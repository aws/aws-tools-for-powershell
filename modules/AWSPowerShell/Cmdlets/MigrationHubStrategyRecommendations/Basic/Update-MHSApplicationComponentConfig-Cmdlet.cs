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
using Amazon.MigrationHubStrategyRecommendations;
using Amazon.MigrationHubStrategyRecommendations.Model;

namespace Amazon.PowerShell.Cmdlets.MHS
{
    /// <summary>
    /// Updates the configuration of an application component.
    /// </summary>
    [Cmdlet("Update", "MHSApplicationComponentConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Migration Hub Strategy Recommendations UpdateApplicationComponentConfig API operation.", Operation = new[] {"UpdateApplicationComponentConfig"}, SelectReturnType = typeof(Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigResponse))]
    [AWSCmdletOutput("None or Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateMHSApplicationComponentConfigCmdlet : AmazonMigrationHubStrategyRecommendationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationComponentId
        /// <summary>
        /// <para>
        /// <para> The ID of the application component. The ID is unique within an AWS account. </para>
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
        public System.String ApplicationComponentId { get; set; }
        #endregion
        
        #region Parameter AppType
        /// <summary>
        /// <para>
        /// <para>The type of known component.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.AppType")]
        public Amazon.MigrationHubStrategyRecommendations.AppType AppType { get; set; }
        #endregion
        
        #region Parameter ConfigureOnly
        /// <summary>
        /// <para>
        /// <para>Update the configuration request of an application component. If it is set to true,
        /// the source code and/or database credentials are updated. If it is set to false, the
        /// source code and/or database credentials are updated and an analysis is initiated.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ConfigureOnly { get; set; }
        #endregion
        
        #region Parameter InclusionStatus
        /// <summary>
        /// <para>
        /// <para> Indicates whether the application component has been included for server recommendation
        /// or not. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.InclusionStatus")]
        public Amazon.MigrationHubStrategyRecommendations.InclusionStatus InclusionStatus { get; set; }
        #endregion
        
        #region Parameter StrategyOption_IsPreferred
        /// <summary>
        /// <para>
        /// <para> Indicates if a specific strategy is preferred for the application component. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? StrategyOption_IsPreferred { get; set; }
        #endregion
        
        #region Parameter SecretsManagerKey
        /// <summary>
        /// <para>
        /// <para> Database credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SecretsManagerKey { get; set; }
        #endregion
        
        #region Parameter SourceCodeList
        /// <summary>
        /// <para>
        /// <para> The list of source code configurations to update for the application component. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MigrationHubStrategyRecommendations.Model.SourceCode[] SourceCodeList { get; set; }
        #endregion
        
        #region Parameter StrategyOption_Strategy
        /// <summary>
        /// <para>
        /// <para> Type of transformation. For example, Rehost, Replatform, and so on. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.Strategy")]
        public Amazon.MigrationHubStrategyRecommendations.Strategy StrategyOption_Strategy { get; set; }
        #endregion
        
        #region Parameter StrategyOption_TargetDestination
        /// <summary>
        /// <para>
        /// <para> Destination information about where the application component can migrate to. For
        /// example, <c>EC2</c>, <c>ECS</c>, and so on. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.TargetDestination")]
        public Amazon.MigrationHubStrategyRecommendations.TargetDestination StrategyOption_TargetDestination { get; set; }
        #endregion
        
        #region Parameter StrategyOption_ToolName
        /// <summary>
        /// <para>
        /// <para> The name of the tool that can be used to transform an application component using
        /// this strategy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MigrationHubStrategyRecommendations.TransformationToolName")]
        public Amazon.MigrationHubStrategyRecommendations.TransformationToolName StrategyOption_ToolName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationComponentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationComponentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationComponentId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationComponentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MHSApplicationComponentConfig (UpdateApplicationComponentConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigResponse, UpdateMHSApplicationComponentConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationComponentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationComponentId = this.ApplicationComponentId;
            #if MODULAR
            if (this.ApplicationComponentId == null && ParameterWasBound(nameof(this.ApplicationComponentId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationComponentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AppType = this.AppType;
            context.ConfigureOnly = this.ConfigureOnly;
            context.InclusionStatus = this.InclusionStatus;
            context.SecretsManagerKey = this.SecretsManagerKey;
            if (this.SourceCodeList != null)
            {
                context.SourceCodeList = new List<Amazon.MigrationHubStrategyRecommendations.Model.SourceCode>(this.SourceCodeList);
            }
            context.StrategyOption_IsPreferred = this.StrategyOption_IsPreferred;
            context.StrategyOption_Strategy = this.StrategyOption_Strategy;
            context.StrategyOption_TargetDestination = this.StrategyOption_TargetDestination;
            context.StrategyOption_ToolName = this.StrategyOption_ToolName;
            
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
            var request = new Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigRequest();
            
            if (cmdletContext.ApplicationComponentId != null)
            {
                request.ApplicationComponentId = cmdletContext.ApplicationComponentId;
            }
            if (cmdletContext.AppType != null)
            {
                request.AppType = cmdletContext.AppType;
            }
            if (cmdletContext.ConfigureOnly != null)
            {
                request.ConfigureOnly = cmdletContext.ConfigureOnly.Value;
            }
            if (cmdletContext.InclusionStatus != null)
            {
                request.InclusionStatus = cmdletContext.InclusionStatus;
            }
            if (cmdletContext.SecretsManagerKey != null)
            {
                request.SecretsManagerKey = cmdletContext.SecretsManagerKey;
            }
            if (cmdletContext.SourceCodeList != null)
            {
                request.SourceCodeList = cmdletContext.SourceCodeList;
            }
            
             // populate StrategyOption
            var requestStrategyOptionIsNull = true;
            request.StrategyOption = new Amazon.MigrationHubStrategyRecommendations.Model.StrategyOption();
            System.Boolean? requestStrategyOption_strategyOption_IsPreferred = null;
            if (cmdletContext.StrategyOption_IsPreferred != null)
            {
                requestStrategyOption_strategyOption_IsPreferred = cmdletContext.StrategyOption_IsPreferred.Value;
            }
            if (requestStrategyOption_strategyOption_IsPreferred != null)
            {
                request.StrategyOption.IsPreferred = requestStrategyOption_strategyOption_IsPreferred.Value;
                requestStrategyOptionIsNull = false;
            }
            Amazon.MigrationHubStrategyRecommendations.Strategy requestStrategyOption_strategyOption_Strategy = null;
            if (cmdletContext.StrategyOption_Strategy != null)
            {
                requestStrategyOption_strategyOption_Strategy = cmdletContext.StrategyOption_Strategy;
            }
            if (requestStrategyOption_strategyOption_Strategy != null)
            {
                request.StrategyOption.Strategy = requestStrategyOption_strategyOption_Strategy;
                requestStrategyOptionIsNull = false;
            }
            Amazon.MigrationHubStrategyRecommendations.TargetDestination requestStrategyOption_strategyOption_TargetDestination = null;
            if (cmdletContext.StrategyOption_TargetDestination != null)
            {
                requestStrategyOption_strategyOption_TargetDestination = cmdletContext.StrategyOption_TargetDestination;
            }
            if (requestStrategyOption_strategyOption_TargetDestination != null)
            {
                request.StrategyOption.TargetDestination = requestStrategyOption_strategyOption_TargetDestination;
                requestStrategyOptionIsNull = false;
            }
            Amazon.MigrationHubStrategyRecommendations.TransformationToolName requestStrategyOption_strategyOption_ToolName = null;
            if (cmdletContext.StrategyOption_ToolName != null)
            {
                requestStrategyOption_strategyOption_ToolName = cmdletContext.StrategyOption_ToolName;
            }
            if (requestStrategyOption_strategyOption_ToolName != null)
            {
                request.StrategyOption.ToolName = requestStrategyOption_strategyOption_ToolName;
                requestStrategyOptionIsNull = false;
            }
             // determine if request.StrategyOption should be set to null
            if (requestStrategyOptionIsNull)
            {
                request.StrategyOption = null;
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
        
        private Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigResponse CallAWSServiceOperation(IAmazonMigrationHubStrategyRecommendations client, Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Migration Hub Strategy Recommendations", "UpdateApplicationComponentConfig");
            try
            {
                #if DESKTOP
                return client.UpdateApplicationComponentConfig(request);
                #elif CORECLR
                return client.UpdateApplicationComponentConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationComponentId { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.AppType AppType { get; set; }
            public System.Boolean? ConfigureOnly { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.InclusionStatus InclusionStatus { get; set; }
            public System.String SecretsManagerKey { get; set; }
            public List<Amazon.MigrationHubStrategyRecommendations.Model.SourceCode> SourceCodeList { get; set; }
            public System.Boolean? StrategyOption_IsPreferred { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.Strategy StrategyOption_Strategy { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.TargetDestination StrategyOption_TargetDestination { get; set; }
            public Amazon.MigrationHubStrategyRecommendations.TransformationToolName StrategyOption_ToolName { get; set; }
            public System.Func<Amazon.MigrationHubStrategyRecommendations.Model.UpdateApplicationComponentConfigResponse, UpdateMHSApplicationComponentConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
