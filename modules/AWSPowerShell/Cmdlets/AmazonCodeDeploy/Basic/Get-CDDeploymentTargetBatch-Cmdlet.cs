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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Returns an array of targets associated with a deployment. This method works with
    /// all compute types and should be used instead of the deprecated <code>BatchGetDeploymentInstances</code>.
    /// 
    /// 
    ///  
    /// <para>
    ///  The type of targets returned depends on the deployment's compute platform: 
    /// </para><ul><li><para><b>EC2/On-premises</b>: Information about EC2 instance targets. 
    /// </para></li><li><para><b>AWS Lambda</b>: Information about Lambda functions targets. 
    /// </para></li><li><para><b>Amazon ECS</b>: Information about Amazon ECS service targets. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "CDDeploymentTargetBatch")]
    [OutputType("Amazon.CodeDeploy.Model.DeploymentTarget")]
    [AWSCmdlet("Calls the AWS CodeDeploy BatchGetDeploymentTargets API operation.", Operation = new[] {"BatchGetDeploymentTargets"})]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.DeploymentTarget",
        "This cmdlet returns a collection of DeploymentTarget objects.",
        "The service call response (type Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCDDeploymentTargetBatchCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para> The unique ID of a deployment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para> The unique IDs of the deployment targets. The compute platform of the deployment
        /// determines the type of the targets and their formats. </para><ul><li><para> For deployments that use the EC2/On-premises compute platform, the target IDs are
        /// EC2 or on-premises instances IDs, and their target type is <code>instanceTarget</code>.
        /// </para></li><li><para> For deployments that use the AWS Lambda compute platform, the target IDs are the
        /// names of Lambda functions, and their target type is <code>instanceTarget</code>. </para></li><li><para> For deployments that use the Amazon ECS compute platform, the target IDs are pairs
        /// of Amazon ECS clusters and services specified using the format <code>&lt;clustername&gt;:&lt;servicename&gt;</code>.
        /// Their target type is <code>ecsTarget</code>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TargetIds")]
        public System.String[] TargetId { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.DeploymentId = this.DeploymentId;
            if (this.TargetId != null)
            {
                context.TargetIds = new List<System.String>(this.TargetId);
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
            var request = new Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.TargetIds != null)
            {
                request.TargetIds = cmdletContext.TargetIds;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DeploymentTargets;
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
        
        private Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.BatchGetDeploymentTargetsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "BatchGetDeploymentTargets");
            try
            {
                #if DESKTOP
                return client.BatchGetDeploymentTargets(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.BatchGetDeploymentTargetsAsync(request);
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
            public System.String DeploymentId { get; set; }
            public List<System.String> TargetIds { get; set; }
        }
        
    }
}
