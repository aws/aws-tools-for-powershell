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
    /// Creates an application version.
    /// </summary>
    [Cmdlet("New", "SARApplicationVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse")]
    [AWSCmdlet("Calls the AWS Serverless Application Repository CreateApplicationVersion API operation.", Operation = new[] {"CreateApplicationVersion"}, SelectReturnType = typeof(Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse))]
    [AWSCmdletOutput("Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse",
        "This cmdlet returns an Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSARApplicationVersionCmdlet : AmazonServerlessApplicationRepositoryClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the application.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter SemanticVersion
        /// <summary>
        /// <para>
        /// <para>The semantic version of the new version.</para>
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
        
        #region Parameter TemplateBody
        /// <summary>
        /// <para>
        /// <para>The raw packaged AWS SAM template of your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateBody { get; set; }
        #endregion
        
        #region Parameter TemplateUrl
        /// <summary>
        /// <para>
        /// <para>A link to the packaged AWS SAM template of your application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemplateUrl { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse).
        /// Specifying the name of a property of type Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SemanticVersion parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SemanticVersion' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SemanticVersion' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SARApplicationVersion (CreateApplicationVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse, NewSARApplicationVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SemanticVersion;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SemanticVersion = this.SemanticVersion;
            #if MODULAR
            if (this.SemanticVersion == null && ParameterWasBound(nameof(this.SemanticVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter SemanticVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceCodeArchiveUrl = this.SourceCodeArchiveUrl;
            context.SourceCodeUrl = this.SourceCodeUrl;
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
            var request = new Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
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
        
        private Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse CallAWSServiceOperation(IAmazonServerlessApplicationRepository client, Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Serverless Application Repository", "CreateApplicationVersion");
            try
            {
                #if DESKTOP
                return client.CreateApplicationVersion(request);
                #elif CORECLR
                return client.CreateApplicationVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String SemanticVersion { get; set; }
            public System.String SourceCodeArchiveUrl { get; set; }
            public System.String SourceCodeUrl { get; set; }
            public System.String TemplateBody { get; set; }
            public System.String TemplateUrl { get; set; }
            public System.Func<Amazon.ServerlessApplicationRepository.Model.CreateApplicationVersionResponse, NewSARApplicationVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
