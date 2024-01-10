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
using Amazon.Rekognition;
using Amazon.Rekognition.Model;

namespace Amazon.PowerShell.Cmdlets.REK
{
    /// <summary>
    /// <note><para>
    /// This operation applies only to Amazon Rekognition Custom Labels.
    /// </para></note><para>
    /// Creates a new Amazon Rekognition Custom Labels dataset. You can create a dataset by
    /// using an Amazon Sagemaker format manifest file or by copying an existing Amazon Rekognition
    /// Custom Labels dataset.
    /// </para><para>
    /// To create a training dataset for a project, specify <c>TRAIN</c> for the value of
    /// <c>DatasetType</c>. To create the test dataset for a project, specify <c>TEST</c>
    /// for the value of <c>DatasetType</c>. 
    /// </para><para>
    /// The response from <c>CreateDataset</c> is the Amazon Resource Name (ARN) for the dataset.
    /// Creating a dataset takes a while to complete. Use <a>DescribeDataset</a> to check
    /// the current status. The dataset created successfully if the value of <c>Status</c>
    /// is <c>CREATE_COMPLETE</c>. 
    /// </para><para>
    /// To check if any non-terminal errors occurred, call <a>ListDatasetEntries</a> and check
    /// for the presence of <c>errors</c> lists in the JSON Lines.
    /// </para><para>
    /// Dataset creation fails if a terminal error occurs (<c>Status</c> = <c>CREATE_FAILED</c>).
    /// Currently, you can't access the terminal error information. 
    /// </para><para>
    /// For more information, see Creating dataset in the <i>Amazon Rekognition Custom Labels
    /// Developer Guide</i>.
    /// </para><para>
    /// This operation requires permissions to perform the <c>rekognition:CreateDataset</c>
    /// action. If you want to copy an existing dataset, you also require permission to perform
    /// the <c>rekognition:ListDatasetEntries</c> action.
    /// </para>
    /// </summary>
    [Cmdlet("New", "REKDataset", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Rekognition CreateDataset API operation.", Operation = new[] {"CreateDataset"}, SelectReturnType = typeof(Amazon.Rekognition.Model.CreateDatasetResponse))]
    [AWSCmdletOutput("System.String or Amazon.Rekognition.Model.CreateDatasetResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Rekognition.Model.CreateDatasetResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewREKDatasetCmdlet : AmazonRekognitionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter S3Object_Bucket
        /// <summary>
        /// <para>
        /// <para>Name of the S3 bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetSource_GroundTruthManifest_S3Object_Bucket")]
        public System.String S3Object_Bucket { get; set; }
        #endregion
        
        #region Parameter DatasetSource_DatasetArn
        /// <summary>
        /// <para>
        /// <para> The ARN of an Amazon Rekognition Custom Labels dataset that you want to copy. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetSource_DatasetArn { get; set; }
        #endregion
        
        #region Parameter DatasetType
        /// <summary>
        /// <para>
        /// <para> The type of the dataset. Specify <c>TRAIN</c> to create a training dataset. Specify
        /// <c>TEST</c> to create a test dataset. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Rekognition.DatasetType")]
        public Amazon.Rekognition.DatasetType DatasetType { get; set; }
        #endregion
        
        #region Parameter S3Object_Name
        /// <summary>
        /// <para>
        /// <para>S3 object key name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetSource_GroundTruthManifest_S3Object_Name")]
        public System.String S3Object_Name { get; set; }
        #endregion
        
        #region Parameter ProjectArn
        /// <summary>
        /// <para>
        /// <para> The ARN of the Amazon Rekognition Custom Labels project to which you want to asssign
        /// the dataset. </para>
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
        public System.String ProjectArn { get; set; }
        #endregion
        
        #region Parameter S3Object_Version
        /// <summary>
        /// <para>
        /// <para>If the bucket is versioning enabled, you can specify the object version. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DatasetSource_GroundTruthManifest_S3Object_Version")]
        public System.String S3Object_Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'DatasetArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Rekognition.Model.CreateDatasetResponse).
        /// Specifying the name of a property of type Amazon.Rekognition.Model.CreateDatasetResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "DatasetArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-REKDataset (CreateDataset)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Rekognition.Model.CreateDatasetResponse, NewREKDatasetCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.DatasetSource_DatasetArn = this.DatasetSource_DatasetArn;
            context.S3Object_Bucket = this.S3Object_Bucket;
            context.S3Object_Name = this.S3Object_Name;
            context.S3Object_Version = this.S3Object_Version;
            context.DatasetType = this.DatasetType;
            #if MODULAR
            if (this.DatasetType == null && ParameterWasBound(nameof(this.DatasetType)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProjectArn = this.ProjectArn;
            #if MODULAR
            if (this.ProjectArn == null && ParameterWasBound(nameof(this.ProjectArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Rekognition.Model.CreateDatasetRequest();
            
            
             // populate DatasetSource
            var requestDatasetSourceIsNull = true;
            request.DatasetSource = new Amazon.Rekognition.Model.DatasetSource();
            System.String requestDatasetSource_datasetSource_DatasetArn = null;
            if (cmdletContext.DatasetSource_DatasetArn != null)
            {
                requestDatasetSource_datasetSource_DatasetArn = cmdletContext.DatasetSource_DatasetArn;
            }
            if (requestDatasetSource_datasetSource_DatasetArn != null)
            {
                request.DatasetSource.DatasetArn = requestDatasetSource_datasetSource_DatasetArn;
                requestDatasetSourceIsNull = false;
            }
            Amazon.Rekognition.Model.GroundTruthManifest requestDatasetSource_datasetSource_GroundTruthManifest = null;
            
             // populate GroundTruthManifest
            var requestDatasetSource_datasetSource_GroundTruthManifestIsNull = true;
            requestDatasetSource_datasetSource_GroundTruthManifest = new Amazon.Rekognition.Model.GroundTruthManifest();
            Amazon.Rekognition.Model.S3Object requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object = null;
            
             // populate S3Object
            var requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3ObjectIsNull = true;
            requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object = new Amazon.Rekognition.Model.S3Object();
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
            System.String requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Name = null;
            if (cmdletContext.S3Object_Name != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Name = cmdletContext.S3Object_Name;
            }
            if (requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Name != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object.Name = requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Name;
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3ObjectIsNull = false;
            }
            System.String requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Version = null;
            if (cmdletContext.S3Object_Version != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Version = cmdletContext.S3Object_Version;
            }
            if (requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Version != null)
            {
                requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object.Version = requestDatasetSource_datasetSource_GroundTruthManifest_datasetSource_GroundTruthManifest_S3Object_s3Object_Version;
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
            if (cmdletContext.ProjectArn != null)
            {
                request.ProjectArn = cmdletContext.ProjectArn;
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
        
        private Amazon.Rekognition.Model.CreateDatasetResponse CallAWSServiceOperation(IAmazonRekognition client, Amazon.Rekognition.Model.CreateDatasetRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Rekognition", "CreateDataset");
            try
            {
                #if DESKTOP
                return client.CreateDataset(request);
                #elif CORECLR
                return client.CreateDatasetAsync(request).GetAwaiter().GetResult();
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
            public System.String DatasetSource_DatasetArn { get; set; }
            public System.String S3Object_Bucket { get; set; }
            public System.String S3Object_Name { get; set; }
            public System.String S3Object_Version { get; set; }
            public Amazon.Rekognition.DatasetType DatasetType { get; set; }
            public System.String ProjectArn { get; set; }
            public System.Func<Amazon.Rekognition.Model.CreateDatasetResponse, NewREKDatasetCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.DatasetArn;
        }
        
    }
}
