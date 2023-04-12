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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// <note><para>
    ///  For use by AWS Ground Station Agent and shouldn't be called directly.
    /// </para></note><para>
    ///  Registers a new agent with AWS Ground Station. 
    /// </para>
    /// </summary>
    [Cmdlet("Register", "GSAgent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Ground Station RegisterAgent API operation.", Operation = new[] {"RegisterAgent"}, SelectReturnType = typeof(Amazon.GroundStation.Model.RegisterAgentResponse))]
    [AWSCmdletOutput("System.String or Amazon.GroundStation.Model.RegisterAgentResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GroundStation.Model.RegisterAgentResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterGSAgentCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        #region Parameter AgentDetails_AgentCpuCore
        /// <summary>
        /// <para>
        /// <para>List of CPU cores reserved for the agent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentDetails_AgentCpuCores")]
        public System.Int32[] AgentDetails_AgentCpuCore { get; set; }
        #endregion
        
        #region Parameter AgentDetails_AgentVersion
        /// <summary>
        /// <para>
        /// <para>Current agent version.</para>
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
        public System.String AgentDetails_AgentVersion { get; set; }
        #endregion
        
        #region Parameter DiscoveryData_CapabilityArn
        /// <summary>
        /// <para>
        /// <para>List of capabilities to associate with agent.</para>
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
        [Alias("DiscoveryData_CapabilityArns")]
        public System.String[] DiscoveryData_CapabilityArn { get; set; }
        #endregion
        
        #region Parameter AgentDetails_ComponentVersion
        /// <summary>
        /// <para>
        /// <para>List of versions being used by agent components.</para>
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
        [Alias("AgentDetails_ComponentVersions")]
        public Amazon.GroundStation.Model.ComponentVersion[] AgentDetails_ComponentVersion { get; set; }
        #endregion
        
        #region Parameter AgentDetails_InstanceId
        /// <summary>
        /// <para>
        /// <para>ID of EC2 instance agent is running on.</para>
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
        public System.String AgentDetails_InstanceId { get; set; }
        #endregion
        
        #region Parameter AgentDetails_InstanceType
        /// <summary>
        /// <para>
        /// <para>Type of EC2 instance agent is running on.</para>
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
        public System.String AgentDetails_InstanceType { get; set; }
        #endregion
        
        #region Parameter DiscoveryData_PrivateIpAddress
        /// <summary>
        /// <para>
        /// <para>List of private IP addresses to associate with agent.</para>
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
        [Alias("DiscoveryData_PrivateIpAddresses")]
        public System.String[] DiscoveryData_PrivateIpAddress { get; set; }
        #endregion
        
        #region Parameter DiscoveryData_PublicIpAddress
        /// <summary>
        /// <para>
        /// <para>List of public IP addresses to associate with agent.</para>
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
        [Alias("DiscoveryData_PublicIpAddresses")]
        public System.String[] DiscoveryData_PublicIpAddress { get; set; }
        #endregion
        
        #region Parameter AgentDetails_ReservedCpuCore
        /// <summary>
        /// <para>
        /// <note><para>This field should not be used. Use agentCpuCores instead.</para></note><para>List of CPU cores reserved for processes other than the agent running on the EC2 instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentDetails_ReservedCpuCores")]
        public System.Int32[] AgentDetails_ReservedCpuCore { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AgentId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.RegisterAgentResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.RegisterAgentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AgentId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentDetails_InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-GSAgent (RegisterAgent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.RegisterAgentResponse, RegisterGSAgentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AgentDetails_AgentCpuCore != null)
            {
                context.AgentDetails_AgentCpuCore = new List<System.Int32>(this.AgentDetails_AgentCpuCore);
            }
            context.AgentDetails_AgentVersion = this.AgentDetails_AgentVersion;
            #if MODULAR
            if (this.AgentDetails_AgentVersion == null && ParameterWasBound(nameof(this.AgentDetails_AgentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentDetails_AgentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AgentDetails_ComponentVersion != null)
            {
                context.AgentDetails_ComponentVersion = new List<Amazon.GroundStation.Model.ComponentVersion>(this.AgentDetails_ComponentVersion);
            }
            #if MODULAR
            if (this.AgentDetails_ComponentVersion == null && ParameterWasBound(nameof(this.AgentDetails_ComponentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentDetails_ComponentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentDetails_InstanceId = this.AgentDetails_InstanceId;
            #if MODULAR
            if (this.AgentDetails_InstanceId == null && ParameterWasBound(nameof(this.AgentDetails_InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentDetails_InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AgentDetails_InstanceType = this.AgentDetails_InstanceType;
            #if MODULAR
            if (this.AgentDetails_InstanceType == null && ParameterWasBound(nameof(this.AgentDetails_InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentDetails_InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AgentDetails_ReservedCpuCore != null)
            {
                context.AgentDetails_ReservedCpuCore = new List<System.Int32>(this.AgentDetails_ReservedCpuCore);
            }
            if (this.DiscoveryData_CapabilityArn != null)
            {
                context.DiscoveryData_CapabilityArn = new List<System.String>(this.DiscoveryData_CapabilityArn);
            }
            #if MODULAR
            if (this.DiscoveryData_CapabilityArn == null && ParameterWasBound(nameof(this.DiscoveryData_CapabilityArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DiscoveryData_CapabilityArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DiscoveryData_PrivateIpAddress != null)
            {
                context.DiscoveryData_PrivateIpAddress = new List<System.String>(this.DiscoveryData_PrivateIpAddress);
            }
            #if MODULAR
            if (this.DiscoveryData_PrivateIpAddress == null && ParameterWasBound(nameof(this.DiscoveryData_PrivateIpAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter DiscoveryData_PrivateIpAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DiscoveryData_PublicIpAddress != null)
            {
                context.DiscoveryData_PublicIpAddress = new List<System.String>(this.DiscoveryData_PublicIpAddress);
            }
            #if MODULAR
            if (this.DiscoveryData_PublicIpAddress == null && ParameterWasBound(nameof(this.DiscoveryData_PublicIpAddress)))
            {
                WriteWarning("You are passing $null as a value for parameter DiscoveryData_PublicIpAddress which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GroundStation.Model.RegisterAgentRequest();
            
            
             // populate AgentDetails
            var requestAgentDetailsIsNull = true;
            request.AgentDetails = new Amazon.GroundStation.Model.AgentDetails();
            List<System.Int32> requestAgentDetails_agentDetails_AgentCpuCore = null;
            if (cmdletContext.AgentDetails_AgentCpuCore != null)
            {
                requestAgentDetails_agentDetails_AgentCpuCore = cmdletContext.AgentDetails_AgentCpuCore;
            }
            if (requestAgentDetails_agentDetails_AgentCpuCore != null)
            {
                request.AgentDetails.AgentCpuCores = requestAgentDetails_agentDetails_AgentCpuCore;
                requestAgentDetailsIsNull = false;
            }
            System.String requestAgentDetails_agentDetails_AgentVersion = null;
            if (cmdletContext.AgentDetails_AgentVersion != null)
            {
                requestAgentDetails_agentDetails_AgentVersion = cmdletContext.AgentDetails_AgentVersion;
            }
            if (requestAgentDetails_agentDetails_AgentVersion != null)
            {
                request.AgentDetails.AgentVersion = requestAgentDetails_agentDetails_AgentVersion;
                requestAgentDetailsIsNull = false;
            }
            List<Amazon.GroundStation.Model.ComponentVersion> requestAgentDetails_agentDetails_ComponentVersion = null;
            if (cmdletContext.AgentDetails_ComponentVersion != null)
            {
                requestAgentDetails_agentDetails_ComponentVersion = cmdletContext.AgentDetails_ComponentVersion;
            }
            if (requestAgentDetails_agentDetails_ComponentVersion != null)
            {
                request.AgentDetails.ComponentVersions = requestAgentDetails_agentDetails_ComponentVersion;
                requestAgentDetailsIsNull = false;
            }
            System.String requestAgentDetails_agentDetails_InstanceId = null;
            if (cmdletContext.AgentDetails_InstanceId != null)
            {
                requestAgentDetails_agentDetails_InstanceId = cmdletContext.AgentDetails_InstanceId;
            }
            if (requestAgentDetails_agentDetails_InstanceId != null)
            {
                request.AgentDetails.InstanceId = requestAgentDetails_agentDetails_InstanceId;
                requestAgentDetailsIsNull = false;
            }
            System.String requestAgentDetails_agentDetails_InstanceType = null;
            if (cmdletContext.AgentDetails_InstanceType != null)
            {
                requestAgentDetails_agentDetails_InstanceType = cmdletContext.AgentDetails_InstanceType;
            }
            if (requestAgentDetails_agentDetails_InstanceType != null)
            {
                request.AgentDetails.InstanceType = requestAgentDetails_agentDetails_InstanceType;
                requestAgentDetailsIsNull = false;
            }
            List<System.Int32> requestAgentDetails_agentDetails_ReservedCpuCore = null;
            if (cmdletContext.AgentDetails_ReservedCpuCore != null)
            {
                requestAgentDetails_agentDetails_ReservedCpuCore = cmdletContext.AgentDetails_ReservedCpuCore;
            }
            if (requestAgentDetails_agentDetails_ReservedCpuCore != null)
            {
                request.AgentDetails.ReservedCpuCores = requestAgentDetails_agentDetails_ReservedCpuCore;
                requestAgentDetailsIsNull = false;
            }
             // determine if request.AgentDetails should be set to null
            if (requestAgentDetailsIsNull)
            {
                request.AgentDetails = null;
            }
            
             // populate DiscoveryData
            var requestDiscoveryDataIsNull = true;
            request.DiscoveryData = new Amazon.GroundStation.Model.DiscoveryData();
            List<System.String> requestDiscoveryData_discoveryData_CapabilityArn = null;
            if (cmdletContext.DiscoveryData_CapabilityArn != null)
            {
                requestDiscoveryData_discoveryData_CapabilityArn = cmdletContext.DiscoveryData_CapabilityArn;
            }
            if (requestDiscoveryData_discoveryData_CapabilityArn != null)
            {
                request.DiscoveryData.CapabilityArns = requestDiscoveryData_discoveryData_CapabilityArn;
                requestDiscoveryDataIsNull = false;
            }
            List<System.String> requestDiscoveryData_discoveryData_PrivateIpAddress = null;
            if (cmdletContext.DiscoveryData_PrivateIpAddress != null)
            {
                requestDiscoveryData_discoveryData_PrivateIpAddress = cmdletContext.DiscoveryData_PrivateIpAddress;
            }
            if (requestDiscoveryData_discoveryData_PrivateIpAddress != null)
            {
                request.DiscoveryData.PrivateIpAddresses = requestDiscoveryData_discoveryData_PrivateIpAddress;
                requestDiscoveryDataIsNull = false;
            }
            List<System.String> requestDiscoveryData_discoveryData_PublicIpAddress = null;
            if (cmdletContext.DiscoveryData_PublicIpAddress != null)
            {
                requestDiscoveryData_discoveryData_PublicIpAddress = cmdletContext.DiscoveryData_PublicIpAddress;
            }
            if (requestDiscoveryData_discoveryData_PublicIpAddress != null)
            {
                request.DiscoveryData.PublicIpAddresses = requestDiscoveryData_discoveryData_PublicIpAddress;
                requestDiscoveryDataIsNull = false;
            }
             // determine if request.DiscoveryData should be set to null
            if (requestDiscoveryDataIsNull)
            {
                request.DiscoveryData = null;
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
        
        private Amazon.GroundStation.Model.RegisterAgentResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.RegisterAgentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "RegisterAgent");
            try
            {
                #if DESKTOP
                return client.RegisterAgent(request);
                #elif CORECLR
                return client.RegisterAgentAsync(request).GetAwaiter().GetResult();
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
            public List<System.Int32> AgentDetails_AgentCpuCore { get; set; }
            public System.String AgentDetails_AgentVersion { get; set; }
            public List<Amazon.GroundStation.Model.ComponentVersion> AgentDetails_ComponentVersion { get; set; }
            public System.String AgentDetails_InstanceId { get; set; }
            public System.String AgentDetails_InstanceType { get; set; }
            public List<System.Int32> AgentDetails_ReservedCpuCore { get; set; }
            public List<System.String> DiscoveryData_CapabilityArn { get; set; }
            public List<System.String> DiscoveryData_PrivateIpAddress { get; set; }
            public List<System.String> DiscoveryData_PublicIpAddress { get; set; }
            public System.Func<Amazon.GroundStation.Model.RegisterAgentResponse, RegisterGSAgentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgentId;
        }
        
    }
}
