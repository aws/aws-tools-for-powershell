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
    /// Stops a running experiment. Stopping an experiment run ends audience exposure and
    /// returns users to the currently deployed feature flag configuration.
    /// </summary>
    [Cmdlet("Stop", "APPCExperimentRun", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.StopExperimentRunResponse")]
    [AWSCmdlet("Calls the AWS AppConfig StopExperimentRun API operation.", Operation = new[] {"StopExperimentRun"}, SelectReturnType = typeof(Amazon.AppConfig.Model.StopExperimentRunResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.StopExperimentRunResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.StopExperimentRunResponse object containing multiple properties."
    )]
    public partial class StopAPPCExperimentRunCmdlet : AmazonAppConfigClientCmdlet, IExecutor
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
        
        #region Parameter Result_ExecutiveSummary
        /// <summary>
        /// <para>
        /// <para>A summary of the experiment outcome and key findings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Result_ExecutiveSummary { get; set; }
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
        
        #region Parameter Result_ReasonsNotToLaunch
        /// <summary>
        /// <para>
        /// <para>Evidence against launching the treatment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Result_ReasonsNotToLaunch { get; set; }
        #endregion
        
        #region Parameter Result_ReasonsToLaunch
        /// <summary>
        /// <para>
        /// <para>Evidence in favor of launching the winning treatment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Result_ReasonsToLaunch { get; set; }
        #endregion
        
        #region Parameter Run
        /// <summary>
        /// <para>
        /// <para>The run number to stop.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Run { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.StopExperimentRunResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.StopExperimentRunResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-APPCExperimentRun (StopExperimentRun)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.StopExperimentRunResponse, StopAPPCExperimentRunCmdlet>(Select) ??
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
            context.ExperimentDefinitionIdentifier = this.ExperimentDefinitionIdentifier;
            #if MODULAR
            if (this.ExperimentDefinitionIdentifier == null && ParameterWasBound(nameof(this.ExperimentDefinitionIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ExperimentDefinitionIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Result_ExecutiveSummary = this.Result_ExecutiveSummary;
            context.Result_ReasonsNotToLaunch = this.Result_ReasonsNotToLaunch;
            context.Result_ReasonsToLaunch = this.Result_ReasonsToLaunch;
            context.Run = this.Run;
            #if MODULAR
            if (this.Run == null && ParameterWasBound(nameof(this.Run)))
            {
                WriteWarning("You are passing $null as a value for parameter Run which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppConfig.Model.StopExperimentRunRequest();
            
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
            if (cmdletContext.ExperimentDefinitionIdentifier != null)
            {
                request.ExperimentDefinitionIdentifier = cmdletContext.ExperimentDefinitionIdentifier;
            }
            
             // populate Result
            var requestResultIsNull = true;
            request.Result = new Amazon.AppConfig.Model.ExperimentRunResult();
            System.String requestResult_result_ExecutiveSummary = null;
            if (cmdletContext.Result_ExecutiveSummary != null)
            {
                requestResult_result_ExecutiveSummary = cmdletContext.Result_ExecutiveSummary;
            }
            if (requestResult_result_ExecutiveSummary != null)
            {
                request.Result.ExecutiveSummary = requestResult_result_ExecutiveSummary;
                requestResultIsNull = false;
            }
            System.String requestResult_result_ReasonsNotToLaunch = null;
            if (cmdletContext.Result_ReasonsNotToLaunch != null)
            {
                requestResult_result_ReasonsNotToLaunch = cmdletContext.Result_ReasonsNotToLaunch;
            }
            if (requestResult_result_ReasonsNotToLaunch != null)
            {
                request.Result.ReasonsNotToLaunch = requestResult_result_ReasonsNotToLaunch;
                requestResultIsNull = false;
            }
            System.String requestResult_result_ReasonsToLaunch = null;
            if (cmdletContext.Result_ReasonsToLaunch != null)
            {
                requestResult_result_ReasonsToLaunch = cmdletContext.Result_ReasonsToLaunch;
            }
            if (requestResult_result_ReasonsToLaunch != null)
            {
                request.Result.ReasonsToLaunch = requestResult_result_ReasonsToLaunch;
                requestResultIsNull = false;
            }
             // determine if request.Result should be set to null
            if (requestResultIsNull)
            {
                request.Result = null;
            }
            if (cmdletContext.Run != null)
            {
                request.Run = cmdletContext.Run.Value;
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
        
        private Amazon.AppConfig.Model.StopExperimentRunResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.StopExperimentRunRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "StopExperimentRun");
            try
            {
                return client.StopExperimentRunAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ExperimentDefinitionIdentifier { get; set; }
            public System.String Result_ExecutiveSummary { get; set; }
            public System.String Result_ReasonsNotToLaunch { get; set; }
            public System.String Result_ReasonsToLaunch { get; set; }
            public System.Int32? Run { get; set; }
            public System.Func<Amazon.AppConfig.Model.StopExperimentRunResponse, StopAPPCExperimentRunCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
