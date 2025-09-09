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
    /// Updates the TLS inspection configuration settings for the specified TLS inspection
    /// configuration. You use a TLS inspection configuration by referencing it in one or
    /// more firewall policies. When you modify a TLS inspection configuration, you modify
    /// all firewall policies that use the TLS inspection configuration. 
    /// 
    ///  
    /// <para>
    /// To update a TLS inspection configuration, first call <a>DescribeTLSInspectionConfiguration</a>
    /// to retrieve the current <a>TLSInspectionConfiguration</a> object, update the object
    /// as needed, and then provide the updated object to this call. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "NWFWTLSInspectionConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall UpdateTLSInspectionConfiguration API operation.", Operation = new[] {"UpdateTLSInspectionConfiguration"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateNWFWTLSInspectionConfigurationCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
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
        
        #region Parameter TLSInspectionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the TLS inspection configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TLSInspectionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter TLSInspectionConfigurationName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the TLS inspection configuration. You can't change the name
        /// of a TLS inspection configuration after you create it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter UpdateToken
        /// <summary>
        /// <para>
        /// <para>A token used for optimistic locking. Network Firewall returns a token to your requests
        /// that access the TLS inspection configuration. The token marks the state of the TLS
        /// inspection configuration resource at the time of the request. </para><para>To make changes to the TLS inspection configuration, you provide the token in your
        /// request. Network Firewall uses the token to ensure that the TLS inspection configuration
        /// hasn't changed since you last retrieved it. If it has changed, the operation fails
        /// with an <c>InvalidTokenException</c>. If this happens, retrieve the TLS inspection
        /// configuration again to get a current copy of it with a current token. Reapply your
        /// changes as needed, then try the operation again using the new token. </para>
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
        public System.String UpdateToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UpdateToken), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NWFWTLSInspectionConfiguration (UpdateTLSInspectionConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse, UpdateNWFWTLSInspectionConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.EncryptionConfiguration_KeyId = this.EncryptionConfiguration_KeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            if (this.TLSInspectionConfiguration_ServerCertificateConfiguration != null)
            {
                context.TLSInspectionConfiguration_ServerCertificateConfiguration = new List<Amazon.NetworkFirewall.Model.ServerCertificateConfiguration>(this.TLSInspectionConfiguration_ServerCertificateConfiguration);
            }
            context.TLSInspectionConfigurationArn = this.TLSInspectionConfigurationArn;
            context.TLSInspectionConfigurationName = this.TLSInspectionConfigurationName;
            context.UpdateToken = this.UpdateToken;
            #if MODULAR
            if (this.UpdateToken == null && ParameterWasBound(nameof(this.UpdateToken)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationRequest();
            
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
            
             // populate TLSInspectionConfiguration
            request.TLSInspectionConfiguration = new Amazon.NetworkFirewall.Model.TLSInspectionConfiguration();
            List<Amazon.NetworkFirewall.Model.ServerCertificateConfiguration> requestTLSInspectionConfiguration_tLSInspectionConfiguration_ServerCertificateConfiguration = null;
            if (cmdletContext.TLSInspectionConfiguration_ServerCertificateConfiguration != null)
            {
                requestTLSInspectionConfiguration_tLSInspectionConfiguration_ServerCertificateConfiguration = cmdletContext.TLSInspectionConfiguration_ServerCertificateConfiguration;
            }
            if (requestTLSInspectionConfiguration_tLSInspectionConfiguration_ServerCertificateConfiguration != null)
            {
                request.TLSInspectionConfiguration.ServerCertificateConfigurations = requestTLSInspectionConfiguration_tLSInspectionConfiguration_ServerCertificateConfiguration;
            }
            if (cmdletContext.TLSInspectionConfigurationArn != null)
            {
                request.TLSInspectionConfigurationArn = cmdletContext.TLSInspectionConfigurationArn;
            }
            if (cmdletContext.TLSInspectionConfigurationName != null)
            {
                request.TLSInspectionConfigurationName = cmdletContext.TLSInspectionConfigurationName;
            }
            if (cmdletContext.UpdateToken != null)
            {
                request.UpdateToken = cmdletContext.UpdateToken;
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
        
        private Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "UpdateTLSInspectionConfiguration");
            try
            {
                return client.UpdateTLSInspectionConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.NetworkFirewall.Model.ServerCertificateConfiguration> TLSInspectionConfiguration_ServerCertificateConfiguration { get; set; }
            public System.String TLSInspectionConfigurationArn { get; set; }
            public System.String TLSInspectionConfigurationName { get; set; }
            public System.String UpdateToken { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.UpdateTLSInspectionConfigurationResponse, UpdateNWFWTLSInspectionConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
