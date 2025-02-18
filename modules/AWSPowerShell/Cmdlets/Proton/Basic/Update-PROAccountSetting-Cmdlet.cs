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
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// Update Proton settings that are used for multiple services in the Amazon Web Services
    /// account.
    /// </summary>
    [Cmdlet("Update", "PROAccountSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.AccountSettings")]
    [AWSCmdlet("Calls the AWS Proton UpdateAccountSettings API operation.", Operation = new[] {"UpdateAccountSettings"}, SelectReturnType = typeof(Amazon.Proton.Model.UpdateAccountSettingsResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.AccountSettings or Amazon.Proton.Model.UpdateAccountSettingsResponse",
        "This cmdlet returns an Amazon.Proton.Model.AccountSettings object.",
        "The service call response (type Amazon.Proton.Model.UpdateAccountSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePROAccountSettingCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PipelineProvisioningRepository_Branch
        /// <summary>
        /// <para>
        /// <para>The repository branch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineProvisioningRepository_Branch { get; set; }
        #endregion
        
        #region Parameter DeletePipelineProvisioningRepository
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to remove a configured pipeline repository from the account settings.
        /// Don't set this field if you are updating the configured pipeline repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletePipelineProvisioningRepository { get; set; }
        #endregion
        
        #region Parameter PipelineProvisioningRepository_Name
        /// <summary>
        /// <para>
        /// <para>The repository name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineProvisioningRepository_Name { get; set; }
        #endregion
        
        #region Parameter PipelineCodebuildRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service role you want to use for provisioning
        /// pipelines. Proton assumes this role for CodeBuild-based provisioning.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineCodebuildRoleArn { get; set; }
        #endregion
        
        #region Parameter PipelineServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service role you want to use for provisioning
        /// pipelines. Assumed by Proton for Amazon Web Services-managed provisioning, and by
        /// customer-owned automation for self-managed provisioning.</para><para>To remove a previously configured ARN, specify an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PipelineServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter PipelineProvisioningRepository_Provider
        /// <summary>
        /// <para>
        /// <para>The repository provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Proton.RepositoryProvider")]
        public Amazon.Proton.RepositoryProvider PipelineProvisioningRepository_Provider { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountSettings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.UpdateAccountSettingsResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.UpdateAccountSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountSettings";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROAccountSetting (UpdateAccountSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.UpdateAccountSettingsResponse, UpdatePROAccountSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeletePipelineProvisioningRepository = this.DeletePipelineProvisioningRepository;
            context.PipelineCodebuildRoleArn = this.PipelineCodebuildRoleArn;
            context.PipelineProvisioningRepository_Branch = this.PipelineProvisioningRepository_Branch;
            context.PipelineProvisioningRepository_Name = this.PipelineProvisioningRepository_Name;
            context.PipelineProvisioningRepository_Provider = this.PipelineProvisioningRepository_Provider;
            context.PipelineServiceRoleArn = this.PipelineServiceRoleArn;
            
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
            var request = new Amazon.Proton.Model.UpdateAccountSettingsRequest();
            
            if (cmdletContext.DeletePipelineProvisioningRepository != null)
            {
                request.DeletePipelineProvisioningRepository = cmdletContext.DeletePipelineProvisioningRepository.Value;
            }
            if (cmdletContext.PipelineCodebuildRoleArn != null)
            {
                request.PipelineCodebuildRoleArn = cmdletContext.PipelineCodebuildRoleArn;
            }
            
             // populate PipelineProvisioningRepository
            var requestPipelineProvisioningRepositoryIsNull = true;
            request.PipelineProvisioningRepository = new Amazon.Proton.Model.RepositoryBranchInput();
            System.String requestPipelineProvisioningRepository_pipelineProvisioningRepository_Branch = null;
            if (cmdletContext.PipelineProvisioningRepository_Branch != null)
            {
                requestPipelineProvisioningRepository_pipelineProvisioningRepository_Branch = cmdletContext.PipelineProvisioningRepository_Branch;
            }
            if (requestPipelineProvisioningRepository_pipelineProvisioningRepository_Branch != null)
            {
                request.PipelineProvisioningRepository.Branch = requestPipelineProvisioningRepository_pipelineProvisioningRepository_Branch;
                requestPipelineProvisioningRepositoryIsNull = false;
            }
            System.String requestPipelineProvisioningRepository_pipelineProvisioningRepository_Name = null;
            if (cmdletContext.PipelineProvisioningRepository_Name != null)
            {
                requestPipelineProvisioningRepository_pipelineProvisioningRepository_Name = cmdletContext.PipelineProvisioningRepository_Name;
            }
            if (requestPipelineProvisioningRepository_pipelineProvisioningRepository_Name != null)
            {
                request.PipelineProvisioningRepository.Name = requestPipelineProvisioningRepository_pipelineProvisioningRepository_Name;
                requestPipelineProvisioningRepositoryIsNull = false;
            }
            Amazon.Proton.RepositoryProvider requestPipelineProvisioningRepository_pipelineProvisioningRepository_Provider = null;
            if (cmdletContext.PipelineProvisioningRepository_Provider != null)
            {
                requestPipelineProvisioningRepository_pipelineProvisioningRepository_Provider = cmdletContext.PipelineProvisioningRepository_Provider;
            }
            if (requestPipelineProvisioningRepository_pipelineProvisioningRepository_Provider != null)
            {
                request.PipelineProvisioningRepository.Provider = requestPipelineProvisioningRepository_pipelineProvisioningRepository_Provider;
                requestPipelineProvisioningRepositoryIsNull = false;
            }
             // determine if request.PipelineProvisioningRepository should be set to null
            if (requestPipelineProvisioningRepositoryIsNull)
            {
                request.PipelineProvisioningRepository = null;
            }
            if (cmdletContext.PipelineServiceRoleArn != null)
            {
                request.PipelineServiceRoleArn = cmdletContext.PipelineServiceRoleArn;
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
        
        private Amazon.Proton.Model.UpdateAccountSettingsResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.UpdateAccountSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "UpdateAccountSettings");
            try
            {
                return client.UpdateAccountSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DeletePipelineProvisioningRepository { get; set; }
            public System.String PipelineCodebuildRoleArn { get; set; }
            public System.String PipelineProvisioningRepository_Branch { get; set; }
            public System.String PipelineProvisioningRepository_Name { get; set; }
            public Amazon.Proton.RepositoryProvider PipelineProvisioningRepository_Provider { get; set; }
            public System.String PipelineServiceRoleArn { get; set; }
            public System.Func<Amazon.Proton.Model.UpdateAccountSettingsResponse, UpdatePROAccountSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountSettings;
        }
        
    }
}
