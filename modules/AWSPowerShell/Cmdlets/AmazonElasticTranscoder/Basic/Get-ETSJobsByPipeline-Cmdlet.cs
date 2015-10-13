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
using Amazon.ElasticTranscoder;
using Amazon.ElasticTranscoder.Model;

namespace Amazon.PowerShell.Cmdlets.ETS
{
    /// <summary>
    /// The ListJobsByPipeline operation gets a list of the jobs currently in a pipeline.
    /// 
    ///  
    /// <para>
    /// Elastic Transcoder returns all of the jobs currently in the specified pipeline. The
    /// response body contains one element for each job that satisfies the search criteria.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ETSJobsByPipeline")]
    [OutputType("Amazon.ElasticTranscoder.Model.Job")]
    [AWSCmdlet("Invokes the ListJobsByPipeline operation against Amazon Elastic Transcoder.", Operation = new[] {"ListJobsByPipeline"})]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.Job",
        "This cmdlet returns a collection of Job objects.",
        "The service call response (type Amazon.ElasticTranscoder.Model.ListJobsByPipelineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextPageToken (type System.String)"
    )]
    public class GetETSJobsByPipelineCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> To list jobs in chronological order by the date and time that they were submitted,
        /// enter <code>true</code>. To list jobs in reverse chronological order, enter <code>false</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Ascending { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The ID of the pipeline for which you want to get job information. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PipelineId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> When Elastic Transcoder returns more than one page of results, use <code>pageToken</code>
        /// in subsequent <code>GET</code> requests to get each successive page of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Ascending = this.Ascending;
            context.PageToken = this.PageToken;
            context.PipelineId = this.PipelineId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticTranscoder.Model.ListJobsByPipelineRequest();
            
            if (cmdletContext.Ascending != null)
            {
                request.Ascending = cmdletContext.Ascending;
            }
            if (cmdletContext.PipelineId != null)
            {
                request.PipelineId = cmdletContext.PipelineId;
            }
            
            // Initialize loop variant and commence piping
            System.String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.PageToken))
            {
                _nextMarker = cmdletContext.PageToken;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.PageToken = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.ListJobsByPipeline(request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Jobs;
                        notes = new Dictionary<string, object>();
                        notes["NextPageToken"] = response.NextPageToken;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Jobs.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.PageToken));
                        }
                        
                        _nextMarker = response.NextPageToken;
                    }
                    catch (Exception e)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    
                    ProcessOutput(output);
                    
                } while (AutoIterationHelpers.HasValue(_nextMarker));
            }
            finally
            {
                if (_userControllingPaging)
                {
                    WriteProgressCompleteRecord("Retrieving", "Retrieved records");
                }
            }
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String Ascending { get; set; }
            public System.String PageToken { get; set; }
            public System.String PipelineId { get; set; }
        }
        
    }
}
