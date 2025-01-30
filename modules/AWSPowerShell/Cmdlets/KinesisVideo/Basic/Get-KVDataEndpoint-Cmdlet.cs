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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Gets an endpoint for a specified stream for either reading or writing. Use this endpoint
    /// in your application to read from the specified stream (using the <c>GetMedia</c> or
    /// <c>GetMediaForFragmentList</c> operations) or write to it (using the <c>PutMedia</c>
    /// operation). 
    /// 
    ///  <note><para>
    /// The returned endpoint does not have the API name appended. The client needs to add
    /// the API name to the returned endpoint.
    /// </para></note><para>
    /// In the request, specify the stream either by <c>StreamName</c> or <c>StreamARN</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "KVDataEndpoint")]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams GetDataEndpoint API operation.", Operation = new[] {"GetDataEndpoint"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.GetDataEndpointResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisVideo.Model.GetDataEndpointResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KinesisVideo.Model.GetDataEndpointResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKVDataEndpointCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter APIName
        /// <summary>
        /// <para>
        /// <para>The name of the API action for which to get an endpoint.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.KinesisVideo.APIName")]
        public Amazon.KinesisVideo.APIName APIName { get; set; }
        #endregion
        
        #region Parameter StreamARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the stream that you want to get the endpoint for.
        /// You must specify either this parameter or a <c>StreamName</c> in the request. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamARN { get; set; }
        #endregion
        
        #region Parameter StreamName
        /// <summary>
        /// <para>
        /// <para>The name of the stream that you want to get the endpoint for. You must specify either
        /// this parameter or a <c>StreamARN</c> in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataEndpoint'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.GetDataEndpointResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideo.Model.GetDataEndpointResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataEndpoint";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the APIName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^APIName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^APIName' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.GetDataEndpointResponse, GetKVDataEndpointCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.APIName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.APIName = this.APIName;
            #if MODULAR
            if (this.APIName == null && ParameterWasBound(nameof(this.APIName)))
            {
                WriteWarning("You are passing $null as a value for parameter APIName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.KinesisVideo.Model.GetDataEndpointRequest();
            
            if (cmdletContext.APIName != null)
            {
                request.APIName = cmdletContext.APIName;
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
        
        private Amazon.KinesisVideo.Model.GetDataEndpointResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.GetDataEndpointRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "GetDataEndpoint");
            try
            {
                #if DESKTOP
                return client.GetDataEndpoint(request);
                #elif CORECLR
                return client.GetDataEndpointAsync(request).GetAwaiter().GetResult();
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
            public Amazon.KinesisVideo.APIName APIName { get; set; }
            public System.String StreamARN { get; set; }
            public System.String StreamName { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.GetDataEndpointResponse, GetKVDataEndpointCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataEndpoint;
        }
        
    }
}
