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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Enables the SMS channel for an application or updates the status and settings of the
    /// SMS channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINSmsChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.SMSChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateSmsChannel API operation.", Operation = new[] {"UpdateSmsChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateSmsChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.SMSChannelResponse or Amazon.Pinpoint.Model.UpdateSmsChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.SMSChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateSmsChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINSmsChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter SMSChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the SMS channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SMSChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter SMSChannelRequest_SenderId
        /// <summary>
        /// <para>
        /// <para>The identity that you want to display on recipients' devices when they receive messages
        /// from the SMS channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SMSChannelRequest_SenderId { get; set; }
        #endregion
        
        #region Parameter SMSChannelRequest_ShortCode
        /// <summary>
        /// <para>
        /// <para>The registered short code that you want to use when you send messages through the
        /// SMS channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SMSChannelRequest_ShortCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SMSChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateSmsChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateSmsChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SMSChannelResponse";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINSmsChannel (UpdateSmsChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateSmsChannelResponse, UpdatePINSmsChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SMSChannelRequest_Enabled = this.SMSChannelRequest_Enabled;
            context.SMSChannelRequest_SenderId = this.SMSChannelRequest_SenderId;
            context.SMSChannelRequest_ShortCode = this.SMSChannelRequest_ShortCode;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateSmsChannelRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate SMSChannelRequest
            var requestSMSChannelRequestIsNull = true;
            request.SMSChannelRequest = new Amazon.Pinpoint.Model.SMSChannelRequest();
            System.Boolean? requestSMSChannelRequest_sMSChannelRequest_Enabled = null;
            if (cmdletContext.SMSChannelRequest_Enabled != null)
            {
                requestSMSChannelRequest_sMSChannelRequest_Enabled = cmdletContext.SMSChannelRequest_Enabled.Value;
            }
            if (requestSMSChannelRequest_sMSChannelRequest_Enabled != null)
            {
                request.SMSChannelRequest.Enabled = requestSMSChannelRequest_sMSChannelRequest_Enabled.Value;
                requestSMSChannelRequestIsNull = false;
            }
            System.String requestSMSChannelRequest_sMSChannelRequest_SenderId = null;
            if (cmdletContext.SMSChannelRequest_SenderId != null)
            {
                requestSMSChannelRequest_sMSChannelRequest_SenderId = cmdletContext.SMSChannelRequest_SenderId;
            }
            if (requestSMSChannelRequest_sMSChannelRequest_SenderId != null)
            {
                request.SMSChannelRequest.SenderId = requestSMSChannelRequest_sMSChannelRequest_SenderId;
                requestSMSChannelRequestIsNull = false;
            }
            System.String requestSMSChannelRequest_sMSChannelRequest_ShortCode = null;
            if (cmdletContext.SMSChannelRequest_ShortCode != null)
            {
                requestSMSChannelRequest_sMSChannelRequest_ShortCode = cmdletContext.SMSChannelRequest_ShortCode;
            }
            if (requestSMSChannelRequest_sMSChannelRequest_ShortCode != null)
            {
                request.SMSChannelRequest.ShortCode = requestSMSChannelRequest_sMSChannelRequest_ShortCode;
                requestSMSChannelRequestIsNull = false;
            }
             // determine if request.SMSChannelRequest should be set to null
            if (requestSMSChannelRequestIsNull)
            {
                request.SMSChannelRequest = null;
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
        
        private Amazon.Pinpoint.Model.UpdateSmsChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateSmsChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateSmsChannel");
            try
            {
                #if DESKTOP
                return client.UpdateSmsChannel(request);
                #elif CORECLR
                return client.UpdateSmsChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.Boolean? SMSChannelRequest_Enabled { get; set; }
            public System.String SMSChannelRequest_SenderId { get; set; }
            public System.String SMSChannelRequest_ShortCode { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateSmsChannelResponse, UpdatePINSmsChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SMSChannelResponse;
        }
        
    }
}
