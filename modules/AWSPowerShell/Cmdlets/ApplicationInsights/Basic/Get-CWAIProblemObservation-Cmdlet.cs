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
using Amazon.ApplicationInsights;
using Amazon.ApplicationInsights.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWAI
{
    /// <summary>
    /// Describes the anomalies or errors associated with the problem.
    /// </summary>
    [Cmdlet("Get", "CWAIProblemObservation")]
    [OutputType("Amazon.ApplicationInsights.Model.RelatedObservations")]
    [AWSCmdlet("Calls the Amazon CloudWatch Application Insights DescribeProblemObservations API operation.", Operation = new[] {"DescribeProblemObservations"}, SelectReturnType = typeof(Amazon.ApplicationInsights.Model.DescribeProblemObservationsResponse))]
    [AWSCmdletOutput("Amazon.ApplicationInsights.Model.RelatedObservations or Amazon.ApplicationInsights.Model.DescribeProblemObservationsResponse",
        "This cmdlet returns an Amazon.ApplicationInsights.Model.RelatedObservations object.",
        "The service call response (type Amazon.ApplicationInsights.Model.DescribeProblemObservationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCWAIProblemObservationCmdlet : AmazonApplicationInsightsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID for the resource group owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter ProblemId
        /// <summary>
        /// <para>
        /// <para>The ID of the problem.</para>
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
        public System.String ProblemId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RelatedObservations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ApplicationInsights.Model.DescribeProblemObservationsResponse).
        /// Specifying the name of a property of type Amazon.ApplicationInsights.Model.DescribeProblemObservationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RelatedObservations";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ApplicationInsights.Model.DescribeProblemObservationsResponse, GetCWAIProblemObservationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.ProblemId = this.ProblemId;
            #if MODULAR
            if (this.ProblemId == null && ParameterWasBound(nameof(this.ProblemId)))
            {
                WriteWarning("You are passing $null as a value for parameter ProblemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ApplicationInsights.Model.DescribeProblemObservationsRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.ProblemId != null)
            {
                request.ProblemId = cmdletContext.ProblemId;
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
        
        private Amazon.ApplicationInsights.Model.DescribeProblemObservationsResponse CallAWSServiceOperation(IAmazonApplicationInsights client, Amazon.ApplicationInsights.Model.DescribeProblemObservationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Application Insights", "DescribeProblemObservations");
            try
            {
                return client.DescribeProblemObservationsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public System.String ProblemId { get; set; }
            public System.Func<Amazon.ApplicationInsights.Model.DescribeProblemObservationsResponse, GetCWAIProblemObservationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RelatedObservations;
        }
        
    }
}
