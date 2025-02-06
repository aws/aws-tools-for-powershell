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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the count of compliant and noncompliant conformance packs across all Amazon
    /// Web Services accounts and Amazon Web Services Regions in an aggregator. You can filter
    /// based on Amazon Web Services account ID or Amazon Web Services Region.
    /// 
    ///  <note><para>
    /// The results can return an empty result page, but if you have a nextToken, the results
    /// are displayed on the next page.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGAggregateConformancePackComplianceSummary")]
    [OutputType("Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse")]
    [AWSCmdlet("Calls the AWS Config GetAggregateConformancePackComplianceSummary API operation.", Operation = new[] {"GetAggregateConformancePackComplianceSummary"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse",
        "This cmdlet returns an Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse object containing multiple properties."
    )]
    public partial class GetCFGAggregateConformancePackComplianceSummaryCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit Amazon Web Services account ID of the source account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter Filters_AwsRegion
        /// <summary>
        /// <para>
        /// <para>The source Amazon Web Services Region from where the data is aggregated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_AwsRegion { get; set; }
        #endregion
        
        #region Parameter ConfigurationAggregatorName
        /// <summary>
        /// <para>
        /// <para>The name of the configuration aggregator.</para>
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
        public System.String ConfigurationAggregatorName { get; set; }
        #endregion
        
        #region Parameter GroupByKey
        /// <summary>
        /// <para>
        /// <para>Groups the result based on Amazon Web Services account ID or Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.AggregateConformancePackComplianceSummaryGroupKey")]
        public Amazon.ConfigService.AggregateConformancePackComplianceSummaryGroupKey GroupByKey { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of results returned on each page. The default is maximum. If you
        /// specify 0, Config uses the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> string returned on a previous page that you use to get the next
        /// page of results in a paginated response.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse, GetCFGAggregateConformancePackComplianceSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConfigurationAggregatorName = this.ConfigurationAggregatorName;
            #if MODULAR
            if (this.ConfigurationAggregatorName == null && ParameterWasBound(nameof(this.ConfigurationAggregatorName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationAggregatorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Filters_AccountId = this.Filters_AccountId;
            context.Filters_AwsRegion = this.Filters_AwsRegion;
            context.GroupByKey = this.GroupByKey;
            context.Limit = this.Limit;
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
            var request = new Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryRequest();
            
            if (cmdletContext.ConfigurationAggregatorName != null)
            {
                request.ConfigurationAggregatorName = cmdletContext.ConfigurationAggregatorName;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.AggregateConformancePackComplianceSummaryFilters();
            System.String requestFilters_filters_AccountId = null;
            if (cmdletContext.Filters_AccountId != null)
            {
                requestFilters_filters_AccountId = cmdletContext.Filters_AccountId;
            }
            if (requestFilters_filters_AccountId != null)
            {
                request.Filters.AccountId = requestFilters_filters_AccountId;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_AwsRegion = null;
            if (cmdletContext.Filters_AwsRegion != null)
            {
                requestFilters_filters_AwsRegion = cmdletContext.Filters_AwsRegion;
            }
            if (requestFilters_filters_AwsRegion != null)
            {
                request.Filters.AwsRegion = requestFilters_filters_AwsRegion;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.GroupByKey != null)
            {
                request.GroupByKey = cmdletContext.GroupByKey;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
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
        
        private Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetAggregateConformancePackComplianceSummary");
            try
            {
                #if DESKTOP
                return client.GetAggregateConformancePackComplianceSummary(request);
                #elif CORECLR
                return client.GetAggregateConformancePackComplianceSummaryAsync(request).GetAwaiter().GetResult();
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
            public System.String ConfigurationAggregatorName { get; set; }
            public System.String Filters_AccountId { get; set; }
            public System.String Filters_AwsRegion { get; set; }
            public Amazon.ConfigService.AggregateConformancePackComplianceSummaryGroupKey GroupByKey { get; set; }
            public System.Int32? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ConfigService.Model.GetAggregateConformancePackComplianceSummaryResponse, GetCFGAggregateConformancePackComplianceSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
