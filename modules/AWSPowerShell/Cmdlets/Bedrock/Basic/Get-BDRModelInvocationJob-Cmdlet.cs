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
    /// Gets details about a batch inference job. For more information, see <a href="https://docs.aws.amazon.com/bedrock/latest/userguide/batch-inference-monitor">Monitor
    /// batch inference jobs</a>
    /// </summary>
    [Cmdlet("Get", "BDRModelInvocationJob")]
    [OutputType("Amazon.Bedrock.Model.GetModelInvocationJobResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock GetModelInvocationJob API operation.", Operation = new[] {"GetModelInvocationJob"}, SelectReturnType = typeof(Amazon.Bedrock.Model.GetModelInvocationJobResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.GetModelInvocationJobResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.GetModelInvocationJobResponse object containing multiple properties."
    )]
    public partial class GetBDRModelInvocationJobCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter JobIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the batch inference job.</para>
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
        public System.String JobIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.GetModelInvocationJobResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.GetModelInvocationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the JobIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^JobIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^JobIdentifier' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.GetModelInvocationJobResponse, GetBDRModelInvocationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.JobIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.JobIdentifier = this.JobIdentifier;
            #if MODULAR
            if (this.JobIdentifier == null && ParameterWasBound(nameof(this.JobIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter JobIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.GetModelInvocationJobRequest();
            
            if (cmdletContext.JobIdentifier != null)
            {
                request.JobIdentifier = cmdletContext.JobIdentifier;
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
        
        private Amazon.Bedrock.Model.GetModelInvocationJobResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.GetModelInvocationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "GetModelInvocationJob");
            try
            {
                #if DESKTOP
                return client.GetModelInvocationJob(request);
                #elif CORECLR
                return client.GetModelInvocationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String JobIdentifier { get; set; }
            public System.Func<Amazon.Bedrock.Model.GetModelInvocationJobResponse, GetBDRModelInvocationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
