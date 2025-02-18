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
using System.Threading;
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
    /// </para><para><c>CreateStream</c> is an asynchronous operation.
    /// </para><para>
    /// For information about how the service works, see <a href="https://docs.aws.amazon.com/kinesisvideostreams/latest/dg/how-it-works.html">How
    /// it Works</a>. 
    /// </para><para>
    /// You must have permissions for the <c>KinesisVideo:CreateStream</c> action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KVStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams CreateStream API operation.", Operation = new[] {"CreateStream"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.CreateStreamResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisVideo.Model.CreateStreamResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KinesisVideo.Model.CreateStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKVStreamCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataRetentionInHour
        /// <summary>
        /// <para>
        /// <para>The number of hours that you want to retain the data in the stream. Kinesis Video
        /// Streams retains the data in a data store that is associated with the stream.</para><para>The default value is 0, indicating that the stream does not persist data.</para><para>When the <c>DataRetentionInHours</c> value is 0, consumers can still consume the fragments
        /// that remain in the service host buffer, which has a retention time limit of 5 minutes
        /// and a retention memory limit of 200 MB. Fragments are removed from the buffer when
        /// either limit is reached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataRetentionInHours")]
        public System.Int32? DataRetentionInHour { get; set; }
        #endregion
        
        #region Parameter DeviceName
        /// <summary>
        /// <para>
        /// <para>The name of the device that is writing to the stream. </para><note><para>In the current implementation, Kinesis Video Streams does not use this name.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Key Management Service (KMS) key that you want Kinesis Video Streams
        /// to use to encrypt stream data.</para><para>If no key ID is specified, the default, Kinesis Video-managed key (<c>Amazon Web Services/kinesisvideo</c>)
        /// is used.</para><para> For more information, see <a href="https://docs.aws.amazon.com/kms/latest/APIReference/API_DescribeKey.html#API_DescribeKey_RequestParameters">DescribeKey</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter MediaType
        /// <summary>
        /// <para>
        /// <para>The media type of the stream. Consumers of the stream can use this information when
        /// processing the stream. For more information about media types, see <a href="http://www.iana.org/assignments/media-types/media-types.xhtml">Media
        /// Types</a>. If you choose to specify the <c>MediaType</c>, see <a href="https://tools.ietf.org/html/rfc6838#section-4.2">Naming
        /// Requirements</a> for guidelines.</para><para>Example valid values include "video/h264" and "video/h264,audio/aac".</para><para>This parameter is optional; the default value is <c>null</c> (or empty in JSON).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MediaType { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>A name for the stream that you are creating.</para><para>The stream name is an identifier for the stream, and must be unique for each account
        /// and region.</para>
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
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tags to associate with the specified stream. Each tag is a key-value pair
        /// (the value is optional).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.CreateStreamResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideo.Model.CreateStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamARN";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KVStream (CreateStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.CreateStreamResponse, NewKVStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataRetentionInHour = this.DataRetentionInHour;
            context.DeviceName = this.DeviceName;
            context.KmsKeyId = this.KmsKeyId;
            context.MediaType = this.MediaType;
            context.StreamName = this.StreamName;
            #if MODULAR
            if (this.StreamName == null && ParameterWasBound(nameof(this.StreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            
            if (cmdletContext.DataRetentionInHour != null)
            {
                request.DataRetentionInHours = cmdletContext.DataRetentionInHour.Value;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.KinesisVideo.Model.CreateStreamResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.CreateStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "CreateStream");
            try
            {
                return client.CreateStreamAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? DataRetentionInHour { get; set; }
            public System.String DeviceName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String MediaType { get; set; }
            public System.String StreamName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.CreateStreamResponse, NewKVStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamARN;
        }
        
    }
}
