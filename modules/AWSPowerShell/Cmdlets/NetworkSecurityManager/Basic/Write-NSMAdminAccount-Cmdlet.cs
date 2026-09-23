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
using Amazon.NetworkSecurityManager;
using Amazon.NetworkSecurityManager.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.NSM
{
    /// <summary>
    /// Sets the AWS account that serves as an AWS Network Security Manager administrator
    /// account, and optionally configures the scope of resources that the administrator can
    /// manage.
    /// 
    ///  
    /// <para>
    /// You can't set an administrator account again immediately after you remove it, or while
    /// the service creates its service-linked role. Retry the request after a few minutes.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "NSMAdminAccount", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NetworkSecurityManager.Model.AdminAccountDetails")]
    [AWSCmdlet("Calls the AWS Network Security Manager Customer API PutAdminAccount API operation.", Operation = new[] {"PutAdminAccount"}, SelectReturnType = typeof(Amazon.NetworkSecurityManager.Model.PutAdminAccountResponse))]
    [AWSCmdletOutput("Amazon.NetworkSecurityManager.Model.AdminAccountDetails or Amazon.NetworkSecurityManager.Model.PutAdminAccountResponse",
        "This cmdlet returns an Amazon.NetworkSecurityManager.Model.AdminAccountDetails object.",
        "The service call response (type Amazon.NetworkSecurityManager.Model.PutAdminAccountResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteNSMAdminAccountCmdlet : AmazonNetworkSecurityManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The AWS account ID to set as the AWS Network Security Manager administrator account.</para>
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
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AdminScope_ScopeFilter_ExcludeOnly_Account
        /// <summary>
        /// <para>
        /// <para>The AWS accounts in the selection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_ScopeFilter_ExcludeOnly_Accounts")]
        public System.String[] AdminScope_ScopeFilter_ExcludeOnly_Account { get; set; }
        #endregion
        
        #region Parameter AdminScope_ScopeFilter_IncludeOnly_Account
        /// <summary>
        /// <para>
        /// <para>The AWS accounts in the selection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_ScopeFilter_IncludeOnly_Accounts")]
        public System.String[] AdminScope_ScopeFilter_IncludeOnly_Account { get; set; }
        #endregion
        
        #region Parameter AdminScope_FirewallTypeScope_AllFirewallTypesEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether the administrator can manage all firewall types, except for third-party
        /// firewall types.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AdminScope_FirewallTypeScope_AllFirewallTypesEnabled { get; set; }
        #endregion
        
        #region Parameter AdminScope_FirewallTypeScope_FirewallType
        /// <summary>
        /// <para>
        /// <para>The list of firewall types that the administrator can manage.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_FirewallTypeScope_FirewallTypes")]
        public System.String[] AdminScope_FirewallTypeScope_FirewallType { get; set; }
        #endregion
        
        #region Parameter AdminScope_ScopeFilter_IncludeAll
        /// <summary>
        /// <para>
        /// <para>All accounts and organizational units are in scope.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.NetworkSecurityManager.Model.Unit AdminScope_ScopeFilter_IncludeAll { get; set; }
        #endregion
        
        #region Parameter AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>The AWS Organizations organizational units (OUs) in the selection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnits")]
        public System.String[] AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnit
        /// <summary>
        /// <para>
        /// <para>The AWS Organizations organizational units (OUs) in the selection.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnits")]
        public System.String[] AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnit { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority to assign to the administrator account.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? Priority { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AdminAccountDetails'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NetworkSecurityManager.Model.PutAdminAccountResponse).
        /// Specifying the name of a property of type Amazon.NetworkSecurityManager.Model.PutAdminAccountResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AdminAccountDetails";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AccountId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-NSMAdminAccount (PutAdminAccount)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NetworkSecurityManager.Model.PutAdminAccountResponse, WriteNSMAdminAccountCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            #if MODULAR
            if (this.AccountId == null && ParameterWasBound(nameof(this.AccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AdminScope_FirewallTypeScope_AllFirewallTypesEnabled = this.AdminScope_FirewallTypeScope_AllFirewallTypesEnabled;
            if (this.AdminScope_FirewallTypeScope_FirewallType != null)
            {
                context.AdminScope_FirewallTypeScope_FirewallType = new List<System.String>(this.AdminScope_FirewallTypeScope_FirewallType);
            }
            if (this.AdminScope_ScopeFilter_ExcludeOnly_Account != null)
            {
                context.AdminScope_ScopeFilter_ExcludeOnly_Account = new List<System.String>(this.AdminScope_ScopeFilter_ExcludeOnly_Account);
            }
            if (this.AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit != null)
            {
                context.AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit = new List<System.String>(this.AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit);
            }
            context.AdminScope_ScopeFilter_IncludeAll = this.AdminScope_ScopeFilter_IncludeAll;
            if (this.AdminScope_ScopeFilter_IncludeOnly_Account != null)
            {
                context.AdminScope_ScopeFilter_IncludeOnly_Account = new List<System.String>(this.AdminScope_ScopeFilter_IncludeOnly_Account);
            }
            if (this.AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnit != null)
            {
                context.AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnit = new List<System.String>(this.AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnit);
            }
            context.Priority = this.Priority;
            #if MODULAR
            if (this.Priority == null && ParameterWasBound(nameof(this.Priority)))
            {
                WriteWarning("You are passing $null as a value for parameter Priority which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NetworkSecurityManager.Model.PutAdminAccountRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate AdminScope
            var requestAdminScopeIsNull = true;
            request.AdminScope = new Amazon.NetworkSecurityManager.Model.AdminScopeInput();
            Amazon.NetworkSecurityManager.Model.AdminFirewallTypeScope requestAdminScope_adminScope_FirewallTypeScope = null;
            
             // populate FirewallTypeScope
            var requestAdminScope_adminScope_FirewallTypeScopeIsNull = true;
            requestAdminScope_adminScope_FirewallTypeScope = new Amazon.NetworkSecurityManager.Model.AdminFirewallTypeScope();
            System.Boolean? requestAdminScope_adminScope_FirewallTypeScope_adminScope_FirewallTypeScope_AllFirewallTypesEnabled = null;
            if (cmdletContext.AdminScope_FirewallTypeScope_AllFirewallTypesEnabled != null)
            {
                requestAdminScope_adminScope_FirewallTypeScope_adminScope_FirewallTypeScope_AllFirewallTypesEnabled = cmdletContext.AdminScope_FirewallTypeScope_AllFirewallTypesEnabled.Value;
            }
            if (requestAdminScope_adminScope_FirewallTypeScope_adminScope_FirewallTypeScope_AllFirewallTypesEnabled != null)
            {
                requestAdminScope_adminScope_FirewallTypeScope.AllFirewallTypesEnabled = requestAdminScope_adminScope_FirewallTypeScope_adminScope_FirewallTypeScope_AllFirewallTypesEnabled.Value;
                requestAdminScope_adminScope_FirewallTypeScopeIsNull = false;
            }
            List<System.String> requestAdminScope_adminScope_FirewallTypeScope_adminScope_FirewallTypeScope_FirewallType = null;
            if (cmdletContext.AdminScope_FirewallTypeScope_FirewallType != null)
            {
                requestAdminScope_adminScope_FirewallTypeScope_adminScope_FirewallTypeScope_FirewallType = cmdletContext.AdminScope_FirewallTypeScope_FirewallType;
            }
            if (requestAdminScope_adminScope_FirewallTypeScope_adminScope_FirewallTypeScope_FirewallType != null)
            {
                requestAdminScope_adminScope_FirewallTypeScope.FirewallTypes = requestAdminScope_adminScope_FirewallTypeScope_adminScope_FirewallTypeScope_FirewallType;
                requestAdminScope_adminScope_FirewallTypeScopeIsNull = false;
            }
             // determine if requestAdminScope_adminScope_FirewallTypeScope should be set to null
            if (requestAdminScope_adminScope_FirewallTypeScopeIsNull)
            {
                requestAdminScope_adminScope_FirewallTypeScope = null;
            }
            if (requestAdminScope_adminScope_FirewallTypeScope != null)
            {
                request.AdminScope.FirewallTypeScope = requestAdminScope_adminScope_FirewallTypeScope;
                requestAdminScopeIsNull = false;
            }
            Amazon.NetworkSecurityManager.Model.AdminScopeFilterInput requestAdminScope_adminScope_ScopeFilter = null;
            
             // populate ScopeFilter
            var requestAdminScope_adminScope_ScopeFilterIsNull = true;
            requestAdminScope_adminScope_ScopeFilter = new Amazon.NetworkSecurityManager.Model.AdminScopeFilterInput();
            Amazon.NetworkSecurityManager.Model.Unit requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeAll = null;
            if (cmdletContext.AdminScope_ScopeFilter_IncludeAll != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeAll = cmdletContext.AdminScope_ScopeFilter_IncludeAll;
            }
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeAll != null)
            {
                requestAdminScope_adminScope_ScopeFilter.IncludeAll = requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeAll;
                requestAdminScope_adminScope_ScopeFilterIsNull = false;
            }
            Amazon.NetworkSecurityManager.Model.AdminScopeSelectionInput requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly = null;
            
             // populate ExcludeOnly
            var requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnlyIsNull = true;
            requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly = new Amazon.NetworkSecurityManager.Model.AdminScopeSelectionInput();
            List<System.String> requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly_adminScope_ScopeFilter_ExcludeOnly_Account = null;
            if (cmdletContext.AdminScope_ScopeFilter_ExcludeOnly_Account != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly_adminScope_ScopeFilter_ExcludeOnly_Account = cmdletContext.AdminScope_ScopeFilter_ExcludeOnly_Account;
            }
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly_adminScope_ScopeFilter_ExcludeOnly_Account != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly.Accounts = requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly_adminScope_ScopeFilter_ExcludeOnly_Account;
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnlyIsNull = false;
            }
            List<System.String> requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly_adminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit = null;
            if (cmdletContext.AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly_adminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit = cmdletContext.AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit;
            }
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly_adminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly.OrganizationalUnits = requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly_adminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit;
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnlyIsNull = false;
            }
             // determine if requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly should be set to null
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnlyIsNull)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly = null;
            }
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly != null)
            {
                requestAdminScope_adminScope_ScopeFilter.ExcludeOnly = requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_ExcludeOnly;
                requestAdminScope_adminScope_ScopeFilterIsNull = false;
            }
            Amazon.NetworkSecurityManager.Model.AdminScopeSelectionInput requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly = null;
            
             // populate IncludeOnly
            var requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnlyIsNull = true;
            requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly = new Amazon.NetworkSecurityManager.Model.AdminScopeSelectionInput();
            List<System.String> requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly_adminScope_ScopeFilter_IncludeOnly_Account = null;
            if (cmdletContext.AdminScope_ScopeFilter_IncludeOnly_Account != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly_adminScope_ScopeFilter_IncludeOnly_Account = cmdletContext.AdminScope_ScopeFilter_IncludeOnly_Account;
            }
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly_adminScope_ScopeFilter_IncludeOnly_Account != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly.Accounts = requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly_adminScope_ScopeFilter_IncludeOnly_Account;
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnlyIsNull = false;
            }
            List<System.String> requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly_adminScope_ScopeFilter_IncludeOnly_OrganizationalUnit = null;
            if (cmdletContext.AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnit != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly_adminScope_ScopeFilter_IncludeOnly_OrganizationalUnit = cmdletContext.AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnit;
            }
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly_adminScope_ScopeFilter_IncludeOnly_OrganizationalUnit != null)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly.OrganizationalUnits = requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly_adminScope_ScopeFilter_IncludeOnly_OrganizationalUnit;
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnlyIsNull = false;
            }
             // determine if requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly should be set to null
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnlyIsNull)
            {
                requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly = null;
            }
            if (requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly != null)
            {
                requestAdminScope_adminScope_ScopeFilter.IncludeOnly = requestAdminScope_adminScope_ScopeFilter_adminScope_ScopeFilter_IncludeOnly;
                requestAdminScope_adminScope_ScopeFilterIsNull = false;
            }
             // determine if requestAdminScope_adminScope_ScopeFilter should be set to null
            if (requestAdminScope_adminScope_ScopeFilterIsNull)
            {
                requestAdminScope_adminScope_ScopeFilter = null;
            }
            if (requestAdminScope_adminScope_ScopeFilter != null)
            {
                request.AdminScope.ScopeFilter = requestAdminScope_adminScope_ScopeFilter;
                requestAdminScopeIsNull = false;
            }
             // determine if request.AdminScope should be set to null
            if (requestAdminScopeIsNull)
            {
                request.AdminScope = null;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority.Value;
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
        
        private Amazon.NetworkSecurityManager.Model.PutAdminAccountResponse CallAWSServiceOperation(IAmazonNetworkSecurityManager client, Amazon.NetworkSecurityManager.Model.PutAdminAccountRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Network Security Manager Customer API", "PutAdminAccount");
            try
            {
                return client.PutAdminAccountAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.Boolean? AdminScope_FirewallTypeScope_AllFirewallTypesEnabled { get; set; }
            public List<System.String> AdminScope_FirewallTypeScope_FirewallType { get; set; }
            public List<System.String> AdminScope_ScopeFilter_ExcludeOnly_Account { get; set; }
            public List<System.String> AdminScope_ScopeFilter_ExcludeOnly_OrganizationalUnit { get; set; }
            public Amazon.NetworkSecurityManager.Model.Unit AdminScope_ScopeFilter_IncludeAll { get; set; }
            public List<System.String> AdminScope_ScopeFilter_IncludeOnly_Account { get; set; }
            public List<System.String> AdminScope_ScopeFilter_IncludeOnly_OrganizationalUnit { get; set; }
            public System.Int32? Priority { get; set; }
            public System.Func<Amazon.NetworkSecurityManager.Model.PutAdminAccountResponse, WriteNSMAdminAccountCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AdminAccountDetails;
        }
        
    }
}
