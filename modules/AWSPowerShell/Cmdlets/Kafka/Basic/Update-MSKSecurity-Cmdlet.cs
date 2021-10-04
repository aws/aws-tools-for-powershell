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
    /// Updates the security settings for the cluster. You can use this operation to specify
    /// encryption and authentication on existing clusters.
    /// </summary>
    [Cmdlet("Update", "MSKSecurity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.UpdateSecurityResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) UpdateSecurity API operation.", Operation = new[] {"UpdateSecurity"}, SelectReturnType = typeof(Amazon.Kafka.Model.UpdateSecurityResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.UpdateSecurityResponse",
        "This cmdlet returns an Amazon.Kafka.Model.UpdateSecurityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMSKSecurityCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
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
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies the cluster.</para>
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
        public System.String ClusterArn { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>The version of the MSK cluster to update. Cluster versions aren't simple numbers.
        /// You can describe an MSK cluster to find its version. When this update operation is
        /// successful, it generates a new cluster version.</para>
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
        public System.String CurrentVersion { get; set; }
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
        
        #region Parameter Iam_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether IAM access control is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Sasl_Iam_Enabled")]
        public System.Boolean? Iam_Enabled { get; set; }
        #endregion
        
        #region Parameter Scram_Enabled
        /// <summary>
        /// <para>
        /// <para>SASL/SCRAM authentication is enabled or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Sasl_Scram_Enabled")]
        public System.Boolean? Scram_Enabled { get; set; }
        #endregion
        
        #region Parameter Tls_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to turn on or turn off TLS authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Tls_Enabled")]
        public System.Boolean? Tls_Enabled { get; set; }
        #endregion
        
        #region Parameter Unauthenticated_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether you want to turn on or turn off unauthenticated traffic to your
        /// cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ClientAuthentication_Unauthenticated_Enabled")]
        public System.Boolean? Unauthenticated_Enabled { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.UpdateSecurityResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.UpdateSecurityResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClusterArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClusterArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MSKSecurity (UpdateSecurity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.UpdateSecurityResponse, UpdateMSKSecurityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClusterArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Iam_Enabled = this.Iam_Enabled;
            context.Scram_Enabled = this.Scram_Enabled;
            if (this.Tls_CertificateAuthorityArnList != null)
            {
                context.Tls_CertificateAuthorityArnList = new List<System.String>(this.Tls_CertificateAuthorityArnList);
            }
            context.Tls_Enabled = this.Tls_Enabled;
            context.Unauthenticated_Enabled = this.Unauthenticated_Enabled;
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EncryptionAtRest_DataVolumeKMSKeyId = this.EncryptionAtRest_DataVolumeKMSKeyId;
            context.EncryptionInTransit_ClientBroker = this.EncryptionInTransit_ClientBroker;
            context.EncryptionInTransit_InCluster = this.EncryptionInTransit_InCluster;
            
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
            var request = new Amazon.Kafka.Model.UpdateSecurityRequest();
            
            
             // populate ClientAuthentication
            var requestClientAuthenticationIsNull = true;
            request.ClientAuthentication = new Amazon.Kafka.Model.ClientAuthentication();
            Amazon.Kafka.Model.Unauthenticated requestClientAuthentication_clientAuthentication_Unauthenticated = null;
            
             // populate Unauthenticated
            var requestClientAuthentication_clientAuthentication_UnauthenticatedIsNull = true;
            requestClientAuthentication_clientAuthentication_Unauthenticated = new Amazon.Kafka.Model.Unauthenticated();
            System.Boolean? requestClientAuthentication_clientAuthentication_Unauthenticated_unauthenticated_Enabled = null;
            if (cmdletContext.Unauthenticated_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Unauthenticated_unauthenticated_Enabled = cmdletContext.Unauthenticated_Enabled.Value;
            }
            if (requestClientAuthentication_clientAuthentication_Unauthenticated_unauthenticated_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Unauthenticated.Enabled = requestClientAuthentication_clientAuthentication_Unauthenticated_unauthenticated_Enabled.Value;
                requestClientAuthentication_clientAuthentication_UnauthenticatedIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Unauthenticated should be set to null
            if (requestClientAuthentication_clientAuthentication_UnauthenticatedIsNull)
            {
                requestClientAuthentication_clientAuthentication_Unauthenticated = null;
            }
            if (requestClientAuthentication_clientAuthentication_Unauthenticated != null)
            {
                request.ClientAuthentication.Unauthenticated = requestClientAuthentication_clientAuthentication_Unauthenticated;
                requestClientAuthenticationIsNull = false;
            }
            Amazon.Kafka.Model.Sasl requestClientAuthentication_clientAuthentication_Sasl = null;
            
             // populate Sasl
            var requestClientAuthentication_clientAuthentication_SaslIsNull = true;
            requestClientAuthentication_clientAuthentication_Sasl = new Amazon.Kafka.Model.Sasl();
            Amazon.Kafka.Model.Iam requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam = null;
            
             // populate Iam
            var requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_IamIsNull = true;
            requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam = new Amazon.Kafka.Model.Iam();
            System.Boolean? requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam_iam_Enabled = null;
            if (cmdletContext.Iam_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam_iam_Enabled = cmdletContext.Iam_Enabled.Value;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam_iam_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam.Enabled = requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam_iam_Enabled.Value;
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_IamIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam should be set to null
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_IamIsNull)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam = null;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl.Iam = requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Iam;
                requestClientAuthentication_clientAuthentication_SaslIsNull = false;
            }
            Amazon.Kafka.Model.Scram requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram = null;
            
             // populate Scram
            var requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_ScramIsNull = true;
            requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram = new Amazon.Kafka.Model.Scram();
            System.Boolean? requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram_scram_Enabled = null;
            if (cmdletContext.Scram_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram_scram_Enabled = cmdletContext.Scram_Enabled.Value;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram_scram_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram.Enabled = requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram_scram_Enabled.Value;
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_ScramIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram should be set to null
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_ScramIsNull)
            {
                requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram = null;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram != null)
            {
                requestClientAuthentication_clientAuthentication_Sasl.Scram = requestClientAuthentication_clientAuthentication_Sasl_clientAuthentication_Sasl_Scram;
                requestClientAuthentication_clientAuthentication_SaslIsNull = false;
            }
             // determine if requestClientAuthentication_clientAuthentication_Sasl should be set to null
            if (requestClientAuthentication_clientAuthentication_SaslIsNull)
            {
                requestClientAuthentication_clientAuthentication_Sasl = null;
            }
            if (requestClientAuthentication_clientAuthentication_Sasl != null)
            {
                request.ClientAuthentication.Sasl = requestClientAuthentication_clientAuthentication_Sasl;
                requestClientAuthenticationIsNull = false;
            }
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
            System.Boolean? requestClientAuthentication_clientAuthentication_Tls_tls_Enabled = null;
            if (cmdletContext.Tls_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Tls_tls_Enabled = cmdletContext.Tls_Enabled.Value;
            }
            if (requestClientAuthentication_clientAuthentication_Tls_tls_Enabled != null)
            {
                requestClientAuthentication_clientAuthentication_Tls.Enabled = requestClientAuthentication_clientAuthentication_Tls_tls_Enabled.Value;
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
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
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
        
        private Amazon.Kafka.Model.UpdateSecurityResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.UpdateSecurityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "UpdateSecurity");
            try
            {
                #if DESKTOP
                return client.UpdateSecurity(request);
                #elif CORECLR
                return client.UpdateSecurityAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Iam_Enabled { get; set; }
            public System.Boolean? Scram_Enabled { get; set; }
            public List<System.String> Tls_CertificateAuthorityArnList { get; set; }
            public System.Boolean? Tls_Enabled { get; set; }
            public System.Boolean? Unauthenticated_Enabled { get; set; }
            public System.String ClusterArn { get; set; }
            public System.String CurrentVersion { get; set; }
            public System.String EncryptionAtRest_DataVolumeKMSKeyId { get; set; }
            public Amazon.Kafka.ClientBroker EncryptionInTransit_ClientBroker { get; set; }
            public System.Boolean? EncryptionInTransit_InCluster { get; set; }
            public System.Func<Amazon.Kafka.Model.UpdateSecurityResponse, UpdateMSKSecurityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
