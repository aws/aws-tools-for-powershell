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
    /// Updates the provisioned throughput for the given table, or manages the global secondary
    /// indexes on the table.
    /// 
    ///  
    /// <para>
    /// You can increase or decrease the table's provisioned throughput values within the
    /// maximums and minimums listed in the <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/Limits.html">Limits</a>
    /// section in the <i>Amazon DynamoDB Developer Guide</i>.
    /// </para><para>
    /// In addition, you can use <i>UpdateTable</i> to add, modify or delete global secondary
    /// indexes on the table. For more information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/GSI.OnlineOps.html">Managing
    /// Global Secondary Indexes</a> in the <i>Amazon DynamoDB Developer Guide</i>. 
    /// </para><para>
    /// The table must be in the <code>ACTIVE</code> state for <i>UpdateTable</i> to succeed.
    /// <i>UpdateTable</i> is an asynchronous operation; while executing the operation, the
    /// table is in the <code>UPDATING</code> state. While the table is in the <code>UPDATING</code>
    /// state, the table still has the provisioned throughput from before the call. The table's
    /// new provisioned throughput settings go into effect when the table returns to the <code>ACTIVE</code>
    /// state; at that point, the <i>UpdateTable</i> operation is complete. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DDBTable", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TableDescription")]
    [AWSCmdlet("Invokes the UpdateTable operation against Amazon DynamoDB.", Operation = new[] {"UpdateTable"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableDescription",
        "This cmdlet returns a TableDescription object.",
        "The service call response (type UpdateTableResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateDDBTableCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
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
        
        /// <summary>
        /// <para>
        /// <para>An array of one or more global secondary indexes for the table. For each index in
        /// the array, you can request one action:</para><ul><li><para><i>Create</i> - add a new global secondary index to the table.</para></li><li><para><i>Update</i> - modify the provisioned throughput settings of an existing global secondary
        /// index.</para></li><li><para><i>Delete</i> - remove a global secondary index from the table.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalSecondaryIndexUpdates")]
        public Amazon.DynamoDBv2.Model.GlobalSecondaryIndexUpdate[] GlobalSecondaryIndexUpdate { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of strongly consistent reads consumed per second before DynamoDB
        /// returns a <i>ThrottlingException</i>. For more information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithTables.html#ProvisionedThroughput">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProvisionedThroughput_ReadCapacityUnits")]
        public Int64 ReadCapacity { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the table to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String TableName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of writes consumed per second before DynamoDB returns a <i>ThrottlingException</i>.
        /// For more information, see <a href="http://docs.aws.amazon.com/amazondynamodb/latest/developerguide/WorkingWithTables.html#ProvisionedThroughput">Specifying
        /// Read and Write Requirements</a> in the <i>Amazon DynamoDB Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ProvisionedThroughput_WriteCapacityUnits")]
        public Int64 WriteCapacity { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
                context.AttributeDefinitions = new List<AttributeDefinition>(this.AttributeDefinition);
            }
            if (this.GlobalSecondaryIndexUpdate != null)
            {
                context.GlobalSecondaryIndexUpdates = new List<GlobalSecondaryIndexUpdate>(this.GlobalSecondaryIndexUpdate);
            }
            if (ParameterWasBound("ReadCapacity"))
                context.ReadCapacity = this.ReadCapacity;
            if (ParameterWasBound("WriteCapacity"))
                context.WriteCapacity = this.WriteCapacity;
            context.TableName = this.TableName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new UpdateTableRequest();
            
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
            request.ProvisionedThroughput = new ProvisionedThroughput();
            Int64? requestProvisionedThroughput_readCapacity = null;
            if (cmdletContext.ReadCapacity != null)
            {
                requestProvisionedThroughput_readCapacity = cmdletContext.ReadCapacity.Value;
            }
            if (requestProvisionedThroughput_readCapacity != null)
            {
                request.ProvisionedThroughput.ReadCapacityUnits = requestProvisionedThroughput_readCapacity.Value;
                requestProvisionedThroughputIsNull = false;
            }
            Int64? requestProvisionedThroughput_writeCapacity = null;
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
            public List<AttributeDefinition> AttributeDefinitions { get; set; }
            public List<GlobalSecondaryIndexUpdate> GlobalSecondaryIndexUpdates { get; set; }
            public Int64? ReadCapacity { get; set; }
            public Int64? WriteCapacity { get; set; }
            public String TableName { get; set; }
        }
        
    }
}
