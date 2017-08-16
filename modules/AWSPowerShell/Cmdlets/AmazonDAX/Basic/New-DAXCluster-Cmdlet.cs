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
using Amazon.DAX;
using Amazon.DAX.Model;

namespace Amazon.PowerShell.Cmdlets.DAX
{
    /// <summary>
    /// Creates a DAX cluster. All nodes in the cluster run the same DAX caching software.
    /// </summary>
    [Cmdlet("New", "DAXCluster", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DAX.Model.Cluster")]
    [AWSCmdlet("Invokes the CreateCluster operation against Amazon DynamoDB Accelerator (DAX).", Operation = new[] {"CreateCluster"})]
    [AWSCmdletOutput("Amazon.DAX.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.DAX.Model.CreateClusterResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDAXClusterCmdlet : AmazonDAXClientCmdlet, IExecutor
    {
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The Availability Zones (AZs) in which the cluster nodes will be created. All nodes
        /// belonging to the cluster are placed in these Availability Zones. Use this parameter
        /// if you want to distribute the nodes across multiple AZs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AvailabilityZones")]
        public System.String[] AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter ClusterName
        /// <summary>
        /// <para>
        /// <para>The cluster identifier. This parameter is stored as a lowercase string.</para><para><b>Constraints:</b></para><ul><li><para>A name must contain from 1 to 20 alphanumeric characters or hyphens.</para></li><li><para>The first character must be a letter.</para></li><li><para>A name cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ClusterName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IamRoleArn
        /// <summary>
        /// <para>
        /// <para>A valid Amazon Resource Name (ARN) that identifies an IAM role. At runtime, DAX will
        /// assume this role and use the role's permissions to access DynamoDB on your behalf.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IamRoleArn { get; set; }
        #endregion
        
        #region Parameter NodeType
        /// <summary>
        /// <para>
        /// <para>The compute and memory capacity of the nodes in the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NodeType { get; set; }
        #endregion
        
        #region Parameter NotificationTopicArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon SNS topic to which notifications will
        /// be sent.</para><note><para>The Amazon SNS topic owner must be same as the DAX cluster owner.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationTopicArn { get; set; }
        #endregion
        
        #region Parameter ParameterGroupName
        /// <summary>
        /// <para>
        /// <para>The parameter group to be associated with the DAX cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ParameterGroupName { get; set; }
        #endregion
        
        #region Parameter PreferredMaintenanceWindow
        /// <summary>
        /// <para>
        /// <para>Specifies the weekly time range during which maintenance on the DAX cluster is performed.
        /// It is specified as a range in the format ddd:hh24:mi-ddd:hh24:mi (24H Clock UTC).
        /// The minimum maintenance window is a 60 minute period. Valid values for <code>ddd</code>
        /// are:</para><ul><li><para><code>sun</code></para></li><li><para><code>mon</code></para></li><li><para><code>tue</code></para></li><li><para><code>wed</code></para></li><li><para><code>thu</code></para></li><li><para><code>fri</code></para></li><li><para><code>sat</code></para></li></ul><para>Example: <code>sun:05:00-sun:09:00</code></para><note><para>If you don't specify a preferred maintenance window when you create or modify a cache
        /// cluster, DAX assigns a 60-minute maintenance window on a randomly selected day of
        /// the week.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String PreferredMaintenanceWindow { get; set; }
        #endregion
        
        #region Parameter ReplicationFactor
        /// <summary>
        /// <para>
        /// <para>The number of nodes in the DAX cluster. A replication factor of 1 will create a single-node
        /// cluster, without any read replicas. For additional fault tolerance, you can create
        /// a multiple node cluster with one or more read replicas. To do this, set <i>ReplicationFactor</i>
        /// to 2 or more.</para><note><para>AWS recommends that you have at least two read replicas per cluster.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 ReplicationFactor { get; set; }
        #endregion
        
        #region Parameter SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of security group IDs to be assigned to each node in the DAX cluster. (Each
        /// of the security group ID is system-generated.)</para><para>If this parameter is not specified, DAX assigns the default VPC security group to
        /// each node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("SecurityGroupIds")]
        public System.String[] SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter SubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the subnet group to be used for the replication group.</para><important><para>DAX clusters can only run in an Amazon VPC environment. All of the subnets that you
        /// specify in a subnet group must exist in the same VPC.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SubnetGroupName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags to associate with the DAX cluster. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DAX.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DAXCluster (CreateCluster)"))
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
            
            if (this.AvailabilityZone != null)
            {
                context.AvailabilityZones = new List<System.String>(this.AvailabilityZone);
            }
            context.ClusterName = this.ClusterName;
            context.Description = this.Description;
            context.IamRoleArn = this.IamRoleArn;
            context.NodeType = this.NodeType;
            context.NotificationTopicArn = this.NotificationTopicArn;
            context.ParameterGroupName = this.ParameterGroupName;
            context.PreferredMaintenanceWindow = this.PreferredMaintenanceWindow;
            if (ParameterWasBound("ReplicationFactor"))
                context.ReplicationFactor = this.ReplicationFactor;
            if (this.SecurityGroupId != null)
            {
                context.SecurityGroupIds = new List<System.String>(this.SecurityGroupId);
            }
            context.SubnetGroupName = this.SubnetGroupName;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DAX.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.DAX.Model.CreateClusterRequest();
            
            if (cmdletContext.AvailabilityZones != null)
            {
                request.AvailabilityZones = cmdletContext.AvailabilityZones;
            }
            if (cmdletContext.ClusterName != null)
            {
                request.ClusterName = cmdletContext.ClusterName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.IamRoleArn != null)
            {
                request.IamRoleArn = cmdletContext.IamRoleArn;
            }
            if (cmdletContext.NodeType != null)
            {
                request.NodeType = cmdletContext.NodeType;
            }
            if (cmdletContext.NotificationTopicArn != null)
            {
                request.NotificationTopicArn = cmdletContext.NotificationTopicArn;
            }
            if (cmdletContext.ParameterGroupName != null)
            {
                request.ParameterGroupName = cmdletContext.ParameterGroupName;
            }
            if (cmdletContext.PreferredMaintenanceWindow != null)
            {
                request.PreferredMaintenanceWindow = cmdletContext.PreferredMaintenanceWindow;
            }
            if (cmdletContext.ReplicationFactor != null)
            {
                request.ReplicationFactor = cmdletContext.ReplicationFactor.Value;
            }
            if (cmdletContext.SecurityGroupIds != null)
            {
                request.SecurityGroupIds = cmdletContext.SecurityGroupIds;
            }
            if (cmdletContext.SubnetGroupName != null)
            {
                request.SubnetGroupName = cmdletContext.SubnetGroupName;
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
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Cluster;
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
        
        private Amazon.DAX.Model.CreateClusterResponse CallAWSServiceOperation(IAmazonDAX client, Amazon.DAX.Model.CreateClusterRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB Accelerator (DAX)", "CreateCluster");
            try
            {
                #if DESKTOP
                return client.CreateCluster(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateClusterAsync(request);
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
            public List<System.String> AvailabilityZones { get; set; }
            public System.String ClusterName { get; set; }
            public System.String Description { get; set; }
            public System.String IamRoleArn { get; set; }
            public System.String NodeType { get; set; }
            public System.String NotificationTopicArn { get; set; }
            public System.String ParameterGroupName { get; set; }
            public System.String PreferredMaintenanceWindow { get; set; }
            public System.Int32? ReplicationFactor { get; set; }
            public List<System.String> SecurityGroupIds { get; set; }
            public System.String SubnetGroupName { get; set; }
            public List<Amazon.DAX.Model.Tag> Tags { get; set; }
        }
        
    }
}
