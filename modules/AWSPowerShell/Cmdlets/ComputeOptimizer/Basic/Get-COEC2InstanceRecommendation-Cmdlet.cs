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
using Amazon.ComputeOptimizer;
using Amazon.ComputeOptimizer.Model;

namespace Amazon.PowerShell.Cmdlets.CO
{
    /// <summary>
    /// Returns Amazon EC2 instance recommendations.
    /// 
    ///  
    /// <para>
    /// Compute Optimizer generates recommendations for Amazon Elastic Compute Cloud (Amazon
    /// EC2) instances that meet a specific set of requirements. For more information, see
    /// the <a href="https://docs.aws.amazon.com/compute-optimizer/latest/ug/requirements.html">Supported
    /// resources and requirements</a> in the <i>Compute Optimizer User Guide</i>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "COEC2InstanceRecommendation")]
    [OutputType("Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse")]
    [AWSCmdlet("Calls the AWS Compute Optimizer GetEC2InstanceRecommendations API operation.", Operation = new[] {"GetEC2InstanceRecommendations"}, SelectReturnType = typeof(Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse))]
    [AWSCmdletOutput("Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse",
        "This cmdlet returns an Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse object containing multiple properties."
    )]
    public partial class GetCOEC2InstanceRecommendationCmdlet : AmazonComputeOptimizerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account for which to return instance recommendations.</para><para>If your account is the management account of an organization, use this parameter to
        /// specify the member account for which you want to return instance recommendations.</para><para>Only one account ID can be specified per request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AccountIds")]
        public System.String[] AccountId { get; set; }
        #endregion
        
        #region Parameter RecommendationPreferences_CpuVendorArchitecture
        /// <summary>
        /// <para>
        /// <para>Specifies the CPU vendor and architecture for Amazon EC2 instance and Auto Scaling
        /// group recommendations.</para><para>For example, when you specify <c>AWS_ARM64</c> with:</para><ul><li><para>A <a>GetEC2InstanceRecommendations</a> or <a>GetAutoScalingGroupRecommendations</a>
        /// request, Compute Optimizer returns recommendations that consist of Graviton instance
        /// types only.</para></li><li><para>A <a>GetEC2RecommendationProjectedMetrics</a> request, Compute Optimizer returns projected
        /// utilization metrics for Graviton instance type recommendations only.</para></li><li><para>A <a>ExportEC2InstanceRecommendations</a> or <a>ExportAutoScalingGroupRecommendations</a>
        /// request, Compute Optimizer exports recommendations that consist of Graviton instance
        /// types only.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecommendationPreferences_CpuVendorArchitectures")]
        public System.String[] RecommendationPreferences_CpuVendorArchitecture { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>An array of objects to specify a filter that returns a more specific list of instance
        /// recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.ComputeOptimizer.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the instances for which to return recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceArns")]
        public System.String[] InstanceArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of instance recommendations to return with a single request.</para><para>To retrieve the remaining results, make another request with the returned <c>nextToken</c>
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to advance to the next page of instance recommendations.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse).
        /// Specifying the name of a property of type Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse, GetCOEC2InstanceRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AccountId != null)
            {
                context.AccountId = new List<System.String>(this.AccountId);
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.ComputeOptimizer.Model.Filter>(this.Filter);
            }
            if (this.InstanceArn != null)
            {
                context.InstanceArn = new List<System.String>(this.InstanceArn);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.RecommendationPreferences_CpuVendorArchitecture != null)
            {
                context.RecommendationPreferences_CpuVendorArchitecture = new List<System.String>(this.RecommendationPreferences_CpuVendorArchitecture);
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
            var request = new Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountIds = cmdletContext.AccountId;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArns = cmdletContext.InstanceArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate RecommendationPreferences
            var requestRecommendationPreferencesIsNull = true;
            request.RecommendationPreferences = new Amazon.ComputeOptimizer.Model.RecommendationPreferences();
            List<System.String> requestRecommendationPreferences_recommendationPreferences_CpuVendorArchitecture = null;
            if (cmdletContext.RecommendationPreferences_CpuVendorArchitecture != null)
            {
                requestRecommendationPreferences_recommendationPreferences_CpuVendorArchitecture = cmdletContext.RecommendationPreferences_CpuVendorArchitecture;
            }
            if (requestRecommendationPreferences_recommendationPreferences_CpuVendorArchitecture != null)
            {
                request.RecommendationPreferences.CpuVendorArchitectures = requestRecommendationPreferences_recommendationPreferences_CpuVendorArchitecture;
                requestRecommendationPreferencesIsNull = false;
            }
             // determine if request.RecommendationPreferences should be set to null
            if (requestRecommendationPreferencesIsNull)
            {
                request.RecommendationPreferences = null;
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
        
        private Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse CallAWSServiceOperation(IAmazonComputeOptimizer client, Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Compute Optimizer", "GetEC2InstanceRecommendations");
            try
            {
                return client.GetEC2InstanceRecommendationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AccountId { get; set; }
            public List<Amazon.ComputeOptimizer.Model.Filter> Filter { get; set; }
            public List<System.String> InstanceArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> RecommendationPreferences_CpuVendorArchitecture { get; set; }
            public System.Func<Amazon.ComputeOptimizer.Model.GetEC2InstanceRecommendationsResponse, GetCOEC2InstanceRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
