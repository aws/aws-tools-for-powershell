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
    /// <c>GetTile</c> returns a tile. Map tiles are used by clients to render a map. they're
    /// addressed using a grid arrangement with an X coordinate, Y coordinate, and Z (zoom)
    /// level.
    /// 
    ///  
    /// <para>
    /// For more information, see <a href="https://docs.aws.amazon.com/location/latest/developerguide/tiles.html">Tiles</a>
    /// in the <i>Amazon Location Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "GEOMTile")]
    [OutputType("Amazon.GeoMaps.Model.GetTileResponse")]
    [AWSCmdlet("Calls the Amazon Location Service Maps V2 GetTile API operation.", Operation = new[] {"GetTile"}, SelectReturnType = typeof(Amazon.GeoMaps.Model.GetTileResponse))]
    [AWSCmdletOutput("Amazon.GeoMaps.Model.GetTileResponse",
        "This cmdlet returns an Amazon.GeoMaps.Model.GetTileResponse object containing multiple properties."
    )]
    public partial class GetGEOMTileCmdlet : AmazonGeoMapsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter Tileset
        /// <summary>
        /// <para>
        /// <para>Specifies the desired tile set.</para><para>Valid Values: <c>raster.satellite | vector.basemap</c></para>
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
        public System.String Tileset { get; set; }
        #endregion
        
        #region Parameter X
        /// <summary>
        /// <para>
        /// <para>The X axis value for the map tile. Must be between 0 and 19.</para>
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
        public System.String X { get; set; }
        #endregion
        
        #region Parameter Y
        /// <summary>
        /// <para>
        /// <para>The Y axis value for the map tile.</para>
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
        public System.String Y { get; set; }
        #endregion
        
        #region Parameter Z
        /// <summary>
        /// <para>
        /// <para>The zoom value for the map tile.</para>
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
        public System.String Z { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GeoMaps.Model.GetTileResponse).
        /// Specifying the name of a property of type Amazon.GeoMaps.Model.GetTileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Tileset parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Tileset' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Tileset' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.GeoMaps.Model.GetTileResponse, GetGEOMTileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Tileset;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Key = this.Key;
            context.Tileset = this.Tileset;
            #if MODULAR
            if (this.Tileset == null && ParameterWasBound(nameof(this.Tileset)))
            {
                WriteWarning("You are passing $null as a value for parameter Tileset which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.X = this.X;
            #if MODULAR
            if (this.X == null && ParameterWasBound(nameof(this.X)))
            {
                WriteWarning("You are passing $null as a value for parameter X which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Y = this.Y;
            #if MODULAR
            if (this.Y == null && ParameterWasBound(nameof(this.Y)))
            {
                WriteWarning("You are passing $null as a value for parameter Y which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Z = this.Z;
            #if MODULAR
            if (this.Z == null && ParameterWasBound(nameof(this.Z)))
            {
                WriteWarning("You are passing $null as a value for parameter Z which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GeoMaps.Model.GetTileRequest();
            
            if (cmdletContext.Key != null)
            {
                request.Key = cmdletContext.Key;
            }
            if (cmdletContext.Tileset != null)
            {
                request.Tileset = cmdletContext.Tileset;
            }
            if (cmdletContext.X != null)
            {
                request.X = cmdletContext.X;
            }
            if (cmdletContext.Y != null)
            {
                request.Y = cmdletContext.Y;
            }
            if (cmdletContext.Z != null)
            {
                request.Z = cmdletContext.Z;
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
        
        private Amazon.GeoMaps.Model.GetTileResponse CallAWSServiceOperation(IAmazonGeoMaps client, Amazon.GeoMaps.Model.GetTileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Location Service Maps V2", "GetTile");
            try
            {
                #if DESKTOP
                return client.GetTile(request);
                #elif CORECLR
                return client.GetTileAsync(request).GetAwaiter().GetResult();
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
            public System.String Key { get; set; }
            public System.String Tileset { get; set; }
            public System.String X { get; set; }
            public System.String Y { get; set; }
            public System.String Z { get; set; }
            public System.Func<Amazon.GeoMaps.Model.GetTileResponse, GetGEOMTileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
