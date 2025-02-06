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
    /// The <c>Suggest</c> operation finds addresses or place candidates based on incomplete
    /// or misspelled queries. You then select the best query to submit based on the returned
    /// results.
    /// </summary>
    [Cmdlet("Invoke", "GEOPSuggest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.GeoPlaces.Model.SuggestResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Places V2 Suggest API operation.", Operation = new[] {"Suggest"}, SelectReturnType = typeof(Amazon.GeoPlaces.Model.SuggestResponse))]
    [AWSCmdletOutput("Amazon.GeoPlaces.Model.SuggestResponse",
        "This cmdlet returns an Amazon.GeoPlaces.Model.SuggestResponse object containing multiple properties."
    )]
    public partial class InvokeGEOPSuggestCmdlet : AmazonGeoPlacesClientCmdlet, IExecutor
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
        
        #region Parameter BiasPosition
        /// <summary>
        /// <para>
        /// <para>The position, in longitude and latitude, that the results should be close to. Typically,
        /// place results returned are ranked higher the closer they are to this position. Stored
        /// in <c>[lng, lat]</c> and in the WSG84 format.</para><note><para>The fields <c>BiasPosition</c>, <c>FilterBoundingBox</c>, and <c>FilterCircle</c>
        /// are mutually exclusive.</para></note>
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
        /// lat}, {eastward lng}, {northern lat}]</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] Filter_BoundingBox { get; set; }
        #endregion
        
        #region Parameter Circle_Center
        /// <summary>
        /// <para>
        /// <para>The center position, in longitude and latitude, of the <c>FilterCircle</c>.</para>
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
        /// their alpha-2 or alpha-3 character codes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filter_IncludeCountries")]
        public System.String[] Filter_IncludeCountry { get; set; }
        #endregion
        
        #region Parameter IntendedUse
        /// <summary>
        /// <para>
        /// <para>Indicates if the results will be stored. Defaults to <c>SingleUse</c>, if left empty.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoPlaces.SuggestIntendedUse")]
        public Amazon.GeoPlaces.SuggestIntendedUse IntendedUse { get; set; }
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
        
        #region Parameter MaxQueryRefinement
        /// <summary>
        /// <para>
        /// <para>Maximum number of query terms to be returned for use with a search text query.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxQueryRefinements")]
        public System.Int32? MaxQueryRefinement { get; set; }
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
        
        #region Parameter QueryText
        /// <summary>
        /// <para>
        /// <para>The free-form text query to match addresses against. This is usually a partially typed
        /// address from an end user in an address box or form.</para>
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
        /// <para>An optional limit for the number of results returned in a single call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoPlaces.Model.SuggestResponse).
        /// Specifying the name of a property of type Amazon.GeoPlaces.Model.SuggestResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-GEOPSuggest (Suggest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GeoPlaces.Model.SuggestResponse, InvokeGEOPSuggestCmdlet>(Select) ??
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
            context.MaxQueryRefinement = this.MaxQueryRefinement;
            context.MaxResult = this.MaxResult;
            context.PoliticalView = this.PoliticalView;
            context.QueryText = this.QueryText;
            #if MODULAR
            if (this.QueryText == null && ParameterWasBound(nameof(this.QueryText)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryText which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GeoPlaces.Model.SuggestRequest();
            
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
            request.Filter = new Amazon.GeoPlaces.Model.SuggestFilter();
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
            if (cmdletContext.MaxQueryRefinement != null)
            {
                request.MaxQueryRefinements = cmdletContext.MaxQueryRefinement.Value;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.PoliticalView != null)
            {
                request.PoliticalView = cmdletContext.PoliticalView;
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
        
        private Amazon.GeoPlaces.Model.SuggestResponse CallAWSServiceOperation(IAmazonGeoPlaces client, Amazon.GeoPlaces.Model.SuggestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Places V2", "Suggest");
            try
            {
                #if DESKTOP
                return client.Suggest(request);
                #elif CORECLR
                return client.SuggestAsync(request).GetAwaiter().GetResult();
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
            public List<System.Double> Filter_BoundingBox { get; set; }
            public List<System.Double> Circle_Center { get; set; }
            public System.Int64? Circle_Radius { get; set; }
            public List<System.String> Filter_IncludeCountry { get; set; }
            public Amazon.GeoPlaces.SuggestIntendedUse IntendedUse { get; set; }
            public System.String Key { get; set; }
            public System.String Language { get; set; }
            public System.Int32? MaxQueryRefinement { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String PoliticalView { get; set; }
            public System.String QueryText { get; set; }
            public System.Func<Amazon.GeoPlaces.Model.SuggestResponse, InvokeGEOPSuggestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
