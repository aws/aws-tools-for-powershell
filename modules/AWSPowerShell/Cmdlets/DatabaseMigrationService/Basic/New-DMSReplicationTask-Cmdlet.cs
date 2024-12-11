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
using Amazon.DatabaseMigrationService;
using Amazon.DatabaseMigrationService.Model;

namespace Amazon.PowerShell.Cmdlets.DMS
{
    /// <summary>
    /// Creates a replication task using the specified parameters.
    /// </summary>
    [Cmdlet("New", "DMSReplicationTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationTask")]
    [AWSCmdlet("Calls the AWS Database Migration Service CreateReplicationTask API operation.", Operation = new[] {"CreateReplicationTask"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationTask or Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.ReplicationTask object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewDMSReplicationTaskCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
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
        
        #region Parameter MigrationType
        /// <summary>
        /// <para>
        /// <para>The migration type. Valid values: <c>full-load</c> | <c>cdc</c> | <c>full-load-and-cdc</c></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.MigrationTypeValue")]
        public Amazon.DatabaseMigrationService.MigrationTypeValue MigrationType { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a replication instance.</para>
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
        public System.String ReplicationInstanceArn { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskIdentifier
        /// <summary>
        /// <para>
        /// <para>An identifier for the replication task.</para><para>Constraints:</para><ul><li><para>Must contain 1-255 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
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
        public System.String ReplicationTaskIdentifier { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskSetting
        /// <summary>
        /// <para>
        /// <para>Overall settings for the task, in JSON format. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.CustomizingTasks.TaskSettings.html">Specifying
        /// Task Settings for Database Migration Service Tasks</a> in the <i>Database Migration
        /// Service User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ReplicationTaskSettings")]
        public System.String ReplicationTaskSetting { get; set; }
        #endregion
        
        #region Parameter ResourceIdentifier
        /// <summary>
        /// <para>
        /// <para>A friendly name for the resource identifier at the end of the <c>EndpointArn</c> response
        /// parameter that is returned in the created <c>Endpoint</c> object. The value for this
        /// parameter can have up to 31 characters. It can contain only ASCII letters, digits,
        /// and hyphen ('-'). Also, it can't end with a hyphen or contain two consecutive hyphens,
        /// and can only begin with a letter, such as <c>Example-App-ARN1</c>. For example, this
        /// value might result in the <c>EndpointArn</c> value <c>arn:aws:dms:eu-west-1:012345678901:rep:Example-App-ARN1</c>.
        /// If you don't specify a <c>ResourceIdentifier</c> value, DMS generates a default identifier
        /// value for the end of <c>EndpointArn</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ResourceIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceEndpointArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) that uniquely identifies the source endpoint.</para>
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
        public System.String SourceEndpointArn { get; set; }
        #endregion
        
        #region Parameter TableMapping
        /// <summary>
        /// <para>
        /// <para>The table mappings for the task, in JSON format. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.CustomizingTasks.TableMapping.html">Using
        /// Table Mapping to Specify Task Settings</a> in the <i>Database Migration Service User
        /// Guide.</i></para>
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
        [Alias("TableMappings")]
        public System.String TableMapping { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>One or more tags to be assigned to the replication task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetEndpointArn
        /// <summary>
        /// <para>
        /// <para>An Amazon Resource Name (ARN) that uniquely identifies the target endpoint.</para>
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
        public System.String TargetEndpointArn { get; set; }
        #endregion
        
        #region Parameter TaskData
        /// <summary>
        /// <para>
        /// <para>Supplemental information that the task requires to migrate the data for certain source
        /// and target endpoints. For more information, see <a href="https://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.TaskData.html">Specifying
        /// Supplemental Data for Task Settings</a> in the <i>Database Migration Service User
        /// Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskData { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ReplicationTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ReplicationTask";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSReplicationTask (CreateReplicationTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse, NewDMSReplicationTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CdcStartPosition = this.CdcStartPosition;
            context.CdcStartTime = this.CdcStartTime;
            context.CdcStopPosition = this.CdcStopPosition;
            context.MigrationType = this.MigrationType;
            #if MODULAR
            if (this.MigrationType == null && ParameterWasBound(nameof(this.MigrationType)))
            {
                WriteWarning("You are passing $null as a value for parameter MigrationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationInstanceArn = this.ReplicationInstanceArn;
            #if MODULAR
            if (this.ReplicationInstanceArn == null && ParameterWasBound(nameof(this.ReplicationInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationTaskIdentifier = this.ReplicationTaskIdentifier;
            #if MODULAR
            if (this.ReplicationTaskIdentifier == null && ParameterWasBound(nameof(this.ReplicationTaskIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationTaskIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ReplicationTaskSetting = this.ReplicationTaskSetting;
            context.ResourceIdentifier = this.ResourceIdentifier;
            context.SourceEndpointArn = this.SourceEndpointArn;
            #if MODULAR
            if (this.SourceEndpointArn == null && ParameterWasBound(nameof(this.SourceEndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceEndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TableMapping = this.TableMapping;
            #if MODULAR
            if (this.TableMapping == null && ParameterWasBound(nameof(this.TableMapping)))
            {
                WriteWarning("You are passing $null as a value for parameter TableMapping which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
            context.TargetEndpointArn = this.TargetEndpointArn;
            #if MODULAR
            if (this.TargetEndpointArn == null && ParameterWasBound(nameof(this.TargetEndpointArn)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetEndpointArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TaskData = this.TaskData;
            
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
            var request = new Amazon.DatabaseMigrationService.Model.CreateReplicationTaskRequest();
            
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
            if (cmdletContext.MigrationType != null)
            {
                request.MigrationType = cmdletContext.MigrationType;
            }
            if (cmdletContext.ReplicationInstanceArn != null)
            {
                request.ReplicationInstanceArn = cmdletContext.ReplicationInstanceArn;
            }
            if (cmdletContext.ReplicationTaskIdentifier != null)
            {
                request.ReplicationTaskIdentifier = cmdletContext.ReplicationTaskIdentifier;
            }
            if (cmdletContext.ReplicationTaskSetting != null)
            {
                request.ReplicationTaskSettings = cmdletContext.ReplicationTaskSetting;
            }
            if (cmdletContext.ResourceIdentifier != null)
            {
                request.ResourceIdentifier = cmdletContext.ResourceIdentifier;
            }
            if (cmdletContext.SourceEndpointArn != null)
            {
                request.SourceEndpointArn = cmdletContext.SourceEndpointArn;
            }
            if (cmdletContext.TableMapping != null)
            {
                request.TableMappings = cmdletContext.TableMapping;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TargetEndpointArn != null)
            {
                request.TargetEndpointArn = cmdletContext.TargetEndpointArn;
            }
            if (cmdletContext.TaskData != null)
            {
                request.TaskData = cmdletContext.TaskData;
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
        
        private Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.CreateReplicationTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "CreateReplicationTask");
            try
            {
                #if DESKTOP
                return client.CreateReplicationTask(request);
                #elif CORECLR
                return client.CreateReplicationTaskAsync(request).GetAwaiter().GetResult();
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
            public Amazon.DatabaseMigrationService.MigrationTypeValue MigrationType { get; set; }
            public System.String ReplicationInstanceArn { get; set; }
            public System.String ReplicationTaskIdentifier { get; set; }
            public System.String ReplicationTaskSetting { get; set; }
            public System.String ResourceIdentifier { get; set; }
            public System.String SourceEndpointArn { get; set; }
            public System.String TableMapping { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tag { get; set; }
            public System.String TargetEndpointArn { get; set; }
            public System.String TaskData { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse, NewDMSReplicationTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ReplicationTask;
        }
        
    }
}
