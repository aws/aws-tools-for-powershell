/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates auto scaling settings on your global tables at once.
    /// 
    ///  <important><para>
    /// For global tables, this operation only applies to global tables using Version 2019.11.21
    /// (Current version). 
    /// </para></important>
    /// </summary>
    [Cmdlet("Update", "DDBTableReplicaAutoScaling", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TableAutoScalingDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateTableReplicaAutoScaling API operation.", Operation = new[] {"UpdateTableReplicaAutoScaling"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableAutoScalingDescription or Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.TableAutoScalingDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateDDBTableReplicaAutoScalingCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GlobalSecondaryIndexUpdate
        /// <summary>
        /// <para>
        /// <para>Represents the auto scaling settings of the global secondary indexes of the replica
        /// to be updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GlobalSecondaryIndexUpdates")]
        public Amazon.DynamoDBv2.Model.GlobalSecondaryIndexAutoScalingUpdate[] GlobalSecondaryIndexUpdate { get; set; }
        #endregion
        
        #region Parameter ProvisionedWriteCapacityAutoScalingUpdate
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DynamoDBv2.Model.AutoScalingSettingsUpdate ProvisionedWriteCapacityAutoScalingUpdate { get; set; }
        #endregion
        
        #region Parameter ReplicaUpdate
        /// <summary>
        /// <para>
        /// <para>Represents the auto scaling settings of replicas of the table that will be modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicaUpdates")]
        public Amazon.DynamoDBv2.Model.ReplicaAutoScalingUpdate[] ReplicaUpdate { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the global table to be updated. You can also provide the Amazon Resource
        /// Name (ARN) of the table in this parameter.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TableAutoScalingDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TableAutoScalingDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TableName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TableName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TableName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBTableReplicaAutoScaling (UpdateTableReplicaAutoScaling)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingResponse, UpdateDDBTableReplicaAutoScalingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TableName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.GlobalSecondaryIndexUpdate != null)
            {
                context.GlobalSecondaryIndexUpdate = new List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndexAutoScalingUpdate>(this.GlobalSecondaryIndexUpdate);
            }
            context.ProvisionedWriteCapacityAutoScalingUpdate = this.ProvisionedWriteCapacityAutoScalingUpdate;
            if (this.ReplicaUpdate != null)
            {
                context.ReplicaUpdate = new List<Amazon.DynamoDBv2.Model.ReplicaAutoScalingUpdate>(this.ReplicaUpdate);
            }
            context.TableName = this.TableName;
            #if MODULAR
            if (this.TableName == null && ParameterWasBound(nameof(this.TableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingRequest();
            
            if (cmdletContext.GlobalSecondaryIndexUpdate != null)
            {
                request.GlobalSecondaryIndexUpdates = cmdletContext.GlobalSecondaryIndexUpdate;
            }
            if (cmdletContext.ProvisionedWriteCapacityAutoScalingUpdate != null)
            {
                request.ProvisionedWriteCapacityAutoScalingUpdate = cmdletContext.ProvisionedWriteCapacityAutoScalingUpdate;
            }
            if (cmdletContext.ReplicaUpdate != null)
            {
                request.ReplicaUpdates = cmdletContext.ReplicaUpdate;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        #region AWS Service Operation Call
        
        private Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateTableReplicaAutoScaling");
            try
            {
                #if DESKTOP
                return client.UpdateTableReplicaAutoScaling(request);
                #elif CORECLR
                return client.UpdateTableReplicaAutoScalingAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<Amazon.DynamoDBv2.Model.GlobalSecondaryIndexAutoScalingUpdate> GlobalSecondaryIndexUpdate { get; set; }
            public Amazon.DynamoDBv2.Model.AutoScalingSettingsUpdate ProvisionedWriteCapacityAutoScalingUpdate { get; set; }
            public List<Amazon.DynamoDBv2.Model.ReplicaAutoScalingUpdate> ReplicaUpdate { get; set; }
            public System.String TableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.UpdateTableReplicaAutoScalingResponse, UpdateDDBTableReplicaAutoScalingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TableAutoScalingDescription;
        }
        
    }
}
