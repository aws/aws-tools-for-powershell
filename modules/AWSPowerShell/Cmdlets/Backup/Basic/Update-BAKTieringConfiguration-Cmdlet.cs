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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// This request will send changes to your specified tiering configuration. <c>TieringConfigurationName</c>
    /// cannot be updated after it is created.
    /// 
    ///  
    /// <para><c>ResourceSelection</c> can contain:
    /// </para><ul><li><para><c>Resources</c></para></li><li><para><c>TieringDownSettingsInDays</c></para></li><li><para><c>ResourceType</c></para></li></ul>
    /// </summary>
    [Cmdlet("Update", "BAKTieringConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.UpdateTieringConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Backup UpdateTieringConfiguration API operation.", Operation = new[] {"UpdateTieringConfiguration"}, SelectReturnType = typeof(Amazon.Backup.Model.UpdateTieringConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.UpdateTieringConfigurationResponse",
        "This cmdlet returns an Amazon.Backup.Model.UpdateTieringConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateBAKTieringConfigurationCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TieringConfiguration_BackupVaultName
        /// <summary>
        /// <para>
        /// <para>The name of the backup vault where the tiering configuration applies. Use <c>*</c>
        /// to apply to all backup vaults.</para>
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
        public System.String TieringConfiguration_BackupVaultName { get; set; }
        #endregion
        
        #region Parameter TieringConfiguration_ResourceSelection
        /// <summary>
        /// <para>
        /// <para>An array of resource selection objects that specify which resources are included in
        /// the tiering configuration and their tiering settings.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.Backup.Model.ResourceSelection[] TieringConfiguration_ResourceSelection { get; set; }
        #endregion
        
        #region Parameter TieringConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of a tiering configuration to update.</para>
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
        public System.String TieringConfigurationName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.UpdateTieringConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.UpdateTieringConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TieringConfigurationName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TieringConfigurationName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TieringConfigurationName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TieringConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-BAKTieringConfiguration (UpdateTieringConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.UpdateTieringConfigurationResponse, UpdateBAKTieringConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TieringConfigurationName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.TieringConfiguration_BackupVaultName = this.TieringConfiguration_BackupVaultName;
            #if MODULAR
            if (this.TieringConfiguration_BackupVaultName == null && ParameterWasBound(nameof(this.TieringConfiguration_BackupVaultName)))
            {
                WriteWarning("You are passing $null as a value for parameter TieringConfiguration_BackupVaultName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TieringConfiguration_ResourceSelection != null)
            {
                context.TieringConfiguration_ResourceSelection = new List<Amazon.Backup.Model.ResourceSelection>(this.TieringConfiguration_ResourceSelection);
            }
            #if MODULAR
            if (this.TieringConfiguration_ResourceSelection == null && ParameterWasBound(nameof(this.TieringConfiguration_ResourceSelection)))
            {
                WriteWarning("You are passing $null as a value for parameter TieringConfiguration_ResourceSelection which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TieringConfigurationName = this.TieringConfigurationName;
            #if MODULAR
            if (this.TieringConfigurationName == null && ParameterWasBound(nameof(this.TieringConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter TieringConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.UpdateTieringConfigurationRequest();
            
            
             // populate TieringConfiguration
            var requestTieringConfigurationIsNull = true;
            request.TieringConfiguration = new Amazon.Backup.Model.TieringConfigurationInputForUpdate();
            System.String requestTieringConfiguration_tieringConfiguration_BackupVaultName = null;
            if (cmdletContext.TieringConfiguration_BackupVaultName != null)
            {
                requestTieringConfiguration_tieringConfiguration_BackupVaultName = cmdletContext.TieringConfiguration_BackupVaultName;
            }
            if (requestTieringConfiguration_tieringConfiguration_BackupVaultName != null)
            {
                request.TieringConfiguration.BackupVaultName = requestTieringConfiguration_tieringConfiguration_BackupVaultName;
                requestTieringConfigurationIsNull = false;
            }
            List<Amazon.Backup.Model.ResourceSelection> requestTieringConfiguration_tieringConfiguration_ResourceSelection = null;
            if (cmdletContext.TieringConfiguration_ResourceSelection != null)
            {
                requestTieringConfiguration_tieringConfiguration_ResourceSelection = cmdletContext.TieringConfiguration_ResourceSelection;
            }
            if (requestTieringConfiguration_tieringConfiguration_ResourceSelection != null)
            {
                request.TieringConfiguration.ResourceSelection = requestTieringConfiguration_tieringConfiguration_ResourceSelection;
                requestTieringConfigurationIsNull = false;
            }
             // determine if request.TieringConfiguration should be set to null
            if (requestTieringConfigurationIsNull)
            {
                request.TieringConfiguration = null;
            }
            if (cmdletContext.TieringConfigurationName != null)
            {
                request.TieringConfigurationName = cmdletContext.TieringConfigurationName;
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
        
        private Amazon.Backup.Model.UpdateTieringConfigurationResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.UpdateTieringConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "UpdateTieringConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateTieringConfiguration(request);
                #elif CORECLR
                return client.UpdateTieringConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String TieringConfiguration_BackupVaultName { get; set; }
            public List<Amazon.Backup.Model.ResourceSelection> TieringConfiguration_ResourceSelection { get; set; }
            public System.String TieringConfigurationName { get; set; }
            public System.Func<Amazon.Backup.Model.UpdateTieringConfigurationResponse, UpdateBAKTieringConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
