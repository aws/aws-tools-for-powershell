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
    /// Publishes pre-shaped events to an event bus.
    /// </summary>
    [Cmdlet("Write", "EVBV2RawEvent", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EventBridgeV2.Model.PutRawEventsResponse")]
    [AWSCmdlet("Calls the Amazon EventBridgeV2 PutRawEvents API operation.", Operation = new[] {"PutRawEvents"}, SelectReturnType = typeof(Amazon.EventBridgeV2.Model.PutRawEventsResponse))]
    [AWSCmdletOutput("Amazon.EventBridgeV2.Model.PutRawEventsResponse",
        "This cmdlet returns an Amazon.EventBridgeV2.Model.PutRawEventsResponse object containing multiple properties."
    )]
    public partial class WriteEVBV2RawEventCmdlet : AmazonEventBridgeV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SchemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn
        /// <summary>
        /// <para>
        /// <para>EventBridge Connection ARN that provides API Key or OAuth credentials for the registry.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn { get; set; }
        #endregion
        
        #region Parameter DeduplicationConfiguration_DeduplicationType
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EventBridgeV2.DeduplicationType")]
        public Amazon.EventBridgeV2.DeduplicationType DeduplicationConfiguration_DeduplicationType { get; set; }
        #endregion
        
        #region Parameter Entry
        /// <summary>
        /// <para>
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("Entries")]
        public Amazon.EventBridgeV2.Model.PutRawEventsRequestEntry[] Entry { get; set; }
        #endregion
        
        #region Parameter EventBusArn
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
        public System.String EventBusArn { get; set; }
        #endregion
        
        #region Parameter SchemaRegistryConfiguration_RegistryUri
        /// <summary>
        /// <para>
        /// <para>Glue Schema Registry ARN, or Confluent Cloud HTTPS URL.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SchemaRegistryConfiguration_RegistryUri { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridgeV2.Model.PutRawEventsResponse).
        /// Specifying the name of a property of type Amazon.EventBridgeV2.Model.PutRawEventsResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EventBusArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EVBV2RawEvent (PutRawEvents)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EventBridgeV2.Model.PutRawEventsResponse, WriteEVBV2RawEventCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeduplicationConfiguration_DeduplicationType = this.DeduplicationConfiguration_DeduplicationType;
            if (this.Entry != null)
            {
                context.Entry = new List<Amazon.EventBridgeV2.Model.PutRawEventsRequestEntry>(this.Entry);
            }
            #if MODULAR
            if (this.Entry == null && ParameterWasBound(nameof(this.Entry)))
            {
                WriteWarning("You are passing $null as a value for parameter Entry which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EventBusArn = this.EventBusArn;
            #if MODULAR
            if (this.EventBusArn == null && ParameterWasBound(nameof(this.EventBusArn)))
            {
                WriteWarning("You are passing $null as a value for parameter EventBusArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SchemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn = this.SchemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn;
            context.SchemaRegistryConfiguration_RegistryUri = this.SchemaRegistryConfiguration_RegistryUri;
            
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
            var request = new Amazon.EventBridgeV2.Model.PutRawEventsRequest();
            
            
             // populate DeduplicationConfiguration
            var requestDeduplicationConfigurationIsNull = true;
            request.DeduplicationConfiguration = new Amazon.EventBridgeV2.Model.DeduplicationConfiguration();
            Amazon.EventBridgeV2.DeduplicationType requestDeduplicationConfiguration_deduplicationConfiguration_DeduplicationType = null;
            if (cmdletContext.DeduplicationConfiguration_DeduplicationType != null)
            {
                requestDeduplicationConfiguration_deduplicationConfiguration_DeduplicationType = cmdletContext.DeduplicationConfiguration_DeduplicationType;
            }
            if (requestDeduplicationConfiguration_deduplicationConfiguration_DeduplicationType != null)
            {
                request.DeduplicationConfiguration.DeduplicationType = requestDeduplicationConfiguration_deduplicationConfiguration_DeduplicationType;
                requestDeduplicationConfigurationIsNull = false;
            }
             // determine if request.DeduplicationConfiguration should be set to null
            if (requestDeduplicationConfigurationIsNull)
            {
                request.DeduplicationConfiguration = null;
            }
            if (cmdletContext.Entry != null)
            {
                request.Entries = cmdletContext.Entry;
            }
            if (cmdletContext.EventBusArn != null)
            {
                request.EventBusArn = cmdletContext.EventBusArn;
            }
            
             // populate SchemaRegistryConfiguration
            var requestSchemaRegistryConfigurationIsNull = true;
            request.SchemaRegistryConfiguration = new Amazon.EventBridgeV2.Model.SchemaRegistryConfiguration();
            System.String requestSchemaRegistryConfiguration_schemaRegistryConfiguration_RegistryUri = null;
            if (cmdletContext.SchemaRegistryConfiguration_RegistryUri != null)
            {
                requestSchemaRegistryConfiguration_schemaRegistryConfiguration_RegistryUri = cmdletContext.SchemaRegistryConfiguration_RegistryUri;
            }
            if (requestSchemaRegistryConfiguration_schemaRegistryConfiguration_RegistryUri != null)
            {
                request.SchemaRegistryConfiguration.RegistryUri = requestSchemaRegistryConfiguration_schemaRegistryConfiguration_RegistryUri;
                requestSchemaRegistryConfigurationIsNull = false;
            }
            Amazon.EventBridgeV2.Model.ConfluentPublicRegistryConfiguration requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration = null;
            
             // populate ConfluentPublicRegistryConfiguration
            var requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfigurationIsNull = true;
            requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration = new Amazon.EventBridgeV2.Model.ConfluentPublicRegistryConfiguration();
            System.String requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn = null;
            if (cmdletContext.SchemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn != null)
            {
                requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn = cmdletContext.SchemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn;
            }
            if (requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn != null)
            {
                requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration.ConnectionArn = requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn;
                requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfigurationIsNull = false;
            }
             // determine if requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration should be set to null
            if (requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfigurationIsNull)
            {
                requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration = null;
            }
            if (requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration != null)
            {
                request.SchemaRegistryConfiguration.ConfluentPublicRegistryConfiguration = requestSchemaRegistryConfiguration_schemaRegistryConfiguration_ConfluentPublicRegistryConfiguration;
                requestSchemaRegistryConfigurationIsNull = false;
            }
             // determine if request.SchemaRegistryConfiguration should be set to null
            if (requestSchemaRegistryConfigurationIsNull)
            {
                request.SchemaRegistryConfiguration = null;
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
        
        private Amazon.EventBridgeV2.Model.PutRawEventsResponse CallAWSServiceOperation(IAmazonEventBridgeV2 client, Amazon.EventBridgeV2.Model.PutRawEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridgeV2", "PutRawEvents");
            try
            {
                return client.PutRawEventsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.EventBridgeV2.DeduplicationType DeduplicationConfiguration_DeduplicationType { get; set; }
            public List<Amazon.EventBridgeV2.Model.PutRawEventsRequestEntry> Entry { get; set; }
            public System.String EventBusArn { get; set; }
            public System.String SchemaRegistryConfiguration_ConfluentPublicRegistryConfiguration_ConnectionArn { get; set; }
            public System.String SchemaRegistryConfiguration_RegistryUri { get; set; }
            public System.Func<Amazon.EventBridgeV2.Model.PutRawEventsResponse, WriteEVBV2RawEventCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
