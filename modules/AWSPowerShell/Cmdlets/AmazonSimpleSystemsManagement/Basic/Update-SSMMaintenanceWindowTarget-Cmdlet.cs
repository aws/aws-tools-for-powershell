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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Modifies the target of an existing Maintenance Window. You can't change the target
    /// type, but you can change the following:
    /// 
    ///  
    /// <para>
    /// The target from being an ID target to a Tag target, or a Tag target to an ID target.
    /// </para><para>
    /// IDs for an ID target.
    /// </para><para>
    /// Tags for a Tag target.
    /// </para><para>
    /// Owner.
    /// </para><para>
    /// Name.
    /// </para><para>
    /// Description.
    /// </para><para>
    /// If a parameter is null, then the corresponding field is not modified.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SSMMaintenanceWindowTarget", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.UpdateMaintenanceWindowTargetResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager UpdateMaintenanceWindowTarget API operation.", Operation = new[] {"UpdateMaintenanceWindowTarget"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.UpdateMaintenanceWindowTargetResponse",
        "This cmdlet returns a Amazon.SimpleSystemsManagement.Model.UpdateMaintenanceWindowTargetResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSMMaintenanceWindowTargetCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A name for the update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OwnerInformation
        /// <summary>
        /// <para>
        /// <para>User-provided value that will be included in any CloudWatch events raised while running
        /// tasks for these targets in this Maintenance Window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String OwnerInformation { get; set; }
        #endregion
        
        #region Parameter Replace
        /// <summary>
        /// <para>
        /// <para>If True, then all fields that are required by the RegisterTargetWithMaintenanceWindow
        /// action are also required for this API request. Optional fields that are not specified
        /// are set to null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Replace { get; set; }
        #endregion
        
        #region Parameter Target
        /// <summary>
        /// <para>
        /// <para>The targets to add or replace.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Targets")]
        public Amazon.SimpleSystemsManagement.Model.Target[] Target { get; set; }
        #endregion
        
        #region Parameter WindowId
        /// <summary>
        /// <para>
        /// <para>The Maintenance Window ID with which to modify the target.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WindowId { get; set; }
        #endregion
        
        #region Parameter WindowTargetId
        /// <summary>
        /// <para>
        /// <para>The target ID to modify.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMMaintenanceWindowTarget (UpdateMaintenanceWindowTarget)"))
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
            
            context.Description = this.Description;
            context.Name = this.Name;
            context.OwnerInformation = this.OwnerInformation;
            if (ParameterWasBound("Replace"))
                context.Replace = this.Replace;
            if (this.Target != null)
            {
                context.Targets = new List<Amazon.SimpleSystemsManagement.Model.Target>(this.Target);
            }
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
            var request = new Amazon.SimpleSystemsManagement.Model.UpdateMaintenanceWindowTargetRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.OwnerInformation != null)
            {
                request.OwnerInformation = cmdletContext.OwnerInformation;
            }
            if (cmdletContext.Replace != null)
            {
                request.Replace = cmdletContext.Replace.Value;
            }
            if (cmdletContext.Targets != null)
            {
                request.Targets = cmdletContext.Targets;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdateMaintenanceWindowTargetResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdateMaintenanceWindowTargetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "UpdateMaintenanceWindowTarget");
            try
            {
                #if DESKTOP
                return client.UpdateMaintenanceWindowTarget(request);
                #elif CORECLR
                return client.UpdateMaintenanceWindowTargetAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String OwnerInformation { get; set; }
            public System.Boolean? Replace { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Target> Targets { get; set; }
            public System.String WindowId { get; set; }
            public System.String WindowTargetId { get; set; }
        }
        
    }
}
