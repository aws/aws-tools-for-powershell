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
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Configures and starts the asynchronous process of rotating this secret. If you include
    /// the configuration parameters, the operation sets those values for the secret and then
    /// immediately starts a rotation. If you do not include the configuration parameters,
    /// the operation starts a rotation with the values already stored in the secret. After
    /// the rotation completes, the protected service and its clients all use the new version
    /// of the secret. 
    /// 
    ///  
    /// <para>
    /// This required configuration information includes the ARN of an AWS Lambda function
    /// and the time between scheduled rotations. The Lambda rotation function creates a new
    /// version of the secret and creates or updates the credentials on the protected service
    /// to match. After testing the new credentials, the function marks the new secret with
    /// the staging label <code>AWSCURRENT</code> so that your clients all immediately begin
    /// to use the new version. For more information about rotating secrets and how to configure
    /// a Lambda function to rotate the secrets for your protected service, see <a href="http://docs.aws.amazon.com/secretsmanager/latest/userguide/rotating-secrets.html">Rotating
    /// Secrets in AWS Secrets Manager</a> in the <i>AWS Secrets Manager User Guide</i>.
    /// </para><para>
    /// Secrets Manager schedules the next rotation when the previous one is complete. Secrets
    /// Manager schedules the date by adding the rotation interval (number of days) to the
    /// actual date of the last rotation. The service chooses the hour within that 24-hour
    /// date window randomly. The minute is also chosen somewhat randomly, but weighted towards
    /// the top of the hour and influenced by a variety of factors that help distribute load.
    /// </para><para>
    /// The rotation function must end with the versions of the secret in one of two states:
    /// </para><ul><li><para>
    /// The <code>AWSPENDING</code> and <code>AWSCURRENT</code> staging labels are attached
    /// to the same version of the secret, or
    /// </para></li><li><para>
    /// The <code>AWSPENDING</code> staging label is not attached to any version of the secret.
    /// </para></li></ul><para>
    /// If instead the <code>AWSPENDING</code> staging label is present but is not attached
    /// to the same version as <code>AWSCURRENT</code> then any later invocation of <code>RotateSecret</code>
    /// assumes that a previous rotation request is still in progress and returns an error.
    /// </para><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:RotateSecret
    /// </para></li><li><para>
    /// lambda:InvokeFunction (on the function specified in the secret's metadata)
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To list the secrets in your account, use <a>ListSecrets</a>.
    /// </para></li><li><para>
    /// To get the details for a version of a secret, use <a>DescribeSecret</a>.
    /// </para></li><li><para>
    /// To create a new version of a secret, use <a>CreateSecret</a>.
    /// </para></li><li><para>
    /// To attach staging labels to or remove staging labels from a version of a secret, use
    /// <a>UpdateSecretVersionStage</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Invoke", "SECSecretRotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.RotateSecretResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager RotateSecret API operation.", Operation = new[] {"RotateSecret"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.RotateSecretResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.RotateSecretResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class InvokeSECSecretRotationCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter RotationRules_AutomaticallyAfterDay
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days between automatic scheduled rotations of the secret.</para><para>Secrets Manager schedules the next rotation when the previous one is complete. Secrets
        /// Manager schedules the date by adding the rotation interval (number of days) to the
        /// actual date of the last rotation. The service chooses the hour within that 24-hour
        /// date window randomly. The minute is also chosen somewhat randomly, but weighted towards
        /// the top of the hour and influenced by a variety of factors that help distribute load.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RotationRules_AutomaticallyAfterDays")]
        public System.Int64 RotationRules_AutomaticallyAfterDay { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies a unique identifier for the new version of the secret that helps
        /// ensure idempotency. </para><para>If you use the AWS CLI or one of the AWS SDK to call this operation, then you can
        /// leave this parameter empty. The CLI or SDK generates a random UUID for you and includes
        /// that in the request for this parameter. If you don't use the SDK and instead generate
        /// a raw HTTP request to the Secrets Manager service endpoint, then you must generate
        /// a <code>ClientRequestToken</code> yourself for new versions and include that value
        /// in the request.</para><para>You only need to specify your own value if you are implementing your own retry logic
        /// and want to ensure that a given secret is not created twice. We recommend that you
        /// generate a <a href="https://wikipedia.org/wiki/Universally_unique_identifier">UUID-type</a>
        /// value to ensure uniqueness within the specified secret. </para><para>Secrets Manager uses this value to prevent the accidental creation of duplicate versions
        /// if there are failures and retries during the function's processing. This value becomes
        /// the <code>VersionId</code> of the new version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter RotationLambdaARN
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies the ARN of the Lambda function that can rotate the secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RotationLambdaARN { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret that you want to rotate. You can specify either the Amazon Resource
        /// Name (ARN) or the friendly name of the secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String SecretId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SecretId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Invoke-SECSecretRotation (RotateSecret)"))
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
            
            context.ClientRequestToken = this.ClientRequestToken;
            context.RotationLambdaARN = this.RotationLambdaARN;
            if (ParameterWasBound("RotationRules_AutomaticallyAfterDay"))
                context.RotationRules_AutomaticallyAfterDays = this.RotationRules_AutomaticallyAfterDay;
            context.SecretId = this.SecretId;
            
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
            var request = new Amazon.SecretsManager.Model.RotateSecretRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.RotationLambdaARN != null)
            {
                request.RotationLambdaARN = cmdletContext.RotationLambdaARN;
            }
            
             // populate RotationRules
            bool requestRotationRulesIsNull = true;
            request.RotationRules = new Amazon.SecretsManager.Model.RotationRulesType();
            System.Int64? requestRotationRules_rotationRules_AutomaticallyAfterDay = null;
            if (cmdletContext.RotationRules_AutomaticallyAfterDays != null)
            {
                requestRotationRules_rotationRules_AutomaticallyAfterDay = cmdletContext.RotationRules_AutomaticallyAfterDays.Value;
            }
            if (requestRotationRules_rotationRules_AutomaticallyAfterDay != null)
            {
                request.RotationRules.AutomaticallyAfterDays = requestRotationRules_rotationRules_AutomaticallyAfterDay.Value;
                requestRotationRulesIsNull = false;
            }
             // determine if request.RotationRules should be set to null
            if (requestRotationRulesIsNull)
            {
                request.RotationRules = null;
            }
            if (cmdletContext.SecretId != null)
            {
                request.SecretId = cmdletContext.SecretId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.SecretsManager.Model.RotateSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.RotateSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "RotateSecret");
            try
            {
                #if DESKTOP
                return client.RotateSecret(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RotateSecretAsync(request);
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
            public System.String ClientRequestToken { get; set; }
            public System.String RotationLambdaARN { get; set; }
            public System.Int64? RotationRules_AutomaticallyAfterDays { get; set; }
            public System.String SecretId { get; set; }
        }
        
    }
}
