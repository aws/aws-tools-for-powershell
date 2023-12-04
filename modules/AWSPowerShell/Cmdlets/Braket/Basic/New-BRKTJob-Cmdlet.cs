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
using Amazon.Braket;
using Amazon.Braket.Model;

namespace Amazon.PowerShell.Cmdlets.BRKT
{
    /// <summary>
    /// Creates an Amazon Braket job.
    /// </summary>
    [Cmdlet("New", "BRKTJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Braket CreateJob API operation.", Operation = new[] {"CreateJob"}, SelectReturnType = typeof(Amazon.Braket.Model.CreateJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.Braket.Model.CreateJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Braket.Model.CreateJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewBRKTJobCmdlet : AmazonBraketClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Association
        /// <summary>
        /// <para>
        /// <para>The list of Amazon Braket resources associated with the hybrid job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Associations")]
        public Amazon.Braket.Model.Association[] Association { get; set; }
        #endregion
        
        #region Parameter ScriptModeConfig_CompressionType
        /// <summary>
        /// <para>
        /// <para>The type of compression used by the Python scripts for an Amazon Braket job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlgorithmSpecification_ScriptModeConfig_CompressionType")]
        [AWSConstantClassSource("Amazon.Braket.CompressionType")]
        public Amazon.Braket.CompressionType ScriptModeConfig_CompressionType { get; set; }
        #endregion
        
        #region Parameter DeviceConfig_Device
        /// <summary>
        /// <para>
        /// <para>The primary quantum processing unit (QPU) or simulator used to create and run an Amazon
        /// Braket job.</para>
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
        public System.String DeviceConfig_Device { get; set; }
        #endregion
        
        #region Parameter ScriptModeConfig_EntryPoint
        /// <summary>
        /// <para>
        /// <para>The path to the Python script that serves as the entry point for an Amazon Braket
        /// job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlgorithmSpecification_ScriptModeConfig_EntryPoint")]
        public System.String ScriptModeConfig_EntryPoint { get; set; }
        #endregion
        
        #region Parameter HyperParameter
        /// <summary>
        /// <para>
        /// <para>Algorithm-specific parameters used by an Amazon Braket job that influence the quality
        /// of the training job. The values are set with a string of JSON key:value pairs, where
        /// the key is the name of the hyperparameter and the value is the value of th hyperparameter.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HyperParameters")]
        public System.Collections.Hashtable HyperParameter { get; set; }
        #endregion
        
        #region Parameter InputDataConfig
        /// <summary>
        /// <para>
        /// <para>A list of parameters that specify the name and type of input data and where it is
        /// located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.Braket.Model.InputFileConfig[] InputDataConfig { get; set; }
        #endregion
        
        #region Parameter InstanceConfig_InstanceCount
        /// <summary>
        /// <para>
        /// <para>Configures the number of resource instances to use while running an Amazon Braket
        /// job on Amazon Braket. The default value is 1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? InstanceConfig_InstanceCount { get; set; }
        #endregion
        
        #region Parameter InstanceConfig_InstanceType
        /// <summary>
        /// <para>
        /// <para>Configures the type resource instances to use while running an Amazon Braket hybrid
        /// job.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Braket.InstanceType")]
        public Amazon.Braket.InstanceType InstanceConfig_InstanceType { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon Braket job.</para>
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
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The AWS Key Management Service (AWS KMS) key that Amazon Braket uses to encrypt the
        /// job training artifacts at rest using Amazon S3 server-side encryption.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputDataConfig_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter CheckpointConfig_LocalPath
        /// <summary>
        /// <para>
        /// <para>(Optional) The local directory where checkpoints are written. The default directory
        /// is <code>/opt/braket/checkpoints/</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CheckpointConfig_LocalPath { get; set; }
        #endregion
        
        #region Parameter StoppingCondition_MaxRuntimeInSecond
        /// <summary>
        /// <para>
        /// <para>The maximum length of time, in seconds, that an Amazon Braket job can run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StoppingCondition_MaxRuntimeInSeconds")]
        public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an IAM role that Amazon Braket can assume to perform
        /// tasks on behalf of a user. It can access user resources, run an Amazon Braket job
        /// container on behalf of user, and output resources to the users' s3 buckets.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter OutputDataConfig_S3Path
        /// <summary>
        /// <para>
        /// <para>Identifies the S3 path where you want Amazon Braket to store the job training artifacts.
        /// For example, <code>s3://bucket-name/key-name-prefix</code>.</para>
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
        public System.String OutputDataConfig_S3Path { get; set; }
        #endregion
        
        #region Parameter ScriptModeConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>The URI that specifies the S3 path to the Python script module that contains the training
        /// script used by an Amazon Braket job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlgorithmSpecification_ScriptModeConfig_S3Uri")]
        public System.String ScriptModeConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter CheckpointConfig_S3Uri
        /// <summary>
        /// <para>
        /// <para>Identifies the S3 path where you want Amazon Braket to store checkpoints. For example,
        /// <code>s3://bucket-name/key-name-prefix</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CheckpointConfig_S3Uri { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A tag object that consists of a key and an optional value, used to manage metadata
        /// for Amazon Braket resources.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ContainerImage_Uri
        /// <summary>
        /// <para>
        /// <para>The URI locating the container image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AlgorithmSpecification_ContainerImage_Uri")]
        public System.String ContainerImage_Uri { get; set; }
        #endregion
        
        #region Parameter InstanceConfig_VolumeSizeInGb
        /// <summary>
        /// <para>
        /// <para>The size of the storage volume, in GB, that user wants to provision.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int32? InstanceConfig_VolumeSizeInGb { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>A unique token that guarantees that the call to this API is idempotent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Braket.Model.CreateJobResponse).
        /// Specifying the name of a property of type Amazon.Braket.Model.CreateJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.JobName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-BRKTJob (CreateJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Braket.Model.CreateJobResponse, NewBRKTJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContainerImage_Uri = this.ContainerImage_Uri;
            context.ScriptModeConfig_CompressionType = this.ScriptModeConfig_CompressionType;
            context.ScriptModeConfig_EntryPoint = this.ScriptModeConfig_EntryPoint;
            context.ScriptModeConfig_S3Uri = this.ScriptModeConfig_S3Uri;
            if (this.Association != null)
            {
                context.Association = new List<Amazon.Braket.Model.Association>(this.Association);
            }
            context.CheckpointConfig_LocalPath = this.CheckpointConfig_LocalPath;
            context.CheckpointConfig_S3Uri = this.CheckpointConfig_S3Uri;
            context.ClientToken = this.ClientToken;
            context.DeviceConfig_Device = this.DeviceConfig_Device;
            #if MODULAR
            if (this.DeviceConfig_Device == null && ParameterWasBound(nameof(this.DeviceConfig_Device)))
            {
                WriteWarning("You are passing $null as a value for parameter DeviceConfig_Device which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.HyperParameter != null)
            {
                context.HyperParameter = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.HyperParameter.Keys)
                {
                    context.HyperParameter.Add((String)hashKey, (String)(this.HyperParameter[hashKey]));
                }
            }
            if (this.InputDataConfig != null)
            {
                context.InputDataConfig = new List<Amazon.Braket.Model.InputFileConfig>(this.InputDataConfig);
            }
            context.InstanceConfig_InstanceCount = this.InstanceConfig_InstanceCount;
            context.InstanceConfig_InstanceType = this.InstanceConfig_InstanceType;
            #if MODULAR
            if (this.InstanceConfig_InstanceType == null && ParameterWasBound(nameof(this.InstanceConfig_InstanceType)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceConfig_InstanceType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InstanceConfig_VolumeSizeInGb = this.InstanceConfig_VolumeSizeInGb;
            #if MODULAR
            if (this.InstanceConfig_VolumeSizeInGb == null && ParameterWasBound(nameof(this.InstanceConfig_VolumeSizeInGb)))
            {
                WriteWarning("You are passing $null as a value for parameter InstanceConfig_VolumeSizeInGb which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.JobName = this.JobName;
            #if MODULAR
            if (this.JobName == null && ParameterWasBound(nameof(this.JobName)))
            {
                WriteWarning("You are passing $null as a value for parameter JobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputDataConfig_KmsKeyId = this.OutputDataConfig_KmsKeyId;
            context.OutputDataConfig_S3Path = this.OutputDataConfig_S3Path;
            #if MODULAR
            if (this.OutputDataConfig_S3Path == null && ParameterWasBound(nameof(this.OutputDataConfig_S3Path)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputDataConfig_S3Path which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.StoppingCondition_MaxRuntimeInSecond = this.StoppingCondition_MaxRuntimeInSecond;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
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
            var request = new Amazon.Braket.Model.CreateJobRequest();
            
            
             // populate AlgorithmSpecification
            var requestAlgorithmSpecificationIsNull = true;
            request.AlgorithmSpecification = new Amazon.Braket.Model.AlgorithmSpecification();
            Amazon.Braket.Model.ContainerImage requestAlgorithmSpecification_algorithmSpecification_ContainerImage = null;
            
             // populate ContainerImage
            var requestAlgorithmSpecification_algorithmSpecification_ContainerImageIsNull = true;
            requestAlgorithmSpecification_algorithmSpecification_ContainerImage = new Amazon.Braket.Model.ContainerImage();
            System.String requestAlgorithmSpecification_algorithmSpecification_ContainerImage_containerImage_Uri = null;
            if (cmdletContext.ContainerImage_Uri != null)
            {
                requestAlgorithmSpecification_algorithmSpecification_ContainerImage_containerImage_Uri = cmdletContext.ContainerImage_Uri;
            }
            if (requestAlgorithmSpecification_algorithmSpecification_ContainerImage_containerImage_Uri != null)
            {
                requestAlgorithmSpecification_algorithmSpecification_ContainerImage.Uri = requestAlgorithmSpecification_algorithmSpecification_ContainerImage_containerImage_Uri;
                requestAlgorithmSpecification_algorithmSpecification_ContainerImageIsNull = false;
            }
             // determine if requestAlgorithmSpecification_algorithmSpecification_ContainerImage should be set to null
            if (requestAlgorithmSpecification_algorithmSpecification_ContainerImageIsNull)
            {
                requestAlgorithmSpecification_algorithmSpecification_ContainerImage = null;
            }
            if (requestAlgorithmSpecification_algorithmSpecification_ContainerImage != null)
            {
                request.AlgorithmSpecification.ContainerImage = requestAlgorithmSpecification_algorithmSpecification_ContainerImage;
                requestAlgorithmSpecificationIsNull = false;
            }
            Amazon.Braket.Model.ScriptModeConfig requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig = null;
            
             // populate ScriptModeConfig
            var requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfigIsNull = true;
            requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig = new Amazon.Braket.Model.ScriptModeConfig();
            Amazon.Braket.CompressionType requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_CompressionType = null;
            if (cmdletContext.ScriptModeConfig_CompressionType != null)
            {
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_CompressionType = cmdletContext.ScriptModeConfig_CompressionType;
            }
            if (requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_CompressionType != null)
            {
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig.CompressionType = requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_CompressionType;
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfigIsNull = false;
            }
            System.String requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_EntryPoint = null;
            if (cmdletContext.ScriptModeConfig_EntryPoint != null)
            {
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_EntryPoint = cmdletContext.ScriptModeConfig_EntryPoint;
            }
            if (requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_EntryPoint != null)
            {
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig.EntryPoint = requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_EntryPoint;
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfigIsNull = false;
            }
            System.String requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_S3Uri = null;
            if (cmdletContext.ScriptModeConfig_S3Uri != null)
            {
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_S3Uri = cmdletContext.ScriptModeConfig_S3Uri;
            }
            if (requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_S3Uri != null)
            {
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig.S3Uri = requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig_scriptModeConfig_S3Uri;
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfigIsNull = false;
            }
             // determine if requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig should be set to null
            if (requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfigIsNull)
            {
                requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig = null;
            }
            if (requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig != null)
            {
                request.AlgorithmSpecification.ScriptModeConfig = requestAlgorithmSpecification_algorithmSpecification_ScriptModeConfig;
                requestAlgorithmSpecificationIsNull = false;
            }
             // determine if request.AlgorithmSpecification should be set to null
            if (requestAlgorithmSpecificationIsNull)
            {
                request.AlgorithmSpecification = null;
            }
            if (cmdletContext.Association != null)
            {
                request.Associations = cmdletContext.Association;
            }
            
             // populate CheckpointConfig
            var requestCheckpointConfigIsNull = true;
            request.CheckpointConfig = new Amazon.Braket.Model.JobCheckpointConfig();
            System.String requestCheckpointConfig_checkpointConfig_LocalPath = null;
            if (cmdletContext.CheckpointConfig_LocalPath != null)
            {
                requestCheckpointConfig_checkpointConfig_LocalPath = cmdletContext.CheckpointConfig_LocalPath;
            }
            if (requestCheckpointConfig_checkpointConfig_LocalPath != null)
            {
                request.CheckpointConfig.LocalPath = requestCheckpointConfig_checkpointConfig_LocalPath;
                requestCheckpointConfigIsNull = false;
            }
            System.String requestCheckpointConfig_checkpointConfig_S3Uri = null;
            if (cmdletContext.CheckpointConfig_S3Uri != null)
            {
                requestCheckpointConfig_checkpointConfig_S3Uri = cmdletContext.CheckpointConfig_S3Uri;
            }
            if (requestCheckpointConfig_checkpointConfig_S3Uri != null)
            {
                request.CheckpointConfig.S3Uri = requestCheckpointConfig_checkpointConfig_S3Uri;
                requestCheckpointConfigIsNull = false;
            }
             // determine if request.CheckpointConfig should be set to null
            if (requestCheckpointConfigIsNull)
            {
                request.CheckpointConfig = null;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate DeviceConfig
            var requestDeviceConfigIsNull = true;
            request.DeviceConfig = new Amazon.Braket.Model.DeviceConfig();
            System.String requestDeviceConfig_deviceConfig_Device = null;
            if (cmdletContext.DeviceConfig_Device != null)
            {
                requestDeviceConfig_deviceConfig_Device = cmdletContext.DeviceConfig_Device;
            }
            if (requestDeviceConfig_deviceConfig_Device != null)
            {
                request.DeviceConfig.Device = requestDeviceConfig_deviceConfig_Device;
                requestDeviceConfigIsNull = false;
            }
             // determine if request.DeviceConfig should be set to null
            if (requestDeviceConfigIsNull)
            {
                request.DeviceConfig = null;
            }
            if (cmdletContext.HyperParameter != null)
            {
                request.HyperParameters = cmdletContext.HyperParameter;
            }
            if (cmdletContext.InputDataConfig != null)
            {
                request.InputDataConfig = cmdletContext.InputDataConfig;
            }
            
             // populate InstanceConfig
            var requestInstanceConfigIsNull = true;
            request.InstanceConfig = new Amazon.Braket.Model.InstanceConfig();
            System.Int32? requestInstanceConfig_instanceConfig_InstanceCount = null;
            if (cmdletContext.InstanceConfig_InstanceCount != null)
            {
                requestInstanceConfig_instanceConfig_InstanceCount = cmdletContext.InstanceConfig_InstanceCount.Value;
            }
            if (requestInstanceConfig_instanceConfig_InstanceCount != null)
            {
                request.InstanceConfig.InstanceCount = requestInstanceConfig_instanceConfig_InstanceCount.Value;
                requestInstanceConfigIsNull = false;
            }
            Amazon.Braket.InstanceType requestInstanceConfig_instanceConfig_InstanceType = null;
            if (cmdletContext.InstanceConfig_InstanceType != null)
            {
                requestInstanceConfig_instanceConfig_InstanceType = cmdletContext.InstanceConfig_InstanceType;
            }
            if (requestInstanceConfig_instanceConfig_InstanceType != null)
            {
                request.InstanceConfig.InstanceType = requestInstanceConfig_instanceConfig_InstanceType;
                requestInstanceConfigIsNull = false;
            }
            System.Int32? requestInstanceConfig_instanceConfig_VolumeSizeInGb = null;
            if (cmdletContext.InstanceConfig_VolumeSizeInGb != null)
            {
                requestInstanceConfig_instanceConfig_VolumeSizeInGb = cmdletContext.InstanceConfig_VolumeSizeInGb.Value;
            }
            if (requestInstanceConfig_instanceConfig_VolumeSizeInGb != null)
            {
                request.InstanceConfig.VolumeSizeInGb = requestInstanceConfig_instanceConfig_VolumeSizeInGb.Value;
                requestInstanceConfigIsNull = false;
            }
             // determine if request.InstanceConfig should be set to null
            if (requestInstanceConfigIsNull)
            {
                request.InstanceConfig = null;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            
             // populate OutputDataConfig
            var requestOutputDataConfigIsNull = true;
            request.OutputDataConfig = new Amazon.Braket.Model.JobOutputDataConfig();
            System.String requestOutputDataConfig_outputDataConfig_KmsKeyId = null;
            if (cmdletContext.OutputDataConfig_KmsKeyId != null)
            {
                requestOutputDataConfig_outputDataConfig_KmsKeyId = cmdletContext.OutputDataConfig_KmsKeyId;
            }
            if (requestOutputDataConfig_outputDataConfig_KmsKeyId != null)
            {
                request.OutputDataConfig.KmsKeyId = requestOutputDataConfig_outputDataConfig_KmsKeyId;
                requestOutputDataConfigIsNull = false;
            }
            System.String requestOutputDataConfig_outputDataConfig_S3Path = null;
            if (cmdletContext.OutputDataConfig_S3Path != null)
            {
                requestOutputDataConfig_outputDataConfig_S3Path = cmdletContext.OutputDataConfig_S3Path;
            }
            if (requestOutputDataConfig_outputDataConfig_S3Path != null)
            {
                request.OutputDataConfig.S3Path = requestOutputDataConfig_outputDataConfig_S3Path;
                requestOutputDataConfigIsNull = false;
            }
             // determine if request.OutputDataConfig should be set to null
            if (requestOutputDataConfigIsNull)
            {
                request.OutputDataConfig = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            
             // populate StoppingCondition
            var requestStoppingConditionIsNull = true;
            request.StoppingCondition = new Amazon.Braket.Model.JobStoppingCondition();
            System.Int32? requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = null;
            if (cmdletContext.StoppingCondition_MaxRuntimeInSecond != null)
            {
                requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond = cmdletContext.StoppingCondition_MaxRuntimeInSecond.Value;
            }
            if (requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond != null)
            {
                request.StoppingCondition.MaxRuntimeInSeconds = requestStoppingCondition_stoppingCondition_MaxRuntimeInSecond.Value;
                requestStoppingConditionIsNull = false;
            }
             // determine if request.StoppingCondition should be set to null
            if (requestStoppingConditionIsNull)
            {
                request.StoppingCondition = null;
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
        
        private Amazon.Braket.Model.CreateJobResponse CallAWSServiceOperation(IAmazonBraket client, Amazon.Braket.Model.CreateJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Braket", "CreateJob");
            try
            {
                #if DESKTOP
                return client.CreateJob(request);
                #elif CORECLR
                return client.CreateJobAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerImage_Uri { get; set; }
            public Amazon.Braket.CompressionType ScriptModeConfig_CompressionType { get; set; }
            public System.String ScriptModeConfig_EntryPoint { get; set; }
            public System.String ScriptModeConfig_S3Uri { get; set; }
            public List<Amazon.Braket.Model.Association> Association { get; set; }
            public System.String CheckpointConfig_LocalPath { get; set; }
            public System.String CheckpointConfig_S3Uri { get; set; }
            public System.String ClientToken { get; set; }
            public System.String DeviceConfig_Device { get; set; }
            public Dictionary<System.String, System.String> HyperParameter { get; set; }
            public List<Amazon.Braket.Model.InputFileConfig> InputDataConfig { get; set; }
            public System.Int32? InstanceConfig_InstanceCount { get; set; }
            public Amazon.Braket.InstanceType InstanceConfig_InstanceType { get; set; }
            public System.Int32? InstanceConfig_VolumeSizeInGb { get; set; }
            public System.String JobName { get; set; }
            public System.String OutputDataConfig_KmsKeyId { get; set; }
            public System.String OutputDataConfig_S3Path { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? StoppingCondition_MaxRuntimeInSecond { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Braket.Model.CreateJobResponse, NewBRKTJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobArn;
        }
        
    }
}
