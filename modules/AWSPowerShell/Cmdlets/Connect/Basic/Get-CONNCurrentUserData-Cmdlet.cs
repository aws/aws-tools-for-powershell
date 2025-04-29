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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Gets the real-time active user data from the specified Amazon Connect instance.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CONNCurrentUserData")]
    [OutputType("Amazon.Connect.Model.UserData")]
    [AWSCmdlet("Calls the Amazon Connect Service GetCurrentUserData API operation.", Operation = new[] {"GetCurrentUserData"}, SelectReturnType = typeof(Amazon.Connect.Model.GetCurrentUserDataResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.UserData or Amazon.Connect.Model.GetCurrentUserDataResponse",
        "This cmdlet returns a collection of Amazon.Connect.Model.UserData objects.",
        "The service call response (type Amazon.Connect.Model.GetCurrentUserDataResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCONNCurrentUserDataCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Filters_Agent
        /// <summary>
        /// <para>
        /// <para>A list of up to 100 agent IDs or ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Agents")]
        public System.String[] Filters_Agent { get; set; }
        #endregion
        
        #region Parameter ContactFilter_ContactState
        /// <summary>
        /// <para>
        /// <para>A list of up to 9 <a href="https://docs.aws.amazon.com/connect/latest/adminguide/about-contact-states.html">contact
        /// states</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ContactFilter_ContactStates")]
        public System.String[] ContactFilter_ContactState { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Filters_Queue
        /// <summary>
        /// <para>
        /// <para>A list of up to 100 queues or ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_Queues")]
        public System.String[] Filters_Queue { get; set; }
        #endregion
        
        #region Parameter Filters_RoutingProfile
        /// <summary>
        /// <para>
        /// <para>A list of up to 100 routing profile IDs or ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_RoutingProfiles")]
        public System.String[] Filters_RoutingProfile { get; set; }
        #endregion
        
        #region Parameter Filters_UserHierarchyGroup
        /// <summary>
        /// <para>
        /// <para>A UserHierarchyGroup ID or ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_UserHierarchyGroups")]
        public System.String[] Filters_UserHierarchyGroup { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next set of results. Use the value returned in the previous response
        /// in the next request to retrieve the next set of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UserDataList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.GetCurrentUserDataResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.GetCurrentUserDataResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UserDataList";
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
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.GetCurrentUserDataResponse, GetCONNCurrentUserDataCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Filters_Agent != null)
            {
                context.Filters_Agent = new List<System.String>(this.Filters_Agent);
            }
            if (this.ContactFilter_ContactState != null)
            {
                context.ContactFilter_ContactState = new List<System.String>(this.ContactFilter_ContactState);
            }
            if (this.Filters_Queue != null)
            {
                context.Filters_Queue = new List<System.String>(this.Filters_Queue);
            }
            if (this.Filters_RoutingProfile != null)
            {
                context.Filters_RoutingProfile = new List<System.String>(this.Filters_RoutingProfile);
            }
            if (this.Filters_UserHierarchyGroup != null)
            {
                context.Filters_UserHierarchyGroup = new List<System.String>(this.Filters_UserHierarchyGroup);
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
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
            var request = new Amazon.Connect.Model.GetCurrentUserDataRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Connect.Model.UserDataFilters();
            List<System.String> requestFilters_filters_Agent = null;
            if (cmdletContext.Filters_Agent != null)
            {
                requestFilters_filters_Agent = cmdletContext.Filters_Agent;
            }
            if (requestFilters_filters_Agent != null)
            {
                request.Filters.Agents = requestFilters_filters_Agent;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_Queue = null;
            if (cmdletContext.Filters_Queue != null)
            {
                requestFilters_filters_Queue = cmdletContext.Filters_Queue;
            }
            if (requestFilters_filters_Queue != null)
            {
                request.Filters.Queues = requestFilters_filters_Queue;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_RoutingProfile = null;
            if (cmdletContext.Filters_RoutingProfile != null)
            {
                requestFilters_filters_RoutingProfile = cmdletContext.Filters_RoutingProfile;
            }
            if (requestFilters_filters_RoutingProfile != null)
            {
                request.Filters.RoutingProfiles = requestFilters_filters_RoutingProfile;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_UserHierarchyGroup = null;
            if (cmdletContext.Filters_UserHierarchyGroup != null)
            {
                requestFilters_filters_UserHierarchyGroup = cmdletContext.Filters_UserHierarchyGroup;
            }
            if (requestFilters_filters_UserHierarchyGroup != null)
            {
                request.Filters.UserHierarchyGroups = requestFilters_filters_UserHierarchyGroup;
                requestFiltersIsNull = false;
            }
            Amazon.Connect.Model.ContactFilter requestFilters_filters_ContactFilter = null;
            
             // populate ContactFilter
            var requestFilters_filters_ContactFilterIsNull = true;
            requestFilters_filters_ContactFilter = new Amazon.Connect.Model.ContactFilter();
            List<System.String> requestFilters_filters_ContactFilter_contactFilter_ContactState = null;
            if (cmdletContext.ContactFilter_ContactState != null)
            {
                requestFilters_filters_ContactFilter_contactFilter_ContactState = cmdletContext.ContactFilter_ContactState;
            }
            if (requestFilters_filters_ContactFilter_contactFilter_ContactState != null)
            {
                requestFilters_filters_ContactFilter.ContactStates = requestFilters_filters_ContactFilter_contactFilter_ContactState;
                requestFilters_filters_ContactFilterIsNull = false;
            }
             // determine if requestFilters_filters_ContactFilter should be set to null
            if (requestFilters_filters_ContactFilterIsNull)
            {
                requestFilters_filters_ContactFilter = null;
            }
            if (requestFilters_filters_ContactFilter != null)
            {
                request.Filters.ContactFilter = requestFilters_filters_ContactFilter;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
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
        
        private Amazon.Connect.Model.GetCurrentUserDataResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.GetCurrentUserDataRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "GetCurrentUserData");
            try
            {
                return client.GetCurrentUserDataAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Filters_Agent { get; set; }
            public List<System.String> ContactFilter_ContactState { get; set; }
            public List<System.String> Filters_Queue { get; set; }
            public List<System.String> Filters_RoutingProfile { get; set; }
            public List<System.String> Filters_UserHierarchyGroup { get; set; }
            public System.String InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Connect.Model.GetCurrentUserDataResponse, GetCONNCurrentUserDataCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UserDataList;
        }
        
    }
}
