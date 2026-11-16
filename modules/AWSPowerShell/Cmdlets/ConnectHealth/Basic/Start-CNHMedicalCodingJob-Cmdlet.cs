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
using Amazon.ConnectHealth;
using Amazon.ConnectHealth.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CNH
{
    /// <summary>
    /// Starts an asynchronous job that generates medical codes (ICD-10 and CPT) for clinical
    /// text. Call GetMedicalCodingJob to check the status of the job. When the job succeeds,
    /// Amazon Connect Health writes the results to the output Amazon S3 location.
    /// 
    ///  
    /// <para>
    /// To tailor the codes to your organization, specify an ACTIVE medical coding dataset
    /// in the Domain. If you don't specify a dataset, the job uses the general medical coding
    /// knowledge base.
    /// </para><para>
    /// Medical coding jobs are in preview release and are subject to change.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CNHMedicalCodingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse")]
    [AWSCmdlet("Calls the Connect Health StartMedicalCodingJob API operation.", Operation = new[] {"StartMedicalCodingJob"}, SelectReturnType = typeof(Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse))]
    [AWSCmdletOutput("Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse",
        "This cmdlet returns an Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse object containing multiple properties."
    )]
    public partial class StartCNHMedicalCodingJobCmdlet : AmazonConnectHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EncounterContext_AfterHour
        /// <summary>
        /// <para>
        /// <para>Specifies whether the encounter took place outside regular business hours.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncounterContext_AfterHours")]
        public System.Boolean? EncounterContext_AfterHour { get; set; }
        #endregion
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of an ACTIVE medical coding dataset in the Domain to code against.
        /// If you don't specify a dataset, the job uses the general medical coding knowledge
        /// base.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter PatientContext_DateOfBirth
        /// <summary>
        /// <para>
        /// <para>The date of birth of the patient, in YYYY-MM-DD format. The date can't be after the
        /// current date in UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PatientContext_DateOfBirth { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the parent Domain.</para>
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
        public System.String DomainId { get; set; }
        #endregion
        
        #region Parameter EncounterContext_EncounterDate
        /// <summary>
        /// <para>
        /// <para>The date of the encounter, in YYYY-MM-DD format. The date can't be more than one day
        /// after the current date in UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncounterContext_EncounterDate { get; set; }
        #endregion
        
        #region Parameter EncounterContext_EncounterDurationMinute
        /// <summary>
        /// <para>
        /// <para>The duration of the encounter, in minutes, from 1 to 1440.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncounterContext_EncounterDurationMinutes")]
        public System.Int32? EncounterContext_EncounterDurationMinute { get; set; }
        #endregion
        
        #region Parameter EncounterContext_EncounterReason
        /// <summary>
        /// <para>
        /// <para>The reason for the encounter. The reason can contain letters, numbers, spaces, periods,
        /// commas, and hyphens, and can't contain only spaces.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncounterContext_EncounterReason { get; set; }
        #endregion
        
        #region Parameter EncounterContext_EncounterType
        /// <summary>
        /// <para>
        /// <para>The type of the encounter, either in person or telehealth.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectHealth.EncounterType")]
        public Amazon.ConnectHealth.EncounterType EncounterContext_EncounterType { get; set; }
        #endregion
        
        #region Parameter PatientContext_Insurance
        /// <summary>
        /// <para>
        /// <para>The insurance of the patient.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PatientContext_Insurance { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location where Amazon Connect Health writes the results of the job.</para>
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
        public System.String OutputDataConfig_S3OutputPath { get; set; }
        #endregion
        
        #region Parameter PatientContext_Sex
        /// <summary>
        /// <para>
        /// <para>The sex of the patient.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectHealth.Sex")]
        public Amazon.ConnectHealth.Sex PatientContext_Sex { get; set; }
        #endregion
        
        #region Parameter PatientContext_Status
        /// <summary>
        /// <para>
        /// <para>The status of the patient, either new or established.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectHealth.PatientStatus")]
        public Amazon.ConnectHealth.PatientStatus PatientContext_Status { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The clinical text to generate medical codes for, such as a clinical note.</para>
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
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse).
        /// Specifying the name of a property of type Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CNHMedicalCodingJob (StartMedicalCodingJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse, StartCNHMedicalCodingJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DatasetId = this.DatasetId;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncounterContext_AfterHour = this.EncounterContext_AfterHour;
            context.EncounterContext_EncounterDate = this.EncounterContext_EncounterDate;
            context.EncounterContext_EncounterDurationMinute = this.EncounterContext_EncounterDurationMinute;
            context.EncounterContext_EncounterReason = this.EncounterContext_EncounterReason;
            context.EncounterContext_EncounterType = this.EncounterContext_EncounterType;
            context.OutputDataConfig_S3OutputPath = this.OutputDataConfig_S3OutputPath;
            #if MODULAR
            if (this.OutputDataConfig_S3OutputPath == null && ParameterWasBound(nameof(this.OutputDataConfig_S3OutputPath)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3OutputPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PatientContext_DateOfBirth = this.PatientContext_DateOfBirth;
            context.PatientContext_Insurance = this.PatientContext_Insurance;
            context.PatientContext_Sex = this.PatientContext_Sex;
            context.PatientContext_Status = this.PatientContext_Status;
            context.Text = this.Text;
            #if MODULAR
            if (this.Text == null && ParameterWasBound(nameof(this.Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectHealth.Model.StartMedicalCodingJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate EncounterContext
            var requestEncounterContextIsNull = true;
            request.EncounterContext = new Amazon.ConnectHealth.Model.MedicalCodesEncounterContext();
            System.Boolean? requestEncounterContext_encounterContext_AfterHour = null;
            if (cmdletContext.EncounterContext_AfterHour != null)
            {
                requestEncounterContext_encounterContext_AfterHour = cmdletContext.EncounterContext_AfterHour.Value;
            }
            if (requestEncounterContext_encounterContext_AfterHour != null)
            {
                request.EncounterContext.AfterHours = requestEncounterContext_encounterContext_AfterHour.Value;
                requestEncounterContextIsNull = false;
            }
            System.String requestEncounterContext_encounterContext_EncounterDate = null;
            if (cmdletContext.EncounterContext_EncounterDate != null)
            {
                requestEncounterContext_encounterContext_EncounterDate = cmdletContext.EncounterContext_EncounterDate;
            }
            if (requestEncounterContext_encounterContext_EncounterDate != null)
            {
                request.EncounterContext.EncounterDate = requestEncounterContext_encounterContext_EncounterDate;
                requestEncounterContextIsNull = false;
            }
            System.Int32? requestEncounterContext_encounterContext_EncounterDurationMinute = null;
            if (cmdletContext.EncounterContext_EncounterDurationMinute != null)
            {
                requestEncounterContext_encounterContext_EncounterDurationMinute = cmdletContext.EncounterContext_EncounterDurationMinute.Value;
            }
            if (requestEncounterContext_encounterContext_EncounterDurationMinute != null)
            {
                request.EncounterContext.EncounterDurationMinutes = requestEncounterContext_encounterContext_EncounterDurationMinute.Value;
                requestEncounterContextIsNull = false;
            }
            System.String requestEncounterContext_encounterContext_EncounterReason = null;
            if (cmdletContext.EncounterContext_EncounterReason != null)
            {
                requestEncounterContext_encounterContext_EncounterReason = cmdletContext.EncounterContext_EncounterReason;
            }
            if (requestEncounterContext_encounterContext_EncounterReason != null)
            {
                request.EncounterContext.EncounterReason = requestEncounterContext_encounterContext_EncounterReason;
                requestEncounterContextIsNull = false;
            }
            Amazon.ConnectHealth.EncounterType requestEncounterContext_encounterContext_EncounterType = null;
            if (cmdletContext.EncounterContext_EncounterType != null)
            {
                requestEncounterContext_encounterContext_EncounterType = cmdletContext.EncounterContext_EncounterType;
            }
            if (requestEncounterContext_encounterContext_EncounterType != null)
            {
                request.EncounterContext.EncounterType = requestEncounterContext_encounterContext_EncounterType;
                requestEncounterContextIsNull = false;
            }
             // determine if request.EncounterContext should be set to null
            if (requestEncounterContextIsNull)
            {
                request.EncounterContext = null;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.ConnectHealth.Model.MedicalCodingOutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_S3OutputPath = null;
            if (cmdletContext.OutputDataConfig_S3OutputPath != null)
            {
                requestOutputDataConfig_outputDataConfig_S3OutputPath = cmdletContext.OutputDataConfig_S3OutputPath;
            }
            if (requestOutputDataConfig_outputDataConfig_S3OutputPath != null)
            {
                request.OutputDataConfig.S3OutputPath = requestOutputDataConfig_outputDataConfig_S3OutputPath;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            
             // populate PatientContext
            var requestPatientContextIsNull = true;
            request.PatientContext = new Amazon.ConnectHealth.Model.MedicalCodesPatientContext();
            System.String requestPatientContext_patientContext_DateOfBirth = null;
            if (cmdletContext.PatientContext_DateOfBirth != null)
            {
                requestPatientContext_patientContext_DateOfBirth = cmdletContext.PatientContext_DateOfBirth;
            }
            if (requestPatientContext_patientContext_DateOfBirth != null)
            {
                request.PatientContext.DateOfBirth = requestPatientContext_patientContext_DateOfBirth;
                requestPatientContextIsNull = false;
            }
            System.String requestPatientContext_patientContext_Insurance = null;
            if (cmdletContext.PatientContext_Insurance != null)
            {
                requestPatientContext_patientContext_Insurance = cmdletContext.PatientContext_Insurance;
            }
            if (requestPatientContext_patientContext_Insurance != null)
            {
                request.PatientContext.Insurance = requestPatientContext_patientContext_Insurance;
                requestPatientContextIsNull = false;
            }
            Amazon.ConnectHealth.Sex requestPatientContext_patientContext_Sex = null;
            if (cmdletContext.PatientContext_Sex != null)
            {
                requestPatientContext_patientContext_Sex = cmdletContext.PatientContext_Sex;
            }
            if (requestPatientContext_patientContext_Sex != null)
            {
                request.PatientContext.Sex = requestPatientContext_patientContext_Sex;
                requestPatientContextIsNull = false;
            }
            Amazon.ConnectHealth.PatientStatus requestPatientContext_patientContext_Status = null;
            if (cmdletContext.PatientContext_Status != null)
            {
                requestPatientContext_patientContext_Status = cmdletContext.PatientContext_Status;
            }
            if (requestPatientContext_patientContext_Status != null)
            {
                request.PatientContext.Status = requestPatientContext_patientContext_Status;
                requestPatientContextIsNull = false;
            }
             // determine if request.PatientContext should be set to null
            if (requestPatientContextIsNull)
            {
                request.PatientContext = null;
            }
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
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
        
        private Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse CallAWSServiceOperation(IAmazonConnectHealth client, Amazon.ConnectHealth.Model.StartMedicalCodingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Connect Health", "StartMedicalCodingJob");
            try
            {
                return client.StartMedicalCodingJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetId { get; set; }
            public System.String DomainId { get; set; }
            public System.Boolean? EncounterContext_AfterHour { get; set; }
            public System.String EncounterContext_EncounterDate { get; set; }
            public System.Int32? EncounterContext_EncounterDurationMinute { get; set; }
            public System.String EncounterContext_EncounterReason { get; set; }
            public Amazon.ConnectHealth.EncounterType EncounterContext_EncounterType { get; set; }
            public System.String OutputDataConfig_S3OutputPath { get; set; }
            public System.String PatientContext_DateOfBirth { get; set; }
            public System.String PatientContext_Insurance { get; set; }
            public Amazon.ConnectHealth.Sex PatientContext_Sex { get; set; }
            public Amazon.ConnectHealth.PatientStatus PatientContext_Status { get; set; }
            public System.String Text { get; set; }
            public System.Func<Amazon.ConnectHealth.Model.StartMedicalCodingJobResponse, StartCNHMedicalCodingJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
