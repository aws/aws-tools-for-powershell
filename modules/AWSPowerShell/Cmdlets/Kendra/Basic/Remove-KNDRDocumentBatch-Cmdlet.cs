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
using Amazon.Kendra;
using Amazon.Kendra.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.KNDR
{
    /// <summary>
    /// Removes one or more documents from an index. The documents must have been added with
    /// the <c>BatchPutDocument</c> API.
    /// 
    ///  
    /// <para>
    /// The documents are deleted asynchronously. You can see the progress of the deletion
    /// by using Amazon Web Services CloudWatch. Any error messages related to the processing
    /// of the batch are sent to your Amazon Web Services CloudWatch log. You can also use
    /// the <c>BatchGetDocumentStatus</c> API to monitor the progress of deleting your documents.
    /// </para><para>
    /// Deleting documents from an index using <c>BatchDeleteDocument</c> could take up to
    /// an hour or more, depending on the number of documents you want to delete.
    /// </para>
    /// </summary>
    [Cmdlet("Remove", "KNDRDocumentBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    [OutputType("Amazon.Kendra.Model.BatchDeleteDocumentResponseFailedDocument")]
    [AWSCmdlet("Calls the Amazon Kendra BatchDeleteDocument API operation.", Operation = new[] {"BatchDeleteDocument"}, SelectReturnType = typeof(Amazon.Kendra.Model.BatchDeleteDocumentResponse))]
    [AWSCmdletOutput("Amazon.Kendra.Model.BatchDeleteDocumentResponseFailedDocument or Amazon.Kendra.Model.BatchDeleteDocumentResponse",
        "This cmdlet returns a collection of Amazon.Kendra.Model.BatchDeleteDocumentResponseFailedDocument objects.",
        "The service call response (type Amazon.Kendra.Model.BatchDeleteDocumentResponse) can be returned by specifying '-Select *'."
    )]
    public partial class RemoveKNDRDocumentBatchCmdlet : AmazonKendraClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DataSourceSyncJobMetricTarget_DataSourceId
        /// <summary>
        /// <para>
        /// <para>The ID of the data source that is running the sync job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceSyncJobMetricTarget_DataSourceId { get; set; }
        #endregion
        
        #region Parameter DataSourceSyncJobMetricTarget_DataSourceSyncJobId
        /// <summary>
        /// <para>
        /// <para>The ID of the sync job that is running on the data source.</para><para>If the ID of a sync job is not provided and there is a sync job running, then the
        /// ID of this sync job is used and metrics are generated for this sync job.</para><para>If the ID of a sync job is not provided and there is no sync job running, then no
        /// metrics are generated and documents are indexed/deleted at the index level without
        /// sync job metrics included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataSourceSyncJobMetricTarget_DataSourceSyncJobId { get; set; }
        #endregion
        
        #region Parameter DocumentIdList
        /// <summary>
        /// <para>
        /// <para>One or more identifiers for documents to delete from the index.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
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
        public System.String[] DocumentIdList { get; set; }
        #endregion
        
        #region Parameter IndexId
        /// <summary>
        /// <para>
        /// <para>The identifier of the index that contains the documents to delete.</para>
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
        public System.String IndexId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'FailedDocuments'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Kendra.Model.BatchDeleteDocumentResponse).
        /// Specifying the name of a property of type Amazon.Kendra.Model.BatchDeleteDocumentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "FailedDocuments";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.IndexId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Remove-KNDRDocumentBatch (BatchDeleteDocument)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Kendra.Model.BatchDeleteDocumentResponse, RemoveKNDRDocumentBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.DataSourceSyncJobMetricTarget_DataSourceId = this.DataSourceSyncJobMetricTarget_DataSourceId;
            context.DataSourceSyncJobMetricTarget_DataSourceSyncJobId = this.DataSourceSyncJobMetricTarget_DataSourceSyncJobId;
            if (this.DocumentIdList != null)
            {
                context.DocumentIdList = new List<System.String>(this.DocumentIdList);
            }
            #if MODULAR
            if (this.DocumentIdList == null && ParameterWasBound(nameof(this.DocumentIdList)))
            {
                WriteWarning("You are passing $null as a value for parameter DocumentIdList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IndexId = this.IndexId;
            #if MODULAR
            if (this.IndexId == null && ParameterWasBound(nameof(this.IndexId)))
            {
                WriteWarning("You are passing $null as a value for parameter IndexId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Kendra.Model.BatchDeleteDocumentRequest();
            
            
             // populate DataSourceSyncJobMetricTarget
            var requestDataSourceSyncJobMetricTargetIsNull = true;
            request.DataSourceSyncJobMetricTarget = new Amazon.Kendra.Model.DataSourceSyncJobMetricTarget();
            System.String requestDataSourceSyncJobMetricTarget_dataSourceSyncJobMetricTarget_DataSourceId = null;
            if (cmdletContext.DataSourceSyncJobMetricTarget_DataSourceId != null)
            {
                requestDataSourceSyncJobMetricTarget_dataSourceSyncJobMetricTarget_DataSourceId = cmdletContext.DataSourceSyncJobMetricTarget_DataSourceId;
            }
            if (requestDataSourceSyncJobMetricTarget_dataSourceSyncJobMetricTarget_DataSourceId != null)
            {
                request.DataSourceSyncJobMetricTarget.DataSourceId = requestDataSourceSyncJobMetricTarget_dataSourceSyncJobMetricTarget_DataSourceId;
                requestDataSourceSyncJobMetricTargetIsNull = false;
            }
            System.String requestDataSourceSyncJobMetricTarget_dataSourceSyncJobMetricTarget_DataSourceSyncJobId = null;
            if (cmdletContext.DataSourceSyncJobMetricTarget_DataSourceSyncJobId != null)
            {
                requestDataSourceSyncJobMetricTarget_dataSourceSyncJobMetricTarget_DataSourceSyncJobId = cmdletContext.DataSourceSyncJobMetricTarget_DataSourceSyncJobId;
            }
            if (requestDataSourceSyncJobMetricTarget_dataSourceSyncJobMetricTarget_DataSourceSyncJobId != null)
            {
                request.DataSourceSyncJobMetricTarget.DataSourceSyncJobId = requestDataSourceSyncJobMetricTarget_dataSourceSyncJobMetricTarget_DataSourceSyncJobId;
                requestDataSourceSyncJobMetricTargetIsNull = false;
            }
             // determine if request.DataSourceSyncJobMetricTarget should be set to null
            if (requestDataSourceSyncJobMetricTargetIsNull)
            {
                request.DataSourceSyncJobMetricTarget = null;
            }
            if (cmdletContext.DocumentIdList != null)
            {
                request.DocumentIdList = cmdletContext.DocumentIdList;
            }
            if (cmdletContext.IndexId != null)
            {
                request.IndexId = cmdletContext.IndexId;
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
        
        private Amazon.Kendra.Model.BatchDeleteDocumentResponse CallAWSServiceOperation(IAmazonKendra client, Amazon.Kendra.Model.BatchDeleteDocumentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Kendra", "BatchDeleteDocument");
            try
            {
                return client.BatchDeleteDocumentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DataSourceSyncJobMetricTarget_DataSourceId { get; set; }
            public System.String DataSourceSyncJobMetricTarget_DataSourceSyncJobId { get; set; }
            public List<System.String> DocumentIdList { get; set; }
            public System.String IndexId { get; set; }
            public System.Func<Amazon.Kendra.Model.BatchDeleteDocumentResponse, RemoveKNDRDocumentBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.FailedDocuments;
        }
        
    }
}
