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
using Amazon.AppSync;
using Amazon.AppSync.Model;

namespace Amazon.PowerShell.Cmdlets.ASYN
{
    /// <summary>
    /// Creates a <c>DataSource</c> object.
    /// </summary>
    [Cmdlet("New", "ASYNDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.DataSource")]
    [AWSCmdlet("Calls the AWS AppSync CreateDataSource API operation.", Operation = new[] {"CreateDataSource"}, SelectReturnType = typeof(Amazon.AppSync.Model.CreateDataSourceResponse))]
    [AWSCmdletOutput("Amazon.AppSync.Model.DataSource or Amazon.AppSync.Model.CreateDataSourceResponse",
        "This cmdlet returns an Amazon.AppSync.Model.DataSource object.",
        "The service call response (type Amazon.AppSync.Model.CreateDataSourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewASYNDataSourceCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API ID for the GraphQL API for the <c>DataSource</c>.</para>
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
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter HttpConfig_AuthorizationConfig
        /// <summary>
        /// <para>
        /// <para>The authorization configuration in case the HTTP endpoint requires authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppSync.Model.AuthorizationConfig HttpConfig_AuthorizationConfig { get; set; }
        #endregion
        
        #region Parameter OpenSearchServiceConfig_AwsRegion
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services Region.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenSearchServiceConfig_AwsRegion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the <c>DataSource</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DynamodbConfig
        /// <summary>
        /// <para>
        /// <para>Amazon DynamoDB settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppSync.Model.DynamodbDataSourceConfig DynamodbConfig { get; set; }
        #endregion
        
        #region Parameter ElasticsearchConfig
        /// <summary>
        /// <para>
        /// <para>Amazon OpenSearch Service settings.</para><para>As of September 2021, Amazon Elasticsearch service is Amazon OpenSearch Service. This
        /// configuration is deprecated. For new data sources, use <a>CreateDataSourceRequest$openSearchServiceConfig</a>
        /// to create an OpenSearch data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppSync.Model.ElasticsearchDataSourceConfig ElasticsearchConfig { get; set; }
        #endregion
        
        #region Parameter HttpConfig_Endpoint
        /// <summary>
        /// <para>
        /// <para>The HTTP URL endpoint. You can specify either the domain name or IP, and port combination,
        /// and the URL scheme must be HTTP or HTTPS. If you don't specify the port, AppSync uses
        /// the default port 80 for the HTTP endpoint and port 443 for HTTPS endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String HttpConfig_Endpoint { get; set; }
        #endregion
        
        #region Parameter OpenSearchServiceConfig_Endpoint
        /// <summary>
        /// <para>
        /// <para>The endpoint.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OpenSearchServiceConfig_Endpoint { get; set; }
        #endregion
        
        #region Parameter EventBridgeConfig_EventBusArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the event bus. For more information about event buses, see <a href="https://docs.aws.amazon.com/eventbridge/latest/userguide/eb-event-bus.html">Amazon
        /// EventBridge event buses</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EventBridgeConfig_EventBusArn { get; set; }
        #endregion
        
        #region Parameter LambdaConfig
        /// <summary>
        /// <para>
        /// <para>Lambda settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppSync.Model.LambdaDataSourceConfig LambdaConfig { get; set; }
        #endregion
        
        #region Parameter MetricsConfig
        /// <summary>
        /// <para>
        /// <para>Enables or disables enhanced data source metrics for specified data sources. Note
        /// that <c>metricsConfig</c> won't be used unless the <c>dataSourceLevelMetricsBehavior</c>
        /// value is set to <c>PER_DATA_SOURCE_METRICS</c>. If the <c>dataSourceLevelMetricsBehavior</c>
        /// is set to <c>FULL_REQUEST_DATA_SOURCE_METRICS</c> instead, <c>metricsConfig</c> will
        /// be ignored. However, you can still set its value.</para><para><c>metricsConfig</c> can be <c>ENABLED</c> or <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.DataSourceLevelMetricsConfig")]
        public Amazon.AppSync.DataSourceLevelMetricsConfig MetricsConfig { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A user-supplied name for the <c>DataSource</c>.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseConfig_RdsHttpEndpointConfig
        /// <summary>
        /// <para>
        /// <para>Amazon RDS HTTP endpoint settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.AppSync.Model.RdsHttpEndpointConfig RelationalDatabaseConfig_RdsHttpEndpointConfig { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseConfig_RelationalDatabaseSourceType
        /// <summary>
        /// <para>
        /// <para>Source type for the relational database.</para><ul><li><para><b>RDS_HTTP_ENDPOINT</b>: The relational database source type is an Amazon Relational
        /// Database Service (Amazon RDS) HTTP endpoint.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.AppSync.RelationalDatabaseSourceType")]
        public Amazon.AppSync.RelationalDatabaseSourceType RelationalDatabaseConfig_RelationalDatabaseSourceType { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The Identity and Access Management (IAM) service role Amazon Resource Name (ARN) for
        /// the data source. The system assumes this role when accessing the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the <c>DataSource</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.AppSync.DataSourceType")]
        public Amazon.AppSync.DataSourceType Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSource'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.AppSync.Model.CreateDataSourceResponse).
        /// Specifying the name of a property of type Amazon.AppSync.Model.CreateDataSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataSource";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASYNDataSource (CreateDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.AppSync.Model.CreateDataSourceResponse, NewASYNDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiId = this.ApiId;
            #if MODULAR
            if (this.ApiId == null && ParameterWasBound(nameof(this.ApiId)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DynamodbConfig = this.DynamodbConfig;
            context.ElasticsearchConfig = this.ElasticsearchConfig;
            context.EventBridgeConfig_EventBusArn = this.EventBridgeConfig_EventBusArn;
            context.HttpConfig_AuthorizationConfig = this.HttpConfig_AuthorizationConfig;
            context.HttpConfig_Endpoint = this.HttpConfig_Endpoint;
            context.LambdaConfig = this.LambdaConfig;
            context.MetricsConfig = this.MetricsConfig;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OpenSearchServiceConfig_AwsRegion = this.OpenSearchServiceConfig_AwsRegion;
            context.OpenSearchServiceConfig_Endpoint = this.OpenSearchServiceConfig_Endpoint;
            context.RelationalDatabaseConfig_RdsHttpEndpointConfig = this.RelationalDatabaseConfig_RdsHttpEndpointConfig;
            context.RelationalDatabaseConfig_RelationalDatabaseSourceType = this.RelationalDatabaseConfig_RelationalDatabaseSourceType;
            context.ServiceRoleArn = this.ServiceRoleArn;
            context.Type = this.Type;
            #if MODULAR
            if (this.Type == null && ParameterWasBound(nameof(this.Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.AppSync.Model.CreateDataSourceRequest();
            
            if (cmdletContext.ApiId != null)
            {
                request.ApiId = cmdletContext.ApiId;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DynamodbConfig != null)
            {
                request.DynamodbConfig = cmdletContext.DynamodbConfig;
            }
            if (cmdletContext.ElasticsearchConfig != null)
            {
                request.ElasticsearchConfig = cmdletContext.ElasticsearchConfig;
            }
            
             // populate EventBridgeConfig
            var requestEventBridgeConfigIsNull = true;
            request.EventBridgeConfig = new Amazon.AppSync.Model.EventBridgeDataSourceConfig();
            System.String requestEventBridgeConfig_eventBridgeConfig_EventBusArn = null;
            if (cmdletContext.EventBridgeConfig_EventBusArn != null)
            {
                requestEventBridgeConfig_eventBridgeConfig_EventBusArn = cmdletContext.EventBridgeConfig_EventBusArn;
            }
            if (requestEventBridgeConfig_eventBridgeConfig_EventBusArn != null)
            {
                request.EventBridgeConfig.EventBusArn = requestEventBridgeConfig_eventBridgeConfig_EventBusArn;
                requestEventBridgeConfigIsNull = false;
            }
             // determine if request.EventBridgeConfig should be set to null
            if (requestEventBridgeConfigIsNull)
            {
                request.EventBridgeConfig = null;
            }
            
             // populate HttpConfig
            var requestHttpConfigIsNull = true;
            request.HttpConfig = new Amazon.AppSync.Model.HttpDataSourceConfig();
            Amazon.AppSync.Model.AuthorizationConfig requestHttpConfig_httpConfig_AuthorizationConfig = null;
            if (cmdletContext.HttpConfig_AuthorizationConfig != null)
            {
                requestHttpConfig_httpConfig_AuthorizationConfig = cmdletContext.HttpConfig_AuthorizationConfig;
            }
            if (requestHttpConfig_httpConfig_AuthorizationConfig != null)
            {
                request.HttpConfig.AuthorizationConfig = requestHttpConfig_httpConfig_AuthorizationConfig;
                requestHttpConfigIsNull = false;
            }
            System.String requestHttpConfig_httpConfig_Endpoint = null;
            if (cmdletContext.HttpConfig_Endpoint != null)
            {
                requestHttpConfig_httpConfig_Endpoint = cmdletContext.HttpConfig_Endpoint;
            }
            if (requestHttpConfig_httpConfig_Endpoint != null)
            {
                request.HttpConfig.Endpoint = requestHttpConfig_httpConfig_Endpoint;
                requestHttpConfigIsNull = false;
            }
             // determine if request.HttpConfig should be set to null
            if (requestHttpConfigIsNull)
            {
                request.HttpConfig = null;
            }
            if (cmdletContext.LambdaConfig != null)
            {
                request.LambdaConfig = cmdletContext.LambdaConfig;
            }
            if (cmdletContext.MetricsConfig != null)
            {
                request.MetricsConfig = cmdletContext.MetricsConfig;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OpenSearchServiceConfig
            var requestOpenSearchServiceConfigIsNull = true;
            request.OpenSearchServiceConfig = new Amazon.AppSync.Model.OpenSearchServiceDataSourceConfig();
            System.String requestOpenSearchServiceConfig_openSearchServiceConfig_AwsRegion = null;
            if (cmdletContext.OpenSearchServiceConfig_AwsRegion != null)
            {
                requestOpenSearchServiceConfig_openSearchServiceConfig_AwsRegion = cmdletContext.OpenSearchServiceConfig_AwsRegion;
            }
            if (requestOpenSearchServiceConfig_openSearchServiceConfig_AwsRegion != null)
            {
                request.OpenSearchServiceConfig.AwsRegion = requestOpenSearchServiceConfig_openSearchServiceConfig_AwsRegion;
                requestOpenSearchServiceConfigIsNull = false;
            }
            System.String requestOpenSearchServiceConfig_openSearchServiceConfig_Endpoint = null;
            if (cmdletContext.OpenSearchServiceConfig_Endpoint != null)
            {
                requestOpenSearchServiceConfig_openSearchServiceConfig_Endpoint = cmdletContext.OpenSearchServiceConfig_Endpoint;
            }
            if (requestOpenSearchServiceConfig_openSearchServiceConfig_Endpoint != null)
            {
                request.OpenSearchServiceConfig.Endpoint = requestOpenSearchServiceConfig_openSearchServiceConfig_Endpoint;
                requestOpenSearchServiceConfigIsNull = false;
            }
             // determine if request.OpenSearchServiceConfig should be set to null
            if (requestOpenSearchServiceConfigIsNull)
            {
                request.OpenSearchServiceConfig = null;
            }
            
             // populate RelationalDatabaseConfig
            var requestRelationalDatabaseConfigIsNull = true;
            request.RelationalDatabaseConfig = new Amazon.AppSync.Model.RelationalDatabaseDataSourceConfig();
            Amazon.AppSync.Model.RdsHttpEndpointConfig requestRelationalDatabaseConfig_relationalDatabaseConfig_RdsHttpEndpointConfig = null;
            if (cmdletContext.RelationalDatabaseConfig_RdsHttpEndpointConfig != null)
            {
                requestRelationalDatabaseConfig_relationalDatabaseConfig_RdsHttpEndpointConfig = cmdletContext.RelationalDatabaseConfig_RdsHttpEndpointConfig;
            }
            if (requestRelationalDatabaseConfig_relationalDatabaseConfig_RdsHttpEndpointConfig != null)
            {
                request.RelationalDatabaseConfig.RdsHttpEndpointConfig = requestRelationalDatabaseConfig_relationalDatabaseConfig_RdsHttpEndpointConfig;
                requestRelationalDatabaseConfigIsNull = false;
            }
            Amazon.AppSync.RelationalDatabaseSourceType requestRelationalDatabaseConfig_relationalDatabaseConfig_RelationalDatabaseSourceType = null;
            if (cmdletContext.RelationalDatabaseConfig_RelationalDatabaseSourceType != null)
            {
                requestRelationalDatabaseConfig_relationalDatabaseConfig_RelationalDatabaseSourceType = cmdletContext.RelationalDatabaseConfig_RelationalDatabaseSourceType;
            }
            if (requestRelationalDatabaseConfig_relationalDatabaseConfig_RelationalDatabaseSourceType != null)
            {
                request.RelationalDatabaseConfig.RelationalDatabaseSourceType = requestRelationalDatabaseConfig_relationalDatabaseConfig_RelationalDatabaseSourceType;
                requestRelationalDatabaseConfigIsNull = false;
            }
             // determine if request.RelationalDatabaseConfig should be set to null
            if (requestRelationalDatabaseConfigIsNull)
            {
                request.RelationalDatabaseConfig = null;
            }
            if (cmdletContext.ServiceRoleArn != null)
            {
                request.ServiceRoleArn = cmdletContext.ServiceRoleArn;
            }
            if (cmdletContext.Type != null)
            {
                request.Type = cmdletContext.Type;
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
        
        private Amazon.AppSync.Model.CreateDataSourceResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.CreateDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "CreateDataSource");
            try
            {
                #if DESKTOP
                return client.CreateDataSource(request);
                #elif CORECLR
                return client.CreateDataSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String ApiId { get; set; }
            public System.String Description { get; set; }
            public Amazon.AppSync.Model.DynamodbDataSourceConfig DynamodbConfig { get; set; }
            public Amazon.AppSync.Model.ElasticsearchDataSourceConfig ElasticsearchConfig { get; set; }
            public System.String EventBridgeConfig_EventBusArn { get; set; }
            public Amazon.AppSync.Model.AuthorizationConfig HttpConfig_AuthorizationConfig { get; set; }
            public System.String HttpConfig_Endpoint { get; set; }
            public Amazon.AppSync.Model.LambdaDataSourceConfig LambdaConfig { get; set; }
            public Amazon.AppSync.DataSourceLevelMetricsConfig MetricsConfig { get; set; }
            public System.String Name { get; set; }
            public System.String OpenSearchServiceConfig_AwsRegion { get; set; }
            public System.String OpenSearchServiceConfig_Endpoint { get; set; }
            public Amazon.AppSync.Model.RdsHttpEndpointConfig RelationalDatabaseConfig_RdsHttpEndpointConfig { get; set; }
            public Amazon.AppSync.RelationalDatabaseSourceType RelationalDatabaseConfig_RelationalDatabaseSourceType { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public Amazon.AppSync.DataSourceType Type { get; set; }
            public System.Func<Amazon.AppSync.Model.CreateDataSourceResponse, NewASYNDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSource;
        }
        
    }
}
