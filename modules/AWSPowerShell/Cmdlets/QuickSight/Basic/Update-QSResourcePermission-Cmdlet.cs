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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates the service role configuration that Amazon Quick Sight uses to access resources
    /// in your Amazon Web Services account. To use this operation, you must have the <c>quicksight:UpdateResourcePermissions</c>
    /// and <c>iam:PassRole</c> permissions.
    /// 
    ///  
    /// <para>
    /// Call this operation in the Amazon Web Services Region where your Amazon Quick Sight
    /// account is registered (the home Region). You can switch from a role managed by Amazon
    /// Quick Sight to a customer-managed role, or replace one customer-managed role with
    /// another. You can't use this operation to switch back to a role managed by Amazon Quick
    /// Sight.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "QSResourcePermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateResourcePermissionsResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateResourcePermissions API operation.", Operation = new[] {"UpdateResourcePermissions"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateResourcePermissionsResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateResourcePermissionsResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateResourcePermissionsResponse object containing multiple properties."
    )]
    public partial class UpdateQSResourcePermissionCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon Web Services account whose service role configuration you want
        /// to update.</para>
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
        public System.String AwsAccountId { get; set; }
        #endregion
        
        #region Parameter CustomerManagedRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the customer-managed role that you want Amazon Quick Sight to use. To use
        /// this operation, you must have the <c>iam:PassRole</c> permission for the role.</para><para>Configure the role as follows:</para><ul><li><para>The role must belong to the Amazon Web Services account specified by <c>AwsAccountId</c>.</para></li><li><para>Configure the role trust policy to allow the Amazon Quick Sight service principal
        /// to call <c>sts:AssumeRole</c>.</para></li><li><para>Attach a permissions policy that allows access to the resources that you want Amazon
        /// Quick Sight to use.</para></li><li><para>To use features that rely on session tags, configure the role trust policy to allow
        /// the Amazon Quick Sight service principal to call <c>sts:TagSession</c>.</para></li></ul><para>If the role doesn't exist or its trust policy doesn't allow <c>sts:AssumeRole</c>,
        /// the request returns an <c>AccessDeniedException</c>.</para><para>When you call this operation, Amazon Quick Sight attempts to assume the role with
        /// session tags and records whether the attempt succeeds. If you later add or remove
        /// <c>sts:TagSession</c> from the trust policy, call this operation again with the same
        /// role ARN to refresh the stored capability.</para>
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
        public System.String CustomerManagedRoleArn { get; set; }
        #endregion
        
        #region Parameter RoleType
        /// <summary>
        /// <para>
        /// <para>The type of service role that you want Amazon Quick Sight to use. The only supported
        /// value for this operation is <c>CUSTOMER_MANAGED</c>. Requests that specify <c>QUICKSIGHT_MANAGED</c>
        /// are rejected.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.QuickSight.ServiceRoleType")]
        public Amazon.QuickSight.ServiceRoleType RoleType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateResourcePermissionsResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateResourcePermissionsResponse will result in that property being returned.
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
                nameof(this.AwsAccountId),
                nameof(this.CustomerManagedRoleArn)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSResourcePermission (UpdateResourcePermissions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateResourcePermissionsResponse, UpdateQSResourcePermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CustomerManagedRoleArn = this.CustomerManagedRoleArn;
            #if MODULAR
            if (this.CustomerManagedRoleArn == null && ParameterWasBound(nameof(this.CustomerManagedRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter CustomerManagedRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleType = this.RoleType;
            #if MODULAR
            if (this.RoleType == null && ParameterWasBound(nameof(this.RoleType)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.QuickSight.Model.UpdateResourcePermissionsRequest();
            
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.CustomerManagedRoleArn != null)
            {
                request.CustomerManagedRoleArn = cmdletContext.CustomerManagedRoleArn;
            }
            if (cmdletContext.RoleType != null)
            {
                request.RoleType = cmdletContext.RoleType;
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
        
        private Amazon.QuickSight.Model.UpdateResourcePermissionsResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateResourcePermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateResourcePermissions");
            try
            {
                return client.UpdateResourcePermissionsAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AwsAccountId { get; set; }
            public System.String CustomerManagedRoleArn { get; set; }
            public Amazon.QuickSight.ServiceRoleType RoleType { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateResourcePermissionsResponse, UpdateQSResourcePermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
