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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Creates a new Kinesis video stream. 
    /// 
    ///  
    /// <para>
    /// When you create a new stream, Kinesis Video Streams assigns it a version number. When
    /// you change the stream's metadata, Kinesis Video Streams updates the version. 
    /// </para><para><code>CreateStream</code> is an asynchronous operation.
    /// </para><para>
    /// For information about how the service works, see <a href="http://docs.aws.amazon.com/kinesisvideostreams/latest/dg/how-it-works.html">How
    /// it Works</a>. 
    /// </para><para>
    /// You must have permissions for the <code>KinesisVideo:CreateStream</code> action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KVStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams CreateStream API operation.", Operation = new[] {"CreateStream"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.KinesisVideo.Model.CreateStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewKVStreamCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        #region Parameter DataRetentionInHour
        /// <summary>
        /// <para>
        /// <para>The number of hours that you want to retain the data in the stream. Kinesis Video
        /// Streams retains the data in a data store that is associated with the stream.</para><para>The default value is 0, indicating that the stream does not persist data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DataRetentionInHours")]
        public System.Int32 DataRetentionInHour { get; set; }
        #endregion
        
        #region Parameter DeviceName
        /// <summary>
        /// <para>
        /// <para>The name of the device that is writing to the stream. </para><note><para>In the current implementation, Kinesis Video Streams does not use this name.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeviceName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Key Management Service (AWS KMS) key that you want Kinesis Video
        /// Streams to use to encrypt stream data.</para><para>If no key ID is specified, the default, Kinesis Video-managed key (<code>aws/kinesisvideo</code>)
        /// is used.</para><para> For more information, see <a href="http://docs.aws.amazon.com/kms/latest/APIReference/API_DescribeKey.html#API_DescribeKey_RequestParameters">DescribeKey</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MediaType
        /// <summary>
        /// <para>
        /// <para>The media type of the stream. Consumers of the stream can use this information when
        /// processing the stream. For more information about media types, see <a href="http://www.iana.org/assignments/media-types/media-types.xhtml">Media
        /// Types</a>. If you choose to specify the <code>MediaType</code>, see <a href="https://tools.ietf.org/html/rfc6838#section-4.2">Naming
        /// Requirements</a> for guidelines.</para><para>To play video on the console, the media must be H.264 encoded, and you need to specify
        /// this video type in this parameter as <code>video/h264</code>. </para><para>This parameter is optional; the default value is <code>null</code> (or empty in JSON).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MediaType { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>A name for the stream that you are creating.</para><para>The stream name is an identifier for the stream, and must be unique for each account
        /// and region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KVStream (CreateStream)"))
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
            
            if (ParameterWasBound("DataRetentionInHour"))
                context.DataRetentionInHours = this.DataRetentionInHour;
            context.DeviceName = this.DeviceName;
            context.KmsKeyId = this.KmsKeyId;
            context.MediaType = this.MediaType;
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
            var request = new Amazon.KinesisVideo.Model.CreateStreamRequest();
            
            if (cmdletContext.DataRetentionInHours != null)
            {
                request.DataRetentionInHours = cmdletContext.DataRetentionInHours.Value;
            }
            if (cmdletContext.DeviceName != null)
            {
                request.DeviceName = cmdletContext.DeviceName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.MediaType != null)
            {
                request.MediaType = cmdletContext.MediaType;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StreamARN;
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
        
        private Amazon.KinesisVideo.Model.CreateStreamResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.CreateStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "CreateStream");
            try
            {
                #if DESKTOP
                return client.CreateStream(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateStreamAsync(request);
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
            public System.Int32? DataRetentionInHours { get; set; }
            public System.String DeviceName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MediaType { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
