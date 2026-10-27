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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Updates the scan configuration for your Amazon Inspector account. If you don't specify
    /// an <c>accountId</c>, this operation updates the delegated administrator's configuration
    /// and propagates it to member accounts that have not been individually configured. If
    /// you specify an <c>accountId</c>, this operation updates that member account's configuration.
    /// Only the delegated administrator can specify an <c>accountId</c>; member accounts
    /// cannot call this operation.
    /// </summary>
    [Cmdlet("Update", "INS2Configuration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Inspector2 UpdateConfiguration API operation.", Operation = new[] {"UpdateConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.UpdateConfigurationResponse))]
    [AWSCmdletOutput("None or Amazon.Inspector2.Model.UpdateConfigurationResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Inspector2.Model.UpdateConfigurationResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateINS2ConfigurationCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The 12-digit Amazon Web Services account ID of the member account whose scan configuration
        /// you want to update. When specified, you must be the delegated administrator for this
        /// member account. If not specified, the operation updates your own configuration and
        /// propagates changes to any member accounts that have not been individually configured.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter Ec2Configuration_ActivateVMScanner
        /// <summary>
        /// <para>
        /// <para>Whether to activate Amazon Inspector VM scanner for Amazon EC2 scanning.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Ec2Configuration_ActivateVMScanner { get; set; }
        #endregion
        
        #region Parameter UpdateConfigurationInheritance_AmiConfiguration
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.InheritanceMode")]
        public Amazon.Inspector2.InheritanceMode UpdateConfigurationInheritance_AmiConfiguration { get; set; }
        #endregion
        
        #region Parameter AmiConfiguration_CreatedWithin
        /// <summary>
        /// <para>
        /// <para>Restricts scanning to AMIs that were created within the specified duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.AmiScanDuration")]
        public Amazon.Inspector2.AmiScanDuration AmiConfiguration_CreatedWithin { get; set; }
        #endregion
        
        #region Parameter UpdateConfigurationInheritance_Ec2Configuration
        /// <summary>
        /// <para>
        /// <para>The inheritance mode for Amazon EC2 scan configuration. Set to <c>INHERIT_FROM_ADMIN</c>
        /// to reset the member account's Amazon EC2 scan configuration to inherit from the delegated
        /// administrator. If omitted, the member account's existing Amazon EC2 scan configuration
        /// is not changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.InheritanceMode")]
        public Amazon.Inspector2.InheritanceMode UpdateConfigurationInheritance_Ec2Configuration { get; set; }
        #endregion
        
        #region Parameter UpdateConfigurationInheritance_EcrConfiguration
        /// <summary>
        /// <para>
        /// <para>The inheritance mode for Amazon ECR scan configuration. Set to <c>INHERIT_FROM_ADMIN</c>
        /// to reset the member account's Amazon ECR scan configuration to inherit from the delegated
        /// administrator. If omitted, the member account's existing Amazon ECR scan configuration
        /// is not changed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.InheritanceMode")]
        public Amazon.Inspector2.InheritanceMode UpdateConfigurationInheritance_EcrConfiguration { get; set; }
        #endregion
        
        #region Parameter AmiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi
        /// <summary>
        /// <para>
        /// <para>Whether to exclude AMIs created by Amazon Data Lifecycle Manager (DLM) backups from
        /// scanning.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AmiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmis")]
        public System.Boolean? AmiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi { get; set; }
        #endregion
        
        #region Parameter AmiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi
        /// <summary>
        /// <para>
        /// <para>Whether to exclude AMIs that are copies of other AMIs from scanning.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AmiConfiguration_ScanModeConfiguration_ExcludeCopiedAmis")]
        public System.Boolean? AmiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi { get; set; }
        #endregion
        
        #region Parameter AmiConfiguration_LastLaunchedWithin
        /// <summary>
        /// <para>
        /// <para>Restricts scanning to AMIs that were last launched within the specified duration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.AmiScanDuration")]
        public Amazon.Inspector2.AmiScanDuration AmiConfiguration_LastLaunchedWithin { get; set; }
        #endregion
        
        #region Parameter EcrConfiguration_PullDateRescanDuration
        /// <summary>
        /// <para>
        /// <para>The rescan duration configured for image pull date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.EcrPullDateRescanDuration")]
        public Amazon.Inspector2.EcrPullDateRescanDuration EcrConfiguration_PullDateRescanDuration { get; set; }
        #endregion
        
        #region Parameter EcrConfiguration_PullDateRescanMode
        /// <summary>
        /// <para>
        /// <para>The pull date for the re-scan mode.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.EcrPullDateRescanMode")]
        public Amazon.Inspector2.EcrPullDateRescanMode EcrConfiguration_PullDateRescanMode { get; set; }
        #endregion
        
        #region Parameter EcrConfiguration_RescanDuration
        /// <summary>
        /// <para>
        /// <para>The rescan duration configured for image push date.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        [AWSConstantClassSource("Amazon.Inspector2.EcrRescanDuration")]
        public Amazon.Inspector2.EcrRescanDuration EcrConfiguration_RescanDuration { get; set; }
        #endregion
        
        #region Parameter AmiConfiguration_ScanModeConfiguration_ScanMode
        /// <summary>
        /// <para>
        /// <para>The scan mode that determines whether all AMIs are scanned or only those matching
        /// the specified tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.AmiScanMode")]
        public Amazon.Inspector2.AmiScanMode AmiConfiguration_ScanModeConfiguration_ScanMode { get; set; }
        #endregion
        
        #region Parameter Ec2Configuration_ScanMode
        /// <summary>
        /// <para>
        /// <para>The scan method that is applied to the instance.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Inspector2.Ec2ScanMode")]
        public Amazon.Inspector2.Ec2ScanMode Ec2Configuration_ScanMode { get; set; }
        #endregion
        
        #region Parameter AmiConfiguration_ScanModeConfiguration_Tag
        /// <summary>
        /// <para>
        /// <para>The tag filters used to select which AMIs are scanned when using targeted scanning.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data
        /// for this property is returned from the service the property will also be null. This
        /// was changed to improve performance and allow the SDK and caller to distinguish between
        /// a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AmiConfiguration_ScanModeConfiguration_Tags")]
        public Amazon.Inspector2.Model.AmiTagFilter[] AmiConfiguration_ScanModeConfiguration_Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.UpdateConfigurationResponse).
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.EcrConfiguration_RescanDuration), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INS2Configuration (UpdateConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.UpdateConfigurationResponse, UpdateINS2ConfigurationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.AccountId = this.AccountId;
            context.AmiConfiguration_CreatedWithin = this.AmiConfiguration_CreatedWithin;
            context.AmiConfiguration_LastLaunchedWithin = this.AmiConfiguration_LastLaunchedWithin;
            context.AmiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi = this.AmiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi;
            context.AmiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi = this.AmiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi;
            context.AmiConfiguration_ScanModeConfiguration_ScanMode = this.AmiConfiguration_ScanModeConfiguration_ScanMode;
            if (this.AmiConfiguration_ScanModeConfiguration_Tag != null)
            {
                context.AmiConfiguration_ScanModeConfiguration_Tag = new List<Amazon.Inspector2.Model.AmiTagFilter>(this.AmiConfiguration_ScanModeConfiguration_Tag);
            }
            context.Ec2Configuration_ActivateVMScanner = this.Ec2Configuration_ActivateVMScanner;
            context.Ec2Configuration_ScanMode = this.Ec2Configuration_ScanMode;
            context.EcrConfiguration_PullDateRescanDuration = this.EcrConfiguration_PullDateRescanDuration;
            context.EcrConfiguration_PullDateRescanMode = this.EcrConfiguration_PullDateRescanMode;
            context.EcrConfiguration_RescanDuration = this.EcrConfiguration_RescanDuration;
            context.UpdateConfigurationInheritance_AmiConfiguration = this.UpdateConfigurationInheritance_AmiConfiguration;
            context.UpdateConfigurationInheritance_Ec2Configuration = this.UpdateConfigurationInheritance_Ec2Configuration;
            context.UpdateConfigurationInheritance_EcrConfiguration = this.UpdateConfigurationInheritance_EcrConfiguration;
            
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
            var request = new Amazon.Inspector2.Model.UpdateConfigurationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            
             // populate AmiConfiguration
            var requestAmiConfigurationIsNull = true;
            request.AmiConfiguration = new Amazon.Inspector2.Model.AmiConfiguration();
            Amazon.Inspector2.AmiScanDuration requestAmiConfiguration_amiConfiguration_CreatedWithin = null;
            if (cmdletContext.AmiConfiguration_CreatedWithin != null)
            {
                requestAmiConfiguration_amiConfiguration_CreatedWithin = cmdletContext.AmiConfiguration_CreatedWithin;
            }
            if (requestAmiConfiguration_amiConfiguration_CreatedWithin != null)
            {
                request.AmiConfiguration.CreatedWithin = requestAmiConfiguration_amiConfiguration_CreatedWithin;
                requestAmiConfigurationIsNull = false;
            }
            Amazon.Inspector2.AmiScanDuration requestAmiConfiguration_amiConfiguration_LastLaunchedWithin = null;
            if (cmdletContext.AmiConfiguration_LastLaunchedWithin != null)
            {
                requestAmiConfiguration_amiConfiguration_LastLaunchedWithin = cmdletContext.AmiConfiguration_LastLaunchedWithin;
            }
            if (requestAmiConfiguration_amiConfiguration_LastLaunchedWithin != null)
            {
                request.AmiConfiguration.LastLaunchedWithin = requestAmiConfiguration_amiConfiguration_LastLaunchedWithin;
                requestAmiConfigurationIsNull = false;
            }
            Amazon.Inspector2.Model.AmiScanModeConfiguration requestAmiConfiguration_amiConfiguration_ScanModeConfiguration = null;
            
             // populate ScanModeConfiguration
            var requestAmiConfiguration_amiConfiguration_ScanModeConfigurationIsNull = true;
            requestAmiConfiguration_amiConfiguration_ScanModeConfiguration = new Amazon.Inspector2.Model.AmiScanModeConfiguration();
            System.Boolean? requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi = null;
            if (cmdletContext.AmiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi != null)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi = cmdletContext.AmiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi.Value;
            }
            if (requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi != null)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration.ExcludeBackupDlmAmis = requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi.Value;
                requestAmiConfiguration_amiConfiguration_ScanModeConfigurationIsNull = false;
            }
            System.Boolean? requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi = null;
            if (cmdletContext.AmiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi != null)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi = cmdletContext.AmiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi.Value;
            }
            if (requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi != null)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration.ExcludeCopiedAmis = requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi.Value;
                requestAmiConfiguration_amiConfiguration_ScanModeConfigurationIsNull = false;
            }
            Amazon.Inspector2.AmiScanMode requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ScanMode = null;
            if (cmdletContext.AmiConfiguration_ScanModeConfiguration_ScanMode != null)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ScanMode = cmdletContext.AmiConfiguration_ScanModeConfiguration_ScanMode;
            }
            if (requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ScanMode != null)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration.ScanMode = requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_ScanMode;
                requestAmiConfiguration_amiConfiguration_ScanModeConfigurationIsNull = false;
            }
            List<Amazon.Inspector2.Model.AmiTagFilter> requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_Tag = null;
            if (cmdletContext.AmiConfiguration_ScanModeConfiguration_Tag != null)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_Tag = cmdletContext.AmiConfiguration_ScanModeConfiguration_Tag;
            }
            if (requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_Tag != null)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration.Tags = requestAmiConfiguration_amiConfiguration_ScanModeConfiguration_amiConfiguration_ScanModeConfiguration_Tag;
                requestAmiConfiguration_amiConfiguration_ScanModeConfigurationIsNull = false;
            }
             // determine if requestAmiConfiguration_amiConfiguration_ScanModeConfiguration should be set to null
            if (requestAmiConfiguration_amiConfiguration_ScanModeConfigurationIsNull)
            {
                requestAmiConfiguration_amiConfiguration_ScanModeConfiguration = null;
            }
            if (requestAmiConfiguration_amiConfiguration_ScanModeConfiguration != null)
            {
                request.AmiConfiguration.ScanModeConfiguration = requestAmiConfiguration_amiConfiguration_ScanModeConfiguration;
                requestAmiConfigurationIsNull = false;
            }
             // determine if request.AmiConfiguration should be set to null
            if (requestAmiConfigurationIsNull)
            {
                request.AmiConfiguration = null;
            }
            
             // populate Ec2Configuration
            var requestEc2ConfigurationIsNull = true;
            request.Ec2Configuration = new Amazon.Inspector2.Model.Ec2Configuration();
            System.Boolean? requestEc2Configuration_ec2Configuration_ActivateVMScanner = null;
            if (cmdletContext.Ec2Configuration_ActivateVMScanner != null)
            {
                requestEc2Configuration_ec2Configuration_ActivateVMScanner = cmdletContext.Ec2Configuration_ActivateVMScanner.Value;
            }
            if (requestEc2Configuration_ec2Configuration_ActivateVMScanner != null)
            {
                request.Ec2Configuration.ActivateVMScanner = requestEc2Configuration_ec2Configuration_ActivateVMScanner.Value;
                requestEc2ConfigurationIsNull = false;
            }
            Amazon.Inspector2.Ec2ScanMode requestEc2Configuration_ec2Configuration_ScanMode = null;
            if (cmdletContext.Ec2Configuration_ScanMode != null)
            {
                requestEc2Configuration_ec2Configuration_ScanMode = cmdletContext.Ec2Configuration_ScanMode;
            }
            if (requestEc2Configuration_ec2Configuration_ScanMode != null)
            {
                request.Ec2Configuration.ScanMode = requestEc2Configuration_ec2Configuration_ScanMode;
                requestEc2ConfigurationIsNull = false;
            }
             // determine if request.Ec2Configuration should be set to null
            if (requestEc2ConfigurationIsNull)
            {
                request.Ec2Configuration = null;
            }
            
             // populate EcrConfiguration
            var requestEcrConfigurationIsNull = true;
            request.EcrConfiguration = new Amazon.Inspector2.Model.EcrConfiguration();
            Amazon.Inspector2.EcrPullDateRescanDuration requestEcrConfiguration_ecrConfiguration_PullDateRescanDuration = null;
            if (cmdletContext.EcrConfiguration_PullDateRescanDuration != null)
            {
                requestEcrConfiguration_ecrConfiguration_PullDateRescanDuration = cmdletContext.EcrConfiguration_PullDateRescanDuration;
            }
            if (requestEcrConfiguration_ecrConfiguration_PullDateRescanDuration != null)
            {
                request.EcrConfiguration.PullDateRescanDuration = requestEcrConfiguration_ecrConfiguration_PullDateRescanDuration;
                requestEcrConfigurationIsNull = false;
            }
            Amazon.Inspector2.EcrPullDateRescanMode requestEcrConfiguration_ecrConfiguration_PullDateRescanMode = null;
            if (cmdletContext.EcrConfiguration_PullDateRescanMode != null)
            {
                requestEcrConfiguration_ecrConfiguration_PullDateRescanMode = cmdletContext.EcrConfiguration_PullDateRescanMode;
            }
            if (requestEcrConfiguration_ecrConfiguration_PullDateRescanMode != null)
            {
                request.EcrConfiguration.PullDateRescanMode = requestEcrConfiguration_ecrConfiguration_PullDateRescanMode;
                requestEcrConfigurationIsNull = false;
            }
            Amazon.Inspector2.EcrRescanDuration requestEcrConfiguration_ecrConfiguration_RescanDuration = null;
            if (cmdletContext.EcrConfiguration_RescanDuration != null)
            {
                requestEcrConfiguration_ecrConfiguration_RescanDuration = cmdletContext.EcrConfiguration_RescanDuration;
            }
            if (requestEcrConfiguration_ecrConfiguration_RescanDuration != null)
            {
                request.EcrConfiguration.RescanDuration = requestEcrConfiguration_ecrConfiguration_RescanDuration;
                requestEcrConfigurationIsNull = false;
            }
             // determine if request.EcrConfiguration should be set to null
            if (requestEcrConfigurationIsNull)
            {
                request.EcrConfiguration = null;
            }
            
             // populate UpdateConfigurationInheritance
            var requestUpdateConfigurationInheritanceIsNull = true;
            request.UpdateConfigurationInheritance = new Amazon.Inspector2.Model.UpdateConfigurationInheritance();
            Amazon.Inspector2.InheritanceMode requestUpdateConfigurationInheritance_updateConfigurationInheritance_AmiConfiguration = null;
            if (cmdletContext.UpdateConfigurationInheritance_AmiConfiguration != null)
            {
                requestUpdateConfigurationInheritance_updateConfigurationInheritance_AmiConfiguration = cmdletContext.UpdateConfigurationInheritance_AmiConfiguration;
            }
            if (requestUpdateConfigurationInheritance_updateConfigurationInheritance_AmiConfiguration != null)
            {
                request.UpdateConfigurationInheritance.AmiConfiguration = requestUpdateConfigurationInheritance_updateConfigurationInheritance_AmiConfiguration;
                requestUpdateConfigurationInheritanceIsNull = false;
            }
            Amazon.Inspector2.InheritanceMode requestUpdateConfigurationInheritance_updateConfigurationInheritance_Ec2Configuration = null;
            if (cmdletContext.UpdateConfigurationInheritance_Ec2Configuration != null)
            {
                requestUpdateConfigurationInheritance_updateConfigurationInheritance_Ec2Configuration = cmdletContext.UpdateConfigurationInheritance_Ec2Configuration;
            }
            if (requestUpdateConfigurationInheritance_updateConfigurationInheritance_Ec2Configuration != null)
            {
                request.UpdateConfigurationInheritance.Ec2Configuration = requestUpdateConfigurationInheritance_updateConfigurationInheritance_Ec2Configuration;
                requestUpdateConfigurationInheritanceIsNull = false;
            }
            Amazon.Inspector2.InheritanceMode requestUpdateConfigurationInheritance_updateConfigurationInheritance_EcrConfiguration = null;
            if (cmdletContext.UpdateConfigurationInheritance_EcrConfiguration != null)
            {
                requestUpdateConfigurationInheritance_updateConfigurationInheritance_EcrConfiguration = cmdletContext.UpdateConfigurationInheritance_EcrConfiguration;
            }
            if (requestUpdateConfigurationInheritance_updateConfigurationInheritance_EcrConfiguration != null)
            {
                request.UpdateConfigurationInheritance.EcrConfiguration = requestUpdateConfigurationInheritance_updateConfigurationInheritance_EcrConfiguration;
                requestUpdateConfigurationInheritanceIsNull = false;
            }
             // determine if request.UpdateConfigurationInheritance should be set to null
            if (requestUpdateConfigurationInheritanceIsNull)
            {
                request.UpdateConfigurationInheritance = null;
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
        
        private Amazon.Inspector2.Model.UpdateConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.UpdateConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "UpdateConfiguration");
            try
            {
                return client.UpdateConfigurationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public Amazon.Inspector2.AmiScanDuration AmiConfiguration_CreatedWithin { get; set; }
            public Amazon.Inspector2.AmiScanDuration AmiConfiguration_LastLaunchedWithin { get; set; }
            public System.Boolean? AmiConfiguration_ScanModeConfiguration_ExcludeBackupDlmAmi { get; set; }
            public System.Boolean? AmiConfiguration_ScanModeConfiguration_ExcludeCopiedAmi { get; set; }
            public Amazon.Inspector2.AmiScanMode AmiConfiguration_ScanModeConfiguration_ScanMode { get; set; }
            public List<Amazon.Inspector2.Model.AmiTagFilter> AmiConfiguration_ScanModeConfiguration_Tag { get; set; }
            public System.Boolean? Ec2Configuration_ActivateVMScanner { get; set; }
            public Amazon.Inspector2.Ec2ScanMode Ec2Configuration_ScanMode { get; set; }
            public Amazon.Inspector2.EcrPullDateRescanDuration EcrConfiguration_PullDateRescanDuration { get; set; }
            public Amazon.Inspector2.EcrPullDateRescanMode EcrConfiguration_PullDateRescanMode { get; set; }
            public Amazon.Inspector2.EcrRescanDuration EcrConfiguration_RescanDuration { get; set; }
            public Amazon.Inspector2.InheritanceMode UpdateConfigurationInheritance_AmiConfiguration { get; set; }
            public Amazon.Inspector2.InheritanceMode UpdateConfigurationInheritance_Ec2Configuration { get; set; }
            public Amazon.Inspector2.InheritanceMode UpdateConfigurationInheritance_EcrConfiguration { get; set; }
            public System.Func<Amazon.Inspector2.Model.UpdateConfigurationResponse, UpdateINS2ConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
