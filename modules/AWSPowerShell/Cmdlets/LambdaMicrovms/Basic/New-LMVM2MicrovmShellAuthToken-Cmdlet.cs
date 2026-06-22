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
using Amazon.LambdaMicrovms;
using Amazon.LambdaMicrovms.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LMVM2
{
    /// <summary>
    /// Creates a shell authentication token for interactive shell access to a running MicroVM.
    /// The MicroVM must have been run with the SHELL_INGRESS network connector attached.
    /// </summary>
    [Cmdlet("New", "LMVM2MicrovmShellAuthToken", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Lambda MicroVMs CreateMicrovmShellAuthToken API operation.", Operation = new[] {"CreateMicrovmShellAuthToken"}, SelectReturnType = typeof(Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenResponse))]
    [AWSCmdletOutput("System.String or Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenResponse",
        "This cmdlet returns a collection of System.String objects.",
        "The service call response (type Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLMVM2MicrovmShellAuthTokenCmdlet : AmazonLambdaMicrovmsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ExpirationInMinute
        /// <summary>
        /// <para>
        /// <para>The duration in minutes before the shell authentication token expires.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("ExpirationInMinutes")]
        public System.Int32? ExpirationInMinute { get; set; }
        #endregion
        
        #region Parameter MicrovmIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the MicroVM to create a shell authentication token for.</para>
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
        public System.String MicrovmIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AuthToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenResponse).
        /// Specifying the name of a property of type Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AuthToken";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MicrovmIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LMVM2MicrovmShellAuthToken (CreateMicrovmShellAuthToken)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenResponse, NewLMVM2MicrovmShellAuthTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ExpirationInMinute = this.ExpirationInMinute;
            #if MODULAR
            if (this.ExpirationInMinute == null && ParameterWasBound(nameof(this.ExpirationInMinute)))
            {
                WriteWarning("You are passing $null as a value for parameter ExpirationInMinute which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MicrovmIdentifier = this.MicrovmIdentifier;
            #if MODULAR
            if (this.MicrovmIdentifier == null && ParameterWasBound(nameof(this.MicrovmIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter MicrovmIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenRequest();
            
            if (cmdletContext.ExpirationInMinute != null)
            {
                request.ExpirationInMinutes = cmdletContext.ExpirationInMinute.Value;
            }
            if (cmdletContext.MicrovmIdentifier != null)
            {
                request.MicrovmIdentifier = cmdletContext.MicrovmIdentifier;
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
        
        private Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenResponse CallAWSServiceOperation(IAmazonLambdaMicrovms client, Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Lambda MicroVMs", "CreateMicrovmShellAuthToken");
            try
            {
                return client.CreateMicrovmShellAuthTokenAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ExpirationInMinute { get; set; }
            public System.String MicrovmIdentifier { get; set; }
            public System.Func<Amazon.LambdaMicrovms.Model.CreateMicrovmShellAuthTokenResponse, NewLMVM2MicrovmShellAuthTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AuthToken;
        }
        
    }
}
