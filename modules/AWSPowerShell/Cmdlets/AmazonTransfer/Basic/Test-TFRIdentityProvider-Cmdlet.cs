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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// If the <code>IdentityProviderType</code> of the server is <code>API_Gateway</code>,
    /// tests whether your API Gateway is set up successfully. We highly recommend that you
    /// call this method to test your authentication method as soon as you create your server.
    /// By doing so, you can troubleshoot issues with the API Gateway integration to ensure
    /// that your users can successfully use the service.
    /// </summary>
    [Cmdlet("Test", "TFRIdentityProvider")]
    [OutputType("Amazon.Transfer.Model.TestIdentityProviderResponse")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP TestIdentityProvider API operation.", Operation = new[] {"TestIdentityProvider"})]
    [AWSCmdletOutput("Amazon.Transfer.Model.TestIdentityProviderResponse",
        "This cmdlet returns a Amazon.Transfer.Model.TestIdentityProviderResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestTFRIdentityProviderCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>A system assigned identifier for a specific server. That server's user authentication
        /// method is tested with a user name and password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ServerId { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>This request parameter is name of the user account to be tested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter UserPassword
        /// <summary>
        /// <para>
        /// <para>The password of the user account to be tested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UserPassword { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ServerId = this.ServerId;
            context.UserName = this.UserName;
            context.UserPassword = this.UserPassword;
            
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
            var request = new Amazon.Transfer.Model.TestIdentityProviderRequest();
            
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            if (cmdletContext.UserPassword != null)
            {
                request.UserPassword = cmdletContext.UserPassword;
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
        
        private Amazon.Transfer.Model.TestIdentityProviderResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.TestIdentityProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "TestIdentityProvider");
            try
            {
                #if DESKTOP
                return client.TestIdentityProvider(request);
                #elif CORECLR
                return client.TestIdentityProviderAsync(request).GetAwaiter().GetResult();
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
            public System.String ServerId { get; set; }
            public System.String UserName { get; set; }
            public System.String UserPassword { get; set; }
        }
        
    }
}
