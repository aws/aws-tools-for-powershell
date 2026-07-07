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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Updates a CSPM connector's configuration, such as the scope or regions for the connected
    /// cloud provider.
    /// </summary>
    [Cmdlet("Update", "SHUBConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.UpdateConnectorResponse")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateConnector API operation.", Operation = new[] {"UpdateConnector"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.UpdateConnectorResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.UpdateConnectorResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.UpdateConnectorResponse object containing multiple properties."
    )]
    public partial class UpdateSHUBConnectorCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Provider_Azure_AzureRegion
        /// <summary>
        /// <para>
        /// <para>The updated list of Azure regions to monitor.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provider_Azure_AzureRegions")]
        public System.String[] Provider_Azure_AzureRegion { get; set; }
        #endregion
        
        #region Parameter ConnectorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the connector to update.</para>
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
        public System.String ConnectorId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description of the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Provider_Azure_ScopeConfiguration_ScopeType
        /// <summary>
        /// <para>
        /// <para>The type of scope. Valid values are <c>tenant</c> and <c>subscription</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.ScopeType")]
        public Amazon.SecurityHub.ScopeType Provider_Azure_ScopeConfiguration_ScopeType { get; set; }
        #endregion
        
        #region Parameter Provider_Azure_ScopeConfiguration_ScopeValue
        /// <summary>
        /// <para>
        /// <para>The list of scope values, such as subscription IDs, when the scope type is <c>subscription</c>.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Provider_Azure_ScopeConfiguration_ScopeValues")]
        public System.String[] Provider_Azure_ScopeConfiguration_ScopeValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.UpdateConnectorResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.UpdateConnectorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConnectorId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBConnector (UpdateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.UpdateConnectorResponse, UpdateSHUBConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ConnectorId = this.ConnectorId;
            #if MODULAR
            if (this.ConnectorId == null && ParameterWasBound(nameof(this.ConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            if (this.Provider_Azure_AzureRegion != null)
            {
                context.Provider_Azure_AzureRegion = new List<System.String>(this.Provider_Azure_AzureRegion);
            }
            context.Provider_Azure_ScopeConfiguration_ScopeType = this.Provider_Azure_ScopeConfiguration_ScopeType;
            if (this.Provider_Azure_ScopeConfiguration_ScopeValue != null)
            {
                context.Provider_Azure_ScopeConfiguration_ScopeValue = new List<System.String>(this.Provider_Azure_ScopeConfiguration_ScopeValue);
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
            var request = new Amazon.SecurityHub.Model.UpdateConnectorRequest();
            
            if (cmdletContext.ConnectorId != null)
            {
                request.ConnectorId = cmdletContext.ConnectorId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate Provider
            var requestProviderIsNull = true;
            request.Provider = new Amazon.SecurityHub.Model.CspmProviderUpdateConfiguration();
            Amazon.SecurityHub.Model.AzureUpdateConfiguration requestProvider_provider_Azure = null;
            
             // populate Azure
            var requestProvider_provider_AzureIsNull = true;
            requestProvider_provider_Azure = new Amazon.SecurityHub.Model.AzureUpdateConfiguration();
            List<System.String> requestProvider_provider_Azure_provider_Azure_AzureRegion = null;
            if (cmdletContext.Provider_Azure_AzureRegion != null)
            {
                requestProvider_provider_Azure_provider_Azure_AzureRegion = cmdletContext.Provider_Azure_AzureRegion;
            }
            if (requestProvider_provider_Azure_provider_Azure_AzureRegion != null)
            {
                requestProvider_provider_Azure.AzureRegions = requestProvider_provider_Azure_provider_Azure_AzureRegion;
                requestProvider_provider_AzureIsNull = false;
            }
            Amazon.SecurityHub.Model.AzureScopeConfiguration requestProvider_provider_Azure_provider_Azure_ScopeConfiguration = null;
            
             // populate ScopeConfiguration
            var requestProvider_provider_Azure_provider_Azure_ScopeConfigurationIsNull = true;
            requestProvider_provider_Azure_provider_Azure_ScopeConfiguration = new Amazon.SecurityHub.Model.AzureScopeConfiguration();
            Amazon.SecurityHub.ScopeType requestProvider_provider_Azure_provider_Azure_ScopeConfiguration_provider_Azure_ScopeConfiguration_ScopeType = null;
            if (cmdletContext.Provider_Azure_ScopeConfiguration_ScopeType != null)
            {
                requestProvider_provider_Azure_provider_Azure_ScopeConfiguration_provider_Azure_ScopeConfiguration_ScopeType = cmdletContext.Provider_Azure_ScopeConfiguration_ScopeType;
            }
            if (requestProvider_provider_Azure_provider_Azure_ScopeConfiguration_provider_Azure_ScopeConfiguration_ScopeType != null)
            {
                requestProvider_provider_Azure_provider_Azure_ScopeConfiguration.ScopeType = requestProvider_provider_Azure_provider_Azure_ScopeConfiguration_provider_Azure_ScopeConfiguration_ScopeType;
                requestProvider_provider_Azure_provider_Azure_ScopeConfigurationIsNull = false;
            }
            List<System.String> requestProvider_provider_Azure_provider_Azure_ScopeConfiguration_provider_Azure_ScopeConfiguration_ScopeValue = null;
            if (cmdletContext.Provider_Azure_ScopeConfiguration_ScopeValue != null)
            {
                requestProvider_provider_Azure_provider_Azure_ScopeConfiguration_provider_Azure_ScopeConfiguration_ScopeValue = cmdletContext.Provider_Azure_ScopeConfiguration_ScopeValue;
            }
            if (requestProvider_provider_Azure_provider_Azure_ScopeConfiguration_provider_Azure_ScopeConfiguration_ScopeValue != null)
            {
                requestProvider_provider_Azure_provider_Azure_ScopeConfiguration.ScopeValues = requestProvider_provider_Azure_provider_Azure_ScopeConfiguration_provider_Azure_ScopeConfiguration_ScopeValue;
                requestProvider_provider_Azure_provider_Azure_ScopeConfigurationIsNull = false;
            }
             // determine if requestProvider_provider_Azure_provider_Azure_ScopeConfiguration should be set to null
            if (requestProvider_provider_Azure_provider_Azure_ScopeConfigurationIsNull)
            {
                requestProvider_provider_Azure_provider_Azure_ScopeConfiguration = null;
            }
            if (requestProvider_provider_Azure_provider_Azure_ScopeConfiguration != null)
            {
                requestProvider_provider_Azure.ScopeConfiguration = requestProvider_provider_Azure_provider_Azure_ScopeConfiguration;
                requestProvider_provider_AzureIsNull = false;
            }
             // determine if requestProvider_provider_Azure should be set to null
            if (requestProvider_provider_AzureIsNull)
            {
                requestProvider_provider_Azure = null;
            }
            if (requestProvider_provider_Azure != null)
            {
                request.Provider.Azure = requestProvider_provider_Azure;
                requestProviderIsNull = false;
            }
             // determine if request.Provider should be set to null
            if (requestProviderIsNull)
            {
                request.Provider = null;
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
        
        private Amazon.SecurityHub.Model.UpdateConnectorResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateConnector");
            try
            {
                return client.UpdateConnectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ConnectorId { get; set; }
            public System.String Description { get; set; }
            public List<System.String> Provider_Azure_AzureRegion { get; set; }
            public Amazon.SecurityHub.ScopeType Provider_Azure_ScopeConfiguration_ScopeType { get; set; }
            public List<System.String> Provider_Azure_ScopeConfiguration_ScopeValue { get; set; }
            public System.Func<Amazon.SecurityHub.Model.UpdateConnectorResponse, UpdateSHUBConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
