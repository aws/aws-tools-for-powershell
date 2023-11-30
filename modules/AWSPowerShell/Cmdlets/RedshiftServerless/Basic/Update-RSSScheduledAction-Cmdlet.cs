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
using Amazon.RedshiftServerless;
using Amazon.RedshiftServerless.Model;

namespace Amazon.PowerShell.Cmdlets.RSS
{
    /// <summary>
    /// Updates a scheduled action.
    /// </summary>
    [Cmdlet("Update", "RSSScheduledAction", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RedshiftServerless.Model.ScheduledActionResponse")]
    [AWSCmdlet("Calls the Redshift Serverless UpdateScheduledAction API operation.", Operation = new[] {"UpdateScheduledAction"}, SelectReturnType = typeof(Amazon.RedshiftServerless.Model.UpdateScheduledActionResponse))]
    [AWSCmdletOutput("Amazon.RedshiftServerless.Model.ScheduledActionResponse or Amazon.RedshiftServerless.Model.UpdateScheduledActionResponse",
        "This cmdlet returns an Amazon.RedshiftServerless.Model.ScheduledActionResponse object.",
        "The service call response (type Amazon.RedshiftServerless.Model.UpdateScheduledActionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateRSSScheduledActionCmdlet : AmazonRedshiftServerlessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Schedule_At
        /// <summary>
        /// <para>
        /// <para>The timestamp of when Amazon Redshift Serverless should run the scheduled action.
        /// Format of at expressions is "<code>at(yyyy-mm-ddThh:mm:ss)</code>". For example, "<code>at(2016-03-04T17:27:00)</code>".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? Schedule_At { get; set; }
        #endregion
        
        #region Parameter Schedule_Cron
        /// <summary>
        /// <para>
        /// <para>The cron expression to use to schedule a recurring scheduled action. Schedule invocations
        /// must be separated by at least one hour.</para><para>Format of cron expressions is "<code>cron(Minutes Hours Day-of-month Month Day-of-week
        /// Year)</code>". For example, "<code>cron(0 10 ? * MON *)</code>". For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/events/ScheduledEvents.html#CronExpressions">Cron
        /// Expressions</a> in the <i>Amazon CloudWatch Events User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Cron { get; set; }
        #endregion
        
        #region Parameter Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to enable the scheduled action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Enabled { get; set; }
        #endregion
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>The end time in UTC of the scheduled action to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter CreateSnapshot_NamespaceName
        /// <summary>
        /// <para>
        /// <para>The name of the namespace for which you want to configure a scheduled action to create
        /// a snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_CreateSnapshot_NamespaceName")]
        public System.String CreateSnapshot_NamespaceName { get; set; }
        #endregion
        
        #region Parameter CreateSnapshot_RetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The retention period of the snapshot created by the scheduled action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_CreateSnapshot_RetentionPeriod")]
        public System.Int32? CreateSnapshot_RetentionPeriod { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role to assume to run the scheduled action. This IAM role must
        /// have permission to run the Amazon Redshift Serverless API operation in the scheduled
        /// action. This IAM role must allow the Amazon Redshift scheduler to schedule creating
        /// snapshots (Principal scheduler.redshift.amazonaws.com) to assume permissions on your
        /// behalf. For more information about the IAM role to use with the Amazon Redshift scheduler,
        /// see <a href="https://docs.aws.amazon.com/redshift/latest/mgmt/redshift-iam-access-control-identity-based.html">Using
        /// Identity-Based Policies for Amazon Redshift</a> in the Amazon Redshift Cluster Management
        /// Guide</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter ScheduledActionDescription
        /// <summary>
        /// <para>
        /// <para>The descripion of the scheduled action to update to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ScheduledActionDescription { get; set; }
        #endregion
        
        #region Parameter ScheduledActionName
        /// <summary>
        /// <para>
        /// <para>The name of the scheduled action to update to.</para>
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
        public System.String ScheduledActionName { get; set; }
        #endregion
        
        #region Parameter CreateSnapshot_SnapshotNamePrefix
        /// <summary>
        /// <para>
        /// <para>A string prefix that is attached to the name of the snapshot created by the scheduled
        /// action. The final name of the snapshot is the string prefix appended by the date and
        /// time of when the snapshot was created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_CreateSnapshot_SnapshotNamePrefix")]
        public System.String CreateSnapshot_SnapshotNamePrefix { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The start time in UTC of the scheduled action to update to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
        #endregion
        
        #region Parameter CreateSnapshot_Tag
        /// <summary>
        /// <para>
        /// <para>An array of <a href="https://docs.aws.amazon.com/redshift-serverless/latest/APIReference/API_Tag.html">Tag
        /// objects</a> to associate with the snapshot.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TargetAction_CreateSnapshot_Tags")]
        public Amazon.RedshiftServerless.Model.Tag[] CreateSnapshot_Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ScheduledAction'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RedshiftServerless.Model.UpdateScheduledActionResponse).
        /// Specifying the name of a property of type Amazon.RedshiftServerless.Model.UpdateScheduledActionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ScheduledAction";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ScheduledActionName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ScheduledActionName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ScheduledActionName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ScheduledActionName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-RSSScheduledAction (UpdateScheduledAction)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RedshiftServerless.Model.UpdateScheduledActionResponse, UpdateRSSScheduledActionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ScheduledActionName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Enabled = this.Enabled;
            context.EndTime = this.EndTime;
            context.RoleArn = this.RoleArn;
            context.Schedule_At = this.Schedule_At;
            context.Schedule_Cron = this.Schedule_Cron;
            context.ScheduledActionDescription = this.ScheduledActionDescription;
            context.ScheduledActionName = this.ScheduledActionName;
            #if MODULAR
            if (this.ScheduledActionName == null && ParameterWasBound(nameof(this.ScheduledActionName)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduledActionName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartTime = this.StartTime;
            context.CreateSnapshot_NamespaceName = this.CreateSnapshot_NamespaceName;
            context.CreateSnapshot_RetentionPeriod = this.CreateSnapshot_RetentionPeriod;
            context.CreateSnapshot_SnapshotNamePrefix = this.CreateSnapshot_SnapshotNamePrefix;
            if (this.CreateSnapshot_Tag != null)
            {
                context.CreateSnapshot_Tag = new List<Amazon.RedshiftServerless.Model.Tag>(this.CreateSnapshot_Tag);
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
            var request = new Amazon.RedshiftServerless.Model.UpdateScheduledActionRequest();
            
            if (cmdletContext.Enabled != null)
            {
                request.Enabled = cmdletContext.Enabled.Value;
            }
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.RedshiftServerless.Model.Schedule();
            System.DateTime? requestSchedule_schedule_At = null;
            if (cmdletContext.Schedule_At != null)
            {
                requestSchedule_schedule_At = cmdletContext.Schedule_At.Value;
            }
            if (requestSchedule_schedule_At != null)
            {
                request.Schedule.At = requestSchedule_schedule_At.Value;
                requestScheduleIsNull = false;
            }
            System.String requestSchedule_schedule_Cron = null;
            if (cmdletContext.Schedule_Cron != null)
            {
                requestSchedule_schedule_Cron = cmdletContext.Schedule_Cron;
            }
            if (requestSchedule_schedule_Cron != null)
            {
                request.Schedule.Cron = requestSchedule_schedule_Cron;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            if (cmdletContext.ScheduledActionDescription != null)
            {
                request.ScheduledActionDescription = cmdletContext.ScheduledActionDescription;
            }
            if (cmdletContext.ScheduledActionName != null)
            {
                request.ScheduledActionName = cmdletContext.ScheduledActionName;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
            }
            
             // populate TargetAction
            var requestTargetActionIsNull = true;
            request.TargetAction = new Amazon.RedshiftServerless.Model.TargetAction();
            Amazon.RedshiftServerless.Model.CreateSnapshotScheduleActionParameters requestTargetAction_targetAction_CreateSnapshot = null;
            
             // populate CreateSnapshot
            var requestTargetAction_targetAction_CreateSnapshotIsNull = true;
            requestTargetAction_targetAction_CreateSnapshot = new Amazon.RedshiftServerless.Model.CreateSnapshotScheduleActionParameters();
            System.String requestTargetAction_targetAction_CreateSnapshot_createSnapshot_NamespaceName = null;
            if (cmdletContext.CreateSnapshot_NamespaceName != null)
            {
                requestTargetAction_targetAction_CreateSnapshot_createSnapshot_NamespaceName = cmdletContext.CreateSnapshot_NamespaceName;
            }
            if (requestTargetAction_targetAction_CreateSnapshot_createSnapshot_NamespaceName != null)
            {
                requestTargetAction_targetAction_CreateSnapshot.NamespaceName = requestTargetAction_targetAction_CreateSnapshot_createSnapshot_NamespaceName;
                requestTargetAction_targetAction_CreateSnapshotIsNull = false;
            }
            System.Int32? requestTargetAction_targetAction_CreateSnapshot_createSnapshot_RetentionPeriod = null;
            if (cmdletContext.CreateSnapshot_RetentionPeriod != null)
            {
                requestTargetAction_targetAction_CreateSnapshot_createSnapshot_RetentionPeriod = cmdletContext.CreateSnapshot_RetentionPeriod.Value;
            }
            if (requestTargetAction_targetAction_CreateSnapshot_createSnapshot_RetentionPeriod != null)
            {
                requestTargetAction_targetAction_CreateSnapshot.RetentionPeriod = requestTargetAction_targetAction_CreateSnapshot_createSnapshot_RetentionPeriod.Value;
                requestTargetAction_targetAction_CreateSnapshotIsNull = false;
            }
            System.String requestTargetAction_targetAction_CreateSnapshot_createSnapshot_SnapshotNamePrefix = null;
            if (cmdletContext.CreateSnapshot_SnapshotNamePrefix != null)
            {
                requestTargetAction_targetAction_CreateSnapshot_createSnapshot_SnapshotNamePrefix = cmdletContext.CreateSnapshot_SnapshotNamePrefix;
            }
            if (requestTargetAction_targetAction_CreateSnapshot_createSnapshot_SnapshotNamePrefix != null)
            {
                requestTargetAction_targetAction_CreateSnapshot.SnapshotNamePrefix = requestTargetAction_targetAction_CreateSnapshot_createSnapshot_SnapshotNamePrefix;
                requestTargetAction_targetAction_CreateSnapshotIsNull = false;
            }
            List<Amazon.RedshiftServerless.Model.Tag> requestTargetAction_targetAction_CreateSnapshot_createSnapshot_Tag = null;
            if (cmdletContext.CreateSnapshot_Tag != null)
            {
                requestTargetAction_targetAction_CreateSnapshot_createSnapshot_Tag = cmdletContext.CreateSnapshot_Tag;
            }
            if (requestTargetAction_targetAction_CreateSnapshot_createSnapshot_Tag != null)
            {
                requestTargetAction_targetAction_CreateSnapshot.Tags = requestTargetAction_targetAction_CreateSnapshot_createSnapshot_Tag;
                requestTargetAction_targetAction_CreateSnapshotIsNull = false;
            }
             // determine if requestTargetAction_targetAction_CreateSnapshot should be set to null
            if (requestTargetAction_targetAction_CreateSnapshotIsNull)
            {
                requestTargetAction_targetAction_CreateSnapshot = null;
            }
            if (requestTargetAction_targetAction_CreateSnapshot != null)
            {
                request.TargetAction.CreateSnapshot = requestTargetAction_targetAction_CreateSnapshot;
                requestTargetActionIsNull = false;
            }
             // determine if request.TargetAction should be set to null
            if (requestTargetActionIsNull)
            {
                request.TargetAction = null;
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
        
        private Amazon.RedshiftServerless.Model.UpdateScheduledActionResponse CallAWSServiceOperation(IAmazonRedshiftServerless client, Amazon.RedshiftServerless.Model.UpdateScheduledActionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Redshift Serverless", "UpdateScheduledAction");
            try
            {
                #if DESKTOP
                return client.UpdateScheduledAction(request);
                #elif CORECLR
                return client.UpdateScheduledActionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? Enabled { get; set; }
            public System.DateTime? EndTime { get; set; }
            public System.String RoleArn { get; set; }
            public System.DateTime? Schedule_At { get; set; }
            public System.String Schedule_Cron { get; set; }
            public System.String ScheduledActionDescription { get; set; }
            public System.String ScheduledActionName { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.String CreateSnapshot_NamespaceName { get; set; }
            public System.Int32? CreateSnapshot_RetentionPeriod { get; set; }
            public System.String CreateSnapshot_SnapshotNamePrefix { get; set; }
            public List<Amazon.RedshiftServerless.Model.Tag> CreateSnapshot_Tag { get; set; }
            public System.Func<Amazon.RedshiftServerless.Model.UpdateScheduledActionResponse, UpdateRSSScheduledActionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ScheduledAction;
        }
        
    }
}
