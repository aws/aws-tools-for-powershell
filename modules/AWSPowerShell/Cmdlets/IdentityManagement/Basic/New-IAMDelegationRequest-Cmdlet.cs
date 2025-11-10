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
using Amazon.IdentityManagement;
using Amazon.IdentityManagement.Model;

namespace Amazon.PowerShell.Cmdlets.IAM
{
    /// <summary>
    /// This API is currently unavailable for general use.
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
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? OnlySendByOwner { get; set; }
        #endregion
        
        #region Parameter OwnerAccountId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OwnerAccountId { get; set; }
        #endregion
        
        #region Parameter Permissions_Parameter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Permissions_Parameters")]
        public Amazon.IdentityManagement.Model.PolicyParameter[] Permissions_Parameter { get; set; }
        #endregion
        
        #region Parameter Permissions_PolicyTemplateArn
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Permissions_PolicyTemplateArn { get; set; }
        #endregion
        
        #region Parameter RedirectUrl
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RedirectUrl { get; set; }
        #endregion
        
        #region Parameter RequestMessage
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RequestMessage { get; set; }
        #endregion
        
        #region Parameter RequestorWorkflowId
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
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
                #if DESKTOP
                return client.CreateDelegationRequest(request);
                #elif CORECLR
                return client.CreateDelegationRequestAsync(request).GetAwaiter().GetResult();
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
