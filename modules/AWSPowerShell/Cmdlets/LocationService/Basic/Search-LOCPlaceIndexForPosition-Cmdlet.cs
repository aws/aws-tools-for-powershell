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
using Amazon.LocationService;
using Amazon.LocationService.Model;

namespace Amazon.PowerShell.Cmdlets.LOC
{
    /// <summary>
    /// Reverse geocodes a given coordinate and returns a legible address. Allows you to search
    /// for Places or points of interest near a given position.
    /// </summary>
    [Cmdlet("Search", "LOCPlaceIndexForPosition")]
    [OutputType("Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse")]
    [AWSCmdlet("Calls the Amazon Location Service SearchPlaceIndexForPosition API operation.", Operation = new[] {"SearchPlaceIndexForPosition"}, SelectReturnType = typeof(Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse",
        "This cmdlet returns an Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse object containing multiple properties."
    )]
    public partial class SearchLOCPlaceIndexForPositionCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>The optional <a href="https://docs.aws.amazon.com/location/latest/developerguide/using-apikeys.html">API
        /// key</a> to authorize the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter Language
        /// <summary>
        /// <para>
        /// <para>The preferred language used to return results. The value must be a valid <a href="https://tools.ietf.org/search/bcp47">BCP
        /// 47</a> language tag, for example, <c>en</c> for English.</para><para>This setting affects the languages used in the results, but not the results themselves.
        /// If no language is specified, or not supported for a particular result, the partner
        /// automatically chooses a language for the result.</para><para>For an example, we'll use the Greek language. You search for a location around Athens,
        /// Greece, with the <c>language</c> parameter set to <c>en</c>. The <c>city</c> in the
        /// results will most likely be returned as <c>Athens</c>.</para><para>If you set the <c>language</c> parameter to <c>el</c>, for Greek, then the <c>city</c>
        /// in the results will more likely be returned as <c>Αθήνα</c>.</para><para>If the data provider does not have a value for Greek, the result will be in a language
        /// that the provider does support.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Language { get; set; }
        #endregion
        
        #region Parameter Position
        /// <summary>
        /// <para>
        /// <para>Specifies the longitude and latitude of the position to query.</para><para> This parameter must contain a pair of numbers. The first number represents the X
        /// coordinate, or longitude; the second number represents the Y coordinate, or latitude.</para><para>For example, <c>[-123.1174, 49.2847]</c> represents a position with longitude <c>-123.1174</c>
        /// and latitude <c>49.2847</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double[] Position { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>An optional parameter. The maximum number of results returned per request.</para><para>Default value: <c>50</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse, SearchLOCPlaceIndexForPositionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IndexName = this.IndexName;
            #if MODULAR
            if (this.IndexName == null && ParameterWasBound(nameof(this.IndexName)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Key = this.Key;
            context.Language = this.Language;
            context.MaxResult = this.MaxResult;
            if (this.Position != null)
            {
                context.Position = new List<System.Double>(this.Position);
            }
            #if MODULAR
            if (this.Position == null && ParameterWasBound(nameof(this.Position)))
            {
                WriteWarning("You are passing $null as a value for parameter Position which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LocationService.Model.SearchPlaceIndexForPositionRequest();
            
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
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
            if (cmdletContext.Position != null)
            {
                request.Position = cmdletContext.Position;
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
        
        private Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.SearchPlaceIndexForPositionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "SearchPlaceIndexForPosition");
            try
            {
                #if DESKTOP
                return client.SearchPlaceIndexForPosition(request);
                #elif CORECLR
                return client.SearchPlaceIndexForPositionAsync(request).GetAwaiter().GetResult();
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
            public System.String IndexName { get; set; }
            public System.String Key { get; set; }
            public System.String Language { get; set; }
            public System.Int32? MaxResult { get; set; }
            public List<System.Double> Position { get; set; }
            public System.Func<Amazon.LocationService.Model.SearchPlaceIndexForPositionResponse, SearchLOCPlaceIndexForPositionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
