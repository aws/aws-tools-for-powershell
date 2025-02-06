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
using Amazon.KinesisVideoMedia;
using Amazon.KinesisVideoMedia.Model;

namespace Amazon.PowerShell.Cmdlets.KVM
{
    /// <summary>
    /// Use this API to retrieve media content from a Kinesis video stream. In the request,
    /// you identify the stream name or stream Amazon Resource Name (ARN), and the starting
    /// chunk. Kinesis Video Streams then returns a stream of chunks in order by fragment
    /// number.
    /// 
    ///  <note><para>
    /// You must first call the <c>GetDataEndpoint</c> API to get an endpoint. Then send the
    /// <c>GetMedia</c> requests to this endpoint using the <a href="https://docs.aws.amazon.com/cli/latest/reference/">--endpoint-url
    /// parameter</a>. 
    /// </para></note><para>
    /// When you put media data (fragments) on a stream, Kinesis Video Streams stores each
    /// incoming fragment and related metadata in what is called a "chunk." For more information,
    /// see <a href="https://docs.aws.amazon.com/kinesisvideostreams/latest/dg/API_dataplane_PutMedia.html">PutMedia</a>.
    /// The <c>GetMedia</c> API returns a stream of these chunks starting from the chunk that
    /// you specify in the request. 
    /// </para><para>
    /// The following limits apply when using the <c>GetMedia</c> API:
    /// </para><ul><li><para>
    /// A client can call <c>GetMedia</c> up to five times per second per stream. 
    /// </para></li><li><para>
    /// Kinesis Video Streams sends media data at a rate of up to 25 megabytes per second
    /// (or 200 megabits per second) during a <c>GetMedia</c> session. 
    /// </para></li></ul><note><para>
    /// If an error is thrown after invoking a Kinesis Video Streams media API, in addition
    /// to the HTTP status code and the response body, it includes the following pieces of
    /// information: 
    /// </para><ul><li><para><c>x-amz-ErrorType</c> HTTP header – contains a more specific error type in addition
    /// to what the HTTP status code provides. 
    /// </para></li><li><para><c>x-amz-RequestId</c> HTTP header – if you want to report an issue to AWS, the support
    /// team can better diagnose the problem if given the Request Id.
    /// </para></li></ul><para>
    /// Both the HTTP status code and the ErrorType header can be utilized to make programmatic
    /// decisions about whether errors are retry-able and under what conditions, as well as
    /// provide information on what actions the client programmer might need to take in order
    /// to successfully try again.
    /// </para><para>
    /// For more information, see the <b>Errors</b> section at the bottom of this topic, as
    /// well as <a href="https://docs.aws.amazon.com/kinesisvideostreams/latest/dg/CommonErrors.html">Common
    /// Errors</a>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Get", "KVMMedia")]
    [OutputType("Amazon.KinesisVideoMedia.Model.GetMediaResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams Media GetMedia API operation.", Operation = new[] {"GetMedia"}, SelectReturnType = typeof(Amazon.KinesisVideoMedia.Model.GetMediaResponse))]
    [AWSCmdletOutput("Amazon.KinesisVideoMedia.Model.GetMediaResponse",
        "This cmdlet returns an Amazon.KinesisVideoMedia.Model.GetMediaResponse object containing multiple properties."
    )]
    public partial class GetKVMMediaCmdlet : AmazonKinesisVideoMediaClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StartSelector
        /// <summary>
        /// <para>
        /// <para>Identifies the starting chunk to get from the specified stream. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.KinesisVideoMedia.Model.StartSelector StartSelector { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream from where you want to get the media content. If you don't specify
        /// the <c>streamARN</c>, you must specify the <c>streamName</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The Kinesis video stream name from where you want to get the media content. If you
        /// don't specify the <c>streamName</c>, you must specify the <c>streamARN</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideoMedia.Model.GetMediaResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideoMedia.Model.GetMediaResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
                context.Select = CreateSelectDelegate<Amazon.KinesisVideoMedia.Model.GetMediaResponse, GetKVMMediaCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.StartSelector = this.StartSelector;
            #if MODULAR
            if (this.StartSelector == null && ParameterWasBound(nameof(this.StartSelector)))
            {
                WriteWarning("You are passing $null as a value for parameter StartSelector which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StreamARN = this.StreamARN;
            context.StreamName = this.StreamName;
            
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
            var request = new Amazon.KinesisVideoMedia.Model.GetMediaRequest();
            
            if (cmdletContext.StartSelector != null)
            {
                request.StartSelector = cmdletContext.StartSelector;
            }
            if (cmdletContext.StreamARN != null)
            {
                request.StreamARN = cmdletContext.StreamARN;
            }
            if (cmdletContext.StreamName != null)
            {
                request.StreamName = cmdletContext.StreamName;
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
        
        private Amazon.KinesisVideoMedia.Model.GetMediaResponse CallAWSServiceOperation(IAmazonKinesisVideoMedia client, Amazon.KinesisVideoMedia.Model.GetMediaRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams Media", "GetMedia");
            try
            {
                #if DESKTOP
                return client.GetMedia(request);
                #elif CORECLR
                return client.GetMediaAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KinesisVideoMedia.Model.StartSelector StartSelector { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.KinesisVideoMedia.Model.GetMediaResponse, GetKVMMediaCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
