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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// Starts processing a stream processor. You create a stream processor by calling <a>CreateStreamProcessor</a>.
    /// To tell <code>StartStreamProcessor</code> which stream processor to start, use the
    /// value of the <code>Name</code> field specified in the call to <code>CreateStreamProcessor</code>.
    /// 
    ///  
    /// <para>
    /// If you are using a label detection stream processor to detect labels, you need to
    /// provide a <code>Start selector</code> and a <code>Stop selector</code> to determine
    /// the length of the stream processing time.
    /// </para>
    /// </summary>
    [Cmdlet("Start", "REKStreamProcessor", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition StartStreamProcessor API operation.", Operation = new[] {"StartStreamProcessor"}, SelectReturnType = typeof(Amazon.Rekognition.Model.StartStreamProcessorResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.StartStreamProcessorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.StartStreamProcessorResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartREKStreamProcessorCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        #region Parameter KVSStreamStartSelector_FragmentNumber
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the fragment. This value monotonically increases based on
        /// the ingestion order. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StartSelector_KVSStreamStartSelector_FragmentNumber")]
        public System.String KVSStreamStartSelector_FragmentNumber { get; set; }
        #endregion
        
        #region Parameter StopSelector_MaxDurationInSecond
        /// <summary>
        /// <para>
        /// <para> Specifies the maximum amount of time in seconds that you want the stream to be processed.
        /// The largest amount of time is 2 minutes. The default is 10 seconds. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StopSelector_MaxDurationInSeconds")]
        public System.Int64? StopSelector_MaxDurationInSecond { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the stream processor to start processing.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter KVSStreamStartSelector_ProducerTimestamp
        /// <summary>
        /// <para>
        /// <para> The timestamp from the producer corresponding to the fragment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StartSelector_KVSStreamStartSelector_ProducerTimestamp")]
        public System.Int64? KVSStreamStartSelector_ProducerTimestamp { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'SessionId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.StartStreamProcessorResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.StartStreamProcessorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "SessionId";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-REKStreamProcessor (StartStreamProcessor)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.StartStreamProcessorResponse, StartREKStreamProcessorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.KVSStreamStartSelector_FragmentNumber = this.KVSStreamStartSelector_FragmentNumber;
            context.KVSStreamStartSelector_ProducerTimestamp = this.KVSStreamStartSelector_ProducerTimestamp;
            context.StopSelector_MaxDurationInSecond = this.StopSelector_MaxDurationInSecond;
            
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
            var request = new Amazon.Rekognition.Model.StartStreamProcessorRequest();
            
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate StartSelector
            var requestStartSelectorIsNull = true;
            request.StartSelector = new Amazon.Rekognition.Model.StreamProcessingStartSelector();
            Amazon.Rekognition.Model.KinesisVideoStreamStartSelector requestStartSelector_startSelector_KVSStreamStartSelector = null;
            
             // populate KVSStreamStartSelector
            var requestStartSelector_startSelector_KVSStreamStartSelectorIsNull = true;
            requestStartSelector_startSelector_KVSStreamStartSelector = new Amazon.Rekognition.Model.KinesisVideoStreamStartSelector();
            System.String requestStartSelector_startSelector_KVSStreamStartSelector_kVSStreamStartSelector_FragmentNumber = null;
            if (cmdletContext.KVSStreamStartSelector_FragmentNumber != null)
            {
                requestStartSelector_startSelector_KVSStreamStartSelector_kVSStreamStartSelector_FragmentNumber = cmdletContext.KVSStreamStartSelector_FragmentNumber;
            }
            if (requestStartSelector_startSelector_KVSStreamStartSelector_kVSStreamStartSelector_FragmentNumber != null)
            {
                requestStartSelector_startSelector_KVSStreamStartSelector.FragmentNumber = requestStartSelector_startSelector_KVSStreamStartSelector_kVSStreamStartSelector_FragmentNumber;
                requestStartSelector_startSelector_KVSStreamStartSelectorIsNull = false;
            }
            System.Int64? requestStartSelector_startSelector_KVSStreamStartSelector_kVSStreamStartSelector_ProducerTimestamp = null;
            if (cmdletContext.KVSStreamStartSelector_ProducerTimestamp != null)
            {
                requestStartSelector_startSelector_KVSStreamStartSelector_kVSStreamStartSelector_ProducerTimestamp = cmdletContext.KVSStreamStartSelector_ProducerTimestamp.Value;
            }
            if (requestStartSelector_startSelector_KVSStreamStartSelector_kVSStreamStartSelector_ProducerTimestamp != null)
            {
                requestStartSelector_startSelector_KVSStreamStartSelector.ProducerTimestamp = requestStartSelector_startSelector_KVSStreamStartSelector_kVSStreamStartSelector_ProducerTimestamp.Value;
                requestStartSelector_startSelector_KVSStreamStartSelectorIsNull = false;
            }
             // determine if requestStartSelector_startSelector_KVSStreamStartSelector should be set to null
            if (requestStartSelector_startSelector_KVSStreamStartSelectorIsNull)
            {
                requestStartSelector_startSelector_KVSStreamStartSelector = null;
            }
            if (requestStartSelector_startSelector_KVSStreamStartSelector != null)
            {
                request.StartSelector.KVSStreamStartSelector = requestStartSelector_startSelector_KVSStreamStartSelector;
                requestStartSelectorIsNull = false;
            }
             // determine if request.StartSelector should be set to null
            if (requestStartSelectorIsNull)
            {
                request.StartSelector = null;
            }
            
             // populate StopSelector
            var requestStopSelectorIsNull = true;
            request.StopSelector = new Amazon.Rekognition.Model.StreamProcessingStopSelector();
            System.Int64? requestStopSelector_stopSelector_MaxDurationInSecond = null;
            if (cmdletContext.StopSelector_MaxDurationInSecond != null)
            {
                requestStopSelector_stopSelector_MaxDurationInSecond = cmdletContext.StopSelector_MaxDurationInSecond.Value;
            }
            if (requestStopSelector_stopSelector_MaxDurationInSecond != null)
            {
                request.StopSelector.MaxDurationInSeconds = requestStopSelector_stopSelector_MaxDurationInSecond.Value;
                requestStopSelectorIsNull = false;
            }
             // determine if request.StopSelector should be set to null
            if (requestStopSelectorIsNull)
            {
                request.StopSelector = null;
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
        
        private Amazon.Rekognition.Model.StartStreamProcessorResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.StartStreamProcessorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "StartStreamProcessor");
            try
            {
                #if DESKTOP
                return client.StartStreamProcessor(request);
                #elif CORECLR
                return client.StartStreamProcessorAsync(request).GetAwaiter().GetResult();
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
            public System.String Name { get; set; }
            public System.String KVSStreamStartSelector_FragmentNumber { get; set; }
            public System.Int64? KVSStreamStartSelector_ProducerTimestamp { get; set; }
            public System.Int64? StopSelector_MaxDurationInSecond { get; set; }
            public System.Func<Amazon.Rekognition.Model.StartStreamProcessorResponse, StartREKStreamProcessorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.SessionId;
        }
        
    }
}
