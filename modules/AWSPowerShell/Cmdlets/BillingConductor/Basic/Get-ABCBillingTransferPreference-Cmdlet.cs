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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// Retrieves the auto billing group creation preference for a billing transfer.
    /// </summary>
    [Cmdlet("Get", "ABCBillingTransferPreference")]
    [OutputType("Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse")]
    [AWSCmdlet("Calls the AWSBillingConductor GetBillingTransferPreference API operation.", Operation = new[] {"GetBillingTransferPreference"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse",
        "This cmdlet returns an Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse object containing multiple properties."
    )]
    public partial class GetABCBillingTransferPreferenceCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ResponsibilityTransferArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the billing transfer whose preference you want to
        /// retrieve.</para>
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
        public System.String ResponsibilityTransferArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse, GetABCBillingTransferPreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ResponsibilityTransferArn = this.ResponsibilityTransferArn;
            #if MODULAR
            if (this.ResponsibilityTransferArn == null && ParameterWasBound(nameof(this.ResponsibilityTransferArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResponsibilityTransferArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.BillingConductor.Model.GetBillingTransferPreferenceRequest();
            
            if (cmdletContext.ResponsibilityTransferArn != null)
            {
                request.ResponsibilityTransferArn = cmdletContext.ResponsibilityTransferArn;
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
        
        private Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.GetBillingTransferPreferenceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "GetBillingTransferPreference");
            try
            {
                return client.GetBillingTransferPreferenceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ResponsibilityTransferArn { get; set; }
            public System.Func<Amazon.BillingConductor.Model.GetBillingTransferPreferenceResponse, GetABCBillingTransferPreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
