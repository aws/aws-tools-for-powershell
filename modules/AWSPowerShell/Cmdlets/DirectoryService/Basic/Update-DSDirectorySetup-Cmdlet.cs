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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Updates the directory for a particular update type.
    /// </summary>
    [Cmdlet("Update", "DSDirectorySetup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Directory Service UpdateDirectorySetup API operation.", Operation = new[] {"UpdateDirectorySetup"}, SelectReturnType = typeof(Amazon.DirectoryService.Model.UpdateDirectorySetupResponse))]
    [AWSCmdletOutput("None or Amazon.DirectoryService.Model.UpdateDirectorySetupResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DirectoryService.Model.UpdateDirectorySetupResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateDSDirectorySetupCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CreateSnapshotBeforeUpdate
        /// <summary>
        /// <para>
        /// <para> The boolean that specifies if a snapshot for the directory needs to be taken before
        /// updating the directory. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CreateSnapshotBeforeUpdate { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para> The identifier of the directory on which you want to perform the update. </para>
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
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter OSUpdateSettings_OSVersion
        /// <summary>
        /// <para>
        /// <para> OS version that the directory needs to be updated to. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DirectoryService.OSVersion")]
        public Amazon.DirectoryService.OSVersion OSUpdateSettings_OSVersion { get; set; }
        #endregion
        
        #region Parameter UpdateType
        /// <summary>
        /// <para>
        /// <para> The type of update that needs to be performed on the directory. For example, OS.
        /// </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DirectoryService.UpdateType")]
        public Amazon.DirectoryService.UpdateType UpdateType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DirectoryService.Model.UpdateDirectorySetupResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DirectoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSDirectorySetup (UpdateDirectorySetup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DirectoryService.Model.UpdateDirectorySetupResponse, UpdateDSDirectorySetupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CreateSnapshotBeforeUpdate = this.CreateSnapshotBeforeUpdate;
            context.DirectoryId = this.DirectoryId;
            #if MODULAR
            if (this.DirectoryId == null && ParameterWasBound(nameof(this.DirectoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter DirectoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OSUpdateSettings_OSVersion = this.OSUpdateSettings_OSVersion;
            context.UpdateType = this.UpdateType;
            #if MODULAR
            if (this.UpdateType == null && ParameterWasBound(nameof(this.UpdateType)))
            {
                WriteWarning("You are passing $null as a value for parameter UpdateType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DirectoryService.Model.UpdateDirectorySetupRequest();
            
            if (cmdletContext.CreateSnapshotBeforeUpdate != null)
            {
                request.CreateSnapshotBeforeUpdate = cmdletContext.CreateSnapshotBeforeUpdate.Value;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            
             // populate OSUpdateSettings
            var requestOSUpdateSettingsIsNull = true;
            request.OSUpdateSettings = new Amazon.DirectoryService.Model.OSUpdateSettings();
            Amazon.DirectoryService.OSVersion requestOSUpdateSettings_oSUpdateSettings_OSVersion = null;
            if (cmdletContext.OSUpdateSettings_OSVersion != null)
            {
                requestOSUpdateSettings_oSUpdateSettings_OSVersion = cmdletContext.OSUpdateSettings_OSVersion;
            }
            if (requestOSUpdateSettings_oSUpdateSettings_OSVersion != null)
            {
                request.OSUpdateSettings.OSVersion = requestOSUpdateSettings_oSUpdateSettings_OSVersion;
                requestOSUpdateSettingsIsNull = false;
            }
             // determine if request.OSUpdateSettings should be set to null
            if (requestOSUpdateSettingsIsNull)
            {
                request.OSUpdateSettings = null;
            }
            if (cmdletContext.UpdateType != null)
            {
                request.UpdateType = cmdletContext.UpdateType;
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
        
        private Amazon.DirectoryService.Model.UpdateDirectorySetupResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.UpdateDirectorySetupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "UpdateDirectorySetup");
            try
            {
                return client.UpdateDirectorySetupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? CreateSnapshotBeforeUpdate { get; set; }
            public System.String DirectoryId { get; set; }
            public Amazon.DirectoryService.OSVersion OSUpdateSettings_OSVersion { get; set; }
            public Amazon.DirectoryService.UpdateType UpdateType { get; set; }
            public System.Func<Amazon.DirectoryService.Model.UpdateDirectorySetupResponse, UpdateDSDirectorySetupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
