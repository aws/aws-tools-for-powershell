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
using Amazon.SecurityAgent;
using Amazon.SecurityAgent.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SECAG
{
    /// <summary>
    /// Creates a new threat under a threat model job.
    /// </summary>
    [Cmdlet("New", "SECAGThreat", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityAgent.Model.CreateThreatResponse")]
    [AWSCmdlet("Calls the AWS Security Agent CreateThreat API operation.", Operation = new[] {"CreateThreat"}, SelectReturnType = typeof(Amazon.SecurityAgent.Model.CreateThreatResponse))]
    [AWSCmdletOutput("Amazon.SecurityAgent.Model.CreateThreatResponse",
        "This cmdlet returns an Amazon.SecurityAgent.Model.CreateThreatResponse object containing multiple properties."
    )]
    public partial class NewSECAGThreatCmdlet : AmazonSecurityAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent space.</para>
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
        public System.String AgentSpaceId { get; set; }
        #endregion
        
        #region Parameter Comment
        /// <summary>
        /// <para>
        /// <para>Optional customer comment on the threat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Comments")]
        public System.String Comment { get; set; }
        #endregion
        
        #region Parameter Evidence
        /// <summary>
        /// <para>
        /// <para>The source code files supporting the threat.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.SecurityAgent.Model.ThreatEvidenceShape[] Evidence { get; set; }
        #endregion
        
        #region Parameter Anchor_Id
        /// <summary>
        /// <para>
        /// <para>The identifier of the DFD element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Anchor_Id { get; set; }
        #endregion
        
        #region Parameter ImpactedAsset
        /// <summary>
        /// <para>
        /// <para>The specific assets affected by the threat.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImpactedAssets")]
        public System.String[] ImpactedAsset { get; set; }
        #endregion
        
        #region Parameter ImpactedGoal
        /// <summary>
        /// <para>
        /// <para>The security goals affected by the threat.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] ImpactedGoal { get; set; }
        #endregion
        
        #region Parameter Anchor_Kind
        /// <summary>
        /// <para>
        /// <para>The kind of DFD element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Anchor_Kind { get; set; }
        #endregion
        
        #region Parameter Anchor_PackageId
        /// <summary>
        /// <para>
        /// <para>The package identifier containing the DFD element.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Anchor_PackageId { get; set; }
        #endregion
        
        #region Parameter Prerequisite
        /// <summary>
        /// <para>
        /// <para>The conditions required for the threat to be exploitable.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Prerequisites")]
        public System.String Prerequisite { get; set; }
        #endregion
        
        #region Parameter Recommendation
        /// <summary>
        /// <para>
        /// <para>The recommended mitigation guidance for this threat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Recommendation { get; set; }
        #endregion
        
        #region Parameter Severity
        /// <summary>
        /// <para>
        /// <para>The severity level of the threat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityAgent.ThreatSeverity")]
        public Amazon.SecurityAgent.ThreatSeverity Severity { get; set; }
        #endregion
        
        #region Parameter Statement
        /// <summary>
        /// <para>
        /// <para>The natural-language threat statement.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Statement { get; set; }
        #endregion
        
        #region Parameter Stride
        /// <summary>
        /// <para>
        /// <para>The STRIDE categories applicable to this threat.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] Stride { get; set; }
        #endregion
        
        #region Parameter ThreatAction
        /// <summary>
        /// <para>
        /// <para>What the threat source can do.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThreatAction { get; set; }
        #endregion
        
        #region Parameter ThreatImpact
        /// <summary>
        /// <para>
        /// <para>The direct consequence of the threat action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThreatImpact { get; set; }
        #endregion
        
        #region Parameter ThreatJobId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the threat model job the threat belongs to.</para>
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
        public System.String ThreatJobId { get; set; }
        #endregion
        
        #region Parameter ThreatSource
        /// <summary>
        /// <para>
        /// <para>The actor or origin of the threat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ThreatSource { get; set; }
        #endregion
        
        #region Parameter Title
        /// <summary>
        /// <para>
        /// <para>A short title summarizing the threat.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityAgent.Model.CreateThreatResponse).
        /// Specifying the name of a property of type Amazon.SecurityAgent.Model.CreateThreatResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ThreatJobId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SECAGThreat (CreateThreat)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityAgent.Model.CreateThreatResponse, NewSECAGThreatCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Anchor_Id = this.Anchor_Id;
            context.Anchor_Kind = this.Anchor_Kind;
            context.Anchor_PackageId = this.Anchor_PackageId;
            context.Comment = this.Comment;
            if (this.Evidence != null)
            {
                context.Evidence = new List<Amazon.SecurityAgent.Model.ThreatEvidenceShape>(this.Evidence);
            }
            if (this.ImpactedAsset != null)
            {
                context.ImpactedAsset = new List<System.String>(this.ImpactedAsset);
            }
            if (this.ImpactedGoal != null)
            {
                context.ImpactedGoal = new List<System.String>(this.ImpactedGoal);
            }
            context.Prerequisite = this.Prerequisite;
            context.Recommendation = this.Recommendation;
            context.Severity = this.Severity;
            context.Statement = this.Statement;
            if (this.Stride != null)
            {
                context.Stride = new List<System.String>(this.Stride);
            }
            context.ThreatAction = this.ThreatAction;
            context.ThreatImpact = this.ThreatImpact;
            context.ThreatJobId = this.ThreatJobId;
            #if MODULAR
            if (this.ThreatJobId == null && ParameterWasBound(nameof(this.ThreatJobId)))
            {
                WriteWarning("You are passing $null as a value for parameter ThreatJobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ThreatSource = this.ThreatSource;
            context.Title = this.Title;
            
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
            var request = new Amazon.SecurityAgent.Model.CreateThreatRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            
             // populate Anchor
            var requestAnchorIsNull = true;
            request.Anchor = new Amazon.SecurityAgent.Model.ThreatAnchorShape();
            System.String requestAnchor_anchor_Id = null;
            if (cmdletContext.Anchor_Id != null)
            {
                requestAnchor_anchor_Id = cmdletContext.Anchor_Id;
            }
            if (requestAnchor_anchor_Id != null)
            {
                request.Anchor.Id = requestAnchor_anchor_Id;
                requestAnchorIsNull = false;
            }
            System.String requestAnchor_anchor_Kind = null;
            if (cmdletContext.Anchor_Kind != null)
            {
                requestAnchor_anchor_Kind = cmdletContext.Anchor_Kind;
            }
            if (requestAnchor_anchor_Kind != null)
            {
                request.Anchor.Kind = requestAnchor_anchor_Kind;
                requestAnchorIsNull = false;
            }
            System.String requestAnchor_anchor_PackageId = null;
            if (cmdletContext.Anchor_PackageId != null)
            {
                requestAnchor_anchor_PackageId = cmdletContext.Anchor_PackageId;
            }
            if (requestAnchor_anchor_PackageId != null)
            {
                request.Anchor.PackageId = requestAnchor_anchor_PackageId;
                requestAnchorIsNull = false;
            }
             // determine if request.Anchor should be set to null
            if (requestAnchorIsNull)
            {
                request.Anchor = null;
            }
            if (cmdletContext.Comment != null)
            {
                request.Comments = cmdletContext.Comment;
            }
            if (cmdletContext.Evidence != null)
            {
                request.Evidence = cmdletContext.Evidence;
            }
            if (cmdletContext.ImpactedAsset != null)
            {
                request.ImpactedAssets = cmdletContext.ImpactedAsset;
            }
            if (cmdletContext.ImpactedGoal != null)
            {
                request.ImpactedGoal = cmdletContext.ImpactedGoal;
            }
            if (cmdletContext.Prerequisite != null)
            {
                request.Prerequisites = cmdletContext.Prerequisite;
            }
            if (cmdletContext.Recommendation != null)
            {
                request.Recommendation = cmdletContext.Recommendation;
            }
            if (cmdletContext.Severity != null)
            {
                request.Severity = cmdletContext.Severity;
            }
            if (cmdletContext.Statement != null)
            {
                request.Statement = cmdletContext.Statement;
            }
            if (cmdletContext.Stride != null)
            {
                request.Stride = cmdletContext.Stride;
            }
            if (cmdletContext.ThreatAction != null)
            {
                request.ThreatAction = cmdletContext.ThreatAction;
            }
            if (cmdletContext.ThreatImpact != null)
            {
                request.ThreatImpact = cmdletContext.ThreatImpact;
            }
            if (cmdletContext.ThreatJobId != null)
            {
                request.ThreatJobId = cmdletContext.ThreatJobId;
            }
            if (cmdletContext.ThreatSource != null)
            {
                request.ThreatSource = cmdletContext.ThreatSource;
            }
            if (cmdletContext.Title != null)
            {
                request.Title = cmdletContext.Title;
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
        
        private Amazon.SecurityAgent.Model.CreateThreatResponse CallAWSServiceOperation(IAmazonSecurityAgent client, Amazon.SecurityAgent.Model.CreateThreatRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Agent", "CreateThreat");
            try
            {
                return client.CreateThreatAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentSpaceId { get; set; }
            public System.String Anchor_Id { get; set; }
            public System.String Anchor_Kind { get; set; }
            public System.String Anchor_PackageId { get; set; }
            public System.String Comment { get; set; }
            public List<Amazon.SecurityAgent.Model.ThreatEvidenceShape> Evidence { get; set; }
            public List<System.String> ImpactedAsset { get; set; }
            public List<System.String> ImpactedGoal { get; set; }
            public System.String Prerequisite { get; set; }
            public System.String Recommendation { get; set; }
            public Amazon.SecurityAgent.ThreatSeverity Severity { get; set; }
            public System.String Statement { get; set; }
            public List<System.String> Stride { get; set; }
            public System.String ThreatAction { get; set; }
            public System.String ThreatImpact { get; set; }
            public System.String ThreatJobId { get; set; }
            public System.String ThreatSource { get; set; }
            public System.String Title { get; set; }
            public System.Func<Amazon.SecurityAgent.Model.CreateThreatResponse, NewSECAGThreatCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
