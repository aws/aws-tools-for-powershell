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
using System.Management.Automation;
using Amazon.PowerShell.Common;
using Amazon.PowerShell.Cmdlets.DDB.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Adds a new Amazon DynamoDB KeySchemaElement instance to the supplied TableSchema object.
    /// </summary>
    [Cmdlet("Add", "DDBKeySchema")]
    [OutputType("TableSchema")]
    [AWSCmdlet("Adds a new Amazon DynamoDB KeySchemaElement instance to the supplied TableSchema object.")]
    [AWSCmdletOutput("Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema", "This cmdlet returns an updated Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema object to the pipeline.")]
    [AWSClientCmdlet("Amazon DynamoDB", "DDB", null, "DynamoDBv2")]
    public class AddDDBKeySchemaCmdlet : BaseCmdlet
    {
        #region Parameter Schema
        /// <summary>
        /// A previously constructed object to which the new key schema element will be added to any
        /// attached KeySchema property collection.
        /// </summary>
        [Parameter(ValueFromPipeline = true, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema Schema { get; set; }
        #endregion

        #region Parameter KeyName
        /// <summary>
        /// The name of the key to be applied to the schema. If a key with the specified name already exists 
        /// an error is thrown.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String KeyName { get; set; }
        #endregion

        #region Parameter KeyType 
        /// <summary>
        /// The key type. Valid values are "HASH" or "RANGE". If not specified, "HASH" is assumed. 
        /// </summary>
        [Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.KeyType")]
        public Amazon.DynamoDBv2.KeyType KeyType { get; set; }
        #endregion

        #region Parameter KeyDataType
        /// <summary>
        /// <para>
        /// The data type of the key as specified by the Amazon DynamoDB api. If an attribute 
        /// entry for the key already exists in the attribute definitions of the supplied schema 
        /// object, this parameter can be omitted otherwise an attribute will be added and defined 
        /// as the declared type.
        /// </para>
        /// <para>
        /// Valid values for data type: "S" string, "N" number or "B" binary.
        /// </para>
        /// </summary>
        [Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ScalarAttributeType")]
        public Amazon.DynamoDBv2.ScalarAttributeType KeyDataType { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var schemaObj = DDBSchemaCmdletHelper.TableSchemaFromParameter(Schema);
                if (schemaObj == null)
                    throw new ArgumentException("Expected TableSchema object to update.");

                var keyType = !string.IsNullOrEmpty(KeyType) ? KeyType : Amazon.DynamoDBv2.KeyType.HASH;
                schemaObj.AddKey(KeyName, keyType, KeyDataType);

                WriteObject(schemaObj);
            }
            catch (Exception e)
            {
                ThrowError(e);
            }
        }
    }
}
