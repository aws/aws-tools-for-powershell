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
using Amazon.SSOAdmin;
using Amazon.SSOAdmin.Model;

namespace Amazon.PowerShell.Cmdlets.SSOADMN
{
    /// <summary>
    /// Assigns access to a principal for a specified Amazon Web Services account using a
    /// specified permission set.
    /// 
    ///  <note><para>
    /// The term <i>principal</i> here refers to a user or group that is defined in IAM Identity
    /// Center.
    /// </para></note><note><para>
    /// As part of a successful <c>CreateAccountAssignment</c> call, the specified permission
    /// set will automatically be provisioned to the account in the form of an IAM policy.
    /// That policy is attached to the IAM role created in IAM Identity Center. If the permission
    /// set is subsequently updated, the corresponding IAM policies attached to roles in your
    /// accounts will not be updated automatically. In this case, you must call <c><a>ProvisionPermissionSet</a></c> to make these updates.
    /// </para></note><note><para>
    ///  After a successful response, call <c>DescribeAccountAssignmentCreationStatus</c>
    /// to describe the status of an assignment creation request. 
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "SSOADMNAccountAssignment", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.SSOAdmin.Model.AccountAssignmentOperationStatus")]
    [AWSCmdlet("Calls the AWS Single Sign-On Admin CreateAccountAssignment API operation.", Operation = new[] {"CreateAccountAssignment"}, SelectReturnType = typeof(Amazon.SSOAdmin.Model.CreateAccountAssignmentResponse))]
    [AWSCmdletOutput("Amazon.SSOAdmin.Model.AccountAssignmentOperationStatus or Amazon.SSOAdmin.Model.CreateAccountAssignmentResponse",
        "This cmdlet returns an Amazon.SSOAdmin.Model.AccountAssignmentOperationStatus object.",
        "The service call response (type Amazon.SSOAdmin.Model.CreateAccountAssignmentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewSSOADMNAccountAssignmentCmdlet : AmazonSSOAdminClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter InstanceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM Identity Center instance under which the operation will be executed.
        /// For more information about ARNs, see <a href="/general/latest/gr/aws-arns-and-namespaces.html">Amazon
        /// Resource Names (ARNs) and Amazon Web Services Service Namespaces</a> in the <i>Amazon
        /// Web Services General Reference</i>.</para>
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
        public System.String InstanceArn { get; set; }
        #endregion
        
        #region Parameter PermissionSetArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the permission set that the admin wants to grant the principal access to.</para>
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
        public System.String PermissionSetArn { get; set; }
        #endregion
        
        #region Parameter PrincipalId
        /// <summary>
        /// <para>
        /// <para>An identifier for an object in IAM Identity Center, such as a user or group. PrincipalIds
        /// are GUIDs (For example, f81d4fae-7dec-11d0-a765-00a0c91e6bf6). For more information
        /// about PrincipalIds in IAM Identity Center, see the <a href="/singlesignon/latest/IdentityStoreAPIReference/welcome.html">IAM
        /// Identity Center Identity Store API Reference</a>.</para>
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
        public System.String PrincipalId { get; set; }
        #endregion
        
        #region Parameter PrincipalType
        /// <summary>
        /// <para>
        /// <para>The entity type for which the assignment will be created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SSOAdmin.PrincipalType")]
        public Amazon.SSOAdmin.PrincipalType PrincipalType { get; set; }
        #endregion
        
        #region Parameter TargetId
        /// <summary>
        /// <para>
        /// <para>TargetID is an Amazon Web Services account identifier, (For example, 123456789012).</para>
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
        public System.String TargetId { get; set; }
        #endregion
        
        #region Parameter TargetType
        /// <summary>
        /// <para>
        /// <para>The entity type for which the assignment will be created.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SSOAdmin.TargetType")]
        public Amazon.SSOAdmin.TargetType TargetType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'AccountAssignmentCreationStatus'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SSOAdmin.Model.CreateAccountAssignmentResponse).
        /// Specifying the name of a property of type Amazon.SSOAdmin.Model.CreateAccountAssignmentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "AccountAssignmentCreationStatus";
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-SSOADMNAccountAssignment (CreateAccountAssignment)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SSOAdmin.Model.CreateAccountAssignmentResponse, NewSSOADMNAccountAssignmentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.InstanceArn = this.InstanceArn;
            #if MODULAR
            if (this.InstanceArn == null && ParameterWasBound(nameof(this.InstanceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PermissionSetArn = this.PermissionSetArn;
            #if MODULAR
            if (this.PermissionSetArn == null && ParameterWasBound(nameof(this.PermissionSetArn)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionSetArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalId = this.PrincipalId;
            #if MODULAR
            if (this.PrincipalId == null && ParameterWasBound(nameof(this.PrincipalId)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PrincipalType = this.PrincipalType;
            #if MODULAR
            if (this.PrincipalType == null && ParameterWasBound(nameof(this.PrincipalType)))
            {
                WriteWarning("You are passing $null as a value for parameter PrincipalType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetId = this.TargetId;
            #if MODULAR
            if (this.TargetId == null && ParameterWasBound(nameof(this.TargetId)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetType = this.TargetType;
            #if MODULAR
            if (this.TargetType == null && ParameterWasBound(nameof(this.TargetType)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SSOAdmin.Model.CreateAccountAssignmentRequest();
            
            if (cmdletContext.InstanceArn != null)
            {
                request.InstanceArn = cmdletContext.InstanceArn;
            }
            if (cmdletContext.PermissionSetArn != null)
            {
                request.PermissionSetArn = cmdletContext.PermissionSetArn;
            }
            if (cmdletContext.PrincipalId != null)
            {
                request.PrincipalId = cmdletContext.PrincipalId;
            }
            if (cmdletContext.PrincipalType != null)
            {
                request.PrincipalType = cmdletContext.PrincipalType;
            }
            if (cmdletContext.TargetId != null)
            {
                request.TargetId = cmdletContext.TargetId;
            }
            if (cmdletContext.TargetType != null)
            {
                request.TargetType = cmdletContext.TargetType;
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
        
        private Amazon.SSOAdmin.Model.CreateAccountAssignmentResponse CallAWSServiceOperation(IAmazonSSOAdmin client, Amazon.SSOAdmin.Model.CreateAccountAssignmentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Single Sign-On Admin", "CreateAccountAssignment");
            try
            {
                return client.CreateAccountAssignmentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String InstanceArn { get; set; }
            public System.String PermissionSetArn { get; set; }
            public System.String PrincipalId { get; set; }
            public Amazon.SSOAdmin.PrincipalType PrincipalType { get; set; }
            public System.String TargetId { get; set; }
            public Amazon.SSOAdmin.TargetType TargetType { get; set; }
            public System.Func<Amazon.SSOAdmin.Model.CreateAccountAssignmentResponse, NewSSOADMNAccountAssignmentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.AccountAssignmentCreationStatus;
        }
        
    }
}
