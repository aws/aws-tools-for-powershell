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
using Amazon.ForecastService;
using Amazon.ForecastService.Model;

namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// Describes a predictor backtest export job created using the <a>CreatePredictorBacktestExportJob</a>
    /// operation.
    /// 
    ///  
    /// <para>
    /// In addition to listing the properties provided by the user in the <c>CreatePredictorBacktestExportJob</c>
    /// request, this operation lists the following properties:
    /// </para><ul><li><para><c>CreationTime</c></para></li><li><para><c>LastModificationTime</c></para></li><li><para><c>Status</c></para></li><li><para><c>Message</c> (if an error occurred)
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "FRCPredictorBacktestExportJob")]
    [OutputType("Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse")]
    [AWSCmdlet("Calls the Amazon Forecast Service DescribePredictorBacktestExportJob API operation.", Operation = new[] {"DescribePredictorBacktestExportJob"}, SelectReturnType = typeof(Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse))]
    [AWSCmdletOutput("Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse",
        "This cmdlet returns an Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse object containing multiple properties."
    )]
    public partial class GetFRCPredictorBacktestExportJobCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter PredictorBacktestExportJobArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the predictor backtest export job.</para>
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
        public System.String PredictorBacktestExportJobArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse, GetFRCPredictorBacktestExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.PredictorBacktestExportJobArn = this.PredictorBacktestExportJobArn;
            #if MODULAR
            if (this.PredictorBacktestExportJobArn == null && ParameterWasBound(nameof(this.PredictorBacktestExportJobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PredictorBacktestExportJobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.DescribePredictorBacktestExportJobRequest();
            
            if (cmdletContext.PredictorBacktestExportJobArn != null)
            {
                request.PredictorBacktestExportJobArn = cmdletContext.PredictorBacktestExportJobArn;
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
        
        private Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.DescribePredictorBacktestExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "DescribePredictorBacktestExportJob");
            try
            {
                #if DESKTOP
                return client.DescribePredictorBacktestExportJob(request);
                #elif CORECLR
                return client.DescribePredictorBacktestExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String PredictorBacktestExportJobArn { get; set; }
            public System.Func<Amazon.ForecastService.Model.DescribePredictorBacktestExportJobResponse, GetFRCPredictorBacktestExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
