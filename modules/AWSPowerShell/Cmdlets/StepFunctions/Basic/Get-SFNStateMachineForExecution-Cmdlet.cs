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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Provides information about a state machine's definition, its execution role ARN, and
    /// configuration. If a Map Run dispatched the execution, this action returns the Map
    /// Run Amazon Resource Name (ARN) in the response. The state machine returned is the
    /// state machine associated with the Map Run.
    /// 
    ///  <note><para>
    /// This operation is eventually consistent. The results are best effort and may not reflect
    /// very recent updates and changes.
    /// </para></note><para>
    /// This API action is not supported by <c>EXPRESS</c> state machines.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "SFNStateMachineForExecution")]
    [OutputType("Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse")]
    [AWSCmdlet("Calls the AWS Step Functions DescribeStateMachineForExecution API operation.", Operation = new[] {"DescribeStateMachineForExecution"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse object containing multiple properties."
    )]
    public partial class GetSFNStateMachineForExecutionCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ExecutionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the execution you want state machine information
        /// for.</para>
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
        public System.String ExecutionArn { get; set; }
        #endregion
        
        #region Parameter IncludedData
        /// <summary>
        /// <para>
        /// <para>If your state machine definition is encrypted with a KMS key, callers must have <c>kms:Decrypt</c>
        /// permission to decrypt the definition. Alternatively, you can call the API with <c>includedData
        /// = METADATA_ONLY</c> to get a successful response without the encrypted definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.IncludedData")]
        public Amazon.StepFunctions.IncludedData IncludedData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse, GetSFNStateMachineForExecutionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExecutionArn = this.ExecutionArn;
            #if MODULAR
            if (this.ExecutionArn == null && ParameterWasBound(nameof(this.ExecutionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludedData = this.IncludedData;
            
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
            var request = new Amazon.StepFunctions.Model.DescribeStateMachineForExecutionRequest();
            
            if (cmdletContext.ExecutionArn != null)
            {
                request.ExecutionArn = cmdletContext.ExecutionArn;
            }
            if (cmdletContext.IncludedData != null)
            {
                request.IncludedData = cmdletContext.IncludedData;
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
        
        private Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.DescribeStateMachineForExecutionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "DescribeStateMachineForExecution");
            try
            {
                #if DESKTOP
                return client.DescribeStateMachineForExecution(request);
                #elif CORECLR
                return client.DescribeStateMachineForExecutionAsync(request).GetAwaiter().GetResult();
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
            public System.String ExecutionArn { get; set; }
            public Amazon.StepFunctions.IncludedData IncludedData { get; set; }
            public System.Func<Amazon.StepFunctions.Model.DescribeStateMachineForExecutionResponse, GetSFNStateMachineForExecutionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
