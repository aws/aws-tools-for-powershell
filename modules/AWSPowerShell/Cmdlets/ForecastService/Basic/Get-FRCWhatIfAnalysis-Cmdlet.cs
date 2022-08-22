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
    /// Describes the what-if analysis created using the <a>CreateWhatIfAnalysis</a> operation.
    /// 
    ///  
    /// <para>
    /// In addition to listing the properties provided in the <code>CreateWhatIfAnalysis</code>
    /// request, this operation lists the following properties:
    /// </para><ul><li><para><code>CreationTime</code></para></li><li><para><code>LastModificationTime</code></para></li><li><para><code>Message</code> - If an error occurred, information about the error.
    /// </para></li><li><para><code>Status</code></para></li></ul>
    /// </summary>
    [Cmdlet("Get", "FRCWhatIfAnalysis")]
    [OutputType("Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse")]
    [AWSCmdlet("Calls the Amazon Forecast Service DescribeWhatIfAnalysis API operation.", Operation = new[] {"DescribeWhatIfAnalysis"}, SelectReturnType = typeof(Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse))]
    [AWSCmdletOutput("Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse",
        "This cmdlet returns an Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetFRCWhatIfAnalysisCmdlet : AmazonForecastServiceClientCmdlet, IExecutor
    {
        
        #region Parameter WhatIfAnalysisArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the what-if analysis that you are interested in.</para>
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
        public System.String WhatIfAnalysisArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse).
        /// Specifying the name of a property of type Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WhatIfAnalysisArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WhatIfAnalysisArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WhatIfAnalysisArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse, GetFRCWhatIfAnalysisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WhatIfAnalysisArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.WhatIfAnalysisArn = this.WhatIfAnalysisArn;
            #if MODULAR
            if (this.WhatIfAnalysisArn == null && ParameterWasBound(nameof(this.WhatIfAnalysisArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WhatIfAnalysisArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ForecastService.Model.DescribeWhatIfAnalysisRequest();
            
            if (cmdletContext.WhatIfAnalysisArn != null)
            {
                request.WhatIfAnalysisArn = cmdletContext.WhatIfAnalysisArn;
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
        
        private Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse CallAWSServiceOperation(IAmazonForecastService client, Amazon.ForecastService.Model.DescribeWhatIfAnalysisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Forecast Service", "DescribeWhatIfAnalysis");
            try
            {
                #if DESKTOP
                return client.DescribeWhatIfAnalysis(request);
                #elif CORECLR
                return client.DescribeWhatIfAnalysisAsync(request).GetAwaiter().GetResult();
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
            public System.String WhatIfAnalysisArn { get; set; }
            public System.Func<Amazon.ForecastService.Model.DescribeWhatIfAnalysisResponse, GetFRCWhatIfAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
