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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// Starts a third-party telemetry enrichment. An enrichment adds resource metadata, such
    /// as tags, from a third-party telemetry source to the telemetry that CloudWatch receives
    /// from the resources of that source.
    /// 
    ///  
    /// <para>
    /// You specify an Amazon Web Services Config connector for your third-party environment,
    /// such as a Microsoft Azure tenant. You can use each connector for only one enrichment.
    /// </para><para>
    /// To use this operation, you must have the <c>config:PutThirdPartyServiceLinkedConfigurationRecorder</c>
    /// permission. If the Amazon Web Services Config service-linked role does not exist in
    /// your account, you must also have the <c>iam:CreateServiceLinkedRole</c> permission.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CWOADMNThirdPartyTelemetryEnrichment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service StartThirdPartyTelemetryEnrichment API operation.", Operation = new[] {"StartThirdPartyTelemetryEnrichment"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse",
        "This cmdlet returns an Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse object containing multiple properties."
    )]
    public partial class StartCWOADMNThirdPartyTelemetryEnrichmentCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter TelemetrySourceConfiguration_Azure_AwsConfigConnectorArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Config connector for the
        /// Microsoft Azure tenant to collect resource metadata from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TelemetrySourceConfiguration_Azure_AwsConfigConnectorArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the enrichment. The name must be unique in your account and Region. You
        /// can use the name instead of the ARN to identify the enrichment in other operations.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to associate with the enrichment resource.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CWOADMNThirdPartyTelemetryEnrichment (StartThirdPartyTelemetryEnrichment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse, StartCWOADMNThirdPartyTelemetryEnrichmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TelemetrySourceConfiguration_Azure_AwsConfigConnectorArn = this.TelemetrySourceConfiguration_Azure_AwsConfigConnectorArn;
            
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
            var request = new Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TelemetrySourceConfiguration
            var requestTelemetrySourceConfigurationIsNull = true;
            request.TelemetrySourceConfiguration = new Amazon.ObservabilityAdmin.Model.TelemetrySourceConfigurationInput();
            Amazon.ObservabilityAdmin.Model.AzureTelemetrySourceConfigurationInput requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure = null;
            
             // populate Azure
            var requestTelemetrySourceConfiguration_telemetrySourceConfiguration_AzureIsNull = true;
            requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure = new Amazon.ObservabilityAdmin.Model.AzureTelemetrySourceConfigurationInput();
            System.String requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure_telemetrySourceConfiguration_Azure_AwsConfigConnectorArn = null;
            if (cmdletContext.TelemetrySourceConfiguration_Azure_AwsConfigConnectorArn != null)
            {
                requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure_telemetrySourceConfiguration_Azure_AwsConfigConnectorArn = cmdletContext.TelemetrySourceConfiguration_Azure_AwsConfigConnectorArn;
            }
            if (requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure_telemetrySourceConfiguration_Azure_AwsConfigConnectorArn != null)
            {
                requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure.AwsConfigConnectorArn = requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure_telemetrySourceConfiguration_Azure_AwsConfigConnectorArn;
                requestTelemetrySourceConfiguration_telemetrySourceConfiguration_AzureIsNull = false;
            }
             // determine if requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure should be set to null
            if (requestTelemetrySourceConfiguration_telemetrySourceConfiguration_AzureIsNull)
            {
                requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure = null;
            }
            if (requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure != null)
            {
                request.TelemetrySourceConfiguration.Azure = requestTelemetrySourceConfiguration_telemetrySourceConfiguration_Azure;
                requestTelemetrySourceConfigurationIsNull = false;
            }
             // determine if request.TelemetrySourceConfiguration should be set to null
            if (requestTelemetrySourceConfigurationIsNull)
            {
                request.TelemetrySourceConfiguration = null;
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
        
        private Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "StartThirdPartyTelemetryEnrichment");
            try
            {
                return client.StartThirdPartyTelemetryEnrichmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TelemetrySourceConfiguration_Azure_AwsConfigConnectorArn { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.StartThirdPartyTelemetryEnrichmentResponse, StartCWOADMNThirdPartyTelemetryEnrichmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
