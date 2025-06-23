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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Registers an AMI. When you're creating an instance-store backed AMI, registering the
    /// AMI is the final step in the creation process. For more information about creating
    /// AMIs, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/creating-an-ami-ebs.html#creating-launching-ami-from-snapshot">Create
    /// an AMI from a snapshot</a> and <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/creating-an-ami-instance-store.html">Create
    /// an instance-store backed AMI</a> in the <i>Amazon EC2 User Guide</i>.
    /// 
    ///  <note><para>
    /// For Amazon EBS-backed instances, <a>CreateImage</a> creates and registers the AMI
    /// in a single request, so you don't have to register the AMI yourself. We recommend
    /// that you always use <a>CreateImage</a> unless you have a specific reason to use RegisterImage.
    /// </para></note><para>
    /// If needed, you can deregister an AMI at any time. Any modifications you make to an
    /// AMI backed by an instance store volume invalidates its registration. If you make changes
    /// to an image, deregister the previous image and register the new image.
    /// </para><para><b>Register a snapshot of a root device volume</b></para><para>
    /// You can use <c>RegisterImage</c> to create an Amazon EBS-backed Linux AMI from a snapshot
    /// of a root device volume. You specify the snapshot using a block device mapping. You
    /// can't set the encryption state of the volume using the block device mapping. If the
    /// snapshot is encrypted, or encryption by default is enabled, the root volume of an
    /// instance launched from the AMI is encrypted.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/creating-an-ami-ebs.html#creating-launching-ami-from-snapshot">Create
    /// an AMI from a snapshot</a> and <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/AMIEncryption.html">Use
    /// encryption with EBS-backed AMIs</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para><b>Amazon Web Services Marketplace product codes</b></para><para>
    /// If any snapshots have Amazon Web Services Marketplace product codes, they are copied
    /// to the new AMI.
    /// </para><para>
    /// In most cases, AMIs for Windows, RedHat, SUSE, and SQL Server require correct licensing
    /// information to be present on the AMI. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ami-billing-info.html">Understand
    /// AMI billing information</a> in the <i>Amazon EC2 User Guide</i>. When creating an
    /// AMI from a snapshot, the <c>RegisterImage</c> operation derives the correct billing
    /// information from the snapshot's metadata, but this requires the appropriate metadata
    /// to be present. To verify if the correct billing information was applied, check the
    /// <c>PlatformDetails</c> field on the new AMI. If the field is empty or doesn't match
    /// the expected operating system code (for example, Windows, RedHat, SUSE, or SQL), the
    /// AMI creation was unsuccessful, and you should discard the AMI and instead create the
    /// AMI from an instance using <a>CreateImage</a>. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/creating-an-ami-ebs.html#how-to-create-ebs-ami">Create
    /// an AMI from an instance </a> in the <i>Amazon EC2 User Guide</i>.
    /// </para><para>
    /// If you purchase a Reserved Instance to apply to an On-Demand Instance that was launched
    /// from an AMI with a billing product code, make sure that the Reserved Instance has
    /// the matching billing product code. If you purchase a Reserved Instance without the
    /// matching billing product code, the Reserved Instance will not be applied to the On-Demand
    /// Instance. For information about how to obtain the platform details and billing information
    /// of an AMI, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ami-billing-info.html">Understand
    /// AMI billing information</a> in the <i>Amazon EC2 User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "EC2Image", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) RegisterImage API operation.", Operation = new[] {"RegisterImage"}, SelectReturnType = typeof(Amazon.EC2.Model.RegisterImageResponse))]
    [AWSCmdletOutput("System.String or Amazon.EC2.Model.RegisterImageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EC2.Model.RegisterImageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterEC2ImageCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Architecture
        /// <summary>
        /// <para>
        /// <para>The architecture of the AMI.</para><para>Default: For Amazon EBS-backed AMIs, <c>i386</c>. For instance store-backed AMIs,
        /// the architecture specified in the manifest file.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.ArchitectureValues")]
        public Amazon.EC2.ArchitectureValues Architecture { get; set; }
        #endregion
        
        #region Parameter BillingProduct
        /// <summary>
        /// <para>
        /// <para>The billing product codes. Your account must be authorized to specify billing product
        /// codes.</para><para>If your account is not authorized to specify billing product codes, you can publish
        /// AMIs that include billable software and list them on the Amazon Web Services Marketplace.
        /// You must first register as a seller on the Amazon Web Services Marketplace. For more
        /// information, see <a href="https://docs.aws.amazon.com/marketplace/latest/userguide/user-guide-for-sellers.html">Getting
        /// started as an Amazon Web Services Marketplace seller</a> and <a href="https://docs.aws.amazon.com/marketplace/latest/userguide/ami-products.html">AMI-based
        /// products in Amazon Web Services Marketplace</a> in the <i>Amazon Web Services Marketplace
        /// Seller Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BillingProducts")]
        public System.String[] BillingProduct { get; set; }
        #endregion
        
        #region Parameter BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>The block device mapping entries.</para><para>If you specify an Amazon EBS volume using the ID of an Amazon EBS snapshot, you can't
        /// specify the encryption state of the volume.</para><para>If you create an AMI on an Outpost, then all backing snapshots must be on the same
        /// Outpost or in the Region of that Outpost. AMIs on an Outpost that include local snapshots
        /// can be used to launch instances on the same Outpost only. For more information, <a href="https://docs.aws.amazon.com/ebs/latest/userguide/snapshots-outposts.html#ami">Create
        /// AMIs from local snapshots</a> in the <i>Amazon EBS User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockDeviceMappings")]
        public Amazon.EC2.Model.BlockDeviceMapping[] BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter BootMode
        /// <summary>
        /// <para>
        /// <para>The boot mode of the AMI. A value of <c>uefi-preferred</c> indicates that the AMI
        /// supports both UEFI and Legacy BIOS.</para><note><para>The operating system contained in the AMI must be configured to support the specified
        /// boot mode.</para></note><para>For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ami-boot.html">Instance
        /// launch behavior with Amazon EC2 boot modes</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.BootModeValues")]
        public Amazon.EC2.BootModeValues BootMode { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for your AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter EnaSupport
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to enable enhanced networking with ENA for the AMI and any instances
        /// that you launch from the AMI.</para><para>This option is supported only for HVM AMIs. Specifying this option with a PV AMI can
        /// make instances launched from the AMI unreachable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnaSupport { get; set; }
        #endregion
        
        #region Parameter ImageLocation
        /// <summary>
        /// <para>
        /// <para>The full path to your AMI manifest in Amazon S3 storage. The specified bucket must
        /// have the <c>aws-exec-read</c> canned access control list (ACL) to ensure that it can
        /// be accessed by Amazon EC2. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/acl-overview.html#canned-acl">Canned
        /// ACL</a> in the <i>Amazon S3 Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ImageLocation { get; set; }
        #endregion
        
        #region Parameter ImdsSupport
        /// <summary>
        /// <para>
        /// <para>Set to <c>v2.0</c> to indicate that IMDSv2 is specified in the AMI. Instances launched
        /// from this AMI will have <c>HttpTokens</c> automatically set to <c>required</c> so
        /// that, by default, the instance requires that IMDSv2 is used when requesting instance
        /// metadata. In addition, <c>HttpPutResponseHopLimit</c> is set to <c>2</c>. For more
        /// information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/configuring-IMDS-new-instances.html#configure-IMDS-new-instances-ami-configuration">Configure
        /// the AMI</a> in the <i>Amazon EC2 User Guide</i>.</para><note><para>If you set the value to <c>v2.0</c>, make sure that your AMI software can support
        /// IMDSv2.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.ImdsSupportValues")]
        public Amazon.EC2.ImdsSupportValues ImdsSupport { get; set; }
        #endregion
        
        #region Parameter KernelId
        /// <summary>
        /// <para>
        /// <para>The ID of the kernel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KernelId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for your AMI.</para><para>Constraints: 3-128 alphanumeric characters, parentheses (()), square brackets ([]),
        /// spaces ( ), periods (.), slashes (/), dashes (-), single quotes ('), at-signs (@),
        /// or underscores(_)</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RamdiskId
        /// <summary>
        /// <para>
        /// <para>The ID of the RAM disk.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RamdiskId { get; set; }
        #endregion
        
        #region Parameter RootDeviceName
        /// <summary>
        /// <para>
        /// <para>The device name of the root device volume (for example, <c>/dev/sda1</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RootDeviceName { get; set; }
        #endregion
        
        #region Parameter SriovNetSupport
        /// <summary>
        /// <para>
        /// <para>Set to <c>simple</c> to enable enhanced networking with the Intel 82599 Virtual Function
        /// interface for the AMI and any instances that you launch from the AMI.</para><para>There is no way to disable <c>sriovNetSupport</c> at this time.</para><para>This option is supported only for HVM AMIs. Specifying this option with a PV AMI can
        /// make instances launched from the AMI unreachable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SriovNetSupport { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the AMI.</para><para>To tag the AMI, the value for <c>ResourceType</c> must be <c>image</c>. If you specify
        /// another value for <c>ResourceType</c>, the request fails.</para><para>To tag an AMI after it has been registered, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateTags.html">CreateTags</a>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TpmSupport
        /// <summary>
        /// <para>
        /// <para>Set to <c>v2.0</c> to enable Trusted Platform Module (TPM) support. For more information,
        /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/nitrotpm.html">NitroTPM</a>
        /// in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.TpmSupportValues")]
        public Amazon.EC2.TpmSupportValues TpmSupport { get; set; }
        #endregion
        
        #region Parameter UefiData
        /// <summary>
        /// <para>
        /// <para>Base64 representation of the non-volatile UEFI variable store. To retrieve the UEFI
        /// data, use the <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_GetInstanceUefiData">GetInstanceUefiData</a>
        /// command. You can inspect and modify the UEFI data by using the <a href="https://github.com/awslabs/python-uefivars">python-uefivars
        /// tool</a> on GitHub. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/uefi-secure-boot.html">UEFI
        /// Secure Boot for Amazon EC2 instances</a> in the <i>Amazon EC2 User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UefiData { get; set; }
        #endregion
        
        #region Parameter VirtualizationType
        /// <summary>
        /// <para>
        /// <para>The type of virtualization (<c>hvm</c> | <c>paravirtual</c>).</para><para>Default: <c>paravirtual</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VirtualizationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.RegisterImageResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.RegisterImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageLocation), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-EC2Image (RegisterImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.RegisterImageResponse, RegisterEC2ImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Architecture = this.Architecture;
            if (this.BillingProduct != null)
            {
                context.BillingProduct = new List<System.String>(this.BillingProduct);
            }
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMapping = new List<Amazon.EC2.Model.BlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.BootMode = this.BootMode;
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.EnaSupport = this.EnaSupport;
            context.ImageLocation = this.ImageLocation;
            context.ImdsSupport = this.ImdsSupport;
            context.KernelId = this.KernelId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RamdiskId = this.RamdiskId;
            context.RootDeviceName = this.RootDeviceName;
            context.SriovNetSupport = this.SriovNetSupport;
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TpmSupport = this.TpmSupport;
            context.UefiData = this.UefiData;
            context.VirtualizationType = this.VirtualizationType;
            
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
            var request = new Amazon.EC2.Model.RegisterImageRequest();
            
            if (cmdletContext.Architecture != null)
            {
                request.Architecture = cmdletContext.Architecture;
            }
            if (cmdletContext.BillingProduct != null)
            {
                request.BillingProducts = cmdletContext.BillingProduct;
            }
            if (cmdletContext.BlockDeviceMapping != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMapping;
            }
            if (cmdletContext.BootMode != null)
            {
                request.BootMode = cmdletContext.BootMode;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.EnaSupport != null)
            {
                request.EnaSupport = cmdletContext.EnaSupport.Value;
            }
            if (cmdletContext.ImageLocation != null)
            {
                request.ImageLocation = cmdletContext.ImageLocation;
            }
            if (cmdletContext.ImdsSupport != null)
            {
                request.ImdsSupport = cmdletContext.ImdsSupport;
            }
            if (cmdletContext.KernelId != null)
            {
                request.KernelId = cmdletContext.KernelId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RamdiskId != null)
            {
                request.RamdiskId = cmdletContext.RamdiskId;
            }
            if (cmdletContext.RootDeviceName != null)
            {
                request.RootDeviceName = cmdletContext.RootDeviceName;
            }
            if (cmdletContext.SriovNetSupport != null)
            {
                request.SriovNetSupport = cmdletContext.SriovNetSupport;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TpmSupport != null)
            {
                request.TpmSupport = cmdletContext.TpmSupport;
            }
            if (cmdletContext.UefiData != null)
            {
                request.UefiData = cmdletContext.UefiData;
            }
            if (cmdletContext.VirtualizationType != null)
            {
                request.VirtualizationType = cmdletContext.VirtualizationType;
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
        
        private Amazon.EC2.Model.RegisterImageResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RegisterImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "RegisterImage");
            try
            {
                return client.RegisterImageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EC2.ArchitectureValues Architecture { get; set; }
            public List<System.String> BillingProduct { get; set; }
            public List<Amazon.EC2.Model.BlockDeviceMapping> BlockDeviceMapping { get; set; }
            public Amazon.EC2.BootModeValues BootMode { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.Boolean? EnaSupport { get; set; }
            public System.String ImageLocation { get; set; }
            public Amazon.EC2.ImdsSupportValues ImdsSupport { get; set; }
            public System.String KernelId { get; set; }
            public System.String Name { get; set; }
            public System.String RamdiskId { get; set; }
            public System.String RootDeviceName { get; set; }
            public System.String SriovNetSupport { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public Amazon.EC2.TpmSupportValues TpmSupport { get; set; }
            public System.String UefiData { get; set; }
            public System.String VirtualizationType { get; set; }
            public System.Func<Amazon.EC2.Model.RegisterImageResponse, RegisterEC2ImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageId;
        }
        
    }
}
