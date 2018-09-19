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
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;

namespace Amazon.PowerShell.Cmdlets.SES
{
    /// <summary>
    /// Sets an Amazon Simple Notification Service (Amazon SNS) topic to use when delivering
    /// notifications. When you use this operation, you specify a verified identity, such
    /// as an email address or domain. When you send an email that uses the chosen identity
    /// in the Source field, Amazon SES sends notifications to the topic you specified. You
    /// can send bounce, complaint, or delivery notifications (or any combination of the three)
    /// to the Amazon SNS topic that you specify.
    /// 
    ///  
    /// <para>
    /// You can execute this operation no more than once per second.
    /// </para><para>
    /// For more information about feedback notification, see the <a href="http://docs.aws.amazon.com/ses/latest/DeveloperGuide/notifications.html">Amazon
    /// SES Developer Guide</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "SESIdentityNotificationTopic", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Simple Email Service SetIdentityNotificationTopic API operation.", Operation = new[] {"SetIdentityNotificationTopic"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Identity parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SimpleEmail.Model.SetIdentityNotificationTopicResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetSESIdentityNotificationTopicCmdlet : AmazonSimpleEmailServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Identity
        /// <summary>
        /// <para>
        /// <para>The identity (email address or domain) that you want to set the Amazon SNS topic for.</para><important><para>You can only specify a verified identity for this parameter.</para></important><para>You can specify an identity by using its name or by using its Amazon Resource Name
        /// (ARN). The following examples are all valid identities: <code>sender@example.com</code>,
        /// <code>example.com</code>, <code>arn:aws:ses:us-east-1:123456789012:identity/example.com</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Identity { get; set; }
        #endregion
        
        #region Parameter NotificationType
        /// <summary>
        /// <para>
        /// <para>The type of notifications that will be published to the specified Amazon SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [AWSConstantClassSource("Amazon.SimpleEmail.NotificationType")]
        public Amazon.SimpleEmail.NotificationType NotificationType { get; set; }
        #endregion
        
        #region Parameter SnsTopic
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic. If the parameter is omitted
        /// from the request or a null value is passed, <code>SnsTopic</code> is cleared and publishing
        /// is disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String SnsTopic { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Identity parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Identity", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SESIdentityNotificationTopic (SetIdentityNotificationTopic)"))
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
            
            context.Identity = this.Identity;
            context.NotificationType = this.NotificationType;
            context.SnsTopic = this.SnsTopic;
            
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
            var request = new Amazon.SimpleEmail.Model.SetIdentityNotificationTopicRequest();
            
            if (cmdletContext.Identity != null)
            {
                request.Identity = cmdletContext.Identity;
            }
            if (cmdletContext.NotificationType != null)
            {
                request.NotificationType = cmdletContext.NotificationType;
            }
            if (cmdletContext.SnsTopic != null)
            {
                request.SnsTopic = cmdletContext.SnsTopic;
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
                    pipelineOutput = this.Identity;
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
        
        private Amazon.SimpleEmail.Model.SetIdentityNotificationTopicResponse CallAWSServiceOperation(IAmazonSimpleEmailService client, Amazon.SimpleEmail.Model.SetIdentityNotificationTopicRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Email Service", "SetIdentityNotificationTopic");
            try
            {
                #if DESKTOP
                return client.SetIdentityNotificationTopic(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SetIdentityNotificationTopicAsync(request);
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
            public System.String Identity { get; set; }
            public Amazon.SimpleEmail.NotificationType NotificationType { get; set; }
            public System.String SnsTopic { get; set; }
        }
        
    }
}
