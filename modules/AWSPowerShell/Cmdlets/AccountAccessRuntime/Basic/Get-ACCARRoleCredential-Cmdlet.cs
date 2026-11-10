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
using Amazon.AccountAccessRuntime;
using Amazon.AccountAccessRuntime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ACCAR
{
    /// <summary>
    /// Returns temporary Amazon Web Services credentials for a role that you are entitled
    /// to assume within a tenant. You can use these credentials for programmatic access with
    /// the CLI or an Amazon Web Services SDK. If you aren't entitled to the role, the request
    /// fails with an <c>AccessDeniedException</c> error.
    /// </summary>
    [Cmdlet("Get", "ACCARRoleCredential")]
    [OutputType("Amazon.AccountAccessRuntime.Model.CredentialsDetails")]
    [AWSCmdlet("Calls the Account Access Runtime GetRoleCredentials API operation.", Operation = new[] {"GetRoleCredentials"}, SelectReturnType = typeof(Amazon.AccountAccessRuntime.Model.GetRoleCredentialsResponse))]
    [AWSCmdletOutput("Amazon.AccountAccessRuntime.Model.CredentialsDetails or Amazon.AccountAccessRuntime.Model.GetRoleCredentialsResponse",
        "This cmdlet returns an Amazon.AccountAccessRuntime.Model.CredentialsDetails object.",
        "The service call response (type Amazon.AccountAccessRuntime.Model.GetRoleCredentialsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetACCARRoleCredentialCmdlet : AmazonAccountAccessRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccessType
        /// <summary>
        /// <para>
        /// <para>The type of access to request for the role. Specify <c>PROGRAMMATIC_ACCESS</c> to
        /// receive access key credentials for use with the CLI or an Amazon Web Services SDK.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AccountAccessRuntime.AccessType")]
        public Amazon.AccountAccessRuntime.AccessType AccessType { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role to retrieve credentials for. You must be
        /// entitled to assume this role.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter SessionDuration
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, that the returned credentials remain valid. If you don't
        /// specify a value, the service uses the default session duration. The maximum value
        /// can't exceed the maximum session duration configured for the role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SessionDuration { get; set; }
        #endregion
        
        #region Parameter SessionName
        /// <summary>
        /// <para>
        /// <para>An optional name for the role session. The name can be 2 to 64 characters and can
        /// contain alphanumeric characters and the following symbols: plus (+), equal (=), comma
        /// (,), period (.), at (@), and hyphen (-). The session name appears in CloudTrail logs
        /// for the assumed role session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionName { get; set; }
        #endregion
        
        #region Parameter TenantId
        /// <summary>
        /// <para>
        /// <para>The identifier of the tenant that the request applies to. A tenant ID begins with
        /// <c>aa-</c> and is 3 to 24 characters long. It can contain lowercase letters, numbers,
        /// and hyphens.</para>
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
        public System.String TenantId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CredentialsDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AccountAccessRuntime.Model.GetRoleCredentialsResponse).
        /// Specifying the name of a property of type Amazon.AccountAccessRuntime.Model.GetRoleCredentialsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CredentialsDetails";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AccountAccessRuntime.Model.GetRoleCredentialsResponse, GetACCARRoleCredentialCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccessType = this.AccessType;
            #if MODULAR
            if (this.AccessType == null && ParameterWasBound(nameof(this.AccessType)))
            {
                WriteWarning("You are passing $null as a value for parameter AccessType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionDuration = this.SessionDuration;
            context.SessionName = this.SessionName;
            context.TenantId = this.TenantId;
            #if MODULAR
            if (this.TenantId == null && ParameterWasBound(nameof(this.TenantId)))
            {
                WriteWarning("You are passing $null as a value for parameter TenantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AccountAccessRuntime.Model.GetRoleCredentialsRequest();
            
            if (cmdletContext.AccessType != null)
            {
                request.AccessType = cmdletContext.AccessType;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.SessionDuration != null)
            {
                request.SessionDuration = cmdletContext.SessionDuration.Value;
            }
            if (cmdletContext.SessionName != null)
            {
                request.SessionName = cmdletContext.SessionName;
            }
            if (cmdletContext.TenantId != null)
            {
                request.TenantId = cmdletContext.TenantId;
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
        
        private Amazon.AccountAccessRuntime.Model.GetRoleCredentialsResponse CallAWSServiceOperation(IAmazonAccountAccessRuntime client, Amazon.AccountAccessRuntime.Model.GetRoleCredentialsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Account Access Runtime", "GetRoleCredentials");
            try
            {
                return client.GetRoleCredentialsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.AccountAccessRuntime.AccessType AccessType { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? SessionDuration { get; set; }
            public System.String SessionName { get; set; }
            public System.String TenantId { get; set; }
            public System.Func<Amazon.AccountAccessRuntime.Model.GetRoleCredentialsResponse, GetACCARRoleCredentialCmdlet, object> Select { get; set; } =
                (response, cmdlet) => Amazon.PowerShell.Common.SensitiveOutput.TagForHost(response.CredentialsDetails, cmdlet, "CredentialsDetails");
        }
        
    }
}
