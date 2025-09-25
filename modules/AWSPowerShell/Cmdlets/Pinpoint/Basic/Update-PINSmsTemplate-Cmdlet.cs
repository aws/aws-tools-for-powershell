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
    /// Updates an existing message template for messages that are sent through the SMS channel.
    /// </summary>
    [Cmdlet("Update", "PINSmsTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateSmsTemplate API operation.", Operation = new[] {"UpdateSmsTemplate"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateSmsTemplateResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageBody or Amazon.Pinpoint.Model.UpdateSmsTemplateResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.MessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateSmsTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINSmsTemplateCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SMSTemplateRequest_Body
        /// <summary>
        /// <para>
        /// <para>The message body to use in text messages that are based on the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SMSTemplateRequest_Body { get; set; }
        #endregion
        
        #region Parameter CreateNewVersion
        /// <summary>
        /// <para>
        /// <para>Specifies whether to save the updates as a new version of the message template. Valid
        /// values are: true, save the updates as a new version; and, false, save the updates
        /// to (overwrite) the latest existing version of the template.</para><para>If you don't specify a value for this parameter, Amazon Pinpoint saves the updates
        /// to (overwrites) the latest existing version of the template. If you specify a value
        /// of true for this parameter, don't specify a value for the version parameter. Otherwise,
        /// an error will occur.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CreateNewVersion { get; set; }
        #endregion
        
        #region Parameter SMSTemplateRequest_DefaultSubstitution
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
        [Alias("SMSTemplateRequest_DefaultSubstitutions")]
        public System.String SMSTemplateRequest_DefaultSubstitution { get; set; }
        #endregion
        
        #region Parameter SMSTemplateRequest_RecommenderId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the recommender model to use for the message template. Amazon
        /// Pinpoint uses this value to determine how to retrieve and process data from a recommender
        /// model when it sends messages that use the template, if the template contains message
        /// variables for recommendation data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SMSTemplateRequest_RecommenderId { get; set; }
        #endregion
        
        #region Parameter SMSTemplateRequest_Tag
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
        [Alias("SMSTemplateRequest_Tags")]
        public System.Collections.Hashtable SMSTemplateRequest_Tag { get; set; }
        #endregion
        
        #region Parameter SMSTemplateRequest_TemplateDescription
        /// <summary>
        /// <para>
        /// <para>A custom description of the message template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SMSTemplateRequest_TemplateDescription { get; set; }
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
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the version of the message template to update, retrieve
        /// information about, or delete. To retrieve identifiers and other information for all
        /// the versions of a template, use the <link linkend="templates-template-name-template-type-versions">Template
        /// Versions</link> resource.</para><para>If specified, this value must match the identifier for an existing template version.
        /// If specified for an update operation, this value must match the identifier for the
        /// latest existing version of the template. This restriction helps ensure that race conditions
        /// don't occur.</para><para>If you don't specify a value for this parameter, Amazon Pinpoint does the following:</para><ul><li><para>For a get operation, retrieves information about the active version of the template.</para></li><li><para>For an update operation, saves the updates to (overwrites) the latest existing version
        /// of the template, if the create-new-version parameter isn't used or is set to false.</para></li><li><para>For a delete operation, deletes the template, including all versions of the template.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MessageBody'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateSmsTemplateResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateSmsTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageBody";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TemplateName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TemplateName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TemplateName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINSmsTemplate (UpdateSmsTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateSmsTemplateResponse, UpdatePINSmsTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TemplateName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CreateNewVersion = this.CreateNewVersion;
            context.SMSTemplateRequest_Body = this.SMSTemplateRequest_Body;
            context.SMSTemplateRequest_DefaultSubstitution = this.SMSTemplateRequest_DefaultSubstitution;
            context.SMSTemplateRequest_RecommenderId = this.SMSTemplateRequest_RecommenderId;
            if (this.SMSTemplateRequest_Tag != null)
            {
                context.SMSTemplateRequest_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.SMSTemplateRequest_Tag.Keys)
                {
                    context.SMSTemplateRequest_Tag.Add((String)hashKey, (System.String)(this.SMSTemplateRequest_Tag[hashKey]));
                }
            }
            context.SMSTemplateRequest_TemplateDescription = this.SMSTemplateRequest_TemplateDescription;
            context.TemplateName = this.TemplateName;
            #if MODULAR
            if (this.TemplateName == null && ParameterWasBound(nameof(this.TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Version = this.Version;
            
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
            var request = new Amazon.Pinpoint.Model.UpdateSmsTemplateRequest();
            
            if (cmdletContext.CreateNewVersion != null)
            {
                request.CreateNewVersion = cmdletContext.CreateNewVersion.Value;
            }
            
             // populate SMSTemplateRequest
            var requestSMSTemplateRequestIsNull = true;
            request.SMSTemplateRequest = new Amazon.Pinpoint.Model.SMSTemplateRequest();
            System.String requestSMSTemplateRequest_sMSTemplateRequest_Body = null;
            if (cmdletContext.SMSTemplateRequest_Body != null)
            {
                requestSMSTemplateRequest_sMSTemplateRequest_Body = cmdletContext.SMSTemplateRequest_Body;
            }
            if (requestSMSTemplateRequest_sMSTemplateRequest_Body != null)
            {
                request.SMSTemplateRequest.Body = requestSMSTemplateRequest_sMSTemplateRequest_Body;
                requestSMSTemplateRequestIsNull = false;
            }
            System.String requestSMSTemplateRequest_sMSTemplateRequest_DefaultSubstitution = null;
            if (cmdletContext.SMSTemplateRequest_DefaultSubstitution != null)
            {
                requestSMSTemplateRequest_sMSTemplateRequest_DefaultSubstitution = cmdletContext.SMSTemplateRequest_DefaultSubstitution;
            }
            if (requestSMSTemplateRequest_sMSTemplateRequest_DefaultSubstitution != null)
            {
                request.SMSTemplateRequest.DefaultSubstitutions = requestSMSTemplateRequest_sMSTemplateRequest_DefaultSubstitution;
                requestSMSTemplateRequestIsNull = false;
            }
            System.String requestSMSTemplateRequest_sMSTemplateRequest_RecommenderId = null;
            if (cmdletContext.SMSTemplateRequest_RecommenderId != null)
            {
                requestSMSTemplateRequest_sMSTemplateRequest_RecommenderId = cmdletContext.SMSTemplateRequest_RecommenderId;
            }
            if (requestSMSTemplateRequest_sMSTemplateRequest_RecommenderId != null)
            {
                request.SMSTemplateRequest.RecommenderId = requestSMSTemplateRequest_sMSTemplateRequest_RecommenderId;
                requestSMSTemplateRequestIsNull = false;
            }
            Dictionary<System.String, System.String> requestSMSTemplateRequest_sMSTemplateRequest_Tag = null;
            if (cmdletContext.SMSTemplateRequest_Tag != null)
            {
                requestSMSTemplateRequest_sMSTemplateRequest_Tag = cmdletContext.SMSTemplateRequest_Tag;
            }
            if (requestSMSTemplateRequest_sMSTemplateRequest_Tag != null)
            {
                request.SMSTemplateRequest.Tags = requestSMSTemplateRequest_sMSTemplateRequest_Tag;
                requestSMSTemplateRequestIsNull = false;
            }
            System.String requestSMSTemplateRequest_sMSTemplateRequest_TemplateDescription = null;
            if (cmdletContext.SMSTemplateRequest_TemplateDescription != null)
            {
                requestSMSTemplateRequest_sMSTemplateRequest_TemplateDescription = cmdletContext.SMSTemplateRequest_TemplateDescription;
            }
            if (requestSMSTemplateRequest_sMSTemplateRequest_TemplateDescription != null)
            {
                request.SMSTemplateRequest.TemplateDescription = requestSMSTemplateRequest_sMSTemplateRequest_TemplateDescription;
                requestSMSTemplateRequestIsNull = false;
            }
             // determine if request.SMSTemplateRequest should be set to null
            if (requestSMSTemplateRequestIsNull)
            {
                request.SMSTemplateRequest = null;
            }
            if (cmdletContext.TemplateName != null)
            {
                request.TemplateName = cmdletContext.TemplateName;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.Pinpoint.Model.UpdateSmsTemplateResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateSmsTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateSmsTemplate");
            try
            {
                #if DESKTOP
                return client.UpdateSmsTemplate(request);
                #elif CORECLR
                return client.UpdateSmsTemplateAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CreateNewVersion { get; set; }
            public System.String SMSTemplateRequest_Body { get; set; }
            public System.String SMSTemplateRequest_DefaultSubstitution { get; set; }
            public System.String SMSTemplateRequest_RecommenderId { get; set; }
            public Dictionary<System.String, System.String> SMSTemplateRequest_Tag { get; set; }
            public System.String SMSTemplateRequest_TemplateDescription { get; set; }
            public System.String TemplateName { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateSmsTemplateResponse, UpdatePINSmsTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageBody;
        }
        
    }
}
