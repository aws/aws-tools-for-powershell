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

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.IOTSW
{
    /// <summary>
    /// Updates a dataset.
    /// </summary>
    [Cmdlet("Update", "IOTSWDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.IoTSiteWise.Model.UpdateDatasetResponse")]
    [AWSCmdlet("Calls the AWS IoT SiteWise UpdateDataset API operation.", Operation = new[] {"UpdateDataset"}, SelectReturnType = typeof(Amazon.IoTSiteWise.Model.UpdateDatasetResponse))]
    [AWSCmdletOutput("Amazon.IoTSiteWise.Model.UpdateDatasetResponse",
        "This cmdlet returns an Amazon.IoTSiteWise.Model.UpdateDatasetResponse object containing multiple properties."
    )]
    public partial class UpdateIOTSWDatasetCmdlet : AmazonIoTSiteWiseClientCmdlet, IExecutor
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
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String DatasetId { get; set; }
        #endregion
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>The name of the dataset.</para>
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
        
        #region Parameter Metadata
        /// <summary>
        /// <para>
        /// <para>The updated metadata for the dataset.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Collections.Hashtable Metadata { get; set; }
        #endregion
        
        #region Parameter DatasetConfig_Session_SessionEndTimestamp_OffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset from <c>timeInSeconds</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetConfig_Session_SessionEndTimestamp_OffsetInNanos")]
        public System.Int32? DatasetConfig_Session_SessionEndTimestamp_OffsetInNano { get; set; }
        #endregion
        
        #region Parameter DatasetConfig_Session_SessionStartTimestamp_OffsetInNano
        /// <summary>
        /// <para>
        /// <para>The nanosecond offset from <c>timeInSeconds</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetConfig_Session_SessionStartTimestamp_OffsetInNanos")]
        public System.Int32? DatasetConfig_Session_SessionStartTimestamp_OffsetInNano { get; set; }
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
        
        #region Parameter DatasetConfig_Session_SessionEndTimestamp_TimeInSecond
        /// <summary>
        /// <para>
        /// <para>The timestamp date, in seconds, in the Unix epoch format. Fractional nanosecond data
        /// is provided by <c>offsetInNanos</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetConfig_Session_SessionEndTimestamp_TimeInSeconds")]
        public System.Int64? DatasetConfig_Session_SessionEndTimestamp_TimeInSecond { get; set; }
        #endregion
        
        #region Parameter DatasetConfig_Session_SessionStartTimestamp_TimeInSecond
        /// <summary>
        /// <para>
        /// <para>The timestamp date, in seconds, in the Unix epoch format. Fractional nanosecond data
        /// is provided by <c>offsetInNanos</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetConfig_Session_SessionStartTimestamp_TimeInSeconds")]
        public System.Int64? DatasetConfig_Session_SessionStartTimestamp_TimeInSecond { get; set; }
        #endregion
        
        #region Parameter WorkspaceName
        /// <summary>
        /// <para>
        /// <para>The name of the workspace that contains the dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkspaceName { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.IoTSiteWise.Model.UpdateDatasetResponse).
        /// Specifying the name of a property of type Amazon.IoTSiteWise.Model.UpdateDatasetResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWDataset (UpdateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateDatasetResponse, UpdateIOTSWDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DatasetConfig_Session_SessionEndTimestamp_OffsetInNano = this.DatasetConfig_Session_SessionEndTimestamp_OffsetInNano;
            context.DatasetConfig_Session_SessionEndTimestamp_TimeInSecond = this.DatasetConfig_Session_SessionEndTimestamp_TimeInSecond;
            context.DatasetConfig_Session_SessionStartTimestamp_OffsetInNano = this.DatasetConfig_Session_SessionStartTimestamp_OffsetInNano;
            context.DatasetConfig_Session_SessionStartTimestamp_TimeInSecond = this.DatasetConfig_Session_SessionStartTimestamp_TimeInSecond;
            context.DatasetDescription = this.DatasetDescription;
            context.DatasetId = this.DatasetId;
            #if MODULAR
            if (this.DatasetId == null && ParameterWasBound(nameof(this.DatasetId)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            if (this.Metadata != null)
            {
                context.Metadata = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Metadata.Keys)
                {
                    context.Metadata.Add((String)hashKey, (System.String)(this.Metadata[hashKey]));
                }
            }
            context.WorkspaceName = this.WorkspaceName;
            
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
            var request = new Amazon.IoTSiteWise.Model.UpdateDatasetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DatasetConfig
            var requestDatasetConfigIsNull = true;
            request.DatasetConfig = new Amazon.IoTSiteWise.Model.DatasetConfig();
            Amazon.IoTSiteWise.Model.SessionConfig requestDatasetConfig_datasetConfig_Session = null;
            
             // populate Session
            var requestDatasetConfig_datasetConfig_SessionIsNull = true;
            requestDatasetConfig_datasetConfig_Session = new Amazon.IoTSiteWise.Model.SessionConfig();
            Amazon.IoTSiteWise.Model.TimeInNanos requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp = null;
            
             // populate SessionEndTimestamp
            var requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestampIsNull = true;
            requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp = new Amazon.IoTSiteWise.Model.TimeInNanos();
            System.Int32? requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp_datasetConfig_Session_SessionEndTimestamp_OffsetInNano = null;
            if (cmdletContext.DatasetConfig_Session_SessionEndTimestamp_OffsetInNano != null)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp_datasetConfig_Session_SessionEndTimestamp_OffsetInNano = cmdletContext.DatasetConfig_Session_SessionEndTimestamp_OffsetInNano.Value;
            }
            if (requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp_datasetConfig_Session_SessionEndTimestamp_OffsetInNano != null)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp.OffsetInNanos = requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp_datasetConfig_Session_SessionEndTimestamp_OffsetInNano.Value;
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestampIsNull = false;
            }
            System.Int64? requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp_datasetConfig_Session_SessionEndTimestamp_TimeInSecond = null;
            if (cmdletContext.DatasetConfig_Session_SessionEndTimestamp_TimeInSecond != null)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp_datasetConfig_Session_SessionEndTimestamp_TimeInSecond = cmdletContext.DatasetConfig_Session_SessionEndTimestamp_TimeInSecond.Value;
            }
            if (requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp_datasetConfig_Session_SessionEndTimestamp_TimeInSecond != null)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp.TimeInSeconds = requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp_datasetConfig_Session_SessionEndTimestamp_TimeInSecond.Value;
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestampIsNull = false;
            }
             // determine if requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp should be set to null
            if (requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestampIsNull)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp = null;
            }
            if (requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp != null)
            {
                requestDatasetConfig_datasetConfig_Session.SessionEndTimestamp = requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionEndTimestamp;
                requestDatasetConfig_datasetConfig_SessionIsNull = false;
            }
            Amazon.IoTSiteWise.Model.TimeInNanos requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp = null;
            
             // populate SessionStartTimestamp
            var requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestampIsNull = true;
            requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp = new Amazon.IoTSiteWise.Model.TimeInNanos();
            System.Int32? requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp_datasetConfig_Session_SessionStartTimestamp_OffsetInNano = null;
            if (cmdletContext.DatasetConfig_Session_SessionStartTimestamp_OffsetInNano != null)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp_datasetConfig_Session_SessionStartTimestamp_OffsetInNano = cmdletContext.DatasetConfig_Session_SessionStartTimestamp_OffsetInNano.Value;
            }
            if (requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp_datasetConfig_Session_SessionStartTimestamp_OffsetInNano != null)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp.OffsetInNanos = requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp_datasetConfig_Session_SessionStartTimestamp_OffsetInNano.Value;
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestampIsNull = false;
            }
            System.Int64? requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp_datasetConfig_Session_SessionStartTimestamp_TimeInSecond = null;
            if (cmdletContext.DatasetConfig_Session_SessionStartTimestamp_TimeInSecond != null)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp_datasetConfig_Session_SessionStartTimestamp_TimeInSecond = cmdletContext.DatasetConfig_Session_SessionStartTimestamp_TimeInSecond.Value;
            }
            if (requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp_datasetConfig_Session_SessionStartTimestamp_TimeInSecond != null)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp.TimeInSeconds = requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp_datasetConfig_Session_SessionStartTimestamp_TimeInSecond.Value;
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestampIsNull = false;
            }
             // determine if requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp should be set to null
            if (requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestampIsNull)
            {
                requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp = null;
            }
            if (requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp != null)
            {
                requestDatasetConfig_datasetConfig_Session.SessionStartTimestamp = requestDatasetConfig_datasetConfig_Session_datasetConfig_Session_SessionStartTimestamp;
                requestDatasetConfig_datasetConfig_SessionIsNull = false;
            }
             // determine if requestDatasetConfig_datasetConfig_Session should be set to null
            if (requestDatasetConfig_datasetConfig_SessionIsNull)
            {
                requestDatasetConfig_datasetConfig_Session = null;
            }
            if (requestDatasetConfig_datasetConfig_Session != null)
            {
                request.DatasetConfig.Session = requestDatasetConfig_datasetConfig_Session;
                requestDatasetConfigIsNull = false;
            }
             // determine if request.DatasetConfig should be set to null
            if (requestDatasetConfigIsNull)
            {
                request.DatasetConfig = null;
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
            if (cmdletContext.Metadata != null)
            {
                request.Metadata = cmdletContext.Metadata;
            }
            if (cmdletContext.WorkspaceName != null)
            {
                request.WorkspaceName = cmdletContext.WorkspaceName;
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
        
        private Amazon.IoTSiteWise.Model.UpdateDatasetResponse CallAWSServiceOperation(IAmazonIoTSiteWise client, Amazon.IoTSiteWise.Model.UpdateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS IoT SiteWise", "UpdateDataset");
            try
            {
                return client.UpdateDatasetAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.Int32? DatasetConfig_Session_SessionEndTimestamp_OffsetInNano { get; set; }
            public System.Int64? DatasetConfig_Session_SessionEndTimestamp_TimeInSecond { get; set; }
            public System.Int32? DatasetConfig_Session_SessionStartTimestamp_OffsetInNano { get; set; }
            public System.Int64? DatasetConfig_Session_SessionStartTimestamp_TimeInSecond { get; set; }
            public System.String DatasetDescription { get; set; }
            public System.String DatasetId { get; set; }
            public System.String DatasetName { get; set; }
            public System.String Kendra_KnowledgeBaseArn { get; set; }
            public System.String Kendra_RoleArn { get; set; }
            public Amazon.IoTSiteWise.DatasetSourceFormat DatasetSource_SourceFormat { get; set; }
            public Amazon.IoTSiteWise.DatasetSourceType DatasetSource_SourceType { get; set; }
            public Dictionary<System.String, System.String> Metadata { get; set; }
            public System.String WorkspaceName { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateDatasetResponse, UpdateIOTSWDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
