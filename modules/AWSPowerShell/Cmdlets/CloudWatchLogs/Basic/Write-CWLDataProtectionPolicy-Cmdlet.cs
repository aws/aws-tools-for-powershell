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
using System.Threading;
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates a data protection policy for the specified log group. A data protection policy
    /// can help safeguard sensitive data that's ingested by the log group by auditing and
    /// masking the sensitive log data.
    /// 
    ///  <important><para>
    /// Sensitive data is detected and masked when it is ingested into the log group. When
    /// you set a data protection policy, log events ingested into the log group before that
    /// time are not masked.
    /// </para></important><para>
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
    /// The <c>PutDataProtectionPolicy</c> operation applies to only the specified log group.
    /// You can also use <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutAccountPolicy.html">PutAccountPolicy</a>
    /// to create an account-level data protection policy that applies to all log groups in
    /// the account, including both existing log groups and log groups that are created level.
    /// If a log group has its own data protection policy and the account also has an account-level
    /// data protection policy, then the two policies are cumulative. Any sensitive term specified
    /// in either policy is masked.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLDataProtectionPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutDataProtectionPolicy API operation.", Operation = new[] {"PutDataProtectionPolicy"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse object containing multiple properties."
    )]
    public partial class WriteCWLDataProtectionPolicyCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>Specify either the log group name or log group ARN.</para>
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
        /// <para>Specify the data protection policy, in JSON.</para><para>This policy must include two JSON blocks:</para><ul><li><para>The first block must include both a <c>DataIdentifer</c> array and an <c>Operation</c>
        /// property with an <c>Audit</c> action. The <c>DataIdentifer</c> array lists the types
        /// of sensitive data that you want to mask. For more information about the available
        /// options, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/mask-sensitive-log-data-types.html">Types
        /// of data that you can mask</a>.</para><para>The <c>Operation</c> property with an <c>Audit</c> action is required to find the
        /// sensitive data terms. This <c>Audit</c> action must contain a <c>FindingsDestination</c>
        /// object. You can optionally use that <c>FindingsDestination</c> object to list one
        /// or more destinations to send audit findings to. If you specify destinations such as
        /// log groups, Firehose streams, and S3 buckets, they must already exist.</para></li><li><para>The second block must include both a <c>DataIdentifer</c> array and an <c>Operation</c>
        /// property with an <c>Deidentify</c> action. The <c>DataIdentifer</c> array must exactly
        /// match the <c>DataIdentifer</c> array in the first block of the policy.</para><para>The <c>Operation</c> property with the <c>Deidentify</c> action is what actually masks
        /// the data, and it must contain the <c> "MaskConfig": {}</c> object. The <c> "MaskConfig":
        /// {}</c> object must be empty.</para></li></ul><para>For an example data protection policy, see the <b>Examples</b> section on this page.</para><important><para>The contents of the two <c>DataIdentifer</c> arrays must match exactly.</para></important><para>In addition to the two JSON blocks, the <c>policyDocument</c> can also include <c>Name</c>,
        /// <c>Description</c>, and <c>Version</c> fields. The <c>Name</c> is used as a dimension
        /// when CloudWatch Logs reports audit findings metrics to CloudWatch.</para><para>The JSON specified in <c>policyDocument</c> can be up to 30,720 characters.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse will result in that property being returned.
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LogGroupIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLDataProtectionPolicy (PutDataProtectionPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse, WriteCWLDataProtectionPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            var request = new Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyRequest();
            
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
        
        private Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutDataProtectionPolicy");
            try
            {
                return client.PutDataProtectionPolicyAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.CloudWatchLogs.Model.PutDataProtectionPolicyResponse, WriteCWLDataProtectionPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
