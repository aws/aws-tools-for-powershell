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
using Amazon.ARCRegionswitch;
using Amazon.ARCRegionswitch.Model;

namespace Amazon.PowerShell.Cmdlets.ARC
{
    /// <summary>
    /// Updates an existing Region switch plan. You can modify the plan's description, workflows,
    /// execution role, recovery time objective, associated alarms, and triggers.
    /// </summary>
    [Cmdlet("Update", "ARCPlan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ARCRegionswitch.Model.Plan")]
    [AWSCmdlet("Calls the ARC - Region switch UpdatePlan API operation.", Operation = new[] {"UpdatePlan"}, SelectReturnType = typeof(Amazon.ARCRegionswitch.Model.UpdatePlanResponse))]
    [AWSCmdletOutput("Amazon.ARCRegionswitch.Model.Plan or Amazon.ARCRegionswitch.Model.UpdatePlanResponse",
        "This cmdlet returns an Amazon.ARCRegionswitch.Model.Plan object.",
        "The service call response (type Amazon.ARCRegionswitch.Model.UpdatePlanResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateARCPlanCmdlet : AmazonARCRegionswitchClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the plan.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter AssociatedAlarm
        /// <summary>
        /// <para>
        /// <para>The updated CloudWatch alarms associated with the plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AssociatedAlarms")]
        public System.Collections.Hashtable AssociatedAlarm { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The updated description for the Region switch plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The updated IAM role ARN that grants Region switch the permissions needed to execute
        /// the plan steps.</para>
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
        public System.String ExecutionRole { get; set; }
        #endregion
        
        #region Parameter RecoveryTimeObjectiveMinute
        /// <summary>
        /// <para>
        /// <para>The updated target recovery time objective (RTO) in minutes for the plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RecoveryTimeObjectiveMinutes")]
        public System.Int32? RecoveryTimeObjectiveMinute { get; set; }
        #endregion
        
        #region Parameter ReportConfiguration_ReportOutput
        /// <summary>
        /// <para>
        /// <para>The output configuration for the report.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ARCRegionswitch.Model.ReportOutputConfiguration[] ReportConfiguration_ReportOutput { get; set; }
        #endregion
        
        #region Parameter Trigger
        /// <summary>
        /// <para>
        /// <para>The updated conditions that can automatically trigger the execution of the plan.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Triggers")]
        public Amazon.ARCRegionswitch.Model.Trigger[] Trigger { get; set; }
        #endregion
        
        #region Parameter Workflow
        /// <summary>
        /// <para>
        /// <para>The updated workflows for the Region switch plan.</para>
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ARCRegionswitch.Model.UpdatePlanResponse).
        /// Specifying the name of a property of type Amazon.ARCRegionswitch.Model.UpdatePlanResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Arn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ARCPlan (UpdatePlan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ARCRegionswitch.Model.UpdatePlanResponse, UpdateARCPlanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            context.RecoveryTimeObjectiveMinute = this.RecoveryTimeObjectiveMinute;
            if (this.ReportConfiguration_ReportOutput != null)
            {
                context.ReportConfiguration_ReportOutput = new List<Amazon.ARCRegionswitch.Model.ReportOutputConfiguration>(this.ReportConfiguration_ReportOutput);
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
            var request = new Amazon.ARCRegionswitch.Model.UpdatePlanRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
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
            if (cmdletContext.RecoveryTimeObjectiveMinute != null)
            {
                request.RecoveryTimeObjectiveMinutes = cmdletContext.RecoveryTimeObjectiveMinute.Value;
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
        
        private Amazon.ARCRegionswitch.Model.UpdatePlanResponse CallAWSServiceOperation(IAmazonARCRegionswitch client, Amazon.ARCRegionswitch.Model.UpdatePlanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "ARC - Region switch", "UpdatePlan");
            try
            {
                #if DESKTOP
                return client.UpdatePlan(request);
                #elif CORECLR
                return client.UpdatePlanAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public Dictionary<System.String, Amazon.ARCRegionswitch.Model.AssociatedAlarm> AssociatedAlarm { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRole { get; set; }
            public System.Int32? RecoveryTimeObjectiveMinute { get; set; }
            public List<Amazon.ARCRegionswitch.Model.ReportOutputConfiguration> ReportConfiguration_ReportOutput { get; set; }
            public List<Amazon.ARCRegionswitch.Model.Trigger> Trigger { get; set; }
            public List<Amazon.ARCRegionswitch.Model.Workflow> Workflow { get; set; }
            public System.Func<Amazon.ARCRegionswitch.Model.UpdatePlanResponse, UpdateARCPlanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Plan;
        }
        
    }
}
