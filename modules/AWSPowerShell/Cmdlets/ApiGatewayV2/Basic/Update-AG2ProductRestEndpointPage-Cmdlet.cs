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
    /// Updates a product REST endpoint page.
    /// </summary>
    [Cmdlet("Update", "AG2ProductRestEndpointPage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 UpdateProductRestEndpointPage API operation.", Operation = new[] {"UpdateProductRestEndpointPage"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse object containing multiple properties."
    )]
    public partial class UpdateAG2ProductRestEndpointPageCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Overrides_Body
        /// <summary>
        /// <para>
        /// <para>By default, this is the documentation of your REST API from API Gateway. You can provide
        /// custom documentation to override this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisplayContent_Overrides_Body")]
        public System.String Overrides_Body { get; set; }
        #endregion
        
        #region Parameter Overrides_Endpoint
        /// <summary>
        /// <para>
        /// <para>The URL for your REST API. By default, API Gateway uses the default execute API endpoint.
        /// You can provide a custom domain to override this value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisplayContent_Overrides_Endpoint")]
        public System.String Overrides_Endpoint { get; set; }
        #endregion
        
        #region Parameter DisplayContent_None
        /// <summary>
        /// <para>
        /// <para>If your product REST endpoint contains no overrides, the none object is returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ApiGatewayV2.Model.None DisplayContent_None { get; set; }
        #endregion
        
        #region Parameter Overrides_OperationName
        /// <summary>
        /// <para>
        /// <para>The operation name of the product REST endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DisplayContent_Overrides_OperationName")]
        public System.String Overrides_OperationName { get; set; }
        #endregion
        
        #region Parameter PortalProductId
        /// <summary>
        /// <para>
        /// <para>The portal product identifier.</para>
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
        public System.String PortalProductId { get; set; }
        #endregion
        
        #region Parameter ProductRestEndpointPageId
        /// <summary>
        /// <para>
        /// <para>The product REST endpoint identifier.</para>
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
        public System.String ProductRestEndpointPageId { get; set; }
        #endregion
        
        #region Parameter TryItState
        /// <summary>
        /// <para>
        /// <para>The try it state of a product REST endpoint page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.TryItState")]
        public Amazon.ApiGatewayV2.TryItState TryItState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProductRestEndpointPageId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-AG2ProductRestEndpointPage (UpdateProductRestEndpointPage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse, UpdateAG2ProductRestEndpointPageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DisplayContent_None = this.DisplayContent_None;
            context.Overrides_Body = this.Overrides_Body;
            context.Overrides_Endpoint = this.Overrides_Endpoint;
            context.Overrides_OperationName = this.Overrides_OperationName;
            context.PortalProductId = this.PortalProductId;
            #if MODULAR
            if (this.PortalProductId == null && ParameterWasBound(nameof(this.PortalProductId)))
            {
                WriteWarning("You are passing $null as a value for parameter PortalProductId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProductRestEndpointPageId = this.ProductRestEndpointPageId;
            #if MODULAR
            if (this.ProductRestEndpointPageId == null && ParameterWasBound(nameof(this.ProductRestEndpointPageId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProductRestEndpointPageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TryItState = this.TryItState;
            
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
            var request = new Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageRequest();
            
            
             // populate DisplayContent
            var requestDisplayContentIsNull = true;
            request.DisplayContent = new Amazon.ApiGatewayV2.Model.EndpointDisplayContent();
            Amazon.ApiGatewayV2.Model.None requestDisplayContent_displayContent_None = null;
            if (cmdletContext.DisplayContent_None != null)
            {
                requestDisplayContent_displayContent_None = cmdletContext.DisplayContent_None;
            }
            if (requestDisplayContent_displayContent_None != null)
            {
                request.DisplayContent.None = requestDisplayContent_displayContent_None;
                requestDisplayContentIsNull = false;
            }
            Amazon.ApiGatewayV2.Model.DisplayContentOverrides requestDisplayContent_displayContent_Overrides = null;
            
             // populate Overrides
            var requestDisplayContent_displayContent_OverridesIsNull = true;
            requestDisplayContent_displayContent_Overrides = new Amazon.ApiGatewayV2.Model.DisplayContentOverrides();
            System.String requestDisplayContent_displayContent_Overrides_overrides_Body = null;
            if (cmdletContext.Overrides_Body != null)
            {
                requestDisplayContent_displayContent_Overrides_overrides_Body = cmdletContext.Overrides_Body;
            }
            if (requestDisplayContent_displayContent_Overrides_overrides_Body != null)
            {
                requestDisplayContent_displayContent_Overrides.Body = requestDisplayContent_displayContent_Overrides_overrides_Body;
                requestDisplayContent_displayContent_OverridesIsNull = false;
            }
            System.String requestDisplayContent_displayContent_Overrides_overrides_Endpoint = null;
            if (cmdletContext.Overrides_Endpoint != null)
            {
                requestDisplayContent_displayContent_Overrides_overrides_Endpoint = cmdletContext.Overrides_Endpoint;
            }
            if (requestDisplayContent_displayContent_Overrides_overrides_Endpoint != null)
            {
                requestDisplayContent_displayContent_Overrides.Endpoint = requestDisplayContent_displayContent_Overrides_overrides_Endpoint;
                requestDisplayContent_displayContent_OverridesIsNull = false;
            }
            System.String requestDisplayContent_displayContent_Overrides_overrides_OperationName = null;
            if (cmdletContext.Overrides_OperationName != null)
            {
                requestDisplayContent_displayContent_Overrides_overrides_OperationName = cmdletContext.Overrides_OperationName;
            }
            if (requestDisplayContent_displayContent_Overrides_overrides_OperationName != null)
            {
                requestDisplayContent_displayContent_Overrides.OperationName = requestDisplayContent_displayContent_Overrides_overrides_OperationName;
                requestDisplayContent_displayContent_OverridesIsNull = false;
            }
             // determine if requestDisplayContent_displayContent_Overrides should be set to null
            if (requestDisplayContent_displayContent_OverridesIsNull)
            {
                requestDisplayContent_displayContent_Overrides = null;
            }
            if (requestDisplayContent_displayContent_Overrides != null)
            {
                request.DisplayContent.Overrides = requestDisplayContent_displayContent_Overrides;
                requestDisplayContentIsNull = false;
            }
             // determine if request.DisplayContent should be set to null
            if (requestDisplayContentIsNull)
            {
                request.DisplayContent = null;
            }
            if (cmdletContext.PortalProductId != null)
            {
                request.PortalProductId = cmdletContext.PortalProductId;
            }
            if (cmdletContext.ProductRestEndpointPageId != null)
            {
                request.ProductRestEndpointPageId = cmdletContext.ProductRestEndpointPageId;
            }
            if (cmdletContext.TryItState != null)
            {
                request.TryItState = cmdletContext.TryItState;
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
        
        private Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "UpdateProductRestEndpointPage");
            try
            {
                return client.UpdateProductRestEndpointPageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.ApiGatewayV2.Model.None DisplayContent_None { get; set; }
            public System.String Overrides_Body { get; set; }
            public System.String Overrides_Endpoint { get; set; }
            public System.String Overrides_OperationName { get; set; }
            public System.String PortalProductId { get; set; }
            public System.String ProductRestEndpointPageId { get; set; }
            public Amazon.ApiGatewayV2.TryItState TryItState { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.UpdateProductRestEndpointPageResponse, UpdateAG2ProductRestEndpointPageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
