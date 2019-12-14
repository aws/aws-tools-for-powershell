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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Creates a Stage for an API.
    /// </summary>
    [Cmdlet("New", "AG2Stage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreateStageResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreateStage API operation.", Operation = new[] {"CreateStage"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.CreateStageResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreateStageResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.CreateStageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewAG2StageCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API identifier.</para>
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
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter AutoDeploy
        /// <summary>
        /// <para>
        /// <para>Specifies whether updates to an API automatically trigger a new deployment. The default
        /// value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoDeploy { get; set; }
        #endregion
        
        #region Parameter ClientCertificateId
        /// <summary>
        /// <para>
        /// <para>The identifier of a client certificate for a Stage. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientCertificateId { get; set; }
        #endregion
        
        #region Parameter DefaultRouteSettings_DataTraceEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether (true) or not (false) data trace logging is enabled for this route.
        /// This property affects the log entries pushed to Amazon CloudWatch Logs. Supported
        /// only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DefaultRouteSettings_DataTraceEnabled { get; set; }
        #endregion
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para>The deployment identifier of the API stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description for the API stage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter AccessLogSettings_DestinationArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the CloudWatch Logs log group to receive access logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessLogSettings_DestinationArn { get; set; }
        #endregion
        
        #region Parameter DefaultRouteSettings_DetailedMetricsEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether detailed metrics are enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DefaultRouteSettings_DetailedMetricsEnabled { get; set; }
        #endregion
        
        #region Parameter AccessLogSettings_Format
        /// <summary>
        /// <para>
        /// <para>A single line format of the access logs of data, as specified by selected $context
        /// variables. The format must include at least $context.requestId.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccessLogSettings_Format { get; set; }
        #endregion
        
        #region Parameter DefaultRouteSettings_LoggingLevel
        /// <summary>
        /// <para>
        /// <para>Specifies the logging level for this route: INFO, ERROR, or OFF. This property affects
        /// the log entries pushed to Amazon CloudWatch Logs. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.LoggingLevel")]
        public Amazon.ApiGatewayV2.LoggingLevel DefaultRouteSettings_LoggingLevel { get; set; }
        #endregion
        
        #region Parameter RouteSetting
        /// <summary>
        /// <para>
        /// <para>Route settings for the stage, by routeKey.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RouteSettings")]
        public System.Collections.Hashtable RouteSetting { get; set; }
        #endregion
        
        #region Parameter StageName
        /// <summary>
        /// <para>
        /// <para>The name of the stage.</para>
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
        
        #region Parameter StageVariable
        /// <summary>
        /// <para>
        /// <para>A map that defines the stage variables for a Stage. Variable names can have alphanumeric
        /// and underscore characters, and the values must match [A-Za-z0-9-._~:/?#&amp;=,]+.
        /// Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StageVariables")]
        public System.Collections.Hashtable StageVariable { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The collection of tags. Each tag element is associated with a given resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter DefaultRouteSettings_ThrottlingBurstLimit
        /// <summary>
        /// <para>
        /// <para>Specifies the throttling burst limit. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DefaultRouteSettings_ThrottlingBurstLimit { get; set; }
        #endregion
        
        #region Parameter DefaultRouteSettings_ThrottlingRateLimit
        /// <summary>
        /// <para>
        /// <para>Specifies the throttling rate limit. Supported only for WebSocket APIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Double? DefaultRouteSettings_ThrottlingRateLimit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.CreateStageResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.CreateStageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApiId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApiId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApiId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2Stage (CreateStage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.CreateStageResponse, NewAG2StageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApiId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessLogSettings_DestinationArn = this.AccessLogSettings_DestinationArn;
            context.AccessLogSettings_Format = this.AccessLogSettings_Format;
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoDeploy = this.AutoDeploy;
            context.ClientCertificateId = this.ClientCertificateId;
            context.DefaultRouteSettings_DataTraceEnabled = this.DefaultRouteSettings_DataTraceEnabled;
            context.DefaultRouteSettings_DetailedMetricsEnabled = this.DefaultRouteSettings_DetailedMetricsEnabled;
            context.DefaultRouteSettings_LoggingLevel = this.DefaultRouteSettings_LoggingLevel;
            context.DefaultRouteSettings_ThrottlingBurstLimit = this.DefaultRouteSettings_ThrottlingBurstLimit;
            context.DefaultRouteSettings_ThrottlingRateLimit = this.DefaultRouteSettings_ThrottlingRateLimit;
            context.DeploymentId = this.DeploymentId;
            context.Description = this.Description;
            if (this.RouteSetting != null)
            {
                context.RouteSetting = new Dictionary<System.String, Amazon.ApiGatewayV2.Model.RouteSettings>(StringComparer.Ordinal);
                foreach (var hashKey in this.RouteSetting.Keys)
                {
                    context.RouteSetting.Add((String)hashKey, (RouteSettings)(this.RouteSetting[hashKey]));
                }
            }
            context.StageName = this.StageName;
            #if MODULAR
            if (this.StageName == null && ParameterWasBound(nameof(this.StageName)))
            {
                WriteWarning("You are passing $null as a value for parameter StageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.StageVariable != null)
            {
                context.StageVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.StageVariable.Keys)
                {
                    context.StageVariable.Add((String)hashKey, (String)(this.StageVariable[hashKey]));
                }
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.ApiGatewayV2.Model.CreateStageRequest();
            
            
             // populate AccessLogSettings
            var requestAccessLogSettingsIsNull = true;
            request.AccessLogSettings = new Amazon.ApiGatewayV2.Model.AccessLogSettings();
            System.String requestAccessLogSettings_accessLogSettings_DestinationArn = null;
            if (cmdletContext.AccessLogSettings_DestinationArn != null)
            {
                requestAccessLogSettings_accessLogSettings_DestinationArn = cmdletContext.AccessLogSettings_DestinationArn;
            }
            if (requestAccessLogSettings_accessLogSettings_DestinationArn != null)
            {
                request.AccessLogSettings.DestinationArn = requestAccessLogSettings_accessLogSettings_DestinationArn;
                requestAccessLogSettingsIsNull = false;
            }
            System.String requestAccessLogSettings_accessLogSettings_Format = null;
            if (cmdletContext.AccessLogSettings_Format != null)
            {
                requestAccessLogSettings_accessLogSettings_Format = cmdletContext.AccessLogSettings_Format;
            }
            if (requestAccessLogSettings_accessLogSettings_Format != null)
            {
                request.AccessLogSettings.Format = requestAccessLogSettings_accessLogSettings_Format;
                requestAccessLogSettingsIsNull = false;
            }
             // determine if request.AccessLogSettings should be set to null
            if (requestAccessLogSettingsIsNull)
            {
                request.AccessLogSettings = null;
            }
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.AutoDeploy != null)
            {
                request.AutoDeploy = cmdletContext.AutoDeploy.Value;
            }
            if (cmdletContext.ClientCertificateId != null)
            {
                request.ClientCertificateId = cmdletContext.ClientCertificateId;
            }
            
             // populate DefaultRouteSettings
            var requestDefaultRouteSettingsIsNull = true;
            request.DefaultRouteSettings = new Amazon.ApiGatewayV2.Model.RouteSettings();
            System.Boolean? requestDefaultRouteSettings_defaultRouteSettings_DataTraceEnabled = null;
            if (cmdletContext.DefaultRouteSettings_DataTraceEnabled != null)
            {
                requestDefaultRouteSettings_defaultRouteSettings_DataTraceEnabled = cmdletContext.DefaultRouteSettings_DataTraceEnabled.Value;
            }
            if (requestDefaultRouteSettings_defaultRouteSettings_DataTraceEnabled != null)
            {
                request.DefaultRouteSettings.DataTraceEnabled = requestDefaultRouteSettings_defaultRouteSettings_DataTraceEnabled.Value;
                requestDefaultRouteSettingsIsNull = false;
            }
            System.Boolean? requestDefaultRouteSettings_defaultRouteSettings_DetailedMetricsEnabled = null;
            if (cmdletContext.DefaultRouteSettings_DetailedMetricsEnabled != null)
            {
                requestDefaultRouteSettings_defaultRouteSettings_DetailedMetricsEnabled = cmdletContext.DefaultRouteSettings_DetailedMetricsEnabled.Value;
            }
            if (requestDefaultRouteSettings_defaultRouteSettings_DetailedMetricsEnabled != null)
            {
                request.DefaultRouteSettings.DetailedMetricsEnabled = requestDefaultRouteSettings_defaultRouteSettings_DetailedMetricsEnabled.Value;
                requestDefaultRouteSettingsIsNull = false;
            }
            Amazon.ApiGatewayV2.LoggingLevel requestDefaultRouteSettings_defaultRouteSettings_LoggingLevel = null;
            if (cmdletContext.DefaultRouteSettings_LoggingLevel != null)
            {
                requestDefaultRouteSettings_defaultRouteSettings_LoggingLevel = cmdletContext.DefaultRouteSettings_LoggingLevel;
            }
            if (requestDefaultRouteSettings_defaultRouteSettings_LoggingLevel != null)
            {
                request.DefaultRouteSettings.LoggingLevel = requestDefaultRouteSettings_defaultRouteSettings_LoggingLevel;
                requestDefaultRouteSettingsIsNull = false;
            }
            System.Int32? requestDefaultRouteSettings_defaultRouteSettings_ThrottlingBurstLimit = null;
            if (cmdletContext.DefaultRouteSettings_ThrottlingBurstLimit != null)
            {
                requestDefaultRouteSettings_defaultRouteSettings_ThrottlingBurstLimit = cmdletContext.DefaultRouteSettings_ThrottlingBurstLimit.Value;
            }
            if (requestDefaultRouteSettings_defaultRouteSettings_ThrottlingBurstLimit != null)
            {
                request.DefaultRouteSettings.ThrottlingBurstLimit = requestDefaultRouteSettings_defaultRouteSettings_ThrottlingBurstLimit.Value;
                requestDefaultRouteSettingsIsNull = false;
            }
            System.Double? requestDefaultRouteSettings_defaultRouteSettings_ThrottlingRateLimit = null;
            if (cmdletContext.DefaultRouteSettings_ThrottlingRateLimit != null)
            {
                requestDefaultRouteSettings_defaultRouteSettings_ThrottlingRateLimit = cmdletContext.DefaultRouteSettings_ThrottlingRateLimit.Value;
            }
            if (requestDefaultRouteSettings_defaultRouteSettings_ThrottlingRateLimit != null)
            {
                request.DefaultRouteSettings.ThrottlingRateLimit = requestDefaultRouteSettings_defaultRouteSettings_ThrottlingRateLimit.Value;
                requestDefaultRouteSettingsIsNull = false;
            }
             // determine if request.DefaultRouteSettings should be set to null
            if (requestDefaultRouteSettingsIsNull)
            {
                request.DefaultRouteSettings = null;
            }
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.RouteSetting != null)
            {
                request.RouteSettings = cmdletContext.RouteSetting;
            }
            if (cmdletContext.StageName != null)
            {
                request.StageName = cmdletContext.StageName;
            }
            if (cmdletContext.StageVariable != null)
            {
                request.StageVariables = cmdletContext.StageVariable;
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
        
        private Amazon.ApiGatewayV2.Model.CreateStageResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreateStageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreateStage");
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
            public System.String AccessLogSettings_DestinationArn { get; set; }
            public System.String AccessLogSettings_Format { get; set; }
            public System.String ApiId { get; set; }
            public System.Boolean? AutoDeploy { get; set; }
            public System.String ClientCertificateId { get; set; }
            public System.Boolean? DefaultRouteSettings_DataTraceEnabled { get; set; }
            public System.Boolean? DefaultRouteSettings_DetailedMetricsEnabled { get; set; }
            public Amazon.ApiGatewayV2.LoggingLevel DefaultRouteSettings_LoggingLevel { get; set; }
            public System.Int32? DefaultRouteSettings_ThrottlingBurstLimit { get; set; }
            public System.Double? DefaultRouteSettings_ThrottlingRateLimit { get; set; }
            public System.String DeploymentId { get; set; }
            public System.String Description { get; set; }
            public Dictionary<System.String, Amazon.ApiGatewayV2.Model.RouteSettings> RouteSetting { get; set; }
            public System.String StageName { get; set; }
            public Dictionary<System.String, System.String> StageVariable { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.CreateStageResponse, NewAG2StageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
