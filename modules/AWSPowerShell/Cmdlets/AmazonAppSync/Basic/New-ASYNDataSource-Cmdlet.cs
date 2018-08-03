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
    /// Creates a <code>DataSource</code> object.
    /// </summary>
    [Cmdlet("New", "ASYNDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.AppSync.Model.DataSource")]
    [AWSCmdlet("Calls the AWS AppSync CreateDataSource API operation.", Operation = new[] {"CreateDataSource"})]
    [AWSCmdletOutput("Amazon.AppSync.Model.DataSource",
        "This cmdlet returns a DataSource object.",
        "The service call response (type Amazon.AppSync.Model.CreateDataSourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewASYNDataSourceCmdlet : AmazonAppSyncClientCmdlet, IExecutor
    {
        
        #region Parameter ApiId
        /// <summary>
        /// <para>
        /// <para>The API ID for the GraphQL API for the <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ApiId { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DynamodbConfig
        /// <summary>
        /// <para>
        /// <para>DynamoDB settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.DynamodbDataSourceConfig DynamodbConfig { get; set; }
        #endregion
        
        #region Parameter ElasticsearchConfig
        /// <summary>
        /// <para>
        /// <para>Amazon Elasticsearch settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.ElasticsearchDataSourceConfig ElasticsearchConfig { get; set; }
        #endregion
        
        #region Parameter HttpConfig_Endpoint
        /// <summary>
        /// <para>
        /// <para>The Http url endpoint. You can either specify the domain name or ip and port combination
        /// and the url scheme must be http(s). If the port is not specified, AWS AppSync will
        /// use the default port 80 for http endpoint and port 443 for https endpoints.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String HttpConfig_Endpoint { get; set; }
        #endregion
        
        #region Parameter LambdaConfig
        /// <summary>
        /// <para>
        /// <para>AWS Lambda settings.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.AppSync.Model.LambdaDataSourceConfig LambdaConfig { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>A user-supplied name for the <code>DataSource</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ServiceRoleArn
        /// <summary>
        /// <para>
        /// <para>The IAM service role ARN for the data source. The system assumes this role when accessing
        /// the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleArn { get; set; }
        #endregion
        
        #region Parameter Type
        /// <summary>
        /// <para>
        /// <para>The type of the <code>DataSource</code>.</para>
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-ASYNDataSource (CreateDataSource)"))
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
            context.HttpConfig_Endpoint = this.HttpConfig_Endpoint;
            context.LambdaConfig = this.LambdaConfig;
            context.Name = this.Name;
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
            
             // populate HttpConfig
            bool requestHttpConfigIsNull = true;
            request.HttpConfig = new Amazon.AppSync.Model.HttpDataSourceConfig();
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
        
        private Amazon.AppSync.Model.CreateDataSourceResponse CallAWSServiceOperation(IAmazonAppSync client, Amazon.AppSync.Model.CreateDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS AppSync", "CreateDataSource");
            try
            {
                #if DESKTOP
                return client.CreateDataSource(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateDataSourceAsync(request);
                return task.Result;
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
            public System.String HttpConfig_Endpoint { get; set; }
            public Amazon.AppSync.Model.LambdaDataSourceConfig LambdaConfig { get; set; }
            public System.String Name { get; set; }
            public System.String ServiceRoleArn { get; set; }
            public Amazon.AppSync.DataSourceType Type { get; set; }
        }
        
    }
}
