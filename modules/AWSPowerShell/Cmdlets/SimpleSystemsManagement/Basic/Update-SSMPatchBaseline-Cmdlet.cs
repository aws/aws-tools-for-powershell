/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Modifies an existing patch baseline. Fields not specified in the request are left
    /// unchanged.
    /// 
    ///  <note><para>
    /// For information about valid key-value pairs in <c>PatchFilters</c> for each supported
    /// operating system type, see <a>PatchFilter</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SSMPatchBaseline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse")]
    [AWSCmdlet("Calls the AWS Systems Manager UpdatePatchBaseline API operation.", Operation = new[] {"UpdatePatchBaseline"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse))]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse",
        "This cmdlet returns an Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse object containing multiple properties."
    )]
    public partial class UpdateSSMPatchBaselineCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApprovedPatch
        /// <summary>
        /// <para>
        /// <para>A list of explicitly approved patches for the baseline.</para><para>For information about accepted formats for lists of approved patches and rejected
        /// patches, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/patch-manager-approved-rejected-package-name-formats.html">Package
        /// name formats for approved and rejected patch lists</a> in the <i>Amazon Web Services
        /// Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApprovedPatches")]
        public System.String[] ApprovedPatch { get; set; }
        #endregion
        
        #region Parameter ApprovedPatchesComplianceLevel
        /// <summary>
        /// <para>
        /// <para>Assigns a new compliance severity level to an existing patch baseline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.PatchComplianceLevel")]
        public Amazon.SimpleSystemsManagement.PatchComplianceLevel ApprovedPatchesComplianceLevel { get; set; }
        #endregion
        
        #region Parameter ApprovedPatchesEnableNonSecurity
        /// <summary>
        /// <para>
        /// <para>Indicates whether the list of approved patches includes non-security updates that
        /// should be applied to the managed nodes. The default value is <c>false</c>. Applies
        /// to Linux managed nodes only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApprovedPatchesEnableNonSecurity { get; set; }
        #endregion
        
        #region Parameter BaselineId
        /// <summary>
        /// <para>
        /// <para>The ID of the patch baseline to update.</para>
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
        public System.String BaselineId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the patch baseline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the patch baseline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter GlobalFilters_PatchFilter
        /// <summary>
        /// <para>
        /// <para>The set of patch filters that make up the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GlobalFilters_PatchFilters")]
        public Amazon.SimpleSystemsManagement.Model.PatchFilter[] GlobalFilters_PatchFilter { get; set; }
        #endregion
        
        #region Parameter ApprovalRules_PatchRule
        /// <summary>
        /// <para>
        /// <para>The rules that make up the rule group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApprovalRules_PatchRules")]
        public Amazon.SimpleSystemsManagement.Model.PatchRule[] ApprovalRules_PatchRule { get; set; }
        #endregion
        
        #region Parameter RejectedPatch
        /// <summary>
        /// <para>
        /// <para>A list of explicitly rejected patches for the baseline.</para><para>For information about accepted formats for lists of approved patches and rejected
        /// patches, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/patch-manager-approved-rejected-package-name-formats.html">Package
        /// name formats for approved and rejected patch lists</a> in the <i>Amazon Web Services
        /// Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RejectedPatches")]
        public System.String[] RejectedPatch { get; set; }
        #endregion
        
        #region Parameter RejectedPatchesAction
        /// <summary>
        /// <para>
        /// <para>The action for Patch Manager to take on patches included in the <c>RejectedPackages</c>
        /// list.</para><dl><dt>ALLOW_AS_DEPENDENCY</dt><dd><para><b>Linux and macOS</b>: A package in the rejected patches list is installed only
        /// if it is a dependency of another package. It is considered compliant with the patch
        /// baseline, and its status is reported as <c>INSTALLED_OTHER</c>. This is the default
        /// action if no option is specified.</para><para><b>Windows Server</b>: Windows Server doesn't support the concept of package dependencies.
        /// If a package in the rejected patches list and already installed on the node, its status
        /// is reported as <c>INSTALLED_OTHER</c>. Any package not already installed on the node
        /// is skipped. This is the default action if no option is specified.</para></dd><dt>BLOCK</dt><dd><para><b>All OSs</b>: Packages in the rejected patches list, and packages that include
        /// them as dependencies, aren't installed by Patch Manager under any circumstances. If
        /// a package was installed before it was added to the rejected patches list, or is installed
        /// outside of Patch Manager afterward, it's considered noncompliant with the patch baseline
        /// and its status is reported as <c>INSTALLED_REJECTED</c>.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.PatchAction")]
        public Amazon.SimpleSystemsManagement.PatchAction RejectedPatchesAction { get; set; }
        #endregion
        
        #region Parameter Replace
        /// <summary>
        /// <para>
        /// <para>If True, then all fields that are required by the <a>CreatePatchBaseline</a> operation
        /// are also required for this API request. Optional fields that aren't specified are
        /// set to null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Replace { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>Information about the patches to use to update the managed nodes, including target
        /// operating systems and source repositories. Applies to Linux managed nodes only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Sources")]
        public Amazon.SimpleSystemsManagement.Model.PatchSource[] Source { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BaselineId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BaselineId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BaselineId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BaselineId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMPatchBaseline (UpdatePatchBaseline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse, UpdateSSMPatchBaselineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BaselineId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.ApprovalRules_PatchRule != null)
            {
                context.ApprovalRules_PatchRule = new List<Amazon.SimpleSystemsManagement.Model.PatchRule>(this.ApprovalRules_PatchRule);
            }
            if (this.ApprovedPatch != null)
            {
                context.ApprovedPatch = new List<System.String>(this.ApprovedPatch);
            }
            context.ApprovedPatchesComplianceLevel = this.ApprovedPatchesComplianceLevel;
            context.ApprovedPatchesEnableNonSecurity = this.ApprovedPatchesEnableNonSecurity;
            context.BaselineId = this.BaselineId;
            #if MODULAR
            if (this.BaselineId == null && ParameterWasBound(nameof(this.BaselineId)))
            {
                WriteWarning("You are passing $null as a value for parameter BaselineId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            if (this.GlobalFilters_PatchFilter != null)
            {
                context.GlobalFilters_PatchFilter = new List<Amazon.SimpleSystemsManagement.Model.PatchFilter>(this.GlobalFilters_PatchFilter);
            }
            context.Name = this.Name;
            if (this.RejectedPatch != null)
            {
                context.RejectedPatch = new List<System.String>(this.RejectedPatch);
            }
            context.RejectedPatchesAction = this.RejectedPatchesAction;
            context.Replace = this.Replace;
            if (this.Source != null)
            {
                context.Source = new List<Amazon.SimpleSystemsManagement.Model.PatchSource>(this.Source);
            }
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineRequest();
            
            
             // populate ApprovalRules
            var requestApprovalRulesIsNull = true;
            request.ApprovalRules = new Amazon.SimpleSystemsManagement.Model.PatchRuleGroup();
            List<Amazon.SimpleSystemsManagement.Model.PatchRule> requestApprovalRules_approvalRules_PatchRule = null;
            if (cmdletContext.ApprovalRules_PatchRule != null)
            {
                requestApprovalRules_approvalRules_PatchRule = cmdletContext.ApprovalRules_PatchRule;
            }
            if (requestApprovalRules_approvalRules_PatchRule != null)
            {
                request.ApprovalRules.PatchRules = requestApprovalRules_approvalRules_PatchRule;
                requestApprovalRulesIsNull = false;
            }
             // determine if request.ApprovalRules should be set to null
            if (requestApprovalRulesIsNull)
            {
                request.ApprovalRules = null;
            }
            if (cmdletContext.ApprovedPatch != null)
            {
                request.ApprovedPatches = cmdletContext.ApprovedPatch;
            }
            if (cmdletContext.ApprovedPatchesComplianceLevel != null)
            {
                request.ApprovedPatchesComplianceLevel = cmdletContext.ApprovedPatchesComplianceLevel;
            }
            if (cmdletContext.ApprovedPatchesEnableNonSecurity != null)
            {
                request.ApprovedPatchesEnableNonSecurity = cmdletContext.ApprovedPatchesEnableNonSecurity.Value;
            }
            if (cmdletContext.BaselineId != null)
            {
                request.BaselineId = cmdletContext.BaselineId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate GlobalFilters
            var requestGlobalFiltersIsNull = true;
            request.GlobalFilters = new Amazon.SimpleSystemsManagement.Model.PatchFilterGroup();
            List<Amazon.SimpleSystemsManagement.Model.PatchFilter> requestGlobalFilters_globalFilters_PatchFilter = null;
            if (cmdletContext.GlobalFilters_PatchFilter != null)
            {
                requestGlobalFilters_globalFilters_PatchFilter = cmdletContext.GlobalFilters_PatchFilter;
            }
            if (requestGlobalFilters_globalFilters_PatchFilter != null)
            {
                request.GlobalFilters.PatchFilters = requestGlobalFilters_globalFilters_PatchFilter;
                requestGlobalFiltersIsNull = false;
            }
             // determine if request.GlobalFilters should be set to null
            if (requestGlobalFiltersIsNull)
            {
                request.GlobalFilters = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RejectedPatch != null)
            {
                request.RejectedPatches = cmdletContext.RejectedPatch;
            }
            if (cmdletContext.RejectedPatchesAction != null)
            {
                request.RejectedPatchesAction = cmdletContext.RejectedPatchesAction;
            }
            if (cmdletContext.Replace != null)
            {
                request.Replace = cmdletContext.Replace.Value;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "UpdatePatchBaseline");
            try
            {
                #if DESKTOP
                return client.UpdatePatchBaseline(request);
                #elif CORECLR
                return client.UpdatePatchBaselineAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> ApprovedPatch { get; set; }
            public Amazon.SimpleSystemsManagement.PatchComplianceLevel ApprovedPatchesComplianceLevel { get; set; }
            public System.Boolean? ApprovedPatchesEnableNonSecurity { get; set; }
            public System.String BaselineId { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchFilter> GlobalFilters_PatchFilter { get; set; }
            public System.String Name { get; set; }
            public List<System.String> RejectedPatch { get; set; }
            public Amazon.SimpleSystemsManagement.PatchAction RejectedPatchesAction { get; set; }
            public System.Boolean? Replace { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchSource> Source { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse, UpdateSSMPatchBaselineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
