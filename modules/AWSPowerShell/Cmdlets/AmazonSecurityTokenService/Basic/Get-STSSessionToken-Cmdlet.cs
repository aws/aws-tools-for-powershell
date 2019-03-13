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
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Amazon.PowerShell.Cmdlets.STS
{
    /// <summary>
    /// Returns a set of temporary credentials for an AWS account or IAM user. The credentials
    /// consist of an access key ID, a secret access key, and a security token. Typically,
    /// you use <code>GetSessionToken</code> if you want to use MFA to protect programmatic
    /// calls to specific AWS APIs like Amazon EC2 <code>StopInstances</code>. MFA-enabled
    /// IAM users would need to call <code>GetSessionToken</code> and submit an MFA code that
    /// is associated with their MFA device. Using the temporary security credentials that
    /// are returned from the call, IAM users can then make programmatic calls to APIs that
    /// require MFA authentication. If you do not supply a correct MFA code, then the API
    /// returns an access denied error. For a comparison of <code>GetSessionToken</code> with
    /// the other APIs that produce temporary credentials, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html">Requesting
    /// Temporary Security Credentials</a> and <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#stsapi_comparison">Comparing
    /// the AWS STS APIs</a> in the <i>IAM User Guide</i>.
    /// 
    ///  
    /// <para>
    /// The <code>GetSessionToken</code> action must be called by using the long-term AWS
    /// security credentials of the AWS account or an IAM user. Credentials that are created
    /// by IAM users are valid for the duration that you specify, from 900 seconds (15 minutes)
    /// up to a maximum of 129600 seconds (36 hours), with a default of 43200 seconds (12
    /// hours); credentials that are created by using account credentials can range from 900
    /// seconds (15 minutes) up to a maximum of 3600 seconds (1 hour), with a default of 1
    /// hour. 
    /// </para><para>
    /// The temporary security credentials created by <code>GetSessionToken</code> can be
    /// used to make API calls to any AWS service with the following exceptions:
    /// </para><ul><li><para>
    /// You cannot call any IAM APIs unless MFA authentication information is included in
    /// the request.
    /// </para></li><li><para>
    /// You cannot call any STS API <i>except</i><code>AssumeRole</code> or <code>GetCallerIdentity</code>.
    /// </para></li></ul><note><para>
    /// We recommend that you do not call <code>GetSessionToken</code> with root account credentials.
    /// Instead, follow our <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/best-practices.html#create-iam-users">best
    /// practices</a> by creating one or more IAM users, giving them the necessary permissions,
    /// and using IAM users for everyday interaction with AWS. 
    /// </para></note><para>
    /// The permissions associated with the temporary security credentials returned by <code>GetSessionToken</code>
    /// are based on the permissions associated with account or IAM user whose credentials
    /// are used to call the action. If <code>GetSessionToken</code> is called using root
    /// account credentials, the temporary credentials have root account permissions. Similarly,
    /// if <code>GetSessionToken</code> is called using the credentials of an IAM user, the
    /// temporary credentials have the same permissions as the IAM user. 
    /// </para><para>
    /// For more information about using <code>GetSessionToken</code> to create temporary
    /// credentials, go to <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_request.html#api_getsessiontoken">Temporary
    /// Credentials for Users in Untrusted Environments</a> in the <i>IAM User Guide</i>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("Get", "STSSessionToken")]
    [OutputType("Amazon.SecurityToken.Model.Credentials")]
    [AWSCmdlet("Calls the AWS Security Token Service GetSessionToken API operation.", Operation = new[] {"GetSessionToken"})]
    [AWSCmdletOutput("Amazon.SecurityToken.Model.Credentials",
        "This cmdlet returns a Credentials object.",
        "The service call response (type Amazon.SecurityToken.Model.GetSessionTokenResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSTSSessionTokenCmdlet : AmazonSecurityTokenServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DurationInSeconds
        /// <summary>
        /// <para>
        /// <para>The duration, in seconds, that the credentials should remain valid. Acceptable durations
        /// for IAM user sessions range from 900 seconds (15 minutes) to 129600 seconds (36 hours),
        /// with 43200 seconds (12 hours) as the default. Sessions for AWS account owners are
        /// restricted to a maximum of 3600 seconds (one hour). If the duration is longer than
        /// one hour, the session for AWS account owners defaults to one hour.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        [Alias("DurationSeconds")]
        public System.Int32 DurationInSeconds { get; set; }
        #endregion
        
        #region Parameter SerialNumber
        /// <summary>
        /// <para>
        /// <para>The identification number of the MFA device that is associated with the IAM user who
        /// is making the <code>GetSessionToken</code> call. Specify this value if the IAM user
        /// has a policy that requires MFA authentication. The value is either the serial number
        /// for a hardware device (such as <code>GAHT12345678</code>) or an Amazon Resource Name
        /// (ARN) for a virtual device (such as <code>arn:aws:iam::123456789012:mfa/user</code>).
        /// You can find the device for an IAM user by going to the AWS Management Console and
        /// viewing the user's security credentials. </para><para>The regex used to validated this parameter is a string of characters consisting of
        /// upper- and lower-case alphanumeric characters with no spaces. You can also include
        /// underscores or any of the following characters: =,.@:/-</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String SerialNumber { get; set; }
        #endregion
        
        #region Parameter TokenCode
        /// <summary>
        /// <para>
        /// <para>The value provided by the MFA device, if MFA is required. If any policy requires the
        /// IAM user to submit an MFA code, specify this value. If MFA authentication is required,
        /// and the user does not provide a code when requesting a set of temporary security credentials,
        /// the user will receive an "access denied" response when requesting resources that require
        /// MFA authentication.</para><para>The format for this parameter, as described by its regex pattern, is a sequence of
        /// six numeric digits.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String TokenCode { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("DurationInSeconds"))
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Credentials;
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
        
        private Amazon.SecurityToken.Model.GetSessionTokenResponse CallAWSServiceOperation(IAmazonSecurityTokenService client, Amazon.SecurityToken.Model.GetSessionTokenRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Token Service", "GetSessionToken");
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
        }
        
    }
}
