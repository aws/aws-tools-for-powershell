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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Uploads a batch of log events to the specified log stream.
    /// 
    ///  <important><para>
    /// The sequence token is now ignored in <c>PutLogEvents</c> actions. <c>PutLogEvents</c>
    /// actions are always accepted and never return <c>InvalidSequenceTokenException</c>
    /// or <c>DataAlreadyAcceptedException</c> even if the sequence token is not valid. You
    /// can use parallel <c>PutLogEvents</c> actions on the same log stream. 
    /// </para></important><para>
    /// The batch of events must satisfy the following constraints:
    /// </para><ul><li><para>
    /// The maximum batch size is 1,048,576 bytes. This size is calculated as the sum of all
    /// event messages in UTF-8, plus 26 bytes for each log event.
    /// </para></li><li><para>
    /// None of the log events in the batch can be more than 2 hours in the future.
    /// </para></li><li><para>
    /// None of the log events in the batch can be more than 14 days in the past. Also, none
    /// of the log events can be from earlier than the retention period of the log group.
    /// </para></li><li><para>
    /// The log events in the batch must be in chronological order by their timestamp. The
    /// timestamp is the time that the event occurred, expressed as the number of milliseconds
    /// after <c>Jan 1, 1970 00:00:00 UTC</c>. (In Amazon Web Services Tools for PowerShell
    /// and the Amazon Web Services SDK for .NET, the timestamp is specified in .NET format:
    /// <c>yyyy-mm-ddThh:mm:ss</c>. For example, <c>2017-09-15T13:45:30</c>.) 
    /// </para></li><li><para>
    /// A batch of log events in a single request cannot span more than 24 hours. Otherwise,
    /// the operation fails.
    /// </para></li><li><para>
    /// Each log event can be no larger than 256 KB.
    /// </para></li><li><para>
    /// The maximum number of log events in a batch is 10,000.
    /// </para></li><li><important><para>
    /// The quota of five requests per second per log stream has been removed. Instead, <c>PutLogEvents</c>
    /// actions are throttled based on a per-second per-account quota. You can request an
    /// increase to the per-second throttling quota by using the Service Quotas service.
    /// </para></important></li></ul><para>
    /// If a call to <c>PutLogEvents</c> returns "UnrecognizedClientException" the most likely
    /// cause is a non-valid Amazon Web Services access key ID or secret key. 
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLLogEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutLogEvents API operation.", Operation = new[] {"PutLogEvents"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutLogEventsResponse), LegacyAlias="Write-CWLLogEvents")]
    [AWSCmdletOutput("System.String or Amazon.CloudWatchLogs.Model.PutLogEventsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutLogEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLLogEventCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Entity_Attribute
        /// <summary>
        /// <para>
        /// <para>Additional attributes of the entity that are not used to specify the identity of the
        /// entity. A list of key-value pairs.</para><para>For details about how to use the attributes, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/adding-your-own-related-telemetry.html">How
        /// to add related information to telemetry</a> in the <i>CloudWatch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Entity_Attributes")]
        public System.Collections.Hashtable Entity_Attribute { get; set; }
        #endregion
        
        #region Parameter Entity_KeyAttribute
        /// <summary>
        /// <para>
        /// <para>The attributes of the entity which identify the specific entity, as a list of key-value
        /// pairs. Entities with the same <c>keyAttributes</c> are considered to be the same entity.</para><para>There are five allowed attributes (key names): <c>Type</c>, <c>ResourceType</c>, <c>Identifier</c><c>Name</c>, and <c>Environment</c>.</para><para>For details about how to use the key attributes, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/adding-your-own-related-telemetry.html">How
        /// to add related information to telemetry</a> in the <i>CloudWatch User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Entity_KeyAttributes")]
        public System.Collections.Hashtable Entity_KeyAttribute { get; set; }
        #endregion
        
        #region Parameter LogEvent
        /// <summary>
        /// <para>
        /// <para>The log events.</para>
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
        [Alias("LogEvents")]
        public Amazon.CloudWatchLogs.Model.InputLogEvent[] LogEvent { get; set; }
        #endregion
        
        #region Parameter LogGroupName
        /// <summary>
        /// <para>
        /// <para>The name of the log group.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LogGroupName { get; set; }
        #endregion
        
        #region Parameter LogStreamName
        /// <summary>
        /// <para>
        /// <para>The name of the log stream.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String LogStreamName { get; set; }
        #endregion
        
        #region Parameter SequenceToken
        /// <summary>
        /// <para>
        /// <para>The sequence token obtained from the response of the previous <c>PutLogEvents</c>
        /// call.</para><important><para>The <c>sequenceToken</c> parameter is now ignored in <c>PutLogEvents</c> actions.
        /// <c>PutLogEvents</c> actions are now accepted and never return <c>InvalidSequenceTokenException</c>
        /// or <c>DataAlreadyAcceptedException</c> even if the sequence token is not valid.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SequenceToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NextSequenceToken'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutLogEventsResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.PutLogEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NextSequenceToken";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogStreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLLogEvent (PutLogEvents)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutLogEventsResponse, WriteCWLLogEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Entity_Attribute != null)
            {
                context.Entity_Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Entity_Attribute.Keys)
                {
                    context.Entity_Attribute.Add((String)hashKey, (System.String)(this.Entity_Attribute[hashKey]));
                }
            }
            if (this.Entity_KeyAttribute != null)
            {
                context.Entity_KeyAttribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Entity_KeyAttribute.Keys)
                {
                    context.Entity_KeyAttribute.Add((String)hashKey, (System.String)(this.Entity_KeyAttribute[hashKey]));
                }
            }
            if (this.LogEvent != null)
            {
                context.LogEvent = new List<Amazon.CloudWatchLogs.Model.InputLogEvent>(this.LogEvent);
            }
            #if MODULAR
            if (this.LogEvent == null && ParameterWasBound(nameof(this.LogEvent)))
            {
                WriteWarning("You are passing $null as a value for parameter LogEvent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogGroupName = this.LogGroupName;
            #if MODULAR
            if (this.LogGroupName == null && ParameterWasBound(nameof(this.LogGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LogStreamName = this.LogStreamName;
            #if MODULAR
            if (this.LogStreamName == null && ParameterWasBound(nameof(this.LogStreamName)))
            {
                WriteWarning("You are passing $null as a value for parameter LogStreamName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SequenceToken = this.SequenceToken;
            
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
            var request = new Amazon.CloudWatchLogs.Model.PutLogEventsRequest();
            
            
             // populate Entity
            var requestEntityIsNull = true;
            request.Entity = new Amazon.CloudWatchLogs.Model.Entity();
            Dictionary<System.String, System.String> requestEntity_entity_Attribute = null;
            if (cmdletContext.Entity_Attribute != null)
            {
                requestEntity_entity_Attribute = cmdletContext.Entity_Attribute;
            }
            if (requestEntity_entity_Attribute != null)
            {
                request.Entity.Attributes = requestEntity_entity_Attribute;
                requestEntityIsNull = false;
            }
            Dictionary<System.String, System.String> requestEntity_entity_KeyAttribute = null;
            if (cmdletContext.Entity_KeyAttribute != null)
            {
                requestEntity_entity_KeyAttribute = cmdletContext.Entity_KeyAttribute;
            }
            if (requestEntity_entity_KeyAttribute != null)
            {
                request.Entity.KeyAttributes = requestEntity_entity_KeyAttribute;
                requestEntityIsNull = false;
            }
             // determine if request.Entity should be set to null
            if (requestEntityIsNull)
            {
                request.Entity = null;
            }
            if (cmdletContext.LogEvent != null)
            {
                request.LogEvents = cmdletContext.LogEvent;
            }
            if (cmdletContext.LogGroupName != null)
            {
                request.LogGroupName = cmdletContext.LogGroupName;
            }
            if (cmdletContext.LogStreamName != null)
            {
                request.LogStreamName = cmdletContext.LogStreamName;
            }
            if (cmdletContext.SequenceToken != null)
            {
                request.SequenceToken = cmdletContext.SequenceToken;
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
        
        private Amazon.CloudWatchLogs.Model.PutLogEventsResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutLogEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutLogEvents");
            try
            {
                #if DESKTOP
                return client.PutLogEvents(request);
                #elif CORECLR
                return client.PutLogEventsAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Entity_Attribute { get; set; }
            public Dictionary<System.String, System.String> Entity_KeyAttribute { get; set; }
            public List<Amazon.CloudWatchLogs.Model.InputLogEvent> LogEvent { get; set; }
            public System.String LogGroupName { get; set; }
            public System.String LogStreamName { get; set; }
            public System.String SequenceToken { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutLogEventsResponse, WriteCWLLogEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NextSequenceToken;
        }
        
    }
}
