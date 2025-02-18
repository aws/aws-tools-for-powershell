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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Modifies the settings for a set of cluster snapshots.
    /// </summary>
    [Cmdlet("Edit", "RSClusterSnapshotBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse")]
    [AWSCmdlet("Calls the Amazon Redshift BatchModifyClusterSnapshots API operation.", Operation = new[] {"BatchModifyClusterSnapshots"}, SelectReturnType = typeof(Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse",
        "This cmdlet returns an Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse object containing multiple properties."
    )]
    public partial class EditRSClusterSnapshotBatchCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Enforce
        /// <summary>
        /// <para>
        /// <para>A boolean value indicating whether to override an exception if the retention period
        /// has passed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enforce { get; set; }
        #endregion
        
        #region Parameter ManualSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days that a manual snapshot is retained. If you specify the value -1,
        /// the manual snapshot is retained indefinitely.</para><para>The number must be either -1 or an integer between 1 and 3,653.</para><para>If you decrease the manual snapshot retention period from its current value, existing
        /// manual snapshots that fall outside of the new retention period will return an error.
        /// If you want to suppress the errors and delete the snapshots, use the force option.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter SnapshotIdentifierList
        /// <summary>
        /// <para>
        /// <para>A list of snapshot identifiers you want to modify.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String[] SnapshotIdentifierList { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSClusterSnapshotBatch (BatchModifyClusterSnapshots)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse, EditRSClusterSnapshotBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enforce = this.Enforce;
            context.ManualSnapshotRetentionPeriod = this.ManualSnapshotRetentionPeriod;
            if (this.SnapshotIdentifierList != null)
            {
                context.SnapshotIdentifierList = new List<System.String>(this.SnapshotIdentifierList);
            }
            #if MODULAR
            if (this.SnapshotIdentifierList == null && ParameterWasBound(nameof(this.SnapshotIdentifierList)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotIdentifierList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Redshift.Model.BatchModifyClusterSnapshotsRequest();
            
            if (cmdletContext.Enforce != null)
            {
                request.Force = cmdletContext.Enforce.Value;
            }
            if (cmdletContext.ManualSnapshotRetentionPeriod != null)
            {
                request.ManualSnapshotRetentionPeriod = cmdletContext.ManualSnapshotRetentionPeriod.Value;
            }
            if (cmdletContext.SnapshotIdentifierList != null)
            {
                request.SnapshotIdentifierList = cmdletContext.SnapshotIdentifierList;
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
        
        private Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.BatchModifyClusterSnapshotsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "BatchModifyClusterSnapshots");
            try
            {
                return client.BatchModifyClusterSnapshotsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Enforce { get; set; }
            public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
            public List<System.String> SnapshotIdentifierList { get; set; }
            public System.Func<Amazon.Redshift.Model.BatchModifyClusterSnapshotsResponse, EditRSClusterSnapshotBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
