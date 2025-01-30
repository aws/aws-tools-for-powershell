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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Gets information about an inference profile. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/cross-region-inference.html">Increase
    /// throughput and resilience with cross-region inference in Amazon Bedrock</a>. in the
    /// Amazon Bedrock User Guide.
    /// </summary>
    [Cmdlet("Get", "BDRInferenceProfile")]
    [OutputType("Amazon.Bedrock.Model.GetInferenceProfileResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock GetInferenceProfile API operation.", Operation = new[] {"GetInferenceProfile"}, SelectReturnType = typeof(Amazon.Bedrock.Model.GetInferenceProfileResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.GetInferenceProfileResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.GetInferenceProfileResponse object containing multiple properties."
    )]
    public partial class GetBDRInferenceProfileCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InferenceProfileIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or Amazon Resource Name (ARN) of the inference profile.</para>
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
        public System.String InferenceProfileIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.GetInferenceProfileResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.GetInferenceProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InferenceProfileIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InferenceProfileIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InferenceProfileIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.GetInferenceProfileResponse, GetBDRInferenceProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InferenceProfileIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InferenceProfileIdentifier = this.InferenceProfileIdentifier;
            #if MODULAR
            if (this.InferenceProfileIdentifier == null && ParameterWasBound(nameof(this.InferenceProfileIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter InferenceProfileIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.GetInferenceProfileRequest();
            
            if (cmdletContext.InferenceProfileIdentifier != null)
            {
                request.InferenceProfileIdentifier = cmdletContext.InferenceProfileIdentifier;
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
        
        private Amazon.Bedrock.Model.GetInferenceProfileResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.GetInferenceProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "GetInferenceProfile");
            try
            {
                #if DESKTOP
                return client.GetInferenceProfile(request);
                #elif CORECLR
                return client.GetInferenceProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String InferenceProfileIdentifier { get; set; }
            public System.Func<Amazon.Bedrock.Model.GetInferenceProfileResponse, GetBDRInferenceProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
