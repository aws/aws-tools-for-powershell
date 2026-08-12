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
    /// Updates the specified Exascale storage vault.
    /// </summary>
    [Cmdlet("Update", "ODBExascaleDbStorageVault", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services UpdateExascaleDbStorageVault API operation.", Operation = new[] {"UpdateExascaleDbStorageVault"}, SelectReturnType = typeof(Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse",
        "This cmdlet returns an Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse object containing multiple properties."
    )]
    public partial class UpdateODBExascaleDbStorageVaultCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalFlashCacheInPercent
        /// <summary>
        /// <para>
        /// <para>The additional flash cache percentage for the Exascale storage vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AdditionalFlashCacheInPercent { get; set; }
        #endregion
        
        #region Parameter AutoscaleLimitInGBs
        /// <summary>
        /// <para>
        /// <para>The autoscale limit in gigabytes (GB) for the Exascale storage vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoscaleLimitInGBs { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new description for the Exascale storage vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A new user-friendly name for the Exascale storage vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ExascaleDbStorageVaultId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the Exascale storage vault to update.</para>
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
        public System.String ExascaleDbStorageVaultId { get; set; }
        #endregion
        
        #region Parameter HighCapacityDatabaseStorageTotalSizeInGBs
        /// <summary>
        /// <para>
        /// <para>The total size of the high-capacity database storage, in gigabytes (GB), for the Exascale
        /// storage vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HighCapacityDatabaseStorageTotalSizeInGBs { get; set; }
        #endregion
        
        #region Parameter IsAutoscaleEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether autoscaling is enabled for the Exascale storage vault.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsAutoscaleEnabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ExascaleDbStorageVaultId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ODBExascaleDbStorageVault (UpdateExascaleDbStorageVault)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse, UpdateODBExascaleDbStorageVaultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdditionalFlashCacheInPercent = this.AdditionalFlashCacheInPercent;
            context.AutoscaleLimitInGBs = this.AutoscaleLimitInGBs;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.ExascaleDbStorageVaultId = this.ExascaleDbStorageVaultId;
            #if MODULAR
            if (this.ExascaleDbStorageVaultId == null && ParameterWasBound(nameof(this.ExascaleDbStorageVaultId)))
            {
                WriteWarning("You are passing $null as a value for parameter ExascaleDbStorageVaultId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HighCapacityDatabaseStorageTotalSizeInGBs = this.HighCapacityDatabaseStorageTotalSizeInGBs;
            context.IsAutoscaleEnabled = this.IsAutoscaleEnabled;
            
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
            var request = new Amazon.Odb.Model.UpdateExascaleDbStorageVaultRequest();
            
            if (cmdletContext.AdditionalFlashCacheInPercent != null)
            {
                request.AdditionalFlashCacheInPercent = cmdletContext.AdditionalFlashCacheInPercent.Value;
            }
            if (cmdletContext.AutoscaleLimitInGBs != null)
            {
                request.AutoscaleLimitInGBs = cmdletContext.AutoscaleLimitInGBs.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.ExascaleDbStorageVaultId != null)
            {
                request.ExascaleDbStorageVaultId = cmdletContext.ExascaleDbStorageVaultId;
            }
            if (cmdletContext.HighCapacityDatabaseStorageTotalSizeInGBs != null)
            {
                request.HighCapacityDatabaseStorageTotalSizeInGBs = cmdletContext.HighCapacityDatabaseStorageTotalSizeInGBs.Value;
            }
            if (cmdletContext.IsAutoscaleEnabled != null)
            {
                request.IsAutoscaleEnabled = cmdletContext.IsAutoscaleEnabled.Value;
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
        
        private Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.UpdateExascaleDbStorageVaultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "UpdateExascaleDbStorageVault");
            try
            {
                return client.UpdateExascaleDbStorageVaultAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? AdditionalFlashCacheInPercent { get; set; }
            public System.Int32? AutoscaleLimitInGBs { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String ExascaleDbStorageVaultId { get; set; }
            public System.Int32? HighCapacityDatabaseStorageTotalSizeInGBs { get; set; }
            public System.Boolean? IsAutoscaleEnabled { get; set; }
            public System.Func<Amazon.Odb.Model.UpdateExascaleDbStorageVaultResponse, UpdateODBExascaleDbStorageVaultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
