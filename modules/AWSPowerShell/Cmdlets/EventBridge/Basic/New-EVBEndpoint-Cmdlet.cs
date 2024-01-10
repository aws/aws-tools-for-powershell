/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Creates a global endpoint. Global endpoints improve your application's availability
    /// by making it regional-fault tolerant. To do this, you define a primary and secondary
    /// Region with event buses in each Region. You also create a Amazon Route 53 health check
    /// that will tell EventBridge to route events to the secondary Region when an "unhealthy"
    /// state is encountered and events will be routed back to the primary Region when the
    /// health check reports a "healthy" state.
    /// </summary>
    [Cmdlet("New", "EVBEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridge.Model.CreateEndpointResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge CreateEndpoint API operation.", Operation = new[] {"CreateEndpoint"}, SelectReturnType = typeof(Amazon.EventBridge.Model.CreateEndpointResponse))]
    [AWSCmdletOutput("Amazon.EventBridge.Model.CreateEndpointResponse",
        "This cmdlet returns an Amazon.EventBridge.Model.CreateEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEVBEndpointCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the global endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventBus
        /// <summary>
        /// <para>
        /// <para>Define the event buses used. </para><important><para>The names of the event buses must be identical in each Region.</para></important>
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
        [Alias("EventBuses")]
        public Amazon.EventBridge.Model.EndpointEventBus[] EventBus { get; set; }
        #endregion
        
        #region Parameter Primary_HealthCheck
        /// <summary>
        /// <para>
        /// <para>The ARN of the health check used by the endpoint to determine whether failover is
        /// triggered.</para>
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
        [Alias("RoutingConfig_FailoverConfig_Primary_HealthCheck")]
        public System.String Primary_HealthCheck { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the global endpoint. For example, <c>"Name":"us-east-2-custom_bus_A-endpoint"</c>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role used for replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Secondary_Route
        /// <summary>
        /// <para>
        /// <para>Defines the secondary Region.</para>
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
        [Alias("RoutingConfig_FailoverConfig_Secondary_Route")]
        public System.String Secondary_Route { get; set; }
        #endregion
        
        #region Parameter ReplicationConfig_State
        /// <summary>
        /// <para>
        /// <para>The state of event replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridge.ReplicationState")]
        public Amazon.EventBridge.ReplicationState ReplicationConfig_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.CreateEndpointResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.CreateEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EVBEndpoint (CreateEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.CreateEndpointResponse, NewEVBEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            if (this.EventBus != null)
            {
                context.EventBus = new List<Amazon.EventBridge.Model.EndpointEventBus>(this.EventBus);
            }
            #if MODULAR
            if (this.EventBus == null && ParameterWasBound(nameof(this.EventBus)))
            {
                WriteWarning("You are passing $null as a value for parameter EventBus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationConfig_State = this.ReplicationConfig_State;
            context.RoleArn = this.RoleArn;
            context.Primary_HealthCheck = this.Primary_HealthCheck;
            #if MODULAR
            if (this.Primary_HealthCheck == null && ParameterWasBound(nameof(this.Primary_HealthCheck)))
            {
                WriteWarning("You are passing $null as a value for parameter Primary_HealthCheck which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Secondary_Route = this.Secondary_Route;
            #if MODULAR
            if (this.Secondary_Route == null && ParameterWasBound(nameof(this.Secondary_Route)))
            {
                WriteWarning("You are passing $null as a value for parameter Secondary_Route which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EventBridge.Model.CreateEndpointRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventBus != null)
            {
                request.EventBuses = cmdletContext.EventBus;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ReplicationConfig
            var requestReplicationConfigIsNull = true;
            request.ReplicationConfig = new Amazon.EventBridge.Model.ReplicationConfig();
            Amazon.EventBridge.ReplicationState requestReplicationConfig_replicationConfig_State = null;
            if (cmdletContext.ReplicationConfig_State != null)
            {
                requestReplicationConfig_replicationConfig_State = cmdletContext.ReplicationConfig_State;
            }
            if (requestReplicationConfig_replicationConfig_State != null)
            {
                request.ReplicationConfig.State = requestReplicationConfig_replicationConfig_State;
                requestReplicationConfigIsNull = false;
            }
             // determine if request.ReplicationConfig should be set to null
            if (requestReplicationConfigIsNull)
            {
                request.ReplicationConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate RoutingConfig
            var requestRoutingConfigIsNull = true;
            request.RoutingConfig = new Amazon.EventBridge.Model.RoutingConfig();
            Amazon.EventBridge.Model.FailoverConfig requestRoutingConfig_routingConfig_FailoverConfig = null;
            
             // populate FailoverConfig
            var requestRoutingConfig_routingConfig_FailoverConfigIsNull = true;
            requestRoutingConfig_routingConfig_FailoverConfig = new Amazon.EventBridge.Model.FailoverConfig();
            Amazon.EventBridge.Model.Primary requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary = null;
            
             // populate Primary
            var requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_PrimaryIsNull = true;
            requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary = new Amazon.EventBridge.Model.Primary();
            System.String requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary_primary_HealthCheck = null;
            if (cmdletContext.Primary_HealthCheck != null)
            {
                requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary_primary_HealthCheck = cmdletContext.Primary_HealthCheck;
            }
            if (requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary_primary_HealthCheck != null)
            {
                requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary.HealthCheck = requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary_primary_HealthCheck;
                requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_PrimaryIsNull = false;
            }
             // determine if requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary should be set to null
            if (requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_PrimaryIsNull)
            {
                requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary = null;
            }
            if (requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary != null)
            {
                requestRoutingConfig_routingConfig_FailoverConfig.Primary = requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Primary;
                requestRoutingConfig_routingConfig_FailoverConfigIsNull = false;
            }
            Amazon.EventBridge.Model.Secondary requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary = null;
            
             // populate Secondary
            var requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_SecondaryIsNull = true;
            requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary = new Amazon.EventBridge.Model.Secondary();
            System.String requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary_secondary_Route = null;
            if (cmdletContext.Secondary_Route != null)
            {
                requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary_secondary_Route = cmdletContext.Secondary_Route;
            }
            if (requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary_secondary_Route != null)
            {
                requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary.Route = requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary_secondary_Route;
                requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_SecondaryIsNull = false;
            }
             // determine if requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary should be set to null
            if (requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_SecondaryIsNull)
            {
                requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary = null;
            }
            if (requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary != null)
            {
                requestRoutingConfig_routingConfig_FailoverConfig.Secondary = requestRoutingConfig_routingConfig_FailoverConfig_routingConfig_FailoverConfig_Secondary;
                requestRoutingConfig_routingConfig_FailoverConfigIsNull = false;
            }
             // determine if requestRoutingConfig_routingConfig_FailoverConfig should be set to null
            if (requestRoutingConfig_routingConfig_FailoverConfigIsNull)
            {
                requestRoutingConfig_routingConfig_FailoverConfig = null;
            }
            if (requestRoutingConfig_routingConfig_FailoverConfig != null)
            {
                request.RoutingConfig.FailoverConfig = requestRoutingConfig_routingConfig_FailoverConfig;
                requestRoutingConfigIsNull = false;
            }
             // determine if request.RoutingConfig should be set to null
            if (requestRoutingConfigIsNull)
            {
                request.RoutingConfig = null;
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
        
        private Amazon.EventBridge.Model.CreateEndpointResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.CreateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "CreateEndpoint");
            try
            {
                #if DESKTOP
                return client.CreateEndpoint(request);
                #elif CORECLR
                return client.CreateEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public List<Amazon.EventBridge.Model.EndpointEventBus> EventBus { get; set; }
            public System.String Name { get; set; }
            public Amazon.EventBridge.ReplicationState ReplicationConfig_State { get; set; }
            public System.String RoleArn { get; set; }
            public System.String Primary_HealthCheck { get; set; }
            public System.String Secondary_Route { get; set; }
            public System.Func<Amazon.EventBridge.Model.CreateEndpointResponse, NewEVBEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
