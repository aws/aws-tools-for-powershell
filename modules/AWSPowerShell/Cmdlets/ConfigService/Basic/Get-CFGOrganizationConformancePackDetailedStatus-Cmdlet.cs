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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns detailed status for each member account within an organization for a given
    /// organization conformance pack.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGOrganizationConformancePackDetailedStatus")]
    [OutputType("Amazon.ConfigService.Model.OrganizationConformancePackDetailedStatus")]
    [AWSCmdlet("Calls the AWS Config GetOrganizationConformancePackDetailedStatus API operation.", Operation = new[] {"GetOrganizationConformancePackDetailedStatus"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.OrganizationConformancePackDetailedStatus or Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.OrganizationConformancePackDetailedStatus objects.",
        "The service call response (type Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGOrganizationConformancePackDetailedStatusCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit account ID of the member account within an organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter OrganizationConformancePackName
        /// <summary>
        /// <para>
        /// <para>The name of organization conformance pack for which you want status details for member
        /// accounts.</para>
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
        public System.String OrganizationConformancePackName { get; set; }
        #endregion
        
        #region Parameter Filters_Status
        /// <summary>
        /// <para>
        /// <para>Indicates deployment status for conformance pack in a member account. When management
        /// account calls <c>PutOrganizationConformancePack</c> action for the first time, conformance
        /// pack status is created in the member account. When management account calls <c>PutOrganizationConformancePack</c>
        /// action for the second time, conformance pack status is updated in the member account.
        /// Conformance pack status is deleted when the management account deletes <c>OrganizationConformancePack</c>
        /// and disables service access for <c>config-multiaccountsetup.amazonaws.com</c>. </para><para> Config sets the state of the conformance pack to:</para><ul><li><para><c>CREATE_SUCCESSFUL</c> when conformance pack has been created in the member account.
        /// </para></li><li><para><c>CREATE_IN_PROGRESS</c> when conformance pack is being created in the member account.</para></li><li><para><c>CREATE_FAILED</c> when conformance pack creation has failed in the member account.</para></li><li><para><c>DELETE_FAILED</c> when conformance pack deletion has failed in the member account.</para></li><li><para><c>DELETE_IN_PROGRESS</c> when conformance pack is being deleted in the member account.</para></li><li><para><c>DELETE_SUCCESSFUL</c> when conformance pack has been deleted in the member account.
        /// </para></li><li><para><c>UPDATE_SUCCESSFUL</c> when conformance pack has been updated in the member account.</para></li><li><para><c>UPDATE_IN_PROGRESS</c> when conformance pack is being updated in the member account.</para></li><li><para><c>UPDATE_FAILED</c> when conformance pack deletion has failed in the member account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.OrganizationResourceDetailedStatus")]
        public Amazon.ConfigService.OrganizationResourceDetailedStatus Filters_Status { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of <c>OrganizationConformancePackDetailedStatuses</c> returned
        /// on each page. If you do not specify a number, Config uses the default. The default
        /// is 100. </para>
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
        /// <para>The nextToken string returned on a previous page that you use to get the next page
        /// of results in a paginated response. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationConformancePackDetailedStatuses'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationConformancePackDetailedStatuses";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusResponse, GetCFGOrganizationConformancePackDetailedStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_AccountId = this.Filters_AccountId;
            context.Filters_Status = this.Filters_Status;
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
            context.OrganizationConformancePackName = this.OrganizationConformancePackName;
            #if MODULAR
            if (this.OrganizationConformancePackName == null && ParameterWasBound(nameof(this.OrganizationConformancePackName)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationConformancePackName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.OrganizationResourceDetailedStatusFilters();
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
            Amazon.ConfigService.OrganizationResourceDetailedStatus requestFilters_filters_Status = null;
            if (cmdletContext.Filters_Status != null)
            {
                requestFilters_filters_Status = cmdletContext.Filters_Status;
            }
            if (requestFilters_filters_Status != null)
            {
                request.Filters.Status = requestFilters_filters_Status;
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
            if (cmdletContext.OrganizationConformancePackName != null)
            {
                request.OrganizationConformancePackName = cmdletContext.OrganizationConformancePackName;
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
            var request = new Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusRequest();
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.OrganizationResourceDetailedStatusFilters();
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
            Amazon.ConfigService.OrganizationResourceDetailedStatus requestFilters_filters_Status = null;
            if (cmdletContext.Filters_Status != null)
            {
                requestFilters_filters_Status = cmdletContext.Filters_Status;
            }
            if (requestFilters_filters_Status != null)
            {
                request.Filters.Status = requestFilters_filters_Status;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.OrganizationConformancePackName != null)
            {
                request.OrganizationConformancePackName = cmdletContext.OrganizationConformancePackName;
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
                    int _receivedThisCall = response.OrganizationConformancePackDetailedStatuses?.Count ?? 0;
                    
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
        
        private Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetOrganizationConformancePackDetailedStatus");
            try
            {
                #if DESKTOP
                return client.GetOrganizationConformancePackDetailedStatus(request);
                #elif CORECLR
                return client.GetOrganizationConformancePackDetailedStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String Filters_AccountId { get; set; }
            public Amazon.ConfigService.OrganizationResourceDetailedStatus Filters_Status { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String OrganizationConformancePackName { get; set; }
            public System.Func<Amazon.ConfigService.Model.GetOrganizationConformancePackDetailedStatusResponse, GetCFGOrganizationConformancePackDetailedStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationConformancePackDetailedStatuses;
        }
        
    }
}
