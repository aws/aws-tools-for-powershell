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
using Amazon.NetworkFirewall;
using Amazon.NetworkFirewall.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NWFW
{
    /// <summary>
    /// Begins capturing the flows in a firewall, according to the filters you define. Captures
    /// are similar, but not identical to snapshots. Capture operations provide visibility
    /// into flows that are not closed and are tracked by a firewall's flow table. Unlike
    /// snapshots, captures are a time-boxed view. 
    /// 
    ///  
    /// <para>
    /// A flow is network traffic that is monitored by a firewall, either by stateful or stateless
    /// rules. For traffic to be considered part of a flow, it must share Destination, DestinationPort,
    /// Direction, Protocol, Source, and SourcePort. 
    /// </para><note><para>
    /// To avoid encountering operation limits, you should avoid starting captures with broad
    /// filters, like wide IP ranges. Instead, we recommend you define more specific criteria
    /// with <c>FlowFilters</c>, like narrow IP ranges, ports, or protocols.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "NWFWFlowCapture", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkFirewall.Model.StartFlowCaptureResponse")]
    [AWSCmdlet("Calls the AWS Network Firewall StartFlowCapture API operation.", Operation = new[] {"StartFlowCapture"}, SelectReturnType = typeof(Amazon.NetworkFirewall.Model.StartFlowCaptureResponse))]
    [AWSCmdletOutput("Amazon.NetworkFirewall.Model.StartFlowCaptureResponse",
        "This cmdlet returns an Amazon.NetworkFirewall.Model.StartFlowCaptureResponse object containing multiple properties."
    )]
    public partial class StartNWFWFlowCaptureCmdlet : AmazonNetworkFirewallClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The ID of the Availability Zone where the firewall is located. For example, <c>us-east-2a</c>.</para><para>Defines the scope a flow operation. You can use up to 20 filters to configure a single
        /// flow operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter FirewallArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the firewall.</para>
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
        public System.String FirewallArn { get; set; }
        #endregion
        
        #region Parameter FlowFilter
        /// <summary>
        /// <para>
        /// <para>Defines the scope a flow operation. You can use up to 20 filters to configure a single
        /// flow operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("FlowFilters")]
        public Amazon.NetworkFirewall.Model.FlowFilter[] FlowFilter { get; set; }
        #endregion
        
        #region Parameter MinimumFlowAgeInSecond
        /// <summary>
        /// <para>
        /// <para>The reqested <c>FlowOperation</c> ignores flows with an age (in seconds) lower than
        /// <c>MinimumFlowAgeInSeconds</c>. You provide this for start commands.</para><note><para>We recommend setting this value to at least 1 minute (60 seconds) to reduce chance
        /// of capturing flows that are not yet established.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MinimumFlowAgeInSeconds")]
        public System.Int32? MinimumFlowAgeInSecond { get; set; }
        #endregion
        
        #region Parameter VpcEndpointAssociationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a VPC endpoint association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcEndpointAssociationArn { get; set; }
        #endregion
        
        #region Parameter VpcEndpointId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the primary endpoint associated with a firewall.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkFirewall.Model.StartFlowCaptureResponse).
        /// Specifying the name of a property of type Amazon.NetworkFirewall.Model.StartFlowCaptureResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FirewallArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-NWFWFlowCapture (StartFlowCapture)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkFirewall.Model.StartFlowCaptureResponse, StartNWFWFlowCaptureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.FirewallArn = this.FirewallArn;
            #if MODULAR
            if (this.FirewallArn == null && ParameterWasBound(nameof(this.FirewallArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FirewallArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.FlowFilter != null)
            {
                context.FlowFilter = new List<Amazon.NetworkFirewall.Model.FlowFilter>(this.FlowFilter);
            }
            #if MODULAR
            if (this.FlowFilter == null && ParameterWasBound(nameof(this.FlowFilter)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowFilter which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MinimumFlowAgeInSecond = this.MinimumFlowAgeInSecond;
            context.VpcEndpointAssociationArn = this.VpcEndpointAssociationArn;
            context.VpcEndpointId = this.VpcEndpointId;
            
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
            var request = new Amazon.NetworkFirewall.Model.StartFlowCaptureRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.FirewallArn != null)
            {
                request.FirewallArn = cmdletContext.FirewallArn;
            }
            if (cmdletContext.FlowFilter != null)
            {
                request.FlowFilters = cmdletContext.FlowFilter;
            }
            if (cmdletContext.MinimumFlowAgeInSecond != null)
            {
                request.MinimumFlowAgeInSeconds = cmdletContext.MinimumFlowAgeInSecond.Value;
            }
            if (cmdletContext.VpcEndpointAssociationArn != null)
            {
                request.VpcEndpointAssociationArn = cmdletContext.VpcEndpointAssociationArn;
            }
            if (cmdletContext.VpcEndpointId != null)
            {
                request.VpcEndpointId = cmdletContext.VpcEndpointId;
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
        
        private Amazon.NetworkFirewall.Model.StartFlowCaptureResponse CallAWSServiceOperation(IAmazonNetworkFirewall client, Amazon.NetworkFirewall.Model.StartFlowCaptureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Firewall", "StartFlowCapture");
            try
            {
                return client.StartFlowCaptureAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String FirewallArn { get; set; }
            public List<Amazon.NetworkFirewall.Model.FlowFilter> FlowFilter { get; set; }
            public System.Int32? MinimumFlowAgeInSecond { get; set; }
            public System.String VpcEndpointAssociationArn { get; set; }
            public System.String VpcEndpointId { get; set; }
            public System.Func<Amazon.NetworkFirewall.Model.StartFlowCaptureResponse, StartNWFWFlowCaptureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
