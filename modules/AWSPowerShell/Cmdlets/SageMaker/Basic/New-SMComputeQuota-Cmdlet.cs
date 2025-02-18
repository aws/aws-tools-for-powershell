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
using Amazon.SageMaker;
using Amazon.SageMaker.Model;

namespace Amazon.PowerShell.Cmdlets.SM
{
    /// <summary>
    /// Create compute allocation definition. This defines how compute is allocated, shared,
    /// and borrowed for specified entities. Specifically, how to lend and borrow idle compute
    /// and assign a fair-share weight to the specified entities.
    /// </summary>
    [Cmdlet("New", "SMComputeQuota", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SageMaker.Model.CreateComputeQuotaResponse")]
    [AWSCmdlet("Calls the Amazon SageMaker Service CreateComputeQuota API operation.", Operation = new[] {"CreateComputeQuota"}, SelectReturnType = typeof(Amazon.SageMaker.Model.CreateComputeQuotaResponse))]
    [AWSCmdletOutput("Amazon.SageMaker.Model.CreateComputeQuotaResponse",
        "This cmdlet returns an Amazon.SageMaker.Model.CreateComputeQuotaResponse object containing multiple properties."
    )]
    public partial class NewSMComputeQuotaCmdlet : AmazonSageMakerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        
        #region Parameter ClusterArn
        /// <summary>
        /// <para>
        /// <para>ARN of the cluster.</para>
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
        public System.String ClusterArn { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>Name to the compute allocation definition.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags of the compute allocation definition.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.SageMaker.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ComputeQuotaTarget_TeamName
        /// <summary>
        /// <para>
        /// <para>Name of the team to allocate compute resources to.</para>
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
        public System.String ComputeQuotaTarget_TeamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SageMaker.Model.CreateComputeQuotaResponse).
        /// Specifying the name of a property of type Amazon.SageMaker.Model.CreateComputeQuotaResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SMComputeQuota (CreateComputeQuota)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SageMaker.Model.CreateComputeQuotaResponse, NewSMComputeQuotaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActivationState = this.ActivationState;
            context.ClusterArn = this.ClusterArn;
            #if MODULAR
            if (this.ClusterArn == null && ParameterWasBound(nameof(this.ClusterArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ClusterArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ComputeQuotaConfig_ComputeQuotaResource != null)
            {
                context.ComputeQuotaConfig_ComputeQuotaResource = new List<Amazon.SageMaker.Model.ComputeQuotaResourceConfig>(this.ComputeQuotaConfig_ComputeQuotaResource);
            }
            context.ComputeQuotaConfig_PreemptTeamTask = this.ComputeQuotaConfig_PreemptTeamTask;
            context.ResourceSharingConfig_BorrowLimit = this.ResourceSharingConfig_BorrowLimit;
            context.ResourceSharingConfig_Strategy = this.ResourceSharingConfig_Strategy;
            context.ComputeQuotaTarget_FairShareWeight = this.ComputeQuotaTarget_FairShareWeight;
            context.ComputeQuotaTarget_TeamName = this.ComputeQuotaTarget_TeamName;
            #if MODULAR
            if (this.ComputeQuotaTarget_TeamName == null && ParameterWasBound(nameof(this.ComputeQuotaTarget_TeamName)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeQuotaTarget_TeamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.SageMaker.Model.Tag>(this.Tag);
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
            var request = new Amazon.SageMaker.Model.CreateComputeQuotaRequest();
            
            if (cmdletContext.ActivationState != null)
            {
                request.ActivationState = cmdletContext.ActivationState;
            }
            if (cmdletContext.ClusterArn != null)
            {
                request.ClusterArn = cmdletContext.ClusterArn;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.SageMaker.Model.CreateComputeQuotaResponse CallAWSServiceOperation(IAmazonSageMaker client, Amazon.SageMaker.Model.CreateComputeQuotaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon SageMaker Service", "CreateComputeQuota");
            try
            {
                return client.CreateComputeQuotaAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClusterArn { get; set; }
            public List<Amazon.SageMaker.Model.ComputeQuotaResourceConfig> ComputeQuotaConfig_ComputeQuotaResource { get; set; }
            public Amazon.SageMaker.PreemptTeamTasks ComputeQuotaConfig_PreemptTeamTask { get; set; }
            public System.Int32? ResourceSharingConfig_BorrowLimit { get; set; }
            public Amazon.SageMaker.ResourceSharingStrategy ResourceSharingConfig_Strategy { get; set; }
            public System.Int32? ComputeQuotaTarget_FairShareWeight { get; set; }
            public System.String ComputeQuotaTarget_TeamName { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.SageMaker.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.SageMaker.Model.CreateComputeQuotaResponse, NewSMComputeQuotaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
