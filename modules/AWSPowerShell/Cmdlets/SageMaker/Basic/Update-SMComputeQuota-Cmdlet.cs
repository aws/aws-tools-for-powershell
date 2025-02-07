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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Update the compute allocation definition.
    /// </summary>
    [Cmdlet("Update", "SMComputeQuota", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.UpdateComputeQuotaResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service UpdateComputeQuota API operation.", Operation = new[] {"UpdateComputeQuota"}, SelectReturnType = typeof(Amazon.SageMaker.Model.UpdateComputeQuotaResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.UpdateComputeQuotaResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.UpdateComputeQuotaResponse object containing multiple properties."
    )]
    public partial class UpdateSMComputeQuotaCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActivationState
        /// <summary>
        /// <para>
        /// <para>The state of the compute allocation being described. Use to enable or disable compute
        /// allocation.</para><para>Default is <c>Enabled</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SageMaker.ActivationState")]
        public Amazon.SageMaker.ActivationState ActivationState { get; set; }
        #endregion
        
        #region Parameter ResourceSharingConfig_BorrowLimit
        /// <summary>
        /// <para>
        /// <para>The limit on how much idle compute can be borrowed.The values can be 1 - 500 percent
        /// of idle compute that the team is allowed to borrow.</para><para>Default is <c>50</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeQuotaConfig_ResourceSharingConfig_BorrowLimit")]
        public System.Int32? ResourceSharingConfig_BorrowLimit { get; set; }
        #endregion
        
        #region Parameter ComputeQuotaId
        /// <summary>
        /// <para>
        /// <para>ID of the compute allocation definition.</para>
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
        public System.String ComputeQuotaId { get; set; }
        #endregion
        
        #region Parameter ComputeQuotaConfig_ComputeQuotaResource
        /// <summary>
        /// <para>
        /// <para>Allocate compute resources by instance types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeQuotaConfig_ComputeQuotaResources")]
        public Amazon.SageMaker.Model.ComputeQuotaResourceConfig[] ComputeQuotaConfig_ComputeQuotaResource { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Description of the compute allocation definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ComputeQuotaTarget_FairShareWeight
        /// <summary>
        /// <para>
        /// <para>Assigned entity fair-share weight. Idle compute will be shared across entities based
        /// on these assigned weights. This weight is only used when <c>FairShare</c> is enabled.</para><para>A weight of 0 is the lowest priority and 100 is the highest. Weight 0 is the default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ComputeQuotaTarget_FairShareWeight { get; set; }
        #endregion
        
        #region Parameter ComputeQuotaConfig_PreemptTeamTask
        /// <summary>
        /// <para>
        /// <para>Allows workloads from within an entity to preempt same-team workloads. When set to
        /// <c>LowerPriority</c>, the entity's lower priority tasks are preempted by their own
        /// higher priority tasks.</para><para>Default is <c>LowerPriority</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeQuotaConfig_PreemptTeamTasks")]
        [AWSConstantClassSource("Amazon.SageMaker.PreemptTeamTasks")]
        public Amazon.SageMaker.PreemptTeamTasks ComputeQuotaConfig_PreemptTeamTask { get; set; }
        #endregion
        
        #region Parameter ResourceSharingConfig_Strategy
        /// <summary>
        /// <para>
        /// <para>The strategy of how idle compute is shared within the cluster. The following are the
        /// options of strategies.</para><ul><li><para><c>DontLend</c>: entities do not lend idle compute.</para></li><li><para><c>Lend</c>: entities can lend idle compute to entities that can borrow.</para></li><li><para><c>LendandBorrow</c>: entities can lend idle compute and borrow idle compute from
        /// other entities.</para></li></ul><para>Default is <c>LendandBorrow</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeQuotaConfig_ResourceSharingConfig_Strategy")]
        [AWSConstantClassSource("Amazon.SageMaker.ResourceSharingStrategy")]
        public Amazon.SageMaker.ResourceSharingStrategy ResourceSharingConfig_Strategy { get; set; }
        #endregion
        
        #region Parameter TargetVersion
        /// <summary>
        /// <para>
        /// <para>Target version.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? TargetVersion { get; set; }
        #endregion
        
        #region Parameter ComputeQuotaTarget_TeamName
        /// <summary>
        /// <para>
        /// <para>Name of the team to allocate compute resources to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeQuotaTarget_TeamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.UpdateComputeQuotaResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.UpdateComputeQuotaResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ComputeQuotaId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SMComputeQuota (UpdateComputeQuota)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.UpdateComputeQuotaResponse, UpdateSMComputeQuotaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActivationState = this.ActivationState;
            if (this.ComputeQuotaConfig_ComputeQuotaResource != null)
            {
                context.ComputeQuotaConfig_ComputeQuotaResource = new List<Amazon.SageMaker.Model.ComputeQuotaResourceConfig>(this.ComputeQuotaConfig_ComputeQuotaResource);
            }
            context.ComputeQuotaConfig_PreemptTeamTask = this.ComputeQuotaConfig_PreemptTeamTask;
            context.ResourceSharingConfig_BorrowLimit = this.ResourceSharingConfig_BorrowLimit;
            context.ResourceSharingConfig_Strategy = this.ResourceSharingConfig_Strategy;
            context.ComputeQuotaId = this.ComputeQuotaId;
            #if MODULAR
            if (this.ComputeQuotaId == null && ParameterWasBound(nameof(this.ComputeQuotaId)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeQuotaId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ComputeQuotaTarget_FairShareWeight = this.ComputeQuotaTarget_FairShareWeight;
            context.ComputeQuotaTarget_TeamName = this.ComputeQuotaTarget_TeamName;
            context.Description = this.Description;
            context.TargetVersion = this.TargetVersion;
            #if MODULAR
            if (this.TargetVersion == null && ParameterWasBound(nameof(this.TargetVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SageMaker.Model.UpdateComputeQuotaRequest();
            
            if (cmdletContext.ActivationState != null)
            {
                request.ActivationState = cmdletContext.ActivationState;
            }
            
             // populate ComputeQuotaConfig
            var requestComputeQuotaConfigIsNull = true;
            request.ComputeQuotaConfig = new Amazon.SageMaker.Model.ComputeQuotaConfig();
            List<Amazon.SageMaker.Model.ComputeQuotaResourceConfig> requestComputeQuotaConfig_computeQuotaConfig_ComputeQuotaResource = null;
            if (cmdletContext.ComputeQuotaConfig_ComputeQuotaResource != null)
            {
                requestComputeQuotaConfig_computeQuotaConfig_ComputeQuotaResource = cmdletContext.ComputeQuotaConfig_ComputeQuotaResource;
            }
            if (requestComputeQuotaConfig_computeQuotaConfig_ComputeQuotaResource != null)
            {
                request.ComputeQuotaConfig.ComputeQuotaResources = requestComputeQuotaConfig_computeQuotaConfig_ComputeQuotaResource;
                requestComputeQuotaConfigIsNull = false;
            }
            Amazon.SageMaker.PreemptTeamTasks requestComputeQuotaConfig_computeQuotaConfig_PreemptTeamTask = null;
            if (cmdletContext.ComputeQuotaConfig_PreemptTeamTask != null)
            {
                requestComputeQuotaConfig_computeQuotaConfig_PreemptTeamTask = cmdletContext.ComputeQuotaConfig_PreemptTeamTask;
            }
            if (requestComputeQuotaConfig_computeQuotaConfig_PreemptTeamTask != null)
            {
                request.ComputeQuotaConfig.PreemptTeamTasks = requestComputeQuotaConfig_computeQuotaConfig_PreemptTeamTask;
                requestComputeQuotaConfigIsNull = false;
            }
            Amazon.SageMaker.Model.ResourceSharingConfig requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig = null;
            
             // populate ResourceSharingConfig
            var requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfigIsNull = true;
            requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig = new Amazon.SageMaker.Model.ResourceSharingConfig();
            System.Int32? requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig_resourceSharingConfig_BorrowLimit = null;
            if (cmdletContext.ResourceSharingConfig_BorrowLimit != null)
            {
                requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig_resourceSharingConfig_BorrowLimit = cmdletContext.ResourceSharingConfig_BorrowLimit.Value;
            }
            if (requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig_resourceSharingConfig_BorrowLimit != null)
            {
                requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig.BorrowLimit = requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig_resourceSharingConfig_BorrowLimit.Value;
                requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfigIsNull = false;
            }
            Amazon.SageMaker.ResourceSharingStrategy requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig_resourceSharingConfig_Strategy = null;
            if (cmdletContext.ResourceSharingConfig_Strategy != null)
            {
                requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig_resourceSharingConfig_Strategy = cmdletContext.ResourceSharingConfig_Strategy;
            }
            if (requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig_resourceSharingConfig_Strategy != null)
            {
                requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig.Strategy = requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig_resourceSharingConfig_Strategy;
                requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfigIsNull = false;
            }
             // determine if requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig should be set to null
            if (requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfigIsNull)
            {
                requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig = null;
            }
            if (requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig != null)
            {
                request.ComputeQuotaConfig.ResourceSharingConfig = requestComputeQuotaConfig_computeQuotaConfig_ResourceSharingConfig;
                requestComputeQuotaConfigIsNull = false;
            }
             // determine if request.ComputeQuotaConfig should be set to null
            if (requestComputeQuotaConfigIsNull)
            {
                request.ComputeQuotaConfig = null;
            }
            if (cmdletContext.ComputeQuotaId != null)
            {
                request.ComputeQuotaId = cmdletContext.ComputeQuotaId;
            }
            
             // populate ComputeQuotaTarget
            var requestComputeQuotaTargetIsNull = true;
            request.ComputeQuotaTarget = new Amazon.SageMaker.Model.ComputeQuotaTarget();
            System.Int32? requestComputeQuotaTarget_computeQuotaTarget_FairShareWeight = null;
            if (cmdletContext.ComputeQuotaTarget_FairShareWeight != null)
            {
                requestComputeQuotaTarget_computeQuotaTarget_FairShareWeight = cmdletContext.ComputeQuotaTarget_FairShareWeight.Value;
            }
            if (requestComputeQuotaTarget_computeQuotaTarget_FairShareWeight != null)
            {
                request.ComputeQuotaTarget.FairShareWeight = requestComputeQuotaTarget_computeQuotaTarget_FairShareWeight.Value;
                requestComputeQuotaTargetIsNull = false;
            }
            System.String requestComputeQuotaTarget_computeQuotaTarget_TeamName = null;
            if (cmdletContext.ComputeQuotaTarget_TeamName != null)
            {
                requestComputeQuotaTarget_computeQuotaTarget_TeamName = cmdletContext.ComputeQuotaTarget_TeamName;
            }
            if (requestComputeQuotaTarget_computeQuotaTarget_TeamName != null)
            {
                request.ComputeQuotaTarget.TeamName = requestComputeQuotaTarget_computeQuotaTarget_TeamName;
                requestComputeQuotaTargetIsNull = false;
            }
             // determine if request.ComputeQuotaTarget should be set to null
            if (requestComputeQuotaTargetIsNull)
            {
                request.ComputeQuotaTarget = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.TargetVersion != null)
            {
                request.TargetVersion = cmdletContext.TargetVersion.Value;
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
        
        private Amazon.SageMaker.Model.UpdateComputeQuotaResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.UpdateComputeQuotaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "UpdateComputeQuota");
            try
            {
                #if DESKTOP
                return client.UpdateComputeQuota(request);
                #elif CORECLR
                return client.UpdateComputeQuotaAsync(request).GetAwaiter().GetResult();
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
            public Amazon.SageMaker.ActivationState ActivationState { get; set; }
            public List<Amazon.SageMaker.Model.ComputeQuotaResourceConfig> ComputeQuotaConfig_ComputeQuotaResource { get; set; }
            public Amazon.SageMaker.PreemptTeamTasks ComputeQuotaConfig_PreemptTeamTask { get; set; }
            public System.Int32? ResourceSharingConfig_BorrowLimit { get; set; }
            public Amazon.SageMaker.ResourceSharingStrategy ResourceSharingConfig_Strategy { get; set; }
            public System.String ComputeQuotaId { get; set; }
            public System.Int32? ComputeQuotaTarget_FairShareWeight { get; set; }
            public System.String ComputeQuotaTarget_TeamName { get; set; }
            public System.String Description { get; set; }
            public System.Int32? TargetVersion { get; set; }
            public System.Func<Amazon.SageMaker.Model.UpdateComputeQuotaResponse, UpdateSMComputeQuotaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
