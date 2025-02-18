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
    /// Copies the specified automated cluster snapshot to a new manual cluster snapshot.
    /// The source must be an automated snapshot and it must be in the available state.
    /// 
    ///  
    /// <para>
    /// When you delete a cluster, Amazon Redshift deletes any automated snapshots of the
    /// cluster. Also, when the retention period of the snapshot expires, Amazon Redshift
    /// automatically deletes it. If you want to keep an automated snapshot for a longer period,
    /// you can make a manual copy of the snapshot. Manual snapshots are retained until you
    /// delete them.
    /// </para><para>
    ///  For more information about working with snapshots, go to <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/working-with-snapshots.html">Amazon
    /// Redshift Snapshots</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Copy", "RSClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Snapshot")]
    [AWSCmdlet("Calls the Amazon Redshift CopyClusterSnapshot API operation.", Operation = new[] {"CopyClusterSnapshot"}, SelectReturnType = typeof(Amazon.Redshift.Model.CopyClusterSnapshotResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.Snapshot or Amazon.Redshift.Model.CopyClusterSnapshotResponse",
        "This cmdlet returns an Amazon.Redshift.Model.Snapshot object.",
        "The service call response (type Amazon.Redshift.Model.CopyClusterSnapshotResponse) can be returned by specifying '-Select *'."
    )]
    public partial class CopyRSClusterSnapshotCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ManualSnapshotRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days that a manual snapshot is retained. If the value is -1, the manual
        /// snapshot is retained indefinitely. </para><para>The value must be either -1 or an integer between 1 and 3,653.</para><para>The default value is -1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster the source snapshot was created from. This parameter
        /// is required if your IAM user has a policy containing a snapshot resource element that
        /// specifies anything other than * for the cluster name.</para><para>Constraints:</para><ul><li><para>Must be the identifier for a valid cluster.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceSnapshotClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the source snapshot.</para><para>Constraints:</para><ul><li><para>Must be the identifier for a valid automated snapshot whose state is <c>available</c>.</para></li></ul>
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
        public System.String SourceSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter TargetSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier given to the new manual snapshot.</para><para>Constraints:</para><ul><li><para>Cannot be null, empty, or blank.</para></li><li><para>Must contain from 1 to 255 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li><li><para>Must be unique for the Amazon Web Services account that is making the request.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TargetSnapshotIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Snapshot'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.CopyClusterSnapshotResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.CopyClusterSnapshotResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Snapshot";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceSnapshotIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Copy-RSClusterSnapshot (CopyClusterSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.CopyClusterSnapshotResponse, CopyRSClusterSnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ManualSnapshotRetentionPeriod = this.ManualSnapshotRetentionPeriod;
            context.SourceSnapshotClusterIdentifier = this.SourceSnapshotClusterIdentifier;
            context.SourceSnapshotIdentifier = this.SourceSnapshotIdentifier;
            #if MODULAR
            if (this.SourceSnapshotIdentifier == null && ParameterWasBound(nameof(this.SourceSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetSnapshotIdentifier = this.TargetSnapshotIdentifier;
            #if MODULAR
            if (this.TargetSnapshotIdentifier == null && ParameterWasBound(nameof(this.TargetSnapshotIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetSnapshotIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Redshift.Model.CopyClusterSnapshotRequest();
            
            if (cmdletContext.ManualSnapshotRetentionPeriod != null)
            {
                request.ManualSnapshotRetentionPeriod = cmdletContext.ManualSnapshotRetentionPeriod.Value;
            }
            if (cmdletContext.SourceSnapshotClusterIdentifier != null)
            {
                request.SourceSnapshotClusterIdentifier = cmdletContext.SourceSnapshotClusterIdentifier;
            }
            if (cmdletContext.SourceSnapshotIdentifier != null)
            {
                request.SourceSnapshotIdentifier = cmdletContext.SourceSnapshotIdentifier;
            }
            if (cmdletContext.TargetSnapshotIdentifier != null)
            {
                request.TargetSnapshotIdentifier = cmdletContext.TargetSnapshotIdentifier;
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
        
        private Amazon.Redshift.Model.CopyClusterSnapshotResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CopyClusterSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CopyClusterSnapshot");
            try
            {
                return client.CopyClusterSnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? ManualSnapshotRetentionPeriod { get; set; }
            public System.String SourceSnapshotClusterIdentifier { get; set; }
            public System.String SourceSnapshotIdentifier { get; set; }
            public System.String TargetSnapshotIdentifier { get; set; }
            public System.Func<Amazon.Redshift.Model.CopyClusterSnapshotResponse, CopyRSClusterSnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Snapshot;
        }
        
    }
}
