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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Update the event configuration for a particular resource identifier.
    /// </summary>
    [Cmdlet("Update", "IOTWResourceEventConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdateResourceEventConfiguration API operation.", Operation = new[] {"UpdateResourceEventConfiguration"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdateResourceEventConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdateResourceEventConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdateResourceEventConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTWResourceEventConfigurationCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        #region Parameter Sidewalk_DeviceRegistrationState_AmazonIdEventTopic
        /// <summary>
        /// <para>
        /// <para>Enum to denote whether amazon id event topic is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeviceRegistrationState_AmazonIdEventTopic","DeviceRegistrationState_Sidewalk_AmazonIdEventTopic")]
        [AWSConstantClassSource("Amazon.IoTWireless.EventNotificationTopicStatus")]
        public Amazon.IoTWireless.EventNotificationTopicStatus Sidewalk_DeviceRegistrationState_AmazonIdEventTopic { get; set; }
        #endregion
        
        #region Parameter Sidewalk_AmazonIdEventTopic
        /// <summary>
        /// <para>
        /// <para>Enum to denote whether amazon id event topic is enabled or disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Proximity_Sidewalk_AmazonIdEventTopic")]
        [AWSConstantClassSource("Amazon.IoTWireless.EventNotificationTopicStatus")]
        public Amazon.IoTWireless.EventNotificationTopicStatus Sidewalk_AmazonIdEventTopic { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>Resource identifier to opt in for event messaging.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter IdentifierType
        /// <summary>
        /// <para>
        /// <para>Identifier type of the particular resource identifier for event configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTWireless.IdentifierType")]
        public Amazon.IoTWireless.IdentifierType IdentifierType { get; set; }
        #endregion
        
        #region Parameter PartnerType
        /// <summary>
        /// <para>
        /// <para>Partner type of the resource if the identifier type is PartnerAccountId</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.EventNotificationPartnerType")]
        public Amazon.IoTWireless.EventNotificationPartnerType PartnerType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdateResourceEventConfigurationResponse).
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWResourceEventConfiguration (UpdateResourceEventConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdateResourceEventConfigurationResponse, UpdateIOTWResourceEventConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Sidewalk_DeviceRegistrationState_AmazonIdEventTopic = this.Sidewalk_DeviceRegistrationState_AmazonIdEventTopic;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IdentifierType = this.IdentifierType;
            #if MODULAR
            if (this.IdentifierType == null && ParameterWasBound(nameof(this.IdentifierType)))
            {
                WriteWarning("You are passing $null as a value for parameter IdentifierType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartnerType = this.PartnerType;
            context.Sidewalk_AmazonIdEventTopic = this.Sidewalk_AmazonIdEventTopic;
            
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
            var request = new Amazon.IoTWireless.Model.UpdateResourceEventConfigurationRequest();
            
            
             // populate DeviceRegistrationState
            var requestDeviceRegistrationStateIsNull = true;
            request.DeviceRegistrationState = new Amazon.IoTWireless.Model.DeviceRegistrationStateEventConfiguration();
            Amazon.IoTWireless.Model.SidewalkEventNotificationConfigurations requestDeviceRegistrationState_deviceRegistrationState_Sidewalk = null;
            
             // populate Sidewalk
            var requestDeviceRegistrationState_deviceRegistrationState_SidewalkIsNull = true;
            requestDeviceRegistrationState_deviceRegistrationState_Sidewalk = new Amazon.IoTWireless.Model.SidewalkEventNotificationConfigurations();
            Amazon.IoTWireless.EventNotificationTopicStatus requestDeviceRegistrationState_deviceRegistrationState_Sidewalk_sidewalk_DeviceRegistrationState_AmazonIdEventTopic = null;
            if (cmdletContext.Sidewalk_DeviceRegistrationState_AmazonIdEventTopic != null)
            {
                requestDeviceRegistrationState_deviceRegistrationState_Sidewalk_sidewalk_DeviceRegistrationState_AmazonIdEventTopic = cmdletContext.Sidewalk_DeviceRegistrationState_AmazonIdEventTopic;
            }
            if (requestDeviceRegistrationState_deviceRegistrationState_Sidewalk_sidewalk_DeviceRegistrationState_AmazonIdEventTopic != null)
            {
                requestDeviceRegistrationState_deviceRegistrationState_Sidewalk.AmazonIdEventTopic = requestDeviceRegistrationState_deviceRegistrationState_Sidewalk_sidewalk_DeviceRegistrationState_AmazonIdEventTopic;
                requestDeviceRegistrationState_deviceRegistrationState_SidewalkIsNull = false;
            }
             // determine if requestDeviceRegistrationState_deviceRegistrationState_Sidewalk should be set to null
            if (requestDeviceRegistrationState_deviceRegistrationState_SidewalkIsNull)
            {
                requestDeviceRegistrationState_deviceRegistrationState_Sidewalk = null;
            }
            if (requestDeviceRegistrationState_deviceRegistrationState_Sidewalk != null)
            {
                request.DeviceRegistrationState.Sidewalk = requestDeviceRegistrationState_deviceRegistrationState_Sidewalk;
                requestDeviceRegistrationStateIsNull = false;
            }
             // determine if request.DeviceRegistrationState should be set to null
            if (requestDeviceRegistrationStateIsNull)
            {
                request.DeviceRegistrationState = null;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.IdentifierType != null)
            {
                request.IdentifierType = cmdletContext.IdentifierType;
            }
            if (cmdletContext.PartnerType != null)
            {
                request.PartnerType = cmdletContext.PartnerType;
            }
            
             // populate Proximity
            var requestProximityIsNull = true;
            request.Proximity = new Amazon.IoTWireless.Model.ProximityEventConfiguration();
            Amazon.IoTWireless.Model.SidewalkEventNotificationConfigurations requestProximity_proximity_Sidewalk = null;
            
             // populate Sidewalk
            var requestProximity_proximity_SidewalkIsNull = true;
            requestProximity_proximity_Sidewalk = new Amazon.IoTWireless.Model.SidewalkEventNotificationConfigurations();
            Amazon.IoTWireless.EventNotificationTopicStatus requestProximity_proximity_Sidewalk_sidewalk_AmazonIdEventTopic = null;
            if (cmdletContext.Sidewalk_AmazonIdEventTopic != null)
            {
                requestProximity_proximity_Sidewalk_sidewalk_AmazonIdEventTopic = cmdletContext.Sidewalk_AmazonIdEventTopic;
            }
            if (requestProximity_proximity_Sidewalk_sidewalk_AmazonIdEventTopic != null)
            {
                requestProximity_proximity_Sidewalk.AmazonIdEventTopic = requestProximity_proximity_Sidewalk_sidewalk_AmazonIdEventTopic;
                requestProximity_proximity_SidewalkIsNull = false;
            }
             // determine if requestProximity_proximity_Sidewalk should be set to null
            if (requestProximity_proximity_SidewalkIsNull)
            {
                requestProximity_proximity_Sidewalk = null;
            }
            if (requestProximity_proximity_Sidewalk != null)
            {
                request.Proximity.Sidewalk = requestProximity_proximity_Sidewalk;
                requestProximityIsNull = false;
            }
             // determine if request.Proximity should be set to null
            if (requestProximityIsNull)
            {
                request.Proximity = null;
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
        
        private Amazon.IoTWireless.Model.UpdateResourceEventConfigurationResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdateResourceEventConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdateResourceEventConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateResourceEventConfiguration(request);
                #elif CORECLR
                return client.UpdateResourceEventConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoTWireless.EventNotificationTopicStatus Sidewalk_DeviceRegistrationState_AmazonIdEventTopic { get; set; }
            public System.String Identifier { get; set; }
            public Amazon.IoTWireless.IdentifierType IdentifierType { get; set; }
            public Amazon.IoTWireless.EventNotificationPartnerType PartnerType { get; set; }
            public Amazon.IoTWireless.EventNotificationTopicStatus Sidewalk_AmazonIdEventTopic { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdateResourceEventConfigurationResponse, UpdateIOTWResourceEventConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
