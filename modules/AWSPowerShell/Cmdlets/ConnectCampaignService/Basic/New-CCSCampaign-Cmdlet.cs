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
using Amazon.ConnectCampaignService;
using Amazon.ConnectCampaignService.Model;

namespace Amazon.PowerShell.Cmdlets.CCS
{
    /// <summary>
    /// Creates a campaign for the specified Amazon Connect account. This API is idempotent.
    /// </summary>
    [Cmdlet("New", "CCSCampaign", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectCampaignService.Model.CreateCampaignResponse")]
    [AWSCmdlet("Calls the Amazon Connect Campaign Service CreateCampaign API operation.", Operation = new[] {"CreateCampaign"}, SelectReturnType = typeof(Amazon.ConnectCampaignService.Model.CreateCampaignResponse))]
    [AWSCmdletOutput("Amazon.ConnectCampaignService.Model.CreateCampaignResponse",
        "This cmdlet returns an Amazon.ConnectCampaignService.Model.CreateCampaignResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCCSCampaignCmdlet : AmazonConnectCampaignServiceClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter OutboundCallConfig_ConnectContactFlowId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String OutboundCallConfig_ConnectContactFlowId { get; set; }
        #endregion
        
        #region Parameter ConnectInstanceId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String ConnectInstanceId { get; set; }
        #endregion
        
        #region Parameter OutboundCallConfig_ConnectQueueId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutboundCallConfig_ConnectQueueId { get; set; }
        #endregion
        
        #region Parameter OutboundCallConfig_ConnectSourcePhoneNumber
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutboundCallConfig_ConnectSourcePhoneNumber { get; set; }
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
        
        #region Parameter AnswerMachineDetectionConfig_EnableAnswerMachineDetection
        /// <summary>
        /// <para>
        /// <para>Enable or disable answering machine detection</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OutboundCallConfig_AnswerMachineDetectionConfig_EnableAnswerMachineDetection")]
        public System.Boolean? AnswerMachineDetectionConfig_EnableAnswerMachineDetection { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectCampaignService.Model.CreateCampaignResponse).
        /// Specifying the name of a property of type Amazon.ConnectCampaignService.Model.CreateCampaignResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CCSCampaign (CreateCampaign)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectCampaignService.Model.CreateCampaignResponse, NewCCSCampaignCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectInstanceId = this.ConnectInstanceId;
            #if MODULAR
            if (this.ConnectInstanceId == null && ParameterWasBound(nameof(this.ConnectInstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectInstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentlessDialerConfig_DialingCapacity = this.AgentlessDialerConfig_DialingCapacity;
            context.PredictiveDialerConfig_BandwidthAllocation = this.PredictiveDialerConfig_BandwidthAllocation;
            context.PredictiveDialerConfig_DialingCapacity = this.PredictiveDialerConfig_DialingCapacity;
            context.ProgressiveDialerConfig_BandwidthAllocation = this.ProgressiveDialerConfig_BandwidthAllocation;
            context.ProgressiveDialerConfig_DialingCapacity = this.ProgressiveDialerConfig_DialingCapacity;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnswerMachineDetectionConfig_EnableAnswerMachineDetection = this.AnswerMachineDetectionConfig_EnableAnswerMachineDetection;
            context.OutboundCallConfig_ConnectContactFlowId = this.OutboundCallConfig_ConnectContactFlowId;
            #if MODULAR
            if (this.OutboundCallConfig_ConnectContactFlowId == null && ParameterWasBound(nameof(this.OutboundCallConfig_ConnectContactFlowId)))
            {
                WriteWarning("You are passing $null as a value for parameter OutboundCallConfig_ConnectContactFlowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutboundCallConfig_ConnectQueueId = this.OutboundCallConfig_ConnectQueueId;
            context.OutboundCallConfig_ConnectSourcePhoneNumber = this.OutboundCallConfig_ConnectSourcePhoneNumber;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.ConnectCampaignService.Model.CreateCampaignRequest();
            
            if (cmdletContext.ConnectInstanceId != null)
            {
                request.ConnectInstanceId = cmdletContext.ConnectInstanceId;
            }
            
             // populate DialerConfig
            var requestDialerConfigIsNull = true;
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
                requestDialerConfigIsNull = false;
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
                requestDialerConfigIsNull = false;
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
                requestDialerConfigIsNull = false;
            }
             // determine if request.DialerConfig should be set to null
            if (requestDialerConfigIsNull)
            {
                request.DialerConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutboundCallConfig
            var requestOutboundCallConfigIsNull = true;
            request.OutboundCallConfig = new Amazon.ConnectCampaignService.Model.OutboundCallConfig();
            System.String requestOutboundCallConfig_outboundCallConfig_ConnectContactFlowId = null;
            if (cmdletContext.OutboundCallConfig_ConnectContactFlowId != null)
            {
                requestOutboundCallConfig_outboundCallConfig_ConnectContactFlowId = cmdletContext.OutboundCallConfig_ConnectContactFlowId;
            }
            if (requestOutboundCallConfig_outboundCallConfig_ConnectContactFlowId != null)
            {
                request.OutboundCallConfig.ConnectContactFlowId = requestOutboundCallConfig_outboundCallConfig_ConnectContactFlowId;
                requestOutboundCallConfigIsNull = false;
            }
            System.String requestOutboundCallConfig_outboundCallConfig_ConnectQueueId = null;
            if (cmdletContext.OutboundCallConfig_ConnectQueueId != null)
            {
                requestOutboundCallConfig_outboundCallConfig_ConnectQueueId = cmdletContext.OutboundCallConfig_ConnectQueueId;
            }
            if (requestOutboundCallConfig_outboundCallConfig_ConnectQueueId != null)
            {
                request.OutboundCallConfig.ConnectQueueId = requestOutboundCallConfig_outboundCallConfig_ConnectQueueId;
                requestOutboundCallConfigIsNull = false;
            }
            System.String requestOutboundCallConfig_outboundCallConfig_ConnectSourcePhoneNumber = null;
            if (cmdletContext.OutboundCallConfig_ConnectSourcePhoneNumber != null)
            {
                requestOutboundCallConfig_outboundCallConfig_ConnectSourcePhoneNumber = cmdletContext.OutboundCallConfig_ConnectSourcePhoneNumber;
            }
            if (requestOutboundCallConfig_outboundCallConfig_ConnectSourcePhoneNumber != null)
            {
                request.OutboundCallConfig.ConnectSourcePhoneNumber = requestOutboundCallConfig_outboundCallConfig_ConnectSourcePhoneNumber;
                requestOutboundCallConfigIsNull = false;
            }
            Amazon.ConnectCampaignService.Model.AnswerMachineDetectionConfig requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig = null;
            
             // populate AnswerMachineDetectionConfig
            var requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfigIsNull = true;
            requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig = new Amazon.ConnectCampaignService.Model.AnswerMachineDetectionConfig();
            System.Boolean? requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection = null;
            if (cmdletContext.AnswerMachineDetectionConfig_EnableAnswerMachineDetection != null)
            {
                requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection = cmdletContext.AnswerMachineDetectionConfig_EnableAnswerMachineDetection.Value;
            }
            if (requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection != null)
            {
                requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig.EnableAnswerMachineDetection = requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig_answerMachineDetectionConfig_EnableAnswerMachineDetection.Value;
                requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfigIsNull = false;
            }
             // determine if requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig should be set to null
            if (requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfigIsNull)
            {
                requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig = null;
            }
            if (requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig != null)
            {
                request.OutboundCallConfig.AnswerMachineDetectionConfig = requestOutboundCallConfig_outboundCallConfig_AnswerMachineDetectionConfig;
                requestOutboundCallConfigIsNull = false;
            }
             // determine if request.OutboundCallConfig should be set to null
            if (requestOutboundCallConfigIsNull)
            {
                request.OutboundCallConfig = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.ConnectCampaignService.Model.CreateCampaignResponse CallAWSServiceOperation(IAmazonConnectCampaignService client, Amazon.ConnectCampaignService.Model.CreateCampaignRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Campaign Service", "CreateCampaign");
            try
            {
                #if DESKTOP
                return client.CreateCampaign(request);
                #elif CORECLR
                return client.CreateCampaignAsync(request).GetAwaiter().GetResult();
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
            public System.String ConnectInstanceId { get; set; }
            public System.Double? AgentlessDialerConfig_DialingCapacity { get; set; }
            public System.Double? PredictiveDialerConfig_BandwidthAllocation { get; set; }
            public System.Double? PredictiveDialerConfig_DialingCapacity { get; set; }
            public System.Double? ProgressiveDialerConfig_BandwidthAllocation { get; set; }
            public System.Double? ProgressiveDialerConfig_DialingCapacity { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? AnswerMachineDetectionConfig_EnableAnswerMachineDetection { get; set; }
            public System.String OutboundCallConfig_ConnectContactFlowId { get; set; }
            public System.String OutboundCallConfig_ConnectQueueId { get; set; }
            public System.String OutboundCallConfig_ConnectSourcePhoneNumber { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ConnectCampaignService.Model.CreateCampaignResponse, NewCCSCampaignCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
