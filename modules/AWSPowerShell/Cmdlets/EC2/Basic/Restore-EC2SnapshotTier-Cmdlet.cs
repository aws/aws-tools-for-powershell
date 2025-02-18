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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Restores an archived Amazon EBS snapshot for use temporarily or permanently, or modifies
    /// the restore period or restore type for a snapshot that was previously temporarily
    /// restored.
    /// 
    ///  
    /// <para>
    /// For more information see <a href="https://docs.aws.amazon.com/ebs/latest/userguide/working-with-snapshot-archiving.html#restore-archived-snapshot">
    /// Restore an archived snapshot</a> and <a href="https://docs.aws.amazon.com/ebs/latest/userguide/working-with-snapshot-archiving.html#modify-temp-restore-period">
    /// modify the restore period or restore type for a temporarily restored snapshot</a>
    /// in the <i>Amazon EBS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Restore", "EC2SnapshotTier", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.RestoreSnapshotTierResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) RestoreSnapshotTier API operation.", Operation = new[] {"RestoreSnapshotTier"}, SelectReturnType = typeof(Amazon.EC2.Model.RestoreSnapshotTierResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.RestoreSnapshotTierResponse",
        "This cmdlet returns an Amazon.EC2.Model.RestoreSnapshotTierResponse object containing multiple properties."
    )]
    public partial class RestoreEC2SnapshotTierCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter PermanentRestore
        /// <summary>
        /// <para>
        /// <para>Indicates whether to permanently restore an archived snapshot. To permanently restore
        /// an archived snapshot, specify <c>true</c> and omit the <b>RestoreSnapshotTierRequest$TemporaryRestoreDays</b>
        /// parameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PermanentRestore { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the snapshot to restore.</para>
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
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter TemporaryRestoreDay
        /// <summary>
        /// <para>
        /// <para>Specifies the number of days for which to temporarily restore an archived snapshot.
        /// Required for temporary restores only. The snapshot will be automatically re-archived
        /// after this period.</para><para>To temporarily restore an archived snapshot, specify the number of days and omit the
        /// <b>PermanentRestore</b> parameter or set it to <c>false</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TemporaryRestoreDays")]
        public System.Int32? TemporaryRestoreDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.RestoreSnapshotTierResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.RestoreSnapshotTierResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-EC2SnapshotTier (RestoreSnapshotTier)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.RestoreSnapshotTierResponse, RestoreEC2SnapshotTierCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PermanentRestore = this.PermanentRestore;
            context.SnapshotId = this.SnapshotId;
            #if MODULAR
            if (this.SnapshotId == null && ParameterWasBound(nameof(this.SnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TemporaryRestoreDay = this.TemporaryRestoreDay;
            
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
            var request = new Amazon.EC2.Model.RestoreSnapshotTierRequest();
            
            if (cmdletContext.PermanentRestore != null)
            {
                request.PermanentRestore = cmdletContext.PermanentRestore.Value;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
            }
            if (cmdletContext.TemporaryRestoreDay != null)
            {
                request.TemporaryRestoreDays = cmdletContext.TemporaryRestoreDay.Value;
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
        
        private Amazon.EC2.Model.RestoreSnapshotTierResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.RestoreSnapshotTierRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "RestoreSnapshotTier");
            try
            {
                return client.RestoreSnapshotTierAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? PermanentRestore { get; set; }
            public System.String SnapshotId { get; set; }
            public System.Int32? TemporaryRestoreDay { get; set; }
            public System.Func<Amazon.EC2.Model.RestoreSnapshotTierResponse, RestoreEC2SnapshotTierCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
