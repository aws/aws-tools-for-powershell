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
using Amazon.ServerlessApplicationRepository;
using Amazon.ServerlessApplicationRepository.Model;

namespace Amazon.PowerShell.Cmdlets.SAR
{
    /// <summary>
    /// Creates an application, optionally including an AWS SAM file to create the first application
    /// version in the same call.
    /// </summary>
    [Cmdlet("New", "SARApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse")]
    [AWSCmdlet("Calls the AWS Serverless Application Repository CreateApplication API operation.", Operation = new[] {"CreateApplication"}, SelectReturnType = typeof(Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse))]
    [AWSCmdletOutput("Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse",
        "This cmdlet returns an Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSARApplicationCmdlet : AmazonServerlessApplicationRepositoryClientCmdlet, IExecutor
    {
        
        #region Parameter Author
        /// <summary>
        /// <para>
        /// <para>The name of the author publishing the app.</para><para>Minimum length=1. Maximum length=127.</para><para>Pattern "^[a-z0-9](([a-z0-9]|-(?!-))*[a-z0-9])?$";</para>
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
        public System.String Author { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the application.</para><para>Minimum length=1. Maximum length=256</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter HomePageUrl
        /// <summary>
        /// <para>
        /// <para>A URL with more information about the application, for example the location of your
        /// GitHub repository for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HomePageUrl { get; set; }
        #endregion
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>Labels to improve discovery of apps in search results.</para><para>Minimum length=1. Maximum length=127. Maximum number of labels: 10</para><para>Pattern: "^[a-zA-Z0-9+\\-_:\\/@]+$";</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Labels")]
        public System.String[] Label { get; set; }
        #endregion
        
        #region Parameter LicenseBody
        /// <summary>
        /// <para>
        /// <para>A local text file that contains the license of the app that matches the spdxLicenseID
        /// value of your application. The file has the format file://&lt;path&gt;/&lt;filename&gt;.</para><para>Maximum size 5 MB</para><para>You can specify only one of licenseBody and licenseUrl; otherwise, an error results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseBody { get; set; }
        #endregion
        
        #region Parameter LicenseUrl
        /// <summary>
        /// <para>
        /// <para>A link to the S3 object that contains the license of the app that matches the spdxLicenseID
        /// value of your application.</para><para>Maximum size 5 MB</para><para>You can specify only one of licenseBody and licenseUrl; otherwise, an error results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LicenseUrl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the application that you want to publish.</para><para>Minimum length=1. Maximum length=140</para><para>Pattern: "[a-zA-Z0-9\\-]+";</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ReadmeBody
        /// <summary>
        /// <para>
        /// <para>A local text readme file in Markdown language that contains a more detailed description
        /// of the application and how it works. The file has the format file://&lt;path&gt;/&lt;filename&gt;.</para><para>Maximum size 5 MB</para><para>You can specify only one of readmeBody and readmeUrl; otherwise, an error results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmeBody { get; set; }
        #endregion
        
        #region Parameter ReadmeUrl
        /// <summary>
        /// <para>
        /// <para>A link to the S3 object in Markdown language that contains a more detailed description
        /// of the application and how it works.</para><para>Maximum size 5 MB</para><para>You can specify only one of readmeBody and readmeUrl; otherwise, an error results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmeUrl { get; set; }
        #endregion
        
        #region Parameter SemanticVersion
        /// <summary>
        /// <para>
        /// <para>The semantic version of the application:</para><para><a href="https://semver.org/">https://semver.org/</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SemanticVersion { get; set; }
        #endregion
        
        #region Parameter SourceCodeArchiveUrl
        /// <summary>
        /// <para>
        /// <para>A link to the S3 object that contains the ZIP archive of the source code for this
        /// version of your application.</para><para>Maximum size 50 MB</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceCodeArchiveUrl { get; set; }
        #endregion
        
        #region Parameter SourceCodeUrl
        /// <summary>
        /// <para>
        /// <para>A link to a public repository for the source code of your application, for example
        /// the URL of a specific GitHub commit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceCodeUrl { get; set; }
        #endregion
        
        #region Parameter SpdxLicenseId
        /// <summary>
        /// <para>
        /// <para>A valid identifier from <a href="https://spdx.org/licenses/">https://spdx.org/licenses/</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SpdxLicenseId { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>The local raw packaged AWS SAM template file of your application. The file has the
        /// format file://&lt;path&gt;/&lt;filename&gt;.</para><para>You can specify only one of templateBody and templateUrl; otherwise an error results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateUrl
        /// <summary>
        /// <para>
        /// <para>A link to the S3 object containing the packaged AWS SAM template of your application.</para><para>You can specify only one of templateBody and templateUrl; otherwise an error results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse).
        /// Specifying the name of a property of type Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SARApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse, NewSARApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Author = this.Author;
            #if MODULAR
            if (this.Author == null && ParameterWasBound(nameof(this.Author)))
            {
                WriteWarning("You are passing $null as a value for parameter Author which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HomePageUrl = this.HomePageUrl;
            if (this.Label != null)
            {
                context.Label = new List<System.String>(this.Label);
            }
            context.LicenseBody = this.LicenseBody;
            context.LicenseUrl = this.LicenseUrl;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReadmeBody = this.ReadmeBody;
            context.ReadmeUrl = this.ReadmeUrl;
            context.SemanticVersion = this.SemanticVersion;
            context.SourceCodeArchiveUrl = this.SourceCodeArchiveUrl;
            context.SourceCodeUrl = this.SourceCodeUrl;
            context.SpdxLicenseId = this.SpdxLicenseId;
            context.TemplateBody = this.TemplateBody;
            context.TemplateUrl = this.TemplateUrl;
            
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
            var request = new Amazon.ServerlessApplicationRepository.Model.CreateApplicationRequest();
            
            if (cmdletContext.Author != null)
            {
                request.Author = cmdletContext.Author;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.HomePageUrl != null)
            {
                request.HomePageUrl = cmdletContext.HomePageUrl;
            }
            if (cmdletContext.Label != null)
            {
                request.Labels = cmdletContext.Label;
            }
            if (cmdletContext.LicenseBody != null)
            {
                request.LicenseBody = cmdletContext.LicenseBody;
            }
            if (cmdletContext.LicenseUrl != null)
            {
                request.LicenseUrl = cmdletContext.LicenseUrl;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ReadmeBody != null)
            {
                request.ReadmeBody = cmdletContext.ReadmeBody;
            }
            if (cmdletContext.ReadmeUrl != null)
            {
                request.ReadmeUrl = cmdletContext.ReadmeUrl;
            }
            if (cmdletContext.SemanticVersion != null)
            {
                request.SemanticVersion = cmdletContext.SemanticVersion;
            }
            if (cmdletContext.SourceCodeArchiveUrl != null)
            {
                request.SourceCodeArchiveUrl = cmdletContext.SourceCodeArchiveUrl;
            }
            if (cmdletContext.SourceCodeUrl != null)
            {
                request.SourceCodeUrl = cmdletContext.SourceCodeUrl;
            }
            if (cmdletContext.SpdxLicenseId != null)
            {
                request.SpdxLicenseId = cmdletContext.SpdxLicenseId;
            }
            if (cmdletContext.TemplateBody != null)
            {
                request.TemplateBody = cmdletContext.TemplateBody;
            }
            if (cmdletContext.TemplateUrl != null)
            {
                request.TemplateUrl = cmdletContext.TemplateUrl;
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
        
        private Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse CallAWSServiceOperation(IAmazonServerlessApplicationRepository client, Amazon.ServerlessApplicationRepository.Model.CreateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Serverless Application Repository", "CreateApplication");
            try
            {
                #if DESKTOP
                return client.CreateApplication(request);
                #elif CORECLR
                return client.CreateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String Author { get; set; }
            public System.String Description { get; set; }
            public System.String HomePageUrl { get; set; }
            public List<System.String> Label { get; set; }
            public System.String LicenseBody { get; set; }
            public System.String LicenseUrl { get; set; }
            public System.String Name { get; set; }
            public System.String ReadmeBody { get; set; }
            public System.String ReadmeUrl { get; set; }
            public System.String SemanticVersion { get; set; }
            public System.String SourceCodeArchiveUrl { get; set; }
            public System.String SourceCodeUrl { get; set; }
            public System.String SpdxLicenseId { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateUrl { get; set; }
            public System.Func<Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse, NewSARApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
