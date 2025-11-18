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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// Creates an IAM delegation request for temporary access delegation.
    /// 
    ///  
    /// <para>
    /// This API is not available for general use. In order to use this API, a caller first
    /// need to go through an onboarding process described in the <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies-temporary-delegation-partner-guide.html">partner
    /// onboarding documentation</a>. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "IAMDelegationRequest", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IdentityManagement.Model.CreateDelegationRequestResponse")]
    [AWSCmdlet("Calls the AWS Identity and Access Management CreateDelegationRequest API operation.", Operation = new[] {"CreateDelegationRequest"}, SelectReturnType = typeof(Amazon.IdentityManagement.Model.CreateDelegationRequestResponse))]
    [AWSCmdletOutput("Amazon.IdentityManagement.Model.CreateDelegationRequestResponse",
        "This cmdlet returns an Amazon.IdentityManagement.Model.CreateDelegationRequestResponse object containing multiple properties."
    )]
    public partial class NewIAMDelegationRequestCmdlet : AmazonIdentityManagementServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the delegation request.</para>
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
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter NotificationChannel
        /// <summary>
        /// <para>
        /// <para>The notification channel for updates about the delegation request.</para><para>At this time,only SNS topic ARNs are accepted for notification. This topic ARN must
        /// have a resource policy granting <c>SNS:Publish</c> permission to the IAM service principal
        /// (<c>iam.amazonaws.com</c>). See <a href="https://docs.aws.amazon.com/IAM/latest/UserGuide/access_policies-temporary-delegation-partner-guide.html">partner
        /// onboarding documentation</a> for more details. </para>
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
        public System.String NotificationChannel { get; set; }
        #endregion
        
        #region Parameter OnlySendByOwner
        /// <summary>
        /// <para>
        /// <para>Specifies whether the delegation token should only be sent by the owner.</para><para>This flag prevents any party other than the owner from calling <c>SendDelegationToken</c>
        /// API for this delegation request. This behavior becomes useful when the delegation
        /// request owner needs to be present for subsequent partner interactions, but the delegation
        /// request was sent to a more privileged user for approval due to the owner lacking sufficient
        /// delegation permissions. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OnlySendByOwner { get; set; }
        #endregion
        
        #region Parameter OwnerAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID this delegation request is targeted to.</para><para>If the account ID is not known, this parameter can be omitted, resulting in a request
        /// that can be associated by any account. If the account ID passed, then the created
        /// delegation request can only be associated with an identity of that target account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerAccountId { get; set; }
        #endregion
        
        #region Parameter Permissions_Parameter
        /// <summary>
        /// <para>
        /// <para>A list of policy parameters that define the scope and constraints of the delegated
        /// permissions.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions_Parameters")]
        public Amazon.IdentityManagement.Model.PolicyParameter[] Permissions_Parameter { get; set; }
        #endregion
        
        #region Parameter Permissions_PolicyTemplateArn
        /// <summary>
        /// <para>
        /// <para>This ARN maps to a pre-registered policy content for this partner. See the <a href="">partner
        /// onboarding documentation</a> to understand how to create a delegation template.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Permissions_PolicyTemplateArn { get; set; }
        #endregion
        
        #region Parameter RedirectUrl
        /// <summary>
        /// <para>
        /// <para>The URL to redirect to after the delegation request is processed.</para><para>This URL is used by the IAM console to show a link to the customer to re-load the
        /// partner workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedirectUrl { get; set; }
        #endregion
        
        #region Parameter RequestMessage
        /// <summary>
        /// <para>
        /// <para>A message explaining the reason for the delegation request.</para><para>Requesters can utilize this field to add a custom note to the delegation request.
        /// This field is different from the description such that this is to be utilized for
        /// a custom messaging on a case-by-case basis.</para><para>For example, if the current delegation request is in response to a previous request
        /// being rejected, this explanation can be added to the request via this field.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestMessage { get; set; }
        #endregion
        
        #region Parameter RequestorWorkflowId
        /// <summary>
        /// <para>
        /// <para>The workflow ID associated with the requestor.</para><para>This is the unique identifier on the partner side that can be used to track the progress
        /// of the request.</para><para>IAM maintains a uniqueness check on this workflow id for each request - if a workflow
        /// id for an existing request is passed, this API call will fail.</para>
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
        public System.String RequestorWorkflowId { get; set; }
        #endregion
        
        #region Parameter SessionDuration
        /// <summary>
        /// <para>
        /// <para>The duration for which the delegated session should remain active, in seconds.</para><para>The active time window for the session starts when the customer calls the <a href="https://docs.aws.amazon.com/IAM/latest/APIReference/API_SendDelegationToken.html">SendDelegationToken</a>
        /// API.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? SessionDuration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IdentityManagement.Model.CreateDelegationRequestResponse).
        /// Specifying the name of a property of type Amazon.IdentityManagement.Model.CreateDelegationRequestResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RequestorWorkflowId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IAMDelegationRequest (CreateDelegationRequest)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IdentityManagement.Model.CreateDelegationRequestResponse, NewIAMDelegationRequestCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            #if MODULAR
            if (this.Description == null && ParameterWasBound(nameof(this.Description)))
            {
                WriteWarning("You are passing $null as a value for parameter Description which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NotificationChannel = this.NotificationChannel;
            #if MODULAR
            if (this.NotificationChannel == null && ParameterWasBound(nameof(this.NotificationChannel)))
            {
                WriteWarning("You are passing $null as a value for parameter NotificationChannel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OnlySendByOwner = this.OnlySendByOwner;
            context.OwnerAccountId = this.OwnerAccountId;
            if (this.Permissions_Parameter != null)
            {
                context.Permissions_Parameter = new List<Amazon.IdentityManagement.Model.PolicyParameter>(this.Permissions_Parameter);
            }
            context.Permissions_PolicyTemplateArn = this.Permissions_PolicyTemplateArn;
            context.RedirectUrl = this.RedirectUrl;
            context.RequestMessage = this.RequestMessage;
            context.RequestorWorkflowId = this.RequestorWorkflowId;
            #if MODULAR
            if (this.RequestorWorkflowId == null && ParameterWasBound(nameof(this.RequestorWorkflowId)))
            {
                WriteWarning("You are passing $null as a value for parameter RequestorWorkflowId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SessionDuration = this.SessionDuration;
            #if MODULAR
            if (this.SessionDuration == null && ParameterWasBound(nameof(this.SessionDuration)))
            {
                WriteWarning("You are passing $null as a value for parameter SessionDuration which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.IdentityManagement.Model.CreateDelegationRequestRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.NotificationChannel != null)
            {
                request.NotificationChannel = cmdletContext.NotificationChannel;
            }
            if (cmdletContext.OnlySendByOwner != null)
            {
                request.OnlySendByOwner = cmdletContext.OnlySendByOwner.Value;
            }
            if (cmdletContext.OwnerAccountId != null)
            {
                request.OwnerAccountId = cmdletContext.OwnerAccountId;
            }
            
             // populate Permissions
            var requestPermissionsIsNull = true;
            request.Permissions = new Amazon.IdentityManagement.Model.DelegationPermission();
            List<Amazon.IdentityManagement.Model.PolicyParameter> requestPermissions_permissions_Parameter = null;
            if (cmdletContext.Permissions_Parameter != null)
            {
                requestPermissions_permissions_Parameter = cmdletContext.Permissions_Parameter;
            }
            if (requestPermissions_permissions_Parameter != null)
            {
                request.Permissions.Parameters = requestPermissions_permissions_Parameter;
                requestPermissionsIsNull = false;
            }
            System.String requestPermissions_permissions_PolicyTemplateArn = null;
            if (cmdletContext.Permissions_PolicyTemplateArn != null)
            {
                requestPermissions_permissions_PolicyTemplateArn = cmdletContext.Permissions_PolicyTemplateArn;
            }
            if (requestPermissions_permissions_PolicyTemplateArn != null)
            {
                request.Permissions.PolicyTemplateArn = requestPermissions_permissions_PolicyTemplateArn;
                requestPermissionsIsNull = false;
            }
             // determine if request.Permissions should be set to null
            if (requestPermissionsIsNull)
            {
                request.Permissions = null;
            }
            if (cmdletContext.RedirectUrl != null)
            {
                request.RedirectUrl = cmdletContext.RedirectUrl;
            }
            if (cmdletContext.RequestMessage != null)
            {
                request.RequestMessage = cmdletContext.RequestMessage;
            }
            if (cmdletContext.RequestorWorkflowId != null)
            {
                request.RequestorWorkflowId = cmdletContext.RequestorWorkflowId;
            }
            if (cmdletContext.SessionDuration != null)
            {
                request.SessionDuration = cmdletContext.SessionDuration.Value;
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
        
        private Amazon.IdentityManagement.Model.CreateDelegationRequestResponse CallAWSServiceOperation(IAmazonIdentityManagementService client, Amazon.IdentityManagement.Model.CreateDelegationRequestRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Identity and Access Management", "CreateDelegationRequest");
            try
            {
                return client.CreateDelegationRequestAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String NotificationChannel { get; set; }
            public System.Boolean? OnlySendByOwner { get; set; }
            public System.String OwnerAccountId { get; set; }
            public List<Amazon.IdentityManagement.Model.PolicyParameter> Permissions_Parameter { get; set; }
            public System.String Permissions_PolicyTemplateArn { get; set; }
            public System.String RedirectUrl { get; set; }
            public System.String RequestMessage { get; set; }
            public System.String RequestorWorkflowId { get; set; }
            public System.Int32? SessionDuration { get; set; }
            public System.Func<Amazon.IdentityManagement.Model.CreateDelegationRequestResponse, NewIAMDelegationRequestCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
