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
using Amazon.BedrockDataAutomationRuntime;
using Amazon.BedrockDataAutomationRuntime.Model;

namespace Amazon.PowerShell.Cmdlets.BDAR
{
    /// <summary>
    /// API used to get data automation status.
    /// </summary>
    [Cmdlet("Get", "BDARDataAutomationStatus")]
    [OutputType("Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse")]
    [AWSCmdlet("Calls the Runtime for Amazon Bedrock Data Automation GetDataAutomationStatus API operation.", Operation = new[] {"GetDataAutomationStatus"}, SelectReturnType = typeof(Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse))]
    [AWSCmdletOutput("Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse",
        "This cmdlet returns an Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse object containing multiple properties."
    )]
    public partial class GetBDARDataAutomationStatusCmdlet : AmazonBedrockDataAutomationRuntimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InvocationArn
        /// <summary>
        /// <para>
        /// <para>Invocation arn.</para>
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
        public System.String InvocationArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse).
        /// Specifying the name of a property of type Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InvocationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InvocationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InvocationArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse, GetBDARDataAutomationStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InvocationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InvocationArn = this.InvocationArn;
            #if MODULAR
            if (this.InvocationArn == null && ParameterWasBound(nameof(this.InvocationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InvocationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusRequest();
            
            if (cmdletContext.InvocationArn != null)
            {
                request.InvocationArn = cmdletContext.InvocationArn;
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
        
        private Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse CallAWSServiceOperation(IAmazonBedrockDataAutomationRuntime client, Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Runtime for Amazon Bedrock Data Automation", "GetDataAutomationStatus");
            try
            {
                #if DESKTOP
                return client.GetDataAutomationStatus(request);
                #elif CORECLR
                return client.GetDataAutomationStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String InvocationArn { get; set; }
            public System.Func<Amazon.BedrockDataAutomationRuntime.Model.GetDataAutomationStatusResponse, GetBDARDataAutomationStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
