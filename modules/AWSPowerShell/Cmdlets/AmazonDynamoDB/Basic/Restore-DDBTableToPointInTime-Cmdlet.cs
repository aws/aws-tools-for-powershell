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
    /// Restores the specified table to the specified point in time within <code>EarliestRestorableDateTime</code>
    /// and <code>LatestRestorableDateTime</code>. You can restore your table to any point
    /// in time during the last 35 days. Any number of users can execute up to 4 concurrent
    /// restores (any type of restore) in a given account. 
    /// 
    ///  
    /// <para>
    ///  When you restore using point in time recovery, DynamoDB restores your table data
    /// to the state based on the selected date and time (day:hour:minute:second) to a new
    /// table. 
    /// </para><para>
    ///  Along with data, the following are also included on the new restored table using
    /// point in time recovery: 
    /// </para><ul><li><para>
    /// Global secondary indexes (GSIs)
    /// </para></li><li><para>
    /// Local secondary indexes (LSIs)
    /// </para></li><li><para>
    /// Provisioned read and write capacity
    /// </para></li><li><para>
    /// Encryption settings
    /// </para><important><para>
    ///  All these settings come from the current settings of the source table at the time
    /// of restore. 
    /// </para></important></li></ul><para>
    /// You must manually set up the following on the restored table:
    /// </para><ul><li><para>
    /// Auto scaling policies
    /// </para></li><li><para>
    /// IAM policies
    /// </para></li><li><para>
    /// Cloudwatch metrics and alarms
    /// </para></li><li><para>
    /// Tags
    /// </para></li><li><para>
    /// Stream settings
    /// </para></li><li><para>
    /// Time to Live (TTL) settings
    /// </para></li><li><para>
    /// Point in time recovery settings
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Restore", "DDBTableToPointInTime", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB RestoreTableToPointInTime API operation.", Operation = new[] {"RestoreTableToPointInTime"})]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableDescription",
        "This cmdlet returns a TableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.RestoreTableToPointInTimeResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreDDBTableToPointInTimeCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter RestoreDateTime
        /// <summary>
        /// <para>
        /// <para>Time in the past to restore the table to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.DateTime RestoreDateTime { get; set; }
        #endregion
        
        #region Parameter SourceTableName
        /// <summary>
        /// <para>
        /// <para>Name of the source table that is being restored.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceTableName { get; set; }
        #endregion
        
        #region Parameter TargetTableName
        /// <summary>
        /// <para>
        /// <para>The name of the new table to which it must be restored to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String TargetTableName { get; set; }
        #endregion
        
        #region Parameter UseLatestRestorableTime
        /// <summary>
        /// <para>
        /// <para>Restore the table to the latest possible time. <code>LatestRestorableDateTime</code>
        /// is typically 5 minutes before the current time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean UseLatestRestorableTime { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("TargetTableName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-DDBTableToPointInTime (RestoreTableToPointInTime)"))
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
            
            if (ParameterWasBound("RestoreDateTime"))
                context.RestoreDateTime = this.RestoreDateTime;
            context.SourceTableName = this.SourceTableName;
            context.TargetTableName = this.TargetTableName;
            if (ParameterWasBound("UseLatestRestorableTime"))
                context.UseLatestRestorableTime = this.UseLatestRestorableTime;
            
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
            var request = new Amazon.DynamoDBv2.Model.RestoreTableToPointInTimeRequest();
            
            if (cmdletContext.RestoreDateTime != null)
            {
                request.RestoreDateTime = cmdletContext.RestoreDateTime.Value;
            }
            if (cmdletContext.SourceTableName != null)
            {
                request.SourceTableName = cmdletContext.SourceTableName;
            }
            if (cmdletContext.TargetTableName != null)
            {
                request.TargetTableName = cmdletContext.TargetTableName;
            }
            if (cmdletContext.UseLatestRestorableTime != null)
            {
                request.UseLatestRestorableTime = cmdletContext.UseLatestRestorableTime.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.TableDescription;
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
        
        private Amazon.DynamoDBv2.Model.RestoreTableToPointInTimeResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.RestoreTableToPointInTimeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "RestoreTableToPointInTime");
            try
            {
                #if DESKTOP
                return client.RestoreTableToPointInTime(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.RestoreTableToPointInTimeAsync(request);
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
            public System.DateTime? RestoreDateTime { get; set; }
            public System.String SourceTableName { get; set; }
            public System.String TargetTableName { get; set; }
            public System.Boolean? UseLatestRestorableTime { get; set; }
        }
        
    }
}
