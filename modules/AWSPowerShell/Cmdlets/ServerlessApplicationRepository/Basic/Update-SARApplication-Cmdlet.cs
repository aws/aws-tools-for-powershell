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
    /// Updates the specified application.
    /// </summary>
    [Cmdlet("Update", "SARApplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse")]
    [AWSCmdlet("Calls the AWS Serverless Application Repository UpdateApplication API operation.", Operation = new[] {"UpdateApplication"}, SelectReturnType = typeof(Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse))]
    [AWSCmdletOutput("Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse",
        "This cmdlet returns an Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse object containing multiple properties."
    )]
    public partial class UpdateSARApplicationCmdlet : AmazonServerlessApplicationRepositoryClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the application.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Author
        /// <summary>
        /// <para>
        /// <para>The name of the author publishing the app.</para><para>Minimum length=1. Maximum length=127.</para><para>Pattern "^[a-z0-9](([a-z0-9]|-(?!-))*[a-z0-9])?$";</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Author { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the application.</para><para>Minimum length=1. Maximum length=256</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter ReadmeBody
        /// <summary>
        /// <para>
        /// <para>A text readme file in Markdown language that contains a more detailed description
        /// of the application and how it works.</para><para>Maximum size 5 MB</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmeBody { get; set; }
        #endregion
        
        #region Parameter ReadmeUrl
        /// <summary>
        /// <para>
        /// <para>A link to the readme file in Markdown language that contains a more detailed description
        /// of the application and how it works.</para><para>Maximum size 5 MB</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReadmeUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse).
        /// Specifying the name of a property of type Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SARApplication (UpdateApplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse, UpdateSARApplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Author = this.Author;
            context.Description = this.Description;
            context.HomePageUrl = this.HomePageUrl;
            if (this.Label != null)
            {
                context.Label = new List<System.String>(this.Label);
            }
            context.ReadmeBody = this.ReadmeBody;
            context.ReadmeUrl = this.ReadmeUrl;
            
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
            var request = new Amazon.ServerlessApplicationRepository.Model.UpdateApplicationRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
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
            if (cmdletContext.ReadmeBody != null)
            {
                request.ReadmeBody = cmdletContext.ReadmeBody;
            }
            if (cmdletContext.ReadmeUrl != null)
            {
                request.ReadmeUrl = cmdletContext.ReadmeUrl;
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
        
        private Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse CallAWSServiceOperation(IAmazonServerlessApplicationRepository client, Amazon.ServerlessApplicationRepository.Model.UpdateApplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Serverless Application Repository", "UpdateApplication");
            try
            {
                #if DESKTOP
                return client.UpdateApplication(request);
                #elif CORECLR
                return client.UpdateApplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String Author { get; set; }
            public System.String Description { get; set; }
            public System.String HomePageUrl { get; set; }
            public List<System.String> Label { get; set; }
            public System.String ReadmeBody { get; set; }
            public System.String ReadmeUrl { get; set; }
            public System.Func<Amazon.ServerlessApplicationRepository.Model.UpdateApplicationResponse, UpdateSARApplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
