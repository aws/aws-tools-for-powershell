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
using Amazon.Bedrock;
using Amazon.Bedrock.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BDR
{
    /// <summary>
    /// Gets the calling account's stored enrollment setting for a trusted access program.
    /// The account is derived from the authenticated caller. Use GetTrustedAccessProgram
    /// to retrieve the resolved participation status, including organization inheritance.
    /// If no enrollment is stored, returns inherit without timestamps.
    /// </summary>
    [Cmdlet("Get", "BDRTrustedAccessProgramAccountEnrollment")]
    [OutputType("Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock GetTrustedAccessProgramAccountEnrollment API operation.", Operation = new[] {"GetTrustedAccessProgramAccountEnrollment"}, SelectReturnType = typeof(Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse object containing multiple properties."
    )]
    public partial class GetBDRTrustedAccessProgramAccountEnrollmentCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProgramIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the trusted access program.</para>
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
        public System.String ProgramIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse, GetBDRTrustedAccessProgramAccountEnrollmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ProgramIdentifier = this.ProgramIdentifier;
            #if MODULAR
            if (this.ProgramIdentifier == null && ParameterWasBound(nameof(this.ProgramIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ProgramIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentRequest();
            
            if (cmdletContext.ProgramIdentifier != null)
            {
                request.ProgramIdentifier = cmdletContext.ProgramIdentifier;
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
        
        private Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "GetTrustedAccessProgramAccountEnrollment");
            try
            {
                return client.GetTrustedAccessProgramAccountEnrollmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ProgramIdentifier { get; set; }
            public System.Func<Amazon.Bedrock.Model.GetTrustedAccessProgramAccountEnrollmentResponse, GetBDRTrustedAccessProgramAccountEnrollmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
