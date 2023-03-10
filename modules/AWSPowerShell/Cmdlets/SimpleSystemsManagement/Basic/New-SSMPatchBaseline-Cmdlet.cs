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
    /// Creates a patch baseline.
    /// 
    ///  <note><para>
    /// For information about valid key-value pairs in <code>PatchFilters</code> for each
    /// supported operating system type, see <a>PatchFilter</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SSMPatchBaseline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager CreatePatchBaseline API operation.", Operation = new[] {"CreatePatchBaseline"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMPatchBaselineCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        #region Parameter ApprovedPatch
        /// <summary>
        /// <para>
        /// <para>A list of explicitly approved patches for the baseline.</para><para>For information about accepted formats for lists of approved patches and rejected
        /// patches, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/patch-manager-approved-rejected-package-name-formats.html">About
        /// package name formats for approved and rejected patch lists</a> in the <i>Amazon Web
        /// Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApprovedPatches")]
        public System.String[] ApprovedPatch { get; set; }
        #endregion
        
        #region Parameter ApprovedPatchesComplianceLevel
        /// <summary>
        /// <para>
        /// <para>Defines the compliance level for approved patches. When an approved patch is reported
        /// as missing, this value describes the severity of the compliance violation. The default
        /// value is <code>UNSPECIFIED</code>.</para>
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
        /// should be applied to the managed nodes. The default value is <code>false</code>. Applies
        /// to Linux managed nodes only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ApprovedPatchesEnableNonSecurity { get; set; }
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter OperatingSystem
        /// <summary>
        /// <para>
        /// <para>Defines the operating system the patch baseline applies to. The default value is <code>WINDOWS</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.OperatingSystem")]
        public Amazon.SimpleSystemsManagement.OperatingSystem OperatingSystem { get; set; }
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
        /// patches, see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/patch-manager-approved-rejected-package-name-formats.html">About
        /// package name formats for approved and rejected patch lists</a> in the <i>Amazon Web
        /// Services Systems Manager User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RejectedPatches")]
        public System.String[] RejectedPatch { get; set; }
        #endregion
        
        #region Parameter RejectedPatchesAction
        /// <summary>
        /// <para>
        /// <para>The action for Patch Manager to take on patches included in the <code>RejectedPackages</code>
        /// list.</para><ul><li><para><b><code>ALLOW_AS_DEPENDENCY</code></b>: A package in the <code>Rejected</code>
        /// patches list is installed only if it is a dependency of another package. It is considered
        /// compliant with the patch baseline, and its status is reported as <code>InstalledOther</code>.
        /// This is the default action if no option is specified.</para></li><li><para><b><code>BLOCK</code></b>: Packages in the <code>RejectedPatches</code> list, and
        /// packages that include them as dependencies, aren't installed under any circumstances.
        /// If a package was installed before it was added to the Rejected patches list, it is
        /// considered non-compliant with the patch baseline, and its status is reported as <code>InstalledRejected</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.PatchAction")]
        public Amazon.SimpleSystemsManagement.PatchAction RejectedPatchesAction { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Optional metadata that you assign to a resource. Tags enable you to categorize a resource
        /// in different ways, such as by purpose, owner, or environment. For example, you might
        /// want to tag a patch baseline to identify the severity level of patches it specifies
        /// and the operating system family it applies to. In this case, you could specify the
        /// following key-value pairs:</para><ul><li><para><code>Key=PatchSeverity,Value=Critical</code></para></li><li><para><code>Key=OS,Value=Windows</code></para></li></ul><note><para>To add tags to an existing patch baseline, use the <a>AddTagsToResource</a> operation.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>User-provided idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BaselineId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BaselineId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMPatchBaseline (CreatePatchBaseline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse, NewSSMPatchBaselineCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.GlobalFilters_PatchFilter != null)
            {
                context.GlobalFilters_PatchFilter = new List<Amazon.SimpleSystemsManagement.Model.PatchFilter>(this.GlobalFilters_PatchFilter);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OperatingSystem = this.OperatingSystem;
            if (this.RejectedPatch != null)
            {
                context.RejectedPatch = new List<System.String>(this.RejectedPatch);
            }
            context.RejectedPatchesAction = this.RejectedPatchesAction;
            if (this.Source != null)
            {
                context.Source = new List<Amazon.SimpleSystemsManagement.Model.PatchSource>(this.Source);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
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
            var request = new Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineRequest();
            
            
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
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
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
            if (cmdletContext.OperatingSystem != null)
            {
                request.OperatingSystem = cmdletContext.OperatingSystem;
            }
            if (cmdletContext.RejectedPatch != null)
            {
                request.RejectedPatches = cmdletContext.RejectedPatch;
            }
            if (cmdletContext.RejectedPatchesAction != null)
            {
                request.RejectedPatchesAction = cmdletContext.RejectedPatchesAction;
            }
            if (cmdletContext.Source != null)
            {
                request.Sources = cmdletContext.Source;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreatePatchBaseline");
            try
            {
                #if DESKTOP
                return client.CreatePatchBaseline(request);
                #elif CORECLR
                return client.CreatePatchBaselineAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchFilter> GlobalFilters_PatchFilter { get; set; }
            public System.String Name { get; set; }
            public Amazon.SimpleSystemsManagement.OperatingSystem OperatingSystem { get; set; }
            public List<System.String> RejectedPatch { get; set; }
            public Amazon.SimpleSystemsManagement.PatchAction RejectedPatchesAction { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchSource> Source { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse, NewSSMPatchBaselineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BaselineId;
        }
        
    }
}
