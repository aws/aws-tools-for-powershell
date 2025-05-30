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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// A paginated call to get a list of all custom line item versions.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "ABCCustomLineItemVersionList")]
    [OutputType("Amazon.BillingConductor.Model.CustomLineItemVersionListElement")]
    [AWSCmdlet("Calls the AWSBillingConductor ListCustomLineItemVersions API operation.", Operation = new[] {"ListCustomLineItemVersions"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.CustomLineItemVersionListElement or Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse",
        "This cmdlet returns a collection of Amazon.BillingConductor.Model.CustomLineItemVersionListElement objects.",
        "The service call response (type Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetABCCustomLineItemVersionListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the custom line item.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_EndBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The exclusive end billing period that defines a billing period range where a custom
        /// line item version is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_BillingPeriodRange_EndBillingPeriod")]
        public System.String BillingPeriodRange_EndBillingPeriod { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_StartBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The inclusive start billing period that defines a billing period range where a custom
        /// line item version is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_BillingPeriodRange_StartBillingPeriod")]
        public System.String BillingPeriodRange_StartBillingPeriod { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of custom line item versions to retrieve.</para>
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
        /// <para>The pagination token that's used on subsequent calls to retrieve custom line item
        /// versions.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomLineItemVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomLineItemVersions";
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
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse, GetABCCustomLineItemVersionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BillingPeriodRange_EndBillingPeriod = this.BillingPeriodRange_EndBillingPeriod;
            context.BillingPeriodRange_StartBillingPeriod = this.BillingPeriodRange_StartBillingPeriod;
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
            var request = new Amazon.BillingConductor.Model.ListCustomLineItemVersionsRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.BillingConductor.Model.ListCustomLineItemVersionsFilter();
            Amazon.BillingConductor.Model.ListCustomLineItemVersionsBillingPeriodRangeFilter requestFilters_filters_BillingPeriodRange = null;
            
             // populate BillingPeriodRange
            var requestFilters_filters_BillingPeriodRangeIsNull = true;
            requestFilters_filters_BillingPeriodRange = new Amazon.BillingConductor.Model.ListCustomLineItemVersionsBillingPeriodRangeFilter();
            System.String requestFilters_filters_BillingPeriodRange_billingPeriodRange_EndBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_EndBillingPeriod != null)
            {
                requestFilters_filters_BillingPeriodRange_billingPeriodRange_EndBillingPeriod = cmdletContext.BillingPeriodRange_EndBillingPeriod;
            }
            if (requestFilters_filters_BillingPeriodRange_billingPeriodRange_EndBillingPeriod != null)
            {
                requestFilters_filters_BillingPeriodRange.EndBillingPeriod = requestFilters_filters_BillingPeriodRange_billingPeriodRange_EndBillingPeriod;
                requestFilters_filters_BillingPeriodRangeIsNull = false;
            }
            System.String requestFilters_filters_BillingPeriodRange_billingPeriodRange_StartBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_StartBillingPeriod != null)
            {
                requestFilters_filters_BillingPeriodRange_billingPeriodRange_StartBillingPeriod = cmdletContext.BillingPeriodRange_StartBillingPeriod;
            }
            if (requestFilters_filters_BillingPeriodRange_billingPeriodRange_StartBillingPeriod != null)
            {
                requestFilters_filters_BillingPeriodRange.StartBillingPeriod = requestFilters_filters_BillingPeriodRange_billingPeriodRange_StartBillingPeriod;
                requestFilters_filters_BillingPeriodRangeIsNull = false;
            }
             // determine if requestFilters_filters_BillingPeriodRange should be set to null
            if (requestFilters_filters_BillingPeriodRangeIsNull)
            {
                requestFilters_filters_BillingPeriodRange = null;
            }
            if (requestFilters_filters_BillingPeriodRange != null)
            {
                request.Filters.BillingPeriodRange = requestFilters_filters_BillingPeriodRange;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        
        private Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListCustomLineItemVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListCustomLineItemVersions");
            try
            {
                return client.ListCustomLineItemVersionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String BillingPeriodRange_EndBillingPeriod { get; set; }
            public System.String BillingPeriodRange_StartBillingPeriod { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse, GetABCCustomLineItemVersionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomLineItemVersions;
        }
        
    }
}
