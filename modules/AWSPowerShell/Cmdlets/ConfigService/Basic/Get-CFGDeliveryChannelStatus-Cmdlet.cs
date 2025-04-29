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
using Amazon.ConfigService;
using Amazon.ConfigService.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CFG
{
    /// <summary>
    /// Returns the current status of the specified delivery channel. If a delivery channel
    /// is not specified, this operation returns the current status of all delivery channels
    /// associated with the account.
    /// 
    ///  <note><para>
    /// Currently, you can specify only one delivery channel per region in your account.
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "CFGDeliveryChannelStatus")]
    [OutputType("Amazon.ConfigService.Model.DeliveryChannelStatus")]
    [AWSCmdlet("Calls the AWS Config DescribeDeliveryChannelStatus API operation.", Operation = new[] {"DescribeDeliveryChannelStatus"}, SelectReturnType = typeof(Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse))]
    [AWSCmdletOutput("Amazon.ConfigService.Model.DeliveryChannelStatus or Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse",
        "This cmdlet returns a collection of Amazon.ConfigService.Model.DeliveryChannelStatus objects.",
        "The service call response (type Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetCFGDeliveryChannelStatusCmdlet : AmazonConfigServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DeliveryChannelName
        /// <summary>
        /// <para>
        /// <para>A list of delivery channel names.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [Alias("DeliveryChannelNames")]
        public System.String[] DeliveryChannelName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DeliveryChannelsStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse).
        /// Specifying the name of a property of type Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DeliveryChannelsStatus";
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
                context.Select = CreateSelectDelegate<Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse, GetCFGDeliveryChannelStatusCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DeliveryChannelName != null)
            {
                context.DeliveryChannelName = new List<System.String>(this.DeliveryChannelName);
            }
            
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
            var request = new Amazon.ConfigService.Model.DescribeDeliveryChannelStatusRequest();
            
            if (cmdletContext.DeliveryChannelName != null)
            {
                request.DeliveryChannelNames = cmdletContext.DeliveryChannelName;
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
        
        private Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse CallAWSServiceOperation(IAmazonConfigService client, Amazon.ConfigService.Model.DescribeDeliveryChannelStatusRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Config", "DescribeDeliveryChannelStatus");
            try
            {
                return client.DescribeDeliveryChannelStatusAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<System.String> DeliveryChannelName { get; set; }
            public System.Func<Amazon.ConfigService.Model.DescribeDeliveryChannelStatusResponse, GetCFGDeliveryChannelStatusCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DeliveryChannelsStatus;
        }
        
    }
}
