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
    /// Creates an EventSource, which forwards events from an origin (an AWS service or another
    /// account) onto an event bus. The bus must be ACTIVE. Retries carrying the same ClientToken
    /// are idempotent.
    /// </summary>
    [Cmdlet("New", "EVBV2EventSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridgeV2.Model.CreateEventSourceResponse")]
    [AWSCmdlet("Calls the Amazon EventBridgeV2 CreateEventSource API operation.", Operation = new[] {"CreateEventSource"}, SelectReturnType = typeof(Amazon.EventBridgeV2.Model.CreateEventSourceResponse))]
    [AWSCmdletOutput("Amazon.EventBridgeV2.Model.CreateEventSourceResponse",
        "This cmdlet returns an Amazon.EventBridgeV2.Model.CreateEventSourceResponse object containing multiple properties."
    )]
    public partial class NewEVBV2EventSourceCmdlet : AmazonEventBridgeV2ClientCmdlet, IExecutor
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
        
        #region Parameter EventBusArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String EventBusArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String Name { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridgeV2.Model.CreateEventSourceResponse).
        /// Specifying the name of a property of type Amazon.EventBridgeV2.Model.CreateEventSourceResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.EventBusArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EVBV2EventSource (CreateEventSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridgeV2.Model.CreateEventSourceResponse, NewEVBV2EventSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Configuration_AwsServiceEventsConfiguration_AwsService = this.Configuration_AwsServiceEventsConfiguration_AwsService;
            context.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn = this.Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn;
            context.Configuration_AwsServiceEventsConfiguration_Pattern = this.Configuration_AwsServiceEventsConfiguration_Pattern;
            context.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn = this.Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn;
            context.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier = this.Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier;
            context.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn = this.Configuration_PartnerEventsConfiguration_PartnerEventSourceArn;
            context.Configuration_PartnerEventsConfiguration_Pattern = this.Configuration_PartnerEventsConfiguration_Pattern;
            context.Description = this.Description;
            context.EventBusArn = this.EventBusArn;
            #if MODULAR
            if (this.EventBusArn == null && ParameterWasBound(nameof(this.EventBusArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventBusArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.EventBridgeV2.Model.CreateEventSourceRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
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
            if (cmdletContext.EventBusArn != null)
            {
                request.EventBusArn = cmdletContext.EventBusArn;
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
        
        private Amazon.EventBridgeV2.Model.CreateEventSourceResponse CallAWSServiceOperation(IAmazonEventBridgeV2 client, Amazon.EventBridgeV2.Model.CreateEventSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridgeV2", "CreateEventSource");
            try
            {
                return client.CreateEventSourceAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Configuration_AwsServiceEventsConfiguration_AwsService { get; set; }
            public System.String Configuration_AwsServiceEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
            public System.String Configuration_AwsServiceEventsConfiguration_Pattern { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_OnFailureConfiguration_Arn { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_PartnerBusKmsKeyIdentifier { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_PartnerEventSourceArn { get; set; }
            public System.String Configuration_PartnerEventsConfiguration_Pattern { get; set; }
            public System.String Description { get; set; }
            public System.String EventBusArn { get; set; }
            public System.String Name { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.EventBridgeV2.Model.CreateEventSourceResponse, NewEVBV2EventSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
