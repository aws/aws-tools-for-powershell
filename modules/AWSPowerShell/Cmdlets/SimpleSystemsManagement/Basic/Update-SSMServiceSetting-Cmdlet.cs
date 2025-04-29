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
    /// <c>ServiceSetting</c> is an account-level setting for an Amazon Web Services service.
    /// This setting defines how a user interacts with or uses a service or a feature of a
    /// service. For example, if an Amazon Web Services service charges money to the account
    /// based on feature or service usage, then the Amazon Web Services service team might
    /// create a default setting of "false". This means the user can't use this feature unless
    /// they change the setting to "true" and intentionally opt in for a paid feature.
    /// 
    ///  
    /// <para>
    /// Services map a <c>SettingId</c> object to a setting value. Amazon Web Services services
    /// teams define the default value for a <c>SettingId</c>. You can't create a new <c>SettingId</c>,
    /// but you can overwrite the default value if you have the <c>ssm:UpdateServiceSetting</c>
    /// permission for the setting. Use the <a>GetServiceSetting</a> API operation to view
    /// the current value. Or, use the <a>ResetServiceSetting</a> to change the value back
    /// to the original value defined by the Amazon Web Services service team.
    /// </para><para>
    /// Update the service setting for the account. 
    /// </para>
    /// </summary>
    [Cmdlet("Update", "SSMServiceSetting", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the AWS Systems Manager UpdateServiceSetting API operation.", Operation = new[] {"UpdateServiceSetting"}, SelectReturnType = typeof(Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingResponse))]
    [AWSCmdletOutput("None or Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateSSMServiceSettingCmdlet : AmazonSimpleSystemsManagementClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter SettingId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the service setting to update. For example, <c>arn:aws:ssm:us-east-1:111122223333:servicesetting/ssm/parameter-store/high-throughput-enabled</c>.
        /// The setting ID can be one of the following.</para><ul><li><para><c>/ssm/appmanager/appmanager-enabled</c></para></li><li><para><c>/ssm/automation/customer-script-log-destination</c></para></li><li><para><c>/ssm/automation/customer-script-log-group-name</c></para></li><li><para>/ssm/automation/enable-adaptive-concurrency</para></li><li><para><c>/ssm/documents/console/public-sharing-permission</c></para></li><li><para><c>/ssm/managed-instance/activation-tier</c></para></li><li><para><c>/ssm/managed-instance/default-ec2-instance-management-role</c></para></li><li><para><c>/ssm/opsinsights/opscenter</c></para></li><li><para><c>/ssm/parameter-store/default-parameter-tier</c></para></li><li><para><c>/ssm/parameter-store/high-throughput-enabled</c></para></li></ul><note><para>Permissions to update the <c>/ssm/managed-instance/default-ec2-instance-management-role</c>
        /// setting should only be provided to administrators. Implement least privilege access
        /// when allowing individuals to configure or modify the Default Host Management Configuration.</para></note>
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
        public System.String SettingId { get; set; }
        #endregion
        
        #region Parameter SettingValue
        /// <summary>
        /// <para>
        /// <para>The new value to specify for the service setting. The following list specifies the
        /// available values for each setting.</para><ul><li><para>For <c>/ssm/appmanager/appmanager-enabled</c>, enter <c>True</c> or <c>False</c>.</para></li><li><para>For <c>/ssm/automation/customer-script-log-destination</c>, enter <c>CloudWatch</c>.</para></li><li><para>For <c>/ssm/automation/customer-script-log-group-name</c>, enter the name of an Amazon
        /// CloudWatch Logs log group.</para></li><li><para>For <c>/ssm/documents/console/public-sharing-permission</c>, enter <c>Enable</c> or
        /// <c>Disable</c>.</para></li><li><para>For <c>/ssm/managed-instance/activation-tier</c>, enter <c>standard</c> or <c>advanced</c>.</para></li><li><para>For <c>/ssm/managed-instance/default-ec2-instance-management-role</c>, enter the name
        /// of an IAM role. </para></li><li><para> For <c>/ssm/opsinsights/opscenter</c>, enter <c>Enabled</c> or <c>Disabled</c>. </para></li><li><para>For <c>/ssm/parameter-store/default-parameter-tier</c>, enter <c>Standard</c>, <c>Advanced</c>,
        /// or <c>Intelligent-Tiering</c></para></li><li><para>For <c>/ssm/parameter-store/high-throughput-enabled</c>, enter <c>true</c> or <c>false</c>.</para></li></ul>
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
        public System.String SettingValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SettingId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-SSMServiceSetting (UpdateServiceSetting)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingResponse, UpdateSSMServiceSettingCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.SettingId = this.SettingId;
            #if MODULAR
            if (this.SettingId == null && ParameterWasBound(nameof(this.SettingId)))
            {
                WriteWarning("You are passing $null as a value for parameter SettingId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SettingValue = this.SettingValue;
            #if MODULAR
            if (this.SettingValue == null && ParameterWasBound(nameof(this.SettingValue)))
            {
                WriteWarning("You are passing $null as a value for parameter SettingValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingRequest();
            
            if (cmdletContext.SettingId != null)
            {
                request.SettingId = cmdletContext.SettingId;
            }
            if (cmdletContext.SettingValue != null)
            {
                request.SettingValue = cmdletContext.SettingValue;
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
        
        private Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingResponse CallAWSServiceOperation(IAmazonSimpleSystemsManagement client, Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Systems Manager", "UpdateServiceSetting");
            try
            {
                return client.UpdateServiceSettingAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String SettingId { get; set; }
            public System.String SettingValue { get; set; }
            public System.Func<Amazon.SimpleSystemsManagement.Model.UpdateServiceSettingResponse, UpdateSSMServiceSettingCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
