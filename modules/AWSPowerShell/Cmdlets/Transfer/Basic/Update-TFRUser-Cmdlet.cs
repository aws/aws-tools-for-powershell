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
    /// Assigns new properties to a user. Parameters you pass modify any or all of the following:
    /// the home directory, role, and policy for the <code>UserName</code> and <code>ServerId</code>
    /// you specify.
    /// 
    ///  
    /// <para>
    /// The response returns the <code>ServerId</code> and the <code>UserName</code> for the
    /// updated user.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "TFRUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Transfer.Model.UpdateUserResponse")]
    [AWSCmdlet("Calls the AWS Transfer for SFTP UpdateUser API operation.", Operation = new[] {"UpdateUser"}, SelectReturnType = typeof(Amazon.Transfer.Model.UpdateUserResponse))]
    [AWSCmdletOutput("Amazon.Transfer.Model.UpdateUserResponse",
        "This cmdlet returns an Amazon.Transfer.Model.UpdateUserResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateTFRUserCmdlet : AmazonTransferClientCmdlet, IExecutor
    {
        
        #region Parameter HomeDirectory
        /// <summary>
        /// <para>
        /// <para>Specifies the landing directory (folder) for a user when they log in to the file transfer
        /// protocol-enabled server using their file transfer protocol client.</para><para>An example is <code>your-Amazon-S3-bucket-name&gt;/home/username</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HomeDirectory { get; set; }
        #endregion
        
        #region Parameter HomeDirectoryMapping
        /// <summary>
        /// <para>
        /// <para>Logical directory mappings that specify what Amazon S3 paths and keys should be visible
        /// to your user and how you want to make them visible. You will need to specify the "<code>Entry</code>"
        /// and "<code>Target</code>" pair, where <code>Entry</code> shows how the path is made
        /// visible and <code>Target</code> is the actual Amazon S3 path. If you only specify
        /// a target, it will be displayed as is. You will need to also make sure that your IAM
        /// role provides access to paths in <code>Target</code>. The following is an example.</para><para><code>'[ "/bucket2/documentation", { "Entry": "your-personal-report.pdf", "Target":
        /// "/bucket3/customized-reports/${transfer:UserName}.pdf" } ]'</code></para><para>In most cases, you can use this value instead of the scope-down policy to lock your
        /// user down to the designated home directory ("chroot"). To do this, you can set <code>Entry</code>
        /// to '/' and set <code>Target</code> to the HomeDirectory parameter value.</para><note><para>If the target of a logical directory entry does not exist in Amazon S3, the entry
        /// will be ignored. As a workaround, you can use the Amazon S3 API to create 0 byte objects
        /// as place holders for your directory. If using the CLI, use the <code>s3api</code>
        /// call instead of <code>s3</code> so you can use the put-object operation. For example,
        /// you use the following: <code>aws s3api put-object --bucket bucketname --key path/to/folder/</code>.
        /// Make sure that the end of the key name ends in a / for it to be considered a folder.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HomeDirectoryMappings")]
        public Amazon.Transfer.Model.HomeDirectoryMapEntry[] HomeDirectoryMapping { get; set; }
        #endregion
        
        #region Parameter HomeDirectoryType
        /// <summary>
        /// <para>
        /// <para>The type of landing directory (folder) you want your users' home directory to be when
        /// they log into the file transfer protocol-enabled server. If you set it to <code>PATH</code>,
        /// the user will see the absolute Amazon S3 bucket paths as is in their file transfer
        /// protocol clients. If you set it <code>LOGICAL</code>, you will need to provide mappings
        /// in the <code>HomeDirectoryMappings</code> for how you want to make Amazon S3 paths
        /// visible to your users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Transfer.HomeDirectoryType")]
        public Amazon.Transfer.HomeDirectoryType HomeDirectoryType { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>Allows you to supply a scope-down policy for your user so you can use the same IAM
        /// role across multiple users. The policy scopes down user access to portions of your
        /// Amazon S3 bucket. Variables you can use inside this policy include <code>${Transfer:UserName}</code>,
        /// <code>${Transfer:HomeDirectory}</code>, and <code>${Transfer:HomeBucket}</code>.</para><note><para>For scope-down policies, AWS Transfer Family stores the policy as a JSON blob, instead
        /// of the Amazon Resource Name (ARN) of the policy. You save the policy as a JSON blob
        /// and pass it in the <code>Policy</code> argument.</para><para>For an example of a scope-down policy, see <a href="https://docs.aws.amazon.com/transfer/latest/userguide/users.html#users-policies-scope-down">Creating
        /// a scope-down policy</a>.</para><para>For more information, see <a href="https://docs.aws.amazon.com/STS/latest/APIReference/API_AssumeRole.html">AssumeRole</a>
        /// in the <i>AWS Security Token Service API Reference</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Role
        /// <summary>
        /// <para>
        /// <para>The IAM role that controls your users' access to your Amazon S3 bucket. The policies
        /// attached to this role will determine the level of access you want to provide your
        /// users when transferring files into and out of your Amazon S3 bucket or buckets. The
        /// IAM role should also contain a trust relationship that allows the file transfer protocol-enabled
        /// server to access your resources when servicing your users' transfer requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Role { get; set; }
        #endregion
        
        #region Parameter ServerId
        /// <summary>
        /// <para>
        /// <para>A system-assigned unique identifier for a file transfer protocol-enabled server instance
        /// that the user account is assigned to.</para>
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
        public System.String ServerId { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>A unique string that identifies a user and is associated with a file transfer protocol-enabled
        /// server as specified by the <code>ServerId</code>. This user name must be a minimum
        /// of 3 and a maximum of 100 characters long. The following are valid characters: a-z,
        /// A-Z, 0-9, underscore '_', hyphen '-', period '.', and at sign '@'. The user name can't
        /// start with a hyphen, period, and at sign.</para>
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
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Transfer.Model.UpdateUserResponse).
        /// Specifying the name of a property of type Amazon.Transfer.Model.UpdateUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-TFRUser (UpdateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Transfer.Model.UpdateUserResponse, UpdateTFRUserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.HomeDirectory = this.HomeDirectory;
            if (this.HomeDirectoryMapping != null)
            {
                context.HomeDirectoryMapping = new List<Amazon.Transfer.Model.HomeDirectoryMapEntry>(this.HomeDirectoryMapping);
            }
            context.HomeDirectoryType = this.HomeDirectoryType;
            context.Policy = this.Policy;
            context.Role = this.Role;
            context.ServerId = this.ServerId;
            #if MODULAR
            if (this.ServerId == null && ParameterWasBound(nameof(this.ServerId)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserName = this.UserName;
            #if MODULAR
            if (this.UserName == null && ParameterWasBound(nameof(this.UserName)))
            {
                WriteWarning("You are passing $null as a value for parameter UserName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Transfer.Model.UpdateUserRequest();
            
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
            if (cmdletContext.Role != null)
            {
                request.Role = cmdletContext.Role;
            }
            if (cmdletContext.ServerId != null)
            {
                request.ServerId = cmdletContext.ServerId;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
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
        
        private Amazon.Transfer.Model.UpdateUserResponse CallAWSServiceOperation(IAmazonTransfer client, Amazon.Transfer.Model.UpdateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Transfer for SFTP", "UpdateUser");
            try
            {
                #if DESKTOP
                return client.UpdateUser(request);
                #elif CORECLR
                return client.UpdateUserAsync(request).GetAwaiter().GetResult();
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
            public System.String HomeDirectory { get; set; }
            public List<Amazon.Transfer.Model.HomeDirectoryMapEntry> HomeDirectoryMapping { get; set; }
            public Amazon.Transfer.HomeDirectoryType HomeDirectoryType { get; set; }
            public System.String Policy { get; set; }
            public System.String Role { get; set; }
            public System.String ServerId { get; set; }
            public System.String UserName { get; set; }
            public System.Func<Amazon.Transfer.Model.UpdateUserResponse, UpdateTFRUserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
