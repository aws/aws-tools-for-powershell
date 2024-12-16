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
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace Amazon.PowerShell.Cmdlets.SMSV
{
    /// <summary>
    /// Set the MessageFeedbackStatus as <c>RECEIVED</c> or <c>FAILED</c> for the passed in
    /// MessageId. 
    /// 
    ///  
    /// <para>
    /// If you use message feedback then you must update message feedback record. When you
    /// receive a signal that a user has received the message you must use <c>PutMessageFeedback</c>
    /// to set the message feedback record as <c>RECEIVED</c>; Otherwise, an hour after the
    /// message feedback record is set to <c>FAILED</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "SMSVMessageFeedback", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint SMS Voice V2 PutMessageFeedback API operation.", Operation = new[] {"PutMessageFeedback"}, SelectReturnType = typeof(Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse))]
    [AWSCmdletOutput("Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse",
        "This cmdlet returns an Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse object containing multiple properties."
    )]
    public partial class WriteSMSVMessageFeedbackCmdlet : AmazonPinpointSMSVoiceV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MessageFeedbackStatus
        /// <summary>
        /// <para>
        /// <para>Set the message feedback to be either <c>RECEIVED</c> or <c>FAILED</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.PinpointSMSVoiceV2.MessageFeedbackStatus")]
        public Amazon.PinpointSMSVoiceV2.MessageFeedbackStatus MessageFeedbackStatus { get; set; }
        #endregion
        
        #region Parameter MessageId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the message.</para>
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
        public System.String MessageId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse).
        /// Specifying the name of a property of type Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MessageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SMSVMessageFeedback (PutMessageFeedback)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse, WriteSMSVMessageFeedbackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MessageFeedbackStatus = this.MessageFeedbackStatus;
            #if MODULAR
            if (this.MessageFeedbackStatus == null && ParameterWasBound(nameof(this.MessageFeedbackStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageFeedbackStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageId = this.MessageId;
            #if MODULAR
            if (this.MessageId == null && ParameterWasBound(nameof(this.MessageId)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackRequest();
            
            if (cmdletContext.MessageFeedbackStatus != null)
            {
                request.MessageFeedbackStatus = cmdletContext.MessageFeedbackStatus;
            }
            if (cmdletContext.MessageId != null)
            {
                request.MessageId = cmdletContext.MessageId;
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
        
        private Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse CallAWSServiceOperation(IAmazonPinpointSMSVoiceV2 client, Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint SMS Voice V2", "PutMessageFeedback");
            try
            {
                #if DESKTOP
                return client.PutMessageFeedback(request);
                #elif CORECLR
                return client.PutMessageFeedbackAsync(request).GetAwaiter().GetResult();
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
            public Amazon.PinpointSMSVoiceV2.MessageFeedbackStatus MessageFeedbackStatus { get; set; }
            public System.String MessageId { get; set; }
            public System.Func<Amazon.PinpointSMSVoiceV2.Model.PutMessageFeedbackResponse, WriteSMSVMessageFeedbackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
