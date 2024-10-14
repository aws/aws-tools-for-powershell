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
using Amazon.KinesisVideo;
using Amazon.KinesisVideo.Model;

namespace Amazon.PowerShell.Cmdlets.KV
{
    /// <summary>
    /// Updates the existing signaling channel. This is an asynchronous operation and takes
    /// time to complete. 
    /// 
    ///  
    /// <para>
    /// If the <c>MessageTtlSeconds</c> value is updated (either increased or reduced), it
    /// only applies to new messages sent via this channel after it's been updated. Existing
    /// messages are still expired as per the previous <c>MessageTtlSeconds</c> value.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "KVSignalingChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Kinesis Video Streams UpdateSignalingChannel API operation.", Operation = new[] {"UpdateSignalingChannel"}, SelectReturnType = typeof(Amazon.KinesisVideo.Model.UpdateSignalingChannelResponse))]
    [AWSCmdletOutput("None or Amazon.KinesisVideo.Model.UpdateSignalingChannelResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.KinesisVideo.Model.UpdateSignalingChannelResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateKVSignalingChannelCmdlet : AmazonKinesisVideoClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelARN
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the signaling channel that you want to update.</para>
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
        public System.String ChannelARN { get; set; }
        #endregion
        
        #region Parameter CurrentVersion
        /// <summary>
        /// <para>
        /// <para>The current version of the signaling channel that you want to update.</para>
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
        public System.String CurrentVersion { get; set; }
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
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.KinesisVideo.Model.UpdateSignalingChannelResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ChannelARN parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ChannelARN' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ChannelARN' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelARN), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-KVSignalingChannel (UpdateSignalingChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.KinesisVideo.Model.UpdateSignalingChannelResponse, UpdateKVSignalingChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ChannelARN;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ChannelARN = this.ChannelARN;
            #if MODULAR
            if (this.ChannelARN == null && ParameterWasBound(nameof(this.ChannelARN)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelARN which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CurrentVersion = this.CurrentVersion;
            #if MODULAR
            if (this.CurrentVersion == null && ParameterWasBound(nameof(this.CurrentVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter CurrentVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SingleMasterConfiguration_MessageTtlSecond = this.SingleMasterConfiguration_MessageTtlSecond;
            
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
            var request = new Amazon.KinesisVideo.Model.UpdateSignalingChannelRequest();
            
            if (cmdletContext.ChannelARN != null)
            {
                request.ChannelARN = cmdletContext.ChannelARN;
            }
            if (cmdletContext.CurrentVersion != null)
            {
                request.CurrentVersion = cmdletContext.CurrentVersion;
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
        
        private Amazon.KinesisVideo.Model.UpdateSignalingChannelResponse CallAWSServiceOperation(IAmazonKinesisVideo client, Amazon.KinesisVideo.Model.UpdateSignalingChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kinesis Video Streams", "UpdateSignalingChannel");
            try
            {
                #if DESKTOP
                return client.UpdateSignalingChannel(request);
                #elif CORECLR
                return client.UpdateSignalingChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String CurrentVersion { get; set; }
            public System.Int32? SingleMasterConfiguration_MessageTtlSecond { get; set; }
            public System.Func<Amazon.KinesisVideo.Model.UpdateSignalingChannelResponse, UpdateKVSignalingChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
