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
using Amazon.NetworkMonitor;
using Amazon.NetworkMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.CWNM
{
    /// <summary>
    /// Returns the details about a probe. This action requires both the <c>monitorName</c>
    /// and <c>probeId</c> parameters. Run <c>ListMonitors</c> to get a list of monitor names.
    /// Run <c>GetMonitor</c> to get a list of probes and probe IDs.
    /// </summary>
    [Cmdlet("Get", "CWNMProbe")]
    [OutputType("Amazon.NetworkMonitor.Model.GetProbeResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Network Monitor GetProbe API operation.", Operation = new[] {"GetProbe"}, SelectReturnType = typeof(Amazon.NetworkMonitor.Model.GetProbeResponse))]
    [AWSCmdletOutput("Amazon.NetworkMonitor.Model.GetProbeResponse",
        "This cmdlet returns an Amazon.NetworkMonitor.Model.GetProbeResponse object containing multiple properties."
    )]
    public partial class GetCWNMProbeCmdlet : AmazonNetworkMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MonitorName
        /// <summary>
        /// <para>
        /// <para>The name of the monitor associated with the probe. Run <c>ListMonitors</c> to get
        /// a list of monitor names.</para>
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
        
        #region Parameter ProbeId
        /// <summary>
        /// <para>
        /// <para>The ID of the probe to get information about. Run <c>GetMonitor</c> action to get
        /// a list of probes and probe IDs for the monitor.</para>
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
        public System.String ProbeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkMonitor.Model.GetProbeResponse).
        /// Specifying the name of a property of type Amazon.NetworkMonitor.Model.GetProbeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkMonitor.Model.GetProbeResponse, GetCWNMProbeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.MonitorName = this.MonitorName;
            #if MODULAR
            if (this.MonitorName == null && ParameterWasBound(nameof(this.MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProbeId = this.ProbeId;
            #if MODULAR
            if (this.ProbeId == null && ParameterWasBound(nameof(this.ProbeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProbeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkMonitor.Model.GetProbeRequest();
            
            if (cmdletContext.MonitorName != null)
            {
                request.MonitorName = cmdletContext.MonitorName;
            }
            if (cmdletContext.ProbeId != null)
            {
                request.ProbeId = cmdletContext.ProbeId;
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
        
        private Amazon.NetworkMonitor.Model.GetProbeResponse CallAWSServiceOperation(IAmazonNetworkMonitor client, Amazon.NetworkMonitor.Model.GetProbeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Network Monitor", "GetProbe");
            try
            {
                #if DESKTOP
                return client.GetProbe(request);
                #elif CORECLR
                return client.GetProbeAsync(request).GetAwaiter().GetResult();
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
            public System.String MonitorName { get; set; }
            public System.String ProbeId { get; set; }
            public System.Func<Amazon.NetworkMonitor.Model.GetProbeResponse, GetCWNMProbeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
