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
    /// Adds the data source on the domain.
    /// </summary>
    [Cmdlet("Add", "OSDataSource", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon OpenSearch Service AddDataSource API operation.", Operation = new[] {"AddDataSource"}, SelectReturnType = typeof(Amazon.OpenSearchService.Model.AddDataSourceResponse))]
    [AWSCmdletOutput("System.String or Amazon.OpenSearchService.Model.AddDataSourceResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.OpenSearchService.Model.AddDataSourceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class AddOSDataSourceCmdlet : AmazonOpenSearchServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the data source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DomainName
        /// <summary>
        /// <para>
        /// <para>The name of the domain.</para>
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
        public System.String DomainName { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the data source.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter S3GlueDataCatalog_RoleArn
        /// <summary>
        /// <para>
        /// <para>The role ARN for the AWS S3 Glue Data Catalog.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataSourceType_S3GlueDataCatalog_RoleArn")]
        public System.String S3GlueDataCatalog_RoleArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Message'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.OpenSearchService.Model.AddDataSourceResponse).
        /// Specifying the name of a property of type Amazon.OpenSearchService.Model.AddDataSourceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Message";
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
            
            var resourceIdentifiersText = string.Empty;
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Add-OSDataSource (AddDataSource)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.OpenSearchService.Model.AddDataSourceResponse, AddOSDataSourceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.S3GlueDataCatalog_RoleArn = this.S3GlueDataCatalog_RoleArn;
            context.Description = this.Description;
            context.DomainName = this.DomainName;
            #if MODULAR
            if (this.DomainName == null && ParameterWasBound(nameof(this.DomainName)))
            {
                WriteWarning("You are passing $null as a value for parameter DomainName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.OpenSearchService.Model.AddDataSourceRequest();
            
            
             // populate DataSourceType
            var requestDataSourceTypeIsNull = true;
            request.DataSourceType = new Amazon.OpenSearchService.Model.DataSourceType();
            Amazon.OpenSearchService.Model.S3GlueDataCatalog requestDataSourceType_dataSourceType_S3GlueDataCatalog = null;
            
             // populate S3GlueDataCatalog
            var requestDataSourceType_dataSourceType_S3GlueDataCatalogIsNull = true;
            requestDataSourceType_dataSourceType_S3GlueDataCatalog = new Amazon.OpenSearchService.Model.S3GlueDataCatalog();
            System.String requestDataSourceType_dataSourceType_S3GlueDataCatalog_s3GlueDataCatalog_RoleArn = null;
            if (cmdletContext.S3GlueDataCatalog_RoleArn != null)
            {
                requestDataSourceType_dataSourceType_S3GlueDataCatalog_s3GlueDataCatalog_RoleArn = cmdletContext.S3GlueDataCatalog_RoleArn;
            }
            if (requestDataSourceType_dataSourceType_S3GlueDataCatalog_s3GlueDataCatalog_RoleArn != null)
            {
                requestDataSourceType_dataSourceType_S3GlueDataCatalog.RoleArn = requestDataSourceType_dataSourceType_S3GlueDataCatalog_s3GlueDataCatalog_RoleArn;
                requestDataSourceType_dataSourceType_S3GlueDataCatalogIsNull = false;
            }
             // determine if requestDataSourceType_dataSourceType_S3GlueDataCatalog should be set to null
            if (requestDataSourceType_dataSourceType_S3GlueDataCatalogIsNull)
            {
                requestDataSourceType_dataSourceType_S3GlueDataCatalog = null;
            }
            if (requestDataSourceType_dataSourceType_S3GlueDataCatalog != null)
            {
                request.DataSourceType.S3GlueDataCatalog = requestDataSourceType_dataSourceType_S3GlueDataCatalog;
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
            if (cmdletContext.DomainName != null)
            {
                request.DomainName = cmdletContext.DomainName;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
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
        
        private Amazon.OpenSearchService.Model.AddDataSourceResponse CallAWSServiceOperation(IAmazonOpenSearchService client, Amazon.OpenSearchService.Model.AddDataSourceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon OpenSearch Service", "AddDataSource");
            try
            {
                #if DESKTOP
                return client.AddDataSource(request);
                #elif CORECLR
                return client.AddDataSourceAsync(request).GetAwaiter().GetResult();
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
            public System.String S3GlueDataCatalog_RoleArn { get; set; }
            public System.String Description { get; set; }
            public System.String DomainName { get; set; }
            public System.String Name { get; set; }
            public System.Func<Amazon.OpenSearchService.Model.AddDataSourceResponse, AddOSDataSourceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Message;
        }
        
    }
}
