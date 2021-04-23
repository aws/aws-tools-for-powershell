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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Geocodes free-form text, such as an address, name, city, or region to allow you to
    /// search for Places or points of interest. 
    /// 
    ///  
    /// <para>
    /// Includes the option to apply additional parameters to narrow your list of results.
    /// </para><note><para>
    /// You can search for places near a given position using <code>BiasPosition</code>, or
    /// filter results within a bounding box using <code>FilterBBox</code>. Providing both
    /// parameters simultaneously returns an error.
    /// </para></note>
    /// </summary>
    [Cmdlet("Search", "LOCPlaceIndexForText")]
    [OutputType("Amazon.LocationService.Model.SearchPlaceIndexForTextResponse")]
    [AWSCmdlet("Calls the Amazon Location Service SearchPlaceIndexForText API operation.", Operation = new[] {"SearchPlaceIndexForText"}, SelectReturnType = typeof(Amazon.LocationService.Model.SearchPlaceIndexForTextResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.SearchPlaceIndexForTextResponse",
        "This cmdlet returns an Amazon.LocationService.Model.SearchPlaceIndexForTextResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SearchLOCPlaceIndexForTextCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter BiasPosition
        /// <summary>
        /// <para>
        /// <para>Searches for results closest to the given position. An optional parameter defined
        /// by longitude, and latitude.</para><ul><li><para>The first <code>bias</code> position is the X coordinate, or longitude.</para></li><li><para>The second <code>bias</code> position is the Y coordinate, or latitude. </para></li></ul><para>For example, <code>bias=xLongitude&amp;bias=yLatitude</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] BiasPosition { get; set; }
        #endregion
        
        #region Parameter FilterBBox
        /// <summary>
        /// <para>
        /// <para>Filters the results by returning only Places within the provided bounding box. An
        /// optional parameter.</para><para>The first 2 <code>bbox</code> parameters describe the lower southwest corner:</para><ul><li><para>The first <code>bbox</code> position is the X coordinate or longitude of the lower
        /// southwest corner.</para></li><li><para>The second <code>bbox</code> position is the Y coordinate or latitude of the lower
        /// southwest corner.</para></li></ul><para>For example, <code>bbox=xLongitudeSW&amp;bbox=yLatitudeSW</code>.</para><para>The next <code>bbox</code> parameters describe the upper northeast corner:</para><ul><li><para>The third <code>bbox</code> position is the X coordinate, or longitude of the upper
        /// northeast corner.</para></li><li><para>The fourth <code>bbox</code> position is the Y coordinate, or longitude of the upper
        /// northeast corner.</para></li></ul><para>For example, <code>bbox=xLongitudeNE&amp;bbox=yLatitudeNE</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double[] FilterBBox { get; set; }
        #endregion
        
        #region Parameter FilterCountry
        /// <summary>
        /// <para>
        /// <para>Limits the search to the given a list of countries/regions. An optional parameter.</para><ul><li><para>Use the <a href="https://www.iso.org/iso-3166-country-codes.html">ISO 3166</a> 3-digit
        /// country code. For example, Australia uses three upper-case characters: <code>AUS</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FilterCountries")]
        public System.String[] FilterCountry { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the place index resource you want to use for the search.</para>
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
        public System.String IndexName { get; set; }
        #endregion
        
        #region Parameter Text
        /// <summary>
        /// <para>
        /// <para>The address, name, city, or region to be used in the search. In free-form text format.
        /// For example, <code>123 Any Street</code>.</para>
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
        public System.String Text { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter. The maximum number of results returned per request. </para><para>The default: <code>50</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.SearchPlaceIndexForTextResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.SearchPlaceIndexForTextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the IndexName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^IndexName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^IndexName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.SearchPlaceIndexForTextResponse, SearchLOCPlaceIndexForTextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.IndexName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.BiasPosition != null)
            {
                context.BiasPosition = new List<System.Double>(this.BiasPosition);
            }
            if (this.FilterBBox != null)
            {
                context.FilterBBox = new List<System.Double>(this.FilterBBox);
            }
            if (this.FilterCountry != null)
            {
                context.FilterCountry = new List<System.String>(this.FilterCountry);
            }
            context.IndexName = this.IndexName;
            #if MODULAR
            if (this.IndexName == null && ParameterWasBound(nameof(this.IndexName)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxResult = this.MaxResult;
            context.Text = this.Text;
            #if MODULAR
            if (this.Text == null && ParameterWasBound(nameof(this.Text)))
            {
                WriteWarning("You are passing $null as a value for parameter Text which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.SearchPlaceIndexForTextRequest();
            
            if (cmdletContext.BiasPosition != null)
            {
                request.BiasPosition = cmdletContext.BiasPosition;
            }
            if (cmdletContext.FilterBBox != null)
            {
                request.FilterBBox = cmdletContext.FilterBBox;
            }
            if (cmdletContext.FilterCountry != null)
            {
                request.FilterCountries = cmdletContext.FilterCountry;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.Text != null)
            {
                request.Text = cmdletContext.Text;
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
        
        private Amazon.LocationService.Model.SearchPlaceIndexForTextResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.SearchPlaceIndexForTextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "SearchPlaceIndexForText");
            try
            {
                #if DESKTOP
                return client.SearchPlaceIndexForText(request);
                #elif CORECLR
                return client.SearchPlaceIndexForTextAsync(request).GetAwaiter().GetResult();
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
            public List<System.Double> BiasPosition { get; set; }
            public List<System.Double> FilterBBox { get; set; }
            public List<System.String> FilterCountry { get; set; }
            public System.String IndexName { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String Text { get; set; }
            public System.Func<Amazon.LocationService.Model.SearchPlaceIndexForTextResponse, SearchLOCPlaceIndexForTextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
