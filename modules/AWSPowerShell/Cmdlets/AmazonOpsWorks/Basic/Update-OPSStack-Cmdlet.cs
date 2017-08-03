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
    /// Updates a specified stack.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "OPSStack", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateStack operation against AWS OpsWorks.", Operation = new[] {"UpdateStack"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StackId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.OpsWorks.Model.UpdateStackResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateOPSStackCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        #region Parameter AgentVersion
        /// <summary>
        /// <para>
        /// <para>The default AWS OpsWorks Stacks agent version. You have the following options:</para><ul><li><para>Auto-update - Set this parameter to <code>LATEST</code>. AWS OpsWorks Stacks automatically
        /// installs new agent versions on the stack's instances as soon as they are available.</para></li><li><para>Fixed version - Set this parameter to your preferred agent version. To update the
        /// agent version, you must edit the stack configuration and specify a new version. AWS
        /// OpsWorks Stacks then automatically installs that version on the stack's instances.</para></li></ul><para>The default setting is <code>LATEST</code>. To specify an agent version, you must
        /// use the complete version number, not the abbreviated number shown on the console.
        /// For a list of available agent version numbers, call <a>DescribeAgentVersions</a>.
        /// AgentVersion cannot be set to Chef 12.2.</para><note><para>You can also specify an agent version when you create or update an instance, which
        /// overrides the stack's default setting.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AgentVersion { get; set; }
        #endregion
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>One or more user-defined key-value pairs to be added to the stack attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter ChefConfiguration_BerkshelfVersion
        /// <summary>
        /// <para>
        /// <para>The Berkshelf version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ChefConfiguration_BerkshelfVersion { get; set; }
        #endregion
        
        #region Parameter CustomJson
        /// <summary>
        /// <para>
        /// <para>A string that contains user-defined, custom JSON. It can be used to override the corresponding
        /// default stack configuration JSON values or to pass data to recipes. The string should
        /// be in the following format:</para><para><code>"{\"key1\": \"value1\", \"key2\": \"value2\",...}"</code></para><para>For more information on custom JSON, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-json.html">Use
        /// Custom JSON to Modify the Stack Configuration Attributes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomJson { get; set; }
        #endregion
        
        #region Parameter DefaultAvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The stack's default Availability Zone, which must be in the stack's region. For more
        /// information, see <a href="http://docs.aws.amazon.com/general/latest/gr/rande.html">Regions
        /// and Endpoints</a>. If you also specify a value for <code>DefaultSubnetId</code>, the
        /// subnet must be in the same zone. For more information, see <a>CreateStack</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultAvailabilityZone { get; set; }
        #endregion
        
        #region Parameter DefaultInstanceProfileArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM profile that is the default profile for all of the stack's EC2 instances.
        /// For more information about IAM ARNs, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/Using_Identifiers.html">Using
        /// Identifiers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultInstanceProfileArn { get; set; }
        #endregion
        
        #region Parameter DefaultOs
        /// <summary>
        /// <para>
        /// <para>The stack's operating system, which must be set to one of the following:</para><ul><li><para>A supported Linux operating system: An Amazon Linux version, such as <code>Amazon
        /// Linux 2017.03</code>, <code>Amazon Linux 2016.09</code>, <code>Amazon Linux 2016.03</code>,
        /// <code>Amazon Linux 2015.09</code>, or <code>Amazon Linux 2015.03</code>.</para></li><li><para>A supported Ubuntu operating system, such as <code>Ubuntu 16.04 LTS</code>, <code>Ubuntu
        /// 14.04 LTS</code>, or <code>Ubuntu 12.04 LTS</code>.</para></li><li><para><code>CentOS Linux 7</code></para></li><li><para><code>Red Hat Enterprise Linux 7</code></para></li><li><para>A supported Windows operating system, such as <code>Microsoft Windows Server 2012
        /// R2 Base</code>, <code>Microsoft Windows Server 2012 R2 with SQL Server Express</code>,
        /// <code>Microsoft Windows Server 2012 R2 with SQL Server Standard</code>, or <code>Microsoft
        /// Windows Server 2012 R2 with SQL Server Web</code>.</para></li><li><para>A custom AMI: <code>Custom</code>. You specify the custom AMI you want to use when
        /// you create instances. For more information on how to use custom AMIs with OpsWorks,
        /// see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-custom-ami.html">Using
        /// Custom AMIs</a>.</para></li></ul><para>The default option is the stack's current operating system. For more information on
        /// the supported operating systems, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-os.html">AWS
        /// OpsWorks Stacks Operating Systems</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultOs { get; set; }
        #endregion
        
        #region Parameter DefaultRootDeviceType
        /// <summary>
        /// <para>
        /// <para>The default root device type. This value is used by default for all instances in the
        /// stack, but you can override it when you create an instance. For more information,
        /// see <a href="http://docs.aws.amazon.com/AWSEC2/latest/UserGuide/ComponentsAMIs.html#storage-for-the-root-device">Storage
        /// for the Root Device</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.OpsWorks.RootDeviceType")]
        public Amazon.OpsWorks.RootDeviceType DefaultRootDeviceType { get; set; }
        #endregion
        
        #region Parameter DefaultSshKeyName
        /// <summary>
        /// <para>
        /// <para>A default Amazon EC2 key-pair name. The default value is <code>none</code>. If you
        /// specify a key-pair name, AWS OpsWorks Stacks installs the public key on the instance
        /// and you can use the private key with an SSH client to log in to the instance. For
        /// more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-ssh.html">
        /// Using SSH to Communicate with an Instance</a> and <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/security-ssh-access.html">
        /// Managing SSH Access</a>. You can override this setting by specifying a different key
        /// pair, or no key pair, when you <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workinginstances-add.html">
        /// create an instance</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DefaultSshKeyName { get; set; }
        #endregion
        
        #region Parameter DefaultSubnetId
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
        public System.String DefaultSubnetId { get; set; }
        #endregion
        
        #region Parameter HostnameTheme
        /// <summary>
        /// <para>
        /// <para>The stack's new host name theme, with spaces replaced by underscores. The theme is
        /// used to generate host names for the stack's instances. By default, <code>HostnameTheme</code>
        /// is set to <code>Layer_Dependent</code>, which creates host names by appending integers
        /// to the layer's short name. The other themes are:</para><ul><li><para><code>Baked_Goods</code></para></li><li><para><code>Clouds</code></para></li><li><para><code>Europe_Cities</code></para></li><li><para><code>Fruits</code></para></li><li><para><code>Greek_Deities</code></para></li><li><para><code>Legendary_creatures_from_Japan</code></para></li><li><para><code>Planets_and_Moons</code></para></li><li><para><code>Roman_Deities</code></para></li><li><para><code>Scottish_Islands</code></para></li><li><para><code>US_Cities</code></para></li><li><para><code>Wild_Cats</code></para></li></ul><para>To obtain a generated host name, call <code>GetHostNameSuggestion</code>, which returns
        /// a host name based on the current theme.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HostnameTheme { get; set; }
        #endregion
        
        #region Parameter ChefConfiguration_ManageBerkshelf
        /// <summary>
        /// <para>
        /// <para>Whether to enable Berkshelf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ChefConfiguration_ManageBerkshelf { get; set; }
        #endregion
        
        #region Parameter ConfigurationManager_Name
        /// <summary>
        /// <para>
        /// <para>The name. This parameter must be set to "Chef".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationManager_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The stack's new name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Password
        /// <summary>
        /// <para>
        /// <para>When included in a request, the parameter depends on the repository type.</para><ul><li><para>For Amazon S3 bundles, set <code>Password</code> to the appropriate IAM secret access
        /// key.</para></li><li><para>For HTTP bundles and Subversion repositories, set <code>Password</code> to the password.</para></li></ul><para>For more information on how to safely handle IAM credentials, see <a href="http://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html">http://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html</a>.</para><para>In responses, AWS OpsWorks Stacks returns <code>*****FILTERED*****</code> instead
        /// of the actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomCookbooksSource_Password { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Revision
        /// <summary>
        /// <para>
        /// <para>The application's version. AWS OpsWorks Stacks enables you to easily deploy new versions
        /// of an application. One of the simplest approaches is to have branches or revisions
        /// in your repository that represent different versions that can potentially be deployed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomCookbooksSource_Revision { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>Do not use this parameter. You cannot update a stack's service role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_SshKey
        /// <summary>
        /// <para>
        /// <para>In requests, the repository's SSH key.</para><para>In responses, AWS OpsWorks Stacks returns <code>*****FILTERED*****</code> instead
        /// of the actual value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomCookbooksSource_SshKey { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StackId { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Type
        /// <summary>
        /// <para>
        /// <para>The repository type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.OpsWorks.SourceType")]
        public Amazon.OpsWorks.SourceType CustomCookbooksSource_Type { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Url
        /// <summary>
        /// <para>
        /// <para>The source URL. The following is an example of an Amazon S3 source URL: <code>https://s3.amazonaws.com/opsworks-demo-bucket/opsworks_cookbook_demo.tar.gz</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomCookbooksSource_Url { get; set; }
        #endregion
        
        #region Parameter UseCustomCookbook
        /// <summary>
        /// <para>
        /// <para>Whether the stack uses custom cookbooks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UseCustomCookbooks")]
        public System.Boolean UseCustomCookbook { get; set; }
        #endregion
        
        #region Parameter UseOpsworksSecurityGroup
        /// <summary>
        /// <para>
        /// <para>Whether to associate the AWS OpsWorks Stacks built-in security groups with the stack's
        /// layers.</para><para>AWS OpsWorks Stacks provides a standard set of built-in security groups, one for each
        /// layer, which are associated with layers by default. <code>UseOpsworksSecurityGroups</code>
        /// allows you to provide your own custom security groups instead of using the built-in
        /// groups. <code>UseOpsworksSecurityGroups</code> has the following settings: </para><ul><li><para>True - AWS OpsWorks Stacks automatically associates the appropriate built-in security
        /// group with each layer (default setting). You can associate additional security groups
        /// with a layer after you create it, but you cannot delete the built-in security group.</para></li><li><para>False - AWS OpsWorks Stacks does not associate built-in security groups with layers.
        /// You must create appropriate EC2 security groups and associate a security group with
        /// each layer that you create. However, you can still manually associate a built-in security
        /// group with a layer on. Custom security groups are required only for those layers that
        /// need custom settings.</para></li></ul><para>For more information, see <a href="http://docs.aws.amazon.com/opsworks/latest/userguide/workingstacks-creating.html">Create
        /// a New Stack</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UseOpsworksSecurityGroups")]
        public System.Boolean UseOpsworksSecurityGroup { get; set; }
        #endregion
        
        #region Parameter CustomCookbooksSource_Username
        /// <summary>
        /// <para>
        /// <para>This parameter depends on the repository type.</para><ul><li><para>For Amazon S3 bundles, set <code>Username</code> to the appropriate IAM access key
        /// ID.</para></li><li><para>For HTTP bundles, Git repositories, and Subversion repositories, set <code>Username</code>
        /// to the user name.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CustomCookbooksSource_Username { get; set; }
        #endregion
        
        #region Parameter ConfigurationManager_Version
        /// <summary>
        /// <para>
        /// <para>The Chef version. This parameter must be set to 12, 11.10, or 11.4 for Linux stacks,
        /// and to 12.2 for Windows stacks. The default value for Linux stacks is 11.4.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ConfigurationManager_Version { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the StackId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StackId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OPSStack (UpdateStack)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AgentVersion = this.AgentVersion;
            if (this.Attribute != null)
            {
                context.Attributes = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attributes.Add((String)hashKey, (String)(this.Attribute[hashKey]));
                }
            }
            context.ChefConfiguration_BerkshelfVersion = this.ChefConfiguration_BerkshelfVersion;
            if (ParameterWasBound("ChefConfiguration_ManageBerkshelf"))
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
            context.DefaultOs = this.DefaultOs;
            context.DefaultRootDeviceType = this.DefaultRootDeviceType;
            context.DefaultSshKeyName = this.DefaultSshKeyName;
            context.DefaultSubnetId = this.DefaultSubnetId;
            context.HostnameTheme = this.HostnameTheme;
            context.Name = this.Name;
            context.ServiceRoleArn = this.ServiceRoleArn;
            context.StackId = this.StackId;
            if (ParameterWasBound("UseCustomCookbook"))
                context.UseCustomCookbooks = this.UseCustomCookbook;
            if (ParameterWasBound("UseOpsworksSecurityGroup"))
                context.UseOpsworksSecurityGroups = this.UseOpsworksSecurityGroup;
            
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
            var request = new Amazon.OpsWorks.Model.UpdateStackRequest();
            
            if (cmdletContext.AgentVersion != null)
            {
                request.AgentVersion = cmdletContext.AgentVersion;
            }
            if (cmdletContext.Attributes != null)
            {
                request.Attributes = cmdletContext.Attributes;
            }
            
             // populate ChefConfiguration
            bool requestChefConfigurationIsNull = true;
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
            bool requestConfigurationManagerIsNull = true;
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
            bool requestCustomCookbooksSourceIsNull = true;
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
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
            }
            if (cmdletContext.UseCustomCookbooks != null)
            {
                request.UseCustomCookbooks = cmdletContext.UseCustomCookbooks.Value;
            }
            if (cmdletContext.UseOpsworksSecurityGroups != null)
            {
                request.UseOpsworksSecurityGroups = cmdletContext.UseOpsworksSecurityGroups.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.StackId;
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
        
        #region AWS Service Operation Call
        
        private Amazon.OpsWorks.Model.UpdateStackResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.UpdateStackRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "UpdateStack");
            #if DESKTOP
            return client.UpdateStack(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.UpdateStackAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String AgentVersion { get; set; }
            public Dictionary<System.String, System.String> Attributes { get; set; }
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
            public System.String ServiceRoleArn { get; set; }
            public System.String StackId { get; set; }
            public System.Boolean? UseCustomCookbooks { get; set; }
            public System.Boolean? UseOpsworksSecurityGroups { get; set; }
        }
        
    }
}
