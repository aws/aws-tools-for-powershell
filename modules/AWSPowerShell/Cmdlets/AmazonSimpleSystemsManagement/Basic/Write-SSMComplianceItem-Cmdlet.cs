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
    /// Registers a compliance type and other compliance details on a designated resource.
    /// This API lets you register custom compliance details with a resource. This call overwrites
    /// existing compliance information on the resource, so you must provide a full list of
    /// compliance items each time you send the request.
    /// </summary>
    [Cmdlet("Write", "SSMComplianceItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Invokes the PutComplianceItems operation against Amazon Simple Systems Management.", Operation = new[] {"PutComplianceItems"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the ResourceId parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.SimpleSystemsManagement.Model.PutComplianceItemsResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteSSMComplianceItemCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>Specify the compliance type. For example, specify Association (for a State Manager
        /// association), Patch, or Custom:<code>string</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ComplianceType { get; set; }
        #endregion
        
        #region Parameter ExecutionSummary_ExecutionId
        /// <summary>
        /// <para>
        /// <para>An ID created by the system when <code>PutComplianceItems</code> was called. For example,
        /// <code>CommandID</code> is a valid execution ID. You can use this ID in subsequent
        /// calls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionSummary_ExecutionId { get; set; }
        #endregion
        
        #region Parameter ExecutionSummary_ExecutionTime
        /// <summary>
        /// <para>
        /// <para>The time the execution ran as a datetime object that is saved in the following format:
        /// yyyy-MM-dd'T'HH:mm:ss'Z'.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime ExecutionSummary_ExecutionTime { get; set; }
        #endregion
        
        #region Parameter ExecutionSummary_ExecutionType
        /// <summary>
        /// <para>
        /// <para>The type of execution. For example, <code>Command</code> is a valid execution type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExecutionSummary_ExecutionType { get; set; }
        #endregion
        
        #region Parameter ItemContentHash
        /// <summary>
        /// <para>
        /// <para>MD5 or Sha256 content hash. The content hash is used to determine if existing information
        /// should be overwritten or ignored. If the content hashes match, ,the request to put
        /// compliance information is ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ItemContentHash { get; set; }
        #endregion
        
        #region Parameter Item
        /// <summary>
        /// <para>
        /// <para>Information about the compliance as defined by the resource type. For example, for
        /// a patch compliance type, <code>Items</code> includes information about the PatchSeverity,
        /// Classification, etc.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Items")]
        public Amazon.SimpleSystemsManagement.Model.ComplianceItemEntry[] Item { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>Specify an ID for this resource. For a managed instance, this is the instance ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Specify the type of resource. <code>ManagedInstance</code> is currently the only supported
        /// resource type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the ResourceId parameter.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SSMComplianceItem (PutComplianceItems)"))
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
            
            context.ComplianceType = this.ComplianceType;
            context.ExecutionSummary_ExecutionId = this.ExecutionSummary_ExecutionId;
            if (ParameterWasBound("ExecutionSummary_ExecutionTime"))
                context.ExecutionSummary_ExecutionTime = this.ExecutionSummary_ExecutionTime;
            context.ExecutionSummary_ExecutionType = this.ExecutionSummary_ExecutionType;
            context.ItemContentHash = this.ItemContentHash;
            if (this.Item != null)
            {
                context.Items = new List<Amazon.SimpleSystemsManagement.Model.ComplianceItemEntry>(this.Item);
            }
            context.ResourceId = this.ResourceId;
            context.ResourceType = this.ResourceType;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.PutComplianceItemsRequest();
            
            if (cmdletContext.ComplianceType != null)
            {
                request.ComplianceType = cmdletContext.ComplianceType;
            }
            
             // populate ExecutionSummary
            bool requestExecutionSummaryIsNull = true;
            request.ExecutionSummary = new Amazon.SimpleSystemsManagement.Model.ComplianceExecutionSummary();
            System.String requestExecutionSummary_executionSummary_ExecutionId = null;
            if (cmdletContext.ExecutionSummary_ExecutionId != null)
            {
                requestExecutionSummary_executionSummary_ExecutionId = cmdletContext.ExecutionSummary_ExecutionId;
            }
            if (requestExecutionSummary_executionSummary_ExecutionId != null)
            {
                request.ExecutionSummary.ExecutionId = requestExecutionSummary_executionSummary_ExecutionId;
                requestExecutionSummaryIsNull = false;
            }
            System.DateTime? requestExecutionSummary_executionSummary_ExecutionTime = null;
            if (cmdletContext.ExecutionSummary_ExecutionTime != null)
            {
                requestExecutionSummary_executionSummary_ExecutionTime = cmdletContext.ExecutionSummary_ExecutionTime.Value;
            }
            if (requestExecutionSummary_executionSummary_ExecutionTime != null)
            {
                request.ExecutionSummary.ExecutionTime = requestExecutionSummary_executionSummary_ExecutionTime.Value;
                requestExecutionSummaryIsNull = false;
            }
            System.String requestExecutionSummary_executionSummary_ExecutionType = null;
            if (cmdletContext.ExecutionSummary_ExecutionType != null)
            {
                requestExecutionSummary_executionSummary_ExecutionType = cmdletContext.ExecutionSummary_ExecutionType;
            }
            if (requestExecutionSummary_executionSummary_ExecutionType != null)
            {
                request.ExecutionSummary.ExecutionType = requestExecutionSummary_executionSummary_ExecutionType;
                requestExecutionSummaryIsNull = false;
            }
             // determine if request.ExecutionSummary should be set to null
            if (requestExecutionSummaryIsNull)
            {
                request.ExecutionSummary = null;
            }
            if (cmdletContext.ItemContentHash != null)
            {
                request.ItemContentHash = cmdletContext.ItemContentHash;
            }
            if (cmdletContext.Items != null)
            {
                request.Items = cmdletContext.Items;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
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
                    pipelineOutput = this.ResourceId;
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
        
        private Amazon.SimpleSystemsManagement.Model.PutComplianceItemsResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.PutComplianceItemsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Systems Management", "PutComplianceItems");
            #if DESKTOP
            return client.PutComplianceItems(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutComplianceItemsAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ComplianceType { get; set; }
            public System.String ExecutionSummary_ExecutionId { get; set; }
            public System.DateTime? ExecutionSummary_ExecutionTime { get; set; }
            public System.String ExecutionSummary_ExecutionType { get; set; }
            public System.String ItemContentHash { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.ComplianceItemEntry> Items { get; set; }
            public System.String ResourceId { get; set; }
            public System.String ResourceType { get; set; }
        }
        
    }
}
