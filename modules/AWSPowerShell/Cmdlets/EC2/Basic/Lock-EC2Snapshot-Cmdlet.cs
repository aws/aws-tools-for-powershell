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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Locks an Amazon EBS snapshot in either <i>governance</i> or <i>compliance</i> mode
    /// to protect it against accidental or malicious deletions for a specific duration. A
    /// locked snapshot can't be deleted.
    /// 
    ///  
    /// <para>
    /// You can also use this action to modify the lock settings for a snapshot that is already
    /// locked. The allowed modifications depend on the lock mode and lock state:
    /// </para><ul><li><para>
    /// If the snapshot is locked in governance mode, you can modify the lock mode and the
    /// lock duration or lock expiration date.
    /// </para></li><li><para>
    /// If the snapshot is locked in compliance mode and it is in the cooling-off period,
    /// you can modify the lock mode and the lock duration or lock expiration date.
    /// </para></li><li><para>
    /// If the snapshot is locked in compliance mode and the cooling-off period has lapsed,
    /// you can only increase the lock duration or extend the lock expiration date.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Lock", "EC2Snapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.LockSnapshotResponse")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) LockSnapshot API operation.", Operation = new[] {"LockSnapshot"}, SelectReturnType = typeof(Amazon.EC2.Model.LockSnapshotResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.LockSnapshotResponse",
        "This cmdlet returns an Amazon.EC2.Model.LockSnapshotResponse object containing multiple properties."
    )]
    public partial class LockEC2SnapshotCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CoolOffPeriod
        /// <summary>
        /// <para>
        /// <para>The cooling-off period during which you can unlock the snapshot or modify the lock
        /// settings after locking the snapshot in compliance mode, in hours. After the cooling-off
        /// period expires, you can't unlock or delete the snapshot, decrease the lock duration,
        /// or change the lock mode. You can increase the lock duration after the cooling-off
        /// period expires.</para><para>The cooling-off period is optional when locking a snapshot in compliance mode. If
        /// you are locking the snapshot in governance mode, omit this parameter.</para><para>To lock the snapshot in compliance mode immediately without a cooling-off period,
        /// omit this parameter.</para><para>If you are extending the lock duration for a snapshot that is locked in compliance
        /// mode after the cooling-off period has expired, omit this parameter. If you specify
        /// a cooling-period in a such a request, the request fails.</para><para>Allowed values: Min 1, max 72.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? CoolOffPeriod { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter ExpirationDate
        /// <summary>
        /// <para>
        /// <para>The date and time at which the snapshot lock is to automatically expire, in the UTC
        /// time zone (<c>YYYY-MM-DDThh:mm:ss.sssZ</c>).</para><para>You must specify either this parameter or <b>LockDuration</b>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpirationDate { get; set; }
        #endregion
        
        #region Parameter LockDuration
        /// <summary>
        /// <para>
        /// <para>The period of time for which to lock the snapshot, in days. The snapshot lock will
        /// automatically expire after this period lapses.</para><para>You must specify either this parameter or <b>ExpirationDate</b>, but not both.</para><para>Allowed values: Min: 1, max 36500</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? LockDuration { get; set; }
        #endregion
        
        #region Parameter LockMode
        /// <summary>
        /// <para>
        /// <para>The mode in which to lock the snapshot. Specify one of the following:</para><ul><li><para><c>governance</c> - Locks the snapshot in governance mode. Snapshots locked in governance
        /// mode can't be deleted until one of the following conditions are met:</para><ul><li><para>The lock duration expires.</para></li><li><para>The snapshot is unlocked by a user with the appropriate permissions.</para></li></ul><para>Users with the appropriate IAM permissions can unlock the snapshot, increase or decrease
        /// the lock duration, and change the lock mode to <c>compliance</c> at any time.</para><para>If you lock a snapshot in <c>governance</c> mode, omit <b> CoolOffPeriod</b>.</para></li><li><para><c>compliance</c> - Locks the snapshot in compliance mode. Snapshots locked in compliance
        /// mode can't be unlocked by any user. They can be deleted only after the lock duration
        /// expires. Users can't decrease the lock duration or change the lock mode to <c>governance</c>.
        /// However, users with appropriate IAM permissions can increase the lock duration at
        /// any time.</para><para>If you lock a snapshot in <c>compliance</c> mode, you can optionally specify <b>CoolOffPeriod</b>.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.LockMode")]
        public Amazon.EC2.LockMode LockMode { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The ID of the snapshot to lock.</para>
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.LockSnapshotResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.LockSnapshotResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SnapshotId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Lock-EC2Snapshot (LockSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.LockSnapshotResponse, LockEC2SnapshotCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CoolOffPeriod = this.CoolOffPeriod;
            context.DryRun = this.DryRun;
            context.ExpirationDate = this.ExpirationDate;
            context.LockDuration = this.LockDuration;
            context.LockMode = this.LockMode;
            #if MODULAR
            if (this.LockMode == null && ParameterWasBound(nameof(this.LockMode)))
            {
                WriteWarning("You are passing $null as a value for parameter LockMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotId = this.SnapshotId;
            #if MODULAR
            if (this.SnapshotId == null && ParameterWasBound(nameof(this.SnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.LockSnapshotRequest();
            
            if (cmdletContext.CoolOffPeriod != null)
            {
                request.CoolOffPeriod = cmdletContext.CoolOffPeriod.Value;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.ExpirationDate != null)
            {
                request.ExpirationDate = cmdletContext.ExpirationDate.Value;
            }
            if (cmdletContext.LockDuration != null)
            {
                request.LockDuration = cmdletContext.LockDuration.Value;
            }
            if (cmdletContext.LockMode != null)
            {
                request.LockMode = cmdletContext.LockMode;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
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
        
        private Amazon.EC2.Model.LockSnapshotResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.LockSnapshotRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "LockSnapshot");
            try
            {
                return client.LockSnapshotAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? CoolOffPeriod { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.DateTime? ExpirationDate { get; set; }
            public System.Int32? LockDuration { get; set; }
            public Amazon.EC2.LockMode LockMode { get; set; }
            public System.String SnapshotId { get; set; }
            public System.Func<Amazon.EC2.Model.LockSnapshotResponse, LockEC2SnapshotCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
