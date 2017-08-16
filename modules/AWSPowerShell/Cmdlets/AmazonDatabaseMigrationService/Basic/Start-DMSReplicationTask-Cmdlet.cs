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
    /// Starts the replication task.
    /// 
    ///  
    /// <para>
    /// For more information about AWS DMS tasks, see the AWS DMS user guide at <a href="http://docs.aws.amazon.com/dms/latest/userguide/CHAP_Tasks.html">
    /// Working with Migration Tasks </a></para>
    /// </summary>
    [Cmdlet("Start", "DMSReplicationTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.ReplicationTask")]
    [AWSCmdlet("Invokes the StartReplicationTask operation against AWS Database Migration Service.", Operation = new[] {"StartReplicationTask"})]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.ReplicationTask",
        "This cmdlet returns a ReplicationTask object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartDMSReplicationTaskCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
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
        
        #region Parameter ReplicationTaskArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Number (ARN) of the replication task to be started.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ReplicationTaskArn { get; set; }
        #endregion
        
        #region Parameter StartReplicationTaskType
        /// <summary>
        /// <para>
        /// <para>The type of replication task.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue")]
        public Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue StartReplicationTaskType { get; set; }
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DMSReplicationTask (StartReplicationTask)"))
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
            
            if (ParameterWasBound("CdcStartTime"))
                context.CdcStartTime = this.CdcStartTime;
            context.ReplicationTaskArn = this.ReplicationTaskArn;
            context.StartReplicationTaskType = this.StartReplicationTaskType;
            
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
            
            if (cmdletContext.CdcStartTime != null)
            {
                request.CdcStartTime = cmdletContext.CdcStartTime.Value;
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
        
        private Amazon.DatabaseMigrationService.Model.StartReplicationTaskResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.StartReplicationTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "StartReplicationTask");
            try
            {
                #if DESKTOP
                return client.StartReplicationTask(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartReplicationTaskAsync(request);
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
            public System.DateTime? CdcStartTime { get; set; }
            public System.String ReplicationTaskArn { get; set; }
            public Amazon.DatabaseMigrationService.StartReplicationTaskTypeValue StartReplicationTaskType { get; set; }
        }
        
    }
}
