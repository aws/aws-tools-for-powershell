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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Creates a license.
    /// </summary>
    [Cmdlet("New", "LICMLicense", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManager.Model.CreateLicenseResponse")]
    [AWSCmdlet("Calls the AWS License Manager CreateLicense API operation.", Operation = new[] {"CreateLicense"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CreateLicenseResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.CreateLicenseResponse",
        "This cmdlet returns an Amazon.LicenseManager.Model.CreateLicenseResponse object containing multiple properties."
    )]
    public partial class NewLICMLicenseCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BorrowConfiguration_AllowEarlyCheckIn
        /// <summary>
        /// <para>
        /// <para>Indicates whether early check-ins are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConsumptionConfiguration_BorrowConfiguration_AllowEarlyCheckIn")]
        public System.Boolean? BorrowConfiguration_AllowEarlyCheckIn { get; set; }
        #endregion
        
        #region Parameter Validity_Begin
        /// <summary>
        /// <para>
        /// <para>Start of the time range.</para>
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
        public System.String Validity_Begin { get; set; }
        #endregion
        
        #region Parameter Beneficiary
        /// <summary>
        /// <para>
        /// <para>License beneficiary.</para>
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
        public System.String Beneficiary { get; set; }
        #endregion
        
        #region Parameter Validity_End
        /// <summary>
        /// <para>
        /// <para>End of the time range.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Validity_End { get; set; }
        #endregion
        
        #region Parameter Entitlement
        /// <summary>
        /// <para>
        /// <para>License entitlements.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Entitlements")]
        public Amazon.LicenseManager.Model.Entitlement[] Entitlement { get; set; }
        #endregion
        
        #region Parameter HomeRegion
        /// <summary>
        /// <para>
        /// <para>Home Region for the license.</para>
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
        public System.String HomeRegion { get; set; }
        #endregion
        
        #region Parameter LicenseMetadata
        /// <summary>
        /// <para>
        /// <para>Information about the license.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.LicenseManager.Model.Metadata[] LicenseMetadata { get; set; }
        #endregion
        
        #region Parameter LicenseName
        /// <summary>
        /// <para>
        /// <para>License name.</para>
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
        public System.String LicenseName { get; set; }
        #endregion
        
        #region Parameter BorrowConfiguration_MaxTimeToLiveInMinute
        /// <summary>
        /// <para>
        /// <para>Maximum time for the borrow configuration, in minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConsumptionConfiguration_BorrowConfiguration_MaxTimeToLiveInMinutes")]
        public System.Int32? BorrowConfiguration_MaxTimeToLiveInMinute { get; set; }
        #endregion
        
        #region Parameter ProvisionalConfiguration_MaxTimeToLiveInMinute
        /// <summary>
        /// <para>
        /// <para>Maximum time for the provisional configuration, in minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConsumptionConfiguration_ProvisionalConfiguration_MaxTimeToLiveInMinutes")]
        public System.Int32? ProvisionalConfiguration_MaxTimeToLiveInMinute { get; set; }
        #endregion
        
        #region Parameter Issuer_Name
        /// <summary>
        /// <para>
        /// <para>Issuer name.</para>
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
        public System.String Issuer_Name { get; set; }
        #endregion
        
        #region Parameter ProductName
        /// <summary>
        /// <para>
        /// <para>Product name.</para>
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
        public System.String ProductName { get; set; }
        #endregion
        
        #region Parameter ProductSKU
        /// <summary>
        /// <para>
        /// <para>Product SKU.</para>
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
        public System.String ProductSKU { get; set; }
        #endregion
        
        #region Parameter ConsumptionConfiguration_RenewType
        /// <summary>
        /// <para>
        /// <para>Renewal frequency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LicenseManager.RenewType")]
        public Amazon.LicenseManager.RenewType ConsumptionConfiguration_RenewType { get; set; }
        #endregion
        
        #region Parameter Issuer_SignKey
        /// <summary>
        /// <para>
        /// <para>Asymmetric KMS key from Key Management Service. The KMS key must have a key usage
        /// of sign and verify, and support the RSASSA-PSS SHA-256 signing algorithm.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Issuer_SignKey { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CreateLicenseResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CreateLicenseResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LicenseName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMLicense (CreateLicense)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CreateLicenseResponse, NewLICMLicenseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Beneficiary = this.Beneficiary;
            #if MODULAR
            if (this.Beneficiary == null && ParameterWasBound(nameof(this.Beneficiary)))
            {
                WriteWarning("You are passing $null as a value for parameter Beneficiary which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BorrowConfiguration_AllowEarlyCheckIn = this.BorrowConfiguration_AllowEarlyCheckIn;
            context.BorrowConfiguration_MaxTimeToLiveInMinute = this.BorrowConfiguration_MaxTimeToLiveInMinute;
            context.ProvisionalConfiguration_MaxTimeToLiveInMinute = this.ProvisionalConfiguration_MaxTimeToLiveInMinute;
            context.ConsumptionConfiguration_RenewType = this.ConsumptionConfiguration_RenewType;
            if (this.Entitlement != null)
            {
                context.Entitlement = new List<Amazon.LicenseManager.Model.Entitlement>(this.Entitlement);
            }
            #if MODULAR
            if (this.Entitlement == null && ParameterWasBound(nameof(this.Entitlement)))
            {
                WriteWarning("You are passing $null as a value for parameter Entitlement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HomeRegion = this.HomeRegion;
            #if MODULAR
            if (this.HomeRegion == null && ParameterWasBound(nameof(this.HomeRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter HomeRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Issuer_Name = this.Issuer_Name;
            #if MODULAR
            if (this.Issuer_Name == null && ParameterWasBound(nameof(this.Issuer_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Issuer_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Issuer_SignKey = this.Issuer_SignKey;
            if (this.LicenseMetadata != null)
            {
                context.LicenseMetadata = new List<Amazon.LicenseManager.Model.Metadata>(this.LicenseMetadata);
            }
            context.LicenseName = this.LicenseName;
            #if MODULAR
            if (this.LicenseName == null && ParameterWasBound(nameof(this.LicenseName)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProductName = this.ProductName;
            #if MODULAR
            if (this.ProductName == null && ParameterWasBound(nameof(this.ProductName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProductSKU = this.ProductSKU;
            #if MODULAR
            if (this.ProductSKU == null && ParameterWasBound(nameof(this.ProductSKU)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductSKU which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Validity_Begin = this.Validity_Begin;
            #if MODULAR
            if (this.Validity_Begin == null && ParameterWasBound(nameof(this.Validity_Begin)))
            {
                WriteWarning("You are passing $null as a value for parameter Validity_Begin which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Validity_End = this.Validity_End;
            
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
            var request = new Amazon.LicenseManager.Model.CreateLicenseRequest();
            
            if (cmdletContext.Beneficiary != null)
            {
                request.Beneficiary = cmdletContext.Beneficiary;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConsumptionConfiguration
            var requestConsumptionConfigurationIsNull = true;
            request.ConsumptionConfiguration = new Amazon.LicenseManager.Model.ConsumptionConfiguration();
            Amazon.LicenseManager.RenewType requestConsumptionConfiguration_consumptionConfiguration_RenewType = null;
            if (cmdletContext.ConsumptionConfiguration_RenewType != null)
            {
                requestConsumptionConfiguration_consumptionConfiguration_RenewType = cmdletContext.ConsumptionConfiguration_RenewType;
            }
            if (requestConsumptionConfiguration_consumptionConfiguration_RenewType != null)
            {
                request.ConsumptionConfiguration.RenewType = requestConsumptionConfiguration_consumptionConfiguration_RenewType;
                requestConsumptionConfigurationIsNull = false;
            }
            Amazon.LicenseManager.Model.ProvisionalConfiguration requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration = null;
            
             // populate ProvisionalConfiguration
            var requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfigurationIsNull = true;
            requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration = new Amazon.LicenseManager.Model.ProvisionalConfiguration();
            System.Int32? requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration_provisionalConfiguration_MaxTimeToLiveInMinute = null;
            if (cmdletContext.ProvisionalConfiguration_MaxTimeToLiveInMinute != null)
            {
                requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration_provisionalConfiguration_MaxTimeToLiveInMinute = cmdletContext.ProvisionalConfiguration_MaxTimeToLiveInMinute.Value;
            }
            if (requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration_provisionalConfiguration_MaxTimeToLiveInMinute != null)
            {
                requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration.MaxTimeToLiveInMinutes = requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration_provisionalConfiguration_MaxTimeToLiveInMinute.Value;
                requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfigurationIsNull = false;
            }
             // determine if requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration should be set to null
            if (requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfigurationIsNull)
            {
                requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration = null;
            }
            if (requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration != null)
            {
                request.ConsumptionConfiguration.ProvisionalConfiguration = requestConsumptionConfiguration_consumptionConfiguration_ProvisionalConfiguration;
                requestConsumptionConfigurationIsNull = false;
            }
            Amazon.LicenseManager.Model.BorrowConfiguration requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration = null;
            
             // populate BorrowConfiguration
            var requestConsumptionConfiguration_consumptionConfiguration_BorrowConfigurationIsNull = true;
            requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration = new Amazon.LicenseManager.Model.BorrowConfiguration();
            System.Boolean? requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration_borrowConfiguration_AllowEarlyCheckIn = null;
            if (cmdletContext.BorrowConfiguration_AllowEarlyCheckIn != null)
            {
                requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration_borrowConfiguration_AllowEarlyCheckIn = cmdletContext.BorrowConfiguration_AllowEarlyCheckIn.Value;
            }
            if (requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration_borrowConfiguration_AllowEarlyCheckIn != null)
            {
                requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration.AllowEarlyCheckIn = requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration_borrowConfiguration_AllowEarlyCheckIn.Value;
                requestConsumptionConfiguration_consumptionConfiguration_BorrowConfigurationIsNull = false;
            }
            System.Int32? requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration_borrowConfiguration_MaxTimeToLiveInMinute = null;
            if (cmdletContext.BorrowConfiguration_MaxTimeToLiveInMinute != null)
            {
                requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration_borrowConfiguration_MaxTimeToLiveInMinute = cmdletContext.BorrowConfiguration_MaxTimeToLiveInMinute.Value;
            }
            if (requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration_borrowConfiguration_MaxTimeToLiveInMinute != null)
            {
                requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration.MaxTimeToLiveInMinutes = requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration_borrowConfiguration_MaxTimeToLiveInMinute.Value;
                requestConsumptionConfiguration_consumptionConfiguration_BorrowConfigurationIsNull = false;
            }
             // determine if requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration should be set to null
            if (requestConsumptionConfiguration_consumptionConfiguration_BorrowConfigurationIsNull)
            {
                requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration = null;
            }
            if (requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration != null)
            {
                request.ConsumptionConfiguration.BorrowConfiguration = requestConsumptionConfiguration_consumptionConfiguration_BorrowConfiguration;
                requestConsumptionConfigurationIsNull = false;
            }
             // determine if request.ConsumptionConfiguration should be set to null
            if (requestConsumptionConfigurationIsNull)
            {
                request.ConsumptionConfiguration = null;
            }
            if (cmdletContext.Entitlement != null)
            {
                request.Entitlements = cmdletContext.Entitlement;
            }
            if (cmdletContext.HomeRegion != null)
            {
                request.HomeRegion = cmdletContext.HomeRegion;
            }
            
             // populate Issuer
            var requestIssuerIsNull = true;
            request.Issuer = new Amazon.LicenseManager.Model.Issuer();
            System.String requestIssuer_issuer_Name = null;
            if (cmdletContext.Issuer_Name != null)
            {
                requestIssuer_issuer_Name = cmdletContext.Issuer_Name;
            }
            if (requestIssuer_issuer_Name != null)
            {
                request.Issuer.Name = requestIssuer_issuer_Name;
                requestIssuerIsNull = false;
            }
            System.String requestIssuer_issuer_SignKey = null;
            if (cmdletContext.Issuer_SignKey != null)
            {
                requestIssuer_issuer_SignKey = cmdletContext.Issuer_SignKey;
            }
            if (requestIssuer_issuer_SignKey != null)
            {
                request.Issuer.SignKey = requestIssuer_issuer_SignKey;
                requestIssuerIsNull = false;
            }
             // determine if request.Issuer should be set to null
            if (requestIssuerIsNull)
            {
                request.Issuer = null;
            }
            if (cmdletContext.LicenseMetadata != null)
            {
                request.LicenseMetadata = cmdletContext.LicenseMetadata;
            }
            if (cmdletContext.LicenseName != null)
            {
                request.LicenseName = cmdletContext.LicenseName;
            }
            if (cmdletContext.ProductName != null)
            {
                request.ProductName = cmdletContext.ProductName;
            }
            if (cmdletContext.ProductSKU != null)
            {
                request.ProductSKU = cmdletContext.ProductSKU;
            }
            
             // populate Validity
            var requestValidityIsNull = true;
            request.Validity = new Amazon.LicenseManager.Model.DatetimeRange();
            System.String requestValidity_validity_Begin = null;
            if (cmdletContext.Validity_Begin != null)
            {
                requestValidity_validity_Begin = cmdletContext.Validity_Begin;
            }
            if (requestValidity_validity_Begin != null)
            {
                request.Validity.Begin = requestValidity_validity_Begin;
                requestValidityIsNull = false;
            }
            System.String requestValidity_validity_End = null;
            if (cmdletContext.Validity_End != null)
            {
                requestValidity_validity_End = cmdletContext.Validity_End;
            }
            if (requestValidity_validity_End != null)
            {
                request.Validity.End = requestValidity_validity_End;
                requestValidityIsNull = false;
            }
             // determine if request.Validity should be set to null
            if (requestValidityIsNull)
            {
                request.Validity = null;
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
        
        private Amazon.LicenseManager.Model.CreateLicenseResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateLicenseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateLicense");
            try
            {
                return client.CreateLicenseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Beneficiary { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? BorrowConfiguration_AllowEarlyCheckIn { get; set; }
            public System.Int32? BorrowConfiguration_MaxTimeToLiveInMinute { get; set; }
            public System.Int32? ProvisionalConfiguration_MaxTimeToLiveInMinute { get; set; }
            public Amazon.LicenseManager.RenewType ConsumptionConfiguration_RenewType { get; set; }
            public List<Amazon.LicenseManager.Model.Entitlement> Entitlement { get; set; }
            public System.String HomeRegion { get; set; }
            public System.String Issuer_Name { get; set; }
            public System.String Issuer_SignKey { get; set; }
            public List<Amazon.LicenseManager.Model.Metadata> LicenseMetadata { get; set; }
            public System.String LicenseName { get; set; }
            public System.String ProductName { get; set; }
            public System.String ProductSKU { get; set; }
            public System.String Validity_Begin { get; set; }
            public System.String Validity_End { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CreateLicenseResponse, NewLICMLicenseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
