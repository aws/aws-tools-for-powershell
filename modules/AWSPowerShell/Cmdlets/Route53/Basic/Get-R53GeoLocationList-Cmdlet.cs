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
using Amazon.Route53;
using Amazon.Route53.Model;

namespace Amazon.PowerShell.Cmdlets.R53
{
    /// <summary>
    /// Retrieves a list of supported geographic locations.
    /// 
    ///  
    /// <para>
    /// Countries are listed first, and continents are listed last. If Amazon Route 53 supports
    /// subdivisions for a country (for example, states or provinces), the subdivisions for
    /// that country are listed in alphabetical order immediately after the corresponding
    /// country.
    /// </para><para>
    /// Route 53 does not perform authorization for this API because it retrieves information
    /// that is already available to the public.
    /// </para><para>
    /// For a list of supported geolocation codes, see the <a href="https://docs.aws.amazon.com/Route53/latest/APIReference/API_GeoLocation.html">GeoLocation</a>
    /// data type.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53GeoLocationList")]
    [OutputType("Amazon.Route53.Model.ListGeoLocationsResponse")]
    [AWSCmdlet("Calls the Amazon Route 53 ListGeoLocations API operation.", Operation = new[] {"ListGeoLocations"}, SelectReturnType = typeof(Amazon.Route53.Model.ListGeoLocationsResponse), LegacyAlias="Get-R53GeoLocations")]
    [AWSCmdletOutput("Amazon.Route53.Model.ListGeoLocationsResponse",
        "This cmdlet returns an Amazon.Route53.Model.ListGeoLocationsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53GeoLocationListCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter StartContinentCode
        /// <summary>
        /// <para>
        /// <para>The code for the continent with which you want to start listing locations that Amazon
        /// Route 53 supports for geolocation. If Route 53 has already returned a page or more
        /// of results, if <code>IsTruncated</code> is true, and if <code>NextContinentCode</code>
        /// from the previous response has a value, enter that value in <code>startcontinentcode</code>
        /// to return the next page of results.</para><para>Include <code>startcontinentcode</code> only if you want to list continents. Don't
        /// include <code>startcontinentcode</code> when you're listing countries or countries
        /// with their subdivisions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartContinentCode { get; set; }
        #endregion
        
        #region Parameter StartCountryCode
        /// <summary>
        /// <para>
        /// <para>The code for the country with which you want to start listing locations that Amazon
        /// Route 53 supports for geolocation. If Route 53 has already returned a page or more
        /// of results, if <code>IsTruncated</code> is <code>true</code>, and if <code>NextCountryCode</code>
        /// from the previous response has a value, enter that value in <code>startcountrycode</code>
        /// to return the next page of results.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartCountryCode { get; set; }
        #endregion
        
        #region Parameter StartSubdivisionCode
        /// <summary>
        /// <para>
        /// <para>The code for the state of the United States with which you want to start listing locations
        /// that Amazon Route 53 supports for geolocation. If Route 53 has already returned a
        /// page or more of results, if <code>IsTruncated</code> is <code>true</code>, and if
        /// <code>NextSubdivisionCode</code> from the previous response has a value, enter that
        /// value in <code>startsubdivisioncode</code> to return the next page of results.</para><para>To list subdivisions (U.S. states), you must include both <code>startcountrycode</code>
        /// and <code>startsubdivisioncode</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StartSubdivisionCode { get; set; }
        #endregion
        
        #region Parameter MaxItem
        /// <summary>
        /// <para>
        /// <para>(Optional) The maximum number of geolocations to be included in the response body
        /// for this request. If more than <code>maxitems</code> geolocations remain to be listed,
        /// then the value of the <code>IsTruncated</code> element in the response is <code>true</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxItems")]
        public System.String MaxItem { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Route53.Model.ListGeoLocationsResponse).
        /// Specifying the name of a property of type Amazon.Route53.Model.ListGeoLocationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Route53.Model.ListGeoLocationsResponse, GetR53GeoLocationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StartContinentCode = this.StartContinentCode;
            context.StartCountryCode = this.StartCountryCode;
            context.StartSubdivisionCode = this.StartSubdivisionCode;
            context.MaxItem = this.MaxItem;
            
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
            var request = new Amazon.Route53.Model.ListGeoLocationsRequest();
            
            if (cmdletContext.StartContinentCode != null)
            {
                request.StartContinentCode = cmdletContext.StartContinentCode;
            }
            if (cmdletContext.StartCountryCode != null)
            {
                request.StartCountryCode = cmdletContext.StartCountryCode;
            }
            if (cmdletContext.StartSubdivisionCode != null)
            {
                request.StartSubdivisionCode = cmdletContext.StartSubdivisionCode;
            }
            if (cmdletContext.MaxItem != null)
            {
                request.MaxItems = cmdletContext.MaxItem;
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
        
        private Amazon.Route53.Model.ListGeoLocationsResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.ListGeoLocationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "ListGeoLocations");
            try
            {
                #if DESKTOP
                return client.ListGeoLocations(request);
                #elif CORECLR
                return client.ListGeoLocationsAsync(request).GetAwaiter().GetResult();
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
            public System.String StartContinentCode { get; set; }
            public System.String StartCountryCode { get; set; }
            public System.String StartSubdivisionCode { get; set; }
            public System.String MaxItem { get; set; }
            public System.Func<Amazon.Route53.Model.ListGeoLocationsResponse, GetR53GeoLocationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
