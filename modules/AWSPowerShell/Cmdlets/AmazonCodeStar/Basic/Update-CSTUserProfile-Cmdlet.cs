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
    /// Updates a user's profile in AWS CodeStar. The user profile is not project-specific.
    /// Information in the user profile is displayed wherever the user's information appears
    /// to other users in AWS CodeStar.
    /// </summary>
    [Cmdlet("Update", "CSTUserProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeStar.Model.UpdateUserProfileResponse")]
    [AWSCmdlet("Invokes the UpdateUserProfile operation against AWS CodeStar.", Operation = new[] {"UpdateUserProfile"})]
    [AWSCmdletOutput("Amazon.CodeStar.Model.UpdateUserProfileResponse",
        "This cmdlet returns a Amazon.CodeStar.Model.UpdateUserProfileResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCSTUserProfileCmdlet : AmazonCodeStarClientCmdlet, IExecutor
    {
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The name that is displayed as the friendly name for the user in AWS CodeStar.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter EmailAddress
        /// <summary>
        /// <para>
        /// <para>The email address that is displayed as part of the user's profile in AWS CodeStar.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EmailAddress { get; set; }
        #endregion
        
        #region Parameter SshPublicKey
        /// <summary>
        /// <para>
        /// <para>The SSH public key associated with the user in AWS CodeStar. If a project owner allows
        /// the user remote access to project resources, this public key will be used along with
        /// the user's private key for SSH access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SshPublicKey { get; set; }
        #endregion
        
        #region Parameter UserArn
        /// <summary>
        /// <para>
        /// <para>The name that will be displayed as the friendly name for the user in AWS CodeStar.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CSTUserProfile (UpdateUserProfile)"))
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
            
            context.DisplayName = this.DisplayName;
            context.EmailAddress = this.EmailAddress;
            context.SshPublicKey = this.SshPublicKey;
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
            var request = new Amazon.CodeStar.Model.UpdateUserProfileRequest();
            
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.EmailAddress != null)
            {
                request.EmailAddress = cmdletContext.EmailAddress;
            }
            if (cmdletContext.SshPublicKey != null)
            {
                request.SshPublicKey = cmdletContext.SshPublicKey;
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
        
        private Amazon.CodeStar.Model.UpdateUserProfileResponse CallAWSServiceOperation(IAmazonCodeStar client, Amazon.CodeStar.Model.UpdateUserProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeStar", "UpdateUserProfile");
            try
            {
                #if DESKTOP
                return client.UpdateUserProfile(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateUserProfileAsync(request);
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
            public System.String DisplayName { get; set; }
            public System.String EmailAddress { get; set; }
            public System.String SshPublicKey { get; set; }
            public System.String UserArn { get; set; }
        }
        
    }
}
