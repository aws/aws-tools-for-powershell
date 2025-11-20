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
using Amazon.ApiGatewayV2;
using Amazon.ApiGatewayV2.Model;

namespace Amazon.PowerShell.Cmdlets.AG2
{
    /// <summary>
    /// Creates a product REST endpoint page for a portal product.
    /// </summary>
    [Cmdlet("New", "AG2ProductRestEndpointPage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway V2 CreateProductRestEndpointPage API operation.", Operation = new[] {"CreateProductRestEndpointPage"}, SelectReturnType = typeof(Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse))]
    [AWSCmdletOutput("Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse",
        "This cmdlet returns an Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse object containing multiple properties."
    )]
    public partial class NewAG2ProductRestEndpointPageCmdlet : AmazonApiGatewayV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        
        #region Parameter IdentifierParts_Method
        /// <summary>
        /// <para>
        /// <para>The method of the product REST endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestEndpointIdentifier_IdentifierParts_Method")]
        public System.String IdentifierParts_Method { get; set; }
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
        
        #region Parameter IdentifierParts_Path
        /// <summary>
        /// <para>
        /// <para>The path of the product REST endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestEndpointIdentifier_IdentifierParts_Path")]
        public System.String IdentifierParts_Path { get; set; }
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
        
        #region Parameter IdentifierParts_RestApiId
        /// <summary>
        /// <para>
        /// <para>The REST API ID of the product REST endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestEndpointIdentifier_IdentifierParts_RestApiId")]
        public System.String IdentifierParts_RestApiId { get; set; }
        #endregion
        
        #region Parameter IdentifierParts_Stage
        /// <summary>
        /// <para>
        /// <para>The stage of the product REST endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RestEndpointIdentifier_IdentifierParts_Stage")]
        public System.String IdentifierParts_Stage { get; set; }
        #endregion
        
        #region Parameter TryItState
        /// <summary>
        /// <para>
        /// <para>The try it state of the product REST endpoint page.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ApiGatewayV2.TryItState")]
        public Amazon.ApiGatewayV2.TryItState TryItState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse).
        /// Specifying the name of a property of type Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the PortalProductId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^PortalProductId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^PortalProductId' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PortalProductId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-AG2ProductRestEndpointPage (CreateProductRestEndpointPage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse, NewAG2ProductRestEndpointPageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.PortalProductId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            context.IdentifierParts_Method = this.IdentifierParts_Method;
            context.IdentifierParts_Path = this.IdentifierParts_Path;
            context.IdentifierParts_RestApiId = this.IdentifierParts_RestApiId;
            context.IdentifierParts_Stage = this.IdentifierParts_Stage;
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
            var request = new Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageRequest();
            
            
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
            
             // populate RestEndpointIdentifier
            var requestRestEndpointIdentifierIsNull = true;
            request.RestEndpointIdentifier = new Amazon.ApiGatewayV2.Model.RestEndpointIdentifier();
            Amazon.ApiGatewayV2.Model.IdentifierParts requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts = null;
            
             // populate IdentifierParts
            var requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierPartsIsNull = true;
            requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts = new Amazon.ApiGatewayV2.Model.IdentifierParts();
            System.String requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Method = null;
            if (cmdletContext.IdentifierParts_Method != null)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Method = cmdletContext.IdentifierParts_Method;
            }
            if (requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Method != null)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts.Method = requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Method;
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierPartsIsNull = false;
            }
            System.String requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Path = null;
            if (cmdletContext.IdentifierParts_Path != null)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Path = cmdletContext.IdentifierParts_Path;
            }
            if (requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Path != null)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts.Path = requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Path;
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierPartsIsNull = false;
            }
            System.String requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_RestApiId = null;
            if (cmdletContext.IdentifierParts_RestApiId != null)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_RestApiId = cmdletContext.IdentifierParts_RestApiId;
            }
            if (requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_RestApiId != null)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts.RestApiId = requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_RestApiId;
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierPartsIsNull = false;
            }
            System.String requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Stage = null;
            if (cmdletContext.IdentifierParts_Stage != null)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Stage = cmdletContext.IdentifierParts_Stage;
            }
            if (requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Stage != null)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts.Stage = requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts_identifierParts_Stage;
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierPartsIsNull = false;
            }
             // determine if requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts should be set to null
            if (requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierPartsIsNull)
            {
                requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts = null;
            }
            if (requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts != null)
            {
                request.RestEndpointIdentifier.IdentifierParts = requestRestEndpointIdentifier_restEndpointIdentifier_IdentifierParts;
                requestRestEndpointIdentifierIsNull = false;
            }
             // determine if request.RestEndpointIdentifier should be set to null
            if (requestRestEndpointIdentifierIsNull)
            {
                request.RestEndpointIdentifier = null;
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
        
        private Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse CallAWSServiceOperation(IAmazonApiGatewayV2 client, Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway V2", "CreateProductRestEndpointPage");
            try
            {
                #if DESKTOP
                return client.CreateProductRestEndpointPage(request);
                #elif CORECLR
                return client.CreateProductRestEndpointPageAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
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
            public System.String IdentifierParts_Method { get; set; }
            public System.String IdentifierParts_Path { get; set; }
            public System.String IdentifierParts_RestApiId { get; set; }
            public System.String IdentifierParts_Stage { get; set; }
            public Amazon.ApiGatewayV2.TryItState TryItState { get; set; }
            public System.Func<Amazon.ApiGatewayV2.Model.CreateProductRestEndpointPageResponse, NewAG2ProductRestEndpointPageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
