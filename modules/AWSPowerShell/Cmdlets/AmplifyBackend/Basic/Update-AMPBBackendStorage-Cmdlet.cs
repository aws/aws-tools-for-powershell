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
using Amazon.AmplifyBackend;
using Amazon.AmplifyBackend.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AMPB
{
    /// <summary>
    /// Updates an existing backend storage resource.
    /// </summary>
    [Cmdlet("Update", "AMPBBackendStorage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse")]
    [AWSCmdlet("Calls the Amplify Backend UpdateBackendStorage API operation.", Operation = new[] {"UpdateBackendStorage"}, SelectReturnType = typeof(Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse))]
    [AWSCmdletOutput("Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse",
        "This cmdlet returns an Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse object containing multiple properties."
    )]
    public partial class UpdateAMPBBackendStorageCmdlet : AmazonAmplifyBackendClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AppId
        /// <summary>
        /// <para>
        /// <para>The app ID.</para>
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
        public System.String AppId { get; set; }
        #endregion
        
        #region Parameter Permissions_Authenticated
        /// <summary>
        /// <para>
        /// <para>Lists all authenticated user read, write, and delete permissions for your S3 bucket.</para><para />
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
        [Alias("ResourceConfig_Permissions_Authenticated")]
        public System.String[] Permissions_Authenticated { get; set; }
        #endregion
        
        #region Parameter BackendEnvironmentName
        /// <summary>
        /// <para>
        /// <para>The name of the backend environment.</para>
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
        public System.String BackendEnvironmentName { get; set; }
        #endregion
        
        #region Parameter ResourceName
        /// <summary>
        /// <para>
        /// <para>The name of the storage resource.</para>
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
        public System.String ResourceName { get; set; }
        #endregion
        
        #region Parameter ResourceConfig_ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the storage service.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AmplifyBackend.ServiceName")]
        public Amazon.AmplifyBackend.ServiceName ResourceConfig_ServiceName { get; set; }
        #endregion
        
        #region Parameter Permissions_UnAuthenticated
        /// <summary>
        /// <para>
        /// <para>Lists all unauthenticated user read, write, and delete permissions for your S3 bucket.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_Permissions_UnAuthenticated")]
        public System.String[] Permissions_UnAuthenticated { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse).
        /// Specifying the name of a property of type Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AppId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AMPBBackendStorage (UpdateBackendStorage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse, UpdateAMPBBackendStorageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AppId = this.AppId;
            #if MODULAR
            if (this.AppId == null && ParameterWasBound(nameof(this.AppId)))
            {
                WriteWarning("You are passing $null as a value for parameter AppId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BackendEnvironmentName = this.BackendEnvironmentName;
            #if MODULAR
            if (this.BackendEnvironmentName == null && ParameterWasBound(nameof(this.BackendEnvironmentName)))
            {
                WriteWarning("You are passing $null as a value for parameter BackendEnvironmentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permissions_Authenticated != null)
            {
                context.Permissions_Authenticated = new List<System.String>(this.Permissions_Authenticated);
            }
            #if MODULAR
            if (this.Permissions_Authenticated == null && ParameterWasBound(nameof(this.Permissions_Authenticated)))
            {
                WriteWarning("You are passing $null as a value for parameter Permissions_Authenticated which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Permissions_UnAuthenticated != null)
            {
                context.Permissions_UnAuthenticated = new List<System.String>(this.Permissions_UnAuthenticated);
            }
            context.ResourceConfig_ServiceName = this.ResourceConfig_ServiceName;
            #if MODULAR
            if (this.ResourceConfig_ServiceName == null && ParameterWasBound(nameof(this.ResourceConfig_ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceConfig_ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceName = this.ResourceName;
            #if MODULAR
            if (this.ResourceName == null && ParameterWasBound(nameof(this.ResourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AmplifyBackend.Model.UpdateBackendStorageRequest();
            
            if (cmdletContext.AppId != null)
            {
                request.AppId = cmdletContext.AppId;
            }
            if (cmdletContext.BackendEnvironmentName != null)
            {
                request.BackendEnvironmentName = cmdletContext.BackendEnvironmentName;
            }
            
             // populate ResourceConfig
            var requestResourceConfigIsNull = true;
            request.ResourceConfig = new Amazon.AmplifyBackend.Model.UpdateBackendStorageResourceConfig();
            Amazon.AmplifyBackend.ServiceName requestResourceConfig_resourceConfig_ServiceName = null;
            if (cmdletContext.ResourceConfig_ServiceName != null)
            {
                requestResourceConfig_resourceConfig_ServiceName = cmdletContext.ResourceConfig_ServiceName;
            }
            if (requestResourceConfig_resourceConfig_ServiceName != null)
            {
                request.ResourceConfig.ServiceName = requestResourceConfig_resourceConfig_ServiceName;
                requestResourceConfigIsNull = false;
            }
            Amazon.AmplifyBackend.Model.BackendStoragePermissions requestResourceConfig_resourceConfig_Permissions = null;
            
             // populate Permissions
            var requestResourceConfig_resourceConfig_PermissionsIsNull = true;
            requestResourceConfig_resourceConfig_Permissions = new Amazon.AmplifyBackend.Model.BackendStoragePermissions();
            List<System.String> requestResourceConfig_resourceConfig_Permissions_permissions_Authenticated = null;
            if (cmdletContext.Permissions_Authenticated != null)
            {
                requestResourceConfig_resourceConfig_Permissions_permissions_Authenticated = cmdletContext.Permissions_Authenticated;
            }
            if (requestResourceConfig_resourceConfig_Permissions_permissions_Authenticated != null)
            {
                requestResourceConfig_resourceConfig_Permissions.Authenticated = requestResourceConfig_resourceConfig_Permissions_permissions_Authenticated;
                requestResourceConfig_resourceConfig_PermissionsIsNull = false;
            }
            List<System.String> requestResourceConfig_resourceConfig_Permissions_permissions_UnAuthenticated = null;
            if (cmdletContext.Permissions_UnAuthenticated != null)
            {
                requestResourceConfig_resourceConfig_Permissions_permissions_UnAuthenticated = cmdletContext.Permissions_UnAuthenticated;
            }
            if (requestResourceConfig_resourceConfig_Permissions_permissions_UnAuthenticated != null)
            {
                requestResourceConfig_resourceConfig_Permissions.UnAuthenticated = requestResourceConfig_resourceConfig_Permissions_permissions_UnAuthenticated;
                requestResourceConfig_resourceConfig_PermissionsIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_Permissions should be set to null
            if (requestResourceConfig_resourceConfig_PermissionsIsNull)
            {
                requestResourceConfig_resourceConfig_Permissions = null;
            }
            if (requestResourceConfig_resourceConfig_Permissions != null)
            {
                request.ResourceConfig.Permissions = requestResourceConfig_resourceConfig_Permissions;
                requestResourceConfigIsNull = false;
            }
             // determine if request.ResourceConfig should be set to null
            if (requestResourceConfigIsNull)
            {
                request.ResourceConfig = null;
            }
            if (cmdletContext.ResourceName != null)
            {
                request.ResourceName = cmdletContext.ResourceName;
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
        
        private Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse CallAWSServiceOperation(IAmazonAmplifyBackend client, Amazon.AmplifyBackend.Model.UpdateBackendStorageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amplify Backend", "UpdateBackendStorage");
            try
            {
                return client.UpdateBackendStorageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AppId { get; set; }
            public System.String BackendEnvironmentName { get; set; }
            public List<System.String> Permissions_Authenticated { get; set; }
            public List<System.String> Permissions_UnAuthenticated { get; set; }
            public Amazon.AmplifyBackend.ServiceName ResourceConfig_ServiceName { get; set; }
            public System.String ResourceName { get; set; }
            public System.Func<Amazon.AmplifyBackend.Model.UpdateBackendStorageResponse, UpdateAMPBBackendStorageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
