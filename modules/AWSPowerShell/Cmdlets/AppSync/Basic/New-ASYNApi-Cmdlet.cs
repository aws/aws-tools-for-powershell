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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Creates an <c>Api</c> object. Use this operation to create an AppSync API with your
    /// preferred configuration, such as an Event API that provides real-time message publishing
    /// and message subscriptions over WebSockets.
    /// </summary>
    [Cmdlet("New", "ASYNApi", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.Api")]
    [AWSCmdlet("Calls the AWS AppSync CreateApi API operation.", Operation = new[] {"CreateApi"}, SelectReturnType = typeof(Amazon.AppSync.Model.CreateApiResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.Api or Amazon.AppSync.Model.CreateApiResponse",
        "This cmdlet returns an Amazon.AppSync.Model.Api object.",
        "The service call response (type Amazon.AppSync.Model.CreateApiResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewASYNApiCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventConfig_AuthProvider
        /// <summary>
        /// <para>
        /// <para>A list of authorization providers.</para>
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
        [Alias("EventConfig_AuthProviders")]
        public Amazon.AppSync.Model.AuthProvider[] EventConfig_AuthProvider { get; set; }
        #endregion
        
        #region Parameter LogConfig_CloudWatchLogsRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM service role that AppSync assumes to publish CloudWatch Logs in your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventConfig_LogConfig_CloudWatchLogsRoleArn")]
        public System.String LogConfig_CloudWatchLogsRoleArn { get; set; }
        #endregion
        
        #region Parameter EventConfig_ConnectionAuthMode
        /// <summary>
        /// <para>
        /// <para>A list of valid authorization modes for the Event API connections.</para>
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
        [Alias("EventConfig_ConnectionAuthModes")]
        public Amazon.AppSync.Model.AuthMode[] EventConfig_ConnectionAuthMode { get; set; }
        #endregion
        
        #region Parameter EventConfig_DefaultPublishAuthMode
        /// <summary>
        /// <para>
        /// <para>A list of valid authorization modes for the Event API publishing.</para>
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
        [Alias("EventConfig_DefaultPublishAuthModes")]
        public Amazon.AppSync.Model.AuthMode[] EventConfig_DefaultPublishAuthMode { get; set; }
        #endregion
        
        #region Parameter EventConfig_DefaultSubscribeAuthMode
        /// <summary>
        /// <para>
        /// <para>A list of valid authorization modes for the Event API subscriptions.</para>
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
        [Alias("EventConfig_DefaultSubscribeAuthModes")]
        public Amazon.AppSync.Model.AuthMode[] EventConfig_DefaultSubscribeAuthMode { get; set; }
        #endregion
        
        #region Parameter LogConfig_LogLevel
        /// <summary>
        /// <para>
        /// <para>The type of information to log for the Event API. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventConfig_LogConfig_LogLevel")]
        [AWSConstantClassSource("Amazon.AppSync.EventLogLevel")]
        public Amazon.AppSync.EventLogLevel LogConfig_LogLevel { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the <c>Api</c>.</para>
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
        
        #region Parameter OwnerContact
        /// <summary>
        /// <para>
        /// <para>The owner contact information for the <c>Api</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerContact { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Api'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.CreateApiResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.CreateApiResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Api";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASYNApi (CreateApi)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.CreateApiResponse, NewASYNApiCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.EventConfig_AuthProvider != null)
            {
                context.EventConfig_AuthProvider = new List<Amazon.AppSync.Model.AuthProvider>(this.EventConfig_AuthProvider);
            }
            #if MODULAR
            if (this.EventConfig_AuthProvider == null && ParameterWasBound(nameof(this.EventConfig_AuthProvider)))
            {
                WriteWarning("You are passing $null as a value for parameter EventConfig_AuthProvider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EventConfig_ConnectionAuthMode != null)
            {
                context.EventConfig_ConnectionAuthMode = new List<Amazon.AppSync.Model.AuthMode>(this.EventConfig_ConnectionAuthMode);
            }
            #if MODULAR
            if (this.EventConfig_ConnectionAuthMode == null && ParameterWasBound(nameof(this.EventConfig_ConnectionAuthMode)))
            {
                WriteWarning("You are passing $null as a value for parameter EventConfig_ConnectionAuthMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EventConfig_DefaultPublishAuthMode != null)
            {
                context.EventConfig_DefaultPublishAuthMode = new List<Amazon.AppSync.Model.AuthMode>(this.EventConfig_DefaultPublishAuthMode);
            }
            #if MODULAR
            if (this.EventConfig_DefaultPublishAuthMode == null && ParameterWasBound(nameof(this.EventConfig_DefaultPublishAuthMode)))
            {
                WriteWarning("You are passing $null as a value for parameter EventConfig_DefaultPublishAuthMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EventConfig_DefaultSubscribeAuthMode != null)
            {
                context.EventConfig_DefaultSubscribeAuthMode = new List<Amazon.AppSync.Model.AuthMode>(this.EventConfig_DefaultSubscribeAuthMode);
            }
            #if MODULAR
            if (this.EventConfig_DefaultSubscribeAuthMode == null && ParameterWasBound(nameof(this.EventConfig_DefaultSubscribeAuthMode)))
            {
                WriteWarning("You are passing $null as a value for parameter EventConfig_DefaultSubscribeAuthMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogConfig_CloudWatchLogsRoleArn = this.LogConfig_CloudWatchLogsRoleArn;
            context.LogConfig_LogLevel = this.LogConfig_LogLevel;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OwnerContact = this.OwnerContact;
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
            var request = new Amazon.AppSync.Model.CreateApiRequest();
            
            
             // populate EventConfig
            var requestEventConfigIsNull = true;
            request.EventConfig = new Amazon.AppSync.Model.EventConfig();
            List<Amazon.AppSync.Model.AuthProvider> requestEventConfig_eventConfig_AuthProvider = null;
            if (cmdletContext.EventConfig_AuthProvider != null)
            {
                requestEventConfig_eventConfig_AuthProvider = cmdletContext.EventConfig_AuthProvider;
            }
            if (requestEventConfig_eventConfig_AuthProvider != null)
            {
                request.EventConfig.AuthProviders = requestEventConfig_eventConfig_AuthProvider;
                requestEventConfigIsNull = false;
            }
            List<Amazon.AppSync.Model.AuthMode> requestEventConfig_eventConfig_ConnectionAuthMode = null;
            if (cmdletContext.EventConfig_ConnectionAuthMode != null)
            {
                requestEventConfig_eventConfig_ConnectionAuthMode = cmdletContext.EventConfig_ConnectionAuthMode;
            }
            if (requestEventConfig_eventConfig_ConnectionAuthMode != null)
            {
                request.EventConfig.ConnectionAuthModes = requestEventConfig_eventConfig_ConnectionAuthMode;
                requestEventConfigIsNull = false;
            }
            List<Amazon.AppSync.Model.AuthMode> requestEventConfig_eventConfig_DefaultPublishAuthMode = null;
            if (cmdletContext.EventConfig_DefaultPublishAuthMode != null)
            {
                requestEventConfig_eventConfig_DefaultPublishAuthMode = cmdletContext.EventConfig_DefaultPublishAuthMode;
            }
            if (requestEventConfig_eventConfig_DefaultPublishAuthMode != null)
            {
                request.EventConfig.DefaultPublishAuthModes = requestEventConfig_eventConfig_DefaultPublishAuthMode;
                requestEventConfigIsNull = false;
            }
            List<Amazon.AppSync.Model.AuthMode> requestEventConfig_eventConfig_DefaultSubscribeAuthMode = null;
            if (cmdletContext.EventConfig_DefaultSubscribeAuthMode != null)
            {
                requestEventConfig_eventConfig_DefaultSubscribeAuthMode = cmdletContext.EventConfig_DefaultSubscribeAuthMode;
            }
            if (requestEventConfig_eventConfig_DefaultSubscribeAuthMode != null)
            {
                request.EventConfig.DefaultSubscribeAuthModes = requestEventConfig_eventConfig_DefaultSubscribeAuthMode;
                requestEventConfigIsNull = false;
            }
            Amazon.AppSync.Model.EventLogConfig requestEventConfig_eventConfig_LogConfig = null;
            
             // populate LogConfig
            var requestEventConfig_eventConfig_LogConfigIsNull = true;
            requestEventConfig_eventConfig_LogConfig = new Amazon.AppSync.Model.EventLogConfig();
            System.String requestEventConfig_eventConfig_LogConfig_logConfig_CloudWatchLogsRoleArn = null;
            if (cmdletContext.LogConfig_CloudWatchLogsRoleArn != null)
            {
                requestEventConfig_eventConfig_LogConfig_logConfig_CloudWatchLogsRoleArn = cmdletContext.LogConfig_CloudWatchLogsRoleArn;
            }
            if (requestEventConfig_eventConfig_LogConfig_logConfig_CloudWatchLogsRoleArn != null)
            {
                requestEventConfig_eventConfig_LogConfig.CloudWatchLogsRoleArn = requestEventConfig_eventConfig_LogConfig_logConfig_CloudWatchLogsRoleArn;
                requestEventConfig_eventConfig_LogConfigIsNull = false;
            }
            Amazon.AppSync.EventLogLevel requestEventConfig_eventConfig_LogConfig_logConfig_LogLevel = null;
            if (cmdletContext.LogConfig_LogLevel != null)
            {
                requestEventConfig_eventConfig_LogConfig_logConfig_LogLevel = cmdletContext.LogConfig_LogLevel;
            }
            if (requestEventConfig_eventConfig_LogConfig_logConfig_LogLevel != null)
            {
                requestEventConfig_eventConfig_LogConfig.LogLevel = requestEventConfig_eventConfig_LogConfig_logConfig_LogLevel;
                requestEventConfig_eventConfig_LogConfigIsNull = false;
            }
             // determine if requestEventConfig_eventConfig_LogConfig should be set to null
            if (requestEventConfig_eventConfig_LogConfigIsNull)
            {
                requestEventConfig_eventConfig_LogConfig = null;
            }
            if (requestEventConfig_eventConfig_LogConfig != null)
            {
                request.EventConfig.LogConfig = requestEventConfig_eventConfig_LogConfig;
                requestEventConfigIsNull = false;
            }
             // determine if request.EventConfig should be set to null
            if (requestEventConfigIsNull)
            {
                request.EventConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OwnerContact != null)
            {
                request.OwnerContact = cmdletContext.OwnerContact;
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
        
        private Amazon.AppSync.Model.CreateApiResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.CreateApiRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "CreateApi");
            try
            {
                #if DESKTOP
                return client.CreateApi(request);
                #elif CORECLR
                return client.CreateApiAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.AppSync.Model.AuthProvider> EventConfig_AuthProvider { get; set; }
            public List<Amazon.AppSync.Model.AuthMode> EventConfig_ConnectionAuthMode { get; set; }
            public List<Amazon.AppSync.Model.AuthMode> EventConfig_DefaultPublishAuthMode { get; set; }
            public List<Amazon.AppSync.Model.AuthMode> EventConfig_DefaultSubscribeAuthMode { get; set; }
            public System.String LogConfig_CloudWatchLogsRoleArn { get; set; }
            public Amazon.AppSync.EventLogLevel LogConfig_LogLevel { get; set; }
            public System.String Name { get; set; }
            public System.String OwnerContact { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppSync.Model.CreateApiResponse, NewASYNApiCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Api;
        }
        
    }
}
