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
using Amazon.DataZone;
using Amazon.DataZone.Model;

namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Removes a policy grant.
    /// </summary>
    [Cmdlet("Remove", "DZPolicyGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon DataZone RemovePolicyGrant API operation.", Operation = new[] {"RemovePolicyGrant"}, SelectReturnType = typeof(Amazon.DataZone.Model.RemovePolicyGrantResponse))]
    [AWSCmdletOutput("None or Amazon.DataZone.Model.RemovePolicyGrantResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataZone.Model.RemovePolicyGrantResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveDZPolicyGrantCmdlet : AmazonDataZoneClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DomainUnitGrantFilter_AllDomainUnitsGrantFilter
        /// <summary>
        /// <para>
        /// <para>Specifies a grant filter containing all domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_DomainUnit_DomainUnitGrantFilter_AllDomainUnitsGrantFilter")]
        public Amazon.DataZone.Model.AllDomainUnitsGrantFilter DomainUnitGrantFilter_AllDomainUnitsGrantFilter { get; set; }
        #endregion
        
        #region Parameter User_AllUsersGrantFilter
        /// <summary>
        /// <para>
        /// <para>The all users grant filter of the user policy grant principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_User_AllUsersGrantFilter")]
        public Amazon.DataZone.Model.AllUsersGrantFilter User_AllUsersGrantFilter { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain where you want to remove a policy grant.</para>
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
        public System.String DomainIdentifier { get; set; }
        #endregion
        
        #region Parameter DomainUnitFilter_DomainUnit
        /// <summary>
        /// <para>
        /// <para>The domain unit ID to use in the filter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_Project_ProjectGrantFilter_DomainUnitFilter_DomainUnit")]
        public System.String DomainUnitFilter_DomainUnit { get; set; }
        #endregion
        
        #region Parameter DomainUnit_DomainUnitDesignation
        /// <summary>
        /// <para>
        /// <para>Specifes the designation of the domain unit users.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_DomainUnit_DomainUnitDesignation")]
        [AWSConstantClassSource("Amazon.DataZone.DomainUnitDesignation")]
        public Amazon.DataZone.DomainUnitDesignation DomainUnit_DomainUnitDesignation { get; set; }
        #endregion
        
        #region Parameter DomainUnit_DomainUnitIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_DomainUnit_DomainUnitIdentifier")]
        public System.String DomainUnit_DomainUnitIdentifier { get; set; }
        #endregion
        
        #region Parameter EntityIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the entity from which you want to remove a policy grant.</para>
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
        public System.String EntityIdentifier { get; set; }
        #endregion
        
        #region Parameter EntityType
        /// <summary>
        /// <para>
        /// <para>The type of the entity from which you want to remove a policy grant.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataZone.TargetEntityType")]
        public Amazon.DataZone.TargetEntityType EntityType { get; set; }
        #endregion
        
        #region Parameter Group_GroupIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID Of the group of the group principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_Group_GroupIdentifier")]
        public System.String Group_GroupIdentifier { get; set; }
        #endregion
        
        #region Parameter DomainUnitFilter_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_Project_ProjectGrantFilter_DomainUnitFilter_IncludeChildDomainUnits")]
        public System.Boolean? DomainUnitFilter_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The type of the policy that you want to remove.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DataZone.ManagedPolicyType")]
        public Amazon.DataZone.ManagedPolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter Project_ProjectDesignation
        /// <summary>
        /// <para>
        /// <para>The project designation of the project policy grant principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_Project_ProjectDesignation")]
        [AWSConstantClassSource("Amazon.DataZone.ProjectDesignation")]
        public Amazon.DataZone.ProjectDesignation Project_ProjectDesignation { get; set; }
        #endregion
        
        #region Parameter Project_ProjectIdentifier
        /// <summary>
        /// <para>
        /// <para>The project ID of the project policy grant principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_Project_ProjectIdentifier")]
        public System.String Project_ProjectIdentifier { get; set; }
        #endregion
        
        #region Parameter User_UserIdentifier
        /// <summary>
        /// <para>
        /// <para>The user ID of the user policy grant principal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Principal_User_UserIdentifier")]
        public System.String User_UserIdentifier { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that is provided to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.RemovePolicyGrantResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntityIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-DZPolicyGrant (RemovePolicyGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.RemovePolicyGrantResponse, RemoveDZPolicyGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DomainIdentifier = this.DomainIdentifier;
            #if MODULAR
            if (this.DomainIdentifier == null && ParameterWasBound(nameof(this.DomainIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntityIdentifier = this.EntityIdentifier;
            #if MODULAR
            if (this.EntityIdentifier == null && ParameterWasBound(nameof(this.EntityIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EntityType = this.EntityType;
            #if MODULAR
            if (this.EntityType == null && ParameterWasBound(nameof(this.EntityType)))
            {
                WriteWarning("You are passing $null as a value for parameter EntityType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyType = this.PolicyType;
            #if MODULAR
            if (this.PolicyType == null && ParameterWasBound(nameof(this.PolicyType)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DomainUnit_DomainUnitDesignation = this.DomainUnit_DomainUnitDesignation;
            context.DomainUnitGrantFilter_AllDomainUnitsGrantFilter = this.DomainUnitGrantFilter_AllDomainUnitsGrantFilter;
            context.DomainUnit_DomainUnitIdentifier = this.DomainUnit_DomainUnitIdentifier;
            context.Group_GroupIdentifier = this.Group_GroupIdentifier;
            context.Project_ProjectDesignation = this.Project_ProjectDesignation;
            context.DomainUnitFilter_DomainUnit = this.DomainUnitFilter_DomainUnit;
            context.DomainUnitFilter_IncludeChildDomainUnit = this.DomainUnitFilter_IncludeChildDomainUnit;
            context.Project_ProjectIdentifier = this.Project_ProjectIdentifier;
            context.User_AllUsersGrantFilter = this.User_AllUsersGrantFilter;
            context.User_UserIdentifier = this.User_UserIdentifier;
            
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
            var request = new Amazon.DataZone.Model.RemovePolicyGrantRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DomainIdentifier != null)
            {
                request.DomainIdentifier = cmdletContext.DomainIdentifier;
            }
            if (cmdletContext.EntityIdentifier != null)
            {
                request.EntityIdentifier = cmdletContext.EntityIdentifier;
            }
            if (cmdletContext.EntityType != null)
            {
                request.EntityType = cmdletContext.EntityType;
            }
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            
             // populate Principal
            var requestPrincipalIsNull = true;
            request.Principal = new Amazon.DataZone.Model.PolicyGrantPrincipal();
            Amazon.DataZone.Model.GroupPolicyGrantPrincipal requestPrincipal_principal_Group = null;
            
             // populate Group
            var requestPrincipal_principal_GroupIsNull = true;
            requestPrincipal_principal_Group = new Amazon.DataZone.Model.GroupPolicyGrantPrincipal();
            System.String requestPrincipal_principal_Group_group_GroupIdentifier = null;
            if (cmdletContext.Group_GroupIdentifier != null)
            {
                requestPrincipal_principal_Group_group_GroupIdentifier = cmdletContext.Group_GroupIdentifier;
            }
            if (requestPrincipal_principal_Group_group_GroupIdentifier != null)
            {
                requestPrincipal_principal_Group.GroupIdentifier = requestPrincipal_principal_Group_group_GroupIdentifier;
                requestPrincipal_principal_GroupIsNull = false;
            }
             // determine if requestPrincipal_principal_Group should be set to null
            if (requestPrincipal_principal_GroupIsNull)
            {
                requestPrincipal_principal_Group = null;
            }
            if (requestPrincipal_principal_Group != null)
            {
                request.Principal.Group = requestPrincipal_principal_Group;
                requestPrincipalIsNull = false;
            }
            Amazon.DataZone.Model.UserPolicyGrantPrincipal requestPrincipal_principal_User = null;
            
             // populate User
            var requestPrincipal_principal_UserIsNull = true;
            requestPrincipal_principal_User = new Amazon.DataZone.Model.UserPolicyGrantPrincipal();
            Amazon.DataZone.Model.AllUsersGrantFilter requestPrincipal_principal_User_user_AllUsersGrantFilter = null;
            if (cmdletContext.User_AllUsersGrantFilter != null)
            {
                requestPrincipal_principal_User_user_AllUsersGrantFilter = cmdletContext.User_AllUsersGrantFilter;
            }
            if (requestPrincipal_principal_User_user_AllUsersGrantFilter != null)
            {
                requestPrincipal_principal_User.AllUsersGrantFilter = requestPrincipal_principal_User_user_AllUsersGrantFilter;
                requestPrincipal_principal_UserIsNull = false;
            }
            System.String requestPrincipal_principal_User_user_UserIdentifier = null;
            if (cmdletContext.User_UserIdentifier != null)
            {
                requestPrincipal_principal_User_user_UserIdentifier = cmdletContext.User_UserIdentifier;
            }
            if (requestPrincipal_principal_User_user_UserIdentifier != null)
            {
                requestPrincipal_principal_User.UserIdentifier = requestPrincipal_principal_User_user_UserIdentifier;
                requestPrincipal_principal_UserIsNull = false;
            }
             // determine if requestPrincipal_principal_User should be set to null
            if (requestPrincipal_principal_UserIsNull)
            {
                requestPrincipal_principal_User = null;
            }
            if (requestPrincipal_principal_User != null)
            {
                request.Principal.User = requestPrincipal_principal_User;
                requestPrincipalIsNull = false;
            }
            Amazon.DataZone.Model.DomainUnitPolicyGrantPrincipal requestPrincipal_principal_DomainUnit = null;
            
             // populate DomainUnit
            var requestPrincipal_principal_DomainUnitIsNull = true;
            requestPrincipal_principal_DomainUnit = new Amazon.DataZone.Model.DomainUnitPolicyGrantPrincipal();
            Amazon.DataZone.DomainUnitDesignation requestPrincipal_principal_DomainUnit_domainUnit_DomainUnitDesignation = null;
            if (cmdletContext.DomainUnit_DomainUnitDesignation != null)
            {
                requestPrincipal_principal_DomainUnit_domainUnit_DomainUnitDesignation = cmdletContext.DomainUnit_DomainUnitDesignation;
            }
            if (requestPrincipal_principal_DomainUnit_domainUnit_DomainUnitDesignation != null)
            {
                requestPrincipal_principal_DomainUnit.DomainUnitDesignation = requestPrincipal_principal_DomainUnit_domainUnit_DomainUnitDesignation;
                requestPrincipal_principal_DomainUnitIsNull = false;
            }
            System.String requestPrincipal_principal_DomainUnit_domainUnit_DomainUnitIdentifier = null;
            if (cmdletContext.DomainUnit_DomainUnitIdentifier != null)
            {
                requestPrincipal_principal_DomainUnit_domainUnit_DomainUnitIdentifier = cmdletContext.DomainUnit_DomainUnitIdentifier;
            }
            if (requestPrincipal_principal_DomainUnit_domainUnit_DomainUnitIdentifier != null)
            {
                requestPrincipal_principal_DomainUnit.DomainUnitIdentifier = requestPrincipal_principal_DomainUnit_domainUnit_DomainUnitIdentifier;
                requestPrincipal_principal_DomainUnitIsNull = false;
            }
            Amazon.DataZone.Model.DomainUnitGrantFilter requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter = null;
            
             // populate DomainUnitGrantFilter
            var requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilterIsNull = true;
            requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter = new Amazon.DataZone.Model.DomainUnitGrantFilter();
            Amazon.DataZone.Model.AllDomainUnitsGrantFilter requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter_domainUnitGrantFilter_AllDomainUnitsGrantFilter = null;
            if (cmdletContext.DomainUnitGrantFilter_AllDomainUnitsGrantFilter != null)
            {
                requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter_domainUnitGrantFilter_AllDomainUnitsGrantFilter = cmdletContext.DomainUnitGrantFilter_AllDomainUnitsGrantFilter;
            }
            if (requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter_domainUnitGrantFilter_AllDomainUnitsGrantFilter != null)
            {
                requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter.AllDomainUnitsGrantFilter = requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter_domainUnitGrantFilter_AllDomainUnitsGrantFilter;
                requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilterIsNull = false;
            }
             // determine if requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter should be set to null
            if (requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilterIsNull)
            {
                requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter = null;
            }
            if (requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter != null)
            {
                requestPrincipal_principal_DomainUnit.DomainUnitGrantFilter = requestPrincipal_principal_DomainUnit_principal_DomainUnit_DomainUnitGrantFilter;
                requestPrincipal_principal_DomainUnitIsNull = false;
            }
             // determine if requestPrincipal_principal_DomainUnit should be set to null
            if (requestPrincipal_principal_DomainUnitIsNull)
            {
                requestPrincipal_principal_DomainUnit = null;
            }
            if (requestPrincipal_principal_DomainUnit != null)
            {
                request.Principal.DomainUnit = requestPrincipal_principal_DomainUnit;
                requestPrincipalIsNull = false;
            }
            Amazon.DataZone.Model.ProjectPolicyGrantPrincipal requestPrincipal_principal_Project = null;
            
             // populate Project
            var requestPrincipal_principal_ProjectIsNull = true;
            requestPrincipal_principal_Project = new Amazon.DataZone.Model.ProjectPolicyGrantPrincipal();
            Amazon.DataZone.ProjectDesignation requestPrincipal_principal_Project_project_ProjectDesignation = null;
            if (cmdletContext.Project_ProjectDesignation != null)
            {
                requestPrincipal_principal_Project_project_ProjectDesignation = cmdletContext.Project_ProjectDesignation;
            }
            if (requestPrincipal_principal_Project_project_ProjectDesignation != null)
            {
                requestPrincipal_principal_Project.ProjectDesignation = requestPrincipal_principal_Project_project_ProjectDesignation;
                requestPrincipal_principal_ProjectIsNull = false;
            }
            System.String requestPrincipal_principal_Project_project_ProjectIdentifier = null;
            if (cmdletContext.Project_ProjectIdentifier != null)
            {
                requestPrincipal_principal_Project_project_ProjectIdentifier = cmdletContext.Project_ProjectIdentifier;
            }
            if (requestPrincipal_principal_Project_project_ProjectIdentifier != null)
            {
                requestPrincipal_principal_Project.ProjectIdentifier = requestPrincipal_principal_Project_project_ProjectIdentifier;
                requestPrincipal_principal_ProjectIsNull = false;
            }
            Amazon.DataZone.Model.ProjectGrantFilter requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter = null;
            
             // populate ProjectGrantFilter
            var requestPrincipal_principal_Project_principal_Project_ProjectGrantFilterIsNull = true;
            requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter = new Amazon.DataZone.Model.ProjectGrantFilter();
            Amazon.DataZone.Model.DomainUnitFilterForProject requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter = null;
            
             // populate DomainUnitFilter
            var requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilterIsNull = true;
            requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter = new Amazon.DataZone.Model.DomainUnitFilterForProject();
            System.String requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter_domainUnitFilter_DomainUnit = null;
            if (cmdletContext.DomainUnitFilter_DomainUnit != null)
            {
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter_domainUnitFilter_DomainUnit = cmdletContext.DomainUnitFilter_DomainUnit;
            }
            if (requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter_domainUnitFilter_DomainUnit != null)
            {
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter.DomainUnit = requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter_domainUnitFilter_DomainUnit;
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilterIsNull = false;
            }
            System.Boolean? requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter_domainUnitFilter_IncludeChildDomainUnit = null;
            if (cmdletContext.DomainUnitFilter_IncludeChildDomainUnit != null)
            {
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter_domainUnitFilter_IncludeChildDomainUnit = cmdletContext.DomainUnitFilter_IncludeChildDomainUnit.Value;
            }
            if (requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter_domainUnitFilter_IncludeChildDomainUnit != null)
            {
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter.IncludeChildDomainUnits = requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter_domainUnitFilter_IncludeChildDomainUnit.Value;
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilterIsNull = false;
            }
             // determine if requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter should be set to null
            if (requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilterIsNull)
            {
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter = null;
            }
            if (requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter != null)
            {
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter.DomainUnitFilter = requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter_principal_Project_ProjectGrantFilter_DomainUnitFilter;
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilterIsNull = false;
            }
             // determine if requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter should be set to null
            if (requestPrincipal_principal_Project_principal_Project_ProjectGrantFilterIsNull)
            {
                requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter = null;
            }
            if (requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter != null)
            {
                requestPrincipal_principal_Project.ProjectGrantFilter = requestPrincipal_principal_Project_principal_Project_ProjectGrantFilter;
                requestPrincipal_principal_ProjectIsNull = false;
            }
             // determine if requestPrincipal_principal_Project should be set to null
            if (requestPrincipal_principal_ProjectIsNull)
            {
                requestPrincipal_principal_Project = null;
            }
            if (requestPrincipal_principal_Project != null)
            {
                request.Principal.Project = requestPrincipal_principal_Project;
                requestPrincipalIsNull = false;
            }
             // determine if request.Principal should be set to null
            if (requestPrincipalIsNull)
            {
                request.Principal = null;
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
        
        private Amazon.DataZone.Model.RemovePolicyGrantResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.RemovePolicyGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "RemovePolicyGrant");
            try
            {
                return client.RemovePolicyGrantAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DomainIdentifier { get; set; }
            public System.String EntityIdentifier { get; set; }
            public Amazon.DataZone.TargetEntityType EntityType { get; set; }
            public Amazon.DataZone.ManagedPolicyType PolicyType { get; set; }
            public Amazon.DataZone.DomainUnitDesignation DomainUnit_DomainUnitDesignation { get; set; }
            public Amazon.DataZone.Model.AllDomainUnitsGrantFilter DomainUnitGrantFilter_AllDomainUnitsGrantFilter { get; set; }
            public System.String DomainUnit_DomainUnitIdentifier { get; set; }
            public System.String Group_GroupIdentifier { get; set; }
            public Amazon.DataZone.ProjectDesignation Project_ProjectDesignation { get; set; }
            public System.String DomainUnitFilter_DomainUnit { get; set; }
            public System.Boolean? DomainUnitFilter_IncludeChildDomainUnit { get; set; }
            public System.String Project_ProjectIdentifier { get; set; }
            public Amazon.DataZone.Model.AllUsersGrantFilter User_AllUsersGrantFilter { get; set; }
            public System.String User_UserIdentifier { get; set; }
            public System.Func<Amazon.DataZone.Model.RemovePolicyGrantResponse, RemoveDZPolicyGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
