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
using Amazon.DirectoryService;
using Amazon.DirectoryService.Model;

namespace Amazon.PowerShell.Cmdlets.DS
{
    /// <summary>
    /// Resets the password for any user in your AWS Managed Microsoft AD or Simple AD directory.
    /// </summary>
    [Cmdlet("Reset", "DSUserPassword", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the AWS Directory Service ResetUserPassword API operation.", Operation = new[] {"ResetUserPassword"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the UserName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.DirectoryService.Model.ResetUserPasswordResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ResetDSUserPasswordCmdlet : AmazonDirectoryServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DirectoryId
        /// <summary>
        /// <para>
        /// <para>Identifier of the AWS Managed Microsoft AD or Simple AD directory in which the user
        /// resides.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String DirectoryId { get; set; }
        #endregion
        
        #region Parameter NewPassword
        /// <summary>
        /// <para>
        /// <para>The new password that will be reset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NewPassword { get; set; }
        #endregion
        
        #region Parameter UserName
        /// <summary>
        /// <para>
        /// <para>The user name of the user whose password will be reset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Reset-DSUserPassword (ResetUserPassword)"))
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
            
            context.DirectoryId = this.DirectoryId;
            context.NewPassword = this.NewPassword;
            context.UserName = this.UserName;
            
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
            var request = new Amazon.DirectoryService.Model.ResetUserPasswordRequest();
            
            if (cmdletContext.DirectoryId != null)
            {
                request.DirectoryId = cmdletContext.DirectoryId;
            }
            if (cmdletContext.NewPassword != null)
            {
                request.NewPassword = cmdletContext.NewPassword;
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.DirectoryService.Model.ResetUserPasswordResponse CallAWSServiceOperation(IAmazonDirectoryService client, Amazon.DirectoryService.Model.ResetUserPasswordRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Directory Service", "ResetUserPassword");
            try
            {
                #if DESKTOP
                return client.ResetUserPassword(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ResetUserPasswordAsync(request);
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
            public System.String DirectoryId { get; set; }
            public System.String NewPassword { get; set; }
            public System.String UserName { get; set; }
        }
        
    }
}
