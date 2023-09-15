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
    /// Creates a new user in the specified user pool.
    /// 
    ///  
    /// <para>
    /// If <code>MessageAction</code> isn't set, the default is to send a welcome message
    /// via email or phone (SMS).
    /// </para><note><para>
    /// This action might generate an SMS text message. Starting June 1, 2021, US telecom
    /// carriers require you to register an origination phone number before you can send SMS
    /// messages to US phone numbers. If you use SMS text messages in Amazon Cognito, you
    /// must register a phone number with <a href="https://console.aws.amazon.com/pinpoint/home/">Amazon
    /// Pinpoint</a>. Amazon Cognito uses the registered number automatically. Otherwise,
    /// Amazon Cognito users who must receive SMS messages might not be able to sign up, activate
    /// their accounts, or sign in.
    /// </para><para>
    /// If you have never used SMS text messages with Amazon Cognito or any other Amazon Web
    /// Service, Amazon Simple Notification Service might place your account in the SMS sandbox.
    /// In <i><a href="https://docs.aws.amazon.com/sns/latest/dg/sns-sms-sandbox.html">sandbox
    /// mode</a></i>, you can send messages only to verified phone numbers. After you test
    /// your app while in the sandbox environment, you can move out of the sandbox and into
    /// production. For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pool-sms-settings.html">
    /// SMS message settings for Amazon Cognito user pools</a> in the <i>Amazon Cognito Developer
    /// Guide</i>.
    /// </para></note><para>
    /// This message is based on a template that you configured in your call to create or
    /// update a user pool. This template includes your custom sign-up instructions and placeholders
    /// for user name and temporary password.
    /// </para><para>
    /// Alternatively, you can call <code>AdminCreateUser</code> with <code>SUPPRESS</code>
    /// for the <code>MessageAction</code> parameter, and Amazon Cognito won't send any email.
    /// 
    /// </para><para>
    /// In either case, the user will be in the <code>FORCE_CHANGE_PASSWORD</code> state until
    /// they sign in and change their password.
    /// </para><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("New", "CGIPUserAdmin", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.UserType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider AdminCreateUser API operation.", Operation = new[] {"AdminCreateUser"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.UserType or Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.UserType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCGIPUserAdminCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        #region Parameter ClientMetadata
        /// <summary>
        /// <para>
        /// <para>A map of custom key-value pairs that you can provide as input for any custom workflows
        /// that this action triggers.</para><para>You create custom workflows by assigning Lambda functions to user pool triggers. When
        /// you use the AdminCreateUser API action, Amazon Cognito invokes the function that is
        /// assigned to the <i>pre sign-up</i> trigger. When Amazon Cognito invokes this function,
        /// it passes a JSON payload, which the function receives as input. This payload contains
        /// a <code>clientMetadata</code> attribute, which provides the data that you assigned
        /// to the ClientMetadata parameter in your AdminCreateUser request. In your function
        /// code in Lambda, you can process the <code>clientMetadata</code> value to enhance your
        /// workflow for your specific needs.</para><para>For more information, see <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-user-identity-pools-working-with-aws-lambda-triggers.html">
        /// Customizing user pool Workflows with Lambda Triggers</a> in the <i>Amazon Cognito
        /// Developer Guide</i>.</para><note><para>When you use the ClientMetadata parameter, remember that Amazon Cognito won't do the
        /// following:</para><ul><li><para>Store the ClientMetadata value. This data is available only to Lambda triggers that
        /// are assigned to a user pool to support custom workflows. If your user pool configuration
        /// doesn't include triggers, the ClientMetadata parameter serves no purpose.</para></li><li><para>Validate the ClientMetadata value.</para></li><li><para>Encrypt the ClientMetadata value. Don't use Amazon Cognito to provide sensitive information.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable ClientMetadata { get; set; }
        #endregion
        
        #region Parameter DesiredDeliveryMedium
        /// <summary>
        /// <para>
        /// <para>Specify <code>"EMAIL"</code> if email will be used to send the welcome message. Specify
        /// <code>"SMS"</code> if the phone number will be used. The default value is <code>"SMS"</code>.
        /// You can specify more than one value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DesiredDeliveryMediums")]
        public System.String[] DesiredDeliveryMedium { get; set; }
        #endregion
        
        #region Parameter ForceAliasCreation
        /// <summary>
        /// <para>
        /// <para>This parameter is used only if the <code>phone_number_verified</code> or <code>email_verified</code>
        /// attribute is set to <code>True</code>. Otherwise, it is ignored.</para><para>If this parameter is set to <code>True</code> and the phone number or email address
        /// specified in the UserAttributes parameter already exists as an alias with a different
        /// user, the API call will migrate the alias from the previous user to the newly created
        /// user. The previous user will no longer be able to log in using that alias.</para><para>If this parameter is set to <code>False</code>, the API throws an <code>AliasExistsException</code>
        /// error if the alias already exists. The default value is <code>False</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceAliasCreation { get; set; }
        #endregion
        
        #region Parameter MessageAction
        /// <summary>
        /// <para>
        /// <para>Set to <code>RESEND</code> to resend the invitation message to a user that already
        /// exists and reset the expiration limit on the user's account. Set to <code>SUPPRESS</code>
        /// to suppress sending the message. You can specify only one value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CognitoIdentityProvider.MessageActionType")]
        public Amazon.CognitoIdentityProvider.MessageActionType MessageAction { get; set; }
        #endregion
        
        #region Parameter TemporaryPassword
        /// <summary>
        /// <para>
        /// <para>The user's temporary password. This password must conform to the password policy that
        /// you specified when you created the user pool.</para><para>The temporary password is valid only once. To complete the Admin Create User flow,
        /// the user must enter the temporary password in the sign-in page, along with a new password
        /// to be used in all future sign-ins.</para><para>This parameter isn't required. If you don't specify a value, Amazon Cognito generates
        /// one for you.</para><para>The temporary password can only be used until the user account expiration limit that
        /// you set for your user pool. To reset the account after that time limit, you must call
        /// <code>AdminCreateUser</code> again and specify <code>RESEND</code> for the <code>MessageAction</code>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TemporaryPassword { get; set; }
        #endregion
        
        #region Parameter UserAttribute
        /// <summary>
        /// <para>
        /// <para>An array of name-value pairs that contain user attributes and attribute values to
        /// be set for the user to be created. You can create a user without specifying any attributes
        /// other than <code>Username</code>. However, any attributes that you specify as required
        /// (when creating a user pool or in the <b>Attributes</b> tab of the console) either
        /// you should supply (in your call to <code>AdminCreateUser</code>) or the user should
        /// supply (when they sign up in response to your welcome message).</para><para>For custom attributes, you must prepend the <code>custom:</code> prefix to the attribute
        /// name.</para><para>To send a message inviting the user to sign up, you must specify the user's email
        /// address or phone number. You can do this in your call to AdminCreateUser or in the
        /// <b>Users</b> tab of the Amazon Cognito console for managing your user pools.</para><para>In your call to <code>AdminCreateUser</code>, you can set the <code>email_verified</code>
        /// attribute to <code>True</code>, and you can set the <code>phone_number_verified</code>
        /// attribute to <code>True</code>. You can also do this by calling <a href="https://docs.aws.amazon.com/cognito-user-identity-pools/latest/APIReference/API_AdminUpdateUserAttributes.html">AdminUpdateUserAttributes</a>.</para><ul><li><para><b>email</b>: The email address of the user to whom the message that contains the
        /// code and username will be sent. Required if the <code>email_verified</code> attribute
        /// is set to <code>True</code>, or if <code>"EMAIL"</code> is specified in the <code>DesiredDeliveryMediums</code>
        /// parameter.</para></li><li><para><b>phone_number</b>: The phone number of the user to whom the message that contains
        /// the code and username will be sent. Required if the <code>phone_number_verified</code>
        /// attribute is set to <code>True</code>, or if <code>"SMS"</code> is specified in the
        /// <code>DesiredDeliveryMediums</code> parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("UserAttributes")]
        public Amazon.CognitoIdentityProvider.Model.AttributeType[] UserAttribute { get; set; }
        #endregion
        
        #region Parameter Username
        /// <summary>
        /// <para>
        /// <para>The username for the user. Must be unique within the user pool. Must be a UTF-8 string
        /// between 1 and 128 characters. After the user is created, the username can't be changed.</para>
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
        public System.String Username { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The user pool ID for the user pool where the user will be created.</para>
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
        /// the validation data and uses it in the validation process.</para><para>The user's validation data isn't persisted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CognitoIdentityProvider.Model.AttributeType[] ValidationData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'User'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "User";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the UserPoolId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^UserPoolId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CGIPUserAdmin (AdminCreateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse, NewCGIPUserAdminCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.UserPoolId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ClientMetadata != null)
            {
                context.ClientMetadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.ClientMetadata.Keys)
                {
                    context.ClientMetadata.Add((String)hashKey, (String)(this.ClientMetadata[hashKey]));
                }
            }
            if (this.DesiredDeliveryMedium != null)
            {
                context.DesiredDeliveryMedium = new List<System.String>(this.DesiredDeliveryMedium);
            }
            context.ForceAliasCreation = this.ForceAliasCreation;
            context.MessageAction = this.MessageAction;
            context.TemporaryPassword = this.TemporaryPassword;
            if (this.UserAttribute != null)
            {
                context.UserAttribute = new List<Amazon.CognitoIdentityProvider.Model.AttributeType>(this.UserAttribute);
            }
            context.Username = this.Username;
            #if MODULAR
            if (this.Username == null && ParameterWasBound(nameof(this.Username)))
            {
                WriteWarning("You are passing $null as a value for parameter Username which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            
            if (cmdletContext.ClientMetadata != null)
            {
                request.ClientMetadata = cmdletContext.ClientMetadata;
            }
            if (cmdletContext.DesiredDeliveryMedium != null)
            {
                request.DesiredDeliveryMediums = cmdletContext.DesiredDeliveryMedium;
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
            if (cmdletContext.UserAttribute != null)
            {
                request.UserAttributes = cmdletContext.UserAttribute;
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
        
        private Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.AdminCreateUserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "AdminCreateUser");
            try
            {
                #if DESKTOP
                return client.AdminCreateUser(request);
                #elif CORECLR
                return client.AdminCreateUserAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> ClientMetadata { get; set; }
            public List<System.String> DesiredDeliveryMedium { get; set; }
            public System.Boolean? ForceAliasCreation { get; set; }
            public Amazon.CognitoIdentityProvider.MessageActionType MessageAction { get; set; }
            public System.String TemporaryPassword { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.AttributeType> UserAttribute { get; set; }
            public System.String Username { get; set; }
            public System.String UserPoolId { get; set; }
            public List<Amazon.CognitoIdentityProvider.Model.AttributeType> ValidationData { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.AdminCreateUserResponse, NewCGIPUserAdminCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.User;
        }
        
    }
}
