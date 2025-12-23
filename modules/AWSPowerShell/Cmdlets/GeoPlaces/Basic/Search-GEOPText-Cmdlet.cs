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
using Amazon.GeoPlaces;
using Amazon.GeoPlaces.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GEOP
{
    /// <summary>
    /// <c>SearchText</c> searches for geocode and place information. You can then complete
    /// a follow-up query suggested from the <c>Suggest</c> API via a query id.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/location/latest/developerguide/search-text.html">Search
    /// Text</a> in the <i>Amazon Location Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Search", "GEOPText")]
    [OutputType("Amazon.GeoPlaces.Model.SearchTextResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Places V2 SearchText API operation.", Operation = new[] {"SearchText"}, SelectReturnType = typeof(Amazon.GeoPlaces.Model.SearchTextResponse))]
    [AWSCmdletOutput("Amazon.GeoPlaces.Model.SearchTextResponse",
        "This cmdlet returns an Amazon.GeoPlaces.Model.SearchTextResponse object containing multiple properties."
    )]
    public partial class SearchGEOPTextCmdlet : AmazonGeoPlacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalFeature
        /// <summary>
        /// <para>
        /// <para>A list of optional additional parameters, such as time zone, that can be requested
        /// for each result.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalFeatures")]
        public System.String[] AdditionalFeature { get; set; }
        #endregion
        
        #region Parameter BiasPosition
        /// <summary>
        /// <para>
        /// <para>The position, in longitude and latitude, that the results should be close to. Typically,
        /// place results returned are ranked higher the closer they are to this position. Stored
        /// in <c>[lng, lat]</c> and in the WGS 84 format.</para><note><para>Exactly one of the following fields must be set: <c>BiasPosition</c>, <c>Filter.BoundingBox</c>,
        /// or <c>Filter.Circle</c>.</para></note><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] BiasPosition { get; set; }
        #endregion
        
        #region Parameter Filter_BoundingBox
        /// <summary>
        /// <para>
        /// <para>The bounding box enclosing the geometric shape (area or line) that an individual result
        /// covers.</para><para>The bounding box formed is defined as a set 4 coordinates: <c>[{westward lng}, {southern
        /// lat}, {eastward lng}, {northern lat}]</c></para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] Filter_BoundingBox { get; set; }
        #endregion
        
        #region Parameter Circle_Center
        /// <summary>
        /// <para>
        /// <para>The center position in World Geodetic System (WGS 84) format: [longitude, latitude].</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Circle_Center")]
        public System.Double[] Circle_Center { get; set; }
        #endregion
        
        #region Parameter Filter_IncludeCountry
        /// <summary>
        /// <para>
        /// <para> A list of countries that all results must be in. Countries are represented by either
        /// their alpha-2 or alpha-3 character codes.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_IncludeCountries")]
        public System.String[] Filter_IncludeCountry { get; set; }
        #endregion
        
        #region Parameter IntendedUse
        /// <summary>
        /// <para>
        /// <para>Indicates if the results will be stored. Defaults to <c>SingleUse</c>, if left empty.</para><note><para>Storing the response of an SearchText query is required to comply with service terms,
        /// but charged at a higher cost per request. Please review the <a href="https://aws.amazon.com/location/sla/">user
        /// agreement</a> and <a href="https://aws.amazon.com/location/pricing/">service pricing
        /// structure</a> to determine the correct setting for your use case.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoPlaces.SearchTextIntendedUse")]
        public Amazon.GeoPlaces.SearchTextIntendedUse IntendedUse { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>Optional: The API key to be used for authorization. Either an API key or valid SigV4
        /// signature must be provided when making a request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>A list of <a href="https://en.wikipedia.org/wiki/IETF_language_tag">BCP 47</a> compliant
        /// language codes for the results to be rendered in. If there is no data for the result
        /// in the requested language, data will be returned in the default language for the entry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter PoliticalView
        /// <summary>
        /// <para>
        /// <para>The alpha-2 or alpha-3 character code for the political view of a country. The political
        /// view applies to the results of the request to represent unresolved territorial claims
        /// through the point of view of the specified country.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PoliticalView { get; set; }
        #endregion
        
        #region Parameter QueryId
        /// <summary>
        /// <para>
        /// <para>The query Id returned by the suggest API. If passed in the request, the SearchText
        /// API will preform a SearchText query with the improved query terms for the original
        /// query made to the suggest API.</para><note><para>Exactly one of the following fields must be set: <c>QueryText</c> or <c>QueryId</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryId { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The free-form text query to match addresses against. This is usually a partially typed
        /// address from an end user in an address box or form.</para><note><para>Exactly one of the following fields must be set: <c>QueryText</c> or <c>QueryId</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter Circle_Radius
        /// <summary>
        /// <para>
        /// <para>The radius, in meters, of the <c>FilterCircle</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_Circle_Radius")]
        public System.Int64? Circle_Radius { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional limit for the number of results returned in a single call.</para><para>Default value: 20</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>If <c>nextToken</c> is returned, there are more results available. The value of <c>nextToken</c>
        /// is a unique pagination token for each page. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoPlaces.Model.SearchTextResponse).
        /// Specifying the name of a property of type Amazon.GeoPlaces.Model.SearchTextResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.GeoPlaces.Model.SearchTextResponse, SearchGEOPTextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalFeature != null)
            {
                context.AdditionalFeature = new List<System.String>(this.AdditionalFeature);
            }
            if (this.BiasPosition != null)
            {
                context.BiasPosition = new List<System.Double>(this.BiasPosition);
            }
            if (this.Filter_BoundingBox != null)
            {
                context.Filter_BoundingBox = new List<System.Double>(this.Filter_BoundingBox);
            }
            if (this.Circle_Center != null)
            {
                context.Circle_Center = new List<System.Double>(this.Circle_Center);
            }
            context.Circle_Radius = this.Circle_Radius;
            if (this.Filter_IncludeCountry != null)
            {
                context.Filter_IncludeCountry = new List<System.String>(this.Filter_IncludeCountry);
            }
            context.IntendedUse = this.IntendedUse;
            context.Key = this.Key;
            context.Language = this.Language;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PoliticalView = this.PoliticalView;
            context.QueryId = this.QueryId;
            context.QueryText = this.QueryText;
            
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
            var request = new Amazon.GeoPlaces.Model.SearchTextRequest();
            
            if (cmdletContext.AdditionalFeature != null)
            {
                request.AdditionalFeatures = cmdletContext.AdditionalFeature;
            }
            if (cmdletContext.BiasPosition != null)
            {
                request.BiasPosition = cmdletContext.BiasPosition;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.GeoPlaces.Model.SearchTextFilter();
            List<System.Double> requestFilter_filter_BoundingBox = null;
            if (cmdletContext.Filter_BoundingBox != null)
            {
                requestFilter_filter_BoundingBox = cmdletContext.Filter_BoundingBox;
            }
            if (requestFilter_filter_BoundingBox != null)
            {
                request.Filter.BoundingBox = requestFilter_filter_BoundingBox;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_IncludeCountry = null;
            if (cmdletContext.Filter_IncludeCountry != null)
            {
                requestFilter_filter_IncludeCountry = cmdletContext.Filter_IncludeCountry;
            }
            if (requestFilter_filter_IncludeCountry != null)
            {
                request.Filter.IncludeCountries = requestFilter_filter_IncludeCountry;
                requestFilterIsNull = false;
            }
            Amazon.GeoPlaces.Model.FilterCircle requestFilter_filter_Circle = null;
            
             // populate Circle
            var requestFilter_filter_CircleIsNull = true;
            requestFilter_filter_Circle = new Amazon.GeoPlaces.Model.FilterCircle();
            List<System.Double> requestFilter_filter_Circle_circle_Center = null;
            if (cmdletContext.Circle_Center != null)
            {
                requestFilter_filter_Circle_circle_Center = cmdletContext.Circle_Center;
            }
            if (requestFilter_filter_Circle_circle_Center != null)
            {
                requestFilter_filter_Circle.Center = requestFilter_filter_Circle_circle_Center;
                requestFilter_filter_CircleIsNull = false;
            }
            System.Int64? requestFilter_filter_Circle_circle_Radius = null;
            if (cmdletContext.Circle_Radius != null)
            {
                requestFilter_filter_Circle_circle_Radius = cmdletContext.Circle_Radius.Value;
            }
            if (requestFilter_filter_Circle_circle_Radius != null)
            {
                requestFilter_filter_Circle.Radius = requestFilter_filter_Circle_circle_Radius.Value;
                requestFilter_filter_CircleIsNull = false;
            }
             // determine if requestFilter_filter_Circle should be set to null
            if (requestFilter_filter_CircleIsNull)
            {
                requestFilter_filter_Circle = null;
            }
            if (requestFilter_filter_Circle != null)
            {
                request.Filter.Circle = requestFilter_filter_Circle;
                requestFilterIsNull = false;
            }
             // determine if request.Filter should be set to null
            if (requestFilterIsNull)
            {
                request.Filter = null;
            }
            if (cmdletContext.IntendedUse != null)
            {
                request.IntendedUse = cmdletContext.IntendedUse;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.Language != null)
            {
                request.Language = cmdletContext.Language;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.PoliticalView != null)
            {
                request.PoliticalView = cmdletContext.PoliticalView;
            }
            if (cmdletContext.QueryId != null)
            {
                request.QueryId = cmdletContext.QueryId;
            }
            if (cmdletContext.QueryText != null)
            {
                request.QueryText = cmdletContext.QueryText;
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
        
        private Amazon.GeoPlaces.Model.SearchTextResponse CallAWSServiceOperation(IAmazonGeoPlaces client, Amazon.GeoPlaces.Model.SearchTextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Places V2", "SearchText");
            try
            {
                return client.SearchTextAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AdditionalFeature { get; set; }
            public List<System.Double> BiasPosition { get; set; }
            public List<System.Double> Filter_BoundingBox { get; set; }
            public List<System.Double> Circle_Center { get; set; }
            public System.Int64? Circle_Radius { get; set; }
            public List<System.String> Filter_IncludeCountry { get; set; }
            public Amazon.GeoPlaces.SearchTextIntendedUse IntendedUse { get; set; }
            public System.String Key { get; set; }
            public System.String Language { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PoliticalView { get; set; }
            public System.String QueryId { get; set; }
            public System.String QueryText { get; set; }
            public System.Func<Amazon.GeoPlaces.Model.SearchTextResponse, SearchGEOPTextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
