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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Updates the draft outbound email message for a contact. Use this operation to save
    /// changes to an in-progress outbound email reply before you send it. This operation
    /// applies only to contacts with an <c>OUTBOUND</c> or <c>AGENT_REPLY</c> initiation
    /// method; it isn't supported for flow-initiated emails.
    /// </summary>
    [Cmdlet("Update", "CONNOutboundEmailContactMessage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Connect Service UpdateOutboundEmailContactMessage API operation.", Operation = new[] {"UpdateOutboundEmailContactMessage"}, SelectReturnType = typeof(Amazon.Connect.Model.UpdateOutboundEmailContactMessageResponse))]
    [AWSCmdletOutput("System.String or Amazon.Connect.Model.UpdateOutboundEmailContactMessageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Connect.Model.UpdateOutboundEmailContactMessageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCONNOutboundEmailContactMessageCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EmailMessage_RawMessage_Body
        /// <summary>
        /// <para>
        /// <para>The email message body.</para>
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
        public System.String EmailMessage_RawMessage_Body { get; set; }
        #endregion
        
        #region Parameter ContactId
        /// <summary>
        /// <para>
        /// <para>The identifier of the contact in this instance of Connect Customer. </para>
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
        public System.String ContactId { get; set; }
        #endregion
        
        #region Parameter EmailMessage_RawMessage_ContentType
        /// <summary>
        /// <para>
        /// <para>The content type of the email body. Valid values:</para><ul><li><para><c>text/plain</c> – Plain text content.</para></li><li><para><c>text/html</c> – HTML-formatted content.</para></li></ul>
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
        public System.String EmailMessage_RawMessage_ContentType { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter EmailMessage_MessageSourceType
        /// <summary>
        /// <para>
        /// <para>The message source type. The only supported value is <c>RAW</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.UpdateOutboundEmailMessageSourceType")]
        public Amazon.Connect.UpdateOutboundEmailMessageSourceType EmailMessage_MessageSourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContactId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.UpdateOutboundEmailContactMessageResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.UpdateOutboundEmailContactMessageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContactId";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ContactId),
                nameof(this.InstanceId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CONNOutboundEmailContactMessage (UpdateOutboundEmailContactMessage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.UpdateOutboundEmailContactMessageResponse, UpdateCONNOutboundEmailContactMessageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContactId = this.ContactId;
            #if MODULAR
            if (this.ContactId == null && ParameterWasBound(nameof(this.ContactId)))
            {
                WriteWarning("You are passing $null as a value for parameter ContactId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailMessage_MessageSourceType = this.EmailMessage_MessageSourceType;
            #if MODULAR
            if (this.EmailMessage_MessageSourceType == null && ParameterWasBound(nameof(this.EmailMessage_MessageSourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailMessage_MessageSourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailMessage_RawMessage_Body = this.EmailMessage_RawMessage_Body;
            #if MODULAR
            if (this.EmailMessage_RawMessage_Body == null && ParameterWasBound(nameof(this.EmailMessage_RawMessage_Body)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailMessage_RawMessage_Body which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EmailMessage_RawMessage_ContentType = this.EmailMessage_RawMessage_ContentType;
            #if MODULAR
            if (this.EmailMessage_RawMessage_ContentType == null && ParameterWasBound(nameof(this.EmailMessage_RawMessage_ContentType)))
            {
                WriteWarning("You are passing $null as a value for parameter EmailMessage_RawMessage_ContentType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Connect.Model.UpdateOutboundEmailContactMessageRequest();
            
            if (cmdletContext.ContactId != null)
            {
                request.ContactId = cmdletContext.ContactId;
            }
            
             // populate EmailMessage
            var requestEmailMessageIsNull = true;
            request.EmailMessage = new Amazon.Connect.Model.UpdateOutboundEmailContent();
            Amazon.Connect.UpdateOutboundEmailMessageSourceType requestEmailMessage_emailMessage_MessageSourceType = null;
            if (cmdletContext.EmailMessage_MessageSourceType != null)
            {
                requestEmailMessage_emailMessage_MessageSourceType = cmdletContext.EmailMessage_MessageSourceType;
            }
            if (requestEmailMessage_emailMessage_MessageSourceType != null)
            {
                request.EmailMessage.MessageSourceType = requestEmailMessage_emailMessage_MessageSourceType;
                requestEmailMessageIsNull = false;
            }
            Amazon.Connect.Model.UpdateOutboundRawMessage requestEmailMessage_emailMessage_RawMessage = null;
            
             // populate RawMessage
            var requestEmailMessage_emailMessage_RawMessageIsNull = true;
            requestEmailMessage_emailMessage_RawMessage = new Amazon.Connect.Model.UpdateOutboundRawMessage();
            System.String requestEmailMessage_emailMessage_RawMessage_emailMessage_RawMessage_Body = null;
            if (cmdletContext.EmailMessage_RawMessage_Body != null)
            {
                requestEmailMessage_emailMessage_RawMessage_emailMessage_RawMessage_Body = cmdletContext.EmailMessage_RawMessage_Body;
            }
            if (requestEmailMessage_emailMessage_RawMessage_emailMessage_RawMessage_Body != null)
            {
                requestEmailMessage_emailMessage_RawMessage.Body = requestEmailMessage_emailMessage_RawMessage_emailMessage_RawMessage_Body;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
            System.String requestEmailMessage_emailMessage_RawMessage_emailMessage_RawMessage_ContentType = null;
            if (cmdletContext.EmailMessage_RawMessage_ContentType != null)
            {
                requestEmailMessage_emailMessage_RawMessage_emailMessage_RawMessage_ContentType = cmdletContext.EmailMessage_RawMessage_ContentType;
            }
            if (requestEmailMessage_emailMessage_RawMessage_emailMessage_RawMessage_ContentType != null)
            {
                requestEmailMessage_emailMessage_RawMessage.ContentType = requestEmailMessage_emailMessage_RawMessage_emailMessage_RawMessage_ContentType;
                requestEmailMessage_emailMessage_RawMessageIsNull = false;
            }
             // determine if requestEmailMessage_emailMessage_RawMessage should be set to null
            if (requestEmailMessage_emailMessage_RawMessageIsNull)
            {
                requestEmailMessage_emailMessage_RawMessage = null;
            }
            if (requestEmailMessage_emailMessage_RawMessage != null)
            {
                request.EmailMessage.RawMessage = requestEmailMessage_emailMessage_RawMessage;
                requestEmailMessageIsNull = false;
            }
             // determine if request.EmailMessage should be set to null
            if (requestEmailMessageIsNull)
            {
                request.EmailMessage = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
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
        
        private Amazon.Connect.Model.UpdateOutboundEmailContactMessageResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.UpdateOutboundEmailContactMessageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "UpdateOutboundEmailContactMessage");
            try
            {
                return client.UpdateOutboundEmailContactMessageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ContactId { get; set; }
            public Amazon.Connect.UpdateOutboundEmailMessageSourceType EmailMessage_MessageSourceType { get; set; }
            public System.String EmailMessage_RawMessage_Body { get; set; }
            public System.String EmailMessage_RawMessage_ContentType { get; set; }
            public System.String InstanceId { get; set; }
            public System.Func<Amazon.Connect.Model.UpdateOutboundEmailContactMessageResponse, UpdateCONNOutboundEmailContactMessageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContactId;
        }
        
    }
}
