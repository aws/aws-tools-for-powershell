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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.PROM
{
    /// <summary>
    /// The <c>CreateScraper</c> operation creates a scraper to collect metrics. A scraper
    /// pulls metrics from Prometheus-compatible sources within an Amazon EKS cluster, and
    /// sends them to your Amazon Managed Service for Prometheus workspace. Scrapers are flexible,
    /// and can be configured to control what metrics are collected, the frequency of collection,
    /// what transformations are applied to the metrics, and more.
    /// 
    ///  
    /// <para>
    /// An IAM role will be created for you that Amazon Managed Service for Prometheus uses
    /// to access the metrics in your cluster. You must configure this role with a policy
    /// that allows it to scrape metrics from your cluster. For more information, see <a href="https://docs.aws.amazon.com/prometheus/latest/userguide/AMP-collector-how-to.html#AMP-collector-eks-setup">Configuring
    /// your Amazon EKS cluster</a> in the <i>Amazon Managed Service for Prometheus User Guide</i>.
    /// </para><para>
    /// The <c>scrapeConfiguration</c> parameter contains the base-64 encoded YAML configuration
    /// for the scraper.
    /// </para><para>
    /// When creating a scraper, the service creates a <c>Network Interface</c> in each <b>Availability
    /// Zone</b> that are passed into <c>CreateScraper</c> through subnets. These network
    /// interfaces are used to connect to the Amazon EKS cluster within the VPC for scraping
    /// metrics.
    /// </para><note><para>
    /// For more information about collectors, including what metrics are collected, and how
    /// to configure the scraper, see <a href="https://docs.aws.amazon.com/prometheus/latest/userguide/AMP-collector-how-to.html">Using
    /// an Amazon Web Services managed collector</a> in the <i>Amazon Managed Service for
    /// Prometheus User Guide</i>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "PROMScraper", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PrometheusService.Model.CreateScraperResponse")]
    [AWSCmdlet("Calls the Amazon Prometheus Service CreateScraper API operation.", Operation = new[] {"CreateScraper"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.CreateScraperResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.CreateScraperResponse",
        "This cmdlet returns an Amazon.PrometheusService.Model.CreateScraperResponse object containing multiple properties."
    )]
    public partial class NewPROMScraperCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>(optional) An alias to associate with the scraper. This is for your use, and does
        /// not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter EksConfiguration_ClusterArn
        /// <summary>
        /// <para>
        /// <para>ARN of the Amazon EKS cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_EksConfiguration_ClusterArn")]
        public System.String EksConfiguration_ClusterArn { get; set; }
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
        
        #region Parameter EksConfiguration_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of the security group IDs for the Amazon EKS cluster VPC configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_EksConfiguration_SecurityGroupIds")]
        public System.String[] EksConfiguration_SecurityGroupId { get; set; }
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
        
        #region Parameter EksConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs for the Amazon EKS cluster VPC configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_EksConfiguration_SubnetIds")]
        public System.String[] EksConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>(Optional) The list of tag keys and values to associate with the scraper.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// <para>(Optional) A unique, case-sensitive identifier that you can provide to ensure the
        /// idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.PrometheusService.Model.CreateScraperResponse).
        /// Specifying the name of a property of type Amazon.PrometheusService.Model.CreateScraperResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PROMScraper (CreateScraper)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.CreateScraperResponse, NewPROMScraperCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Alias = this.Alias;
            context.ClientToken = this.ClientToken;
            context.AmpConfiguration_WorkspaceArn = this.AmpConfiguration_WorkspaceArn;
            context.RoleConfiguration_SourceRoleArn = this.RoleConfiguration_SourceRoleArn;
            context.RoleConfiguration_TargetRoleArn = this.RoleConfiguration_TargetRoleArn;
            context.ScrapeConfiguration_ConfigurationBlob = this.ScrapeConfiguration_ConfigurationBlob;
            context.EksConfiguration_ClusterArn = this.EksConfiguration_ClusterArn;
            if (this.EksConfiguration_SecurityGroupId != null)
            {
                context.EksConfiguration_SecurityGroupId = new List<System.String>(this.EksConfiguration_SecurityGroupId);
            }
            if (this.EksConfiguration_SubnetId != null)
            {
                context.EksConfiguration_SubnetId = new List<System.String>(this.EksConfiguration_SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            
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
                var request = new Amazon.PrometheusService.Model.CreateScraperRequest();
                
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
                
                 // populate Source
                var requestSourceIsNull = true;
                request.Source = new Amazon.PrometheusService.Model.Source();
                Amazon.PrometheusService.Model.EksConfiguration requestSource_source_EksConfiguration = null;
                
                 // populate EksConfiguration
                var requestSource_source_EksConfigurationIsNull = true;
                requestSource_source_EksConfiguration = new Amazon.PrometheusService.Model.EksConfiguration();
                System.String requestSource_source_EksConfiguration_eksConfiguration_ClusterArn = null;
                if (cmdletContext.EksConfiguration_ClusterArn != null)
                {
                    requestSource_source_EksConfiguration_eksConfiguration_ClusterArn = cmdletContext.EksConfiguration_ClusterArn;
                }
                if (requestSource_source_EksConfiguration_eksConfiguration_ClusterArn != null)
                {
                    requestSource_source_EksConfiguration.ClusterArn = requestSource_source_EksConfiguration_eksConfiguration_ClusterArn;
                    requestSource_source_EksConfigurationIsNull = false;
                }
                List<System.String> requestSource_source_EksConfiguration_eksConfiguration_SecurityGroupId = null;
                if (cmdletContext.EksConfiguration_SecurityGroupId != null)
                {
                    requestSource_source_EksConfiguration_eksConfiguration_SecurityGroupId = cmdletContext.EksConfiguration_SecurityGroupId;
                }
                if (requestSource_source_EksConfiguration_eksConfiguration_SecurityGroupId != null)
                {
                    requestSource_source_EksConfiguration.SecurityGroupIds = requestSource_source_EksConfiguration_eksConfiguration_SecurityGroupId;
                    requestSource_source_EksConfigurationIsNull = false;
                }
                List<System.String> requestSource_source_EksConfiguration_eksConfiguration_SubnetId = null;
                if (cmdletContext.EksConfiguration_SubnetId != null)
                {
                    requestSource_source_EksConfiguration_eksConfiguration_SubnetId = cmdletContext.EksConfiguration_SubnetId;
                }
                if (requestSource_source_EksConfiguration_eksConfiguration_SubnetId != null)
                {
                    requestSource_source_EksConfiguration.SubnetIds = requestSource_source_EksConfiguration_eksConfiguration_SubnetId;
                    requestSource_source_EksConfigurationIsNull = false;
                }
                 // determine if requestSource_source_EksConfiguration should be set to null
                if (requestSource_source_EksConfigurationIsNull)
                {
                    requestSource_source_EksConfiguration = null;
                }
                if (requestSource_source_EksConfiguration != null)
                {
                    request.Source.EksConfiguration = requestSource_source_EksConfiguration;
                    requestSourceIsNull = false;
                }
                 // determine if request.Source should be set to null
                if (requestSourceIsNull)
                {
                    request.Source = null;
                }
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
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
        
        private Amazon.PrometheusService.Model.CreateScraperResponse CallAWSServiceOperation(IAmazonPrometheusService client, Amazon.PrometheusService.Model.CreateScraperRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Prometheus Service", "CreateScraper");
            try
            {
                return client.CreateScraperAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String EksConfiguration_ClusterArn { get; set; }
            public List<System.String> EksConfiguration_SecurityGroupId { get; set; }
            public List<System.String> EksConfiguration_SubnetId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.PrometheusService.Model.CreateScraperResponse, NewPROMScraperCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
