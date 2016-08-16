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
    /// This API is deprecated and will eventually be removed. We recommend you use <a>ListClusters</a>,
    /// <a>DescribeCluster</a>, <a>ListSteps</a>, <a>ListInstanceGroups</a> and <a>ListBootstrapActions</a>
    /// instead.
    /// 
    ///  
    /// <para>
    /// DescribeJobFlows returns a list of job flows that match all of the supplied parameters.
    /// The parameters can include a list of job flow IDs, job flow states, and restrictions
    /// on job flow creation date and time.
    /// </para><para>
    /// Regardless of supplied parameters, only job flows created within the last two months
    /// are returned.
    /// </para><para>
    /// If no parameters are supplied, then job flows matching either of the following criteria
    /// are returned:
    /// </para><ul><li><para>
    /// Job flows created and completed in the last two weeks
    /// </para></li><li><para>
    ///  Job flows created within the last two months that are in one of the following states:
    /// <code>RUNNING</code>, <code>WAITING</code>, <code>SHUTTING_DOWN</code>, <code>STARTING</code></para></li></ul><para>
    /// Amazon Elastic MapReduce can return a maximum of 512 job flow descriptions.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "EMRJobFlow")]
    [OutputType("Amazon.ElasticMapReduce.Model.JobFlowDetail")]
    [AWSCmdlet("Invokes the DescribeJobFlows operation against Amazon Elastic MapReduce.", Operation = new[] {"DescribeJobFlows"})]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.JobFlowDetail",
        "This cmdlet returns a collection of JobFlowDetail objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetEMRJobFlowCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter CreatedAfter
        /// <summary>
        /// <para>
        /// <para>Return only job flows created after this date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CreatedAfter { get; set; }
        #endregion
        
        #region Parameter CreatedBefore
        /// <summary>
        /// <para>
        /// <para>Return only job flows created before this date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CreatedBefore { get; set; }
        #endregion
        
        #region Parameter JobFlowId
        /// <summary>
        /// <para>
        /// <para>Return only job flows whose job flow ID is contained in this list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("JobFlowIds")]
        public System.String[] JobFlowId { get; set; }
        #endregion
        
        #region Parameter JobFlowState
        /// <summary>
        /// <para>
        /// <para>Return only job flows whose state is contained in this list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("JobFlowStates")]
        public System.String[] JobFlowState { get; set; }
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
            
            if (ParameterWasBound("CreatedAfter"))
                context.CreatedAfter = this.CreatedAfter;
            if (ParameterWasBound("CreatedBefore"))
                context.CreatedBefore = this.CreatedBefore;
            if (this.JobFlowId != null)
            {
                context.JobFlowIds = new List<System.String>(this.JobFlowId);
            }
            if (this.JobFlowState != null)
            {
                context.JobFlowStates = new List<System.String>(this.JobFlowState);
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
            var request = new Amazon.ElasticMapReduce.Model.DescribeJobFlowsRequest();
            
            if (cmdletContext.CreatedAfter != null)
            {
                request.CreatedAfter = cmdletContext.CreatedAfter.Value;
            }
            if (cmdletContext.CreatedBefore != null)
            {
                request.CreatedBefore = cmdletContext.CreatedBefore.Value;
            }
            if (cmdletContext.JobFlowIds != null)
            {
                request.JobFlowIds = cmdletContext.JobFlowIds;
            }
            if (cmdletContext.JobFlowStates != null)
            {
                request.JobFlowStates = cmdletContext.JobFlowStates;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.JobFlows;
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
        
        private static Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.DescribeJobFlowsRequest request)
        {
            #if DESKTOP
            return client.DescribeJobFlows(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.DescribeJobFlowsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.DateTime? CreatedAfter { get; set; }
            public System.DateTime? CreatedBefore { get; set; }
            public List<System.String> JobFlowIds { get; set; }
            public List<System.String> JobFlowStates { get; set; }
        }
        
    }
}
