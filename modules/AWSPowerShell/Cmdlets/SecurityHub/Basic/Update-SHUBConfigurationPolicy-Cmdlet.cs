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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Updates a configuration policy. Only the Security Hub delegated administrator can
    /// invoke this operation from the home Region.
    /// </summary>
    [Cmdlet("Update", "SHUBConfigurationPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateConfigurationPolicy API operation.", Operation = new[] {"UpdateConfigurationPolicy"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse",
        "This cmdlet returns an Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateSHUBConfigurationPolicyCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The description of the configuration policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter SecurityControlsConfiguration_DisabledSecurityControlIdentifier
        /// <summary>
        /// <para>
        /// <para> A list of security controls that are disabled in the configuration policy. Security
        /// Hub enables all other controls (including newly released controls) other than the
        /// listed controls. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationPolicy_SecurityHub_SecurityControlsConfiguration_DisabledSecurityControlIdentifiers")]
        public System.String[] SecurityControlsConfiguration_DisabledSecurityControlIdentifier { get; set; }
        #endregion
        
        #region Parameter SecurityControlsConfiguration_EnabledSecurityControlIdentifier
        /// <summary>
        /// <para>
        /// <para> A list of security controls that are enabled in the configuration policy. Security
        /// Hub disables all other controls (including newly released controls) other than the
        /// listed controls. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationPolicy_SecurityHub_SecurityControlsConfiguration_EnabledSecurityControlIdentifiers")]
        public System.String[] SecurityControlsConfiguration_EnabledSecurityControlIdentifier { get; set; }
        #endregion
        
        #region Parameter SecurityHub_EnabledStandardIdentifier
        /// <summary>
        /// <para>
        /// <para> A list that defines which security standards are enabled in the configuration policy.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationPolicy_SecurityHub_EnabledStandardIdentifiers")]
        public System.String[] SecurityHub_EnabledStandardIdentifier { get; set; }
        #endregion
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) or universally unique identifier (UUID) of the configuration
        /// policy. </para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The name of the configuration policy. Alphanumeric characters and the following ASCII
        /// characters are permitted: <code>-, ., !, *, /</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter SecurityControlsConfiguration_SecurityControlCustomParameter
        /// <summary>
        /// <para>
        /// <para> A list of security controls and control parameter values that are included in a configuration
        /// policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationPolicy_SecurityHub_SecurityControlsConfiguration_SecurityControlCustomParameters")]
        public Amazon.SecurityHub.Model.SecurityControlCustomParameter[] SecurityControlsConfiguration_SecurityControlCustomParameter { get; set; }
        #endregion
        
        #region Parameter SecurityHub_ServiceEnabled
        /// <summary>
        /// <para>
        /// <para> Indicates whether Security Hub is enabled in the policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ConfigurationPolicy_SecurityHub_ServiceEnabled")]
        public System.Boolean? SecurityHub_ServiceEnabled { get; set; }
        #endregion
        
        #region Parameter UpdatedReason
        /// <summary>
        /// <para>
        /// <para> The reason for updating the configuration policy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String UpdatedReason { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Identifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Identifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBConfigurationPolicy (UpdateConfigurationPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse, UpdateSHUBConfigurationPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Identifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.SecurityHub_EnabledStandardIdentifier != null)
            {
                context.SecurityHub_EnabledStandardIdentifier = new List<System.String>(this.SecurityHub_EnabledStandardIdentifier);
            }
            if (this.SecurityControlsConfiguration_DisabledSecurityControlIdentifier != null)
            {
                context.SecurityControlsConfiguration_DisabledSecurityControlIdentifier = new List<System.String>(this.SecurityControlsConfiguration_DisabledSecurityControlIdentifier);
            }
            if (this.SecurityControlsConfiguration_EnabledSecurityControlIdentifier != null)
            {
                context.SecurityControlsConfiguration_EnabledSecurityControlIdentifier = new List<System.String>(this.SecurityControlsConfiguration_EnabledSecurityControlIdentifier);
            }
            if (this.SecurityControlsConfiguration_SecurityControlCustomParameter != null)
            {
                context.SecurityControlsConfiguration_SecurityControlCustomParameter = new List<Amazon.SecurityHub.Model.SecurityControlCustomParameter>(this.SecurityControlsConfiguration_SecurityControlCustomParameter);
            }
            context.SecurityHub_ServiceEnabled = this.SecurityHub_ServiceEnabled;
            context.Description = this.Description;
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            context.UpdatedReason = this.UpdatedReason;
            
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
            var request = new Amazon.SecurityHub.Model.UpdateConfigurationPolicyRequest();
            
            
             // populate ConfigurationPolicy
            var requestConfigurationPolicyIsNull = true;
            request.ConfigurationPolicy = new Amazon.SecurityHub.Model.Policy();
            Amazon.SecurityHub.Model.SecurityHubPolicy requestConfigurationPolicy_configurationPolicy_SecurityHub = null;
            
             // populate SecurityHub
            var requestConfigurationPolicy_configurationPolicy_SecurityHubIsNull = true;
            requestConfigurationPolicy_configurationPolicy_SecurityHub = new Amazon.SecurityHub.Model.SecurityHubPolicy();
            List<System.String> requestConfigurationPolicy_configurationPolicy_SecurityHub_securityHub_EnabledStandardIdentifier = null;
            if (cmdletContext.SecurityHub_EnabledStandardIdentifier != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_securityHub_EnabledStandardIdentifier = cmdletContext.SecurityHub_EnabledStandardIdentifier;
            }
            if (requestConfigurationPolicy_configurationPolicy_SecurityHub_securityHub_EnabledStandardIdentifier != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub.EnabledStandardIdentifiers = requestConfigurationPolicy_configurationPolicy_SecurityHub_securityHub_EnabledStandardIdentifier;
                requestConfigurationPolicy_configurationPolicy_SecurityHubIsNull = false;
            }
            System.Boolean? requestConfigurationPolicy_configurationPolicy_SecurityHub_securityHub_ServiceEnabled = null;
            if (cmdletContext.SecurityHub_ServiceEnabled != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_securityHub_ServiceEnabled = cmdletContext.SecurityHub_ServiceEnabled.Value;
            }
            if (requestConfigurationPolicy_configurationPolicy_SecurityHub_securityHub_ServiceEnabled != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub.ServiceEnabled = requestConfigurationPolicy_configurationPolicy_SecurityHub_securityHub_ServiceEnabled.Value;
                requestConfigurationPolicy_configurationPolicy_SecurityHubIsNull = false;
            }
            Amazon.SecurityHub.Model.SecurityControlsConfiguration requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration = null;
            
             // populate SecurityControlsConfiguration
            var requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfigurationIsNull = true;
            requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration = new Amazon.SecurityHub.Model.SecurityControlsConfiguration();
            List<System.String> requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_DisabledSecurityControlIdentifier = null;
            if (cmdletContext.SecurityControlsConfiguration_DisabledSecurityControlIdentifier != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_DisabledSecurityControlIdentifier = cmdletContext.SecurityControlsConfiguration_DisabledSecurityControlIdentifier;
            }
            if (requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_DisabledSecurityControlIdentifier != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration.DisabledSecurityControlIdentifiers = requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_DisabledSecurityControlIdentifier;
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfigurationIsNull = false;
            }
            List<System.String> requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_EnabledSecurityControlIdentifier = null;
            if (cmdletContext.SecurityControlsConfiguration_EnabledSecurityControlIdentifier != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_EnabledSecurityControlIdentifier = cmdletContext.SecurityControlsConfiguration_EnabledSecurityControlIdentifier;
            }
            if (requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_EnabledSecurityControlIdentifier != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration.EnabledSecurityControlIdentifiers = requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_EnabledSecurityControlIdentifier;
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfigurationIsNull = false;
            }
            List<Amazon.SecurityHub.Model.SecurityControlCustomParameter> requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_SecurityControlCustomParameter = null;
            if (cmdletContext.SecurityControlsConfiguration_SecurityControlCustomParameter != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_SecurityControlCustomParameter = cmdletContext.SecurityControlsConfiguration_SecurityControlCustomParameter;
            }
            if (requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_SecurityControlCustomParameter != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration.SecurityControlCustomParameters = requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration_securityControlsConfiguration_SecurityControlCustomParameter;
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfigurationIsNull = false;
            }
             // determine if requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration should be set to null
            if (requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfigurationIsNull)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration = null;
            }
            if (requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration != null)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub.SecurityControlsConfiguration = requestConfigurationPolicy_configurationPolicy_SecurityHub_configurationPolicy_SecurityHub_SecurityControlsConfiguration;
                requestConfigurationPolicy_configurationPolicy_SecurityHubIsNull = false;
            }
             // determine if requestConfigurationPolicy_configurationPolicy_SecurityHub should be set to null
            if (requestConfigurationPolicy_configurationPolicy_SecurityHubIsNull)
            {
                requestConfigurationPolicy_configurationPolicy_SecurityHub = null;
            }
            if (requestConfigurationPolicy_configurationPolicy_SecurityHub != null)
            {
                request.ConfigurationPolicy.SecurityHub = requestConfigurationPolicy_configurationPolicy_SecurityHub;
                requestConfigurationPolicyIsNull = false;
            }
             // determine if request.ConfigurationPolicy should be set to null
            if (requestConfigurationPolicyIsNull)
            {
                request.ConfigurationPolicy = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.UpdatedReason != null)
            {
                request.UpdatedReason = cmdletContext.UpdatedReason;
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
        
        private Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateConfigurationPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateConfigurationPolicy");
            try
            {
                #if DESKTOP
                return client.UpdateConfigurationPolicy(request);
                #elif CORECLR
                return client.UpdateConfigurationPolicyAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> SecurityHub_EnabledStandardIdentifier { get; set; }
            public List<System.String> SecurityControlsConfiguration_DisabledSecurityControlIdentifier { get; set; }
            public List<System.String> SecurityControlsConfiguration_EnabledSecurityControlIdentifier { get; set; }
            public List<Amazon.SecurityHub.Model.SecurityControlCustomParameter> SecurityControlsConfiguration_SecurityControlCustomParameter { get; set; }
            public System.Boolean? SecurityHub_ServiceEnabled { get; set; }
            public System.String Description { get; set; }
            public System.String Identifier { get; set; }
            public System.String Name { get; set; }
            public System.String UpdatedReason { get; set; }
            public System.Func<Amazon.SecurityHub.Model.UpdateConfigurationPolicyResponse, UpdateSHUBConfigurationPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
