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
using Amazon.AppMesh;
using Amazon.AppMesh.Model;

namespace Amazon.PowerShell.Cmdlets.AMSH
{
    /// <summary>
    /// Updates an existing virtual node in a specified service mesh.
    /// </summary>
    [Cmdlet("Update", "AMSHVirtualNode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppMesh.Model.VirtualNodeData")]
    [AWSCmdlet("Calls the AWS App Mesh UpdateVirtualNode API operation.", Operation = new[] {"UpdateVirtualNode"}, SelectReturnType = typeof(Amazon.AppMesh.Model.UpdateVirtualNodeResponse))]
    [AWSCmdletOutput("Amazon.AppMesh.Model.VirtualNodeData or Amazon.AppMesh.Model.UpdateVirtualNodeResponse",
        "This cmdlet returns an Amazon.AppMesh.Model.VirtualNodeData object.",
        "The service call response (type Amazon.AppMesh.Model.UpdateVirtualNodeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateAMSHVirtualNodeCmdlet : AmazonAppMeshClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsCloudMap_Attribute
        /// <summary>
        /// <para>
        /// <para>A string map that contains attributes with values that you can use to filter instances
        /// by any custom attribute that you specified when you registered the instance. Only
        /// instances that match all of the specified key/value pairs will be returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_AwsCloudMap_Attributes")]
        public Amazon.AppMesh.Model.AwsCloudMapInstanceAttribute[] AwsCloudMap_Attribute { get; set; }
        #endregion
        
        #region Parameter Spec_Backend
        /// <summary>
        /// <para>
        /// <para>The backends that the virtual node is expected to send outbound traffic to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Backends")]
        public Amazon.AppMesh.Model.Backend[] Spec_Backend { get; set; }
        #endregion
        
        #region Parameter Acm_CertificateAuthorityArn
        /// <summary>
        /// <para>
        /// <para>One or more ACM Amazon Resource Name (ARN)s.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm_CertificateAuthorityArns")]
        public System.String[] Acm_CertificateAuthorityArn { get; set; }
        #endregion
        
        #region Parameter Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain
        /// <summary>
        /// <para>
        /// <para>The certificate chain for the certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain { get; set; }
        #endregion
        
        #region Parameter Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain
        /// <summary>
        /// <para>
        /// <para>The certificate trust chain for a certificate stored on the file system of the virtual
        /// node that the proxy is running on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("File_CertificateChain")]
        public System.String Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain { get; set; }
        #endregion
        
        #region Parameter Tls_Enforce
        /// <summary>
        /// <para>
        /// <para>Whether the policy is enforced. The default is <code>True</code>, if a value isn't
        /// specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_BackendDefaults_ClientPolicy_Tls_Enforce")]
        public System.Boolean? Tls_Enforce { get; set; }
        #endregion
        
        #region Parameter Match_Exact
        /// <summary>
        /// <para>
        /// <para>The values sent must match the specified values exactly.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match_Exact")]
        public System.String[] Match_Exact { get; set; }
        #endregion
        
        #region Parameter Dns_Hostname
        /// <summary>
        /// <para>
        /// <para>Specifies the DNS service discovery hostname for the virtual node. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_Dns_Hostname")]
        public System.String Dns_Hostname { get; set; }
        #endregion
        
        #region Parameter AwsCloudMap_IpPreference
        /// <summary>
        /// <para>
        /// <para>The preferred IP version that this virtual node uses. Setting the IP preference on
        /// the virtual node only overrides the IP preference set for the mesh on this specific
        /// node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_AwsCloudMap_IpPreference")]
        [AWSConstantClassSource("Amazon.AppMesh.IpPreference")]
        public Amazon.AppMesh.IpPreference AwsCloudMap_IpPreference { get; set; }
        #endregion
        
        #region Parameter Dns_IpPreference
        /// <summary>
        /// <para>
        /// <para>The preferred IP version that this virtual node uses. Setting the IP preference on
        /// the virtual node only overrides the IP preference set for the mesh on this specific
        /// node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_Dns_IpPreference")]
        [AWSConstantClassSource("Amazon.AppMesh.IpPreference")]
        public Amazon.AppMesh.IpPreference Dns_IpPreference { get; set; }
        #endregion
        
        #region Parameter Format_Json
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Logging_AccessLog_File_Format_Json")]
        public Amazon.AppMesh.Model.JsonFormatRef[] Format_Json { get; set; }
        #endregion
        
        #region Parameter Spec_Listener
        /// <summary>
        /// <para>
        /// <para>The listener that the virtual node is expected to receive inbound traffic from. You
        /// can specify one listener.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Listeners")]
        public Amazon.AppMesh.Model.Listener[] Spec_Listener { get; set; }
        #endregion
        
        #region Parameter MeshName
        /// <summary>
        /// <para>
        /// <para>The name of the service mesh that the virtual node resides in.</para>
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
        public System.String MeshName { get; set; }
        #endregion
        
        #region Parameter MeshOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services IAM account ID of the service mesh owner. If the account ID
        /// is not your own, then it's the ID of the account that shared the mesh with your account.
        /// For more information about mesh sharing, see <a href="https://docs.aws.amazon.com/app-mesh/latest/userguide/sharing.html">Working
        /// with shared meshes</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MeshOwner { get; set; }
        #endregion
        
        #region Parameter AwsCloudMap_NamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the Cloud Map namespace to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_AwsCloudMap_NamespaceName")]
        public System.String AwsCloudMap_NamespaceName { get; set; }
        #endregion
        
        #region Parameter File_Path
        /// <summary>
        /// <para>
        /// <para>The file path to write access logs to. You can use <code>/dev/stdout</code> to send
        /// access logs to standard out and configure your Envoy container to use a log driver,
        /// such as <code>awslogs</code>, to export the access logs to a log storage service such
        /// as Amazon CloudWatch Logs. You can also specify a path in the Envoy container's file
        /// system to write the files to disk.</para><note><para>The Envoy process must have write permissions to the path that you specify here. Otherwise,
        /// Envoy fails to bootstrap properly.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Logging_AccessLog_File_Path")]
        public System.String File_Path { get; set; }
        #endregion
        
        #region Parameter Tls_Port
        /// <summary>
        /// <para>
        /// <para>One or more ports that the policy is enforced for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_BackendDefaults_ClientPolicy_Tls_Ports")]
        public System.Int32[] Tls_Port { get; set; }
        #endregion
        
        #region Parameter File_PrivateKey
        /// <summary>
        /// <para>
        /// <para>The private key for a certificate stored on the file system of the virtual node that
        /// the proxy is running on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_PrivateKey")]
        public System.String File_PrivateKey { get; set; }
        #endregion
        
        #region Parameter Dns_ResponseType
        /// <summary>
        /// <para>
        /// <para>Specifies the DNS response type for the virtual node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_Dns_ResponseType")]
        [AWSConstantClassSource("Amazon.AppMesh.DnsResponseType")]
        public Amazon.AppMesh.DnsResponseType Dns_ResponseType { get; set; }
        #endregion
        
        #region Parameter Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName
        /// <summary>
        /// <para>
        /// <para>A reference to an object that represents the name of the secret requested from the
        /// Secret Discovery Service provider representing Transport Layer Security (TLS) materials
        /// like a certificate or certificate chain.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sds_SecretName")]
        public System.String Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName { get; set; }
        #endregion
        
        #region Parameter Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName
        /// <summary>
        /// <para>
        /// <para>A reference to an object that represents the name of the secret for a Transport Layer
        /// Security (TLS) Secret Discovery Service validation context trust.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName { get; set; }
        #endregion
        
        #region Parameter AwsCloudMap_ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the Cloud Map service to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_ServiceDiscovery_AwsCloudMap_ServiceName")]
        public System.String AwsCloudMap_ServiceName { get; set; }
        #endregion
        
        #region Parameter Format_Text
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Spec_Logging_AccessLog_File_Format_Text")]
        public System.String Format_Text { get; set; }
        #endregion
        
        #region Parameter VirtualNodeName
        /// <summary>
        /// <para>
        /// <para>The name of the virtual node to update.</para>
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
        public System.String VirtualNodeName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. Up to 36 letters, numbers, hyphens, and underscores are allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'VirtualNode'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppMesh.Model.UpdateVirtualNodeResponse).
        /// Specifying the name of a property of type Amazon.AppMesh.Model.UpdateVirtualNodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "VirtualNode";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the VirtualNodeName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^VirtualNodeName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^VirtualNodeName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.VirtualNodeName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMSHVirtualNode (UpdateVirtualNode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppMesh.Model.UpdateVirtualNodeResponse, UpdateAMSHVirtualNodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.VirtualNodeName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.MeshName = this.MeshName;
            #if MODULAR
            if (this.MeshName == null && ParameterWasBound(nameof(this.MeshName)))
            {
                WriteWarning("You are passing $null as a value for parameter MeshName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MeshOwner = this.MeshOwner;
            context.Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain = this.Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain;
            context.File_PrivateKey = this.File_PrivateKey;
            context.Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName = this.Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName;
            context.Tls_Enforce = this.Tls_Enforce;
            if (this.Tls_Port != null)
            {
                context.Tls_Port = new List<System.Int32>(this.Tls_Port);
            }
            if (this.Match_Exact != null)
            {
                context.Match_Exact = new List<System.String>(this.Match_Exact);
            }
            if (this.Acm_CertificateAuthorityArn != null)
            {
                context.Acm_CertificateAuthorityArn = new List<System.String>(this.Acm_CertificateAuthorityArn);
            }
            context.Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain = this.Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain;
            context.Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName = this.Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName;
            if (this.Spec_Backend != null)
            {
                context.Spec_Backend = new List<Amazon.AppMesh.Model.Backend>(this.Spec_Backend);
            }
            if (this.Spec_Listener != null)
            {
                context.Spec_Listener = new List<Amazon.AppMesh.Model.Listener>(this.Spec_Listener);
            }
            if (this.Format_Json != null)
            {
                context.Format_Json = new List<Amazon.AppMesh.Model.JsonFormatRef>(this.Format_Json);
            }
            context.Format_Text = this.Format_Text;
            context.File_Path = this.File_Path;
            if (this.AwsCloudMap_Attribute != null)
            {
                context.AwsCloudMap_Attribute = new List<Amazon.AppMesh.Model.AwsCloudMapInstanceAttribute>(this.AwsCloudMap_Attribute);
            }
            context.AwsCloudMap_IpPreference = this.AwsCloudMap_IpPreference;
            context.AwsCloudMap_NamespaceName = this.AwsCloudMap_NamespaceName;
            context.AwsCloudMap_ServiceName = this.AwsCloudMap_ServiceName;
            context.Dns_Hostname = this.Dns_Hostname;
            context.Dns_IpPreference = this.Dns_IpPreference;
            context.Dns_ResponseType = this.Dns_ResponseType;
            context.VirtualNodeName = this.VirtualNodeName;
            #if MODULAR
            if (this.VirtualNodeName == null && ParameterWasBound(nameof(this.VirtualNodeName)))
            {
                WriteWarning("You are passing $null as a value for parameter VirtualNodeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppMesh.Model.UpdateVirtualNodeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.MeshName != null)
            {
                request.MeshName = cmdletContext.MeshName;
            }
            if (cmdletContext.MeshOwner != null)
            {
                request.MeshOwner = cmdletContext.MeshOwner;
            }
            
             // populate Spec
            var requestSpecIsNull = true;
            request.Spec = new Amazon.AppMesh.Model.VirtualNodeSpec();
            List<Amazon.AppMesh.Model.Backend> requestSpec_spec_Backend = null;
            if (cmdletContext.Spec_Backend != null)
            {
                requestSpec_spec_Backend = cmdletContext.Spec_Backend;
            }
            if (requestSpec_spec_Backend != null)
            {
                request.Spec.Backends = requestSpec_spec_Backend;
                requestSpecIsNull = false;
            }
            List<Amazon.AppMesh.Model.Listener> requestSpec_spec_Listener = null;
            if (cmdletContext.Spec_Listener != null)
            {
                requestSpec_spec_Listener = cmdletContext.Spec_Listener;
            }
            if (requestSpec_spec_Listener != null)
            {
                request.Spec.Listeners = requestSpec_spec_Listener;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.BackendDefaults requestSpec_spec_BackendDefaults = null;
            
             // populate BackendDefaults
            var requestSpec_spec_BackendDefaultsIsNull = true;
            requestSpec_spec_BackendDefaults = new Amazon.AppMesh.Model.BackendDefaults();
            Amazon.AppMesh.Model.ClientPolicy requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy = null;
            
             // populate ClientPolicy
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicyIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy = new Amazon.AppMesh.Model.ClientPolicy();
            Amazon.AppMesh.Model.ClientPolicyTls requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls = null;
            
             // populate Tls
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_TlsIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls = new Amazon.AppMesh.Model.ClientPolicyTls();
            System.Boolean? requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_tls_Enforce = null;
            if (cmdletContext.Tls_Enforce != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_tls_Enforce = cmdletContext.Tls_Enforce.Value;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_tls_Enforce != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls.Enforce = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_tls_Enforce.Value;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_TlsIsNull = false;
            }
            List<System.Int32> requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_tls_Port = null;
            if (cmdletContext.Tls_Port != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_tls_Port = cmdletContext.Tls_Port;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_tls_Port != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls.Ports = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_tls_Port;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_TlsIsNull = false;
            }
            Amazon.AppMesh.Model.ClientTlsCertificate requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate = null;
            
             // populate Certificate
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_CertificateIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate = new Amazon.AppMesh.Model.ClientTlsCertificate();
            Amazon.AppMesh.Model.ListenerTlsSdsCertificate requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds = null;
            
             // populate Sds
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_SdsIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds = new Amazon.AppMesh.Model.ListenerTlsSdsCertificate();
            System.String requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName = null;
            if (cmdletContext.Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName = cmdletContext.Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds.SecretName = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_SdsIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_SdsIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate.Sds = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_CertificateIsNull = false;
            }
            Amazon.AppMesh.Model.ListenerTlsFileCertificate requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File = null;
            
             // populate File
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_FileIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File = new Amazon.AppMesh.Model.ListenerTlsFileCertificate();
            System.String requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain = null;
            if (cmdletContext.Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain = cmdletContext.Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File.CertificateChain = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_FileIsNull = false;
            }
            System.String requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_file_PrivateKey = null;
            if (cmdletContext.File_PrivateKey != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_file_PrivateKey = cmdletContext.File_PrivateKey;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_file_PrivateKey != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File.PrivateKey = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_file_PrivateKey;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_FileIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_FileIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate.File = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate_spec_BackendDefaults_ClientPolicy_Tls_Certificate_File;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_CertificateIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_CertificateIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls.Certificate = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Certificate;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_TlsIsNull = false;
            }
            Amazon.AppMesh.Model.TlsValidationContext requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation = null;
            
             // populate Validation
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_ValidationIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation = new Amazon.AppMesh.Model.TlsValidationContext();
            Amazon.AppMesh.Model.SubjectAlternativeNames requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames = null;
            
             // populate SubjectAlternativeNames
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNamesIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames = new Amazon.AppMesh.Model.SubjectAlternativeNames();
            Amazon.AppMesh.Model.SubjectAlternativeNameMatchers requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match = null;
            
             // populate Match
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_MatchIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match = new Amazon.AppMesh.Model.SubjectAlternativeNameMatchers();
            List<System.String> requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match_match_Exact = null;
            if (cmdletContext.Match_Exact != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match_match_Exact = cmdletContext.Match_Exact;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match_match_Exact != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match.Exact = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match_match_Exact;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_MatchIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_MatchIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames.Match = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames_Match;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNamesIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNamesIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation.SubjectAlternativeNames = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_SubjectAlternativeNames;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_ValidationIsNull = false;
            }
            Amazon.AppMesh.Model.TlsValidationContextTrust requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust = null;
            
             // populate Trust
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_TrustIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust = new Amazon.AppMesh.Model.TlsValidationContextTrust();
            Amazon.AppMesh.Model.TlsValidationContextAcmTrust requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm = null;
            
             // populate Acm
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_AcmIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm = new Amazon.AppMesh.Model.TlsValidationContextAcmTrust();
            List<System.String> requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm_acm_CertificateAuthorityArn = null;
            if (cmdletContext.Acm_CertificateAuthorityArn != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm_acm_CertificateAuthorityArn = cmdletContext.Acm_CertificateAuthorityArn;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm_acm_CertificateAuthorityArn != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm.CertificateAuthorityArns = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm_acm_CertificateAuthorityArn;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_AcmIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_AcmIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust.Acm = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Acm;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_TrustIsNull = false;
            }
            Amazon.AppMesh.Model.TlsValidationContextFileTrust requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File = null;
            
             // populate File
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_FileIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File = new Amazon.AppMesh.Model.TlsValidationContextFileTrust();
            System.String requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain = null;
            if (cmdletContext.Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain = cmdletContext.Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File.CertificateChain = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_FileIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_FileIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust.File = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_TrustIsNull = false;
            }
            Amazon.AppMesh.Model.TlsValidationContextSdsTrust requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds = null;
            
             // populate Sds
            var requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_SdsIsNull = true;
            requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds = new Amazon.AppMesh.Model.TlsValidationContextSdsTrust();
            System.String requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName = null;
            if (cmdletContext.Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName = cmdletContext.Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds.SecretName = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_SdsIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_SdsIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust.Sds = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_TrustIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_TrustIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation.Trust = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation_spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_ValidationIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_ValidationIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls.Validation = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls_spec_BackendDefaults_ClientPolicy_Tls_Validation;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_TlsIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_TlsIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls != null)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy.Tls = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy_spec_BackendDefaults_ClientPolicy_Tls;
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicyIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy should be set to null
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicyIsNull)
            {
                requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy = null;
            }
            if (requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy != null)
            {
                requestSpec_spec_BackendDefaults.ClientPolicy = requestSpec_spec_BackendDefaults_spec_BackendDefaults_ClientPolicy;
                requestSpec_spec_BackendDefaultsIsNull = false;
            }
             // determine if requestSpec_spec_BackendDefaults should be set to null
            if (requestSpec_spec_BackendDefaultsIsNull)
            {
                requestSpec_spec_BackendDefaults = null;
            }
            if (requestSpec_spec_BackendDefaults != null)
            {
                request.Spec.BackendDefaults = requestSpec_spec_BackendDefaults;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.Logging requestSpec_spec_Logging = null;
            
             // populate Logging
            var requestSpec_spec_LoggingIsNull = true;
            requestSpec_spec_Logging = new Amazon.AppMesh.Model.Logging();
            Amazon.AppMesh.Model.AccessLog requestSpec_spec_Logging_spec_Logging_AccessLog = null;
            
             // populate AccessLog
            var requestSpec_spec_Logging_spec_Logging_AccessLogIsNull = true;
            requestSpec_spec_Logging_spec_Logging_AccessLog = new Amazon.AppMesh.Model.AccessLog();
            Amazon.AppMesh.Model.FileAccessLog requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File = null;
            
             // populate File
            var requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_FileIsNull = true;
            requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File = new Amazon.AppMesh.Model.FileAccessLog();
            System.String requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path = null;
            if (cmdletContext.File_Path != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path = cmdletContext.File_Path;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File.Path = requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_file_Path;
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_FileIsNull = false;
            }
            Amazon.AppMesh.Model.LoggingFormat requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format = null;
            
             // populate Format
            var requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_FormatIsNull = true;
            requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format = new Amazon.AppMesh.Model.LoggingFormat();
            List<Amazon.AppMesh.Model.JsonFormatRef> requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format_format_Json = null;
            if (cmdletContext.Format_Json != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format_format_Json = cmdletContext.Format_Json;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format_format_Json != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format.Json = requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format_format_Json;
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_FormatIsNull = false;
            }
            System.String requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format_format_Text = null;
            if (cmdletContext.Format_Text != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format_format_Text = cmdletContext.Format_Text;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format_format_Text != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format.Text = requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format_format_Text;
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_FormatIsNull = false;
            }
             // determine if requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format should be set to null
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_FormatIsNull)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format = null;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File.Format = requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File_spec_Logging_AccessLog_File_Format;
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_FileIsNull = false;
            }
             // determine if requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File should be set to null
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_FileIsNull)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File = null;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File != null)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog.File = requestSpec_spec_Logging_spec_Logging_AccessLog_spec_Logging_AccessLog_File;
                requestSpec_spec_Logging_spec_Logging_AccessLogIsNull = false;
            }
             // determine if requestSpec_spec_Logging_spec_Logging_AccessLog should be set to null
            if (requestSpec_spec_Logging_spec_Logging_AccessLogIsNull)
            {
                requestSpec_spec_Logging_spec_Logging_AccessLog = null;
            }
            if (requestSpec_spec_Logging_spec_Logging_AccessLog != null)
            {
                requestSpec_spec_Logging.AccessLog = requestSpec_spec_Logging_spec_Logging_AccessLog;
                requestSpec_spec_LoggingIsNull = false;
            }
             // determine if requestSpec_spec_Logging should be set to null
            if (requestSpec_spec_LoggingIsNull)
            {
                requestSpec_spec_Logging = null;
            }
            if (requestSpec_spec_Logging != null)
            {
                request.Spec.Logging = requestSpec_spec_Logging;
                requestSpecIsNull = false;
            }
            Amazon.AppMesh.Model.ServiceDiscovery requestSpec_spec_ServiceDiscovery = null;
            
             // populate ServiceDiscovery
            var requestSpec_spec_ServiceDiscoveryIsNull = true;
            requestSpec_spec_ServiceDiscovery = new Amazon.AppMesh.Model.ServiceDiscovery();
            Amazon.AppMesh.Model.DnsServiceDiscovery requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns = null;
            
             // populate Dns
            var requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull = true;
            requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns = new Amazon.AppMesh.Model.DnsServiceDiscovery();
            System.String requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname = null;
            if (cmdletContext.Dns_Hostname != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname = cmdletContext.Dns_Hostname;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns.Hostname = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_Hostname;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull = false;
            }
            Amazon.AppMesh.IpPreference requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_IpPreference = null;
            if (cmdletContext.Dns_IpPreference != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_IpPreference = cmdletContext.Dns_IpPreference;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_IpPreference != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns.IpPreference = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_IpPreference;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull = false;
            }
            Amazon.AppMesh.DnsResponseType requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_ResponseType = null;
            if (cmdletContext.Dns_ResponseType != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_ResponseType = cmdletContext.Dns_ResponseType;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_ResponseType != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns.ResponseType = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns_dns_ResponseType;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull = false;
            }
             // determine if requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns should be set to null
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_DnsIsNull)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns = null;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns != null)
            {
                requestSpec_spec_ServiceDiscovery.Dns = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_Dns;
                requestSpec_spec_ServiceDiscoveryIsNull = false;
            }
            Amazon.AppMesh.Model.AwsCloudMapServiceDiscovery requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap = null;
            
             // populate AwsCloudMap
            var requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = true;
            requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap = new Amazon.AppMesh.Model.AwsCloudMapServiceDiscovery();
            List<Amazon.AppMesh.Model.AwsCloudMapInstanceAttribute> requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_Attribute = null;
            if (cmdletContext.AwsCloudMap_Attribute != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_Attribute = cmdletContext.AwsCloudMap_Attribute;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_Attribute != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap.Attributes = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_Attribute;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = false;
            }
            Amazon.AppMesh.IpPreference requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_IpPreference = null;
            if (cmdletContext.AwsCloudMap_IpPreference != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_IpPreference = cmdletContext.AwsCloudMap_IpPreference;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_IpPreference != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap.IpPreference = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_IpPreference;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = false;
            }
            System.String requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_NamespaceName = null;
            if (cmdletContext.AwsCloudMap_NamespaceName != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_NamespaceName = cmdletContext.AwsCloudMap_NamespaceName;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_NamespaceName != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap.NamespaceName = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_NamespaceName;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = false;
            }
            System.String requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_ServiceName = null;
            if (cmdletContext.AwsCloudMap_ServiceName != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_ServiceName = cmdletContext.AwsCloudMap_ServiceName;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_ServiceName != null)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap.ServiceName = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap_awsCloudMap_ServiceName;
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull = false;
            }
             // determine if requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap should be set to null
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMapIsNull)
            {
                requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap = null;
            }
            if (requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap != null)
            {
                requestSpec_spec_ServiceDiscovery.AwsCloudMap = requestSpec_spec_ServiceDiscovery_spec_ServiceDiscovery_AwsCloudMap;
                requestSpec_spec_ServiceDiscoveryIsNull = false;
            }
             // determine if requestSpec_spec_ServiceDiscovery should be set to null
            if (requestSpec_spec_ServiceDiscoveryIsNull)
            {
                requestSpec_spec_ServiceDiscovery = null;
            }
            if (requestSpec_spec_ServiceDiscovery != null)
            {
                request.Spec.ServiceDiscovery = requestSpec_spec_ServiceDiscovery;
                requestSpecIsNull = false;
            }
             // determine if request.Spec should be set to null
            if (requestSpecIsNull)
            {
                request.Spec = null;
            }
            if (cmdletContext.VirtualNodeName != null)
            {
                request.VirtualNodeName = cmdletContext.VirtualNodeName;
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
        
        private Amazon.AppMesh.Model.UpdateVirtualNodeResponse CallAWSServiceOperation(IAmazonAppMesh client, Amazon.AppMesh.Model.UpdateVirtualNodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS App Mesh", "UpdateVirtualNode");
            try
            {
                #if DESKTOP
                return client.UpdateVirtualNode(request);
                #elif CORECLR
                return client.UpdateVirtualNodeAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String MeshName { get; set; }
            public System.String MeshOwner { get; set; }
            public System.String Spec_BackendDefaults_ClientPolicy_Tls_Certificate_File_CertificateChain { get; set; }
            public System.String File_PrivateKey { get; set; }
            public System.String Spec_BackendDefaults_ClientPolicy_Tls_Certificate_Sds_SecretName { get; set; }
            public System.Boolean? Tls_Enforce { get; set; }
            public List<System.Int32> Tls_Port { get; set; }
            public List<System.String> Match_Exact { get; set; }
            public List<System.String> Acm_CertificateAuthorityArn { get; set; }
            public System.String Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_File_CertificateChain { get; set; }
            public System.String Spec_BackendDefaults_ClientPolicy_Tls_Validation_Trust_Sds_SecretName { get; set; }
            public List<Amazon.AppMesh.Model.Backend> Spec_Backend { get; set; }
            public List<Amazon.AppMesh.Model.Listener> Spec_Listener { get; set; }
            public List<Amazon.AppMesh.Model.JsonFormatRef> Format_Json { get; set; }
            public System.String Format_Text { get; set; }
            public System.String File_Path { get; set; }
            public List<Amazon.AppMesh.Model.AwsCloudMapInstanceAttribute> AwsCloudMap_Attribute { get; set; }
            public Amazon.AppMesh.IpPreference AwsCloudMap_IpPreference { get; set; }
            public System.String AwsCloudMap_NamespaceName { get; set; }
            public System.String AwsCloudMap_ServiceName { get; set; }
            public System.String Dns_Hostname { get; set; }
            public Amazon.AppMesh.IpPreference Dns_IpPreference { get; set; }
            public Amazon.AppMesh.DnsResponseType Dns_ResponseType { get; set; }
            public System.String VirtualNodeName { get; set; }
            public System.Func<Amazon.AppMesh.Model.UpdateVirtualNodeResponse, UpdateAMSHVirtualNodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.VirtualNode;
        }
        
    }
}
