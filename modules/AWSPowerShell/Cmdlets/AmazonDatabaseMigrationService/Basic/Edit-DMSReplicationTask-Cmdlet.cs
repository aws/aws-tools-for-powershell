/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Modifies the specified replication task.
    /// 
    ///  
    /// <para>
    /// You can't modify the task endpoints. The task must be stopped before you can modify
    /// it. 
    /// </para><para>
    /// For more information about AWS DMS tasks, see the AWS DMS user guide at <a href="http://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.html">
    /// Working with Migration Tasks </a></para>
    /// </summary>
    [Cmdlet("Edit", "DMSReplicationTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationTask")]
    [AWSCmdlet("Calls the AWS Database Migration Service ModifyReplicationTask API operation.", Operation = new[] {"ModifyReplicationTask"})]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationTask",
        "This cmdlet returns a ReplicationTask object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.ModifyReplicationTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class EditDMSReplicationTaskCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CdcStartPosition
        /// <summary>
        /// <para>
        /// <para>Indicates when you want a change data capture (CDC) operation to start. Use either
        /// CdcStartPosition or CdcStartTime to specify when you want a CDC operation to start.
        /// Specifying both values results in an error.</para><para> The value can be in date, checkpoint, or LSN/SCN format.</para><para>Date Example: --cdc-start-position “2018-03-08T12:12:12”</para><para>Checkpoint Example: --cdc-start-position "checkpoint:V1#27#mysql-bin-changelog.157832:1975:-1:2002:677883278264080:mysql-bin-changelog.157832:1876#0#0#*#0#93"</para><para>LSN Example: --cdc-start-position “mysql-bin-changelog.000024:373”</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
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
        [System.Management.Automation.Parameter]
        public System.DateTime CdcStartTime { get; set; }
        #endregion
        
        #region Parameter CdcStopPosition
        /// <summary>
        /// <para>
        /// <para>Indicates when you want a change data capture (CDC) operation to stop. The value can
        /// be either server time or commit time.</para><para>Server time example: --cdc-stop-position “server_time:3018-02-09T12:12:12”</para><para>Commit time example: --cdc-stop-position “commit_time: 3018-02-09T12:12:12 “</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CdcStopPosition { get; set; }
        #endregion
        
        #region Parameter MigrationType
        /// <summary>
        /// <para>
        /// <para>The migration type.</para><para>Valid values: full-load | cdc | full-load-and-cdc</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.MigrationTypeValue")]
        public Amazon.DatabaseMigrationService.MigrationTypeValue MigrationType { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the replication task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationTaskArn { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskIdentifier
        /// <summary>
        /// <para>
        /// <para>The replication task identifier.</para><para>Constraints:</para><ul><li><para>Must contain from 1 to 255 alphanumeric characters or hyphens.</para></li><li><para>First character must be a letter.</para></li><li><para>Cannot end with a hyphen or contain two consecutive hyphens.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReplicationTaskIdentifier { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskSetting
        /// <summary>
        /// <para>
        /// <para>JSON file that contains settings for the task, such as target metadata settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReplicationTaskSettings")]
        public System.String ReplicationTaskSetting { get; set; }
        #endregion
        
        #region Parameter TableMapping
        /// <summary>
        /// <para>
        /// <para>When using the AWS CLI or boto3, provide the path of the JSON file that contains the
        /// table mappings. Precede the path with "file://". When working with the DMS API, provide
        /// the JSON as the parameter value.</para><para>For example, --table-mappings file://mappingfile.json</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TableMappings")]
        public System.String TableMapping { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReplicationTaskArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Edit-DMSReplicationTask (ModifyReplicationTask)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.CdcStartPosition = this.CdcStartPosition;
            if (ParameterWasBound("CdcStartTime"))
                context.CdcStartTime = this.CdcStartTime;
            context.CdcStopPosition = this.CdcStopPosition;
            context.MigrationType = this.MigrationType;
            context.ReplicationTaskArn = this.ReplicationTaskArn;
            context.ReplicationTaskIdentifier = this.ReplicationTaskIdentifier;
            context.ReplicationTaskSettings = this.ReplicationTaskSetting;
            context.TableMappings = this.TableMapping;
            
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
            var request = new Amazon.DatabaseMigrationService.Model.ModifyReplicationTaskRequest();
            
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
            if (cmdletContext.ReplicationTaskArn != null)
            {
                request.ReplicationTaskArn = cmdletContext.ReplicationTaskArn;
            }
            if (cmdletContext.ReplicationTaskIdentifier != null)
            {
                request.ReplicationTaskIdentifier = cmdletContext.ReplicationTaskIdentifier;
            }
            if (cmdletContext.ReplicationTaskSettings != null)
            {
                request.ReplicationTaskSettings = cmdletContext.ReplicationTaskSettings;
            }
            if (cmdletContext.TableMappings != null)
            {
                request.TableMappings = cmdletContext.TableMappings;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ReplicationTask;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.DatabaseMigrationService.Model.ModifyReplicationTaskResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.ModifyReplicationTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "ModifyReplicationTask");
            try
            {
                #if DESKTOP
                return client.ModifyReplicationTask(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ModifyReplicationTaskAsync(request);
                return task.Result;
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
            public System.String ReplicationTaskArn { get; set; }
            public System.String ReplicationTaskIdentifier { get; set; }
            public System.String ReplicationTaskSettings { get; set; }
            public System.String TableMappings { get; set; }
        }
        
    }
}
