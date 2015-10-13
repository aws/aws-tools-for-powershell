/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// To retrieve a list of supported geo locations, send a <code>GET</code> request to
    /// the <code>2013-04-01/geolocations</code> resource. The response to this request includes
    /// a <code>GeoLocationDetailsList</code> element with zero, one, or multiple <code>GeoLocationDetails</code>
    /// child elements. The list is sorted by country code, and then subdivision code, followed
    /// by continents at the end of the list. 
    /// 
    ///  
    /// <para>
    ///  By default, the list of geo locations is displayed on a single page. You can control
    /// the length of the page that is displayed by using the <code>MaxItems</code> parameter.
    /// If the list is truncated, <code>IsTruncated</code> will be set to <i>true</i> and
    /// a combination of <code>NextContinentCode, NextCountryCode, NextSubdivisionCode</code>
    /// will be populated. You can pass these as parameters to <code>StartContinentCode, StartCountryCode,
    /// StartSubdivisionCode</code> to control the geo location that the list begins with.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "R53GeoLocations")]
    [OutputType("Amazon.Route53.Model.ListGeoLocationsResponse")]
    [AWSCmdlet("Invokes the ListGeoLocations operation against AWS Route 53.", Operation = new[] {"ListGeoLocations"})]
    [AWSCmdletOutput("Amazon.Route53.Model.ListGeoLocationsResponse",
        "This cmdlet returns a Amazon.Route53.Model.ListGeoLocationsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53GeoLocationsCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The first continent code in the lexicographic ordering of geo locations that you want
        /// the <code>ListGeoLocations</code> request to list. For non-continent geo locations,
        /// this should be null.</para><para>Valid values: <code>AF</code> | <code>AN</code> | <code>AS</code> | <code>EU</code>
        /// | <code>OC</code> | <code>NA</code> | <code>SA</code></para><para>Constraint: Specifying <code>ContinentCode</code> with either <code>CountryCode</code>
        /// or <code>SubdivisionCode</code> returns an <a>InvalidInput</a> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartContinentCode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The first country code in the lexicographic ordering of geo locations that you want
        /// the <code>ListGeoLocations</code> request to list.</para><para>The default geo location uses a <code>*</code> for the country code. All other country
        /// codes follow the ISO 3166 two-character code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartCountryCode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The first subdivision code in the lexicographic ordering of geo locations that you
        /// want the <code>ListGeoLocations</code> request to list.</para><para>Constraint: Specifying <code>SubdivisionCode</code> without <code>CountryCode</code>
        /// returns an <a>InvalidInput</a> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StartSubdivisionCode { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The maximum number of geo locations you want in the response body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int MaxItem { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.StartContinentCode = this.StartContinentCode;
            context.StartCountryCode = this.StartCountryCode;
            context.StartSubdivisionCode = this.StartSubdivisionCode;
            if (ParameterWasBound("MaxItem"))
                context.MaxItems = this.MaxItem;
            
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
            if (cmdletContext.MaxItems != null)
            {
                request.MaxItems = AutoIterationHelpers.ConvertEmitLimitToServiceTypeString(cmdletContext.MaxItems.Value);
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.ListGeoLocations(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String StartContinentCode { get; set; }
            public System.String StartCountryCode { get; set; }
            public System.String StartSubdivisionCode { get; set; }
            public int? MaxItems { get; set; }
        }
        
    }
}
