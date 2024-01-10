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
    /// Returns a list of the events emitted by the resources that are evaluated by DevOps
    /// Guru. You can use filters to specify which events are returned.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "DGURUEventList")]
    [OutputType("Amazon.DevOpsGuru.Model.Event")]
    [AWSCmdlet("Calls the Amazon DevOps Guru ListEvents API operation.", Operation = new[] {"ListEvents"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.ListEventsResponse))]
    [AWSCmdletOutput("Amazon.DevOpsGuru.Model.Event or Amazon.DevOpsGuru.Model.ListEventsResponse",
        "This cmdlet returns a collection of Amazon.DevOpsGuru.Model.Event objects.",
        "The service call response (type Amazon.DevOpsGuru.Model.ListEventsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDGURUEventListCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Filters_DataSource
        /// <summary>
        /// <para>
        /// <para> The source, <c>AWS_CLOUD_TRAIL</c> or <c>AWS_CODE_DEPLOY</c>, of the events you want
        /// returned. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsGuru.EventDataSource")]
        public Amazon.DevOpsGuru.EventDataSource Filters_DataSource { get; set; }
        #endregion
        
        #region Parameter Filters_EventClass
        /// <summary>
        /// <para>
        /// <para> The class of the events you want to filter for, such as an infrastructure change,
        /// a deployment, or a schema change. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DevOpsGuru.EventClass")]
        public Amazon.DevOpsGuru.EventClass Filters_EventClass { get; set; }
        #endregion
        
        #region Parameter Filters_EventSource
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services source that emitted the events you want to filter for. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Filters_EventSource { get; set; }
        #endregion
        
        #region Parameter Filters_EventTimeRange
        /// <summary>
        /// <para>
        /// <para> A time range during which you want the filtered events to have occurred. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DevOpsGuru.Model.EventTimeRange Filters_EventTimeRange { get; set; }
        #endregion
        
        #region Parameter Filters_InsightId
        /// <summary>
        /// <para>
        /// <para> An ID of an insight that is related to the events you want to filter for. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Filters_InsightId { get; set; }
        #endregion
        
        #region Parameter Filters_ResourceCollection
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DevOpsGuru.Model.ResourceCollection Filters_ResourceCollection { get; set; }
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
        /// <br/>In order to manually control output pagination, use '-NextToken $null' for the first call and '-NextToken $AWSHistory.LastServiceResponse.NextToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Events'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.ListEventsResponse).
        /// Specifying the name of a property of type Amazon.DevOpsGuru.Model.ListEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Events";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Filters_InsightId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Filters_InsightId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Filters_InsightId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.ListEventsResponse, GetDGURUEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Filters_InsightId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            context.Filters_DataSource = this.Filters_DataSource;
            context.Filters_EventClass = this.Filters_EventClass;
            context.Filters_EventSource = this.Filters_EventSource;
            context.Filters_EventTimeRange = this.Filters_EventTimeRange;
            context.Filters_InsightId = this.Filters_InsightId;
            context.Filters_ResourceCollection = this.Filters_ResourceCollection;
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
            var request = new Amazon.DevOpsGuru.Model.ListEventsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.DevOpsGuru.Model.ListEventsFilters();
            Amazon.DevOpsGuru.EventDataSource requestFilters_filters_DataSource = null;
            if (cmdletContext.Filters_DataSource != null)
            {
                requestFilters_filters_DataSource = cmdletContext.Filters_DataSource;
            }
            if (requestFilters_filters_DataSource != null)
            {
                request.Filters.DataSource = requestFilters_filters_DataSource;
                requestFiltersIsNull = false;
            }
            Amazon.DevOpsGuru.EventClass requestFilters_filters_EventClass = null;
            if (cmdletContext.Filters_EventClass != null)
            {
                requestFilters_filters_EventClass = cmdletContext.Filters_EventClass;
            }
            if (requestFilters_filters_EventClass != null)
            {
                request.Filters.EventClass = requestFilters_filters_EventClass;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_EventSource = null;
            if (cmdletContext.Filters_EventSource != null)
            {
                requestFilters_filters_EventSource = cmdletContext.Filters_EventSource;
            }
            if (requestFilters_filters_EventSource != null)
            {
                request.Filters.EventSource = requestFilters_filters_EventSource;
                requestFiltersIsNull = false;
            }
            Amazon.DevOpsGuru.Model.EventTimeRange requestFilters_filters_EventTimeRange = null;
            if (cmdletContext.Filters_EventTimeRange != null)
            {
                requestFilters_filters_EventTimeRange = cmdletContext.Filters_EventTimeRange;
            }
            if (requestFilters_filters_EventTimeRange != null)
            {
                request.Filters.EventTimeRange = requestFilters_filters_EventTimeRange;
                requestFiltersIsNull = false;
            }
            System.String requestFilters_filters_InsightId = null;
            if (cmdletContext.Filters_InsightId != null)
            {
                requestFilters_filters_InsightId = cmdletContext.Filters_InsightId;
            }
            if (requestFilters_filters_InsightId != null)
            {
                request.Filters.InsightId = requestFilters_filters_InsightId;
                requestFiltersIsNull = false;
            }
            Amazon.DevOpsGuru.Model.ResourceCollection requestFilters_filters_ResourceCollection = null;
            if (cmdletContext.Filters_ResourceCollection != null)
            {
                requestFilters_filters_ResourceCollection = cmdletContext.Filters_ResourceCollection;
            }
            if (requestFilters_filters_ResourceCollection != null)
            {
                request.Filters.ResourceCollection = requestFilters_filters_ResourceCollection;
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
        
        private Amazon.DevOpsGuru.Model.ListEventsResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.ListEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "ListEvents");
            try
            {
                #if DESKTOP
                return client.ListEvents(request);
                #elif CORECLR
                return client.ListEventsAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public Amazon.DevOpsGuru.EventDataSource Filters_DataSource { get; set; }
            public Amazon.DevOpsGuru.EventClass Filters_EventClass { get; set; }
            public System.String Filters_EventSource { get; set; }
            public Amazon.DevOpsGuru.Model.EventTimeRange Filters_EventTimeRange { get; set; }
            public System.String Filters_InsightId { get; set; }
            public Amazon.DevOpsGuru.Model.ResourceCollection Filters_ResourceCollection { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.ListEventsResponse, GetDGURUEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Events;
        }
        
    }
}
