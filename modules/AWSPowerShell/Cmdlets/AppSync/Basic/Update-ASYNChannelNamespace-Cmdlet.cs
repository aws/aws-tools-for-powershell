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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Updates a <c>ChannelNamespace</c> associated with an <c>Api</c>.
    /// </summary>
    [Cmdlet("Update", "ASYNChannelNamespace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.ChannelNamespace")]
    [AWSCmdlet("Calls the AWS AppSync UpdateChannelNamespace API operation.", Operation = new[] {"UpdateChannelNamespace"}, SelectReturnType = typeof(Amazon.AppSync.Model.UpdateChannelNamespaceResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.ChannelNamespace or Amazon.AppSync.Model.UpdateChannelNamespaceResponse",
        "This cmdlet returns an Amazon.AppSync.Model.ChannelNamespace object.",
        "The service call response (type Amazon.AppSync.Model.UpdateChannelNamespaceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateASYNChannelNamespaceCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the <c>ChannelNamespace</c>.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelNamespace'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.UpdateChannelNamespaceResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.UpdateChannelNamespaceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelNamespace";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASYNChannelNamespace (UpdateChannelNamespace)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.UpdateChannelNamespaceResponse, UpdateASYNChannelNamespaceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CodeHandler = this.CodeHandler;
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
            var request = new Amazon.AppSync.Model.UpdateChannelNamespaceRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.CodeHandler != null)
            {
                request.CodeHandlers = cmdletContext.CodeHandler;
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
        
        private Amazon.AppSync.Model.UpdateChannelNamespaceResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.UpdateChannelNamespaceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "UpdateChannelNamespace");
            try
            {
                return client.UpdateChannelNamespaceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public List<Amazon.AppSync.Model.AuthMode> PublishAuthMode { get; set; }
            public List<Amazon.AppSync.Model.AuthMode> SubscribeAuthMode { get; set; }
            public System.Func<Amazon.AppSync.Model.UpdateChannelNamespaceResponse, UpdateASYNChannelNamespaceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelNamespace;
        }
        
    }
}
