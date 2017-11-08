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
    /// Exports a deployed version of a <a>RestApi</a> in a specified format.
    /// </summary>
    [Cmdlet("Get", "AGExport")]
    [OutputType("Amazon.APIGateway.Model.GetExportResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway GetExport API operation.", Operation = new[] {"GetExport"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetExportResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.GetExportResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGExportCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The content-type of the export, for example <code>application/json</code>. Currently
        /// <code>application/json</code> and <code>application/yaml</code> are supported for
        /// <code>exportType</code> of <code>swagger</code>. This should be specified in the <code>Accept</code>
        /// header for direct API requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Accepts")]
        public System.String Accept { get; set; }
        #endregion
        
        #region Parameter ExportType
        /// <summary>
        /// <para>
        /// <para>The type of export. Currently only 'swagger' is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExportType { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A key-value map of query string parameters that specify properties of the export,
        /// depending on the requested <code>exportType</code>. For <code>exportType</code><code>swagger</code>,
        /// any combination of the following parameters are supported: <code>integrations</code>
        /// will export the API with x-amazon-apigateway-integration extensions. <code>authorizers</code>
        /// will export the API with x-amazon-apigateway-authorizer extensions. <code>postman</code>
        /// will export the API with Postman extensions, allowing for import to the Postman tool</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The string identifier of the associated <a>RestApi</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the <a>Stage</a> that will be exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StageName { get; set; }
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
            
            context.Accepts = this.Accept;
            context.ExportType = this.ExportType;
            if (this.Parameter != null)
            {
                context.Parameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameters.Add((String)hashKey, (String)(this.Parameter[hashKey]));
                }
            }
            context.RestApiId = this.RestApiId;
            context.StageName = this.StageName;
            
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
            var request = new Amazon.APIGateway.Model.GetExportRequest();
            
            if (cmdletContext.Accepts != null)
            {
                request.Accepts = cmdletContext.Accepts;
            }
            if (cmdletContext.ExportType != null)
            {
                request.ExportType = cmdletContext.ExportType;
            }
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.StageName != null)
            {
                request.StageName = cmdletContext.StageName;
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
        
        private Amazon.APIGateway.Model.GetExportResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetExportRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetExport");
            try
            {
                #if DESKTOP
                return client.GetExport(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetExportAsync(request);
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
            public System.String Accepts { get; set; }
            public System.String ExportType { get; set; }
            public Dictionary<System.String, System.String> Parameters { get; set; }
            public System.String RestApiId { get; set; }
            public System.String StageName { get; set; }
        }
        
    }
}
