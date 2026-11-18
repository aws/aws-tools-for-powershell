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
    /// Cancels a point-in-time recovery of a user pool before Amazon Cognito applies any
    /// changes. You can cancel a recovery when its status is <c>PREVIEW_GENERATING</c> or
    /// <c>PREVIEW_GENERATED</c>. When you cancel a recovery, Amazon Cognito discards the
    /// recovery preview, resumes write operations in the user pool, and sets the status of
    /// the recovery to <c>PREVIEW_CANCELLED</c>. Your user pool data doesn't change.
    /// 
    ///  
    /// <para>
    /// You can't cancel a recovery after you start it with a request.
    /// </para><note><para>
    /// Amazon Cognito evaluates Identity and Access Management (IAM) policies in requests
    /// for this API operation. For this operation, you must use IAM credentials to authorize
    /// requests, and you must grant yourself the corresponding IAM permission in a policy.
    /// </para><para><b>Learn more</b></para><ul><li><para><a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_aws-signing.html">Signing
    /// Amazon Web Services API Requests</a></para></li><li><para><a href="https://docs.aws.amazon.com/cognito/latest/developerguide/user-pools-API-operations.html">Using
    /// the Amazon Cognito user pools API and user pool endpoints</a></para></li></ul></note>
    /// </summary>
    [Cmdlet("Stop", "CGIPPointInTimeRecovery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CognitoIdentityProvider.Model.RestorationType")]
    [AWSCmdlet("Calls the Amazon Cognito Identity Provider CancelPointInTimeRecovery API operation.", Operation = new[] {"CancelPointInTimeRecovery"}, SelectReturnType = typeof(Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryResponse))]
    [AWSCmdletOutput("Amazon.CognitoIdentityProvider.Model.RestorationType or Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryResponse",
        "This cmdlet returns an Amazon.CognitoIdentityProvider.Model.RestorationType object.",
        "The service call response (type Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopCGIPPointInTimeRecoveryCmdlet : AmazonCognitoIdentityProviderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RestoreId
        /// <summary>
        /// <para>
        /// <para>The ID of the recovery that you want to cancel. Amazon Cognito returns this ID in
        /// the response to an <c>InitiatePointInTimeRecovery</c> request.</para>
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
        public System.String RestoreId { get; set; }
        #endregion
        
        #region Parameter UserPoolId
        /// <summary>
        /// <para>
        /// <para>The ID of the user pool that contains the recovery that you want to cancel.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryResponse).
        /// Specifying the name of a property of type Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.RestoreId),
                nameof(this.UserPoolId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-CGIPPointInTimeRecovery (CancelPointInTimeRecovery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryResponse, StopCGIPPointInTimeRecoveryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RestoreId = this.RestoreId;
            #if MODULAR
            if (this.RestoreId == null && ParameterWasBound(nameof(this.RestoreId)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryRequest();
            
            if (cmdletContext.RestoreId != null)
            {
                request.RestoreId = cmdletContext.RestoreId;
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
        
        private Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryResponse CallAWSServiceOperation(IAmazonCognitoIdentityProvider client, Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Cognito Identity Provider", "CancelPointInTimeRecovery");
            try
            {
                return client.CancelPointInTimeRecoveryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String RestoreId { get; set; }
            public System.String UserPoolId { get; set; }
            public System.Func<Amazon.CognitoIdentityProvider.Model.CancelPointInTimeRecoveryResponse, StopCGIPPointInTimeRecoveryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Restoration;
        }
        
    }
}
