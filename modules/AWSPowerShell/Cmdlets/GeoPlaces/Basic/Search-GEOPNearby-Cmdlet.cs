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
using Amazon.GeoPlaces;
using Amazon.GeoPlaces.Model;

namespace Amazon.PowerShell.Cmdlets.GEOP
{
    /// <summary>
    /// <c>SearchNearby</c> queries for points of interest within a radius from a central
    /// coordinates, returning place results with optional filters such as categories, business
    /// chains, food types and more. The API returns details such as a place name, address,
    /// phone, category, food type, contact, opening hours. Also, the API can return phonemes,
    /// time zones and more based on requested parameters.
    /// </summary>
    [Cmdlet("Search", "GEOPNearby", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GeoPlaces.Model.SearchNearbyResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Places V2 SearchNearby API operation.", Operation = new[] {"SearchNearby"}, SelectReturnType = typeof(Amazon.GeoPlaces.Model.SearchNearbyResponse))]
    [AWSCmdletOutput("Amazon.GeoPlaces.Model.SearchNearbyResponse",
        "This cmdlet returns an Amazon.GeoPlaces.Model.SearchNearbyResponse object containing multiple properties."
    )]
    public partial class SearchGEOPNearbyCmdlet : AmazonGeoPlacesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalFeature
        /// <summary>
        /// <para>
        /// <para>A list of optional additional parameters, such as time zone, that can be requested
        /// for each result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalFeatures")]
        public System.String[] AdditionalFeature { get; set; }
        #endregion
        
        #region Parameter Filter_BoundingBox
        /// <summary>
        /// <para>
        /// <para>The bounding box enclosing the geometric shape (area or line) that an individual result
        /// covers.</para><para>The bounding box formed is defined as a set 4 coordinates: <c>[{westward lng}, {southern
        /// lat}, {eastward lng}, {northern lat}]</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] Filter_BoundingBox { get; set; }
        #endregion
        
        #region Parameter Filter_ExcludeBusinessChain
        /// <summary>
        /// <para>
        /// <para>The Business Chains associated with the place.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ExcludeBusinessChains")]
        public System.String[] Filter_ExcludeBusinessChain { get; set; }
        #endregion
        
        #region Parameter Filter_ExcludeCategory
        /// <summary>
        /// <para>
        /// <para>Categories of results that results are excluded from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ExcludeCategories")]
        public System.String[] Filter_ExcludeCategory { get; set; }
        #endregion
        
        #region Parameter Filter_ExcludeFoodType
        /// <summary>
        /// <para>
        /// <para>Food types that results are excluded from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_ExcludeFoodTypes")]
        public System.String[] Filter_ExcludeFoodType { get; set; }
        #endregion
        
        #region Parameter Filter_IncludeBusinessChain
        /// <summary>
        /// <para>
        /// <para>The Business Chains associated with the place.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_IncludeBusinessChains")]
        public System.String[] Filter_IncludeBusinessChain { get; set; }
        #endregion
        
        #region Parameter Filter_IncludeCategory
        /// <summary>
        /// <para>
        /// <para>Categories of results that results must belong too.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_IncludeCategories")]
        public System.String[] Filter_IncludeCategory { get; set; }
        #endregion
        
        #region Parameter Filter_IncludeCountry
        /// <summary>
        /// <para>
        /// <para>A list of countries that all results must be in. Countries are represented by either
        /// their alpha-2 or alpha-3 character codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_IncludeCountries")]
        public System.String[] Filter_IncludeCountry { get; set; }
        #endregion
        
        #region Parameter Filter_IncludeFoodType
        /// <summary>
        /// <para>
        /// <para>Food types that results are included from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_IncludeFoodTypes")]
        public System.String[] Filter_IncludeFoodType { get; set; }
        #endregion
        
        #region Parameter IntendedUse
        /// <summary>
        /// <para>
        /// <para>Indicates if the results will be stored. Defaults to <c>SingleUse</c>, if left empty.</para><note><para>Storing the response of an SearchNearby query is required to comply with service terms,
        /// but charged at a higher cost per request. Please review the <a href="https://aws.amazon.com/location/sla/">user
        /// agreement</a> and <a href="https://aws.amazon.com/location/pricing/">service pricing
        /// structure</a> to determine the correct setting for your use case.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoPlaces.SearchNearbyIntendedUse")]
        public Amazon.GeoPlaces.SearchNearbyIntendedUse IntendedUse { get; set; }
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
        
        #region Parameter QueryPosition
        /// <summary>
        /// <para>
        /// <para>The position, in <c>[lng, lat]</c> for which you are querying nearby results for.
        /// Results closer to the position will be ranked higher then results further away from
        /// the position</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double[] QueryPosition { get; set; }
        #endregion
        
        #region Parameter QueryRadius
        /// <summary>
        /// <para>
        /// <para>The maximum distance in meters from the QueryPosition from which a result will be
        /// returned.</para><note><para>The fields <c>QueryText</c>, and <c>QueryID</c> are mutually exclusive.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? QueryRadius { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional limit for the number of results returned in a single call.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoPlaces.Model.SearchNearbyResponse).
        /// Specifying the name of a property of type Amazon.GeoPlaces.Model.SearchNearbyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueryPosition parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueryPosition' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueryPosition' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueryPosition), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Search-GEOPNearby (SearchNearby)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GeoPlaces.Model.SearchNearbyResponse, SearchGEOPNearbyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueryPosition;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalFeature != null)
            {
                context.AdditionalFeature = new List<System.String>(this.AdditionalFeature);
            }
            if (this.Filter_BoundingBox != null)
            {
                context.Filter_BoundingBox = new List<System.Double>(this.Filter_BoundingBox);
            }
            if (this.Filter_ExcludeBusinessChain != null)
            {
                context.Filter_ExcludeBusinessChain = new List<System.String>(this.Filter_ExcludeBusinessChain);
            }
            if (this.Filter_ExcludeCategory != null)
            {
                context.Filter_ExcludeCategory = new List<System.String>(this.Filter_ExcludeCategory);
            }
            if (this.Filter_ExcludeFoodType != null)
            {
                context.Filter_ExcludeFoodType = new List<System.String>(this.Filter_ExcludeFoodType);
            }
            if (this.Filter_IncludeBusinessChain != null)
            {
                context.Filter_IncludeBusinessChain = new List<System.String>(this.Filter_IncludeBusinessChain);
            }
            if (this.Filter_IncludeCategory != null)
            {
                context.Filter_IncludeCategory = new List<System.String>(this.Filter_IncludeCategory);
            }
            if (this.Filter_IncludeCountry != null)
            {
                context.Filter_IncludeCountry = new List<System.String>(this.Filter_IncludeCountry);
            }
            if (this.Filter_IncludeFoodType != null)
            {
                context.Filter_IncludeFoodType = new List<System.String>(this.Filter_IncludeFoodType);
            }
            context.IntendedUse = this.IntendedUse;
            context.Key = this.Key;
            context.Language = this.Language;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.PoliticalView = this.PoliticalView;
            if (this.QueryPosition != null)
            {
                context.QueryPosition = new List<System.Double>(this.QueryPosition);
            }
            #if MODULAR
            if (this.QueryPosition == null && ParameterWasBound(nameof(this.QueryPosition)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryPosition which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryRadius = this.QueryRadius;
            
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
            var request = new Amazon.GeoPlaces.Model.SearchNearbyRequest();
            
            if (cmdletContext.AdditionalFeature != null)
            {
                request.AdditionalFeatures = cmdletContext.AdditionalFeature;
            }
            
             // populate Filter
            var requestFilterIsNull = true;
            request.Filter = new Amazon.GeoPlaces.Model.SearchNearbyFilter();
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
            List<System.String> requestFilter_filter_ExcludeBusinessChain = null;
            if (cmdletContext.Filter_ExcludeBusinessChain != null)
            {
                requestFilter_filter_ExcludeBusinessChain = cmdletContext.Filter_ExcludeBusinessChain;
            }
            if (requestFilter_filter_ExcludeBusinessChain != null)
            {
                request.Filter.ExcludeBusinessChains = requestFilter_filter_ExcludeBusinessChain;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ExcludeCategory = null;
            if (cmdletContext.Filter_ExcludeCategory != null)
            {
                requestFilter_filter_ExcludeCategory = cmdletContext.Filter_ExcludeCategory;
            }
            if (requestFilter_filter_ExcludeCategory != null)
            {
                request.Filter.ExcludeCategories = requestFilter_filter_ExcludeCategory;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_ExcludeFoodType = null;
            if (cmdletContext.Filter_ExcludeFoodType != null)
            {
                requestFilter_filter_ExcludeFoodType = cmdletContext.Filter_ExcludeFoodType;
            }
            if (requestFilter_filter_ExcludeFoodType != null)
            {
                request.Filter.ExcludeFoodTypes = requestFilter_filter_ExcludeFoodType;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_IncludeBusinessChain = null;
            if (cmdletContext.Filter_IncludeBusinessChain != null)
            {
                requestFilter_filter_IncludeBusinessChain = cmdletContext.Filter_IncludeBusinessChain;
            }
            if (requestFilter_filter_IncludeBusinessChain != null)
            {
                request.Filter.IncludeBusinessChains = requestFilter_filter_IncludeBusinessChain;
                requestFilterIsNull = false;
            }
            List<System.String> requestFilter_filter_IncludeCategory = null;
            if (cmdletContext.Filter_IncludeCategory != null)
            {
                requestFilter_filter_IncludeCategory = cmdletContext.Filter_IncludeCategory;
            }
            if (requestFilter_filter_IncludeCategory != null)
            {
                request.Filter.IncludeCategories = requestFilter_filter_IncludeCategory;
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
            List<System.String> requestFilter_filter_IncludeFoodType = null;
            if (cmdletContext.Filter_IncludeFoodType != null)
            {
                requestFilter_filter_IncludeFoodType = cmdletContext.Filter_IncludeFoodType;
            }
            if (requestFilter_filter_IncludeFoodType != null)
            {
                request.Filter.IncludeFoodTypes = requestFilter_filter_IncludeFoodType;
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
            if (cmdletContext.QueryPosition != null)
            {
                request.QueryPosition = cmdletContext.QueryPosition;
            }
            if (cmdletContext.QueryRadius != null)
            {
                request.QueryRadius = cmdletContext.QueryRadius.Value;
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
        
        private Amazon.GeoPlaces.Model.SearchNearbyResponse CallAWSServiceOperation(IAmazonGeoPlaces client, Amazon.GeoPlaces.Model.SearchNearbyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Places V2", "SearchNearby");
            try
            {
                #if DESKTOP
                return client.SearchNearby(request);
                #elif CORECLR
                return client.SearchNearbyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AdditionalFeature { get; set; }
            public List<System.Double> Filter_BoundingBox { get; set; }
            public List<System.String> Filter_ExcludeBusinessChain { get; set; }
            public List<System.String> Filter_ExcludeCategory { get; set; }
            public List<System.String> Filter_ExcludeFoodType { get; set; }
            public List<System.String> Filter_IncludeBusinessChain { get; set; }
            public List<System.String> Filter_IncludeCategory { get; set; }
            public List<System.String> Filter_IncludeCountry { get; set; }
            public List<System.String> Filter_IncludeFoodType { get; set; }
            public Amazon.GeoPlaces.SearchNearbyIntendedUse IntendedUse { get; set; }
            public System.String Key { get; set; }
            public System.String Language { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String PoliticalView { get; set; }
            public List<System.Double> QueryPosition { get; set; }
            public System.Int64? QueryRadius { get; set; }
            public System.Func<Amazon.GeoPlaces.Model.SearchNearbyResponse, SearchGEOPNearbyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
