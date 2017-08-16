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
    /// Generates a client SDK for a <a>RestApi</a> and <a>Stage</a>.
    /// </summary>
    [Cmdlet("Get", "AGSdk")]
    [OutputType("Amazon.APIGateway.Model.GetSdkResponse")]
    [AWSCmdlet("Invokes the GetSdk operation against Amazon API Gateway.", Operation = new[] {"GetSdk"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetSdkResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.GetSdkResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGSdkCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A key-value map of query string parameters that specify properties of the SDK, depending
        /// on the requested <code>sdkType</code>. For <code>sdkType</code> of <code>objectivec</code>,
        /// a parameter named <code>classPrefix</code> is required. For <code>sdkType</code> of
        /// <code>android</code>, parameters named <code>groupId</code>, <code>artifactId</code>,
        /// <code>artifactVersion</code>, and <code>invokerPackage</code> are required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
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
        
        #region Parameter SdkType
        /// <summary>
        /// <para>
        /// <para>The language for the generated SDK. Currently <code>javascript</code>, <code>android</code>,
        /// and <code>objectivec</code> (for iOS) are supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SdkType { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the <a>Stage</a> that the SDK will use.</para>
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
            
            if (this.Parameter != null)
            {
                context.Parameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameters.Add((String)hashKey, (String)(this.Parameter[hashKey]));
                }
            }
            context.RestApiId = this.RestApiId;
            context.SdkType = this.SdkType;
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
            var request = new Amazon.APIGateway.Model.GetSdkRequest();
            
            if (cmdletContext.Parameters != null)
            {
                request.Parameters = cmdletContext.Parameters;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.SdkType != null)
            {
                request.SdkType = cmdletContext.SdkType;
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
        
        private Amazon.APIGateway.Model.GetSdkResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetSdkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetSdk");
            try
            {
                #if DESKTOP
                return client.GetSdk(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetSdkAsync(request);
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
            public Dictionary<System.String, System.String> Parameters { get; set; }
            public System.String RestApiId { get; set; }
            public System.String SdkType { get; set; }
            public System.String StageName { get; set; }
        }
        
    }
}
