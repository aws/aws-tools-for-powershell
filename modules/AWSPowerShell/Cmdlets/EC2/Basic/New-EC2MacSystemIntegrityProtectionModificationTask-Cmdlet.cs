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
using Amazon.EC2;
using Amazon.EC2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Creates a System Integrity Protection (SIP) modification task to configure the SIP
    /// settings for an x86 Mac instance or Apple silicon Mac instance. For more information,
    /// see <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/mac-sip-settings.html#mac-sip-configure">
    /// Configure SIP for Amazon EC2 instances</a> in the <i>Amazon EC2 User Guide</i>.
    /// 
    ///  
    /// <para>
    /// When you configure the SIP settings for your instance, you can either enable or disable
    /// all SIP settings, or you can specify a custom SIP configuration that selectively enables
    /// or disables specific SIP settings.
    /// </para><note><para>
    /// If you implement a custom configuration, <a href="https://docs.aws.amazon.com/AWSEC2/latest/UserGuide/mac-sip-settings.html#mac-sip-check-settings">
    /// connect to the instance and verify the settings</a> to ensure that your requirements
    /// are properly implemented and functioning as intended.
    /// </para><para>
    /// SIP configurations might change with macOS updates. We recommend that you review custom
    /// SIP settings after any macOS version upgrade to ensure continued compatibility and
    /// proper functionality of your security configurations.
    /// </para></note><para>
    /// To enable or disable all SIP settings, use the <b>MacSystemIntegrityProtectionStatus</b>
    /// parameter only. For example, to enable all SIP settings, specify the following:
    /// </para><ul><li><para><c>MacSystemIntegrityProtectionStatus=enabled</c></para></li></ul><para>
    /// To specify a custom configuration that selectively enables or disables specific SIP
    /// settings, use the <b>MacSystemIntegrityProtectionStatus</b> parameter to enable or
    /// disable all SIP settings, and then use the <b>MacSystemIntegrityProtectionConfiguration</b>
    /// parameter to specify exceptions. In this case, the exceptions you specify for <b>MacSystemIntegrityProtectionConfiguration</b>
    /// override the value you specify for <b>MacSystemIntegrityProtectionStatus</b>. For
    /// example, to enable all SIP settings, except <c>NvramProtections</c>, specify the following:
    /// </para><ul><li><para><c>MacSystemIntegrityProtectionStatus=enabled</c></para></li><li><para><c>MacSystemIntegrityProtectionConfigurationRequest "NvramProtections=disabled"</c></para></li></ul>
    /// </summary>
    [Cmdlet("New", "EC2MacSystemIntegrityProtectionModificationTask", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EC2.Model.MacModificationTask")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) CreateMacSystemIntegrityProtectionModificationTask API operation.", Operation = new[] {"CreateMacSystemIntegrityProtectionModificationTask"}, SelectReturnType = typeof(Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskResponse))]
    [AWSCmdletOutput("Amazon.EC2.Model.MacModificationTask or Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskResponse",
        "This cmdlet returns an Amazon.EC2.Model.MacModificationTask object.",
        "The service call response (type Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2MacSystemIntegrityProtectionModificationTaskCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter MacSystemIntegrityProtectionConfiguration_AppleInternal
        /// <summary>
        /// <para>
        /// <para>Enables or disables Apple Internal.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.MacSystemIntegrityProtectionSettingStatus")]
        public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_AppleInternal { get; set; }
        #endregion
        
        #region Parameter MacSystemIntegrityProtectionConfiguration_BaseSystem
        /// <summary>
        /// <para>
        /// <para>Enables or disables Base System.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.MacSystemIntegrityProtectionSettingStatus")]
        public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_BaseSystem { get; set; }
        #endregion
        
        #region Parameter MacSystemIntegrityProtectionConfiguration_DebuggingRestriction
        /// <summary>
        /// <para>
        /// <para>Enables or disables Debugging Restrictions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MacSystemIntegrityProtectionConfiguration_DebuggingRestrictions")]
        [AWSConstantClassSource("Amazon.EC2.MacSystemIntegrityProtectionSettingStatus")]
        public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_DebuggingRestriction { get; set; }
        #endregion
        
        #region Parameter DryRun
        /// <summary>
        /// <para>
        /// <para>Checks whether you have the required permissions for the action, without actually
        /// making the request, and provides an error response. If you have the required permissions,
        /// the error response is <c>DryRunOperation</c>. Otherwise, it is <c>UnauthorizedOperation</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DryRun { get; set; }
        #endregion
        
        #region Parameter MacSystemIntegrityProtectionConfiguration_DTraceRestriction
        /// <summary>
        /// <para>
        /// <para>Enables or disables Dtrace Restrictions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MacSystemIntegrityProtectionConfiguration_DTraceRestrictions")]
        [AWSConstantClassSource("Amazon.EC2.MacSystemIntegrityProtectionSettingStatus")]
        public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_DTraceRestriction { get; set; }
        #endregion
        
        #region Parameter MacSystemIntegrityProtectionConfiguration_FilesystemProtection
        /// <summary>
        /// <para>
        /// <para>Enables or disables Filesystem Protections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MacSystemIntegrityProtectionConfiguration_FilesystemProtections")]
        [AWSConstantClassSource("Amazon.EC2.MacSystemIntegrityProtectionSettingStatus")]
        public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_FilesystemProtection { get; set; }
        #endregion
        
        #region Parameter InstanceId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon EC2 Mac instance.</para>
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
        public System.String InstanceId { get; set; }
        #endregion
        
        #region Parameter MacSystemIntegrityProtectionConfiguration_KextSigning
        /// <summary>
        /// <para>
        /// <para>Enables or disables Kext Signing.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EC2.MacSystemIntegrityProtectionSettingStatus")]
        public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_KextSigning { get; set; }
        #endregion
        
        #region Parameter MacCredential
        /// <summary>
        /// <para>
        /// <para><b>[Apple silicon Mac instances only]</b> Specifies the following credentials:</para><ul><li><para><b>Internal disk administrative user</b></para><ul><li><para><b>Username</b> - Only the default administrative user (<c>aws-managed-user</c>)
        /// is supported and it is used by default. You can't specify a different administrative
        /// user.</para></li><li><para><b>Password</b> - If you did not change the default password for <c>aws-managed-user</c>,
        /// specify the default password, which is <i>blank</i>. Otherwise, specify your password.</para></li></ul></li><li><para><b>Amazon EBS root volume administrative user</b></para><ul><li><para><b>Username</b> - If you did not change the default administrative user, specify
        /// <c>ec2-user</c>. Otherwise, specify the username for your administrative user.</para></li><li><para><b>Password</b> - Specify the password for the administrative user.</para></li></ul></li></ul><para>The credentials must be specified in the following JSON format:</para><para><c>{ "internalDiskPassword":"<i>internal-disk-admin_password</i>", "rootVolumeUsername":"<i>root-volume-admin_username</i>",
        /// "rootVolumepassword":"<i>root-volume-admin_password</i>" }</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MacCredentials")]
        public System.String MacCredential { get; set; }
        #endregion
        
        #region Parameter MacSystemIntegrityProtectionStatus
        /// <summary>
        /// <para>
        /// <para>Specifies the overall SIP status for the instance. To enable all SIP settings, specify
        /// <c>enabled</c>. To disable all SIP settings, specify <c>disabled</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EC2.MacSystemIntegrityProtectionSettingStatus")]
        public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionStatus { get; set; }
        #endregion
        
        #region Parameter MacSystemIntegrityProtectionConfiguration_NvramProtection
        /// <summary>
        /// <para>
        /// <para>Enables or disables Nvram Protections.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MacSystemIntegrityProtectionConfiguration_NvramProtections")]
        [AWSConstantClassSource("Amazon.EC2.MacSystemIntegrityProtectionSettingStatus")]
        public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_NvramProtection { get; set; }
        #endregion
        
        #region Parameter TagSpecification
        /// <summary>
        /// <para>
        /// <para>Specifies tags to apply to the SIP modification task.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TagSpecifications")]
        public Amazon.EC2.Model.TagSpecification[] TagSpecification { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier that you provide to ensure the idempotency of the
        /// request. For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// Idempotency</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MacModificationTask'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MacModificationTask";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InstanceId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2MacSystemIntegrityProtectionModificationTask (CreateMacSystemIntegrityProtectionModificationTask)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskResponse, NewEC2MacSystemIntegrityProtectionModificationTaskCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DryRun = this.DryRun;
            context.InstanceId = this.InstanceId;
            #if MODULAR
            if (this.InstanceId == null && ParameterWasBound(nameof(this.InstanceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MacCredential = this.MacCredential;
            context.MacSystemIntegrityProtectionConfiguration_AppleInternal = this.MacSystemIntegrityProtectionConfiguration_AppleInternal;
            context.MacSystemIntegrityProtectionConfiguration_BaseSystem = this.MacSystemIntegrityProtectionConfiguration_BaseSystem;
            context.MacSystemIntegrityProtectionConfiguration_DebuggingRestriction = this.MacSystemIntegrityProtectionConfiguration_DebuggingRestriction;
            context.MacSystemIntegrityProtectionConfiguration_DTraceRestriction = this.MacSystemIntegrityProtectionConfiguration_DTraceRestriction;
            context.MacSystemIntegrityProtectionConfiguration_FilesystemProtection = this.MacSystemIntegrityProtectionConfiguration_FilesystemProtection;
            context.MacSystemIntegrityProtectionConfiguration_KextSigning = this.MacSystemIntegrityProtectionConfiguration_KextSigning;
            context.MacSystemIntegrityProtectionConfiguration_NvramProtection = this.MacSystemIntegrityProtectionConfiguration_NvramProtection;
            context.MacSystemIntegrityProtectionStatus = this.MacSystemIntegrityProtectionStatus;
            #if MODULAR
            if (this.MacSystemIntegrityProtectionStatus == null && ParameterWasBound(nameof(this.MacSystemIntegrityProtectionStatus)))
            {
                WriteWarning("You are passing $null as a value for parameter MacSystemIntegrityProtectionStatus which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.TagSpecification != null)
            {
                context.TagSpecification = new List<Amazon.EC2.Model.TagSpecification>(this.TagSpecification);
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
            var request = new Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DryRun != null)
            {
                request.DryRun = cmdletContext.DryRun.Value;
            }
            if (cmdletContext.InstanceId != null)
            {
                request.InstanceId = cmdletContext.InstanceId;
            }
            if (cmdletContext.MacCredential != null)
            {
                request.MacCredentials = cmdletContext.MacCredential;
            }
            
             // populate MacSystemIntegrityProtectionConfiguration
            var requestMacSystemIntegrityProtectionConfigurationIsNull = true;
            request.MacSystemIntegrityProtectionConfiguration = new Amazon.EC2.Model.MacSystemIntegrityProtectionConfigurationRequest();
            Amazon.EC2.MacSystemIntegrityProtectionSettingStatus requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_AppleInternal = null;
            if (cmdletContext.MacSystemIntegrityProtectionConfiguration_AppleInternal != null)
            {
                requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_AppleInternal = cmdletContext.MacSystemIntegrityProtectionConfiguration_AppleInternal;
            }
            if (requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_AppleInternal != null)
            {
                request.MacSystemIntegrityProtectionConfiguration.AppleInternal = requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_AppleInternal;
                requestMacSystemIntegrityProtectionConfigurationIsNull = false;
            }
            Amazon.EC2.MacSystemIntegrityProtectionSettingStatus requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_BaseSystem = null;
            if (cmdletContext.MacSystemIntegrityProtectionConfiguration_BaseSystem != null)
            {
                requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_BaseSystem = cmdletContext.MacSystemIntegrityProtectionConfiguration_BaseSystem;
            }
            if (requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_BaseSystem != null)
            {
                request.MacSystemIntegrityProtectionConfiguration.BaseSystem = requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_BaseSystem;
                requestMacSystemIntegrityProtectionConfigurationIsNull = false;
            }
            Amazon.EC2.MacSystemIntegrityProtectionSettingStatus requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_DebuggingRestriction = null;
            if (cmdletContext.MacSystemIntegrityProtectionConfiguration_DebuggingRestriction != null)
            {
                requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_DebuggingRestriction = cmdletContext.MacSystemIntegrityProtectionConfiguration_DebuggingRestriction;
            }
            if (requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_DebuggingRestriction != null)
            {
                request.MacSystemIntegrityProtectionConfiguration.DebuggingRestrictions = requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_DebuggingRestriction;
                requestMacSystemIntegrityProtectionConfigurationIsNull = false;
            }
            Amazon.EC2.MacSystemIntegrityProtectionSettingStatus requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_DTraceRestriction = null;
            if (cmdletContext.MacSystemIntegrityProtectionConfiguration_DTraceRestriction != null)
            {
                requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_DTraceRestriction = cmdletContext.MacSystemIntegrityProtectionConfiguration_DTraceRestriction;
            }
            if (requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_DTraceRestriction != null)
            {
                request.MacSystemIntegrityProtectionConfiguration.DTraceRestrictions = requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_DTraceRestriction;
                requestMacSystemIntegrityProtectionConfigurationIsNull = false;
            }
            Amazon.EC2.MacSystemIntegrityProtectionSettingStatus requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_FilesystemProtection = null;
            if (cmdletContext.MacSystemIntegrityProtectionConfiguration_FilesystemProtection != null)
            {
                requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_FilesystemProtection = cmdletContext.MacSystemIntegrityProtectionConfiguration_FilesystemProtection;
            }
            if (requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_FilesystemProtection != null)
            {
                request.MacSystemIntegrityProtectionConfiguration.FilesystemProtections = requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_FilesystemProtection;
                requestMacSystemIntegrityProtectionConfigurationIsNull = false;
            }
            Amazon.EC2.MacSystemIntegrityProtectionSettingStatus requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_KextSigning = null;
            if (cmdletContext.MacSystemIntegrityProtectionConfiguration_KextSigning != null)
            {
                requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_KextSigning = cmdletContext.MacSystemIntegrityProtectionConfiguration_KextSigning;
            }
            if (requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_KextSigning != null)
            {
                request.MacSystemIntegrityProtectionConfiguration.KextSigning = requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_KextSigning;
                requestMacSystemIntegrityProtectionConfigurationIsNull = false;
            }
            Amazon.EC2.MacSystemIntegrityProtectionSettingStatus requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_NvramProtection = null;
            if (cmdletContext.MacSystemIntegrityProtectionConfiguration_NvramProtection != null)
            {
                requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_NvramProtection = cmdletContext.MacSystemIntegrityProtectionConfiguration_NvramProtection;
            }
            if (requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_NvramProtection != null)
            {
                request.MacSystemIntegrityProtectionConfiguration.NvramProtections = requestMacSystemIntegrityProtectionConfiguration_macSystemIntegrityProtectionConfiguration_NvramProtection;
                requestMacSystemIntegrityProtectionConfigurationIsNull = false;
            }
             // determine if request.MacSystemIntegrityProtectionConfiguration should be set to null
            if (requestMacSystemIntegrityProtectionConfigurationIsNull)
            {
                request.MacSystemIntegrityProtectionConfiguration = null;
            }
            if (cmdletContext.MacSystemIntegrityProtectionStatus != null)
            {
                request.MacSystemIntegrityProtectionStatus = cmdletContext.MacSystemIntegrityProtectionStatus;
            }
            if (cmdletContext.TagSpecification != null)
            {
                request.TagSpecifications = cmdletContext.TagSpecification;
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
        
        private Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "CreateMacSystemIntegrityProtectionModificationTask");
            try
            {
                return client.CreateMacSystemIntegrityProtectionModificationTaskAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.Boolean? DryRun { get; set; }
            public System.String InstanceId { get; set; }
            public System.String MacCredential { get; set; }
            public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_AppleInternal { get; set; }
            public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_BaseSystem { get; set; }
            public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_DebuggingRestriction { get; set; }
            public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_DTraceRestriction { get; set; }
            public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_FilesystemProtection { get; set; }
            public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_KextSigning { get; set; }
            public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionConfiguration_NvramProtection { get; set; }
            public Amazon.EC2.MacSystemIntegrityProtectionSettingStatus MacSystemIntegrityProtectionStatus { get; set; }
            public List<Amazon.EC2.Model.TagSpecification> TagSpecification { get; set; }
            public System.Func<Amazon.EC2.Model.CreateMacSystemIntegrityProtectionModificationTaskResponse, NewEC2MacSystemIntegrityProtectionModificationTaskCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MacModificationTask;
        }
        
    }
}
