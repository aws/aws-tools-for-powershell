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
using Amazon.SSMIncidents;
using Amazon.SSMIncidents.Model;

namespace Amazon.PowerShell.Cmdlets.SSMI
{
    /// <summary>
    /// Updates a timeline event. You can update events of type <c>Custom Event</c>.
    /// </summary>
    [Cmdlet("Update", "SSMITimelineEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager Incident Manager UpdateTimelineEvent API operation.", Operation = new[] {"UpdateTimelineEvent"}, SelectReturnType = typeof(Amazon.SSMIncidents.Model.UpdateTimelineEventResponse))]
    [AWSCmdletOutput("None or Amazon.SSMIncidents.Model.UpdateTimelineEventResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SSMIncidents.Model.UpdateTimelineEventResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSMITimelineEventCmdlet : AmazonSSMIncidentsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventData
        /// <summary>
        /// <para>
        /// <para>A short description of the event.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventData { get; set; }
        #endregion
        
        #region Parameter EventId
        /// <summary>
        /// <para>
        /// <para>The ID of the event to update. You can use <c>ListTimelineEvents</c> to find an event's
        /// ID.</para>
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
        public System.String EventId { get; set; }
        #endregion
        
        #region Parameter EventReference
        /// <summary>
        /// <para>
        /// <para>Updates all existing references in a <c>TimelineEvent</c>. A reference is an Amazon
        /// Web Services resource involved or associated with the incident. To specify a reference,
        /// enter its Amazon Resource Name (ARN). You can also specify a related item associated
        /// with that resource. For example, to specify an Amazon DynamoDB (DynamoDB) table as
        /// a resource, use its ARN. You can also specify an Amazon CloudWatch metric associated
        /// with the DynamoDB table as a related item.</para><important><para>This update action overrides all existing references. If you want to keep existing
        /// references, you must specify them in the call. If you don't, this action removes any
        /// existing references and enters only new references.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EventReferences")]
        public Amazon.SSMIncidents.Model.EventReference[] EventReference { get; set; }
        #endregion
        
        #region Parameter EventTime
        /// <summary>
        /// <para>
        /// <para>The timestamp for when the event occurred.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EventTime { get; set; }
        #endregion
        
        #region Parameter EventType
        /// <summary>
        /// <para>
        /// <para>The type of event. You can update events of type <c>Custom Event</c> and <c>Note</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventType { get; set; }
        #endregion
        
        #region Parameter IncidentRecordArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the incident that includes the timeline event.</para>
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
        public System.String IncidentRecordArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A token that ensures that a client calls the operation only once with the specified
        /// details.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSMIncidents.Model.UpdateTimelineEventResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EventId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EventId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EventId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EventId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMITimelineEvent (UpdateTimelineEvent)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSMIncidents.Model.UpdateTimelineEventResponse, UpdateSSMITimelineEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EventId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.EventData = this.EventData;
            context.EventId = this.EventId;
            #if MODULAR
            if (this.EventId == null && ParameterWasBound(nameof(this.EventId)))
            {
                WriteWarning("You are passing $null as a value for parameter EventId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.EventReference != null)
            {
                context.EventReference = new List<Amazon.SSMIncidents.Model.EventReference>(this.EventReference);
            }
            context.EventTime = this.EventTime;
            context.EventType = this.EventType;
            context.IncidentRecordArn = this.IncidentRecordArn;
            #if MODULAR
            if (this.IncidentRecordArn == null && ParameterWasBound(nameof(this.IncidentRecordArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IncidentRecordArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSMIncidents.Model.UpdateTimelineEventRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.EventData != null)
            {
                request.EventData = cmdletContext.EventData;
            }
            if (cmdletContext.EventId != null)
            {
                request.EventId = cmdletContext.EventId;
            }
            if (cmdletContext.EventReference != null)
            {
                request.EventReferences = cmdletContext.EventReference;
            }
            if (cmdletContext.EventTime != null)
            {
                request.EventTime = cmdletContext.EventTime.Value;
            }
            if (cmdletContext.EventType != null)
            {
                request.EventType = cmdletContext.EventType;
            }
            if (cmdletContext.IncidentRecordArn != null)
            {
                request.IncidentRecordArn = cmdletContext.IncidentRecordArn;
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
        
        private Amazon.SSMIncidents.Model.UpdateTimelineEventResponse CallAWSServiceOperation(IAmazonSSMIncidents client, Amazon.SSMIncidents.Model.UpdateTimelineEventRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager Incident Manager", "UpdateTimelineEvent");
            try
            {
                #if DESKTOP
                return client.UpdateTimelineEvent(request);
                #elif CORECLR
                return client.UpdateTimelineEventAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String EventData { get; set; }
            public System.String EventId { get; set; }
            public List<Amazon.SSMIncidents.Model.EventReference> EventReference { get; set; }
            public System.DateTime? EventTime { get; set; }
            public System.String EventType { get; set; }
            public System.String IncidentRecordArn { get; set; }
            public System.Func<Amazon.SSMIncidents.Model.UpdateTimelineEventResponse, UpdateSSMITimelineEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
