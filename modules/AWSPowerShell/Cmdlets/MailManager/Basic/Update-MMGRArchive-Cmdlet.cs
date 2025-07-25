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
using Amazon.MailManager;
using Amazon.MailManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MMGR
{
    /// <summary>
    /// Updates the attributes of an existing email archive.
    /// </summary>
    [Cmdlet("Update", "MMGRArchive", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon SES Mail Manager UpdateArchive API operation.", Operation = new[] {"UpdateArchive"}, SelectReturnType = typeof(Amazon.MailManager.Model.UpdateArchiveResponse))]
    [AWSCmdletOutput("None or Amazon.MailManager.Model.UpdateArchiveResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.MailManager.Model.UpdateArchiveResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateMMGRArchiveCmdlet : AmazonMailManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ArchiveId
        /// <summary>
        /// <para>
        /// <para>The identifier of the archive to update.</para>
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
        public System.String ArchiveId { get; set; }
        #endregion
        
        #region Parameter ArchiveName
        /// <summary>
        /// <para>
        /// <para>A new, unique name for the archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArchiveName { get; set; }
        #endregion
        
        #region Parameter Retention_RetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The enum value sets the period for retaining emails in an archive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MailManager.RetentionPeriod")]
        public Amazon.MailManager.RetentionPeriod Retention_RetentionPeriod { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MailManager.Model.UpdateArchiveResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ArchiveId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MMGRArchive (UpdateArchive)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MailManager.Model.UpdateArchiveResponse, UpdateMMGRArchiveCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ArchiveId = this.ArchiveId;
            #if MODULAR
            if (this.ArchiveId == null && ParameterWasBound(nameof(this.ArchiveId)))
            {
                WriteWarning("You are passing $null as a value for parameter ArchiveId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ArchiveName = this.ArchiveName;
            context.Retention_RetentionPeriod = this.Retention_RetentionPeriod;
            
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
            var request = new Amazon.MailManager.Model.UpdateArchiveRequest();
            
            if (cmdletContext.ArchiveId != null)
            {
                request.ArchiveId = cmdletContext.ArchiveId;
            }
            if (cmdletContext.ArchiveName != null)
            {
                request.ArchiveName = cmdletContext.ArchiveName;
            }
            
             // populate Retention
            var requestRetentionIsNull = true;
            request.Retention = new Amazon.MailManager.Model.ArchiveRetention();
            Amazon.MailManager.RetentionPeriod requestRetention_retention_RetentionPeriod = null;
            if (cmdletContext.Retention_RetentionPeriod != null)
            {
                requestRetention_retention_RetentionPeriod = cmdletContext.Retention_RetentionPeriod;
            }
            if (requestRetention_retention_RetentionPeriod != null)
            {
                request.Retention.RetentionPeriod = requestRetention_retention_RetentionPeriod;
                requestRetentionIsNull = false;
            }
             // determine if request.Retention should be set to null
            if (requestRetentionIsNull)
            {
                request.Retention = null;
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
        
        private Amazon.MailManager.Model.UpdateArchiveResponse CallAWSServiceOperation(IAmazonMailManager client, Amazon.MailManager.Model.UpdateArchiveRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SES Mail Manager", "UpdateArchive");
            try
            {
                return client.UpdateArchiveAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ArchiveId { get; set; }
            public System.String ArchiveName { get; set; }
            public Amazon.MailManager.RetentionPeriod Retention_RetentionPeriod { get; set; }
            public System.Func<Amazon.MailManager.Model.UpdateArchiveResponse, UpdateMMGRArchiveCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
