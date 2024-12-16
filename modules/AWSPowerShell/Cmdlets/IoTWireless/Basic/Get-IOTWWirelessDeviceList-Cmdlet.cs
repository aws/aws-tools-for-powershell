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
    /// Lists the wireless devices registered to your AWS account.
    /// </summary>
    [Cmdlet("Get", "IOTWWirelessDeviceList")]
    [OutputType("Amazon.IoTWireless.Model.WirelessDeviceStatistics")]
    [AWSCmdlet("Calls the AWS IoT Wireless ListWirelessDevices API operation.", Operation = new[] {"ListWirelessDevices"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.ListWirelessDevicesResponse))]
    [AWSCmdletOutput("Amazon.IoTWireless.Model.WirelessDeviceStatistics or Amazon.IoTWireless.Model.ListWirelessDevicesResponse",
        "This cmdlet returns a collection of Amazon.IoTWireless.Model.WirelessDeviceStatistics objects.",
        "The service call response (type Amazon.IoTWireless.Model.ListWirelessDevicesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTWWirelessDeviceListCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationName
        /// <summary>
        /// <para>
        /// <para>A filter to list only the wireless devices that use this destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DestinationName { get; set; }
        #endregion
        
        #region Parameter DeviceProfileId
        /// <summary>
        /// <para>
        /// <para>A filter to list only the wireless devices that use this device profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeviceProfileId { get; set; }
        #endregion
        
        #region Parameter FuotaTaskId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FuotaTaskId { get; set; }
        #endregion
        
        #region Parameter MulticastGroupId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String MulticastGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceProfileId
        /// <summary>
        /// <para>
        /// <para>A filter to list only the wireless devices that use this service profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceProfileId { get; set; }
        #endregion
        
        #region Parameter WirelessDeviceType
        /// <summary>
        /// <para>
        /// <para>A filter to list only the wireless devices that use this wireless device type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.WirelessDeviceType")]
        public Amazon.IoTWireless.WirelessDeviceType WirelessDeviceType { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to return in this operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>To retrieve the next set of results, the <c>nextToken</c> value from a previous response;
        /// otherwise <b>null</b> to receive the first set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'WirelessDeviceList'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.ListWirelessDevicesResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.ListWirelessDevicesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "WirelessDeviceList";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.ListWirelessDevicesResponse, GetIOTWWirelessDeviceListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DestinationName = this.DestinationName;
            context.DeviceProfileId = this.DeviceProfileId;
            context.FuotaTaskId = this.FuotaTaskId;
            context.MaxResult = this.MaxResult;
            context.MulticastGroupId = this.MulticastGroupId;
            context.NextToken = this.NextToken;
            context.ServiceProfileId = this.ServiceProfileId;
            context.WirelessDeviceType = this.WirelessDeviceType;
            
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
            var request = new Amazon.IoTWireless.Model.ListWirelessDevicesRequest();
            
            if (cmdletContext.DestinationName != null)
            {
                request.DestinationName = cmdletContext.DestinationName;
            }
            if (cmdletContext.DeviceProfileId != null)
            {
                request.DeviceProfileId = cmdletContext.DeviceProfileId;
            }
            if (cmdletContext.FuotaTaskId != null)
            {
                request.FuotaTaskId = cmdletContext.FuotaTaskId;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.MulticastGroupId != null)
            {
                request.MulticastGroupId = cmdletContext.MulticastGroupId;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.ServiceProfileId != null)
            {
                request.ServiceProfileId = cmdletContext.ServiceProfileId;
            }
            if (cmdletContext.WirelessDeviceType != null)
            {
                request.WirelessDeviceType = cmdletContext.WirelessDeviceType;
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
        
        private Amazon.IoTWireless.Model.ListWirelessDevicesResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.ListWirelessDevicesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "ListWirelessDevices");
            try
            {
                #if DESKTOP
                return client.ListWirelessDevices(request);
                #elif CORECLR
                return client.ListWirelessDevicesAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationName { get; set; }
            public System.String DeviceProfileId { get; set; }
            public System.String FuotaTaskId { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String MulticastGroupId { get; set; }
            public System.String NextToken { get; set; }
            public System.String ServiceProfileId { get; set; }
            public Amazon.IoTWireless.WirelessDeviceType WirelessDeviceType { get; set; }
            public System.Func<Amazon.IoTWireless.Model.ListWirelessDevicesResponse, GetIOTWWirelessDeviceListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.WirelessDeviceList;
        }
        
    }
}
