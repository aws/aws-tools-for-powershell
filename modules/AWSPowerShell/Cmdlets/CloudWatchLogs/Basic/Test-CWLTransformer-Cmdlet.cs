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

namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Use this operation to test a log transformer. You enter the transformer configuration
    /// and a set of log events to test with. The operation responds with an array that includes
    /// the original log events and the transformed versions.
    /// </summary>
    [Cmdlet("Test", "CWLTransformer")]
    [OutputType("Amazon.CloudWatchLogs.Model.TransformedLogRecord")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs TestTransformer API operation.", Operation = new[] {"TestTransformer"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.TestTransformerResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.TransformedLogRecord or Amazon.CloudWatchLogs.Model.TestTransformerResponse",
        "This cmdlet returns a collection of Amazon.CloudWatchLogs.Model.TransformedLogRecord objects.",
        "The service call response (type Amazon.CloudWatchLogs.Model.TestTransformerResponse) can be returned by specifying '-Select *'."
    )]
    public partial class TestCWLTransformerCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LogEventMessage
        /// <summary>
        /// <para>
        /// <para>An array of the raw log events that you want to use to test this transformer.</para>
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
        [Alias("LogEventMessages")]
        public System.String[] LogEventMessage { get; set; }
        #endregion
        
        #region Parameter TransformerConfig
        /// <summary>
        /// <para>
        /// <para>This structure contains the configuration of this log transformer that you want to
        /// test. A log transformer is an array of processors, where each processor applies one
        /// type of transformation to the log events that are ingested.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TransformedLogs'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.TestTransformerResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.TestTransformerResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TransformedLogs";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.TestTransformerResponse, TestCWLTransformerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.LogEventMessage != null)
            {
                context.LogEventMessage = new List<System.String>(this.LogEventMessage);
            }
            #if MODULAR
            if (this.LogEventMessage == null && ParameterWasBound(nameof(this.LogEventMessage)))
            {
                WriteWarning("You are passing $null as a value for parameter LogEventMessage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.CloudWatchLogs.Model.TestTransformerRequest();
            
            if (cmdletContext.LogEventMessage != null)
            {
                request.LogEventMessages = cmdletContext.LogEventMessage;
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
        
        private Amazon.CloudWatchLogs.Model.TestTransformerResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.TestTransformerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "TestTransformer");
            try
            {
                return client.TestTransformerAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> LogEventMessage { get; set; }
            public List<Amazon.CloudWatchLogs.Model.Processor> TransformerConfig { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.TestTransformerResponse, TestCWLTransformerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TransformedLogs;
        }
        
    }
}
