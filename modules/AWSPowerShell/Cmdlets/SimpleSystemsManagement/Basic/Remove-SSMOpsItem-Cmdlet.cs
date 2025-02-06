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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Delete an OpsItem. You must have permission in Identity and Access Management (IAM)
    /// to delete an OpsItem. 
    /// 
    ///  <important><para>
    /// Note the following important information about this operation.
    /// </para><ul><li><para>
    /// Deleting an OpsItem is irreversible. You can't restore a deleted OpsItem.
    /// </para></li><li><para>
    /// This operation uses an <i>eventual consistency model</i>, which means the system can
    /// take a few minutes to complete this operation. If you delete an OpsItem and immediately
    /// call, for example, <a>GetOpsItem</a>, the deleted OpsItem might still appear in the
    /// response. 
    /// </para></li><li><para>
    /// This operation is idempotent. The system doesn't throw an exception if you repeatedly
    /// call this operation for the same OpsItem. If the first call is successful, all additional
    /// calls return the same successful response as the first call.
    /// </para></li><li><para>
    /// This operation doesn't support cross-account calls. A delegated administrator or management
    /// account can't delete OpsItems in other accounts, even if OpsCenter has been set up
    /// for cross-account administration. For more information about cross-account administration,
    /// see <a href="https://docs.aws.amazon.com/systems-manager/latest/userguide/OpsCenter-setting-up-cross-account.html">Setting
    /// up OpsCenter to centrally manage OpsItems across accounts</a> in the <i>Systems Manager
    /// User Guide</i>.
    /// </para></li></ul></important>
    /// </summary>
    [Cmdlet("Remove", "SSMOpsItem", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager DeleteOpsItem API operation.", Operation = new[] {"DeleteOpsItem"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.DeleteOpsItemResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleSystemsManagement.Model.DeleteOpsItemResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleSystemsManagement.Model.DeleteOpsItemResponse) be returned by specifying '-Select *'."
    )]
    public partial class RemoveSSMOpsItemCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter OpsItemId
        /// <summary>
        /// <para>
        /// <para>The ID of the OpsItem that you want to delete.</para>
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
        public System.String OpsItemId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.DeleteOpsItemResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OpsItemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-SSMOpsItem (DeleteOpsItem)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.DeleteOpsItemResponse, RemoveSSMOpsItemCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.OpsItemId = this.OpsItemId;
            #if MODULAR
            if (this.OpsItemId == null && ParameterWasBound(nameof(this.OpsItemId)))
            {
                WriteWarning("You are passing $null as a value for parameter OpsItemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.DeleteOpsItemRequest();
            
            if (cmdletContext.OpsItemId != null)
            {
                request.OpsItemId = cmdletContext.OpsItemId;
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
        
        private Amazon.SimpleSystemsManagement.Model.DeleteOpsItemResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.DeleteOpsItemRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "DeleteOpsItem");
            try
            {
                #if DESKTOP
                return client.DeleteOpsItem(request);
                #elif CORECLR
                return client.DeleteOpsItemAsync(request).GetAwaiter().GetResult();
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
            public System.String OpsItemId { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.DeleteOpsItemResponse, RemoveSSMOpsItemCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
