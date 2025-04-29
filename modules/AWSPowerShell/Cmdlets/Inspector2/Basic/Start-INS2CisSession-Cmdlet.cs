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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Starts a CIS session. This API is used by the Amazon Inspector SSM plugin to communicate
    /// with the Amazon Inspector service. The Amazon Inspector SSM plugin calls this API
    /// to start a CIS scan session for the scan ID supplied by the service.
    /// </summary>
    [Cmdlet("Start", "INS2CisSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Inspector2 StartCisSession API operation.", Operation = new[] {"StartCisSession"}, SelectReturnType = typeof(Amazon.Inspector2.Model.StartCisSessionResponse))]
    [AWSCmdletOutput("None or Amazon.Inspector2.Model.StartCisSessionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Inspector2.Model.StartCisSessionResponse) be returned by specifying '-Select *'."
    )]
    public partial class StartINS2CisSessionCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ScanJobId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the scan job.</para>
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
        public System.String ScanJobId { get; set; }
        #endregion
        
        #region Parameter Message_SessionToken
        /// <summary>
        /// <para>
        /// <para>The unique token that identifies the CIS session.</para>
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
        public System.String Message_SessionToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.StartCisSessionResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScanJobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-INS2CisSession (StartCisSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.StartCisSessionResponse, StartINS2CisSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Message_SessionToken = this.Message_SessionToken;
            #if MODULAR
            if (this.Message_SessionToken == null && ParameterWasBound(nameof(this.Message_SessionToken)))
            {
                WriteWarning("You are passing $null as a value for parameter Message_SessionToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanJobId = this.ScanJobId;
            #if MODULAR
            if (this.ScanJobId == null && ParameterWasBound(nameof(this.ScanJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.StartCisSessionRequest();
            
            
             // populate Message
            var requestMessageIsNull = true;
            request.Message = new Amazon.Inspector2.Model.StartCisSessionMessage();
            System.String requestMessage_message_SessionToken = null;
            if (cmdletContext.Message_SessionToken != null)
            {
                requestMessage_message_SessionToken = cmdletContext.Message_SessionToken;
            }
            if (requestMessage_message_SessionToken != null)
            {
                request.Message.SessionToken = requestMessage_message_SessionToken;
                requestMessageIsNull = false;
            }
             // determine if request.Message should be set to null
            if (requestMessageIsNull)
            {
                request.Message = null;
            }
            if (cmdletContext.ScanJobId != null)
            {
                request.ScanJobId = cmdletContext.ScanJobId;
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
        
        private Amazon.Inspector2.Model.StartCisSessionResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.StartCisSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "StartCisSession");
            try
            {
                return client.StartCisSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Message_SessionToken { get; set; }
            public System.String ScanJobId { get; set; }
            public System.Func<Amazon.Inspector2.Model.StartCisSessionResponse, StartINS2CisSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
