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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// Create an ephemeris with your specified <a>EphemerisData</a>.
    /// </summary>
    [Cmdlet("New", "GSEphemeris", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Ground Station CreateEphemeris API operation.", Operation = new[] {"CreateEphemeris"}, SelectReturnType = typeof(Amazon.GroundStation.Model.CreateEphemerisResponse))]
    [AWSCmdletOutput("System.String or Amazon.GroundStation.Model.CreateEphemerisResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GroundStation.Model.CreateEphemerisResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGSEphemerisCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AzElData_AngleUnit
        /// <summary>
        /// <para>
        /// <para>The unit of measure for azimuth and elevation angles. All angles in all segments must
        /// use the same unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_AzEl_Data_AzElData_AngleUnit")]
        [AWSConstantClassSource("Amazon.GroundStation.AngleUnits")]
        public Amazon.GroundStation.AngleUnits AzElData_AngleUnit { get; set; }
        #endregion
        
        #region Parameter AzElData_AzElSegmentList
        /// <summary>
        /// <para>
        /// <para>List of azimuth elevation segments.</para><para>Must contain between 1 and 100 segments. Segments must be in chronological order with
        /// no overlaps.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_AzEl_Data_AzElData_AzElSegmentList")]
        public Amazon.GroundStation.Model.AzElSegment[] AzElData_AzElSegmentList { get; set; }
        #endregion
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 Bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_AzEl_Data_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Oem_S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 Bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Oem_S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Tle_S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 Bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Tle_S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to enable the ephemeris after validation. Set to <c>false</c> to
        /// keep it disabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter ExpirationTime
        /// <summary>
        /// <para>
        /// <para>An overall expiration time for the ephemeris in UTC, after which it will become <c>EXPIRED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpirationTime { get; set; }
        #endregion
        
        #region Parameter AzEl_GroundStation
        /// <summary>
        /// <para>
        /// <para>The ground station name for which you're providing azimuth elevation data.</para><para>This ephemeris is specific to this ground station and can't be used at other locations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_AzEl_GroundStation")]
        public System.String AzEl_GroundStation { get; set; }
        #endregion
        
        #region Parameter S3Object_Key
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 key for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_AzEl_Data_S3Object_Key")]
        public System.String S3Object_Key { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Oem_S3Object_Key
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 key for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Oem_S3Object_Key { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Tle_S3Object_Key
        /// <summary>
        /// <para>
        /// <para>An Amazon S3 key for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Tle_S3Object_Key { get; set; }
        #endregion
        
        #region Parameter KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the KMS key to use for encrypting the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name that you can use to identify the ephemeris.</para>
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
        
        #region Parameter Oem_OemData
        /// <summary>
        /// <para>
        /// <para>OEM data that you provide directly instead of using an Amazon S3 object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_Oem_OemData")]
        public System.String Oem_OemData { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>A priority score that determines which ephemeris to use when multiple ephemerides
        /// overlap.</para><para>Higher numbers take precedence. The default is 1. Must be 1 or greater.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter SatelliteId
        /// <summary>
        /// <para>
        /// <para>The satellite ID that associates this ephemeris with a satellite in AWS Ground Station.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SatelliteId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags assigned to an ephemeris.</para><para />
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
        
        #region Parameter Tle_TleData
        /// <summary>
        /// <para>
        /// <para>TLE data that you provide directly instead of using an Amazon S3 object.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_Tle_TleData")]
        public Amazon.GroundStation.Model.TLEData[] Tle_TleData { get; set; }
        #endregion
        
        #region Parameter S3Object_Version
        /// <summary>
        /// <para>
        /// <para>For versioned Amazon S3 objects, the version to use for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Ephemeris_AzEl_Data_S3Object_Version")]
        public System.String S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Oem_S3Object_Version
        /// <summary>
        /// <para>
        /// <para>For versioned Amazon S3 objects, the version to use for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Oem_S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Ephemeris_Tle_S3Object_Version
        /// <summary>
        /// <para>
        /// <para>For versioned Amazon S3 objects, the version to use for the ephemeris.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Ephemeris_Tle_S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EphemerisId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.CreateEphemerisResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.CreateEphemerisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EphemerisId";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GSEphemeris (CreateEphemeris)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.CreateEphemerisResponse, NewGSEphemerisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enabled = this.Enabled;
            context.AzElData_AngleUnit = this.AzElData_AngleUnit;
            if (this.AzElData_AzElSegmentList != null)
            {
                context.AzElData_AzElSegmentList = new List<Amazon.GroundStation.Model.AzElSegment>(this.AzElData_AzElSegmentList);
            }
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Key = this.S3Object_Key;
            context.S3Object_Version = this.S3Object_Version;
            context.AzEl_GroundStation = this.AzEl_GroundStation;
            context.Oem_OemData = this.Oem_OemData;
            context.Ephemeris_Oem_S3Object_Bucket = this.Ephemeris_Oem_S3Object_Bucket;
            context.Ephemeris_Oem_S3Object_Key = this.Ephemeris_Oem_S3Object_Key;
            context.Ephemeris_Oem_S3Object_Version = this.Ephemeris_Oem_S3Object_Version;
            context.Ephemeris_Tle_S3Object_Bucket = this.Ephemeris_Tle_S3Object_Bucket;
            context.Ephemeris_Tle_S3Object_Key = this.Ephemeris_Tle_S3Object_Key;
            context.Ephemeris_Tle_S3Object_Version = this.Ephemeris_Tle_S3Object_Version;
            if (this.Tle_TleData != null)
            {
                context.Tle_TleData = new List<Amazon.GroundStation.Model.TLEData>(this.Tle_TleData);
            }
            context.ExpirationTime = this.ExpirationTime;
            context.KmsKeyArn = this.KmsKeyArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Priority = this.Priority;
            context.SatelliteId = this.SatelliteId;
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
            var request = new Amazon.GroundStation.Model.CreateEphemerisRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            
             // populate Ephemeris
            var requestEphemerisIsNull = true;
            request.Ephemeris = new Amazon.GroundStation.Model.EphemerisData();
            Amazon.GroundStation.Model.AzElEphemeris requestEphemeris_ephemeris_AzEl = null;
            
             // populate AzEl
            var requestEphemeris_ephemeris_AzElIsNull = true;
            requestEphemeris_ephemeris_AzEl = new Amazon.GroundStation.Model.AzElEphemeris();
            System.String requestEphemeris_ephemeris_AzEl_azEl_GroundStation = null;
            if (cmdletContext.AzEl_GroundStation != null)
            {
                requestEphemeris_ephemeris_AzEl_azEl_GroundStation = cmdletContext.AzEl_GroundStation;
            }
            if (requestEphemeris_ephemeris_AzEl_azEl_GroundStation != null)
            {
                requestEphemeris_ephemeris_AzEl.GroundStation = requestEphemeris_ephemeris_AzEl_azEl_GroundStation;
                requestEphemeris_ephemeris_AzElIsNull = false;
            }
            Amazon.GroundStation.Model.AzElSegmentsData requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data = null;
            
             // populate Data
            var requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_DataIsNull = true;
            requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data = new Amazon.GroundStation.Model.AzElSegmentsData();
            Amazon.GroundStation.Model.AzElSegments requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData = null;
            
             // populate AzElData
            var requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElDataIsNull = true;
            requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData = new Amazon.GroundStation.Model.AzElSegments();
            Amazon.GroundStation.AngleUnits requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData_azElData_AngleUnit = null;
            if (cmdletContext.AzElData_AngleUnit != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData_azElData_AngleUnit = cmdletContext.AzElData_AngleUnit;
            }
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData_azElData_AngleUnit != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData.AngleUnit = requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData_azElData_AngleUnit;
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElDataIsNull = false;
            }
            List<Amazon.GroundStation.Model.AzElSegment> requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData_azElData_AzElSegmentList = null;
            if (cmdletContext.AzElData_AzElSegmentList != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData_azElData_AzElSegmentList = cmdletContext.AzElData_AzElSegmentList;
            }
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData_azElData_AzElSegmentList != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData.AzElSegmentList = requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData_azElData_AzElSegmentList;
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElDataIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData should be set to null
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElDataIsNull)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData = null;
            }
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data.AzElData = requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_AzElData;
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_DataIsNull = false;
            }
            Amazon.GroundStation.Model.S3Object requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object = null;
            
             // populate S3Object
            var requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3ObjectIsNull = true;
            requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object = new Amazon.GroundStation.Model.S3Object();
            System.String requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Bucket = null;
            if (cmdletContext.S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Bucket = cmdletContext.S3Object_Bucket;
            }
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object.Bucket = requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Bucket;
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Key = null;
            if (cmdletContext.S3Object_Key != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Key = cmdletContext.S3Object_Key;
            }
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Key != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object.Key = requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Key;
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Version = null;
            if (cmdletContext.S3Object_Version != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Version = cmdletContext.S3Object_Version;
            }
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Version != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object.Version = requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object_s3Object_Version;
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3ObjectIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object should be set to null
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3ObjectIsNull)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object = null;
            }
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object != null)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data.S3Object = requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data_ephemeris_AzEl_Data_S3Object;
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_DataIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data should be set to null
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_DataIsNull)
            {
                requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data = null;
            }
            if (requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data != null)
            {
                requestEphemeris_ephemeris_AzEl.Data = requestEphemeris_ephemeris_AzEl_ephemeris_AzEl_Data;
                requestEphemeris_ephemeris_AzElIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_AzEl should be set to null
            if (requestEphemeris_ephemeris_AzElIsNull)
            {
                requestEphemeris_ephemeris_AzEl = null;
            }
            if (requestEphemeris_ephemeris_AzEl != null)
            {
                request.Ephemeris.AzEl = requestEphemeris_ephemeris_AzEl;
                requestEphemerisIsNull = false;
            }
            Amazon.GroundStation.Model.OEMEphemeris requestEphemeris_ephemeris_Oem = null;
            
             // populate Oem
            var requestEphemeris_ephemeris_OemIsNull = true;
            requestEphemeris_ephemeris_Oem = new Amazon.GroundStation.Model.OEMEphemeris();
            System.String requestEphemeris_ephemeris_Oem_oem_OemData = null;
            if (cmdletContext.Oem_OemData != null)
            {
                requestEphemeris_ephemeris_Oem_oem_OemData = cmdletContext.Oem_OemData;
            }
            if (requestEphemeris_ephemeris_Oem_oem_OemData != null)
            {
                requestEphemeris_ephemeris_Oem.OemData = requestEphemeris_ephemeris_Oem_oem_OemData;
                requestEphemeris_ephemeris_OemIsNull = false;
            }
            Amazon.GroundStation.Model.S3Object requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object = null;
            
             // populate S3Object
            var requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull = true;
            requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object = new Amazon.GroundStation.Model.S3Object();
            System.String requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Bucket = null;
            if (cmdletContext.Ephemeris_Oem_S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Bucket = cmdletContext.Ephemeris_Oem_S3Object_Bucket;
            }
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object.Bucket = requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Bucket;
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Key = null;
            if (cmdletContext.Ephemeris_Oem_S3Object_Key != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Key = cmdletContext.Ephemeris_Oem_S3Object_Key;
            }
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Key != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object.Key = requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Key;
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Version = null;
            if (cmdletContext.Ephemeris_Oem_S3Object_Version != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Version = cmdletContext.Ephemeris_Oem_S3Object_Version;
            }
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Version != null)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object.Version = requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object_ephemeris_Oem_S3Object_Version;
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object should be set to null
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3ObjectIsNull)
            {
                requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object = null;
            }
            if (requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object != null)
            {
                requestEphemeris_ephemeris_Oem.S3Object = requestEphemeris_ephemeris_Oem_ephemeris_Oem_S3Object;
                requestEphemeris_ephemeris_OemIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_Oem should be set to null
            if (requestEphemeris_ephemeris_OemIsNull)
            {
                requestEphemeris_ephemeris_Oem = null;
            }
            if (requestEphemeris_ephemeris_Oem != null)
            {
                request.Ephemeris.Oem = requestEphemeris_ephemeris_Oem;
                requestEphemerisIsNull = false;
            }
            Amazon.GroundStation.Model.TLEEphemeris requestEphemeris_ephemeris_Tle = null;
            
             // populate Tle
            var requestEphemeris_ephemeris_TleIsNull = true;
            requestEphemeris_ephemeris_Tle = new Amazon.GroundStation.Model.TLEEphemeris();
            List<Amazon.GroundStation.Model.TLEData> requestEphemeris_ephemeris_Tle_tle_TleData = null;
            if (cmdletContext.Tle_TleData != null)
            {
                requestEphemeris_ephemeris_Tle_tle_TleData = cmdletContext.Tle_TleData;
            }
            if (requestEphemeris_ephemeris_Tle_tle_TleData != null)
            {
                requestEphemeris_ephemeris_Tle.TleData = requestEphemeris_ephemeris_Tle_tle_TleData;
                requestEphemeris_ephemeris_TleIsNull = false;
            }
            Amazon.GroundStation.Model.S3Object requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object = null;
            
             // populate S3Object
            var requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull = true;
            requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object = new Amazon.GroundStation.Model.S3Object();
            System.String requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Bucket = null;
            if (cmdletContext.Ephemeris_Tle_S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Bucket = cmdletContext.Ephemeris_Tle_S3Object_Bucket;
            }
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Bucket != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object.Bucket = requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Bucket;
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Key = null;
            if (cmdletContext.Ephemeris_Tle_S3Object_Key != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Key = cmdletContext.Ephemeris_Tle_S3Object_Key;
            }
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Key != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object.Key = requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Key;
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull = false;
            }
            System.String requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Version = null;
            if (cmdletContext.Ephemeris_Tle_S3Object_Version != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Version = cmdletContext.Ephemeris_Tle_S3Object_Version;
            }
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Version != null)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object.Version = requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object_ephemeris_Tle_S3Object_Version;
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object should be set to null
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3ObjectIsNull)
            {
                requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object = null;
            }
            if (requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object != null)
            {
                requestEphemeris_ephemeris_Tle.S3Object = requestEphemeris_ephemeris_Tle_ephemeris_Tle_S3Object;
                requestEphemeris_ephemeris_TleIsNull = false;
            }
             // determine if requestEphemeris_ephemeris_Tle should be set to null
            if (requestEphemeris_ephemeris_TleIsNull)
            {
                requestEphemeris_ephemeris_Tle = null;
            }
            if (requestEphemeris_ephemeris_Tle != null)
            {
                request.Ephemeris.Tle = requestEphemeris_ephemeris_Tle;
                requestEphemerisIsNull = false;
            }
             // determine if request.Ephemeris should be set to null
            if (requestEphemerisIsNull)
            {
                request.Ephemeris = null;
            }
            if (cmdletContext.ExpirationTime != null)
            {
                request.ExpirationTime = cmdletContext.ExpirationTime.Value;
            }
            if (cmdletContext.KmsKeyArn != null)
            {
                request.KmsKeyArn = cmdletContext.KmsKeyArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
            }
            if (cmdletContext.SatelliteId != null)
            {
                request.SatelliteId = cmdletContext.SatelliteId;
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
        
        private Amazon.GroundStation.Model.CreateEphemerisResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.CreateEphemerisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "CreateEphemeris");
            try
            {
                return client.CreateEphemerisAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public Amazon.GroundStation.AngleUnits AzElData_AngleUnit { get; set; }
            public List<Amazon.GroundStation.Model.AzElSegment> AzElData_AzElSegmentList { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Key { get; set; }
            public System.String S3Object_Version { get; set; }
            public System.String AzEl_GroundStation { get; set; }
            public System.String Oem_OemData { get; set; }
            public System.String Ephemeris_Oem_S3Object_Bucket { get; set; }
            public System.String Ephemeris_Oem_S3Object_Key { get; set; }
            public System.String Ephemeris_Oem_S3Object_Version { get; set; }
            public System.String Ephemeris_Tle_S3Object_Bucket { get; set; }
            public System.String Ephemeris_Tle_S3Object_Key { get; set; }
            public System.String Ephemeris_Tle_S3Object_Version { get; set; }
            public List<Amazon.GroundStation.Model.TLEData> Tle_TleData { get; set; }
            public System.DateTime? ExpirationTime { get; set; }
            public System.String KmsKeyArn { get; set; }
            public System.String Name { get; set; }
            public System.Int32? Priority { get; set; }
            public System.String SatelliteId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GroundStation.Model.CreateEphemerisResponse, NewGSEphemerisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EphemerisId;
        }
        
    }
}
