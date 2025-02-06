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
using Amazon.SsmSap;
using Amazon.SsmSap.Model;

namespace Amazon.PowerShell.Cmdlets.SMSAP
{
    /// <summary>
    /// Updates the settings of an application registered with AWS Systems Manager for SAP.
    /// </summary>
    [Cmdlet("Update", "SMSAPApplicationSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SsmSap.Model.UpdateApplicationSettingsResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager for SAP UpdateApplicationSettings API operation.", Operation = new[] {"UpdateApplicationSettings"}, SelectReturnType = typeof(Amazon.SsmSap.Model.UpdateApplicationSettingsResponse))]
    [AWSCmdletOutput("Amazon.SsmSap.Model.UpdateApplicationSettingsResponse",
        "This cmdlet returns an Amazon.SsmSap.Model.UpdateApplicationSettingsResponse object containing multiple properties."
    )]
    public partial class UpdateSMSAPApplicationSettingCmdlet : AmazonSsmSapClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The ID of the application.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter Backint_BackintMode
        /// <summary>
        /// <para>
        /// <para>AWS service for your database backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SsmSap.BackintMode")]
        public Amazon.SsmSap.BackintMode Backint_BackintMode { get; set; }
        #endregion
        
        #region Parameter CredentialsToAddOrUpdate
        /// <summary>
        /// <para>
        /// <para>The credentials to be added or updated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SsmSap.Model.ApplicationCredential[] CredentialsToAddOrUpdate { get; set; }
        #endregion
        
        #region Parameter CredentialsToRemove
        /// <summary>
        /// <para>
        /// <para>The credentials to be removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SsmSap.Model.ApplicationCredential[] CredentialsToRemove { get; set; }
        #endregion
        
        #region Parameter DatabaseArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of the SAP HANA database that replaces the current SAP HANA
        /// connection with the SAP_ABAP application.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseArn { get; set; }
        #endregion
        
        #region Parameter Backint_EnsureNoBackupInProcess
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Backint_EnsureNoBackupInProcess { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SsmSap.Model.UpdateApplicationSettingsResponse).
        /// Specifying the name of a property of type Amazon.SsmSap.Model.UpdateApplicationSettingsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMSAPApplicationSetting (UpdateApplicationSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SsmSap.Model.UpdateApplicationSettingsResponse, UpdateSMSAPApplicationSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Backint_BackintMode = this.Backint_BackintMode;
            context.Backint_EnsureNoBackupInProcess = this.Backint_EnsureNoBackupInProcess;
            if (this.CredentialsToAddOrUpdate != null)
            {
                context.CredentialsToAddOrUpdate = new List<Amazon.SsmSap.Model.ApplicationCredential>(this.CredentialsToAddOrUpdate);
            }
            if (this.CredentialsToRemove != null)
            {
                context.CredentialsToRemove = new List<Amazon.SsmSap.Model.ApplicationCredential>(this.CredentialsToRemove);
            }
            context.DatabaseArn = this.DatabaseArn;
            
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
            var request = new Amazon.SsmSap.Model.UpdateApplicationSettingsRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate Backint
            var requestBackintIsNull = true;
            request.Backint = new Amazon.SsmSap.Model.BackintConfig();
            Amazon.SsmSap.BackintMode requestBackint_backint_BackintMode = null;
            if (cmdletContext.Backint_BackintMode != null)
            {
                requestBackint_backint_BackintMode = cmdletContext.Backint_BackintMode;
            }
            if (requestBackint_backint_BackintMode != null)
            {
                request.Backint.BackintMode = requestBackint_backint_BackintMode;
                requestBackintIsNull = false;
            }
            System.Boolean? requestBackint_backint_EnsureNoBackupInProcess = null;
            if (cmdletContext.Backint_EnsureNoBackupInProcess != null)
            {
                requestBackint_backint_EnsureNoBackupInProcess = cmdletContext.Backint_EnsureNoBackupInProcess.Value;
            }
            if (requestBackint_backint_EnsureNoBackupInProcess != null)
            {
                request.Backint.EnsureNoBackupInProcess = requestBackint_backint_EnsureNoBackupInProcess.Value;
                requestBackintIsNull = false;
            }
             // determine if request.Backint should be set to null
            if (requestBackintIsNull)
            {
                request.Backint = null;
            }
            if (cmdletContext.CredentialsToAddOrUpdate != null)
            {
                request.CredentialsToAddOrUpdate = cmdletContext.CredentialsToAddOrUpdate;
            }
            if (cmdletContext.CredentialsToRemove != null)
            {
                request.CredentialsToRemove = cmdletContext.CredentialsToRemove;
            }
            if (cmdletContext.DatabaseArn != null)
            {
                request.DatabaseArn = cmdletContext.DatabaseArn;
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
        
        private Amazon.SsmSap.Model.UpdateApplicationSettingsResponse CallAWSServiceOperation(IAmazonSsmSap client, Amazon.SsmSap.Model.UpdateApplicationSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager for SAP", "UpdateApplicationSettings");
            try
            {
                #if DESKTOP
                return client.UpdateApplicationSettings(request);
                #elif CORECLR
                return client.UpdateApplicationSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public Amazon.SsmSap.BackintMode Backint_BackintMode { get; set; }
            public System.Boolean? Backint_EnsureNoBackupInProcess { get; set; }
            public List<Amazon.SsmSap.Model.ApplicationCredential> CredentialsToAddOrUpdate { get; set; }
            public List<Amazon.SsmSap.Model.ApplicationCredential> CredentialsToRemove { get; set; }
            public System.String DatabaseArn { get; set; }
            public System.Func<Amazon.SsmSap.Model.UpdateApplicationSettingsResponse, UpdateSMSAPApplicationSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
