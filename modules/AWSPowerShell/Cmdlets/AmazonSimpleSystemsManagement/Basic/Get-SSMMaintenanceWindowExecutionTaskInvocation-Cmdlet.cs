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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Retrieves a task invocation. A task invocation is a specific task executing on a specific
    /// target. Maintenance Windows report status for all invocations.
    /// </summary>
    [Cmdlet("Get", "SSMMaintenanceWindowExecutionTaskInvocation")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse")]
    [AWSCmdlet("Invokes the GetMaintenanceWindowExecutionTaskInvocation operation against Amazon Simple Systems Management.", Operation = new[] {"GetMaintenanceWindowExecutionTaskInvocation"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse",
        "This cmdlet returns a Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetSSMMaintenanceWindowExecutionTaskInvocationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter InvocationId
        /// <summary>
        /// <para>
        /// <para>The invocation ID to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String InvocationId { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para>The ID of the specific task in the Maintenance Window task that should be retrieved.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TaskId { get; set; }
        #endregion
        
        #region Parameter WindowExecutionId
        /// <summary>
        /// <para>
        /// <para>The ID of the Maintenance Window execution for which the task is a part.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WindowExecutionId { get; set; }
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
            
            context.InvocationId = this.InvocationId;
            context.TaskId = this.TaskId;
            context.WindowExecutionId = this.WindowExecutionId;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationRequest();
            
            if (cmdletContext.InvocationId != null)
            {
                request.InvocationId = cmdletContext.InvocationId;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
            }
            if (cmdletContext.WindowExecutionId != null)
            {
                request.WindowExecutionId = cmdletContext.WindowExecutionId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetMaintenanceWindowExecutionTaskInvocationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Systems Management", "GetMaintenanceWindowExecutionTaskInvocation");
            try
            {
                #if DESKTOP
                return client.GetMaintenanceWindowExecutionTaskInvocation(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetMaintenanceWindowExecutionTaskInvocationAsync(request);
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
            public System.String InvocationId { get; set; }
            public System.String TaskId { get; set; }
            public System.String WindowExecutionId { get; set; }
        }
        
    }
}
