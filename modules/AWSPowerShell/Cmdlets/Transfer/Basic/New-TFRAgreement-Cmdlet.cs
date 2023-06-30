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
    /// Creates an agreement. An agreement is a bilateral trading partner agreement, or partnership,
    /// between an Transfer Family server and an AS2 process. The agreement defines the file
    /// and message transfer relationship between the server and the AS2 process. To define
    /// an agreement, Transfer Family combines a server, local profile, partner profile, certificate,
    /// and other attributes.
    /// 
    ///  
    /// <para>
    /// The partner is identified with the <code>PartnerProfileId</code>, and the AS2 process
    /// is identified with the <code>LocalProfileId</code>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "TFRAgreement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP CreateAgreement API operation.", Operation = new[] {"CreateAgreement"}, SelectReturnType = typeof(Amazon.Transfer.Model.CreateAgreementResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.CreateAgreementResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.CreateAgreementResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewTFRAgreementCmdlet : AmazonTransferClientCmdlet, IExecutor
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
        /// with <code>StartFileTransfer</code>.</para><para>If you are using Basic authentication for your AS2 connector, the access role requires
        /// the <code>secretsmanager:GetSecretValue</code> permission for the secret. If the secret
        /// is encrypted using a customer-managed key instead of the Amazon Web Services managed
        /// key in Secrets Manager, then the role also needs the <code>kms:Decrypt</code> permission
        /// for that key.</para>
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
        public System.String AccessRole { get; set; }
        #endregion
        
        #region Parameter BaseDirectory
        /// <summary>
        /// <para>
        /// <para>The landing directory (folder) for files transferred by using the AS2 protocol.</para><para>A <code>BaseDirectory</code> example is <code>/DOC-EXAMPLE-BUCKET/home/mydirectory</code>.</para>
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
        public System.String BaseDirectory { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A name or short description to identify the agreement. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter LocalProfileId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the AS2 local profile.</para>
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
        public System.String LocalProfileId { get; set; }
        #endregion
        
        #region Parameter PartnerProfileId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the partner profile used in the agreement.</para>
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
        public System.String PartnerProfileId { get; set; }
        #endregion
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>A system-assigned unique identifier for a server instance. This is the specific server
        /// that the agreement uses.</para>
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
        public System.String ServerId { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the agreement. The agreement can be either <code>ACTIVE</code> or <code>INACTIVE</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.AgreementStatusType")]
        public Amazon.Transfer.AgreementStatusType Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs that can be used to group and search for agreements.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.Transfer.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AgreementId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.CreateAgreementResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.CreateAgreementResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AgreementId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ServerId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ServerId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ServerId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TFRAgreement (CreateAgreement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.CreateAgreementResponse, NewTFRAgreementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ServerId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessRole = this.AccessRole;
            #if MODULAR
            if (this.AccessRole == null && ParameterWasBound(nameof(this.AccessRole)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BaseDirectory = this.BaseDirectory;
            #if MODULAR
            if (this.BaseDirectory == null && ParameterWasBound(nameof(this.BaseDirectory)))
            {
                WriteWarning("You are passing $null as a value for parameter BaseDirectory which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.LocalProfileId = this.LocalProfileId;
            #if MODULAR
            if (this.LocalProfileId == null && ParameterWasBound(nameof(this.LocalProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter LocalProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartnerProfileId = this.PartnerProfileId;
            #if MODULAR
            if (this.PartnerProfileId == null && ParameterWasBound(nameof(this.PartnerProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter PartnerProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerId = this.ServerId;
            #if MODULAR
            if (this.ServerId == null && ParameterWasBound(nameof(this.ServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Status = this.Status;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.Transfer.Model.Tag>(this.Tag);
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
            var request = new Amazon.Transfer.Model.CreateAgreementRequest();
            
            if (cmdletContext.AccessRole != null)
            {
                request.AccessRole = cmdletContext.AccessRole;
            }
            if (cmdletContext.BaseDirectory != null)
            {
                request.BaseDirectory = cmdletContext.BaseDirectory;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.LocalProfileId != null)
            {
                request.LocalProfileId = cmdletContext.LocalProfileId;
            }
            if (cmdletContext.PartnerProfileId != null)
            {
                request.PartnerProfileId = cmdletContext.PartnerProfileId;
            }
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.Transfer.Model.CreateAgreementResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.CreateAgreementRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "CreateAgreement");
            try
            {
                #if DESKTOP
                return client.CreateAgreement(request);
                #elif CORECLR
                return client.CreateAgreementAsync(request).GetAwaiter().GetResult();
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
            public System.String BaseDirectory { get; set; }
            public System.String Description { get; set; }
            public System.String LocalProfileId { get; set; }
            public System.String PartnerProfileId { get; set; }
            public System.String ServerId { get; set; }
            public Amazon.Transfer.AgreementStatusType Status { get; set; }
            public List<Amazon.Transfer.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Transfer.Model.CreateAgreementResponse, NewTFRAgreementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgreementId;
        }
        
    }
}
