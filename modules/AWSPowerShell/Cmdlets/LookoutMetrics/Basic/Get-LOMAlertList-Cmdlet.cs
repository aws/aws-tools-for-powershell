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
using Amazon.LookoutMetrics;
using Amazon.LookoutMetrics.Model;

namespace Amazon.PowerShell.Cmdlets.LOM
{
    /// <summary>
    /// Lists the alerts attached to a detector.
    /// 
    ///  
    /// <para>
    /// Amazon Lookout for Metrics API actions are eventually consistent. If you do a read
    /// operation on a resource immediately after creating or modifying it, use retries to
    /// allow time for the write operation to complete.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "LOMAlertList")]
    [OutputType("Amazon.LookoutMetrics.Model.AlertSummary")]
    [AWSCmdlet("Calls the Amazon Lookout for Metrics ListAlerts API operation.", Operation = new[] {"ListAlerts"}, SelectReturnType = typeof(Amazon.LookoutMetrics.Model.ListAlertsResponse))]
    [AWSCmdletOutput("Amazon.LookoutMetrics.Model.AlertSummary or Amazon.LookoutMetrics.Model.ListAlertsResponse",
        "This cmdlet returns a collection of Amazon.LookoutMetrics.Model.AlertSummary objects.",
        "The service call response (type Amazon.LookoutMetrics.Model.ListAlertsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLOMAlertListCmdlet : AmazonLookoutMetricsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnomalyDetectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the alert's detector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AnomalyDetectorArn { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results that will be displayed by the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the result of the previous request is truncated, the response includes a <c>NextToken</c>.
        /// To retrieve the next set of results, use the token in the next request. Tokens expire
        /// after 24 hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AlertSummaryList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutMetrics.Model.ListAlertsResponse).
        /// Specifying the name of a property of type Amazon.LookoutMetrics.Model.ListAlertsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AlertSummaryList";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AnomalyDetectorArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AnomalyDetectorArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AnomalyDetectorArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.LookoutMetrics.Model.ListAlertsResponse, GetLOMAlertListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AnomalyDetectorArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnomalyDetectorArn = this.AnomalyDetectorArn;
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
            // create request
            var request = new Amazon.LookoutMetrics.Model.ListAlertsRequest();
            
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
        
        private Amazon.LookoutMetrics.Model.ListAlertsResponse CallAWSServiceOperation(IAmazonLookoutMetrics client, Amazon.LookoutMetrics.Model.ListAlertsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Metrics", "ListAlerts");
            try
            {
                #if DESKTOP
                return client.ListAlerts(request);
                #elif CORECLR
                return client.ListAlertsAsync(request).GetAwaiter().GetResult();
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
            public System.String AnomalyDetectorArn { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.LookoutMetrics.Model.ListAlertsResponse, GetLOMAlertListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AlertSummaryList;
        }
        
    }
}
