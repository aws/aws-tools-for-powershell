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
    /// Creates a cloud service provider management (CSPM) connector in Security Hub CSPM.
    /// A connector establishes a connection between Security Hub CSPM and a third-party cloud
    /// provider, enabling Security Hub CSPM to ingest security findings and resource data
    /// from the connected environment.
    /// </summary>
    [Cmdlet("New", "SHUBConnector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.CreateConnectorResponse")]
    [AWSCmdlet("Calls the AWS Security Hub CreateConnector API operation.", Operation = new[] {"CreateConnector"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.CreateConnectorResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.CreateConnectorResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.CreateConnectorResponse object containing multiple properties."
    )]
    public partial class NewSHUBConnectorCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Provider_Azure_AWSConfigConnectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Config connector used to establish the connection to Azure.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Provider_Azure_AWSConfigConnectorArn { get; set; }
        #endregion
        
        #region Parameter Provider_Azure_AzureRegion
        /// <summary>
        /// <para>
        /// <para>The list of Azure regions to monitor.</para><para />
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the connector. Must be unique within the account.</para>
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
        public System.String Name { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the connector resource.</para><para />
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
        /// <para>A unique identifier used to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.CreateConnectorResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.CreateConnectorResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SHUBConnector (CreateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.CreateConnectorResponse, NewSHUBConnectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Provider_Azure_AWSConfigConnectorArn = this.Provider_Azure_AWSConfigConnectorArn;
            if (this.Provider_Azure_AzureRegion != null)
            {
                context.Provider_Azure_AzureRegion = new List<System.String>(this.Provider_Azure_AzureRegion);
            }
            context.Provider_Azure_ScopeConfiguration_ScopeType = this.Provider_Azure_ScopeConfiguration_ScopeType;
            if (this.Provider_Azure_ScopeConfiguration_ScopeValue != null)
            {
                context.Provider_Azure_ScopeConfiguration_ScopeValue = new List<System.String>(this.Provider_Azure_ScopeConfiguration_ScopeValue);
            }
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
            var request = new Amazon.SecurityHub.Model.CreateConnectorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Provider
            var requestProviderIsNull = true;
            request.Provider = new Amazon.SecurityHub.Model.CspmProviderConfiguration();
            Amazon.SecurityHub.Model.AzureProviderConfiguration requestProvider_provider_Azure = null;
            
             // populate Azure
            var requestProvider_provider_AzureIsNull = true;
            requestProvider_provider_Azure = new Amazon.SecurityHub.Model.AzureProviderConfiguration();
            System.String requestProvider_provider_Azure_provider_Azure_AWSConfigConnectorArn = null;
            if (cmdletContext.Provider_Azure_AWSConfigConnectorArn != null)
            {
                requestProvider_provider_Azure_provider_Azure_AWSConfigConnectorArn = cmdletContext.Provider_Azure_AWSConfigConnectorArn;
            }
            if (requestProvider_provider_Azure_provider_Azure_AWSConfigConnectorArn != null)
            {
                requestProvider_provider_Azure.AWSConfigConnectorArn = requestProvider_provider_Azure_provider_Azure_AWSConfigConnectorArn;
                requestProvider_provider_AzureIsNull = false;
            }
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
        
        private Amazon.SecurityHub.Model.CreateConnectorResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.CreateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "CreateConnector");
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
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String Provider_Azure_AWSConfigConnectorArn { get; set; }
            public List<System.String> Provider_Azure_AzureRegion { get; set; }
            public Amazon.SecurityHub.ScopeType Provider_Azure_ScopeConfiguration_ScopeType { get; set; }
            public List<System.String> Provider_Azure_ScopeConfiguration_ScopeValue { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.SecurityHub.Model.CreateConnectorResponse, NewSHUBConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
