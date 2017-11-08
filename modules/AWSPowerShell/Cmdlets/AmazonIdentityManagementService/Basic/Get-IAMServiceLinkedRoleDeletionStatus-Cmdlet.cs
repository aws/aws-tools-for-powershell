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
    /// Retrieves the status of your service-linked role deletion. After you use the <a>DeleteServiceLinkedRole</a>
    /// API operation to submit a service-linked role for deletion, you can use the <code>DeletionTaskId</code>
    /// parameter in <code>GetServiceLinkedRoleDeletionStatus</code> to check the status of
    /// the deletion. If the deletion fails, this operation returns the reason that it failed.
    /// </summary>
    [Cmdlet("Get", "IAMServiceLinkedRoleDeletionStatus")]
    [OutputType("Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse")]
    [AWSCmdlet("Calls the AWS Identity and Access Management GetServiceLinkedRoleDeletionStatus API operation.", Operation = new[] {"GetServiceLinkedRoleDeletionStatus"})]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse",
        "This cmdlet returns a Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIAMServiceLinkedRoleDeletionStatusCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        #region Parameter DeletionTaskId
        /// <summary>
        /// <para>
        /// <para>The deletion task identifier. This identifier is returned by the <a>DeleteServiceLinkedRole</a>
        /// operation in the format <code>task/aws-service-role/&lt;service-principal-name&gt;/&lt;role-name&gt;/&lt;task-uuid&gt;</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String DeletionTaskId { get; set; }
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
            
            context.DeletionTaskId = this.DeletionTaskId;
            
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
            var request = new Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusRequest();
            
            if (cmdletContext.DeletionTaskId != null)
            {
                request.DeletionTaskId = cmdletContext.DeletionTaskId;
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
        
        private Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.GetServiceLinkedRoleDeletionStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "GetServiceLinkedRoleDeletionStatus");
            try
            {
                #if DESKTOP
                return client.GetServiceLinkedRoleDeletionStatus(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetServiceLinkedRoleDeletionStatusAsync(request);
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
            public System.String DeletionTaskId { get; set; }
        }
        
    }
}
