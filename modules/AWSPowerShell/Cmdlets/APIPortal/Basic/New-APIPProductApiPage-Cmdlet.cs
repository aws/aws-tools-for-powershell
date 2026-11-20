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
    /// Creates an API page that documents a Managed API in a product. The page content is
    /// generated asynchronously. Use `status` to track it.
    /// </summary>
    [Cmdlet("New", "APIPProductApiPage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.APIPortal.Model.CreateProductApiPageResponse")]
    [AWSCmdlet("Calls the APIPortal CreateProductApiPage API operation.", Operation = new[] {"CreateProductApiPage"}, SelectReturnType = typeof(Amazon.APIPortal.Model.CreateProductApiPageResponse))]
    [AWSCmdletOutput("Amazon.APIPortal.Model.CreateProductApiPageResponse",
        "This cmdlet returns an Amazon.APIPortal.Model.CreateProductApiPageResponse object containing multiple properties."
    )]
    public partial class NewAPIPProductApiPageCmdlet : AmazonAPIPortalClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DisplayContent_Overrides_ApiUrl
        /// <summary>
        /// <para>
        /// The invoke URL shown on the page and used for Try-It
        /// and the portal's allowed-domain list: http(s)://host[:port][/path], with no whitespace,
        /// quotes or angle brackets. On this request member only, as ApiEndpoint is also returned
        /// in responses.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayContent_Overrides_ApiUrl { get; set; }
        #endregion
        
        #region Parameter DisplayContent_Overrides_Body
        /// <summary>
        /// <para>
        /// The Markdown body of the page, from 1 to 32,768 characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayContent_Overrides_Body { get; set; }
        #endregion
        
        #region Parameter ManagedApiId
        /// <summary>
        /// <para>
        /// The Managed API this page documents. It must
        /// already be associated with the product, and the page's API identifier is taken from
        /// the Managed API rather than supplied by the caller.
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
        public System.String ManagedApiId { get; set; }
        #endregion
        
        #region Parameter DisplayContent_None
        /// <summary>
        /// <para>
        /// Use the content generated from the Managed API.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.APIPortal.Model.None DisplayContent_None { get; set; }
        #endregion
        
        #region Parameter DisplayContent_Overrides_OperationName
        /// <summary>
        /// <para>
        /// The operation name shown as the page title,
        /// from 1 to 255 characters.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayContent_Overrides_OperationName { get; set; }
        #endregion
        
        #region Parameter ProductId
        /// <summary>
        /// <para>
        /// The identifier of the product.
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
        
        #region Parameter TryItState
        /// <summary>
        /// <para>
        /// Whether readers can call the API from the page
        /// with Try-It. Defaults to `DISABLED`. To enable it, the page's API URL must use HTTPS
        /// on a domain that supports Try-It.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.APIPortal.TryItState")]
        public Amazon.APIPortal.TryItState TryItState { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIPortal.Model.CreateProductApiPageResponse).
        /// Specifying the name of a property of type Amazon.APIPortal.Model.CreateProductApiPageResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ManagedApiId),
                nameof(this.ProductId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-APIPProductApiPage (CreateProductApiPage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIPortal.Model.CreateProductApiPageResponse, NewAPIPProductApiPageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DisplayContent_None = this.DisplayContent_None;
            context.DisplayContent_Overrides_ApiUrl = this.DisplayContent_Overrides_ApiUrl;
            context.DisplayContent_Overrides_Body = this.DisplayContent_Overrides_Body;
            context.DisplayContent_Overrides_OperationName = this.DisplayContent_Overrides_OperationName;
            context.ManagedApiId = this.ManagedApiId;
            #if MODULAR
            if (this.ManagedApiId == null && ParameterWasBound(nameof(this.ManagedApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ManagedApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.APIPortal.Model.CreateProductApiPageRequest();
            
            
             // populate DisplayContent
            var requestDisplayContentIsNull = true;
            request.DisplayContent = new Amazon.APIPortal.Model.ApiPageDisplayContent();
            Amazon.APIPortal.Model.None requestDisplayContent_displayContent_None = null;
            if (cmdletContext.DisplayContent_None != null)
            {
                requestDisplayContent_displayContent_None = cmdletContext.DisplayContent_None;
            }
            if (requestDisplayContent_displayContent_None != null)
            {
                request.DisplayContent.None = requestDisplayContent_displayContent_None;
                requestDisplayContentIsNull = false;
            }
            Amazon.APIPortal.Model.DisplayContentOverrides requestDisplayContent_displayContent_Overrides = null;
            
             // populate Overrides
            var requestDisplayContent_displayContent_OverridesIsNull = true;
            requestDisplayContent_displayContent_Overrides = new Amazon.APIPortal.Model.DisplayContentOverrides();
            System.String requestDisplayContent_displayContent_Overrides_displayContent_Overrides_ApiUrl = null;
            if (cmdletContext.DisplayContent_Overrides_ApiUrl != null)
            {
                requestDisplayContent_displayContent_Overrides_displayContent_Overrides_ApiUrl = cmdletContext.DisplayContent_Overrides_ApiUrl;
            }
            if (requestDisplayContent_displayContent_Overrides_displayContent_Overrides_ApiUrl != null)
            {
                requestDisplayContent_displayContent_Overrides.ApiUrl = requestDisplayContent_displayContent_Overrides_displayContent_Overrides_ApiUrl;
                requestDisplayContent_displayContent_OverridesIsNull = false;
            }
            System.String requestDisplayContent_displayContent_Overrides_displayContent_Overrides_Body = null;
            if (cmdletContext.DisplayContent_Overrides_Body != null)
            {
                requestDisplayContent_displayContent_Overrides_displayContent_Overrides_Body = cmdletContext.DisplayContent_Overrides_Body;
            }
            if (requestDisplayContent_displayContent_Overrides_displayContent_Overrides_Body != null)
            {
                requestDisplayContent_displayContent_Overrides.Body = requestDisplayContent_displayContent_Overrides_displayContent_Overrides_Body;
                requestDisplayContent_displayContent_OverridesIsNull = false;
            }
            System.String requestDisplayContent_displayContent_Overrides_displayContent_Overrides_OperationName = null;
            if (cmdletContext.DisplayContent_Overrides_OperationName != null)
            {
                requestDisplayContent_displayContent_Overrides_displayContent_Overrides_OperationName = cmdletContext.DisplayContent_Overrides_OperationName;
            }
            if (requestDisplayContent_displayContent_Overrides_displayContent_Overrides_OperationName != null)
            {
                requestDisplayContent_displayContent_Overrides.OperationName = requestDisplayContent_displayContent_Overrides_displayContent_Overrides_OperationName;
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
            if (cmdletContext.ManagedApiId != null)
            {
                request.ManagedApiId = cmdletContext.ManagedApiId;
            }
            if (cmdletContext.ProductId != null)
            {
                request.ProductId = cmdletContext.ProductId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.APIPortal.Model.CreateProductApiPageResponse CallAWSServiceOperation(IAmazonAPIPortal client, Amazon.APIPortal.Model.CreateProductApiPageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "APIPortal", "CreateProductApiPage");
            try
            {
                return client.CreateProductApiPageAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.APIPortal.Model.None DisplayContent_None { get; set; }
            public System.String DisplayContent_Overrides_ApiUrl { get; set; }
            public System.String DisplayContent_Overrides_Body { get; set; }
            public System.String DisplayContent_Overrides_OperationName { get; set; }
            public System.String ManagedApiId { get; set; }
            public System.String ProductId { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public Amazon.APIPortal.TryItState TryItState { get; set; }
            public System.Func<Amazon.APIPortal.Model.CreateProductApiPageResponse, NewAPIPProductApiPageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
