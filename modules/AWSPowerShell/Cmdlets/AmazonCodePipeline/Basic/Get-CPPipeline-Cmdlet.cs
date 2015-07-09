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
using Amazon.CodePipeline;
using Amazon.CodePipeline.Model;

namespace Amazon.PowerShell.Cmdlets.CP
{
    /// <summary>
    /// Returns the metadata, structure, stages, and actions of a pipeline. Can be used to
    /// return the entire structure of a pipeline in JSON format, which can then be modified
    /// and used to update the pipeline structure with <a>UpdatePipeline</a>.
    /// </summary>
    [Cmdlet("Get", "CPPipeline")]
    [OutputType("Amazon.CodePipeline.Model.PipelineDeclaration")]
    [AWSCmdlet("Invokes the GetPipeline operation against AWS CodePipeline.", Operation = new[] {"GetPipeline"})]
    [AWSCmdletOutput("Amazon.CodePipeline.Model.PipelineDeclaration",
        "This cmdlet returns a PipelineDeclaration object.",
        "The service call response (type GetPipelineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetCPPipelineCmdlet : AmazonCodePipelineClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the pipeline for which you want to get information. Pipeline names must
        /// be unique under an Amazon Web Services (AWS) user account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The version number of the pipeline. If you do not specify a version, defaults to the
        /// most current version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Int32 Version { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Name = this.Name;
            if (ParameterWasBound("Version"))
                context.Version = this.Version;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new GetPipelineRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.GetPipeline(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Pipeline;
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
            public String Name { get; set; }
            public Int32? Version { get; set; }
        }
        
    }
}
