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
    /// Creates an endpoint for a device and mobile app on one of the supported push notification
    /// services, such as GCM and APNS.       <code>CreatePlatformEndpoint</code> requires
    /// the PlatformApplicationArn that is returned from <code>CreatePlatformApplication</code>.
    /// The EndpointArn that is      returned when using <code>CreatePlatformEndpoint</code>
    /// can then be used by the <code>Publish</code> action to send a message to a mobile
    /// app or by the <code>Subscribe</code>       action for subscription to a topic. The
    /// <code>CreatePlatformEndpoint</code> action is idempotent, so if the requester already
    /// owns an endpoint with the same device token and attributes,       that endpoint's
    /// ARN is returned without creating a new endpoint.       For more information, see <a href="http://docs.aws.amazon.com/sns/latest/dg/SNSMobilePush.html">Using Amazon SNS
    /// Mobile Push Notifications</a>.    
    /// 
    ///     
    /// <para>
    /// When using <code>CreatePlatformEndpoint</code> with Baidu, two attributes must be
    /// provided: ChannelId and UserId. The token field must also contain the ChannelId. 
    ///      For more information, see <a href="http://docs.aws.amazon.com/sns/latest/dg/SNSMobilePushBaiduEndpoint.html">Creating
    /// an Amazon SNS Endpoint for Baidu</a>.          
    /// </para>
    /// </summary>
    [Cmdlet("New", "SNSPlatformEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CreatePlatformEndpoint operation against Amazon Simple Notification Service.", Operation = new[] {"CreatePlatformEndpoint"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleNotificationService.Model.CreatePlatformEndpointResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewSNSPlatformEndpointCmdlet : AmazonSimpleNotificationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>For a list of attributes, see <a href="http://docs.aws.amazon.com/sns/latest/api/API_SetEndpointAttributes.html">SetEndpointAttributes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter CustomUserData
        /// <summary>
        /// <para>
        /// <para>Arbitrary user data to associate with the endpoint. Amazon SNS does not use this data.
        /// The data must be in UTF-8 format and less than 2KB.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3)]
        public System.String CustomUserData { get; set; }
        #endregion
        
        #region Parameter PlatformApplicationArn
        /// <summary>
        /// <para>
        /// <para>PlatformApplicationArn returned from CreatePlatformApplication is used to create a
        /// an endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String PlatformApplicationArn { get; set; }
        #endregion
        
        #region Parameter Token
        /// <summary>
        /// <para>
        /// <para>Unique identifier created by the notification service for an app on a device.    
        ///   The specific name for Token will vary, depending on which notification service is
        /// being used.       For example, when using APNS as the notification service, you need
        /// the device token.       Alternatively, when using GCM or ADM, the device token equivalent
        /// is called the registration ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Token { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SNSPlatformEndpoint (CreatePlatformEndpoint)"))
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
                context.Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.CustomUserData = this.CustomUserData;
            context.PlatformApplicationArn = this.PlatformApplicationArn;
            context.Token = this.Token;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SimpleNotificationService.Model.CreatePlatformEndpointRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            if (cmdletContext.CustomUserData != null)
            {
                request.CustomUserData = cmdletContext.CustomUserData;
            }
            if (cmdletContext.PlatformApplicationArn != null)
            {
                request.PlatformApplicationArn = cmdletContext.PlatformApplicationArn;
            }
            if (cmdletContext.Token != null)
            {
                request.Token = cmdletContext.Token;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreatePlatformEndpoint(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EndpointArn;
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
            public Dictionary<System.String, System.String> Attributes { get; set; }
            public System.String CustomUserData { get; set; }
            public System.String PlatformApplicationArn { get; set; }
            public System.String Token { get; set; }
        }
        
    }
}
