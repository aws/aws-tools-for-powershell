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
using Amazon.CloudWatchLogs;
using Amazon.CloudWatchLogs.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CWL
{
    /// <summary>
    /// Creates an integration between CloudWatch Logs and another service in this account.
    /// Currently, only integrations with OpenSearch Service are supported, and currently
    /// you can have only one integration in your account.
    /// 
    ///  
    /// <para>
    /// Integrating with OpenSearch Service makes it possible for you to create curated vended
    /// logs dashboards, powered by OpenSearch Service analytics. For more information, see
    /// <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/CloudWatchLogs-OpenSearch-Dashboards.html">Vended
    /// log dashboards powered by Amazon OpenSearch Service</a>.
    /// </para><para>
    /// You can use this operation only to create a new integration. You can't modify an existing
    /// integration.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "CWLIntegration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CloudWatchLogs.Model.PutIntegrationResponse")]
    [AWSCmdlet("Calls the Amazon CloudWatch Logs PutIntegration API operation.", Operation = new[] {"PutIntegration"}, SelectReturnType = typeof(Amazon.CloudWatchLogs.Model.PutIntegrationResponse))]
    [AWSCmdletOutput("Amazon.CloudWatchLogs.Model.PutIntegrationResponse",
        "This cmdlet returns an Amazon.CloudWatchLogs.Model.PutIntegrationResponse object containing multiple properties."
    )]
    public partial class WriteCWLIntegrationCmdlet : AmazonCloudWatchLogsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter OpenSearchResourceConfig_ApplicationArn
        /// <summary>
        /// <para>
        /// <para>If you want to use an existing OpenSearch Service application for your integration
        /// with OpenSearch Service, specify it here. If you omit this, a new application will
        /// be created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_OpenSearchResourceConfig_ApplicationArn")]
        public System.String OpenSearchResourceConfig_ApplicationArn { get; set; }
        #endregion
        
        #region Parameter OpenSearchResourceConfig_DashboardViewerPrincipal
        /// <summary>
        /// <para>
        /// <para>Specify the ARNs of IAM roles and IAM users who you want to grant permission to for
        /// viewing the dashboards.</para><important><para>In addition to specifying these users here, you must also grant them the <b>CloudWatchOpenSearchDashboardAccess</b>
        /// IAM policy. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/OpenSearch-Dashboards-UserRoles.html">IAM
        /// policies for users</a>.</para></important><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_OpenSearchResourceConfig_DashboardViewerPrincipals")]
        public System.String[] OpenSearchResourceConfig_DashboardViewerPrincipal { get; set; }
        #endregion
        
        #region Parameter OpenSearchResourceConfig_DataSourceRoleArn
        /// <summary>
        /// <para>
        /// <para>Specify the ARN of an IAM role that CloudWatch Logs will use to create the integration.
        /// This role must have the permissions necessary to access the OpenSearch Service collection
        /// to be able to create the dashboards. For more information about the permissions needed,
        /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/OpenSearch-Dashboards-CreateRole.html">Permissions
        /// that the integration needs</a> in the CloudWatch Logs User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_OpenSearchResourceConfig_DataSourceRoleArn")]
        public System.String OpenSearchResourceConfig_DataSourceRoleArn { get; set; }
        #endregion
        
        #region Parameter IntegrationName
        /// <summary>
        /// <para>
        /// <para>A name for the integration.</para>
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
        public System.String IntegrationName { get; set; }
        #endregion
        
        #region Parameter IntegrationType
        /// <summary>
        /// <para>
        /// <para>The type of integration. Currently, the only supported type is <c>OPENSEARCH</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CloudWatchLogs.IntegrationType")]
        public Amazon.CloudWatchLogs.IntegrationType IntegrationType { get; set; }
        #endregion
        
        #region Parameter OpenSearchResourceConfig_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>To have the vended dashboard data encrypted with KMS instead of the CloudWatch Logs
        /// default encryption method, specify the ARN of the KMS key that you want to use.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_OpenSearchResourceConfig_KmsKeyArn")]
        public System.String OpenSearchResourceConfig_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter OpenSearchResourceConfig_RetentionDay
        /// <summary>
        /// <para>
        /// <para>Specify how many days that you want the data derived by OpenSearch Service to be retained
        /// in the index that the dashboard refers to. This also sets the maximum time period
        /// that you can choose when viewing data in the dashboard. Choosing a longer time frame
        /// will incur additional costs. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceConfig_OpenSearchResourceConfig_RetentionDays")]
        public System.Int32? OpenSearchResourceConfig_RetentionDay { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CloudWatchLogs.Model.PutIntegrationResponse).
        /// Specifying the name of a property of type Amazon.CloudWatchLogs.Model.PutIntegrationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IntegrationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-CWLIntegration (PutIntegration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CloudWatchLogs.Model.PutIntegrationResponse, WriteCWLIntegrationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.IntegrationName = this.IntegrationName;
            #if MODULAR
            if (this.IntegrationName == null && ParameterWasBound(nameof(this.IntegrationName)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntegrationType = this.IntegrationType;
            #if MODULAR
            if (this.IntegrationType == null && ParameterWasBound(nameof(this.IntegrationType)))
            {
                WriteWarning("You are passing $null as a value for parameter IntegrationType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OpenSearchResourceConfig_ApplicationArn = this.OpenSearchResourceConfig_ApplicationArn;
            if (this.OpenSearchResourceConfig_DashboardViewerPrincipal != null)
            {
                context.OpenSearchResourceConfig_DashboardViewerPrincipal = new List<System.String>(this.OpenSearchResourceConfig_DashboardViewerPrincipal);
            }
            context.OpenSearchResourceConfig_DataSourceRoleArn = this.OpenSearchResourceConfig_DataSourceRoleArn;
            context.OpenSearchResourceConfig_KmsKeyArn = this.OpenSearchResourceConfig_KmsKeyArn;
            context.OpenSearchResourceConfig_RetentionDay = this.OpenSearchResourceConfig_RetentionDay;
            
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
            var request = new Amazon.CloudWatchLogs.Model.PutIntegrationRequest();
            
            if (cmdletContext.IntegrationName != null)
            {
                request.IntegrationName = cmdletContext.IntegrationName;
            }
            if (cmdletContext.IntegrationType != null)
            {
                request.IntegrationType = cmdletContext.IntegrationType;
            }
            
             // populate ResourceConfig
            request.ResourceConfig = new Amazon.CloudWatchLogs.Model.ResourceConfig();
            Amazon.CloudWatchLogs.Model.OpenSearchResourceConfig requestResourceConfig_resourceConfig_OpenSearchResourceConfig = null;
            
             // populate OpenSearchResourceConfig
            var requestResourceConfig_resourceConfig_OpenSearchResourceConfigIsNull = true;
            requestResourceConfig_resourceConfig_OpenSearchResourceConfig = new Amazon.CloudWatchLogs.Model.OpenSearchResourceConfig();
            System.String requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_ApplicationArn = null;
            if (cmdletContext.OpenSearchResourceConfig_ApplicationArn != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_ApplicationArn = cmdletContext.OpenSearchResourceConfig_ApplicationArn;
            }
            if (requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_ApplicationArn != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig.ApplicationArn = requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_ApplicationArn;
                requestResourceConfig_resourceConfig_OpenSearchResourceConfigIsNull = false;
            }
            List<System.String> requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_DashboardViewerPrincipal = null;
            if (cmdletContext.OpenSearchResourceConfig_DashboardViewerPrincipal != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_DashboardViewerPrincipal = cmdletContext.OpenSearchResourceConfig_DashboardViewerPrincipal;
            }
            if (requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_DashboardViewerPrincipal != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig.DashboardViewerPrincipals = requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_DashboardViewerPrincipal;
                requestResourceConfig_resourceConfig_OpenSearchResourceConfigIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_DataSourceRoleArn = null;
            if (cmdletContext.OpenSearchResourceConfig_DataSourceRoleArn != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_DataSourceRoleArn = cmdletContext.OpenSearchResourceConfig_DataSourceRoleArn;
            }
            if (requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_DataSourceRoleArn != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig.DataSourceRoleArn = requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_DataSourceRoleArn;
                requestResourceConfig_resourceConfig_OpenSearchResourceConfigIsNull = false;
            }
            System.String requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_KmsKeyArn = null;
            if (cmdletContext.OpenSearchResourceConfig_KmsKeyArn != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_KmsKeyArn = cmdletContext.OpenSearchResourceConfig_KmsKeyArn;
            }
            if (requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_KmsKeyArn != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig.KmsKeyArn = requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_KmsKeyArn;
                requestResourceConfig_resourceConfig_OpenSearchResourceConfigIsNull = false;
            }
            System.Int32? requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_RetentionDay = null;
            if (cmdletContext.OpenSearchResourceConfig_RetentionDay != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_RetentionDay = cmdletContext.OpenSearchResourceConfig_RetentionDay.Value;
            }
            if (requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_RetentionDay != null)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig.RetentionDays = requestResourceConfig_resourceConfig_OpenSearchResourceConfig_openSearchResourceConfig_RetentionDay.Value;
                requestResourceConfig_resourceConfig_OpenSearchResourceConfigIsNull = false;
            }
             // determine if requestResourceConfig_resourceConfig_OpenSearchResourceConfig should be set to null
            if (requestResourceConfig_resourceConfig_OpenSearchResourceConfigIsNull)
            {
                requestResourceConfig_resourceConfig_OpenSearchResourceConfig = null;
            }
            if (requestResourceConfig_resourceConfig_OpenSearchResourceConfig != null)
            {
                request.ResourceConfig.OpenSearchResourceConfig = requestResourceConfig_resourceConfig_OpenSearchResourceConfig;
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
        
        private Amazon.CloudWatchLogs.Model.PutIntegrationResponse CallAWSServiceOperation(IAmazonCloudWatchLogs client, Amazon.CloudWatchLogs.Model.PutIntegrationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Logs", "PutIntegration");
            try
            {
                return client.PutIntegrationAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String IntegrationName { get; set; }
            public Amazon.CloudWatchLogs.IntegrationType IntegrationType { get; set; }
            public System.String OpenSearchResourceConfig_ApplicationArn { get; set; }
            public List<System.String> OpenSearchResourceConfig_DashboardViewerPrincipal { get; set; }
            public System.String OpenSearchResourceConfig_DataSourceRoleArn { get; set; }
            public System.String OpenSearchResourceConfig_KmsKeyArn { get; set; }
            public System.Int32? OpenSearchResourceConfig_RetentionDay { get; set; }
            public System.Func<Amazon.CloudWatchLogs.Model.PutIntegrationResponse, WriteCWLIntegrationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
