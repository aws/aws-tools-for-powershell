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
using Amazon.Elasticsearch;
using Amazon.Elasticsearch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ES
{
    /// <summary>
    /// Allows you to either upgrade your domain or perform an Upgrade eligibility check to
    /// a compatible Elasticsearch version.
    /// </summary>
    [Cmdlet("Update", "ESElasticsearchDomain", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse")]
    [AWSCmdlet("Calls the Amazon Elasticsearch UpgradeElasticsearchDomain API operation.", Operation = new[] {"UpgradeElasticsearchDomain"}, SelectReturnType = typeof(Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse))]
    [AWSCmdletOutput("Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse",
        "This cmdlet returns an Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse object containing multiple properties."
    )]
    public partial class UpdateESElasticsearchDomainCmdlet : AmazonElasticsearchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeploymentStrategyOptions_DeploymentStrategy
        /// <summary>
        /// <para>
        /// <para>The deployment strategy to use for this operation. The only valid value is <c>ClonedBlueGreen</c>,
        /// which creates a cloned cluster on the target version next to the primary cluster so
        /// that you can validate it and shift traffic to it before you cut over.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Elasticsearch.DeploymentStrategyOverride")]
        public Amazon.Elasticsearch.DeploymentStrategyOverride DeploymentStrategyOptions_DeploymentStrategy { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter PerformCheckOnly
        /// <summary>
        /// <para>
        /// <para> This flag, when set to True, indicates that an Upgrade Eligibility Check needs to
        /// be performed. This will not actually perform the Upgrade. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PerformCheckOnly { get; set; }
        #endregion
        
        #region Parameter DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction
        /// <summary>
        /// <para>
        /// <para>Ends the retention period now. Valid only after cutover completes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Elasticsearch.RetentionAction")]
        public Amazon.Elasticsearch.RetentionAction DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction { get; set; }
        #endregion
        
        #region Parameter DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour
        /// <summary>
        /// <para>
        /// <para>The number of hours to keep the cluster that you cut over from. The retention period
        /// starts when cutover completes. The minimum is 1 hour. In an <c>UpdateClone</c> response
        /// after cutover completes, this value is the number of hours remaining in the retention
        /// period, rounded up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHours")]
        public System.Int32? DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour { get; set; }
        #endregion
        
        #region Parameter TargetVersion
        /// <summary>
        /// <para>
        /// <para>The version of Elasticsearch that you intend to upgrade the domain to.</para>
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
        public System.String TargetVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse).
        /// Specifying the name of a property of type Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DomainName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ESElasticsearchDomain (UpgradeElasticsearchDomain)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse, UpdateESElasticsearchDomainCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction = this.DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction;
            context.DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour = this.DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour;
            context.DeploymentStrategyOptions_DeploymentStrategy = this.DeploymentStrategyOptions_DeploymentStrategy;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PerformCheckOnly = this.PerformCheckOnly;
            context.TargetVersion = this.TargetVersion;
            #if MODULAR
            if (this.TargetVersion == null && ParameterWasBound(nameof(this.TargetVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainRequest();
            
            
             // populate DeploymentStrategyOptions
            var requestDeploymentStrategyOptionsIsNull = true;
            request.DeploymentStrategyOptions = new Amazon.Elasticsearch.Model.DeploymentStrategyOverrideOptions();
            Amazon.Elasticsearch.DeploymentStrategyOverride requestDeploymentStrategyOptions_deploymentStrategyOptions_DeploymentStrategy = null;
            if (cmdletContext.DeploymentStrategyOptions_DeploymentStrategy != null)
            {
                requestDeploymentStrategyOptions_deploymentStrategyOptions_DeploymentStrategy = cmdletContext.DeploymentStrategyOptions_DeploymentStrategy;
            }
            if (requestDeploymentStrategyOptions_deploymentStrategyOptions_DeploymentStrategy != null)
            {
                request.DeploymentStrategyOptions.DeploymentStrategy = requestDeploymentStrategyOptions_deploymentStrategyOptions_DeploymentStrategy;
                requestDeploymentStrategyOptionsIsNull = false;
            }
            Amazon.Elasticsearch.Model.ClonedBlueGreenOptions requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions = null;
            
             // populate ClonedBlueGreenOptions
            var requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptionsIsNull = true;
            requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions = new Amazon.Elasticsearch.Model.ClonedBlueGreenOptions();
            Amazon.Elasticsearch.Model.RetentionOptions requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions = null;
            
             // populate RetentionOptions
            var requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptionsIsNull = true;
            requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions = new Amazon.Elasticsearch.Model.RetentionOptions();
            Amazon.Elasticsearch.RetentionAction requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction = null;
            if (cmdletContext.DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction != null)
            {
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction = cmdletContext.DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction;
            }
            if (requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction != null)
            {
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions.RetentionAction = requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction;
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptionsIsNull = false;
            }
            System.Int32? requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour = null;
            if (cmdletContext.DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour != null)
            {
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour = cmdletContext.DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour.Value;
            }
            if (requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour != null)
            {
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions.RetentionInHours = requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour.Value;
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptionsIsNull = false;
            }
             // determine if requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions should be set to null
            if (requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptionsIsNull)
            {
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions = null;
            }
            if (requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions != null)
            {
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions.RetentionOptions = requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_deploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions;
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptionsIsNull = false;
            }
             // determine if requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions should be set to null
            if (requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptionsIsNull)
            {
                requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions = null;
            }
            if (requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions != null)
            {
                request.DeploymentStrategyOptions.ClonedBlueGreenOptions = requestDeploymentStrategyOptions_deploymentStrategyOptions_ClonedBlueGreenOptions;
                requestDeploymentStrategyOptionsIsNull = false;
            }
             // determine if request.DeploymentStrategyOptions should be set to null
            if (requestDeploymentStrategyOptionsIsNull)
            {
                request.DeploymentStrategyOptions = null;
            }
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.PerformCheckOnly != null)
            {
                request.PerformCheckOnly = cmdletContext.PerformCheckOnly.Value;
            }
            if (cmdletContext.TargetVersion != null)
            {
                request.TargetVersion = cmdletContext.TargetVersion;
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
        
        private Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse CallAWSServiceOperation(IAmazonElasticsearch client, Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elasticsearch", "UpgradeElasticsearchDomain");
            try
            {
                return client.UpgradeElasticsearchDomainAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Elasticsearch.RetentionAction DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionAction { get; set; }
            public System.Int32? DeploymentStrategyOptions_ClonedBlueGreenOptions_RetentionOptions_RetentionInHour { get; set; }
            public Amazon.Elasticsearch.DeploymentStrategyOverride DeploymentStrategyOptions_DeploymentStrategy { get; set; }
            public System.String DomainName { get; set; }
            public System.Boolean? PerformCheckOnly { get; set; }
            public System.String TargetVersion { get; set; }
            public System.Func<Amazon.Elasticsearch.Model.UpgradeElasticsearchDomainResponse, UpdateESElasticsearchDomainCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
