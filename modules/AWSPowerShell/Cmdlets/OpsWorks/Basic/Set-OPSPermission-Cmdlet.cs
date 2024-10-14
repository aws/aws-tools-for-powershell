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
using Amazon.OpsWorks;
using Amazon.OpsWorks.Model;

namespace Amazon.PowerShell.Cmdlets.OPS
{
    /// <summary>
    /// Specifies a user's permissions. For more information, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/workingsecurity.html">Security
    /// and Permissions</a>.
    /// 
    ///  
    /// <para><b>Required Permissions</b>: To use this action, an IAM user must have a Manage permissions
    /// level for the stack, or an attached policy that explicitly grants permissions. For
    /// more information on user permissions, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
    /// User Permissions</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Set", "OPSPermission", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS OpsWorks SetPermission API operation.", Operation = new[] {"SetPermission"}, SelectReturnType = typeof(Amazon.OpsWorks.Model.SetPermissionResponse))]
    [AWSCmdletOutput("None or Amazon.OpsWorks.Model.SetPermissionResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.OpsWorks.Model.SetPermissionResponse) be returned by specifying '-Select *'."
    )]
    public partial class SetOPSPermissionCmdlet : AmazonOpsWorksClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AllowSsh
        /// <summary>
        /// <para>
        /// <para>The user is allowed to use SSH to communicate with the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowSsh { get; set; }
        #endregion
        
        #region Parameter AllowSudo
        /// <summary>
        /// <para>
        /// <para>The user is allowed to use <b>sudo</b> to elevate privileges.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 3, ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AllowSudo { get; set; }
        #endregion
        
        #region Parameter IamUserArn
        /// <summary>
        /// <para>
        /// <para>The user's IAM ARN. This can also be a federated user's ARN.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String IamUserArn { get; set; }
        #endregion
        
        #region Parameter Level
        /// <summary>
        /// <para>
        /// <para>The user's permission level, which must be set to one of the following strings. You
        /// cannot set your own permissions level.</para><ul><li><para><c>deny</c></para></li><li><para><c>show</c></para></li><li><para><c>deploy</c></para></li><li><para><c>manage</c></para></li><li><para><c>iam_only</c></para></li></ul><para>For more information about the permissions associated with these levels, see <a href="https://docs.aws.amazon.com/opsworks/latest/userguide/opsworks-security-users.html">Managing
        /// User Permissions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Level { get; set; }
        #endregion
        
        #region Parameter StackId
        /// <summary>
        /// <para>
        /// <para>The stack ID.</para>
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
        public System.String StackId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpsWorks.Model.SetPermissionResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the StackId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^StackId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^StackId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.StackId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Set-OPSPermission (SetPermission)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpsWorks.Model.SetPermissionResponse, SetOPSPermissionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.StackId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AllowSsh = this.AllowSsh;
            context.AllowSudo = this.AllowSudo;
            context.IamUserArn = this.IamUserArn;
            #if MODULAR
            if (this.IamUserArn == null && ParameterWasBound(nameof(this.IamUserArn)))
            {
                WriteWarning("You are passing $null as a value for parameter IamUserArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Level = this.Level;
            context.StackId = this.StackId;
            #if MODULAR
            if (this.StackId == null && ParameterWasBound(nameof(this.StackId)))
            {
                WriteWarning("You are passing $null as a value for parameter StackId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpsWorks.Model.SetPermissionRequest();
            
            if (cmdletContext.AllowSsh != null)
            {
                request.AllowSsh = cmdletContext.AllowSsh.Value;
            }
            if (cmdletContext.AllowSudo != null)
            {
                request.AllowSudo = cmdletContext.AllowSudo.Value;
            }
            if (cmdletContext.IamUserArn != null)
            {
                request.IamUserArn = cmdletContext.IamUserArn;
            }
            if (cmdletContext.Level != null)
            {
                request.Level = cmdletContext.Level;
            }
            if (cmdletContext.StackId != null)
            {
                request.StackId = cmdletContext.StackId;
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
        
        private Amazon.OpsWorks.Model.SetPermissionResponse CallAWSServiceOperation(IAmazonOpsWorks client, Amazon.OpsWorks.Model.SetPermissionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS OpsWorks", "SetPermission");
            try
            {
                #if DESKTOP
                return client.SetPermission(request);
                #elif CORECLR
                return client.SetPermissionAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? AllowSsh { get; set; }
            public System.Boolean? AllowSudo { get; set; }
            public System.String IamUserArn { get; set; }
            public System.String Level { get; set; }
            public System.String StackId { get; set; }
            public System.Func<Amazon.OpsWorks.Model.SetPermissionResponse, SetOPSPermissionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
