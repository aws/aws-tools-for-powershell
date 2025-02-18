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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Updates an existing cost anomaly subscription. Specify the fields that you want to
    /// update. Omitted fields are unchanged.
    /// 
    ///  <note><para>
    /// The JSON below describes the generic construct for each type. See <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_UpdateAnomalySubscription.html#API_UpdateAnomalySubscription_RequestParameters">Request
    /// Parameters</a> for possible values as they apply to <c>AnomalySubscription</c>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "CEAnomalySubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cost Explorer UpdateAnomalySubscription API operation.", Operation = new[] {"UpdateAnomalySubscription"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse))]
    [AWSCmdletOutput("System.String or Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCEAnomalySubscriptionCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Frequency
        /// <summary>
        /// <para>
        /// <para>The update to the frequency value that subscribers receive notifications. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.AnomalySubscriptionFrequency")]
        public Amazon.CostExplorer.AnomalySubscriptionFrequency Frequency { get; set; }
        #endregion
        
        #region Parameter MonitorArnList
        /// <summary>
        /// <para>
        /// <para>A list of cost anomaly monitor ARNs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] MonitorArnList { get; set; }
        #endregion
        
        #region Parameter Subscriber
        /// <summary>
        /// <para>
        /// <para>The update to the subscriber list. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Subscribers")]
        public Amazon.CostExplorer.Model.Subscriber[] Subscriber { get; set; }
        #endregion
        
        #region Parameter SubscriptionArn
        /// <summary>
        /// <para>
        /// <para>A cost anomaly subscription Amazon Resource Name (ARN). </para>
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
        public System.String SubscriptionArn { get; set; }
        #endregion
        
        #region Parameter SubscriptionName
        /// <summary>
        /// <para>
        /// <para>The new name of the subscription. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubscriptionName { get; set; }
        #endregion
        
        #region Parameter ThresholdExpression
        /// <summary>
        /// <para>
        /// <para>The update to the <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Expression.html">Expression</a>
        /// object used to specify the anomalies that you want to generate alerts for. This supports
        /// dimensions and nested expressions. The supported dimensions are <c>ANOMALY_TOTAL_IMPACT_ABSOLUTE</c>
        /// and <c>ANOMALY_TOTAL_IMPACT_PERCENTAGE</c>, corresponding to an anomaly’s TotalImpact
        /// and TotalImpactPercentage, respectively (see <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Impact.html">Impact</a>
        /// for more details). The supported nested expression types are <c>AND</c> and <c>OR</c>.
        /// The match option <c>GREATER_THAN_OR_EQUAL</c> is required. Values must be numbers
        /// between 0 and 10,000,000,000 in string format.</para><para>You can specify either Threshold or ThresholdExpression, but not both.</para><para>The following are examples of valid ThresholdExpressions:</para><ul><li><para>Absolute threshold: <c>{ "Dimensions": { "Key": "ANOMALY_TOTAL_IMPACT_ABSOLUTE", "MatchOptions":
        /// [ "GREATER_THAN_OR_EQUAL" ], "Values": [ "100" ] } }</c></para></li><li><para>Percentage threshold: <c>{ "Dimensions": { "Key": "ANOMALY_TOTAL_IMPACT_PERCENTAGE",
        /// "MatchOptions": [ "GREATER_THAN_OR_EQUAL" ], "Values": [ "100" ] } }</c></para></li><li><para><c>AND</c> two thresholds together: <c>{ "And": [ { "Dimensions": { "Key": "ANOMALY_TOTAL_IMPACT_ABSOLUTE",
        /// "MatchOptions": [ "GREATER_THAN_OR_EQUAL" ], "Values": [ "100" ] } }, { "Dimensions":
        /// { "Key": "ANOMALY_TOTAL_IMPACT_PERCENTAGE", "MatchOptions": [ "GREATER_THAN_OR_EQUAL"
        /// ], "Values": [ "100" ] } } ] }</c></para></li><li><para><c>OR</c> two thresholds together: <c>{ "Or": [ { "Dimensions": { "Key": "ANOMALY_TOTAL_IMPACT_ABSOLUTE",
        /// "MatchOptions": [ "GREATER_THAN_OR_EQUAL" ], "Values": [ "100" ] } }, { "Dimensions":
        /// { "Key": "ANOMALY_TOTAL_IMPACT_PERCENTAGE", "MatchOptions": [ "GREATER_THAN_OR_EQUAL"
        /// ], "Values": [ "100" ] } } ] }</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression ThresholdExpression { get; set; }
        #endregion
        
        #region Parameter Threshold
        /// <summary>
        /// <para>
        /// <para>(deprecated)</para><para>The update to the threshold value for receiving notifications. </para><para>This field has been deprecated. To update a threshold, use ThresholdExpression. Continued
        /// use of Threshold will be treated as shorthand syntax for a ThresholdExpression.</para><para>You can specify either Threshold or ThresholdExpression, but not both.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Threshold has been deprecated in favor of ThresholdExpression")]
        public System.Double? Threshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SubscriptionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SubscriptionArn";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SubscriptionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CEAnomalySubscription (UpdateAnomalySubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse, UpdateCEAnomalySubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Frequency = this.Frequency;
            if (this.MonitorArnList != null)
            {
                context.MonitorArnList = new List<System.String>(this.MonitorArnList);
            }
            if (this.Subscriber != null)
            {
                context.Subscriber = new List<Amazon.CostExplorer.Model.Subscriber>(this.Subscriber);
            }
            context.SubscriptionArn = this.SubscriptionArn;
            #if MODULAR
            if (this.SubscriptionArn == null && ParameterWasBound(nameof(this.SubscriptionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriptionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SubscriptionName = this.SubscriptionName;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Threshold = this.Threshold;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ThresholdExpression = this.ThresholdExpression;
            
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
            var request = new Amazon.CostExplorer.Model.UpdateAnomalySubscriptionRequest();
            
            if (cmdletContext.Frequency != null)
            {
                request.Frequency = cmdletContext.Frequency;
            }
            if (cmdletContext.MonitorArnList != null)
            {
                request.MonitorArnList = cmdletContext.MonitorArnList;
            }
            if (cmdletContext.Subscriber != null)
            {
                request.Subscribers = cmdletContext.Subscriber;
            }
            if (cmdletContext.SubscriptionArn != null)
            {
                request.SubscriptionArn = cmdletContext.SubscriptionArn;
            }
            if (cmdletContext.SubscriptionName != null)
            {
                request.SubscriptionName = cmdletContext.SubscriptionName;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Threshold != null)
            {
                request.Threshold = cmdletContext.Threshold.Value;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ThresholdExpression != null)
            {
                request.ThresholdExpression = cmdletContext.ThresholdExpression;
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
        
        private Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.UpdateAnomalySubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "UpdateAnomalySubscription");
            try
            {
                return client.UpdateAnomalySubscriptionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.CostExplorer.AnomalySubscriptionFrequency Frequency { get; set; }
            public List<System.String> MonitorArnList { get; set; }
            public List<Amazon.CostExplorer.Model.Subscriber> Subscriber { get; set; }
            public System.String SubscriptionArn { get; set; }
            public System.String SubscriptionName { get; set; }
            [System.ObsoleteAttribute]
            public System.Double? Threshold { get; set; }
            public Amazon.CostExplorer.Model.Expression ThresholdExpression { get; set; }
            public System.Func<Amazon.CostExplorer.Model.UpdateAnomalySubscriptionResponse, UpdateCEAnomalySubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SubscriptionArn;
        }
        
    }
}
