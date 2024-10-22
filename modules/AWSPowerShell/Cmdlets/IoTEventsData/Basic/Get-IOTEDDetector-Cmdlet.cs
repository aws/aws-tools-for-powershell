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
using Amazon.IoTEventsData;
using Amazon.IoTEventsData.Model;

namespace Amazon.PowerShell.Cmdlets.IOTED
{
    /// <summary>
    /// Returns information about the specified detector (instance).
    /// </summary>
    [Cmdlet("Get", "IOTEDDetector")]
    [OutputType("Amazon.IoTEventsData.Model.Detector")]
    [AWSCmdlet("Calls the AWS IoT Events Data DescribeDetector API operation.", Operation = new[] {"DescribeDetector"}, SelectReturnType = typeof(Amazon.IoTEventsData.Model.DescribeDetectorResponse))]
    [AWSCmdletOutput("Amazon.IoTEventsData.Model.Detector or Amazon.IoTEventsData.Model.DescribeDetectorResponse",
        "This cmdlet returns an Amazon.IoTEventsData.Model.Detector object.",
        "The service call response (type Amazon.IoTEventsData.Model.DescribeDetectorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetIOTEDDetectorCmdlet : AmazonIoTEventsDataClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DetectorModelName
        /// <summary>
        /// <para>
        /// <para>The name of the detector model whose detectors (instances) you want information about.</para>
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
        public System.String DetectorModelName { get; set; }
        #endregion
        
        #region Parameter KeyValue
        /// <summary>
        /// <para>
        /// <para>A filter used to limit results to detectors (instances) created because of the given
        /// key ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KeyValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Detector'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEventsData.Model.DescribeDetectorResponse).
        /// Specifying the name of a property of type Amazon.IoTEventsData.Model.DescribeDetectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Detector";
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
                context.Select = CreateSelectDelegate<Amazon.IoTEventsData.Model.DescribeDetectorResponse, GetIOTEDDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DetectorModelName = this.DetectorModelName;
            #if MODULAR
            if (this.DetectorModelName == null && ParameterWasBound(nameof(this.DetectorModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KeyValue = this.KeyValue;
            
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
            var request = new Amazon.IoTEventsData.Model.DescribeDetectorRequest();
            
            if (cmdletContext.DetectorModelName != null)
            {
                request.DetectorModelName = cmdletContext.DetectorModelName;
            }
            if (cmdletContext.KeyValue != null)
            {
                request.KeyValue = cmdletContext.KeyValue;
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
        
        private Amazon.IoTEventsData.Model.DescribeDetectorResponse CallAWSServiceOperation(IAmazonIoTEventsData client, Amazon.IoTEventsData.Model.DescribeDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events Data", "DescribeDetector");
            try
            {
                #if DESKTOP
                return client.DescribeDetector(request);
                #elif CORECLR
                return client.DescribeDetectorAsync(request).GetAwaiter().GetResult();
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
            public System.String DetectorModelName { get; set; }
            public System.String KeyValue { get; set; }
            public System.Func<Amazon.IoTEventsData.Model.DescribeDetectorResponse, GetIOTEDDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Detector;
        }
        
    }
}
