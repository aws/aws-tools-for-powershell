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
using System.Threading;
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// List the export jobs for the Amazon SageMaker Model Card.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SMModelCardExportJobList")]
    [OutputType("Amazon.SageMaker.Model.ModelCardExportJobSummary")]
    [AWSCmdlet("Calls the Amazon SageMaker Service ListModelCardExportJobs API operation.", Operation = new[] {"ListModelCardExportJobs"}, SelectReturnType = typeof(Amazon.SageMaker.Model.ListModelCardExportJobsResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.ModelCardExportJobSummary or Amazon.SageMaker.Model.ListModelCardExportJobsResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.ModelCardExportJobSummary objects.",
        "The service call response (type Amazon.SageMaker.Model.ListModelCardExportJobsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMModelCardExportJobListCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>Only list model card export jobs that were created after the time specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>Only list model card export jobs that were created before the time specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter ModelCardExportJobNameContain
        /// <summary>
        /// <para>
        /// <para>Only list model card export jobs with names that contain the specified string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelCardExportJobNameContains")]
        public System.String ModelCardExportJobNameContain { get; set; }
        #endregion
        
        #region Parameter ModelCardName
        /// <summary>
        /// <para>
        /// <para>List export jobs for the model card with the specified name.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ModelCardName { get; set; }
        #endregion
        
        #region Parameter ModelCardVersion
        /// <summary>
        /// <para>
        /// <para>List export jobs for the model card with the specified version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ModelCardVersion { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Sort model card export jobs by either name or creation time. Sorts by creation time
        /// by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ModelCardExportJobSortBy")]
        public Amazon.SageMaker.ModelCardExportJobSortBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Sort model card export jobs by ascending or descending order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ModelCardExportJobSortOrder")]
        public Amazon.SageMaker.ModelCardExportJobSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter StatusEqual
        /// <summary>
        /// <para>
        /// <para>Only list model card export jobs with the specified status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusEquals")]
        [AWSConstantClassSource("Amazon.SageMaker.ModelCardExportJobStatus")]
        public Amazon.SageMaker.ModelCardExportJobStatus StatusEqual { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of model card export jobs to list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the response to a previous <c>ListModelCardExportJobs</c> request was truncated,
        /// the response includes a <c>NextToken</c>. To retrieve the next set of model card export
        /// jobs, use the token in the next request.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelCardExportJobSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.ListModelCardExportJobsResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.ListModelCardExportJobsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelCardExportJobSummaries";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.ListModelCardExportJobsResponse, GetSMModelCardExportJobListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreationTimeAfter = this.CreationTimeAfter;
            context.CreationTimeBefore = this.CreationTimeBefore;
            context.MaxResult = this.MaxResult;
            context.ModelCardExportJobNameContain = this.ModelCardExportJobNameContain;
            context.ModelCardName = this.ModelCardName;
            #if MODULAR
            if (this.ModelCardName == null && ParameterWasBound(nameof(this.ModelCardName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelCardName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelCardVersion = this.ModelCardVersion;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.StatusEqual = this.StatusEqual;
            
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
            var request = new Amazon.SageMaker.Model.ListModelCardExportJobsRequest();
            
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
            if (cmdletContext.ModelCardExportJobNameContain != null)
            {
                request.ModelCardExportJobNameContains = cmdletContext.ModelCardExportJobNameContain;
            }
            if (cmdletContext.ModelCardName != null)
            {
                request.ModelCardName = cmdletContext.ModelCardName;
            }
            if (cmdletContext.ModelCardVersion != null)
            {
                request.ModelCardVersion = cmdletContext.ModelCardVersion.Value;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.StatusEqual != null)
            {
                request.StatusEquals = cmdletContext.StatusEqual;
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
        
        private Amazon.SageMaker.Model.ListModelCardExportJobsResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.ListModelCardExportJobsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "ListModelCardExportJobs");
            try
            {
                return client.ListModelCardExportJobsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ModelCardExportJobNameContain { get; set; }
            public System.String ModelCardName { get; set; }
            public System.Int32? ModelCardVersion { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SageMaker.ModelCardExportJobSortBy SortBy { get; set; }
            public Amazon.SageMaker.ModelCardExportJobSortOrder SortOrder { get; set; }
            public Amazon.SageMaker.ModelCardExportJobStatus StatusEqual { get; set; }
            public System.Func<Amazon.SageMaker.Model.ListModelCardExportJobsResponse, GetSMModelCardExportJobListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelCardExportJobSummaries;
        }
        
    }
}
