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
using Amazon.Connect;
using Amazon.Connect.Model;

namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Creates a new notification to be delivered to specified recipients. Notifications
    /// can include localized content with links, and an optional expiration time. Recipients
    /// can be specified as individual user ARNs or instance ARNs to target all users in an
    /// instance.
    /// </summary>
    [Cmdlet("New", "CONNNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Connect.Model.CreateNotificationResponse")]
    [AWSCmdlet("Calls the Amazon Connect Service CreateNotification API operation.", Operation = new[] {"CreateNotification"}, SelectReturnType = typeof(Amazon.Connect.Model.CreateNotificationResponse))]
    [AWSCmdletOutput("Amazon.Connect.Model.CreateNotificationResponse",
        "This cmdlet returns an Amazon.Connect.Model.CreateNotificationResponse object containing multiple properties."
    )]
    public partial class NewCONNNotificationCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Content
        /// <summary>
        /// <para>
        /// <para>The localized content of the notification. A map where keys are locale codes and values
        /// are the notification text in that locale. Content supports links. Maximum 250 characters
        /// per locale.</para>
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
        public System.Collections.Hashtable Content { get; set; }
        #endregion
        
        #region Parameter ExpiresAt
        /// <summary>
        /// <para>
        /// <para>The timestamp when the notification should expire and no longer be displayed to users.
        /// If not specified, defaults to one week from creation.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? ExpiresAt { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Connect instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter PredefinedNotificationId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PredefinedNotificationId { get; set; }
        #endregion
        
        #region Parameter Priority
        /// <summary>
        /// <para>
        /// <para>The priority level of the notification. Valid values are HIGH and LOW. High priority
        /// notifications are displayed above low priority notifications.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Connect.ConfigurableNotificationPriority")]
        public Amazon.Connect.ConfigurableNotificationPriority Priority { get; set; }
        #endregion
        
        #region Parameter Recipient
        /// <summary>
        /// <para>
        /// <para>A list of Amazon Resource Names (ARNs) identifying the recipients of the notification.
        /// Can include user ARNs or instance ARNs to target all users in an instance. Maximum
        /// of 200 recipients.</para>
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
        [Alias("Recipients")]
        public System.String[] Recipient { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags used to organize, track, or control access for this resource. For example,
        /// <c>{ "Tags": {"key1":"value1", "key2":"value2"} }</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request. If not provided, the Amazon Web Services SDK populates this field. For
        /// more information about idempotency, see <a href="https://aws.amazon.com/builders-library/making-retries-safe-with-idempotent-APIs/">Making
        /// retries safe with idempotent APIs</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.CreateNotificationResponse).
        /// Specifying the name of a property of type Amazon.Connect.Model.CreateNotificationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InstanceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InstanceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CONNNotification (CreateNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.CreateNotificationResponse, NewCONNNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InstanceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            if (this.Content != null)
            {
                context.Content = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Content.Keys)
                {
                    context.Content.Add((String)hashKey, (System.String)(this.Content[hashKey]));
                }
            }
            #if MODULAR
            if (this.Content == null && ParameterWasBound(nameof(this.Content)))
            {
                WriteWarning("You are passing $null as a value for parameter Content which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpiresAt = this.ExpiresAt;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PredefinedNotificationId = this.PredefinedNotificationId;
            context.Priority = this.Priority;
            if (this.Recipient != null)
            {
                context.Recipient = new List<System.String>(this.Recipient);
            }
            #if MODULAR
            if (this.Recipient == null && ParameterWasBound(nameof(this.Recipient)))
            {
                WriteWarning("You are passing $null as a value for parameter Recipient which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.Connect.Model.CreateNotificationRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Content != null)
            {
                request.Content = cmdletContext.Content;
            }
            if (cmdletContext.ExpiresAt != null)
            {
                request.ExpiresAt = cmdletContext.ExpiresAt.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.PredefinedNotificationId != null)
            {
                request.PredefinedNotificationId = cmdletContext.PredefinedNotificationId;
            }
            if (cmdletContext.Priority != null)
            {
                request.Priority = cmdletContext.Priority;
            }
            if (cmdletContext.Recipient != null)
            {
                request.Recipients = cmdletContext.Recipient;
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
        
        private Amazon.Connect.Model.CreateNotificationResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.CreateNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "CreateNotification");
            try
            {
                #if DESKTOP
                return client.CreateNotification(request);
                #elif CORECLR
                return client.CreateNotificationAsync(request).GetAwaiter().GetResult();
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
            public Dictionary<System.String, System.String> Content { get; set; }
            public System.DateTime? ExpiresAt { get; set; }
            public System.String InstanceId { get; set; }
            public System.String PredefinedNotificationId { get; set; }
            public Amazon.Connect.ConfigurableNotificationPriority Priority { get; set; }
            public List<System.String> Recipient { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Connect.Model.CreateNotificationResponse, NewCONNNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
