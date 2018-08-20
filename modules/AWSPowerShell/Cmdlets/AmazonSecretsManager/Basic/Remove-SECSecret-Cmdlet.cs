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
    /// Deletes an entire secret and all of its versions. You can optionally include a recovery
    /// window during which you can restore the secret. If you don't specify a recovery window
    /// value, the operation defaults to 30 days. Secrets Manager attaches a <code>DeletionDate</code>
    /// stamp to the secret that specifies the end of the recovery window. At the end of the
    /// recovery window, Secrets Manager deletes the secret permanently.
    /// 
    ///  
    /// <para>
    /// At any time before recovery window ends, you can use <a>RestoreSecret</a> to remove
    /// the <code>DeletionDate</code> and cancel the deletion of the secret.
    /// </para><para>
    /// You cannot access the encrypted secret information in any secret that is scheduled
    /// for deletion. If you need to access that information, you must cancel the deletion
    /// with <a>RestoreSecret</a> and then retrieve the information.
    /// </para><note><ul><li><para>
    /// There is no explicit operation to delete a version of a secret. Instead, remove all
    /// staging labels from the <code>VersionStage</code> field of a version. That marks the
    /// version as deprecated and allows Secrets Manager to delete it as needed. Versions
    /// that do not have any staging labels do not show up in <a>ListSecretVersionIds</a>
    /// unless you specify <code>IncludeDeprecated</code>.
    /// </para></li><li><para>
    /// The permanent secret deletion at the end of the waiting period is performed as a background
    /// task with low priority. There is no guarantee of a specific time after the recovery
    /// window for the actual delete operation to occur.
    /// </para></li></ul></note><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:DeleteSecret
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To create a secret, use <a>CreateSecret</a>.
    /// </para></li><li><para>
    /// To cancel deletion of a version of a secret before the recovery window has expired,
    /// use <a>RestoreSecret</a>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Remove", "SECSecret", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.SecretsManager.Model.DeleteSecretResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager DeleteSecret API operation.", Operation = new[] {"DeleteSecret"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.DeleteSecretResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.DeleteSecretResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSECSecretCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter DeleteWithNoRecovery
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies that the secret is to be deleted without any recovery window.
        /// You can't use both this parameter and the <code>RecoveryWindowInDays</code> parameter
        /// in the same API call.</para><para>An asynchronous background process performs the actual deletion, so there can be a
        /// short delay before the operation completes. If you write code to delete and then immediately
        /// recreate a secret with the same name, ensure that your code includes appropriate back
        /// off and retry logic.</para><important><para>Use this parameter with caution. This parameter causes the operation to skip the normal
        /// waiting period before the permanent deletion that AWS would normally impose with the
        /// <code>RecoveryWindowInDays</code> parameter. If you delete a secret with the <code>ForceDeleteWithouRecovery</code>
        /// parameter, then you have no opportunity to recover the secret. It is permanently lost.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DeleteWithNoRecovery { get; set; }
        #endregion
        
        #region Parameter RecoveryWindowInDay
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies the number of days that Secrets Manager waits before it can delete
        /// the secret. You can't use both this parameter and the <code>ForceDeleteWithoutRecovery</code>
        /// parameter in the same API call.</para><para>This value can range from 7 to 30 days. The default value is 30.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RecoveryWindowInDays")]
        public System.Int64 RecoveryWindowInDay { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret that you want to delete. You can specify either the Amazon Resource
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SECSecret (DeleteSecret)"))
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
            
            if (ParameterWasBound("DeleteWithNoRecovery"))
                context.DeleteWithNoRecovery = this.DeleteWithNoRecovery;
            if (ParameterWasBound("RecoveryWindowInDay"))
                context.RecoveryWindowInDays = this.RecoveryWindowInDay;
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
            var request = new Amazon.SecretsManager.Model.DeleteSecretRequest();
            
            if (cmdletContext.DeleteWithNoRecovery != null)
            {
                request.ForceDeleteWithoutRecovery = cmdletContext.DeleteWithNoRecovery.Value;
            }
            if (cmdletContext.RecoveryWindowInDays != null)
            {
                request.RecoveryWindowInDays = cmdletContext.RecoveryWindowInDays.Value;
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
        
        private Amazon.SecretsManager.Model.DeleteSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.DeleteSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "DeleteSecret");
            try
            {
                #if DESKTOP
                return client.DeleteSecret(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteSecretAsync(request);
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
            public System.Boolean? DeleteWithNoRecovery { get; set; }
            public System.Int64? RecoveryWindowInDays { get; set; }
            public System.String SecretId { get; set; }
        }
        
    }
}
