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
using Amazon.XRay;
using Amazon.XRay.Model;

namespace Amazon.PowerShell.Cmdlets.XR
{
    /// <summary>
    /// Uploads segment documents to Amazon Web Services X-Ray. The <a href="https://docs.aws.amazon.com/xray/index.html">X-Ray
    /// SDK</a> generates segment documents and sends them to the X-Ray daemon, which uploads
    /// them in batches. A segment document can be a completed segment, an in-progress segment,
    /// or an array of subsegments.
    /// 
    ///  
    /// <para>
    /// Segments must include the following fields. For the full segment document schema,
    /// see <a href="https://docs.aws.amazon.com/xray/latest/devguide/xray-api-segmentdocuments.html">Amazon
    /// Web Services X-Ray Segment Documents</a> in the <i>Amazon Web Services X-Ray Developer
    /// Guide</i>.
    /// </para><para><b>Required segment document fields</b></para><ul><li><para><code>name</code> - The name of the service that handled the request.
    /// </para></li><li><para><code>id</code> - A 64-bit identifier for the segment, unique among segments in the
    /// same trace, in 16 hexadecimal digits.
    /// </para></li><li><para><code>trace_id</code> - A unique identifier that connects all segments and subsegments
    /// originating from a single client request.
    /// </para></li><li><para><code>start_time</code> - Time the segment or subsegment was created, in floating
    /// point seconds in epoch time, accurate to milliseconds. For example, <code>1480615200.010</code>
    /// or <code>1.480615200010E9</code>.
    /// </para></li><li><para><code>end_time</code> - Time the segment or subsegment was closed. For example, <code>1480615200.090</code>
    /// or <code>1.480615200090E9</code>. Specify either an <code>end_time</code> or <code>in_progress</code>.
    /// </para></li><li><para><code>in_progress</code> - Set to <code>true</code> instead of specifying an <code>end_time</code>
    /// to record that a segment has been started, but is not complete. Send an in-progress
    /// segment when your application receives a request that will take a long time to serve,
    /// to trace that the request was received. When the response is sent, send the complete
    /// segment to overwrite the in-progress segment.
    /// </para></li></ul><para>
    /// A <code>trace_id</code> consists of three numbers separated by hyphens. For example,
    /// 1-58406520-a006649127e371903a2de979. This includes:
    /// </para><para><b>Trace ID Format</b></para><ul><li><para>
    /// The version number, for instance, <code>1</code>.
    /// </para></li><li><para>
    /// The time of the original request, in Unix epoch time, in 8 hexadecimal digits. For
    /// example, 10:00AM December 2nd, 2016 PST in epoch time is <code>1480615200</code> seconds,
    /// or <code>58406520</code> in hexadecimal.
    /// </para></li><li><para>
    /// A 96-bit identifier for the trace, globally unique, in 24 hexadecimal digits.
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Write", "XRTraceSegment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.XRay.Model.UnprocessedTraceSegment")]
    [AWSCmdlet("Calls the AWS X-Ray PutTraceSegments API operation.", Operation = new[] {"PutTraceSegments"}, SelectReturnType = typeof(Amazon.XRay.Model.PutTraceSegmentsResponse))]
    [AWSCmdletOutput("Amazon.XRay.Model.UnprocessedTraceSegment or Amazon.XRay.Model.PutTraceSegmentsResponse",
        "This cmdlet returns a collection of Amazon.XRay.Model.UnprocessedTraceSegment objects.",
        "The service call response (type Amazon.XRay.Model.PutTraceSegmentsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WriteXRTraceSegmentCmdlet : AmazonXRayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TraceSegmentDocument
        /// <summary>
        /// <para>
        /// <para>A string containing a JSON document defining one or more segments or subsegments.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("TraceSegmentDocuments")]
        public System.String[] TraceSegmentDocument { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'UnprocessedTraceSegments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.XRay.Model.PutTraceSegmentsResponse).
        /// Specifying the name of a property of type Amazon.XRay.Model.PutTraceSegmentsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "UnprocessedTraceSegments";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TraceSegmentDocument parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TraceSegmentDocument' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TraceSegmentDocument' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TraceSegmentDocument), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-XRTraceSegment (PutTraceSegments)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.XRay.Model.PutTraceSegmentsResponse, WriteXRTraceSegmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TraceSegmentDocument;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.TraceSegmentDocument != null)
            {
                context.TraceSegmentDocument = new List<System.String>(this.TraceSegmentDocument);
            }
            #if MODULAR
            if (this.TraceSegmentDocument == null && ParameterWasBound(nameof(this.TraceSegmentDocument)))
            {
                WriteWarning("You are passing $null as a value for parameter TraceSegmentDocument which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.XRay.Model.PutTraceSegmentsRequest();
            
            if (cmdletContext.TraceSegmentDocument != null)
            {
                request.TraceSegmentDocuments = cmdletContext.TraceSegmentDocument;
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
        
        private Amazon.XRay.Model.PutTraceSegmentsResponse CallAWSServiceOperation(IAmazonXRay client, Amazon.XRay.Model.PutTraceSegmentsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS X-Ray", "PutTraceSegments");
            try
            {
                #if DESKTOP
                return client.PutTraceSegments(request);
                #elif CORECLR
                return client.PutTraceSegmentsAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> TraceSegmentDocument { get; set; }
            public System.Func<Amazon.XRay.Model.PutTraceSegmentsResponse, WriteXRTraceSegmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.UnprocessedTraceSegments;
        }
        
    }
}
