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
using Amazon.Odb;
using Amazon.Odb.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ODB
{
    /// <summary>
    /// Creates an Exadata infrastructure.
    /// </summary>
    [Cmdlet("New", "ODBCloudExadataInfrastructure", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse")]
    [AWSCmdlet("Calls the Oracle Database@Amazon Web Services CreateCloudExadataInfrastructure API operation.", Operation = new[] {"CreateCloudExadataInfrastructure"}, SelectReturnType = typeof(Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse))]
    [AWSCmdletOutput("Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse",
        "This cmdlet returns an Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse object containing multiple properties."
    )]
    public partial class NewODBCloudExadataInfrastructureCmdlet : AmazonOdbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AvailabilityZone
        /// <summary>
        /// <para>
        /// <para>The name of the Availability Zone (AZ) where the Exadata infrastructure is located.</para><para>This operation requires that you specify a value for either <c>availabilityZone</c>
        /// or <c>availabilityZoneId</c>.</para><para>Example: <c>us-east-1a</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZone { get; set; }
        #endregion
        
        #region Parameter AvailabilityZoneId
        /// <summary>
        /// <para>
        /// <para>The AZ ID of the AZ where the Exadata infrastructure is located.</para><para>This operation requires that you specify a value for either <c>availabilityZone</c>
        /// or <c>availabilityZoneId</c>.</para><para>Example: <c>use1-az1</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AvailabilityZoneId { get; set; }
        #endregion
        
        #region Parameter ComputeCount
        /// <summary>
        /// <para>
        /// <para>The number of database servers for the Exadata infrastructure. Valid values for this
        /// parameter depend on the shape. To get information about the minimum and maximum values,
        /// use the <c>ListDbSystemShapes</c> operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? ComputeCount { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_CustomActionTimeoutInMin
        /// <summary>
        /// <para>
        /// <para>The custom action timeout in minutes for the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceWindow_CustomActionTimeoutInMins")]
        public System.Int32? MaintenanceWindow_CustomActionTimeoutInMin { get; set; }
        #endregion
        
        #region Parameter CustomerContactsToSendToOCI
        /// <summary>
        /// <para>
        /// <para>The email addresses of contacts to receive notification from Oracle about maintenance
        /// updates for the Exadata infrastructure.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Odb.Model.CustomerContact[] CustomerContactsToSendToOCI { get; set; }
        #endregion
        
        #region Parameter DatabaseServerType
        /// <summary>
        /// <para>
        /// <para>The database server model type of the Exadata infrastructure. For the list of valid
        /// model names, use the <c>ListDbSystemShapes</c> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatabaseServerType { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_DaysOfWeek
        /// <summary>
        /// <para>
        /// <para>The days of the week when maintenance can be performed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Odb.Model.DayOfWeek[] MaintenanceWindow_DaysOfWeek { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>A user-friendly name for the Exadata infrastructure.</para>
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
        
        #region Parameter MaintenanceWindow_HoursOfDay
        /// <summary>
        /// <para>
        /// <para>The hours of the day when maintenance can be performed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] MaintenanceWindow_HoursOfDay { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_IsCustomActionTimeoutEnabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether custom action timeout is enabled for the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MaintenanceWindow_IsCustomActionTimeoutEnabled { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_LeadTimeInWeek
        /// <summary>
        /// <para>
        /// <para>The lead time in weeks before the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceWindow_LeadTimeInWeeks")]
        public System.Int32? MaintenanceWindow_LeadTimeInWeek { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_Month
        /// <summary>
        /// <para>
        /// <para>The months when maintenance can be performed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaintenanceWindow_Months")]
        public Amazon.Odb.Model.Month[] MaintenanceWindow_Month { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_PatchingMode
        /// <summary>
        /// <para>
        /// <para>The patching mode for the maintenance window.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.PatchingModeType")]
        public Amazon.Odb.PatchingModeType MaintenanceWindow_PatchingMode { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_Preference
        /// <summary>
        /// <para>
        /// <para>The preference for the maintenance window scheduling.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Odb.PreferenceType")]
        public Amazon.Odb.PreferenceType MaintenanceWindow_Preference { get; set; }
        #endregion
        
        #region Parameter Shape
        /// <summary>
        /// <para>
        /// <para>The model name of the Exadata infrastructure. For the list of valid model names, use
        /// the <c>ListDbSystemShapes</c> operation.</para>
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
        public System.String Shape { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_SkipRu
        /// <summary>
        /// <para>
        /// <para>Indicates whether to skip release updates during maintenance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? MaintenanceWindow_SkipRu { get; set; }
        #endregion
        
        #region Parameter StorageCount
        /// <summary>
        /// <para>
        /// <para>The number of storage servers to activate for this Exadata infrastructure. Valid values
        /// for this parameter depend on the shape. To get information about the minimum and maximum
        /// values, use the <c>ListDbSystemShapes</c> operation.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? StorageCount { get; set; }
        #endregion
        
        #region Parameter StorageServerType
        /// <summary>
        /// <para>
        /// <para>The storage server model type of the Exadata infrastructure. For the list of valid
        /// model names, use the <c>ListDbSystemShapes</c> operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StorageServerType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The list of resource tags to apply to the Exadata infrastructure.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter MaintenanceWindow_WeeksOfMonth
        /// <summary>
        /// <para>
        /// <para>The weeks of the month when maintenance can be performed.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32[] MaintenanceWindow_WeeksOfMonth { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If you don't specify a client token, the Amazon Web Services SDK automatically
        /// generates a client token and uses it for the request to ensure idempotency. The client
        /// token is valid for up to 24 hours after it's first used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse).
        /// Specifying the name of a property of type Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DisplayName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ODBCloudExadataInfrastructure (CreateCloudExadataInfrastructure)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse, NewODBCloudExadataInfrastructureCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AvailabilityZone = this.AvailabilityZone;
            context.AvailabilityZoneId = this.AvailabilityZoneId;
            context.ClientToken = this.ClientToken;
            context.ComputeCount = this.ComputeCount;
            #if MODULAR
            if (this.ComputeCount == null && ParameterWasBound(nameof(this.ComputeCount)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.CustomerContactsToSendToOCI != null)
            {
                context.CustomerContactsToSendToOCI = new List<Amazon.Odb.Model.CustomerContact>(this.CustomerContactsToSendToOCI);
            }
            context.DatabaseServerType = this.DatabaseServerType;
            context.DisplayName = this.DisplayName;
            #if MODULAR
            if (this.DisplayName == null && ParameterWasBound(nameof(this.DisplayName)))
            {
                WriteWarning("You are passing $null as a value for parameter DisplayName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaintenanceWindow_CustomActionTimeoutInMin = this.MaintenanceWindow_CustomActionTimeoutInMin;
            if (this.MaintenanceWindow_DaysOfWeek != null)
            {
                context.MaintenanceWindow_DaysOfWeek = new List<Amazon.Odb.Model.DayOfWeek>(this.MaintenanceWindow_DaysOfWeek);
            }
            if (this.MaintenanceWindow_HoursOfDay != null)
            {
                context.MaintenanceWindow_HoursOfDay = new List<System.Int32>(this.MaintenanceWindow_HoursOfDay);
            }
            context.MaintenanceWindow_IsCustomActionTimeoutEnabled = this.MaintenanceWindow_IsCustomActionTimeoutEnabled;
            context.MaintenanceWindow_LeadTimeInWeek = this.MaintenanceWindow_LeadTimeInWeek;
            if (this.MaintenanceWindow_Month != null)
            {
                context.MaintenanceWindow_Month = new List<Amazon.Odb.Model.Month>(this.MaintenanceWindow_Month);
            }
            context.MaintenanceWindow_PatchingMode = this.MaintenanceWindow_PatchingMode;
            context.MaintenanceWindow_Preference = this.MaintenanceWindow_Preference;
            context.MaintenanceWindow_SkipRu = this.MaintenanceWindow_SkipRu;
            if (this.MaintenanceWindow_WeeksOfMonth != null)
            {
                context.MaintenanceWindow_WeeksOfMonth = new List<System.Int32>(this.MaintenanceWindow_WeeksOfMonth);
            }
            context.Shape = this.Shape;
            #if MODULAR
            if (this.Shape == null && ParameterWasBound(nameof(this.Shape)))
            {
                WriteWarning("You are passing $null as a value for parameter Shape which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageCount = this.StorageCount;
            #if MODULAR
            if (this.StorageCount == null && ParameterWasBound(nameof(this.StorageCount)))
            {
                WriteWarning("You are passing $null as a value for parameter StorageCount which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StorageServerType = this.StorageServerType;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Odb.Model.CreateCloudExadataInfrastructureRequest();
            
            if (cmdletContext.AvailabilityZone != null)
            {
                request.AvailabilityZone = cmdletContext.AvailabilityZone;
            }
            if (cmdletContext.AvailabilityZoneId != null)
            {
                request.AvailabilityZoneId = cmdletContext.AvailabilityZoneId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ComputeCount != null)
            {
                request.ComputeCount = cmdletContext.ComputeCount.Value;
            }
            if (cmdletContext.CustomerContactsToSendToOCI != null)
            {
                request.CustomerContactsToSendToOCI = cmdletContext.CustomerContactsToSendToOCI;
            }
            if (cmdletContext.DatabaseServerType != null)
            {
                request.DatabaseServerType = cmdletContext.DatabaseServerType;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            
             // populate MaintenanceWindow
            var requestMaintenanceWindowIsNull = true;
            request.MaintenanceWindow = new Amazon.Odb.Model.MaintenanceWindow();
            System.Int32? requestMaintenanceWindow_maintenanceWindow_CustomActionTimeoutInMin = null;
            if (cmdletContext.MaintenanceWindow_CustomActionTimeoutInMin != null)
            {
                requestMaintenanceWindow_maintenanceWindow_CustomActionTimeoutInMin = cmdletContext.MaintenanceWindow_CustomActionTimeoutInMin.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_CustomActionTimeoutInMin != null)
            {
                request.MaintenanceWindow.CustomActionTimeoutInMins = requestMaintenanceWindow_maintenanceWindow_CustomActionTimeoutInMin.Value;
                requestMaintenanceWindowIsNull = false;
            }
            List<Amazon.Odb.Model.DayOfWeek> requestMaintenanceWindow_maintenanceWindow_DaysOfWeek = null;
            if (cmdletContext.MaintenanceWindow_DaysOfWeek != null)
            {
                requestMaintenanceWindow_maintenanceWindow_DaysOfWeek = cmdletContext.MaintenanceWindow_DaysOfWeek;
            }
            if (requestMaintenanceWindow_maintenanceWindow_DaysOfWeek != null)
            {
                request.MaintenanceWindow.DaysOfWeek = requestMaintenanceWindow_maintenanceWindow_DaysOfWeek;
                requestMaintenanceWindowIsNull = false;
            }
            List<System.Int32> requestMaintenanceWindow_maintenanceWindow_HoursOfDay = null;
            if (cmdletContext.MaintenanceWindow_HoursOfDay != null)
            {
                requestMaintenanceWindow_maintenanceWindow_HoursOfDay = cmdletContext.MaintenanceWindow_HoursOfDay;
            }
            if (requestMaintenanceWindow_maintenanceWindow_HoursOfDay != null)
            {
                request.MaintenanceWindow.HoursOfDay = requestMaintenanceWindow_maintenanceWindow_HoursOfDay;
                requestMaintenanceWindowIsNull = false;
            }
            System.Boolean? requestMaintenanceWindow_maintenanceWindow_IsCustomActionTimeoutEnabled = null;
            if (cmdletContext.MaintenanceWindow_IsCustomActionTimeoutEnabled != null)
            {
                requestMaintenanceWindow_maintenanceWindow_IsCustomActionTimeoutEnabled = cmdletContext.MaintenanceWindow_IsCustomActionTimeoutEnabled.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_IsCustomActionTimeoutEnabled != null)
            {
                request.MaintenanceWindow.IsCustomActionTimeoutEnabled = requestMaintenanceWindow_maintenanceWindow_IsCustomActionTimeoutEnabled.Value;
                requestMaintenanceWindowIsNull = false;
            }
            System.Int32? requestMaintenanceWindow_maintenanceWindow_LeadTimeInWeek = null;
            if (cmdletContext.MaintenanceWindow_LeadTimeInWeek != null)
            {
                requestMaintenanceWindow_maintenanceWindow_LeadTimeInWeek = cmdletContext.MaintenanceWindow_LeadTimeInWeek.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_LeadTimeInWeek != null)
            {
                request.MaintenanceWindow.LeadTimeInWeeks = requestMaintenanceWindow_maintenanceWindow_LeadTimeInWeek.Value;
                requestMaintenanceWindowIsNull = false;
            }
            List<Amazon.Odb.Model.Month> requestMaintenanceWindow_maintenanceWindow_Month = null;
            if (cmdletContext.MaintenanceWindow_Month != null)
            {
                requestMaintenanceWindow_maintenanceWindow_Month = cmdletContext.MaintenanceWindow_Month;
            }
            if (requestMaintenanceWindow_maintenanceWindow_Month != null)
            {
                request.MaintenanceWindow.Months = requestMaintenanceWindow_maintenanceWindow_Month;
                requestMaintenanceWindowIsNull = false;
            }
            Amazon.Odb.PatchingModeType requestMaintenanceWindow_maintenanceWindow_PatchingMode = null;
            if (cmdletContext.MaintenanceWindow_PatchingMode != null)
            {
                requestMaintenanceWindow_maintenanceWindow_PatchingMode = cmdletContext.MaintenanceWindow_PatchingMode;
            }
            if (requestMaintenanceWindow_maintenanceWindow_PatchingMode != null)
            {
                request.MaintenanceWindow.PatchingMode = requestMaintenanceWindow_maintenanceWindow_PatchingMode;
                requestMaintenanceWindowIsNull = false;
            }
            Amazon.Odb.PreferenceType requestMaintenanceWindow_maintenanceWindow_Preference = null;
            if (cmdletContext.MaintenanceWindow_Preference != null)
            {
                requestMaintenanceWindow_maintenanceWindow_Preference = cmdletContext.MaintenanceWindow_Preference;
            }
            if (requestMaintenanceWindow_maintenanceWindow_Preference != null)
            {
                request.MaintenanceWindow.Preference = requestMaintenanceWindow_maintenanceWindow_Preference;
                requestMaintenanceWindowIsNull = false;
            }
            System.Boolean? requestMaintenanceWindow_maintenanceWindow_SkipRu = null;
            if (cmdletContext.MaintenanceWindow_SkipRu != null)
            {
                requestMaintenanceWindow_maintenanceWindow_SkipRu = cmdletContext.MaintenanceWindow_SkipRu.Value;
            }
            if (requestMaintenanceWindow_maintenanceWindow_SkipRu != null)
            {
                request.MaintenanceWindow.SkipRu = requestMaintenanceWindow_maintenanceWindow_SkipRu.Value;
                requestMaintenanceWindowIsNull = false;
            }
            List<System.Int32> requestMaintenanceWindow_maintenanceWindow_WeeksOfMonth = null;
            if (cmdletContext.MaintenanceWindow_WeeksOfMonth != null)
            {
                requestMaintenanceWindow_maintenanceWindow_WeeksOfMonth = cmdletContext.MaintenanceWindow_WeeksOfMonth;
            }
            if (requestMaintenanceWindow_maintenanceWindow_WeeksOfMonth != null)
            {
                request.MaintenanceWindow.WeeksOfMonth = requestMaintenanceWindow_maintenanceWindow_WeeksOfMonth;
                requestMaintenanceWindowIsNull = false;
            }
             // determine if request.MaintenanceWindow should be set to null
            if (requestMaintenanceWindowIsNull)
            {
                request.MaintenanceWindow = null;
            }
            if (cmdletContext.Shape != null)
            {
                request.Shape = cmdletContext.Shape;
            }
            if (cmdletContext.StorageCount != null)
            {
                request.StorageCount = cmdletContext.StorageCount.Value;
            }
            if (cmdletContext.StorageServerType != null)
            {
                request.StorageServerType = cmdletContext.StorageServerType;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse CallAWSServiceOperation(IAmazonOdb client, Amazon.Odb.Model.CreateCloudExadataInfrastructureRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Oracle Database@Amazon Web Services", "CreateCloudExadataInfrastructure");
            try
            {
                return client.CreateCloudExadataInfrastructureAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AvailabilityZone { get; set; }
            public System.String AvailabilityZoneId { get; set; }
            public System.String ClientToken { get; set; }
            public System.Int32? ComputeCount { get; set; }
            public List<Amazon.Odb.Model.CustomerContact> CustomerContactsToSendToOCI { get; set; }
            public System.String DatabaseServerType { get; set; }
            public System.String DisplayName { get; set; }
            public System.Int32? MaintenanceWindow_CustomActionTimeoutInMin { get; set; }
            public List<Amazon.Odb.Model.DayOfWeek> MaintenanceWindow_DaysOfWeek { get; set; }
            public List<System.Int32> MaintenanceWindow_HoursOfDay { get; set; }
            public System.Boolean? MaintenanceWindow_IsCustomActionTimeoutEnabled { get; set; }
            public System.Int32? MaintenanceWindow_LeadTimeInWeek { get; set; }
            public List<Amazon.Odb.Model.Month> MaintenanceWindow_Month { get; set; }
            public Amazon.Odb.PatchingModeType MaintenanceWindow_PatchingMode { get; set; }
            public Amazon.Odb.PreferenceType MaintenanceWindow_Preference { get; set; }
            public System.Boolean? MaintenanceWindow_SkipRu { get; set; }
            public List<System.Int32> MaintenanceWindow_WeeksOfMonth { get; set; }
            public System.String Shape { get; set; }
            public System.Int32? StorageCount { get; set; }
            public System.String StorageServerType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Odb.Model.CreateCloudExadataInfrastructureResponse, NewODBCloudExadataInfrastructureCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
