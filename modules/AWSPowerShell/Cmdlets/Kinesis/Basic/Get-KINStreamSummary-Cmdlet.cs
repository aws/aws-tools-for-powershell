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
using Amazon.Kinesis;
using Amazon.Kinesis.Model;

namespace Amazon.PowerShell.Cmdlets.KIN
{
    /// <summary>
    /// Provides a summarized description of the specified Kinesis data stream without the
    /// shard list.
    /// 
    ///  <note><para>
    /// When invoking this API, you must use either the <c>StreamARN</c> or the <c>StreamName</c>
    /// parameter, or both. It is recommended that you use the <c>StreamARN</c> input parameter
    /// when you invoke this API.
    /// </para></note><para>
    /// The information returned includes the stream name, Amazon Resource Name (ARN), status,
    /// record retention period, approximate creation time, monitoring, encryption details,
    /// and open shard count. 
    /// </para><para><a>DescribeStreamSummary</a> has a limit of 20 transactions per second per account.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KINStreamSummary")]
    [OutputType("Amazon.Kinesis.Model.StreamDescriptionSummary")]
    [AWSCmdlet("Calls the Amazon Kinesis DescribeStreamSummary API operation.", Operation = new[] {"DescribeStreamSummary"}, SelectReturnType = typeof(Amazon.Kinesis.Model.DescribeStreamSummaryResponse))]
    [AWSCmdletOutput("Amazon.Kinesis.Model.StreamDescriptionSummary or Amazon.Kinesis.Model.DescribeStreamSummaryResponse",
        "This cmdlet returns an Amazon.Kinesis.Model.StreamDescriptionSummary object.",
        "The service call response (type Amazon.Kinesis.Model.DescribeStreamSummaryResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKINStreamSummaryCmdlet : AmazonKinesisClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The ARN of the stream.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream to describe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'StreamDescriptionSummary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kinesis.Model.DescribeStreamSummaryResponse).
        /// Specifying the name of a property of type Amazon.Kinesis.Model.DescribeStreamSummaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "StreamDescriptionSummary";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StreamName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StreamName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StreamName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kinesis.Model.DescribeStreamSummaryResponse, GetKINStreamSummaryCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StreamName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
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
            var request = new Amazon.Kinesis.Model.DescribeStreamSummaryRequest();
            
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
        
        private Amazon.Kinesis.Model.DescribeStreamSummaryResponse CallAWSServiceOperation(IAmazonKinesis client, Amazon.Kinesis.Model.DescribeStreamSummaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis", "DescribeStreamSummary");
            try
            {
                #if DESKTOP
                return client.DescribeStreamSummary(request);
                #elif CORECLR
                return client.DescribeStreamSummaryAsync(request).GetAwaiter().GetResult();
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
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.Kinesis.Model.DescribeStreamSummaryResponse, GetKINStreamSummaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.StreamDescriptionSummary;
        }
        
    }
}
