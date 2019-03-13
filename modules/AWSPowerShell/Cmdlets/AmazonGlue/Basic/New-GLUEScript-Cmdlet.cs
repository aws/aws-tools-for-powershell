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
using Amazon.Glue;
using Amazon.Glue.Model;

namespace Amazon.PowerShell.Cmdlets.GLUE
{
    /// <summary>
    /// Transforms a directed acyclic graph (DAG) into code.
    /// </summary>
    [Cmdlet("New", "GLUEScript", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Glue.Model.CreateScriptResponse")]
    [AWSCmdlet("Calls the AWS Glue CreateScript API operation.", Operation = new[] {"CreateScript"})]
    [AWSCmdletOutput("Amazon.Glue.Model.CreateScriptResponse",
        "This cmdlet returns a Amazon.Glue.Model.CreateScriptResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewGLUEScriptCmdlet : AmazonGlueClientCmdlet, IExecutor
    {
        
        #region Parameter DagEdge
        /// <summary>
        /// <para>
        /// <para>A list of the edges in the DAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DagEdges")]
        public Amazon.Glue.Model.CodeGenEdge[] DagEdge { get; set; }
        #endregion
        
        #region Parameter DagNode
        /// <summary>
        /// <para>
        /// <para>A list of the nodes in the DAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DagNodes")]
        public Amazon.Glue.Model.CodeGenNode[] DagNode { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The programming language of the resulting code from the DAG.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Glue.Language")]
        public Amazon.Glue.Language Language { get; set; }
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GLUEScript (CreateScript)"))
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
            
            if (this.DagEdge != null)
            {
                context.DagEdges = new List<Amazon.Glue.Model.CodeGenEdge>(this.DagEdge);
            }
            if (this.DagNode != null)
            {
                context.DagNodes = new List<Amazon.Glue.Model.CodeGenNode>(this.DagNode);
            }
            context.Language = this.Language;
            
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
            var request = new Amazon.Glue.Model.CreateScriptRequest();
            
            if (cmdletContext.DagEdges != null)
            {
                request.DagEdges = cmdletContext.DagEdges;
            }
            if (cmdletContext.DagNodes != null)
            {
                request.DagNodes = cmdletContext.DagNodes;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
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
        
        private Amazon.Glue.Model.CreateScriptResponse CallAWSServiceOperation(IAmazonGlue client, Amazon.Glue.Model.CreateScriptRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue", "CreateScript");
            try
            {
                #if DESKTOP
                return client.CreateScript(request);
                #elif CORECLR
                return client.CreateScriptAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Glue.Model.CodeGenEdge> DagEdges { get; set; }
            public List<Amazon.Glue.Model.CodeGenNode> DagNodes { get; set; }
            public Amazon.Glue.Language Language { get; set; }
        }
        
    }
}
