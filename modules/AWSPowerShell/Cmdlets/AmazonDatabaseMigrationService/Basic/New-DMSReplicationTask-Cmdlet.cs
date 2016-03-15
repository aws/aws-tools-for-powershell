/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// 
    ///  <note />
    /// </summary>
    [Cmdlet("New", "DMSReplicationTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationTask")]
    [AWSCmdlet("Invokes the CreateReplicationTask operation against AWS Database Migration Service.", Operation = new[] {"CreateReplicationTask"})]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationTask",
        "This cmdlet returns a ReplicationTask object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.CreateReplicationTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public class NewDMSReplicationTaskCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        #region Parameter CdcStartTime
        /// <summary>
        /// <para>
        /// <para>The start time for the Change Data Capture (CDC) operation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime CdcStartTime { get; set; }
        #endregion
        
        #region Parameter MigrationType
        /// <summary>
        /// <para>
        /// <para>The migration type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.MigrationTypeValue")]
        public Amazon.DatabaseMigrationService.MigrationTypeValue MigrationType { get; set; }
        #endregion
        
        #region Parameter ReplicationInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the replication instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationInstanceArn { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskIdentifier
        /// <summary>
        /// <para>
        /// <para>The replication task identifier.</para><para>Constraints:</para><ul><li>Must contain from 1 to 63 alphanumeric characters or hyphens.</li><li>First
        /// character must be a letter.</li><li>Cannot end with a hyphen or contain two consecutive
        /// hyphens.</li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ReplicationTaskIdentifier { get; set; }
        #endregion
        
        #region Parameter ReplicationTaskSetting
        /// <summary>
        /// <para>
        /// <para>Settings for the task, such as target metadata settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ReplicationTaskSettings")]
        public System.String ReplicationTaskSetting { get; set; }
        #endregion
        
        #region Parameter SourceEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) string that uniquely identifies the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceEndpointArn { get; set; }
        #endregion
        
        #region Parameter TableMapping
        /// <summary>
        /// <para>
        /// <para>The path of the JSON file that contains the table mappings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TableMappings")]
        public System.String TableMapping { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags to be added to the replication instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.DatabaseMigrationService.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TargetEndpointArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) string that uniquely identifies the endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String TargetEndpointArn { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ReplicationInstanceArn", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DMSReplicationTask (CreateReplicationTask)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            if (ParameterWasBound("CdcStartTime"))
                context.CdcStartTime = this.CdcStartTime;
            context.MigrationType = this.MigrationType;
            context.ReplicationInstanceArn = this.ReplicationInstanceArn;
            context.ReplicationTaskIdentifier = this.ReplicationTaskIdentifier;
            context.ReplicationTaskSettings = this.ReplicationTaskSetting;
            context.SourceEndpointArn = this.SourceEndpointArn;
            context.TableMappings = this.TableMapping;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.DatabaseMigrationService.Model.Tag>(this.Tag);
            }
            context.TargetEndpointArn = this.TargetEndpointArn;
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DatabaseMigrationService.Model.CreateReplicationTaskRequest();
            
            if (cmdletContext.CdcStartTime != null)
            {
                request.CdcStartTime = cmdletContext.CdcStartTime.Value;
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
            if (cmdletContext.ReplicationTaskSettings != null)
            {
                request.ReplicationTaskSettings = cmdletContext.ReplicationTaskSettings;
            }
            if (cmdletContext.SourceEndpointArn != null)
            {
                request.SourceEndpointArn = cmdletContext.SourceEndpointArn;
            }
            if (cmdletContext.TableMappings != null)
            {
                request.TableMappings = cmdletContext.TableMappings;
            }
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TargetEndpointArn != null)
            {
                request.TargetEndpointArn = cmdletContext.TargetEndpointArn;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = client.CreateReplicationTask(request);
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
        
        
        internal class CmdletContext : ExecutorContext
        {
            public System.DateTime? CdcStartTime { get; set; }
            public Amazon.DatabaseMigrationService.MigrationTypeValue MigrationType { get; set; }
            public System.String ReplicationInstanceArn { get; set; }
            public System.String ReplicationTaskIdentifier { get; set; }
            public System.String ReplicationTaskSettings { get; set; }
            public System.String SourceEndpointArn { get; set; }
            public System.String TableMappings { get; set; }
            public List<Amazon.DatabaseMigrationService.Model.Tag> Tags { get; set; }
            public System.String TargetEndpointArn { get; set; }
        }
        
    }
}
