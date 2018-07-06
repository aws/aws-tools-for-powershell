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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Tests a custom authorization behavior by invoking a specified custom authorizer. Use
    /// this to test and debug the custom authorization behavior of devices that connect to
    /// the AWS IoT device gateway.
    /// </summary>
    [Cmdlet("Test", "IOTInvokeAuthorizer")]
    [OutputType("Amazon.IoT.Model.TestInvokeAuthorizerResponse")]
    [AWSCmdlet("Calls the AWS IoT TestInvokeAuthorizer API operation.", Operation = new[] {"TestInvokeAuthorizer"})]
    [AWSCmdletOutput("Amazon.IoT.Model.TestInvokeAuthorizerResponse",
        "This cmdlet returns a Amazon.IoT.Model.TestInvokeAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestIOTInvokeAuthorizerCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorizerName
        /// <summary>
        /// <para>
        /// <para>The custom authorizer name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthorizerName { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>The token returned by your custom authentication service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter TokenSignature
        /// <summary>
        /// <para>
        /// <para>The signature made with the token and your custom authentication service's private
        /// key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TokenSignature { get; set; }
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
            
            context.AuthorizerName = this.AuthorizerName;
            context.Token = this.Token;
            context.TokenSignature = this.TokenSignature;
            
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
            var request = new Amazon.IoT.Model.TestInvokeAuthorizerRequest();
            
            if (cmdletContext.AuthorizerName != null)
            {
                request.AuthorizerName = cmdletContext.AuthorizerName;
            }
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
            }
            if (cmdletContext.TokenSignature != null)
            {
                request.TokenSignature = cmdletContext.TokenSignature;
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
        
        private Amazon.IoT.Model.TestInvokeAuthorizerResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.TestInvokeAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "TestInvokeAuthorizer");
            try
            {
                #if DESKTOP
                return client.TestInvokeAuthorizer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.TestInvokeAuthorizerAsync(request);
                return task.Result;
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
            public System.String AuthorizerName { get; set; }
            public System.String Token { get; set; }
            public System.String TokenSignature { get; set; }
        }
        
    }
}
