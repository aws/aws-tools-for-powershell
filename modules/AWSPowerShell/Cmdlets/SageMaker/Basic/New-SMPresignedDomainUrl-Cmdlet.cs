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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Creates a URL for a specified UserProfile in a Domain. When accessed in a web browser,
    /// the user will be automatically signed in to the domain, and granted access to all
    /// of the Apps and files associated with the Domain's Amazon Elastic File System volume.
    /// This operation can only be called when the authentication mode equals IAM. 
    /// 
    ///  
    /// <para>
    /// The IAM role or user passed to this API defines the permissions to access the app.
    /// Once the presigned URL is created, no additional permission is required to access
    /// this URL. IAM authorization policies for this API are also enforced for every HTTP
    /// request and WebSocket frame that attempts to connect to the app.
    /// </para><para>
    /// You can restrict access to this API and to the URL that it returns to a list of IP
    /// addresses, Amazon VPCs or Amazon VPC Endpoints that you specify. For more information,
    /// see <a href="https://docs.aws.amazon.com/sagemaker/latest/dg/studio-interface-endpoint.html">Connect
    /// to Amazon SageMaker Studio Through an Interface VPC Endpoint</a> .
    /// </para><note><para>
    /// The URL that you get from a call to <c>CreatePresignedDomainUrl</c> has a default
    /// timeout of 5 minutes. You can configure this value using <c>ExpiresInSeconds</c>.
    /// If you try to use the URL after the timeout limit expires, you are directed to the
    /// Amazon Web Services console sign-in page.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SMPresignedDomainUrl", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreatePresignedDomainUrl API operation.", Operation = new[] {"CreatePresignedDomainUrl"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreatePresignedDomainUrlResponse))]
    [AWSCmdletOutput("System.String or Amazon.SageMaker.Model.CreatePresignedDomainUrlResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SageMaker.Model.CreatePresignedDomainUrlResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSMPresignedDomainUrlCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The domain ID.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter ExpiresInSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds until the pre-signed URL expires. This value defaults to 300.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExpiresInSeconds")]
        public System.Int32? ExpiresInSecond { get; set; }
        #endregion
        
        #region Parameter LandingUri
        /// <summary>
        /// <para>
        /// <para>The landing page that the user is directed to when accessing the presigned URL. Using
        /// this value, users can access Studio or Studio Classic, even if it is not the default
        /// experience for the domain. The supported values are:</para><ul><li><para><c>studio::relative/path</c>: Directs users to the relative path in Studio.</para></li><li><para><c>app:JupyterServer:relative/path</c>: Directs users to the relative path in the
        /// Studio Classic application.</para></li><li><para><c>app:JupyterLab:relative/path</c>: Directs users to the relative path in the JupyterLab
        /// application.</para></li><li><para><c>app:RStudioServerPro:relative/path</c>: Directs users to the relative path in
        /// the RStudio application.</para></li><li><para><c>app:CodeEditor:relative/path</c>: Directs users to the relative path in the Code
        /// Editor, based on Code-OSS, Visual Studio Code - Open Source application.</para></li><li><para><c>app:Canvas:relative/path</c>: Directs users to the relative path in the Canvas
        /// application.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LandingUri { get; set; }
        #endregion
        
        #region Parameter SessionExpirationDurationInSecond
        /// <summary>
        /// <para>
        /// <para>The session expiration duration in seconds. This value defaults to 43200.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionExpirationDurationInSeconds")]
        public System.Int32? SessionExpirationDurationInSecond { get; set; }
        #endregion
        
        #region Parameter SpaceName
        /// <summary>
        /// <para>
        /// <para>The name of the space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SpaceName { get; set; }
        #endregion
        
        #region Parameter UserProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the UserProfile to sign-in as.</para>
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
        public System.String UserProfileName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthorizedUrl'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreatePresignedDomainUrlResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreatePresignedDomainUrlResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthorizedUrl";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMPresignedDomainUrl (CreatePresignedDomainUrl)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreatePresignedDomainUrlResponse, NewSMPresignedDomainUrlCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpiresInSecond = this.ExpiresInSecond;
            context.LandingUri = this.LandingUri;
            context.SessionExpirationDurationInSecond = this.SessionExpirationDurationInSecond;
            context.SpaceName = this.SpaceName;
            context.UserProfileName = this.UserProfileName;
            #if MODULAR
            if (this.UserProfileName == null && ParameterWasBound(nameof(this.UserProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter UserProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.CreatePresignedDomainUrlRequest();
            
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            if (cmdletContext.ExpiresInSecond != null)
            {
                request.ExpiresInSeconds = cmdletContext.ExpiresInSecond.Value;
            }
            if (cmdletContext.LandingUri != null)
            {
                request.LandingUri = cmdletContext.LandingUri;
            }
            if (cmdletContext.SessionExpirationDurationInSecond != null)
            {
                request.SessionExpirationDurationInSeconds = cmdletContext.SessionExpirationDurationInSecond.Value;
            }
            if (cmdletContext.SpaceName != null)
            {
                request.SpaceName = cmdletContext.SpaceName;
            }
            if (cmdletContext.UserProfileName != null)
            {
                request.UserProfileName = cmdletContext.UserProfileName;
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
        
        private Amazon.SageMaker.Model.CreatePresignedDomainUrlResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreatePresignedDomainUrlRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreatePresignedDomainUrl");
            try
            {
                #if DESKTOP
                return client.CreatePresignedDomainUrl(request);
                #elif CORECLR
                return client.CreatePresignedDomainUrlAsync(request).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.Int32? ExpiresInSecond { get; set; }
            public System.String LandingUri { get; set; }
            public System.Int32? SessionExpirationDurationInSecond { get; set; }
            public System.String SpaceName { get; set; }
            public System.String UserProfileName { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreatePresignedDomainUrlResponse, NewSMPresignedDomainUrlCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthorizedUrl;
        }
        
    }
}
