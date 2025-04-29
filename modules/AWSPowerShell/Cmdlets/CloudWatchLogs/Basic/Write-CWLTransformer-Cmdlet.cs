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
    /// Creates or updates a <i>log transformer</i> for a single log group. You use log transformers
    /// to transform log events into a different format, making them easier for you to process
    /// and analyze. You can also transform logs from different sources into standardized
    /// formats that contains relevant, source-specific information.
    /// 
    ///  
    /// <para>
    /// After you have created a transformer, CloudWatch Logs performs the transformations
    /// at the time of log ingestion. You can then refer to the transformed versions of the
    /// logs during operations such as querying with CloudWatch Logs Insights or creating
    /// metric filters or subscription filers.
    /// </para><para>
    /// You can also use a transformer to copy metadata from metadata keys into the log events
    /// themselves. This metadata can include log group name, log stream name, account ID
    /// and Region.
    /// </para><para>
    /// A transformer for a log group is a series of processors, where each processor applies
    /// one type of transformation to the log events ingested into this log group. The processors
    /// work one after another, in the order that you list them, like a pipeline. For more
    /// information about the available processors to use in a transformer, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CloudWatch-Logs-Transformation.html#CloudWatch-Logs-Transformation-Processors">
    /// Processors that you can use</a>.
    /// </para><para>
    /// Having log events in standardized format enables visibility across your applications
    /// for your log analysis, reporting, and alarming needs. CloudWatch Logs provides transformation
    /// for common log types with out-of-the-box transformation templates for major Amazon
    /// Web Services log sources such as VPC flow logs, Lambda, and Amazon RDS. You can use
    /// pre-built transformation templates or create custom transformation policies.
    /// </para><para>
    /// You can create transformers only for the log groups in the Standard log class.
    /// </para><para>
    /// You can also set up a transformer at the account level. For more information, see
    /// <a href="https://docs.aws.amazon.com/AmazonCloudWatchLogs/latest/APIReference/API_PutAccountPolicy.html">PutAccountPolicy</a>.
    /// If there is both a log-group level transformer created with <c>PutTransformer</c>
    /// and an account-level transformer that could apply to the same log group, the log group
    /// uses only the log-group level transformer. It ignores the account-level transformer.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLTransformer", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutTransformer API operation.", Operation = new[] {"PutTransformer"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutTransformerResponse))]
    [AWSCmdletOutput("None or Amazon.CloudWatchLogs.Model.PutTransformerResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.CloudWatchLogs.Model.PutTransformerResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteCWLTransformerCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogGroupIdentifier
        /// <summary>
        /// <para>
        /// <para>Specify either the name or ARN of the log group to create the transformer for. </para>
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
        
        #region Parameter TransformerConfig
        /// <summary>
        /// <para>
        /// <para>This structure contains the configuration of this log transformer. A log transformer
        /// is an array of processors, where each processor applies one type of transformation
        /// to the log events that are ingested.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.CloudWatchLogs.Model.Processor[] TransformerConfig { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutTransformerResponse).
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLTransformer (PutTransformer)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutTransformerResponse, WriteCWLTransformerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LogGroupIdentifier = this.LogGroupIdentifier;
            #if MODULAR
            if (this.LogGroupIdentifier == null && ParameterWasBound(nameof(this.LogGroupIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter LogGroupIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TransformerConfig != null)
            {
                context.TransformerConfig = new List<Amazon.CloudWatchLogs.Model.Processor>(this.TransformerConfig);
            }
            #if MODULAR
            if (this.TransformerConfig == null && ParameterWasBound(nameof(this.TransformerConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter TransformerConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.PutTransformerRequest();
            
            if (cmdletContext.LogGroupIdentifier != null)
            {
                request.LogGroupIdentifier = cmdletContext.LogGroupIdentifier;
            }
            if (cmdletContext.TransformerConfig != null)
            {
                request.TransformerConfig = cmdletContext.TransformerConfig;
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
        
        private Amazon.CloudWatchLogs.Model.PutTransformerResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutTransformerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutTransformer");
            try
            {
                return client.PutTransformerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.CloudWatchLogs.Model.Processor> TransformerConfig { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutTransformerResponse, WriteCWLTransformerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
