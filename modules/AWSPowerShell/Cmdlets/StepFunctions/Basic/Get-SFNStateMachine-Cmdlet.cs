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
using Amazon.StepFunctions;
using Amazon.StepFunctions.Model;

namespace Amazon.PowerShell.Cmdlets.SFN
{
    /// <summary>
    /// Provides information about a state machine's definition, its IAM role Amazon Resource
    /// Name (ARN), and configuration.
    /// 
    ///  
    /// <para>
    /// A qualified state machine ARN can either refer to a <i>Distributed Map state</i> defined
    /// within a state machine, a version ARN, or an alias ARN.
    /// </para><para>
    /// The following are some examples of qualified and unqualified state machine ARNs:
    /// </para><ul><li><para>
    /// The following qualified state machine ARN refers to a <i>Distributed Map state</i>
    /// with a label <c>mapStateLabel</c> in a state machine named <c>myStateMachine</c>.
    /// </para><para><c>arn:partition:states:region:account-id:stateMachine:myStateMachine/mapStateLabel</c></para><note><para>
    /// If you provide a qualified state machine ARN that refers to a <i>Distributed Map state</i>,
    /// the request fails with <c>ValidationException</c>.
    /// </para></note></li><li><para>
    /// The following qualified state machine ARN refers to an alias named <c>PROD</c>.
    /// </para><para><c>arn:&lt;partition&gt;:states:&lt;region&gt;:&lt;account-id&gt;:stateMachine:&lt;myStateMachine:PROD&gt;</c></para><note><para>
    /// If you provide a qualified state machine ARN that refers to a version ARN or an alias
    /// ARN, the request starts execution for that version or alias.
    /// </para></note></li><li><para>
    /// The following unqualified state machine ARN refers to a state machine named <c>myStateMachine</c>.
    /// </para><para><c>arn:&lt;partition&gt;:states:&lt;region&gt;:&lt;account-id&gt;:stateMachine:&lt;myStateMachine&gt;</c></para></li></ul><para>
    /// This API action returns the details for a state machine version if the <c>stateMachineArn</c>
    /// you specify is a state machine version ARN.
    /// </para><note><para>
    /// This operation is eventually consistent. The results are best effort and may not reflect
    /// very recent updates and changes.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "SFNStateMachine")]
    [OutputType("Amazon.StepFunctions.Model.DescribeStateMachineResponse")]
    [AWSCmdlet("Calls the AWS Step Functions DescribeStateMachine API operation.", Operation = new[] {"DescribeStateMachine"}, SelectReturnType = typeof(Amazon.StepFunctions.Model.DescribeStateMachineResponse))]
    [AWSCmdletOutput("Amazon.StepFunctions.Model.DescribeStateMachineResponse",
        "This cmdlet returns an Amazon.StepFunctions.Model.DescribeStateMachineResponse object containing multiple properties."
    )]
    public partial class GetSFNStateMachineCmdlet : AmazonStepFunctionsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter IncludedData
        /// <summary>
        /// <para>
        /// <para>If your state machine definition is encrypted with a KMS key, callers must have <c>kms:Decrypt</c>
        /// permission to decrypt the definition. Alternatively, you can call the API with <c>includedData
        /// = METADATA_ONLY</c> to get a successful response without the encrypted definition.</para><note><para> When calling a labelled ARN for an encrypted state machine, the <c>includedData =
        /// METADATA_ONLY</c> parameter will not apply because Step Functions needs to decrypt
        /// the entire state machine definition to get the Distributed Map state’s definition.
        /// In this case, the API caller needs to have <c>kms:Decrypt</c> permission. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.StepFunctions.IncludedData")]
        public Amazon.StepFunctions.IncludedData IncludedData { get; set; }
        #endregion
        
        #region Parameter StateMachineArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the state machine for which you want the information.</para><para>If you specify a state machine version ARN, this API returns details about that version.
        /// The version ARN is a combination of state machine ARN and the version number separated
        /// by a colon (:). For example, <c>stateMachineARN:1</c>.</para>
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
        public System.String StateMachineArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.StepFunctions.Model.DescribeStateMachineResponse).
        /// Specifying the name of a property of type Amazon.StepFunctions.Model.DescribeStateMachineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StateMachineArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StateMachineArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StateMachineArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.StepFunctions.Model.DescribeStateMachineResponse, GetSFNStateMachineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StateMachineArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.IncludedData = this.IncludedData;
            context.StateMachineArn = this.StateMachineArn;
            #if MODULAR
            if (this.StateMachineArn == null && ParameterWasBound(nameof(this.StateMachineArn)))
            {
                WriteWarning("You are passing $null as a value for parameter StateMachineArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.StepFunctions.Model.DescribeStateMachineRequest();
            
            if (cmdletContext.IncludedData != null)
            {
                request.IncludedData = cmdletContext.IncludedData;
            }
            if (cmdletContext.StateMachineArn != null)
            {
                request.StateMachineArn = cmdletContext.StateMachineArn;
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
        
        private Amazon.StepFunctions.Model.DescribeStateMachineResponse CallAWSServiceOperation(IAmazonStepFunctions client, Amazon.StepFunctions.Model.DescribeStateMachineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Step Functions", "DescribeStateMachine");
            try
            {
                #if DESKTOP
                return client.DescribeStateMachine(request);
                #elif CORECLR
                return client.DescribeStateMachineAsync(request).GetAwaiter().GetResult();
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
            public Amazon.StepFunctions.IncludedData IncludedData { get; set; }
            public System.String StateMachineArn { get; set; }
            public System.Func<Amazon.StepFunctions.Model.DescribeStateMachineResponse, GetSFNStateMachineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
