/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Backtracks a DB cluster to a specific time, without creating a new DB cluster.
    /// 
    ///  
    /// <para>
    /// For more information on backtracking, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/AuroraUserGuide/AuroraMySQL.Managing.Backtrack.html">
    /// Backtracking an Aurora DB Cluster</a> in the <i>Amazon Aurora User Guide.</i></para>
    /// </summary>
    [Cmdlet("Reset", "RDSDBCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.BacktrackDBClusterResponse")]
    [AWSCmdlet("Calls the Amazon Relational Database Service BacktrackDBCluster API operation.", Operation = new[] {"BacktrackDBCluster"})]
    [AWSCmdletOutput("Amazon.RDS.Model.BacktrackDBClusterResponse",
        "This cmdlet returns a Amazon.RDS.Model.BacktrackDBClusterResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ResetRDSDBClusterCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter BacktrackTo
        /// <summary>
        /// <para>
        /// <para>The timestamp of the time to backtrack the DB cluster to, specified in ISO 8601 format.
        /// For more information about ISO 8601, see the <a href="http://en.wikipedia.org/wiki/ISO_8601">ISO8601
        /// Wikipedia page.</a></para><note><para>If the specified time is not a consistent time for the DB cluster, Aurora automatically
        /// chooses the nearest possible consistent time for the DB cluster.</para></note><para>Constraints:</para><ul><li><para>Must contain a valid ISO 8601 timestamp.</para></li><li><para>Cannot contain a timestamp set in the future.</para></li></ul><para>Example: <code>2017-07-08T18:00Z</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime BacktrackTo { get; set; }
        #endregion
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB cluster identifier of the DB cluster to be backtracked. This parameter is stored
        /// as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul><para>Example: <code>my-cluster1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter EnforceReset
        /// <summary>
        /// <para>
        /// <para>A value that, if specified, forces the DB cluster to backtrack when binary logging
        /// is enabled. Otherwise, an error occurs when binary logging is enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnforceReset { get; set; }
        #endregion
        
        #region Parameter UseEarliestTimeOnPointInTimeUnavailable
        /// <summary>
        /// <para>
        /// <para>If <i>BacktrackTo</i> is set to a timestamp earlier than the earliest backtrack time,
        /// this value backtracks the DB cluster to the earliest possible backtrack time. Otherwise,
        /// an error occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UseEarliestTimeOnPointInTimeUnavailable { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-RDSDBCluster (BacktrackDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound("BacktrackTo"))
                context.BacktrackTo = this.BacktrackTo;
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            if (ParameterWasBound("EnforceReset"))
                context.EnforceReset = this.EnforceReset;
            if (ParameterWasBound("UseEarliestTimeOnPointInTimeUnavailable"))
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                #if DESKTOP
                return client.BacktrackDBCluster(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BacktrackDBClusterAsync(request);
                return task.Result;
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
            public System.DateTime? BacktrackTo { get; set; }
            public System.String DBClusterIdentifier { get; set; }
            public System.Boolean? EnforceReset { get; set; }
            public System.Boolean? UseEarliestTimeOnPointInTimeUnavailable { get; set; }
        }
        
    }
}
