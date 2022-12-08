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
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;

namespace Amazon.PowerShell.Cmdlets.KINF
{
    /// <summary>
    /// Lists your delivery streams in alphabetical order of their names.
    /// 
    ///  
    /// <para>
    /// The number of delivery streams might be too large to return using a single call to
    /// <code>ListDeliveryStreams</code>. You can limit the number of delivery streams returned,
    /// using the <code>Limit</code> parameter. To determine whether there are more delivery
    /// streams to list, check the value of <code>HasMoreDeliveryStreams</code> in the output.
    /// If there are more delivery streams to list, you can request them by calling this operation
    /// again and setting the <code>ExclusiveStartDeliveryStreamName</code> parameter to the
    /// name of the last delivery stream returned in the last call.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINFDeliveryStreamList")]
    [OutputType("Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse")]
    [AWSCmdlet("Calls the Amazon Kinesis Firehose ListDeliveryStreams API operation.", Operation = new[] {"ListDeliveryStreams"}, SelectReturnType = typeof(Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse))]
    [AWSCmdletOutput("Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse",
        "This cmdlet returns an Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetKINFDeliveryStreamListCmdlet : AmazonKinesisFirehoseClientCmdlet, IExecutor
    {
        
        #region Parameter DeliveryStreamType
        /// <summary>
        /// <para>
        /// <para>The delivery stream type. This can be one of the following values:</para><ul><li><para><code>DirectPut</code>: Provider applications access the delivery stream directly.</para></li><li><para><code>KinesisStreamAsSource</code>: The delivery stream uses a Kinesis data stream
        /// as a source.</para></li></ul><para>This parameter is optional. If this parameter is omitted, delivery streams of all
        /// types are returned.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisFirehose.DeliveryStreamType")]
        public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
        #endregion
        
        #region Parameter ExclusiveStartDeliveryStreamName
        /// <summary>
        /// <para>
        /// <para>The list of delivery streams returned by this call to <code>ListDeliveryStreams</code>
        /// will start with the delivery stream whose name comes alphabetically immediately after
        /// the name you specify in <code>ExclusiveStartDeliveryStreamName</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExclusiveStartDeliveryStreamName { get; set; }
        #endregion
        
        #region Parameter Limit
        /// <summary>
        /// <para>
        /// <para>The maximum number of delivery streams to list. The default value is 10.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Limit { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse).
        /// Specifying the name of a property of type Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse will result in that property being returned.
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
                context.Select = CreateSelectDelegate<Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse, GetKINFDeliveryStreamListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DeliveryStreamType = this.DeliveryStreamType;
            context.ExclusiveStartDeliveryStreamName = this.ExclusiveStartDeliveryStreamName;
            context.Limit = this.Limit;
            
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
            var request = new Amazon.KinesisFirehose.Model.ListDeliveryStreamsRequest();
            
            if (cmdletContext.DeliveryStreamType != null)
            {
                request.DeliveryStreamType = cmdletContext.DeliveryStreamType;
            }
            if (cmdletContext.ExclusiveStartDeliveryStreamName != null)
            {
                request.ExclusiveStartDeliveryStreamName = cmdletContext.ExclusiveStartDeliveryStreamName;
            }
            if (cmdletContext.Limit != null)
            {
                request.Limit = cmdletContext.Limit.Value;
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
        
        private Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse CallAWSServiceOperation(IAmazonKinesisFirehose client, Amazon.KinesisFirehose.Model.ListDeliveryStreamsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Firehose", "ListDeliveryStreams");
            try
            {
                #if DESKTOP
                return client.ListDeliveryStreams(request);
                #elif CORECLR
                return client.ListDeliveryStreamsAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KinesisFirehose.DeliveryStreamType DeliveryStreamType { get; set; }
            public System.String ExclusiveStartDeliveryStreamName { get; set; }
            public System.Int32? Limit { get; set; }
            public System.Func<Amazon.KinesisFirehose.Model.ListDeliveryStreamsResponse, GetKINFDeliveryStreamListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
