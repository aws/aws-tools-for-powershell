/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// <para>
    /// Adds a new Amazon DynamoDB local or global secondary index schema property to the supplied object, 
    /// or returns a new object initialized with the index schema. 
    /// </para>
    /// <para>
    /// The default behavior of this cmdlet is to create a local secondary index. To specify that the index
    /// is global, use the -Global switch and also add the ReadCapacity and WriteCapacity parameters to
    /// indicate the required throughput for the index.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "DDBIndexSchema", DefaultParameterSetName = LocalIndexParameterSet)]
    [OutputType("TableSchema")]
    [AWSCmdlet("Adds a new Amazon DynamoDB global or local secondary index schema property to the supplied TableSchema object.")]
    [AWSCmdletOutput("Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema", "This cmdlet returns an updated Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema object to the pipeline.")]
    public class AddDDBIndexSchemaCmdlet : BaseCmdlet
    {
        const string LocalIndexParameterSet = "LocalIndex";
        const string GlobalIndexParameterSet = "GlobalIndex";

        #region Parameter Schema
        /// <summary>
        /// A previously constructed TableSchema object to which the new index schema element will be added.
        /// </summary>
        [Parameter(ValueFromPipeline = true, Mandatory = true)]
        public Amazon.PowerShell.Cmdlets.DDB.Model.TableSchema Schema { get; set; }
        #endregion

        #region Parameter IndexName
        /// <summary>
        /// The name of the secondary index. Must be unique only for this table that will be created.
        /// If an index with the same name already exists on the pipelined object an error is thrown.
        /// </summary>
        [Parameter(Position = 0, Mandatory = true)]
        public System.String IndexName { get; set; }
        #endregion

        #region Parameter RangeKeyName
        /// <summary>
        /// The name of the range key to add to the secondary index. This is a mandatory parameter for
        /// local indexes. Global indexes can be defined with either a range key or a hash key, either
        /// of which can be any attribute in the table.
        /// </summary>
        [Parameter(ParameterSetName = LocalIndexParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = GlobalIndexParameterSet)]
        public System.String RangeKeyName { get; set; }
        #endregion

        #region Parameter RangeKeyDataType
        /// <summary>
        /// The data type of the range key as specified by the Amazon DynamoDB api. 
        /// This is a mandatory parameter for local indexes. Global indexes can be defined with either 
        /// a range key or a hash key, either of which can be any attribute in the table.
        /// </summary>
        [Parameter(ParameterSetName = LocalIndexParameterSet, Mandatory = true)]
        [Parameter(ParameterSetName = GlobalIndexParameterSet)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ScalarAttributeType")]
        public Amazon.DynamoDBv2.ScalarAttributeType RangeKeyDataType { get; set; }
        #endregion

        #region Parameter ProjectionType
        /// <summary>
        /// Specifies attributes that are copied (projected) from the table into the index. These are in addition 
        /// to the primary key attributes and index key attributes, which are automatically projected. 
        /// Valid values:
        /// KEYS_ONLY - Only the index and primary keys are projected into the index.
        /// INCLUDE   - Only the specified table attributes are projected into the index. The list of projected attributes
        ///             are specified with the -NonKeyAttribute parameter.
        /// ALL       - All of the table attributes are projected into the index.
        /// </summary>
        [Parameter]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ProjectionType")]
        public Amazon.DynamoDBv2.ProjectionType ProjectionType { get; set; }
        #endregion

        #region Parameter NonKeyAttribute
        /// <summary>
        /// A collection of one or more non-key attribute names that are projected into the index. The total count of attributes 
        /// specified in NonKeyAttributes, summed across all of the secondary indexes, must not exceed 20. If you project the same 
        /// attribute into two different indexes, this counts as two distinct attributes when determining the total.
        /// </summary>
        [Parameter]
        public System.String[] NonKeyAttribute { get; set; }
        #endregion

        #region Parameter Global
        /// <summary>
        /// If set, specifies that the index components described by the parameters should be
        /// added as a global secondary index entry. The ReadCapacity and WriteCapacity parameters 
        /// are also required when defining a global index.
        /// </summary>
        [Parameter(ParameterSetName = GlobalIndexParameterSet)]
        public SwitchParameter Global { get; set; }
        #endregion

        #region Parameter HashKeyName
        /// <summary>
        /// The name of the hash key for the global secondary index.
        /// </summary>
        [Parameter(ParameterSetName = GlobalIndexParameterSet)]
        public System.String HashKeyName { get; set; }
        #endregion

        #region Parameter HashKeyDataType
        /// <summary>
        /// The data type of the hash key for the global index, as specified by the Amazon DynamoDB api. 
        /// </summary>
        [Parameter(ParameterSetName = GlobalIndexParameterSet)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.ScalarAttributeType")]
        public Amazon.DynamoDBv2.ScalarAttributeType HashKeyDataType { get; set; }
        #endregion

        #region Parameter ReadCapacity
        /// <summary>
        /// The provisioned throughput setting for read operations on the secondary index if the index is global (the -Global
        /// switch is specified). Ignored for local secondary indexes (the default).
        /// </summary>
        [Parameter(ParameterSetName = GlobalIndexParameterSet)]
        public System.Int64? ReadCapacity { get; set; }
        #endregion

        #region Parameter WriteCapacity
        /// <summary>
        /// The provisioned throughput setting for write operations on the secondary index if the index is global (the -Global
        /// switch is specified). Ignored for local secondary indexes (the default).
        /// </summary>
        [Parameter(ParameterSetName = GlobalIndexParameterSet)]
        public System.Int64? WriteCapacity { get; set; }
        #endregion

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                var schemaObj = DDBSchemaCmdletHelper.TableSchemaFromParameter(Schema);
                if (schemaObj == null)
                    throw new ArgumentException("Expected TableSchema object to update.");

                if (this.Global.IsPresent)
                {
                    if (string.IsNullOrEmpty(RangeKeyName) && string.IsNullOrEmpty(HashKeyName))
                        throw new ArgumentNullException("Either RangeKeyName or HashKeyName needs to be specified for a global secondary index.");

                    if (ReadCapacity.HasValue && WriteCapacity.HasValue)
                    {
                        schemaObj.SetGlobalSecondaryIndex(IndexName,
                                                          HashKeyName,
                                                          HashKeyDataType,
                                                          RangeKeyName,
                                                          RangeKeyDataType,
                                                          ReadCapacity.Value,
                                                          WriteCapacity.Value,
                                                          ProjectionType,
                                                          NonKeyAttribute);
                    }
                    else
                        throw new ArgumentNullException(
                            "Both ReadCapacity and WriteCapacity must be specified for a global secondary index.");
                }
                else
                {
                    schemaObj.SetLocalSecondaryIndex(IndexName, RangeKeyName, RangeKeyDataType, ProjectionType, NonKeyAttribute);
                }

                WriteObject(schemaObj);
            }
            catch (Exception e)
            {
                ThrowError(e);
            }
        }
    }
}
