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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Creates a gateway, which is a virtual or edge device that delivers industrial data
    /// streams from local servers to IoT SiteWise. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/gateway-connector.html">Ingesting
    /// data using a gateway</a> in the <i>IoT SiteWise User Guide</i>.
    /// </summary>
    [Cmdlet("New", "IOTSWGateway", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreateGatewayResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreateGateway API operation.", Operation = new[] {"CreateGateway"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreateGatewayResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreateGatewayResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateGatewayResponse object containing multiple properties."
    )]
    public partial class NewIOTSWGatewayCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GreengrassV2_CoreDeviceOperatingSystem
        /// <summary>
        /// <para>
        /// <para>The operating system of the core device in IoT Greengrass V2. Specifying the operating
        /// system is required for MQTT-enabled, V3 gateways (<c>gatewayVersion</c><c>3</c>)
        /// and not applicable for Classic stream, V2 gateways (<c>gatewayVersion</c><c>2</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatewayPlatform_GreengrassV2_CoreDeviceOperatingSystem")]
        [AWSConstantClassSource("Amazon.IoTSiteWise.CoreDeviceOperatingSystem")]
        public Amazon.IoTSiteWise.CoreDeviceOperatingSystem GreengrassV2_CoreDeviceOperatingSystem { get; set; }
        #endregion
        
        #region Parameter GreengrassV2_CoreDeviceThingName
        /// <summary>
        /// <para>
        /// <para>The name of the IoT thing for your IoT Greengrass V2 core device.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatewayPlatform_GreengrassV2_CoreDeviceThingName")]
        public System.String GreengrassV2_CoreDeviceThingName { get; set; }
        #endregion
        
        #region Parameter GatewayName
        /// <summary>
        /// <para>
        /// <para>A unique name for the gateway.</para>
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
        public System.String GatewayName { get; set; }
        #endregion
        
        #region Parameter GatewayVersion
        /// <summary>
        /// <para>
        /// <para>The version of the gateway to create. Specify <c>3</c> to create an MQTT-enabled,
        /// V3 gateway and <c>2</c> to create a Classic streams, V2 gateway. If not specified,
        /// the default is <c>2</c> (Classic streams, V2 gateway).</para><note><para>When creating a V3 gateway (<c>gatewayVersion=3</c>) with the <c>GreengrassV2</c>
        /// platform, you must also specify the <c>coreDeviceOperatingSystem</c> parameter.</para></note><para> We recommend creating an MQTT-enabled gateway for self-hosted gateways and Siemens
        /// Industrial Edge gateways. For more information on gateway versions, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/gateways.html">Use
        /// Amazon Web Services IoT SiteWise Edge Edge gateways</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GatewayVersion { get; set; }
        #endregion
        
        #region Parameter Greengrass_GroupArn
        /// <summary>
        /// <para>
        /// <para>The <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">ARN</a>
        /// of the Greengrass group. For more information about how to find a group's ARN, see
        /// <a href="https://docs.aws.amazon.com/greengrass/v1/apireference/listgroups-get.html">ListGroups</a>
        /// and <a href="https://docs.aws.amazon.com/greengrass/v1/apireference/getgroup-get.html">GetGroup</a>
        /// in the <i>IoT Greengrass V1 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatewayPlatform_Greengrass_GroupArn")]
        public System.String Greengrass_GroupArn { get; set; }
        #endregion
        
        #region Parameter SiemensIE_IotCoreThingName
        /// <summary>
        /// <para>
        /// <para>The name of the IoT Thing for your SiteWise Edge gateway.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GatewayPlatform_SiemensIE_IotCoreThingName")]
        public System.String SiemensIE_IotCoreThingName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that contain metadata for the gateway. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/tag-resources.html">Tagging
        /// your IoT SiteWise resources</a> in the <i>IoT SiteWise User Guide</i>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreateGatewayResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreateGatewayResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GatewayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWGateway (CreateGateway)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreateGatewayResponse, NewIOTSWGatewayCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GatewayName = this.GatewayName;
            #if MODULAR
            if (this.GatewayName == null && ParameterWasBound(nameof(this.GatewayName)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Greengrass_GroupArn = this.Greengrass_GroupArn;
            context.GreengrassV2_CoreDeviceOperatingSystem = this.GreengrassV2_CoreDeviceOperatingSystem;
            context.GreengrassV2_CoreDeviceThingName = this.GreengrassV2_CoreDeviceThingName;
            context.SiemensIE_IotCoreThingName = this.SiemensIE_IotCoreThingName;
            context.GatewayVersion = this.GatewayVersion;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.IoTSiteWise.Model.CreateGatewayRequest();
            
            if (cmdletContext.GatewayName != null)
            {
                request.GatewayName = cmdletContext.GatewayName;
            }
            
             // populate GatewayPlatform
            request.GatewayPlatform = new Amazon.IoTSiteWise.Model.GatewayPlatform();
            Amazon.IoTSiteWise.Model.Greengrass requestGatewayPlatform_gatewayPlatform_Greengrass = null;
            
             // populate Greengrass
            var requestGatewayPlatform_gatewayPlatform_GreengrassIsNull = true;
            requestGatewayPlatform_gatewayPlatform_Greengrass = new Amazon.IoTSiteWise.Model.Greengrass();
            System.String requestGatewayPlatform_gatewayPlatform_Greengrass_greengrass_GroupArn = null;
            if (cmdletContext.Greengrass_GroupArn != null)
            {
                requestGatewayPlatform_gatewayPlatform_Greengrass_greengrass_GroupArn = cmdletContext.Greengrass_GroupArn;
            }
            if (requestGatewayPlatform_gatewayPlatform_Greengrass_greengrass_GroupArn != null)
            {
                requestGatewayPlatform_gatewayPlatform_Greengrass.GroupArn = requestGatewayPlatform_gatewayPlatform_Greengrass_greengrass_GroupArn;
                requestGatewayPlatform_gatewayPlatform_GreengrassIsNull = false;
            }
             // determine if requestGatewayPlatform_gatewayPlatform_Greengrass should be set to null
            if (requestGatewayPlatform_gatewayPlatform_GreengrassIsNull)
            {
                requestGatewayPlatform_gatewayPlatform_Greengrass = null;
            }
            if (requestGatewayPlatform_gatewayPlatform_Greengrass != null)
            {
                request.GatewayPlatform.Greengrass = requestGatewayPlatform_gatewayPlatform_Greengrass;
            }
            Amazon.IoTSiteWise.Model.SiemensIE requestGatewayPlatform_gatewayPlatform_SiemensIE = null;
            
             // populate SiemensIE
            var requestGatewayPlatform_gatewayPlatform_SiemensIEIsNull = true;
            requestGatewayPlatform_gatewayPlatform_SiemensIE = new Amazon.IoTSiteWise.Model.SiemensIE();
            System.String requestGatewayPlatform_gatewayPlatform_SiemensIE_siemensIE_IotCoreThingName = null;
            if (cmdletContext.SiemensIE_IotCoreThingName != null)
            {
                requestGatewayPlatform_gatewayPlatform_SiemensIE_siemensIE_IotCoreThingName = cmdletContext.SiemensIE_IotCoreThingName;
            }
            if (requestGatewayPlatform_gatewayPlatform_SiemensIE_siemensIE_IotCoreThingName != null)
            {
                requestGatewayPlatform_gatewayPlatform_SiemensIE.IotCoreThingName = requestGatewayPlatform_gatewayPlatform_SiemensIE_siemensIE_IotCoreThingName;
                requestGatewayPlatform_gatewayPlatform_SiemensIEIsNull = false;
            }
             // determine if requestGatewayPlatform_gatewayPlatform_SiemensIE should be set to null
            if (requestGatewayPlatform_gatewayPlatform_SiemensIEIsNull)
            {
                requestGatewayPlatform_gatewayPlatform_SiemensIE = null;
            }
            if (requestGatewayPlatform_gatewayPlatform_SiemensIE != null)
            {
                request.GatewayPlatform.SiemensIE = requestGatewayPlatform_gatewayPlatform_SiemensIE;
            }
            Amazon.IoTSiteWise.Model.GreengrassV2 requestGatewayPlatform_gatewayPlatform_GreengrassV2 = null;
            
             // populate GreengrassV2
            var requestGatewayPlatform_gatewayPlatform_GreengrassV2IsNull = true;
            requestGatewayPlatform_gatewayPlatform_GreengrassV2 = new Amazon.IoTSiteWise.Model.GreengrassV2();
            Amazon.IoTSiteWise.CoreDeviceOperatingSystem requestGatewayPlatform_gatewayPlatform_GreengrassV2_greengrassV2_CoreDeviceOperatingSystem = null;
            if (cmdletContext.GreengrassV2_CoreDeviceOperatingSystem != null)
            {
                requestGatewayPlatform_gatewayPlatform_GreengrassV2_greengrassV2_CoreDeviceOperatingSystem = cmdletContext.GreengrassV2_CoreDeviceOperatingSystem;
            }
            if (requestGatewayPlatform_gatewayPlatform_GreengrassV2_greengrassV2_CoreDeviceOperatingSystem != null)
            {
                requestGatewayPlatform_gatewayPlatform_GreengrassV2.CoreDeviceOperatingSystem = requestGatewayPlatform_gatewayPlatform_GreengrassV2_greengrassV2_CoreDeviceOperatingSystem;
                requestGatewayPlatform_gatewayPlatform_GreengrassV2IsNull = false;
            }
            System.String requestGatewayPlatform_gatewayPlatform_GreengrassV2_greengrassV2_CoreDeviceThingName = null;
            if (cmdletContext.GreengrassV2_CoreDeviceThingName != null)
            {
                requestGatewayPlatform_gatewayPlatform_GreengrassV2_greengrassV2_CoreDeviceThingName = cmdletContext.GreengrassV2_CoreDeviceThingName;
            }
            if (requestGatewayPlatform_gatewayPlatform_GreengrassV2_greengrassV2_CoreDeviceThingName != null)
            {
                requestGatewayPlatform_gatewayPlatform_GreengrassV2.CoreDeviceThingName = requestGatewayPlatform_gatewayPlatform_GreengrassV2_greengrassV2_CoreDeviceThingName;
                requestGatewayPlatform_gatewayPlatform_GreengrassV2IsNull = false;
            }
             // determine if requestGatewayPlatform_gatewayPlatform_GreengrassV2 should be set to null
            if (requestGatewayPlatform_gatewayPlatform_GreengrassV2IsNull)
            {
                requestGatewayPlatform_gatewayPlatform_GreengrassV2 = null;
            }
            if (requestGatewayPlatform_gatewayPlatform_GreengrassV2 != null)
            {
                request.GatewayPlatform.GreengrassV2 = requestGatewayPlatform_gatewayPlatform_GreengrassV2;
            }
            if (cmdletContext.GatewayVersion != null)
            {
                request.GatewayVersion = cmdletContext.GatewayVersion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.IoTSiteWise.Model.CreateGatewayResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreateGatewayRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreateGateway");
            try
            {
                return client.CreateGatewayAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GatewayName { get; set; }
            public System.String Greengrass_GroupArn { get; set; }
            public Amazon.IoTSiteWise.CoreDeviceOperatingSystem GreengrassV2_CoreDeviceOperatingSystem { get; set; }
            public System.String GreengrassV2_CoreDeviceThingName { get; set; }
            public System.String SiemensIE_IotCoreThingName { get; set; }
            public System.String GatewayVersion { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateGatewayResponse, NewIOTSWGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
