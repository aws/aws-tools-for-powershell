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
using Amazon.WorkMail;
using Amazon.WorkMail.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WM
{
    /// <summary>
    /// Returns summaries of the organization's users.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "WMUserList")]
    [OutputType("Amazon.WorkMail.Model.User")]
    [AWSCmdlet("Calls the Amazon WorkMail ListUsers API operation.", Operation = new[] {"ListUsers"}, SelectReturnType = typeof(Amazon.WorkMail.Model.ListUsersResponse))]
    [AWSCmdletOutput("Amazon.WorkMail.Model.User or Amazon.WorkMail.Model.ListUsersResponse",
        "This cmdlet returns a collection of Amazon.WorkMail.Model.User objects.",
        "The service call response (type Amazon.WorkMail.Model.ListUsersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetWMUserListCmdlet : AmazonWorkMailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_DisplayNamePrefix
        /// <summary>
        /// <para>
        /// <para>Filters only users with the provided display name prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_DisplayNamePrefix { get; set; }
        #endregion
        
        #region Parameter Filters_IdentityProviderUserIdPrefix
        /// <summary>
        /// <para>
        /// <para>Filters only users with the ID from the IAM Identity Center.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_IdentityProviderUserIdPrefix { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The identifier for the organization under which the users exist.</para>
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
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Filters_PrimaryEmailPrefix
        /// <summary>
        /// <para>
        /// <para>Filters only users with the provided email prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_PrimaryEmailPrefix { get; set; }
        #endregion
        
        #region Parameter Filters_State
        /// <summary>
        /// <para>
        /// <para>Filters only users with the provided state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkMail.EntityState")]
        public Amazon.WorkMail.EntityState Filters_State { get; set; }
        #endregion
        
        #region Parameter Filters_UsernamePrefix
        /// <summary>
        /// <para>
        /// <para>Filters only users with the provided username prefix.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_UsernamePrefix { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// <para>If a value for this parameter is not specified the cmdlet will use a default value of '<b>100</b>'.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems","MaxResults")]
        public int? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token to use to retrieve the next page of results. The first call does not contain
        /// any tokens.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Users'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkMail.Model.ListUsersResponse).
        /// Specifying the name of a property of type Amazon.WorkMail.Model.ListUsersResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Users";
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
                context.Select = CreateSelectDelegate<Amazon.WorkMail.Model.ListUsersResponse, GetWMUserListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Filters_DisplayNamePrefix = this.Filters_DisplayNamePrefix;
            context.Filters_IdentityProviderUserIdPrefix = this.Filters_IdentityProviderUserIdPrefix;
            context.Filters_PrimaryEmailPrefix = this.Filters_PrimaryEmailPrefix;
            context.Filters_State = this.Filters_State;
            context.Filters_UsernamePrefix = this.Filters_UsernamePrefix;
            context.MaxResult = this.MaxResult;
            #if MODULAR
            if (!ParameterWasBound(nameof(this.MaxResult)))
            {
                WriteVerbose("MaxResult parameter unset, using default value of '100'");
                context.MaxResult = 100;
            }
            #endif
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
            context.OrganizationId = this.OrganizationId;
            #if MODULAR
            if (this.OrganizationId == null && ParameterWasBound(nameof(this.OrganizationId)))
            {
                WriteWarning("You are passing $null as a value for parameter OrganizationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkMail.Model.ListUsersRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.WorkMail.Model.ListUsersFilters();
            System.String requestFilters_filters_DisplayNamePrefix = null;
            if (cmdletContext.Filters_DisplayNamePrefix != null)
            {
                requestFilters_filters_DisplayNamePrefix = cmdletContext.Filters_DisplayNamePrefix;
            }
            if (requestFilters_filters_DisplayNamePrefix != null)
            {
                request.Filters.DisplayNamePrefix = requestFilters_filters_DisplayNamePrefix;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_IdentityProviderUserIdPrefix = null;
            if (cmdletContext.Filters_IdentityProviderUserIdPrefix != null)
            {
                requestFilters_filters_IdentityProviderUserIdPrefix = cmdletContext.Filters_IdentityProviderUserIdPrefix;
            }
            if (requestFilters_filters_IdentityProviderUserIdPrefix != null)
            {
                request.Filters.IdentityProviderUserIdPrefix = requestFilters_filters_IdentityProviderUserIdPrefix;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_PrimaryEmailPrefix = null;
            if (cmdletContext.Filters_PrimaryEmailPrefix != null)
            {
                requestFilters_filters_PrimaryEmailPrefix = cmdletContext.Filters_PrimaryEmailPrefix;
            }
            if (requestFilters_filters_PrimaryEmailPrefix != null)
            {
                request.Filters.PrimaryEmailPrefix = requestFilters_filters_PrimaryEmailPrefix;
                requestFiltersIsNull = false;
            }
            Amazon.WorkMail.EntityState requestFilters_filters_State = null;
            if (cmdletContext.Filters_State != null)
            {
                requestFilters_filters_State = cmdletContext.Filters_State;
            }
            if (requestFilters_filters_State != null)
            {
                request.Filters.State = requestFilters_filters_State;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_UsernamePrefix = null;
            if (cmdletContext.Filters_UsernamePrefix != null)
            {
                requestFilters_filters_UsernamePrefix = cmdletContext.Filters_UsernamePrefix;
            }
            if (requestFilters_filters_UsernamePrefix != null)
            {
                request.Filters.UsernamePrefix = requestFilters_filters_UsernamePrefix;
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
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
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
            var request = new Amazon.WorkMail.Model.ListUsersRequest();
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.WorkMail.Model.ListUsersFilters();
            System.String requestFilters_filters_DisplayNamePrefix = null;
            if (cmdletContext.Filters_DisplayNamePrefix != null)
            {
                requestFilters_filters_DisplayNamePrefix = cmdletContext.Filters_DisplayNamePrefix;
            }
            if (requestFilters_filters_DisplayNamePrefix != null)
            {
                request.Filters.DisplayNamePrefix = requestFilters_filters_DisplayNamePrefix;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_IdentityProviderUserIdPrefix = null;
            if (cmdletContext.Filters_IdentityProviderUserIdPrefix != null)
            {
                requestFilters_filters_IdentityProviderUserIdPrefix = cmdletContext.Filters_IdentityProviderUserIdPrefix;
            }
            if (requestFilters_filters_IdentityProviderUserIdPrefix != null)
            {
                request.Filters.IdentityProviderUserIdPrefix = requestFilters_filters_IdentityProviderUserIdPrefix;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_PrimaryEmailPrefix = null;
            if (cmdletContext.Filters_PrimaryEmailPrefix != null)
            {
                requestFilters_filters_PrimaryEmailPrefix = cmdletContext.Filters_PrimaryEmailPrefix;
            }
            if (requestFilters_filters_PrimaryEmailPrefix != null)
            {
                request.Filters.PrimaryEmailPrefix = requestFilters_filters_PrimaryEmailPrefix;
                requestFiltersIsNull = false;
            }
            Amazon.WorkMail.EntityState requestFilters_filters_State = null;
            if (cmdletContext.Filters_State != null)
            {
                requestFilters_filters_State = cmdletContext.Filters_State;
            }
            if (requestFilters_filters_State != null)
            {
                request.Filters.State = requestFilters_filters_State;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_UsernamePrefix = null;
            if (cmdletContext.Filters_UsernamePrefix != null)
            {
                requestFilters_filters_UsernamePrefix = cmdletContext.Filters_UsernamePrefix;
            }
            if (requestFilters_filters_UsernamePrefix != null)
            {
                request.Filters.UsernamePrefix = requestFilters_filters_UsernamePrefix;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            
            // Initialize loop variants and commence piping
            System.String _nextToken = null;
            int? _emitLimit = null;
            int _retrievedSoFar = 0;
            if (AutoIterationHelpers.HasValue(cmdletContext.NextToken))
            {
                _nextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.MaxResult.HasValue)
            {
                // The service has a maximum page size of 100. If the user has
                // asked for more items than page max, and there is no page size
                // configured, we rely on the service ignoring the set maximum
                // and giving us 100 items back. If a page size is set, that will
                // be used to configure the pagination.
                // We'll make further calls to satisfy the user's request.
                _emitLimit = cmdletContext.MaxResult;
            }
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextToken = _nextToken;
                if (_emitLimit.HasValue)
                {
                    int correctPageSize = Math.Min(100, _emitLimit.Value);
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(correctPageSize);
                }
                else if (!ParameterWasBound(nameof(this.MaxResult)))
                {
                    request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToInt32(100);
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
                    int _receivedThisCall = response.Users?.Count ?? 0;
                    
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
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken) && (!_emitLimit.HasValue || _emitLimit.Value >= 1));
            
            
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
        
        private Amazon.WorkMail.Model.ListUsersResponse CallAWSServiceOperation(IAmazonWorkMail client, Amazon.WorkMail.Model.ListUsersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkMail", "ListUsers");
            try
            {
                return client.ListUsersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Filters_DisplayNamePrefix { get; set; }
            public System.String Filters_IdentityProviderUserIdPrefix { get; set; }
            public System.String Filters_PrimaryEmailPrefix { get; set; }
            public Amazon.WorkMail.EntityState Filters_State { get; set; }
            public System.String Filters_UsernamePrefix { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OrganizationId { get; set; }
            public System.Func<Amazon.WorkMail.Model.ListUsersResponse, GetWMUserListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Users;
        }
        
    }
}
