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
using Amazon.Textract;
using Amazon.Textract.Model;

namespace Amazon.PowerShell.Cmdlets.TXT
{
    /// <summary>
    /// Gets summarized results for the <c>StartLendingAnalysis</c> operation, which analyzes
    /// text in a lending document. The returned summary consists of information about documents
    /// grouped together by a common document type. Information like detected signatures,
    /// page numbers, and split documents is returned with respect to the type of grouped
    /// document. 
    /// 
    ///  
    /// <para>
    /// You start asynchronous text analysis by calling <c>StartLendingAnalysis</c>, which
    /// returns a job identifier (<c>JobId</c>). When the text analysis operation finishes,
    /// Amazon Textract publishes a completion status to the Amazon Simple Notification Service
    /// (Amazon SNS) topic that's registered in the initial call to <c>StartLendingAnalysis</c>.
    /// 
    /// </para><para>
    /// To get the results of the text analysis operation, first check that the status value
    /// published to the Amazon SNS topic is SUCCEEDED. If so, call <c>GetLendingAnalysisSummary</c>,
    /// and pass the job identifier (<c>JobId</c>) from the initial call to <c>StartLendingAnalysis</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TXTLendingAnalysisSummary")]
    [OutputType("Amazon.Textract.Model.GetLendingAnalysisSummaryResponse")]
    [AWSCmdlet("Calls the Amazon Textract GetLendingAnalysisSummary API operation.", Operation = new[] {"GetLendingAnalysisSummary"}, SelectReturnType = typeof(Amazon.Textract.Model.GetLendingAnalysisSummaryResponse))]
    [AWSCmdletOutput("Amazon.Textract.Model.GetLendingAnalysisSummaryResponse",
        "This cmdlet returns an Amazon.Textract.Model.GetLendingAnalysisSummaryResponse object containing multiple properties."
    )]
    public partial class GetTXTLendingAnalysisSummaryCmdlet : AmazonTextractClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter JobId
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the lending or text-detection job. The <c>JobId</c> is returned
        /// from StartLendingAnalysis. A <c>JobId</c> value is only valid for 7 days.</para>
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
        public System.String JobId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Textract.Model.GetLendingAnalysisSummaryResponse).
        /// Specifying the name of a property of type Amazon.Textract.Model.GetLendingAnalysisSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.Textract.Model.GetLendingAnalysisSummaryResponse, GetTXTLendingAnalysisSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.JobId = this.JobId;
            #if MODULAR
            if (this.JobId == null && ParameterWasBound(nameof(this.JobId)))
            {
                WriteWarning("You are passing $null as a value for parameter JobId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Textract.Model.GetLendingAnalysisSummaryRequest();
            
            if (cmdletContext.JobId != null)
            {
                request.JobId = cmdletContext.JobId;
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
        
        private Amazon.Textract.Model.GetLendingAnalysisSummaryResponse CallAWSServiceOperation(IAmazonTextract client, Amazon.Textract.Model.GetLendingAnalysisSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Textract", "GetLendingAnalysisSummary");
            try
            {
                return client.GetLendingAnalysisSummaryAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String JobId { get; set; }
            public System.Func<Amazon.Textract.Model.GetLendingAnalysisSummaryResponse, GetTXTLendingAnalysisSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
