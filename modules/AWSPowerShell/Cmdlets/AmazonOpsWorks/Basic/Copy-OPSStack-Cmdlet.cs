/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Creates a clone of a specified stack. For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-cloning.html">Clone
    /// a Stack</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have an attached
    /// policy that explicitly grants permissions. For more information on user permissions,
    /// see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "OPSStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the CloneStack operation against AWS OpsWorks.", Operation = new[] {"CloneStack"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type CloneStackResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class CopyOPSStackCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A list of stack attributes and values as key/value pairs to be added to the cloned
        /// stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Berkshelf version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ChefConfiguration_BerkshelfVersion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of source stack app IDs to be included in the cloned stack.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CloneAppIds")]
        public System.String[] CloneAppId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to clone the source stack's permissions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ClonePermissions { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A string that contains user-defined, custom JSON. It is used to override the corresponding
        /// default stack configuration JSON values. The string should be in the following format
        /// and must escape characters such as '"'.:</para><para><code>"{\"key1\": \"value1\", \"key2\": \"value2\",...}"</code></para><para>For more information on custom JSON, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-json.html">Use
        /// Custom JSON to Modify the Stack Configuration Attributes</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CustomJson { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The cloned stack's default Availability Zone, which must be in the specified region.
        /// For more information, see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html">Regions
        /// and Endpoints</a>. If you also specify a value for <code>DefaultSubnetId</code>, the
        /// subnet must be in the same zone. For more information, see the <code>VpcId</code>
        /// parameter description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DefaultAvailabilityZone { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM profile that is the default profile for all of the stack's EC2 instances.
        /// For more information about IAM ARNs, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">Using
        /// Identifiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DefaultInstanceProfileArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack's operating system, which must be set to one of the following.</para><ul><li>Standard Linux operating systems: an Amazon Linux version such as <code>Amazon
        /// Linux 2014.09</code>, <code>Ubuntu 12.04 LTS</code>, or <code>Ubuntu 14.04 LTS</code>.</li><li>Custom Linux AMIs: <code>Custom</code>. You specify the custom AMI you want to
        /// use when you create instances.</li><li>Microsoft Windows Server 2012 R2.</li></ul><para> The default option is the current Amazon Linux version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DefaultOs { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The default root device type. This value is used by default for all instances in the
        /// cloned stack, but you can override it when you create an instance. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ComponentsAMIs.html#storage-for-the-root-device">Storage
        /// for the Root Device</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public RootDeviceType DefaultRootDeviceType { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A default Amazon EC2 key pair name. The default value is none. If you specify a key
        /// pair name, AWS OpsWorks installs the public key on the instance and you can use the
        /// private key with an SSH client to log in to the instance. For more information, see
        /// <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-ssh.html">
        /// Using SSH to Communicate with an Instance</a> and <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/security-ssh-access.html">
        /// Managing SSH Access</a>. You can override this setting by specifying a different key
        /// pair, or no key pair, when you <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-add.html">
        /// create an instance</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DefaultSshKeyName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack's default VPC subnet ID. This parameter is required if you specify a value
        /// for the <code>VpcId</code> parameter. All instances are launched into this subnet
        /// unless you specify otherwise when you create the instance. If you also specify a value
        /// for <code>DefaultAvailabilityZone</code>, the subnet must be in that zone. For information
        /// on default values and when this parameter is required, see the <code>VpcId</code>
        /// parameter description. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DefaultSubnetId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack's host name theme, with spaces are replaced by underscores. The theme is
        /// used to generate host names for the stack's instances. By default, <code>HostnameTheme</code>
        /// is set to <code>Layer_Dependent</code>, which creates host names by appending integers
        /// to the layer's short name. The other themes are:</para><ul><li><code>Baked_Goods</code></li><li><code>Clouds</code></li><li><code>Europe_Cities</code></li><li><code>Fruits</code></li><li><code>Greek_Deities</code></li><li><code>Legendary_creatures_from_Japan</code></li><li><code>Planets_and_Moons</code></li><li><code>Roman_Deities</code></li><li><code>Scottish_Islands</code></li><li><code>US_Cities</code></li><li><code>Wild_Cats</code></li></ul><para>To obtain a generated host name, call <code>GetHostNameSuggestion</code>, which returns
        /// a host name based on the current theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String HostnameTheme { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to enable Berkshelf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean ChefConfiguration_ManageBerkshelf { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name. This parameter must be set to "Chef".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ConfigurationManager_Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The cloned stack name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>When included in a request, the parameter depends on the repository type. </para><ul><li>For Amazon S3 bundles, set <code>Password</code> to the appropriate IAM
        /// secret access key.</li><li>For HTTP bundles and Subversion repositories, set <code>Password</code>
        /// to the password.</li></ul><para>For more information on how to safely handle IAM credentials, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html"></a>.</para><para>In responses, AWS OpsWorks returns <code>*****FILTERED*****</code> instead of the
        /// actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CustomCookbooksSource_Password { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The cloned stack AWS region, such as "us-east-1". For more information about AWS regions,
        /// see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html">Regions and
        /// Endpoints</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String StackRegion { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The application's version. AWS OpsWorks enables you to easily deploy new versions
        /// of an application. One of the simplest approaches is to have branches or revisions
        /// in your repository that represent different versions that can potentially be deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CustomCookbooksSource_Revision { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The stack AWS Identity and Access Management (IAM) role, which allows AWS OpsWorks
        /// to work with AWS resources on your behalf. You must set this parameter to the Amazon
        /// Resource Name (ARN) for an existing IAM role. If you create a stack by using the AWS
        /// OpsWorks console, it creates the role for you. You can obtain an existing stack's
        /// IAM ARN programmatically by calling <a>DescribePermissions</a>. For more information
        /// about IAM ARNs, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">Using
        /// Identifiers</a>.</para><note><para>You must set this parameter to a valid service role ARN or the action will fail; there
        /// is no default value. You can specify the source stack's service role ARN, if you prefer,
        /// but you must do so explicitly.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ServiceRoleArn { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The source stack ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String SourceStackId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>In requests, the repository's SSH key.</para><para>In responses, AWS OpsWorks returns <code>*****FILTERED*****</code> instead of the
        /// actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CustomCookbooksSource_SshKey { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The repository type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public SourceType CustomCookbooksSource_Type { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The source URL. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CustomCookbooksSource_Url { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to use custom cookbooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean UseCustomCookbooks { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>Whether to associate the AWS OpsWorks built-in security groups with the stack's layers.</para><para>AWS OpsWorks provides a standard set of built-in security groups, one for each layer,
        /// which are associated with layers by default. With <code>UseOpsworksSecurityGroups</code>
        /// you can instead provide your own custom security groups. <code>UseOpsworksSecurityGroups</code>
        /// has the following settings: </para><ul><li>True - AWS OpsWorks automatically associates the appropriate built-in security
        /// group with each layer (default setting). You can associate additional security groups
        /// with a layer after you create it but you cannot delete the built-in security group.
        /// </li><li>False - AWS OpsWorks does not associate built-in security groups with layers.
        /// You must create appropriate EC2 security groups and associate a security group with
        /// each layer that you create. However, you can still manually associate a built-in security
        /// group with a layer on creation; custom security groups are required only for those
        /// layers that need custom settings. </li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-creating.html">Create
        /// a New Stack</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Boolean UseOpsworksSecurityGroups { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>This parameter depends on the repository type. </para><ul><li>For Amazon S3 bundles, set <code>Username</code> to the appropriate IAM
        /// access key ID.</li><li>For HTTP bundles, Git repositories, and Subversion repositories,
        /// set <code>Username</code> to the user name.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String CustomCookbooksSource_Username { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The Chef version. This parameter must be set to 0.9, 11.4, or 11.10. The default value
        /// is 11.4.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String ConfigurationManager_Version { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the VPC that the cloned stack is to be launched into. It must be in the
        /// specified region. All instances are launched into this VPC, and you cannot change
        /// the ID later.</para><ul><li>If your account supports EC2 Classic, the default value is no VPC.</li><li>If your account does not support EC2 Classic, the default value is the default
        /// VPC for the specified region.</li></ul><para>If the VPC ID corresponds to a default VPC and you have specified either the <code>DefaultAvailabilityZone</code>
        /// or the <code>DefaultSubnetId</code> parameter only, AWS OpsWorks infers the value
        /// of the other parameter. If you specify neither parameter, AWS OpsWorks sets these
        /// parameters to the first valid Availability Zone for the specified region and the corresponding
        /// default VPC subnet ID, respectively. </para><para>If you specify a nondefault VPC ID, note the following:</para><ul><li>It must belong to a VPC in your account that is in the specified region.</li><li>You must specify a value for <code>DefaultSubnetId</code>.</li></ul><para>For more information on how to use AWS OpsWorks with a VPC, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-vpc.html">Running
        /// a Stack in a VPC</a>. For more information on default VPC and EC2 Classic, see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ec2-supported-platforms.html">Supported
        /// Platforms</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String VpcId { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceStackId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-OPSStack (CloneStack)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<String, String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.ChefConfiguration_BerkshelfVersion = this.ChefConfiguration_BerkshelfVersion;
            if (ParameterWasBound("ChefConfiguration_ManageBerkshelf"))
                context.ChefConfiguration_ManageBerkshelf = this.ChefConfiguration_ManageBerkshelf;
            if (this.CloneAppId != null)
            {
                context.CloneAppIds = new List<String>(this.CloneAppId);
            }
            if (ParameterWasBound("ClonePermissions"))
                context.ClonePermissions = this.ClonePermissions;
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
            context.DefaultOs = this.DefaultOs;
            context.DefaultRootDeviceType = this.DefaultRootDeviceType;
            context.DefaultSshKeyName = this.DefaultSshKeyName;
            context.DefaultSubnetId = this.DefaultSubnetId;
            context.HostnameTheme = this.HostnameTheme;
            context.Name = this.Name;
            context.StackRegion = this.StackRegion;
            context.ServiceRoleArn = this.ServiceRoleArn;
            context.SourceStackId = this.SourceStackId;
            if (ParameterWasBound("UseCustomCookbooks"))
                context.UseCustomCookbooks = this.UseCustomCookbooks;
            if (ParameterWasBound("UseOpsworksSecurityGroups"))
                context.UseOpsworksSecurityGroups = this.UseOpsworksSecurityGroups;
            context.VpcId = this.VpcId;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CloneStackRequest();
            
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            
             // populate ChefConfiguration
            bool requestChefConfigurationIsNull = true;
            request.ChefConfiguration = new ChefConfiguration();
            String requestChefConfiguration_chefConfiguration_BerkshelfVersion = null;
            if (cmdletContext.ChefConfiguration_BerkshelfVersion != null)
            {
                requestChefConfiguration_chefConfiguration_BerkshelfVersion = cmdletContext.ChefConfiguration_BerkshelfVersion;
            }
            if (requestChefConfiguration_chefConfiguration_BerkshelfVersion != null)
            {
                request.ChefConfiguration.BerkshelfVersion = requestChefConfiguration_chefConfiguration_BerkshelfVersion;
                requestChefConfigurationIsNull = false;
            }
            Boolean? requestChefConfiguration_chefConfiguration_ManageBerkshelf = null;
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
            if (cmdletContext.CloneAppIds != null)
            {
                request.CloneAppIds = cmdletContext.CloneAppIds;
            }
            if (cmdletContext.ClonePermissions != null)
            {
                request.ClonePermissions = cmdletContext.ClonePermissions.Value;
            }
            
             // populate ConfigurationManager
            bool requestConfigurationManagerIsNull = true;
            request.ConfigurationManager = new StackConfigurationManager();
            String requestConfigurationManager_configurationManager_Name = null;
            if (cmdletContext.ConfigurationManager_Name != null)
            {
                requestConfigurationManager_configurationManager_Name = cmdletContext.ConfigurationManager_Name;
            }
            if (requestConfigurationManager_configurationManager_Name != null)
            {
                request.ConfigurationManager.Name = requestConfigurationManager_configurationManager_Name;
                requestConfigurationManagerIsNull = false;
            }
            String requestConfigurationManager_configurationManager_Version = null;
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
            bool requestCustomCookbooksSourceIsNull = true;
            request.CustomCookbooksSource = new Source();
            String requestCustomCookbooksSource_customCookbooksSource_Password = null;
            if (cmdletContext.CustomCookbooksSource_Password != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Password = cmdletContext.CustomCookbooksSource_Password;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Password != null)
            {
                request.CustomCookbooksSource.Password = requestCustomCookbooksSource_customCookbooksSource_Password;
                requestCustomCookbooksSourceIsNull = false;
            }
            String requestCustomCookbooksSource_customCookbooksSource_Revision = null;
            if (cmdletContext.CustomCookbooksSource_Revision != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Revision = cmdletContext.CustomCookbooksSource_Revision;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Revision != null)
            {
                request.CustomCookbooksSource.Revision = requestCustomCookbooksSource_customCookbooksSource_Revision;
                requestCustomCookbooksSourceIsNull = false;
            }
            String requestCustomCookbooksSource_customCookbooksSource_SshKey = null;
            if (cmdletContext.CustomCookbooksSource_SshKey != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_SshKey = cmdletContext.CustomCookbooksSource_SshKey;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_SshKey != null)
            {
                request.CustomCookbooksSource.SshKey = requestCustomCookbooksSource_customCookbooksSource_SshKey;
                requestCustomCookbooksSourceIsNull = false;
            }
            SourceType requestCustomCookbooksSource_customCookbooksSource_Type = null;
            if (cmdletContext.CustomCookbooksSource_Type != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Type = cmdletContext.CustomCookbooksSource_Type;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Type != null)
            {
                request.CustomCookbooksSource.Type = requestCustomCookbooksSource_customCookbooksSource_Type;
                requestCustomCookbooksSourceIsNull = false;
            }
            String requestCustomCookbooksSource_customCookbooksSource_Url = null;
            if (cmdletContext.CustomCookbooksSource_Url != null)
            {
                requestCustomCookbooksSource_customCookbooksSource_Url = cmdletContext.CustomCookbooksSource_Url;
            }
            if (requestCustomCookbooksSource_customCookbooksSource_Url != null)
            {
                request.CustomCookbooksSource.Url = requestCustomCookbooksSource_customCookbooksSource_Url;
                requestCustomCookbooksSourceIsNull = false;
            }
            String requestCustomCookbooksSource_customCookbooksSource_Username = null;
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
            if (cmdletContext.SourceStackId != null)
            {
                request.SourceStackId = cmdletContext.SourceStackId;
            }
            if (cmdletContext.UseCustomCookbooks != null)
            {
                request.UseCustomCookbooks = cmdletContext.UseCustomCookbooks.Value;
            }
            if (cmdletContext.UseOpsworksSecurityGroups != null)
            {
                request.UseOpsworksSecurityGroups = cmdletContext.UseOpsworksSecurityGroups.Value;
            }
            if (cmdletContext.VpcId != null)
            {
                request.VpcId = cmdletContext.VpcId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CloneStack(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.StackId;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public Dictionary<String, String> Attributes { get; set; }
            public String ChefConfiguration_BerkshelfVersion { get; set; }
            public Boolean? ChefConfiguration_ManageBerkshelf { get; set; }
            public List<String> CloneAppIds { get; set; }
            public Boolean? ClonePermissions { get; set; }
            public String ConfigurationManager_Name { get; set; }
            public String ConfigurationManager_Version { get; set; }
            public String CustomCookbooksSource_Password { get; set; }
            public String CustomCookbooksSource_Revision { get; set; }
            public String CustomCookbooksSource_SshKey { get; set; }
            public SourceType CustomCookbooksSource_Type { get; set; }
            public String CustomCookbooksSource_Url { get; set; }
            public String CustomCookbooksSource_Username { get; set; }
            public String CustomJson { get; set; }
            public String DefaultAvailabilityZone { get; set; }
            public String DefaultInstanceProfileArn { get; set; }
            public String DefaultOs { get; set; }
            public RootDeviceType DefaultRootDeviceType { get; set; }
            public String DefaultSshKeyName { get; set; }
            public String DefaultSubnetId { get; set; }
            public String HostnameTheme { get; set; }
            public String Name { get; set; }
            public String StackRegion { get; set; }
            public String ServiceRoleArn { get; set; }
            public String SourceStackId { get; set; }
            public Boolean? UseCustomCookbooks { get; set; }
            public Boolean? UseOpsworksSecurityGroups { get; set; }
            public String VpcId { get; set; }
        }
        
    }
}
