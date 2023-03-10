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
using Amazon.Private5G;
using Amazon.Private5G.Model;

namespace Amazon.PowerShell.Cmdlets.PV5G
{
    /// <summary>
    /// Starts an update of the specified network resource.
    /// 
    ///  
    /// <para>
    /// After you submit a request to replace or return a network resource, the status of
    /// the network resource is <code>CREATING_SHIPPING_LABEL</code>. The shipping label is
    /// available when the status of the network resource is <code>PENDING_RETURN</code>.
    /// After the network resource is successfully returned, its status is <code>DELETED</code>.
    /// For more information, see <a href="https://docs.aws.amazon.com/private-networks/latest/userguide/radio-units.html#return-radio-unit">Return
    /// a radio unit</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "PV5GNetworkResourceUpdate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Private5G.Model.NetworkResource")]
    [AWSCmdlet("Calls the AWS Private 5G StartNetworkResourceUpdate API operation.", Operation = new[] {"StartNetworkResourceUpdate"}, SelectReturnType = typeof(Amazon.Private5G.Model.StartNetworkResourceUpdateResponse))]
    [AWSCmdletOutput("Amazon.Private5G.Model.NetworkResource or Amazon.Private5G.Model.StartNetworkResourceUpdateResponse",
        "This cmdlet returns an Amazon.Private5G.Model.NetworkResource object.",
        "The service call response (type Amazon.Private5G.Model.StartNetworkResourceUpdateResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartPV5GNetworkResourceUpdateCmdlet : AmazonPrivate5GClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter ShippingAddress_City
        /// <summary>
        /// <para>
        /// <para>The city for this address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_City { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Company
        /// <summary>
        /// <para>
        /// <para>The company name for this address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Company { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Country
        /// <summary>
        /// <para>
        /// <para>The country for this address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Country { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Name
        /// <summary>
        /// <para>
        /// <para>The recipient's name for this address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Name { get; set; }
        #endregion
        
        #region Parameter NetworkResourceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network resource.</para>
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
        public System.String NetworkResourceArn { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_PhoneNumber
        /// <summary>
        /// <para>
        /// <para>The phone number for this address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_PhoneNumber { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_PostalCode
        /// <summary>
        /// <para>
        /// <para>The postal code for this address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_PostalCode { get; set; }
        #endregion
        
        #region Parameter ReturnReason
        /// <summary>
        /// <para>
        /// <para>The reason for the return. Providing a reason for a return is optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ReturnReason { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_StateOrProvince
        /// <summary>
        /// <para>
        /// <para>The state or province for this address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_StateOrProvince { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Street1
        /// <summary>
        /// <para>
        /// <para>The first line of the street address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Street1 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Street2
        /// <summary>
        /// <para>
        /// <para>The second line of the street address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Street2 { get; set; }
        #endregion
        
        #region Parameter ShippingAddress_Street3
        /// <summary>
        /// <para>
        /// <para>The third line of the street address.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ShippingAddress_Street3 { get; set; }
        #endregion
        
        #region Parameter UpdateType
        /// <summary>
        /// <para>
        /// <para>The update type.</para><ul><li><para><code>REPLACE</code> - Submits a request to replace a defective radio unit. We provide
        /// a shipping label that you can use for the return process and we ship a replacement
        /// radio unit to you.</para></li><li><para><code>RETURN</code> - Submits a request to replace a radio unit that you no longer
        /// need. We provide a shipping label that you can use for the return process.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Private5G.UpdateType")]
        public Amazon.Private5G.UpdateType UpdateType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkResource'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Private5G.Model.StartNetworkResourceUpdateResponse).
        /// Specifying the name of a property of type Amazon.Private5G.Model.StartNetworkResourceUpdateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkResource";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkResourceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkResourceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkResourceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-PV5GNetworkResourceUpdate (StartNetworkResourceUpdate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Private5G.Model.StartNetworkResourceUpdateResponse, StartPV5GNetworkResourceUpdateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkResourceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.NetworkResourceArn = this.NetworkResourceArn;
            #if MODULAR
            if (this.NetworkResourceArn == null && ParameterWasBound(nameof(this.NetworkResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReturnReason = this.ReturnReason;
            context.ShippingAddress_City = this.ShippingAddress_City;
            context.ShippingAddress_Company = this.ShippingAddress_Company;
            context.ShippingAddress_Country = this.ShippingAddress_Country;
            context.ShippingAddress_Name = this.ShippingAddress_Name;
            context.ShippingAddress_PhoneNumber = this.ShippingAddress_PhoneNumber;
            context.ShippingAddress_PostalCode = this.ShippingAddress_PostalCode;
            context.ShippingAddress_StateOrProvince = this.ShippingAddress_StateOrProvince;
            context.ShippingAddress_Street1 = this.ShippingAddress_Street1;
            context.ShippingAddress_Street2 = this.ShippingAddress_Street2;
            context.ShippingAddress_Street3 = this.ShippingAddress_Street3;
            context.UpdateType = this.UpdateType;
            #if MODULAR
            if (this.UpdateType == null && ParameterWasBound(nameof(this.UpdateType)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Private5G.Model.StartNetworkResourceUpdateRequest();
            
            if (cmdletContext.NetworkResourceArn != null)
            {
                request.NetworkResourceArn = cmdletContext.NetworkResourceArn;
            }
            if (cmdletContext.ReturnReason != null)
            {
                request.ReturnReason = cmdletContext.ReturnReason;
            }
            
             // populate ShippingAddress
            var requestShippingAddressIsNull = true;
            request.ShippingAddress = new Amazon.Private5G.Model.Address();
            System.String requestShippingAddress_shippingAddress_City = null;
            if (cmdletContext.ShippingAddress_City != null)
            {
                requestShippingAddress_shippingAddress_City = cmdletContext.ShippingAddress_City;
            }
            if (requestShippingAddress_shippingAddress_City != null)
            {
                request.ShippingAddress.City = requestShippingAddress_shippingAddress_City;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Company = null;
            if (cmdletContext.ShippingAddress_Company != null)
            {
                requestShippingAddress_shippingAddress_Company = cmdletContext.ShippingAddress_Company;
            }
            if (requestShippingAddress_shippingAddress_Company != null)
            {
                request.ShippingAddress.Company = requestShippingAddress_shippingAddress_Company;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Country = null;
            if (cmdletContext.ShippingAddress_Country != null)
            {
                requestShippingAddress_shippingAddress_Country = cmdletContext.ShippingAddress_Country;
            }
            if (requestShippingAddress_shippingAddress_Country != null)
            {
                request.ShippingAddress.Country = requestShippingAddress_shippingAddress_Country;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Name = null;
            if (cmdletContext.ShippingAddress_Name != null)
            {
                requestShippingAddress_shippingAddress_Name = cmdletContext.ShippingAddress_Name;
            }
            if (requestShippingAddress_shippingAddress_Name != null)
            {
                request.ShippingAddress.Name = requestShippingAddress_shippingAddress_Name;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_PhoneNumber = null;
            if (cmdletContext.ShippingAddress_PhoneNumber != null)
            {
                requestShippingAddress_shippingAddress_PhoneNumber = cmdletContext.ShippingAddress_PhoneNumber;
            }
            if (requestShippingAddress_shippingAddress_PhoneNumber != null)
            {
                request.ShippingAddress.PhoneNumber = requestShippingAddress_shippingAddress_PhoneNumber;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_PostalCode = null;
            if (cmdletContext.ShippingAddress_PostalCode != null)
            {
                requestShippingAddress_shippingAddress_PostalCode = cmdletContext.ShippingAddress_PostalCode;
            }
            if (requestShippingAddress_shippingAddress_PostalCode != null)
            {
                request.ShippingAddress.PostalCode = requestShippingAddress_shippingAddress_PostalCode;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_StateOrProvince = null;
            if (cmdletContext.ShippingAddress_StateOrProvince != null)
            {
                requestShippingAddress_shippingAddress_StateOrProvince = cmdletContext.ShippingAddress_StateOrProvince;
            }
            if (requestShippingAddress_shippingAddress_StateOrProvince != null)
            {
                request.ShippingAddress.StateOrProvince = requestShippingAddress_shippingAddress_StateOrProvince;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Street1 = null;
            if (cmdletContext.ShippingAddress_Street1 != null)
            {
                requestShippingAddress_shippingAddress_Street1 = cmdletContext.ShippingAddress_Street1;
            }
            if (requestShippingAddress_shippingAddress_Street1 != null)
            {
                request.ShippingAddress.Street1 = requestShippingAddress_shippingAddress_Street1;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Street2 = null;
            if (cmdletContext.ShippingAddress_Street2 != null)
            {
                requestShippingAddress_shippingAddress_Street2 = cmdletContext.ShippingAddress_Street2;
            }
            if (requestShippingAddress_shippingAddress_Street2 != null)
            {
                request.ShippingAddress.Street2 = requestShippingAddress_shippingAddress_Street2;
                requestShippingAddressIsNull = false;
            }
            System.String requestShippingAddress_shippingAddress_Street3 = null;
            if (cmdletContext.ShippingAddress_Street3 != null)
            {
                requestShippingAddress_shippingAddress_Street3 = cmdletContext.ShippingAddress_Street3;
            }
            if (requestShippingAddress_shippingAddress_Street3 != null)
            {
                request.ShippingAddress.Street3 = requestShippingAddress_shippingAddress_Street3;
                requestShippingAddressIsNull = false;
            }
             // determine if request.ShippingAddress should be set to null
            if (requestShippingAddressIsNull)
            {
                request.ShippingAddress = null;
            }
            if (cmdletContext.UpdateType != null)
            {
                request.UpdateType = cmdletContext.UpdateType;
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
        
        private Amazon.Private5G.Model.StartNetworkResourceUpdateResponse CallAWSServiceOperation(IAmazonPrivate5G client, Amazon.Private5G.Model.StartNetworkResourceUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Private 5G", "StartNetworkResourceUpdate");
            try
            {
                #if DESKTOP
                return client.StartNetworkResourceUpdate(request);
                #elif CORECLR
                return client.StartNetworkResourceUpdateAsync(request).GetAwaiter().GetResult();
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
            public System.String NetworkResourceArn { get; set; }
            public System.String ReturnReason { get; set; }
            public System.String ShippingAddress_City { get; set; }
            public System.String ShippingAddress_Company { get; set; }
            public System.String ShippingAddress_Country { get; set; }
            public System.String ShippingAddress_Name { get; set; }
            public System.String ShippingAddress_PhoneNumber { get; set; }
            public System.String ShippingAddress_PostalCode { get; set; }
            public System.String ShippingAddress_StateOrProvince { get; set; }
            public System.String ShippingAddress_Street1 { get; set; }
            public System.String ShippingAddress_Street2 { get; set; }
            public System.String ShippingAddress_Street3 { get; set; }
            public Amazon.Private5G.UpdateType UpdateType { get; set; }
            public System.Func<Amazon.Private5G.Model.StartNetworkResourceUpdateResponse, StartPV5GNetworkResourceUpdateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkResource;
        }
        
    }
}
