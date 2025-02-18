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
using Amazon.Proton;
using Amazon.Proton.Model;

namespace Amazon.PowerShell.Cmdlets.PRO
{
    /// <summary>
    /// Attempts to cancel a service pipeline deployment on an <a>UpdateServicePipeline</a>
    /// action, if the deployment is <c>IN_PROGRESS</c>. For more information, see <a href="https://docs.aws.amazon.com/proton/latest/userguide/ag-svc-pipeline-update.html">Update
    /// a service pipeline</a> in the <i>Proton User guide</i>.
    /// 
    ///  
    /// <para>
    /// The following list includes potential cancellation scenarios.
    /// </para><ul><li><para>
    /// If the cancellation attempt succeeds, the resulting deployment state is <c>CANCELLED</c>.
    /// </para></li><li><para>
    /// If the cancellation attempt fails, the resulting deployment state is <c>FAILED</c>.
    /// </para></li><li><para>
    /// If the current <a>UpdateServicePipeline</a> action succeeds before the cancellation
    /// attempt starts, the resulting deployment state is <c>SUCCEEDED</c> and the cancellation
    /// attempt has no effect.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Stop", "PROServicePipelineDeployment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Proton.Model.ServicePipeline")]
    [AWSCmdlet("Calls the AWS Proton CancelServicePipelineDeployment API operation.", Operation = new[] {"CancelServicePipelineDeployment"}, SelectReturnType = typeof(Amazon.Proton.Model.CancelServicePipelineDeploymentResponse))]
    [AWSCmdletOutput("Amazon.Proton.Model.ServicePipeline or Amazon.Proton.Model.CancelServicePipelineDeploymentResponse",
        "This cmdlet returns an Amazon.Proton.Model.ServicePipeline object.",
        "The service call response (type Amazon.Proton.Model.CancelServicePipelineDeploymentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopPROServicePipelineDeploymentCmdlet : AmazonProtonClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ServiceName
        /// <summary>
        /// <para>
        /// <para>The name of the service with the service pipeline deployment to cancel.</para>
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
        public System.String ServiceName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Pipeline'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Proton.Model.CancelServicePipelineDeploymentResponse).
        /// Specifying the name of a property of type Amazon.Proton.Model.CancelServicePipelineDeploymentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Pipeline";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServiceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-PROServicePipelineDeployment (CancelServicePipelineDeployment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Proton.Model.CancelServicePipelineDeploymentResponse, StopPROServicePipelineDeploymentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ServiceName = this.ServiceName;
            #if MODULAR
            if (this.ServiceName == null && ParameterWasBound(nameof(this.ServiceName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Proton.Model.CancelServicePipelineDeploymentRequest();
            
            if (cmdletContext.ServiceName != null)
            {
                request.ServiceName = cmdletContext.ServiceName;
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
        
        private Amazon.Proton.Model.CancelServicePipelineDeploymentResponse CallAWSServiceOperation(IAmazonProton client, Amazon.Proton.Model.CancelServicePipelineDeploymentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Proton", "CancelServicePipelineDeployment");
            try
            {
                return client.CancelServicePipelineDeploymentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ServiceName { get; set; }
            public System.Func<Amazon.Proton.Model.CancelServicePipelineDeploymentResponse, StopPROServicePipelineDeploymentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Pipeline;
        }
        
    }
}
