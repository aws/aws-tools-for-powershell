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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates an existing DLP setting configuration in an Amazon Web Services account. Fields
    /// that are omitted from the request retain their current values.
    /// </summary>
    [Cmdlet("Update", "QSDlpSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateDlpSettingResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateDlpSetting API operation.", Operation = new[] {"UpdateDlpSetting"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateDlpSettingResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateDlpSettingResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateDlpSettingResponse object containing multiple properties."
    )]
    public partial class UpdateQSDlpSettingCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account that contains the DLP setting that you want
        /// to update.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter DlpSettingId
        /// <summary>
        /// <para>
        /// <para>The ID of the DLP setting that you want to update.</para>
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
        public System.String DlpSettingId { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether DLP enforcement is active for this setting. Set to <c>true</c> to
        /// enable enforcement, or <c>false</c> to disable it.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter ProviderConfig_MicrosoftPurview_LabelActionMapping
        /// <summary>
        /// <para>
        /// <para>The mappings from Microsoft Purview sensitivity labels to enforcement actions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ProviderConfig_MicrosoftPurview_LabelActionMappings")]
        public Amazon.QuickSight.Model.LabelActionMapping[] ProviderConfig_MicrosoftPurview_LabelActionMapping { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>An updated display name for the DLP setting.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ProviderOutageAction
        /// <summary>
        /// <para>
        /// <para>An updated behavior to apply when the DLP provider is unreachable. Valid values are
        /// <c>ALLOW</c>, <c>WARN</c>, and <c>BLOCK</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.DlpAction")]
        public Amazon.QuickSight.DlpAction ProviderOutageAction { get; set; }
        #endregion
        
        #region Parameter ProviderType
        /// <summary>
        /// <para>
        /// <para>An updated DLP provider type. Currently, the only supported value is <c>MICROSOFT_PURVIEW</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.DlpProviderType")]
        public Amazon.QuickSight.DlpProviderType ProviderType { get; set; }
        #endregion
        
        #region Parameter ProviderConfig_MicrosoftPurview_Credentials_SecretArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon Web Services Secrets Manager secret that contains the Microsoft
        /// Purview OAuth credentials. The secret includes the Azure tenant ID, client ID, and
        /// client secret or certificate.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ProviderConfig_MicrosoftPurview_Credentials_SecretArn { get; set; }
        #endregion
        
        #region Parameter ProviderConfig_MicrosoftPurview_UnmappedAction
        /// <summary>
        /// <para>
        /// <para>The default action to apply to content that has no sensitivity label or whose label
        /// is not mapped. Valid values are <c>ALLOW</c>, <c>BLOCK</c>, and <c>WARN</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.QuickSight.DlpAction")]
        public Amazon.QuickSight.DlpAction ProviderConfig_MicrosoftPurview_UnmappedAction { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateDlpSettingResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateDlpSettingResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DlpSettingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSDlpSetting (UpdateDlpSetting)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateDlpSettingResponse, UpdateQSDlpSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DlpSettingId = this.DlpSettingId;
            #if MODULAR
            if (this.DlpSettingId == null && ParameterWasBound(nameof(this.DlpSettingId)))
            {
                WriteWarning("You are passing $null as a value for parameter DlpSettingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Enabled = this.Enabled;
            context.Name = this.Name;
            context.ProviderConfig_MicrosoftPurview_Credentials_SecretArn = this.ProviderConfig_MicrosoftPurview_Credentials_SecretArn;
            if (this.ProviderConfig_MicrosoftPurview_LabelActionMapping != null)
            {
                context.ProviderConfig_MicrosoftPurview_LabelActionMapping = new List<Amazon.QuickSight.Model.LabelActionMapping>(this.ProviderConfig_MicrosoftPurview_LabelActionMapping);
            }
            context.ProviderConfig_MicrosoftPurview_UnmappedAction = this.ProviderConfig_MicrosoftPurview_UnmappedAction;
            context.ProviderOutageAction = this.ProviderOutageAction;
            context.ProviderType = this.ProviderType;
            
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
            var request = new Amazon.QuickSight.Model.UpdateDlpSettingRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.DlpSettingId != null)
            {
                request.DlpSettingId = cmdletContext.DlpSettingId;
            }
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate ProviderConfig
            var requestProviderConfigIsNull = true;
            request.ProviderConfig = new Amazon.QuickSight.Model.ProviderConfig();
            Amazon.QuickSight.Model.MicrosoftPurviewProviderConfig requestProviderConfig_providerConfig_MicrosoftPurview = null;
            
             // populate MicrosoftPurview
            var requestProviderConfig_providerConfig_MicrosoftPurviewIsNull = true;
            requestProviderConfig_providerConfig_MicrosoftPurview = new Amazon.QuickSight.Model.MicrosoftPurviewProviderConfig();
            List<Amazon.QuickSight.Model.LabelActionMapping> requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_LabelActionMapping = null;
            if (cmdletContext.ProviderConfig_MicrosoftPurview_LabelActionMapping != null)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_LabelActionMapping = cmdletContext.ProviderConfig_MicrosoftPurview_LabelActionMapping;
            }
            if (requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_LabelActionMapping != null)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview.LabelActionMappings = requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_LabelActionMapping;
                requestProviderConfig_providerConfig_MicrosoftPurviewIsNull = false;
            }
            Amazon.QuickSight.DlpAction requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_UnmappedAction = null;
            if (cmdletContext.ProviderConfig_MicrosoftPurview_UnmappedAction != null)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_UnmappedAction = cmdletContext.ProviderConfig_MicrosoftPurview_UnmappedAction;
            }
            if (requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_UnmappedAction != null)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview.UnmappedAction = requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_UnmappedAction;
                requestProviderConfig_providerConfig_MicrosoftPurviewIsNull = false;
            }
            Amazon.QuickSight.Model.MicrosoftPurviewCredentials requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials = null;
            
             // populate Credentials
            var requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_CredentialsIsNull = true;
            requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials = new Amazon.QuickSight.Model.MicrosoftPurviewCredentials();
            System.String requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials_providerConfig_MicrosoftPurview_Credentials_SecretArn = null;
            if (cmdletContext.ProviderConfig_MicrosoftPurview_Credentials_SecretArn != null)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials_providerConfig_MicrosoftPurview_Credentials_SecretArn = cmdletContext.ProviderConfig_MicrosoftPurview_Credentials_SecretArn;
            }
            if (requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials_providerConfig_MicrosoftPurview_Credentials_SecretArn != null)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials.SecretArn = requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials_providerConfig_MicrosoftPurview_Credentials_SecretArn;
                requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_CredentialsIsNull = false;
            }
             // determine if requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials should be set to null
            if (requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_CredentialsIsNull)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials = null;
            }
            if (requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials != null)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview.Credentials = requestProviderConfig_providerConfig_MicrosoftPurview_providerConfig_MicrosoftPurview_Credentials;
                requestProviderConfig_providerConfig_MicrosoftPurviewIsNull = false;
            }
             // determine if requestProviderConfig_providerConfig_MicrosoftPurview should be set to null
            if (requestProviderConfig_providerConfig_MicrosoftPurviewIsNull)
            {
                requestProviderConfig_providerConfig_MicrosoftPurview = null;
            }
            if (requestProviderConfig_providerConfig_MicrosoftPurview != null)
            {
                request.ProviderConfig.MicrosoftPurview = requestProviderConfig_providerConfig_MicrosoftPurview;
                requestProviderConfigIsNull = false;
            }
             // determine if request.ProviderConfig should be set to null
            if (requestProviderConfigIsNull)
            {
                request.ProviderConfig = null;
            }
            if (cmdletContext.ProviderOutageAction != null)
            {
                request.ProviderOutageAction = cmdletContext.ProviderOutageAction;
            }
            if (cmdletContext.ProviderType != null)
            {
                request.ProviderType = cmdletContext.ProviderType;
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
        
        private Amazon.QuickSight.Model.UpdateDlpSettingResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateDlpSettingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateDlpSetting");
            try
            {
                return client.UpdateDlpSettingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String DlpSettingId { get; set; }
            public System.Boolean? Enabled { get; set; }
            public System.String Name { get; set; }
            public System.String ProviderConfig_MicrosoftPurview_Credentials_SecretArn { get; set; }
            public List<Amazon.QuickSight.Model.LabelActionMapping> ProviderConfig_MicrosoftPurview_LabelActionMapping { get; set; }
            public Amazon.QuickSight.DlpAction ProviderConfig_MicrosoftPurview_UnmappedAction { get; set; }
            public Amazon.QuickSight.DlpAction ProviderOutageAction { get; set; }
            public Amazon.QuickSight.DlpProviderType ProviderType { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateDlpSettingResponse, UpdateQSDlpSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
