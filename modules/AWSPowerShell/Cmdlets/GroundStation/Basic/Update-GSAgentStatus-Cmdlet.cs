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
using Amazon.GroundStation;
using Amazon.GroundStation.Model;

namespace Amazon.PowerShell.Cmdlets.GS
{
    /// <summary>
    /// <note><para>
    ///  For use by AWS Ground Station Agent and shouldn't be called directly.
    /// </para></note><para>
    /// Update the status of the agent.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "GSAgentStatus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Ground Station UpdateAgentStatus API operation.", Operation = new[] {"UpdateAgentStatus"}, SelectReturnType = typeof(Amazon.GroundStation.Model.UpdateAgentStatusResponse))]
    [AWSCmdletOutput("System.String or Amazon.GroundStation.Model.UpdateAgentStatusResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GroundStation.Model.UpdateAgentStatusResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGSAgentStatusCmdlet : AmazonGroundStationClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AgentId
        /// <summary>
        /// <para>
        /// <para>UUID of agent to update.</para>
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
        public System.String AgentId { get; set; }
        #endregion
        
        #region Parameter ComponentStatus
        /// <summary>
        /// <para>
        /// <para>List of component statuses for agent.</para>
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
        [Alias("ComponentStatuses")]
        public Amazon.GroundStation.Model.ComponentStatusData[] ComponentStatus { get; set; }
        #endregion
        
        #region Parameter AggregateStatus_SignatureMap
        /// <summary>
        /// <para>
        /// <para>Sparse map of failure signatures.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AggregateStatus_SignatureMap { get; set; }
        #endregion
        
        #region Parameter AggregateStatus_Status
        /// <summary>
        /// <para>
        /// <para>Aggregate status.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.GroundStation.AgentStatus")]
        public Amazon.GroundStation.AgentStatus AggregateStatus_Status { get; set; }
        #endregion
        
        #region Parameter TaskId
        /// <summary>
        /// <para>
        /// <para>GUID of agent task.</para>
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
        public System.String TaskId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AgentId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GroundStation.Model.UpdateAgentStatusResponse).
        /// Specifying the name of a property of type Amazon.GroundStation.Model.UpdateAgentStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AgentId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AgentId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AgentId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AgentId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AgentId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GSAgentStatus (UpdateAgentStatus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GroundStation.Model.UpdateAgentStatusResponse, UpdateGSAgentStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AgentId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AgentId = this.AgentId;
            #if MODULAR
            if (this.AgentId == null && ParameterWasBound(nameof(this.AgentId)))
            {
                WriteWarning("You are passing $null as a value for parameter AgentId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AggregateStatus_SignatureMap != null)
            {
                context.AggregateStatus_SignatureMap = new Dictionary<System.String, System.Boolean>(StringComparer.Ordinal);
                foreach (var hashKey in this.AggregateStatus_SignatureMap.Keys)
                {
                    context.AggregateStatus_SignatureMap.Add((String)hashKey, (Boolean)(this.AggregateStatus_SignatureMap[hashKey]));
                }
            }
            context.AggregateStatus_Status = this.AggregateStatus_Status;
            #if MODULAR
            if (this.AggregateStatus_Status == null && ParameterWasBound(nameof(this.AggregateStatus_Status)))
            {
                WriteWarning("You are passing $null as a value for parameter AggregateStatus_Status which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ComponentStatus != null)
            {
                context.ComponentStatus = new List<Amazon.GroundStation.Model.ComponentStatusData>(this.ComponentStatus);
            }
            #if MODULAR
            if (this.ComponentStatus == null && ParameterWasBound(nameof(this.ComponentStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter ComponentStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskId = this.TaskId;
            #if MODULAR
            if (this.TaskId == null && ParameterWasBound(nameof(this.TaskId)))
            {
                WriteWarning("You are passing $null as a value for parameter TaskId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.GroundStation.Model.UpdateAgentStatusRequest();
            
            if (cmdletContext.AgentId != null)
            {
                request.AgentId = cmdletContext.AgentId;
            }
            
             // populate AggregateStatus
            var requestAggregateStatusIsNull = true;
            request.AggregateStatus = new Amazon.GroundStation.Model.AggregateStatus();
            Dictionary<System.String, System.Boolean> requestAggregateStatus_aggregateStatus_SignatureMap = null;
            if (cmdletContext.AggregateStatus_SignatureMap != null)
            {
                requestAggregateStatus_aggregateStatus_SignatureMap = cmdletContext.AggregateStatus_SignatureMap;
            }
            if (requestAggregateStatus_aggregateStatus_SignatureMap != null)
            {
                request.AggregateStatus.SignatureMap = requestAggregateStatus_aggregateStatus_SignatureMap;
                requestAggregateStatusIsNull = false;
            }
            Amazon.GroundStation.AgentStatus requestAggregateStatus_aggregateStatus_Status = null;
            if (cmdletContext.AggregateStatus_Status != null)
            {
                requestAggregateStatus_aggregateStatus_Status = cmdletContext.AggregateStatus_Status;
            }
            if (requestAggregateStatus_aggregateStatus_Status != null)
            {
                request.AggregateStatus.Status = requestAggregateStatus_aggregateStatus_Status;
                requestAggregateStatusIsNull = false;
            }
             // determine if request.AggregateStatus should be set to null
            if (requestAggregateStatusIsNull)
            {
                request.AggregateStatus = null;
            }
            if (cmdletContext.ComponentStatus != null)
            {
                request.ComponentStatuses = cmdletContext.ComponentStatus;
            }
            if (cmdletContext.TaskId != null)
            {
                request.TaskId = cmdletContext.TaskId;
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
        
        private Amazon.GroundStation.Model.UpdateAgentStatusResponse CallAWSServiceOperation(IAmazonGroundStation client, Amazon.GroundStation.Model.UpdateAgentStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Ground Station", "UpdateAgentStatus");
            try
            {
                #if DESKTOP
                return client.UpdateAgentStatus(request);
                #elif CORECLR
                return client.UpdateAgentStatusAsync(request).GetAwaiter().GetResult();
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
            public System.String AgentId { get; set; }
            public Dictionary<System.String, System.Boolean> AggregateStatus_SignatureMap { get; set; }
            public Amazon.GroundStation.AgentStatus AggregateStatus_Status { get; set; }
            public List<Amazon.GroundStation.Model.ComponentStatusData> ComponentStatus { get; set; }
            public System.String TaskId { get; set; }
            public System.Func<Amazon.GroundStation.Model.UpdateAgentStatusResponse, UpdateGSAgentStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AgentId;
        }
        
    }
}
