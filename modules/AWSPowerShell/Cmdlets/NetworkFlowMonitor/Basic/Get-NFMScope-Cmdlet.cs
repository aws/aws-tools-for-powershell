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
using Amazon.NetworkFlowMonitor;
using Amazon.NetworkFlowMonitor.Model;

namespace Amazon.PowerShell.Cmdlets.NFM
{
    /// <summary>
    /// Gets information about a scope, including the name, status, tags, and target details.
    /// The scope in Network Flow Monitor is an account.
    /// </summary>
    [Cmdlet("Get", "NFMScope")]
    [OutputType("Amazon.NetworkFlowMonitor.Model.GetScopeResponse")]
    [AWSCmdlet("Calls the Network Flow Monitor GetScope API operation.", Operation = new[] {"GetScope"}, SelectReturnType = typeof(Amazon.NetworkFlowMonitor.Model.GetScopeResponse))]
    [AWSCmdletOutput("Amazon.NetworkFlowMonitor.Model.GetScopeResponse",
        "This cmdlet returns an Amazon.NetworkFlowMonitor.Model.GetScopeResponse object containing multiple properties."
    )]
    public partial class GetNFMScopeCmdlet : AmazonNetworkFlowMonitorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ScopeId
        /// <summary>
        /// <para>
        /// <para>The identifier for the scope that includes the resources you want to get data results
        /// for. A scope ID is an internally-generated identifier that includes all the resources
        /// for a specific root account. A scope ID is returned from a <c>CreateScope</c> API
        /// call.</para>
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
        public System.String ScopeId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFlowMonitor.Model.GetScopeResponse).
        /// Specifying the name of a property of type Amazon.NetworkFlowMonitor.Model.GetScopeResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFlowMonitor.Model.GetScopeResponse, GetNFMScopeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ScopeId = this.ScopeId;
            #if MODULAR
            if (this.ScopeId == null && ParameterWasBound(nameof(this.ScopeId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScopeId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkFlowMonitor.Model.GetScopeRequest();
            
            if (cmdletContext.ScopeId != null)
            {
                request.ScopeId = cmdletContext.ScopeId;
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
        
        private Amazon.NetworkFlowMonitor.Model.GetScopeResponse CallAWSServiceOperation(IAmazonNetworkFlowMonitor client, Amazon.NetworkFlowMonitor.Model.GetScopeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Network Flow Monitor", "GetScope");
            try
            {
                return client.GetScopeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ScopeId { get; set; }
            public System.Func<Amazon.NetworkFlowMonitor.Model.GetScopeResponse, GetNFMScopeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
