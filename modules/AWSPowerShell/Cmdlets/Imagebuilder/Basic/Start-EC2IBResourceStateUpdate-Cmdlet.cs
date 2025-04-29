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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Begin asynchronous resource state update for lifecycle changes to the specified image
    /// resources.
    /// </summary>
    [Cmdlet("Start", "EC2IBResourceStateUpdate", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse")]
    [AWSCmdlet("Calls the EC2 Image Builder StartResourceStateUpdate API operation.", Operation = new[] {"StartResourceStateUpdate"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse))]
    [AWSCmdletOutput("Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse",
        "This cmdlet returns an Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse object containing multiple properties."
    )]
    public partial class StartEC2IBResourceStateUpdateCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IncludeResources_Ami
        /// <summary>
        /// <para>
        /// <para>Specifies whether the lifecycle action should apply to distributed AMIs</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeResources_Amis")]
        public System.Boolean? IncludeResources_Ami { get; set; }
        #endregion
        
        #region Parameter IncludeResources_Container
        /// <summary>
        /// <para>
        /// <para>Specifies whether the lifecycle action should apply to distributed containers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeResources_Containers")]
        public System.Boolean? IncludeResources_Container { get; set; }
        #endregion
        
        #region Parameter ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) of the IAM role that’s used to update image
        /// state.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRole { get; set; }
        #endregion
        
        #region Parameter Amis_IsPublic
        /// <summary>
        /// <para>
        /// <para>Configures whether public AMIs are excluded from the lifecycle action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionRules_Amis_IsPublic")]
        public System.Boolean? Amis_IsPublic { get; set; }
        #endregion
        
        #region Parameter Amis_Region
        /// <summary>
        /// <para>
        /// <para>Configures Amazon Web Services Regions that are excluded from the lifecycle action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionRules_Amis_Regions")]
        public System.String[] Amis_Region { get; set; }
        #endregion
        
        #region Parameter ResourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Image Builder resource that is updated. The state update might also
        /// impact associated resources.</para>
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
        public System.String ResourceArn { get; set; }
        #endregion
        
        #region Parameter Amis_SharedAccount
        /// <summary>
        /// <para>
        /// <para>Specifies Amazon Web Services accounts whose resources are excluded from the lifecycle
        /// action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionRules_Amis_SharedAccounts")]
        public System.String[] Amis_SharedAccount { get; set; }
        #endregion
        
        #region Parameter IncludeResources_Snapshot
        /// <summary>
        /// <para>
        /// <para>Specifies whether the lifecycle action should apply to snapshots associated with distributed
        /// AMIs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IncludeResources_Snapshots")]
        public System.Boolean? IncludeResources_Snapshot { get; set; }
        #endregion
        
        #region Parameter State_Status
        /// <summary>
        /// <para>
        /// <para>Shows the current lifecycle policy action that was applied to an impacted resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.ResourceStatus")]
        public Amazon.Imagebuilder.ResourceStatus State_Status { get; set; }
        #endregion
        
        #region Parameter Amis_TagMap
        /// <summary>
        /// <para>
        /// <para>Lists tags that should be excluded from lifecycle actions for the AMIs that have them.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionRules_Amis_TagMap")]
        public System.Collections.Hashtable Amis_TagMap { get; set; }
        #endregion
        
        #region Parameter LastLaunched_Unit
        /// <summary>
        /// <para>
        /// <para>Defines the unit of time that the lifecycle policy uses to calculate elapsed time
        /// since the last instance launched from the AMI. For example: days, weeks, months, or
        /// years.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionRules_Amis_LastLaunched_Unit")]
        [AWSConstantClassSource("Amazon.Imagebuilder.LifecyclePolicyTimeUnit")]
        public Amazon.Imagebuilder.LifecyclePolicyTimeUnit LastLaunched_Unit { get; set; }
        #endregion
        
        #region Parameter UpdateAt
        /// <summary>
        /// <para>
        /// <para>The timestamp that indicates when resources are updated by a lifecycle action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? UpdateAt { get; set; }
        #endregion
        
        #region Parameter LastLaunched_Value
        /// <summary>
        /// <para>
        /// <para>The integer number of units for the time period. For example <c>6</c> (months).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ExclusionRules_Amis_LastLaunched_Value")]
        public System.Int32? LastLaunched_Value { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-EC2IBResourceStateUpdate (StartResourceStateUpdate)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse, StartEC2IBResourceStateUpdateCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Amis_IsPublic = this.Amis_IsPublic;
            context.LastLaunched_Unit = this.LastLaunched_Unit;
            context.LastLaunched_Value = this.LastLaunched_Value;
            if (this.Amis_Region != null)
            {
                context.Amis_Region = new List<System.String>(this.Amis_Region);
            }
            if (this.Amis_SharedAccount != null)
            {
                context.Amis_SharedAccount = new List<System.String>(this.Amis_SharedAccount);
            }
            if (this.Amis_TagMap != null)
            {
                context.Amis_TagMap = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Amis_TagMap.Keys)
                {
                    context.Amis_TagMap.Add((String)hashKey, (System.String)(this.Amis_TagMap[hashKey]));
                }
            }
            context.ExecutionRole = this.ExecutionRole;
            context.IncludeResources_Ami = this.IncludeResources_Ami;
            context.IncludeResources_Container = this.IncludeResources_Container;
            context.IncludeResources_Snapshot = this.IncludeResources_Snapshot;
            context.ResourceArn = this.ResourceArn;
            #if MODULAR
            if (this.ResourceArn == null && ParameterWasBound(nameof(this.ResourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.State_Status = this.State_Status;
            context.UpdateAt = this.UpdateAt;
            
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
            var request = new Amazon.Imagebuilder.Model.StartResourceStateUpdateRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ExclusionRules
            var requestExclusionRulesIsNull = true;
            request.ExclusionRules = new Amazon.Imagebuilder.Model.ResourceStateUpdateExclusionRules();
            Amazon.Imagebuilder.Model.LifecyclePolicyDetailExclusionRulesAmis requestExclusionRules_exclusionRules_Amis = null;
            
             // populate Amis
            var requestExclusionRules_exclusionRules_AmisIsNull = true;
            requestExclusionRules_exclusionRules_Amis = new Amazon.Imagebuilder.Model.LifecyclePolicyDetailExclusionRulesAmis();
            System.Boolean? requestExclusionRules_exclusionRules_Amis_amis_IsPublic = null;
            if (cmdletContext.Amis_IsPublic != null)
            {
                requestExclusionRules_exclusionRules_Amis_amis_IsPublic = cmdletContext.Amis_IsPublic.Value;
            }
            if (requestExclusionRules_exclusionRules_Amis_amis_IsPublic != null)
            {
                requestExclusionRules_exclusionRules_Amis.IsPublic = requestExclusionRules_exclusionRules_Amis_amis_IsPublic.Value;
                requestExclusionRules_exclusionRules_AmisIsNull = false;
            }
            List<System.String> requestExclusionRules_exclusionRules_Amis_amis_Region = null;
            if (cmdletContext.Amis_Region != null)
            {
                requestExclusionRules_exclusionRules_Amis_amis_Region = cmdletContext.Amis_Region;
            }
            if (requestExclusionRules_exclusionRules_Amis_amis_Region != null)
            {
                requestExclusionRules_exclusionRules_Amis.Regions = requestExclusionRules_exclusionRules_Amis_amis_Region;
                requestExclusionRules_exclusionRules_AmisIsNull = false;
            }
            List<System.String> requestExclusionRules_exclusionRules_Amis_amis_SharedAccount = null;
            if (cmdletContext.Amis_SharedAccount != null)
            {
                requestExclusionRules_exclusionRules_Amis_amis_SharedAccount = cmdletContext.Amis_SharedAccount;
            }
            if (requestExclusionRules_exclusionRules_Amis_amis_SharedAccount != null)
            {
                requestExclusionRules_exclusionRules_Amis.SharedAccounts = requestExclusionRules_exclusionRules_Amis_amis_SharedAccount;
                requestExclusionRules_exclusionRules_AmisIsNull = false;
            }
            Dictionary<System.String, System.String> requestExclusionRules_exclusionRules_Amis_amis_TagMap = null;
            if (cmdletContext.Amis_TagMap != null)
            {
                requestExclusionRules_exclusionRules_Amis_amis_TagMap = cmdletContext.Amis_TagMap;
            }
            if (requestExclusionRules_exclusionRules_Amis_amis_TagMap != null)
            {
                requestExclusionRules_exclusionRules_Amis.TagMap = requestExclusionRules_exclusionRules_Amis_amis_TagMap;
                requestExclusionRules_exclusionRules_AmisIsNull = false;
            }
            Amazon.Imagebuilder.Model.LifecyclePolicyDetailExclusionRulesAmisLastLaunched requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched = null;
            
             // populate LastLaunched
            var requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunchedIsNull = true;
            requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched = new Amazon.Imagebuilder.Model.LifecyclePolicyDetailExclusionRulesAmisLastLaunched();
            Amazon.Imagebuilder.LifecyclePolicyTimeUnit requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched_lastLaunched_Unit = null;
            if (cmdletContext.LastLaunched_Unit != null)
            {
                requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched_lastLaunched_Unit = cmdletContext.LastLaunched_Unit;
            }
            if (requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched_lastLaunched_Unit != null)
            {
                requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched.Unit = requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched_lastLaunched_Unit;
                requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunchedIsNull = false;
            }
            System.Int32? requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched_lastLaunched_Value = null;
            if (cmdletContext.LastLaunched_Value != null)
            {
                requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched_lastLaunched_Value = cmdletContext.LastLaunched_Value.Value;
            }
            if (requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched_lastLaunched_Value != null)
            {
                requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched.Value = requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched_lastLaunched_Value.Value;
                requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunchedIsNull = false;
            }
             // determine if requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched should be set to null
            if (requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunchedIsNull)
            {
                requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched = null;
            }
            if (requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched != null)
            {
                requestExclusionRules_exclusionRules_Amis.LastLaunched = requestExclusionRules_exclusionRules_Amis_exclusionRules_Amis_LastLaunched;
                requestExclusionRules_exclusionRules_AmisIsNull = false;
            }
             // determine if requestExclusionRules_exclusionRules_Amis should be set to null
            if (requestExclusionRules_exclusionRules_AmisIsNull)
            {
                requestExclusionRules_exclusionRules_Amis = null;
            }
            if (requestExclusionRules_exclusionRules_Amis != null)
            {
                request.ExclusionRules.Amis = requestExclusionRules_exclusionRules_Amis;
                requestExclusionRulesIsNull = false;
            }
             // determine if request.ExclusionRules should be set to null
            if (requestExclusionRulesIsNull)
            {
                request.ExclusionRules = null;
            }
            if (cmdletContext.ExecutionRole != null)
            {
                request.ExecutionRole = cmdletContext.ExecutionRole;
            }
            
             // populate IncludeResources
            var requestIncludeResourcesIsNull = true;
            request.IncludeResources = new Amazon.Imagebuilder.Model.ResourceStateUpdateIncludeResources();
            System.Boolean? requestIncludeResources_includeResources_Ami = null;
            if (cmdletContext.IncludeResources_Ami != null)
            {
                requestIncludeResources_includeResources_Ami = cmdletContext.IncludeResources_Ami.Value;
            }
            if (requestIncludeResources_includeResources_Ami != null)
            {
                request.IncludeResources.Amis = requestIncludeResources_includeResources_Ami.Value;
                requestIncludeResourcesIsNull = false;
            }
            System.Boolean? requestIncludeResources_includeResources_Container = null;
            if (cmdletContext.IncludeResources_Container != null)
            {
                requestIncludeResources_includeResources_Container = cmdletContext.IncludeResources_Container.Value;
            }
            if (requestIncludeResources_includeResources_Container != null)
            {
                request.IncludeResources.Containers = requestIncludeResources_includeResources_Container.Value;
                requestIncludeResourcesIsNull = false;
            }
            System.Boolean? requestIncludeResources_includeResources_Snapshot = null;
            if (cmdletContext.IncludeResources_Snapshot != null)
            {
                requestIncludeResources_includeResources_Snapshot = cmdletContext.IncludeResources_Snapshot.Value;
            }
            if (requestIncludeResources_includeResources_Snapshot != null)
            {
                request.IncludeResources.Snapshots = requestIncludeResources_includeResources_Snapshot.Value;
                requestIncludeResourcesIsNull = false;
            }
             // determine if request.IncludeResources should be set to null
            if (requestIncludeResourcesIsNull)
            {
                request.IncludeResources = null;
            }
            if (cmdletContext.ResourceArn != null)
            {
                request.ResourceArn = cmdletContext.ResourceArn;
            }
            
             // populate State
            var requestStateIsNull = true;
            request.State = new Amazon.Imagebuilder.Model.ResourceState();
            Amazon.Imagebuilder.ResourceStatus requestState_state_Status = null;
            if (cmdletContext.State_Status != null)
            {
                requestState_state_Status = cmdletContext.State_Status;
            }
            if (requestState_state_Status != null)
            {
                request.State.Status = requestState_state_Status;
                requestStateIsNull = false;
            }
             // determine if request.State should be set to null
            if (requestStateIsNull)
            {
                request.State = null;
            }
            if (cmdletContext.UpdateAt != null)
            {
                request.UpdateAt = cmdletContext.UpdateAt.Value;
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
        
        private Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.StartResourceStateUpdateRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "StartResourceStateUpdate");
            try
            {
                return client.StartResourceStateUpdateAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? Amis_IsPublic { get; set; }
            public Amazon.Imagebuilder.LifecyclePolicyTimeUnit LastLaunched_Unit { get; set; }
            public System.Int32? LastLaunched_Value { get; set; }
            public List<System.String> Amis_Region { get; set; }
            public List<System.String> Amis_SharedAccount { get; set; }
            public Dictionary<System.String, System.String> Amis_TagMap { get; set; }
            public System.String ExecutionRole { get; set; }
            public System.Boolean? IncludeResources_Ami { get; set; }
            public System.Boolean? IncludeResources_Container { get; set; }
            public System.Boolean? IncludeResources_Snapshot { get; set; }
            public System.String ResourceArn { get; set; }
            public Amazon.Imagebuilder.ResourceStatus State_Status { get; set; }
            public System.DateTime? UpdateAt { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.StartResourceStateUpdateResponse, StartEC2IBResourceStateUpdateCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
