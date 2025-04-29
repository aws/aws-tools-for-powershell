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
using Amazon.SupportApp;
using Amazon.SupportApp.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SUP
{
    /// <summary>
    /// Creates a Slack channel configuration for your Amazon Web Services account.
    /// 
    ///  <note><ul><li><para>
    /// You can add up to 5 Slack workspaces for your account.
    /// </para></li><li><para>
    /// You can add up to 20 Slack channels for your account.
    /// </para></li></ul></note><para>
    /// A Slack channel can have up to 100 Amazon Web Services accounts. This means that only
    /// 100 accounts can add the same Slack channel to the Amazon Web Services Support App.
    /// We recommend that you only add the accounts that you need to manage support cases
    /// for your organization. This can reduce the notifications about case updates that you
    /// receive in the Slack channel.
    /// </para><note><para>
    /// We recommend that you choose a private Slack channel so that only members in that
    /// channel have read and write access to your support cases. Anyone in your Slack channel
    /// can create, update, or resolve support cases for your account. Users require an invitation
    /// to join private channels. 
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SUPSlackChannelConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Support App CreateSlackChannelConfiguration API operation.", Operation = new[] {"CreateSlackChannelConfiguration"}, SelectReturnType = typeof(Amazon.SupportApp.Model.CreateSlackChannelConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.SupportApp.Model.CreateSlackChannelConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SupportApp.Model.CreateSlackChannelConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class NewSUPSlackChannelConfigurationCmdlet : AmazonSupportAppClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
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
        /// <para>The name of the Slack channel that you configure for the Amazon Web Services Support
        /// App.</para>
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
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// <para>The case severity for a support case that you want to receive notifications.</para><para>If you specify <c>high</c> or <c>all</c>, you must specify <c>true</c> for at least
        /// one of the following parameters:</para><ul><li><para><c>notifyOnAddCorrespondenceToCase</c></para></li><li><para><c>notifyOnCreateOrReopenCase</c></para></li><li><para><c>notifyOnResolveCase</c></para></li></ul><para>If you specify <c>none</c>, the following parameters must be null or <c>false</c>:</para><ul><li><para><c>notifyOnAddCorrespondenceToCase</c></para></li><li><para><c>notifyOnCreateOrReopenCase</c></para></li><li><para><c>notifyOnResolveCase</c></para></li></ul><note><para>If you don't specify these parameters in your request, they default to <c>false</c>.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SupportApp.Model.CreateSlackChannelConfigurationResponse).
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ChannelId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SUPSlackChannelConfiguration (CreateSlackChannelConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SupportApp.Model.CreateSlackChannelConfigurationResponse, NewSUPSlackChannelConfigurationCmdlet>(Select) ??
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
            #if MODULAR
            if (this.ChannelRoleArn == null && ParameterWasBound(nameof(this.ChannelRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ChannelRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotifyOnAddCorrespondenceToCase = this.NotifyOnAddCorrespondenceToCase;
            context.NotifyOnCaseSeverity = this.NotifyOnCaseSeverity;
            #if MODULAR
            if (this.NotifyOnCaseSeverity == null && ParameterWasBound(nameof(this.NotifyOnCaseSeverity)))
            {
                WriteWarning("You are passing $null as a value for parameter NotifyOnCaseSeverity which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.SupportApp.Model.CreateSlackChannelConfigurationRequest();
            
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
        
        private Amazon.SupportApp.Model.CreateSlackChannelConfigurationResponse CallAWSServiceOperation(IAmazonSupportApp client, Amazon.SupportApp.Model.CreateSlackChannelConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Support App", "CreateSlackChannelConfiguration");
            try
            {
                return client.CreateSlackChannelConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Func<Amazon.SupportApp.Model.CreateSlackChannelConfigurationResponse, NewSUPSlackChannelConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
