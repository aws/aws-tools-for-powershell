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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Adds an alert subscription to a cost anomaly detection monitor. You can use each subscription
    /// to define subscribers with email or SNS notifications. Email subscribers can set an
    /// absolute or percentage threshold and a time frequency for receiving notifications.
    /// </summary>
    [Cmdlet("New", "CEAnomalySubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Cost Explorer CreateAnomalySubscription API operation.", Operation = new[] {"CreateAnomalySubscription"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.CreateAnomalySubscriptionResponse))]
    [AWSCmdletOutput("System.String or Amazon.CostExplorer.Model.CreateAnomalySubscriptionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CostExplorer.Model.CreateAnomalySubscriptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCEAnomalySubscriptionCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AnomalySubscription_AccountId
        /// <summary>
        /// <para>
        /// <para>Your unique account identifier. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalySubscription_AccountId { get; set; }
        #endregion
        
        #region Parameter AnomalySubscription_Frequency
        /// <summary>
        /// <para>
        /// <para>The frequency that anomaly notifications are sent. Notifications are sent either over
        /// email (for DAILY and WEEKLY frequencies) or SNS (for IMMEDIATE frequency). For more
        /// information, see <a href="https://docs.aws.amazon.com/cost-management/latest/userguide/ad-SNS.html">Creating
        /// an Amazon SNS topic for anomaly notifications</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CostExplorer.AnomalySubscriptionFrequency")]
        public Amazon.CostExplorer.AnomalySubscriptionFrequency AnomalySubscription_Frequency { get; set; }
        #endregion
        
        #region Parameter AnomalySubscription_MonitorArnList
        /// <summary>
        /// <para>
        /// <para>A list of cost anomaly monitors. </para>
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
        public System.String[] AnomalySubscription_MonitorArnList { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para>An optional list of tags to associate with the specified <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_AnomalySubscription.html"><c>AnomalySubscription</c></a>. You can use resource tags to control access to your
        /// <c>subscription</c> using IAM policies.</para><para>Each tag consists of a key and a value, and each key must be unique for the resource.
        /// The following restrictions apply to resource tags:</para><ul><li><para>Although the maximum number of array members is 200, you can assign a maximum of 50
        /// user-tags to one resource. The remaining are reserved for Amazon Web Services use</para></li><li><para>The maximum length of a key is 128 characters</para></li><li><para>The maximum length of a value is 256 characters</para></li><li><para>Keys and values can only contain alphanumeric characters, spaces, and any of the following:
        /// <c>_.:/=+@-</c></para></li><li><para>Keys and values are case sensitive</para></li><li><para>Keys and values are trimmed for any leading or trailing whitespaces</para></li><li><para>Don’t use <c>aws:</c> as a prefix for your keys. This prefix is reserved for Amazon
        /// Web Services use</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.CostExplorer.Model.ResourceTag[] ResourceTag { get; set; }
        #endregion
        
        #region Parameter AnomalySubscription_Subscriber
        /// <summary>
        /// <para>
        /// <para>A list of subscribers to notify. </para>
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
        [Alias("AnomalySubscription_Subscribers")]
        public Amazon.CostExplorer.Model.Subscriber[] AnomalySubscription_Subscriber { get; set; }
        #endregion
        
        #region Parameter AnomalySubscription_SubscriptionArn
        /// <summary>
        /// <para>
        /// <para>The <c>AnomalySubscription</c> Amazon Resource Name (ARN). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnomalySubscription_SubscriptionArn { get; set; }
        #endregion
        
        #region Parameter AnomalySubscription_SubscriptionName
        /// <summary>
        /// <para>
        /// <para>The name for the subscription. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String AnomalySubscription_SubscriptionName { get; set; }
        #endregion
        
        #region Parameter AnomalySubscription_ThresholdExpression
        /// <summary>
        /// <para>
        /// <para>An <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Expression.html">Expression</a>
        /// object used to specify the anomalies that you want to generate alerts for. This supports
        /// dimensions and nested expressions. The supported dimensions are <c>ANOMALY_TOTAL_IMPACT_ABSOLUTE</c>
        /// and <c>ANOMALY_TOTAL_IMPACT_PERCENTAGE</c>, corresponding to an anomaly’s TotalImpact
        /// and TotalImpactPercentage, respectively (see <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Impact.html">Impact</a>
        /// for more details). The supported nested expression types are <c>AND</c> and <c>OR</c>.
        /// The match option <c>GREATER_THAN_OR_EQUAL</c> is required. Values must be numbers
        /// between 0 and 10,000,000,000 in string format.</para><para>One of Threshold or ThresholdExpression is required for this resource. You cannot
        /// specify both.</para><para>The following are examples of valid ThresholdExpressions:</para><ul><li><para>Absolute threshold: <c>{ "Dimensions": { "Key": "ANOMALY_TOTAL_IMPACT_ABSOLUTE", "MatchOptions":
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
        public Amazon.CostExplorer.Model.Expression AnomalySubscription_ThresholdExpression { get; set; }
        #endregion
        
        #region Parameter AnomalySubscription_Threshold
        /// <summary>
        /// <para>
        /// <para>(deprecated)</para><para>An absolute dollar value that must be exceeded by the anomaly's total impact (see
        /// <a href="https://docs.aws.amazon.com/aws-cost-management/latest/APIReference/API_Impact.html">Impact</a>
        /// for more details) for an anomaly notification to be generated.</para><para>This field has been deprecated. To specify a threshold, use ThresholdExpression. Continued
        /// use of Threshold will be treated as shorthand syntax for a ThresholdExpression.</para><para>One of Threshold or ThresholdExpression is required for this resource. You cannot
        /// specify both.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Threshold has been deprecated in favor of ThresholdExpression")]
        public System.Double? AnomalySubscription_Threshold { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SubscriptionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.CreateAnomalySubscriptionResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.CreateAnomalySubscriptionResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AnomalySubscription_SubscriptionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CEAnomalySubscription (CreateAnomalySubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.CreateAnomalySubscriptionResponse, NewCEAnomalySubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AnomalySubscription_AccountId = this.AnomalySubscription_AccountId;
            context.AnomalySubscription_Frequency = this.AnomalySubscription_Frequency;
            #if MODULAR
            if (this.AnomalySubscription_Frequency == null && ParameterWasBound(nameof(this.AnomalySubscription_Frequency)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalySubscription_Frequency which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AnomalySubscription_MonitorArnList != null)
            {
                context.AnomalySubscription_MonitorArnList = new List<System.String>(this.AnomalySubscription_MonitorArnList);
            }
            #if MODULAR
            if (this.AnomalySubscription_MonitorArnList == null && ParameterWasBound(nameof(this.AnomalySubscription_MonitorArnList)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalySubscription_MonitorArnList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AnomalySubscription_Subscriber != null)
            {
                context.AnomalySubscription_Subscriber = new List<Amazon.CostExplorer.Model.Subscriber>(this.AnomalySubscription_Subscriber);
            }
            #if MODULAR
            if (this.AnomalySubscription_Subscriber == null && ParameterWasBound(nameof(this.AnomalySubscription_Subscriber)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalySubscription_Subscriber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AnomalySubscription_SubscriptionArn = this.AnomalySubscription_SubscriptionArn;
            context.AnomalySubscription_SubscriptionName = this.AnomalySubscription_SubscriptionName;
            #if MODULAR
            if (this.AnomalySubscription_SubscriptionName == null && ParameterWasBound(nameof(this.AnomalySubscription_SubscriptionName)))
            {
                WriteWarning("You are passing $null as a value for parameter AnomalySubscription_SubscriptionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnomalySubscription_Threshold = this.AnomalySubscription_Threshold;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnomalySubscription_ThresholdExpression = this.AnomalySubscription_ThresholdExpression;
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.CostExplorer.Model.ResourceTag>(this.ResourceTag);
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
            var request = new Amazon.CostExplorer.Model.CreateAnomalySubscriptionRequest();
            
            
             // populate AnomalySubscription
            var requestAnomalySubscriptionIsNull = true;
            request.AnomalySubscription = new Amazon.CostExplorer.Model.AnomalySubscription();
            System.String requestAnomalySubscription_anomalySubscription_AccountId = null;
            if (cmdletContext.AnomalySubscription_AccountId != null)
            {
                requestAnomalySubscription_anomalySubscription_AccountId = cmdletContext.AnomalySubscription_AccountId;
            }
            if (requestAnomalySubscription_anomalySubscription_AccountId != null)
            {
                request.AnomalySubscription.AccountId = requestAnomalySubscription_anomalySubscription_AccountId;
                requestAnomalySubscriptionIsNull = false;
            }
            Amazon.CostExplorer.AnomalySubscriptionFrequency requestAnomalySubscription_anomalySubscription_Frequency = null;
            if (cmdletContext.AnomalySubscription_Frequency != null)
            {
                requestAnomalySubscription_anomalySubscription_Frequency = cmdletContext.AnomalySubscription_Frequency;
            }
            if (requestAnomalySubscription_anomalySubscription_Frequency != null)
            {
                request.AnomalySubscription.Frequency = requestAnomalySubscription_anomalySubscription_Frequency;
                requestAnomalySubscriptionIsNull = false;
            }
            List<System.String> requestAnomalySubscription_anomalySubscription_MonitorArnList = null;
            if (cmdletContext.AnomalySubscription_MonitorArnList != null)
            {
                requestAnomalySubscription_anomalySubscription_MonitorArnList = cmdletContext.AnomalySubscription_MonitorArnList;
            }
            if (requestAnomalySubscription_anomalySubscription_MonitorArnList != null)
            {
                request.AnomalySubscription.MonitorArnList = requestAnomalySubscription_anomalySubscription_MonitorArnList;
                requestAnomalySubscriptionIsNull = false;
            }
            List<Amazon.CostExplorer.Model.Subscriber> requestAnomalySubscription_anomalySubscription_Subscriber = null;
            if (cmdletContext.AnomalySubscription_Subscriber != null)
            {
                requestAnomalySubscription_anomalySubscription_Subscriber = cmdletContext.AnomalySubscription_Subscriber;
            }
            if (requestAnomalySubscription_anomalySubscription_Subscriber != null)
            {
                request.AnomalySubscription.Subscribers = requestAnomalySubscription_anomalySubscription_Subscriber;
                requestAnomalySubscriptionIsNull = false;
            }
            System.String requestAnomalySubscription_anomalySubscription_SubscriptionArn = null;
            if (cmdletContext.AnomalySubscription_SubscriptionArn != null)
            {
                requestAnomalySubscription_anomalySubscription_SubscriptionArn = cmdletContext.AnomalySubscription_SubscriptionArn;
            }
            if (requestAnomalySubscription_anomalySubscription_SubscriptionArn != null)
            {
                request.AnomalySubscription.SubscriptionArn = requestAnomalySubscription_anomalySubscription_SubscriptionArn;
                requestAnomalySubscriptionIsNull = false;
            }
            System.String requestAnomalySubscription_anomalySubscription_SubscriptionName = null;
            if (cmdletContext.AnomalySubscription_SubscriptionName != null)
            {
                requestAnomalySubscription_anomalySubscription_SubscriptionName = cmdletContext.AnomalySubscription_SubscriptionName;
            }
            if (requestAnomalySubscription_anomalySubscription_SubscriptionName != null)
            {
                request.AnomalySubscription.SubscriptionName = requestAnomalySubscription_anomalySubscription_SubscriptionName;
                requestAnomalySubscriptionIsNull = false;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            System.Double? requestAnomalySubscription_anomalySubscription_Threshold = null;
            if (cmdletContext.AnomalySubscription_Threshold != null)
            {
                requestAnomalySubscription_anomalySubscription_Threshold = cmdletContext.AnomalySubscription_Threshold.Value;
            }
            if (requestAnomalySubscription_anomalySubscription_Threshold != null)
            {
                request.AnomalySubscription.Threshold = requestAnomalySubscription_anomalySubscription_Threshold.Value;
                requestAnomalySubscriptionIsNull = false;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            Amazon.CostExplorer.Model.Expression requestAnomalySubscription_anomalySubscription_ThresholdExpression = null;
            if (cmdletContext.AnomalySubscription_ThresholdExpression != null)
            {
                requestAnomalySubscription_anomalySubscription_ThresholdExpression = cmdletContext.AnomalySubscription_ThresholdExpression;
            }
            if (requestAnomalySubscription_anomalySubscription_ThresholdExpression != null)
            {
                request.AnomalySubscription.ThresholdExpression = requestAnomalySubscription_anomalySubscription_ThresholdExpression;
                requestAnomalySubscriptionIsNull = false;
            }
             // determine if request.AnomalySubscription should be set to null
            if (requestAnomalySubscriptionIsNull)
            {
                request.AnomalySubscription = null;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
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
        
        private Amazon.CostExplorer.Model.CreateAnomalySubscriptionResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.CreateAnomalySubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "CreateAnomalySubscription");
            try
            {
                #if DESKTOP
                return client.CreateAnomalySubscription(request);
                #elif CORECLR
                return client.CreateAnomalySubscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.String AnomalySubscription_AccountId { get; set; }
            public Amazon.CostExplorer.AnomalySubscriptionFrequency AnomalySubscription_Frequency { get; set; }
            public List<System.String> AnomalySubscription_MonitorArnList { get; set; }
            public List<Amazon.CostExplorer.Model.Subscriber> AnomalySubscription_Subscriber { get; set; }
            public System.String AnomalySubscription_SubscriptionArn { get; set; }
            public System.String AnomalySubscription_SubscriptionName { get; set; }
            [System.ObsoleteAttribute]
            public System.Double? AnomalySubscription_Threshold { get; set; }
            public Amazon.CostExplorer.Model.Expression AnomalySubscription_ThresholdExpression { get; set; }
            public List<Amazon.CostExplorer.Model.ResourceTag> ResourceTag { get; set; }
            public System.Func<Amazon.CostExplorer.Model.CreateAnomalySubscriptionResponse, NewCEAnomalySubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SubscriptionArn;
        }
        
    }
}
