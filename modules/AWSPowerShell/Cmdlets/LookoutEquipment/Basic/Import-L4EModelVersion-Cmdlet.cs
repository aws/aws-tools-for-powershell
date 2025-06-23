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
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Imports a model that has been trained successfully.
    /// </summary>
    [Cmdlet("Import", "L4EModelVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutEquipment.Model.ImportModelVersionResponse")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment ImportModelVersion API operation.", Operation = new[] {"ImportModelVersion"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.ImportModelVersionResponse))]
    [AWSCmdletOutput("Amazon.LookoutEquipment.Model.ImportModelVersionResponse",
        "This cmdlet returns an Amazon.LookoutEquipment.Model.ImportModelVersionResponse object containing multiple properties."
    )]
    public partial class ImportL4EModelVersionCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter S3InputConfiguration_Bucket
        /// <summary>
        /// <para>
        /// <para>The name of the S3 bucket holding the label data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LabelsInputConfiguration_S3InputConfiguration_Bucket")]
        public System.String S3InputConfiguration_Bucket { get; set; }
        #endregion
        
        #region Parameter DatasetName
        /// <summary>
        /// <para>
        /// <para>The name of the dataset for the machine learning model being imported. </para>
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
        
        #region Parameter InferenceDataImportStrategy
        /// <summary>
        /// <para>
        /// <para>Indicates how to import the accumulated inference data when a model version is imported.
        /// The possible values are as follows:</para><ul><li><para>NO_IMPORT – Don't import the data.</para></li><li><para>ADD_WHEN_EMPTY – Only import the data from the source model if there is no existing
        /// data in the target model.</para></li><li><para>OVERWRITE – Import the data from the source model and overwrite the existing data
        /// in the target model.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LookoutEquipment.InferenceDataImportStrategy")]
        public Amazon.LookoutEquipment.InferenceDataImportStrategy InferenceDataImportStrategy { get; set; }
        #endregion
        
        #region Parameter LabelsInputConfiguration_LabelGroupName
        /// <summary>
        /// <para>
        /// <para> The name of the label group to be used for label data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LabelsInputConfiguration_LabelGroupName { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name for the machine learning model to be created. If the model already exists,
        /// Amazon Lookout for Equipment creates a new version. If you do not specify this field,
        /// it is filled with the name of the source model.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter S3InputConfiguration_Prefix
        /// <summary>
        /// <para>
        /// <para> The prefix for the S3 bucket used for the label data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LabelsInputConfiguration_S3InputConfiguration_Prefix")]
        public System.String S3InputConfiguration_Prefix { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role with permission to access the data source
        /// being used to create the machine learning model. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter ServerSideKmsKeyId
        /// <summary>
        /// <para>
        /// <para>Provides the identifier of the KMS key key used to encrypt model data by Amazon Lookout
        /// for Equipment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideKmsKeyId { get; set; }
        #endregion
        
        #region Parameter SourceModelVersionArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the model version to import.</para>
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
        public System.String SourceModelVersionArn { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags associated with the machine learning model to be created. </para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LookoutEquipment.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique identifier for the request. If you do not set the client request token, Amazon
        /// Lookout for Equipment generates one. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.ImportModelVersionResponse).
        /// Specifying the name of a property of type Amazon.LookoutEquipment.Model.ImportModelVersionResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.SourceModelVersionArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-L4EModelVersion (ImportModelVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.ImportModelVersionResponse, ImportL4EModelVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InferenceDataImportStrategy = this.InferenceDataImportStrategy;
            context.LabelsInputConfiguration_LabelGroupName = this.LabelsInputConfiguration_LabelGroupName;
            context.S3InputConfiguration_Bucket = this.S3InputConfiguration_Bucket;
            context.S3InputConfiguration_Prefix = this.S3InputConfiguration_Prefix;
            context.ModelName = this.ModelName;
            context.RoleArn = this.RoleArn;
            context.ServerSideKmsKeyId = this.ServerSideKmsKeyId;
            context.SourceModelVersionArn = this.SourceModelVersionArn;
            #if MODULAR
            if (this.SourceModelVersionArn == null && ParameterWasBound(nameof(this.SourceModelVersionArn)))
            {
                WriteWarning("You are passing $null as a value for parameter SourceModelVersionArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.LookoutEquipment.Model.Tag>(this.Tag);
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
            var request = new Amazon.LookoutEquipment.Model.ImportModelVersionRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            if (cmdletContext.InferenceDataImportStrategy != null)
            {
                request.InferenceDataImportStrategy = cmdletContext.InferenceDataImportStrategy;
            }
            
             // populate LabelsInputConfiguration
            var requestLabelsInputConfigurationIsNull = true;
            request.LabelsInputConfiguration = new Amazon.LookoutEquipment.Model.LabelsInputConfiguration();
            System.String requestLabelsInputConfiguration_labelsInputConfiguration_LabelGroupName = null;
            if (cmdletContext.LabelsInputConfiguration_LabelGroupName != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_LabelGroupName = cmdletContext.LabelsInputConfiguration_LabelGroupName;
            }
            if (requestLabelsInputConfiguration_labelsInputConfiguration_LabelGroupName != null)
            {
                request.LabelsInputConfiguration.LabelGroupName = requestLabelsInputConfiguration_labelsInputConfiguration_LabelGroupName;
                requestLabelsInputConfigurationIsNull = false;
            }
            Amazon.LookoutEquipment.Model.LabelsS3InputConfiguration requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration = null;
            
             // populate S3InputConfiguration
            var requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfigurationIsNull = true;
            requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration = new Amazon.LookoutEquipment.Model.LabelsS3InputConfiguration();
            System.String requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket = null;
            if (cmdletContext.S3InputConfiguration_Bucket != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket = cmdletContext.S3InputConfiguration_Bucket;
            }
            if (requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration.Bucket = requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket;
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfigurationIsNull = false;
            }
            System.String requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix = null;
            if (cmdletContext.S3InputConfiguration_Prefix != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix = cmdletContext.S3InputConfiguration_Prefix;
            }
            if (requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix != null)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration.Prefix = requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix;
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfigurationIsNull = false;
            }
             // determine if requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration should be set to null
            if (requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfigurationIsNull)
            {
                requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration = null;
            }
            if (requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration != null)
            {
                request.LabelsInputConfiguration.S3InputConfiguration = requestLabelsInputConfiguration_labelsInputConfiguration_S3InputConfiguration;
                requestLabelsInputConfigurationIsNull = false;
            }
             // determine if request.LabelsInputConfiguration should be set to null
            if (requestLabelsInputConfigurationIsNull)
            {
                request.LabelsInputConfiguration = null;
            }
            if (cmdletContext.ModelName != null)
            {
                request.ModelName = cmdletContext.ModelName;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.ServerSideKmsKeyId != null)
            {
                request.ServerSideKmsKeyId = cmdletContext.ServerSideKmsKeyId;
            }
            if (cmdletContext.SourceModelVersionArn != null)
            {
                request.SourceModelVersionArn = cmdletContext.SourceModelVersionArn;
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
        
        private Amazon.LookoutEquipment.Model.ImportModelVersionResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.ImportModelVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "ImportModelVersion");
            try
            {
                return client.ImportModelVersionAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String DatasetName { get; set; }
            public Amazon.LookoutEquipment.InferenceDataImportStrategy InferenceDataImportStrategy { get; set; }
            public System.String LabelsInputConfiguration_LabelGroupName { get; set; }
            public System.String S3InputConfiguration_Bucket { get; set; }
            public System.String S3InputConfiguration_Prefix { get; set; }
            public System.String ModelName { get; set; }
            public System.String RoleArn { get; set; }
            public System.String ServerSideKmsKeyId { get; set; }
            public System.String SourceModelVersionArn { get; set; }
            public List<Amazon.LookoutEquipment.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.ImportModelVersionResponse, ImportL4EModelVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
