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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Returns information about a configured OpenSearch Serverless security policy. For
    /// more information, see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-network.html">Network
    /// access for Amazon OpenSearch Serverless</a> and <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-encryption.html">Encryption
    /// at rest for Amazon OpenSearch Serverless</a>.
    /// </summary>
    [Cmdlet("Get", "OSSSecurityPolicy")]
    [OutputType("Amazon.OpenSearchServerless.Model.SecurityPolicyDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless GetSecurityPolicy API operation.", Operation = new[] {"GetSecurityPolicy"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.GetSecurityPolicyResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.SecurityPolicyDetail or Amazon.OpenSearchServerless.Model.GetSecurityPolicyResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.SecurityPolicyDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.GetSecurityPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetOSSSecurityPolicyCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the security policy.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of security policy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.OpenSearchServerless.SecurityPolicyType")]
        public Amazon.OpenSearchServerless.SecurityPolicyType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecurityPolicyDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.GetSecurityPolicyResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.GetSecurityPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecurityPolicyDetail";
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.GetSecurityPolicyResponse, GetOSSSecurityPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchServerless.Model.GetSecurityPolicyRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.OpenSearchServerless.Model.GetSecurityPolicyResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.GetSecurityPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "GetSecurityPolicy");
            try
            {
                #if DESKTOP
                return client.GetSecurityPolicy(request);
                #elif CORECLR
                return client.GetSecurityPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public Amazon.OpenSearchServerless.SecurityPolicyType Type { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.GetSecurityPolicyResponse, GetOSSSecurityPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecurityPolicyDetail;
        }
        
    }
}
