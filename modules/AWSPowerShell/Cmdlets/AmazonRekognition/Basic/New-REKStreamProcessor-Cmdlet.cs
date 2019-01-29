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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Creates an Amazon Rekognition stream processor that you can use to detect and recognize
    /// faces in a streaming video.
    /// 
    ///  
    /// <para>
    /// Amazon Rekognition Video is a consumer of live video from Amazon Kinesis Video Streams.
    /// Amazon Rekognition Video sends analysis results to Amazon Kinesis Data Streams.
    /// </para><para>
    /// You provide as input a Kinesis video stream (<code>Input</code>) and a Kinesis data
    /// stream (<code>Output</code>) stream. You also specify the face recognition criteria
    /// in <code>Settings</code>. For example, the collection containing faces that you want
    /// to recognize. Use <code>Name</code> to assign an identifier for the stream processor.
    /// You use <code>Name</code> to manage the stream processor. For example, you can start
    /// processing the source video by calling <a>StartStreamProcessor</a> with the <code>Name</code>
    /// field. 
    /// </para><para>
    /// After you have finished analyzing a streaming video, use <a>StopStreamProcessor</a>
    /// to stop processing. You can delete the stream processor by calling <a>DeleteStreamProcessor</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "REKStreamProcessor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition CreateStreamProcessor API operation.", Operation = new[] {"CreateStreamProcessor"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.Rekognition.Model.CreateStreamProcessorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewREKStreamProcessorCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter KinesisVideoStream_Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the Kinesis video stream stream that streams the source video.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Input_KinesisVideoStream_Arn")]
        public System.String KinesisVideoStream_Arn { get; set; }
        #endregion
        
        #region Parameter KinesisDataStream_Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the output Amazon Kinesis Data Streams stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Output_KinesisDataStream_Arn")]
        public System.String KinesisDataStream_Arn { get; set; }
        #endregion
        
        #region Parameter FaceSearch_CollectionId
        /// <summary>
        /// <para>
        /// <para>The ID of a collection that contains faces that you want to search for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Settings_FaceSearch_CollectionId")]
        public System.String FaceSearch_CollectionId { get; set; }
        #endregion
        
        #region Parameter FaceSearch_FaceMatchThreshold
        /// <summary>
        /// <para>
        /// <para>Minimum face match confidence score that must be met to return a result for a recognized
        /// face. Default is 70. 0 is the lowest confidence. 100 is the highest confidence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Settings_FaceSearch_FaceMatchThreshold")]
        public System.Single FaceSearch_FaceMatchThreshold { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>An identifier you assign to the stream processor. You can use <code>Name</code> to
        /// manage the stream processor. For example, you can get the current status of the stream
        /// processor by calling <a>DescribeStreamProcessor</a>. <code>Name</code> is idempotent.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>ARN of the IAM role that allows access to the stream processor.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-REKStreamProcessor (CreateStreamProcessor)"))
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
            
            context.Input_KinesisVideoStream_Arn = this.KinesisVideoStream_Arn;
            context.Name = this.Name;
            context.Output_KinesisDataStream_Arn = this.KinesisDataStream_Arn;
            context.RoleArn = this.RoleArn;
            context.Settings_FaceSearch_CollectionId = this.FaceSearch_CollectionId;
            if (ParameterWasBound("FaceSearch_FaceMatchThreshold"))
                context.Settings_FaceSearch_FaceMatchThreshold = this.FaceSearch_FaceMatchThreshold;
            
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
            
            
             // populate Input
            bool requestInputIsNull = true;
            request.Input = new Amazon.Rekognition.Model.StreamProcessorInput();
            Amazon.Rekognition.Model.KinesisVideoStream requestInput_input_KinesisVideoStream = null;
            
             // populate KinesisVideoStream
            bool requestInput_input_KinesisVideoStreamIsNull = true;
            requestInput_input_KinesisVideoStream = new Amazon.Rekognition.Model.KinesisVideoStream();
            System.String requestInput_input_KinesisVideoStream_kinesisVideoStream_Arn = null;
            if (cmdletContext.Input_KinesisVideoStream_Arn != null)
            {
                requestInput_input_KinesisVideoStream_kinesisVideoStream_Arn = cmdletContext.Input_KinesisVideoStream_Arn;
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
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Output
            bool requestOutputIsNull = true;
            request.Output = new Amazon.Rekognition.Model.StreamProcessorOutput();
            Amazon.Rekognition.Model.KinesisDataStream requestOutput_output_KinesisDataStream = null;
            
             // populate KinesisDataStream
            bool requestOutput_output_KinesisDataStreamIsNull = true;
            requestOutput_output_KinesisDataStream = new Amazon.Rekognition.Model.KinesisDataStream();
            System.String requestOutput_output_KinesisDataStream_kinesisDataStream_Arn = null;
            if (cmdletContext.Output_KinesisDataStream_Arn != null)
            {
                requestOutput_output_KinesisDataStream_kinesisDataStream_Arn = cmdletContext.Output_KinesisDataStream_Arn;
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
                requestOutputIsNull = false;
            }
             // determine if request.Output should be set to null
            if (requestOutputIsNull)
            {
                request.Output = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate Settings
            bool requestSettingsIsNull = true;
            request.Settings = new Amazon.Rekognition.Model.StreamProcessorSettings();
            Amazon.Rekognition.Model.FaceSearchSettings requestSettings_settings_FaceSearch = null;
            
             // populate FaceSearch
            bool requestSettings_settings_FaceSearchIsNull = true;
            requestSettings_settings_FaceSearch = new Amazon.Rekognition.Model.FaceSearchSettings();
            System.String requestSettings_settings_FaceSearch_faceSearch_CollectionId = null;
            if (cmdletContext.Settings_FaceSearch_CollectionId != null)
            {
                requestSettings_settings_FaceSearch_faceSearch_CollectionId = cmdletContext.Settings_FaceSearch_CollectionId;
            }
            if (requestSettings_settings_FaceSearch_faceSearch_CollectionId != null)
            {
                requestSettings_settings_FaceSearch.CollectionId = requestSettings_settings_FaceSearch_faceSearch_CollectionId;
                requestSettings_settings_FaceSearchIsNull = false;
            }
            System.Single? requestSettings_settings_FaceSearch_faceSearch_FaceMatchThreshold = null;
            if (cmdletContext.Settings_FaceSearch_FaceMatchThreshold != null)
            {
                requestSettings_settings_FaceSearch_faceSearch_FaceMatchThreshold = cmdletContext.Settings_FaceSearch_FaceMatchThreshold.Value;
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
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StreamProcessorArn;
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
        
        private Amazon.Rekognition.Model.CreateStreamProcessorResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.CreateStreamProcessorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "CreateStreamProcessor");
            try
            {
                #if DESKTOP
                return client.CreateStreamProcessor(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateStreamProcessorAsync(request);
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
            public System.String Input_KinesisVideoStream_Arn { get; set; }
            public System.String Name { get; set; }
            public System.String Output_KinesisDataStream_Arn { get; set; }
            public System.String RoleArn { get; set; }
            public System.String Settings_FaceSearch_CollectionId { get; set; }
            public System.Single? Settings_FaceSearch_FaceMatchThreshold { get; set; }
        }
        
    }
}
