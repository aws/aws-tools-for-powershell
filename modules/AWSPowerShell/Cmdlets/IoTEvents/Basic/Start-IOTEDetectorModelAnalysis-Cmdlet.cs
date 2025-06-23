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
using Amazon.IoTEvents;
using Amazon.IoTEvents.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTE
{
    /// <summary>
    /// Performs an analysis of your detector model. For more information, see <a href="https://docs.aws.amazon.com/iotevents/latest/developerguide/iotevents-analyze-api.html">Troubleshooting
    /// a detector model</a> in the <i>AWS IoT Events Developer Guide</i>.
    /// </summary>
    [Cmdlet("Start", "IOTEDetectorModelAnalysis", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS IoT Events StartDetectorModelAnalysis API operation.", Operation = new[] {"StartDetectorModelAnalysis"}, SelectReturnType = typeof(Amazon.IoTEvents.Model.StartDetectorModelAnalysisResponse))]
    [AWSCmdletOutput("System.String or Amazon.IoTEvents.Model.StartDetectorModelAnalysisResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.IoTEvents.Model.StartDetectorModelAnalysisResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartIOTEDetectorModelAnalysisCmdlet : AmazonIoTEventsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DetectorModelDefinition_InitialStateName
        /// <summary>
        /// <para>
        /// <para>The state that is entered at the creation of each detector (instance).</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DetectorModelDefinition_InitialStateName { get; set; }
        #endregion
        
        #region Parameter DetectorModelDefinition_State
        /// <summary>
        /// <para>
        /// <para>Information about the states of the detector.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        [Alias("DetectorModelDefinition_States")]
        public Amazon.IoTEvents.Model.State[] DetectorModelDefinition_State { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AnalysisId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTEvents.Model.StartDetectorModelAnalysisResponse).
        /// Specifying the name of a property of type Amazon.IoTEvents.Model.StartDetectorModelAnalysisResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AnalysisId";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-IOTEDetectorModelAnalysis (StartDetectorModelAnalysis)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTEvents.Model.StartDetectorModelAnalysisResponse, StartIOTEDetectorModelAnalysisCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DetectorModelDefinition_InitialStateName = this.DetectorModelDefinition_InitialStateName;
            #if MODULAR
            if (this.DetectorModelDefinition_InitialStateName == null && ParameterWasBound(nameof(this.DetectorModelDefinition_InitialStateName)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorModelDefinition_InitialStateName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.DetectorModelDefinition_State != null)
            {
                context.DetectorModelDefinition_State = new List<Amazon.IoTEvents.Model.State>(this.DetectorModelDefinition_State);
            }
            #if MODULAR
            if (this.DetectorModelDefinition_State == null && ParameterWasBound(nameof(this.DetectorModelDefinition_State)))
            {
                WriteWarning("You are passing $null as a value for parameter DetectorModelDefinition_State which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IoTEvents.Model.StartDetectorModelAnalysisRequest();
            
            
             // populate DetectorModelDefinition
            var requestDetectorModelDefinitionIsNull = true;
            request.DetectorModelDefinition = new Amazon.IoTEvents.Model.DetectorModelDefinition();
            System.String requestDetectorModelDefinition_detectorModelDefinition_InitialStateName = null;
            if (cmdletContext.DetectorModelDefinition_InitialStateName != null)
            {
                requestDetectorModelDefinition_detectorModelDefinition_InitialStateName = cmdletContext.DetectorModelDefinition_InitialStateName;
            }
            if (requestDetectorModelDefinition_detectorModelDefinition_InitialStateName != null)
            {
                request.DetectorModelDefinition.InitialStateName = requestDetectorModelDefinition_detectorModelDefinition_InitialStateName;
                requestDetectorModelDefinitionIsNull = false;
            }
            List<Amazon.IoTEvents.Model.State> requestDetectorModelDefinition_detectorModelDefinition_State = null;
            if (cmdletContext.DetectorModelDefinition_State != null)
            {
                requestDetectorModelDefinition_detectorModelDefinition_State = cmdletContext.DetectorModelDefinition_State;
            }
            if (requestDetectorModelDefinition_detectorModelDefinition_State != null)
            {
                request.DetectorModelDefinition.States = requestDetectorModelDefinition_detectorModelDefinition_State;
                requestDetectorModelDefinitionIsNull = false;
            }
             // determine if request.DetectorModelDefinition should be set to null
            if (requestDetectorModelDefinitionIsNull)
            {
                request.DetectorModelDefinition = null;
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
        
        private Amazon.IoTEvents.Model.StartDetectorModelAnalysisResponse CallAWSServiceOperation(IAmazonIoTEvents client, Amazon.IoTEvents.Model.StartDetectorModelAnalysisRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT Events", "StartDetectorModelAnalysis");
            try
            {
                return client.StartDetectorModelAnalysisAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DetectorModelDefinition_InitialStateName { get; set; }
            public List<Amazon.IoTEvents.Model.State> DetectorModelDefinition_State { get; set; }
            public System.Func<Amazon.IoTEvents.Model.StartDetectorModelAnalysisResponse, StartIOTEDetectorModelAnalysisCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AnalysisId;
        }
        
    }
}
