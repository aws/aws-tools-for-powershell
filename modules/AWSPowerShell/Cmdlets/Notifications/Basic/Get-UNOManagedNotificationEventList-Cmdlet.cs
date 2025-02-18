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
using Amazon.Notifications;
using Amazon.Notifications.Model;

namespace Amazon.PowerShell.Cmdlets.UNO
{
    /// <summary>
    /// Returns a list of Managed Notification Events according to specified filters, ordered
    /// by creation time in reverse chronological order (newest first).
    /// </summary>
    [Cmdlet("Get", "UNOManagedNotificationEventList")]
    [OutputType("Amazon.Notifications.Model.ManagedNotificationEventOverview")]
    [AWSCmdlet("Calls the AWS User Notifications ListManagedNotificationEvents API operation.", Operation = new[] {"ListManagedNotificationEvents"}, SelectReturnType = typeof(Amazon.Notifications.Model.ListManagedNotificationEventsResponse))]
    [AWSCmdletOutput("Amazon.Notifications.Model.ManagedNotificationEventOverview or Amazon.Notifications.Model.ListManagedNotificationEventsResponse",
        "This cmdlet returns a collection of Amazon.Notifications.Model.ManagedNotificationEventOverview objects.",
        "The service call response (type Amazon.Notifications.Model.ListManagedNotificationEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetUNOManagedNotificationEventListCmdlet : AmazonNotificationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter EndTime
        /// <summary>
        /// <para>
        /// <para>Latest time of events to return from this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EndTime { get; set; }
        #endregion
        
        #region Parameter Locale
        /// <summary>
        /// <para>
        /// <para>The locale code of the language used for the retrieved NotificationEvent. The default
        /// locale is English (en_US).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Notifications.LocaleCode")]
        public Amazon.Notifications.LocaleCode Locale { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The Organizational Unit Id that an Amazon Web Services account belongs to.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter RelatedAccount
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the Managed Notification Events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedAccount { get; set; }
        #endregion
        
        #region Parameter Source
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services service the event originates from. For example aws.cloudwatch.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source { get; set; }
        #endregion
        
        #region Parameter StartTime
        /// <summary>
        /// <para>
        /// <para>The earliest time of events to return from this call.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? StartTime { get; set; }
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
        /// <para>The start token for paginated calls. Retrieved from the response of a previous <c>ListManagedNotificationChannelAssociations</c>
        /// call. Next token uses Base64 encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ManagedNotificationEvents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Notifications.Model.ListManagedNotificationEventsResponse).
        /// Specifying the name of a property of type Amazon.Notifications.Model.ListManagedNotificationEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ManagedNotificationEvents";
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
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Notifications.Model.ListManagedNotificationEventsResponse, GetUNOManagedNotificationEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.EndTime = this.EndTime;
            context.Locale = this.Locale;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OrganizationalUnitId = this.OrganizationalUnitId;
            context.RelatedAccount = this.RelatedAccount;
            context.Source = this.Source;
            context.StartTime = this.StartTime;
            
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
            var request = new Amazon.Notifications.Model.ListManagedNotificationEventsRequest();
            
            if (cmdletContext.EndTime != null)
            {
                request.EndTime = cmdletContext.EndTime.Value;
            }
            if (cmdletContext.Locale != null)
            {
                request.Locale = cmdletContext.Locale;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
            }
            if (cmdletContext.OrganizationalUnitId != null)
            {
                request.OrganizationalUnitId = cmdletContext.OrganizationalUnitId;
            }
            if (cmdletContext.RelatedAccount != null)
            {
                request.RelatedAccount = cmdletContext.RelatedAccount;
            }
            if (cmdletContext.Source != null)
            {
                request.Source = cmdletContext.Source;
            }
            if (cmdletContext.StartTime != null)
            {
                request.StartTime = cmdletContext.StartTime.Value;
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
        
        private Amazon.Notifications.Model.ListManagedNotificationEventsResponse CallAWSServiceOperation(IAmazonNotifications client, Amazon.Notifications.Model.ListManagedNotificationEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS User Notifications", "ListManagedNotificationEvents");
            try
            {
                return client.ListManagedNotificationEventsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.DateTime? EndTime { get; set; }
            public Amazon.Notifications.LocaleCode Locale { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OrganizationalUnitId { get; set; }
            public System.String RelatedAccount { get; set; }
            public System.String Source { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.Notifications.Model.ListManagedNotificationEventsResponse, GetUNOManagedNotificationEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ManagedNotificationEvents;
        }
        
    }
}
