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
using Amazon.KinesisAnalyticsV2;
using Amazon.KinesisAnalyticsV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KINA2
{
    /// <summary>
    /// Lists the enhanced snapshots in your account. Snapshots are not scoped to an application.
    /// To list the snapshots that were created from a specific application, use the <c>SourceApplicationName</c>
    /// parameter.
    /// 
    ///  
    /// <para>
    /// You can specify only one of the following filters in a request: <c>SourceApplicationName</c>,
    /// <c>SnapshotInitiator</c>, <c>SnapshotInitiatorOperation</c>, or <c>SnapshotStatus</c>.
    /// If you specify more than one filter, <c>InvalidArgumentException</c> is returned.
    /// </para><para>
    /// The results are sorted in descending order of snapshot creation timestamp. To get
    /// detailed information about a specific snapshot, use <c>DescribeSnapshot</c>.
    /// </para><br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "KINA2SnapshotList")]
    [OutputType("Amazon.KinesisAnalyticsV2.Model.SnapshotInfo")]
    [AWSCmdlet("Calls the Amazon Kinesis Analytics V2 ListSnapshots API operation.", Operation = new[] {"ListSnapshots"}, SelectReturnType = typeof(Amazon.KinesisAnalyticsV2.Model.ListSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.KinesisAnalyticsV2.Model.SnapshotInfo or Amazon.KinesisAnalyticsV2.Model.ListSnapshotsResponse",
        "This cmdlet returns a collection of Amazon.KinesisAnalyticsV2.Model.SnapshotInfo objects.",
        "The service call response (type Amazon.KinesisAnalyticsV2.Model.ListSnapshotsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKINA2SnapshotListCmdlet : AmazonKinesisAnalyticsV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SnapshotInitiator
        /// <summary>
        /// <para>
        /// <para>Use this parameter to list only the snapshots with the specified initiator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.SnapshotInitiator")]
        public Amazon.KinesisAnalyticsV2.SnapshotInitiator SnapshotInitiator { get; set; }
        #endregion
        
        #region Parameter SnapshotInitiatorOperation
        /// <summary>
        /// <para>
        /// <para>Use this parameter to list only the snapshots that were created by the specified operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.SnapshotInitiatorOperation")]
        public Amazon.KinesisAnalyticsV2.SnapshotInitiatorOperation SnapshotInitiatorOperation { get; set; }
        #endregion
        
        #region Parameter SnapshotStatus
        /// <summary>
        /// <para>
        /// <para>Use this parameter to list only the snapshots with the specified status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisAnalyticsV2.SnapshotStatus")]
        public Amazon.KinesisAnalyticsV2.SnapshotStatus SnapshotStatus { get; set; }
        #endregion
        
        #region Parameter SourceApplicationName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceApplicationName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of snapshots to list.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In AWSPowerShell and AWSPowerShell.NetCore this parameter is used to limit the total number of items returned by the cmdlet.
        /// <br/>In AWS.Tools this parameter is simply passed to the service to specify how many items should be returned by each service call.
        /// <br/>Pipe the output of this cmdlet into Select-Object -First to terminate retrieving data pages early and control the number of items returned.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public int? Limit { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SnapshotInfoList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisAnalyticsV2.Model.ListSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.KinesisAnalyticsV2.Model.ListSnapshotsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SnapshotInfoList";
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
                context.Select = CreateSelectDelegate<Amazon.KinesisAnalyticsV2.Model.ListSnapshotsResponse, GetKINA2SnapshotListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Limit = this.Limit;
            #if !MODULAR
            if (ParameterWasBound(nameof(this.Limit)) && this.Limit.HasValue)
            {
                WriteWarning("AWSPowerShell and AWSPowerShell.NetCore use the Limit parameter to limit the total number of items returned by the cmdlet." +
                    " This behavior is obsolete and will be removed in a future version of these modules. Pipe the output of this cmdlet into Select-Object -First to terminate" +
                    " retrieving data pages early and control the number of items returned. AWS.Tools already implements the new behavior of simply passing Limit" +
                    " to the service to specify how many items should be returned by each service call.");
            }
            #endif
            context.NextToken = this.NextToken;
            context.SnapshotInitiator = this.SnapshotInitiator;
            context.SnapshotInitiatorOperation = this.SnapshotInitiatorOperation;
            context.SnapshotStatus = this.SnapshotStatus;
            context.SourceApplicationName = this.SourceApplicationName;
            
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
            var request = new Amazon.KinesisAnalyticsV2.Model.ListSnapshotsRequest();
            
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.SnapshotInitiator != null)
            {
                request.SnapshotInitiator = cmdletContext.SnapshotInitiator;
            }
            if (cmdletContext.SnapshotInitiatorOperation != null)
            {
                request.SnapshotInitiatorOperation = cmdletContext.SnapshotInitiatorOperation;
            }
            if (cmdletContext.SnapshotStatus != null)
            {
                request.SnapshotStatus = cmdletContext.SnapshotStatus;
            }
            if (cmdletContext.SourceApplicationName != null)
            {
                request.SourceApplicationName = cmdletContext.SourceApplicationName;
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
        
        private Amazon.KinesisAnalyticsV2.Model.ListSnapshotsResponse CallAWSServiceOperation(IAmazonKinesisAnalyticsV2 client, Amazon.KinesisAnalyticsV2.Model.ListSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Analytics V2", "ListSnapshots");
            try
            {
                return client.ListSnapshotsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int? Limit { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.KinesisAnalyticsV2.SnapshotInitiator SnapshotInitiator { get; set; }
            public Amazon.KinesisAnalyticsV2.SnapshotInitiatorOperation SnapshotInitiatorOperation { get; set; }
            public Amazon.KinesisAnalyticsV2.SnapshotStatus SnapshotStatus { get; set; }
            public System.String SourceApplicationName { get; set; }
            public System.Func<Amazon.KinesisAnalyticsV2.Model.ListSnapshotsResponse, GetKINA2SnapshotListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SnapshotInfoList;
        }
        
    }
}
