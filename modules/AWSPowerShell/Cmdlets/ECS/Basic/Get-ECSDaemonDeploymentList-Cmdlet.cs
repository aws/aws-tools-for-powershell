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
using Amazon.ECS;
using Amazon.ECS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Returns a list of daemon deployments for a specified daemon. You can filter the results
    /// by status or creation time.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "ECSDaemonDeploymentList")]
    [OutputType("Amazon.ECS.Model.DaemonDeploymentSummary")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service ListDaemonDeployments API operation.", Operation = new[] {"ListDaemonDeployments"}, SelectReturnType = typeof(Amazon.ECS.Model.ListDaemonDeploymentsResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.DaemonDeploymentSummary or Amazon.ECS.Model.ListDaemonDeploymentsResponse",
        "This cmdlet returns a collection of Amazon.ECS.Model.DaemonDeploymentSummary objects.",
        "The service call response (type Amazon.ECS.Model.ListDaemonDeploymentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetECSDaemonDeploymentListCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreatedAt_After
        /// <summary>
        /// <para>
        /// <para>Include service deployments in the result that were created after this time. The format
        /// is yyyy-MM-dd HH:mm:ss.SSSSSS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAt_After { get; set; }
        #endregion
        
        #region Parameter CreatedAt_Before
        /// <summary>
        /// <para>
        /// <para>Include service deployments in the result that were created before this time. The
        /// format is yyyy-MM-dd HH:mm:ss.SSSSSS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreatedAt_Before { get; set; }
        #endregion
        
        #region Parameter DaemonArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the daemon to list deployments for.</para>
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
        public System.String DaemonArn { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>An optional filter to narrow the <c>ListDaemonDeployments</c> results by deployment
        /// status. If you don't specify a status, all deployments are returned.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Status { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of daemon deployment results that <c>ListDaemonDeployments</c>
        /// returned in paginated output. When this parameter is used, <c>ListDaemonDeployments</c>
        /// only returns <c>maxResults</c> results in a single page along with a <c>nextToken</c>
        /// response element. The remaining results of the initial request can be seen by sending
        /// another <c>ListDaemonDeployments</c> request with the returned <c>nextToken</c> value.
        /// This value can be between 1 and 100. If this parameter isn't used, then <c>ListDaemonDeployments</c>
        /// returns up to 20 results and a <c>nextToken</c> value if applicable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> value returned from a <c>ListDaemonDeployments</c> request indicating
        /// that more results are available to fulfill the request and further calls will be needed.
        /// If <c>maxResults</c> was provided, it's possible for the number of results to be fewer
        /// than <c>maxResults</c>.</para><note><para>This token should be treated as an opaque identifier that is only used to retrieve
        /// the next items in a list and not for other programmatic purposes.</para></note>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DaemonDeployments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.ListDaemonDeploymentsResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.ListDaemonDeploymentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DaemonDeployments";
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
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.ListDaemonDeploymentsResponse, GetECSDaemonDeploymentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatedAt_After = this.CreatedAt_After;
            context.CreatedAt_Before = this.CreatedAt_Before;
            context.DaemonArn = this.DaemonArn;
            #if MODULAR
            if (this.DaemonArn == null && ParameterWasBound(nameof(this.DaemonArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DaemonArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.Status != null)
            {
                context.Status = new List<System.String>(this.Status);
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
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ECS.Model.ListDaemonDeploymentsRequest();
            
            
             // populate CreatedAt
            var requestCreatedAtIsNull = true;
            request.CreatedAt = new Amazon.ECS.Model.CreatedAt();
            System.DateTime? requestCreatedAt_createdAt_After = null;
            if (cmdletContext.CreatedAt_After != null)
            {
                requestCreatedAt_createdAt_After = cmdletContext.CreatedAt_After.Value;
            }
            if (requestCreatedAt_createdAt_After != null)
            {
                request.CreatedAt.After = requestCreatedAt_createdAt_After.Value;
                requestCreatedAtIsNull = false;
            }
            System.DateTime? requestCreatedAt_createdAt_Before = null;
            if (cmdletContext.CreatedAt_Before != null)
            {
                requestCreatedAt_createdAt_Before = cmdletContext.CreatedAt_Before.Value;
            }
            if (requestCreatedAt_createdAt_Before != null)
            {
                request.CreatedAt.Before = requestCreatedAt_createdAt_Before.Value;
                requestCreatedAtIsNull = false;
            }
             // determine if request.CreatedAt should be set to null
            if (requestCreatedAtIsNull)
            {
                request.CreatedAt = null;
            }
            if (cmdletContext.DaemonArn != null)
            {
                request.DaemonArn = cmdletContext.DaemonArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.ECS.Model.ListDaemonDeploymentsResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.ListDaemonDeploymentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "ListDaemonDeployments");
            try
            {
                return client.ListDaemonDeploymentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? CreatedAt_After { get; set; }
            public System.DateTime? CreatedAt_Before { get; set; }
            public System.String DaemonArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Status { get; set; }
            public System.Func<Amazon.ECS.Model.ListDaemonDeploymentsResponse, GetECSDaemonDeploymentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DaemonDeployments;
        }
        
    }
}
