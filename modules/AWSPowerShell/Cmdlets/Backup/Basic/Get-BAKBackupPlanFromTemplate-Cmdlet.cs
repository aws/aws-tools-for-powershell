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
using Amazon.Backup;
using Amazon.Backup.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAK
{
    /// <summary>
    /// Returns the template specified by its <c>templateId</c> as a backup plan.
    /// </summary>
    [Cmdlet("Get", "BAKBackupPlanFromTemplate")]
    [OutputType("Amazon.Backup.Model.BackupPlan")]
    [AWSCmdlet("Calls the AWS Backup GetBackupPlanFromTemplate API operation.", Operation = new[] {"GetBackupPlanFromTemplate"}, SelectReturnType = typeof(Amazon.Backup.Model.GetBackupPlanFromTemplateResponse))]
    [AWSCmdletOutput("Amazon.Backup.Model.BackupPlan or Amazon.Backup.Model.GetBackupPlanFromTemplateResponse",
        "This cmdlet returns an Amazon.Backup.Model.BackupPlan object.",
        "The service call response (type Amazon.Backup.Model.GetBackupPlanFromTemplateResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetBAKBackupPlanFromTemplateCmdlet : AmazonBackupClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BackupPlanTemplateId
        /// <summary>
        /// <para>
        /// <para>Uniquely identifies a stored backup plan template.</para>
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
        public System.String BackupPlanTemplateId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BackupPlanDocument'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Backup.Model.GetBackupPlanFromTemplateResponse).
        /// Specifying the name of a property of type Amazon.Backup.Model.GetBackupPlanFromTemplateResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BackupPlanDocument";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Backup.Model.GetBackupPlanFromTemplateResponse, GetBAKBackupPlanFromTemplateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BackupPlanTemplateId = this.BackupPlanTemplateId;
            #if MODULAR
            if (this.BackupPlanTemplateId == null && ParameterWasBound(nameof(this.BackupPlanTemplateId)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupPlanTemplateId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Backup.Model.GetBackupPlanFromTemplateRequest();
            
            if (cmdletContext.BackupPlanTemplateId != null)
            {
                request.BackupPlanTemplateId = cmdletContext.BackupPlanTemplateId;
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
        
        private Amazon.Backup.Model.GetBackupPlanFromTemplateResponse CallAWSServiceOperation(IAmazonBackup client, Amazon.Backup.Model.GetBackupPlanFromTemplateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Backup", "GetBackupPlanFromTemplate");
            try
            {
                return client.GetBackupPlanFromTemplateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BackupPlanTemplateId { get; set; }
            public System.Func<Amazon.Backup.Model.GetBackupPlanFromTemplateResponse, GetBAKBackupPlanFromTemplateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BackupPlanDocument;
        }
        
    }
}
