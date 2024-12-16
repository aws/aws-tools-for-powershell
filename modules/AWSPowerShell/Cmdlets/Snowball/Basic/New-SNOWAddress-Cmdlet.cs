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
using Amazon.Snowball;
using Amazon.Snowball.Model;

namespace Amazon.PowerShell.Cmdlets.SNOW
{
    /// <summary>
    /// Creates an address for a Snow device to be shipped to. In most regions, addresses
    /// are validated at the time of creation. The address you provide must be located within
    /// the serviceable area of your region. If the address is invalid or unsupported, then
    /// an exception is thrown. If providing an address as a JSON file through the <c>cli-input-json</c>
    /// option, include the full file path. For example, <c>--cli-input-json file://create-address.json</c>.
    /// </summary>
    [Cmdlet("New", "SNOWAddress", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Import/Export Snowball CreateAddress API operation.", Operation = new[] {"CreateAddress"}, SelectReturnType = typeof(Amazon.Snowball.Model.CreateAddressResponse))]
    [AWSCmdletOutput("System.String or Amazon.Snowball.Model.CreateAddressResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Snowball.Model.CreateAddressResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSNOWAddressCmdlet : AmazonSnowballClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Address_AddressId
        /// <summary>
        /// <para>
        /// <para>The unique ID for an address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_AddressId { get; set; }
        #endregion
        
        #region Parameter Address_City
        /// <summary>
        /// <para>
        /// <para>The city in an address that a Snow device is to be delivered to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_City { get; set; }
        #endregion
        
        #region Parameter Address_Company
        /// <summary>
        /// <para>
        /// <para>The name of the company to receive a Snow device at an address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Company { get; set; }
        #endregion
        
        #region Parameter Address_Country
        /// <summary>
        /// <para>
        /// <para>The country in an address that a Snow device is to be delivered to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Country { get; set; }
        #endregion
        
        #region Parameter Address_IsRestricted
        /// <summary>
        /// <para>
        /// <para>If the address you are creating is a primary address, then set this option to true.
        /// This field is not supported in most regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Address_IsRestricted { get; set; }
        #endregion
        
        #region Parameter Address_Landmark
        /// <summary>
        /// <para>
        /// <para>This field is no longer used and the value is ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Landmark { get; set; }
        #endregion
        
        #region Parameter Address_Name
        /// <summary>
        /// <para>
        /// <para>The name of a person to receive a Snow device at an address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Name { get; set; }
        #endregion
        
        #region Parameter Address_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number associated with an address that a Snow device is to be delivered
        /// to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter Address_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code in an address that a Snow device is to be delivered to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_PostalCode { get; set; }
        #endregion
        
        #region Parameter Address_PrefectureOrDistrict
        /// <summary>
        /// <para>
        /// <para>This field is no longer used and the value is ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_PrefectureOrDistrict { get; set; }
        #endregion
        
        #region Parameter Address_StateOrProvince
        /// <summary>
        /// <para>
        /// <para>The state or province in an address that a Snow device is to be delivered to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_StateOrProvince { get; set; }
        #endregion
        
        #region Parameter Address_Street1
        /// <summary>
        /// <para>
        /// <para>The first line in a street address that a Snow device is to be delivered to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Street1 { get; set; }
        #endregion
        
        #region Parameter Address_Street2
        /// <summary>
        /// <para>
        /// <para>The second line in a street address that a Snow device is to be delivered to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Street2 { get; set; }
        #endregion
        
        #region Parameter Address_Street3
        /// <summary>
        /// <para>
        /// <para>The third line in a street address that a Snow device is to be delivered to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Address_Street3 { get; set; }
        #endregion
        
        #region Parameter Address_Type
        /// <summary>
        /// <para>
        /// <para>Differentiates between delivery address and pickup address in the customer account.
        /// Provided at job creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Snowball.AddressType")]
        public Amazon.Snowball.AddressType Address_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AddressId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Snowball.Model.CreateAddressResponse).
        /// Specifying the name of a property of type Amazon.Snowball.Model.CreateAddressResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AddressId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SNOWAddress (CreateAddress)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Snowball.Model.CreateAddressResponse, NewSNOWAddressCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Address_AddressId = this.Address_AddressId;
            context.Address_City = this.Address_City;
            context.Address_Company = this.Address_Company;
            context.Address_Country = this.Address_Country;
            context.Address_IsRestricted = this.Address_IsRestricted;
            context.Address_Landmark = this.Address_Landmark;
            context.Address_Name = this.Address_Name;
            context.Address_PhoneNumber = this.Address_PhoneNumber;
            context.Address_PostalCode = this.Address_PostalCode;
            context.Address_PrefectureOrDistrict = this.Address_PrefectureOrDistrict;
            context.Address_StateOrProvince = this.Address_StateOrProvince;
            context.Address_Street1 = this.Address_Street1;
            context.Address_Street2 = this.Address_Street2;
            context.Address_Street3 = this.Address_Street3;
            context.Address_Type = this.Address_Type;
            
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
            var request = new Amazon.Snowball.Model.CreateAddressRequest();
            
            
             // populate Address
            var requestAddressIsNull = true;
            request.Address = new Amazon.Snowball.Model.Address();
            System.String requestAddress_address_AddressId = null;
            if (cmdletContext.Address_AddressId != null)
            {
                requestAddress_address_AddressId = cmdletContext.Address_AddressId;
            }
            if (requestAddress_address_AddressId != null)
            {
                request.Address.AddressId = requestAddress_address_AddressId;
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
            System.String requestAddress_address_Company = null;
            if (cmdletContext.Address_Company != null)
            {
                requestAddress_address_Company = cmdletContext.Address_Company;
            }
            if (requestAddress_address_Company != null)
            {
                request.Address.Company = requestAddress_address_Company;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Country = null;
            if (cmdletContext.Address_Country != null)
            {
                requestAddress_address_Country = cmdletContext.Address_Country;
            }
            if (requestAddress_address_Country != null)
            {
                request.Address.Country = requestAddress_address_Country;
                requestAddressIsNull = false;
            }
            System.Boolean? requestAddress_address_IsRestricted = null;
            if (cmdletContext.Address_IsRestricted != null)
            {
                requestAddress_address_IsRestricted = cmdletContext.Address_IsRestricted.Value;
            }
            if (requestAddress_address_IsRestricted != null)
            {
                request.Address.IsRestricted = requestAddress_address_IsRestricted.Value;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Landmark = null;
            if (cmdletContext.Address_Landmark != null)
            {
                requestAddress_address_Landmark = cmdletContext.Address_Landmark;
            }
            if (requestAddress_address_Landmark != null)
            {
                request.Address.Landmark = requestAddress_address_Landmark;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Name = null;
            if (cmdletContext.Address_Name != null)
            {
                requestAddress_address_Name = cmdletContext.Address_Name;
            }
            if (requestAddress_address_Name != null)
            {
                request.Address.Name = requestAddress_address_Name;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_PhoneNumber = null;
            if (cmdletContext.Address_PhoneNumber != null)
            {
                requestAddress_address_PhoneNumber = cmdletContext.Address_PhoneNumber;
            }
            if (requestAddress_address_PhoneNumber != null)
            {
                request.Address.PhoneNumber = requestAddress_address_PhoneNumber;
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
            System.String requestAddress_address_PrefectureOrDistrict = null;
            if (cmdletContext.Address_PrefectureOrDistrict != null)
            {
                requestAddress_address_PrefectureOrDistrict = cmdletContext.Address_PrefectureOrDistrict;
            }
            if (requestAddress_address_PrefectureOrDistrict != null)
            {
                request.Address.PrefectureOrDistrict = requestAddress_address_PrefectureOrDistrict;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_StateOrProvince = null;
            if (cmdletContext.Address_StateOrProvince != null)
            {
                requestAddress_address_StateOrProvince = cmdletContext.Address_StateOrProvince;
            }
            if (requestAddress_address_StateOrProvince != null)
            {
                request.Address.StateOrProvince = requestAddress_address_StateOrProvince;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Street1 = null;
            if (cmdletContext.Address_Street1 != null)
            {
                requestAddress_address_Street1 = cmdletContext.Address_Street1;
            }
            if (requestAddress_address_Street1 != null)
            {
                request.Address.Street1 = requestAddress_address_Street1;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Street2 = null;
            if (cmdletContext.Address_Street2 != null)
            {
                requestAddress_address_Street2 = cmdletContext.Address_Street2;
            }
            if (requestAddress_address_Street2 != null)
            {
                request.Address.Street2 = requestAddress_address_Street2;
                requestAddressIsNull = false;
            }
            System.String requestAddress_address_Street3 = null;
            if (cmdletContext.Address_Street3 != null)
            {
                requestAddress_address_Street3 = cmdletContext.Address_Street3;
            }
            if (requestAddress_address_Street3 != null)
            {
                request.Address.Street3 = requestAddress_address_Street3;
                requestAddressIsNull = false;
            }
            Amazon.Snowball.AddressType requestAddress_address_Type = null;
            if (cmdletContext.Address_Type != null)
            {
                requestAddress_address_Type = cmdletContext.Address_Type;
            }
            if (requestAddress_address_Type != null)
            {
                request.Address.Type = requestAddress_address_Type;
                requestAddressIsNull = false;
            }
             // determine if request.Address should be set to null
            if (requestAddressIsNull)
            {
                request.Address = null;
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
        
        private Amazon.Snowball.Model.CreateAddressResponse CallAWSServiceOperation(IAmazonSnowball client, Amazon.Snowball.Model.CreateAddressRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Import/Export Snowball", "CreateAddress");
            try
            {
                #if DESKTOP
                return client.CreateAddress(request);
                #elif CORECLR
                return client.CreateAddressAsync(request).GetAwaiter().GetResult();
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
            public System.String Address_AddressId { get; set; }
            public System.String Address_City { get; set; }
            public System.String Address_Company { get; set; }
            public System.String Address_Country { get; set; }
            public System.Boolean? Address_IsRestricted { get; set; }
            public System.String Address_Landmark { get; set; }
            public System.String Address_Name { get; set; }
            public System.String Address_PhoneNumber { get; set; }
            public System.String Address_PostalCode { get; set; }
            public System.String Address_PrefectureOrDistrict { get; set; }
            public System.String Address_StateOrProvince { get; set; }
            public System.String Address_Street1 { get; set; }
            public System.String Address_Street2 { get; set; }
            public System.String Address_Street3 { get; set; }
            public Amazon.Snowball.AddressType Address_Type { get; set; }
            public System.Func<Amazon.Snowball.Model.CreateAddressResponse, NewSNOWAddressCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AddressId;
        }
        
    }
}
