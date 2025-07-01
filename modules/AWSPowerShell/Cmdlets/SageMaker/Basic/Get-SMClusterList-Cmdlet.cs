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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Retrieves the list of SageMaker HyperPod clusters.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SMClusterList")]
    [OutputType("Amazon.SageMaker.Model.ClusterSummary")]
    [AWSCmdlet("Calls the Amazon SageMaker Service ListClusters API operation.", Operation = new[] {"ListClusters"}, SelectReturnType = typeof(Amazon.SageMaker.Model.ListClustersResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.ClusterSummary or Amazon.SageMaker.Model.ListClustersResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.ClusterSummary objects.",
        "The service call response (type Amazon.SageMaker.Model.ListClustersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMClusterListCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>Set a start time for the time range during which you want to list SageMaker HyperPod
        /// clusters. Timestamps are formatted according to the ISO 8601 standard. </para><para>Acceptable formats include:</para><ul><li><para><c>YYYY-MM-DDThh:mm:ss.sssTZD</c> (UTC), for example, <c>2014-10-01T20:30:00.000Z</c></para></li><li><para><c>YYYY-MM-DDThh:mm:ss.sssTZD</c> (with offset), for example, <c>2014-10-01T12:30:00.000-08:00</c></para></li><li><para><c>YYYY-MM-DD</c>, for example, <c>2014-10-01</c></para></li><li><para>Unix time in seconds, for example, <c>1412195400</c>. This is also referred to as
        /// Unix Epoch time and represents the number of seconds since midnight, January 1, 1970
        /// UTC.</para></li></ul><para>For more information about the timestamp format, see <a href="https://docs.aws.amazon.com/cli/latest/userguide/cli-usage-parameters-types.html#parameter-type-timestamp">Timestamp</a>
        /// in the <i>Amazon Web Services Command Line Interface User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>Set an end time for the time range during which you want to list SageMaker HyperPod
        /// clusters. A filter that returns nodes in a SageMaker HyperPod cluster created before
        /// the specified time. The acceptable formats are the same as the timestamp formats for
        /// <c>CreationTimeAfter</c>. For more information about the timestamp format, see <a href="https://docs.aws.amazon.com/cli/latest/userguide/cli-usage-parameters-types.html#parameter-type-timestamp">Timestamp</a>
        /// in the <i>Amazon Web Services Command Line Interface User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter NameContain
        /// <summary>
        /// <para>
        /// <para>Set the maximum number of instances to print in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NameContains")]
        public System.String NameContain { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The field by which to sort results. The default value is <c>CREATION_TIME</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ClusterSortBy")]
        public Amazon.SageMaker.ClusterSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order for results. The default value is <c>Ascending</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SortOrder")]
        public Amazon.SageMaker.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter TrainingPlanArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN); of the training plan to filter clusters by. For more
        /// information about reserving GPU capacity for your SageMaker HyperPod clusters using
        /// Amazon SageMaker Training Plan, see <c><a href="https://docs.aws.amazon.com/sagemaker/latest/APIReference/API_CreateTrainingPlan.html">CreateTrainingPlan</a></c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TrainingPlanArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of clusters to evaluate for the operation (not necessarily
        /// the number of matching items). After SageMaker processes the number of clusters up
        /// to <c>MaxResults</c>, it stops the operation and returns the matching clusters up
        /// to that point. If all the matching clusters are desired, SageMaker will go through
        /// all the clusters until <c>NextToken</c> is empty.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Set the next token to retrieve the list of SageMaker HyperPod clusters.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'NextToken' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-NextToken' to null for the first call then set the 'NextToken' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ClusterSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.ListClustersResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.ListClustersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ClusterSummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.ListClustersResponse, GetSMClusterListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreationTimeAfter = this.CreationTimeAfter;
            context.CreationTimeBefore = this.CreationTimeBefore;
            context.MaxResult = this.MaxResult;
            context.NameContain = this.NameContain;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.TrainingPlanArn = this.TrainingPlanArn;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SageMaker.Model.ListClustersRequest();
            
            if (cmdletContext.CreationTimeAfter != null)
            {
                request.CreationTimeAfter = cmdletContext.CreationTimeAfter.Value;
            }
            if (cmdletContext.CreationTimeBefore != null)
            {
                request.CreationTimeBefore = cmdletContext.CreationTimeBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NameContain != null)
            {
                request.NameContains = cmdletContext.NameContain;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.TrainingPlanArn != null)
            {
                request.TrainingPlanArn = cmdletContext.TrainingPlanArn;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SageMaker.Model.ListClustersResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.ListClustersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "ListClusters");
            try
            {
                #if DESKTOP
                return client.ListClusters(request);
                #elif CORECLR
                return client.ListClustersAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? CreationTimeAfter { get; set; }
            public System.DateTime? CreationTimeBefore { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NameContain { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SageMaker.ClusterSortBy SortBy { get; set; }
            public Amazon.SageMaker.SortOrder SortOrder { get; set; }
            public System.String TrainingPlanArn { get; set; }
            public System.Func<Amazon.SageMaker.Model.ListClustersResponse, GetSMClusterListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ClusterSummaries;
        }
        
    }
}
