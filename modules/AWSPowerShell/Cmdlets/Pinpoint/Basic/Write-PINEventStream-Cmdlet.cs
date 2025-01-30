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
using Amazon.Pinpoint;
using Amazon.Pinpoint.Model;

namespace Amazon.PowerShell.Cmdlets.PIN
{
    /// <summary>
    /// Creates a new event stream for an application or updates the settings of an existing
    /// event stream for an application.
    /// </summary>
    [Cmdlet("Write", "PINEventStream", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Pinpoint.Model.EventStream")]
    [AWSCmdlet("Calls the Amazon Pinpoint PutEventStream API operation.", Operation = new[] {"PutEventStream"}, SelectReturnType = typeof(Amazon.Pinpoint.Model.PutEventStreamResponse))]
    [AWSCmdletOutput("Amazon.Pinpoint.Model.EventStream or Amazon.Pinpoint.Model.PutEventStreamResponse",
        "This cmdlet returns an Amazon.Pinpoint.Model.EventStream object.",
        "The service call response (type Amazon.Pinpoint.Model.PutEventStreamResponse) can be returned by specifying '-Select *'."
    )]
    public partial class WritePINEventStreamCmdlet : AmazonPinpointClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationId
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the application. This identifier is displayed as the <b>Project
        /// ID</b> on the Amazon Pinpoint console.</para>
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
        public System.String ApplicationId { get; set; }
        #endregion
        
        #region Parameter WriteEventStream_DestinationStreamArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon Kinesis data stream or Amazon Kinesis
        /// Data Firehose delivery stream that you want to publish event data to.</para><para>For a Kinesis data stream, the ARN format is: arn:aws:kinesis:<replaceable>region</replaceable>:<replaceable>account-id</replaceable>:stream/<replaceable>stream_name</replaceable></para><para>For a Kinesis Data Firehose delivery stream, the ARN format is: arn:aws:firehose:<replaceable>region</replaceable>:<replaceable>account-id</replaceable>:deliverystream/<replaceable>stream_name</replaceable></para>
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
        public System.String WriteEventStream_DestinationStreamArn { get; set; }
        #endregion
        
        #region Parameter WriteEventStream_RoleArn
        /// <summary>
        /// <para>
        /// <para>The AWS Identity and Access Management (IAM) role that authorizes Amazon Pinpoint
        /// to publish event data to the stream in your AWS account.</para>
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
        public System.String WriteEventStream_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'EventStream'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Pinpoint.Model.PutEventStreamResponse).
        /// Specifying the name of a property of type Amazon.Pinpoint.Model.PutEventStreamResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "EventStream";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ApplicationId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ApplicationId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-PINEventStream (PutEventStream)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Pinpoint.Model.PutEventStreamResponse, WritePINEventStreamCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ApplicationId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ApplicationId = this.ApplicationId;
            #if MODULAR
            if (this.ApplicationId == null && ParameterWasBound(nameof(this.ApplicationId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WriteEventStream_DestinationStreamArn = this.WriteEventStream_DestinationStreamArn;
            #if MODULAR
            if (this.WriteEventStream_DestinationStreamArn == null && ParameterWasBound(nameof(this.WriteEventStream_DestinationStreamArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WriteEventStream_DestinationStreamArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WriteEventStream_RoleArn = this.WriteEventStream_RoleArn;
            #if MODULAR
            if (this.WriteEventStream_RoleArn == null && ParameterWasBound(nameof(this.WriteEventStream_RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter WriteEventStream_RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Pinpoint.Model.PutEventStreamRequest();
            
            if (cmdletContext.ApplicationId != null)
            {
                request.ApplicationId = cmdletContext.ApplicationId;
            }
            
             // populate WriteEventStream
            var requestWriteEventStreamIsNull = true;
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
        
        private Amazon.Pinpoint.Model.PutEventStreamResponse CallAWSServiceOperation(IAmazonPinpoint client, Amazon.Pinpoint.Model.PutEventStreamRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Pinpoint", "PutEventStream");
            try
            {
                #if DESKTOP
                return client.PutEventStream(request);
                #elif CORECLR
                return client.PutEventStreamAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationId { get; set; }
            public System.String WriteEventStream_DestinationStreamArn { get; set; }
            public System.String WriteEventStream_RoleArn { get; set; }
            public System.Func<Amazon.Pinpoint.Model.PutEventStreamResponse, WritePINEventStreamCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.EventStream;
        }
        
    }
}
