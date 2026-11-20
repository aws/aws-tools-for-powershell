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
using Amazon.APIPortal;
using Amazon.APIPortal.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APIP
{
    /// <summary>
    /// Creates a product. A product groups Managed APIs with their API pages and product
    /// pages so a portal can publish them together.
    /// </summary>
    [Cmdlet("New", "APIPProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIPortal.Model.CreateProductResponse")]
    [AWSCmdlet("Calls the APIPortal CreateProduct API operation.", Operation = new[] {"CreateProduct"}, SelectReturnType = typeof(Amazon.APIPortal.Model.CreateProductResponse))]
    [AWSCmdletOutput("Amazon.APIPortal.Model.CreateProductResponse",
        "This cmdlet returns an Amazon.APIPortal.Model.CreateProductResponse object containing multiple properties."
    )]
    public partial class NewAPIPProductCmdlet : AmazonAPIPortalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ApiSelectionConfiguration_ApiSelectionMode
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.APIPortal.ApiSelectionMode")]
        public Amazon.APIPortal.ApiSelectionMode ApiSelectionConfiguration_ApiSelectionMode { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A description of the product, up to 1024 characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// The name of the product, from 1 to 255 characters.
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter ApiSelectionConfiguration_RuleFilter
        /// <summary>
        /// <para>
        /// Required for RULE_BASED, rejected for CUSTOM.
        /// Filters are combined with AND, the values within one filter with OR, and evaluated
        /// only over the account's Managed APIs. Replaced as a whole on update, not merged.
        /// <para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ApiSelectionConfiguration_RuleFilters")]
        public Amazon.APIPortal.Model.RuleFilter[] ApiSelectionConfiguration_RuleFilter { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para />
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIPortal.Model.CreateProductResponse).
        /// Specifying the name of a property of type Amazon.APIPortal.Model.CreateProductResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DisplayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APIPProduct (CreateProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIPortal.Model.CreateProductResponse, NewAPIPProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiSelectionConfiguration_ApiSelectionMode = this.ApiSelectionConfiguration_ApiSelectionMode;
            if (this.ApiSelectionConfiguration_RuleFilter != null)
            {
                context.ApiSelectionConfiguration_RuleFilter = new List<Amazon.APIPortal.Model.RuleFilter>(this.ApiSelectionConfiguration_RuleFilter);
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.APIPortal.Model.CreateProductRequest();
            
            
             // populate ApiSelectionConfiguration
            var requestApiSelectionConfigurationIsNull = true;
            request.ApiSelectionConfiguration = new Amazon.APIPortal.Model.ApiSelectionConfiguration();
            Amazon.APIPortal.ApiSelectionMode requestApiSelectionConfiguration_apiSelectionConfiguration_ApiSelectionMode = null;
            if (cmdletContext.ApiSelectionConfiguration_ApiSelectionMode != null)
            {
                requestApiSelectionConfiguration_apiSelectionConfiguration_ApiSelectionMode = cmdletContext.ApiSelectionConfiguration_ApiSelectionMode;
            }
            if (requestApiSelectionConfiguration_apiSelectionConfiguration_ApiSelectionMode != null)
            {
                request.ApiSelectionConfiguration.ApiSelectionMode = requestApiSelectionConfiguration_apiSelectionConfiguration_ApiSelectionMode;
                requestApiSelectionConfigurationIsNull = false;
            }
            List<Amazon.APIPortal.Model.RuleFilter> requestApiSelectionConfiguration_apiSelectionConfiguration_RuleFilter = null;
            if (cmdletContext.ApiSelectionConfiguration_RuleFilter != null)
            {
                requestApiSelectionConfiguration_apiSelectionConfiguration_RuleFilter = cmdletContext.ApiSelectionConfiguration_RuleFilter;
            }
            if (requestApiSelectionConfiguration_apiSelectionConfiguration_RuleFilter != null)
            {
                request.ApiSelectionConfiguration.RuleFilters = requestApiSelectionConfiguration_apiSelectionConfiguration_RuleFilter;
                requestApiSelectionConfigurationIsNull = false;
            }
             // determine if request.ApiSelectionConfiguration should be set to null
            if (requestApiSelectionConfigurationIsNull)
            {
                request.ApiSelectionConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
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
        
        private Amazon.APIPortal.Model.CreateProductResponse CallAWSServiceOperation(IAmazonAPIPortal client, Amazon.APIPortal.Model.CreateProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "APIPortal", "CreateProduct");
            try
            {
                return client.CreateProductAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.APIPortal.ApiSelectionMode ApiSelectionConfiguration_ApiSelectionMode { get; set; }
            public List<Amazon.APIPortal.Model.RuleFilter> ApiSelectionConfiguration_RuleFilter { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.APIPortal.Model.CreateProductResponse, NewAPIPProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
