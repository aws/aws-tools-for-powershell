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
    /// Updates a product. Only the fields supplied in the request are changed.
    /// </summary>
    [Cmdlet("Update", "APIPProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIPortal.Model.UpdateProductResponse")]
    [AWSCmdlet("Calls the APIPortal UpdateProduct API operation.", Operation = new[] {"UpdateProduct"}, SelectReturnType = typeof(Amazon.APIPortal.Model.UpdateProductResponse))]
    [AWSCmdletOutput("Amazon.APIPortal.Model.UpdateProductResponse",
        "This cmdlet returns an Amazon.APIPortal.Model.UpdateProductResponse object containing multiple properties."
    )]
    public partial class UpdateAPIPProductCmdlet : AmazonAPIPortalClientCmdlet, IExecutor
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
        
        #region Parameter DisplayOrder_Content
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
        [Alias("DisplayOrder_Contents")]
        public Amazon.APIPortal.Model.Section[] DisplayOrder_Content { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The new description of the product. Omit it
        /// to keep the current description.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// The new name of the product. Omit it to keep
        /// the current name.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter DisplayOrder_OverviewPageArn
        /// <summary>
        /// <para>
        /// The ARN of the product page shown as the
        /// product overview.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayOrder_OverviewPageArn { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// The identifier of the product.
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
        public System.String ProductId { get; set; }
        #endregion
        
        #region Parameter DisplayOrder_ProductPageArn
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
        [Alias("DisplayOrder_ProductPageArns")]
        public System.String[] DisplayOrder_ProductPageArn { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIPortal.Model.UpdateProductResponse).
        /// Specifying the name of a property of type Amazon.APIPortal.Model.UpdateProductResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APIPProduct (UpdateProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIPortal.Model.UpdateProductResponse, UpdateAPIPProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiSelectionConfiguration_ApiSelectionMode = this.ApiSelectionConfiguration_ApiSelectionMode;
            if (this.ApiSelectionConfiguration_RuleFilter != null)
            {
                context.ApiSelectionConfiguration_RuleFilter = new List<Amazon.APIPortal.Model.RuleFilter>(this.ApiSelectionConfiguration_RuleFilter);
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            if (this.DisplayOrder_Content != null)
            {
                context.DisplayOrder_Content = new List<Amazon.APIPortal.Model.Section>(this.DisplayOrder_Content);
            }
            context.DisplayOrder_OverviewPageArn = this.DisplayOrder_OverviewPageArn;
            if (this.DisplayOrder_ProductPageArn != null)
            {
                context.DisplayOrder_ProductPageArn = new List<System.String>(this.DisplayOrder_ProductPageArn);
            }
            context.ProductId = this.ProductId;
            #if MODULAR
            if (this.ProductId == null && ParameterWasBound(nameof(this.ProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.APIPortal.Model.UpdateProductRequest();
            
            
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
            
             // populate DisplayOrder
            var requestDisplayOrderIsNull = true;
            request.DisplayOrder = new Amazon.APIPortal.Model.DisplayOrder();
            List<Amazon.APIPortal.Model.Section> requestDisplayOrder_displayOrder_Content = null;
            if (cmdletContext.DisplayOrder_Content != null)
            {
                requestDisplayOrder_displayOrder_Content = cmdletContext.DisplayOrder_Content;
            }
            if (requestDisplayOrder_displayOrder_Content != null)
            {
                request.DisplayOrder.Contents = requestDisplayOrder_displayOrder_Content;
                requestDisplayOrderIsNull = false;
            }
            System.String requestDisplayOrder_displayOrder_OverviewPageArn = null;
            if (cmdletContext.DisplayOrder_OverviewPageArn != null)
            {
                requestDisplayOrder_displayOrder_OverviewPageArn = cmdletContext.DisplayOrder_OverviewPageArn;
            }
            if (requestDisplayOrder_displayOrder_OverviewPageArn != null)
            {
                request.DisplayOrder.OverviewPageArn = requestDisplayOrder_displayOrder_OverviewPageArn;
                requestDisplayOrderIsNull = false;
            }
            List<System.String> requestDisplayOrder_displayOrder_ProductPageArn = null;
            if (cmdletContext.DisplayOrder_ProductPageArn != null)
            {
                requestDisplayOrder_displayOrder_ProductPageArn = cmdletContext.DisplayOrder_ProductPageArn;
            }
            if (requestDisplayOrder_displayOrder_ProductPageArn != null)
            {
                request.DisplayOrder.ProductPageArns = requestDisplayOrder_displayOrder_ProductPageArn;
                requestDisplayOrderIsNull = false;
            }
             // determine if request.DisplayOrder should be set to null
            if (requestDisplayOrderIsNull)
            {
                request.DisplayOrder = null;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
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
        
        private Amazon.APIPortal.Model.UpdateProductResponse CallAWSServiceOperation(IAmazonAPIPortal client, Amazon.APIPortal.Model.UpdateProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "APIPortal", "UpdateProduct");
            try
            {
                return client.UpdateProductAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.APIPortal.Model.Section> DisplayOrder_Content { get; set; }
            public System.String DisplayOrder_OverviewPageArn { get; set; }
            public List<System.String> DisplayOrder_ProductPageArn { get; set; }
            public System.String ProductId { get; set; }
            public System.Func<Amazon.APIPortal.Model.UpdateProductResponse, UpdateAPIPProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
