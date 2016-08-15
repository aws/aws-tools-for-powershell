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
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;

namespace Amazon.PowerShell.Cmdlets.AS
{
    /// <summary>
    /// Configures an Auto Scaling group to send notifications when specified events take
    /// place. Subscribers to the specified topic can have messages delivered to an endpoint
    /// such as a web server or an email address.
    /// 
    ///  
    /// <para>
    /// This configuration overwrites any existing configuration.
    /// </para><para>
    /// For more information see <a href="http://docs.aws.amazon.com/AutoScaling/latest/DeveloperGuide/ASGettingNotifications.html">Getting
    /// SNS Notifications When Your Auto Scaling Group Scales</a> in the <i>Auto Scaling User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ASNotificationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutNotificationConfiguration operation against Auto Scaling.", Operation = new[] {"PutNotificationConfiguration"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the AutoScalingGroupName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.AutoScaling.Model.PutNotificationConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteASNotificationConfigurationCmdlet : AmazonAutoScalingClientCmdlet, IExecutor
    {
        
        #region Parameter AutoScalingGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the Auto Scaling group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String AutoScalingGroupName { get; set; }
        #endregion
        
        #region Parameter NotificationType
        /// <summary>
        /// <para>
        /// <para>The type of event that will cause the notification to be sent. For details about notification
        /// types supported by Auto Scaling, see <a>DescribeAutoScalingNotificationTypes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("NotificationTypes")]
        public System.String[] NotificationType { get; set; }
        #endregion
        
        #region Parameter TopicARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Simple Notification Service (SNS) topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String TopicARN { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the AutoScalingGroupName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("AutoScalingGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ASNotificationConfiguration (PutNotificationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AutoScalingGroupName = this.AutoScalingGroupName;
            if (this.NotificationType != null)
            {
                context.NotificationTypes = new List<System.String>(this.NotificationType);
            }
            context.TopicARN = this.TopicARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.AutoScaling.Model.PutNotificationConfigurationRequest();
            
            if (cmdletContext.AutoScalingGroupName != null)
            {
                request.AutoScalingGroupName = cmdletContext.AutoScalingGroupName;
            }
            if (cmdletContext.NotificationTypes != null)
            {
                request.NotificationTypes = cmdletContext.NotificationTypes;
            }
            if (cmdletContext.TopicARN != null)
            {
                request.TopicARN = cmdletContext.TopicARN;
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
                    pipelineOutput = this.AutoScalingGroupName;
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
        
        private static Amazon.AutoScaling.Model.PutNotificationConfigurationResponse CallAWSServiceOperation(IAmazonAutoScaling client, Amazon.AutoScaling.Model.PutNotificationConfigurationRequest request)
        {
            return client.PutNotificationConfiguration(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String AutoScalingGroupName { get; set; }
            public List<System.String> NotificationTypes { get; set; }
            public System.String TopicARN { get; set; }
        }
        
    }
}
