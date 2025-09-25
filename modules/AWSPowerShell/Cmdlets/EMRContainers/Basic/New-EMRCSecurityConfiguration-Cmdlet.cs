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
using Amazon.EMRContainers;
using Amazon.EMRContainers.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EMRC
{
    /// <summary>
    /// Creates a security configuration. Security configurations in Amazon EMR on EKS are
    /// templates for different security setups. You can use security configurations to configure
    /// the Lake Formation integration setup. You can also create a security configuration
    /// to re-use a security setup each time you create a virtual cluster.
    /// </summary>
    [Cmdlet("New", "EMRCSecurityConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon EMR Containers CreateSecurityConfiguration API operation.", Operation = new[] {"CreateSecurityConfiguration"}, SelectReturnType = typeof(Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse))]
    [AWSCmdletOutput("Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse",
        "This cmdlet returns an Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse object containing multiple properties."
    )]
    public partial class NewEMRCSecurityConfigurationCmdlet : AmazonEMRContainersClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LakeFormationConfiguration_AuthorizedSessionTagValue
        /// <summary>
        /// <para>
        /// <para>The session tag to authorize Amazon EMR on EKS for API calls to Lake Formation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_AuthorizedSessionTagValue")]
        public System.String LakeFormationConfiguration_AuthorizedSessionTagValue { get; set; }
        #endregion
        
        #region Parameter TlsCertificateConfiguration_CertificateProviderType
        /// <summary>
        /// <para>
        /// <para>The TLS certificate type. Acceptable values: <c>PEM</c> or <c>Custom</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_CertificateProviderType")]
        [AWSConstantClassSource("Amazon.EMRContainers.CertificateProviderType")]
        public Amazon.EMRContainers.CertificateProviderType TlsCertificateConfiguration_CertificateProviderType { get; set; }
        #endregion
        
        #region Parameter SecureNamespaceInfo_ClusterId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon EKS cluster where Amazon EMR on EKS jobs run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_ClusterId")]
        public System.String SecureNamespaceInfo_ClusterId { get; set; }
        #endregion
        
        #region Parameter ContainerProvider_Id
        /// <summary>
        /// <para>
        /// <para>The ID of the container cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerProvider_Id { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the security configuration.</para>
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
        
        #region Parameter EksInfo_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespaces of the Amazon EKS cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProvider_Info_EksInfo_Namespace")]
        public System.String EksInfo_Namespace { get; set; }
        #endregion
        
        #region Parameter SecureNamespaceInfo_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the Amazon EKS cluster where the system jobs run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_Namespace")]
        public System.String SecureNamespaceInfo_Namespace { get; set; }
        #endregion
        
        #region Parameter EksInfo_NodeLabel
        /// <summary>
        /// <para>
        /// <para>The nodeLabel of the nodes where the resources of this virtual cluster can get scheduled.
        /// It requires relevant scaling and policy engine addons.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContainerProvider_Info_EksInfo_NodeLabel")]
        public System.String EksInfo_NodeLabel { get; set; }
        #endregion
        
        #region Parameter TlsCertificateConfiguration_PrivateCertificateSecretArn
        /// <summary>
        /// <para>
        /// <para>Secrets Manager ARN that contains the private TLS certificate contents, used for communication
        /// between the user job and the system job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_PrivateCertificateSecretArn")]
        public System.String TlsCertificateConfiguration_PrivateCertificateSecretArn { get; set; }
        #endregion
        
        #region Parameter TlsCertificateConfiguration_PublicCertificateSecretArn
        /// <summary>
        /// <para>
        /// <para>Secrets Manager ARN that contains the public TLS certificate contents, used for communication
        /// between the user job and the system job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_PublicCertificateSecretArn")]
        public System.String TlsCertificateConfiguration_PublicCertificateSecretArn { get; set; }
        #endregion
        
        #region Parameter LakeFormationConfiguration_QueryEngineRoleArn
        /// <summary>
        /// <para>
        /// <para>The query engine IAM role ARN that is tied to the secure Spark job. The <c>QueryEngine</c>
        /// role assumes the <c>JobExecutionRole</c> to execute all the Lake Formation calls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_QueryEngineRoleArn")]
        public System.String LakeFormationConfiguration_QueryEngineRoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the security configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ContainerProvider_Type
        /// <summary>
        /// <para>
        /// <para>The type of the container provider. Amazon EKS is the only supported type as of now.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EMRContainers.ContainerProviderType")]
        public Amazon.EMRContainers.ContainerProviderType ContainerProvider_Type { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client idempotency token to use when creating the security configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse).
        /// Specifying the name of a property of type Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EMRCSecurityConfiguration (CreateSecurityConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse, NewEMRCSecurityConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ContainerProvider_Id = this.ContainerProvider_Id;
            context.EksInfo_Namespace = this.EksInfo_Namespace;
            context.EksInfo_NodeLabel = this.EksInfo_NodeLabel;
            context.ContainerProvider_Type = this.ContainerProvider_Type;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TlsCertificateConfiguration_CertificateProviderType = this.TlsCertificateConfiguration_CertificateProviderType;
            context.TlsCertificateConfiguration_PrivateCertificateSecretArn = this.TlsCertificateConfiguration_PrivateCertificateSecretArn;
            context.TlsCertificateConfiguration_PublicCertificateSecretArn = this.TlsCertificateConfiguration_PublicCertificateSecretArn;
            context.LakeFormationConfiguration_AuthorizedSessionTagValue = this.LakeFormationConfiguration_AuthorizedSessionTagValue;
            context.LakeFormationConfiguration_QueryEngineRoleArn = this.LakeFormationConfiguration_QueryEngineRoleArn;
            context.SecureNamespaceInfo_ClusterId = this.SecureNamespaceInfo_ClusterId;
            context.SecureNamespaceInfo_Namespace = this.SecureNamespaceInfo_Namespace;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.EMRContainers.Model.CreateSecurityConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ContainerProvider
            var requestContainerProviderIsNull = true;
            request.ContainerProvider = new Amazon.EMRContainers.Model.ContainerProvider();
            System.String requestContainerProvider_containerProvider_Id = null;
            if (cmdletContext.ContainerProvider_Id != null)
            {
                requestContainerProvider_containerProvider_Id = cmdletContext.ContainerProvider_Id;
            }
            if (requestContainerProvider_containerProvider_Id != null)
            {
                request.ContainerProvider.Id = requestContainerProvider_containerProvider_Id;
                requestContainerProviderIsNull = false;
            }
            Amazon.EMRContainers.ContainerProviderType requestContainerProvider_containerProvider_Type = null;
            if (cmdletContext.ContainerProvider_Type != null)
            {
                requestContainerProvider_containerProvider_Type = cmdletContext.ContainerProvider_Type;
            }
            if (requestContainerProvider_containerProvider_Type != null)
            {
                request.ContainerProvider.Type = requestContainerProvider_containerProvider_Type;
                requestContainerProviderIsNull = false;
            }
            Amazon.EMRContainers.Model.ContainerInfo requestContainerProvider_containerProvider_Info = null;
            
             // populate Info
            var requestContainerProvider_containerProvider_InfoIsNull = true;
            requestContainerProvider_containerProvider_Info = new Amazon.EMRContainers.Model.ContainerInfo();
            Amazon.EMRContainers.Model.EksInfo requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo = null;
            
             // populate EksInfo
            var requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfoIsNull = true;
            requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo = new Amazon.EMRContainers.Model.EksInfo();
            System.String requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_Namespace = null;
            if (cmdletContext.EksInfo_Namespace != null)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_Namespace = cmdletContext.EksInfo_Namespace;
            }
            if (requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_Namespace != null)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo.Namespace = requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_Namespace;
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfoIsNull = false;
            }
            System.String requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_NodeLabel = null;
            if (cmdletContext.EksInfo_NodeLabel != null)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_NodeLabel = cmdletContext.EksInfo_NodeLabel;
            }
            if (requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_NodeLabel != null)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo.NodeLabel = requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo_eksInfo_NodeLabel;
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfoIsNull = false;
            }
             // determine if requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo should be set to null
            if (requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfoIsNull)
            {
                requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo = null;
            }
            if (requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo != null)
            {
                requestContainerProvider_containerProvider_Info.EksInfo = requestContainerProvider_containerProvider_Info_containerProvider_Info_EksInfo;
                requestContainerProvider_containerProvider_InfoIsNull = false;
            }
             // determine if requestContainerProvider_containerProvider_Info should be set to null
            if (requestContainerProvider_containerProvider_InfoIsNull)
            {
                requestContainerProvider_containerProvider_Info = null;
            }
            if (requestContainerProvider_containerProvider_Info != null)
            {
                request.ContainerProvider.Info = requestContainerProvider_containerProvider_Info;
                requestContainerProviderIsNull = false;
            }
             // determine if request.ContainerProvider should be set to null
            if (requestContainerProviderIsNull)
            {
                request.ContainerProvider = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate SecurityConfigurationData
            var requestSecurityConfigurationDataIsNull = true;
            request.SecurityConfigurationData = new Amazon.EMRContainers.Model.SecurityConfigurationData();
            Amazon.EMRContainers.Model.AuthorizationConfiguration requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration = null;
            
             // populate AuthorizationConfiguration
            var requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfigurationIsNull = true;
            requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration = new Amazon.EMRContainers.Model.AuthorizationConfiguration();
            Amazon.EMRContainers.Model.EncryptionConfiguration requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration = null;
            
             // populate EncryptionConfiguration
            var requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfigurationIsNull = true;
            requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration = new Amazon.EMRContainers.Model.EncryptionConfiguration();
            Amazon.EMRContainers.Model.InTransitEncryptionConfiguration requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration = null;
            
             // populate InTransitEncryptionConfiguration
            var requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfigurationIsNull = true;
            requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration = new Amazon.EMRContainers.Model.InTransitEncryptionConfiguration();
            Amazon.EMRContainers.Model.TLSCertificateConfiguration requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration = null;
            
             // populate TlsCertificateConfiguration
            var requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfigurationIsNull = true;
            requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration = new Amazon.EMRContainers.Model.TLSCertificateConfiguration();
            Amazon.EMRContainers.CertificateProviderType requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_CertificateProviderType = null;
            if (cmdletContext.TlsCertificateConfiguration_CertificateProviderType != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_CertificateProviderType = cmdletContext.TlsCertificateConfiguration_CertificateProviderType;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_CertificateProviderType != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration.CertificateProviderType = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_CertificateProviderType;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfigurationIsNull = false;
            }
            System.String requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_PrivateCertificateSecretArn = null;
            if (cmdletContext.TlsCertificateConfiguration_PrivateCertificateSecretArn != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_PrivateCertificateSecretArn = cmdletContext.TlsCertificateConfiguration_PrivateCertificateSecretArn;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_PrivateCertificateSecretArn != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration.PrivateCertificateSecretArn = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_PrivateCertificateSecretArn;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfigurationIsNull = false;
            }
            System.String requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_PublicCertificateSecretArn = null;
            if (cmdletContext.TlsCertificateConfiguration_PublicCertificateSecretArn != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_PublicCertificateSecretArn = cmdletContext.TlsCertificateConfiguration_PublicCertificateSecretArn;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_PublicCertificateSecretArn != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration.PublicCertificateSecretArn = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration_tlsCertificateConfiguration_PublicCertificateSecretArn;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfigurationIsNull = false;
            }
             // determine if requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration should be set to null
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfigurationIsNull)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration = null;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration.TlsCertificateConfiguration = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration_TlsCertificateConfiguration;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfigurationIsNull = false;
            }
             // determine if requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration should be set to null
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfigurationIsNull)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration = null;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration.InTransitEncryptionConfiguration = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration_InTransitEncryptionConfiguration;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfigurationIsNull = false;
            }
             // determine if requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration should be set to null
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfigurationIsNull)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration = null;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration.EncryptionConfiguration = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_EncryptionConfiguration;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfigurationIsNull = false;
            }
            Amazon.EMRContainers.Model.LakeFormationConfiguration requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration = null;
            
             // populate LakeFormationConfiguration
            var requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfigurationIsNull = true;
            requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration = new Amazon.EMRContainers.Model.LakeFormationConfiguration();
            System.String requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_lakeFormationConfiguration_AuthorizedSessionTagValue = null;
            if (cmdletContext.LakeFormationConfiguration_AuthorizedSessionTagValue != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_lakeFormationConfiguration_AuthorizedSessionTagValue = cmdletContext.LakeFormationConfiguration_AuthorizedSessionTagValue;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_lakeFormationConfiguration_AuthorizedSessionTagValue != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration.AuthorizedSessionTagValue = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_lakeFormationConfiguration_AuthorizedSessionTagValue;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfigurationIsNull = false;
            }
            System.String requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_lakeFormationConfiguration_QueryEngineRoleArn = null;
            if (cmdletContext.LakeFormationConfiguration_QueryEngineRoleArn != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_lakeFormationConfiguration_QueryEngineRoleArn = cmdletContext.LakeFormationConfiguration_QueryEngineRoleArn;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_lakeFormationConfiguration_QueryEngineRoleArn != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration.QueryEngineRoleArn = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_lakeFormationConfiguration_QueryEngineRoleArn;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfigurationIsNull = false;
            }
            Amazon.EMRContainers.Model.SecureNamespaceInfo requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo = null;
            
             // populate SecureNamespaceInfo
            var requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfoIsNull = true;
            requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo = new Amazon.EMRContainers.Model.SecureNamespaceInfo();
            System.String requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_secureNamespaceInfo_ClusterId = null;
            if (cmdletContext.SecureNamespaceInfo_ClusterId != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_secureNamespaceInfo_ClusterId = cmdletContext.SecureNamespaceInfo_ClusterId;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_secureNamespaceInfo_ClusterId != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo.ClusterId = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_secureNamespaceInfo_ClusterId;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfoIsNull = false;
            }
            System.String requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_secureNamespaceInfo_Namespace = null;
            if (cmdletContext.SecureNamespaceInfo_Namespace != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_secureNamespaceInfo_Namespace = cmdletContext.SecureNamespaceInfo_Namespace;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_secureNamespaceInfo_Namespace != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo.Namespace = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo_secureNamespaceInfo_Namespace;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfoIsNull = false;
            }
             // determine if requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo should be set to null
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfoIsNull)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo = null;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration.SecureNamespaceInfo = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration_SecureNamespaceInfo;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfigurationIsNull = false;
            }
             // determine if requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration should be set to null
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfigurationIsNull)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration = null;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration != null)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration.LakeFormationConfiguration = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration_securityConfigurationData_AuthorizationConfiguration_LakeFormationConfiguration;
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfigurationIsNull = false;
            }
             // determine if requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration should be set to null
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfigurationIsNull)
            {
                requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration = null;
            }
            if (requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration != null)
            {
                request.SecurityConfigurationData.AuthorizationConfiguration = requestSecurityConfigurationData_securityConfigurationData_AuthorizationConfiguration;
                requestSecurityConfigurationDataIsNull = false;
            }
             // determine if request.SecurityConfigurationData should be set to null
            if (requestSecurityConfigurationDataIsNull)
            {
                request.SecurityConfigurationData = null;
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
        
        private Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse CallAWSServiceOperation(IAmazonEMRContainers client, Amazon.EMRContainers.Model.CreateSecurityConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EMR Containers", "CreateSecurityConfiguration");
            try
            {
                return client.CreateSecurityConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ContainerProvider_Id { get; set; }
            public System.String EksInfo_Namespace { get; set; }
            public System.String EksInfo_NodeLabel { get; set; }
            public Amazon.EMRContainers.ContainerProviderType ContainerProvider_Type { get; set; }
            public System.String Name { get; set; }
            public Amazon.EMRContainers.CertificateProviderType TlsCertificateConfiguration_CertificateProviderType { get; set; }
            public System.String TlsCertificateConfiguration_PrivateCertificateSecretArn { get; set; }
            public System.String TlsCertificateConfiguration_PublicCertificateSecretArn { get; set; }
            public System.String LakeFormationConfiguration_AuthorizedSessionTagValue { get; set; }
            public System.String LakeFormationConfiguration_QueryEngineRoleArn { get; set; }
            public System.String SecureNamespaceInfo_ClusterId { get; set; }
            public System.String SecureNamespaceInfo_Namespace { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.EMRContainers.Model.CreateSecurityConfigurationResponse, NewEMRCSecurityConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
