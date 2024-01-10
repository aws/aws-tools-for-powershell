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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates the search configuration.
    /// 
    ///  
    /// <para>
    /// Requires permission to access the <a href="https://docs.aws.amazon.com/service-authorization/latest/reference/list_awsiot.html#awsiot-actions-as-permissions">UpdateIndexingConfiguration</a>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IOTIndexingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT UpdateIndexingConfiguration API operation.", Operation = new[] {"UpdateIndexingConfiguration"}, SelectReturnType = typeof(Amazon.IoT.Model.UpdateIndexingConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoT.Model.UpdateIndexingConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoT.Model.UpdateIndexingConfigurationResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTIndexingConfigurationCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ThingGroupIndexingConfiguration_CustomField
        /// <summary>
        /// <para>
        /// <para>A list of thing group fields to index. This list cannot contain any managed fields.
        /// Use the GetIndexingConfiguration API to get a list of managed fields.</para><para>Contains custom field names and their data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingGroupIndexingConfiguration_CustomFields")]
        public Amazon.IoT.Model.Field[] ThingGroupIndexingConfiguration_CustomField { get; set; }
        #endregion
        
        #region Parameter ThingIndexingConfiguration_CustomField
        /// <summary>
        /// <para>
        /// <para>Contains custom field names and their data type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingIndexingConfiguration_CustomFields")]
        public Amazon.IoT.Model.Field[] ThingIndexingConfiguration_CustomField { get; set; }
        #endregion
        
        #region Parameter ThingIndexingConfiguration_DeviceDefenderIndexingMode
        /// <summary>
        /// <para>
        /// <para>Device Defender indexing mode. Valid values are:</para><ul><li><para>VIOLATIONS – Your thing index contains Device Defender violations. To enable Device
        /// Defender indexing, <i>deviceDefenderIndexingMode</i> must not be set to OFF.</para></li><li><para>OFF - Device Defender indexing is disabled.</para></li></ul><para>For more information about Device Defender violations, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/device-defender-detect.html">Device
        /// Defender Detect.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.DeviceDefenderIndexingMode")]
        public Amazon.IoT.DeviceDefenderIndexingMode ThingIndexingConfiguration_DeviceDefenderIndexingMode { get; set; }
        #endregion
        
        #region Parameter Filter_GeoLocation
        /// <summary>
        /// <para>
        /// <para>The list of geolocation targets that you select to index. The default maximum number
        /// of geolocation targets for indexing is <c>1</c>. To increase the limit, see <a href="https://docs.aws.amazon.com/general/latest/gr/iot_device_management.html#fleet-indexing-limits">Amazon
        /// Web Services IoT Device Management Quotas</a> in the <i>Amazon Web Services General
        /// Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingIndexingConfiguration_Filter_GeoLocations")]
        public Amazon.IoT.Model.GeoLocationTarget[] Filter_GeoLocation { get; set; }
        #endregion
        
        #region Parameter ThingGroupIndexingConfiguration_ManagedField
        /// <summary>
        /// <para>
        /// <para>Contains fields that are indexed and whose types are already known by the Fleet Indexing
        /// service. This is an optional field. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/managing-fleet-index.html#managed-field">Managed
        /// fields</a> in the <i>Amazon Web Services IoT Core Developer Guide</i>.</para><note><para>You can't modify managed fields by updating fleet indexing configuration.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingGroupIndexingConfiguration_ManagedFields")]
        public Amazon.IoT.Model.Field[] ThingGroupIndexingConfiguration_ManagedField { get; set; }
        #endregion
        
        #region Parameter ThingIndexingConfiguration_ManagedField
        /// <summary>
        /// <para>
        /// <para>Contains fields that are indexed and whose types are already known by the Fleet Indexing
        /// service. This is an optional field. For more information, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/managing-fleet-index.html#managed-field">Managed
        /// fields</a> in the <i>Amazon Web Services IoT Core Developer Guide</i>.</para><note><para>You can't modify managed fields by updating fleet indexing configuration.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingIndexingConfiguration_ManagedFields")]
        public Amazon.IoT.Model.Field[] ThingIndexingConfiguration_ManagedField { get; set; }
        #endregion
        
        #region Parameter ThingIndexingConfiguration_NamedShadowIndexingMode
        /// <summary>
        /// <para>
        /// <para>Named shadow indexing mode. Valid values are:</para><ul><li><para>ON – Your thing index contains named shadow. To enable thing named shadow indexing,
        /// <i>namedShadowIndexingMode</i> must not be set to OFF.</para></li><li><para>OFF - Named shadow indexing is disabled.</para></li></ul><para>For more information about Shadows, see <a href="https://docs.aws.amazon.com/iot/latest/developerguide/iot-device-shadows.html">IoT
        /// Device Shadow service.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.NamedShadowIndexingMode")]
        public Amazon.IoT.NamedShadowIndexingMode ThingIndexingConfiguration_NamedShadowIndexingMode { get; set; }
        #endregion
        
        #region Parameter Filter_NamedShadowName
        /// <summary>
        /// <para>
        /// <para>The shadow names that you select to index. The default maximum number of shadow names
        /// for indexing is 10. To increase the limit, see <a href="https://docs.aws.amazon.com/general/latest/gr/iot_device_management.html#fleet-indexing-limits">Amazon
        /// Web Services IoT Device Management Quotas</a> in the <i>Amazon Web Services General
        /// Reference</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ThingIndexingConfiguration_Filter_NamedShadowNames")]
        public System.String[] Filter_NamedShadowName { get; set; }
        #endregion
        
        #region Parameter ThingIndexingConfiguration_ThingConnectivityIndexingMode
        /// <summary>
        /// <para>
        /// <para>Thing connectivity indexing mode. Valid values are: </para><ul><li><para>STATUS – Your thing index contains connectivity status. To enable thing connectivity
        /// indexing, <i>thingIndexMode</i> must not be set to OFF.</para></li><li><para>OFF - Thing connectivity status indexing is disabled.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.ThingConnectivityIndexingMode")]
        public Amazon.IoT.ThingConnectivityIndexingMode ThingIndexingConfiguration_ThingConnectivityIndexingMode { get; set; }
        #endregion
        
        #region Parameter ThingGroupIndexingConfiguration_ThingGroupIndexingMode
        /// <summary>
        /// <para>
        /// <para>Thing group indexing mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoT.ThingGroupIndexingMode")]
        public Amazon.IoT.ThingGroupIndexingMode ThingGroupIndexingConfiguration_ThingGroupIndexingMode { get; set; }
        #endregion
        
        #region Parameter ThingIndexingConfiguration_ThingIndexingMode
        /// <summary>
        /// <para>
        /// <para>Thing indexing mode. Valid values are:</para><ul><li><para>REGISTRY – Your thing index contains registry data only.</para></li><li><para>REGISTRY_AND_SHADOW - Your thing index contains registry and shadow data.</para></li><li><para>OFF - Thing indexing is disabled.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.IoT.ThingIndexingMode")]
        public Amazon.IoT.ThingIndexingMode ThingIndexingConfiguration_ThingIndexingMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoT.Model.UpdateIndexingConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ThingIndexingConfiguration_ThingIndexingMode parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ThingIndexingConfiguration_ThingIndexingMode' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ThingIndexingConfiguration_ThingIndexingMode' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThingIndexingConfiguration_ThingIndexingMode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTIndexingConfiguration (UpdateIndexingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoT.Model.UpdateIndexingConfigurationResponse, UpdateIOTIndexingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ThingIndexingConfiguration_ThingIndexingMode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ThingGroupIndexingConfiguration_CustomField != null)
            {
                context.ThingGroupIndexingConfiguration_CustomField = new List<Amazon.IoT.Model.Field>(this.ThingGroupIndexingConfiguration_CustomField);
            }
            if (this.ThingGroupIndexingConfiguration_ManagedField != null)
            {
                context.ThingGroupIndexingConfiguration_ManagedField = new List<Amazon.IoT.Model.Field>(this.ThingGroupIndexingConfiguration_ManagedField);
            }
            context.ThingGroupIndexingConfiguration_ThingGroupIndexingMode = this.ThingGroupIndexingConfiguration_ThingGroupIndexingMode;
            if (this.ThingIndexingConfiguration_CustomField != null)
            {
                context.ThingIndexingConfiguration_CustomField = new List<Amazon.IoT.Model.Field>(this.ThingIndexingConfiguration_CustomField);
            }
            context.ThingIndexingConfiguration_DeviceDefenderIndexingMode = this.ThingIndexingConfiguration_DeviceDefenderIndexingMode;
            if (this.Filter_GeoLocation != null)
            {
                context.Filter_GeoLocation = new List<Amazon.IoT.Model.GeoLocationTarget>(this.Filter_GeoLocation);
            }
            if (this.Filter_NamedShadowName != null)
            {
                context.Filter_NamedShadowName = new List<System.String>(this.Filter_NamedShadowName);
            }
            if (this.ThingIndexingConfiguration_ManagedField != null)
            {
                context.ThingIndexingConfiguration_ManagedField = new List<Amazon.IoT.Model.Field>(this.ThingIndexingConfiguration_ManagedField);
            }
            context.ThingIndexingConfiguration_NamedShadowIndexingMode = this.ThingIndexingConfiguration_NamedShadowIndexingMode;
            context.ThingIndexingConfiguration_ThingConnectivityIndexingMode = this.ThingIndexingConfiguration_ThingConnectivityIndexingMode;
            context.ThingIndexingConfiguration_ThingIndexingMode = this.ThingIndexingConfiguration_ThingIndexingMode;
            
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
            var request = new Amazon.IoT.Model.UpdateIndexingConfigurationRequest();
            
            
             // populate ThingGroupIndexingConfiguration
            var requestThingGroupIndexingConfigurationIsNull = true;
            request.ThingGroupIndexingConfiguration = new Amazon.IoT.Model.ThingGroupIndexingConfiguration();
            List<Amazon.IoT.Model.Field> requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_CustomField = null;
            if (cmdletContext.ThingGroupIndexingConfiguration_CustomField != null)
            {
                requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_CustomField = cmdletContext.ThingGroupIndexingConfiguration_CustomField;
            }
            if (requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_CustomField != null)
            {
                request.ThingGroupIndexingConfiguration.CustomFields = requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_CustomField;
                requestThingGroupIndexingConfigurationIsNull = false;
            }
            List<Amazon.IoT.Model.Field> requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ManagedField = null;
            if (cmdletContext.ThingGroupIndexingConfiguration_ManagedField != null)
            {
                requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ManagedField = cmdletContext.ThingGroupIndexingConfiguration_ManagedField;
            }
            if (requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ManagedField != null)
            {
                request.ThingGroupIndexingConfiguration.ManagedFields = requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ManagedField;
                requestThingGroupIndexingConfigurationIsNull = false;
            }
            Amazon.IoT.ThingGroupIndexingMode requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ThingGroupIndexingMode = null;
            if (cmdletContext.ThingGroupIndexingConfiguration_ThingGroupIndexingMode != null)
            {
                requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ThingGroupIndexingMode = cmdletContext.ThingGroupIndexingConfiguration_ThingGroupIndexingMode;
            }
            if (requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ThingGroupIndexingMode != null)
            {
                request.ThingGroupIndexingConfiguration.ThingGroupIndexingMode = requestThingGroupIndexingConfiguration_thingGroupIndexingConfiguration_ThingGroupIndexingMode;
                requestThingGroupIndexingConfigurationIsNull = false;
            }
             // determine if request.ThingGroupIndexingConfiguration should be set to null
            if (requestThingGroupIndexingConfigurationIsNull)
            {
                request.ThingGroupIndexingConfiguration = null;
            }
            
             // populate ThingIndexingConfiguration
            var requestThingIndexingConfigurationIsNull = true;
            request.ThingIndexingConfiguration = new Amazon.IoT.Model.ThingIndexingConfiguration();
            List<Amazon.IoT.Model.Field> requestThingIndexingConfiguration_thingIndexingConfiguration_CustomField = null;
            if (cmdletContext.ThingIndexingConfiguration_CustomField != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_CustomField = cmdletContext.ThingIndexingConfiguration_CustomField;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_CustomField != null)
            {
                request.ThingIndexingConfiguration.CustomFields = requestThingIndexingConfiguration_thingIndexingConfiguration_CustomField;
                requestThingIndexingConfigurationIsNull = false;
            }
            Amazon.IoT.DeviceDefenderIndexingMode requestThingIndexingConfiguration_thingIndexingConfiguration_DeviceDefenderIndexingMode = null;
            if (cmdletContext.ThingIndexingConfiguration_DeviceDefenderIndexingMode != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_DeviceDefenderIndexingMode = cmdletContext.ThingIndexingConfiguration_DeviceDefenderIndexingMode;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_DeviceDefenderIndexingMode != null)
            {
                request.ThingIndexingConfiguration.DeviceDefenderIndexingMode = requestThingIndexingConfiguration_thingIndexingConfiguration_DeviceDefenderIndexingMode;
                requestThingIndexingConfigurationIsNull = false;
            }
            List<Amazon.IoT.Model.Field> requestThingIndexingConfiguration_thingIndexingConfiguration_ManagedField = null;
            if (cmdletContext.ThingIndexingConfiguration_ManagedField != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_ManagedField = cmdletContext.ThingIndexingConfiguration_ManagedField;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_ManagedField != null)
            {
                request.ThingIndexingConfiguration.ManagedFields = requestThingIndexingConfiguration_thingIndexingConfiguration_ManagedField;
                requestThingIndexingConfigurationIsNull = false;
            }
            Amazon.IoT.NamedShadowIndexingMode requestThingIndexingConfiguration_thingIndexingConfiguration_NamedShadowIndexingMode = null;
            if (cmdletContext.ThingIndexingConfiguration_NamedShadowIndexingMode != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_NamedShadowIndexingMode = cmdletContext.ThingIndexingConfiguration_NamedShadowIndexingMode;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_NamedShadowIndexingMode != null)
            {
                request.ThingIndexingConfiguration.NamedShadowIndexingMode = requestThingIndexingConfiguration_thingIndexingConfiguration_NamedShadowIndexingMode;
                requestThingIndexingConfigurationIsNull = false;
            }
            Amazon.IoT.ThingConnectivityIndexingMode requestThingIndexingConfiguration_thingIndexingConfiguration_ThingConnectivityIndexingMode = null;
            if (cmdletContext.ThingIndexingConfiguration_ThingConnectivityIndexingMode != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_ThingConnectivityIndexingMode = cmdletContext.ThingIndexingConfiguration_ThingConnectivityIndexingMode;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_ThingConnectivityIndexingMode != null)
            {
                request.ThingIndexingConfiguration.ThingConnectivityIndexingMode = requestThingIndexingConfiguration_thingIndexingConfiguration_ThingConnectivityIndexingMode;
                requestThingIndexingConfigurationIsNull = false;
            }
            Amazon.IoT.ThingIndexingMode requestThingIndexingConfiguration_thingIndexingConfiguration_ThingIndexingMode = null;
            if (cmdletContext.ThingIndexingConfiguration_ThingIndexingMode != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_ThingIndexingMode = cmdletContext.ThingIndexingConfiguration_ThingIndexingMode;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_ThingIndexingMode != null)
            {
                request.ThingIndexingConfiguration.ThingIndexingMode = requestThingIndexingConfiguration_thingIndexingConfiguration_ThingIndexingMode;
                requestThingIndexingConfigurationIsNull = false;
            }
            Amazon.IoT.Model.IndexingFilter requestThingIndexingConfiguration_thingIndexingConfiguration_Filter = null;
            
             // populate Filter
            var requestThingIndexingConfiguration_thingIndexingConfiguration_FilterIsNull = true;
            requestThingIndexingConfiguration_thingIndexingConfiguration_Filter = new Amazon.IoT.Model.IndexingFilter();
            List<Amazon.IoT.Model.GeoLocationTarget> requestThingIndexingConfiguration_thingIndexingConfiguration_Filter_filter_GeoLocation = null;
            if (cmdletContext.Filter_GeoLocation != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_Filter_filter_GeoLocation = cmdletContext.Filter_GeoLocation;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_Filter_filter_GeoLocation != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_Filter.GeoLocations = requestThingIndexingConfiguration_thingIndexingConfiguration_Filter_filter_GeoLocation;
                requestThingIndexingConfiguration_thingIndexingConfiguration_FilterIsNull = false;
            }
            List<System.String> requestThingIndexingConfiguration_thingIndexingConfiguration_Filter_filter_NamedShadowName = null;
            if (cmdletContext.Filter_NamedShadowName != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_Filter_filter_NamedShadowName = cmdletContext.Filter_NamedShadowName;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_Filter_filter_NamedShadowName != null)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_Filter.NamedShadowNames = requestThingIndexingConfiguration_thingIndexingConfiguration_Filter_filter_NamedShadowName;
                requestThingIndexingConfiguration_thingIndexingConfiguration_FilterIsNull = false;
            }
             // determine if requestThingIndexingConfiguration_thingIndexingConfiguration_Filter should be set to null
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_FilterIsNull)
            {
                requestThingIndexingConfiguration_thingIndexingConfiguration_Filter = null;
            }
            if (requestThingIndexingConfiguration_thingIndexingConfiguration_Filter != null)
            {
                request.ThingIndexingConfiguration.Filter = requestThingIndexingConfiguration_thingIndexingConfiguration_Filter;
                requestThingIndexingConfigurationIsNull = false;
            }
             // determine if request.ThingIndexingConfiguration should be set to null
            if (requestThingIndexingConfigurationIsNull)
            {
                request.ThingIndexingConfiguration = null;
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
        
        private Amazon.IoT.Model.UpdateIndexingConfigurationResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateIndexingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateIndexingConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateIndexingConfiguration(request);
                #elif CORECLR
                return client.UpdateIndexingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IoT.Model.Field> ThingGroupIndexingConfiguration_CustomField { get; set; }
            public List<Amazon.IoT.Model.Field> ThingGroupIndexingConfiguration_ManagedField { get; set; }
            public Amazon.IoT.ThingGroupIndexingMode ThingGroupIndexingConfiguration_ThingGroupIndexingMode { get; set; }
            public List<Amazon.IoT.Model.Field> ThingIndexingConfiguration_CustomField { get; set; }
            public Amazon.IoT.DeviceDefenderIndexingMode ThingIndexingConfiguration_DeviceDefenderIndexingMode { get; set; }
            public List<Amazon.IoT.Model.GeoLocationTarget> Filter_GeoLocation { get; set; }
            public List<System.String> Filter_NamedShadowName { get; set; }
            public List<Amazon.IoT.Model.Field> ThingIndexingConfiguration_ManagedField { get; set; }
            public Amazon.IoT.NamedShadowIndexingMode ThingIndexingConfiguration_NamedShadowIndexingMode { get; set; }
            public Amazon.IoT.ThingConnectivityIndexingMode ThingIndexingConfiguration_ThingConnectivityIndexingMode { get; set; }
            public Amazon.IoT.ThingIndexingMode ThingIndexingConfiguration_ThingIndexingMode { get; set; }
            public System.Func<Amazon.IoT.Model.UpdateIndexingConfigurationResponse, UpdateIOTIndexingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
