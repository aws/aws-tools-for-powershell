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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Creates a new user profile.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have an attached
    /// policy that explicitly grants permissions. For more information about user permissions,
    /// see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "OPSUserProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS OpsWorks CreateUserProfile API operation.", Operation = new[] {"CreateUserProfile"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.CreateUserProfileResponse))]
    [AWSCmdletOutput("System.String or Amazon.OpsWorks.Model.CreateUserProfileResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.OpsWorks.Model.CreateUserProfileResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOPSUserProfileCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AllowSelfManagement
        /// <summary>
        /// <para>
        /// <para>Whether users can specify their own SSH public key through the My Settings page. For
        /// more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/security-settingsshkey.html">Setting
        /// an IAM User's Public SSH Key</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowSelfManagement { get; set; }
        #endregion
        
        #region Parameter IamUserArn
        /// <summary>
        /// <para>
        /// <para>The user's IAM ARN; this can also be a federated user's ARN.</para>
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
        public System.String IamUserArn { get; set; }
        #endregion
        
        #region Parameter SshPublicKey
        /// <summary>
        /// <para>
        /// <para>The user's public SSH key.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String SshPublicKey { get; set; }
        #endregion
        
        #region Parameter SshUsername
        /// <summary>
        /// <para>
        /// <para>The user's SSH user name. The allowable characters are [a-z], [A-Z], [0-9], '-', and
        /// '_'. If the specified name includes other punctuation marks, OpsWorks Stacks removes
        /// them. For example, <c>my.name</c> is changed to <c>myname</c>. If you do not specify
        /// an SSH user name, OpsWorks Stacks generates one from the IAM user name. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String SshUsername { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'IamUserArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.CreateUserProfileResponse).
        /// Specifying the name of a property of type Amazon.OpsWorks.Model.CreateUserProfileResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "IamUserArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IamUserArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OPSUserProfile (CreateUserProfile)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.CreateUserProfileResponse, NewOPSUserProfileCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AllowSelfManagement = this.AllowSelfManagement;
            context.IamUserArn = this.IamUserArn;
            #if MODULAR
            if (this.IamUserArn == null && ParameterWasBound(nameof(this.IamUserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamUserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SshPublicKey = this.SshPublicKey;
            context.SshUsername = this.SshUsername;
            
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
            var request = new Amazon.OpsWorks.Model.CreateUserProfileRequest();
            
            if (cmdletContext.AllowSelfManagement != null)
            {
                request.AllowSelfManagement = cmdletContext.AllowSelfManagement.Value;
            }
            if (cmdletContext.IamUserArn != null)
            {
                request.IamUserArn = cmdletContext.IamUserArn;
            }
            if (cmdletContext.SshPublicKey != null)
            {
                request.SshPublicKey = cmdletContext.SshPublicKey;
            }
            if (cmdletContext.SshUsername != null)
            {
                request.SshUsername = cmdletContext.SshUsername;
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
        
        private Amazon.OpsWorks.Model.CreateUserProfileResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.CreateUserProfileRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "CreateUserProfile");
            try
            {
                return client.CreateUserProfileAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AllowSelfManagement { get; set; }
            public System.String IamUserArn { get; set; }
            public System.String SshPublicKey { get; set; }
            public System.String SshUsername { get; set; }
            public System.Func<Amazon.OpsWorks.Model.CreateUserProfileResponse, NewOPSUserProfileCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.IamUserArn;
        }
        
    }
}
