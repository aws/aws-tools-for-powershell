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
using System.Threading;
using Amazon.WellArchitected;
using Amazon.WellArchitected.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WAT
{
    /// <summary>
    /// Updates an existing optimization profile's configuration, including its pillars, execution
    /// role, and aggregation settings. Include only the fields you want to change. Any field
    /// you omit from the request keeps its current value, so you do not need to retrieve
    /// the profile first and resend the fields you are not changing.
    /// 
    ///  
    /// <para>
    /// To clear an optional text field, supply an empty string for it; the field is then
    /// unset, and a subsequent read omits it rather than returning an empty string. Omitting
    /// the field from the request leaves the stored value in place. <c>description</c> and
    /// <c>businessOverview</c> can be cleared this way. <c>displayName</c> cannot be cleared
    /// because a display name is required, though you can change it. <c>pillars</c> cannot
    /// be cleared because a profile must target at least one pillar.
    /// </para><para><c>aggregationConfiguration</c> behaves differently because it is a list of per-account
    /// configurations rather than a text field. Supplying an empty list removes every account
    /// entry, but the field itself remains set: a subsequent read returns an empty list rather
    /// than omitting the field. Omitting it from the request keeps the stored entries.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "WATAgentProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.UpdateAgentProfileResponse")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool UpdateAgentProfile API operation.", Operation = new[] {"UpdateAgentProfile"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.UpdateAgentProfileResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.UpdateAgentProfileResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.UpdateAgentProfileResponse object containing multiple properties."
    )]
    public partial class UpdateWATAgentProfileCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AggregationConfiguration
        /// <summary>
        /// <para>
        /// <para>The updated aggregation configuration, as a list of per-account entries. Omit this
        /// field to keep the current entries, or supply an empty list to remove them all. The
        /// field remains set either way — an emptied configuration is read back as an empty list,
        /// not as an absent field.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.WellArchitected.Model.AggregationConfiguration[] AggregationConfiguration { get; set; }
        #endregion
        
        #region Parameter BusinessOverview
        /// <summary>
        /// <para>
        /// <para>The updated business overview for the profile. Omit this field to keep the current
        /// business overview, or supply an empty string to clear it; a cleared business overview
        /// is read back as absent rather than as an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BusinessOverview { get; set; }
        #endregion
        
        #region Parameter DeletionProtection
        /// <summary>
        /// <para>
        /// <para>Indicates whether deletion protection is enabled for the profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DeletionProtection { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the profile. Omit this field to keep the current description,
        /// or supply an empty string to clear it; a cleared description is read back as absent
        /// rather than as an empty string.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The updated display name of the profile. Omit this field to keep the current display
        /// name. A display name is required, so it cannot be cleared.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The updated ARN of the IAM execution role. Omit this field to keep the current execution
        /// role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Pillar
        /// <summary>
        /// <para>
        /// <para>The updated Amazon Web Services Well-Architected Framework pillars for the profile.
        /// Omit this field to keep the current pillars. A profile must target at least one pillar,
        /// so an empty list is rejected.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Pillars")]
        public System.String[] Pillar { get; set; }
        #endregion
        
        #region Parameter ProfileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the profile to update.</para>
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
        public System.String ProfileArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.UpdateAgentProfileResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.UpdateAgentProfileResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProfileArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WATAgentProfile (UpdateAgentProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.UpdateAgentProfileResponse, UpdateWATAgentProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AggregationConfiguration != null)
            {
                context.AggregationConfiguration = new List<Amazon.WellArchitected.Model.AggregationConfiguration>(this.AggregationConfiguration);
            }
            context.BusinessOverview = this.BusinessOverview;
            context.ClientToken = this.ClientToken;
            context.DeletionProtection = this.DeletionProtection;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            if (this.Pillar != null)
            {
                context.Pillar = new List<System.String>(this.Pillar);
            }
            context.ProfileArn = this.ProfileArn;
            #if MODULAR
            if (this.ProfileArn == null && ParameterWasBound(nameof(this.ProfileArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WellArchitected.Model.UpdateAgentProfileRequest();
            
            if (cmdletContext.AggregationConfiguration != null)
            {
                request.AggregationConfiguration = cmdletContext.AggregationConfiguration;
            }
            if (cmdletContext.BusinessOverview != null)
            {
                request.BusinessOverview = cmdletContext.BusinessOverview;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DeletionProtection != null)
            {
                request.DeletionProtection = cmdletContext.DeletionProtection.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.Pillar != null)
            {
                request.Pillars = cmdletContext.Pillar;
            }
            if (cmdletContext.ProfileArn != null)
            {
                request.ProfileArn = cmdletContext.ProfileArn;
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
        
        private Amazon.WellArchitected.Model.UpdateAgentProfileResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.UpdateAgentProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "UpdateAgentProfile");
            try
            {
                return client.UpdateAgentProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.WellArchitected.Model.AggregationConfiguration> AggregationConfiguration { get; set; }
            public System.String BusinessOverview { get; set; }
            public System.String ClientToken { get; set; }
            public System.Boolean? DeletionProtection { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public List<System.String> Pillar { get; set; }
            public System.String ProfileArn { get; set; }
            public System.Func<Amazon.WellArchitected.Model.UpdateAgentProfileResponse, UpdateWATAgentProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
