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
using Amazon.RDS;
using Amazon.RDS.Model;

namespace Amazon.PowerShell.Cmdlets.RDS
{
    /// <summary>
    /// Deletes automated backups using the <c>DbiResourceId</c> value of the source DB instance
    /// or the Amazon Resource Name (ARN) of the automated backups.
    /// </summary>
    [Cmdlet("Remove", "RDSDBInstanceAutomatedBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.RDS.Model.DBInstanceAutomatedBackup")]
    [AWSCmdlet("Calls the Amazon Relational Database Service DeleteDBInstanceAutomatedBackup API operation.", Operation = new[] {"DeleteDBInstanceAutomatedBackup"}, SelectReturnType = typeof(Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupResponse))]
    [AWSCmdletOutput("Amazon.RDS.Model.DBInstanceAutomatedBackup or Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupResponse",
        "This cmdlet returns an Amazon.RDS.Model.DBInstanceAutomatedBackup object.",
        "The service call response (type Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveRDSDBInstanceAutomatedBackupCmdlet : AmazonRDSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DBInstanceAutomatedBackupsArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the automated backups to delete, for example, <c>arn:aws:rds:us-east-1:123456789012:auto-backup:ab-L2IJCEXJP7XQ7HOJ4SIEXAMPLE</c>.</para><para>This setting doesn't apply to RDS Custom.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DBInstanceAutomatedBackupsArn { get; set; }
        #endregion
        
        #region Parameter DbiResourceId
        /// <summary>
        /// <para>
        /// <para>The identifier for the source DB instance, which can't be changed and which is unique
        /// to an Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String DbiResourceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DBInstanceAutomatedBackup'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupResponse).
        /// Specifying the name of a property of type Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DBInstanceAutomatedBackup";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DbiResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-RDSDBInstanceAutomatedBackup (DeleteDBInstanceAutomatedBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupResponse, RemoveRDSDBInstanceAutomatedBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DBInstanceAutomatedBackupsArn = this.DBInstanceAutomatedBackupsArn;
            context.DbiResourceId = this.DbiResourceId;
            
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
            var request = new Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupRequest();
            
            if (cmdletContext.DBInstanceAutomatedBackupsArn != null)
            {
                request.DBInstanceAutomatedBackupsArn = cmdletContext.DBInstanceAutomatedBackupsArn;
            }
            if (cmdletContext.DbiResourceId != null)
            {
                request.DbiResourceId = cmdletContext.DbiResourceId;
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
        
        private Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupResponse CallAWSServiceOperation(IAmazonRDS client, Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Relational Database Service", "DeleteDBInstanceAutomatedBackup");
            try
            {
                #if DESKTOP
                return client.DeleteDBInstanceAutomatedBackup(request);
                #elif CORECLR
                return client.DeleteDBInstanceAutomatedBackupAsync(request).GetAwaiter().GetResult();
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
            public System.String DBInstanceAutomatedBackupsArn { get; set; }
            public System.String DbiResourceId { get; set; }
            public System.Func<Amazon.RDS.Model.DeleteDBInstanceAutomatedBackupResponse, RemoveRDSDBInstanceAutomatedBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DBInstanceAutomatedBackup;
        }
        
    }
}
