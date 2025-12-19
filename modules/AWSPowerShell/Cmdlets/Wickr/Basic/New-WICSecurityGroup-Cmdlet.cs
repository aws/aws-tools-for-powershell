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
using Amazon.Wickr;
using Amazon.Wickr.Model;

namespace Amazon.PowerShell.Cmdlets.WIC
{
    /// <summary>
    /// Creates a new security group in a Wickr network. Security groups allow you to organize
    /// users and control their permissions, features, and security settings.
    /// </summary>
    [Cmdlet("New", "WICSecurityGroup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Wickr.Model.SecurityGroup")]
    [AWSCmdlet("Calls the AWS Wickr Admin API CreateSecurityGroup API operation.", Operation = new[] {"CreateSecurityGroup"}, SelectReturnType = typeof(Amazon.Wickr.Model.CreateSecurityGroupResponse))]
    [AWSCmdletOutput("Amazon.Wickr.Model.SecurityGroup or Amazon.Wickr.Model.CreateSecurityGroupResponse",
        "This cmdlet returns an Amazon.Wickr.Model.SecurityGroup object.",
        "The service call response (type Amazon.Wickr.Model.CreateSecurityGroupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewWICSecurityGroupCmdlet : AmazonWickrClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SecurityGroupSettings_EnableGuestFederation
        /// <summary>
        /// <para>
        /// <para>Guest users let you work with people outside your organization that only have limited
        /// access to Wickr. Only valid when federationMode is set to Global.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_EnableGuestFederation { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_EnableRestrictedGlobalFederation
        /// <summary>
        /// <para>
        /// <para>Enables restricted global federation to limit communication to specific permitted
        /// networks only. Requires globalFederation to be enabled.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_EnableRestrictedGlobalFederation { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_FederationMode
        /// <summary>
        /// <para>
        /// <para>The local federation mode. Values: 0 (none), 1 (federated - all networks), 2 (restricted
        /// - only permitted networks).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_FederationMode { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_GlobalFederation
        /// <summary>
        /// <para>
        /// <para>Allow users to securely federate with all Amazon Web Services Wickr networks and Amazon
        /// Web Services Enterprise networks.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? SecurityGroupSettings_GlobalFederation { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_LockoutThreshold
        /// <summary>
        /// <para>
        /// <para>The number of failed password attempts before a user account is locked out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SecurityGroupSettings_LockoutThreshold { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the new security group.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NetworkId
        /// <summary>
        /// <para>
        /// <para>The ID of the Wickr network where the security group will be created.</para>
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
        public System.String NetworkId { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PermittedNetwork
        /// <summary>
        /// <para>
        /// <para>A list of network IDs that are permitted for local federation when federation mode
        /// is set to restricted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_PermittedNetworks")]
        public System.String[] SecurityGroupSettings_PermittedNetwork { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PermittedWickrAwsNetwork
        /// <summary>
        /// <para>
        /// <para>A list of permitted Amazon Web Services Wickr networks for restricted global federation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_PermittedWickrAwsNetworks")]
        public Amazon.Wickr.Model.WickrAwsNetworks[] SecurityGroupSettings_PermittedWickrAwsNetwork { get; set; }
        #endregion
        
        #region Parameter SecurityGroupSettings_PermittedWickrEnterpriseNetwork
        /// <summary>
        /// <para>
        /// <para>A list of permitted Wickr Enterprise networks for restricted global federation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecurityGroupSettings_PermittedWickrEnterpriseNetworks")]
        public Amazon.Wickr.Model.PermittedWickrEnterpriseNetwork[] SecurityGroupSettings_PermittedWickrEnterpriseNetwork { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for this request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SecurityGroup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Wickr.Model.CreateSecurityGroupResponse).
        /// Specifying the name of a property of type Amazon.Wickr.Model.CreateSecurityGroupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SecurityGroup";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.NetworkId),
                nameof(this.Name)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WICSecurityGroup (CreateSecurityGroup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Wickr.Model.CreateSecurityGroupResponse, NewWICSecurityGroupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkId = this.NetworkId;
            #if MODULAR
            if (this.NetworkId == null && ParameterWasBound(nameof(this.NetworkId)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SecurityGroupSettings_EnableGuestFederation = this.SecurityGroupSettings_EnableGuestFederation;
            context.SecurityGroupSettings_EnableRestrictedGlobalFederation = this.SecurityGroupSettings_EnableRestrictedGlobalFederation;
            context.SecurityGroupSettings_FederationMode = this.SecurityGroupSettings_FederationMode;
            context.SecurityGroupSettings_GlobalFederation = this.SecurityGroupSettings_GlobalFederation;
            context.SecurityGroupSettings_LockoutThreshold = this.SecurityGroupSettings_LockoutThreshold;
            if (this.SecurityGroupSettings_PermittedNetwork != null)
            {
                context.SecurityGroupSettings_PermittedNetwork = new List<System.String>(this.SecurityGroupSettings_PermittedNetwork);
            }
            if (this.SecurityGroupSettings_PermittedWickrAwsNetwork != null)
            {
                context.SecurityGroupSettings_PermittedWickrAwsNetwork = new List<Amazon.Wickr.Model.WickrAwsNetworks>(this.SecurityGroupSettings_PermittedWickrAwsNetwork);
            }
            if (this.SecurityGroupSettings_PermittedWickrEnterpriseNetwork != null)
            {
                context.SecurityGroupSettings_PermittedWickrEnterpriseNetwork = new List<Amazon.Wickr.Model.PermittedWickrEnterpriseNetwork>(this.SecurityGroupSettings_PermittedWickrEnterpriseNetwork);
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
            var request = new Amazon.Wickr.Model.CreateSecurityGroupRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.NetworkId != null)
            {
                request.NetworkId = cmdletContext.NetworkId;
            }
            
             // populate SecurityGroupSettings
            var requestSecurityGroupSettingsIsNull = true;
            request.SecurityGroupSettings = new Amazon.Wickr.Model.SecurityGroupSettingsRequest();
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableGuestFederation = null;
            if (cmdletContext.SecurityGroupSettings_EnableGuestFederation != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableGuestFederation = cmdletContext.SecurityGroupSettings_EnableGuestFederation.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableGuestFederation != null)
            {
                request.SecurityGroupSettings.EnableGuestFederation = requestSecurityGroupSettings_securityGroupSettings_EnableGuestFederation.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_EnableRestrictedGlobalFederation = null;
            if (cmdletContext.SecurityGroupSettings_EnableRestrictedGlobalFederation != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_EnableRestrictedGlobalFederation = cmdletContext.SecurityGroupSettings_EnableRestrictedGlobalFederation.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_EnableRestrictedGlobalFederation != null)
            {
                request.SecurityGroupSettings.EnableRestrictedGlobalFederation = requestSecurityGroupSettings_securityGroupSettings_EnableRestrictedGlobalFederation.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_FederationMode = null;
            if (cmdletContext.SecurityGroupSettings_FederationMode != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_FederationMode = cmdletContext.SecurityGroupSettings_FederationMode.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_FederationMode != null)
            {
                request.SecurityGroupSettings.FederationMode = requestSecurityGroupSettings_securityGroupSettings_FederationMode.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Boolean? requestSecurityGroupSettings_securityGroupSettings_GlobalFederation = null;
            if (cmdletContext.SecurityGroupSettings_GlobalFederation != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_GlobalFederation = cmdletContext.SecurityGroupSettings_GlobalFederation.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_GlobalFederation != null)
            {
                request.SecurityGroupSettings.GlobalFederation = requestSecurityGroupSettings_securityGroupSettings_GlobalFederation.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            System.Int32? requestSecurityGroupSettings_securityGroupSettings_LockoutThreshold = null;
            if (cmdletContext.SecurityGroupSettings_LockoutThreshold != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_LockoutThreshold = cmdletContext.SecurityGroupSettings_LockoutThreshold.Value;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_LockoutThreshold != null)
            {
                request.SecurityGroupSettings.LockoutThreshold = requestSecurityGroupSettings_securityGroupSettings_LockoutThreshold.Value;
                requestSecurityGroupSettingsIsNull = false;
            }
            List<System.String> requestSecurityGroupSettings_securityGroupSettings_PermittedNetwork = null;
            if (cmdletContext.SecurityGroupSettings_PermittedNetwork != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PermittedNetwork = cmdletContext.SecurityGroupSettings_PermittedNetwork;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PermittedNetwork != null)
            {
                request.SecurityGroupSettings.PermittedNetworks = requestSecurityGroupSettings_securityGroupSettings_PermittedNetwork;
                requestSecurityGroupSettingsIsNull = false;
            }
            List<Amazon.Wickr.Model.WickrAwsNetworks> requestSecurityGroupSettings_securityGroupSettings_PermittedWickrAwsNetwork = null;
            if (cmdletContext.SecurityGroupSettings_PermittedWickrAwsNetwork != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PermittedWickrAwsNetwork = cmdletContext.SecurityGroupSettings_PermittedWickrAwsNetwork;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PermittedWickrAwsNetwork != null)
            {
                request.SecurityGroupSettings.PermittedWickrAwsNetworks = requestSecurityGroupSettings_securityGroupSettings_PermittedWickrAwsNetwork;
                requestSecurityGroupSettingsIsNull = false;
            }
            List<Amazon.Wickr.Model.PermittedWickrEnterpriseNetwork> requestSecurityGroupSettings_securityGroupSettings_PermittedWickrEnterpriseNetwork = null;
            if (cmdletContext.SecurityGroupSettings_PermittedWickrEnterpriseNetwork != null)
            {
                requestSecurityGroupSettings_securityGroupSettings_PermittedWickrEnterpriseNetwork = cmdletContext.SecurityGroupSettings_PermittedWickrEnterpriseNetwork;
            }
            if (requestSecurityGroupSettings_securityGroupSettings_PermittedWickrEnterpriseNetwork != null)
            {
                request.SecurityGroupSettings.PermittedWickrEnterpriseNetworks = requestSecurityGroupSettings_securityGroupSettings_PermittedWickrEnterpriseNetwork;
                requestSecurityGroupSettingsIsNull = false;
            }
             // determine if request.SecurityGroupSettings should be set to null
            if (requestSecurityGroupSettingsIsNull)
            {
                request.SecurityGroupSettings = null;
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
        
        private Amazon.Wickr.Model.CreateSecurityGroupResponse CallAWSServiceOperation(IAmazonWickr client, Amazon.Wickr.Model.CreateSecurityGroupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Wickr Admin API", "CreateSecurityGroup");
            try
            {
                #if DESKTOP
                return client.CreateSecurityGroup(request);
                #elif CORECLR
                return client.CreateSecurityGroupAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String NetworkId { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableGuestFederation { get; set; }
            public System.Boolean? SecurityGroupSettings_EnableRestrictedGlobalFederation { get; set; }
            public System.Int32? SecurityGroupSettings_FederationMode { get; set; }
            public System.Boolean? SecurityGroupSettings_GlobalFederation { get; set; }
            public System.Int32? SecurityGroupSettings_LockoutThreshold { get; set; }
            public List<System.String> SecurityGroupSettings_PermittedNetwork { get; set; }
            public List<Amazon.Wickr.Model.WickrAwsNetworks> SecurityGroupSettings_PermittedWickrAwsNetwork { get; set; }
            public List<Amazon.Wickr.Model.PermittedWickrEnterpriseNetwork> SecurityGroupSettings_PermittedWickrEnterpriseNetwork { get; set; }
            public System.Func<Amazon.Wickr.Model.CreateSecurityGroupResponse, NewWICSecurityGroupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SecurityGroup;
        }
        
    }
}
