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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Updates the portal product.
    /// </summary>
    [Cmdlet("Update", "AG2PortalProduct", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 UpdatePortalProduct API operation.", Operation = new[] {"UpdatePortalProduct"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse object containing multiple properties."
    )]
    public partial class UpdateAG2PortalProductCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DisplayOrder_Content
        /// <summary>
        /// <para>
        /// <para>Represents a list of sections which include section name and list of product REST
        /// endpoints for a product.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisplayOrder_Contents")]
        public Amazon.ApiGatewayV2.Model.Section[] DisplayOrder_Content { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The displayName.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter DisplayOrder_OverviewPageArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the overview page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayOrder_OverviewPageArn { get; set; }
        #endregion
        
        #region Parameter PortalProductId
        /// <summary>
        /// <para>
        /// <para>The portal product identifier.</para>
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
        public System.String PortalProductId { get; set; }
        #endregion
        
        #region Parameter DisplayOrder_ProductPageArn
        /// <summary>
        /// <para>
        /// <para>The product page ARNs.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisplayOrder_ProductPageArns")]
        public System.String[] DisplayOrder_ProductPageArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortalProductId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AG2PortalProduct (UpdatePortalProduct)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse, UpdateAG2PortalProductCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            if (this.DisplayOrder_Content != null)
            {
                context.DisplayOrder_Content = new List<Amazon.ApiGatewayV2.Model.Section>(this.DisplayOrder_Content);
            }
            context.DisplayOrder_OverviewPageArn = this.DisplayOrder_OverviewPageArn;
            if (this.DisplayOrder_ProductPageArn != null)
            {
                context.DisplayOrder_ProductPageArn = new List<System.String>(this.DisplayOrder_ProductPageArn);
            }
            context.PortalProductId = this.PortalProductId;
            #if MODULAR
            if (this.PortalProductId == null && ParameterWasBound(nameof(this.PortalProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApiGatewayV2.Model.UpdatePortalProductRequest();
            
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
            request.DisplayOrder = new Amazon.ApiGatewayV2.Model.DisplayOrder();
            List<Amazon.ApiGatewayV2.Model.Section> requestDisplayOrder_displayOrder_Content = null;
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
            if (cmdletContext.PortalProductId != null)
            {
                request.PortalProductId = cmdletContext.PortalProductId;
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
        
        private Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.UpdatePortalProductRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "UpdatePortalProduct");
            try
            {
                return client.UpdatePortalProductAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public List<Amazon.ApiGatewayV2.Model.Section> DisplayOrder_Content { get; set; }
            public System.String DisplayOrder_OverviewPageArn { get; set; }
            public List<System.String> DisplayOrder_ProductPageArn { get; set; }
            public System.String PortalProductId { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.UpdatePortalProductResponse, UpdateAG2PortalProductCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
