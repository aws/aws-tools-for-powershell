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
using Amazon.IoTEvents;
using Amazon.IoTEvents.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTE
{
    /// <summary>
    /// Updates an input.
    /// </summary>
    [Cmdlet("Update", "IOTEInput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTEvents.Model.InputConfiguration")]
    [AWSCmdlet("Calls the AWS IoT Events UpdateInput API operation.", Operation = new[] {"UpdateInput"}, SelectReturnType = typeof(Amazon.IoTEvents.Model.UpdateInputResponse))]
    [AWSCmdletOutput("Amazon.IoTEvents.Model.InputConfiguration or Amazon.IoTEvents.Model.UpdateInputResponse",
        "This cmdlet returns an Amazon.IoTEvents.Model.InputConfiguration object.",
        "The service call response (type Amazon.IoTEvents.Model.UpdateInputResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTEInputCmdlet : AmazonIoTEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InputDefinition_Attribute
        /// <summary>
        /// <para>
        /// <para>The attributes from the JSON payload that are made available by the input. Inputs
        /// are derived from messages sent to the AWS IoT Events system using <c>BatchPutMessage</c>.
        /// Each such message contains a JSON payload, and those attributes (and their paired
        /// values) specified here are available for use in the <c>condition</c> expressions used
        /// by detectors that monitor this input. </para>
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
        [Alias("InputDefinition_Attributes")]
        public Amazon.IoTEvents.Model.Attribute[] InputDefinition_Attribute { get; set; }
        #endregion
        
        #region Parameter InputDescription
        /// <summary>
        /// <para>
        /// <para>A brief description of the input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputDescription { get; set; }
        #endregion
        
        #region Parameter InputName
        /// <summary>
        /// <para>
        /// <para>The name of the input you want to update.</para>
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
        public System.String InputName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InputConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEvents.Model.UpdateInputResponse).
        /// Specifying the name of a property of type Amazon.IoTEvents.Model.UpdateInputResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InputConfiguration";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InputName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTEInput (UpdateInput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTEvents.Model.UpdateInputResponse, UpdateIOTEInputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.InputDefinition_Attribute != null)
            {
                context.InputDefinition_Attribute = new List<Amazon.IoTEvents.Model.Attribute>(this.InputDefinition_Attribute);
            }
            #if MODULAR
            if (this.InputDefinition_Attribute == null && ParameterWasBound(nameof(this.InputDefinition_Attribute)))
            {
                WriteWarning("You are passing $null as a value for parameter InputDefinition_Attribute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputDescription = this.InputDescription;
            context.InputName = this.InputName;
            #if MODULAR
            if (this.InputName == null && ParameterWasBound(nameof(this.InputName)))
            {
                WriteWarning("You are passing $null as a value for parameter InputName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTEvents.Model.UpdateInputRequest();
            
            
             // populate InputDefinition
            var requestInputDefinitionIsNull = true;
            request.InputDefinition = new Amazon.IoTEvents.Model.InputDefinition();
            List<Amazon.IoTEvents.Model.Attribute> requestInputDefinition_inputDefinition_Attribute = null;
            if (cmdletContext.InputDefinition_Attribute != null)
            {
                requestInputDefinition_inputDefinition_Attribute = cmdletContext.InputDefinition_Attribute;
            }
            if (requestInputDefinition_inputDefinition_Attribute != null)
            {
                request.InputDefinition.Attributes = requestInputDefinition_inputDefinition_Attribute;
                requestInputDefinitionIsNull = false;
            }
             // determine if request.InputDefinition should be set to null
            if (requestInputDefinitionIsNull)
            {
                request.InputDefinition = null;
            }
            if (cmdletContext.InputDescription != null)
            {
                request.InputDescription = cmdletContext.InputDescription;
            }
            if (cmdletContext.InputName != null)
            {
                request.InputName = cmdletContext.InputName;
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
        
        private Amazon.IoTEvents.Model.UpdateInputResponse CallAWSServiceOperation(IAmazonIoTEvents client, Amazon.IoTEvents.Model.UpdateInputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events", "UpdateInput");
            try
            {
                return client.UpdateInputAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.IoTEvents.Model.Attribute> InputDefinition_Attribute { get; set; }
            public System.String InputDescription { get; set; }
            public System.String InputName { get; set; }
            public System.Func<Amazon.IoTEvents.Model.UpdateInputResponse, UpdateIOTEInputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InputConfiguration;
        }
        
    }
}
