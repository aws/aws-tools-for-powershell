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
    /// Create an <a>ApiKey</a> resource. 
    /// 
    ///  <div class="seeAlso"><a href="http://docs.aws.amazon.com/cli/latest/reference/apigateway/create-api-key.html">AWS
    /// CLI</a></div>
    /// </summary>
    [Cmdlet("New", "AGApiKey", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateApiKeyResponse")]
    [AWSCmdlet("Invokes the CreateApiKey operation against Amazon API Gateway.", Operation = new[] {"CreateApiKey"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateApiKeyResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateApiKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAGApiKeyCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter CustomerId
        /// <summary>
        /// <para>
        /// <para>An AWS Marketplace customer identifier , when integrating with the AWS SaaS Marketplace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomerId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the <a>ApiKey</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the <a>ApiKey</a> can be used by callers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Enabled { get; set; }
        #endregion
        
        #region Parameter GenerateDistinctId
        /// <summary>
        /// <para>
        /// <para>Specifies whether (<code>true</code>) or not (<code>false</code>) the key identifier
        /// is distinct from the created API key value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean GenerateDistinctId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the <a>ApiKey</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StageKey
        /// <summary>
        /// <para>
        /// <para>DEPRECATED FOR USAGE PLANS - Specifies stages associated with the API key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StageKeys")]
        public Amazon.APIGateway.Model.StageKey[] StageKey { get; set; }
        #endregion
        
        #region Parameter Value
        /// <summary>
        /// <para>
        /// <para>Specifies a value of the API key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Value { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Value", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGApiKey (CreateApiKey)"))
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
            
            context.CustomerId = this.CustomerId;
            context.Description = this.Description;
            if (ParameterWasBound("Enabled"))
                context.Enabled = this.Enabled;
            if (ParameterWasBound("GenerateDistinctId"))
                context.GenerateDistinctId = this.GenerateDistinctId;
            context.Name = this.Name;
            if (this.StageKey != null)
            {
                context.StageKeys = new List<Amazon.APIGateway.Model.StageKey>(this.StageKey);
            }
            context.Value = this.Value;
            
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
            var request = new Amazon.APIGateway.Model.CreateApiKeyRequest();
            
            if (cmdletContext.CustomerId != null)
            {
                request.CustomerId = cmdletContext.CustomerId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.GenerateDistinctId != null)
            {
                request.GenerateDistinctId = cmdletContext.GenerateDistinctId.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.StageKeys != null)
            {
                request.StageKeys = cmdletContext.StageKeys;
            }
            if (cmdletContext.Value != null)
            {
                request.Value = cmdletContext.Value;
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
        
        private static Amazon.APIGateway.Model.CreateApiKeyResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateApiKeyRequest request)
        {
            #if DESKTOP
            return client.CreateApiKey(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.CreateApiKeyAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String CustomerId { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.Boolean? GenerateDistinctId { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.APIGateway.Model.StageKey> StageKeys { get; set; }
            public System.String Value { get; set; }
        }
        
    }
}
