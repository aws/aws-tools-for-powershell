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
    /// Gets information about the current <a>ApiKeys</a> resource.
    /// </summary>
    [Cmdlet("Get", "AGApiKeyList")]
    [OutputType("Amazon.APIGateway.Model.GetApiKeysResponse")]
    [AWSCmdlet("Invokes the GetApiKeys operation against Amazon API Gateway.", Operation = new[] {"GetApiKeys"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetApiKeysResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.GetApiKeysResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGApiKeyListCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter CustomerId
        /// <summary>
        /// <para>
        /// <para>The identifier of a customer in AWS Marketplace or an external system, such as a developer
        /// portal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomerId { get; set; }
        #endregion
        
        #region Parameter IncludeValue
        /// <summary>
        /// <para>
        /// <para>A boolean flag to specify whether (<code>true</code>) or not (<code>false</code>)
        /// the result contains key values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("IncludeValues")]
        public System.Boolean IncludeValue { get; set; }
        #endregion
        
        #region Parameter NameQuery
        /// <summary>
        /// <para>
        /// <para>The name of queried API keys.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NameQuery { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of returned results per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public System.Int32 Limit { get; set; }
        #endregion
        
        #region Parameter Position
        /// <summary>
        /// <para>
        /// <para>The current pagination position in the paged result set.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String Position { get; set; }
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
            
            context.CustomerId = this.CustomerId;
            if (ParameterWasBound("IncludeValue"))
                context.IncludeValues = this.IncludeValue;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.NameQuery = this.NameQuery;
            context.Position = this.Position;
            
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
            var request = new Amazon.APIGateway.Model.GetApiKeysRequest();
            
            if (cmdletContext.CustomerId != null)
            {
                request.CustomerId = cmdletContext.CustomerId;
            }
            if (cmdletContext.IncludeValues != null)
            {
                request.IncludeValues = cmdletContext.IncludeValues.Value;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
            }
            if (cmdletContext.NameQuery != null)
            {
                request.NameQuery = cmdletContext.NameQuery;
            }
            if (cmdletContext.Position != null)
            {
                request.Position = cmdletContext.Position;
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
        
        private Amazon.APIGateway.Model.GetApiKeysResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetApiKeysRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetApiKeys");
            #if DESKTOP
            return client.GetApiKeys(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.GetApiKeysAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String CustomerId { get; set; }
            public System.Boolean? IncludeValues { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NameQuery { get; set; }
            public System.String Position { get; set; }
        }
        
    }
}
