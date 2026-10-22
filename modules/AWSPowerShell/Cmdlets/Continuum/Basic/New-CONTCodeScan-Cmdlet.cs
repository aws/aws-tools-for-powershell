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
using Amazon.Continuum;
using Amazon.Continuum.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONT
{
    /// <summary>
    /// Creates an explicit scan request for one environment. CP creates durable work before
    /// any queue delivery occurs. Retrying a request that succeeded, with the same clientToken
    /// on the same environment, returns the original scan instead of starting another one.
    /// Token handling is not yet atomic: requests with the same token that run at the same
    /// time, or a retry after a request that failed partway through, can leave an additional
    /// scan, which may end in the FAILED state with a message that it was superseded. Deleting
    /// the environment makes its tokens unusable; a later request with one of them returns
    /// ResourceNotFoundException. Each environment can have a limited number of scans in
    /// progress at the same time. Once that limit is enforced, a request that would exceed
    /// it returns ServiceQuotaExceededException; wait for a scan to finish (ListCodeScans
    /// shows each scan's status), then retry.
    /// </summary>
    [Cmdlet("New", "CONTCodeScan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Continuum.Model.CodeScanSummary")]
    [AWSCmdlet("Calls the AWS Continuum CreateCodeScan API operation.", Operation = new[] {"CreateCodeScan"}, SelectReturnType = typeof(Amazon.Continuum.Model.CreateCodeScanResponse))]
    [AWSCmdletOutput("Amazon.Continuum.Model.CodeScanSummary or Amazon.Continuum.Model.CreateCodeScanResponse",
        "This cmdlet returns an Amazon.Continuum.Model.CodeScanSummary object.",
        "The service call response (type Amazon.Continuum.Model.CreateCodeScanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCONTCodeScanCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// Environment to scan.
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
        public System.String EnvironmentId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// An optional token identifying one scan request
        /// for this environment. SDKs generate a token when omitted. If a request reaches the
        /// service without a token, the service generates one for that request, so each request
        /// without a token starts a new scan. To retry a request after a lost response, supply
        /// the same token on the same environment; once a request with that token has succeeded,
        /// a retry returns the original scan. Concurrent requests with the same token, or a retry
        /// after a request that failed partway through, can leave an additional scan, which may
        /// end FAILED as superseded. A token is bound to its scan for as long as the service
        /// retains the scan's build record, with no shorter expiry. Deleting the environment
        /// makes the binding inaccessible: a later request with the token returns ResourceNotFoundException.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Scan'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.CreateCodeScanResponse).
        /// Specifying the name of a property of type Amazon.Continuum.Model.CreateCodeScanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Scan";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONTCodeScan (CreateCodeScan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.CreateCodeScanResponse, NewCONTCodeScanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.EnvironmentId = this.EnvironmentId;
            #if MODULAR
            if (this.EnvironmentId == null && ParameterWasBound(nameof(this.EnvironmentId)))
            {
                WriteWarning("You are passing $null as a value for parameter EnvironmentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Continuum.Model.CreateCodeScanRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
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
        
        private Amazon.Continuum.Model.CreateCodeScanResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.CreateCodeScanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "CreateCodeScan");
            try
            {
                return client.CreateCodeScanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String EnvironmentId { get; set; }
            public System.Func<Amazon.Continuum.Model.CreateCodeScanResponse, NewCONTCodeScanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Scan;
        }
        
    }
}
