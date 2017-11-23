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
    /// Creates a set of permissions for the specified folder or document. The resource permissions
    /// are overwritten if the principals already have different permissions.
    /// </summary>
    [Cmdlet("Add", "WDResourcePermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkDocs.Model.ShareResult")]
    [AWSCmdlet("Calls the Amazon WorkDocs AddResourcePermissions API operation.", Operation = new[] {"AddResourcePermissions"})]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.ShareResult",
        "This cmdlet returns a collection of ShareResult objects.",
        "The service call response (type Amazon.WorkDocs.Model.AddResourcePermissionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddWDResourcePermissionCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. Do not set this field when using administrative
        /// API actions, as in accessing the API using AWS credentials.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter NotificationOptions_EmailMessage
        /// <summary>
        /// <para>
        /// <para>Text value to be included in the email body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NotificationOptions_EmailMessage { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The users, groups, or organization being granted permission.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Principals")]
        public Amazon.WorkDocs.Model.SharePrincipal[] Principal { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter NotificationOptions_SendEmail
        /// <summary>
        /// <para>
        /// <para>Boolean value to indicate an email notification should be sent to the receipients.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean NotificationOptions_SendEmail { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ResourceId", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-WDResourcePermission (AddResourcePermissions)"))
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
            
            context.AuthenticationToken = this.AuthenticationToken;
            context.NotificationOptions_EmailMessage = this.NotificationOptions_EmailMessage;
            if (ParameterWasBound("NotificationOptions_SendEmail"))
                context.NotificationOptions_SendEmail = this.NotificationOptions_SendEmail;
            if (this.Principal != null)
            {
                context.Principals = new List<Amazon.WorkDocs.Model.SharePrincipal>(this.Principal);
            }
            context.ResourceId = this.ResourceId;
            
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
            var request = new Amazon.WorkDocs.Model.AddResourcePermissionsRequest();
            
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            
             // populate NotificationOptions
            bool requestNotificationOptionsIsNull = true;
            request.NotificationOptions = new Amazon.WorkDocs.Model.NotificationOptions();
            System.String requestNotificationOptions_notificationOptions_EmailMessage = null;
            if (cmdletContext.NotificationOptions_EmailMessage != null)
            {
                requestNotificationOptions_notificationOptions_EmailMessage = cmdletContext.NotificationOptions_EmailMessage;
            }
            if (requestNotificationOptions_notificationOptions_EmailMessage != null)
            {
                request.NotificationOptions.EmailMessage = requestNotificationOptions_notificationOptions_EmailMessage;
                requestNotificationOptionsIsNull = false;
            }
            System.Boolean? requestNotificationOptions_notificationOptions_SendEmail = null;
            if (cmdletContext.NotificationOptions_SendEmail != null)
            {
                requestNotificationOptions_notificationOptions_SendEmail = cmdletContext.NotificationOptions_SendEmail.Value;
            }
            if (requestNotificationOptions_notificationOptions_SendEmail != null)
            {
                request.NotificationOptions.SendEmail = requestNotificationOptions_notificationOptions_SendEmail.Value;
                requestNotificationOptionsIsNull = false;
            }
             // determine if request.NotificationOptions should be set to null
            if (requestNotificationOptionsIsNull)
            {
                request.NotificationOptions = null;
            }
            if (cmdletContext.Principals != null)
            {
                request.Principals = cmdletContext.Principals;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ShareResults;
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
        
        private Amazon.WorkDocs.Model.AddResourcePermissionsResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.AddResourcePermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "AddResourcePermissions");
            try
            {
                #if DESKTOP
                return client.AddResourcePermissions(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.AddResourcePermissionsAsync(request);
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
            public System.String AuthenticationToken { get; set; }
            public System.String NotificationOptions_EmailMessage { get; set; }
            public System.Boolean? NotificationOptions_SendEmail { get; set; }
            public List<Amazon.WorkDocs.Model.SharePrincipal> Principals { get; set; }
            public System.String ResourceId { get; set; }
        }
        
    }
}
