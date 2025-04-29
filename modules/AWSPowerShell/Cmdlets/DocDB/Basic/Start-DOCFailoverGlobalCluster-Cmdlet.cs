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
using Amazon.DocDB;
using Amazon.DocDB.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DOC
{
    /// <summary>
    /// Promotes the specified secondary DB cluster to be the primary DB cluster in the global
    /// cluster when failing over a global cluster occurs.
    /// 
    ///  
    /// <para>
    /// Use this operation to respond to an unplanned event, such as a regional disaster in
    /// the primary region. Failing over can result in a loss of write transaction data that
    /// wasn't replicated to the chosen secondary before the failover event occurred. However,
    /// the recovery process that promotes a DB instance on the chosen seconday DB cluster
    /// to be the primary writer DB instance guarantees that the data is in a transactionally
    /// consistent state.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "DOCFailoverGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DocDB.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon DocumentDB (with MongoDB compatibility) FailoverGlobalCluster API operation.", Operation = new[] {"FailoverGlobalCluster"}, SelectReturnType = typeof(Amazon.DocDB.Model.FailoverGlobalClusterResponse))]
    [AWSCmdletOutput("Amazon.DocDB.Model.GlobalCluster or Amazon.DocDB.Model.FailoverGlobalClusterResponse",
        "This cmdlet returns an Amazon.DocDB.Model.GlobalCluster object.",
        "The service call response (type Amazon.DocDB.Model.FailoverGlobalClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDOCFailoverGlobalClusterCmdlet : AmazonDocDBClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowDataLoss
        /// <summary>
        /// <para>
        /// <para>Specifies whether to allow data loss for this global cluster operation. Allowing data
        /// loss triggers a global failover operation.</para><para>If you don't specify <c>AllowDataLoss</c>, the global cluster operation defaults to
        /// a switchover.</para><para>Constraints:</para><ul><li><para>Can't be specified together with the <c>Switchover</c> parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowDataLoss { get; set; }
        #endregion
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon DocumentDB global cluster to apply this operation. The
        /// identifier is the unique key assigned by the user when the cluster is created. In
        /// other words, it's the name of the global cluster.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing global cluster.</para></li><li><para>Minimum length of 1. Maximum length of 255.</para></li></ul><para>Pattern: <c>[A-Za-z][0-9A-Za-z-:._]*</c></para>
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
        /// <para>The identifier of the secondary Amazon DocumentDB cluster that you want to promote
        /// to the primary for the global cluster. Use the Amazon Resource Name (ARN) for the
        /// identifier so that Amazon DocumentDB can locate the cluster in its Amazon Web Services
        /// region.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing secondary cluster.</para></li><li><para>Minimum length of 1. Maximum length of 255.</para></li></ul><para>Pattern: <c>[A-Za-z][0-9A-Za-z-:._]*</c></para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DocDB.Model.FailoverGlobalClusterResponse).
        /// Specifying the name of a property of type Amazon.DocDB.Model.FailoverGlobalClusterResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DOCFailoverGlobalCluster (FailoverGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DocDB.Model.FailoverGlobalClusterResponse, StartDOCFailoverGlobalClusterCmdlet>(Select) ??
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
            var request = new Amazon.DocDB.Model.FailoverGlobalClusterRequest();
            
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
        
        private Amazon.DocDB.Model.FailoverGlobalClusterResponse CallAWSServiceOperation(IAmazonDocDB client, Amazon.DocDB.Model.FailoverGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DocumentDB (with MongoDB compatibility)", "FailoverGlobalCluster");
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
            public System.Func<Amazon.DocDB.Model.FailoverGlobalClusterResponse, StartDOCFailoverGlobalClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalCluster;
        }
        
    }
}
