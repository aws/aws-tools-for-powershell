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
using Amazon.AppStream;
using Amazon.AppStream.Model;

namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Creates custom branding that customizes the appearance of the streaming application
    /// catalog page.
    /// </summary>
    [Cmdlet("New", "APSThemeForStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.Theme")]
    [AWSCmdlet("Calls the Amazon AppStream CreateThemeForStack API operation.", Operation = new[] {"CreateThemeForStack"}, SelectReturnType = typeof(Amazon.AppStream.Model.CreateThemeForStackResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.Theme or Amazon.AppStream.Model.CreateThemeForStackResponse",
        "This cmdlet returns an Amazon.AppStream.Model.Theme object.",
        "The service call response (type Amazon.AppStream.Model.CreateThemeForStackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewAPSThemeForStackCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter FooterLink
        /// <summary>
        /// <para>
        /// <para>The links that are displayed in the footer of the streaming application catalog page.
        /// These links are helpful resources for users, such as the organization's IT support
        /// and product marketing sites.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FooterLinks")]
        public Amazon.AppStream.Model.ThemeFooterLink[] FooterLink { get; set; }
        #endregion
        
        #region Parameter FaviconS3Location_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket of the S3 object.</para>
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
        public System.String FaviconS3Location_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OrganizationLogoS3Location_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket of the S3 object.</para>
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
        public System.String OrganizationLogoS3Location_S3Bucket { get; set; }
        #endregion
        
        #region Parameter FaviconS3Location_S3Key
        /// <summary>
        /// <para>
        /// <para>The S3 key of the S3 object.</para><para>This is required when used for the following:</para><ul><li><para>IconS3Location (Actions: CreateApplication and UpdateApplication)</para></li><li><para>SessionScriptS3Location (Actions: CreateFleet and UpdateFleet)</para></li><li><para>ScriptDetails (Actions: CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>CUSTOM</c> PackagingType (Actions:
        /// CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>APPSTREAM2</c> PackagingType,
        /// and using an existing application package (VHD file). In this case, <c>S3Key</c> refers
        /// to the VHD file. If a new application package is required, then <c>S3Key</c> is not
        /// required. (Actions: CreateAppBlock)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FaviconS3Location_S3Key { get; set; }
        #endregion
        
        #region Parameter OrganizationLogoS3Location_S3Key
        /// <summary>
        /// <para>
        /// <para>The S3 key of the S3 object.</para><para>This is required when used for the following:</para><ul><li><para>IconS3Location (Actions: CreateApplication and UpdateApplication)</para></li><li><para>SessionScriptS3Location (Actions: CreateFleet and UpdateFleet)</para></li><li><para>ScriptDetails (Actions: CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>CUSTOM</c> PackagingType (Actions:
        /// CreateAppBlock)</para></li><li><para>SourceS3Location when creating an app block with <c>APPSTREAM2</c> PackagingType,
        /// and using an existing application package (VHD file). In this case, <c>S3Key</c> refers
        /// to the VHD file. If a new application package is required, then <c>S3Key</c> is not
        /// required. (Actions: CreateAppBlock)</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationLogoS3Location_S3Key { get; set; }
        #endregion
        
        #region Parameter StackName
        /// <summary>
        /// <para>
        /// <para>The name of the stack for the theme.</para>
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
        public System.String StackName { get; set; }
        #endregion
        
        #region Parameter ThemeStyling
        /// <summary>
        /// <para>
        /// <para>The color theme that is applied to website links, text, and buttons. These colors
        /// are also applied as accents in the background for the streaming application catalog
        /// page.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppStream.ThemeStyling")]
        public Amazon.AppStream.ThemeStyling ThemeStyling { get; set; }
        #endregion
        
        #region Parameter TitleText
        /// <summary>
        /// <para>
        /// <para>The title that is displayed at the top of the browser tab during users' application
        /// streaming sessions.</para>
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
        public System.String TitleText { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Theme'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.CreateThemeForStackResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.CreateThemeForStackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Theme";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APSThemeForStack (CreateThemeForStack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.CreateThemeForStackResponse, NewAPSThemeForStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.FaviconS3Location_S3Bucket = this.FaviconS3Location_S3Bucket;
            #if MODULAR
            if (this.FaviconS3Location_S3Bucket == null && ParameterWasBound(nameof(this.FaviconS3Location_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter FaviconS3Location_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FaviconS3Location_S3Key = this.FaviconS3Location_S3Key;
            if (this.FooterLink != null)
            {
                context.FooterLink = new List<Amazon.AppStream.Model.ThemeFooterLink>(this.FooterLink);
            }
            context.OrganizationLogoS3Location_S3Bucket = this.OrganizationLogoS3Location_S3Bucket;
            #if MODULAR
            if (this.OrganizationLogoS3Location_S3Bucket == null && ParameterWasBound(nameof(this.OrganizationLogoS3Location_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationLogoS3Location_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OrganizationLogoS3Location_S3Key = this.OrganizationLogoS3Location_S3Key;
            context.StackName = this.StackName;
            #if MODULAR
            if (this.StackName == null && ParameterWasBound(nameof(this.StackName)))
            {
                WriteWarning("You are passing $null as a value for parameter StackName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThemeStyling = this.ThemeStyling;
            #if MODULAR
            if (this.ThemeStyling == null && ParameterWasBound(nameof(this.ThemeStyling)))
            {
                WriteWarning("You are passing $null as a value for parameter ThemeStyling which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TitleText = this.TitleText;
            #if MODULAR
            if (this.TitleText == null && ParameterWasBound(nameof(this.TitleText)))
            {
                WriteWarning("You are passing $null as a value for parameter TitleText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppStream.Model.CreateThemeForStackRequest();
            
            
             // populate FaviconS3Location
            var requestFaviconS3LocationIsNull = true;
            request.FaviconS3Location = new Amazon.AppStream.Model.S3Location();
            System.String requestFaviconS3Location_faviconS3Location_S3Bucket = null;
            if (cmdletContext.FaviconS3Location_S3Bucket != null)
            {
                requestFaviconS3Location_faviconS3Location_S3Bucket = cmdletContext.FaviconS3Location_S3Bucket;
            }
            if (requestFaviconS3Location_faviconS3Location_S3Bucket != null)
            {
                request.FaviconS3Location.S3Bucket = requestFaviconS3Location_faviconS3Location_S3Bucket;
                requestFaviconS3LocationIsNull = false;
            }
            System.String requestFaviconS3Location_faviconS3Location_S3Key = null;
            if (cmdletContext.FaviconS3Location_S3Key != null)
            {
                requestFaviconS3Location_faviconS3Location_S3Key = cmdletContext.FaviconS3Location_S3Key;
            }
            if (requestFaviconS3Location_faviconS3Location_S3Key != null)
            {
                request.FaviconS3Location.S3Key = requestFaviconS3Location_faviconS3Location_S3Key;
                requestFaviconS3LocationIsNull = false;
            }
             // determine if request.FaviconS3Location should be set to null
            if (requestFaviconS3LocationIsNull)
            {
                request.FaviconS3Location = null;
            }
            if (cmdletContext.FooterLink != null)
            {
                request.FooterLinks = cmdletContext.FooterLink;
            }
            
             // populate OrganizationLogoS3Location
            var requestOrganizationLogoS3LocationIsNull = true;
            request.OrganizationLogoS3Location = new Amazon.AppStream.Model.S3Location();
            System.String requestOrganizationLogoS3Location_organizationLogoS3Location_S3Bucket = null;
            if (cmdletContext.OrganizationLogoS3Location_S3Bucket != null)
            {
                requestOrganizationLogoS3Location_organizationLogoS3Location_S3Bucket = cmdletContext.OrganizationLogoS3Location_S3Bucket;
            }
            if (requestOrganizationLogoS3Location_organizationLogoS3Location_S3Bucket != null)
            {
                request.OrganizationLogoS3Location.S3Bucket = requestOrganizationLogoS3Location_organizationLogoS3Location_S3Bucket;
                requestOrganizationLogoS3LocationIsNull = false;
            }
            System.String requestOrganizationLogoS3Location_organizationLogoS3Location_S3Key = null;
            if (cmdletContext.OrganizationLogoS3Location_S3Key != null)
            {
                requestOrganizationLogoS3Location_organizationLogoS3Location_S3Key = cmdletContext.OrganizationLogoS3Location_S3Key;
            }
            if (requestOrganizationLogoS3Location_organizationLogoS3Location_S3Key != null)
            {
                request.OrganizationLogoS3Location.S3Key = requestOrganizationLogoS3Location_organizationLogoS3Location_S3Key;
                requestOrganizationLogoS3LocationIsNull = false;
            }
             // determine if request.OrganizationLogoS3Location should be set to null
            if (requestOrganizationLogoS3LocationIsNull)
            {
                request.OrganizationLogoS3Location = null;
            }
            if (cmdletContext.StackName != null)
            {
                request.StackName = cmdletContext.StackName;
            }
            if (cmdletContext.ThemeStyling != null)
            {
                request.ThemeStyling = cmdletContext.ThemeStyling;
            }
            if (cmdletContext.TitleText != null)
            {
                request.TitleText = cmdletContext.TitleText;
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
        
        private Amazon.AppStream.Model.CreateThemeForStackResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.CreateThemeForStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "CreateThemeForStack");
            try
            {
                #if DESKTOP
                return client.CreateThemeForStack(request);
                #elif CORECLR
                return client.CreateThemeForStackAsync(request).GetAwaiter().GetResult();
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
            public System.String FaviconS3Location_S3Bucket { get; set; }
            public System.String FaviconS3Location_S3Key { get; set; }
            public List<Amazon.AppStream.Model.ThemeFooterLink> FooterLink { get; set; }
            public System.String OrganizationLogoS3Location_S3Bucket { get; set; }
            public System.String OrganizationLogoS3Location_S3Key { get; set; }
            public System.String StackName { get; set; }
            public Amazon.AppStream.ThemeStyling ThemeStyling { get; set; }
            public System.String TitleText { get; set; }
            public System.Func<Amazon.AppStream.Model.CreateThemeForStackResponse, NewAPSThemeForStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Theme;
        }
        
    }
}
