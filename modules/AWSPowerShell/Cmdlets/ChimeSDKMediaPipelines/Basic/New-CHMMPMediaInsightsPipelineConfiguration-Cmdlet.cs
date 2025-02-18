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
using Amazon.ChimeSDKMediaPipelines;
using Amazon.ChimeSDKMediaPipelines.Model;

namespace Amazon.PowerShell.Cmdlets.CHMMP
{
    /// <summary>
    /// A structure that contains the static configurations for a media insights pipeline.
    /// </summary>
    [Cmdlet("New", "CHMMPMediaInsightsPipelineConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime SDK Media Pipelines CreateMediaInsightsPipelineConfiguration API operation.", Operation = new[] {"CreateMediaInsightsPipelineConfiguration"}, SelectReturnType = typeof(Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfiguration or Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationResponse",
        "This cmdlet returns an Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfiguration object.",
        "The service call response (type Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewCHMMPMediaInsightsPipelineConfigurationCmdlet : AmazonChimeSDKMediaPipelinesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the media insights pipeline configuration request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter RealTimeAlertConfiguration_Disabled
        /// <summary>
        /// <para>
        /// <para>Turns off real-time alerts.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RealTimeAlertConfiguration_Disabled { get; set; }
        #endregion
        
        #region Parameter Element
        /// <summary>
        /// <para>
        /// <para>The elements in the request, such as a processor for Amazon Transcribe or a sink for
        /// a Kinesis Data Stream.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Elements")]
        public Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfigurationElement[] Element { get; set; }
        #endregion
        
        #region Parameter MediaInsightsPipelineConfigurationName
        /// <summary>
        /// <para>
        /// <para>The name of the media insights pipeline configuration.</para>
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
        public System.String MediaInsightsPipelineConfigurationName { get; set; }
        #endregion
        
        #region Parameter ResourceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role used by the service to access Amazon Web Services resources, including
        /// <c>Transcribe</c> and <c>Transcribe Call Analytics</c>, on the caller’s behalf.</para>
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
        public System.String ResourceAccessRoleArn { get; set; }
        #endregion
        
        #region Parameter RealTimeAlertConfiguration_Rule
        /// <summary>
        /// <para>
        /// <para>The rules in the alert. Rules specify the words or phrases that you want to be notified
        /// about.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RealTimeAlertConfiguration_Rules")]
        public Amazon.ChimeSDKMediaPipelines.Model.RealTimeAlertRule[] RealTimeAlertConfiguration_Rule { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags assigned to the media insights pipeline configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ChimeSDKMediaPipelines.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MediaInsightsPipelineConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MediaInsightsPipelineConfiguration";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.MediaInsightsPipelineConfigurationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CHMMPMediaInsightsPipelineConfiguration (CreateMediaInsightsPipelineConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationResponse, NewCHMMPMediaInsightsPipelineConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientRequestToken = this.ClientRequestToken;
            if (this.Element != null)
            {
                context.Element = new List<Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfigurationElement>(this.Element);
            }
            #if MODULAR
            if (this.Element == null && ParameterWasBound(nameof(this.Element)))
            {
                WriteWarning("You are passing $null as a value for parameter Element which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MediaInsightsPipelineConfigurationName = this.MediaInsightsPipelineConfigurationName;
            #if MODULAR
            if (this.MediaInsightsPipelineConfigurationName == null && ParameterWasBound(nameof(this.MediaInsightsPipelineConfigurationName)))
            {
                WriteWarning("You are passing $null as a value for parameter MediaInsightsPipelineConfigurationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RealTimeAlertConfiguration_Disabled = this.RealTimeAlertConfiguration_Disabled;
            if (this.RealTimeAlertConfiguration_Rule != null)
            {
                context.RealTimeAlertConfiguration_Rule = new List<Amazon.ChimeSDKMediaPipelines.Model.RealTimeAlertRule>(this.RealTimeAlertConfiguration_Rule);
            }
            context.ResourceAccessRoleArn = this.ResourceAccessRoleArn;
            #if MODULAR
            if (this.ResourceAccessRoleArn == null && ParameterWasBound(nameof(this.ResourceAccessRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceAccessRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ChimeSDKMediaPipelines.Model.Tag>(this.Tag);
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
            var request = new Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationRequest();
            
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            if (cmdletContext.Element != null)
            {
                request.Elements = cmdletContext.Element;
            }
            if (cmdletContext.MediaInsightsPipelineConfigurationName != null)
            {
                request.MediaInsightsPipelineConfigurationName = cmdletContext.MediaInsightsPipelineConfigurationName;
            }
            
             // populate RealTimeAlertConfiguration
            var requestRealTimeAlertConfigurationIsNull = true;
            request.RealTimeAlertConfiguration = new Amazon.ChimeSDKMediaPipelines.Model.RealTimeAlertConfiguration();
            System.Boolean? requestRealTimeAlertConfiguration_realTimeAlertConfiguration_Disabled = null;
            if (cmdletContext.RealTimeAlertConfiguration_Disabled != null)
            {
                requestRealTimeAlertConfiguration_realTimeAlertConfiguration_Disabled = cmdletContext.RealTimeAlertConfiguration_Disabled.Value;
            }
            if (requestRealTimeAlertConfiguration_realTimeAlertConfiguration_Disabled != null)
            {
                request.RealTimeAlertConfiguration.Disabled = requestRealTimeAlertConfiguration_realTimeAlertConfiguration_Disabled.Value;
                requestRealTimeAlertConfigurationIsNull = false;
            }
            List<Amazon.ChimeSDKMediaPipelines.Model.RealTimeAlertRule> requestRealTimeAlertConfiguration_realTimeAlertConfiguration_Rule = null;
            if (cmdletContext.RealTimeAlertConfiguration_Rule != null)
            {
                requestRealTimeAlertConfiguration_realTimeAlertConfiguration_Rule = cmdletContext.RealTimeAlertConfiguration_Rule;
            }
            if (requestRealTimeAlertConfiguration_realTimeAlertConfiguration_Rule != null)
            {
                request.RealTimeAlertConfiguration.Rules = requestRealTimeAlertConfiguration_realTimeAlertConfiguration_Rule;
                requestRealTimeAlertConfigurationIsNull = false;
            }
             // determine if request.RealTimeAlertConfiguration should be set to null
            if (requestRealTimeAlertConfigurationIsNull)
            {
                request.RealTimeAlertConfiguration = null;
            }
            if (cmdletContext.ResourceAccessRoleArn != null)
            {
                request.ResourceAccessRoleArn = cmdletContext.ResourceAccessRoleArn;
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
        
        private Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationResponse CallAWSServiceOperation(IAmazonChimeSDKMediaPipelines client, Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Media Pipelines", "CreateMediaInsightsPipelineConfiguration");
            try
            {
                return client.CreateMediaInsightsPipelineConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientRequestToken { get; set; }
            public List<Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfigurationElement> Element { get; set; }
            public System.String MediaInsightsPipelineConfigurationName { get; set; }
            public System.Boolean? RealTimeAlertConfiguration_Disabled { get; set; }
            public List<Amazon.ChimeSDKMediaPipelines.Model.RealTimeAlertRule> RealTimeAlertConfiguration_Rule { get; set; }
            public System.String ResourceAccessRoleArn { get; set; }
            public List<Amazon.ChimeSDKMediaPipelines.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.ChimeSDKMediaPipelines.Model.CreateMediaInsightsPipelineConfigurationResponse, NewCHMMPMediaInsightsPipelineConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MediaInsightsPipelineConfiguration;
        }
        
    }
}
