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
    /// Returns compliance details of a conformance pack for all Amazon Web Services resources
    /// that are monitered by conformance pack.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGConformancePackComplianceDetail")]
    [OutputType("Amazon.ConfigService.Model.ConformancePackEvaluationResult")]
    [AWSCmdlet("Calls the AWS Config GetConformancePackComplianceDetails API operation.", Operation = new[] {"GetConformancePackComplianceDetails"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetConformancePackComplianceDetailsResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.ConformancePackEvaluationResult or Amazon.ConfigService.Model.GetConformancePackComplianceDetailsResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.ConformancePackEvaluationResult objects.",
        "The service call response (type Amazon.ConfigService.Model.GetConformancePackComplianceDetailsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGConformancePackComplianceDetailCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_ComplianceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by compliance.</para><para>The allowed values are <c>COMPLIANT</c> and <c>NON_COMPLIANT</c>. <c>INSUFFICIENT_DATA</c>
        /// is not supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.ConformancePackComplianceType")]
        public Amazon.ConfigService.ConformancePackComplianceType Filters_ComplianceType { get; set; }
        #endregion
        
        #region Parameter Filters_ConfigRuleName
        /// <summary>
        /// <para>
        /// <para>Filters the results by Config rule names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ConfigRuleNames")]
        public System.String[] Filters_ConfigRuleName { get; set; }
        #endregion
        
        #region Parameter ConformancePackName
        /// <summary>
        /// <para>
        /// <para>Name of the conformance pack.</para>
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
        public System.String ConformancePackName { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceId
        /// <summary>
        /// <para>
        /// <para>Filters the results by resource IDs.</para><note><para>This is valid only when you provide resource type. If there is no resource type, you
        /// will see an error.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ResourceIds")]
        public System.String[] Filters_ResourceId { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceType
        /// <summary>
        /// <para>
        /// <para>Filters the results by the resource type (for example, <c>"AWS::EC2::Instance"</c>).
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_ResourceType { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of evaluation results returned on each page. If you do no specify
        /// a number, Config uses the default. The default is 100.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The <c>nextToken</c> string returned in a previous request that you use to request
        /// the next page of results in a paginated response.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConformancePackRuleEvaluationResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetConformancePackComplianceDetailsResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetConformancePackComplianceDetailsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConformancePackRuleEvaluationResults";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetConformancePackComplianceDetailsResponse, GetCFGConformancePackComplianceDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConformancePackName = this.ConformancePackName;
            #if MODULAR
            if (this.ConformancePackName == null && ParameterWasBound(nameof(this.ConformancePackName)))
            {
                WriteWarning("You are passing $null as a value for parameter ConformancePackName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Filters_ComplianceType = this.Filters_ComplianceType;
            if (this.Filters_ConfigRuleName != null)
            {
                context.Filters_ConfigRuleName = new List<System.String>(this.Filters_ConfigRuleName);
            }
            if (this.Filters_ResourceId != null)
            {
                context.Filters_ResourceId = new List<System.String>(this.Filters_ResourceId);
            }
            context.Filters_ResourceType = this.Filters_ResourceType;
            context.Limit = this.Limit;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
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
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ConfigService.Model.GetConformancePackComplianceDetailsRequest();
            
            if (cmdletContext.ConformancePackName != null)
            {
                request.ConformancePackName = cmdletContext.ConformancePackName;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.ConformancePackEvaluationFilters();
            Amazon.ConfigService.ConformancePackComplianceType requestFilters_filters_ComplianceType = null;
            if (cmdletContext.Filters_ComplianceType != null)
            {
                requestFilters_filters_ComplianceType = cmdletContext.Filters_ComplianceType;
            }
            if (requestFilters_filters_ComplianceType != null)
            {
                request.Filters.ComplianceType = requestFilters_filters_ComplianceType;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ConfigRuleName = null;
            if (cmdletContext.Filters_ConfigRuleName != null)
            {
                requestFilters_filters_ConfigRuleName = cmdletContext.Filters_ConfigRuleName;
            }
            if (requestFilters_filters_ConfigRuleName != null)
            {
                request.Filters.ConfigRuleNames = requestFilters_filters_ConfigRuleName;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ResourceId = null;
            if (cmdletContext.Filters_ResourceId != null)
            {
                requestFilters_filters_ResourceId = cmdletContext.Filters_ResourceId;
            }
            if (requestFilters_filters_ResourceId != null)
            {
                request.Filters.ResourceIds = requestFilters_filters_ResourceId;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_ResourceType = null;
            if (cmdletContext.Filters_ResourceType != null)
            {
                requestFilters_filters_ResourceType = cmdletContext.Filters_ResourceType;
            }
            if (requestFilters_filters_ResourceType != null)
            {
                request.Filters.ResourceType = requestFilters_filters_ResourceType;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
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
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            var useParameterSelect = this.Select.StartsWith("^");
            
            // create request and set iteration invariants
            var request = new Amazon.ConfigService.Model.GetConformancePackComplianceDetailsRequest();
            if (cmdletContext.ConformancePackName != null)
            {
                request.ConformancePackName = cmdletContext.ConformancePackName;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.ConformancePackEvaluationFilters();
            Amazon.ConfigService.ConformancePackComplianceType requestFilters_filters_ComplianceType = null;
            if (cmdletContext.Filters_ComplianceType != null)
            {
                requestFilters_filters_ComplianceType = cmdletContext.Filters_ComplianceType;
            }
            if (requestFilters_filters_ComplianceType != null)
            {
                request.Filters.ComplianceType = requestFilters_filters_ComplianceType;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ConfigRuleName = null;
            if (cmdletContext.Filters_ConfigRuleName != null)
            {
                requestFilters_filters_ConfigRuleName = cmdletContext.Filters_ConfigRuleName;
            }
            if (requestFilters_filters_ConfigRuleName != null)
            {
                request.Filters.ConfigRuleNames = requestFilters_filters_ConfigRuleName;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ResourceId = null;
            if (cmdletContext.Filters_ResourceId != null)
            {
                requestFilters_filters_ResourceId = cmdletContext.Filters_ResourceId;
            }
            if (requestFilters_filters_ResourceId != null)
            {
                request.Filters.ResourceIds = requestFilters_filters_ResourceId;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_ResourceType = null;
            if (cmdletContext.Filters_ResourceType != null)
            {
                requestFilters_filters_ResourceType = cmdletContext.Filters_ResourceType;
            }
            if (requestFilters_filters_ResourceType != null)
            {
                request.Filters.ResourceType = requestFilters_filters_ResourceType;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Limit.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.Limit;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.Limit = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                
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
                    int _receivedThisCall = response.ConformancePackRuleEvaluationResults?.Count ?? 0;
                    
                    _nextToken = response.NextToken;
                    _retrievedSoFar += _receivedThisCall;
                    if (_emitLimit.HasValue)
                    {
                        _emitLimit -= _receivedThisCall;
                    }
                }
                catch (Exception e)
                {
                    if (_retrievedSoFar == 0 || !_emitLimit.HasValue)
                    {
                        output = new CmdletOutput { ErrorResponse = e };
                    }
                    else
                    {
                        break;
                    }
                }
                
                ProcessOutput(output);
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 0));
            
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ConfigService.Model.GetConformancePackComplianceDetailsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetConformancePackComplianceDetailsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetConformancePackComplianceDetails");
            try
            {
                #if DESKTOP
                return client.GetConformancePackComplianceDetails(request);
                #elif CORECLR
                return client.GetConformancePackComplianceDetailsAsync(request).GetAwaiter().GetResult();
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
            public System.String ConformancePackName { get; set; }
            public Amazon.ConfigService.ConformancePackComplianceType Filters_ComplianceType { get; set; }
            public List<System.String> Filters_ConfigRuleName { get; set; }
            public List<System.String> Filters_ResourceId { get; set; }
            public System.String Filters_ResourceType { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.ConfigService.Model.GetConformancePackComplianceDetailsResponse, GetCFGConformancePackComplianceDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConformancePackRuleEvaluationResults;
        }
        
    }
}
