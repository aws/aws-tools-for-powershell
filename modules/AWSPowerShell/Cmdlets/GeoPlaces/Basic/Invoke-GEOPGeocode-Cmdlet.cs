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
    /// <c>Geocode</c> converts a textual address or place into geographic coordinates. You
    /// can obtain geographic coordinates, address component, and other related information.
    /// It supports flexible queries, including free-form text or structured queries with
    /// components like street names, postal codes, and regions. The Geocode API can also
    /// provide additional features such as time zone information and the inclusion of political
    /// views.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/location/latest/developerguide/geocode.html">Geocode</a>
    /// in the <i>Amazon Location Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Invoke", "GEOPGeocode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GeoPlaces.Model.GeocodeResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Places V2 Geocode API operation.", Operation = new[] {"Geocode"}, SelectReturnType = typeof(Amazon.GeoPlaces.Model.GeocodeResponse))]
    [AWSCmdletOutput("Amazon.GeoPlaces.Model.GeocodeResponse",
        "This cmdlet returns an Amazon.GeoPlaces.Model.GeocodeResponse object containing multiple properties."
    )]
    public partial class InvokeGEOPGeocodeCmdlet : AmazonGeoPlacesClientCmdlet, IExecutor
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
        
        #region Parameter QueryComponents_AddressNumber
        /// <summary>
        /// <para>
        /// <para>The house number or address results should have. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryComponents_AddressNumber { get; set; }
        #endregion
        
        #region Parameter BiasPosition
        /// <summary>
        /// <para>
        /// <para>The position, in longitude and latitude, that the results should be close to. Typically,
        /// place results returned are ranked higher the closer they are to this position. Stored
        /// in <c>[lng, lat]</c> and in the WGS 84 format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] BiasPosition { get; set; }
        #endregion
        
        #region Parameter QueryComponents_Country
        /// <summary>
        /// <para>
        /// <para>The alpha-2 or alpha-3 character code for the country that the results will be present
        /// in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryComponents_Country { get; set; }
        #endregion
        
        #region Parameter QueryComponents_District
        /// <summary>
        /// <para>
        /// <para>The district or division of a city the results should be present in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryComponents_District { get; set; }
        #endregion
        
        #region Parameter Filter_IncludeCountry
        /// <summary>
        /// <para>
        /// <para> A list of countries that all results must be in. Countries are represented by either
        /// their alpha-2 or alpha-3 character codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_IncludeCountries")]
        public System.String[] Filter_IncludeCountry { get; set; }
        #endregion
        
        #region Parameter Filter_IncludePlaceType
        /// <summary>
        /// <para>
        /// <para>The included place types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_IncludePlaceTypes")]
        public System.String[] Filter_IncludePlaceType { get; set; }
        #endregion
        
        #region Parameter IntendedUse
        /// <summary>
        /// <para>
        /// <para>Indicates if the results will be stored. Defaults to <c>SingleUse</c>, if left empty.</para><note><para>Storing the response of an Geocode query is required to comply with service terms,
        /// but charged at a higher cost per request. Please review the <a href="https://aws.amazon.com/location/sla/">user
        /// agreement</a> and <a href="https://aws.amazon.com/location/pricing/">service pricing
        /// structure</a> to determine the correct setting for your use case.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoPlaces.GeocodeIntendedUse")]
        public Amazon.GeoPlaces.GeocodeIntendedUse IntendedUse { get; set; }
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
        
        #region Parameter QueryComponents_Locality
        /// <summary>
        /// <para>
        /// <para>The city or locality results should be present in. </para><para>Example: <c>Vancouver</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryComponents_Locality { get; set; }
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
        
        #region Parameter QueryComponents_PostalCode
        /// <summary>
        /// <para>
        /// <para>An alphanumeric string included in a postal address to facilitate mail sorting, such
        /// as post code, postcode, or ZIP code for which the result should possess. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryComponents_PostalCode { get; set; }
        #endregion
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The free-form text query to match addresses against. This is usually a partially typed
        /// address from an end user in an address box or form.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String QueryText { get; set; }
        #endregion
        
        #region Parameter QueryComponents_Region
        /// <summary>
        /// <para>
        /// <para>The region or state results should be to be present in. </para><para>Example: <c>North Rhine-Westphalia</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryComponents_Region { get; set; }
        #endregion
        
        #region Parameter QueryComponents_Street
        /// <summary>
        /// <para>
        /// <para>The name of the street results should be present in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryComponents_Street { get; set; }
        #endregion
        
        #region Parameter QueryComponents_SubRegion
        /// <summary>
        /// <para>
        /// <para>The sub-region or county for which results should be present in. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String QueryComponents_SubRegion { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoPlaces.Model.GeocodeResponse).
        /// Specifying the name of a property of type Amazon.GeoPlaces.Model.GeocodeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QueryText parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QueryText' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QueryText' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QueryText), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-GEOPGeocode (Geocode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GeoPlaces.Model.GeocodeResponse, InvokeGEOPGeocodeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QueryText;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalFeature != null)
            {
                context.AdditionalFeature = new List<System.String>(this.AdditionalFeature);
            }
            if (this.BiasPosition != null)
            {
                context.BiasPosition = new List<System.Double>(this.BiasPosition);
            }
            if (this.Filter_IncludeCountry != null)
            {
                context.Filter_IncludeCountry = new List<System.String>(this.Filter_IncludeCountry);
            }
            if (this.Filter_IncludePlaceType != null)
            {
                context.Filter_IncludePlaceType = new List<System.String>(this.Filter_IncludePlaceType);
            }
            context.IntendedUse = this.IntendedUse;
            context.Key = this.Key;
            context.Language = this.Language;
            context.MaxResult = this.MaxResult;
            context.PoliticalView = this.PoliticalView;
            context.QueryComponents_AddressNumber = this.QueryComponents_AddressNumber;
            context.QueryComponents_Country = this.QueryComponents_Country;
            context.QueryComponents_District = this.QueryComponents_District;
            context.QueryComponents_Locality = this.QueryComponents_Locality;
            context.QueryComponents_PostalCode = this.QueryComponents_PostalCode;
            context.QueryComponents_Region = this.QueryComponents_Region;
            context.QueryComponents_Street = this.QueryComponents_Street;
            context.QueryComponents_SubRegion = this.QueryComponents_SubRegion;
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
            var request = new Amazon.GeoPlaces.Model.GeocodeRequest();
            
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
            request.Filter = new Amazon.GeoPlaces.Model.GeocodeFilter();
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
            List<System.String> requestFilter_filter_IncludePlaceType = null;
            if (cmdletContext.Filter_IncludePlaceType != null)
            {
                requestFilter_filter_IncludePlaceType = cmdletContext.Filter_IncludePlaceType;
            }
            if (requestFilter_filter_IncludePlaceType != null)
            {
                request.Filter.IncludePlaceTypes = requestFilter_filter_IncludePlaceType;
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
            if (cmdletContext.PoliticalView != null)
            {
                request.PoliticalView = cmdletContext.PoliticalView;
            }
            
             // populate QueryComponents
            var requestQueryComponentsIsNull = true;
            request.QueryComponents = new Amazon.GeoPlaces.Model.GeocodeQueryComponents();
            System.String requestQueryComponents_queryComponents_AddressNumber = null;
            if (cmdletContext.QueryComponents_AddressNumber != null)
            {
                requestQueryComponents_queryComponents_AddressNumber = cmdletContext.QueryComponents_AddressNumber;
            }
            if (requestQueryComponents_queryComponents_AddressNumber != null)
            {
                request.QueryComponents.AddressNumber = requestQueryComponents_queryComponents_AddressNumber;
                requestQueryComponentsIsNull = false;
            }
            System.String requestQueryComponents_queryComponents_Country = null;
            if (cmdletContext.QueryComponents_Country != null)
            {
                requestQueryComponents_queryComponents_Country = cmdletContext.QueryComponents_Country;
            }
            if (requestQueryComponents_queryComponents_Country != null)
            {
                request.QueryComponents.Country = requestQueryComponents_queryComponents_Country;
                requestQueryComponentsIsNull = false;
            }
            System.String requestQueryComponents_queryComponents_District = null;
            if (cmdletContext.QueryComponents_District != null)
            {
                requestQueryComponents_queryComponents_District = cmdletContext.QueryComponents_District;
            }
            if (requestQueryComponents_queryComponents_District != null)
            {
                request.QueryComponents.District = requestQueryComponents_queryComponents_District;
                requestQueryComponentsIsNull = false;
            }
            System.String requestQueryComponents_queryComponents_Locality = null;
            if (cmdletContext.QueryComponents_Locality != null)
            {
                requestQueryComponents_queryComponents_Locality = cmdletContext.QueryComponents_Locality;
            }
            if (requestQueryComponents_queryComponents_Locality != null)
            {
                request.QueryComponents.Locality = requestQueryComponents_queryComponents_Locality;
                requestQueryComponentsIsNull = false;
            }
            System.String requestQueryComponents_queryComponents_PostalCode = null;
            if (cmdletContext.QueryComponents_PostalCode != null)
            {
                requestQueryComponents_queryComponents_PostalCode = cmdletContext.QueryComponents_PostalCode;
            }
            if (requestQueryComponents_queryComponents_PostalCode != null)
            {
                request.QueryComponents.PostalCode = requestQueryComponents_queryComponents_PostalCode;
                requestQueryComponentsIsNull = false;
            }
            System.String requestQueryComponents_queryComponents_Region = null;
            if (cmdletContext.QueryComponents_Region != null)
            {
                requestQueryComponents_queryComponents_Region = cmdletContext.QueryComponents_Region;
            }
            if (requestQueryComponents_queryComponents_Region != null)
            {
                request.QueryComponents.Region = requestQueryComponents_queryComponents_Region;
                requestQueryComponentsIsNull = false;
            }
            System.String requestQueryComponents_queryComponents_Street = null;
            if (cmdletContext.QueryComponents_Street != null)
            {
                requestQueryComponents_queryComponents_Street = cmdletContext.QueryComponents_Street;
            }
            if (requestQueryComponents_queryComponents_Street != null)
            {
                request.QueryComponents.Street = requestQueryComponents_queryComponents_Street;
                requestQueryComponentsIsNull = false;
            }
            System.String requestQueryComponents_queryComponents_SubRegion = null;
            if (cmdletContext.QueryComponents_SubRegion != null)
            {
                requestQueryComponents_queryComponents_SubRegion = cmdletContext.QueryComponents_SubRegion;
            }
            if (requestQueryComponents_queryComponents_SubRegion != null)
            {
                request.QueryComponents.SubRegion = requestQueryComponents_queryComponents_SubRegion;
                requestQueryComponentsIsNull = false;
            }
             // determine if request.QueryComponents should be set to null
            if (requestQueryComponentsIsNull)
            {
                request.QueryComponents = null;
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
        
        private Amazon.GeoPlaces.Model.GeocodeResponse CallAWSServiceOperation(IAmazonGeoPlaces client, Amazon.GeoPlaces.Model.GeocodeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Places V2", "Geocode");
            try
            {
                #if DESKTOP
                return client.Geocode(request);
                #elif CORECLR
                return client.GeocodeAsync(request).GetAwaiter().GetResult();
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
            public List<System.Double> BiasPosition { get; set; }
            public List<System.String> Filter_IncludeCountry { get; set; }
            public List<System.String> Filter_IncludePlaceType { get; set; }
            public Amazon.GeoPlaces.GeocodeIntendedUse IntendedUse { get; set; }
            public System.String Key { get; set; }
            public System.String Language { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String PoliticalView { get; set; }
            public System.String QueryComponents_AddressNumber { get; set; }
            public System.String QueryComponents_Country { get; set; }
            public System.String QueryComponents_District { get; set; }
            public System.String QueryComponents_Locality { get; set; }
            public System.String QueryComponents_PostalCode { get; set; }
            public System.String QueryComponents_Region { get; set; }
            public System.String QueryComponents_Street { get; set; }
            public System.String QueryComponents_SubRegion { get; set; }
            public System.String QueryText { get; set; }
            public System.Func<Amazon.GeoPlaces.Model.GeocodeResponse, InvokeGEOPGeocodeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
