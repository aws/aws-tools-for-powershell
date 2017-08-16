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
    /// The ListJobsByStatus operation gets a list of jobs that have a specified status. The
    /// response body contains one element for each job that satisfies the search criteria.<br/><br/>This operation automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output.
    /// </summary>
    [Cmdlet("Get", "ETSJobsByStatus")]
    [OutputType("Amazon.ElasticTranscoder.Model.Job")]
    [AWSCmdlet("Invokes the ListJobsByStatus operation against Amazon Elastic Transcoder.", Operation = new[] {"ListJobsByStatus"})]
    [AWSCmdletOutput("Amazon.ElasticTranscoder.Model.Job",
        "This cmdlet returns a collection of Job objects.",
        "The service call response (type Amazon.ElasticTranscoder.Model.ListJobsByStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: NextPageToken (type System.String)"
    )]
    public partial class GetETSJobsByStatusCmdlet : AmazonElasticTranscoderClientCmdlet, IExecutor
    {
        
        #region Parameter Ascending
        /// <summary>
        /// <para>
        /// <para> To list jobs in chronological order by the date and time that they were submitted,
        /// enter <code>true</code>. To list jobs in reverse chronological order, enter <code>false</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Ascending { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>To get information about all of the jobs associated with the current AWS account that
        /// have a given status, specify the following status: <code>Submitted</code>, <code>Progressing</code>,
        /// <code>Complete</code>, <code>Canceled</code>, or <code>Error</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Status { get; set; }
        #endregion
        
        #region Parameter PageToken
        /// <summary>
        /// <para>
        /// <para> When Elastic Transcoder returns more than one page of results, use <code>pageToken</code>
        /// in subsequent <code>GET</code> requests to get each successive page of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public System.String PageToken { get; set; }
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
            
            context.Ascending = this.Ascending;
            context.PageToken = this.PageToken;
            context.Status = this.Status;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new Amazon.ElasticTranscoder.Model.ListJobsByStatusRequest();
            
            if (cmdletContext.Ascending != null)
            {
                request.Ascending = cmdletContext.Ascending;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
                        
                        var response = CallAWSServiceOperation(client, request);
                        
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
        
        #region AWS Service Operation Call
        
        private Amazon.ElasticTranscoder.Model.ListJobsByStatusResponse CallAWSServiceOperation(IAmazonElasticTranscoder client, Amazon.ElasticTranscoder.Model.ListJobsByStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Transcoder", "ListJobsByStatus");
            try
            {
                #if DESKTOP
                return client.ListJobsByStatus(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListJobsByStatusAsync(request);
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
            public System.String Ascending { get; set; }
            public System.String PageToken { get; set; }
            public System.String Status { get; set; }
        }
        
    }
}
