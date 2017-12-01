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
using Amazon.IoT;
using Amazon.IoT.Model;

namespace Amazon.PowerShell.Cmdlets.IOT
{
    /// <summary>
    /// Updates a role alias.
    /// </summary>
    [Cmdlet("Update", "IOTRoleAlias", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoT.Model.UpdateRoleAliasResponse")]
    [AWSCmdlet("Calls the AWS IoT UpdateRoleAlias API operation.", Operation = new[] {"UpdateRoleAlias"})]
    [AWSCmdletOutput("Amazon.IoT.Model.UpdateRoleAliasResponse",
        "This cmdlet returns a Amazon.IoT.Model.UpdateRoleAliasResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateIOTRoleAliasCmdlet : AmazonIoTClientCmdlet, IExecutor
    {
        
        #region Parameter CredentialDurationSecond
        /// <summary>
        /// <para>
        /// <para>The number of seconds the credential will be valid.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("CredentialDurationSeconds")]
        public System.Int32 CredentialDurationSecond { get; set; }
        #endregion
        
        #region Parameter RoleAlias
        /// <summary>
        /// <para>
        /// <para>The role alias to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String RoleAlias { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The role ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String RoleArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("RoleArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTRoleAlias (UpdateRoleAlias)"))
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
            
            if (ParameterWasBound("CredentialDurationSecond"))
                context.CredentialDurationSeconds = this.CredentialDurationSecond;
            context.RoleAlias = this.RoleAlias;
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.IoT.Model.UpdateRoleAliasRequest();
            
            if (cmdletContext.CredentialDurationSeconds != null)
            {
                request.CredentialDurationSeconds = cmdletContext.CredentialDurationSeconds.Value;
            }
            if (cmdletContext.RoleAlias != null)
            {
                request.RoleAlias = cmdletContext.RoleAlias;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.IoT.Model.UpdateRoleAliasResponse CallAWSServiceOperation(IAmazonIoT client, Amazon.IoT.Model.UpdateRoleAliasRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT", "UpdateRoleAlias");
            try
            {
                #if DESKTOP
                return client.UpdateRoleAlias(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateRoleAliasAsync(request);
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
            public System.Int32? CredentialDurationSeconds { get; set; }
            public System.String RoleAlias { get; set; }
            public System.String RoleArn { get; set; }
        }
        
    }
}
