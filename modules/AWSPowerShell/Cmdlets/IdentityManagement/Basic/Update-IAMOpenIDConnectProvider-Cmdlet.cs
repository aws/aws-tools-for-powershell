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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Updates the configuration of an existing IAM OpenID Connect (OIDC) identity provider
    /// resource object. Use this operation to set, change, or remove the trusted identity
    /// propagation context provider, and to associate or disassociate an IAM Identity Center
    /// instance with the provider.
    /// 
    ///  <note><para>
    /// This operation does not update the OIDC provider's server certificate thumbprints.
    /// Thumbprints are managed only by the <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_UpdateOpenIDConnectProviderThumbprint.html">UpdateOpenIDConnectProviderThumbprint</a>
    /// operation. To change a provider's thumbprints, call that operation instead.
    /// </para></note><para>
    /// To remove a configuration rather than replace it, use the <c>RemoveContextProvider</c>
    /// and <c>RemoveIdentityCenterInstance</c> parameters. For each configuration, provide
    /// either the new value or the corresponding <c>Remove</c> flag in a single request,
    /// but not both. For example, specifying both <c>ContextProvider</c> and <c>RemoveContextProvider</c>
    /// in the same request is not allowed.
    /// </para><para>
    /// A single request can change either the context provider or the IAM Identity Center
    /// association, but not both. To change both, make separate <c>UpdateOpenIDConnectProvider</c>
    /// requests. To remove the context provider, first remove the IAM Identity Center association
    /// in a separate request.
    /// </para><para>
    /// To control who can configure trusted identity propagation on an OIDC provider, use
    /// the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_iam-condition-keys.html#ck_EnableIdentityPropagation">iam:EnableIdentityPropagation</a>,
    /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_iam-condition-keys.html#ck_EnableIdentityCenterAssociation">iam:EnableIdentityCenterAssociation</a>,
    /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_iam-condition-keys.html#ck_ResourceIdentityProviderIssuers">iam:ResourceIdentityProviderIssuers</a>,
    /// <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_iam-condition-keys.html#ck_RequestIdentityCenterInstanceArn">iam:RequestIdentityCenterInstanceArn</a>,
    /// and <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/reference_policies_iam-condition-keys.html#ck_ResourceIdentityCenterInstanceArn">iam:ResourceIdentityCenterInstanceArn</a>
    /// condition keys in IAM policies. The <c>Request</c> keys contain the values in the
    /// request. The <c>Resource</c> keys contain the values stored on the provider.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "IAMOpenIDConnectProvider", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Identity and Access Management UpdateOpenIDConnectProvider API operation.", Operation = new[] {"UpdateOpenIDConnectProvider"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderResponse))]
    [AWSCmdletOutput("None or Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIAMOpenIDConnectProviderCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter IdentityCenterInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM Identity Center instance to associate with
        /// the OIDC provider.</para><para>For the format, see <a href="https://docs.aws.amazon.com/singlesignon/latest/APIReference/API_InstanceMetadata.html">InstanceMetadata</a>
        /// in the <i>IAM Identity Center API Reference</i>.</para><para>To disassociate the currently associated instance instead of changing it, use <c>RemoveIdentityCenterInstance</c>.
        /// Do not specify both <c>IdentityCenterInstanceArn</c> and <c>RemoveIdentityCenterInstance</c>
        /// in the same request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdentityCenterInstanceArn { get; set; }
        #endregion
        
        #region Parameter ContextProvider_KeyDefinitionList
        /// <summary>
        /// <para>
        /// <para>A list of source-to-target key mappings that define how keys from the external identity
        /// provider's assertion or token are mapped into trusted context keys. You can specify
        /// from 0 to 10 mappings.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.IdentityManagement.Model.ContextProviderKeyDefinition[] ContextProvider_KeyDefinitionList { get; set; }
        #endregion
        
        #region Parameter OpenIDConnectProviderArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM OIDC provider resource object to update.
        /// You can get a list of OIDC provider resource ARNs by using the <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_ListOpenIDConnectProviders.html">ListOpenIDConnectProviders</a>
        /// operation.</para><para>For more information about ARNs, see <a href="https://docs.aws.amazon.com/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs)</a> in the <i>Amazon Web Services General Reference</i>.</para>
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
        public System.String OpenIDConnectProviderArn { get; set; }
        #endregion
        
        #region Parameter RemoveContextProvider
        /// <summary>
        /// <para>
        /// <para>Specifies whether to remove the existing context provider configuration from the OIDC
        /// provider. Set this value to <c>true</c> to remove the context provider.</para><para>This parameter is mutually exclusive with <c>ContextProvider</c>. In a single request,
        /// specify either a new <c>ContextProvider</c> value or <c>RemoveContextProvider</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveContextProvider { get; set; }
        #endregion
        
        #region Parameter RemoveIdentityCenterInstance
        /// <summary>
        /// <para>
        /// <para>Specifies whether to disassociate the IAM Identity Center instance from the OIDC provider.
        /// Set this value to <c>true</c> to remove the association.</para><para>This parameter is mutually exclusive with <c>IdentityCenterInstanceArn</c>. In a single
        /// request, specify either a new <c>IdentityCenterInstanceArn</c> value or <c>RemoveIdentityCenterInstance</c>,
        /// but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RemoveIdentityCenterInstance { get; set; }
        #endregion
        
        #region Parameter ContextProvider_SubjectSourceKey
        /// <summary>
        /// <para>
        /// <para>The source key that is used to derive the subject for the injected trusted context.
        /// This value identifies the claim or attribute in the external identity provider's assertion
        /// or token that supplies the subject.</para><para>The key can contain only ASCII letters (A-Z, a-z), numbers (0-9), single spaces, and
        /// the following characters: <c>_ . : / = + - @ #</c>. It can't start or end with a space
        /// or contain two spaces in a row.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextProvider_SubjectSourceKey { get; set; }
        #endregion
        
        #region Parameter ContextProvider_SubjectTypeSourceKey
        /// <summary>
        /// <para>
        /// <para>The source key that supplies the subject type from the external identity provider's
        /// assertion or token.</para><para>The key can contain only ASCII letters (A-Z, a-z), numbers (0-9), single spaces, and
        /// the following characters: <c>_ . : / = + - @ #</c>. It can't start or end with a space
        /// or contain two spaces in a row.</para><para>This parameter is mutually exclusive with <c>SubjectTypeValue</c>. Specify either
        /// <c>SubjectTypeSourceKey</c> or <c>SubjectTypeValue</c>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextProvider_SubjectTypeSourceKey { get; set; }
        #endregion
        
        #region Parameter ContextProvider_SubjectTypeValue
        /// <summary>
        /// <para>
        /// <para>A static value for the subject type, such as <c>user</c> or <c>workload</c>.</para><para>This parameter is optional and is mutually exclusive with <c>SubjectTypeSourceKey</c>.
        /// Specify either <c>SubjectTypeValue</c> or <c>SubjectTypeSourceKey</c>, but not both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextProvider_SubjectTypeValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OpenIDConnectProviderArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IAMOpenIDConnectProvider (UpdateOpenIDConnectProvider)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderResponse, UpdateIAMOpenIDConnectProviderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.ContextProvider_KeyDefinitionList != null)
            {
                context.ContextProvider_KeyDefinitionList = new List<Amazon.IdentityManagement.Model.ContextProviderKeyDefinition>(this.ContextProvider_KeyDefinitionList);
            }
            context.ContextProvider_SubjectSourceKey = this.ContextProvider_SubjectSourceKey;
            context.ContextProvider_SubjectTypeSourceKey = this.ContextProvider_SubjectTypeSourceKey;
            context.ContextProvider_SubjectTypeValue = this.ContextProvider_SubjectTypeValue;
            context.IdentityCenterInstanceArn = this.IdentityCenterInstanceArn;
            context.OpenIDConnectProviderArn = this.OpenIDConnectProviderArn;
            #if MODULAR
            if (this.OpenIDConnectProviderArn == null && ParameterWasBound(nameof(this.OpenIDConnectProviderArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OpenIDConnectProviderArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RemoveContextProvider = this.RemoveContextProvider;
            context.RemoveIdentityCenterInstance = this.RemoveIdentityCenterInstance;
            
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
            var request = new Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderRequest();
            
            
             // populate ContextProvider
            var requestContextProviderIsNull = true;
            request.ContextProvider = new Amazon.IdentityManagement.Model.ContextProvider();
            List<Amazon.IdentityManagement.Model.ContextProviderKeyDefinition> requestContextProvider_contextProvider_KeyDefinitionList = null;
            if (cmdletContext.ContextProvider_KeyDefinitionList != null)
            {
                requestContextProvider_contextProvider_KeyDefinitionList = cmdletContext.ContextProvider_KeyDefinitionList;
            }
            if (requestContextProvider_contextProvider_KeyDefinitionList != null)
            {
                request.ContextProvider.KeyDefinitionList = requestContextProvider_contextProvider_KeyDefinitionList;
                requestContextProviderIsNull = false;
            }
            System.String requestContextProvider_contextProvider_SubjectSourceKey = null;
            if (cmdletContext.ContextProvider_SubjectSourceKey != null)
            {
                requestContextProvider_contextProvider_SubjectSourceKey = cmdletContext.ContextProvider_SubjectSourceKey;
            }
            if (requestContextProvider_contextProvider_SubjectSourceKey != null)
            {
                request.ContextProvider.SubjectSourceKey = requestContextProvider_contextProvider_SubjectSourceKey;
                requestContextProviderIsNull = false;
            }
            System.String requestContextProvider_contextProvider_SubjectTypeSourceKey = null;
            if (cmdletContext.ContextProvider_SubjectTypeSourceKey != null)
            {
                requestContextProvider_contextProvider_SubjectTypeSourceKey = cmdletContext.ContextProvider_SubjectTypeSourceKey;
            }
            if (requestContextProvider_contextProvider_SubjectTypeSourceKey != null)
            {
                request.ContextProvider.SubjectTypeSourceKey = requestContextProvider_contextProvider_SubjectTypeSourceKey;
                requestContextProviderIsNull = false;
            }
            System.String requestContextProvider_contextProvider_SubjectTypeValue = null;
            if (cmdletContext.ContextProvider_SubjectTypeValue != null)
            {
                requestContextProvider_contextProvider_SubjectTypeValue = cmdletContext.ContextProvider_SubjectTypeValue;
            }
            if (requestContextProvider_contextProvider_SubjectTypeValue != null)
            {
                request.ContextProvider.SubjectTypeValue = requestContextProvider_contextProvider_SubjectTypeValue;
                requestContextProviderIsNull = false;
            }
             // determine if request.ContextProvider should be set to null
            if (requestContextProviderIsNull)
            {
                request.ContextProvider = null;
            }
            if (cmdletContext.IdentityCenterInstanceArn != null)
            {
                request.IdentityCenterInstanceArn = cmdletContext.IdentityCenterInstanceArn;
            }
            if (cmdletContext.OpenIDConnectProviderArn != null)
            {
                request.OpenIDConnectProviderArn = cmdletContext.OpenIDConnectProviderArn;
            }
            if (cmdletContext.RemoveContextProvider != null)
            {
                request.RemoveContextProvider = cmdletContext.RemoveContextProvider.Value;
            }
            if (cmdletContext.RemoveIdentityCenterInstance != null)
            {
                request.RemoveIdentityCenterInstance = cmdletContext.RemoveIdentityCenterInstance.Value;
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
        
        private Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "UpdateOpenIDConnectProvider");
            try
            {
                return client.UpdateOpenIDConnectProviderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.IdentityManagement.Model.ContextProviderKeyDefinition> ContextProvider_KeyDefinitionList { get; set; }
            public System.String ContextProvider_SubjectSourceKey { get; set; }
            public System.String ContextProvider_SubjectTypeSourceKey { get; set; }
            public System.String ContextProvider_SubjectTypeValue { get; set; }
            public System.String IdentityCenterInstanceArn { get; set; }
            public System.String OpenIDConnectProviderArn { get; set; }
            public System.Boolean? RemoveContextProvider { get; set; }
            public System.Boolean? RemoveIdentityCenterInstance { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.UpdateOpenIDConnectProviderResponse, UpdateIAMOpenIDConnectProviderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
