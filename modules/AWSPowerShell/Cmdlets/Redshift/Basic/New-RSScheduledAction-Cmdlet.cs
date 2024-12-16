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
using Amazon.Redshift;
using Amazon.Redshift.Model;

namespace Amazon.PowerShell.Cmdlets.RS
{
    /// <summary>
    /// Creates a scheduled action. A scheduled action contains a schedule and an Amazon Redshift
    /// API action. For example, you can create a schedule of when to run the <c>ResizeCluster</c>
    /// API operation.
    /// </summary>
    [Cmdlet("New", "RSScheduledAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Redshift.Model.CreateScheduledActionResponse")]
    [AWSCmdlet("Calls the Amazon Redshift CreateScheduledAction API operation.", Operation = new[] {"CreateScheduledAction"}, SelectReturnType = typeof(Amazon.Redshift.Model.CreateScheduledActionResponse))]
    [AWSCmdletOutput("Amazon.Redshift.Model.CreateScheduledActionResponse",
        "This cmdlet returns an Amazon.Redshift.Model.CreateScheduledActionResponse object containing multiple properties."
    )]
    public partial class NewRSScheduledActionCmdlet : AmazonRedshiftClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ResizeCluster_Classic
        /// <summary>
        /// <para>
        /// <para>A boolean value indicating whether the resize operation is using the classic resize
        /// process. If you don't provide this parameter or set the value to <c>false</c>, the
        /// resize type is elastic. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_ResizeCluster_Classic")]
        public System.Boolean? ResizeCluster_Classic { get; set; }
        #endregion
        
        #region Parameter PauseCluster_ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster to be paused.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_PauseCluster_ClusterIdentifier")]
        public System.String PauseCluster_ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ResizeCluster_ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the cluster to resize.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_ResizeCluster_ClusterIdentifier")]
        public System.String ResizeCluster_ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ResumeCluster_ClusterIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the cluster to be resumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_ResumeCluster_ClusterIdentifier")]
        public System.String ResumeCluster_ClusterIdentifier { get; set; }
        #endregion
        
        #region Parameter ResizeCluster_ClusterType
        /// <summary>
        /// <para>
        /// <para>The new cluster type for the specified cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_ResizeCluster_ClusterType")]
        public System.String ResizeCluster_ClusterType { get; set; }
        #endregion
        
        #region Parameter Enable
        /// <summary>
        /// <para>
        /// <para>If true, the schedule is enabled. If false, the scheduled action does not trigger.
        /// For more information about <c>state</c> of the scheduled action, see <a>ScheduledAction</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enable { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end time in UTC of the scheduled action. After this time, the scheduled action
        /// does not trigger. For more information about this parameter, see <a>ScheduledAction</a>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter IamRole
        /// <summary>
        /// <para>
        /// <para>The IAM role to assume to run the target action. For more information about this parameter,
        /// see <a>ScheduledAction</a>. </para>
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
        public System.String IamRole { get; set; }
        #endregion
        
        #region Parameter ResizeCluster_NodeType
        /// <summary>
        /// <para>
        /// <para>The new node type for the nodes you are adding. If not specified, the cluster's current
        /// node type is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_ResizeCluster_NodeType")]
        public System.String ResizeCluster_NodeType { get; set; }
        #endregion
        
        #region Parameter ResizeCluster_NumberOfNode
        /// <summary>
        /// <para>
        /// <para>The new number of nodes for the cluster. If not specified, the cluster's current number
        /// of nodes is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_ResizeCluster_NumberOfNodes")]
        public System.Int32? ResizeCluster_NumberOfNode { get; set; }
        #endregion
        
        #region Parameter ResizeCluster_ReservedNodeId
        /// <summary>
        /// <para>
        /// <para>The identifier of the reserved node.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_ResizeCluster_ReservedNodeId")]
        public System.String ResizeCluster_ReservedNodeId { get; set; }
        #endregion
        
        #region Parameter Schedule
        /// <summary>
        /// <para>
        /// <para>The schedule in <c>at( )</c> or <c>cron( )</c> format. For more information about
        /// this parameter, see <a>ScheduledAction</a>.</para>
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
        public System.String Schedule { get; set; }
        #endregion
        
        #region Parameter ScheduledActionDescription
        /// <summary>
        /// <para>
        /// <para>The description of the scheduled action. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledActionDescription { get; set; }
        #endregion
        
        #region Parameter ScheduledActionName
        /// <summary>
        /// <para>
        /// <para>The name of the scheduled action. The name must be unique within an account. For more
        /// information about this parameter, see <a>ScheduledAction</a>. </para>
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
        public System.String ScheduledActionName { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start time in UTC of the scheduled action. Before this time, the scheduled action
        /// does not trigger. For more information about this parameter, see <a>ScheduledAction</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter ResizeCluster_TargetReservedNodeOfferingId
        /// <summary>
        /// <para>
        /// <para>The identifier of the target reserved node offering.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_ResizeCluster_TargetReservedNodeOfferingId")]
        public System.String ResizeCluster_TargetReservedNodeOfferingId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Redshift.Model.CreateScheduledActionResponse).
        /// Specifying the name of a property of type Amazon.Redshift.Model.CreateScheduledActionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduledActionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-RSScheduledAction (CreateScheduledAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Redshift.Model.CreateScheduledActionResponse, NewRSScheduledActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Enable = this.Enable;
            context.EndTime = this.EndTime;
            context.IamRole = this.IamRole;
            #if MODULAR
            if (this.IamRole == null && ParameterWasBound(nameof(this.IamRole)))
            {
                WriteWarning("You are passing $null as a value for parameter IamRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule = this.Schedule;
            #if MODULAR
            if (this.Schedule == null && ParameterWasBound(nameof(this.Schedule)))
            {
                WriteWarning("You are passing $null as a value for parameter Schedule which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduledActionDescription = this.ScheduledActionDescription;
            context.ScheduledActionName = this.ScheduledActionName;
            #if MODULAR
            if (this.ScheduledActionName == null && ParameterWasBound(nameof(this.ScheduledActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            context.PauseCluster_ClusterIdentifier = this.PauseCluster_ClusterIdentifier;
            context.ResizeCluster_Classic = this.ResizeCluster_Classic;
            context.ResizeCluster_ClusterIdentifier = this.ResizeCluster_ClusterIdentifier;
            context.ResizeCluster_ClusterType = this.ResizeCluster_ClusterType;
            context.ResizeCluster_NodeType = this.ResizeCluster_NodeType;
            context.ResizeCluster_NumberOfNode = this.ResizeCluster_NumberOfNode;
            context.ResizeCluster_ReservedNodeId = this.ResizeCluster_ReservedNodeId;
            context.ResizeCluster_TargetReservedNodeOfferingId = this.ResizeCluster_TargetReservedNodeOfferingId;
            context.ResumeCluster_ClusterIdentifier = this.ResumeCluster_ClusterIdentifier;
            
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
            var request = new Amazon.Redshift.Model.CreateScheduledActionRequest();
            
            if (cmdletContext.Enable != null)
            {
                request.Enable = cmdletContext.Enable.Value;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.IamRole != null)
            {
                request.IamRole = cmdletContext.IamRole;
            }
            if (cmdletContext.Schedule != null)
            {
                request.Schedule = cmdletContext.Schedule;
            }
            if (cmdletContext.ScheduledActionDescription != null)
            {
                request.ScheduledActionDescription = cmdletContext.ScheduledActionDescription;
            }
            if (cmdletContext.ScheduledActionName != null)
            {
                request.ScheduledActionName = cmdletContext.ScheduledActionName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
             // populate TargetAction
            var requestTargetActionIsNull = true;
            request.TargetAction = new Amazon.Redshift.Model.ScheduledActionType();
            Amazon.Redshift.Model.PauseClusterMessage requestTargetAction_targetAction_PauseCluster = null;
            
             // populate PauseCluster
            var requestTargetAction_targetAction_PauseClusterIsNull = true;
            requestTargetAction_targetAction_PauseCluster = new Amazon.Redshift.Model.PauseClusterMessage();
            System.String requestTargetAction_targetAction_PauseCluster_pauseCluster_ClusterIdentifier = null;
            if (cmdletContext.PauseCluster_ClusterIdentifier != null)
            {
                requestTargetAction_targetAction_PauseCluster_pauseCluster_ClusterIdentifier = cmdletContext.PauseCluster_ClusterIdentifier;
            }
            if (requestTargetAction_targetAction_PauseCluster_pauseCluster_ClusterIdentifier != null)
            {
                requestTargetAction_targetAction_PauseCluster.ClusterIdentifier = requestTargetAction_targetAction_PauseCluster_pauseCluster_ClusterIdentifier;
                requestTargetAction_targetAction_PauseClusterIsNull = false;
            }
             // determine if requestTargetAction_targetAction_PauseCluster should be set to null
            if (requestTargetAction_targetAction_PauseClusterIsNull)
            {
                requestTargetAction_targetAction_PauseCluster = null;
            }
            if (requestTargetAction_targetAction_PauseCluster != null)
            {
                request.TargetAction.PauseCluster = requestTargetAction_targetAction_PauseCluster;
                requestTargetActionIsNull = false;
            }
            Amazon.Redshift.Model.ResumeClusterMessage requestTargetAction_targetAction_ResumeCluster = null;
            
             // populate ResumeCluster
            var requestTargetAction_targetAction_ResumeClusterIsNull = true;
            requestTargetAction_targetAction_ResumeCluster = new Amazon.Redshift.Model.ResumeClusterMessage();
            System.String requestTargetAction_targetAction_ResumeCluster_resumeCluster_ClusterIdentifier = null;
            if (cmdletContext.ResumeCluster_ClusterIdentifier != null)
            {
                requestTargetAction_targetAction_ResumeCluster_resumeCluster_ClusterIdentifier = cmdletContext.ResumeCluster_ClusterIdentifier;
            }
            if (requestTargetAction_targetAction_ResumeCluster_resumeCluster_ClusterIdentifier != null)
            {
                requestTargetAction_targetAction_ResumeCluster.ClusterIdentifier = requestTargetAction_targetAction_ResumeCluster_resumeCluster_ClusterIdentifier;
                requestTargetAction_targetAction_ResumeClusterIsNull = false;
            }
             // determine if requestTargetAction_targetAction_ResumeCluster should be set to null
            if (requestTargetAction_targetAction_ResumeClusterIsNull)
            {
                requestTargetAction_targetAction_ResumeCluster = null;
            }
            if (requestTargetAction_targetAction_ResumeCluster != null)
            {
                request.TargetAction.ResumeCluster = requestTargetAction_targetAction_ResumeCluster;
                requestTargetActionIsNull = false;
            }
            Amazon.Redshift.Model.ResizeClusterMessage requestTargetAction_targetAction_ResizeCluster = null;
            
             // populate ResizeCluster
            var requestTargetAction_targetAction_ResizeClusterIsNull = true;
            requestTargetAction_targetAction_ResizeCluster = new Amazon.Redshift.Model.ResizeClusterMessage();
            System.Boolean? requestTargetAction_targetAction_ResizeCluster_resizeCluster_Classic = null;
            if (cmdletContext.ResizeCluster_Classic != null)
            {
                requestTargetAction_targetAction_ResizeCluster_resizeCluster_Classic = cmdletContext.ResizeCluster_Classic.Value;
            }
            if (requestTargetAction_targetAction_ResizeCluster_resizeCluster_Classic != null)
            {
                requestTargetAction_targetAction_ResizeCluster.Classic = requestTargetAction_targetAction_ResizeCluster_resizeCluster_Classic.Value;
                requestTargetAction_targetAction_ResizeClusterIsNull = false;
            }
            System.String requestTargetAction_targetAction_ResizeCluster_resizeCluster_ClusterIdentifier = null;
            if (cmdletContext.ResizeCluster_ClusterIdentifier != null)
            {
                requestTargetAction_targetAction_ResizeCluster_resizeCluster_ClusterIdentifier = cmdletContext.ResizeCluster_ClusterIdentifier;
            }
            if (requestTargetAction_targetAction_ResizeCluster_resizeCluster_ClusterIdentifier != null)
            {
                requestTargetAction_targetAction_ResizeCluster.ClusterIdentifier = requestTargetAction_targetAction_ResizeCluster_resizeCluster_ClusterIdentifier;
                requestTargetAction_targetAction_ResizeClusterIsNull = false;
            }
            System.String requestTargetAction_targetAction_ResizeCluster_resizeCluster_ClusterType = null;
            if (cmdletContext.ResizeCluster_ClusterType != null)
            {
                requestTargetAction_targetAction_ResizeCluster_resizeCluster_ClusterType = cmdletContext.ResizeCluster_ClusterType;
            }
            if (requestTargetAction_targetAction_ResizeCluster_resizeCluster_ClusterType != null)
            {
                requestTargetAction_targetAction_ResizeCluster.ClusterType = requestTargetAction_targetAction_ResizeCluster_resizeCluster_ClusterType;
                requestTargetAction_targetAction_ResizeClusterIsNull = false;
            }
            System.String requestTargetAction_targetAction_ResizeCluster_resizeCluster_NodeType = null;
            if (cmdletContext.ResizeCluster_NodeType != null)
            {
                requestTargetAction_targetAction_ResizeCluster_resizeCluster_NodeType = cmdletContext.ResizeCluster_NodeType;
            }
            if (requestTargetAction_targetAction_ResizeCluster_resizeCluster_NodeType != null)
            {
                requestTargetAction_targetAction_ResizeCluster.NodeType = requestTargetAction_targetAction_ResizeCluster_resizeCluster_NodeType;
                requestTargetAction_targetAction_ResizeClusterIsNull = false;
            }
            System.Int32? requestTargetAction_targetAction_ResizeCluster_resizeCluster_NumberOfNode = null;
            if (cmdletContext.ResizeCluster_NumberOfNode != null)
            {
                requestTargetAction_targetAction_ResizeCluster_resizeCluster_NumberOfNode = cmdletContext.ResizeCluster_NumberOfNode.Value;
            }
            if (requestTargetAction_targetAction_ResizeCluster_resizeCluster_NumberOfNode != null)
            {
                requestTargetAction_targetAction_ResizeCluster.NumberOfNodes = requestTargetAction_targetAction_ResizeCluster_resizeCluster_NumberOfNode.Value;
                requestTargetAction_targetAction_ResizeClusterIsNull = false;
            }
            System.String requestTargetAction_targetAction_ResizeCluster_resizeCluster_ReservedNodeId = null;
            if (cmdletContext.ResizeCluster_ReservedNodeId != null)
            {
                requestTargetAction_targetAction_ResizeCluster_resizeCluster_ReservedNodeId = cmdletContext.ResizeCluster_ReservedNodeId;
            }
            if (requestTargetAction_targetAction_ResizeCluster_resizeCluster_ReservedNodeId != null)
            {
                requestTargetAction_targetAction_ResizeCluster.ReservedNodeId = requestTargetAction_targetAction_ResizeCluster_resizeCluster_ReservedNodeId;
                requestTargetAction_targetAction_ResizeClusterIsNull = false;
            }
            System.String requestTargetAction_targetAction_ResizeCluster_resizeCluster_TargetReservedNodeOfferingId = null;
            if (cmdletContext.ResizeCluster_TargetReservedNodeOfferingId != null)
            {
                requestTargetAction_targetAction_ResizeCluster_resizeCluster_TargetReservedNodeOfferingId = cmdletContext.ResizeCluster_TargetReservedNodeOfferingId;
            }
            if (requestTargetAction_targetAction_ResizeCluster_resizeCluster_TargetReservedNodeOfferingId != null)
            {
                requestTargetAction_targetAction_ResizeCluster.TargetReservedNodeOfferingId = requestTargetAction_targetAction_ResizeCluster_resizeCluster_TargetReservedNodeOfferingId;
                requestTargetAction_targetAction_ResizeClusterIsNull = false;
            }
             // determine if requestTargetAction_targetAction_ResizeCluster should be set to null
            if (requestTargetAction_targetAction_ResizeClusterIsNull)
            {
                requestTargetAction_targetAction_ResizeCluster = null;
            }
            if (requestTargetAction_targetAction_ResizeCluster != null)
            {
                request.TargetAction.ResizeCluster = requestTargetAction_targetAction_ResizeCluster;
                requestTargetActionIsNull = false;
            }
             // determine if request.TargetAction should be set to null
            if (requestTargetActionIsNull)
            {
                request.TargetAction = null;
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
        
        private Amazon.Redshift.Model.CreateScheduledActionResponse CallAWSServiceOperation(IAmazonRedshift client, Amazon.Redshift.Model.CreateScheduledActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Redshift", "CreateScheduledAction");
            try
            {
                #if DESKTOP
                return client.CreateScheduledAction(request);
                #elif CORECLR
                return client.CreateScheduledActionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enable { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String IamRole { get; set; }
            public System.String Schedule { get; set; }
            public System.String ScheduledActionDescription { get; set; }
            public System.String ScheduledActionName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String PauseCluster_ClusterIdentifier { get; set; }
            public System.Boolean? ResizeCluster_Classic { get; set; }
            public System.String ResizeCluster_ClusterIdentifier { get; set; }
            public System.String ResizeCluster_ClusterType { get; set; }
            public System.String ResizeCluster_NodeType { get; set; }
            public System.Int32? ResizeCluster_NumberOfNode { get; set; }
            public System.String ResizeCluster_ReservedNodeId { get; set; }
            public System.String ResizeCluster_TargetReservedNodeOfferingId { get; set; }
            public System.String ResumeCluster_ClusterIdentifier { get; set; }
            public System.Func<Amazon.Redshift.Model.CreateScheduledActionResponse, NewRSScheduledActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
