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
using Amazon.SSMIncidents;
using Amazon.SSMIncidents.Model;

namespace Amazon.PowerShell.Cmdlets.SSMI
{
    /// <summary>
    /// Lists timeline events for the specified incident record.
    /// </summary>
    [Cmdlet("Get", "SSMITimelineEventList")]
    [OutputType("Amazon.SSMIncidents.Model.EventSummary")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager ListTimelineEvents API operation.", Operation = new[] {"ListTimelineEvents"}, SelectReturnType = typeof(Amazon.SSMIncidents.Model.ListTimelineEventsResponse))]
    [AWSCmdletOutput("Amazon.SSMIncidents.Model.EventSummary or Amazon.SSMIncidents.Model.ListTimelineEventsResponse",
        "This cmdlet returns a collection of Amazon.SSMIncidents.Model.EventSummary objects.",
        "The service call response (type Amazon.SSMIncidents.Model.ListTimelineEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetSSMITimelineEventListCmdlet : AmazonSSMIncidentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// <para>Filters the timeline events based on the provided conditional values. You can filter
        /// timeline events with the following keys:</para><ul><li><para><c>eventReference</c></para></li><li><para><c>eventTime</c></para></li><li><para><c>eventType</c></para></li></ul><para>Note the following when deciding how to use Filters:</para><ul><li><para>If you don't specify a Filter, the response includes all timeline events.</para></li><li><para>If you specify more than one filter in a single request, the response returns timeline
        /// events that match all filters.</para></li><li><para>If you specify a filter with more than one value, the response returns timeline events
        /// that match any of the values provided.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters")]
        public Amazon.SSMIncidents.Model.Filter[] Filter { get; set; }
        #endregion
        
        #region Parameter IncidentRecordArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the incident that includes the timeline event.</para>
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
        public System.String IncidentRecordArn { get; set; }
        #endregion
        
        #region Parameter SortBy
        /// <summary>
        /// <para>
        /// <para>Sort timeline events by the specified key value pair.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SSMIncidents.TimelineEventSort")]
        public Amazon.SSMIncidents.TimelineEventSort SortBy { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>Sorts the order of timeline events by the value specified in the <c>sortBy</c> field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SSMIncidents.SortOrder")]
        public Amazon.SSMIncidents.SortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results per page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token for the next set of items to return. (You received this token
        /// from a previous call.)</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventSummaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMIncidents.Model.ListTimelineEventsResponse).
        /// Specifying the name of a property of type Amazon.SSMIncidents.Model.ListTimelineEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventSummaries";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IncidentRecordArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IncidentRecordArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IncidentRecordArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
                context.Select = CreateSelectDelegate<Amazon.SSMIncidents.Model.ListTimelineEventsResponse, GetSSMITimelineEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IncidentRecordArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filter != null)
            {
                context.Filter = new List<Amazon.SSMIncidents.Model.Filter>(this.Filter);
            }
            context.IncidentRecordArn = this.IncidentRecordArn;
            #if MODULAR
            if (this.IncidentRecordArn == null && ParameterWasBound(nameof(this.IncidentRecordArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IncidentRecordArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SortBy = this.SortBy;
            context.SortOrder = this.SortOrder;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SSMIncidents.Model.ListTimelineEventsRequest();
            
            if (cmdletContext.Filter != null)
            {
                request.Filters = cmdletContext.Filter;
            }
            if (cmdletContext.IncidentRecordArn != null)
            {
                request.IncidentRecordArn = cmdletContext.IncidentRecordArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SortBy != null)
            {
                request.SortBy = cmdletContext.SortBy;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.SSMIncidents.Model.ListTimelineEventsResponse CallAWSServiceOperation(IAmazonSSMIncidents client, Amazon.SSMIncidents.Model.ListTimelineEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager", "ListTimelineEvents");
            try
            {
                #if DESKTOP
                return client.ListTimelineEvents(request);
                #elif CORECLR
                return client.ListTimelineEventsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SSMIncidents.Model.Filter> Filter { get; set; }
            public System.String IncidentRecordArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.SSMIncidents.TimelineEventSort SortBy { get; set; }
            public Amazon.SSMIncidents.SortOrder SortOrder { get; set; }
            public System.Func<Amazon.SSMIncidents.Model.ListTimelineEventsResponse, GetSSMITimelineEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventSummaries;
        }
        
    }
}
