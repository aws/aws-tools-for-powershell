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
using Amazon.SageMakerGeospatial;
using Amazon.SageMakerGeospatial.Model;

namespace Amazon.PowerShell.Cmdlets.SMGS
{
    /// <summary>
    /// Allows you run image query on a specific raster data collection to get a list of the
    /// satellite imagery matching the selected filters.
    /// </summary>
    [Cmdlet("Search", "SMGSRasterDataCollection", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse")]
    [AWSCmdlet("Calls the SageMaker Geospatial SearchRasterDataCollection API operation.", Operation = new[] {"SearchRasterDataCollection"}, SelectReturnType = typeof(Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse))]
    [AWSCmdletOutput("Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse",
        "This cmdlet returns an Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchSMGSRasterDataCollectionCmdlet : AmazonSageMakerGeospatialClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the raster data collection.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter RasterDataCollectionQuery_BandFilter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] RasterDataCollectionQuery_BandFilter { get; set; }
        #endregion
        
        #region Parameter MultiPolygonGeometry_Coordinate
        /// <summary>
        /// <para>
        /// <para>The coordinates of the multipolygon geometry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_Coordinates")]
        public System.Double[][][][] MultiPolygonGeometry_Coordinate { get; set; }
        #endregion
        
        #region Parameter PolygonGeometry_Coordinate
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_Coordinates")]
        public System.Double[][][] PolygonGeometry_Coordinate { get; set; }
        #endregion
        
        #region Parameter TimeRangeFilter_EndTime
        /// <summary>
        /// <para>
        /// <para>The end time for the time-range filter.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RasterDataCollectionQuery_TimeRangeFilter_EndTime")]
        public System.DateTime? TimeRangeFilter_EndTime { get; set; }
        #endregion
        
        #region Parameter PropertyFilters_LogicalOperator
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RasterDataCollectionQuery_PropertyFilters_LogicalOperator")]
        [AWSConstantClassSource("Amazon.SageMakerGeospatial.LogicalOperator")]
        public Amazon.SageMakerGeospatial.LogicalOperator PropertyFilters_LogicalOperator { get; set; }
        #endregion
        
        #region Parameter PropertyFilters_Property
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RasterDataCollectionQuery_PropertyFilters_Properties")]
        public Amazon.SageMakerGeospatial.Model.PropertyFilter[] PropertyFilters_Property { get; set; }
        #endregion
        
        #region Parameter TimeRangeFilter_StartTime
        /// <summary>
        /// <para>
        /// <para>The start time for the time-range filter.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RasterDataCollectionQuery_TimeRangeFilter_StartTime")]
        public System.DateTime? TimeRangeFilter_StartTime { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If the previous response was truncated, you receive this token. Use it in your next
        /// request to receive the next set of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse).
        /// Specifying the name of a property of type Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-SMGSRasterDataCollection (SearchRasterDataCollection)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse, SearchSMGSRasterDataCollectionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NextToken = this.NextToken;
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
            if (this.RasterDataCollectionQuery_BandFilter != null)
            {
                context.RasterDataCollectionQuery_BandFilter = new List<System.String>(this.RasterDataCollectionQuery_BandFilter);
            }
            context.PropertyFilters_LogicalOperator = this.PropertyFilters_LogicalOperator;
            if (this.PropertyFilters_Property != null)
            {
                context.PropertyFilters_Property = new List<Amazon.SageMakerGeospatial.Model.PropertyFilter>(this.PropertyFilters_Property);
            }
            context.TimeRangeFilter_EndTime = this.TimeRangeFilter_EndTime;
            #if MODULAR
            if (this.TimeRangeFilter_EndTime == null && ParameterWasBound(nameof(this.TimeRangeFilter_EndTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeRangeFilter_EndTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TimeRangeFilter_StartTime = this.TimeRangeFilter_StartTime;
            #if MODULAR
            if (this.TimeRangeFilter_StartTime == null && ParameterWasBound(nameof(this.TimeRangeFilter_StartTime)))
            {
                WriteWarning("You are passing $null as a value for parameter TimeRangeFilter_StartTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            
             // populate RasterDataCollectionQuery
            var requestRasterDataCollectionQueryIsNull = true;
            request.RasterDataCollectionQuery = new Amazon.SageMakerGeospatial.Model.RasterDataCollectionQueryWithBandFilterInput();
            List<System.String> requestRasterDataCollectionQuery_rasterDataCollectionQuery_BandFilter = null;
            if (cmdletContext.RasterDataCollectionQuery_BandFilter != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_BandFilter = cmdletContext.RasterDataCollectionQuery_BandFilter;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_BandFilter != null)
            {
                request.RasterDataCollectionQuery.BandFilter = requestRasterDataCollectionQuery_rasterDataCollectionQuery_BandFilter;
                requestRasterDataCollectionQueryIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.AreaOfInterest requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest = null;
            
             // populate AreaOfInterest
            var requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterestIsNull = true;
            requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest = new Amazon.SageMakerGeospatial.Model.AreaOfInterest();
            Amazon.SageMakerGeospatial.Model.AreaOfInterestGeometry requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry = null;
            
             // populate AreaOfInterestGeometry
            var requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometryIsNull = true;
            requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry = new Amazon.SageMakerGeospatial.Model.AreaOfInterestGeometry();
            Amazon.SageMakerGeospatial.Model.MultiPolygonGeometryInput requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry = null;
            
             // populate MultiPolygonGeometry
            var requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometryIsNull = true;
            requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry = new Amazon.SageMakerGeospatial.Model.MultiPolygonGeometryInput();
            List<List<List<List<System.Double>>>> requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_multiPolygonGeometry_Coordinate = null;
            if (cmdletContext.MultiPolygonGeometry_Coordinate != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_multiPolygonGeometry_Coordinate = cmdletContext.MultiPolygonGeometry_Coordinate;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_multiPolygonGeometry_Coordinate != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry.Coordinates = requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry_multiPolygonGeometry_Coordinate;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometryIsNull = false;
            }
             // determine if requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry should be set to null
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometryIsNull)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry = null;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry.MultiPolygonGeometry = requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_MultiPolygonGeometry;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometryIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.PolygonGeometryInput requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry = null;
            
             // populate PolygonGeometry
            var requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometryIsNull = true;
            requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry = new Amazon.SageMakerGeospatial.Model.PolygonGeometryInput();
            List<List<List<System.Double>>> requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_polygonGeometry_Coordinate = null;
            if (cmdletContext.PolygonGeometry_Coordinate != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_polygonGeometry_Coordinate = cmdletContext.PolygonGeometry_Coordinate;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_polygonGeometry_Coordinate != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry.Coordinates = requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry_polygonGeometry_Coordinate;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometryIsNull = false;
            }
             // determine if requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry should be set to null
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometryIsNull)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry = null;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry.PolygonGeometry = requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry_PolygonGeometry;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometryIsNull = false;
            }
             // determine if requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry should be set to null
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometryIsNull)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry = null;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest.AreaOfInterestGeometry = requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest_rasterDataCollectionQuery_AreaOfInterest_AreaOfInterestGeometry;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterestIsNull = false;
            }
             // determine if requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest should be set to null
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterestIsNull)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest = null;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest != null)
            {
                request.RasterDataCollectionQuery.AreaOfInterest = requestRasterDataCollectionQuery_rasterDataCollectionQuery_AreaOfInterest;
                requestRasterDataCollectionQueryIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.PropertyFilters requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters = null;
            
             // populate PropertyFilters
            var requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFiltersIsNull = true;
            requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters = new Amazon.SageMakerGeospatial.Model.PropertyFilters();
            Amazon.SageMakerGeospatial.LogicalOperator requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters_propertyFilters_LogicalOperator = null;
            if (cmdletContext.PropertyFilters_LogicalOperator != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters_propertyFilters_LogicalOperator = cmdletContext.PropertyFilters_LogicalOperator;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters_propertyFilters_LogicalOperator != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters.LogicalOperator = requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters_propertyFilters_LogicalOperator;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFiltersIsNull = false;
            }
            List<Amazon.SageMakerGeospatial.Model.PropertyFilter> requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters_propertyFilters_Property = null;
            if (cmdletContext.PropertyFilters_Property != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters_propertyFilters_Property = cmdletContext.PropertyFilters_Property;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters_propertyFilters_Property != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters.Properties = requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters_propertyFilters_Property;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFiltersIsNull = false;
            }
             // determine if requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters should be set to null
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFiltersIsNull)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters = null;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters != null)
            {
                request.RasterDataCollectionQuery.PropertyFilters = requestRasterDataCollectionQuery_rasterDataCollectionQuery_PropertyFilters;
                requestRasterDataCollectionQueryIsNull = false;
            }
            Amazon.SageMakerGeospatial.Model.TimeRangeFilterInput requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter = null;
            
             // populate TimeRangeFilter
            var requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilterIsNull = true;
            requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter = new Amazon.SageMakerGeospatial.Model.TimeRangeFilterInput();
            System.DateTime? requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_EndTime = null;
            if (cmdletContext.TimeRangeFilter_EndTime != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_EndTime = cmdletContext.TimeRangeFilter_EndTime.Value;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_EndTime != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter.EndTime = requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_EndTime.Value;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilterIsNull = false;
            }
            System.DateTime? requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_StartTime = null;
            if (cmdletContext.TimeRangeFilter_StartTime != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_StartTime = cmdletContext.TimeRangeFilter_StartTime.Value;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_StartTime != null)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter.StartTime = requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter_timeRangeFilter_StartTime.Value;
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilterIsNull = false;
            }
             // determine if requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter should be set to null
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilterIsNull)
            {
                requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter = null;
            }
            if (requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter != null)
            {
                request.RasterDataCollectionQuery.TimeRangeFilter = requestRasterDataCollectionQuery_rasterDataCollectionQuery_TimeRangeFilter;
                requestRasterDataCollectionQueryIsNull = false;
            }
             // determine if request.RasterDataCollectionQuery should be set to null
            if (requestRasterDataCollectionQueryIsNull)
            {
                request.RasterDataCollectionQuery = null;
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
        
        private Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse CallAWSServiceOperation(IAmazonSageMakerGeospatial client, Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "SageMaker Geospatial", "SearchRasterDataCollection");
            try
            {
                #if DESKTOP
                return client.SearchRasterDataCollection(request);
                #elif CORECLR
                return client.SearchRasterDataCollectionAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String NextToken { get; set; }
            public List<List<List<List<System.Double>>>> MultiPolygonGeometry_Coordinate { get; set; }
            public List<List<List<System.Double>>> PolygonGeometry_Coordinate { get; set; }
            public List<System.String> RasterDataCollectionQuery_BandFilter { get; set; }
            public Amazon.SageMakerGeospatial.LogicalOperator PropertyFilters_LogicalOperator { get; set; }
            public List<Amazon.SageMakerGeospatial.Model.PropertyFilter> PropertyFilters_Property { get; set; }
            public System.DateTime? TimeRangeFilter_EndTime { get; set; }
            public System.DateTime? TimeRangeFilter_StartTime { get; set; }
            public System.Func<Amazon.SageMakerGeospatial.Model.SearchRasterDataCollectionResponse, SearchSMGSRasterDataCollectionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
