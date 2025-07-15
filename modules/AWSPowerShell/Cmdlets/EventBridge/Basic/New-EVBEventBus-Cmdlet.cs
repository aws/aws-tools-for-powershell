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
using Amazon.EventBridge;
using Amazon.EventBridge.Model;

namespace Amazon.PowerShell.Cmdlets.EVB
{
    /// <summary>
    /// Creates a new event bus within your account. This can be a custom event bus which
    /// you can use to receive events from your custom applications and services, or it can
    /// be a partner event bus which can be matched to a partner event source.
    /// </summary>
    [Cmdlet("New", "EVBEventBus", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon EventBridge CreateEventBus API operation.", Operation = new[] {"CreateEventBus"}, SelectReturnType = typeof(Amazon.EventBridge.Model.CreateEventBusResponse))]
    [AWSCmdletOutput("System.String or Amazon.EventBridge.Model.CreateEventBusResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.EventBridge.Model.CreateEventBusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEVBEventBusCmdlet : AmazonEventBridgeClientCmdlet, IExecutor
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
        
        #region Parameter EventSourceName
        /// <summary>
        /// <para>
        /// <para>If you are creating a partner event bus, this specifies the partner event source that
        /// the new event bus will be matched with.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventSourceName { get; set; }
        #endregion
        
        #region Parameter LogConfig_IncludeDetail
        /// <summary>
        /// <para>
        /// <para>Whether EventBridge include detailed event information in the records it generates.
        /// Detailed data can be useful for troubleshooting and debugging. This information includes
        /// details of the event itself, as well as target details.</para><para>For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-event-bus-logs.html#eb-event-logs-data">Including
        /// detail data in event bus logs</a> in the <i>EventBridge User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridge.IncludeDetail")]
        public Amazon.EventBridge.IncludeDetail LogConfig_IncludeDetail { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier of the KMS customer managed key for EventBridge to use, if you choose
        /// to use a customer managed key to encrypt events on this event bus. The identifier
        /// can be the key Amazon Resource Name (ARN), KeyId, key alias, or key alias ARN.</para><para>If you do not specify a customer managed key identifier, EventBridge uses an Amazon
        /// Web Services owned key to encrypt events on the event bus.</para><para>For more information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/viewing-keys.html">Identify
        /// and view keys</a> in the <i>Key Management Service Developer Guide</i>. </para><note><para>Schema discovery is not supported for event buses encrypted using a customer managed
        /// key. EventBridge returns an error if: </para><ul><li><para>You call <c><a href="https://docs.aws.amazon.com/eventbridge/latest/schema-reference/v1-discoverers.html#CreateDiscoverer">CreateDiscoverer</a></c> on an event bus set to use a customer managed key for encryption.</para></li><li><para>You call <c><a href="https://docs.aws.amazon.com/eventbridge/latest/APIReference/API_UpdatedEventBus.html">UpdatedEventBus</a></c> to set a customer managed key on an event bus with schema discovery enabled.</para></li></ul><para>To enable schema discovery on an event bus, choose to use an Amazon Web Services owned
        /// key. For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-encryption-event-bus-cmkey.html">Encrypting
        /// events</a> in the <i>Amazon EventBridge User Guide</i>.</para></note><important><para>If you have specified that EventBridge use a customer managed key for encrypting the
        /// source event bus, we strongly recommend you also specify a customer managed key for
        /// any archives for the event bus as well. </para><para>For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/encryption-archives.html">Encrypting
        /// archives</a> in the <i>Amazon EventBridge User Guide</i>.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter LogConfig_Level
        /// <summary>
        /// <para>
        /// <para>The level of logging detail to include. This applies to all log destinations for the
        /// event bus.</para><para>For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-event-bus-logs.html#eb-event-bus-logs-level">Specifying
        /// event bus log level</a> in the <i>EventBridge User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridge.Level")]
        public Amazon.EventBridge.Level LogConfig_Level { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the new event bus. </para><para>Custom event bus names can't contain the <c>/</c> character, but you can use the <c>/</c>
        /// character in partner event bus names. In addition, for partner event buses, the name
        /// must exactly match the name of the partner event source that this event bus is matched
        /// to.</para><para>You can't use the name <c>default</c> for a custom event bus, as this name is already
        /// used for your account's default event bus.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to associate with the event bus.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.EventBridge.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventBusArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridge.Model.CreateEventBusResponse).
        /// Specifying the name of a property of type Amazon.EventBridge.Model.CreateEventBusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventBusArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EVBEventBus (CreateEventBus)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridge.Model.CreateEventBusResponse, NewEVBEventBusCmdlet>(Select) ??
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
            context.EventSourceName = this.EventSourceName;
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.LogConfig_IncludeDetail = this.LogConfig_IncludeDetail;
            context.LogConfig_Level = this.LogConfig_Level;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.EventBridge.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.EventBridge.Model.CreateEventBusRequest();
            
            
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
            if (cmdletContext.EventSourceName != null)
            {
                request.EventSourceName = cmdletContext.EventSourceName;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            
             // populate LogConfig
            var requestLogConfigIsNull = true;
            request.LogConfig = new Amazon.EventBridge.Model.LogConfig();
            Amazon.EventBridge.IncludeDetail requestLogConfig_logConfig_IncludeDetail = null;
            if (cmdletContext.LogConfig_IncludeDetail != null)
            {
                requestLogConfig_logConfig_IncludeDetail = cmdletContext.LogConfig_IncludeDetail;
            }
            if (requestLogConfig_logConfig_IncludeDetail != null)
            {
                request.LogConfig.IncludeDetail = requestLogConfig_logConfig_IncludeDetail;
                requestLogConfigIsNull = false;
            }
            Amazon.EventBridge.Level requestLogConfig_logConfig_Level = null;
            if (cmdletContext.LogConfig_Level != null)
            {
                requestLogConfig_logConfig_Level = cmdletContext.LogConfig_Level;
            }
            if (requestLogConfig_logConfig_Level != null)
            {
                request.LogConfig.Level = requestLogConfig_logConfig_Level;
                requestLogConfigIsNull = false;
            }
             // determine if request.LogConfig should be set to null
            if (requestLogConfigIsNull)
            {
                request.LogConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.EventBridge.Model.CreateEventBusResponse CallAWSServiceOperation(IAmazonEventBridge client, Amazon.EventBridge.Model.CreateEventBusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridge", "CreateEventBus");
            try
            {
                #if DESKTOP
                return client.CreateEventBus(request);
                #elif CORECLR
                return client.CreateEventBusAsync(request).GetAwaiter().GetResult();
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
            public System.String EventSourceName { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public Amazon.EventBridge.IncludeDetail LogConfig_IncludeDetail { get; set; }
            public Amazon.EventBridge.Level LogConfig_Level { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.EventBridge.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.EventBridge.Model.CreateEventBusResponse, NewEVBEventBusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventBusArn;
        }
        
    }
}
