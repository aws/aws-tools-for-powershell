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
    /// Updates the status of the Systems Manager document associated with the specified instance.
    /// </summary>
    [Cmdlet("Update", "SSMAssociationStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.AssociationDescription")]
    [AWSCmdlet("Invokes the UpdateAssociationStatus operation against Amazon Simple Systems Management.", Operation = new[] {"UpdateAssociationStatus"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.AssociationDescription",
        "This cmdlet returns a AssociationDescription object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSMAssociationStatusCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter AssociationStatus_AdditionalInfo
        /// <summary>
        /// <para>
        /// <para>A user-defined string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AssociationStatus_AdditionalInfo { get; set; }
        #endregion
        
        #region Parameter AssociationStatus_Date
        /// <summary>
        /// <para>
        /// <para>The date when the status changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime AssociationStatus_Date { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter AssociationStatus_Message
        /// <summary>
        /// <para>
        /// <para>The reason for the status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AssociationStatus_Message { get; set; }
        #endregion
        
        #region Parameter AssociationStatus_Name
        /// <summary>
        /// <para>
        /// <para>The status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.AssociationStatusName")]
        public Amazon.SimpleSystemsManagement.AssociationStatusName AssociationStatus_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Systems Manager document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
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
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AssociationStatus_AdditionalInfo = this.AssociationStatus_AdditionalInfo;
            if (ParameterWasBound("AssociationStatus_Date"))
                context.AssociationStatus_Date = this.AssociationStatus_Date;
            context.AssociationStatus_Message = this.AssociationStatus_Message;
            context.AssociationStatus_Name = this.AssociationStatus_Name;
            context.InstanceId = this.InstanceId;
            context.Name = this.Name;
            
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
                var response = CallAWSServiceOperation(client, request);
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
        
        #region AWS Service Operation Call
        
        private Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdateAssociationStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Systems Management", "UpdateAssociationStatus");
            try
            {
                #if DESKTOP
                return client.UpdateAssociationStatus(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateAssociationStatusAsync(request);
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
            public System.String AssociationStatus_AdditionalInfo { get; set; }
            public System.DateTime? AssociationStatus_Date { get; set; }
            public System.String AssociationStatus_Message { get; set; }
            public Amazon.SimpleSystemsManagement.AssociationStatusName AssociationStatus_Name { get; set; }
            public System.String InstanceId { get; set; }
            public System.String Name { get; set; }
        }
        
    }
}
