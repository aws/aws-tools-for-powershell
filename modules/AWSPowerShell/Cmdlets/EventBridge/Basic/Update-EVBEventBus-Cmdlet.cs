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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Updates the specified event bus.
    /// </summary>
    [Cmdlet("Update", "EVBEventBus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridge.Model.UpdateEventBusResponse")]
    [AWSCmdlet("Calls the Amazon EventBridge UpdateEventBus API operation.", Operation = new[] {"UpdateEventBus"}, SelectReturnType = typeof(Amazon.EventBridge.Model.UpdateEventBusResponse))]
    [AWSCmdletOutput("Amazon.EventBridge.Model.UpdateEventBusResponse",
        "This cmdlet returns an Amazon.EventBridge.Model.UpdateEventBusResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEVBEventBusCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DeadLetterConfig_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the SQS queue specified as the target for the dead-letter queue.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DeadLetterConfig_Arn { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The event bus description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS customer managed key for EventBridge to use, if you choose
        /// to use a customer managed key to encrypt events on this event bus. The identifier
        /// can be the key Amazon Resource Name (ARN), KeyId, key alias, or key alias ARN.</para><para>If you do not specify a customer managed key identifier, EventBridge uses an Amazon
        /// Web Services owned key to encrypt events on the event bus.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/getting-started.html">Managing
        /// keys</a> in the <i>Key Management Service Developer Guide</i>. </para><note><para>Archives and schema discovery are not supported for event buses encrypted using a
        /// customer managed key. EventBridge returns an error if:</para><ul><li><para>You call <c><a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_CreateArchive.html">CreateArchive</a></c> on an event bus set to use a customer managed key for encryption.</para></li><li><para>You call <c><a href="https://docs.aws.amazon.com/eventbridge/latest/schema-reference/v1-discoverers.html#CreateDiscoverer">CreateDiscoverer</a></c> on an event bus set to use a customer managed key for encryption.</para></li><li><para>You call <c><a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_UpdatedEventBus.html">UpdatedEventBus</a></c> to set a customer managed key on an event bus with an archives or schema discovery
        /// enabled.</para></li></ul><para>To enable archives or schema discovery on an event bus, choose to use an Amazon Web
        /// Services owned key. For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-encryption.html">Data
        /// encryption in EventBridge</a> in the <i>Amazon EventBridge User Guide</i>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the event bus.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.UpdateEventBusResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.UpdateEventBusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EVBEventBus (UpdateEventBus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.UpdateEventBusResponse, UpdateEVBEventBusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DeadLetterConfig_Arn = this.DeadLetterConfig_Arn;
            context.Description = this.Description;
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.Name = this.Name;
            
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
            var request = new Amazon.EventBridge.Model.UpdateEventBusRequest();
            
            
             // populate DeadLetterConfig
            var requestDeadLetterConfigIsNull = true;
            request.DeadLetterConfig = new Amazon.EventBridge.Model.DeadLetterConfig();
            System.String requestDeadLetterConfig_deadLetterConfig_Arn = null;
            if (cmdletContext.DeadLetterConfig_Arn != null)
            {
                requestDeadLetterConfig_deadLetterConfig_Arn = cmdletContext.DeadLetterConfig_Arn;
            }
            if (requestDeadLetterConfig_deadLetterConfig_Arn != null)
            {
                request.DeadLetterConfig.Arn = requestDeadLetterConfig_deadLetterConfig_Arn;
                requestDeadLetterConfigIsNull = false;
            }
             // determine if request.DeadLetterConfig should be set to null
            if (requestDeadLetterConfigIsNull)
            {
                request.DeadLetterConfig = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.EventBridge.Model.UpdateEventBusResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.UpdateEventBusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "UpdateEventBus");
            try
            {
                #if DESKTOP
                return client.UpdateEventBus(request);
                #elif CORECLR
                return client.UpdateEventBusAsync(request).GetAwaiter().GetResult();
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
            public System.String DeadLetterConfig_Arn { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.EventBridge.Model.UpdateEventBusResponse, UpdateEVBEventBusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
