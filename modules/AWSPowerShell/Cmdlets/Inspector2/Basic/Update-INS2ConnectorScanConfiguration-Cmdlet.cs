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
    /// Updates scan configuration settings for resources associated with an Amazon Web Services
    /// Config connector.
    /// </summary>
    [Cmdlet("Update", "INS2ConnectorScanConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Inspector2 UpdateConnectorScanConfiguration API operation.", Operation = new[] {"UpdateConnectorScanConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateConnectorScanConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Inspector2.Model.UpdateConnectorScanConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Inspector2.Model.UpdateConnectorScanConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateINS2ConnectorScanConfigurationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsConfigConnectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services Config connector.</para>
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
        public System.String AwsConfigConnectorArn { get; set; }
        #endregion
        
        #region Parameter ScanConfiguration_ContainerImageScanning_PullDuration
        /// <summary>
        /// <para>
        /// <para>The amount of time after a container image is last pulled from a repository during
        /// which Amazon Inspector continues to rescan the image for vulnerabilities. Valid values
        /// are <c>DAYS_3</c>, <c>DAYS_7</c>, <c>DAYS_14</c>, <c>DAYS_30</c>, <c>DAYS_60</c>,
        /// <c>DAYS_90</c>, and <c>DAYS_180</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.ContainerImagePullDateRescanDuration")]
        public Amazon.Inspector2.ContainerImagePullDateRescanDuration ScanConfiguration_ContainerImageScanning_PullDuration { get; set; }
        #endregion
        
        #region Parameter ScanConfiguration_ContainerImageScanning_PushDuration
        /// <summary>
        /// <para>
        /// <para>The amount of time after a container image is pushed to a repository during which
        /// Amazon Inspector continues to rescan the image for vulnerabilities. Valid values are
        /// <c>LIFETIME</c>, <c>DAYS_3</c>, <c>DAYS_7</c>, <c>DAYS_14</c>, <c>DAYS_30</c>, <c>DAYS_60</c>,
        /// <c>DAYS_90</c>, and <c>DAYS_180</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.ContainerImageRescanDuration")]
        public Amazon.Inspector2.ContainerImageRescanDuration ScanConfiguration_ContainerImageScanning_PushDuration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateConnectorScanConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AwsConfigConnectorArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2ConnectorScanConfiguration (UpdateConnectorScanConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateConnectorScanConfigurationResponse, UpdateINS2ConnectorScanConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsConfigConnectorArn = this.AwsConfigConnectorArn;
            #if MODULAR
            if (this.AwsConfigConnectorArn == null && ParameterWasBound(nameof(this.AwsConfigConnectorArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsConfigConnectorArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScanConfiguration_ContainerImageScanning_PullDuration = this.ScanConfiguration_ContainerImageScanning_PullDuration;
            context.ScanConfiguration_ContainerImageScanning_PushDuration = this.ScanConfiguration_ContainerImageScanning_PushDuration;
            
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
            var request = new Amazon.Inspector2.Model.UpdateConnectorScanConfigurationRequest();
            
            if (cmdletContext.AwsConfigConnectorArn != null)
            {
                request.AwsConfigConnectorArn = cmdletContext.AwsConfigConnectorArn;
            }
            
             // populate ScanConfiguration
            var requestScanConfigurationIsNull = true;
            request.ScanConfiguration = new Amazon.Inspector2.Model.ConnectorScanConfiguration();
            Amazon.Inspector2.Model.ConnectorContainerImageScanConfiguration requestScanConfiguration_scanConfiguration_ContainerImageScanning = null;
            
             // populate ContainerImageScanning
            var requestScanConfiguration_scanConfiguration_ContainerImageScanningIsNull = true;
            requestScanConfiguration_scanConfiguration_ContainerImageScanning = new Amazon.Inspector2.Model.ConnectorContainerImageScanConfiguration();
            Amazon.Inspector2.ContainerImagePullDateRescanDuration requestScanConfiguration_scanConfiguration_ContainerImageScanning_scanConfiguration_ContainerImageScanning_PullDuration = null;
            if (cmdletContext.ScanConfiguration_ContainerImageScanning_PullDuration != null)
            {
                requestScanConfiguration_scanConfiguration_ContainerImageScanning_scanConfiguration_ContainerImageScanning_PullDuration = cmdletContext.ScanConfiguration_ContainerImageScanning_PullDuration;
            }
            if (requestScanConfiguration_scanConfiguration_ContainerImageScanning_scanConfiguration_ContainerImageScanning_PullDuration != null)
            {
                requestScanConfiguration_scanConfiguration_ContainerImageScanning.PullDuration = requestScanConfiguration_scanConfiguration_ContainerImageScanning_scanConfiguration_ContainerImageScanning_PullDuration;
                requestScanConfiguration_scanConfiguration_ContainerImageScanningIsNull = false;
            }
            Amazon.Inspector2.ContainerImageRescanDuration requestScanConfiguration_scanConfiguration_ContainerImageScanning_scanConfiguration_ContainerImageScanning_PushDuration = null;
            if (cmdletContext.ScanConfiguration_ContainerImageScanning_PushDuration != null)
            {
                requestScanConfiguration_scanConfiguration_ContainerImageScanning_scanConfiguration_ContainerImageScanning_PushDuration = cmdletContext.ScanConfiguration_ContainerImageScanning_PushDuration;
            }
            if (requestScanConfiguration_scanConfiguration_ContainerImageScanning_scanConfiguration_ContainerImageScanning_PushDuration != null)
            {
                requestScanConfiguration_scanConfiguration_ContainerImageScanning.PushDuration = requestScanConfiguration_scanConfiguration_ContainerImageScanning_scanConfiguration_ContainerImageScanning_PushDuration;
                requestScanConfiguration_scanConfiguration_ContainerImageScanningIsNull = false;
            }
             // determine if requestScanConfiguration_scanConfiguration_ContainerImageScanning should be set to null
            if (requestScanConfiguration_scanConfiguration_ContainerImageScanningIsNull)
            {
                requestScanConfiguration_scanConfiguration_ContainerImageScanning = null;
            }
            if (requestScanConfiguration_scanConfiguration_ContainerImageScanning != null)
            {
                request.ScanConfiguration.ContainerImageScanning = requestScanConfiguration_scanConfiguration_ContainerImageScanning;
                requestScanConfigurationIsNull = false;
            }
             // determine if request.ScanConfiguration should be set to null
            if (requestScanConfigurationIsNull)
            {
                request.ScanConfiguration = null;
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
        
        private Amazon.Inspector2.Model.UpdateConnectorScanConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateConnectorScanConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateConnectorScanConfiguration");
            try
            {
                return client.UpdateConnectorScanConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsConfigConnectorArn { get; set; }
            public Amazon.Inspector2.ContainerImagePullDateRescanDuration ScanConfiguration_ContainerImageScanning_PullDuration { get; set; }
            public Amazon.Inspector2.ContainerImageRescanDuration ScanConfiguration_ContainerImageScanning_PushDuration { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateConnectorScanConfigurationResponse, UpdateINS2ConnectorScanConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
