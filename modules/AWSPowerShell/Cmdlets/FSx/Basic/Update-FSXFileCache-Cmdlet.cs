/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.FSx;
using Amazon.FSx.Model;

namespace Amazon.PowerShell.Cmdlets.FSX
{
    /// <summary>
    /// Updates the configuration of an existing Amazon File Cache resource. You can update
    /// multiple properties in a single request.
    /// </summary>
    [Cmdlet("Update", "FSXFileCache", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.FSx.Model.FileCache")]
    [AWSCmdlet("Calls the Amazon FSx UpdateFileCache API operation.", Operation = new[] {"UpdateFileCache"}, SelectReturnType = typeof(Amazon.FSx.Model.UpdateFileCacheResponse))]
    [AWSCmdletOutput("Amazon.FSx.Model.FileCache or Amazon.FSx.Model.UpdateFileCacheResponse",
        "This cmdlet returns an Amazon.FSx.Model.FileCache object.",
        "The service call response (type Amazon.FSx.Model.UpdateFileCacheResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateFSXFileCacheCmdlet : AmazonFSxClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter FileCacheId
        /// <summary>
        /// <para>
        /// <para>The ID of the cache that you are updating.</para>
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
        public System.String FileCacheId { get; set; }
        #endregion
        
        #region Parameter LustreConfiguration_WeeklyMaintenanceStartTime
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LustreConfiguration_WeeklyMaintenanceStartTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FileCache'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FSx.Model.UpdateFileCacheResponse).
        /// Specifying the name of a property of type Amazon.FSx.Model.UpdateFileCacheResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FileCache";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileCacheId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-FSXFileCache (UpdateFileCache)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FSx.Model.UpdateFileCacheResponse, UpdateFSXFileCacheCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            context.FileCacheId = this.FileCacheId;
            #if MODULAR
            if (this.FileCacheId == null && ParameterWasBound(nameof(this.FileCacheId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileCacheId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LustreConfiguration_WeeklyMaintenanceStartTime = this.LustreConfiguration_WeeklyMaintenanceStartTime;
            
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
            var request = new Amazon.FSx.Model.UpdateFileCacheRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.FileCacheId != null)
            {
                request.FileCacheId = cmdletContext.FileCacheId;
            }
            
             // populate LustreConfiguration
            var requestLustreConfigurationIsNull = true;
            request.LustreConfiguration = new Amazon.FSx.Model.UpdateFileCacheLustreConfiguration();
            System.String requestLustreConfiguration_lustreConfiguration_WeeklyMaintenanceStartTime = null;
            if (cmdletContext.LustreConfiguration_WeeklyMaintenanceStartTime != null)
            {
                requestLustreConfiguration_lustreConfiguration_WeeklyMaintenanceStartTime = cmdletContext.LustreConfiguration_WeeklyMaintenanceStartTime;
            }
            if (requestLustreConfiguration_lustreConfiguration_WeeklyMaintenanceStartTime != null)
            {
                request.LustreConfiguration.WeeklyMaintenanceStartTime = requestLustreConfiguration_lustreConfiguration_WeeklyMaintenanceStartTime;
                requestLustreConfigurationIsNull = false;
            }
             // determine if request.LustreConfiguration should be set to null
            if (requestLustreConfigurationIsNull)
            {
                request.LustreConfiguration = null;
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
        
        private Amazon.FSx.Model.UpdateFileCacheResponse CallAWSServiceOperation(IAmazonFSx client, Amazon.FSx.Model.UpdateFileCacheRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon FSx", "UpdateFileCache");
            try
            {
                #if DESKTOP
                return client.UpdateFileCache(request);
                #elif CORECLR
                return client.UpdateFileCacheAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public System.String FileCacheId { get; set; }
            public System.String LustreConfiguration_WeeklyMaintenanceStartTime { get; set; }
            public System.Func<Amazon.FSx.Model.UpdateFileCacheResponse, UpdateFSXFileCacheCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FileCache;
        }
        
    }
}
