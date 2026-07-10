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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates the properties of an existing knowledge base.
    /// </summary>
    [Cmdlet("Update", "QSKnowledgeBase", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateKnowledgeBase API operation.", Operation = new[] {"UpdateKnowledgeBase"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse object containing multiple properties."
    )]
    public partial class UpdateQSKnowledgeBaseCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus
        /// <summary>
        /// <para>
        /// <para>The status of audio extraction. Valid values are ENABLED and DISABLED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.AudioExtractionStatus")]
        public Amazon.QuickSight.AudioExtractionStatus MediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the knowledge base.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the knowledge base. If you don't specify a description, the existing
        /// description is retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus
        /// <summary>
        /// <para>
        /// <para>The status of image extraction. Valid values are ENABLED and DISABLED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.ImageExtractionStatus")]
        public Amazon.QuickSight.ImageExtractionStatus MediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus { get; set; }
        #endregion
        
        #region Parameter AccessControlConfiguration_IsACLEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether ACLs are enabled for the knowledge base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AccessControlConfiguration_IsACLEnabled { get; set; }
        #endregion
        
        #region Parameter IsEmailNotificationOptedForIngestionFailure
        /// <summary>
        /// <para>
        /// <para>Specifies whether email notifications are enabled for ingestion failures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IsEmailNotificationOptedForIngestionFailures")]
        public System.Boolean? IsEmailNotificationOptedForIngestionFailure { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the knowledge base.</para>
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the knowledge base. If you don't specify a name, the existing name is
        /// retained.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter KnowledgeBaseConfiguration_TemplateConfiguration_Template
        /// <summary>
        /// <para>
        /// <para>The template document that defines the knowledge base behavior.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject KnowledgeBaseConfiguration_TemplateConfiguration_Template { get; set; }
        #endregion
        
        #region Parameter MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus
        /// <summary>
        /// <para>
        /// <para>The status of video extraction. Valid values are ENABLED and DISABLED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.VideoExtractionStatus")]
        public Amazon.QuickSight.VideoExtractionStatus MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus { get; set; }
        #endregion
        
        #region Parameter MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType
        /// <summary>
        /// <para>
        /// <para>The type of video extraction to perform.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.VideoExtractionType")]
        public Amazon.QuickSight.VideoExtractionType MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KnowledgeBaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSKnowledgeBase (UpdateKnowledgeBase)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse, UpdateQSKnowledgeBaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessControlConfiguration_IsACLEnabled = this.AccessControlConfiguration_IsACLEnabled;
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.IsEmailNotificationOptedForIngestionFailure = this.IsEmailNotificationOptedForIngestionFailure;
            context.KnowledgeBaseConfiguration_TemplateConfiguration_Template = this.KnowledgeBaseConfiguration_TemplateConfiguration_Template;
            context.KnowledgeBaseId = this.KnowledgeBaseId;
            #if MODULAR
            if (this.KnowledgeBaseId == null && ParameterWasBound(nameof(this.KnowledgeBaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter KnowledgeBaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus = this.MediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus;
            context.MediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus = this.MediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus;
            context.MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus = this.MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus;
            context.MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType = this.MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType;
            context.Name = this.Name;
            
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
            var request = new Amazon.QuickSight.Model.UpdateKnowledgeBaseRequest();
            
            
             // populate AccessControlConfiguration
            var requestAccessControlConfigurationIsNull = true;
            request.AccessControlConfiguration = new Amazon.QuickSight.Model.AccessControlConfiguration();
            System.Boolean? requestAccessControlConfiguration_accessControlConfiguration_IsACLEnabled = null;
            if (cmdletContext.AccessControlConfiguration_IsACLEnabled != null)
            {
                requestAccessControlConfiguration_accessControlConfiguration_IsACLEnabled = cmdletContext.AccessControlConfiguration_IsACLEnabled.Value;
            }
            if (requestAccessControlConfiguration_accessControlConfiguration_IsACLEnabled != null)
            {
                request.AccessControlConfiguration.IsACLEnabled = requestAccessControlConfiguration_accessControlConfiguration_IsACLEnabled.Value;
                requestAccessControlConfigurationIsNull = false;
            }
             // determine if request.AccessControlConfiguration should be set to null
            if (requestAccessControlConfigurationIsNull)
            {
                request.AccessControlConfiguration = null;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IsEmailNotificationOptedForIngestionFailure != null)
            {
                request.IsEmailNotificationOptedForIngestionFailures = cmdletContext.IsEmailNotificationOptedForIngestionFailure.Value;
            }
            
             // populate KnowledgeBaseConfiguration
            var requestKnowledgeBaseConfigurationIsNull = true;
            request.KnowledgeBaseConfiguration = new Amazon.QuickSight.Model.KnowledgeBaseConfiguration();
            Amazon.QuickSight.Model.KbTemplateConfiguration requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration = null;
            
             // populate TemplateConfiguration
            var requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfigurationIsNull = true;
            requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration = new Amazon.QuickSight.Model.KbTemplateConfiguration();
            Amazon.Runtime.Documents.Document? requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration_knowledgeBaseConfiguration_TemplateConfiguration_Template = null;
            if (cmdletContext.KnowledgeBaseConfiguration_TemplateConfiguration_Template != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration_knowledgeBaseConfiguration_TemplateConfiguration_Template = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.KnowledgeBaseConfiguration_TemplateConfiguration_Template);
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration_knowledgeBaseConfiguration_TemplateConfiguration_Template != null)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration.Template = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration_knowledgeBaseConfiguration_TemplateConfiguration_Template.Value;
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfigurationIsNull = false;
            }
             // determine if requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration should be set to null
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfigurationIsNull)
            {
                requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration = null;
            }
            if (requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration != null)
            {
                request.KnowledgeBaseConfiguration.TemplateConfiguration = requestKnowledgeBaseConfiguration_knowledgeBaseConfiguration_TemplateConfiguration;
                requestKnowledgeBaseConfigurationIsNull = false;
            }
             // determine if request.KnowledgeBaseConfiguration should be set to null
            if (requestKnowledgeBaseConfigurationIsNull)
            {
                request.KnowledgeBaseConfiguration = null;
            }
            if (cmdletContext.KnowledgeBaseId != null)
            {
                request.KnowledgeBaseId = cmdletContext.KnowledgeBaseId;
            }
            
             // populate MediaExtractionConfiguration
            var requestMediaExtractionConfigurationIsNull = true;
            request.MediaExtractionConfiguration = new Amazon.QuickSight.Model.MediaExtractionConfiguration();
            Amazon.QuickSight.Model.AudioExtractionConfiguration requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration = null;
            
             // populate AudioExtractionConfiguration
            var requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfigurationIsNull = true;
            requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration = new Amazon.QuickSight.Model.AudioExtractionConfiguration();
            Amazon.QuickSight.AudioExtractionStatus requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus = null;
            if (cmdletContext.MediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus = cmdletContext.MediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration.AudioExtractionStatus = requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus;
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfigurationIsNull = false;
            }
             // determine if requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration should be set to null
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfigurationIsNull)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration = null;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration != null)
            {
                request.MediaExtractionConfiguration.AudioExtractionConfiguration = requestMediaExtractionConfiguration_mediaExtractionConfiguration_AudioExtractionConfiguration;
                requestMediaExtractionConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.ImageExtractionConfiguration requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration = null;
            
             // populate ImageExtractionConfiguration
            var requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfigurationIsNull = true;
            requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration = new Amazon.QuickSight.Model.ImageExtractionConfiguration();
            Amazon.QuickSight.ImageExtractionStatus requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus = null;
            if (cmdletContext.MediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus = cmdletContext.MediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration.ImageExtractionStatus = requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus;
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfigurationIsNull = false;
            }
             // determine if requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration should be set to null
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfigurationIsNull)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration = null;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration != null)
            {
                request.MediaExtractionConfiguration.ImageExtractionConfiguration = requestMediaExtractionConfiguration_mediaExtractionConfiguration_ImageExtractionConfiguration;
                requestMediaExtractionConfigurationIsNull = false;
            }
            Amazon.QuickSight.Model.VideoExtractionConfiguration requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration = null;
            
             // populate VideoExtractionConfiguration
            var requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfigurationIsNull = true;
            requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration = new Amazon.QuickSight.Model.VideoExtractionConfiguration();
            Amazon.QuickSight.VideoExtractionStatus requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus = null;
            if (cmdletContext.MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus = cmdletContext.MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration.VideoExtractionStatus = requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus;
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfigurationIsNull = false;
            }
            Amazon.QuickSight.VideoExtractionType requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType = null;
            if (cmdletContext.MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType = cmdletContext.MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType != null)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration.VideoExtractionType = requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType;
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfigurationIsNull = false;
            }
             // determine if requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration should be set to null
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfigurationIsNull)
            {
                requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration = null;
            }
            if (requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration != null)
            {
                request.MediaExtractionConfiguration.VideoExtractionConfiguration = requestMediaExtractionConfiguration_mediaExtractionConfiguration_VideoExtractionConfiguration;
                requestMediaExtractionConfigurationIsNull = false;
            }
             // determine if request.MediaExtractionConfiguration should be set to null
            if (requestMediaExtractionConfigurationIsNull)
            {
                request.MediaExtractionConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateKnowledgeBaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateKnowledgeBase");
            try
            {
                return client.UpdateKnowledgeBaseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AccessControlConfiguration_IsACLEnabled { get; set; }
            public System.String AwsAccountId { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? IsEmailNotificationOptedForIngestionFailure { get; set; }
            public System.Management.Automation.PSObject KnowledgeBaseConfiguration_TemplateConfiguration_Template { get; set; }
            public System.String KnowledgeBaseId { get; set; }
            public Amazon.QuickSight.AudioExtractionStatus MediaExtractionConfiguration_AudioExtractionConfiguration_AudioExtractionStatus { get; set; }
            public Amazon.QuickSight.ImageExtractionStatus MediaExtractionConfiguration_ImageExtractionConfiguration_ImageExtractionStatus { get; set; }
            public Amazon.QuickSight.VideoExtractionStatus MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionStatus { get; set; }
            public Amazon.QuickSight.VideoExtractionType MediaExtractionConfiguration_VideoExtractionConfiguration_VideoExtractionType { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateKnowledgeBaseResponse, UpdateQSKnowledgeBaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
