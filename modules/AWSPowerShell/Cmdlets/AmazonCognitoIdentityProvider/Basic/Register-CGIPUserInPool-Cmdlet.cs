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
    /// Registers the user in the specified user pool and creates a user name, password, and
    /// user attributes.
    /// </summary>
    [Cmdlet("Register", "CGIPUserInPool", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.SignUpResponse")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider SignUp API operation. This operation uses anonymous authentication and does not require credential parameters to be supplied.", Operation = new[] {"SignUp"})]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.SignUpResponse",
        "This cmdlet returns a Amazon.CognitoIdentityProvider.Model.SignUpResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RegisterCGIPUserInPoolCmdlet : AnonymousAmazonCognitoIdentityProviderClientCmdlet, IExecutor
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
        
        #region Parameter ClientId
        /// <summary>
        /// <para>
        /// <para>The ID of the client associated with the user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientId { get; set; }
        #endregion
        
        #region Parameter UserContextData_EncodedData
        /// <summary>
        /// <para>
        /// <para>Contextual data such as the user's device fingerprint, IP address, or location used
        /// for evaluating the risk of an unexpected event by Amazon Cognito advanced security.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String UserContextData_EncodedData { get; set; }
        #endregion
        
        #region Parameter Password
        /// <summary>
        /// <para>
        /// <para>The password of the user you wish to register.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Password { get; set; }
        #endregion
        
        #region Parameter SecretHash
        /// <summary>
        /// <para>
        /// <para>A keyed-hash message authentication code (HMAC) calculated using the secret key of
        /// a user pool client and username plus the client ID in the message.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SecretHash { get; set; }
        #endregion
        
        #region Parameter UserAttribute
        /// <summary>
        /// <para>
        /// <para>An array of name-value pairs representing user attributes.</para><para>For custom attributes, you must prepend the <code>custom:</code> prefix to the attribute
        /// name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserAttributes")]
        public Amazon.CognitoIdentityProvider.Model.AttributeType[] UserAttribute { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The user name of the user you wish to register.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter ValidationData
        /// <summary>
        /// <para>
        /// <para>The validation data in the request to register a user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CognitoIdentityProvider.Model.AttributeType[] ValidationData { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Username", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-CGIPUserInPool (SignUp)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AnalyticsMetadata_AnalyticsEndpointId = this.AnalyticsMetadata_AnalyticsEndpointId;
            context.ClientId = this.ClientId;
            context.Password = this.Password;
            context.SecretHash = this.SecretHash;
            if (this.UserAttribute != null)
            {
                context.UserAttributes = new List<Amazon.CognitoIdentityProvider.Model.AttributeType>(this.UserAttribute);
            }
            context.UserContextData_EncodedData = this.UserContextData_EncodedData;
            context.Username = this.Username;
            if (this.ValidationData != null)
            {
                context.ValidationData = new List<Amazon.CognitoIdentityProvider.Model.AttributeType>(this.ValidationData);
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
            var request = new Amazon.CognitoIdentityProvider.Model.SignUpRequest();
            
            
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
            if (cmdletContext.ClientId != null)
            {
                request.ClientId = cmdletContext.ClientId;
            }
            if (cmdletContext.Password != null)
            {
                request.Password = cmdletContext.Password;
            }
            if (cmdletContext.SecretHash != null)
            {
                request.SecretHash = cmdletContext.SecretHash;
            }
            if (cmdletContext.UserAttributes != null)
            {
                request.UserAttributes = cmdletContext.UserAttributes;
            }
            
             // populate UserContextData
            bool requestUserContextDataIsNull = true;
            request.UserContextData = new Amazon.CognitoIdentityProvider.Model.UserContextDataType();
            System.String requestUserContextData_userContextData_EncodedData = null;
            if (cmdletContext.UserContextData_EncodedData != null)
            {
                requestUserContextData_userContextData_EncodedData = cmdletContext.UserContextData_EncodedData;
            }
            if (requestUserContextData_userContextData_EncodedData != null)
            {
                request.UserContextData.EncodedData = requestUserContextData_userContextData_EncodedData;
                requestUserContextDataIsNull = false;
            }
             // determine if request.UserContextData should be set to null
            if (requestUserContextDataIsNull)
            {
                request.UserContextData = null;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
            }
            if (cmdletContext.ValidationData != null)
            {
                request.ValidationData = cmdletContext.ValidationData;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Region);
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
        
        private Amazon.CognitoIdentityProvider.Model.SignUpResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.SignUpRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "SignUp");
            try
            {
                #if DESKTOP
                return client.SignUp(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.SignUpAsync(request);
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
            public System.String ClientId { get; set; }
            public System.String Password { get; set; }
            public System.String SecretHash { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.AttributeType> UserAttributes { get; set; }
            public System.String UserContextData_EncodedData { get; set; }
            public System.String Username { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.AttributeType> ValidationData { get; set; }
        }
        
    }
}
