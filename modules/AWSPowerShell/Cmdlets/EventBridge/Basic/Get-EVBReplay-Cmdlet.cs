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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Retrieves details about a replay. Use <c>DescribeReplay</c> to determine the progress
    /// of a running replay. A replay processes events to replay based on the time in the
    /// event, and replays them using 1 minute intervals. If you use <c>StartReplay</c> and
    /// specify an <c>EventStartTime</c> and an <c>EventEndTime</c> that covers a 20 minute
    /// time range, the events are replayed from the first minute of that 20 minute range
    /// first. Then the events from the second minute are replayed. You can use <c>DescribeReplay</c>
    /// to determine the progress of a replay. The value returned for <c>EventLastReplayedTime</c>
    /// indicates the time within the specified time range associated with the last event
    /// replayed.
    /// </summary>
    [Cmdlet("Get", "EVBReplay")]
    [OutputType("Amazon.EventBridge.Model.DescribeReplayResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge DescribeReplay API operation.", Operation = new[] {"DescribeReplay"}, SelectReturnType = typeof(Amazon.EventBridge.Model.DescribeReplayResponse))]
    [AWSCmdletOutput("Amazon.EventBridge.Model.DescribeReplayResponse",
        "This cmdlet returns an Amazon.EventBridge.Model.DescribeReplayResponse object containing multiple properties."
    )]
    public partial class GetEVBReplayCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ReplayName
        /// <summary>
        /// <para>
        /// <para>The name of the replay to retrieve.</para>
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
        public System.String ReplayName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.DescribeReplayResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.DescribeReplayResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.DescribeReplayResponse, GetEVBReplayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ReplayName = this.ReplayName;
            #if MODULAR
            if (this.ReplayName == null && ParameterWasBound(nameof(this.ReplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EventBridge.Model.DescribeReplayRequest();
            
            if (cmdletContext.ReplayName != null)
            {
                request.ReplayName = cmdletContext.ReplayName;
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
        
        private Amazon.EventBridge.Model.DescribeReplayResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.DescribeReplayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "DescribeReplay");
            try
            {
                return client.DescribeReplayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ReplayName { get; set; }
            public System.Func<Amazon.EventBridge.Model.DescribeReplayResponse, GetEVBReplayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
