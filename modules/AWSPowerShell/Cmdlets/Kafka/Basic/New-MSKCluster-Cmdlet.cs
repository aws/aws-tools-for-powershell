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
using Amazon.Kafka;
using Amazon.Kafka.Model;

namespace Amazon.PowerShell.Cmdlets.MSK
{
    /// <summary>
    /// Creates a new MSK cluster.
    /// </summary>
    [Cmdlet("New", "MSKCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.CreateClusterResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) CreateCluster API operation.", Operation = new[] {"CreateCluster"}, SelectReturnType = typeof(Amazon.Kafka.Model.CreateClusterResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.CreateClusterResponse",
        "This cmdlet returns an Amazon.Kafka.Model.CreateClusterResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewMSKClusterCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigurationInfo_Arn
        /// <summary>
        /// <para>
        /// <para>ARN of the configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConfigurationInfo_Arn { get; set; }
        #endregion
        
        #region Parameter BrokerNodeGroupInfo
        /// <summary>
        /// <para>
        /// <para>Information about the broker nodes in the cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Kafka.Model.BrokerNodeGroupInfo BrokerNodeGroupInfo { get; set; }
        #endregion
        
        #region Parameter Tls_CertificateAuthorityArnList
        /// <summary>
        /// <para>
        /// <para>List of ACM Certificate Authority ARNs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Tls_CertificateAuthorityArnList")]
        public System.String[] Tls_CertificateAuthorityArnList { get; set; }
        #endregion
        
        #region Parameter EncryptionInTransit_ClientBroker
        /// <summary>
        /// <para>
        /// <para>Indicates the encryption setting for data in transit between clients and brokers.
        /// The following are the possible values.</para><para>               TLS means that client-broker communication is enabled with TLS only.</para><para>               TLS_PLAINTEXT means that client-broker communication is enabled for
        /// both TLS-encrypted, as well as plaintext data.</para><para>               PLAINTEXT means that client-broker communication is enabled in plaintext
        /// only.</para><para>The default value is TLS_PLAINTEXT.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionInfo_EncryptionInTransit_ClientBroker")]
        [AWSConstantClassSource("Amazon.Kafka.ClientBroker")]
        public Amazon.Kafka.ClientBroker EncryptionInTransit_ClientBroker { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The name of the cluster.</para>
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
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter EncryptionAtRest_DataVolumeKMSKeyId
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS KMS key for encrypting data at rest. If you don't specify a KMS
        /// key, MSK creates one for you and uses it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionInfo_EncryptionAtRest_DataVolumeKMSKeyId")]
        public System.String EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
        #endregion
        
        #region Parameter EnhancedMonitoring
        /// <summary>
        /// <para>
        /// <para>Specifies the level of monitoring for the MSK cluster. The possible values are DEFAULT,
        /// PER_BROKER, and PER_TOPIC_PER_BROKER.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Kafka.EnhancedMonitoring")]
        public Amazon.Kafka.EnhancedMonitoring EnhancedMonitoring { get; set; }
        #endregion
        
        #region Parameter EncryptionInTransit_InCluster
        /// <summary>
        /// <para>
        /// <para>When set to true, it indicates that data communication among the broker nodes of the
        /// cluster is encrypted. When set to false, the communication happens in plaintext.</para><para>The default value is true.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EncryptionInfo_EncryptionInTransit_InCluster")]
        public System.Boolean? EncryptionInTransit_InCluster { get; set; }
        #endregion
        
        #region Parameter KafkaVersion
        /// <summary>
        /// <para>
        /// <para>The version of Apache Kafka.</para>
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
        public System.String KafkaVersion { get; set; }
        #endregion
        
        #region Parameter NumberOfBrokerNode
        /// <summary>
        /// <para>
        /// <para>The number of broker nodes in the cluster.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("NumberOfBrokerNodes")]
        public System.Int32? NumberOfBrokerNode { get; set; }
        #endregion
        
        #region Parameter ConfigurationInfo_Revision
        /// <summary>
        /// <para>
        /// <para>The revision of the configuration to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ConfigurationInfo_Revision { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Create tags when creating the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.CreateClusterResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.CreateClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterName' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MSKCluster (CreateCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.CreateClusterResponse, NewMSKClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BrokerNodeGroupInfo = this.BrokerNodeGroupInfo;
            #if MODULAR
            if (this.BrokerNodeGroupInfo == null && ParameterWasBound(nameof(this.BrokerNodeGroupInfo)))
            {
                WriteWarning("You are passing $null as a value for parameter BrokerNodeGroupInfo which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tls_CertificateAuthorityArnList != null)
            {
                context.Tls_CertificateAuthorityArnList = new List<System.String>(this.Tls_CertificateAuthorityArnList);
            }
            context.ClusterName = this.ClusterName;
            #if MODULAR
            if (this.ClusterName == null && ParameterWasBound(nameof(this.ClusterName)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationInfo_Arn = this.ConfigurationInfo_Arn;
            context.ConfigurationInfo_Revision = this.ConfigurationInfo_Revision;
            context.EncryptionAtRest_DataVolumeKMSKeyId = this.EncryptionAtRest_DataVolumeKMSKeyId;
            context.EncryptionInTransit_ClientBroker = this.EncryptionInTransit_ClientBroker;
            context.EncryptionInTransit_InCluster = this.EncryptionInTransit_InCluster;
            context.EnhancedMonitoring = this.EnhancedMonitoring;
            context.KafkaVersion = this.KafkaVersion;
            #if MODULAR
            if (this.KafkaVersion == null && ParameterWasBound(nameof(this.KafkaVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter KafkaVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NumberOfBrokerNode = this.NumberOfBrokerNode;
            #if MODULAR
            if (this.NumberOfBrokerNode == null && ParameterWasBound(nameof(this.NumberOfBrokerNode)))
            {
                WriteWarning("You are passing $null as a value for parameter NumberOfBrokerNode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kafka.Model.CreateClusterRequest();
            
            if (cmdletContext.BrokerNodeGroupInfo != null)
            {
                request.BrokerNodeGroupInfo = cmdletContext.BrokerNodeGroupInfo;
            }
            
             // populate ClientAuthentication
            var requestClientAuthenticationIsNull = true;
            request.ClientAuthentication = new Amazon.Kafka.Model.ClientAuthentication();
            Amazon.Kafka.Model.Tls requestClientAuthentication_clientAuthentication_Tls = null;
            
             // populate Tls
            var requestClientAuthentication_clientAuthentication_TlsIsNull = true;
            requestClientAuthentication_clientAuthentication_Tls = new Amazon.Kafka.Model.Tls();
            List<System.String> requestClientAuthentication_clientAuthentication_Tls_tls_CertificateAuthorityArnList = null;
            if (cmdletContext.Tls_CertificateAuthorityArnList != null)
            {
                requestClientAuthentication_clientAuthentication_Tls_tls_CertificateAuthorityArnList = cmdletContext.Tls_CertificateAuthorityArnList;
            }
            if (requestClientAuthentication_clientAuthentication_Tls_tls_CertificateAuthorityArnList != null)
            {
                requestClientAuthentication_clientAuthentication_Tls.CertificateAuthorityArnList = requestClientAuthentication_clientAuthentication_Tls_tls_CertificateAuthorityArnList;
                requestClientAuthentication_clientAuthentication_TlsIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Tls should be set to null
            if (requestClientAuthentication_clientAuthentication_TlsIsNull)
            {
                requestClientAuthentication_clientAuthentication_Tls = null;
            }
            if (requestClientAuthentication_clientAuthentication_Tls != null)
            {
                request.ClientAuthentication.Tls = requestClientAuthentication_clientAuthentication_Tls;
                requestClientAuthenticationIsNull = false;
            }
             // determine if request.ClientAuthentication should be set to null
            if (requestClientAuthenticationIsNull)
            {
                request.ClientAuthentication = null;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            
             // populate ConfigurationInfo
            var requestConfigurationInfoIsNull = true;
            request.ConfigurationInfo = new Amazon.Kafka.Model.ConfigurationInfo();
            System.String requestConfigurationInfo_configurationInfo_Arn = null;
            if (cmdletContext.ConfigurationInfo_Arn != null)
            {
                requestConfigurationInfo_configurationInfo_Arn = cmdletContext.ConfigurationInfo_Arn;
            }
            if (requestConfigurationInfo_configurationInfo_Arn != null)
            {
                request.ConfigurationInfo.Arn = requestConfigurationInfo_configurationInfo_Arn;
                requestConfigurationInfoIsNull = false;
            }
            System.Int64? requestConfigurationInfo_configurationInfo_Revision = null;
            if (cmdletContext.ConfigurationInfo_Revision != null)
            {
                requestConfigurationInfo_configurationInfo_Revision = cmdletContext.ConfigurationInfo_Revision.Value;
            }
            if (requestConfigurationInfo_configurationInfo_Revision != null)
            {
                request.ConfigurationInfo.Revision = requestConfigurationInfo_configurationInfo_Revision.Value;
                requestConfigurationInfoIsNull = false;
            }
             // determine if request.ConfigurationInfo should be set to null
            if (requestConfigurationInfoIsNull)
            {
                request.ConfigurationInfo = null;
            }
            
             // populate EncryptionInfo
            var requestEncryptionInfoIsNull = true;
            request.EncryptionInfo = new Amazon.Kafka.Model.EncryptionInfo();
            Amazon.Kafka.Model.EncryptionAtRest requestEncryptionInfo_encryptionInfo_EncryptionAtRest = null;
            
             // populate EncryptionAtRest
            var requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull = true;
            requestEncryptionInfo_encryptionInfo_EncryptionAtRest = new Amazon.Kafka.Model.EncryptionAtRest();
            System.String requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId = null;
            if (cmdletContext.EncryptionAtRest_DataVolumeKMSKeyId != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId = cmdletContext.EncryptionAtRest_DataVolumeKMSKeyId;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest.DataVolumeKMSKeyId = requestEncryptionInfo_encryptionInfo_EncryptionAtRest_encryptionAtRest_DataVolumeKMSKeyId;
                requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull = false;
            }
             // determine if requestEncryptionInfo_encryptionInfo_EncryptionAtRest should be set to null
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRestIsNull)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionAtRest = null;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionAtRest != null)
            {
                request.EncryptionInfo.EncryptionAtRest = requestEncryptionInfo_encryptionInfo_EncryptionAtRest;
                requestEncryptionInfoIsNull = false;
            }
            Amazon.Kafka.Model.EncryptionInTransit requestEncryptionInfo_encryptionInfo_EncryptionInTransit = null;
            
             // populate EncryptionInTransit
            var requestEncryptionInfo_encryptionInfo_EncryptionInTransitIsNull = true;
            requestEncryptionInfo_encryptionInfo_EncryptionInTransit = new Amazon.Kafka.Model.EncryptionInTransit();
            Amazon.Kafka.ClientBroker requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker = null;
            if (cmdletContext.EncryptionInTransit_ClientBroker != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker = cmdletContext.EncryptionInTransit_ClientBroker;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit.ClientBroker = requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_ClientBroker;
                requestEncryptionInfo_encryptionInfo_EncryptionInTransitIsNull = false;
            }
            System.Boolean? requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster = null;
            if (cmdletContext.EncryptionInTransit_InCluster != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster = cmdletContext.EncryptionInTransit_InCluster.Value;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster != null)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit.InCluster = requestEncryptionInfo_encryptionInfo_EncryptionInTransit_encryptionInTransit_InCluster.Value;
                requestEncryptionInfo_encryptionInfo_EncryptionInTransitIsNull = false;
            }
             // determine if requestEncryptionInfo_encryptionInfo_EncryptionInTransit should be set to null
            if (requestEncryptionInfo_encryptionInfo_EncryptionInTransitIsNull)
            {
                requestEncryptionInfo_encryptionInfo_EncryptionInTransit = null;
            }
            if (requestEncryptionInfo_encryptionInfo_EncryptionInTransit != null)
            {
                request.EncryptionInfo.EncryptionInTransit = requestEncryptionInfo_encryptionInfo_EncryptionInTransit;
                requestEncryptionInfoIsNull = false;
            }
             // determine if request.EncryptionInfo should be set to null
            if (requestEncryptionInfoIsNull)
            {
                request.EncryptionInfo = null;
            }
            if (cmdletContext.EnhancedMonitoring != null)
            {
                request.EnhancedMonitoring = cmdletContext.EnhancedMonitoring;
            }
            if (cmdletContext.KafkaVersion != null)
            {
                request.KafkaVersion = cmdletContext.KafkaVersion;
            }
            if (cmdletContext.NumberOfBrokerNode != null)
            {
                request.NumberOfBrokerNodes = cmdletContext.NumberOfBrokerNode.Value;
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
        
        private Amazon.Kafka.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "CreateCluster");
            try
            {
                #if DESKTOP
                return client.CreateCluster(request);
                #elif CORECLR
                return client.CreateClusterAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Kafka.Model.BrokerNodeGroupInfo BrokerNodeGroupInfo { get; set; }
            public List<System.String> Tls_CertificateAuthorityArnList { get; set; }
            public System.String ClusterName { get; set; }
            public System.String ConfigurationInfo_Arn { get; set; }
            public System.Int64? ConfigurationInfo_Revision { get; set; }
            public System.String EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
            public Amazon.Kafka.ClientBroker EncryptionInTransit_ClientBroker { get; set; }
            public System.Boolean? EncryptionInTransit_InCluster { get; set; }
            public Amazon.Kafka.EnhancedMonitoring EnhancedMonitoring { get; set; }
            public System.String KafkaVersion { get; set; }
            public System.Int32? NumberOfBrokerNode { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Kafka.Model.CreateClusterResponse, NewMSKClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
