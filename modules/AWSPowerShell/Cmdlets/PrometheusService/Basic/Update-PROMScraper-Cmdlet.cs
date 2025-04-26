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
using Amazon.PrometheusService;
using Amazon.PrometheusService.Model;

namespace Amazon.PowerShell.Cmdlets.PROM
{
    /// <summary>
    /// Updates an existing scraper.
    /// 
    ///  
    /// <para>
    /// You can't use this function to update the source from which the scraper is collecting
    /// metrics. To change the source, delete the scraper and create a new one.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "PROMScraper", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PrometheusService.Model.UpdateScraperResponse")]
    [AWSCmdlet("Calls the Amazon Prometheus Service UpdateScraper API operation.", Operation = new[] {"UpdateScraper"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.UpdateScraperResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.UpdateScraperResponse",
        "This cmdlet returns an Amazon.PrometheusService.Model.UpdateScraperResponse object containing multiple properties."
    )]
    public partial class UpdatePROMScraperCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>The new alias of the scraper.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter ScrapeConfiguration_ConfigurationBlob
        /// <summary>
        /// <para>
        /// <para>The base 64 encoded scrape configuration file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] ScrapeConfiguration_ConfigurationBlob { get; set; }
        #endregion
        
        #region Parameter ScraperId
        /// <summary>
        /// <para>
        /// <para>The ID of the scraper to update.</para>
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
        
        #region Parameter RoleConfiguration_SourceRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role used in the source account to enable cross-account
        /// scraping. For information about the contents of this policy, see <a href="https://docs.aws.amazon.com/prometheus/latest/userguide/AMP-collector-how-to.html#cross-account-remote-write">Cross-account
        /// setup</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleConfiguration_SourceRoleArn { get; set; }
        #endregion
        
        #region Parameter RoleConfiguration_TargetRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the role used in the target account to enable cross-account
        /// scraping. For information about the contents of this policy, see <a href="https://docs.aws.amazon.com/prometheus/latest/userguide/AMP-collector-how-to.html#cross-account-remote-write">Cross-account
        /// setup</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleConfiguration_TargetRoleArn { get; set; }
        #endregion
        
        #region Parameter AmpConfiguration_WorkspaceArn
        /// <summary>
        /// <para>
        /// <para>ARN of the Amazon Managed Service for Prometheus workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_AmpConfiguration_WorkspaceArn")]
        public System.String AmpConfiguration_WorkspaceArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier that you can provide to ensure the idempotency of the request.
        /// Case-sensitive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PrometheusService.Model.UpdateScraperResponse).
        /// Specifying the name of a property of type Amazon.PrometheusService.Model.UpdateScraperResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScraperId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-PROMScraper (UpdateScraper)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.UpdateScraperResponse, UpdatePROMScraperCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Alias = this.Alias;
            context.ClientToken = this.ClientToken;
            context.AmpConfiguration_WorkspaceArn = this.AmpConfiguration_WorkspaceArn;
            context.RoleConfiguration_SourceRoleArn = this.RoleConfiguration_SourceRoleArn;
            context.RoleConfiguration_TargetRoleArn = this.RoleConfiguration_TargetRoleArn;
            context.ScrapeConfiguration_ConfigurationBlob = this.ScrapeConfiguration_ConfigurationBlob;
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
            System.IO.MemoryStream _ScrapeConfiguration_ConfigurationBlobStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.PrometheusService.Model.UpdateScraperRequest();
                
                if (cmdletContext.Alias != null)
                {
                    request.Alias = cmdletContext.Alias;
                }
                if (cmdletContext.ClientToken != null)
                {
                    request.ClientToken = cmdletContext.ClientToken;
                }
                
                 // populate Destination
                var requestDestinationIsNull = true;
                request.Destination = new Amazon.PrometheusService.Model.Destination();
                Amazon.PrometheusService.Model.AmpConfiguration requestDestination_destination_AmpConfiguration = null;
                
                 // populate AmpConfiguration
                var requestDestination_destination_AmpConfigurationIsNull = true;
                requestDestination_destination_AmpConfiguration = new Amazon.PrometheusService.Model.AmpConfiguration();
                System.String requestDestination_destination_AmpConfiguration_ampConfiguration_WorkspaceArn = null;
                if (cmdletContext.AmpConfiguration_WorkspaceArn != null)
                {
                    requestDestination_destination_AmpConfiguration_ampConfiguration_WorkspaceArn = cmdletContext.AmpConfiguration_WorkspaceArn;
                }
                if (requestDestination_destination_AmpConfiguration_ampConfiguration_WorkspaceArn != null)
                {
                    requestDestination_destination_AmpConfiguration.WorkspaceArn = requestDestination_destination_AmpConfiguration_ampConfiguration_WorkspaceArn;
                    requestDestination_destination_AmpConfigurationIsNull = false;
                }
                 // determine if requestDestination_destination_AmpConfiguration should be set to null
                if (requestDestination_destination_AmpConfigurationIsNull)
                {
                    requestDestination_destination_AmpConfiguration = null;
                }
                if (requestDestination_destination_AmpConfiguration != null)
                {
                    request.Destination.AmpConfiguration = requestDestination_destination_AmpConfiguration;
                    requestDestinationIsNull = false;
                }
                 // determine if request.Destination should be set to null
                if (requestDestinationIsNull)
                {
                    request.Destination = null;
                }
                
                 // populate RoleConfiguration
                var requestRoleConfigurationIsNull = true;
                request.RoleConfiguration = new Amazon.PrometheusService.Model.RoleConfiguration();
                System.String requestRoleConfiguration_roleConfiguration_SourceRoleArn = null;
                if (cmdletContext.RoleConfiguration_SourceRoleArn != null)
                {
                    requestRoleConfiguration_roleConfiguration_SourceRoleArn = cmdletContext.RoleConfiguration_SourceRoleArn;
                }
                if (requestRoleConfiguration_roleConfiguration_SourceRoleArn != null)
                {
                    request.RoleConfiguration.SourceRoleArn = requestRoleConfiguration_roleConfiguration_SourceRoleArn;
                    requestRoleConfigurationIsNull = false;
                }
                System.String requestRoleConfiguration_roleConfiguration_TargetRoleArn = null;
                if (cmdletContext.RoleConfiguration_TargetRoleArn != null)
                {
                    requestRoleConfiguration_roleConfiguration_TargetRoleArn = cmdletContext.RoleConfiguration_TargetRoleArn;
                }
                if (requestRoleConfiguration_roleConfiguration_TargetRoleArn != null)
                {
                    request.RoleConfiguration.TargetRoleArn = requestRoleConfiguration_roleConfiguration_TargetRoleArn;
                    requestRoleConfigurationIsNull = false;
                }
                 // determine if request.RoleConfiguration should be set to null
                if (requestRoleConfigurationIsNull)
                {
                    request.RoleConfiguration = null;
                }
                
                 // populate ScrapeConfiguration
                var requestScrapeConfigurationIsNull = true;
                request.ScrapeConfiguration = new Amazon.PrometheusService.Model.ScrapeConfiguration();
                System.IO.MemoryStream requestScrapeConfiguration_scrapeConfiguration_ConfigurationBlob = null;
                if (cmdletContext.ScrapeConfiguration_ConfigurationBlob != null)
                {
                    _ScrapeConfiguration_ConfigurationBlobStream = new System.IO.MemoryStream(cmdletContext.ScrapeConfiguration_ConfigurationBlob);
                    requestScrapeConfiguration_scrapeConfiguration_ConfigurationBlob = _ScrapeConfiguration_ConfigurationBlobStream;
                }
                if (requestScrapeConfiguration_scrapeConfiguration_ConfigurationBlob != null)
                {
                    request.ScrapeConfiguration.ConfigurationBlob = requestScrapeConfiguration_scrapeConfiguration_ConfigurationBlob;
                    requestScrapeConfigurationIsNull = false;
                }
                 // determine if request.ScrapeConfiguration should be set to null
                if (requestScrapeConfigurationIsNull)
                {
                    request.ScrapeConfiguration = null;
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
            finally
            {
                if( _ScrapeConfiguration_ConfigurationBlobStream != null)
                {
                    _ScrapeConfiguration_ConfigurationBlobStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.PrometheusService.Model.UpdateScraperResponse CallAWSServiceOperation(IAmazonPrometheusService client, Amazon.PrometheusService.Model.UpdateScraperRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Prometheus Service", "UpdateScraper");
            try
            {
                return client.UpdateScraperAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String AmpConfiguration_WorkspaceArn { get; set; }
            public System.String RoleConfiguration_SourceRoleArn { get; set; }
            public System.String RoleConfiguration_TargetRoleArn { get; set; }
            public byte[] ScrapeConfiguration_ConfigurationBlob { get; set; }
            public System.String ScraperId { get; set; }
            public System.Func<Amazon.PrometheusService.Model.UpdateScraperResponse, UpdatePROMScraperCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
