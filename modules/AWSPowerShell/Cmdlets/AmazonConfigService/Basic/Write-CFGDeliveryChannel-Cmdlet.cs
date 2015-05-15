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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates a new delivery channel object to deliver the configuration information to
    /// an Amazon S3 bucket, and to an Amazon SNS topic. 
    /// 
    ///  
    /// <para>
    /// You can use this action to change the Amazon S3 bucket or an Amazon SNS topic of the
    /// existing delivery channel. To change the Amazon S3 bucket or an Amazon SNS topic,
    /// call this action and specify the changed values for the S3 bucket and the SNS topic.
    /// If you specify a different value for either the S3 bucket or the SNS topic, this action
    /// will keep the existing value for the parameter that is not changed. 
    /// </para><note><para>
    /// Currently, you can specify only one delivery channel per account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGDeliveryChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutDeliveryChannel operation against Amazon Config.", Operation = new[] {"PutDeliveryChannel"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DeliveryChannelName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type PutDeliveryChannelResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class WriteCFGDeliveryChannelCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The name of the delivery channel. By default, AWS Config automatically assigns the
        /// name "default" when creating the delivery channel. You cannot change the assigned
        /// name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("DeliveryChannel_Name")]
        public String DeliveryChannelName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket used to store configuration history for the delivery
        /// channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeliveryChannel_S3BucketName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The prefix for the specified Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeliveryChannel_S3KeyPrefix { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role used for accessing the Amazon S3 bucket
        /// and the Amazon SNS topic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DeliveryChannel_SnsTopicARN { get; set; }
        
        /// <summary>
        /// Returns the value passed to the DeliveryChannelName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DeliveryChannelName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGDeliveryChannel (PutDeliveryChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DeliveryChannelName = this.DeliveryChannelName;
            context.DeliveryChannel_S3BucketName = this.DeliveryChannel_S3BucketName;
            context.DeliveryChannel_S3KeyPrefix = this.DeliveryChannel_S3KeyPrefix;
            context.DeliveryChannel_SnsTopicARN = this.DeliveryChannel_SnsTopicARN;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new PutDeliveryChannelRequest();
            
            
             // populate DeliveryChannel
            bool requestDeliveryChannelIsNull = true;
            request.DeliveryChannel = new DeliveryChannel();
            String requestDeliveryChannel_deliveryChannelName = null;
            if (cmdletContext.DeliveryChannelName != null)
            {
                requestDeliveryChannel_deliveryChannelName = cmdletContext.DeliveryChannelName;
            }
            if (requestDeliveryChannel_deliveryChannelName != null)
            {
                request.DeliveryChannel.Name = requestDeliveryChannel_deliveryChannelName;
                requestDeliveryChannelIsNull = false;
            }
            String requestDeliveryChannel_deliveryChannel_S3BucketName = null;
            if (cmdletContext.DeliveryChannel_S3BucketName != null)
            {
                requestDeliveryChannel_deliveryChannel_S3BucketName = cmdletContext.DeliveryChannel_S3BucketName;
            }
            if (requestDeliveryChannel_deliveryChannel_S3BucketName != null)
            {
                request.DeliveryChannel.S3BucketName = requestDeliveryChannel_deliveryChannel_S3BucketName;
                requestDeliveryChannelIsNull = false;
            }
            String requestDeliveryChannel_deliveryChannel_S3KeyPrefix = null;
            if (cmdletContext.DeliveryChannel_S3KeyPrefix != null)
            {
                requestDeliveryChannel_deliveryChannel_S3KeyPrefix = cmdletContext.DeliveryChannel_S3KeyPrefix;
            }
            if (requestDeliveryChannel_deliveryChannel_S3KeyPrefix != null)
            {
                request.DeliveryChannel.S3KeyPrefix = requestDeliveryChannel_deliveryChannel_S3KeyPrefix;
                requestDeliveryChannelIsNull = false;
            }
            String requestDeliveryChannel_deliveryChannel_SnsTopicARN = null;
            if (cmdletContext.DeliveryChannel_SnsTopicARN != null)
            {
                requestDeliveryChannel_deliveryChannel_SnsTopicARN = cmdletContext.DeliveryChannel_SnsTopicARN;
            }
            if (requestDeliveryChannel_deliveryChannel_SnsTopicARN != null)
            {
                request.DeliveryChannel.SnsTopicARN = requestDeliveryChannel_deliveryChannel_SnsTopicARN;
                requestDeliveryChannelIsNull = false;
            }
             // determine if request.DeliveryChannel should be set to null
            if (requestDeliveryChannelIsNull)
            {
                request.DeliveryChannel = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.PutDeliveryChannel(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.DeliveryChannelName;
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
            public String DeliveryChannelName { get; set; }
            public String DeliveryChannel_S3BucketName { get; set; }
            public String DeliveryChannel_S3KeyPrefix { get; set; }
            public String DeliveryChannel_SnsTopicARN { get; set; }
        }
        
    }
}
