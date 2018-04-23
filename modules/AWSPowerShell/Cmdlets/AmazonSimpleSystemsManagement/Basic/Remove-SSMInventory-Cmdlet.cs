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
    /// Delete a custom inventory type, or the data associated with a custom Inventory type.
    /// Deleting a custom inventory type is also referred to as deleting a custom inventory
    /// schema.
    /// </summary>
    [Cmdlet("Remove", "SSMInventory", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.DeleteInventoryResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager DeleteInventory API operation.", Operation = new[] {"DeleteInventory"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.DeleteInventoryResponse",
        "This cmdlet returns a Amazon.SimpleSystemsManagement.Model.DeleteInventoryResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveSSMInventoryCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>User-provided idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Use this option to view a summary of the deletion request without deleting any data
        /// or the data type. This option is useful when you only want to understand what will
        /// be deleted. Once you validate that the data to be deleted is what you intend to delete,
        /// you can run the same command without specifying the <code>DryRun</code> option.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean DryRun { get; set; }
        #endregion
        
        #region Parameter SchemaDeleteOption
        /// <summary>
        /// <para>
        /// <para>Use the <code>SchemaDeleteOption</code> to delete a custom inventory type (schema).
        /// If you don't choose this option, the system only deletes existing inventory data associated
        /// with the custom inventory type. Choose one of the following options:</para><para>DisableSchema: If you choose this option, the system ignores all inventory data for
        /// the specified version, and any earlier versions. To enable this schema again, you
        /// must call the <code>PutInventory</code> action for a version greater than the disbled
        /// version.</para><para>DeleteSchema: This option deletes the specified custom type from the Inventory service.
        /// You can recreate the schema later, if you want.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.InventorySchemaDeleteOption")]
        public Amazon.SimpleSystemsManagement.InventorySchemaDeleteOption SchemaDeleteOption { get; set; }
        #endregion
        
        #region Parameter TypeName
        /// <summary>
        /// <para>
        /// <para>The name of the custom inventory type for which you want to delete either all previously
        /// collected data, or the inventory type itself. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TypeName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TypeName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SSMInventory (DeleteInventory)"))
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
            
            context.ClientToken = this.ClientToken;
            if (ParameterWasBound("DryRun"))
                context.DryRun = this.DryRun;
            context.SchemaDeleteOption = this.SchemaDeleteOption;
            context.TypeName = this.TypeName;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.DeleteInventoryRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.SchemaDeleteOption != null)
            {
                request.SchemaDeleteOption = cmdletContext.SchemaDeleteOption;
            }
            if (cmdletContext.TypeName != null)
            {
                request.TypeName = cmdletContext.TypeName;
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
        
        private Amazon.SimpleSystemsManagement.Model.DeleteInventoryResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.DeleteInventoryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "DeleteInventory");
            try
            {
                #if DESKTOP
                return client.DeleteInventory(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteInventoryAsync(request);
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
            public System.String ClientToken { get; set; }
            public System.Boolean? DryRun { get; set; }
            public Amazon.SimpleSystemsManagement.InventorySchemaDeleteOption SchemaDeleteOption { get; set; }
            public System.String TypeName { get; set; }
        }
        
    }
}
