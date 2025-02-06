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
using Amazon.ElasticFileSystem;
using Amazon.ElasticFileSystem.Model;

namespace Amazon.PowerShell.Cmdlets.EFS
{
    /// <summary>
    /// Applies an Amazon EFS <c>FileSystemPolicy</c> to an Amazon EFS file system. A file
    /// system policy is an IAM resource-based policy and can contain multiple policy statements.
    /// A file system always has exactly one file system policy, which can be the default
    /// policy or an explicit policy set or updated using this API operation. EFS file system
    /// policies have a 20,000 character limit. When an explicit policy is set, it overrides
    /// the default policy. For more information about the default file system policy, see
    /// <a href="https://docs.aws.amazon.com/efs/latest/ug/iam-access-control-nfs-efs.html#default-filesystempolicy">
    /// Default EFS file system policy</a>. 
    /// 
    ///  <note><para>
    /// EFS file system policies have a 20,000 character limit.
    /// </para></note><para>
    /// This operation requires permissions for the <c>elasticfilesystem:PutFileSystemPolicy</c>
    /// action.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "EFSFileSystemPolicy", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse")]
    [AWSCmdlet("Calls the Amazon Elastic File System PutFileSystemPolicy API operation.", Operation = new[] {"PutFileSystemPolicy"}, SelectReturnType = typeof(Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse))]
    [AWSCmdletOutput("Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse",
        "This cmdlet returns an Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse object containing multiple properties."
    )]
    public partial class WriteEFSFileSystemPolicyCmdlet : AmazonElasticFileSystemClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BypassPolicyLockoutSafetyCheck
        /// <summary>
        /// <para>
        /// <para>(Optional) A boolean that specifies whether or not to bypass the <c>FileSystemPolicy</c>
        /// lockout safety check. The lockout safety check determines whether the policy in the
        /// request will lock out, or prevent, the IAM principal that is making the request from
        /// making future <c>PutFileSystemPolicy</c> requests on this file system. Set <c>BypassPolicyLockoutSafetyCheck</c>
        /// to <c>True</c> only when you intend to prevent the IAM principal that is making the
        /// request from making subsequent <c>PutFileSystemPolicy</c> requests on this file system.
        /// The default value is <c>False</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
        #endregion
        
        #region Parameter FileSystemId
        /// <summary>
        /// <para>
        /// <para>The ID of the EFS file system that you want to create or update the <c>FileSystemPolicy</c>
        /// for.</para>
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
        public System.String FileSystemId { get; set; }
        #endregion
        
        #region Parameter Policy
        /// <summary>
        /// <para>
        /// <para>The <c>FileSystemPolicy</c> that you're creating. Accepts a JSON formatted policy
        /// definition. EFS file system policies have a 20,000 character limit. To find out more
        /// about the elements that make up a file system policy, see <a href="https://docs.aws.amazon.com/efs/latest/ug/security_iam_service-with-iam.html#security_iam_service-with-iam-resource-based-policies">Resource-based
        /// policies within Amazon EFS</a>. </para>
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
        public System.String Policy { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse).
        /// Specifying the name of a property of type Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.FileSystemId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-EFSFileSystemPolicy (PutFileSystemPolicy)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse, WriteEFSFileSystemPolicyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.BypassPolicyLockoutSafetyCheck = this.BypassPolicyLockoutSafetyCheck;
            context.FileSystemId = this.FileSystemId;
            #if MODULAR
            if (this.FileSystemId == null && ParameterWasBound(nameof(this.FileSystemId)))
            {
                WriteWarning("You are passing $null as a value for parameter FileSystemId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Policy = this.Policy;
            #if MODULAR
            if (this.Policy == null && ParameterWasBound(nameof(this.Policy)))
            {
                WriteWarning("You are passing $null as a value for parameter Policy which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticFileSystem.Model.PutFileSystemPolicyRequest();
            
            if (cmdletContext.BypassPolicyLockoutSafetyCheck != null)
            {
                request.BypassPolicyLockoutSafetyCheck = cmdletContext.BypassPolicyLockoutSafetyCheck.Value;
            }
            if (cmdletContext.FileSystemId != null)
            {
                request.FileSystemId = cmdletContext.FileSystemId;
            }
            if (cmdletContext.Policy != null)
            {
                request.Policy = cmdletContext.Policy;
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
        
        private Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse CallAWSServiceOperation(IAmazonElasticFileSystem client, Amazon.ElasticFileSystem.Model.PutFileSystemPolicyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic File System", "PutFileSystemPolicy");
            try
            {
                #if DESKTOP
                return client.PutFileSystemPolicy(request);
                #elif CORECLR
                return client.PutFileSystemPolicyAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? BypassPolicyLockoutSafetyCheck { get; set; }
            public System.String FileSystemId { get; set; }
            public System.String Policy { get; set; }
            public System.Func<Amazon.ElasticFileSystem.Model.PutFileSystemPolicyResponse, WriteEFSFileSystemPolicyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
