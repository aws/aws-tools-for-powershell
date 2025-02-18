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
using Amazon.IoTFleetWise;
using Amazon.IoTFleetWise.Model;

namespace Amazon.PowerShell.Cmdlets.IFW
{
    /// <summary>
    /// Creates or updates the logging option.
    /// </summary>
    [Cmdlet("Write", "IFWLoggingOption", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT FleetWise PutLoggingOptions API operation.", Operation = new[] {"PutLoggingOptions"}, SelectReturnType = typeof(Amazon.IoTFleetWise.Model.PutLoggingOptionsResponse))]
    [AWSCmdletOutput("None or Amazon.IoTFleetWise.Model.PutLoggingOptionsResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTFleetWise.Model.PutLoggingOptionsResponse) be returned by specifying '-Select *'."
    )]
    public partial class WriteIFWLoggingOptionCmdlet : AmazonIoTFleetWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CloudWatchLogDelivery_LogGroupName
        /// <summary>
        /// <para>
        /// <para>The Amazon CloudWatch Logs group the operation sends data to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CloudWatchLogDelivery_LogGroupName { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogDelivery_LogType
        /// <summary>
        /// <para>
        /// <para>The type of log to send data to Amazon CloudWatch Logs.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTFleetWise.LogType")]
        public Amazon.IoTFleetWise.LogType CloudWatchLogDelivery_LogType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTFleetWise.Model.PutLoggingOptionsResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.CloudWatchLogDelivery_LogGroupName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-IFWLoggingOption (PutLoggingOptions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTFleetWise.Model.PutLoggingOptionsResponse, WriteIFWLoggingOptionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CloudWatchLogDelivery_LogGroupName = this.CloudWatchLogDelivery_LogGroupName;
            context.CloudWatchLogDelivery_LogType = this.CloudWatchLogDelivery_LogType;
            #if MODULAR
            if (this.CloudWatchLogDelivery_LogType == null && ParameterWasBound(nameof(this.CloudWatchLogDelivery_LogType)))
            {
                WriteWarning("You are passing $null as a value for parameter CloudWatchLogDelivery_LogType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTFleetWise.Model.PutLoggingOptionsRequest();
            
            
             // populate CloudWatchLogDelivery
            var requestCloudWatchLogDeliveryIsNull = true;
            request.CloudWatchLogDelivery = new Amazon.IoTFleetWise.Model.CloudWatchLogDeliveryOptions();
            System.String requestCloudWatchLogDelivery_cloudWatchLogDelivery_LogGroupName = null;
            if (cmdletContext.CloudWatchLogDelivery_LogGroupName != null)
            {
                requestCloudWatchLogDelivery_cloudWatchLogDelivery_LogGroupName = cmdletContext.CloudWatchLogDelivery_LogGroupName;
            }
            if (requestCloudWatchLogDelivery_cloudWatchLogDelivery_LogGroupName != null)
            {
                request.CloudWatchLogDelivery.LogGroupName = requestCloudWatchLogDelivery_cloudWatchLogDelivery_LogGroupName;
                requestCloudWatchLogDeliveryIsNull = false;
            }
            Amazon.IoTFleetWise.LogType requestCloudWatchLogDelivery_cloudWatchLogDelivery_LogType = null;
            if (cmdletContext.CloudWatchLogDelivery_LogType != null)
            {
                requestCloudWatchLogDelivery_cloudWatchLogDelivery_LogType = cmdletContext.CloudWatchLogDelivery_LogType;
            }
            if (requestCloudWatchLogDelivery_cloudWatchLogDelivery_LogType != null)
            {
                request.CloudWatchLogDelivery.LogType = requestCloudWatchLogDelivery_cloudWatchLogDelivery_LogType;
                requestCloudWatchLogDeliveryIsNull = false;
            }
             // determine if request.CloudWatchLogDelivery should be set to null
            if (requestCloudWatchLogDeliveryIsNull)
            {
                request.CloudWatchLogDelivery = null;
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
        
        private Amazon.IoTFleetWise.Model.PutLoggingOptionsResponse CallAWSServiceOperation(IAmazonIoTFleetWise client, Amazon.IoTFleetWise.Model.PutLoggingOptionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT FleetWise", "PutLoggingOptions");
            try
            {
                return client.PutLoggingOptionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CloudWatchLogDelivery_LogGroupName { get; set; }
            public Amazon.IoTFleetWise.LogType CloudWatchLogDelivery_LogType { get; set; }
            public System.Func<Amazon.IoTFleetWise.Model.PutLoggingOptionsResponse, WriteIFWLoggingOptionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
