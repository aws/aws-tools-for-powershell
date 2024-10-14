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
    /// Creates a place index resource in your Amazon Web Services account. Use a place index
    /// resource to geocode addresses and other text queries by using the <c>SearchPlaceIndexForText</c>
    /// operation, and reverse geocode coordinates by using the <c>SearchPlaceIndexForPosition</c>
    /// operation, and enable autosuggestions by using the <c>SearchPlaceIndexForSuggestions</c>
    /// operation.
    /// 
    ///  <note><para>
    /// If your application is tracking or routing assets you use in your business, such as
    /// delivery vehicles or employees, you must not use Esri as your geolocation provider.
    /// See section 82 of the <a href="http://aws.amazon.com/service-terms">Amazon Web Services
    /// service terms</a> for more details.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "LOCPlaceIndex", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LocationService.Model.CreatePlaceIndexResponse")]
    [AWSCmdlet("Calls the Amazon Location Service CreatePlaceIndex API operation.", Operation = new[] {"CreatePlaceIndex"}, SelectReturnType = typeof(Amazon.LocationService.Model.CreatePlaceIndexResponse))]
    [AWSCmdletOutput("Amazon.LocationService.Model.CreatePlaceIndexResponse",
        "This cmdlet returns an Amazon.LocationService.Model.CreatePlaceIndexResponse object containing multiple properties."
    )]
    public partial class NewLOCPlaceIndexCmdlet : AmazonLocationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataSource
        /// <summary>
        /// <para>
        /// <para>Specifies the geospatial data provider for the new place index.</para><note><para>This field is case-sensitive. Enter the valid values as shown. For example, entering
        /// <c>HERE</c> returns an error.</para></note><para>Valid values include:</para><ul><li><para><c>Esri</c> – For additional information about <a href="https://docs.aws.amazon.com/location/latest/developerguide/esri.html">Esri</a>'s
        /// coverage in your region of interest, see <a href="https://developers.arcgis.com/rest/geocode/api-reference/geocode-coverage.htm">Esri
        /// details on geocoding coverage</a>.</para></li><li><para><c>Grab</c> – Grab provides place index functionality for Southeast Asia. For additional
        /// information about <a href="https://docs.aws.amazon.com/location/latest/developerguide/grab.html">GrabMaps</a>'
        /// coverage, see <a href="https://docs.aws.amazon.com/location/latest/developerguide/grab.html#grab-coverage-area">GrabMaps
        /// countries and areas covered</a>.</para></li><li><para><c>Here</c> – For additional information about <a href="https://docs.aws.amazon.com/location/latest/developerguide/HERE.html">HERE
        /// Technologies</a>' coverage in your region of interest, see <a href="https://developer.here.com/documentation/geocoder/dev_guide/topics/coverage-geocoder.html">HERE
        /// details on goecoding coverage</a>.</para><important><para>If you specify HERE Technologies (<c>Here</c>) as the data provider, you may not <a href="https://docs.aws.amazon.com/location-places/latest/APIReference/API_DataSourceConfiguration.html">store
        /// results</a> for locations in Japan. For more information, see the <a href="http://aws.amazon.com/service-terms/">Amazon
        /// Web Services Service Terms</a> for Amazon Location Service.</para></important></li></ul><para>For additional information , see <a href="https://docs.aws.amazon.com/location/latest/developerguide/what-is-data-provider.html">Data
        /// providers</a> on the <i>Amazon Location Service Developer Guide</i>.</para>
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
        public System.String DataSource { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The optional description for the place index resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IndexName
        /// <summary>
        /// <para>
        /// <para>The name of the place index resource. </para><para>Requirements:</para><ul><li><para>Contain only alphanumeric characters (A–Z, a–z, 0–9), hyphens (-), periods (.), and
        /// underscores (_).</para></li><li><para>Must be a unique place index resource name.</para></li><li><para>No spaces allowed. For example, <c>ExamplePlaceIndex</c>.</para></li></ul>
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
        
        #region Parameter DataSourceConfiguration_IntendedUse
        /// <summary>
        /// <para>
        /// <para>Specifies how the results of an operation will be stored by the caller. </para><para>Valid values include:</para><ul><li><para><c>SingleUse</c> specifies that the results won't be stored. </para></li><li><para><c>Storage</c> specifies that the result can be cached or stored in a database.</para></li></ul><para>Default value: <c>SingleUse</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LocationService.IntendedUse")]
        public Amazon.LocationService.IntendedUse DataSourceConfiguration_IntendedUse { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Applies one or more tags to the place index resource. A tag is a key-value pair that
        /// helps you manage, identify, search, and filter your resources.</para><para>Format: <c>"key" : "value"</c></para><para>Restrictions:</para><ul><li><para>Maximum 50 tags per resource.</para></li><li><para>Each tag key must be unique and must have exactly one associated value.</para></li><li><para>Maximum key length: 128 Unicode characters in UTF-8.</para></li><li><para>Maximum value length: 256 Unicode characters in UTF-8.</para></li><li><para>Can use alphanumeric characters (A–Z, a–z, 0–9), and the following characters: + -
        /// = . _ : / @</para></li><li><para>Cannot use "aws:" as a prefix for a key.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter PricingPlan
        /// <summary>
        /// <para>
        /// <para>No longer used. If included, the only allowed value is <c>RequestBasedUsage</c>.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Deprecated. If included, the only allowed value is RequestBasedUsage.")]
        [AWSConstantClassSource("Amazon.LocationService.PricingPlan")]
        public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LocationService.Model.CreatePlaceIndexResponse).
        /// Specifying the name of a property of type Amazon.LocationService.Model.CreatePlaceIndexResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LOCPlaceIndex (CreatePlaceIndex)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LocationService.Model.CreatePlaceIndexResponse, NewLOCPlaceIndexCmdlet>(Select) ??
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
            context.DataSource = this.DataSource;
            #if MODULAR
            if (this.DataSource == null && ParameterWasBound(nameof(this.DataSource)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSource which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DataSourceConfiguration_IntendedUse = this.DataSourceConfiguration_IntendedUse;
            context.Description = this.Description;
            context.IndexName = this.IndexName;
            #if MODULAR
            if (this.IndexName == null && ParameterWasBound(nameof(this.IndexName)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.PricingPlan = this.PricingPlan;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
            var request = new Amazon.LocationService.Model.CreatePlaceIndexRequest();
            
            if (cmdletContext.DataSource != null)
            {
                request.DataSource = cmdletContext.DataSource;
            }
            
             // populate DataSourceConfiguration
            var requestDataSourceConfigurationIsNull = true;
            request.DataSourceConfiguration = new Amazon.LocationService.Model.DataSourceConfiguration();
            Amazon.LocationService.IntendedUse requestDataSourceConfiguration_dataSourceConfiguration_IntendedUse = null;
            if (cmdletContext.DataSourceConfiguration_IntendedUse != null)
            {
                requestDataSourceConfiguration_dataSourceConfiguration_IntendedUse = cmdletContext.DataSourceConfiguration_IntendedUse;
            }
            if (requestDataSourceConfiguration_dataSourceConfiguration_IntendedUse != null)
            {
                request.DataSourceConfiguration.IntendedUse = requestDataSourceConfiguration_dataSourceConfiguration_IntendedUse;
                requestDataSourceConfigurationIsNull = false;
            }
             // determine if request.DataSourceConfiguration should be set to null
            if (requestDataSourceConfigurationIsNull)
            {
                request.DataSourceConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IndexName != null)
            {
                request.IndexName = cmdletContext.IndexName;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.PricingPlan != null)
            {
                request.PricingPlan = cmdletContext.PricingPlan;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.LocationService.Model.CreatePlaceIndexResponse CallAWSServiceOperation(IAmazonLocationService client, Amazon.LocationService.Model.CreatePlaceIndexRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service", "CreatePlaceIndex");
            try
            {
                #if DESKTOP
                return client.CreatePlaceIndex(request);
                #elif CORECLR
                return client.CreatePlaceIndexAsync(request).GetAwaiter().GetResult();
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
            public System.String DataSource { get; set; }
            public Amazon.LocationService.IntendedUse DataSourceConfiguration_IntendedUse { get; set; }
            public System.String Description { get; set; }
            public System.String IndexName { get; set; }
            [System.ObsoleteAttribute]
            public Amazon.LocationService.PricingPlan PricingPlan { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.LocationService.Model.CreatePlaceIndexResponse, NewLOCPlaceIndexCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
