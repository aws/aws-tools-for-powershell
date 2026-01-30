/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Retrieves the identity context for a Quick Sight user in a specified namespace, allowing
    /// you to obtain identity tokens that can be used with identity-enhanced IAM role sessions
    /// to call identity-aware APIs.
    /// 
    ///  
    /// <para>
    /// Currently, you can call the following APIs with identity-enhanced Credentials
    /// </para><ul><li><para><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_StartDashboardSnapshotJob.html">StartDashboardSnapshotJob</a></para></li><li><para><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_DescribeDashboardSnapshotJob.html">DescribeDashboardSnapshotJob</a></para></li><li><para><a href="https://docs.aws.amazon.com/quicksight/latest/APIReference/API_DescribeDashboardSnapshotJobResult.html">DescribeDashboardSnapshotJobResult</a></para></li></ul><para><b>Supported Authentication Methods</b></para><para>
    /// This API supports Quick Sight native users, IAM federated users, and Active Directory
    /// users. For Quick Sight users authenticated by Amazon Web Services Identity Center,
    /// see <a href="https://docs.aws.amazon.com/singlesignon/latest/userguide/trustedidentitypropagation-identity-enhanced-iam-role-sessions.html">Identity
    /// Center documentation on identity-enhanced IAM role sessions</a>.
    /// </para><para><b>Supported Regions</b></para><para>
    /// The GetIdentityContext API works only in regions that support at least one of these
    /// identity types:
    /// </para><ul><li><para>
    /// Amazon Quick Sight native identity
    /// </para></li><li><para>
    /// IAM federated identity
    /// </para></li><li><para>
    /// Active Directory
    /// </para></li></ul><para>
    /// To use this API successfully, call it in the same region where your user's identity
    /// resides. For example, if your user's identity is in us-east-1, make the API call in
    /// us-east-1. For more information about managing identities in Amazon Quick Sight, see
    /// <a href="https://docs.aws.amazon.com/quicksight/latest/userguide/identity.html">Identity
    /// and access management in Amazon Quick Sight</a> in the Amazon Quick Sight User Guide.
    /// </para><para><b>Getting Identity-Enhanced Credentials</b></para><para>
    /// To obtain identity-enhanced credentials, follow these steps:
    /// </para><ul><li><para>
    /// Call the GetIdentityContext API to retrieve an identity token for the specified user.
    /// </para></li><li><para>
    /// Use the identity token with the <a href="https://docs.aws.amazon.com/STS/latest/APIReference/API_AssumeRole.html">STS
    /// AssumeRole API</a> to obtain identity-enhanced IAM role session credentials.
    /// </para></li></ul><para><b>Usage with STS AssumeRole</b></para><para>
    /// The identity token returned by this API should be used with the STS AssumeRole API
    /// to obtain credentials for an identity-enhanced IAM role session. When calling AssumeRole,
    /// include the identity token in the <c>ProvidedContexts</c> parameter with <c>ProviderArn</c>
    /// set to <c>arn:aws:iam::aws:contextProvider/QuickSight</c> and <c>ContextAssertion</c>
    /// set to the identity token received from this API.
    /// </para><para>
    /// The assumed role must allow the <c>sts:SetContext</c> action in addition to <c>sts:AssumeRole</c>
    /// in its trust relationship policy. The trust policy should include both actions for
    /// the principal that will be assuming the role.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "QSIdentityContext")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon QuickSight GetIdentityContext API operation.", Operation = new[] {"GetIdentityContext"}, SelectReturnType = typeof(Amazon.QuickSight.Model.GetIdentityContextResponse))]
    [AWSCmdletOutput("System.String or Amazon.QuickSight.Model.GetIdentityContextResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.QuickSight.Model.GetIdentityContextResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetQSIdentityContextCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID for the Amazon Web Services account that the user whose identity context you
        /// want to retrieve is in. Currently, you use the ID for the Amazon Web Services account
        /// that contains your Quick Sight account.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter UserIdentifier_Email
        /// <summary>
        /// <para>
        /// <para>The email address of the user that you want to get identity context for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserIdentifier_Email { get; set; }
        #endregion
        
        #region Parameter Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace of the user that you want to get identity context for. This parameter
        /// is required when the UserIdentifier is specified using Email or UserName.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Namespace { get; set; }
        #endregion
        
        #region Parameter SessionExpiresAt
        /// <summary>
        /// <para>
        /// <para>The timestamp at which the session will expire.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? SessionExpiresAt { get; set; }
        #endregion
        
        #region Parameter UserIdentifier_UserArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the user that you want to get identity context for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserIdentifier_UserArn { get; set; }
        #endregion
        
        #region Parameter UserIdentifier_UserName
        /// <summary>
        /// <para>
        /// <para>The name of the user that you want to get identity context for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UserIdentifier_UserName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Context'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.GetIdentityContextResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.GetIdentityContextResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Context";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AwsAccountId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AwsAccountId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.GetIdentityContextResponse, GetQSIdentityContextCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AwsAccountId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Namespace = this.Namespace;
            context.SessionExpiresAt = this.SessionExpiresAt;
            context.UserIdentifier_Email = this.UserIdentifier_Email;
            context.UserIdentifier_UserArn = this.UserIdentifier_UserArn;
            context.UserIdentifier_UserName = this.UserIdentifier_UserName;
            
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
            var request = new Amazon.QuickSight.Model.GetIdentityContextRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.Namespace != null)
            {
                request.Namespace = cmdletContext.Namespace;
            }
            if (cmdletContext.SessionExpiresAt != null)
            {
                request.SessionExpiresAt = cmdletContext.SessionExpiresAt.Value;
            }
            
             // populate UserIdentifier
            var requestUserIdentifierIsNull = true;
            request.UserIdentifier = new Amazon.QuickSight.Model.UserIdentifier();
            System.String requestUserIdentifier_userIdentifier_Email = null;
            if (cmdletContext.UserIdentifier_Email != null)
            {
                requestUserIdentifier_userIdentifier_Email = cmdletContext.UserIdentifier_Email;
            }
            if (requestUserIdentifier_userIdentifier_Email != null)
            {
                request.UserIdentifier.Email = requestUserIdentifier_userIdentifier_Email;
                requestUserIdentifierIsNull = false;
            }
            System.String requestUserIdentifier_userIdentifier_UserArn = null;
            if (cmdletContext.UserIdentifier_UserArn != null)
            {
                requestUserIdentifier_userIdentifier_UserArn = cmdletContext.UserIdentifier_UserArn;
            }
            if (requestUserIdentifier_userIdentifier_UserArn != null)
            {
                request.UserIdentifier.UserArn = requestUserIdentifier_userIdentifier_UserArn;
                requestUserIdentifierIsNull = false;
            }
            System.String requestUserIdentifier_userIdentifier_UserName = null;
            if (cmdletContext.UserIdentifier_UserName != null)
            {
                requestUserIdentifier_userIdentifier_UserName = cmdletContext.UserIdentifier_UserName;
            }
            if (requestUserIdentifier_userIdentifier_UserName != null)
            {
                request.UserIdentifier.UserName = requestUserIdentifier_userIdentifier_UserName;
                requestUserIdentifierIsNull = false;
            }
             // determine if request.UserIdentifier should be set to null
            if (requestUserIdentifierIsNull)
            {
                request.UserIdentifier = null;
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
        
        private Amazon.QuickSight.Model.GetIdentityContextResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.GetIdentityContextRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "GetIdentityContext");
            try
            {
                #if DESKTOP
                return client.GetIdentityContext(request);
                #elif CORECLR
                return client.GetIdentityContextAsync(request).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String Namespace { get; set; }
            public System.DateTime? SessionExpiresAt { get; set; }
            public System.String UserIdentifier_Email { get; set; }
            public System.String UserIdentifier_UserArn { get; set; }
            public System.String UserIdentifier_UserName { get; set; }
            public System.Func<Amazon.QuickSight.Model.GetIdentityContextResponse, GetQSIdentityContextCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Context;
        }
        
    }
}
