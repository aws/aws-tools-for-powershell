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
using Amazon.OpenSearchServerless;
using Amazon.OpenSearchServerless.Model;

namespace Amazon.PowerShell.Cmdlets.OSS
{
    /// <summary>
    /// Updates a security configuration for OpenSearch Serverless. For more information,
    /// see <a href="https://docs.aws.amazon.com/opensearch-service/latest/developerguide/serverless-saml.html">SAML
    /// authentication for Amazon OpenSearch Serverless</a>.
    /// </summary>
    [Cmdlet("Update", "OSSSecurityConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.OpenSearchServerless.Model.SecurityConfigDetail")]
    [AWSCmdlet("Calls the OpenSearch Serverless UpdateSecurityConfig API operation.", Operation = new[] {"UpdateSecurityConfig"}, SelectReturnType = typeof(Amazon.OpenSearchServerless.Model.UpdateSecurityConfigResponse))]
    [AWSCmdletOutput("Amazon.OpenSearchServerless.Model.SecurityConfigDetail or Amazon.OpenSearchServerless.Model.UpdateSecurityConfigResponse",
        "This cmdlet returns an Amazon.OpenSearchServerless.Model.SecurityConfigDetail object.",
        "The service call response (type Amazon.OpenSearchServerless.Model.UpdateSecurityConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOSSSecurityConfigCmdlet : AmazonOpenSearchServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ConfigVersion
        /// <summary>
        /// <para>
        /// <para>The version of the security configuration to be updated. You can find the most recent
        /// version of a security configuration using the <c>GetSecurityPolicy</c> command.</para>
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
        public System.String ConfigVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the security configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IamIdentityCenterOptionsUpdates_GroupAttribute
        /// <summary>
        /// <para>
        /// <para>The group attribute for this IAM Identity Center integration. Defaults to <c>GroupId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchServerless.IamIdentityCenterGroupAttribute")]
        public Amazon.OpenSearchServerless.IamIdentityCenterGroupAttribute IamIdentityCenterOptionsUpdates_GroupAttribute { get; set; }
        #endregion
        
        #region Parameter SamlOptions_GroupAttribute
        /// <summary>
        /// <para>
        /// <para>The group attribute for this SAML integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamlOptions_GroupAttribute { get; set; }
        #endregion
        
        #region Parameter Id
        /// <summary>
        /// <para>
        /// <para>The security configuration identifier. For SAML the ID will be <c>saml/&lt;accountId&gt;/&lt;idpProviderName&gt;</c>.
        /// For example, <c>saml/123456789123/OKTADev</c>.</para>
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
        public System.String Id { get; set; }
        #endregion
        
        #region Parameter SamlOptions_Metadata
        /// <summary>
        /// <para>
        /// <para>The XML IdP metadata file generated from your identity provider.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamlOptions_Metadata { get; set; }
        #endregion
        
        #region Parameter SamlOptions_SessionTimeout
        /// <summary>
        /// <para>
        /// <para>The session timeout, in minutes. Default is 60 minutes (12 hours).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SamlOptions_SessionTimeout { get; set; }
        #endregion
        
        #region Parameter IamIdentityCenterOptionsUpdates_UserAttribute
        /// <summary>
        /// <para>
        /// <para>The user attribute for this IAM Identity Center integration. Defaults to <c>UserId</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.OpenSearchServerless.IamIdentityCenterUserAttribute")]
        public Amazon.OpenSearchServerless.IamIdentityCenterUserAttribute IamIdentityCenterOptionsUpdates_UserAttribute { get; set; }
        #endregion
        
        #region Parameter SamlOptions_UserAttribute
        /// <summary>
        /// <para>
        /// <para>A user attribute for this SAML integration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SamlOptions_UserAttribute { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier to ensure idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecurityConfigDetail'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchServerless.Model.UpdateSecurityConfigResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchServerless.Model.UpdateSecurityConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecurityConfigDetail";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Id), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSSSecurityConfig (UpdateSecurityConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchServerless.Model.UpdateSecurityConfigResponse, UpdateOSSSecurityConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.ConfigVersion = this.ConfigVersion;
            #if MODULAR
            if (this.ConfigVersion == null && ParameterWasBound(nameof(this.ConfigVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.IamIdentityCenterOptionsUpdates_GroupAttribute = this.IamIdentityCenterOptionsUpdates_GroupAttribute;
            context.IamIdentityCenterOptionsUpdates_UserAttribute = this.IamIdentityCenterOptionsUpdates_UserAttribute;
            context.Id = this.Id;
            #if MODULAR
            if (this.Id == null && ParameterWasBound(nameof(this.Id)))
            {
                WriteWarning("You are passing $null as a value for parameter Id which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SamlOptions_GroupAttribute = this.SamlOptions_GroupAttribute;
            context.SamlOptions_Metadata = this.SamlOptions_Metadata;
            context.SamlOptions_SessionTimeout = this.SamlOptions_SessionTimeout;
            context.SamlOptions_UserAttribute = this.SamlOptions_UserAttribute;
            
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
            var request = new Amazon.OpenSearchServerless.Model.UpdateSecurityConfigRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ConfigVersion != null)
            {
                request.ConfigVersion = cmdletContext.ConfigVersion;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate IamIdentityCenterOptionsUpdates
            var requestIamIdentityCenterOptionsUpdatesIsNull = true;
            request.IamIdentityCenterOptionsUpdates = new Amazon.OpenSearchServerless.Model.UpdateIamIdentityCenterConfigOptions();
            Amazon.OpenSearchServerless.IamIdentityCenterGroupAttribute requestIamIdentityCenterOptionsUpdates_iamIdentityCenterOptionsUpdates_GroupAttribute = null;
            if (cmdletContext.IamIdentityCenterOptionsUpdates_GroupAttribute != null)
            {
                requestIamIdentityCenterOptionsUpdates_iamIdentityCenterOptionsUpdates_GroupAttribute = cmdletContext.IamIdentityCenterOptionsUpdates_GroupAttribute;
            }
            if (requestIamIdentityCenterOptionsUpdates_iamIdentityCenterOptionsUpdates_GroupAttribute != null)
            {
                request.IamIdentityCenterOptionsUpdates.GroupAttribute = requestIamIdentityCenterOptionsUpdates_iamIdentityCenterOptionsUpdates_GroupAttribute;
                requestIamIdentityCenterOptionsUpdatesIsNull = false;
            }
            Amazon.OpenSearchServerless.IamIdentityCenterUserAttribute requestIamIdentityCenterOptionsUpdates_iamIdentityCenterOptionsUpdates_UserAttribute = null;
            if (cmdletContext.IamIdentityCenterOptionsUpdates_UserAttribute != null)
            {
                requestIamIdentityCenterOptionsUpdates_iamIdentityCenterOptionsUpdates_UserAttribute = cmdletContext.IamIdentityCenterOptionsUpdates_UserAttribute;
            }
            if (requestIamIdentityCenterOptionsUpdates_iamIdentityCenterOptionsUpdates_UserAttribute != null)
            {
                request.IamIdentityCenterOptionsUpdates.UserAttribute = requestIamIdentityCenterOptionsUpdates_iamIdentityCenterOptionsUpdates_UserAttribute;
                requestIamIdentityCenterOptionsUpdatesIsNull = false;
            }
             // determine if request.IamIdentityCenterOptionsUpdates should be set to null
            if (requestIamIdentityCenterOptionsUpdatesIsNull)
            {
                request.IamIdentityCenterOptionsUpdates = null;
            }
            if (cmdletContext.Id != null)
            {
                request.Id = cmdletContext.Id;
            }
            
             // populate SamlOptions
            var requestSamlOptionsIsNull = true;
            request.SamlOptions = new Amazon.OpenSearchServerless.Model.SamlConfigOptions();
            System.String requestSamlOptions_samlOptions_GroupAttribute = null;
            if (cmdletContext.SamlOptions_GroupAttribute != null)
            {
                requestSamlOptions_samlOptions_GroupAttribute = cmdletContext.SamlOptions_GroupAttribute;
            }
            if (requestSamlOptions_samlOptions_GroupAttribute != null)
            {
                request.SamlOptions.GroupAttribute = requestSamlOptions_samlOptions_GroupAttribute;
                requestSamlOptionsIsNull = false;
            }
            System.String requestSamlOptions_samlOptions_Metadata = null;
            if (cmdletContext.SamlOptions_Metadata != null)
            {
                requestSamlOptions_samlOptions_Metadata = cmdletContext.SamlOptions_Metadata;
            }
            if (requestSamlOptions_samlOptions_Metadata != null)
            {
                request.SamlOptions.Metadata = requestSamlOptions_samlOptions_Metadata;
                requestSamlOptionsIsNull = false;
            }
            System.Int32? requestSamlOptions_samlOptions_SessionTimeout = null;
            if (cmdletContext.SamlOptions_SessionTimeout != null)
            {
                requestSamlOptions_samlOptions_SessionTimeout = cmdletContext.SamlOptions_SessionTimeout.Value;
            }
            if (requestSamlOptions_samlOptions_SessionTimeout != null)
            {
                request.SamlOptions.SessionTimeout = requestSamlOptions_samlOptions_SessionTimeout.Value;
                requestSamlOptionsIsNull = false;
            }
            System.String requestSamlOptions_samlOptions_UserAttribute = null;
            if (cmdletContext.SamlOptions_UserAttribute != null)
            {
                requestSamlOptions_samlOptions_UserAttribute = cmdletContext.SamlOptions_UserAttribute;
            }
            if (requestSamlOptions_samlOptions_UserAttribute != null)
            {
                request.SamlOptions.UserAttribute = requestSamlOptions_samlOptions_UserAttribute;
                requestSamlOptionsIsNull = false;
            }
             // determine if request.SamlOptions should be set to null
            if (requestSamlOptionsIsNull)
            {
                request.SamlOptions = null;
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
        
        private Amazon.OpenSearchServerless.Model.UpdateSecurityConfigResponse CallAWSServiceOperation(IAmazonOpenSearchServerless client, Amazon.OpenSearchServerless.Model.UpdateSecurityConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "OpenSearch Serverless", "UpdateSecurityConfig");
            try
            {
                #if DESKTOP
                return client.UpdateSecurityConfig(request);
                #elif CORECLR
                return client.UpdateSecurityConfigAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String ConfigVersion { get; set; }
            public System.String Description { get; set; }
            public Amazon.OpenSearchServerless.IamIdentityCenterGroupAttribute IamIdentityCenterOptionsUpdates_GroupAttribute { get; set; }
            public Amazon.OpenSearchServerless.IamIdentityCenterUserAttribute IamIdentityCenterOptionsUpdates_UserAttribute { get; set; }
            public System.String Id { get; set; }
            public System.String SamlOptions_GroupAttribute { get; set; }
            public System.String SamlOptions_Metadata { get; set; }
            public System.Int32? SamlOptions_SessionTimeout { get; set; }
            public System.String SamlOptions_UserAttribute { get; set; }
            public System.Func<Amazon.OpenSearchServerless.Model.UpdateSecurityConfigResponse, UpdateOSSSecurityConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecurityConfigDetail;
        }
        
    }
}
