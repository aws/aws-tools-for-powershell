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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CHMMP
{
    /// <summary>
    /// Updates the media insights pipeline's configuration settings.
    /// </summary>
    [Cmdlet("Update", "CHMMPMediaInsightsPipelineConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfiguration")]
    [AWSCmdlet("Calls the Amazon Chime SDK Media Pipelines UpdateMediaInsightsPipelineConfiguration API operation.", Operation = new[] {"UpdateMediaInsightsPipelineConfiguration"}, SelectReturnType = typeof(Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfiguration or Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationResponse",
        "This cmdlet returns an Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfiguration object.",
        "The service call response (type Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCHMMPMediaInsightsPipelineConfigurationCmdlet : AmazonChimeSDKMediaPipelinesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// a Kinesis Data Stream..</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        
        #region Parameter Identifier
        /// <summary>
        /// <para>
        /// <para>The unique identifier for the resource to be updated. Valid values include the name
        /// and ARN of the media insights pipeline configuration.</para>
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
        public System.String Identifier { get; set; }
        #endregion
        
        #region Parameter ResourceAccessRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the role used by the service to access Amazon Web Services resources.</para>
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
        /// about.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RealTimeAlertConfiguration_Rules")]
        public Amazon.ChimeSDKMediaPipelines.Model.RealTimeAlertRule[] RealTimeAlertConfiguration_Rule { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MediaInsightsPipelineConfiguration'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Identifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CHMMPMediaInsightsPipelineConfiguration (UpdateMediaInsightsPipelineConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationResponse, UpdateCHMMPMediaInsightsPipelineConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
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
            context.Identifier = this.Identifier;
            #if MODULAR
            if (this.Identifier == null && ParameterWasBound(nameof(this.Identifier)))
            {
                WriteWarning("You are passing $null as a value for parameter Identifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationRequest();
            
            if (cmdletContext.Element != null)
            {
                request.Elements = cmdletContext.Element;
            }
            if (cmdletContext.Identifier != null)
            {
                request.Identifier = cmdletContext.Identifier;
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
        
        private Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationResponse CallAWSServiceOperation(IAmazonChimeSDKMediaPipelines client, Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Chime SDK Media Pipelines", "UpdateMediaInsightsPipelineConfiguration");
            try
            {
                return client.UpdateMediaInsightsPipelineConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public List<Amazon.ChimeSDKMediaPipelines.Model.MediaInsightsPipelineConfigurationElement> Element { get; set; }
            public System.String Identifier { get; set; }
            public System.Boolean? RealTimeAlertConfiguration_Disabled { get; set; }
            public List<Amazon.ChimeSDKMediaPipelines.Model.RealTimeAlertRule> RealTimeAlertConfiguration_Rule { get; set; }
            public System.String ResourceAccessRoleArn { get; set; }
            public System.Func<Amazon.ChimeSDKMediaPipelines.Model.UpdateMediaInsightsPipelineConfigurationResponse, UpdateCHMMPMediaInsightsPipelineConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MediaInsightsPipelineConfiguration;
        }
        
    }
}
