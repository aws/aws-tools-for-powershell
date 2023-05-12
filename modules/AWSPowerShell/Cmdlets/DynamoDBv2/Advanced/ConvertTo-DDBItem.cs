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
using System.Collections.Specialized;
using System.Globalization;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Converts a dictionary of types commonly used in PowerShell to a dictionary of DynamoDB attribute values.
    /// </summary>
    [Cmdlet("ConvertTo", "DDBItem")]
    [AWSCmdlet("Converts a dictionary of types commonly used in PowerShell to a dictionary of DynamoDB attribute values.")]
    [OutputType("System.Collections.Hashtable")]
    [AWSCmdletOutput("System.Collections.HashTable", "This cmdlet returns a dictionary of common types.")]
    public class ConvertToDDBItemCmdlet : BaseCmdlet
    {
        /// <summary>
        /// <para>
        /// <para>A dictionary of commonly used PowerShell types to convert to a dictionary of DynamoDB attribute values.
        /// </para><para> The following types will be converted to the following DynamoDB attribute values:</para></para><ul>
        /// <li><para><code>String</code> will be converted to <code>S</code></para></li>
        /// <li><para><code>Boolean</code> will be converted to <code>BOOL</code></para></li>
        /// <li><para>Any numeric type will be converted to <code>N</code></para></li>
        /// <li><para><code>MemoryStream</code> will be converted to <code>B</code></para></li>
        /// <li><para><code>Hashtable</code> will be converted to <code>M</code></para></li>
        /// <li><para><code>HashSet&lt;String&gt;</code> will be converted to <code>SS</code></para></li>
        /// <li><para>Any numeric HashSet will be converted to <code>NS</code></para></li>
        /// <li><para><code>HashSet&lt;MemoryStream&gt;</code> will be converted to <code>BS</code></para></li>
        /// <li><para><code>Array</code> will be converted to <code>L</code></para></li>
        /// <li><para><code>ArrayList</code> will be converted to <code>L</code></para></li>
        /// <li><para>A generic list of any supported type above will be converted to <code>L</code></para></li>
        /// </ul>
        /// </summary>
        [Parameter(
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true,
            Mandatory = true
        )]
        public IDictionary[] InputObject { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            foreach (IDictionary item in InputObject)
            {
                Dictionary<String, Amazon.DynamoDBv2.Model.AttributeValue> ddbDictionary = ConvertToDDBItemDictionary(item);
                WriteObject(ddbDictionary);
            }
        }

        private DynamoDBv2.Model.AttributeValue ConvertToDDBAttribute(Object inputObject, string attributeName)
        {
            Amazon.DynamoDBv2.Model.AttributeValue ddbAttribute;

            Object[] objectArray;
            var inputObjectType = inputObject?.GetType();
            if (inputObject == null)
            {
                ddbAttribute = new AttributeValue { NULL = true };
            }
            else if (inputObjectType.FullName == "Amazon.DynamoDBv2.Model.AttributeValue")
            {
                return (Amazon.DynamoDBv2.Model.AttributeValue)inputObject;
            }
            else if (inputObjectType.FullName == "System.Management.Automation.PSObject")
            {
                var psObject = (PSObject)inputObject;
                return (ConvertToDDBAttribute(psObject.BaseObject, attributeName));
            }
            else if (inputObjectType.IsArray)
            {
                objectArray = (System.Object[])inputObject;
                ddbAttribute = new AttributeValue {
                    L = ConvertToDDBItemList(objectArray, attributeName),
                    IsLSet = true
                };
            }
            else if (inputObjectType.FullName == "System.Collections.ArrayList")
            {
                var arrayList = (System.Collections.ArrayList)inputObject;
                objectArray = arrayList.ToArray();
                ddbAttribute = new AttributeValue {
                    L = ConvertToDDBItemList(objectArray, attributeName),
                    IsLSet = true
                };
            }
            else if (inputObjectType.Name == "HashSet`1")
            {
                ddbAttribute = ConvertHashSetValue(inputObject, inputObjectType, attributeName);
            }
            else if (inputObjectType.Name == "List`1")
            {
                ddbAttribute = ConvertListValue(inputObject, inputObjectType, attributeName);
            }
            else
            {
                ddbAttribute = ConvertSingleValue(inputObject, inputObjectType, attributeName);
            }

            return ddbAttribute;
        }

        private AttributeValue ConvertHashSetValue(Object inputObject, Type inputObjectType, string attributeName)
        {
                Type genericListType = inputObjectType.GenericTypeArguments[0];
                var genericListTypeName = genericListType.Name;

                switch (genericListTypeName)
                {
                    case nameof(String):
                        var stringSet = (System.Collections.Generic.HashSet<String>)inputObject;
                        var stringList = stringSet.ToList();
                        return new AttributeValue { SS = stringList };
                    case nameof(Int16):
                        var int16Set = (System.Collections.Generic.HashSet<Int16>)inputObject;
                        var int16List = int16Set.ToList();
                        return new AttributeValue { NS = int16List.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(UInt16):
                        var uInt16Set = (System.Collections.Generic.HashSet<UInt16>)inputObject;
                        var uInt16List = uInt16Set.ToList();
                        return new AttributeValue { NS = uInt16List.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(Int32):
                        var int32Set = (System.Collections.Generic.HashSet<Int32>)inputObject;
                        var int32List = int32Set.ToList();
                        return new AttributeValue { NS = int32List.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(UInt32):
                        var uInt32Set = (System.Collections.Generic.HashSet<UInt32>)inputObject;
                        var uInt32List = uInt32Set.ToList();
                        return new AttributeValue { NS = uInt32List.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(Int64):
                        var int64Set = (System.Collections.Generic.HashSet<Int64>)inputObject;
                        var int64List = int64Set.ToList();
                        return new AttributeValue { NS = int64List.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(UInt64):
                        var uInt64Set = (System.Collections.Generic.HashSet<UInt64>)inputObject;
                        var uInt64List = uInt64Set.ToList();
                        return new AttributeValue { NS = uInt64List.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(Decimal):
                        var decimalSet = (System.Collections.Generic.HashSet<Decimal>)inputObject;
                        var decimalList = decimalSet.ToList();
                        return new AttributeValue { NS = decimalList.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(Single):
                        var singleSet = (System.Collections.Generic.HashSet<Single>)inputObject;
                        var singleList = singleSet.ToList();
                        return new AttributeValue { NS = singleList.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(Double):
                        var doubleSet = (System.Collections.Generic.HashSet<Double>)inputObject;
                        var doubleList = doubleSet.ToList();
                        return new AttributeValue { NS = doubleList.ConvertAll<string>(x => x.ToString(CultureInfo.InvariantCulture)) };
                    case nameof(System.IO.MemoryStream):
                        var memoryStreamSet = (System.Collections.Generic.HashSet<System.IO.MemoryStream>)inputObject;
                        var memoryStreamList = memoryStreamSet.ToList();
                        return new AttributeValue { BS = memoryStreamList };
                    default:
                        throw new InvalidOperationException($"The data type '{inputObjectType.FullName}' provided for the attribute '{attributeName}' is not supported for conversion into a DynamoDB attribute value.");
                }
        }

        private AttributeValue ConvertListValue(Object inputObject, Type inputObjectType, string attributeName)
        {
            Type genericListType = inputObjectType.GenericTypeArguments[0];
            var genericListTypeName = genericListType.Name;
            Object[] objectArray;

            switch (genericListTypeName)
            {
                case nameof(String):
                    var stringGenericList = (System.Collections.Generic.List<String>)inputObject;
                    objectArray = stringGenericList.Cast<object>().ToArray();
                    break;
                case nameof(Int16):
                    var int16GenericList = (System.Collections.Generic.List<Int16>)inputObject;
                    objectArray = int16GenericList.Cast<object>().ToArray();
                    break;
                case nameof(UInt16):
                    var uInt16GenericList = (System.Collections.Generic.List<UInt16>)inputObject;
                    objectArray = uInt16GenericList.Cast<object>().ToArray();
                    break;
                case nameof(Int32):
                    var int32GenericList = (System.Collections.Generic.List<Int32>)inputObject;
                    objectArray = int32GenericList.Cast<object>().ToArray();
                    break;
                case nameof(UInt32):
                    var uInt32GenericList = (System.Collections.Generic.List<UInt32>)inputObject;
                    objectArray = uInt32GenericList.Cast<object>().ToArray();
                    break;
                case nameof(Int64):
                    var int64GenericList = (System.Collections.Generic.List<Int64>)inputObject;
                    objectArray = int64GenericList.Cast<object>().ToArray();
                    break;
                case nameof(UInt64):
                    var uInt64GenericList = (System.Collections.Generic.List<UInt64>)inputObject;
                    objectArray = uInt64GenericList.Cast<object>().ToArray();
                    break;
                case nameof(Decimal):
                    var decimalGenericList = (System.Collections.Generic.List<Decimal>)inputObject;
                    objectArray = decimalGenericList.Cast<object>().ToArray();
                    break;
                case nameof(Single):
                    var singleGenericList = (System.Collections.Generic.List<Single>)inputObject;
                    objectArray = singleGenericList.Cast<object>().ToArray();
                    break;
                case nameof(Double):
                    var doubleGenericList = (System.Collections.Generic.List<Double>)inputObject;
                    objectArray = doubleGenericList.Cast<object>().ToArray();
                    break;
                case nameof(Boolean):
                    var booleanGenericList = (System.Collections.Generic.List<Boolean>)inputObject;
                    objectArray = booleanGenericList.Cast<object>().ToArray();
                    break;
                case nameof(System.IO.MemoryStream):
                    var memoryStreamGenericList = (System.Collections.Generic.List<System.IO.MemoryStream>)inputObject;
                    objectArray = memoryStreamGenericList.Cast<object>().ToArray();
                    break;
                case nameof(Object):
                    var objectGenericList = (System.Collections.Generic.List<Object>)inputObject;
                    objectArray = objectGenericList.ToArray();
                    break;
                default:
                    throw new InvalidOperationException($"The data type '{inputObjectType.FullName}' provided for the attribute '{attributeName}' is not supported for conversion into a DynamoDB attribute value.");
            }
            return new AttributeValue {
                L = ConvertToDDBItemList(objectArray, attributeName),
                IsLSet = true
            };
        }

        private AttributeValue ConvertSingleValue(Object inputObject, Type inputObjectType, string attributeName)
        {
            switch (inputObjectType.Name)
            {
                case nameof(String):
                    return new AttributeValue { S = (string)inputObject };
                case nameof(Boolean):
                    return new AttributeValue { BOOL = (Boolean)inputObject };
                case nameof(Decimal):
                    var decimalValue = (Decimal)inputObject;
                    return new AttributeValue { N = (string)decimalValue.ToString(CultureInfo.InvariantCulture) };
                case nameof(Single):
                    var singleValue = (Single)inputObject;
                    return new AttributeValue { N = (string)singleValue.ToString(CultureInfo.InvariantCulture) };
                case nameof(Double):
                    var doubleValue = (Double)inputObject;
                    return new AttributeValue { N = (string)doubleValue.ToString(CultureInfo.InvariantCulture) };
                case nameof(Int16):
                    var int16Value = (Int16)inputObject;
                    return new AttributeValue { N = (string)int16Value.ToString(CultureInfo.InvariantCulture) };
                case nameof(UInt16):
                    var uInt16Value = (UInt16)inputObject;
                    return new AttributeValue { N = (string)uInt16Value.ToString(CultureInfo.InvariantCulture) };
                case nameof(Int32):
                    var int32Value = (Int32)inputObject;
                    return new AttributeValue { N = (string)int32Value.ToString(CultureInfo.InvariantCulture) };
                case nameof(UInt32):
                    var uInt32Value = (UInt32)inputObject;
                    return new AttributeValue { N = (string)uInt32Value.ToString(CultureInfo.InvariantCulture) };
                case nameof(Int64):
                    var int64Value = (Int64)inputObject;
                    return new AttributeValue { N = (string)int64Value.ToString(CultureInfo.InvariantCulture) };
                case nameof(UInt64):
                    var uInt64Value = (UInt64)inputObject;
                    return new AttributeValue { N = (string)uInt64Value.ToString(CultureInfo.InvariantCulture) };
                case nameof(System.IO.MemoryStream):
                    return new AttributeValue { B = (System.IO.MemoryStream)inputObject };
                case nameof(System.Collections.Hashtable):
                    return new AttributeValue {
                        M = ConvertToDDBItemDictionary((System.Collections.Hashtable)inputObject),
                        IsMSet = true
                    };
                default:
                    throw new InvalidOperationException($"The data type '{inputObjectType.FullName}' provided for the attribute '{attributeName}' is not supported for conversion into a DynamoDB attribute value.");
            }
        }

        private Dictionary<string, DynamoDBv2.Model.AttributeValue> ConvertToDDBItemDictionary(IDictionary iDictionary)
        {
            var ddbDictionary = new Dictionary<String, Amazon.DynamoDBv2.Model.AttributeValue>();
            foreach (DictionaryEntry entry in iDictionary)
            {
                string attributeName = entry.Key.ToString();
                ddbDictionary[attributeName] = ConvertToDDBAttribute(entry.Value, attributeName);
            }
            return ddbDictionary;
        }

        private List<Amazon.DynamoDBv2.Model.AttributeValue> ConvertToDDBItemList(System.Object[] array, string attributeName)
        {
            var ddbList = new List<Amazon.DynamoDBv2.Model.AttributeValue>();

            foreach (Object item in array)
            {
                var ddbAttribute = ConvertToDDBAttribute(item, attributeName);
                ddbList.Add(ddbAttribute);
            }

            return ddbList;
        }
    }
}
