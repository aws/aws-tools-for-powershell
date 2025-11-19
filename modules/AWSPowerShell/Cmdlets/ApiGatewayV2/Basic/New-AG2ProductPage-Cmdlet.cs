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
    /// Creates a new product page for a portal product.
    /// </summary>
    [Cmdlet("New", "AG2ProductPage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreateProductPageResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreateProductPage API operation.", Operation = new[] {"CreateProductPage"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.CreateProductPageResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreateProductPageResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.CreateProductPageResponse object containing multiple properties."
    )]
    public partial class NewAG2ProductPageCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DisplayContent_Body
        /// <summary>
        /// <para>
        /// <para>The body.</para>
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
        public System.String DisplayContent_Body { get; set; }
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
        
        #region Parameter DisplayContent_Title
        /// <summary>
        /// <para>
        /// <para>The title.</para>
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
        public System.String DisplayContent_Title { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.CreateProductPageResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.CreateProductPageResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2ProductPage (CreateProductPage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.CreateProductPageResponse, NewAG2ProductPageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DisplayContent_Body = this.DisplayContent_Body;
            #if MODULAR
            if (this.DisplayContent_Body == null && ParameterWasBound(nameof(this.DisplayContent_Body)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayContent_Body which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DisplayContent_Title = this.DisplayContent_Title;
            #if MODULAR
            if (this.DisplayContent_Title == null && ParameterWasBound(nameof(this.DisplayContent_Title)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayContent_Title which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.ApiGatewayV2.Model.CreateProductPageRequest();
            
            
             // populate DisplayContent
            var requestDisplayContentIsNull = true;
            request.DisplayContent = new Amazon.ApiGatewayV2.Model.DisplayContent();
            System.String requestDisplayContent_displayContent_Body = null;
            if (cmdletContext.DisplayContent_Body != null)
            {
                requestDisplayContent_displayContent_Body = cmdletContext.DisplayContent_Body;
            }
            if (requestDisplayContent_displayContent_Body != null)
            {
                request.DisplayContent.Body = requestDisplayContent_displayContent_Body;
                requestDisplayContentIsNull = false;
            }
            System.String requestDisplayContent_displayContent_Title = null;
            if (cmdletContext.DisplayContent_Title != null)
            {
                requestDisplayContent_displayContent_Title = cmdletContext.DisplayContent_Title;
            }
            if (requestDisplayContent_displayContent_Title != null)
            {
                request.DisplayContent.Title = requestDisplayContent_displayContent_Title;
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
        
        private Amazon.ApiGatewayV2.Model.CreateProductPageResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreateProductPageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreateProductPage");
            try
            {
                return client.CreateProductPageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DisplayContent_Body { get; set; }
            public System.String DisplayContent_Title { get; set; }
            public System.String PortalProductId { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.CreateProductPageResponse, NewAG2ProductPageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
