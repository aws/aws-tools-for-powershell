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

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Increases the Kinesis data stream's retention period, which is the length of time
    /// data records are accessible after they are added to the stream. The maximum value
    /// of a stream's retention period is 8760 hours (365 days).
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// If you choose a longer stream retention period, this operation increases the time
    /// period during which records that have not yet expired are accessible. However, it
    /// does not make previous, expired data (older than the stream's previous retention period)
    /// accessible after the operation has been called. For example, if a stream's retention
    /// period is set to 24 hours and is increased to 168 hours, any data that is older than
    /// 24 hours remains inaccessible to consumer applications.
    /// </para>
    /// </summary>
    [Cmdlet("Request", "KINStreamRetentionPeriodIncrease", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis IncreaseStreamRetentionPeriod API operation.", Operation = new[] {"IncreaseStreamRetentionPeriod"}, SelectReturnType = typeof(Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodResponse))]
    [AWSCmdletOutput("None or Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodResponse) be returned by specifying '-Select *'."
    )]
    public partial class RequestKINStreamRetentionPeriodIncreaseCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter RetentionPeriodHour
        /// <summary>
        /// <para>
        /// <para>The new retention period of the stream, in hours. Must be more than the current retention
        /// period.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("RetentionPeriodHours")]
        public System.Int32? RetentionPeriodHour { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to modify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodResponse).
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StreamName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-KINStreamRetentionPeriodIncrease (IncreaseStreamRetentionPeriod)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodResponse, RequestKINStreamRetentionPeriodIncreaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.RetentionPeriodHour = this.RetentionPeriodHour;
            #if MODULAR
            if (this.RetentionPeriodHour == null && ParameterWasBound(nameof(this.RetentionPeriodHour)))
            {
                WriteWarning("You are passing $null as a value for parameter RetentionPeriodHour which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            
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
            var request = new Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodRequest();
            
            if (cmdletContext.RetentionPeriodHour != null)
            {
                request.RetentionPeriodHours = cmdletContext.RetentionPeriodHour.Value;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
        
        private Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "IncreaseStreamRetentionPeriod");
            try
            {
                return client.IncreaseStreamRetentionPeriodAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? RetentionPeriodHour { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.IncreaseStreamRetentionPeriodResponse, RequestKINStreamRetentionPeriodIncreaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
