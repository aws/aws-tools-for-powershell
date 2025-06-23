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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a Traffic Mirror session.
    /// 
    ///  
    /// <para>
    /// A Traffic Mirror session actively copies packets from a Traffic Mirror source to a
    /// Traffic Mirror target. Create a filter, and then assign it to the session to define
    /// a subset of the traffic to mirror, for example all TCP traffic.
    /// </para><para>
    /// The Traffic Mirror source and the Traffic Mirror target (monitoring appliances) can
    /// be in the same VPC, or in a different VPC connected via VPC peering or a transit gateway.
    /// 
    /// </para><para>
    /// By default, no traffic is mirrored. Use <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/API_CreateTrafficMirrorFilter.html">CreateTrafficMirrorFilter</a>
    /// to create filter rules that specify the traffic to mirror.
    /// </para>
    /// </summary>
    [Cmdlet("New", "EC2TrafficMirrorSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.TrafficMirrorSession")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateTrafficMirrorSession API operation.", Operation = new[] {"CreateTrafficMirrorSession"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateTrafficMirrorSessionResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.TrafficMirrorSession or Amazon.EC2.Model.CreateTrafficMirrorSessionResponse",
        "This cmdlet returns an Amazon.EC2.Model.TrafficMirrorSession object.",
        "The service call response (type Amazon.EC2.Model.CreateTrafficMirrorSessionResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2TrafficMirrorSessionCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the Traffic Mirror session.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
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
        
        #region Parameter NetworkInterfaceId
        /// <summary>
        /// <para>
        /// <para>The ID of the source network interface.</para>
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
        public System.String NetworkInterfaceId { get; set; }
        #endregion
        
        #region Parameter PacketLength
        /// <summary>
        /// <para>
        /// <para>The number of bytes in each packet to mirror. These are bytes after the VXLAN header.
        /// Do not specify this parameter when you want to mirror the entire packet. To mirror
        /// a subset of the packet, set this to the length (in bytes) that you want to mirror.
        /// For example, if you set this value to 100, then the first 100 bytes that meet the
        /// filter criteria are copied to the target.</para><para>If you do not want to mirror the entire packet, use the <c>PacketLength</c> parameter
        /// to specify the number of bytes in each packet to mirror.</para><para>For sessions with Network Load Balancer (NLB) Traffic Mirror targets the default <c>PacketLength</c>
        /// will be set to 8500. Valid values are 1-8500. Setting a <c>PacketLength</c> greater
        /// than 8500 will result in an error response.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PacketLength { get; set; }
        #endregion
        
        #region Parameter SessionNumber
        /// <summary>
        /// <para>
        /// <para>The session number determines the order in which sessions are evaluated when an interface
        /// is used by multiple sessions. The first session with a matching filter is the one
        /// that mirrors the packets.</para><para>Valid values are 1-32766.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SessionNumber { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>The tags to assign to a Traffic Mirror session.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorFilterId
        /// <summary>
        /// <para>
        /// <para>The ID of the Traffic Mirror filter.</para>
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
        public System.String TrafficMirrorFilterId { get; set; }
        #endregion
        
        #region Parameter TrafficMirrorTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the Traffic Mirror target.</para>
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
        public System.String TrafficMirrorTargetId { get; set; }
        #endregion
        
        #region Parameter VirtualNetworkId
        /// <summary>
        /// <para>
        /// <para>The VXLAN ID for the Traffic Mirror session. For more information about the VXLAN
        /// protocol, see <a href="https://datatracker.ietf.org/doc/html/rfc7348">RFC 7348</a>.
        /// If you do not specify a <c>VirtualNetworkId</c>, an account-wide unique ID is chosen
        /// at random.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? VirtualNetworkId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/ec2/latest/devguide/ec2-api-idempotency.html">How
        /// to ensure idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TrafficMirrorSession'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateTrafficMirrorSessionResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateTrafficMirrorSessionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TrafficMirrorSession";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TrafficMirrorFilterId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2TrafficMirrorSession (CreateTrafficMirrorSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateTrafficMirrorSessionResponse, NewEC2TrafficMirrorSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.DryRun = this.DryRun;
            context.NetworkInterfaceId = this.NetworkInterfaceId;
            #if MODULAR
            if (this.NetworkInterfaceId == null && ParameterWasBound(nameof(this.NetworkInterfaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkInterfaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PacketLength = this.PacketLength;
            context.SessionNumber = this.SessionNumber;
            #if MODULAR
            if (this.SessionNumber == null && ParameterWasBound(nameof(this.SessionNumber)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionNumber which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
            }
            context.TrafficMirrorFilterId = this.TrafficMirrorFilterId;
            #if MODULAR
            if (this.TrafficMirrorFilterId == null && ParameterWasBound(nameof(this.TrafficMirrorFilterId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficMirrorFilterId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TrafficMirrorTargetId = this.TrafficMirrorTargetId;
            #if MODULAR
            if (this.TrafficMirrorTargetId == null && ParameterWasBound(nameof(this.TrafficMirrorTargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter TrafficMirrorTargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VirtualNetworkId = this.VirtualNetworkId;
            
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
            var request = new Amazon.EC2.Model.CreateTrafficMirrorSessionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.NetworkInterfaceId != null)
            {
                request.NetworkInterfaceId = cmdletContext.NetworkInterfaceId;
            }
            if (cmdletContext.PacketLength != null)
            {
                request.PacketLength = cmdletContext.PacketLength.Value;
            }
            if (cmdletContext.SessionNumber != null)
            {
                request.SessionNumber = cmdletContext.SessionNumber.Value;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
            }
            if (cmdletContext.TrafficMirrorFilterId != null)
            {
                request.TrafficMirrorFilterId = cmdletContext.TrafficMirrorFilterId;
            }
            if (cmdletContext.TrafficMirrorTargetId != null)
            {
                request.TrafficMirrorTargetId = cmdletContext.TrafficMirrorTargetId;
            }
            if (cmdletContext.VirtualNetworkId != null)
            {
                request.VirtualNetworkId = cmdletContext.VirtualNetworkId.Value;
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
        
        private Amazon.EC2.Model.CreateTrafficMirrorSessionResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateTrafficMirrorSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateTrafficMirrorSession");
            try
            {
                return client.CreateTrafficMirrorSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String NetworkInterfaceId { get; set; }
            public System.Int32? PacketLength { get; set; }
            public System.Int32? SessionNumber { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.String TrafficMirrorFilterId { get; set; }
            public System.String TrafficMirrorTargetId { get; set; }
            public System.Int32? VirtualNetworkId { get; set; }
            public System.Func<Amazon.EC2.Model.CreateTrafficMirrorSessionResponse, NewEC2TrafficMirrorSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TrafficMirrorSession;
        }
        
    }
}
