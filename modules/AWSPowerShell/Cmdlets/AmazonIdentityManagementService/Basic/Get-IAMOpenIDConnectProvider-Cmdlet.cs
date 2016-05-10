/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Returns information about the specified OpenID Connect (OIDC) provider resource object
    /// in IAM.
    /// </summary>
    [Cmdlet("Get", "IAMOpenIDConnectProvider")]
    [OutputType("Amazon.IdentityManagement.Model.GetOpenIDConnectProviderResponse")]
    [AWSCmdlet("Invokes the GetOpenIDConnectProvider operation against AWS Identity and Access Management.", Operation = new[] {"GetOpenIDConnectProvider"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.GetOpenIDConnectProviderResponse",
        "This cmdlet returns a Amazon.IdentityManagement.Model.GetOpenIDConnectProviderResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetIAMOpenIDConnectProviderCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter OpenIDConnectProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the OIDC provider resource object in IAM to get
        /// information for. You can get a list of OIDC provider resource ARNs by using the <a>ListOpenIDConnectProviders</a>
        /// action.</para><para>For more information about ARNs, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and AWS Service Namespaces</a> in the <i>AWS General Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String OpenIDConnectProviderArn { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.OpenIDConnectProviderArn = this.OpenIDConnectProviderArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IdentityManagement.Model.GetOpenIDConnectProviderRequest();
            
            if (cmdletContext.OpenIDConnectProviderArn != null)
            {
                request.OpenIDConnectProviderArn = cmdletContext.OpenIDConnectProviderArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetOpenIDConnectProvider(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String OpenIDConnectProviderArn { get; set; }
        }
        
    }
}
