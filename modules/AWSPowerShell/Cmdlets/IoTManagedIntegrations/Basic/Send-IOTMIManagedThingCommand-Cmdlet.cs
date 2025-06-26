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
using Amazon.IoTManagedIntegrations;
using Amazon.IoTManagedIntegrations.Model;

namespace Amazon.PowerShell.Cmdlets.IOTMI
{
    /// <summary>
    /// Send the command to the device represented by the managed thing.
    /// </summary>
    [Cmdlet("Send", "IOTMIManagedThingCommand", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management SendManagedThingCommand API operation.", Operation = new[] {"SendManagedThingCommand"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandResponse) can be returned by specifying '-Select *'."
    )]
    public partial class SendIOTMIManagedThingCommandCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountAssociationId
        /// <summary>
        /// <para>
        /// <para>The identifier of the account association to use when sending a command to a managed
        /// thing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountAssociationId { get; set; }
        #endregion
        
        #region Parameter Endpoint
        /// <summary>
        /// <para>
        /// <para>The device endpoint.</para>
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
        [Alias("Endpoints")]
        public Amazon.IoTManagedIntegrations.Model.CommandEndpoint[] Endpoint { get; set; }
        #endregion
        
        #region Parameter ManagedThingId
        /// <summary>
        /// <para>
        /// <para>The id of the device.</para>
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
        public System.String ManagedThingId { get; set; }
        #endregion
        
        #region Parameter ConnectorAssociationId
        /// <summary>
        /// <para>
        /// <para>The ID tracking the current discovery process for one connector association.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("ConnectorAssociationId has been deprecated")]
        public System.String ConnectorAssociationId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TraceId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TraceId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ManagedThingId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ManagedThingId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ManagedThingId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ManagedThingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-IOTMIManagedThingCommand (SendManagedThingCommand)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandResponse, SendIOTMIManagedThingCommandCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ManagedThingId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountAssociationId = this.AccountAssociationId;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ConnectorAssociationId = this.ConnectorAssociationId;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Endpoint != null)
            {
                context.Endpoint = new List<Amazon.IoTManagedIntegrations.Model.CommandEndpoint>(this.Endpoint);
            }
            #if MODULAR
            if (this.Endpoint == null && ParameterWasBound(nameof(this.Endpoint)))
            {
                WriteWarning("You are passing $null as a value for parameter Endpoint which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ManagedThingId = this.ManagedThingId;
            #if MODULAR
            if (this.ManagedThingId == null && ParameterWasBound(nameof(this.ManagedThingId)))
            {
                WriteWarning("You are passing $null as a value for parameter ManagedThingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandRequest();
            
            if (cmdletContext.AccountAssociationId != null)
            {
                request.AccountAssociationId = cmdletContext.AccountAssociationId;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.ConnectorAssociationId != null)
            {
                request.ConnectorAssociationId = cmdletContext.ConnectorAssociationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Endpoint != null)
            {
                request.Endpoints = cmdletContext.Endpoint;
            }
            if (cmdletContext.ManagedThingId != null)
            {
                request.ManagedThingId = cmdletContext.ManagedThingId;
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
        
        private Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "SendManagedThingCommand");
            try
            {
                #if DESKTOP
                return client.SendManagedThingCommand(request);
                #elif CORECLR
                return client.SendManagedThingCommandAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountAssociationId { get; set; }
            [System.ObsoleteAttribute]
            public System.String ConnectorAssociationId { get; set; }
            public List<Amazon.IoTManagedIntegrations.Model.CommandEndpoint> Endpoint { get; set; }
            public System.String ManagedThingId { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.SendManagedThingCommandResponse, SendIOTMIManagedThingCommandCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TraceId;
        }
        
    }
}
