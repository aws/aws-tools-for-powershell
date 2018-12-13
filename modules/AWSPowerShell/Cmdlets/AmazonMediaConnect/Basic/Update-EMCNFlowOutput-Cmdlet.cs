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
    /// Updates an existing flow output.
    /// </summary>
    [Cmdlet("Update", "EMCNFlowOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Output")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlowOutput API operation.", Operation = new[] {"UpdateFlowOutput"})]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Output",
        "This cmdlet returns a Output object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowOutputResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack.",
        "Additionally, the following properties are added as Note properties to the service response type instance for the cmdlet entry in the $AWSHistory stack: FlowArn (type System.String)"
    )]
    public partial class UpdateEMCNFlowOutputCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A description of the output. This description
        /// appears only on the AWS Elemental MediaConnect console and will not be seen by the
        /// end user.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// The IP address where you want to send the
        /// output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter Encryption
        /// <summary>
        /// <para>
        /// The type of key used for the encryption. If
        /// no keyType is provided, the service will use the default setting (static-key).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
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
        
        #region Parameter OutputArn
        /// <summary>
        /// <para>
        /// The ARN of the output that you want to update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String OutputArn { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// The port to use when content is distributed to this
        /// output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// The protocol to use for the output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.MediaConnect.Protocol")]
        public Amazon.MediaConnect.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter SmoothingLatency
        /// <summary>
        /// <para>
        /// The smoothing latency in milliseconds
        /// for RTP and RTP-FEC streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 SmoothingLatency { get; set; }
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
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that is associated with the output that
        /// you want to update.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String FlowArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("OutputArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowOutput (UpdateFlowOutput)"))
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
            
            context.Description = this.Description;
            context.Destination = this.Destination;
            context.Encryption = this.Encryption;
            context.FlowArn = this.FlowArn;
            if (ParameterWasBound("MaxLatency"))
                context.MaxLatency = this.MaxLatency;
            context.OutputArn = this.OutputArn;
            if (ParameterWasBound("Port"))
                context.Port = this.Port;
            context.Protocol = this.Protocol;
            if (ParameterWasBound("SmoothingLatency"))
                context.SmoothingLatency = this.SmoothingLatency;
            context.StreamId = this.StreamId;
            
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
            var request = new Amazon.MediaConnect.Model.UpdateFlowOutputRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.Encryption != null)
            {
                request.Encryption = cmdletContext.Encryption;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            if (cmdletContext.MaxLatency != null)
            {
                request.MaxLatency = cmdletContext.MaxLatency.Value;
            }
            if (cmdletContext.OutputArn != null)
            {
                request.OutputArn = cmdletContext.OutputArn;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.SmoothingLatency != null)
            {
                request.SmoothingLatency = cmdletContext.SmoothingLatency.Value;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Output;
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
        
        private Amazon.MediaConnect.Model.UpdateFlowOutputResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlowOutput");
            try
            {
                #if DESKTOP
                return client.UpdateFlowOutput(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateFlowOutputAsync(request);
                return task.Result;
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
            public System.String Description { get; set; }
            public System.String Destination { get; set; }
            public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
            public System.String FlowArn { get; set; }
            public System.Int32? MaxLatency { get; set; }
            public System.String OutputArn { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.MediaConnect.Protocol Protocol { get; set; }
            public System.Int32? SmoothingLatency { get; set; }
            public System.String StreamId { get; set; }
        }
        
    }
}
