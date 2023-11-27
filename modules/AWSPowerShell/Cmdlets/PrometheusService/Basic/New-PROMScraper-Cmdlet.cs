/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Create a scraper.
    /// </summary>
    [Cmdlet("New", "PROMScraper", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.PrometheusService.Model.CreateScraperResponse")]
    [AWSCmdlet("Calls the Amazon Prometheus Service CreateScraper API operation.", Operation = new[] {"CreateScraper"}, SelectReturnType = typeof(Amazon.PrometheusService.Model.CreateScraperResponse))]
    [AWSCmdletOutput("Amazon.PrometheusService.Model.CreateScraperResponse",
        "This cmdlet returns an Amazon.PrometheusService.Model.CreateScraperResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewPROMScraperCmdlet : AmazonPrometheusServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alias
        /// <summary>
        /// <para>
        /// <para>An optional user-assigned alias for this scraper. This alias is for user reference
        /// and does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Alias { get; set; }
        #endregion
        
        #region Parameter EksConfiguration_ClusterArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an EKS cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_EksConfiguration_ClusterArn")]
        public System.String EksConfiguration_ClusterArn { get; set; }
        #endregion
        
        #region Parameter ScrapeConfiguration_ConfigurationBlob
        /// <summary>
        /// <para>
        /// <para>Binary data representing a Prometheus configuration file.</para>
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
        /// <para>A list of security group IDs specified for VPC configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_EksConfiguration_SecurityGroupIds")]
        public System.String[] EksConfiguration_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter EksConfiguration_SubnetId
        /// <summary>
        /// <para>
        /// <para>A list of subnet IDs specified for VPC configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_EksConfiguration_SubnetIds")]
        public System.String[] EksConfiguration_SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional, user-provided tags for this scraper.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter AmpConfiguration_WorkspaceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an AMP workspace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Destination_AmpConfiguration_WorkspaceArn")]
        public System.String AmpConfiguration_WorkspaceArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Optional, unique, case-sensitive, user-provided identifier to ensure the idempotency
        /// of the request.</para>
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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Alias parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Alias' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Alias' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-PROMScraper (CreateScraper)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.PrometheusService.Model.CreateScraperResponse, NewPROMScraperCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Alias;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Alias = this.Alias;
            context.ClientToken = this.ClientToken;
            context.AmpConfiguration_WorkspaceArn = this.AmpConfiguration_WorkspaceArn;
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
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
                #if DESKTOP
                return client.CreateScraper(request);
                #elif CORECLR
                return client.CreateScraperAsync(request).GetAwaiter().GetResult();
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
            public System.String Alias { get; set; }
            public System.String ClientToken { get; set; }
            public System.String AmpConfiguration_WorkspaceArn { get; set; }
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
