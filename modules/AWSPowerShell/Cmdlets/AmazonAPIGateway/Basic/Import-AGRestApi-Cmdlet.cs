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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// A feature of the API Gateway control service for creating a new API from an external
    /// API definition file.
    /// </summary>
    [Cmdlet("Import", "AGRestApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.ImportRestApiResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway ImportRestApi API operation.", Operation = new[] {"ImportRestApi"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.ImportRestApiResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.ImportRestApiResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ImportAGRestApiCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter Body
        /// <summary>
        /// <para>
        /// <para>[Required] The POST request body containing external API definitions. Currently, only
        /// Swagger definition JSON files are supported. The maximum size of the API definition
        /// file is 2MB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.IO.MemoryStream Body { get; set; }
        #endregion
        
        #region Parameter FailOnWarning
        /// <summary>
        /// <para>
        /// <para>A query parameter to indicate whether to rollback the API creation (<code>true</code>)
        /// or not (<code>false</code>) when a warning is encountered. The default value is <code>false</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("FailOnWarnings")]
        public System.Boolean FailOnWarning { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A key-value map of context-specific query string parameters specifying the behavior
        /// of different API importing operations. The following shows operation-specific parameters
        /// and their supported values.</para><para> To exclude <a>DocumentationParts</a> from the import, set <code>parameters</code>
        /// as <code>ignore=documentation</code>.</para><para> To configure the endpoint type, set <code>parameters</code> as <code>endpointConfigurationTypes=EDGE</code>,
        /// <code>endpointConfigurationTypes=REGIONAL</code>, or <code>endpointConfigurationTypes=PRIVATE</code>.
        /// The default endpoint type is <code>EDGE</code>.</para><para> To handle imported <code>basePath</code>, set <code>parameters</code> as <code>basePath=ignore</code>,
        /// <code>basePath=prepend</code> or <code>basePath=split</code>.</para><para>For example, the AWS CLI command to exclude documentation from the imported API is:</para><pre><code>aws apigateway import-rest-api --parameters ignore=documentation --body
        /// 'file:///path/to/imported-api-body.json'</code></pre><para>The AWS CLI command to set the regional endpoint on the imported API is:</para><pre><code>aws apigateway import-rest-api --parameters endpointConfigurationTypes=REGIONAL
        /// --body 'file:///path/to/imported-api-body.json'</code></pre>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Parameter", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-AGRestApi (ImportRestApi)"))
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
            
            context.Body = this.Body;
            if (ParameterWasBound("FailOnWarning"))
                context.FailOnWarnings = this.FailOnWarning;
            if (this.Parameter != null)
            {
                context.Parameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameters.Add((String)hashKey, (String)(this.Parameter[hashKey]));
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
            var request = new Amazon.APIGateway.Model.ImportRestApiRequest();
            
            if (cmdletContext.Body != null)
            {
                request.Body = cmdletContext.Body;
            }
            if (cmdletContext.FailOnWarnings != null)
            {
                request.FailOnWarnings = cmdletContext.FailOnWarnings.Value;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
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
        
        private Amazon.APIGateway.Model.ImportRestApiResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.ImportRestApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "ImportRestApi");
            try
            {
                #if DESKTOP
                return client.ImportRestApi(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ImportRestApiAsync(request);
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
            public System.IO.MemoryStream Body { get; set; }
            public System.Boolean? FailOnWarnings { get; set; }
            public Dictionary<System.String, System.String> Parameters { get; set; }
        }
        
    }
}
