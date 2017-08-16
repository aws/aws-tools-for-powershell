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
using Amazon.CodeStar;
using Amazon.CodeStar.Model;

namespace Amazon.PowerShell.Cmdlets.CST
{
    /// <summary>
    /// Updates a team member's attributes in an AWS CodeStar project. For example, you can
    /// change a team member's role in the project, or change whether they have remote access
    /// to project resources.
    /// </summary>
    [Cmdlet("Update", "CSTTeamMember", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeStar.Model.UpdateTeamMemberResponse")]
    [AWSCmdlet("Invokes the UpdateTeamMember operation against AWS CodeStar.", Operation = new[] {"UpdateTeamMember"})]
    [AWSCmdletOutput("Amazon.CodeStar.Model.UpdateTeamMemberResponse",
        "This cmdlet returns a Amazon.CodeStar.Model.UpdateTeamMemberResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCSTTeamMemberCmdlet : AmazonCodeStarClientCmdlet, IExecutor
    {
        
        #region Parameter ProjectId
        /// <summary>
        /// <para>
        /// <para>The ID of the project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProjectId { get; set; }
        #endregion
        
        #region Parameter ProjectRole
        /// <summary>
        /// <para>
        /// <para>The role assigned to the user in the project. Project roles have different levels
        /// of access. For more information, see <a href="http://docs.aws.amazon.com/codestar/latest/userguide/working-with-teams.html">Working
        /// with Teams</a> in the AWS CodeStar User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProjectRole { get; set; }
        #endregion
        
        #region Parameter RemoteAccessAllowed
        /// <summary>
        /// <para>
        /// <para>Whether a team member is allowed to remotely access project resources using the SSH
        /// public key associated with the user's profile. Even if this is set to True, the user
        /// must associate a public key with their profile before the user can access resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RemoteAccessAllowed { get; set; }
        #endregion
        
        #region Parameter UserArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the user for whom you want to change team membership
        /// attributes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String UserArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CSTTeamMember (UpdateTeamMember)"))
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
            
            context.ProjectId = this.ProjectId;
            context.ProjectRole = this.ProjectRole;
            if (ParameterWasBound("RemoteAccessAllowed"))
                context.RemoteAccessAllowed = this.RemoteAccessAllowed;
            context.UserArn = this.UserArn;
            
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
            var request = new Amazon.CodeStar.Model.UpdateTeamMemberRequest();
            
            if (cmdletContext.ProjectId != null)
            {
                request.ProjectId = cmdletContext.ProjectId;
            }
            if (cmdletContext.ProjectRole != null)
            {
                request.ProjectRole = cmdletContext.ProjectRole;
            }
            if (cmdletContext.RemoteAccessAllowed != null)
            {
                request.RemoteAccessAllowed = cmdletContext.RemoteAccessAllowed.Value;
            }
            if (cmdletContext.UserArn != null)
            {
                request.UserArn = cmdletContext.UserArn;
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
        
        private Amazon.CodeStar.Model.UpdateTeamMemberResponse CallAWSServiceOperation(IAmazonCodeStar client, Amazon.CodeStar.Model.UpdateTeamMemberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeStar", "UpdateTeamMember");
            try
            {
                #if DESKTOP
                return client.UpdateTeamMember(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateTeamMemberAsync(request);
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
            public System.String ProjectId { get; set; }
            public System.String ProjectRole { get; set; }
            public System.Boolean? RemoteAccessAllowed { get; set; }
            public System.String UserArn { get; set; }
        }
        
    }
}
