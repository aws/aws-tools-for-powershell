using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.CredentialManagement;

namespace Amazon.PowerShell.Common
{
    internal class AWSCredentialsArgumentsFull : IAWSCredentialsArgumentsFull
    {
        public const string BasicOrSessionSet = "BasicOrSession";
        public const string AssumeRoleSet = "AssumeRole";
        public const string AWSCredentialsObjectSet = "AWSCredentialsObject";
        public const string StoredProfileSet = "StoredProfile";
        //public const string FederatedSet = "Federated";

        public SessionState SessionState { get; private set; }

        #region Parameter AccessKey
        /// <summary>
        /// The AWS access key for the user account. This can be a temporary access key
        /// if the corresponding session token is supplied to the -SessionToken parameter.
        /// </summary>
        [Alias("AK")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = BasicOrSessionSet)]
        public string AccessKey { get; set; }
        #endregion

        #region Parameter SecretKey
        /// <summary>
        /// The AWS secret key for the user account. This can be a temporary secret key
        /// if the corresponding session token is supplied to the -SessionToken parameter.
        /// </summary>
        [Alias("SK", "SecretAccessKey")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = BasicOrSessionSet)]
        public string SecretKey { get; set; }
        #endregion

        #region Parameter SessionToken
        /// <summary>
        /// The session token if the access and secret keys are temporary session-based credentials.
        /// </summary>
        [Alias("ST")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = BasicOrSessionSet)]
        public string SessionToken { get; set; }
        #endregion

        #region Parameter ExternalId
        /// <summary>
        /// The user-defined external ID to be used when assuming a role, if required by the role.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AssumeRoleSet)]
        public string ExternalID { get; set; }
        #endregion endregion

        #region Parameter MfaSerial
        /// <summary>
        /// The MFA serial number to be used when assuming a role, if required by the role.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = AssumeRoleSet)]
        public string MfaSerial { get; set; }
        #endregion

//#if DESKTOP
//        #region Parameter RoleArn
//        /// <summary>
//        /// The ARN of the role to assume.
//        /// This parameter applies to assume role credentials and federated credentials.
//        /// </summary>
//        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AssumeRoleSet)]
//        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = FederatedSet)]
//        public string RoleArn { get; set; }
//        #endregion
//#else
        #region Parameter RoleArn
        /// <summary>
        /// The ARN of the role to assume for assume role credentials.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AssumeRoleSet)]
        public string RoleArn { get; set; }
        #endregion
//#endif

        #region Parameter SourceProfile
        /// <summary>
        /// The name of the source profile to be used by assume role credentials.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = AssumeRoleSet)]
        public string SourceProfile { get; set; }
        #endregion

//#if DESKTOP
//        #region Parameter EndpointName
//        /// <summary>
//        /// The name of the endpoint to be used for federated credentials.
//        /// See the Set-AWSSamlEndpoint cmdlet for more information about registering endpoints.
//        /// </summary>
//        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = FederatedSet)]
//        public string EndpointName { get; set; }
//        #endregion

//        #region Parameter UserIdentity
//        /// <summary>
//        /// The user to be used by federated credentials.  If this optional parameter is omitted, the currently logged-on user will be used.
//        /// </summary>
//        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = FederatedSet)]
//        public string UserIdentity { get; set; }
//        #endregion

//#endif

        #region Parameter ProfileName
        /// <summary>
        /// The user-defined name of an AWS credentials or SAML-based role profile containing
        /// credential information. The profile is expected to be found in the secure credential
        /// file shared with the AWS SDK for .NET and AWS Toolkit for Visual Studio. You can also
        /// specify the name of a profile stored in the .ini-format credential file used with
        /// the AWS CLI and other AWS SDKs.
        /// </summary>
        [Alias("StoredCredentials", "AWSProfileName")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, ParameterSetName = StoredProfileSet, Position = 200)]
        public string ProfileName { get; set; }
        #endregion

        #region Parameter ProfileLocation
        /// <summary>
        /// <para>
        /// Used to specify the name and location of the ini-format credential file (shared with
        /// the AWS CLI and other AWS SDKs)
        /// </para>
        /// <para>
        /// If this optional parameter is omitted this cmdlet will search the encrypted credential
        /// file used by the AWS SDK for .NET and AWS Toolkit for Visual Studio first.
        /// If the profile is not found then the cmdlet will search in the ini-format credential
        /// file at the default location: (user's home directory)\.aws\credentials.
        /// </para>
        /// <para>
        /// If this parameter is specified then this cmdlet will only search the ini-format credential
        /// file at the location given.
        /// </para>
        /// <para>
        /// As the current folder can vary in a shell or during script execution it is advised
        /// that you use specify a fully qualified path instead of a relative path.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Note that the encrypted credential file is not supported on all platforms.
        /// It will be skipped when searching for profiles on Windows Nano Server, Mac, and Linux platforms.
        /// </remarks>
        [Alias("AWSProfilesLocation", "ProfilesLocation")]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = BasicOrSessionSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = AssumeRoleSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = AWSCredentialsObjectSet)]
        //[Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = FederatedSet)]
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, Position = 201, ParameterSetName = StoredProfileSet)]
        public virtual string ProfileLocation { get; set; }
        #endregion

        #region Parameter Credential
        /// <summary>
        /// An AWSCredentials object instance containing access and secret key information,
        /// and optionally a token for session-based credentials.
        /// </summary>
        [Parameter(ValueFromPipeline = true, Mandatory = true, ParameterSetName = AWSCredentialsObjectSet)]
        public AWSCredentials Credential { get; set; }
        #endregion

        #region Parameter NetworkCredential
        /// <summary>
        /// Used with SAML-based authentication when ProfileName references a SAML role profile.
        /// Contains the network credentials to be supplied during authentication with the
        /// configured identity provider's endpoint. This parameter is not required if the
        /// user's default network identity can or should be used during authentication.
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = StoredProfileSet)]
        //[Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false, ParameterSetName = FederatedSet)]
        public PSCredential NetworkCredential { get; set; }
        #endregion

        public AWSCredentialsArgumentsFull(SessionState sessionState)
        {
            SessionState = sessionState;
        }

        public CredentialProfileOptions GetCredentialProfileOptions()
        {
            return new CredentialProfileOptions
            {
                AccessKey = AccessKey,
                SecretKey = SecretKey,
                Token = SessionToken,
                ExternalID = ExternalID,
                MfaSerial = MfaSerial,
                RoleArn = RoleArn,
                SourceProfile = SourceProfile,
//#if DESKTOP
//                EndpointName = EndpointName,
//                UserIdentity = UserIdentity,
//#endif
            };
        }
    }
}
