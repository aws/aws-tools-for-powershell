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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Creates a new dataset in an Amazon Lookout for Vision project. <c>CreateDataset</c>
    /// can create a training or a test dataset from a valid dataset source (<c>DatasetSource</c>).
    /// 
    ///  
    /// <para>
    /// If you want a single dataset project, specify <c>train</c> for the value of <c>DatasetType</c>.
    /// </para><para>
    /// To have a project with separate training and test datasets, call <c>CreateDataset</c>
    /// twice. On the first call, specify <c>train</c> for the value of <c>DatasetType</c>.
    /// On the second call, specify <c>test</c> for the value of <c>DatasetType</c>. 
    /// </para><para>
    /// This operation requires permissions to perform the <c>lookoutvision:CreateDataset</c>
    /// operation.
    /// </para>
    /// </summary>
    [Cmdlet("New", "LFVDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutforVision.Model.DatasetMetadata")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("Amazon.LookoutforVision.Model.DatasetMetadata or Amazon.LookoutforVision.Model.CreateDatasetResponse",
        "This cmdlet returns an Amazon.LookoutforVision.Model.DatasetMetadata object.",
        "The service call response (type Amazon.LookoutforVision.Model.CreateDatasetResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewLFVDatasetCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket that contains the manifest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetSource_GroundTruthManifest_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter DatasetType
        /// <summary>
        /// <para>
        /// <para>The type of the dataset. Specify <c>train</c> for a training dataset. Specify <c>test</c>
        /// for a test dataset.</para>
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
        public System.String DatasetType { get; set; }
        #endregion
        
        #region Parameter S3Object_Key
        /// <summary>
        /// <para>
        /// <para>The name and location of the manifest file withiin the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetSource_GroundTruthManifest_S3Object_Key")]
        public System.String S3Object_Key { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project in which you want to create a dataset.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter S3Object_VersionId
        /// <summary>
        /// <para>
        /// <para>The version ID of the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetSource_GroundTruthManifest_S3Object_VersionId")]
        public System.String S3Object_VersionId { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>ClientToken is an idempotency token that ensures a call to <c>CreateDataset</c> completes
        /// only once. You choose the value to pass. For example, An issue might prevent you from
        /// getting a response from <c>CreateDataset</c>. In this case, safely retry your call
        /// to <c>CreateDataset</c> by using the same <c>ClientToken</c> parameter value.</para><para>If you don't supply a value for <c>ClientToken</c>, the AWS SDK you are using inserts
        /// a value for you. This prevents retries after a network error from making multiple
        /// dataset creation requests. You'll need to provide your own value for other use cases.
        /// </para><para>An error occurs if the other input parameters are not the same as in the first request.
        /// Using a different value for <c>ClientToken</c> is considered a new call to <c>CreateDataset</c>.
        /// An idempotency token is active for 8 hours. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetMetadata'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.CreateDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetMetadata";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-LFVDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.CreateDatasetResponse, NewLFVDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Key = this.S3Object_Key;
            context.S3Object_VersionId = this.S3Object_VersionId;
            context.DatasetType = this.DatasetType;
            #if MODULAR
            if (this.DatasetType == null && ParameterWasBound(nameof(this.DatasetType)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutforVision.Model.CreateDatasetRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DatasetSource
            var requestDatasetSourceIsNull = true;
            request.DatasetSource = new Amazon.LookoutforVision.Model.DatasetSource();
            Amazon.LookoutforVision.Model.DatasetGroundTruthManifest requestDatasetSource_datasetSource_GroundTruthManifest = null;
            
             // populate GroundTruthManifest
            var requestDatasetSource_datasetSource_GroundTruthManifestIsNull = true;
            requestDatasetSource_datasetSource_GroundTruthManifest = new Amazon.LookoutforVision.Model.DatasetGroundTruthManifest();
            Amazon.LookoutforVision.Model.InputS3Object requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object = null;
            
             // populate S3Object
            var requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3ObjectIsNull = true;
            requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object = new Amazon.LookoutforVision.Model.InputS3Object();
            System.String requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Bucket = null;
            if (cmdletContext.S3Object_Bucket != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Bucket = cmdletContext.S3Object_Bucket;
            }
            if (requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Bucket != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object.Bucket = requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Bucket;
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3ObjectIsNull = false;
            }
            System.String requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Key = null;
            if (cmdletContext.S3Object_Key != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Key = cmdletContext.S3Object_Key;
            }
            if (requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Key != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object.Key = requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Key;
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3ObjectIsNull = false;
            }
            System.String requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_VersionId = null;
            if (cmdletContext.S3Object_VersionId != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_VersionId = cmdletContext.S3Object_VersionId;
            }
            if (requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_VersionId != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object.VersionId = requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_VersionId;
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3ObjectIsNull = false;
            }
             // determine if requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object should be set to null
            if (requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3ObjectIsNull)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object = null;
            }
            if (requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest.S3Object = requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object;
                requestDatasetSource_datasetSource_GroundTruthManifestIsNull = false;
            }
             // determine if requestDatasetSource_datasetSource_GroundTruthManifest should be set to null
            if (requestDatasetSource_datasetSource_GroundTruthManifestIsNull)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest = null;
            }
            if (requestDatasetSource_datasetSource_GroundTruthManifest != null)
            {
                request.DatasetSource.GroundTruthManifest = requestDatasetSource_datasetSource_GroundTruthManifest;
                requestDatasetSourceIsNull = false;
            }
             // determine if request.DatasetSource should be set to null
            if (requestDatasetSourceIsNull)
            {
                request.DatasetSource = null;
            }
            if (cmdletContext.DatasetType != null)
            {
                request.DatasetType = cmdletContext.DatasetType;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
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
        
        private Amazon.LookoutforVision.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "CreateDataset");
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
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Key { get; set; }
            public System.String S3Object_VersionId { get; set; }
            public System.String DatasetType { get; set; }
            public System.String ProjectName { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.CreateDatasetResponse, NewLFVDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetMetadata;
        }
        
    }
}
