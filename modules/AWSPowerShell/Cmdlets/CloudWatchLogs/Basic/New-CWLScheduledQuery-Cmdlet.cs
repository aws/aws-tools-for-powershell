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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates a scheduled query that runs CloudWatch Logs Insights queries at regular intervals.
    /// Scheduled queries enable proactive monitoring by automatically executing queries to
    /// detect patterns and anomalies in your log data. Query results can be delivered to
    /// Amazon S3 for analysis or further processing.
    /// </summary>
    [Cmdlet("New", "CWLScheduledQuery", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs CreateScheduledQuery API operation.", Operation = new[] {"CreateScheduledQuery"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse object containing multiple properties."
    )]
    public partial class NewCWLScheduledQueryCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>An optional description for the scheduled query to help identify its purpose and functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter S3Configuration_DestinationIdentifier
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI where query results are delivered. Must be a valid S3 URI format.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_S3Configuration_DestinationIdentifier")]
        public System.String S3Configuration_DestinationIdentifier { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants permissions to execute the query and deliver results
        /// to the specified destination. The role must have permissions to read from the specified
        /// log groups and write to the destination.</para>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>An array of log group names or ARNs to query. You can specify between 1 and 50 log
        /// groups. Log groups can be identified by name or full ARN.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogGroupIdentifiers")]
        public System.String[] LogGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the scheduled query. The name must be unique within your account and region.
        /// Valid characters are alphanumeric characters, hyphens, underscores, and periods. Length
        /// must be between 1 and 255 characters.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter QueryLanguage
        /// <summary>
        /// <para>
        /// <para>The query language to use for the scheduled query. Valid values are <c>LogsQL</c>,
        /// <c>PPL</c>, and <c>SQL</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.QueryLanguage")]
        public Amazon.CloudWatchLogs.QueryLanguage QueryLanguage { get; set; }
        #endregion
        
        #region Parameter QueryString
        /// <summary>
        /// <para>
        /// <para>The query string to execute. This is the same query syntax used in CloudWatch Logs
        /// Insights. Maximum length is 10,000 characters.</para>
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
        public System.String QueryString { get; set; }
        #endregion
        
        #region Parameter S3Configuration_RoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants permissions to write query results to the specified
        /// Amazon S3 destination.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DestinationConfiguration_S3Configuration_RoleArn")]
        public System.String S3Configuration_RoleArn { get; set; }
        #endregion
        
        #region Parameter ScheduleEndTime
        /// <summary>
        /// <para>
        /// <para>The end time for the scheduled query in Unix epoch format. The query will stop executing
        /// after this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ScheduleEndTime { get; set; }
        #endregion
        
        #region Parameter ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>A cron expression that defines when the scheduled query runs. The expression uses
        /// standard cron syntax and supports minute-level precision. Maximum length is 256 characters.</para>
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
        public System.String ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter ScheduleStartTime
        /// <summary>
        /// <para>
        /// <para>The start time for the scheduled query in Unix epoch format. The query will not execute
        /// before this time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ScheduleStartTime { get; set; }
        #endregion
        
        #region Parameter StartTimeOffset
        /// <summary>
        /// <para>
        /// <para>The time offset in seconds that defines the lookback period for the query. This determines
        /// how far back in time the query searches from the execution time.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? StartTimeOffset { get; set; }
        #endregion
        
        #region Parameter State
        /// <summary>
        /// <para>
        /// <para>The initial state of the scheduled query. Valid values are <c>ENABLED</c> and <c>DISABLED</c>.
        /// Default is <c>ENABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.ScheduledQueryState")]
        public Amazon.CloudWatchLogs.ScheduledQueryState State { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Key-value pairs to associate with the scheduled query for resource management and
        /// cost allocation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone for evaluating the schedule expression. This determines when the scheduled
        /// query executes relative to the specified timezone.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Timezone { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.Name),
                nameof(this.ExecutionRoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWLScheduledQuery (CreateScheduledQuery)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse, NewCWLScheduledQueryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.S3Configuration_DestinationIdentifier = this.S3Configuration_DestinationIdentifier;
            context.S3Configuration_RoleArn = this.S3Configuration_RoleArn;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LogGroupIdentifier != null)
            {
                context.LogGroupIdentifier = new List<System.String>(this.LogGroupIdentifier);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryLanguage = this.QueryLanguage;
            #if MODULAR
            if (this.QueryLanguage == null && ParameterWasBound(nameof(this.QueryLanguage)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryLanguage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueryString = this.QueryString;
            #if MODULAR
            if (this.QueryString == null && ParameterWasBound(nameof(this.QueryString)))
            {
                WriteWarning("You are passing $null as a value for parameter QueryString which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleEndTime = this.ScheduleEndTime;
            context.ScheduleExpression = this.ScheduleExpression;
            #if MODULAR
            if (this.ScheduleExpression == null && ParameterWasBound(nameof(this.ScheduleExpression)))
            {
                WriteWarning("You are passing $null as a value for parameter ScheduleExpression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ScheduleStartTime = this.ScheduleStartTime;
            context.StartTimeOffset = this.StartTimeOffset;
            context.State = this.State;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.Timezone = this.Timezone;
            
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
            var request = new Amazon.CloudWatchLogs.Model.CreateScheduledQueryRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate DestinationConfiguration
            var requestDestinationConfigurationIsNull = true;
            request.DestinationConfiguration = new Amazon.CloudWatchLogs.Model.DestinationConfiguration();
            Amazon.CloudWatchLogs.Model.S3Configuration requestDestinationConfiguration_destinationConfiguration_S3Configuration = null;
            
             // populate S3Configuration
            var requestDestinationConfiguration_destinationConfiguration_S3ConfigurationIsNull = true;
            requestDestinationConfiguration_destinationConfiguration_S3Configuration = new Amazon.CloudWatchLogs.Model.S3Configuration();
            System.String requestDestinationConfiguration_destinationConfiguration_S3Configuration_s3Configuration_DestinationIdentifier = null;
            if (cmdletContext.S3Configuration_DestinationIdentifier != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3Configuration_s3Configuration_DestinationIdentifier = cmdletContext.S3Configuration_DestinationIdentifier;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3Configuration_s3Configuration_DestinationIdentifier != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3Configuration.DestinationIdentifier = requestDestinationConfiguration_destinationConfiguration_S3Configuration_s3Configuration_DestinationIdentifier;
                requestDestinationConfiguration_destinationConfiguration_S3ConfigurationIsNull = false;
            }
            System.String requestDestinationConfiguration_destinationConfiguration_S3Configuration_s3Configuration_RoleArn = null;
            if (cmdletContext.S3Configuration_RoleArn != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3Configuration_s3Configuration_RoleArn = cmdletContext.S3Configuration_RoleArn;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3Configuration_s3Configuration_RoleArn != null)
            {
                requestDestinationConfiguration_destinationConfiguration_S3Configuration.RoleArn = requestDestinationConfiguration_destinationConfiguration_S3Configuration_s3Configuration_RoleArn;
                requestDestinationConfiguration_destinationConfiguration_S3ConfigurationIsNull = false;
            }
             // determine if requestDestinationConfiguration_destinationConfiguration_S3Configuration should be set to null
            if (requestDestinationConfiguration_destinationConfiguration_S3ConfigurationIsNull)
            {
                requestDestinationConfiguration_destinationConfiguration_S3Configuration = null;
            }
            if (requestDestinationConfiguration_destinationConfiguration_S3Configuration != null)
            {
                request.DestinationConfiguration.S3Configuration = requestDestinationConfiguration_destinationConfiguration_S3Configuration;
                requestDestinationConfigurationIsNull = false;
            }
             // determine if request.DestinationConfiguration should be set to null
            if (requestDestinationConfigurationIsNull)
            {
                request.DestinationConfiguration = null;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.LogGroupIdentifier != null)
            {
                request.LogGroupIdentifiers = cmdletContext.LogGroupIdentifier;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.QueryLanguage != null)
            {
                request.QueryLanguage = cmdletContext.QueryLanguage;
            }
            if (cmdletContext.QueryString != null)
            {
                request.QueryString = cmdletContext.QueryString;
            }
            if (cmdletContext.ScheduleEndTime != null)
            {
                request.ScheduleEndTime = cmdletContext.ScheduleEndTime.Value;
            }
            if (cmdletContext.ScheduleExpression != null)
            {
                request.ScheduleExpression = cmdletContext.ScheduleExpression;
            }
            if (cmdletContext.ScheduleStartTime != null)
            {
                request.ScheduleStartTime = cmdletContext.ScheduleStartTime.Value;
            }
            if (cmdletContext.StartTimeOffset != null)
            {
                request.StartTimeOffset = cmdletContext.StartTimeOffset.Value;
            }
            if (cmdletContext.State != null)
            {
                request.State = cmdletContext.State;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Timezone != null)
            {
                request.Timezone = cmdletContext.Timezone;
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
        
        private Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.CreateScheduledQueryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "CreateScheduledQuery");
            try
            {
                #if DESKTOP
                return client.CreateScheduledQuery(request);
                #elif CORECLR
                return client.CreateScheduledQueryAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String S3Configuration_DestinationIdentifier { get; set; }
            public System.String S3Configuration_RoleArn { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public List<System.String> LogGroupIdentifier { get; set; }
            public System.String Name { get; set; }
            public Amazon.CloudWatchLogs.QueryLanguage QueryLanguage { get; set; }
            public System.String QueryString { get; set; }
            public System.Int64? ScheduleEndTime { get; set; }
            public System.String ScheduleExpression { get; set; }
            public System.Int64? ScheduleStartTime { get; set; }
            public System.Int64? StartTimeOffset { get; set; }
            public Amazon.CloudWatchLogs.ScheduledQueryState State { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String Timezone { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.CreateScheduledQueryResponse, NewCWLScheduledQueryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
