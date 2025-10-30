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
using Amazon.BedrockAgentCoreControl;
using Amazon.BedrockAgentCoreControl.Model;

namespace Amazon.PowerShell.Cmdlets.BACC
{
    /// <summary>
    /// Creates a custom browser.
    /// </summary>
    [Cmdlet("New", "BACCBrowser", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse")]
    [AWSCmdlet("Calls the Amazon Bedrock Agent Core Control Plane Fronting Layer CreateBrowser API operation.", Operation = new[] {"CreateBrowser"}, SelectReturnType = typeof(Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse))]
    [AWSCmdletOutput("Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse",
        "This cmdlet returns an Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse object containing multiple properties."
    )]
    public partial class NewBACCBrowserCmdlet : AmazonBedrockAgentCoreControlClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Location_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon S3 bucket. This bucket contains the stored data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Recording_S3Location_Bucket")]
        public System.String S3Location_Bucket { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the browser.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter BrowserSigning_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether browser signing is enabled. When enabled, the browser will cryptographically
        /// sign HTTP requests to identify itself as an AI agent to bot control vendors.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BrowserSigning_Enabled { get; set; }
        #endregion
        
        #region Parameter Recording_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates whether recording is enabled for the browser. When set to true, browser
        /// sessions are recorded.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Recording_Enabled { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role that provides permissions for the browser
        /// to access Amazon Web Services services.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the browser. The name must be unique within your account.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter NetworkConfiguration_NetworkMode
        /// <summary>
        /// <para>
        /// <para>The network mode for the browser. This field specifies how the browser connects to
        /// the network.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.BedrockAgentCoreControl.BrowserNetworkMode")]
        public Amazon.BedrockAgentCoreControl.BrowserNetworkMode NetworkConfiguration_NetworkMode { get; set; }
        #endregion
        
        #region Parameter S3Location_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix for objects in the Amazon S3 bucket. This prefix is added to the object
        /// keys to organize the data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Recording_S3Location_Prefix")]
        public System.String S3Location_Prefix { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The security groups associated with the VPC configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_VpcConfig_SecurityGroups")]
        public System.String[] VpcConfig_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>The subnets associated with the VPC configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A map of tag keys and values to assign to the browser. Tags enable you to categorize
        /// your resources in different ways, for example, by purpose, owner, or environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier to ensure that the operation completes no more
        /// than one time. If this token matches a previous request, Amazon Bedrock ignores the
        /// request but does not return an error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse).
        /// Specifying the name of a property of type Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BACCBrowser (CreateBrowser)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse, NewBACCBrowserCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BrowserSigning_Enabled = this.BrowserSigning_Enabled;
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NetworkConfiguration_NetworkMode = this.NetworkConfiguration_NetworkMode;
            #if MODULAR
            if (this.NetworkConfiguration_NetworkMode == null && ParameterWasBound(nameof(this.NetworkConfiguration_NetworkMode)))
            {
                WriteWarning("You are passing $null as a value for parameter NetworkConfiguration_NetworkMode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.VpcConfig_SecurityGroup != null)
            {
                context.VpcConfig_SecurityGroup = new List<System.String>(this.VpcConfig_SecurityGroup);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            context.Recording_Enabled = this.Recording_Enabled;
            context.S3Location_Bucket = this.S3Location_Bucket;
            context.S3Location_Prefix = this.S3Location_Prefix;
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
            var request = new Amazon.BedrockAgentCoreControl.Model.CreateBrowserRequest();
            
            
             // populate BrowserSigning
            var requestBrowserSigningIsNull = true;
            request.BrowserSigning = new Amazon.BedrockAgentCoreControl.Model.BrowserSigningConfigInput();
            System.Boolean? requestBrowserSigning_browserSigning_Enabled = null;
            if (cmdletContext.BrowserSigning_Enabled != null)
            {
                requestBrowserSigning_browserSigning_Enabled = cmdletContext.BrowserSigning_Enabled.Value;
            }
            if (requestBrowserSigning_browserSigning_Enabled != null)
            {
                request.BrowserSigning.Enabled = requestBrowserSigning_browserSigning_Enabled.Value;
                requestBrowserSigningIsNull = false;
            }
             // determine if request.BrowserSigning should be set to null
            if (requestBrowserSigningIsNull)
            {
                request.BrowserSigning = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.ExecutionRoleArn != null)
            {
                request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.BedrockAgentCoreControl.Model.BrowserNetworkConfiguration();
            Amazon.BedrockAgentCoreControl.BrowserNetworkMode requestNetworkConfiguration_networkConfiguration_NetworkMode = null;
            if (cmdletContext.NetworkConfiguration_NetworkMode != null)
            {
                requestNetworkConfiguration_networkConfiguration_NetworkMode = cmdletContext.NetworkConfiguration_NetworkMode;
            }
            if (requestNetworkConfiguration_networkConfiguration_NetworkMode != null)
            {
                request.NetworkConfiguration.NetworkMode = requestNetworkConfiguration_networkConfiguration_NetworkMode;
                requestNetworkConfigurationIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.VpcConfig requestNetworkConfiguration_networkConfiguration_VpcConfig = null;
            
             // populate VpcConfig
            var requestNetworkConfiguration_networkConfiguration_VpcConfigIsNull = true;
            requestNetworkConfiguration_networkConfiguration_VpcConfig = new Amazon.BedrockAgentCoreControl.Model.VpcConfig();
            List<System.String> requestNetworkConfiguration_networkConfiguration_VpcConfig_vpcConfig_SecurityGroup = null;
            if (cmdletContext.VpcConfig_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_VpcConfig_vpcConfig_SecurityGroup = cmdletContext.VpcConfig_SecurityGroup;
            }
            if (requestNetworkConfiguration_networkConfiguration_VpcConfig_vpcConfig_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_VpcConfig.SecurityGroups = requestNetworkConfiguration_networkConfiguration_VpcConfig_vpcConfig_SecurityGroup;
                requestNetworkConfiguration_networkConfiguration_VpcConfigIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_VpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_VpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestNetworkConfiguration_networkConfiguration_VpcConfig_vpcConfig_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_VpcConfig.Subnets = requestNetworkConfiguration_networkConfiguration_VpcConfig_vpcConfig_Subnet;
                requestNetworkConfiguration_networkConfiguration_VpcConfigIsNull = false;
            }
             // determine if requestNetworkConfiguration_networkConfiguration_VpcConfig should be set to null
            if (requestNetworkConfiguration_networkConfiguration_VpcConfigIsNull)
            {
                requestNetworkConfiguration_networkConfiguration_VpcConfig = null;
            }
            if (requestNetworkConfiguration_networkConfiguration_VpcConfig != null)
            {
                request.NetworkConfiguration.VpcConfig = requestNetworkConfiguration_networkConfiguration_VpcConfig;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            
             // populate Recording
            var requestRecordingIsNull = true;
            request.Recording = new Amazon.BedrockAgentCoreControl.Model.RecordingConfig();
            System.Boolean? requestRecording_recording_Enabled = null;
            if (cmdletContext.Recording_Enabled != null)
            {
                requestRecording_recording_Enabled = cmdletContext.Recording_Enabled.Value;
            }
            if (requestRecording_recording_Enabled != null)
            {
                request.Recording.Enabled = requestRecording_recording_Enabled.Value;
                requestRecordingIsNull = false;
            }
            Amazon.BedrockAgentCoreControl.Model.S3Location requestRecording_recording_S3Location = null;
            
             // populate S3Location
            var requestRecording_recording_S3LocationIsNull = true;
            requestRecording_recording_S3Location = new Amazon.BedrockAgentCoreControl.Model.S3Location();
            System.String requestRecording_recording_S3Location_s3Location_Bucket = null;
            if (cmdletContext.S3Location_Bucket != null)
            {
                requestRecording_recording_S3Location_s3Location_Bucket = cmdletContext.S3Location_Bucket;
            }
            if (requestRecording_recording_S3Location_s3Location_Bucket != null)
            {
                requestRecording_recording_S3Location.Bucket = requestRecording_recording_S3Location_s3Location_Bucket;
                requestRecording_recording_S3LocationIsNull = false;
            }
            System.String requestRecording_recording_S3Location_s3Location_Prefix = null;
            if (cmdletContext.S3Location_Prefix != null)
            {
                requestRecording_recording_S3Location_s3Location_Prefix = cmdletContext.S3Location_Prefix;
            }
            if (requestRecording_recording_S3Location_s3Location_Prefix != null)
            {
                requestRecording_recording_S3Location.Prefix = requestRecording_recording_S3Location_s3Location_Prefix;
                requestRecording_recording_S3LocationIsNull = false;
            }
             // determine if requestRecording_recording_S3Location should be set to null
            if (requestRecording_recording_S3LocationIsNull)
            {
                requestRecording_recording_S3Location = null;
            }
            if (requestRecording_recording_S3Location != null)
            {
                request.Recording.S3Location = requestRecording_recording_S3Location;
                requestRecordingIsNull = false;
            }
             // determine if request.Recording should be set to null
            if (requestRecordingIsNull)
            {
                request.Recording = null;
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
        
        private Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse CallAWSServiceOperation(IAmazonBedrockAgentCoreControl client, Amazon.BedrockAgentCoreControl.Model.CreateBrowserRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Bedrock Agent Core Control Plane Fronting Layer", "CreateBrowser");
            try
            {
                #if DESKTOP
                return client.CreateBrowser(request);
                #elif CORECLR
                return client.CreateBrowserAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? BrowserSigning_Enabled { get; set; }
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.String Name { get; set; }
            public Amazon.BedrockAgentCoreControl.BrowserNetworkMode NetworkConfiguration_NetworkMode { get; set; }
            public List<System.String> VpcConfig_SecurityGroup { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.Boolean? Recording_Enabled { get; set; }
            public System.String S3Location_Bucket { get; set; }
            public System.String S3Location_Prefix { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.BedrockAgentCoreControl.Model.CreateBrowserResponse, NewBACCBrowserCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
