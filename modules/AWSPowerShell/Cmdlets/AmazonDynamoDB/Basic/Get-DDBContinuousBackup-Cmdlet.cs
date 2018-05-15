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
    /// Checks the status of continuous backups and point in time recovery on the specified
    /// table. Continuous backups are <code>ENABLED</code> on all tables at table creation.
    /// If point in time recovery is enabled, <code>PointInTimeRecoveryStatus</code> will
    /// be set to ENABLED.
    /// 
    ///  
    /// <para>
    ///  Once continuous backups and point in time recovery are enabled, you can restore to
    /// any point in time within <code>EarliestRestorableDateTime</code> and <code>LatestRestorableDateTime</code>.
    /// 
    /// </para><para><code>LatestRestorableDateTime</code> is typically 5 minutes before the current time.
    /// You can restore your table to any point in time during the last 35 days. 
    /// </para><para>
    /// You can call <code>DescribeContinuousBackups</code> at a maximum rate of 10 times
    /// per second.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBContinuousBackup")]
    [OutputType("Amazon.DynamoDBv2.Model.ContinuousBackupsDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB DescribeContinuousBackups API operation.", Operation = new[] {"DescribeContinuousBackups"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ContinuousBackupsDescription",
        "This cmdlet returns a ContinuousBackupsDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDDBContinuousBackupCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>Name of the table for which the customer wants to check the continuous backups and
        /// point in time recovery settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
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
            var request = new Amazon.DynamoDBv2.Model.DescribeContinuousBackupsRequest();
            
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
                object pipelineOutput = response.ContinuousBackupsDescription;
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
        
        private Amazon.DynamoDBv2.Model.DescribeContinuousBackupsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.DescribeContinuousBackupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "DescribeContinuousBackups");
            try
            {
                #if DESKTOP
                return client.DescribeContinuousBackups(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DescribeContinuousBackupsAsync(request);
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
            public System.String TableName { get; set; }
        }
        
    }
}
