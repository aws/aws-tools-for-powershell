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
    /// Creates a snapshot of a DB cluster. For more information on Amazon Aurora, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Aurora.html">Aurora
    /// on Amazon RDS</a> in the <i>Amazon RDS User Guide.</i>
    /// </summary>
    [Cmdlet("New", "RDSDBClusterSnapshot", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBClusterSnapshot")]
    [AWSCmdlet("Invokes the CreateDBClusterSnapshot operation against Amazon Relational Database Service.", Operation = new[] {"CreateDBClusterSnapshot"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterSnapshot",
        "This cmdlet returns a DBClusterSnapshot object.",
        "The service call response (type CreateDBClusterSnapshotResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewRDSDBClusterSnapshotCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB cluster to create a snapshot for. This parameter is not case-sensitive.
        /// </para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens.</li><li>First
        /// character must be a letter.</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens.</li></ul><para>Example: <code>my-cluster1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public String DBClusterIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The identifier of the DB cluster snapshot. This parameter is stored as a lowercase
        /// string. </para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens.</li><li>First
        /// character must be a letter.</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens.</li></ul><para>Example: <code>my-cluster1-snapshot1</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public String DBClusterSnapshotIdentifier { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The tags to be assigned to the DB cluster snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.RDS.Model.Tag[] Tag { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBClusterSnapshot (CreateDBClusterSnapshot)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DBClusterIdentifier = this.DBClusterIdentifier;
            context.DBClusterSnapshotIdentifier = this.DBClusterSnapshotIdentifier;
            if (this.Tag != null)
            {
                context.Tags = new List<Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new CreateDBClusterSnapshotRequest();
            
            if (cmdletContext.DBClusterIdentifier != null)
            {
                request.DBClusterIdentifier = cmdletContext.DBClusterIdentifier;
            }
            if (cmdletContext.DBClusterSnapshotIdentifier != null)
            {
                request.DBClusterSnapshotIdentifier = cmdletContext.DBClusterSnapshotIdentifier;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateDBClusterSnapshot(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBClusterSnapshot;
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
            public String DBClusterIdentifier { get; set; }
            public String DBClusterSnapshotIdentifier { get; set; }
            public List<Tag> Tags { get; set; }
        }
        
    }
}
