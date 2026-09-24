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
using Amazon.EventBridgeV2;
using Amazon.EventBridgeV2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EVBV2
{
    /// <summary>
    /// Returns the full configuration and state of a subscriber.
    /// </summary>
    [Cmdlet("Get", "EVBV2SubscriberDetail")]
    [OutputType("Amazon.EventBridgeV2.Model.DescribeSubscriberResponse")]
    [AWSCmdlet("Calls the Amazon EventBridgeV2 DescribeSubscriber API operation.", Operation = new[] {"DescribeSubscriber"}, SelectReturnType = typeof(Amazon.EventBridgeV2.Model.DescribeSubscriberResponse))]
    [AWSCmdletOutput("Amazon.EventBridgeV2.Model.DescribeSubscriberResponse",
        "This cmdlet returns an Amazon.EventBridgeV2.Model.DescribeSubscriberResponse object containing multiple properties."
    )]
    public partial class GetEVBV2SubscriberDetailCmdlet : AmazonEventBridgeV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SubscriberArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        public System.String SubscriberArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EventBridgeV2.Model.DescribeSubscriberResponse).
        /// Specifying the name of a property of type Amazon.EventBridgeV2.Model.DescribeSubscriberResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.EventBridgeV2.Model.DescribeSubscriberResponse, GetEVBV2SubscriberDetailCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SubscriberArn = this.SubscriberArn;
            #if MODULAR
            if (this.SubscriberArn == null && ParameterWasBound(nameof(this.SubscriberArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SubscriberArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EventBridgeV2.Model.DescribeSubscriberRequest();
            
            if (cmdletContext.SubscriberArn != null)
            {
                request.SubscriberArn = cmdletContext.SubscriberArn;
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
        
        private Amazon.EventBridgeV2.Model.DescribeSubscriberResponse CallAWSServiceOperation(IAmazonEventBridgeV2 client, Amazon.EventBridgeV2.Model.DescribeSubscriberRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EventBridgeV2", "DescribeSubscriber");
            try
            {
                return client.DescribeSubscriberAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SubscriberArn { get; set; }
            public System.Func<Amazon.EventBridgeV2.Model.DescribeSubscriberResponse, GetEVBV2SubscriberDetailCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
