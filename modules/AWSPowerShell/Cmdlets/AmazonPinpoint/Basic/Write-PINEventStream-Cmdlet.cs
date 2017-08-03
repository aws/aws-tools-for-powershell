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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Use to create or update the event stream for an app.
    /// </summary>
    [Cmdlet("Write", "PINEventStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.EventStream")]
    [AWSCmdlet("Invokes the PutEventStream operation against Amazon Pinpoint.", Operation = new[] {"PutEventStream"})]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.EventStream",
        "This cmdlet returns a EventStream object.",
        "The service call response (type Amazon.Pinpoint.Model.PutEventStreamResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class WritePINEventStreamCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// ApplicationId
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter WriteEventStream_DestinationStreamArn
        /// <summary>
        /// <para>
        /// The Amazon Resource Name (ARN) of
        /// the Amazon Kinesis stream or Firehose delivery stream to which you want to publish
        /// events. Firehose ARN: arn:aws:firehose:REGION:ACCOUNT_ID:deliverystream/STREAM_NAME
        /// Kinesis ARN: arn:aws:kinesis:REGION:ACCOUNT_ID:stream/STREAM_NAME
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteEventStream_DestinationStreamArn { get; set; }
        #endregion
        
        #region Parameter WriteEventStream_ExternalId
        /// <summary>
        /// <para>
        /// The external ID assigned the IAM role that
        /// authorizes Amazon Pinpoint to publish to the stream.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteEventStream_ExternalId { get; set; }
        #endregion
        
        #region Parameter WriteEventStream_RoleArn
        /// <summary>
        /// <para>
        /// The IAM role that authorizes Amazon Pinpoint to
        /// publish events to the stream in your account.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String WriteEventStream_RoleArn { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-PINEventStream (PutEventStream)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplicationId = this.ApplicationId;
            context.WriteEventStream_DestinationStreamArn = this.WriteEventStream_DestinationStreamArn;
            context.WriteEventStream_ExternalId = this.WriteEventStream_ExternalId;
            context.WriteEventStream_RoleArn = this.WriteEventStream_RoleArn;
            
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
            var request = new Amazon.Pinpoint.Model.PutEventStreamRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate WriteEventStream
            bool requestWriteEventStreamIsNull = true;
            request.WriteEventStream = new Amazon.Pinpoint.Model.WriteEventStream();
            System.String requestWriteEventStream_writeEventStream_DestinationStreamArn = null;
            if (cmdletContext.WriteEventStream_DestinationStreamArn != null)
            {
                requestWriteEventStream_writeEventStream_DestinationStreamArn = cmdletContext.WriteEventStream_DestinationStreamArn;
            }
            if (requestWriteEventStream_writeEventStream_DestinationStreamArn != null)
            {
                request.WriteEventStream.DestinationStreamArn = requestWriteEventStream_writeEventStream_DestinationStreamArn;
                requestWriteEventStreamIsNull = false;
            }
            System.String requestWriteEventStream_writeEventStream_ExternalId = null;
            if (cmdletContext.WriteEventStream_ExternalId != null)
            {
                requestWriteEventStream_writeEventStream_ExternalId = cmdletContext.WriteEventStream_ExternalId;
            }
            if (requestWriteEventStream_writeEventStream_ExternalId != null)
            {
                request.WriteEventStream.ExternalId = requestWriteEventStream_writeEventStream_ExternalId;
                requestWriteEventStreamIsNull = false;
            }
            System.String requestWriteEventStream_writeEventStream_RoleArn = null;
            if (cmdletContext.WriteEventStream_RoleArn != null)
            {
                requestWriteEventStream_writeEventStream_RoleArn = cmdletContext.WriteEventStream_RoleArn;
            }
            if (requestWriteEventStream_writeEventStream_RoleArn != null)
            {
                request.WriteEventStream.RoleArn = requestWriteEventStream_writeEventStream_RoleArn;
                requestWriteEventStreamIsNull = false;
            }
             // determine if request.WriteEventStream should be set to null
            if (requestWriteEventStreamIsNull)
            {
                request.WriteEventStream = null;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.EventStream;
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
        
        private Amazon.Pinpoint.Model.PutEventStreamResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.PutEventStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "PutEventStream");
            #if DESKTOP
            return client.PutEventStream(request);
            #elif CORECLR
            // todo: handle AggregateException and extract true service exception for rethrow
            var task = client.PutEventStreamAsync(request);
            return task.Result;
            #else
                    #error "Unknown build edition"
            #endif
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ApplicationId { get; set; }
            public System.String WriteEventStream_DestinationStreamArn { get; set; }
            public System.String WriteEventStream_ExternalId { get; set; }
            public System.String WriteEventStream_RoleArn { get; set; }
        }
        
    }
}
