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
    /// Deletes one or more detectors that were created. When a detector is deleted, its state
    /// will be cleared and the detector will be removed from the list of detectors. The deleted
    /// detector will no longer appear if referenced in the <a href="https://docs.aws.amazon.com/iotevents/latest/apireference/API_iotevents-data_ListDetectors.html">ListDetectors</a>
    /// API call.
    /// </summary>
    [Cmdlet("Remove", "IOTEDDetectorBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.IoTEventsData.Model.BatchDeleteDetectorErrorEntry")]
    [AWSCmdlet("Calls the AWS IoT Events Data BatchDeleteDetector API operation.", Operation = new[] {"BatchDeleteDetector"}, SelectReturnType = typeof(Amazon.IoTEventsData.Model.BatchDeleteDetectorResponse))]
    [AWSCmdletOutput("Amazon.IoTEventsData.Model.BatchDeleteDetectorErrorEntry or Amazon.IoTEventsData.Model.BatchDeleteDetectorResponse",
        "This cmdlet returns a collection of Amazon.IoTEventsData.Model.BatchDeleteDetectorErrorEntry objects.",
        "The service call response (type Amazon.IoTEventsData.Model.BatchDeleteDetectorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveIOTEDDetectorBatchCmdlet : AmazonIoTEventsDataClientCmdlet, IExecutor
    {
        
        #region Parameter Detector
        /// <summary>
        /// <para>
        /// <para>The list of one or more detectors to be deleted.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Detectors")]
        public Amazon.IoTEventsData.Model.DeleteDetectorRequest[] Detector { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BatchDeleteDetectorErrorEntries'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEventsData.Model.BatchDeleteDetectorResponse).
        /// Specifying the name of a property of type Amazon.IoTEventsData.Model.BatchDeleteDetectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BatchDeleteDetectorErrorEntries";
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
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Detector), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-IOTEDDetectorBatch (BatchDeleteDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTEventsData.Model.BatchDeleteDetectorResponse, RemoveIOTEDDetectorBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Detector != null)
            {
                context.Detector = new List<Amazon.IoTEventsData.Model.DeleteDetectorRequest>(this.Detector);
            }
            #if MODULAR
            if (this.Detector == null && ParameterWasBound(nameof(this.Detector)))
            {
                WriteWarning("You are passing $null as a value for parameter Detector which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTEventsData.Model.BatchDeleteDetectorRequest();
            
            if (cmdletContext.Detector != null)
            {
                request.Detectors = cmdletContext.Detector;
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
        
        private Amazon.IoTEventsData.Model.BatchDeleteDetectorResponse CallAWSServiceOperation(IAmazonIoTEventsData client, Amazon.IoTEventsData.Model.BatchDeleteDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events Data", "BatchDeleteDetector");
            try
            {
                #if DESKTOP
                return client.BatchDeleteDetector(request);
                #elif CORECLR
                return client.BatchDeleteDetectorAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.IoTEventsData.Model.DeleteDetectorRequest> Detector { get; set; }
            public System.Func<Amazon.IoTEventsData.Model.BatchDeleteDetectorResponse, RemoveIOTEDDetectorBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BatchDeleteDetectorErrorEntries;
        }
        
    }
}
