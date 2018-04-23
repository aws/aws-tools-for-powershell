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
    /// Modifies the staging labels attached to a version of a secret. Staging labels are
    /// used to track a version as it progresses through the secret rotation process. You
    /// can attach a staging label to only one version of a secret at a time. If a staging
    /// label to be added is already attached to another version, then it is moved--removed
    /// from the other version first and then attached to this one. For more information about
    /// staging labels, see <a href="http://docs.aws.amazon.com/secretsmanager/latest/userguide/terms-concepts.html#term_staging-label">Staging
    /// Labels</a> in the <i>AWS Secrets Manager User Guide</i>. 
    /// 
    ///  
    /// <para>
    /// The staging labels that you specify in the <code>VersionStage</code> parameter are
    /// added to the existing list of staging labels--they don't replace it.
    /// </para><para>
    /// You can move the <code>AWSCURRENT</code> staging label to this version by including
    /// it in this call.
    /// </para><note><para>
    /// Whenever you move <code>AWSCURRENT</code>, Secrets Manager automatically moves the
    /// label <code>AWSPREVIOUS</code> to the version that <code>AWSCURRENT</code> was removed
    /// from.
    /// </para></note><para>
    /// If this action results in the last label being removed from a version, then the version
    /// is considered to be 'deprecated' and can be deleted by Secrets Manager.
    /// </para><para><b>Minimum permissions</b></para><para>
    /// To run this command, you must have the following permissions:
    /// </para><ul><li><para>
    /// secretsmanager:UpdateSecretVersionStage
    /// </para></li></ul><para><b>Related operations</b></para><ul><li><para>
    /// To get the list of staging labels that are currently associated with a version of
    /// a secret, use <code><a>DescribeSecret</a></code> and examine the <code>SecretVersionsToStages</code>
    /// response value.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Update", "SECSecretVersionStage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecretsManager.Model.UpdateSecretVersionStageResponse")]
    [AWSCmdlet("Calls the AWS Secrets Manager UpdateSecretVersionStage API operation.", Operation = new[] {"UpdateSecretVersionStage"})]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.UpdateSecretVersionStageResponse",
        "This cmdlet returns a Amazon.SecretsManager.Model.UpdateSecretVersionStageResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSECSecretVersionStageCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter MoveToVersionId
        /// <summary>
        /// <para>
        /// <para>(Optional) The secret version ID that you want to add the staging labels to.</para><para>If any of the staging labels are already attached to a different version of the secret,
        /// then they are removed from that version before adding them to this version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String MoveToVersionId { get; set; }
        #endregion
        
        #region Parameter RemoveFromVersionId
        /// <summary>
        /// <para>
        /// <para>(Optional) Specifies the secret version ID of the version that the staging labels
        /// are to be removed from.</para><para>If you want to move a label to a new version, you do not have to explicitly remove
        /// it with this parameter. Adding a label using the <code>MoveToVersionId</code> parameter
        /// automatically removes it from the old version. However, if you do include both the
        /// "MoveTo" and "RemoveFrom" parameters, then the move is successful only if the staging
        /// labels are actually present on the "RemoveFrom" version. If a staging label was on
        /// a different version than "RemoveFrom", then the request fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RemoveFromVersionId { get; set; }
        #endregion
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret with the version whose list of staging labels you want to modify.
        /// You can specify either the Amazon Resource Name (ARN) or the friendly name of the
        /// secret.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter VersionStage
        /// <summary>
        /// <para>
        /// <para>The list of staging labels to add to this version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String VersionStage { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SECSecretVersionStage (UpdateSecretVersionStage)"))
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
            
            context.MoveToVersionId = this.MoveToVersionId;
            context.RemoveFromVersionId = this.RemoveFromVersionId;
            context.SecretId = this.SecretId;
            context.VersionStage = this.VersionStage;
            
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
            var request = new Amazon.SecretsManager.Model.UpdateSecretVersionStageRequest();
            
            if (cmdletContext.MoveToVersionId != null)
            {
                request.MoveToVersionId = cmdletContext.MoveToVersionId;
            }
            if (cmdletContext.RemoveFromVersionId != null)
            {
                request.RemoveFromVersionId = cmdletContext.RemoveFromVersionId;
            }
            if (cmdletContext.SecretId != null)
            {
                request.SecretId = cmdletContext.SecretId;
            }
            if (cmdletContext.VersionStage != null)
            {
                request.VersionStage = cmdletContext.VersionStage;
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
        
        private Amazon.SecretsManager.Model.UpdateSecretVersionStageResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.UpdateSecretVersionStageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "UpdateSecretVersionStage");
            try
            {
                #if DESKTOP
                return client.UpdateSecretVersionStage(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateSecretVersionStageAsync(request);
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
            public System.String MoveToVersionId { get; set; }
            public System.String RemoveFromVersionId { get; set; }
            public System.String SecretId { get; set; }
            public System.String VersionStage { get; set; }
        }
        
    }
}
