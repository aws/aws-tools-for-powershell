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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Updates an existing code security scan configuration.
    /// </summary>
    [Cmdlet("Update", "INS2CodeSecurityScanConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Inspector2 UpdateCodeSecurityScanConfiguration API operation.", Operation = new[] {"UpdateCodeSecurityScanConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateINS2CodeSecurityScanConfigurationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter Configuration_RuleSetCategory
        /// <summary>
        /// <para>
        /// <para>The categories of security rules to be applied during the scan.</para>
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
        
        #region Parameter ScanConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the scan configuration to update.</para>
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
        public System.String ScanConfigurationArn { get; set; }
        #endregion
        
        #region Parameter ContinuousIntegrationScanConfiguration_SupportedEvent
        /// <summary>
        /// <para>
        /// <para>The repository events that trigger continuous integration scans, such as pull requests
        /// or commits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ContinuousIntegrationScanConfiguration_SupportedEvents")]
        public System.String[] ContinuousIntegrationScanConfiguration_SupportedEvent { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScanConfigurationArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScanConfigurationArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScanConfigurationArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScanConfigurationArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScanConfigurationArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScanConfigurationArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2CodeSecurityScanConfiguration (UpdateCodeSecurityScanConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationResponse, UpdateINS2CodeSecurityScanConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScanConfigurationArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.ScanConfigurationArn = this.ScanConfigurationArn;
            #if MODULAR
            if (this.ScanConfigurationArn == null && ParameterWasBound(nameof(this.ScanConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationRequest();
            
            
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
            if (cmdletContext.ScanConfigurationArn != null)
            {
                request.ScanConfigurationArn = cmdletContext.ScanConfigurationArn;
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
        
        private Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateCodeSecurityScanConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateCodeSecurityScanConfiguration(request);
                #elif CORECLR
                return client.UpdateCodeSecurityScanConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ContinuousIntegrationScanConfiguration_SupportedEvent { get; set; }
            public Amazon.Inspector2.PeriodicScanFrequency PeriodicScanConfiguration_Frequency { get; set; }
            public System.String PeriodicScanConfiguration_FrequencyExpression { get; set; }
            public List<System.String> Configuration_RuleSetCategory { get; set; }
            public System.String ScanConfigurationArn { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateCodeSecurityScanConfigurationResponse, UpdateINS2CodeSecurityScanConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScanConfigurationArn;
        }
        
    }
}
