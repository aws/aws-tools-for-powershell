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
using Amazon.Budgets;
using Amazon.Budgets.Model;

namespace Amazon.PowerShell.Cmdlets.BGT
{
    /// <summary>
    /// Creates a notification. You must create the budget before you create the associated
    /// notification.
    /// </summary>
    [Cmdlet("New", "BGTNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Budgets CreateNotification API operation.", Operation = new[] {"CreateNotification"}, SelectReturnType = typeof(Amazon.Budgets.Model.CreateNotificationResponse))]
    [AWSCmdletOutput("None or Amazon.Budgets.Model.CreateNotificationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Budgets.Model.CreateNotificationResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewBGTNotificationCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <c>accountId</c> that is associated with the budget that you want to create a
        /// notification for.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetName
        /// <summary>
        /// <para>
        /// <para>The name of the budget that you want Amazon Web Services to notify you about. Budget
        /// names must be unique within an account.</para>
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
        public System.String BudgetName { get; set; }
        #endregion
        
        #region Parameter Notification_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The comparison that's used for this notification.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Budgets.ComparisonOperator")]
        public Amazon.Budgets.ComparisonOperator Notification_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter Notification_NotificationState
        /// <summary>
        /// <para>
        /// <para>Specifies whether this notification is in alarm. If a budget notification is in the
        /// <c>ALARM</c> state, you passed the set threshold for the budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Budgets.NotificationState")]
        public Amazon.Budgets.NotificationState Notification_NotificationState { get; set; }
        #endregion
        
        #region Parameter Notification_NotificationType
        /// <summary>
        /// <para>
        /// <para>Specifies whether the notification is for how much you have spent (<c>ACTUAL</c>)
        /// or for how much that you're forecasted to spend (<c>FORECASTED</c>).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationType")]
        public Amazon.Budgets.NotificationType Notification_NotificationType { get; set; }
        #endregion
        
        #region Parameter Subscriber
        /// <summary>
        /// <para>
        /// <para>A list of subscribers that you want to associate with the notification. Each notification
        /// can have one SNS subscriber and up to 10 email subscribers.</para>
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
        [Alias("Subscribers")]
        public Amazon.Budgets.Model.Subscriber[] Subscriber { get; set; }
        #endregion
        
        #region Parameter Notification_Threshold
        /// <summary>
        /// <para>
        /// <para>The threshold that's associated with a notification. Thresholds are always a percentage,
        /// and many customers find value being alerted between 50% - 200% of the budgeted amount.
        /// The maximum limit for your threshold is 1,000,000% above the budgeted amount.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? Notification_Threshold { get; set; }
        #endregion
        
        #region Parameter Notification_ThresholdType
        /// <summary>
        /// <para>
        /// <para>The type of threshold for a notification. For <c>ABSOLUTE_VALUE</c> thresholds, Amazon
        /// Web Services notifies you when you go over or are forecasted to go over your total
        /// cost threshold. For <c>PERCENTAGE</c> thresholds, Amazon Web Services notifies you
        /// when you go over or are forecasted to go over a certain percentage of your forecasted
        /// spend. For example, if you have a budget for 200 dollars and you have a <c>PERCENTAGE</c>
        /// threshold of 80%, Amazon Web Services notifies you when you go over 160 dollars.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Budgets.ThresholdType")]
        public Amazon.Budgets.ThresholdType Notification_ThresholdType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Budgets.Model.CreateNotificationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BudgetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BGTNotification (CreateNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Budgets.Model.CreateNotificationResponse, NewBGTNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BudgetName = this.BudgetName;
            #if MODULAR
            if (this.BudgetName == null && ParameterWasBound(nameof(this.BudgetName)))
            {
                WriteWarning("You are passing $null as a value for parameter BudgetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Notification_ComparisonOperator = this.Notification_ComparisonOperator;
            #if MODULAR
            if (this.Notification_ComparisonOperator == null && ParameterWasBound(nameof(this.Notification_ComparisonOperator)))
            {
                WriteWarning("You are passing $null as a value for parameter Notification_ComparisonOperator which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Notification_NotificationState = this.Notification_NotificationState;
            context.Notification_NotificationType = this.Notification_NotificationType;
            #if MODULAR
            if (this.Notification_NotificationType == null && ParameterWasBound(nameof(this.Notification_NotificationType)))
            {
                WriteWarning("You are passing $null as a value for parameter Notification_NotificationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Notification_Threshold = this.Notification_Threshold;
            #if MODULAR
            if (this.Notification_Threshold == null && ParameterWasBound(nameof(this.Notification_Threshold)))
            {
                WriteWarning("You are passing $null as a value for parameter Notification_Threshold which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Notification_ThresholdType = this.Notification_ThresholdType;
            if (this.Subscriber != null)
            {
                context.Subscriber = new List<Amazon.Budgets.Model.Subscriber>(this.Subscriber);
            }
            #if MODULAR
            if (this.Subscriber == null && ParameterWasBound(nameof(this.Subscriber)))
            {
                WriteWarning("You are passing $null as a value for parameter Subscriber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Budgets.Model.CreateNotificationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            
             // populate Notification
            var requestNotificationIsNull = true;
            request.Notification = new Amazon.Budgets.Model.Notification();
            Amazon.Budgets.ComparisonOperator requestNotification_notification_ComparisonOperator = null;
            if (cmdletContext.Notification_ComparisonOperator != null)
            {
                requestNotification_notification_ComparisonOperator = cmdletContext.Notification_ComparisonOperator;
            }
            if (requestNotification_notification_ComparisonOperator != null)
            {
                request.Notification.ComparisonOperator = requestNotification_notification_ComparisonOperator;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationState requestNotification_notification_NotificationState = null;
            if (cmdletContext.Notification_NotificationState != null)
            {
                requestNotification_notification_NotificationState = cmdletContext.Notification_NotificationState;
            }
            if (requestNotification_notification_NotificationState != null)
            {
                request.Notification.NotificationState = requestNotification_notification_NotificationState;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationType requestNotification_notification_NotificationType = null;
            if (cmdletContext.Notification_NotificationType != null)
            {
                requestNotification_notification_NotificationType = cmdletContext.Notification_NotificationType;
            }
            if (requestNotification_notification_NotificationType != null)
            {
                request.Notification.NotificationType = requestNotification_notification_NotificationType;
                requestNotificationIsNull = false;
            }
            System.Double? requestNotification_notification_Threshold = null;
            if (cmdletContext.Notification_Threshold != null)
            {
                requestNotification_notification_Threshold = cmdletContext.Notification_Threshold.Value;
            }
            if (requestNotification_notification_Threshold != null)
            {
                request.Notification.Threshold = requestNotification_notification_Threshold.Value;
                requestNotificationIsNull = false;
            }
            Amazon.Budgets.ThresholdType requestNotification_notification_ThresholdType = null;
            if (cmdletContext.Notification_ThresholdType != null)
            {
                requestNotification_notification_ThresholdType = cmdletContext.Notification_ThresholdType;
            }
            if (requestNotification_notification_ThresholdType != null)
            {
                request.Notification.ThresholdType = requestNotification_notification_ThresholdType;
                requestNotificationIsNull = false;
            }
             // determine if request.Notification should be set to null
            if (requestNotificationIsNull)
            {
                request.Notification = null;
            }
            if (cmdletContext.Subscriber != null)
            {
                request.Subscribers = cmdletContext.Subscriber;
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
        
        private Amazon.Budgets.Model.CreateNotificationResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.CreateNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "CreateNotification");
            try
            {
                #if DESKTOP
                return client.CreateNotification(request);
                #elif CORECLR
                return client.CreateNotificationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String BudgetName { get; set; }
            public Amazon.Budgets.ComparisonOperator Notification_ComparisonOperator { get; set; }
            public Amazon.Budgets.NotificationState Notification_NotificationState { get; set; }
            public Amazon.Budgets.NotificationType Notification_NotificationType { get; set; }
            public System.Double? Notification_Threshold { get; set; }
            public Amazon.Budgets.ThresholdType Notification_ThresholdType { get; set; }
            public List<Amazon.Budgets.Model.Subscriber> Subscriber { get; set; }
            public System.Func<Amazon.Budgets.Model.CreateNotificationResponse, NewBGTNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
