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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// Starts an experiment run for the specified experiment definition. An experiment run
    /// delivers treatments to the target audience and collects metrics. You can start multiple
    /// experiment runs from the same experiment definition.
    /// 
    ///  <note><para>
    /// Billing for this experiment begins when you call this operation and continues until
    /// the experiment is stopped. For pricing details, see <a href="https://aws.amazon.com/systems-manager/pricing/">AppConfig
    /// pricing</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Start", "APPCExperimentRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.StartExperimentRunResponse")]
    [AWSCmdlet("Calls the AWS AppConfig StartExperimentRun API operation.", Operation = new[] {"StartExperimentRun"}, SelectReturnType = typeof(Amazon.AppConfig.Model.StartExperimentRunResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.StartExperimentRunResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.StartExperimentRunResponse object containing multiple properties."
    )]
    public partial class StartAPPCExperimentRunCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApplicationIdentifier
        /// <summary>
        /// <para>
        /// <para>The application ID or name.</para>
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
        public System.String ApplicationIdentifier { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of this experiment run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DeploymentParameters_DynamicExtensionParameter
        /// <summary>
        /// <para>
        /// <para>A map of extension parameters for the deployment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentParameters_DynamicExtensionParameters")]
        public System.Collections.Hashtable DeploymentParameters_DynamicExtensionParameter { get; set; }
        #endregion
        
        #region Parameter ExperimentDefinitionIdentifier
        /// <summary>
        /// <para>
        /// <para>The experiment definition ID or name.</para>
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
        public System.String ExperimentDefinitionIdentifier { get; set; }
        #endregion
        
        #region Parameter ExposurePercentage
        /// <summary>
        /// <para>
        /// <para>The percentage of the target audience to expose to treatments. Set to 0 to validate
        /// the experiment before exposing production users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Single? ExposurePercentage { get; set; }
        #endregion
        
        #region Parameter TreatmentOverrides_Inline
        /// <summary>
        /// <para>
        /// <para>A map of entity IDs to treatment keys. Each entry assigns the specified entity to
        /// the specified treatment, bypassing random assignment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable TreatmentOverrides_Inline { get; set; }
        #endregion
        
        #region Parameter DeploymentParameters_Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the deployment.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentParameters_Tags")]
        public System.Collections.Hashtable DeploymentParameters_Tag { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to assign to the experiment run.</para><para />
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.StartExperimentRunResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.StartExperimentRunResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ApplicationIdentifier),
                nameof(this.ExperimentDefinitionIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-APPCExperimentRun (StartExperimentRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.StartExperimentRunResponse, StartAPPCExperimentRunCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationIdentifier = this.ApplicationIdentifier;
            #if MODULAR
            if (this.ApplicationIdentifier == null && ParameterWasBound(nameof(this.ApplicationIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DeploymentParameters_DynamicExtensionParameter != null)
            {
                context.DeploymentParameters_DynamicExtensionParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeploymentParameters_DynamicExtensionParameter.Keys)
                {
                    context.DeploymentParameters_DynamicExtensionParameter.Add((String)hashKey, (System.String)(this.DeploymentParameters_DynamicExtensionParameter[hashKey]));
                }
            }
            if (this.DeploymentParameters_Tag != null)
            {
                context.DeploymentParameters_Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.DeploymentParameters_Tag.Keys)
                {
                    context.DeploymentParameters_Tag.Add((String)hashKey, (System.String)(this.DeploymentParameters_Tag[hashKey]));
                }
            }
            context.Description = this.Description;
            context.ExperimentDefinitionIdentifier = this.ExperimentDefinitionIdentifier;
            #if MODULAR
            if (this.ExperimentDefinitionIdentifier == null && ParameterWasBound(nameof(this.ExperimentDefinitionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExperimentDefinitionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExposurePercentage = this.ExposurePercentage;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.TreatmentOverrides_Inline != null)
            {
                context.TreatmentOverrides_Inline = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.TreatmentOverrides_Inline.Keys)
                {
                    context.TreatmentOverrides_Inline.Add((String)hashKey, (System.String)(this.TreatmentOverrides_Inline[hashKey]));
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
            var request = new Amazon.AppConfig.Model.StartExperimentRunRequest();
            
            if (cmdletContext.ApplicationIdentifier != null)
            {
                request.ApplicationIdentifier = cmdletContext.ApplicationIdentifier;
            }
            
             // populate DeploymentParameters
            var requestDeploymentParametersIsNull = true;
            request.DeploymentParameters = new Amazon.AppConfig.Model.DeploymentParameters();
            Dictionary<System.String, System.String> requestDeploymentParameters_deploymentParameters_DynamicExtensionParameter = null;
            if (cmdletContext.DeploymentParameters_DynamicExtensionParameter != null)
            {
                requestDeploymentParameters_deploymentParameters_DynamicExtensionParameter = cmdletContext.DeploymentParameters_DynamicExtensionParameter;
            }
            if (requestDeploymentParameters_deploymentParameters_DynamicExtensionParameter != null)
            {
                request.DeploymentParameters.DynamicExtensionParameters = requestDeploymentParameters_deploymentParameters_DynamicExtensionParameter;
                requestDeploymentParametersIsNull = false;
            }
            Dictionary<System.String, System.String> requestDeploymentParameters_deploymentParameters_Tag = null;
            if (cmdletContext.DeploymentParameters_Tag != null)
            {
                requestDeploymentParameters_deploymentParameters_Tag = cmdletContext.DeploymentParameters_Tag;
            }
            if (requestDeploymentParameters_deploymentParameters_Tag != null)
            {
                request.DeploymentParameters.Tags = requestDeploymentParameters_deploymentParameters_Tag;
                requestDeploymentParametersIsNull = false;
            }
             // determine if request.DeploymentParameters should be set to null
            if (requestDeploymentParametersIsNull)
            {
                request.DeploymentParameters = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExperimentDefinitionIdentifier != null)
            {
                request.ExperimentDefinitionIdentifier = cmdletContext.ExperimentDefinitionIdentifier;
            }
            if (cmdletContext.ExposurePercentage != null)
            {
                request.ExposurePercentage = cmdletContext.ExposurePercentage.Value;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TreatmentOverrides
            var requestTreatmentOverridesIsNull = true;
            request.TreatmentOverrides = new Amazon.AppConfig.Model.TreatmentOverrides();
            Dictionary<System.String, System.String> requestTreatmentOverrides_treatmentOverrides_Inline = null;
            if (cmdletContext.TreatmentOverrides_Inline != null)
            {
                requestTreatmentOverrides_treatmentOverrides_Inline = cmdletContext.TreatmentOverrides_Inline;
            }
            if (requestTreatmentOverrides_treatmentOverrides_Inline != null)
            {
                request.TreatmentOverrides.Inline = requestTreatmentOverrides_treatmentOverrides_Inline;
                requestTreatmentOverridesIsNull = false;
            }
             // determine if request.TreatmentOverrides should be set to null
            if (requestTreatmentOverridesIsNull)
            {
                request.TreatmentOverrides = null;
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
        
        private Amazon.AppConfig.Model.StartExperimentRunResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.StartExperimentRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "StartExperimentRun");
            try
            {
                return client.StartExperimentRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ApplicationIdentifier { get; set; }
            public Dictionary<System.String, System.String> DeploymentParameters_DynamicExtensionParameter { get; set; }
            public Dictionary<System.String, System.String> DeploymentParameters_Tag { get; set; }
            public System.String Description { get; set; }
            public System.String ExperimentDefinitionIdentifier { get; set; }
            public System.Single? ExposurePercentage { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Dictionary<System.String, System.String> TreatmentOverrides_Inline { get; set; }
            public System.Func<Amazon.AppConfig.Model.StartExperimentRunResponse, StartAPPCExperimentRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
