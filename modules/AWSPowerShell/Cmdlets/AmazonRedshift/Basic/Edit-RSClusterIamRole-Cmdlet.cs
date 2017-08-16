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
    /// Modifies the list of AWS Identity and Access Management (IAM) roles that can be used
    /// by the cluster to access other AWS services.
    /// 
    ///  
    /// <para>
    /// A cluster can have up to 10 IAM roles associated at any time.
    /// </para>
    /// </summary>
    [Cmdlet("Edit", "RSClusterIamRole", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.Cluster")]
    [AWSCmdlet("Invokes the ModifyClusterIamRoles operation against Amazon Redshift.", Operation = new[] {"ModifyClusterIamRoles"}, LegacyAlias="Edit-RSClusterIamRoles")]
    [AWSCmdletOutput("Amazon.Redshift.Model.Cluster",
        "This cmdlet returns a Cluster object.",
        "The service call response (type Amazon.Redshift.Model.ModifyClusterIamRolesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditRSClusterIamRoleCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        #region Parameter AddIamRole
        /// <summary>
        /// <para>
        /// <para>Zero or more IAM roles to associate with the cluster. The roles must be in their Amazon
        /// Resource Name (ARN) format. You can associate up to 10 IAM roles with a single cluster
        /// in a single request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("AddIamRoles")]
        public System.String[] AddIamRole { get; set; }
        #endregion
        
        #region Parameter ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the cluster for which you want to associate or disassociate
        /// IAM roles.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter RemoveIamRole
        /// <summary>
        /// <para>
        /// <para>Zero or more IAM roles in ARN format to disassociate from the cluster. You can disassociate
        /// up to 10 IAM roles from a single cluster in a single request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RemoveIamRoles")]
        public System.String[] RemoveIamRole { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ClusterIdentifier", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-RSClusterIamRole (ModifyClusterIamRoles)"))
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
            
            if (this.AddIamRole != null)
            {
                context.AddIamRoles = new List<System.String>(this.AddIamRole);
            }
            context.ClusterIdentifier = this.ClusterIdentifier;
            if (this.RemoveIamRole != null)
            {
                context.RemoveIamRoles = new List<System.String>(this.RemoveIamRole);
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
            var request = new Amazon.Redshift.Model.ModifyClusterIamRolesRequest();
            
            if (cmdletContext.AddIamRoles != null)
            {
                request.AddIamRoles = cmdletContext.AddIamRoles;
            }
            if (cmdletContext.ClusterIdentifier != null)
            {
                request.ClusterIdentifier = cmdletContext.ClusterIdentifier;
            }
            if (cmdletContext.RemoveIamRoles != null)
            {
                request.RemoveIamRoles = cmdletContext.RemoveIamRoles;
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
        
        private Amazon.Redshift.Model.ModifyClusterIamRolesResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.ModifyClusterIamRolesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "ModifyClusterIamRoles");
            try
            {
                #if DESKTOP
                return client.ModifyClusterIamRoles(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyClusterIamRolesAsync(request);
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
            public List<System.String> AddIamRoles { get; set; }
            public System.String ClusterIdentifier { get; set; }
            public List<System.String> RemoveIamRoles { get; set; }
        }
        
    }
}
