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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// Lists resources in your cloud provider that the connector can access, such as management
    /// groups, subscriptions, resource types, Regions, resources, and Event Hubs. Use the
    /// results to build a telemetry manifest. This operation returns results in pages. To
    /// get the next page, pass the returned <c>NextToken</c> in the next call. We recommend
    /// that you use pagination to ensure that the operation returns quickly and successfully.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWOADMNResourcesByConnectorList")]
    [OutputType("Amazon.ObservabilityAdmin.Model.ConnectorQueryResults")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service ListResourcesByConnector API operation.", Operation = new[] {"ListResourcesByConnector"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.ConnectorQueryResults or Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorResponse",
        "This cmdlet returns an Amazon.ObservabilityAdmin.Model.ConnectorQueryResults object.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWOADMNResourcesByConnectorListCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorIdentifier
        /// <summary>
        /// <para>
        /// <para>The connector to use for the query. Specify one of the following:</para><ul><li><para>The Amazon Resource Name (ARN) of the connector</para></li><li><para>The ID of the connector</para></li></ul>
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
        public System.String ConnectorIdentifier { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_EventHubs_Scope_ManagementGroupId
        /// <summary>
        /// <para>
        /// <para>Limits the query to resources under this management group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_EventHubs_Scope_ManagementGroupId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_Regions_Scope_ManagementGroupId
        /// <summary>
        /// <para>
        /// <para>Limits the query to resources under this management group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_Regions_Scope_ManagementGroupId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_ResourceIds_Scope_ManagementGroupId
        /// <summary>
        /// <para>
        /// <para>Limits the query to resources under this management group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_ResourceIds_Scope_ManagementGroupId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_ResourceTypes_Scope_ManagementGroupId
        /// <summary>
        /// <para>
        /// <para>Limits the query to resources under this management group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_ResourceTypes_Scope_ManagementGroupId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_Subscriptions_ManagementGroupId
        /// <summary>
        /// <para>
        /// <para>Limits the results to subscriptions under this management group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_Subscriptions_ManagementGroupId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_EventHubs_NamespaceName
        /// <summary>
        /// <para>
        /// <para>Limits the results to Event Hubs in this namespace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_EventHubs_NamespaceName { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_ManagementGroups_ParentManagementGroupId
        /// <summary>
        /// <para>
        /// <para>Lists the management groups under this management group. If you omit this value, the
        /// query starts at the tenant root group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_ManagementGroups_ParentManagementGroupId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_EventHubs_Region
        /// <summary>
        /// <para>
        /// <para>Limits the results to one Azure Region, for example <c>eastus</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_EventHubs_Region { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_ResourceIds_Region
        /// <summary>
        /// <para>
        /// <para>Limits the results to one Azure Region, for example <c>eastus</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_ResourceIds_Region { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_ResourceIds_ResourceType
        /// <summary>
        /// <para>
        /// <para>Limits the results to one Azure resource type, for example <c>Microsoft.Compute/virtualMachines</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Selector_Azure_ResourceIds_ResourceType { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_EventHubs_Scope_SubscriptionId
        /// <summary>
        /// <para>
        /// <para>Limits the query to these subscriptions. You can specify 1–1000 subscriptions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Selector_Azure_EventHubs_Scope_SubscriptionIds")]
        public System.String[] Selector_Azure_EventHubs_Scope_SubscriptionId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_Regions_Scope_SubscriptionId
        /// <summary>
        /// <para>
        /// <para>Limits the query to these subscriptions. You can specify 1–1000 subscriptions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Selector_Azure_Regions_Scope_SubscriptionIds")]
        public System.String[] Selector_Azure_Regions_Scope_SubscriptionId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_ResourceIds_Scope_SubscriptionId
        /// <summary>
        /// <para>
        /// <para>Limits the query to these subscriptions. You can specify 1–1000 subscriptions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Selector_Azure_ResourceIds_Scope_SubscriptionIds")]
        public System.String[] Selector_Azure_ResourceIds_Scope_SubscriptionId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_ResourceTypes_Scope_SubscriptionId
        /// <summary>
        /// <para>
        /// <para>Limits the query to these subscriptions. You can specify 1–1000 subscriptions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Selector_Azure_ResourceTypes_Scope_SubscriptionIds")]
        public System.String[] Selector_Azure_ResourceTypes_Scope_SubscriptionId { get; set; }
        #endregion
        
        #region Parameter Selector_Azure_ResourceIds_TagFilter
        /// <summary>
        /// <para>
        /// <para>Limits the results to resources that have these tags. A resource must match the filters
        /// for all tag keys, and any of the values for each key. The service matches tag keys
        /// and values case-insensitively, as Azure does.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Selector_Azure_ResourceIds_TagFilters")]
        public Amazon.ObservabilityAdmin.Model.TagFilter[] Selector_Azure_ResourceIds_TagFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in one call. For an <c>EventHubs</c> query,
        /// a page can contain more results than this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The token for the next page of results, returned by a previous call.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Results'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Results";
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
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorResponse, GetCWOADMNResourcesByConnectorListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorIdentifier = this.ConnectorIdentifier;
            #if MODULAR
            if (this.ConnectorIdentifier == null && ParameterWasBound(nameof(this.ConnectorIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Selector_Azure_EventHubs_NamespaceName = this.Selector_Azure_EventHubs_NamespaceName;
            context.Selector_Azure_EventHubs_Region = this.Selector_Azure_EventHubs_Region;
            context.Selector_Azure_EventHubs_Scope_ManagementGroupId = this.Selector_Azure_EventHubs_Scope_ManagementGroupId;
            if (this.Selector_Azure_EventHubs_Scope_SubscriptionId != null)
            {
                context.Selector_Azure_EventHubs_Scope_SubscriptionId = new List<System.String>(this.Selector_Azure_EventHubs_Scope_SubscriptionId);
            }
            context.Selector_Azure_ManagementGroups_ParentManagementGroupId = this.Selector_Azure_ManagementGroups_ParentManagementGroupId;
            context.Selector_Azure_Regions_Scope_ManagementGroupId = this.Selector_Azure_Regions_Scope_ManagementGroupId;
            if (this.Selector_Azure_Regions_Scope_SubscriptionId != null)
            {
                context.Selector_Azure_Regions_Scope_SubscriptionId = new List<System.String>(this.Selector_Azure_Regions_Scope_SubscriptionId);
            }
            context.Selector_Azure_ResourceIds_Region = this.Selector_Azure_ResourceIds_Region;
            context.Selector_Azure_ResourceIds_ResourceType = this.Selector_Azure_ResourceIds_ResourceType;
            context.Selector_Azure_ResourceIds_Scope_ManagementGroupId = this.Selector_Azure_ResourceIds_Scope_ManagementGroupId;
            if (this.Selector_Azure_ResourceIds_Scope_SubscriptionId != null)
            {
                context.Selector_Azure_ResourceIds_Scope_SubscriptionId = new List<System.String>(this.Selector_Azure_ResourceIds_Scope_SubscriptionId);
            }
            if (this.Selector_Azure_ResourceIds_TagFilter != null)
            {
                context.Selector_Azure_ResourceIds_TagFilter = new List<Amazon.ObservabilityAdmin.Model.TagFilter>(this.Selector_Azure_ResourceIds_TagFilter);
            }
            context.Selector_Azure_ResourceTypes_Scope_ManagementGroupId = this.Selector_Azure_ResourceTypes_Scope_ManagementGroupId;
            if (this.Selector_Azure_ResourceTypes_Scope_SubscriptionId != null)
            {
                context.Selector_Azure_ResourceTypes_Scope_SubscriptionId = new List<System.String>(this.Selector_Azure_ResourceTypes_Scope_SubscriptionId);
            }
            context.Selector_Azure_Subscriptions_ManagementGroupId = this.Selector_Azure_Subscriptions_ManagementGroupId;
            
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
            var request = new Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorRequest();
            
            if (cmdletContext.ConnectorIdentifier != null)
            {
                request.ConnectorIdentifier = cmdletContext.ConnectorIdentifier;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            
             // populate Selector
            var requestSelectorIsNull = true;
            request.Selector = new Amazon.ObservabilityAdmin.Model.ConnectorQuery();
            Amazon.ObservabilityAdmin.Model.AzureConnectorQuery requestSelector_selector_Azure = null;
            
             // populate Azure
            var requestSelector_selector_AzureIsNull = true;
            requestSelector_selector_Azure = new Amazon.ObservabilityAdmin.Model.AzureConnectorQuery();
            Amazon.ObservabilityAdmin.Model.AzureManagementGroupsQuery requestSelector_selector_Azure_selector_Azure_ManagementGroups = null;
            
             // populate ManagementGroups
            var requestSelector_selector_Azure_selector_Azure_ManagementGroupsIsNull = true;
            requestSelector_selector_Azure_selector_Azure_ManagementGroups = new Amazon.ObservabilityAdmin.Model.AzureManagementGroupsQuery();
            System.String requestSelector_selector_Azure_selector_Azure_ManagementGroups_selector_Azure_ManagementGroups_ParentManagementGroupId = null;
            if (cmdletContext.Selector_Azure_ManagementGroups_ParentManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ManagementGroups_selector_Azure_ManagementGroups_ParentManagementGroupId = cmdletContext.Selector_Azure_ManagementGroups_ParentManagementGroupId;
            }
            if (requestSelector_selector_Azure_selector_Azure_ManagementGroups_selector_Azure_ManagementGroups_ParentManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ManagementGroups.ParentManagementGroupId = requestSelector_selector_Azure_selector_Azure_ManagementGroups_selector_Azure_ManagementGroups_ParentManagementGroupId;
                requestSelector_selector_Azure_selector_Azure_ManagementGroupsIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_ManagementGroups should be set to null
            if (requestSelector_selector_Azure_selector_Azure_ManagementGroupsIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_ManagementGroups = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_ManagementGroups != null)
            {
                requestSelector_selector_Azure.ManagementGroups = requestSelector_selector_Azure_selector_Azure_ManagementGroups;
                requestSelector_selector_AzureIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureRegionsQuery requestSelector_selector_Azure_selector_Azure_Regions = null;
            
             // populate Regions
            var requestSelector_selector_Azure_selector_Azure_RegionsIsNull = true;
            requestSelector_selector_Azure_selector_Azure_Regions = new Amazon.ObservabilityAdmin.Model.AzureRegionsQuery();
            Amazon.ObservabilityAdmin.Model.AzureQueryScope requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope = null;
            
             // populate Scope
            var requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_ScopeIsNull = true;
            requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope = new Amazon.ObservabilityAdmin.Model.AzureQueryScope();
            System.String requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope_selector_Azure_Regions_Scope_ManagementGroupId = null;
            if (cmdletContext.Selector_Azure_Regions_Scope_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope_selector_Azure_Regions_Scope_ManagementGroupId = cmdletContext.Selector_Azure_Regions_Scope_ManagementGroupId;
            }
            if (requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope_selector_Azure_Regions_Scope_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope.ManagementGroupId = requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope_selector_Azure_Regions_Scope_ManagementGroupId;
                requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_ScopeIsNull = false;
            }
            List<System.String> requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope_selector_Azure_Regions_Scope_SubscriptionId = null;
            if (cmdletContext.Selector_Azure_Regions_Scope_SubscriptionId != null)
            {
                requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope_selector_Azure_Regions_Scope_SubscriptionId = cmdletContext.Selector_Azure_Regions_Scope_SubscriptionId;
            }
            if (requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope_selector_Azure_Regions_Scope_SubscriptionId != null)
            {
                requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope.SubscriptionIds = requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope_selector_Azure_Regions_Scope_SubscriptionId;
                requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_ScopeIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope should be set to null
            if (requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_ScopeIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope != null)
            {
                requestSelector_selector_Azure_selector_Azure_Regions.Scope = requestSelector_selector_Azure_selector_Azure_Regions_selector_Azure_Regions_Scope;
                requestSelector_selector_Azure_selector_Azure_RegionsIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_Regions should be set to null
            if (requestSelector_selector_Azure_selector_Azure_RegionsIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_Regions = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_Regions != null)
            {
                requestSelector_selector_Azure.Regions = requestSelector_selector_Azure_selector_Azure_Regions;
                requestSelector_selector_AzureIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureResourceTypesQuery requestSelector_selector_Azure_selector_Azure_ResourceTypes = null;
            
             // populate ResourceTypes
            var requestSelector_selector_Azure_selector_Azure_ResourceTypesIsNull = true;
            requestSelector_selector_Azure_selector_Azure_ResourceTypes = new Amazon.ObservabilityAdmin.Model.AzureResourceTypesQuery();
            Amazon.ObservabilityAdmin.Model.AzureQueryScope requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope = null;
            
             // populate Scope
            var requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_ScopeIsNull = true;
            requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope = new Amazon.ObservabilityAdmin.Model.AzureQueryScope();
            System.String requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope_selector_Azure_ResourceTypes_Scope_ManagementGroupId = null;
            if (cmdletContext.Selector_Azure_ResourceTypes_Scope_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope_selector_Azure_ResourceTypes_Scope_ManagementGroupId = cmdletContext.Selector_Azure_ResourceTypes_Scope_ManagementGroupId;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope_selector_Azure_ResourceTypes_Scope_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope.ManagementGroupId = requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope_selector_Azure_ResourceTypes_Scope_ManagementGroupId;
                requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_ScopeIsNull = false;
            }
            List<System.String> requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope_selector_Azure_ResourceTypes_Scope_SubscriptionId = null;
            if (cmdletContext.Selector_Azure_ResourceTypes_Scope_SubscriptionId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope_selector_Azure_ResourceTypes_Scope_SubscriptionId = cmdletContext.Selector_Azure_ResourceTypes_Scope_SubscriptionId;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope_selector_Azure_ResourceTypes_Scope_SubscriptionId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope.SubscriptionIds = requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope_selector_Azure_ResourceTypes_Scope_SubscriptionId;
                requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_ScopeIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope should be set to null
            if (requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_ScopeIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceTypes.Scope = requestSelector_selector_Azure_selector_Azure_ResourceTypes_selector_Azure_ResourceTypes_Scope;
                requestSelector_selector_Azure_selector_Azure_ResourceTypesIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_ResourceTypes should be set to null
            if (requestSelector_selector_Azure_selector_Azure_ResourceTypesIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceTypes = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceTypes != null)
            {
                requestSelector_selector_Azure.ResourceTypes = requestSelector_selector_Azure_selector_Azure_ResourceTypes;
                requestSelector_selector_AzureIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureSubscriptionsQuery requestSelector_selector_Azure_selector_Azure_Subscriptions = null;
            
             // populate Subscriptions
            var requestSelector_selector_Azure_selector_Azure_SubscriptionsIsNull = true;
            requestSelector_selector_Azure_selector_Azure_Subscriptions = new Amazon.ObservabilityAdmin.Model.AzureSubscriptionsQuery();
            System.String requestSelector_selector_Azure_selector_Azure_Subscriptions_selector_Azure_Subscriptions_ManagementGroupId = null;
            if (cmdletContext.Selector_Azure_Subscriptions_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_Subscriptions_selector_Azure_Subscriptions_ManagementGroupId = cmdletContext.Selector_Azure_Subscriptions_ManagementGroupId;
            }
            if (requestSelector_selector_Azure_selector_Azure_Subscriptions_selector_Azure_Subscriptions_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_Subscriptions.ManagementGroupId = requestSelector_selector_Azure_selector_Azure_Subscriptions_selector_Azure_Subscriptions_ManagementGroupId;
                requestSelector_selector_Azure_selector_Azure_SubscriptionsIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_Subscriptions should be set to null
            if (requestSelector_selector_Azure_selector_Azure_SubscriptionsIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_Subscriptions = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_Subscriptions != null)
            {
                requestSelector_selector_Azure.Subscriptions = requestSelector_selector_Azure_selector_Azure_Subscriptions;
                requestSelector_selector_AzureIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureEventHubsQuery requestSelector_selector_Azure_selector_Azure_EventHubs = null;
            
             // populate EventHubs
            var requestSelector_selector_Azure_selector_Azure_EventHubsIsNull = true;
            requestSelector_selector_Azure_selector_Azure_EventHubs = new Amazon.ObservabilityAdmin.Model.AzureEventHubsQuery();
            System.String requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_NamespaceName = null;
            if (cmdletContext.Selector_Azure_EventHubs_NamespaceName != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_NamespaceName = cmdletContext.Selector_Azure_EventHubs_NamespaceName;
            }
            if (requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_NamespaceName != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs.NamespaceName = requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_NamespaceName;
                requestSelector_selector_Azure_selector_Azure_EventHubsIsNull = false;
            }
            System.String requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Region = null;
            if (cmdletContext.Selector_Azure_EventHubs_Region != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Region = cmdletContext.Selector_Azure_EventHubs_Region;
            }
            if (requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Region != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs.Region = requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Region;
                requestSelector_selector_Azure_selector_Azure_EventHubsIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureQueryScope requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope = null;
            
             // populate Scope
            var requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_ScopeIsNull = true;
            requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope = new Amazon.ObservabilityAdmin.Model.AzureQueryScope();
            System.String requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope_selector_Azure_EventHubs_Scope_ManagementGroupId = null;
            if (cmdletContext.Selector_Azure_EventHubs_Scope_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope_selector_Azure_EventHubs_Scope_ManagementGroupId = cmdletContext.Selector_Azure_EventHubs_Scope_ManagementGroupId;
            }
            if (requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope_selector_Azure_EventHubs_Scope_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope.ManagementGroupId = requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope_selector_Azure_EventHubs_Scope_ManagementGroupId;
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_ScopeIsNull = false;
            }
            List<System.String> requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope_selector_Azure_EventHubs_Scope_SubscriptionId = null;
            if (cmdletContext.Selector_Azure_EventHubs_Scope_SubscriptionId != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope_selector_Azure_EventHubs_Scope_SubscriptionId = cmdletContext.Selector_Azure_EventHubs_Scope_SubscriptionId;
            }
            if (requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope_selector_Azure_EventHubs_Scope_SubscriptionId != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope.SubscriptionIds = requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope_selector_Azure_EventHubs_Scope_SubscriptionId;
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_ScopeIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope should be set to null
            if (requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_ScopeIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope != null)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs.Scope = requestSelector_selector_Azure_selector_Azure_EventHubs_selector_Azure_EventHubs_Scope;
                requestSelector_selector_Azure_selector_Azure_EventHubsIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_EventHubs should be set to null
            if (requestSelector_selector_Azure_selector_Azure_EventHubsIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_EventHubs = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_EventHubs != null)
            {
                requestSelector_selector_Azure.EventHubs = requestSelector_selector_Azure_selector_Azure_EventHubs;
                requestSelector_selector_AzureIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureResourceIdsQuery requestSelector_selector_Azure_selector_Azure_ResourceIds = null;
            
             // populate ResourceIds
            var requestSelector_selector_Azure_selector_Azure_ResourceIdsIsNull = true;
            requestSelector_selector_Azure_selector_Azure_ResourceIds = new Amazon.ObservabilityAdmin.Model.AzureResourceIdsQuery();
            System.String requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Region = null;
            if (cmdletContext.Selector_Azure_ResourceIds_Region != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Region = cmdletContext.Selector_Azure_ResourceIds_Region;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Region != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds.Region = requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Region;
                requestSelector_selector_Azure_selector_Azure_ResourceIdsIsNull = false;
            }
            System.String requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_ResourceType = null;
            if (cmdletContext.Selector_Azure_ResourceIds_ResourceType != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_ResourceType = cmdletContext.Selector_Azure_ResourceIds_ResourceType;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_ResourceType != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds.ResourceType = requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_ResourceType;
                requestSelector_selector_Azure_selector_Azure_ResourceIdsIsNull = false;
            }
            List<Amazon.ObservabilityAdmin.Model.TagFilter> requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_TagFilter = null;
            if (cmdletContext.Selector_Azure_ResourceIds_TagFilter != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_TagFilter = cmdletContext.Selector_Azure_ResourceIds_TagFilter;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_TagFilter != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds.TagFilters = requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_TagFilter;
                requestSelector_selector_Azure_selector_Azure_ResourceIdsIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureQueryScope requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope = null;
            
             // populate Scope
            var requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_ScopeIsNull = true;
            requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope = new Amazon.ObservabilityAdmin.Model.AzureQueryScope();
            System.String requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope_selector_Azure_ResourceIds_Scope_ManagementGroupId = null;
            if (cmdletContext.Selector_Azure_ResourceIds_Scope_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope_selector_Azure_ResourceIds_Scope_ManagementGroupId = cmdletContext.Selector_Azure_ResourceIds_Scope_ManagementGroupId;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope_selector_Azure_ResourceIds_Scope_ManagementGroupId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope.ManagementGroupId = requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope_selector_Azure_ResourceIds_Scope_ManagementGroupId;
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_ScopeIsNull = false;
            }
            List<System.String> requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope_selector_Azure_ResourceIds_Scope_SubscriptionId = null;
            if (cmdletContext.Selector_Azure_ResourceIds_Scope_SubscriptionId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope_selector_Azure_ResourceIds_Scope_SubscriptionId = cmdletContext.Selector_Azure_ResourceIds_Scope_SubscriptionId;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope_selector_Azure_ResourceIds_Scope_SubscriptionId != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope.SubscriptionIds = requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope_selector_Azure_ResourceIds_Scope_SubscriptionId;
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_ScopeIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope should be set to null
            if (requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_ScopeIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope != null)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds.Scope = requestSelector_selector_Azure_selector_Azure_ResourceIds_selector_Azure_ResourceIds_Scope;
                requestSelector_selector_Azure_selector_Azure_ResourceIdsIsNull = false;
            }
             // determine if requestSelector_selector_Azure_selector_Azure_ResourceIds should be set to null
            if (requestSelector_selector_Azure_selector_Azure_ResourceIdsIsNull)
            {
                requestSelector_selector_Azure_selector_Azure_ResourceIds = null;
            }
            if (requestSelector_selector_Azure_selector_Azure_ResourceIds != null)
            {
                requestSelector_selector_Azure.ResourceIds = requestSelector_selector_Azure_selector_Azure_ResourceIds;
                requestSelector_selector_AzureIsNull = false;
            }
             // determine if requestSelector_selector_Azure should be set to null
            if (requestSelector_selector_AzureIsNull)
            {
                requestSelector_selector_Azure = null;
            }
            if (requestSelector_selector_Azure != null)
            {
                request.Selector.Azure = requestSelector_selector_Azure;
                requestSelectorIsNull = false;
            }
             // determine if request.Selector should be set to null
            if (requestSelectorIsNull)
            {
                request.Selector = null;
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
        
        private Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "ListResourcesByConnector");
            try
            {
                return client.ListResourcesByConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorIdentifier { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String Selector_Azure_EventHubs_NamespaceName { get; set; }
            public System.String Selector_Azure_EventHubs_Region { get; set; }
            public System.String Selector_Azure_EventHubs_Scope_ManagementGroupId { get; set; }
            public List<System.String> Selector_Azure_EventHubs_Scope_SubscriptionId { get; set; }
            public System.String Selector_Azure_ManagementGroups_ParentManagementGroupId { get; set; }
            public System.String Selector_Azure_Regions_Scope_ManagementGroupId { get; set; }
            public List<System.String> Selector_Azure_Regions_Scope_SubscriptionId { get; set; }
            public System.String Selector_Azure_ResourceIds_Region { get; set; }
            public System.String Selector_Azure_ResourceIds_ResourceType { get; set; }
            public System.String Selector_Azure_ResourceIds_Scope_ManagementGroupId { get; set; }
            public List<System.String> Selector_Azure_ResourceIds_Scope_SubscriptionId { get; set; }
            public List<Amazon.ObservabilityAdmin.Model.TagFilter> Selector_Azure_ResourceIds_TagFilter { get; set; }
            public System.String Selector_Azure_ResourceTypes_Scope_ManagementGroupId { get; set; }
            public List<System.String> Selector_Azure_ResourceTypes_Scope_SubscriptionId { get; set; }
            public System.String Selector_Azure_Subscriptions_ManagementGroupId { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.ListResourcesByConnectorResponse, GetCWOADMNResourcesByConnectorListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Results;
        }
        
    }
}
