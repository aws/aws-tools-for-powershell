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
    /// Creates a scan configuration for code security scanning.
    /// </summary>
    [Cmdlet("New", "INS2CodeSecurityScanConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Inspector2 CreateCodeSecurityScanConfiguration API operation.", Operation = new[] {"CreateCodeSecurityScanConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewINS2CodeSecurityScanConfigurationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PeriodicScanConfiguration_Frequency
        /// <summary>
        /// <para>
        /// <para>The frequency at which periodic scans are performed (such as weekly or monthly).</para><para>If you don't provide the <c>frequencyExpression</c> Amazon Inspector chooses day for
        /// the scan to run. If you provide the <c>frequencyExpression</c>, the schedule must
        /// match the specified <c>frequency</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_PeriodicScanConfiguration_Frequency")]
        [AWSConstantClassSource("Amazon.Inspector2.PeriodicScanFrequency")]
        public Amazon.Inspector2.PeriodicScanFrequency PeriodicScanConfiguration_Frequency { get; set; }
        #endregion
        
        #region Parameter PeriodicScanConfiguration_FrequencyExpression
        /// <summary>
        /// <para>
        /// <para>The schedule expression for periodic scans, in cron format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_PeriodicScanConfiguration_FrequencyExpression")]
        public System.String PeriodicScanConfiguration_FrequencyExpression { get; set; }
        #endregion
        
        #region Parameter Level
        /// <summary>
        /// <para>
        /// <para>The security level for the scan configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector2.ConfigurationLevel")]
        public Amazon.Inspector2.ConfigurationLevel Level { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the scan configuration.</para>
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
        
        #region Parameter ScopeSettings_ProjectSelectionScope
        /// <summary>
        /// <para>
        /// <para>The scope of projects to be selected for scanning within the integrated repositories.
        /// Setting the value to <c>ALL</c> applies the scope settings to all existing and future
        /// projects imported into Amazon Inspector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.ProjectSelectionScope")]
        public Amazon.Inspector2.ProjectSelectionScope ScopeSettings_ProjectSelectionScope { get; set; }
        #endregion
        
        #region Parameter Configuration_RuleSetCategory
        /// <summary>
        /// <para>
        /// <para>The categories of security rules to be applied during the scan.</para><para />
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
        [Alias("Configuration_RuleSetCategories")]
        public System.String[] Configuration_RuleSetCategory { get; set; }
        #endregion
        
        #region Parameter ContinuousIntegrationScanConfiguration_SupportedEvent
        /// <summary>
        /// <para>
        /// <para>The repository events that trigger continuous integration scans, such as pull requests
        /// or commits.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ContinuousIntegrationScanConfiguration_SupportedEvents")]
        public System.String[] ContinuousIntegrationScanConfiguration_SupportedEvent { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the scan configuration.</para><para />
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScanConfigurationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScanConfigurationArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INS2CodeSecurityScanConfiguration (CreateCodeSecurityScanConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationResponse, NewINS2CodeSecurityScanConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ContinuousIntegrationScanConfiguration_SupportedEvent != null)
            {
                context.ContinuousIntegrationScanConfiguration_SupportedEvent = new List<System.String>(this.ContinuousIntegrationScanConfiguration_SupportedEvent);
            }
            context.PeriodicScanConfiguration_Frequency = this.PeriodicScanConfiguration_Frequency;
            context.PeriodicScanConfiguration_FrequencyExpression = this.PeriodicScanConfiguration_FrequencyExpression;
            if (this.Configuration_RuleSetCategory != null)
            {
                context.Configuration_RuleSetCategory = new List<System.String>(this.Configuration_RuleSetCategory);
            }
            #if MODULAR
            if (this.Configuration_RuleSetCategory == null && ParameterWasBound(nameof(this.Configuration_RuleSetCategory)))
            {
                WriteWarning("You are passing $null as a value for parameter Configuration_RuleSetCategory which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Level = this.Level;
            #if MODULAR
            if (this.Level == null && ParameterWasBound(nameof(this.Level)))
            {
                WriteWarning("You are passing $null as a value for parameter Level which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScopeSettings_ProjectSelectionScope = this.ScopeSettings_ProjectSelectionScope;
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.Inspector2.Model.CodeSecurityScanConfiguration();
            List<System.String> requestConfiguration_configuration_RuleSetCategory = null;
            if (cmdletContext.Configuration_RuleSetCategory != null)
            {
                requestConfiguration_configuration_RuleSetCategory = cmdletContext.Configuration_RuleSetCategory;
            }
            if (requestConfiguration_configuration_RuleSetCategory != null)
            {
                request.Configuration.RuleSetCategories = requestConfiguration_configuration_RuleSetCategory;
                requestConfigurationIsNull = false;
            }
            Amazon.Inspector2.Model.ContinuousIntegrationScanConfiguration requestConfiguration_configuration_ContinuousIntegrationScanConfiguration = null;
            
             // populate ContinuousIntegrationScanConfiguration
            var requestConfiguration_configuration_ContinuousIntegrationScanConfigurationIsNull = true;
            requestConfiguration_configuration_ContinuousIntegrationScanConfiguration = new Amazon.Inspector2.Model.ContinuousIntegrationScanConfiguration();
            List<System.String> requestConfiguration_configuration_ContinuousIntegrationScanConfiguration_continuousIntegrationScanConfiguration_SupportedEvent = null;
            if (cmdletContext.ContinuousIntegrationScanConfiguration_SupportedEvent != null)
            {
                requestConfiguration_configuration_ContinuousIntegrationScanConfiguration_continuousIntegrationScanConfiguration_SupportedEvent = cmdletContext.ContinuousIntegrationScanConfiguration_SupportedEvent;
            }
            if (requestConfiguration_configuration_ContinuousIntegrationScanConfiguration_continuousIntegrationScanConfiguration_SupportedEvent != null)
            {
                requestConfiguration_configuration_ContinuousIntegrationScanConfiguration.SupportedEvents = requestConfiguration_configuration_ContinuousIntegrationScanConfiguration_continuousIntegrationScanConfiguration_SupportedEvent;
                requestConfiguration_configuration_ContinuousIntegrationScanConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_ContinuousIntegrationScanConfiguration should be set to null
            if (requestConfiguration_configuration_ContinuousIntegrationScanConfigurationIsNull)
            {
                requestConfiguration_configuration_ContinuousIntegrationScanConfiguration = null;
            }
            if (requestConfiguration_configuration_ContinuousIntegrationScanConfiguration != null)
            {
                request.Configuration.ContinuousIntegrationScanConfiguration = requestConfiguration_configuration_ContinuousIntegrationScanConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.Inspector2.Model.PeriodicScanConfiguration requestConfiguration_configuration_PeriodicScanConfiguration = null;
            
             // populate PeriodicScanConfiguration
            var requestConfiguration_configuration_PeriodicScanConfigurationIsNull = true;
            requestConfiguration_configuration_PeriodicScanConfiguration = new Amazon.Inspector2.Model.PeriodicScanConfiguration();
            Amazon.Inspector2.PeriodicScanFrequency requestConfiguration_configuration_PeriodicScanConfiguration_periodicScanConfiguration_Frequency = null;
            if (cmdletContext.PeriodicScanConfiguration_Frequency != null)
            {
                requestConfiguration_configuration_PeriodicScanConfiguration_periodicScanConfiguration_Frequency = cmdletContext.PeriodicScanConfiguration_Frequency;
            }
            if (requestConfiguration_configuration_PeriodicScanConfiguration_periodicScanConfiguration_Frequency != null)
            {
                requestConfiguration_configuration_PeriodicScanConfiguration.Frequency = requestConfiguration_configuration_PeriodicScanConfiguration_periodicScanConfiguration_Frequency;
                requestConfiguration_configuration_PeriodicScanConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_PeriodicScanConfiguration_periodicScanConfiguration_FrequencyExpression = null;
            if (cmdletContext.PeriodicScanConfiguration_FrequencyExpression != null)
            {
                requestConfiguration_configuration_PeriodicScanConfiguration_periodicScanConfiguration_FrequencyExpression = cmdletContext.PeriodicScanConfiguration_FrequencyExpression;
            }
            if (requestConfiguration_configuration_PeriodicScanConfiguration_periodicScanConfiguration_FrequencyExpression != null)
            {
                requestConfiguration_configuration_PeriodicScanConfiguration.FrequencyExpression = requestConfiguration_configuration_PeriodicScanConfiguration_periodicScanConfiguration_FrequencyExpression;
                requestConfiguration_configuration_PeriodicScanConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_PeriodicScanConfiguration should be set to null
            if (requestConfiguration_configuration_PeriodicScanConfigurationIsNull)
            {
                requestConfiguration_configuration_PeriodicScanConfiguration = null;
            }
            if (requestConfiguration_configuration_PeriodicScanConfiguration != null)
            {
                request.Configuration.PeriodicScanConfiguration = requestConfiguration_configuration_PeriodicScanConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Level != null)
            {
                request.Level = cmdletContext.Level;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ScopeSettings
            var requestScopeSettingsIsNull = true;
            request.ScopeSettings = new Amazon.Inspector2.Model.ScopeSettings();
            Amazon.Inspector2.ProjectSelectionScope requestScopeSettings_scopeSettings_ProjectSelectionScope = null;
            if (cmdletContext.ScopeSettings_ProjectSelectionScope != null)
            {
                requestScopeSettings_scopeSettings_ProjectSelectionScope = cmdletContext.ScopeSettings_ProjectSelectionScope;
            }
            if (requestScopeSettings_scopeSettings_ProjectSelectionScope != null)
            {
                request.ScopeSettings.ProjectSelectionScope = requestScopeSettings_scopeSettings_ProjectSelectionScope;
                requestScopeSettingsIsNull = false;
            }
             // determine if request.ScopeSettings should be set to null
            if (requestScopeSettingsIsNull)
            {
                request.ScopeSettings = null;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "CreateCodeSecurityScanConfiguration");
            try
            {
                return client.CreateCodeSecurityScanConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> ContinuousIntegrationScanConfiguration_SupportedEvent { get; set; }
            public Amazon.Inspector2.PeriodicScanFrequency PeriodicScanConfiguration_Frequency { get; set; }
            public System.String PeriodicScanConfiguration_FrequencyExpression { get; set; }
            public List<System.String> Configuration_RuleSetCategory { get; set; }
            public Amazon.Inspector2.ConfigurationLevel Level { get; set; }
            public System.String Name { get; set; }
            public Amazon.Inspector2.ProjectSelectionScope ScopeSettings_ProjectSelectionScope { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Inspector2.Model.CreateCodeSecurityScanConfigurationResponse, NewINS2CodeSecurityScanConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScanConfigurationArn;
        }
        
    }
}
