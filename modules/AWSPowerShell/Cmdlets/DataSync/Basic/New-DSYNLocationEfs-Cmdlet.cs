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
using Amazon.DataSync;
using Amazon.DataSync.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Creates a transfer <i>location</i> for an Amazon EFS file system. DataSync can use
    /// this location as a source or destination for transferring data.
    /// 
    ///  
    /// <para>
    /// Before you begin, make sure that you understand how DataSync <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-efs-location.html#create-efs-location-access">accesses
    /// Amazon EFS file systems</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "DSYNLocationEfs", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS DataSync CreateLocationEfs API operation.", Operation = new[] {"CreateLocationEfs"}, SelectReturnType = typeof(Amazon.DataSync.Model.CreateLocationEfsResponse))]
    [AWSCmdletOutput("System.String or Amazon.DataSync.Model.CreateLocationEfsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DataSync.Model.CreateLocationEfsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDSYNLocationEfsCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessPointArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the access point that DataSync uses to
        /// mount your Amazon EFS file system.</para><para>For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-efs-location.html#create-efs-location-iam">Accessing
        /// restricted file systems</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessPointArn { get; set; }
        #endregion
        
        #region Parameter EfsFilesystemArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN for your Amazon EFS file system.</para>
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
        public System.String EfsFilesystemArn { get; set; }
        #endregion
        
        #region Parameter FileSystemAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>Specifies an Identity and Access Management (IAM) role that allows DataSync to access
        /// your Amazon EFS file system.</para><para>For information on creating this role, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-efs-location.html#create-efs-location-iam-role">Creating
        /// a DataSync IAM role for file system access</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FileSystemAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter InTransitEncryption
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want DataSync to use Transport Layer Security (TLS) 1.2 encryption
        /// when it transfers data to or from your Amazon EFS file system.</para><para>If you specify an access point using <c>AccessPointArn</c> or an IAM role using <c>FileSystemAccessRoleArn</c>,
        /// you must set this parameter to <c>TLS1_2</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.EfsInTransitEncryption")]
        public Amazon.DataSync.EfsInTransitEncryption InTransitEncryption { get; set; }
        #endregion
        
        #region Parameter Ec2Config_SecurityGroupArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Names (ARNs) of the security groups associated with
        /// an Amazon EFS file system's mount target.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Ec2Config_SecurityGroupArns")]
        public System.String[] Ec2Config_SecurityGroupArn { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>Specifies a mount path for your Amazon EFS file system. This is where DataSync reads
        /// or writes data on your file system (depending on if this is a source or destination
        /// location).</para><para>By default, DataSync uses the root directory (or <a href="https://docs.aws.amazon.com/efs/latest/ug/efs-access-points.html">access
        /// point</a> if you provide one by using <c>AccessPointArn</c>). You can also include
        /// subdirectories using forward slashes (for example, <c>/path/to/folder</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter Ec2Config_SubnetArn
        /// <summary>
        /// <para>
        /// <para>Specifies the ARN of a subnet where DataSync creates the <a href="https://docs.aws.amazon.com/datasync/latest/userguide/datasync-network.html#required-network-interfaces">network
        /// interfaces</a> for managing traffic during your transfer.</para><para>The subnet must be located:</para><ul><li><para>In the same virtual private cloud (VPC) as the Amazon EFS file system.</para></li><li><para>In the same Availability Zone as at least one mount target for the Amazon EFS file
        /// system.</para></li></ul><note><para>You don't need to specify a subnet that includes a file system mount target.</para></note>
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
        public System.String Ec2Config_SubnetArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies the key-value pair that represents a tag that you want to add to the resource.
        /// The value can be an empty string. This value helps you manage, filter, and search
        /// for your resources. We recommend that you create a name tag for your location.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DataSync.Model.TagListEntry[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LocationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.CreateLocationEfsResponse).
        /// Specifying the name of a property of type Amazon.DataSync.Model.CreateLocationEfsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LocationArn";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DSYNLocationEfs (CreateLocationEfs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.CreateLocationEfsResponse, NewDSYNLocationEfsCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessPointArn = this.AccessPointArn;
            if (this.Ec2Config_SecurityGroupArn != null)
            {
                context.Ec2Config_SecurityGroupArn = new List<System.String>(this.Ec2Config_SecurityGroupArn);
            }
            #if MODULAR
            if (this.Ec2Config_SecurityGroupArn == null && ParameterWasBound(nameof(this.Ec2Config_SecurityGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Ec2Config_SecurityGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Ec2Config_SubnetArn = this.Ec2Config_SubnetArn;
            #if MODULAR
            if (this.Ec2Config_SubnetArn == null && ParameterWasBound(nameof(this.Ec2Config_SubnetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter Ec2Config_SubnetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EfsFilesystemArn = this.EfsFilesystemArn;
            #if MODULAR
            if (this.EfsFilesystemArn == null && ParameterWasBound(nameof(this.EfsFilesystemArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EfsFilesystemArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FileSystemAccessRoleArn = this.FileSystemAccessRoleArn;
            context.InTransitEncryption = this.InTransitEncryption;
            context.Subdirectory = this.Subdirectory;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DataSync.Model.TagListEntry>(this.Tag);
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
            var request = new Amazon.DataSync.Model.CreateLocationEfsRequest();
            
            if (cmdletContext.AccessPointArn != null)
            {
                request.AccessPointArn = cmdletContext.AccessPointArn;
            }
            
             // populate Ec2Config
            var requestEc2ConfigIsNull = true;
            request.Ec2Config = new Amazon.DataSync.Model.Ec2Config();
            List<System.String> requestEc2Config_ec2Config_SecurityGroupArn = null;
            if (cmdletContext.Ec2Config_SecurityGroupArn != null)
            {
                requestEc2Config_ec2Config_SecurityGroupArn = cmdletContext.Ec2Config_SecurityGroupArn;
            }
            if (requestEc2Config_ec2Config_SecurityGroupArn != null)
            {
                request.Ec2Config.SecurityGroupArns = requestEc2Config_ec2Config_SecurityGroupArn;
                requestEc2ConfigIsNull = false;
            }
            System.String requestEc2Config_ec2Config_SubnetArn = null;
            if (cmdletContext.Ec2Config_SubnetArn != null)
            {
                requestEc2Config_ec2Config_SubnetArn = cmdletContext.Ec2Config_SubnetArn;
            }
            if (requestEc2Config_ec2Config_SubnetArn != null)
            {
                request.Ec2Config.SubnetArn = requestEc2Config_ec2Config_SubnetArn;
                requestEc2ConfigIsNull = false;
            }
             // determine if request.Ec2Config should be set to null
            if (requestEc2ConfigIsNull)
            {
                request.Ec2Config = null;
            }
            if (cmdletContext.EfsFilesystemArn != null)
            {
                request.EfsFilesystemArn = cmdletContext.EfsFilesystemArn;
            }
            if (cmdletContext.FileSystemAccessRoleArn != null)
            {
                request.FileSystemAccessRoleArn = cmdletContext.FileSystemAccessRoleArn;
            }
            if (cmdletContext.InTransitEncryption != null)
            {
                request.InTransitEncryption = cmdletContext.InTransitEncryption;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
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
        
        private Amazon.DataSync.Model.CreateLocationEfsResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.CreateLocationEfsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "CreateLocationEfs");
            try
            {
                return client.CreateLocationEfsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccessPointArn { get; set; }
            public List<System.String> Ec2Config_SecurityGroupArn { get; set; }
            public System.String Ec2Config_SubnetArn { get; set; }
            public System.String EfsFilesystemArn { get; set; }
            public System.String FileSystemAccessRoleArn { get; set; }
            public Amazon.DataSync.EfsInTransitEncryption InTransitEncryption { get; set; }
            public System.String Subdirectory { get; set; }
            public List<Amazon.DataSync.Model.TagListEntry> Tag { get; set; }
            public System.Func<Amazon.DataSync.Model.CreateLocationEfsResponse, NewDSYNLocationEfsCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LocationArn;
        }
        
    }
}
