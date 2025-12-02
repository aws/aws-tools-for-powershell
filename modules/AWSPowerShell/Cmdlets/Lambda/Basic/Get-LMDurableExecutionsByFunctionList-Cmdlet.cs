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
using Amazon.Lambda;
using Amazon.Lambda.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Returns a list of <a href="https://docs.aws.amazon.com/lambda/latest/dg/durable-functions.html">durable
    /// executions</a> for a specified Lambda function. You can filter the results by execution
    /// name, status, and start time range. This API supports pagination for large result
    /// sets.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "LMDurableExecutionsByFunctionList")]
    [OutputType("Amazon.Lambda.Model.Execution")]
    [AWSCmdlet("Calls the AWS Lambda ListDurableExecutionsByFunction API operation.", Operation = new[] {"ListDurableExecutionsByFunction"}, SelectReturnType = typeof(Amazon.Lambda.Model.ListDurableExecutionsByFunctionResponse))]
    [AWSCmdletOutput("Amazon.Lambda.Model.Execution or Amazon.Lambda.Model.ListDurableExecutionsByFunctionResponse",
        "This cmdlet returns a collection of Amazon.Lambda.Model.Execution objects.",
        "The service call response (type Amazon.Lambda.Model.ListDurableExecutionsByFunctionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLMDurableExecutionsByFunctionListCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DurableExecutionName
        /// <summary>
        /// <para>
        /// <para>Filter executions by name. Only executions with names that contain this string are
        /// returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DurableExecutionName { get; set; }
        #endregion
        
        #region Parameter FunctionName
        /// <summary>
        /// <para>
        /// <para>The name or ARN of the Lambda function. You can specify a function name, a partial
        /// ARN, or a full ARN.</para>
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
        public System.String FunctionName { get; set; }
        #endregion
        
        #region Parameter Qualifier
        /// <summary>
        /// <para>
        /// <para>The function version or alias. If not specified, lists executions for the $LATEST
        /// version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Qualifier { get; set; }
        #endregion
        
        #region Parameter ReverseOrder
        /// <summary>
        /// <para>
        /// <para>Set to true to return results in reverse chronological order (newest first). Default
        /// is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReverseOrder { get; set; }
        #endregion
        
        #region Parameter StartedAfter
        /// <summary>
        /// <para>
        /// <para>Filter executions that started after this timestamp (ISO 8601 format).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartedAfter { get; set; }
        #endregion
        
        #region Parameter StartedBefore
        /// <summary>
        /// <para>
        /// <para>Filter executions that started before this timestamp (ISO 8601 format).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartedBefore { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Filter executions by status. Valid values: RUNNING, SUCCEEDED, FAILED, TIMED_OUT,
        /// STOPPED.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Statuses")]
        public System.String[] Status { get; set; }
        #endregion
        
        #region Parameter Marker
        /// <summary>
        /// <para>
        /// <para>Pagination token from a previous request to continue retrieving results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>'Marker' is only returned by the cmdlet when '-Select *' is specified. In order to manually control output pagination, set '-Marker' to null for the first call then set the 'Marker' using the same property output from the previous call for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String Marker { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>Maximum number of executions to return (1-1000). Default is 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DurableExecutions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.ListDurableExecutionsByFunctionResponse).
        /// Specifying the name of a property of type Amazon.Lambda.Model.ListDurableExecutionsByFunctionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DurableExecutions";
        #endregion
        
        #region Parameter NoAutoIteration
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of Marker
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
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.ListDurableExecutionsByFunctionResponse, GetLMDurableExecutionsByFunctionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DurableExecutionName = this.DurableExecutionName;
            context.FunctionName = this.FunctionName;
            #if MODULAR
            if (this.FunctionName == null && ParameterWasBound(nameof(this.FunctionName)))
            {
                WriteWarning("You are passing $null as a value for parameter FunctionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Marker = this.Marker;
            context.MaxItem = this.MaxItem;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.MaxItem)) && this.MaxItem.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the MaxItem parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing MaxItem" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.Qualifier = this.Qualifier;
            context.ReverseOrder = this.ReverseOrder;
            context.StartedAfter = this.StartedAfter;
            context.StartedBefore = this.StartedBefore;
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
            var request = new Amazon.Lambda.Model.ListDurableExecutionsByFunctionRequest();
            
            if (cmdletContext.DurableExecutionName != null)
            {
                request.DurableExecutionName = cmdletContext.DurableExecutionName;
            }
            if (cmdletContext.FunctionName != null)
            {
                request.FunctionName = cmdletContext.FunctionName;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxItem.Value);
            }
            if (cmdletContext.Qualifier != null)
            {
                request.Qualifier = cmdletContext.Qualifier;
            }
            if (cmdletContext.ReverseOrder != null)
            {
                request.ReverseOrder = cmdletContext.ReverseOrder.Value;
            }
            if (cmdletContext.StartedAfter != null)
            {
                request.StartedAfter = cmdletContext.StartedAfter.Value;
            }
            if (cmdletContext.StartedBefore != null)
            {
                request.StartedBefore = cmdletContext.StartedBefore.Value;
            }
            if (cmdletContext.Status != null)
            {
                request.Statuses = cmdletContext.Status;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.Marker;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.Marker));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.Marker = _nextToken;
                
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
                    
                    _nextToken = response.NextMarker;
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
        
        private Amazon.Lambda.Model.ListDurableExecutionsByFunctionResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.ListDurableExecutionsByFunctionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "ListDurableExecutionsByFunction");
            try
            {
                return client.ListDurableExecutionsByFunctionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DurableExecutionName { get; set; }
            public System.String FunctionName { get; set; }
            public System.String Marker { get; set; }
            public int? MaxItem { get; set; }
            public System.String Qualifier { get; set; }
            public System.Boolean? ReverseOrder { get; set; }
            public System.DateTime? StartedAfter { get; set; }
            public System.DateTime? StartedBefore { get; set; }
            public List<System.String> Status { get; set; }
            public System.Func<Amazon.Lambda.Model.ListDurableExecutionsByFunctionResponse, GetLMDurableExecutionsByFunctionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DurableExecutions;
        }
        
    }
}
