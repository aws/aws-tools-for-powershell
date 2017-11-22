/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using Amazon.WorkDocs;
using Amazon.WorkDocs.Model;

namespace Amazon.PowerShell.Cmdlets.WD
{
    /// <summary>
    /// Configure WorkDocs to use Amazon SNS notifications.
    /// 
    ///  
    /// <para>
    /// The endpoint receives a confirmation message, and must confirm the subscription. For
    /// more information, see <a href="http://docs.aws.amazon.com/sns/latest/dg/SendMessageToHttp.html#SendMessageToHttp.confirm">Confirm
    /// the Subscription</a> in the <i>Amazon Simple Notification Service Developer Guide</i>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "WDNotificationSubscription", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkDocs.Model.Subscription")]
    [AWSCmdlet("Calls the Amazon WorkDocs CreateNotificationSubscription API operation.", Operation = new[] {"CreateNotificationSubscription"})]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.Subscription",
        "This cmdlet returns a Subscription object.",
        "The service call response (type Amazon.WorkDocs.Model.CreateNotificationSubscriptionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewWDNotificationSubscriptionCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        #region Parameter Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint to receive the notifications. If the protocol is HTTPS, the endpoint
        /// is a URL that begins with "https://".</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Endpoint { get; set; }
        #endregion
        
        #region Parameter OrganizationId
        /// <summary>
        /// <para>
        /// <para>The ID of the organization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String OrganizationId { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The protocol to use. The supported value is https, which delivers JSON-encoded messages
        /// using HTTPS POST.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WorkDocs.SubscriptionProtocolType")]
        public Amazon.WorkDocs.SubscriptionProtocolType Protocol { get; set; }
        #endregion
        
        #region Parameter SubscriptionType
        /// <summary>
        /// <para>
        /// <para>The notification type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.WorkDocs.SubscriptionType")]
        public Amazon.WorkDocs.SubscriptionType SubscriptionType { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("OrganizationId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-WDNotificationSubscription (CreateNotificationSubscription)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.Endpoint = this.Endpoint;
            context.OrganizationId = this.OrganizationId;
            context.Protocol = this.Protocol;
            context.SubscriptionType = this.SubscriptionType;
            
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
            var request = new Amazon.WorkDocs.Model.CreateNotificationSubscriptionRequest();
            
            if (cmdletContext.Endpoint != null)
            {
                request.Endpoint = cmdletContext.Endpoint;
            }
            if (cmdletContext.OrganizationId != null)
            {
                request.OrganizationId = cmdletContext.OrganizationId;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.SubscriptionType != null)
            {
                request.SubscriptionType = cmdletContext.SubscriptionType;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Subscription;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.WorkDocs.Model.CreateNotificationSubscriptionResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.CreateNotificationSubscriptionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "CreateNotificationSubscription");
            try
            {
                #if DESKTOP
                return client.CreateNotificationSubscription(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateNotificationSubscriptionAsync(request);
                return task.Result;
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
            public System.String Endpoint { get; set; }
            public System.String OrganizationId { get; set; }
            public Amazon.WorkDocs.SubscriptionProtocolType Protocol { get; set; }
            public Amazon.WorkDocs.SubscriptionType SubscriptionType { get; set; }
        }
        
    }
}
