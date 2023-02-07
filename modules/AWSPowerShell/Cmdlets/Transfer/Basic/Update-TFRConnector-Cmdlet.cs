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
using Amazon.Transfer;
using Amazon.Transfer.Model;

namespace Amazon.PowerShell.Cmdlets.TFR
{
    /// <summary>
    /// Updates some of the parameters for an existing connector. Provide the <code>ConnectorId</code>
    /// for the connector that you want to update, along with the new values for the parameters
    /// to update.
    /// </summary>
    [Cmdlet("Update", "TFRConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP UpdateConnector API operation.", Operation = new[] {"UpdateConnector"}, SelectReturnType = typeof(Amazon.Transfer.Model.UpdateConnectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.UpdateConnectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.UpdateConnectorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateTFRConnectorCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        #region Parameter AccessRole
        /// <summary>
        /// <para>
        /// <para>With AS2, you can send files by calling <code>StartFileTransfer</code> and specifying
        /// the file paths in the request parameter, <code>SendFilePaths</code>. We use the file’s
        /// parent directory (for example, for <code>--send-file-paths /bucket/dir/file.txt</code>,
        /// parent directory is <code>/bucket/dir/</code>) to temporarily store a processed AS2
        /// message file, store the MDN when we receive them from the partner, and write a final
        /// JSON file containing relevant metadata of the transmission. So, the <code>AccessRole</code>
        /// needs to provide read and write access to the parent directory of the file location
        /// used in the <code>StartFileTransfer</code> request. Additionally, you need to provide
        /// read and write access to the parent directory of the files that you intend to send
        /// with <code>StartFileTransfer</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessRole { get; set; }
        #endregion
        
        #region Parameter As2Config_Compression
        /// <summary>
        /// <para>
        /// <para>Specifies whether the AS2 file is compressed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.CompressionEnum")]
        public Amazon.Transfer.CompressionEnum As2Config_Compression { get; set; }
        #endregion
        
        #region Parameter ConnectorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the connector.</para>
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
        public System.String ConnectorId { get; set; }
        #endregion
        
        #region Parameter As2Config_EncryptionAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm that is used to encrypt the file.</para><note><para>You can only specify <code>NONE</code> if the URL for your connector uses HTTPS. This
        /// ensures that no traffic is sent in clear text.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.EncryptionAlg")]
        public Amazon.Transfer.EncryptionAlg As2Config_EncryptionAlgorithm { get; set; }
        #endregion
        
        #region Parameter As2Config_LocalProfileId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the AS2 local profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String As2Config_LocalProfileId { get; set; }
        #endregion
        
        #region Parameter LoggingRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role that
        /// allows a connector to turn on CloudWatch logging for Amazon S3 events. When set, you
        /// can view connector activity in your CloudWatch logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingRole { get; set; }
        #endregion
        
        #region Parameter As2Config_MdnResponse
        /// <summary>
        /// <para>
        /// <para>Used for outbound requests (from an Transfer Family server to a partner AS2 server)
        /// to determine whether the partner response for transfers is synchronous or asynchronous.
        /// Specify either of the following values:</para><ul><li><para><code>SYNC</code>: The system expects a synchronous MDN response, confirming that
        /// the file was transferred successfully (or not).</para></li><li><para><code>NONE</code>: Specifies that no MDN response is required.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.MdnResponse")]
        public Amazon.Transfer.MdnResponse As2Config_MdnResponse { get; set; }
        #endregion
        
        #region Parameter As2Config_MdnSigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The signing algorithm for the MDN response.</para><note><para>If set to DEFAULT (or not set at all), the value for <code>SigningAlgorithm</code>
        /// is used.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.MdnSigningAlg")]
        public Amazon.Transfer.MdnSigningAlg As2Config_MdnSigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter As2Config_MessageSubject
        /// <summary>
        /// <para>
        /// <para>Used as the <code>Subject</code> HTTP header attribute in AS2 messages that are being
        /// sent with the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String As2Config_MessageSubject { get; set; }
        #endregion
        
        #region Parameter As2Config_PartnerProfileId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the partner profile for the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String As2Config_PartnerProfileId { get; set; }
        #endregion
        
        #region Parameter As2Config_SigningAlgorithm
        /// <summary>
        /// <para>
        /// <para>The algorithm that is used to sign the AS2 messages sent with the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.SigningAlg")]
        public Amazon.Transfer.SigningAlg As2Config_SigningAlgorithm { get; set; }
        #endregion
        
        #region Parameter Url
        /// <summary>
        /// <para>
        /// <para>The URL of the partner's AS2 endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Url { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.UpdateConnectorResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.UpdateConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConnectorId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConnectorId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConnectorId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TFRConnector (UpdateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.UpdateConnectorResponse, UpdateTFRConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConnectorId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessRole = this.AccessRole;
            context.As2Config_Compression = this.As2Config_Compression;
            context.As2Config_EncryptionAlgorithm = this.As2Config_EncryptionAlgorithm;
            context.As2Config_LocalProfileId = this.As2Config_LocalProfileId;
            context.As2Config_MdnResponse = this.As2Config_MdnResponse;
            context.As2Config_MdnSigningAlgorithm = this.As2Config_MdnSigningAlgorithm;
            context.As2Config_MessageSubject = this.As2Config_MessageSubject;
            context.As2Config_PartnerProfileId = this.As2Config_PartnerProfileId;
            context.As2Config_SigningAlgorithm = this.As2Config_SigningAlgorithm;
            context.ConnectorId = this.ConnectorId;
            #if MODULAR
            if (this.ConnectorId == null && ParameterWasBound(nameof(this.ConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggingRole = this.LoggingRole;
            context.Url = this.Url;
            
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
            var request = new Amazon.Transfer.Model.UpdateConnectorRequest();
            
            if (cmdletContext.AccessRole != null)
            {
                request.AccessRole = cmdletContext.AccessRole;
            }
            
             // populate As2Config
            var requestAs2ConfigIsNull = true;
            request.As2Config = new Amazon.Transfer.Model.As2ConnectorConfig();
            Amazon.Transfer.CompressionEnum requestAs2Config_as2Config_Compression = null;
            if (cmdletContext.As2Config_Compression != null)
            {
                requestAs2Config_as2Config_Compression = cmdletContext.As2Config_Compression;
            }
            if (requestAs2Config_as2Config_Compression != null)
            {
                request.As2Config.Compression = requestAs2Config_as2Config_Compression;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.EncryptionAlg requestAs2Config_as2Config_EncryptionAlgorithm = null;
            if (cmdletContext.As2Config_EncryptionAlgorithm != null)
            {
                requestAs2Config_as2Config_EncryptionAlgorithm = cmdletContext.As2Config_EncryptionAlgorithm;
            }
            if (requestAs2Config_as2Config_EncryptionAlgorithm != null)
            {
                request.As2Config.EncryptionAlgorithm = requestAs2Config_as2Config_EncryptionAlgorithm;
                requestAs2ConfigIsNull = false;
            }
            System.String requestAs2Config_as2Config_LocalProfileId = null;
            if (cmdletContext.As2Config_LocalProfileId != null)
            {
                requestAs2Config_as2Config_LocalProfileId = cmdletContext.As2Config_LocalProfileId;
            }
            if (requestAs2Config_as2Config_LocalProfileId != null)
            {
                request.As2Config.LocalProfileId = requestAs2Config_as2Config_LocalProfileId;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.MdnResponse requestAs2Config_as2Config_MdnResponse = null;
            if (cmdletContext.As2Config_MdnResponse != null)
            {
                requestAs2Config_as2Config_MdnResponse = cmdletContext.As2Config_MdnResponse;
            }
            if (requestAs2Config_as2Config_MdnResponse != null)
            {
                request.As2Config.MdnResponse = requestAs2Config_as2Config_MdnResponse;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.MdnSigningAlg requestAs2Config_as2Config_MdnSigningAlgorithm = null;
            if (cmdletContext.As2Config_MdnSigningAlgorithm != null)
            {
                requestAs2Config_as2Config_MdnSigningAlgorithm = cmdletContext.As2Config_MdnSigningAlgorithm;
            }
            if (requestAs2Config_as2Config_MdnSigningAlgorithm != null)
            {
                request.As2Config.MdnSigningAlgorithm = requestAs2Config_as2Config_MdnSigningAlgorithm;
                requestAs2ConfigIsNull = false;
            }
            System.String requestAs2Config_as2Config_MessageSubject = null;
            if (cmdletContext.As2Config_MessageSubject != null)
            {
                requestAs2Config_as2Config_MessageSubject = cmdletContext.As2Config_MessageSubject;
            }
            if (requestAs2Config_as2Config_MessageSubject != null)
            {
                request.As2Config.MessageSubject = requestAs2Config_as2Config_MessageSubject;
                requestAs2ConfigIsNull = false;
            }
            System.String requestAs2Config_as2Config_PartnerProfileId = null;
            if (cmdletContext.As2Config_PartnerProfileId != null)
            {
                requestAs2Config_as2Config_PartnerProfileId = cmdletContext.As2Config_PartnerProfileId;
            }
            if (requestAs2Config_as2Config_PartnerProfileId != null)
            {
                request.As2Config.PartnerProfileId = requestAs2Config_as2Config_PartnerProfileId;
                requestAs2ConfigIsNull = false;
            }
            Amazon.Transfer.SigningAlg requestAs2Config_as2Config_SigningAlgorithm = null;
            if (cmdletContext.As2Config_SigningAlgorithm != null)
            {
                requestAs2Config_as2Config_SigningAlgorithm = cmdletContext.As2Config_SigningAlgorithm;
            }
            if (requestAs2Config_as2Config_SigningAlgorithm != null)
            {
                request.As2Config.SigningAlgorithm = requestAs2Config_as2Config_SigningAlgorithm;
                requestAs2ConfigIsNull = false;
            }
             // determine if request.As2Config should be set to null
            if (requestAs2ConfigIsNull)
            {
                request.As2Config = null;
            }
            if (cmdletContext.ConnectorId != null)
            {
                request.ConnectorId = cmdletContext.ConnectorId;
            }
            if (cmdletContext.LoggingRole != null)
            {
                request.LoggingRole = cmdletContext.LoggingRole;
            }
            if (cmdletContext.Url != null)
            {
                request.Url = cmdletContext.Url;
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
        
        private Amazon.Transfer.Model.UpdateConnectorResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.UpdateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "UpdateConnector");
            try
            {
                #if DESKTOP
                return client.UpdateConnector(request);
                #elif CORECLR
                return client.UpdateConnectorAsync(request).GetAwaiter().GetResult();
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
            public System.String AccessRole { get; set; }
            public Amazon.Transfer.CompressionEnum As2Config_Compression { get; set; }
            public Amazon.Transfer.EncryptionAlg As2Config_EncryptionAlgorithm { get; set; }
            public System.String As2Config_LocalProfileId { get; set; }
            public Amazon.Transfer.MdnResponse As2Config_MdnResponse { get; set; }
            public Amazon.Transfer.MdnSigningAlg As2Config_MdnSigningAlgorithm { get; set; }
            public System.String As2Config_MessageSubject { get; set; }
            public System.String As2Config_PartnerProfileId { get; set; }
            public Amazon.Transfer.SigningAlg As2Config_SigningAlgorithm { get; set; }
            public System.String ConnectorId { get; set; }
            public System.String LoggingRole { get; set; }
            public System.String Url { get; set; }
            public System.Func<Amazon.Transfer.Model.UpdateConnectorResponse, UpdateTFRConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorId;
        }
        
    }
}
