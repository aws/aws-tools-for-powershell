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
using Amazon.DataSync;
using Amazon.DataSync.Model;

namespace Amazon.PowerShell.Cmdlets.DSYN
{
    /// <summary>
    /// Modifies the following configuration parameters of the Network File System (NFS) transfer
    /// location that you're using with DataSync.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-nfs-location.html">Configuring
    /// transfers with an NFS file server</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "DSYNLocationNfs", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS DataSync UpdateLocationNfs API operation.", Operation = new[] {"UpdateLocationNfs"}, SelectReturnType = typeof(Amazon.DataSync.Model.UpdateLocationNfsResponse))]
    [AWSCmdletOutput("None or Amazon.DataSync.Model.UpdateLocationNfsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataSync.Model.UpdateLocationNfsResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateDSYNLocationNfsCmdlet : AmazonDataSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OnPremConfig_AgentArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Names (ARNs) of the DataSync agents that can connect to your NFS
        /// file server.</para><para>You can specify more than one agent. For more information, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/do-i-need-datasync-agent.html#multiple-agents">Using
        /// multiple DataSync agents</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("OnPremConfig_AgentArns")]
        public System.String[] OnPremConfig_AgentArn { get; set; }
        #endregion
        
        #region Parameter LocationArn
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Resource Name (ARN) of the NFS transfer location that you want
        /// to update.</para>
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
        public System.String LocationArn { get; set; }
        #endregion
        
        #region Parameter Subdirectory
        /// <summary>
        /// <para>
        /// <para>Specifies the export path in your NFS file server that you want DataSync to mount.</para><para>This path (or a subdirectory of the path) is where DataSync transfers data to or from.
        /// For information on configuring an export for DataSync, see <a href="https://docs.aws.amazon.com/datasync/latest/userguide/create-nfs-location.html#accessing-nfs">Accessing
        /// NFS file servers</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Subdirectory { get; set; }
        #endregion
        
        #region Parameter MountOptions_Version
        /// <summary>
        /// <para>
        /// <para>Specifies the NFS version that you want DataSync to use when mounting your NFS share.
        /// If the server refuses to use the version specified, the task fails.</para><para>You can specify the following options:</para><ul><li><para><c>AUTOMATIC</c> (default): DataSync chooses NFS version 4.1.</para></li><li><para><c>NFS3</c>: Stateless protocol version that allows for asynchronous writes on the
        /// server.</para></li><li><para><c>NFSv4_0</c>: Stateful, firewall-friendly protocol version that supports delegations
        /// and pseudo file systems.</para></li><li><para><c>NFSv4_1</c>: Stateful protocol version that supports sessions, directory delegations,
        /// and parallel data processing. NFS version 4.1 also includes all features available
        /// in version 4.0.</para></li></ul><note><para>DataSync currently only supports NFS version 3 with Amazon FSx for NetApp ONTAP locations.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.DataSync.NfsVersion")]
        public Amazon.DataSync.NfsVersion MountOptions_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataSync.Model.UpdateLocationNfsResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LocationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-DSYNLocationNfs (UpdateLocationNfs)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataSync.Model.UpdateLocationNfsResponse, UpdateDSYNLocationNfsCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LocationArn = this.LocationArn;
            #if MODULAR
            if (this.LocationArn == null && ParameterWasBound(nameof(this.LocationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LocationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MountOptions_Version = this.MountOptions_Version;
            if (this.OnPremConfig_AgentArn != null)
            {
                context.OnPremConfig_AgentArn = new List<System.String>(this.OnPremConfig_AgentArn);
            }
            context.Subdirectory = this.Subdirectory;
            
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
            var request = new Amazon.DataSync.Model.UpdateLocationNfsRequest();
            
            if (cmdletContext.LocationArn != null)
            {
                request.LocationArn = cmdletContext.LocationArn;
            }
            
             // populate MountOptions
            var requestMountOptionsIsNull = true;
            request.MountOptions = new Amazon.DataSync.Model.NfsMountOptions();
            Amazon.DataSync.NfsVersion requestMountOptions_mountOptions_Version = null;
            if (cmdletContext.MountOptions_Version != null)
            {
                requestMountOptions_mountOptions_Version = cmdletContext.MountOptions_Version;
            }
            if (requestMountOptions_mountOptions_Version != null)
            {
                request.MountOptions.Version = requestMountOptions_mountOptions_Version;
                requestMountOptionsIsNull = false;
            }
             // determine if request.MountOptions should be set to null
            if (requestMountOptionsIsNull)
            {
                request.MountOptions = null;
            }
            
             // populate OnPremConfig
            var requestOnPremConfigIsNull = true;
            request.OnPremConfig = new Amazon.DataSync.Model.OnPremConfig();
            List<System.String> requestOnPremConfig_onPremConfig_AgentArn = null;
            if (cmdletContext.OnPremConfig_AgentArn != null)
            {
                requestOnPremConfig_onPremConfig_AgentArn = cmdletContext.OnPremConfig_AgentArn;
            }
            if (requestOnPremConfig_onPremConfig_AgentArn != null)
            {
                request.OnPremConfig.AgentArns = requestOnPremConfig_onPremConfig_AgentArn;
                requestOnPremConfigIsNull = false;
            }
             // determine if request.OnPremConfig should be set to null
            if (requestOnPremConfigIsNull)
            {
                request.OnPremConfig = null;
            }
            if (cmdletContext.Subdirectory != null)
            {
                request.Subdirectory = cmdletContext.Subdirectory;
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
        
        private Amazon.DataSync.Model.UpdateLocationNfsResponse CallAWSServiceOperation(IAmazonDataSync client, Amazon.DataSync.Model.UpdateLocationNfsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS DataSync", "UpdateLocationNfs");
            try
            {
                return client.UpdateLocationNfsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LocationArn { get; set; }
            public Amazon.DataSync.NfsVersion MountOptions_Version { get; set; }
            public List<System.String> OnPremConfig_AgentArn { get; set; }
            public System.String Subdirectory { get; set; }
            public System.Func<Amazon.DataSync.Model.UpdateLocationNfsResponse, UpdateDSYNLocationNfsCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
