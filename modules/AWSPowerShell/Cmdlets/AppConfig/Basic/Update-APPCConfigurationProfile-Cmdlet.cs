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
using Amazon.AppConfig;
using Amazon.AppConfig.Model;

namespace Amazon.PowerShell.Cmdlets.APPC
{
    /// <summary>
    /// Updates a configuration profile.
    /// </summary>
    [Cmdlet("Update", "APPCConfigurationProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppConfig.Model.UpdateConfigurationProfileResponse")]
    [AWSCmdlet("Calls the AWS AppConfig UpdateConfigurationProfile API operation.", Operation = new[] {"UpdateConfigurationProfile"}, SelectReturnType = typeof(Amazon.AppConfig.Model.UpdateConfigurationProfileResponse))]
    [AWSCmdletOutput("Amazon.AppConfig.Model.UpdateConfigurationProfileResponse",
        "This cmdlet returns an Amazon.AppConfig.Model.UpdateConfigurationProfileResponse object containing multiple properties."
    )]
    public partial class UpdateAPPCConfigurationProfileCmdlet : AmazonAppConfigClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The application ID.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter ConfigurationProfileId
        /// <summary>
        /// <para>
        /// <para>The ID of the configuration profile.</para>
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
        public System.String ConfigurationProfileId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the configuration profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter KmsKeyIdentifier
        /// <summary>
        /// <para>
        /// <para>The identifier for a Key Management Service key to encrypt new configuration data
        /// versions in the AppConfig hosted configuration store. This attribute is only used
        /// for <c>hosted</c> configuration types. The identifier can be an KMS key ID, alias,
        /// or the Amazon Resource Name (ARN) of the key ID or alias. To encrypt data managed
        /// in other configuration stores, see the documentation for how to specify an KMS key
        /// for that particular service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the configuration profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RetrievalRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of an IAM role with permission to access the configuration at the specified
        /// <c>LocationUri</c>.</para><important><para>A retrieval role ARN is not required for configurations stored in CodePipeline or
        /// the AppConfig hosted configuration store. It is required for all other sources that
        /// store your configuration. </para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RetrievalRoleArn { get; set; }
        #endregion
        
        #region Parameter Validator
        /// <summary>
        /// <para>
        /// <para>A list of methods for validating the configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Validators")]
        public Amazon.AppConfig.Model.Validator[] Validator { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppConfig.Model.UpdateConfigurationProfileResponse).
        /// Specifying the name of a property of type Amazon.AppConfig.Model.UpdateConfigurationProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ConfigurationProfileId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ConfigurationProfileId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ConfigurationProfileId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ConfigurationProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APPCConfigurationProfile (UpdateConfigurationProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppConfig.Model.UpdateConfigurationProfileResponse, UpdateAPPCConfigurationProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ConfigurationProfileId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ConfigurationProfileId = this.ConfigurationProfileId;
            #if MODULAR
            if (this.ConfigurationProfileId == null && ParameterWasBound(nameof(this.ConfigurationProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter ConfigurationProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.KmsKeyIdentifier = this.KmsKeyIdentifier;
            context.Name = this.Name;
            context.RetrievalRoleArn = this.RetrievalRoleArn;
            if (this.Validator != null)
            {
                context.Validator = new List<Amazon.AppConfig.Model.Validator>(this.Validator);
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
            var request = new Amazon.AppConfig.Model.UpdateConfigurationProfileRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            if (cmdletContext.ConfigurationProfileId != null)
            {
                request.ConfigurationProfileId = cmdletContext.ConfigurationProfileId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.KmsKeyIdentifier != null)
            {
                request.KmsKeyIdentifier = cmdletContext.KmsKeyIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.RetrievalRoleArn != null)
            {
                request.RetrievalRoleArn = cmdletContext.RetrievalRoleArn;
            }
            if (cmdletContext.Validator != null)
            {
                request.Validators = cmdletContext.Validator;
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
        
        private Amazon.AppConfig.Model.UpdateConfigurationProfileResponse CallAWSServiceOperation(IAmazonAppConfig client, Amazon.AppConfig.Model.UpdateConfigurationProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppConfig", "UpdateConfigurationProfile");
            try
            {
                #if DESKTOP
                return client.UpdateConfigurationProfile(request);
                #elif CORECLR
                return client.UpdateConfigurationProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String ConfigurationProfileId { get; set; }
            public System.String Description { get; set; }
            public System.String KmsKeyIdentifier { get; set; }
            public System.String Name { get; set; }
            public System.String RetrievalRoleArn { get; set; }
            public List<Amazon.AppConfig.Model.Validator> Validator { get; set; }
            public System.Func<Amazon.AppConfig.Model.UpdateConfigurationProfileResponse, UpdateAPPCConfigurationProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
