/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Creates a new version of the specified grant. For more information, see <a href="https://docs.aws.amazon.com/license-manager/latest/userguide/granted-licenses.html">Granted
    /// licenses in License Manager</a> in the <i>License Manager User Guide</i>.
    /// </summary>
    [Cmdlet("New", "LICMGrantVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LicenseManager.Model.CreateGrantVersionResponse")]
    [AWSCmdlet("Calls the AWS License Manager CreateGrantVersion API operation.", Operation = new[] {"CreateGrantVersion"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.CreateGrantVersionResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.CreateGrantVersionResponse",
        "This cmdlet returns an Amazon.LicenseManager.Model.CreateGrantVersionResponse object containing multiple properties."
    )]
    public partial class NewLICMGrantVersionCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Options_ActivationOverrideBehavior
        /// <summary>
        /// <para>
        /// <para>An activation option for your grant that determines the behavior of activating a grant.
        /// Activation options can only be used with granted licenses sourced from the Amazon
        /// Web Services Marketplace. Additionally, the operation must specify the value of <c>ACTIVE</c>
        /// for the <c>Status</c> parameter.</para><ul><li><para>As a license administrator, you can optionally specify an <c>ActivationOverrideBehavior</c>
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
        /// <para>Allowed operations for the grant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AllowedOperations")]
        public System.String[] AllowedOperation { get; set; }
        #endregion
        
        #region Parameter GrantArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the grant.</para>
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
        public System.String GrantArn { get; set; }
        #endregion
        
        #region Parameter GrantName
        /// <summary>
        /// <para>
        /// <para>Grant name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String GrantName { get; set; }
        #endregion
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para>Current version of the grant.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceVersion { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>Grant status.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LicenseManager.GrantStatus")]
        public Amazon.LicenseManager.GrantStatus Status { get; set; }
        #endregion
        
        #region Parameter StatusReason
        /// <summary>
        /// <para>
        /// <para>Grant status reason.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StatusReason { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.CreateGrantVersionResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.CreateGrantVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GrantArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GrantArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GrantArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GrantArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LICMGrantVersion (CreateGrantVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.CreateGrantVersionResponse, NewLICMGrantVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GrantArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.AllowedOperation != null)
            {
                context.AllowedOperation = new List<System.String>(this.AllowedOperation);
            }
            context.ClientToken = this.ClientToken;
            #if MODULAR
            if (this.ClientToken == null && ParameterWasBound(nameof(this.ClientToken)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientToken which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GrantArn = this.GrantArn;
            #if MODULAR
            if (this.GrantArn == null && ParameterWasBound(nameof(this.GrantArn)))
            {
                WriteWarning("You are passing $null as a value for parameter GrantArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.GrantName = this.GrantName;
            context.Options_ActivationOverrideBehavior = this.Options_ActivationOverrideBehavior;
            context.SourceVersion = this.SourceVersion;
            context.Status = this.Status;
            context.StatusReason = this.StatusReason;
            
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
            var request = new Amazon.LicenseManager.Model.CreateGrantVersionRequest();
            
            if (cmdletContext.AllowedOperation != null)
            {
                request.AllowedOperations = cmdletContext.AllowedOperation;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.GrantArn != null)
            {
                request.GrantArn = cmdletContext.GrantArn;
            }
            if (cmdletContext.GrantName != null)
            {
                request.GrantName = cmdletContext.GrantName;
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
             // determine if request.Options should be set to null
            if (requestOptionsIsNull)
            {
                request.Options = null;
            }
            if (cmdletContext.SourceVersion != null)
            {
                request.SourceVersion = cmdletContext.SourceVersion;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.StatusReason != null)
            {
                request.StatusReason = cmdletContext.StatusReason;
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
        
        private Amazon.LicenseManager.Model.CreateGrantVersionResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.CreateGrantVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "CreateGrantVersion");
            try
            {
                #if DESKTOP
                return client.CreateGrantVersion(request);
                #elif CORECLR
                return client.CreateGrantVersionAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> AllowedOperation { get; set; }
            public System.String ClientToken { get; set; }
            public System.String GrantArn { get; set; }
            public System.String GrantName { get; set; }
            public Amazon.LicenseManager.ActivationOverrideBehavior Options_ActivationOverrideBehavior { get; set; }
            public System.String SourceVersion { get; set; }
            public Amazon.LicenseManager.GrantStatus Status { get; set; }
            public System.String StatusReason { get; set; }
            public System.Func<Amazon.LicenseManager.Model.CreateGrantVersionResponse, NewLICMGrantVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
