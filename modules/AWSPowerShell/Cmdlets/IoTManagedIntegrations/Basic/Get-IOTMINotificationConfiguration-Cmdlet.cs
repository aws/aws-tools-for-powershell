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
    /// Get a notification configuration for a specified event type.
    /// </summary>
    [Cmdlet("Get", "IOTMINotificationConfiguration")]
    [OutputType("Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse")]
    [AWSCmdlet("Calls the Managed integrations for AWS IoT Device Management GetNotificationConfiguration API operation.", Operation = new[] {"GetNotificationConfiguration"}, SelectReturnType = typeof(Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse))]
    [AWSCmdletOutput("Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse",
        "This cmdlet returns an Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse object containing multiple properties."
    )]
    public partial class GetIOTMINotificationConfigurationCmdlet : AmazonIoTManagedIntegrationsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EventType
        /// <summary>
        /// <para>
        /// <para>The type of event triggering a device notification to the customer-managed destination.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTManagedIntegrations.EventType")]
        public Amazon.IoTManagedIntegrations.EventType EventType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse).
        /// Specifying the name of a property of type Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the EventType parameter.
        /// The -PassThru parameter is deprecated, use -Select '^EventType' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^EventType' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse, GetIOTMINotificationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.EventType;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.EventType = this.EventType;
            #if MODULAR
            if (this.EventType == null && ParameterWasBound(nameof(this.EventType)))
            {
                WriteWarning("You are passing $null as a value for parameter EventType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationRequest();
            
            if (cmdletContext.EventType != null)
            {
                request.EventType = cmdletContext.EventType;
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
        
        private Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse CallAWSServiceOperation(IAmazonIoTManagedIntegrations client, Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Managed integrations for AWS IoT Device Management", "GetNotificationConfiguration");
            try
            {
                #if DESKTOP
                return client.GetNotificationConfiguration(request);
                #elif CORECLR
                return client.GetNotificationConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoTManagedIntegrations.EventType EventType { get; set; }
            public System.Func<Amazon.IoTManagedIntegrations.Model.GetNotificationConfigurationResponse, GetIOTMINotificationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
