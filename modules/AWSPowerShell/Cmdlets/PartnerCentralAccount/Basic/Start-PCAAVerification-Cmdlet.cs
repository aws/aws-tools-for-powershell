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
using Amazon.PartnerCentralAccount;
using Amazon.PartnerCentralAccount.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PCAA
{
    /// <summary>
    /// Initiates a new verification process for a partner account. This operation begins
    /// the verification workflow for either business registration or individual registrant
    /// identity verification as required by AWS Partner Central.
    /// </summary>
    [Cmdlet("Start", "PCAAVerification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PartnerCentralAccount.Model.StartVerificationResponse")]
    [AWSCmdlet("Calls the Partner Central Account API StartVerification API operation.", Operation = new[] {"StartVerification"}, SelectReturnType = typeof(Amazon.PartnerCentralAccount.Model.StartVerificationResponse))]
    [AWSCmdletOutput("Amazon.PartnerCentralAccount.Model.StartVerificationResponse",
        "This cmdlet returns an Amazon.PartnerCentralAccount.Model.StartVerificationResponse object containing multiple properties."
    )]
    public partial class StartPCAAVerificationCmdlet : AmazonPartnerCentralAccountClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BusinessVerificationDetails_CountryCode
        /// <summary>
        /// <para>
        /// <para>The ISO 3166-1 alpha-2 country code where the business is legally registered and operates.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationDetails_BusinessVerificationDetails_CountryCode")]
        public System.String BusinessVerificationDetails_CountryCode { get; set; }
        #endregion
        
        #region Parameter BusinessVerificationDetails_JurisdictionOfIncorporation
        /// <summary>
        /// <para>
        /// <para>The specific legal jurisdiction or state where the business was incorporated or registered,
        /// providing additional location context beyond the country code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationDetails_BusinessVerificationDetails_JurisdictionOfIncorporation")]
        public System.String BusinessVerificationDetails_JurisdictionOfIncorporation { get; set; }
        #endregion
        
        #region Parameter BusinessVerificationDetails_LegalName
        /// <summary>
        /// <para>
        /// <para>The official legal name of the business as registered with the appropriate government
        /// authorities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationDetails_BusinessVerificationDetails_LegalName")]
        public System.String BusinessVerificationDetails_LegalName { get; set; }
        #endregion
        
        #region Parameter VerificationDetails_RegistrantVerificationDetail
        /// <summary>
        /// <para>
        /// <para>The registrant verification details to be used when starting an individual identity
        /// verification process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationDetails_RegistrantVerificationDetails")]
        public Amazon.PartnerCentralAccount.Model.RegistrantVerificationDetails VerificationDetails_RegistrantVerificationDetail { get; set; }
        #endregion
        
        #region Parameter BusinessVerificationDetails_RegistrationId
        /// <summary>
        /// <para>
        /// <para>The unique business registration identifier assigned by the government or regulatory
        /// authority, such as a company registration number or tax identification number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VerificationDetails_BusinessVerificationDetails_RegistrationId")]
        public System.String BusinessVerificationDetails_RegistrationId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. This prevents duplicate verification processes from being started accidentally.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PartnerCentralAccount.Model.StartVerificationResponse).
        /// Specifying the name of a property of type Amazon.PartnerCentralAccount.Model.StartVerificationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BusinessVerificationDetails_RegistrationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-PCAAVerification (StartVerification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PartnerCentralAccount.Model.StartVerificationResponse, StartPCAAVerificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.BusinessVerificationDetails_CountryCode = this.BusinessVerificationDetails_CountryCode;
            context.BusinessVerificationDetails_JurisdictionOfIncorporation = this.BusinessVerificationDetails_JurisdictionOfIncorporation;
            context.BusinessVerificationDetails_LegalName = this.BusinessVerificationDetails_LegalName;
            context.BusinessVerificationDetails_RegistrationId = this.BusinessVerificationDetails_RegistrationId;
            context.VerificationDetails_RegistrantVerificationDetail = this.VerificationDetails_RegistrantVerificationDetail;
            
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
            var request = new Amazon.PartnerCentralAccount.Model.StartVerificationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate VerificationDetails
            var requestVerificationDetailsIsNull = true;
            request.VerificationDetails = new Amazon.PartnerCentralAccount.Model.VerificationDetails();
            Amazon.PartnerCentralAccount.Model.RegistrantVerificationDetails requestVerificationDetails_verificationDetails_RegistrantVerificationDetail = null;
            if (cmdletContext.VerificationDetails_RegistrantVerificationDetail != null)
            {
                requestVerificationDetails_verificationDetails_RegistrantVerificationDetail = cmdletContext.VerificationDetails_RegistrantVerificationDetail;
            }
            if (requestVerificationDetails_verificationDetails_RegistrantVerificationDetail != null)
            {
                request.VerificationDetails.RegistrantVerificationDetails = requestVerificationDetails_verificationDetails_RegistrantVerificationDetail;
                requestVerificationDetailsIsNull = false;
            }
            Amazon.PartnerCentralAccount.Model.BusinessVerificationDetails requestVerificationDetails_verificationDetails_BusinessVerificationDetails = null;
            
             // populate BusinessVerificationDetails
            var requestVerificationDetails_verificationDetails_BusinessVerificationDetailsIsNull = true;
            requestVerificationDetails_verificationDetails_BusinessVerificationDetails = new Amazon.PartnerCentralAccount.Model.BusinessVerificationDetails();
            System.String requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_CountryCode = null;
            if (cmdletContext.BusinessVerificationDetails_CountryCode != null)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_CountryCode = cmdletContext.BusinessVerificationDetails_CountryCode;
            }
            if (requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_CountryCode != null)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails.CountryCode = requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_CountryCode;
                requestVerificationDetails_verificationDetails_BusinessVerificationDetailsIsNull = false;
            }
            System.String requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_JurisdictionOfIncorporation = null;
            if (cmdletContext.BusinessVerificationDetails_JurisdictionOfIncorporation != null)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_JurisdictionOfIncorporation = cmdletContext.BusinessVerificationDetails_JurisdictionOfIncorporation;
            }
            if (requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_JurisdictionOfIncorporation != null)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails.JurisdictionOfIncorporation = requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_JurisdictionOfIncorporation;
                requestVerificationDetails_verificationDetails_BusinessVerificationDetailsIsNull = false;
            }
            System.String requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_LegalName = null;
            if (cmdletContext.BusinessVerificationDetails_LegalName != null)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_LegalName = cmdletContext.BusinessVerificationDetails_LegalName;
            }
            if (requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_LegalName != null)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails.LegalName = requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_LegalName;
                requestVerificationDetails_verificationDetails_BusinessVerificationDetailsIsNull = false;
            }
            System.String requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_RegistrationId = null;
            if (cmdletContext.BusinessVerificationDetails_RegistrationId != null)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_RegistrationId = cmdletContext.BusinessVerificationDetails_RegistrationId;
            }
            if (requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_RegistrationId != null)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails.RegistrationId = requestVerificationDetails_verificationDetails_BusinessVerificationDetails_businessVerificationDetails_RegistrationId;
                requestVerificationDetails_verificationDetails_BusinessVerificationDetailsIsNull = false;
            }
             // determine if requestVerificationDetails_verificationDetails_BusinessVerificationDetails should be set to null
            if (requestVerificationDetails_verificationDetails_BusinessVerificationDetailsIsNull)
            {
                requestVerificationDetails_verificationDetails_BusinessVerificationDetails = null;
            }
            if (requestVerificationDetails_verificationDetails_BusinessVerificationDetails != null)
            {
                request.VerificationDetails.BusinessVerificationDetails = requestVerificationDetails_verificationDetails_BusinessVerificationDetails;
                requestVerificationDetailsIsNull = false;
            }
             // determine if request.VerificationDetails should be set to null
            if (requestVerificationDetailsIsNull)
            {
                request.VerificationDetails = null;
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
        
        private Amazon.PartnerCentralAccount.Model.StartVerificationResponse CallAWSServiceOperation(IAmazonPartnerCentralAccount client, Amazon.PartnerCentralAccount.Model.StartVerificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Partner Central Account API", "StartVerification");
            try
            {
                return client.StartVerificationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BusinessVerificationDetails_CountryCode { get; set; }
            public System.String BusinessVerificationDetails_JurisdictionOfIncorporation { get; set; }
            public System.String BusinessVerificationDetails_LegalName { get; set; }
            public System.String BusinessVerificationDetails_RegistrationId { get; set; }
            public Amazon.PartnerCentralAccount.Model.RegistrantVerificationDetails VerificationDetails_RegistrantVerificationDetail { get; set; }
            public System.Func<Amazon.PartnerCentralAccount.Model.StartVerificationResponse, StartPCAAVerificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
