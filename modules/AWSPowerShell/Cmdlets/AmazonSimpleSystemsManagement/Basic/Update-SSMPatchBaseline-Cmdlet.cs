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
    /// Modifies an existing patch baseline. Fields not specified in the request are left
    /// unchanged.
    /// 
    ///  <note><para>
    /// For information about valid key and value pairs in <code>PatchFilters</code> for each
    /// supported operating system type, see <a href="http://docs.aws.amazon.com/systems-manager/latest/APIReference/API_PatchFilter.html">PatchFilter</a>.
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "SSMPatchBaseline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse")]
    [AWSCmdlet("Calls the Amazon Simple Systems Management UpdatePatchBaseline API operation.", Operation = new[] {"UpdatePatchBaseline"})]
    [AWSCmdletOutput("Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse",
        "This cmdlet returns a Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSSMPatchBaselineCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        #region Parameter ApprovedPatch
        /// <summary>
        /// <para>
        /// <para>A list of explicitly approved patches for the baseline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ApprovedPatches")]
        public System.String[] ApprovedPatch { get; set; }
        #endregion
        
        #region Parameter ApprovedPatchesComplianceLevel
        /// <summary>
        /// <para>
        /// <para>Assigns a new compliance severity level to an existing patch baseline.</para>
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
        
        #region Parameter BaselineId
        /// <summary>
        /// <para>
        /// <para>The ID of the patch baseline to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String BaselineId { get; set; }
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
        /// <para>A list of explicitly rejected patches for the baseline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("RejectedPatches")]
        public System.String[] RejectedPatch { get; set; }
        #endregion
        
        #region Parameter Replace
        /// <summary>
        /// <para>
        /// <para>If True, then all fields that are required by the CreatePatchBaseline action are also
        /// required for this API request. Optional fields that are not specified are set to null.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Replace { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("BaselineId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMPatchBaseline (UpdatePatchBaseline)"))
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
            context.BaselineId = this.BaselineId;
            context.Description = this.Description;
            if (this.GlobalFilters_PatchFilter != null)
            {
                context.GlobalFilters_PatchFilters = new List<Amazon.SimpleSystemsManagement.Model.PatchFilter>(this.GlobalFilters_PatchFilter);
            }
            context.Name = this.Name;
            if (this.RejectedPatch != null)
            {
                context.RejectedPatches = new List<System.String>(this.RejectedPatch);
            }
            if (ParameterWasBound("Replace"))
                context.Replace = this.Replace;
            if (this.Source != null)
            {
                context.Sources = new List<Amazon.SimpleSystemsManagement.Model.PatchSource>(this.Source);
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
            if (cmdletContext.BaselineId != null)
            {
                request.BaselineId = cmdletContext.BaselineId;
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
            if (cmdletContext.RejectedPatches != null)
            {
                request.RejectedPatches = cmdletContext.RejectedPatches;
            }
            if (cmdletContext.Replace != null)
            {
                request.Replace = cmdletContext.Replace.Value;
            }
            if (cmdletContext.Sources != null)
            {
                request.Sources = cmdletContext.Sources;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdatePatchBaselineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Simple Systems Management", "UpdatePatchBaseline");
            try
            {
                #if DESKTOP
                return client.UpdatePatchBaseline(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdatePatchBaselineAsync(request);
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
            public System.String BaselineId { get; set; }
            public System.String Description { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchFilter> GlobalFilters_PatchFilters { get; set; }
            public System.String Name { get; set; }
            public List<System.String> RejectedPatches { get; set; }
            public System.Boolean? Replace { get; set; }
            public List<Amazon.SimpleSystemsManagement.Model.PatchSource> Sources { get; set; }
        }
        
    }
}
