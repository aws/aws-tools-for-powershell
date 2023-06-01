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
using Amazon.AlexaForBusiness;
using Amazon.AlexaForBusiness.Model;

namespace Amazon.PowerShell.Cmdlets.ALXB
{
    /// <summary>
    /// Creates a network profile with the specified details.<br/><br/>This operation is deprecated.
    /// </summary>
    [Cmdlet("New", "ALXBNetworkProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Alexa For Business CreateNetworkProfile API operation.", Operation = new[] {"CreateNetworkProfile"}, SelectReturnType = typeof(Amazon.AlexaForBusiness.Model.CreateNetworkProfileResponse))]
    [AWSCmdletOutput("System.String or Amazon.AlexaForBusiness.Model.CreateNetworkProfileResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.AlexaForBusiness.Model.CreateNetworkProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    [System.ObsoleteAttribute("Alexa For Business is no longer supported")]
    public partial class NewALXBNetworkProfileCmdlet : AmazonAlexaForBusinessClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Private Certificate Authority (PCA) created in AWS Certificate Manager
        /// (ACM). This is used to issue certificates to the devices. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter CurrentPassword
        /// <summary>
        /// <para>
        /// <para>The current password of the Wi-Fi network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CurrentPassword { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Detailed information about a device's network profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EapMethod
        /// <summary>
        /// <para>
        /// <para>The authentication standard that is used in the EAP framework. Currently, EAP_TLS
        /// is supported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.NetworkEapMethod")]
        public Amazon.AlexaForBusiness.NetworkEapMethod EapMethod { get; set; }
        #endregion
        
        #region Parameter NetworkProfileName
        /// <summary>
        /// <para>
        /// <para>The name of the network profile associated with a device.</para>
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
        public System.String NetworkProfileName { get; set; }
        #endregion
        
        #region Parameter NextPassword
        /// <summary>
        /// <para>
        /// <para>The next, or subsequent, password of the Wi-Fi network. This password is asynchronously
        /// transmitted to the device and is used when the password of the network changes to
        /// NextPassword. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextPassword { get; set; }
        #endregion
        
        #region Parameter SecurityType
        /// <summary>
        /// <para>
        /// <para>The security type of the Wi-Fi network. This can be WPA2_ENTERPRISE, WPA2_PSK, WPA_PSK,
        /// WEP, or OPEN.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AlexaForBusiness.NetworkSecurityType")]
        public Amazon.AlexaForBusiness.NetworkSecurityType SecurityType { get; set; }
        #endregion
        
        #region Parameter Ssid
        /// <summary>
        /// <para>
        /// <para>The SSID of the Wi-Fi network.</para>
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
        public System.String Ssid { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be added to the specified resource. Do not provide system tags. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.AlexaForBusiness.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TrustAnchor
        /// <summary>
        /// <para>
        /// <para>The root certificates of your authentication server that is installed on your devices
        /// and used to trust your authentication server during EAP negotiation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TrustAnchors")]
        public System.String[] TrustAnchor { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NetworkProfileArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AlexaForBusiness.Model.CreateNetworkProfileResponse).
        /// Specifying the name of a property of type Amazon.AlexaForBusiness.Model.CreateNetworkProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NetworkProfileArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the NetworkProfileName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^NetworkProfileName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^NetworkProfileName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.NetworkProfileName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ALXBNetworkProfile (CreateNetworkProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AlexaForBusiness.Model.CreateNetworkProfileResponse, NewALXBNetworkProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.NetworkProfileName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            context.ClientRequestToken = this.ClientRequestToken;
            context.CurrentPassword = this.CurrentPassword;
            context.Description = this.Description;
            context.EapMethod = this.EapMethod;
            context.NetworkProfileName = this.NetworkProfileName;
            #if MODULAR
            if (this.NetworkProfileName == null && ParameterWasBound(nameof(this.NetworkProfileName)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkProfileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextPassword = this.NextPassword;
            context.SecurityType = this.SecurityType;
            #if MODULAR
            if (this.SecurityType == null && ParameterWasBound(nameof(this.SecurityType)))
            {
                WriteWarning("You are passing $null as a value for parameter SecurityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Ssid = this.Ssid;
            #if MODULAR
            if (this.Ssid == null && ParameterWasBound(nameof(this.Ssid)))
            {
                WriteWarning("You are passing $null as a value for parameter Ssid which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.AlexaForBusiness.Model.Tag>(this.Tag);
            }
            if (this.TrustAnchor != null)
            {
                context.TrustAnchor = new List<System.String>(this.TrustAnchor);
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
            var request = new Amazon.AlexaForBusiness.Model.CreateNetworkProfileRequest();
            
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.CurrentPassword != null)
            {
                request.CurrentPassword = cmdletContext.CurrentPassword;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EapMethod != null)
            {
                request.EapMethod = cmdletContext.EapMethod;
            }
            if (cmdletContext.NetworkProfileName != null)
            {
                request.NetworkProfileName = cmdletContext.NetworkProfileName;
            }
            if (cmdletContext.NextPassword != null)
            {
                request.NextPassword = cmdletContext.NextPassword;
            }
            if (cmdletContext.SecurityType != null)
            {
                request.SecurityType = cmdletContext.SecurityType;
            }
            if (cmdletContext.Ssid != null)
            {
                request.Ssid = cmdletContext.Ssid;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrustAnchor != null)
            {
                request.TrustAnchors = cmdletContext.TrustAnchor;
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
        
        private Amazon.AlexaForBusiness.Model.CreateNetworkProfileResponse CallAWSServiceOperation(IAmazonAlexaForBusiness client, Amazon.AlexaForBusiness.Model.CreateNetworkProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Alexa For Business", "CreateNetworkProfile");
            try
            {
                #if DESKTOP
                return client.CreateNetworkProfile(request);
                #elif CORECLR
                return client.CreateNetworkProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String CertificateAuthorityArn { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.String CurrentPassword { get; set; }
            public System.String Description { get; set; }
            public Amazon.AlexaForBusiness.NetworkEapMethod EapMethod { get; set; }
            public System.String NetworkProfileName { get; set; }
            public System.String NextPassword { get; set; }
            public Amazon.AlexaForBusiness.NetworkSecurityType SecurityType { get; set; }
            public System.String Ssid { get; set; }
            public List<Amazon.AlexaForBusiness.Model.Tag> Tag { get; set; }
            public List<System.String> TrustAnchor { get; set; }
            public System.Func<Amazon.AlexaForBusiness.Model.CreateNetworkProfileResponse, NewALXBNetworkProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NetworkProfileArn;
        }
        
    }
}
