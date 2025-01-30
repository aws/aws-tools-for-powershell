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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Create an endpoint group for the specified listener. An endpoint group is a collection
    /// of endpoints in one Amazon Web Services Region. A resource must be valid and active
    /// when you add it as an endpoint.
    /// 
    ///  
    /// <para>
    /// For more information about endpoint types and requirements for endpoints that you
    /// can add to Global Accelerator, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/about-endpoints.html">
    /// Endpoints for standard accelerators</a> in the <i>Global Accelerator Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GACLEndpointGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.EndpointGroup")]
    [AWSCmdlet("Calls the AWS Global Accelerator CreateEndpointGroup API operation.", Operation = new[] {"CreateEndpointGroup"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.CreateEndpointGroupResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.EndpointGroup or Amazon.GlobalAccelerator.Model.CreateEndpointGroupResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.EndpointGroup object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.CreateEndpointGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGACLEndpointGroupCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EndpointConfiguration
        /// <summary>
        /// <para>
        /// <para>The list of endpoint objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfigurations")]
        public Amazon.GlobalAccelerator.Model.EndpointConfiguration[] EndpointConfiguration { get; set; }
        #endregion
        
        #region Parameter EndpointGroupRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region where the endpoint group is located. A listener can
        /// have only one endpoint group in a specific Region.</para>
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
        public System.String EndpointGroupRegion { get; set; }
        #endregion
        
        #region Parameter HealthCheckIntervalSecond
        /// <summary>
        /// <para>
        /// <para>The time—10 seconds or 30 seconds—between each health check for an endpoint. The default
        /// value is 30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckIntervalSeconds")]
        public System.Int32? HealthCheckIntervalSecond { get; set; }
        #endregion
        
        #region Parameter HealthCheckPath
        /// <summary>
        /// <para>
        /// <para>If the protocol is HTTP/S, then this specifies the path that is the destination for
        /// health check targets. The default value is slash (/).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HealthCheckPath { get; set; }
        #endregion
        
        #region Parameter HealthCheckPort
        /// <summary>
        /// <para>
        /// <para>The port that Global Accelerator uses to check the health of endpoints that are part
        /// of this endpoint group. The default port is the listener port that this endpoint group
        /// is associated with. If listener port is a list of ports, Global Accelerator uses the
        /// first port in the list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? HealthCheckPort { get; set; }
        #endregion
        
        #region Parameter HealthCheckProtocol
        /// <summary>
        /// <para>
        /// <para>The protocol that Global Accelerator uses to check the health of endpoints that are
        /// part of this endpoint group. The default value is TCP.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlobalAccelerator.HealthCheckProtocol")]
        public Amazon.GlobalAccelerator.HealthCheckProtocol HealthCheckProtocol { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency—that
        /// is, the uniqueness—of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter ListenerArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the listener.</para>
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
        public System.String ListenerArn { get; set; }
        #endregion
        
        #region Parameter PortOverride
        /// <summary>
        /// <para>
        /// <para>Override specific listener ports used to route traffic to endpoints that are part
        /// of this endpoint group. For example, you can create a port override in which the listener
        /// receives user traffic on ports 80 and 443, but your accelerator routes that traffic
        /// to ports 1080 and 1443, respectively, on the endpoints.</para><para>For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/about-endpoint-groups-port-override.html">
        /// Overriding listener ports</a> in the <i>Global Accelerator Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PortOverrides")]
        public Amazon.GlobalAccelerator.Model.PortOverride[] PortOverride { get; set; }
        #endregion
        
        #region Parameter ThresholdCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive health checks required to set the state of a healthy endpoint
        /// to unhealthy, or to set an unhealthy endpoint to healthy. The default value is 3.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ThresholdCount { get; set; }
        #endregion
        
        #region Parameter TrafficDialPercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of traffic to send to an Amazon Web Services Region. Additional traffic
        /// is distributed to other endpoint groups for this listener. </para><para>Use this action to increase (dial up) or decrease (dial down) traffic to a specific
        /// Region. The percentage is applied to the traffic that would otherwise have been routed
        /// to the Region based on optimal routing.</para><para>The default value is 100.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? TrafficDialPercentage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EndpointGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.CreateEndpointGroupResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.CreateEndpointGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointGroup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ListenerArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ListenerArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ListenerArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ListenerArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GACLEndpointGroup (CreateEndpointGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.CreateEndpointGroupResponse, NewGACLEndpointGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ListenerArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.EndpointConfiguration != null)
            {
                context.EndpointConfiguration = new List<Amazon.GlobalAccelerator.Model.EndpointConfiguration>(this.EndpointConfiguration);
            }
            context.EndpointGroupRegion = this.EndpointGroupRegion;
            #if MODULAR
            if (this.EndpointGroupRegion == null && ParameterWasBound(nameof(this.EndpointGroupRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointGroupRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheckIntervalSecond = this.HealthCheckIntervalSecond;
            context.HealthCheckPath = this.HealthCheckPath;
            context.HealthCheckPort = this.HealthCheckPort;
            context.HealthCheckProtocol = this.HealthCheckProtocol;
            context.IdempotencyToken = this.IdempotencyToken;
            context.ListenerArn = this.ListenerArn;
            #if MODULAR
            if (this.ListenerArn == null && ParameterWasBound(nameof(this.ListenerArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ListenerArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PortOverride != null)
            {
                context.PortOverride = new List<Amazon.GlobalAccelerator.Model.PortOverride>(this.PortOverride);
            }
            context.ThresholdCount = this.ThresholdCount;
            context.TrafficDialPercentage = this.TrafficDialPercentage;
            
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
            var request = new Amazon.GlobalAccelerator.Model.CreateEndpointGroupRequest();
            
            if (cmdletContext.EndpointConfiguration != null)
            {
                request.EndpointConfigurations = cmdletContext.EndpointConfiguration;
            }
            if (cmdletContext.EndpointGroupRegion != null)
            {
                request.EndpointGroupRegion = cmdletContext.EndpointGroupRegion;
            }
            if (cmdletContext.HealthCheckIntervalSecond != null)
            {
                request.HealthCheckIntervalSeconds = cmdletContext.HealthCheckIntervalSecond.Value;
            }
            if (cmdletContext.HealthCheckPath != null)
            {
                request.HealthCheckPath = cmdletContext.HealthCheckPath;
            }
            if (cmdletContext.HealthCheckPort != null)
            {
                request.HealthCheckPort = cmdletContext.HealthCheckPort.Value;
            }
            if (cmdletContext.HealthCheckProtocol != null)
            {
                request.HealthCheckProtocol = cmdletContext.HealthCheckProtocol;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.ListenerArn != null)
            {
                request.ListenerArn = cmdletContext.ListenerArn;
            }
            if (cmdletContext.PortOverride != null)
            {
                request.PortOverrides = cmdletContext.PortOverride;
            }
            if (cmdletContext.ThresholdCount != null)
            {
                request.ThresholdCount = cmdletContext.ThresholdCount.Value;
            }
            if (cmdletContext.TrafficDialPercentage != null)
            {
                request.TrafficDialPercentage = cmdletContext.TrafficDialPercentage.Value;
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
        
        private Amazon.GlobalAccelerator.Model.CreateEndpointGroupResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.CreateEndpointGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "CreateEndpointGroup");
            try
            {
                #if DESKTOP
                return client.CreateEndpointGroup(request);
                #elif CORECLR
                return client.CreateEndpointGroupAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public List<Amazon.GlobalAccelerator.Model.EndpointConfiguration> EndpointConfiguration { get; set; }
            public System.String EndpointGroupRegion { get; set; }
            public System.Int32? HealthCheckIntervalSecond { get; set; }
            public System.String HealthCheckPath { get; set; }
            public System.Int32? HealthCheckPort { get; set; }
            public Amazon.GlobalAccelerator.HealthCheckProtocol HealthCheckProtocol { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String ListenerArn { get; set; }
            public List<Amazon.GlobalAccelerator.Model.PortOverride> PortOverride { get; set; }
            public System.Int32? ThresholdCount { get; set; }
            public System.Single? TrafficDialPercentage { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.CreateEndpointGroupResponse, NewGACLEndpointGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointGroup;
        }
        
    }
}
