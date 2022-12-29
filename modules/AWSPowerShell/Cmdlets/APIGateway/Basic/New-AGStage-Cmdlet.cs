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
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Creates a new Stage resource that references a pre-existing Deployment for the API.
    /// </summary>
    [Cmdlet("New", "AGStage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIGateway.Model.CreateStageResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway CreateStage API operation.", Operation = new[] {"CreateStage"}, SelectReturnType = typeof(Amazon.APIGateway.Model.CreateStageResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.CreateStageResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.CreateStageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAGStageCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        #region Parameter CacheClusterEnabled
        /// <summary>
        /// <para>
        /// <para>Whether cache clustering is enabled for the stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CacheClusterEnabled { get; set; }
        #endregion
        
        #region Parameter CacheClusterSize
        /// <summary>
        /// <para>
        /// <para>The stage's cache capacity in GB. For more information about choosing a cache size,
        /// see <a href="https://docs.aws.amazon.com/apigateway/latest/developerguide/api-gateway-caching.html">Enabling
        /// API caching to enhance responsiveness</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.APIGateway.CacheClusterSize")]
        public Amazon.APIGateway.CacheClusterSize CacheClusterSize { get; set; }
        #endregion
        
        #region Parameter CanarySettings_DeploymentId
        /// <summary>
        /// <para>
        /// <para>The ID of the canary deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CanarySettings_DeploymentId { get; set; }
        #endregion
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Deployment resource for the Stage resource.</para>
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
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the Stage resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DocumentationVersion
        /// <summary>
        /// <para>
        /// <para>The version of the associated API documentation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DocumentationVersion { get; set; }
        #endregion
        
        #region Parameter CanarySettings_PercentTraffic
        /// <summary>
        /// <para>
        /// <para>The percent (0-100) of traffic diverted to a canary deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? CanarySettings_PercentTraffic { get; set; }
        #endregion
        
        #region Parameter RestApiId
        /// <summary>
        /// <para>
        /// <para>The string identifier of the associated RestApi.</para>
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
        public System.String RestApiId { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name for the Stage resource. Stage names can only contain alphanumeric characters,
        /// hyphens, and underscores. Maximum length is 128 characters.</para>
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
        public System.String StageName { get; set; }
        #endregion
        
        #region Parameter CanarySettings_StageVariableOverride
        /// <summary>
        /// <para>
        /// <para>Stage variables overridden for a canary release deployment, including new stage variables
        /// introduced in the canary. These stage variables are represented as a string-to-string
        /// map between stage variable names and their values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CanarySettings_StageVariableOverrides")]
        public System.Collections.Hashtable CanarySettings_StageVariableOverride { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The key-value map of strings. The valid character set is [a-zA-Z+-=._:/]. The tag
        /// key can be up to 128 characters and must not start with <code>aws:</code>. The tag
        /// value can be up to 256 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter TracingEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether active tracing with X-ray is enabled for the Stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TracingEnabled { get; set; }
        #endregion
        
        #region Parameter CanarySettings_UseStageCache
        /// <summary>
        /// <para>
        /// <para>A Boolean flag to indicate whether the canary deployment uses the stage cache or not.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? CanarySettings_UseStageCache { get; set; }
        #endregion
        
        #region Parameter Variable
        /// <summary>
        /// <para>
        /// <para>A map that defines the stage variables for the new Stage resource. Variable names
        /// can have alphanumeric and underscore characters, and the values must match <code>[A-Za-z0-9-._~:/?#&amp;=,]+</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Variables")]
        public System.Collections.Hashtable Variable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.CreateStageResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.CreateStageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RestApiId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RestApiId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RestApiId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AGStage (CreateStage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.CreateStageResponse, NewAGStageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RestApiId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CacheClusterEnabled = this.CacheClusterEnabled;
            context.CacheClusterSize = this.CacheClusterSize;
            context.CanarySettings_DeploymentId = this.CanarySettings_DeploymentId;
            context.CanarySettings_PercentTraffic = this.CanarySettings_PercentTraffic;
            if (this.CanarySettings_StageVariableOverride != null)
            {
                context.CanarySettings_StageVariableOverride = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.CanarySettings_StageVariableOverride.Keys)
                {
                    context.CanarySettings_StageVariableOverride.Add((String)hashKey, (String)(this.CanarySettings_StageVariableOverride[hashKey]));
                }
            }
            context.CanarySettings_UseStageCache = this.CanarySettings_UseStageCache;
            context.DeploymentId = this.DeploymentId;
            #if MODULAR
            if (this.DeploymentId == null && ParameterWasBound(nameof(this.DeploymentId)))
            {
                WriteWarning("You are passing $null as a value for parameter DeploymentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DocumentationVersion = this.DocumentationVersion;
            context.RestApiId = this.RestApiId;
            #if MODULAR
            if (this.RestApiId == null && ParameterWasBound(nameof(this.RestApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter RestApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StageName = this.StageName;
            #if MODULAR
            if (this.StageName == null && ParameterWasBound(nameof(this.StageName)))
            {
                WriteWarning("You are passing $null as a value for parameter StageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
            context.TracingEnabled = this.TracingEnabled;
            if (this.Variable != null)
            {
                context.Variable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Variable.Keys)
                {
                    context.Variable.Add((String)hashKey, (String)(this.Variable[hashKey]));
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
            var request = new Amazon.APIGateway.Model.CreateStageRequest();
            
            if (cmdletContext.CacheClusterEnabled != null)
            {
                request.CacheClusterEnabled = cmdletContext.CacheClusterEnabled.Value;
            }
            if (cmdletContext.CacheClusterSize != null)
            {
                request.CacheClusterSize = cmdletContext.CacheClusterSize;
            }
            
             // populate CanarySettings
            var requestCanarySettingsIsNull = true;
            request.CanarySettings = new Amazon.APIGateway.Model.CanarySettings();
            System.String requestCanarySettings_canarySettings_DeploymentId = null;
            if (cmdletContext.CanarySettings_DeploymentId != null)
            {
                requestCanarySettings_canarySettings_DeploymentId = cmdletContext.CanarySettings_DeploymentId;
            }
            if (requestCanarySettings_canarySettings_DeploymentId != null)
            {
                request.CanarySettings.DeploymentId = requestCanarySettings_canarySettings_DeploymentId;
                requestCanarySettingsIsNull = false;
            }
            System.Double? requestCanarySettings_canarySettings_PercentTraffic = null;
            if (cmdletContext.CanarySettings_PercentTraffic != null)
            {
                requestCanarySettings_canarySettings_PercentTraffic = cmdletContext.CanarySettings_PercentTraffic.Value;
            }
            if (requestCanarySettings_canarySettings_PercentTraffic != null)
            {
                request.CanarySettings.PercentTraffic = requestCanarySettings_canarySettings_PercentTraffic.Value;
                requestCanarySettingsIsNull = false;
            }
            Dictionary<System.String, System.String> requestCanarySettings_canarySettings_StageVariableOverride = null;
            if (cmdletContext.CanarySettings_StageVariableOverride != null)
            {
                requestCanarySettings_canarySettings_StageVariableOverride = cmdletContext.CanarySettings_StageVariableOverride;
            }
            if (requestCanarySettings_canarySettings_StageVariableOverride != null)
            {
                request.CanarySettings.StageVariableOverrides = requestCanarySettings_canarySettings_StageVariableOverride;
                requestCanarySettingsIsNull = false;
            }
            System.Boolean? requestCanarySettings_canarySettings_UseStageCache = null;
            if (cmdletContext.CanarySettings_UseStageCache != null)
            {
                requestCanarySettings_canarySettings_UseStageCache = cmdletContext.CanarySettings_UseStageCache.Value;
            }
            if (requestCanarySettings_canarySettings_UseStageCache != null)
            {
                request.CanarySettings.UseStageCache = requestCanarySettings_canarySettings_UseStageCache.Value;
                requestCanarySettingsIsNull = false;
            }
             // determine if request.CanarySettings should be set to null
            if (requestCanarySettingsIsNull)
            {
                request.CanarySettings = null;
            }
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DocumentationVersion != null)
            {
                request.DocumentationVersion = cmdletContext.DocumentationVersion;
            }
            if (cmdletContext.RestApiId != null)
            {
                request.RestApiId = cmdletContext.RestApiId;
            }
            if (cmdletContext.StageName != null)
            {
                request.StageName = cmdletContext.StageName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TracingEnabled != null)
            {
                request.TracingEnabled = cmdletContext.TracingEnabled.Value;
            }
            if (cmdletContext.Variable != null)
            {
                request.Variables = cmdletContext.Variable;
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
        
        private Amazon.APIGateway.Model.CreateStageResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.CreateStageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "CreateStage");
            try
            {
                #if DESKTOP
                return client.CreateStage(request);
                #elif CORECLR
                return client.CreateStageAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? CacheClusterEnabled { get; set; }
            public Amazon.APIGateway.CacheClusterSize CacheClusterSize { get; set; }
            public System.String CanarySettings_DeploymentId { get; set; }
            public System.Double? CanarySettings_PercentTraffic { get; set; }
            public Dictionary<System.String, System.String> CanarySettings_StageVariableOverride { get; set; }
            public System.Boolean? CanarySettings_UseStageCache { get; set; }
            public System.String DeploymentId { get; set; }
            public System.String Description { get; set; }
            public System.String DocumentationVersion { get; set; }
            public System.String RestApiId { get; set; }
            public System.String StageName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Boolean? TracingEnabled { get; set; }
            public Dictionary<System.String, System.String> Variable { get; set; }
            public System.Func<Amazon.APIGateway.Model.CreateStageResponse, NewAGStageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
