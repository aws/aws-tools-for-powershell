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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Rebuilds the specified WorkSpaces. You can specify the Workspaces using either the
    /// <code>-WorkspaceId</code> or <code>-Request</code> parameters.
    /// <para>
    /// Rebuilding a WorkSpace is a potentially destructive action that can result in the
    /// loss of data. Rebuilding a WorkSpace causes the following to occur:
    /// </para><ul><li><para>
    /// The system is restored to the image of the bundle that the WorkSpace is created from.
    /// Any applications that have been installed, or system settings that have been made
    /// since the WorkSpace was created will be lost.
    /// </para></li><li><para>
    /// The data drive (D drive) is re-created from the last automatic snapshot taken of the
    /// data drive. The current contents of the data drive are overwritten. Automatic snapshots
    /// of the data drive are taken every 12 hours, so the snapshot can be as much as 12 hours
    /// old.
    /// </para></li></ul><para>
    /// To be able to rebuild a WorkSpace, the WorkSpace must have a <b>State</b> of <code>AVAILABLE</code>
    /// or <code>ERROR</code>.
    /// </para><note><para>
    /// This operation is asynchronous and returns before the WorkSpaces have been completely
    /// rebuilt.
    /// </para></note>
    /// </summary>
    [Cmdlet("Reset", "WKSWorkspace", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName = RequestObjectParameterSet)]
    [OutputType("Amazon.WorkSpaces.Model.FailedWorkspaceChangeRequest")]
    [AWSCmdlet("Calls the Amazon WorkSpaces RebuildWorkspaces API operation.", Operation = new[] { "RebuildWorkspaces" })]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.FailedWorkspaceChangeRequest",
        "This cmdlet returns a collection of FailedWorkspaceChangeRequest objects.",
        "The service call response (type Amazon.WorkSpaces.Model.RebuildWorkspacesResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ResetWKSWorkspaceCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        const string RequestObjectParameterSet = "IdFromRequestObject";
        const string WorkspaceIdParameterSet = "SimpleId";
        
        #region Parameter Request
        /// <summary>
        /// <para>
        /// <para>An array of structures that specify the WorkSpaces to rebuild.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0,
                                                ValueFromPipeline = true,
                                                Mandatory = true,
                                                ParameterSetName = RequestObjectParameterSet)]
        [Alias("RebuildWorkspaceRequests", "RebuildWorkspaceRequest")]
        public Amazon.WorkSpaces.Model.RebuildRequest[] Request { get; set; }
        #endregion

        // todo: move this parameter into a partial class and bind into the context, as Request objects, using 
        // PostExecutionContextLoad() when we resume auto-generating this cmdlet.

        #region Parameter WorkspaceId
        /// <summary>
        /// The IDs of one or more WorkSpaces to rebuild.
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0,
                                                ValueFromPipeline = true,
                                                ValueFromPipelineByPropertyName = true,
                                                Mandatory = true,
                                                ParameterSetName = WorkspaceIdParameterSet)]
        public string[] WorkspaceId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(this.Request != null ? "Request" : "WorkspaceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-WKSWorkspace (RebuildWorkspaces)"))
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
                context.Request = new List<Amazon.WorkSpaces.Model.RebuildRequest>(this.Request);
            }
            else
            {
                var rebuildRequests = new List<Amazon.WorkSpaces.Model.RebuildRequest>();
                foreach (var id in this.WorkspaceId)
                {
                    rebuildRequests.Add(new RebuildRequest{ WorkspaceId = id });
                }
                context.Request = rebuildRequests;
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
            var request = new Amazon.WorkSpaces.Model.RebuildWorkspacesRequest();
            
            if (cmdletContext.Request != null)
            {
                request.RebuildWorkspaceRequests = cmdletContext.Request;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
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
        
        private Amazon.WorkSpaces.Model.RebuildWorkspacesResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.RebuildWorkspacesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "RebuildWorkspaces");

            try
            {
#if DESKTOP
                return client.RebuildWorkspaces(request);
#elif CORECLR
                return client.RebuildWorkspacesAsync(request).GetAwaiter().GetResult();
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
        
        internal class CmdletContext : ExecutorContext
        {
            public List<Amazon.WorkSpaces.Model.RebuildRequest> Request { get; set; }
        }
        
    }
}
