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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates or updates a <i>field index policy</i> for the specified log group. Only log
    /// groups in the Standard log class support field index policies. For more information
    /// about log classes, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CloudWatch_Logs_Log_Classes.html">Log
    /// classes</a>.
    /// 
    ///  
    /// <para>
    /// You can use field index policies to create <i>field indexes</i> on fields found in
    /// log events in the log group. Creating field indexes speeds up and lowers the costs
    /// for CloudWatch Logs Insights queries that reference those field indexes, because these
    /// queries attempt to skip the processing of log events that are known to not match the
    /// indexed field. Good fields to index are fields that you often need to query for and
    /// fields or values that match only a small fraction of the total log events. Common
    /// examples of indexes include request ID, session ID, userID, and instance IDs. For
    /// more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CloudWatchLogs-Field-Indexing.html">Create
    /// field indexes to improve query performance and reduce costs</a>.
    /// </para><para>
    /// To find the fields that are in your log group events, use the <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_GetLogGroupFields.html">GetLogGroupFields</a>
    /// operation.
    /// </para><para>
    /// For example, suppose you have created a field index for <c>requestId</c>. Then, any
    /// CloudWatch Logs Insights query on that log group that includes <c>requestId = <i>value</i></c> or <c>requestId IN [<i>value</i>, <i>value</i>, ...]</c> will process fewer log
    /// events to reduce costs, and have improved performance.
    /// </para><para>
    /// Each index policy has the following quotas and restrictions:
    /// </para><ul><li><para>
    /// As many as 20 fields can be included in the policy.
    /// </para></li><li><para>
    /// Each field name can include as many as 100 characters.
    /// </para></li></ul><para>
    /// Matches of log events to the names of indexed fields are case-sensitive. For example,
    /// a field index of <c>RequestId</c> won't match a log event containing <c>requestId</c>.
    /// </para><para>
    /// Log group-level field index policies created with <c>PutIndexPolicy</c> override account-level
    /// field index policies created with <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutAccountPolicy.html">PutAccountPolicy</a>.
    /// If you use <c>PutIndexPolicy</c> to create a field index policy for a log group, that
    /// log group uses only that policy. The log group ignores any account-wide field index
    /// policy that you might have created.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLIndexPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.IndexPolicy")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutIndexPolicy API operation.", Operation = new[] {"PutIndexPolicy"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutIndexPolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.IndexPolicy or Amazon.CloudWatchLogs.Model.PutIndexPolicyResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.IndexPolicy object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutIndexPolicyResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLIndexPolicyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>Specify either the log group name or log group ARN to apply this field index policy
        /// to. If you specify an ARN, use the format arn:aws:logs:<i>region</i>:<i>account-id</i>:log-group:<i>log_group_name</i>
        /// Don't include an * at the end.</para>
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
        public System.String LogGroupIdentifier { get; set; }
        #endregion
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>The index policy document, in JSON format. The following is an example of an index
        /// policy document that creates two indexes, <c>RequestId</c> and <c>TransactionId</c>.</para><para><c>"policyDocument": "{ "Fields": [ "RequestId", "TransactionId" ] }"</c></para><para>The policy document must include at least one field index. For more information about
        /// the fields that can be included and other restrictions, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CloudWatchLogs-Field-Indexing-Syntax.html">Field
        /// index syntax and quotas</a>.</para>
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
        public System.String PolicyDocument { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IndexPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutIndexPolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.PutIndexPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IndexPolicy";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LogGroupIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LogGroupIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LogGroupIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLIndexPolicy (PutIndexPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutIndexPolicyResponse, WriteCWLIndexPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LogGroupIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LogGroupIdentifier = this.LogGroupIdentifier;
            #if MODULAR
            if (this.LogGroupIdentifier == null && ParameterWasBound(nameof(this.LogGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyDocument = this.PolicyDocument;
            #if MODULAR
            if (this.PolicyDocument == null && ParameterWasBound(nameof(this.PolicyDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.PutIndexPolicyRequest();
            
            if (cmdletContext.LogGroupIdentifier != null)
            {
                request.LogGroupIdentifier = cmdletContext.LogGroupIdentifier;
            }
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
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
        
        private Amazon.CloudWatchLogs.Model.PutIndexPolicyResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutIndexPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutIndexPolicy");
            try
            {
                #if DESKTOP
                return client.PutIndexPolicy(request);
                #elif CORECLR
                return client.PutIndexPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String LogGroupIdentifier { get; set; }
            public System.String PolicyDocument { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutIndexPolicyResponse, WriteCWLIndexPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IndexPolicy;
        }
        
    }
}
