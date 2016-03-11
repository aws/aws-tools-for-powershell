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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Updates the name and/or the path of the specified user.
    /// 
    ///  <important> You should understand the implications of changing a user's path or name.
    /// For more information, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_users_manage.html#id_users_renaming">Renaming
    /// an IAM User</a> and <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/id_groups_manage_rename.html">Renaming
    /// an IAM Group</a> in the <i>IAM User Guide</i>. </important><note> To change a user
    /// name the requester must have appropriate permissions on both the source object and
    /// the target object. For example, to change Bob to Robert, the entity making the request
    /// must have permission on Bob and Robert, or must have permission on all (*). For more
    /// information about permissions, see <a href="http://docs.aws.amazon.com/IAM/latest/UserGuide/PermissionsAndPolicies.html" target="blank">Permissions and Policies</a>. </note>
    /// </summary>
    [Cmdlet("Update", "IAMUser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the UpdateUser operation against AWS Identity and Access Management.", Operation = new[] {"UpdateUser"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the UserName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.IdentityManagement.Model.UpdateUserResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateIAMUserCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter NewPath
        /// <summary>
        /// <para>
        /// <para>New path for the user. Include this parameter only if you're changing the user's path.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1)]
        public System.String NewPath { get; set; }
        #endregion
        
        #region Parameter NewUserName
        /// <summary>
        /// <para>
        /// <para>New name for the user. Include this parameter only if you're changing the user's name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String NewUserName { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>Name of the user to update. If you're changing the name of the user, this is the original
        /// user name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String UserName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the UserName parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("UserName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMUser (UpdateUser)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.NewPath = this.NewPath;
            context.NewUserName = this.NewUserName;
            context.UserName = this.UserName;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.IdentityManagement.Model.UpdateUserRequest();
            
            if (cmdletContext.NewPath != null)
            {
                request.NewPath = cmdletContext.NewPath;
            }
            if (cmdletContext.NewUserName != null)
            {
                request.NewUserName = cmdletContext.NewUserName;
            }
            if (cmdletContext.UserName != null)
            {
                request.UserName = cmdletContext.UserName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateUser(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.UserName;
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.String NewPath { get; set; }
            public System.String NewUserName { get; set; }
            public System.String UserName { get; set; }
        }
        
    }
}
