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
using System.Threading;
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Update the position information of a given wireless device or a wireless gateway resource.
    /// The position coordinates are based on the <a href="https://gisgeography.com/wgs84-world-geodetic-system/">
    /// World Geodetic System (WGS84)</a>.
    /// </summary>
    [Cmdlet("Update", "IOTWResourcePosition", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdateResourcePosition API operation.", Operation = new[] {"UpdateResourcePosition"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdateResourcePositionResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdateResourcePositionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdateResourcePositionResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTWResourcePositionCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GeoJsonPayload
        /// <summary>
        /// <para>
        /// <para>The position information of the resource, displayed as a JSON payload. The payload
        /// uses the GeoJSON format, which a format that's used to encode geographic data structures.
        /// For more information, see <a href="https://geojson.org/">GeoJSON</a>.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] GeoJsonPayload { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the resource for which position information is updated. It can be
        /// the wireless device ID or the wireless gateway ID, depending on the resource type.</para>
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
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>The type of resource for which position information is updated, which can be a wireless
        /// device or a wireless gateway.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTWireless.PositionResourceType")]
        public Amazon.IoTWireless.PositionResourceType ResourceType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdateResourcePositionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWResourcePosition (UpdateResourcePosition)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdateResourcePositionResponse, UpdateIOTWResourcePositionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GeoJsonPayload = this.GeoJsonPayload;
            context.ResourceIdentifier = this.ResourceIdentifier;
            #if MODULAR
            if (this.ResourceIdentifier == null && ParameterWasBound(nameof(this.ResourceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _GeoJsonPayloadStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.IoTWireless.Model.UpdateResourcePositionRequest();
                
                if (cmdletContext.GeoJsonPayload != null)
                {
                    _GeoJsonPayloadStream = new System.IO.MemoryStream(cmdletContext.GeoJsonPayload);
                    request.GeoJsonPayload = _GeoJsonPayloadStream;
                }
                if (cmdletContext.ResourceIdentifier != null)
                {
                    request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
                }
                if (cmdletContext.ResourceType != null)
                {
                    request.ResourceType = cmdletContext.ResourceType;
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
            finally
            {
                if( _GeoJsonPayloadStream != null)
                {
                    _GeoJsonPayloadStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.IoTWireless.Model.UpdateResourcePositionResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdateResourcePositionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdateResourcePosition");
            try
            {
                return client.UpdateResourcePositionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public byte[] GeoJsonPayload { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public Amazon.IoTWireless.PositionResourceType ResourceType { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdateResourcePositionResponse, UpdateIOTWResourcePositionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
