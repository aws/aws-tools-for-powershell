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
    /// Updates the status of the SSM document associated with the specified instance.
    /// </summary>
    [Cmdlet("Update", "SSMAssociationStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.AssociationDescription")]
    [AWSCmdlet("Invokes the UpdateAssociationStatus operation against Amazon Simple Systems Management.", Operation = new[] {"UpdateAssociationStatus"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.AssociationDescription",
        "This cmdlet returns a AssociationDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class UpdateSSMAssociationStatusCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        /// <summary>
        /// <para>
        /// <para>A user-defined string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AssociationStatus_AdditionalInfo { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The date when the status changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime AssociationStatus_Date { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The reason for the status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AssociationStatus_Message { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.SimpleSystemsManagement.AssociationStatusName AssociationStatus_Name { get; set; }
        
        /// <summary>
        /// <para>
        /// <para>The name of the SSM document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("InstanceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMAssociationStatus (UpdateAssociationStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            context.AssociationStatus_AdditionalInfo = this.AssociationStatus_AdditionalInfo;
            if (ParameterWasBound("AssociationStatus_Date"))
                context.AssociationStatus_Date = this.AssociationStatus_Date;
            context.AssociationStatus_Message = this.AssociationStatus_Message;
            context.AssociationStatus_Name = this.AssociationStatus_Name;
            context.InstanceId = this.InstanceId;
            context.Name = this.Name;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusRequest();
            
            
             // populate AssociationStatus
            bool requestAssociationStatusIsNull = true;
            request.AssociationStatus = new Amazon.SimpleSystemsManagement.Model.AssociationStatus();
            System.String requestAssociationStatus_associationStatus_AdditionalInfo = null;
            if (cmdletContext.AssociationStatus_AdditionalInfo != null)
            {
                requestAssociationStatus_associationStatus_AdditionalInfo = cmdletContext.AssociationStatus_AdditionalInfo;
            }
            if (requestAssociationStatus_associationStatus_AdditionalInfo != null)
            {
                request.AssociationStatus.AdditionalInfo = requestAssociationStatus_associationStatus_AdditionalInfo;
                requestAssociationStatusIsNull = false;
            }
            System.DateTime? requestAssociationStatus_associationStatus_Date = null;
            if (cmdletContext.AssociationStatus_Date != null)
            {
                requestAssociationStatus_associationStatus_Date = cmdletContext.AssociationStatus_Date.Value;
            }
            if (requestAssociationStatus_associationStatus_Date != null)
            {
                request.AssociationStatus.Date = requestAssociationStatus_associationStatus_Date.Value;
                requestAssociationStatusIsNull = false;
            }
            System.String requestAssociationStatus_associationStatus_Message = null;
            if (cmdletContext.AssociationStatus_Message != null)
            {
                requestAssociationStatus_associationStatus_Message = cmdletContext.AssociationStatus_Message;
            }
            if (requestAssociationStatus_associationStatus_Message != null)
            {
                request.AssociationStatus.Message = requestAssociationStatus_associationStatus_Message;
                requestAssociationStatusIsNull = false;
            }
            Amazon.SimpleSystemsManagement.AssociationStatusName requestAssociationStatus_associationStatus_Name = null;
            if (cmdletContext.AssociationStatus_Name != null)
            {
                requestAssociationStatus_associationStatus_Name = cmdletContext.AssociationStatus_Name;
            }
            if (requestAssociationStatus_associationStatus_Name != null)
            {
                request.AssociationStatus.Name = requestAssociationStatus_associationStatus_Name;
                requestAssociationStatusIsNull = false;
            }
             // determine if request.AssociationStatus should be set to null
            if (requestAssociationStatusIsNull)
            {
                request.AssociationStatus = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.UpdateAssociationStatus(request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.AssociationDescription;
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
            public System.String AssociationStatus_AdditionalInfo { get; set; }
            public System.DateTime? AssociationStatus_Date { get; set; }
            public System.String AssociationStatus_Message { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationStatusName AssociationStatus_Name { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
