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
    /// Describe a <a>BasePathMapping</a> resource.
    /// </summary>
    [Cmdlet("Get", "AGBasePathMapping")]
    [OutputType("Amazon.APIGateway.Model.GetBasePathMappingResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway GetBasePathMapping API operation.", Operation = new[] {"GetBasePathMapping"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetBasePathMappingResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.GetBasePathMappingResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGBasePathMappingCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter BasePath
        /// <summary>
        /// <para>
        /// <para>The base path name that callers of the API must provide as part of the URL after the
        /// domain name. This value must be unique for all of the mappings across a single API.
        /// Leave this blank if you do not want callers to specify any base path name after the
        /// domain name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BasePath { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The domain name of the <a>BasePathMapping</a> resource to be described.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DomainName { get; set; }
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
            
            context.BasePath = this.BasePath;
            context.DomainName = this.DomainName;
            
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
            var request = new Amazon.APIGateway.Model.GetBasePathMappingRequest();
            
            if (cmdletContext.BasePath != null)
            {
                request.BasePath = cmdletContext.BasePath;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
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
        
        private Amazon.APIGateway.Model.GetBasePathMappingResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetBasePathMappingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetBasePathMapping");
            try
            {
                #if DESKTOP
                return client.GetBasePathMapping(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetBasePathMappingAsync(request);
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
            public System.String BasePath { get; set; }
            public System.String DomainName { get; set; }
        }
        
    }
}
