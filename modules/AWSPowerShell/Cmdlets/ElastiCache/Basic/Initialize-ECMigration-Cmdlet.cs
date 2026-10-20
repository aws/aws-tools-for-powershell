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
using Amazon.ElastiCache;
using Amazon.ElastiCache.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC
{
    /// <summary>
    /// Prepares the serverless cache for data migration by validating the configuration and
    /// setting up the migration resources.
    /// </summary>
    [Cmdlet("Initialize", "ECMigration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElastiCache.Model.ServerlessCache")]
    [AWSCmdlet("Calls the Amazon ElastiCache PrepareMigration API operation.", Operation = new[] {"PrepareMigration"}, SelectReturnType = typeof(Amazon.ElastiCache.Model.PrepareMigrationResponse))]
    [AWSCmdletOutput("Amazon.ElastiCache.Model.ServerlessCache or Amazon.ElastiCache.Model.PrepareMigrationResponse",
        "This cmdlet returns an Amazon.ElastiCache.Model.ServerlessCache object.",
        "The service call response (type Amazon.ElastiCache.Model.PrepareMigrationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InitializeECMigrationCmdlet : AmazonElastiCacheClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CustomerNodeEndpointList
        /// <summary>
        /// <para>
        /// <para>The list of endpoints from which to migrate data. For serverless cache migrations,
        /// the list should have only one element.</para><para />
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
        public Amazon.ElastiCache.Model.CustomerNodeEndpoint[] CustomerNodeEndpointList { get; set; }
        #endregion
        
        #region Parameter SourceAuthenticationConfiguration_SecretManagerConfig_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the secret in AWS Secrets Manager that contains the credentials for authenticating
        /// with the source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceAuthenticationConfiguration_SecretManagerConfig_SecretArn { get; set; }
        #endregion
        
        #region Parameter ServerlessCacheName
        /// <summary>
        /// <para>
        /// <para>The name of the serverless cache to prepare for migration.</para>
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
        public System.String ServerlessCacheName { get; set; }
        #endregion
        
        #region Parameter SourceTlsConfiguration_SourceTlsCertificate
        /// <summary>
        /// <para>
        /// <para>The TLS certificate used to verify the identity of the source during migration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceTlsConfiguration_SourceTlsCertificate { get; set; }
        #endregion
        
        #region Parameter SourceTlsConfiguration_SourceTlsMode
        /// <summary>
        /// <para>
        /// <para>The TLS mode to use when connecting to the source. Valid values are <c>none</c> and
        /// <c>verify-ca</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElastiCache.TlsMode")]
        public Amazon.ElastiCache.TlsMode SourceTlsConfiguration_SourceTlsMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ServerlessCache'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElastiCache.Model.PrepareMigrationResponse).
        /// Specifying the name of a property of type Amazon.ElastiCache.Model.PrepareMigrationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ServerlessCache";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ServerlessCacheName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Initialize-ECMigration (PrepareMigration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElastiCache.Model.PrepareMigrationResponse, InitializeECMigrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CustomerNodeEndpointList != null)
            {
                context.CustomerNodeEndpointList = new List<Amazon.ElastiCache.Model.CustomerNodeEndpoint>(this.CustomerNodeEndpointList);
            }
            #if MODULAR
            if (this.CustomerNodeEndpointList == null && ParameterWasBound(nameof(this.CustomerNodeEndpointList)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomerNodeEndpointList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerlessCacheName = this.ServerlessCacheName;
            #if MODULAR
            if (this.ServerlessCacheName == null && ParameterWasBound(nameof(this.ServerlessCacheName)))
            {
                WriteWarning("You are passing $null as a value for parameter ServerlessCacheName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SourceAuthenticationConfiguration_SecretManagerConfig_SecretArn = this.SourceAuthenticationConfiguration_SecretManagerConfig_SecretArn;
            context.SourceTlsConfiguration_SourceTlsCertificate = this.SourceTlsConfiguration_SourceTlsCertificate;
            context.SourceTlsConfiguration_SourceTlsMode = this.SourceTlsConfiguration_SourceTlsMode;
            
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
            var request = new Amazon.ElastiCache.Model.PrepareMigrationRequest();
            
            if (cmdletContext.CustomerNodeEndpointList != null)
            {
                request.CustomerNodeEndpointList = cmdletContext.CustomerNodeEndpointList;
            }
            if (cmdletContext.ServerlessCacheName != null)
            {
                request.ServerlessCacheName = cmdletContext.ServerlessCacheName;
            }
            
             // populate SourceAuthenticationConfiguration
            var requestSourceAuthenticationConfigurationIsNull = true;
            request.SourceAuthenticationConfiguration = new Amazon.ElastiCache.Model.SourceAuthenticationConfiguration();
            Amazon.ElastiCache.Model.SecretManagerAuthConfig requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig = null;
            
             // populate SecretManagerConfig
            var requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfigIsNull = true;
            requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig = new Amazon.ElastiCache.Model.SecretManagerAuthConfig();
            System.String requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig_sourceAuthenticationConfiguration_SecretManagerConfig_SecretArn = null;
            if (cmdletContext.SourceAuthenticationConfiguration_SecretManagerConfig_SecretArn != null)
            {
                requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig_sourceAuthenticationConfiguration_SecretManagerConfig_SecretArn = cmdletContext.SourceAuthenticationConfiguration_SecretManagerConfig_SecretArn;
            }
            if (requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig_sourceAuthenticationConfiguration_SecretManagerConfig_SecretArn != null)
            {
                requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig.SecretArn = requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig_sourceAuthenticationConfiguration_SecretManagerConfig_SecretArn;
                requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfigIsNull = false;
            }
             // determine if requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig should be set to null
            if (requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfigIsNull)
            {
                requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig = null;
            }
            if (requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig != null)
            {
                request.SourceAuthenticationConfiguration.SecretManagerConfig = requestSourceAuthenticationConfiguration_sourceAuthenticationConfiguration_SecretManagerConfig;
                requestSourceAuthenticationConfigurationIsNull = false;
            }
             // determine if request.SourceAuthenticationConfiguration should be set to null
            if (requestSourceAuthenticationConfigurationIsNull)
            {
                request.SourceAuthenticationConfiguration = null;
            }
            
             // populate SourceTlsConfiguration
            var requestSourceTlsConfigurationIsNull = true;
            request.SourceTlsConfiguration = new Amazon.ElastiCache.Model.SourceTlsConfiguration();
            System.String requestSourceTlsConfiguration_sourceTlsConfiguration_SourceTlsCertificate = null;
            if (cmdletContext.SourceTlsConfiguration_SourceTlsCertificate != null)
            {
                requestSourceTlsConfiguration_sourceTlsConfiguration_SourceTlsCertificate = cmdletContext.SourceTlsConfiguration_SourceTlsCertificate;
            }
            if (requestSourceTlsConfiguration_sourceTlsConfiguration_SourceTlsCertificate != null)
            {
                request.SourceTlsConfiguration.SourceTlsCertificate = requestSourceTlsConfiguration_sourceTlsConfiguration_SourceTlsCertificate;
                requestSourceTlsConfigurationIsNull = false;
            }
            Amazon.ElastiCache.TlsMode requestSourceTlsConfiguration_sourceTlsConfiguration_SourceTlsMode = null;
            if (cmdletContext.SourceTlsConfiguration_SourceTlsMode != null)
            {
                requestSourceTlsConfiguration_sourceTlsConfiguration_SourceTlsMode = cmdletContext.SourceTlsConfiguration_SourceTlsMode;
            }
            if (requestSourceTlsConfiguration_sourceTlsConfiguration_SourceTlsMode != null)
            {
                request.SourceTlsConfiguration.SourceTlsMode = requestSourceTlsConfiguration_sourceTlsConfiguration_SourceTlsMode;
                requestSourceTlsConfigurationIsNull = false;
            }
             // determine if request.SourceTlsConfiguration should be set to null
            if (requestSourceTlsConfigurationIsNull)
            {
                request.SourceTlsConfiguration = null;
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
        
        private Amazon.ElastiCache.Model.PrepareMigrationResponse CallAWSServiceOperation(IAmazonElastiCache client, Amazon.ElastiCache.Model.PrepareMigrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon ElastiCache", "PrepareMigration");
            try
            {
                return client.PrepareMigrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ElastiCache.Model.CustomerNodeEndpoint> CustomerNodeEndpointList { get; set; }
            public System.String ServerlessCacheName { get; set; }
            public System.String SourceAuthenticationConfiguration_SecretManagerConfig_SecretArn { get; set; }
            public System.String SourceTlsConfiguration_SourceTlsCertificate { get; set; }
            public Amazon.ElastiCache.TlsMode SourceTlsConfiguration_SourceTlsMode { get; set; }
            public System.Func<Amazon.ElastiCache.Model.PrepareMigrationResponse, InitializeECMigrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ServerlessCache;
        }
        
    }
}
