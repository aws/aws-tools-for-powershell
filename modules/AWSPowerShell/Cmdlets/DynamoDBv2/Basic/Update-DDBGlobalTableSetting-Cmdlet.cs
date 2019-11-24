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
    /// Updates settings for a global table.
    /// </summary>
    [Cmdlet("Update", "DDBGlobalTableSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB UpdateGlobalTableSettings API operation.", Operation = new[] {"UpdateGlobalTableSettings"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateDDBGlobalTableSettingCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter GlobalTableBillingMode
        /// <summary>
        /// <para>
        /// <para>The billing mode of the global table. If <code>GlobalTableBillingMode</code> is not
        /// specified, the global table defaults to <code>PROVISIONED</code> capacity billing
        /// mode.</para><ul><li><para><code>PROVISIONED</code> - We recommend using <code>PROVISIONED</code> for predictable
        /// workloads. <code>PROVISIONED</code> sets the billing mode to <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadWriteCapacityMode.html#HowItWorks.ProvisionedThroughput.Manual">Provisioned
        /// Mode</a>.</para></li><li><para><code>PAY_PER_REQUEST</code> - We recommend using <code>PAY_PER_REQUEST</code> for
        /// unpredictable workloads. <code>PAY_PER_REQUEST</code> sets the billing mode to <a href="https://docs.aws.amazon.com/amazondynamodb/latest/developerguide/HowItWorks.ReadWriteCapacityMode.html#HowItWorks.OnDemand">On-Demand
        /// Mode</a>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BillingMode")]
        public Amazon.DynamoDBv2.BillingMode GlobalTableBillingMode { get; set; }
        #endregion
        
        #region Parameter GlobalTableGlobalSecondaryIndexSettingsUpdate
        /// <summary>
        /// <para>
        /// <para>Represents the settings of a global secondary index for a global table that will be
        /// modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DynamoDBv2.Model.GlobalTableGlobalSecondaryIndexSettingsUpdate[] GlobalTableGlobalSecondaryIndexSettingsUpdate { get; set; }
        #endregion
        
        #region Parameter GlobalTableName
        /// <summary>
        /// <para>
        /// <para>The name of the global table</para>
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
        public System.String GlobalTableName { get; set; }
        #endregion
        
        #region Parameter GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate
        /// <summary>
        /// <para>
        /// <para>Auto scaling settings for managing provisioned write capacity for the global table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DynamoDBv2.Model.AutoScalingSettingsUpdate GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate { get; set; }
        #endregion
        
        #region Parameter GlobalTableProvisionedWriteCapacityUnit
        /// <summary>
        /// <para>
        /// <para>The maximum number of writes consumed per second before DynamoDB returns a <code>ThrottlingException.</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GlobalTableProvisionedWriteCapacityUnits")]
        public System.Int64? GlobalTableProvisionedWriteCapacityUnit { get; set; }
        #endregion
        
        #region Parameter ReplicaSettingsUpdate
        /// <summary>
        /// <para>
        /// <para>Represents the settings for a global table in a Region that will be modified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DynamoDBv2.Model.ReplicaSettingsUpdate[] ReplicaSettingsUpdate { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GlobalTableName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GlobalTableName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GlobalTableName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalTableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DDBGlobalTableSetting (UpdateGlobalTableSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse, UpdateDDBGlobalTableSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GlobalTableName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GlobalTableBillingMode = this.GlobalTableBillingMode;
            if (this.GlobalTableGlobalSecondaryIndexSettingsUpdate != null)
            {
                context.GlobalTableGlobalSecondaryIndexSettingsUpdate = new List<Amazon.DynamoDBv2.Model.GlobalTableGlobalSecondaryIndexSettingsUpdate>(this.GlobalTableGlobalSecondaryIndexSettingsUpdate);
            }
            context.GlobalTableName = this.GlobalTableName;
            #if MODULAR
            if (this.GlobalTableName == null && ParameterWasBound(nameof(this.GlobalTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate = this.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate;
            context.GlobalTableProvisionedWriteCapacityUnit = this.GlobalTableProvisionedWriteCapacityUnit;
            if (this.ReplicaSettingsUpdate != null)
            {
                context.ReplicaSettingsUpdate = new List<Amazon.DynamoDBv2.Model.ReplicaSettingsUpdate>(this.ReplicaSettingsUpdate);
            }
            
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
            var request = new Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsRequest();
            
            if (cmdletContext.GlobalTableBillingMode != null)
            {
                request.GlobalTableBillingMode = cmdletContext.GlobalTableBillingMode;
            }
            if (cmdletContext.GlobalTableGlobalSecondaryIndexSettingsUpdate != null)
            {
                request.GlobalTableGlobalSecondaryIndexSettingsUpdate = cmdletContext.GlobalTableGlobalSecondaryIndexSettingsUpdate;
            }
            if (cmdletContext.GlobalTableName != null)
            {
                request.GlobalTableName = cmdletContext.GlobalTableName;
            }
            if (cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate != null)
            {
                request.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate = cmdletContext.GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate;
            }
            if (cmdletContext.GlobalTableProvisionedWriteCapacityUnit != null)
            {
                request.GlobalTableProvisionedWriteCapacityUnits = cmdletContext.GlobalTableProvisionedWriteCapacityUnit.Value;
            }
            if (cmdletContext.ReplicaSettingsUpdate != null)
            {
                request.ReplicaSettingsUpdate = cmdletContext.ReplicaSettingsUpdate;
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
        
        private Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "UpdateGlobalTableSettings");
            try
            {
                #if DESKTOP
                return client.UpdateGlobalTableSettings(request);
                #elif CORECLR
                return client.UpdateGlobalTableSettingsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DynamoDBv2.BillingMode GlobalTableBillingMode { get; set; }
            public List<Amazon.DynamoDBv2.Model.GlobalTableGlobalSecondaryIndexSettingsUpdate> GlobalTableGlobalSecondaryIndexSettingsUpdate { get; set; }
            public System.String GlobalTableName { get; set; }
            public Amazon.DynamoDBv2.Model.AutoScalingSettingsUpdate GlobalTableProvisionedWriteCapacityAutoScalingSettingsUpdate { get; set; }
            public System.Int64? GlobalTableProvisionedWriteCapacityUnit { get; set; }
            public List<Amazon.DynamoDBv2.Model.ReplicaSettingsUpdate> ReplicaSettingsUpdate { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.UpdateGlobalTableSettingsResponse, UpdateDDBGlobalTableSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
