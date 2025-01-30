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
    /// Describes a forecast created using the <a>CreateForecast</a> operation.
    /// 
    ///  
    /// <para>
    /// In addition to listing the properties provided in the <c>CreateForecast</c> request,
    /// this operation lists the following properties:
    /// </para><ul><li><para><c>DatasetGroupArn</c> - The dataset group that provided the training data.
    /// </para></li><li><para><c>CreationTime</c></para></li><li><para><c>LastModificationTime</c></para></li><li><para><c>Status</c></para></li><li><para><c>Message</c> - If an error occurred, information about the error.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "FRCForecast")]
    [OutputType("Amazon.ForecastService.Model.DescribeForecastResponse")]
    [AWSCmdlet("Calls the Amazon Forecast Service DescribeForecast API operation.", Operation = new[] {"DescribeForecast"}, SelectReturnType = typeof(Amazon.ForecastService.Model.DescribeForecastResponse))]
    [AWSCmdletOutput("Amazon.ForecastService.Model.DescribeForecastResponse",
        "This cmdlet returns an Amazon.ForecastService.Model.DescribeForecastResponse object containing multiple properties."
    )]
    public partial class GetFRCForecastCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ForecastArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the forecast.</para>
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
        public System.String ForecastArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.DescribeForecastResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.DescribeForecastResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ForecastArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ForecastArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ForecastArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.DescribeForecastResponse, GetFRCForecastCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ForecastArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ForecastArn = this.ForecastArn;
            #if MODULAR
            if (this.ForecastArn == null && ParameterWasBound(nameof(this.ForecastArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ForecastArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.DescribeForecastRequest();
            
            if (cmdletContext.ForecastArn != null)
            {
                request.ForecastArn = cmdletContext.ForecastArn;
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
        
        private Amazon.ForecastService.Model.DescribeForecastResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.DescribeForecastRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "DescribeForecast");
            try
            {
                #if DESKTOP
                return client.DescribeForecast(request);
                #elif CORECLR
                return client.DescribeForecastAsync(request).GetAwaiter().GetResult();
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
            public System.String ForecastArn { get; set; }
            public System.Func<Amazon.ForecastService.Model.DescribeForecastResponse, GetFRCForecastCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
