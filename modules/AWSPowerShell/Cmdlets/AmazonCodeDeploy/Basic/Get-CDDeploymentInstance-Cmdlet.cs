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
using Amazon.CodeDeploy;
using Amazon.CodeDeploy.Model;

namespace Amazon.PowerShell.Cmdlets.CD
{
    /// <summary>
    /// Gets information about an instance as part of a deployment.
    /// </summary>
    [Cmdlet("Get", "CDDeploymentInstance")]
    [OutputType("Amazon.CodeDeploy.Model.InstanceSummary")]
    [AWSCmdlet("Calls the AWS CodeDeploy GetDeploymentInstance API operation.", Operation = new[] {"GetDeploymentInstance"})]
    [AWSCmdletOutput("Amazon.CodeDeploy.Model.InstanceSummary",
        "This cmdlet returns a InstanceSummary object.",
        "The service call response (type Amazon.CodeDeploy.Model.GetDeploymentInstanceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCDDeploymentInstanceCmdlet : AmazonCodeDeployClientCmdlet, IExecutor
    {
        
        #region Parameter DeploymentId
        /// <summary>
        /// <para>
        /// <para>The unique ID of a deployment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DeploymentId { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The unique ID of an instance in the deployment group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InstanceId { get; set; }
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
            context.InstanceId = this.InstanceId;
            
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
            var request = new Amazon.CodeDeploy.Model.GetDeploymentInstanceRequest();
            
            if (cmdletContext.DeploymentId != null)
            {
                request.DeploymentId = cmdletContext.DeploymentId;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.InstanceSummary;
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
        
        private Amazon.CodeDeploy.Model.GetDeploymentInstanceResponse CallAWSServiceOperation(IAmazonCodeDeploy client, Amazon.CodeDeploy.Model.GetDeploymentInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeDeploy", "GetDeploymentInstance");
            try
            {
                #if DESKTOP
                return client.GetDeploymentInstance(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetDeploymentInstanceAsync(request);
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
            public System.String InstanceId { get; set; }
        }
        
    }
}
