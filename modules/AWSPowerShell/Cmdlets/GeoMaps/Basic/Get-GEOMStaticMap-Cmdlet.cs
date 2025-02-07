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
using Amazon.GeoMaps;
using Amazon.GeoMaps.Model;

namespace Amazon.PowerShell.Cmdlets.GEOM
{
    /// <summary>
    /// Provides high-quality static map images with customizable options. You can modify
    /// the map's appearance and overlay additional information. It's an ideal solution for
    /// applications requiring tailored static map snapshots.
    /// </summary>
    [Cmdlet("Get", "GEOMStaticMap")]
    [OutputType("Amazon.GeoMaps.Model.GetStaticMapResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Maps V2 GetStaticMap API operation.", Operation = new[] {"GetStaticMap"}, SelectReturnType = typeof(Amazon.GeoMaps.Model.GetStaticMapResponse))]
    [AWSCmdletOutput("Amazon.GeoMaps.Model.GetStaticMapResponse",
        "This cmdlet returns an Amazon.GeoMaps.Model.GetStaticMapResponse object containing multiple properties."
    )]
    public partial class GetGEOMStaticMapCmdlet : AmazonGeoMapsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BoundedPosition
        /// <summary>
        /// <para>
        /// <para>Takes in two or more pair of coordinates, [Lon, Lat], with each coordinate separated
        /// by a comma. The API will generate an image to encompass all of the provided coordinates.
        /// </para><note><para>Cannot be used with <c>Zoom</c> and or <c>Radius</c></para></note><para>Example: 97.170451,78.039098,99.045536,27.176178</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BoundedPositions")]
        public System.String BoundedPosition { get; set; }
        #endregion
        
        #region Parameter BoundingBox
        /// <summary>
        /// <para>
        /// <para>Takes in two pairs of coordinates, [Lon, Lat], denoting south-westerly and north-easterly
        /// edges of the image. The underlying area becomes the view of the image. </para><para>Example: -123.17075,49.26959,-123.08125,49.31429</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BoundingBox { get; set; }
        #endregion
        
        #region Parameter Center
        /// <summary>
        /// <para>
        /// <para>Takes in a pair of coordinates, [Lon, Lat], which becomes the center point of the
        /// image. This parameter requires that either zoom or radius is set.</para><note><para>Cannot be used with <c>Zoom</c> and or <c>Radius</c></para></note><para>Example: 49.295,-123.108</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Center { get; set; }
        #endregion
        
        #region Parameter CompactOverlay
        /// <summary>
        /// <para>
        /// <para>Takes in a string to draw geometries on the image. The input is a comma separated
        /// format as follows format: <c>[Lon, Lat]</c></para><para>Example: <c>line:-122.407653,37.798557,-122.413291,37.802443;color=%23DD0000;width=7;outline-color=#00DD00;outline-width=5yd|point:-122.40572,37.80004;label=Fog
        /// Hill Market;size=large;text-color=%23DD0000;color=#EE4B2B</c></para><note><para>Currently it supports the following geometry types: point, line and polygon. It does
        /// not support multiPoint , multiLine and multiPolgyon.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CompactOverlay { get; set; }
        #endregion
        
        #region Parameter FileName
        /// <summary>
        /// <para>
        /// <para>The map scaling parameter to size the image, icons, and labels. It follows the pattern
        /// of <c>^map(@2x)?$</c>.</para><para>Example: <c>map, map@2x</c></para>
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
        public System.String FileName { get; set; }
        #endregion
        
        #region Parameter GeoJsonOverlay
        /// <summary>
        /// <para>
        /// <para>Takes in a string to draw geometries on the image. The input is a valid GeoJSON collection
        /// object. </para><para>Example: <c>{"type":"FeatureCollection","features": [{"type":"Feature","geometry":{"type":"MultiPoint","coordinates":
        /// [[-90.076345,51.504107],[-0.074451,51.506892]]},"properties": {"color":"#00DD00"}}]}</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GeoJsonOverlay { get; set; }
        #endregion
        
        #region Parameter Height
        /// <summary>
        /// <para>
        /// <para>Specifies the height of the map image.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Height { get; set; }
        #endregion
        
        #region Parameter Key
        /// <summary>
        /// <para>
        /// <para>Optional: The API key to be used for authorization. Either an API key or valid SigV4
        /// signature must be provided when making a request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Key { get; set; }
        #endregion
        
        #region Parameter Padding
        /// <summary>
        /// <para>
        /// <para>Applies additional space (in pixels) around overlay feature to prevent them from being
        /// cut or obscured.</para><note><para>Value for max and min is determined by:</para><para>Min: <c>1</c></para><para>Max: <c>min(height, width)/4</c></para></note><para>Example: <c>100</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Padding { get; set; }
        #endregion
        
        #region Parameter Radius
        /// <summary>
        /// <para>
        /// <para>Used with center parameter, it specifies the zoom of the image where you can control
        /// it on a granular level. Takes in any value <c>&gt;= 1</c>. </para><para>Example: <c>1500</c></para><note><para>Cannot be used with <c>Zoom</c>.</para></note><para><b>Unit</b>: <c>Meters</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? Radius { get; set; }
        #endregion
        
        #region Parameter ScaleBarUnit
        /// <summary>
        /// <para>
        /// <para>Displays a scale on the bottom right of the map image with the unit specified in the
        /// input. </para><para>Example: <c>KilometersMiles, Miles, Kilometers, MilesKilometers</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoMaps.ScaleBarUnit")]
        public Amazon.GeoMaps.ScaleBarUnit ScaleBarUnit { get; set; }
        #endregion
        
        #region Parameter Style
        /// <summary>
        /// <para>
        /// <para>Style specifies the desired map style for the <c>Style</c> APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GeoMaps.StaticMapStyle")]
        public Amazon.GeoMaps.StaticMapStyle Style { get; set; }
        #endregion
        
        #region Parameter Width
        /// <summary>
        /// <para>
        /// <para>Specifies the width of the map image.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Width { get; set; }
        #endregion
        
        #region Parameter Zoom
        /// <summary>
        /// <para>
        /// <para>Specifies the zoom level of the map image.</para><note><para>Cannot be used with <c>Radius</c>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? Zoom { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoMaps.Model.GetStaticMapResponse).
        /// Specifying the name of a property of type Amazon.GeoMaps.Model.GetStaticMapResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the FileName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^FileName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^FileName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.GeoMaps.Model.GetStaticMapResponse, GetGEOMStaticMapCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.FileName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BoundedPosition = this.BoundedPosition;
            context.BoundingBox = this.BoundingBox;
            context.Center = this.Center;
            context.CompactOverlay = this.CompactOverlay;
            context.FileName = this.FileName;
            #if MODULAR
            if (this.FileName == null && ParameterWasBound(nameof(this.FileName)))
            {
                WriteWarning("You are passing $null as a value for parameter FileName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GeoJsonOverlay = this.GeoJsonOverlay;
            context.Height = this.Height;
            #if MODULAR
            if (this.Height == null && ParameterWasBound(nameof(this.Height)))
            {
                WriteWarning("You are passing $null as a value for parameter Height which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Key = this.Key;
            context.Padding = this.Padding;
            context.Radius = this.Radius;
            context.ScaleBarUnit = this.ScaleBarUnit;
            context.Style = this.Style;
            context.Width = this.Width;
            #if MODULAR
            if (this.Width == null && ParameterWasBound(nameof(this.Width)))
            {
                WriteWarning("You are passing $null as a value for parameter Width which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Zoom = this.Zoom;
            
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
            var request = new Amazon.GeoMaps.Model.GetStaticMapRequest();
            
            if (cmdletContext.BoundedPosition != null)
            {
                request.BoundedPositions = cmdletContext.BoundedPosition;
            }
            if (cmdletContext.BoundingBox != null)
            {
                request.BoundingBox = cmdletContext.BoundingBox;
            }
            if (cmdletContext.Center != null)
            {
                request.Center = cmdletContext.Center;
            }
            if (cmdletContext.CompactOverlay != null)
            {
                request.CompactOverlay = cmdletContext.CompactOverlay;
            }
            if (cmdletContext.FileName != null)
            {
                request.FileName = cmdletContext.FileName;
            }
            if (cmdletContext.GeoJsonOverlay != null)
            {
                request.GeoJsonOverlay = cmdletContext.GeoJsonOverlay;
            }
            if (cmdletContext.Height != null)
            {
                request.Height = cmdletContext.Height.Value;
            }
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.Padding != null)
            {
                request.Padding = cmdletContext.Padding.Value;
            }
            if (cmdletContext.Radius != null)
            {
                request.Radius = cmdletContext.Radius.Value;
            }
            if (cmdletContext.ScaleBarUnit != null)
            {
                request.ScaleBarUnit = cmdletContext.ScaleBarUnit;
            }
            if (cmdletContext.Style != null)
            {
                request.Style = cmdletContext.Style;
            }
            if (cmdletContext.Width != null)
            {
                request.Width = cmdletContext.Width.Value;
            }
            if (cmdletContext.Zoom != null)
            {
                request.Zoom = cmdletContext.Zoom.Value;
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
        
        private Amazon.GeoMaps.Model.GetStaticMapResponse CallAWSServiceOperation(IAmazonGeoMaps client, Amazon.GeoMaps.Model.GetStaticMapRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Maps V2", "GetStaticMap");
            try
            {
                #if DESKTOP
                return client.GetStaticMap(request);
                #elif CORECLR
                return client.GetStaticMapAsync(request).GetAwaiter().GetResult();
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
            public System.String BoundedPosition { get; set; }
            public System.String BoundingBox { get; set; }
            public System.String Center { get; set; }
            public System.String CompactOverlay { get; set; }
            public System.String FileName { get; set; }
            public System.String GeoJsonOverlay { get; set; }
            public System.Int32? Height { get; set; }
            public System.String Key { get; set; }
            public System.Int32? Padding { get; set; }
            public System.Int64? Radius { get; set; }
            public Amazon.GeoMaps.ScaleBarUnit ScaleBarUnit { get; set; }
            public Amazon.GeoMaps.StaticMapStyle Style { get; set; }
            public System.Int32? Width { get; set; }
            public System.Single? Zoom { get; set; }
            public System.Func<Amazon.GeoMaps.Model.GetStaticMapResponse, GetGEOMStaticMapCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
