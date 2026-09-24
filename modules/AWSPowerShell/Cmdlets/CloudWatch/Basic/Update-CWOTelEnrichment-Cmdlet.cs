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
using Amazon.CloudWatch;
using Amazon.CloudWatch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CW
{
    /// <summary>
    /// Replaces the filters that determine which CloudWatch vended metrics are enriched with
    /// resource ARN and resource tag labels for the account. Enrichment must already be running
    /// for the account. If it is not, this operation returns a <c>ResourceNotFoundException</c>.
    /// To start enrichment, use <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/APIReference/API_StartOTelEnrichment.html">StartOTelEnrichment</a>.
    /// 
    ///  
    /// <para>
    /// The filters in the request completely replace the stored filters; they are not merged
    /// with them. <c>IncludeFilters</c> and <c>ExcludeFilters</c> are replaced as a pair,
    /// so a request that specifies only <c>IncludeFilters</c> also clears the stored <c>ExcludeFilters</c>,
    /// and a request that specifies neither clears both.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWOTelEnrichment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch UpdateOTelEnrichment API operation.", Operation = new[] {"UpdateOTelEnrichment"}, SelectReturnType = typeof(Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse))]
    [AWSCmdletOutput("Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse",
        "This cmdlet returns an Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse object containing multiple properties."
    )]
    public partial class UpdateCWOTelEnrichmentCmdlet : AmazonCloudWatchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExcludeFilter
        /// <summary>
        /// <para>
        /// <para>The metric namespaces, and the metric names, to leave unenriched. If this parameter
        /// is omitted, nothing is excluded.</para><para>Amazon CloudWatch applies <c>ExcludeFilters</c> after <c>IncludeFilters</c>, so a
        /// metric that both parameters match is not enriched.</para><para>A maximum of 100 filters is allowed across <c>IncludeFilters</c> and <c>ExcludeFilters</c>
        /// combined.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExcludeFilters")]
        public Amazon.CloudWatch.Model.OTelEnrichmentMetricSelector[] ExcludeFilter { get; set; }
        #endregion
        
        #region Parameter IncludeFilter
        /// <summary>
        /// <para>
        /// <para>The metric namespaces, and the metric names, to enrich. If this parameter is omitted,
        /// every namespace that Amazon CloudWatch supports for enrichment is in scope.</para><para>A maximum of 100 filters is allowed across <c>IncludeFilters</c> and <c>ExcludeFilters</c>
        /// combined.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeFilters")]
        public Amazon.CloudWatch.Model.OTelEnrichmentMetricSelector[] IncludeFilter { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse).
        /// Specifying the name of a property of type Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWOTelEnrichment (UpdateOTelEnrichment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse, UpdateCWOTelEnrichmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ExcludeFilter != null)
            {
                context.ExcludeFilter = new List<Amazon.CloudWatch.Model.OTelEnrichmentMetricSelector>(this.ExcludeFilter);
            }
            if (this.IncludeFilter != null)
            {
                context.IncludeFilter = new List<Amazon.CloudWatch.Model.OTelEnrichmentMetricSelector>(this.IncludeFilter);
            }
            
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
            var request = new Amazon.CloudWatch.Model.UpdateOTelEnrichmentRequest();
            
            if (cmdletContext.ExcludeFilter != null)
            {
                request.ExcludeFilters = cmdletContext.ExcludeFilter;
            }
            if (cmdletContext.IncludeFilter != null)
            {
                request.IncludeFilters = cmdletContext.IncludeFilter;
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
        
        private Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse CallAWSServiceOperation(IAmazonCloudWatch client, Amazon.CloudWatch.Model.UpdateOTelEnrichmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch", "UpdateOTelEnrichment");
            try
            {
                return client.UpdateOTelEnrichmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatch.Model.OTelEnrichmentMetricSelector> ExcludeFilter { get; set; }
            public List<Amazon.CloudWatch.Model.OTelEnrichmentMetricSelector> IncludeFilter { get; set; }
            public System.Func<Amazon.CloudWatch.Model.UpdateOTelEnrichmentResponse, UpdateCWOTelEnrichmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
