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
    /// Creates a connector to a third-party cloud provider. With a connector, you can discover
    /// resources in the provider and collect their telemetry. Currently, Microsoft Azure
    /// is the only supported provider.
    /// </summary>
    [Cmdlet("New", "CWOADMNConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ObservabilityAdmin.Model.Connector")]
    [AWSCmdlet("Calls the CloudWatch Observability Admin Service CreateConnector API operation.", Operation = new[] {"CreateConnector"}, SelectReturnType = typeof(Amazon.ObservabilityAdmin.Model.CreateConnectorResponse))]
    [AWSCmdletOutput("Amazon.ObservabilityAdmin.Model.Connector or Amazon.ObservabilityAdmin.Model.CreateConnectorResponse",
        "This cmdlet returns an Amazon.ObservabilityAdmin.Model.Connector object.",
        "The service call response (type Amazon.ObservabilityAdmin.Model.CreateConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCWOADMNConnectorCmdlet : AmazonObservabilityAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorConfiguration_Azure_ClientIdentifier
        /// <summary>
        /// <para>
        /// <para>The application (client) ID of the Azure app registration. The app registration must
        /// have a federated identity credential that trusts the Amazon Web Services OpenID Connect
        /// (OIDC) issuer for your account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorConfiguration_Azure_ClientIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the connector. The name must be unique in the account and Region (case-sensitive).
        /// If another connector already uses the name, the request fails with a <c>ConflictException</c>.</para><para>The name can contain letters, digits, hyphens (-), underscores (_) and periods (.),
        /// and must start with a letter.</para>
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
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Web Services Identity and Access Management
        /// (IAM) role that CloudWatch assumes to get credentials for the third-party cloud provider.
        /// The role must trust the Amazon CloudWatch Observability Admin service principal, <c>observabilityadmin.amazonaws.com</c>.
        /// The role must also allow <c>sts:GetWebIdentityToken</c> for the provider's token exchange
        /// audience.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags that you want to apply to the connector.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ConnectorConfiguration_Azure_TenantIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the Microsoft Entra ID tenant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorConfiguration_Azure_TenantIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the operation completes
        /// no more than one time. If you use an Amazon Web Services SDK, the SDK generates this
        /// value and reuses it on retries. If this token matches a previous request with the
        /// same parameters, the service returns the connector from the first request without
        /// an error. If you use the same token with different parameters, including different
        /// tags, the service returns a <c>ValidationException</c>. This operation is idempotent
        /// when you use the same token and parameters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Connector'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ObservabilityAdmin.Model.CreateConnectorResponse).
        /// Specifying the name of a property of type Amazon.ObservabilityAdmin.Model.CreateConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Connector";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorConfiguration_Azure_ClientIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWOADMNConnector (CreateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ObservabilityAdmin.Model.CreateConnectorResponse, NewCWOADMNConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConnectorConfiguration_Azure_ClientIdentifier = this.ConnectorConfiguration_Azure_ClientIdentifier;
            context.ConnectorConfiguration_Azure_TenantIdentifier = this.ConnectorConfiguration_Azure_TenantIdentifier;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ObservabilityAdmin.Model.CreateConnectorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate ConnectorConfiguration
            var requestConnectorConfigurationIsNull = true;
            request.ConnectorConfiguration = new Amazon.ObservabilityAdmin.Model.ConnectorConfiguration();
            Amazon.ObservabilityAdmin.Model.AzureConnectorConfiguration requestConnectorConfiguration_connectorConfiguration_Azure = null;
            
             // populate Azure
            var requestConnectorConfiguration_connectorConfiguration_AzureIsNull = true;
            requestConnectorConfiguration_connectorConfiguration_Azure = new Amazon.ObservabilityAdmin.Model.AzureConnectorConfiguration();
            System.String requestConnectorConfiguration_connectorConfiguration_Azure_connectorConfiguration_Azure_ClientIdentifier = null;
            if (cmdletContext.ConnectorConfiguration_Azure_ClientIdentifier != null)
            {
                requestConnectorConfiguration_connectorConfiguration_Azure_connectorConfiguration_Azure_ClientIdentifier = cmdletContext.ConnectorConfiguration_Azure_ClientIdentifier;
            }
            if (requestConnectorConfiguration_connectorConfiguration_Azure_connectorConfiguration_Azure_ClientIdentifier != null)
            {
                requestConnectorConfiguration_connectorConfiguration_Azure.ClientIdentifier = requestConnectorConfiguration_connectorConfiguration_Azure_connectorConfiguration_Azure_ClientIdentifier;
                requestConnectorConfiguration_connectorConfiguration_AzureIsNull = false;
            }
            System.String requestConnectorConfiguration_connectorConfiguration_Azure_connectorConfiguration_Azure_TenantIdentifier = null;
            if (cmdletContext.ConnectorConfiguration_Azure_TenantIdentifier != null)
            {
                requestConnectorConfiguration_connectorConfiguration_Azure_connectorConfiguration_Azure_TenantIdentifier = cmdletContext.ConnectorConfiguration_Azure_TenantIdentifier;
            }
            if (requestConnectorConfiguration_connectorConfiguration_Azure_connectorConfiguration_Azure_TenantIdentifier != null)
            {
                requestConnectorConfiguration_connectorConfiguration_Azure.TenantIdentifier = requestConnectorConfiguration_connectorConfiguration_Azure_connectorConfiguration_Azure_TenantIdentifier;
                requestConnectorConfiguration_connectorConfiguration_AzureIsNull = false;
            }
             // determine if requestConnectorConfiguration_connectorConfiguration_Azure should be set to null
            if (requestConnectorConfiguration_connectorConfiguration_AzureIsNull)
            {
                requestConnectorConfiguration_connectorConfiguration_Azure = null;
            }
            if (requestConnectorConfiguration_connectorConfiguration_Azure != null)
            {
                request.ConnectorConfiguration.Azure = requestConnectorConfiguration_connectorConfiguration_Azure;
                requestConnectorConfigurationIsNull = false;
            }
             // determine if request.ConnectorConfiguration should be set to null
            if (requestConnectorConfigurationIsNull)
            {
                request.ConnectorConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.ObservabilityAdmin.Model.CreateConnectorResponse CallAWSServiceOperation(IAmazonObservabilityAdmin client, Amazon.ObservabilityAdmin.Model.CreateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "CloudWatch Observability Admin Service", "CreateConnector");
            try
            {
                return client.CreateConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorConfiguration_Azure_ClientIdentifier { get; set; }
            public System.String ConnectorConfiguration_Azure_TenantIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.String RoleArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.ObservabilityAdmin.Model.CreateConnectorResponse, NewCWOADMNConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Connector;
        }
        
    }
}
