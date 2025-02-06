/*******************************************************************************
 *  Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// This operation lets you register custom compliance details with a resource. This call
    /// overwrites existing compliance information on the resource, so you must provide a
    /// full list of compliance items each time that you send the request.
    /// 
    ///  
    /// <para>
    /// ComplianceType can be one of the following:
    /// </para><ul><li><para>
    /// ExecutionId: The execution ID when the patch, association, or custom compliance item
    /// was applied.
    /// </para></li><li><para>
    /// ExecutionType: Specify patch, association, or Custom:<c>string</c>.
    /// </para></li><li><para>
    /// ExecutionTime. The time the patch, association, or custom compliance item was applied
    /// to the managed node.
    /// </para></li><li><para>
    /// Id: The patch, association, or custom compliance ID.
    /// </para></li><li><para>
    /// Title: A title.
    /// </para></li><li><para>
    /// Status: The status of the compliance item. For example, <c>approved</c> for patches,
    /// or <c>Failed</c> for associations.
    /// </para></li><li><para>
    /// Severity: A patch severity. For example, <c>Critical</c>.
    /// </para></li><li><para>
    /// DocumentName: An SSM document name. For example, <c>AWS-RunPatchBaseline</c>.
    /// </para></li><li><para>
    /// DocumentVersion: An SSM document version number. For example, 4.
    /// </para></li><li><para>
    /// Classification: A patch classification. For example, <c>security updates</c>.
    /// </para></li><li><para>
    /// PatchBaselineId: A patch baseline ID.
    /// </para></li><li><para>
    /// PatchSeverity: A patch severity. For example, <c>Critical</c>.
    /// </para></li><li><para>
    /// PatchState: A patch state. For example, <c>InstancesWithFailedPatches</c>.
    /// </para></li><li><para>
    /// PatchGroup: The name of a patch group.
    /// </para></li><li><para>
    /// InstalledTime: The time the association, patch, or custom compliance item was applied
    /// to the resource. Specify the time by using the following format: <c>yyyy-MM-dd'T'HH:mm:ss'Z'</c></para></li></ul>
    /// </summary>
    [Cmdlet("Write", "SSMComplianceItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager PutComplianceItems API operation.", Operation = new[] {"PutComplianceItems"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.PutComplianceItemsResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleSystemsManagement.Model.PutComplianceItemsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleSystemsManagement.Model.PutComplianceItemsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteSSMComplianceItemCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComplianceType
        /// <summary>
        /// <para>
        /// <para>Specify the compliance type. For example, specify Association (for a State Manager
        /// association), Patch, or Custom:<c>string</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ComplianceType { get; set; }
        #endregion
        
        #region Parameter ExecutionSummary_ExecutionId
        /// <summary>
        /// <para>
        /// <para>An ID created by the system when <c>PutComplianceItems</c> was called. For example,
        /// <c>CommandID</c> is a valid execution ID. You can use this ID in subsequent calls.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionSummary_ExecutionId { get; set; }
        #endregion
        
        #region Parameter ExecutionSummary_ExecutionTime
        /// <summary>
        /// <para>
        /// <para>The time the execution ran as a datetime object that is saved in the following format:
        /// <c>yyyy-MM-dd'T'HH:mm:ss'Z'</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ExecutionSummary_ExecutionTime { get; set; }
        #endregion
        
        #region Parameter ExecutionSummary_ExecutionType
        /// <summary>
        /// <para>
        /// <para>The type of execution. For example, <c>Command</c> is a valid execution type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionSummary_ExecutionType { get; set; }
        #endregion
        
        #region Parameter ItemContentHash
        /// <summary>
        /// <para>
        /// <para>MD5 or SHA-256 content hash. The content hash is used to determine if existing information
        /// should be overwritten or ignored. If the content hashes match, the request to put
        /// compliance information is ignored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ItemContentHash { get; set; }
        #endregion
        
        #region Parameter Item
        /// <summary>
        /// <para>
        /// <para>Information about the compliance as defined by the resource type. For example, for
        /// a patch compliance type, <c>Items</c> includes information about the PatchSeverity,
        /// Classification, and so on.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Items")]
        public Amazon.SimpleSystemsManagement.Model.ComplianceItemEntry[] Item { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>Specify an ID for this resource. For a managed node, this is the node ID.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter ResourceType
        /// <summary>
        /// <para>
        /// <para>Specify the type of resource. <c>ManagedInstance</c> is currently the only supported
        /// resource type.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ResourceType { get; set; }
        #endregion
        
        #region Parameter UploadType
        /// <summary>
        /// <para>
        /// <para>The mode for uploading compliance items. You can specify <c>COMPLETE</c> or <c>PARTIAL</c>.
        /// In <c>COMPLETE</c> mode, the system overwrites all existing compliance information
        /// for the resource. You must provide a full list of compliance items each time you send
        /// the request.</para><para>In <c>PARTIAL</c> mode, the system overwrites compliance information for a specific
        /// association. The association must be configured with <c>SyncCompliance</c> set to
        /// <c>MANUAL</c>. By default, all requests use <c>COMPLETE</c> mode.</para><note><para>This attribute is only valid for association compliance.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.ComplianceUploadType")]
        public Amazon.SimpleSystemsManagement.ComplianceUploadType UploadType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.PutComplianceItemsResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-SSMComplianceItem (PutComplianceItems)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.PutComplianceItemsResponse, WriteSSMComplianceItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ComplianceType = this.ComplianceType;
            #if MODULAR
            if (this.ComplianceType == null && ParameterWasBound(nameof(this.ComplianceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ComplianceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionSummary_ExecutionId = this.ExecutionSummary_ExecutionId;
            context.ExecutionSummary_ExecutionTime = this.ExecutionSummary_ExecutionTime;
            #if MODULAR
            if (this.ExecutionSummary_ExecutionTime == null && ParameterWasBound(nameof(this.ExecutionSummary_ExecutionTime)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionSummary_ExecutionTime which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExecutionSummary_ExecutionType = this.ExecutionSummary_ExecutionType;
            context.ItemContentHash = this.ItemContentHash;
            if (this.Item != null)
            {
                context.Item = new List<Amazon.SimpleSystemsManagement.Model.ComplianceItemEntry>(this.Item);
            }
            #if MODULAR
            if (this.Item == null && ParameterWasBound(nameof(this.Item)))
            {
                WriteWarning("You are passing $null as a value for parameter Item which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceType = this.ResourceType;
            #if MODULAR
            if (this.ResourceType == null && ParameterWasBound(nameof(this.ResourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UploadType = this.UploadType;
            
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
            var requestExecutionSummaryIsNull = true;
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
            if (cmdletContext.Item != null)
            {
                request.Items = cmdletContext.Item;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            if (cmdletContext.ResourceType != null)
            {
                request.ResourceType = cmdletContext.ResourceType;
            }
            if (cmdletContext.UploadType != null)
            {
                request.UploadType = cmdletContext.UploadType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
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
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "PutComplianceItems");
            try
            {
                #if DESKTOP
                return client.PutComplianceItems(request);
                #elif CORECLR
                return client.PutComplianceItemsAsync(request).GetAwaiter().GetResult();
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
            public System.String ComplianceType { get; set; }
            public System.String ExecutionSummary_ExecutionId { get; set; }
            public System.DateTime? ExecutionSummary_ExecutionTime { get; set; }
            public System.String ExecutionSummary_ExecutionType { get; set; }
            public System.String ItemContentHash { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.ComplianceItemEntry> Item { get; set; }
            public System.String ResourceId { get; set; }
            public System.String ResourceType { get; set; }
            public Amazon.SimpleSystemsManagement.ComplianceUploadType UploadType { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.PutComplianceItemsResponse, WriteSSMComplianceItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
