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
    /// Creates a notification configuration. A configuration is a connection between an event
    /// type and a destination that you have already created.
    /// </summary>
    [Cmdlet("New", "IOTMINotificationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTManagedIntegrations.EventType")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management CreateNotificationConfiguration API operation.", Operation = new[] {"CreateNotificationConfiguration"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IoTManagedIntegrations.EventType or Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationResponse",
        "This cmdlet returns an Amazon.IoTManagedIntegrations.EventType object.",
        "The service call response (type Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewIOTMINotificationConfigurationCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DestinationName
        /// <summary>
        /// <para>
        /// <para>The name of the destination for the notification configuration.</para>
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
        public System.String DestinationName { get; set; }
        #endregion
        
        #region Parameter EventType
        /// <summary>
        /// <para>
        /// <para>The type of event triggering a device notification to the customer-managed destination.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.EventType")]
        public Amazon.IoTManagedIntegrations.EventType EventType { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>An idempotency token. If you retry a request that completed successfully initially
        /// using the same client token and parameters, then the retry attempt will succeed without
        /// performing any further actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of key/value pairs that are used to manage the notification configuration.</para>
        /// </para>
        /// <para>This parameter is deprecated.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [System.ObsoleteAttribute("Tags has been deprecated from this api")]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventType'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventType";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DestinationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTMINotificationConfiguration (CreateNotificationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationResponse, NewIOTMINotificationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DestinationName = this.DestinationName;
            #if MODULAR
            if (this.DestinationName == null && ParameterWasBound(nameof(this.DestinationName)))
            {
                WriteWarning("You are passing $null as a value for parameter DestinationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventType = this.EventType;
            #if MODULAR
            if (this.EventType == null && ParameterWasBound(nameof(this.EventType)))
            {
                WriteWarning("You are passing $null as a value for parameter EventType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
            var request = new Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DestinationName != null)
            {
                request.DestinationName = cmdletContext.DestinationName;
            }
            if (cmdletContext.EventType != null)
            {
                request.EventType = cmdletContext.EventType;
            }
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
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
        
        private Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "CreateNotificationConfiguration");
            try
            {
                #if DESKTOP
                return client.CreateNotificationConfiguration(request);
                #elif CORECLR
                return client.CreateNotificationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String DestinationName { get; set; }
            public Amazon.IoTManagedIntegrations.EventType EventType { get; set; }
            [System.ObsoleteAttribute]
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.CreateNotificationConfigurationResponse, NewIOTMINotificationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventType;
        }
        
    }
}
