/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Creates a new user in the specified user pool and sends a welcome message via email
    /// or phone (SMS). This message is based on a template that you configured in your call
    /// to CreateUserPool or UpdateUserPool. This template includes your custom sign-up instructions
    /// and placeholders for user name and temporary password.
    /// 
    ///  
    /// <para>
    /// Requires developer credentials.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CGIPUserAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.UserType")]
    [AWSCmdlet("Invokes the AdminCreateUser operation against Amazon Cognito Identity Provider.", Operation = new[] {"AdminCreateUser"})]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.UserType",
        "This cmdlet returns a UserType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGIPUserAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        #region Parameter DesiredDeliveryMedium
        /// <summary>
        /// <para>
        /// <para>Specify "EMAIL" if email will be used to send the welcome message. Specify "SMS" if
        /// the phone number will be used. The default value is "SMS". More than one value can
        /// be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("DesiredDeliveryMediums")]
        public System.String[] DesiredDeliveryMedium { get; set; }
        #endregion
        
        #region Parameter ForceAliasCreation
        /// <summary>
        /// <para>
        /// <para>This parameter is only used if the phone_number_verified or email_verified attribute
        /// is set to True. Otherwise, it is ignored.</para><para>If this parameter is set to True and the phone number or email address specified in
        /// the UserAttributes parameter already exists as an alias with a different user, the
        /// API call will migrate the alias from the previous user to the newly created user.
        /// The previous user will no longer be able to log in using that alias.</para><para>If this parameter is set to False, the API throws an AliasExistsException error if
        /// the alias already exists. The default value is False.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ForceAliasCreation { get; set; }
        #endregion
        
        #region Parameter MessageAction
        /// <summary>
        /// <para>
        /// <para>Set to "RESEND" to resend the invitation message to a user that already exists and
        /// reset the expiration limit on the user's account. Set to "SUPPRESS" to suppress sending
        /// the message. Only one value can be specified.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.MessageActionType")]
        public Amazon.CognitoIdentityProvider.MessageActionType MessageAction { get; set; }
        #endregion
        
        #region Parameter TemporaryPassword
        /// <summary>
        /// <para>
        /// <para>The user's temporary password. This password must conform to the password policy that
        /// you specified when you created the user pool.</para><para>The temporary password is valid only once. To complete the Admin Create User flow,
        /// the user must enter the temporary password in the sign-in page along with a new password
        /// to be used in all future sign-ins.</para><para>This parameter is not required. If you do not specify a value, Amazon Cognito generates
        /// one for you.</para><para>The temporary password can only be used until the user account expiration limit that
        /// you specified when you created the user pool. To reset the account after that time
        /// limit, you must call AdminCreateUser again, specifying "RESEND" for the MessageAction
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TemporaryPassword { get; set; }
        #endregion
        
        #region Parameter UserAttribute
        /// <summary>
        /// <para>
        /// <para>An array of name-value pairs that contain user attributes and attribute values to
        /// be set for the user to be created. You can create a user without specifying any attributes
        /// other than Username. However, any attributes that you specify as required (in CreateUserPool
        /// or in the <b>Attributes</b> tab of the console) must be supplied either by you (in
        /// your call to AdminCreateUser) or by the user (when he or she signs up in response
        /// to your welcome message).</para><para>To send a message inviting the user to sign up, you must specify the user's email
        /// address or phone number. This can be done in your call to AdminCreateUser or in the
        /// <b>Users</b> tab of the Amazon Cognito console for managing your user pools.</para><para>In your call to AdminCreateUser, you can set the email_verified attribute to True,
        /// and you can set the phone_number_verified attribute to True. (You cannot do this by
        /// calling other operations such as AdminUpdateUserAttributes.)</para><ul><li><para><b>email</b>: The email address of the user to whom the message that contains the
        /// code and username will be sent. Required if the email_verified attribute is set to
        /// True, or if "EMAIL" is specified in the DesiredDeliveryMediums parameter.</para></li><li><para><b>phone_number</b>: The phone number of the user to whom the message that contains
        /// the code and username will be sent. Required if the phone_number_verified attribute
        /// is set to True, or if "SMS" is specified in the DesiredDeliveryMediums parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("UserAttributes")]
        public Amazon.CognitoIdentityProvider.Model.AttributeType[] UserAttribute { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The username for the user. Must be unique within the user pool. Must be a UTF-8 string
        /// between 1 and 128 characters. After the user is created, the username cannot be changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID for the user pool where the user will be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter ValidationData
        /// <summary>
        /// <para>
        /// <para>The user's validation data. This is an array of name-value pairs that contain user
        /// attributes and attribute values that you can use for custom validation, such as restricting
        /// the types of user accounts that can be registered. For example, you might choose to
        /// allow or disallow user sign-up based on the user's domain.</para><para>To configure custom validation, you must create a Pre Sign-up Lambda trigger for the
        /// user pool as described in the Amazon Cognito Developer Guide. The Lambda trigger receives
        /// the validation data and uses it in the validation process.</para><para>The user's validation data is not persisted.</para>
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserPoolId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIPUserAdmin (AdminCreateUser)"))
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
            
            if (this.DesiredDeliveryMedium != null)
            {
                context.DesiredDeliveryMediums = new List<System.String>(this.DesiredDeliveryMedium);
            }
            if (ParameterWasBound("ForceAliasCreation"))
                context.ForceAliasCreation = this.ForceAliasCreation;
            context.MessageAction = this.MessageAction;
            context.TemporaryPassword = this.TemporaryPassword;
            if (this.UserAttribute != null)
            {
                context.UserAttributes = new List<Amazon.CognitoIdentityProvider.Model.AttributeType>(this.UserAttribute);
            }
            context.Username = this.Username;
            context.UserPoolId = this.UserPoolId;
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
            var request = new Amazon.CognitoIdentityProvider.Model.AdminCreateUserRequest();
            
            if (cmdletContext.DesiredDeliveryMediums != null)
            {
                request.DesiredDeliveryMediums = cmdletContext.DesiredDeliveryMediums;
            }
            if (cmdletContext.ForceAliasCreation != null)
            {
                request.ForceAliasCreation = cmdletContext.ForceAliasCreation.Value;
            }
            if (cmdletContext.MessageAction != null)
            {
                request.MessageAction = cmdletContext.MessageAction;
            }
            if (cmdletContext.TemporaryPassword != null)
            {
                request.TemporaryPassword = cmdletContext.TemporaryPassword;
            }
            if (cmdletContext.UserAttributes != null)
            {
                request.UserAttributes = cmdletContext.UserAttributes;
            }
            if (cmdletContext.Username != null)
            {
                request.Username = cmdletContext.Username;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
            }
            if (cmdletContext.ValidationData != null)
            {
                request.ValidationData = cmdletContext.ValidationData;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.User;
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminCreateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminCreateUser");
            #if DESKTOP
            return client.AdminCreateUser(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AdminCreateUserAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> DesiredDeliveryMediums { get; set; }
            public System.Boolean? ForceAliasCreation { get; set; }
            public Amazon.CognitoIdentityProvider.MessageActionType MessageAction { get; set; }
            public System.String TemporaryPassword { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.AttributeType> UserAttributes { get; set; }
            public System.String Username { get; set; }
            public System.String UserPoolId { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.AttributeType> ValidationData { get; set; }
        }
        
    }
}
