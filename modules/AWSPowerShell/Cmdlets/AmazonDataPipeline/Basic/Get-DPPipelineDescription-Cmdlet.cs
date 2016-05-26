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
using Amazon.DataPipeline;
using Amazon.DataPipeline.Model;

namespace Amazon.PowerShell.Cmdlets.DP
{
    /// <summary>
    /// Retrieves metadata about one or more pipelines. The information retrieved includes
    /// the name of the pipeline, the pipeline identifier, its current state, and the user
    /// account that owns the pipeline. Using account credentials, you can retrieve metadata
    /// about pipelines that you or your IAM users have created. If you are using an IAM user
    /// account, you can retrieve metadata about only those pipelines for which you have read
    /// permissions.
    /// 
    ///  
    /// <para>
    /// To retrieve the full pipeline definition instead of metadata about the pipeline, call
    /// <a>GetPipelineDefinition</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DPPipelineDescription")]
    [OutputType("Amazon.DataPipeline.Model.PipelineDescription")]
    [AWSCmdlet("Invokes the DescribePipelines operation against AWS Data Pipeline.", Operation = new[] {"DescribePipelines"})]
    [AWSCmdletOutput("Amazon.DataPipeline.Model.PipelineDescription",
        "This cmdlet returns a collection of PipelineDescription objects.",
        "The service call response (type Amazon.DataPipeline.Model.DescribePipelinesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetDPPipelineDescriptionCmdlet : AmazonDataPipelineClientCmdlet, IExecutor
    {
        
        #region Parameter PipelineId
        /// <summary>
        /// <para>
        /// <para>The IDs of the pipelines to describe. You can pass as many as 25 identifiers in a
        /// single call. To obtain pipeline IDs, call <a>ListPipelines</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("PipelineIds")]
        public System.String[] PipelineId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.PipelineId != null)
            {
                context.PipelineIds = new List<System.String>(this.PipelineId);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DataPipeline.Model.DescribePipelinesRequest();
            
            if (cmdletContext.PipelineIds != null)
            {
                request.PipelineIds = cmdletContext.PipelineIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.PipelineDescriptionList;
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
        
        private static Amazon.DataPipeline.Model.DescribePipelinesResponse CallAWSServiceOperation(IAmazonDataPipeline client, Amazon.DataPipeline.Model.DescribePipelinesRequest request)
        {
            return client.DescribePipelines(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> PipelineIds { get; set; }
        }
        
    }
}
