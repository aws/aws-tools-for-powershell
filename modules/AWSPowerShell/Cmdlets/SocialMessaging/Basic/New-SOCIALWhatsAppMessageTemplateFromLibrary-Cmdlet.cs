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
using Amazon.SocialMessaging;
using Amazon.SocialMessaging.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SOCIAL
{
    /// <summary>
    /// Creates a new WhatsApp message template using a template from Meta's template library.
    /// </summary>
    [Cmdlet("New", "SOCIALWhatsAppMessageTemplateFromLibrary", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse")]
    [AWSCmdlet("Calls the AWS End User Messaging Social CreateWhatsAppMessageTemplateFromLibrary API operation.", Operation = new[] {"CreateWhatsAppMessageTemplateFromLibrary"}, SelectReturnType = typeof(Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse))]
    [AWSCmdletOutput("Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse",
        "This cmdlet returns an Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse object containing multiple properties."
    )]
    public partial class NewSOCIALWhatsAppMessageTemplateFromLibraryCmdlet : AmazonSocialMessagingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LibraryTemplateBodyInputs_AddContactNumber
        /// <summary>
        /// <para>
        /// <para>When true, includes a contact number in the template body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetaLibraryTemplate_LibraryTemplateBodyInputs_AddContactNumber")]
        public System.Boolean? LibraryTemplateBodyInputs_AddContactNumber { get; set; }
        #endregion
        
        #region Parameter LibraryTemplateBodyInputs_AddLearnMoreLink
        /// <summary>
        /// <para>
        /// <para>When true, includes a "learn more" link in the template body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetaLibraryTemplate_LibraryTemplateBodyInputs_AddLearnMoreLink")]
        public System.Boolean? LibraryTemplateBodyInputs_AddLearnMoreLink { get; set; }
        #endregion
        
        #region Parameter LibraryTemplateBodyInputs_AddSecurityRecommendation
        /// <summary>
        /// <para>
        /// <para>When true, includes security recommendations in the template body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetaLibraryTemplate_LibraryTemplateBodyInputs_AddSecurityRecommendation")]
        public System.Boolean? LibraryTemplateBodyInputs_AddSecurityRecommendation { get; set; }
        #endregion
        
        #region Parameter LibraryTemplateBodyInputs_AddTrackPackageLink
        /// <summary>
        /// <para>
        /// <para>When true, includes a package tracking link in the template body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetaLibraryTemplate_LibraryTemplateBodyInputs_AddTrackPackageLink")]
        public System.Boolean? LibraryTemplateBodyInputs_AddTrackPackageLink { get; set; }
        #endregion
        
        #region Parameter LibraryTemplateBodyInputs_CodeExpirationMinute
        /// <summary>
        /// <para>
        /// <para>The number of minutes until a verification code or OTP expires.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetaLibraryTemplate_LibraryTemplateBodyInputs_CodeExpirationMinutes")]
        public System.Int32? LibraryTemplateBodyInputs_CodeExpirationMinute { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The ID of the WhatsApp Business Account to associate with this template.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter MetaLibraryTemplate_LibraryTemplateButtonInput
        /// <summary>
        /// <para>
        /// <para>Button customizations for the template.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MetaLibraryTemplate_LibraryTemplateButtonInputs")]
        public Amazon.SocialMessaging.Model.LibraryTemplateButtonInput[] MetaLibraryTemplate_LibraryTemplateButtonInput { get; set; }
        #endregion
        
        #region Parameter MetaLibraryTemplate_LibraryTemplateName
        /// <summary>
        /// <para>
        /// <para>The name of the template in Meta's library.</para>
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
        public System.String MetaLibraryTemplate_LibraryTemplateName { get; set; }
        #endregion
        
        #region Parameter MetaLibraryTemplate_TemplateCategory
        /// <summary>
        /// <para>
        /// <para>The category of the template (for example, UTILITY or MARKETING).</para>
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
        public System.String MetaLibraryTemplate_TemplateCategory { get; set; }
        #endregion
        
        #region Parameter MetaLibraryTemplate_TemplateLanguage
        /// <summary>
        /// <para>
        /// <para>The language code for the template (for example, en_US).</para>
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
        public System.String MetaLibraryTemplate_TemplateLanguage { get; set; }
        #endregion
        
        #region Parameter MetaLibraryTemplate_TemplateName
        /// <summary>
        /// <para>
        /// <para>The name to assign to the template.</para>
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
        public System.String MetaLibraryTemplate_TemplateName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse).
        /// Specifying the name of a property of type Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SOCIALWhatsAppMessageTemplateFromLibrary (CreateWhatsAppMessageTemplateFromLibrary)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse, NewSOCIALWhatsAppMessageTemplateFromLibraryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LibraryTemplateBodyInputs_AddContactNumber = this.LibraryTemplateBodyInputs_AddContactNumber;
            context.LibraryTemplateBodyInputs_AddLearnMoreLink = this.LibraryTemplateBodyInputs_AddLearnMoreLink;
            context.LibraryTemplateBodyInputs_AddSecurityRecommendation = this.LibraryTemplateBodyInputs_AddSecurityRecommendation;
            context.LibraryTemplateBodyInputs_AddTrackPackageLink = this.LibraryTemplateBodyInputs_AddTrackPackageLink;
            context.LibraryTemplateBodyInputs_CodeExpirationMinute = this.LibraryTemplateBodyInputs_CodeExpirationMinute;
            if (this.MetaLibraryTemplate_LibraryTemplateButtonInput != null)
            {
                context.MetaLibraryTemplate_LibraryTemplateButtonInput = new List<Amazon.SocialMessaging.Model.LibraryTemplateButtonInput>(this.MetaLibraryTemplate_LibraryTemplateButtonInput);
            }
            context.MetaLibraryTemplate_LibraryTemplateName = this.MetaLibraryTemplate_LibraryTemplateName;
            #if MODULAR
            if (this.MetaLibraryTemplate_LibraryTemplateName == null && ParameterWasBound(nameof(this.MetaLibraryTemplate_LibraryTemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetaLibraryTemplate_LibraryTemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetaLibraryTemplate_TemplateCategory = this.MetaLibraryTemplate_TemplateCategory;
            #if MODULAR
            if (this.MetaLibraryTemplate_TemplateCategory == null && ParameterWasBound(nameof(this.MetaLibraryTemplate_TemplateCategory)))
            {
                WriteWarning("You are passing $null as a value for parameter MetaLibraryTemplate_TemplateCategory which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetaLibraryTemplate_TemplateLanguage = this.MetaLibraryTemplate_TemplateLanguage;
            #if MODULAR
            if (this.MetaLibraryTemplate_TemplateLanguage == null && ParameterWasBound(nameof(this.MetaLibraryTemplate_TemplateLanguage)))
            {
                WriteWarning("You are passing $null as a value for parameter MetaLibraryTemplate_TemplateLanguage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MetaLibraryTemplate_TemplateName = this.MetaLibraryTemplate_TemplateName;
            #if MODULAR
            if (this.MetaLibraryTemplate_TemplateName == null && ParameterWasBound(nameof(this.MetaLibraryTemplate_TemplateName)))
            {
                WriteWarning("You are passing $null as a value for parameter MetaLibraryTemplate_TemplateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryRequest();
            
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate MetaLibraryTemplate
            var requestMetaLibraryTemplateIsNull = true;
            request.MetaLibraryTemplate = new Amazon.SocialMessaging.Model.MetaLibraryTemplate();
            List<Amazon.SocialMessaging.Model.LibraryTemplateButtonInput> requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateButtonInput = null;
            if (cmdletContext.MetaLibraryTemplate_LibraryTemplateButtonInput != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateButtonInput = cmdletContext.MetaLibraryTemplate_LibraryTemplateButtonInput;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateButtonInput != null)
            {
                request.MetaLibraryTemplate.LibraryTemplateButtonInputs = requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateButtonInput;
                requestMetaLibraryTemplateIsNull = false;
            }
            System.String requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateName = null;
            if (cmdletContext.MetaLibraryTemplate_LibraryTemplateName != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateName = cmdletContext.MetaLibraryTemplate_LibraryTemplateName;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateName != null)
            {
                request.MetaLibraryTemplate.LibraryTemplateName = requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateName;
                requestMetaLibraryTemplateIsNull = false;
            }
            System.String requestMetaLibraryTemplate_metaLibraryTemplate_TemplateCategory = null;
            if (cmdletContext.MetaLibraryTemplate_TemplateCategory != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_TemplateCategory = cmdletContext.MetaLibraryTemplate_TemplateCategory;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_TemplateCategory != null)
            {
                request.MetaLibraryTemplate.TemplateCategory = requestMetaLibraryTemplate_metaLibraryTemplate_TemplateCategory;
                requestMetaLibraryTemplateIsNull = false;
            }
            System.String requestMetaLibraryTemplate_metaLibraryTemplate_TemplateLanguage = null;
            if (cmdletContext.MetaLibraryTemplate_TemplateLanguage != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_TemplateLanguage = cmdletContext.MetaLibraryTemplate_TemplateLanguage;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_TemplateLanguage != null)
            {
                request.MetaLibraryTemplate.TemplateLanguage = requestMetaLibraryTemplate_metaLibraryTemplate_TemplateLanguage;
                requestMetaLibraryTemplateIsNull = false;
            }
            System.String requestMetaLibraryTemplate_metaLibraryTemplate_TemplateName = null;
            if (cmdletContext.MetaLibraryTemplate_TemplateName != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_TemplateName = cmdletContext.MetaLibraryTemplate_TemplateName;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_TemplateName != null)
            {
                request.MetaLibraryTemplate.TemplateName = requestMetaLibraryTemplate_metaLibraryTemplate_TemplateName;
                requestMetaLibraryTemplateIsNull = false;
            }
            Amazon.SocialMessaging.Model.LibraryTemplateBodyInputs requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs = null;
            
             // populate LibraryTemplateBodyInputs
            var requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputsIsNull = true;
            requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs = new Amazon.SocialMessaging.Model.LibraryTemplateBodyInputs();
            System.Boolean? requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddContactNumber = null;
            if (cmdletContext.LibraryTemplateBodyInputs_AddContactNumber != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddContactNumber = cmdletContext.LibraryTemplateBodyInputs_AddContactNumber.Value;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddContactNumber != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs.AddContactNumber = requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddContactNumber.Value;
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputsIsNull = false;
            }
            System.Boolean? requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddLearnMoreLink = null;
            if (cmdletContext.LibraryTemplateBodyInputs_AddLearnMoreLink != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddLearnMoreLink = cmdletContext.LibraryTemplateBodyInputs_AddLearnMoreLink.Value;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddLearnMoreLink != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs.AddLearnMoreLink = requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddLearnMoreLink.Value;
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputsIsNull = false;
            }
            System.Boolean? requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddSecurityRecommendation = null;
            if (cmdletContext.LibraryTemplateBodyInputs_AddSecurityRecommendation != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddSecurityRecommendation = cmdletContext.LibraryTemplateBodyInputs_AddSecurityRecommendation.Value;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddSecurityRecommendation != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs.AddSecurityRecommendation = requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddSecurityRecommendation.Value;
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputsIsNull = false;
            }
            System.Boolean? requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddTrackPackageLink = null;
            if (cmdletContext.LibraryTemplateBodyInputs_AddTrackPackageLink != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddTrackPackageLink = cmdletContext.LibraryTemplateBodyInputs_AddTrackPackageLink.Value;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddTrackPackageLink != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs.AddTrackPackageLink = requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_AddTrackPackageLink.Value;
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputsIsNull = false;
            }
            System.Int32? requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_CodeExpirationMinute = null;
            if (cmdletContext.LibraryTemplateBodyInputs_CodeExpirationMinute != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_CodeExpirationMinute = cmdletContext.LibraryTemplateBodyInputs_CodeExpirationMinute.Value;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_CodeExpirationMinute != null)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs.CodeExpirationMinutes = requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs_libraryTemplateBodyInputs_CodeExpirationMinute.Value;
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputsIsNull = false;
            }
             // determine if requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs should be set to null
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputsIsNull)
            {
                requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs = null;
            }
            if (requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs != null)
            {
                request.MetaLibraryTemplate.LibraryTemplateBodyInputs = requestMetaLibraryTemplate_metaLibraryTemplate_LibraryTemplateBodyInputs;
                requestMetaLibraryTemplateIsNull = false;
            }
             // determine if request.MetaLibraryTemplate should be set to null
            if (requestMetaLibraryTemplateIsNull)
            {
                request.MetaLibraryTemplate = null;
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
        
        private Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse CallAWSServiceOperation(IAmazonSocialMessaging client, Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS End User Messaging Social", "CreateWhatsAppMessageTemplateFromLibrary");
            try
            {
                return client.CreateWhatsAppMessageTemplateFromLibraryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Id { get; set; }
            public System.Boolean? LibraryTemplateBodyInputs_AddContactNumber { get; set; }
            public System.Boolean? LibraryTemplateBodyInputs_AddLearnMoreLink { get; set; }
            public System.Boolean? LibraryTemplateBodyInputs_AddSecurityRecommendation { get; set; }
            public System.Boolean? LibraryTemplateBodyInputs_AddTrackPackageLink { get; set; }
            public System.Int32? LibraryTemplateBodyInputs_CodeExpirationMinute { get; set; }
            public List<Amazon.SocialMessaging.Model.LibraryTemplateButtonInput> MetaLibraryTemplate_LibraryTemplateButtonInput { get; set; }
            public System.String MetaLibraryTemplate_LibraryTemplateName { get; set; }
            public System.String MetaLibraryTemplate_TemplateCategory { get; set; }
            public System.String MetaLibraryTemplate_TemplateLanguage { get; set; }
            public System.String MetaLibraryTemplate_TemplateName { get; set; }
            public System.Func<Amazon.SocialMessaging.Model.CreateWhatsAppMessageTemplateFromLibraryResponse, NewSOCIALWhatsAppMessageTemplateFromLibraryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
