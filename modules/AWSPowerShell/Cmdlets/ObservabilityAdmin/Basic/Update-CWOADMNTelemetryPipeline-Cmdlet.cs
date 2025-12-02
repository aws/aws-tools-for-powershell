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
    /// Updates the configuration of an existing telemetry pipeline.
    /// 
    ///  <note><para>
    /// The following attributes cannot be updated after pipeline creation:
    /// </para><ul><li><para><b>Pipeline name</b> - The pipeline name is immutable
    /// </para></li><li><para><b>Pipeline ARN</b> - The ARN is automatically generated and cannot be changed
    /// </para></li><li><para><b>Source type</b> - Once a pipeline is created with a specific source type (such
    /// as S3, CloudWatch Logs, GitHub, or third-party sources), it cannot be changed to a
    /// different source type
    /// </para></li></ul><para>
    /// Processors can be added, removed, or modified. However, some processors are not supported
    /// for third-party pipelines and cannot be added through updates.
    /// </para></note><para><b>Source-Specific Update Rules</b></para><dl><dt>CloudWatch Logs Sources (Vended and Custom)</dt><dd><para><b>Updatable:</b><c>sts_role_arn</c></para><para><b>Fixed:</b><c>data_source_name</c>, <c>data_source_type</c>, sink (must remain
    /// <c>@original</c>)
    /// </para></dd><dt>S3 Sources (Crowdstrike, Zscaler, SentinelOne, Custom)</dt><dd><para><b>Updatable:</b> All SQS configuration parameters, <c>sts_role_arn</c>, codec settings,
    /// compression type, bucket ownership settings, sink log group
    /// </para><para><b>Fixed:</b><c>notification_type</c>, <c>aws.region</c></para></dd><dt>GitHub Audit Logs</dt><dd><para><b>Updatable:</b> All Amazon Web Services Secrets Manager attributes, <c>scope</c>
    /// (can switch between ORGANIZATION/ENTERPRISE), <c>organization</c> or <c>enterprise</c>
    /// name, <c>range</c>, authentication credentials (PAT or GitHub App)
    /// </para></dd><dt>Microsoft Sources (Entra ID, Office365, Windows)</dt><dd><para><b>Updatable:</b> All Amazon Web Services Secrets Manager attributes, <c>tenant_id</c>,
    /// <c>workspace_id</c> (Windows only), OAuth2 credentials (<c>client_id</c>, <c>client_secret</c>)
    /// </para></dd><dt>Okta Sources (SSO, Auth0)</dt><dd><para><b>Updatable:</b> All Amazon Web Services Secrets Manager attributes, <c>domain</c>,
    /// <c>range</c> (SSO only), OAuth2 credentials (<c>client_id</c>, <c>client_secret</c>)
    /// </para></dd><dt>Palo Alto Networks</dt><dd><para><b>Updatable:</b> All Amazon Web Services Secrets Manager attributes, <c>hostname</c>,
    /// basic authentication credentials (<c>username</c>, <c>password</c>)
    /// </para></dd><dt>ServiceNow CMDB</dt><dd><para><b>Updatable:</b> All Amazon Web Services Secrets Manager attributes, <c>instance_url</c>,
    /// <c>range</c>, OAuth2 credentials (<c>client_id</c>, <c>client_secret</c>)
    /// </para></dd><dt>Wiz CNAPP</dt><dd><para><b>Updatable:</b> All Amazon Web Services Secrets Manager attributes, <c>region</c>,
    /// <c>range</c>, OAuth2 credentials (<c>client_id</c>, <c>client_secret</c>)
    /// </para></dd></dl>
    /// </summary>
    [Cmdlet("Update", "CWOADMNTelemetryPipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service UpdateTelemetryPipeline API operation.", Operation = new[] {"UpdateTelemetryPipeline"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineResponse))]
    [AWSCmdletOutput("None or Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWOADMNTelemetryPipelineCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_Body
        /// <summary>
        /// <para>
        /// <para>The pipeline configuration body that defines the data processing rules and transformations.</para>
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
        public System.String Configuration_Body { get; set; }
        #endregion
        
        #region Parameter PipelineIdentifier
        /// <summary>
        /// <para>
        /// <para>The ARN of the telemetry pipeline to update.</para>
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
        public System.String PipelineIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PipelineIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWOADMNTelemetryPipeline (UpdateTelemetryPipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineResponse, UpdateCWOADMNTelemetryPipelineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_Body = this.Configuration_Body;
            #if MODULAR
            if (this.Configuration_Body == null && ParameterWasBound(nameof(this.Configuration_Body)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_Body which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PipelineIdentifier = this.PipelineIdentifier;
            #if MODULAR
            if (this.PipelineIdentifier == null && ParameterWasBound(nameof(this.PipelineIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter PipelineIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.ObservabilityAdmin.Model.TelemetryPipelineConfiguration();
            System.String requestConfiguration_configuration_Body = null;
            if (cmdletContext.Configuration_Body != null)
            {
                requestConfiguration_configuration_Body = cmdletContext.Configuration_Body;
            }
            if (requestConfiguration_configuration_Body != null)
            {
                request.Configuration.Body = requestConfiguration_configuration_Body;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.PipelineIdentifier != null)
            {
                request.PipelineIdentifier = cmdletContext.PipelineIdentifier;
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
        
        private Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "UpdateTelemetryPipeline");
            try
            {
                return client.UpdateTelemetryPipelineAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_Body { get; set; }
            public System.String PipelineIdentifier { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.UpdateTelemetryPipelineResponse, UpdateCWOADMNTelemetryPipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
