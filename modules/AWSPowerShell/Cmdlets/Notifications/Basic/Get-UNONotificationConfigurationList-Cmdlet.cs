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
using Amazon.Notifications;
using Amazon.Notifications.Model;

namespace Amazon.PowerShell.Cmdlets.UNO
{
    /// <summary>
    /// Returns a list of abbreviated <c>NotificationConfigurations</c> according to specified
    /// filters, in reverse chronological order (newest first).
    /// </summary>
    [Cmdlet("Get", "UNONotificationConfigurationList")]
    [OutputType("Amazon.Notifications.Model.NotificationConfigurationStructure")]
    [AWSCmdlet("Calls the AWS User Notifications ListNotificationConfigurations API operation.", Operation = new[] {"ListNotificationConfigurations"}, SelectReturnType = typeof(Amazon.Notifications.Model.ListNotificationConfigurationsResponse))]
    [AWSCmdletOutput("Amazon.Notifications.Model.NotificationConfigurationStructure or Amazon.Notifications.Model.ListNotificationConfigurationsResponse",
        "This cmdlet returns a collection of Amazon.Notifications.Model.NotificationConfigurationStructure objects.",
        "The service call response (type Amazon.Notifications.Model.ListNotificationConfigurationsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetUNONotificationConfigurationListCmdlet : AmazonNotificationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ChannelArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Channel to match.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ChannelArn { get; set; }
        #endregion
        
        #region Parameter EventRuleSource
        /// <summary>
        /// <para>
        /// <para>The matched event source.</para><para>Must match one of the valid EventBridge sources. Only Amazon Web Services service
        /// sourced events are supported. For example, <c>aws.ec2</c> and <c>aws.cloudwatch</c>.
        /// For more information, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-service-event.html#eb-service-event-delivery-level">Event
        /// delivery from Amazon Web Services services</a> in the <i>Amazon EventBridge User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventRuleSource { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The <c>NotificationConfiguration</c> status to match.</para><ul><li><para>Values:</para><ul><li><para><c>ACTIVE</c></para><ul><li><para>All <c>EventRules</c> are <c>ACTIVE</c> and any call can be run.</para></li></ul></li><li><para><c>PARTIALLY_ACTIVE</c></para><ul><li><para>Some <c>EventRules</c> are <c>ACTIVE</c> and some are <c>INACTIVE</c>. Any call can
        /// be run.</para></li><li><para>Any call can be run.</para></li></ul></li><li><para><c>INACTIVE</c></para><ul><li><para>All <c>EventRules</c> are <c>INACTIVE</c> and any call can be run.</para></li></ul></li><li><para><c>DELETING</c></para><ul><li><para>This <c>NotificationConfiguration</c> is being deleted.</para></li><li><para>Only <c>GET</c> and <c>LIST</c> calls can be run.</para></li></ul></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Notifications.NotificationConfigurationStatus")]
        public Amazon.Notifications.NotificationConfigurationStatus Status { get; set; }
        #endregion
        
        #region Parameter Subtype
        /// <summary>
        /// <para>
        /// <para>The subtype used to filter the notification configurations in the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Notifications.NotificationConfigurationSubtype")]
        public Amazon.Notifications.NotificationConfigurationSubtype Subtype { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of results to be returned in this call. Defaults to 20.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The start token for paginated calls. Retrieved from the response of a previous <c>ListEventRules</c>
        /// call. Next token uses Base64 encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'NotificationConfigurations'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Notifications.Model.ListNotificationConfigurationsResponse).
        /// Specifying the name of a property of type Amazon.Notifications.Model.ListNotificationConfigurationsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "NotificationConfigurations";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Notifications.Model.ListNotificationConfigurationsResponse, GetUNONotificationConfigurationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ChannelArn = this.ChannelArn;
            context.EventRuleSource = this.EventRuleSource;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.Status = this.Status;
            context.Subtype = this.Subtype;
            
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
            var request = new Amazon.Notifications.Model.ListNotificationConfigurationsRequest();
            
            if (cmdletContext.ChannelArn != null)
            {
                request.ChannelArn = cmdletContext.ChannelArn;
            }
            if (cmdletContext.EventRuleSource != null)
            {
                request.EventRuleSource = cmdletContext.EventRuleSource;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Subtype != null)
            {
                request.Subtype = cmdletContext.Subtype;
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
        
        private Amazon.Notifications.Model.ListNotificationConfigurationsResponse CallAWSServiceOperation(IAmazonNotifications client, Amazon.Notifications.Model.ListNotificationConfigurationsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS User Notifications", "ListNotificationConfigurations");
            try
            {
                #if DESKTOP
                return client.ListNotificationConfigurations(request);
                #elif CORECLR
                return client.ListNotificationConfigurationsAsync(request).GetAwaiter().GetResult();
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
            public System.String ChannelArn { get; set; }
            public System.String EventRuleSource { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public Amazon.Notifications.NotificationConfigurationStatus Status { get; set; }
            public Amazon.Notifications.NotificationConfigurationSubtype Subtype { get; set; }
            public System.Func<Amazon.Notifications.Model.ListNotificationConfigurationsResponse, GetUNONotificationConfigurationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.NotificationConfigurations;
        }
        
    }
}
