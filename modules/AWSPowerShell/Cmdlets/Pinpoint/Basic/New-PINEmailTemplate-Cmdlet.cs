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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates a message template for messages that are sent through the email channel.
    /// </summary>
    [Cmdlet("New", "PINEmailTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.CreateTemplateMessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint CreateEmailTemplate API operation.", Operation = new[] {"CreateEmailTemplate"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.CreateEmailTemplateResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.CreateTemplateMessageBody or Amazon.Pinpoint.Model.CreateEmailTemplateResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.CreateTemplateMessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.CreateEmailTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewPINEmailTemplateCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EmailTemplateRequest_DefaultSubstitution
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
        [Alias("EmailTemplateRequest_DefaultSubstitutions")]
        public System.String EmailTemplateRequest_DefaultSubstitution { get; set; }
        #endregion
        
        #region Parameter EmailTemplateRequest_Header
        /// <summary>
        /// <para>
        /// <para>The list of <a href="https://docs.aws.amazon.com/pinpoint/latest/apireference/templates-template-name-email.html#templates-template-name-email-model-messageheader">MessageHeaders</a>
        /// for the email. You can have up to 15 Headers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailTemplateRequest_Headers")]
        public Amazon.Pinpoint.Model.MessageHeader[] EmailTemplateRequest_Header { get; set; }
        #endregion
        
        #region Parameter EmailTemplateRequest_HtmlPart
        /// <summary>
        /// <para>
        /// <para>The message body, in HTML format, to use in email messages that are based on the message
        /// template. We recommend using HTML format for email clients that render HTML content.
        /// You can include links, formatted text, and more in an HTML message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailTemplateRequest_HtmlPart { get; set; }
        #endregion
        
        #region Parameter EmailTemplateRequest_RecommenderId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the recommender model to use for the message template. Amazon
        /// Pinpoint uses this value to determine how to retrieve and process data from a recommender
        /// model when it sends messages that use the template, if the template contains message
        /// variables for recommendation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailTemplateRequest_RecommenderId { get; set; }
        #endregion
        
        #region Parameter EmailTemplateRequest_Subject
        /// <summary>
        /// <para>
        /// <para>The subject line, or title, to use in email messages that are based on the message
        /// template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailTemplateRequest_Subject { get; set; }
        #endregion
        
        #region Parameter EmailTemplateRequest_Tag
        /// <summary>
        /// <para>
        /// <note><para>As of <b>22-05-2023</b> tags has been deprecated for update operations. After this
        /// date any value in tags is not processed and an error code is not returned. To manage
        /// tags we recommend using either <a href="https://docs.aws.amazon.com/pinpoint/latest/apireference/tags-resource-arn.html">Tags</a>
        /// in the <i>API Reference for Amazon Pinpoint</i>, <a href="https://docs.aws.amazon.com/cli/latest/reference/resourcegroupstaggingapi/index.html">resourcegroupstaggingapi</a>
        /// commands in the <i>AWS Command Line Interface Documentation</i> or <a href="https://sdk.amazonaws.com/java/api/latest/software/amazon/awssdk/services/resourcegroupstaggingapi/package-summary.html">resourcegroupstaggingapi</a>
        /// in the <i>AWS SDK</i>.</para></note><para>(Deprecated) A string-to-string map of key-value pairs that defines the tags to associate
        /// with the message template. Each tag consists of a required tag key and an associated
        /// tag value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EmailTemplateRequest_Tags")]
        public System.Collections.Hashtable EmailTemplateRequest_Tag { get; set; }
        #endregion
        
        #region Parameter EmailTemplateRequest_TemplateDescription
        /// <summary>
        /// <para>
        /// <para>A custom description of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailTemplateRequest_TemplateDescription { get; set; }
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
        
        #region Parameter EmailTemplateRequest_TextPart
        /// <summary>
        /// <para>
        /// <para>The message body, in plain text format, to use in email messages that are based on
        /// the message template. We recommend using plain text format for email clients that
        /// don't render HTML content and clients that are connected to high-latency networks,
        /// such as mobile devices.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EmailTemplateRequest_TextPart { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CreateTemplateMessageBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.CreateEmailTemplateResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.CreateEmailTemplateResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PINEmailTemplate (CreateEmailTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.CreateEmailTemplateResponse, NewPINEmailTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EmailTemplateRequest_DefaultSubstitution = this.EmailTemplateRequest_DefaultSubstitution;
            if (this.EmailTemplateRequest_Header != null)
            {
                context.EmailTemplateRequest_Header = new List<Amazon.Pinpoint.Model.MessageHeader>(this.EmailTemplateRequest_Header);
            }
            context.EmailTemplateRequest_HtmlPart = this.EmailTemplateRequest_HtmlPart;
            context.EmailTemplateRequest_RecommenderId = this.EmailTemplateRequest_RecommenderId;
            context.EmailTemplateRequest_Subject = this.EmailTemplateRequest_Subject;
            if (this.EmailTemplateRequest_Tag != null)
            {
                context.EmailTemplateRequest_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.EmailTemplateRequest_Tag.Keys)
                {
                    context.EmailTemplateRequest_Tag.Add((String)hashKey, (System.String)(this.EmailTemplateRequest_Tag[hashKey]));
                }
            }
            context.EmailTemplateRequest_TemplateDescription = this.EmailTemplateRequest_TemplateDescription;
            context.EmailTemplateRequest_TextPart = this.EmailTemplateRequest_TextPart;
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pinpoint.Model.CreateEmailTemplateRequest();
            
            
             // populate EmailTemplateRequest
            var requestEmailTemplateRequestIsNull = true;
            request.EmailTemplateRequest = new Amazon.Pinpoint.Model.EmailTemplateRequest();
            System.String requestEmailTemplateRequest_emailTemplateRequest_DefaultSubstitution = null;
            if (cmdletContext.EmailTemplateRequest_DefaultSubstitution != null)
            {
                requestEmailTemplateRequest_emailTemplateRequest_DefaultSubstitution = cmdletContext.EmailTemplateRequest_DefaultSubstitution;
            }
            if (requestEmailTemplateRequest_emailTemplateRequest_DefaultSubstitution != null)
            {
                request.EmailTemplateRequest.DefaultSubstitutions = requestEmailTemplateRequest_emailTemplateRequest_DefaultSubstitution;
                requestEmailTemplateRequestIsNull = false;
            }
            List<Amazon.Pinpoint.Model.MessageHeader> requestEmailTemplateRequest_emailTemplateRequest_Header = null;
            if (cmdletContext.EmailTemplateRequest_Header != null)
            {
                requestEmailTemplateRequest_emailTemplateRequest_Header = cmdletContext.EmailTemplateRequest_Header;
            }
            if (requestEmailTemplateRequest_emailTemplateRequest_Header != null)
            {
                request.EmailTemplateRequest.Headers = requestEmailTemplateRequest_emailTemplateRequest_Header;
                requestEmailTemplateRequestIsNull = false;
            }
            System.String requestEmailTemplateRequest_emailTemplateRequest_HtmlPart = null;
            if (cmdletContext.EmailTemplateRequest_HtmlPart != null)
            {
                requestEmailTemplateRequest_emailTemplateRequest_HtmlPart = cmdletContext.EmailTemplateRequest_HtmlPart;
            }
            if (requestEmailTemplateRequest_emailTemplateRequest_HtmlPart != null)
            {
                request.EmailTemplateRequest.HtmlPart = requestEmailTemplateRequest_emailTemplateRequest_HtmlPart;
                requestEmailTemplateRequestIsNull = false;
            }
            System.String requestEmailTemplateRequest_emailTemplateRequest_RecommenderId = null;
            if (cmdletContext.EmailTemplateRequest_RecommenderId != null)
            {
                requestEmailTemplateRequest_emailTemplateRequest_RecommenderId = cmdletContext.EmailTemplateRequest_RecommenderId;
            }
            if (requestEmailTemplateRequest_emailTemplateRequest_RecommenderId != null)
            {
                request.EmailTemplateRequest.RecommenderId = requestEmailTemplateRequest_emailTemplateRequest_RecommenderId;
                requestEmailTemplateRequestIsNull = false;
            }
            System.String requestEmailTemplateRequest_emailTemplateRequest_Subject = null;
            if (cmdletContext.EmailTemplateRequest_Subject != null)
            {
                requestEmailTemplateRequest_emailTemplateRequest_Subject = cmdletContext.EmailTemplateRequest_Subject;
            }
            if (requestEmailTemplateRequest_emailTemplateRequest_Subject != null)
            {
                request.EmailTemplateRequest.Subject = requestEmailTemplateRequest_emailTemplateRequest_Subject;
                requestEmailTemplateRequestIsNull = false;
            }
            Dictionary<System.String, System.String> requestEmailTemplateRequest_emailTemplateRequest_Tag = null;
            if (cmdletContext.EmailTemplateRequest_Tag != null)
            {
                requestEmailTemplateRequest_emailTemplateRequest_Tag = cmdletContext.EmailTemplateRequest_Tag;
            }
            if (requestEmailTemplateRequest_emailTemplateRequest_Tag != null)
            {
                request.EmailTemplateRequest.Tags = requestEmailTemplateRequest_emailTemplateRequest_Tag;
                requestEmailTemplateRequestIsNull = false;
            }
            System.String requestEmailTemplateRequest_emailTemplateRequest_TemplateDescription = null;
            if (cmdletContext.EmailTemplateRequest_TemplateDescription != null)
            {
                requestEmailTemplateRequest_emailTemplateRequest_TemplateDescription = cmdletContext.EmailTemplateRequest_TemplateDescription;
            }
            if (requestEmailTemplateRequest_emailTemplateRequest_TemplateDescription != null)
            {
                request.EmailTemplateRequest.TemplateDescription = requestEmailTemplateRequest_emailTemplateRequest_TemplateDescription;
                requestEmailTemplateRequestIsNull = false;
            }
            System.String requestEmailTemplateRequest_emailTemplateRequest_TextPart = null;
            if (cmdletContext.EmailTemplateRequest_TextPart != null)
            {
                requestEmailTemplateRequest_emailTemplateRequest_TextPart = cmdletContext.EmailTemplateRequest_TextPart;
            }
            if (requestEmailTemplateRequest_emailTemplateRequest_TextPart != null)
            {
                request.EmailTemplateRequest.TextPart = requestEmailTemplateRequest_emailTemplateRequest_TextPart;
                requestEmailTemplateRequestIsNull = false;
            }
             // determine if request.EmailTemplateRequest should be set to null
            if (requestEmailTemplateRequestIsNull)
            {
                request.EmailTemplateRequest = null;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
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
        
        private Amazon.Pinpoint.Model.CreateEmailTemplateResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.CreateEmailTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "CreateEmailTemplate");
            try
            {
                #if DESKTOP
                return client.CreateEmailTemplate(request);
                #elif CORECLR
                return client.CreateEmailTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.String EmailTemplateRequest_DefaultSubstitution { get; set; }
            public List<Amazon.Pinpoint.Model.MessageHeader> EmailTemplateRequest_Header { get; set; }
            public System.String EmailTemplateRequest_HtmlPart { get; set; }
            public System.String EmailTemplateRequest_RecommenderId { get; set; }
            public System.String EmailTemplateRequest_Subject { get; set; }
            public Dictionary<System.String, System.String> EmailTemplateRequest_Tag { get; set; }
            public System.String EmailTemplateRequest_TemplateDescription { get; set; }
            public System.String EmailTemplateRequest_TextPart { get; set; }
            public System.String TemplateName { get; set; }
            public System.Func<Amazon.Pinpoint.Model.CreateEmailTemplateResponse, NewPINEmailTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CreateTemplateMessageBody;
        }
        
    }
}
