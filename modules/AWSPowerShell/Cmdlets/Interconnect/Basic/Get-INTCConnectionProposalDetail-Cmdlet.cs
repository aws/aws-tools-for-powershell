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
using Amazon.Interconnect;
using Amazon.Interconnect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INTC
{
    /// <summary>
    /// Describes the details of a connection proposal generated at a partner's portal.
    /// </summary>
    [Cmdlet("Get", "INTCConnectionProposalDetail")]
    [OutputType("Amazon.Interconnect.Model.DescribeConnectionProposalResponse")]
    [AWSCmdlet("Calls the Interconnect DescribeConnectionProposal API operation.", Operation = new[] {"DescribeConnectionProposal"}, SelectReturnType = typeof(Amazon.Interconnect.Model.DescribeConnectionProposalResponse))]
    [AWSCmdletOutput("Amazon.Interconnect.Model.DescribeConnectionProposalResponse",
        "This cmdlet returns an Amazon.Interconnect.Model.DescribeConnectionProposalResponse object containing multiple properties."
    )]
    public partial class GetINTCConnectionProposalDetailCmdlet : AmazonInterconnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActivationKey
        /// <summary>
        /// <para>
        /// <para>An Activation Key that was generated on a supported partner's portal. This key captures
        /// the desired parameters from the initial creation request.</para>
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
        public System.String ActivationKey { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Interconnect.Model.DescribeConnectionProposalResponse).
        /// Specifying the name of a property of type Amazon.Interconnect.Model.DescribeConnectionProposalResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.Interconnect.Model.DescribeConnectionProposalResponse, GetINTCConnectionProposalDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActivationKey = this.ActivationKey;
            #if MODULAR
            if (this.ActivationKey == null && ParameterWasBound(nameof(this.ActivationKey)))
            {
                WriteWarning("You are passing $null as a value for parameter ActivationKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Interconnect.Model.DescribeConnectionProposalRequest();
            
            if (cmdletContext.ActivationKey != null)
            {
                request.ActivationKey = cmdletContext.ActivationKey;
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
        
        private Amazon.Interconnect.Model.DescribeConnectionProposalResponse CallAWSServiceOperation(IAmazonInterconnect client, Amazon.Interconnect.Model.DescribeConnectionProposalRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Interconnect", "DescribeConnectionProposal");
            try
            {
                return client.DescribeConnectionProposalAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActivationKey { get; set; }
            public System.Func<Amazon.Interconnect.Model.DescribeConnectionProposalResponse, GetINTCConnectionProposalDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
