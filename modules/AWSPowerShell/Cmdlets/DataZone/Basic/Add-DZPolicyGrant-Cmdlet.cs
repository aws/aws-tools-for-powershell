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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.DZ
{
    /// <summary>
    /// Adds a policy grant (an authorization policy) to a specified entity, including domain
    /// units, environment blueprint configurations, or environment profiles.
    /// </summary>
    [Cmdlet("Add", "DZPolicyGrant", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon DataZone AddPolicyGrant API operation.", Operation = new[] {"AddPolicyGrant"}, SelectReturnType = typeof(Amazon.DataZone.Model.AddPolicyGrantResponse))]
    [AWSCmdletOutput("None or Amazon.DataZone.Model.AddPolicyGrantResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.DataZone.Model.AddPolicyGrantResponse) be returned by specifying '-Select *'."
    )]
    public partial class AddDZPolicyGrantCmdlet : AmazonDataZoneClientCmdlet, IExecutor
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
        
        #region Parameter Detail_CreateEnvironment
        /// <summary>
        /// <para>
        /// <para>Specifies that this is a create environment policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.Unit Detail_CreateEnvironment { get; set; }
        #endregion
        
        #region Parameter Detail_CreateEnvironmentFromBlueprint
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.Unit Detail_CreateEnvironmentFromBlueprint { get; set; }
        #endregion
        
        #region Parameter Detail_DelegateCreateEnvironmentProfile
        /// <summary>
        /// <para>
        /// <para>Specifies that this is the delegation of the create environment profile policy.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.DataZone.Model.Unit Detail_DelegateCreateEnvironmentProfile { get; set; }
        #endregion
        
        #region Parameter DomainIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID of the domain where you want to add a policy grant.</para>
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
        
        #region Parameter CreateEnvironmentProfile_DomainUnitId
        /// <summary>
        /// <para>
        /// <para>The ID of the domain unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_CreateEnvironmentProfile_DomainUnitId")]
        public System.String CreateEnvironmentProfile_DomainUnitId { get; set; }
        #endregion
        
        #region Parameter UseAssetType_DomainUnitId
        /// <summary>
        /// <para>
        /// <para>The ID of the domain unit.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_UseAssetType_DomainUnitId")]
        public System.String UseAssetType_DomainUnitId { get; set; }
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
        /// <para>The ID of the entity (resource) to which you want to add a policy grant.</para>
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
        /// <para>The type of entity (resource) to which the grant is added.</para>
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
        
        #region Parameter AddToProjectMemberPool_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy grant is applied to child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_AddToProjectMemberPool_IncludeChildDomainUnits")]
        public System.Boolean? AddToProjectMemberPool_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter CreateAssetType_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy grant is applied to child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_CreateAssetType_IncludeChildDomainUnits")]
        public System.Boolean? CreateAssetType_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter CreateDomainUnit_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy grant is applied to child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_CreateDomainUnit_IncludeChildDomainUnits")]
        public System.Boolean? CreateDomainUnit_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter CreateFormType_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy grant is applied to child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_CreateFormType_IncludeChildDomainUnits")]
        public System.Boolean? CreateFormType_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter CreateGlossary_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy grant is applied to child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_CreateGlossary_IncludeChildDomainUnits")]
        public System.Boolean? CreateGlossary_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter CreateProject_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy grant is applied to child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_CreateProject_IncludeChildDomainUnits")]
        public System.Boolean? CreateProject_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter CreateProjectFromProjectProfile_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether to include child domain units when creating a project from project
        /// profile policy grant details</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_CreateProjectFromProjectProfile_IncludeChildDomainUnits")]
        public System.Boolean? CreateProjectFromProjectProfile_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter OverrideDomainUnitOwners_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy is inherited by child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_OverrideDomainUnitOwners_IncludeChildDomainUnits")]
        public System.Boolean? OverrideDomainUnitOwners_IncludeChildDomainUnit { get; set; }
        #endregion
        
        #region Parameter OverrideProjectOwners_IncludeChildDomainUnit
        /// <summary>
        /// <para>
        /// <para>Specifies whether the policy is inherited by child domain units.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_OverrideProjectOwners_IncludeChildDomainUnits")]
        public System.Boolean? OverrideProjectOwners_IncludeChildDomainUnit { get; set; }
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
        /// <para>The type of policy that you want to grant.</para>
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
        
        #region Parameter CreateProjectFromProjectProfile_ProjectProfile
        /// <summary>
        /// <para>
        /// <para>Specifies project profiles when creating a project from project profile policy grant
        /// details</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Detail_CreateProjectFromProjectProfile_ProjectProfiles")]
        public System.String[] CreateProjectFromProjectProfile_ProjectProfile { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DataZone.Model.AddPolicyGrantResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EntityIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DZPolicyGrant (AddPolicyGrant)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DataZone.Model.AddPolicyGrantResponse, AddDZPolicyGrantCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.AddToProjectMemberPool_IncludeChildDomainUnit = this.AddToProjectMemberPool_IncludeChildDomainUnit;
            context.CreateAssetType_IncludeChildDomainUnit = this.CreateAssetType_IncludeChildDomainUnit;
            context.CreateDomainUnit_IncludeChildDomainUnit = this.CreateDomainUnit_IncludeChildDomainUnit;
            context.Detail_CreateEnvironment = this.Detail_CreateEnvironment;
            context.Detail_CreateEnvironmentFromBlueprint = this.Detail_CreateEnvironmentFromBlueprint;
            context.CreateEnvironmentProfile_DomainUnitId = this.CreateEnvironmentProfile_DomainUnitId;
            context.CreateFormType_IncludeChildDomainUnit = this.CreateFormType_IncludeChildDomainUnit;
            context.CreateGlossary_IncludeChildDomainUnit = this.CreateGlossary_IncludeChildDomainUnit;
            context.CreateProject_IncludeChildDomainUnit = this.CreateProject_IncludeChildDomainUnit;
            context.CreateProjectFromProjectProfile_IncludeChildDomainUnit = this.CreateProjectFromProjectProfile_IncludeChildDomainUnit;
            if (this.CreateProjectFromProjectProfile_ProjectProfile != null)
            {
                context.CreateProjectFromProjectProfile_ProjectProfile = new List<System.String>(this.CreateProjectFromProjectProfile_ProjectProfile);
            }
            context.Detail_DelegateCreateEnvironmentProfile = this.Detail_DelegateCreateEnvironmentProfile;
            context.OverrideDomainUnitOwners_IncludeChildDomainUnit = this.OverrideDomainUnitOwners_IncludeChildDomainUnit;
            context.OverrideProjectOwners_IncludeChildDomainUnit = this.OverrideProjectOwners_IncludeChildDomainUnit;
            context.UseAssetType_DomainUnitId = this.UseAssetType_DomainUnitId;
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
            var request = new Amazon.DataZone.Model.AddPolicyGrantRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Detail
            request.Detail = new Amazon.DataZone.Model.PolicyGrantDetail();
            Amazon.DataZone.Model.Unit requestDetail_detail_CreateEnvironment = null;
            if (cmdletContext.Detail_CreateEnvironment != null)
            {
                requestDetail_detail_CreateEnvironment = cmdletContext.Detail_CreateEnvironment;
            }
            if (requestDetail_detail_CreateEnvironment != null)
            {
                request.Detail.CreateEnvironment = requestDetail_detail_CreateEnvironment;
            }
            Amazon.DataZone.Model.Unit requestDetail_detail_CreateEnvironmentFromBlueprint = null;
            if (cmdletContext.Detail_CreateEnvironmentFromBlueprint != null)
            {
                requestDetail_detail_CreateEnvironmentFromBlueprint = cmdletContext.Detail_CreateEnvironmentFromBlueprint;
            }
            if (requestDetail_detail_CreateEnvironmentFromBlueprint != null)
            {
                request.Detail.CreateEnvironmentFromBlueprint = requestDetail_detail_CreateEnvironmentFromBlueprint;
            }
            Amazon.DataZone.Model.Unit requestDetail_detail_DelegateCreateEnvironmentProfile = null;
            if (cmdletContext.Detail_DelegateCreateEnvironmentProfile != null)
            {
                requestDetail_detail_DelegateCreateEnvironmentProfile = cmdletContext.Detail_DelegateCreateEnvironmentProfile;
            }
            if (requestDetail_detail_DelegateCreateEnvironmentProfile != null)
            {
                request.Detail.DelegateCreateEnvironmentProfile = requestDetail_detail_DelegateCreateEnvironmentProfile;
            }
            Amazon.DataZone.Model.AddToProjectMemberPoolPolicyGrantDetail requestDetail_detail_AddToProjectMemberPool = null;
            
             // populate AddToProjectMemberPool
            var requestDetail_detail_AddToProjectMemberPoolIsNull = true;
            requestDetail_detail_AddToProjectMemberPool = new Amazon.DataZone.Model.AddToProjectMemberPoolPolicyGrantDetail();
            System.Boolean? requestDetail_detail_AddToProjectMemberPool_addToProjectMemberPool_IncludeChildDomainUnit = null;
            if (cmdletContext.AddToProjectMemberPool_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_AddToProjectMemberPool_addToProjectMemberPool_IncludeChildDomainUnit = cmdletContext.AddToProjectMemberPool_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_AddToProjectMemberPool_addToProjectMemberPool_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_AddToProjectMemberPool.IncludeChildDomainUnits = requestDetail_detail_AddToProjectMemberPool_addToProjectMemberPool_IncludeChildDomainUnit.Value;
                requestDetail_detail_AddToProjectMemberPoolIsNull = false;
            }
             // determine if requestDetail_detail_AddToProjectMemberPool should be set to null
            if (requestDetail_detail_AddToProjectMemberPoolIsNull)
            {
                requestDetail_detail_AddToProjectMemberPool = null;
            }
            if (requestDetail_detail_AddToProjectMemberPool != null)
            {
                request.Detail.AddToProjectMemberPool = requestDetail_detail_AddToProjectMemberPool;
            }
            Amazon.DataZone.Model.CreateAssetTypePolicyGrantDetail requestDetail_detail_CreateAssetType = null;
            
             // populate CreateAssetType
            var requestDetail_detail_CreateAssetTypeIsNull = true;
            requestDetail_detail_CreateAssetType = new Amazon.DataZone.Model.CreateAssetTypePolicyGrantDetail();
            System.Boolean? requestDetail_detail_CreateAssetType_createAssetType_IncludeChildDomainUnit = null;
            if (cmdletContext.CreateAssetType_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateAssetType_createAssetType_IncludeChildDomainUnit = cmdletContext.CreateAssetType_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_CreateAssetType_createAssetType_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateAssetType.IncludeChildDomainUnits = requestDetail_detail_CreateAssetType_createAssetType_IncludeChildDomainUnit.Value;
                requestDetail_detail_CreateAssetTypeIsNull = false;
            }
             // determine if requestDetail_detail_CreateAssetType should be set to null
            if (requestDetail_detail_CreateAssetTypeIsNull)
            {
                requestDetail_detail_CreateAssetType = null;
            }
            if (requestDetail_detail_CreateAssetType != null)
            {
                request.Detail.CreateAssetType = requestDetail_detail_CreateAssetType;
            }
            Amazon.DataZone.Model.CreateDomainUnitPolicyGrantDetail requestDetail_detail_CreateDomainUnit = null;
            
             // populate CreateDomainUnit
            var requestDetail_detail_CreateDomainUnitIsNull = true;
            requestDetail_detail_CreateDomainUnit = new Amazon.DataZone.Model.CreateDomainUnitPolicyGrantDetail();
            System.Boolean? requestDetail_detail_CreateDomainUnit_createDomainUnit_IncludeChildDomainUnit = null;
            if (cmdletContext.CreateDomainUnit_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateDomainUnit_createDomainUnit_IncludeChildDomainUnit = cmdletContext.CreateDomainUnit_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_CreateDomainUnit_createDomainUnit_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateDomainUnit.IncludeChildDomainUnits = requestDetail_detail_CreateDomainUnit_createDomainUnit_IncludeChildDomainUnit.Value;
                requestDetail_detail_CreateDomainUnitIsNull = false;
            }
             // determine if requestDetail_detail_CreateDomainUnit should be set to null
            if (requestDetail_detail_CreateDomainUnitIsNull)
            {
                requestDetail_detail_CreateDomainUnit = null;
            }
            if (requestDetail_detail_CreateDomainUnit != null)
            {
                request.Detail.CreateDomainUnit = requestDetail_detail_CreateDomainUnit;
            }
            Amazon.DataZone.Model.CreateEnvironmentProfilePolicyGrantDetail requestDetail_detail_CreateEnvironmentProfile = null;
            
             // populate CreateEnvironmentProfile
            var requestDetail_detail_CreateEnvironmentProfileIsNull = true;
            requestDetail_detail_CreateEnvironmentProfile = new Amazon.DataZone.Model.CreateEnvironmentProfilePolicyGrantDetail();
            System.String requestDetail_detail_CreateEnvironmentProfile_createEnvironmentProfile_DomainUnitId = null;
            if (cmdletContext.CreateEnvironmentProfile_DomainUnitId != null)
            {
                requestDetail_detail_CreateEnvironmentProfile_createEnvironmentProfile_DomainUnitId = cmdletContext.CreateEnvironmentProfile_DomainUnitId;
            }
            if (requestDetail_detail_CreateEnvironmentProfile_createEnvironmentProfile_DomainUnitId != null)
            {
                requestDetail_detail_CreateEnvironmentProfile.DomainUnitId = requestDetail_detail_CreateEnvironmentProfile_createEnvironmentProfile_DomainUnitId;
                requestDetail_detail_CreateEnvironmentProfileIsNull = false;
            }
             // determine if requestDetail_detail_CreateEnvironmentProfile should be set to null
            if (requestDetail_detail_CreateEnvironmentProfileIsNull)
            {
                requestDetail_detail_CreateEnvironmentProfile = null;
            }
            if (requestDetail_detail_CreateEnvironmentProfile != null)
            {
                request.Detail.CreateEnvironmentProfile = requestDetail_detail_CreateEnvironmentProfile;
            }
            Amazon.DataZone.Model.CreateFormTypePolicyGrantDetail requestDetail_detail_CreateFormType = null;
            
             // populate CreateFormType
            var requestDetail_detail_CreateFormTypeIsNull = true;
            requestDetail_detail_CreateFormType = new Amazon.DataZone.Model.CreateFormTypePolicyGrantDetail();
            System.Boolean? requestDetail_detail_CreateFormType_createFormType_IncludeChildDomainUnit = null;
            if (cmdletContext.CreateFormType_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateFormType_createFormType_IncludeChildDomainUnit = cmdletContext.CreateFormType_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_CreateFormType_createFormType_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateFormType.IncludeChildDomainUnits = requestDetail_detail_CreateFormType_createFormType_IncludeChildDomainUnit.Value;
                requestDetail_detail_CreateFormTypeIsNull = false;
            }
             // determine if requestDetail_detail_CreateFormType should be set to null
            if (requestDetail_detail_CreateFormTypeIsNull)
            {
                requestDetail_detail_CreateFormType = null;
            }
            if (requestDetail_detail_CreateFormType != null)
            {
                request.Detail.CreateFormType = requestDetail_detail_CreateFormType;
            }
            Amazon.DataZone.Model.CreateGlossaryPolicyGrantDetail requestDetail_detail_CreateGlossary = null;
            
             // populate CreateGlossary
            var requestDetail_detail_CreateGlossaryIsNull = true;
            requestDetail_detail_CreateGlossary = new Amazon.DataZone.Model.CreateGlossaryPolicyGrantDetail();
            System.Boolean? requestDetail_detail_CreateGlossary_createGlossary_IncludeChildDomainUnit = null;
            if (cmdletContext.CreateGlossary_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateGlossary_createGlossary_IncludeChildDomainUnit = cmdletContext.CreateGlossary_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_CreateGlossary_createGlossary_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateGlossary.IncludeChildDomainUnits = requestDetail_detail_CreateGlossary_createGlossary_IncludeChildDomainUnit.Value;
                requestDetail_detail_CreateGlossaryIsNull = false;
            }
             // determine if requestDetail_detail_CreateGlossary should be set to null
            if (requestDetail_detail_CreateGlossaryIsNull)
            {
                requestDetail_detail_CreateGlossary = null;
            }
            if (requestDetail_detail_CreateGlossary != null)
            {
                request.Detail.CreateGlossary = requestDetail_detail_CreateGlossary;
            }
            Amazon.DataZone.Model.CreateProjectPolicyGrantDetail requestDetail_detail_CreateProject = null;
            
             // populate CreateProject
            var requestDetail_detail_CreateProjectIsNull = true;
            requestDetail_detail_CreateProject = new Amazon.DataZone.Model.CreateProjectPolicyGrantDetail();
            System.Boolean? requestDetail_detail_CreateProject_createProject_IncludeChildDomainUnit = null;
            if (cmdletContext.CreateProject_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateProject_createProject_IncludeChildDomainUnit = cmdletContext.CreateProject_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_CreateProject_createProject_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateProject.IncludeChildDomainUnits = requestDetail_detail_CreateProject_createProject_IncludeChildDomainUnit.Value;
                requestDetail_detail_CreateProjectIsNull = false;
            }
             // determine if requestDetail_detail_CreateProject should be set to null
            if (requestDetail_detail_CreateProjectIsNull)
            {
                requestDetail_detail_CreateProject = null;
            }
            if (requestDetail_detail_CreateProject != null)
            {
                request.Detail.CreateProject = requestDetail_detail_CreateProject;
            }
            Amazon.DataZone.Model.OverrideDomainUnitOwnersPolicyGrantDetail requestDetail_detail_OverrideDomainUnitOwners = null;
            
             // populate OverrideDomainUnitOwners
            var requestDetail_detail_OverrideDomainUnitOwnersIsNull = true;
            requestDetail_detail_OverrideDomainUnitOwners = new Amazon.DataZone.Model.OverrideDomainUnitOwnersPolicyGrantDetail();
            System.Boolean? requestDetail_detail_OverrideDomainUnitOwners_overrideDomainUnitOwners_IncludeChildDomainUnit = null;
            if (cmdletContext.OverrideDomainUnitOwners_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_OverrideDomainUnitOwners_overrideDomainUnitOwners_IncludeChildDomainUnit = cmdletContext.OverrideDomainUnitOwners_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_OverrideDomainUnitOwners_overrideDomainUnitOwners_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_OverrideDomainUnitOwners.IncludeChildDomainUnits = requestDetail_detail_OverrideDomainUnitOwners_overrideDomainUnitOwners_IncludeChildDomainUnit.Value;
                requestDetail_detail_OverrideDomainUnitOwnersIsNull = false;
            }
             // determine if requestDetail_detail_OverrideDomainUnitOwners should be set to null
            if (requestDetail_detail_OverrideDomainUnitOwnersIsNull)
            {
                requestDetail_detail_OverrideDomainUnitOwners = null;
            }
            if (requestDetail_detail_OverrideDomainUnitOwners != null)
            {
                request.Detail.OverrideDomainUnitOwners = requestDetail_detail_OverrideDomainUnitOwners;
            }
            Amazon.DataZone.Model.OverrideProjectOwnersPolicyGrantDetail requestDetail_detail_OverrideProjectOwners = null;
            
             // populate OverrideProjectOwners
            var requestDetail_detail_OverrideProjectOwnersIsNull = true;
            requestDetail_detail_OverrideProjectOwners = new Amazon.DataZone.Model.OverrideProjectOwnersPolicyGrantDetail();
            System.Boolean? requestDetail_detail_OverrideProjectOwners_overrideProjectOwners_IncludeChildDomainUnit = null;
            if (cmdletContext.OverrideProjectOwners_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_OverrideProjectOwners_overrideProjectOwners_IncludeChildDomainUnit = cmdletContext.OverrideProjectOwners_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_OverrideProjectOwners_overrideProjectOwners_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_OverrideProjectOwners.IncludeChildDomainUnits = requestDetail_detail_OverrideProjectOwners_overrideProjectOwners_IncludeChildDomainUnit.Value;
                requestDetail_detail_OverrideProjectOwnersIsNull = false;
            }
             // determine if requestDetail_detail_OverrideProjectOwners should be set to null
            if (requestDetail_detail_OverrideProjectOwnersIsNull)
            {
                requestDetail_detail_OverrideProjectOwners = null;
            }
            if (requestDetail_detail_OverrideProjectOwners != null)
            {
                request.Detail.OverrideProjectOwners = requestDetail_detail_OverrideProjectOwners;
            }
            Amazon.DataZone.Model.UseAssetTypePolicyGrantDetail requestDetail_detail_UseAssetType = null;
            
             // populate UseAssetType
            var requestDetail_detail_UseAssetTypeIsNull = true;
            requestDetail_detail_UseAssetType = new Amazon.DataZone.Model.UseAssetTypePolicyGrantDetail();
            System.String requestDetail_detail_UseAssetType_useAssetType_DomainUnitId = null;
            if (cmdletContext.UseAssetType_DomainUnitId != null)
            {
                requestDetail_detail_UseAssetType_useAssetType_DomainUnitId = cmdletContext.UseAssetType_DomainUnitId;
            }
            if (requestDetail_detail_UseAssetType_useAssetType_DomainUnitId != null)
            {
                requestDetail_detail_UseAssetType.DomainUnitId = requestDetail_detail_UseAssetType_useAssetType_DomainUnitId;
                requestDetail_detail_UseAssetTypeIsNull = false;
            }
             // determine if requestDetail_detail_UseAssetType should be set to null
            if (requestDetail_detail_UseAssetTypeIsNull)
            {
                requestDetail_detail_UseAssetType = null;
            }
            if (requestDetail_detail_UseAssetType != null)
            {
                request.Detail.UseAssetType = requestDetail_detail_UseAssetType;
            }
            Amazon.DataZone.Model.CreateProjectFromProjectProfilePolicyGrantDetail requestDetail_detail_CreateProjectFromProjectProfile = null;
            
             // populate CreateProjectFromProjectProfile
            var requestDetail_detail_CreateProjectFromProjectProfileIsNull = true;
            requestDetail_detail_CreateProjectFromProjectProfile = new Amazon.DataZone.Model.CreateProjectFromProjectProfilePolicyGrantDetail();
            System.Boolean? requestDetail_detail_CreateProjectFromProjectProfile_createProjectFromProjectProfile_IncludeChildDomainUnit = null;
            if (cmdletContext.CreateProjectFromProjectProfile_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateProjectFromProjectProfile_createProjectFromProjectProfile_IncludeChildDomainUnit = cmdletContext.CreateProjectFromProjectProfile_IncludeChildDomainUnit.Value;
            }
            if (requestDetail_detail_CreateProjectFromProjectProfile_createProjectFromProjectProfile_IncludeChildDomainUnit != null)
            {
                requestDetail_detail_CreateProjectFromProjectProfile.IncludeChildDomainUnits = requestDetail_detail_CreateProjectFromProjectProfile_createProjectFromProjectProfile_IncludeChildDomainUnit.Value;
                requestDetail_detail_CreateProjectFromProjectProfileIsNull = false;
            }
            List<System.String> requestDetail_detail_CreateProjectFromProjectProfile_createProjectFromProjectProfile_ProjectProfile = null;
            if (cmdletContext.CreateProjectFromProjectProfile_ProjectProfile != null)
            {
                requestDetail_detail_CreateProjectFromProjectProfile_createProjectFromProjectProfile_ProjectProfile = cmdletContext.CreateProjectFromProjectProfile_ProjectProfile;
            }
            if (requestDetail_detail_CreateProjectFromProjectProfile_createProjectFromProjectProfile_ProjectProfile != null)
            {
                requestDetail_detail_CreateProjectFromProjectProfile.ProjectProfiles = requestDetail_detail_CreateProjectFromProjectProfile_createProjectFromProjectProfile_ProjectProfile;
                requestDetail_detail_CreateProjectFromProjectProfileIsNull = false;
            }
             // determine if requestDetail_detail_CreateProjectFromProjectProfile should be set to null
            if (requestDetail_detail_CreateProjectFromProjectProfileIsNull)
            {
                requestDetail_detail_CreateProjectFromProjectProfile = null;
            }
            if (requestDetail_detail_CreateProjectFromProjectProfile != null)
            {
                request.Detail.CreateProjectFromProjectProfile = requestDetail_detail_CreateProjectFromProjectProfile;
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
        
        private Amazon.DataZone.Model.AddPolicyGrantResponse CallAWSServiceOperation(IAmazonDataZone client, Amazon.DataZone.Model.AddPolicyGrantRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DataZone", "AddPolicyGrant");
            try
            {
                return client.AddPolicyGrantAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AddToProjectMemberPool_IncludeChildDomainUnit { get; set; }
            public System.Boolean? CreateAssetType_IncludeChildDomainUnit { get; set; }
            public System.Boolean? CreateDomainUnit_IncludeChildDomainUnit { get; set; }
            public Amazon.DataZone.Model.Unit Detail_CreateEnvironment { get; set; }
            public Amazon.DataZone.Model.Unit Detail_CreateEnvironmentFromBlueprint { get; set; }
            public System.String CreateEnvironmentProfile_DomainUnitId { get; set; }
            public System.Boolean? CreateFormType_IncludeChildDomainUnit { get; set; }
            public System.Boolean? CreateGlossary_IncludeChildDomainUnit { get; set; }
            public System.Boolean? CreateProject_IncludeChildDomainUnit { get; set; }
            public System.Boolean? CreateProjectFromProjectProfile_IncludeChildDomainUnit { get; set; }
            public List<System.String> CreateProjectFromProjectProfile_ProjectProfile { get; set; }
            public Amazon.DataZone.Model.Unit Detail_DelegateCreateEnvironmentProfile { get; set; }
            public System.Boolean? OverrideDomainUnitOwners_IncludeChildDomainUnit { get; set; }
            public System.Boolean? OverrideProjectOwners_IncludeChildDomainUnit { get; set; }
            public System.String UseAssetType_DomainUnitId { get; set; }
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
            public System.Func<Amazon.DataZone.Model.AddPolicyGrantResponse, AddDZPolicyGrantCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
