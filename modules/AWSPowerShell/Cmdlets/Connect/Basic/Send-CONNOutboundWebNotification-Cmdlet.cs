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
using Amazon.Connect;
using Amazon.Connect.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CONN
{
    /// <summary>
    /// Sends an outbound web notification to a customer's web browser for outbound campaigns.
    /// For more information about outbound campaigns, see <a href="https://docs.aws.amazon.com/connect/latest/adminguide/enable-outbound-campaigns.html">Set
    /// up Connect Customer outbound campaigns</a>.
    /// 
    ///  <note><para>
    /// Only the Connect Customer outbound campaigns service principal is allowed to assume
    /// a role in your account and call this API.
    /// </para></note>
    /// </summary>
    [Cmdlet("Send", "CONNOutboundWebNotification", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon Connect Service SendOutboundWebNotification API operation.", Operation = new[] {"SendOutboundWebNotification"}, SelectReturnType = typeof(Amazon.Connect.Model.SendOutboundWebNotificationResponse))]
    [AWSCmdletOutput("None or Amazon.Connect.Model.SendOutboundWebNotificationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Connect.Model.SendOutboundWebNotificationResponse) be returned by specifying '-Select *'."
    )]
    public partial class SendCONNOutboundWebNotificationCmdlet : AmazonConnectClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter BrowserId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the customer's web browser instance to which the notification
        /// is being sent.</para>
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
        public System.String BrowserId { get; set; }
        #endregion
        
        #region Parameter Source_SourceCampaign_CampaignId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_SourceCampaign_CampaignId { get; set; }
        #endregion
        
        #region Parameter Content_Attributes_RecommenderConfig_Context
        /// <summary>
        /// <para>
        /// <para>A map of contextual key-value pairs supplied to the recommender to influence the recommendations
        /// returned.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Content_Attributes_RecommenderConfig_Context { get; set; }
        #endregion
        
        #region Parameter Content_Attributes_RecommenderConfig_DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Personalize domain that hosts the recommender.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Attributes_RecommenderConfig_DomainName { get; set; }
        #endregion
        
        #region Parameter ExpiresAt
        /// <summary>
        /// <para>
        /// <para>The timestamp, in Unix epoch time format, at which the web notification expires. After
        /// this time, the notification is no longer delivered to the customer's browser.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.DateTime? ExpiresAt { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Connect Customer instance. You can <a href="https://docs.aws.amazon.com/connect/latest/adminguide/find-instance-arn.html">find
        /// the instance ID</a> in the Amazon Resource Name (ARN) of the instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter Source_SourceCampaign_OutboundRequestId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for a each request part of same campaign.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_SourceCampaign_OutboundRequestId { get; set; }
        #endregion
        
        #region Parameter Destination_ProfileId
        /// <summary>
        /// <para>
        /// <para>The identifier of the customer profile associated with the browser session that should
        /// receive the notification.</para>
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
        public System.String Destination_ProfileId { get; set; }
        #endregion
        
        #region Parameter Content_Attributes_RecommenderConfig_RecommenderName
        /// <summary>
        /// <para>
        /// <para>The name of the recommender used to generate the recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_Attributes_RecommenderConfig_RecommenderName { get; set; }
        #endregion
        
        #region Parameter SessionId
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the customer's web session to which the notification is being
        /// sent.</para>
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
        public System.String SessionId { get; set; }
        #endregion
        
        #region Parameter Content_Type
        /// <summary>
        /// <para>
        /// <para>The type of web notification to send.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Connect.NotificationType")]
        public Amazon.Connect.NotificationType Content_Type { get; set; }
        #endregion
        
        #region Parameter Content_ViewArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the view to render for the notification.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Content_ViewArn { get; set; }
        #endregion
        
        #region Parameter Destination_WidgetId
        /// <summary>
        /// <para>
        /// <para>The identifier of the communication widget that delivers the notification to the customer's
        /// browser.</para>
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
        public System.String Destination_WidgetId { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Connect.Model.SendOutboundWebNotificationResponse).
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.BrowserId),
                nameof(this.InstanceId),
                nameof(this.SessionId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-CONNOutboundWebNotification (SendOutboundWebNotification)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Connect.Model.SendOutboundWebNotificationResponse, SendCONNOutboundWebNotificationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BrowserId = this.BrowserId;
            #if MODULAR
            if (this.BrowserId == null && ParameterWasBound(nameof(this.BrowserId)))
            {
                WriteWarning("You are passing $null as a value for parameter BrowserId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientToken = this.ClientToken;
            if (this.Content_Attributes_RecommenderConfig_Context != null)
            {
                context.Content_Attributes_RecommenderConfig_Context = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Content_Attributes_RecommenderConfig_Context.Keys)
                {
                    context.Content_Attributes_RecommenderConfig_Context.Add((String)hashKey, (System.String)(this.Content_Attributes_RecommenderConfig_Context[hashKey]));
                }
            }
            context.Content_Attributes_RecommenderConfig_DomainName = this.Content_Attributes_RecommenderConfig_DomainName;
            context.Content_Attributes_RecommenderConfig_RecommenderName = this.Content_Attributes_RecommenderConfig_RecommenderName;
            context.Content_Type = this.Content_Type;
            #if MODULAR
            if (this.Content_Type == null && ParameterWasBound(nameof(this.Content_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Content_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Content_ViewArn = this.Content_ViewArn;
            context.Destination_ProfileId = this.Destination_ProfileId;
            #if MODULAR
            if (this.Destination_ProfileId == null && ParameterWasBound(nameof(this.Destination_ProfileId)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_ProfileId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Destination_WidgetId = this.Destination_WidgetId;
            #if MODULAR
            if (this.Destination_WidgetId == null && ParameterWasBound(nameof(this.Destination_WidgetId)))
            {
                WriteWarning("You are passing $null as a value for parameter Destination_WidgetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ExpiresAt = this.ExpiresAt;
            #if MODULAR
            if (this.ExpiresAt == null && ParameterWasBound(nameof(this.ExpiresAt)))
            {
                WriteWarning("You are passing $null as a value for parameter ExpiresAt which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionId = this.SessionId;
            #if MODULAR
            if (this.SessionId == null && ParameterWasBound(nameof(this.SessionId)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Source_SourceCampaign_CampaignId = this.Source_SourceCampaign_CampaignId;
            context.Source_SourceCampaign_OutboundRequestId = this.Source_SourceCampaign_OutboundRequestId;
            
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
            var request = new Amazon.Connect.Model.SendOutboundWebNotificationRequest();
            
            if (cmdletContext.BrowserId != null)
            {
                request.BrowserId = cmdletContext.BrowserId;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Content
            var requestContentIsNull = true;
            request.Content = new Amazon.Connect.Model.WebNotificationContent();
            Amazon.Connect.NotificationType requestContent_content_Type = null;
            if (cmdletContext.Content_Type != null)
            {
                requestContent_content_Type = cmdletContext.Content_Type;
            }
            if (requestContent_content_Type != null)
            {
                request.Content.Type = requestContent_content_Type;
                requestContentIsNull = false;
            }
            System.String requestContent_content_ViewArn = null;
            if (cmdletContext.Content_ViewArn != null)
            {
                requestContent_content_ViewArn = cmdletContext.Content_ViewArn;
            }
            if (requestContent_content_ViewArn != null)
            {
                request.Content.ViewArn = requestContent_content_ViewArn;
                requestContentIsNull = false;
            }
            Amazon.Connect.Model.ContentAttributes requestContent_content_Attributes = null;
            
             // populate Attributes
            var requestContent_content_AttributesIsNull = true;
            requestContent_content_Attributes = new Amazon.Connect.Model.ContentAttributes();
            Amazon.Connect.Model.RecommenderConfig requestContent_content_Attributes_content_Attributes_RecommenderConfig = null;
            
             // populate RecommenderConfig
            var requestContent_content_Attributes_content_Attributes_RecommenderConfigIsNull = true;
            requestContent_content_Attributes_content_Attributes_RecommenderConfig = new Amazon.Connect.Model.RecommenderConfig();
            Dictionary<System.String, System.String> requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_Context = null;
            if (cmdletContext.Content_Attributes_RecommenderConfig_Context != null)
            {
                requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_Context = cmdletContext.Content_Attributes_RecommenderConfig_Context;
            }
            if (requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_Context != null)
            {
                requestContent_content_Attributes_content_Attributes_RecommenderConfig.Context = requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_Context;
                requestContent_content_Attributes_content_Attributes_RecommenderConfigIsNull = false;
            }
            System.String requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_DomainName = null;
            if (cmdletContext.Content_Attributes_RecommenderConfig_DomainName != null)
            {
                requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_DomainName = cmdletContext.Content_Attributes_RecommenderConfig_DomainName;
            }
            if (requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_DomainName != null)
            {
                requestContent_content_Attributes_content_Attributes_RecommenderConfig.DomainName = requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_DomainName;
                requestContent_content_Attributes_content_Attributes_RecommenderConfigIsNull = false;
            }
            System.String requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_RecommenderName = null;
            if (cmdletContext.Content_Attributes_RecommenderConfig_RecommenderName != null)
            {
                requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_RecommenderName = cmdletContext.Content_Attributes_RecommenderConfig_RecommenderName;
            }
            if (requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_RecommenderName != null)
            {
                requestContent_content_Attributes_content_Attributes_RecommenderConfig.RecommenderName = requestContent_content_Attributes_content_Attributes_RecommenderConfig_content_Attributes_RecommenderConfig_RecommenderName;
                requestContent_content_Attributes_content_Attributes_RecommenderConfigIsNull = false;
            }
             // determine if requestContent_content_Attributes_content_Attributes_RecommenderConfig should be set to null
            if (requestContent_content_Attributes_content_Attributes_RecommenderConfigIsNull)
            {
                requestContent_content_Attributes_content_Attributes_RecommenderConfig = null;
            }
            if (requestContent_content_Attributes_content_Attributes_RecommenderConfig != null)
            {
                requestContent_content_Attributes.RecommenderConfig = requestContent_content_Attributes_content_Attributes_RecommenderConfig;
                requestContent_content_AttributesIsNull = false;
            }
             // determine if requestContent_content_Attributes should be set to null
            if (requestContent_content_AttributesIsNull)
            {
                requestContent_content_Attributes = null;
            }
            if (requestContent_content_Attributes != null)
            {
                request.Content.Attributes = requestContent_content_Attributes;
                requestContentIsNull = false;
            }
             // determine if request.Content should be set to null
            if (requestContentIsNull)
            {
                request.Content = null;
            }
            
             // populate Destination
            var requestDestinationIsNull = true;
            request.Destination = new Amazon.Connect.Model.WidgetDestination();
            System.String requestDestination_destination_ProfileId = null;
            if (cmdletContext.Destination_ProfileId != null)
            {
                requestDestination_destination_ProfileId = cmdletContext.Destination_ProfileId;
            }
            if (requestDestination_destination_ProfileId != null)
            {
                request.Destination.ProfileId = requestDestination_destination_ProfileId;
                requestDestinationIsNull = false;
            }
            System.String requestDestination_destination_WidgetId = null;
            if (cmdletContext.Destination_WidgetId != null)
            {
                requestDestination_destination_WidgetId = cmdletContext.Destination_WidgetId;
            }
            if (requestDestination_destination_WidgetId != null)
            {
                request.Destination.WidgetId = requestDestination_destination_WidgetId;
                requestDestinationIsNull = false;
            }
             // determine if request.Destination should be set to null
            if (requestDestinationIsNull)
            {
                request.Destination = null;
            }
            if (cmdletContext.ExpiresAt != null)
            {
                request.ExpiresAt = cmdletContext.ExpiresAt.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.SessionId != null)
            {
                request.SessionId = cmdletContext.SessionId;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.Connect.Model.WebNotificationSource();
            Amazon.Connect.Model.SourceCampaign requestSource_source_SourceCampaign = null;
            
             // populate SourceCampaign
            var requestSource_source_SourceCampaignIsNull = true;
            requestSource_source_SourceCampaign = new Amazon.Connect.Model.SourceCampaign();
            System.String requestSource_source_SourceCampaign_source_SourceCampaign_CampaignId = null;
            if (cmdletContext.Source_SourceCampaign_CampaignId != null)
            {
                requestSource_source_SourceCampaign_source_SourceCampaign_CampaignId = cmdletContext.Source_SourceCampaign_CampaignId;
            }
            if (requestSource_source_SourceCampaign_source_SourceCampaign_CampaignId != null)
            {
                requestSource_source_SourceCampaign.CampaignId = requestSource_source_SourceCampaign_source_SourceCampaign_CampaignId;
                requestSource_source_SourceCampaignIsNull = false;
            }
            System.String requestSource_source_SourceCampaign_source_SourceCampaign_OutboundRequestId = null;
            if (cmdletContext.Source_SourceCampaign_OutboundRequestId != null)
            {
                requestSource_source_SourceCampaign_source_SourceCampaign_OutboundRequestId = cmdletContext.Source_SourceCampaign_OutboundRequestId;
            }
            if (requestSource_source_SourceCampaign_source_SourceCampaign_OutboundRequestId != null)
            {
                requestSource_source_SourceCampaign.OutboundRequestId = requestSource_source_SourceCampaign_source_SourceCampaign_OutboundRequestId;
                requestSource_source_SourceCampaignIsNull = false;
            }
             // determine if requestSource_source_SourceCampaign should be set to null
            if (requestSource_source_SourceCampaignIsNull)
            {
                requestSource_source_SourceCampaign = null;
            }
            if (requestSource_source_SourceCampaign != null)
            {
                request.Source.SourceCampaign = requestSource_source_SourceCampaign;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
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
        
        private Amazon.Connect.Model.SendOutboundWebNotificationResponse CallAWSServiceOperation(IAmazonConnect client, Amazon.Connect.Model.SendOutboundWebNotificationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Connect Service", "SendOutboundWebNotification");
            try
            {
                return client.SendOutboundWebNotificationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String BrowserId { get; set; }
            public System.String ClientToken { get; set; }
            public Dictionary<System.String, System.String> Content_Attributes_RecommenderConfig_Context { get; set; }
            public System.String Content_Attributes_RecommenderConfig_DomainName { get; set; }
            public System.String Content_Attributes_RecommenderConfig_RecommenderName { get; set; }
            public Amazon.Connect.NotificationType Content_Type { get; set; }
            public System.String Content_ViewArn { get; set; }
            public System.String Destination_ProfileId { get; set; }
            public System.String Destination_WidgetId { get; set; }
            public System.DateTime? ExpiresAt { get; set; }
            public System.String InstanceId { get; set; }
            public System.String SessionId { get; set; }
            public System.String Source_SourceCampaign_CampaignId { get; set; }
            public System.String Source_SourceCampaign_OutboundRequestId { get; set; }
            public System.Func<Amazon.Connect.Model.SendOutboundWebNotificationResponse, SendCONNOutboundWebNotificationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
