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
    /// Switches over the specified secondary DB cluster to be the new primary DB cluster
    /// in the global database cluster. Switchover operations were previously called "managed
    /// planned failovers."
    /// 
    ///  
    /// <para>
    /// Aurora promotes the specified secondary cluster to assume full read/write capabilities
    /// and demotes the current primary cluster to a secondary (read-only) cluster, maintaining
    /// the orginal replication topology. All secondary clusters are synchronized with the
    /// primary at the beginning of the process so the new primary continues operations for
    /// the Aurora global database without losing any data. Your database is unavailable for
    /// a short time while the primary and selected secondary clusters are assuming their
    /// new roles. For more information about switching over an Aurora global database, see
    /// <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/aurora-global-database-disaster-recovery.html#aurora-global-database-disaster-recovery.managed-failover">Performing
    /// switchovers for Amazon Aurora global databases</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><note><para>
    /// This operation is intended for controlled environments, for operations such as "regional
    /// rotation" or to fall back to the original primary after a global database failover.
    /// </para></note>
    /// </summary>
    [Cmdlet("Request", "RDSSwitchoverGlobalCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.GlobalCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service SwitchoverGlobalCluster API operation.", Operation = new[] {"SwitchoverGlobalCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.SwitchoverGlobalClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.GlobalCluster or Amazon.RDS.Model.SwitchoverGlobalClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.GlobalCluster object.",
        "The service call response (type Amazon.RDS.Model.SwitchoverGlobalClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RequestRDSSwitchoverGlobalClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter GlobalClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the global database cluster to switch over. This parameter isn't
        /// case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing global database cluster (Aurora global database).</para></li></ul>
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
        
        #region Parameter TargetDbClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the secondary Aurora DB cluster to promote to the new primary for
        /// the global database cluster. Use the Amazon Resource Name (ARN) for the identifier
        /// so that Aurora can locate the cluster in its Amazon Web Services Region.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.SwitchoverGlobalClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.SwitchoverGlobalClusterResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-RDSSwitchoverGlobalCluster (SwitchoverGlobalCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.SwitchoverGlobalClusterResponse, RequestRDSSwitchoverGlobalClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.GlobalClusterIdentifier = this.GlobalClusterIdentifier;
            #if MODULAR
            if (this.GlobalClusterIdentifier == null && ParameterWasBound(nameof(this.GlobalClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.RDS.Model.SwitchoverGlobalClusterRequest();
            
            if (cmdletContext.GlobalClusterIdentifier != null)
            {
                request.GlobalClusterIdentifier = cmdletContext.GlobalClusterIdentifier;
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
        
        private Amazon.RDS.Model.SwitchoverGlobalClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.SwitchoverGlobalClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "SwitchoverGlobalCluster");
            try
            {
                return client.SwitchoverGlobalClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String GlobalClusterIdentifier { get; set; }
            public System.String TargetDbClusterIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.SwitchoverGlobalClusterResponse, RequestRDSSwitchoverGlobalClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.GlobalCluster;
        }
        
    }
}
