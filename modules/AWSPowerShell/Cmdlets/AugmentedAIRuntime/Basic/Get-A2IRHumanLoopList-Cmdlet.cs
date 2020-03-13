/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.AugmentedAIRuntime;
using Amazon.AugmentedAIRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.A2IR
{
    /// <summary>
    /// Returns information about human loops, given the specified parameters. If a human
    /// loop was deleted, it will not be included.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "A2IRHumanLoopList")]
    [OutputType("Amazon.AugmentedAIRuntime.Model.HumanLoopSummary")]
    [AWSCmdlet("Calls the Amazon Augmented AI (A2I) Runtime ListHumanLoops API operation.", Operation = new[] {"ListHumanLoops"}, SelectReturnType = typeof(Amazon.AugmentedAIRuntime.Model.ListHumanLoopsResponse))]
    [AWSCmdletOutput("Amazon.AugmentedAIRuntime.Model.HumanLoopSummary or Amazon.AugmentedAIRuntime.Model.ListHumanLoopsResponse",
        "This cmdlet returns a collection of Amazon.AugmentedAIRuntime.Model.HumanLoopSummary objects.",
        "The service call response (type Amazon.AugmentedAIRuntime.Model.ListHumanLoopsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetA2IRHumanLoopListCmdlet : AmazonAugmentedAIRuntimeClientCmdlet, IExecutor
    {
        
        #region Parameter CreationTimeAfter
        /// <summary>
        /// <para>
        /// <para>(Optional) The timestamp of the date when you want the human loops to begin in ISO
        /// 8601 format. For example, <code>2020-02-24</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeAfter { get; set; }
        #endregion
        
        #region Parameter CreationTimeBefore
        /// <summary>
        /// <para>
        /// <para>(Optional) The timestamp of the date before which you want the human loops to begin
        /// in ISO 8601 format. For example, <code>2020-02-24</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CreationTimeBefore { get; set; }
        #endregion
        
        #region Parameter FlowDefinitionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a flow definition.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FlowDefinitionArn { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Optional. The order for displaying results. Valid values: <code>Ascending</code> and
        /// <code>Descending</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AugmentedAIRuntime.SortOrder")]
        public Amazon.AugmentedAIRuntime.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The total number of items to return. If the total number of available items is more
        /// than the value specified in <code>MaxResults</code>, then a <code>NextToken</code>
        /// is returned in the output. You can use this token to display the next page of results.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>A token to display the next page of results.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'HumanLoopSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AugmentedAIRuntime.Model.ListHumanLoopsResponse).
        /// Specifying the name of a property of type Amazon.AugmentedAIRuntime.Model.ListHumanLoopsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "HumanLoopSummaries";
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AugmentedAIRuntime.Model.ListHumanLoopsResponse, GetA2IRHumanLoopListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreationTimeAfter = this.CreationTimeAfter;
            context.CreationTimeBefore = this.CreationTimeBefore;
            context.FlowDefinitionArn = this.FlowDefinitionArn;
            #if MODULAR
            if (this.FlowDefinitionArn == null && ParameterWasBound(nameof(this.FlowDefinitionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowDefinitionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortOrder = this.SortOrder;
            
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
            var request = new Amazon.AugmentedAIRuntime.Model.ListHumanLoopsRequest();
            
            if (cmdletContext.CreationTimeAfter != null)
            {
                request.CreationTimeAfter = cmdletContext.CreationTimeAfter.Value;
            }
            if (cmdletContext.CreationTimeBefore != null)
            {
                request.CreationTimeBefore = cmdletContext.CreationTimeBefore.Value;
            }
            if (cmdletContext.FlowDefinitionArn != null)
            {
                request.FlowDefinitionArn = cmdletContext.FlowDefinitionArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
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
        
        private Amazon.AugmentedAIRuntime.Model.ListHumanLoopsResponse CallAWSServiceOperation(IAmazonAugmentedAIRuntime client, Amazon.AugmentedAIRuntime.Model.ListHumanLoopsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Augmented AI (A2I) Runtime", "ListHumanLoops");
            try
            {
                #if DESKTOP
                return client.ListHumanLoops(request);
                #elif CORECLR
                return client.ListHumanLoopsAsync(request).GetAwaiter().GetResult();
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
            public System.String FlowDefinitionArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.AugmentedAIRuntime.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.AugmentedAIRuntime.Model.ListHumanLoopsResponse, GetA2IRHumanLoopListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.HumanLoopSummaries;
        }
        
    }
}
