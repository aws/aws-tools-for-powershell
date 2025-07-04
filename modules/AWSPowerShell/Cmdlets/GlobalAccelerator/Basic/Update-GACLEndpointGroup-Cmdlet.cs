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
using Amazon.GlobalAccelerator;
using Amazon.GlobalAccelerator.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GACL
{
    /// <summary>
    /// Update an endpoint group. A resource must be valid and active when you add it as an
    /// endpoint.
    /// </summary>
    [Cmdlet("Update", "GACLEndpointGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GlobalAccelerator.Model.EndpointGroup")]
    [AWSCmdlet("Calls the AWS Global Accelerator UpdateEndpointGroup API operation.", Operation = new[] {"UpdateEndpointGroup"}, SelectReturnType = typeof(Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse))]
    [AWSCmdletOutput("Amazon.GlobalAccelerator.Model.EndpointGroup or Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse",
        "This cmdlet returns an Amazon.GlobalAccelerator.Model.EndpointGroup object.",
        "The service call response (type Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateGACLEndpointGroupCmdlet : AmazonGlobalAcceleratorClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndpointConfiguration
        /// <summary>
        /// <para>
        /// <para>The list of endpoint objects. A resource must be valid and active when you add it
        /// as an endpoint.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EndpointConfigurations")]
        public Amazon.GlobalAccelerator.Model.EndpointConfiguration[] EndpointConfiguration { get; set; }
        #endregion
        
        #region Parameter EndpointGroupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the endpoint group.</para>
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
        public System.String EndpointGroupArn { get; set; }
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
        /// is associated with. If the listener port is a list of ports, Global Accelerator uses
        /// the first port in the list.</para>
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
        
        #region Parameter IsEndpointConfigurationsSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.GlobalAccelerator.Model.UpdateEndpointGroupRequest.EndpointConfigurations" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// <para>If this property is set to false the property <seealso cref="P:Amazon.GlobalAccelerator.Model.UpdateEndpointGroupRequest.EndpointConfigurations" /> will be reset to null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsEndpointConfigurationsSet { get; set; }
        #endregion
        
        #region Parameter IsPortOverridesSet
        /// <summary>
        /// <para>
        /// This property is set to true if the property <seealso cref="P:Amazon.GlobalAccelerator.Model.UpdateEndpointGroupRequest.PortOverrides" />
        /// is set; false otherwise.
        /// This property can be used to determine if the related property
        /// was returned by a service response or if the related property
        /// should be sent to the service during a service call.
        /// <para>If this property is set to false the property <seealso cref="P:Amazon.GlobalAccelerator.Model.UpdateEndpointGroupRequest.PortOverrides" /> will be reset to null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IsPortOverridesSet { get; set; }
        #endregion
        
        #region Parameter PortOverride
        /// <summary>
        /// <para>
        /// <para>Override specific listener ports used to route traffic to endpoints that are part
        /// of this endpoint group. For example, you can create a port override in which the listener
        /// receives user traffic on ports 80 and 443, but your accelerator routes that traffic
        /// to ports 1080 and 1443, respectively, on the endpoints.</para><para>For more information, see <a href="https://docs.aws.amazon.com/global-accelerator/latest/dg/about-endpoint-groups-port-override.html">
        /// Overriding listener ports</a> in the <i>Global Accelerator Developer Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse).
        /// Specifying the name of a property of type Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EndpointGroup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EndpointGroupArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GACLEndpointGroup (UpdateEndpointGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse, UpdateGACLEndpointGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.EndpointConfiguration != null)
            {
                context.EndpointConfiguration = new List<Amazon.GlobalAccelerator.Model.EndpointConfiguration>(this.EndpointConfiguration);
            }
            context.IsEndpointConfigurationsSet = this.IsEndpointConfigurationsSet;
            if (!ParameterWasBound(nameof(this.IsEndpointConfigurationsSet)) && this.EndpointConfiguration != null)
            {
                context.IsEndpointConfigurationsSet = true;
            }
            context.EndpointGroupArn = this.EndpointGroupArn;
            #if MODULAR
            if (this.EndpointGroupArn == null && ParameterWasBound(nameof(this.EndpointGroupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EndpointGroupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.HealthCheckIntervalSecond = this.HealthCheckIntervalSecond;
            context.HealthCheckPath = this.HealthCheckPath;
            context.HealthCheckPort = this.HealthCheckPort;
            context.HealthCheckProtocol = this.HealthCheckProtocol;
            if (this.PortOverride != null)
            {
                context.PortOverride = new List<Amazon.GlobalAccelerator.Model.PortOverride>(this.PortOverride);
            }
            context.IsPortOverridesSet = this.IsPortOverridesSet;
            if (!ParameterWasBound(nameof(this.IsPortOverridesSet)) && this.PortOverride != null)
            {
                context.IsPortOverridesSet = true;
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
            var request = new Amazon.GlobalAccelerator.Model.UpdateEndpointGroupRequest();
            
            if (cmdletContext.EndpointConfiguration != null)
            {
                request.EndpointConfigurations = cmdletContext.EndpointConfiguration;
            }
            if (cmdletContext.IsEndpointConfigurationsSet != null)
            {
                request.IsEndpointConfigurationsSet = cmdletContext.IsEndpointConfigurationsSet.Value;
            }
            if (cmdletContext.EndpointGroupArn != null)
            {
                request.EndpointGroupArn = cmdletContext.EndpointGroupArn;
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
            if (cmdletContext.PortOverride != null)
            {
                request.PortOverrides = cmdletContext.PortOverride;
            }
            if (cmdletContext.IsPortOverridesSet != null)
            {
                request.IsPortOverridesSet = cmdletContext.IsPortOverridesSet.Value;
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
        
        private Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse CallAWSServiceOperation(IAmazonGlobalAccelerator client, Amazon.GlobalAccelerator.Model.UpdateEndpointGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Global Accelerator", "UpdateEndpointGroup");
            try
            {
                return client.UpdateEndpointGroupAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? IsEndpointConfigurationsSet { get; set; }
            public System.String EndpointGroupArn { get; set; }
            public System.Int32? HealthCheckIntervalSecond { get; set; }
            public System.String HealthCheckPath { get; set; }
            public System.Int32? HealthCheckPort { get; set; }
            public Amazon.GlobalAccelerator.HealthCheckProtocol HealthCheckProtocol { get; set; }
            public List<Amazon.GlobalAccelerator.Model.PortOverride> PortOverride { get; set; }
            public System.Boolean? IsPortOverridesSet { get; set; }
            public System.Int32? ThresholdCount { get; set; }
            public System.Single? TrafficDialPercentage { get; set; }
            public System.Func<Amazon.GlobalAccelerator.Model.UpdateEndpointGroupResponse, UpdateGACLEndpointGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EndpointGroup;
        }
        
    }
}
