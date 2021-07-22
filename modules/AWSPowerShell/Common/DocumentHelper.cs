/*
 * Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */

using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using Amazon.Runtime;
using Amazon.Runtime.Documents;

namespace Amazon.PowerShell.Common
{
    /// <summary>
    /// Conversion methods for changing a <see cref="PSObject"/> into a
    /// <see cref="Amazon.Runtime.Documents.Document"/>
    /// </summary>
    public static class DocumentHelper
    {
        public static Document ToDocument(PSObject obj)
        {
            return ToDocument(obj.BaseObject);
        }

        private static Document ToDocument(object obj)
        {
            if (null == obj)
                return new Document();

            if (obj is PSObject psObject)
                return ToDocument(psObject);

            if (obj is Document doc)
                return doc;

            if (obj is bool b)
                return new Document(b);

            if (obj is int i)
                return new Document(i);

            if (obj is float f)
                return new Document(f);

            if (obj is double d)
                return new Document(d);

            if (obj is long l)
                return new Document(l);

            if (obj is string s)
                return new Document(s);

            if (obj is object[] array)
                return new Document(array.AsEnumerable().Select(ToDocument).ToList());

            if (obj is Hashtable ht)
            {
                return new Document(
                    ht.Keys.Cast<object>().ToDictionary(
                        key => key.ToString(),
                        key => ToDocument(ht[key])));
            }

            throw new ArgumentException(
                $"A [{obj.GetType().FullName}] can not be represented as a valid {typeof(Document).FullName}");
        }
    }
}