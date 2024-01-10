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
using Amazon.SecurityLake;
using Amazon.SecurityLake.Model;

namespace Amazon.PowerShell.Cmdlets.SLK
{
    /// <summary>
    /// Adds a third-party custom source in Amazon Security Lake, from the Amazon Web Services
    /// Region where you want to create a custom source. Security Lake can collect logs and
    /// events from third-party custom sources. After creating the appropriate IAM role to
    /// invoke Glue crawler, use this API to add a custom source name in Security Lake. This
    /// operation creates a partition in the Amazon S3 bucket for Security Lake as the target
    /// location for log files from the custom source. In addition, this operation also creates
    /// an associated Glue table and an Glue crawler.
    /// </summary>
    [Cmdlet("New", "SLKCustomLogSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityLake.Model.CreateCustomLogSourceResponse")]
    [AWSCmdlet("Calls the Amazon Security Lake CreateCustomLogSource API operation.", Operation = new[] {"CreateCustomLogSource"}, SelectReturnType = typeof(Amazon.SecurityLake.Model.CreateCustomLogSourceResponse))]
    [AWSCmdletOutput("Amazon.SecurityLake.Model.CreateCustomLogSourceResponse",
        "This cmdlet returns an Amazon.SecurityLake.Model.CreateCustomLogSourceResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSLKCustomLogSourceCmdlet : AmazonSecurityLakeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventClass
        /// <summary>
        /// <para>
        /// <para>The Open Cybersecurity Schema Framework (OCSF) event classes which describes the type
        /// of data that the custom source will send to Security Lake. The supported event classes
        /// are:</para><ul><li><para><c>ACCESS_ACTIVITY</c></para></li><li><para><c>FILE_ACTIVITY</c></para></li><li><para><c>KERNEL_ACTIVITY</c></para></li><li><para><c>KERNEL_EXTENSION</c></para></li><li><para><c>MEMORY_ACTIVITY</c></para></li><li><para><c>MODULE_ACTIVITY</c></para></li><li><para><c>PROCESS_ACTIVITY</c></para></li><li><para><c>REGISTRY_KEY_ACTIVITY</c></para></li><li><para><c>REGISTRY_VALUE_ACTIVITY</c></para></li><li><para><c>RESOURCE_ACTIVITY</c></para></li><li><para><c>SCHEDULED_JOB_ACTIVITY</c></para></li><li><para><c>SECURITY_FINDING</c></para></li><li><para><c>ACCOUNT_CHANGE</c></para></li><li><para><c>AUTHENTICATION</c></para></li><li><para><c>AUTHORIZATION</c></para></li><li><para><c>ENTITY_MANAGEMENT_AUDIT</c></para></li><li><para><c>DHCP_ACTIVITY</c></para></li><li><para><c>NETWORK_ACTIVITY</c></para></li><li><para><c>DNS_ACTIVITY</c></para></li><li><para><c>FTP_ACTIVITY</c></para></li><li><para><c>HTTP_ACTIVITY</c></para></li><li><para><c>RDP_ACTIVITY</c></para></li><li><para><c>SMB_ACTIVITY</c></para></li><li><para><c>SSH_ACTIVITY</c></para></li><li><para><c>CONFIG_STATE</c></para></li><li><para><c>INVENTORY_INFO</c></para></li><li><para><c>EMAIL_ACTIVITY</c></para></li><li><para><c>API_ACTIVITY</c></para></li><li><para><c>CLOUD_API</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("EventClasses")]
        public System.String[] EventClass { get; set; }
        #endregion
        
        #region Parameter ProviderIdentity_ExternalId
        /// <summary>
        /// <para>
        /// <para>The external ID used to estalish trust relationship with the AWS identity.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ProviderIdentity_ExternalId")]
        public System.String ProviderIdentity_ExternalId { get; set; }
        #endregion
        
        #region Parameter ProviderIdentity_Principal
        /// <summary>
        /// <para>
        /// <para>The AWS identity principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ProviderIdentity_Principal")]
        public System.String ProviderIdentity_Principal { get; set; }
        #endregion
        
        #region Parameter CrawlerConfiguration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role to
        /// be used by the Glue crawler. The recommended IAM policies are:</para><ul><li><para>The managed policy <c>AWSGlueServiceRole</c></para></li><li><para>A custom policy granting access to your Amazon S3 Data Lake</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CrawlerConfiguration_RoleArn")]
        public System.String CrawlerConfiguration_RoleArn { get; set; }
        #endregion
        
        #region Parameter SourceName
        /// <summary>
        /// <para>
        /// <para>Specify the name for a third-party custom source. This must be a Regionally unique
        /// value.</para>
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
        public System.String SourceName { get; set; }
        #endregion
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para>Specify the source version for the third-party custom source, to limit log collection
        /// to a specific version of custom data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityLake.Model.CreateCustomLogSourceResponse).
        /// Specifying the name of a property of type Amazon.SecurityLake.Model.CreateCustomLogSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EventClass parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EventClass' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EventClass' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SLKCustomLogSource (CreateCustomLogSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityLake.Model.CreateCustomLogSourceResponse, NewSLKCustomLogSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EventClass;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CrawlerConfiguration_RoleArn = this.CrawlerConfiguration_RoleArn;
            context.ProviderIdentity_ExternalId = this.ProviderIdentity_ExternalId;
            context.ProviderIdentity_Principal = this.ProviderIdentity_Principal;
            if (this.EventClass != null)
            {
                context.EventClass = new List<System.String>(this.EventClass);
            }
            context.SourceName = this.SourceName;
            #if MODULAR
            if (this.SourceName == null && ParameterWasBound(nameof(this.SourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceVersion = this.SourceVersion;
            
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
            var request = new Amazon.SecurityLake.Model.CreateCustomLogSourceRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.SecurityLake.Model.CustomLogSourceConfiguration();
            Amazon.SecurityLake.Model.CustomLogSourceCrawlerConfiguration requestConfiguration_configuration_CrawlerConfiguration = null;
            
             // populate CrawlerConfiguration
            var requestConfiguration_configuration_CrawlerConfigurationIsNull = true;
            requestConfiguration_configuration_CrawlerConfiguration = new Amazon.SecurityLake.Model.CustomLogSourceCrawlerConfiguration();
            System.String requestConfiguration_configuration_CrawlerConfiguration_crawlerConfiguration_RoleArn = null;
            if (cmdletContext.CrawlerConfiguration_RoleArn != null)
            {
                requestConfiguration_configuration_CrawlerConfiguration_crawlerConfiguration_RoleArn = cmdletContext.CrawlerConfiguration_RoleArn;
            }
            if (requestConfiguration_configuration_CrawlerConfiguration_crawlerConfiguration_RoleArn != null)
            {
                requestConfiguration_configuration_CrawlerConfiguration.RoleArn = requestConfiguration_configuration_CrawlerConfiguration_crawlerConfiguration_RoleArn;
                requestConfiguration_configuration_CrawlerConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CrawlerConfiguration should be set to null
            if (requestConfiguration_configuration_CrawlerConfigurationIsNull)
            {
                requestConfiguration_configuration_CrawlerConfiguration = null;
            }
            if (requestConfiguration_configuration_CrawlerConfiguration != null)
            {
                request.Configuration.CrawlerConfiguration = requestConfiguration_configuration_CrawlerConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.SecurityLake.Model.AwsIdentity requestConfiguration_configuration_ProviderIdentity = null;
            
             // populate ProviderIdentity
            var requestConfiguration_configuration_ProviderIdentityIsNull = true;
            requestConfiguration_configuration_ProviderIdentity = new Amazon.SecurityLake.Model.AwsIdentity();
            System.String requestConfiguration_configuration_ProviderIdentity_providerIdentity_ExternalId = null;
            if (cmdletContext.ProviderIdentity_ExternalId != null)
            {
                requestConfiguration_configuration_ProviderIdentity_providerIdentity_ExternalId = cmdletContext.ProviderIdentity_ExternalId;
            }
            if (requestConfiguration_configuration_ProviderIdentity_providerIdentity_ExternalId != null)
            {
                requestConfiguration_configuration_ProviderIdentity.ExternalId = requestConfiguration_configuration_ProviderIdentity_providerIdentity_ExternalId;
                requestConfiguration_configuration_ProviderIdentityIsNull = false;
            }
            System.String requestConfiguration_configuration_ProviderIdentity_providerIdentity_Principal = null;
            if (cmdletContext.ProviderIdentity_Principal != null)
            {
                requestConfiguration_configuration_ProviderIdentity_providerIdentity_Principal = cmdletContext.ProviderIdentity_Principal;
            }
            if (requestConfiguration_configuration_ProviderIdentity_providerIdentity_Principal != null)
            {
                requestConfiguration_configuration_ProviderIdentity.Principal = requestConfiguration_configuration_ProviderIdentity_providerIdentity_Principal;
                requestConfiguration_configuration_ProviderIdentityIsNull = false;
            }
             // determine if requestConfiguration_configuration_ProviderIdentity should be set to null
            if (requestConfiguration_configuration_ProviderIdentityIsNull)
            {
                requestConfiguration_configuration_ProviderIdentity = null;
            }
            if (requestConfiguration_configuration_ProviderIdentity != null)
            {
                request.Configuration.ProviderIdentity = requestConfiguration_configuration_ProviderIdentity;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.EventClass != null)
            {
                request.EventClasses = cmdletContext.EventClass;
            }
            if (cmdletContext.SourceName != null)
            {
                request.SourceName = cmdletContext.SourceName;
            }
            if (cmdletContext.SourceVersion != null)
            {
                request.SourceVersion = cmdletContext.SourceVersion;
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
        
        private Amazon.SecurityLake.Model.CreateCustomLogSourceResponse CallAWSServiceOperation(IAmazonSecurityLake client, Amazon.SecurityLake.Model.CreateCustomLogSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Security Lake", "CreateCustomLogSource");
            try
            {
                #if DESKTOP
                return client.CreateCustomLogSource(request);
                #elif CORECLR
                return client.CreateCustomLogSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String CrawlerConfiguration_RoleArn { get; set; }
            public System.String ProviderIdentity_ExternalId { get; set; }
            public System.String ProviderIdentity_Principal { get; set; }
            public List<System.String> EventClass { get; set; }
            public System.String SourceName { get; set; }
            public System.String SourceVersion { get; set; }
            public System.Func<Amazon.SecurityLake.Model.CreateCustomLogSourceResponse, NewSLKCustomLogSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
