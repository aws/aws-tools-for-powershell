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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Creates a connector that specifies the connection between a third-party cloud service
    /// provider and Config.
    /// 
    ///  
    /// <para>
    /// A connector is required to create a service-linked configuration recorder for a third-party
    /// cloud service provider using the <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_PutThirdPartyServiceLinkedConfigurationRecorder.html">PutThirdPartyServiceLinkedConfigurationRecorder</a>
    /// operation.
    /// </para><para>
    /// This API creates a service-linked role <c>AWSServiceRoleForConfigThirdParty</c> in
    /// your account. The service-linked role is created only when the role does not exist
    /// in your account.
    /// </para><note><para><b>Connectors cannot be updated</b></para><para>
    /// To update the connector configuration, you must delete all associated configuration
    /// recorders, delete the connector, and recreate it with the updated configuration.
    /// </para></note><note><para><b>Tags are added at creation and cannot be updated with this operation</b></para><para>
    /// Use <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_TagResource.html">TagResource</a>
    /// and <a href="https://docs.aws.amazon.com/config/latest/APIReference/API_UntagResource.html">UntagResource</a>
    /// to update tags after creation.
    /// </para></note>
    /// </summary>
    [Cmdlet("Write", "CFGConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Config PutConnector API operation.", Operation = new[] {"PutConnector"}, SelectReturnType = typeof(Amazon.ConfigService.Model.PutConnectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.ConfigService.Model.PutConnectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.ConfigService.Model.PutConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCFGConnectorCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ConnectorConfiguration_Azure_ClientIdentifier
        /// <summary>
        /// <para>
        /// <para>The Azure client identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorConfiguration_Azure_ClientIdentifier { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags for the connector. Each tag consists of a key and an optional value, both
        /// of which you define.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ConfigService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ConnectorConfiguration_Azure_TenantIdentifier
        /// <summary>
        /// <para>
        /// <para>The Azure tenant identifier.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ConnectorConfiguration_Azure_TenantIdentifier { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Arn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.PutConnectorResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.PutConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Arn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CFGConnector (PutConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.PutConnectorResponse, WriteCFGConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorConfiguration_Azure_ClientIdentifier = this.ConnectorConfiguration_Azure_ClientIdentifier;
            context.ConnectorConfiguration_Azure_TenantIdentifier = this.ConnectorConfiguration_Azure_TenantIdentifier;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ConfigService.Model.Tag>(this.Tag);
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
            var request = new Amazon.ConfigService.Model.PutConnectorRequest();
            
            
             // populate ConnectorConfiguration
            var requestConnectorConfigurationIsNull = true;
            request.ConnectorConfiguration = new Amazon.ConfigService.Model.ConnectorConfiguration();
            Amazon.ConfigService.Model.AzureConnectorConfiguration requestConnectorConfiguration_connectorConfiguration_Azure = null;
            
             // populate Azure
            var requestConnectorConfiguration_connectorConfiguration_AzureIsNull = true;
            requestConnectorConfiguration_connectorConfiguration_Azure = new Amazon.ConfigService.Model.AzureConnectorConfiguration();
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
        
        private Amazon.ConfigService.Model.PutConnectorResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.PutConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "PutConnector");
            try
            {
                return client.PutConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorConfiguration_Azure_ClientIdentifier { get; set; }
            public System.String ConnectorConfiguration_Azure_TenantIdentifier { get; set; }
            public List<Amazon.ConfigService.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ConfigService.Model.PutConnectorResponse, WriteCFGConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Arn;
        }
        
    }
}
