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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Starts the replication task.
    /// 
    ///  
    /// <para>
    /// For more information about DMS tasks, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.html">Working
    /// with Migration Tasks </a> in the <i>Database Migration Service User Guide.</i></para>
    /// </summary>
    [Cmdlet("Start", "DMSReplicationTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationTask")]
    [AWSCmdlet("Calls the AWS Database Migration Service StartReplicationTask API operation.", Operation = new[] {"StartReplicationTask"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationTask or Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.ReplicationTask object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDMSReplicationTaskCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CdcStartPosition
        /// <summary>
        /// <para>
        /// <para>Indicates when you want a change data capture (CDC) operation to start. Use either
        /// CdcStartPosition or CdcStartTime to specify when you want a CDC operation to start.
        /// Specifying both values results in an error.</para><para> The value can be in date, checkpoint, or LSN/SCN format.</para><para>Date Example: --cdc-start-position “2018-03-08T12:12:12”</para><para>Checkpoint Example: --cdc-start-position "checkpoint:V1#27#mysql-bin-changelog.157832:1975:-1:2002:677883278264080:mysql-bin-changelog.157832:1876#0#0#*#0#93"</para><para>LSN Example: --cdc-start-position “mysql-bin-changelog.000024:373”</para><note><para>When you use this task setting with a source PostgreSQL database, a logical replication
        /// slot should already be created and associated with the source endpoint. You can verify
        /// this by setting the <c>slotName</c> extra connection attribute to the name of this
        /// logical replication slot. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Source.PostgreSQL.html#CHAP_Source.PostgreSQL.ConnectionAttrib">Extra
        /// Connection Attributes When Using PostgreSQL as a Source for DMS</a>.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CdcStartPosition { get; set; }
        #endregion
        
        #region Parameter CdcStartTime
        /// <summary>
        /// <para>
        /// <para>Indicates the start time for a change data capture (CDC) operation. Use either CdcStartTime
        /// or CdcStartPosition to specify when you want a CDC operation to start. Specifying
        /// both values results in an error.</para><para>Timestamp Example: --cdc-start-time “2018-03-08T12:12:12”</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CdcStartTime { get; set; }
        #endregion
        
        #region Parameter CdcStopPosition
        /// <summary>
        /// <para>
        /// <para>Indicates when you want a change data capture (CDC) operation to stop. The value can
        /// be either server time or commit time.</para><para>Server time example: --cdc-stop-position “server_time:2018-02-09T12:12:12”</para><para>Commit time example: --cdc-stop-position “commit_time:2018-02-09T12:12:12“</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CdcStopPosition { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the replication task to be started.</para>
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
        public System.String ReplicationTaskArn { get; set; }
        #endregion
        
        #region Parameter StartReplicationTaskType
        /// <summary>
        /// <para>
        /// <para>The type of replication task to start.</para><para>When the migration type is <c>full-load</c> or <c>full-load-and-cdc</c>, the only
        /// valid value for the first run of the task is <c>start-replication</c>. This option
        /// will start the migration.</para><para>You can also use <a>ReloadTables</a> to reload specific tables that failed during
        /// migration instead of restarting the task.</para><para>The <c>resume-processing</c> option isn't applicable for a full-load task, because
        /// you can't resume partially loaded tables during the full load phase.</para><para>For a <c>full-load-and-cdc</c> task, DMS migrates table data, and then applies data
        /// changes that occur on the source. To load all the tables again, and start capturing
        /// source changes, use <c>reload-target</c>. Otherwise use <c>resume-processing</c>,
        /// to replicate the changes from the last stop position.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue")]
        public Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue StartReplicationTaskType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationTask";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ReplicationTaskArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ReplicationTaskArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ReplicationTaskArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationTaskArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DMSReplicationTask (StartReplicationTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse, StartDMSReplicationTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ReplicationTaskArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.CdcStartPosition = this.CdcStartPosition;
            context.CdcStartTime = this.CdcStartTime;
            context.CdcStopPosition = this.CdcStopPosition;
            context.ReplicationTaskArn = this.ReplicationTaskArn;
            #if MODULAR
            if (this.ReplicationTaskArn == null && ParameterWasBound(nameof(this.ReplicationTaskArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationTaskArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartReplicationTaskType = this.StartReplicationTaskType;
            #if MODULAR
            if (this.StartReplicationTaskType == null && ParameterWasBound(nameof(this.StartReplicationTaskType)))
            {
                WriteWarning("You are passing $null as a value for parameter StartReplicationTaskType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.StartReplicationTaskRequest();
            
            if (cmdletContext.CdcStartPosition != null)
            {
                request.CdcStartPosition = cmdletContext.CdcStartPosition;
            }
            if (cmdletContext.CdcStartTime != null)
            {
                request.CdcStartTime = cmdletContext.CdcStartTime.Value;
            }
            if (cmdletContext.CdcStopPosition != null)
            {
                request.CdcStopPosition = cmdletContext.CdcStopPosition;
            }
            if (cmdletContext.ReplicationTaskArn != null)
            {
                request.ReplicationTaskArn = cmdletContext.ReplicationTaskArn;
            }
            if (cmdletContext.StartReplicationTaskType != null)
            {
                request.StartReplicationTaskType = cmdletContext.StartReplicationTaskType;
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
        
        private Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.StartReplicationTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "StartReplicationTask");
            try
            {
                #if DESKTOP
                return client.StartReplicationTask(request);
                #elif CORECLR
                return client.StartReplicationTaskAsync(request).GetAwaiter().GetResult();
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
            public System.String CdcStartPosition { get; set; }
            public System.DateTime? CdcStartTime { get; set; }
            public System.String CdcStopPosition { get; set; }
            public System.String ReplicationTaskArn { get; set; }
            public Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue StartReplicationTaskType { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse, StartDMSReplicationTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationTask;
        }
        
    }
}
