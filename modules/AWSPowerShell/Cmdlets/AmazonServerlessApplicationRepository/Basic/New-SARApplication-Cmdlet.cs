/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    [AWSCmdlet("Calls the AWS Serverless Application Repository CreateApplication API operation.", Operation = new[] {"CreateApplication"})]
    [AWSCmdletOutput("Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse",
        "This cmdlet returns a Amazon.ServerlessApplicationRepository.Model.CreateApplicationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSARApplicationCmdlet : AmazonServerlessApplicationRepositoryClientCmdlet, IExecutor
    {
        
        #region Parameter Author
        /// <summary>
        /// <para>
        /// <para>The name of the author publishing the app.</para><para>Min Length=1. Max Length=127.</para><para>Pattern "^[a-z0-9](([a-z0-9]|-(?!-))*[a-z0-9])?$";</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Author { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the application.</para><para>Min Length=1. Max Length=256</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter HomePageUrl
        /// <summary>
        /// <para>
        /// <para>A URL with more information about the application, for example the location of your
        /// GitHub repository for the application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HomePageUrl { get; set; }
        #endregion
        
        #region Parameter Label
        /// <summary>
        /// <para>
        /// <para>Labels to improve discovery of apps in search results.</para><para>Min Length=1. Max Length=127. Maximum number of labels: 10</para><para>Pattern: "^[a-zA-Z0-9+\\-_:\\/@]+$";</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Labels")]
        public System.String[] Label { get; set; }
        #endregion
        
        #region Parameter LicenseBody
        /// <summary>
        /// <para>
        /// <para>A raw text file that contains the license of the app that matches the spdxLicenseID
        /// of your application.</para><para>Max size 5 MB</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LicenseBody { get; set; }
        #endregion
        
        #region Parameter LicenseUrl
        /// <summary>
        /// <para>
        /// <para>A link to a license file of the app that matches the spdxLicenseID of your application.</para><para>Max size 5 MB</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String LicenseUrl { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the application you want to publish.</para><para>Min Length=1. Max Length=140</para><para>Pattern: "[a-zA-Z0-9\\-]+";</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ReadmeBody
        /// <summary>
        /// <para>
        /// <para>A raw text Readme file that contains a more detailed description of the application
        /// and how it works in markdown language.</para><para>Max size 5 MB</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReadmeBody { get; set; }
        #endregion
        
        #region Parameter ReadmeUrl
        /// <summary>
        /// <para>
        /// <para>A link to the Readme file that contains a more detailed description of the application
        /// and how it works in markdown language.</para><para>Max size 5 MB</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReadmeUrl { get; set; }
        #endregion
        
        #region Parameter SemanticVersion
        /// <summary>
        /// <para>
        /// <para>The semantic version of the application:</para><para><a href="https://semver.org/">https://semver.org/</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SemanticVersion { get; set; }
        #endregion
        
        #region Parameter SourceCodeUrl
        /// <summary>
        /// <para>
        /// <para>A link to a public repository for the source code of your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceCodeUrl { get; set; }
        #endregion
        
        #region Parameter SpdxLicenseId
        /// <summary>
        /// <para>
        /// <para>A valid identifier from <a href="https://spdx.org/licenses/">https://spdx.org/licenses/</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SpdxLicenseId { get; set; }
        #endregion
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>The raw packaged AWS SAM template of your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateUrl
        /// <summary>
        /// <para>
        /// <para>A link to the packaged AWS SAM template of your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemplateUrl { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SARApplication (CreateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Author = this.Author;
            context.Description = this.Description;
            context.HomePageUrl = this.HomePageUrl;
            if (this.Label != null)
            {
                context.Labels = new List<System.String>(this.Label);
            }
            context.LicenseBody = this.LicenseBody;
            context.LicenseUrl = this.LicenseUrl;
            context.Name = this.Name;
            context.ReadmeBody = this.ReadmeBody;
            context.ReadmeUrl = this.ReadmeUrl;
            context.SemanticVersion = this.SemanticVersion;
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
            if (cmdletContext.Labels != null)
            {
                request.Labels = cmdletContext.Labels;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateApplicationAsync(request);
                return task.Result;
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
            public List<System.String> Labels { get; set; }
            public System.String LicenseBody { get; set; }
            public System.String LicenseUrl { get; set; }
            public System.String Name { get; set; }
            public System.String ReadmeBody { get; set; }
            public System.String ReadmeUrl { get; set; }
            public System.String SemanticVersion { get; set; }
            public System.String SourceCodeUrl { get; set; }
            public System.String SpdxLicenseId { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateUrl { get; set; }
        }
        
    }
}
