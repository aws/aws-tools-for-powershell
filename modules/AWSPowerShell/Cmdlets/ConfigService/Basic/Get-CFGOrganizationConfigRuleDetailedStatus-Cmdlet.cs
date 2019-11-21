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
    /// organization config rule.
    /// 
    ///  <note><para>
    /// Only a master account can call this API.
    /// </para></note><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CFGOrganizationConfigRuleDetailedStatus")]
    [OutputType("Amazon.ConfigService.Model.MemberAccountStatus")]
    [AWSCmdlet("Calls the AWS Config GetOrganizationConfigRuleDetailedStatus API operation.", Operation = new[] {"GetOrganizationConfigRuleDetailedStatus"}, SelectReturnType = typeof(Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.MemberAccountStatus or Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.MemberAccountStatus objects.",
        "The service call response (type Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCFGOrganizationConfigRuleDetailedStatusCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Filters_AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit account ID of the member account within an organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_AccountId { get; set; }
        #endregion
        
        #region Parameter Filters_MemberAccountRuleStatus
        /// <summary>
        /// <para>
        /// <para>Indicates deployment status for config rule in the member account. When master account
        /// calls <code>PutOrganizationConfigRule</code> action for the first time, config rule
        /// status is created in the member account. When master account calls <code>PutOrganizationConfigRule</code>
        /// action for the second time, config rule status is updated in the member account. Config
        /// rule status is deleted when the master account deletes <code>OrganizationConfigRule</code>
        /// and disables service access for <code>config-multiaccountsetup.amazonaws.com</code>.
        /// </para><para>AWS Config sets the state of the rule to:</para><ul><li><para><code>CREATE_SUCCESSFUL</code> when config rule has been created in the member account.</para></li><li><para><code>CREATE_IN_PROGRESS</code> when config rule is being created in the member account.</para></li><li><para><code>CREATE_FAILED</code> when config rule creation has failed in the member account.</para></li><li><para><code>DELETE_FAILED</code> when config rule deletion has failed in the member account.</para></li><li><para><code>DELETE_IN_PROGRESS</code> when config rule is being deleted in the member account.</para></li><li><para><code>DELETE_SUCCESSFUL</code> when config rule has been deleted in the member account.</para></li><li><para><code>UPDATE_SUCCESSFUL</code> when config rule has been updated in the member account.</para></li><li><para><code>UPDATE_IN_PROGRESS</code> when config rule is being updated in the member account.</para></li><li><para><code>UPDATE_FAILED</code> when config rule deletion has failed in the member account.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConfigService.MemberAccountRuleStatus")]
        public Amazon.ConfigService.MemberAccountRuleStatus Filters_MemberAccountRuleStatus { get; set; }
        #endregion
        
        #region Parameter OrganizationConfigRuleName
        /// <summary>
        /// <para>
        /// <para>The name of organization config rule for which you want status details for member
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
        public System.String OrganizationConfigRuleName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of <code>OrganizationConfigRuleDetailedStatus</code> returned on
        /// each page. If you do not specify a number, AWS Config uses the default. The default
        /// is 100.</para>
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
        /// <para>The <code>nextToken</code> string returned on a previous page that you use to get
        /// the next page of results in a paginated response. </para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'OrganizationConfigRuleDetailedStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "OrganizationConfigRuleDetailedStatus";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OrganizationConfigRuleName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OrganizationConfigRuleName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OrganizationConfigRuleName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusResponse, GetCFGOrganizationConfigRuleDetailedStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OrganizationConfigRuleName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filters_AccountId = this.Filters_AccountId;
            context.Filters_MemberAccountRuleStatus = this.Filters_MemberAccountRuleStatus;
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
            context.OrganizationConfigRuleName = this.OrganizationConfigRuleName;
            #if MODULAR
            if (this.OrganizationConfigRuleName == null && ParameterWasBound(nameof(this.OrganizationConfigRuleName)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationConfigRuleName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.StatusDetailFilters();
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
            Amazon.ConfigService.MemberAccountRuleStatus requestFilters_filters_MemberAccountRuleStatus = null;
            if (cmdletContext.Filters_MemberAccountRuleStatus != null)
            {
                requestFilters_filters_MemberAccountRuleStatus = cmdletContext.Filters_MemberAccountRuleStatus;
            }
            if (requestFilters_filters_MemberAccountRuleStatus != null)
            {
                request.Filters.MemberAccountRuleStatus = requestFilters_filters_MemberAccountRuleStatus;
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
            if (cmdletContext.OrganizationConfigRuleName != null)
            {
                request.OrganizationConfigRuleName = cmdletContext.OrganizationConfigRuleName;
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
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            
            // create request and set iteration invariants
            var request = new Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusRequest();
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.ConfigService.Model.StatusDetailFilters();
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
            Amazon.ConfigService.MemberAccountRuleStatus requestFilters_filters_MemberAccountRuleStatus = null;
            if (cmdletContext.Filters_MemberAccountRuleStatus != null)
            {
                requestFilters_filters_MemberAccountRuleStatus = cmdletContext.Filters_MemberAccountRuleStatus;
            }
            if (requestFilters_filters_MemberAccountRuleStatus != null)
            {
                request.Filters.MemberAccountRuleStatus = requestFilters_filters_MemberAccountRuleStatus;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.OrganizationConfigRuleName != null)
            {
                request.OrganizationConfigRuleName = cmdletContext.OrganizationConfigRuleName;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (AutoIterationHelpers.HasValue(cmdletContext.Limit))
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
                    int correctPageSize = AutoIterationHelpers.Min(100, _emitLimit.Value);
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
                    int _receivedThisCall = response.OrganizationConfigRuleDetailedStatus.Count;
                    
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
        
        private Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "GetOrganizationConfigRuleDetailedStatus");
            try
            {
                #if DESKTOP
                return client.GetOrganizationConfigRuleDetailedStatus(request);
                #elif CORECLR
                return client.GetOrganizationConfigRuleDetailedStatusAsync(request).GetAwaiter().GetResult();
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
            public Amazon.ConfigService.MemberAccountRuleStatus Filters_MemberAccountRuleStatus { get; set; }
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public System.String OrganizationConfigRuleName { get; set; }
            public System.Func<Amazon.ConfigService.Model.GetOrganizationConfigRuleDetailedStatusResponse, GetCFGOrganizationConfigRuleDetailedStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.OrganizationConfigRuleDetailedStatus;
        }
        
    }
}
