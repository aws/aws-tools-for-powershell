/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Updates a <code>DataSource</code> object.
    /// </summary>
    [Cmdlet("Update", "ASYNDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.DataSource")]
    [AWSCmdlet("Calls the AWS AppSync UpdateDataSource API operation.", Operation = new[] {"UpdateDataSource"})]
    [AWSCmdletOutput("Amazon.AppSync.Model.DataSource",
        "This cmdlet returns a DataSource object.",
        "The service call response (type Amazon.AppSync.Model.UpdateDataSourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateASYNDataSourceCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API ID.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter HttpConfig_AuthorizationConfig
        /// <summary>
        /// <para>
        /// <para>The authorization config in case the HTTP endpoint requires authorization.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.AuthorizationConfig HttpConfig_AuthorizationConfig { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The new description for the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DynamodbConfig
        /// <summary>
        /// <para>
        /// <para>The new Amazon DynamoDB configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.DynamodbDataSourceConfig DynamodbConfig { get; set; }
        #endregion
        
        #region Parameter ElasticsearchConfig
        /// <summary>
        /// <para>
        /// <para>The new Elasticsearch Service configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.ElasticsearchDataSourceConfig ElasticsearchConfig { get; set; }
        #endregion
        
        #region Parameter HttpConfig_Endpoint
        /// <summary>
        /// <para>
        /// <para>The HTTP URL endpoint. You can either specify the domain name or IP, and port combination,
        /// and the URL scheme must be HTTP or HTTPS. If the port is not specified, AWS AppSync
        /// uses the default port 80 for the HTTP endpoint and port 443 for HTTPS endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HttpConfig_Endpoint { get; set; }
        #endregion
        
        #region Parameter LambdaConfig
        /// <summary>
        /// <para>
        /// <para>The new AWS Lambda configuration.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.LambdaDataSourceConfig LambdaConfig { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The new name for the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseConfig_RdsHttpEndpointConfig
        /// <summary>
        /// <para>
        /// <para>Amazon RDS HTTP endpoint settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.RdsHttpEndpointConfig RelationalDatabaseConfig_RdsHttpEndpointConfig { get; set; }
        #endregion
        
        #region Parameter RelationalDatabaseConfig_RelationalDatabaseSourceType
        /// <summary>
        /// <para>
        /// <para>Source type for the relational database.</para><ul><li><para><b>RDS_HTTP_ENDPOINT</b>: The relational database source type is an Amazon RDS HTTP
        /// endpoint.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AppSync.RelationalDatabaseSourceType")]
        public Amazon.AppSync.RelationalDatabaseSourceType RelationalDatabaseConfig_RelationalDatabaseSourceType { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The new service role ARN for the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The new data source type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.AppSync.DataSourceType")]
        public Amazon.AppSync.DataSourceType Type { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ASYNDataSource (UpdateDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApiId = this.ApiId;
            context.Description = this.Description;
            context.DynamodbConfig = this.DynamodbConfig;
            context.ElasticsearchConfig = this.ElasticsearchConfig;
            context.HttpConfig_AuthorizationConfig = this.HttpConfig_AuthorizationConfig;
            context.HttpConfig_Endpoint = this.HttpConfig_Endpoint;
            context.LambdaConfig = this.LambdaConfig;
            context.Name = this.Name;
            context.RelationalDatabaseConfig_RdsHttpEndpointConfig = this.RelationalDatabaseConfig_RdsHttpEndpointConfig;
            context.RelationalDatabaseConfig_RelationalDatabaseSourceType = this.RelationalDatabaseConfig_RelationalDatabaseSourceType;
            context.ServiceRoleArn = this.ServiceRoleArn;
            context.Type = this.Type;
            
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
            var request = new Amazon.AppSync.Model.UpdateDataSourceRequest();
            
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
            
             // populate HttpConfig
            bool requestHttpConfigIsNull = true;
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
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate RelationalDatabaseConfig
            bool requestRelationalDatabaseConfigIsNull = true;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.DataSource;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.AppSync.Model.UpdateDataSourceResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.UpdateDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "UpdateDataSource");
            try
            {
                #if DESKTOP
                return client.UpdateDataSource(request);
                #elif CORECLR
                return client.UpdateDataSourceAsync(request).GetAwaiter().GetResult();
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
            public Amazon.AppSync.Model.AuthorizationConfig HttpConfig_AuthorizationConfig { get; set; }
            public System.String HttpConfig_Endpoint { get; set; }
            public Amazon.AppSync.Model.LambdaDataSourceConfig LambdaConfig { get; set; }
            public System.String Name { get; set; }
            public Amazon.AppSync.Model.RdsHttpEndpointConfig RelationalDatabaseConfig_RdsHttpEndpointConfig { get; set; }
            public Amazon.AppSync.RelationalDatabaseSourceType RelationalDatabaseConfig_RelationalDatabaseSourceType { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public Amazon.AppSync.DataSourceType Type { get; set; }
        }
        
    }
}
