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
    /// Updates the <code>Config</code> used when scheduling contacts.
    /// 
    ///  
    /// <para>
    /// Updating a <code>Config</code> will not update the execution parameters for existing
    /// future contacts scheduled with this <code>Config</code>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GSConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GroundStation.Model.UpdateConfigResponse")]
    [AWSCmdlet("Calls the AWS Ground Station UpdateConfig API operation.", Operation = new[] {"UpdateConfig"}, SelectReturnType = typeof(Amazon.GroundStation.Model.UpdateConfigResponse))]
    [AWSCmdletOutput("Amazon.GroundStation.Model.UpdateConfigResponse",
        "This cmdlet returns an Amazon.GroundStation.Model.UpdateConfigResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGSConfigCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        #region Parameter ConfigData_AntennaDownlinkConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should configure an antenna for downlink
        /// during a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaDownlinkConfig ConfigData_AntennaDownlinkConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_AntennaDownlinkDemodDecodeConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should conﬁgure an antenna for downlink demod
        /// decode during a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig ConfigData_AntennaDownlinkDemodDecodeConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_AntennaUplinkConfig
        /// <summary>
        /// <para>
        /// <para>Information about how AWS Ground Station should conﬁgure an antenna for uplink during
        /// a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.AntennaUplinkConfig ConfigData_AntennaUplinkConfig { get; set; }
        #endregion
        
        #region Parameter ConfigId
        /// <summary>
        /// <para>
        /// <para>UUID of a <code>Config</code>.</para>
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
        public System.String ConfigId { get; set; }
        #endregion
        
        #region Parameter ConfigType
        /// <summary>
        /// <para>
        /// <para>Type of a <code>Config</code>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GroundStation.ConfigCapabilityType")]
        public Amazon.GroundStation.ConfigCapabilityType ConfigType { get; set; }
        #endregion
        
        #region Parameter ConfigData_DataflowEndpointConfig
        /// <summary>
        /// <para>
        /// <para>Information about the dataflow endpoint <code>Config</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.DataflowEndpointConfig ConfigData_DataflowEndpointConfig { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name of a <code>Config</code>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ConfigData_TrackingConfig
        /// <summary>
        /// <para>
        /// <para>Object that determines whether tracking should be used during a contact executed with
        /// this <code>Config</code> in the mission profile. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.TrackingConfig ConfigData_TrackingConfig { get; set; }
        #endregion
        
        #region Parameter ConfigData_UplinkEchoConfig
        /// <summary>
        /// <para>
        /// <para>Information about an uplink echo <code>Config</code>.</para><para>Parameters from the <code>AntennaUplinkConfig</code>, corresponding to the specified
        /// <code>AntennaUplinkConfigArn</code>, are used when this <code>UplinkEchoConfig</code>
        /// is used in a contact.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.GroundStation.Model.UplinkEchoConfig ConfigData_UplinkEchoConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.UpdateConfigResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.UpdateConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GSConfig (UpdateConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.UpdateConfigResponse, UpdateGSConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConfigData_AntennaDownlinkConfig = this.ConfigData_AntennaDownlinkConfig;
            context.ConfigData_AntennaDownlinkDemodDecodeConfig = this.ConfigData_AntennaDownlinkDemodDecodeConfig;
            context.ConfigData_AntennaUplinkConfig = this.ConfigData_AntennaUplinkConfig;
            context.ConfigData_DataflowEndpointConfig = this.ConfigData_DataflowEndpointConfig;
            context.ConfigData_TrackingConfig = this.ConfigData_TrackingConfig;
            context.ConfigData_UplinkEchoConfig = this.ConfigData_UplinkEchoConfig;
            context.ConfigId = this.ConfigId;
            #if MODULAR
            if (this.ConfigId == null && ParameterWasBound(nameof(this.ConfigId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigType = this.ConfigType;
            #if MODULAR
            if (this.ConfigType == null && ParameterWasBound(nameof(this.ConfigType)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GroundStation.Model.UpdateConfigRequest();
            
            
             // populate ConfigData
            var requestConfigDataIsNull = true;
            request.ConfigData = new Amazon.GroundStation.Model.ConfigTypeData();
            Amazon.GroundStation.Model.AntennaDownlinkConfig requestConfigData_configData_AntennaDownlinkConfig = null;
            if (cmdletContext.ConfigData_AntennaDownlinkConfig != null)
            {
                requestConfigData_configData_AntennaDownlinkConfig = cmdletContext.ConfigData_AntennaDownlinkConfig;
            }
            if (requestConfigData_configData_AntennaDownlinkConfig != null)
            {
                request.ConfigData.AntennaDownlinkConfig = requestConfigData_configData_AntennaDownlinkConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig requestConfigData_configData_AntennaDownlinkDemodDecodeConfig = null;
            if (cmdletContext.ConfigData_AntennaDownlinkDemodDecodeConfig != null)
            {
                requestConfigData_configData_AntennaDownlinkDemodDecodeConfig = cmdletContext.ConfigData_AntennaDownlinkDemodDecodeConfig;
            }
            if (requestConfigData_configData_AntennaDownlinkDemodDecodeConfig != null)
            {
                request.ConfigData.AntennaDownlinkDemodDecodeConfig = requestConfigData_configData_AntennaDownlinkDemodDecodeConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.AntennaUplinkConfig requestConfigData_configData_AntennaUplinkConfig = null;
            if (cmdletContext.ConfigData_AntennaUplinkConfig != null)
            {
                requestConfigData_configData_AntennaUplinkConfig = cmdletContext.ConfigData_AntennaUplinkConfig;
            }
            if (requestConfigData_configData_AntennaUplinkConfig != null)
            {
                request.ConfigData.AntennaUplinkConfig = requestConfigData_configData_AntennaUplinkConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.DataflowEndpointConfig requestConfigData_configData_DataflowEndpointConfig = null;
            if (cmdletContext.ConfigData_DataflowEndpointConfig != null)
            {
                requestConfigData_configData_DataflowEndpointConfig = cmdletContext.ConfigData_DataflowEndpointConfig;
            }
            if (requestConfigData_configData_DataflowEndpointConfig != null)
            {
                request.ConfigData.DataflowEndpointConfig = requestConfigData_configData_DataflowEndpointConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.TrackingConfig requestConfigData_configData_TrackingConfig = null;
            if (cmdletContext.ConfigData_TrackingConfig != null)
            {
                requestConfigData_configData_TrackingConfig = cmdletContext.ConfigData_TrackingConfig;
            }
            if (requestConfigData_configData_TrackingConfig != null)
            {
                request.ConfigData.TrackingConfig = requestConfigData_configData_TrackingConfig;
                requestConfigDataIsNull = false;
            }
            Amazon.GroundStation.Model.UplinkEchoConfig requestConfigData_configData_UplinkEchoConfig = null;
            if (cmdletContext.ConfigData_UplinkEchoConfig != null)
            {
                requestConfigData_configData_UplinkEchoConfig = cmdletContext.ConfigData_UplinkEchoConfig;
            }
            if (requestConfigData_configData_UplinkEchoConfig != null)
            {
                request.ConfigData.UplinkEchoConfig = requestConfigData_configData_UplinkEchoConfig;
                requestConfigDataIsNull = false;
            }
             // determine if request.ConfigData should be set to null
            if (requestConfigDataIsNull)
            {
                request.ConfigData = null;
            }
            if (cmdletContext.ConfigId != null)
            {
                request.ConfigId = cmdletContext.ConfigId;
            }
            if (cmdletContext.ConfigType != null)
            {
                request.ConfigType = cmdletContext.ConfigType;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.GroundStation.Model.UpdateConfigResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.UpdateConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "UpdateConfig");
            try
            {
                #if DESKTOP
                return client.UpdateConfig(request);
                #elif CORECLR
                return client.UpdateConfigAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GroundStation.Model.AntennaDownlinkConfig ConfigData_AntennaDownlinkConfig { get; set; }
            public Amazon.GroundStation.Model.AntennaDownlinkDemodDecodeConfig ConfigData_AntennaDownlinkDemodDecodeConfig { get; set; }
            public Amazon.GroundStation.Model.AntennaUplinkConfig ConfigData_AntennaUplinkConfig { get; set; }
            public Amazon.GroundStation.Model.DataflowEndpointConfig ConfigData_DataflowEndpointConfig { get; set; }
            public Amazon.GroundStation.Model.TrackingConfig ConfigData_TrackingConfig { get; set; }
            public Amazon.GroundStation.Model.UplinkEchoConfig ConfigData_UplinkEchoConfig { get; set; }
            public System.String ConfigId { get; set; }
            public Amazon.GroundStation.ConfigCapabilityType ConfigType { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.GroundStation.Model.UpdateConfigResponse, UpdateGSConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
