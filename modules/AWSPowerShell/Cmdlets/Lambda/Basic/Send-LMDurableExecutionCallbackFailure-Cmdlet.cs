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
using Amazon.Lambda;
using Amazon.Lambda.Model;

namespace Amazon.PowerShell.Cmdlets.LM
{
    /// <summary>
    /// Sends a failure response for a callback operation in a durable execution. Use this
    /// API when an external system cannot complete a callback operation successfully.
    /// </summary>
    [Cmdlet("Send", "LMDurableExecutionCallbackFailure", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Lambda SendDurableExecutionCallbackFailure API operation.", Operation = new[] {"SendDurableExecutionCallbackFailure"}, SelectReturnType = typeof(Amazon.Lambda.Model.SendDurableExecutionCallbackFailureResponse))]
    [AWSCmdletOutput("None or Amazon.Lambda.Model.SendDurableExecutionCallbackFailureResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Lambda.Model.SendDurableExecutionCallbackFailureResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendLMDurableExecutionCallbackFailureCmdlet : AmazonLambdaClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CallbackId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the callback operation.</para>
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
        public System.String CallbackId { get; set; }
        #endregion
        
        #region Parameter Error_ErrorData
        /// <summary>
        /// <para>
        /// <para>Machine-readable error data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Error_ErrorData { get; set; }
        #endregion
        
        #region Parameter Error_ErrorMessage
        /// <summary>
        /// <para>
        /// <para>A human-readable error message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Error_ErrorMessage { get; set; }
        #endregion
        
        #region Parameter Error_ErrorType
        /// <summary>
        /// <para>
        /// <para>The error type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Error_ErrorType { get; set; }
        #endregion
        
        #region Parameter Error_StackTrace
        /// <summary>
        /// <para>
        /// <para>Stack trace information for the error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Error_StackTrace { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Lambda.Model.SendDurableExecutionCallbackFailureResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the CallbackId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^CallbackId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^CallbackId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CallbackId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-LMDurableExecutionCallbackFailure (SendDurableExecutionCallbackFailure)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Lambda.Model.SendDurableExecutionCallbackFailureResponse, SendLMDurableExecutionCallbackFailureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.CallbackId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CallbackId = this.CallbackId;
            #if MODULAR
            if (this.CallbackId == null && ParameterWasBound(nameof(this.CallbackId)))
            {
                WriteWarning("You are passing $null as a value for parameter CallbackId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Error_ErrorData = this.Error_ErrorData;
            context.Error_ErrorMessage = this.Error_ErrorMessage;
            context.Error_ErrorType = this.Error_ErrorType;
            if (this.Error_StackTrace != null)
            {
                context.Error_StackTrace = new List<System.String>(this.Error_StackTrace);
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
            var request = new Amazon.Lambda.Model.SendDurableExecutionCallbackFailureRequest();
            
            if (cmdletContext.CallbackId != null)
            {
                request.CallbackId = cmdletContext.CallbackId;
            }
            
             // populate Error
            var requestErrorIsNull = true;
            request.Error = new Amazon.Lambda.Model.ErrorObject();
            System.String requestError_error_ErrorData = null;
            if (cmdletContext.Error_ErrorData != null)
            {
                requestError_error_ErrorData = cmdletContext.Error_ErrorData;
            }
            if (requestError_error_ErrorData != null)
            {
                request.Error.ErrorData = requestError_error_ErrorData;
                requestErrorIsNull = false;
            }
            System.String requestError_error_ErrorMessage = null;
            if (cmdletContext.Error_ErrorMessage != null)
            {
                requestError_error_ErrorMessage = cmdletContext.Error_ErrorMessage;
            }
            if (requestError_error_ErrorMessage != null)
            {
                request.Error.ErrorMessage = requestError_error_ErrorMessage;
                requestErrorIsNull = false;
            }
            System.String requestError_error_ErrorType = null;
            if (cmdletContext.Error_ErrorType != null)
            {
                requestError_error_ErrorType = cmdletContext.Error_ErrorType;
            }
            if (requestError_error_ErrorType != null)
            {
                request.Error.ErrorType = requestError_error_ErrorType;
                requestErrorIsNull = false;
            }
            List<System.String> requestError_error_StackTrace = null;
            if (cmdletContext.Error_StackTrace != null)
            {
                requestError_error_StackTrace = cmdletContext.Error_StackTrace;
            }
            if (requestError_error_StackTrace != null)
            {
                request.Error.StackTrace = requestError_error_StackTrace;
                requestErrorIsNull = false;
            }
             // determine if request.Error should be set to null
            if (requestErrorIsNull)
            {
                request.Error = null;
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
        
        private Amazon.Lambda.Model.SendDurableExecutionCallbackFailureResponse CallAWSServiceOperation(IAmazonLambda client, Amazon.Lambda.Model.SendDurableExecutionCallbackFailureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Lambda", "SendDurableExecutionCallbackFailure");
            try
            {
                #if DESKTOP
                return client.SendDurableExecutionCallbackFailure(request);
                #elif CORECLR
                return client.SendDurableExecutionCallbackFailureAsync(request).GetAwaiter().GetResult();
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
            public System.String CallbackId { get; set; }
            public System.String Error_ErrorData { get; set; }
            public System.String Error_ErrorMessage { get; set; }
            public System.String Error_ErrorType { get; set; }
            public List<System.String> Error_StackTrace { get; set; }
            public System.Func<Amazon.Lambda.Model.SendDurableExecutionCallbackFailureResponse, SendLMDurableExecutionCallbackFailureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
