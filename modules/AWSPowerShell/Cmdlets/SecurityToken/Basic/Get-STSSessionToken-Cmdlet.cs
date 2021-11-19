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
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// Returns a set of temporary credentials for an Amazon Web Services account or IAM user.
    /// The credentials consist of an access key ID, a secret access key, and a security token.
    /// Typically, you use <code>GetSessionToken</code> if you want to use MFA to protect
    /// programmatic calls to specific Amazon Web Services API operations like Amazon EC2
    /// <code>StopInstances</code>. MFA-enabled IAM users would need to call <code>GetSessionToken</code>
    /// and submit an MFA code that is associated with their MFA device. Using the temporary
    /// security credentials that are returned from the call, IAM users can then make programmatic
    /// calls to API operations that require MFA authentication. If you do not supply a correct
    /// MFA code, then the API returns an access denied error. For a comparison of <code>GetSessionToken</code>
    /// with the other API operations that produce temporary credentials, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html">Requesting
    /// Temporary Security Credentials</a> and <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#stsapi_comparison">Comparing
    /// the Amazon Web Services STS API operations</a> in the <i>IAM User Guide</i>.
    /// 
    ///  
    /// <para><b>Session Duration</b></para><para>
    /// The <code>GetSessionToken</code> operation must be called by using the long-term Amazon
    /// Web Services security credentials of the Amazon Web Services account root user or
    /// an IAM user. Credentials that are created by IAM users are valid for the duration
    /// that you specify. This duration can range from 900 seconds (15 minutes) up to a maximum
    /// of 129,600 seconds (36 hours), with a default of 43,200 seconds (12 hours). Credentials
    /// based on account credentials can range from 900 seconds (15 minutes) up to 3,600 seconds
    /// (1 hour), with a default of 1 hour. 
    /// </para><para><b>Permissions</b></para><para>
    /// The temporary security credentials created by <code>GetSessionToken</code> can be
    /// used to make API calls to any Amazon Web Services service with the following exceptions:
    /// </para><ul><li><para>
    /// You cannot call any IAM API operations unless MFA authentication information is included
    /// in the request.
    /// </para></li><li><para>
    /// You cannot call any STS API <i>except</i><code>AssumeRole</code> or <code>GetCallerIdentity</code>.
    /// </para></li></ul><note><para>
    /// We recommend that you do not call <code>GetSessionToken</code> with Amazon Web Services
    /// account root user credentials. Instead, follow our <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/best-practices.html#create-iam-users">best
    /// practices</a> by creating one or more IAM users, giving them the necessary permissions,
    /// and using IAM users for everyday interaction with Amazon Web Services. 
    /// </para></note><para>
    /// The credentials that are returned by <code>GetSessionToken</code> are based on permissions
    /// associated with the user whose credentials were used to call the operation. If <code>GetSessionToken</code>
    /// is called using Amazon Web Services account root user credentials, the temporary credentials
    /// have root user permissions. Similarly, if <code>GetSessionToken</code> is called using
    /// the credentials of an IAM user, the temporary credentials have the same permissions
    /// as the IAM user. 
    /// </para><para>
    /// For more information about using <code>GetSessionToken</code> to create temporary
    /// credentials, go to <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#api_getsessiontoken">Temporary
    /// Credentials for Users in Untrusted Environments</a> in the <i>IAM User Guide</i>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "STSSessionToken")]
    [OutputType("Amazon.SecurityToken.Model.Credentials")]
    [AWSCmdlet("Calls the AWS Security Token Service (STS) GetSessionToken API operation.", Operation = new[] {"GetSessionToken"}, SelectReturnType = typeof(Amazon.SecurityToken.Model.GetSessionTokenResponse))]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.Credentials or Amazon.SecurityToken.Model.GetSessionTokenResponse",
        "This cmdlet returns an Amazon.SecurityToken.Model.Credentials object.",
        "The service call response (type Amazon.SecurityToken.Model.GetSessionTokenResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSTSSessionTokenCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, that the credentials should remain valid. Acceptable durations
        /// for IAM user sessions range from 900 seconds (15 minutes) to 129,600 seconds (36 hours),
        /// with 43,200 seconds (12 hours) as the default. Sessions for Amazon Web Services account
        /// owners are restricted to a maximum of 3,600 seconds (one hour). If the duration is
        /// longer than one hour, the session for Amazon Web Services account owners defaults
        /// to one hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("DurationSeconds")]
        public System.Int32? DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter SerialNumber
        /// <summary>
        /// <para>
        /// <para>The identification number of the MFA device that is associated with the IAM user who
        /// is making the <code>GetSessionToken</code> call. Specify this value if the IAM user
        /// has a policy that requires MFA authentication. The value is either the serial number
        /// for a hardware device (such as <code>GAHT12345678</code>) or an Amazon Resource Name
        /// (ARN) for a virtual device (such as <code>arn:aws:iam::123456789012:mfa/user</code>).
        /// You can find the device for an IAM user by going to the Amazon Web Services Management
        /// Console and viewing the user's security credentials. </para><para>The regex used to validate this parameter is a string of characters consisting of
        /// upper- and lower-case alphanumeric characters with no spaces. You can also include
        /// underscores or any of the following characters: =,.@:/-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String SerialNumber { get; set; }
        #endregion
        
        #region Parameter TokenCode
        /// <summary>
        /// <para>
        /// <para>The value provided by the MFA device, if MFA is required. If any policy requires the
        /// IAM user to submit an MFA code, specify this value. If MFA authentication is required,
        /// the user must provide a code when requesting a set of temporary security credentials.
        /// A user who fails to provide the code receives an "access denied" response when requesting
        /// resources that require MFA authentication.</para><para>The format for this parameter, as described by its regex pattern, is a sequence of
        /// six numeric digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String TokenCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Credentials'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityToken.Model.GetSessionTokenResponse).
        /// Specifying the name of a property of type Amazon.SecurityToken.Model.GetSessionTokenResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Credentials";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DurationInSeconds parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DurationInSeconds' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DurationInSeconds' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityToken.Model.GetSessionTokenResponse, GetSTSSessionTokenCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DurationInSeconds;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DurationInSeconds = this.DurationInSeconds;
            context.SerialNumber = this.SerialNumber;
            context.TokenCode = this.TokenCode;
            
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
            var request = new Amazon.SecurityToken.Model.GetSessionTokenRequest();
            
            if (cmdletContext.DurationInSeconds != null)
            {
                request.DurationSeconds = cmdletContext.DurationInSeconds.Value;
            }
            if (cmdletContext.SerialNumber != null)
            {
                request.SerialNumber = cmdletContext.SerialNumber;
            }
            if (cmdletContext.TokenCode != null)
            {
                request.TokenCode = cmdletContext.TokenCode;
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
        
        private Amazon.SecurityToken.Model.GetSessionTokenResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.GetSessionTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service (STS)", "GetSessionToken");
            try
            {
                #if DESKTOP
                return client.GetSessionToken(request);
                #elif CORECLR
                return client.GetSessionTokenAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? DurationInSeconds { get; set; }
            public System.String SerialNumber { get; set; }
            public System.String TokenCode { get; set; }
            public System.Func<Amazon.SecurityToken.Model.GetSessionTokenResponse, GetSTSSessionTokenCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Credentials;
        }
        
    }
}
