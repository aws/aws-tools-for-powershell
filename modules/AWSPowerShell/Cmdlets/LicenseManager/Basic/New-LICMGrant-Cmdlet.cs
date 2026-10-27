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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Creates a grant for the specified license. A grant shares the use of license entitlements
    /// with a specific Amazon Web Services account, an organization, or an organizational
    /// unit (OU). For more information, see <a href="https://docs.aws.amazon.com/license-manager/latest/userguide/granted-licenses.html">Granted
    /// licenses in License Manager</a> in the <i>License Manager User Guide</i>.
    /// 
    ///  
    /// <para>
    /// Set the type of grant with the <c>GrantType</c> field:
    /// </para><ul><li><para><c>BuyerGrant</c> - The default grant type, created by the seller when a customer
    /// subscribes to a product. The seller creates a license for the subscription and a buyer
    /// grant for the customer. With a buyer grant, the customer can use, consume, and distribute
    /// the license, according to the permissions the seller sets in the product contract.
    /// </para></li><li><para><c>DelegateGrant</c> - A delegate grant gives the grantee read-only visibility into
    /// the licenses and grants that you have distributed to buyers for a product. The grantee
    /// can monitor that activity on your behalf, and can also listen for the related Amazon
    /// EventBridge events. A delegate grant conveys no entitlement to use the licenses, and
    /// its only allowed operation is <c>ListReceivedLicenses</c>. You must create the delegate
    /// grant, and its license, from the same Amazon Web Services account that you used to
    /// create those buyer licenses and grants.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "LICMGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManager.Model.CreateGrantResponse")]
    [AWSCmdlet("Calls the AWS License Manager CreateGrant API operation.", Operation = new[] {"CreateGrant"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CreateGrantResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.CreateGrantResponse",
        "This cmdlet returns an Amazon.LicenseManager.Model.CreateGrantResponse object containing multiple properties."
    )]
    public partial class NewLICMGrantCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Options_ActivationOverrideBehavior
        /// <summary>
        /// <para>
        /// <para>An activation option for your grant that determines the behavior of activating a grant.
        /// Activation options can only be used with granted licenses sourced from the Amazon
        /// Web Services Marketplace. Additionally, the operation must activate the grant. For
        /// the <c>CreateGrantVersion</c> operation, specify <c>ACTIVE</c> for the <c>Status</c>
        /// parameter. For the <c>CreateGrant</c> operation, specify <c>ACTIVE</c> for the <c>DesiredStatus</c>
        /// option.</para><ul><li><para>As a license administrator, you can optionally specify an <c>ActivationOverrideBehavior</c>
        /// when activating a grant.</para></li><li><para>As a grantor, you can optionally specify an <c>ActivationOverrideBehavior</c> when
        /// you activate a grant for a grantee account in your organization.</para></li><li><para>As a grantee, if the grantor creating the distributed grant doesn’t specify an <c>ActivationOverrideBehavior</c>,
        /// you can optionally specify one when you are activating the grant.</para></li></ul><dl><dt>DISTRIBUTED_GRANTS_ONLY</dt><dd><para>Use this value to activate a grant without replacing any member account’s active grants
        /// for the same product.</para></dd><dt>ALL_GRANTS_PERMITTED_BY_ISSUER</dt><dd><para>Use this value to activate a grant and disable other active grants in any member accounts
        /// for the same product. This action will also replace their previously activated grants
        /// with this activated grant.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LicenseManager.ActivationOverrideBehavior")]
        public Amazon.LicenseManager.ActivationOverrideBehavior Options_ActivationOverrideBehavior { get; set; }
        #endregion
        
        #region Parameter AllowedOperation
        /// <summary>
        /// <para>
        /// <para>Allowed operations for the grant.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("AllowedOperations")]
        public System.String[] AllowedOperation { get; set; }
        #endregion
        
        #region Parameter Options_DesiredStatus
        /// <summary>
        /// <para>
        /// <para>The status of the grant after License Manager creates it. The only supported value
        /// is <c>ACTIVE</c>. Specify <c>ACTIVE</c> to create and activate the grant in one request.</para><para>You can specify this option only for the <c>CreateGrant</c> operation, and only when
        /// the grant principal is an organization or an organizational unit (OU). To change the
        /// status of an existing grant, use the <c>Status</c> parameter of the <c>CreateGrantVersion</c>
        /// operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LicenseManager.GrantStatus")]
        public Amazon.LicenseManager.GrantStatus Options_DesiredStatus { get; set; }
        #endregion
        
        #region Parameter GrantName
        /// <summary>
        /// <para>
        /// <para>Grant name.</para>
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
        public System.String GrantName { get; set; }
        #endregion
        
        #region Parameter GrantType
        /// <summary>
        /// <para>
        /// <para>The type of grant to create. For more information about each type, see the preceding
        /// description of this operation. Valid values:</para><ul><li><para><c>BuyerGrant</c> - The default grant type if you don't specify a value. Conveys
        /// the entitlement to use the license.</para></li><li><para><c>DelegateGrant</c> - Gives the grantee read-only visibility into the licenses and
        /// grants that you have distributed to buyers, with no entitlement to use them.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LicenseManager.GrantType")]
        public Amazon.LicenseManager.GrantType GrantType { get; set; }
        #endregion
        
        #region Parameter HomeRegion
        /// <summary>
        /// <para>
        /// <para>Home Region of the grant.</para>
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
        public System.String HomeRegion { get; set; }
        #endregion
        
        #region Parameter LicenseArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the license.</para>
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
        public System.String LicenseArn { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The grant principals. You can specify one of the following as an Amazon Resource Name
        /// (ARN):</para><ul><li><para>An Amazon Web Services account, which includes only the account specified.</para></li></ul><ul><li><para>An organizational unit (OU), which includes all accounts in the OU.</para></li></ul><ul><li><para>An organization, which will include all accounts across your organization.</para></li></ul><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Principals")]
        public System.String[] Principal { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to add to the grant. For more information about tagging support in License Manager,
        /// see the <a href="https://docs.aws.amazon.com/license-manager/latest/APIReference/API_TagResource.html">TagResource</a>
        /// operation.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LicenseManager.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request.</para>
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
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CreateGrantResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CreateGrantResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LicenseArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMGrant (CreateGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CreateGrantResponse, NewLICMGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AllowedOperation != null)
            {
                context.AllowedOperation = new List<System.String>(this.AllowedOperation);
            }
            #if MODULAR
            if (this.AllowedOperation == null && ParameterWasBound(nameof(this.AllowedOperation)))
            {
                WriteWarning("You are passing $null as a value for parameter AllowedOperation which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GrantName = this.GrantName;
            #if MODULAR
            if (this.GrantName == null && ParameterWasBound(nameof(this.GrantName)))
            {
                WriteWarning("You are passing $null as a value for parameter GrantName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GrantType = this.GrantType;
            context.HomeRegion = this.HomeRegion;
            #if MODULAR
            if (this.HomeRegion == null && ParameterWasBound(nameof(this.HomeRegion)))
            {
                WriteWarning("You are passing $null as a value for parameter HomeRegion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LicenseArn = this.LicenseArn;
            #if MODULAR
            if (this.LicenseArn == null && ParameterWasBound(nameof(this.LicenseArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Options_ActivationOverrideBehavior = this.Options_ActivationOverrideBehavior;
            context.Options_DesiredStatus = this.Options_DesiredStatus;
            if (this.Principal != null)
            {
                context.Principal = new List<System.String>(this.Principal);
            }
            #if MODULAR
            if (this.Principal == null && ParameterWasBound(nameof(this.Principal)))
            {
                WriteWarning("You are passing $null as a value for parameter Principal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.LicenseManager.Model.Tag>(this.Tag);
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
            var request = new Amazon.LicenseManager.Model.CreateGrantRequest();
            
            if (cmdletContext.AllowedOperation != null)
            {
                request.AllowedOperations = cmdletContext.AllowedOperation;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GrantName != null)
            {
                request.GrantName = cmdletContext.GrantName;
            }
            if (cmdletContext.GrantType != null)
            {
                request.GrantType = cmdletContext.GrantType;
            }
            if (cmdletContext.HomeRegion != null)
            {
                request.HomeRegion = cmdletContext.HomeRegion;
            }
            if (cmdletContext.LicenseArn != null)
            {
                request.LicenseArn = cmdletContext.LicenseArn;
            }
            
             // populate Options
            var requestOptionsIsNull = true;
            request.Options = new Amazon.LicenseManager.Model.Options();
            Amazon.LicenseManager.ActivationOverrideBehavior requestOptions_options_ActivationOverrideBehavior = null;
            if (cmdletContext.Options_ActivationOverrideBehavior != null)
            {
                requestOptions_options_ActivationOverrideBehavior = cmdletContext.Options_ActivationOverrideBehavior;
            }
            if (requestOptions_options_ActivationOverrideBehavior != null)
            {
                request.Options.ActivationOverrideBehavior = requestOptions_options_ActivationOverrideBehavior;
                requestOptionsIsNull = false;
            }
            Amazon.LicenseManager.GrantStatus requestOptions_options_DesiredStatus = null;
            if (cmdletContext.Options_DesiredStatus != null)
            {
                requestOptions_options_DesiredStatus = cmdletContext.Options_DesiredStatus;
            }
            if (requestOptions_options_DesiredStatus != null)
            {
                request.Options.DesiredStatus = requestOptions_options_DesiredStatus;
                requestOptionsIsNull = false;
            }
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.Principal != null)
            {
                request.Principals = cmdletContext.Principal;
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
        
        private Amazon.LicenseManager.Model.CreateGrantResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateGrant");
            try
            {
                return client.CreateGrantAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> AllowedOperation { get; set; }
            public System.String ClientToken { get; set; }
            public System.String GrantName { get; set; }
            public Amazon.LicenseManager.GrantType GrantType { get; set; }
            public System.String HomeRegion { get; set; }
            public System.String LicenseArn { get; set; }
            public Amazon.LicenseManager.ActivationOverrideBehavior Options_ActivationOverrideBehavior { get; set; }
            public Amazon.LicenseManager.GrantStatus Options_DesiredStatus { get; set; }
            public List<System.String> Principal { get; set; }
            public List<Amazon.LicenseManager.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CreateGrantResponse, NewLICMGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
