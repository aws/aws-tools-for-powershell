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
using Amazon.Private5G;
using Amazon.Private5G.Model;

namespace Amazon.PowerShell.Cmdlets.PV5G
{
    /// <summary>
    /// Gets the specified network.
    /// </summary>
    [Cmdlet("Get", "PV5GNetwork")]
    [OutputType("Amazon.Private5G.Model.Network")]
    [AWSCmdlet("Calls the AWS Private 5G GetNetwork API operation.", Operation = new[] {"GetNetwork"}, SelectReturnType = typeof(Amazon.Private5G.Model.GetNetworkResponse))]
    [AWSCmdletOutput("Amazon.Private5G.Model.Network or Amazon.Private5G.Model.GetNetworkResponse",
        "This cmdlet returns an Amazon.Private5G.Model.Network object.",
        "The service call response (type Amazon.Private5G.Model.GetNetworkResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetPV5GNetworkCmdlet : AmazonPrivate5GClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter NetworkArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the network.</para>
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
        public System.String NetworkArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Network'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Private5G.Model.GetNetworkResponse).
        /// Specifying the name of a property of type Amazon.Private5G.Model.GetNetworkResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Network";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Private5G.Model.GetNetworkResponse, GetPV5GNetworkCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.NetworkArn = this.NetworkArn;
            #if MODULAR
            if (this.NetworkArn == null && ParameterWasBound(nameof(this.NetworkArn)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Private5G.Model.GetNetworkRequest();
            
            if (cmdletContext.NetworkArn != null)
            {
                request.NetworkArn = cmdletContext.NetworkArn;
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
        
        private Amazon.Private5G.Model.GetNetworkResponse CallAWSServiceOperation(IAmazonPrivate5G client, Amazon.Private5G.Model.GetNetworkRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Private 5G", "GetNetwork");
            try
            {
                return client.GetNetworkAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String NetworkArn { get; set; }
            public System.Func<Amazon.Private5G.Model.GetNetworkResponse, GetPV5GNetworkCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Network;
        }
        
    }
}
