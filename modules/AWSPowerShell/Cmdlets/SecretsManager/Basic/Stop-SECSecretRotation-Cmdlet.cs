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
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace Amazon.PowerShell.Cmdlets.SEC
{
    /// <summary>
    /// Disables automatic scheduled rotation and cancels the rotation of a secret if currently
    /// in progress.
    /// 
    ///  
    /// <para>
    /// To re-enable scheduled rotation, call <a>RotateSecret</a> with <code>AutomaticallyRotateAfterDays</code>
    /// set to a value greater than 0. This immediately rotates your secret and then enables
    /// the automatic schedule.
    /// </para><note><para>
    /// If you cancel a rotation while in progress, it can leave the <code>VersionStage</code>
    /// labels in an unexpected state. Depending on the step of the rotation in progress,
    /// you might need to remove the staging label <code>AWSPENDING</code> from the partially
    /// created version, specified by the <code>VersionId</code> response value. You should
    /// also evaluate the partially rotated new version to see if it should be deleted, which
    /// you can do by removing all staging labels from the new version <code>VersionStage</code>
    /// field.
    /// </para></note><para>
    /// To successfully start a rotation, the staging label <code>AWSPENDING</code> must be
    /// in one of the following states:
    /// </para><ul><li><para>
    /// Not attached to any version at all
    /// </para></li><li><para>
    /// Attached to the same version as the staging label <code>AWSCURRENT</code></para></li></ul><para>
    /// If the staging label <code>AWSPENDING</code> attached to a different version than
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
    [AWSCmdlet("Calls the AWS Secrets Manager CancelRotateSecret API operation.", Operation = new[] {"CancelRotateSecret"}, SelectReturnType = typeof(Amazon.SecretsManager.Model.CancelRotateSecretResponse))]
    [AWSCmdletOutput("Amazon.SecretsManager.Model.CancelRotateSecretResponse",
        "This cmdlet returns an Amazon.SecretsManager.Model.CancelRotateSecretResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopSECSecretRotationCmdlet : AmazonSecretsManagerClientCmdlet, IExecutor
    {
        
        #region Parameter SecretId
        /// <summary>
        /// <para>
        /// <para>Specifies the secret to cancel a rotation request. You can specify either the Amazon
        /// Resource Name (ARN) or the friendly name of the secret.</para><para>For an ARN, we recommend that you specify a complete ARN rather than a partial ARN.</para>
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
        public System.String SecretId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecretsManager.Model.CancelRotateSecretResponse).
        /// Specifying the name of a property of type Amazon.SecretsManager.Model.CancelRotateSecretResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SecretId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SecretId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SecretId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SecretId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-SECSecretRotation (CancelRotateSecret)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecretsManager.Model.CancelRotateSecretResponse, StopSECSecretRotationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SecretId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SecretId = this.SecretId;
            #if MODULAR
            if (this.SecretId == null && ParameterWasBound(nameof(this.SecretId)))
            {
                WriteWarning("You are passing $null as a value for parameter SecretId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecretsManager.Model.CancelRotateSecretRequest();
            
            if (cmdletContext.SecretId != null)
            {
                request.SecretId = cmdletContext.SecretId;
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
        
        private Amazon.SecretsManager.Model.CancelRotateSecretResponse CallAWSServiceOperation(IAmazonSecretsManager client, Amazon.SecretsManager.Model.CancelRotateSecretRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Secrets Manager", "CancelRotateSecret");
            try
            {
                #if DESKTOP
                return client.CancelRotateSecret(request);
                #elif CORECLR
                return client.CancelRotateSecretAsync(request).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SecretsManager.Model.CancelRotateSecretResponse, StopSECSecretRotationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
