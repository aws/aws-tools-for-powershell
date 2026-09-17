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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Get estimated position information as a payload in GeoJSON format. The payload measurement
    /// data is resolved using solvers that are provided by third-party vendors.
    /// </summary>
    [Cmdlet("Get", "IOTWPositionEstimate")]
    [OutputType("System.IO.MemoryStream")]
    [AWSCmdlet("Calls the AWS IoT Wireless GetPositionEstimate API operation.", Operation = new[] {"GetPositionEstimate"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.GetPositionEstimateResponse))]
    [AWSCmdletOutput("System.IO.MemoryStream or Amazon.IoTWireless.Model.GetPositionEstimateResponse",
        "This cmdlet returns a System.IO.MemoryStream object.",
        "The service call response (type Amazon.IoTWireless.Model.GetPositionEstimateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetIOTWPositionEstimateCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Gnss_AssistAltitude
        /// <summary>
        /// <para>
        /// <para>Optional assistance altitude, which is the altitude of the device at capture time,
        /// specified in meters above the WGS84 reference ellipsoid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Gnss_AssistAltitude { get; set; }
        #endregion
        
        #region Parameter GnssMultiFrame_AssistAltitude
        /// <summary>
        /// <para>
        /// <para>Optional assistance altitude, which is the altitude of the device at capture time,
        /// specified in meters above the WGS84 reference ellipsoid. This parameter is required
        /// when Use2DSolver is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? GnssMultiFrame_AssistAltitude { get; set; }
        #endregion
        
        #region Parameter Gnss_AssistPosition
        /// <summary>
        /// <para>
        /// <para>Optional assistance position information, specified using latitude and longitude values
        /// in degrees. The coordinates are inside the WGS84 reference frame.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single[] Gnss_AssistPosition { get; set; }
        #endregion
        
        #region Parameter GnssMultiFrame_AssistPosition
        /// <summary>
        /// <para>
        /// <para>Optional assistance position information, specified using latitude and longitude values
        /// in degrees. The coordinates are inside the WGS84 reference frame.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single[] GnssMultiFrame_AssistPosition { get; set; }
        #endregion
        
        #region Parameter GnssMultiFrame_Capture
        /// <summary>
        /// <para>
        /// <para>List of GNSS scan captures. Each capture contains a payload from a single GNSS scan.
        /// The number of captures must be 2, 4, 8, 16, or 32.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GnssMultiFrame_Captures")]
        public Amazon.IoTWireless.Model.GnssCapture[] GnssMultiFrame_Capture { get; set; }
        #endregion
        
        #region Parameter Gnss_CaptureTime
        /// <summary>
        /// <para>
        /// <para>Optional parameter that gives an estimate of the time when the GNSS scan information
        /// is taken, in seconds GPS time (GPST). If capture time is not specified, the local
        /// server time is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Gnss_CaptureTime { get; set; }
        #endregion
        
        #region Parameter Gnss_CaptureTimeAccuracy
        /// <summary>
        /// <para>
        /// <para>Optional value that gives the capture time estimate accuracy, in seconds. If capture
        /// time accuracy is not specified, default value of 300 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Gnss_CaptureTimeAccuracy { get; set; }
        #endregion
        
        #region Parameter GnssMultiFrame_CaptureTimeAccuracy
        /// <summary>
        /// <para>
        /// <para>Optional value that gives the capture time estimate accuracy, in seconds. If capture
        /// time accuracy is not specified, default value of 300 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? GnssMultiFrame_CaptureTimeAccuracy { get; set; }
        #endregion
        
        #region Parameter CellTowers_Cdma
        /// <summary>
        /// <para>
        /// <para>CDMA object information.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTWireless.Model.CdmaObj[] CellTowers_Cdma { get; set; }
        #endregion
        
        #region Parameter AdvancedConfiguration_WiFiCellular_ConfidencePercent
        /// <summary>
        /// <para>
        /// <para>The confidence level for WiFi and cellular position estimates, expressed as a percentage.
        /// This value determines the size of the confidence area or uncertainty radius for the
        /// estimated position. A higher confidence level produces a larger uncertainty radius,
        /// while a lower confidence level produces a smaller, more precise radius.</para><para>Valid range: 50 to 99 inclusive. If not specified, the default value of 68 is used,
        /// which corresponds to approximately one standard deviation of the normal distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AdvancedConfiguration_WiFiCellular_ConfidencePercent { get; set; }
        #endregion
        
        #region Parameter CellTowers_Gsm
        /// <summary>
        /// <para>
        /// <para>GSM object information.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTWireless.Model.GsmObj[] CellTowers_Gsm { get; set; }
        #endregion
        
        #region Parameter Ip_IpAddress
        /// <summary>
        /// <para>
        /// <para>IP address information.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ip_IpAddress { get; set; }
        #endregion
        
        #region Parameter CellTowers_Lte
        /// <summary>
        /// <para>
        /// <para>LTE object information.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTWireless.Model.LteObj[] CellTowers_Lte { get; set; }
        #endregion
        
        #region Parameter Gnss_Payload
        /// <summary>
        /// <para>
        /// <para>Payload that contains the GNSS scan result, or NAV message, in hexadecimal notation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Gnss_Payload { get; set; }
        #endregion
        
        #region Parameter CellTowers_Tdscdma
        /// <summary>
        /// <para>
        /// <para>TD-SCDMA object information.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTWireless.Model.TdscdmaObj[] CellTowers_Tdscdma { get; set; }
        #endregion
        
        #region Parameter Timestamp
        /// <summary>
        /// <para>
        /// <para>Optional information that specifies the time when the position information will be
        /// resolved. It uses the Unix timestamp format. If not specified, the time at which the
        /// request was received will be used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.DateTime? Timestamp { get; set; }
        #endregion
        
        #region Parameter Gnss_Use2DSolver
        /// <summary>
        /// <para>
        /// <para>Optional parameter that forces 2D solve, which modifies the positioning algorithm
        /// to a 2D solution problem. When this parameter is specified, the assistance altitude
        /// should have an accuracy of at least 10 meters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Gnss_Use2DSolver { get; set; }
        #endregion
        
        #region Parameter GnssMultiFrame_Use2DSolver
        /// <summary>
        /// <para>
        /// <para>Optional parameter that forces 2D solve, which modifies the positioning algorithm
        /// to a 2D solution problem. When this parameter is specified, the assistance altitude
        /// should have an accuracy of at least 10 meters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? GnssMultiFrame_Use2DSolver { get; set; }
        #endregion
        
        #region Parameter CellTowers_Wcdma
        /// <summary>
        /// <para>
        /// <para>WCDMA object information.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IoTWireless.Model.WcdmaObj[] CellTowers_Wcdma { get; set; }
        #endregion
        
        #region Parameter WiFiAccessPoint
        /// <summary>
        /// <para>
        /// <para>Retrieves an estimated device position by resolving WLAN measurement data. The position
        /// is resolved using HERE's Wi-Fi based solver.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WiFiAccessPoints")]
        public Amazon.IoTWireless.Model.WiFiAccessPoint[] WiFiAccessPoint { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GeoJsonPayload'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.GetPositionEstimateResponse).
        /// Specifying the name of a property of type Amazon.IoTWireless.Model.GetPositionEstimateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GeoJsonPayload";
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
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.GetPositionEstimateResponse, GetIOTWPositionEstimateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdvancedConfiguration_WiFiCellular_ConfidencePercent = this.AdvancedConfiguration_WiFiCellular_ConfidencePercent;
            if (this.CellTowers_Cdma != null)
            {
                context.CellTowers_Cdma = new List<Amazon.IoTWireless.Model.CdmaObj>(this.CellTowers_Cdma);
            }
            if (this.CellTowers_Gsm != null)
            {
                context.CellTowers_Gsm = new List<Amazon.IoTWireless.Model.GsmObj>(this.CellTowers_Gsm);
            }
            if (this.CellTowers_Lte != null)
            {
                context.CellTowers_Lte = new List<Amazon.IoTWireless.Model.LteObj>(this.CellTowers_Lte);
            }
            if (this.CellTowers_Tdscdma != null)
            {
                context.CellTowers_Tdscdma = new List<Amazon.IoTWireless.Model.TdscdmaObj>(this.CellTowers_Tdscdma);
            }
            if (this.CellTowers_Wcdma != null)
            {
                context.CellTowers_Wcdma = new List<Amazon.IoTWireless.Model.WcdmaObj>(this.CellTowers_Wcdma);
            }
            context.Gnss_AssistAltitude = this.Gnss_AssistAltitude;
            if (this.Gnss_AssistPosition != null)
            {
                context.Gnss_AssistPosition = new List<System.Single>(this.Gnss_AssistPosition);
            }
            context.Gnss_CaptureTime = this.Gnss_CaptureTime;
            context.Gnss_CaptureTimeAccuracy = this.Gnss_CaptureTimeAccuracy;
            context.Gnss_Payload = this.Gnss_Payload;
            context.Gnss_Use2DSolver = this.Gnss_Use2DSolver;
            context.GnssMultiFrame_AssistAltitude = this.GnssMultiFrame_AssistAltitude;
            if (this.GnssMultiFrame_AssistPosition != null)
            {
                context.GnssMultiFrame_AssistPosition = new List<System.Single>(this.GnssMultiFrame_AssistPosition);
            }
            if (this.GnssMultiFrame_Capture != null)
            {
                context.GnssMultiFrame_Capture = new List<Amazon.IoTWireless.Model.GnssCapture>(this.GnssMultiFrame_Capture);
            }
            context.GnssMultiFrame_CaptureTimeAccuracy = this.GnssMultiFrame_CaptureTimeAccuracy;
            context.GnssMultiFrame_Use2DSolver = this.GnssMultiFrame_Use2DSolver;
            context.Ip_IpAddress = this.Ip_IpAddress;
            context.Timestamp = this.Timestamp;
            if (this.WiFiAccessPoint != null)
            {
                context.WiFiAccessPoint = new List<Amazon.IoTWireless.Model.WiFiAccessPoint>(this.WiFiAccessPoint);
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
            var request = new Amazon.IoTWireless.Model.GetPositionEstimateRequest();
            
            
             // populate AdvancedConfiguration
            var requestAdvancedConfigurationIsNull = true;
            request.AdvancedConfiguration = new Amazon.IoTWireless.Model.AdvancedConfiguration();
            Amazon.IoTWireless.Model.WiFiCellular requestAdvancedConfiguration_advancedConfiguration_WiFiCellular = null;
            
             // populate WiFiCellular
            var requestAdvancedConfiguration_advancedConfiguration_WiFiCellularIsNull = true;
            requestAdvancedConfiguration_advancedConfiguration_WiFiCellular = new Amazon.IoTWireless.Model.WiFiCellular();
            System.Int32? requestAdvancedConfiguration_advancedConfiguration_WiFiCellular_advancedConfiguration_WiFiCellular_ConfidencePercent = null;
            if (cmdletContext.AdvancedConfiguration_WiFiCellular_ConfidencePercent != null)
            {
                requestAdvancedConfiguration_advancedConfiguration_WiFiCellular_advancedConfiguration_WiFiCellular_ConfidencePercent = cmdletContext.AdvancedConfiguration_WiFiCellular_ConfidencePercent.Value;
            }
            if (requestAdvancedConfiguration_advancedConfiguration_WiFiCellular_advancedConfiguration_WiFiCellular_ConfidencePercent != null)
            {
                requestAdvancedConfiguration_advancedConfiguration_WiFiCellular.ConfidencePercent = requestAdvancedConfiguration_advancedConfiguration_WiFiCellular_advancedConfiguration_WiFiCellular_ConfidencePercent.Value;
                requestAdvancedConfiguration_advancedConfiguration_WiFiCellularIsNull = false;
            }
             // determine if requestAdvancedConfiguration_advancedConfiguration_WiFiCellular should be set to null
            if (requestAdvancedConfiguration_advancedConfiguration_WiFiCellularIsNull)
            {
                requestAdvancedConfiguration_advancedConfiguration_WiFiCellular = null;
            }
            if (requestAdvancedConfiguration_advancedConfiguration_WiFiCellular != null)
            {
                request.AdvancedConfiguration.WiFiCellular = requestAdvancedConfiguration_advancedConfiguration_WiFiCellular;
                requestAdvancedConfigurationIsNull = false;
            }
             // determine if request.AdvancedConfiguration should be set to null
            if (requestAdvancedConfigurationIsNull)
            {
                request.AdvancedConfiguration = null;
            }
            
             // populate CellTowers
            var requestCellTowersIsNull = true;
            request.CellTowers = new Amazon.IoTWireless.Model.CellTowers();
            List<Amazon.IoTWireless.Model.CdmaObj> requestCellTowers_cellTowers_Cdma = null;
            if (cmdletContext.CellTowers_Cdma != null)
            {
                requestCellTowers_cellTowers_Cdma = cmdletContext.CellTowers_Cdma;
            }
            if (requestCellTowers_cellTowers_Cdma != null)
            {
                request.CellTowers.Cdma = requestCellTowers_cellTowers_Cdma;
                requestCellTowersIsNull = false;
            }
            List<Amazon.IoTWireless.Model.GsmObj> requestCellTowers_cellTowers_Gsm = null;
            if (cmdletContext.CellTowers_Gsm != null)
            {
                requestCellTowers_cellTowers_Gsm = cmdletContext.CellTowers_Gsm;
            }
            if (requestCellTowers_cellTowers_Gsm != null)
            {
                request.CellTowers.Gsm = requestCellTowers_cellTowers_Gsm;
                requestCellTowersIsNull = false;
            }
            List<Amazon.IoTWireless.Model.LteObj> requestCellTowers_cellTowers_Lte = null;
            if (cmdletContext.CellTowers_Lte != null)
            {
                requestCellTowers_cellTowers_Lte = cmdletContext.CellTowers_Lte;
            }
            if (requestCellTowers_cellTowers_Lte != null)
            {
                request.CellTowers.Lte = requestCellTowers_cellTowers_Lte;
                requestCellTowersIsNull = false;
            }
            List<Amazon.IoTWireless.Model.TdscdmaObj> requestCellTowers_cellTowers_Tdscdma = null;
            if (cmdletContext.CellTowers_Tdscdma != null)
            {
                requestCellTowers_cellTowers_Tdscdma = cmdletContext.CellTowers_Tdscdma;
            }
            if (requestCellTowers_cellTowers_Tdscdma != null)
            {
                request.CellTowers.Tdscdma = requestCellTowers_cellTowers_Tdscdma;
                requestCellTowersIsNull = false;
            }
            List<Amazon.IoTWireless.Model.WcdmaObj> requestCellTowers_cellTowers_Wcdma = null;
            if (cmdletContext.CellTowers_Wcdma != null)
            {
                requestCellTowers_cellTowers_Wcdma = cmdletContext.CellTowers_Wcdma;
            }
            if (requestCellTowers_cellTowers_Wcdma != null)
            {
                request.CellTowers.Wcdma = requestCellTowers_cellTowers_Wcdma;
                requestCellTowersIsNull = false;
            }
             // determine if request.CellTowers should be set to null
            if (requestCellTowersIsNull)
            {
                request.CellTowers = null;
            }
            
             // populate Gnss
            var requestGnssIsNull = true;
            request.Gnss = new Amazon.IoTWireless.Model.Gnss();
            System.Single? requestGnss_gnss_AssistAltitude = null;
            if (cmdletContext.Gnss_AssistAltitude != null)
            {
                requestGnss_gnss_AssistAltitude = cmdletContext.Gnss_AssistAltitude.Value;
            }
            if (requestGnss_gnss_AssistAltitude != null)
            {
                request.Gnss.AssistAltitude = requestGnss_gnss_AssistAltitude.Value;
                requestGnssIsNull = false;
            }
            List<System.Single> requestGnss_gnss_AssistPosition = null;
            if (cmdletContext.Gnss_AssistPosition != null)
            {
                requestGnss_gnss_AssistPosition = cmdletContext.Gnss_AssistPosition;
            }
            if (requestGnss_gnss_AssistPosition != null)
            {
                request.Gnss.AssistPosition = requestGnss_gnss_AssistPosition;
                requestGnssIsNull = false;
            }
            System.Single? requestGnss_gnss_CaptureTime = null;
            if (cmdletContext.Gnss_CaptureTime != null)
            {
                requestGnss_gnss_CaptureTime = cmdletContext.Gnss_CaptureTime.Value;
            }
            if (requestGnss_gnss_CaptureTime != null)
            {
                request.Gnss.CaptureTime = requestGnss_gnss_CaptureTime.Value;
                requestGnssIsNull = false;
            }
            System.Single? requestGnss_gnss_CaptureTimeAccuracy = null;
            if (cmdletContext.Gnss_CaptureTimeAccuracy != null)
            {
                requestGnss_gnss_CaptureTimeAccuracy = cmdletContext.Gnss_CaptureTimeAccuracy.Value;
            }
            if (requestGnss_gnss_CaptureTimeAccuracy != null)
            {
                request.Gnss.CaptureTimeAccuracy = requestGnss_gnss_CaptureTimeAccuracy.Value;
                requestGnssIsNull = false;
            }
            System.String requestGnss_gnss_Payload = null;
            if (cmdletContext.Gnss_Payload != null)
            {
                requestGnss_gnss_Payload = cmdletContext.Gnss_Payload;
            }
            if (requestGnss_gnss_Payload != null)
            {
                request.Gnss.Payload = requestGnss_gnss_Payload;
                requestGnssIsNull = false;
            }
            System.Boolean? requestGnss_gnss_Use2DSolver = null;
            if (cmdletContext.Gnss_Use2DSolver != null)
            {
                requestGnss_gnss_Use2DSolver = cmdletContext.Gnss_Use2DSolver.Value;
            }
            if (requestGnss_gnss_Use2DSolver != null)
            {
                request.Gnss.Use2DSolver = requestGnss_gnss_Use2DSolver.Value;
                requestGnssIsNull = false;
            }
             // determine if request.Gnss should be set to null
            if (requestGnssIsNull)
            {
                request.Gnss = null;
            }
            
             // populate GnssMultiFrame
            var requestGnssMultiFrameIsNull = true;
            request.GnssMultiFrame = new Amazon.IoTWireless.Model.GnssMultiFrame();
            System.Single? requestGnssMultiFrame_gnssMultiFrame_AssistAltitude = null;
            if (cmdletContext.GnssMultiFrame_AssistAltitude != null)
            {
                requestGnssMultiFrame_gnssMultiFrame_AssistAltitude = cmdletContext.GnssMultiFrame_AssistAltitude.Value;
            }
            if (requestGnssMultiFrame_gnssMultiFrame_AssistAltitude != null)
            {
                request.GnssMultiFrame.AssistAltitude = requestGnssMultiFrame_gnssMultiFrame_AssistAltitude.Value;
                requestGnssMultiFrameIsNull = false;
            }
            List<System.Single> requestGnssMultiFrame_gnssMultiFrame_AssistPosition = null;
            if (cmdletContext.GnssMultiFrame_AssistPosition != null)
            {
                requestGnssMultiFrame_gnssMultiFrame_AssistPosition = cmdletContext.GnssMultiFrame_AssistPosition;
            }
            if (requestGnssMultiFrame_gnssMultiFrame_AssistPosition != null)
            {
                request.GnssMultiFrame.AssistPosition = requestGnssMultiFrame_gnssMultiFrame_AssistPosition;
                requestGnssMultiFrameIsNull = false;
            }
            List<Amazon.IoTWireless.Model.GnssCapture> requestGnssMultiFrame_gnssMultiFrame_Capture = null;
            if (cmdletContext.GnssMultiFrame_Capture != null)
            {
                requestGnssMultiFrame_gnssMultiFrame_Capture = cmdletContext.GnssMultiFrame_Capture;
            }
            if (requestGnssMultiFrame_gnssMultiFrame_Capture != null)
            {
                request.GnssMultiFrame.Captures = requestGnssMultiFrame_gnssMultiFrame_Capture;
                requestGnssMultiFrameIsNull = false;
            }
            System.Single? requestGnssMultiFrame_gnssMultiFrame_CaptureTimeAccuracy = null;
            if (cmdletContext.GnssMultiFrame_CaptureTimeAccuracy != null)
            {
                requestGnssMultiFrame_gnssMultiFrame_CaptureTimeAccuracy = cmdletContext.GnssMultiFrame_CaptureTimeAccuracy.Value;
            }
            if (requestGnssMultiFrame_gnssMultiFrame_CaptureTimeAccuracy != null)
            {
                request.GnssMultiFrame.CaptureTimeAccuracy = requestGnssMultiFrame_gnssMultiFrame_CaptureTimeAccuracy.Value;
                requestGnssMultiFrameIsNull = false;
            }
            System.Boolean? requestGnssMultiFrame_gnssMultiFrame_Use2DSolver = null;
            if (cmdletContext.GnssMultiFrame_Use2DSolver != null)
            {
                requestGnssMultiFrame_gnssMultiFrame_Use2DSolver = cmdletContext.GnssMultiFrame_Use2DSolver.Value;
            }
            if (requestGnssMultiFrame_gnssMultiFrame_Use2DSolver != null)
            {
                request.GnssMultiFrame.Use2DSolver = requestGnssMultiFrame_gnssMultiFrame_Use2DSolver.Value;
                requestGnssMultiFrameIsNull = false;
            }
             // determine if request.GnssMultiFrame should be set to null
            if (requestGnssMultiFrameIsNull)
            {
                request.GnssMultiFrame = null;
            }
            
             // populate Ip
            var requestIpIsNull = true;
            request.Ip = new Amazon.IoTWireless.Model.Ip();
            System.String requestIp_ip_IpAddress = null;
            if (cmdletContext.Ip_IpAddress != null)
            {
                requestIp_ip_IpAddress = cmdletContext.Ip_IpAddress;
            }
            if (requestIp_ip_IpAddress != null)
            {
                request.Ip.IpAddress = requestIp_ip_IpAddress;
                requestIpIsNull = false;
            }
             // determine if request.Ip should be set to null
            if (requestIpIsNull)
            {
                request.Ip = null;
            }
            if (cmdletContext.Timestamp != null)
            {
                request.Timestamp = cmdletContext.Timestamp.Value;
            }
            if (cmdletContext.WiFiAccessPoint != null)
            {
                request.WiFiAccessPoints = cmdletContext.WiFiAccessPoint;
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
        
        private Amazon.IoTWireless.Model.GetPositionEstimateResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.GetPositionEstimateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "GetPositionEstimate");
            try
            {
                return client.GetPositionEstimateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? AdvancedConfiguration_WiFiCellular_ConfidencePercent { get; set; }
            public List<Amazon.IoTWireless.Model.CdmaObj> CellTowers_Cdma { get; set; }
            public List<Amazon.IoTWireless.Model.GsmObj> CellTowers_Gsm { get; set; }
            public List<Amazon.IoTWireless.Model.LteObj> CellTowers_Lte { get; set; }
            public List<Amazon.IoTWireless.Model.TdscdmaObj> CellTowers_Tdscdma { get; set; }
            public List<Amazon.IoTWireless.Model.WcdmaObj> CellTowers_Wcdma { get; set; }
            public System.Single? Gnss_AssistAltitude { get; set; }
            public List<System.Single> Gnss_AssistPosition { get; set; }
            public System.Single? Gnss_CaptureTime { get; set; }
            public System.Single? Gnss_CaptureTimeAccuracy { get; set; }
            public System.String Gnss_Payload { get; set; }
            public System.Boolean? Gnss_Use2DSolver { get; set; }
            public System.Single? GnssMultiFrame_AssistAltitude { get; set; }
            public List<System.Single> GnssMultiFrame_AssistPosition { get; set; }
            public List<Amazon.IoTWireless.Model.GnssCapture> GnssMultiFrame_Capture { get; set; }
            public System.Single? GnssMultiFrame_CaptureTimeAccuracy { get; set; }
            public System.Boolean? GnssMultiFrame_Use2DSolver { get; set; }
            public System.String Ip_IpAddress { get; set; }
            public System.DateTime? Timestamp { get; set; }
            public List<Amazon.IoTWireless.Model.WiFiAccessPoint> WiFiAccessPoint { get; set; }
            public System.Func<Amazon.IoTWireless.Model.GetPositionEstimateResponse, GetIOTWPositionEstimateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GeoJsonPayload;
        }
        
    }
}
