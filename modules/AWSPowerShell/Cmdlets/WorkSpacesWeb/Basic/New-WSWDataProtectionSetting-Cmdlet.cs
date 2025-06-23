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
using Amazon.WorkSpacesWeb;
using Amazon.WorkSpacesWeb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.WSW
{
    /// <summary>
    /// Creates a data protection settings resource that can be associated with a web portal.
    /// </summary>
    [Cmdlet("New", "WSWDataProtectionSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon WorkSpaces Web CreateDataProtectionSettings API operation.", Operation = new[] {"CreateDataProtectionSettings"}, SelectReturnType = typeof(Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsResponse))]
    [AWSCmdletOutput("System.String or Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewWSWDataProtectionSettingCmdlet : AmazonWorkSpacesWebClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AdditionalEncryptionContext
        /// <summary>
        /// <para>
        /// <para>Additional encryption context of the data protection settings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable AdditionalEncryptionContext { get; set; }
        #endregion
        
        #region Parameter CustomerManagedKey
        /// <summary>
        /// <para>
        /// <para>The custom managed key of the data protection settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String CustomerManagedKey { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the data protection settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The display name of the data protection settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter InlineRedactionConfiguration_GlobalConfidenceLevel
        /// <summary>
        /// <para>
        /// <para>The global confidence level for the inline redaction configuration. This indicates
        /// the certainty of data type matches in the redaction process. Confidence level 3 means
        /// high confidence, and requires a formatted text pattern match in order for content
        /// to be redacted. Confidence level 2 means medium confidence, and redaction considers
        /// both formatted and unformatted text, and adds keyword associate to the logic. Confidence
        /// level 1 means low confidence, and redaction is enforced for both formatted pattern
        /// + unformatted pattern without keyword. This is applied to patterns that do not have
        /// a pattern-level confidence level. Defaults to confidence level 2.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InlineRedactionConfiguration_GlobalConfidenceLevel { get; set; }
        #endregion
        
        #region Parameter InlineRedactionConfiguration_GlobalEnforcedUrl
        /// <summary>
        /// <para>
        /// <para>The global enforced URL configuration for the inline redaction configuration. This
        /// is applied to patterns that do not have a pattern-level enforced URL list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InlineRedactionConfiguration_GlobalEnforcedUrls")]
        public System.String[] InlineRedactionConfiguration_GlobalEnforcedUrl { get; set; }
        #endregion
        
        #region Parameter InlineRedactionConfiguration_GlobalExemptUrl
        /// <summary>
        /// <para>
        /// <para>The global exempt URL configuration for the inline redaction configuration. This is
        /// applied to patterns that do not have a pattern-level exempt URL list.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InlineRedactionConfiguration_GlobalExemptUrls")]
        public System.String[] InlineRedactionConfiguration_GlobalExemptUrl { get; set; }
        #endregion
        
        #region Parameter InlineRedactionConfiguration_InlineRedactionPattern
        /// <summary>
        /// <para>
        /// <para>The inline redaction patterns to be enabled for the inline redaction configuration.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InlineRedactionConfiguration_InlineRedactionPatterns")]
        public Amazon.WorkSpacesWeb.Model.InlineRedactionPattern[] InlineRedactionConfiguration_InlineRedactionPattern { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to add to the data protection settings resource. A tag is a key-value pair.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WorkSpacesWeb.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. Idempotency ensures that an API request completes only once. With an
        /// idempotent request, if the original request completes successfully, subsequent retries
        /// with the same client token returns the result from the original successful request.
        /// </para><para>If you do not specify a client token, one is automatically generated by the Amazon
        /// Web Services SDK.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataProtectionSettingsArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsResponse).
        /// Specifying the name of a property of type Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataProtectionSettingsArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WSWDataProtectionSetting (CreateDataProtectionSettings)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsResponse, NewWSWDataProtectionSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AdditionalEncryptionContext != null)
            {
                context.AdditionalEncryptionContext = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.AdditionalEncryptionContext.Keys)
                {
                    context.AdditionalEncryptionContext.Add((String)hashKey, (System.String)(this.AdditionalEncryptionContext[hashKey]));
                }
            }
            context.ClientToken = this.ClientToken;
            context.CustomerManagedKey = this.CustomerManagedKey;
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.InlineRedactionConfiguration_GlobalConfidenceLevel = this.InlineRedactionConfiguration_GlobalConfidenceLevel;
            if (this.InlineRedactionConfiguration_GlobalEnforcedUrl != null)
            {
                context.InlineRedactionConfiguration_GlobalEnforcedUrl = new List<System.String>(this.InlineRedactionConfiguration_GlobalEnforcedUrl);
            }
            if (this.InlineRedactionConfiguration_GlobalExemptUrl != null)
            {
                context.InlineRedactionConfiguration_GlobalExemptUrl = new List<System.String>(this.InlineRedactionConfiguration_GlobalExemptUrl);
            }
            if (this.InlineRedactionConfiguration_InlineRedactionPattern != null)
            {
                context.InlineRedactionConfiguration_InlineRedactionPattern = new List<Amazon.WorkSpacesWeb.Model.InlineRedactionPattern>(this.InlineRedactionConfiguration_InlineRedactionPattern);
            }
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WorkSpacesWeb.Model.Tag>(this.Tag);
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
            var request = new Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsRequest();
            
            if (cmdletContext.AdditionalEncryptionContext != null)
            {
                request.AdditionalEncryptionContext = cmdletContext.AdditionalEncryptionContext;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.CustomerManagedKey != null)
            {
                request.CustomerManagedKey = cmdletContext.CustomerManagedKey;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate InlineRedactionConfiguration
            var requestInlineRedactionConfigurationIsNull = true;
            request.InlineRedactionConfiguration = new Amazon.WorkSpacesWeb.Model.InlineRedactionConfiguration();
            System.Int32? requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalConfidenceLevel = null;
            if (cmdletContext.InlineRedactionConfiguration_GlobalConfidenceLevel != null)
            {
                requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalConfidenceLevel = cmdletContext.InlineRedactionConfiguration_GlobalConfidenceLevel.Value;
            }
            if (requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalConfidenceLevel != null)
            {
                request.InlineRedactionConfiguration.GlobalConfidenceLevel = requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalConfidenceLevel.Value;
                requestInlineRedactionConfigurationIsNull = false;
            }
            List<System.String> requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalEnforcedUrl = null;
            if (cmdletContext.InlineRedactionConfiguration_GlobalEnforcedUrl != null)
            {
                requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalEnforcedUrl = cmdletContext.InlineRedactionConfiguration_GlobalEnforcedUrl;
            }
            if (requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalEnforcedUrl != null)
            {
                request.InlineRedactionConfiguration.GlobalEnforcedUrls = requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalEnforcedUrl;
                requestInlineRedactionConfigurationIsNull = false;
            }
            List<System.String> requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalExemptUrl = null;
            if (cmdletContext.InlineRedactionConfiguration_GlobalExemptUrl != null)
            {
                requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalExemptUrl = cmdletContext.InlineRedactionConfiguration_GlobalExemptUrl;
            }
            if (requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalExemptUrl != null)
            {
                request.InlineRedactionConfiguration.GlobalExemptUrls = requestInlineRedactionConfiguration_inlineRedactionConfiguration_GlobalExemptUrl;
                requestInlineRedactionConfigurationIsNull = false;
            }
            List<Amazon.WorkSpacesWeb.Model.InlineRedactionPattern> requestInlineRedactionConfiguration_inlineRedactionConfiguration_InlineRedactionPattern = null;
            if (cmdletContext.InlineRedactionConfiguration_InlineRedactionPattern != null)
            {
                requestInlineRedactionConfiguration_inlineRedactionConfiguration_InlineRedactionPattern = cmdletContext.InlineRedactionConfiguration_InlineRedactionPattern;
            }
            if (requestInlineRedactionConfiguration_inlineRedactionConfiguration_InlineRedactionPattern != null)
            {
                request.InlineRedactionConfiguration.InlineRedactionPatterns = requestInlineRedactionConfiguration_inlineRedactionConfiguration_InlineRedactionPattern;
                requestInlineRedactionConfigurationIsNull = false;
            }
             // determine if request.InlineRedactionConfiguration should be set to null
            if (requestInlineRedactionConfigurationIsNull)
            {
                request.InlineRedactionConfiguration = null;
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
        
        private Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsResponse CallAWSServiceOperation(IAmazonWorkSpacesWeb client, Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces Web", "CreateDataProtectionSettings");
            try
            {
                return client.CreateDataProtectionSettingsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> AdditionalEncryptionContext { get; set; }
            public System.String ClientToken { get; set; }
            public System.String CustomerManagedKey { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.Int32? InlineRedactionConfiguration_GlobalConfidenceLevel { get; set; }
            public List<System.String> InlineRedactionConfiguration_GlobalEnforcedUrl { get; set; }
            public List<System.String> InlineRedactionConfiguration_GlobalExemptUrl { get; set; }
            public List<Amazon.WorkSpacesWeb.Model.InlineRedactionPattern> InlineRedactionConfiguration_InlineRedactionPattern { get; set; }
            public List<Amazon.WorkSpacesWeb.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.WorkSpacesWeb.Model.CreateDataProtectionSettingsResponse, NewWSWDataProtectionSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataProtectionSettingsArn;
        }
        
    }
}
