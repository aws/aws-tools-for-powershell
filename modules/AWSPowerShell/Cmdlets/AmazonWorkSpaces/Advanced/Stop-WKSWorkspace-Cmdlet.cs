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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Stops the specified WorkSpaces. You can specify the Workspaces using either the
    /// <code>-WorkspaceId</code> or <code>-Request</code> parameters.
    /// <para>
    /// To terminate WorkSpaces please update your script to use the <code>Remove-WKSWorkspace</code> cmdlet. 
    /// </para>
    /// </summary>
    [Cmdlet("Stop", "WKSWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName = RequestObjectParameterSet)]
    [OutputType("Amazon.WorkSpaces.Model.FailedWorkspaceChangeRequest")]
    [AWSCmdlet("Invokes the StopWorkspaces operation against Amazon WorkSpaces.", Operation = new[] {"StopWorkspaces"})]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.FailedWorkspaceChangeRequest",
        "This cmdlet returns a collection of FailedWorkspaceChangeRequest objects.",
        "The service call response (type Amazon.WorkSpaces.Model.StopWorkspacesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StopWKSWorkspaceCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        const string RequestObjectParameterSet = "RequestObjectSet";
        const string WorkspaceIdParameterSet = "IdParameterSet";
        
        #region Parameter Request
        /// <summary>
        /// <para>An array of StopRequest objects specifying the WorkSpaces to operate on.</para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, 
                                                ValueFromPipeline = true, 
                                                Mandatory = true,
                                                ParameterSetName = RequestObjectParameterSet)]
        [Alias("StopWorkspaceRequests", "StopWorkspaceRequest")]
        public Amazon.WorkSpaces.Model.StopRequest[] Request { get; set; }
        #endregion

        // todo: move this parameter into a partial class and bind into the context, as Request objects, using 
        // PostExecutionContextLoad() when we resume auto-generating this cmdlet.

        #region Parameter WorkspaceId
        /// <summary>
        /// The IDs of one or more WorkSpaces to be stopped.
        /// </summary>
        /// <returns></returns>
        [System.Management.Automation.Parameter(Position = 0,
                                                ValueFromPipeline = true, 
                                                ValueFromPipelineByPropertyName = true, 
                                                Mandatory = true,
                                                ParameterSetName = WorkspaceIdParameterSet)]
        public string[] WorkspaceId { get; set; }
        #endregion

        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(this.Request != null ? "Request" : "WorkspaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-WKSWorkspace (StopWorkspaces)"))
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
            

            if (this.Request != null)
            {
                context.StopRequest = new List<Amazon.WorkSpaces.Model.StopRequest>(this.Request);
            }
            else
            {
                var stopRequests = new List<Amazon.WorkSpaces.Model.StopRequest>();
                foreach (var id in this.WorkspaceId)
                {
                    stopRequests.Add(new StopRequest { WorkspaceId = id });
                }

                context.StopRequest = stopRequests;
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

            CmdletOutput output;

            try
            {
                var request = new Amazon.WorkSpaces.Model.StopWorkspacesRequest();

                request.StopWorkspaceRequests = cmdletContext.StopRequest;
                var client = Client ?? CreateClient(context.Credentials, context.Region);
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.FailedRequests;
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
        
        private static Amazon.WorkSpaces.Model.StopWorkspacesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.StopWorkspacesRequest request)
        {
            #if DESKTOP
            return client.StopWorkspaces(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.StopWorkspacesAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.WorkSpaces.Model.StopRequest> StopRequest { get; set; }
        }
        
    }
}
