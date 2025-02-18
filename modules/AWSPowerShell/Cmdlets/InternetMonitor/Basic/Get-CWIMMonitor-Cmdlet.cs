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
using Amazon.InternetMonitor;
using Amazon.InternetMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.CWIM
{
    /// <summary>
    /// Gets information about a monitor in Amazon CloudWatch Internet Monitor based on a
    /// monitor name. The information returned includes the Amazon Resource Name (ARN), create
    /// time, modified time, resources included in the monitor, and status information.
    /// </summary>
    [Cmdlet("Get", "CWIMMonitor")]
    [OutputType("Amazon.InternetMonitor.Model.GetMonitorResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Internet Monitor GetMonitor API operation.", Operation = new[] {"GetMonitor"}, SelectReturnType = typeof(Amazon.InternetMonitor.Model.GetMonitorResponse))]
    [AWSCmdletOutput("Amazon.InternetMonitor.Model.GetMonitorResponse",
        "This cmdlet returns an Amazon.InternetMonitor.Model.GetMonitorResponse object containing multiple properties."
    )]
    public partial class GetCWIMMonitorCmdlet : AmazonInternetMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LinkedAccountId
        /// <summary>
        /// <para>
        /// <para>The account ID for an account that you've set up cross-account sharing for in Amazon
        /// CloudWatch Internet Monitor. You configure cross-account sharing by using Amazon CloudWatch
        /// Observability Access Manager. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/cwim-cross-account.html">Internet
        /// Monitor cross-account observability</a> in the Amazon CloudWatch Internet Monitor
        /// User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LinkedAccountId { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.InternetMonitor.Model.GetMonitorResponse).
        /// Specifying the name of a property of type Amazon.InternetMonitor.Model.GetMonitorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.InternetMonitor.Model.GetMonitorResponse, GetCWIMMonitorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LinkedAccountId = this.LinkedAccountId;
            context.MonitorName = this.MonitorName;
            #if MODULAR
            if (this.MonitorName == null && ParameterWasBound(nameof(this.MonitorName)))
            {
                WriteWarning("You are passing $null as a value for parameter MonitorName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.InternetMonitor.Model.GetMonitorRequest();
            
            if (cmdletContext.LinkedAccountId != null)
            {
                request.LinkedAccountId = cmdletContext.LinkedAccountId;
            }
            if (cmdletContext.MonitorName != null)
            {
                request.MonitorName = cmdletContext.MonitorName;
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
        
        private Amazon.InternetMonitor.Model.GetMonitorResponse CallAWSServiceOperation(IAmazonInternetMonitor client, Amazon.InternetMonitor.Model.GetMonitorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Internet Monitor", "GetMonitor");
            try
            {
                return client.GetMonitorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LinkedAccountId { get; set; }
            public System.String MonitorName { get; set; }
            public System.Func<Amazon.InternetMonitor.Model.GetMonitorResponse, GetCWIMMonitorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
