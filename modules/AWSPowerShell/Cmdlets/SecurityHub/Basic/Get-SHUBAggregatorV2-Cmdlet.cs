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
using Amazon.SecurityHub;
using Amazon.SecurityHub.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SHUB
{
    /// <summary>
    /// Returns the configuration of the specified Aggregator V2. This API is in public preview
    /// and subject to change.
    /// </summary>
    [Cmdlet("Get", "SHUBAggregatorV2")]
    [OutputType("Amazon.SecurityHub.Model.GetAggregatorV2Response")]
    [AWSCmdlet("Calls the AWS Security Hub GetAggregatorV2 API operation.", Operation = new[] {"GetAggregatorV2"}, SelectReturnType = typeof(Amazon.SecurityHub.Model.GetAggregatorV2Response))]
    [AWSCmdletOutput("Amazon.SecurityHub.Model.GetAggregatorV2Response",
        "This cmdlet returns an Amazon.SecurityHub.Model.GetAggregatorV2Response object containing multiple properties."
    )]
    public partial class GetSHUBAggregatorV2Cmdlet : AmazonSecurityHubClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AggregatorV2Arn
        /// <summary>
        /// <para>
        /// <para>The ARN of the Aggregator V2.</para>
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
        public System.String AggregatorV2Arn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SecurityHub.Model.GetAggregatorV2Response).
        /// Specifying the name of a property of type Amazon.SecurityHub.Model.GetAggregatorV2Response will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.SecurityHub.Model.GetAggregatorV2Response, GetSHUBAggregatorV2Cmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AggregatorV2Arn = this.AggregatorV2Arn;
            #if MODULAR
            if (this.AggregatorV2Arn == null && ParameterWasBound(nameof(this.AggregatorV2Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter AggregatorV2Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SecurityHub.Model.GetAggregatorV2Request();
            
            if (cmdletContext.AggregatorV2Arn != null)
            {
                request.AggregatorV2Arn = cmdletContext.AggregatorV2Arn;
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
        
        private Amazon.SecurityHub.Model.GetAggregatorV2Response CallAWSServiceOperation(IAmazonSecurityHub client, Amazon.SecurityHub.Model.GetAggregatorV2Request request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Security Hub", "GetAggregatorV2");
            try
            {
                return client.GetAggregatorV2Async(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AggregatorV2Arn { get; set; }
            public System.Func<Amazon.SecurityHub.Model.GetAggregatorV2Response, GetSHUBAggregatorV2Cmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
