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

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Backtracks a DB cluster to a specific time, without creating a new DB cluster.
    /// 
    ///  
    /// <para>
    /// For more information on backtracking, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/AuroraMySQL.Managing.Backtrack.html">
    /// Backtracking an Aurora DB Cluster</a> in the <i>Amazon Aurora User Guide</i>.
    /// </para><note><para>
    /// This action applies only to Aurora MySQL DB clusters.
    /// </para></note>
    /// </summary>
    [Cmdlet("Reset", "RDSDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.BacktrackDBClusterResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service BacktrackDBCluster API operation.", Operation = new[] {"BacktrackDBCluster"}, SelectReturnType = typeof(Amazon.RDS.Model.BacktrackDBClusterResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.BacktrackDBClusterResponse",
        "This cmdlet returns an Amazon.RDS.Model.BacktrackDBClusterResponse object containing multiple properties."
    )]
    public partial class ResetRDSDBClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BacktrackTo
        /// <summary>
        /// <para>
        /// <para>The timestamp of the time to backtrack the DB cluster to, specified in ISO 8601 format.
        /// For more information about ISO 8601, see the <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO8601
        /// Wikipedia page.</a></para><note><para>If the specified time isn't a consistent time for the DB cluster, Aurora automatically
        /// chooses the nearest possible consistent time for the DB cluster.</para></note><para>Constraints:</para><ul><li><para>Must contain a valid ISO 8601 timestamp.</para></li><li><para>Can't contain a timestamp set in the future.</para></li></ul><para>Example: <c>2017-07-08T18:00Z</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? BacktrackTo { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier of the DB cluster to be backtracked. This parameter is stored
        /// as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Can't end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <c>my-cluster1</c></para>
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
        
        #region Parameter EnforceReset
        /// <summary>
        /// <para>
        /// <para>Specifies whether to force the DB cluster to backtrack when binary logging is enabled.
        /// Otherwise, an error occurs when binary logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnforceReset { get; set; }
        #endregion
        
        #region Parameter UseEarliestTimeOnPointInTimeUnavailable
        /// <summary>
        /// <para>
        /// <para>Specifies whether to backtrack the DB cluster to the earliest possible backtrack time
        /// when <i>BacktrackTo</i> is set to a timestamp earlier than the earliest backtrack
        /// time. When this parameter is disabled and <i>BacktrackTo</i> is set to a timestamp
        /// earlier than the earliest backtrack time, an error occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? UseEarliestTimeOnPointInTimeUnavailable { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.BacktrackDBClusterResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.BacktrackDBClusterResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBClusterIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-RDSDBCluster (BacktrackDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.BacktrackDBClusterResponse, ResetRDSDBClusterCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BacktrackTo = this.BacktrackTo;
            #if MODULAR
            if (this.BacktrackTo == null && ParameterWasBound(nameof(this.BacktrackTo)))
            {
                WriteWarning("You are passing $null as a value for parameter BacktrackTo which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            #if MODULAR
            if (this.DBClusterIdentifier == null && ParameterWasBound(nameof(this.DBClusterIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBClusterIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EnforceReset = this.EnforceReset;
            context.UseEarliestTimeOnPointInTimeUnavailable = this.UseEarliestTimeOnPointInTimeUnavailable;
            
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
            var request = new Amazon.RDS.Model.BacktrackDBClusterRequest();
            
            if (cmdletContext.BacktrackTo != null)
            {
                request.BacktrackTo = cmdletContext.BacktrackTo.Value;
            }
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.EnforceReset != null)
            {
                request.Force = cmdletContext.EnforceReset.Value;
            }
            if (cmdletContext.UseEarliestTimeOnPointInTimeUnavailable != null)
            {
                request.UseEarliestTimeOnPointInTimeUnavailable = cmdletContext.UseEarliestTimeOnPointInTimeUnavailable.Value;
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
        
        private Amazon.RDS.Model.BacktrackDBClusterResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.BacktrackDBClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "BacktrackDBCluster");
            try
            {
                return client.BacktrackDBClusterAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? BacktrackTo { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.Boolean? EnforceReset { get; set; }
            public System.Boolean? UseEarliestTimeOnPointInTimeUnavailable { get; set; }
            public System.Func<Amazon.RDS.Model.BacktrackDBClusterResponse, ResetRDSDBClusterCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
