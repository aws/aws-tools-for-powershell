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
    /// Shares a Systems Manager document publicly or privately. If you share a document privately,
    /// you must specify the AWS user account IDs for those people who can use the document.
    /// If you share a document publicly, you must specify <i>All</i> as the account ID.
    /// </summary>
    [Cmdlet("Edit", "SSMDocumentPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the ModifyDocumentPermission operation against Amazon Simple Systems Management.", Operation = new[] {"ModifyDocumentPermission"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the Name parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SimpleSystemsManagement.Model.ModifyDocumentPermissionResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditSSMDocumentPermissionCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter AccountIdsToAdd
        /// <summary>
        /// <para>
        /// <para>The AWS user accounts that should have access to the document. The account IDs can
        /// either be a group of account IDs or <i>All</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] AccountIdsToAdd { get; set; }
        #endregion
        
        #region Parameter AccountIdsToRemove
        /// <summary>
        /// <para>
        /// <para>The AWS user accounts that should no longer have access to the document. The AWS user
        /// account can either be a group of account IDs or <i>All</i>. This action has a higher
        /// priority than <i>AccountIdsToAdd</i>. If you specify an account ID to add and the
        /// same ID to remove, the system removes access to the document.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String[] AccountIdsToRemove { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the document that you want to share.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter PermissionType
        /// <summary>
        /// <para>
        /// <para>The permission type for the document. The permission type can be <i>Share</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DocumentPermissionType")]
        public Amazon.SimpleSystemsManagement.DocumentPermissionType PermissionType { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the Name parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-SSMDocumentPermission (ModifyDocumentPermission)"))
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
            
            if (this.AccountIdsToAdd != null)
            {
                context.AccountIdsToAdd = new List<System.String>(this.AccountIdsToAdd);
            }
            if (this.AccountIdsToRemove != null)
            {
                context.AccountIdsToRemove = new List<System.String>(this.AccountIdsToRemove);
            }
            context.Name = this.Name;
            context.PermissionType = this.PermissionType;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.ModifyDocumentPermissionRequest();
            
            if (cmdletContext.AccountIdsToAdd != null)
            {
                request.AccountIdsToAdd = cmdletContext.AccountIdsToAdd;
            }
            if (cmdletContext.AccountIdsToRemove != null)
            {
                request.AccountIdsToRemove = cmdletContext.AccountIdsToRemove;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PermissionType != null)
            {
                request.PermissionType = cmdletContext.PermissionType;
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
                    pipelineOutput = this.Name;
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
        
        private Amazon.SimpleSystemsManagement.Model.ModifyDocumentPermissionResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.ModifyDocumentPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Systems Management", "ModifyDocumentPermission");
            #if DESKTOP
            return client.ModifyDocumentPermission(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.ModifyDocumentPermissionAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal class CmdletContext : ExecutorContext
        {
            public List<System.String> AccountIdsToAdd { get; set; }
            public List<System.String> AccountIdsToRemove { get; set; }
            public System.String Name { get; set; }
            public Amazon.SimpleSystemsManagement.DocumentPermissionType PermissionType { get; set; }
        }
        
    }
}
