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
using Amazon.PrometheusService;
using Amazon.PrometheusService.Model;

namespace Amazon.PowerShell.Cmdlets.PROM
{
    /// <summary>
    /// Updates the logging configuration for a Amazon Managed Service for Prometheus scraper.
    /// </summary>
    [Cmdlet("Update", "PROMScraperLoggingConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PrometheusService.Model.ScraperLoggingConfigurationStatus")]
    [AWSCmdlet("Calls the Amazon Prometheus Service UpdateScraperLoggingConfiguration API operation.", Operation = new[] {"UpdateScraperLoggingConfiguration"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.ScraperLoggingConfigurationStatus or Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationResponse",
        "This cmdlet returns an Amazon.PrometheusService.Model.ScraperLoggingConfigurationStatus object.",
        "The service call response (type Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdatePROMScraperLoggingConfigurationCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CloudWatchLogs_LogGroupArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the CloudWatch log group to which the vended log data will be published.
        /// This log group must exist prior to calling this operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoggingDestination_CloudWatchLogs_LogGroupArn")]
        public System.String CloudWatchLogs_LogGroupArn { get; set; }
        #endregion
        
        #region Parameter ScraperComponent
        /// <summary>
        /// <para>
        /// <para>The list of scraper components to configure for logging.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ScraperComponents")]
        public Amazon.PrometheusService.Model.ScraperComponent[] ScraperComponent { get; set; }
        #endregion
        
        #region Parameter ScraperId
        /// <summary>
        /// <para>
        /// <para>The ID of the scraper whose logging configuration will be updated.</para>
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
        public System.String ScraperId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Status'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationResponse).
        /// Specifying the name of a property of type Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Status";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScraperId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScraperId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScraperId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScraperId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROMScraperLoggingConfiguration (UpdateScraperLoggingConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationResponse, UpdatePROMScraperLoggingConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScraperId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CloudWatchLogs_LogGroupArn = this.CloudWatchLogs_LogGroupArn;
            if (this.ScraperComponent != null)
            {
                context.ScraperComponent = new List<Amazon.PrometheusService.Model.ScraperComponent>(this.ScraperComponent);
            }
            context.ScraperId = this.ScraperId;
            #if MODULAR
            if (this.ScraperId == null && ParameterWasBound(nameof(this.ScraperId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScraperId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationRequest();
            
            
             // populate LoggingDestination
            request.LoggingDestination = new Amazon.PrometheusService.Model.ScraperLoggingDestination();
            Amazon.PrometheusService.Model.CloudWatchLogDestination requestLoggingDestination_loggingDestination_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLoggingDestination_loggingDestination_CloudWatchLogsIsNull = true;
            requestLoggingDestination_loggingDestination_CloudWatchLogs = new Amazon.PrometheusService.Model.CloudWatchLogDestination();
            System.String requestLoggingDestination_loggingDestination_CloudWatchLogs_cloudWatchLogs_LogGroupArn = null;
            if (cmdletContext.CloudWatchLogs_LogGroupArn != null)
            {
                requestLoggingDestination_loggingDestination_CloudWatchLogs_cloudWatchLogs_LogGroupArn = cmdletContext.CloudWatchLogs_LogGroupArn;
            }
            if (requestLoggingDestination_loggingDestination_CloudWatchLogs_cloudWatchLogs_LogGroupArn != null)
            {
                requestLoggingDestination_loggingDestination_CloudWatchLogs.LogGroupArn = requestLoggingDestination_loggingDestination_CloudWatchLogs_cloudWatchLogs_LogGroupArn;
                requestLoggingDestination_loggingDestination_CloudWatchLogsIsNull = false;
            }
             // determine if requestLoggingDestination_loggingDestination_CloudWatchLogs should be set to null
            if (requestLoggingDestination_loggingDestination_CloudWatchLogsIsNull)
            {
                requestLoggingDestination_loggingDestination_CloudWatchLogs = null;
            }
            if (requestLoggingDestination_loggingDestination_CloudWatchLogs != null)
            {
                request.LoggingDestination.CloudWatchLogs = requestLoggingDestination_loggingDestination_CloudWatchLogs;
            }
            if (cmdletContext.ScraperComponent != null)
            {
                request.ScraperComponents = cmdletContext.ScraperComponent;
            }
            if (cmdletContext.ScraperId != null)
            {
                request.ScraperId = cmdletContext.ScraperId;
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
        
        private Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationResponse CallAWSServiceOperation(IAmazonPrometheusService client, Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Prometheus Service", "UpdateScraperLoggingConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateScraperLoggingConfiguration(request);
                #elif CORECLR
                return client.UpdateScraperLoggingConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogs_LogGroupArn { get; set; }
            public List<Amazon.PrometheusService.Model.ScraperComponent> ScraperComponent { get; set; }
            public System.String ScraperId { get; set; }
            public System.Func<Amazon.PrometheusService.Model.UpdateScraperLoggingConfigurationResponse, UpdatePROMScraperLoggingConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Status;
        }
        
    }
}
