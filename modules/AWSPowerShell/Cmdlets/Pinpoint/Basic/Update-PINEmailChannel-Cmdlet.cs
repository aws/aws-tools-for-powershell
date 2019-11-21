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
    /// Enables the email channel for an application or updates the status and settings of
    /// the email channel for an application.
    /// </summary>
    [Cmdlet("Update", "PINEmailChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.EmailChannelResponse")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateEmailChannel API operation.", Operation = new[] {"UpdateEmailChannel"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateEmailChannelResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.EmailChannelResponse or Amazon.Pinpoint.Model.UpdateEmailChannelResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.EmailChannelResponse object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateEmailChannelResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdatePINEmailChannelCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter EmailChannelRequest_ConfigurationSet
        /// <summary>
        /// <para>
        /// <para>The configuration set that you want to apply to email that you send through the channel
        /// by using the <a href="emailAPIreference.html">Amazon Pinpoint Email API</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailChannelRequest_ConfigurationSet { get; set; }
        #endregion
        
        #region Parameter EmailChannelRequest_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the email channel for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EmailChannelRequest_Enabled { get; set; }
        #endregion
        
        #region Parameter EmailChannelRequest_FromAddress
        /// <summary>
        /// <para>
        /// <para>The verified email address that you want to send email from when you send email through
        /// the channel.</para>
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
        public System.String EmailChannelRequest_FromAddress { get; set; }
        #endregion
        
        #region Parameter EmailChannelRequest_Identity
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the identity, verified with Amazon Simple Email
        /// Service (Amazon SES), that you want to use when you send email through the channel.</para>
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
        public System.String EmailChannelRequest_Identity { get; set; }
        #endregion
        
        #region Parameter EmailChannelRequest_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Identity and Access Management (IAM) role that you want Amazon
        /// Pinpoint to use when it submits email-related event data for the channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailChannelRequest_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EmailChannelResponse'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateEmailChannelResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateEmailChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EmailChannelResponse";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINEmailChannel (UpdateEmailChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateEmailChannelResponse, UpdatePINEmailChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailChannelRequest_ConfigurationSet = this.EmailChannelRequest_ConfigurationSet;
            context.EmailChannelRequest_Enabled = this.EmailChannelRequest_Enabled;
            context.EmailChannelRequest_FromAddress = this.EmailChannelRequest_FromAddress;
            #if MODULAR
            if (this.EmailChannelRequest_FromAddress == null && ParameterWasBound(nameof(this.EmailChannelRequest_FromAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailChannelRequest_FromAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailChannelRequest_Identity = this.EmailChannelRequest_Identity;
            #if MODULAR
            if (this.EmailChannelRequest_Identity == null && ParameterWasBound(nameof(this.EmailChannelRequest_Identity)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailChannelRequest_Identity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailChannelRequest_RoleArn = this.EmailChannelRequest_RoleArn;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateEmailChannelRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate EmailChannelRequest
            var requestEmailChannelRequestIsNull = true;
            request.EmailChannelRequest = new Amazon.Pinpoint.Model.EmailChannelRequest();
            System.String requestEmailChannelRequest_emailChannelRequest_ConfigurationSet = null;
            if (cmdletContext.EmailChannelRequest_ConfigurationSet != null)
            {
                requestEmailChannelRequest_emailChannelRequest_ConfigurationSet = cmdletContext.EmailChannelRequest_ConfigurationSet;
            }
            if (requestEmailChannelRequest_emailChannelRequest_ConfigurationSet != null)
            {
                request.EmailChannelRequest.ConfigurationSet = requestEmailChannelRequest_emailChannelRequest_ConfigurationSet;
                requestEmailChannelRequestIsNull = false;
            }
            System.Boolean? requestEmailChannelRequest_emailChannelRequest_Enabled = null;
            if (cmdletContext.EmailChannelRequest_Enabled != null)
            {
                requestEmailChannelRequest_emailChannelRequest_Enabled = cmdletContext.EmailChannelRequest_Enabled.Value;
            }
            if (requestEmailChannelRequest_emailChannelRequest_Enabled != null)
            {
                request.EmailChannelRequest.Enabled = requestEmailChannelRequest_emailChannelRequest_Enabled.Value;
                requestEmailChannelRequestIsNull = false;
            }
            System.String requestEmailChannelRequest_emailChannelRequest_FromAddress = null;
            if (cmdletContext.EmailChannelRequest_FromAddress != null)
            {
                requestEmailChannelRequest_emailChannelRequest_FromAddress = cmdletContext.EmailChannelRequest_FromAddress;
            }
            if (requestEmailChannelRequest_emailChannelRequest_FromAddress != null)
            {
                request.EmailChannelRequest.FromAddress = requestEmailChannelRequest_emailChannelRequest_FromAddress;
                requestEmailChannelRequestIsNull = false;
            }
            System.String requestEmailChannelRequest_emailChannelRequest_Identity = null;
            if (cmdletContext.EmailChannelRequest_Identity != null)
            {
                requestEmailChannelRequest_emailChannelRequest_Identity = cmdletContext.EmailChannelRequest_Identity;
            }
            if (requestEmailChannelRequest_emailChannelRequest_Identity != null)
            {
                request.EmailChannelRequest.Identity = requestEmailChannelRequest_emailChannelRequest_Identity;
                requestEmailChannelRequestIsNull = false;
            }
            System.String requestEmailChannelRequest_emailChannelRequest_RoleArn = null;
            if (cmdletContext.EmailChannelRequest_RoleArn != null)
            {
                requestEmailChannelRequest_emailChannelRequest_RoleArn = cmdletContext.EmailChannelRequest_RoleArn;
            }
            if (requestEmailChannelRequest_emailChannelRequest_RoleArn != null)
            {
                request.EmailChannelRequest.RoleArn = requestEmailChannelRequest_emailChannelRequest_RoleArn;
                requestEmailChannelRequestIsNull = false;
            }
             // determine if request.EmailChannelRequest should be set to null
            if (requestEmailChannelRequestIsNull)
            {
                request.EmailChannelRequest = null;
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
        
        private Amazon.Pinpoint.Model.UpdateEmailChannelResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateEmailChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateEmailChannel");
            try
            {
                #if DESKTOP
                return client.UpdateEmailChannel(request);
                #elif CORECLR
                return client.UpdateEmailChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String EmailChannelRequest_ConfigurationSet { get; set; }
            public System.Boolean? EmailChannelRequest_Enabled { get; set; }
            public System.String EmailChannelRequest_FromAddress { get; set; }
            public System.String EmailChannelRequest_Identity { get; set; }
            public System.String EmailChannelRequest_RoleArn { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateEmailChannelResponse, UpdatePINEmailChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EmailChannelResponse;
        }
        
    }
}
