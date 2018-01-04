/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Gets information about whether a specified geographic location is supported for Amazon
    /// Route 53 geolocation resource record sets.
    /// 
    ///  
    /// <para>
    /// Use the following syntax to determine whether a continent is supported for geolocation:
    /// </para><para><code>GET /2013-04-01/geolocation?ContinentCode=<i>two-letter abbreviation for a
    /// continent</i></code></para><para>
    /// Use the following syntax to determine whether a country is supported for geolocation:
    /// </para><para><code>GET /2013-04-01/geolocation?CountryCode=<i>two-character country code</i></code></para><para>
    /// Use the following syntax to determine whether a subdivision of a country is supported
    /// for geolocation:
    /// </para><para><code>GET /2013-04-01/geolocation?CountryCode=<i>two-character country code</i>&amp;SubdivisionCode=<i>subdivision
    /// code</i></code></para>
    /// </summary>
    [Cmdlet("Get", "R53GeoLocation")]
    [OutputType("Amazon.Route53.Model.GeoLocationDetails")]
    [AWSCmdlet("Calls the Amazon Route 53 GetGeoLocation API operation.", Operation = new[] {"GetGeoLocation"})]
    [AWSCmdletOutput("Amazon.Route53.Model.GeoLocationDetails",
        "This cmdlet returns a GeoLocationDetails object.",
        "The service call response (type Amazon.Route53.Model.GetGeoLocationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetR53GeoLocationCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter ContinentCode
        /// <summary>
        /// <para>
        /// <para>Amazon Route 53 supports the following continent codes:</para><ul><li><para><b>AF</b>: Africa</para></li><li><para><b>AN</b>: Antarctica</para></li><li><para><b>AS</b>: Asia</para></li><li><para><b>EU</b>: Europe</para></li><li><para><b>OC</b>: Oceania</para></li><li><para><b>NA</b>: North America</para></li><li><para><b>SA</b>: South America</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContinentCode { get; set; }
        #endregion
        
        #region Parameter CountryCode
        /// <summary>
        /// <para>
        /// <para>Amazon Route 53 uses the two-letter country codes that are specified in <a href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO
        /// standard 3166-1 alpha-2</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CountryCode { get; set; }
        #endregion
        
        #region Parameter SubdivisionCode
        /// <summary>
        /// <para>
        /// <para>Amazon Route 53 uses the one- to three-letter subdivision codes that are specified
        /// in <a href="https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2">ISO standard 3166-1
        /// alpha-2</a>. Amazon Route 53 doesn't support subdivision codes for all countries.
        /// If you specify <code>SubdivisionCode</code>, you must also specify <code>CountryCode</code>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SubdivisionCode { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ContinentCode = this.ContinentCode;
            context.CountryCode = this.CountryCode;
            context.SubdivisionCode = this.SubdivisionCode;
            
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
            var request = new Amazon.Route53.Model.GetGeoLocationRequest();
            
            if (cmdletContext.ContinentCode != null)
            {
                request.ContinentCode = cmdletContext.ContinentCode;
            }
            if (cmdletContext.CountryCode != null)
            {
                request.CountryCode = cmdletContext.CountryCode;
            }
            if (cmdletContext.SubdivisionCode != null)
            {
                request.SubdivisionCode = cmdletContext.SubdivisionCode;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.GeoLocationDetails;
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
        
        #region AWS Service Operation Call
        
        private Amazon.Route53.Model.GetGeoLocationResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.GetGeoLocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Route 53", "GetGeoLocation");
            try
            {
                #if DESKTOP
                return client.GetGeoLocation(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetGeoLocationAsync(request);
                return task.Result;
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
            public System.String ContinentCode { get; set; }
            public System.String CountryCode { get; set; }
            public System.String SubdivisionCode { get; set; }
        }
        
    }
}
