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
    /// Sets your account's enrollment preference for a trusted access program. Amazon Bedrock
    /// identifies the account from your authenticated request. To enable enrollment, your
    /// account needs applicable approval and no applicable revocation, including when you
    /// repeat an enabled setting. Otherwise, Amazon Bedrock returns <c>ConflictException</c>
    /// and preserves the stored setting. With the required permissions, you can set <c>disabled</c>
    /// or <c>inherit</c> even if your account is ineligible or its eligibility is revoked.
    /// </summary>
    [Cmdlet("Write", "BDRTrustedAccessProgramAccountEnrollment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock PutTrustedAccessProgramAccountEnrollment API operation.", Operation = new[] {"PutTrustedAccessProgramAccountEnrollment"}, SelectReturnType = typeof(Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse))]
    [AWSCmdletOutput("Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse",
        "This cmdlet returns an Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse object containing multiple properties."
    )]
    public partial class WriteBDRTrustedAccessProgramAccountEnrollmentCmdlet : AmazonBedrockClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OptIn
        /// <summary>
        /// <para>
        /// <para>The enrollment preference to store. A transition to enabled accepts the program's
        /// terms. Changing the preference records a new updatedAt. Repeating the same stored
        /// preference preserves updatedAt.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Bedrock.TrustedAccessProgramOptIn")]
        public Amazon.Bedrock.TrustedAccessProgramOptIn OptIn { get; set; }
        #endregion
        
        #region Parameter ProgramIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the trusted access program.</para>
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
        public System.String ProgramIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse).
        /// Specifying the name of a property of type Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProgramIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BDRTrustedAccessProgramAccountEnrollment (PutTrustedAccessProgramAccountEnrollment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse, WriteBDRTrustedAccessProgramAccountEnrollmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OptIn = this.OptIn;
            #if MODULAR
            if (this.OptIn == null && ParameterWasBound(nameof(this.OptIn)))
            {
                WriteWarning("You are passing $null as a value for parameter OptIn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentRequest();
            
            if (cmdletContext.OptIn != null)
            {
                request.OptIn = cmdletContext.OptIn;
            }
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
        
        private Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse CallAWSServiceOperation(IAmazonBedrock client, Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock", "PutTrustedAccessProgramAccountEnrollment");
            try
            {
                return client.PutTrustedAccessProgramAccountEnrollmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Bedrock.TrustedAccessProgramOptIn OptIn { get; set; }
            public System.String ProgramIdentifier { get; set; }
            public System.Func<Amazon.Bedrock.Model.PutTrustedAccessProgramAccountEnrollmentResponse, WriteBDRTrustedAccessProgramAccountEnrollmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
