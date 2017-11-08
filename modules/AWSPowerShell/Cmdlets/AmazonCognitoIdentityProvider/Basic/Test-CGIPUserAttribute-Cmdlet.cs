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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Verifies the specified user attributes in the user pool.
    /// </summary>
    [Cmdlet("Test", "CGIPUserAttribute")]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider VerifyUserAttribute API operation. This operation uses anonymous authentication and does not require credential parameters to be supplied.", Operation = new[] {"VerifyUserAttribute"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AccessToken parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CognitoIdentityProvider.Model.VerifyUserAttributeResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestCGIPUserAttributeCmdlet : AnonymousAmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AccessToken
        /// <summary>
        /// <para>
        /// <para>Represents the access token of the request to verify user attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AccessToken { get; set; }
        #endregion
        
        #region Parameter AttributeName
        /// <summary>
        /// <para>
        /// <para>The attribute name in the request to verify user attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttributeName { get; set; }
        #endregion
        
        #region Parameter Code
        /// <summary>
        /// <para>
        /// <para>The verification code in the request to verify user attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Code { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the AccessToken parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AccessToken = this.AccessToken;
            context.AttributeName = this.AttributeName;
            context.Code = this.Code;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.VerifyUserAttributeRequest();
            
            if (cmdletContext.AccessToken != null)
            {
                request.AccessToken = cmdletContext.AccessToken;
            }
            if (cmdletContext.AttributeName != null)
            {
                request.AttributeName = cmdletContext.AttributeName;
            }
            if (cmdletContext.Code != null)
            {
                request.Code = cmdletContext.Code;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.AccessToken;
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
        
        private Amazon.CognitoIdentityProvider.Model.VerifyUserAttributeResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.VerifyUserAttributeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "VerifyUserAttribute");
            try
            {
                #if DESKTOP
                return client.VerifyUserAttribute(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.VerifyUserAttributeAsync(request);
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
            public System.String AccessToken { get; set; }
            public System.String AttributeName { get; set; }
            public System.String Code { get; set; }
        }
        
    }
}
