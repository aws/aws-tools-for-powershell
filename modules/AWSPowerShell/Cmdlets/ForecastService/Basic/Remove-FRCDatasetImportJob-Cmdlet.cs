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

namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// Deletes a dataset import job created using the <a href="https://docs.aws.amazon.com/forecast/latest/dg/API_CreateDatasetImportJob.html">CreateDatasetImportJob</a>
    /// operation. You can delete only dataset import jobs that have a status of <c>ACTIVE</c>
    /// or <c>CREATE_FAILED</c>. To get the status, use the <a href="https://docs.aws.amazon.com/forecast/latest/dg/API_DescribeDatasetImportJob.html">DescribeDatasetImportJob</a>
    /// operation.
    /// </summary>
    [Cmdlet("Remove", "FRCDatasetImportJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Forecast Service DeleteDatasetImportJob API operation.", Operation = new[] {"DeleteDatasetImportJob"}, SelectReturnType = typeof(Amazon.ForecastService.Model.DeleteDatasetImportJobResponse))]
    [AWSCmdletOutput("None or Amazon.ForecastService.Model.DeleteDatasetImportJobResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.ForecastService.Model.DeleteDatasetImportJobResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveFRCDatasetImportJobCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetImportJobArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the dataset import job to delete.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.DeleteDatasetImportJobResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetImportJobArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-FRCDatasetImportJob (DeleteDatasetImportJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.DeleteDatasetImportJobResponse, RemoveFRCDatasetImportJobCmdlet>(Select) ??
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
            var request = new Amazon.ForecastService.Model.DeleteDatasetImportJobRequest();
            
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
        
        private Amazon.ForecastService.Model.DeleteDatasetImportJobResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.DeleteDatasetImportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "DeleteDatasetImportJob");
            try
            {
                return client.DeleteDatasetImportJobAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.ForecastService.Model.DeleteDatasetImportJobResponse, RemoveFRCDatasetImportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
