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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Returns a list of anomaly groups.
    /// </summary>
    [Cmdlet("Get", "LOMAnomalyGroupSummaryList")]
    [OutputType("Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics ListAnomalyGroupSummaries API operation.", Operation = new[] {"ListAnomalyGroupSummaries"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse))]
    [AWSCmdletOutput("Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse",
        "This cmdlet returns an Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse object containing multiple properties."
    )]
    public partial class GetLOMAnomalyGroupSummaryListCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the anomaly detector.</para>
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
        public System.String AnomalyDetectorArn { get; set; }
        #endregion
        
        #region Parameter SensitivityThreshold
        /// <summary>
        /// <para>
        /// <para>The minimum severity score for inclusion in the output.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SensitivityThreshold { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>Specify the pagination token that's returned by a previous request to retrieve the
        /// next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse, GetLOMAnomalyGroupSummaryListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
            #if MODULAR
            if (this.AnomalyDetectorArn == null && ParameterWasBound(nameof(this.AnomalyDetectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalyDetectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.SensitivityThreshold = this.SensitivityThreshold;
            #if MODULAR
            if (this.SensitivityThreshold == null && ParameterWasBound(nameof(this.SensitivityThreshold)))
            {
                WriteWarning("You are passing $null as a value for parameter SensitivityThreshold which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            // create request
            var request = new Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesRequest();
            
            if (cmdletContext.AnomalyDetectorArn != null)
            {
                request.AnomalyDetectorArn = cmdletContext.AnomalyDetectorArn;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.SensitivityThreshold != null)
            {
                request.SensitivityThreshold = cmdletContext.SensitivityThreshold.Value;
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
        
        private Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "ListAnomalyGroupSummaries");
            try
            {
                return client.ListAnomalyGroupSummariesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AnomalyDetectorArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Int32? SensitivityThreshold { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.ListAnomalyGroupSummariesResponse, GetLOMAnomalyGroupSummaryListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
