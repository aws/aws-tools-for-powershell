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
    /// For a given DMS Serverless replication configuration, DMS connects to the source endpoint
    /// and collects the metadata to analyze the replication workload. Using this metadata,
    /// DMS then computes and provisions the required capacity and starts replicating to the
    /// target endpoint using the server resources that DMS has provisioned for the DMS Serverless
    /// replication.
    /// </summary>
    [Cmdlet("Start", "DMSReplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DatabaseMigrationService.Model.Replication")]
    [AWSCmdlet("Calls the AWS Database Migration Service StartReplication API operation.", Operation = new[] {"StartReplication"}, SelectReturnType = typeof(Amazon.DatabaseMigrationService.Model.StartReplicationResponse))]
    [AWSCmdletOutput("Amazon.DatabaseMigrationService.Model.Replication or Amazon.DatabaseMigrationService.Model.StartReplicationResponse",
        "This cmdlet returns an Amazon.DatabaseMigrationService.Model.Replication object.",
        "The service call response (type Amazon.DatabaseMigrationService.Model.StartReplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartDMSReplicationCmdlet : AmazonDatabaseMigrationServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter CdcStartPosition
        /// <summary>
        /// <para>
        /// <para>Indicates when you want a change data capture (CDC) operation to start. Use either
        /// <c>CdcStartPosition</c> or <c>CdcStartTime</c> to specify when you want a CDC operation
        /// to start. Specifying both values results in an error.</para><para>The value can be in date, checkpoint, or LSN/SCN format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CdcStartPosition { get; set; }
        #endregion
        
        #region Parameter CdcStartTime
        /// <summary>
        /// <para>
        /// <para>Indicates the start time for a change data capture (CDC) operation. Use either <c>CdcStartTime</c>
        /// or <c>CdcStartPosition</c> to specify when you want a CDC operation to start. Specifying
        /// both values results in an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? CdcStartTime { get; set; }
        #endregion
        
        #region Parameter CdcStopPosition
        /// <summary>
        /// <para>
        /// <para>Indicates when you want a change data capture (CDC) operation to stop. The value can
        /// be either server time or commit time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CdcStopPosition { get; set; }
        #endregion
        
        #region Parameter ReplicationConfigArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name of the replication for which to start replication.</para>
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
        public System.String ReplicationConfigArn { get; set; }
        #endregion
        
        #region Parameter StartReplicationType
        /// <summary>
        /// <para>
        /// <para>The replication type.</para><para>When the replication type is <c>full-load</c> or <c>full-load-and-cdc</c>, the only
        /// valid value for the first run of the replication is <c>start-replication</c>. This
        /// option will start the replication.</para><para>You can also use <a>ReloadTables</a> to reload specific tables that failed during
        /// replication instead of restarting the replication.</para><para>The <c>resume-processing</c> option isn't applicable for a full-load replication,
        /// because you can't resume partially loaded tables during the full load phase.</para><para>For a <c>full-load-and-cdc</c> replication, DMS migrates table data, and then applies
        /// data changes that occur on the source. To load all the tables again, and start capturing
        /// source changes, use <c>reload-target</c>. Otherwise use <c>resume-processing</c>,
        /// to replicate the changes from the last stop position.</para>
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
        public System.String StartReplicationType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Replication'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DatabaseMigrationService.Model.StartReplicationResponse).
        /// Specifying the name of a property of type Amazon.DatabaseMigrationService.Model.StartReplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Replication";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ReplicationConfigArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-DMSReplication (StartReplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DatabaseMigrationService.Model.StartReplicationResponse, StartDMSReplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CdcStartPosition = this.CdcStartPosition;
            context.CdcStartTime = this.CdcStartTime;
            context.CdcStopPosition = this.CdcStopPosition;
            context.ReplicationConfigArn = this.ReplicationConfigArn;
            #if MODULAR
            if (this.ReplicationConfigArn == null && ParameterWasBound(nameof(this.ReplicationConfigArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ReplicationConfigArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StartReplicationType = this.StartReplicationType;
            #if MODULAR
            if (this.StartReplicationType == null && ParameterWasBound(nameof(this.StartReplicationType)))
            {
                WriteWarning("You are passing $null as a value for parameter StartReplicationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DatabaseMigrationService.Model.StartReplicationRequest();
            
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
            if (cmdletContext.ReplicationConfigArn != null)
            {
                request.ReplicationConfigArn = cmdletContext.ReplicationConfigArn;
            }
            if (cmdletContext.StartReplicationType != null)
            {
                request.StartReplicationType = cmdletContext.StartReplicationType;
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
        
        private Amazon.DatabaseMigrationService.Model.StartReplicationResponse CallAWSServiceOperation(IAmazonDatabaseMigrationService client, Amazon.DatabaseMigrationService.Model.StartReplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Database Migration Service", "StartReplication");
            try
            {
                #if DESKTOP
                return client.StartReplication(request);
                #elif CORECLR
                return client.StartReplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String ReplicationConfigArn { get; set; }
            public System.String StartReplicationType { get; set; }
            public System.Func<Amazon.DatabaseMigrationService.Model.StartReplicationResponse, StartDMSReplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Replication;
        }
        
    }
}
