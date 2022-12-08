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
using Amazon.ManagedBlockchain;
using Amazon.ManagedBlockchain.Model;

namespace Amazon.PowerShell.Cmdlets.MBC
{
    /// <summary>
    /// Creates a new blockchain network using Amazon Managed Blockchain.
    /// 
    ///  
    /// <para>
    /// Applies only to Hyperledger Fabric.
    /// </para>
    /// </summary>
    [Cmdlet("New", "MBCNetwork", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ManagedBlockchain.Model.CreateNetworkResponse")]
    [AWSCmdlet("Calls the Amazon Managed Blockchain CreateNetwork API operation.", Operation = new[] {"CreateNetwork"}, SelectReturnType = typeof(Amazon.ManagedBlockchain.Model.CreateNetworkResponse))]
    [AWSCmdletOutput("Amazon.ManagedBlockchain.Model.CreateNetworkResponse",
        "This cmdlet returns an Amazon.ManagedBlockchain.Model.CreateNetworkResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMBCNetworkCmdlet : AmazonManagedBlockchainClientCmdlet, IExecutor
    {
        
        #region Parameter Fabric_AdminPassword
        /// <summary>
        /// <para>
        /// <para>The password for the member's initial administrative user. The <code>AdminPassword</code>
        /// must be at least eight characters long and no more than 32 characters. It must contain
        /// at least one uppercase letter, one lowercase letter, and one digit. It cannot have
        /// a single quotation mark (‘), a double quotation marks (“), a forward slash(/), a backward
        /// slash(\), @, or a space.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemberConfiguration_FrameworkConfiguration_Fabric_AdminPassword")]
        public System.String Fabric_AdminPassword { get; set; }
        #endregion
        
        #region Parameter Fabric_AdminUsername
        /// <summary>
        /// <para>
        /// <para>The user name for the member's initial administrative user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemberConfiguration_FrameworkConfiguration_Fabric_AdminUsername")]
        public System.String Fabric_AdminUsername { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>This is a unique, case-sensitive identifier that you provide to ensure the idempotency
        /// of the operation. An idempotent operation completes no more than once. This identifier
        /// is required only if you make a service request directly using an HTTP client. It is
        /// generated automatically if you use an Amazon Web Services SDK or the Amazon Web Services
        /// CLI. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the network.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter MemberConfiguration_Description
        /// <summary>
        /// <para>
        /// <para>An optional description of the member.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemberConfiguration_Description { get; set; }
        #endregion
        
        #region Parameter Fabric_Edition
        /// <summary>
        /// <para>
        /// <para>The edition of Amazon Managed Blockchain that the network uses. For more information,
        /// see <a href="http://aws.amazon.com/managed-blockchain/pricing/">Amazon Managed Blockchain
        /// Pricing</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FrameworkConfiguration_Fabric_Edition")]
        [AWSConstantClassSource("Amazon.ManagedBlockchain.Edition")]
        public Amazon.ManagedBlockchain.Edition Fabric_Edition { get; set; }
        #endregion
        
        #region Parameter Cloudwatch_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch_Enabled")]
        public System.Boolean? Cloudwatch_Enabled { get; set; }
        #endregion
        
        #region Parameter Framework
        /// <summary>
        /// <para>
        /// <para>The blockchain framework that the network uses.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ManagedBlockchain.Framework")]
        public Amazon.ManagedBlockchain.Framework Framework { get; set; }
        #endregion
        
        #region Parameter FrameworkVersion
        /// <summary>
        /// <para>
        /// <para>The version of the blockchain framework that the network uses.</para>
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
        public System.String FrameworkVersion { get; set; }
        #endregion
        
        #region Parameter MemberConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the customer managed key in Key Management Service
        /// (KMS) to use for encryption at rest in the member. This parameter is inherited by
        /// any nodes that this member creates. For more information, see <a href="https://docs.aws.amazon.com/managed-blockchain/latest/hyperledger-fabric-dev/managed-blockchain-encryption-at-rest.html">Encryption
        /// at Rest</a> in the <i>Amazon Managed Blockchain Hyperledger Fabric Developer Guide</i>.</para><para>Use one of the following options to specify this parameter:</para><ul><li><para><b>Undefined or empty string</b> - By default, use an KMS key that is owned and managed
        /// by Amazon Web Services on your behalf.</para></li><li><para><b>A valid symmetric customer managed KMS key</b> - Use the specified KMS key in
        /// your account that you create, own, and manage.</para><para>Amazon Managed Blockchain doesn't support asymmetric keys. For more information, see
        /// <a href="https://docs.aws.amazon.com/kms/latest/developerguide/symmetric-asymmetric.html">Using
        /// symmetric and asymmetric keys</a> in the <i>Key Management Service Developer Guide</i>.</para><para>The following is an example of a KMS key ARN: <code>arn:aws:kms:us-east-2:111122223333:key/1234abcd-12ab-34cd-56ef-1234567890ab</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MemberConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter MemberConfiguration_Name
        /// <summary>
        /// <para>
        /// <para>The name of the member.</para>
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
        public System.String MemberConfiguration_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the network.</para>
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
        
        #region Parameter ApprovalThresholdPolicy_ProposalDurationInHour
        /// <summary>
        /// <para>
        /// <para>The duration from the time that a proposal is created until it expires. If members
        /// cast neither the required number of <code>YES</code> votes to approve the proposal
        /// nor the number of <code>NO</code> votes required to reject it before the duration
        /// expires, the proposal is <code>EXPIRED</code> and <code>ProposalActions</code> aren't
        /// carried out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VotingPolicy_ApprovalThresholdPolicy_ProposalDurationInHours")]
        public System.Int32? ApprovalThresholdPolicy_ProposalDurationInHour { get; set; }
        #endregion
        
        #region Parameter MemberConfiguration_Tag
        /// <summary>
        /// <para>
        /// <para>Tags assigned to the member. Tags consist of a key and optional value. For more information
        /// about tags, see <a href="https://docs.aws.amazon.com/managed-blockchain/latest/hyperledger-fabric-dev/tagging-resources.html">Tagging
        /// Resources</a> in the <i>Amazon Managed Blockchain Hyperledger Fabric Developer Guide</i>.</para><para>When specifying tags during creation, you can specify multiple key-value pairs in
        /// a single request, with an overall maximum of 50 tags added to each resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MemberConfiguration_Tags")]
        public System.Collections.Hashtable MemberConfiguration_Tag { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to assign to the network. Each tag consists of a key and optional value.</para><para>When specifying tags during creation, you can specify multiple key-value pairs in
        /// a single request, with an overall maximum of 50 tags added to each resource.</para><para>For more information about tags, see <a href="https://docs.aws.amazon.com/managed-blockchain/latest/ethereum-dev/tagging-resources.html">Tagging
        /// Resources</a> in the <i>Amazon Managed Blockchain Ethereum Developer Guide</i>, or
        /// <a href="https://docs.aws.amazon.com/managed-blockchain/latest/hyperledger-fabric-dev/tagging-resources.html">Tagging
        /// Resources</a> in the <i>Amazon Managed Blockchain Hyperledger Fabric Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ApprovalThresholdPolicy_ThresholdComparator
        /// <summary>
        /// <para>
        /// <para>Determines whether the vote percentage must be greater than the <code>ThresholdPercentage</code>
        /// or must be greater than or equal to the <code>ThreholdPercentage</code> to be approved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VotingPolicy_ApprovalThresholdPolicy_ThresholdComparator")]
        [AWSConstantClassSource("Amazon.ManagedBlockchain.ThresholdComparator")]
        public Amazon.ManagedBlockchain.ThresholdComparator ApprovalThresholdPolicy_ThresholdComparator { get; set; }
        #endregion
        
        #region Parameter ApprovalThresholdPolicy_ThresholdPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of votes among all members that must be <code>YES</code> for a proposal
        /// to be approved. For example, a <code>ThresholdPercentage</code> value of <code>50</code>
        /// indicates 50%. The <code>ThresholdComparator</code> determines the precise comparison.
        /// If a <code>ThresholdPercentage</code> value of <code>50</code> is specified on a network
        /// with 10 members, along with a <code>ThresholdComparator</code> value of <code>GREATER_THAN</code>,
        /// this indicates that 6 <code>YES</code> votes are required for the proposal to be approved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VotingPolicy_ApprovalThresholdPolicy_ThresholdPercentage")]
        public System.Int32? ApprovalThresholdPolicy_ThresholdPercentage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ManagedBlockchain.Model.CreateNetworkResponse).
        /// Specifying the name of a property of type Amazon.ManagedBlockchain.Model.CreateNetworkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MBCNetwork (CreateNetwork)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ManagedBlockchain.Model.CreateNetworkResponse, NewMBCNetworkCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.Framework = this.Framework;
            #if MODULAR
            if (this.Framework == null && ParameterWasBound(nameof(this.Framework)))
            {
                WriteWarning("You are passing $null as a value for parameter Framework which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Fabric_Edition = this.Fabric_Edition;
            context.FrameworkVersion = this.FrameworkVersion;
            #if MODULAR
            if (this.FrameworkVersion == null && ParameterWasBound(nameof(this.FrameworkVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter FrameworkVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemberConfiguration_Description = this.MemberConfiguration_Description;
            context.Fabric_AdminPassword = this.Fabric_AdminPassword;
            context.Fabric_AdminUsername = this.Fabric_AdminUsername;
            context.MemberConfiguration_KmsKeyArn = this.MemberConfiguration_KmsKeyArn;
            context.Cloudwatch_Enabled = this.Cloudwatch_Enabled;
            context.MemberConfiguration_Name = this.MemberConfiguration_Name;
            #if MODULAR
            if (this.MemberConfiguration_Name == null && ParameterWasBound(nameof(this.MemberConfiguration_Name)))
            {
                WriteWarning("You are passing $null as a value for parameter MemberConfiguration_Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.MemberConfiguration_Tag != null)
            {
                context.MemberConfiguration_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.MemberConfiguration_Tag.Keys)
                {
                    context.MemberConfiguration_Tag.Add((String)hashKey, (String)(this.MemberConfiguration_Tag[hashKey]));
                }
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.ApprovalThresholdPolicy_ProposalDurationInHour = this.ApprovalThresholdPolicy_ProposalDurationInHour;
            context.ApprovalThresholdPolicy_ThresholdComparator = this.ApprovalThresholdPolicy_ThresholdComparator;
            context.ApprovalThresholdPolicy_ThresholdPercentage = this.ApprovalThresholdPolicy_ThresholdPercentage;
            
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
            var request = new Amazon.ManagedBlockchain.Model.CreateNetworkRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Framework != null)
            {
                request.Framework = cmdletContext.Framework;
            }
            
             // populate FrameworkConfiguration
            var requestFrameworkConfigurationIsNull = true;
            request.FrameworkConfiguration = new Amazon.ManagedBlockchain.Model.NetworkFrameworkConfiguration();
            Amazon.ManagedBlockchain.Model.NetworkFabricConfiguration requestFrameworkConfiguration_frameworkConfiguration_Fabric = null;
            
             // populate Fabric
            var requestFrameworkConfiguration_frameworkConfiguration_FabricIsNull = true;
            requestFrameworkConfiguration_frameworkConfiguration_Fabric = new Amazon.ManagedBlockchain.Model.NetworkFabricConfiguration();
            Amazon.ManagedBlockchain.Edition requestFrameworkConfiguration_frameworkConfiguration_Fabric_fabric_Edition = null;
            if (cmdletContext.Fabric_Edition != null)
            {
                requestFrameworkConfiguration_frameworkConfiguration_Fabric_fabric_Edition = cmdletContext.Fabric_Edition;
            }
            if (requestFrameworkConfiguration_frameworkConfiguration_Fabric_fabric_Edition != null)
            {
                requestFrameworkConfiguration_frameworkConfiguration_Fabric.Edition = requestFrameworkConfiguration_frameworkConfiguration_Fabric_fabric_Edition;
                requestFrameworkConfiguration_frameworkConfiguration_FabricIsNull = false;
            }
             // determine if requestFrameworkConfiguration_frameworkConfiguration_Fabric should be set to null
            if (requestFrameworkConfiguration_frameworkConfiguration_FabricIsNull)
            {
                requestFrameworkConfiguration_frameworkConfiguration_Fabric = null;
            }
            if (requestFrameworkConfiguration_frameworkConfiguration_Fabric != null)
            {
                request.FrameworkConfiguration.Fabric = requestFrameworkConfiguration_frameworkConfiguration_Fabric;
                requestFrameworkConfigurationIsNull = false;
            }
             // determine if request.FrameworkConfiguration should be set to null
            if (requestFrameworkConfigurationIsNull)
            {
                request.FrameworkConfiguration = null;
            }
            if (cmdletContext.FrameworkVersion != null)
            {
                request.FrameworkVersion = cmdletContext.FrameworkVersion;
            }
            
             // populate MemberConfiguration
            var requestMemberConfigurationIsNull = true;
            request.MemberConfiguration = new Amazon.ManagedBlockchain.Model.MemberConfiguration();
            System.String requestMemberConfiguration_memberConfiguration_Description = null;
            if (cmdletContext.MemberConfiguration_Description != null)
            {
                requestMemberConfiguration_memberConfiguration_Description = cmdletContext.MemberConfiguration_Description;
            }
            if (requestMemberConfiguration_memberConfiguration_Description != null)
            {
                request.MemberConfiguration.Description = requestMemberConfiguration_memberConfiguration_Description;
                requestMemberConfigurationIsNull = false;
            }
            System.String requestMemberConfiguration_memberConfiguration_KmsKeyArn = null;
            if (cmdletContext.MemberConfiguration_KmsKeyArn != null)
            {
                requestMemberConfiguration_memberConfiguration_KmsKeyArn = cmdletContext.MemberConfiguration_KmsKeyArn;
            }
            if (requestMemberConfiguration_memberConfiguration_KmsKeyArn != null)
            {
                request.MemberConfiguration.KmsKeyArn = requestMemberConfiguration_memberConfiguration_KmsKeyArn;
                requestMemberConfigurationIsNull = false;
            }
            System.String requestMemberConfiguration_memberConfiguration_Name = null;
            if (cmdletContext.MemberConfiguration_Name != null)
            {
                requestMemberConfiguration_memberConfiguration_Name = cmdletContext.MemberConfiguration_Name;
            }
            if (requestMemberConfiguration_memberConfiguration_Name != null)
            {
                request.MemberConfiguration.Name = requestMemberConfiguration_memberConfiguration_Name;
                requestMemberConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestMemberConfiguration_memberConfiguration_Tag = null;
            if (cmdletContext.MemberConfiguration_Tag != null)
            {
                requestMemberConfiguration_memberConfiguration_Tag = cmdletContext.MemberConfiguration_Tag;
            }
            if (requestMemberConfiguration_memberConfiguration_Tag != null)
            {
                request.MemberConfiguration.Tags = requestMemberConfiguration_memberConfiguration_Tag;
                requestMemberConfigurationIsNull = false;
            }
            Amazon.ManagedBlockchain.Model.MemberFrameworkConfiguration requestMemberConfiguration_memberConfiguration_FrameworkConfiguration = null;
            
             // populate FrameworkConfiguration
            var requestMemberConfiguration_memberConfiguration_FrameworkConfigurationIsNull = true;
            requestMemberConfiguration_memberConfiguration_FrameworkConfiguration = new Amazon.ManagedBlockchain.Model.MemberFrameworkConfiguration();
            Amazon.ManagedBlockchain.Model.MemberFabricConfiguration requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric = null;
            
             // populate Fabric
            var requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_FabricIsNull = true;
            requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric = new Amazon.ManagedBlockchain.Model.MemberFabricConfiguration();
            System.String requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric_fabric_AdminPassword = null;
            if (cmdletContext.Fabric_AdminPassword != null)
            {
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric_fabric_AdminPassword = cmdletContext.Fabric_AdminPassword;
            }
            if (requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric_fabric_AdminPassword != null)
            {
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric.AdminPassword = requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric_fabric_AdminPassword;
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_FabricIsNull = false;
            }
            System.String requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric_fabric_AdminUsername = null;
            if (cmdletContext.Fabric_AdminUsername != null)
            {
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric_fabric_AdminUsername = cmdletContext.Fabric_AdminUsername;
            }
            if (requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric_fabric_AdminUsername != null)
            {
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric.AdminUsername = requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric_fabric_AdminUsername;
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_FabricIsNull = false;
            }
             // determine if requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric should be set to null
            if (requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_FabricIsNull)
            {
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric = null;
            }
            if (requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric != null)
            {
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration.Fabric = requestMemberConfiguration_memberConfiguration_FrameworkConfiguration_memberConfiguration_FrameworkConfiguration_Fabric;
                requestMemberConfiguration_memberConfiguration_FrameworkConfigurationIsNull = false;
            }
             // determine if requestMemberConfiguration_memberConfiguration_FrameworkConfiguration should be set to null
            if (requestMemberConfiguration_memberConfiguration_FrameworkConfigurationIsNull)
            {
                requestMemberConfiguration_memberConfiguration_FrameworkConfiguration = null;
            }
            if (requestMemberConfiguration_memberConfiguration_FrameworkConfiguration != null)
            {
                request.MemberConfiguration.FrameworkConfiguration = requestMemberConfiguration_memberConfiguration_FrameworkConfiguration;
                requestMemberConfigurationIsNull = false;
            }
            Amazon.ManagedBlockchain.Model.MemberLogPublishingConfiguration requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration = null;
            
             // populate LogPublishingConfiguration
            var requestMemberConfiguration_memberConfiguration_LogPublishingConfigurationIsNull = true;
            requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration = new Amazon.ManagedBlockchain.Model.MemberLogPublishingConfiguration();
            Amazon.ManagedBlockchain.Model.MemberFabricLogPublishingConfiguration requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric = null;
            
             // populate Fabric
            var requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_FabricIsNull = true;
            requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric = new Amazon.ManagedBlockchain.Model.MemberFabricLogPublishingConfiguration();
            Amazon.ManagedBlockchain.Model.LogConfigurations requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs = null;
            
             // populate CaLogs
            var requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogsIsNull = true;
            requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs = new Amazon.ManagedBlockchain.Model.LogConfigurations();
            Amazon.ManagedBlockchain.Model.LogConfiguration requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch = null;
            
             // populate Cloudwatch
            var requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_CloudwatchIsNull = true;
            requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch = new Amazon.ManagedBlockchain.Model.LogConfiguration();
            System.Boolean? requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch_cloudwatch_Enabled = null;
            if (cmdletContext.Cloudwatch_Enabled != null)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch_cloudwatch_Enabled = cmdletContext.Cloudwatch_Enabled.Value;
            }
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch_cloudwatch_Enabled != null)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch.Enabled = requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch_cloudwatch_Enabled.Value;
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_CloudwatchIsNull = false;
            }
             // determine if requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch should be set to null
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_CloudwatchIsNull)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch = null;
            }
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch != null)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs.Cloudwatch = requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs_Cloudwatch;
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogsIsNull = false;
            }
             // determine if requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs should be set to null
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogsIsNull)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs = null;
            }
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs != null)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric.CaLogs = requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric_memberConfiguration_LogPublishingConfiguration_Fabric_CaLogs;
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_FabricIsNull = false;
            }
             // determine if requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric should be set to null
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_FabricIsNull)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric = null;
            }
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric != null)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration.Fabric = requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration_memberConfiguration_LogPublishingConfiguration_Fabric;
                requestMemberConfiguration_memberConfiguration_LogPublishingConfigurationIsNull = false;
            }
             // determine if requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration should be set to null
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfigurationIsNull)
            {
                requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration = null;
            }
            if (requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration != null)
            {
                request.MemberConfiguration.LogPublishingConfiguration = requestMemberConfiguration_memberConfiguration_LogPublishingConfiguration;
                requestMemberConfigurationIsNull = false;
            }
             // determine if request.MemberConfiguration should be set to null
            if (requestMemberConfigurationIsNull)
            {
                request.MemberConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate VotingPolicy
            var requestVotingPolicyIsNull = true;
            request.VotingPolicy = new Amazon.ManagedBlockchain.Model.VotingPolicy();
            Amazon.ManagedBlockchain.Model.ApprovalThresholdPolicy requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy = null;
            
             // populate ApprovalThresholdPolicy
            var requestVotingPolicy_votingPolicy_ApprovalThresholdPolicyIsNull = true;
            requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy = new Amazon.ManagedBlockchain.Model.ApprovalThresholdPolicy();
            System.Int32? requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ProposalDurationInHour = null;
            if (cmdletContext.ApprovalThresholdPolicy_ProposalDurationInHour != null)
            {
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ProposalDurationInHour = cmdletContext.ApprovalThresholdPolicy_ProposalDurationInHour.Value;
            }
            if (requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ProposalDurationInHour != null)
            {
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy.ProposalDurationInHours = requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ProposalDurationInHour.Value;
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicyIsNull = false;
            }
            Amazon.ManagedBlockchain.ThresholdComparator requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ThresholdComparator = null;
            if (cmdletContext.ApprovalThresholdPolicy_ThresholdComparator != null)
            {
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ThresholdComparator = cmdletContext.ApprovalThresholdPolicy_ThresholdComparator;
            }
            if (requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ThresholdComparator != null)
            {
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy.ThresholdComparator = requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ThresholdComparator;
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicyIsNull = false;
            }
            System.Int32? requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ThresholdPercentage = null;
            if (cmdletContext.ApprovalThresholdPolicy_ThresholdPercentage != null)
            {
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ThresholdPercentage = cmdletContext.ApprovalThresholdPolicy_ThresholdPercentage.Value;
            }
            if (requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ThresholdPercentage != null)
            {
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy.ThresholdPercentage = requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy_approvalThresholdPolicy_ThresholdPercentage.Value;
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicyIsNull = false;
            }
             // determine if requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy should be set to null
            if (requestVotingPolicy_votingPolicy_ApprovalThresholdPolicyIsNull)
            {
                requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy = null;
            }
            if (requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy != null)
            {
                request.VotingPolicy.ApprovalThresholdPolicy = requestVotingPolicy_votingPolicy_ApprovalThresholdPolicy;
                requestVotingPolicyIsNull = false;
            }
             // determine if request.VotingPolicy should be set to null
            if (requestVotingPolicyIsNull)
            {
                request.VotingPolicy = null;
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
        
        private Amazon.ManagedBlockchain.Model.CreateNetworkResponse CallAWSServiceOperation(IAmazonManagedBlockchain client, Amazon.ManagedBlockchain.Model.CreateNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Blockchain", "CreateNetwork");
            try
            {
                #if DESKTOP
                return client.CreateNetwork(request);
                #elif CORECLR
                return client.CreateNetworkAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.ManagedBlockchain.Framework Framework { get; set; }
            public Amazon.ManagedBlockchain.Edition Fabric_Edition { get; set; }
            public System.String FrameworkVersion { get; set; }
            public System.String MemberConfiguration_Description { get; set; }
            public System.String Fabric_AdminPassword { get; set; }
            public System.String Fabric_AdminUsername { get; set; }
            public System.String MemberConfiguration_KmsKeyArn { get; set; }
            public System.Boolean? Cloudwatch_Enabled { get; set; }
            public System.String MemberConfiguration_Name { get; set; }
            public Dictionary<System.String, System.String> MemberConfiguration_Tag { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Int32? ApprovalThresholdPolicy_ProposalDurationInHour { get; set; }
            public Amazon.ManagedBlockchain.ThresholdComparator ApprovalThresholdPolicy_ThresholdComparator { get; set; }
            public System.Int32? ApprovalThresholdPolicy_ThresholdPercentage { get; set; }
            public System.Func<Amazon.ManagedBlockchain.Model.CreateNetworkResponse, NewMBCNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
