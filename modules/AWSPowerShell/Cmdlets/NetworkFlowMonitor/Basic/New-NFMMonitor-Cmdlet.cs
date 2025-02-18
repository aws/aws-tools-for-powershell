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
using Amazon.NetworkFlowMonitor;
using Amazon.NetworkFlowMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.NFM
{
    /// <summary>
    /// Create a monitor for specific network flows between local and remote resources, so
    /// that you can monitor network performance for one or several of your workloads. For
    /// each monitor, Network Flow Monitor publishes detailed end-to-end performance metrics
    /// and a network health indicators (NHI) that informs you whether there were Amazon Web
    /// Services network issues for one or more of the network flows tracked by a monitor,
    /// during a time period that you choose.
    /// </summary>
    [Cmdlet("New", "NFMMonitor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse")]
    [AWSCmdlet("Calls the Network Flow Monitor CreateMonitor API operation.", Operation = new[] {"CreateMonitor"}, SelectReturnType = typeof(Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse))]
    [AWSCmdletOutput("Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse",
        "This cmdlet returns an Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse object containing multiple properties."
    )]
    public partial class NewNFMMonitorCmdlet : AmazonNetworkFlowMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LocalResource
        /// <summary>
        /// <para>
        /// <para>The local resources to monitor. A local resource, in a bi-directional flow of a workload,
        /// is the host where the agent is installed. For example, if a workload consists of an
        /// interaction between a web service and a backend database (for example, Amazon Relational
        /// Database Service (RDS)), the EC2 instance hosting the web service, which also runs
        /// the agent, is the local resource.</para>
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
        [Alias("LocalResources")]
        public Amazon.NetworkFlowMonitor.Model.MonitorLocalResource[] LocalResource { get; set; }
        #endregion
        
        #region Parameter MonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the monitor. </para>
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
        
        #region Parameter RemoteResource
        /// <summary>
        /// <para>
        /// <para>The remote resources to monitor. A remote resource is the other endpoint in the bi-directional
        /// flow of a workload, with a local resource. For example, Amazon Relational Database
        /// Service (RDS) can be a remote resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RemoteResources")]
        public Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource[] RemoteResource { get; set; }
        #endregion
        
        #region Parameter ScopeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the scope for the monitor.</para>
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
        public System.String ScopeArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for a monitor. You can add a maximum of 200 tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse).
        /// Specifying the name of a property of type Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MonitorName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NFMMonitor (CreateMonitor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse, NewNFMMonitorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.LocalResource != null)
            {
                context.LocalResource = new List<Amazon.NetworkFlowMonitor.Model.MonitorLocalResource>(this.LocalResource);
            }
            #if MODULAR
            if (this.LocalResource == null && ParameterWasBound(nameof(this.LocalResource)))
            {
                WriteWarning("You are passing $null as a value for parameter LocalResource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MonitorName = this.MonitorName;
            #if MODULAR
            if (this.MonitorName == null && ParameterWasBound(nameof(this.MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RemoteResource != null)
            {
                context.RemoteResource = new List<Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource>(this.RemoteResource);
            }
            context.ScopeArn = this.ScopeArn;
            #if MODULAR
            if (this.ScopeArn == null && ParameterWasBound(nameof(this.ScopeArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
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
            var request = new Amazon.NetworkFlowMonitor.Model.CreateMonitorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.LocalResource != null)
            {
                request.LocalResources = cmdletContext.LocalResource;
            }
            if (cmdletContext.MonitorName != null)
            {
                request.MonitorName = cmdletContext.MonitorName;
            }
            if (cmdletContext.RemoteResource != null)
            {
                request.RemoteResources = cmdletContext.RemoteResource;
            }
            if (cmdletContext.ScopeArn != null)
            {
                request.ScopeArn = cmdletContext.ScopeArn;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse CallAWSServiceOperation(IAmazonNetworkFlowMonitor client, Amazon.NetworkFlowMonitor.Model.CreateMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Network Flow Monitor", "CreateMonitor");
            try
            {
                return client.CreateMonitorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.NetworkFlowMonitor.Model.MonitorLocalResource> LocalResource { get; set; }
            public System.String MonitorName { get; set; }
            public List<Amazon.NetworkFlowMonitor.Model.MonitorRemoteResource> RemoteResource { get; set; }
            public System.String ScopeArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.NetworkFlowMonitor.Model.CreateMonitorResponse, NewNFMMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
