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
    /// Disables the user from signing in with the specified external (SAML or social) identity
    /// provider. If the user to disable is a Cognito User Pools native username + password
    /// user, they are not permitted to use their password to sign-in. If the user to disable
    /// is a linked external IdP user, any link between that user and an existing user is
    /// removed. The next time the external user (no longer attached to the previously linked
    /// <code>DestinationUser</code>) signs in, they must create a new user account. See .
    /// 
    ///  
    /// <para>
    /// This action is enabled only for admin access and requires developer credentials.
    /// </para><para>
    /// The <code>ProviderName</code> must match the value specified when creating an IdP
    /// for the pool. 
    /// </para><para>
    /// To disable a native username + password user, the <code>ProviderName</code> value
    /// must be <code>Cognito</code> and the <code>ProviderAttributeName</code> must be <code>Cognito_Subject</code>,
    /// with the <code>ProviderAttributeValue</code> being the name that is used in the user
    /// pool for the user.
    /// </para><para>
    /// The <code>ProviderAttributeName</code> must always be <code>Cognito_Subject</code>
    /// for social identity providers. The <code>ProviderAttributeValue</code> must always
    /// be the exact subject that was used when the user was originally linked as a source
    /// user.
    /// </para><para>
    /// For de-linking a SAML identity, there are two scenarios. If the linked identity has
    /// not yet been used to sign-in, the <code>ProviderAttributeName</code> and <code>ProviderAttributeValue</code>
    /// must be the same values that were used for the <code>SourceUser</code> when the identities
    /// were originally linked in the call. (If the linking was done with <code>ProviderAttributeName</code>
    /// set to <code>Cognito_Subject</code>, the same applies here). However, if the user
    /// has already signed in, the <code>ProviderAttributeName</code> must be <code>Cognito_Subject</code>
    /// and <code>ProviderAttributeValue</code> must be the subject of the SAML assertion.
    /// </para>
    /// </summary>
    [Cmdlet("Disable", "CGIPProviderForUserAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminDisableProviderForUser API operation.", Operation = new[] {"AdminDisableProviderForUser"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the UserPoolId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class DisableCGIPProviderForUserAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter User_ProviderAttributeName
        /// <summary>
        /// <para>
        /// <para>The name of the provider attribute to link to, for example, <code>NameID</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String User_ProviderAttributeName { get; set; }
        #endregion
        
        #region Parameter User_ProviderAttributeValue
        /// <summary>
        /// <para>
        /// <para>The value of the provider attribute to link to, for example, <code>xxxxx_account</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String User_ProviderAttributeValue { get; set; }
        #endregion
        
        #region Parameter User_ProviderName
        /// <summary>
        /// <para>
        /// <para>The name of the provider, for example, Facebook, Google, or Login with Amazon.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String User_ProviderName { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID for the user pool.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the UserPoolId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserPoolId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Disable-CGIPProviderForUserAdmin (AdminDisableProviderForUser)"))
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
            
            context.User_ProviderAttributeName = this.User_ProviderAttributeName;
            context.User_ProviderAttributeValue = this.User_ProviderAttributeValue;
            context.User_ProviderName = this.User_ProviderName;
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserRequest();
            
            
             // populate User
            bool requestUserIsNull = true;
            request.User = new Amazon.CognitoIdentityProvider.Model.ProviderUserIdentifierType();
            System.String requestUser_user_ProviderAttributeName = null;
            if (cmdletContext.User_ProviderAttributeName != null)
            {
                requestUser_user_ProviderAttributeName = cmdletContext.User_ProviderAttributeName;
            }
            if (requestUser_user_ProviderAttributeName != null)
            {
                request.User.ProviderAttributeName = requestUser_user_ProviderAttributeName;
                requestUserIsNull = false;
            }
            System.String requestUser_user_ProviderAttributeValue = null;
            if (cmdletContext.User_ProviderAttributeValue != null)
            {
                requestUser_user_ProviderAttributeValue = cmdletContext.User_ProviderAttributeValue;
            }
            if (requestUser_user_ProviderAttributeValue != null)
            {
                request.User.ProviderAttributeValue = requestUser_user_ProviderAttributeValue;
                requestUserIsNull = false;
            }
            System.String requestUser_user_ProviderName = null;
            if (cmdletContext.User_ProviderName != null)
            {
                requestUser_user_ProviderName = cmdletContext.User_ProviderName;
            }
            if (requestUser_user_ProviderName != null)
            {
                request.User.ProviderName = requestUser_user_ProviderName;
                requestUserIsNull = false;
            }
             // determine if request.User should be set to null
            if (requestUserIsNull)
            {
                request.User = null;
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
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.UserPoolId;
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminDisableProviderForUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminDisableProviderForUser");
            try
            {
                #if DESKTOP
                return client.AdminDisableProviderForUser(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AdminDisableProviderForUserAsync(request);
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
            public System.String User_ProviderAttributeName { get; set; }
            public System.String User_ProviderAttributeValue { get; set; }
            public System.String User_ProviderName { get; set; }
            public System.String UserPoolId { get; set; }
        }
        
    }
}
