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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Creates an Amazon Rekognition stream processor that you can use to detect and recognize
    /// faces or to detect labels in a streaming video.
    /// 
    ///  
    /// <para>
    /// Amazon Rekognition Video is a consumer of live video from Amazon Kinesis Video Streams.
    /// There are two different settings for stream processors in Amazon Rekognition: detecting
    /// faces and detecting labels.
    /// </para><ul><li><para>
    /// If you are creating a stream processor for detecting faces, you provide as input a
    /// Kinesis video stream (<c>Input</c>) and a Kinesis data stream (<c>Output</c>) stream
    /// for receiving the output. You must use the <c>FaceSearch</c> option in <c>Settings</c>,
    /// specifying the collection that contains the faces you want to recognize. After you
    /// have finished analyzing a streaming video, use <a>StopStreamProcessor</a> to stop
    /// processing.
    /// </para></li><li><para>
    /// If you are creating a stream processor to detect labels, you provide as input a Kinesis
    /// video stream (<c>Input</c>), Amazon S3 bucket information (<c>Output</c>), and an
    /// Amazon SNS topic ARN (<c>NotificationChannel</c>). You can also provide a KMS key
    /// ID to encrypt the data sent to your Amazon S3 bucket. You specify what you want to
    /// detect by using the <c>ConnectedHome</c> option in settings, and selecting one of
    /// the following: <c>PERSON</c>, <c>PET</c>, <c>PACKAGE</c>, <c>ALL</c> You can also
    /// specify where in the frame you want Amazon Rekognition to monitor with <c>RegionsOfInterest</c>.
    /// When you run the <a>StartStreamProcessor</a> operation on a label detection stream
    /// processor, you input start and stop information to determine the length of the processing
    /// time.
    /// </para></li></ul><para>
    ///  Use <c>Name</c> to assign an identifier for the stream processor. You use <c>Name</c>
    /// to manage the stream processor. For example, you can start processing the source video
    /// by calling <a>StartStreamProcessor</a> with the <c>Name</c> field. 
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:CreateStreamProcessor</c>
    /// action. If you want to tag your stream processor, you also require permission to perform
    /// the <c>rekognition:TagResource</c> operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "REKStreamProcessor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition CreateStreamProcessor API operation.", Operation = new[] {"CreateStreamProcessor"}, SelectReturnType = typeof(Amazon.Rekognition.Model.CreateStreamProcessorResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.CreateStreamProcessorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.CreateStreamProcessorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewREKStreamProcessorCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter KinesisVideoStream_Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the Kinesis video stream stream that streams the source video.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_KinesisVideoStream_Arn")]
        public System.String KinesisVideoStream_Arn { get; set; }
        #endregion
        
        #region Parameter KinesisDataStream_Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the output Amazon Kinesis Data Streams stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_KinesisDataStream_Arn")]
        public System.String KinesisDataStream_Arn { get; set; }
        #endregion
        
        #region Parameter S3Destination_Bucket
        /// <summary>
        /// <para>
        /// <para> The name of the Amazon S3 bucket you want to associate with the streaming video project.
        /// You must be the owner of the Amazon S3 bucket. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_S3Destination_Bucket")]
        public System.String S3Destination_Bucket { get; set; }
        #endregion
        
        #region Parameter FaceSearch_CollectionId
        /// <summary>
        /// <para>
        /// <para>The ID of a collection that contains faces that you want to search for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_FaceSearch_CollectionId")]
        public System.String FaceSearch_CollectionId { get; set; }
        #endregion
        
        #region Parameter FaceSearch_FaceMatchThreshold
        /// <summary>
        /// <para>
        /// <para>Minimum face match confidence score that must be met to return a result for a recognized
        /// face. The default is 80. 0 is the lowest confidence. 100 is the highest confidence.
        /// Values between 0 and 100 are accepted, and values lower than 80 are set to 80.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_FaceSearch_FaceMatchThreshold")]
        public System.Single? FaceSearch_FaceMatchThreshold { get; set; }
        #endregion
        
        #region Parameter S3Destination_KeyPrefix
        /// <summary>
        /// <para>
        /// <para> The prefix value of the location within the bucket that you want the information
        /// to be published to. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/using-prefixes.html">Using
        /// prefixes</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Output_S3Destination_KeyPrefix")]
        public System.String S3Destination_KeyPrefix { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para> The identifier for your AWS Key Management Service key (AWS KMS key). This is an
        /// optional parameter for label detection stream processors and should not be used to
        /// create a face search stream processor. You can supply the Amazon Resource Name (ARN)
        /// of your KMS key, the ID of your KMS key, an alias for your KMS key, or an alias ARN.
        /// The key is used to encrypt results and data published to your Amazon S3 bucket, which
        /// includes image frames and hero images. Your source images are unaffected. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ConnectedHome_Label
        /// <summary>
        /// <para>
        /// <para> Specifies what you want to detect in the video, such as people, packages, or pets.
        /// The current valid labels you can include in this list are: "PERSON", "PET", "PACKAGE",
        /// and "ALL". </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ConnectedHome_Labels")]
        public System.String[] ConnectedHome_Label { get; set; }
        #endregion
        
        #region Parameter ConnectedHome_MinConfidence
        /// <summary>
        /// <para>
        /// <para> The minimum confidence required to label an object in the video. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_ConnectedHome_MinConfidence")]
        public System.Single? ConnectedHome_MinConfidence { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>An identifier you assign to the stream processor. You can use <c>Name</c> to manage
        /// the stream processor. For example, you can get the current status of the stream processor
        /// by calling <a>DescribeStreamProcessor</a>. <c>Name</c> is idempotent. This is required
        /// for both face search and label detection stream processors. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter DataSharingPreference_OptIn
        /// <summary>
        /// <para>
        /// <para> If this option is set to true, you choose to share data with Rekognition to improve
        /// model performance. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DataSharingPreference_OptIn { get; set; }
        #endregion
        
        #region Parameter RegionsOfInterest
        /// <summary>
        /// <para>
        /// <para> Specifies locations in the frames where Amazon Rekognition checks for objects or
        /// people. You can specify up to 10 regions of interest, and each region has either a
        /// polygon or a bounding box. This is an optional parameter for label detection stream
        /// processors and should not be used to create a face search stream processor. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Rekognition.Model.RegionOfInterest[] RegionsOfInterest { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the IAM role that allows access to the stream
        /// processor. The IAM role provides Rekognition read permissions for a Kinesis stream.
        /// It also provides write permissions to an Amazon S3 bucket and Amazon Simple Notification
        /// Service topic for a label detection stream processor. This is required for both face
        /// search and label detection stream processors.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter NotificationChannel_SNSTopicArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Number (ARN) of the Amazon Amazon Simple Notification Service
        /// topic to which Amazon Rekognition posts the completion status. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationChannel_SNSTopicArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> A set of tags (key-value pairs) that you want to attach to the stream processor.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamProcessorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.CreateStreamProcessorResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.CreateStreamProcessorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamProcessorArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-REKStreamProcessor (CreateStreamProcessor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.CreateStreamProcessorResponse, NewREKStreamProcessorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataSharingPreference_OptIn = this.DataSharingPreference_OptIn;
            context.KinesisVideoStream_Arn = this.KinesisVideoStream_Arn;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationChannel_SNSTopicArn = this.NotificationChannel_SNSTopicArn;
            context.KinesisDataStream_Arn = this.KinesisDataStream_Arn;
            context.S3Destination_Bucket = this.S3Destination_Bucket;
            context.S3Destination_KeyPrefix = this.S3Destination_KeyPrefix;
            if (this.RegionsOfInterest != null)
            {
                context.RegionsOfInterest = new List<Amazon.Rekognition.Model.RegionOfInterest>(this.RegionsOfInterest);
            }
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ConnectedHome_Label != null)
            {
                context.ConnectedHome_Label = new List<System.String>(this.ConnectedHome_Label);
            }
            context.ConnectedHome_MinConfidence = this.ConnectedHome_MinConfidence;
            context.FaceSearch_CollectionId = this.FaceSearch_CollectionId;
            context.FaceSearch_FaceMatchThreshold = this.FaceSearch_FaceMatchThreshold;
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
            var request = new Amazon.Rekognition.Model.CreateStreamProcessorRequest();
            
            
             // populate DataSharingPreference
            var requestDataSharingPreferenceIsNull = true;
            request.DataSharingPreference = new Amazon.Rekognition.Model.StreamProcessorDataSharingPreference();
            System.Boolean? requestDataSharingPreference_dataSharingPreference_OptIn = null;
            if (cmdletContext.DataSharingPreference_OptIn != null)
            {
                requestDataSharingPreference_dataSharingPreference_OptIn = cmdletContext.DataSharingPreference_OptIn.Value;
            }
            if (requestDataSharingPreference_dataSharingPreference_OptIn != null)
            {
                request.DataSharingPreference.OptIn = requestDataSharingPreference_dataSharingPreference_OptIn.Value;
                requestDataSharingPreferenceIsNull = false;
            }
             // determine if request.DataSharingPreference should be set to null
            if (requestDataSharingPreferenceIsNull)
            {
                request.DataSharingPreference = null;
            }
            
             // populate Input
            request.Input = new Amazon.Rekognition.Model.StreamProcessorInput();
            Amazon.Rekognition.Model.KinesisVideoStream requestInput_input_KinesisVideoStream = null;
            
             // populate KinesisVideoStream
            var requestInput_input_KinesisVideoStreamIsNull = true;
            requestInput_input_KinesisVideoStream = new Amazon.Rekognition.Model.KinesisVideoStream();
            System.String requestInput_input_KinesisVideoStream_kinesisVideoStream_Arn = null;
            if (cmdletContext.KinesisVideoStream_Arn != null)
            {
                requestInput_input_KinesisVideoStream_kinesisVideoStream_Arn = cmdletContext.KinesisVideoStream_Arn;
            }
            if (requestInput_input_KinesisVideoStream_kinesisVideoStream_Arn != null)
            {
                requestInput_input_KinesisVideoStream.Arn = requestInput_input_KinesisVideoStream_kinesisVideoStream_Arn;
                requestInput_input_KinesisVideoStreamIsNull = false;
            }
             // determine if requestInput_input_KinesisVideoStream should be set to null
            if (requestInput_input_KinesisVideoStreamIsNull)
            {
                requestInput_input_KinesisVideoStream = null;
            }
            if (requestInput_input_KinesisVideoStream != null)
            {
                request.Input.KinesisVideoStream = requestInput_input_KinesisVideoStream;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NotificationChannel
            var requestNotificationChannelIsNull = true;
            request.NotificationChannel = new Amazon.Rekognition.Model.StreamProcessorNotificationChannel();
            System.String requestNotificationChannel_notificationChannel_SNSTopicArn = null;
            if (cmdletContext.NotificationChannel_SNSTopicArn != null)
            {
                requestNotificationChannel_notificationChannel_SNSTopicArn = cmdletContext.NotificationChannel_SNSTopicArn;
            }
            if (requestNotificationChannel_notificationChannel_SNSTopicArn != null)
            {
                request.NotificationChannel.SNSTopicArn = requestNotificationChannel_notificationChannel_SNSTopicArn;
                requestNotificationChannelIsNull = false;
            }
             // determine if request.NotificationChannel should be set to null
            if (requestNotificationChannelIsNull)
            {
                request.NotificationChannel = null;
            }
            
             // populate Output
            request.Output = new Amazon.Rekognition.Model.StreamProcessorOutput();
            Amazon.Rekognition.Model.KinesisDataStream requestOutput_output_KinesisDataStream = null;
            
             // populate KinesisDataStream
            var requestOutput_output_KinesisDataStreamIsNull = true;
            requestOutput_output_KinesisDataStream = new Amazon.Rekognition.Model.KinesisDataStream();
            System.String requestOutput_output_KinesisDataStream_kinesisDataStream_Arn = null;
            if (cmdletContext.KinesisDataStream_Arn != null)
            {
                requestOutput_output_KinesisDataStream_kinesisDataStream_Arn = cmdletContext.KinesisDataStream_Arn;
            }
            if (requestOutput_output_KinesisDataStream_kinesisDataStream_Arn != null)
            {
                requestOutput_output_KinesisDataStream.Arn = requestOutput_output_KinesisDataStream_kinesisDataStream_Arn;
                requestOutput_output_KinesisDataStreamIsNull = false;
            }
             // determine if requestOutput_output_KinesisDataStream should be set to null
            if (requestOutput_output_KinesisDataStreamIsNull)
            {
                requestOutput_output_KinesisDataStream = null;
            }
            if (requestOutput_output_KinesisDataStream != null)
            {
                request.Output.KinesisDataStream = requestOutput_output_KinesisDataStream;
            }
            Amazon.Rekognition.Model.S3Destination requestOutput_output_S3Destination = null;
            
             // populate S3Destination
            var requestOutput_output_S3DestinationIsNull = true;
            requestOutput_output_S3Destination = new Amazon.Rekognition.Model.S3Destination();
            System.String requestOutput_output_S3Destination_s3Destination_Bucket = null;
            if (cmdletContext.S3Destination_Bucket != null)
            {
                requestOutput_output_S3Destination_s3Destination_Bucket = cmdletContext.S3Destination_Bucket;
            }
            if (requestOutput_output_S3Destination_s3Destination_Bucket != null)
            {
                requestOutput_output_S3Destination.Bucket = requestOutput_output_S3Destination_s3Destination_Bucket;
                requestOutput_output_S3DestinationIsNull = false;
            }
            System.String requestOutput_output_S3Destination_s3Destination_KeyPrefix = null;
            if (cmdletContext.S3Destination_KeyPrefix != null)
            {
                requestOutput_output_S3Destination_s3Destination_KeyPrefix = cmdletContext.S3Destination_KeyPrefix;
            }
            if (requestOutput_output_S3Destination_s3Destination_KeyPrefix != null)
            {
                requestOutput_output_S3Destination.KeyPrefix = requestOutput_output_S3Destination_s3Destination_KeyPrefix;
                requestOutput_output_S3DestinationIsNull = false;
            }
             // determine if requestOutput_output_S3Destination should be set to null
            if (requestOutput_output_S3DestinationIsNull)
            {
                requestOutput_output_S3Destination = null;
            }
            if (requestOutput_output_S3Destination != null)
            {
                request.Output.S3Destination = requestOutput_output_S3Destination;
            }
            if (cmdletContext.RegionsOfInterest != null)
            {
                request.RegionsOfInterest = cmdletContext.RegionsOfInterest;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate Settings
            request.Settings = new Amazon.Rekognition.Model.StreamProcessorSettings();
            Amazon.Rekognition.Model.ConnectedHomeSettings requestSettings_settings_ConnectedHome = null;
            
             // populate ConnectedHome
            var requestSettings_settings_ConnectedHomeIsNull = true;
            requestSettings_settings_ConnectedHome = new Amazon.Rekognition.Model.ConnectedHomeSettings();
            List<System.String> requestSettings_settings_ConnectedHome_connectedHome_Label = null;
            if (cmdletContext.ConnectedHome_Label != null)
            {
                requestSettings_settings_ConnectedHome_connectedHome_Label = cmdletContext.ConnectedHome_Label;
            }
            if (requestSettings_settings_ConnectedHome_connectedHome_Label != null)
            {
                requestSettings_settings_ConnectedHome.Labels = requestSettings_settings_ConnectedHome_connectedHome_Label;
                requestSettings_settings_ConnectedHomeIsNull = false;
            }
            System.Single? requestSettings_settings_ConnectedHome_connectedHome_MinConfidence = null;
            if (cmdletContext.ConnectedHome_MinConfidence != null)
            {
                requestSettings_settings_ConnectedHome_connectedHome_MinConfidence = cmdletContext.ConnectedHome_MinConfidence.Value;
            }
            if (requestSettings_settings_ConnectedHome_connectedHome_MinConfidence != null)
            {
                requestSettings_settings_ConnectedHome.MinConfidence = requestSettings_settings_ConnectedHome_connectedHome_MinConfidence.Value;
                requestSettings_settings_ConnectedHomeIsNull = false;
            }
             // determine if requestSettings_settings_ConnectedHome should be set to null
            if (requestSettings_settings_ConnectedHomeIsNull)
            {
                requestSettings_settings_ConnectedHome = null;
            }
            if (requestSettings_settings_ConnectedHome != null)
            {
                request.Settings.ConnectedHome = requestSettings_settings_ConnectedHome;
            }
            Amazon.Rekognition.Model.FaceSearchSettings requestSettings_settings_FaceSearch = null;
            
             // populate FaceSearch
            var requestSettings_settings_FaceSearchIsNull = true;
            requestSettings_settings_FaceSearch = new Amazon.Rekognition.Model.FaceSearchSettings();
            System.String requestSettings_settings_FaceSearch_faceSearch_CollectionId = null;
            if (cmdletContext.FaceSearch_CollectionId != null)
            {
                requestSettings_settings_FaceSearch_faceSearch_CollectionId = cmdletContext.FaceSearch_CollectionId;
            }
            if (requestSettings_settings_FaceSearch_faceSearch_CollectionId != null)
            {
                requestSettings_settings_FaceSearch.CollectionId = requestSettings_settings_FaceSearch_faceSearch_CollectionId;
                requestSettings_settings_FaceSearchIsNull = false;
            }
            System.Single? requestSettings_settings_FaceSearch_faceSearch_FaceMatchThreshold = null;
            if (cmdletContext.FaceSearch_FaceMatchThreshold != null)
            {
                requestSettings_settings_FaceSearch_faceSearch_FaceMatchThreshold = cmdletContext.FaceSearch_FaceMatchThreshold.Value;
            }
            if (requestSettings_settings_FaceSearch_faceSearch_FaceMatchThreshold != null)
            {
                requestSettings_settings_FaceSearch.FaceMatchThreshold = requestSettings_settings_FaceSearch_faceSearch_FaceMatchThreshold.Value;
                requestSettings_settings_FaceSearchIsNull = false;
            }
             // determine if requestSettings_settings_FaceSearch should be set to null
            if (requestSettings_settings_FaceSearchIsNull)
            {
                requestSettings_settings_FaceSearch = null;
            }
            if (requestSettings_settings_FaceSearch != null)
            {
                request.Settings.FaceSearch = requestSettings_settings_FaceSearch;
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
        
        private Amazon.Rekognition.Model.CreateStreamProcessorResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.CreateStreamProcessorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "CreateStreamProcessor");
            try
            {
                #if DESKTOP
                return client.CreateStreamProcessor(request);
                #elif CORECLR
                return client.CreateStreamProcessorAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DataSharingPreference_OptIn { get; set; }
            public System.String KinesisVideoStream_Arn { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public System.String NotificationChannel_SNSTopicArn { get; set; }
            public System.String KinesisDataStream_Arn { get; set; }
            public System.String S3Destination_Bucket { get; set; }
            public System.String S3Destination_KeyPrefix { get; set; }
            public List<Amazon.Rekognition.Model.RegionOfInterest> RegionsOfInterest { get; set; }
            public System.String RoleArn { get; set; }
            public List<System.String> ConnectedHome_Label { get; set; }
            public System.Single? ConnectedHome_MinConfidence { get; set; }
            public System.String FaceSearch_CollectionId { get; set; }
            public System.Single? FaceSearch_FaceMatchThreshold { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Rekognition.Model.CreateStreamProcessorResponse, NewREKStreamProcessorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamProcessorArn;
        }
        
    }
}
