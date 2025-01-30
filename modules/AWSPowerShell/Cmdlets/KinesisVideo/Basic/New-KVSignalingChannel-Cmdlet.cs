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
    /// Creates a signaling channel. 
    /// 
    ///  
    /// <para><c>CreateSignalingChannel</c> is an asynchronous operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "KVSignalingChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams CreateSignalingChannel API operation.", Operation = new[] {"CreateSignalingChannel"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.CreateSignalingChannelResponse))]
    [AWSCmdletOutput("System.String or Amazon.KinesisVideo.Model.CreateSignalingChannelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.KinesisVideo.Model.CreateSignalingChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewKVSignalingChannelCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>A name for the signaling channel that you are creating. It must be unique for each
        /// Amazon Web Services account and Amazon Web Services Region.</para>
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
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter ChannelType
        /// <summary>
        /// <para>
        /// <para>A type of the signaling channel that you are creating. Currently, <c>SINGLE_MASTER</c>
        /// is the only supported channel type. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.KinesisVideo.ChannelType")]
        public Amazon.KinesisVideo.ChannelType ChannelType { get; set; }
        #endregion
        
        #region Parameter SingleMasterConfiguration_MessageTtlSecond
        /// <summary>
        /// <para>
        /// <para>The period of time a signaling channel retains undelivered messages before they are
        /// discarded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SingleMasterConfiguration_MessageTtlSeconds")]
        public System.Int32? SingleMasterConfiguration_MessageTtlSecond { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A set of tags (key-value pairs) that you want to associate with this channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.KinesisVideo.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ChannelARN'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.CreateSignalingChannelResponse).
        /// Specifying the name of a property of type Amazon.KinesisVideo.Model.CreateSignalingChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ChannelARN";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChannelName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChannelName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChannelName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-KVSignalingChannel (CreateSignalingChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.CreateSignalingChannelResponse, NewKVSignalingChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChannelName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelType = this.ChannelType;
            context.SingleMasterConfiguration_MessageTtlSecond = this.SingleMasterConfiguration_MessageTtlSecond;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.KinesisVideo.Model.Tag>(this.Tag);
            }
            
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
            var request = new Amazon.KinesisVideo.Model.CreateSignalingChannelRequest();
            
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.ChannelType != null)
            {
                request.ChannelType = cmdletContext.ChannelType;
            }
            
             // populate SingleMasterConfiguration
            var requestSingleMasterConfigurationIsNull = true;
            request.SingleMasterConfiguration = new Amazon.KinesisVideo.Model.SingleMasterConfiguration();
            System.Int32? requestSingleMasterConfiguration_singleMasterConfiguration_MessageTtlSecond = null;
            if (cmdletContext.SingleMasterConfiguration_MessageTtlSecond != null)
            {
                requestSingleMasterConfiguration_singleMasterConfiguration_MessageTtlSecond = cmdletContext.SingleMasterConfiguration_MessageTtlSecond.Value;
            }
            if (requestSingleMasterConfiguration_singleMasterConfiguration_MessageTtlSecond != null)
            {
                request.SingleMasterConfiguration.MessageTtlSeconds = requestSingleMasterConfiguration_singleMasterConfiguration_MessageTtlSecond.Value;
                requestSingleMasterConfigurationIsNull = false;
            }
             // determine if request.SingleMasterConfiguration should be set to null
            if (requestSingleMasterConfigurationIsNull)
            {
                request.SingleMasterConfiguration = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.KinesisVideo.Model.CreateSignalingChannelResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.CreateSignalingChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "CreateSignalingChannel");
            try
            {
                #if DESKTOP
                return client.CreateSignalingChannel(request);
                #elif CORECLR
                return client.CreateSignalingChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelName { get; set; }
            public Amazon.KinesisVideo.ChannelType ChannelType { get; set; }
            public System.Int32? SingleMasterConfiguration_MessageTtlSecond { get; set; }
            public List<Amazon.KinesisVideo.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.CreateSignalingChannelResponse, NewKVSignalingChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ChannelARN;
        }
        
    }
}
