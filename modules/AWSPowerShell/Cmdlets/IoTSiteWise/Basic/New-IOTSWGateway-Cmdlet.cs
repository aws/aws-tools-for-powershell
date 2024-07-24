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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

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
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateGatewayResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewIOTSWGatewayCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// your IoT SiteWise resources</a> in the <i>IoT SiteWise User Guide</i>.</para>
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
            context.GreengrassV2_CoreDeviceThingName = this.GreengrassV2_CoreDeviceThingName;
            context.SiemensIE_IotCoreThingName = this.SiemensIE_IotCoreThingName;
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
            var requestGatewayPlatformIsNull = true;
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
                requestGatewayPlatformIsNull = false;
            }
            Amazon.IoTSiteWise.Model.GreengrassV2 requestGatewayPlatform_gatewayPlatform_GreengrassV2 = null;
            
             // populate GreengrassV2
            var requestGatewayPlatform_gatewayPlatform_GreengrassV2IsNull = true;
            requestGatewayPlatform_gatewayPlatform_GreengrassV2 = new Amazon.IoTSiteWise.Model.GreengrassV2();
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
                requestGatewayPlatformIsNull = false;
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
                requestGatewayPlatformIsNull = false;
            }
             // determine if request.GatewayPlatform should be set to null
            if (requestGatewayPlatformIsNull)
            {
                request.GatewayPlatform = null;
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
                #if DESKTOP
                return client.CreateGateway(request);
                #elif CORECLR
                return client.CreateGatewayAsync(request).GetAwaiter().GetResult();
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
            public System.String GatewayName { get; set; }
            public System.String Greengrass_GroupArn { get; set; }
            public System.String GreengrassV2_CoreDeviceThingName { get; set; }
            public System.String SiemensIE_IotCoreThingName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateGatewayResponse, NewIOTSWGatewayCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
