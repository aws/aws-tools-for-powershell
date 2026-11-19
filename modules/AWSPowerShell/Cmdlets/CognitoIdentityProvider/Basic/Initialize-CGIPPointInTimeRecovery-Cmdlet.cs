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
using System.Threading;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CGIP
{
    /// <summary>
    /// Initiates a point-in-time recovery of a user pool to a time in the past that you specify.
    /// This operation is the first step of a recovery and doesn't change your user pool data.
    /// Amazon Cognito pauses write operations in the user pool and generates a recovery preview,
    /// which might not be available immediately. The preview shows the number of entities
    /// that the recovery creates, updates, and deletes. To check the status of the recovery
    /// and review the preview, make a request. When the status is <c>PREVIEW_GENERATED</c>,
    /// apply the recovery with a request or discard it with a request. The time that it takes
    /// to generate the recovery preview doesn't depend on the size of your user pool.
    /// 
    ///  <important><para>
    /// Point-in-time recovery is a disaster recovery feature. Use it to recover from accidental
    /// or unauthorized changes that affect your user data, for example the deletion or corruption
    /// of many users. Don't use point-in-time recovery to remove users that were created
    /// recently or to revert changes to individual users. To delete or update individual
    /// users, use operations like and .
    /// </para></important><para>
    /// While a recovery is in progress, Amazon Cognito blocks operations that write to the
    /// user pool, for example user sign-up, user creation, and attribute updates. Sign-in
    /// and read operations continue to work, with the following exceptions:
    /// </para><ul><li><para>
    /// Users who must set a new password, set up MFA, or respond to a TOTP MFA challenge
    /// can't complete sign-in. Sign-in with the <c>NEW_PASSWORD_REQUIRED</c>, <c>MFA_SETUP</c>,
    /// and <c>SOFTWARE_TOKEN_MFA</c> challenges fails until the recovery ends.
    /// </para></li><li><para>
    /// Federated users can sign in only if they have previously signed in to the user pool
    /// and their attributes from the external identity provider haven't changed.
    /// </para></li><li><para>
    /// You can't create or start user import jobs. Start your import jobs after the recovery
    /// ends.
    /// </para></li></ul><para>
    /// If you don't start or cancel the recovery within 24 hours after you initiate it, the
    /// recovery preview expires. Amazon Cognito then resumes write operations and doesn't
    /// change your user pool data. The 24-hour period includes the time that Amazon Cognito
    /// takes to generate the recovery preview.
    /// </para><para>
    /// A point-in-time recovery restores user data, including user profiles and attributes,
    /// group memberships, passwords, MFA settings, and passkeys. It doesn't restore user
    /// pool configuration, for example app clients, the attribute schema, encryption settings,
    /// or multi-Region replication settings. Users who changed their password after the recovery
    /// point keep their current password.
    /// </para><para>
    /// The following requirements and limits apply to point-in-time recovery:
    /// </para><ul><li><para>
    /// Your user pool must be on the Essentials or Plus <a href="https://docs.aws.amazon.com/cognito/latest/developerguide/cognito-sign-in-feature-plans.html">feature
    /// plan</a>. With the Essentials feature plan, you can recover your user pool to a point
    /// in time up to 1 day in the past. With the Plus feature plan, you can recover up to
    /// 14 days in the past. Your user pool must have been on the required feature plan at
    /// the recovery point. For example, to recover to a point in time 14 days ago, your user
    /// pool must have been on the Plus feature plan for the past 14 days.
    /// </para></li><li><para>
    /// The recovery point must be at least 15 minutes in the past and can't be earlier than
    /// the creation time of the user pool.
    /// </para></li><li><para>
    /// A user pool can have only one active recovery at a time.
    /// </para></li><li><para>
    /// An Amazon Web Services account can have up to five active recoveries at a time across
    /// all of its user pools. An organization in Amazon Web Services Organizations can have
    /// up to ten active recoveries at a time across all of its accounts.
    /// </para></li><li><para>
    /// You can complete one recovery of a user pool in a 24-hour period.
    /// </para></li><li><para>
    /// You can create up to three recovery previews of a user pool, ten recovery previews
    /// in an Amazon Web Services account, and 15 recovery previews in an organization in
    /// Amazon Web Services Organizations in a 24-hour period. You can create up to ten recovery
    /// previews of a user pool in a 30-day period.
    /// </para></li><li><para>
    /// You can't initiate a recovery while a user import job is in progress in your user
    /// pool. Wait for the import job to complete, or stop it with a request, and then initiate
    /// the recovery.
    /// </para></li><li><para>
    /// In a user pool with multi-Region replication, you can initiate a recovery only in
    /// the primary Amazon Web Services Region, and only after replication is complete.
    /// </para></li><li><para>
    /// If your user pool uses a customer managed key in KMS for encryption, the key must
    /// remain enabled and accessible to Amazon Cognito for the duration of the recovery.
    /// </para></li><li><para>
    /// Some user pools don't support point-in-time recovery, for example some older user
    /// pools and user pools that contain user data with characters or formats that point-in-time
    /// recovery doesn't support. If your user pool doesn't support it, Amazon Cognito returns
    /// an error when you initiate a recovery. To get help with this limitation, contact Amazon
    /// Web Services Support.
    /// </para></li></ul><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Initialize", "CGIPPointInTimeRecovery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.RestorationType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider InitiatePointInTimeRecovery API operation.", Operation = new[] {"InitiatePointInTimeRecovery"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.RestorationType or Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.RestorationType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class InitializeCGIPPointInTimeRecoveryCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RestoreTimestamp
        /// <summary>
        /// <para>
        /// <para>The point in time that you want to recover your user pool to. Amazon Cognito reverts
        /// changes to user data that occurred after this time. The recovery point must be at
        /// least 15 minutes in the past and within the recovery period of your user pool feature
        /// plan: up to 1 day in the past with the Essentials feature plan, or up to 14 days in
        /// the past with the Plus feature plan.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? RestoreTimestamp { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that you want to recover.</para>
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
        public System.String UserPoolId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Restoration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Restoration";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.UserPoolId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Initialize-CGIPPointInTimeRecovery (InitiatePointInTimeRecovery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryResponse, InitializeCGIPPointInTimeRecoveryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RestoreTimestamp = this.RestoreTimestamp;
            #if MODULAR
            if (this.RestoreTimestamp == null && ParameterWasBound(nameof(this.RestoreTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UserPoolId = this.UserPoolId;
            #if MODULAR
            if (this.UserPoolId == null && ParameterWasBound(nameof(this.UserPoolId)))
            {
                WriteWarning("You are passing $null as a value for parameter UserPoolId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryRequest();
            
            if (cmdletContext.RestoreTimestamp != null)
            {
                request.RestoreTimestamp = cmdletContext.RestoreTimestamp.Value;
            }
            if (cmdletContext.UserPoolId != null)
            {
                request.UserPoolId = cmdletContext.UserPoolId;
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
        
        private Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "InitiatePointInTimeRecovery");
            try
            {
                return client.InitiatePointInTimeRecoveryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? RestoreTimestamp { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.InitiatePointInTimeRecoveryResponse, InitializeCGIPPointInTimeRecoveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Restoration;
        }
        
    }
}
