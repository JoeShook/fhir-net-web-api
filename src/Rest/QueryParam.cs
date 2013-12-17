﻿/*
  Copyright (c) 2011-2013, HL7, Inc.
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without modification, 
  are permitted provided that the following conditions are met:
  
   * Redistributions of source code must retain the above copyright notice, this 
     list of conditions and the following disclaimer.
   * Redistributions in binary form must reproduce the above copyright notice, 
     this list of conditions and the following disclaimer in the documentation 
     and/or other materials provided with the distribution.
   * Neither the name of HL7 nor the names of its contributors may be used to 
     endorse or promote products derived from this software without specific 
     prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
  POSSIBILITY OF SUCH DAMAGE.
  

*/


using Hl7.Fhir.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Hl7.Fhir.Rest
{
    public static class QueryParam
    {
        /// <summary>
        /// Parses the possibly escaped key=value quey parameter into a (key,value) Tuple
        /// </summary>
        /// <param name="param"></param>
        /// <returns>A Tuple<string,string> containing the key and value. Value maybe null if
        /// only the key was specified as a query parameter.</returns>
        public static Tuple<string, string> Parse(string param)
        {
            if (param == null) throw new ArgumentNullException("param");

            string[] pair = param.Split('=');

            var key = Uri.UnescapeDataString(pair[0]);
            var value = pair.Length >= 2 ? String.Join("?", pair.Skip(1)) : null;
            if( value != null ) value = Uri.UnescapeDataString(value);

            return new Tuple<string, string>(key, value);
        }


        /// <summary>
        /// Converts a key,value pair into a query parameters, escaping the key and value
        /// of necessary.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(string key, string value=null)
        {
            if (key == null) throw new ArgumentNullException("key");

            var result = Uri.EscapeDataString(key);

            if( value != null )
                result += "=" + Uri.EscapeDataString(value);

            return result;
        }


        public static string ToString(Tuple<string, string> kv)
        {
            if (kv == null) throw new ArgumentNullException("kv");
            if (kv.Item1 == null) throw new ArgumentException("Key in tuple may not be null", "kv");

            return ToString(kv.Item1, kv.Item2);
        }

        /// <summary>
        /// Builds a query string based on a set of key,value pairs
        /// </summary>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static string Join(IEnumerable<Tuple<string,string>> pars)
        {
            StringBuilder result = new StringBuilder();

            foreach (var kv in pars)
            {
                result.Append(QueryParam.ToString(kv));
                result.Append("&"); 
            }

            return result.ToString().TrimEnd('&');
        }

        public static IEnumerable<Tuple<string, string>> Split(string query)
        {
            if (query == null) throw new ArgumentNullException("query");

            var result = new List<Tuple<string, string>>();

            if (query == String.Empty) return result;

            var q = query.TrimStart('?');

            var querySegments = q.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var segment in querySegments)
            {
                var kv = QueryParam.Parse(segment);
                result.Add(kv);
            }

            return result;
        }
    }

}