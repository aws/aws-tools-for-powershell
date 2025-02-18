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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Updates the configuration of your organization in Security Hub. Only the Security
    /// Hub administrator account can invoke this operation.
    /// </summary>
    [Cmdlet("Update", "SHUBOrganizationConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Security Hub UpdateOrganizationConfiguration API operation.", Operation = new[] {"UpdateOrganizationConfiguration"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.UpdateOrganizationConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.SecurityHub.Model.UpdateOrganizationConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SecurityHub.Model.UpdateOrganizationConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSHUBOrganizationConfigurationCmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AutoEnable
        /// <summary>
        /// <para>
        /// <para>Whether to automatically enable Security Hub in new member accounts when they join
        /// the organization.</para><para>If set to <c>true</c>, then Security Hub is automatically enabled in new accounts.
        /// If set to <c>false</c>, then Security Hub isn't enabled in new accounts automatically.
        /// The default value is <c>false</c>.</para><para>If the <c>ConfigurationType</c> of your organization is set to <c>CENTRAL</c>, then
        /// this field is set to <c>false</c> and can't be changed in the home Region and linked
        /// Regions. However, in that case, the delegated administrator can create a configuration
        /// policy in which Security Hub is enabled and associate the policy with new organization
        /// accounts.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? AutoEnable { get; set; }
        #endregion
        
        #region Parameter AutoEnableStandard
        /// <summary>
        /// <para>
        /// <para>Whether to automatically enable Security Hub <a href="https://docs.aws.amazon.com/securityhub/latest/userguide/securityhub-standards-enable-disable.html">default
        /// standards</a> in new member accounts when they join the organization.</para><para>The default value of this parameter is equal to <c>DEFAULT</c>.</para><para>If equal to <c>DEFAULT</c>, then Security Hub default standards are automatically
        /// enabled for new member accounts. If equal to <c>NONE</c>, then default standards are
        /// not automatically enabled for new member accounts.</para><para>If the <c>ConfigurationType</c> of your organization is set to <c>CENTRAL</c>, then
        /// this field is set to <c>NONE</c> and can't be changed in the home Region and linked
        /// Regions. However, in that case, the delegated administrator can create a configuration
        /// policy in which specific security standards are enabled and associate the policy with
        /// new organization accounts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AutoEnableStandards")]
        [AWSConstantClassSource("Amazon.SecurityHub.AutoEnableStandards")]
        public Amazon.SecurityHub.AutoEnableStandards AutoEnableStandard { get; set; }
        #endregion
        
        #region Parameter OrganizationConfiguration_ConfigurationType
        /// <summary>
        /// <para>
        /// <para> Indicates whether the organization uses local or central configuration. </para><para>If you use local configuration, the Security Hub delegated administrator can set <c>AutoEnable</c>
        /// to <c>true</c> and <c>AutoEnableStandards</c> to <c>DEFAULT</c>. This automatically
        /// enables Security Hub and default security standards in new organization accounts.
        /// These new account settings must be set separately in each Amazon Web Services Region,
        /// and settings may be different in each Region. </para><para> If you use central configuration, the delegated administrator can create configuration
        /// policies. Configuration policies can be used to configure Security Hub, security standards,
        /// and security controls in multiple accounts and Regions. If you want new organization
        /// accounts to use a specific configuration, you can create a configuration policy and
        /// associate it with the root or specific organizational units (OUs). New accounts will
        /// inherit the policy from the root or their assigned OU. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.OrganizationConfigurationConfigurationType")]
        public Amazon.SecurityHub.OrganizationConfigurationConfigurationType OrganizationConfiguration_ConfigurationType { get; set; }
        #endregion
        
        #region Parameter OrganizationConfiguration_Status
        /// <summary>
        /// <para>
        /// <para> Describes whether central configuration could be enabled as the <c>ConfigurationType</c>
        /// for the organization. If your <c>ConfigurationType</c> is local configuration, then
        /// the value of <c>Status</c> is always <c>ENABLED</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SecurityHub.OrganizationConfigurationStatus")]
        public Amazon.SecurityHub.OrganizationConfigurationStatus OrganizationConfiguration_Status { get; set; }
        #endregion
        
        #region Parameter OrganizationConfiguration_StatusMessage
        /// <summary>
        /// <para>
        /// <para> Provides an explanation if the value of <c>Status</c> is equal to <c>FAILED</c> when
        /// <c>ConfigurationType</c> is equal to <c>CENTRAL</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationConfiguration_StatusMessage { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.UpdateOrganizationConfigurationResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AutoEnable), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SHUBOrganizationConfiguration (UpdateOrganizationConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.UpdateOrganizationConfigurationResponse, UpdateSHUBOrganizationConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AutoEnable = this.AutoEnable;
            #if MODULAR
            if (this.AutoEnable == null && ParameterWasBound(nameof(this.AutoEnable)))
            {
                WriteWarning("You are passing $null as a value for parameter AutoEnable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoEnableStandard = this.AutoEnableStandard;
            context.OrganizationConfiguration_ConfigurationType = this.OrganizationConfiguration_ConfigurationType;
            context.OrganizationConfiguration_Status = this.OrganizationConfiguration_Status;
            context.OrganizationConfiguration_StatusMessage = this.OrganizationConfiguration_StatusMessage;
            
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
            var request = new Amazon.SecurityHub.Model.UpdateOrganizationConfigurationRequest();
            
            if (cmdletContext.AutoEnable != null)
            {
                request.AutoEnable = cmdletContext.AutoEnable.Value;
            }
            if (cmdletContext.AutoEnableStandard != null)
            {
                request.AutoEnableStandards = cmdletContext.AutoEnableStandard;
            }
            
             // populate OrganizationConfiguration
            var requestOrganizationConfigurationIsNull = true;
            request.OrganizationConfiguration = new Amazon.SecurityHub.Model.OrganizationConfiguration();
            Amazon.SecurityHub.OrganizationConfigurationConfigurationType requestOrganizationConfiguration_organizationConfiguration_ConfigurationType = null;
            if (cmdletContext.OrganizationConfiguration_ConfigurationType != null)
            {
                requestOrganizationConfiguration_organizationConfiguration_ConfigurationType = cmdletContext.OrganizationConfiguration_ConfigurationType;
            }
            if (requestOrganizationConfiguration_organizationConfiguration_ConfigurationType != null)
            {
                request.OrganizationConfiguration.ConfigurationType = requestOrganizationConfiguration_organizationConfiguration_ConfigurationType;
                requestOrganizationConfigurationIsNull = false;
            }
            Amazon.SecurityHub.OrganizationConfigurationStatus requestOrganizationConfiguration_organizationConfiguration_Status = null;
            if (cmdletContext.OrganizationConfiguration_Status != null)
            {
                requestOrganizationConfiguration_organizationConfiguration_Status = cmdletContext.OrganizationConfiguration_Status;
            }
            if (requestOrganizationConfiguration_organizationConfiguration_Status != null)
            {
                request.OrganizationConfiguration.Status = requestOrganizationConfiguration_organizationConfiguration_Status;
                requestOrganizationConfigurationIsNull = false;
            }
            System.String requestOrganizationConfiguration_organizationConfiguration_StatusMessage = null;
            if (cmdletContext.OrganizationConfiguration_StatusMessage != null)
            {
                requestOrganizationConfiguration_organizationConfiguration_StatusMessage = cmdletContext.OrganizationConfiguration_StatusMessage;
            }
            if (requestOrganizationConfiguration_organizationConfiguration_StatusMessage != null)
            {
                request.OrganizationConfiguration.StatusMessage = requestOrganizationConfiguration_organizationConfiguration_StatusMessage;
                requestOrganizationConfigurationIsNull = false;
            }
             // determine if request.OrganizationConfiguration should be set to null
            if (requestOrganizationConfigurationIsNull)
            {
                request.OrganizationConfiguration = null;
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
        
        private Amazon.SecurityHub.Model.UpdateOrganizationConfigurationResponse CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.UpdateOrganizationConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "UpdateOrganizationConfiguration");
            try
            {
                return client.UpdateOrganizationConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AutoEnable { get; set; }
            public Amazon.SecurityHub.AutoEnableStandards AutoEnableStandard { get; set; }
            public Amazon.SecurityHub.OrganizationConfigurationConfigurationType OrganizationConfiguration_ConfigurationType { get; set; }
            public Amazon.SecurityHub.OrganizationConfigurationStatus OrganizationConfiguration_Status { get; set; }
            public System.String OrganizationConfiguration_StatusMessage { get; set; }
            public System.Func<Amazon.SecurityHub.Model.UpdateOrganizationConfigurationResponse, UpdateSHUBOrganizationConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
