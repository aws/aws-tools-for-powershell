/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates the source of a flow.
    /// </summary>
    [Cmdlet("Update", "EMCNFlowSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Source")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlowSource API operation.", Operation = new[] {"UpdateFlowSource"})]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Source",
        "This cmdlet returns a Source object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowSourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: FlowArn (type System.String)"
    )]
    public partial class UpdateEMCNFlowSourceCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Decryption
        /// <summary>
        /// <para>
        /// The type of encryption used on the content
        /// ingested from this source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaConnect.Model.UpdateEncryption Decryption { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A description for the source. This value is
        /// not used or seen outside of the current AWS Elemental MediaConnect account.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EntitlementArn
        /// <summary>
        /// <para>
        /// The ARN of the entitlement that allows
        /// you to subscribe to this flow. The entitlement is set by the flow originator, and
        /// the ARN is generated as part of the originator's flow.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EntitlementArn { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that is associated with the source that
        /// you want to update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter IngestPort
        /// <summary>
        /// <para>
        /// The port that the flow will be listening on
        /// for incoming content.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 IngestPort { get; set; }
        #endregion
        
        #region Parameter MaxBitrate
        /// <summary>
        /// <para>
        /// The smoothing max bitrate for RTP and RTP-FEC
        /// streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaxBitrate { get; set; }
        #endregion
        
        #region Parameter MaxLatency
        /// <summary>
        /// <para>
        /// The maximum latency in milliseconds for Zixi-based
        /// streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 MaxLatency { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// The protocol that is used by the source.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaConnect.Protocol")]
        public Amazon.MediaConnect.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter SourceArn
        /// <summary>
        /// <para>
        /// The ARN of the source that you want to update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String SourceArn { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// The stream ID that you want to use for this transport.
        /// This parameter applies only to Zixi-based streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamId { get; set; }
        #endregion
        
        #region Parameter WhitelistCidr
        /// <summary>
        /// <para>
        /// The range of IP addresses that should be
        /// allowed to contribute content to your source. These IP addresses should in the form
        /// of a Classless Inter-Domain Routing (CIDR) block; for example, 10.0.0.0/16.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WhitelistCidr { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("SourceArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowSource (UpdateFlowSource)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Decryption = this.Decryption;
            context.Description = this.Description;
            context.EntitlementArn = this.EntitlementArn;
            context.FlowArn = this.FlowArn;
            if (ParameterWasBound("IngestPort"))
                context.IngestPort = this.IngestPort;
            if (ParameterWasBound("MaxBitrate"))
                context.MaxBitrate = this.MaxBitrate;
            if (ParameterWasBound("MaxLatency"))
                context.MaxLatency = this.MaxLatency;
            context.Protocol = this.Protocol;
            context.SourceArn = this.SourceArn;
            context.StreamId = this.StreamId;
            context.WhitelistCidr = this.WhitelistCidr;
            
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowSourceRequest();
            
            if (cmdletContext.Decryption != null)
            {
                request.Decryption = cmdletContext.Decryption;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EntitlementArn != null)
            {
                request.EntitlementArn = cmdletContext.EntitlementArn;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            if (cmdletContext.IngestPort != null)
            {
                request.IngestPort = cmdletContext.IngestPort.Value;
            }
            if (cmdletContext.MaxBitrate != null)
            {
                request.MaxBitrate = cmdletContext.MaxBitrate.Value;
            }
            if (cmdletContext.MaxLatency != null)
            {
                request.MaxLatency = cmdletContext.MaxLatency.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.SourceArn != null)
            {
                request.SourceArn = cmdletContext.SourceArn;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
            }
            if (cmdletContext.WhitelistCidr != null)
            {
                request.WhitelistCidr = cmdletContext.WhitelistCidr;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Source;
                notes = new Dictionary<string, object>();
                notes["FlowArn"] = response.FlowArn;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.MediaConnect.Model.UpdateFlowSourceResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlowSource");
            try
            {
                #if DESKTOP
                return client.UpdateFlowSource(request);
                #elif CORECLR
                return client.UpdateFlowSourceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.MediaConnect.Model.UpdateEncryption Decryption { get; set; }
            public System.String Description { get; set; }
            public System.String EntitlementArn { get; set; }
            public System.String FlowArn { get; set; }
            public System.Int32? IngestPort { get; set; }
            public System.Int32? MaxBitrate { get; set; }
            public System.Int32? MaxLatency { get; set; }
            public Amazon.MediaConnect.Protocol Protocol { get; set; }
            public System.String SourceArn { get; set; }
            public System.String StreamId { get; set; }
            public System.String WhitelistCidr { get; set; }
        }
        
    }
}
