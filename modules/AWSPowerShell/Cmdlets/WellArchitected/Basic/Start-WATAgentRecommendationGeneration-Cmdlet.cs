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
    /// Initiates a new recommendation generation process for the specified optimization profile.
    /// This asynchronous operation analyzes your Amazon Web Services resources and generates
    /// optimization recommendations based on the configured pillars and scope. Use GetAgentRecommendationGeneration
    /// to check status.
    /// </summary>
    [Cmdlet("Start", "WATAgentRecommendationGeneration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse")]
    [AWSCmdlet("Calls the AWS Well-Architected Tool StartAgentRecommendationGeneration API operation.", Operation = new[] {"StartAgentRecommendationGeneration"}, SelectReturnType = typeof(Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse))]
    [AWSCmdletOutput("Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse",
        "This cmdlet returns an Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse object containing multiple properties."
    )]
    public partial class StartWATAgentRecommendationGenerationCmdlet : AmazonWellArchitectedClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalContext
        /// <summary>
        /// <para>
        /// <para>Optional additional context to guide the recommendation generation, such as specific
        /// business requirements or constraints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Management.Automation.PSObject AdditionalContext { get; set; }
        #endregion
        
        #region Parameter Scope_GoalId
        /// <summary>
        /// <para>
        /// <para>Specific goal IDs to focus on during recommendation generation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_GoalIds")]
        public System.String[] Scope_GoalId { get; set; }
        #endregion
        
        #region Parameter Scope_Item
        /// <summary>
        /// <para>
        /// <para>Optional per-pillar item filtering configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Scope_Items")]
        public Amazon.WellArchitected.Model.PillarItem[] Scope_Item { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>An optional name for this generation process to help identify it in lists and logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Scope_Pillar
        /// <summary>
        /// <para>
        /// <para>The Well-Architected Tool Framework pillars to include in the generation scope.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Scope_Pillars")]
        public System.String[] Scope_Pillar { get; set; }
        #endregion
        
        #region Parameter ProfileArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the optimization profile to use for generating recommendations.</para>
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
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The types of recommendations to generate.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Types")]
        public System.String[] Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse).
        /// Specifying the name of a property of type Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-WATAgentRecommendationGeneration (StartAgentRecommendationGeneration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse, StartWATAgentRecommendationGenerationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdditionalContext = this.AdditionalContext;
            context.Name = this.Name;
            context.ProfileArn = this.ProfileArn;
            #if MODULAR
            if (this.ProfileArn == null && ParameterWasBound(nameof(this.ProfileArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProfileArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Scope_GoalId != null)
            {
                context.Scope_GoalId = new List<System.String>(this.Scope_GoalId);
            }
            if (this.Scope_Item != null)
            {
                context.Scope_Item = new List<Amazon.WellArchitected.Model.PillarItem>(this.Scope_Item);
            }
            if (this.Scope_Pillar != null)
            {
                context.Scope_Pillar = new List<System.String>(this.Scope_Pillar);
            }
            #if MODULAR
            if (this.Scope_Pillar == null && ParameterWasBound(nameof(this.Scope_Pillar)))
            {
                WriteWarning("You are passing $null as a value for parameter Scope_Pillar which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Type != null)
            {
                context.Type = new List<System.String>(this.Type);
            }
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WellArchitected.Model.StartAgentRecommendationGenerationRequest();
            
            if (cmdletContext.AdditionalContext != null)
            {
                request.AdditionalContext = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.AdditionalContext);
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ProfileArn != null)
            {
                request.ProfileArn = cmdletContext.ProfileArn;
            }
            
             // populate Scope
            var requestScopeIsNull = true;
            request.Scope = new Amazon.WellArchitected.Model.Scope();
            List<System.String> requestScope_scope_GoalId = null;
            if (cmdletContext.Scope_GoalId != null)
            {
                requestScope_scope_GoalId = cmdletContext.Scope_GoalId;
            }
            if (requestScope_scope_GoalId != null)
            {
                request.Scope.GoalIds = requestScope_scope_GoalId;
                requestScopeIsNull = false;
            }
            List<Amazon.WellArchitected.Model.PillarItem> requestScope_scope_Item = null;
            if (cmdletContext.Scope_Item != null)
            {
                requestScope_scope_Item = cmdletContext.Scope_Item;
            }
            if (requestScope_scope_Item != null)
            {
                request.Scope.Items = requestScope_scope_Item;
                requestScopeIsNull = false;
            }
            List<System.String> requestScope_scope_Pillar = null;
            if (cmdletContext.Scope_Pillar != null)
            {
                requestScope_scope_Pillar = cmdletContext.Scope_Pillar;
            }
            if (requestScope_scope_Pillar != null)
            {
                request.Scope.Pillars = requestScope_scope_Pillar;
                requestScopeIsNull = false;
            }
             // determine if request.Scope should be set to null
            if (requestScopeIsNull)
            {
                request.Scope = null;
            }
            if (cmdletContext.Type != null)
            {
                request.Types = cmdletContext.Type;
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
        
        private Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse CallAWSServiceOperation(IAmazonWellArchitected client, Amazon.WellArchitected.Model.StartAgentRecommendationGenerationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Well-Architected Tool", "StartAgentRecommendationGeneration");
            try
            {
                return client.StartAgentRecommendationGenerationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Management.Automation.PSObject AdditionalContext { get; set; }
            public System.String Name { get; set; }
            public System.String ProfileArn { get; set; }
            public List<System.String> Scope_GoalId { get; set; }
            public List<Amazon.WellArchitected.Model.PillarItem> Scope_Item { get; set; }
            public List<System.String> Scope_Pillar { get; set; }
            public List<System.String> Type { get; set; }
            public System.Func<Amazon.WellArchitected.Model.StartAgentRecommendationGenerationResponse, StartWATAgentRecommendationGenerationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
