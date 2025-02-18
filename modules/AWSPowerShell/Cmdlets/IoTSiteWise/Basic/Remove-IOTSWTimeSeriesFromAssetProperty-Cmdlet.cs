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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Disassociates a time series (data stream) from an asset property.
    /// </summary>
    [Cmdlet("Remove", "IOTSWTimeSeriesFromAssetProperty", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT SiteWise DisassociateTimeSeriesFromAssetProperty API operation.", Operation = new[] {"DisassociateTimeSeriesFromAssetProperty"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyResponse))]
    [AWSCmdletOutput("None or Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveIOTSWTimeSeriesFromAssetPropertyCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>The alias that identifies the time series.</para>
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
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter AssetId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset in which the asset property was created. This can be either the
        /// actual ID in UUID format, or else <c>externalId:</c> followed by the external ID,
        /// if it has one. For more information, see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/object-ids.html#external-id-references">Referencing
        /// objects with external IDs</a> in the <i>IoT SiteWise User Guide</i>.</para>
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
        public System.String AssetId { get; set; }
        #endregion
        
        #region Parameter PropertyId
        /// <summary>
        /// <para>
        /// <para>The ID of the asset property. This can be either the actual ID in UUID format, or
        /// else <c>externalId:</c> followed by the external ID, if it has one. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/object-ids.html#external-id-references">Referencing
        /// objects with external IDs</a> in the <i>IoT SiteWise User Guide</i>.</para>
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
        public System.String PropertyId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyResponse).
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTSWTimeSeriesFromAssetProperty (DisassociateTimeSeriesFromAssetProperty)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyResponse, RemoveIOTSWTimeSeriesFromAssetPropertyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Alias = this.Alias;
            #if MODULAR
            if (this.Alias == null && ParameterWasBound(nameof(this.Alias)))
            {
                WriteWarning("You are passing $null as a value for parameter Alias which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AssetId = this.AssetId;
            #if MODULAR
            if (this.AssetId == null && ParameterWasBound(nameof(this.AssetId)))
            {
                WriteWarning("You are passing $null as a value for parameter AssetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.PropertyId = this.PropertyId;
            #if MODULAR
            if (this.PropertyId == null && ParameterWasBound(nameof(this.PropertyId)))
            {
                WriteWarning("You are passing $null as a value for parameter PropertyId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyRequest();
            
            if (cmdletContext.Alias != null)
            {
                request.Alias = cmdletContext.Alias;
            }
            if (cmdletContext.AssetId != null)
            {
                request.AssetId = cmdletContext.AssetId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.PropertyId != null)
            {
                request.PropertyId = cmdletContext.PropertyId;
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
        
        private Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "DisassociateTimeSeriesFromAssetProperty");
            try
            {
                return client.DisassociateTimeSeriesFromAssetPropertyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public System.String AssetId { get; set; }
            public System.String ClientToken { get; set; }
            public System.String PropertyId { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.DisassociateTimeSeriesFromAssetPropertyResponse, RemoveIOTSWTimeSeriesFromAssetPropertyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
