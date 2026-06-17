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
    /// Updates the status or risk level of a security finding.
    /// </summary>
    [Cmdlet("Update", "SECAGFinding", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Agent UpdateFinding API operation.", Operation = new[] {"UpdateFinding"}, SelectReturnType = typeof(Amazon.SecurityAgent.Model.UpdateFindingResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityAgent.Model.UpdateFindingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityAgent.Model.UpdateFindingResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSECAGFindingCmdlet : AmazonSecurityAgentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AgentSpaceId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the agent space that contains the finding.</para>
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
        
        #region Parameter AttackScript
        /// <summary>
        /// <para>
        /// <para>The updated attack script for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AttackScript { get; set; }
        #endregion
        
        #region Parameter CustomerNote
        /// <summary>
        /// <para>
        /// <para>A customer-provided note on the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CustomerNote { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter FindingId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the finding to update.</para>
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
        public System.String FindingId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The updated name for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Reasoning
        /// <summary>
        /// <para>
        /// <para>The updated reasoning for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Reasoning { get; set; }
        #endregion
        
        #region Parameter RiskLevel
        /// <summary>
        /// <para>
        /// <para>The updated risk level for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityAgent.RiskLevel")]
        public Amazon.SecurityAgent.RiskLevel RiskLevel { get; set; }
        #endregion
        
        #region Parameter RiskScore
        /// <summary>
        /// <para>
        /// <para>The updated numerical risk score for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RiskScore { get; set; }
        #endregion
        
        #region Parameter RiskType
        /// <summary>
        /// <para>
        /// <para>The updated risk type for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RiskType { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The updated status for the finding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityAgent.FindingStatus")]
        public Amazon.SecurityAgent.FindingStatus Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityAgent.Model.UpdateFindingResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FindingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SECAGFinding (UpdateFinding)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityAgent.Model.UpdateFindingResponse, UpdateSECAGFindingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentSpaceId = this.AgentSpaceId;
            #if MODULAR
            if (this.AgentSpaceId == null && ParameterWasBound(nameof(this.AgentSpaceId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentSpaceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AttackScript = this.AttackScript;
            context.CustomerNote = this.CustomerNote;
            context.Description = this.Description;
            context.FindingId = this.FindingId;
            #if MODULAR
            if (this.FindingId == null && ParameterWasBound(nameof(this.FindingId)))
            {
                WriteWarning("You are passing $null as a value for parameter FindingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.Reasoning = this.Reasoning;
            context.RiskLevel = this.RiskLevel;
            context.RiskScore = this.RiskScore;
            context.RiskType = this.RiskType;
            context.Status = this.Status;
            
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
            var request = new Amazon.SecurityAgent.Model.UpdateFindingRequest();
            
            if (cmdletContext.AgentSpaceId != null)
            {
                request.AgentSpaceId = cmdletContext.AgentSpaceId;
            }
            if (cmdletContext.AttackScript != null)
            {
                request.AttackScript = cmdletContext.AttackScript;
            }
            if (cmdletContext.CustomerNote != null)
            {
                request.CustomerNote = cmdletContext.CustomerNote;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.FindingId != null)
            {
                request.FindingId = cmdletContext.FindingId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Reasoning != null)
            {
                request.Reasoning = cmdletContext.Reasoning;
            }
            if (cmdletContext.RiskLevel != null)
            {
                request.RiskLevel = cmdletContext.RiskLevel;
            }
            if (cmdletContext.RiskScore != null)
            {
                request.RiskScore = cmdletContext.RiskScore;
            }
            if (cmdletContext.RiskType != null)
            {
                request.RiskType = cmdletContext.RiskType;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
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
        
        private Amazon.SecurityAgent.Model.UpdateFindingResponse CallAWSServiceOperation(IAmazonSecurityAgent client, Amazon.SecurityAgent.Model.UpdateFindingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Agent", "UpdateFinding");
            try
            {
                return client.UpdateFindingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AttackScript { get; set; }
            public System.String CustomerNote { get; set; }
            public System.String Description { get; set; }
            public System.String FindingId { get; set; }
            public System.String Name { get; set; }
            public System.String Reasoning { get; set; }
            public Amazon.SecurityAgent.RiskLevel RiskLevel { get; set; }
            public System.String RiskScore { get; set; }
            public System.String RiskType { get; set; }
            public Amazon.SecurityAgent.FindingStatus Status { get; set; }
            public System.Func<Amazon.SecurityAgent.Model.UpdateFindingResponse, UpdateSECAGFindingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
