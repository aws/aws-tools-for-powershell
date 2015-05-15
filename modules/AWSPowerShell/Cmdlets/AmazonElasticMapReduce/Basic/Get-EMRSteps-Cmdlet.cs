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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Provides a list of steps for the cluster.
    /// </summary>
    [Cmdlet("Get", "EMRSteps")]
    [OutputType("Amazon.ElasticMapReduce.Model.StepSummary")]
    [AWSCmdlet("Invokes the ListSteps operation against Amazon Elastic MapReduce.", Operation = new[] {"ListSteps"})]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.StepSummary",
        "This cmdlet returns a collection of StepSummary objects.",
        "The service call response (type ListStepsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: Marker (type String)"
    )]
    public class GetEMRStepsCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster for which to list the steps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ClusterId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The filter to limit the step list based on the identifier of the steps.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StepIds")]
        public System.String[] StepId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The filter to limit the step list based on certain states.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("StepStates")]
        public System.String[] StepState { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("NextToken")]
        public String Marker { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.ClusterId = this.ClusterId;
            context.Marker = this.Marker;
            if (this.StepId != null)
            {
                context.StepIds = new List<String>(this.StepId);
            }
            if (this.StepState != null)
            {
                context.StepStates = new List<String>(this.StepState);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            
            // create request and set iteration invariants
            var request = new ListStepsRequest();
            
            if (cmdletContext.ClusterId != null)
            {
                request.ClusterId = cmdletContext.ClusterId;
            }
            if (cmdletContext.StepIds != null)
            {
                request.StepIds = cmdletContext.StepIds;
            }
            if (cmdletContext.StepStates != null)
            {
                request.StepStates = cmdletContext.StepStates;
            }
            
            // Initialize loop variant and commence piping
            String _nextMarker = null;
            bool _userControllingPaging = false;
            if (AutoIterationHelpers.HasValue(cmdletContext.Marker))
            {
                _nextMarker = cmdletContext.Marker;
                _userControllingPaging = true;
            }
            
            try
            {
                do
                {
                    request.Marker = _nextMarker;
                    
                    var client = Client ?? CreateClient(context.Credentials, context.Region);
                    CmdletOutput output;
                    
                    try
                    {
                        
                        var response = client.ListSteps(request);
                        
                        Dictionary<string, object> notes = null;
                        object pipelineOutput = response.Steps;
                        notes = new Dictionary<string, object>();
                        notes["Marker"] = response.Marker;
                        output = new CmdletOutput
                        {
                            PipelineOutput = pipelineOutput,
                            ServiceResponse = response,
                            Notes = notes
                        };
                        if (_userControllingPaging)
                        {
                            int _receivedThisCall = response.Steps.Count;
                            WriteProgressRecord("Retrieving", string.Format("Retrieved {0} records starting from marker '{1}'", _receivedThisCall, request.Marker));
                        }
                        
                        _nextMarker = response.Marker;
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
            public String ClusterId { get; set; }
            public String Marker { get; set; }
            public List<String> StepIds { get; set; }
            public List<String> StepStates { get; set; }
        }
        
    }
}
