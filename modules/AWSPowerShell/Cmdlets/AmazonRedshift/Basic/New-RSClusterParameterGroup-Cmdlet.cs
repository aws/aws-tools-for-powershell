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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates an Amazon Redshift parameter group. 
    /// 
    ///  
    /// <para>
    /// Creating parameter groups is independent of creating clusters. You can associate a
    /// cluster with a parameter group when you create the cluster. You can also associate
    /// an existing cluster with a parameter group after the cluster is created by using <a>ModifyCluster</a>.
    /// 
    /// </para><para>
    ///  Parameters in the parameter group define specific behavior that applies to the databases
    /// you create on the cluster. For more information about managing parameter groups, go
    /// to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-parameter-groups.html">Amazon
    /// Redshift Parameter Groups</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// 
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSClusterParameterGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ClusterParameterGroup")]
    [AWSCmdlet("Invokes the CreateClusterParameterGroup operation against Amazon Redshift.", Operation = new[] {"CreateClusterParameterGroup"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.ClusterParameterGroup",
        "This cmdlet returns a ClusterParameterGroup object.",
        "The service call response (type CreateClusterParameterGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewRSClusterParameterGroupCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para> A description of the parameter group. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public String Description { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The Amazon Redshift engine version to which the cluster parameter group applies.
        /// The cluster engine version determines the set of parameters. </para><para>To get a list of valid parameter group family names, you can call <a>DescribeClusterParameterGroups</a>.
        /// By default, Amazon Redshift returns a list of all the parameter groups that are owned
        /// by your AWS account, including the default parameter groups for each Amazon Redshift
        /// engine version. The parameter group family names associated with the default parameter
        /// groups provide you the valid values. For example, a valid family name is "redshift-1.0".
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public String ParameterGroupFamily { get; set; }
        
        /// <summary>
        /// <para>
        /// <para> The name of the cluster parameter group. </para><para> Constraints: </para><ul><li>Must be 1 to 255 alphanumeric characters or hyphens</li><li>First character
        /// must be a letter.</li><li>Cannot end with a hyphen or contain two consecutive hyphens.</li><li>Must be unique withing your AWS account.</li></ul><note>This value is stored
        /// as a lower-case string.</note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public String ParameterGroupName { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
        
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ParameterGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSClusterParameterGroup (CreateClusterParameterGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.Description = this.Description;
            context.ParameterGroupFamily = this.ParameterGroupFamily;
            context.ParameterGroupName = this.ParameterGroupName;
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
            var request = new CreateClusterParameterGroupRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ParameterGroupFamily != null)
            {
                request.ParameterGroupFamily = cmdletContext.ParameterGroupFamily;
            }
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
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
                var response = client.CreateClusterParameterGroup(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ClusterParameterGroup;
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
            public String Description { get; set; }
            public String ParameterGroupFamily { get; set; }
            public String ParameterGroupName { get; set; }
            public List<Tag> Tags { get; set; }
        }
        
    }
}
