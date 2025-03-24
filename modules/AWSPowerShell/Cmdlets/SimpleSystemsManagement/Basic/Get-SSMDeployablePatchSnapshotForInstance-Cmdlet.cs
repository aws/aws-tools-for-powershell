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
    /// Retrieves the current snapshot for the patch baseline the managed node uses. This
    /// API is primarily used by the <c>AWS-RunPatchBaseline</c> Systems Manager document
    /// (SSM document).
    /// 
    ///  <note><para>
    /// If you run the command locally, such as with the Command Line Interface (CLI), the
    /// system attempts to use your local Amazon Web Services credentials and the operation
    /// fails. To avoid this, you can run the command in the Amazon Web Services Systems Manager
    /// console. Use Run Command, a tool in Amazon Web Services Systems Manager, with an SSM
    /// document that enables you to target a managed node with a script or command. For example,
    /// run the command using the <c>AWS-RunShellScript</c> document or the <c>AWS-RunPowerShellScript</c>
    /// document.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "SSMDeployablePatchSnapshotForInstance")]
    [OutputType("Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager GetDeployablePatchSnapshotForInstance API operation.", Operation = new[] {"GetDeployablePatchSnapshotForInstance"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse object containing multiple properties."
    )]
    public partial class GetSSMDeployablePatchSnapshotForInstanceCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BaselineOverride_ApprovedPatch
        /// <summary>
        /// <para>
        /// <para>A list of explicitly approved patches for the baseline.</para><para>For information about accepted formats for lists of approved patches and rejected
        /// patches, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/patch-manager-approved-rejected-package-name-formats.html">Package
        /// name formats for approved and rejected patch lists</a> in the <i>Amazon Web Services
        /// Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BaselineOverride_ApprovedPatches")]
        public System.String[] BaselineOverride_ApprovedPatch { get; set; }
        #endregion
        
        #region Parameter BaselineOverride_ApprovedPatchesComplianceLevel
        /// <summary>
        /// <para>
        /// <para>Defines the compliance level for approved patches. When an approved patch is reported
        /// as missing, this value describes the severity of the compliance violation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.PatchComplianceLevel")]
        public Amazon.SimpleSystemsManagement.PatchComplianceLevel BaselineOverride_ApprovedPatchesComplianceLevel { get; set; }
        #endregion
        
        #region Parameter BaselineOverride_ApprovedPatchesEnableNonSecurity
        /// <summary>
        /// <para>
        /// <para>Indicates whether the list of approved patches includes non-security updates that
        /// should be applied to the managed nodes. The default value is <c>false</c>. Applies
        /// to Linux managed nodes only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BaselineOverride_ApprovedPatchesEnableNonSecurity { get; set; }
        #endregion
        
        #region Parameter BaselineOverride_AvailableSecurityUpdatesComplianceStatus
        /// <summary>
        /// <para>
        /// <para>Indicates whether managed nodes for which there are available security-related patches
        /// that have not been approved by the baseline are being defined as <c>COMPLIANT</c>
        /// or <c>NON_COMPLIANT</c>. This option is specified when the <c>CreatePatchBaseline</c>
        /// or <c>UpdatePatchBaseline</c> commands are run.</para><para>Applies to Windows Server managed nodes only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.PatchComplianceStatus")]
        public Amazon.SimpleSystemsManagement.PatchComplianceStatus BaselineOverride_AvailableSecurityUpdatesComplianceStatus { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the managed node for which the appropriate patch snapshot should be retrieved.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter BaselineOverride_OperatingSystem
        /// <summary>
        /// <para>
        /// <para>The operating system rule used by the patch baseline override.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.OperatingSystem")]
        public Amazon.SimpleSystemsManagement.OperatingSystem BaselineOverride_OperatingSystem { get; set; }
        #endregion
        
        #region Parameter GlobalFilters_PatchFilter
        /// <summary>
        /// <para>
        /// <para>The set of patch filters that make up the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BaselineOverride_GlobalFilters_PatchFilters")]
        public Amazon.SimpleSystemsManagement.Model.PatchFilter[] GlobalFilters_PatchFilter { get; set; }
        #endregion
        
        #region Parameter ApprovalRules_PatchRule
        /// <summary>
        /// <para>
        /// <para>The rules that make up the rule group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BaselineOverride_ApprovalRules_PatchRules")]
        public Amazon.SimpleSystemsManagement.Model.PatchRule[] ApprovalRules_PatchRule { get; set; }
        #endregion
        
        #region Parameter BaselineOverride_RejectedPatch
        /// <summary>
        /// <para>
        /// <para>A list of explicitly rejected patches for the baseline.</para><para>For information about accepted formats for lists of approved patches and rejected
        /// patches, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/patch-manager-approved-rejected-package-name-formats.html">Package
        /// name formats for approved and rejected patch lists</a> in the <i>Amazon Web Services
        /// Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BaselineOverride_RejectedPatches")]
        public System.String[] BaselineOverride_RejectedPatch { get; set; }
        #endregion
        
        #region Parameter BaselineOverride_RejectedPatchesAction
        /// <summary>
        /// <para>
        /// <para>The action for Patch Manager to take on patches included in the <c>RejectedPackages</c>
        /// list. A patch can be allowed only if it is a dependency of another package, or blocked
        /// entirely along with packages that include it as a dependency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.PatchAction")]
        public Amazon.SimpleSystemsManagement.PatchAction BaselineOverride_RejectedPatchesAction { get; set; }
        #endregion
        
        #region Parameter SnapshotId
        /// <summary>
        /// <para>
        /// <para>The snapshot ID provided by the user when running <c>AWS-RunPatchBaseline</c>.</para>
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
        public System.String SnapshotId { get; set; }
        #endregion
        
        #region Parameter BaselineOverride_Source
        /// <summary>
        /// <para>
        /// <para>Information about the patches to use to update the managed nodes, including target
        /// operating systems and source repositories. Applies to Linux managed nodes only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BaselineOverride_Sources")]
        public Amazon.SimpleSystemsManagement.Model.PatchSource[] BaselineOverride_Source { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SnapshotId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SnapshotId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SnapshotId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse, GetSSMDeployablePatchSnapshotForInstanceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SnapshotId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ApprovalRules_PatchRule != null)
            {
                context.ApprovalRules_PatchRule = new List<Amazon.SimpleSystemsManagement.Model.PatchRule>(this.ApprovalRules_PatchRule);
            }
            if (this.BaselineOverride_ApprovedPatch != null)
            {
                context.BaselineOverride_ApprovedPatch = new List<System.String>(this.BaselineOverride_ApprovedPatch);
            }
            context.BaselineOverride_ApprovedPatchesComplianceLevel = this.BaselineOverride_ApprovedPatchesComplianceLevel;
            context.BaselineOverride_ApprovedPatchesEnableNonSecurity = this.BaselineOverride_ApprovedPatchesEnableNonSecurity;
            context.BaselineOverride_AvailableSecurityUpdatesComplianceStatus = this.BaselineOverride_AvailableSecurityUpdatesComplianceStatus;
            if (this.GlobalFilters_PatchFilter != null)
            {
                context.GlobalFilters_PatchFilter = new List<Amazon.SimpleSystemsManagement.Model.PatchFilter>(this.GlobalFilters_PatchFilter);
            }
            context.BaselineOverride_OperatingSystem = this.BaselineOverride_OperatingSystem;
            if (this.BaselineOverride_RejectedPatch != null)
            {
                context.BaselineOverride_RejectedPatch = new List<System.String>(this.BaselineOverride_RejectedPatch);
            }
            context.BaselineOverride_RejectedPatchesAction = this.BaselineOverride_RejectedPatchesAction;
            if (this.BaselineOverride_Source != null)
            {
                context.BaselineOverride_Source = new List<Amazon.SimpleSystemsManagement.Model.PatchSource>(this.BaselineOverride_Source);
            }
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SnapshotId = this.SnapshotId;
            #if MODULAR
            if (this.SnapshotId == null && ParameterWasBound(nameof(this.SnapshotId)))
            {
                WriteWarning("You are passing $null as a value for parameter SnapshotId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceRequest();
            
            
             // populate BaselineOverride
            var requestBaselineOverrideIsNull = true;
            request.BaselineOverride = new Amazon.SimpleSystemsManagement.Model.BaselineOverride();
            List<System.String> requestBaselineOverride_baselineOverride_ApprovedPatch = null;
            if (cmdletContext.BaselineOverride_ApprovedPatch != null)
            {
                requestBaselineOverride_baselineOverride_ApprovedPatch = cmdletContext.BaselineOverride_ApprovedPatch;
            }
            if (requestBaselineOverride_baselineOverride_ApprovedPatch != null)
            {
                request.BaselineOverride.ApprovedPatches = requestBaselineOverride_baselineOverride_ApprovedPatch;
                requestBaselineOverrideIsNull = false;
            }
            Amazon.SimpleSystemsManagement.PatchComplianceLevel requestBaselineOverride_baselineOverride_ApprovedPatchesComplianceLevel = null;
            if (cmdletContext.BaselineOverride_ApprovedPatchesComplianceLevel != null)
            {
                requestBaselineOverride_baselineOverride_ApprovedPatchesComplianceLevel = cmdletContext.BaselineOverride_ApprovedPatchesComplianceLevel;
            }
            if (requestBaselineOverride_baselineOverride_ApprovedPatchesComplianceLevel != null)
            {
                request.BaselineOverride.ApprovedPatchesComplianceLevel = requestBaselineOverride_baselineOverride_ApprovedPatchesComplianceLevel;
                requestBaselineOverrideIsNull = false;
            }
            System.Boolean? requestBaselineOverride_baselineOverride_ApprovedPatchesEnableNonSecurity = null;
            if (cmdletContext.BaselineOverride_ApprovedPatchesEnableNonSecurity != null)
            {
                requestBaselineOverride_baselineOverride_ApprovedPatchesEnableNonSecurity = cmdletContext.BaselineOverride_ApprovedPatchesEnableNonSecurity.Value;
            }
            if (requestBaselineOverride_baselineOverride_ApprovedPatchesEnableNonSecurity != null)
            {
                request.BaselineOverride.ApprovedPatchesEnableNonSecurity = requestBaselineOverride_baselineOverride_ApprovedPatchesEnableNonSecurity.Value;
                requestBaselineOverrideIsNull = false;
            }
            Amazon.SimpleSystemsManagement.PatchComplianceStatus requestBaselineOverride_baselineOverride_AvailableSecurityUpdatesComplianceStatus = null;
            if (cmdletContext.BaselineOverride_AvailableSecurityUpdatesComplianceStatus != null)
            {
                requestBaselineOverride_baselineOverride_AvailableSecurityUpdatesComplianceStatus = cmdletContext.BaselineOverride_AvailableSecurityUpdatesComplianceStatus;
            }
            if (requestBaselineOverride_baselineOverride_AvailableSecurityUpdatesComplianceStatus != null)
            {
                request.BaselineOverride.AvailableSecurityUpdatesComplianceStatus = requestBaselineOverride_baselineOverride_AvailableSecurityUpdatesComplianceStatus;
                requestBaselineOverrideIsNull = false;
            }
            Amazon.SimpleSystemsManagement.OperatingSystem requestBaselineOverride_baselineOverride_OperatingSystem = null;
            if (cmdletContext.BaselineOverride_OperatingSystem != null)
            {
                requestBaselineOverride_baselineOverride_OperatingSystem = cmdletContext.BaselineOverride_OperatingSystem;
            }
            if (requestBaselineOverride_baselineOverride_OperatingSystem != null)
            {
                request.BaselineOverride.OperatingSystem = requestBaselineOverride_baselineOverride_OperatingSystem;
                requestBaselineOverrideIsNull = false;
            }
            List<System.String> requestBaselineOverride_baselineOverride_RejectedPatch = null;
            if (cmdletContext.BaselineOverride_RejectedPatch != null)
            {
                requestBaselineOverride_baselineOverride_RejectedPatch = cmdletContext.BaselineOverride_RejectedPatch;
            }
            if (requestBaselineOverride_baselineOverride_RejectedPatch != null)
            {
                request.BaselineOverride.RejectedPatches = requestBaselineOverride_baselineOverride_RejectedPatch;
                requestBaselineOverrideIsNull = false;
            }
            Amazon.SimpleSystemsManagement.PatchAction requestBaselineOverride_baselineOverride_RejectedPatchesAction = null;
            if (cmdletContext.BaselineOverride_RejectedPatchesAction != null)
            {
                requestBaselineOverride_baselineOverride_RejectedPatchesAction = cmdletContext.BaselineOverride_RejectedPatchesAction;
            }
            if (requestBaselineOverride_baselineOverride_RejectedPatchesAction != null)
            {
                request.BaselineOverride.RejectedPatchesAction = requestBaselineOverride_baselineOverride_RejectedPatchesAction;
                requestBaselineOverrideIsNull = false;
            }
            List<Amazon.SimpleSystemsManagement.Model.PatchSource> requestBaselineOverride_baselineOverride_Source = null;
            if (cmdletContext.BaselineOverride_Source != null)
            {
                requestBaselineOverride_baselineOverride_Source = cmdletContext.BaselineOverride_Source;
            }
            if (requestBaselineOverride_baselineOverride_Source != null)
            {
                request.BaselineOverride.Sources = requestBaselineOverride_baselineOverride_Source;
                requestBaselineOverrideIsNull = false;
            }
            Amazon.SimpleSystemsManagement.Model.PatchRuleGroup requestBaselineOverride_baselineOverride_ApprovalRules = null;
            
             // populate ApprovalRules
            var requestBaselineOverride_baselineOverride_ApprovalRulesIsNull = true;
            requestBaselineOverride_baselineOverride_ApprovalRules = new Amazon.SimpleSystemsManagement.Model.PatchRuleGroup();
            List<Amazon.SimpleSystemsManagement.Model.PatchRule> requestBaselineOverride_baselineOverride_ApprovalRules_approvalRules_PatchRule = null;
            if (cmdletContext.ApprovalRules_PatchRule != null)
            {
                requestBaselineOverride_baselineOverride_ApprovalRules_approvalRules_PatchRule = cmdletContext.ApprovalRules_PatchRule;
            }
            if (requestBaselineOverride_baselineOverride_ApprovalRules_approvalRules_PatchRule != null)
            {
                requestBaselineOverride_baselineOverride_ApprovalRules.PatchRules = requestBaselineOverride_baselineOverride_ApprovalRules_approvalRules_PatchRule;
                requestBaselineOverride_baselineOverride_ApprovalRulesIsNull = false;
            }
             // determine if requestBaselineOverride_baselineOverride_ApprovalRules should be set to null
            if (requestBaselineOverride_baselineOverride_ApprovalRulesIsNull)
            {
                requestBaselineOverride_baselineOverride_ApprovalRules = null;
            }
            if (requestBaselineOverride_baselineOverride_ApprovalRules != null)
            {
                request.BaselineOverride.ApprovalRules = requestBaselineOverride_baselineOverride_ApprovalRules;
                requestBaselineOverrideIsNull = false;
            }
            Amazon.SimpleSystemsManagement.Model.PatchFilterGroup requestBaselineOverride_baselineOverride_GlobalFilters = null;
            
             // populate GlobalFilters
            var requestBaselineOverride_baselineOverride_GlobalFiltersIsNull = true;
            requestBaselineOverride_baselineOverride_GlobalFilters = new Amazon.SimpleSystemsManagement.Model.PatchFilterGroup();
            List<Amazon.SimpleSystemsManagement.Model.PatchFilter> requestBaselineOverride_baselineOverride_GlobalFilters_globalFilters_PatchFilter = null;
            if (cmdletContext.GlobalFilters_PatchFilter != null)
            {
                requestBaselineOverride_baselineOverride_GlobalFilters_globalFilters_PatchFilter = cmdletContext.GlobalFilters_PatchFilter;
            }
            if (requestBaselineOverride_baselineOverride_GlobalFilters_globalFilters_PatchFilter != null)
            {
                requestBaselineOverride_baselineOverride_GlobalFilters.PatchFilters = requestBaselineOverride_baselineOverride_GlobalFilters_globalFilters_PatchFilter;
                requestBaselineOverride_baselineOverride_GlobalFiltersIsNull = false;
            }
             // determine if requestBaselineOverride_baselineOverride_GlobalFilters should be set to null
            if (requestBaselineOverride_baselineOverride_GlobalFiltersIsNull)
            {
                requestBaselineOverride_baselineOverride_GlobalFilters = null;
            }
            if (requestBaselineOverride_baselineOverride_GlobalFilters != null)
            {
                request.BaselineOverride.GlobalFilters = requestBaselineOverride_baselineOverride_GlobalFilters;
                requestBaselineOverrideIsNull = false;
            }
             // determine if request.BaselineOverride should be set to null
            if (requestBaselineOverrideIsNull)
            {
                request.BaselineOverride = null;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.SnapshotId != null)
            {
                request.SnapshotId = cmdletContext.SnapshotId;
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
        
        private Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "GetDeployablePatchSnapshotForInstance");
            try
            {
                #if DESKTOP
                return client.GetDeployablePatchSnapshotForInstance(request);
                #elif CORECLR
                return client.GetDeployablePatchSnapshotForInstanceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.SimpleSystemsManagement.Model.PatchRule> ApprovalRules_PatchRule { get; set; }
            public List<System.String> BaselineOverride_ApprovedPatch { get; set; }
            public Amazon.SimpleSystemsManagement.PatchComplianceLevel BaselineOverride_ApprovedPatchesComplianceLevel { get; set; }
            public System.Boolean? BaselineOverride_ApprovedPatchesEnableNonSecurity { get; set; }
            public Amazon.SimpleSystemsManagement.PatchComplianceStatus BaselineOverride_AvailableSecurityUpdatesComplianceStatus { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchFilter> GlobalFilters_PatchFilter { get; set; }
            public Amazon.SimpleSystemsManagement.OperatingSystem BaselineOverride_OperatingSystem { get; set; }
            public List<System.String> BaselineOverride_RejectedPatch { get; set; }
            public Amazon.SimpleSystemsManagement.PatchAction BaselineOverride_RejectedPatchesAction { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchSource> BaselineOverride_Source { get; set; }
            public System.String InstanceId { get; set; }
            public System.String SnapshotId { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.GetDeployablePatchSnapshotForInstanceResponse, GetSSMDeployablePatchSnapshotForInstanceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
