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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Promotes a read replica DB instance to a standalone DB instance.
    /// 
    ///  <note><ul><li><para>
    /// Backup duration is a function of the amount of changes to the database since the previous
    /// backup. If you plan to promote a read replica to a standalone instance, we recommend
    /// that you enable backups and complete at least one backup prior to promotion. In addition,
    /// a read replica cannot be promoted to a standalone instance when it is in the <code>backing-up</code>
    /// status. If you have enabled backups on your read replica, configure the automated
    /// backup window so that daily backups do not interfere with read replica promotion.
    /// </para></li><li><para>
    /// This command doesn't apply to Aurora MySQL and Aurora PostgreSQL.
    /// </para></li></ul></note>
    /// </summary>
    [Cmdlet("Convert", "RDSReadReplicaToStandalone", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstance")]
    [AWSCmdlet("Calls the Amazon Relational Database Service PromoteReadReplica API operation.", Operation = new[] {"PromoteReadReplica"}, SelectReturnType = typeof(Amazon.RDS.Model.PromoteReadReplicaResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstance or Amazon.RDS.Model.PromoteReadReplicaResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstance object.",
        "The service call response (type Amazon.RDS.Model.PromoteReadReplicaResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class ConvertRDSReadReplicaToStandaloneCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        #region Parameter BackupRetentionPeriod
        /// <summary>
        /// <para>
        /// <para>The number of days for which automated backups are retained. Setting this parameter
        /// to a positive number enables backups. Setting this parameter to 0 disables automated
        /// backups.</para><para>Default: 1</para><para>Constraints:</para><ul><li><para>Must be a value from 0 to 35.</para></li><li><para>Can't be set to 0 if the DB instance is a source to read replicas.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BackupRetentionPeriod { get; set; }
        #endregion
        
        #region Parameter DBInstanceIdentifier
        /// <summary>
        /// <para>
        /// <para>The DB instance identifier. This value is stored as a lowercase string.</para><para>Constraints:</para><ul><li><para>Must match the identifier of an existing read replica DB instance.</para></li></ul><para>Example: <code>mydbinstance</code></para>
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
        public System.String DBInstanceIdentifier { get; set; }
        #endregion
        
        #region Parameter PreferredBackupWindow
        /// <summary>
        /// <para>
        /// <para> The daily time range during which automated backups are created if automated backups
        /// are enabled, using the <code>BackupRetentionPeriod</code> parameter. </para><para> The default is a 30-minute window selected at random from an 8-hour block of time
        /// for each AWS Region. To see the time blocks available, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/AdjustingTheMaintenanceWindow.html">
        /// Adjusting the Preferred Maintenance Window</a> in the <i>Amazon RDS User Guide.</i></para><para>Constraints:</para><ul><li><para>Must be in the format <code>hh24:mi-hh24:mi</code>.</para></li><li><para>Must be in Universal Coordinated Time (UTC).</para></li><li><para>Must not conflict with the preferred maintenance window.</para></li><li><para>Must be at least 30 minutes.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PreferredBackupWindow { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstance'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.PromoteReadReplicaResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.PromoteReadReplicaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstance";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DBInstanceIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DBInstanceIdentifier' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DBInstanceIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Convert-RDSReadReplicaToStandalone (PromoteReadReplica)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.PromoteReadReplicaResponse, ConvertRDSReadReplicaToStandaloneCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DBInstanceIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupRetentionPeriod = this.BackupRetentionPeriod;
            context.DBInstanceIdentifier = this.DBInstanceIdentifier;
            #if MODULAR
            if (this.DBInstanceIdentifier == null && ParameterWasBound(nameof(this.DBInstanceIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter DBInstanceIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PreferredBackupWindow = this.PreferredBackupWindow;
            
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
            var request = new Amazon.RDS.Model.PromoteReadReplicaRequest();
            
            if (cmdletContext.BackupRetentionPeriod != null)
            {
                request.BackupRetentionPeriod = cmdletContext.BackupRetentionPeriod.Value;
            }
            if (cmdletContext.DBInstanceIdentifier != null)
            {
                request.DBInstanceIdentifier = cmdletContext.DBInstanceIdentifier;
            }
            if (cmdletContext.PreferredBackupWindow != null)
            {
                request.PreferredBackupWindow = cmdletContext.PreferredBackupWindow;
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
        
        private Amazon.RDS.Model.PromoteReadReplicaResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.PromoteReadReplicaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "PromoteReadReplica");
            try
            {
                #if DESKTOP
                return client.PromoteReadReplica(request);
                #elif CORECLR
                return client.PromoteReadReplicaAsync(request).GetAwaiter().GetResult();
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
            public System.Int32? BackupRetentionPeriod { get; set; }
            public System.String DBInstanceIdentifier { get; set; }
            public System.String PreferredBackupWindow { get; set; }
            public System.Func<Amazon.RDS.Model.PromoteReadReplicaResponse, ConvertRDSReadReplicaToStandaloneCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstance;
        }
        
    }
}
