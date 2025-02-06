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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Forces a failover for a DB cluster.
    /// 
    ///  
    /// <para>
    /// For an Aurora DB cluster, failover for a DB cluster promotes one of the Aurora Replicas
    /// (read-only instances) in the DB cluster to be the primary DB instance (the cluster
    /// writer).
    /// </para><para>
    /// For a Multi-AZ DB cluster, after RDS terminates the primary DB instance, the internal
    /// monitoring system detects that the primary DB instance is unhealthy and promotes a
    /// readable standby (read-only instances) in the DB cluster to be the primary DB instance
    /// (the cluster writer). Failover times are typically less than 35 seconds.
    /// </para><para>
    /// An Amazon Aurora DB cluster automatically fails over to an Aurora Replica, if one
    /// exists, when the primary DB instance fails. A Multi-AZ DB cluster automatically fails
    /// over to a readable standby DB instance when the primary DB instance fails.
    /// </para><para>
    /// To simulate a failure of a primary instance for testing, you can force a failover.
    /// Because each instance in a DB cluster has its own endpoint address, make sure to clean
    /// up and re-establish any existing connections that use those endpoint addresses when
    /// the failover is complete.
    /// </para><para>
    /// For more information on Amazon Aurora DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/CHAP_AuroraOverview.html">
    /// What is Amazon Aurora?</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><para>
    /// For more information on Multi-AZ DB clusters, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/multi-az-db-clusters-concepts.html">
    /// Multi-AZ DB cluster deployments</a> in the <i>Amazon RDS User Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "RDSDBClusterFailover", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Calls the Amazon Relational Database Service FailoverDBCluster API operation.", Operation = new[] {"FailoverDBCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.FailoverDBClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster or Amazon.RDS.Model.FailoverDBClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBCluster object.",
        "The service call response (type Amazon.RDS.Model.FailoverDBClusterResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartRDSDBClusterFailoverCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB cluster to force a failover for. This parameter isn't case-sensitive.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing DB cluster.</para></li></ul>
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
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter TargetDBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The name of the DB instance to promote to the primary DB instance.</para><para>Specify the DB instance identifier for an Aurora Replica or a Multi-AZ readable standby
        /// in the DB cluster, for example <c>mydbcluster-replica1</c>.</para><para>This setting isn't supported for RDS for MySQL Multi-AZ DB clusters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TargetDBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBCluster'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.FailoverDBClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.FailoverDBClusterResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBCluster";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-RDSDBClusterFailover (FailoverDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.FailoverDBClusterResponse, StartRDSDBClusterFailoverCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            #if MODULAR
            if (this.DBClusterIdentifier == null && ParameterWasBound(nameof(this.DBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetDBInstanceIdentifier = this.TargetDBInstanceIdentifier;
            
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
            var request = new Amazon.RDS.Model.FailoverDBClusterRequest();
            
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.TargetDBInstanceIdentifier != null)
            {
                request.TargetDBInstanceIdentifier = cmdletContext.TargetDBInstanceIdentifier;
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
        
        private Amazon.RDS.Model.FailoverDBClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.FailoverDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "FailoverDBCluster");
            try
            {
                #if DESKTOP
                return client.FailoverDBCluster(request);
                #elif CORECLR
                return client.FailoverDBClusterAsync(request).GetAwaiter().GetResult();
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
            public System.String DBClusterIdentifier { get; set; }
            public System.String TargetDBInstanceIdentifier { get; set; }
            public System.Func<Amazon.RDS.Model.FailoverDBClusterResponse, StartRDSDBClusterFailoverCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBCluster;
        }
        
    }
}
