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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Saves the current state of a browser session as a reusable profile in Amazon Bedrock
    /// AgentCore. A browser profile captures persistent browser data such as cookies and
    /// local storage from an active session, enabling you to reuse this data in future browser
    /// sessions.
    /// 
    ///  
    /// <para>
    /// To save a browser session profile, you must specify the profile identifier, browser
    /// identifier, and session ID. The session must be active when saving the profile. Once
    /// saved, the profile can be used with the <c>StartBrowserSession</c> operation to initialize
    /// new sessions with the stored browser state.
    /// </para><para>
    /// Browser profiles are useful for scenarios that require persistent authentication,
    /// maintaining user preferences across sessions, or continuing tasks that depend on previously
    /// stored browser data.
    /// </para><para>
    /// The following operations are related to <c>SaveBrowserSessionProfile</c>:
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_StartBrowserSession.html">StartBrowserSession</a></para></li><li><para><a href="https://docs.aws.amazon.com/bedrock-agentcore/latest/APIReference/API_GetBrowserSession.html">GetBrowserSession</a></para></li></ul>
    /// </summary>
    [Cmdlet("Save", "BACBrowserSessionProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer SaveBrowserSessionProfile API operation.", Operation = new[] {"SaveBrowserSessionProfile"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse object containing multiple properties."
    )]
    public partial class SaveBACBrowserSessionProfileCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BrowserIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the browser associated with the session from which to save
        /// the profile.</para>
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
        public System.String BrowserIdentifier { get; set; }
        #endregion
        
        #region Parameter ProfileIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the browser profile. This identifier is used to reference
        /// the profile when starting new browser sessions. The identifier must follow the pattern
        /// of an alphanumeric name (up to 48 characters) followed by a hyphen and a 10-character
        /// alphanumeric suffix.</para>
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
        public System.String ProfileIdentifier { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the browser session from which to save the profile. The session
        /// must be active when saving the profile.</para>
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
        public System.String SessionId { get; set; }
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the API request completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock AgentCore
        /// ignores the request, but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var targetParameterNames = new string[]
            {
                nameof(this.SessionId),
                nameof(this.BrowserIdentifier),
                nameof(this.ProfileIdentifier)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Save-BACBrowserSessionProfile (SaveBrowserSessionProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse, SaveBACBrowserSessionProfileCmdlet>(Select) ??
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
            context.ProfileIdentifier = this.ProfileIdentifier;
            #if MODULAR
            if (this.ProfileIdentifier == null && ParameterWasBound(nameof(this.ProfileIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TraceId = this.TraceId;
            context.TraceParent = this.TraceParent;
            
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
            var request = new Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileRequest();
            
            if (cmdletContext.BrowserIdentifier != null)
            {
                request.BrowserIdentifier = cmdletContext.BrowserIdentifier;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ProfileIdentifier != null)
            {
                request.ProfileIdentifier = cmdletContext.ProfileIdentifier;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            if (cmdletContext.TraceId != null)
            {
                request.TraceId = cmdletContext.TraceId;
            }
            if (cmdletContext.TraceParent != null)
            {
                request.TraceParent = cmdletContext.TraceParent;
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
        
        private Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "SaveBrowserSessionProfile");
            try
            {
                #if DESKTOP
                return client.SaveBrowserSessionProfile(request);
                #elif CORECLR
                return client.SaveBrowserSessionProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String BrowserIdentifier { get; set; }
            public System.String ClientToken { get; set; }
            public System.String ProfileIdentifier { get; set; }
            public System.String SessionId { get; set; }
            public System.String TraceId { get; set; }
            public System.String TraceParent { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.SaveBrowserSessionProfileResponse, SaveBACBrowserSessionProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
