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
using Amazon.AugmentedAIRuntime;
using Amazon.AugmentedAIRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.A2IR
{
    /// <summary>
    /// Starts a human loop, provided that at least one activation condition is met.
    /// </summary>
    [Cmdlet("Start", "A2IRHumanLoop", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse")]
    [AWSCmdlet("Calls the Amazon Augmented AI (A2I) Runtime StartHumanLoop API operation.", Operation = new[] {"StartHumanLoop"}, SelectReturnType = typeof(Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse))]
    [AWSCmdletOutput("Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse",
        "This cmdlet returns an Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse object containing multiple properties."
    )]
    public partial class StartA2IRHumanLoopCmdlet : AmazonAugmentedAIRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataAttributes_ContentClassifier
        /// <summary>
        /// <para>
        /// <para>Declares that your content is free of personally identifiable information or adult
        /// content.</para><para>Amazon SageMaker can restrict the Amazon Mechanical Turk workers who can view your
        /// task based on this information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataAttributes_ContentClassifiers")]
        public System.String[] DataAttributes_ContentClassifier { get; set; }
        #endregion
        
        #region Parameter FlowDefinitionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the flow definition associated with this human loop.</para>
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
        public System.String FlowDefinitionArn { get; set; }
        #endregion
        
        #region Parameter HumanLoopName
        /// <summary>
        /// <para>
        /// <para>The name of the human loop.</para>
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
        public System.String HumanLoopName { get; set; }
        #endregion
        
        #region Parameter HumanLoopInput_InputContent
        /// <summary>
        /// <para>
        /// <para>Serialized input from the human loop. The input must be a string representation of
        /// a file in JSON format.</para>
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
        public System.String HumanLoopInput_InputContent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse).
        /// Specifying the name of a property of type Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the HumanLoopName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^HumanLoopName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^HumanLoopName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.HumanLoopName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-A2IRHumanLoop (StartHumanLoop)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse, StartA2IRHumanLoopCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.HumanLoopName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.DataAttributes_ContentClassifier != null)
            {
                context.DataAttributes_ContentClassifier = new List<System.String>(this.DataAttributes_ContentClassifier);
            }
            context.FlowDefinitionArn = this.FlowDefinitionArn;
            #if MODULAR
            if (this.FlowDefinitionArn == null && ParameterWasBound(nameof(this.FlowDefinitionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowDefinitionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HumanLoopInput_InputContent = this.HumanLoopInput_InputContent;
            #if MODULAR
            if (this.HumanLoopInput_InputContent == null && ParameterWasBound(nameof(this.HumanLoopInput_InputContent)))
            {
                WriteWarning("You are passing $null as a value for parameter HumanLoopInput_InputContent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HumanLoopName = this.HumanLoopName;
            #if MODULAR
            if (this.HumanLoopName == null && ParameterWasBound(nameof(this.HumanLoopName)))
            {
                WriteWarning("You are passing $null as a value for parameter HumanLoopName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AugmentedAIRuntime.Model.StartHumanLoopRequest();
            
            
             // populate DataAttributes
            var requestDataAttributesIsNull = true;
            request.DataAttributes = new Amazon.AugmentedAIRuntime.Model.HumanLoopDataAttributes();
            List<System.String> requestDataAttributes_dataAttributes_ContentClassifier = null;
            if (cmdletContext.DataAttributes_ContentClassifier != null)
            {
                requestDataAttributes_dataAttributes_ContentClassifier = cmdletContext.DataAttributes_ContentClassifier;
            }
            if (requestDataAttributes_dataAttributes_ContentClassifier != null)
            {
                request.DataAttributes.ContentClassifiers = requestDataAttributes_dataAttributes_ContentClassifier;
                requestDataAttributesIsNull = false;
            }
             // determine if request.DataAttributes should be set to null
            if (requestDataAttributesIsNull)
            {
                request.DataAttributes = null;
            }
            if (cmdletContext.FlowDefinitionArn != null)
            {
                request.FlowDefinitionArn = cmdletContext.FlowDefinitionArn;
            }
            
             // populate HumanLoopInput
            var requestHumanLoopInputIsNull = true;
            request.HumanLoopInput = new Amazon.AugmentedAIRuntime.Model.HumanLoopInput();
            System.String requestHumanLoopInput_humanLoopInput_InputContent = null;
            if (cmdletContext.HumanLoopInput_InputContent != null)
            {
                requestHumanLoopInput_humanLoopInput_InputContent = cmdletContext.HumanLoopInput_InputContent;
            }
            if (requestHumanLoopInput_humanLoopInput_InputContent != null)
            {
                request.HumanLoopInput.InputContent = requestHumanLoopInput_humanLoopInput_InputContent;
                requestHumanLoopInputIsNull = false;
            }
             // determine if request.HumanLoopInput should be set to null
            if (requestHumanLoopInputIsNull)
            {
                request.HumanLoopInput = null;
            }
            if (cmdletContext.HumanLoopName != null)
            {
                request.HumanLoopName = cmdletContext.HumanLoopName;
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
        
        private Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse CallAWSServiceOperation(IAmazonAugmentedAIRuntime client, Amazon.AugmentedAIRuntime.Model.StartHumanLoopRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Augmented AI (A2I) Runtime", "StartHumanLoop");
            try
            {
                #if DESKTOP
                return client.StartHumanLoop(request);
                #elif CORECLR
                return client.StartHumanLoopAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> DataAttributes_ContentClassifier { get; set; }
            public System.String FlowDefinitionArn { get; set; }
            public System.String HumanLoopInput_InputContent { get; set; }
            public System.String HumanLoopName { get; set; }
            public System.Func<Amazon.AugmentedAIRuntime.Model.StartHumanLoopResponse, StartA2IRHumanLoopCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
