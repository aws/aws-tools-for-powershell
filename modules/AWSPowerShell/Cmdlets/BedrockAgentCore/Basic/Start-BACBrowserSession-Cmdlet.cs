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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Creates and initializes a browser session in Amazon Bedrock AgentCore. The session
    /// enables agents to navigate and interact with web content, extract information from
    /// websites, and perform web-based tasks as part of their response generation.
    /// 
    ///  
    /// <para>
    /// To create a session, you must specify a browser identifier and a name. You can also
    /// configure the viewport dimensions to control the visible area of web content. The
    /// session remains active until it times out or you explicitly stop it using the <c>StopBrowserSession</c>
    /// operation.
    /// </para><para>
    /// The following operations are related to <c>StartBrowserSession</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_GetBrowserSession.html">GetBrowserSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_UpdateBrowserStream.html">UpdateBrowserStream</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_SaveBrowserSessionProfile.html">SaveBrowserSessionProfile</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_StopBrowserSession.html">StopBrowserSession</a></para></li></ul>
    /// </summary>
    [Cmdlet("Start", "BACBrowserSession", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer StartBrowserSession API operation.", Operation = new[] {"StartBrowserSession"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse object containing multiple properties."
    )]
    public partial class StartBACBrowserSessionCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BrowserIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the browser to use for this session. This identifier specifies
        /// which browser environment to initialize for the session.</para>
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
        public System.String BrowserIdentifier { get; set; }
        #endregion
        
        #region Parameter Extension
        /// <summary>
        /// <para>
        /// <para>A list of browser extensions to load into the browser session.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Extensions")]
        public Amazon.BedrockAgentCore.Model.BrowserExtension[] Extension { get; set; }
        #endregion
        
        #region Parameter ViewPort_Height
        /// <summary>
        /// <para>
        /// <para>The height of the viewport in pixels. This value determines the vertical dimension
        /// of the visible area. Valid values range from 600 to 1080 pixels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ViewPort_Height { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the browser session. This name helps you identify and manage the session.
        /// The name does not need to be unique.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProfileConfiguration_ProfileIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the browser profile. This identifier is used to reference
        /// the profile when starting new browser sessions or saving session data to the profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProfileConfiguration_ProfileIdentifier { get; set; }
        #endregion
        
        #region Parameter SessionTimeoutSecond
        /// <summary>
        /// <para>
        /// <para>The time in seconds after which the session automatically terminates if there is no
        /// activity. The default value is 3600 seconds (1 hour). The minimum allowed value is
        /// 60 seconds, and the maximum allowed value is 28800 seconds (8 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SessionTimeoutSeconds")]
        public System.Int32? SessionTimeoutSecond { get; set; }
        #endregion
        
        #region Parameter TraceId
        /// <summary>
        /// <para>
        /// <para>The trace identifier for request tracking.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceId { get; set; }
        #endregion
        
        #region Parameter TraceParent
        /// <summary>
        /// <para>
        /// <para>The parent trace information for distributed tracing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TraceParent { get; set; }
        #endregion
        
        #region Parameter ViewPort_Width
        /// <summary>
        /// <para>
        /// <para>The width of the viewport in pixels. This value determines the horizontal dimension
        /// of the visible area. Valid values range from 800 to 1920 pixels.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ViewPort_Width { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock AgentCore
        /// ignores the request, but does not return an error. This parameter helps prevent the
        /// creation of duplicate sessions if there are temporary network issues.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BrowserIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-BACBrowserSession (StartBrowserSession)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse, StartBACBrowserSessionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BrowserIdentifier = this.BrowserIdentifier;
            #if MODULAR
            if (this.BrowserIdentifier == null && ParameterWasBound(nameof(this.BrowserIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter BrowserIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.Extension != null)
            {
                context.Extension = new List<Amazon.BedrockAgentCore.Model.BrowserExtension>(this.Extension);
            }
            context.Name = this.Name;
            context.ProfileConfiguration_ProfileIdentifier = this.ProfileConfiguration_ProfileIdentifier;
            context.SessionTimeoutSecond = this.SessionTimeoutSecond;
            context.TraceId = this.TraceId;
            context.TraceParent = this.TraceParent;
            context.ViewPort_Height = this.ViewPort_Height;
            context.ViewPort_Width = this.ViewPort_Width;
            
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
            var request = new Amazon.BedrockAgentCore.Model.StartBrowserSessionRequest();
            
            if (cmdletContext.BrowserIdentifier != null)
            {
                request.BrowserIdentifier = cmdletContext.BrowserIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Extension != null)
            {
                request.Extensions = cmdletContext.Extension;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ProfileConfiguration
            var requestProfileConfigurationIsNull = true;
            request.ProfileConfiguration = new Amazon.BedrockAgentCore.Model.BrowserProfileConfiguration();
            System.String requestProfileConfiguration_profileConfiguration_ProfileIdentifier = null;
            if (cmdletContext.ProfileConfiguration_ProfileIdentifier != null)
            {
                requestProfileConfiguration_profileConfiguration_ProfileIdentifier = cmdletContext.ProfileConfiguration_ProfileIdentifier;
            }
            if (requestProfileConfiguration_profileConfiguration_ProfileIdentifier != null)
            {
                request.ProfileConfiguration.ProfileIdentifier = requestProfileConfiguration_profileConfiguration_ProfileIdentifier;
                requestProfileConfigurationIsNull = false;
            }
             // determine if request.ProfileConfiguration should be set to null
            if (requestProfileConfigurationIsNull)
            {
                request.ProfileConfiguration = null;
            }
            if (cmdletContext.SessionTimeoutSecond != null)
            {
                request.SessionTimeoutSeconds = cmdletContext.SessionTimeoutSecond.Value;
            }
            if (cmdletContext.TraceId != null)
            {
                request.TraceId = cmdletContext.TraceId;
            }
            if (cmdletContext.TraceParent != null)
            {
                request.TraceParent = cmdletContext.TraceParent;
            }
            
             // populate ViewPort
            var requestViewPortIsNull = true;
            request.ViewPort = new Amazon.BedrockAgentCore.Model.ViewPort();
            System.Int32? requestViewPort_viewPort_Height = null;
            if (cmdletContext.ViewPort_Height != null)
            {
                requestViewPort_viewPort_Height = cmdletContext.ViewPort_Height.Value;
            }
            if (requestViewPort_viewPort_Height != null)
            {
                request.ViewPort.Height = requestViewPort_viewPort_Height.Value;
                requestViewPortIsNull = false;
            }
            System.Int32? requestViewPort_viewPort_Width = null;
            if (cmdletContext.ViewPort_Width != null)
            {
                requestViewPort_viewPort_Width = cmdletContext.ViewPort_Width.Value;
            }
            if (requestViewPort_viewPort_Width != null)
            {
                request.ViewPort.Width = requestViewPort_viewPort_Width.Value;
                requestViewPortIsNull = false;
            }
             // determine if request.ViewPort should be set to null
            if (requestViewPortIsNull)
            {
                request.ViewPort = null;
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
        
        private Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.StartBrowserSessionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "StartBrowserSession");
            try
            {
                return client.StartBrowserSessionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BrowserIdentifier { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.BedrockAgentCore.Model.BrowserExtension> Extension { get; set; }
            public System.String Name { get; set; }
            public System.String ProfileConfiguration_ProfileIdentifier { get; set; }
            public System.Int32? SessionTimeoutSecond { get; set; }
            public System.String TraceId { get; set; }
            public System.String TraceParent { get; set; }
            public System.Int32? ViewPort_Height { get; set; }
            public System.Int32? ViewPort_Width { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.StartBrowserSessionResponse, StartBACBrowserSessionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
