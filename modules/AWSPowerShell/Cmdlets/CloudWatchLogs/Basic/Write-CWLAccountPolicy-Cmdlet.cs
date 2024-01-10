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
    /// Creates an account-level data protection policy or subscription filter policy that
    /// applies to all log groups or a subset of log groups in the account.
    /// 
    ///  
    /// <para><b>Data protection policy</b></para><para>
    /// A data protection policy can help safeguard sensitive data that's ingested by your
    /// log groups by auditing and masking the sensitive log data. Each account can have only
    /// one account-level data protection policy.
    /// </para><important><para>
    /// Sensitive data is detected and masked when it is ingested into a log group. When you
    /// set a data protection policy, log events ingested into the log groups before that
    /// time are not masked.
    /// </para></important><para>
    /// If you use <c>PutAccountPolicy</c> to create a data protection policy for your whole
    /// account, it applies to both existing log groups and all log groups that are created
    /// later in this account. The account-level policy is applied to existing log groups
    /// with eventual consistency. It might take up to 5 minutes before sensitive data in
    /// existing log groups begins to be masked.
    /// </para><para>
    /// By default, when a user views a log event that includes masked data, the sensitive
    /// data is replaced by asterisks. A user who has the <c>logs:Unmask</c> permission can
    /// use a <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_GetLogEvents.html">GetLogEvents</a>
    /// or <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_FilterLogEvents.html">FilterLogEvents</a>
    /// operation with the <c>unmask</c> parameter set to <c>true</c> to view the unmasked
    /// log events. Users with the <c>logs:Unmask</c> can also view unmasked data in the CloudWatch
    /// Logs console by running a CloudWatch Logs Insights query with the <c>unmask</c> query
    /// command.
    /// </para><para>
    /// For more information, including a list of types of data that can be audited and masked,
    /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/mask-sensitive-log-data.html">Protect
    /// sensitive log data with masking</a>.
    /// </para><para>
    /// To use the <c>PutAccountPolicy</c> operation for a data protection policy, you must
    /// be signed on with the <c>logs:PutDataProtectionPolicy</c> and <c>logs:PutAccountPolicy</c>
    /// permissions.
    /// </para><para>
    /// The <c>PutAccountPolicy</c> operation applies to all log groups in the account. You
    /// can use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDataProtectionPolicy.html">PutDataProtectionPolicy</a>
    /// to create a data protection policy that applies to just one log group. If a log group
    /// has its own data protection policy and the account also has an account-level data
    /// protection policy, then the two policies are cumulative. Any sensitive term specified
    /// in either policy is masked.
    /// </para><para><b>Subscription filter policy</b></para><para>
    /// A subscription filter policy sets up a real-time feed of log events from CloudWatch
    /// Logs to other Amazon Web Services services. Account-level subscription filter policies
    /// apply to both existing log groups and log groups that are created later in this account.
    /// Supported destinations are Kinesis Data Streams, Kinesis Data Firehose, and Lambda.
    /// When log events are sent to the receiving service, they are Base64 encoded and compressed
    /// with the GZIP format.
    /// </para><para>
    /// The following destinations are supported for subscription filters:
    /// </para><ul><li><para>
    /// An Kinesis Data Streams data stream in the same account as the subscription policy,
    /// for same-account delivery.
    /// </para></li><li><para>
    /// An Kinesis Data Firehose data stream in the same account as the subscription policy,
    /// for same-account delivery.
    /// </para></li><li><para>
    /// A Lambda function in the same account as the subscription policy, for same-account
    /// delivery.
    /// </para></li><li><para>
    /// A logical destination in a different account created with <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDestination.html">PutDestination</a>,
    /// for cross-account delivery. Kinesis Data Streams and Kinesis Data Firehose are supported
    /// as logical destinations.
    /// </para></li></ul><para>
    /// Each account can have one account-level subscription filter policy. If you are updating
    /// an existing filter, you must specify the correct name in <c>PolicyName</c>. To perform
    /// a <c>PutAccountPolicy</c> subscription filter operation for any destination except
    /// a Lambda function, you must also have the <c>iam:PassRole</c> permission.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLAccountPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.AccountPolicy")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutAccountPolicy API operation.", Operation = new[] {"PutAccountPolicy"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutAccountPolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.AccountPolicy or Amazon.CloudWatchLogs.Model.PutAccountPolicyResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.AccountPolicy object.",
        "The service call response (type Amazon.CloudWatchLogs.Model.PutAccountPolicyResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteCWLAccountPolicyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PolicyDocument
        /// <summary>
        /// <para>
        /// <para>Specify the policy, in JSON.</para><para><b>Data protection policy</b></para><para>A data protection policy must include two JSON blocks:</para><ul><li><para>The first block must include both a <c>DataIdentifer</c> array and an <c>Operation</c>
        /// property with an <c>Audit</c> action. The <c>DataIdentifer</c> array lists the types
        /// of sensitive data that you want to mask. For more information about the available
        /// options, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/mask-sensitive-log-data-types.html">Types
        /// of data that you can mask</a>.</para><para>The <c>Operation</c> property with an <c>Audit</c> action is required to find the
        /// sensitive data terms. This <c>Audit</c> action must contain a <c>FindingsDestination</c>
        /// object. You can optionally use that <c>FindingsDestination</c> object to list one
        /// or more destinations to send audit findings to. If you specify destinations such as
        /// log groups, Kinesis Data Firehose streams, and S3 buckets, they must already exist.</para></li><li><para>The second block must include both a <c>DataIdentifer</c> array and an <c>Operation</c>
        /// property with an <c>Deidentify</c> action. The <c>DataIdentifer</c> array must exactly
        /// match the <c>DataIdentifer</c> array in the first block of the policy.</para><para>The <c>Operation</c> property with the <c>Deidentify</c> action is what actually masks
        /// the data, and it must contain the <c> "MaskConfig": {}</c> object. The <c> "MaskConfig":
        /// {}</c> object must be empty.</para></li></ul><para>For an example data protection policy, see the <b>Examples</b> section on this page.</para><important><para>The contents of the two <c>DataIdentifer</c> arrays must match exactly.</para></important><para>In addition to the two JSON blocks, the <c>policyDocument</c> can also include <c>Name</c>,
        /// <c>Description</c>, and <c>Version</c> fields. The <c>Name</c> is different than the
        /// operation's <c>policyName</c> parameter, and is used as a dimension when CloudWatch
        /// Logs reports audit findings metrics to CloudWatch.</para><para>The JSON specified in <c>policyDocument</c> can be up to 30,720 characters long.</para><para><b>Subscription filter policy</b></para><para>A subscription filter policy can include the following attributes in a JSON block:</para><ul><li><para><b>DestinationArn</b> The ARN of the destination to deliver log events to. Supported
        /// destinations are:</para><ul><li><para>An Kinesis Data Streams data stream in the same account as the subscription policy,
        /// for same-account delivery.</para></li><li><para>An Kinesis Data Firehose data stream in the same account as the subscription policy,
        /// for same-account delivery.</para></li><li><para>A Lambda function in the same account as the subscription policy, for same-account
        /// delivery.</para></li><li><para>A logical destination in a different account created with <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutDestination.html">PutDestination</a>,
        /// for cross-account delivery. Kinesis Data Streams and Kinesis Data Firehose are supported
        /// as logical destinations.</para></li></ul></li><li><para><b>RoleArn</b> The ARN of an IAM role that grants CloudWatch Logs permissions to
        /// deliver ingested log events to the destination stream. You don't need to provide the
        /// ARN when you are working with a logical destination for cross-account delivery.</para></li><li><para><b>FilterPattern</b> A filter pattern for subscribing to a filtered stream of log
        /// events.</para></li><li><para><b>Distribution</b>The method used to distribute log data to the destination. By
        /// default, log data is grouped by log stream, but the grouping can be set to <c>Random</c>
        /// for a more even distribution. This property is only applicable when the destination
        /// is an Kinesis Data Streams data stream.</para></li></ul>
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
        
        #region Parameter PolicyName
        /// <summary>
        /// <para>
        /// <para>A name for the policy. This must be unique within the account.</para>
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
        public System.String PolicyName { get; set; }
        #endregion
        
        #region Parameter PolicyType
        /// <summary>
        /// <para>
        /// <para>The type of policy that you're creating or updating.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.PolicyType")]
        public Amazon.CloudWatchLogs.PolicyType PolicyType { get; set; }
        #endregion
        
        #region Parameter Scope
        /// <summary>
        /// <para>
        /// <para>Currently the only valid value for this parameter is <c>ALL</c>, which specifies that
        /// the data protection policy applies to all log groups in the account. If you omit this
        /// parameter, the default of <c>ALL</c> is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.Scope")]
        public Amazon.CloudWatchLogs.Scope Scope { get; set; }
        #endregion
        
        #region Parameter SelectionCriterion
        /// <summary>
        /// <para>
        /// <para>Use this parameter to apply the subscription filter policy to a subset of log groups
        /// in the account. Currently, the only supported filter is <c>LogGroupName NOT IN []</c>.
        /// The <c>selectionCriteria</c> string can be up to 25KB in length. The length is determined
        /// by using its UTF-8 bytes.</para><para>Using the <c>selectionCriteria</c> parameter is useful to help prevent infinite loops.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/Subscriptions-recursion-prevention.html">Log
        /// recursion prevention</a>.</para><para>Specifing <c>selectionCriteria</c> is valid only when you specify <c> SUBSCRIPTION_FILTER_POLICY</c>
        /// for <c>policyType</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SelectionCriteria")]
        public System.String SelectionCriterion { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountPolicy'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutAccountPolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.PutAccountPolicyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountPolicy";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PolicyName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLAccountPolicy (PutAccountPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutAccountPolicyResponse, WriteCWLAccountPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PolicyDocument = this.PolicyDocument;
            #if MODULAR
            if (this.PolicyDocument == null && ParameterWasBound(nameof(this.PolicyDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyName = this.PolicyName;
            #if MODULAR
            if (this.PolicyName == null && ParameterWasBound(nameof(this.PolicyName)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PolicyType = this.PolicyType;
            #if MODULAR
            if (this.PolicyType == null && ParameterWasBound(nameof(this.PolicyType)))
            {
                WriteWarning("You are passing $null as a value for parameter PolicyType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Scope = this.Scope;
            context.SelectionCriterion = this.SelectionCriterion;
            
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
            var request = new Amazon.CloudWatchLogs.Model.PutAccountPolicyRequest();
            
            if (cmdletContext.PolicyDocument != null)
            {
                request.PolicyDocument = cmdletContext.PolicyDocument;
            }
            if (cmdletContext.PolicyName != null)
            {
                request.PolicyName = cmdletContext.PolicyName;
            }
            if (cmdletContext.PolicyType != null)
            {
                request.PolicyType = cmdletContext.PolicyType;
            }
            if (cmdletContext.Scope != null)
            {
                request.Scope = cmdletContext.Scope;
            }
            if (cmdletContext.SelectionCriterion != null)
            {
                request.SelectionCriteria = cmdletContext.SelectionCriterion;
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
        
        private Amazon.CloudWatchLogs.Model.PutAccountPolicyResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutAccountPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutAccountPolicy");
            try
            {
                #if DESKTOP
                return client.PutAccountPolicy(request);
                #elif CORECLR
                return client.PutAccountPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.String PolicyDocument { get; set; }
            public System.String PolicyName { get; set; }
            public Amazon.CloudWatchLogs.PolicyType PolicyType { get; set; }
            public Amazon.CloudWatchLogs.Scope Scope { get; set; }
            public System.String SelectionCriterion { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutAccountPolicyResponse, WriteCWLAccountPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountPolicy;
        }
        
    }
}
