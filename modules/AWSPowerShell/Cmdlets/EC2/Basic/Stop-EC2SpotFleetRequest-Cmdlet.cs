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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Cancels the specified Spot Fleet requests.
    /// 
    ///  
    /// <para>
    /// After you cancel a Spot Fleet request, the Spot Fleet launches no new instances.
    /// </para><para>
    /// You must also specify whether a canceled Spot Fleet request should terminate its instances.
    /// If you choose to terminate the instances, the Spot Fleet request enters the <c>cancelled_terminating</c>
    /// state. Otherwise, the Spot Fleet request enters the <c>cancelled_running</c> state
    /// and the instances continue to run until they are interrupted or you terminate them
    /// manually.
    /// </para><para><b>Restrictions</b></para><ul><li><para>
    /// You can delete up to 100 fleets in a single request. If you exceed the specified number,
    /// no fleets are deleted.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Stop", "EC2SpotFleetRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.CancelSpotFleetRequestsResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CancelSpotFleetRequests API operation.", Operation = new[] {"CancelSpotFleetRequests"}, SelectReturnType = typeof(Amazon.EC2.Model.CancelSpotFleetRequestsResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.CancelSpotFleetRequestsResponse",
        "This cmdlet returns an Amazon.EC2.Model.CancelSpotFleetRequestsResponse object containing multiple properties."
    )]
    public partial class StopEC2SpotFleetRequestCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter SpotFleetRequestId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Spot Fleet requests.</para><para>Constraint: You can specify up to 100 IDs in a single request.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("SpotFleetRequestIds")]
        public System.String[] SpotFleetRequestId { get; set; }
        #endregion
        
        #region Parameter TerminateInstance
        /// <summary>
        /// <para>
        /// <para>Indicates whether to terminate the associated instances when the Spot Fleet request
        /// is canceled. The default is to terminate the instances.</para><para>To let the instances continue to run after the Spot Fleet request is canceled, specify
        /// <c>no-terminate-instances</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TerminateInstances")]
        public System.Boolean? TerminateInstance { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CancelSpotFleetRequestsResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CancelSpotFleetRequestsResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SpotFleetRequestId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-EC2SpotFleetRequest (CancelSpotFleetRequests)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CancelSpotFleetRequestsResponse, StopEC2SpotFleetRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DryRun = this.DryRun;
            if (this.SpotFleetRequestId != null)
            {
                context.SpotFleetRequestId = new List<System.String>(this.SpotFleetRequestId);
            }
            #if MODULAR
            if (this.SpotFleetRequestId == null && ParameterWasBound(nameof(this.SpotFleetRequestId)))
            {
                WriteWarning("You are passing $null as a value for parameter SpotFleetRequestId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TerminateInstance = this.TerminateInstance;
            #if MODULAR
            if (this.TerminateInstance == null && ParameterWasBound(nameof(this.TerminateInstance)))
            {
                WriteWarning("You are passing $null as a value for parameter TerminateInstance which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.CancelSpotFleetRequestsRequest();
            
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.SpotFleetRequestId != null)
            {
                request.SpotFleetRequestIds = cmdletContext.SpotFleetRequestId;
            }
            if (cmdletContext.TerminateInstance != null)
            {
                request.TerminateInstances = cmdletContext.TerminateInstance.Value;
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
        
        private Amazon.EC2.Model.CancelSpotFleetRequestsResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CancelSpotFleetRequestsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CancelSpotFleetRequests");
            try
            {
                return client.CancelSpotFleetRequestsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? DryRun { get; set; }
            public List<System.String> SpotFleetRequestId { get; set; }
            public System.Boolean? TerminateInstance { get; set; }
            public System.Func<Amazon.EC2.Model.CancelSpotFleetRequestsResponse, StopEC2SpotFleetRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
