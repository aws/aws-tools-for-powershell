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
    /// Starts a new patient insights job.
    /// </summary>
    [Cmdlet("Start", "CNHPatientInsightsJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse")]
    [AWSCmdlet("Calls the Connect Health StartPatientInsightsJob API operation.", Operation = new[] {"StartPatientInsightsJob"}, SelectReturnType = typeof(Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse))]
    [AWSCmdletOutput("Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse",
        "This cmdlet returns an Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse object containing multiple properties."
    )]
    public partial class StartCNHPatientInsightsJobCmdlet : AmazonConnectHealthClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PatientContext_DateOfBirth
        /// <summary>
        /// <para>
        /// <para>Date of birth of the patient.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PatientContext_DateOfBirth { get; set; }
        #endregion
        
        #region Parameter DomainId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        
        #region Parameter EncounterContext_EncounterReason
        /// <summary>
        /// <para>
        /// <para>Chief complaint for the visit</para>
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
        public System.String EncounterContext_EncounterReason { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_FhirServer_FhirEndpoint
        /// <summary>
        /// <para>
        /// <para>FHIR server endpoint URL for accessing patient data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_FhirServer_FhirEndpoint { get; set; }
        #endregion
        
        #region Parameter InsightsContext_InsightsType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ConnectHealth.InsightsType")]
        public Amazon.ConnectHealth.InsightsType InsightsContext_InsightsType { get; set; }
        #endregion
        
        #region Parameter InputDataConfig_FhirServer_OauthToken
        /// <summary>
        /// <para>
        /// <para>OAuth token for authenticating with the FHIR server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDataConfig_FhirServer_OauthToken { get; set; }
        #endregion
        
        #region Parameter PatientContext_PatientId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of the patient</para>
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
        public System.String PatientContext_PatientId { get; set; }
        #endregion
        
        #region Parameter PatientContext_Pronoun
        /// <summary>
        /// <para>
        /// <para>Pronouns preferred by the patient.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PatientContext_Pronouns")]
        [AWSConstantClassSource("Amazon.ConnectHealth.Pronouns")]
        public Amazon.ConnectHealth.Pronouns PatientContext_Pronoun { get; set; }
        #endregion
        
        #region Parameter UserContext_Role
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ConnectHealth.ProviderRole")]
        public Amazon.ConnectHealth.ProviderRole UserContext_Role { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3OutputPath
        /// <summary>
        /// <para>
        /// <para>S3 URI where the insights output will be stored.</para>
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
        
        #region Parameter InputDataConfig_S3Source
        /// <summary>
        /// <para>
        /// <para>List of S3 sources containing patient data.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputDataConfig_S3Sources")]
        public Amazon.ConnectHealth.Model.S3Source[] InputDataConfig_S3Source { get; set; }
        #endregion
        
        #region Parameter UserContext_Specialty
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ConnectHealth.Specialty")]
        public Amazon.ConnectHealth.Specialty UserContext_Specialty { get; set; }
        #endregion
        
        #region Parameter UserContext_UserId
        /// <summary>
        /// <para>
        /// <para>Unique identifier of the user</para>
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
        public System.String UserContext_UserId { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse).
        /// Specifying the name of a property of type Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CNHPatientInsightsJob (StartPatientInsightsJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse, StartCNHPatientInsightsJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DomainId = this.DomainId;
            #if MODULAR
            if (this.DomainId == null && ParameterWasBound(nameof(this.DomainId)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncounterContext_EncounterReason = this.EncounterContext_EncounterReason;
            #if MODULAR
            if (this.EncounterContext_EncounterReason == null && ParameterWasBound(nameof(this.EncounterContext_EncounterReason)))
            {
                WriteWarning("You are passing $null as a value for parameter EncounterContext_EncounterReason which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDataConfig_FhirServer_FhirEndpoint = this.InputDataConfig_FhirServer_FhirEndpoint;
            context.InputDataConfig_FhirServer_OauthToken = this.InputDataConfig_FhirServer_OauthToken;
            if (this.InputDataConfig_S3Source != null)
            {
                context.InputDataConfig_S3Source = new List<Amazon.ConnectHealth.Model.S3Source>(this.InputDataConfig_S3Source);
            }
            context.InsightsContext_InsightsType = this.InsightsContext_InsightsType;
            #if MODULAR
            if (this.InsightsContext_InsightsType == null && ParameterWasBound(nameof(this.InsightsContext_InsightsType)))
            {
                WriteWarning("You are passing $null as a value for parameter InsightsContext_InsightsType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputDataConfig_S3OutputPath = this.OutputDataConfig_S3OutputPath;
            #if MODULAR
            if (this.OutputDataConfig_S3OutputPath == null && ParameterWasBound(nameof(this.OutputDataConfig_S3OutputPath)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3OutputPath which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PatientContext_DateOfBirth = this.PatientContext_DateOfBirth;
            context.PatientContext_PatientId = this.PatientContext_PatientId;
            #if MODULAR
            if (this.PatientContext_PatientId == null && ParameterWasBound(nameof(this.PatientContext_PatientId)))
            {
                WriteWarning("You are passing $null as a value for parameter PatientContext_PatientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PatientContext_Pronoun = this.PatientContext_Pronoun;
            context.UserContext_Role = this.UserContext_Role;
            #if MODULAR
            if (this.UserContext_Role == null && ParameterWasBound(nameof(this.UserContext_Role)))
            {
                WriteWarning("You are passing $null as a value for parameter UserContext_Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserContext_Specialty = this.UserContext_Specialty;
            context.UserContext_UserId = this.UserContext_UserId;
            #if MODULAR
            if (this.UserContext_UserId == null && ParameterWasBound(nameof(this.UserContext_UserId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserContext_UserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConnectHealth.Model.StartPatientInsightsJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainId != null)
            {
                request.DomainId = cmdletContext.DomainId;
            }
            
             // populate EncounterContext
            var requestEncounterContextIsNull = true;
            request.EncounterContext = new Amazon.ConnectHealth.Model.PatientInsightsEncounterContext();
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
             // determine if request.EncounterContext should be set to null
            if (requestEncounterContextIsNull)
            {
                request.EncounterContext = null;
            }
            
             // populate InputDataConfig
            var requestInputDataConfigIsNull = true;
            request.InputDataConfig = new Amazon.ConnectHealth.Model.InputDataConfig();
            List<Amazon.ConnectHealth.Model.S3Source> requestInputDataConfig_inputDataConfig_S3Source = null;
            if (cmdletContext.InputDataConfig_S3Source != null)
            {
                requestInputDataConfig_inputDataConfig_S3Source = cmdletContext.InputDataConfig_S3Source;
            }
            if (requestInputDataConfig_inputDataConfig_S3Source != null)
            {
                request.InputDataConfig.S3Sources = requestInputDataConfig_inputDataConfig_S3Source;
                requestInputDataConfigIsNull = false;
            }
            Amazon.ConnectHealth.Model.FHIRServer requestInputDataConfig_inputDataConfig_FhirServer = null;
            
             // populate FhirServer
            var requestInputDataConfig_inputDataConfig_FhirServerIsNull = true;
            requestInputDataConfig_inputDataConfig_FhirServer = new Amazon.ConnectHealth.Model.FHIRServer();
            System.String requestInputDataConfig_inputDataConfig_FhirServer_inputDataConfig_FhirServer_FhirEndpoint = null;
            if (cmdletContext.InputDataConfig_FhirServer_FhirEndpoint != null)
            {
                requestInputDataConfig_inputDataConfig_FhirServer_inputDataConfig_FhirServer_FhirEndpoint = cmdletContext.InputDataConfig_FhirServer_FhirEndpoint;
            }
            if (requestInputDataConfig_inputDataConfig_FhirServer_inputDataConfig_FhirServer_FhirEndpoint != null)
            {
                requestInputDataConfig_inputDataConfig_FhirServer.FhirEndpoint = requestInputDataConfig_inputDataConfig_FhirServer_inputDataConfig_FhirServer_FhirEndpoint;
                requestInputDataConfig_inputDataConfig_FhirServerIsNull = false;
            }
            System.String requestInputDataConfig_inputDataConfig_FhirServer_inputDataConfig_FhirServer_OauthToken = null;
            if (cmdletContext.InputDataConfig_FhirServer_OauthToken != null)
            {
                requestInputDataConfig_inputDataConfig_FhirServer_inputDataConfig_FhirServer_OauthToken = cmdletContext.InputDataConfig_FhirServer_OauthToken;
            }
            if (requestInputDataConfig_inputDataConfig_FhirServer_inputDataConfig_FhirServer_OauthToken != null)
            {
                requestInputDataConfig_inputDataConfig_FhirServer.OauthToken = requestInputDataConfig_inputDataConfig_FhirServer_inputDataConfig_FhirServer_OauthToken;
                requestInputDataConfig_inputDataConfig_FhirServerIsNull = false;
            }
             // determine if requestInputDataConfig_inputDataConfig_FhirServer should be set to null
            if (requestInputDataConfig_inputDataConfig_FhirServerIsNull)
            {
                requestInputDataConfig_inputDataConfig_FhirServer = null;
            }
            if (requestInputDataConfig_inputDataConfig_FhirServer != null)
            {
                request.InputDataConfig.FhirServer = requestInputDataConfig_inputDataConfig_FhirServer;
                requestInputDataConfigIsNull = false;
            }
             // determine if request.InputDataConfig should be set to null
            if (requestInputDataConfigIsNull)
            {
                request.InputDataConfig = null;
            }
            
             // populate InsightsContext
            var requestInsightsContextIsNull = true;
            request.InsightsContext = new Amazon.ConnectHealth.Model.InsightsContext();
            Amazon.ConnectHealth.InsightsType requestInsightsContext_insightsContext_InsightsType = null;
            if (cmdletContext.InsightsContext_InsightsType != null)
            {
                requestInsightsContext_insightsContext_InsightsType = cmdletContext.InsightsContext_InsightsType;
            }
            if (requestInsightsContext_insightsContext_InsightsType != null)
            {
                request.InsightsContext.InsightsType = requestInsightsContext_insightsContext_InsightsType;
                requestInsightsContextIsNull = false;
            }
             // determine if request.InsightsContext should be set to null
            if (requestInsightsContextIsNull)
            {
                request.InsightsContext = null;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.ConnectHealth.Model.OutputDataConfig();
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
            request.PatientContext = new Amazon.ConnectHealth.Model.PatientInsightsPatientContext();
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
            System.String requestPatientContext_patientContext_PatientId = null;
            if (cmdletContext.PatientContext_PatientId != null)
            {
                requestPatientContext_patientContext_PatientId = cmdletContext.PatientContext_PatientId;
            }
            if (requestPatientContext_patientContext_PatientId != null)
            {
                request.PatientContext.PatientId = requestPatientContext_patientContext_PatientId;
                requestPatientContextIsNull = false;
            }
            Amazon.ConnectHealth.Pronouns requestPatientContext_patientContext_Pronoun = null;
            if (cmdletContext.PatientContext_Pronoun != null)
            {
                requestPatientContext_patientContext_Pronoun = cmdletContext.PatientContext_Pronoun;
            }
            if (requestPatientContext_patientContext_Pronoun != null)
            {
                request.PatientContext.Pronouns = requestPatientContext_patientContext_Pronoun;
                requestPatientContextIsNull = false;
            }
             // determine if request.PatientContext should be set to null
            if (requestPatientContextIsNull)
            {
                request.PatientContext = null;
            }
            
             // populate UserContext
            var requestUserContextIsNull = true;
            request.UserContext = new Amazon.ConnectHealth.Model.UserContext();
            Amazon.ConnectHealth.ProviderRole requestUserContext_userContext_Role = null;
            if (cmdletContext.UserContext_Role != null)
            {
                requestUserContext_userContext_Role = cmdletContext.UserContext_Role;
            }
            if (requestUserContext_userContext_Role != null)
            {
                request.UserContext.Role = requestUserContext_userContext_Role;
                requestUserContextIsNull = false;
            }
            Amazon.ConnectHealth.Specialty requestUserContext_userContext_Specialty = null;
            if (cmdletContext.UserContext_Specialty != null)
            {
                requestUserContext_userContext_Specialty = cmdletContext.UserContext_Specialty;
            }
            if (requestUserContext_userContext_Specialty != null)
            {
                request.UserContext.Specialty = requestUserContext_userContext_Specialty;
                requestUserContextIsNull = false;
            }
            System.String requestUserContext_userContext_UserId = null;
            if (cmdletContext.UserContext_UserId != null)
            {
                requestUserContext_userContext_UserId = cmdletContext.UserContext_UserId;
            }
            if (requestUserContext_userContext_UserId != null)
            {
                request.UserContext.UserId = requestUserContext_userContext_UserId;
                requestUserContextIsNull = false;
            }
             // determine if request.UserContext should be set to null
            if (requestUserContextIsNull)
            {
                request.UserContext = null;
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
        
        private Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse CallAWSServiceOperation(IAmazonConnectHealth client, Amazon.ConnectHealth.Model.StartPatientInsightsJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Connect Health", "StartPatientInsightsJob");
            try
            {
                return client.StartPatientInsightsJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainId { get; set; }
            public System.String EncounterContext_EncounterReason { get; set; }
            public System.String InputDataConfig_FhirServer_FhirEndpoint { get; set; }
            public System.String InputDataConfig_FhirServer_OauthToken { get; set; }
            public List<Amazon.ConnectHealth.Model.S3Source> InputDataConfig_S3Source { get; set; }
            public Amazon.ConnectHealth.InsightsType InsightsContext_InsightsType { get; set; }
            public System.String OutputDataConfig_S3OutputPath { get; set; }
            public System.String PatientContext_DateOfBirth { get; set; }
            public System.String PatientContext_PatientId { get; set; }
            public Amazon.ConnectHealth.Pronouns PatientContext_Pronoun { get; set; }
            public Amazon.ConnectHealth.ProviderRole UserContext_Role { get; set; }
            public Amazon.ConnectHealth.Specialty UserContext_Specialty { get; set; }
            public System.String UserContext_UserId { get; set; }
            public System.Func<Amazon.ConnectHealth.Model.StartPatientInsightsJobResponse, StartCNHPatientInsightsJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
