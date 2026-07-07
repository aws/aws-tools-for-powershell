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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Creates a connector that links an external cloud provider to Amazon Inspector for
    /// vulnerability scanning.
    /// </summary>
    [Cmdlet("New", "INS2Connector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Inspector2 CreateConnector API operation.", Operation = new[] {"CreateConnector"}, SelectReturnType = typeof(Amazon.Inspector2.Model.CreateConnectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.Inspector2.Model.CreateConnectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Inspector2.Model.CreateConnectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewINS2ConnectorCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ProviderDetail_Azure_AutoInstallVMScanner
        /// <summary>
        /// <para>
        /// <para>Specifies whether to automatically install the VM scanner on connected Azure resources.
        /// Defaults to <c>true</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ProviderDetail_Azure_AutoInstallVMScanner { get; set; }
        #endregion
        
        #region Parameter ProviderDetail_Azure_AwsConfigConnectorArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services Config connector to associate with this connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderDetail_Azure_AwsConfigConnectorArn { get; set; }
        #endregion
        
        #region Parameter ProviderDetail_Azure_AzureRegion
        /// <summary>
        /// <para>
        /// <para>The Azure regions to scan.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProviderDetail_Azure_AzureRegions")]
        public System.String[] ProviderDetail_Azure_AzureRegion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the connector.</para>
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
        
        #region Parameter Provider
        /// <summary>
        /// <para>
        /// <para>The cloud provider for the connector.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Inspector2.ConnectorCloudProvider")]
        public Amazon.Inspector2.ConnectorCloudProvider Provider { get; set; }
        #endregion
        
        #region Parameter ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType
        /// <summary>
        /// <para>
        /// <para>The type of scope. Valid values are <c>TENANT</c>, which scans all resources in the
        /// Azure tenant, and <c>SUBSCRIPTION</c>, which scans only the resources in the specified
        /// Azure subscriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.ScopeType")]
        public Amazon.Inspector2.ScopeType ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType { get; set; }
        #endregion
        
        #region Parameter ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType
        /// <summary>
        /// <para>
        /// <para>The type of scope. Valid values are <c>TENANT</c>, which scans all resources in the
        /// Azure tenant, and <c>SUBSCRIPTION</c>, which scans only the resources in the specified
        /// Azure subscriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.ScopeType")]
        public Amazon.Inspector2.ScopeType ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType { get; set; }
        #endregion
        
        #region Parameter ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeType
        /// <summary>
        /// <para>
        /// <para>The type of scope. Valid values are <c>TENANT</c>, which scans all resources in the
        /// Azure tenant, and <c>SUBSCRIPTION</c>, which scans only the resources in the specified
        /// Azure subscriptions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.ScopeType")]
        public Amazon.Inspector2.ScopeType ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeType { get; set; }
        #endregion
        
        #region Parameter ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue
        /// <summary>
        /// <para>
        /// <para>The list of scope values. For subscription-level scope, these are Azure subscription
        /// IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValues")]
        public System.String[] ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue { get; set; }
        #endregion
        
        #region Parameter ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue
        /// <summary>
        /// <para>
        /// <para>The list of scope values. For subscription-level scope, these are Azure subscription
        /// IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValues")]
        public System.String[] ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue { get; set; }
        #endregion
        
        #region Parameter ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue
        /// <summary>
        /// <para>
        /// <para>The list of scope values. For subscription-level scope, these are Azure subscription
        /// IDs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValues")]
        public System.String[] ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the connector.</para><para />
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
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the operation
        /// completes no more than one time. If this token matches a previous request, the service
        /// ignores the request but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ConnectorArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.CreateConnectorResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.CreateConnectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ConnectorArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INS2Connector (CreateConnector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.CreateConnectorResponse, NewINS2ConnectorCmdlet>(Select) ??
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
            context.Provider = this.Provider;
            #if MODULAR
            if (this.Provider == null && ParameterWasBound(nameof(this.Provider)))
            {
                WriteWarning("You are passing $null as a value for parameter Provider which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProviderDetail_Azure_AutoInstallVMScanner = this.ProviderDetail_Azure_AutoInstallVMScanner;
            context.ProviderDetail_Azure_AwsConfigConnectorArn = this.ProviderDetail_Azure_AwsConfigConnectorArn;
            if (this.ProviderDetail_Azure_AzureRegion != null)
            {
                context.ProviderDetail_Azure_AzureRegion = new List<System.String>(this.ProviderDetail_Azure_AzureRegion);
            }
            context.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType = this.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType;
            if (this.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue != null)
            {
                context.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue = new List<System.String>(this.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue);
            }
            context.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType = this.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType;
            if (this.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue != null)
            {
                context.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue = new List<System.String>(this.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue);
            }
            context.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeType = this.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeType;
            if (this.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue != null)
            {
                context.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue = new List<System.String>(this.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue);
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
            var request = new Amazon.Inspector2.Model.CreateConnectorRequest();
            
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
            if (cmdletContext.Provider != null)
            {
                request.Provider = cmdletContext.Provider;
            }
            
             // populate ProviderDetail
            var requestProviderDetailIsNull = true;
            request.ProviderDetail = new Amazon.Inspector2.Model.ProviderDetailCreate();
            Amazon.Inspector2.Model.AzureProviderDetailCreate requestProviderDetail_providerDetail_Azure = null;
            
             // populate Azure
            var requestProviderDetail_providerDetail_AzureIsNull = true;
            requestProviderDetail_providerDetail_Azure = new Amazon.Inspector2.Model.AzureProviderDetailCreate();
            System.Boolean? requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AutoInstallVMScanner = null;
            if (cmdletContext.ProviderDetail_Azure_AutoInstallVMScanner != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AutoInstallVMScanner = cmdletContext.ProviderDetail_Azure_AutoInstallVMScanner.Value;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AutoInstallVMScanner != null)
            {
                requestProviderDetail_providerDetail_Azure.AutoInstallVMScanner = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AutoInstallVMScanner.Value;
                requestProviderDetail_providerDetail_AzureIsNull = false;
            }
            System.String requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AwsConfigConnectorArn = null;
            if (cmdletContext.ProviderDetail_Azure_AwsConfigConnectorArn != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AwsConfigConnectorArn = cmdletContext.ProviderDetail_Azure_AwsConfigConnectorArn;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AwsConfigConnectorArn != null)
            {
                requestProviderDetail_providerDetail_Azure.AwsConfigConnectorArn = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AwsConfigConnectorArn;
                requestProviderDetail_providerDetail_AzureIsNull = false;
            }
            List<System.String> requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AzureRegion = null;
            if (cmdletContext.ProviderDetail_Azure_AzureRegion != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AzureRegion = cmdletContext.ProviderDetail_Azure_AzureRegion;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AzureRegion != null)
            {
                requestProviderDetail_providerDetail_Azure.AzureRegions = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_AzureRegion;
                requestProviderDetail_providerDetail_AzureIsNull = false;
            }
            Amazon.Inspector2.Model.AzureScopeConfigurationInput requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration = null;
            
             // populate ScopeConfiguration
            var requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfigurationIsNull = true;
            requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration = new Amazon.Inspector2.Model.AzureScopeConfigurationInput();
            Amazon.Inspector2.Model.ScopeConfigurationInput requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning = null;
            
             // populate ContainerImageScanning
            var requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanningIsNull = true;
            requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning = new Amazon.Inspector2.Model.ScopeConfigurationInput();
            Amazon.Inspector2.ScopeType requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType = null;
            if (cmdletContext.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType = cmdletContext.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning.ScopeType = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanningIsNull = false;
            }
            List<System.String> requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue = null;
            if (cmdletContext.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue = cmdletContext.ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning.ScopeValues = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanningIsNull = false;
            }
             // determine if requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning should be set to null
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanningIsNull)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning = null;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration.ContainerImageScanning = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ContainerImageScanning;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfigurationIsNull = false;
            }
            Amazon.Inspector2.Model.ScopeConfigurationInput requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning = null;
            
             // populate ServerlessScanning
            var requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanningIsNull = true;
            requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning = new Amazon.Inspector2.Model.ScopeConfigurationInput();
            Amazon.Inspector2.ScopeType requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType = null;
            if (cmdletContext.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType = cmdletContext.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning.ScopeType = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanningIsNull = false;
            }
            List<System.String> requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue = null;
            if (cmdletContext.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue = cmdletContext.ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning.ScopeValues = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_providerDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanningIsNull = false;
            }
             // determine if requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning should be set to null
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanningIsNull)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning = null;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration.ServerlessScanning = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_ServerlessScanning;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfigurationIsNull = false;
            }
            Amazon.Inspector2.Model.ScopeConfigurationInput requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning = null;
            
             // populate VmScanning
            var requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanningIsNull = true;
            requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning = new Amazon.Inspector2.Model.ScopeConfigurationInput();
            Amazon.Inspector2.ScopeType requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning_providerDetail_Azure_ScopeConfiguration_VmScanning_ScopeType = null;
            if (cmdletContext.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeType != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning_providerDetail_Azure_ScopeConfiguration_VmScanning_ScopeType = cmdletContext.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeType;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning_providerDetail_Azure_ScopeConfiguration_VmScanning_ScopeType != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning.ScopeType = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning_providerDetail_Azure_ScopeConfiguration_VmScanning_ScopeType;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanningIsNull = false;
            }
            List<System.String> requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning_providerDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue = null;
            if (cmdletContext.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning_providerDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue = cmdletContext.ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning_providerDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning.ScopeValues = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning_providerDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanningIsNull = false;
            }
             // determine if requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning should be set to null
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanningIsNull)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning = null;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning != null)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration.VmScanning = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration_providerDetail_Azure_ScopeConfiguration_VmScanning;
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfigurationIsNull = false;
            }
             // determine if requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration should be set to null
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfigurationIsNull)
            {
                requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration = null;
            }
            if (requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration != null)
            {
                requestProviderDetail_providerDetail_Azure.ScopeConfiguration = requestProviderDetail_providerDetail_Azure_providerDetail_Azure_ScopeConfiguration;
                requestProviderDetail_providerDetail_AzureIsNull = false;
            }
             // determine if requestProviderDetail_providerDetail_Azure should be set to null
            if (requestProviderDetail_providerDetail_AzureIsNull)
            {
                requestProviderDetail_providerDetail_Azure = null;
            }
            if (requestProviderDetail_providerDetail_Azure != null)
            {
                request.ProviderDetail.Azure = requestProviderDetail_providerDetail_Azure;
                requestProviderDetailIsNull = false;
            }
             // determine if request.ProviderDetail should be set to null
            if (requestProviderDetailIsNull)
            {
                request.ProviderDetail = null;
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
        
        private Amazon.Inspector2.Model.CreateConnectorResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.CreateConnectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "CreateConnector");
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
            public Amazon.Inspector2.ConnectorCloudProvider Provider { get; set; }
            public System.Boolean? ProviderDetail_Azure_AutoInstallVMScanner { get; set; }
            public System.String ProviderDetail_Azure_AwsConfigConnectorArn { get; set; }
            public List<System.String> ProviderDetail_Azure_AzureRegion { get; set; }
            public Amazon.Inspector2.ScopeType ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeType { get; set; }
            public List<System.String> ProviderDetail_Azure_ScopeConfiguration_ContainerImageScanning_ScopeValue { get; set; }
            public Amazon.Inspector2.ScopeType ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeType { get; set; }
            public List<System.String> ProviderDetail_Azure_ScopeConfiguration_ServerlessScanning_ScopeValue { get; set; }
            public Amazon.Inspector2.ScopeType ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeType { get; set; }
            public List<System.String> ProviderDetail_Azure_ScopeConfiguration_VmScanning_ScopeValue { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Inspector2.Model.CreateConnectorResponse, NewINS2ConnectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ConnectorArn;
        }
        
    }
}
