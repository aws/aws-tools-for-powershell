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
    /// Creates a <a>Deployment</a> resource, which makes a specified <a>RestApi</a> callable
    /// over the internet.
    /// </summary>
    [Cmdlet("New", "AGDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateDeploymentResponse")]
    [AWSCmdlet("Invokes the CreateDeployment operation against Amazon API Gateway.", Operation = new[] {"CreateDeployment"})]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateDeploymentResponse",
        "This cmdlet returns a Amazon.APIGateway.Model.CreateDeploymentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewAGDeploymentCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>Enables a cache cluster for the <a>Stage</a> resource specified in the input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean CacheClusterEnabled { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Specifies the cache cluster size for the <a>Stage</a> resource specified in the input,
        /// if a cache cluster is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.APIGateway.CacheClusterSize CacheClusterSize { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The description for the <a>Deployment</a> resource to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The <a>RestApi</a> resource identifier for the <a>Deployment</a> resource to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String RestApiId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The description of the <a>Stage</a> resource for the <a>Deployment</a> resource to
        /// create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StageDescription { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the <a>Stage</a> resource for the <a>Deployment</a> resource to create.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StageName { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StageName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGDeployment (CreateDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("CacheClusterEnabled"))
                context.CacheClusterEnabled = this.CacheClusterEnabled;
            context.CacheClusterSize = this.CacheClusterSize;
            context.Description = this.Description;
            context.RestApiId = this.RestApiId;
            context.StageDescription = this.StageDescription;
            context.StageName = this.StageName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.APIGateway.Model.CreateDeploymentRequest();
            
            if (cmdletContext.CacheClusterEnabled != null)
            {
                request.CacheClusterEnabled = cmdletContext.CacheClusterEnabled.Value;
            }
            if (cmdletContext.CacheClusterSize != null)
            {
                request.CacheClusterSize = cmdletContext.CacheClusterSize;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.StageDescription != null)
            {
                request.StageDescription = cmdletContext.StageDescription;
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
                var response = client.CreateDeployment(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.Boolean? CacheClusterEnabled { get; set; }
            public Amazon.APIGateway.CacheClusterSize CacheClusterSize { get; set; }
            public System.String Description { get; set; }
            public System.String RestApiId { get; set; }
            public System.String StageDescription { get; set; }
            public System.String StageName { get; set; }
        }
        
    }
}
