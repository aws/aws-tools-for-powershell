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
    /// Describes the what-if forecast created using the <a>CreateWhatIfForecast</a> operation.
    /// 
    ///  
    /// <para>
    /// In addition to listing the properties provided in the <c>CreateWhatIfForecast</c>
    /// request, this operation lists the following properties:
    /// </para><ul><li><para><c>CreationTime</c></para></li><li><para><c>LastModificationTime</c></para></li><li><para><c>Message</c> - If an error occurred, information about the error.
    /// </para></li><li><para><c>Status</c></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "FRCWhatIfForecast")]
    [OutputType("Amazon.ForecastService.Model.DescribeWhatIfForecastResponse")]
    [AWSCmdlet("Calls the Amazon Forecast Service DescribeWhatIfForecast API operation.", Operation = new[] {"DescribeWhatIfForecast"}, SelectReturnType = typeof(Amazon.ForecastService.Model.DescribeWhatIfForecastResponse))]
    [AWSCmdletOutput("Amazon.ForecastService.Model.DescribeWhatIfForecastResponse",
        "This cmdlet returns an Amazon.ForecastService.Model.DescribeWhatIfForecastResponse object containing multiple properties."
    )]
    public partial class GetFRCWhatIfForecastCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter WhatIfForecastArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the what-if forecast that you are interested in.</para>
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
        public System.String WhatIfForecastArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.DescribeWhatIfForecastResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.DescribeWhatIfForecastResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.DescribeWhatIfForecastResponse, GetFRCWhatIfForecastCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.WhatIfForecastArn = this.WhatIfForecastArn;
            #if MODULAR
            if (this.WhatIfForecastArn == null && ParameterWasBound(nameof(this.WhatIfForecastArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WhatIfForecastArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.DescribeWhatIfForecastRequest();
            
            if (cmdletContext.WhatIfForecastArn != null)
            {
                request.WhatIfForecastArn = cmdletContext.WhatIfForecastArn;
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
        
        private Amazon.ForecastService.Model.DescribeWhatIfForecastResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.DescribeWhatIfForecastRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "DescribeWhatIfForecast");
            try
            {
                return client.DescribeWhatIfForecastAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String WhatIfForecastArn { get; set; }
            public System.Func<Amazon.ForecastService.Model.DescribeWhatIfForecastResponse, GetFRCWhatIfForecastCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
