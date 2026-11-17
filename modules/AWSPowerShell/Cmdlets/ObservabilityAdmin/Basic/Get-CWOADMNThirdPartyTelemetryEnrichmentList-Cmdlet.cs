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
    /// Returns a summary of each third-party telemetry enrichment in your account and Region.
    /// To get the full configuration of an enrichment, use <c>GetThirdPartyTelemetryEnrichment</c>.
    /// The results are paginated. To get the next page of results, use <c>NextToken</c>.<br/><br/>This cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CWOADMNThirdPartyTelemetryEnrichmentList")]
    [OutputType("Amazon.ObservabilityAdmin.Model.ThirdPartyTelemetryEnrichmentSummary")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service ListThirdPartyTelemetryEnrichments API operation.", Operation = new[] {"ListThirdPartyTelemetryEnrichments"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.ThirdPartyTelemetryEnrichmentSummary or Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsResponse",
        "This cmdlet returns a collection of Amazon.ObservabilityAdmin.Model.ThirdPartyTelemetryEnrichmentSummary objects.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWOADMNThirdPartyTelemetryEnrichmentListCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Returns only the enrichments that have this status. Valid values:</para><ul><li><para><c>Initializing</c> - CloudWatch is setting up the enrichment. Some telemetry can
        /// be enriched before setup completes.</para></li><li><para><c>Running</c> - The enrichment is active.</para></li><li><para><c>Stopped</c> - The enrichment is stopped.</para></li><li><para><c>Impaired</c> - The enrichment has a problem. <c>StatusReason</c> describes the
        /// problem.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.ThirdPartyTelemetryEnrichmentStatus")]
        public Amazon.ObservabilityAdmin.ThirdPartyTelemetryEnrichmentStatus Status { get; set; }
        #endregion
        
        #region Parameter TelemetrySource
        /// <summary>
        /// <para>
        /// <para>Returns only the enrichments for this third-party telemetry source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ObservabilityAdmin.ThirdPartyTelemetrySource")]
        public Amazon.ObservabilityAdmin.ThirdPartyTelemetrySource TelemetrySource { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in a single call. If you omit this parameter,
        /// the operation returns up to 100 results.</para>
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
        /// <para>The token for the next set of results. A previous call generates this token. If you
        /// omit this parameter, the operation returns the first page of results.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TelemetryEnrichments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TelemetryEnrichments";
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
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsResponse, GetCWOADMNThirdPartyTelemetryEnrichmentListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
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
            context.Status = this.Status;
            context.TelemetrySource = this.TelemetrySource;
            
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
            var request = new Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsRequest();
            
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.MaxResult.Value);
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.TelemetrySource != null)
            {
                request.TelemetrySource = cmdletContext.TelemetrySource;
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
        
        private Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "ListThirdPartyTelemetryEnrichments");
            try
            {
                return client.ListThirdPartyTelemetryEnrichmentsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public int? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.ObservabilityAdmin.ThirdPartyTelemetryEnrichmentStatus Status { get; set; }
            public Amazon.ObservabilityAdmin.ThirdPartyTelemetrySource TelemetrySource { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.ListThirdPartyTelemetryEnrichmentsResponse, GetCWOADMNThirdPartyTelemetryEnrichmentListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TelemetryEnrichments;
        }
        
    }
}
