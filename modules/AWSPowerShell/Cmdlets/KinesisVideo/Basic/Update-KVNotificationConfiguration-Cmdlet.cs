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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Updates the notification information for a stream.
    /// </summary>
    [Cmdlet("Update", "KVNotificationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams UpdateNotificationConfiguration API operation.", Operation = new[] {"UpdateNotificationConfiguration"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.UpdateNotificationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisVideo.Model.UpdateNotificationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisVideo.Model.UpdateNotificationConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKVNotificationConfigurationCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter NotificationConfiguration_Status
        /// <summary>
        /// <para>
        /// <para>Indicates if a notification configuration is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisVideo.ConfigurationStatus")]
        public Amazon.KinesisVideo.ConfigurationStatus NotificationConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Kinesis video stream from where you want to
        /// update the notification configuration. You must specify either the <c>StreamName</c>
        /// or the <c>StreamARN</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream from which to update the notification configuration. You must
        /// specify either the <c>StreamName</c> or the <c>StreamARN</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter DestinationConfig_Uri
        /// <summary>
        /// <para>
        /// <para>The Uniform Resource Identifier (URI) that identifies where the images will be delivered.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NotificationConfiguration_DestinationConfig_Uri")]
        public System.String DestinationConfig_Uri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.UpdateNotificationConfigurationResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KVNotificationConfiguration (UpdateNotificationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.UpdateNotificationConfigurationResponse, UpdateKVNotificationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationConfig_Uri = this.DestinationConfig_Uri;
            context.NotificationConfiguration_Status = this.NotificationConfiguration_Status;
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            
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
            var request = new Amazon.KinesisVideo.Model.UpdateNotificationConfigurationRequest();
            
            
             // populate NotificationConfiguration
            var requestNotificationConfigurationIsNull = true;
            request.NotificationConfiguration = new Amazon.KinesisVideo.Model.NotificationConfiguration();
            Amazon.KinesisVideo.ConfigurationStatus requestNotificationConfiguration_notificationConfiguration_Status = null;
            if (cmdletContext.NotificationConfiguration_Status != null)
            {
                requestNotificationConfiguration_notificationConfiguration_Status = cmdletContext.NotificationConfiguration_Status;
            }
            if (requestNotificationConfiguration_notificationConfiguration_Status != null)
            {
                request.NotificationConfiguration.Status = requestNotificationConfiguration_notificationConfiguration_Status;
                requestNotificationConfigurationIsNull = false;
            }
            Amazon.KinesisVideo.Model.NotificationDestinationConfig requestNotificationConfiguration_notificationConfiguration_DestinationConfig = null;
            
             // populate DestinationConfig
            var requestNotificationConfiguration_notificationConfiguration_DestinationConfigIsNull = true;
            requestNotificationConfiguration_notificationConfiguration_DestinationConfig = new Amazon.KinesisVideo.Model.NotificationDestinationConfig();
            System.String requestNotificationConfiguration_notificationConfiguration_DestinationConfig_destinationConfig_Uri = null;
            if (cmdletContext.DestinationConfig_Uri != null)
            {
                requestNotificationConfiguration_notificationConfiguration_DestinationConfig_destinationConfig_Uri = cmdletContext.DestinationConfig_Uri;
            }
            if (requestNotificationConfiguration_notificationConfiguration_DestinationConfig_destinationConfig_Uri != null)
            {
                requestNotificationConfiguration_notificationConfiguration_DestinationConfig.Uri = requestNotificationConfiguration_notificationConfiguration_DestinationConfig_destinationConfig_Uri;
                requestNotificationConfiguration_notificationConfiguration_DestinationConfigIsNull = false;
            }
             // determine if requestNotificationConfiguration_notificationConfiguration_DestinationConfig should be set to null
            if (requestNotificationConfiguration_notificationConfiguration_DestinationConfigIsNull)
            {
                requestNotificationConfiguration_notificationConfiguration_DestinationConfig = null;
            }
            if (requestNotificationConfiguration_notificationConfiguration_DestinationConfig != null)
            {
                request.NotificationConfiguration.DestinationConfig = requestNotificationConfiguration_notificationConfiguration_DestinationConfig;
                requestNotificationConfigurationIsNull = false;
            }
             // determine if request.NotificationConfiguration should be set to null
            if (requestNotificationConfigurationIsNull)
            {
                request.NotificationConfiguration = null;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
        
        private Amazon.KinesisVideo.Model.UpdateNotificationConfigurationResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.UpdateNotificationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "UpdateNotificationConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateNotificationConfiguration(request);
                #elif CORECLR
                return client.UpdateNotificationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationConfig_Uri { get; set; }
            public Amazon.KinesisVideo.ConfigurationStatus NotificationConfiguration_Status { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.UpdateNotificationConfigurationResponse, UpdateKVNotificationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
