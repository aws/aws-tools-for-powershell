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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Adds or updates the remediation configuration with a specific Config rule with the
    /// selected target or action. The API creates the <c>RemediationConfiguration</c> object
    /// for the Config rule. The Config rule must already exist for you to add a remediation
    /// configuration. The target (SSM document) must exist and have permissions to use the
    /// target. 
    /// 
    ///  <note><para>
    /// If you make backward incompatible changes to the SSM document, you must call this
    /// again to ensure the remediations can run.
    /// </para><para>
    /// This API does not support adding remediation configurations for service-linked Config
    /// Rules such as Organization Config rules, the rules deployed by conformance packs,
    /// and rules deployed by Amazon Web Services Security Hub.
    /// </para></note><note><para>
    /// For manual remediation configuration, you need to provide a value for <c>automationAssumeRole</c>
    /// or use a value in the <c>assumeRole</c>field to remediate your resources. The SSM
    /// automation document can use either as long as it maps to a valid parameter.
    /// </para><para>
    /// However, for automatic remediation configuration, the only valid <c>assumeRole</c>
    /// field value is <c>AutomationAssumeRole</c> and you need to provide a value for <c>AutomationAssumeRole</c>
    /// to remediate your resources.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGRemediationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ConfigService.Model.FailedRemediationBatch")]
    [AWSCmdlet("Calls the AWS Config PutRemediationConfigurations API operation.", Operation = new[] {"PutRemediationConfigurations"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutRemediationConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.FailedRemediationBatch or Amazon.ConfigService.Model.PutRemediationConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.FailedRemediationBatch objects.",
        "The service call response (type Amazon.ConfigService.Model.PutRemediationConfigurationsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCFGRemediationConfigurationCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RemediationConfiguration
        /// <summary>
        /// <para>
        /// <para>A list of remediation configuration objects.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RemediationConfigurations")]
        public Amazon.ConfigService.Model.RemediationConfiguration[] RemediationConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedBatches'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutRemediationConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutRemediationConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedBatches";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RemediationConfiguration parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RemediationConfiguration' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RemediationConfiguration' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RemediationConfiguration), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGRemediationConfiguration (PutRemediationConfigurations)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutRemediationConfigurationsResponse, WriteCFGRemediationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RemediationConfiguration;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.RemediationConfiguration != null)
            {
                context.RemediationConfiguration = new List<Amazon.ConfigService.Model.RemediationConfiguration>(this.RemediationConfiguration);
            }
            #if MODULAR
            if (this.RemediationConfiguration == null && ParameterWasBound(nameof(this.RemediationConfiguration)))
            {
                WriteWarning("You are passing $null as a value for parameter RemediationConfiguration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ConfigService.Model.PutRemediationConfigurationsRequest();
            
            if (cmdletContext.RemediationConfiguration != null)
            {
                request.RemediationConfigurations = cmdletContext.RemediationConfiguration;
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
        
        private Amazon.ConfigService.Model.PutRemediationConfigurationsResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutRemediationConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutRemediationConfigurations");
            try
            {
                #if DESKTOP
                return client.PutRemediationConfigurations(request);
                #elif CORECLR
                return client.PutRemediationConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ConfigService.Model.RemediationConfiguration> RemediationConfiguration { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutRemediationConfigurationsResponse, WriteCFGRemediationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedBatches;
        }
        
    }
}
