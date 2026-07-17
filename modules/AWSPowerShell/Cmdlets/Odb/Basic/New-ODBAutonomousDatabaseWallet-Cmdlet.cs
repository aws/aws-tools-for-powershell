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
using Amazon.Odb;
using Amazon.Odb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Creates a new wallet for the specified Autonomous Database.
    /// </summary>
    [Cmdlet("New", "ODBAutonomousDatabaseWallet", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services CreateAutonomousDatabaseWallet API operation.", Operation = new[] {"CreateAutonomousDatabaseWallet"}, SelectReturnType = typeof(Amazon.Odb.Model.CreateAutonomousDatabaseWalletResponse))]
    [AWSCmdletOutput("System.IO.MemoryStream or Amazon.Odb.Model.CreateAutonomousDatabaseWalletResponse",
        "This cmdlet returns a System.IO.MemoryStream object.",
        "The service call response (type Amazon.Odb.Model.CreateAutonomousDatabaseWalletResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewODBAutonomousDatabaseWalletCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutonomousDatabaseId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Autonomous Database to create a wallet for.</para>
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
        public System.String AutonomousDatabaseId { get; set; }
        #endregion
        
        #region Parameter PasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType
        /// <summary>
        /// <para>
        /// <para>The type of Oracle Cloud Identifier (OCID) used as the external ID when assuming the
        /// IAM role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.ExternalIdType")]
        public Amazon.Odb.ExternalIdType PasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType { get; set; }
        #endregion
        
        #region Parameter PasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Identity and Access Management
        /// (IAM) role that OCI assumes to retrieve the secret value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password to encrypt the keys inside the wallet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter PasswordSource
        /// <summary>
        /// <para>
        /// <para>The source of the password for encrypting the wallet. When set to <c>CUSTOMER_MANAGED_AWS_SECRET</c>,
        /// the password is retrieved from an Amazon Web Services Secrets Manager secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.WalletPasswordSource")]
        public Amazon.Odb.WalletPasswordSource PasswordSource { get; set; }
        #endregion
        
        #region Parameter PasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId
        /// <summary>
        /// <para>
        /// <para>The identifier or ARN of the Amazon Web Services Secrets Manager secret that contains
        /// the password.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId { get; set; }
        #endregion
        
        #region Parameter WalletType
        /// <summary>
        /// <para>
        /// <para>The type of wallet to create, either a regional wallet or an instance wallet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.WalletType")]
        public Amazon.Odb.WalletType WalletType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A client-provided token to ensure the idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AutonomousDatabaseWalletFile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.CreateAutonomousDatabaseWalletResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.CreateAutonomousDatabaseWalletResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AutonomousDatabaseWalletFile";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutonomousDatabaseId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ODBAutonomousDatabaseWallet (CreateAutonomousDatabaseWallet)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.CreateAutonomousDatabaseWalletResponse, NewODBAutonomousDatabaseWalletCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutonomousDatabaseId = this.AutonomousDatabaseId;
            #if MODULAR
            if (this.AutonomousDatabaseId == null && ParameterWasBound(nameof(this.AutonomousDatabaseId)))
            {
                WriteWarning("You are passing $null as a value for parameter AutonomousDatabaseId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Password = this.Password;
            context.PasswordSource = this.PasswordSource;
            context.PasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType = this.PasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType;
            context.PasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn = this.PasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn;
            context.PasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId = this.PasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId;
            context.WalletType = this.WalletType;
            
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
            var request = new Amazon.Odb.Model.CreateAutonomousDatabaseWalletRequest();
            
            if (cmdletContext.AutonomousDatabaseId != null)
            {
                request.AutonomousDatabaseId = cmdletContext.AutonomousDatabaseId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.PasswordSource != null)
            {
                request.PasswordSource = cmdletContext.PasswordSource;
            }
            
             // populate PasswordSourceConfiguration
            var requestPasswordSourceConfigurationIsNull = true;
            request.PasswordSourceConfiguration = new Amazon.Odb.Model.WalletPasswordSourceConfigurationInput();
            Amazon.Odb.Model.CustomerManagedAwsSecretConfigurationInput requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret = null;
            
             // populate CustomerManagedAwsSecret
            var requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecretIsNull = true;
            requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret = new Amazon.Odb.Model.CustomerManagedAwsSecretConfigurationInput();
            Amazon.Odb.ExternalIdType requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType = null;
            if (cmdletContext.PasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType != null)
            {
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType = cmdletContext.PasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType;
            }
            if (requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType != null)
            {
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret.ExternalIdType = requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType;
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecretIsNull = false;
            }
            System.String requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn = null;
            if (cmdletContext.PasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn != null)
            {
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn = cmdletContext.PasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn;
            }
            if (requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn != null)
            {
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret.IamRoleArn = requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn;
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecretIsNull = false;
            }
            System.String requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_SecretId = null;
            if (cmdletContext.PasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId != null)
            {
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_SecretId = cmdletContext.PasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId;
            }
            if (requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_SecretId != null)
            {
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret.SecretId = requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret_passwordSourceConfiguration_CustomerManagedAwsSecret_SecretId;
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecretIsNull = false;
            }
             // determine if requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret should be set to null
            if (requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecretIsNull)
            {
                requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret = null;
            }
            if (requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret != null)
            {
                request.PasswordSourceConfiguration.CustomerManagedAwsSecret = requestPasswordSourceConfiguration_passwordSourceConfiguration_CustomerManagedAwsSecret;
                requestPasswordSourceConfigurationIsNull = false;
            }
             // determine if request.PasswordSourceConfiguration should be set to null
            if (requestPasswordSourceConfigurationIsNull)
            {
                request.PasswordSourceConfiguration = null;
            }
            if (cmdletContext.WalletType != null)
            {
                request.WalletType = cmdletContext.WalletType;
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
        
        private Amazon.Odb.Model.CreateAutonomousDatabaseWalletResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.CreateAutonomousDatabaseWalletRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "CreateAutonomousDatabaseWallet");
            try
            {
                return client.CreateAutonomousDatabaseWalletAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AutonomousDatabaseId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Password { get; set; }
            public Amazon.Odb.WalletPasswordSource PasswordSource { get; set; }
            public Amazon.Odb.ExternalIdType PasswordSourceConfiguration_CustomerManagedAwsSecret_ExternalIdType { get; set; }
            public System.String PasswordSourceConfiguration_CustomerManagedAwsSecret_IamRoleArn { get; set; }
            public System.String PasswordSourceConfiguration_CustomerManagedAwsSecret_SecretId { get; set; }
            public Amazon.Odb.WalletType WalletType { get; set; }
            public System.Func<Amazon.Odb.Model.CreateAutonomousDatabaseWalletResponse, NewODBAutonomousDatabaseWalletCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AutonomousDatabaseWalletFile;
        }
        
    }
}
