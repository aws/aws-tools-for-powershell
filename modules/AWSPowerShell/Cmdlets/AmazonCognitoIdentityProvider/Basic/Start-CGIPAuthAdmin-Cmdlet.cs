/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Initiates the authentication flow, as an administrator.
    /// 
    ///  
    /// <para>
    /// Requires developer credentials.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "CGIPAuthAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminInitiateAuth API operation.", Operation = new[] {"AdminInitiateAuth"})]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse",
        "This cmdlet returns a Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCGIPAuthAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter AnalyticsMetadata_AnalyticsEndpointId
        /// <summary>
        /// <para>
        /// <para>The endpoint ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AnalyticsMetadata_AnalyticsEndpointId { get; set; }
        #endregion
        
        #region Parameter AuthFlow
        /// <summary>
        /// <para>
        /// <para>The authentication flow for this call to execute. The API action will depend on this
        /// value. For example:</para><ul><li><para><code>REFRESH_TOKEN_AUTH</code> will take in a valid refresh token and return new
        /// tokens.</para></li><li><para><code>USER_SRP_AUTH</code> will take in <code>USERNAME</code> and <code>SRP_A</code>
        /// and return the SRP variables to be used for next challenge execution.</para></li><li><para><code>USER_PASSWORD_AUTH</code> will take in <code>USERNAME</code> and <code>PASSWORD</code>
        /// and return the next challenge or tokens.</para></li></ul><para>Valid values include:</para><ul><li><para><code>USER_SRP_AUTH</code>: Authentication flow for the Secure Remote Password (SRP)
        /// protocol.</para></li><li><para><code>REFRESH_TOKEN_AUTH</code>/<code>REFRESH_TOKEN</code>: Authentication flow for
        /// refreshing the access token and ID token by supplying a valid refresh token.</para></li><li><para><code>CUSTOM_AUTH</code>: Custom authentication flow.</para></li><li><para><code>ADMIN_NO_SRP_AUTH</code>: Non-SRP authentication flow; you can pass in the
        /// USERNAME and PASSWORD directly if the flow is enabled for calling the app client.</para></li><li><para><code>USER_PASSWORD_AUTH</code>: Non-SRP authentication flow; USERNAME and PASSWORD
        /// are passed directly. If a user migration Lambda trigger is set, this flow will invoke
        /// the user migration Lambda if the USERNAME is not found in the user pool. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.AuthFlowType")]
        public Amazon.CognitoIdentityProvider.AuthFlowType AuthFlow { get; set; }
        #endregion
        
        #region Parameter AuthParameter
        /// <summary>
        /// <para>
        /// <para>The authentication parameters. These are inputs corresponding to the <code>AuthFlow</code>
        /// that you are invoking. The required values depend on the value of <code>AuthFlow</code>:</para><ul><li><para>For <code>USER_SRP_AUTH</code>: <code>USERNAME</code> (required), <code>SRP_A</code>
        /// (required), <code>SECRET_HASH</code> (required if the app client is configured with
        /// a client secret), <code>DEVICE_KEY</code></para></li><li><para>For <code>REFRESH_TOKEN_AUTH/REFRESH_TOKEN</code>: <code>REFRESH_TOKEN</code> (required),
        /// <code>SECRET_HASH</code> (required if the app client is configured with a client secret),
        /// <code>DEVICE_KEY</code></para></li><li><para>For <code>ADMIN_NO_SRP_AUTH</code>: <code>USERNAME</code> (required), <code>SECRET_HASH</code>
        /// (if app client is configured with client secret), <code>PASSWORD</code> (required),
        /// <code>DEVICE_KEY</code></para></li><li><para>For <code>CUSTOM_AUTH</code>: <code>USERNAME</code> (required), <code>SECRET_HASH</code>
        /// (if app client is configured with client secret), <code>DEVICE_KEY</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AuthParameters")]
        public System.Collections.Hashtable AuthParameter { get; set; }
        #endregion
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The app client ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter ClientMetadata
        /// <summary>
        /// <para>
        /// <para>This is a random key-value pair map which can contain any key and will be passed to
        /// your PreAuthentication Lambda trigger as-is. It can be used to implement additional
        /// validations around authentication.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Collections.Hashtable ClientMetadata { get; set; }
        #endregion
        
        #region Parameter ContextData_EncodedData
        /// <summary>
        /// <para>
        /// <para>Encoded data containing device fingerprinting details, collected using the Amazon
        /// Cognito context data collection library.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContextData_EncodedData { get; set; }
        #endregion
        
        #region Parameter ContextData_HttpHeader
        /// <summary>
        /// <para>
        /// <para>HttpHeaders received on your server in same order.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ContextData_HttpHeaders")]
        public Amazon.CognitoIdentityProvider.Model.HttpHeader[] ContextData_HttpHeader { get; set; }
        #endregion
        
        #region Parameter ContextData_IpAddress
        /// <summary>
        /// <para>
        /// <para>Source IP address of your user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContextData_IpAddress { get; set; }
        #endregion
        
        #region Parameter ContextData_ServerName
        /// <summary>
        /// <para>
        /// <para>Your server endpoint where this API is invoked.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContextData_ServerName { get; set; }
        #endregion
        
        #region Parameter ContextData_ServerPath
        /// <summary>
        /// <para>
        /// <para>Your server path where this API is invoked. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ContextData_ServerPath { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Cognito user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClientId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CGIPAuthAdmin (AdminInitiateAuth)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AnalyticsMetadata_AnalyticsEndpointId = this.AnalyticsMetadata_AnalyticsEndpointId;
            context.AuthFlow = this.AuthFlow;
            if (this.AuthParameter != null)
            {
                context.AuthParameters = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AuthParameter.Keys)
                {
                    context.AuthParameters.Add((String)hashKey, (String)(this.AuthParameter[hashKey]));
                }
            }
            context.ClientId = this.ClientId;
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
                context.ContextData_HttpHeaders = new List<Amazon.CognitoIdentityProvider.Model.HttpHeader>(this.ContextData_HttpHeader);
            }
            context.ContextData_IpAddress = this.ContextData_IpAddress;
            context.ContextData_ServerName = this.ContextData_ServerName;
            context.ContextData_ServerPath = this.ContextData_ServerPath;
            context.UserPoolId = this.UserPoolId;
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthRequest();
            
            
             // populate AnalyticsMetadata
            bool requestAnalyticsMetadataIsNull = true;
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
            if (cmdletContext.AuthFlow != null)
            {
                request.AuthFlow = cmdletContext.AuthFlow;
            }
            if (cmdletContext.AuthParameters != null)
            {
                request.AuthParameters = cmdletContext.AuthParameters;
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
            bool requestContextDataIsNull = true;
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
            if (cmdletContext.ContextData_HttpHeaders != null)
            {
                requestContextData_contextData_HttpHeader = cmdletContext.ContextData_HttpHeaders;
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
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminInitiateAuthRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminInitiateAuth");
            try
            {
                #if DESKTOP
                return client.AdminInitiateAuth(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AdminInitiateAuthAsync(request);
                return task.Result;
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
            public Amazon.CognitoIdentityProvider.AuthFlowType AuthFlow { get; set; }
            public Dictionary<System.String, System.String> AuthParameters { get; set; }
            public System.String ClientId { get; set; }
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public System.String ContextData_EncodedData { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.HttpHeader> ContextData_HttpHeaders { get; set; }
            public System.String ContextData_IpAddress { get; set; }
            public System.String ContextData_ServerName { get; set; }
            public System.String ContextData_ServerPath { get; set; }
            public System.String UserPoolId { get; set; }
        }
        
    }
}
