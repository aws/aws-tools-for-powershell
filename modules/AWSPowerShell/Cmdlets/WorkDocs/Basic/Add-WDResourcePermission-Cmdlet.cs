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
    [AWSCmdlet("Calls the Amazon WorkDocs AddResourcePermissions API operation.", Operation = new[] {"AddResourcePermissions"}, SelectReturnType = typeof(Amazon.WorkDocs.Model.AddResourcePermissionsResponse))]
    [AWSCmdletOutput("Amazon.WorkDocs.Model.ShareResult or Amazon.WorkDocs.Model.AddResourcePermissionsResponse",
        "This cmdlet returns a collection of Amazon.WorkDocs.Model.ShareResult objects.",
        "The service call response (type Amazon.WorkDocs.Model.AddResourcePermissionsResponse) can be returned by specifying '-Select *'."
    )]
    public partial class AddWDResourcePermissionCmdlet : AmazonWorkDocsClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsSensitiveResponse { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AuthenticationToken
        /// <summary>
        /// <para>
        /// <para>Amazon WorkDocs authentication token. Not required when using Amazon Web Services
        /// administrator credentials to access the API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AuthenticationToken { get; set; }
        #endregion
        
        #region Parameter NotificationOptions_EmailMessage
        /// <summary>
        /// <para>
        /// <para>Text value to be included in the email body.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NotificationOptions_EmailMessage { get; set; }
        #endregion
        
        #region Parameter Principal
        /// <summary>
        /// <para>
        /// <para>The users, groups, or organization being granted permission.</para>
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
        [Alias("Principals")]
        public Amazon.WorkDocs.Model.SharePrincipal[] Principal { get; set; }
        #endregion
        
        #region Parameter ResourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the resource.</para>
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
        public System.String ResourceId { get; set; }
        #endregion
        
        #region Parameter NotificationOptions_SendEmail
        /// <summary>
        /// <para>
        /// <para>Boolean value to indicate an email notification should be sent to the recipients.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? NotificationOptions_SendEmail { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ShareResults'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkDocs.Model.AddResourcePermissionsResponse).
        /// Specifying the name of a property of type Amazon.WorkDocs.Model.AddResourcePermissionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ShareResults";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ResourceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ResourceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ResourceId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ResourceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-WDResourcePermission (AddResourcePermissions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkDocs.Model.AddResourcePermissionsResponse, AddWDResourcePermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ResourceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AuthenticationToken = this.AuthenticationToken;
            context.NotificationOptions_EmailMessage = this.NotificationOptions_EmailMessage;
            context.NotificationOptions_SendEmail = this.NotificationOptions_SendEmail;
            if (this.Principal != null)
            {
                context.Principal = new List<Amazon.WorkDocs.Model.SharePrincipal>(this.Principal);
            }
            #if MODULAR
            if (this.Principal == null && ParameterWasBound(nameof(this.Principal)))
            {
                WriteWarning("You are passing $null as a value for parameter Principal which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourceId = this.ResourceId;
            #if MODULAR
            if (this.ResourceId == null && ParameterWasBound(nameof(this.ResourceId)))
            {
                WriteWarning("You are passing $null as a value for parameter ResourceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkDocs.Model.AddResourcePermissionsRequest();
            
            if (cmdletContext.AuthenticationToken != null)
            {
                request.AuthenticationToken = cmdletContext.AuthenticationToken;
            }
            
             // populate NotificationOptions
            var requestNotificationOptionsIsNull = true;
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
            if (cmdletContext.Principal != null)
            {
                request.Principals = cmdletContext.Principal;
            }
            if (cmdletContext.ResourceId != null)
            {
                request.ResourceId = cmdletContext.ResourceId;
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
        
        private Amazon.WorkDocs.Model.AddResourcePermissionsResponse CallAWSServiceOperation(IAmazonWorkDocs client, Amazon.WorkDocs.Model.AddResourcePermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkDocs", "AddResourcePermissions");
            try
            {
                #if DESKTOP
                return client.AddResourcePermissions(request);
                #elif CORECLR
                return client.AddResourcePermissionsAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.WorkDocs.Model.SharePrincipal> Principal { get; set; }
            public System.String ResourceId { get; set; }
            public System.Func<Amazon.WorkDocs.Model.AddResourcePermissionsResponse, AddWDResourcePermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ShareResults;
        }
        
    }
}
