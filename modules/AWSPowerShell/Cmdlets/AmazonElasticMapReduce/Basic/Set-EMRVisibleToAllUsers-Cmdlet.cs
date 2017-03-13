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
using Amazon.ElasticMapReduce;
using Amazon.ElasticMapReduce.Model;

namespace Amazon.PowerShell.Cmdlets.EMR
{
    /// <summary>
    /// Sets whether all AWS Identity and Access Management (IAM) users under your account
    /// can access the specified clusters (job flows). This action works on running clusters.
    /// You can also set the visibility of a cluster when you launch it using the <code>VisibleToAllUsers</code>
    /// parameter of <a>RunJobFlow</a>. The SetVisibleToAllUsers action can be called only
    /// by an IAM user who created the cluster or the AWS account that owns the cluster.
    /// </summary>
    [Cmdlet("Set", "EMRVisibleToAllUsers", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the SetVisibleToAllUsers operation against Amazon Elastic MapReduce.", Operation = new[] {"SetVisibleToAllUsers"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the JobFlowId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetEMRVisibleToAllUsersCmdlet : AmazonElasticMapReduceClientCmdlet, IExecutor
    {
        
        #region Parameter JobFlowId
        /// <summary>
        /// <para>
        /// <para>Identifiers of the job flows to receive the new visibility setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("JobFlowIds")]
        public System.String[] JobFlowId { get; set; }
        #endregion
        
        #region Parameter VisibleToAllUser
        /// <summary>
        /// <para>
        /// <para>Whether the specified clusters are visible to all IAM users of the AWS account associated
        /// with the cluster. If this value is set to True, all IAM users of that AWS account
        /// can view and, if they have the proper IAM policy permissions set, manage the clusters.
        /// If it is set to False, only the IAM user that created a cluster can view and manage
        /// it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        [Alias("VisibleToAllUsers")]
        public System.Boolean VisibleToAllUser { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the JobFlowId parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("JobFlowId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-EMRVisibleToAllUsers (SetVisibleToAllUsers)"))
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
            
            if (this.JobFlowId != null)
            {
                context.JobFlowIds = new List<System.String>(this.JobFlowId);
            }
            if (ParameterWasBound("VisibleToAllUser"))
                context.VisibleToAllUsers = this.VisibleToAllUser;
            
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
            var request = new Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersRequest();
            
            if (cmdletContext.JobFlowIds != null)
            {
                request.JobFlowIds = cmdletContext.JobFlowIds;
            }
            if (cmdletContext.VisibleToAllUsers != null)
            {
                request.VisibleToAllUsers = cmdletContext.VisibleToAllUsers.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.JobFlowId;
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
        
        private static Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersResponse CallAWSServiceOperation(IAmazonElasticMapReduce client, Amazon.ElasticMapReduce.Model.SetVisibleToAllUsersRequest request)
        {
            #if DESKTOP
            return client.SetVisibleToAllUsers(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.SetVisibleToAllUsersAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> JobFlowIds { get; set; }
            public System.Boolean? VisibleToAllUsers { get; set; }
        }
        
    }
}
