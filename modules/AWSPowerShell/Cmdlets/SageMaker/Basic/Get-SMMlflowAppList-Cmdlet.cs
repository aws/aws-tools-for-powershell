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
    /// Lists all MLflow Apps<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SMMlflowAppList")]
    [OutputType("Amazon.SageMaker.Model.MlflowAppSummary")]
    [AWSCmdlet("Calls the Amazon SageMaker Service ListMlflowApps API operation.", Operation = new[] {"ListMlflowApps"}, SelectReturnType = typeof(Amazon.SageMaker.Model.ListMlflowAppsResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.MlflowAppSummary or Amazon.SageMaker.Model.ListMlflowAppsResponse",
        "This cmdlet returns a collection of Amazon.SageMaker.Model.MlflowAppSummary objects.",
        "The service call response (type Amazon.SageMaker.Model.ListMlflowAppsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSMMlflowAppListCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountDefaultStatus
        /// <summary>
        /// <para>
        /// <para>Filter for MLflow Apps with the specified <c>AccountDefaultStatus</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.AccountDefaultStatus")]
        public Amazon.SageMaker.AccountDefaultStatus AccountDefaultStatus { get; set; }
        #endregion
        
        #region Parameter CreatedAfter
        /// <summary>
        /// <para>
        /// <para>Use the <c>CreatedAfter</c> filter to only list MLflow Apps created after a specific
        /// date and time. Listed MLflow Apps are shown with a date and time such as <c>"2024-03-16T01:46:56+00:00"</c>.
        /// The <c>CreatedAfter</c> parameter takes in a Unix timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAfter { get; set; }
        #endregion
        
        #region Parameter CreatedBefore
        /// <summary>
        /// <para>
        /// <para>Use the <c>CreatedBefore</c> filter to only list MLflow Apps created before a specific
        /// date and time. Listed MLflow Apps are shown with a date and time such as <c>"2024-03-16T01:46:56+00:00"</c>.
        /// The <c>CreatedAfter</c> parameter takes in a Unix timestamp.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedBefore { get; set; }
        #endregion
        
        #region Parameter DefaultForDomainId
        /// <summary>
        /// <para>
        /// <para>Filter for MLflow Apps with the specified default SageMaker Domain ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultForDomainId { get; set; }
        #endregion
        
        #region Parameter MlflowVersion
        /// <summary>
        /// <para>
        /// <para>Filter for Mlflow Apps with the specified version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MlflowVersion { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Filter for MLflow Apps sorting by name, creation time, or creation status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SortMlflowAppBy")]
        public Amazon.SageMaker.SortMlflowAppBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Change the order of the listed MLflow Apps. By default, MLflow Apps are listed in
        /// <c>Descending</c> order by creation time. To change the list order, specify <c>SortOrder</c>
        /// to be <c>Ascending</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.SortOrder")]
        public Amazon.SageMaker.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filter for Mlflow apps with a specific creation status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.MlflowAppStatus")]
        public Amazon.SageMaker.MlflowAppStatus Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of MLflow Apps to list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was truncated, use this token in your next request to receive
        /// the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.ListMlflowAppsResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.ListMlflowAppsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summaries";
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
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.ListMlflowAppsResponse, GetSMMlflowAppListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountDefaultStatus = this.AccountDefaultStatus;
            context.CreatedAfter = this.CreatedAfter;
            context.CreatedBefore = this.CreatedBefore;
            context.DefaultForDomainId = this.DefaultForDomainId;
            context.MaxResult = this.MaxResult;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxResult)) && this.MaxResult.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxResult parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxResult" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.MlflowVersion = this.MlflowVersion;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.SageMaker.Model.ListMlflowAppsRequest();
            
            if (cmdletContext.AccountDefaultStatus != null)
            {
                request.AccountDefaultStatus = cmdletContext.AccountDefaultStatus;
            }
            if (cmdletContext.CreatedAfter != null)
            {
                request.CreatedAfter = cmdletContext.CreatedAfter.Value;
            }
            if (cmdletContext.CreatedBefore != null)
            {
                request.CreatedBefore = cmdletContext.CreatedBefore.Value;
            }
            if (cmdletContext.DefaultForDomainId != null)
            {
                request.DefaultForDomainId = cmdletContext.DefaultForDomainId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.MlflowVersion != null)
            {
                request.MlflowVersion = cmdletContext.MlflowVersion;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.SageMaker.Model.ListMlflowAppsResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.ListMlflowAppsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "ListMlflowApps");
            try
            {
                return client.ListMlflowAppsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.AccountDefaultStatus AccountDefaultStatus { get; set; }
            public System.DateTime? CreatedAfter { get; set; }
            public System.DateTime? CreatedBefore { get; set; }
            public System.String DefaultForDomainId { get; set; }
            public int? MaxResult { get; set; }
            public System.String MlflowVersion { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SageMaker.SortMlflowAppBy SortBy { get; set; }
            public Amazon.SageMaker.SortOrder SortOrder { get; set; }
            public Amazon.SageMaker.MlflowAppStatus Status { get; set; }
            public System.Func<Amazon.SageMaker.Model.ListMlflowAppsResponse, GetSMMlflowAppListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summaries;
        }
        
    }
}
