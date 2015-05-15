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
    /// services,       such as APNS and GCM.      For more information, see <a href="http://docs.aws.amazon.com/sns/latest/dg/SNSMobilePush.html">Using
    /// Amazon SNS Mobile Push Notifications</a>.
    /// </summary>
    [Cmdlet("Set", "SNSPlatformApplicationAttributes", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetPlatformApplicationAttributes operation against Amazon Simple Notification Service.", Operation = new[] {"SetPlatformApplicationAttributes"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the PlatformApplicationArn parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type SetPlatformApplicationAttributesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class SetSNSPlatformApplicationAttributesCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A map of the platform application attributes. Attributes in this map include the following:</para><ul><li><code>PlatformCredential</code> -- The credential received
        /// from the notification service. For APNS/APNS_SANDBOX, PlatformCredential is "private
        /// key".         For GCM, PlatformCredential is "API key". For ADM, PlatformCredential
        /// is "client secret".</li><li><code>PlatformPrincipal</code> -- The principal
        /// received from the notification service. For APNS/APNS_SANDBOX, PlatformPrincipal is
        /// "SSL certificate".         For GCM, PlatformPrincipal is not applicable. For ADM,
        /// PlatformPrincipal is "client id".</li><li><code>EventEndpointCreated</code>
        /// -- Topic ARN to which EndpointCreated event notifications should be sent.</li><li><code>EventEndpointDeleted</code> -- Topic ARN to which EndpointDeleted event
        /// notifications should be sent.</li><li><code>EventEndpointUpdated</code> -- Topic
        /// ARN to which EndpointUpdate event notifications should be sent.</li><li><code>EventDeliveryFailure</code>
        /// -- Topic ARN to which DeliveryFailure event notifications should be sent upon Direct
        /// Publish delivery failure (permanent) to one of the application's endpoints.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>PlatformApplicationArn for SetPlatformApplicationAttributes action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String PlatformApplicationArn { get; set; }
        
        /// <summary>
        /// Returns the value passed to the PlatformApplicationArn parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
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
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.PlatformApplicationArn = this.PlatformApplicationArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new SetPlatformApplicationAttributesRequest();
            
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
                var response = client.SetPlatformApplicationAttributes(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<String, String> Attributes { get; set; }
            public String PlatformApplicationArn { get; set; }
        }
        
    }
}
