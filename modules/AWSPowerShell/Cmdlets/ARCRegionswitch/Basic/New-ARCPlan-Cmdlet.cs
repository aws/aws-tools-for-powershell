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
using Amazon.ARCRegionswitch;
using Amazon.ARCRegionswitch.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.ARC
{
    /// <summary>
    /// Creates a new Region switch plan. A plan defines the steps required to shift traffic
    /// from one Amazon Web Services Region to another.
    /// 
    ///  
    /// <para>
    /// You must specify a name for the plan, the primary Region, and at least one additional
    /// Region. You can also provide a description, execution role, recovery time objective,
    /// associated alarms, triggers, and workflows that define the steps to execute during
    /// a Region switch.
    /// </para>
    /// </summary>
    [Cmdlet("New", "ARCPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCRegionswitch.Model.Plan")]
    [AWSCmdlet("Calls the ARC - Region switch CreatePlan API operation.", Operation = new[] {"CreatePlan"}, SelectReturnType = typeof(Amazon.ARCRegionswitch.Model.CreatePlanResponse))]
    [AWSCmdletOutput("Amazon.ARCRegionswitch.Model.Plan or Amazon.ARCRegionswitch.Model.CreatePlanResponse",
        "This cmdlet returns an Amazon.ARCRegionswitch.Model.Plan object.",
        "The service call response (type Amazon.ARCRegionswitch.Model.CreatePlanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewARCPlanCmdlet : AmazonARCRegionswitchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AssociatedAlarm
        /// <summary>
        /// <para>
        /// <para>The alarms associated with a Region switch plan.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociatedAlarms")]
        public System.Collections.Hashtable AssociatedAlarm { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of a Region switch plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExecutionRole
        /// <summary>
        /// <para>
        /// <para>An execution role is a way to categorize a Region switch plan.</para>
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
        public System.String ExecutionRole { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of a Region switch plan.</para>
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
        
        #region Parameter PrimaryRegion
        /// <summary>
        /// <para>
        /// <para>The primary Amazon Web Services Region for the application. This is the Region where
        /// the application normally runs before any Region switch occurs.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PrimaryRegion { get; set; }
        #endregion
        
        #region Parameter RecoveryApproach
        /// <summary>
        /// <para>
        /// <para>The recovery approach for a Region switch plan, which can be active/active (activeActive)
        /// or active/passive (activePassive).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.ARCRegionswitch.RecoveryApproach")]
        public Amazon.ARCRegionswitch.RecoveryApproach RecoveryApproach { get; set; }
        #endregion
        
        #region Parameter RecoveryTimeObjectiveMinute
        /// <summary>
        /// <para>
        /// <para>Optionally, you can specify an recovery time objective for a Region switch plan, in
        /// minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecoveryTimeObjectiveMinutes")]
        public System.Int32? RecoveryTimeObjectiveMinute { get; set; }
        #endregion
        
        #region Parameter PlanRegions
        /// <summary>
        /// <para>
        /// <para>An array that specifies the Amazon Web Services Regions for a Region switch plan.
        /// Specify two Regions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Regions")]
        public System.String[] PlanRegions { get; set; }
        #endregion
        
        #region Parameter ReportConfiguration_ReportOutput
        /// <summary>
        /// <para>
        /// <para>The output configuration for the report.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ARCRegionswitch.Model.ReportOutputConfiguration[] ReportConfiguration_ReportOutput { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to apply to the Region switch plan.</para><para />
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
        
        #region Parameter Trigger
        /// <summary>
        /// <para>
        /// <para>The triggers associated with a Region switch plan.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Triggers")]
        public Amazon.ARCRegionswitch.Model.Trigger[] Trigger { get; set; }
        #endregion
        
        #region Parameter Workflow
        /// <summary>
        /// <para>
        /// <para>An array of workflows included in a Region switch plan.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Workflows")]
        public Amazon.ARCRegionswitch.Model.Workflow[] Workflow { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Plan'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCRegionswitch.Model.CreatePlanResponse).
        /// Specifying the name of a property of type Amazon.ARCRegionswitch.Model.CreatePlanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Plan";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ARCPlan (CreatePlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCRegionswitch.Model.CreatePlanResponse, NewARCPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociatedAlarm != null)
            {
                context.AssociatedAlarm = new Dictionary<System.String, Amazon.ARCRegionswitch.Model.AssociatedAlarm>(StringComparer.Ordinal);
                foreach (var hashKey in this.AssociatedAlarm.Keys)
                {
                    context.AssociatedAlarm.Add((String)hashKey, (Amazon.ARCRegionswitch.Model.AssociatedAlarm)(this.AssociatedAlarm[hashKey]));
                }
            }
            context.Description = this.Description;
            context.ExecutionRole = this.ExecutionRole;
            #if MODULAR
            if (this.ExecutionRole == null && ParameterWasBound(nameof(this.ExecutionRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrimaryRegion = this.PrimaryRegion;
            context.RecoveryApproach = this.RecoveryApproach;
            #if MODULAR
            if (this.RecoveryApproach == null && ParameterWasBound(nameof(this.RecoveryApproach)))
            {
                WriteWarning("You are passing $null as a value for parameter RecoveryApproach which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RecoveryTimeObjectiveMinute = this.RecoveryTimeObjectiveMinute;
            if (this.PlanRegions != null)
            {
                context.PlanRegions = new List<System.String>(this.PlanRegions);
            }
            #if MODULAR
            if (this.PlanRegions == null && ParameterWasBound(nameof(this.PlanRegions)))
            {
                WriteWarning("You are passing $null as a value for parameter PlanRegions which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ReportConfiguration_ReportOutput != null)
            {
                context.ReportConfiguration_ReportOutput = new List<Amazon.ARCRegionswitch.Model.ReportOutputConfiguration>(this.ReportConfiguration_ReportOutput);
            }
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.Trigger != null)
            {
                context.Trigger = new List<Amazon.ARCRegionswitch.Model.Trigger>(this.Trigger);
            }
            if (this.Workflow != null)
            {
                context.Workflow = new List<Amazon.ARCRegionswitch.Model.Workflow>(this.Workflow);
            }
            #if MODULAR
            if (this.Workflow == null && ParameterWasBound(nameof(this.Workflow)))
            {
                WriteWarning("You are passing $null as a value for parameter Workflow which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ARCRegionswitch.Model.CreatePlanRequest();
            
            if (cmdletContext.AssociatedAlarm != null)
            {
                request.AssociatedAlarms = cmdletContext.AssociatedAlarm;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRole != null)
            {
                request.ExecutionRole = cmdletContext.ExecutionRole;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.PrimaryRegion != null)
            {
                request.PrimaryRegion = cmdletContext.PrimaryRegion;
            }
            if (cmdletContext.RecoveryApproach != null)
            {
                request.RecoveryApproach = cmdletContext.RecoveryApproach;
            }
            if (cmdletContext.RecoveryTimeObjectiveMinute != null)
            {
                request.RecoveryTimeObjectiveMinutes = cmdletContext.RecoveryTimeObjectiveMinute.Value;
            }
            if (cmdletContext.PlanRegions != null)
            {
                request.Regions = cmdletContext.PlanRegions;
            }
            
             // populate ReportConfiguration
            var requestReportConfigurationIsNull = true;
            request.ReportConfiguration = new Amazon.ARCRegionswitch.Model.ReportConfiguration();
            List<Amazon.ARCRegionswitch.Model.ReportOutputConfiguration> requestReportConfiguration_reportConfiguration_ReportOutput = null;
            if (cmdletContext.ReportConfiguration_ReportOutput != null)
            {
                requestReportConfiguration_reportConfiguration_ReportOutput = cmdletContext.ReportConfiguration_ReportOutput;
            }
            if (requestReportConfiguration_reportConfiguration_ReportOutput != null)
            {
                request.ReportConfiguration.ReportOutput = requestReportConfiguration_reportConfiguration_ReportOutput;
                requestReportConfigurationIsNull = false;
            }
             // determine if request.ReportConfiguration should be set to null
            if (requestReportConfigurationIsNull)
            {
                request.ReportConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Trigger != null)
            {
                request.Triggers = cmdletContext.Trigger;
            }
            if (cmdletContext.Workflow != null)
            {
                request.Workflows = cmdletContext.Workflow;
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
        
        private Amazon.ARCRegionswitch.Model.CreatePlanResponse CallAWSServiceOperation(IAmazonARCRegionswitch client, Amazon.ARCRegionswitch.Model.CreatePlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "ARC - Region switch", "CreatePlan");
            try
            {
                return client.CreatePlanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Dictionary<System.String, Amazon.ARCRegionswitch.Model.AssociatedAlarm> AssociatedAlarm { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRole { get; set; }
            public System.String Name { get; set; }
            public System.String PrimaryRegion { get; set; }
            public Amazon.ARCRegionswitch.RecoveryApproach RecoveryApproach { get; set; }
            public System.Int32? RecoveryTimeObjectiveMinute { get; set; }
            public List<System.String> PlanRegions { get; set; }
            public List<Amazon.ARCRegionswitch.Model.ReportOutputConfiguration> ReportConfiguration_ReportOutput { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.ARCRegionswitch.Model.Trigger> Trigger { get; set; }
            public List<Amazon.ARCRegionswitch.Model.Workflow> Workflow { get; set; }
            public System.Func<Amazon.ARCRegionswitch.Model.CreatePlanResponse, NewARCPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Plan;
        }
        
    }
}
