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
using System.Threading;
using Amazon.AppStream;
using Amazon.AppStream.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.APS
{
    /// <summary>
    /// Updates the specified fields for the specified image builder. The image builder must
    /// be in the STOPPED state.
    /// </summary>
    [Cmdlet("Update", "APSImageBuilder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppStream.Model.ImageBuilder")]
    [AWSCmdlet("Calls the Amazon AppStream UpdateImageBuilder API operation.", Operation = new[] {"UpdateImageBuilder"}, SelectReturnType = typeof(Amazon.AppStream.Model.UpdateImageBuilderResponse))]
    [AWSCmdletOutput("Amazon.AppStream.Model.ImageBuilder or Amazon.AppStream.Model.UpdateImageBuilderResponse",
        "This cmdlet returns an Amazon.AppStream.Model.ImageBuilder object.",
        "The service call response (type Amazon.AppStream.Model.UpdateImageBuilderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateAPSImageBuilderCmdlet : AmazonAppStreamClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AttributesToDelete
        /// <summary>
        /// <para>
        /// <para>The image builder attributes to delete.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] AttributesToDelete { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DisplayName
        /// <summary>
        /// <para>
        /// <para>The image builder name to display.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DisplayName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the image builder.</para>
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
        
        #region Parameter AgentAccessConfig_S3BucketArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Amazon S3 bucket where agent screenshots are
        /// stored. If ScreenshotsUploadEnabled is false after the merge, the stored bucket ARN
        /// is removed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AgentAccessConfig_S3BucketArn { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_ScreenImageFormat
        /// <summary>
        /// <para>
        /// <para>The image format for agent screen captures.</para><ul><li><para>PNG - PNG format.</para></li><li><para>JPEG - JPEG format.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.ScreenImageFormat")]
        public Amazon.AppStream.ScreenImageFormat AgentAccessConfig_ScreenImageFormat { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_ScreenResolution
        /// <summary>
        /// <para>
        /// <para>The screen resolution for the agent streaming environment.</para><ul><li><para>W_1280xH_720 - 1280 x 720 pixels.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.ScreenResolution")]
        public Amazon.AppStream.ScreenResolution AgentAccessConfig_ScreenResolution { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_ScreenshotsUploadEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether screenshot uploads to Amazon S3 are enabled for agent sessions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AgentAccessConfig_ScreenshotsUploadEnabled { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_Setting
        /// <summary>
        /// <para>
        /// <para>The list of agent access settings that define permissions for each agent action. These
        /// settings are merged with the stored settings by agent action. A setting that you specify
        /// replaces the stored setting for the same agent action. The merged settings must have
        /// at least one agent action enabled.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AgentAccessConfig_Settings")]
        public Amazon.AppStream.Model.AgentAccessSetting[] AgentAccessConfig_Setting { get; set; }
        #endregion
        
        #region Parameter AgentAccessConfig_UserControlMode
        /// <summary>
        /// <para>
        /// <para>The user control mode for agent sessions. This setting determines how users can interact
        /// with agent sessions.</para><ul><li><para>VIEW_ONLY - Users can view and observe agent actions as they happen.</para></li><li><para>VIEW_STOP - Users can view agent actions and stop the agent if needed.</para></li><li><para>DISABLED - Users cannot view or stop the agent session.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppStream.UserControlMode")]
        public Amazon.AppStream.UserControlMode AgentAccessConfig_UserControlMode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageBuilder'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppStream.Model.UpdateImageBuilderResponse).
        /// Specifying the name of a property of type Amazon.AppStream.Model.UpdateImageBuilderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageBuilder";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-APSImageBuilder (UpdateImageBuilder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppStream.Model.UpdateImageBuilderResponse, UpdateAPSImageBuilderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AgentAccessConfig_S3BucketArn = this.AgentAccessConfig_S3BucketArn;
            context.AgentAccessConfig_ScreenImageFormat = this.AgentAccessConfig_ScreenImageFormat;
            context.AgentAccessConfig_ScreenResolution = this.AgentAccessConfig_ScreenResolution;
            context.AgentAccessConfig_ScreenshotsUploadEnabled = this.AgentAccessConfig_ScreenshotsUploadEnabled;
            if (this.AgentAccessConfig_Setting != null)
            {
                context.AgentAccessConfig_Setting = new List<Amazon.AppStream.Model.AgentAccessSetting>(this.AgentAccessConfig_Setting);
            }
            context.AgentAccessConfig_UserControlMode = this.AgentAccessConfig_UserControlMode;
            if (this.AttributesToDelete != null)
            {
                context.AttributesToDelete = new List<System.String>(this.AttributesToDelete);
            }
            context.Description = this.Description;
            context.DisplayName = this.DisplayName;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppStream.Model.UpdateImageBuilderRequest();
            
            
             // populate AgentAccessConfig
            var requestAgentAccessConfigIsNull = true;
            request.AgentAccessConfig = new Amazon.AppStream.Model.ImageBuilderAgentAccessConfigForUpdate();
            System.String requestAgentAccessConfig_agentAccessConfig_S3BucketArn = null;
            if (cmdletContext.AgentAccessConfig_S3BucketArn != null)
            {
                requestAgentAccessConfig_agentAccessConfig_S3BucketArn = cmdletContext.AgentAccessConfig_S3BucketArn;
            }
            if (requestAgentAccessConfig_agentAccessConfig_S3BucketArn != null)
            {
                request.AgentAccessConfig.S3BucketArn = requestAgentAccessConfig_agentAccessConfig_S3BucketArn;
                requestAgentAccessConfigIsNull = false;
            }
            Amazon.AppStream.ScreenImageFormat requestAgentAccessConfig_agentAccessConfig_ScreenImageFormat = null;
            if (cmdletContext.AgentAccessConfig_ScreenImageFormat != null)
            {
                requestAgentAccessConfig_agentAccessConfig_ScreenImageFormat = cmdletContext.AgentAccessConfig_ScreenImageFormat;
            }
            if (requestAgentAccessConfig_agentAccessConfig_ScreenImageFormat != null)
            {
                request.AgentAccessConfig.ScreenImageFormat = requestAgentAccessConfig_agentAccessConfig_ScreenImageFormat;
                requestAgentAccessConfigIsNull = false;
            }
            Amazon.AppStream.ScreenResolution requestAgentAccessConfig_agentAccessConfig_ScreenResolution = null;
            if (cmdletContext.AgentAccessConfig_ScreenResolution != null)
            {
                requestAgentAccessConfig_agentAccessConfig_ScreenResolution = cmdletContext.AgentAccessConfig_ScreenResolution;
            }
            if (requestAgentAccessConfig_agentAccessConfig_ScreenResolution != null)
            {
                request.AgentAccessConfig.ScreenResolution = requestAgentAccessConfig_agentAccessConfig_ScreenResolution;
                requestAgentAccessConfigIsNull = false;
            }
            System.Boolean? requestAgentAccessConfig_agentAccessConfig_ScreenshotsUploadEnabled = null;
            if (cmdletContext.AgentAccessConfig_ScreenshotsUploadEnabled != null)
            {
                requestAgentAccessConfig_agentAccessConfig_ScreenshotsUploadEnabled = cmdletContext.AgentAccessConfig_ScreenshotsUploadEnabled.Value;
            }
            if (requestAgentAccessConfig_agentAccessConfig_ScreenshotsUploadEnabled != null)
            {
                request.AgentAccessConfig.ScreenshotsUploadEnabled = requestAgentAccessConfig_agentAccessConfig_ScreenshotsUploadEnabled.Value;
                requestAgentAccessConfigIsNull = false;
            }
            List<Amazon.AppStream.Model.AgentAccessSetting> requestAgentAccessConfig_agentAccessConfig_Setting = null;
            if (cmdletContext.AgentAccessConfig_Setting != null)
            {
                requestAgentAccessConfig_agentAccessConfig_Setting = cmdletContext.AgentAccessConfig_Setting;
            }
            if (requestAgentAccessConfig_agentAccessConfig_Setting != null)
            {
                request.AgentAccessConfig.Settings = requestAgentAccessConfig_agentAccessConfig_Setting;
                requestAgentAccessConfigIsNull = false;
            }
            Amazon.AppStream.UserControlMode requestAgentAccessConfig_agentAccessConfig_UserControlMode = null;
            if (cmdletContext.AgentAccessConfig_UserControlMode != null)
            {
                requestAgentAccessConfig_agentAccessConfig_UserControlMode = cmdletContext.AgentAccessConfig_UserControlMode;
            }
            if (requestAgentAccessConfig_agentAccessConfig_UserControlMode != null)
            {
                request.AgentAccessConfig.UserControlMode = requestAgentAccessConfig_agentAccessConfig_UserControlMode;
                requestAgentAccessConfigIsNull = false;
            }
             // determine if request.AgentAccessConfig should be set to null
            if (requestAgentAccessConfigIsNull)
            {
                request.AgentAccessConfig = null;
            }
            if (cmdletContext.AttributesToDelete != null)
            {
                request.AttributesToDelete = cmdletContext.AttributesToDelete;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DisplayName != null)
            {
                request.DisplayName = cmdletContext.DisplayName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.AppStream.Model.UpdateImageBuilderResponse CallAWSServiceOperation(IAmazonAppStream client, Amazon.AppStream.Model.UpdateImageBuilderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon AppStream", "UpdateImageBuilder");
            try
            {
                return client.UpdateImageBuilderAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AgentAccessConfig_S3BucketArn { get; set; }
            public Amazon.AppStream.ScreenImageFormat AgentAccessConfig_ScreenImageFormat { get; set; }
            public Amazon.AppStream.ScreenResolution AgentAccessConfig_ScreenResolution { get; set; }
            public System.Boolean? AgentAccessConfig_ScreenshotsUploadEnabled { get; set; }
            public List<Amazon.AppStream.Model.AgentAccessSetting> AgentAccessConfig_Setting { get; set; }
            public Amazon.AppStream.UserControlMode AgentAccessConfig_UserControlMode { get; set; }
            public List<System.String> AttributesToDelete { get; set; }
            public System.String Description { get; set; }
            public System.String DisplayName { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.AppStream.Model.UpdateImageBuilderResponse, UpdateAPSImageBuilderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageBuilder;
        }
        
    }
}
