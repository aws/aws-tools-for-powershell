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
using Amazon.EventBridgeV2;
using Amazon.EventBridgeV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVBV2
{
    /// <summary>
    /// Updates an EventSource. Fields omitted from the request are left unchanged.
    /// </summary>
    [Cmdlet("Update", "EVBV2EventSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridgeV2.Model.UpdateEventSourceResponse")]
    [AWSCmdlet("Calls the Amazon EventBridgeV2 UpdateEventSource API operation.", Operation = new[] {"UpdateEventSource"}, SelectReturnType = typeof(Amazon.EventBridgeV2.Model.UpdateEventSourceResponse))]
    [AWSCmdletOutput("Amazon.EventBridgeV2.Model.UpdateEventSourceResponse",
        "This cmdlet returns an Amazon.EventBridgeV2.Model.UpdateEventSourceResponse object containing multiple properties."
    )]
    public partial class UpdateEVBV2EventSourceCmdlet : AmazonEventBridgeV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the destination that receives events that could not be delivered. An Amazon
        /// SQS queue is the supported destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
        #endregion
        
        #region Parameter Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the destination that receives events that could not be delivered. An Amazon
        /// SQS queue is the supported destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
        #endregion
        
        #region Parameter Configuration_AwsServiceEventsConfiguration_AwsService
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AwsServiceEventsConfiguration_AwsService { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EventSourceArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String EventSourceArn { get; set; }
        #endregion
        
        #region Parameter Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Configuration_PartnerEventsConfiguration_PartnerEventSourceArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_PartnerEventsConfiguration_PartnerEventSourceArn { get; set; }
        #endregion
        
        #region Parameter Configuration_AwsServiceEventsConfiguration_Pattern
        /// <summary>
        /// <para>
        /// <para>A filter pattern, as a JSON string, that defines which of the service's events are
        /// forwarded to the event bus. Do not include source, account, or region as top-level
        /// fields. If no pattern is specified, all events from the service are forwarded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_AwsServiceEventsConfiguration_Pattern { get; set; }
        #endregion
        
        #region Parameter Configuration_PartnerEventsConfiguration_Pattern
        /// <summary>
        /// <para>
        /// <para>A filter pattern, as a JSON string, that defines which of the partner event source's
        /// events are forwarded to the event bus. If no pattern is specified, all events from
        /// the partner event source are forwarded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_PartnerEventsConfiguration_Pattern { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridgeV2.Model.UpdateEventSourceResponse).
        /// Specifying the name of a property of type Amazon.EventBridgeV2.Model.UpdateEventSourceResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EventSourceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EVBV2EventSource (UpdateEventSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridgeV2.Model.UpdateEventSourceResponse, UpdateEVBV2EventSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Configuration_AwsServiceEventsConfiguration_AwsService = this.Configuration_AwsServiceEventsConfiguration_AwsService;
            context.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn = this.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn;
            context.Configuration_AwsServiceEventsConfiguration_Pattern = this.Configuration_AwsServiceEventsConfiguration_Pattern;
            context.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn = this.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn;
            context.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier = this.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier;
            context.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn = this.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn;
            context.Configuration_PartnerEventsConfiguration_Pattern = this.Configuration_PartnerEventsConfiguration_Pattern;
            context.Description = this.Description;
            context.EventSourceArn = this.EventSourceArn;
            #if MODULAR
            if (this.EventSourceArn == null && ParameterWasBound(nameof(this.EventSourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventSourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EventBridgeV2.Model.UpdateEventSourceRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.EventBridgeV2.Model.EventSourceConfiguration();
            Amazon.EventBridgeV2.Model.AwsServiceEventsSourceConfiguration requestConfiguration_configuration_AwsServiceEventsConfiguration = null;
            
             // populate AwsServiceEventsConfiguration
            var requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull = true;
            requestConfiguration_configuration_AwsServiceEventsConfiguration = new Amazon.EventBridgeV2.Model.AwsServiceEventsSourceConfiguration();
            System.String requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_AwsService = null;
            if (cmdletContext.Configuration_AwsServiceEventsConfiguration_AwsService != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_AwsService = cmdletContext.Configuration_AwsServiceEventsConfiguration_AwsService;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_AwsService != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration.AwsService = requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_AwsService;
                requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_Pattern = null;
            if (cmdletContext.Configuration_AwsServiceEventsConfiguration_Pattern != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_Pattern = cmdletContext.Configuration_AwsServiceEventsConfiguration_Pattern;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_Pattern != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration.Pattern = requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_Pattern;
                requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.OnFailureConfiguration requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration = null;
            
             // populate OnFailureConfiguration
            var requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfigurationIsNull = true;
            requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration = new Amazon.EventBridgeV2.Model.OnFailureConfiguration();
            System.String requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn = null;
            if (cmdletContext.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn = cmdletContext.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration.Arn = requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn;
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration should be set to null
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfigurationIsNull)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration = null;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration != null)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration.OnFailureConfiguration = requestConfiguration_configuration_AwsServiceEventsConfiguration_configuration_AwsServiceEventsConfiguration_OnFailureConfiguration;
                requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_AwsServiceEventsConfiguration should be set to null
            if (requestConfiguration_configuration_AwsServiceEventsConfigurationIsNull)
            {
                requestConfiguration_configuration_AwsServiceEventsConfiguration = null;
            }
            if (requestConfiguration_configuration_AwsServiceEventsConfiguration != null)
            {
                request.Configuration.AwsServiceEventsConfiguration = requestConfiguration_configuration_AwsServiceEventsConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.PartnerEventsSourceConfiguration requestConfiguration_configuration_PartnerEventsConfiguration = null;
            
             // populate PartnerEventsConfiguration
            var requestConfiguration_configuration_PartnerEventsConfigurationIsNull = true;
            requestConfiguration_configuration_PartnerEventsConfiguration = new Amazon.EventBridgeV2.Model.PartnerEventsSourceConfiguration();
            System.String requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier = null;
            if (cmdletContext.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier = cmdletContext.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration.PartnerBusKmsKeyIdentifier = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier;
                requestConfiguration_configuration_PartnerEventsConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerEventSourceArn = null;
            if (cmdletContext.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerEventSourceArn = cmdletContext.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerEventSourceArn != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration.PartnerEventSourceArn = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_PartnerEventSourceArn;
                requestConfiguration_configuration_PartnerEventsConfigurationIsNull = false;
            }
            System.String requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_Pattern = null;
            if (cmdletContext.Configuration_PartnerEventsConfiguration_Pattern != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_Pattern = cmdletContext.Configuration_PartnerEventsConfiguration_Pattern;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_Pattern != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration.Pattern = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_Pattern;
                requestConfiguration_configuration_PartnerEventsConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.OnFailureConfiguration requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration = null;
            
             // populate OnFailureConfiguration
            var requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfigurationIsNull = true;
            requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration = new Amazon.EventBridgeV2.Model.OnFailureConfiguration();
            System.String requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn = null;
            if (cmdletContext.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn = cmdletContext.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration.Arn = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn;
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration should be set to null
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfigurationIsNull)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration = null;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration != null)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration.OnFailureConfiguration = requestConfiguration_configuration_PartnerEventsConfiguration_configuration_PartnerEventsConfiguration_OnFailureConfiguration;
                requestConfiguration_configuration_PartnerEventsConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_PartnerEventsConfiguration should be set to null
            if (requestConfiguration_configuration_PartnerEventsConfigurationIsNull)
            {
                requestConfiguration_configuration_PartnerEventsConfiguration = null;
            }
            if (requestConfiguration_configuration_PartnerEventsConfiguration != null)
            {
                request.Configuration.PartnerEventsConfiguration = requestConfiguration_configuration_PartnerEventsConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EventSourceArn != null)
            {
                request.EventSourceArn = cmdletContext.EventSourceArn;
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
        
        private Amazon.EventBridgeV2.Model.UpdateEventSourceResponse CallAWSServiceOperation(IAmazonEventBridgeV2 client, Amazon.EventBridgeV2.Model.UpdateEventSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridgeV2", "UpdateEventSource");
            try
            {
                return client.UpdateEventSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_AwsServiceEventsConfiguration_AwsService { get; set; }
            public System.String Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
            public System.String Configuration_AwsServiceEventsConfiguration_Pattern { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_PartnerEventSourceArn { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_Pattern { get; set; }
            public System.String Description { get; set; }
            public System.String EventSourceArn { get; set; }
            public System.Func<Amazon.EventBridgeV2.Model.UpdateEventSourceResponse, UpdateEVBV2EventSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
