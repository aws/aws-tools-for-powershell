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
    /// Creates a scheduled inference. Scheduling an inference is setting up a continuous
    /// real-time inference plan to analyze new measurement data. When setting up the schedule,
    /// you provide an S3 bucket location for the input data, assign it a delimiter between
    /// separate entries in the data, set an offset delay if desired, and set the frequency
    /// of inferencing. You must also provide an S3 bucket location for the output data.
    /// </summary>
    [Cmdlet("New", "L4EInferenceScheduler", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse")]
    [AWSCmdlet("Calls the Amazon Lookout for Equipment CreateInferenceScheduler API operation.", Operation = new[] {"CreateInferenceScheduler"}, SelectReturnType = typeof(Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse))]
    [AWSCmdletOutput("Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse",
        "This cmdlet returns an Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewL4EInferenceSchedulerCmdlet : AmazonLookoutEquipmentClientCmdlet, IExecutor
    {
        
        #region Parameter S3InputConfiguration_Bucket
        /// <summary>
        /// <para>
        /// <para>The bucket containing the input dataset for the inference. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataInputConfiguration_S3InputConfiguration_Bucket")]
        public System.String S3InputConfiguration_Bucket { get; set; }
        #endregion
        
        #region Parameter S3OutputConfiguration_Bucket
        /// <summary>
        /// <para>
        /// <para> The bucket containing the output results from the inference </para>
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
        [Alias("DataOutputConfiguration_S3OutputConfiguration_Bucket")]
        public System.String S3OutputConfiguration_Bucket { get; set; }
        #endregion
        
        #region Parameter InferenceInputNameConfiguration_ComponentTimestampDelimiter
        /// <summary>
        /// <para>
        /// <para>Indicates the delimiter character used between items in the data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataInputConfiguration_InferenceInputNameConfiguration_ComponentTimestampDelimiter")]
        public System.String InferenceInputNameConfiguration_ComponentTimestampDelimiter { get; set; }
        #endregion
        
        #region Parameter DataDelayOffsetInMinute
        /// <summary>
        /// <para>
        /// <para>A period of time (in minutes) by which inference on the data is delayed after the
        /// data starts. For instance, if you select an offset delay time of five minutes, inference
        /// will not begin on the data until the first data measurement after the five minute
        /// mark. For example, if five minutes is selected, the inference scheduler will wake
        /// up at the configured frequency with the additional five minute delay time to check
        /// the customer S3 bucket. The customer can upload data at the same frequency and they
        /// don't need to stop and restart the scheduler when uploading new data. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataDelayOffsetInMinutes")]
        public System.Int64? DataDelayOffsetInMinute { get; set; }
        #endregion
        
        #region Parameter DataUploadFrequency
        /// <summary>
        /// <para>
        /// <para> How often data is uploaded to the source S3 bucket for the input data. The value
        /// chosen is the length of time between data uploads. For instance, if you select 5 minutes,
        /// Amazon Lookout for Equipment will upload the real-time data to the source bucket once
        /// every 5 minutes. This frequency also determines how often Amazon Lookout for Equipment
        /// starts a scheduled inference on your data. In this example, it starts once every 5
        /// minutes. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.LookoutEquipment.DataUploadFrequency")]
        public Amazon.LookoutEquipment.DataUploadFrequency DataUploadFrequency { get; set; }
        #endregion
        
        #region Parameter InferenceSchedulerName
        /// <summary>
        /// <para>
        /// <para>The name of the inference scheduler being created. </para>
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
        public System.String InferenceSchedulerName { get; set; }
        #endregion
        
        #region Parameter DataInputConfiguration_InputTimeZoneOffset
        /// <summary>
        /// <para>
        /// <para>Indicates the difference between your time zone and Greenwich Mean Time (GMT). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataInputConfiguration_InputTimeZoneOffset { get; set; }
        #endregion
        
        #region Parameter DataOutputConfiguration_KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The ID number for the AWS KMS key used to encrypt the inference output. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DataOutputConfiguration_KmsKeyId { get; set; }
        #endregion
        
        #region Parameter ModelName
        /// <summary>
        /// <para>
        /// <para>The name of the previously trained ML model being used to create the inference scheduler.
        /// </para>
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
        
        #region Parameter S3InputConfiguration_Prefix
        /// <summary>
        /// <para>
        /// <para>The prefix for the S3 bucket used for the input data for the inference. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataInputConfiguration_S3InputConfiguration_Prefix")]
        public System.String S3InputConfiguration_Prefix { get; set; }
        #endregion
        
        #region Parameter S3OutputConfiguration_Prefix
        /// <summary>
        /// <para>
        /// <para> The prefix for the S3 bucket used for the output results from the inference. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataOutputConfiguration_S3OutputConfiguration_Prefix")]
        public System.String S3OutputConfiguration_Prefix { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of a role with permission to access the data source
        /// being used for the inference. </para>
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
        
        #region Parameter ServerSideKmsKeyId
        /// <summary>
        /// <para>
        /// <para>Provides the identifier of the KMS key used to encrypt inference scheduler data by
        /// Amazon Lookout for Equipment. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServerSideKmsKeyId { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Any tags associated with the inference scheduler. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.LookoutEquipment.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter InferenceInputNameConfiguration_TimestampFormat
        /// <summary>
        /// <para>
        /// <para>The format of the timestamp, whether Epoch time, or standard, with or without hyphens
        /// (-). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DataInputConfiguration_InferenceInputNameConfiguration_TimestampFormat")]
        public System.String InferenceInputNameConfiguration_TimestampFormat { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> A unique identifier for the request. If you do not set the client request token,
        /// Amazon Lookout for Equipment generates one. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse).
        /// Specifying the name of a property of type Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InferenceSchedulerName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-L4EInferenceScheduler (CreateInferenceScheduler)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse, NewL4EInferenceSchedulerCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.DataDelayOffsetInMinute = this.DataDelayOffsetInMinute;
            context.InferenceInputNameConfiguration_ComponentTimestampDelimiter = this.InferenceInputNameConfiguration_ComponentTimestampDelimiter;
            context.InferenceInputNameConfiguration_TimestampFormat = this.InferenceInputNameConfiguration_TimestampFormat;
            context.DataInputConfiguration_InputTimeZoneOffset = this.DataInputConfiguration_InputTimeZoneOffset;
            context.S3InputConfiguration_Bucket = this.S3InputConfiguration_Bucket;
            context.S3InputConfiguration_Prefix = this.S3InputConfiguration_Prefix;
            context.DataOutputConfiguration_KmsKeyId = this.DataOutputConfiguration_KmsKeyId;
            context.S3OutputConfiguration_Bucket = this.S3OutputConfiguration_Bucket;
            #if MODULAR
            if (this.S3OutputConfiguration_Bucket == null && ParameterWasBound(nameof(this.S3OutputConfiguration_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3OutputConfiguration_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputConfiguration_Prefix = this.S3OutputConfiguration_Prefix;
            context.DataUploadFrequency = this.DataUploadFrequency;
            #if MODULAR
            if (this.DataUploadFrequency == null && ParameterWasBound(nameof(this.DataUploadFrequency)))
            {
                WriteWarning("You are passing $null as a value for parameter DataUploadFrequency which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.InferenceSchedulerName = this.InferenceSchedulerName;
            #if MODULAR
            if (this.InferenceSchedulerName == null && ParameterWasBound(nameof(this.InferenceSchedulerName)))
            {
                WriteWarning("You are passing $null as a value for parameter InferenceSchedulerName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ModelName = this.ModelName;
            #if MODULAR
            if (this.ModelName == null && ParameterWasBound(nameof(this.ModelName)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServerSideKmsKeyId = this.ServerSideKmsKeyId;
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
            var request = new Amazon.LookoutEquipment.Model.CreateInferenceSchedulerRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.DataDelayOffsetInMinute != null)
            {
                request.DataDelayOffsetInMinutes = cmdletContext.DataDelayOffsetInMinute.Value;
            }
            
             // populate DataInputConfiguration
            var requestDataInputConfigurationIsNull = true;
            request.DataInputConfiguration = new Amazon.LookoutEquipment.Model.InferenceInputConfiguration();
            System.String requestDataInputConfiguration_dataInputConfiguration_InputTimeZoneOffset = null;
            if (cmdletContext.DataInputConfiguration_InputTimeZoneOffset != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_InputTimeZoneOffset = cmdletContext.DataInputConfiguration_InputTimeZoneOffset;
            }
            if (requestDataInputConfiguration_dataInputConfiguration_InputTimeZoneOffset != null)
            {
                request.DataInputConfiguration.InputTimeZoneOffset = requestDataInputConfiguration_dataInputConfiguration_InputTimeZoneOffset;
                requestDataInputConfigurationIsNull = false;
            }
            Amazon.LookoutEquipment.Model.InferenceInputNameConfiguration requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration = null;
            
             // populate InferenceInputNameConfiguration
            var requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfigurationIsNull = true;
            requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration = new Amazon.LookoutEquipment.Model.InferenceInputNameConfiguration();
            System.String requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration_inferenceInputNameConfiguration_ComponentTimestampDelimiter = null;
            if (cmdletContext.InferenceInputNameConfiguration_ComponentTimestampDelimiter != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration_inferenceInputNameConfiguration_ComponentTimestampDelimiter = cmdletContext.InferenceInputNameConfiguration_ComponentTimestampDelimiter;
            }
            if (requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration_inferenceInputNameConfiguration_ComponentTimestampDelimiter != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration.ComponentTimestampDelimiter = requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration_inferenceInputNameConfiguration_ComponentTimestampDelimiter;
                requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfigurationIsNull = false;
            }
            System.String requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration_inferenceInputNameConfiguration_TimestampFormat = null;
            if (cmdletContext.InferenceInputNameConfiguration_TimestampFormat != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration_inferenceInputNameConfiguration_TimestampFormat = cmdletContext.InferenceInputNameConfiguration_TimestampFormat;
            }
            if (requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration_inferenceInputNameConfiguration_TimestampFormat != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration.TimestampFormat = requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration_inferenceInputNameConfiguration_TimestampFormat;
                requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfigurationIsNull = false;
            }
             // determine if requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration should be set to null
            if (requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfigurationIsNull)
            {
                requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration = null;
            }
            if (requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration != null)
            {
                request.DataInputConfiguration.InferenceInputNameConfiguration = requestDataInputConfiguration_dataInputConfiguration_InferenceInputNameConfiguration;
                requestDataInputConfigurationIsNull = false;
            }
            Amazon.LookoutEquipment.Model.InferenceS3InputConfiguration requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration = null;
            
             // populate S3InputConfiguration
            var requestDataInputConfiguration_dataInputConfiguration_S3InputConfigurationIsNull = true;
            requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration = new Amazon.LookoutEquipment.Model.InferenceS3InputConfiguration();
            System.String requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket = null;
            if (cmdletContext.S3InputConfiguration_Bucket != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket = cmdletContext.S3InputConfiguration_Bucket;
            }
            if (requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration.Bucket = requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration_s3InputConfiguration_Bucket;
                requestDataInputConfiguration_dataInputConfiguration_S3InputConfigurationIsNull = false;
            }
            System.String requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix = null;
            if (cmdletContext.S3InputConfiguration_Prefix != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix = cmdletContext.S3InputConfiguration_Prefix;
            }
            if (requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix != null)
            {
                requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration.Prefix = requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration_s3InputConfiguration_Prefix;
                requestDataInputConfiguration_dataInputConfiguration_S3InputConfigurationIsNull = false;
            }
             // determine if requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration should be set to null
            if (requestDataInputConfiguration_dataInputConfiguration_S3InputConfigurationIsNull)
            {
                requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration = null;
            }
            if (requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration != null)
            {
                request.DataInputConfiguration.S3InputConfiguration = requestDataInputConfiguration_dataInputConfiguration_S3InputConfiguration;
                requestDataInputConfigurationIsNull = false;
            }
             // determine if request.DataInputConfiguration should be set to null
            if (requestDataInputConfigurationIsNull)
            {
                request.DataInputConfiguration = null;
            }
            
             // populate DataOutputConfiguration
            var requestDataOutputConfigurationIsNull = true;
            request.DataOutputConfiguration = new Amazon.LookoutEquipment.Model.InferenceOutputConfiguration();
            System.String requestDataOutputConfiguration_dataOutputConfiguration_KmsKeyId = null;
            if (cmdletContext.DataOutputConfiguration_KmsKeyId != null)
            {
                requestDataOutputConfiguration_dataOutputConfiguration_KmsKeyId = cmdletContext.DataOutputConfiguration_KmsKeyId;
            }
            if (requestDataOutputConfiguration_dataOutputConfiguration_KmsKeyId != null)
            {
                request.DataOutputConfiguration.KmsKeyId = requestDataOutputConfiguration_dataOutputConfiguration_KmsKeyId;
                requestDataOutputConfigurationIsNull = false;
            }
            Amazon.LookoutEquipment.Model.InferenceS3OutputConfiguration requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration = null;
            
             // populate S3OutputConfiguration
            var requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfigurationIsNull = true;
            requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration = new Amazon.LookoutEquipment.Model.InferenceS3OutputConfiguration();
            System.String requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Bucket = null;
            if (cmdletContext.S3OutputConfiguration_Bucket != null)
            {
                requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Bucket = cmdletContext.S3OutputConfiguration_Bucket;
            }
            if (requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Bucket != null)
            {
                requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration.Bucket = requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Bucket;
                requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfigurationIsNull = false;
            }
            System.String requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Prefix = null;
            if (cmdletContext.S3OutputConfiguration_Prefix != null)
            {
                requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Prefix = cmdletContext.S3OutputConfiguration_Prefix;
            }
            if (requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Prefix != null)
            {
                requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration.Prefix = requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration_s3OutputConfiguration_Prefix;
                requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfigurationIsNull = false;
            }
             // determine if requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration should be set to null
            if (requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfigurationIsNull)
            {
                requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration = null;
            }
            if (requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration != null)
            {
                request.DataOutputConfiguration.S3OutputConfiguration = requestDataOutputConfiguration_dataOutputConfiguration_S3OutputConfiguration;
                requestDataOutputConfigurationIsNull = false;
            }
             // determine if request.DataOutputConfiguration should be set to null
            if (requestDataOutputConfigurationIsNull)
            {
                request.DataOutputConfiguration = null;
            }
            if (cmdletContext.DataUploadFrequency != null)
            {
                request.DataUploadFrequency = cmdletContext.DataUploadFrequency;
            }
            if (cmdletContext.InferenceSchedulerName != null)
            {
                request.InferenceSchedulerName = cmdletContext.InferenceSchedulerName;
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
        
        private Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse CallAWSServiceOperation(IAmazonLookoutEquipment client, Amazon.LookoutEquipment.Model.CreateInferenceSchedulerRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Equipment", "CreateInferenceScheduler");
            try
            {
                #if DESKTOP
                return client.CreateInferenceScheduler(request);
                #elif CORECLR
                return client.CreateInferenceSchedulerAsync(request).GetAwaiter().GetResult();
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
            public System.Int64? DataDelayOffsetInMinute { get; set; }
            public System.String InferenceInputNameConfiguration_ComponentTimestampDelimiter { get; set; }
            public System.String InferenceInputNameConfiguration_TimestampFormat { get; set; }
            public System.String DataInputConfiguration_InputTimeZoneOffset { get; set; }
            public System.String S3InputConfiguration_Bucket { get; set; }
            public System.String S3InputConfiguration_Prefix { get; set; }
            public System.String DataOutputConfiguration_KmsKeyId { get; set; }
            public System.String S3OutputConfiguration_Bucket { get; set; }
            public System.String S3OutputConfiguration_Prefix { get; set; }
            public Amazon.LookoutEquipment.DataUploadFrequency DataUploadFrequency { get; set; }
            public System.String InferenceSchedulerName { get; set; }
            public System.String ModelName { get; set; }
            public System.String RoleArn { get; set; }
            public System.String ServerSideKmsKeyId { get; set; }
            public List<Amazon.LookoutEquipment.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.LookoutEquipment.Model.CreateInferenceSchedulerResponse, NewL4EInferenceSchedulerCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
