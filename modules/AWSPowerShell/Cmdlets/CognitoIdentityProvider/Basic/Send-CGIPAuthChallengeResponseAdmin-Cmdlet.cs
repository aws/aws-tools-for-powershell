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
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Responds to an authentication challenge, as an administrator.
    /// 
    ///  
    /// <para>
    /// Calling this action requires developer credentials.
    /// </para>
    /// </summary>
    [Cmdlet("Send", "CGIPAuthChallengeResponseAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminRespondToAuthChallenge API operation.", Operation = new[] {"AdminRespondToAuthChallenge"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendCGIPAuthChallengeResponseAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AnalyticsMetadata_AnalyticsEndpointId
        /// <summary>
        /// <para>
        /// <para>The endpoint ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AnalyticsMetadata_AnalyticsEndpointId { get; set; }
        #endregion
        
        #region Parameter ChallengeName
        /// <summary>
        /// <para>
        /// <para>The challenge name. For more information, see .</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.ChallengeNameType")]
        public Amazon.CognitoIdentityProvider.ChallengeNameType ChallengeName { get; set; }
        #endregion
        
        #region Parameter ChallengeResponse
        /// <summary>
        /// <para>
        /// <para>The challenge responses. These are inputs corresponding to the value of <code>ChallengeName</code>,
        /// for example:</para><ul><li><para><code>SMS_MFA</code>: <code>SMS_MFA_CODE</code>, <code>USERNAME</code>, <code>SECRET_HASH</code>
        /// (if app client is configured with client secret).</para></li><li><para><code>PASSWORD_VERIFIER</code>: <code>PASSWORD_CLAIM_SIGNATURE</code>, <code>PASSWORD_CLAIM_SECRET_BLOCK</code>,
        /// <code>TIMESTAMP</code>, <code>USERNAME</code>, <code>SECRET_HASH</code> (if app client
        /// is configured with client secret).</para></li><li><para><code>ADMIN_NO_SRP_AUTH</code>: <code>PASSWORD</code>, <code>USERNAME</code>, <code>SECRET_HASH</code>
        /// (if app client is configured with client secret). </para></li><li><para><code>NEW_PASSWORD_REQUIRED</code>: <code>NEW_PASSWORD</code>, any other required
        /// attributes, <code>USERNAME</code>, <code>SECRET_HASH</code> (if app client is configured
        /// with client secret). </para></li></ul><para>The value of the <code>USERNAME</code> attribute must be the user's actual username,
        /// not an alias (such as email address or phone number). To make this easier, the <code>AdminInitiateAuth</code>
        /// response includes the actual username value in the <code>USERNAMEUSER_ID_FOR_SRP</code>
        /// attribute, even if you specified an alias in your call to <code>AdminInitiateAuth</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ChallengeResponses")]
        public System.Collections.Hashtable ChallengeResponse { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The app client ID.</para>
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
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter ClientMetadata
        /// <summary>
        /// <para>
        /// <para>A map of custom key-value pairs that you can provide as input for any custom workflows
        /// that this action triggers. </para><para>You create custom workflows by assigning AWS Lambda functions to user pool triggers.
        /// When you use the AdminRespondToAuthChallenge API action, Amazon Cognito invokes any
        /// functions that are assigned to the following triggers: <i>pre sign-up</i>, <i>custom
        /// message</i>, <i>post authentication</i>, <i>user migration</i>, <i>pre token generation</i>,
        /// <i>define auth challenge</i>, <i>create auth challenge</i>, and <i>verify auth challenge
        /// response</i>. When Amazon Cognito invokes any of these functions, it passes a JSON
        /// payload, which the function receives as input. This payload contains a <code>clientMetadata</code>
        /// attribute, which provides the data that you assigned to the ClientMetadata parameter
        /// in your AdminRespondToAuthChallenge request. In your function code in AWS Lambda,
        /// you can process the <code>clientMetadata</code> value to enhance your workflow for
        /// your specific needs.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">Customizing
        /// User Pool Workflows with Lambda Triggers</a> in the <i>Amazon Cognito Developer Guide</i>.</para><note><para>Take the following limitations into consideration when you use the ClientMetadata
        /// parameter:</para><ul><li><para>Amazon Cognito does not store the ClientMetadata value. This data is available only
        /// to AWS Lambda triggers that are assigned to a user pool to support custom workflows.
        /// If your user pool configuration does not include triggers, the ClientMetadata parameter
        /// serves no purpose.</para></li><li><para>Amazon Cognito does not validate the ClientMetadata value.</para></li><li><para>Amazon Cognito does not encrypt the the ClientMetadata value, so don't use it to provide
        /// sensitive information.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ClientMetadata { get; set; }
        #endregion
        
        #region Parameter ContextData_EncodedData
        /// <summary>
        /// <para>
        /// <para>Encoded data containing device fingerprinting details, collected using the Amazon
        /// Cognito context data collection library.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_EncodedData { get; set; }
        #endregion
        
        #region Parameter ContextData_HttpHeader
        /// <summary>
        /// <para>
        /// <para>HttpHeaders received on your server in same order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ContextData_HttpHeaders")]
        public Amazon.CognitoIdentityProvider.Model.HttpHeader[] ContextData_HttpHeader { get; set; }
        #endregion
        
        #region Parameter ContextData_IpAddress
        /// <summary>
        /// <para>
        /// <para>Source IP address of your user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_IpAddress { get; set; }
        #endregion
        
        #region Parameter ContextData_ServerName
        /// <summary>
        /// <para>
        /// <para>Your server endpoint where this API is invoked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_ServerName { get; set; }
        #endregion
        
        #region Parameter ContextData_ServerPath
        /// <summary>
        /// <para>
        /// <para>Your server path where this API is invoked. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextData_ServerPath { get; set; }
        #endregion
        
        #region Parameter Session
        /// <summary>
        /// <para>
        /// <para>The session which should be passed both ways in challenge-response calls to the service.
        /// If <code>InitiateAuth</code> or <code>RespondToAuthChallenge</code> API call determines
        /// that the caller needs to go through another challenge, they return a session with
        /// other challenge parameters. This session should be passed as it is to the next <code>RespondToAuthChallenge</code>
        /// API call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Session { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Cognito user pool.</para>
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
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ClientId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ClientId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ClientId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CGIPAuthChallengeResponseAdmin (AdminRespondToAuthChallenge)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse, SendCGIPAuthChallengeResponseAdminCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ClientId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AnalyticsMetadata_AnalyticsEndpointId = this.AnalyticsMetadata_AnalyticsEndpointId;
            context.ChallengeName = this.ChallengeName;
            #if MODULAR
            if (this.ChallengeName == null && ParameterWasBound(nameof(this.ChallengeName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChallengeName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ChallengeResponse != null)
            {
                context.ChallengeResponse = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ChallengeResponse.Keys)
                {
                    context.ChallengeResponse.Add((String)hashKey, (String)(this.ChallengeResponse[hashKey]));
                }
            }
            context.ClientId = this.ClientId;
            #if MODULAR
            if (this.ClientId == null && ParameterWasBound(nameof(this.ClientId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ClientMetadata != null)
            {
                context.ClientMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ClientMetadata.Keys)
                {
                    context.ClientMetadata.Add((String)hashKey, (String)(this.ClientMetadata[hashKey]));
                }
            }
            context.ContextData_EncodedData = this.ContextData_EncodedData;
            if (this.ContextData_HttpHeader != null)
            {
                context.ContextData_HttpHeader = new List<Amazon.CognitoIdentityProvider.Model.HttpHeader>(this.ContextData_HttpHeader);
            }
            context.ContextData_IpAddress = this.ContextData_IpAddress;
            context.ContextData_ServerName = this.ContextData_ServerName;
            context.ContextData_ServerPath = this.ContextData_ServerPath;
            context.Session = this.Session;
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeRequest();
            
            
             // populate AnalyticsMetadata
            var requestAnalyticsMetadataIsNull = true;
            request.AnalyticsMetadata = new Amazon.CognitoIdentityProvider.Model.AnalyticsMetadataType();
            System.String requestAnalyticsMetadata_analyticsMetadata_AnalyticsEndpointId = null;
            if (cmdletContext.AnalyticsMetadata_AnalyticsEndpointId != null)
            {
                requestAnalyticsMetadata_analyticsMetadata_AnalyticsEndpointId = cmdletContext.AnalyticsMetadata_AnalyticsEndpointId;
            }
            if (requestAnalyticsMetadata_analyticsMetadata_AnalyticsEndpointId != null)
            {
                request.AnalyticsMetadata.AnalyticsEndpointId = requestAnalyticsMetadata_analyticsMetadata_AnalyticsEndpointId;
                requestAnalyticsMetadataIsNull = false;
            }
             // determine if request.AnalyticsMetadata should be set to null
            if (requestAnalyticsMetadataIsNull)
            {
                request.AnalyticsMetadata = null;
            }
            if (cmdletContext.ChallengeName != null)
            {
                request.ChallengeName = cmdletContext.ChallengeName;
            }
            if (cmdletContext.ChallengeResponse != null)
            {
                request.ChallengeResponses = cmdletContext.ChallengeResponse;
            }
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.ClientMetadata != null)
            {
                request.ClientMetadata = cmdletContext.ClientMetadata;
            }
            
             // populate ContextData
            var requestContextDataIsNull = true;
            request.ContextData = new Amazon.CognitoIdentityProvider.Model.ContextDataType();
            System.String requestContextData_contextData_EncodedData = null;
            if (cmdletContext.ContextData_EncodedData != null)
            {
                requestContextData_contextData_EncodedData = cmdletContext.ContextData_EncodedData;
            }
            if (requestContextData_contextData_EncodedData != null)
            {
                request.ContextData.EncodedData = requestContextData_contextData_EncodedData;
                requestContextDataIsNull = false;
            }
            List<Amazon.CognitoIdentityProvider.Model.HttpHeader> requestContextData_contextData_HttpHeader = null;
            if (cmdletContext.ContextData_HttpHeader != null)
            {
                requestContextData_contextData_HttpHeader = cmdletContext.ContextData_HttpHeader;
            }
            if (requestContextData_contextData_HttpHeader != null)
            {
                request.ContextData.HttpHeaders = requestContextData_contextData_HttpHeader;
                requestContextDataIsNull = false;
            }
            System.String requestContextData_contextData_IpAddress = null;
            if (cmdletContext.ContextData_IpAddress != null)
            {
                requestContextData_contextData_IpAddress = cmdletContext.ContextData_IpAddress;
            }
            if (requestContextData_contextData_IpAddress != null)
            {
                request.ContextData.IpAddress = requestContextData_contextData_IpAddress;
                requestContextDataIsNull = false;
            }
            System.String requestContextData_contextData_ServerName = null;
            if (cmdletContext.ContextData_ServerName != null)
            {
                requestContextData_contextData_ServerName = cmdletContext.ContextData_ServerName;
            }
            if (requestContextData_contextData_ServerName != null)
            {
                request.ContextData.ServerName = requestContextData_contextData_ServerName;
                requestContextDataIsNull = false;
            }
            System.String requestContextData_contextData_ServerPath = null;
            if (cmdletContext.ContextData_ServerPath != null)
            {
                requestContextData_contextData_ServerPath = cmdletContext.ContextData_ServerPath;
            }
            if (requestContextData_contextData_ServerPath != null)
            {
                request.ContextData.ServerPath = requestContextData_contextData_ServerPath;
                requestContextDataIsNull = false;
            }
             // determine if request.ContextData should be set to null
            if (requestContextDataIsNull)
            {
                request.ContextData = null;
            }
            if (cmdletContext.Session != null)
            {
                request.Session = cmdletContext.Session;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminRespondToAuthChallenge");
            try
            {
                #if DESKTOP
                return client.AdminRespondToAuthChallenge(request);
                #elif CORECLR
                return client.AdminRespondToAuthChallengeAsync(request).GetAwaiter().GetResult();
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
            public System.String AnalyticsMetadata_AnalyticsEndpointId { get; set; }
            public Amazon.CognitoIdentityProvider.ChallengeNameType ChallengeName { get; set; }
            public Dictionary<System.String, System.String> ChallengeResponse { get; set; }
            public System.String ClientId { get; set; }
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public System.String ContextData_EncodedData { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.HttpHeader> ContextData_HttpHeader { get; set; }
            public System.String ContextData_IpAddress { get; set; }
            public System.String ContextData_ServerName { get; set; }
            public System.String ContextData_ServerPath { get; set; }
            public System.String Session { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.AdminRespondToAuthChallengeResponse, SendCGIPAuthChallengeResponseAdminCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
