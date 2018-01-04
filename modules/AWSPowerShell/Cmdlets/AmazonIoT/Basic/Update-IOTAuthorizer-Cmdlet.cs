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
    /// Updates an authorizer.
    /// </summary>
    [Cmdlet("Update", "IOTAuthorizer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.UpdateAuthorizerResponse")]
    [AWSCmdlet("Calls the AWS IoT UpdateAuthorizer API operation.", Operation = new[] {"UpdateAuthorizer"})]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateAuthorizerResponse",
        "This cmdlet returns a Amazon.IoT.Model.UpdateAuthorizerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTAuthorizerCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter AuthorizerFunctionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the authorizer's Lambda function.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthorizerFunctionArn { get; set; }
        #endregion
        
        #region Parameter AuthorizerName
        /// <summary>
        /// <para>
        /// <para>The authorizer name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String AuthorizerName { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the update authorizer request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.IoT.AuthorizerStatus")]
        public Amazon.IoT.AuthorizerStatus Status { get; set; }
        #endregion
        
        #region Parameter TokenKeyName
        /// <summary>
        /// <para>
        /// <para>The key used to extract the token from the HTTP headers. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TokenKeyName { get; set; }
        #endregion
        
        #region Parameter TokenSigningPublicKey
        /// <summary>
        /// <para>
        /// <para>The public keys used to verify the token signature.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TokenSigningPublicKeys")]
        public System.Collections.Hashtable TokenSigningPublicKey { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AuthorizerName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTAuthorizer (UpdateAuthorizer)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AuthorizerFunctionArn = this.AuthorizerFunctionArn;
            context.AuthorizerName = this.AuthorizerName;
            context.Status = this.Status;
            context.TokenKeyName = this.TokenKeyName;
            if (this.TokenSigningPublicKey != null)
            {
                context.TokenSigningPublicKeys = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TokenSigningPublicKey.Keys)
                {
                    context.TokenSigningPublicKeys.Add((String)hashKey, (String)(this.TokenSigningPublicKey[hashKey]));
                }
            }
            
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
            var request = new Amazon.IoT.Model.UpdateAuthorizerRequest();
            
            if (cmdletContext.AuthorizerFunctionArn != null)
            {
                request.AuthorizerFunctionArn = cmdletContext.AuthorizerFunctionArn;
            }
            if (cmdletContext.AuthorizerName != null)
            {
                request.AuthorizerName = cmdletContext.AuthorizerName;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TokenKeyName != null)
            {
                request.TokenKeyName = cmdletContext.TokenKeyName;
            }
            if (cmdletContext.TokenSigningPublicKeys != null)
            {
                request.TokenSigningPublicKeys = cmdletContext.TokenSigningPublicKeys;
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
        
        private Amazon.IoT.Model.UpdateAuthorizerResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateAuthorizerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateAuthorizer");
            try
            {
                #if DESKTOP
                return client.UpdateAuthorizer(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateAuthorizerAsync(request);
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
            public System.String AuthorizerFunctionArn { get; set; }
            public System.String AuthorizerName { get; set; }
            public Amazon.IoT.AuthorizerStatus Status { get; set; }
            public System.String TokenKeyName { get; set; }
            public Dictionary<System.String, System.String> TokenSigningPublicKeys { get; set; }
        }
        
    }
}
