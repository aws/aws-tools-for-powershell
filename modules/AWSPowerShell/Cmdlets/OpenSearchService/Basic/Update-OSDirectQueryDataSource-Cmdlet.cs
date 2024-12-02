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
using Amazon.OpenSearchService;
using Amazon.OpenSearchService.Model;

namespace Amazon.PowerShell.Cmdlets.OS
{
    /// <summary>
    /// Updates the configuration or properties of an existing direct query data source in
    /// Amazon OpenSearch Service.
    /// </summary>
    [Cmdlet("Update", "OSDirectQueryDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service UpdateDirectQueryDataSource API operation.", Operation = new[] {"UpdateDirectQueryDataSource"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceResponse))]
    [AWSCmdletOutput("System.String or Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOSDirectQueryDataSourceCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DataSourceName
        /// <summary>
        /// <para>
        /// <para> A unique, user-defined label to identify the data source within your OpenSearch Service
        /// environment. </para>
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
        public System.String DataSourceName { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> An optional text field for providing additional context and details about the data
        /// source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OpenSearchArn
        /// <summary>
        /// <para>
        /// <para> A list of Amazon Resource Names (ARNs) for the OpenSearch collections that are associated
        /// with the direct query data source. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("OpenSearchArns")]
        public System.String[] OpenSearchArn { get; set; }
        #endregion
        
        #region Parameter CloudWatchLog_RoleArn
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the IAM role that grants OpenSearch Service permission to
        /// access the specified data source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceType_CloudWatchLog_RoleArn")]
        public System.String CloudWatchLog_RoleArn { get; set; }
        #endregion
        
        #region Parameter SecurityLake_RoleArn
        /// <summary>
        /// <para>
        /// <para> The unique identifier of the IAM role that grants OpenSearch Service permission to
        /// access the specified data source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceType_SecurityLake_RoleArn")]
        public System.String SecurityLake_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DataSourceArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DataSourceArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DataSourceName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DataSourceName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DataSourceName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DataSourceName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OSDirectQueryDataSource (UpdateDirectQueryDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceResponse, UpdateOSDirectQueryDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DataSourceName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DataSourceName = this.DataSourceName;
            #if MODULAR
            if (this.DataSourceName == null && ParameterWasBound(nameof(this.DataSourceName)))
            {
                WriteWarning("You are passing $null as a value for parameter DataSourceName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLog_RoleArn = this.CloudWatchLog_RoleArn;
            context.SecurityLake_RoleArn = this.SecurityLake_RoleArn;
            context.Description = this.Description;
            if (this.OpenSearchArn != null)
            {
                context.OpenSearchArn = new List<System.String>(this.OpenSearchArn);
            }
            #if MODULAR
            if (this.OpenSearchArn == null && ParameterWasBound(nameof(this.OpenSearchArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OpenSearchArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceRequest();
            
            if (cmdletContext.DataSourceName != null)
            {
                request.DataSourceName = cmdletContext.DataSourceName;
            }
            
             // populate DataSourceType
            var requestDataSourceTypeIsNull = true;
            request.DataSourceType = new Amazon.OpenSearchService.Model.DirectQueryDataSourceType();
            Amazon.OpenSearchService.Model.CloudWatchDirectQueryDataSource requestDataSourceType_dataSourceType_CloudWatchLog = null;
            
             // populate CloudWatchLog
            var requestDataSourceType_dataSourceType_CloudWatchLogIsNull = true;
            requestDataSourceType_dataSourceType_CloudWatchLog = new Amazon.OpenSearchService.Model.CloudWatchDirectQueryDataSource();
            System.String requestDataSourceType_dataSourceType_CloudWatchLog_cloudWatchLog_RoleArn = null;
            if (cmdletContext.CloudWatchLog_RoleArn != null)
            {
                requestDataSourceType_dataSourceType_CloudWatchLog_cloudWatchLog_RoleArn = cmdletContext.CloudWatchLog_RoleArn;
            }
            if (requestDataSourceType_dataSourceType_CloudWatchLog_cloudWatchLog_RoleArn != null)
            {
                requestDataSourceType_dataSourceType_CloudWatchLog.RoleArn = requestDataSourceType_dataSourceType_CloudWatchLog_cloudWatchLog_RoleArn;
                requestDataSourceType_dataSourceType_CloudWatchLogIsNull = false;
            }
             // determine if requestDataSourceType_dataSourceType_CloudWatchLog should be set to null
            if (requestDataSourceType_dataSourceType_CloudWatchLogIsNull)
            {
                requestDataSourceType_dataSourceType_CloudWatchLog = null;
            }
            if (requestDataSourceType_dataSourceType_CloudWatchLog != null)
            {
                request.DataSourceType.CloudWatchLog = requestDataSourceType_dataSourceType_CloudWatchLog;
                requestDataSourceTypeIsNull = false;
            }
            Amazon.OpenSearchService.Model.SecurityLakeDirectQueryDataSource requestDataSourceType_dataSourceType_SecurityLake = null;
            
             // populate SecurityLake
            var requestDataSourceType_dataSourceType_SecurityLakeIsNull = true;
            requestDataSourceType_dataSourceType_SecurityLake = new Amazon.OpenSearchService.Model.SecurityLakeDirectQueryDataSource();
            System.String requestDataSourceType_dataSourceType_SecurityLake_securityLake_RoleArn = null;
            if (cmdletContext.SecurityLake_RoleArn != null)
            {
                requestDataSourceType_dataSourceType_SecurityLake_securityLake_RoleArn = cmdletContext.SecurityLake_RoleArn;
            }
            if (requestDataSourceType_dataSourceType_SecurityLake_securityLake_RoleArn != null)
            {
                requestDataSourceType_dataSourceType_SecurityLake.RoleArn = requestDataSourceType_dataSourceType_SecurityLake_securityLake_RoleArn;
                requestDataSourceType_dataSourceType_SecurityLakeIsNull = false;
            }
             // determine if requestDataSourceType_dataSourceType_SecurityLake should be set to null
            if (requestDataSourceType_dataSourceType_SecurityLakeIsNull)
            {
                requestDataSourceType_dataSourceType_SecurityLake = null;
            }
            if (requestDataSourceType_dataSourceType_SecurityLake != null)
            {
                request.DataSourceType.SecurityLake = requestDataSourceType_dataSourceType_SecurityLake;
                requestDataSourceTypeIsNull = false;
            }
             // determine if request.DataSourceType should be set to null
            if (requestDataSourceTypeIsNull)
            {
                request.DataSourceType = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.OpenSearchArn != null)
            {
                request.OpenSearchArns = cmdletContext.OpenSearchArn;
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
        
        private Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "UpdateDirectQueryDataSource");
            try
            {
                #if DESKTOP
                return client.UpdateDirectQueryDataSource(request);
                #elif CORECLR
                return client.UpdateDirectQueryDataSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String DataSourceName { get; set; }
            public System.String CloudWatchLog_RoleArn { get; set; }
            public System.String SecurityLake_RoleArn { get; set; }
            public System.String Description { get; set; }
            public List<System.String> OpenSearchArn { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.UpdateDirectQueryDataSourceResponse, UpdateOSDirectQueryDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DataSourceArn;
        }
        
    }
}
