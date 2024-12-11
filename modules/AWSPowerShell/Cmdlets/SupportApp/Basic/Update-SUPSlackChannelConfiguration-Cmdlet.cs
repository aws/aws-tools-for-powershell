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
using Amazon.SupportApp;
using Amazon.SupportApp.Model;

namespace Amazon.PowerShell.Cmdlets.SUP
{
    /// <summary>
    /// Updates the configuration for a Slack channel, such as case update notifications.
    /// </summary>
    [Cmdlet("Update", "SUPSlackChannelConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse")]
    [AWSCmdlet("Calls the AWS Support App UpdateSlackChannelConfiguration API operation.", Operation = new[] {"UpdateSlackChannelConfiguration"}, SelectReturnType = typeof(Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse))]
    [AWSCmdletOutput("Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse",
        "This cmdlet returns an Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse object containing multiple properties."
    )]
    public partial class UpdateSUPSlackChannelConfigurationCmdlet : AmazonSupportAppClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelId
        /// <summary>
        /// <para>
        /// <para>The channel ID in Slack. This ID identifies a channel within a Slack workspace.</para>
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
        public System.String ChannelId { get; set; }
        #endregion
        
        #region Parameter ChannelName
        /// <summary>
        /// <para>
        /// <para>The Slack channel name that you want to update.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelName { get; set; }
        #endregion
        
        #region Parameter ChannelRoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that you want to use to perform operations
        /// on Amazon Web Services. For more information, see <a href="https://docs.aws.amazon.com/awssupport/latest/user/support-app-permissions.html">Managing
        /// access to the Amazon Web Services Support App</a> in the <i>Amazon Web Services Support
        /// User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelRoleArn { get; set; }
        #endregion
        
        #region Parameter NotifyOnAddCorrespondenceToCase
        /// <summary>
        /// <para>
        /// <para>Whether you want to get notified when a support case has a new correspondence.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NotifyOnAddCorrespondenceToCase { get; set; }
        #endregion
        
        #region Parameter NotifyOnCaseSeverity
        /// <summary>
        /// <para>
        /// <para>The case severity for a support case that you want to receive notifications.</para><para>If you specify <c>high</c> or <c>all</c>, at least one of the following parameters
        /// must be <c>true</c>:</para><ul><li><para><c>notifyOnAddCorrespondenceToCase</c></para></li><li><para><c>notifyOnCreateOrReopenCase</c></para></li><li><para><c>notifyOnResolveCase</c></para></li></ul><para>If you specify <c>none</c>, any of the following parameters that you specify in your
        /// request must be <c>false</c>:</para><ul><li><para><c>notifyOnAddCorrespondenceToCase</c></para></li><li><para><c>notifyOnCreateOrReopenCase</c></para></li><li><para><c>notifyOnResolveCase</c></para></li></ul><note><para>If you don't specify these parameters in your request, the Amazon Web Services Support
        /// App uses the current values by default.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.SupportApp.NotificationSeverityLevel")]
        public Amazon.SupportApp.NotificationSeverityLevel NotifyOnCaseSeverity { get; set; }
        #endregion
        
        #region Parameter NotifyOnCreateOrReopenCase
        /// <summary>
        /// <para>
        /// <para>Whether you want to get notified when a support case is created or reopened.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NotifyOnCreateOrReopenCase { get; set; }
        #endregion
        
        #region Parameter NotifyOnResolveCase
        /// <summary>
        /// <para>
        /// <para>Whether you want to get notified when a support case is resolved.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NotifyOnResolveCase { get; set; }
        #endregion
        
        #region Parameter TeamId
        /// <summary>
        /// <para>
        /// <para>The team ID in Slack. This ID uniquely identifies a Slack workspace, such as <c>T012ABCDEFG</c>.</para>
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
        public System.String TeamId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse).
        /// Specifying the name of a property of type Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SUPSlackChannelConfiguration (UpdateSlackChannelConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse, UpdateSUPSlackChannelConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelId = this.ChannelId;
            #if MODULAR
            if (this.ChannelId == null && ParameterWasBound(nameof(this.ChannelId)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ChannelName = this.ChannelName;
            context.ChannelRoleArn = this.ChannelRoleArn;
            context.NotifyOnAddCorrespondenceToCase = this.NotifyOnAddCorrespondenceToCase;
            context.NotifyOnCaseSeverity = this.NotifyOnCaseSeverity;
            context.NotifyOnCreateOrReopenCase = this.NotifyOnCreateOrReopenCase;
            context.NotifyOnResolveCase = this.NotifyOnResolveCase;
            context.TeamId = this.TeamId;
            #if MODULAR
            if (this.TeamId == null && ParameterWasBound(nameof(this.TeamId)))
            {
                WriteWarning("You are passing $null as a value for parameter TeamId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SupportApp.Model.UpdateSlackChannelConfigurationRequest();
            
            if (cmdletContext.ChannelId != null)
            {
                request.ChannelId = cmdletContext.ChannelId;
            }
            if (cmdletContext.ChannelName != null)
            {
                request.ChannelName = cmdletContext.ChannelName;
            }
            if (cmdletContext.ChannelRoleArn != null)
            {
                request.ChannelRoleArn = cmdletContext.ChannelRoleArn;
            }
            if (cmdletContext.NotifyOnAddCorrespondenceToCase != null)
            {
                request.NotifyOnAddCorrespondenceToCase = cmdletContext.NotifyOnAddCorrespondenceToCase.Value;
            }
            if (cmdletContext.NotifyOnCaseSeverity != null)
            {
                request.NotifyOnCaseSeverity = cmdletContext.NotifyOnCaseSeverity;
            }
            if (cmdletContext.NotifyOnCreateOrReopenCase != null)
            {
                request.NotifyOnCreateOrReopenCase = cmdletContext.NotifyOnCreateOrReopenCase.Value;
            }
            if (cmdletContext.NotifyOnResolveCase != null)
            {
                request.NotifyOnResolveCase = cmdletContext.NotifyOnResolveCase.Value;
            }
            if (cmdletContext.TeamId != null)
            {
                request.TeamId = cmdletContext.TeamId;
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
        
        private Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse CallAWSServiceOperation(IAmazonSupportApp client, Amazon.SupportApp.Model.UpdateSlackChannelConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support App", "UpdateSlackChannelConfiguration");
            try
            {
                #if DESKTOP
                return client.UpdateSlackChannelConfiguration(request);
                #elif CORECLR
                return client.UpdateSlackChannelConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelId { get; set; }
            public System.String ChannelName { get; set; }
            public System.String ChannelRoleArn { get; set; }
            public System.Boolean? NotifyOnAddCorrespondenceToCase { get; set; }
            public Amazon.SupportApp.NotificationSeverityLevel NotifyOnCaseSeverity { get; set; }
            public System.Boolean? NotifyOnCreateOrReopenCase { get; set; }
            public System.Boolean? NotifyOnResolveCase { get; set; }
            public System.String TeamId { get; set; }
            public System.Func<Amazon.SupportApp.Model.UpdateSlackChannelConfigurationResponse, UpdateSUPSlackChannelConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
