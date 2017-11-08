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
    /// Creates a new Amazon Redshift subnet group. You must provide a list of one or more
    /// subnets in your existing Amazon Virtual Private Cloud (Amazon VPC) when creating Amazon
    /// Redshift subnet group.
    /// 
    ///  
    /// <para>
    ///  For information about subnet groups, go to <a href="http://docs.aws.amazon.com/redshift/latest/mgmt/working-with-cluster-subnet-groups.html">Amazon
    /// Redshift Cluster Subnet Groups</a> in the <i>Amazon Redshift Cluster Management Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "RSClusterSubnetGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.ClusterSubnetGroup")]
    [AWSCmdlet("Calls the Amazon Redshift CreateClusterSubnetGroup API operation.", Operation = new[] {"CreateClusterSubnetGroup"})]
    [AWSCmdletOutput("Amazon.Redshift.Model.ClusterSubnetGroup",
        "This cmdlet returns a ClusterSubnetGroup object.",
        "The service call response (type Amazon.Redshift.Model.CreateClusterSubnetGroupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewRSClusterSubnetGroupCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter ClusterSubnetGroupName
        /// <summary>
        /// <para>
        /// <para>The name for the subnet group. Amazon Redshift stores the value as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must contain no more than 255 alphanumeric characters or hyphens.</para></li><li><para>Must not be "Default".</para></li><li><para>Must be unique for all subnet groups that are created by your AWS account.</para></li></ul><para>Example: <code>examplesubnetgroup</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterSubnetGroupName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the subnet group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SubnetId
        /// <summary>
        /// <para>
        /// <para>An array of VPC subnet IDs. A maximum of 20 subnets can be modified in a single request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        [Alias("SubnetIds")]
        public System.String[] SubnetId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of tag instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.Redshift.Model.Tag[] Tag { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterSubnetGroupName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSClusterSubnetGroup (CreateClusterSubnetGroup)"))
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
            
            context.ClusterSubnetGroupName = this.ClusterSubnetGroupName;
            context.Description = this.Description;
            if (this.SubnetId != null)
            {
                context.SubnetIds = new List<System.String>(this.SubnetId);
            }
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.Redshift.Model.Tag>(this.Tag);
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
            var request = new Amazon.Redshift.Model.CreateClusterSubnetGroupRequest();
            
            if (cmdletContext.ClusterSubnetGroupName != null)
            {
                request.ClusterSubnetGroupName = cmdletContext.ClusterSubnetGroupName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.SubnetIds != null)
            {
                request.SubnetIds = cmdletContext.SubnetIds;
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
                object pipelineOutput = response.ClusterSubnetGroup;
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
        
        private Amazon.Redshift.Model.CreateClusterSubnetGroupResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateClusterSubnetGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateClusterSubnetGroup");
            try
            {
                #if DESKTOP
                return client.CreateClusterSubnetGroup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateClusterSubnetGroupAsync(request);
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
            public System.String ClusterSubnetGroupName { get; set; }
            public System.String Description { get; set; }
            public List<System.String> SubnetIds { get; set; }
            public List<Amazon.Redshift.Model.Tag> Tags { get; set; }
        }
        
    }
}
