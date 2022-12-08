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
using Amazon.KafkaConnect;
using Amazon.KafkaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.MSKC
{
    /// <summary>
    /// Updates the specified connector.
    /// </summary>
    [Cmdlet("Update", "MSKCConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.KafkaConnect.Model.UpdateConnectorResponse")]
    [AWSCmdlet("Calls the Managed Streaming for Kafka Connect UpdateConnector API operation.", Operation = new[] {"UpdateConnector"}, SelectReturnType = typeof(Amazon.KafkaConnect.Model.UpdateConnectorResponse))]
    [AWSCmdletOutput("Amazon.KafkaConnect.Model.UpdateConnectorResponse",
        "This cmdlet returns an Amazon.KafkaConnect.Model.UpdateConnectorResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMSKCConnectorCmdlet : AmazonKafkaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter ConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the connector that you want to update.</para>
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
        public System.String ConnectorArn { get; set; }
        #endregion
        
        #region Parameter ScaleInPolicy_CpuUtilizationPercentage
        /// <summary>
        /// <para>
        /// <para>The target CPU utilization percentage threshold at which you want connector scale
        /// in to be triggered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_ScaleInPolicy_CpuUtilizationPercentage")]
        public System.Int32? ScaleInPolicy_CpuUtilizationPercentage { get; set; }
        #endregion
        
        #region Parameter ScaleOutPolicy_CpuUtilizationPercentage
        /// <summary>
        /// <para>
        /// <para>The target CPU utilization percentage threshold at which you want connector scale
        /// out to be triggered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_ScaleOutPolicy_CpuUtilizationPercentage")]
        public System.Int32? ScaleOutPolicy_CpuUtilizationPercentage { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>The current version of the connector that you want to update.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String CurrentVersion { get; set; }
        #endregion
        
        #region Parameter AutoScaling_MaxWorkerCount
        /// <summary>
        /// <para>
        /// <para>The target maximum number of workers allocated to the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_MaxWorkerCount")]
        public System.Int32? AutoScaling_MaxWorkerCount { get; set; }
        #endregion
        
        #region Parameter AutoScaling_McuCount
        /// <summary>
        /// <para>
        /// <para>The target number of microcontroller units (MCUs) allocated to each connector worker.
        /// The valid values are 1,2,4,8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_McuCount")]
        public System.Int32? AutoScaling_McuCount { get; set; }
        #endregion
        
        #region Parameter ProvisionedCapacity_McuCount
        /// <summary>
        /// <para>
        /// <para>The number of microcontroller units (MCUs) allocated to each connector worker. The
        /// valid values are 1,2,4,8.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_ProvisionedCapacity_McuCount")]
        public System.Int32? ProvisionedCapacity_McuCount { get; set; }
        #endregion
        
        #region Parameter AutoScaling_MinWorkerCount
        /// <summary>
        /// <para>
        /// <para>The target minimum number of workers allocated to the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_AutoScaling_MinWorkerCount")]
        public System.Int32? AutoScaling_MinWorkerCount { get; set; }
        #endregion
        
        #region Parameter ProvisionedCapacity_WorkerCount
        /// <summary>
        /// <para>
        /// <para>The number of workers that are allocated to the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_ProvisionedCapacity_WorkerCount")]
        public System.Int32? ProvisionedCapacity_WorkerCount { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KafkaConnect.Model.UpdateConnectorResponse).
        /// Specifying the name of a property of type Amazon.KafkaConnect.Model.UpdateConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectorArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectorArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectorArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MSKCConnector (UpdateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KafkaConnect.Model.UpdateConnectorResponse, UpdateMSKCConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectorArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutoScaling_MaxWorkerCount = this.AutoScaling_MaxWorkerCount;
            context.AutoScaling_McuCount = this.AutoScaling_McuCount;
            context.AutoScaling_MinWorkerCount = this.AutoScaling_MinWorkerCount;
            context.ScaleInPolicy_CpuUtilizationPercentage = this.ScaleInPolicy_CpuUtilizationPercentage;
            context.ScaleOutPolicy_CpuUtilizationPercentage = this.ScaleOutPolicy_CpuUtilizationPercentage;
            context.ProvisionedCapacity_McuCount = this.ProvisionedCapacity_McuCount;
            context.ProvisionedCapacity_WorkerCount = this.ProvisionedCapacity_WorkerCount;
            context.ConnectorArn = this.ConnectorArn;
            #if MODULAR
            if (this.ConnectorArn == null && ParameterWasBound(nameof(this.ConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KafkaConnect.Model.UpdateConnectorRequest();
            
            
             // populate Capacity
            var requestCapacityIsNull = true;
            request.Capacity = new Amazon.KafkaConnect.Model.CapacityUpdate();
            Amazon.KafkaConnect.Model.ProvisionedCapacityUpdate requestCapacity_capacity_ProvisionedCapacity = null;
            
             // populate ProvisionedCapacity
            var requestCapacity_capacity_ProvisionedCapacityIsNull = true;
            requestCapacity_capacity_ProvisionedCapacity = new Amazon.KafkaConnect.Model.ProvisionedCapacityUpdate();
            System.Int32? requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_McuCount = null;
            if (cmdletContext.ProvisionedCapacity_McuCount != null)
            {
                requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_McuCount = cmdletContext.ProvisionedCapacity_McuCount.Value;
            }
            if (requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_McuCount != null)
            {
                requestCapacity_capacity_ProvisionedCapacity.McuCount = requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_McuCount.Value;
                requestCapacity_capacity_ProvisionedCapacityIsNull = false;
            }
            System.Int32? requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_WorkerCount = null;
            if (cmdletContext.ProvisionedCapacity_WorkerCount != null)
            {
                requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_WorkerCount = cmdletContext.ProvisionedCapacity_WorkerCount.Value;
            }
            if (requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_WorkerCount != null)
            {
                requestCapacity_capacity_ProvisionedCapacity.WorkerCount = requestCapacity_capacity_ProvisionedCapacity_provisionedCapacity_WorkerCount.Value;
                requestCapacity_capacity_ProvisionedCapacityIsNull = false;
            }
             // determine if requestCapacity_capacity_ProvisionedCapacity should be set to null
            if (requestCapacity_capacity_ProvisionedCapacityIsNull)
            {
                requestCapacity_capacity_ProvisionedCapacity = null;
            }
            if (requestCapacity_capacity_ProvisionedCapacity != null)
            {
                request.Capacity.ProvisionedCapacity = requestCapacity_capacity_ProvisionedCapacity;
                requestCapacityIsNull = false;
            }
            Amazon.KafkaConnect.Model.AutoScalingUpdate requestCapacity_capacity_AutoScaling = null;
            
             // populate AutoScaling
            var requestCapacity_capacity_AutoScalingIsNull = true;
            requestCapacity_capacity_AutoScaling = new Amazon.KafkaConnect.Model.AutoScalingUpdate();
            System.Int32? requestCapacity_capacity_AutoScaling_autoScaling_MaxWorkerCount = null;
            if (cmdletContext.AutoScaling_MaxWorkerCount != null)
            {
                requestCapacity_capacity_AutoScaling_autoScaling_MaxWorkerCount = cmdletContext.AutoScaling_MaxWorkerCount.Value;
            }
            if (requestCapacity_capacity_AutoScaling_autoScaling_MaxWorkerCount != null)
            {
                requestCapacity_capacity_AutoScaling.MaxWorkerCount = requestCapacity_capacity_AutoScaling_autoScaling_MaxWorkerCount.Value;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
            System.Int32? requestCapacity_capacity_AutoScaling_autoScaling_McuCount = null;
            if (cmdletContext.AutoScaling_McuCount != null)
            {
                requestCapacity_capacity_AutoScaling_autoScaling_McuCount = cmdletContext.AutoScaling_McuCount.Value;
            }
            if (requestCapacity_capacity_AutoScaling_autoScaling_McuCount != null)
            {
                requestCapacity_capacity_AutoScaling.McuCount = requestCapacity_capacity_AutoScaling_autoScaling_McuCount.Value;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
            System.Int32? requestCapacity_capacity_AutoScaling_autoScaling_MinWorkerCount = null;
            if (cmdletContext.AutoScaling_MinWorkerCount != null)
            {
                requestCapacity_capacity_AutoScaling_autoScaling_MinWorkerCount = cmdletContext.AutoScaling_MinWorkerCount.Value;
            }
            if (requestCapacity_capacity_AutoScaling_autoScaling_MinWorkerCount != null)
            {
                requestCapacity_capacity_AutoScaling.MinWorkerCount = requestCapacity_capacity_AutoScaling_autoScaling_MinWorkerCount.Value;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
            Amazon.KafkaConnect.Model.ScaleInPolicyUpdate requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy = null;
            
             // populate ScaleInPolicy
            var requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicyIsNull = true;
            requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy = new Amazon.KafkaConnect.Model.ScaleInPolicyUpdate();
            System.Int32? requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy_scaleInPolicy_CpuUtilizationPercentage = null;
            if (cmdletContext.ScaleInPolicy_CpuUtilizationPercentage != null)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy_scaleInPolicy_CpuUtilizationPercentage = cmdletContext.ScaleInPolicy_CpuUtilizationPercentage.Value;
            }
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy_scaleInPolicy_CpuUtilizationPercentage != null)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy.CpuUtilizationPercentage = requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy_scaleInPolicy_CpuUtilizationPercentage.Value;
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicyIsNull = false;
            }
             // determine if requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy should be set to null
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicyIsNull)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy = null;
            }
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy != null)
            {
                requestCapacity_capacity_AutoScaling.ScaleInPolicy = requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleInPolicy;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
            Amazon.KafkaConnect.Model.ScaleOutPolicyUpdate requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy = null;
            
             // populate ScaleOutPolicy
            var requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicyIsNull = true;
            requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy = new Amazon.KafkaConnect.Model.ScaleOutPolicyUpdate();
            System.Int32? requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy_scaleOutPolicy_CpuUtilizationPercentage = null;
            if (cmdletContext.ScaleOutPolicy_CpuUtilizationPercentage != null)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy_scaleOutPolicy_CpuUtilizationPercentage = cmdletContext.ScaleOutPolicy_CpuUtilizationPercentage.Value;
            }
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy_scaleOutPolicy_CpuUtilizationPercentage != null)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy.CpuUtilizationPercentage = requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy_scaleOutPolicy_CpuUtilizationPercentage.Value;
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicyIsNull = false;
            }
             // determine if requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy should be set to null
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicyIsNull)
            {
                requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy = null;
            }
            if (requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy != null)
            {
                requestCapacity_capacity_AutoScaling.ScaleOutPolicy = requestCapacity_capacity_AutoScaling_capacity_AutoScaling_ScaleOutPolicy;
                requestCapacity_capacity_AutoScalingIsNull = false;
            }
             // determine if requestCapacity_capacity_AutoScaling should be set to null
            if (requestCapacity_capacity_AutoScalingIsNull)
            {
                requestCapacity_capacity_AutoScaling = null;
            }
            if (requestCapacity_capacity_AutoScaling != null)
            {
                request.Capacity.AutoScaling = requestCapacity_capacity_AutoScaling;
                requestCapacityIsNull = false;
            }
             // determine if request.Capacity should be set to null
            if (requestCapacityIsNull)
            {
                request.Capacity = null;
            }
            if (cmdletContext.ConnectorArn != null)
            {
                request.ConnectorArn = cmdletContext.ConnectorArn;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
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
        
        private Amazon.KafkaConnect.Model.UpdateConnectorResponse CallAWSServiceOperation(IAmazonKafkaConnect client, Amazon.KafkaConnect.Model.UpdateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed Streaming for Kafka Connect", "UpdateConnector");
            try
            {
                #if DESKTOP
                return client.UpdateConnector(request);
                #elif CORECLR
                return client.UpdateConnectorAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? AutoScaling_MaxWorkerCount { get; set; }
            public System.Int32? AutoScaling_McuCount { get; set; }
            public System.Int32? AutoScaling_MinWorkerCount { get; set; }
            public System.Int32? ScaleInPolicy_CpuUtilizationPercentage { get; set; }
            public System.Int32? ScaleOutPolicy_CpuUtilizationPercentage { get; set; }
            public System.Int32? ProvisionedCapacity_McuCount { get; set; }
            public System.Int32? ProvisionedCapacity_WorkerCount { get; set; }
            public System.String ConnectorArn { get; set; }
            public System.String CurrentVersion { get; set; }
            public System.Func<Amazon.KafkaConnect.Model.UpdateConnectorResponse, UpdateMSKCConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
