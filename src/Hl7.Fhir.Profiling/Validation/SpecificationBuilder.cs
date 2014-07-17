﻿/*
* Copyright (c) 2014, Furore (info@furore.com) and contributors
* See the file CONTRIBUTORS for details.
*
* This file is licensed under the BSD 3-Clause license
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhir.IO;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;
using Fhir.Profiling.IO;

namespace Fhir.Profiling
{
    public class SpecificationBuilder
    {
        private Specification specification = new Specification();
        public SpecificationResolver resolver = null;
        public SpecificationLoader loader = null;
        // SpecificationSealer (die code moet naar een eigen class)

        public SpecificationBuilder(SpecificationResolver resolver = null)
        {
            this.resolver = resolver;
            loader = new SpecificationLoader(this);
        }

        private List<string> ResolvedProfileUris = new List<string>();

        public TypeRef CreateTypeRef(string code, string profileUri)
        {
            // Create new or refer to existing

            TypeRef typeref = new TypeRef(code, profileUri);
            TypeRef existing = specification.FindTypeRef(typeref);
           
            if (existing != null)
            {
                return existing;
            }
            else
            {
                specification.Add(typeref);
                return typeref;
            }
        }

        public void Add(IEnumerable<ValueSet> valuesets)
        {
            specification.Add(valuesets);
        }

        public void Add(IEnumerable<Structure> structures)
        {
            specification.Add(structures);
        }

        private void _linkBindings()
        {
            foreach (Element element in specification.Elements)
            {
                if (element.BindingUri != null)
                    element.Binding = specification.GetValueSetByUri(element.BindingUri);
            }
        }

        public void Add(string uri)
        {
            if (resolver != null)
            {
                if (!ResolvedProfileUris.Contains(uri))
                {
                    IEnumerable<Structure> structures = Resolve(uri);
                    this.Add(structures);
                    ResolvedProfileUris.Add(uri);
                    // todo: this not give an error if unresolved.
                }
            }
            else
            {
                throw new InvalidOperationException("This ProfileBuilder has no resolver for uri's");
            }
        }

        private IEnumerable<TypeRef> UnlinkedTypeRefs
        {
            get
            {
                return specification.Elements.SelectMany(e => e.TypeRefs).Where(r => r.Structure == null);
            }
        }

        private IEnumerable<string> CollectProfileUris()
        {
            return specification.Elements.SelectMany(e => e.TypeRefs).Select(t => t.ProfileUri).Distinct().Where(s => s != null);
            
        }

        private void _linkTypeRefs()
        {
            foreach (TypeRef typeref in UnlinkedTypeRefs)
            {
                typeref.Structure = specification.GetStructureByName(typeref.Code);
            }
        }

        private void _linkElementRefs()
        {
            foreach (Structure structure in specification.Structures)
            {
                foreach (Element element in structure.Elements)
                {
                    if (element.ElementRef == null && element.ElementRefPath != null)
                        element.ElementRef = specification.GetElementByPath(structure, element.ElementRefPath);
                }
            }
        }

        private bool _tryLinkToParent(Structure structure, Element element)
        {
            Element parent = specification.ParentOf(structure, element);
            if (parent != null)
            {
                parent.Children.Add(element);
                return true;
            }
            return false;
        }

        public void _linkElements(Structure structure)
        {
            foreach (Element e in structure.Elements)
            {
                _tryLinkToParent(structure, e);
            }
        }

        public void _linkElements()
        {
            foreach (Structure structure in specification.Structures)
            {
                _linkElements(structure);
            }
        }

        public void _addNameSpace(Element element)
        {
            if (element.HasTypeRef)
            {
                TypeRef typeref = element.TypeRefs.FirstOrDefault(t => t.Structure != null);
                if (typeref != null)
                {
                    element.NameSpacePrefix = typeref.Structure.NameSpacePrefix;
                }
            }

            if (element.NameSpacePrefix == null)
                element.NameSpacePrefix = FhirNamespaceManager.Fhir;
            
        }

        public void _addNameSpaces()
        {
            foreach (Element element in specification.Elements.Where(e => e.NameSpacePrefix == null))
            {
                _addNameSpace(element);
            }
        }

        private void _compileConstraints()
        {
            foreach (Constraint c in specification.Constraints)
            {
                if (!c.Compiled)
                    ConstraintCompiler.Compile(c);
            }
        }
        

        /// <summary>
        /// Make the profile complete and usable by linking all internal structures and perform precompilation
        /// </summary>
        private void _surrect()
        {
            _linkBindings();
            _linkElements();
            _linkTypeRefs();
            _linkElementRefs();
            _compileConstraints();
            _addNameSpaces();
            specification.Seal();
        }

        public IEnumerable<Structure> Resolve(Uri uri)
        {
            Profile profile = resolver.GetProfile(uri);
            if (profile != null)
            {
                return loader.LoadStructures(profile);
            }
            else
            {
                return Enumerable.Empty<Structure>();
            }
        }

        public IEnumerable<Structure> Resolve(string uri)
        {
            //uri = uri.ToLower();
            return Resolve(new Uri(uri));
        }

        public IEnumerable<Structure> Resolve(TypeRef typeref)
        {
            Uri uri;
            if (typeref.ProfileUri == null)
            {
                string name = typeref.Code.ToLower(); // todo: this is a temporary fix!!!
                uri = new Uri("http://hl7.org/fhir/profile/" + name);
            }
            else
            {
                uri = new Uri(typeref.ProfileUri);
            }
            return Resolve(uri);
        }
      
        private int resolveTypeRef(TypeRef typeref)
        {
            IEnumerable<Structure> structures = Resolve(typeref);
            this.Add(structures);
            return structures.Count();
        }

        private int resolveTypeRefs()
        {
            int count = 0;
            // Resolve all typerefs that are not resource references

            List<TypeRef> typerefs = specification.TypeRefs.Where(t => t.Resolution == Resolution.New).ToList();
            // list because we change the resolution.

            foreach (TypeRef typeref in typerefs)
            {
                count += resolveTypeRef(typeref);
                typeref.Resolution = (count > 0) ? Resolution.Resolved : Resolution.Unresolvable;
            }
            return count;
        }

        public void Resolve()
        {
            int count;
            do
            {
                count = resolveTypeRefs();

            }
            while (count > 0);
            
        }

        public Specification ToSpecification()
        {
            if (!specification.Sealed)
            {
                _surrect();
            }
            return specification;

        }
    }
}
