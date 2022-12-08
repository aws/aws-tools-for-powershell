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
    /// Update an existing endpoint. For more information about global endpoints, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-global-endpoints.html">Making
    /// applications Regional-fault tolerant with global endpoints and event replication</a>
    /// in the Amazon EventBridge User Guide..
    /// </summary>
    [Cmdlet("Update", "EVBEndpoint", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridge.Model.UpdateEndpointResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge UpdateEndpoint API operation.", Operation = new[] {"UpdateEndpoint"}, SelectReturnType = typeof(Amazon.EventBridge.Model.UpdateEndpointResponse))]
    [AWSCmdletOutput("Amazon.EventBridge.Model.UpdateEndpointResponse",
        "This cmdlet returns an Amazon.EventBridge.Model.UpdateEndpointResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEVBEndpointCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventBus
        /// <summary>
        /// <para>
        /// <para>Define event buses used for replication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RoutingConfig_FailoverConfig_Primary_HealthCheck")]
        public System.String Primary_HealthCheck { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the endpoint you want to update.</para>
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
        /// <para>The ARN of the role used by event replication for this request.</para>
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
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.UpdateEndpointResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.UpdateEndpointResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EVBEndpoint (UpdateEndpoint)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.UpdateEndpointResponse, UpdateEVBEndpointCmdlet>(Select) ??
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
            context.Secondary_Route = this.Secondary_Route;
            
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
            var request = new Amazon.EventBridge.Model.UpdateEndpointRequest();
            
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
        
        private Amazon.EventBridge.Model.UpdateEndpointResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.UpdateEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "UpdateEndpoint");
            try
            {
                #if DESKTOP
                return client.UpdateEndpoint(request);
                #elif CORECLR
                return client.UpdateEndpointAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.EventBridge.Model.UpdateEndpointResponse, UpdateEVBEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
