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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Sets the attributes of the platform application object for the supported push notification
    /// services, such as APNS and GCM. For more information, see <a href="http://docs.aws.amazon.com/sns/latest/dg/SNSMobilePush.html">Using
    /// Amazon SNS Mobile Push Notifications</a>. For information on configuring attributes
    /// for message delivery status, see <a href="http://docs.aws.amazon.com/sns/latest/dg/sns-msg-status.html">Using
    /// Amazon SNS Application Attributes for Message Delivery Status</a>.
    /// </summary>
    [Cmdlet("Set", "SNSPlatformApplicationAttributes", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetPlatformApplicationAttributes operation against Amazon Simple Notification Service.", Operation = new[] {"SetPlatformApplicationAttributes"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the PlatformApplicationArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetSNSPlatformApplicationAttributesCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>A map of the platform application attributes. Attributes in this map include the following:</para><ul><li><para><code>PlatformCredential</code> -- The credential received from the notification
        /// service. For APNS/APNS_SANDBOX, PlatformCredential is private key. For GCM, PlatformCredential
        /// is "API key". For ADM, PlatformCredential is "client secret".</para></li><li><para><code>PlatformPrincipal</code> -- The principal received from the notification service.
        /// For APNS/APNS_SANDBOX, PlatformPrincipal is SSL certificate. For GCM, PlatformPrincipal
        /// is not applicable. For ADM, PlatformPrincipal is "client id".</para></li><li><para><code>EventEndpointCreated</code> -- Topic ARN to which EndpointCreated event notifications
        /// should be sent.</para></li><li><para><code>EventEndpointDeleted</code> -- Topic ARN to which EndpointDeleted event notifications
        /// should be sent.</para></li><li><para><code>EventEndpointUpdated</code> -- Topic ARN to which EndpointUpdate event notifications
        /// should be sent.</para></li><li><para><code>EventDeliveryFailure</code> -- Topic ARN to which DeliveryFailure event notifications
        /// should be sent upon Direct Publish delivery failure (permanent) to one of the application's
        /// endpoints.</para></li><li><para><code>SuccessFeedbackRoleArn</code> -- IAM role ARN used to give Amazon SNS write
        /// access to use CloudWatch Logs on your behalf.</para></li><li><para><code>FailureFeedbackRoleArn</code> -- IAM role ARN used to give Amazon SNS write
        /// access to use CloudWatch Logs on your behalf.</para></li><li><para><code>SuccessFeedbackSampleRate</code> -- Sample rate percentage (0-100) of successfully
        /// delivered messages.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter PlatformApplicationArn
        /// <summary>
        /// <para>
        /// <para>PlatformApplicationArn for SetPlatformApplicationAttributes action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PlatformApplicationArn { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the PlatformApplicationArn parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("PlatformApplicationArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-SNSPlatformApplicationAttributes (SetPlatformApplicationAttributes)"))
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
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.PlatformApplicationArn = this.PlatformApplicationArn;
            
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
            var request = new Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.PlatformApplicationArn != null)
            {
                request.PlatformApplicationArn = cmdletContext.PlatformApplicationArn;
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
                    pipelineOutput = this.PlatformApplicationArn;
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
        
        private static Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.SetPlatformApplicationAttributesRequest request)
        {
            #if DESKTOP
            return client.SetPlatformApplicationAttributes(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SetPlatformApplicationAttributesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<System.String, System.String> Attributes { get; set; }
            public System.String PlatformApplicationArn { get; set; }
        }
        
    }
}
