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
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Amazon.PowerShell.Cmdlets.SNS
{
    /// <summary>
    /// Verifies an endpoint owner's intent to receive messages by validating the token sent
    /// to the endpoint by an earlier <c>Subscribe</c> action. If the token is valid, the
    /// action creates a new subscription and returns its Amazon Resource Name (ARN). This
    /// call requires an AWS signature only when the <c>AuthenticateOnUnsubscribe</c> flag
    /// is set to "true".
    /// </summary>
    [Cmdlet("Confirm", "SNSSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Simple Notification Service (SNS) ConfirmSubscription API operation.", Operation = new[] {"ConfirmSubscription"}, SelectReturnType = typeof(Amazon.SimpleNotificationService.Model.ConfirmSubscriptionResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleNotificationService.Model.ConfirmSubscriptionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.ConfirmSubscriptionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ConfirmSNSSubscriptionCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthenticateOnUnsubscribe
        /// <summary>
        /// <para>
        /// <para>Disallows unauthenticated unsubscribes of the subscription. If the value of this parameter
        /// is <c>true</c> and the request has an Amazon Web Services signature, then only the
        /// topic owner and the subscription owner can unsubscribe the endpoint. The unsubscribe
        /// action requires Amazon Web Services authentication. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String AuthenticateOnUnsubscribe { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>Short-lived token sent to an endpoint during the <c>Subscribe</c> action.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Token { get; set; }
        #endregion
        
        #region Parameter TopicArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the topic for which you wish to confirm a subscription.</para>
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
        public System.String TopicArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SubscriptionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleNotificationService.Model.ConfirmSubscriptionResponse).
        /// Specifying the name of a property of type Amazon.SimpleNotificationService.Model.ConfirmSubscriptionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SubscriptionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TopicArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TopicArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TopicArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TopicArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Confirm-SNSSubscription (ConfirmSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleNotificationService.Model.ConfirmSubscriptionResponse, ConfirmSNSSubscriptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TopicArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthenticateOnUnsubscribe = this.AuthenticateOnUnsubscribe;
            context.Token = this.Token;
            #if MODULAR
            if (this.Token == null && ParameterWasBound(nameof(this.Token)))
            {
                WriteWarning("You are passing $null as a value for parameter Token which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TopicArn = this.TopicArn;
            #if MODULAR
            if (this.TopicArn == null && ParameterWasBound(nameof(this.TopicArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TopicArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleNotificationService.Model.ConfirmSubscriptionRequest();
            
            if (cmdletContext.AuthenticateOnUnsubscribe != null)
            {
                request.AuthenticateOnUnsubscribe = cmdletContext.AuthenticateOnUnsubscribe;
            }
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
            }
            if (cmdletContext.TopicArn != null)
            {
                request.TopicArn = cmdletContext.TopicArn;
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
        
        private Amazon.SimpleNotificationService.Model.ConfirmSubscriptionResponse CallAWSServiceOperation(IAmazonSimpleNotificationService client, Amazon.SimpleNotificationService.Model.ConfirmSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Notification Service (SNS)", "ConfirmSubscription");
            try
            {
                #if DESKTOP
                return client.ConfirmSubscription(request);
                #elif CORECLR
                return client.ConfirmSubscriptionAsync(request).GetAwaiter().GetResult();
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
            public System.String AuthenticateOnUnsubscribe { get; set; }
            public System.String Token { get; set; }
            public System.String TopicArn { get; set; }
            public System.Func<Amazon.SimpleNotificationService.Model.ConfirmSubscriptionResponse, ConfirmSNSSubscriptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SubscriptionArn;
        }
        
    }
}
