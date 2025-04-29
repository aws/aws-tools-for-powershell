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
using Amazon.SavingsPlans;
using Amazon.SavingsPlans.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SP
{
    /// <summary>
    /// Describes the specified Savings Plans.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "SPSavingsPlan")]
    [OutputType("Amazon.SavingsPlans.Model.SavingsPlan")]
    [AWSCmdlet("Calls the AWS Savings Plans DescribeSavingsPlans API operation.", Operation = new[] {"DescribeSavingsPlans"}, SelectReturnType = typeof(Amazon.SavingsPlans.Model.DescribeSavingsPlansResponse))]
    [AWSCmdletOutput("Amazon.SavingsPlans.Model.SavingsPlan or Amazon.SavingsPlans.Model.DescribeSavingsPlansResponse",
        "This cmdlet returns a collection of Amazon.SavingsPlans.Model.SavingsPlan objects.",
        "The service call response (type Amazon.SavingsPlans.Model.DescribeSavingsPlansResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSPSavingsPlanCmdlet : AmazonSavingsPlansClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>The filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.SavingsPlans.Model.SavingsPlanFilter[] Filter { get; set; }
        #endregion
        
        #region Parameter SavingsPlanArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARN) of the Savings Plans.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SavingsPlanArns")]
        public System.String[] SavingsPlanArn { get; set; }
        #endregion
        
        #region Parameter SavingsPlanId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Savings Plans.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SavingsPlanIds")]
        public System.String[] SavingsPlanId { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The current states of the Savings Plans.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("States")]
        public System.String[] State { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve additional
        /// results, make another call with the returned token value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SavingsPlans'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SavingsPlans.Model.DescribeSavingsPlansResponse).
        /// Specifying the name of a property of type Amazon.SavingsPlans.Model.DescribeSavingsPlansResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SavingsPlans";
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
                context.Select = CreateSelectDelegate<Amazon.SavingsPlans.Model.DescribeSavingsPlansResponse, GetSPSavingsPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.SavingsPlans.Model.SavingsPlanFilter>(this.Filter);
            }
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            if (this.SavingsPlanArn != null)
            {
                context.SavingsPlanArn = new List<System.String>(this.SavingsPlanArn);
            }
            if (this.SavingsPlanId != null)
            {
                context.SavingsPlanId = new List<System.String>(this.SavingsPlanId);
            }
            if (this.State != null)
            {
                context.State = new List<System.String>(this.State);
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
            var request = new Amazon.SavingsPlans.Model.DescribeSavingsPlansRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.SavingsPlanArn != null)
            {
                request.SavingsPlanArns = cmdletContext.SavingsPlanArn;
            }
            if (cmdletContext.SavingsPlanId != null)
            {
                request.SavingsPlanIds = cmdletContext.SavingsPlanId;
            }
            if (cmdletContext.State != null)
            {
                request.States = cmdletContext.State;
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
        
        private Amazon.SavingsPlans.Model.DescribeSavingsPlansResponse CallAWSServiceOperation(IAmazonSavingsPlans client, Amazon.SavingsPlans.Model.DescribeSavingsPlansRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Savings Plans", "DescribeSavingsPlans");
            try
            {
                return client.DescribeSavingsPlansAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.SavingsPlans.Model.SavingsPlanFilter> Filter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<System.String> SavingsPlanArn { get; set; }
            public List<System.String> SavingsPlanId { get; set; }
            public List<System.String> State { get; set; }
            public System.Func<Amazon.SavingsPlans.Model.DescribeSavingsPlansResponse, GetSPSavingsPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SavingsPlans;
        }
        
    }
}
