/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.VoiceID;
using Amazon.VoiceID.Model;

namespace Amazon.PowerShell.Cmdlets.VID
{
    /// <summary>
    /// Starts a new batch speaker enrollment job using specified details.
    /// </summary>
    [Cmdlet("Start", "VIDSpeakerEnrollmentJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VoiceID.Model.SpeakerEnrollmentJob")]
    [AWSCmdlet("Calls the Amazon Voice ID StartSpeakerEnrollmentJob API operation.", Operation = new[] {"StartSpeakerEnrollmentJob"}, SelectReturnType = typeof(Amazon.VoiceID.Model.StartSpeakerEnrollmentJobResponse))]
    [AWSCmdletOutput("Amazon.VoiceID.Model.SpeakerEnrollmentJob or Amazon.VoiceID.Model.StartSpeakerEnrollmentJobResponse",
        "This cmdlet returns an Amazon.VoiceID.Model.SpeakerEnrollmentJob object.",
        "The service call response (type Amazon.VoiceID.Model.StartSpeakerEnrollmentJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartVIDSpeakerEnrollmentJobCmdlet : AmazonVoiceIDClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role Amazon Resource Name (ARN) that grants Voice ID permissions to access
        /// customer's buckets to read the input manifest file and write the job output file.
        /// Refer to <a href="https://docs.aws.amazon.com/connect/latest/adminguide/voiceid-batch-enrollment.html">Batch
        /// enrollment using audio data from prior calls</a> for the permissions needed in this
        /// role.</para>
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
        public System.String DataAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The identifier of the domain that contains the speaker enrollment job and in which
        /// the speakers are enrolled. </para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter EnrollmentConfig_ExistingEnrollmentAction
        /// <summary>
        /// <para>
        /// <para> The action to take when the specified speaker is already enrolled in the specified
        /// domain. The default value is <code>SKIP</code>, which skips the enrollment for the
        /// existing speaker. Setting the value to <code>OVERWRITE</code> replaces the existing
        /// voice prints and enrollment audio stored for that speaker with new data generated
        /// from the latest audio.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VoiceID.ExistingEnrollmentAction")]
        public Amazon.VoiceID.ExistingEnrollmentAction EnrollmentConfig_ExistingEnrollmentAction { get; set; }
        #endregion
        
        #region Parameter FraudDetectionConfig_FraudDetectionAction
        /// <summary>
        /// <para>
        /// <para>The action to take when the given speaker is flagged by the fraud detection system.
        /// The default value is <code>FAIL</code>, which fails the speaker enrollment. Changing
        /// this value to <code>IGNORE</code> results in the speaker being enrolled even if they
        /// are flagged by the fraud detection system.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnrollmentConfig_FraudDetectionConfig_FraudDetectionAction")]
        [AWSConstantClassSource("Amazon.VoiceID.FraudDetectionAction")]
        public Amazon.VoiceID.FraudDetectionAction FraudDetectionConfig_FraudDetectionAction { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>A name for your speaker enrollment job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS key you want Voice ID to use to encrypt the output file
        /// of a speaker enrollment job/fraudster registration job. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter FraudDetectionConfig_RiskThreshold
        /// <summary>
        /// <para>
        /// <para>Threshold value for determining whether the speaker is a high risk to be fraudulent.
        /// If the detected risk score calculated by Voice ID is greater than or equal to the
        /// threshold, the speaker is considered a fraudster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnrollmentConfig_FraudDetectionConfig_RiskThreshold")]
        public System.Int32? FraudDetectionConfig_RiskThreshold { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 location for the input manifest file that contains the list of individual enrollment
        /// or registration job requests.</para>
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
        public System.String InputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The S3 path of the folder where Voice ID writes the job output file. It has a <code>*.out</code>
        /// extension. For example, if the input file name is <code>input-file.json</code> and
        /// the output folder path is <code>s3://output-bucket/output-folder</code>, the full
        /// output file path is <code>s3://output-bucket/output-folder/job-Id/input-file.json.out</code>.</para>
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
        public System.String OutputDataConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter FraudDetectionConfig_WatchlistId
        /// <summary>
        /// <para>
        /// <para>The identifier of watchlists against which fraud detection is performed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnrollmentConfig_FraudDetectionConfig_WatchlistIds")]
        public System.String[] FraudDetectionConfig_WatchlistId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Job'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VoiceID.Model.StartSpeakerEnrollmentJobResponse).
        /// Specifying the name of a property of type Amazon.VoiceID.Model.StartSpeakerEnrollmentJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Job";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DomainId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DomainId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-VIDSpeakerEnrollmentJob (StartSpeakerEnrollmentJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VoiceID.Model.StartSpeakerEnrollmentJobResponse, StartVIDSpeakerEnrollmentJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DomainId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.DataAccessRoleArn = this.DataAccessRoleArn;
            #if MODULAR
            if (this.DataAccessRoleArn == null && ParameterWasBound(nameof(this.DataAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DataAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnrollmentConfig_ExistingEnrollmentAction = this.EnrollmentConfig_ExistingEnrollmentAction;
            context.FraudDetectionConfig_FraudDetectionAction = this.FraudDetectionConfig_FraudDetectionAction;
            context.FraudDetectionConfig_RiskThreshold = this.FraudDetectionConfig_RiskThreshold;
            if (this.FraudDetectionConfig_WatchlistId != null)
            {
                context.FraudDetectionConfig_WatchlistId = new List<System.String>(this.FraudDetectionConfig_WatchlistId);
            }
            context.InputDataConfig_S3Uri = this.InputDataConfig_S3Uri;
            #if MODULAR
            if (this.InputDataConfig_S3Uri == null && ParameterWasBound(nameof(this.InputDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            context.OutputDataConfig_KmsKeyId = this.OutputDataConfig_KmsKeyId;
            context.OutputDataConfig_S3Uri = this.OutputDataConfig_S3Uri;
            #if MODULAR
            if (this.OutputDataConfig_S3Uri == null && ParameterWasBound(nameof(this.OutputDataConfig_S3Uri)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3Uri which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.VoiceID.Model.StartSpeakerEnrollmentJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataAccessRoleArn != null)
            {
                request.DataAccessRoleArn = cmdletContext.DataAccessRoleArn;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate EnrollmentConfig
            var requestEnrollmentConfigIsNull = true;
            request.EnrollmentConfig = new Amazon.VoiceID.Model.EnrollmentConfig();
            Amazon.VoiceID.ExistingEnrollmentAction requestEnrollmentConfig_enrollmentConfig_ExistingEnrollmentAction = null;
            if (cmdletContext.EnrollmentConfig_ExistingEnrollmentAction != null)
            {
                requestEnrollmentConfig_enrollmentConfig_ExistingEnrollmentAction = cmdletContext.EnrollmentConfig_ExistingEnrollmentAction;
            }
            if (requestEnrollmentConfig_enrollmentConfig_ExistingEnrollmentAction != null)
            {
                request.EnrollmentConfig.ExistingEnrollmentAction = requestEnrollmentConfig_enrollmentConfig_ExistingEnrollmentAction;
                requestEnrollmentConfigIsNull = false;
            }
            Amazon.VoiceID.Model.EnrollmentJobFraudDetectionConfig requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig = null;
            
             // populate FraudDetectionConfig
            var requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfigIsNull = true;
            requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig = new Amazon.VoiceID.Model.EnrollmentJobFraudDetectionConfig();
            Amazon.VoiceID.FraudDetectionAction requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_FraudDetectionAction = null;
            if (cmdletContext.FraudDetectionConfig_FraudDetectionAction != null)
            {
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_FraudDetectionAction = cmdletContext.FraudDetectionConfig_FraudDetectionAction;
            }
            if (requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_FraudDetectionAction != null)
            {
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig.FraudDetectionAction = requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_FraudDetectionAction;
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfigIsNull = false;
            }
            System.Int32? requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_RiskThreshold = null;
            if (cmdletContext.FraudDetectionConfig_RiskThreshold != null)
            {
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_RiskThreshold = cmdletContext.FraudDetectionConfig_RiskThreshold.Value;
            }
            if (requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_RiskThreshold != null)
            {
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig.RiskThreshold = requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_RiskThreshold.Value;
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfigIsNull = false;
            }
            List<System.String> requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_WatchlistId = null;
            if (cmdletContext.FraudDetectionConfig_WatchlistId != null)
            {
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_WatchlistId = cmdletContext.FraudDetectionConfig_WatchlistId;
            }
            if (requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_WatchlistId != null)
            {
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig.WatchlistIds = requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig_fraudDetectionConfig_WatchlistId;
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfigIsNull = false;
            }
             // determine if requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig should be set to null
            if (requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfigIsNull)
            {
                requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig = null;
            }
            if (requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig != null)
            {
                request.EnrollmentConfig.FraudDetectionConfig = requestEnrollmentConfig_enrollmentConfig_FraudDetectionConfig;
                requestEnrollmentConfigIsNull = false;
            }
             // determine if request.EnrollmentConfig should be set to null
            if (requestEnrollmentConfigIsNull)
            {
                request.EnrollmentConfig = null;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.VoiceID.Model.InputDataConfig();
            System.String requestInputDataConfig_inputDataConfig_S3Uri = null;
            if (cmdletContext.InputDataConfig_S3Uri != null)
            {
                requestInputDataConfig_inputDataConfig_S3Uri = cmdletContext.InputDataConfig_S3Uri;
            }
            if (requestInputDataConfig_inputDataConfig_S3Uri != null)
            {
                request.InputDataConfig.S3Uri = requestInputDataConfig_inputDataConfig_S3Uri;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.VoiceID.Model.OutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_KmsKeyId = null;
            if (cmdletContext.OutputDataConfig_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_KmsKeyId = cmdletContext.OutputDataConfig_KmsKeyId;
            }
            if (requestOutputDataConfig_outputDataConfig_KmsKeyId != null)
            {
                request.OutputDataConfig.KmsKeyId = requestOutputDataConfig_outputDataConfig_KmsKeyId;
                requestOutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3Uri = null;
            if (cmdletContext.OutputDataConfig_S3Uri != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Uri = cmdletContext.OutputDataConfig_S3Uri;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Uri != null)
            {
                request.OutputDataConfig.S3Uri = requestOutputDataConfig_outputDataConfig_S3Uri;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
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
        
        private Amazon.VoiceID.Model.StartSpeakerEnrollmentJobResponse CallAWSServiceOperation(IAmazonVoiceID client, Amazon.VoiceID.Model.StartSpeakerEnrollmentJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Voice ID", "StartSpeakerEnrollmentJob");
            try
            {
                #if DESKTOP
                return client.StartSpeakerEnrollmentJob(request);
                #elif CORECLR
                return client.StartSpeakerEnrollmentJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DataAccessRoleArn { get; set; }
            public System.String DomainId { get; set; }
            public Amazon.VoiceID.ExistingEnrollmentAction EnrollmentConfig_ExistingEnrollmentAction { get; set; }
            public Amazon.VoiceID.FraudDetectionAction FraudDetectionConfig_FraudDetectionAction { get; set; }
            public System.Int32? FraudDetectionConfig_RiskThreshold { get; set; }
            public List<System.String> FraudDetectionConfig_WatchlistId { get; set; }
            public System.String InputDataConfig_S3Uri { get; set; }
            public System.String JobName { get; set; }
            public System.String OutputDataConfig_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3Uri { get; set; }
            public System.Func<Amazon.VoiceID.Model.StartSpeakerEnrollmentJobResponse, StartVIDSpeakerEnrollmentJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Job;
        }
        
    }
}
