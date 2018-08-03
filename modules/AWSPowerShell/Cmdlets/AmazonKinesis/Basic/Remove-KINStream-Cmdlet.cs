/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Deletes a Kinesis data stream and all its shards and data. You must shut down any
    /// applications that are operating on the stream before you delete the stream. If an
    /// application attempts to operate on a deleted stream, it receives the exception <code>ResourceNotFoundException</code>.
    /// 
    ///  
    /// <para>
    /// If the stream is in the <code>ACTIVE</code> state, you can delete it. After a <code>DeleteStream</code>
    /// request, the specified stream is in the <code>DELETING</code> state until Kinesis
    /// Data Streams completes the deletion.
    /// </para><para><b>Note:</b> Kinesis Data Streams might continue to accept data read and write operations,
    /// such as <a>PutRecord</a>, <a>PutRecords</a>, and <a>GetRecords</a>, on a stream in
    /// the <code>DELETING</code> state until the stream deletion is complete.
    /// </para><para>
    /// When you delete a stream, any shards in that stream are also deleted, and any tags
    /// are dissociated from the stream.
    /// </para><para>
    /// You can use the <a>DescribeStream</a> operation to check the state of the stream,
    /// which is returned in <code>StreamStatus</code>.
    /// </para><para><a>DeleteStream</a> has a limit of five transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "KINStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None","System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis DeleteStream API operation.", Operation = new[] {"DeleteStream"})]
    [AWSCmdletOutput("None or System.String",
        "When you use the PassThru parameter, this cmdlet outputs the value supplied to the StreamName parameter. Otherwise, this cmdlet does not return any output. " +
        "The service response (type Amazon.Kinesis.Model.DeleteStreamResponse) can be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RemoveKINStreamCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        #region Parameter EnforceConsumerDeletion
        /// <summary>
        /// <para>
        /// <para>If this parameter is unset (<code>null</code>) or if you set it to <code>false</code>,
        /// and the stream has registered consumers, the call to <code>DeleteStream</code> fails
        /// with a <code>ResourceInUseException</code>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean EnforceConsumerDeletion { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to delete.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Returns the value passed to the StreamName parameter.
        /// By default, this cmdlet does not generate any output.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter PassThru { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("StreamName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-KINStream (DeleteStream)"))
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
            
            if (ParameterWasBound("EnforceConsumerDeletion"))
                context.EnforceConsumerDeletion = this.EnforceConsumerDeletion;
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
            var request = new Amazon.Kinesis.Model.DeleteStreamRequest();
            
            if (cmdletContext.EnforceConsumerDeletion != null)
            {
                request.EnforceConsumerDeletion = cmdletContext.EnforceConsumerDeletion.Value;
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
                object pipelineOutput = null;
                if (this.PassThru.IsPresent)
                    pipelineOutput = this.StreamName;
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
        
        private Amazon.Kinesis.Model.DeleteStreamResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.DeleteStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "DeleteStream");
            try
            {
                #if DESKTOP
                return client.DeleteStream(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.DeleteStreamAsync(request);
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
            public System.Boolean? EnforceConsumerDeletion { get; set; }
            public System.String StreamName { get; set; }
        }
        
    }
}
