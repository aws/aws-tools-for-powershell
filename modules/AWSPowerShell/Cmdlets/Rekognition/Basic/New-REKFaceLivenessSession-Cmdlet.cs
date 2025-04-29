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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// This API operation initiates a Face Liveness session. It returns a <c>SessionId</c>,
    /// which you can use to start streaming Face Liveness video and get the results for a
    /// Face Liveness session. 
    /// 
    ///  
    /// <para>
    /// You can use the <c>OutputConfig</c> option in the Settings parameter to provide an
    /// Amazon S3 bucket location. The Amazon S3 bucket stores reference images and audit
    /// images. If no Amazon S3 bucket is defined, raw bytes are sent instead. 
    /// </para><para>
    /// You can use <c>AuditImagesLimit</c> to limit the number of audit images returned when
    /// <c>GetFaceLivenessSessionResults</c> is called. This number is between 0 and 4. By
    /// default, it is set to 0. The limit is best effort and based on the duration of the
    /// selfie-video. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "REKFaceLivenessSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition CreateFaceLivenessSession API operation.", Operation = new[] {"CreateFaceLivenessSession"}, SelectReturnType = typeof(Amazon.Rekognition.Model.CreateFaceLivenessSessionResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.CreateFaceLivenessSessionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.CreateFaceLivenessSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewREKFaceLivenessSessionCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Settings_AuditImagesLimit
        /// <summary>
        /// <para>
        /// <para>Number of audit images to be returned back. Takes an integer between 0-4. Any integer
        /// less than 0 will return 0, any integer above 4 will return 4 images in the response.
        /// By default, it is set to 0. The limit is best effort and is based on the actual duration
        /// of the selfie-video.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Settings_AuditImagesLimit { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>Idempotent token is used to recognize the Face Liveness request. If the same token
        /// is used with multiple <c>CreateFaceLivenessSession</c> requests, the same session
        /// is returned. This token is employed to avoid unintentionally creating the same session
        /// multiple times.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para> The identifier for your AWS Key Management Service key (AWS KMS key). Used to encrypt
        /// audit images and reference images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The path to an AWS Amazon S3 bucket used to store Face Liveness session results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OutputConfig_S3Bucket")]
        public System.String OutputConfig_S3Bucket { get; set; }
        #endregion
        
        #region Parameter OutputConfig_S3KeyPrefix
        /// <summary>
        /// <para>
        /// <para>The prefix prepended to the output files for the Face Liveness session results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Settings_OutputConfig_S3KeyPrefix")]
        public System.String OutputConfig_S3KeyPrefix { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SessionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.CreateFaceLivenessSessionResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.CreateFaceLivenessSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SessionId";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.KmsKeyId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-REKFaceLivenessSession (CreateFaceLivenessSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.CreateFaceLivenessSessionResponse, NewREKFaceLivenessSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.KmsKeyId = this.KmsKeyId;
            context.Settings_AuditImagesLimit = this.Settings_AuditImagesLimit;
            context.OutputConfig_S3Bucket = this.OutputConfig_S3Bucket;
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
            var request = new Amazon.Rekognition.Model.CreateFaceLivenessSessionRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            
             // populate Settings
            var requestSettingsIsNull = true;
            request.Settings = new Amazon.Rekognition.Model.CreateFaceLivenessSessionRequestSettings();
            System.Int32? requestSettings_settings_AuditImagesLimit = null;
            if (cmdletContext.Settings_AuditImagesLimit != null)
            {
                requestSettings_settings_AuditImagesLimit = cmdletContext.Settings_AuditImagesLimit.Value;
            }
            if (requestSettings_settings_AuditImagesLimit != null)
            {
                request.Settings.AuditImagesLimit = requestSettings_settings_AuditImagesLimit.Value;
                requestSettingsIsNull = false;
            }
            Amazon.Rekognition.Model.LivenessOutputConfig requestSettings_settings_OutputConfig = null;
            
             // populate OutputConfig
            var requestSettings_settings_OutputConfigIsNull = true;
            requestSettings_settings_OutputConfig = new Amazon.Rekognition.Model.LivenessOutputConfig();
            System.String requestSettings_settings_OutputConfig_outputConfig_S3Bucket = null;
            if (cmdletContext.OutputConfig_S3Bucket != null)
            {
                requestSettings_settings_OutputConfig_outputConfig_S3Bucket = cmdletContext.OutputConfig_S3Bucket;
            }
            if (requestSettings_settings_OutputConfig_outputConfig_S3Bucket != null)
            {
                requestSettings_settings_OutputConfig.S3Bucket = requestSettings_settings_OutputConfig_outputConfig_S3Bucket;
                requestSettings_settings_OutputConfigIsNull = false;
            }
            System.String requestSettings_settings_OutputConfig_outputConfig_S3KeyPrefix = null;
            if (cmdletContext.OutputConfig_S3KeyPrefix != null)
            {
                requestSettings_settings_OutputConfig_outputConfig_S3KeyPrefix = cmdletContext.OutputConfig_S3KeyPrefix;
            }
            if (requestSettings_settings_OutputConfig_outputConfig_S3KeyPrefix != null)
            {
                requestSettings_settings_OutputConfig.S3KeyPrefix = requestSettings_settings_OutputConfig_outputConfig_S3KeyPrefix;
                requestSettings_settings_OutputConfigIsNull = false;
            }
             // determine if requestSettings_settings_OutputConfig should be set to null
            if (requestSettings_settings_OutputConfigIsNull)
            {
                requestSettings_settings_OutputConfig = null;
            }
            if (requestSettings_settings_OutputConfig != null)
            {
                request.Settings.OutputConfig = requestSettings_settings_OutputConfig;
                requestSettingsIsNull = false;
            }
             // determine if request.Settings should be set to null
            if (requestSettingsIsNull)
            {
                request.Settings = null;
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
        
        private Amazon.Rekognition.Model.CreateFaceLivenessSessionResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.CreateFaceLivenessSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "CreateFaceLivenessSession");
            try
            {
                return client.CreateFaceLivenessSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String KmsKeyId { get; set; }
            public System.Int32? Settings_AuditImagesLimit { get; set; }
            public System.String OutputConfig_S3Bucket { get; set; }
            public System.String OutputConfig_S3KeyPrefix { get; set; }
            public System.Func<Amazon.Rekognition.Model.CreateFaceLivenessSessionResponse, NewREKFaceLivenessSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SessionId;
        }
        
    }
}
