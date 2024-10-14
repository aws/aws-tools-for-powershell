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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Returns the list of all log groups that are being monitored and tagged by DevOps
    /// Guru.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DGURUMonitoredResourceList")]
    [OutputType("Amazon.DevOpsGuru.Model.MonitoredResourceIdentifier")]
    [AWSCmdlet("Calls the Amazon DevOps Guru ListMonitoredResources API operation.", Operation = new[] {"ListMonitoredResources"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.ListMonitoredResourcesResponse))]
    [AWSCmdletOutput("Amazon.DevOpsGuru.Model.MonitoredResourceIdentifier or Amazon.DevOpsGuru.Model.ListMonitoredResourcesResponse",
        "This cmdlet returns a collection of Amazon.DevOpsGuru.Model.MonitoredResourceIdentifier objects.",
        "The service call response (type Amazon.DevOpsGuru.Model.ListMonitoredResourcesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetDGURUMonitoredResourceListCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_ResourcePermission
        /// <summary>
        /// <para>
        /// <para> The permission status of a resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.DevOpsGuru.ResourcePermission")]
        public Amazon.DevOpsGuru.ResourcePermission Filters_ResourcePermission { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceTypeFilter
        /// <summary>
        /// <para>
        /// <para> The type of resource that you wish to retrieve, such as log groups. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_ResourceTypeFilters")]
        public System.String[] Filters_ResourceTypeFilter { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return with a single call. To retrieve the remaining
        /// results, make another call with the returned <c>nextToken</c> value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token to use to retrieve the next page of results for this operation.
        /// If this value is null, it retrieves the first page.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MonitoredResourceIdentifiers'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.ListMonitoredResourcesResponse).
        /// Specifying the name of a property of type Amazon.DevOpsGuru.Model.ListMonitoredResourcesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MonitoredResourceIdentifiers";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Filters_ResourcePermission parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Filters_ResourcePermission' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Filters_ResourcePermission' instead. This parameter will be removed in a future version.")]
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.ListMonitoredResourcesResponse, GetDGURUMonitoredResourceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Filters_ResourcePermission;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Filters_ResourcePermission = this.Filters_ResourcePermission;
            if (this.Filters_ResourceTypeFilter != null)
            {
                context.Filters_ResourceTypeFilter = new List<System.String>(this.Filters_ResourceTypeFilter);
            }
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
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.DevOpsGuru.Model.ListMonitoredResourcesRequest();
            
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.DevOpsGuru.Model.ListMonitoredResourcesFilters();
            Amazon.DevOpsGuru.ResourcePermission requestFilters_filters_ResourcePermission = null;
            if (cmdletContext.Filters_ResourcePermission != null)
            {
                requestFilters_filters_ResourcePermission = cmdletContext.Filters_ResourcePermission;
            }
            if (requestFilters_filters_ResourcePermission != null)
            {
                request.Filters.ResourcePermission = requestFilters_filters_ResourcePermission;
                requestFiltersIsNull = false;
            }
            List<System.String> requestFilters_filters_ResourceTypeFilter = null;
            if (cmdletContext.Filters_ResourceTypeFilter != null)
            {
                requestFilters_filters_ResourceTypeFilter = cmdletContext.Filters_ResourceTypeFilter;
            }
            if (requestFilters_filters_ResourceTypeFilter != null)
            {
                request.Filters.ResourceTypeFilters = requestFilters_filters_ResourceTypeFilter;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
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
        
        private Amazon.DevOpsGuru.Model.ListMonitoredResourcesResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.ListMonitoredResourcesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "ListMonitoredResources");
            try
            {
                #if DESKTOP
                return client.ListMonitoredResources(request);
                #elif CORECLR
                return client.ListMonitoredResourcesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DevOpsGuru.ResourcePermission Filters_ResourcePermission { get; set; }
            public List<System.String> Filters_ResourceTypeFilter { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.ListMonitoredResourcesResponse, GetDGURUMonitoredResourceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MonitoredResourceIdentifiers;
        }
        
    }
}
