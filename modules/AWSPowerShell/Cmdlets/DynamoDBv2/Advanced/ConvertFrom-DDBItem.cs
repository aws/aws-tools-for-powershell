/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.PowerShell.Cmdlets.DDB.Model;
using System.Collections;
using System.ComponentModel;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Converts a dictionary of DynamoDB attribute values to a dictionary of types commonly used in PowerShell.
    /// </summary>
    [Cmdlet("ConvertFrom", "DDBItem")]
    [AWSCmdlet("Converts a dictionary of DynamoDB attribute values to a dictionary of types commonly used in PowerShell.")]
    [OutputType("System.Collections.Hashtable")]
    [AWSCmdletOutput("System.Collections.HashTable", "This cmdlet returns a dictionary of common types.")]
    public class ConvertFromDDBItemCmdlet : BaseCmdlet
    {
        /// <summary>
        /// <para>
        /// <para>A dictionary of DynamoDB attribute values to convert to a Hashtable of types commonly used in PowerShell.
        /// </para><para> The following DynamoDB attribute values will be converted to the following types:</para></para><ul>
        /// <li><para><code>S</code> will be converted to <code>String</code>.</para></li>
        /// <li><para><code>BOOL</code> will be converted to <code>Boolean</code>.</para></li>
        /// <li><para><code>N</code> will be converted to the type specified by the <code>NumericType</code> parameter.</para></li>
        /// <li><para><code>B</code> will be converted to <code>MemoryStream</code>.</para></li>
        /// <li><para><code>M</code> will be converted to <code>Hashtable</code>.</para></li>
        /// <li><para><code>SS</code> will be converted to <code>HashSet&lt;String&gt;</code>.</para></li>
        /// <li><para><code>NS</code> will be converted to a HashSet of the type specified by the parameter <code>NumericType</code>.</para></li>
        /// <li><para><code>BS</code> will be converted to <code>HashSet&lt;MemoryStream&gt;</code>.</para></li>
        /// <li><para><code>L</code> will be converted to <code>Array</code>.</para></li>
        /// </ul>
        /// </summary>
        [Parameter(
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true
        )]
        [Alias("Item", "Items", "Attributes", "UnprocessedItems")]
        public System.Collections.Generic.Dictionary<string, Amazon.DynamoDBv2.Model.AttributeValue>[] InputObject { get; set; }

        private Type _NumericType = typeof(double);
        #region Parameter NumericType
        /// <summary>
        /// Specifies the type to which numeric values will be converted. This conversion is required because DynamoDB stores numeric values as strings. The default value for this parameter is <code>Double</code>. There is a risk for loss of precision when converting to <code>Single</code> or <code>Double</code> because these types do not support up to 38 digits of precision as DynamoDB numeric values do.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateSet(
            "System.Int16",
            "System.UInt16",
            "System.Int32",
            "System.UInt32",
            "System.Int64",
            "System.UInt64",
            "System.Decimal",
            "System.Single",
            "System.Double"
            )]
        public Type NumericType {
            get
            {
                return _NumericType;
            }
            set
            {
                _NumericType = value;
            }
        }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            foreach (System.Collections.Generic.Dictionary<string, Amazon.DynamoDBv2.Model.AttributeValue> ddbDictionary in InputObject)
            {
                System.Collections.IDictionary dictionary = ConvertFromDDBItemAsIDictionary(ddbDictionary);
                WriteObject(dictionary);
            }
        }

        private Object ConvertFromDDBAttribute(Amazon.DynamoDBv2.Model.AttributeValue attributeValue)
        {
            if (attributeValue.SS.Count > 0)
            {
                return new HashSet<string>(attributeValue.SS.ToList());
            }
            else if (attributeValue.S != null)
            {
                return attributeValue.S;
            }
            else if (attributeValue.NS.Count > 0)
            {
                switch (NumericType.Name)
                {
                    case "Int16":
                        var int16List = attributeValue.NS.Select(Int16.Parse).ToList();
                        return new HashSet<Int16>(int16List);
                    case "UInt16":
                        var uInt16List = attributeValue.NS.Select(UInt16.Parse).ToList();
                        return new HashSet<UInt16>(uInt16List);
                    case "Int32":
                        var int32List = attributeValue.NS.Select(Int32.Parse).ToList();
                        return new HashSet<Int32>(int32List);
                    case "UInt32":
                        var uInt32List = attributeValue.NS.Select(UInt32.Parse).ToList();
                        return new HashSet<UInt32>(uInt32List);
                    case "Int64":
                        var int64List = attributeValue.NS.Select(Int64.Parse).ToList();
                        return new HashSet<Int64>(int64List);
                    case "UInt64":
                        var uInt64List = attributeValue.NS.Select(UInt64.Parse).ToList();
                        return new HashSet<UInt64>(uInt64List);
                    case "Decimal":
                        var decimalList = attributeValue.NS.Select(Decimal.Parse).ToList();
                        return new HashSet<Decimal>(decimalList);
                    case "Single":
                        var singleList =attributeValue.NS.Select(Single.Parse).ToList();
                        return new HashSet<Single>(singleList);
                    case "Double":
                        var doubleList =attributeValue.NS.Select(Double.Parse).ToList();
                        return new HashSet<Double>(doubleList);
                    default:
                        throw new InvalidOperationException($"The value '{NumericType.Name}' provided for the parameter NumericType is not supported.");
                }
            }
            else if (attributeValue.N != null)
            {
                var converter = TypeDescriptor.GetConverter(NumericType);
                var result = converter.ConvertFrom(attributeValue.N);
                return result;
            }
            else if (attributeValue.IsBOOLSet)
            {
                return attributeValue.BOOL;
            }
            else if (attributeValue.BS.Count > 0)
            {
                return new HashSet<System.IO.MemoryStream>(attributeValue.BS.ToList());
            }
            else if (attributeValue.B != null)
            {
                return attributeValue.B;
            }
            else if (attributeValue.NULL == true)
            {
                return null;
            }
            else if (attributeValue.IsLSet)
            {
                return ConvertFromDDBItemAsArray(attributeValue.L);
            }
            else if (attributeValue.M != null)
            {
                return ConvertFromDDBItemAsIDictionary(attributeValue.M);
            }
            else
            {
                throw new InvalidOperationException($"Invalid DynamoDB item attribute value '{attributeValue}'");
            }
        }
        
        public IDictionary ConvertFromDDBItemAsIDictionary(Dictionary<String, Amazon.DynamoDBv2.Model.AttributeValue> ddbItem)
        {
            System.Collections.IDictionary dictionary;

            dictionary = new System.Collections.Hashtable();

            foreach (System.Collections.Generic.KeyValuePair<string, Amazon.DynamoDBv2.Model.AttributeValue> keyValuePair in ddbItem)
            {
                dictionary[keyValuePair.Key] = ConvertFromDDBAttribute(keyValuePair.Value);
            }
            return dictionary;
        }

        private Array ConvertFromDDBItemAsArray(System.Collections.Generic.List<Amazon.DynamoDBv2.Model.AttributeValue> attributeValueList)
        {
            ArrayList list = new ArrayList();

            foreach (Amazon.DynamoDBv2.Model.AttributeValue attributeValue in attributeValueList)
            {
                list.Add(ConvertFromDDBAttribute(attributeValue));
            }
            return list.ToArray();
        }
    }
}
