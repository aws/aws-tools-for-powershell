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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates a message template for messages that are sent through the voice channel.
    /// </summary>
    [Cmdlet("New", "PINVoiceTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.CreateTemplateMessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateVoiceTemplate API operation.", Operation = new[] {"CreateVoiceTemplate"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateVoiceTemplateResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.CreateTemplateMessageBody or Amazon.Pinpoint.Model.CreateVoiceTemplateResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.CreateTemplateMessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateVoiceTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPINVoiceTemplateCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VoiceTemplateRequest_Body
        /// <summary>
        /// <para>
        /// <para>The text of the script to use in messages that are based on the message template,
        /// in plain text format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VoiceTemplateRequest_Body { get; set; }
        #endregion
        
        #region Parameter VoiceTemplateRequest_DefaultSubstitution
        /// <summary>
        /// <para>
        /// <para>A JSON object that specifies the default values to use for message variables in the
        /// message template. This object is a set of key-value pairs. Each key defines a message
        /// variable in the template. The corresponding value defines the default value for that
        /// variable. When you create a message that's based on the template, you can override
        /// these defaults with message-specific and address-specific variables and values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VoiceTemplateRequest_DefaultSubstitutions")]
        public System.String VoiceTemplateRequest_DefaultSubstitution { get; set; }
        #endregion
        
        #region Parameter VoiceTemplateRequest_LanguageCode
        /// <summary>
        /// <para>
        /// <para>The code for the language to use when synthesizing the text of the script in messages
        /// that are based on the message template. For a list of supported languages and the
        /// code for each one, see the <a href="https://docs.aws.amazon.com/polly/latest/dg/what-is.html">Amazon
        /// Polly Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VoiceTemplateRequest_LanguageCode { get; set; }
        #endregion
        
        #region Parameter VoiceTemplateRequest_Tag
        /// <summary>
        /// <para>
        /// <note><para>As of <b>22-05-2023</b> tags has been deprecated for update operations. After this
        /// date any value in tags is not processed and an error code is not returned. To manage
        /// tags we recommend using either <a href="https://docs.aws.amazon.com/pinpoint/latest/apireference/tags-resource-arn.html">Tags</a>
        /// in the <i>API Reference for Amazon Pinpoint</i>, <a href="https://docs.aws.amazon.com/cli/latest/reference/resourcegroupstaggingapi/index.html">resourcegroupstaggingapi</a>
        /// commands in the <i>AWS Command Line Interface Documentation</i> or <a href="https://sdk.amazonaws.com/java/api/latest/software/amazon/awssdk/services/resourcegroupstaggingapi/package-summary.html">resourcegroupstaggingapi</a>
        /// in the <i>AWS SDK</i>.</para></note><para>(Deprecated) A string-to-string map of key-value pairs that defines the tags to associate
        /// with the message template. Each tag consists of a required tag key and an associated
        /// tag value.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VoiceTemplateRequest_Tags")]
        public System.Collections.Hashtable VoiceTemplateRequest_Tag { get; set; }
        #endregion
        
        #region Parameter VoiceTemplateRequest_TemplateDescription
        /// <summary>
        /// <para>
        /// <para>A custom description of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VoiceTemplateRequest_TemplateDescription { get; set; }
        #endregion
        
        #region Parameter TemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the message template. A template name must start with an alphanumeric
        /// character and can contain a maximum of 128 characters. The characters can be alphanumeric
        /// characters, underscores (_), or hyphens (-). Template names are case sensitive.</para>
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
        public System.String TemplateName { get; set; }
        #endregion
        
        #region Parameter VoiceTemplateRequest_VoiceId
        /// <summary>
        /// <para>
        /// <para>The name of the voice to use when delivering messages that are based on the message
        /// template. For a list of supported voices, see the <a href="https://docs.aws.amazon.com/polly/latest/dg/what-is.html">Amazon
        /// Polly Developer Guide</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VoiceTemplateRequest_VoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CreateTemplateMessageBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateVoiceTemplateResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateVoiceTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CreateTemplateMessageBody";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINVoiceTemplate (CreateVoiceTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateVoiceTemplateResponse, NewPINVoiceTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VoiceTemplateRequest_Body = this.VoiceTemplateRequest_Body;
            context.VoiceTemplateRequest_DefaultSubstitution = this.VoiceTemplateRequest_DefaultSubstitution;
            context.VoiceTemplateRequest_LanguageCode = this.VoiceTemplateRequest_LanguageCode;
            if (this.VoiceTemplateRequest_Tag != null)
            {
                context.VoiceTemplateRequest_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.VoiceTemplateRequest_Tag.Keys)
                {
                    context.VoiceTemplateRequest_Tag.Add((String)hashKey, (System.String)(this.VoiceTemplateRequest_Tag[hashKey]));
                }
            }
            context.VoiceTemplateRequest_TemplateDescription = this.VoiceTemplateRequest_TemplateDescription;
            context.VoiceTemplateRequest_VoiceId = this.VoiceTemplateRequest_VoiceId;
            
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
            var request = new Amazon.Pinpoint.Model.CreateVoiceTemplateRequest();
            
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            
             // populate VoiceTemplateRequest
            var requestVoiceTemplateRequestIsNull = true;
            request.VoiceTemplateRequest = new Amazon.Pinpoint.Model.VoiceTemplateRequest();
            System.String requestVoiceTemplateRequest_voiceTemplateRequest_Body = null;
            if (cmdletContext.VoiceTemplateRequest_Body != null)
            {
                requestVoiceTemplateRequest_voiceTemplateRequest_Body = cmdletContext.VoiceTemplateRequest_Body;
            }
            if (requestVoiceTemplateRequest_voiceTemplateRequest_Body != null)
            {
                request.VoiceTemplateRequest.Body = requestVoiceTemplateRequest_voiceTemplateRequest_Body;
                requestVoiceTemplateRequestIsNull = false;
            }
            System.String requestVoiceTemplateRequest_voiceTemplateRequest_DefaultSubstitution = null;
            if (cmdletContext.VoiceTemplateRequest_DefaultSubstitution != null)
            {
                requestVoiceTemplateRequest_voiceTemplateRequest_DefaultSubstitution = cmdletContext.VoiceTemplateRequest_DefaultSubstitution;
            }
            if (requestVoiceTemplateRequest_voiceTemplateRequest_DefaultSubstitution != null)
            {
                request.VoiceTemplateRequest.DefaultSubstitutions = requestVoiceTemplateRequest_voiceTemplateRequest_DefaultSubstitution;
                requestVoiceTemplateRequestIsNull = false;
            }
            System.String requestVoiceTemplateRequest_voiceTemplateRequest_LanguageCode = null;
            if (cmdletContext.VoiceTemplateRequest_LanguageCode != null)
            {
                requestVoiceTemplateRequest_voiceTemplateRequest_LanguageCode = cmdletContext.VoiceTemplateRequest_LanguageCode;
            }
            if (requestVoiceTemplateRequest_voiceTemplateRequest_LanguageCode != null)
            {
                request.VoiceTemplateRequest.LanguageCode = requestVoiceTemplateRequest_voiceTemplateRequest_LanguageCode;
                requestVoiceTemplateRequestIsNull = false;
            }
            Dictionary<System.String, System.String> requestVoiceTemplateRequest_voiceTemplateRequest_Tag = null;
            if (cmdletContext.VoiceTemplateRequest_Tag != null)
            {
                requestVoiceTemplateRequest_voiceTemplateRequest_Tag = cmdletContext.VoiceTemplateRequest_Tag;
            }
            if (requestVoiceTemplateRequest_voiceTemplateRequest_Tag != null)
            {
                request.VoiceTemplateRequest.Tags = requestVoiceTemplateRequest_voiceTemplateRequest_Tag;
                requestVoiceTemplateRequestIsNull = false;
            }
            System.String requestVoiceTemplateRequest_voiceTemplateRequest_TemplateDescription = null;
            if (cmdletContext.VoiceTemplateRequest_TemplateDescription != null)
            {
                requestVoiceTemplateRequest_voiceTemplateRequest_TemplateDescription = cmdletContext.VoiceTemplateRequest_TemplateDescription;
            }
            if (requestVoiceTemplateRequest_voiceTemplateRequest_TemplateDescription != null)
            {
                request.VoiceTemplateRequest.TemplateDescription = requestVoiceTemplateRequest_voiceTemplateRequest_TemplateDescription;
                requestVoiceTemplateRequestIsNull = false;
            }
            System.String requestVoiceTemplateRequest_voiceTemplateRequest_VoiceId = null;
            if (cmdletContext.VoiceTemplateRequest_VoiceId != null)
            {
                requestVoiceTemplateRequest_voiceTemplateRequest_VoiceId = cmdletContext.VoiceTemplateRequest_VoiceId;
            }
            if (requestVoiceTemplateRequest_voiceTemplateRequest_VoiceId != null)
            {
                request.VoiceTemplateRequest.VoiceId = requestVoiceTemplateRequest_voiceTemplateRequest_VoiceId;
                requestVoiceTemplateRequestIsNull = false;
            }
             // determine if request.VoiceTemplateRequest should be set to null
            if (requestVoiceTemplateRequestIsNull)
            {
                request.VoiceTemplateRequest = null;
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
        
        private Amazon.Pinpoint.Model.CreateVoiceTemplateResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateVoiceTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateVoiceTemplate");
            try
            {
                return client.CreateVoiceTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String TemplateName { get; set; }
            public System.String VoiceTemplateRequest_Body { get; set; }
            public System.String VoiceTemplateRequest_DefaultSubstitution { get; set; }
            public System.String VoiceTemplateRequest_LanguageCode { get; set; }
            public Dictionary<System.String, System.String> VoiceTemplateRequest_Tag { get; set; }
            public System.String VoiceTemplateRequest_TemplateDescription { get; set; }
            public System.String VoiceTemplateRequest_VoiceId { get; set; }
            public System.Func<Amazon.Pinpoint.Model.CreateVoiceTemplateResponse, NewPINVoiceTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CreateTemplateMessageBody;
        }
        
    }
}
