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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Lists custom model deployments in your account. You can filter the results by creation
    /// time, name, status, and associated model. Use this operation to manage and monitor
    /// your custom model deployments.
    /// 
    ///  
    /// <para>
    /// We recommend using pagination to ensure that the operation returns quickly and successfully.
    /// </para><para>
    /// The following actions are related to the <c>ListCustomModelDeployments</c> operation:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_CreateCustomModelDeployment.html">CreateCustomModelDeployment</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_GetCustomModelDeployment.html">GetCustomModelDeployment</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock/latest/APIReference/API_DeleteCustomModelDeployment.html">DeleteCustomModelDeployment</a></para></li></ul><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "BDRCustomModelDeploymentList")]
    [OutputType("Amazon.Bedrock.Model.CustomModelDeploymentSummary")]
    [AWSCmdlet("Calls the Amazon Bedrock ListCustomModelDeployments API operation.", Operation = new[] {"ListCustomModelDeployments"}, SelectReturnType = typeof(Amazon.Bedrock.Model.ListCustomModelDeploymentsResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.CustomModelDeploymentSummary or Amazon.Bedrock.Model.ListCustomModelDeploymentsResponse",
        "This cmdlet returns a collection of Amazon.Bedrock.Model.CustomModelDeploymentSummary objects.",
        "The service call response (type Amazon.Bedrock.Model.ListCustomModelDeploymentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBDRCustomModelDeploymentListCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreatedAfter
        /// <summary>
        /// <para>
        /// <para>Filters deployments created after the specified date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAfter { get; set; }
        #endregion
        
        #region Parameter CreatedBefore
        /// <summary>
        /// <para>
        /// <para>Filters deployments created before the specified date and time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedBefore { get; set; }
        #endregion
        
        #region Parameter ModelArnEqual
        /// <summary>
        /// <para>
        /// <para>Filters deployments by the Amazon Resource Name (ARN) of the associated custom model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ModelArnEquals")]
        public System.String ModelArnEqual { get; set; }
        #endregion
        
        #region Parameter NameContain
        /// <summary>
        /// <para>
        /// <para>Filters deployments whose names contain the specified string. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NameContains")]
        public System.String NameContain { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort the results by. The only supported value is <c>CreationTime</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.SortModelsBy")]
        public Amazon.Bedrock.SortModelsBy SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The sort order for the results. Valid values are <c>Ascending</c> and <c>Descending</c>.
        /// Default is <c>Descending</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Bedrock.SortOrder")]
        public Amazon.Bedrock.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter StatusEqual
        /// <summary>
        /// <para>
        /// <para>Filters deployments by status. Valid values are <c>CREATING</c>, <c>ACTIVE</c>, and
        /// <c>FAILED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StatusEquals")]
        [AWSConstantClassSource("Amazon.Bedrock.CustomModelDeploymentStatus")]
        public Amazon.Bedrock.CustomModelDeploymentStatus StatusEqual { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
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
        /// <para>The token for the next set of results. Use this token to retrieve additional results
        /// when the response is truncated.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ModelDeploymentSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.ListCustomModelDeploymentsResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.ListCustomModelDeploymentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ModelDeploymentSummaries";
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
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.ListCustomModelDeploymentsResponse, GetBDRCustomModelDeploymentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatedAfter = this.CreatedAfter;
            context.CreatedBefore = this.CreatedBefore;
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
            context.ModelArnEqual = this.ModelArnEqual;
            context.NameContain = this.NameContain;
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
            var request = new Amazon.Bedrock.Model.ListCustomModelDeploymentsRequest();
            
            if (cmdletContext.CreatedAfter != null)
            {
                request.CreatedAfter = cmdletContext.CreatedAfter.Value;
            }
            if (cmdletContext.CreatedBefore != null)
            {
                request.CreatedBefore = cmdletContext.CreatedBefore.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.ModelArnEqual != null)
            {
                request.ModelArnEquals = cmdletContext.ModelArnEqual;
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
        
        private Amazon.Bedrock.Model.ListCustomModelDeploymentsResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.ListCustomModelDeploymentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "ListCustomModelDeployments");
            try
            {
                return client.ListCustomModelDeploymentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String ModelArnEqual { get; set; }
            public System.String NameContain { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Bedrock.SortModelsBy SortBy { get; set; }
            public Amazon.Bedrock.SortOrder SortOrder { get; set; }
            public Amazon.Bedrock.CustomModelDeploymentStatus StatusEqual { get; set; }
            public System.Func<Amazon.Bedrock.Model.ListCustomModelDeploymentsResponse, GetBDRCustomModelDeploymentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ModelDeploymentSummaries;
        }
        
    }
}
