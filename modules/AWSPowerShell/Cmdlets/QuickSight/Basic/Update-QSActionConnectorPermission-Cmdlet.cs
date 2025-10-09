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
using Amazon.QuickSight;
using Amazon.QuickSight.Model;

namespace Amazon.PowerShell.Cmdlets.QS
{
    /// <summary>
    /// Updates the permissions for an action connector by granting or revoking access for
    /// specific users and groups. You can control who can view, use, or manage the action
    /// connector.
    /// </summary>
    [Cmdlet("Update", "QSActionConnectorPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse")]
    [AWSCmdlet("Calls the Amazon QuickSight UpdateActionConnectorPermissions API operation.", Operation = new[] {"UpdateActionConnectorPermissions"}, SelectReturnType = typeof(Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse))]
    [AWSCmdletOutput("Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse",
        "This cmdlet returns an Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse object containing multiple properties."
    )]
    public partial class UpdateQSActionConnectorPermissionCmdlet : AmazonQuickSightClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ActionConnectorId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the action connector whose permissions you want to update.</para>
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
        public System.String ActionConnectorId { get; set; }
        #endregion
        
        #region Parameter AwsAccountId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID that contains the action connector.</para>
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
        
        #region Parameter GrantPermission
        /// <summary>
        /// <para>
        /// <para>The permissions to grant to users and groups for this action connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GrantPermissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] GrantPermission { get; set; }
        #endregion
        
        #region Parameter RevokePermission
        /// <summary>
        /// <para>
        /// <para>The permissions to revoke from users and groups for this action connector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RevokePermissions")]
        public Amazon.QuickSight.Model.ResourcePermission[] RevokePermission { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse).
        /// Specifying the name of a property of type Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse will result in that property being returned.
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
            
            var targetParameterNames = new string[]
            {
                nameof(this.ActionConnectorId),
                nameof(this.AwsAccountId)
            };
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(targetParameterNames, MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-QSActionConnectorPermission (UpdateActionConnectorPermissions)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse, UpdateQSActionConnectorPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ActionConnectorId = this.ActionConnectorId;
            #if MODULAR
            if (this.ActionConnectorId == null && ParameterWasBound(nameof(this.ActionConnectorId)))
            {
                WriteWarning("You are passing $null as a value for parameter ActionConnectorId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AwsAccountId = this.AwsAccountId;
            #if MODULAR
            if (this.AwsAccountId == null && ParameterWasBound(nameof(this.AwsAccountId)))
            {
                WriteWarning("You are passing $null as a value for parameter AwsAccountId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.GrantPermission != null)
            {
                context.GrantPermission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.GrantPermission);
            }
            if (this.RevokePermission != null)
            {
                context.RevokePermission = new List<Amazon.QuickSight.Model.ResourcePermission>(this.RevokePermission);
            }
            
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
            var request = new Amazon.QuickSight.Model.UpdateActionConnectorPermissionsRequest();
            
            if (cmdletContext.ActionConnectorId != null)
            {
                request.ActionConnectorId = cmdletContext.ActionConnectorId;
            }
            if (cmdletContext.AwsAccountId != null)
            {
                request.AwsAccountId = cmdletContext.AwsAccountId;
            }
            if (cmdletContext.GrantPermission != null)
            {
                request.GrantPermissions = cmdletContext.GrantPermission;
            }
            if (cmdletContext.RevokePermission != null)
            {
                request.RevokePermissions = cmdletContext.RevokePermission;
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
        
        private Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse CallAWSServiceOperation(IAmazonQuickSight client, Amazon.QuickSight.Model.UpdateActionConnectorPermissionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon QuickSight", "UpdateActionConnectorPermissions");
            try
            {
                #if DESKTOP
                return client.UpdateActionConnectorPermissions(request);
                #elif CORECLR
                return client.UpdateActionConnectorPermissionsAsync(request).GetAwaiter().GetResult();
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
            public System.String ActionConnectorId { get; set; }
            public System.String AwsAccountId { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> GrantPermission { get; set; }
            public List<Amazon.QuickSight.Model.ResourcePermission> RevokePermission { get; set; }
            public System.Func<Amazon.QuickSight.Model.UpdateActionConnectorPermissionsResponse, UpdateQSActionConnectorPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
