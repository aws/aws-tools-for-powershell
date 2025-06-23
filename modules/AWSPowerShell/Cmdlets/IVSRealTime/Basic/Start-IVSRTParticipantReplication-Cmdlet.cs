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
using Amazon.IVSRealTime;
using Amazon.IVSRealTime.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IVSRT
{
    /// <summary>
    /// Starts replicating a publishing participant from a source stage to a destination stage.
    /// </summary>
    [Cmdlet("Start", "IVSRTParticipantReplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IVSRealTime.Model.StartParticipantReplicationResponse")]
    [AWSCmdlet("Calls the Amazon Interactive Video Service RealTime StartParticipantReplication API operation.", Operation = new[] {"StartParticipantReplication"}, SelectReturnType = typeof(Amazon.IVSRealTime.Model.StartParticipantReplicationResponse))]
    [AWSCmdletOutput("Amazon.IVSRealTime.Model.StartParticipantReplicationResponse",
        "This cmdlet returns an Amazon.IVSRealTime.Model.StartParticipantReplicationResponse object containing multiple properties."
    )]
    public partial class StartIVSRTParticipantReplicationCmdlet : AmazonIVSRealTimeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Attribute
        /// <summary>
        /// <para>
        /// <para>Application-provided attributes to set on the replicated participant in the destination
        /// stage. Map keys and values can contain UTF-8 encoded text. The maximum length of this
        /// field is 1 KB total. <i>This field is exposed to all stage participants and should
        /// not be used for personally identifying, confidential, or sensitive information.</i></para><para>These attributes are merged with any attributes set for this participant when creating
        /// the token. If there is overlap in keys, the values in these attributes are replaced.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Attributes")]
        public System.Collections.Hashtable Attribute { get; set; }
        #endregion
        
        #region Parameter DestinationStageArn
        /// <summary>
        /// <para>
        /// <para>ARN of the stage to which the participant will be replicated.</para>
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
        public System.String DestinationStageArn { get; set; }
        #endregion
        
        #region Parameter ParticipantId
        /// <summary>
        /// <para>
        /// <para>Participant ID of the publisher that will be replicated. This is assigned by IVS and
        /// returned by <a>CreateParticipantToken</a> or the <c>jti</c> (JWT ID) used to <a href="https://docs.aws.amazon.com/ivs/latest/RealTimeUserGuide/getting-started-distribute-tokens.html#getting-started-distribute-tokens-self-signed">create
        /// a self signed token</a>. </para>
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
        public System.String ParticipantId { get; set; }
        #endregion
        
        #region Parameter ReconnectWindowSecond
        /// <summary>
        /// <para>
        /// <para>If the participant disconnects and then reconnects within the specified interval,
        /// replication will continue to be <c>ACTIVE</c>. Default: 0.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReconnectWindowSeconds")]
        public System.Int32? ReconnectWindowSecond { get; set; }
        #endregion
        
        #region Parameter SourceStageArn
        /// <summary>
        /// <para>
        /// <para>ARN of the stage where the participant is publishing.</para>
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
        public System.String SourceStageArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IVSRealTime.Model.StartParticipantReplicationResponse).
        /// Specifying the name of a property of type Amazon.IVSRealTime.Model.StartParticipantReplicationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IVSRTParticipantReplication (StartParticipantReplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IVSRealTime.Model.StartParticipantReplicationResponse, StartIVSRTParticipantReplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Attribute != null)
            {
                context.Attribute = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Attribute.Keys)
                {
                    context.Attribute.Add((String)hashKey, (System.String)(this.Attribute[hashKey]));
                }
            }
            context.DestinationStageArn = this.DestinationStageArn;
            #if MODULAR
            if (this.DestinationStageArn == null && ParameterWasBound(nameof(this.DestinationStageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationStageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParticipantId = this.ParticipantId;
            #if MODULAR
            if (this.ParticipantId == null && ParameterWasBound(nameof(this.ParticipantId)))
            {
                WriteWarning("You are passing $null as a value for parameter ParticipantId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReconnectWindowSecond = this.ReconnectWindowSecond;
            context.SourceStageArn = this.SourceStageArn;
            #if MODULAR
            if (this.SourceStageArn == null && ParameterWasBound(nameof(this.SourceStageArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceStageArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IVSRealTime.Model.StartParticipantReplicationRequest();
            
            if (cmdletContext.Attribute != null)
            {
                request.Attributes = cmdletContext.Attribute;
            }
            if (cmdletContext.DestinationStageArn != null)
            {
                request.DestinationStageArn = cmdletContext.DestinationStageArn;
            }
            if (cmdletContext.ParticipantId != null)
            {
                request.ParticipantId = cmdletContext.ParticipantId;
            }
            if (cmdletContext.ReconnectWindowSecond != null)
            {
                request.ReconnectWindowSeconds = cmdletContext.ReconnectWindowSecond.Value;
            }
            if (cmdletContext.SourceStageArn != null)
            {
                request.SourceStageArn = cmdletContext.SourceStageArn;
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
        
        private Amazon.IVSRealTime.Model.StartParticipantReplicationResponse CallAWSServiceOperation(IAmazonIVSRealTime client, Amazon.IVSRealTime.Model.StartParticipantReplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Interactive Video Service RealTime", "StartParticipantReplication");
            try
            {
                return client.StartParticipantReplicationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Attribute { get; set; }
            public System.String DestinationStageArn { get; set; }
            public System.String ParticipantId { get; set; }
            public System.Int32? ReconnectWindowSecond { get; set; }
            public System.String SourceStageArn { get; set; }
            public System.Func<Amazon.IVSRealTime.Model.StartParticipantReplicationResponse, StartIVSRTParticipantReplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
