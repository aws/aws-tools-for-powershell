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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Creates an Network Firewall TLS inspection configuration. Network Firewall uses TLS
    /// inspection configurations to decrypt your firewall's inbound and outbound SSL/TLS
    /// traffic. After decryption, Network Firewall inspects the traffic according to your
    /// firewall policy's stateful rules, and then re-encrypts it before sending it to its
    /// destination. You can enable inspection of your firewall's inbound traffic, outbound
    /// traffic, or both. To use TLS inspection with your firewall, you must first import
    /// or provision certificates using ACM, create a TLS inspection configuration, add that
    /// configuration to a new firewall policy, and then associate that policy with your firewall.
    /// 
    ///  
    /// <para>
    /// To update the settings for a TLS inspection configuration, use <a>UpdateTLSInspectionConfiguration</a>.
    /// </para><para>
    /// To manage a TLS inspection configuration's tags, use the standard Amazon Web Services
    /// resource tagging operations, <a>ListTagsForResource</a>, <a>TagResource</a>, and <a>UntagResource</a>.
    /// </para><para>
    /// To retrieve information about TLS inspection configurations, use <a>ListTLSInspectionConfigurations</a>
    /// and <a>DescribeTLSInspectionConfiguration</a>.
    /// </para><para>
    ///  For more information about TLS inspection configurations, see <a href="https://docs.aws.amazon.com/network-firewall/latest/developerguide/tls-inspection.html">Inspecting
    /// SSL/TLS traffic with TLS inspection configurations</a> in the <i>Network Firewall
    /// Developer Guide</i>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "NWFWTLSInspectionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall CreateTLSInspectionConfiguration API operation.", Operation = new[] {"CreateTLSInspectionConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse object containing multiple properties."
    )]
    public partial class NewNWFWTLSInspectionConfigurationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the TLS inspection configuration. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Key Management Service (KMS) customer managed key.
        /// You can use any of the key identifiers that KMS supports, unless you're using a key
        /// that's managed by another account. If you're using a key managed by another account,
        /// then specify the key ARN. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id">Key
        /// ID</a> in the <i>Amazon Web Services KMS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KeyId { get; set; }
        #endregion
        
        #region Parameter TLSInspectionConfiguration_ServerCertificateConfiguration
        /// <summary>
        /// <para>
        /// <para>Lists the server certificate configurations that are associated with the TLS configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TLSInspectionConfiguration_ServerCertificateConfigurations")]
        public Amazon.NetworkFirewall.Model.ServerCertificateConfiguration[] TLSInspectionConfiguration_ServerCertificateConfiguration { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key:value pairs to associate with the resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkFirewall.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TLSInspectionConfigurationName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the TLS inspection configuration. You can't change the name
        /// of a TLS inspection configuration after you create it.</para>
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
        public System.String TLSInspectionConfigurationName { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services KMS key to use for encryption of your Network Firewall
        /// resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.EncryptionType")]
        public Amazon.NetworkFirewall.EncryptionType EncryptionConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TLSInspectionConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NWFWTLSInspectionConfiguration (CreateTLSInspectionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse, NewNWFWTLSInspectionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.EncryptionConfiguration_KeyId = this.EncryptionConfiguration_KeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkFirewall.Model.Tag>(this.Tag);
            }
            if (this.TLSInspectionConfiguration_ServerCertificateConfiguration != null)
            {
                context.TLSInspectionConfiguration_ServerCertificateConfiguration = new List<Amazon.NetworkFirewall.Model.ServerCertificateConfiguration>(this.TLSInspectionConfiguration_ServerCertificateConfiguration);
            }
            context.TLSInspectionConfigurationName = this.TLSInspectionConfigurationName;
            #if MODULAR
            if (this.TLSInspectionConfigurationName == null && ParameterWasBound(nameof(this.TLSInspectionConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter TLSInspectionConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.NetworkFirewall.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KeyId = null;
            if (cmdletContext.EncryptionConfiguration_KeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KeyId = cmdletContext.EncryptionConfiguration_KeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KeyId != null)
            {
                request.EncryptionConfiguration.KeyId = requestEncryptionConfiguration_encryptionConfiguration_KeyId;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.NetworkFirewall.EncryptionType requestEncryptionConfiguration_encryptionConfiguration_Type = null;
            if (cmdletContext.EncryptionConfiguration_Type != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_Type = cmdletContext.EncryptionConfiguration_Type;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_Type != null)
            {
                request.EncryptionConfiguration.Type = requestEncryptionConfiguration_encryptionConfiguration_Type;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TLSInspectionConfiguration
            var requestTLSInspectionConfigurationIsNull = true;
            request.TLSInspectionConfiguration = new Amazon.NetworkFirewall.Model.TLSInspectionConfiguration();
            List<Amazon.NetworkFirewall.Model.ServerCertificateConfiguration> requestTLSInspectionConfiguration_tLSInspectionConfiguration_ServerCertificateConfiguration = null;
            if (cmdletContext.TLSInspectionConfiguration_ServerCertificateConfiguration != null)
            {
                requestTLSInspectionConfiguration_tLSInspectionConfiguration_ServerCertificateConfiguration = cmdletContext.TLSInspectionConfiguration_ServerCertificateConfiguration;
            }
            if (requestTLSInspectionConfiguration_tLSInspectionConfiguration_ServerCertificateConfiguration != null)
            {
                request.TLSInspectionConfiguration.ServerCertificateConfigurations = requestTLSInspectionConfiguration_tLSInspectionConfiguration_ServerCertificateConfiguration;
                requestTLSInspectionConfigurationIsNull = false;
            }
             // determine if request.TLSInspectionConfiguration should be set to null
            if (requestTLSInspectionConfigurationIsNull)
            {
                request.TLSInspectionConfiguration = null;
            }
            if (cmdletContext.TLSInspectionConfigurationName != null)
            {
                request.TLSInspectionConfigurationName = cmdletContext.TLSInspectionConfigurationName;
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
        
        private Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "CreateTLSInspectionConfiguration");
            try
            {
                return client.CreateTLSInspectionConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String EncryptionConfiguration_KeyId { get; set; }
            public Amazon.NetworkFirewall.EncryptionType EncryptionConfiguration_Type { get; set; }
            public List<Amazon.NetworkFirewall.Model.Tag> Tag { get; set; }
            public List<Amazon.NetworkFirewall.Model.ServerCertificateConfiguration> TLSInspectionConfiguration_ServerCertificateConfiguration { get; set; }
            public System.String TLSInspectionConfigurationName { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.CreateTLSInspectionConfigurationResponse, NewNWFWTLSInspectionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
