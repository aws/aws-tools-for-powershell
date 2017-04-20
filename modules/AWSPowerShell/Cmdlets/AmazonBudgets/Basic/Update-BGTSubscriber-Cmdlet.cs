/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Update a subscriber
    /// </summary>
    [Cmdlet("Update", "BGTSubscriber", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateSubscriber operation against AWS Budgets.", Operation = new[] {"UpdateSubscriber"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the BudgetName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Budgets.Model.UpdateSubscriberResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateBGTSubscriberCmdlet : AmazonBudgetsClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter NewSubscriber_Address
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewSubscriber_Address { get; set; }
        #endregion
        
        #region Parameter OldSubscriber_Address
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OldSubscriber_Address { get; set; }
        #endregion
        
        #region Parameter BudgetName
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BudgetName { get; set; }
        #endregion
        
        #region Parameter Notification_ComparisonOperator
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.ComparisonOperator")]
        public Amazon.Budgets.ComparisonOperator Notification_ComparisonOperator { get; set; }
        #endregion
        
        #region Parameter Notification_NotificationType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.NotificationType")]
        public Amazon.Budgets.NotificationType Notification_NotificationType { get; set; }
        #endregion
        
        #region Parameter NewSubscriber_SubscriptionType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.SubscriptionType")]
        public Amazon.Budgets.SubscriptionType NewSubscriber_SubscriptionType { get; set; }
        #endregion
        
        #region Parameter OldSubscriber_SubscriptionType
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.Budgets.SubscriptionType")]
        public Amazon.Budgets.SubscriptionType OldSubscriber_SubscriptionType { get; set; }
        #endregion
        
        #region Parameter Notification_Threshold
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Double Notification_Threshold { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BGTSubscriber (UpdateSubscriber)"))
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
            context.NewSubscriber_Address = this.NewSubscriber_Address;
            context.NewSubscriber_SubscriptionType = this.NewSubscriber_SubscriptionType;
            context.Notification_ComparisonOperator = this.Notification_ComparisonOperator;
            context.Notification_NotificationType = this.Notification_NotificationType;
            if (ParameterWasBound("Notification_Threshold"))
                context.Notification_Threshold = this.Notification_Threshold;
            context.OldSubscriber_Address = this.OldSubscriber_Address;
            context.OldSubscriber_SubscriptionType = this.OldSubscriber_SubscriptionType;
            
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
            var request = new Amazon.Budgets.Model.UpdateSubscriberRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.BudgetName != null)
            {
                request.BudgetName = cmdletContext.BudgetName;
            }
            
             // populate NewSubscriber
            bool requestNewSubscriberIsNull = true;
            request.NewSubscriber = new Amazon.Budgets.Model.Subscriber();
            System.String requestNewSubscriber_newSubscriber_Address = null;
            if (cmdletContext.NewSubscriber_Address != null)
            {
                requestNewSubscriber_newSubscriber_Address = cmdletContext.NewSubscriber_Address;
            }
            if (requestNewSubscriber_newSubscriber_Address != null)
            {
                request.NewSubscriber.Address = requestNewSubscriber_newSubscriber_Address;
                requestNewSubscriberIsNull = false;
            }
            Amazon.Budgets.SubscriptionType requestNewSubscriber_newSubscriber_SubscriptionType = null;
            if (cmdletContext.NewSubscriber_SubscriptionType != null)
            {
                requestNewSubscriber_newSubscriber_SubscriptionType = cmdletContext.NewSubscriber_SubscriptionType;
            }
            if (requestNewSubscriber_newSubscriber_SubscriptionType != null)
            {
                request.NewSubscriber.SubscriptionType = requestNewSubscriber_newSubscriber_SubscriptionType;
                requestNewSubscriberIsNull = false;
            }
             // determine if request.NewSubscriber should be set to null
            if (requestNewSubscriberIsNull)
            {
                request.NewSubscriber = null;
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
             // determine if request.Notification should be set to null
            if (requestNotificationIsNull)
            {
                request.Notification = null;
            }
            
             // populate OldSubscriber
            bool requestOldSubscriberIsNull = true;
            request.OldSubscriber = new Amazon.Budgets.Model.Subscriber();
            System.String requestOldSubscriber_oldSubscriber_Address = null;
            if (cmdletContext.OldSubscriber_Address != null)
            {
                requestOldSubscriber_oldSubscriber_Address = cmdletContext.OldSubscriber_Address;
            }
            if (requestOldSubscriber_oldSubscriber_Address != null)
            {
                request.OldSubscriber.Address = requestOldSubscriber_oldSubscriber_Address;
                requestOldSubscriberIsNull = false;
            }
            Amazon.Budgets.SubscriptionType requestOldSubscriber_oldSubscriber_SubscriptionType = null;
            if (cmdletContext.OldSubscriber_SubscriptionType != null)
            {
                requestOldSubscriber_oldSubscriber_SubscriptionType = cmdletContext.OldSubscriber_SubscriptionType;
            }
            if (requestOldSubscriber_oldSubscriber_SubscriptionType != null)
            {
                request.OldSubscriber.SubscriptionType = requestOldSubscriber_oldSubscriber_SubscriptionType;
                requestOldSubscriberIsNull = false;
            }
             // determine if request.OldSubscriber should be set to null
            if (requestOldSubscriberIsNull)
            {
                request.OldSubscriber = null;
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
        
        private Amazon.Budgets.Model.UpdateSubscriberResponse CallAWSServiceOperation(IAmazonBudgets client, Amazon.Budgets.Model.UpdateSubscriberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Budgets", "UpdateSubscriber");
            #if DESKTOP
            return client.UpdateSubscriber(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateSubscriberAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AccountId { get; set; }
            public System.String BudgetName { get; set; }
            public System.String NewSubscriber_Address { get; set; }
            public Amazon.Budgets.SubscriptionType NewSubscriber_SubscriptionType { get; set; }
            public Amazon.Budgets.ComparisonOperator Notification_ComparisonOperator { get; set; }
            public Amazon.Budgets.NotificationType Notification_NotificationType { get; set; }
            public System.Double? Notification_Threshold { get; set; }
            public System.String OldSubscriber_Address { get; set; }
            public Amazon.Budgets.SubscriptionType OldSubscriber_SubscriptionType { get; set; }
        }
        
    }
}
