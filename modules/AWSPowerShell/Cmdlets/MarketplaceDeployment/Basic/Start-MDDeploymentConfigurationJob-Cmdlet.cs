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
using Amazon.MarketplaceDeployment;
using Amazon.MarketplaceDeployment.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.MD
{
    /// <summary>
    /// Starts a job that publishes a deployment configuration for a product and delivery
    /// option. The job runs asynchronously. Use <c>GetDeploymentConfigurationJob</c> to track
    /// its status. When the job reaches the <c>SUCCEEDED</c> status, its configuration becomes
    /// the active deployment configuration for the product and delivery option.
    /// 
    ///  
    /// <para>
    /// The populated member of <c>configuration</c> must match the <c>deliveryOptionType</c>
    /// in the request path.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "MDDeploymentConfigurationJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse")]
    [AWSCmdlet("Calls the AWS Marketplace Deployment Service StartDeploymentConfigurationJob API operation.", Operation = new[] {"StartDeploymentConfigurationJob"}, SelectReturnType = typeof(Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse))]
    [AWSCmdletOutput("Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse",
        "This cmdlet returns an Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse object containing multiple properties."
    )]
    public partial class StartMDDeploymentConfigurationJobCmdlet : AmazonMarketplaceDeploymentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Catalog
        /// <summary>
        /// <para>
        /// <para>The catalog related to the request. Fixed value: <c>AWSMarketplace</c></para>
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
        public System.String Catalog { get; set; }
        #endregion
        
        #region Parameter DeliveryOptionType
        /// <summary>
        /// <para>
        /// <para>The delivery option type of the deployment configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.MarketplaceDeployment.DeliveryOptionType")]
        public Amazon.MarketplaceDeployment.DeliveryOptionType DeliveryOptionType { get; set; }
        #endregion
        
        #region Parameter Configuration_DataAsAService_FulfillmentUrl
        /// <summary>
        /// <para>
        /// <para>The HTTPS URL that AWS Marketplace redirects buyers to after they subscribe to the
        /// product. The value must be a valid URI that uses the HTTPS scheme. Maximum length:
        /// 2,048 characters.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Configuration_DataAsAService_FulfillmentUrl { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// <para>The ID of the AWS Marketplace product, for example <c>prod-1234567890abc</c>.</para>
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
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of key-value pairs, where each pair represents a tag to apply to the deployment
        /// configuration. Only the request that creates the deployment configuration can apply
        /// tags. If the deployment configuration already exists, a request that includes one
        /// or more tags fails with a <c>ValidationException</c>. To change tags on an existing
        /// deployment configuration, use <c>TagResource</c> and <c>UntagResource</c>.</para><para />
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
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure that the operation
        /// completes no more than one time. If you retry a request with the same token and the
        /// same input, the service returns the original job instead of starting a new one. If
        /// you reuse a token with different input, the request fails with a <c>ConflictException</c>.</para><note><para>This field is not required if you're calling using an AWS SDK. Otherwise, a <c>clientToken</c>
        /// must be provided with the request.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse).
        /// Specifying the name of a property of type Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProductId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-MDDeploymentConfigurationJob (StartDeploymentConfigurationJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse, StartMDDeploymentConfigurationJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Catalog = this.Catalog;
            #if MODULAR
            if (this.Catalog == null && ParameterWasBound(nameof(this.Catalog)))
            {
                WriteWarning("You are passing $null as a value for parameter Catalog which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.Configuration_DataAsAService_FulfillmentUrl = this.Configuration_DataAsAService_FulfillmentUrl;
            context.DeliveryOptionType = this.DeliveryOptionType;
            #if MODULAR
            if (this.DeliveryOptionType == null && ParameterWasBound(nameof(this.DeliveryOptionType)))
            {
                WriteWarning("You are passing $null as a value for parameter DeliveryOptionType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProductId = this.ProductId;
            #if MODULAR
            if (this.ProductId == null && ParameterWasBound(nameof(this.ProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobRequest();
            
            if (cmdletContext.Catalog != null)
            {
                request.Catalog = cmdletContext.Catalog;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.MarketplaceDeployment.Model.DeploymentConfigurationDetail();
            Amazon.MarketplaceDeployment.Model.DataAsAServiceConfigurationDetail requestConfiguration_configuration_DataAsAService = null;
            
             // populate DataAsAService
            var requestConfiguration_configuration_DataAsAServiceIsNull = true;
            requestConfiguration_configuration_DataAsAService = new Amazon.MarketplaceDeployment.Model.DataAsAServiceConfigurationDetail();
            System.String requestConfiguration_configuration_DataAsAService_configuration_DataAsAService_FulfillmentUrl = null;
            if (cmdletContext.Configuration_DataAsAService_FulfillmentUrl != null)
            {
                requestConfiguration_configuration_DataAsAService_configuration_DataAsAService_FulfillmentUrl = cmdletContext.Configuration_DataAsAService_FulfillmentUrl;
            }
            if (requestConfiguration_configuration_DataAsAService_configuration_DataAsAService_FulfillmentUrl != null)
            {
                requestConfiguration_configuration_DataAsAService.FulfillmentUrl = requestConfiguration_configuration_DataAsAService_configuration_DataAsAService_FulfillmentUrl;
                requestConfiguration_configuration_DataAsAServiceIsNull = false;
            }
             // determine if requestConfiguration_configuration_DataAsAService should be set to null
            if (requestConfiguration_configuration_DataAsAServiceIsNull)
            {
                requestConfiguration_configuration_DataAsAService = null;
            }
            if (requestConfiguration_configuration_DataAsAService != null)
            {
                request.Configuration.DataAsAService = requestConfiguration_configuration_DataAsAService;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.DeliveryOptionType != null)
            {
                request.DeliveryOptionType = cmdletContext.DeliveryOptionType;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
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
        
        private Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse CallAWSServiceOperation(IAmazonMarketplaceDeployment client, Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Marketplace Deployment Service", "StartDeploymentConfigurationJob");
            try
            {
                return client.StartDeploymentConfigurationJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Catalog { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Configuration_DataAsAService_FulfillmentUrl { get; set; }
            public Amazon.MarketplaceDeployment.DeliveryOptionType DeliveryOptionType { get; set; }
            public System.String ProductId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MarketplaceDeployment.Model.StartDeploymentConfigurationJobResponse, StartMDDeploymentConfigurationJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
