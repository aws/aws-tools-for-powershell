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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// This API is in preview release for Amazon Connect and is subject to change.
    /// 
    ///  
    /// <para>
    /// Updates the outbound caller ID name, number, and outbound whisper flow for a specified
    /// queue.
    /// </para><important><ul><li><para>
    /// If the phone number is claimed to a traffic distribution group that was created in
    /// the same Region as the Amazon Connect instance where you are calling this API, then
    /// you can use a full phone number ARN or a UUID for <c>OutboundCallerIdNumberId</c>.
    /// However, if the phone number is claimed to a traffic distribution group that is in
    /// one Region, and you are calling this API from an instance in another Amazon Web Services
    /// Region that is associated with the traffic distribution group, you must provide a
    /// full phone number ARN. If a UUID is provided in this scenario, you will receive a
    /// <c>ResourceNotFoundException</c>.
    /// </para></li><li><para>
    /// Only use the phone number ARN format that doesn't contain <c>instance</c> in the path,
    /// for example, <c>arn:aws:connect:us-east-1:1234567890:phone-number/uuid</c>. This is
    /// the same ARN format that is returned when you call the <a href="https://docs.aws.amazon.com/connect/latest/APIReference/API_ListPhoneNumbersV2.html">ListPhoneNumbersV2</a>
    /// API.
    /// </para></li><li><para>
    /// If you plan to use IAM policies to allow/deny access to this API for phone number
    /// resources claimed to a traffic distribution group, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/security_iam_resource-level-policy-examples.html#allow-deny-queue-actions-replica-region">Allow
    /// or Deny queue API actions for phone numbers in a replica Region</a>.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("Update", "CONNQueueOutboundCallerConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateQueueOutboundCallerConfig API operation.", Operation = new[] {"UpdateQueueOutboundCallerConfig"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateQueueOutboundCallerConfigResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.UpdateQueueOutboundCallerConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.UpdateQueueOutboundCallerConfigResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNQueueOutboundCallerConfigCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter OutboundCallerConfig_OutboundCallerIdName
        /// <summary>
        /// <para>
        /// <para>The caller ID name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutboundCallerConfig_OutboundCallerIdName { get; set; }
        #endregion
        
        #region Parameter OutboundCallerConfig_OutboundCallerIdNumberId
        /// <summary>
        /// <para>
        /// <para>The caller ID number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutboundCallerConfig_OutboundCallerIdNumberId { get; set; }
        #endregion
        
        #region Parameter OutboundCallerConfig_OutboundFlowId
        /// <summary>
        /// <para>
        /// <para>The outbound whisper flow to be used during an outbound call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutboundCallerConfig_OutboundFlowId { get; set; }
        #endregion
        
        #region Parameter QueueId
        /// <summary>
        /// <para>
        /// <para>The identifier for the queue.</para>
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
        public System.String QueueId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateQueueOutboundCallerConfigResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNQueueOutboundCallerConfig (UpdateQueueOutboundCallerConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateQueueOutboundCallerConfigResponse, UpdateCONNQueueOutboundCallerConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutboundCallerConfig_OutboundCallerIdName = this.OutboundCallerConfig_OutboundCallerIdName;
            context.OutboundCallerConfig_OutboundCallerIdNumberId = this.OutboundCallerConfig_OutboundCallerIdNumberId;
            context.OutboundCallerConfig_OutboundFlowId = this.OutboundCallerConfig_OutboundFlowId;
            context.QueueId = this.QueueId;
            #if MODULAR
            if (this.QueueId == null && ParameterWasBound(nameof(this.QueueId)))
            {
                WriteWarning("You are passing $null as a value for parameter QueueId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateQueueOutboundCallerConfigRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
             // populate OutboundCallerConfig
            var requestOutboundCallerConfigIsNull = true;
            request.OutboundCallerConfig = new Amazon.Connect.Model.OutboundCallerConfig();
            System.String requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdName = null;
            if (cmdletContext.OutboundCallerConfig_OutboundCallerIdName != null)
            {
                requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdName = cmdletContext.OutboundCallerConfig_OutboundCallerIdName;
            }
            if (requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdName != null)
            {
                request.OutboundCallerConfig.OutboundCallerIdName = requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdName;
                requestOutboundCallerConfigIsNull = false;
            }
            System.String requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdNumberId = null;
            if (cmdletContext.OutboundCallerConfig_OutboundCallerIdNumberId != null)
            {
                requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdNumberId = cmdletContext.OutboundCallerConfig_OutboundCallerIdNumberId;
            }
            if (requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdNumberId != null)
            {
                request.OutboundCallerConfig.OutboundCallerIdNumberId = requestOutboundCallerConfig_outboundCallerConfig_OutboundCallerIdNumberId;
                requestOutboundCallerConfigIsNull = false;
            }
            System.String requestOutboundCallerConfig_outboundCallerConfig_OutboundFlowId = null;
            if (cmdletContext.OutboundCallerConfig_OutboundFlowId != null)
            {
                requestOutboundCallerConfig_outboundCallerConfig_OutboundFlowId = cmdletContext.OutboundCallerConfig_OutboundFlowId;
            }
            if (requestOutboundCallerConfig_outboundCallerConfig_OutboundFlowId != null)
            {
                request.OutboundCallerConfig.OutboundFlowId = requestOutboundCallerConfig_outboundCallerConfig_OutboundFlowId;
                requestOutboundCallerConfigIsNull = false;
            }
             // determine if request.OutboundCallerConfig should be set to null
            if (requestOutboundCallerConfigIsNull)
            {
                request.OutboundCallerConfig = null;
            }
            if (cmdletContext.QueueId != null)
            {
                request.QueueId = cmdletContext.QueueId;
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
        
        private Amazon.Connect.Model.UpdateQueueOutboundCallerConfigResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateQueueOutboundCallerConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateQueueOutboundCallerConfig");
            try
            {
                #if DESKTOP
                return client.UpdateQueueOutboundCallerConfig(request);
                #elif CORECLR
                return client.UpdateQueueOutboundCallerConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.String OutboundCallerConfig_OutboundCallerIdName { get; set; }
            public System.String OutboundCallerConfig_OutboundCallerIdNumberId { get; set; }
            public System.String OutboundCallerConfig_OutboundFlowId { get; set; }
            public System.String QueueId { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateQueueOutboundCallerConfigResponse, UpdateCONNQueueOutboundCallerConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
