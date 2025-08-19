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
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using System.Threading;
using Amazon.ConnectCampaignService;
using Amazon.ConnectCampaignService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CCS
{
    /// <summary>
    /// Updates the dialer config of a campaign. This API is idempotent.
    /// </summary>
    [Cmdlet("Update", "CCSCampaignDialerConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Campaign Service UpdateCampaignDialerConfig API operation.", Operation = new[] {"UpdateCampaignDialerConfig"}, SelectReturnType = typeof(Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigResponse))]
    [AWSCmdletOutput("None or Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCCSCampaignDialerConfigCmdlet : AmazonConnectCampaignServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PredictiveDialerConfig_BandwidthAllocation
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DialerConfig_PredictiveDialerConfig_BandwidthAllocation")]
        public System.Double? PredictiveDialerConfig_BandwidthAllocation { get; set; }
        #endregion
        
        #region Parameter ProgressiveDialerConfig_BandwidthAllocation
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DialerConfig_ProgressiveDialerConfig_BandwidthAllocation")]
        public System.Double? ProgressiveDialerConfig_BandwidthAllocation { get; set; }
        #endregion
        
        #region Parameter AgentlessDialerConfig_DialingCapacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DialerConfig_AgentlessDialerConfig_DialingCapacity")]
        public System.Double? AgentlessDialerConfig_DialingCapacity { get; set; }
        #endregion
        
        #region Parameter PredictiveDialerConfig_DialingCapacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DialerConfig_PredictiveDialerConfig_DialingCapacity")]
        public System.Double? PredictiveDialerConfig_DialingCapacity { get; set; }
        #endregion
        
        #region Parameter ProgressiveDialerConfig_DialingCapacity
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DialerConfig_ProgressiveDialerConfig_DialingCapacity")]
        public System.Double? ProgressiveDialerConfig_DialingCapacity { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CCSCampaignDialerConfig (UpdateCampaignDialerConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigResponse, UpdateCCSCampaignDialerConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentlessDialerConfig_DialingCapacity = this.AgentlessDialerConfig_DialingCapacity;
            context.PredictiveDialerConfig_BandwidthAllocation = this.PredictiveDialerConfig_BandwidthAllocation;
            context.PredictiveDialerConfig_DialingCapacity = this.PredictiveDialerConfig_DialingCapacity;
            context.ProgressiveDialerConfig_BandwidthAllocation = this.ProgressiveDialerConfig_BandwidthAllocation;
            context.ProgressiveDialerConfig_DialingCapacity = this.ProgressiveDialerConfig_DialingCapacity;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigRequest();
            
            
             // populate DialerConfig
            request.DialerConfig = new Amazon.ConnectCampaignService.Model.DialerConfig();
            Amazon.ConnectCampaignService.Model.AgentlessDialerConfig requestDialerConfig_dialerConfig_AgentlessDialerConfig = null;
            
             // populate AgentlessDialerConfig
            var requestDialerConfig_dialerConfig_AgentlessDialerConfigIsNull = true;
            requestDialerConfig_dialerConfig_AgentlessDialerConfig = new Amazon.ConnectCampaignService.Model.AgentlessDialerConfig();
            System.Double? requestDialerConfig_dialerConfig_AgentlessDialerConfig_agentlessDialerConfig_DialingCapacity = null;
            if (cmdletContext.AgentlessDialerConfig_DialingCapacity != null)
            {
                requestDialerConfig_dialerConfig_AgentlessDialerConfig_agentlessDialerConfig_DialingCapacity = cmdletContext.AgentlessDialerConfig_DialingCapacity.Value;
            }
            if (requestDialerConfig_dialerConfig_AgentlessDialerConfig_agentlessDialerConfig_DialingCapacity != null)
            {
                requestDialerConfig_dialerConfig_AgentlessDialerConfig.DialingCapacity = requestDialerConfig_dialerConfig_AgentlessDialerConfig_agentlessDialerConfig_DialingCapacity.Value;
                requestDialerConfig_dialerConfig_AgentlessDialerConfigIsNull = false;
            }
             // determine if requestDialerConfig_dialerConfig_AgentlessDialerConfig should be set to null
            if (requestDialerConfig_dialerConfig_AgentlessDialerConfigIsNull)
            {
                requestDialerConfig_dialerConfig_AgentlessDialerConfig = null;
            }
            if (requestDialerConfig_dialerConfig_AgentlessDialerConfig != null)
            {
                request.DialerConfig.AgentlessDialerConfig = requestDialerConfig_dialerConfig_AgentlessDialerConfig;
            }
            Amazon.ConnectCampaignService.Model.PredictiveDialerConfig requestDialerConfig_dialerConfig_PredictiveDialerConfig = null;
            
             // populate PredictiveDialerConfig
            var requestDialerConfig_dialerConfig_PredictiveDialerConfigIsNull = true;
            requestDialerConfig_dialerConfig_PredictiveDialerConfig = new Amazon.ConnectCampaignService.Model.PredictiveDialerConfig();
            System.Double? requestDialerConfig_dialerConfig_PredictiveDialerConfig_predictiveDialerConfig_BandwidthAllocation = null;
            if (cmdletContext.PredictiveDialerConfig_BandwidthAllocation != null)
            {
                requestDialerConfig_dialerConfig_PredictiveDialerConfig_predictiveDialerConfig_BandwidthAllocation = cmdletContext.PredictiveDialerConfig_BandwidthAllocation.Value;
            }
            if (requestDialerConfig_dialerConfig_PredictiveDialerConfig_predictiveDialerConfig_BandwidthAllocation != null)
            {
                requestDialerConfig_dialerConfig_PredictiveDialerConfig.BandwidthAllocation = requestDialerConfig_dialerConfig_PredictiveDialerConfig_predictiveDialerConfig_BandwidthAllocation.Value;
                requestDialerConfig_dialerConfig_PredictiveDialerConfigIsNull = false;
            }
            System.Double? requestDialerConfig_dialerConfig_PredictiveDialerConfig_predictiveDialerConfig_DialingCapacity = null;
            if (cmdletContext.PredictiveDialerConfig_DialingCapacity != null)
            {
                requestDialerConfig_dialerConfig_PredictiveDialerConfig_predictiveDialerConfig_DialingCapacity = cmdletContext.PredictiveDialerConfig_DialingCapacity.Value;
            }
            if (requestDialerConfig_dialerConfig_PredictiveDialerConfig_predictiveDialerConfig_DialingCapacity != null)
            {
                requestDialerConfig_dialerConfig_PredictiveDialerConfig.DialingCapacity = requestDialerConfig_dialerConfig_PredictiveDialerConfig_predictiveDialerConfig_DialingCapacity.Value;
                requestDialerConfig_dialerConfig_PredictiveDialerConfigIsNull = false;
            }
             // determine if requestDialerConfig_dialerConfig_PredictiveDialerConfig should be set to null
            if (requestDialerConfig_dialerConfig_PredictiveDialerConfigIsNull)
            {
                requestDialerConfig_dialerConfig_PredictiveDialerConfig = null;
            }
            if (requestDialerConfig_dialerConfig_PredictiveDialerConfig != null)
            {
                request.DialerConfig.PredictiveDialerConfig = requestDialerConfig_dialerConfig_PredictiveDialerConfig;
            }
            Amazon.ConnectCampaignService.Model.ProgressiveDialerConfig requestDialerConfig_dialerConfig_ProgressiveDialerConfig = null;
            
             // populate ProgressiveDialerConfig
            var requestDialerConfig_dialerConfig_ProgressiveDialerConfigIsNull = true;
            requestDialerConfig_dialerConfig_ProgressiveDialerConfig = new Amazon.ConnectCampaignService.Model.ProgressiveDialerConfig();
            System.Double? requestDialerConfig_dialerConfig_ProgressiveDialerConfig_progressiveDialerConfig_BandwidthAllocation = null;
            if (cmdletContext.ProgressiveDialerConfig_BandwidthAllocation != null)
            {
                requestDialerConfig_dialerConfig_ProgressiveDialerConfig_progressiveDialerConfig_BandwidthAllocation = cmdletContext.ProgressiveDialerConfig_BandwidthAllocation.Value;
            }
            if (requestDialerConfig_dialerConfig_ProgressiveDialerConfig_progressiveDialerConfig_BandwidthAllocation != null)
            {
                requestDialerConfig_dialerConfig_ProgressiveDialerConfig.BandwidthAllocation = requestDialerConfig_dialerConfig_ProgressiveDialerConfig_progressiveDialerConfig_BandwidthAllocation.Value;
                requestDialerConfig_dialerConfig_ProgressiveDialerConfigIsNull = false;
            }
            System.Double? requestDialerConfig_dialerConfig_ProgressiveDialerConfig_progressiveDialerConfig_DialingCapacity = null;
            if (cmdletContext.ProgressiveDialerConfig_DialingCapacity != null)
            {
                requestDialerConfig_dialerConfig_ProgressiveDialerConfig_progressiveDialerConfig_DialingCapacity = cmdletContext.ProgressiveDialerConfig_DialingCapacity.Value;
            }
            if (requestDialerConfig_dialerConfig_ProgressiveDialerConfig_progressiveDialerConfig_DialingCapacity != null)
            {
                requestDialerConfig_dialerConfig_ProgressiveDialerConfig.DialingCapacity = requestDialerConfig_dialerConfig_ProgressiveDialerConfig_progressiveDialerConfig_DialingCapacity.Value;
                requestDialerConfig_dialerConfig_ProgressiveDialerConfigIsNull = false;
            }
             // determine if requestDialerConfig_dialerConfig_ProgressiveDialerConfig should be set to null
            if (requestDialerConfig_dialerConfig_ProgressiveDialerConfigIsNull)
            {
                requestDialerConfig_dialerConfig_ProgressiveDialerConfig = null;
            }
            if (requestDialerConfig_dialerConfig_ProgressiveDialerConfig != null)
            {
                request.DialerConfig.ProgressiveDialerConfig = requestDialerConfig_dialerConfig_ProgressiveDialerConfig;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
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
        
        private Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigResponse CallAWSServiceOperation(IAmazonConnectCampaignService client, Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Campaign Service", "UpdateCampaignDialerConfig");
            try
            {
                return client.UpdateCampaignDialerConfigAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Double? AgentlessDialerConfig_DialingCapacity { get; set; }
            public System.Double? PredictiveDialerConfig_BandwidthAllocation { get; set; }
            public System.Double? PredictiveDialerConfig_DialingCapacity { get; set; }
            public System.Double? ProgressiveDialerConfig_BandwidthAllocation { get; set; }
            public System.Double? ProgressiveDialerConfig_DialingCapacity { get; set; }
            public System.String Id { get; set; }
            public System.Func<Amazon.ConnectCampaignService.Model.UpdateCampaignDialerConfigResponse, UpdateCCSCampaignDialerConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
