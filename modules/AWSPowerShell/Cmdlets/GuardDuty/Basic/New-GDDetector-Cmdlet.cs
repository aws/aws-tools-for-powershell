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
using Amazon.GuardDuty;
using Amazon.GuardDuty.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.GD
{
    /// <summary>
    /// Creates a single GuardDuty detector. A detector is a resource that represents the
    /// GuardDuty service. To start using GuardDuty, you must create a detector in each Region
    /// where you enable the service. You can have only one detector per account per Region.
    /// All data sources are enabled in a new detector by default.
    /// 
    ///  <ul><li><para>
    /// When you don't specify any <c>features</c>, with an exception to <c>RUNTIME_MONITORING</c>,
    /// all the optional features are enabled by default.
    /// </para></li><li><para>
    /// When you specify some of the <c>features</c>, any feature that is not specified in
    /// the API call gets enabled by default, with an exception to <c>RUNTIME_MONITORING</c>.
    /// 
    /// </para></li></ul><para>
    /// Specifying both EKS Runtime Monitoring (<c>EKS_RUNTIME_MONITORING</c>) and Runtime
    /// Monitoring (<c>RUNTIME_MONITORING</c>) will cause an error. You can add only one of
    /// these two features because Runtime Monitoring already includes the threat detection
    /// for Amazon EKS resources. For more information, see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/runtime-monitoring.html">Runtime
    /// Monitoring</a>.
    /// </para><para>
    /// There might be regional differences because some data sources might not be available
    /// in all the Amazon Web Services Regions where GuardDuty is presently supported. For
    /// more information, see <a href="https://docs.aws.amazon.com/guardduty/latest/ug/guardduty_regions.html">Regions
    /// and endpoints</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "GDDetector", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon GuardDuty CreateDetector API operation.", Operation = new[] {"CreateDetector"}, SelectReturnType = typeof(Amazon.GuardDuty.Model.CreateDetectorResponse))]
    [AWSCmdletOutput("System.String or Amazon.GuardDuty.Model.CreateDetectorResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GuardDuty.Model.CreateDetectorResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewGDDetectorCmdlet : AmazonGuardDutyClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter ScanEc2InstanceWithFindings_EbsVolume
        /// <summary>
        /// <para>
        /// <para>Describes the configuration for scanning EBS volumes as data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_MalwareProtection_ScanEc2InstanceWithFindings_EbsVolumes")]
        public System.Boolean? ScanEc2InstanceWithFindings_EbsVolume { get; set; }
        #endregion
        
        #region Parameter AuditLogs_Enable
        /// <summary>
        /// <para>
        /// <para>The status of Kubernetes audit logs as a data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_Kubernetes_AuditLogs_Enable")]
        public System.Boolean? AuditLogs_Enable { get; set; }
        #endregion
        
        #region Parameter S3Logs_Enable
        /// <summary>
        /// <para>
        /// <para> The status of S3 data event logs as a data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSources_S3Logs_Enable")]
        public System.Boolean? S3Logs_Enable { get; set; }
        #endregion
        
        #region Parameter Enable
        /// <summary>
        /// <para>
        /// <para>A Boolean value that specifies whether the detector is to be enabled.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Boolean? Enable { get; set; }
        #endregion
        
        #region Parameter Feature
        /// <summary>
        /// <para>
        /// <para>A list of features that will be configured for the detector.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Features")]
        public Amazon.GuardDuty.Model.DetectorFeatureConfiguration[] Feature { get; set; }
        #endregion
        
        #region Parameter FindingPublishingFrequency
        /// <summary>
        /// <para>
        /// <para>A value that specifies how frequently updated findings are exported.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GuardDuty.FindingPublishingFrequency")]
        public Amazon.GuardDuty.FindingPublishingFrequency FindingPublishingFrequency { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags to be added to a new detector resource.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>The idempotency token for the create request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DetectorId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GuardDuty.Model.CreateDetectorResponse).
        /// Specifying the name of a property of type Amazon.GuardDuty.Model.CreateDetectorResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DetectorId";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Enable), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-GDDetector (CreateDetector)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GuardDuty.Model.CreateDetectorResponse, NewGDDetectorCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.AuditLogs_Enable = this.AuditLogs_Enable;
            context.ScanEc2InstanceWithFindings_EbsVolume = this.ScanEc2InstanceWithFindings_EbsVolume;
            context.S3Logs_Enable = this.S3Logs_Enable;
            context.Enable = this.Enable;
            #if MODULAR
            if (this.Enable == null && ParameterWasBound(nameof(this.Enable)))
            {
                WriteWarning("You are passing $null as a value for parameter Enable which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Feature != null)
            {
                context.Feature = new List<Amazon.GuardDuty.Model.DetectorFeatureConfiguration>(this.Feature);
            }
            context.FindingPublishingFrequency = this.FindingPublishingFrequency;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.GuardDuty.Model.CreateDetectorRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DataSources
            var requestDataSourcesIsNull = true;
            request.DataSources = new Amazon.GuardDuty.Model.DataSourceConfigurations();
            Amazon.GuardDuty.Model.KubernetesConfiguration requestDataSources_dataSources_Kubernetes = null;
            
             // populate Kubernetes
            var requestDataSources_dataSources_KubernetesIsNull = true;
            requestDataSources_dataSources_Kubernetes = new Amazon.GuardDuty.Model.KubernetesConfiguration();
            Amazon.GuardDuty.Model.KubernetesAuditLogsConfiguration requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs = null;
            
             // populate AuditLogs
            var requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogsIsNull = true;
            requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs = new Amazon.GuardDuty.Model.KubernetesAuditLogsConfiguration();
            System.Boolean? requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_Enable = null;
            if (cmdletContext.AuditLogs_Enable != null)
            {
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_Enable = cmdletContext.AuditLogs_Enable.Value;
            }
            if (requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_Enable != null)
            {
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs.Enable = requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs_auditLogs_Enable.Value;
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogsIsNull = false;
            }
             // determine if requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs should be set to null
            if (requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogsIsNull)
            {
                requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs = null;
            }
            if (requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs != null)
            {
                requestDataSources_dataSources_Kubernetes.AuditLogs = requestDataSources_dataSources_Kubernetes_dataSources_Kubernetes_AuditLogs;
                requestDataSources_dataSources_KubernetesIsNull = false;
            }
             // determine if requestDataSources_dataSources_Kubernetes should be set to null
            if (requestDataSources_dataSources_KubernetesIsNull)
            {
                requestDataSources_dataSources_Kubernetes = null;
            }
            if (requestDataSources_dataSources_Kubernetes != null)
            {
                request.DataSources.Kubernetes = requestDataSources_dataSources_Kubernetes;
                requestDataSourcesIsNull = false;
            }
            Amazon.GuardDuty.Model.MalwareProtectionConfiguration requestDataSources_dataSources_MalwareProtection = null;
            
             // populate MalwareProtection
            var requestDataSources_dataSources_MalwareProtectionIsNull = true;
            requestDataSources_dataSources_MalwareProtection = new Amazon.GuardDuty.Model.MalwareProtectionConfiguration();
            Amazon.GuardDuty.Model.ScanEc2InstanceWithFindings requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings = null;
            
             // populate ScanEc2InstanceWithFindings
            var requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindingsIsNull = true;
            requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings = new Amazon.GuardDuty.Model.ScanEc2InstanceWithFindings();
            System.Boolean? requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_scanEc2InstanceWithFindings_EbsVolume = null;
            if (cmdletContext.ScanEc2InstanceWithFindings_EbsVolume != null)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_scanEc2InstanceWithFindings_EbsVolume = cmdletContext.ScanEc2InstanceWithFindings_EbsVolume.Value;
            }
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_scanEc2InstanceWithFindings_EbsVolume != null)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings.EbsVolumes = requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings_scanEc2InstanceWithFindings_EbsVolume.Value;
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindingsIsNull = false;
            }
             // determine if requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings should be set to null
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindingsIsNull)
            {
                requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings = null;
            }
            if (requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings != null)
            {
                requestDataSources_dataSources_MalwareProtection.ScanEc2InstanceWithFindings = requestDataSources_dataSources_MalwareProtection_dataSources_MalwareProtection_ScanEc2InstanceWithFindings;
                requestDataSources_dataSources_MalwareProtectionIsNull = false;
            }
             // determine if requestDataSources_dataSources_MalwareProtection should be set to null
            if (requestDataSources_dataSources_MalwareProtectionIsNull)
            {
                requestDataSources_dataSources_MalwareProtection = null;
            }
            if (requestDataSources_dataSources_MalwareProtection != null)
            {
                request.DataSources.MalwareProtection = requestDataSources_dataSources_MalwareProtection;
                requestDataSourcesIsNull = false;
            }
            Amazon.GuardDuty.Model.S3LogsConfiguration requestDataSources_dataSources_S3Logs = null;
            
             // populate S3Logs
            var requestDataSources_dataSources_S3LogsIsNull = true;
            requestDataSources_dataSources_S3Logs = new Amazon.GuardDuty.Model.S3LogsConfiguration();
            System.Boolean? requestDataSources_dataSources_S3Logs_s3Logs_Enable = null;
            if (cmdletContext.S3Logs_Enable != null)
            {
                requestDataSources_dataSources_S3Logs_s3Logs_Enable = cmdletContext.S3Logs_Enable.Value;
            }
            if (requestDataSources_dataSources_S3Logs_s3Logs_Enable != null)
            {
                requestDataSources_dataSources_S3Logs.Enable = requestDataSources_dataSources_S3Logs_s3Logs_Enable.Value;
                requestDataSources_dataSources_S3LogsIsNull = false;
            }
             // determine if requestDataSources_dataSources_S3Logs should be set to null
            if (requestDataSources_dataSources_S3LogsIsNull)
            {
                requestDataSources_dataSources_S3Logs = null;
            }
            if (requestDataSources_dataSources_S3Logs != null)
            {
                request.DataSources.S3Logs = requestDataSources_dataSources_S3Logs;
                requestDataSourcesIsNull = false;
            }
             // determine if request.DataSources should be set to null
            if (requestDataSourcesIsNull)
            {
                request.DataSources = null;
            }
            if (cmdletContext.Enable != null)
            {
                request.Enable = cmdletContext.Enable.Value;
            }
            if (cmdletContext.Feature != null)
            {
                request.Features = cmdletContext.Feature;
            }
            if (cmdletContext.FindingPublishingFrequency != null)
            {
                request.FindingPublishingFrequency = cmdletContext.FindingPublishingFrequency;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.GuardDuty.Model.CreateDetectorResponse CallAWSServiceOperation(IAmazonGuardDuty client, Amazon.GuardDuty.Model.CreateDetectorRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon GuardDuty", "CreateDetector");
            try
            {
                return client.CreateDetectorAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Boolean? AuditLogs_Enable { get; set; }
            public System.Boolean? ScanEc2InstanceWithFindings_EbsVolume { get; set; }
            public System.Boolean? S3Logs_Enable { get; set; }
            public System.Boolean? Enable { get; set; }
            public List<Amazon.GuardDuty.Model.DetectorFeatureConfiguration> Feature { get; set; }
            public Amazon.GuardDuty.FindingPublishingFrequency FindingPublishingFrequency { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.GuardDuty.Model.CreateDetectorResponse, NewGDDetectorCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DetectorId;
        }
        
    }
}
