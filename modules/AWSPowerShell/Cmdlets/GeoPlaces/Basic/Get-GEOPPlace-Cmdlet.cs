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
using Amazon.GeoPlaces;
using Amazon.GeoPlaces.Model;

namespace Amazon.PowerShell.Cmdlets.GEOP
{
    /// <summary>
    /// Finds a place by its unique ID. A <c>PlaceId</c> is returned by other place operations.
    /// </summary>
    [Cmdlet("Get", "GEOPPlace")]
    [OutputType("Amazon.GeoPlaces.Model.GetPlaceResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Places V2 GetPlace API operation.", Operation = new[] {"GetPlace"}, SelectReturnType = typeof(Amazon.GeoPlaces.Model.GetPlaceResponse))]
    [AWSCmdletOutput("Amazon.GeoPlaces.Model.GetPlaceResponse",
        "This cmdlet returns an Amazon.GeoPlaces.Model.GetPlaceResponse object containing multiple properties."
    )]
    public partial class GetGEOPPlaceCmdlet : AmazonGeoPlacesClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdditionalFeature
        /// <summary>
        /// <para>
        /// <para>A list of optional additional parameters such as time zone that can be requested for
        /// each result.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalFeatures")]
        public System.String[] AdditionalFeature { get; set; }
        #endregion
        
        #region Parameter IntendedUse
        /// <summary>
        /// <para>
        /// <para>Indicates if the results will be stored. Defaults to <c>SingleUse</c>, if left empty.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoPlaces.GetPlaceIntendedUse")]
        public Amazon.GeoPlaces.GetPlaceIntendedUse IntendedUse { get; set; }
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
        
        #region Parameter PlaceId
        /// <summary>
        /// <para>
        /// <para>The <c>PlaceId</c> of the place you wish to receive the information for.</para>
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
        public System.String PlaceId { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoPlaces.Model.GetPlaceResponse).
        /// Specifying the name of a property of type Amazon.GeoPlaces.Model.GetPlaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PlaceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PlaceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PlaceId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GeoPlaces.Model.GetPlaceResponse, GetGEOPPlaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PlaceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AdditionalFeature != null)
            {
                context.AdditionalFeature = new List<System.String>(this.AdditionalFeature);
            }
            context.IntendedUse = this.IntendedUse;
            context.Key = this.Key;
            context.Language = this.Language;
            context.PlaceId = this.PlaceId;
            #if MODULAR
            if (this.PlaceId == null && ParameterWasBound(nameof(this.PlaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter PlaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PoliticalView = this.PoliticalView;
            
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
            var request = new Amazon.GeoPlaces.Model.GetPlaceRequest();
            
            if (cmdletContext.AdditionalFeature != null)
            {
                request.AdditionalFeatures = cmdletContext.AdditionalFeature;
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
            if (cmdletContext.PlaceId != null)
            {
                request.PlaceId = cmdletContext.PlaceId;
            }
            if (cmdletContext.PoliticalView != null)
            {
                request.PoliticalView = cmdletContext.PoliticalView;
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
        
        private Amazon.GeoPlaces.Model.GetPlaceResponse CallAWSServiceOperation(IAmazonGeoPlaces client, Amazon.GeoPlaces.Model.GetPlaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Places V2", "GetPlace");
            try
            {
                #if DESKTOP
                return client.GetPlace(request);
                #elif CORECLR
                return client.GetPlaceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.GeoPlaces.GetPlaceIntendedUse IntendedUse { get; set; }
            public System.String Key { get; set; }
            public System.String Language { get; set; }
            public System.String PlaceId { get; set; }
            public System.String PoliticalView { get; set; }
            public System.Func<Amazon.GeoPlaces.Model.GetPlaceResponse, GetGEOPPlaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
