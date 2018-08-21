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
    /// List backups associated with an AWS account. To list backups for a given table, specify
    /// <code>TableName</code>. <code>ListBackups</code> returns a paginated list of results
    /// with at most 1MB worth of items in a page. You can also specify a limit for the maximum
    /// number of entries to be returned in a page. 
    /// 
    ///  
    /// <para>
    /// In the request, start time is inclusive but end time is exclusive. Note that these
    /// limits are for the time at which the original backup was requested.
    /// </para><para>
    /// You can call <code>ListBackups</code> a maximum of 5 times per second.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "DDBBackupsList")]
    [OutputType("Amazon.DynamoDBv2.Model.ListBackupsResponse")]
    [AWSCmdlet("Calls the Amazon DynamoDB ListBackups API operation.", Operation = new[] {"ListBackups"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.ListBackupsResponse",
        "This cmdlet returns a Amazon.DynamoDBv2.Model.ListBackupsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetDDBBackupsListCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter BackupType
        /// <summary>
        /// <para>
        /// <para>The backups from the table specified by <code>BackupType</code> are listed.</para><para>Where <code>BackupType</code> can be:</para><ul><li><para><code>USER</code> - On-demand backup created by you.</para></li><li><para><code>SYSTEM</code> - On-demand backup automatically created by DynamoDB.</para></li><li><para><code>ALL</code> - All types of on-demand backups (USER and SYSTEM).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.DynamoDBv2.BackupTypeFilter")]
        public Amazon.DynamoDBv2.BackupTypeFilter BackupType { get; set; }
        #endregion
        
        #region Parameter ExclusiveStartBackupArn
        /// <summary>
        /// <para>
        /// <para><code>LastEvaluatedBackupArn</code> is the ARN of the backup last evaluated when
        /// the current page of results was returned, inclusive of the current page of results.
        /// This value may be specified as the <code>ExclusiveStartBackupArn</code> of a new <code>ListBackups</code>
        /// operation in order to fetch the next page of results. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ExclusiveStartBackupArn { get; set; }
        #endregion
        
        #region Parameter TableName
        /// <summary>
        /// <para>
        /// <para>The backups from the table specified by <code>TableName</code> are listed. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String TableName { get; set; }
        #endregion
        
        #region Parameter TimeRangeLowerBound
        /// <summary>
        /// <para>
        /// <para>Only backups created after this time are listed. <code>TimeRangeLowerBound</code>
        /// is inclusive.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime TimeRangeLowerBound { get; set; }
        #endregion
        
        #region Parameter TimeRangeUpperBound
        /// <summary>
        /// <para>
        /// <para>Only backups created before this time are listed. <code>TimeRangeUpperBound</code>
        /// is exclusive. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime TimeRangeUpperBound { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>Maximum number of backups to return at once.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> This parameter is only used if you are manually controlling output pagination of the service API call.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("MaxItems")]
        public int Limit { get; set; }
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
            
            context.BackupType = this.BackupType;
            context.ExclusiveStartBackupArn = this.ExclusiveStartBackupArn;
            if (ParameterWasBound("Limit"))
                context.Limit = this.Limit;
            context.TableName = this.TableName;
            if (ParameterWasBound("TimeRangeLowerBound"))
                context.TimeRangeLowerBound = this.TimeRangeLowerBound;
            if (ParameterWasBound("TimeRangeUpperBound"))
                context.TimeRangeUpperBound = this.TimeRangeUpperBound;
            
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
            var request = new Amazon.DynamoDBv2.Model.ListBackupsRequest();
            
            if (cmdletContext.BackupType != null)
            {
                request.BackupType = cmdletContext.BackupType;
            }
            if (cmdletContext.ExclusiveStartBackupArn != null)
            {
                request.ExclusiveStartBackupArn = cmdletContext.ExclusiveStartBackupArn;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = AutoIterationHelpers.ConvertEmitLimitToServiceTypeInt32(cmdletContext.Limit.Value);
            }
            if (cmdletContext.TableName != null)
            {
                request.TableName = cmdletContext.TableName;
            }
            if (cmdletContext.TimeRangeLowerBound != null)
            {
                request.TimeRangeLowerBound = cmdletContext.TimeRangeLowerBound.Value;
            }
            if (cmdletContext.TimeRangeUpperBound != null)
            {
                request.TimeRangeUpperBound = cmdletContext.TimeRangeUpperBound.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
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
        
        private Amazon.DynamoDBv2.Model.ListBackupsResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.ListBackupsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "ListBackups");
            try
            {
                #if DESKTOP
                return client.ListBackups(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.ListBackupsAsync(request);
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
            public Amazon.DynamoDBv2.BackupTypeFilter BackupType { get; set; }
            public System.String ExclusiveStartBackupArn { get; set; }
            public int? Limit { get; set; }
            public System.String TableName { get; set; }
            public System.DateTime? TimeRangeLowerBound { get; set; }
            public System.DateTime? TimeRangeUpperBound { get; set; }
        }
        
    }
}
