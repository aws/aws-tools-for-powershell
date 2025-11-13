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
using Amazon.WorkSpacesWeb;
using Amazon.WorkSpacesWeb.Model;

namespace Amazon.PowerShell.Cmdlets.WSW
{
    /// <summary>
    /// Updates browser settings.
    /// </summary>
    [Cmdlet("Update", "WSWBrowserSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpacesWeb.Model.BrowserSettings")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Web UpdateBrowserSettings API operation.", Operation = new[] {"UpdateBrowserSettings"}, SelectReturnType = typeof(Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsResponse))]
    [AWSCmdletOutput("Amazon.WorkSpacesWeb.Model.BrowserSettings or Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsResponse",
        "This cmdlet returns an Amazon.WorkSpacesWeb.Model.BrowserSettings object.",
        "The service call response (type Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateWSWBrowserSettingCmdlet : AmazonWorkSpacesWebClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter WebContentFilteringPolicy_AllowedUrl
        /// <summary>
        /// <para>
        /// <para>URLs and domains that are always accessible to end users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebContentFilteringPolicy_AllowedUrls")]
        public System.String[] WebContentFilteringPolicy_AllowedUrl { get; set; }
        #endregion
        
        #region Parameter WebContentFilteringPolicy_BlockedCategory
        /// <summary>
        /// <para>
        /// <para>Categories of websites that are blocked on the end user’s browsers.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebContentFilteringPolicy_BlockedCategories")]
        public System.String[] WebContentFilteringPolicy_BlockedCategory { get; set; }
        #endregion
        
        #region Parameter WebContentFilteringPolicy_BlockedUrl
        /// <summary>
        /// <para>
        /// <para>URLs and domains that end users cannot access.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WebContentFilteringPolicy_BlockedUrls")]
        public System.String[] WebContentFilteringPolicy_BlockedUrl { get; set; }
        #endregion
        
        #region Parameter BrowserPolicy
        /// <summary>
        /// <para>
        /// <para>A JSON string containing Chrome Enterprise policies that will be applied to all streaming
        /// sessions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BrowserPolicy { get; set; }
        #endregion
        
        #region Parameter BrowserSettingsArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the browser settings.</para>
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
        public System.String BrowserSettingsArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, subsequent retries
        /// with the same client token return the result from the original successful request.
        /// </para><para>If you do not specify a client token, one is automatically generated by the Amazon
        /// Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BrowserSettings'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BrowserSettings";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the BrowserSettingsArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^BrowserSettingsArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^BrowserSettingsArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.BrowserSettingsArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-WSWBrowserSetting (UpdateBrowserSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsResponse, UpdateWSWBrowserSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.BrowserSettingsArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BrowserPolicy = this.BrowserPolicy;
            context.BrowserSettingsArn = this.BrowserSettingsArn;
            #if MODULAR
            if (this.BrowserSettingsArn == null && ParameterWasBound(nameof(this.BrowserSettingsArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BrowserSettingsArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.WebContentFilteringPolicy_AllowedUrl != null)
            {
                context.WebContentFilteringPolicy_AllowedUrl = new List<System.String>(this.WebContentFilteringPolicy_AllowedUrl);
            }
            if (this.WebContentFilteringPolicy_BlockedCategory != null)
            {
                context.WebContentFilteringPolicy_BlockedCategory = new List<System.String>(this.WebContentFilteringPolicy_BlockedCategory);
            }
            if (this.WebContentFilteringPolicy_BlockedUrl != null)
            {
                context.WebContentFilteringPolicy_BlockedUrl = new List<System.String>(this.WebContentFilteringPolicy_BlockedUrl);
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
            var request = new Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsRequest();
            
            if (cmdletContext.BrowserPolicy != null)
            {
                request.BrowserPolicy = cmdletContext.BrowserPolicy;
            }
            if (cmdletContext.BrowserSettingsArn != null)
            {
                request.BrowserSettingsArn = cmdletContext.BrowserSettingsArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate WebContentFilteringPolicy
            var requestWebContentFilteringPolicyIsNull = true;
            request.WebContentFilteringPolicy = new Amazon.WorkSpacesWeb.Model.WebContentFilteringPolicy();
            List<System.String> requestWebContentFilteringPolicy_webContentFilteringPolicy_AllowedUrl = null;
            if (cmdletContext.WebContentFilteringPolicy_AllowedUrl != null)
            {
                requestWebContentFilteringPolicy_webContentFilteringPolicy_AllowedUrl = cmdletContext.WebContentFilteringPolicy_AllowedUrl;
            }
            if (requestWebContentFilteringPolicy_webContentFilteringPolicy_AllowedUrl != null)
            {
                request.WebContentFilteringPolicy.AllowedUrls = requestWebContentFilteringPolicy_webContentFilteringPolicy_AllowedUrl;
                requestWebContentFilteringPolicyIsNull = false;
            }
            List<System.String> requestWebContentFilteringPolicy_webContentFilteringPolicy_BlockedCategory = null;
            if (cmdletContext.WebContentFilteringPolicy_BlockedCategory != null)
            {
                requestWebContentFilteringPolicy_webContentFilteringPolicy_BlockedCategory = cmdletContext.WebContentFilteringPolicy_BlockedCategory;
            }
            if (requestWebContentFilteringPolicy_webContentFilteringPolicy_BlockedCategory != null)
            {
                request.WebContentFilteringPolicy.BlockedCategories = requestWebContentFilteringPolicy_webContentFilteringPolicy_BlockedCategory;
                requestWebContentFilteringPolicyIsNull = false;
            }
            List<System.String> requestWebContentFilteringPolicy_webContentFilteringPolicy_BlockedUrl = null;
            if (cmdletContext.WebContentFilteringPolicy_BlockedUrl != null)
            {
                requestWebContentFilteringPolicy_webContentFilteringPolicy_BlockedUrl = cmdletContext.WebContentFilteringPolicy_BlockedUrl;
            }
            if (requestWebContentFilteringPolicy_webContentFilteringPolicy_BlockedUrl != null)
            {
                request.WebContentFilteringPolicy.BlockedUrls = requestWebContentFilteringPolicy_webContentFilteringPolicy_BlockedUrl;
                requestWebContentFilteringPolicyIsNull = false;
            }
             // determine if request.WebContentFilteringPolicy should be set to null
            if (requestWebContentFilteringPolicyIsNull)
            {
                request.WebContentFilteringPolicy = null;
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
        
        private Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsResponse CallAWSServiceOperation(IAmazonWorkSpacesWeb client, Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Web", "UpdateBrowserSettings");
            try
            {
                #if DESKTOP
                return client.UpdateBrowserSettings(request);
                #elif CORECLR
                return client.UpdateBrowserSettingsAsync(request).GetAwaiter().GetResult();
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
            public System.String BrowserPolicy { get; set; }
            public System.String BrowserSettingsArn { get; set; }
            public System.String ClientToken { get; set; }
            public List<System.String> WebContentFilteringPolicy_AllowedUrl { get; set; }
            public List<System.String> WebContentFilteringPolicy_BlockedCategory { get; set; }
            public List<System.String> WebContentFilteringPolicy_BlockedUrl { get; set; }
            public System.Func<Amazon.WorkSpacesWeb.Model.UpdateBrowserSettingsResponse, UpdateWSWBrowserSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BrowserSettings;
        }
        
    }
}
