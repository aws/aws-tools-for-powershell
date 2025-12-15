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
    /// Starts an import from a data source to CloudWatch Log and creates a managed log group
    /// as the destination for the imported data. Currently, <a href="https://docs.aws.amazon.com/awscloudtrail/latest/userguide/query-event-data-store.html">CloudTrail
    /// Event Data Store</a> is the only supported data source. 
    /// 
    ///  
    /// <para>
    /// The import task must satisfy the following constraints:
    /// </para><ul><li><para>
    /// The specified source must be in an ACTIVE state.
    /// </para></li><li><para>
    /// The API caller must have permissions to access the data in the provided source and
    /// to perform iam:PassRole on the provided import role which has the same permissions,
    /// as described below.
    /// </para></li><li><para>
    /// The provided IAM role must trust the "cloudtrail.amazonaws.com" principal and have
    /// the following permissions:
    /// </para><ul><li><para>
    /// cloudtrail:GetEventDataStoreData
    /// </para></li><li><para>
    /// logs:CreateLogGroup
    /// </para></li><li><para>
    /// logs:CreateLogStream
    /// </para></li><li><para>
    /// logs:PutResourcePolicy
    /// </para></li><li><para>
    /// (If source has an associated AWS KMS Key) kms:Decrypt
    /// </para></li><li><para>
    /// (If source has an associated AWS KMS Key) kms:GenerateDataKey
    /// </para></li></ul><para>
    /// Example IAM policy for provided import role:
    /// </para><para><c>[ { "Effect": "Allow", "Action": "iam:PassRole", "Resource": "arn:aws:iam::123456789012:role/apiCallerCredentials",
    /// "Condition": { "StringLike": { "iam:AssociatedResourceARN": "arn:aws:logs:us-east-1:123456789012:log-group:aws/cloudtrail/f1d45bff-d0e3-4868-b5d9-2eb678aa32fb:*"
    /// } } }, { "Effect": "Allow", "Action": [ "cloudtrail:GetEventDataStoreData" ], "Resource":
    /// [ "arn:aws:cloudtrail:us-east-1:123456789012:eventdatastore/f1d45bff-d0e3-4868-b5d9-2eb678aa32fb"
    /// ] }, { "Effect": "Allow", "Action": [ "logs:CreateImportTask", "logs:CreateLogGroup",
    /// "logs:CreateLogStream", "logs:PutResourcePolicy" ], "Resource": [ "arn:aws:logs:us-east-1:123456789012:log-group:/aws/cloudtrail/*"
    /// ] }, { "Effect": "Allow", "Action": [ "kms:Decrypt", "kms:GenerateDataKey" ], "Resource":
    /// [ "arn:aws:kms:us-east-1:123456789012:key/12345678-1234-1234-1234-123456789012" ]
    /// } ]</c></para></li><li><para>
    /// If the import source has a customer managed key, the "cloudtrail.amazonaws.com" principal
    /// needs permissions to perform kms:Decrypt and kms:GenerateDataKey.
    /// </para></li><li><para>
    /// There can be no more than 3 active imports per account at a given time.
    /// </para></li><li><para>
    /// The startEventTime must be less than or equal to endEventTime.
    /// </para></li><li><para>
    /// The data being imported must be within the specified source's retention period.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("New", "CWLCWLImportTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.CreateImportTaskResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs CreateImportTask API operation.", Operation = new[] {"CreateImportTask"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.CreateImportTaskResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.CreateImportTaskResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.CreateImportTaskResponse object containing multiple properties."
    )]
    public partial class NewCWLCWLImportTaskCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ImportFilter_EndEventTime
        /// <summary>
        /// <para>
        /// <para>The end of the time range for events to import, expressed as the number of milliseconds
        /// after Jan 1, 1970 00:00:00 UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ImportFilter_EndEventTime { get; set; }
        #endregion
        
        #region Parameter ImportRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role that grants CloudWatch Logs permission to import from the
        /// CloudTrail Lake Event Data Store.</para>
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
        public System.String ImportRoleArn { get; set; }
        #endregion
        
        #region Parameter ImportSourceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the source to import from.</para>
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
        public System.String ImportSourceArn { get; set; }
        #endregion
        
        #region Parameter ImportFilter_StartEventTime
        /// <summary>
        /// <para>
        /// <para>The start of the time range for events to import, expressed as the number of milliseconds
        /// after Jan 1, 1970 00:00:00 UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? ImportFilter_StartEventTime { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.CreateImportTaskResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.CreateImportTaskResponse will result in that property being returned.
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
                nameof(this.ImportRoleArn),
                nameof(this.ImportSourceArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWLCWLImportTask (CreateImportTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.CreateImportTaskResponse, NewCWLCWLImportTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ImportFilter_EndEventTime = this.ImportFilter_EndEventTime;
            context.ImportFilter_StartEventTime = this.ImportFilter_StartEventTime;
            context.ImportRoleArn = this.ImportRoleArn;
            #if MODULAR
            if (this.ImportRoleArn == null && ParameterWasBound(nameof(this.ImportRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImportSourceArn = this.ImportSourceArn;
            #if MODULAR
            if (this.ImportSourceArn == null && ParameterWasBound(nameof(this.ImportSourceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ImportSourceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.CreateImportTaskRequest();
            
            
             // populate ImportFilter
            var requestImportFilterIsNull = true;
            request.ImportFilter = new Amazon.CloudWatchLogs.Model.ImportFilter();
            System.Int64? requestImportFilter_importFilter_EndEventTime = null;
            if (cmdletContext.ImportFilter_EndEventTime != null)
            {
                requestImportFilter_importFilter_EndEventTime = cmdletContext.ImportFilter_EndEventTime.Value;
            }
            if (requestImportFilter_importFilter_EndEventTime != null)
            {
                request.ImportFilter.EndEventTime = requestImportFilter_importFilter_EndEventTime.Value;
                requestImportFilterIsNull = false;
            }
            System.Int64? requestImportFilter_importFilter_StartEventTime = null;
            if (cmdletContext.ImportFilter_StartEventTime != null)
            {
                requestImportFilter_importFilter_StartEventTime = cmdletContext.ImportFilter_StartEventTime.Value;
            }
            if (requestImportFilter_importFilter_StartEventTime != null)
            {
                request.ImportFilter.StartEventTime = requestImportFilter_importFilter_StartEventTime.Value;
                requestImportFilterIsNull = false;
            }
             // determine if request.ImportFilter should be set to null
            if (requestImportFilterIsNull)
            {
                request.ImportFilter = null;
            }
            if (cmdletContext.ImportRoleArn != null)
            {
                request.ImportRoleArn = cmdletContext.ImportRoleArn;
            }
            if (cmdletContext.ImportSourceArn != null)
            {
                request.ImportSourceArn = cmdletContext.ImportSourceArn;
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
        
        private Amazon.CloudWatchLogs.Model.CreateImportTaskResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.CreateImportTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "CreateImportTask");
            try
            {
                #if DESKTOP
                return client.CreateImportTask(request);
                #elif CORECLR
                return client.CreateImportTaskAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? ImportFilter_EndEventTime { get; set; }
            public System.Int64? ImportFilter_StartEventTime { get; set; }
            public System.String ImportRoleArn { get; set; }
            public System.String ImportSourceArn { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.CreateImportTaskResponse, NewCWLCWLImportTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
