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
using Amazon.QConnect;
using Amazon.QConnect.Model;

namespace Amazon.PowerShell.Cmdlets.QC
{
    /// <summary>
    /// Creates a new Amazon Q in Connect message template version from the current content
    /// and configuration of a message template. Versions are immutable and monotonically
    /// increasing. Once a version is created, you can reference a specific version of the
    /// message template by passing in <c>&lt;message-template-id&gt;:&lt;versionNumber&gt;</c>
    /// as the message template identifier. An error is displayed if the supplied <c>messageTemplateContentSha256</c>
    /// is different from the <c>messageTemplateContentSha256</c> of the message template
    /// with <c>$LATEST</c> qualifier. If multiple <c>CreateMessageTemplateVersion</c> requests
    /// are made while the message template remains the same, only the first invocation creates
    /// a new version and the succeeding requests will return the same response as the first
    /// invocation.
    /// </summary>
    [Cmdlet("New", "QCMessageTemplateVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QConnect.Model.ExtendedMessageTemplateData")]
    [AWSCmdlet("Calls the Amazon Q Connect CreateMessageTemplateVersion API operation.", Operation = new[] {"CreateMessageTemplateVersion"}, SelectReturnType = typeof(Amazon.QConnect.Model.CreateMessageTemplateVersionResponse))]
    [AWSCmdletOutput("Amazon.QConnect.Model.ExtendedMessageTemplateData or Amazon.QConnect.Model.CreateMessageTemplateVersionResponse",
        "This cmdlet returns an Amazon.QConnect.Model.ExtendedMessageTemplateData object.",
        "The service call response (type Amazon.QConnect.Model.CreateMessageTemplateVersionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewQCMessageTemplateVersionCmdlet : AmazonQConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The identifier of the knowledge base. Can be either the ID or the ARN. URLs cannot
        /// contain the ARN.</para>
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
        public System.String KnowledgeBaseId { get; set; }
        #endregion
        
        #region Parameter MessageTemplateContentSha256
        /// <summary>
        /// <para>
        /// <para>The checksum value of the message template content that is referenced by the <c>$LATEST</c>
        /// qualifier. It can be returned in <c>MessageTemplateData</c> or <c>ExtendedMessageTemplateData</c>.
        /// It’s calculated by content, language, <c>defaultAttributes</c> and <c>Attachments</c>
        /// of the message template. If not supplied, the message template version will be created
        /// based on the message template content that is referenced by the <c>$LATEST</c> qualifier
        /// by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MessageTemplateContentSha256 { get; set; }
        #endregion
        
        #region Parameter MessageTemplateId
        /// <summary>
        /// <para>
        /// <para>The identifier of the message template. Can be either the ID or the ARN. It cannot
        /// contain any qualifier.</para>
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
        public System.String MessageTemplateId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageTemplate'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QConnect.Model.CreateMessageTemplateVersionResponse).
        /// Specifying the name of a property of type Amazon.QConnect.Model.CreateMessageTemplateVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageTemplate";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MessageTemplateId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MessageTemplateId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MessageTemplateId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MessageTemplateId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-QCMessageTemplateVersion (CreateMessageTemplateVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QConnect.Model.CreateMessageTemplateVersionResponse, NewQCMessageTemplateVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MessageTemplateId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MessageTemplateContentSha256 = this.MessageTemplateContentSha256;
            context.MessageTemplateId = this.MessageTemplateId;
            #if MODULAR
            if (this.MessageTemplateId == null && ParameterWasBound(nameof(this.MessageTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter MessageTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QConnect.Model.CreateMessageTemplateVersionRequest();
            
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            if (cmdletContext.MessageTemplateContentSha256 != null)
            {
                request.MessageTemplateContentSha256 = cmdletContext.MessageTemplateContentSha256;
            }
            if (cmdletContext.MessageTemplateId != null)
            {
                request.MessageTemplateId = cmdletContext.MessageTemplateId;
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
        
        private Amazon.QConnect.Model.CreateMessageTemplateVersionResponse CallAWSServiceOperation(IAmazonQConnect client, Amazon.QConnect.Model.CreateMessageTemplateVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Q Connect", "CreateMessageTemplateVersion");
            try
            {
                #if DESKTOP
                return client.CreateMessageTemplateVersion(request);
                #elif CORECLR
                return client.CreateMessageTemplateVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String KnowledgeBaseId { get; set; }
            public System.String MessageTemplateContentSha256 { get; set; }
            public System.String MessageTemplateId { get; set; }
            public System.Func<Amazon.QConnect.Model.CreateMessageTemplateVersionResponse, NewQCMessageTemplateVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageTemplate;
        }
        
    }
}
