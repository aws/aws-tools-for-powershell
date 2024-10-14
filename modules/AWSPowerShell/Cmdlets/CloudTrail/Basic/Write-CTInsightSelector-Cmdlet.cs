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
using Amazon.CloudTrail;
using Amazon.CloudTrail.Model;

namespace Amazon.PowerShell.Cmdlets.CT
{
    /// <summary>
    /// Lets you enable Insights event logging by specifying the Insights selectors that you
    /// want to enable on an existing trail or event data store. You also use <c>PutInsightSelectors</c>
    /// to turn off Insights event logging, by passing an empty list of Insights types. The
    /// valid Insights event types are <c>ApiErrorRateInsight</c> and <c>ApiCallRateInsight</c>.
    /// 
    ///  
    /// <para>
    /// To enable Insights on an event data store, you must specify the ARNs (or ID suffix
    /// of the ARNs) for the source event data store (<c>EventDataStore</c>) and the destination
    /// event data store (<c>InsightsDestination</c>). The source event data store logs management
    /// events and enables Insights. The destination event data store logs Insights events
    /// based upon the management event activity of the source event data store. The source
    /// and destination event data stores must belong to the same Amazon Web Services account.
    /// </para><para>
    /// To log Insights events for a trail, you must specify the name (<c>TrailName</c>) of
    /// the CloudTrail trail for which you want to change or add Insights selectors.
    /// </para><para>
    /// To log CloudTrail Insights events on API call volume, the trail or event data store
    /// must log <c>write</c> management events. To log CloudTrail Insights events on API
    /// error rate, the trail or event data store must log <c>read</c> or <c>write</c> management
    /// events. You can call <c>GetEventSelectors</c> on a trail to check whether the trail
    /// logs management events. You can call <c>GetEventDataStore</c> on an event data store
    /// to check whether the event data store logs management events.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/logging-insights-events-with-cloudtrail.html">Logging
    /// CloudTrail Insights events</a> in the <i>CloudTrail User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CTInsightSelector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrail.Model.PutInsightSelectorsResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail PutInsightSelectors API operation.", Operation = new[] {"PutInsightSelectors"}, SelectReturnType = typeof(Amazon.CloudTrail.Model.PutInsightSelectorsResponse))]
    [AWSCmdletOutput("Amazon.CloudTrail.Model.PutInsightSelectorsResponse",
        "This cmdlet returns an Amazon.CloudTrail.Model.PutInsightSelectorsResponse object containing multiple properties."
    )]
    public partial class WriteCTInsightSelectorCmdlet : AmazonCloudTrailClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventDataStore
        /// <summary>
        /// <para>
        /// <para>The ARN (or ID suffix of the ARN) of the source event data store for which you want
        /// to change or add Insights selectors. To enable Insights on an event data store, you
        /// must provide both the <c>EventDataStore</c> and <c>InsightsDestination</c> parameters.</para><para>You cannot use this parameter with the <c>TrailName</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventDataStore { get; set; }
        #endregion
        
        #region Parameter InsightsDestination
        /// <summary>
        /// <para>
        /// <para> The ARN (or ID suffix of the ARN) of the destination event data store that logs Insights
        /// events. To enable Insights on an event data store, you must provide both the <c>EventDataStore</c>
        /// and <c>InsightsDestination</c> parameters. </para><para>You cannot use this parameter with the <c>TrailName</c> parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InsightsDestination { get; set; }
        #endregion
        
        #region Parameter InsightSelector
        /// <summary>
        /// <para>
        /// <para>A JSON string that contains the Insights types you want to log on a trail or event
        /// data store. <c>ApiCallRateInsight</c> and <c>ApiErrorRateInsight</c> are valid Insight
        /// types.</para><para>The <c>ApiCallRateInsight</c> Insights type analyzes write-only management API calls
        /// that are aggregated per minute against a baseline API call volume.</para><para>The <c>ApiErrorRateInsight</c> Insights type analyzes management API calls that result
        /// in error codes. The error is shown if the API call is unsuccessful.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("InsightSelectors")]
        public Amazon.CloudTrail.Model.InsightSelector[] InsightSelector { get; set; }
        #endregion
        
        #region Parameter TrailName
        /// <summary>
        /// <para>
        /// <para>The name of the CloudTrail trail for which you want to change or add Insights selectors.</para><para>You cannot use this parameter with the <c>EventDataStore</c> and <c>InsightsDestination</c>
        /// parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TrailName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrail.Model.PutInsightSelectorsResponse).
        /// Specifying the name of a property of type Amazon.CloudTrail.Model.PutInsightSelectorsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TrailName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TrailName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TrailName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrailName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CTInsightSelector (PutInsightSelectors)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrail.Model.PutInsightSelectorsResponse, WriteCTInsightSelectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TrailName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EventDataStore = this.EventDataStore;
            context.InsightsDestination = this.InsightsDestination;
            if (this.InsightSelector != null)
            {
                context.InsightSelector = new List<Amazon.CloudTrail.Model.InsightSelector>(this.InsightSelector);
            }
            #if MODULAR
            if (this.InsightSelector == null && ParameterWasBound(nameof(this.InsightSelector)))
            {
                WriteWarning("You are passing $null as a value for parameter InsightSelector which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrailName = this.TrailName;
            
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
            var request = new Amazon.CloudTrail.Model.PutInsightSelectorsRequest();
            
            if (cmdletContext.EventDataStore != null)
            {
                request.EventDataStore = cmdletContext.EventDataStore;
            }
            if (cmdletContext.InsightsDestination != null)
            {
                request.InsightsDestination = cmdletContext.InsightsDestination;
            }
            if (cmdletContext.InsightSelector != null)
            {
                request.InsightSelectors = cmdletContext.InsightSelector;
            }
            if (cmdletContext.TrailName != null)
            {
                request.TrailName = cmdletContext.TrailName;
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
        
        private Amazon.CloudTrail.Model.PutInsightSelectorsResponse CallAWSServiceOperation(IAmazonCloudTrail client, Amazon.CloudTrail.Model.PutInsightSelectorsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail", "PutInsightSelectors");
            try
            {
                #if DESKTOP
                return client.PutInsightSelectors(request);
                #elif CORECLR
                return client.PutInsightSelectorsAsync(request).GetAwaiter().GetResult();
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
            public System.String EventDataStore { get; set; }
            public System.String InsightsDestination { get; set; }
            public List<Amazon.CloudTrail.Model.InsightSelector> InsightSelector { get; set; }
            public System.String TrailName { get; set; }
            public System.Func<Amazon.CloudTrail.Model.PutInsightSelectorsResponse, WriteCTInsightSelectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
