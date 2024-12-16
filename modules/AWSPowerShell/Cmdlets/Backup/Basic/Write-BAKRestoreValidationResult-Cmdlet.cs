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
using Amazon.Backup;
using Amazon.Backup.Model;

namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// This request allows you to send your independent self-run restore test validation
    /// results. <c>RestoreJobId</c> and <c>ValidationStatus</c> are required. Optionally,
    /// you can input a <c>ValidationStatusMessage</c>.
    /// </summary>
    [Cmdlet("Write", "BAKRestoreValidationResult", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Backup PutRestoreValidationResult API operation.", Operation = new[] {"PutRestoreValidationResult"}, SelectReturnType = typeof(Amazon.Backup.Model.PutRestoreValidationResultResponse))]
    [AWSCmdletOutput("None or Amazon.Backup.Model.PutRestoreValidationResultResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Backup.Model.PutRestoreValidationResultResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteBAKRestoreValidationResultCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RestoreJobId
        /// <summary>
        /// <para>
        /// <para>This is a unique identifier of a restore job within Backup.</para>
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
        public System.String RestoreJobId { get; set; }
        #endregion
        
        #region Parameter ValidationStatus
        /// <summary>
        /// <para>
        /// <para>The status of your restore validation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Backup.RestoreValidationStatus")]
        public Amazon.Backup.RestoreValidationStatus ValidationStatus { get; set; }
        #endregion
        
        #region Parameter ValidationStatusMessage
        /// <summary>
        /// <para>
        /// <para>This is an optional message string you can input to describe the validation status
        /// for the restore test validation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ValidationStatusMessage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.PutRestoreValidationResultResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RestoreJobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-BAKRestoreValidationResult (PutRestoreValidationResult)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.PutRestoreValidationResultResponse, WriteBAKRestoreValidationResultCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RestoreJobId = this.RestoreJobId;
            #if MODULAR
            if (this.RestoreJobId == null && ParameterWasBound(nameof(this.RestoreJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter RestoreJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidationStatus = this.ValidationStatus;
            #if MODULAR
            if (this.ValidationStatus == null && ParameterWasBound(nameof(this.ValidationStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter ValidationStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ValidationStatusMessage = this.ValidationStatusMessage;
            
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
            var request = new Amazon.Backup.Model.PutRestoreValidationResultRequest();
            
            if (cmdletContext.RestoreJobId != null)
            {
                request.RestoreJobId = cmdletContext.RestoreJobId;
            }
            if (cmdletContext.ValidationStatus != null)
            {
                request.ValidationStatus = cmdletContext.ValidationStatus;
            }
            if (cmdletContext.ValidationStatusMessage != null)
            {
                request.ValidationStatusMessage = cmdletContext.ValidationStatusMessage;
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
        
        private Amazon.Backup.Model.PutRestoreValidationResultResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.PutRestoreValidationResultRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "PutRestoreValidationResult");
            try
            {
                #if DESKTOP
                return client.PutRestoreValidationResult(request);
                #elif CORECLR
                return client.PutRestoreValidationResultAsync(request).GetAwaiter().GetResult();
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
            public System.String RestoreJobId { get; set; }
            public Amazon.Backup.RestoreValidationStatus ValidationStatus { get; set; }
            public System.String ValidationStatusMessage { get; set; }
            public System.Func<Amazon.Backup.Model.PutRestoreValidationResultResponse, WriteBAKRestoreValidationResultCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
