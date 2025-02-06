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
using Amazon.ForecastService;
using Amazon.ForecastService.Model;

namespace Amazon.PowerShell.Cmdlets.FRC
{
    /// <summary>
    /// Describes a forecast export job created using the <a>CreateForecastExportJob</a> operation.
    /// 
    ///  
    /// <para>
    /// In addition to listing the properties provided by the user in the <c>CreateForecastExportJob</c>
    /// request, this operation lists the following properties:
    /// </para><ul><li><para><c>CreationTime</c></para></li><li><para><c>LastModificationTime</c></para></li><li><para><c>Status</c></para></li><li><para><c>Message</c> - If an error occurred, information about the error.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "FRCForecastExportJob")]
    [OutputType("Amazon.ForecastService.Model.DescribeForecastExportJobResponse")]
    [AWSCmdlet("Calls the Amazon Forecast Service DescribeForecastExportJob API operation.", Operation = new[] {"DescribeForecastExportJob"}, SelectReturnType = typeof(Amazon.ForecastService.Model.DescribeForecastExportJobResponse))]
    [AWSCmdletOutput("Amazon.ForecastService.Model.DescribeForecastExportJobResponse",
        "This cmdlet returns an Amazon.ForecastService.Model.DescribeForecastExportJobResponse object containing multiple properties."
    )]
    public partial class GetFRCForecastExportJobCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ForecastExportJobArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the forecast export job.</para>
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
        public System.String ForecastExportJobArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.DescribeForecastExportJobResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.DescribeForecastExportJobResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.DescribeForecastExportJobResponse, GetFRCForecastExportJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ForecastExportJobArn = this.ForecastExportJobArn;
            #if MODULAR
            if (this.ForecastExportJobArn == null && ParameterWasBound(nameof(this.ForecastExportJobArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ForecastExportJobArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.DescribeForecastExportJobRequest();
            
            if (cmdletContext.ForecastExportJobArn != null)
            {
                request.ForecastExportJobArn = cmdletContext.ForecastExportJobArn;
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
        
        private Amazon.ForecastService.Model.DescribeForecastExportJobResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.DescribeForecastExportJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "DescribeForecastExportJob");
            try
            {
                #if DESKTOP
                return client.DescribeForecastExportJob(request);
                #elif CORECLR
                return client.DescribeForecastExportJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ForecastExportJobArn { get; set; }
            public System.Func<Amazon.ForecastService.Model.DescribeForecastExportJobResponse, GetFRCForecastExportJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
