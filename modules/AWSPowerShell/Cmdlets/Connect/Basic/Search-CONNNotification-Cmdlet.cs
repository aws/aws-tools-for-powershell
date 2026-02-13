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
    /// Searches for notifications based on specified criteria and filters. Returns a paginated
    /// list of notifications matching the search parameters, ordered by descending creation
    /// time. Supports filtering by content and tags.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Search", "CONNNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.SearchNotificationsResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service SearchNotifications API operation.", Operation = new[] {"SearchNotifications"}, SelectReturnType = typeof(Amazon.Connect.Model.SearchNotificationsResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.SearchNotificationsResponse",
        "This cmdlet returns an Amazon.Connect.Model.SearchNotificationsResponse object containing multiple properties."
    )]
    public partial class SearchCONNNotificationCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SearchCriteria_AndCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions that must all be satisfied.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_AndConditions")]
        public Amazon.Connect.Model.NotificationSearchCriteria[] SearchCriteria_AndCondition { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_StringCondition_ComparisonType
        /// <summary>
        /// <para>
        /// <para>The type of comparison to be made when evaluating the string condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.StringComparisonType")]
        public Amazon.Connect.StringComparisonType SearchCriteria_StringCondition_ComparisonType { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_StringCondition_FieldName
        /// <summary>
        /// <para>
        /// <para>The name of the field in the string condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchCriteria_StringCondition_FieldName { get; set; }
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
        
        #region Parameter SearchCriteria_OrCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions to be met, where at least one condition must be satisfied.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchCriteria_OrConditions")]
        public Amazon.Connect.Model.NotificationSearchCriteria[] SearchCriteria_OrCondition { get; set; }
        #endregion
        
        #region Parameter SearchFilter_AttributeFilter_OrCondition
        /// <summary>
        /// <para>
        /// <para>A list of conditions which would be applied together with an <c>OR</c> condition.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilter_AttributeFilter_OrConditions")]
        public Amazon.Connect.Model.CommonAttributeAndCondition[] SearchFilter_AttributeFilter_OrCondition { get; set; }
        #endregion
        
        #region Parameter SearchFilter_AttributeFilter_AndCondition_TagCondition
        /// <summary>
        /// <para>
        /// <para>A leaf node condition which can be used to specify a tag condition.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SearchFilter_AttributeFilter_AndCondition_TagConditions")]
        public Amazon.Connect.Model.TagCondition[] SearchFilter_AttributeFilter_AndCondition_TagCondition { get; set; }
        #endregion
        
        #region Parameter SearchFilter_AttributeFilter_TagCondition_TagKey
        /// <summary>
        /// <para>
        /// <para>The tag key in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchFilter_AttributeFilter_TagCondition_TagKey { get; set; }
        #endregion
        
        #region Parameter SearchFilter_AttributeFilter_TagCondition_TagValue
        /// <summary>
        /// <para>
        /// <para>The tag value in the tag condition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchFilter_AttributeFilter_TagCondition_TagValue { get; set; }
        #endregion
        
        #region Parameter SearchCriteria_StringCondition_Value
        /// <summary>
        /// <para>
        /// <para>The value of the string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SearchCriteria_StringCondition_Value { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return per page. Valid range is 1-100.</para>
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
        /// to retrieve the next page of results.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.SearchNotificationsResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.SearchNotificationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-CONNNotification (SearchNotifications)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.SearchNotificationsResponse, SearchCONNNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            if (this.SearchCriteria_AndCondition != null)
            {
                context.SearchCriteria_AndCondition = new List<Amazon.Connect.Model.NotificationSearchCriteria>(this.SearchCriteria_AndCondition);
            }
            if (this.SearchCriteria_OrCondition != null)
            {
                context.SearchCriteria_OrCondition = new List<Amazon.Connect.Model.NotificationSearchCriteria>(this.SearchCriteria_OrCondition);
            }
            context.SearchCriteria_StringCondition_ComparisonType = this.SearchCriteria_StringCondition_ComparisonType;
            context.SearchCriteria_StringCondition_FieldName = this.SearchCriteria_StringCondition_FieldName;
            context.SearchCriteria_StringCondition_Value = this.SearchCriteria_StringCondition_Value;
            if (this.SearchFilter_AttributeFilter_AndCondition_TagCondition != null)
            {
                context.SearchFilter_AttributeFilter_AndCondition_TagCondition = new List<Amazon.Connect.Model.TagCondition>(this.SearchFilter_AttributeFilter_AndCondition_TagCondition);
            }
            if (this.SearchFilter_AttributeFilter_OrCondition != null)
            {
                context.SearchFilter_AttributeFilter_OrCondition = new List<Amazon.Connect.Model.CommonAttributeAndCondition>(this.SearchFilter_AttributeFilter_OrCondition);
            }
            context.SearchFilter_AttributeFilter_TagCondition_TagKey = this.SearchFilter_AttributeFilter_TagCondition_TagKey;
            context.SearchFilter_AttributeFilter_TagCondition_TagValue = this.SearchFilter_AttributeFilter_TagCondition_TagValue;
            
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
            var request = new Amazon.Connect.Model.SearchNotificationsRequest();
            
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate SearchCriteria
            var requestSearchCriteriaIsNull = true;
            request.SearchCriteria = new Amazon.Connect.Model.NotificationSearchCriteria();
            List<Amazon.Connect.Model.NotificationSearchCriteria> requestSearchCriteria_searchCriteria_AndCondition = null;
            if (cmdletContext.SearchCriteria_AndCondition != null)
            {
                requestSearchCriteria_searchCriteria_AndCondition = cmdletContext.SearchCriteria_AndCondition;
            }
            if (requestSearchCriteria_searchCriteria_AndCondition != null)
            {
                request.SearchCriteria.AndConditions = requestSearchCriteria_searchCriteria_AndCondition;
                requestSearchCriteriaIsNull = false;
            }
            List<Amazon.Connect.Model.NotificationSearchCriteria> requestSearchCriteria_searchCriteria_OrCondition = null;
            if (cmdletContext.SearchCriteria_OrCondition != null)
            {
                requestSearchCriteria_searchCriteria_OrCondition = cmdletContext.SearchCriteria_OrCondition;
            }
            if (requestSearchCriteria_searchCriteria_OrCondition != null)
            {
                request.SearchCriteria.OrConditions = requestSearchCriteria_searchCriteria_OrCondition;
                requestSearchCriteriaIsNull = false;
            }
            Amazon.Connect.Model.StringCondition requestSearchCriteria_searchCriteria_StringCondition = null;
            
             // populate StringCondition
            var requestSearchCriteria_searchCriteria_StringConditionIsNull = true;
            requestSearchCriteria_searchCriteria_StringCondition = new Amazon.Connect.Model.StringCondition();
            Amazon.Connect.StringComparisonType requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_ComparisonType = null;
            if (cmdletContext.SearchCriteria_StringCondition_ComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_ComparisonType = cmdletContext.SearchCriteria_StringCondition_ComparisonType;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_ComparisonType != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.ComparisonType = requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_ComparisonType;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_FieldName = null;
            if (cmdletContext.SearchCriteria_StringCondition_FieldName != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_FieldName = cmdletContext.SearchCriteria_StringCondition_FieldName;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_FieldName != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.FieldName = requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_FieldName;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
            System.String requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_Value = null;
            if (cmdletContext.SearchCriteria_StringCondition_Value != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_Value = cmdletContext.SearchCriteria_StringCondition_Value;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_Value != null)
            {
                requestSearchCriteria_searchCriteria_StringCondition.Value = requestSearchCriteria_searchCriteria_StringCondition_searchCriteria_StringCondition_Value;
                requestSearchCriteria_searchCriteria_StringConditionIsNull = false;
            }
             // determine if requestSearchCriteria_searchCriteria_StringCondition should be set to null
            if (requestSearchCriteria_searchCriteria_StringConditionIsNull)
            {
                requestSearchCriteria_searchCriteria_StringCondition = null;
            }
            if (requestSearchCriteria_searchCriteria_StringCondition != null)
            {
                request.SearchCriteria.StringCondition = requestSearchCriteria_searchCriteria_StringCondition;
                requestSearchCriteriaIsNull = false;
            }
             // determine if request.SearchCriteria should be set to null
            if (requestSearchCriteriaIsNull)
            {
                request.SearchCriteria = null;
            }
            
             // populate SearchFilter
            var requestSearchFilterIsNull = true;
            request.SearchFilter = new Amazon.Connect.Model.NotificationSearchFilter();
            Amazon.Connect.Model.ControlPlaneAttributeFilter requestSearchFilter_searchFilter_AttributeFilter = null;
            
             // populate AttributeFilter
            var requestSearchFilter_searchFilter_AttributeFilterIsNull = true;
            requestSearchFilter_searchFilter_AttributeFilter = new Amazon.Connect.Model.ControlPlaneAttributeFilter();
            List<Amazon.Connect.Model.CommonAttributeAndCondition> requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_OrCondition = null;
            if (cmdletContext.SearchFilter_AttributeFilter_OrCondition != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_OrCondition = cmdletContext.SearchFilter_AttributeFilter_OrCondition;
            }
            if (requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_OrCondition != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter.OrConditions = requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_OrCondition;
                requestSearchFilter_searchFilter_AttributeFilterIsNull = false;
            }
            Amazon.Connect.Model.CommonAttributeAndCondition requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition = null;
            
             // populate AndCondition
            var requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndConditionIsNull = true;
            requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition = new Amazon.Connect.Model.CommonAttributeAndCondition();
            List<Amazon.Connect.Model.TagCondition> requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition_searchFilter_AttributeFilter_AndCondition_TagCondition = null;
            if (cmdletContext.SearchFilter_AttributeFilter_AndCondition_TagCondition != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition_searchFilter_AttributeFilter_AndCondition_TagCondition = cmdletContext.SearchFilter_AttributeFilter_AndCondition_TagCondition;
            }
            if (requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition_searchFilter_AttributeFilter_AndCondition_TagCondition != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition.TagConditions = requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition_searchFilter_AttributeFilter_AndCondition_TagCondition;
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndConditionIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition should be set to null
            if (requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndConditionIsNull)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition = null;
            }
            if (requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter.AndCondition = requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_AndCondition;
                requestSearchFilter_searchFilter_AttributeFilterIsNull = false;
            }
            Amazon.Connect.Model.TagCondition requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition = null;
            
             // populate TagCondition
            var requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagConditionIsNull = true;
            requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition = new Amazon.Connect.Model.TagCondition();
            System.String requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition_searchFilter_AttributeFilter_TagCondition_TagKey = null;
            if (cmdletContext.SearchFilter_AttributeFilter_TagCondition_TagKey != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition_searchFilter_AttributeFilter_TagCondition_TagKey = cmdletContext.SearchFilter_AttributeFilter_TagCondition_TagKey;
            }
            if (requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition_searchFilter_AttributeFilter_TagCondition_TagKey != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition.TagKey = requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition_searchFilter_AttributeFilter_TagCondition_TagKey;
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagConditionIsNull = false;
            }
            System.String requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition_searchFilter_AttributeFilter_TagCondition_TagValue = null;
            if (cmdletContext.SearchFilter_AttributeFilter_TagCondition_TagValue != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition_searchFilter_AttributeFilter_TagCondition_TagValue = cmdletContext.SearchFilter_AttributeFilter_TagCondition_TagValue;
            }
            if (requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition_searchFilter_AttributeFilter_TagCondition_TagValue != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition.TagValue = requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition_searchFilter_AttributeFilter_TagCondition_TagValue;
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagConditionIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition should be set to null
            if (requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagConditionIsNull)
            {
                requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition = null;
            }
            if (requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition != null)
            {
                requestSearchFilter_searchFilter_AttributeFilter.TagCondition = requestSearchFilter_searchFilter_AttributeFilter_searchFilter_AttributeFilter_TagCondition;
                requestSearchFilter_searchFilter_AttributeFilterIsNull = false;
            }
             // determine if requestSearchFilter_searchFilter_AttributeFilter should be set to null
            if (requestSearchFilter_searchFilter_AttributeFilterIsNull)
            {
                requestSearchFilter_searchFilter_AttributeFilter = null;
            }
            if (requestSearchFilter_searchFilter_AttributeFilter != null)
            {
                request.SearchFilter.AttributeFilter = requestSearchFilter_searchFilter_AttributeFilter;
                requestSearchFilterIsNull = false;
            }
             // determine if request.SearchFilter should be set to null
            if (requestSearchFilterIsNull)
            {
                request.SearchFilter = null;
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
        
        private Amazon.Connect.Model.SearchNotificationsResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.SearchNotificationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "SearchNotifications");
            try
            {
                return client.SearchNotificationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public List<Amazon.Connect.Model.NotificationSearchCriteria> SearchCriteria_AndCondition { get; set; }
            public List<Amazon.Connect.Model.NotificationSearchCriteria> SearchCriteria_OrCondition { get; set; }
            public Amazon.Connect.StringComparisonType SearchCriteria_StringCondition_ComparisonType { get; set; }
            public System.String SearchCriteria_StringCondition_FieldName { get; set; }
            public System.String SearchCriteria_StringCondition_Value { get; set; }
            public List<Amazon.Connect.Model.TagCondition> SearchFilter_AttributeFilter_AndCondition_TagCondition { get; set; }
            public List<Amazon.Connect.Model.CommonAttributeAndCondition> SearchFilter_AttributeFilter_OrCondition { get; set; }
            public System.String SearchFilter_AttributeFilter_TagCondition_TagKey { get; set; }
            public System.String SearchFilter_AttributeFilter_TagCondition_TagValue { get; set; }
            public System.Func<Amazon.Connect.Model.SearchNotificationsResponse, SearchCONNNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
