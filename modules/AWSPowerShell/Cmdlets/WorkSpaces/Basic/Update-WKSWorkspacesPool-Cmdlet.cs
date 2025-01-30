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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Updates the specified pool.
    /// </summary>
    [Cmdlet("Update", "WKSWorkspacesPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpaces.Model.WorkspacesPool")]
    [AWSCmdlet("Calls the Amazon WorkSpaces UpdateWorkspacesPool API operation.", Operation = new[] {"UpdateWorkspacesPool"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.UpdateWorkspacesPoolResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.WorkspacesPool or Amazon.WorkSpaces.Model.UpdateWorkspacesPoolResponse",
        "This cmdlet returns an Amazon.WorkSpaces.Model.WorkspacesPool object.",
        "The service call response (type Amazon.WorkSpaces.Model.UpdateWorkspacesPoolResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWKSWorkspacesPoolCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BundleId
        /// <summary>
        /// <para>
        /// <para>The identifier of the bundle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BundleId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Describes the specified pool to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Capacity_DesiredUserSession
        /// <summary>
        /// <para>
        /// <para>The desired number of user sessions for the WorkSpaces in the pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Capacity_DesiredUserSessions")]
        public System.Int32? Capacity_DesiredUserSession { get; set; }
        #endregion
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the directory.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter TimeoutSettings_DisconnectTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of time, in seconds, that a streaming session remains active
        /// after users disconnect. If users try to reconnect to the streaming session after a
        /// disconnection or network interruption within the time set, they are connected to their
        /// previous session. Otherwise, they are connected to a new session with a new streaming
        /// instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutSettings_DisconnectTimeoutInSeconds")]
        public System.Int32? TimeoutSettings_DisconnectTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter TimeoutSettings_IdleDisconnectTimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>The amount of time in seconds a connection will stay active while idle.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutSettings_IdleDisconnectTimeoutInSeconds")]
        public System.Int32? TimeoutSettings_IdleDisconnectTimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter TimeoutSettings_MaxUserDurationInSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum amount of time, in seconds, that a streaming session can remain
        /// active. If users are still connected to a streaming instance five minutes before this
        /// limit is reached, they are prompted to save any open documents before being disconnected.
        /// After this time elapses, the instance is terminated and replaced by a new instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutSettings_MaxUserDurationInSeconds")]
        public System.Int32? TimeoutSettings_MaxUserDurationInSecond { get; set; }
        #endregion
        
        #region Parameter PoolId
        /// <summary>
        /// <para>
        /// <para>The identifier of the specified pool to update.</para>
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
        public System.String PoolId { get; set; }
        #endregion
        
        #region Parameter ApplicationSettings_SettingsGroup
        /// <summary>
        /// <para>
        /// <para>The path prefix for the S3 bucket where users’ persistent application settings are
        /// stored. You can allow the same persistent application settings to be used across multiple
        /// pools by specifying the same settings group for each pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ApplicationSettings_SettingsGroup { get; set; }
        #endregion
        
        #region Parameter ApplicationSettings_Status
        /// <summary>
        /// <para>
        /// <para>Enables or disables persistent application settings for users during their pool sessions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.WorkSpaces.ApplicationSettingsStatusEnum")]
        public Amazon.WorkSpaces.ApplicationSettingsStatusEnum ApplicationSettings_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WorkspacesPool'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.UpdateWorkspacesPoolResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.UpdateWorkspacesPoolResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WorkspacesPool";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PoolId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PoolId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PoolId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WKSWorkspacesPool (UpdateWorkspacesPool)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.UpdateWorkspacesPoolResponse, UpdateWKSWorkspacesPoolCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PoolId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationSettings_SettingsGroup = this.ApplicationSettings_SettingsGroup;
            context.ApplicationSettings_Status = this.ApplicationSettings_Status;
            context.BundleId = this.BundleId;
            context.Capacity_DesiredUserSession = this.Capacity_DesiredUserSession;
            context.Description = this.Description;
            context.DirectoryId = this.DirectoryId;
            context.PoolId = this.PoolId;
            #if MODULAR
            if (this.PoolId == null && ParameterWasBound(nameof(this.PoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter PoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeoutSettings_DisconnectTimeoutInSecond = this.TimeoutSettings_DisconnectTimeoutInSecond;
            context.TimeoutSettings_IdleDisconnectTimeoutInSecond = this.TimeoutSettings_IdleDisconnectTimeoutInSecond;
            context.TimeoutSettings_MaxUserDurationInSecond = this.TimeoutSettings_MaxUserDurationInSecond;
            
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
            var request = new Amazon.WorkSpaces.Model.UpdateWorkspacesPoolRequest();
            
            
             // populate ApplicationSettings
            var requestApplicationSettingsIsNull = true;
            request.ApplicationSettings = new Amazon.WorkSpaces.Model.ApplicationSettingsRequest();
            System.String requestApplicationSettings_applicationSettings_SettingsGroup = null;
            if (cmdletContext.ApplicationSettings_SettingsGroup != null)
            {
                requestApplicationSettings_applicationSettings_SettingsGroup = cmdletContext.ApplicationSettings_SettingsGroup;
            }
            if (requestApplicationSettings_applicationSettings_SettingsGroup != null)
            {
                request.ApplicationSettings.SettingsGroup = requestApplicationSettings_applicationSettings_SettingsGroup;
                requestApplicationSettingsIsNull = false;
            }
            Amazon.WorkSpaces.ApplicationSettingsStatusEnum requestApplicationSettings_applicationSettings_Status = null;
            if (cmdletContext.ApplicationSettings_Status != null)
            {
                requestApplicationSettings_applicationSettings_Status = cmdletContext.ApplicationSettings_Status;
            }
            if (requestApplicationSettings_applicationSettings_Status != null)
            {
                request.ApplicationSettings.Status = requestApplicationSettings_applicationSettings_Status;
                requestApplicationSettingsIsNull = false;
            }
             // determine if request.ApplicationSettings should be set to null
            if (requestApplicationSettingsIsNull)
            {
                request.ApplicationSettings = null;
            }
            if (cmdletContext.BundleId != null)
            {
                request.BundleId = cmdletContext.BundleId;
            }
            
             // populate Capacity
            var requestCapacityIsNull = true;
            request.Capacity = new Amazon.WorkSpaces.Model.Capacity();
            System.Int32? requestCapacity_capacity_DesiredUserSession = null;
            if (cmdletContext.Capacity_DesiredUserSession != null)
            {
                requestCapacity_capacity_DesiredUserSession = cmdletContext.Capacity_DesiredUserSession.Value;
            }
            if (requestCapacity_capacity_DesiredUserSession != null)
            {
                request.Capacity.DesiredUserSessions = requestCapacity_capacity_DesiredUserSession.Value;
                requestCapacityIsNull = false;
            }
             // determine if request.Capacity should be set to null
            if (requestCapacityIsNull)
            {
                request.Capacity = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.PoolId != null)
            {
                request.PoolId = cmdletContext.PoolId;
            }
            
             // populate TimeoutSettings
            var requestTimeoutSettingsIsNull = true;
            request.TimeoutSettings = new Amazon.WorkSpaces.Model.TimeoutSettings();
            System.Int32? requestTimeoutSettings_timeoutSettings_DisconnectTimeoutInSecond = null;
            if (cmdletContext.TimeoutSettings_DisconnectTimeoutInSecond != null)
            {
                requestTimeoutSettings_timeoutSettings_DisconnectTimeoutInSecond = cmdletContext.TimeoutSettings_DisconnectTimeoutInSecond.Value;
            }
            if (requestTimeoutSettings_timeoutSettings_DisconnectTimeoutInSecond != null)
            {
                request.TimeoutSettings.DisconnectTimeoutInSeconds = requestTimeoutSettings_timeoutSettings_DisconnectTimeoutInSecond.Value;
                requestTimeoutSettingsIsNull = false;
            }
            System.Int32? requestTimeoutSettings_timeoutSettings_IdleDisconnectTimeoutInSecond = null;
            if (cmdletContext.TimeoutSettings_IdleDisconnectTimeoutInSecond != null)
            {
                requestTimeoutSettings_timeoutSettings_IdleDisconnectTimeoutInSecond = cmdletContext.TimeoutSettings_IdleDisconnectTimeoutInSecond.Value;
            }
            if (requestTimeoutSettings_timeoutSettings_IdleDisconnectTimeoutInSecond != null)
            {
                request.TimeoutSettings.IdleDisconnectTimeoutInSeconds = requestTimeoutSettings_timeoutSettings_IdleDisconnectTimeoutInSecond.Value;
                requestTimeoutSettingsIsNull = false;
            }
            System.Int32? requestTimeoutSettings_timeoutSettings_MaxUserDurationInSecond = null;
            if (cmdletContext.TimeoutSettings_MaxUserDurationInSecond != null)
            {
                requestTimeoutSettings_timeoutSettings_MaxUserDurationInSecond = cmdletContext.TimeoutSettings_MaxUserDurationInSecond.Value;
            }
            if (requestTimeoutSettings_timeoutSettings_MaxUserDurationInSecond != null)
            {
                request.TimeoutSettings.MaxUserDurationInSeconds = requestTimeoutSettings_timeoutSettings_MaxUserDurationInSecond.Value;
                requestTimeoutSettingsIsNull = false;
            }
             // determine if request.TimeoutSettings should be set to null
            if (requestTimeoutSettingsIsNull)
            {
                request.TimeoutSettings = null;
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
        
        private Amazon.WorkSpaces.Model.UpdateWorkspacesPoolResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.UpdateWorkspacesPoolRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "UpdateWorkspacesPool");
            try
            {
                #if DESKTOP
                return client.UpdateWorkspacesPool(request);
                #elif CORECLR
                return client.UpdateWorkspacesPoolAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationSettings_SettingsGroup { get; set; }
            public Amazon.WorkSpaces.ApplicationSettingsStatusEnum ApplicationSettings_Status { get; set; }
            public System.String BundleId { get; set; }
            public System.Int32? Capacity_DesiredUserSession { get; set; }
            public System.String Description { get; set; }
            public System.String DirectoryId { get; set; }
            public System.String PoolId { get; set; }
            public System.Int32? TimeoutSettings_DisconnectTimeoutInSecond { get; set; }
            public System.Int32? TimeoutSettings_IdleDisconnectTimeoutInSecond { get; set; }
            public System.Int32? TimeoutSettings_MaxUserDurationInSecond { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.UpdateWorkspacesPoolResponse, UpdateWKSWorkspacesPoolCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WorkspacesPool;
        }
        
    }
}
