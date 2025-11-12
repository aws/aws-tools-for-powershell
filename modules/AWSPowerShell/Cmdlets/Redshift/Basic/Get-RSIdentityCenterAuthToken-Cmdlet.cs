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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Generates an encrypted authentication token that propagates the caller's Amazon Web
    /// Services IAM Identity Center identity to Amazon Redshift clusters. This API extracts
    /// the Amazon Web Services IAM Identity Center identity from enhanced credentials and
    /// creates a secure token that Amazon Redshift drivers can use for authentication.
    /// 
    ///  
    /// <para>
    /// The token is encrypted using Key Management Service (KMS) and can only be decrypted
    /// by the specified Amazon Redshift clusters. The token contains the caller's Amazon
    /// Web Services IAM Identity Center identity information and is valid for a limited time
    /// period.
    /// </para><para>
    /// This API is exclusively for use with Amazon Web Services IAM Identity Center enhanced
    /// credentials. If the caller is not using enhanced credentials with embedded Amazon
    /// Web Services IAM Identity Center identity, the API will return an error.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RSIdentityCenterAuthToken")]
    [OutputType("Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse")]
    [AWSCmdlet("Calls the Amazon Redshift GetIdentityCenterAuthToken API operation.", Operation = new[] {"GetIdentityCenterAuthToken"}, SelectReturnType = typeof(Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse",
        "This cmdlet returns an Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse object containing multiple properties."
    )]
    public partial class GetRSIdentityCenterAuthTokenCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterId
        /// <summary>
        /// <para>
        /// <para>A list of cluster identifiers that the generated token can be used with. The token
        /// will be scoped to only allow authentication to the specified clusters.</para><para>Constraints:</para><ul><li><para><c>ClusterIds</c> must contain at least 1 cluster identifier.</para></li><li><para><c>ClusterIds</c> can hold a maximum of 20 cluster identifiers.</para></li><li><para>Cluster identifiers must be 1 to 63 characters in length.</para></li><li><para>The characters accepted for cluster identifiers are the following:</para><ul><li><para>Alphanumeric characters</para></li><li><para>Hyphens</para></li></ul></li><li><para>Cluster identifiers must start with a letter.</para></li><li><para>Cluster identifiers can't end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ClusterIds")]
        public System.String[] ClusterId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse, GetRSIdentityCenterAuthTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ClusterId != null)
            {
                context.ClusterId = new List<System.String>(this.ClusterId);
            }
            #if MODULAR
            if (this.ClusterId == null && ParameterWasBound(nameof(this.ClusterId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Redshift.Model.GetIdentityCenterAuthTokenRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterIds = cmdletContext.ClusterId;
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
        
        private Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.GetIdentityCenterAuthTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "GetIdentityCenterAuthToken");
            try
            {
                #if DESKTOP
                return client.GetIdentityCenterAuthToken(request);
                #elif CORECLR
                return client.GetIdentityCenterAuthTokenAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ClusterId { get; set; }
            public System.Func<Amazon.Redshift.Model.GetIdentityCenterAuthTokenResponse, GetRSIdentityCenterAuthTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
