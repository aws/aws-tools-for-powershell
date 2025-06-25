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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Creates an S3 access point and attaches it to an Amazon FSx volume. For FSx for OpenZFS
    /// file systems, the volume must be hosted on a high-availability file system, either
    /// Single-AZ or Multi-AZ. For more information, see <a href="fsx/latest/OpenZFSGuide/s3accesspoints-for-FSx.html">Accessing
    /// your data using access points</a> in the Amazon FSx for OpenZFS User Guide. 
    /// 
    ///  
    /// <para>
    /// The requester requires the following permissions to perform these actions:
    /// </para><ul><li><para><c>fsx:CreateAndAttachS3AccessPoint</c></para></li><li><para><c>s3:CreateAccessPoint</c></para></li><li><para><c>s3:GetAccessPoint</c></para></li><li><para><c>s3:PutAccessPointPolicy</c></para></li><li><para><c>s3:DeleteAccessPoint</c></para></li></ul><para>
    /// The following actions are related to <c>CreateAndAttachS3AccessPoint</c>:
    /// </para><ul><li><para><a>DescribeS3AccessPointAttachments</a></para></li><li><para><a>DetachAndDeleteS3AccessPoint</a></para></li></ul>
    /// </summary>
    [Cmdlet("New", "FSXAndAttachS3AccessPoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.S3AccessPointAttachment")]
    [AWSCmdlet("Calls the Amazon FSx CreateAndAttachS3AccessPoint API operation.", Operation = new[] {"CreateAndAttachS3AccessPoint"}, SelectReturnType = typeof(Amazon.FSx.Model.CreateAndAttachS3AccessPointResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.S3AccessPointAttachment or Amazon.FSx.Model.CreateAndAttachS3AccessPointResponse",
        "This cmdlet returns an Amazon.FSx.Model.S3AccessPointAttachment object.",
        "The service call response (type Amazon.FSx.Model.CreateAndAttachS3AccessPointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewFSXAndAttachS3AccessPointCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter PosixUser_Gid
        /// <summary>
        /// <para>
        /// <para>The GID of the file system user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_FileSystemIdentity_PosixUser_Gid")]
        public System.Int64? PosixUser_Gid { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name you want to assign to this S3 access point.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3AccessPoint_Policy
        /// <summary>
        /// <para>
        /// <para>Specifies an access policy to associate with the S3 access point configuration. For
        /// more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/userguide/access-points-policies.html">Configuring
        /// IAM policies for using access points</a> in the Amazon Simple Storage Service User
        /// Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String S3AccessPoint_Policy { get; set; }
        #endregion
        
        #region Parameter PosixUser_SecondaryGid
        /// <summary>
        /// <para>
        /// <para>The list of secondary GIDs for the file system user. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_FileSystemIdentity_PosixUser_SecondaryGids")]
        public System.Int64[] PosixUser_SecondaryGid { get; set; }
        #endregion
        
        #region Parameter FileSystemIdentity_Type
        /// <summary>
        /// <para>
        /// <para>Specifies the FSx for OpenZFS user identity type, accepts only <c>POSIX</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_FileSystemIdentity_Type")]
        [AWSConstantClassSource("Amazon.FSx.OpenZFSFileSystemUserType")]
        public Amazon.FSx.OpenZFSFileSystemUserType FileSystemIdentity_Type { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of S3 access point you want to create. Only <c>OpenZFS</c> is supported.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.FSx.S3AccessPointAttachmentType")]
        public Amazon.FSx.S3AccessPointAttachmentType Type { get; set; }
        #endregion
        
        #region Parameter PosixUser_Uid
        /// <summary>
        /// <para>
        /// <para>The UID of the file system user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OpenZFSConfiguration_FileSystemIdentity_PosixUser_Uid")]
        public System.Int64? PosixUser_Uid { get; set; }
        #endregion
        
        #region Parameter OpenZFSConfiguration_VolumeId
        /// <summary>
        /// <para>
        /// <para>The ID of the FSx for OpenZFS volume to which you want the S3 access point attached.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenZFSConfiguration_VolumeId { get; set; }
        #endregion
        
        #region Parameter VpcConfiguration_VpcId
        /// <summary>
        /// <para>
        /// <para>Specifies the virtual private cloud (VPC) for the S3 access point VPC configuration,
        /// if one exists.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("S3AccessPoint_VpcConfiguration_VpcId")]
        public System.String VpcConfiguration_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'S3AccessPointAttachment'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.CreateAndAttachS3AccessPointResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.CreateAndAttachS3AccessPointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "S3AccessPointAttachment";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-FSXAndAttachS3AccessPoint (CreateAndAttachS3AccessPoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.CreateAndAttachS3AccessPointResponse, NewFSXAndAttachS3AccessPointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientRequestToken = this.ClientRequestToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PosixUser_Gid = this.PosixUser_Gid;
            if (this.PosixUser_SecondaryGid != null)
            {
                context.PosixUser_SecondaryGid = new List<System.Int64>(this.PosixUser_SecondaryGid);
            }
            context.PosixUser_Uid = this.PosixUser_Uid;
            context.FileSystemIdentity_Type = this.FileSystemIdentity_Type;
            context.OpenZFSConfiguration_VolumeId = this.OpenZFSConfiguration_VolumeId;
            context.S3AccessPoint_Policy = this.S3AccessPoint_Policy;
            context.VpcConfiguration_VpcId = this.VpcConfiguration_VpcId;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.FSx.Model.CreateAndAttachS3AccessPointRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OpenZFSConfiguration
            var requestOpenZFSConfigurationIsNull = true;
            request.OpenZFSConfiguration = new Amazon.FSx.Model.CreateAndAttachS3AccessPointOpenZFSConfiguration();
            System.String requestOpenZFSConfiguration_openZFSConfiguration_VolumeId = null;
            if (cmdletContext.OpenZFSConfiguration_VolumeId != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_VolumeId = cmdletContext.OpenZFSConfiguration_VolumeId;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_VolumeId != null)
            {
                request.OpenZFSConfiguration.VolumeId = requestOpenZFSConfiguration_openZFSConfiguration_VolumeId;
                requestOpenZFSConfigurationIsNull = false;
            }
            Amazon.FSx.Model.OpenZFSFileSystemIdentity requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity = null;
            
             // populate FileSystemIdentity
            var requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentityIsNull = true;
            requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity = new Amazon.FSx.Model.OpenZFSFileSystemIdentity();
            Amazon.FSx.OpenZFSFileSystemUserType requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_fileSystemIdentity_Type = null;
            if (cmdletContext.FileSystemIdentity_Type != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_fileSystemIdentity_Type = cmdletContext.FileSystemIdentity_Type;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_fileSystemIdentity_Type != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity.Type = requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_fileSystemIdentity_Type;
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentityIsNull = false;
            }
            Amazon.FSx.Model.OpenZFSPosixFileSystemUser requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser = null;
            
             // populate PosixUser
            var requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUserIsNull = true;
            requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser = new Amazon.FSx.Model.OpenZFSPosixFileSystemUser();
            System.Int64? requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_Gid = null;
            if (cmdletContext.PosixUser_Gid != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_Gid = cmdletContext.PosixUser_Gid.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_Gid != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser.Gid = requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_Gid.Value;
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUserIsNull = false;
            }
            List<System.Int64> requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_SecondaryGid = null;
            if (cmdletContext.PosixUser_SecondaryGid != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_SecondaryGid = cmdletContext.PosixUser_SecondaryGid;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_SecondaryGid != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser.SecondaryGids = requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_SecondaryGid;
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUserIsNull = false;
            }
            System.Int64? requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_Uid = null;
            if (cmdletContext.PosixUser_Uid != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_Uid = cmdletContext.PosixUser_Uid.Value;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_Uid != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser.Uid = requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser_posixUser_Uid.Value;
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUserIsNull = false;
            }
             // determine if requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser should be set to null
            if (requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUserIsNull)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser = null;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser != null)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity.PosixUser = requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity_openZFSConfiguration_FileSystemIdentity_PosixUser;
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentityIsNull = false;
            }
             // determine if requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity should be set to null
            if (requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentityIsNull)
            {
                requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity = null;
            }
            if (requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity != null)
            {
                request.OpenZFSConfiguration.FileSystemIdentity = requestOpenZFSConfiguration_openZFSConfiguration_FileSystemIdentity;
                requestOpenZFSConfigurationIsNull = false;
            }
             // determine if request.OpenZFSConfiguration should be set to null
            if (requestOpenZFSConfigurationIsNull)
            {
                request.OpenZFSConfiguration = null;
            }
            
             // populate S3AccessPoint
            var requestS3AccessPointIsNull = true;
            request.S3AccessPoint = new Amazon.FSx.Model.CreateAndAttachS3AccessPointS3Configuration();
            System.String requestS3AccessPoint_s3AccessPoint_Policy = null;
            if (cmdletContext.S3AccessPoint_Policy != null)
            {
                requestS3AccessPoint_s3AccessPoint_Policy = cmdletContext.S3AccessPoint_Policy;
            }
            if (requestS3AccessPoint_s3AccessPoint_Policy != null)
            {
                request.S3AccessPoint.Policy = requestS3AccessPoint_s3AccessPoint_Policy;
                requestS3AccessPointIsNull = false;
            }
            Amazon.FSx.Model.S3AccessPointVpcConfiguration requestS3AccessPoint_s3AccessPoint_VpcConfiguration = null;
            
             // populate VpcConfiguration
            var requestS3AccessPoint_s3AccessPoint_VpcConfigurationIsNull = true;
            requestS3AccessPoint_s3AccessPoint_VpcConfiguration = new Amazon.FSx.Model.S3AccessPointVpcConfiguration();
            System.String requestS3AccessPoint_s3AccessPoint_VpcConfiguration_vpcConfiguration_VpcId = null;
            if (cmdletContext.VpcConfiguration_VpcId != null)
            {
                requestS3AccessPoint_s3AccessPoint_VpcConfiguration_vpcConfiguration_VpcId = cmdletContext.VpcConfiguration_VpcId;
            }
            if (requestS3AccessPoint_s3AccessPoint_VpcConfiguration_vpcConfiguration_VpcId != null)
            {
                requestS3AccessPoint_s3AccessPoint_VpcConfiguration.VpcId = requestS3AccessPoint_s3AccessPoint_VpcConfiguration_vpcConfiguration_VpcId;
                requestS3AccessPoint_s3AccessPoint_VpcConfigurationIsNull = false;
            }
             // determine if requestS3AccessPoint_s3AccessPoint_VpcConfiguration should be set to null
            if (requestS3AccessPoint_s3AccessPoint_VpcConfigurationIsNull)
            {
                requestS3AccessPoint_s3AccessPoint_VpcConfiguration = null;
            }
            if (requestS3AccessPoint_s3AccessPoint_VpcConfiguration != null)
            {
                request.S3AccessPoint.VpcConfiguration = requestS3AccessPoint_s3AccessPoint_VpcConfiguration;
                requestS3AccessPointIsNull = false;
            }
             // determine if request.S3AccessPoint should be set to null
            if (requestS3AccessPointIsNull)
            {
                request.S3AccessPoint = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.FSx.Model.CreateAndAttachS3AccessPointResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.CreateAndAttachS3AccessPointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "CreateAndAttachS3AccessPoint");
            try
            {
                #if DESKTOP
                return client.CreateAndAttachS3AccessPoint(request);
                #elif CORECLR
                return client.CreateAndAttachS3AccessPointAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String Name { get; set; }
            public System.Int64? PosixUser_Gid { get; set; }
            public List<System.Int64> PosixUser_SecondaryGid { get; set; }
            public System.Int64? PosixUser_Uid { get; set; }
            public Amazon.FSx.OpenZFSFileSystemUserType FileSystemIdentity_Type { get; set; }
            public System.String OpenZFSConfiguration_VolumeId { get; set; }
            public System.String S3AccessPoint_Policy { get; set; }
            public System.String VpcConfiguration_VpcId { get; set; }
            public Amazon.FSx.S3AccessPointAttachmentType Type { get; set; }
            public System.Func<Amazon.FSx.Model.CreateAndAttachS3AccessPointResponse, NewFSXAndAttachS3AccessPointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.S3AccessPointAttachment;
        }
        
    }
}
