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
    /// Adds an IAM user to the team for an AWS CodeStar project.
    /// </summary>
    [Cmdlet("Add", "CSTTeamMember", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Invokes the AssociateTeamMember operation against AWS CodeStar.", Operation = new[] {"AssociateTeamMember"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.CodeStar.Model.AssociateTeamMemberResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddCSTTeamMemberCmdlet : AmazonCodeStarClientCmdlet, IExecutor
    {
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A user- or system-generated token that identifies the entity that requested the team
        /// member association to the project. This token can be used to repeat the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter ProjectId
        /// <summary>
        /// <para>
        /// <para>The ID of the project to which you will add the IAM user.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProjectId { get; set; }
        #endregion
        
        #region Parameter ProjectRole
        /// <summary>
        /// <para>
        /// <para>The AWS CodeStar project role that will apply to this user. This role determines what
        /// actions a user can take in an AWS CodeStar project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ProjectRole { get; set; }
        #endregion
        
        #region Parameter RemoteAccessAllowed
        /// <summary>
        /// <para>
        /// <para>Whether the team member is allowed to use an SSH public/private key pair to remotely
        /// access project resources, for example Amazon EC2 instances.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean RemoteAccessAllowed { get; set; }
        #endregion
        
        #region Parameter UserArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the IAM user you want to add to the DevHub project.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-CSTTeamMember (AssociateTeamMember)"))
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
            
            context.ClientRequestToken = this.ClientRequestToken;
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
            var request = new Amazon.CodeStar.Model.AssociateTeamMemberRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
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
                object pipelineOutput = response.ClientRequestToken;
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
        
        private Amazon.CodeStar.Model.AssociateTeamMemberResponse CallAWSServiceOperation(IAmazonCodeStar client, Amazon.CodeStar.Model.AssociateTeamMemberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeStar", "AssociateTeamMember");
            #if DESKTOP
            return client.AssociateTeamMember(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.AssociateTeamMemberAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String ClientRequestToken { get; set; }
            public System.String ProjectId { get; set; }
            public System.String ProjectRole { get; set; }
            public System.Boolean? RemoteAccessAllowed { get; set; }
            public System.String UserArn { get; set; }
        }
        
    }
}
