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
using Amazon.LookoutEquipment;
using Amazon.LookoutEquipment.Model;

namespace Amazon.PowerShell.Cmdlets.L4E
{
    /// <summary>
    /// Creates a machine learning model for data inference. 
    /// 
    ///  
    /// <para>
    /// A machine-learning (ML) model is a mathematical model that finds patterns in your
    /// data. In Amazon Lookout for Equipment, the model learns the patterns of normal behavior
    /// and detects abnormal behavior that could be potential equipment failure (or maintenance
    /// events). The models are made by analyzing normal data and abnormalities in machine
    /// behavior that have already occurred.
    /// </para><para>
    /// Your model is trained using a portion of the data from your dataset and uses that
    /// data to learn patterns of normal behavior and abnormal patterns that lead to equipment
    /// failure. Another portion of the data is used to evaluate the model's accuracy. 
    /// </para>
    /// </summary>
    [Cmdlet("New", "L4EModel", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutEquipment.Model.CreateModelResponse")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment CreateModel API operation.", Operation = new[] {"CreateModel"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.CreateModelResponse))]
    [AWSCmdletOutput("Amazon.LookoutEquipment.Model.CreateModelResponse",
        "This cmdlet returns an Amazon.LookoutEquipment.Model.CreateModelResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewL4EModelCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
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
        /// <para>The name of the dataset for the machine learning model being created. </para>
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
        
        #region Parameter EvaluationDataEndTime
        /// <summary>
        /// <para>
        /// <para> Indicates the time reference in the dataset that should be used to end the subset
        /// of evaluation data for the machine learning model. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EvaluationDataEndTime { get; set; }
        #endregion
        
        #region Parameter EvaluationDataStartTime
        /// <summary>
        /// <para>
        /// <para>Indicates the time reference in the dataset that should be used to begin the subset
        /// of evaluation data for the machine learning model. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? EvaluationDataStartTime { get; set; }
        #endregion
        
        #region Parameter DatasetSchema_InlineDataSchema
        /// <summary>
        /// <para>
        /// <para>The data schema used within the given dataset.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DatasetSchema_InlineDataSchema { get; set; }
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
        /// <para>The name for the machine learning model to be created.</para>
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
        public System.String ModelName { get; set; }
        #endregion
        
        #region Parameter OffCondition
        /// <summary>
        /// <para>
        /// <para>Indicates that the asset associated with this sensor has been shut off. As long as
        /// this condition is met, Lookout for Equipment will not use data from this asset for
        /// training, evaluation, or inference.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OffCondition { get; set; }
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
        /// <para> The Amazon Resource Name (ARN) of a role with permission to access the data source
        /// being used to create the machine learning model. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter ServerSideKmsKeyId
        /// <summary>
        /// <para>
        /// <para>Provides the identifier of the KMS key used to encrypt model data by Amazon Lookout
        /// for Equipment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> Any tags associated with the machine learning model being created. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LookoutEquipment.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter DataPreProcessingConfiguration_TargetSamplingRate
        /// <summary>
        /// <para>
        /// <para>The sampling rate of the data after post processing by Amazon Lookout for Equipment.
        /// For example, if you provide data that has been collected at a 1 second level and you
        /// want the system to resample the data at a 1 minute rate before training, the <c>TargetSamplingRate</c>
        /// is 1 minute.</para><para>When providing a value for the <c>TargetSamplingRate</c>, you must attach the prefix
        /// "PT" to the rate you want. The value for a 1 second rate is therefore <i>PT1S</i>,
        /// the value for a 15 minute rate is <i>PT15M</i>, and the value for a 1 hour rate is
        /// <i>PT1H</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.LookoutEquipment.TargetSamplingRate")]
        public Amazon.LookoutEquipment.TargetSamplingRate DataPreProcessingConfiguration_TargetSamplingRate { get; set; }
        #endregion
        
        #region Parameter TrainingDataEndTime
        /// <summary>
        /// <para>
        /// <para>Indicates the time reference in the dataset that should be used to end the subset
        /// of training data for the machine learning model. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TrainingDataEndTime { get; set; }
        #endregion
        
        #region Parameter TrainingDataStartTime
        /// <summary>
        /// <para>
        /// <para>Indicates the time reference in the dataset that should be used to begin the subset
        /// of training data for the machine learning model. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? TrainingDataStartTime { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.CreateModelResponse).
        /// Specifying the name of a property of type Amazon.LookoutEquipment.Model.CreateModelResponse will result in that property being returned.
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
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ModelName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-L4EModel (CreateModel)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.CreateModelResponse, NewL4EModelCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DataPreProcessingConfiguration_TargetSamplingRate = this.DataPreProcessingConfiguration_TargetSamplingRate;
            context.DatasetName = this.DatasetName;
            #if MODULAR
            if (this.DatasetName == null && ParameterWasBound(nameof(this.DatasetName)))
            {
                WriteWarning("You are passing $null as a value for parameter DatasetName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.DatasetSchema_InlineDataSchema = this.DatasetSchema_InlineDataSchema;
            context.EvaluationDataEndTime = this.EvaluationDataEndTime;
            context.EvaluationDataStartTime = this.EvaluationDataStartTime;
            context.LabelsInputConfiguration_LabelGroupName = this.LabelsInputConfiguration_LabelGroupName;
            context.S3InputConfiguration_Bucket = this.S3InputConfiguration_Bucket;
            context.S3InputConfiguration_Prefix = this.S3InputConfiguration_Prefix;
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OffCondition = this.OffCondition;
            context.RoleArn = this.RoleArn;
            context.ServerSideKmsKeyId = this.ServerSideKmsKeyId;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.LookoutEquipment.Model.Tag>(this.Tag);
            }
            context.TrainingDataEndTime = this.TrainingDataEndTime;
            context.TrainingDataStartTime = this.TrainingDataStartTime;
            
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
            var request = new Amazon.LookoutEquipment.Model.CreateModelRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DataPreProcessingConfiguration
            var requestDataPreProcessingConfigurationIsNull = true;
            request.DataPreProcessingConfiguration = new Amazon.LookoutEquipment.Model.DataPreProcessingConfiguration();
            Amazon.LookoutEquipment.TargetSamplingRate requestDataPreProcessingConfiguration_dataPreProcessingConfiguration_TargetSamplingRate = null;
            if (cmdletContext.DataPreProcessingConfiguration_TargetSamplingRate != null)
            {
                requestDataPreProcessingConfiguration_dataPreProcessingConfiguration_TargetSamplingRate = cmdletContext.DataPreProcessingConfiguration_TargetSamplingRate;
            }
            if (requestDataPreProcessingConfiguration_dataPreProcessingConfiguration_TargetSamplingRate != null)
            {
                request.DataPreProcessingConfiguration.TargetSamplingRate = requestDataPreProcessingConfiguration_dataPreProcessingConfiguration_TargetSamplingRate;
                requestDataPreProcessingConfigurationIsNull = false;
            }
             // determine if request.DataPreProcessingConfiguration should be set to null
            if (requestDataPreProcessingConfigurationIsNull)
            {
                request.DataPreProcessingConfiguration = null;
            }
            if (cmdletContext.DatasetName != null)
            {
                request.DatasetName = cmdletContext.DatasetName;
            }
            
             // populate DatasetSchema
            var requestDatasetSchemaIsNull = true;
            request.DatasetSchema = new Amazon.LookoutEquipment.Model.DatasetSchema();
            System.String requestDatasetSchema_datasetSchema_InlineDataSchema = null;
            if (cmdletContext.DatasetSchema_InlineDataSchema != null)
            {
                requestDatasetSchema_datasetSchema_InlineDataSchema = cmdletContext.DatasetSchema_InlineDataSchema;
            }
            if (requestDatasetSchema_datasetSchema_InlineDataSchema != null)
            {
                request.DatasetSchema.InlineDataSchema = requestDatasetSchema_datasetSchema_InlineDataSchema;
                requestDatasetSchemaIsNull = false;
            }
             // determine if request.DatasetSchema should be set to null
            if (requestDatasetSchemaIsNull)
            {
                request.DatasetSchema = null;
            }
            if (cmdletContext.EvaluationDataEndTime != null)
            {
                request.EvaluationDataEndTime = cmdletContext.EvaluationDataEndTime.Value;
            }
            if (cmdletContext.EvaluationDataStartTime != null)
            {
                request.EvaluationDataStartTime = cmdletContext.EvaluationDataStartTime.Value;
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
            if (cmdletContext.OffCondition != null)
            {
                request.OffCondition = cmdletContext.OffCondition;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.ServerSideKmsKeyId != null)
            {
                request.ServerSideKmsKeyId = cmdletContext.ServerSideKmsKeyId;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TrainingDataEndTime != null)
            {
                request.TrainingDataEndTime = cmdletContext.TrainingDataEndTime.Value;
            }
            if (cmdletContext.TrainingDataStartTime != null)
            {
                request.TrainingDataStartTime = cmdletContext.TrainingDataStartTime.Value;
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
        
        private Amazon.LookoutEquipment.Model.CreateModelResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.CreateModelRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "CreateModel");
            try
            {
                #if DESKTOP
                return client.CreateModel(request);
                #elif CORECLR
                return client.CreateModelAsync(request).GetAwaiter().GetResult();
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
            public Amazon.LookoutEquipment.TargetSamplingRate DataPreProcessingConfiguration_TargetSamplingRate { get; set; }
            public System.String DatasetName { get; set; }
            public System.String DatasetSchema_InlineDataSchema { get; set; }
            public System.DateTime? EvaluationDataEndTime { get; set; }
            public System.DateTime? EvaluationDataStartTime { get; set; }
            public System.String LabelsInputConfiguration_LabelGroupName { get; set; }
            public System.String S3InputConfiguration_Bucket { get; set; }
            public System.String S3InputConfiguration_Prefix { get; set; }
            public System.String ModelName { get; set; }
            public System.String OffCondition { get; set; }
            public System.String RoleArn { get; set; }
            public System.String ServerSideKmsKeyId { get; set; }
            public List<Amazon.LookoutEquipment.Model.Tag> Tag { get; set; }
            public System.DateTime? TrainingDataEndTime { get; set; }
            public System.DateTime? TrainingDataStartTime { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.CreateModelResponse, NewL4EModelCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
