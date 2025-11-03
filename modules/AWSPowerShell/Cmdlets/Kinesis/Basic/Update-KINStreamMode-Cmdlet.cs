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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Updates the capacity mode of the data stream. Currently, in Kinesis Data Streams,
    /// you can choose between an <b>on-demand</b> capacity mode and a <b>provisioned</b>
    /// capacity mode for your data stream. 
    /// 
    ///  
    /// <para>
    /// If you'd still like to proactively scale your on-demand data stream’s capacity, you
    /// can unlock the warm throughput feature for on-demand data streams by enabling <c>MinimumThroughputBillingCommitment</c>
    /// for your account. Once your account has <c>MinimumThroughputBillingCommitment</c>
    /// enabled, you can specify the warm throughput in MiB per second that your stream can
    /// support in writes.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KINStreamMode", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis UpdateStreamMode API operation.", Operation = new[] {"UpdateStreamMode"}, SelectReturnType = typeof(Amazon.Kinesis.Model.UpdateStreamModeResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.UpdateStreamModeResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kinesis.Model.UpdateStreamModeResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKINStreamModeCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para> Specifies the ARN of the data stream whose capacity mode you want to update. </para>
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
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamModeDetails_StreamMode
        /// <summary>
        /// <para>
        /// <para> Specifies the capacity mode to which you want to set your data stream. Currently,
        /// in Kinesis Data Streams, you can choose between an <b>on-demand</b> capacity mode
        /// and a <b>provisioned</b> capacity mode for your data streams. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Kinesis.StreamMode")]
        public Amazon.Kinesis.StreamMode StreamModeDetails_StreamMode { get; set; }
        #endregion
        
        #region Parameter WarmThroughputMiBp
        /// <summary>
        /// <para>
        /// <para>The target warm throughput in MB/s that the stream should be scaled to handle. This
        /// represents the throughput capacity that will be immediately available for write operations.
        /// This field is only valid when the stream mode is being updated to on-demand.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("WarmThroughputMiBps")]
        public System.Int32? WarmThroughputMiBp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.UpdateStreamModeResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KINStreamMode (UpdateStreamMode)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.UpdateStreamModeResponse, UpdateKINStreamModeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StreamARN = this.StreamARN;
            #if MODULAR
            if (this.StreamARN == null && ParameterWasBound(nameof(this.StreamARN)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamModeDetails_StreamMode = this.StreamModeDetails_StreamMode;
            #if MODULAR
            if (this.StreamModeDetails_StreamMode == null && ParameterWasBound(nameof(this.StreamModeDetails_StreamMode)))
            {
                WriteWarning("You are passing $null as a value for parameter StreamModeDetails_StreamMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WarmThroughputMiBp = this.WarmThroughputMiBp;
            
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
            var request = new Amazon.Kinesis.Model.UpdateStreamModeRequest();
            
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            
             // populate StreamModeDetails
            var requestStreamModeDetailsIsNull = true;
            request.StreamModeDetails = new Amazon.Kinesis.Model.StreamModeDetails();
            Amazon.Kinesis.StreamMode requestStreamModeDetails_streamModeDetails_StreamMode = null;
            if (cmdletContext.StreamModeDetails_StreamMode != null)
            {
                requestStreamModeDetails_streamModeDetails_StreamMode = cmdletContext.StreamModeDetails_StreamMode;
            }
            if (requestStreamModeDetails_streamModeDetails_StreamMode != null)
            {
                request.StreamModeDetails.StreamMode = requestStreamModeDetails_streamModeDetails_StreamMode;
                requestStreamModeDetailsIsNull = false;
            }
             // determine if request.StreamModeDetails should be set to null
            if (requestStreamModeDetailsIsNull)
            {
                request.StreamModeDetails = null;
            }
            if (cmdletContext.WarmThroughputMiBp != null)
            {
                request.WarmThroughputMiBps = cmdletContext.WarmThroughputMiBp.Value;
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
        
        private Amazon.Kinesis.Model.UpdateStreamModeResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.UpdateStreamModeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "UpdateStreamMode");
            try
            {
                return client.UpdateStreamModeAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String StreamARN { get; set; }
            public Amazon.Kinesis.StreamMode StreamModeDetails_StreamMode { get; set; }
            public System.Int32? WarmThroughputMiBp { get; set; }
            public System.Func<Amazon.Kinesis.Model.UpdateStreamModeResponse, UpdateKINStreamModeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
