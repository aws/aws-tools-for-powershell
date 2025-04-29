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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Creates a new stack. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-edit.html">Create
    /// a New Stack</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have an attached
    /// policy that explicitly grants permissions. For more information about user permissions,
    /// see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OPSStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS OpsWorks CreateStack API operation.", Operation = new[] {"CreateStack"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.CreateStackResponse))]
    [AWSCmdletOutput("System.String or Amazon.OpsWorks.Model.CreateStackResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.OpsWorks.Model.CreateStackResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOPSStackCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentVersion
        /// <summary>
        /// <para>
        /// <para>The default OpsWorks Stacks agent version. You have the following options:</para><ul><li><para>Auto-update - Set this parameter to <c>LATEST</c>. OpsWorks Stacks automatically installs
        /// new agent versions on the stack's instances as soon as they are available.</para></li><li><para>Fixed version - Set this parameter to your preferred agent version. To update the
        /// agent version, you must edit the stack configuration and specify a new version. OpsWorks
        /// Stacks installs that version on the stack's instances.</para></li></ul><para>The default setting is the most recent release of the agent. To specify an agent version,
        /// you must use the complete version number, not the abbreviated number shown on the
        /// console. For a list of available agent version numbers, call <a>DescribeAgentVersions</a>.
        /// AgentVersion cannot be set to Chef 12.2.</para><note><para>You can also specify an agent version when you create or update an instance, which
        /// overrides the stack's default setting.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgentVersion { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>One or more user-defined key-value pairs to be added to the stack attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter ChefConfiguration_BerkshelfVersion
        /// <summary>
        /// <para>
        /// <para>The Berkshelf version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChefConfiguration_BerkshelfVersion { get; set; }
        #endregion
        
        #region Parameter CustomJson
        /// <summary>
        /// <para>
        /// <para>A string that contains user-defined, custom JSON. It can be used to override the corresponding
        /// default stack configuration attribute values or to pass data to recipes. The string
        /// should be in the following format:</para><para><c>"{\"key1\": \"value1\", \"key2\": \"value2\",...}"</c></para><para>For more information about custom JSON, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-json.html">Use
        /// Custom JSON to Modify the Stack Configuration Attributes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomJson { get; set; }
        #endregion
        
        #region Parameter DefaultAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The stack's default Availability Zone, which must be in the specified region. For
        /// more information, see <a href="https://docs.aws.amazon.com/general/latest/gr/rande.html">Regions
        /// and Endpoints</a>. If you also specify a value for <c>DefaultSubnetId</c>, the subnet
        /// must be in the same zone. For more information, see the <c>VpcId</c> parameter description.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter DefaultInstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM profile that is the default profile for all
        /// of the stack's EC2 instances. For more information about IAM ARNs, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">Using
        /// Identifiers</a>.</para>
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
        public System.String DefaultInstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter DefaultOs
        /// <summary>
        /// <para>
        /// <para>The stack's default operating system, which is installed on every instance unless
        /// you specify a different operating system when you create the instance. You can specify
        /// one of the following.</para><ul><li><para>A supported Linux operating system: An Amazon Linux version, such as <c>Amazon Linux
        /// 2</c>, <c>Amazon Linux 2018.03</c>, <c>Amazon Linux 2017.09</c>, <c>Amazon Linux 2017.03</c>,
        /// <c>Amazon Linux 2016.09</c>, <c>Amazon Linux 2016.03</c>, <c>Amazon Linux 2015.09</c>,
        /// or <c>Amazon Linux 2015.03</c>.</para></li><li><para>A supported Ubuntu operating system, such as <c>Ubuntu 18.04 LTS</c>, <c>Ubuntu 16.04
        /// LTS</c>, <c>Ubuntu 14.04 LTS</c>, or <c>Ubuntu 12.04 LTS</c>.</para></li><li><para><c>CentOS Linux 7</c></para></li><li><para><c>Red Hat Enterprise Linux 7</c></para></li><li><para>A supported Windows operating system, such as <c>Microsoft Windows Server 2012 R2
        /// Base</c>, <c>Microsoft Windows Server 2012 R2 with SQL Server Express</c>, <c>Microsoft
        /// Windows Server 2012 R2 with SQL Server Standard</c>, or <c>Microsoft Windows Server
        /// 2012 R2 with SQL Server Web</c>.</para></li><li><para>A custom AMI: <c>Custom</c>. You specify the custom AMI you want to use when you create
        /// instances. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-custom-ami.html">
        /// Using Custom AMIs</a>.</para></li></ul><para>The default option is the current Amazon Linux version. Not all operating systems
        /// are supported with all versions of Chef. For more information about supported operating
        /// systems, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-os.html">OpsWorks
        /// Stacks Operating Systems</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultOs { get; set; }
        #endregion
        
        #region Parameter DefaultRootDeviceType
        /// <summary>
        /// <para>
        /// <para>The default root device type. This value is the default for all instances in the stack,
        /// but you can override it when you create an instance. The default option is <c>instance-store</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ComponentsAMIs.html#storage-for-the-root-device">Storage
        /// for the Root Device</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpsWorks.RootDeviceType")]
        public Amazon.OpsWorks.RootDeviceType DefaultRootDeviceType { get; set; }
        #endregion
        
        #region Parameter DefaultSshKeyName
        /// <summary>
        /// <para>
        /// <para>A default Amazon EC2 key pair name. The default value is none. If you specify a key
        /// pair name, OpsWorks installs the public key on the instance and you can use the private
        /// key with an SSH client to log in to the instance. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-ssh.html">
        /// Using SSH to Communicate with an Instance</a> and <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/security-ssh-access.html">
        /// Managing SSH Access</a>. You can override this setting by specifying a different key
        /// pair, or no key pair, when you <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-add.html">
        /// create an instance</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSshKeyName { get; set; }
        #endregion
        
        #region Parameter DefaultSubnetId
        /// <summary>
        /// <para>
        /// <para>The stack's default VPC subnet ID. This parameter is required if you specify a value
        /// for the <c>VpcId</c> parameter. All instances are launched into this subnet unless
        /// you specify otherwise when you create the instance. If you also specify a value for
        /// <c>DefaultAvailabilityZone</c>, the subnet must be in that zone. For information on
        /// default values and when this parameter is required, see the <c>VpcId</c> parameter
        /// description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DefaultSubnetId { get; set; }
        #endregion
        
        #region Parameter HostnameTheme
        /// <summary>
        /// <para>
        /// <para>The stack's host name theme, with spaces replaced by underscores. The theme is used
        /// to generate host names for the stack's instances. By default, <c>HostnameTheme</c>
        /// is set to <c>Layer_Dependent</c>, which creates host names by appending integers to
        /// the layer's short name. The other themes are:</para><ul><li><para><c>Baked_Goods</c></para></li><li><para><c>Clouds</c></para></li><li><para><c>Europe_Cities</c></para></li><li><para><c>Fruits</c></para></li><li><para><c>Greek_Deities_and_Titans</c></para></li><li><para><c>Legendary_creatures_from_Japan</c></para></li><li><para><c>Planets_and_Moons</c></para></li><li><para><c>Roman_Deities</c></para></li><li><para><c>Scottish_Islands</c></para></li><li><para><c>US_Cities</c></para></li><li><para><c>Wild_Cats</c></para></li></ul><para>To obtain a generated host name, call <c>GetHostNameSuggestion</c>, which returns
        /// a host name based on the current theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HostnameTheme { get; set; }
        #endregion
        
        #region Parameter ChefConfiguration_ManageBerkshelf
        /// <summary>
        /// <para>
        /// <para>Whether to enable Berkshelf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ChefConfiguration_ManageBerkshelf { get; set; }
        #endregion
        
        #region Parameter ConfigurationManager_Name
        /// <summary>
        /// <para>
        /// <para>The name. This parameter must be set to <c>Chef</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationManager_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The stack name. Stack names can be a maximum of 64 characters.</para>
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
        
        #region Parameter CustomCookbooksSource_Password
        /// <summary>
        /// <para>
        /// <para>When included in a request, the parameter depends on the repository type.</para><ul><li><para>For Amazon S3 bundles, set <c>Password</c> to the appropriate IAM secret access key.</para></li><li><para>For HTTP bundles and Subversion repositories, set <c>Password</c> to the password.</para></li></ul><para>For more information on how to safely handle IAM credentials, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html">https://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html</a>.</para><para>In responses, OpsWorks Stacks returns <c>*****FILTERED*****</c> instead of the actual
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomCookbooksSource_Password { get; set; }
        #endregion
        
        #region Parameter StackRegion
        /// <summary>
        /// <para>
        /// <para>The stack's Amazon Web Services Region, such as <c>ap-south-1</c>. For more information
        /// about Amazon Web Services Regions, see <a href="https://docs.aws.amazon.com/general/latest/gr/rande.html">Regions
        /// and Endpoints</a>.</para><note><para>In the CLI, this API maps to the <c>--stack-region</c> parameter. If the <c>--stack-region</c>
        /// parameter and the CLI common parameter <c>--region</c> are set to the same value,
        /// the stack uses a <i>regional</i> endpoint. If the <c>--stack-region</c> parameter
        /// is not set, but the CLI <c>--region</c> parameter is, this also results in a stack
        /// with a <i>regional</i> endpoint. However, if the <c>--region</c> parameter is set
        /// to <c>us-east-1</c>, and the <c>--stack-region</c> parameter is set to one of the
        /// following, then the stack uses a legacy or <i>classic</i> region: <c>us-west-1, us-west-2,
        /// sa-east-1, eu-central-1, eu-west-1, ap-northeast-1, ap-southeast-1, ap-southeast-2</c>.
        /// In this case, the actual API endpoint of the stack is in <c>us-east-1</c>. Only the
        /// preceding regions are supported as classic regions in the <c>us-east-1</c> API endpoint.
        /// Because it is a best practice to choose the regional endpoint that is closest to where
        /// you manage Amazon Web Services, we recommend that you use regional endpoints for new
        /// stacks. The CLI common <c>--region</c> parameter always specifies a regional API endpoint;
        /// it cannot be used to specify a classic OpsWorks Stacks region.</para></note>
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
        public System.String StackRegion { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Revision
        /// <summary>
        /// <para>
        /// <para>The application's version. OpsWorks Stacks enables you to easily deploy new versions
        /// of an application. One of the simplest approaches is to have branches or revisions
        /// in your repository that represent different versions that can potentially be deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomCookbooksSource_Revision { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The stack's IAM role, which allows OpsWorks Stacks to work with Amazon Web Services
        /// resources on your behalf. You must set this parameter to the Amazon Resource Name
        /// (ARN) for an existing IAM role. For more information about IAM ARNs, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">Using
        /// Identifiers</a>.</para>
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
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_SshKey
        /// <summary>
        /// <para>
        /// <para>In requests, the repository's SSH key.</para><para>In responses, OpsWorks Stacks returns <c>*****FILTERED*****</c> instead of the actual
        /// value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomCookbooksSource_SshKey { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Type
        /// <summary>
        /// <para>
        /// <para>The repository type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpsWorks.SourceType")]
        public Amazon.OpsWorks.SourceType CustomCookbooksSource_Type { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Url
        /// <summary>
        /// <para>
        /// <para>The source URL. The following is an example of an Amazon S3 source URL: <c>https://s3.amazonaws.com/opsworks-demo-bucket/opsworks_cookbook_demo.tar.gz</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomCookbooksSource_Url { get; set; }
        #endregion
        
        #region Parameter UseCustomCookbook
        /// <summary>
        /// <para>
        /// <para>Whether the stack uses custom cookbooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseCustomCookbooks")]
        public System.Boolean? UseCustomCookbook { get; set; }
        #endregion
        
        #region Parameter UseOpsworksSecurityGroup
        /// <summary>
        /// <para>
        /// <para>Whether to associate the OpsWorks Stacks built-in security groups with the stack's
        /// layers.</para><para>OpsWorks Stacks provides a standard set of built-in security groups, one for each
        /// layer, which are associated with layers by default. With <c>UseOpsworksSecurityGroups</c>
        /// you can instead provide your own custom security groups. <c>UseOpsworksSecurityGroups</c>
        /// has the following settings: </para><ul><li><para>True - OpsWorks Stacks automatically associates the appropriate built-in security
        /// group with each layer (default setting). You can associate additional security groups
        /// with a layer after you create it, but you cannot delete the built-in security group.</para></li><li><para>False - OpsWorks Stacks does not associate built-in security groups with layers. You
        /// must create appropriate EC2 security groups and associate a security group with each
        /// layer that you create. However, you can still manually associate a built-in security
        /// group with a layer on creation; custom security groups are required only for those
        /// layers that need custom settings.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-creating.html">Create
        /// a New Stack</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UseOpsworksSecurityGroups")]
        public System.Boolean? UseOpsworksSecurityGroup { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Username
        /// <summary>
        /// <para>
        /// <para>This parameter depends on the repository type.</para><ul><li><para>For Amazon S3 bundles, set <c>Username</c> to the appropriate IAM access key ID.</para></li><li><para>For HTTP bundles, Git repositories, and Subversion repositories, set <c>Username</c>
        /// to the user name.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomCookbooksSource_Username { get; set; }
        #endregion
        
        #region Parameter ConfigurationManager_Version
        /// <summary>
        /// <para>
        /// <para>The Chef version. This parameter must be set to 12, 11.10, or 11.4 for Linux stacks,
        /// and to 12.2 for Windows stacks. The default value for Linux stacks is 12.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationManager_Version { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC that the stack is to be launched into. The VPC must be in the stack's
        /// region. All instances are launched into this VPC. You cannot change the ID later.</para><ul><li><para>If your account supports EC2-Classic, the default value is <c>no VPC</c>.</para></li><li><para>If your account does not support EC2-Classic, the default value is the default VPC
        /// for the specified region.</para></li></ul><para>If the VPC ID corresponds to a default VPC and you have specified either the <c>DefaultAvailabilityZone</c>
        /// or the <c>DefaultSubnetId</c> parameter only, OpsWorks Stacks infers the value of
        /// the other parameter. If you specify neither parameter, OpsWorks Stacks sets these
        /// parameters to the first valid Availability Zone for the specified region and the corresponding
        /// default VPC subnet ID, respectively.</para><para>If you specify a nondefault VPC ID, note the following:</para><ul><li><para>It must belong to a VPC in your account that is in the specified region.</para></li><li><para>You must specify a value for <c>DefaultSubnetId</c>.</para></li></ul><para>For more information about how to use OpsWorks Stacks with a VPC, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-vpc.html">Running
        /// a Stack in a VPC</a>. For more information about default VPC and EC2-Classic, see
        /// <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-supported-platforms.html">Supported
        /// Platforms</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StackId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.CreateStackResponse).
        /// Specifying the name of a property of type Amazon.OpsWorks.Model.CreateStackResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StackId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OPSStack (CreateStack)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.CreateStackResponse, NewOPSStackCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentVersion = this.AgentVersion;
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.ChefConfiguration_BerkshelfVersion = this.ChefConfiguration_BerkshelfVersion;
            context.ChefConfiguration_ManageBerkshelf = this.ChefConfiguration_ManageBerkshelf;
            context.ConfigurationManager_Name = this.ConfigurationManager_Name;
            context.ConfigurationManager_Version = this.ConfigurationManager_Version;
            context.CustomCookbooksSource_Password = this.CustomCookbooksSource_Password;
            context.CustomCookbooksSource_Revision = this.CustomCookbooksSource_Revision;
            context.CustomCookbooksSource_SshKey = this.CustomCookbooksSource_SshKey;
            context.CustomCookbooksSource_Type = this.CustomCookbooksSource_Type;
            context.CustomCookbooksSource_Url = this.CustomCookbooksSource_Url;
            context.CustomCookbooksSource_Username = this.CustomCookbooksSource_Username;
            context.CustomJson = this.CustomJson;
            context.DefaultAvailabilityZone = this.DefaultAvailabilityZone;
            context.DefaultInstanceProfileArn = this.DefaultInstanceProfileArn;
            #if MODULAR
            if (this.DefaultInstanceProfileArn == null && ParameterWasBound(nameof(this.DefaultInstanceProfileArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DefaultInstanceProfileArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DefaultOs = this.DefaultOs;
            context.DefaultRootDeviceType = this.DefaultRootDeviceType;
            context.DefaultSshKeyName = this.DefaultSshKeyName;
            context.DefaultSubnetId = this.DefaultSubnetId;
            context.HostnameTheme = this.HostnameTheme;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StackRegion = this.StackRegion;
            #if MODULAR
            if (this.StackRegion == null && ParameterWasBound(nameof(this.StackRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter StackRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceRoleArn = this.ServiceRoleArn;
            #if MODULAR
            if (this.ServiceRoleArn == null && ParameterWasBound(nameof(this.ServiceRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UseCustomCookbook = this.UseCustomCookbook;
            context.UseOpsworksSecurityGroup = this.UseOpsworksSecurityGroup;
            context.VpcId = this.VpcId;
            
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
            var request = new Amazon.OpsWorks.Model.CreateStackRequest();
            
            if (cmdletContext.AgentVersion != null)
            {
                request.AgentVersion = cmdletContext.AgentVersion;
            }
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            
             // populate ChefConfiguration
            var requestChefConfigurationIsNull = true;
            request.ChefConfiguration = new Amazon.OpsWorks.Model.ChefConfiguration();
            System.String requestChefConfiguration_chefConfiguration_BerkshelfVersion = null;
            if (cmdletContext.ChefConfiguration_BerkshelfVersion != null)
            {
                requestChefConfiguration_chefConfiguration_BerkshelfVersion = cmdletContext.ChefConfiguration_BerkshelfVersion;
            }
            if (requestChefConfiguration_chefConfiguration_BerkshelfVersion != null)
            {
                request.ChefConfiguration.BerkshelfVersion = requestChefConfiguration_chefConfiguration_BerkshelfVersion;
                requestChefConfigurationIsNull = false;
            }
            System.Boolean? requestChefConfiguration_chefConfiguration_ManageBerkshelf = null;
            if (cmdletContext.ChefConfiguration_ManageBerkshelf != null)
            {
                requestChefConfiguration_chefConfiguration_ManageBerkshelf = cmdletContext.ChefConfiguration_ManageBerkshelf.Value;
            }
            if (requestChefConfiguration_chefConfiguration_ManageBerkshelf != null)
            {
                request.ChefConfiguration.ManageBerkshelf = requestChefConfiguration_chefConfiguration_ManageBerkshelf.Value;
                requestChefConfigurationIsNull = false;
            }
             // determine if request.ChefConfiguration should be set to null
            if (requestChefConfigurationIsNull)
            {
                request.ChefConfiguration = null;
            }
            
             // populate ConfigurationManager
            var requestConfigurationManagerIsNull = true;
            request.ConfigurationManager = new Amazon.OpsWorks.Model.StackConfigurationManager();
            System.String requestConfigurationManager_configurationManager_Name = null;
            if (cmdletContext.ConfigurationManager_Name != null)
            {
                requestConfigurationManager_configurationManager_Name = cmdletContext.ConfigurationManager_Name;
            }
            if (requestConfigurationManager_configurationManager_Name != null)
            {
                request.ConfigurationManager.Name = requestConfigurationManager_configurationManager_Name;
                requestConfigurationManagerIsNull = false;
            }
            System.String requestConfigurationManager_configurationManager_Version = null;
            if (cmdletContext.ConfigurationManager_Version != null)
            {
                requestConfigurationManager_configurationManager_Version = cmdletContext.ConfigurationManager_Version;
            }
            if (requestConfigurationManager_configurationManager_Version != null)
            {
                request.ConfigurationManager.Version = requestConfigurationManager_configurationManager_Version;
                requestConfigurationManagerIsNull = false;
            }
             // determine if request.ConfigurationManager should be set to null
            if (requestConfigurationManagerIsNull)
            {
                request.ConfigurationManager = null;
            }
            
             // populate CustomCookbooksSource
            var requestCustomCookbooksSourceIsNull = true;
            request.CustomCookbooksSource = new Amazon.OpsWorks.Model.Source();
            System.String requestCustomCookbooksSource_customCookbooksSource_Password = null;
            if (cmdletContext.CustomCookbooksSource_Password != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Password = cmdletContext.CustomCookbooksSource_Password;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Password != null)
            {
                request.CustomCookbooksSource.Password = requestCustomCookbooksSource_customCookbooksSource_Password;
                requestCustomCookbooksSourceIsNull = false;
            }
            System.String requestCustomCookbooksSource_customCookbooksSource_Revision = null;
            if (cmdletContext.CustomCookbooksSource_Revision != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Revision = cmdletContext.CustomCookbooksSource_Revision;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Revision != null)
            {
                request.CustomCookbooksSource.Revision = requestCustomCookbooksSource_customCookbooksSource_Revision;
                requestCustomCookbooksSourceIsNull = false;
            }
            System.String requestCustomCookbooksSource_customCookbooksSource_SshKey = null;
            if (cmdletContext.CustomCookbooksSource_SshKey != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_SshKey = cmdletContext.CustomCookbooksSource_SshKey;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_SshKey != null)
            {
                request.CustomCookbooksSource.SshKey = requestCustomCookbooksSource_customCookbooksSource_SshKey;
                requestCustomCookbooksSourceIsNull = false;
            }
            Amazon.OpsWorks.SourceType requestCustomCookbooksSource_customCookbooksSource_Type = null;
            if (cmdletContext.CustomCookbooksSource_Type != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Type = cmdletContext.CustomCookbooksSource_Type;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Type != null)
            {
                request.CustomCookbooksSource.Type = requestCustomCookbooksSource_customCookbooksSource_Type;
                requestCustomCookbooksSourceIsNull = false;
            }
            System.String requestCustomCookbooksSource_customCookbooksSource_Url = null;
            if (cmdletContext.CustomCookbooksSource_Url != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Url = cmdletContext.CustomCookbooksSource_Url;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Url != null)
            {
                request.CustomCookbooksSource.Url = requestCustomCookbooksSource_customCookbooksSource_Url;
                requestCustomCookbooksSourceIsNull = false;
            }
            System.String requestCustomCookbooksSource_customCookbooksSource_Username = null;
            if (cmdletContext.CustomCookbooksSource_Username != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Username = cmdletContext.CustomCookbooksSource_Username;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Username != null)
            {
                request.CustomCookbooksSource.Username = requestCustomCookbooksSource_customCookbooksSource_Username;
                requestCustomCookbooksSourceIsNull = false;
            }
             // determine if request.CustomCookbooksSource should be set to null
            if (requestCustomCookbooksSourceIsNull)
            {
                request.CustomCookbooksSource = null;
            }
            if (cmdletContext.CustomJson != null)
            {
                request.CustomJson = cmdletContext.CustomJson;
            }
            if (cmdletContext.DefaultAvailabilityZone != null)
            {
                request.DefaultAvailabilityZone = cmdletContext.DefaultAvailabilityZone;
            }
            if (cmdletContext.DefaultInstanceProfileArn != null)
            {
                request.DefaultInstanceProfileArn = cmdletContext.DefaultInstanceProfileArn;
            }
            if (cmdletContext.DefaultOs != null)
            {
                request.DefaultOs = cmdletContext.DefaultOs;
            }
            if (cmdletContext.DefaultRootDeviceType != null)
            {
                request.DefaultRootDeviceType = cmdletContext.DefaultRootDeviceType;
            }
            if (cmdletContext.DefaultSshKeyName != null)
            {
                request.DefaultSshKeyName = cmdletContext.DefaultSshKeyName;
            }
            if (cmdletContext.DefaultSubnetId != null)
            {
                request.DefaultSubnetId = cmdletContext.DefaultSubnetId;
            }
            if (cmdletContext.HostnameTheme != null)
            {
                request.HostnameTheme = cmdletContext.HostnameTheme;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.StackRegion != null)
            {
                request.Region = cmdletContext.StackRegion;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.UseCustomCookbook != null)
            {
                request.UseCustomCookbooks = cmdletContext.UseCustomCookbook.Value;
            }
            if (cmdletContext.UseOpsworksSecurityGroup != null)
            {
                request.UseOpsworksSecurityGroups = cmdletContext.UseOpsworksSecurityGroup.Value;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
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
        
        private Amazon.OpsWorks.Model.CreateStackResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.CreateStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "CreateStack");
            try
            {
                return client.CreateStackAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentVersion { get; set; }
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String ChefConfiguration_BerkshelfVersion { get; set; }
            public System.Boolean? ChefConfiguration_ManageBerkshelf { get; set; }
            public System.String ConfigurationManager_Name { get; set; }
            public System.String ConfigurationManager_Version { get; set; }
            public System.String CustomCookbooksSource_Password { get; set; }
            public System.String CustomCookbooksSource_Revision { get; set; }
            public System.String CustomCookbooksSource_SshKey { get; set; }
            public Amazon.OpsWorks.SourceType CustomCookbooksSource_Type { get; set; }
            public System.String CustomCookbooksSource_Url { get; set; }
            public System.String CustomCookbooksSource_Username { get; set; }
            public System.String CustomJson { get; set; }
            public System.String DefaultAvailabilityZone { get; set; }
            public System.String DefaultInstanceProfileArn { get; set; }
            public System.String DefaultOs { get; set; }
            public Amazon.OpsWorks.RootDeviceType DefaultRootDeviceType { get; set; }
            public System.String DefaultSshKeyName { get; set; }
            public System.String DefaultSubnetId { get; set; }
            public System.String HostnameTheme { get; set; }
            public System.String Name { get; set; }
            public System.String StackRegion { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public System.Boolean? UseCustomCookbook { get; set; }
            public System.Boolean? UseOpsworksSecurityGroup { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.OpsWorks.Model.CreateStackResponse, NewOPSStackCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StackId;
        }
        
    }
}
