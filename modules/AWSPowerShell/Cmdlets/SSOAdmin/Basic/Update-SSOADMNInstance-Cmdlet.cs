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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Update the details for the instance of IAM Identity Center that is owned by the Amazon
    /// Web Services account.
    /// 
    ///  
    /// <para>
    /// In a single <c>UpdateInstance</c> request, you can perform only one of the following
    /// operations:
    /// </para><ul><li><para>
    /// Update the encryption configuration of the instance by specifying <c>EncryptionConfiguration</c>.
    /// </para></li><li><para>
    /// Enable permission sets for the instance by specifying <c>PermissionSetsEnabled</c>.
    /// </para></li><li><para>
    /// Update the network configuration of the instance by specifying <c>NetworkConfiguration</c>.
    /// </para></li></ul><para>
    /// A request that specifies more than one of <c>EncryptionConfiguration</c>, <c>PermissionSetsEnabled</c>,
    /// and <c>NetworkConfiguration</c> returns a <c>ValidationException</c>. To perform more
    /// than one of these operations, call <c>UpdateInstance</c> separately for each. The
    /// calls can be made in parallel.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SSOADMNInstance", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin UpdateInstance API operation.", Operation = new[] {"UpdateInstance"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.UpdateInstanceResponse))]
    [AWSCmdletOutput("None or Amazon.SSOAdmin.Model.UpdateInstanceResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSOAdmin.Model.UpdateInstanceResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSOADMNInstanceCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NetworkConfiguration_AllowSourceIp
        /// <summary>
        /// <para>
        /// <para>Allows access from the IPv4 or IPv6 CIDR blocks that you specify, in addition to the
        /// VPCs allowed by <c>RestrictSourceVpcs</c>. If you don't specify this value, no additional
        /// IP address ranges are allowed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AllowSourceIps")]
        public System.String[] NetworkConfiguration_AllowSourceIp { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_ExcludeApplicationArn
        /// <summary>
        /// <para>
        /// <para>Exempts the applications that you specify from the network access control, so that
        /// access to them is unchanged. You can specify both Amazon Web Services managed applications
        /// and customer managed applications, and you can use wildcards. These applications are
        /// not restricted by <c>RestrictSourceVpcs</c> or <c>AllowSourceIps</c>. If you don't
        /// specify this value, the controls apply to all applications.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_ExcludeApplicationArns")]
        public System.String[] NetworkConfiguration_ExcludeApplicationArn { get; set; }
        #endregion
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the instance of IAM Identity Center under which the operation will run.
        /// For more information about ARNs, see <a href="/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a> in the <i>Amazon
        /// Web Services General Reference</i>.</para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KeyType
        /// <summary>
        /// <para>
        /// <para>The type of KMS key used for encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SSOAdmin.KmsKeyType")]
        public Amazon.SSOAdmin.KmsKeyType EncryptionConfiguration_KeyType { get; set; }
        #endregion
        
        #region Parameter EncryptionConfiguration_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key used to encrypt data. Required when KeyType is CUSTOMER_MANAGED_KEY.
        /// Cannot be specified when KeyType is AWS_OWNED_KMS_KEY.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Updates the instance name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PermissionSetsEnabled
        /// <summary>
        /// <para>
        /// <para>Enables permission sets for this Identity Center instance. The only accepted value
        /// is <c>true </c>. After permission sets are enabled, they cannot be disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PermissionSetsEnabled { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_RestrictSourceVpc
        /// <summary>
        /// <para>
        /// <para>Limits access to the VPC endpoints in the VPCs that you specify. These VPCs must be
        /// in your organization, or in the Amazon Web Services account for an account instance.
        /// If you don't specify this value, access is allowed from any VPC in your organization
        /// or Amazon Web Services account.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_RestrictSourceVpcs")]
        public System.String[] NetworkConfiguration_RestrictSourceVpc { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_VpceAccessRequired
        /// <summary>
        /// <para>
        /// <para>Specifies whether access to your Identity Center instance and to applications must
        /// originate from a VPC endpoint. When this value is <c>true</c> and no other field is
        /// specified, access is allowed from any VPC in your organization, or from any VPC in
        /// the Amazon Web Services account for an account instance, and applies to all applications.
        /// When this value is <c>false</c>, no network access control is enforced and the values
        /// of <c>RestrictSourceVpcs</c>, <c>AllowSourceIps</c>, and <c>ExcludeApplicationArns</c>
        /// are cleared.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NetworkConfiguration_VpceAccessRequired { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.UpdateInstanceResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSOADMNInstance (UpdateInstance)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.UpdateInstanceResponse, UpdateSSOADMNInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EncryptionConfiguration_KeyType = this.EncryptionConfiguration_KeyType;
            context.EncryptionConfiguration_KmsKeyArn = this.EncryptionConfiguration_KmsKeyArn;
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            if (this.NetworkConfiguration_AllowSourceIp != null)
            {
                context.NetworkConfiguration_AllowSourceIp = new List<System.String>(this.NetworkConfiguration_AllowSourceIp);
            }
            if (this.NetworkConfiguration_ExcludeApplicationArn != null)
            {
                context.NetworkConfiguration_ExcludeApplicationArn = new List<System.String>(this.NetworkConfiguration_ExcludeApplicationArn);
            }
            if (this.NetworkConfiguration_RestrictSourceVpc != null)
            {
                context.NetworkConfiguration_RestrictSourceVpc = new List<System.String>(this.NetworkConfiguration_RestrictSourceVpc);
            }
            context.NetworkConfiguration_VpceAccessRequired = this.NetworkConfiguration_VpceAccessRequired;
            context.PermissionSetsEnabled = this.PermissionSetsEnabled;
            
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
            var request = new Amazon.SSOAdmin.Model.UpdateInstanceRequest();
            
            
             // populate EncryptionConfiguration
            var requestEncryptionConfigurationIsNull = true;
            request.EncryptionConfiguration = new Amazon.SSOAdmin.Model.EncryptionConfiguration();
            Amazon.SSOAdmin.KmsKeyType requestEncryptionConfiguration_encryptionConfiguration_KeyType = null;
            if (cmdletContext.EncryptionConfiguration_KeyType != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KeyType = cmdletContext.EncryptionConfiguration_KeyType;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KeyType != null)
            {
                request.EncryptionConfiguration.KeyType = requestEncryptionConfiguration_encryptionConfiguration_KeyType;
                requestEncryptionConfigurationIsNull = false;
            }
            System.String requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = null;
            if (cmdletContext.EncryptionConfiguration_KmsKeyArn != null)
            {
                requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn = cmdletContext.EncryptionConfiguration_KmsKeyArn;
            }
            if (requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn != null)
            {
                request.EncryptionConfiguration.KmsKeyArn = requestEncryptionConfiguration_encryptionConfiguration_KmsKeyArn;
                requestEncryptionConfigurationIsNull = false;
            }
             // determine if request.EncryptionConfiguration should be set to null
            if (requestEncryptionConfigurationIsNull)
            {
                request.EncryptionConfiguration = null;
            }
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.SSOAdmin.Model.NetworkConfigurationInfo();
            List<System.String> requestNetworkConfiguration_networkConfiguration_AllowSourceIp = null;
            if (cmdletContext.NetworkConfiguration_AllowSourceIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_AllowSourceIp = cmdletContext.NetworkConfiguration_AllowSourceIp;
            }
            if (requestNetworkConfiguration_networkConfiguration_AllowSourceIp != null)
            {
                request.NetworkConfiguration.AllowSourceIps = requestNetworkConfiguration_networkConfiguration_AllowSourceIp;
                requestNetworkConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_ExcludeApplicationArn = null;
            if (cmdletContext.NetworkConfiguration_ExcludeApplicationArn != null)
            {
                requestNetworkConfiguration_networkConfiguration_ExcludeApplicationArn = cmdletContext.NetworkConfiguration_ExcludeApplicationArn;
            }
            if (requestNetworkConfiguration_networkConfiguration_ExcludeApplicationArn != null)
            {
                request.NetworkConfiguration.ExcludeApplicationArns = requestNetworkConfiguration_networkConfiguration_ExcludeApplicationArn;
                requestNetworkConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_RestrictSourceVpc = null;
            if (cmdletContext.NetworkConfiguration_RestrictSourceVpc != null)
            {
                requestNetworkConfiguration_networkConfiguration_RestrictSourceVpc = cmdletContext.NetworkConfiguration_RestrictSourceVpc;
            }
            if (requestNetworkConfiguration_networkConfiguration_RestrictSourceVpc != null)
            {
                request.NetworkConfiguration.RestrictSourceVpcs = requestNetworkConfiguration_networkConfiguration_RestrictSourceVpc;
                requestNetworkConfigurationIsNull = false;
            }
            System.Boolean? requestNetworkConfiguration_networkConfiguration_VpceAccessRequired = null;
            if (cmdletContext.NetworkConfiguration_VpceAccessRequired != null)
            {
                requestNetworkConfiguration_networkConfiguration_VpceAccessRequired = cmdletContext.NetworkConfiguration_VpceAccessRequired.Value;
            }
            if (requestNetworkConfiguration_networkConfiguration_VpceAccessRequired != null)
            {
                request.NetworkConfiguration.VpceAccessRequired = requestNetworkConfiguration_networkConfiguration_VpceAccessRequired.Value;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            if (cmdletContext.PermissionSetsEnabled != null)
            {
                request.PermissionSetsEnabled = cmdletContext.PermissionSetsEnabled.Value;
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
        
        private Amazon.SSOAdmin.Model.UpdateInstanceResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.UpdateInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "UpdateInstance");
            try
            {
                return client.UpdateInstanceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.SSOAdmin.KmsKeyType EncryptionConfiguration_KeyType { get; set; }
            public System.String EncryptionConfiguration_KmsKeyArn { get; set; }
            public System.String InstanceArn { get; set; }
            public System.String Name { get; set; }
            public List<System.String> NetworkConfiguration_AllowSourceIp { get; set; }
            public List<System.String> NetworkConfiguration_ExcludeApplicationArn { get; set; }
            public List<System.String> NetworkConfiguration_RestrictSourceVpc { get; set; }
            public System.Boolean? NetworkConfiguration_VpceAccessRequired { get; set; }
            public System.Boolean? PermissionSetsEnabled { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.UpdateInstanceResponse, UpdateSSOADMNInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
