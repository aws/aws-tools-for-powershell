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
    /// Each gateway capability defines data sources for a gateway. This is the namespace
    /// of the gateway capability.
    /// 
    ///  
    /// <para>
    /// . The namespace follows the format <c>service:capability:version</c>, where:
    /// </para><ul><li><para><c>service</c> - The service providing the capability, or <c>iotsitewise</c>.
    /// </para></li><li><para><c>capability</c> - The specific capability type. Options include: <c>opcuacollector</c>
    /// for the OPC UA data source collector, or <c>publisher</c> for data publisher capability.
    /// </para></li><li><para><c>version</c> - The version number of the capability. Option include <c>2</c> for
    /// Classic streams, V2 gateways, and <c>3</c> for MQTT-enabled, V3 gateways.
    /// </para></li></ul><para>
    /// After updating a capability configuration, the sync status becomes <c>OUT_OF_SYNC</c>
    /// until the gateway processes the configuration.Use <c>DescribeGatewayCapabilityConfiguration</c>
    /// to check the sync status and verify the configuration was applied.
    /// </para><para>
    /// A gateway can have multiple capability configurations with different namespaces.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "IOTSWGatewayCapabilityConfiguration")]
    [OutputType("Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise DescribeGatewayCapabilityConfiguration API operation.", Operation = new[] {"DescribeGatewayCapabilityConfiguration"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse object containing multiple properties."
    )]
    public partial class GetIOTSWGatewayCapabilityConfigurationCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CapabilityNamespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the capability configuration. For example, if you configure OPC UA
        /// sources for an MQTT-enabled gateway, your OPC-UA capability configuration has the
        /// namespace <c>iotsitewise:opcuacollector:3</c>.</para>
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
        public System.String CapabilityNamespace { get; set; }
        #endregion
        
        #region Parameter GatewayId
        /// <summary>
        /// <para>
        /// <para>The ID of the gateway that defines the capability configuration.</para>
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
        public System.String GatewayId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse, GetIOTSWGatewayCapabilityConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CapabilityNamespace = this.CapabilityNamespace;
            #if MODULAR
            if (this.CapabilityNamespace == null && ParameterWasBound(nameof(this.CapabilityNamespace)))
            {
                WriteWarning("You are passing $null as a value for parameter CapabilityNamespace which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GatewayId = this.GatewayId;
            #if MODULAR
            if (this.GatewayId == null && ParameterWasBound(nameof(this.GatewayId)))
            {
                WriteWarning("You are passing $null as a value for parameter GatewayId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationRequest();
            
            if (cmdletContext.CapabilityNamespace != null)
            {
                request.CapabilityNamespace = cmdletContext.CapabilityNamespace;
            }
            if (cmdletContext.GatewayId != null)
            {
                request.GatewayId = cmdletContext.GatewayId;
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
        
        private Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "DescribeGatewayCapabilityConfiguration");
            try
            {
                return client.DescribeGatewayCapabilityConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CapabilityNamespace { get; set; }
            public System.String GatewayId { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.DescribeGatewayCapabilityConfigurationResponse, GetIOTSWGatewayCapabilityConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
