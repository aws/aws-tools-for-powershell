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
using Amazon.AWSSupport;
using Amazon.AWSSupport.Model;

namespace Amazon.PowerShell.Cmdlets.ASA
{
    /// <summary>
    /// Returns the results for the Trusted Advisor check summaries for the check IDs that
    /// you specified. You can get the check IDs by calling the <a>DescribeTrustedAdvisorChecks</a>
    /// operation.
    /// 
    ///  
    /// <para>
    /// The response contains an array of <a>TrustedAdvisorCheckSummary</a> objects.
    /// </para><note><ul><li><para>
    /// You must have a Business, Enterprise On-Ramp, or Enterprise Support plan to use the
    /// Amazon Web Services Support API. 
    /// </para></li><li><para>
    /// If you call the Amazon Web Services Support API from an account that doesn't have
    /// a Business, Enterprise On-Ramp, or Enterprise Support plan, the <c>SubscriptionRequiredException</c>
    /// error message appears. For information about changing your support plan, see <a href="http://aws.amazon.com/premiumsupport/">Amazon
    /// Web Services Support</a>.
    /// </para></li></ul></note><para>
    /// To call the Trusted Advisor operations in the Amazon Web Services Support API, you
    /// must use the US East (N. Virginia) endpoint. Currently, the US West (Oregon) and Europe
    /// (Ireland) endpoints don't support the Trusted Advisor operations. For more information,
    /// see <a href="https://docs.aws.amazon.com/awssupport/latest/user/about-support-api.html#endpoint">About
    /// the Amazon Web Services Support API</a> in the <i>Amazon Web Services Support User
    /// Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "ASATrustedAdvisorCheckSummary")]
    [OutputType("Amazon.AWSSupport.Model.TrustedAdvisorCheckSummary")]
    [AWSCmdlet("Calls the AWS Support DescribeTrustedAdvisorCheckSummaries API operation.", Operation = new[] {"DescribeTrustedAdvisorCheckSummaries"}, SelectReturnType = typeof(Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesResponse), LegacyAlias="Get-ASATrustedAdvisorCheckSummaries")]
    [AWSCmdletOutput("Amazon.AWSSupport.Model.TrustedAdvisorCheckSummary or Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesResponse",
        "This cmdlet returns a collection of Amazon.AWSSupport.Model.TrustedAdvisorCheckSummary objects.",
        "The service call response (type Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetASATrustedAdvisorCheckSummaryCmdlet : AmazonAWSSupportClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CheckId
        /// <summary>
        /// <para>
        /// <para>The IDs of the Trusted Advisor checks.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("CheckIds")]
        public System.String[] CheckId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Summaries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesResponse).
        /// Specifying the name of a property of type Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Summaries";
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
                context.Select = CreateSelectDelegate<Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesResponse, GetASATrustedAdvisorCheckSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.CheckId != null)
            {
                context.CheckId = new List<System.String>(this.CheckId);
            }
            #if MODULAR
            if (this.CheckId == null && ParameterWasBound(nameof(this.CheckId)))
            {
                WriteWarning("You are passing $null as a value for parameter CheckId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesRequest();
            
            if (cmdletContext.CheckId != null)
            {
                request.CheckIds = cmdletContext.CheckId;
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
        
        private Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesResponse CallAWSServiceOperation(IAmazonAWSSupport client, Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support", "DescribeTrustedAdvisorCheckSummaries");
            try
            {
                return client.DescribeTrustedAdvisorCheckSummariesAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> CheckId { get; set; }
            public System.Func<Amazon.AWSSupport.Model.DescribeTrustedAdvisorCheckSummariesResponse, GetASATrustedAdvisorCheckSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Summaries;
        }
        
    }
}
