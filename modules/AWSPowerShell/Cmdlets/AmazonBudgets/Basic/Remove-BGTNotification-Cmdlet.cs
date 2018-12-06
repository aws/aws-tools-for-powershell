/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Deletes a notification.
    /// 
    ///  <important><para>
    /// Deleting a notification also deletes the subscribers that are associated with the
    /// notification.
    /// </para></important>
    /// </summary>
    [Cmdlet("Remove", "BGTNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Budgets DeleteNotification API operation.", Operation = new[] {"DeleteNotification"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BudgetName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Budgets.Model.DeleteNotificationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveBGTNotificationCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <code>accountId</code> that is associated with the budget whose notification you
        /// want to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetName
        /// <summary>
        /// <para>
        /// <para>The name of the budget whose notification you want to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BudgetName { get; set; }
        #endregion
        
        #region Parameter Notification_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The comparison that is used for this notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.ComparisonOperator")]
        public Amazon.Budgets.ComparisonOperator Notification_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter Notification_NotificationState
        /// <summary>
        /// <para>
        /// <para>Whether this notification is in alarm. If a budget notification is in the <code>ALARM</code>
        /// state, you have passed the set threshold for the budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationState")]
        public Amazon.Budgets.NotificationState Notification_NotificationState { get; set; }
        #endregion
        
        #region Parameter Notification_NotificationType
        /// <summary>
        /// <para>
        /// <para>Whether the notification is for how much you have spent (<code>ACTUAL</code>) or for
        /// how much you're forecasted to spend (<code>FORECASTED</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationType")]
        public Amazon.Budgets.NotificationType Notification_NotificationType { get; set; }
        #endregion
        
        #region Parameter Notification_Threshold
        /// <summary>
        /// <para>
        /// <para>The threshold that is associated with a notification. Thresholds are always a percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double Notification_Threshold { get; set; }
        #endregion
        
        #region Parameter Notification_ThresholdType
        /// <summary>
        /// <para>
        /// <para>The type of threshold for a notification. For <code>ABSOLUTE_VALUE</code> thresholds,
        /// AWS notifies you when you go over or are forecasted to go over your total cost threshold.
        /// For <code>PERCENTAGE</code> thresholds, AWS notifies you when you go over or are forecasted
        /// to go over a certain percentage of your forecasted spend. For example, if you have
        /// a budget for 200 dollars and you have a <code>PERCENTAGE</code> threshold of 80%,
        /// AWS notifies you when you go over 160 dollars.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.ThresholdType")]
        public Amazon.Budgets.ThresholdType Notification_ThresholdType { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the BudgetName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BudgetName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-BGTNotification (DeleteNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AccountId = this.AccountId;
            context.BudgetName = this.BudgetName;
            context.Notification_ComparisonOperator = this.Notification_ComparisonOperator;
            context.Notification_NotificationState = this.Notification_NotificationState;
            context.Notification_NotificationType = this.Notification_NotificationType;
            if (ParameterWasBound("Notification_Threshold"))
                context.Notification_Threshold = this.Notification_Threshold;
            context.Notification_ThresholdType = this.Notification_ThresholdType;
            
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
            var request = new Amazon.Budgets.Model.DeleteNotificationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            
             // populate Notification
            bool requestNotificationIsNull = true;
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.BudgetName;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.Budgets.Model.DeleteNotificationResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.DeleteNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "DeleteNotification");
            try
            {
                #if DESKTOP
                return client.DeleteNotification(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteNotificationAsync(request);
                return task.Result;
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
        }
        
    }
}
