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
    /// Stops automated backup replication for a DB instance.
    /// 
    ///  
    /// <para>
    /// This command doesn't apply to RDS Custom, Aurora MySQL, and Aurora PostgreSQL.
    /// </para><para>
    /// For more information, see <a href="https://docs.aws.amazon.com/AmazonRDS/latest/UserGuide/USER_ReplicateBackups.html">
    /// Replicating Automated Backups to Another Amazon Web Services Region</a> in the <i>Amazon
    /// RDS User Guide.</i></para>
    /// </summary>
    [Cmdlet("Stop", "RDSDBInstanceAutomatedBackupsReplication", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.RDS.Model.DBInstanceAutomatedBackup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service StopDBInstanceAutomatedBackupsReplication API operation.", Operation = new[] {"StopDBInstanceAutomatedBackupsReplication"}, SelectReturnType = typeof(Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstanceAutomatedBackup or Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstanceAutomatedBackup object.",
        "The service call response (type Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StopRDSDBInstanceAutomatedBackupsReplicationCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SourceDBInstanceArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the source DB instance for which to stop replicating
        /// automate backups, for example, <c>arn:aws:rds:us-west-2:123456789012:db:mydatabase</c>.</para>
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
        public System.String SourceDBInstanceArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstanceAutomatedBackup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstanceAutomatedBackup";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SourceDBInstanceArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SourceDBInstanceArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SourceDBInstanceArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceDBInstanceArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Stop-RDSDBInstanceAutomatedBackupsReplication (StopDBInstanceAutomatedBackupsReplication)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationResponse, StopRDSDBInstanceAutomatedBackupsReplicationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SourceDBInstanceArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SourceDBInstanceArn = this.SourceDBInstanceArn;
            #if MODULAR
            if (this.SourceDBInstanceArn == null && ParameterWasBound(nameof(this.SourceDBInstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceDBInstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationRequest();
            
            if (cmdletContext.SourceDBInstanceArn != null)
            {
                request.SourceDBInstanceArn = cmdletContext.SourceDBInstanceArn;
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
        
        private Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "StopDBInstanceAutomatedBackupsReplication");
            try
            {
                #if DESKTOP
                return client.StopDBInstanceAutomatedBackupsReplication(request);
                #elif CORECLR
                return client.StopDBInstanceAutomatedBackupsReplicationAsync(request).GetAwaiter().GetResult();
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
            public System.String SourceDBInstanceArn { get; set; }
            public System.Func<Amazon.RDS.Model.StopDBInstanceAutomatedBackupsReplicationResponse, StopRDSDBInstanceAutomatedBackupsReplicationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstanceAutomatedBackup;
        }
        
    }
}
