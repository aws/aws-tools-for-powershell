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
using Amazon.NimbleStudio;
using Amazon.NimbleStudio.Model;

namespace Amazon.PowerShell.Cmdlets.NS
{
    /// <summary>
    /// Update a launch profile.
    /// </summary>
    [Cmdlet("Update", "NSLaunchProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.NimbleStudio.Model.LaunchProfile")]
    [AWSCmdlet("Calls the Amazon Nimble Studio UpdateLaunchProfile API operation.", Operation = new[] {"UpdateLaunchProfile"}, SelectReturnType = typeof(Amazon.NimbleStudio.Model.UpdateLaunchProfileResponse))]
    [AWSCmdletOutput("Amazon.NimbleStudio.Model.LaunchProfile or Amazon.NimbleStudio.Model.UpdateLaunchProfileResponse",
        "This cmdlet returns an Amazon.NimbleStudio.Model.LaunchProfile object.",
        "The service call response (type Amazon.NimbleStudio.Model.UpdateLaunchProfileResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateNSLaunchProfileCmdlet : AmazonNimbleStudioClientCmdlet, IExecutor
    {
        
        #region Parameter StreamConfiguration_ClipboardMode
        /// <summary>
        /// <para>
        /// <para>Enable or disable the use of the system clipboard to copy and paste between the streaming
        /// session and streaming client.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.NimbleStudio.StreamingClipboardMode")]
        public Amazon.NimbleStudio.StreamingClipboardMode StreamConfiguration_ClipboardMode { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_Ec2InstanceType
        /// <summary>
        /// <para>
        /// <para>The EC2 instance types that users can select from when launching a streaming session
        /// with this launch profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_Ec2InstanceTypes")]
        public System.String[] StreamConfiguration_Ec2InstanceType { get; set; }
        #endregion
        
        #region Parameter LaunchProfileId
        /// <summary>
        /// <para>
        /// <para>The Launch Profile ID.</para>
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
        public System.String LaunchProfileId { get; set; }
        #endregion
        
        #region Parameter LaunchProfileProtocolVersion
        /// <summary>
        /// <para>
        /// <para>The version number of the protocol that is used by the launch profile. The only valid
        /// version is "2021-03-31".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LaunchProfileProtocolVersions")]
        public System.String[] LaunchProfileProtocolVersion { get; set; }
        #endregion
        
        #region Parameter Root_Linux
        /// <summary>
        /// <para>
        /// <para>The folder path in Linux workstations where files are uploaded. The default path is
        /// <code>$HOME/Downloads</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_SessionStorage_Root_Linux")]
        public System.String Root_Linux { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_MaxSessionLengthInMinute
        /// <summary>
        /// <para>
        /// <para>The length of time, in minutes, that a streaming session can be active before it is
        /// stopped or terminated. After this point, Nimble Studio automatically terminates or
        /// stops the session. The default length of time is 690 minutes, and the maximum length
        /// of time is 30 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_MaxSessionLengthInMinutes")]
        public System.Int32? StreamConfiguration_MaxSessionLengthInMinute { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_MaxStoppedSessionLengthInMinute
        /// <summary>
        /// <para>
        /// <para>Integer that determines if you can start and stop your sessions and how long a session
        /// can stay in the STOPPED state. The default value is 0. The maximum value is 5760.</para><para>If the value is missing or set to 0, your sessions can’t be stopped. If you then call
        /// StopStreamingSession, the session fails. If the time that a session stays in the READY
        /// state exceeds the maxSessionLengthInMinutes value, the session will automatically
        /// be terminated by AWS (instead of stopped).</para><para>If the value is set to a positive number, the session can be stopped. You can call
        /// StopStreamingSession to stop sessions in the READY state. If the time that a session
        /// stays in the READY state exceeds the maxSessionLengthInMinutes value, the session
        /// will automatically be stopped by AWS (instead of terminated).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_MaxStoppedSessionLengthInMinutes")]
        public System.Int32? StreamConfiguration_MaxStoppedSessionLengthInMinute { get; set; }
        #endregion
        
        #region Parameter SessionStorage_Mode
        /// <summary>
        /// <para>
        /// <para>Allows artists to upload files to their workstations. The only valid option is <code>UPLOAD</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_SessionStorage_Mode")]
        public System.String[] SessionStorage_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name for the launch profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter StreamConfiguration_StreamingImageId
        /// <summary>
        /// <para>
        /// <para>The streaming images that users can select from when launching a streaming session
        /// with this launch profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_StreamingImageIds")]
        public System.String[] StreamConfiguration_StreamingImageId { get; set; }
        #endregion
        
        #region Parameter StudioComponentId
        /// <summary>
        /// <para>
        /// <para>Unique identifiers for a collection of studio components that can be used with this
        /// launch profile.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StudioComponentIds")]
        public System.String[] StudioComponentId { get; set; }
        #endregion
        
        #region Parameter StudioId
        /// <summary>
        /// <para>
        /// <para>The studio ID. </para>
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
        public System.String StudioId { get; set; }
        #endregion
        
        #region Parameter Root_Window
        /// <summary>
        /// <para>
        /// <para>The folder path in Windows workstations where files are uploaded. The default path
        /// is <code>%HOMEPATH%\Downloads</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StreamConfiguration_SessionStorage_Root_Windows")]
        public System.String Root_Window { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. If you don’t specify a client token, the AWS SDK automatically generates
        /// a client token and uses it for the request to ensure idempotency.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'LaunchProfile'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.NimbleStudio.Model.UpdateLaunchProfileResponse).
        /// Specifying the name of a property of type Amazon.NimbleStudio.Model.UpdateLaunchProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "LaunchProfile";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LaunchProfileId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LaunchProfileId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LaunchProfileId' instead. This parameter will be removed in a future version.")]
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.LaunchProfileId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-NSLaunchProfile (UpdateLaunchProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.NimbleStudio.Model.UpdateLaunchProfileResponse, UpdateNSLaunchProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LaunchProfileId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.Description = this.Description;
            context.LaunchProfileId = this.LaunchProfileId;
            #if MODULAR
            if (this.LaunchProfileId == null && ParameterWasBound(nameof(this.LaunchProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter LaunchProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.LaunchProfileProtocolVersion != null)
            {
                context.LaunchProfileProtocolVersion = new List<System.String>(this.LaunchProfileProtocolVersion);
            }
            context.Name = this.Name;
            context.StreamConfiguration_ClipboardMode = this.StreamConfiguration_ClipboardMode;
            if (this.StreamConfiguration_Ec2InstanceType != null)
            {
                context.StreamConfiguration_Ec2InstanceType = new List<System.String>(this.StreamConfiguration_Ec2InstanceType);
            }
            context.StreamConfiguration_MaxSessionLengthInMinute = this.StreamConfiguration_MaxSessionLengthInMinute;
            context.StreamConfiguration_MaxStoppedSessionLengthInMinute = this.StreamConfiguration_MaxStoppedSessionLengthInMinute;
            if (this.SessionStorage_Mode != null)
            {
                context.SessionStorage_Mode = new List<System.String>(this.SessionStorage_Mode);
            }
            context.Root_Linux = this.Root_Linux;
            context.Root_Window = this.Root_Window;
            if (this.StreamConfiguration_StreamingImageId != null)
            {
                context.StreamConfiguration_StreamingImageId = new List<System.String>(this.StreamConfiguration_StreamingImageId);
            }
            if (this.StudioComponentId != null)
            {
                context.StudioComponentId = new List<System.String>(this.StudioComponentId);
            }
            context.StudioId = this.StudioId;
            #if MODULAR
            if (this.StudioId == null && ParameterWasBound(nameof(this.StudioId)))
            {
                WriteWarning("You are passing $null as a value for parameter StudioId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.NimbleStudio.Model.UpdateLaunchProfileRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.LaunchProfileId != null)
            {
                request.LaunchProfileId = cmdletContext.LaunchProfileId;
            }
            if (cmdletContext.LaunchProfileProtocolVersion != null)
            {
                request.LaunchProfileProtocolVersions = cmdletContext.LaunchProfileProtocolVersion;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate StreamConfiguration
            var requestStreamConfigurationIsNull = true;
            request.StreamConfiguration = new Amazon.NimbleStudio.Model.StreamConfigurationCreate();
            Amazon.NimbleStudio.StreamingClipboardMode requestStreamConfiguration_streamConfiguration_ClipboardMode = null;
            if (cmdletContext.StreamConfiguration_ClipboardMode != null)
            {
                requestStreamConfiguration_streamConfiguration_ClipboardMode = cmdletContext.StreamConfiguration_ClipboardMode;
            }
            if (requestStreamConfiguration_streamConfiguration_ClipboardMode != null)
            {
                request.StreamConfiguration.ClipboardMode = requestStreamConfiguration_streamConfiguration_ClipboardMode;
                requestStreamConfigurationIsNull = false;
            }
            List<System.String> requestStreamConfiguration_streamConfiguration_Ec2InstanceType = null;
            if (cmdletContext.StreamConfiguration_Ec2InstanceType != null)
            {
                requestStreamConfiguration_streamConfiguration_Ec2InstanceType = cmdletContext.StreamConfiguration_Ec2InstanceType;
            }
            if (requestStreamConfiguration_streamConfiguration_Ec2InstanceType != null)
            {
                request.StreamConfiguration.Ec2InstanceTypes = requestStreamConfiguration_streamConfiguration_Ec2InstanceType;
                requestStreamConfigurationIsNull = false;
            }
            System.Int32? requestStreamConfiguration_streamConfiguration_MaxSessionLengthInMinute = null;
            if (cmdletContext.StreamConfiguration_MaxSessionLengthInMinute != null)
            {
                requestStreamConfiguration_streamConfiguration_MaxSessionLengthInMinute = cmdletContext.StreamConfiguration_MaxSessionLengthInMinute.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_MaxSessionLengthInMinute != null)
            {
                request.StreamConfiguration.MaxSessionLengthInMinutes = requestStreamConfiguration_streamConfiguration_MaxSessionLengthInMinute.Value;
                requestStreamConfigurationIsNull = false;
            }
            System.Int32? requestStreamConfiguration_streamConfiguration_MaxStoppedSessionLengthInMinute = null;
            if (cmdletContext.StreamConfiguration_MaxStoppedSessionLengthInMinute != null)
            {
                requestStreamConfiguration_streamConfiguration_MaxStoppedSessionLengthInMinute = cmdletContext.StreamConfiguration_MaxStoppedSessionLengthInMinute.Value;
            }
            if (requestStreamConfiguration_streamConfiguration_MaxStoppedSessionLengthInMinute != null)
            {
                request.StreamConfiguration.MaxStoppedSessionLengthInMinutes = requestStreamConfiguration_streamConfiguration_MaxStoppedSessionLengthInMinute.Value;
                requestStreamConfigurationIsNull = false;
            }
            List<System.String> requestStreamConfiguration_streamConfiguration_StreamingImageId = null;
            if (cmdletContext.StreamConfiguration_StreamingImageId != null)
            {
                requestStreamConfiguration_streamConfiguration_StreamingImageId = cmdletContext.StreamConfiguration_StreamingImageId;
            }
            if (requestStreamConfiguration_streamConfiguration_StreamingImageId != null)
            {
                request.StreamConfiguration.StreamingImageIds = requestStreamConfiguration_streamConfiguration_StreamingImageId;
                requestStreamConfigurationIsNull = false;
            }
            Amazon.NimbleStudio.Model.StreamConfigurationSessionStorage requestStreamConfiguration_streamConfiguration_SessionStorage = null;
            
             // populate SessionStorage
            var requestStreamConfiguration_streamConfiguration_SessionStorageIsNull = true;
            requestStreamConfiguration_streamConfiguration_SessionStorage = new Amazon.NimbleStudio.Model.StreamConfigurationSessionStorage();
            List<System.String> requestStreamConfiguration_streamConfiguration_SessionStorage_sessionStorage_Mode = null;
            if (cmdletContext.SessionStorage_Mode != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_sessionStorage_Mode = cmdletContext.SessionStorage_Mode;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_sessionStorage_Mode != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage.Mode = requestStreamConfiguration_streamConfiguration_SessionStorage_sessionStorage_Mode;
                requestStreamConfiguration_streamConfiguration_SessionStorageIsNull = false;
            }
            Amazon.NimbleStudio.Model.StreamingSessionStorageRoot requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root = null;
            
             // populate Root
            var requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_RootIsNull = true;
            requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root = new Amazon.NimbleStudio.Model.StreamingSessionStorageRoot();
            System.String requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Linux = null;
            if (cmdletContext.Root_Linux != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Linux = cmdletContext.Root_Linux;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Linux != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root.Linux = requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Linux;
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_RootIsNull = false;
            }
            System.String requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Window = null;
            if (cmdletContext.Root_Window != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Window = cmdletContext.Root_Window;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Window != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root.Windows = requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root_root_Window;
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_RootIsNull = false;
            }
             // determine if requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root should be set to null
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_RootIsNull)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root = null;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root != null)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage.Root = requestStreamConfiguration_streamConfiguration_SessionStorage_streamConfiguration_SessionStorage_Root;
                requestStreamConfiguration_streamConfiguration_SessionStorageIsNull = false;
            }
             // determine if requestStreamConfiguration_streamConfiguration_SessionStorage should be set to null
            if (requestStreamConfiguration_streamConfiguration_SessionStorageIsNull)
            {
                requestStreamConfiguration_streamConfiguration_SessionStorage = null;
            }
            if (requestStreamConfiguration_streamConfiguration_SessionStorage != null)
            {
                request.StreamConfiguration.SessionStorage = requestStreamConfiguration_streamConfiguration_SessionStorage;
                requestStreamConfigurationIsNull = false;
            }
             // determine if request.StreamConfiguration should be set to null
            if (requestStreamConfigurationIsNull)
            {
                request.StreamConfiguration = null;
            }
            if (cmdletContext.StudioComponentId != null)
            {
                request.StudioComponentIds = cmdletContext.StudioComponentId;
            }
            if (cmdletContext.StudioId != null)
            {
                request.StudioId = cmdletContext.StudioId;
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
        
        private Amazon.NimbleStudio.Model.UpdateLaunchProfileResponse CallAWSServiceOperation(IAmazonNimbleStudio client, Amazon.NimbleStudio.Model.UpdateLaunchProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Nimble Studio", "UpdateLaunchProfile");
            try
            {
                #if DESKTOP
                return client.UpdateLaunchProfile(request);
                #elif CORECLR
                return client.UpdateLaunchProfileAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String Description { get; set; }
            public System.String LaunchProfileId { get; set; }
            public List<System.String> LaunchProfileProtocolVersion { get; set; }
            public System.String Name { get; set; }
            public Amazon.NimbleStudio.StreamingClipboardMode StreamConfiguration_ClipboardMode { get; set; }
            public List<System.String> StreamConfiguration_Ec2InstanceType { get; set; }
            public System.Int32? StreamConfiguration_MaxSessionLengthInMinute { get; set; }
            public System.Int32? StreamConfiguration_MaxStoppedSessionLengthInMinute { get; set; }
            public List<System.String> SessionStorage_Mode { get; set; }
            public System.String Root_Linux { get; set; }
            public System.String Root_Window { get; set; }
            public List<System.String> StreamConfiguration_StreamingImageId { get; set; }
            public List<System.String> StudioComponentId { get; set; }
            public System.String StudioId { get; set; }
            public System.Func<Amazon.NimbleStudio.Model.UpdateLaunchProfileResponse, UpdateNSLaunchProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.LaunchProfile;
        }
        
    }
}
