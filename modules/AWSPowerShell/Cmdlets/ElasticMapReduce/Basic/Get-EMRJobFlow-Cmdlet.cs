/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// This API is no longer supported and will eventually be removed. We recommend you use
    /// <a>ListClusters</a>, <a>DescribeCluster</a>, <a>ListSteps</a>, <a>ListInstanceGroups</a>
    /// and <a>ListBootstrapActions</a> instead.
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
    /// <c>RUNNING</c>, <c>WAITING</c>, <c>SHUTTING_DOWN</c>, <c>STARTING</c></para></li></ul><para>
    /// Amazon EMR can return a maximum of 512 job flow descriptions.
    /// </para><br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("Get", "EMRJobFlow")]
    [OutputType("Amazon.ElasticMapReduce.Model.JobFlowDetail")]
    [AWSCmdlet("Calls the Amazon Elastic MapReduce DescribeJobFlows API operation.", Operation = new[] {"DescribeJobFlows"}, SelectReturnType = typeof(Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse))]
    [AWSCmdletOutput("Amazon.ElasticMapReduce.Model.JobFlowDetail or Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse",
        "This cmdlet returns a collection of Amazon.ElasticMapReduce.Model.JobFlowDetail objects.",
        "The service call response (type Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse) can be returned by specifying '-Select *'."
    )]
    [System.ObsoleteAttribute("This API is deprecated and will eventually be removed. We recommend that you use ListClusters, DescribeCluster, ListSteps, ListInstanceGroups and ListBootstrapActions instead.")]
    public partial class GetEMRJobFlowCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreatedAfter
        /// <summary>
        /// <para>
        /// <para>Return only job flows created after this date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAfter { get; set; }
        #endregion
        
        #region Parameter CreatedBefore
        /// <summary>
        /// <para>
        /// <para>Return only job flows created before this date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedBefore { get; set; }
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobFlowStates")]
        public System.String[] JobFlowState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobFlows'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse).
        /// Specifying the name of a property of type Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobFlows";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse, GetEMRJobFlowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatedAfter = this.CreatedAfter;
            context.CreatedBefore = this.CreatedBefore;
            if (this.JobFlowId != null)
            {
                context.JobFlowId = new List<System.String>(this.JobFlowId);
            }
            if (this.JobFlowState != null)
            {
                context.JobFlowState = new List<System.String>(this.JobFlowState);
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
            if (cmdletContext.JobFlowId != null)
            {
                request.JobFlowIds = cmdletContext.JobFlowId;
            }
            if (cmdletContext.JobFlowState != null)
            {
                request.JobFlowStates = cmdletContext.JobFlowState;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
        
        private Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.DescribeJobFlowsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic MapReduce", "DescribeJobFlows");
            try
            {
                #if DESKTOP
                return client.DescribeJobFlows(request);
                #elif CORECLR
                return client.DescribeJobFlowsAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? CreatedAfter { get; set; }
            public System.DateTime? CreatedBefore { get; set; }
            public List<System.String> JobFlowId { get; set; }
            public List<System.String> JobFlowState { get; set; }
            public System.Func<Amazon.ElasticMapReduce.Model.DescribeJobFlowsResponse, GetEMRJobFlowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobFlows;
        }
        
    }
}
