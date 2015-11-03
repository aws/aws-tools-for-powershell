/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Modifies the provisioned throughput settings, global secondary indexes, or DynamoDB
    /// Streams settings for a given table.
    /// 
    ///  
    /// <para>
    /// You can only perform one of the following operations at once:
    /// </para><ul><li><para>
    /// Modify the provisioned throughput settings of the table.
    /// </para></li><li><para>
    /// Enable or disable Streams on the table.
    /// </para></li><li><para>
    /// Remove a global secondary index from the table.
    /// </para></li><li><para>
    /// Create a new global secondary index on the table. Once the index begins backfilling,
    /// you can use <i>UpdateTable</i> to perform other operations.
    /// </para></li></ul><para><i>UpdateTable</i> is an asynchronous operation; while it is executing, the table
    /// status changes from <code>ACTIVE</code> to <code>UPDATING</code>. While it is <code>UPDATING</code>,
    /// you cannot issue another <i>UpdateTable</i> request. When the table returns to the
    /// <code>ACTIVE</code> state, the <i>UpdateTable</i> operation is complete.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DDBTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TableDescription")]
    [AWSCmdlet("Invokes the UpdateTable operation against Amazon DynamoDB.", Operation = new[] {"UpdateTable"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableDescription",
        "This cmdlet returns a TableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.UpdateTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateDDBTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter AttributeDefinition
        /// <summary>
        /// <para>
        /// <para>An array of attributes that describe the key schema for the table and indexes. If
        /// you are adding a new global secondary index to the table, <i>AttributeDefinitions</i>
        /// must include the key element(s) of the new index.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AttributeDefinitions")]
        public Amazon.DynamoDBv2.Model.AttributeDefinition[] AttributeDefinition { get; set; }
        #endregion
        
        #region Parameter GlobalSecondaryIndexUpdate
        /// <summary>
        /// <para>
        /// <para>An array of one or more global secondary indexes for the table. For each index in
        /// the array, you can request one action:</para><ul><li><para><i>Create</i> - add a new global secondary index to the table.</para></li><li><para><i>Update</i> - modify the provisioned throughput settings of an existing global secondary
        /// index.</para></li><li><para><i>Delete</i> - remove a global secondary index from the table.</para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/GSI.OnlineOps.html">Managing
        /// Global Secondary Indexes</a> in the <i>Amazon DynamoDB Developer Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalSecondaryIndexUpdates")]
        public Amazon.DynamoDBv2.Model.GlobalSecondaryIndexUpdate[] GlobalSecondaryIndexUpdate { get; set; }
        #endregion
        
        #region Parameter ReadCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of strongly consistent reads consumed per second before DynamoDB
        /// returns a <i>ThrottlingException</i>. For more information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithTables.html#ProvisionedThroughput">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProvisionedThroughput_ReadCapacityUnits")]
        public System.Int64 ReadCapacity { get; set; }
        #endregion
        
        #region Parameter StreamSpecification_StreamEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether DynamoDB Streams is enabled (true) or disabled (false) on the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean StreamSpecification_StreamEnabled { get; set; }
        #endregion
        
        #region Parameter StreamSpecification_StreamViewType
        /// <summary>
        /// <para>
        /// <para>The DynamoDB Streams settings for the table. These settings consist of:</para><ul><li><para><i>StreamEnabled</i> - Indicates whether DynamoDB Streams is enabled (true) or disabled
        /// (false) on the table.</para></li><li><para><i>StreamViewType</i> - When an item in the table is modified, <i>StreamViewType</i>
        /// determines what information is written to the stream for this table. Valid values
        /// for <i>StreamViewType</i> are:</para><ul><li><para><i>KEYS_ONLY</i> - Only the key attributes of the modified item are written to the
        /// stream.</para></li><li><para><i>NEW_IMAGE</i> - The entire item, as it appears after it was modified, is written
        /// to the stream.</para></li><li><para><i>OLD_IMAGE</i> - The entire item, as it appeared before it was modified, is written
        /// to the stream.</para></li><li><para><i>NEW_AND_OLD_IMAGES</i> - Both the new and the old item images of the item are written
        /// to the stream.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DynamoDBv2.StreamViewType")]
        public Amazon.DynamoDBv2.StreamViewType StreamSpecification_StreamViewType { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter WriteCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of writes consumed per second before DynamoDB returns a <i>ThrottlingException</i>.
        /// For more information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithTables.html#ProvisionedThroughput">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProvisionedThroughput_WriteCapacityUnits")]
        public System.Int64 WriteCapacity { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TableName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBTable (UpdateTable)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.AttributeDefinition != null)
            {
                context.AttributeDefinitions = new List<Amazon.DynamoDBv2.Model.AttributeDefinition>(this.AttributeDefinition);
            }
            if (this.GlobalSecondaryIndexUpdate != null)
            {
                context.GlobalSecondaryIndexUpdates = new List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndexUpdate>(this.GlobalSecondaryIndexUpdate);
            }
            if (ParameterWasBound("ReadCapacity"))
                context.ReadCapacity = this.ReadCapacity;
            if (ParameterWasBound("WriteCapacity"))
                context.WriteCapacity = this.WriteCapacity;
            if (ParameterWasBound("StreamSpecification_StreamEnabled"))
                context.StreamSpecification_StreamEnabled = this.StreamSpecification_StreamEnabled;
            context.StreamSpecification_StreamViewType = this.StreamSpecification_StreamViewType;
            context.TableName = this.TableName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DynamoDBv2.Model.UpdateTableRequest();
            
            if (cmdletContext.AttributeDefinitions != null)
            {
                request.AttributeDefinitions = cmdletContext.AttributeDefinitions;
            }
            if (cmdletContext.GlobalSecondaryIndexUpdates != null)
            {
                request.GlobalSecondaryIndexUpdates = cmdletContext.GlobalSecondaryIndexUpdates;
            }
            
             // populate ProvisionedThroughput
            bool requestProvisionedThroughputIsNull = true;
            request.ProvisionedThroughput = new Amazon.DynamoDBv2.Model.ProvisionedThroughput();
            System.Int64? requestProvisionedThroughput_readCapacity = null;
            if (cmdletContext.ReadCapacity != null)
            {
                requestProvisionedThroughput_readCapacity = cmdletContext.ReadCapacity.Value;
            }
            if (requestProvisionedThroughput_readCapacity != null)
            {
                request.ProvisionedThroughput.ReadCapacityUnits = requestProvisionedThroughput_readCapacity.Value;
                requestProvisionedThroughputIsNull = false;
            }
            System.Int64? requestProvisionedThroughput_writeCapacity = null;
            if (cmdletContext.WriteCapacity != null)
            {
                requestProvisionedThroughput_writeCapacity = cmdletContext.WriteCapacity.Value;
            }
            if (requestProvisionedThroughput_writeCapacity != null)
            {
                request.ProvisionedThroughput.WriteCapacityUnits = requestProvisionedThroughput_writeCapacity.Value;
                requestProvisionedThroughputIsNull = false;
            }
             // determine if request.ProvisionedThroughput should be set to null
            if (requestProvisionedThroughputIsNull)
            {
                request.ProvisionedThroughput = null;
            }
            
             // populate StreamSpecification
            bool requestStreamSpecificationIsNull = true;
            request.StreamSpecification = new Amazon.DynamoDBv2.Model.StreamSpecification();
            System.Boolean? requestStreamSpecification_streamSpecification_StreamEnabled = null;
            if (cmdletContext.StreamSpecification_StreamEnabled != null)
            {
                requestStreamSpecification_streamSpecification_StreamEnabled = cmdletContext.StreamSpecification_StreamEnabled.Value;
            }
            if (requestStreamSpecification_streamSpecification_StreamEnabled != null)
            {
                request.StreamSpecification.StreamEnabled = requestStreamSpecification_streamSpecification_StreamEnabled.Value;
                requestStreamSpecificationIsNull = false;
            }
            Amazon.DynamoDBv2.StreamViewType requestStreamSpecification_streamSpecification_StreamViewType = null;
            if (cmdletContext.StreamSpecification_StreamViewType != null)
            {
                requestStreamSpecification_streamSpecification_StreamViewType = cmdletContext.StreamSpecification_StreamViewType;
            }
            if (requestStreamSpecification_streamSpecification_StreamViewType != null)
            {
                request.StreamSpecification.StreamViewType = requestStreamSpecification_streamSpecification_StreamViewType;
                requestStreamSpecificationIsNull = false;
            }
             // determine if request.StreamSpecification should be set to null
            if (requestStreamSpecificationIsNull)
            {
                request.StreamSpecification = null;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateTable(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TableDescription;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.DynamoDBv2.Model.AttributeDefinition> AttributeDefinitions { get; set; }
            public List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndexUpdate> GlobalSecondaryIndexUpdates { get; set; }
            public System.Int64? ReadCapacity { get; set; }
            public System.Int64? WriteCapacity { get; set; }
            public System.Boolean? StreamSpecification_StreamEnabled { get; set; }
            public Amazon.DynamoDBv2.StreamViewType StreamSpecification_StreamViewType { get; set; }
            public System.String TableName { get; set; }
        }
        
    }
}
