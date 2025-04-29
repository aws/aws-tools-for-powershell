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
using Amazon.IoTJobsDataPlane;
using Amazon.IoTJobsDataPlane.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTJ
{
    /// <summary>
    /// Using the command created with the <c>CreateCommand</c> API, start a command execution
    /// on a specific device.
    /// </summary>
    [Cmdlet("Start", "IOTJCommandExecution", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT Jobs Data Plane StartCommandExecution API operation.", Operation = new[] {"StartCommandExecution"}, SelectReturnType = typeof(Amazon.IoTJobsDataPlane.Model.StartCommandExecutionResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTJobsDataPlane.Model.StartCommandExecutionResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTJobsDataPlane.Model.StartCommandExecutionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIOTJCommandExecutionCmdlet : AmazonIoTJobsDataPlaneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CommandArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the command. For example, <c>arn:aws:iot:&lt;region&gt;:&lt;accountid&gt;:command/&lt;commandName&gt;</c></para>
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
        public System.String CommandArn { get; set; }
        #endregion
        
        #region Parameter ExecutionTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>Specifies the amount of time in second the device has to finish the command execution.
        /// A timer is started as soon as the command execution is created. If the command execution
        /// status is not set to another terminal state before the timer expires, it will automatically
        /// update to <c>TIMED_OUT</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExecutionTimeoutSeconds")]
        public System.Int64? ExecutionTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter Parameter
        /// <summary>
        /// <para>
        /// <para>A list of parameters that are required by the <c>StartCommandExecution</c> API when
        /// performing the command on a device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Parameters")]
        public System.Collections.Hashtable Parameter { get; set; }
        #endregion
        
        #region Parameter TargetArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the device where the command execution is occurring.</para>
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
        public System.String TargetArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The client token is used to implement idempotency. It ensures that the request completes
        /// no more than one time. If you retry a request with the same token and the same parameters,
        /// the request will complete successfully. However, if you retry the request using the
        /// same token but different parameters, an HTTP 409 conflict occurs. If you omit this
        /// value, Amazon Web Services SDKs will automatically generate a unique client request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ExecutionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTJobsDataPlane.Model.StartCommandExecutionResponse).
        /// Specifying the name of a property of type Amazon.IoTJobsDataPlane.Model.StartCommandExecutionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ExecutionId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTJCommandExecution (StartCommandExecution)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTJobsDataPlane.Model.StartCommandExecutionResponse, StartIOTJCommandExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.CommandArn = this.CommandArn;
            #if MODULAR
            if (this.CommandArn == null && ParameterWasBound(nameof(this.CommandArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CommandArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionTimeoutSecond = this.ExecutionTimeoutSecond;
            if (this.Parameter != null)
            {
                context.Parameter = new Dictionary<System.String, Amazon.IoTJobsDataPlane.Model.CommandParameterValue>(StringComparer.Ordinal);
                foreach (var hashKey in this.Parameter.Keys)
                {
                    context.Parameter.Add((String)hashKey, (Amazon.IoTJobsDataPlane.Model.CommandParameterValue)(this.Parameter[hashKey]));
                }
            }
            context.TargetArn = this.TargetArn;
            #if MODULAR
            if (this.TargetArn == null && ParameterWasBound(nameof(this.TargetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTJobsDataPlane.Model.StartCommandExecutionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CommandArn != null)
            {
                request.CommandArn = cmdletContext.CommandArn;
            }
            if (cmdletContext.ExecutionTimeoutSecond != null)
            {
                request.ExecutionTimeoutSeconds = cmdletContext.ExecutionTimeoutSecond.Value;
            }
            if (cmdletContext.Parameter != null)
            {
                request.Parameters = cmdletContext.Parameter;
            }
            if (cmdletContext.TargetArn != null)
            {
                request.TargetArn = cmdletContext.TargetArn;
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
        
        private Amazon.IoTJobsDataPlane.Model.StartCommandExecutionResponse CallAWSServiceOperation(IAmazonIoTJobsDataPlane client, Amazon.IoTJobsDataPlane.Model.StartCommandExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Jobs Data Plane", "StartCommandExecution");
            try
            {
                return client.StartCommandExecutionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CommandArn { get; set; }
            public System.Int64? ExecutionTimeoutSecond { get; set; }
            public Dictionary<System.String, Amazon.IoTJobsDataPlane.Model.CommandParameterValue> Parameter { get; set; }
            public System.String TargetArn { get; set; }
            public System.Func<Amazon.IoTJobsDataPlane.Model.StartCommandExecutionResponse, StartIOTJCommandExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ExecutionId;
        }
        
    }
}
