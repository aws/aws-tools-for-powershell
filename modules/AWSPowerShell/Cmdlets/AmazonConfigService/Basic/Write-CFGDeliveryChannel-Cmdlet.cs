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
    /// Creates a delivery channel object to deliver configuration information to an Amazon
    /// S3 bucket and Amazon SNS topic.
    /// 
    ///  
    /// <para>
    /// Before you can create a delivery channel, you must create a configuration recorder.
    /// </para><para>
    /// You can use this action to change the Amazon S3 bucket or an Amazon SNS topic of the
    /// existing delivery channel. To change the Amazon S3 bucket or an Amazon SNS topic,
    /// call this action and specify the changed values for the S3 bucket and the SNS topic.
    /// If you specify a different value for either the S3 bucket or the SNS topic, this action
    /// will keep the existing value for the parameter that is not changed.
    /// </para><note><para>
    /// You can have only one delivery channel per region in your account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGDeliveryChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Config PutDeliveryChannel API operation.", Operation = new[] {"PutDeliveryChannel"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the DeliveryChannelName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ConfigService.Model.PutDeliveryChannelResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGDeliveryChannelCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigSnapshotDeliveryProperties_DeliveryFrequency
        /// <summary>
        /// <para>
        /// <para>The frequency with which AWS Config delivers configuration snapshots.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency")]
        [AWSConstantClassSource("Amazon.ConfigService.MaximumExecutionFrequency")]
        public Amazon.ConfigService.MaximumExecutionFrequency ConfigSnapshotDeliveryProperties_DeliveryFrequency { get; set; }
        #endregion
        
        #region Parameter DeliveryChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the delivery channel. By default, AWS Config assigns the name "default"
        /// when creating the delivery channel. To change the delivery channel name, you must
        /// use the DeleteDeliveryChannel action to delete your current delivery channel, and
        /// then you must use the PutDeliveryChannel command to create a delivery channel that
        /// has the desired name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("DeliveryChannel_Name")]
        public System.String DeliveryChannelName { get; set; }
        #endregion
        
        #region Parameter DeliveryChannel_S3BucketName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket to which AWS Config delivers configuration snapshots
        /// and configuration history files.</para><para>If you specify a bucket that belongs to another AWS account, that bucket must have
        /// policies that grant access permissions to AWS Config. For more information, see <a href="http://docs.aws.amazon.com/config/latest/developerguide/s3-bucket-policy.html">Permissions
        /// for the Amazon S3 Bucket</a> in the AWS Config Developer Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeliveryChannel_S3BucketName { get; set; }
        #endregion
        
        #region Parameter DeliveryChannel_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix for the specified Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeliveryChannel_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter DeliveryChannel_SnsTopicARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic to which AWS Config sends notifications
        /// about configuration changes.</para><para>If you choose a topic from another account, the topic must have policies that grant
        /// access permissions to AWS Config. For more information, see <a href="http://docs.aws.amazon.com/config/latest/developerguide/sns-topic-policy.html">Permissions
        /// for the Amazon SNS Topic</a> in the AWS Config Developer Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeliveryChannel_SnsTopicARN { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the DeliveryChannelName parameter.
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency = this.ConfigSnapshotDeliveryProperties_DeliveryFrequency;
            context.DeliveryChannelName = this.DeliveryChannelName;
            context.DeliveryChannel_S3BucketName = this.DeliveryChannel_S3BucketName;
            context.DeliveryChannel_S3KeyPrefix = this.DeliveryChannel_S3KeyPrefix;
            context.DeliveryChannel_SnsTopicARN = this.DeliveryChannel_SnsTopicARN;
            
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
            var request = new Amazon.ConfigService.Model.PutDeliveryChannelRequest();
            
            
             // populate DeliveryChannel
            bool requestDeliveryChannelIsNull = true;
            request.DeliveryChannel = new Amazon.ConfigService.Model.DeliveryChannel();
            System.String requestDeliveryChannel_deliveryChannelName = null;
            if (cmdletContext.DeliveryChannelName != null)
            {
                requestDeliveryChannel_deliveryChannelName = cmdletContext.DeliveryChannelName;
            }
            if (requestDeliveryChannel_deliveryChannelName != null)
            {
                request.DeliveryChannel.Name = requestDeliveryChannel_deliveryChannelName;
                requestDeliveryChannelIsNull = false;
            }
            System.String requestDeliveryChannel_deliveryChannel_S3BucketName = null;
            if (cmdletContext.DeliveryChannel_S3BucketName != null)
            {
                requestDeliveryChannel_deliveryChannel_S3BucketName = cmdletContext.DeliveryChannel_S3BucketName;
            }
            if (requestDeliveryChannel_deliveryChannel_S3BucketName != null)
            {
                request.DeliveryChannel.S3BucketName = requestDeliveryChannel_deliveryChannel_S3BucketName;
                requestDeliveryChannelIsNull = false;
            }
            System.String requestDeliveryChannel_deliveryChannel_S3KeyPrefix = null;
            if (cmdletContext.DeliveryChannel_S3KeyPrefix != null)
            {
                requestDeliveryChannel_deliveryChannel_S3KeyPrefix = cmdletContext.DeliveryChannel_S3KeyPrefix;
            }
            if (requestDeliveryChannel_deliveryChannel_S3KeyPrefix != null)
            {
                request.DeliveryChannel.S3KeyPrefix = requestDeliveryChannel_deliveryChannel_S3KeyPrefix;
                requestDeliveryChannelIsNull = false;
            }
            System.String requestDeliveryChannel_deliveryChannel_SnsTopicARN = null;
            if (cmdletContext.DeliveryChannel_SnsTopicARN != null)
            {
                requestDeliveryChannel_deliveryChannel_SnsTopicARN = cmdletContext.DeliveryChannel_SnsTopicARN;
            }
            if (requestDeliveryChannel_deliveryChannel_SnsTopicARN != null)
            {
                request.DeliveryChannel.SnsTopicARN = requestDeliveryChannel_deliveryChannel_SnsTopicARN;
                requestDeliveryChannelIsNull = false;
            }
            Amazon.ConfigService.Model.ConfigSnapshotDeliveryProperties requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties = null;
            
             // populate ConfigSnapshotDeliveryProperties
            bool requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryPropertiesIsNull = true;
            requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties = new Amazon.ConfigService.Model.ConfigSnapshotDeliveryProperties();
            Amazon.ConfigService.MaximumExecutionFrequency requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties_configSnapshotDeliveryProperties_DeliveryFrequency = null;
            if (cmdletContext.DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency != null)
            {
                requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties_configSnapshotDeliveryProperties_DeliveryFrequency = cmdletContext.DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency;
            }
            if (requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties_configSnapshotDeliveryProperties_DeliveryFrequency != null)
            {
                requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties.DeliveryFrequency = requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties_configSnapshotDeliveryProperties_DeliveryFrequency;
                requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryPropertiesIsNull = false;
            }
             // determine if requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties should be set to null
            if (requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryPropertiesIsNull)
            {
                requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties = null;
            }
            if (requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties != null)
            {
                request.DeliveryChannel.ConfigSnapshotDeliveryProperties = requestDeliveryChannel_deliveryChannel_ConfigSnapshotDeliveryProperties;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.ConfigService.Model.PutDeliveryChannelResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutDeliveryChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutDeliveryChannel");
            try
            {
                #if DESKTOP
                return client.PutDeliveryChannel(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.PutDeliveryChannelAsync(request);
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
            public Amazon.ConfigService.MaximumExecutionFrequency DeliveryChannel_ConfigSnapshotDeliveryProperties_DeliveryFrequency { get; set; }
            public System.String DeliveryChannelName { get; set; }
            public System.String DeliveryChannel_S3BucketName { get; set; }
            public System.String DeliveryChannel_S3KeyPrefix { get; set; }
            public System.String DeliveryChannel_SnsTopicARN { get; set; }
        }
        
    }
}
