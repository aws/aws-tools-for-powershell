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
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Creates a backup for an existing table.
    /// 
    ///  
    /// <para>
    ///  Each time you create an On-Demand Backup, the entire table data is backed up. There
    /// is no limit to the number of on-demand backups that can be taken. 
    /// </para><para>
    ///  When you create an On-Demand Backup, a time marker of the request is cataloged, and
    /// the backup is created asynchronously, by applying all changes until the time of the
    /// request to the last full table snapshot. Backup requests are processed instantaneously
    /// and become available for restore within minutes. 
    /// </para><para>
    /// You can call <code>CreateBackup</code> at a maximum rate of 50 times per second.
    /// </para><para>
    /// All backups in DynamoDB work without consuming any provisioned throughput on the table.
    /// </para><para>
    ///  If you submit a backup request on 2018-12-14 at 14:25:00, the backup is guaranteed
    /// to contain all data committed to the table up to 14:24:00, and data committed after
    /// 14:26:00 will not be. The backup may or may not contain data modifications made between
    /// 14:24:00 and 14:26:00. On-Demand Backup does not support causal consistency. 
    /// </para><para>
    ///  Along with data, the following are also included on the backups: 
    /// </para><ul><li><para>
    /// Global secondary indexes (GSIs)
    /// </para></li><li><para>
    /// Local secondary indexes (LSIs)
    /// </para></li><li><para>
    /// Streams
    /// </para></li><li><para>
    /// Provisioned read and write capacity
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "DDBBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.BackupDetails")]
    [AWSCmdlet("Calls the Amazon DynamoDB CreateBackup API operation.", Operation = new[] {"CreateBackup"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.BackupDetails",
        "This cmdlet returns a BackupDetails object.",
        "The service call response (type Amazon.DynamoDBv2.Model.CreateBackupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewDDBBackupCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter BackupName
        /// <summary>
        /// <para>
        /// <para>Specified name for the backup.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BackupName { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The name of the table.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TableName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-DDBBackup (CreateBackup)"))
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
            
            context.BackupName = this.BackupName;
            context.TableName = this.TableName;
            
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
            var request = new Amazon.DynamoDBv2.Model.CreateBackupRequest();
            
            if (cmdletContext.BackupName != null)
            {
                request.BackupName = cmdletContext.BackupName;
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.BackupDetails;
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
        
        private Amazon.DynamoDBv2.Model.CreateBackupResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.CreateBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "CreateBackup");
            try
            {
                #if DESKTOP
                return client.CreateBackup(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateBackupAsync(request);
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
            public System.String BackupName { get; set; }
            public System.String TableName { get; set; }
        }
        
    }
}
