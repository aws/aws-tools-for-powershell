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
using Amazon.DevOpsGuru;
using Amazon.DevOpsGuru.Model;

namespace Amazon.PowerShell.Cmdlets.DGURU
{
    /// <summary>
    /// Adds a notification channel to DevOps Guru. A notification channel is used to notify
    /// you about important DevOps Guru events, such as when an insight is generated. 
    /// 
    ///  
    /// <para>
    /// If you use an Amazon SNS topic in another account, you must attach a policy to it
    /// that grants DevOps Guru permission to send it notifications. DevOps Guru adds the
    /// required policy on your behalf to send notifications using Amazon SNS in your account.
    /// DevOps Guru only supports standard SNS topics. For more information, see <a href="https://docs.aws.amazon.com/devops-guru/latest/userguide/sns-required-permissions.html">Permissions
    /// for Amazon SNS topics</a>.
    /// </para><para>
    /// If you use an Amazon SNS topic that is encrypted by an Amazon Web Services Key Management
    /// Service customer-managed key (CMK), then you must add permissions to the CMK. For
    /// more information, see <a href="https://docs.aws.amazon.com/devops-guru/latest/userguide/sns-kms-permissions.html">Permissions
    /// for Amazon Web Services KMS–encrypted Amazon SNS topics</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Add", "DGURUNotificationChannel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon DevOps Guru AddNotificationChannel API operation.", Operation = new[] {"AddNotificationChannel"}, SelectReturnType = typeof(Amazon.DevOpsGuru.Model.AddNotificationChannelResponse))]
    [AWSCmdletOutput("System.String or Amazon.DevOpsGuru.Model.AddNotificationChannelResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.DevOpsGuru.Model.AddNotificationChannelResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddDGURUNotificationChannelCmdlet : AmazonDevOpsGuruClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Filters_MessageType
        /// <summary>
        /// <para>
        /// <para> The events that you want to receive notifications for. For example, you can choose
        /// to receive notifications only when the severity level is upgraded or a new insight
        /// is created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_Filters_MessageTypes")]
        public System.String[] Filters_MessageType { get; set; }
        #endregion
        
        #region Parameter Filters_Severity
        /// <summary>
        /// <para>
        /// <para> The severity levels that you want to receive notifications for. For example, you
        /// can choose to receive notifications only for insights with <c>HIGH</c> and <c>MEDIUM</c>
        /// severity levels. For more information, see <a href="https://docs.aws.amazon.com/devops-guru/latest/userguide/working-with-insights.html#understanding-insights-severities">Understanding
        /// insight severities</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Config_Filters_Severities")]
        public System.String[] Filters_Severity { get; set; }
        #endregion
        
        #region Parameter Config_Sn
        /// <summary>
        /// <para>
        /// <para> Information about a notification channel configured in DevOps Guru to send notifications
        /// when insights are created. </para><para>If you use an Amazon SNS topic in another account, you must attach a policy to it
        /// that grants DevOps Guru permission to send it notifications. DevOps Guru adds the
        /// required policy on your behalf to send notifications using Amazon SNS in your account.
        /// DevOps Guru only supports standard SNS topics. For more information, see <a href="https://docs.aws.amazon.com/devops-guru/latest/userguide/sns-required-permissions.html">Permissions
        /// for Amazon SNS topics</a>.</para><para>If you use an Amazon SNS topic that is encrypted by an Amazon Web Services Key Management
        /// Service customer-managed key (CMK), then you must add permissions to the CMK. For
        /// more information, see <a href="https://docs.aws.amazon.com/devops-guru/latest/userguide/sns-kms-permissions.html">Permissions
        /// for Amazon Web Services KMS–encrypted Amazon SNS topics</a>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Config_Sns")]
        public Amazon.DevOpsGuru.Model.SnsChannelConfig Config_Sn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Id'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DevOpsGuru.Model.AddNotificationChannelResponse).
        /// Specifying the name of a property of type Amazon.DevOpsGuru.Model.AddNotificationChannelResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Id";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Config_Sn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Config_Sn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Config_Sn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Config_Sn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-DGURUNotificationChannel (AddNotificationChannel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DevOpsGuru.Model.AddNotificationChannelResponse, AddDGURUNotificationChannelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Config_Sn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Filters_MessageType != null)
            {
                context.Filters_MessageType = new List<System.String>(this.Filters_MessageType);
            }
            if (this.Filters_Severity != null)
            {
                context.Filters_Severity = new List<System.String>(this.Filters_Severity);
            }
            context.Config_Sn = this.Config_Sn;
            #if MODULAR
            if (this.Config_Sn == null && ParameterWasBound(nameof(this.Config_Sn)))
            {
                WriteWarning("You are passing $null as a value for parameter Config_Sn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.DevOpsGuru.Model.AddNotificationChannelRequest();
            
            
             // populate Config
            var requestConfigIsNull = true;
            request.Config = new Amazon.DevOpsGuru.Model.NotificationChannelConfig();
            Amazon.DevOpsGuru.Model.SnsChannelConfig requestConfig_config_Sn = null;
            if (cmdletContext.Config_Sn != null)
            {
                requestConfig_config_Sn = cmdletContext.Config_Sn;
            }
            if (requestConfig_config_Sn != null)
            {
                request.Config.Sns = requestConfig_config_Sn;
                requestConfigIsNull = false;
            }
            Amazon.DevOpsGuru.Model.NotificationFilterConfig requestConfig_config_Filters = null;
            
             // populate Filters
            var requestConfig_config_FiltersIsNull = true;
            requestConfig_config_Filters = new Amazon.DevOpsGuru.Model.NotificationFilterConfig();
            List<System.String> requestConfig_config_Filters_filters_MessageType = null;
            if (cmdletContext.Filters_MessageType != null)
            {
                requestConfig_config_Filters_filters_MessageType = cmdletContext.Filters_MessageType;
            }
            if (requestConfig_config_Filters_filters_MessageType != null)
            {
                requestConfig_config_Filters.MessageTypes = requestConfig_config_Filters_filters_MessageType;
                requestConfig_config_FiltersIsNull = false;
            }
            List<System.String> requestConfig_config_Filters_filters_Severity = null;
            if (cmdletContext.Filters_Severity != null)
            {
                requestConfig_config_Filters_filters_Severity = cmdletContext.Filters_Severity;
            }
            if (requestConfig_config_Filters_filters_Severity != null)
            {
                requestConfig_config_Filters.Severities = requestConfig_config_Filters_filters_Severity;
                requestConfig_config_FiltersIsNull = false;
            }
             // determine if requestConfig_config_Filters should be set to null
            if (requestConfig_config_FiltersIsNull)
            {
                requestConfig_config_Filters = null;
            }
            if (requestConfig_config_Filters != null)
            {
                request.Config.Filters = requestConfig_config_Filters;
                requestConfigIsNull = false;
            }
             // determine if request.Config should be set to null
            if (requestConfigIsNull)
            {
                request.Config = null;
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
        
        private Amazon.DevOpsGuru.Model.AddNotificationChannelResponse CallAWSServiceOperation(IAmazonDevOpsGuru client, Amazon.DevOpsGuru.Model.AddNotificationChannelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DevOps Guru", "AddNotificationChannel");
            try
            {
                #if DESKTOP
                return client.AddNotificationChannel(request);
                #elif CORECLR
                return client.AddNotificationChannelAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Filters_MessageType { get; set; }
            public List<System.String> Filters_Severity { get; set; }
            public Amazon.DevOpsGuru.Model.SnsChannelConfig Config_Sn { get; set; }
            public System.Func<Amazon.DevOpsGuru.Model.AddNotificationChannelResponse, AddDGURUNotificationChannelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Id;
        }
        
    }
}
