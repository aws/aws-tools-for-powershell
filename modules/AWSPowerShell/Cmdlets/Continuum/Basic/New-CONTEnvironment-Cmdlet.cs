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
using Amazon.Continuum;
using Amazon.Continuum.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONT
{
    /// <summary>
    /// Creates an environment and starts its validation and any requested provisioning. Storage
    /// provisioning and dependency checks may continue after the initial 201 response; use
    /// GetEnvironment to observe completion.
    /// </summary>
    [Cmdlet("New", "CONTEnvironment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Continuum.Model.CreateEnvironmentResponse")]
    [AWSCmdlet("Calls the AWS Continuum CreateEnvironment API operation.", Operation = new[] {"CreateEnvironment"}, SelectReturnType = typeof(Amazon.Continuum.Model.CreateEnvironmentResponse))]
    [AWSCmdletOutput("Amazon.Continuum.Model.CreateEnvironmentResponse",
        "This cmdlet returns an Amazon.Continuum.Model.CreateEnvironmentResponse object containing multiple properties."
    )]
    public partial class NewCONTEnvironmentCmdlet : AmazonContinuumClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain
        /// <summary>
        /// <para>
        /// Domains that an environment's agent execution
        /// may contact.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomains")]
        public System.String[] Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The customer-visible name of the environment.
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
        
        #region Parameter Configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy
        /// <summary>
        /// <para>
        /// Whether Continuum creates a patch
        /// for a proposed remediation. Defaults to DISABLED.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Continuum.PatchCreationPolicy")]
        public Amazon.Continuum.PatchCreationPolicy Configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy { get; set; }
        #endregion
        
        #region Parameter Configuration_CodeConfiguration_SourceConfiguration_RepositorySource
        /// <summary>
        /// <para>
        /// Explicit repository selections from
        /// previously-created integrations.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CodeConfiguration_SourceConfiguration_RepositorySources")]
        public Amazon.Continuum.Model.EnvironmentRepositorySource[] Configuration_CodeConfiguration_SourceConfiguration_RepositorySource { get; set; }
        #endregion
        
        #region Parameter Configuration_CodeConfiguration_SourceConfiguration_S3Source
        /// <summary>
        /// <para>
        /// S3 sources backed by previously-created S3 integrations.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_CodeConfiguration_SourceConfiguration_S3Sources")]
        public Amazon.Continuum.Model.EnvironmentS3IntegrationSource[] Configuration_CodeConfiguration_SourceConfiguration_S3Source { get; set; }
        #endregion
        
        #region Parameter Configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency
        /// <summary>
        /// <para>
        /// Recurring scan interval: P1D (1 day), P2D
        /// (2 days), or P7D (7 days). PT0H disables recurring scans. Defaults to P1D when creating
        /// an environment.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Continuum.Model.CreateEnvironmentResponse).
        /// Specifying the name of a property of type Amazon.Continuum.Model.CreateEnvironmentResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONTEnvironment (CreateEnvironment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Continuum.Model.CreateEnvironmentResponse, NewCONTEnvironmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain != null)
            {
                context.Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain = new List<System.String>(this.Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain);
            }
            context.Configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy = this.Configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy;
            context.Configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency = this.Configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency;
            if (this.Configuration_CodeConfiguration_SourceConfiguration_RepositorySource != null)
            {
                context.Configuration_CodeConfiguration_SourceConfiguration_RepositorySource = new List<Amazon.Continuum.Model.EnvironmentRepositorySource>(this.Configuration_CodeConfiguration_SourceConfiguration_RepositorySource);
            }
            if (this.Configuration_CodeConfiguration_SourceConfiguration_S3Source != null)
            {
                context.Configuration_CodeConfiguration_SourceConfiguration_S3Source = new List<Amazon.Continuum.Model.EnvironmentS3IntegrationSource>(this.Configuration_CodeConfiguration_SourceConfiguration_S3Source);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Continuum.Model.CreateEnvironmentRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Continuum.Model.CreateEnvironmentConfiguration();
            Amazon.Continuum.Model.CreateCodeConfiguration requestConfiguration_configuration_CodeConfiguration = null;
            
             // populate CodeConfiguration
            var requestConfiguration_configuration_CodeConfigurationIsNull = true;
            requestConfiguration_configuration_CodeConfiguration = new Amazon.Continuum.Model.CreateCodeConfiguration();
            Amazon.Continuum.Model.EnvironmentSourceConfiguration requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration = null;
            
             // populate SourceConfiguration
            var requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfigurationIsNull = true;
            requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration = new Amazon.Continuum.Model.EnvironmentSourceConfiguration();
            List<Amazon.Continuum.Model.EnvironmentRepositorySource> requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration_configuration_CodeConfiguration_SourceConfiguration_RepositorySource = null;
            if (cmdletContext.Configuration_CodeConfiguration_SourceConfiguration_RepositorySource != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration_configuration_CodeConfiguration_SourceConfiguration_RepositorySource = cmdletContext.Configuration_CodeConfiguration_SourceConfiguration_RepositorySource;
            }
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration_configuration_CodeConfiguration_SourceConfiguration_RepositorySource != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration.RepositorySources = requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration_configuration_CodeConfiguration_SourceConfiguration_RepositorySource;
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfigurationIsNull = false;
            }
            List<Amazon.Continuum.Model.EnvironmentS3IntegrationSource> requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration_configuration_CodeConfiguration_SourceConfiguration_S3Source = null;
            if (cmdletContext.Configuration_CodeConfiguration_SourceConfiguration_S3Source != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration_configuration_CodeConfiguration_SourceConfiguration_S3Source = cmdletContext.Configuration_CodeConfiguration_SourceConfiguration_S3Source;
            }
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration_configuration_CodeConfiguration_SourceConfiguration_S3Source != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration.S3Sources = requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration_configuration_CodeConfiguration_SourceConfiguration_S3Source;
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration should be set to null
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfigurationIsNull)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration = null;
            }
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration != null)
            {
                requestConfiguration_configuration_CodeConfiguration.SourceConfiguration = requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_SourceConfiguration;
                requestConfiguration_configuration_CodeConfigurationIsNull = false;
            }
            Amazon.Continuum.Model.EnvironmentConfiguration requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration = null;
            
             // populate EnvironmentConfiguration
            var requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfigurationIsNull = true;
            requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration = new Amazon.Continuum.Model.EnvironmentConfiguration();
            Amazon.Continuum.PatchCreationPolicy requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy = null;
            if (cmdletContext.Configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy = cmdletContext.Configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy;
            }
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration.PatchCreationPolicy = requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy;
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency = null;
            if (cmdletContext.Configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency = cmdletContext.Configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency;
            }
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration.ScanFrequency = requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency;
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfigurationIsNull = false;
            }
            Amazon.Continuum.Model.EnvironmentNetworkConfiguration requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network = null;
            
             // populate Network
            var requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_NetworkIsNull = true;
            requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network = new Amazon.Continuum.Model.EnvironmentNetworkConfiguration();
            List<System.String> requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network_configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain = null;
            if (cmdletContext.Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network_configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain = cmdletContext.Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain;
            }
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network_configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network.AllowedDomains = requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network_configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain;
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_NetworkIsNull = false;
            }
             // determine if requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network should be set to null
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_NetworkIsNull)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network = null;
            }
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network != null)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration.Network = requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration_Network;
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration should be set to null
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfigurationIsNull)
            {
                requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration = null;
            }
            if (requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration != null)
            {
                requestConfiguration_configuration_CodeConfiguration.EnvironmentConfiguration = requestConfiguration_configuration_CodeConfiguration_configuration_CodeConfiguration_EnvironmentConfiguration;
                requestConfiguration_configuration_CodeConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_CodeConfiguration should be set to null
            if (requestConfiguration_configuration_CodeConfigurationIsNull)
            {
                requestConfiguration_configuration_CodeConfiguration = null;
            }
            if (requestConfiguration_configuration_CodeConfiguration != null)
            {
                request.Configuration.CodeConfiguration = requestConfiguration_configuration_CodeConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.Continuum.Model.CreateEnvironmentResponse CallAWSServiceOperation(IAmazonContinuum client, Amazon.Continuum.Model.CreateEnvironmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Continuum", "CreateEnvironment");
            try
            {
                return client.CreateEnvironmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> Configuration_CodeConfiguration_EnvironmentConfiguration_Network_AllowedDomain { get; set; }
            public Amazon.Continuum.PatchCreationPolicy Configuration_CodeConfiguration_EnvironmentConfiguration_PatchCreationPolicy { get; set; }
            public System.String Configuration_CodeConfiguration_EnvironmentConfiguration_ScanFrequency { get; set; }
            public List<Amazon.Continuum.Model.EnvironmentRepositorySource> Configuration_CodeConfiguration_SourceConfiguration_RepositorySource { get; set; }
            public List<Amazon.Continuum.Model.EnvironmentS3IntegrationSource> Configuration_CodeConfiguration_SourceConfiguration_S3Source { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.Continuum.Model.CreateEnvironmentResponse, NewCONTEnvironmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
