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
using Amazon.Route53;
using Amazon.Route53.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Lists the individual changes in the change history of a hosted zone. Each entry is
    /// one change, with the full resource record set that the change wrote or deleted. To
    /// list only the changes to the resource record sets that have a specific name and type,
    /// specify <c>RecordName</c> and <c>RecordType</c>. Weighted, latency, and other resource
    /// record sets that have the same name and type appear as separate entries, each with
    /// its <c>SetIdentifier</c>.
    /// 
    ///  
    /// <para>
    /// A change can take a few seconds to appear in <c>ListResourceRecordSetChanges</c> after
    /// it appears in <c>ListHostedZoneChangeBatches</c>. For a complete, ordered list of
    /// changes, use <c>ListHostedZoneChangeBatches</c>.
    /// </para><para>
    /// Results are paginated. To get the next page, use the <c>NextToken</c> value from the
    /// response.
    /// </para><para>
    /// If Change History isn't turned on for the hosted zone, Route 53 returns a <c>FeatureNotEnabled</c>
    /// error.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "R53ResourceRecordSetChangeList")]
    [OutputType("Amazon.Route53.Model.ResourceRecordSetChange")]
    [AWSCmdlet("Calls the Amazon Route 53 ListResourceRecordSetChanges API operation.", Operation = new[] {"ListResourceRecordSetChanges"}, SelectReturnType = typeof(Amazon.Route53.Model.ListResourceRecordSetChangesResponse))]
    [AWSCmdletOutput("Amazon.Route53.Model.ResourceRecordSetChange or Amazon.Route53.Model.ListResourceRecordSetChangesResponse",
        "This cmdlet returns a collection of Amazon.Route53.Model.ResourceRecordSetChange objects.",
        "The service call response (type Amazon.Route53.Model.ListResourceRecordSetChangesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetR53ResourceRecordSetChangeListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter HostedZoneId
        /// <summary>
        /// <para>
        /// <para>The ID of the hosted zone that you want to list changes for.</para>
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
        public System.String HostedZoneId { get; set; }
        #endregion
        
        #region Parameter RecordName
        /// <summary>
        /// <para>
        /// <para>The name of the resource record sets that you want to list changes for, for example,
        /// <c>www.example.com</c>. The name must be the name of the hosted zone or a subdomain
        /// of it. If you specify <c>RecordName</c>, you must also specify <c>RecordType</c>.
        /// If you specify neither, the results include every change in the hosted zone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RecordName { get; set; }
        #endregion
        
        #region Parameter RecordType
        /// <summary>
        /// <para>
        /// <para>The DNS record type of the resource record sets that you want to list changes for.
        /// If you specify <c>RecordType</c>, you must also specify <c>RecordName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53.RRType")]
        public Amazon.Route53.RRType RecordType { get; set; }
        #endregion
        
        #region Parameter SortOrder
        /// <summary>
        /// <para>
        /// <para>The order in which you want Route 53 to return changes. Valid values:</para><ul><li><para><c>DESCENDING</c> – Newest first. This is the default.</para></li><li><para><c>ASCENDING</c> – Oldest first.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Route53.ChangeHistorySortOrder")]
        public Amazon.Route53.ChangeHistorySortOrder SortOrder { get; set; }
        #endregion
        
        #region Parameter SubmittedAfter
        /// <summary>
        /// <para>
        /// <para>The start of the time range, in ISO 8601 format with a UTC offset, for example <c>2026-12-01T00:00:00Z</c>
        /// or <c>2026-12-01T05:30:00.123+05:30</c>. You can specify up to nine fractional digits.
        /// Route 53 rounds a value with more than millisecond precision up to the next millisecond.
        /// The range includes <c>SubmittedAfter</c>.</para><para>If you don't specify a value, the range starts at <c>RetentionStartsAt</c>. If you
        /// specify a value that's earlier than <c>RetentionStartsAt</c>, Route 53 returns an
        /// <c>InvalidInput</c> error that includes the earliest time that you can specify.</para><para>Because submit times can be slightly out of order, a returned <c>SubmittedAt</c> can
        /// fall just outside the range that you requested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubmittedAfter { get; set; }
        #endregion
        
        #region Parameter SubmittedBefore
        /// <summary>
        /// <para>
        /// <para>The end of the time range, in ISO 8601 format with a UTC offset, for example <c>2026-12-02T00:00:00Z</c>
        /// or <c>2026-12-02T05:30:00.123+05:30</c>. You can specify up to nine fractional digits.
        /// Route 53 rounds a value with more than millisecond precision up to the next millisecond.
        /// The range excludes <c>SubmittedBefore</c>. The value must be at least one millisecond
        /// later than <c>SubmittedAfter</c>, or later than <c>RetentionStartsAt</c> if you omit
        /// <c>SubmittedAfter</c>.</para><para>If the range ends within a few seconds of the current time, a later request for the
        /// same range might return more changes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubmittedBefore { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of changes that you want Route 53 to return in this response. Specify
        /// a value from 1 to 100. If you don't specify a value, Route 53 returns up to 100 changes.</para>
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
        /// <para>If the response to a previous <c>ListResourceRecordSetChanges</c> request included
        /// a <c>NextToken</c> element, specify that value here to get the next page of results.
        /// If the previous request included any of the following parameters, include them with
        /// exactly the same values: <c>SubmittedAfter</c>, <c>SubmittedBefore</c>, <c>SortOrder</c>,
        /// <c>RecordName</c>, and <c>RecordType</c>. If you don't, Route 53 returns an <c>InvalidInput</c>
        /// error. If you don't specify <c>NextToken</c>, Route 53 returns the first page of results.</para><para>A <c>NextToken</c> expires 24 hours after Route 53 returns it, and you can use it
        /// only with the hosted zone that it was returned for.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ResourceRecordSetChanges'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListResourceRecordSetChangesResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListResourceRecordSetChangesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ResourceRecordSetChanges";
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
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListResourceRecordSetChangesResponse, GetR53ResourceRecordSetChangeListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.HostedZoneId = this.HostedZoneId;
            #if MODULAR
            if (this.HostedZoneId == null && ParameterWasBound(nameof(this.HostedZoneId)))
            {
                WriteWarning("You are passing $null as a value for parameter HostedZoneId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecordName = this.RecordName;
            context.RecordType = this.RecordType;
            context.SubmittedAfter = this.SubmittedAfter;
            context.SubmittedBefore = this.SubmittedBefore;
            context.SortOrder = this.SortOrder;
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
            var request = new Amazon.Route53.Model.ListResourceRecordSetChangesRequest();
            
            if (cmdletContext.HostedZoneId != null)
            {
                request.HostedZoneId = cmdletContext.HostedZoneId;
            }
            if (cmdletContext.RecordName != null)
            {
                request.RecordName = cmdletContext.RecordName;
            }
            if (cmdletContext.RecordType != null)
            {
                request.RecordType = cmdletContext.RecordType;
            }
            if (cmdletContext.SubmittedAfter != null)
            {
                request.SubmittedAfter = cmdletContext.SubmittedAfter;
            }
            if (cmdletContext.SubmittedBefore != null)
            {
                request.SubmittedBefore = cmdletContext.SubmittedBefore;
            }
            if (cmdletContext.SortOrder != null)
            {
                request.SortOrder = cmdletContext.SortOrder;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
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
        
        private Amazon.Route53.Model.ListResourceRecordSetChangesResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListResourceRecordSetChangesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListResourceRecordSetChanges");
            try
            {
                return client.ListResourceRecordSetChangesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HostedZoneId { get; set; }
            public System.String RecordName { get; set; }
            public Amazon.Route53.RRType RecordType { get; set; }
            public System.String SubmittedAfter { get; set; }
            public System.String SubmittedBefore { get; set; }
            public Amazon.Route53.ChangeHistorySortOrder SortOrder { get; set; }
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.Route53.Model.ListResourceRecordSetChangesResponse, GetR53ResourceRecordSetChangeListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ResourceRecordSetChanges;
        }
        
    }
}
