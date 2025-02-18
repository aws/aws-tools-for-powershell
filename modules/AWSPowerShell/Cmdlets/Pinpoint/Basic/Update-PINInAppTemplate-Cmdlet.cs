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

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Updates an existing message template for messages sent through the in-app message
    /// channel.
    /// </summary>
    [Cmdlet("Update", "PINInAppTemplate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.MessageBody")]
    [AWSCmdlet("Calls the Amazon Pinpoint UpdateInAppTemplate API operation.", Operation = new[] {"UpdateInAppTemplate"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.UpdateInAppTemplateResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.MessageBody or Amazon.Pinpoint.Model.UpdateInAppTemplateResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.MessageBody object.",
        "The service call response (type Amazon.Pinpoint.Model.UpdateInAppTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePINInAppTemplateCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InAppTemplateRequest_Content
        /// <summary>
        /// <para>
        /// <para>The content of the message, can include up to 5 modals. Each modal must contain a
        /// message, a header, and background color. ImageUrl and buttons are optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Pinpoint.Model.InAppMessageContent[] InAppTemplateRequest_Content { get; set; }
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
        
        #region Parameter InAppTemplateRequest_CustomConfig
        /// <summary>
        /// <para>
        /// <para>Custom config to be sent to client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable InAppTemplateRequest_CustomConfig { get; set; }
        #endregion
        
        #region Parameter InAppTemplateRequest_Layout
        /// <summary>
        /// <para>
        /// <para>The layout of the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Pinpoint.Layout")]
        public Amazon.Pinpoint.Layout InAppTemplateRequest_Layout { get; set; }
        #endregion
        
        #region Parameter InAppTemplateRequest_Tag
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
        [Alias("InAppTemplateRequest_Tags")]
        public System.Collections.Hashtable InAppTemplateRequest_Tag { get; set; }
        #endregion
        
        #region Parameter InAppTemplateRequest_TemplateDescription
        /// <summary>
        /// <para>
        /// <para>The description of the template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InAppTemplateRequest_TemplateDescription { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.UpdateInAppTemplateResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.UpdateInAppTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MessageBody";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TemplateName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PINInAppTemplate (UpdateInAppTemplate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.UpdateInAppTemplateResponse, UpdatePINInAppTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreateNewVersion = this.CreateNewVersion;
            if (this.InAppTemplateRequest_Content != null)
            {
                context.InAppTemplateRequest_Content = new List<Amazon.Pinpoint.Model.InAppMessageContent>(this.InAppTemplateRequest_Content);
            }
            if (this.InAppTemplateRequest_CustomConfig != null)
            {
                context.InAppTemplateRequest_CustomConfig = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InAppTemplateRequest_CustomConfig.Keys)
                {
                    context.InAppTemplateRequest_CustomConfig.Add((String)hashKey, (System.String)(this.InAppTemplateRequest_CustomConfig[hashKey]));
                }
            }
            context.InAppTemplateRequest_Layout = this.InAppTemplateRequest_Layout;
            if (this.InAppTemplateRequest_Tag != null)
            {
                context.InAppTemplateRequest_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.InAppTemplateRequest_Tag.Keys)
                {
                    context.InAppTemplateRequest_Tag.Add((String)hashKey, (System.String)(this.InAppTemplateRequest_Tag[hashKey]));
                }
            }
            context.InAppTemplateRequest_TemplateDescription = this.InAppTemplateRequest_TemplateDescription;
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
            var request = new Amazon.Pinpoint.Model.UpdateInAppTemplateRequest();
            
            if (cmdletContext.CreateNewVersion != null)
            {
                request.CreateNewVersion = cmdletContext.CreateNewVersion.Value;
            }
            
             // populate InAppTemplateRequest
            var requestInAppTemplateRequestIsNull = true;
            request.InAppTemplateRequest = new Amazon.Pinpoint.Model.InAppTemplateRequest();
            List<Amazon.Pinpoint.Model.InAppMessageContent> requestInAppTemplateRequest_inAppTemplateRequest_Content = null;
            if (cmdletContext.InAppTemplateRequest_Content != null)
            {
                requestInAppTemplateRequest_inAppTemplateRequest_Content = cmdletContext.InAppTemplateRequest_Content;
            }
            if (requestInAppTemplateRequest_inAppTemplateRequest_Content != null)
            {
                request.InAppTemplateRequest.Content = requestInAppTemplateRequest_inAppTemplateRequest_Content;
                requestInAppTemplateRequestIsNull = false;
            }
            Dictionary<System.String, System.String> requestInAppTemplateRequest_inAppTemplateRequest_CustomConfig = null;
            if (cmdletContext.InAppTemplateRequest_CustomConfig != null)
            {
                requestInAppTemplateRequest_inAppTemplateRequest_CustomConfig = cmdletContext.InAppTemplateRequest_CustomConfig;
            }
            if (requestInAppTemplateRequest_inAppTemplateRequest_CustomConfig != null)
            {
                request.InAppTemplateRequest.CustomConfig = requestInAppTemplateRequest_inAppTemplateRequest_CustomConfig;
                requestInAppTemplateRequestIsNull = false;
            }
            Amazon.Pinpoint.Layout requestInAppTemplateRequest_inAppTemplateRequest_Layout = null;
            if (cmdletContext.InAppTemplateRequest_Layout != null)
            {
                requestInAppTemplateRequest_inAppTemplateRequest_Layout = cmdletContext.InAppTemplateRequest_Layout;
            }
            if (requestInAppTemplateRequest_inAppTemplateRequest_Layout != null)
            {
                request.InAppTemplateRequest.Layout = requestInAppTemplateRequest_inAppTemplateRequest_Layout;
                requestInAppTemplateRequestIsNull = false;
            }
            Dictionary<System.String, System.String> requestInAppTemplateRequest_inAppTemplateRequest_Tag = null;
            if (cmdletContext.InAppTemplateRequest_Tag != null)
            {
                requestInAppTemplateRequest_inAppTemplateRequest_Tag = cmdletContext.InAppTemplateRequest_Tag;
            }
            if (requestInAppTemplateRequest_inAppTemplateRequest_Tag != null)
            {
                request.InAppTemplateRequest.Tags = requestInAppTemplateRequest_inAppTemplateRequest_Tag;
                requestInAppTemplateRequestIsNull = false;
            }
            System.String requestInAppTemplateRequest_inAppTemplateRequest_TemplateDescription = null;
            if (cmdletContext.InAppTemplateRequest_TemplateDescription != null)
            {
                requestInAppTemplateRequest_inAppTemplateRequest_TemplateDescription = cmdletContext.InAppTemplateRequest_TemplateDescription;
            }
            if (requestInAppTemplateRequest_inAppTemplateRequest_TemplateDescription != null)
            {
                request.InAppTemplateRequest.TemplateDescription = requestInAppTemplateRequest_inAppTemplateRequest_TemplateDescription;
                requestInAppTemplateRequestIsNull = false;
            }
             // determine if request.InAppTemplateRequest should be set to null
            if (requestInAppTemplateRequestIsNull)
            {
                request.InAppTemplateRequest = null;
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
        
        private Amazon.Pinpoint.Model.UpdateInAppTemplateResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.UpdateInAppTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "UpdateInAppTemplate");
            try
            {
                return client.UpdateInAppTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Pinpoint.Model.InAppMessageContent> InAppTemplateRequest_Content { get; set; }
            public Dictionary<System.String, System.String> InAppTemplateRequest_CustomConfig { get; set; }
            public Amazon.Pinpoint.Layout InAppTemplateRequest_Layout { get; set; }
            public Dictionary<System.String, System.String> InAppTemplateRequest_Tag { get; set; }
            public System.String InAppTemplateRequest_TemplateDescription { get; set; }
            public System.String TemplateName { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.Pinpoint.Model.UpdateInAppTemplateResponse, UpdatePINInAppTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MessageBody;
        }
        
    }
}
