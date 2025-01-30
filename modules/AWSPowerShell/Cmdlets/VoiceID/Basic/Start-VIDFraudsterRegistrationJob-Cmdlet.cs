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
using Amazon.VoiceID;
using Amazon.VoiceID.Model;

namespace Amazon.PowerShell.Cmdlets.VID
{
    /// <summary>
    /// Starts a new batch fraudster registration job using provided details.
    /// </summary>
    [Cmdlet("Start", "VIDFraudsterRegistrationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.VoiceID.Model.FraudsterRegistrationJob")]
    [AWSCmdlet("Calls the Amazon Voice ID StartFraudsterRegistrationJob API operation.", Operation = new[] {"StartFraudsterRegistrationJob"}, SelectReturnType = typeof(Amazon.VoiceID.Model.StartFraudsterRegistrationJobResponse))]
    [AWSCmdletOutput("Amazon.VoiceID.Model.FraudsterRegistrationJob or Amazon.VoiceID.Model.StartFraudsterRegistrationJobResponse",
        "This cmdlet returns an Amazon.VoiceID.Model.FraudsterRegistrationJob object.",
        "The service call response (type Amazon.VoiceID.Model.StartFraudsterRegistrationJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartVIDFraudsterRegistrationJobCmdlet : AmazonVoiceIDClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role Amazon Resource Name (ARN) that grants Voice ID permissions to access
        /// customer's buckets to read the input manifest file and write the Job output file.
        /// Refer to the <a href="https://docs.aws.amazon.com/connect/latest/adminguide/voiceid-fraudster-watchlist.html">Create
        /// and edit a fraudster watchlist</a> documentation for the permissions needed in this
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
        /// <para>The identifier of the domain that contains the fraudster registration job and in which
        /// the fraudsters are registered.</para>
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
        
        #region Parameter RegistrationConfig_DuplicateRegistrationAction
        /// <summary>
        /// <para>
        /// <para>The action to take when a fraudster is identified as a duplicate. The default action
        /// is <c>SKIP</c>, which skips registering the duplicate fraudster. Setting the value
        /// to <c>REGISTER_AS_NEW</c> always registers a new fraudster into the specified domain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.VoiceID.DuplicateRegistrationAction")]
        public Amazon.VoiceID.DuplicateRegistrationAction RegistrationConfig_DuplicateRegistrationAction { get; set; }
        #endregion
        
        #region Parameter RegistrationConfig_FraudsterSimilarityThreshold
        /// <summary>
        /// <para>
        /// <para>The minimum similarity score between the new and old fraudsters in order to consider
        /// the new fraudster a duplicate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RegistrationConfig_FraudsterSimilarityThreshold { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the new fraudster registration job.</para>
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
        /// <para>The S3 path of the folder where Voice ID writes the job output file. It has a <c>*.out</c>
        /// extension. For example, if the input file name is <c>input-file.json</c> and the output
        /// folder path is <c>s3://output-bucket/output-folder</c>, the full output file path
        /// is <c>s3://output-bucket/output-folder/job-Id/input-file.json.out</c>.</para>
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
        
        #region Parameter RegistrationConfig_WatchlistId
        /// <summary>
        /// <para>
        /// <para>The identifiers of watchlists that a fraudster is registered to. If a watchlist isn't
        /// provided, the fraudsters are registered to the default watchlist. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RegistrationConfig_WatchlistIds")]
        public System.String[] RegistrationConfig_WatchlistId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.VoiceID.Model.StartFraudsterRegistrationJobResponse).
        /// Specifying the name of a property of type Amazon.VoiceID.Model.StartFraudsterRegistrationJobResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-VIDFraudsterRegistrationJob (StartFraudsterRegistrationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.VoiceID.Model.StartFraudsterRegistrationJobResponse, StartVIDFraudsterRegistrationJobCmdlet>(Select) ??
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
            context.RegistrationConfig_DuplicateRegistrationAction = this.RegistrationConfig_DuplicateRegistrationAction;
            context.RegistrationConfig_FraudsterSimilarityThreshold = this.RegistrationConfig_FraudsterSimilarityThreshold;
            if (this.RegistrationConfig_WatchlistId != null)
            {
                context.RegistrationConfig_WatchlistId = new List<System.String>(this.RegistrationConfig_WatchlistId);
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
            var request = new Amazon.VoiceID.Model.StartFraudsterRegistrationJobRequest();
            
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
            
             // populate RegistrationConfig
            var requestRegistrationConfigIsNull = true;
            request.RegistrationConfig = new Amazon.VoiceID.Model.RegistrationConfig();
            Amazon.VoiceID.DuplicateRegistrationAction requestRegistrationConfig_registrationConfig_DuplicateRegistrationAction = null;
            if (cmdletContext.RegistrationConfig_DuplicateRegistrationAction != null)
            {
                requestRegistrationConfig_registrationConfig_DuplicateRegistrationAction = cmdletContext.RegistrationConfig_DuplicateRegistrationAction;
            }
            if (requestRegistrationConfig_registrationConfig_DuplicateRegistrationAction != null)
            {
                request.RegistrationConfig.DuplicateRegistrationAction = requestRegistrationConfig_registrationConfig_DuplicateRegistrationAction;
                requestRegistrationConfigIsNull = false;
            }
            System.Int32? requestRegistrationConfig_registrationConfig_FraudsterSimilarityThreshold = null;
            if (cmdletContext.RegistrationConfig_FraudsterSimilarityThreshold != null)
            {
                requestRegistrationConfig_registrationConfig_FraudsterSimilarityThreshold = cmdletContext.RegistrationConfig_FraudsterSimilarityThreshold.Value;
            }
            if (requestRegistrationConfig_registrationConfig_FraudsterSimilarityThreshold != null)
            {
                request.RegistrationConfig.FraudsterSimilarityThreshold = requestRegistrationConfig_registrationConfig_FraudsterSimilarityThreshold.Value;
                requestRegistrationConfigIsNull = false;
            }
            List<System.String> requestRegistrationConfig_registrationConfig_WatchlistId = null;
            if (cmdletContext.RegistrationConfig_WatchlistId != null)
            {
                requestRegistrationConfig_registrationConfig_WatchlistId = cmdletContext.RegistrationConfig_WatchlistId;
            }
            if (requestRegistrationConfig_registrationConfig_WatchlistId != null)
            {
                request.RegistrationConfig.WatchlistIds = requestRegistrationConfig_registrationConfig_WatchlistId;
                requestRegistrationConfigIsNull = false;
            }
             // determine if request.RegistrationConfig should be set to null
            if (requestRegistrationConfigIsNull)
            {
                request.RegistrationConfig = null;
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
        
        private Amazon.VoiceID.Model.StartFraudsterRegistrationJobResponse CallAWSServiceOperation(IAmazonVoiceID client, Amazon.VoiceID.Model.StartFraudsterRegistrationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Voice ID", "StartFraudsterRegistrationJob");
            try
            {
                #if DESKTOP
                return client.StartFraudsterRegistrationJob(request);
                #elif CORECLR
                return client.StartFraudsterRegistrationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String InputDataConfig_S3Uri { get; set; }
            public System.String JobName { get; set; }
            public System.String OutputDataConfig_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3Uri { get; set; }
            public Amazon.VoiceID.DuplicateRegistrationAction RegistrationConfig_DuplicateRegistrationAction { get; set; }
            public System.Int32? RegistrationConfig_FraudsterSimilarityThreshold { get; set; }
            public List<System.String> RegistrationConfig_WatchlistId { get; set; }
            public System.Func<Amazon.VoiceID.Model.StartFraudsterRegistrationJobResponse, StartVIDFraudsterRegistrationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Job;
        }
        
    }
}
