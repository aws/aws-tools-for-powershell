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
using Amazon.Notifications;
using Amazon.Notifications.Model;

namespace Amazon.PowerShell.Cmdlets.UNO
{
    /// <summary>
    /// Returns a list of <c>ManagedNotificationChildEvents</c> for a specified aggregate
    /// <c>ManagedNotificationEvent</c>, ordered by creation time in reverse chronological
    /// order (newest first).
    /// </summary>
    [Cmdlet("Get", "UNOManagedNotificationChildEventList")]
    [OutputType("Amazon.Notifications.Model.ManagedNotificationChildEventOverview")]
    [AWSCmdlet("Calls the AWS User Notifications ListManagedNotificationChildEvents API operation.", Operation = new[] {"ListManagedNotificationChildEvents"}, SelectReturnType = typeof(Amazon.Notifications.Model.ListManagedNotificationChildEventsResponse))]
    [AWSCmdletOutput("Amazon.Notifications.Model.ManagedNotificationChildEventOverview or Amazon.Notifications.Model.ListManagedNotificationChildEventsResponse",
        "This cmdlet returns a collection of Amazon.Notifications.Model.ManagedNotificationChildEventOverview objects.",
        "The service call response (type Amazon.Notifications.Model.ListManagedNotificationChildEventsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetUNOManagedNotificationChildEventListCmdlet : AmazonNotificationsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AggregateManagedNotificationEventArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the <c>ManagedNotificationEvent</c>.</para>
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
        public System.String AggregateManagedNotificationEventArn { get; set; }
        #endregion
        
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
        /// <para>The locale code of the language used for the retrieved <c>NotificationEvent</c>. The
        /// default locale is English.<c>en_US</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Notifications.LocaleCode")]
        public Amazon.Notifications.LocaleCode Locale { get; set; }
        #endregion
        
        #region Parameter OrganizationalUnitId
        /// <summary>
        /// <para>
        /// <para>The identifier of the Amazon Web Services Organizations organizational unit (OU) associated
        /// with the Managed Notification Child Events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OrganizationalUnitId { get; set; }
        #endregion
        
        #region Parameter RelatedAccount
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the Managed Notification Child
        /// Events.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RelatedAccount { get; set; }
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
        /// <para>The start token for paginated calls. Retrieved from the response of a previous ListManagedNotificationChannelAssociations
        /// call. Next token uses Base64 encoding.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ManagedNotificationChildEvents'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Notifications.Model.ListManagedNotificationChildEventsResponse).
        /// Specifying the name of a property of type Amazon.Notifications.Model.ListManagedNotificationChildEventsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ManagedNotificationChildEvents";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the AggregateManagedNotificationEventArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^AggregateManagedNotificationEventArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^AggregateManagedNotificationEventArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Notifications.Model.ListManagedNotificationChildEventsResponse, GetUNOManagedNotificationChildEventListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.AggregateManagedNotificationEventArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AggregateManagedNotificationEventArn = this.AggregateManagedNotificationEventArn;
            #if MODULAR
            if (this.AggregateManagedNotificationEventArn == null && ParameterWasBound(nameof(this.AggregateManagedNotificationEventArn)))
            {
                WriteWarning("You are passing $null as a value for parameter AggregateManagedNotificationEventArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EndTime = this.EndTime;
            context.Locale = this.Locale;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            context.OrganizationalUnitId = this.OrganizationalUnitId;
            context.RelatedAccount = this.RelatedAccount;
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
            var request = new Amazon.Notifications.Model.ListManagedNotificationChildEventsRequest();
            
            if (cmdletContext.AggregateManagedNotificationEventArn != null)
            {
                request.AggregateManagedNotificationEventArn = cmdletContext.AggregateManagedNotificationEventArn;
            }
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
        
        private Amazon.Notifications.Model.ListManagedNotificationChildEventsResponse CallAWSServiceOperation(IAmazonNotifications client, Amazon.Notifications.Model.ListManagedNotificationChildEventsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS User Notifications", "ListManagedNotificationChildEvents");
            try
            {
                #if DESKTOP
                return client.ListManagedNotificationChildEvents(request);
                #elif CORECLR
                return client.ListManagedNotificationChildEventsAsync(request).GetAwaiter().GetResult();
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
            public System.String AggregateManagedNotificationEventArn { get; set; }
            public System.DateTime? EndTime { get; set; }
            public Amazon.Notifications.LocaleCode Locale { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.String OrganizationalUnitId { get; set; }
            public System.String RelatedAccount { get; set; }
            public System.DateTime? StartTime { get; set; }
            public System.Func<Amazon.Notifications.Model.ListManagedNotificationChildEventsResponse, GetUNOManagedNotificationChildEventListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ManagedNotificationChildEvents;
        }
        
    }
}
