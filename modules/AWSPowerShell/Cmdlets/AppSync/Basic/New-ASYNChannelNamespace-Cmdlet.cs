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
    /// Creates a <c>ChannelNamespace</c> for an <c>Api</c>.
    /// </summary>
    [Cmdlet("New", "ASYNChannelNamespace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.ChannelNamespace")]
    [AWSCmdlet("Calls the AWS AppSync CreateChannelNamespace API operation.", Operation = new[] {"CreateChannelNamespace"}, SelectReturnType = typeof(Amazon.AppSync.Model.CreateChannelNamespaceResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.ChannelNamespace or Amazon.AppSync.Model.CreateChannelNamespaceResponse",
        "This cmdlet returns an Amazon.AppSync.Model.ChannelNamespace object.",
        "The service call response (type Amazon.AppSync.Model.CreateChannelNamespaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewASYNChannelNamespaceCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The <c>Api</c> ID.</para>
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
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter OnPublish_Behavior
        /// <summary>
        /// <para>
        /// <para>The behavior for the handler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandlerConfigs_OnPublish_Behavior")]
        [AWSConstantClassSource("Amazon.AppSync.HandlerBehavior")]
        public Amazon.AppSync.HandlerBehavior OnPublish_Behavior { get; set; }
        #endregion
        
        #region Parameter OnSubscribe_Behavior
        /// <summary>
        /// <para>
        /// <para>The behavior for the handler.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandlerConfigs_OnSubscribe_Behavior")]
        [AWSConstantClassSource("Amazon.AppSync.HandlerBehavior")]
        public Amazon.AppSync.HandlerBehavior OnSubscribe_Behavior { get; set; }
        #endregion
        
        #region Parameter CodeHandler
        /// <summary>
        /// <para>
        /// <para>The event handler functions that run custom business logic to process published events
        /// and subscribe requests.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("CodeHandlers")]
        public System.String CodeHandler { get; set; }
        #endregion
        
        #region Parameter OnPublish_Integration_DataSourceName
        /// <summary>
        /// <para>
        /// <para>The unique name of the data source that has been configured on the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandlerConfigs_OnPublish_Integration_DataSourceName")]
        public System.String OnPublish_Integration_DataSourceName { get; set; }
        #endregion
        
        #region Parameter OnSubscribe_Integration_DataSourceName
        /// <summary>
        /// <para>
        /// <para>The unique name of the data source that has been configured on the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandlerConfigs_OnSubscribe_Integration_DataSourceName")]
        public System.String OnSubscribe_Integration_DataSourceName { get; set; }
        #endregion
        
        #region Parameter OnPublish_LambdaConfig_InvokeType
        /// <summary>
        /// <para>
        /// <para>The invocation type for a Lambda data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandlerConfigs_OnPublish_Integration_LambdaConfig_InvokeType")]
        [AWSConstantClassSource("Amazon.AppSync.InvokeType")]
        public Amazon.AppSync.InvokeType OnPublish_LambdaConfig_InvokeType { get; set; }
        #endregion
        
        #region Parameter OnSubscribe_LambdaConfig_InvokeType
        /// <summary>
        /// <para>
        /// <para>The invocation type for a Lambda data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HandlerConfigs_OnSubscribe_Integration_LambdaConfig_InvokeType")]
        [AWSConstantClassSource("Amazon.AppSync.InvokeType")]
        public Amazon.AppSync.InvokeType OnSubscribe_LambdaConfig_InvokeType { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the <c>ChannelNamespace</c>. This name must be unique within the <c>Api</c></para>
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
        
        #region Parameter PublishAuthMode
        /// <summary>
        /// <para>
        /// <para>The authorization mode to use for publishing messages on the channel namespace. This
        /// configuration overrides the default <c>Api</c> authorization configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PublishAuthModes")]
        public Amazon.AppSync.Model.AuthMode[] PublishAuthMode { get; set; }
        #endregion
        
        #region Parameter SubscribeAuthMode
        /// <summary>
        /// <para>
        /// <para>The authorization mode to use for subscribing to messages on the channel namespace.
        /// This configuration overrides the default <c>Api</c> authorization configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SubscribeAuthModes")]
        public Amazon.AppSync.Model.AuthMode[] SubscribeAuthMode { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelNamespace'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.CreateChannelNamespaceResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.CreateChannelNamespaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelNamespace";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASYNChannelNamespace (CreateChannelNamespace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.CreateChannelNamespaceResponse, NewASYNChannelNamespaceCmdlet>(Select) ??
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
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CodeHandler = this.CodeHandler;
            context.OnPublish_Behavior = this.OnPublish_Behavior;
            context.OnPublish_Integration_DataSourceName = this.OnPublish_Integration_DataSourceName;
            context.OnPublish_LambdaConfig_InvokeType = this.OnPublish_LambdaConfig_InvokeType;
            context.OnSubscribe_Behavior = this.OnSubscribe_Behavior;
            context.OnSubscribe_Integration_DataSourceName = this.OnSubscribe_Integration_DataSourceName;
            context.OnSubscribe_LambdaConfig_InvokeType = this.OnSubscribe_LambdaConfig_InvokeType;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.PublishAuthMode != null)
            {
                context.PublishAuthMode = new List<Amazon.AppSync.Model.AuthMode>(this.PublishAuthMode);
            }
            if (this.SubscribeAuthMode != null)
            {
                context.SubscribeAuthMode = new List<Amazon.AppSync.Model.AuthMode>(this.SubscribeAuthMode);
            }
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
            var request = new Amazon.AppSync.Model.CreateChannelNamespaceRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.CodeHandler != null)
            {
                request.CodeHandlers = cmdletContext.CodeHandler;
            }
            
             // populate HandlerConfigs
            var requestHandlerConfigsIsNull = true;
            request.HandlerConfigs = new Amazon.AppSync.Model.HandlerConfigs();
            Amazon.AppSync.Model.HandlerConfig requestHandlerConfigs_handlerConfigs_OnPublish = null;
            
             // populate OnPublish
            var requestHandlerConfigs_handlerConfigs_OnPublishIsNull = true;
            requestHandlerConfigs_handlerConfigs_OnPublish = new Amazon.AppSync.Model.HandlerConfig();
            Amazon.AppSync.HandlerBehavior requestHandlerConfigs_handlerConfigs_OnPublish_onPublish_Behavior = null;
            if (cmdletContext.OnPublish_Behavior != null)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish_onPublish_Behavior = cmdletContext.OnPublish_Behavior;
            }
            if (requestHandlerConfigs_handlerConfigs_OnPublish_onPublish_Behavior != null)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish.Behavior = requestHandlerConfigs_handlerConfigs_OnPublish_onPublish_Behavior;
                requestHandlerConfigs_handlerConfigs_OnPublishIsNull = false;
            }
            Amazon.AppSync.Model.Integration requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration = null;
            
             // populate Integration
            var requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_IntegrationIsNull = true;
            requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration = new Amazon.AppSync.Model.Integration();
            System.String requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_onPublish_Integration_DataSourceName = null;
            if (cmdletContext.OnPublish_Integration_DataSourceName != null)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_onPublish_Integration_DataSourceName = cmdletContext.OnPublish_Integration_DataSourceName;
            }
            if (requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_onPublish_Integration_DataSourceName != null)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration.DataSourceName = requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_onPublish_Integration_DataSourceName;
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_IntegrationIsNull = false;
            }
            Amazon.AppSync.Model.LambdaConfig requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig = null;
            
             // populate LambdaConfig
            var requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfigIsNull = true;
            requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig = new Amazon.AppSync.Model.LambdaConfig();
            Amazon.AppSync.InvokeType requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig_onPublish_LambdaConfig_InvokeType = null;
            if (cmdletContext.OnPublish_LambdaConfig_InvokeType != null)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig_onPublish_LambdaConfig_InvokeType = cmdletContext.OnPublish_LambdaConfig_InvokeType;
            }
            if (requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig_onPublish_LambdaConfig_InvokeType != null)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig.InvokeType = requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig_onPublish_LambdaConfig_InvokeType;
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfigIsNull = false;
            }
             // determine if requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig should be set to null
            if (requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfigIsNull)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig = null;
            }
            if (requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig != null)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration.LambdaConfig = requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration_handlerConfigs_OnPublish_Integration_LambdaConfig;
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_IntegrationIsNull = false;
            }
             // determine if requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration should be set to null
            if (requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_IntegrationIsNull)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration = null;
            }
            if (requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration != null)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish.Integration = requestHandlerConfigs_handlerConfigs_OnPublish_handlerConfigs_OnPublish_Integration;
                requestHandlerConfigs_handlerConfigs_OnPublishIsNull = false;
            }
             // determine if requestHandlerConfigs_handlerConfigs_OnPublish should be set to null
            if (requestHandlerConfigs_handlerConfigs_OnPublishIsNull)
            {
                requestHandlerConfigs_handlerConfigs_OnPublish = null;
            }
            if (requestHandlerConfigs_handlerConfigs_OnPublish != null)
            {
                request.HandlerConfigs.OnPublish = requestHandlerConfigs_handlerConfigs_OnPublish;
                requestHandlerConfigsIsNull = false;
            }
            Amazon.AppSync.Model.HandlerConfig requestHandlerConfigs_handlerConfigs_OnSubscribe = null;
            
             // populate OnSubscribe
            var requestHandlerConfigs_handlerConfigs_OnSubscribeIsNull = true;
            requestHandlerConfigs_handlerConfigs_OnSubscribe = new Amazon.AppSync.Model.HandlerConfig();
            Amazon.AppSync.HandlerBehavior requestHandlerConfigs_handlerConfigs_OnSubscribe_onSubscribe_Behavior = null;
            if (cmdletContext.OnSubscribe_Behavior != null)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe_onSubscribe_Behavior = cmdletContext.OnSubscribe_Behavior;
            }
            if (requestHandlerConfigs_handlerConfigs_OnSubscribe_onSubscribe_Behavior != null)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe.Behavior = requestHandlerConfigs_handlerConfigs_OnSubscribe_onSubscribe_Behavior;
                requestHandlerConfigs_handlerConfigs_OnSubscribeIsNull = false;
            }
            Amazon.AppSync.Model.Integration requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration = null;
            
             // populate Integration
            var requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_IntegrationIsNull = true;
            requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration = new Amazon.AppSync.Model.Integration();
            System.String requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_onSubscribe_Integration_DataSourceName = null;
            if (cmdletContext.OnSubscribe_Integration_DataSourceName != null)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_onSubscribe_Integration_DataSourceName = cmdletContext.OnSubscribe_Integration_DataSourceName;
            }
            if (requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_onSubscribe_Integration_DataSourceName != null)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration.DataSourceName = requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_onSubscribe_Integration_DataSourceName;
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_IntegrationIsNull = false;
            }
            Amazon.AppSync.Model.LambdaConfig requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig = null;
            
             // populate LambdaConfig
            var requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfigIsNull = true;
            requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig = new Amazon.AppSync.Model.LambdaConfig();
            Amazon.AppSync.InvokeType requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig_onSubscribe_LambdaConfig_InvokeType = null;
            if (cmdletContext.OnSubscribe_LambdaConfig_InvokeType != null)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig_onSubscribe_LambdaConfig_InvokeType = cmdletContext.OnSubscribe_LambdaConfig_InvokeType;
            }
            if (requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig_onSubscribe_LambdaConfig_InvokeType != null)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig.InvokeType = requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig_onSubscribe_LambdaConfig_InvokeType;
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfigIsNull = false;
            }
             // determine if requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig should be set to null
            if (requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfigIsNull)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig = null;
            }
            if (requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig != null)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration.LambdaConfig = requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration_handlerConfigs_OnSubscribe_Integration_LambdaConfig;
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_IntegrationIsNull = false;
            }
             // determine if requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration should be set to null
            if (requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_IntegrationIsNull)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration = null;
            }
            if (requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration != null)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe.Integration = requestHandlerConfigs_handlerConfigs_OnSubscribe_handlerConfigs_OnSubscribe_Integration;
                requestHandlerConfigs_handlerConfigs_OnSubscribeIsNull = false;
            }
             // determine if requestHandlerConfigs_handlerConfigs_OnSubscribe should be set to null
            if (requestHandlerConfigs_handlerConfigs_OnSubscribeIsNull)
            {
                requestHandlerConfigs_handlerConfigs_OnSubscribe = null;
            }
            if (requestHandlerConfigs_handlerConfigs_OnSubscribe != null)
            {
                request.HandlerConfigs.OnSubscribe = requestHandlerConfigs_handlerConfigs_OnSubscribe;
                requestHandlerConfigsIsNull = false;
            }
             // determine if request.HandlerConfigs should be set to null
            if (requestHandlerConfigsIsNull)
            {
                request.HandlerConfigs = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PublishAuthMode != null)
            {
                request.PublishAuthModes = cmdletContext.PublishAuthMode;
            }
            if (cmdletContext.SubscribeAuthMode != null)
            {
                request.SubscribeAuthModes = cmdletContext.SubscribeAuthMode;
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
        
        private Amazon.AppSync.Model.CreateChannelNamespaceResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.CreateChannelNamespaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "CreateChannelNamespace");
            try
            {
                #if DESKTOP
                return client.CreateChannelNamespace(request);
                #elif CORECLR
                return client.CreateChannelNamespaceAsync(request).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
            public System.String CodeHandler { get; set; }
            public Amazon.AppSync.HandlerBehavior OnPublish_Behavior { get; set; }
            public System.String OnPublish_Integration_DataSourceName { get; set; }
            public Amazon.AppSync.InvokeType OnPublish_LambdaConfig_InvokeType { get; set; }
            public Amazon.AppSync.HandlerBehavior OnSubscribe_Behavior { get; set; }
            public System.String OnSubscribe_Integration_DataSourceName { get; set; }
            public Amazon.AppSync.InvokeType OnSubscribe_LambdaConfig_InvokeType { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.AppSync.Model.AuthMode> PublishAuthMode { get; set; }
            public List<Amazon.AppSync.Model.AuthMode> SubscribeAuthMode { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.AppSync.Model.CreateChannelNamespaceResponse, NewASYNChannelNamespaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelNamespace;
        }
        
    }
}
