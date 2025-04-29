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
using Amazon.Transfer;
using Amazon.Transfer.Model;

#pragma warning disable CS0618, CS0612
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
    /// The partner is identified with the <c>PartnerProfileId</c>, and the AS2 process is
    /// identified with the <c>LocalProfileId</c>.
    /// </para><note><para>
    /// Specify <i>either</i><c>BaseDirectory</c> or <c>CustomDirectories</c>, but not both.
    /// Specifying both causes the command to fail.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "TFRAgreement", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP CreateAgreement API operation.", Operation = new[] {"CreateAgreement"}, SelectReturnType = typeof(Amazon.Transfer.Model.CreateAgreementResponse))]
    [AWSCmdletOutput("System.String or Amazon.Transfer.Model.CreateAgreementResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Transfer.Model.CreateAgreementResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewTFRAgreementCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessRole
        /// <summary>
        /// <para>
        /// <para>Connectors are used to send files using either the AS2 or SFTP protocol. For the access
        /// role, provide the Amazon Resource Name (ARN) of the Identity and Access Management
        /// role to use.</para><para><b>For AS2 connectors</b></para><para>With AS2, you can send files by calling <c>StartFileTransfer</c> and specifying the
        /// file paths in the request parameter, <c>SendFilePaths</c>. We use the file’s parent
        /// directory (for example, for <c>--send-file-paths /bucket/dir/file.txt</c>, parent
        /// directory is <c>/bucket/dir/</c>) to temporarily store a processed AS2 message file,
        /// store the MDN when we receive them from the partner, and write a final JSON file containing
        /// relevant metadata of the transmission. So, the <c>AccessRole</c> needs to provide
        /// read and write access to the parent directory of the file location used in the <c>StartFileTransfer</c>
        /// request. Additionally, you need to provide read and write access to the parent directory
        /// of the files that you intend to send with <c>StartFileTransfer</c>.</para><para>If you are using Basic authentication for your AS2 connector, the access role requires
        /// the <c>secretsmanager:GetSecretValue</c> permission for the secret. If the secret
        /// is encrypted using a customer-managed key instead of the Amazon Web Services managed
        /// key in Secrets Manager, then the role also needs the <c>kms:Decrypt</c> permission
        /// for that key.</para><para><b>For SFTP connectors</b></para><para>Make sure that the access role provides read and write access to the parent directory
        /// of the file location that's used in the <c>StartFileTransfer</c> request. Additionally,
        /// make sure that the role provides <c>secretsmanager:GetSecretValue</c> permission to
        /// Secrets Manager.</para>
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
        /// <para>The landing directory (folder) for files transferred by using the AS2 protocol.</para><para>A <c>BaseDirectory</c> example is <c>/<i>amzn-s3-demo-bucket</i>/home/mydirectory</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        
        #region Parameter EnforceMessageSigning
        /// <summary>
        /// <para>
        /// <para> Determines whether or not unsigned messages from your trading partners will be accepted.
        /// </para><ul><li><para><c>ENABLED</c>: Transfer Family rejects unsigned messages from your trading partner.</para></li><li><para><c>DISABLED</c> (default value): Transfer Family accepts unsigned messages from your
        /// trading partner.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.EnforceMessageSigningType")]
        public Amazon.Transfer.EnforceMessageSigningType EnforceMessageSigning { get; set; }
        #endregion
        
        #region Parameter CustomDirectories_FailedFilesDirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a location to store failed AS2 message files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDirectories_FailedFilesDirectory { get; set; }
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
        
        #region Parameter CustomDirectories_MdnFilesDirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a location to store MDN files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDirectories_MdnFilesDirectory { get; set; }
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
        
        #region Parameter CustomDirectories_PayloadFilesDirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a location to store the payload for AS2 message files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDirectories_PayloadFilesDirectory { get; set; }
        #endregion
        
        #region Parameter PreserveFilename
        /// <summary>
        /// <para>
        /// <para> Determines whether or not Transfer Family appends a unique string of characters to
        /// the end of the AS2 message payload filename when saving it. </para><ul><li><para><c>ENABLED</c>: the filename provided by your trading parter is preserved when the
        /// file is saved.</para></li><li><para><c>DISABLED</c> (default value): when Transfer Family saves the file, the filename
        /// is adjusted, as described in <a href="https://docs.aws.amazon.com/transfer/latest/userguide/send-as2-messages.html#file-names-as2">File
        /// names and locations</a>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.PreserveFilenameType")]
        public Amazon.Transfer.PreserveFilenameType PreserveFilename { get; set; }
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
        /// <para>The status of the agreement. The agreement can be either <c>ACTIVE</c> or <c>INACTIVE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.AgreementStatusType")]
        public Amazon.Transfer.AgreementStatusType Status { get; set; }
        #endregion
        
        #region Parameter CustomDirectories_StatusFilesDirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a location to store AS2 status messages.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDirectories_StatusFilesDirectory { get; set; }
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
        
        #region Parameter CustomDirectories_TemporaryFilesDirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a location to store temporary AS2 message files.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomDirectories_TemporaryFilesDirectory { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-TFRAgreement (CreateAgreement)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.CreateAgreementResponse, NewTFRAgreementCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessRole = this.AccessRole;
            #if MODULAR
            if (this.AccessRole == null && ParameterWasBound(nameof(this.AccessRole)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BaseDirectory = this.BaseDirectory;
            context.CustomDirectories_FailedFilesDirectory = this.CustomDirectories_FailedFilesDirectory;
            context.CustomDirectories_MdnFilesDirectory = this.CustomDirectories_MdnFilesDirectory;
            context.CustomDirectories_PayloadFilesDirectory = this.CustomDirectories_PayloadFilesDirectory;
            context.CustomDirectories_StatusFilesDirectory = this.CustomDirectories_StatusFilesDirectory;
            context.CustomDirectories_TemporaryFilesDirectory = this.CustomDirectories_TemporaryFilesDirectory;
            context.Description = this.Description;
            context.EnforceMessageSigning = this.EnforceMessageSigning;
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
            context.PreserveFilename = this.PreserveFilename;
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
            
             // populate CustomDirectories
            var requestCustomDirectoriesIsNull = true;
            request.CustomDirectories = new Amazon.Transfer.Model.CustomDirectoriesType();
            System.String requestCustomDirectories_customDirectories_FailedFilesDirectory = null;
            if (cmdletContext.CustomDirectories_FailedFilesDirectory != null)
            {
                requestCustomDirectories_customDirectories_FailedFilesDirectory = cmdletContext.CustomDirectories_FailedFilesDirectory;
            }
            if (requestCustomDirectories_customDirectories_FailedFilesDirectory != null)
            {
                request.CustomDirectories.FailedFilesDirectory = requestCustomDirectories_customDirectories_FailedFilesDirectory;
                requestCustomDirectoriesIsNull = false;
            }
            System.String requestCustomDirectories_customDirectories_MdnFilesDirectory = null;
            if (cmdletContext.CustomDirectories_MdnFilesDirectory != null)
            {
                requestCustomDirectories_customDirectories_MdnFilesDirectory = cmdletContext.CustomDirectories_MdnFilesDirectory;
            }
            if (requestCustomDirectories_customDirectories_MdnFilesDirectory != null)
            {
                request.CustomDirectories.MdnFilesDirectory = requestCustomDirectories_customDirectories_MdnFilesDirectory;
                requestCustomDirectoriesIsNull = false;
            }
            System.String requestCustomDirectories_customDirectories_PayloadFilesDirectory = null;
            if (cmdletContext.CustomDirectories_PayloadFilesDirectory != null)
            {
                requestCustomDirectories_customDirectories_PayloadFilesDirectory = cmdletContext.CustomDirectories_PayloadFilesDirectory;
            }
            if (requestCustomDirectories_customDirectories_PayloadFilesDirectory != null)
            {
                request.CustomDirectories.PayloadFilesDirectory = requestCustomDirectories_customDirectories_PayloadFilesDirectory;
                requestCustomDirectoriesIsNull = false;
            }
            System.String requestCustomDirectories_customDirectories_StatusFilesDirectory = null;
            if (cmdletContext.CustomDirectories_StatusFilesDirectory != null)
            {
                requestCustomDirectories_customDirectories_StatusFilesDirectory = cmdletContext.CustomDirectories_StatusFilesDirectory;
            }
            if (requestCustomDirectories_customDirectories_StatusFilesDirectory != null)
            {
                request.CustomDirectories.StatusFilesDirectory = requestCustomDirectories_customDirectories_StatusFilesDirectory;
                requestCustomDirectoriesIsNull = false;
            }
            System.String requestCustomDirectories_customDirectories_TemporaryFilesDirectory = null;
            if (cmdletContext.CustomDirectories_TemporaryFilesDirectory != null)
            {
                requestCustomDirectories_customDirectories_TemporaryFilesDirectory = cmdletContext.CustomDirectories_TemporaryFilesDirectory;
            }
            if (requestCustomDirectories_customDirectories_TemporaryFilesDirectory != null)
            {
                request.CustomDirectories.TemporaryFilesDirectory = requestCustomDirectories_customDirectories_TemporaryFilesDirectory;
                requestCustomDirectoriesIsNull = false;
            }
             // determine if request.CustomDirectories should be set to null
            if (requestCustomDirectoriesIsNull)
            {
                request.CustomDirectories = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EnforceMessageSigning != null)
            {
                request.EnforceMessageSigning = cmdletContext.EnforceMessageSigning;
            }
            if (cmdletContext.LocalProfileId != null)
            {
                request.LocalProfileId = cmdletContext.LocalProfileId;
            }
            if (cmdletContext.PartnerProfileId != null)
            {
                request.PartnerProfileId = cmdletContext.PartnerProfileId;
            }
            if (cmdletContext.PreserveFilename != null)
            {
                request.PreserveFilename = cmdletContext.PreserveFilename;
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
                return client.CreateAgreementAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CustomDirectories_FailedFilesDirectory { get; set; }
            public System.String CustomDirectories_MdnFilesDirectory { get; set; }
            public System.String CustomDirectories_PayloadFilesDirectory { get; set; }
            public System.String CustomDirectories_StatusFilesDirectory { get; set; }
            public System.String CustomDirectories_TemporaryFilesDirectory { get; set; }
            public System.String Description { get; set; }
            public Amazon.Transfer.EnforceMessageSigningType EnforceMessageSigning { get; set; }
            public System.String LocalProfileId { get; set; }
            public System.String PartnerProfileId { get; set; }
            public Amazon.Transfer.PreserveFilenameType PreserveFilename { get; set; }
            public System.String ServerId { get; set; }
            public Amazon.Transfer.AgreementStatusType Status { get; set; }
            public List<Amazon.Transfer.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.Transfer.Model.CreateAgreementResponse, NewTFRAgreementCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgreementId;
        }
        
    }
}
