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
using Amazon.ObservabilityAdmin;
using Amazon.ObservabilityAdmin.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWOADMN
{
    /// <summary>
    /// Creates or replaces the telemetry manifest of a connector. The telemetry manifest
    /// declares which resources in your cloud provider to collect telemetry from and which
    /// telemetry types to collect. To avoid overwriting changes made by another caller, specify
    /// <c>ExpectedVersion</c>.
    /// </summary>
    [Cmdlet("Write", "CWOADMNConnectorTelemetryManifest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Int64")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service PutConnectorTelemetryManifest API operation.", Operation = new[] {"PutConnectorTelemetryManifest"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestResponse))]
    [AWSCmdletOutput("System.Int64 or Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestResponse",
        "This cmdlet returns a collection of System.Int64 objects.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCWOADMNConnectorTelemetryManifestCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Manifest_Source_Azure
        /// <summary>
        /// <para>
        /// <para>The Azure scope items. Each <c>AzureScopeItem</c> specifies a set of Azure resources
        /// and the telemetry types to collect from them. You can specify up to 100 scope items.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ObservabilityAdmin.Model.AzureScopeItem[] Manifest_Source_Azure { get; set; }
        #endregion
        
        #region Parameter ConnectorIdentifier
        /// <summary>
        /// <para>
        /// <para>The connector. Specify one of the following:</para><ul><li><para>The Amazon Resource Name (ARN) of the connector</para></li><li><para>The ID of the connector</para></li></ul>
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
        public System.String ConnectorIdentifier { get; set; }
        #endregion
        
        #region Parameter Manifest_Infrastructure_Azure_EventHub
        /// <summary>
        /// <para>
        /// <para>The Event Hubs configuration. Specify exactly one entry, which applies to the Event
        /// Hubs in every Azure Region. This value applies only if an <c>AzureScopeItem</c> collects
        /// <c>ResourceLogs</c>. If you omit it, the setup uses default settings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Manifest_Infrastructure_Azure_EventHubs")]
        public Amazon.ObservabilityAdmin.Model.AzureEventHubConfiguration[] Manifest_Infrastructure_Azure_EventHub { get; set; }
        #endregion
        
        #region Parameter ExpectedVersion
        /// <summary>
        /// <para>
        /// <para>The version of the telemetry manifest that you expect to replace, as returned by <c>GetConnectorTelemetryManifest</c>.
        /// Omit this value when you create the first telemetry manifest. If the value doesn't
        /// match the current version, the request fails with a <c>ConflictException</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ExpectedVersion { get; set; }
        #endregion
        
        #region Parameter Manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay
        /// <summary>
        /// <para>
        /// <para>The number of days that the created Storage Accounts keep Flow Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDays")]
        public System.Int32? Manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay { get; set; }
        #endregion
        
        #region Parameter Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount
        /// <summary>
        /// <para>
        /// <para>The Storage Accounts that store your Flow Logs, listed by Azure Region. Each Region
        /// can appear only once, and each Storage Account can appear only once across all Regions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccounts")]
        public Amazon.ObservabilityAdmin.Model.AzureFlowLogStorageAccountScope[] Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount { get; set; }
        #endregion
        
        #region Parameter Manifest_Infrastructure_Azure_SubscriptionId
        /// <summary>
        /// <para>
        /// <para>The Azure subscription in which the setup creates the Event Hubs namespaces and, for
        /// <c>AwsManaged</c> Flow Logs, the Storage Accounts. You must specify this value if
        /// an <c>AzureScopeItem</c> collects <c>ResourceLogs</c>, or if you specify <c>EventHubs</c>
        /// or <c>AwsManaged</c> Flow Logs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Manifest_Infrastructure_Azure_SubscriptionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the operation completes
        /// no more than one time. If you use an Amazon Web Services SDK, the SDK generates this
        /// value and reuses it on retries. If this token matches a previous request with the
        /// same telemetry manifest, the service returns the stored version without an error.
        /// If you use the same token with a different telemetry manifest, the service returns
        /// a <c>ValidationException</c>. This operation is idempotent when you use the same token
        /// and parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Version'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Version";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWOADMNConnectorTelemetryManifest (PutConnectorTelemetryManifest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestResponse, WriteCWOADMNConnectorTelemetryManifestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectorIdentifier = this.ConnectorIdentifier;
            #if MODULAR
            if (this.ConnectorIdentifier == null && ParameterWasBound(nameof(this.ConnectorIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpectedVersion = this.ExpectedVersion;
            if (this.Manifest_Infrastructure_Azure_EventHub != null)
            {
                context.Manifest_Infrastructure_Azure_EventHub = new List<Amazon.ObservabilityAdmin.Model.AzureEventHubConfiguration>(this.Manifest_Infrastructure_Azure_EventHub);
            }
            context.Manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay = this.Manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay;
            if (this.Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount != null)
            {
                context.Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount = new List<Amazon.ObservabilityAdmin.Model.AzureFlowLogStorageAccountScope>(this.Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount);
            }
            context.Manifest_Infrastructure_Azure_SubscriptionId = this.Manifest_Infrastructure_Azure_SubscriptionId;
            if (this.Manifest_Source_Azure != null)
            {
                context.Manifest_Source_Azure = new List<Amazon.ObservabilityAdmin.Model.AzureScopeItem>(this.Manifest_Source_Azure);
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
            var request = new Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConnectorIdentifier != null)
            {
                request.ConnectorIdentifier = cmdletContext.ConnectorIdentifier;
            }
            if (cmdletContext.ExpectedVersion != null)
            {
                request.ExpectedVersion = cmdletContext.ExpectedVersion.Value;
            }
            
             // populate Manifest
            var requestManifestIsNull = true;
            request.Manifest = new Amazon.ObservabilityAdmin.Model.TelemetryManifest();
            Amazon.ObservabilityAdmin.Model.TelemetryManifestInfrastructure requestManifest_manifest_Infrastructure = null;
            
             // populate Infrastructure
            var requestManifest_manifest_InfrastructureIsNull = true;
            requestManifest_manifest_Infrastructure = new Amazon.ObservabilityAdmin.Model.TelemetryManifestInfrastructure();
            Amazon.ObservabilityAdmin.Model.AzureInfrastructure requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure = null;
            
             // populate Azure
            var requestManifest_manifest_Infrastructure_manifest_Infrastructure_AzureIsNull = true;
            requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure = new Amazon.ObservabilityAdmin.Model.AzureInfrastructure();
            List<Amazon.ObservabilityAdmin.Model.AzureEventHubConfiguration> requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_EventHub = null;
            if (cmdletContext.Manifest_Infrastructure_Azure_EventHub != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_EventHub = cmdletContext.Manifest_Infrastructure_Azure_EventHub;
            }
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_EventHub != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure.EventHubs = requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_EventHub;
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_AzureIsNull = false;
            }
            System.String requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_SubscriptionId = null;
            if (cmdletContext.Manifest_Infrastructure_Azure_SubscriptionId != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_SubscriptionId = cmdletContext.Manifest_Infrastructure_Azure_SubscriptionId;
            }
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_SubscriptionId != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure.SubscriptionId = requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_SubscriptionId;
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_AzureIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureFlowLogsInfrastructure requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs = null;
            
             // populate FlowLogs
            var requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogsIsNull = true;
            requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs = new Amazon.ObservabilityAdmin.Model.AzureFlowLogsInfrastructure();
            Amazon.ObservabilityAdmin.Model.AzureAwsManagedFlowLogs requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged = null;
            
             // populate AwsManaged
            var requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManagedIsNull = true;
            requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged = new Amazon.ObservabilityAdmin.Model.AzureAwsManagedFlowLogs();
            System.Int32? requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged_manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay = null;
            if (cmdletContext.Manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged_manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay = cmdletContext.Manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay.Value;
            }
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged_manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged.RetentionDays = requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged_manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay.Value;
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManagedIsNull = false;
            }
             // determine if requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged should be set to null
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManagedIsNull)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged = null;
            }
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs.AwsManaged = requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_AwsManaged;
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogsIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.AzureCustomerManagedFlowLogs requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged = null;
            
             // populate CustomerManaged
            var requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManagedIsNull = true;
            requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged = new Amazon.ObservabilityAdmin.Model.AzureCustomerManagedFlowLogs();
            List<Amazon.ObservabilityAdmin.Model.AzureFlowLogStorageAccountScope> requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount = null;
            if (cmdletContext.Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount = cmdletContext.Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount;
            }
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged.StorageAccounts = requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount;
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManagedIsNull = false;
            }
             // determine if requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged should be set to null
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManagedIsNull)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged = null;
            }
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs.CustomerManaged = requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs_manifest_Infrastructure_Azure_FlowLogs_CustomerManaged;
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogsIsNull = false;
            }
             // determine if requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs should be set to null
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogsIsNull)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs = null;
            }
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs != null)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure.FlowLogs = requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure_manifest_Infrastructure_Azure_FlowLogs;
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_AzureIsNull = false;
            }
             // determine if requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure should be set to null
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_AzureIsNull)
            {
                requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure = null;
            }
            if (requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure != null)
            {
                requestManifest_manifest_Infrastructure.Azure = requestManifest_manifest_Infrastructure_manifest_Infrastructure_Azure;
                requestManifest_manifest_InfrastructureIsNull = false;
            }
             // determine if requestManifest_manifest_Infrastructure should be set to null
            if (requestManifest_manifest_InfrastructureIsNull)
            {
                requestManifest_manifest_Infrastructure = null;
            }
            if (requestManifest_manifest_Infrastructure != null)
            {
                request.Manifest.Infrastructure = requestManifest_manifest_Infrastructure;
                requestManifestIsNull = false;
            }
            Amazon.ObservabilityAdmin.Model.TelemetryManifestSource requestManifest_manifest_Source = null;
            
             // populate Source
            var requestManifest_manifest_SourceIsNull = true;
            requestManifest_manifest_Source = new Amazon.ObservabilityAdmin.Model.TelemetryManifestSource();
            List<Amazon.ObservabilityAdmin.Model.AzureScopeItem> requestManifest_manifest_Source_manifest_Source_Azure = null;
            if (cmdletContext.Manifest_Source_Azure != null)
            {
                requestManifest_manifest_Source_manifest_Source_Azure = cmdletContext.Manifest_Source_Azure;
            }
            if (requestManifest_manifest_Source_manifest_Source_Azure != null)
            {
                requestManifest_manifest_Source.Azure = requestManifest_manifest_Source_manifest_Source_Azure;
                requestManifest_manifest_SourceIsNull = false;
            }
             // determine if requestManifest_manifest_Source should be set to null
            if (requestManifest_manifest_SourceIsNull)
            {
                requestManifest_manifest_Source = null;
            }
            if (requestManifest_manifest_Source != null)
            {
                request.Manifest.Source = requestManifest_manifest_Source;
                requestManifestIsNull = false;
            }
             // determine if request.Manifest should be set to null
            if (requestManifestIsNull)
            {
                request.Manifest = null;
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
        
        private Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "PutConnectorTelemetryManifest");
            try
            {
                return client.PutConnectorTelemetryManifestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorIdentifier { get; set; }
            public System.Int64? ExpectedVersion { get; set; }
            public List<Amazon.ObservabilityAdmin.Model.AzureEventHubConfiguration> Manifest_Infrastructure_Azure_EventHub { get; set; }
            public System.Int32? Manifest_Infrastructure_Azure_FlowLogs_AwsManaged_RetentionDay { get; set; }
            public List<Amazon.ObservabilityAdmin.Model.AzureFlowLogStorageAccountScope> Manifest_Infrastructure_Azure_FlowLogs_CustomerManaged_StorageAccount { get; set; }
            public System.String Manifest_Infrastructure_Azure_SubscriptionId { get; set; }
            public List<Amazon.ObservabilityAdmin.Model.AzureScopeItem> Manifest_Source_Azure { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.PutConnectorTelemetryManifestResponse, WriteCWOADMNConnectorTelemetryManifestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Version;
        }
        
    }
}
