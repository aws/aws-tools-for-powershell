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
using Amazon.NetworkFlowMonitor;
using Amazon.NetworkFlowMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.NFM
{
    /// <summary>
    /// Update a monitor to add or remove local or remote resources.
    /// </summary>
    [Cmdlet("Update", "NFMMonitor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse")]
    [AWSCmdlet("Calls the Network Flow Monitor UpdateMonitor API operation.", Operation = new[] {"UpdateMonitor"}, SelectReturnType = typeof(Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse))]
    [AWSCmdletOutput("Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse",
        "This cmdlet returns an Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse object containing multiple properties."
    )]
    public partial class UpdateNFMMonitorCmdlet : AmazonNetworkFlowMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LocalResourcesToAdd
        /// <summary>
        /// <para>
        /// <para>Additional local resources to specify network flows for a monitor, as an array of
        /// resources with identifiers and types. A local resource in a workload is the location
        /// of hosts where the Network Flow Monitor agent is installed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFlowMonitor.Model.MonitorLocalResource[] LocalResourcesToAdd { get; set; }
        #endregion
        
        #region Parameter LocalResourcesToRemove
        /// <summary>
        /// <para>
        /// <para>The local resources to remove, as an array of resources with identifiers and types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFlowMonitor.Model.MonitorLocalResource[] LocalResourcesToRemove { get; set; }
        #endregion
        
        #region Parameter MonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the monitor.</para>
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
        public System.String MonitorName { get; set; }
        #endregion
        
        #region Parameter RemoteResourcesToAdd
        /// <summary>
        /// <para>
        /// <para>The remote resources to add, as an array of resources with identifiers and types.</para><para>A remote resource is the other endpoint in the flow of a workload, with a local resource.
        /// For example, Amazon Dynamo DB can be a remote resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource[] RemoteResourcesToAdd { get; set; }
        #endregion
        
        #region Parameter RemoteResourcesToRemove
        /// <summary>
        /// <para>
        /// <para>The remote resources to remove, as an array of resources with identifiers and types.</para><para>A remote resource is the other endpoint specified for the network flow of a workload,
        /// with a local resource. For example, Amazon Dynamo DB can be a remote resource. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource[] RemoteResourcesToRemove { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive string of up to 64 ASCII characters that you specify to make
        /// an idempotent API request. Don't reuse the same client token for other API requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse).
        /// Specifying the name of a property of type Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MonitorName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MonitorName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MonitorName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MonitorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NFMMonitor (UpdateMonitor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse, UpdateNFMMonitorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MonitorName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.LocalResourcesToAdd != null)
            {
                context.LocalResourcesToAdd = new List<Amazon.NetworkFlowMonitor.Model.MonitorLocalResource>(this.LocalResourcesToAdd);
            }
            if (this.LocalResourcesToRemove != null)
            {
                context.LocalResourcesToRemove = new List<Amazon.NetworkFlowMonitor.Model.MonitorLocalResource>(this.LocalResourcesToRemove);
            }
            context.MonitorName = this.MonitorName;
            #if MODULAR
            if (this.MonitorName == null && ParameterWasBound(nameof(this.MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoteResourcesToAdd != null)
            {
                context.RemoteResourcesToAdd = new List<Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource>(this.RemoteResourcesToAdd);
            }
            if (this.RemoteResourcesToRemove != null)
            {
                context.RemoteResourcesToRemove = new List<Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource>(this.RemoteResourcesToRemove);
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
            var request = new Amazon.NetworkFlowMonitor.Model.UpdateMonitorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LocalResourcesToAdd != null)
            {
                request.LocalResourcesToAdd = cmdletContext.LocalResourcesToAdd;
            }
            if (cmdletContext.LocalResourcesToRemove != null)
            {
                request.LocalResourcesToRemove = cmdletContext.LocalResourcesToRemove;
            }
            if (cmdletContext.MonitorName != null)
            {
                request.MonitorName = cmdletContext.MonitorName;
            }
            if (cmdletContext.RemoteResourcesToAdd != null)
            {
                request.RemoteResourcesToAdd = cmdletContext.RemoteResourcesToAdd;
            }
            if (cmdletContext.RemoteResourcesToRemove != null)
            {
                request.RemoteResourcesToRemove = cmdletContext.RemoteResourcesToRemove;
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
        
        private Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse CallAWSServiceOperation(IAmazonNetworkFlowMonitor client, Amazon.NetworkFlowMonitor.Model.UpdateMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Network Flow Monitor", "UpdateMonitor");
            try
            {
                #if DESKTOP
                return client.UpdateMonitor(request);
                #elif CORECLR
                return client.UpdateMonitorAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public List<Amazon.NetworkFlowMonitor.Model.MonitorLocalResource> LocalResourcesToAdd { get; set; }
            public List<Amazon.NetworkFlowMonitor.Model.MonitorLocalResource> LocalResourcesToRemove { get; set; }
            public System.String MonitorName { get; set; }
            public List<Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource> RemoteResourcesToAdd { get; set; }
            public List<Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource> RemoteResourcesToRemove { get; set; }
            public System.Func<Amazon.NetworkFlowMonitor.Model.UpdateMonitorResponse, UpdateNFMMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
