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
using Amazon.AppFabric;
using Amazon.AppFabric.Model;

namespace Amazon.PowerShell.Cmdlets.AFAB
{
    /// <summary>
    /// Establishes a connection between Amazon Web Services AppFabric and an application,
    /// which allows AppFabric to call the APIs of the application.
    /// </summary>
    [Cmdlet("Connect", "AFABAppAuthorization", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppFabric.Model.AppAuthorizationSummary")]
    [AWSCmdlet("Calls the Amazon Web Services AppFabric ConnectAppAuthorization API operation.", Operation = new[] {"ConnectAppAuthorization"}, SelectReturnType = typeof(Amazon.AppFabric.Model.ConnectAppAuthorizationResponse))]
    [AWSCmdletOutput("Amazon.AppFabric.Model.AppAuthorizationSummary or Amazon.AppFabric.Model.ConnectAppAuthorizationResponse",
        "This cmdlet returns an Amazon.AppFabric.Model.AppAuthorizationSummary object.",
        "The service call response (type Amazon.AppFabric.Model.ConnectAppAuthorizationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConnectAFABAppAuthorizationCmdlet : AmazonAppFabricClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AppAuthorizationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app authorization
        /// to use for the request.</para>
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
        public System.String AppAuthorizationIdentifier { get; set; }
        #endregion
        
        #region Parameter AppBundleIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or Universal Unique Identifier (UUID) of the app bundle
        /// that contains the app authorization to use for the request.</para>
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
        public System.String AppBundleIdentifier { get; set; }
        #endregion
        
        #region Parameter AuthRequest_Code
        /// <summary>
        /// <para>
        /// <para>The authorization code returned by the application after permission is granted in
        /// the application OAuth page (after clicking on the AuthURL).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthRequest_Code { get; set; }
        #endregion
        
        #region Parameter AuthRequest_RedirectUri
        /// <summary>
        /// <para>
        /// <para>The redirect URL that is specified in the AuthURL and the application client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthRequest_RedirectUri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AppAuthorizationSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppFabric.Model.ConnectAppAuthorizationResponse).
        /// Specifying the name of a property of type Amazon.AppFabric.Model.ConnectAppAuthorizationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AppAuthorizationSummary";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppAuthorizationIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Connect-AFABAppAuthorization (ConnectAppAuthorization)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppFabric.Model.ConnectAppAuthorizationResponse, ConnectAFABAppAuthorizationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppAuthorizationIdentifier = this.AppAuthorizationIdentifier;
            #if MODULAR
            if (this.AppAuthorizationIdentifier == null && ParameterWasBound(nameof(this.AppAuthorizationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppAuthorizationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppBundleIdentifier = this.AppBundleIdentifier;
            #if MODULAR
            if (this.AppBundleIdentifier == null && ParameterWasBound(nameof(this.AppBundleIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter AppBundleIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AuthRequest_Code = this.AuthRequest_Code;
            context.AuthRequest_RedirectUri = this.AuthRequest_RedirectUri;
            
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
            var request = new Amazon.AppFabric.Model.ConnectAppAuthorizationRequest();
            
            if (cmdletContext.AppAuthorizationIdentifier != null)
            {
                request.AppAuthorizationIdentifier = cmdletContext.AppAuthorizationIdentifier;
            }
            if (cmdletContext.AppBundleIdentifier != null)
            {
                request.AppBundleIdentifier = cmdletContext.AppBundleIdentifier;
            }
            
             // populate AuthRequest
            var requestAuthRequestIsNull = true;
            request.AuthRequest = new Amazon.AppFabric.Model.AuthRequest();
            System.String requestAuthRequest_authRequest_Code = null;
            if (cmdletContext.AuthRequest_Code != null)
            {
                requestAuthRequest_authRequest_Code = cmdletContext.AuthRequest_Code;
            }
            if (requestAuthRequest_authRequest_Code != null)
            {
                request.AuthRequest.Code = requestAuthRequest_authRequest_Code;
                requestAuthRequestIsNull = false;
            }
            System.String requestAuthRequest_authRequest_RedirectUri = null;
            if (cmdletContext.AuthRequest_RedirectUri != null)
            {
                requestAuthRequest_authRequest_RedirectUri = cmdletContext.AuthRequest_RedirectUri;
            }
            if (requestAuthRequest_authRequest_RedirectUri != null)
            {
                request.AuthRequest.RedirectUri = requestAuthRequest_authRequest_RedirectUri;
                requestAuthRequestIsNull = false;
            }
             // determine if request.AuthRequest should be set to null
            if (requestAuthRequestIsNull)
            {
                request.AuthRequest = null;
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
        
        private Amazon.AppFabric.Model.ConnectAppAuthorizationResponse CallAWSServiceOperation(IAmazonAppFabric client, Amazon.AppFabric.Model.ConnectAppAuthorizationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Web Services AppFabric", "ConnectAppAuthorization");
            try
            {
                #if DESKTOP
                return client.ConnectAppAuthorization(request);
                #elif CORECLR
                return client.ConnectAppAuthorizationAsync(request).GetAwaiter().GetResult();
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
            public System.String AppAuthorizationIdentifier { get; set; }
            public System.String AppBundleIdentifier { get; set; }
            public System.String AuthRequest_Code { get; set; }
            public System.String AuthRequest_RedirectUri { get; set; }
            public System.Func<Amazon.AppFabric.Model.ConnectAppAuthorizationResponse, ConnectAFABAppAuthorizationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AppAuthorizationSummary;
        }
        
    }
}
