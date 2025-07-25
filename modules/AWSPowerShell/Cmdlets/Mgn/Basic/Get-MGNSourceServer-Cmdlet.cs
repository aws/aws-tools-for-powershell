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
using Amazon.Mgn;
using Amazon.Mgn.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MGN
{
    /// <summary>
    /// Retrieves all SourceServers or multiple SourceServers by ID.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration. This cmdlet didn't autopaginate in V4, auto-pagination support was added in V5.
    /// </summary>
    [Cmdlet("Get", "MGNSourceServer")]
    [OutputType("Amazon.Mgn.Model.SourceServer")]
    [AWSCmdlet("Calls the Application Migration Service DescribeSourceServers API operation.", Operation = new[] {"DescribeSourceServers"}, SelectReturnType = typeof(Amazon.Mgn.Model.DescribeSourceServersResponse))]
    [AWSCmdletOutput("Amazon.Mgn.Model.SourceServer or Amazon.Mgn.Model.DescribeSourceServersResponse",
        "This cmdlet returns a collection of Amazon.Mgn.Model.SourceServer objects.",
        "The service call response (type Amazon.Mgn.Model.DescribeSourceServersResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetMGNSourceServerCmdlet : AmazonMgnClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountID
        /// <summary>
        /// <para>
        /// <para>Request to filter Source Servers list by Accoun ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountID { get; set; }
        #endregion
        
        #region Parameter Filters_ApplicationIDs
        /// <summary>
        /// <para>
        /// <para>Request to filter Source Servers list by application IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_ApplicationIDs { get; set; }
        #endregion
        
        #region Parameter Filters_IsArchived
        /// <summary>
        /// <para>
        /// <para>Request to filter Source Servers list by archived.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Filters_IsArchived { get; set; }
        #endregion
        
        #region Parameter Filters_LifeCycleState
        /// <summary>
        /// <para>
        /// <para>Request to filter Source Servers list by life cycle states.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_LifeCycleStates")]
        public System.String[] Filters_LifeCycleState { get; set; }
        #endregion
        
        #region Parameter Filters_ReplicationType
        /// <summary>
        /// <para>
        /// <para>Request to filter Source Servers list by replication type.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ReplicationTypes")]
        public System.String[] Filters_ReplicationType { get; set; }
        #endregion
        
        #region Parameter Filters_SourceServerIDs
        /// <summary>
        /// <para>
        /// <para>Request to filter Source Servers list by Source Server ID.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Filters_SourceServerIDs { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>Request to filter Source Servers list by maximum results.</para>
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
        /// <para>Request to filter Source Servers list by next token.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Mgn.Model.DescribeSourceServersResponse).
        /// Specifying the name of a property of type Amazon.Mgn.Model.DescribeSourceServersResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Mgn.Model.DescribeSourceServersResponse, GetMGNSourceServerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountID = this.AccountID;
            if (this.Filters_ApplicationIDs != null)
            {
                context.Filters_ApplicationIDs = new List<System.String>(this.Filters_ApplicationIDs);
            }
            context.Filters_IsArchived = this.Filters_IsArchived;
            if (this.Filters_LifeCycleState != null)
            {
                context.Filters_LifeCycleState = new List<System.String>(this.Filters_LifeCycleState);
            }
            if (this.Filters_ReplicationType != null)
            {
                context.Filters_ReplicationType = new List<System.String>(this.Filters_ReplicationType);
            }
            if (this.Filters_SourceServerIDs != null)
            {
                context.Filters_SourceServerIDs = new List<System.String>(this.Filters_SourceServerIDs);
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
            var request = new Amazon.Mgn.Model.DescribeSourceServersRequest();
            
            if (cmdletContext.AccountID != null)
            {
                request.AccountID = cmdletContext.AccountID;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.Mgn.Model.DescribeSourceServersRequestFilters();
            List<System.String> requestFilters_filters_ApplicationIDs = null;
            if (cmdletContext.Filters_ApplicationIDs != null)
            {
                requestFilters_filters_ApplicationIDs = cmdletContext.Filters_ApplicationIDs;
            }
            if (requestFilters_filters_ApplicationIDs != null)
            {
                request.Filters.ApplicationIDs = requestFilters_filters_ApplicationIDs;
                requestFiltersIsNull = false;
            }
            System.Boolean? requestFilters_filters_IsArchived = null;
            if (cmdletContext.Filters_IsArchived != null)
            {
                requestFilters_filters_IsArchived = cmdletContext.Filters_IsArchived.Value;
            }
            if (requestFilters_filters_IsArchived != null)
            {
                request.Filters.IsArchived = requestFilters_filters_IsArchived.Value;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_LifeCycleState = null;
            if (cmdletContext.Filters_LifeCycleState != null)
            {
                requestFilters_filters_LifeCycleState = cmdletContext.Filters_LifeCycleState;
            }
            if (requestFilters_filters_LifeCycleState != null)
            {
                request.Filters.LifeCycleStates = requestFilters_filters_LifeCycleState;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ReplicationType = null;
            if (cmdletContext.Filters_ReplicationType != null)
            {
                requestFilters_filters_ReplicationType = cmdletContext.Filters_ReplicationType;
            }
            if (requestFilters_filters_ReplicationType != null)
            {
                request.Filters.ReplicationTypes = requestFilters_filters_ReplicationType;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_SourceServerIDs = null;
            if (cmdletContext.Filters_SourceServerIDs != null)
            {
                requestFilters_filters_SourceServerIDs = cmdletContext.Filters_SourceServerIDs;
            }
            if (requestFilters_filters_SourceServerIDs != null)
            {
                request.Filters.SourceServerIDs = requestFilters_filters_SourceServerIDs;
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
        
        private Amazon.Mgn.Model.DescribeSourceServersResponse CallAWSServiceOperation(IAmazonMgn client, Amazon.Mgn.Model.DescribeSourceServersRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Application Migration Service", "DescribeSourceServers");
            try
            {
                return client.DescribeSourceServersAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountID { get; set; }
            public List<System.String> Filters_ApplicationIDs { get; set; }
            public System.Boolean? Filters_IsArchived { get; set; }
            public List<System.String> Filters_LifeCycleState { get; set; }
            public List<System.String> Filters_ReplicationType { get; set; }
            public List<System.String> Filters_SourceServerIDs { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Mgn.Model.DescribeSourceServersResponse, GetMGNSourceServerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Items;
        }
        
    }
}
