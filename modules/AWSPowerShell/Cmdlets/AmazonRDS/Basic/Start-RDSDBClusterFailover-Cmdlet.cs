/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// A failover for a DB cluster promotes one of the read-only instances in the DB cluster
    /// to the master DB instance (the cluster writer) and deletes the current primary instance.
    /// </para><para>
    /// Amazon Aurora will automatically fail over to a read-only instance, if one exists,
    /// when the primary instance fails. You can force a failover when you want to simulate
    /// a failure of a DB instance for testing. Because each instance in a DB cluster has
    /// its own endpoint address, you will need to clean up and re-establish any existing
    /// connections that use those endpoint addresses when the failover is complete.
    /// </para><para>
    /// For more information on Amazon Aurora, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Aurora.html">Aurora
    /// on Amazon RDS</a> in the <i>Amazon RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("Start", "RDSDBClusterFailover", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBCluster")]
    [AWSCmdlet("Invokes the FailoverDBCluster operation against Amazon Relational Database Service.", Operation = new[] {"FailoverDBCluster"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBCluster",
        "This cmdlet returns a DBCluster object.",
        "The service call response (type Amazon.RDS.Model.FailoverDBClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class StartRDSDBClusterFailoverCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>A DB cluster identifier to force a failover for. This parameter is not case-sensitive.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 63 alphanumeric characters or hyphens</para></li><li><para>First character must be a letter</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterIdentifier { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-RDSDBClusterFailover (FailoverDBCluster)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            
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
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.FailoverDBCluster(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBCluster;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String DBClusterIdentifier { get; set; }
        }
        
    }
}
