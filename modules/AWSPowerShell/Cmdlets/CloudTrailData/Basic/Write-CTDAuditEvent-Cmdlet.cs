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
using Amazon.CloudTrailData;
using Amazon.CloudTrailData.Model;

namespace Amazon.PowerShell.Cmdlets.CTD
{
    /// <summary>
    /// Ingests your application events into CloudTrail Lake. A required parameter, <c>auditEvents</c>,
    /// accepts the JSON records (also called <i>payload</i>) of events that you want CloudTrail
    /// to ingest. You can add up to 100 of these events (or up to 1 MB) per <c>PutAuditEvents</c>
    /// request.
    /// </summary>
    [Cmdlet("Write", "CTDAuditEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudTrailData.Model.PutAuditEventsResponse")]
    [AWSCmdlet("Calls the AWS CloudTrail Data Service PutAuditEvents API operation.", Operation = new[] {"PutAuditEvents"}, SelectReturnType = typeof(Amazon.CloudTrailData.Model.PutAuditEventsResponse))]
    [AWSCmdletOutput("Amazon.CloudTrailData.Model.PutAuditEventsResponse",
        "This cmdlet returns an Amazon.CloudTrailData.Model.PutAuditEventsResponse object containing multiple properties."
    )]
    public partial class WriteCTDAuditEventCmdlet : AmazonCloudTrailDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AuditEvent
        /// <summary>
        /// <para>
        /// <para>The JSON payload of events that you want to ingest. You can also point to the JSON
        /// event payload in a file.</para>
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
        [Alias("AuditEvents")]
        public Amazon.CloudTrailData.Model.AuditEvent[] AuditEvent { get; set; }
        #endregion
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para>The ARN or ID (the ARN suffix) of a channel.</para>
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
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter ExternalId
        /// <summary>
        /// <para>
        /// <para>A unique identifier that is conditionally required when the channel's resource policy
        /// includes an external ID. This value can be any string, such as a passphrase or account
        /// number.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExternalId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudTrailData.Model.PutAuditEventsResponse).
        /// Specifying the name of a property of type Amazon.CloudTrailData.Model.PutAuditEventsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CTDAuditEvent (PutAuditEvents)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudTrailData.Model.PutAuditEventsResponse, WriteCTDAuditEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AuditEvent != null)
            {
                context.AuditEvent = new List<Amazon.CloudTrailData.Model.AuditEvent>(this.AuditEvent);
            }
            #if MODULAR
            if (this.AuditEvent == null && ParameterWasBound(nameof(this.AuditEvent)))
            {
                WriteWarning("You are passing $null as a value for parameter AuditEvent which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelArn = this.ChannelArn;
            #if MODULAR
            if (this.ChannelArn == null && ParameterWasBound(nameof(this.ChannelArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExternalId = this.ExternalId;
            
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
            var request = new Amazon.CloudTrailData.Model.PutAuditEventsRequest();
            
            if (cmdletContext.AuditEvent != null)
            {
                request.AuditEvents = cmdletContext.AuditEvent;
            }
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            if (cmdletContext.ExternalId != null)
            {
                request.ExternalId = cmdletContext.ExternalId;
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
        
        private Amazon.CloudTrailData.Model.PutAuditEventsResponse CallAWSServiceOperation(IAmazonCloudTrailData client, Amazon.CloudTrailData.Model.PutAuditEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CloudTrail Data Service", "PutAuditEvents");
            try
            {
                return client.PutAuditEventsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CloudTrailData.Model.AuditEvent> AuditEvent { get; set; }
            public System.String ChannelArn { get; set; }
            public System.String ExternalId { get; set; }
            public System.Func<Amazon.CloudTrailData.Model.PutAuditEventsResponse, WriteCTDAuditEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
