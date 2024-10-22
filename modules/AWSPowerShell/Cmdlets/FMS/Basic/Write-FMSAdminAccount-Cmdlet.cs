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
using Amazon.FMS;
using Amazon.FMS.Model;

namespace Amazon.PowerShell.Cmdlets.FMS
{
    /// <summary>
    /// Creates or updates an Firewall Manager administrator account. The account must be
    /// a member of the organization that was onboarded to Firewall Manager by <a>AssociateAdminAccount</a>.
    /// Only the organization's management account can create an Firewall Manager administrator
    /// account. When you create an Firewall Manager administrator account, the service checks
    /// to see if the account is already a delegated administrator within Organizations. If
    /// the account isn't a delegated administrator, Firewall Manager calls Organizations
    /// to delegate the account within Organizations. For more information about administrator
    /// accounts within Organizations, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts.html">Managing
    /// the Amazon Web Services Accounts in Your Organization</a>.
    /// </summary>
    [Cmdlet("Write", "FMSAdminAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Firewall Management Service PutAdminAccount API operation.", Operation = new[] {"PutAdminAccount"}, SelectReturnType = typeof(Amazon.FMS.Model.PutAdminAccountResponse))]
    [AWSCmdletOutput("None or Amazon.FMS.Model.PutAdminAccountResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.FMS.Model.PutAdminAccountResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteFMSAdminAccountCmdlet : AmazonFMSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccountScope_Account
        /// <summary>
        /// <para>
        /// <para>The list of accounts within the organization that the specified Firewall Manager administrator
        /// either can or cannot apply policies to, based on the value of <c>ExcludeSpecifiedAccounts</c>.
        /// If <c>ExcludeSpecifiedAccounts</c> is set to <c>true</c>, then the Firewall Manager
        /// administrator can apply policies to all members of the organization except for the
        /// accounts in this list. If <c>ExcludeSpecifiedAccounts</c> is set to <c>false</c>,
        /// then the Firewall Manager administrator can only apply policies to the accounts in
        /// this list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_AccountScope_Accounts")]
        public System.String[] AccountScope_Account { get; set; }
        #endregion
        
        #region Parameter AdminAccount
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID to add as an Firewall Manager administrator account.
        /// The account must be a member of the organization that was onboarded to Firewall Manager
        /// by <a>AssociateAdminAccount</a>. For more information about Organizations, see <a href="https://docs.aws.amazon.com/organizations/latest/userguide/orgs_manage_accounts.html">Managing
        /// the Amazon Web Services Accounts in Your Organization</a>.</para>
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
        public System.String AdminAccount { get; set; }
        #endregion
        
        #region Parameter AccountScope_AllAccountsEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean value that indicates if the administrator can apply policies to all accounts
        /// within an organization. If true, the administrator can apply policies to all accounts
        /// within the organization. You can either enable management of all accounts through
        /// this operation, or you can specify a list of accounts to manage in <c>AccountScope$Accounts</c>.
        /// You cannot specify both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_AccountScope_AllAccountsEnabled")]
        public System.Boolean? AccountScope_AllAccountsEnabled { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitScope_AllOrganizationalUnitsEnabled
        /// <summary>
        /// <para>
        /// <para>A boolean value that indicates if the administrator can apply policies to all OUs
        /// within an organization. If true, the administrator can manage all OUs within the organization.
        /// You can either enable management of all OUs through this operation, or you can specify
        /// OUs to manage in <c>OrganizationalUnitScope$OrganizationalUnits</c>. You cannot specify
        /// both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_OrganizationalUnitScope_AllOrganizationalUnitsEnabled")]
        public System.Boolean? OrganizationalUnitScope_AllOrganizationalUnitsEnabled { get; set; }
        #endregion
        
        #region Parameter PolicyTypeScope_AllPolicyTypesEnabled
        /// <summary>
        /// <para>
        /// <para>Allows the specified Firewall Manager administrator to manage all Firewall Manager
        /// policy types, except for third-party policy types. Third-party policy types can only
        /// be managed by the Firewall Manager default administrator.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_PolicyTypeScope_AllPolicyTypesEnabled")]
        public System.Boolean? PolicyTypeScope_AllPolicyTypesEnabled { get; set; }
        #endregion
        
        #region Parameter RegionScope_AllRegionsEnabled
        /// <summary>
        /// <para>
        /// <para>Allows the specified Firewall Manager administrator to manage all Amazon Web Services
        /// Regions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_RegionScope_AllRegionsEnabled")]
        public System.Boolean? RegionScope_AllRegionsEnabled { get; set; }
        #endregion
        
        #region Parameter AccountScope_ExcludeSpecifiedAccount
        /// <summary>
        /// <para>
        /// <para>A boolean value that excludes the accounts in <c>AccountScope$Accounts</c> from the
        /// administrator's scope. If true, the Firewall Manager administrator can apply policies
        /// to all members of the organization except for the accounts listed in <c>AccountScope$Accounts</c>.
        /// You can either specify a list of accounts to exclude by <c>AccountScope$Accounts</c>,
        /// or you can enable management of all accounts by <c>AccountScope$AllAccountsEnabled</c>.
        /// You cannot specify both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_AccountScope_ExcludeSpecifiedAccounts")]
        public System.Boolean? AccountScope_ExcludeSpecifiedAccount { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitScope_ExcludeSpecifiedOrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>A boolean value that excludes the OUs in <c>OrganizationalUnitScope$OrganizationalUnits</c>
        /// from the administrator's scope. If true, the Firewall Manager administrator can apply
        /// policies to all OUs in the organization except for the OUs listed in <c>OrganizationalUnitScope$OrganizationalUnits</c>.
        /// You can either specify a list of OUs to exclude by <c>OrganizationalUnitScope$OrganizationalUnits</c>,
        /// or you can enable management of all OUs by <c>OrganizationalUnitScope$AllOrganizationalUnitsEnabled</c>.
        /// You cannot specify both.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_OrganizationalUnitScope_ExcludeSpecifiedOrganizationalUnits")]
        public System.Boolean? OrganizationalUnitScope_ExcludeSpecifiedOrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitScope_OrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>The list of OUs within the organization that the specified Firewall Manager administrator
        /// either can or cannot apply policies to, based on the value of <c>OrganizationalUnitScope$ExcludeSpecifiedOrganizationalUnits</c>.
        /// If <c>OrganizationalUnitScope$ExcludeSpecifiedOrganizationalUnits</c> is set to <c>true</c>,
        /// then the Firewall Manager administrator can apply policies to all OUs in the organization
        /// except for the OUs in this list. If <c>OrganizationalUnitScope$ExcludeSpecifiedOrganizationalUnits</c>
        /// is set to <c>false</c>, then the Firewall Manager administrator can only apply policies
        /// to the OUs in this list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_OrganizationalUnitScope_OrganizationalUnits")]
        public System.String[] OrganizationalUnitScope_OrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter PolicyTypeScope_PolicyType
        /// <summary>
        /// <para>
        /// <para>The list of policy types that the specified Firewall Manager administrator can manage.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_PolicyTypeScope_PolicyTypes")]
        public System.String[] PolicyTypeScope_PolicyType { get; set; }
        #endregion
        
        #region Parameter RegionScope_Region
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Regions that the specified Firewall Manager administrator
        /// can perform actions in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_RegionScope_Regions")]
        public System.String[] RegionScope_Region { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.FMS.Model.PutAdminAccountResponse).
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AdminAccount), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-FMSAdminAccount (PutAdminAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.FMS.Model.PutAdminAccountResponse, WriteFMSAdminAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AdminAccount = this.AdminAccount;
            #if MODULAR
            if (this.AdminAccount == null && ParameterWasBound(nameof(this.AdminAccount)))
            {
                WriteWarning("You are passing $null as a value for parameter AdminAccount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.AccountScope_Account != null)
            {
                context.AccountScope_Account = new List<System.String>(this.AccountScope_Account);
            }
            context.AccountScope_AllAccountsEnabled = this.AccountScope_AllAccountsEnabled;
            context.AccountScope_ExcludeSpecifiedAccount = this.AccountScope_ExcludeSpecifiedAccount;
            context.OrganizationalUnitScope_AllOrganizationalUnitsEnabled = this.OrganizationalUnitScope_AllOrganizationalUnitsEnabled;
            context.OrganizationalUnitScope_ExcludeSpecifiedOrganizationalUnit = this.OrganizationalUnitScope_ExcludeSpecifiedOrganizationalUnit;
            if (this.OrganizationalUnitScope_OrganizationalUnit != null)
            {
                context.OrganizationalUnitScope_OrganizationalUnit = new List<System.String>(this.OrganizationalUnitScope_OrganizationalUnit);
            }
            context.PolicyTypeScope_AllPolicyTypesEnabled = this.PolicyTypeScope_AllPolicyTypesEnabled;
            if (this.PolicyTypeScope_PolicyType != null)
            {
                context.PolicyTypeScope_PolicyType = new List<System.String>(this.PolicyTypeScope_PolicyType);
            }
            context.RegionScope_AllRegionsEnabled = this.RegionScope_AllRegionsEnabled;
            if (this.RegionScope_Region != null)
            {
                context.RegionScope_Region = new List<System.String>(this.RegionScope_Region);
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
            var request = new Amazon.FMS.Model.PutAdminAccountRequest();
            
            if (cmdletContext.AdminAccount != null)
            {
                request.AdminAccount = cmdletContext.AdminAccount;
            }
            
             // populate AdminScope
            var requestAdminScopeIsNull = true;
            request.AdminScope = new Amazon.FMS.Model.AdminScope();
            Amazon.FMS.Model.PolicyTypeScope requestAdminScope_adminScope_PolicyTypeScope = null;
            
             // populate PolicyTypeScope
            var requestAdminScope_adminScope_PolicyTypeScopeIsNull = true;
            requestAdminScope_adminScope_PolicyTypeScope = new Amazon.FMS.Model.PolicyTypeScope();
            System.Boolean? requestAdminScope_adminScope_PolicyTypeScope_policyTypeScope_AllPolicyTypesEnabled = null;
            if (cmdletContext.PolicyTypeScope_AllPolicyTypesEnabled != null)
            {
                requestAdminScope_adminScope_PolicyTypeScope_policyTypeScope_AllPolicyTypesEnabled = cmdletContext.PolicyTypeScope_AllPolicyTypesEnabled.Value;
            }
            if (requestAdminScope_adminScope_PolicyTypeScope_policyTypeScope_AllPolicyTypesEnabled != null)
            {
                requestAdminScope_adminScope_PolicyTypeScope.AllPolicyTypesEnabled = requestAdminScope_adminScope_PolicyTypeScope_policyTypeScope_AllPolicyTypesEnabled.Value;
                requestAdminScope_adminScope_PolicyTypeScopeIsNull = false;
            }
            List<System.String> requestAdminScope_adminScope_PolicyTypeScope_policyTypeScope_PolicyType = null;
            if (cmdletContext.PolicyTypeScope_PolicyType != null)
            {
                requestAdminScope_adminScope_PolicyTypeScope_policyTypeScope_PolicyType = cmdletContext.PolicyTypeScope_PolicyType;
            }
            if (requestAdminScope_adminScope_PolicyTypeScope_policyTypeScope_PolicyType != null)
            {
                requestAdminScope_adminScope_PolicyTypeScope.PolicyTypes = requestAdminScope_adminScope_PolicyTypeScope_policyTypeScope_PolicyType;
                requestAdminScope_adminScope_PolicyTypeScopeIsNull = false;
            }
             // determine if requestAdminScope_adminScope_PolicyTypeScope should be set to null
            if (requestAdminScope_adminScope_PolicyTypeScopeIsNull)
            {
                requestAdminScope_adminScope_PolicyTypeScope = null;
            }
            if (requestAdminScope_adminScope_PolicyTypeScope != null)
            {
                request.AdminScope.PolicyTypeScope = requestAdminScope_adminScope_PolicyTypeScope;
                requestAdminScopeIsNull = false;
            }
            Amazon.FMS.Model.RegionScope requestAdminScope_adminScope_RegionScope = null;
            
             // populate RegionScope
            var requestAdminScope_adminScope_RegionScopeIsNull = true;
            requestAdminScope_adminScope_RegionScope = new Amazon.FMS.Model.RegionScope();
            System.Boolean? requestAdminScope_adminScope_RegionScope_regionScope_AllRegionsEnabled = null;
            if (cmdletContext.RegionScope_AllRegionsEnabled != null)
            {
                requestAdminScope_adminScope_RegionScope_regionScope_AllRegionsEnabled = cmdletContext.RegionScope_AllRegionsEnabled.Value;
            }
            if (requestAdminScope_adminScope_RegionScope_regionScope_AllRegionsEnabled != null)
            {
                requestAdminScope_adminScope_RegionScope.AllRegionsEnabled = requestAdminScope_adminScope_RegionScope_regionScope_AllRegionsEnabled.Value;
                requestAdminScope_adminScope_RegionScopeIsNull = false;
            }
            List<System.String> requestAdminScope_adminScope_RegionScope_regionScope_Region = null;
            if (cmdletContext.RegionScope_Region != null)
            {
                requestAdminScope_adminScope_RegionScope_regionScope_Region = cmdletContext.RegionScope_Region;
            }
            if (requestAdminScope_adminScope_RegionScope_regionScope_Region != null)
            {
                requestAdminScope_adminScope_RegionScope.Regions = requestAdminScope_adminScope_RegionScope_regionScope_Region;
                requestAdminScope_adminScope_RegionScopeIsNull = false;
            }
             // determine if requestAdminScope_adminScope_RegionScope should be set to null
            if (requestAdminScope_adminScope_RegionScopeIsNull)
            {
                requestAdminScope_adminScope_RegionScope = null;
            }
            if (requestAdminScope_adminScope_RegionScope != null)
            {
                request.AdminScope.RegionScope = requestAdminScope_adminScope_RegionScope;
                requestAdminScopeIsNull = false;
            }
            Amazon.FMS.Model.AccountScope requestAdminScope_adminScope_AccountScope = null;
            
             // populate AccountScope
            var requestAdminScope_adminScope_AccountScopeIsNull = true;
            requestAdminScope_adminScope_AccountScope = new Amazon.FMS.Model.AccountScope();
            List<System.String> requestAdminScope_adminScope_AccountScope_accountScope_Account = null;
            if (cmdletContext.AccountScope_Account != null)
            {
                requestAdminScope_adminScope_AccountScope_accountScope_Account = cmdletContext.AccountScope_Account;
            }
            if (requestAdminScope_adminScope_AccountScope_accountScope_Account != null)
            {
                requestAdminScope_adminScope_AccountScope.Accounts = requestAdminScope_adminScope_AccountScope_accountScope_Account;
                requestAdminScope_adminScope_AccountScopeIsNull = false;
            }
            System.Boolean? requestAdminScope_adminScope_AccountScope_accountScope_AllAccountsEnabled = null;
            if (cmdletContext.AccountScope_AllAccountsEnabled != null)
            {
                requestAdminScope_adminScope_AccountScope_accountScope_AllAccountsEnabled = cmdletContext.AccountScope_AllAccountsEnabled.Value;
            }
            if (requestAdminScope_adminScope_AccountScope_accountScope_AllAccountsEnabled != null)
            {
                requestAdminScope_adminScope_AccountScope.AllAccountsEnabled = requestAdminScope_adminScope_AccountScope_accountScope_AllAccountsEnabled.Value;
                requestAdminScope_adminScope_AccountScopeIsNull = false;
            }
            System.Boolean? requestAdminScope_adminScope_AccountScope_accountScope_ExcludeSpecifiedAccount = null;
            if (cmdletContext.AccountScope_ExcludeSpecifiedAccount != null)
            {
                requestAdminScope_adminScope_AccountScope_accountScope_ExcludeSpecifiedAccount = cmdletContext.AccountScope_ExcludeSpecifiedAccount.Value;
            }
            if (requestAdminScope_adminScope_AccountScope_accountScope_ExcludeSpecifiedAccount != null)
            {
                requestAdminScope_adminScope_AccountScope.ExcludeSpecifiedAccounts = requestAdminScope_adminScope_AccountScope_accountScope_ExcludeSpecifiedAccount.Value;
                requestAdminScope_adminScope_AccountScopeIsNull = false;
            }
             // determine if requestAdminScope_adminScope_AccountScope should be set to null
            if (requestAdminScope_adminScope_AccountScopeIsNull)
            {
                requestAdminScope_adminScope_AccountScope = null;
            }
            if (requestAdminScope_adminScope_AccountScope != null)
            {
                request.AdminScope.AccountScope = requestAdminScope_adminScope_AccountScope;
                requestAdminScopeIsNull = false;
            }
            Amazon.FMS.Model.OrganizationalUnitScope requestAdminScope_adminScope_OrganizationalUnitScope = null;
            
             // populate OrganizationalUnitScope
            var requestAdminScope_adminScope_OrganizationalUnitScopeIsNull = true;
            requestAdminScope_adminScope_OrganizationalUnitScope = new Amazon.FMS.Model.OrganizationalUnitScope();
            System.Boolean? requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_AllOrganizationalUnitsEnabled = null;
            if (cmdletContext.OrganizationalUnitScope_AllOrganizationalUnitsEnabled != null)
            {
                requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_AllOrganizationalUnitsEnabled = cmdletContext.OrganizationalUnitScope_AllOrganizationalUnitsEnabled.Value;
            }
            if (requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_AllOrganizationalUnitsEnabled != null)
            {
                requestAdminScope_adminScope_OrganizationalUnitScope.AllOrganizationalUnitsEnabled = requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_AllOrganizationalUnitsEnabled.Value;
                requestAdminScope_adminScope_OrganizationalUnitScopeIsNull = false;
            }
            System.Boolean? requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_ExcludeSpecifiedOrganizationalUnit = null;
            if (cmdletContext.OrganizationalUnitScope_ExcludeSpecifiedOrganizationalUnit != null)
            {
                requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_ExcludeSpecifiedOrganizationalUnit = cmdletContext.OrganizationalUnitScope_ExcludeSpecifiedOrganizationalUnit.Value;
            }
            if (requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_ExcludeSpecifiedOrganizationalUnit != null)
            {
                requestAdminScope_adminScope_OrganizationalUnitScope.ExcludeSpecifiedOrganizationalUnits = requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_ExcludeSpecifiedOrganizationalUnit.Value;
                requestAdminScope_adminScope_OrganizationalUnitScopeIsNull = false;
            }
            List<System.String> requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_OrganizationalUnit = null;
            if (cmdletContext.OrganizationalUnitScope_OrganizationalUnit != null)
            {
                requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_OrganizationalUnit = cmdletContext.OrganizationalUnitScope_OrganizationalUnit;
            }
            if (requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_OrganizationalUnit != null)
            {
                requestAdminScope_adminScope_OrganizationalUnitScope.OrganizationalUnits = requestAdminScope_adminScope_OrganizationalUnitScope_organizationalUnitScope_OrganizationalUnit;
                requestAdminScope_adminScope_OrganizationalUnitScopeIsNull = false;
            }
             // determine if requestAdminScope_adminScope_OrganizationalUnitScope should be set to null
            if (requestAdminScope_adminScope_OrganizationalUnitScopeIsNull)
            {
                requestAdminScope_adminScope_OrganizationalUnitScope = null;
            }
            if (requestAdminScope_adminScope_OrganizationalUnitScope != null)
            {
                request.AdminScope.OrganizationalUnitScope = requestAdminScope_adminScope_OrganizationalUnitScope;
                requestAdminScopeIsNull = false;
            }
             // determine if request.AdminScope should be set to null
            if (requestAdminScopeIsNull)
            {
                request.AdminScope = null;
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
        
        private Amazon.FMS.Model.PutAdminAccountResponse CallAWSServiceOperation(IAmazonFMS client, Amazon.FMS.Model.PutAdminAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Firewall Management Service", "PutAdminAccount");
            try
            {
                #if DESKTOP
                return client.PutAdminAccount(request);
                #elif CORECLR
                return client.PutAdminAccountAsync(request).GetAwaiter().GetResult();
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
            public System.String AdminAccount { get; set; }
            public List<System.String> AccountScope_Account { get; set; }
            public System.Boolean? AccountScope_AllAccountsEnabled { get; set; }
            public System.Boolean? AccountScope_ExcludeSpecifiedAccount { get; set; }
            public System.Boolean? OrganizationalUnitScope_AllOrganizationalUnitsEnabled { get; set; }
            public System.Boolean? OrganizationalUnitScope_ExcludeSpecifiedOrganizationalUnit { get; set; }
            public List<System.String> OrganizationalUnitScope_OrganizationalUnit { get; set; }
            public System.Boolean? PolicyTypeScope_AllPolicyTypesEnabled { get; set; }
            public List<System.String> PolicyTypeScope_PolicyType { get; set; }
            public System.Boolean? RegionScope_AllRegionsEnabled { get; set; }
            public List<System.String> RegionScope_Region { get; set; }
            public System.Func<Amazon.FMS.Model.PutAdminAccountResponse, WriteFMSAdminAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
