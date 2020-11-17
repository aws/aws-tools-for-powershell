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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Checks out the specified license.
    /// </summary>
    [Cmdlet("Invoke", "LICMLicenseCheckout", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManager.Model.CheckoutLicenseResponse")]
    [AWSCmdlet("Calls the AWS License Manager CheckoutLicense API operation.", Operation = new[] {"CheckoutLicense"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CheckoutLicenseResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.CheckoutLicenseResponse",
        "This cmdlet returns an Amazon.LicenseManager.Model.CheckoutLicenseResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeLICMLicenseCheckoutCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        #region Parameter Beneficiary
        /// <summary>
        /// <para>
        /// <para>License beneficiary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Beneficiary { get; set; }
        #endregion
        
        #region Parameter CheckoutType
        /// <summary>
        /// <para>
        /// <para>Checkout type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LicenseManager.CheckoutType")]
        public Amazon.LicenseManager.CheckoutType CheckoutType { get; set; }
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
        public Amazon.LicenseManager.Model.EntitlementData[] Entitlement { get; set; }
        #endregion
        
        #region Parameter KeyFingerprint
        /// <summary>
        /// <para>
        /// <para>Key fingerprint identifying the license.</para>
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
        public System.String KeyFingerprint { get; set; }
        #endregion
        
        #region Parameter NodeId
        /// <summary>
        /// <para>
        /// <para>Node ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NodeId { get; set; }
        #endregion
        
        #region Parameter ProductSKU
        /// <summary>
        /// <para>
        /// <para>Product SKU.</para>
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
        public System.String ProductSKU { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CheckoutLicenseResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CheckoutLicenseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProductSKU parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProductSKU' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProductSKU' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProductSKU), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-LICMLicenseCheckout (CheckoutLicense)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CheckoutLicenseResponse, InvokeLICMLicenseCheckoutCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProductSKU;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Beneficiary = this.Beneficiary;
            context.CheckoutType = this.CheckoutType;
            #if MODULAR
            if (this.CheckoutType == null && ParameterWasBound(nameof(this.CheckoutType)))
            {
                WriteWarning("You are passing $null as a value for parameter CheckoutType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Entitlement != null)
            {
                context.Entitlement = new List<Amazon.LicenseManager.Model.EntitlementData>(this.Entitlement);
            }
            #if MODULAR
            if (this.Entitlement == null && ParameterWasBound(nameof(this.Entitlement)))
            {
                WriteWarning("You are passing $null as a value for parameter Entitlement which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyFingerprint = this.KeyFingerprint;
            #if MODULAR
            if (this.KeyFingerprint == null && ParameterWasBound(nameof(this.KeyFingerprint)))
            {
                WriteWarning("You are passing $null as a value for parameter KeyFingerprint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NodeId = this.NodeId;
            context.ProductSKU = this.ProductSKU;
            #if MODULAR
            if (this.ProductSKU == null && ParameterWasBound(nameof(this.ProductSKU)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductSKU which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LicenseManager.Model.CheckoutLicenseRequest();
            
            if (cmdletContext.Beneficiary != null)
            {
                request.Beneficiary = cmdletContext.Beneficiary;
            }
            if (cmdletContext.CheckoutType != null)
            {
                request.CheckoutType = cmdletContext.CheckoutType;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Entitlement != null)
            {
                request.Entitlements = cmdletContext.Entitlement;
            }
            if (cmdletContext.KeyFingerprint != null)
            {
                request.KeyFingerprint = cmdletContext.KeyFingerprint;
            }
            if (cmdletContext.NodeId != null)
            {
                request.NodeId = cmdletContext.NodeId;
            }
            if (cmdletContext.ProductSKU != null)
            {
                request.ProductSKU = cmdletContext.ProductSKU;
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
        
        private Amazon.LicenseManager.Model.CheckoutLicenseResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CheckoutLicenseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CheckoutLicense");
            try
            {
                #if DESKTOP
                return client.CheckoutLicense(request);
                #elif CORECLR
                return client.CheckoutLicenseAsync(request).GetAwaiter().GetResult();
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
            public System.String Beneficiary { get; set; }
            public Amazon.LicenseManager.CheckoutType CheckoutType { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.LicenseManager.Model.EntitlementData> Entitlement { get; set; }
            public System.String KeyFingerprint { get; set; }
            public System.String NodeId { get; set; }
            public System.String ProductSKU { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CheckoutLicenseResponse, InvokeLICMLicenseCheckoutCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
