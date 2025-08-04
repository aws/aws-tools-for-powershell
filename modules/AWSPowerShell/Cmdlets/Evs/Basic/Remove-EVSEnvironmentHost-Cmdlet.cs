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
using Amazon.Evs;
using Amazon.Evs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVS
{
    /// <summary>
    /// Amazon.Evs.IAmazonEvs.DeleteEnvironmentHost
    /// </summary>
    [Cmdlet("Remove", "EVSEnvironmentHost", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Evs.Model.DeleteEnvironmentHostResponse")]
    [AWSCmdlet("Calls the Amazon Elastic VMware Service DeleteEnvironmentHost API operation.", Operation = new[] {"DeleteEnvironmentHost"}, SelectReturnType = typeof(Amazon.Evs.Model.DeleteEnvironmentHostResponse))]
    [AWSCmdletOutput("Amazon.Evs.Model.DeleteEnvironmentHostResponse",
        "This cmdlet returns an Amazon.Evs.Model.DeleteEnvironmentHostResponse object containing multiple properties."
    )]
    public partial class RemoveEVSEnvironmentHostCmdlet : AmazonEvsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EnvironmentId
        /// <summary>
        /// <para>
        /// <para>A unique ID for the host's environment.</para>
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
        
        #region Parameter HostName
        /// <summary>
        /// <para>
        /// <para>The DNS hostname associated with the host to be deleted.</para>
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
        public System.String HostName { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para><note><para>This parameter is not used in Amazon EVS currently. If you supply input for this parameter,
        /// it will have no effect.</para></note><para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the host deletion request. If you do not specify a client token, a randomly generated
        /// token is used for the request to ensure idempotency.</para></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Evs.Model.DeleteEnvironmentHostResponse).
        /// Specifying the name of a property of type Amazon.Evs.Model.DeleteEnvironmentHostResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EnvironmentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-EVSEnvironmentHost (DeleteEnvironmentHost)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Evs.Model.DeleteEnvironmentHostResponse, RemoveEVSEnvironmentHostCmdlet>(Select) ??
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
            context.HostName = this.HostName;
            #if MODULAR
            if (this.HostName == null && ParameterWasBound(nameof(this.HostName)))
            {
                WriteWarning("You are passing $null as a value for parameter HostName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Evs.Model.DeleteEnvironmentHostRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EnvironmentId != null)
            {
                request.EnvironmentId = cmdletContext.EnvironmentId;
            }
            if (cmdletContext.HostName != null)
            {
                request.HostName = cmdletContext.HostName;
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
        
        private Amazon.Evs.Model.DeleteEnvironmentHostResponse CallAWSServiceOperation(IAmazonEvs client, Amazon.Evs.Model.DeleteEnvironmentHostRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic VMware Service", "DeleteEnvironmentHost");
            try
            {
                return client.DeleteEnvironmentHostAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String HostName { get; set; }
            public System.Func<Amazon.Evs.Model.DeleteEnvironmentHostResponse, RemoveEVSEnvironmentHostCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
