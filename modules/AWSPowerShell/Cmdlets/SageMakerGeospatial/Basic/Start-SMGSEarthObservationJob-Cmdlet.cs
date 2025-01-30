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
using Amazon.SageMakerGeospatial;
using Amazon.SageMakerGeospatial.Model;

namespace Amazon.PowerShell.Cmdlets.SMGS
{
    /// <summary>
    /// Use this operation to create an Earth observation job.
    /// </summary>
    [Cmdlet("Start", "SMGSEarthObservationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse")]
    [AWSCmdlet("Calls the SageMaker Geospatial StartEarthObservationJob API operation.", Operation = new[] {"StartEarthObservationJob"}, SelectReturnType = typeof(Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse))]
    [AWSCmdletOutput("Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse",
        "This cmdlet returns an Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse object containing multiple properties."
    )]
    public partial class StartSMGSEarthObservationJobCmdlet : AmazonSageMakerGeospatialClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudRemovalConfig_AlgorithmName
        /// <summary>
        /// <para>
        /// <para>The name of the algorithm used for cloud removal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_CloudRemovalConfig_AlgorithmName")]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.AlgorithmNameCloudRemoval")]
        public Amazon.SageMakerGeospatial.AlgorithmNameCloudRemoval CloudRemovalConfig_AlgorithmName { get; set; }
        #endregion
        
        #region Parameter GeoMosaicConfig_AlgorithmName
        /// <summary>
        /// <para>
        /// <para>The name of the algorithm being used for geomosaic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_GeoMosaicConfig_AlgorithmName")]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.AlgorithmNameGeoMosaic")]
        public Amazon.SageMakerGeospatial.AlgorithmNameGeoMosaic GeoMosaicConfig_AlgorithmName { get; set; }
        #endregion
        
        #region Parameter ResamplingConfig_AlgorithmName
        /// <summary>
        /// <para>
        /// <para>The name of the algorithm used for resampling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_ResamplingConfig_AlgorithmName")]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.AlgorithmNameResampling")]
        public Amazon.SageMakerGeospatial.AlgorithmNameResampling ResamplingConfig_AlgorithmName { get; set; }
        #endregion
        
        #region Parameter JobConfig_CloudMaskingConfig
        /// <summary>
        /// <para>
        /// <para>An object containing information about the job configuration for cloud masking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMakerGeospatial.Model.CloudMaskingConfigInput JobConfig_CloudMaskingConfig { get; set; }
        #endregion
        
        #region Parameter MultiPolygonGeometry_Coordinate
        /// <summary>
        /// <para>
        /// <para>The coordinates of the multipolygon geometry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_Coordinates")]
        public System.Double[][][][] MultiPolygonGeometry_Coordinate { get; set; }
        #endregion
        
        #region Parameter PolygonGeometry_Coordinate
        /// <summary>
        /// <para>
        /// <para>Coordinates representing a Polygon based on the <a href="https://www.rfc-editor.org/rfc/rfc7946#section-3.1.6">GeoJson
        /// spec</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_Coordinates")]
        public System.Double[][][] PolygonGeometry_Coordinate { get; set; }
        #endregion
        
        #region Parameter TimeRangeFilter_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time for the time-range filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_RasterDataCollectionQuery_TimeRangeFilter_EndTime")]
        public System.DateTime? TimeRangeFilter_EndTime { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that you specified for the job.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter TemporalStatisticsConfig_GroupBy
        /// <summary>
        /// <para>
        /// <para>The input for the temporal statistics grouping by time frequency option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_TemporalStatisticsConfig_GroupBy")]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.GroupBy")]
        public Amazon.SageMakerGeospatial.GroupBy TemporalStatisticsConfig_GroupBy { get; set; }
        #endregion
        
        #region Parameter CloudRemovalConfig_InterpolationValue
        /// <summary>
        /// <para>
        /// <para>The interpolation value you provide for cloud removal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_CloudRemovalConfig_InterpolationValue")]
        public System.String CloudRemovalConfig_InterpolationValue { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Key Management Service key ID for server-side encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter JobConfig_LandCoverSegmentationConfig
        /// <summary>
        /// <para>
        /// <para>An object containing information about the job configuration for land cover segmentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SageMakerGeospatial.Model.LandCoverSegmentationConfigInput JobConfig_LandCoverSegmentationConfig { get; set; }
        #endregion
        
        #region Parameter PropertyFilters_LogicalOperator
        /// <summary>
        /// <para>
        /// <para>The Logical Operator used to combine the Property Filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_RasterDataCollectionQuery_PropertyFilters_LogicalOperator")]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.LogicalOperator")]
        public Amazon.SageMakerGeospatial.LogicalOperator PropertyFilters_LogicalOperator { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Earth Observation job.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter CustomIndices_Operation
        /// <summary>
        /// <para>
        /// <para>A list of BandMath indices to compute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_BandMathConfig_CustomIndices_Operations")]
        public Amazon.SageMakerGeospatial.Model.Operation[] CustomIndices_Operation { get; set; }
        #endregion
        
        #region Parameter OutputResolution_Predefined
        /// <summary>
        /// <para>
        /// <para>A string value representing Predefined Output Resolution for a stacking operation.
        /// Allowed values are <c>HIGHEST</c>, <c>LOWEST</c>, and <c>AVERAGE</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_StackConfig_OutputResolution_Predefined")]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.PredefinedResolution")]
        public Amazon.SageMakerGeospatial.PredefinedResolution OutputResolution_Predefined { get; set; }
        #endregion
        
        #region Parameter BandMathConfig_PredefinedIndex
        /// <summary>
        /// <para>
        /// <para>One or many of the supported predefined indices to compute. Allowed values: <c>NDVI</c>,
        /// <c>EVI2</c>, <c>MSAVI</c>, <c>NDWI</c>, <c>NDMI</c>, <c>NDSI</c>, and <c>WDRVI</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_BandMathConfig_PredefinedIndices")]
        public System.String[] BandMathConfig_PredefinedIndex { get; set; }
        #endregion
        
        #region Parameter InputConfig_PreviousEarthObservationJobArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the previous Earth Observation job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InputConfig_PreviousEarthObservationJobArn { get; set; }
        #endregion
        
        #region Parameter PropertyFilters_Property
        /// <summary>
        /// <para>
        /// <para>A list of Property Filters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_RasterDataCollectionQuery_PropertyFilters_Properties")]
        public Amazon.SageMakerGeospatial.Model.PropertyFilter[] PropertyFilters_Property { get; set; }
        #endregion
        
        #region Parameter RasterDataCollectionQuery_RasterDataCollectionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the raster data collection.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_RasterDataCollectionQuery_RasterDataCollectionArn")]
        public System.String RasterDataCollectionQuery_RasterDataCollectionArn { get; set; }
        #endregion
        
        #region Parameter TimeRangeFilter_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time for the time-range filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InputConfig_RasterDataCollectionQuery_TimeRangeFilter_StartTime")]
        public System.DateTime? TimeRangeFilter_StartTime { get; set; }
        #endregion
        
        #region Parameter TemporalStatisticsConfig_Statistic
        /// <summary>
        /// <para>
        /// <para>The list of the statistics method options.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_TemporalStatisticsConfig_Statistics")]
        public System.String[] TemporalStatisticsConfig_Statistic { get; set; }
        #endregion
        
        #region Parameter ZonalStatisticsConfig_Statistic
        /// <summary>
        /// <para>
        /// <para>List of zonal statistics to compute.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_ZonalStatisticsConfig_Statistics")]
        public System.String[] ZonalStatisticsConfig_Statistic { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Each tag consists of a key and a value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter CloudRemovalConfig_TargetBand
        /// <summary>
        /// <para>
        /// <para>TargetBands to be returned in the output of CloudRemoval operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_CloudRemovalConfig_TargetBands")]
        public System.String[] CloudRemovalConfig_TargetBand { get; set; }
        #endregion
        
        #region Parameter GeoMosaicConfig_TargetBand
        /// <summary>
        /// <para>
        /// <para>The target bands for geomosaic.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_GeoMosaicConfig_TargetBands")]
        public System.String[] GeoMosaicConfig_TargetBand { get; set; }
        #endregion
        
        #region Parameter ResamplingConfig_TargetBand
        /// <summary>
        /// <para>
        /// <para>Bands used in the operation. If no target bands are specified, it uses all bands available
        /// in the input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_ResamplingConfig_TargetBands")]
        public System.String[] ResamplingConfig_TargetBand { get; set; }
        #endregion
        
        #region Parameter StackConfig_TargetBand
        /// <summary>
        /// <para>
        /// <para>A list of bands to be stacked in the specified order. When the parameter is not provided,
        /// all the available bands in the data collection are stacked in the alphabetical order
        /// of their asset names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_StackConfig_TargetBands")]
        public System.String[] StackConfig_TargetBand { get; set; }
        #endregion
        
        #region Parameter TemporalStatisticsConfig_TargetBand
        /// <summary>
        /// <para>
        /// <para>The list of target band names for the temporal statistic to calculate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_TemporalStatisticsConfig_TargetBands")]
        public System.String[] TemporalStatisticsConfig_TargetBand { get; set; }
        #endregion
        
        #region Parameter ZonalStatisticsConfig_TargetBand
        /// <summary>
        /// <para>
        /// <para>Bands used in the operation. If no target bands are specified, it uses all bands available
        /// input.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_ZonalStatisticsConfig_TargetBands")]
        public System.String[] ZonalStatisticsConfig_TargetBand { get; set; }
        #endregion
        
        #region Parameter JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit
        /// <summary>
        /// <para>
        /// <para>The units for output resolution of the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.Unit")]
        public Amazon.SageMakerGeospatial.Unit JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit { get; set; }
        #endregion
        
        #region Parameter JobConfig_StackConfig_OutputResolution_UserDefined_Unit
        /// <summary>
        /// <para>
        /// <para>The units for output resolution of the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.Unit")]
        public Amazon.SageMakerGeospatial.Unit JobConfig_StackConfig_OutputResolution_UserDefined_Unit { get; set; }
        #endregion
        
        #region Parameter JobConfig_ResamplingConfig_OutputResolution_UserDefined_Value
        /// <summary>
        /// <para>
        /// <para>The value for output resolution of the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? JobConfig_ResamplingConfig_OutputResolution_UserDefined_Value { get; set; }
        #endregion
        
        #region Parameter JobConfig_StackConfig_OutputResolution_UserDefined_Value
        /// <summary>
        /// <para>
        /// <para>The value for output resolution of the result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? JobConfig_StackConfig_OutputResolution_UserDefined_Value { get; set; }
        #endregion
        
        #region Parameter ZonalStatisticsConfig_ZoneS3Path
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 path pointing to the GeoJSON containing the polygonal zones.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_ZonalStatisticsConfig_ZoneS3Path")]
        public System.String ZonalStatisticsConfig_ZoneS3Path { get; set; }
        #endregion
        
        #region Parameter ZonalStatisticsConfig_ZoneS3PathKmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) or an ID of a Amazon Web Services Key Management Service
        /// (Amazon Web Services KMS) key that Amazon SageMaker uses to decrypt your output artifacts
        /// with Amazon S3 server-side encryption. The SageMaker execution role must have <c>kms:GenerateDataKey</c>
        /// permission.</para><para>The <c>KmsKeyId</c> can be any of the following formats:</para><ul><li><para>// KMS Key ID</para><para><c>"1234abcd-12ab-34cd-56ef-1234567890ab"</c></para></li><li><para>// Amazon Resource Name (ARN) of a KMS Key</para><para><c>"arn:aws:kms:&lt;region&gt;:&lt;account&gt;:key/&lt;key-id-12ab-34cd-56ef-1234567890ab&gt;"</c></para></li></ul><para>For more information about key identifiers, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-id">Key
        /// identifiers (KeyID)</a> in the Amazon Web Services Key Management Service (Amazon
        /// Web Services KMS) documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("JobConfig_ZonalStatisticsConfig_ZoneS3PathKmsKeyId")]
        public System.String ZonalStatisticsConfig_ZoneS3PathKmsKeyId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that guarantees that the call to this API is idempotent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-SMGSEarthObservationJob (StartEarthObservationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse, StartSMGSEarthObservationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InputConfig_PreviousEarthObservationJobArn = this.InputConfig_PreviousEarthObservationJobArn;
            if (this.MultiPolygonGeometry_Coordinate != null)
            {
                context.MultiPolygonGeometry_Coordinate = new List<List<List<List<System.Double>>>>();
                foreach (var innerList in this.MultiPolygonGeometry_Coordinate)
                {
                    var innerListCopy = new List<List<List<System.Double>>>();
                    context.MultiPolygonGeometry_Coordinate.Add(innerListCopy);
                    foreach (var secondInnerList in innerList)
                    {
                        var secondInnerListCopy = new List<List<System.Double>>();
                        innerListCopy.Add(secondInnerListCopy);
                        foreach (var innermostList in secondInnerList)
                        {
                            var innermostListCopy = new List<System.Double>(innermostList);
                            secondInnerListCopy.Add(innermostListCopy);
                        }
                    }
                }
            }
            if (this.PolygonGeometry_Coordinate != null)
            {
                context.PolygonGeometry_Coordinate = new List<List<List<System.Double>>>();
                foreach (var innerList in this.PolygonGeometry_Coordinate)
                {
                    var innerListCopy = new List<List<System.Double>>();
                    context.PolygonGeometry_Coordinate.Add(innerListCopy);
                    foreach (var innermostList in innerList)
                    {
                        var innermostListCopy = new List<System.Double>(innermostList);
                        innerListCopy.Add(innermostListCopy);
                    }
                }
            }
            context.PropertyFilters_LogicalOperator = this.PropertyFilters_LogicalOperator;
            if (this.PropertyFilters_Property != null)
            {
                context.PropertyFilters_Property = new List<Amazon.SageMakerGeospatial.Model.PropertyFilter>(this.PropertyFilters_Property);
            }
            context.RasterDataCollectionQuery_RasterDataCollectionArn = this.RasterDataCollectionQuery_RasterDataCollectionArn;
            context.TimeRangeFilter_EndTime = this.TimeRangeFilter_EndTime;
            context.TimeRangeFilter_StartTime = this.TimeRangeFilter_StartTime;
            if (this.CustomIndices_Operation != null)
            {
                context.CustomIndices_Operation = new List<Amazon.SageMakerGeospatial.Model.Operation>(this.CustomIndices_Operation);
            }
            if (this.BandMathConfig_PredefinedIndex != null)
            {
                context.BandMathConfig_PredefinedIndex = new List<System.String>(this.BandMathConfig_PredefinedIndex);
            }
            context.JobConfig_CloudMaskingConfig = this.JobConfig_CloudMaskingConfig;
            context.CloudRemovalConfig_AlgorithmName = this.CloudRemovalConfig_AlgorithmName;
            context.CloudRemovalConfig_InterpolationValue = this.CloudRemovalConfig_InterpolationValue;
            if (this.CloudRemovalConfig_TargetBand != null)
            {
                context.CloudRemovalConfig_TargetBand = new List<System.String>(this.CloudRemovalConfig_TargetBand);
            }
            context.GeoMosaicConfig_AlgorithmName = this.GeoMosaicConfig_AlgorithmName;
            if (this.GeoMosaicConfig_TargetBand != null)
            {
                context.GeoMosaicConfig_TargetBand = new List<System.String>(this.GeoMosaicConfig_TargetBand);
            }
            context.JobConfig_LandCoverSegmentationConfig = this.JobConfig_LandCoverSegmentationConfig;
            context.ResamplingConfig_AlgorithmName = this.ResamplingConfig_AlgorithmName;
            context.JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit = this.JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit;
            context.JobConfig_ResamplingConfig_OutputResolution_UserDefined_Value = this.JobConfig_ResamplingConfig_OutputResolution_UserDefined_Value;
            if (this.ResamplingConfig_TargetBand != null)
            {
                context.ResamplingConfig_TargetBand = new List<System.String>(this.ResamplingConfig_TargetBand);
            }
            context.OutputResolution_Predefined = this.OutputResolution_Predefined;
            context.JobConfig_StackConfig_OutputResolution_UserDefined_Unit = this.JobConfig_StackConfig_OutputResolution_UserDefined_Unit;
            context.JobConfig_StackConfig_OutputResolution_UserDefined_Value = this.JobConfig_StackConfig_OutputResolution_UserDefined_Value;
            if (this.StackConfig_TargetBand != null)
            {
                context.StackConfig_TargetBand = new List<System.String>(this.StackConfig_TargetBand);
            }
            context.TemporalStatisticsConfig_GroupBy = this.TemporalStatisticsConfig_GroupBy;
            if (this.TemporalStatisticsConfig_Statistic != null)
            {
                context.TemporalStatisticsConfig_Statistic = new List<System.String>(this.TemporalStatisticsConfig_Statistic);
            }
            if (this.TemporalStatisticsConfig_TargetBand != null)
            {
                context.TemporalStatisticsConfig_TargetBand = new List<System.String>(this.TemporalStatisticsConfig_TargetBand);
            }
            if (this.ZonalStatisticsConfig_Statistic != null)
            {
                context.ZonalStatisticsConfig_Statistic = new List<System.String>(this.ZonalStatisticsConfig_Statistic);
            }
            if (this.ZonalStatisticsConfig_TargetBand != null)
            {
                context.ZonalStatisticsConfig_TargetBand = new List<System.String>(this.ZonalStatisticsConfig_TargetBand);
            }
            context.ZonalStatisticsConfig_ZoneS3Path = this.ZonalStatisticsConfig_ZoneS3Path;
            context.ZonalStatisticsConfig_ZoneS3PathKmsKeyId = this.ZonalStatisticsConfig_ZoneS3PathKmsKeyId;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SageMakerGeospatial.Model.StartEarthObservationJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            
             // populate InputConfig
            var requestInputConfigIsNull = true;
            request.InputConfig = new Amazon.SageMakerGeospatial.Model.InputConfigInput();
            System.String requestInputConfig_inputConfig_PreviousEarthObservationJobArn = null;
            if (cmdletContext.InputConfig_PreviousEarthObservationJobArn != null)
            {
                requestInputConfig_inputConfig_PreviousEarthObservationJobArn = cmdletContext.InputConfig_PreviousEarthObservationJobArn;
            }
            if (requestInputConfig_inputConfig_PreviousEarthObservationJobArn != null)
            {
                request.InputConfig.PreviousEarthObservationJobArn = requestInputConfig_inputConfig_PreviousEarthObservationJobArn;
                requestInputConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.RasterDataCollectionQueryInput requestInputConfig_inputConfig_RasterDataCollectionQuery = null;
            
             // populate RasterDataCollectionQuery
            var requestInputConfig_inputConfig_RasterDataCollectionQueryIsNull = true;
            requestInputConfig_inputConfig_RasterDataCollectionQuery = new Amazon.SageMakerGeospatial.Model.RasterDataCollectionQueryInput();
            System.String requestInputConfig_inputConfig_RasterDataCollectionQuery_rasterDataCollectionQuery_RasterDataCollectionArn = null;
            if (cmdletContext.RasterDataCollectionQuery_RasterDataCollectionArn != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_rasterDataCollectionQuery_RasterDataCollectionArn = cmdletContext.RasterDataCollectionQuery_RasterDataCollectionArn;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_rasterDataCollectionQuery_RasterDataCollectionArn != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery.RasterDataCollectionArn = requestInputConfig_inputConfig_RasterDataCollectionQuery_rasterDataCollectionQuery_RasterDataCollectionArn;
                requestInputConfig_inputConfig_RasterDataCollectionQueryIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.AreaOfInterest requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest = null;
            
             // populate AreaOfInterest
            var requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterestIsNull = true;
            requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest = new Amazon.SageMakerGeospatial.Model.AreaOfInterest();
            Amazon.SageMakerGeospatial.Model.AreaOfInterestGeometry requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry = null;
            
             // populate AreaOfInterestGeometry
            var requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometryIsNull = true;
            requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry = new Amazon.SageMakerGeospatial.Model.AreaOfInterestGeometry();
            Amazon.SageMakerGeospatial.Model.MultiPolygonGeometryInput requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry = null;
            
             // populate MultiPolygonGeometry
            var requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometryIsNull = true;
            requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry = new Amazon.SageMakerGeospatial.Model.MultiPolygonGeometryInput();
            List<List<List<List<System.Double>>>> requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_multiPolygonGeometry_Coordinate = null;
            if (cmdletContext.MultiPolygonGeometry_Coordinate != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_multiPolygonGeometry_Coordinate = cmdletContext.MultiPolygonGeometry_Coordinate;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_multiPolygonGeometry_Coordinate != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry.Coordinates = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_multiPolygonGeometry_Coordinate;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometryIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry should be set to null
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometryIsNull)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry = null;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry.MultiPolygonGeometry = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometryIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.PolygonGeometryInput requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry = null;
            
             // populate PolygonGeometry
            var requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometryIsNull = true;
            requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry = new Amazon.SageMakerGeospatial.Model.PolygonGeometryInput();
            List<List<List<System.Double>>> requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_polygonGeometry_Coordinate = null;
            if (cmdletContext.PolygonGeometry_Coordinate != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_polygonGeometry_Coordinate = cmdletContext.PolygonGeometry_Coordinate;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_polygonGeometry_Coordinate != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry.Coordinates = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_polygonGeometry_Coordinate;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometryIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry should be set to null
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometryIsNull)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry = null;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry.PolygonGeometry = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometryIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry should be set to null
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometryIsNull)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry = null;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest.AreaOfInterestGeometry = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest_inputConfig_RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterestIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest should be set to null
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterestIsNull)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest = null;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery.AreaOfInterest = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_AreaOfInterest;
                requestInputConfig_inputConfig_RasterDataCollectionQueryIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.PropertyFilters requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters = null;
            
             // populate PropertyFilters
            var requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFiltersIsNull = true;
            requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters = new Amazon.SageMakerGeospatial.Model.PropertyFilters();
            Amazon.SageMakerGeospatial.LogicalOperator requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters_propertyFilters_LogicalOperator = null;
            if (cmdletContext.PropertyFilters_LogicalOperator != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters_propertyFilters_LogicalOperator = cmdletContext.PropertyFilters_LogicalOperator;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters_propertyFilters_LogicalOperator != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters.LogicalOperator = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters_propertyFilters_LogicalOperator;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFiltersIsNull = false;
            }
            List<Amazon.SageMakerGeospatial.Model.PropertyFilter> requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters_propertyFilters_Property = null;
            if (cmdletContext.PropertyFilters_Property != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters_propertyFilters_Property = cmdletContext.PropertyFilters_Property;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters_propertyFilters_Property != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters.Properties = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters_propertyFilters_Property;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFiltersIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters should be set to null
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFiltersIsNull)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters = null;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery.PropertyFilters = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_PropertyFilters;
                requestInputConfig_inputConfig_RasterDataCollectionQueryIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.TimeRangeFilterInput requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter = null;
            
             // populate TimeRangeFilter
            var requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilterIsNull = true;
            requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter = new Amazon.SageMakerGeospatial.Model.TimeRangeFilterInput();
            System.DateTime? requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_EndTime = null;
            if (cmdletContext.TimeRangeFilter_EndTime != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_EndTime = cmdletContext.TimeRangeFilter_EndTime.Value;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_EndTime != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter.EndTime = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_EndTime.Value;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilterIsNull = false;
            }
            System.DateTime? requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_StartTime = null;
            if (cmdletContext.TimeRangeFilter_StartTime != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_StartTime = cmdletContext.TimeRangeFilter_StartTime.Value;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_StartTime != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter.StartTime = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_StartTime.Value;
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilterIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter should be set to null
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilterIsNull)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter = null;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter != null)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery.TimeRangeFilter = requestInputConfig_inputConfig_RasterDataCollectionQuery_inputConfig_RasterDataCollectionQuery_TimeRangeFilter;
                requestInputConfig_inputConfig_RasterDataCollectionQueryIsNull = false;
            }
             // determine if requestInputConfig_inputConfig_RasterDataCollectionQuery should be set to null
            if (requestInputConfig_inputConfig_RasterDataCollectionQueryIsNull)
            {
                requestInputConfig_inputConfig_RasterDataCollectionQuery = null;
            }
            if (requestInputConfig_inputConfig_RasterDataCollectionQuery != null)
            {
                request.InputConfig.RasterDataCollectionQuery = requestInputConfig_inputConfig_RasterDataCollectionQuery;
                requestInputConfigIsNull = false;
            }
             // determine if request.InputConfig should be set to null
            if (requestInputConfigIsNull)
            {
                request.InputConfig = null;
            }
            
             // populate JobConfig
            var requestJobConfigIsNull = true;
            request.JobConfig = new Amazon.SageMakerGeospatial.Model.JobConfigInput();
            Amazon.SageMakerGeospatial.Model.CloudMaskingConfigInput requestJobConfig_jobConfig_CloudMaskingConfig = null;
            if (cmdletContext.JobConfig_CloudMaskingConfig != null)
            {
                requestJobConfig_jobConfig_CloudMaskingConfig = cmdletContext.JobConfig_CloudMaskingConfig;
            }
            if (requestJobConfig_jobConfig_CloudMaskingConfig != null)
            {
                request.JobConfig.CloudMaskingConfig = requestJobConfig_jobConfig_CloudMaskingConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.LandCoverSegmentationConfigInput requestJobConfig_jobConfig_LandCoverSegmentationConfig = null;
            if (cmdletContext.JobConfig_LandCoverSegmentationConfig != null)
            {
                requestJobConfig_jobConfig_LandCoverSegmentationConfig = cmdletContext.JobConfig_LandCoverSegmentationConfig;
            }
            if (requestJobConfig_jobConfig_LandCoverSegmentationConfig != null)
            {
                request.JobConfig.LandCoverSegmentationConfig = requestJobConfig_jobConfig_LandCoverSegmentationConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.BandMathConfigInput requestJobConfig_jobConfig_BandMathConfig = null;
            
             // populate BandMathConfig
            var requestJobConfig_jobConfig_BandMathConfigIsNull = true;
            requestJobConfig_jobConfig_BandMathConfig = new Amazon.SageMakerGeospatial.Model.BandMathConfigInput();
            List<System.String> requestJobConfig_jobConfig_BandMathConfig_bandMathConfig_PredefinedIndex = null;
            if (cmdletContext.BandMathConfig_PredefinedIndex != null)
            {
                requestJobConfig_jobConfig_BandMathConfig_bandMathConfig_PredefinedIndex = cmdletContext.BandMathConfig_PredefinedIndex;
            }
            if (requestJobConfig_jobConfig_BandMathConfig_bandMathConfig_PredefinedIndex != null)
            {
                requestJobConfig_jobConfig_BandMathConfig.PredefinedIndices = requestJobConfig_jobConfig_BandMathConfig_bandMathConfig_PredefinedIndex;
                requestJobConfig_jobConfig_BandMathConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.CustomIndicesInput requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices = null;
            
             // populate CustomIndices
            var requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndicesIsNull = true;
            requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices = new Amazon.SageMakerGeospatial.Model.CustomIndicesInput();
            List<Amazon.SageMakerGeospatial.Model.Operation> requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices_customIndices_Operation = null;
            if (cmdletContext.CustomIndices_Operation != null)
            {
                requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices_customIndices_Operation = cmdletContext.CustomIndices_Operation;
            }
            if (requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices_customIndices_Operation != null)
            {
                requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices.Operations = requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices_customIndices_Operation;
                requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndicesIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices should be set to null
            if (requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndicesIsNull)
            {
                requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices = null;
            }
            if (requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices != null)
            {
                requestJobConfig_jobConfig_BandMathConfig.CustomIndices = requestJobConfig_jobConfig_BandMathConfig_jobConfig_BandMathConfig_CustomIndices;
                requestJobConfig_jobConfig_BandMathConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_BandMathConfig should be set to null
            if (requestJobConfig_jobConfig_BandMathConfigIsNull)
            {
                requestJobConfig_jobConfig_BandMathConfig = null;
            }
            if (requestJobConfig_jobConfig_BandMathConfig != null)
            {
                request.JobConfig.BandMathConfig = requestJobConfig_jobConfig_BandMathConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.GeoMosaicConfigInput requestJobConfig_jobConfig_GeoMosaicConfig = null;
            
             // populate GeoMosaicConfig
            var requestJobConfig_jobConfig_GeoMosaicConfigIsNull = true;
            requestJobConfig_jobConfig_GeoMosaicConfig = new Amazon.SageMakerGeospatial.Model.GeoMosaicConfigInput();
            Amazon.SageMakerGeospatial.AlgorithmNameGeoMosaic requestJobConfig_jobConfig_GeoMosaicConfig_geoMosaicConfig_AlgorithmName = null;
            if (cmdletContext.GeoMosaicConfig_AlgorithmName != null)
            {
                requestJobConfig_jobConfig_GeoMosaicConfig_geoMosaicConfig_AlgorithmName = cmdletContext.GeoMosaicConfig_AlgorithmName;
            }
            if (requestJobConfig_jobConfig_GeoMosaicConfig_geoMosaicConfig_AlgorithmName != null)
            {
                requestJobConfig_jobConfig_GeoMosaicConfig.AlgorithmName = requestJobConfig_jobConfig_GeoMosaicConfig_geoMosaicConfig_AlgorithmName;
                requestJobConfig_jobConfig_GeoMosaicConfigIsNull = false;
            }
            List<System.String> requestJobConfig_jobConfig_GeoMosaicConfig_geoMosaicConfig_TargetBand = null;
            if (cmdletContext.GeoMosaicConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_GeoMosaicConfig_geoMosaicConfig_TargetBand = cmdletContext.GeoMosaicConfig_TargetBand;
            }
            if (requestJobConfig_jobConfig_GeoMosaicConfig_geoMosaicConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_GeoMosaicConfig.TargetBands = requestJobConfig_jobConfig_GeoMosaicConfig_geoMosaicConfig_TargetBand;
                requestJobConfig_jobConfig_GeoMosaicConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_GeoMosaicConfig should be set to null
            if (requestJobConfig_jobConfig_GeoMosaicConfigIsNull)
            {
                requestJobConfig_jobConfig_GeoMosaicConfig = null;
            }
            if (requestJobConfig_jobConfig_GeoMosaicConfig != null)
            {
                request.JobConfig.GeoMosaicConfig = requestJobConfig_jobConfig_GeoMosaicConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.StackConfigInput requestJobConfig_jobConfig_StackConfig = null;
            
             // populate StackConfig
            var requestJobConfig_jobConfig_StackConfigIsNull = true;
            requestJobConfig_jobConfig_StackConfig = new Amazon.SageMakerGeospatial.Model.StackConfigInput();
            List<System.String> requestJobConfig_jobConfig_StackConfig_stackConfig_TargetBand = null;
            if (cmdletContext.StackConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_StackConfig_stackConfig_TargetBand = cmdletContext.StackConfig_TargetBand;
            }
            if (requestJobConfig_jobConfig_StackConfig_stackConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_StackConfig.TargetBands = requestJobConfig_jobConfig_StackConfig_stackConfig_TargetBand;
                requestJobConfig_jobConfig_StackConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.OutputResolutionStackInput requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution = null;
            
             // populate OutputResolution
            var requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolutionIsNull = true;
            requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution = new Amazon.SageMakerGeospatial.Model.OutputResolutionStackInput();
            Amazon.SageMakerGeospatial.PredefinedResolution requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_outputResolution_Predefined = null;
            if (cmdletContext.OutputResolution_Predefined != null)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_outputResolution_Predefined = cmdletContext.OutputResolution_Predefined;
            }
            if (requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_outputResolution_Predefined != null)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution.Predefined = requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_outputResolution_Predefined;
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolutionIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.UserDefined requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined = null;
            
             // populate UserDefined
            var requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefinedIsNull = true;
            requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined = new Amazon.SageMakerGeospatial.Model.UserDefined();
            Amazon.SageMakerGeospatial.Unit requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined_jobConfig_StackConfig_OutputResolution_UserDefined_Unit = null;
            if (cmdletContext.JobConfig_StackConfig_OutputResolution_UserDefined_Unit != null)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined_jobConfig_StackConfig_OutputResolution_UserDefined_Unit = cmdletContext.JobConfig_StackConfig_OutputResolution_UserDefined_Unit;
            }
            if (requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined_jobConfig_StackConfig_OutputResolution_UserDefined_Unit != null)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined.Unit = requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined_jobConfig_StackConfig_OutputResolution_UserDefined_Unit;
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefinedIsNull = false;
            }
            System.Single? requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined_jobConfig_StackConfig_OutputResolution_UserDefined_Value = null;
            if (cmdletContext.JobConfig_StackConfig_OutputResolution_UserDefined_Value != null)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined_jobConfig_StackConfig_OutputResolution_UserDefined_Value = cmdletContext.JobConfig_StackConfig_OutputResolution_UserDefined_Value.Value;
            }
            if (requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined_jobConfig_StackConfig_OutputResolution_UserDefined_Value != null)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined.Value = requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined_jobConfig_StackConfig_OutputResolution_UserDefined_Value.Value;
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefinedIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined should be set to null
            if (requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefinedIsNull)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined = null;
            }
            if (requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined != null)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution.UserDefined = requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution_jobConfig_StackConfig_OutputResolution_UserDefined;
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolutionIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution should be set to null
            if (requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolutionIsNull)
            {
                requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution = null;
            }
            if (requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution != null)
            {
                requestJobConfig_jobConfig_StackConfig.OutputResolution = requestJobConfig_jobConfig_StackConfig_jobConfig_StackConfig_OutputResolution;
                requestJobConfig_jobConfig_StackConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_StackConfig should be set to null
            if (requestJobConfig_jobConfig_StackConfigIsNull)
            {
                requestJobConfig_jobConfig_StackConfig = null;
            }
            if (requestJobConfig_jobConfig_StackConfig != null)
            {
                request.JobConfig.StackConfig = requestJobConfig_jobConfig_StackConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.CloudRemovalConfigInput requestJobConfig_jobConfig_CloudRemovalConfig = null;
            
             // populate CloudRemovalConfig
            var requestJobConfig_jobConfig_CloudRemovalConfigIsNull = true;
            requestJobConfig_jobConfig_CloudRemovalConfig = new Amazon.SageMakerGeospatial.Model.CloudRemovalConfigInput();
            Amazon.SageMakerGeospatial.AlgorithmNameCloudRemoval requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_AlgorithmName = null;
            if (cmdletContext.CloudRemovalConfig_AlgorithmName != null)
            {
                requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_AlgorithmName = cmdletContext.CloudRemovalConfig_AlgorithmName;
            }
            if (requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_AlgorithmName != null)
            {
                requestJobConfig_jobConfig_CloudRemovalConfig.AlgorithmName = requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_AlgorithmName;
                requestJobConfig_jobConfig_CloudRemovalConfigIsNull = false;
            }
            System.String requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_InterpolationValue = null;
            if (cmdletContext.CloudRemovalConfig_InterpolationValue != null)
            {
                requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_InterpolationValue = cmdletContext.CloudRemovalConfig_InterpolationValue;
            }
            if (requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_InterpolationValue != null)
            {
                requestJobConfig_jobConfig_CloudRemovalConfig.InterpolationValue = requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_InterpolationValue;
                requestJobConfig_jobConfig_CloudRemovalConfigIsNull = false;
            }
            List<System.String> requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_TargetBand = null;
            if (cmdletContext.CloudRemovalConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_TargetBand = cmdletContext.CloudRemovalConfig_TargetBand;
            }
            if (requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_CloudRemovalConfig.TargetBands = requestJobConfig_jobConfig_CloudRemovalConfig_cloudRemovalConfig_TargetBand;
                requestJobConfig_jobConfig_CloudRemovalConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_CloudRemovalConfig should be set to null
            if (requestJobConfig_jobConfig_CloudRemovalConfigIsNull)
            {
                requestJobConfig_jobConfig_CloudRemovalConfig = null;
            }
            if (requestJobConfig_jobConfig_CloudRemovalConfig != null)
            {
                request.JobConfig.CloudRemovalConfig = requestJobConfig_jobConfig_CloudRemovalConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.ResamplingConfigInput requestJobConfig_jobConfig_ResamplingConfig = null;
            
             // populate ResamplingConfig
            var requestJobConfig_jobConfig_ResamplingConfigIsNull = true;
            requestJobConfig_jobConfig_ResamplingConfig = new Amazon.SageMakerGeospatial.Model.ResamplingConfigInput();
            Amazon.SageMakerGeospatial.AlgorithmNameResampling requestJobConfig_jobConfig_ResamplingConfig_resamplingConfig_AlgorithmName = null;
            if (cmdletContext.ResamplingConfig_AlgorithmName != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig_resamplingConfig_AlgorithmName = cmdletContext.ResamplingConfig_AlgorithmName;
            }
            if (requestJobConfig_jobConfig_ResamplingConfig_resamplingConfig_AlgorithmName != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig.AlgorithmName = requestJobConfig_jobConfig_ResamplingConfig_resamplingConfig_AlgorithmName;
                requestJobConfig_jobConfig_ResamplingConfigIsNull = false;
            }
            List<System.String> requestJobConfig_jobConfig_ResamplingConfig_resamplingConfig_TargetBand = null;
            if (cmdletContext.ResamplingConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig_resamplingConfig_TargetBand = cmdletContext.ResamplingConfig_TargetBand;
            }
            if (requestJobConfig_jobConfig_ResamplingConfig_resamplingConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig.TargetBands = requestJobConfig_jobConfig_ResamplingConfig_resamplingConfig_TargetBand;
                requestJobConfig_jobConfig_ResamplingConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.OutputResolutionResamplingInput requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution = null;
            
             // populate OutputResolution
            var requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolutionIsNull = true;
            requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution = new Amazon.SageMakerGeospatial.Model.OutputResolutionResamplingInput();
            Amazon.SageMakerGeospatial.Model.UserDefined requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined = null;
            
             // populate UserDefined
            var requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefinedIsNull = true;
            requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined = new Amazon.SageMakerGeospatial.Model.UserDefined();
            Amazon.SageMakerGeospatial.Unit requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined_jobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit = null;
            if (cmdletContext.JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined_jobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit = cmdletContext.JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit;
            }
            if (requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined_jobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined.Unit = requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined_jobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit;
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefinedIsNull = false;
            }
            System.Single? requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined_jobConfig_ResamplingConfig_OutputResolution_UserDefined_Value = null;
            if (cmdletContext.JobConfig_ResamplingConfig_OutputResolution_UserDefined_Value != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined_jobConfig_ResamplingConfig_OutputResolution_UserDefined_Value = cmdletContext.JobConfig_ResamplingConfig_OutputResolution_UserDefined_Value.Value;
            }
            if (requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined_jobConfig_ResamplingConfig_OutputResolution_UserDefined_Value != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined.Value = requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined_jobConfig_ResamplingConfig_OutputResolution_UserDefined_Value.Value;
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefinedIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined should be set to null
            if (requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefinedIsNull)
            {
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined = null;
            }
            if (requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution.UserDefined = requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution_jobConfig_ResamplingConfig_OutputResolution_UserDefined;
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolutionIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution should be set to null
            if (requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolutionIsNull)
            {
                requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution = null;
            }
            if (requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution != null)
            {
                requestJobConfig_jobConfig_ResamplingConfig.OutputResolution = requestJobConfig_jobConfig_ResamplingConfig_jobConfig_ResamplingConfig_OutputResolution;
                requestJobConfig_jobConfig_ResamplingConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_ResamplingConfig should be set to null
            if (requestJobConfig_jobConfig_ResamplingConfigIsNull)
            {
                requestJobConfig_jobConfig_ResamplingConfig = null;
            }
            if (requestJobConfig_jobConfig_ResamplingConfig != null)
            {
                request.JobConfig.ResamplingConfig = requestJobConfig_jobConfig_ResamplingConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.TemporalStatisticsConfigInput requestJobConfig_jobConfig_TemporalStatisticsConfig = null;
            
             // populate TemporalStatisticsConfig
            var requestJobConfig_jobConfig_TemporalStatisticsConfigIsNull = true;
            requestJobConfig_jobConfig_TemporalStatisticsConfig = new Amazon.SageMakerGeospatial.Model.TemporalStatisticsConfigInput();
            Amazon.SageMakerGeospatial.GroupBy requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_GroupBy = null;
            if (cmdletContext.TemporalStatisticsConfig_GroupBy != null)
            {
                requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_GroupBy = cmdletContext.TemporalStatisticsConfig_GroupBy;
            }
            if (requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_GroupBy != null)
            {
                requestJobConfig_jobConfig_TemporalStatisticsConfig.GroupBy = requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_GroupBy;
                requestJobConfig_jobConfig_TemporalStatisticsConfigIsNull = false;
            }
            List<System.String> requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_Statistic = null;
            if (cmdletContext.TemporalStatisticsConfig_Statistic != null)
            {
                requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_Statistic = cmdletContext.TemporalStatisticsConfig_Statistic;
            }
            if (requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_Statistic != null)
            {
                requestJobConfig_jobConfig_TemporalStatisticsConfig.Statistics = requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_Statistic;
                requestJobConfig_jobConfig_TemporalStatisticsConfigIsNull = false;
            }
            List<System.String> requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_TargetBand = null;
            if (cmdletContext.TemporalStatisticsConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_TargetBand = cmdletContext.TemporalStatisticsConfig_TargetBand;
            }
            if (requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_TemporalStatisticsConfig.TargetBands = requestJobConfig_jobConfig_TemporalStatisticsConfig_temporalStatisticsConfig_TargetBand;
                requestJobConfig_jobConfig_TemporalStatisticsConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_TemporalStatisticsConfig should be set to null
            if (requestJobConfig_jobConfig_TemporalStatisticsConfigIsNull)
            {
                requestJobConfig_jobConfig_TemporalStatisticsConfig = null;
            }
            if (requestJobConfig_jobConfig_TemporalStatisticsConfig != null)
            {
                request.JobConfig.TemporalStatisticsConfig = requestJobConfig_jobConfig_TemporalStatisticsConfig;
                requestJobConfigIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.ZonalStatisticsConfigInput requestJobConfig_jobConfig_ZonalStatisticsConfig = null;
            
             // populate ZonalStatisticsConfig
            var requestJobConfig_jobConfig_ZonalStatisticsConfigIsNull = true;
            requestJobConfig_jobConfig_ZonalStatisticsConfig = new Amazon.SageMakerGeospatial.Model.ZonalStatisticsConfigInput();
            List<System.String> requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_Statistic = null;
            if (cmdletContext.ZonalStatisticsConfig_Statistic != null)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_Statistic = cmdletContext.ZonalStatisticsConfig_Statistic;
            }
            if (requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_Statistic != null)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig.Statistics = requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_Statistic;
                requestJobConfig_jobConfig_ZonalStatisticsConfigIsNull = false;
            }
            List<System.String> requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_TargetBand = null;
            if (cmdletContext.ZonalStatisticsConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_TargetBand = cmdletContext.ZonalStatisticsConfig_TargetBand;
            }
            if (requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_TargetBand != null)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig.TargetBands = requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_TargetBand;
                requestJobConfig_jobConfig_ZonalStatisticsConfigIsNull = false;
            }
            System.String requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_ZoneS3Path = null;
            if (cmdletContext.ZonalStatisticsConfig_ZoneS3Path != null)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_ZoneS3Path = cmdletContext.ZonalStatisticsConfig_ZoneS3Path;
            }
            if (requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_ZoneS3Path != null)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig.ZoneS3Path = requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_ZoneS3Path;
                requestJobConfig_jobConfig_ZonalStatisticsConfigIsNull = false;
            }
            System.String requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_ZoneS3PathKmsKeyId = null;
            if (cmdletContext.ZonalStatisticsConfig_ZoneS3PathKmsKeyId != null)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_ZoneS3PathKmsKeyId = cmdletContext.ZonalStatisticsConfig_ZoneS3PathKmsKeyId;
            }
            if (requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_ZoneS3PathKmsKeyId != null)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig.ZoneS3PathKmsKeyId = requestJobConfig_jobConfig_ZonalStatisticsConfig_zonalStatisticsConfig_ZoneS3PathKmsKeyId;
                requestJobConfig_jobConfig_ZonalStatisticsConfigIsNull = false;
            }
             // determine if requestJobConfig_jobConfig_ZonalStatisticsConfig should be set to null
            if (requestJobConfig_jobConfig_ZonalStatisticsConfigIsNull)
            {
                requestJobConfig_jobConfig_ZonalStatisticsConfig = null;
            }
            if (requestJobConfig_jobConfig_ZonalStatisticsConfig != null)
            {
                request.JobConfig.ZonalStatisticsConfig = requestJobConfig_jobConfig_ZonalStatisticsConfig;
                requestJobConfigIsNull = false;
            }
             // determine if request.JobConfig should be set to null
            if (requestJobConfigIsNull)
            {
                request.JobConfig = null;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse CallAWSServiceOperation(IAmazonSageMakerGeospatial client, Amazon.SageMakerGeospatial.Model.StartEarthObservationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Geospatial", "StartEarthObservationJob");
            try
            {
                #if DESKTOP
                return client.StartEarthObservationJob(request);
                #elif CORECLR
                return client.StartEarthObservationJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String InputConfig_PreviousEarthObservationJobArn { get; set; }
            public List<List<List<List<System.Double>>>> MultiPolygonGeometry_Coordinate { get; set; }
            public List<List<List<System.Double>>> PolygonGeometry_Coordinate { get; set; }
            public Amazon.SageMakerGeospatial.LogicalOperator PropertyFilters_LogicalOperator { get; set; }
            public List<Amazon.SageMakerGeospatial.Model.PropertyFilter> PropertyFilters_Property { get; set; }
            public System.String RasterDataCollectionQuery_RasterDataCollectionArn { get; set; }
            public System.DateTime? TimeRangeFilter_EndTime { get; set; }
            public System.DateTime? TimeRangeFilter_StartTime { get; set; }
            public List<Amazon.SageMakerGeospatial.Model.Operation> CustomIndices_Operation { get; set; }
            public List<System.String> BandMathConfig_PredefinedIndex { get; set; }
            public Amazon.SageMakerGeospatial.Model.CloudMaskingConfigInput JobConfig_CloudMaskingConfig { get; set; }
            public Amazon.SageMakerGeospatial.AlgorithmNameCloudRemoval CloudRemovalConfig_AlgorithmName { get; set; }
            public System.String CloudRemovalConfig_InterpolationValue { get; set; }
            public List<System.String> CloudRemovalConfig_TargetBand { get; set; }
            public Amazon.SageMakerGeospatial.AlgorithmNameGeoMosaic GeoMosaicConfig_AlgorithmName { get; set; }
            public List<System.String> GeoMosaicConfig_TargetBand { get; set; }
            public Amazon.SageMakerGeospatial.Model.LandCoverSegmentationConfigInput JobConfig_LandCoverSegmentationConfig { get; set; }
            public Amazon.SageMakerGeospatial.AlgorithmNameResampling ResamplingConfig_AlgorithmName { get; set; }
            public Amazon.SageMakerGeospatial.Unit JobConfig_ResamplingConfig_OutputResolution_UserDefined_Unit { get; set; }
            public System.Single? JobConfig_ResamplingConfig_OutputResolution_UserDefined_Value { get; set; }
            public List<System.String> ResamplingConfig_TargetBand { get; set; }
            public Amazon.SageMakerGeospatial.PredefinedResolution OutputResolution_Predefined { get; set; }
            public Amazon.SageMakerGeospatial.Unit JobConfig_StackConfig_OutputResolution_UserDefined_Unit { get; set; }
            public System.Single? JobConfig_StackConfig_OutputResolution_UserDefined_Value { get; set; }
            public List<System.String> StackConfig_TargetBand { get; set; }
            public Amazon.SageMakerGeospatial.GroupBy TemporalStatisticsConfig_GroupBy { get; set; }
            public List<System.String> TemporalStatisticsConfig_Statistic { get; set; }
            public List<System.String> TemporalStatisticsConfig_TargetBand { get; set; }
            public List<System.String> ZonalStatisticsConfig_Statistic { get; set; }
            public List<System.String> ZonalStatisticsConfig_TargetBand { get; set; }
            public System.String ZonalStatisticsConfig_ZoneS3Path { get; set; }
            public System.String ZonalStatisticsConfig_ZoneS3PathKmsKeyId { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SageMakerGeospatial.Model.StartEarthObservationJobResponse, StartSMGSEarthObservationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
