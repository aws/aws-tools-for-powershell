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
    /// Updates the cluster's connectivity configuration.
    /// </summary>
    [Cmdlet("Update", "MSKConnectivity", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Kafka.Model.UpdateConnectivityResponse")]
    [AWSCmdlet("Calls the Amazon Managed Streaming for Apache Kafka (MSK) UpdateConnectivity API operation.", Operation = new[] {"UpdateConnectivity"}, SelectReturnType = typeof(Amazon.Kafka.Model.UpdateConnectivityResponse))]
    [AWSCmdletOutput("Amazon.Kafka.Model.UpdateConnectivityResponse",
        "This cmdlet returns an Amazon.Kafka.Model.UpdateConnectivityResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMSKConnectivityCmdlet : AmazonKafkaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the configuration.</para>
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
        
        #region Parameter Iam_Enabled
        /// <summary>
        /// <para>
        /// <para>SASL/IAM authentication is on or off for VPC connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam_Enabled")]
        public System.Boolean? Iam_Enabled { get; set; }
        #endregion
        
        #region Parameter Scram_Enabled
        /// <summary>
        /// <para>
        /// <para>SASL/SCRAM authentication is on or off for VPC connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram_Enabled")]
        public System.Boolean? Scram_Enabled { get; set; }
        #endregion
        
        #region Parameter Tls_Enabled
        /// <summary>
        /// <para>
        /// <para>TLS authentication is on or off for VPC connectivity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectivityInfo_VpcConnectivity_ClientAuthentication_Tls_Enabled")]
        public System.Boolean? Tls_Enabled { get; set; }
        #endregion
        
        #region Parameter PublicAccess_Type
        /// <summary>
        /// <para>
        /// <para>The value DISABLED indicates that public access is turned off. SERVICE_PROVIDED_EIPS
        /// indicates that public access is turned on.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConnectivityInfo_PublicAccess_Type")]
        public System.String PublicAccess_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kafka.Model.UpdateConnectivityResponse).
        /// Specifying the name of a property of type Amazon.Kafka.Model.UpdateConnectivityResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClusterArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MSKConnectivity (UpdateConnectivity)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kafka.Model.UpdateConnectivityResponse, UpdateMSKConnectivityCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PublicAccess_Type = this.PublicAccess_Type;
            context.Iam_Enabled = this.Iam_Enabled;
            context.Scram_Enabled = this.Scram_Enabled;
            context.Tls_Enabled = this.Tls_Enabled;
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kafka.Model.UpdateConnectivityRequest();
            
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
            }
            
             // populate ConnectivityInfo
            var requestConnectivityInfoIsNull = true;
            request.ConnectivityInfo = new Amazon.Kafka.Model.ConnectivityInfo();
            Amazon.Kafka.Model.PublicAccess requestConnectivityInfo_connectivityInfo_PublicAccess = null;
            
             // populate PublicAccess
            var requestConnectivityInfo_connectivityInfo_PublicAccessIsNull = true;
            requestConnectivityInfo_connectivityInfo_PublicAccess = new Amazon.Kafka.Model.PublicAccess();
            System.String requestConnectivityInfo_connectivityInfo_PublicAccess_publicAccess_Type = null;
            if (cmdletContext.PublicAccess_Type != null)
            {
                requestConnectivityInfo_connectivityInfo_PublicAccess_publicAccess_Type = cmdletContext.PublicAccess_Type;
            }
            if (requestConnectivityInfo_connectivityInfo_PublicAccess_publicAccess_Type != null)
            {
                requestConnectivityInfo_connectivityInfo_PublicAccess.Type = requestConnectivityInfo_connectivityInfo_PublicAccess_publicAccess_Type;
                requestConnectivityInfo_connectivityInfo_PublicAccessIsNull = false;
            }
             // determine if requestConnectivityInfo_connectivityInfo_PublicAccess should be set to null
            if (requestConnectivityInfo_connectivityInfo_PublicAccessIsNull)
            {
                requestConnectivityInfo_connectivityInfo_PublicAccess = null;
            }
            if (requestConnectivityInfo_connectivityInfo_PublicAccess != null)
            {
                request.ConnectivityInfo.PublicAccess = requestConnectivityInfo_connectivityInfo_PublicAccess;
                requestConnectivityInfoIsNull = false;
            }
            Amazon.Kafka.Model.VpcConnectivity requestConnectivityInfo_connectivityInfo_VpcConnectivity = null;
            
             // populate VpcConnectivity
            var requestConnectivityInfo_connectivityInfo_VpcConnectivityIsNull = true;
            requestConnectivityInfo_connectivityInfo_VpcConnectivity = new Amazon.Kafka.Model.VpcConnectivity();
            Amazon.Kafka.Model.VpcConnectivityClientAuthentication requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication = null;
            
             // populate ClientAuthentication
            var requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthenticationIsNull = true;
            requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication = new Amazon.Kafka.Model.VpcConnectivityClientAuthentication();
            Amazon.Kafka.Model.VpcConnectivityTls requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls = null;
            
             // populate Tls
            var requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_TlsIsNull = true;
            requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls = new Amazon.Kafka.Model.VpcConnectivityTls();
            System.Boolean? requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls_tls_Enabled = null;
            if (cmdletContext.Tls_Enabled != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls_tls_Enabled = cmdletContext.Tls_Enabled.Value;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls_tls_Enabled != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls.Enabled = requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls_tls_Enabled.Value;
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_TlsIsNull = false;
            }
             // determine if requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls should be set to null
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_TlsIsNull)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls = null;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication.Tls = requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Tls;
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthenticationIsNull = false;
            }
            Amazon.Kafka.Model.VpcConnectivitySasl requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl = null;
            
             // populate Sasl
            var requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_SaslIsNull = true;
            requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl = new Amazon.Kafka.Model.VpcConnectivitySasl();
            Amazon.Kafka.Model.VpcConnectivityIam requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam = null;
            
             // populate Iam
            var requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_IamIsNull = true;
            requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam = new Amazon.Kafka.Model.VpcConnectivityIam();
            System.Boolean? requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam_iam_Enabled = null;
            if (cmdletContext.Iam_Enabled != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam_iam_Enabled = cmdletContext.Iam_Enabled.Value;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam_iam_Enabled != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam.Enabled = requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam_iam_Enabled.Value;
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_IamIsNull = false;
            }
             // determine if requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam should be set to null
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_IamIsNull)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam = null;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl.Iam = requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Iam;
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_SaslIsNull = false;
            }
            Amazon.Kafka.Model.VpcConnectivityScram requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram = null;
            
             // populate Scram
            var requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_ScramIsNull = true;
            requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram = new Amazon.Kafka.Model.VpcConnectivityScram();
            System.Boolean? requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram_scram_Enabled = null;
            if (cmdletContext.Scram_Enabled != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram_scram_Enabled = cmdletContext.Scram_Enabled.Value;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram_scram_Enabled != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram.Enabled = requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram_scram_Enabled.Value;
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_ScramIsNull = false;
            }
             // determine if requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram should be set to null
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_ScramIsNull)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram = null;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl.Scram = requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl_Scram;
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_SaslIsNull = false;
            }
             // determine if requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl should be set to null
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_SaslIsNull)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl = null;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication.Sasl = requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication_connectivityInfo_VpcConnectivity_ClientAuthentication_Sasl;
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthenticationIsNull = false;
            }
             // determine if requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication should be set to null
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthenticationIsNull)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication = null;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication != null)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity.ClientAuthentication = requestConnectivityInfo_connectivityInfo_VpcConnectivity_connectivityInfo_VpcConnectivity_ClientAuthentication;
                requestConnectivityInfo_connectivityInfo_VpcConnectivityIsNull = false;
            }
             // determine if requestConnectivityInfo_connectivityInfo_VpcConnectivity should be set to null
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivityIsNull)
            {
                requestConnectivityInfo_connectivityInfo_VpcConnectivity = null;
            }
            if (requestConnectivityInfo_connectivityInfo_VpcConnectivity != null)
            {
                request.ConnectivityInfo.VpcConnectivity = requestConnectivityInfo_connectivityInfo_VpcConnectivity;
                requestConnectivityInfoIsNull = false;
            }
             // determine if request.ConnectivityInfo should be set to null
            if (requestConnectivityInfoIsNull)
            {
                request.ConnectivityInfo = null;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
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
        
        private Amazon.Kafka.Model.UpdateConnectivityResponse CallAWSServiceOperation(IAmazonKafka client, Amazon.Kafka.Model.UpdateConnectivityRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Managed Streaming for Apache Kafka (MSK)", "UpdateConnectivity");
            try
            {
                #if DESKTOP
                return client.UpdateConnectivity(request);
                #elif CORECLR
                return client.UpdateConnectivityAsync(request).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public System.String PublicAccess_Type { get; set; }
            public System.Boolean? Iam_Enabled { get; set; }
            public System.Boolean? Scram_Enabled { get; set; }
            public System.Boolean? Tls_Enabled { get; set; }
            public System.String CurrentVersion { get; set; }
            public System.Func<Amazon.Kafka.Model.UpdateConnectivityResponse, UpdateMSKConnectivityCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
