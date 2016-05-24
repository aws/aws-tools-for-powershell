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
    /// Returns a list of DB cluster snapshot attribute names and values for a manual DB cluster
    /// snapshot.
    /// 
    ///  
    /// <para>
    /// When sharing snapshots with other AWS accounts, <code>DescribeDBClusterSnapshotAttributes</code>
    /// returns the <code>restore</code> attribute and a list of IDs for the AWS accounts
    /// that are authorized to copy or restore the manual DB cluster snapshot. If <code>all</code>
    /// is included in the list of values for the <code>restore</code> attribute, then the
    /// manual DB cluster snapshot is public and can be copied or restored by all AWS accounts.
    /// </para><para>
    /// To add or remove access for an AWS account to copy or restore a manual DB cluster
    /// snapshot, or to make the manual DB cluster snapshot public or private, use the <a>ModifyDBClusterSnapshotAttribute</a>
    /// API action.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "RDSDBClusterSnapshotAttribute")]
    [OutputType("Amazon.RDS.Model.DBClusterSnapshotAttributesResult")]
    [AWSCmdlet("Invokes the DescribeDBClusterSnapshotAttributes operation against Amazon Relational Database Service.", Operation = new[] {"DescribeDBClusterSnapshotAttributes"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterSnapshotAttributesResult",
        "This cmdlet returns a DBClusterSnapshotAttributesResult object.",
        "The service call response (type Amazon.RDS.Model.DescribeDBClusterSnapshotAttributesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class GetRDSDBClusterSnapshotAttributeCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter DBClusterSnapshotIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for the DB cluster snapshot to describe the attributes for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterSnapshotIdentifier { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DBClusterSnapshotIdentifier = this.DBClusterSnapshotIdentifier;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.DescribeDBClusterSnapshotAttributesRequest();
            
            if (cmdletContext.DBClusterSnapshotIdentifier != null)
            {
                request.DBClusterSnapshotIdentifier = cmdletContext.DBClusterSnapshotIdentifier;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.DescribeDBClusterSnapshotAttributes(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBClusterSnapshotAttributesResult;
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
            public System.String DBClusterSnapshotIdentifier { get; set; }
        }
        
    }
}
