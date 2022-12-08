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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Sends a signal to an Automation execution to change the current behavior or status
    /// of the execution.
    /// </summary>
    [Cmdlet("Send", "SSMAutomationSignal", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager SendAutomationSignal API operation.", Operation = new[] {"SendAutomationSignal"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.SendAutomationSignalResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleSystemsManagement.Model.SendAutomationSignalResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleSystemsManagement.Model.SendAutomationSignalResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendSSMAutomationSignalCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter AutomationExecutionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for an existing Automation execution that you want to send the
        /// signal to.</para>
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
        public System.String AutomationExecutionId { get; set; }
        #endregion
        
        #region Parameter Payload
        /// <summary>
        /// <para>
        /// <para>The data sent with the signal. The data schema depends on the type of signal used
        /// in the request.</para><para>For <code>Approve</code> and <code>Reject</code> signal types, the payload is an optional
        /// comment that you can send with the signal type. For example:</para><para><code>Comment="Looks good"</code></para><para>For <code>StartStep</code> and <code>Resume</code> signal types, you must send the
        /// name of the Automation step to start or resume as the payload. For example:</para><para><code>StepName="step1"</code></para><para>For the <code>StopStep</code> signal type, you must send the step execution ID as
        /// the payload. For example:</para><para><code>StepExecutionId="97fff367-fc5a-4299-aed8-0123456789ab"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Payload { get; set; }
        #endregion
        
        #region Parameter SignalType
        /// <summary>
        /// <para>
        /// <para>The type of signal to send to an Automation execution. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.SignalType")]
        public Amazon.SimpleSystemsManagement.SignalType SignalType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.SendAutomationSignalResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AutomationExecutionId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AutomationExecutionId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AutomationExecutionId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutomationExecutionId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-SSMAutomationSignal (SendAutomationSignal)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.SendAutomationSignalResponse, SendSSMAutomationSignalCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AutomationExecutionId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AutomationExecutionId = this.AutomationExecutionId;
            #if MODULAR
            if (this.AutomationExecutionId == null && ParameterWasBound(nameof(this.AutomationExecutionId)))
            {
                WriteWarning("You are passing $null as a value for parameter AutomationExecutionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Payload != null)
            {
                context.Payload = new Dictionary<System.String, List<System.String>>(StringComparer.Ordinal);
                foreach (var hashKey in this.Payload.Keys)
                {
                    object hashValue = this.Payload[hashKey];
                    if (hashValue == null)
                    {
                        context.Payload.Add((String)hashKey, null);
                        continue;
                    }
                    var enumerable = SafeEnumerable(hashValue);
                    var valueSet = new List<System.String>();
                    foreach (var s in enumerable)
                    {
                        valueSet.Add((System.String)s);
                    }
                    context.Payload.Add((String)hashKey, valueSet);
                }
            }
            context.SignalType = this.SignalType;
            #if MODULAR
            if (this.SignalType == null && ParameterWasBound(nameof(this.SignalType)))
            {
                WriteWarning("You are passing $null as a value for parameter SignalType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.SendAutomationSignalRequest();
            
            if (cmdletContext.AutomationExecutionId != null)
            {
                request.AutomationExecutionId = cmdletContext.AutomationExecutionId;
            }
            if (cmdletContext.Payload != null)
            {
                request.Payload = cmdletContext.Payload;
            }
            if (cmdletContext.SignalType != null)
            {
                request.SignalType = cmdletContext.SignalType;
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
        
        private Amazon.SimpleSystemsManagement.Model.SendAutomationSignalResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.SendAutomationSignalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "SendAutomationSignal");
            try
            {
                #if DESKTOP
                return client.SendAutomationSignal(request);
                #elif CORECLR
                return client.SendAutomationSignalAsync(request).GetAwaiter().GetResult();
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
            public System.String AutomationExecutionId { get; set; }
            public Dictionary<System.String, List<System.String>> Payload { get; set; }
            public Amazon.SimpleSystemsManagement.SignalType SignalType { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.SendAutomationSignalResponse, SendSSMAutomationSignalCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
