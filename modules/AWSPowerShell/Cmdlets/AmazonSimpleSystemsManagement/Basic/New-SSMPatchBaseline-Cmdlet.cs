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
    /// Creates a patch baseline.
    /// 
    ///  <note><para>
    /// For information about valid key and value pairs in <code>PatchFilters</code> for each
    /// supported operating system type, see <a href="http://docs.aws.amazon.com/systems-manager/latest/APIReference/API_PatchFilter.html">PatchFilter</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SSMPatchBaseline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager CreatePatchBaseline API operation.", Operation = new[] {"CreatePatchBaseline"})]
    [AWSCmdletOutput("System.String",
        "This cmdlet returns a String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewSSMPatchBaselineCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter ApprovedPatch
        /// <summary>
        /// <para>
        /// <para>A list of explicitly approved patches for the baseline.</para><para>For information about accepted formats for lists of approved patches and rejected
        /// patches, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/patch-manager-approved-rejected-package-name-formats.html">Package
        /// Name Formats for Approved and Rejected Patch Lists</a> in the <i>AWS Systems Manager
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApprovedPatches")]
        public System.String[] ApprovedPatch { get; set; }
        #endregion
        
        #region Parameter ApprovedPatchesComplianceLevel
        /// <summary>
        /// <para>
        /// <para>Defines the compliance level for approved patches. This means that if an approved
        /// patch is reported as missing, this is the severity of the compliance violation. The
        /// default value is UNSPECIFIED.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.PatchComplianceLevel")]
        public Amazon.SimpleSystemsManagement.PatchComplianceLevel ApprovedPatchesComplianceLevel { get; set; }
        #endregion
        
        #region Parameter ApprovedPatchesEnableNonSecurity
        /// <summary>
        /// <para>
        /// <para>Indicates whether the list of approved patches includes non-security updates that
        /// should be applied to the instances. The default value is 'false'. Applies to Linux
        /// instances only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ApprovedPatchesEnableNonSecurity { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>User-provided idempotency token.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the patch baseline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        
        #region Parameter OperatingSystem
        /// <summary>
        /// <para>
        /// <para>Defines the operating system the patch baseline applies to. The Default value is WINDOWS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.OperatingSystem")]
        public Amazon.SimpleSystemsManagement.OperatingSystem OperatingSystem { get; set; }
        #endregion
        
        #region Parameter GlobalFilters_PatchFilter
        /// <summary>
        /// <para>
        /// <para>The set of patch filters that make up the group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("GlobalFilters_PatchFilters")]
        public Amazon.SimpleSystemsManagement.Model.PatchFilter[] GlobalFilters_PatchFilter { get; set; }
        #endregion
        
        #region Parameter ApprovalRules_PatchRule
        /// <summary>
        /// <para>
        /// <para>The rules that make up the rule group.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApprovalRules_PatchRules")]
        public Amazon.SimpleSystemsManagement.Model.PatchRule[] ApprovalRules_PatchRule { get; set; }
        #endregion
        
        #region Parameter RejectedPatch
        /// <summary>
        /// <para>
        /// <para>A list of explicitly rejected patches for the baseline.</para><para>For information about accepted formats for lists of approved patches and rejected
        /// patches, see <a href="http://docs.aws.amazon.com/systems-manager/latest/userguide/patch-manager-approved-rejected-package-name-formats.html">Package
        /// Name Formats for Approved and Rejected Patch Lists</a> in the <i>AWS Systems Manager
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RejectedPatches")]
        public System.String[] RejectedPatch { get; set; }
        #endregion
        
        #region Parameter RejectedPatchesAction
        /// <summary>
        /// <para>
        /// <para>The action for Patch Manager to take on patches included in the RejectedPackages list.</para><ul><li><para><b>ALLOW_AS_DEPENDENCY</b>: A package in the Rejected patches list is installed only
        /// if it is a dependency of another package. It is considered compliant with the patch
        /// baseline, and its status is reported as <i>InstalledOther</i>. This is the default
        /// action if no option is specified.</para></li><li><para><b>BLOCK</b>: Packages in the RejectedPatches list, and packages that include them
        /// as dependencies, are not installed under any circumstances. If a package was installed
        /// before it was added to the Rejected patches list, it is considered non-compliant with
        /// the patch baseline, and its status is reported as <i>InstalledRejected</i>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.PatchAction")]
        public Amazon.SimpleSystemsManagement.PatchAction RejectedPatchesAction { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>Information about the patches to use to update the instances, including target operating
        /// systems and source repositories. Applies to Linux instances only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        /// following key name/value pairs:</para><ul><li><para><code>Key=PatchSeverity,Value=Critical</code></para></li><li><para><code>Key=OS,Value=Windows</code></para></li></ul><note><para>To add tags to an existing patch baseline, use the <a>AddTagsToResource</a> action.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.SimpleSystemsManagement.Model.Tag[] Tag { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSMPatchBaseline (CreatePatchBaseline)"))
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
            
            if (this.ApprovalRules_PatchRule != null)
            {
                context.ApprovalRules_PatchRules = new List<Amazon.SimpleSystemsManagement.Model.PatchRule>(this.ApprovalRules_PatchRule);
            }
            if (this.ApprovedPatch != null)
            {
                context.ApprovedPatches = new List<System.String>(this.ApprovedPatch);
            }
            context.ApprovedPatchesComplianceLevel = this.ApprovedPatchesComplianceLevel;
            if (ParameterWasBound("ApprovedPatchesEnableNonSecurity"))
                context.ApprovedPatchesEnableNonSecurity = this.ApprovedPatchesEnableNonSecurity;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            if (this.GlobalFilters_PatchFilter != null)
            {
                context.GlobalFilters_PatchFilters = new List<Amazon.SimpleSystemsManagement.Model.PatchFilter>(this.GlobalFilters_PatchFilter);
            }
            context.Name = this.Name;
            context.OperatingSystem = this.OperatingSystem;
            if (this.RejectedPatch != null)
            {
                context.RejectedPatches = new List<System.String>(this.RejectedPatch);
            }
            context.RejectedPatchesAction = this.RejectedPatchesAction;
            if (this.Source != null)
            {
                context.Sources = new List<Amazon.SimpleSystemsManagement.Model.PatchSource>(this.Source);
            }
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.SimpleSystemsManagement.Model.Tag>(this.Tag);
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
            bool requestApprovalRulesIsNull = true;
            request.ApprovalRules = new Amazon.SimpleSystemsManagement.Model.PatchRuleGroup();
            List<Amazon.SimpleSystemsManagement.Model.PatchRule> requestApprovalRules_approvalRules_PatchRule = null;
            if (cmdletContext.ApprovalRules_PatchRules != null)
            {
                requestApprovalRules_approvalRules_PatchRule = cmdletContext.ApprovalRules_PatchRules;
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
            if (cmdletContext.ApprovedPatches != null)
            {
                request.ApprovedPatches = cmdletContext.ApprovedPatches;
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
            bool requestGlobalFiltersIsNull = true;
            request.GlobalFilters = new Amazon.SimpleSystemsManagement.Model.PatchFilterGroup();
            List<Amazon.SimpleSystemsManagement.Model.PatchFilter> requestGlobalFilters_globalFilters_PatchFilter = null;
            if (cmdletContext.GlobalFilters_PatchFilters != null)
            {
                requestGlobalFilters_globalFilters_PatchFilter = cmdletContext.GlobalFilters_PatchFilters;
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
            if (cmdletContext.RejectedPatches != null)
            {
                request.RejectedPatches = cmdletContext.RejectedPatches;
            }
            if (cmdletContext.RejectedPatchesAction != null)
            {
                request.RejectedPatchesAction = cmdletContext.RejectedPatchesAction;
            }
            if (cmdletContext.Sources != null)
            {
                request.Sources = cmdletContext.Sources;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BaselineId;
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
        
        private Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.CreatePatchBaselineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "CreatePatchBaseline");
            try
            {
                #if DESKTOP
                return client.CreatePatchBaseline(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreatePatchBaselineAsync(request);
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
            public List<Amazon.SimpleSystemsManagement.Model.PatchRule> ApprovalRules_PatchRules { get; set; }
            public List<System.String> ApprovedPatches { get; set; }
            public Amazon.SimpleSystemsManagement.PatchComplianceLevel ApprovedPatchesComplianceLevel { get; set; }
            public System.Boolean? ApprovedPatchesEnableNonSecurity { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchFilter> GlobalFilters_PatchFilters { get; set; }
            public System.String Name { get; set; }
            public Amazon.SimpleSystemsManagement.OperatingSystem OperatingSystem { get; set; }
            public List<System.String> RejectedPatches { get; set; }
            public Amazon.SimpleSystemsManagement.PatchAction RejectedPatchesAction { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchSource> Sources { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.Tag> Tags { get; set; }
        }
        
    }
}
