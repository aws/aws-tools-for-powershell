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
using Amazon.PinpointEmail;
using Amazon.PinpointEmail.Model;

namespace Amazon.PowerShell.Cmdlets.PINE
{
    /// <summary>
    /// Used to enable or disable feedback forwarding for an identity. This setting determines
    /// what happens when an identity is used to send an email that results in a bounce or
    /// complaint event.
    /// 
    ///  
    /// <para>
    /// When you enable feedback forwarding, Amazon Pinpoint sends you email notifications
    /// when bounce or complaint events occur. Amazon Pinpoint sends this notification to
    /// the address that you specified in the Return-Path header of the original email.
    /// </para><para>
    /// When you disable feedback forwarding, Amazon Pinpoint sends notifications through
    /// other mechanisms, such as by notifying an Amazon SNS topic. You're required to have
    /// a method of tracking bounces and complaints. If you haven't set up another mechanism
    /// for receiving bounce or complaint notifications, Amazon Pinpoint sends an email notification
    /// when these events occur (even if this setting is disabled).
    /// </para>
    /// </summary>
    [Cmdlet("Write", "PINEEmailIdentityFeedbackAttribute", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Pinpoint Email PutEmailIdentityFeedbackAttributes API operation.", Operation = new[] {"PutEmailIdentityFeedbackAttributes"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the EmailIdentity parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.PinpointEmail.Model.PutEmailIdentityFeedbackAttributesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WritePINEEmailIdentityFeedbackAttributeCmdlet : AmazonPinpointEmailClientCmdlet, IExecutor
    {
        
        #region Parameter EmailForwardingEnabled
        /// <summary>
        /// <para>
        /// <para>Sets the feedback forwarding configuration for the identity.</para><para>If the value is <code>true</code>, Amazon Pinpoint sends you email notifications when
        /// bounce or complaint events occur. Amazon Pinpoint sends this notification to the address
        /// that you specified in the Return-Path header of the original email.</para><para>When you set this value to <code>false</code>, Amazon Pinpoint sends notifications
        /// through other mechanisms, such as by notifying an Amazon SNS topic or another event
        /// destination. You're required to have a method of tracking bounces and complaints.
        /// If you haven't set up another mechanism for receiving bounce or complaint notifications,
        /// Amazon Pinpoint sends an email notification when these events occur (even if this
        /// setting is disabled).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EmailForwardingEnabled { get; set; }
        #endregion
        
        #region Parameter EmailIdentity
        /// <summary>
        /// <para>
        /// <para>The email identity that you want to configure bounce and complaint feedback forwarding
        /// for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String EmailIdentity { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the EmailIdentity parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("EmailIdentity", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-PINEEmailIdentityFeedbackAttribute (PutEmailIdentityFeedbackAttributes)"))
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
            
            if (ParameterWasBound("EmailForwardingEnabled"))
                context.EmailForwardingEnabled = this.EmailForwardingEnabled;
            context.EmailIdentity = this.EmailIdentity;
            
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
            var request = new Amazon.PinpointEmail.Model.PutEmailIdentityFeedbackAttributesRequest();
            
            if (cmdletContext.EmailForwardingEnabled != null)
            {
                request.EmailForwardingEnabled = cmdletContext.EmailForwardingEnabled.Value;
            }
            if (cmdletContext.EmailIdentity != null)
            {
                request.EmailIdentity = cmdletContext.EmailIdentity;
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
                    pipelineOutput = this.EmailIdentity;
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
        
        private Amazon.PinpointEmail.Model.PutEmailIdentityFeedbackAttributesResponse CallAWSServiceOperation(IAmazonPinpointEmail client, Amazon.PinpointEmail.Model.PutEmailIdentityFeedbackAttributesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint Email", "PutEmailIdentityFeedbackAttributes");
            try
            {
                #if DESKTOP
                return client.PutEmailIdentityFeedbackAttributes(request);
                #elif CORECLR
                return client.PutEmailIdentityFeedbackAttributesAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? EmailForwardingEnabled { get; set; }
            public System.String EmailIdentity { get; set; }
        }
        
    }
}
