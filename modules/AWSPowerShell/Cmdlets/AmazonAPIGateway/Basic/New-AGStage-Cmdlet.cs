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
    /// Creates a new <a>Stage</a> resource that references a pre-existing <a>Deployment</a>
    /// for the API.
    /// </summary>
    [Cmdlet("New", "AGStage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateStageResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateStage API operation.", Operation = new[] {"CreateStage"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateStageResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateStageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAGStageCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter CacheClusterEnabled
        /// <summary>
        /// <para>
        /// <para>Whether cache clustering is enabled for the stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean CacheClusterEnabled { get; set; }
        #endregion
        
        #region Parameter CacheClusterSize
        /// <summary>
        /// <para>
        /// <para>The stage's cache cluster size.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.APIGateway.CacheClusterSize")]
        public Amazon.APIGateway.CacheClusterSize CacheClusterSize { get; set; }
        #endregion
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the <a>Deployment</a> resource for the <a>Stage</a> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the <a>Stage</a> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DocumentationVersion
        /// <summary>
        /// <para>
        /// <para>The version of the associated API documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DocumentationVersion { get; set; }
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
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name for the <a>Stage</a> resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StageName { get; set; }
        #endregion
        
        #region Parameter Variable
        /// <summary>
        /// <para>
        /// <para>A map that defines the stage variables for the new <a>Stage</a> resource. Variable
        /// names can have alphanumeric and underscore characters, and the values must match <code>[A-Za-z0-9-._~:/?#&amp;=,]+</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Variables")]
        public System.Collections.Hashtable Variable { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StageName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGStage (CreateStage)"))
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
            
            if (ParameterWasBound("CacheClusterEnabled"))
                context.CacheClusterEnabled = this.CacheClusterEnabled;
            context.CacheClusterSize = this.CacheClusterSize;
            context.DeploymentId = this.DeploymentId;
            context.Description = this.Description;
            context.DocumentationVersion = this.DocumentationVersion;
            context.RestApiId = this.RestApiId;
            context.StageName = this.StageName;
            if (this.Variable != null)
            {
                context.Variables = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Variable.Keys)
                {
                    context.Variables.Add((String)hashKey, (String)(this.Variable[hashKey]));
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
            var request = new Amazon.APIGateway.Model.CreateStageRequest();
            
            if (cmdletContext.CacheClusterEnabled != null)
            {
                request.CacheClusterEnabled = cmdletContext.CacheClusterEnabled.Value;
            }
            if (cmdletContext.CacheClusterSize != null)
            {
                request.CacheClusterSize = cmdletContext.CacheClusterSize;
            }
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DocumentationVersion != null)
            {
                request.DocumentationVersion = cmdletContext.DocumentationVersion;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.StageName != null)
            {
                request.StageName = cmdletContext.StageName;
            }
            if (cmdletContext.Variables != null)
            {
                request.Variables = cmdletContext.Variables;
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
        
        private Amazon.APIGateway.Model.CreateStageResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateStageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateStage");
            try
            {
                #if DESKTOP
                return client.CreateStage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateStageAsync(request);
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
            public System.Boolean? CacheClusterEnabled { get; set; }
            public Amazon.APIGateway.CacheClusterSize CacheClusterSize { get; set; }
            public System.String DeploymentId { get; set; }
            public System.String Description { get; set; }
            public System.String DocumentationVersion { get; set; }
            public System.String RestApiId { get; set; }
            public System.String StageName { get; set; }
            public Dictionary<System.String, System.String> Variables { get; set; }
        }
        
    }
}
