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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Creates a dataset to connect an external datasource.
    /// </summary>
    [Cmdlet("New", "IOTSWDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.CreateDatasetResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.CreateDatasetResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.CreateDatasetResponse object containing multiple properties."
    )]
    public partial class NewIOTSWDatasetCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter DatasetDescription
        /// <summary>
        /// <para>
        /// <para>A description about the dataset, and its functionality.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetDescription { get; set; }
        #endregion
        
        #region Parameter DatasetId
        /// <summary>
        /// <para>
        /// <para>The ID of the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>The name of the dataset.</para>
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
        public System.String DatasetName { get; set; }
        #endregion
        
        #region Parameter Kendra_KnowledgeBaseArn
        /// <summary>
        /// <para>
        /// <para>The <c>knowledgeBaseArn</c> details for the Kendra dataset source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetSource_SourceDetail_Kendra_KnowledgeBaseArn")]
        public System.String Kendra_KnowledgeBaseArn { get; set; }
        #endregion
        
        #region Parameter Kendra_RoleArn
        /// <summary>
        /// <para>
        /// <para>The <c>roleARN</c> details for the Kendra dataset source.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetSource_SourceDetail_Kendra_RoleArn")]
        public System.String Kendra_RoleArn { get; set; }
        #endregion
        
        #region Parameter DatasetSource_SourceFormat
        /// <summary>
        /// <para>
        /// <para>The format of the dataset source associated with the dataset.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTSiteWise.DatasetSourceFormat")]
        public Amazon.IoTSiteWise.DatasetSourceFormat DatasetSource_SourceFormat { get; set; }
        #endregion
        
        #region Parameter DatasetSource_SourceType
        /// <summary>
        /// <para>
        /// <para>The type of data source for the dataset.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.IoTSiteWise.DatasetSourceType")]
        public Amazon.IoTSiteWise.DatasetSourceType DatasetSource_SourceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs that contain metadata for the access policy. For more information,
        /// see <a href="https://docs.aws.amazon.com/iot-sitewise/latest/userguide/tag-resources.html">Tagging
        /// your IoT SiteWise resources</a> in the <i>IoT SiteWise User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique case-sensitive identifier that you can provide to ensure the idempotency
        /// of the request. Don't reuse this client token if a new idempotent request is required.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.CreateDatasetResponse will result in that property being returned.
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
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-IOTSWDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.CreateDatasetResponse, NewIOTSWDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DatasetDescription = this.DatasetDescription;
            context.DatasetId = this.DatasetId;
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Kendra_KnowledgeBaseArn = this.Kendra_KnowledgeBaseArn;
            context.Kendra_RoleArn = this.Kendra_RoleArn;
            context.DatasetSource_SourceFormat = this.DatasetSource_SourceFormat;
            #if MODULAR
            if (this.DatasetSource_SourceFormat == null && ParameterWasBound(nameof(this.DatasetSource_SourceFormat)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetSource_SourceFormat which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetSource_SourceType = this.DatasetSource_SourceType;
            #if MODULAR
            if (this.DatasetSource_SourceType == null && ParameterWasBound(nameof(this.DatasetSource_SourceType)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetSource_SourceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.IoTSiteWise.Model.CreateDatasetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetDescription != null)
            {
                request.DatasetDescription = cmdletContext.DatasetDescription;
            }
            if (cmdletContext.DatasetId != null)
            {
                request.DatasetId = cmdletContext.DatasetId;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            
             // populate DatasetSource
            var requestDatasetSourceIsNull = true;
            request.DatasetSource = new Amazon.IoTSiteWise.Model.DatasetSource();
            Amazon.IoTSiteWise.DatasetSourceFormat requestDatasetSource_datasetSource_SourceFormat = null;
            if (cmdletContext.DatasetSource_SourceFormat != null)
            {
                requestDatasetSource_datasetSource_SourceFormat = cmdletContext.DatasetSource_SourceFormat;
            }
            if (requestDatasetSource_datasetSource_SourceFormat != null)
            {
                request.DatasetSource.SourceFormat = requestDatasetSource_datasetSource_SourceFormat;
                requestDatasetSourceIsNull = false;
            }
            Amazon.IoTSiteWise.DatasetSourceType requestDatasetSource_datasetSource_SourceType = null;
            if (cmdletContext.DatasetSource_SourceType != null)
            {
                requestDatasetSource_datasetSource_SourceType = cmdletContext.DatasetSource_SourceType;
            }
            if (requestDatasetSource_datasetSource_SourceType != null)
            {
                request.DatasetSource.SourceType = requestDatasetSource_datasetSource_SourceType;
                requestDatasetSourceIsNull = false;
            }
            Amazon.IoTSiteWise.Model.SourceDetail requestDatasetSource_datasetSource_SourceDetail = null;
            
             // populate SourceDetail
            var requestDatasetSource_datasetSource_SourceDetailIsNull = true;
            requestDatasetSource_datasetSource_SourceDetail = new Amazon.IoTSiteWise.Model.SourceDetail();
            Amazon.IoTSiteWise.Model.KendraSourceDetail requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra = null;
            
             // populate Kendra
            var requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_KendraIsNull = true;
            requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra = new Amazon.IoTSiteWise.Model.KendraSourceDetail();
            System.String requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra_kendra_KnowledgeBaseArn = null;
            if (cmdletContext.Kendra_KnowledgeBaseArn != null)
            {
                requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra_kendra_KnowledgeBaseArn = cmdletContext.Kendra_KnowledgeBaseArn;
            }
            if (requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra_kendra_KnowledgeBaseArn != null)
            {
                requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra.KnowledgeBaseArn = requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra_kendra_KnowledgeBaseArn;
                requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_KendraIsNull = false;
            }
            System.String requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra_kendra_RoleArn = null;
            if (cmdletContext.Kendra_RoleArn != null)
            {
                requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra_kendra_RoleArn = cmdletContext.Kendra_RoleArn;
            }
            if (requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra_kendra_RoleArn != null)
            {
                requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra.RoleArn = requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra_kendra_RoleArn;
                requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_KendraIsNull = false;
            }
             // determine if requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra should be set to null
            if (requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_KendraIsNull)
            {
                requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra = null;
            }
            if (requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra != null)
            {
                requestDatasetSource_datasetSource_SourceDetail.Kendra = requestDatasetSource_datasetSource_SourceDetail_datasetSource_SourceDetail_Kendra;
                requestDatasetSource_datasetSource_SourceDetailIsNull = false;
            }
             // determine if requestDatasetSource_datasetSource_SourceDetail should be set to null
            if (requestDatasetSource_datasetSource_SourceDetailIsNull)
            {
                requestDatasetSource_datasetSource_SourceDetail = null;
            }
            if (requestDatasetSource_datasetSource_SourceDetail != null)
            {
                request.DatasetSource.SourceDetail = requestDatasetSource_datasetSource_SourceDetail;
                requestDatasetSourceIsNull = false;
            }
             // determine if request.DatasetSource should be set to null
            if (requestDatasetSourceIsNull)
            {
                request.DatasetSource = null;
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
        
        private Amazon.IoTSiteWise.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "CreateDataset");
            try
            {
                return client.CreateDatasetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetDescription { get; set; }
            public System.String DatasetId { get; set; }
            public System.String DatasetName { get; set; }
            public System.String Kendra_KnowledgeBaseArn { get; set; }
            public System.String Kendra_RoleArn { get; set; }
            public Amazon.IoTSiteWise.DatasetSourceFormat DatasetSource_SourceFormat { get; set; }
            public Amazon.IoTSiteWise.DatasetSourceType DatasetSource_SourceType { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.CreateDatasetResponse, NewIOTSWDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
