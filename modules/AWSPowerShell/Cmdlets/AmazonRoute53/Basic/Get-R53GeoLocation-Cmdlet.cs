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
    /// To retrieve a single geo location, send a <code>GET</code> request to the <code>/<i>Route
    /// 53 API version</i>/geolocation</code> resource with one of these options: continentcode
    /// | countrycode | countrycode and subdivisioncode.
    /// </summary>
    [Cmdlet("Get", "R53GeoLocation")]
    [OutputType("Amazon.Route53.Model.GeoLocationDetails")]
    [AWSCmdlet("Invokes the GetGeoLocation operation against Amazon Route 53.", Operation = new[] {"GetGeoLocation"})]
    [AWSCmdletOutput("Amazon.Route53.Model.GeoLocationDetails",
        "This cmdlet returns a GeoLocationDetails object.",
        "The service call response (type Amazon.Route53.Model.GetGeoLocationResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetR53GeoLocationCmdlet : AmazonRoute53ClientCmdlet, IExecutor
    {
        
        #region Parameter ContinentCode
        /// <summary>
        /// <para>
        /// <para>The code for a continent geo location. Note: only continent locations have a continent
        /// code.</para><para>Valid values: <code>AF</code> | <code>AN</code> | <code>AS</code> | <code>EU</code>
        /// | <code>OC</code> | <code>NA</code> | <code>SA</code></para><para>Constraint: Specifying <code>ContinentCode</code> with either <code>CountryCode</code>
        /// or <code>SubdivisionCode</code> returns an <a>InvalidInput</a> error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContinentCode { get; set; }
        #endregion
        
        #region Parameter CountryCode
        /// <summary>
        /// <para>
        /// <para>The code for a country geo location. The default location uses '*' for the country
        /// code and will match all locations that are not matched by a geo location.</para><para>The default geo location uses a <code>*</code> for the country code. All other country
        /// codes follow the ISO 3166 two-character code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CountryCode { get; set; }
        #endregion
        
        #region Parameter SubdivisionCode
        /// <summary>
        /// <para>
        /// <para>The code for a country's subdivision (e.g., a province of Canada). A subdivision code
        /// is only valid with the appropriate country code.</para><para>Constraint: Specifying <code>SubdivisionCode</code> without <code>CountryCode</code>
        /// returns an <a>InvalidInput</a> error.</para>
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
            
            context.ContinentCode = this.ContinentCode;
            context.CountryCode = this.CountryCode;
            context.SubdivisionCode = this.SubdivisionCode;
            
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
        
        private static Amazon.Route53.Model.GetGeoLocationResponse CallAWSServiceOperation(IAmazonRoute53 client, Amazon.Route53.Model.GetGeoLocationRequest request)
        {
            return client.GetGeoLocation(request);
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ContinentCode { get; set; }
            public System.String CountryCode { get; set; }
            public System.String SubdivisionCode { get; set; }
        }
        
    }
}
