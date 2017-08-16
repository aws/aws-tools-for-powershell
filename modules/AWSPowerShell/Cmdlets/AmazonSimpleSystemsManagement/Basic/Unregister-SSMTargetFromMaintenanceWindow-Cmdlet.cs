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
    /// Removes a target from a Maintenance Window.
    /// </summary>
    [Cmdlet("Unregister", "SSMTargetFromMaintenanceWindow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse")]
    [AWSCmdlet("Invokes the DeregisterTargetFromMaintenanceWindow operation against Amazon Simple Systems Management.", Operation = new[] {"DeregisterTargetFromMaintenanceWindow"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse",
        "This cmdlet returns a Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UnregisterSSMTargetFromMaintenanceWindowCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter Safe
        /// <summary>
        /// <para>
        /// <para>The system checks if the target is being referenced by a task. If the target is being
        /// referenced, the system returns and error and does not deregister the target from the
        /// Maintenance Window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Safe { get; set; }
        #endregion
        
        #region Parameter WindowId
        /// <summary>
        /// <para>
        /// <para>The ID of the Maintenance Window the target should be removed from.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WindowId { get; set; }
        #endregion
        
        #region Parameter WindowTargetId
        /// <summary>
        /// <para>
        /// <para>The ID of the target definition to remove.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String WindowTargetId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("WindowTargetId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-SSMTargetFromMaintenanceWindow (DeregisterTargetFromMaintenanceWindow)"))
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
            
            if (ParameterWasBound("Safe"))
                context.Safe = this.Safe;
            context.WindowId = this.WindowId;
            context.WindowTargetId = this.WindowTargetId;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowRequest();
            
            if (cmdletContext.Safe != null)
            {
                request.Safe = cmdletContext.Safe.Value;
            }
            if (cmdletContext.WindowId != null)
            {
                request.WindowId = cmdletContext.WindowId;
            }
            if (cmdletContext.WindowTargetId != null)
            {
                request.WindowTargetId = cmdletContext.WindowTargetId;
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
        
        private Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.DeregisterTargetFromMaintenanceWindowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Systems Management", "DeregisterTargetFromMaintenanceWindow");
            try
            {
                #if DESKTOP
                return client.DeregisterTargetFromMaintenanceWindow(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeregisterTargetFromMaintenanceWindowAsync(request);
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
            public System.Boolean? Safe { get; set; }
            public System.String WindowId { get; set; }
            public System.String WindowTargetId { get; set; }
        }
        
    }
}
