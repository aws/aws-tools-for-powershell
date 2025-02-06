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
    /// Returns the most current information about the channel. Specify the <c>ChannelName</c>
    /// or <c>ChannelARN</c> in the input.
    /// </summary>
    [Cmdlet("Get", "KVMediaStorageConfiguration")]
    [OutputType("Amazon.KinesisVideo.Model.MediaStorageConfiguration")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams DescribeMediaStorageConfiguration API operation.", Operation = new[] {"DescribeMediaStorageConfiguration"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationResponse))]
    [AWSCmdletOutput("Amazon.KinesisVideo.Model.MediaStorageConfiguration or Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationResponse",
        "This cmdlet returns an Amazon.KinesisVideo.Model.MediaStorageConfiguration object.",
        "The service call response (type Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetKVMediaStorageConfigurationCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ChannelARN { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name of the channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MediaStorageConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MediaStorageConfiguration";
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
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationResponse, GetKVMediaStorageConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelARN = this.ChannelARN;
            context.ChannelName = this.ChannelName;
            
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
            var request = new Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationRequest();
            
            if (cmdletContext.ChannelARN != null)
            {
                request.ChannelARN = cmdletContext.ChannelARN;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
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
        
        private Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "DescribeMediaStorageConfiguration");
            try
            {
                #if DESKTOP
                return client.DescribeMediaStorageConfiguration(request);
                #elif CORECLR
                return client.DescribeMediaStorageConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelARN { get; set; }
            public System.String ChannelName { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.DescribeMediaStorageConfigurationResponse, GetKVMediaStorageConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MediaStorageConfiguration;
        }
        
    }
}
