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
using Amazon.IoTSiteWise;
using Amazon.IoTSiteWise.Model;

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
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the DatasetId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^DatasetId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^DatasetId' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DatasetId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-IOTSWDataset (UpdateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.IoTSiteWise.Model.UpdateDatasetResponse, UpdateIOTSWDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.DatasetId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
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
                #if DESKTOP
                return client.UpdateDataset(request);
                #elif CORECLR
                return client.UpdateDatasetAsync(request).GetAwaiter().GetResult();
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
            public System.String ClientToken { get; set; }
            public System.String DatasetDescription { get; set; }
            public System.String DatasetId { get; set; }
            public System.String DatasetName { get; set; }
            public System.String Kendra_KnowledgeBaseArn { get; set; }
            public System.String Kendra_RoleArn { get; set; }
            public Amazon.IoTSiteWise.DatasetSourceFormat DatasetSource_SourceFormat { get; set; }
            public Amazon.IoTSiteWise.DatasetSourceType DatasetSource_SourceType { get; set; }
            public System.Func<Amazon.IoTSiteWise.Model.UpdateDatasetResponse, UpdateIOTSWDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
