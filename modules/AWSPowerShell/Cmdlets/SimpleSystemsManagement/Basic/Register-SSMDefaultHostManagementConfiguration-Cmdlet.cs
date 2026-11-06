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
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.SSM
{
    /// <summary>
    /// Enables Default Host Management Configuration (DHMC) for the current Amazon Web Services
    /// account and Amazon Web Services Region. With DHMC enabled, you don't need to configure
    /// additional resources, such as an instance profile, to use your Amazon EC2 instances
    /// as managed nodes in Amazon Web Services Systems Manager.
    /// 
    ///  
    /// <para>
    /// To use this operation, you must have the following permissions:
    /// </para><ul><li><para>
    /// You need the <c>ssm:GetServiceSetting</c> and <c>ssm:UpdateServiceSetting</c> permissions
    /// for the <c>/ssm/managed-instance/default-ec2-instance-management-role</c> service
    /// setting.
    /// </para></li><li><para>
    /// You need the <c>iam:GetRole</c> and <c>iam:PassRole</c> permissions for the role used
    /// for Default Host Management Configuration.
    /// </para></li></ul><para>
    /// If <c>PermissionModel</c> is <c>SERVICE_MANAGED</c>, you also need the <c>iam:CreateRole</c>
    /// and <c>iam:AttachRolePolicy</c> permissions so that Amazon Web Services Systems Manager
    /// can create and configure the role on your behalf.
    /// </para>
    /// </summary>
    [Cmdlet("Register", "SSMDefaultHostManagementConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Systems Manager RegisterDefaultHostManagementConfiguration API operation.", Operation = new[] {"RegisterDefaultHostManagementConfiguration"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationResponse))]
    [AWSCmdletOutput("System.String or Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RegisterSSMDefaultHostManagementConfigurationCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Overwrite
        /// <summary>
        /// <para>
        /// <para>Specifies whether to override the role that is currently registered for Default Host
        /// Management Configuration. The default is <c>false</c>, which acts as a guardrail against
        /// accidentally replacing an existing configuration. Set this to <c>true</c> to replace
        /// the currently registered role.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Overwrite { get; set; }
        #endregion
        
        #region Parameter PermissionModel
        /// <summary>
        /// <para>
        /// <para>The permission model that determines how the IAM role for Default Host Management
        /// Configuration is provided.</para><para>The permission model can be one of the following values:</para><dl><dt>SERVICE_MANAGED</dt><dd><para>Amazon Web Services Systems Manager creates and manages the role on your behalf.</para></dd><dt>SELF_MANAGED</dt><dd><para>You provide the role to register in <c>RoleArn</c>.</para></dd></dl>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.SimpleSystemsManagement.DHMCPermissionModel")]
        public Amazon.SimpleSystemsManagement.DHMCPermissionModel PermissionModel { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the self-managed IAM role that you register for
        /// Default Host Management Configuration. The requirement for this value depends on the
        /// permission model:</para><ul><li><para>If <c>PermissionModel</c> is <c>SELF_MANAGED</c>, this value is required.</para></li><li><para>If <c>PermissionModel</c> is <c>SERVICE_MANAGED</c>, this value must not be set.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RoleArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationResponse).
        /// Specifying the name of a property of type Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RoleArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.PermissionModel), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-SSMDefaultHostManagementConfiguration (RegisterDefaultHostManagementConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationResponse, RegisterSSMDefaultHostManagementConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Overwrite = this.Overwrite;
            context.PermissionModel = this.PermissionModel;
            #if MODULAR
            if (this.PermissionModel == null && ParameterWasBound(nameof(this.PermissionModel)))
            {
                WriteWarning("You are passing $null as a value for parameter PermissionModel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            
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
            var request = new Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationRequest();
            
            if (cmdletContext.Overwrite != null)
            {
                request.Overwrite = cmdletContext.Overwrite.Value;
            }
            if (cmdletContext.PermissionModel != null)
            {
                request.PermissionModel = cmdletContext.PermissionModel;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
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
        
        private Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "RegisterDefaultHostManagementConfiguration");
            try
            {
                return client.RegisterDefaultHostManagementConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? Overwrite { get; set; }
            public Amazon.SimpleSystemsManagement.DHMCPermissionModel PermissionModel { get; set; }
            public System.String RoleArn { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.RegisterDefaultHostManagementConfigurationResponse, RegisterSSMDefaultHostManagementConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RoleArn;
        }
        
    }
}
