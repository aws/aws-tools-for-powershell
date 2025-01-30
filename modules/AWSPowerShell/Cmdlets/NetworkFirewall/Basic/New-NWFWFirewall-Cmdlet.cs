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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Creates an Network Firewall <a>Firewall</a> and accompanying <a>FirewallStatus</a>
    /// for a VPC. 
    /// 
    ///  
    /// <para>
    /// The firewall defines the configuration settings for an Network Firewall firewall.
    /// The settings that you can define at creation include the firewall policy, the subnets
    /// in your VPC to use for the firewall endpoints, and any tags that are attached to the
    /// firewall Amazon Web Services resource. 
    /// </para><para>
    /// After you create a firewall, you can provide additional settings, like the logging
    /// configuration. 
    /// </para><para>
    /// To update the settings for a firewall, you use the operations that apply to the settings
    /// themselves, for example <a>UpdateLoggingConfiguration</a>, <a>AssociateSubnets</a>,
    /// and <a>UpdateFirewallDeleteProtection</a>. 
    /// </para><para>
    /// To manage a firewall's tags, use the standard Amazon Web Services resource tagging
    /// operations, <a>ListTagsForResource</a>, <a>TagResource</a>, and <a>UntagResource</a>.
    /// </para><para>
    /// To retrieve information about firewalls, use <a>ListFirewalls</a> and <a>DescribeFirewall</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NWFWFirewall", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.CreateFirewallResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall CreateFirewall API operation.", Operation = new[] {"CreateFirewall"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.CreateFirewallResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.CreateFirewallResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.CreateFirewallResponse object containing multiple properties."
    )]
    public partial class NewNWFWFirewallCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeleteProtection
        /// <summary>
        /// <para>
        /// <para>A flag indicating whether it is possible to delete the firewall. A setting of <c>TRUE</c>
        /// indicates that the firewall is protected against deletion. Use this setting to protect
        /// against accidentally deleting a firewall that is in use. When you create a firewall,
        /// the operation initializes this flag to <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeleteProtection { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the firewall.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FirewallName
        /// <summary>
        /// <para>
        /// <para>The descriptive name of the firewall. You can't change the name of a firewall after
        /// you create it.</para>
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
        public System.String FirewallName { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the <a>FirewallPolicy</a> that you want to use for
        /// the firewall.</para>
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
        public System.String FirewallPolicyArn { get; set; }
        #endregion
        
        #region Parameter FirewallPolicyChangeProtection
        /// <summary>
        /// <para>
        /// <para>A setting indicating whether the firewall is protected against a change to the firewall
        /// policy association. Use this setting to protect against accidentally modifying the
        /// firewall policy for a firewall that is in use. When you create a firewall, the operation
        /// initializes this setting to <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? FirewallPolicyChangeProtection { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KeyId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services Key Management Service (KMS) customer managed key.
        /// You can use any of the key identifiers that KMS supports, unless you're using a key
        /// that's managed by another account. If you're using a key managed by another account,
        /// then specify the key ARN. For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id">Key
        /// ID</a> in the <i>Amazon Web Services KMS Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KeyId { get; set; }
        #endregion
        
        #region Parameter SubnetChangeProtection
        /// <summary>
        /// <para>
        /// <para>A setting indicating whether the firewall is protected against changes to the subnet
        /// associations. Use this setting to protect against accidentally modifying the subnet
        /// associations for a firewall that is in use. When you create a firewall, the operation
        /// initializes this setting to <c>TRUE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SubnetChangeProtection { get; set; }
        #endregion
        
        #region Parameter SubnetMapping
        /// <summary>
        /// <para>
        /// <para>The public subnets to use for your Network Firewall firewalls. Each subnet must belong
        /// to a different Availability Zone in the VPC. Network Firewall creates a firewall endpoint
        /// in each subnet. </para>
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
        [Alias("SubnetMappings")]
        public Amazon.NetworkFirewall.Model.SubnetMapping[] SubnetMapping { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key:value pairs to associate with the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.NetworkFirewall.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_Type
        /// <summary>
        /// <para>
        /// <para>The type of Amazon Web Services KMS key to use for encryption of your Network Firewall
        /// resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NetworkFirewall.EncryptionType")]
        public Amazon.NetworkFirewall.EncryptionType EncryptionConfiguration_Type { get; set; }
        #endregion
        
        #region Parameter VpcId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the VPC where Network Firewall should create the firewall.
        /// </para><para>You can't change this setting after you create the firewall. </para>
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
        public System.String VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.CreateFirewallResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.CreateFirewallResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FirewallPolicyArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FirewallPolicyArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FirewallPolicyArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NWFWFirewall (CreateFirewall)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.CreateFirewallResponse, NewNWFWFirewallCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FirewallPolicyArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeleteProtection = this.DeleteProtection;
            context.Description = this.Description;
            context.EncryptionConfiguration_KeyId = this.EncryptionConfiguration_KeyId;
            context.EncryptionConfiguration_Type = this.EncryptionConfiguration_Type;
            context.FirewallName = this.FirewallName;
            #if MODULAR
            if (this.FirewallName == null && ParameterWasBound(nameof(this.FirewallName)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallPolicyArn = this.FirewallPolicyArn;
            #if MODULAR
            if (this.FirewallPolicyArn == null && ParameterWasBound(nameof(this.FirewallPolicyArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallPolicyArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FirewallPolicyChangeProtection = this.FirewallPolicyChangeProtection;
            context.SubnetChangeProtection = this.SubnetChangeProtection;
            if (this.SubnetMapping != null)
            {
                context.SubnetMapping = new List<Amazon.NetworkFirewall.Model.SubnetMapping>(this.SubnetMapping);
            }
            #if MODULAR
            if (this.SubnetMapping == null && ParameterWasBound(nameof(this.SubnetMapping)))
            {
                WriteWarning("You are passing $null as a value for parameter SubnetMapping which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.NetworkFirewall.Model.Tag>(this.Tag);
            }
            context.VpcId = this.VpcId;
            #if MODULAR
            if (this.VpcId == null && ParameterWasBound(nameof(this.VpcId)))
            {
                WriteWarning("You are passing $null as a value for parameter VpcId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFirewall.Model.CreateFirewallRequest();
            
            if (cmdletContext.DeleteProtection != null)
            {
                request.DeleteProtection = cmdletContext.DeleteProtection.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.NetworkFirewall.Model.EncryptionConfiguration();
            System.String requestEncryptionConfiguration_encryptionConfiguration_KeyId = null;
            if (cmdletContext.EncryptionConfiguration_KeyId != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KeyId = cmdletContext.EncryptionConfiguration_KeyId;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KeyId != null)
            {
                request.EncryptionConfiguration.KeyId = requestEncryptionConfiguration_encryptionConfiguration_KeyId;
                requestEncryptionConfigurationIsNull = false;
            }
            Amazon.NetworkFirewall.EncryptionType requestEncryptionConfiguration_encryptionConfiguration_Type = null;
            if (cmdletContext.EncryptionConfiguration_Type != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_Type = cmdletContext.EncryptionConfiguration_Type;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_Type != null)
            {
                request.EncryptionConfiguration.Type = requestEncryptionConfiguration_encryptionConfiguration_Type;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.FirewallName != null)
            {
                request.FirewallName = cmdletContext.FirewallName;
            }
            if (cmdletContext.FirewallPolicyArn != null)
            {
                request.FirewallPolicyArn = cmdletContext.FirewallPolicyArn;
            }
            if (cmdletContext.FirewallPolicyChangeProtection != null)
            {
                request.FirewallPolicyChangeProtection = cmdletContext.FirewallPolicyChangeProtection.Value;
            }
            if (cmdletContext.SubnetChangeProtection != null)
            {
                request.SubnetChangeProtection = cmdletContext.SubnetChangeProtection.Value;
            }
            if (cmdletContext.SubnetMapping != null)
            {
                request.SubnetMappings = cmdletContext.SubnetMapping;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.NetworkFirewall.Model.CreateFirewallResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.CreateFirewallRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "CreateFirewall");
            try
            {
                #if DESKTOP
                return client.CreateFirewall(request);
                #elif CORECLR
                return client.CreateFirewallAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? DeleteProtection { get; set; }
            public System.String Description { get; set; }
            public System.String EncryptionConfiguration_KeyId { get; set; }
            public Amazon.NetworkFirewall.EncryptionType EncryptionConfiguration_Type { get; set; }
            public System.String FirewallName { get; set; }
            public System.String FirewallPolicyArn { get; set; }
            public System.Boolean? FirewallPolicyChangeProtection { get; set; }
            public System.Boolean? SubnetChangeProtection { get; set; }
            public List<Amazon.NetworkFirewall.Model.SubnetMapping> SubnetMapping { get; set; }
            public List<Amazon.NetworkFirewall.Model.Tag> Tag { get; set; }
            public System.String VpcId { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.CreateFirewallResponse, NewNWFWFirewallCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
