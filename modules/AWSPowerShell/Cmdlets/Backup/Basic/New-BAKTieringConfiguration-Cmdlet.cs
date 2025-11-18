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
using Amazon.Backup;
using Amazon.Backup.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Creates a tiering configuration.
    /// 
    ///  
    /// <para>
    /// A tiering configuration enables automatic movement of backup data to a lower-cost
    /// storage tier based on the age of backed-up objects in the backup vault.
    /// </para><para>
    /// Each vault can only have one vault-specific tiering configuration, in addition to
    /// any global configuration that applies to all vaults.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BAKTieringConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Backup.Model.CreateTieringConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Backup CreateTieringConfiguration API operation.", Operation = new[] {"CreateTieringConfiguration"}, SelectReturnType = typeof(Amazon.Backup.Model.CreateTieringConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.CreateTieringConfigurationResponse",
        "This cmdlet returns an Amazon.Backup.Model.CreateTieringConfigurationResponse object containing multiple properties."
    )]
    public partial class NewBAKTieringConfigurationCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter CreatorRequestId
        /// <summary>
        /// <para>
        /// <para>This is a unique string that identifies the request and allows failed requests to
        /// be retried without the risk of running the operation twice. This parameter is optional.
        /// If used, this parameter must contain 1 to 50 alphanumeric or '-_.' characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CreatorRequestId { get; set; }
        #endregion
        
        #region Parameter TieringConfiguration_ResourceSelection
        /// <summary>
        /// <para>
        /// <para>An array of resource selection objects that specify which resources are included in
        /// the tiering configuration and their tiering settings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter TieringConfiguration_TieringConfigurationName
        /// <summary>
        /// <para>
        /// <para>The unique name of the tiering configuration. This cannot be changed after creation,
        /// and it must consist of only alphanumeric characters and underscores.</para>
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
        public System.String TieringConfiguration_TieringConfigurationName { get; set; }
        #endregion
        
        #region Parameter TieringConfigurationTag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the tiering configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TieringConfigurationTags")]
        public System.Collections.Hashtable TieringConfigurationTag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.CreateTieringConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.CreateTieringConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TieringConfiguration_BackupVaultName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BAKTieringConfiguration (CreateTieringConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.CreateTieringConfigurationResponse, NewBAKTieringConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreatorRequestId = this.CreatorRequestId;
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
            context.TieringConfiguration_TieringConfigurationName = this.TieringConfiguration_TieringConfigurationName;
            #if MODULAR
            if (this.TieringConfiguration_TieringConfigurationName == null && ParameterWasBound(nameof(this.TieringConfiguration_TieringConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter TieringConfiguration_TieringConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TieringConfigurationTag != null)
            {
                context.TieringConfigurationTag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TieringConfigurationTag.Keys)
                {
                    context.TieringConfigurationTag.Add((String)hashKey, (System.String)(this.TieringConfigurationTag[hashKey]));
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
            var request = new Amazon.Backup.Model.CreateTieringConfigurationRequest();
            
            if (cmdletContext.CreatorRequestId != null)
            {
                request.CreatorRequestId = cmdletContext.CreatorRequestId;
            }
            
             // populate TieringConfiguration
            var requestTieringConfigurationIsNull = true;
            request.TieringConfiguration = new Amazon.Backup.Model.TieringConfigurationInputForCreate();
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
            System.String requestTieringConfiguration_tieringConfiguration_TieringConfigurationName = null;
            if (cmdletContext.TieringConfiguration_TieringConfigurationName != null)
            {
                requestTieringConfiguration_tieringConfiguration_TieringConfigurationName = cmdletContext.TieringConfiguration_TieringConfigurationName;
            }
            if (requestTieringConfiguration_tieringConfiguration_TieringConfigurationName != null)
            {
                request.TieringConfiguration.TieringConfigurationName = requestTieringConfiguration_tieringConfiguration_TieringConfigurationName;
                requestTieringConfigurationIsNull = false;
            }
             // determine if request.TieringConfiguration should be set to null
            if (requestTieringConfigurationIsNull)
            {
                request.TieringConfiguration = null;
            }
            if (cmdletContext.TieringConfigurationTag != null)
            {
                request.TieringConfigurationTags = cmdletContext.TieringConfigurationTag;
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
        
        private Amazon.Backup.Model.CreateTieringConfigurationResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.CreateTieringConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "CreateTieringConfiguration");
            try
            {
                return client.CreateTieringConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CreatorRequestId { get; set; }
            public System.String TieringConfiguration_BackupVaultName { get; set; }
            public List<Amazon.Backup.Model.ResourceSelection> TieringConfiguration_ResourceSelection { get; set; }
            public System.String TieringConfiguration_TieringConfigurationName { get; set; }
            public Dictionary<System.String, System.String> TieringConfigurationTag { get; set; }
            public System.Func<Amazon.Backup.Model.CreateTieringConfigurationResponse, NewBAKTieringConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
