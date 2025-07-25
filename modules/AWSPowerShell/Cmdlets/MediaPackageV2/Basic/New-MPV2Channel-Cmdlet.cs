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
    /// Create a channel to start receiving content streams. The channel represents the input
    /// to MediaPackage for incoming live content from an encoder such as AWS Elemental MediaLive.
    /// The channel receives content, and after packaging it, outputs it through an origin
    /// endpoint to downstream devices (such as video players or CDNs) that request the content.
    /// You can create only one channel with each request. We recommend that you spread out
    /// channels between channel groups, such as putting redundant channels in the same AWS
    /// Region in different channel groups.
    /// </summary>
    [Cmdlet("New", "MPV2Channel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaPackageV2.Model.CreateChannelResponse")]
    [AWSCmdlet("Calls the AWS Elemental MediaPackage v2 CreateChannel API operation.", Operation = new[] {"CreateChannel"}, SelectReturnType = typeof(Amazon.MediaPackageV2.Model.CreateChannelResponse))]
    [AWSCmdletOutput("Amazon.MediaPackageV2.Model.CreateChannelResponse",
        "This cmdlet returns an Amazon.MediaPackageV2.Model.CreateChannelResponse object containing multiple properties."
    )]
    public partial class NewMPV2ChannelCmdlet : AmazonMediaPackageV2ClientCmdlet, IExecutor
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
        /// and must be unique for your account in the AWS Region and channel group. You can't
        /// change the name after you create the channel.</para>
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
        /// <para>Enter any descriptive text that helps you to identify the channel.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InputType
        /// <summary>
        /// <para>
        /// <para>The input type will be an immutable field which will be used to define whether the
        /// channel will allow CMAF ingest or HLS ingest. If unprovided, it will default to HLS
        /// to preserve current behavior.</para><para>The allowed values are:</para><ul><li><para><c>HLS</c> - The HLS streaming specification (which defines M3U8 manifests and TS
        /// segments).</para></li><li><para><c>CMAF</c> - The DASH-IF CMAF Ingest specification (which defines CMAF segments
        /// with optional DASH manifests).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaPackageV2.InputType")]
        public Amazon.MediaPackageV2.InputType InputType { get; set; }
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
        
        #region Parameter InputSwitchConfiguration_PreferredInput
        /// <summary>
        /// <para>
        /// <para>For CMAF inputs, indicates which input MediaPackage should prefer when both inputs
        /// have equal MQCS scores. Select <c>1</c> to prefer the first ingest endpoint, or <c>2</c>
        /// to prefer the second ingest endpoint. If you don't specify a preferred input, MediaPackage
        /// uses its default switching behavior when MQCS scores are equal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InputSwitchConfiguration_PreferredInput { get; set; }
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A comma-separated list of tag key:value pairs that you define. For example:</para><para><c>"Key1": "Value1",</c></para><para><c>"Key2": "Value2"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive token that you provide to ensure the idempotency of the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaPackageV2.Model.CreateChannelResponse).
        /// Specifying the name of a property of type Amazon.MediaPackageV2.Model.CreateChannelResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-MPV2Channel (CreateChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaPackageV2.Model.CreateChannelResponse, NewMPV2ChannelCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.InputSwitchConfiguration_MQCSInputSwitching = this.InputSwitchConfiguration_MQCSInputSwitching;
            context.InputSwitchConfiguration_PreferredInput = this.InputSwitchConfiguration_PreferredInput;
            context.InputType = this.InputType;
            context.OutputHeaderConfiguration_PublishMQCS = this.OutputHeaderConfiguration_PublishMQCS;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.MediaPackageV2.Model.CreateChannelRequest();
            
            if (cmdletContext.ChannelGroupName != null)
            {
                request.ChannelGroupName = cmdletContext.ChannelGroupName;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
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
            System.Int32? requestInputSwitchConfiguration_inputSwitchConfiguration_PreferredInput = null;
            if (cmdletContext.InputSwitchConfiguration_PreferredInput != null)
            {
                requestInputSwitchConfiguration_inputSwitchConfiguration_PreferredInput = cmdletContext.InputSwitchConfiguration_PreferredInput.Value;
            }
            if (requestInputSwitchConfiguration_inputSwitchConfiguration_PreferredInput != null)
            {
                request.InputSwitchConfiguration.PreferredInput = requestInputSwitchConfiguration_inputSwitchConfiguration_PreferredInput.Value;
                requestInputSwitchConfigurationIsNull = false;
            }
             // determine if request.InputSwitchConfiguration should be set to null
            if (requestInputSwitchConfigurationIsNull)
            {
                request.InputSwitchConfiguration = null;
            }
            if (cmdletContext.InputType != null)
            {
                request.InputType = cmdletContext.InputType;
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
        
        private Amazon.MediaPackageV2.Model.CreateChannelResponse CallAWSServiceOperation(IAmazonMediaPackageV2 client, Amazon.MediaPackageV2.Model.CreateChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaPackage v2", "CreateChannel");
            try
            {
                #if DESKTOP
                return client.CreateChannel(request);
                #elif CORECLR
                return client.CreateChannelAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? InputSwitchConfiguration_MQCSInputSwitching { get; set; }
            public System.Int32? InputSwitchConfiguration_PreferredInput { get; set; }
            public Amazon.MediaPackageV2.InputType InputType { get; set; }
            public System.Boolean? OutputHeaderConfiguration_PublishMQCS { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.MediaPackageV2.Model.CreateChannelResponse, NewMPV2ChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
