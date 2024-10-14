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
using Amazon.IoTWireless;
using Amazon.IoTWireless.Model;

namespace Amazon.PowerShell.Cmdlets.IOTW
{
    /// <summary>
    /// Update the summary metric configuration.
    /// </summary>
    [Cmdlet("Update", "IOTWMetricConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS IoT Wireless UpdateMetricConfiguration API operation.", Operation = new[] {"UpdateMetricConfiguration"}, SelectReturnType = typeof(Amazon.IoTWireless.Model.UpdateMetricConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.IoTWireless.Model.UpdateMetricConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.IoTWireless.Model.UpdateMetricConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateIOTWMetricConfigurationCmdlet : AmazonIoTWirelessClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter SummaryMetric_Status
        /// <summary>
        /// <para>
        /// <para>The status of the configuration of summary metrics.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.IoTWireless.SummaryMetricConfigurationStatus")]
        public Amazon.IoTWireless.SummaryMetricConfigurationStatus SummaryMetric_Status { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTWireless.Model.UpdateMetricConfigurationResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the SummaryMetric_Status parameter.
        /// The -PassThru parameter is deprecated, use -Select '^SummaryMetric_Status' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^SummaryMetric_Status' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SummaryMetric_Status), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTWMetricConfiguration (UpdateMetricConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTWireless.Model.UpdateMetricConfigurationResponse, UpdateIOTWMetricConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.SummaryMetric_Status;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.SummaryMetric_Status = this.SummaryMetric_Status;
            
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
            var request = new Amazon.IoTWireless.Model.UpdateMetricConfigurationRequest();
            
            
             // populate SummaryMetric
            var requestSummaryMetricIsNull = true;
            request.SummaryMetric = new Amazon.IoTWireless.Model.SummaryMetricConfiguration();
            Amazon.IoTWireless.SummaryMetricConfigurationStatus requestSummaryMetric_summaryMetric_Status = null;
            if (cmdletContext.SummaryMetric_Status != null)
            {
                requestSummaryMetric_summaryMetric_Status = cmdletContext.SummaryMetric_Status;
            }
            if (requestSummaryMetric_summaryMetric_Status != null)
            {
                request.SummaryMetric.Status = requestSummaryMetric_summaryMetric_Status;
                requestSummaryMetricIsNull = false;
            }
             // determine if request.SummaryMetric should be set to null
            if (requestSummaryMetricIsNull)
            {
                request.SummaryMetric = null;
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
        
        private Amazon.IoTWireless.Model.UpdateMetricConfigurationResponse CallAWSServiceOperation(IAmazonIoTWireless client, Amazon.IoTWireless.Model.UpdateMetricConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Wireless", "UpdateMetricConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateMetricConfiguration(request);
                #elif CORECLR
                return client.UpdateMetricConfigurationAsync(request).GetAwaiter().GetResult();
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
            public Amazon.IoTWireless.SummaryMetricConfigurationStatus SummaryMetric_Status { get; set; }
            public System.Func<Amazon.IoTWireless.Model.UpdateMetricConfigurationResponse, UpdateIOTWMetricConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
