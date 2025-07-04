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
using Amazon.ForecastService;
using Amazon.ForecastService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// Describes a dataset import job created using the <a href="https://docs.aws.amazon.com/forecast/latest/dg/API_CreateDatasetImportJob.html">CreateDatasetImportJob</a>
    /// operation.
    /// 
    ///  
    /// <para>
    /// In addition to listing the parameters provided in the <c>CreateDatasetImportJob</c>
    /// request, this operation includes the following properties:
    /// </para><ul><li><para><c>CreationTime</c></para></li><li><para><c>LastModificationTime</c></para></li><li><para><c>DataSize</c></para></li><li><para><c>FieldStatistics</c></para></li><li><para><c>Status</c></para></li><li><para><c>Message</c> - If an error occurred, information about the error.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "FRCDatasetImportJob")]
    [OutputType("Amazon.ForecastService.Model.DescribeDatasetImportJobResponse")]
    [AWSCmdlet("Calls the Amazon Forecast Service DescribeDatasetImportJob API operation.", Operation = new[] {"DescribeDatasetImportJob"}, SelectReturnType = typeof(Amazon.ForecastService.Model.DescribeDatasetImportJobResponse))]
    [AWSCmdletOutput("Amazon.ForecastService.Model.DescribeDatasetImportJobResponse",
        "This cmdlet returns an Amazon.ForecastService.Model.DescribeDatasetImportJobResponse object containing multiple properties."
    )]
    public partial class GetFRCDatasetImportJobCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetImportJobArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dataset import job.</para>
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
        public System.String DatasetImportJobArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.DescribeDatasetImportJobResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.DescribeDatasetImportJobResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.DescribeDatasetImportJobResponse, GetFRCDatasetImportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DatasetImportJobArn = this.DatasetImportJobArn;
            #if MODULAR
            if (this.DatasetImportJobArn == null && ParameterWasBound(nameof(this.DatasetImportJobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetImportJobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.DescribeDatasetImportJobRequest();
            
            if (cmdletContext.DatasetImportJobArn != null)
            {
                request.DatasetImportJobArn = cmdletContext.DatasetImportJobArn;
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
        
        private Amazon.ForecastService.Model.DescribeDatasetImportJobResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.DescribeDatasetImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "DescribeDatasetImportJob");
            try
            {
                return client.DescribeDatasetImportJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetImportJobArn { get; set; }
            public System.Func<Amazon.ForecastService.Model.DescribeDatasetImportJobResponse, GetFRCDatasetImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
