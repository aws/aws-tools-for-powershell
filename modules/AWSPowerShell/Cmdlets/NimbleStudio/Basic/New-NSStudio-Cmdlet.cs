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
using Amazon.NimbleStudio;
using Amazon.NimbleStudio.Model;

namespace Amazon.PowerShell.Cmdlets.NS
{
    /// <summary>
    /// Create a new studio.
    /// 
    ///  
    /// <para>
    /// When creating a studio, two IAM roles must be provided: the admin role and the user
    /// role. These roles are assumed by your users when they log in to the Nimble Studio
    /// portal.
    /// </para><para>
    /// The user role must have the <c>AmazonNimbleStudio-StudioUser</c> managed policy attached
    /// for the portal to function properly.
    /// </para><para>
    /// The admin role must have the <c>AmazonNimbleStudio-StudioAdmin</c> managed policy
    /// attached for the portal to function properly.
    /// </para><para>
    /// You may optionally specify a KMS key in the <c>StudioEncryptionConfiguration</c>.
    /// </para><para>
    /// In Nimble Studio, resource names, descriptions, initialization scripts, and other
    /// data you provide are always encrypted at rest using an KMS key. By default, this key
    /// is owned by Amazon Web Services and managed on your behalf. You may provide your own
    /// KMS key when calling <c>CreateStudio</c> to encrypt this data using a key you own
    /// and manage.
    /// </para><para>
    /// When providing an KMS key during studio creation, Nimble Studio creates KMS grants
    /// in your account to provide your studio user and admin roles access to these KMS keys.
    /// </para><para>
    /// If you delete this grant, the studio will no longer be accessible to your portal users.
    /// </para><para>
    /// If you delete the studio KMS key, your studio will no longer be accessible.
    /// </para>
    /// </summary>
    [Cmdlet("New", "NSStudio", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NimbleStudio.Model.Studio")]
    [AWSCmdlet("Calls the Amazon Nimble Studio CreateStudio API operation.", Operation = new[] {"CreateStudio"}, SelectReturnType = typeof(Amazon.NimbleStudio.Model.CreateStudioResponse))]
    [AWSCmdletOutput("Amazon.NimbleStudio.Model.Studio or Amazon.NimbleStudio.Model.CreateStudioResponse",
        "This cmdlet returns an Amazon.NimbleStudio.Model.Studio object.",
        "The service call response (type Amazon.NimbleStudio.Model.CreateStudioResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewNSStudioCmdlet : AmazonNimbleStudioClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AdminRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that studio admins will assume when logging in to the Nimble Studio portal.</para>
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
        public System.String AdminRoleArn { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A friendly name for the studio.</para>
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
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter StudioEncryptionConfiguration_KeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN for a KMS key that is used to encrypt studio data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StudioEncryptionConfiguration_KeyArn { get; set; }
        #endregion
        
        #region Parameter StudioEncryptionConfiguration_KeyType
        /// <summary>
        /// <para>
        /// <para>The type of KMS key that is used to encrypt studio data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NimbleStudio.StudioEncryptionConfigurationKeyType")]
        public Amazon.NimbleStudio.StudioEncryptionConfigurationKeyType StudioEncryptionConfiguration_KeyType { get; set; }
        #endregion
        
        #region Parameter StudioName
        /// <summary>
        /// <para>
        /// <para>The studio name that is used in the URL of the Nimble Studio portal when accessed
        /// by Nimble Studio users.</para>
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
        public System.String StudioName { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A collection of labels, in the form of key-value pairs, that apply to this resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter UserRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM role that studio users will assume when logging in to the Nimble Studio portal.</para>
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
        public System.String UserRoleArn { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. If you don’t specify a client token, the Amazon Web Services SDK automatically
        /// generates a client token and uses it for the request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Studio'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NimbleStudio.Model.CreateStudioResponse).
        /// Specifying the name of a property of type Amazon.NimbleStudio.Model.CreateStudioResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Studio";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StudioName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-NSStudio (CreateStudio)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NimbleStudio.Model.CreateStudioResponse, NewNSStudioCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdminRoleArn = this.AdminRoleArn;
            #if MODULAR
            if (this.AdminRoleArn == null && ParameterWasBound(nameof(this.AdminRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AdminRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StudioEncryptionConfiguration_KeyArn = this.StudioEncryptionConfiguration_KeyArn;
            context.StudioEncryptionConfiguration_KeyType = this.StudioEncryptionConfiguration_KeyType;
            context.StudioName = this.StudioName;
            #if MODULAR
            if (this.StudioName == null && ParameterWasBound(nameof(this.StudioName)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.UserRoleArn = this.UserRoleArn;
            #if MODULAR
            if (this.UserRoleArn == null && ParameterWasBound(nameof(this.UserRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter UserRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NimbleStudio.Model.CreateStudioRequest();
            
            if (cmdletContext.AdminRoleArn != null)
            {
                request.AdminRoleArn = cmdletContext.AdminRoleArn;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate StudioEncryptionConfiguration
            var requestStudioEncryptionConfigurationIsNull = true;
            request.StudioEncryptionConfiguration = new Amazon.NimbleStudio.Model.StudioEncryptionConfiguration();
            System.String requestStudioEncryptionConfiguration_studioEncryptionConfiguration_KeyArn = null;
            if (cmdletContext.StudioEncryptionConfiguration_KeyArn != null)
            {
                requestStudioEncryptionConfiguration_studioEncryptionConfiguration_KeyArn = cmdletContext.StudioEncryptionConfiguration_KeyArn;
            }
            if (requestStudioEncryptionConfiguration_studioEncryptionConfiguration_KeyArn != null)
            {
                request.StudioEncryptionConfiguration.KeyArn = requestStudioEncryptionConfiguration_studioEncryptionConfiguration_KeyArn;
                requestStudioEncryptionConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.StudioEncryptionConfigurationKeyType requestStudioEncryptionConfiguration_studioEncryptionConfiguration_KeyType = null;
            if (cmdletContext.StudioEncryptionConfiguration_KeyType != null)
            {
                requestStudioEncryptionConfiguration_studioEncryptionConfiguration_KeyType = cmdletContext.StudioEncryptionConfiguration_KeyType;
            }
            if (requestStudioEncryptionConfiguration_studioEncryptionConfiguration_KeyType != null)
            {
                request.StudioEncryptionConfiguration.KeyType = requestStudioEncryptionConfiguration_studioEncryptionConfiguration_KeyType;
                requestStudioEncryptionConfigurationIsNull = false;
            }
             // determine if request.StudioEncryptionConfiguration should be set to null
            if (requestStudioEncryptionConfigurationIsNull)
            {
                request.StudioEncryptionConfiguration = null;
            }
            if (cmdletContext.StudioName != null)
            {
                request.StudioName = cmdletContext.StudioName;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.UserRoleArn != null)
            {
                request.UserRoleArn = cmdletContext.UserRoleArn;
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
        
        private Amazon.NimbleStudio.Model.CreateStudioResponse CallAWSServiceOperation(IAmazonNimbleStudio client, Amazon.NimbleStudio.Model.CreateStudioRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nimble Studio", "CreateStudio");
            try
            {
                #if DESKTOP
                return client.CreateStudio(request);
                #elif CORECLR
                return client.CreateStudioAsync(request).GetAwaiter().GetResult();
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
            public System.String AdminRoleArn { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DisplayName { get; set; }
            public System.String StudioEncryptionConfiguration_KeyArn { get; set; }
            public Amazon.NimbleStudio.StudioEncryptionConfigurationKeyType StudioEncryptionConfiguration_KeyType { get; set; }
            public System.String StudioName { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String UserRoleArn { get; set; }
            public System.Func<Amazon.NimbleStudio.Model.CreateStudioResponse, NewNSStudioCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Studio;
        }
        
    }
}
