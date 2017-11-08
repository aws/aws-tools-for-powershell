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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Represents a get integration.
    /// </summary>
    [Cmdlet("Get", "AGIntegration")]
    [OutputType("Amazon.APIGateway.Model.GetIntegrationResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway GetIntegration API operation.", Operation = new[] {"GetIntegration"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetIntegrationResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.GetIntegrationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGIntegrationCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter HttpMethod
        /// <summary>
        /// <para>
        /// <para>Specifies a get integration request's HTTP method.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HttpMethod { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>Specifies a get integration request's resource identifier</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The string identifier of the associated <a>RestApi</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
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
            
            context.HttpMethod = this.HttpMethod;
            context.ResourceId = this.ResourceId;
            context.RestApiId = this.RestApiId;
            
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
            var request = new Amazon.APIGateway.Model.GetIntegrationRequest();
            
            if (cmdletContext.HttpMethod != null)
            {
                request.HttpMethod = cmdletContext.HttpMethod;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
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
        
        private Amazon.APIGateway.Model.GetIntegrationResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetIntegration");
            try
            {
                #if DESKTOP
                return client.GetIntegration(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetIntegrationAsync(request);
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
            public System.String HttpMethod { get; set; }
            public System.String ResourceId { get; set; }
            public System.String RestApiId { get; set; }
        }
        
    }
}
