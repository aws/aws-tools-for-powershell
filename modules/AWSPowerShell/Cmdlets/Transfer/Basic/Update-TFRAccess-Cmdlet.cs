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
    /// Allows you to update parameters for the access specified in the <code>ServerID</code>
    /// and <code>ExternalID</code> parameters.
    /// </summary>
    [Cmdlet("Update", "TFRAccess", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Transfer.Model.UpdateAccessResponse")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP UpdateAccess API operation.", Operation = new[] {"UpdateAccess"}, SelectReturnType = typeof(Amazon.Transfer.Model.UpdateAccessResponse))]
    [AWSCmdletOutput("Amazon.Transfer.Model.UpdateAccessResponse",
        "This cmdlet returns an Amazon.Transfer.Model.UpdateAccessResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateTFRAccessCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>A unique identifier that is required to identify specific groups within your directory.
        /// The users of the group that you associate have access to your Amazon S3 or Amazon
        /// EFS resources over the enabled protocols using Transfer Family. If you know the group
        /// name, you can view the SID values by running the following command using Windows PowerShell.</para><para><code>Get-ADGroup -Filter {samAccountName -like "<i>YourGroupName</i>*"} -Properties
        /// * | Select SamAccountName,ObjectSid</code></para><para>In that command, replace <i>YourGroupName</i> with the name of your Active Directory
        /// group.</para><para>The regular expression used to validate this parameter is a string of characters consisting
        /// of uppercase and lowercase alphanumeric characters with no spaces. You can also include
        /// underscores or any of the following characters: =,.@:/-</para>
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
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter PosixProfile_Gid
        /// <summary>
        /// <para>
        /// <para>The POSIX group ID used for all EFS operations by this user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PosixProfile_Gid { get; set; }
        #endregion
        
        #region Parameter HomeDirectory
        /// <summary>
        /// <para>
        /// <para>The landing directory (folder) for a user when they log in to the server using the
        /// client.</para><para>A <code>HomeDirectory</code> example is <code>/bucket_name/home/mydirectory</code>.</para><note><para>The <code>HomeDirectory</code> parameter is only used if <code>HomeDirectoryType</code>
        /// is set to <code>LOGICAL</code>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HomeDirectory { get; set; }
        #endregion
        
        #region Parameter HomeDirectoryMapping
        /// <summary>
        /// <para>
        /// <para>Logical directory mappings that specify what Amazon S3 or Amazon EFS paths and keys
        /// should be visible to your user and how you want to make them visible. You must specify
        /// the <code>Entry</code> and <code>Target</code> pair, where <code>Entry</code> shows
        /// how the path is made visible and <code>Target</code> is the actual Amazon S3 or Amazon
        /// EFS path. If you only specify a target, it is displayed as is. You also must ensure
        /// that your Identity and Access Management (IAM) role provides access to paths in <code>Target</code>.
        /// This value can be set only when <code>HomeDirectoryType</code> is set to <i>LOGICAL</i>.</para><para>The following is an <code>Entry</code> and <code>Target</code> pair example.</para><para><code>[ { "Entry": "/directory1", "Target": "/bucket_name/home/mydirectory" } ]</code></para><para>In most cases, you can use this value instead of the session policy to lock down your
        /// user to the designated home directory ("<code>chroot</code>"). To do this, you can
        /// set <code>Entry</code> to <code>/</code> and set <code>Target</code> to the <code>HomeDirectory</code>
        /// parameter value.</para><para>The following is an <code>Entry</code> and <code>Target</code> pair example for <code>chroot</code>.</para><para><code>[ { "Entry": "/", "Target": "/bucket_name/home/mydirectory" } ]</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HomeDirectoryMappings")]
        public Amazon.Transfer.Model.HomeDirectoryMapEntry[] HomeDirectoryMapping { get; set; }
        #endregion
        
        #region Parameter HomeDirectoryType
        /// <summary>
        /// <para>
        /// <para>The type of landing directory (folder) that you want your users' home directory to
        /// be when they log in to the server. If you set it to <code>PATH</code>, the user will
        /// see the absolute Amazon S3 bucket or Amazon EFS path as is in their file transfer
        /// protocol clients. If you set it to <code>LOGICAL</code>, you need to provide mappings
        /// in the <code>HomeDirectoryMappings</code> for how you want to make Amazon S3 or Amazon
        /// EFS paths visible to your users.</para><note><para>If <code>HomeDirectoryType</code> is <code>LOGICAL</code>, you must provide mappings,
        /// using the <code>HomeDirectoryMappings</code> parameter. If, on the other hand, <code>HomeDirectoryType</code>
        /// is <code>PATH</code>, you provide an absolute path using the <code>HomeDirectory</code>
        /// parameter. You cannot have both <code>HomeDirectory</code> and <code>HomeDirectoryMappings</code>
        /// in your template.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.HomeDirectoryType")]
        public Amazon.Transfer.HomeDirectoryType HomeDirectoryType { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>A session policy for your user so that you can use the same Identity and Access Management
        /// (IAM) role across multiple users. This policy scopes down a user's access to portions
        /// of their Amazon S3 bucket. Variables that you can use inside this policy include <code>${Transfer:UserName}</code>,
        /// <code>${Transfer:HomeDirectory}</code>, and <code>${Transfer:HomeBucket}</code>.</para><note><para>This policy applies only when the domain of <code>ServerId</code> is Amazon S3. Amazon
        /// EFS does not use session policies.</para><para>For session policies, Transfer Family stores the policy as a JSON blob, instead of
        /// the Amazon Resource Name (ARN) of the policy. You save the policy as a JSON blob and
        /// pass it in the <code>Policy</code> argument.</para><para>For an example of a session policy, see <a href="https://docs.aws.amazon.com/transfer/latest/userguide/session-policy.html">Example
        /// session policy</a>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/STS/latest/APIReference/API_AssumeRole.html">AssumeRole</a>
        /// in the <i>Amazon Web ServicesSecurity Token Service API Reference</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role that
        /// controls your users' access to your Amazon S3 bucket or Amazon EFS file system. The
        /// policies attached to this role determine the level of access that you want to provide
        /// your users when transferring files into and out of your Amazon S3 bucket or Amazon
        /// EFS file system. The IAM role should also contain a trust relationship that allows
        /// the server to access your resources when servicing your users' transfer requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter PosixProfile_SecondaryGid
        /// <summary>
        /// <para>
        /// <para>The secondary POSIX group IDs used for all EFS operations by this user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PosixProfile_SecondaryGids")]
        public System.Int64[] PosixProfile_SecondaryGid { get; set; }
        #endregion
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>A system-assigned unique identifier for a server instance. This is the specific server
        /// that you added your user to.</para>
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
        
        #region Parameter PosixProfile_Uid
        /// <summary>
        /// <para>
        /// <para>The POSIX user ID used for all EFS operations by this user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? PosixProfile_Uid { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.UpdateAccessResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.UpdateAccessResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TFRAccess (UpdateAccess)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.UpdateAccessResponse, UpdateTFRAccessCmdlet>(Select) ??
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
            context.ExternalId = this.ExternalId;
            #if MODULAR
            if (this.ExternalId == null && ParameterWasBound(nameof(this.ExternalId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExternalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HomeDirectory = this.HomeDirectory;
            if (this.HomeDirectoryMapping != null)
            {
                context.HomeDirectoryMapping = new List<Amazon.Transfer.Model.HomeDirectoryMapEntry>(this.HomeDirectoryMapping);
            }
            context.HomeDirectoryType = this.HomeDirectoryType;
            context.Policy = this.Policy;
            context.PosixProfile_Gid = this.PosixProfile_Gid;
            if (this.PosixProfile_SecondaryGid != null)
            {
                context.PosixProfile_SecondaryGid = new List<System.Int64>(this.PosixProfile_SecondaryGid);
            }
            context.PosixProfile_Uid = this.PosixProfile_Uid;
            context.Role = this.Role;
            context.ServerId = this.ServerId;
            #if MODULAR
            if (this.ServerId == null && ParameterWasBound(nameof(this.ServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Transfer.Model.UpdateAccessRequest();
            
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
            }
            if (cmdletContext.HomeDirectory != null)
            {
                request.HomeDirectory = cmdletContext.HomeDirectory;
            }
            if (cmdletContext.HomeDirectoryMapping != null)
            {
                request.HomeDirectoryMappings = cmdletContext.HomeDirectoryMapping;
            }
            if (cmdletContext.HomeDirectoryType != null)
            {
                request.HomeDirectoryType = cmdletContext.HomeDirectoryType;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
            }
            
             // populate PosixProfile
            var requestPosixProfileIsNull = true;
            request.PosixProfile = new Amazon.Transfer.Model.PosixProfile();
            System.Int64? requestPosixProfile_posixProfile_Gid = null;
            if (cmdletContext.PosixProfile_Gid != null)
            {
                requestPosixProfile_posixProfile_Gid = cmdletContext.PosixProfile_Gid.Value;
            }
            if (requestPosixProfile_posixProfile_Gid != null)
            {
                request.PosixProfile.Gid = requestPosixProfile_posixProfile_Gid.Value;
                requestPosixProfileIsNull = false;
            }
            List<System.Int64> requestPosixProfile_posixProfile_SecondaryGid = null;
            if (cmdletContext.PosixProfile_SecondaryGid != null)
            {
                requestPosixProfile_posixProfile_SecondaryGid = cmdletContext.PosixProfile_SecondaryGid;
            }
            if (requestPosixProfile_posixProfile_SecondaryGid != null)
            {
                request.PosixProfile.SecondaryGids = requestPosixProfile_posixProfile_SecondaryGid;
                requestPosixProfileIsNull = false;
            }
            System.Int64? requestPosixProfile_posixProfile_Uid = null;
            if (cmdletContext.PosixProfile_Uid != null)
            {
                requestPosixProfile_posixProfile_Uid = cmdletContext.PosixProfile_Uid.Value;
            }
            if (requestPosixProfile_posixProfile_Uid != null)
            {
                request.PosixProfile.Uid = requestPosixProfile_posixProfile_Uid.Value;
                requestPosixProfileIsNull = false;
            }
             // determine if request.PosixProfile should be set to null
            if (requestPosixProfileIsNull)
            {
                request.PosixProfile = null;
            }
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
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
        
        private Amazon.Transfer.Model.UpdateAccessResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.UpdateAccessRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "UpdateAccess");
            try
            {
                #if DESKTOP
                return client.UpdateAccess(request);
                #elif CORECLR
                return client.UpdateAccessAsync(request).GetAwaiter().GetResult();
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
            public System.String ExternalId { get; set; }
            public System.String HomeDirectory { get; set; }
            public List<Amazon.Transfer.Model.HomeDirectoryMapEntry> HomeDirectoryMapping { get; set; }
            public Amazon.Transfer.HomeDirectoryType HomeDirectoryType { get; set; }
            public System.String Policy { get; set; }
            public System.Int64? PosixProfile_Gid { get; set; }
            public List<System.Int64> PosixProfile_SecondaryGid { get; set; }
            public System.Int64? PosixProfile_Uid { get; set; }
            public System.String Role { get; set; }
            public System.String ServerId { get; set; }
            public System.Func<Amazon.Transfer.Model.UpdateAccessResponse, UpdateTFRAccessCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
