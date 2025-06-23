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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Creates a mount target for a file system. You can then mount the file system on EC2
    /// instances by using the mount target.
    /// 
    ///  
    /// <para>
    /// You can create one mount target in each Availability Zone in your VPC. All EC2 instances
    /// in a VPC within a given Availability Zone share a single mount target for a given
    /// file system. If you have multiple subnets in an Availability Zone, you create a mount
    /// target in one of the subnets. EC2 instances do not need to be in the same subnet as
    /// the mount target in order to access their file system.
    /// </para><para>
    /// You can create only one mount target for a One Zone file system. You must create that
    /// mount target in the same Availability Zone in which the file system is located. Use
    /// the <c>AvailabilityZoneName</c> and <c>AvailabiltyZoneId</c> properties in the <a>DescribeFileSystems</a>
    /// response object to get this information. Use the <c>subnetId</c> associated with the
    /// file system's Availability Zone when creating the mount target.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/efs/latest/ug/how-it-works.html">Amazon
    /// EFS: How it Works</a>. 
    /// </para><para>
    /// To create a mount target for a file system, the file system's lifecycle state must
    /// be <c>available</c>. For more information, see <a>DescribeFileSystems</a>.
    /// </para><para>
    /// In the request, provide the following:
    /// </para><ul><li><para>
    /// The file system ID for which you are creating the mount target.
    /// </para></li><li><para>
    /// A subnet ID, which determines the following:
    /// </para><ul><li><para>
    /// The VPC in which Amazon EFS creates the mount target
    /// </para></li><li><para>
    /// The Availability Zone in which Amazon EFS creates the mount target
    /// </para></li><li><para>
    /// The IP address range from which Amazon EFS selects the IP address of the mount target
    /// (if you don't specify an IP address in the request)
    /// </para></li></ul></li></ul><para>
    /// After creating the mount target, Amazon EFS returns a response that includes, a <c>MountTargetId</c>
    /// and an <c>IpAddress</c>. You use this IP address when mounting the file system in
    /// an EC2 instance. You can also use the mount target's DNS name when mounting the file
    /// system. The EC2 instance on which you mount the file system by using the mount target
    /// can resolve the mount target's DNS name to its IP address. For more information, see
    /// <a href="https://docs.aws.amazon.com/efs/latest/ug/how-it-works.html#how-it-works-implementation">How
    /// it Works: Implementation Overview</a>. 
    /// </para><para>
    /// Note that you can create mount targets for a file system in only one VPC, and there
    /// can be only one mount target per Availability Zone. That is, if the file system already
    /// has one or more mount targets created for it, the subnet specified in the request
    /// to add another mount target must meet the following requirements:
    /// </para><ul><li><para>
    /// Must belong to the same VPC as the subnets of the existing mount targets
    /// </para></li><li><para>
    /// Must not be in the same Availability Zone as any of the subnets of the existing mount
    /// targets
    /// </para></li></ul><para>
    /// If the request satisfies the requirements, Amazon EFS does the following:
    /// </para><ul><li><para>
    /// Creates a new mount target in the specified subnet.
    /// </para></li><li><para>
    /// Also creates a new network interface in the subnet as follows:
    /// </para><ul><li><para>
    /// If the request provides an <c>IpAddress</c>, Amazon EFS assigns that IP address to
    /// the network interface. Otherwise, Amazon EFS assigns a free address in the subnet
    /// (in the same way that the Amazon EC2 <c>CreateNetworkInterface</c> call does when
    /// a request does not specify a primary private IP address).
    /// </para></li><li><para>
    /// If the request provides <c>SecurityGroups</c>, this network interface is associated
    /// with those security groups. Otherwise, it belongs to the default security group for
    /// the subnet's VPC.
    /// </para></li><li><para>
    /// Assigns the description <c>Mount target <i>fsmt-id</i> for file system <i>fs-id</i></c> where <c><i>fsmt-id</i></c> is the mount target ID, and <c><i>fs-id</i></c>
    /// is the <c>FileSystemId</c>.
    /// </para></li><li><para>
    /// Sets the <c>requesterManaged</c> property of the network interface to <c>true</c>,
    /// and the <c>requesterId</c> value to <c>EFS</c>.
    /// </para></li></ul><para>
    /// Each Amazon EFS mount target has one corresponding requester-managed EC2 network interface.
    /// After the network interface is created, Amazon EFS sets the <c>NetworkInterfaceId</c>
    /// field in the mount target's description to the network interface ID, and the <c>IpAddress</c>
    /// field to its address. If network interface creation fails, the entire <c>CreateMountTarget</c>
    /// operation fails.
    /// </para></li></ul><note><para>
    /// The <c>CreateMountTarget</c> call returns only after creating the network interface,
    /// but while the mount target state is still <c>creating</c>, you can check the mount
    /// target creation status by calling the <a>DescribeMountTargets</a> operation, which
    /// among other things returns the mount target state.
    /// </para></note><para>
    /// We recommend that you create a mount target in each of the Availability Zones. There
    /// are cost considerations for using a file system in an Availability Zone through a
    /// mount target created in another Availability Zone. For more information, see <a href="http://aws.amazon.com/efs/pricing/">Amazon
    /// EFS pricing</a>. In addition, by always using a mount target local to the instance's
    /// Availability Zone, you eliminate a partial failure scenario. If the Availability Zone
    /// in which your mount target is created goes down, then you can't access your file system
    /// through that mount target. 
    /// </para><para>
    /// This operation requires permissions for the following action on the file system:
    /// </para><ul><li><para><c>elasticfilesystem:CreateMountTarget</c></para></li></ul><para>
    /// This operation also requires permissions for the following Amazon EC2 actions:
    /// </para><ul><li><para><c>ec2:DescribeSubnets</c></para></li><li><para><c>ec2:DescribeNetworkInterfaces</c></para></li><li><para><c>ec2:CreateNetworkInterface</c></para></li></ul>
    /// </summary>
    [Cmdlet("New", "EFSMountTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.CreateMountTargetResponse")]
    [AWSCmdlet("Calls the Amazon Elastic File System CreateMountTarget API operation.", Operation = new[] {"CreateMountTarget"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.CreateMountTargetResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.CreateMountTargetResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.Model.CreateMountTargetResponse object containing multiple properties."
    )]
    public partial class NewEFSMountTargetCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the file system for which to create the mount target.</para>
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter IpAddress
        /// <summary>
        /// <para>
        /// <para>If the IP address type for the mount target is IPv4, then specify the IPv4 address
        /// within the address range of the specified subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IpAddress { get; set; }
        #endregion
        
        #region Parameter IpAddressType
        /// <summary>
        /// <para>
        /// <para>Specify the type of IP address of the mount target you are creating. Options are IPv4,
        /// dual stack, or IPv6. If you don’t specify an IpAddressType, then IPv4 is used.</para><ul><li><para>IPV4_ONLY – Create mount target with IPv4 only subnet or dual-stack subnet.</para></li><li><para>DUAL_STACK – Create mount target with dual-stack subnet.</para></li><li><para>IPV6_ONLY – Create mount target with IPv6 only subnet.</para></li></ul><note><para>Creating IPv6 mount target only ENI in dual-stack subnet is not supported.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticFileSystem.IpAddressType")]
        public Amazon.ElasticFileSystem.IpAddressType IpAddressType { get; set; }
        #endregion
        
        #region Parameter Ipv6Address
        /// <summary>
        /// <para>
        /// <para>If the IP address type for the mount target is IPv6, then specify the IPv6 address
        /// within the address range of the specified subnet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ipv6Address { get; set; }
        #endregion
        
        #region Parameter SecurityGroup
        /// <summary>
        /// <para>
        /// <para>VPC security group IDs, of the form <c>sg-xxxxxxxx</c>. These must be for the same
        /// VPC as the subnet specified. The maximum number of security groups depends on account
        /// quota. For more information, see <a href="https://docs.aws.amazon.com/vpc/latest/userguide/amazon-vpc-limits.html">Amazon
        /// VPC Quotas</a> in the <i>Amazon VPC User Guide</i> (see the <b>Security Groups</b>
        /// table). </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroups")]
        public System.String[] SecurityGroup { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>The ID of the subnet to add the mount target in. For One Zone file systems, use the
        /// subnet that is associated with the file system's Availability Zone.</para>
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
        public System.String SubnetId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.CreateMountTargetResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.CreateMountTargetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EFSMountTarget (CreateMountTarget)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.CreateMountTargetResponse, NewEFSMountTargetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IpAddress = this.IpAddress;
            context.IpAddressType = this.IpAddressType;
            context.Ipv6Address = this.Ipv6Address;
            if (this.SecurityGroup != null)
            {
                context.SecurityGroup = new List<System.String>(this.SecurityGroup);
            }
            context.SubnetId = this.SubnetId;
            #if MODULAR
            if (this.SubnetId == null && ParameterWasBound(nameof(this.SubnetId)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticFileSystem.Model.CreateMountTargetRequest();
            
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.IpAddress != null)
            {
                request.IpAddress = cmdletContext.IpAddress;
            }
            if (cmdletContext.IpAddressType != null)
            {
                request.IpAddressType = cmdletContext.IpAddressType;
            }
            if (cmdletContext.Ipv6Address != null)
            {
                request.Ipv6Address = cmdletContext.Ipv6Address;
            }
            if (cmdletContext.SecurityGroup != null)
            {
                request.SecurityGroups = cmdletContext.SecurityGroup;
            }
            if (cmdletContext.SubnetId != null)
            {
                request.SubnetId = cmdletContext.SubnetId;
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
        
        private Amazon.ElasticFileSystem.Model.CreateMountTargetResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.CreateMountTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "CreateMountTarget");
            try
            {
                return client.CreateMountTargetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String FileSystemId { get; set; }
            public System.String IpAddress { get; set; }
            public Amazon.ElasticFileSystem.IpAddressType IpAddressType { get; set; }
            public System.String Ipv6Address { get; set; }
            public List<System.String> SecurityGroup { get; set; }
            public System.String SubnetId { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.CreateMountTargetResponse, NewEFSMountTargetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
