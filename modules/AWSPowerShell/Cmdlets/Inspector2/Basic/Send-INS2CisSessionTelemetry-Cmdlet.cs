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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Sends a CIS session telemetry. This API is used by the Amazon Inspector SSM plugin
    /// to communicate with the Amazon Inspector service. The Amazon Inspector SSM plugin
    /// calls this API to start a CIS scan session for the scan ID supplied by the service.
    /// </summary>
    [Cmdlet("Send", "INS2CisSessionTelemetry", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Inspector2 SendCisSessionTelemetry API operation.", Operation = new[] {"SendCisSessionTelemetry"}, SelectReturnType = typeof(Amazon.Inspector2.Model.SendCisSessionTelemetryResponse))]
    [AWSCmdletOutput("None or Amazon.Inspector2.Model.SendCisSessionTelemetryResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Inspector2.Model.SendCisSessionTelemetryResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendINS2CisSessionTelemetryCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Message
        /// <summary>
        /// <para>
        /// <para>The CIS session telemetry messages.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Messages")]
        public Amazon.Inspector2.Model.CisSessionMessage[] Message { get; set; }
        #endregion
        
        #region Parameter ScanJobId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the scan job.</para>
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
        public System.String ScanJobId { get; set; }
        #endregion
        
        #region Parameter CisSessionToken
        /// <summary>
        /// <para>
        /// <para>The unique token that identifies the CIS session.</para>
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
        public System.String CisSessionToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.SendCisSessionTelemetryResponse).
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScanJobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-INS2CisSessionTelemetry (SendCisSessionTelemetry)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.SendCisSessionTelemetryResponse, SendINS2CisSessionTelemetryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Message != null)
            {
                context.Message = new List<Amazon.Inspector2.Model.CisSessionMessage>(this.Message);
            }
            #if MODULAR
            if (this.Message == null && ParameterWasBound(nameof(this.Message)))
            {
                WriteWarning("You are passing $null as a value for parameter Message which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanJobId = this.ScanJobId;
            #if MODULAR
            if (this.ScanJobId == null && ParameterWasBound(nameof(this.ScanJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CisSessionToken = this.CisSessionToken;
            #if MODULAR
            if (this.CisSessionToken == null && ParameterWasBound(nameof(this.CisSessionToken)))
            {
                WriteWarning("You are passing $null as a value for parameter CisSessionToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.SendCisSessionTelemetryRequest();
            
            if (cmdletContext.Message != null)
            {
                request.Messages = cmdletContext.Message;
            }
            if (cmdletContext.ScanJobId != null)
            {
                request.ScanJobId = cmdletContext.ScanJobId;
            }
            if (cmdletContext.CisSessionToken != null)
            {
                request.SessionToken = cmdletContext.CisSessionToken;
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
        
        private Amazon.Inspector2.Model.SendCisSessionTelemetryResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.SendCisSessionTelemetryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "SendCisSessionTelemetry");
            try
            {
                return client.SendCisSessionTelemetryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.CisSessionMessage> Message { get; set; }
            public System.String ScanJobId { get; set; }
            public System.String CisSessionToken { get; set; }
            public System.Func<Amazon.Inspector2.Model.SendCisSessionTelemetryResponse, SendINS2CisSessionTelemetryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
