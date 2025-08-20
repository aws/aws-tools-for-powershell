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
    /// Initiates a new media analysis job. Accepts a manifest file in an Amazon S3 bucket.
    /// The output is a manifest file and a summary of the manifest stored in the Amazon S3
    /// bucket.
    /// </summary>
    [Cmdlet("Start", "REKMediaAnalysisJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition StartMediaAnalysisJob API operation.", Operation = new[] {"StartMediaAnalysisJob"}, SelectReturnType = typeof(Amazon.Rekognition.Model.StartMediaAnalysisJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.StartMediaAnalysisJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.StartMediaAnalysisJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartREKMediaAnalysisJobCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Idempotency token used to prevent the accidental creation of duplicate versions. If
        /// you use the same token with multiple <c>StartMediaAnalysisJobRequest</c> requests,
        /// the same response is returned. Use <c>ClientRequestToken</c> to prevent the same request
        /// from being processed more than once.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the job. Does not have to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of customer managed AWS KMS key (name or ARN). The key is used to encrypt
        /// images copied into the service. The key is also used to encrypt results and manifest
        /// files written to the output Amazon S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter DetectModerationLabels_MinConfidence
        /// <summary>
        /// <para>
        /// <para>Specifies the minimum confidence level for the moderation labels to return. Amazon
        /// Rekognition doesn't return any labels with a confidence level lower than this specified
        /// value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationsConfig_DetectModerationLabels_MinConfidence")]
        public System.Single? DetectModerationLabels_MinConfidence { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
        #endregion
        
        #region Parameter DetectModerationLabels_ProjectVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the custom moderation model to be used during the label detection job. If
        /// not provided the pre-trained model is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OperationsConfig_DetectModerationLabels_ProjectVersion")]
        public System.String DetectModerationLabels_ProjectVersion { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Bucket
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 bucket to contain the output of the media analysis job.</para>
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
        public System.String OutputConfig_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon S3 key prefix that comes after the name of the bucket you have
        /// designated for storage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputConfig_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter S3Object_Version
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Input_S3Object_Version")]
        public System.String S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.StartMediaAnalysisJobResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.StartMediaAnalysisJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-REKMediaAnalysisJob (StartMediaAnalysisJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.StartMediaAnalysisJobResponse, StartREKMediaAnalysisJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Name = this.S3Object_Name;
            context.S3Object_Version = this.S3Object_Version;
            context.JobName = this.JobName;
            context.KmsKeyId = this.KmsKeyId;
            context.DetectModerationLabels_MinConfidence = this.DetectModerationLabels_MinConfidence;
            context.DetectModerationLabels_ProjectVersion = this.DetectModerationLabels_ProjectVersion;
            context.OutputConfig_S3Bucket = this.OutputConfig_S3Bucket;
            #if MODULAR
            if (this.OutputConfig_S3Bucket == null && ParameterWasBound(nameof(this.OutputConfig_S3Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputConfig_S3Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputConfig_S3KeyPrefix = this.OutputConfig_S3KeyPrefix;
            
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
            var request = new Amazon.Rekognition.Model.StartMediaAnalysisJobRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate Input
            var requestInputIsNull = true;
            request.Input = new Amazon.Rekognition.Model.MediaAnalysisInput();
            Amazon.Rekognition.Model.S3Object requestInput_input_S3Object = null;
            
             // populate S3Object
            requestInput_input_S3Object = new Amazon.Rekognition.Model.S3Object();
            System.String requestInput_input_S3Object_s3Object_Bucket = null;
            if (cmdletContext.S3Object_Bucket != null)
            {
                requestInput_input_S3Object_s3Object_Bucket = cmdletContext.S3Object_Bucket;
            }
            if (requestInput_input_S3Object_s3Object_Bucket != null)
            {
                requestInput_input_S3Object.Bucket = requestInput_input_S3Object_s3Object_Bucket;
            }
            System.String requestInput_input_S3Object_s3Object_Name = null;
            if (cmdletContext.S3Object_Name != null)
            {
                requestInput_input_S3Object_s3Object_Name = cmdletContext.S3Object_Name;
            }
            if (requestInput_input_S3Object_s3Object_Name != null)
            {
                requestInput_input_S3Object.Name = requestInput_input_S3Object_s3Object_Name;
            }
            System.String requestInput_input_S3Object_s3Object_Version = null;
            if (cmdletContext.S3Object_Version != null)
            {
                requestInput_input_S3Object_s3Object_Version = cmdletContext.S3Object_Version;
            }
            if (requestInput_input_S3Object_s3Object_Version != null)
            {
                requestInput_input_S3Object.Version = requestInput_input_S3Object_s3Object_Version;
            }
            if (requestInput_input_S3Object != null)
            {
                request.Input.S3Object = requestInput_input_S3Object;
                requestInputIsNull = false;
            }
             // determine if request.Input should be set to null
            if (requestInputIsNull)
            {
                request.Input = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate OperationsConfig
            request.OperationsConfig = new Amazon.Rekognition.Model.MediaAnalysisOperationsConfig();
            Amazon.Rekognition.Model.MediaAnalysisDetectModerationLabelsConfig requestOperationsConfig_operationsConfig_DetectModerationLabels = null;
            
             // populate DetectModerationLabels
            var requestOperationsConfig_operationsConfig_DetectModerationLabelsIsNull = true;
            requestOperationsConfig_operationsConfig_DetectModerationLabels = new Amazon.Rekognition.Model.MediaAnalysisDetectModerationLabelsConfig();
            System.Single? requestOperationsConfig_operationsConfig_DetectModerationLabels_detectModerationLabels_MinConfidence = null;
            if (cmdletContext.DetectModerationLabels_MinConfidence != null)
            {
                requestOperationsConfig_operationsConfig_DetectModerationLabels_detectModerationLabels_MinConfidence = cmdletContext.DetectModerationLabels_MinConfidence.Value;
            }
            if (requestOperationsConfig_operationsConfig_DetectModerationLabels_detectModerationLabels_MinConfidence != null)
            {
                requestOperationsConfig_operationsConfig_DetectModerationLabels.MinConfidence = requestOperationsConfig_operationsConfig_DetectModerationLabels_detectModerationLabels_MinConfidence.Value;
                requestOperationsConfig_operationsConfig_DetectModerationLabelsIsNull = false;
            }
            System.String requestOperationsConfig_operationsConfig_DetectModerationLabels_detectModerationLabels_ProjectVersion = null;
            if (cmdletContext.DetectModerationLabels_ProjectVersion != null)
            {
                requestOperationsConfig_operationsConfig_DetectModerationLabels_detectModerationLabels_ProjectVersion = cmdletContext.DetectModerationLabels_ProjectVersion;
            }
            if (requestOperationsConfig_operationsConfig_DetectModerationLabels_detectModerationLabels_ProjectVersion != null)
            {
                requestOperationsConfig_operationsConfig_DetectModerationLabels.ProjectVersion = requestOperationsConfig_operationsConfig_DetectModerationLabels_detectModerationLabels_ProjectVersion;
                requestOperationsConfig_operationsConfig_DetectModerationLabelsIsNull = false;
            }
             // determine if requestOperationsConfig_operationsConfig_DetectModerationLabels should be set to null
            if (requestOperationsConfig_operationsConfig_DetectModerationLabelsIsNull)
            {
                requestOperationsConfig_operationsConfig_DetectModerationLabels = null;
            }
            if (requestOperationsConfig_operationsConfig_DetectModerationLabels != null)
            {
                request.OperationsConfig.DetectModerationLabels = requestOperationsConfig_operationsConfig_DetectModerationLabels;
            }
            
             // populate OutputConfig
            var requestOutputConfigIsNull = true;
            request.OutputConfig = new Amazon.Rekognition.Model.MediaAnalysisOutputConfig();
            System.String requestOutputConfig_outputConfig_S3Bucket = null;
            if (cmdletContext.OutputConfig_S3Bucket != null)
            {
                requestOutputConfig_outputConfig_S3Bucket = cmdletContext.OutputConfig_S3Bucket;
            }
            if (requestOutputConfig_outputConfig_S3Bucket != null)
            {
                request.OutputConfig.S3Bucket = requestOutputConfig_outputConfig_S3Bucket;
                requestOutputConfigIsNull = false;
            }
            System.String requestOutputConfig_outputConfig_S3KeyPrefix = null;
            if (cmdletContext.OutputConfig_S3KeyPrefix != null)
            {
                requestOutputConfig_outputConfig_S3KeyPrefix = cmdletContext.OutputConfig_S3KeyPrefix;
            }
            if (requestOutputConfig_outputConfig_S3KeyPrefix != null)
            {
                request.OutputConfig.S3KeyPrefix = requestOutputConfig_outputConfig_S3KeyPrefix;
                requestOutputConfigIsNull = false;
            }
             // determine if request.OutputConfig should be set to null
            if (requestOutputConfigIsNull)
            {
                request.OutputConfig = null;
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
        
        private Amazon.Rekognition.Model.StartMediaAnalysisJobResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.StartMediaAnalysisJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "StartMediaAnalysisJob");
            try
            {
                #if DESKTOP
                return client.StartMediaAnalysisJob(request);
                #elif CORECLR
                return client.StartMediaAnalysisJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public System.String JobName { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.Single? DetectModerationLabels_MinConfidence { get; set; }
            public System.String DetectModerationLabels_ProjectVersion { get; set; }
            public System.String OutputConfig_S3Bucket { get; set; }
            public System.String OutputConfig_S3KeyPrefix { get; set; }
            public System.Func<Amazon.Rekognition.Model.StartMediaAnalysisJobResponse, StartREKMediaAnalysisJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobId;
        }
        
    }
}
