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
using Amazon.BedrockAgentCore;
using Amazon.BedrockAgentCore.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.BAC
{
    /// <summary>
    /// Creates an event in an AgentCore Memory resource. Events represent interactions or
    /// activities that occur within a session and are associated with specific actors.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the <c>bedrock-agentcore:CreateEvent</c> permission.
    /// </para><para>
    /// This operation is subject to request rate limiting.
    /// </para>
    /// </summary>
    [Cmdlet("New", "BACEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCore.Model.Event")]
    [AWSCmdlet("Calls the Amazon Bedrock AgentCore Data Plane Fronting Layer CreateEvent API operation.", Operation = new[] {"CreateEvent"}, SelectReturnType = typeof(Amazon.BedrockAgentCore.Model.CreateEventResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCore.Model.Event or Amazon.BedrockAgentCore.Model.CreateEventResponse",
        "This cmdlet returns an Amazon.BedrockAgentCore.Model.Event object.",
        "The service call response (type Amazon.BedrockAgentCore.Model.CreateEventResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewBACEventCmdlet : AmazonBedrockAgentCoreClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ActorId
        /// <summary>
        /// <para>
        /// <para>The identifier of the actor associated with this event. An actor represents an entity
        /// that participates in sessions and generates events.</para>
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
        public System.String ActorId { get; set; }
        #endregion
        
        #region Parameter EventTimestamp
        /// <summary>
        /// <para>
        /// <para>The timestamp when the event occurred. If not specified, the current time is used.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? EventTimestamp { get; set; }
        #endregion
        
        #region Parameter MemoryId
        /// <summary>
        /// <para>
        /// <para>The identifier of the AgentCore Memory resource in which to create the event.</para>
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
        public System.String MemoryId { get; set; }
        #endregion
        
        #region Parameter Branch_Name
        /// <summary>
        /// <para>
        /// <para>The name of the branch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Branch_Name { get; set; }
        #endregion
        
        #region Parameter Payload
        /// <summary>
        /// <para>
        /// <para>The content payload of the event. This can include conversational data or binary content.</para><para />
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
        public Amazon.BedrockAgentCore.Model.PayloadType[] Payload { get; set; }
        #endregion
        
        #region Parameter Branch_RootEventId
        /// <summary>
        /// <para>
        /// <para>The identifier of the root event for this branch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Branch_RootEventId { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>The identifier of the session in which this event occurs. A session represents a sequence
        /// of related events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, AgentCore ignores the request,
        /// but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Event'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCore.Model.CreateEventResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCore.Model.CreateEventResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Event";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MemoryId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACEvent (CreateEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCore.Model.CreateEventResponse, NewBACEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActorId = this.ActorId;
            #if MODULAR
            if (this.ActorId == null && ParameterWasBound(nameof(this.ActorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Branch_Name = this.Branch_Name;
            context.Branch_RootEventId = this.Branch_RootEventId;
            context.ClientToken = this.ClientToken;
            context.EventTimestamp = this.EventTimestamp;
            #if MODULAR
            if (this.EventTimestamp == null && ParameterWasBound(nameof(this.EventTimestamp)))
            {
                WriteWarning("You are passing $null as a value for parameter EventTimestamp which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MemoryId = this.MemoryId;
            #if MODULAR
            if (this.MemoryId == null && ParameterWasBound(nameof(this.MemoryId)))
            {
                WriteWarning("You are passing $null as a value for parameter MemoryId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Payload != null)
            {
                context.Payload = new List<Amazon.BedrockAgentCore.Model.PayloadType>(this.Payload);
            }
            #if MODULAR
            if (this.Payload == null && ParameterWasBound(nameof(this.Payload)))
            {
                WriteWarning("You are passing $null as a value for parameter Payload which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionId = this.SessionId;
            
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
            var request = new Amazon.BedrockAgentCore.Model.CreateEventRequest();
            
            if (cmdletContext.ActorId != null)
            {
                request.ActorId = cmdletContext.ActorId;
            }
            
             // populate Branch
            var requestBranchIsNull = true;
            request.Branch = new Amazon.BedrockAgentCore.Model.Branch();
            System.String requestBranch_branch_Name = null;
            if (cmdletContext.Branch_Name != null)
            {
                requestBranch_branch_Name = cmdletContext.Branch_Name;
            }
            if (requestBranch_branch_Name != null)
            {
                request.Branch.Name = requestBranch_branch_Name;
                requestBranchIsNull = false;
            }
            System.String requestBranch_branch_RootEventId = null;
            if (cmdletContext.Branch_RootEventId != null)
            {
                requestBranch_branch_RootEventId = cmdletContext.Branch_RootEventId;
            }
            if (requestBranch_branch_RootEventId != null)
            {
                request.Branch.RootEventId = requestBranch_branch_RootEventId;
                requestBranchIsNull = false;
            }
             // determine if request.Branch should be set to null
            if (requestBranchIsNull)
            {
                request.Branch = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EventTimestamp != null)
            {
                request.EventTimestamp = cmdletContext.EventTimestamp.Value;
            }
            if (cmdletContext.MemoryId != null)
            {
                request.MemoryId = cmdletContext.MemoryId;
            }
            if (cmdletContext.Payload != null)
            {
                request.Payload = cmdletContext.Payload;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
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
        
        private Amazon.BedrockAgentCore.Model.CreateEventResponse CallAWSServiceOperation(IAmazonBedrockAgentCore client, Amazon.BedrockAgentCore.Model.CreateEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock AgentCore Data Plane Fronting Layer", "CreateEvent");
            try
            {
                return client.CreateEventAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ActorId { get; set; }
            public System.String Branch_Name { get; set; }
            public System.String Branch_RootEventId { get; set; }
            public System.String ClientToken { get; set; }
            public System.DateTime? EventTimestamp { get; set; }
            public System.String MemoryId { get; set; }
            public List<Amazon.BedrockAgentCore.Model.PayloadType> Payload { get; set; }
            public System.String SessionId { get; set; }
            public System.Func<Amazon.BedrockAgentCore.Model.CreateEventResponse, NewBACEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Event;
        }
        
    }
}
