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
using Amazon.PcaConnectorScep;
using Amazon.PcaConnectorScep.Model;

namespace Amazon.PowerShell.Cmdlets.PCASCEP
{
    /// <summary>
    /// Creates a SCEP connector. A SCEP connector links Amazon Web Services Private Certificate
    /// Authority to your SCEP-compatible devices and mobile device management (MDM) systems.
    /// Before you create a connector, you must complete a set of prerequisites, including
    /// creation of a private certificate authority (CA) to use with this connector. For more
    /// information, see <a href="https://docs.aws.amazon.com/privateca/latest/userguide/scep-connector.htmlconnector-for-scep-prerequisites.html">Connector
    /// for SCEP prerequisites</a>.
    /// </summary>
    [Cmdlet("New", "PCASCEPConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Private CA Connector for SCEP CreateConnector API operation.", Operation = new[] {"CreateConnector"}, SelectReturnType = typeof(Amazon.PcaConnectorScep.Model.CreateConnectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.PcaConnectorScep.Model.CreateConnectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.PcaConnectorScep.Model.CreateConnectorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPCASCEPConnectorCmdlet : AmazonPcaConnectorScepClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Intune_AzureApplicationId
        /// <summary>
        /// <para>
        /// <para>The directory (tenant) ID from your Microsoft Entra ID app registration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MobileDeviceManagement_Intune_AzureApplicationId")]
        public System.String Intune_AzureApplicationId { get; set; }
        #endregion
        
        #region Parameter CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Private Certificate Authority
        /// certificate authority to use with this connector. Due to security vulnerabilities
        /// present in the SCEP protocol, we recommend using a private CA that's dedicated for
        /// use with the connector.</para><para>To retrieve the private CAs associated with your account, you can call <a href="https://docs.aws.amazon.com/privateca/latest/APIReference/API_ListCertificateAuthorities.html">ListCertificateAuthorities</a>
        /// using the Amazon Web Services Private CA API.</para>
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
        public System.String CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter Intune_Domain
        /// <summary>
        /// <para>
        /// <para>The primary domain from your Microsoft Entra ID app registration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MobileDeviceManagement_Intune_Domain")]
        public System.String Intune_Domain { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value pairs to associate with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Custom string that can be used to distinguish between calls to the <a href="https://docs.aws.amazon.com/C4SCEP_API/pca-connector-scep/latest/APIReference/API_CreateChallenge.html">CreateChallenge</a>
        /// action. Client tokens for <c>CreateChallenge</c> time out after five minutes. Therefore,
        /// if you call <c>CreateChallenge</c> multiple times with the same client token within
        /// five minutes, Connector for SCEP recognizes that you are requesting only one challenge
        /// and will only respond with one. If you change the client token for each call, Connector
        /// for SCEP recognizes that you are requesting multiple challenge passwords.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PcaConnectorScep.Model.CreateConnectorResponse).
        /// Specifying the name of a property of type Amazon.PcaConnectorScep.Model.CreateConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CertificateAuthorityArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CertificateAuthorityArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CertificateAuthorityArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CertificateAuthorityArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PCASCEPConnector (CreateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PcaConnectorScep.Model.CreateConnectorResponse, NewPCASCEPConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CertificateAuthorityArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CertificateAuthorityArn = this.CertificateAuthorityArn;
            #if MODULAR
            if (this.CertificateAuthorityArn == null && ParameterWasBound(nameof(this.CertificateAuthorityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateAuthorityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Intune_AzureApplicationId = this.Intune_AzureApplicationId;
            context.Intune_Domain = this.Intune_Domain;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.PcaConnectorScep.Model.CreateConnectorRequest();
            
            if (cmdletContext.CertificateAuthorityArn != null)
            {
                request.CertificateAuthorityArn = cmdletContext.CertificateAuthorityArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate MobileDeviceManagement
            var requestMobileDeviceManagementIsNull = true;
            request.MobileDeviceManagement = new Amazon.PcaConnectorScep.Model.MobileDeviceManagement();
            Amazon.PcaConnectorScep.Model.IntuneConfiguration requestMobileDeviceManagement_mobileDeviceManagement_Intune = null;
            
             // populate Intune
            var requestMobileDeviceManagement_mobileDeviceManagement_IntuneIsNull = true;
            requestMobileDeviceManagement_mobileDeviceManagement_Intune = new Amazon.PcaConnectorScep.Model.IntuneConfiguration();
            System.String requestMobileDeviceManagement_mobileDeviceManagement_Intune_intune_AzureApplicationId = null;
            if (cmdletContext.Intune_AzureApplicationId != null)
            {
                requestMobileDeviceManagement_mobileDeviceManagement_Intune_intune_AzureApplicationId = cmdletContext.Intune_AzureApplicationId;
            }
            if (requestMobileDeviceManagement_mobileDeviceManagement_Intune_intune_AzureApplicationId != null)
            {
                requestMobileDeviceManagement_mobileDeviceManagement_Intune.AzureApplicationId = requestMobileDeviceManagement_mobileDeviceManagement_Intune_intune_AzureApplicationId;
                requestMobileDeviceManagement_mobileDeviceManagement_IntuneIsNull = false;
            }
            System.String requestMobileDeviceManagement_mobileDeviceManagement_Intune_intune_Domain = null;
            if (cmdletContext.Intune_Domain != null)
            {
                requestMobileDeviceManagement_mobileDeviceManagement_Intune_intune_Domain = cmdletContext.Intune_Domain;
            }
            if (requestMobileDeviceManagement_mobileDeviceManagement_Intune_intune_Domain != null)
            {
                requestMobileDeviceManagement_mobileDeviceManagement_Intune.Domain = requestMobileDeviceManagement_mobileDeviceManagement_Intune_intune_Domain;
                requestMobileDeviceManagement_mobileDeviceManagement_IntuneIsNull = false;
            }
             // determine if requestMobileDeviceManagement_mobileDeviceManagement_Intune should be set to null
            if (requestMobileDeviceManagement_mobileDeviceManagement_IntuneIsNull)
            {
                requestMobileDeviceManagement_mobileDeviceManagement_Intune = null;
            }
            if (requestMobileDeviceManagement_mobileDeviceManagement_Intune != null)
            {
                request.MobileDeviceManagement.Intune = requestMobileDeviceManagement_mobileDeviceManagement_Intune;
                requestMobileDeviceManagementIsNull = false;
            }
             // determine if request.MobileDeviceManagement should be set to null
            if (requestMobileDeviceManagementIsNull)
            {
                request.MobileDeviceManagement = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PcaConnectorScep.Model.CreateConnectorResponse CallAWSServiceOperation(IAmazonPcaConnectorScep client, Amazon.PcaConnectorScep.Model.CreateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Private CA Connector for SCEP", "CreateConnector");
            try
            {
                #if DESKTOP
                return client.CreateConnector(request);
                #elif CORECLR
                return client.CreateConnectorAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Intune_AzureApplicationId { get; set; }
            public System.String Intune_Domain { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.PcaConnectorScep.Model.CreateConnectorResponse, NewPCASCEPConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorArn;
        }
        
    }
}
