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
using Amazon.MediaPackageV2;
using Amazon.MediaPackageV2.Model;

namespace Amazon.PowerShell.Cmdlets.MPV2
{
    /// <summary>
    /// Update the specified channel. You can edit if MediaPackage sends ingest or egress
    /// access logs to the CloudWatch log group, if content will be encrypted, the description
    /// on a channel, and your channel's policy settings. You can't edit the name of the channel
    /// or CloudFront distribution details.
    /// 
    ///  
    /// <para>
    /// Any edits you make that impact the video output may not be reflected for a few minutes.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "MPV2Channel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackageV2.Model.UpdateChannelResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage v2 UpdateChannel API operation.", Operation = new[] {"UpdateChannel"}, SelectReturnType = typeof(Amazon.MediaPackageV2.Model.UpdateChannelResponse))]
    [AWSCmdletOutput("Amazon.MediaPackageV2.Model.UpdateChannelResponse",
        "This cmdlet returns an Amazon.MediaPackageV2.Model.UpdateChannelResponse object containing multiple properties."
    )]
    public partial class UpdateMPV2ChannelCmdlet : AmazonMediaPackageV2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelGroupName
        /// <summary>
        /// <para>
        /// <para>The name that describes the channel group. The name is the primary identifier for
        /// the channel group, and must be unique for your account in the AWS Region.</para>
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
        public System.String ChannelGroupName { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The name that describes the channel. The name is the primary identifier for the channel,
        /// and must be unique for your account in the AWS Region and channel group. </para>
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Any descriptive information that you want to add to the channel for future identification
        /// purposes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InputSwitchConfiguration_MQCSInputSwitching
        /// <summary>
        /// <para>
        /// <para>When true, AWS Elemental MediaPackage performs input switching based on the MQCS.
        /// Default is true. This setting is valid only when <c>InputType</c> is <c>CMAF</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InputSwitchConfiguration_MQCSInputSwitching { get; set; }
        #endregion
        
        #region Parameter OutputHeaderConfiguration_PublishMQCS
        /// <summary>
        /// <para>
        /// <para>When true, AWS Elemental MediaPackage includes the MQCS in responses to the CDN. This
        /// setting is valid only when <c>InputType</c> is <c>CMAF</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OutputHeaderConfiguration_PublishMQCS { get; set; }
        #endregion
        
        #region Parameter ETag
        /// <summary>
        /// <para>
        /// <para>The expected current Entity Tag (ETag) for the resource. If the specified ETag does
        /// not match the resource's current entity tag, the update request will be rejected.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ETag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackageV2.Model.UpdateChannelResponse).
        /// Specifying the name of a property of type Amazon.MediaPackageV2.Model.UpdateChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-MPV2Channel (UpdateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackageV2.Model.UpdateChannelResponse, UpdateMPV2ChannelCmdlet>(Select) ??
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
            context.ChannelGroupName = this.ChannelGroupName;
            #if MODULAR
            if (this.ChannelGroupName == null && ParameterWasBound(nameof(this.ChannelGroupName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelGroupName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelName = this.ChannelName;
            #if MODULAR
            if (this.ChannelName == null && ParameterWasBound(nameof(this.ChannelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.ETag = this.ETag;
            context.InputSwitchConfiguration_MQCSInputSwitching = this.InputSwitchConfiguration_MQCSInputSwitching;
            context.OutputHeaderConfiguration_PublishMQCS = this.OutputHeaderConfiguration_PublishMQCS;
            
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
            var request = new Amazon.MediaPackageV2.Model.UpdateChannelRequest();
            
            if (cmdletContext.ChannelGroupName != null)
            {
                request.ChannelGroupName = cmdletContext.ChannelGroupName;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ETag != null)
            {
                request.ETag = cmdletContext.ETag;
            }
            
             // populate InputSwitchConfiguration
            var requestInputSwitchConfigurationIsNull = true;
            request.InputSwitchConfiguration = new Amazon.MediaPackageV2.Model.InputSwitchConfiguration();
            System.Boolean? requestInputSwitchConfiguration_inputSwitchConfiguration_MQCSInputSwitching = null;
            if (cmdletContext.InputSwitchConfiguration_MQCSInputSwitching != null)
            {
                requestInputSwitchConfiguration_inputSwitchConfiguration_MQCSInputSwitching = cmdletContext.InputSwitchConfiguration_MQCSInputSwitching.Value;
            }
            if (requestInputSwitchConfiguration_inputSwitchConfiguration_MQCSInputSwitching != null)
            {
                request.InputSwitchConfiguration.MQCSInputSwitching = requestInputSwitchConfiguration_inputSwitchConfiguration_MQCSInputSwitching.Value;
                requestInputSwitchConfigurationIsNull = false;
            }
             // determine if request.InputSwitchConfiguration should be set to null
            if (requestInputSwitchConfigurationIsNull)
            {
                request.InputSwitchConfiguration = null;
            }
            
             // populate OutputHeaderConfiguration
            var requestOutputHeaderConfigurationIsNull = true;
            request.OutputHeaderConfiguration = new Amazon.MediaPackageV2.Model.OutputHeaderConfiguration();
            System.Boolean? requestOutputHeaderConfiguration_outputHeaderConfiguration_PublishMQCS = null;
            if (cmdletContext.OutputHeaderConfiguration_PublishMQCS != null)
            {
                requestOutputHeaderConfiguration_outputHeaderConfiguration_PublishMQCS = cmdletContext.OutputHeaderConfiguration_PublishMQCS.Value;
            }
            if (requestOutputHeaderConfiguration_outputHeaderConfiguration_PublishMQCS != null)
            {
                request.OutputHeaderConfiguration.PublishMQCS = requestOutputHeaderConfiguration_outputHeaderConfiguration_PublishMQCS.Value;
                requestOutputHeaderConfigurationIsNull = false;
            }
             // determine if request.OutputHeaderConfiguration should be set to null
            if (requestOutputHeaderConfigurationIsNull)
            {
                request.OutputHeaderConfiguration = null;
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
        
        private Amazon.MediaPackageV2.Model.UpdateChannelResponse CallAWSServiceOperation(IAmazonMediaPackageV2 client, Amazon.MediaPackageV2.Model.UpdateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage v2", "UpdateChannel");
            try
            {
                #if DESKTOP
                return client.UpdateChannel(request);
                #elif CORECLR
                return client.UpdateChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelGroupName { get; set; }
            public System.String ChannelName { get; set; }
            public System.String Description { get; set; }
            public System.String ETag { get; set; }
            public System.Boolean? InputSwitchConfiguration_MQCSInputSwitching { get; set; }
            public System.Boolean? OutputHeaderConfiguration_PublishMQCS { get; set; }
            public System.Func<Amazon.MediaPackageV2.Model.UpdateChannelResponse, UpdateMPV2ChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
