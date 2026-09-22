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
using Amazon.CloudWatchOmni;
using Amazon.CloudWatchOmni.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOM
{
    /// <summary>
    /// Lists alerts within a space, optionally filtered by exact name(s), a single name prefix,
    /// or exact alertId(s), with pagination.
    /// 
    ///  
    /// <para>
    /// Use GetAlert to retrieve a single alert's full detail.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWOMAlertList")]
    [OutputType("Amazon.CloudWatchOmni.Model.AlertSummary")]
    [AWSCmdlet("Calls the CloudWatch Omni ListAlerts API operation.", Operation = new[] {"ListAlerts"}, SelectReturnType = typeof(Amazon.CloudWatchOmni.Model.ListAlertsResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchOmni.Model.AlertSummary or Amazon.CloudWatchOmni.Model.ListAlertsResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchOmni.Model.AlertSummary objects.",
        "The service call response (type Amazon.CloudWatchOmni.Model.ListAlertsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWOMAlertListCmdlet : AmazonCloudWatchOmniClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FilterCriteria_Id
        /// <summary>
        /// <para>
        /// <para>Filter to alerts whose {@link AlertId} exactly matches any entry (OR semantics). Mutually
        /// exclusive with {@code names} and {@code namePrefix}.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Ids")]
        public System.String[] FilterCriteria_Id { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_NamePrefix
        /// <summary>
        /// <para>
        /// <para>Filter to alerts whose name starts with this prefix. Mutually exclusive with {@code
        /// names} and {@code ids}.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FilterCriteria_NamePrefix { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_Name
        /// <summary>
        /// <para>
        /// <para>Filter to alerts whose name exactly matches any entry (OR semantics). Mutually exclusive
        /// with {@code namePrefix} and {@code ids}.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCriteria_Names")]
        public System.String[] FilterCriteria_Name { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_NotificationsEnabled
        /// <summary>
        /// <para>
        /// <para>Filter to alerts by whether notifications are enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FilterCriteria_NotificationsEnabled { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>The field to sort results by.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.AlertSortField")]
        public Amazon.CloudWatchOmni.AlertSortField SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The order in which to sort results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchOmni.AlertSortOrder")]
        public Amazon.CloudWatchOmni.AlertSortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter SpaceId
        /// <summary>
        /// <para>
        /// <para>The unique ID of the space.</para>
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
        public System.String SpaceId { get; set; }
        #endregion
        
        #region Parameter FilterCriteria_StateValue
        /// <summary>
        /// <para>
        /// <para>Filter to alerts currently in any of these states (OR semantics).</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] FilterCriteria_StateValue { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of alerts to return per page.</para>
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
        /// <para>A token to retrieve the next page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Items'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchOmni.Model.ListAlertsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchOmni.Model.ListAlertsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Items";
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
                context.Select = CreateSelectDelegate<Amazon.CloudWatchOmni.Model.ListAlertsResponse, GetCWOMAlertListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.FilterCriteria_Id != null)
            {
                context.FilterCriteria_Id = new List<System.String>(this.FilterCriteria_Id);
            }
            context.FilterCriteria_NamePrefix = this.FilterCriteria_NamePrefix;
            if (this.FilterCriteria_Name != null)
            {
                context.FilterCriteria_Name = new List<System.String>(this.FilterCriteria_Name);
            }
            context.FilterCriteria_NotificationsEnabled = this.FilterCriteria_NotificationsEnabled;
            if (this.FilterCriteria_StateValue != null)
            {
                context.FilterCriteria_StateValue = new List<System.String>(this.FilterCriteria_StateValue);
            }
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
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            context.SpaceId = this.SpaceId;
            #if MODULAR
            if (this.SpaceId == null && ParameterWasBound(nameof(this.SpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CloudWatchOmni.Model.ListAlertsRequest();
            
            
             // populate FilterCriteria
            var requestFilterCriteriaIsNull = true;
            request.FilterCriteria = new Amazon.CloudWatchOmni.Model.AlertFilterCriteria();
            List<System.String> requestFilterCriteria_filterCriteria_Id = null;
            if (cmdletContext.FilterCriteria_Id != null)
            {
                requestFilterCriteria_filterCriteria_Id = cmdletContext.FilterCriteria_Id;
            }
            if (requestFilterCriteria_filterCriteria_Id != null)
            {
                request.FilterCriteria.Ids = requestFilterCriteria_filterCriteria_Id;
                requestFilterCriteriaIsNull = false;
            }
            System.String requestFilterCriteria_filterCriteria_NamePrefix = null;
            if (cmdletContext.FilterCriteria_NamePrefix != null)
            {
                requestFilterCriteria_filterCriteria_NamePrefix = cmdletContext.FilterCriteria_NamePrefix;
            }
            if (requestFilterCriteria_filterCriteria_NamePrefix != null)
            {
                request.FilterCriteria.NamePrefix = requestFilterCriteria_filterCriteria_NamePrefix;
                requestFilterCriteriaIsNull = false;
            }
            List<System.String> requestFilterCriteria_filterCriteria_Name = null;
            if (cmdletContext.FilterCriteria_Name != null)
            {
                requestFilterCriteria_filterCriteria_Name = cmdletContext.FilterCriteria_Name;
            }
            if (requestFilterCriteria_filterCriteria_Name != null)
            {
                request.FilterCriteria.Names = requestFilterCriteria_filterCriteria_Name;
                requestFilterCriteriaIsNull = false;
            }
            System.Boolean? requestFilterCriteria_filterCriteria_NotificationsEnabled = null;
            if (cmdletContext.FilterCriteria_NotificationsEnabled != null)
            {
                requestFilterCriteria_filterCriteria_NotificationsEnabled = cmdletContext.FilterCriteria_NotificationsEnabled.Value;
            }
            if (requestFilterCriteria_filterCriteria_NotificationsEnabled != null)
            {
                request.FilterCriteria.NotificationsEnabled = requestFilterCriteria_filterCriteria_NotificationsEnabled.Value;
                requestFilterCriteriaIsNull = false;
            }
            List<System.String> requestFilterCriteria_filterCriteria_StateValue = null;
            if (cmdletContext.FilterCriteria_StateValue != null)
            {
                requestFilterCriteria_filterCriteria_StateValue = cmdletContext.FilterCriteria_StateValue;
            }
            if (requestFilterCriteria_filterCriteria_StateValue != null)
            {
                request.FilterCriteria.StateValue = requestFilterCriteria_filterCriteria_StateValue;
                requestFilterCriteriaIsNull = false;
            }
             // determine if request.FilterCriteria should be set to null
            if (requestFilterCriteriaIsNull)
            {
                request.FilterCriteria = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.SpaceId != null)
            {
                request.SpaceId = cmdletContext.SpaceId;
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
        
        private Amazon.CloudWatchOmni.Model.ListAlertsResponse CallAWSServiceOperation(IAmazonCloudWatchOmni client, Amazon.CloudWatchOmni.Model.ListAlertsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Omni", "ListAlerts");
            try
            {
                return client.ListAlertsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> FilterCriteria_Id { get; set; }
            public System.String FilterCriteria_NamePrefix { get; set; }
            public List<System.String> FilterCriteria_Name { get; set; }
            public System.Boolean? FilterCriteria_NotificationsEnabled { get; set; }
            public List<System.String> FilterCriteria_StateValue { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.CloudWatchOmni.AlertSortField SortBy { get; set; }
            public Amazon.CloudWatchOmni.AlertSortOrder SortOrder { get; set; }
            public System.String SpaceId { get; set; }
            public System.Func<Amazon.CloudWatchOmni.Model.ListAlertsResponse, GetCWOMAlertListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
