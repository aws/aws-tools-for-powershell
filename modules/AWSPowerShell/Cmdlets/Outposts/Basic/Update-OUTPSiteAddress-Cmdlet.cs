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
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Updates the address of the specified site.
    /// 
    ///  
    /// <para>
    /// You can't update a site address if there is an order in progress. You must wait for
    /// the order to complete or cancel the order.
    /// </para><para>
    /// You can update the operating address before you place an order at the site, or after
    /// all Outposts that belong to the site have been deactivated.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OUTPSiteAddress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.UpdateSiteAddressResponse")]
    [AWSCmdlet("Calls the AWS Outposts UpdateSiteAddress API operation.", Operation = new[] {"UpdateSiteAddress"}, SelectReturnType = typeof(Amazon.Outposts.Model.UpdateSiteAddressResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.UpdateSiteAddressResponse",
        "This cmdlet returns an Amazon.Outposts.Model.UpdateSiteAddressResponse object containing multiple properties."
    )]
    public partial class UpdateOUTPSiteAddressCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Address_AddressLine1
        /// <summary>
        /// <para>
        /// <para>The first line of the address.</para>
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
        public System.String Address_AddressLine1 { get; set; }
        #endregion
        
        #region Parameter Address_AddressLine2
        /// <summary>
        /// <para>
        /// <para>The second line of the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_AddressLine2 { get; set; }
        #endregion
        
        #region Parameter Address_AddressLine3
        /// <summary>
        /// <para>
        /// <para>The third line of the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_AddressLine3 { get; set; }
        #endregion
        
        #region Parameter AddressType
        /// <summary>
        /// <para>
        /// <para> The type of the address. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Outposts.AddressType")]
        public Amazon.Outposts.AddressType AddressType { get; set; }
        #endregion
        
        #region Parameter Address_City
        /// <summary>
        /// <para>
        /// <para>The city for the address.</para>
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
        public System.String Address_City { get; set; }
        #endregion
        
        #region Parameter Address_ContactName
        /// <summary>
        /// <para>
        /// <para>The name of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_ContactName { get; set; }
        #endregion
        
        #region Parameter Address_ContactPhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number of the contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_ContactPhoneNumber { get; set; }
        #endregion
        
        #region Parameter Address_CountryCode
        /// <summary>
        /// <para>
        /// <para>The ISO-3166 two-letter country code for the address.</para>
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
        public System.String Address_CountryCode { get; set; }
        #endregion
        
        #region Parameter Address_DistrictOrCounty
        /// <summary>
        /// <para>
        /// <para>The district or county for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_DistrictOrCounty { get; set; }
        #endregion
        
        #region Parameter Address_Municipality
        /// <summary>
        /// <para>
        /// <para>The municipality for the address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Municipality { get; set; }
        #endregion
        
        #region Parameter Address_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code for the address.</para>
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
        public System.String Address_PostalCode { get; set; }
        #endregion
        
        #region Parameter SiteId
        /// <summary>
        /// <para>
        /// <para> The ID or the Amazon Resource Name (ARN) of the site. </para>
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
        public System.String SiteId { get; set; }
        #endregion
        
        #region Parameter Address_StateOrRegion
        /// <summary>
        /// <para>
        /// <para>The state for the address.</para>
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
        public System.String Address_StateOrRegion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.UpdateSiteAddressResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.UpdateSiteAddressResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SiteId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OUTPSiteAddress (UpdateSiteAddress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.UpdateSiteAddressResponse, UpdateOUTPSiteAddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Address_AddressLine1 = this.Address_AddressLine1;
            #if MODULAR
            if (this.Address_AddressLine1 == null && ParameterWasBound(nameof(this.Address_AddressLine1)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_AddressLine1 which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Address_AddressLine2 = this.Address_AddressLine2;
            context.Address_AddressLine3 = this.Address_AddressLine3;
            context.Address_City = this.Address_City;
            #if MODULAR
            if (this.Address_City == null && ParameterWasBound(nameof(this.Address_City)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_City which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Address_ContactName = this.Address_ContactName;
            context.Address_ContactPhoneNumber = this.Address_ContactPhoneNumber;
            context.Address_CountryCode = this.Address_CountryCode;
            #if MODULAR
            if (this.Address_CountryCode == null && ParameterWasBound(nameof(this.Address_CountryCode)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_CountryCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Address_DistrictOrCounty = this.Address_DistrictOrCounty;
            context.Address_Municipality = this.Address_Municipality;
            context.Address_PostalCode = this.Address_PostalCode;
            #if MODULAR
            if (this.Address_PostalCode == null && ParameterWasBound(nameof(this.Address_PostalCode)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_PostalCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Address_StateOrRegion = this.Address_StateOrRegion;
            #if MODULAR
            if (this.Address_StateOrRegion == null && ParameterWasBound(nameof(this.Address_StateOrRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter Address_StateOrRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AddressType = this.AddressType;
            #if MODULAR
            if (this.AddressType == null && ParameterWasBound(nameof(this.AddressType)))
            {
                WriteWarning("You are passing $null as a value for parameter AddressType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SiteId = this.SiteId;
            #if MODULAR
            if (this.SiteId == null && ParameterWasBound(nameof(this.SiteId)))
            {
                WriteWarning("You are passing $null as a value for parameter SiteId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Outposts.Model.UpdateSiteAddressRequest();
            
            
             // populate Address
            var requestAddressIsNull = true;
            request.Address = new Amazon.Outposts.Model.Address();
            System.String requestAddress_address_AddressLine1 = null;
            if (cmdletContext.Address_AddressLine1 != null)
            {
                requestAddress_address_AddressLine1 = cmdletContext.Address_AddressLine1;
            }
            if (requestAddress_address_AddressLine1 != null)
            {
                request.Address.AddressLine1 = requestAddress_address_AddressLine1;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_AddressLine2 = null;
            if (cmdletContext.Address_AddressLine2 != null)
            {
                requestAddress_address_AddressLine2 = cmdletContext.Address_AddressLine2;
            }
            if (requestAddress_address_AddressLine2 != null)
            {
                request.Address.AddressLine2 = requestAddress_address_AddressLine2;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_AddressLine3 = null;
            if (cmdletContext.Address_AddressLine3 != null)
            {
                requestAddress_address_AddressLine3 = cmdletContext.Address_AddressLine3;
            }
            if (requestAddress_address_AddressLine3 != null)
            {
                request.Address.AddressLine3 = requestAddress_address_AddressLine3;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_City = null;
            if (cmdletContext.Address_City != null)
            {
                requestAddress_address_City = cmdletContext.Address_City;
            }
            if (requestAddress_address_City != null)
            {
                request.Address.City = requestAddress_address_City;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_ContactName = null;
            if (cmdletContext.Address_ContactName != null)
            {
                requestAddress_address_ContactName = cmdletContext.Address_ContactName;
            }
            if (requestAddress_address_ContactName != null)
            {
                request.Address.ContactName = requestAddress_address_ContactName;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_ContactPhoneNumber = null;
            if (cmdletContext.Address_ContactPhoneNumber != null)
            {
                requestAddress_address_ContactPhoneNumber = cmdletContext.Address_ContactPhoneNumber;
            }
            if (requestAddress_address_ContactPhoneNumber != null)
            {
                request.Address.ContactPhoneNumber = requestAddress_address_ContactPhoneNumber;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_CountryCode = null;
            if (cmdletContext.Address_CountryCode != null)
            {
                requestAddress_address_CountryCode = cmdletContext.Address_CountryCode;
            }
            if (requestAddress_address_CountryCode != null)
            {
                request.Address.CountryCode = requestAddress_address_CountryCode;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_DistrictOrCounty = null;
            if (cmdletContext.Address_DistrictOrCounty != null)
            {
                requestAddress_address_DistrictOrCounty = cmdletContext.Address_DistrictOrCounty;
            }
            if (requestAddress_address_DistrictOrCounty != null)
            {
                request.Address.DistrictOrCounty = requestAddress_address_DistrictOrCounty;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Municipality = null;
            if (cmdletContext.Address_Municipality != null)
            {
                requestAddress_address_Municipality = cmdletContext.Address_Municipality;
            }
            if (requestAddress_address_Municipality != null)
            {
                request.Address.Municipality = requestAddress_address_Municipality;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_PostalCode = null;
            if (cmdletContext.Address_PostalCode != null)
            {
                requestAddress_address_PostalCode = cmdletContext.Address_PostalCode;
            }
            if (requestAddress_address_PostalCode != null)
            {
                request.Address.PostalCode = requestAddress_address_PostalCode;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_StateOrRegion = null;
            if (cmdletContext.Address_StateOrRegion != null)
            {
                requestAddress_address_StateOrRegion = cmdletContext.Address_StateOrRegion;
            }
            if (requestAddress_address_StateOrRegion != null)
            {
                request.Address.StateOrRegion = requestAddress_address_StateOrRegion;
                requestAddressIsNull = false;
            }
             // determine if request.Address should be set to null
            if (requestAddressIsNull)
            {
                request.Address = null;
            }
            if (cmdletContext.AddressType != null)
            {
                request.AddressType = cmdletContext.AddressType;
            }
            if (cmdletContext.SiteId != null)
            {
                request.SiteId = cmdletContext.SiteId;
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
        
        private Amazon.Outposts.Model.UpdateSiteAddressResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.UpdateSiteAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "UpdateSiteAddress");
            try
            {
                return client.UpdateSiteAddressAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Address_AddressLine1 { get; set; }
            public System.String Address_AddressLine2 { get; set; }
            public System.String Address_AddressLine3 { get; set; }
            public System.String Address_City { get; set; }
            public System.String Address_ContactName { get; set; }
            public System.String Address_ContactPhoneNumber { get; set; }
            public System.String Address_CountryCode { get; set; }
            public System.String Address_DistrictOrCounty { get; set; }
            public System.String Address_Municipality { get; set; }
            public System.String Address_PostalCode { get; set; }
            public System.String Address_StateOrRegion { get; set; }
            public Amazon.Outposts.AddressType AddressType { get; set; }
            public System.String SiteId { get; set; }
            public System.Func<Amazon.Outposts.Model.UpdateSiteAddressResponse, UpdateOUTPSiteAddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
