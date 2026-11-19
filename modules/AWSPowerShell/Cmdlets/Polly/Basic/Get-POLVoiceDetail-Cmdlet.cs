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
using Amazon.Polly;
using Amazon.Polly.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.POL
{
    /// <summary>
    /// Returns the status and properties of a custom voice. Use this operation after <c>CreateVoice</c>
    /// to check whether the status of the voice is <c>active</c> or <c>failed</c>. Unlike
    /// <c>DescribeVoices</c>, <c>GetVoice</c> also returns <c>Arn</c>, <c>VoiceCreationData</c>,
    /// <c>CustomerManagedEncryption</c>, and <c>StatusReason</c>. If no custom voice with
    /// the specified ID exists in your account and Region, the request fails with <c>ResourceNotFoundException</c>.
    /// 
    ///  
    /// <para>
    /// This operation requires permissions to perform the <c>polly:GetVoice</c> action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "POLVoiceDetail")]
    [OutputType("Amazon.Polly.Model.Voice")]
    [AWSCmdlet("Calls the Amazon Polly GetVoice API operation.", Operation = new[] {"GetVoice"}, SelectReturnType = typeof(Amazon.Polly.Model.GetVoiceResponse))]
    [AWSCmdletOutput("Amazon.Polly.Model.Voice or Amazon.Polly.Model.GetVoiceResponse",
        "This cmdlet returns an Amazon.Polly.Model.Voice object.",
        "The service call response (type Amazon.Polly.Model.GetVoiceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPOLVoiceDetailCmdlet : AmazonPollyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter VoiceId
        /// <summary>
        /// <para>
        /// <para>The ID of the custom voice that <c>CreateVoice</c> returned, for example, <c>vc-9a8fa85dd3</c>.
        /// You can't specify the ARN of the voice.</para>
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
        public System.String VoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Voice'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Polly.Model.GetVoiceResponse).
        /// Specifying the name of a property of type Amazon.Polly.Model.GetVoiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Voice";
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
                context.Select = CreateSelectDelegate<Amazon.Polly.Model.GetVoiceResponse, GetPOLVoiceDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.VoiceId = this.VoiceId;
            #if MODULAR
            if (this.VoiceId == null && ParameterWasBound(nameof(this.VoiceId)))
            {
                WriteWarning("You are passing $null as a value for parameter VoiceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Polly.Model.GetVoiceRequest();
            
            if (cmdletContext.VoiceId != null)
            {
                request.VoiceId = cmdletContext.VoiceId;
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
        
        private Amazon.Polly.Model.GetVoiceResponse CallAWSServiceOperation(IAmazonPolly client, Amazon.Polly.Model.GetVoiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Polly", "GetVoice");
            try
            {
                return client.GetVoiceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String VoiceId { get; set; }
            public System.Func<Amazon.Polly.Model.GetVoiceResponse, GetPOLVoiceDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Voice;
        }
        
    }
}
