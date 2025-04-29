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
using Amazon.RDS;
using Amazon.RDS.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Promotes the specified secondary DB cluster to be the primary DB cluster in the global
    /// database cluster to fail over or switch over a global database. Switchover operations
    /// were previously called "managed planned failovers."
    /// 
    ///  <note><para>
    /// Although this operation can be used either to fail over or to switch over a global
    /// database cluster, its intended use is for global database failover. To switch over
    /// a global database cluster, we recommend that you use the <a>SwitchoverGlobalCluster</a>
    /// operation instead.
    /// </para></note><para>
    /// How you use this operation depends on whether you are failing over or switching over
    /// your global database cluster:
    /// </para><ul><li><para>
    /// Failing over - Specify the <c>AllowDataLoss</c> parameter and don't specify the <c>Switchover</c>
    /// parameter.
    /// </para></li><li><para>
    /// Switching over - Specify the <c>Switchover</c> parameter or omit it, but don't specify
    /// the <c>AllowDataLoss</c> parameter.
    /// </para></li></ul><para><b>About failing over and switching over</b></para><para>
    /// While failing over and switching over a global database cluster both change the primary
    /// DB cluster, you use these operations for different reasons:
    /// </para><ul><li><para><i>Failing over</i> - Use this operation to respond to an unplanned event, such as
    /// a Regional disaster in the primary Region. Failing over can result in a loss of write
    /// transaction data that wasn't replicated to the chosen secondary before the failover
    /// event occurred. However, the recovery process that promotes a DB instance on the chosen
    /// seconday DB cluster to be the primary writer DB instance guarantees that the data
    /// is in a transactionally consistent state.
    /// </para><para>
    /// For more information about failing over an Amazon Aurora global database, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-global-database-disaster-recovery.html#aurora-global-database-failover.managed-unplanned">Performing
    /// managed failovers for Aurora global databases</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para></li><li><para><i>Switching over</i> - Use this operation on a healthy global database cluster for
    /// planned events, such as Regional rotation or to fail back to the original primary
    /// DB cluster after a failover operation. With this operation, there is no data loss.
    /// </para><para>
    /// For more information about switching over an Amazon Aurora global database, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-global-database-disaster-recovery.html#aurora-global-database-disaster-recovery.managed-failover">Performing
    /// switchovers for Aurora global databases</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Start", "RDSFailoverGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service FailoverGlobalCluster API operation.", Operation = new[] {"FailoverGlobalCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.FailoverGlobalClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.GlobalCluster or Amazon.RDS.Model.FailoverGlobalClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.GlobalCluster object.",
        "The service call response (type Amazon.RDS.Model.FailoverGlobalClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartRDSFailoverGlobalClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowDataLoss
        /// <summary>
        /// <para>
        /// <para>Specifies whether to allow data loss for this global database cluster operation. Allowing
        /// data loss triggers a global failover operation.</para><para>If you don't specify <c>AllowDataLoss</c>, the global database cluster operation defaults
        /// to a switchover.</para><para>Constraints:</para><ul><li><para>Can't be specified together with the <c>Switchover</c> parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowDataLoss { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the global database cluster (Aurora global database) this operation
        /// should apply to. The identifier is the unique key assigned by the user when the Aurora
        /// global database is created. In other words, it's the name of the Aurora global database.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing global database cluster.</para></li></ul>
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
        public System.String GlobalClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Switchover
        /// <summary>
        /// <para>
        /// <para>Specifies whether to switch over this global database cluster.</para><para>Constraints:</para><ul><li><para>Can't be specified together with the <c>AllowDataLoss</c> parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Switchover { get; set; }
        #endregion
        
        #region Parameter TargetDbClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the secondary Aurora DB cluster that you want to promote to the
        /// primary for the global database cluster. Use the Amazon Resource Name (ARN) for the
        /// identifier so that Aurora can locate the cluster in its Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TargetDbClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'GlobalCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.FailoverGlobalClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.FailoverGlobalClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "GlobalCluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-RDSFailoverGlobalCluster (FailoverGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.FailoverGlobalClusterResponse, StartRDSFailoverGlobalClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowDataLoss = this.AllowDataLoss;
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            #if MODULAR
            if (this.GlobalClusterIdentifier == null && ParameterWasBound(nameof(this.GlobalClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Switchover = this.Switchover;
            context.TargetDbClusterIdentifier = this.TargetDbClusterIdentifier;
            #if MODULAR
            if (this.TargetDbClusterIdentifier == null && ParameterWasBound(nameof(this.TargetDbClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetDbClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.FailoverGlobalClusterRequest();
            
            if (cmdletContext.AllowDataLoss != null)
            {
                request.AllowDataLoss = cmdletContext.AllowDataLoss.Value;
            }
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
            }
            if (cmdletContext.Switchover != null)
            {
                request.Switchover = cmdletContext.Switchover.Value;
            }
            if (cmdletContext.TargetDbClusterIdentifier != null)
            {
                request.TargetDbClusterIdentifier = cmdletContext.TargetDbClusterIdentifier;
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
        
        private Amazon.RDS.Model.FailoverGlobalClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.FailoverGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "FailoverGlobalCluster");
            try
            {
                return client.FailoverGlobalClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AllowDataLoss { get; set; }
            public System.String GlobalClusterIdentifier { get; set; }
            public System.Boolean? Switchover { get; set; }
            public System.String TargetDbClusterIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.FailoverGlobalClusterResponse, StartRDSFailoverGlobalClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalCluster;
        }
        
    }
}
