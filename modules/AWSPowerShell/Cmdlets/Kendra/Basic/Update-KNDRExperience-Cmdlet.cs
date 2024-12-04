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
using Amazon.Kendra;
using Amazon.Kendra.Model;

namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Updates your Amazon Kendra experience such as a search application. For more information
    /// on creating a search application experience, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/deploying-search-experience-no-code.html">Building
    /// a search experience with no code</a>.
    /// </summary>
    [Cmdlet("Update", "KNDRExperience", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kendra UpdateExperience API operation.", Operation = new[] {"UpdateExperience"}, SelectReturnType = typeof(Amazon.Kendra.Model.UpdateExperienceResponse))]
    [AWSCmdletOutput("None or Amazon.Kendra.Model.UpdateExperienceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kendra.Model.UpdateExperienceResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKNDRExperienceCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContentSourceConfiguration_DataSourceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the data sources you want to use for your Amazon Kendra experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ContentSourceConfiguration_DataSourceIds")]
        public System.String[] ContentSourceConfiguration_DataSourceId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for your Amazon Kendra experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ContentSourceConfiguration_DirectPutContent
        /// <summary>
        /// <para>
        /// <para><c>TRUE</c> to use documents you indexed directly using the <c>BatchPutDocument</c>
        /// API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ContentSourceConfiguration_DirectPutContent")]
        public System.Boolean? ContentSourceConfiguration_DirectPutContent { get; set; }
        #endregion
        
        #region Parameter ContentSourceConfiguration_FaqId
        /// <summary>
        /// <para>
        /// <para>The identifier of the FAQs that you want to use for your Amazon Kendra experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ContentSourceConfiguration_FaqIds")]
        public System.String[] ContentSourceConfiguration_FaqId { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The identifier of your Amazon Kendra experience you want to update.</para>
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
        
        #region Parameter UserIdentityConfiguration_IdentityAttributeName
        /// <summary>
        /// <para>
        /// <para>The IAM Identity Center field name that contains the identifiers of your users, such
        /// as their emails. This is used for <a href="https://docs.aws.amazon.com/kendra/latest/dg/user-context-filter.html">user
        /// context filtering</a> and for granting access to your Amazon Kendra experience. You
        /// must set up IAM Identity Center with Amazon Kendra. You must include your users and
        /// groups in your Access Control List when you ingest documents into your index. For
        /// more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/getting-started-aws-sso.html">Getting
        /// started with an IAM Identity Center identity source</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_UserIdentityConfiguration_IdentityAttributeName")]
        public System.String UserIdentityConfiguration_IdentityAttributeName { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index for your Amazon Kendra experience.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A new name for your Amazon Kendra experience.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role with permission to access the <c>Query</c>
        /// API, <c>QuerySuggestions</c> API, <c>SubmitFeedback</c> API, and IAM Identity Center
        /// that stores your users and groups information. For more information, see <a href="https://docs.aws.amazon.com/kendra/latest/dg/iam-roles.html">IAM
        /// roles for Amazon Kendra</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.UpdateExperienceResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Id parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Id' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KNDRExperience (UpdateExperience)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.UpdateExperienceResponse, UpdateKNDRExperienceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Id;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ContentSourceConfiguration_DataSourceId != null)
            {
                context.ContentSourceConfiguration_DataSourceId = new List<System.String>(this.ContentSourceConfiguration_DataSourceId);
            }
            context.ContentSourceConfiguration_DirectPutContent = this.ContentSourceConfiguration_DirectPutContent;
            if (this.ContentSourceConfiguration_FaqId != null)
            {
                context.ContentSourceConfiguration_FaqId = new List<System.String>(this.ContentSourceConfiguration_FaqId);
            }
            context.UserIdentityConfiguration_IdentityAttributeName = this.UserIdentityConfiguration_IdentityAttributeName;
            context.Description = this.Description;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.Kendra.Model.UpdateExperienceRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Kendra.Model.ExperienceConfiguration();
            Amazon.Kendra.Model.UserIdentityConfiguration requestConfiguration_configuration_UserIdentityConfiguration = null;
            
             // populate UserIdentityConfiguration
            var requestConfiguration_configuration_UserIdentityConfigurationIsNull = true;
            requestConfiguration_configuration_UserIdentityConfiguration = new Amazon.Kendra.Model.UserIdentityConfiguration();
            System.String requestConfiguration_configuration_UserIdentityConfiguration_userIdentityConfiguration_IdentityAttributeName = null;
            if (cmdletContext.UserIdentityConfiguration_IdentityAttributeName != null)
            {
                requestConfiguration_configuration_UserIdentityConfiguration_userIdentityConfiguration_IdentityAttributeName = cmdletContext.UserIdentityConfiguration_IdentityAttributeName;
            }
            if (requestConfiguration_configuration_UserIdentityConfiguration_userIdentityConfiguration_IdentityAttributeName != null)
            {
                requestConfiguration_configuration_UserIdentityConfiguration.IdentityAttributeName = requestConfiguration_configuration_UserIdentityConfiguration_userIdentityConfiguration_IdentityAttributeName;
                requestConfiguration_configuration_UserIdentityConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_UserIdentityConfiguration should be set to null
            if (requestConfiguration_configuration_UserIdentityConfigurationIsNull)
            {
                requestConfiguration_configuration_UserIdentityConfiguration = null;
            }
            if (requestConfiguration_configuration_UserIdentityConfiguration != null)
            {
                request.Configuration.UserIdentityConfiguration = requestConfiguration_configuration_UserIdentityConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.Kendra.Model.ContentSourceConfiguration requestConfiguration_configuration_ContentSourceConfiguration = null;
            
             // populate ContentSourceConfiguration
            var requestConfiguration_configuration_ContentSourceConfigurationIsNull = true;
            requestConfiguration_configuration_ContentSourceConfiguration = new Amazon.Kendra.Model.ContentSourceConfiguration();
            List<System.String> requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_DataSourceId = null;
            if (cmdletContext.ContentSourceConfiguration_DataSourceId != null)
            {
                requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_DataSourceId = cmdletContext.ContentSourceConfiguration_DataSourceId;
            }
            if (requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_DataSourceId != null)
            {
                requestConfiguration_configuration_ContentSourceConfiguration.DataSourceIds = requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_DataSourceId;
                requestConfiguration_configuration_ContentSourceConfigurationIsNull = false;
            }
            System.Boolean? requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_DirectPutContent = null;
            if (cmdletContext.ContentSourceConfiguration_DirectPutContent != null)
            {
                requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_DirectPutContent = cmdletContext.ContentSourceConfiguration_DirectPutContent.Value;
            }
            if (requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_DirectPutContent != null)
            {
                requestConfiguration_configuration_ContentSourceConfiguration.DirectPutContent = requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_DirectPutContent.Value;
                requestConfiguration_configuration_ContentSourceConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_FaqId = null;
            if (cmdletContext.ContentSourceConfiguration_FaqId != null)
            {
                requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_FaqId = cmdletContext.ContentSourceConfiguration_FaqId;
            }
            if (requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_FaqId != null)
            {
                requestConfiguration_configuration_ContentSourceConfiguration.FaqIds = requestConfiguration_configuration_ContentSourceConfiguration_contentSourceConfiguration_FaqId;
                requestConfiguration_configuration_ContentSourceConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ContentSourceConfiguration should be set to null
            if (requestConfiguration_configuration_ContentSourceConfigurationIsNull)
            {
                requestConfiguration_configuration_ContentSourceConfiguration = null;
            }
            if (requestConfiguration_configuration_ContentSourceConfiguration != null)
            {
                request.Configuration.ContentSourceConfiguration = requestConfiguration_configuration_ContentSourceConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.Kendra.Model.UpdateExperienceResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.UpdateExperienceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "UpdateExperience");
            try
            {
                #if DESKTOP
                return client.UpdateExperience(request);
                #elif CORECLR
                return client.UpdateExperienceAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ContentSourceConfiguration_DataSourceId { get; set; }
            public System.Boolean? ContentSourceConfiguration_DirectPutContent { get; set; }
            public List<System.String> ContentSourceConfiguration_FaqId { get; set; }
            public System.String UserIdentityConfiguration_IdentityAttributeName { get; set; }
            public System.String Description { get; set; }
            public System.String Id { get; set; }
            public System.String IndexId { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.Kendra.Model.UpdateExperienceResponse, UpdateKNDRExperienceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
