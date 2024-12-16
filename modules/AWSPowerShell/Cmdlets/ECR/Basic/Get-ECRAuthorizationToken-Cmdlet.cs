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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Retrieves an authorization token. An authorization token represents your IAM authentication
    /// credentials and can be used to access any Amazon ECR registry that your IAM principal
    /// has access to. The authorization token is valid for 12 hours.
    /// 
    ///  
    /// <para>
    /// The <c>authorizationToken</c> returned is a base64 encoded string that can be decoded
    /// and used in a <c>docker login</c> command to authenticate to a registry. The CLI offers
    /// an <c>get-login-password</c> command that simplifies the login process. For more information,
    /// see <a href="https://docs.aws.amazon.com/AmazonECR/latest/userguide/Registries.html#registry_auth">Registry
    /// authentication</a> in the <i>Amazon Elastic Container Registry User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ECRAuthorizationToken")]
    [OutputType("Amazon.ECR.Model.AuthorizationData")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry GetAuthorizationToken API operation.", Operation = new[] {"GetAuthorizationToken"}, SelectReturnType = typeof(Amazon.ECR.Model.GetAuthorizationTokenResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.AuthorizationData or Amazon.ECR.Model.GetAuthorizationTokenResponse",
        "This cmdlet returns a collection of Amazon.ECR.Model.AuthorizationData objects.",
        "The service call response (type Amazon.ECR.Model.GetAuthorizationTokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECRAuthorizationTokenCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Web Services account IDs that are associated with the registries
        /// for which to get AuthorizationData objects. If you do not specify a registry, the
        /// default registry is assumed.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [System.ObsoleteAttribute("This field is deprecated. The returned authorization token can be used to access any Amazon ECR registry that the IAM principal has access to, specifying a registry ID doesn\u0027t change the permissions scope of the authorization token.")]
        [Alias("RegistryIds")]
        public System.String[] RegistryId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthorizationData'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.GetAuthorizationTokenResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.GetAuthorizationTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthorizationData";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.GetAuthorizationTokenResponse, GetECRAuthorizationTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.RegistryId != null)
            {
                context.RegistryId = new List<System.String>(this.RegistryId);
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.ECR.Model.GetAuthorizationTokenRequest();
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryIds = cmdletContext.RegistryId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.ECR.Model.GetAuthorizationTokenResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.GetAuthorizationTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "GetAuthorizationToken");
            try
            {
                #if DESKTOP
                return client.GetAuthorizationToken(request);
                #elif CORECLR
                return client.GetAuthorizationTokenAsync(request).GetAwaiter().GetResult();
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
            [System.ObsoleteAttribute]
            public List<System.String> RegistryId { get; set; }
            public System.Func<Amazon.ECR.Model.GetAuthorizationTokenResponse, GetECRAuthorizationTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthorizationData;
        }
        
    }
}
