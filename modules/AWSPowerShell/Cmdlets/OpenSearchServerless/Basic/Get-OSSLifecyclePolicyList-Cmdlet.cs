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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Returns a list of OpenSearch Serverless lifecycle policies. For more information,
    /// see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-lifecycle.html#serverless-lifecycle-list">Viewing
    /// data lifecycle policies</a>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "OSSLifecyclePolicyList")]
    [OutputType("Amazon.OpenSearchServerless.Model.LifecyclePolicySummary")]
    [AWSCmdlet("Calls the OpenSearch Serverless ListLifecyclePolicies API operation.", Operation = new[] {"ListLifecyclePolicies"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.LifecyclePolicySummary or Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesResponse",
        "This cmdlet returns a collection of Amazon.OpenSearchServerless.Model.LifecyclePolicySummary objects.",
        "The service call response (type Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetOSSLifecyclePolicyListCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Resource
        /// <summary>
        /// <para>
        /// <para>Resource filters that policies can apply to. Currently, the only supported resource
        /// type is <c>index</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Resources")]
        public System.String[] Resource { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of lifecycle policy.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.OpenSearchServerless.LifecyclePolicyType")]
        public Amazon.OpenSearchServerless.LifecyclePolicyType Type { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter that specifies the maximum number of results to return. You
        /// can use use <c>nextToken</c> to get the next page of results. The default is 10.</para>
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
        /// <para>If your initial <c>ListLifecyclePolicies</c> operation returns a <c>nextToken</c>,
        /// you can include the returned <c>nextToken</c> in subsequent <c>ListLifecyclePolicies</c>
        /// operations, which returns results in the next page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LifecyclePolicySummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LifecyclePolicySummaries";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextToken
        /// as the start point.
        /// This cmdlet didn't autopaginate in V4. To preserve the V4 autopagination behavior for all cmdlets, run Set-AWSAutoIterationMode -IterationMode v4.
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
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesResponse, GetOSSLifecyclePolicyListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.NextToken = this.NextToken;
            if (this.Resource != null)
            {
                context.Resource = new List<System.String>(this.Resource);
            }
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Resource != null)
            {
                request.Resources = cmdletContext.Resource;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            var _shouldAutoIterate = !(SessionState.PSVariable.GetValue("AWSPowerShell_AutoIteration_Mode")?.ToString() == "v4");
            
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
                
            } while (!_userControllingPaging && _shouldAutoIterate && AutoIterationHelpers.HasValue(_nextToken));
            
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
        
        private Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "ListLifecyclePolicies");
            try
            {
                return client.ListLifecyclePoliciesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> Resource { get; set; }
            public Amazon.OpenSearchServerless.LifecyclePolicyType Type { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.ListLifecyclePoliciesResponse, GetOSSLifecyclePolicyListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LifecyclePolicySummaries;
        }
        
    }
}
