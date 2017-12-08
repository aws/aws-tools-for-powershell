/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// you identify stream name or stream Amazon Resource Name (ARN), and the starting chunk.
    /// Kinesis Video Streams then returns a stream of chunks in order by fragment number.
    /// 
    ///  <note><para>
    ///  You must first call the <code>GetDataEndpoint</code> API to get an endpoint to which
    /// you can then send the <code>GetMedia</code> requests. 
    /// </para></note><para>
    /// When you put media data (fragments) on a stream, Kinesis Video Streams stores each
    /// incoming fragment and related metadata in what is called a "chunk." For more information,
    /// see . The <code>GetMedia</code> API returns a stream of these chunks starting from
    /// the chunk that you specify in the request. 
    /// </para><para>
    /// The following limits apply when using the <code>GetMedia</code> API:
    /// </para><ul><li><para>
    /// A client can call <code>GetMedia</code> up to five times per second per stream. 
    /// </para></li><li><para>
    /// Kinesis Video Streams sends media data at a rate of up to 25 megabytes per second
    /// (or 200 megabits per second) during a <code>GetMedia</code> session. 
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Get", "KVMMedia")]
    [OutputType("Amazon.KinesisVideoMedia.Model.GetMediaResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams Media GetMedia API operation.", Operation = new[] {"GetMedia"})]
    [AWSCmdletOutput("Amazon.KinesisVideoMedia.Model.GetMediaResponse",
        "This cmdlet returns a Amazon.KinesisVideoMedia.Model.GetMediaResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKVMMediaCmdlet : AmazonKinesisVideoMediaClientCmdlet, IExecutor
    {
        
        #region Parameter StartSelector
        /// <summary>
        /// <para>
        /// <para>Identifies the starting chunk to get from the specified stream. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public Amazon.KinesisVideoMedia.Model.StartSelector StartSelector { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream from where you want to get the media content. If you don't specify
        /// the <code>streamARN</code>, you must specify the <code>streamName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The Kinesis video stream name from where you want to get the media content. If you
        /// don't specify the <code>streamName</code>, you must specify the <code>streamARN</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String StreamName { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.StartSelector = this.StartSelector;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetMediaAsync(request);
                return task.Result;
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
        }
        
    }
}
