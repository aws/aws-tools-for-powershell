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
        public SessionState SessionState { get; private set; }

        /// <summary>
        /// The AWS access key for the user account. This can be a temporary access key
        /// if the corresponding session token is supplied to the -SessionToken parameter.
        /// Temporary session credentials can be set for the current shell instance only
        /// and cannot be saved to the credential store file.
        /// </summary>
        [Alias("AK")]
        [Parameter(Mandatory = true, ParameterSetName = "Basic")]
        [Parameter(Mandatory = true, ParameterSetName = "Session")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string AccessKey { get; set; }

        /// <summary>
        /// The AWS secret key for the user account. This can be a temporary secret key
        /// if the corresponding session token is supplied to the -SessionToken parameter.
        /// Temporary session credentials can be set for the current shell instance only
        /// and cannot be saved to the credential store file.
        /// </summary>
        [Alias("SK", "SecretAccessKey")]
        [Parameter(Mandatory = true, ParameterSetName = "Basic")]
        [Parameter(Mandatory = true, ParameterSetName = "Session")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SecretKey { get; set; }

        /// <summary>
        /// The session token if the access and secret keys are temporary session-based
        /// credentials. Temporary session credentials can be set for the current shell 
        /// instance only and cannot be saved to the credential store file.
        /// </summary>
        [Alias("ST")]
        [Parameter(Mandatory = true, ParameterSetName = "Session")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SessionToken { get; set; }

        [Alias("EI")]
        [Parameter(Mandatory = false, ParameterSetName = "AssumeRole")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string ExternalID { get; set; }

        [Alias("MS")]
        [Parameter(Mandatory = false, ParameterSetName = "AssumeRole")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string MfaSerial { get; set; }

        [Alias("RA")]
        [Parameter(Mandatory = true, ParameterSetName = "AssumeRole")]
#if DESKTOP
        [Parameter(Mandatory = true, ParameterSetName = "SAML")]
#endif
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string RoleArn { get; set; }

        [Alias("SP")]
        [Parameter(Mandatory = true, ParameterSetName = "AssumeRole")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string SourceProfile { get; set; }

#if DESKTOP
        [Alias("EN")]
        [Parameter(Mandatory = true, ParameterSetName = "SAML")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string EndpointName { get; set; }

        [Alias("UI")]
        [Parameter(Mandatory = false, ParameterSetName = "SAML")]
        [Parameter(ValueFromPipelineByPropertyName = true)]
        public string UserIdentity { get; set; }
#endif
        /// <summary>
        /// The user-defined name of an AWS credentials or SAML-based role profile containing
        /// credential information. The profile is expected to be found in the secure credential
        /// file shared with the AWS SDK for .NET and AWS Toolkit for Visual Studio. You can also
        /// specify the name of a profile stored in the .ini-format credential file used with 
        /// the AWS CLI and other AWS SDKs.
        /// </summary>
        [Parameter(Mandatory=true, ParameterSetName="StoredProfile")]
        [Alias("StoredCredentials", "AWSProfileName")]
        public string ProfileName { get; set; }

        /// <summary>
        /// An AWSCredentials object instance containing access and secret key information,
        /// and optionally a token for session-based credentials.
        /// </summary>
        [Parameter(ValueFromPipeline = true)]
        public AWSCredentials Credential { get; set; }

        /// <summary>
        /// Used with SAML-based authentication when ProfileName references a SAML role profile. 
        /// Contains the network credentials to be supplied during authentication with the 
        /// configured identity provider's endpoint. This parameter is not required if the
        /// user's default network identity can or should be used during authentication.
        /// </summary>
        [Parameter(ValueFromPipeline = true)]
        public PSCredential NetworkCredential { get; set; }

        /// <summary>
        /// <para>
        /// Used to specify the name and location of the ini-format credential file (shared with 
        /// the AWS CLI and other AWS SDKs) when the file does not use the default name and/or 
        /// folder location.
        /// </para>
        /// <para>
        /// When the ini-format credential file uses the default filename ('credentials') and is 
        /// placed in the default search location ('.aws' folder in the current user's profile folder, 
        /// 'C:\Users\userid') this parameter is not required. This parameter is also not required 
        /// when the profile to be used is contained in the encrypted credential file shared with the 
        /// AWS SDK for .NET and AWS Toolkit for Visual Studio.
        /// </para>
        /// <para>
        /// As the current folder can vary in a shell or during script execution it is advised 
        /// that you use specify a fully qualified path instead of a relative path.
        /// </para>
        /// </summary>
        [Parameter]
        [Alias("AWSProfilesLocation", "ProfileLocation")]
        public string ProfilesLocation { get; set; }

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
#if DESKTOP
                EndpointName = EndpointName,
                UserIdentity = UserIdentity,
#endif
            };
        }
    }

    internal class AWSCommonArgumentsFull : AWSCredentialsArgumentsFull, IAWSCommonArgumentsFull
    {
        /// <summary>
        /// The system name of an AWS region or an AWSRegion instance. This governs
        /// the sendpoint that will be used when calling service operations. Note that 
        /// the AWS resources referenced in a call are usually region-specific.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public object Region { get; set; }

        public AWSCommonArgumentsFull(SessionState sessionState) : base(sessionState)
        {
        }
    }
}
