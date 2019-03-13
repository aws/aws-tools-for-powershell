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
    /// Updates a notification.
    /// </summary>
    [Cmdlet("Update", "BGTNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Budgets UpdateNotification API operation.", Operation = new[] {"UpdateNotification"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BudgetName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Budgets.Model.UpdateNotificationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBGTNotificationCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The <code>accountId</code> that is associated with the budget whose notification you
        /// want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter BudgetName
        /// <summary>
        /// <para>
        /// <para>The name of the budget whose notification you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BudgetName { get; set; }
        #endregion
        
        #region Parameter NewNotification_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The comparison that is used for this notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.ComparisonOperator")]
        public Amazon.Budgets.ComparisonOperator NewNotification_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter OldNotification_ComparisonOperator
        /// <summary>
        /// <para>
        /// <para>The comparison that is used for this notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.ComparisonOperator")]
        public Amazon.Budgets.ComparisonOperator OldNotification_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter NewNotification_NotificationState
        /// <summary>
        /// <para>
        /// <para>Whether this notification is in alarm. If a budget notification is in the <code>ALARM</code>
        /// state, you have passed the set threshold for the budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationState")]
        public Amazon.Budgets.NotificationState NewNotification_NotificationState { get; set; }
        #endregion
        
        #region Parameter OldNotification_NotificationState
        /// <summary>
        /// <para>
        /// <para>Whether this notification is in alarm. If a budget notification is in the <code>ALARM</code>
        /// state, you have passed the set threshold for the budget.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationState")]
        public Amazon.Budgets.NotificationState OldNotification_NotificationState { get; set; }
        #endregion
        
        #region Parameter NewNotification_NotificationType
        /// <summary>
        /// <para>
        /// <para>Whether the notification is for how much you have spent (<code>ACTUAL</code>) or for
        /// how much you're forecasted to spend (<code>FORECASTED</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationType")]
        public Amazon.Budgets.NotificationType NewNotification_NotificationType { get; set; }
        #endregion
        
        #region Parameter OldNotification_NotificationType
        /// <summary>
        /// <para>
        /// <para>Whether the notification is for how much you have spent (<code>ACTUAL</code>) or for
        /// how much you're forecasted to spend (<code>FORECASTED</code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationType")]
        public Amazon.Budgets.NotificationType OldNotification_NotificationType { get; set; }
        #endregion
        
        #region Parameter NewNotification_Threshold
        /// <summary>
        /// <para>
        /// <para>The threshold that is associated with a notification. Thresholds are always a percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double NewNotification_Threshold { get; set; }
        #endregion
        
        #region Parameter OldNotification_Threshold
        /// <summary>
        /// <para>
        /// <para>The threshold that is associated with a notification. Thresholds are always a percentage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double OldNotification_Threshold { get; set; }
        #endregion
        
        #region Parameter NewNotification_ThresholdType
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
        public Amazon.Budgets.ThresholdType NewNotification_ThresholdType { get; set; }
        #endregion
        
        #region Parameter OldNotification_ThresholdType
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
        public Amazon.Budgets.ThresholdType OldNotification_ThresholdType { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BGTNotification (UpdateNotification)"))
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
            context.NewNotification_ComparisonOperator = this.NewNotification_ComparisonOperator;
            context.NewNotification_NotificationState = this.NewNotification_NotificationState;
            context.NewNotification_NotificationType = this.NewNotification_NotificationType;
            if (ParameterWasBound("NewNotification_Threshold"))
                context.NewNotification_Threshold = this.NewNotification_Threshold;
            context.NewNotification_ThresholdType = this.NewNotification_ThresholdType;
            context.OldNotification_ComparisonOperator = this.OldNotification_ComparisonOperator;
            context.OldNotification_NotificationState = this.OldNotification_NotificationState;
            context.OldNotification_NotificationType = this.OldNotification_NotificationType;
            if (ParameterWasBound("OldNotification_Threshold"))
                context.OldNotification_Threshold = this.OldNotification_Threshold;
            context.OldNotification_ThresholdType = this.OldNotification_ThresholdType;
            
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
            var request = new Amazon.Budgets.Model.UpdateNotificationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            
             // populate NewNotification
            bool requestNewNotificationIsNull = true;
            request.NewNotification = new Amazon.Budgets.Model.Notification();
            Amazon.Budgets.ComparisonOperator requestNewNotification_newNotification_ComparisonOperator = null;
            if (cmdletContext.NewNotification_ComparisonOperator != null)
            {
                requestNewNotification_newNotification_ComparisonOperator = cmdletContext.NewNotification_ComparisonOperator;
            }
            if (requestNewNotification_newNotification_ComparisonOperator != null)
            {
                request.NewNotification.ComparisonOperator = requestNewNotification_newNotification_ComparisonOperator;
                requestNewNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationState requestNewNotification_newNotification_NotificationState = null;
            if (cmdletContext.NewNotification_NotificationState != null)
            {
                requestNewNotification_newNotification_NotificationState = cmdletContext.NewNotification_NotificationState;
            }
            if (requestNewNotification_newNotification_NotificationState != null)
            {
                request.NewNotification.NotificationState = requestNewNotification_newNotification_NotificationState;
                requestNewNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationType requestNewNotification_newNotification_NotificationType = null;
            if (cmdletContext.NewNotification_NotificationType != null)
            {
                requestNewNotification_newNotification_NotificationType = cmdletContext.NewNotification_NotificationType;
            }
            if (requestNewNotification_newNotification_NotificationType != null)
            {
                request.NewNotification.NotificationType = requestNewNotification_newNotification_NotificationType;
                requestNewNotificationIsNull = false;
            }
            System.Double? requestNewNotification_newNotification_Threshold = null;
            if (cmdletContext.NewNotification_Threshold != null)
            {
                requestNewNotification_newNotification_Threshold = cmdletContext.NewNotification_Threshold.Value;
            }
            if (requestNewNotification_newNotification_Threshold != null)
            {
                request.NewNotification.Threshold = requestNewNotification_newNotification_Threshold.Value;
                requestNewNotificationIsNull = false;
            }
            Amazon.Budgets.ThresholdType requestNewNotification_newNotification_ThresholdType = null;
            if (cmdletContext.NewNotification_ThresholdType != null)
            {
                requestNewNotification_newNotification_ThresholdType = cmdletContext.NewNotification_ThresholdType;
            }
            if (requestNewNotification_newNotification_ThresholdType != null)
            {
                request.NewNotification.ThresholdType = requestNewNotification_newNotification_ThresholdType;
                requestNewNotificationIsNull = false;
            }
             // determine if request.NewNotification should be set to null
            if (requestNewNotificationIsNull)
            {
                request.NewNotification = null;
            }
            
             // populate OldNotification
            bool requestOldNotificationIsNull = true;
            request.OldNotification = new Amazon.Budgets.Model.Notification();
            Amazon.Budgets.ComparisonOperator requestOldNotification_oldNotification_ComparisonOperator = null;
            if (cmdletContext.OldNotification_ComparisonOperator != null)
            {
                requestOldNotification_oldNotification_ComparisonOperator = cmdletContext.OldNotification_ComparisonOperator;
            }
            if (requestOldNotification_oldNotification_ComparisonOperator != null)
            {
                request.OldNotification.ComparisonOperator = requestOldNotification_oldNotification_ComparisonOperator;
                requestOldNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationState requestOldNotification_oldNotification_NotificationState = null;
            if (cmdletContext.OldNotification_NotificationState != null)
            {
                requestOldNotification_oldNotification_NotificationState = cmdletContext.OldNotification_NotificationState;
            }
            if (requestOldNotification_oldNotification_NotificationState != null)
            {
                request.OldNotification.NotificationState = requestOldNotification_oldNotification_NotificationState;
                requestOldNotificationIsNull = false;
            }
            Amazon.Budgets.NotificationType requestOldNotification_oldNotification_NotificationType = null;
            if (cmdletContext.OldNotification_NotificationType != null)
            {
                requestOldNotification_oldNotification_NotificationType = cmdletContext.OldNotification_NotificationType;
            }
            if (requestOldNotification_oldNotification_NotificationType != null)
            {
                request.OldNotification.NotificationType = requestOldNotification_oldNotification_NotificationType;
                requestOldNotificationIsNull = false;
            }
            System.Double? requestOldNotification_oldNotification_Threshold = null;
            if (cmdletContext.OldNotification_Threshold != null)
            {
                requestOldNotification_oldNotification_Threshold = cmdletContext.OldNotification_Threshold.Value;
            }
            if (requestOldNotification_oldNotification_Threshold != null)
            {
                request.OldNotification.Threshold = requestOldNotification_oldNotification_Threshold.Value;
                requestOldNotificationIsNull = false;
            }
            Amazon.Budgets.ThresholdType requestOldNotification_oldNotification_ThresholdType = null;
            if (cmdletContext.OldNotification_ThresholdType != null)
            {
                requestOldNotification_oldNotification_ThresholdType = cmdletContext.OldNotification_ThresholdType;
            }
            if (requestOldNotification_oldNotification_ThresholdType != null)
            {
                request.OldNotification.ThresholdType = requestOldNotification_oldNotification_ThresholdType;
                requestOldNotificationIsNull = false;
            }
             // determine if request.OldNotification should be set to null
            if (requestOldNotificationIsNull)
            {
                request.OldNotification = null;
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
        
        private Amazon.Budgets.Model.UpdateNotificationResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.UpdateNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "UpdateNotification");
            try
            {
                #if DESKTOP
                return client.UpdateNotification(request);
                #elif CORECLR
                return client.UpdateNotificationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Budgets.ComparisonOperator NewNotification_ComparisonOperator { get; set; }
            public Amazon.Budgets.NotificationState NewNotification_NotificationState { get; set; }
            public Amazon.Budgets.NotificationType NewNotification_NotificationType { get; set; }
            public System.Double? NewNotification_Threshold { get; set; }
            public Amazon.Budgets.ThresholdType NewNotification_ThresholdType { get; set; }
            public Amazon.Budgets.ComparisonOperator OldNotification_ComparisonOperator { get; set; }
            public Amazon.Budgets.NotificationState OldNotification_NotificationState { get; set; }
            public Amazon.Budgets.NotificationType OldNotification_NotificationType { get; set; }
            public System.Double? OldNotification_Threshold { get; set; }
            public Amazon.Budgets.ThresholdType OldNotification_ThresholdType { get; set; }
        }
        
    }
}
