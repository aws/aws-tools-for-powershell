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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Sets the specified version of the global endpoint token as the token version used
    /// for the Amazon Web Services account.
    /// 
    ///  
    /// <para>
    /// By default, Security Token Service (STS) is available as a global service, and all
    /// STS requests go to a single endpoint at <c>https://sts.amazonaws.com</c>. Amazon Web
    /// Services recommends using Regional STS endpoints to reduce latency, build in redundancy,
    /// and increase session token availability. For information about Regional endpoints
    /// for STS, see <a href="https://docs.aws.amazon.com/general/latest/gr/sts.html">Security
    /// Token Service endpoints and quotas</a> in the <i>Amazon Web Services General Reference</i>.
    /// </para><para>
    /// If you make an STS call to the global endpoint, the resulting session tokens might
    /// be valid in some Regions but not others. It depends on the version that is set in
    /// this operation. Version 1 tokens are valid only in Amazon Web Services Regions that
    /// are available by default. These tokens do not work in manually enabled Regions, such
    /// as Asia Pacific (Hong Kong). Version 2 tokens are valid in all Regions. However, version
    /// 2 tokens are longer and might affect systems where you temporarily store tokens. For
    /// information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_enable-regions.html">Activating
    /// and deactivating STS in an Amazon Web Services Region</a> in the <i>IAM User Guide</i>.
    /// </para><para>
    /// To view the current session token version, see the <c>GlobalEndpointTokenVersion</c>
    /// entry in the response of the <a>GetAccountSummary</a> operation.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "IAMSecurityTokenServicePreference", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management SetSecurityTokenServicePreferences API operation.", Operation = new[] {"SetSecurityTokenServicePreferences"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SetIAMSecurityTokenServicePreferenceCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter GlobalEndpointTokenVersion
        /// <summary>
        /// <para>
        /// <para>The version of the global endpoint token. Version 1 tokens are valid only in Amazon
        /// Web Services Regions that are available by default. These tokens do not work in manually
        /// enabled Regions, such as Asia Pacific (Hong Kong). Version 2 tokens are valid in all
        /// Regions. However, version 2 tokens are longer and might affect systems where you temporarily
        /// store tokens.</para><para>For information, see <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/id_credentials_temp_enable-regions.html">Activating
        /// and deactivating STS in an Amazon Web Services Region</a> in the <i>IAM User Guide</i>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IdentityManagement.GlobalEndpointTokenVersion")]
        public Amazon.IdentityManagement.GlobalEndpointTokenVersion GlobalEndpointTokenVersion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the GlobalEndpointTokenVersion parameter.
        /// The -PassThru parameter is deprecated, use -Select '^GlobalEndpointTokenVersion' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^GlobalEndpointTokenVersion' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.GlobalEndpointTokenVersion), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-IAMSecurityTokenServicePreference (SetSecurityTokenServicePreferences)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesResponse, SetIAMSecurityTokenServicePreferenceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.GlobalEndpointTokenVersion;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.GlobalEndpointTokenVersion = this.GlobalEndpointTokenVersion;
            #if MODULAR
            if (this.GlobalEndpointTokenVersion == null && ParameterWasBound(nameof(this.GlobalEndpointTokenVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter GlobalEndpointTokenVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesRequest();
            
            if (cmdletContext.GlobalEndpointTokenVersion != null)
            {
                request.GlobalEndpointTokenVersion = cmdletContext.GlobalEndpointTokenVersion;
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
        
        private Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "SetSecurityTokenServicePreferences");
            try
            {
                #if DESKTOP
                return client.SetSecurityTokenServicePreferences(request);
                #elif CORECLR
                return client.SetSecurityTokenServicePreferencesAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IdentityManagement.GlobalEndpointTokenVersion GlobalEndpointTokenVersion { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.SetSecurityTokenServicePreferencesResponse, SetIAMSecurityTokenServicePreferenceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
