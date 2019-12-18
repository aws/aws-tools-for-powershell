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
using Amazon.StorageGateway;
using Amazon.StorageGateway.Model;

namespace Amazon.PowerShell.Cmdlets.SG
{
    /// <summary>
    /// Creates a Server Message Block (SMB) file share on an existing file gateway. In Storage
    /// Gateway, a file share is a file system mount point backed by Amazon S3 cloud storage.
    /// Storage Gateway expose file shares using a SMB interface. This operation is only supported
    /// for file gateways.
    /// 
    ///  <important><para>
    /// File gateways require AWS Security Token Service (AWS STS) to be activated to enable
    /// you to create a file share. Make sure that AWS STS is activated in the AWS Region
    /// you are creating your file gateway in. If AWS STS is not activated in this AWS Region,
    /// activate it. For information about how to activate AWS STS, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_enable-regions.html">Activating
    /// and Deactivating AWS STS in an AWS Region</a> in the <i>AWS Identity and Access Management
    /// User Guide.</i></para><para>
    /// File gateways don't support creating hard or symbolic links on a file share.
    /// </para></important>
    /// </summary>
    [Cmdlet("New", "SGSMBFileShare", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Storage Gateway CreateSMBFileShare API operation.", Operation = new[] {"CreateSMBFileShare"}, SelectReturnType = typeof(Amazon.StorageGateway.Model.CreateSMBFileShareResponse))]
    [AWSCmdletOutput("System.String or Amazon.StorageGateway.Model.CreateSMBFileShareResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.StorageGateway.Model.CreateSMBFileShareResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSGSMBFileShareCmdlet : AmazonStorageGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter AdminUserList
        /// <summary>
        /// <para>
        /// <para>A list of users in the Active Directory that will be granted administrator privileges
        /// on the file share. These users can do all file operations as the super-user. </para><important><para>Use this option very carefully, because any user in this list can do anything they
        /// like on the file share, regardless of file permissions.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AdminUserList { get; set; }
        #endregion
        
        #region Parameter Authentication
        /// <summary>
        /// <para>
        /// <para>The authentication method that users use to access the file share.</para><para>Valid values are <code>ActiveDirectory</code> or <code>GuestAccess</code>. The default
        /// is <code>ActiveDirectory</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Authentication { get; set; }
        #endregion
        
        #region Parameter DefaultStorageClass
        /// <summary>
        /// <para>
        /// <para>The default storage class for objects put into an Amazon S3 bucket by the file gateway.
        /// Possible values are <code>S3_STANDARD</code>, <code>S3_STANDARD_IA</code>, or <code>S3_ONEZONE_IA</code>.
        /// If this field is not populated, the default value <code>S3_STANDARD</code> is used.
        /// Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultStorageClass { get; set; }
        #endregion
        
        #region Parameter GatewayARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the file gateway on which you want to create a file
        /// share.</para>
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
        public System.String GatewayARN { get; set; }
        #endregion
        
        #region Parameter GuessMIMETypeEnabled
        /// <summary>
        /// <para>
        /// <para>A value that enables guessing of the MIME type for uploaded objects based on file
        /// extensions. Set this value to true to enable MIME type guessing, and otherwise to
        /// false. The default value is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GuessMIMETypeEnabled { get; set; }
        #endregion
        
        #region Parameter InvalidUserList
        /// <summary>
        /// <para>
        /// <para>A list of users or groups in the Active Directory that are not allowed to access the
        /// file share. A group must be prefixed with the @ character. For example <code>@group1</code>.
        /// Can only be set if Authentication is set to <code>ActiveDirectory</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] InvalidUserList { get; set; }
        #endregion
        
        #region Parameter KMSEncrypted
        /// <summary>
        /// <para>
        /// <para>True to use Amazon S3 server side encryption with your own AWS KMS key, or false to
        /// use a key managed by Amazon S3. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? KMSEncrypted { get; set; }
        #endregion
        
        #region Parameter KMSKey
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS KMS key used for Amazon S3 server side encryption.
        /// This value can only be set when KMSEncrypted is true. Optional.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KMSKey { get; set; }
        #endregion
        
        #region Parameter LocationARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the backed storage used for storing file data. </para>
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
        public System.String LocationARN { get; set; }
        #endregion
        
        #region Parameter ObjectACL
        /// <summary>
        /// <para>
        /// <para>A value that sets the access control list permission for objects in the S3 bucket
        /// that a file gateway puts objects into. The default value is "private".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StorageGateway.ObjectACL")]
        public Amazon.StorageGateway.ObjectACL ObjectACL { get; set; }
        #endregion
        
        #region Parameter ReadOnly
        /// <summary>
        /// <para>
        /// <para>A value that sets the write status of a file share. This value is true if the write
        /// status is read-only, and otherwise false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReadOnly { get; set; }
        #endregion
        
        #region Parameter RequesterPay
        /// <summary>
        /// <para>
        /// <para>A value that sets who pays the cost of the request and the cost associated with data
        /// download from the S3 bucket. If this value is set to true, the requester pays the
        /// costs. Otherwise the S3 bucket owner pays. However, the S3 bucket owner always pays
        /// the cost of storing data.</para><note><para><code>RequesterPays</code> is a configuration for the S3 bucket that backs the file
        /// share, so make sure that the configuration on the file share is the same as the S3
        /// bucket configuration.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequesterPays")]
        public System.Boolean? RequesterPay { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Identity and Access Management (IAM) role that a file gateway assumes
        /// when it accesses the underlying storage. </para>
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
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter SMBACLEnabled
        /// <summary>
        /// <para>
        /// <para>Set this value to "true to enable ACL (access control list) on the SMB file share.
        /// Set it to "false" to map file and directory permissions to the POSIX permissions.</para><para>For more information, see https://docs.aws.amazon.com/storagegateway/latest/userguide/smb-acl.html
        /// in the Storage Gateway User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SMBACLEnabled { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of up to 50 tags that can be assigned to the NFS file share. Each tag is a
        /// key-value pair.</para><note><para>Valid characters for key and value are letters, spaces, and numbers representable
        /// in UTF-8 format, and the following special characters: + - = . _ : / @. The maximum
        /// length of a tag's key is 128 characters, and the maximum length for a tag's value
        /// is 256.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.StorageGateway.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ValidUserList
        /// <summary>
        /// <para>
        /// <para>A list of users or groups in the Active Directory that are allowed to access the file
        /// share. A group must be prefixed with the @ character. For example <code>@group1</code>.
        /// Can only be set if Authentication is set to <code>ActiveDirectory</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ValidUserList { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique string value that you supply that is used by file gateway to ensure idempotent
        /// file share creation.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileShareARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StorageGateway.Model.CreateSMBFileShareResponse).
        /// Specifying the name of a property of type Amazon.StorageGateway.Model.CreateSMBFileShareResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileShareARN";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GatewayARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GatewayARN' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SGSMBFileShare (CreateSMBFileShare)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StorageGateway.Model.CreateSMBFileShareResponse, NewSGSMBFileShareCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GatewayARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdminUserList != null)
            {
                context.AdminUserList = new List<System.String>(this.AdminUserList);
            }
            context.Authentication = this.Authentication;
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultStorageClass = this.DefaultStorageClass;
            context.GatewayARN = this.GatewayARN;
            #if MODULAR
            if (this.GatewayARN == null && ParameterWasBound(nameof(this.GatewayARN)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GuessMIMETypeEnabled = this.GuessMIMETypeEnabled;
            if (this.InvalidUserList != null)
            {
                context.InvalidUserList = new List<System.String>(this.InvalidUserList);
            }
            context.KMSEncrypted = this.KMSEncrypted;
            context.KMSKey = this.KMSKey;
            context.LocationARN = this.LocationARN;
            #if MODULAR
            if (this.LocationARN == null && ParameterWasBound(nameof(this.LocationARN)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ObjectACL = this.ObjectACL;
            context.ReadOnly = this.ReadOnly;
            context.RequesterPay = this.RequesterPay;
            context.Role = this.Role;
            #if MODULAR
            if (this.Role == null && ParameterWasBound(nameof(this.Role)))
            {
                WriteWarning("You are passing $null as a value for parameter Role which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SMBACLEnabled = this.SMBACLEnabled;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.StorageGateway.Model.Tag>(this.Tag);
            }
            if (this.ValidUserList != null)
            {
                context.ValidUserList = new List<System.String>(this.ValidUserList);
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
            var request = new Amazon.StorageGateway.Model.CreateSMBFileShareRequest();
            
            if (cmdletContext.AdminUserList != null)
            {
                request.AdminUserList = cmdletContext.AdminUserList;
            }
            if (cmdletContext.Authentication != null)
            {
                request.Authentication = cmdletContext.Authentication;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DefaultStorageClass != null)
            {
                request.DefaultStorageClass = cmdletContext.DefaultStorageClass;
            }
            if (cmdletContext.GatewayARN != null)
            {
                request.GatewayARN = cmdletContext.GatewayARN;
            }
            if (cmdletContext.GuessMIMETypeEnabled != null)
            {
                request.GuessMIMETypeEnabled = cmdletContext.GuessMIMETypeEnabled.Value;
            }
            if (cmdletContext.InvalidUserList != null)
            {
                request.InvalidUserList = cmdletContext.InvalidUserList;
            }
            if (cmdletContext.KMSEncrypted != null)
            {
                request.KMSEncrypted = cmdletContext.KMSEncrypted.Value;
            }
            if (cmdletContext.KMSKey != null)
            {
                request.KMSKey = cmdletContext.KMSKey;
            }
            if (cmdletContext.LocationARN != null)
            {
                request.LocationARN = cmdletContext.LocationARN;
            }
            if (cmdletContext.ObjectACL != null)
            {
                request.ObjectACL = cmdletContext.ObjectACL;
            }
            if (cmdletContext.ReadOnly != null)
            {
                request.ReadOnly = cmdletContext.ReadOnly.Value;
            }
            if (cmdletContext.RequesterPay != null)
            {
                request.RequesterPays = cmdletContext.RequesterPay.Value;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.SMBACLEnabled != null)
            {
                request.SMBACLEnabled = cmdletContext.SMBACLEnabled.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.ValidUserList != null)
            {
                request.ValidUserList = cmdletContext.ValidUserList;
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
        
        private Amazon.StorageGateway.Model.CreateSMBFileShareResponse CallAWSServiceOperation(IAmazonStorageGateway client, Amazon.StorageGateway.Model.CreateSMBFileShareRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Storage Gateway", "CreateSMBFileShare");
            try
            {
                #if DESKTOP
                return client.CreateSMBFileShare(request);
                #elif CORECLR
                return client.CreateSMBFileShareAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AdminUserList { get; set; }
            public System.String Authentication { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DefaultStorageClass { get; set; }
            public System.String GatewayARN { get; set; }
            public System.Boolean? GuessMIMETypeEnabled { get; set; }
            public List<System.String> InvalidUserList { get; set; }
            public System.Boolean? KMSEncrypted { get; set; }
            public System.String KMSKey { get; set; }
            public System.String LocationARN { get; set; }
            public Amazon.StorageGateway.ObjectACL ObjectACL { get; set; }
            public System.Boolean? ReadOnly { get; set; }
            public System.Boolean? RequesterPay { get; set; }
            public System.String Role { get; set; }
            public System.Boolean? SMBACLEnabled { get; set; }
            public List<Amazon.StorageGateway.Model.Tag> Tag { get; set; }
            public List<System.String> ValidUserList { get; set; }
            public System.Func<Amazon.StorageGateway.Model.CreateSMBFileShareResponse, NewSGSMBFileShareCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileShareARN;
        }
        
    }
}
