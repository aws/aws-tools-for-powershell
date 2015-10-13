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
    /// Creates a new DB cluster parameter group. 
    /// 
    ///  
    /// <para>
    ///  Parameters in a DB cluster parameter group apply to all of the instances in a DB
    /// cluster. 
    /// </para><para>
    ///  A DB cluster parameter group is initially created with the default parameters for
    /// the database engine used by instances in the DB cluster. To provide custom values
    /// for any of the parameters, you must modify the group after creating it using <a>ModifyDBClusterParameterGroup</a>.
    /// Once you've created a DB cluster parameter group, you need to associate it with your
    /// DB cluster using <a>ModifyDBCluster</a>. When you associate a new DB cluster parameter
    /// group with a running DB cluster, you need to reboot the DB instances in the DB cluster
    /// without failover for the new DB cluster parameter group and associated settings to
    /// take effect. 
    /// </para><important><para>
    /// After you create a DB cluster parameter group, you should wait at least 5 minutes
    /// before creating your first DB cluster that uses that DB cluster parameter group as
    /// the default parameter group. This allows Amazon RDS to fully complete the create action
    /// before the DB cluster parameter group is used as the default for a new DB cluster.
    /// This is especially important for parameters that are critical when creating the default
    /// database for a DB cluster, such as the character set for the default database defined
    /// by the <code>character_set_database</code> parameter. You can use the <i>Parameter
    /// Groups</i> option of the <a href="https://console.aws.amazon.com/rds/">Amazon RDS
    /// console</a> or the <a>DescribeDBClusterParameters</a> command to verify that your
    /// DB cluster parameter group has been created or modified.
    /// </para></important><para>
    /// For more information on Amazon Aurora, see <a href="http://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/CHAP_Aurora.html">Aurora
    /// on Amazon RDS</a> in the <i>Amazon RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("New", "RDSDBClusterParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBClusterParameterGroup")]
    [AWSCmdlet("Invokes the CreateDBClusterParameterGroup operation against Amazon Relational Database Service.", Operation = new[] {"CreateDBClusterParameterGroup"})]
    [AWSCmdletOutput("Amazon.RDS.Model.DBClusterParameterGroup",
        "This cmdlet returns a DBClusterParameterGroup object.",
        "The service call response (type Amazon.RDS.Model.CreateDBClusterParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewRDSDBClusterParameterGroupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> The name of the DB cluster parameter group. </para><para> Constraints: </para><ul><li>Must be 1 to 255 alphanumeric characters</li><li>First character must be
        /// a letter</li><li>Cannot end with a hyphen or contain two consecutive hyphens</li></ul><note>This value is stored as a lowercase string.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DBClusterParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The DB cluster parameter group family name. A DB cluster parameter group can be associated
        /// with one and only one DB cluster parameter group family, and can be applied only to
        /// a DB cluster running a database engine and engine version compatible with that DB
        /// cluster parameter group family. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DBParameterGroupFamily { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The description for the DB cluster parameter group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// Documentation for this parameter is not currently available; please refer to the service API documentation.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("DBClusterParameterGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RDSDBClusterParameterGroup (CreateDBClusterParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.DBClusterParameterGroupName = this.DBClusterParameterGroupName;
            context.DBParameterGroupFamily = this.DBParameterGroupFamily;
            context.Description = this.Description;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.RDS.Model.Tag>(this.Tag);
            }
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.RDS.Model.CreateDBClusterParameterGroupRequest();
            
            if (cmdletContext.DBClusterParameterGroupName != null)
            {
                request.DBClusterParameterGroupName = cmdletContext.DBClusterParameterGroupName;
            }
            if (cmdletContext.DBParameterGroupFamily != null)
            {
                request.DBParameterGroupFamily = cmdletContext.DBParameterGroupFamily;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
                var response = client.CreateDBClusterParameterGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DBClusterParameterGroup;
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
            public System.String DBClusterParameterGroupName { get; set; }
            public System.String DBParameterGroupFamily { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.RDS.Model.Tag> Tags { get; set; }
        }
        
    }
}
