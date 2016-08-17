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
    /// Gets a usage plan key of a given key identifier.
    /// </summary>
    [Cmdlet("Get", "AGUsagePlanKey")]
    [OutputType("Amazon.APIGateway.Model.GetUsagePlanKeyResponse")]
    [AWSCmdlet("Invokes the GetUsagePlanKey operation against Amazon API Gateway.", Operation = new[] {"GetUsagePlanKey"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetUsagePlanKeyResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.GetUsagePlanKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGUsagePlanKeyCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter KeyId
        /// <summary>
        /// <para>
        /// <para>The key Id of the to-be-retrieved <a>UsagePlanKey</a> resource representing a plan
        /// customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KeyId { get; set; }
        #endregion
        
        #region Parameter UsagePlanId
        /// <summary>
        /// <para>
        /// <para>The Id of the <a>UsagePlan</a> resource representing the usage plan containing the
        /// to-be-retrieved <a>UsagePlanKey</a> resource representing a plan customer.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UsagePlanId { get; set; }
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
            
            context.KeyId = this.KeyId;
            context.UsagePlanId = this.UsagePlanId;
            
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
            var request = new Amazon.APIGateway.Model.GetUsagePlanKeyRequest();
            
            if (cmdletContext.KeyId != null)
            {
                request.KeyId = cmdletContext.KeyId;
            }
            if (cmdletContext.UsagePlanId != null)
            {
                request.UsagePlanId = cmdletContext.UsagePlanId;
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
        
        private static Amazon.APIGateway.Model.GetUsagePlanKeyResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetUsagePlanKeyRequest request)
        {
            #if DESKTOP
            return client.GetUsagePlanKey(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetUsagePlanKeyAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String KeyId { get; set; }
            public System.String UsagePlanId { get; set; }
        }
        
    }
}
