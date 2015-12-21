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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Retrieves a token that is valid for a specified registry for 12 hours. This command
    /// allows you to use the <code>docker</code> CLI to push and pull images with Amazon
    /// ECR. If you do not specify a registry, the default registry is assumed.
    /// 
    ///  
    /// <para>
    /// The <code>authorizationToken</code> returned for each registry specified is a base64
    /// encoded string that can be decoded and used in a <code>docker login</code> command
    /// to authenticate to a registry. The AWS CLI offers an <code>aws ecr get-login</code>
    /// command that simplifies the login process.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ECRAuthorizationToken")]
    [OutputType("Amazon.ECR.Model.AuthorizationData")]
    [AWSCmdlet("Invokes the GetAuthorizationToken operation against Amazon EC2 Container Registry.", Operation = new[] {"GetAuthorizationToken"})]
    [AWSCmdletOutput("Amazon.ECR.Model.AuthorizationData",
        "This cmdlet returns a collection of AuthorizationData objects.",
        "The service call response (type Amazon.ECR.Model.GetAuthorizationTokenResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetECRAuthorizationTokenCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>A list of AWS account IDs that are associated with the registries for which to get
        /// authorization tokens. If you do not specify a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("RegistryIds")]
        public System.String[] RegistryId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.RegistryId != null)
            {
                context.RegistryIds = new List<System.String>(this.RegistryId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.ECR.Model.GetAuthorizationTokenRequest();
            
            if (cmdletContext.RegistryIds != null)
            {
                request.RegistryIds = cmdletContext.RegistryIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetAuthorizationToken(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AuthorizationData;
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
            public List<System.String> RegistryIds { get; set; }
        }
        
    }
}
