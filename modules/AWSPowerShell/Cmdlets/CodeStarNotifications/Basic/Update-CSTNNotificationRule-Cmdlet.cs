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
using Amazon.CodeStarNotifications;
using Amazon.CodeStarNotifications.Model;

namespace Amazon.PowerShell.Cmdlets.CSTN
{
    /// <summary>
    /// Updates a notification rule for a resource. You can change the events that trigger
    /// the notification rule, the status of the rule, and the targets that receive the notifications.
    /// 
    ///  <note><para>
    /// To add or remove tags for a notification rule, you must use <a>TagResource</a> and
    /// <a>UntagResource</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "CSTNNotificationRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS CodeStar Notifications UpdateNotificationRule API operation.", Operation = new[] {"UpdateNotificationRule"}, SelectReturnType = typeof(Amazon.CodeStarNotifications.Model.UpdateNotificationRuleResponse))]
    [AWSCmdletOutput("None or Amazon.CodeStarNotifications.Model.UpdateNotificationRuleResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CodeStarNotifications.Model.UpdateNotificationRuleResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCSTNNotificationRuleCmdlet : AmazonCodeStarNotificationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the notification rule.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter DetailType
        /// <summary>
        /// <para>
        /// <para>The level of detail to include in the notifications for this resource. BASIC will
        /// include only the contents of the event as it would appear in Amazon CloudWatch. FULL
        /// will include any supplemental information provided by AWS CodeStar Notifications and/or
        /// the service for the resource for which the notification is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeStarNotifications.DetailType")]
        public Amazon.CodeStarNotifications.DetailType DetailType { get; set; }
        #endregion
        
        #region Parameter EventTypeId
        /// <summary>
        /// <para>
        /// <para>A list of event types associated with this notification rule. For a complete list
        /// of event types and IDs, see <a href="https://docs.aws.amazon.com/codestar-notifications/latest/userguide/concepts.html#concepts-api">Notification
        /// concepts</a> in the <i>Developer Tools Console User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventTypeIds")]
        public System.String[] EventTypeId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the notification rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the notification rule. Valid statuses include enabled (sending notifications)
        /// or disabled (not sending notifications).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeStarNotifications.NotificationRuleStatus")]
        public Amazon.CodeStarNotifications.NotificationRuleStatus Status { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The address and type of the targets to receive notifications from this notification
        /// rule.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Targets")]
        public Amazon.CodeStarNotifications.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeStarNotifications.Model.UpdateNotificationRuleResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CSTNNotificationRule (UpdateNotificationRule)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeStarNotifications.Model.UpdateNotificationRuleResponse, UpdateCSTNNotificationRuleCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DetailType = this.DetailType;
            if (this.EventTypeId != null)
            {
                context.EventTypeId = new List<System.String>(this.EventTypeId);
            }
            context.Name = this.Name;
            context.Status = this.Status;
            if (this.Target != null)
            {
                context.Target = new List<Amazon.CodeStarNotifications.Model.Target>(this.Target);
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
            var request = new Amazon.CodeStarNotifications.Model.UpdateNotificationRuleRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.DetailType != null)
            {
                request.DetailType = cmdletContext.DetailType;
            }
            if (cmdletContext.EventTypeId != null)
            {
                request.EventTypeIds = cmdletContext.EventTypeId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Target != null)
            {
                request.Targets = cmdletContext.Target;
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
        
        private Amazon.CodeStarNotifications.Model.UpdateNotificationRuleResponse CallAWSServiceOperation(IAmazonCodeStarNotifications client, Amazon.CodeStarNotifications.Model.UpdateNotificationRuleRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeStar Notifications", "UpdateNotificationRule");
            try
            {
                return client.UpdateNotificationRuleAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public Amazon.CodeStarNotifications.DetailType DetailType { get; set; }
            public List<System.String> EventTypeId { get; set; }
            public System.String Name { get; set; }
            public Amazon.CodeStarNotifications.NotificationRuleStatus Status { get; set; }
            public List<Amazon.CodeStarNotifications.Model.Target> Target { get; set; }
            public System.Func<Amazon.CodeStarNotifications.Model.UpdateNotificationRuleResponse, UpdateCSTNNotificationRuleCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
