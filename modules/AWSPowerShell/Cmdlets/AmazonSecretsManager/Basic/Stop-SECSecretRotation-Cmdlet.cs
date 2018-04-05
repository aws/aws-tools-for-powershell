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
    /// Disables automatic scheduled rotation and cancels the rotation of a secret if one
    /// is currently in progress.
    /// 
    ///  
    /// <para>
    /// To re-enable scheduled rotation, call <a>RotateSecret</a> with <code>AutomaticallyRotateAfterDays</code>
    /// set to a value greater than 0. This will immediately rotate your secret and then enable
    /// the automatic schedule.
    /// </para><note><para>
    /// If you cancel a rotation that is in progress, it can leave the <code>VersionStage</code>
    /// labels in an unexpected state. Depending on what step of the rotation was in progress,
    /// you might need to remove the staging label <code>AWSPENDING</code> from the partially
    /// created version, specified by the <code>SecretVersionId</code> response value. You
    /// should also evaluate the partially rotated new version to see if it should be deleted,
    /// which you can do by removing all staging labels from the new version's <code>VersionStage</code>
    /// field.
    /// </para></note><para>
    /// To successfully start a rotation, the staging label <code>AWSPENDING</code> must be
    /// in one of the following states:
    /// </para><ul><li><para>
    /// Not be attached to any version at all
    /// </para></li><li><para>
    /// Attached to the same version as the staging label <code>AWSCURRENT</code></para></li></ul><para>
    /// If the staging label <code>AWSPENDING</code> is attached to a different version than
    /// the version with <code>AWSCURRENT</code> then the attempt to rotate fails.
    /// </para><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:CancelRotateSecret
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To configure rotation for a secret or to manually trigger a rotation, use <a>RotateSecret</a>.
    /// </para></li><li><para>
    /// To get the rotation configuration details for a secret, use <a>DescribeSecret</a>.
    /// </para></li><li><para>
    /// To list all of the currently available secrets, use <a>ListSecrets</a>.
    /// </para></li><li><para>
    /// To list all of the versions currently associated with a secret, use <a>ListSecretVersionIds</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Stop", "SECSecretRotation", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.CancelRotateSecretResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager CancelRotateSecret API operation.", Operation = new[] {"CancelRotateSecret"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.CancelRotateSecretResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.CancelRotateSecretResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopSECSecretRotationCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret for which you want to cancel a rotation request. You can specify
        /// either the Amazon Resource Name (ARN) or the friendly name of the secret.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-SECSecretRotation (CancelRotateSecret)"))
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
            var request = new Amazon.SecretsManager.Model.CancelRotateSecretRequest();
            
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
        
        private Amazon.SecretsManager.Model.CancelRotateSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.CancelRotateSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "CancelRotateSecret");
            try
            {
                #if DESKTOP
                return client.CancelRotateSecret(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CancelRotateSecretAsync(request);
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
            public System.String SecretId { get; set; }
        }
        
    }
}
