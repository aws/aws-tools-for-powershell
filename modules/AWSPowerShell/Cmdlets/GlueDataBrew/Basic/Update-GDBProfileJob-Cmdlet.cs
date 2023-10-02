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
using Amazon.GlueDataBrew;
using Amazon.GlueDataBrew.Model;

namespace Amazon.PowerShell.Cmdlets.GDB
{
    /// <summary>
    /// Modifies the definition of an existing profile job.
    /// </summary>
    [Cmdlet("Update", "GDBProfileJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Glue DataBrew UpdateProfileJob API operation.", Operation = new[] {"UpdateProfileJob"}, SelectReturnType = typeof(Amazon.GlueDataBrew.Model.UpdateProfileJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.GlueDataBrew.Model.UpdateProfileJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.GlueDataBrew.Model.UpdateProfileJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateGDBProfileJobCmdlet : AmazonGlueDataBrewClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter EntityDetectorConfiguration_AllowedStatistic
        /// <summary>
        /// <para>
        /// <para>Configuration of statistics that are allowed to be run on columns that contain detected
        /// entities. When undefined, no statistics will be computed on columns that contain detected
        /// entities.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EntityDetectorConfiguration_AllowedStatistics")]
        public Amazon.GlueDataBrew.Model.AllowedStatistics[] EntityDetectorConfiguration_AllowedStatistic { get; set; }
        #endregion
        
        #region Parameter OutputLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket name.</para>
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
        public System.String OutputLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter OutputLocation_BucketOwner
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID of the bucket owner.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputLocation_BucketOwner { get; set; }
        #endregion
        
        #region Parameter Configuration_ColumnStatisticsConfiguration
        /// <summary>
        /// <para>
        /// <para>List of configurations for column evaluations. ColumnStatisticsConfigurations are
        /// used to select evaluations and override parameters of evaluations for particular columns.
        /// When ColumnStatisticsConfigurations is undefined, the profile job will profile all
        /// supported columns and run all supported evaluations. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ColumnStatisticsConfigurations")]
        public Amazon.GlueDataBrew.Model.ColumnStatisticsConfiguration[] Configuration_ColumnStatisticsConfiguration { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of an encryption key that is used to protect the job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyArn { get; set; }
        #endregion
        
        #region Parameter EncryptionMode
        /// <summary>
        /// <para>
        /// <para>The encryption mode for the job, which can be one of the following:</para><ul><li><para><code>SSE-KMS</code> - Server-side encryption with keys managed by KMS.</para></li><li><para><code>SSE-S3</code> - Server-side encryption with keys managed by Amazon S3.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.EncryptionMode")]
        public Amazon.GlueDataBrew.EncryptionMode EncryptionMode { get; set; }
        #endregion
        
        #region Parameter EntityDetectorConfiguration_EntityType
        /// <summary>
        /// <para>
        /// <para>Entity types to detect. Can be any of the following:</para><ul><li><para>USA_SSN</para></li><li><para>EMAIL</para></li><li><para>USA_ITIN</para></li><li><para>USA_PASSPORT_NUMBER</para></li><li><para>PHONE_NUMBER</para></li><li><para>USA_DRIVING_LICENSE</para></li><li><para>BANK_ACCOUNT</para></li><li><para>CREDIT_CARD</para></li><li><para>IP_ADDRESS</para></li><li><para>MAC_ADDRESS</para></li><li><para>USA_DEA_NUMBER</para></li><li><para>USA_HCPCS_CODE</para></li><li><para>USA_NATIONAL_PROVIDER_IDENTIFIER</para></li><li><para>USA_NATIONAL_DRUG_CODE</para></li><li><para>USA_HEALTH_INSURANCE_CLAIM_NUMBER</para></li><li><para>USA_MEDICARE_BENEFICIARY_IDENTIFIER</para></li><li><para>USA_CPT_CODE</para></li><li><para>PERSON_NAME</para></li><li><para>DATE</para></li></ul><para>The Entity type group USA_ALL is also supported, and includes all of the above entity
        /// types except PERSON_NAME and DATE.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_EntityDetectorConfiguration_EntityTypes")]
        public System.String[] EntityDetectorConfiguration_EntityType { get; set; }
        #endregion
        
        #region Parameter DatasetStatisticsConfiguration_IncludedStatistic
        /// <summary>
        /// <para>
        /// <para>List of included evaluations. When the list is undefined, all supported evaluations
        /// will be included.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DatasetStatisticsConfiguration_IncludedStatistics")]
        public System.String[] DatasetStatisticsConfiguration_IncludedStatistic { get; set; }
        #endregion
        
        #region Parameter OutputLocation_Key
        /// <summary>
        /// <para>
        /// <para>The unique name of the object in the bucket.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutputLocation_Key { get; set; }
        #endregion
        
        #region Parameter LogSubscription
        /// <summary>
        /// <para>
        /// <para>Enables or disables Amazon CloudWatch logging for the job. If logging is enabled,
        /// CloudWatch writes one log stream for each job run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.LogSubscription")]
        public Amazon.GlueDataBrew.LogSubscription LogSubscription { get; set; }
        #endregion
        
        #region Parameter MaxCapacity
        /// <summary>
        /// <para>
        /// <para>The maximum number of compute nodes that DataBrew can use when the job processes data.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxCapacity { get; set; }
        #endregion
        
        #region Parameter MaxRetry
        /// <summary>
        /// <para>
        /// <para>The maximum number of times to retry the job after a job run fails.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxRetries")]
        public System.Int32? MaxRetry { get; set; }
        #endregion
        
        #region Parameter JobSample_Mode
        /// <summary>
        /// <para>
        /// <para>A value that determines whether the profile job is run on the entire dataset or a
        /// specified number of rows. This value must be one of the following:</para><ul><li><para>FULL_DATASET - The profile job is run on the entire dataset.</para></li><li><para>CUSTOM_ROWS - The profile job is run on the number of rows specified in the <code>Size</code>
        /// parameter.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.GlueDataBrew.SampleMode")]
        public Amazon.GlueDataBrew.SampleMode JobSample_Mode { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the job to be updated.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter DatasetStatisticsConfiguration_Override
        /// <summary>
        /// <para>
        /// <para>List of overrides for evaluations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_DatasetStatisticsConfiguration_Overrides")]
        public Amazon.GlueDataBrew.Model.StatisticOverride[] DatasetStatisticsConfiguration_Override { get; set; }
        #endregion
        
        #region Parameter Configuration_ProfileColumn
        /// <summary>
        /// <para>
        /// <para>List of column selectors. ProfileColumns can be used to select columns from the dataset.
        /// When ProfileColumns is undefined, the profile job will profile all supported columns.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_ProfileColumns")]
        public Amazon.GlueDataBrew.Model.ColumnSelector[] Configuration_ProfileColumn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the Identity and Access Management (IAM) role to
        /// be assumed when DataBrew runs the job.</para>
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
        
        #region Parameter JobSample_Size
        /// <summary>
        /// <para>
        /// <para>The <code>Size</code> parameter is only required when the mode is CUSTOM_ROWS. The
        /// profile job is run on the specified number of rows. The maximum value for size is
        /// Long.MAX_VALUE.</para><para>Long.MAX_VALUE = 9223372036854775807</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int64? JobSample_Size { get; set; }
        #endregion
        
        #region Parameter Timeout
        /// <summary>
        /// <para>
        /// <para>The job's timeout in minutes. A job that attempts to run longer than this timeout
        /// period ends with a status of <code>TIMEOUT</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Timeout { get; set; }
        #endregion
        
        #region Parameter ValidationConfiguration
        /// <summary>
        /// <para>
        /// <para>List of validation configurations that are applied to the profile job.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ValidationConfigurations")]
        public Amazon.GlueDataBrew.Model.ValidationConfiguration[] ValidationConfiguration { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Name'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.GlueDataBrew.Model.UpdateProfileJobResponse).
        /// Specifying the name of a property of type Amazon.GlueDataBrew.Model.UpdateProfileJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Name";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-GDBProfileJob (UpdateProfileJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.GlueDataBrew.Model.UpdateProfileJobResponse, UpdateGDBProfileJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.Configuration_ColumnStatisticsConfiguration != null)
            {
                context.Configuration_ColumnStatisticsConfiguration = new List<Amazon.GlueDataBrew.Model.ColumnStatisticsConfiguration>(this.Configuration_ColumnStatisticsConfiguration);
            }
            if (this.DatasetStatisticsConfiguration_IncludedStatistic != null)
            {
                context.DatasetStatisticsConfiguration_IncludedStatistic = new List<System.String>(this.DatasetStatisticsConfiguration_IncludedStatistic);
            }
            if (this.DatasetStatisticsConfiguration_Override != null)
            {
                context.DatasetStatisticsConfiguration_Override = new List<Amazon.GlueDataBrew.Model.StatisticOverride>(this.DatasetStatisticsConfiguration_Override);
            }
            if (this.EntityDetectorConfiguration_AllowedStatistic != null)
            {
                context.EntityDetectorConfiguration_AllowedStatistic = new List<Amazon.GlueDataBrew.Model.AllowedStatistics>(this.EntityDetectorConfiguration_AllowedStatistic);
            }
            if (this.EntityDetectorConfiguration_EntityType != null)
            {
                context.EntityDetectorConfiguration_EntityType = new List<System.String>(this.EntityDetectorConfiguration_EntityType);
            }
            if (this.Configuration_ProfileColumn != null)
            {
                context.Configuration_ProfileColumn = new List<Amazon.GlueDataBrew.Model.ColumnSelector>(this.Configuration_ProfileColumn);
            }
            context.EncryptionKeyArn = this.EncryptionKeyArn;
            context.EncryptionMode = this.EncryptionMode;
            context.JobSample_Mode = this.JobSample_Mode;
            context.JobSample_Size = this.JobSample_Size;
            context.LogSubscription = this.LogSubscription;
            context.MaxCapacity = this.MaxCapacity;
            context.MaxRetry = this.MaxRetry;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputLocation_Bucket = this.OutputLocation_Bucket;
            #if MODULAR
            if (this.OutputLocation_Bucket == null && ParameterWasBound(nameof(this.OutputLocation_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputLocation_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutputLocation_BucketOwner = this.OutputLocation_BucketOwner;
            context.OutputLocation_Key = this.OutputLocation_Key;
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Timeout = this.Timeout;
            if (this.ValidationConfiguration != null)
            {
                context.ValidationConfiguration = new List<Amazon.GlueDataBrew.Model.ValidationConfiguration>(this.ValidationConfiguration);
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
            var request = new Amazon.GlueDataBrew.Model.UpdateProfileJobRequest();
            
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.GlueDataBrew.Model.ProfileConfiguration();
            List<Amazon.GlueDataBrew.Model.ColumnStatisticsConfiguration> requestConfiguration_configuration_ColumnStatisticsConfiguration = null;
            if (cmdletContext.Configuration_ColumnStatisticsConfiguration != null)
            {
                requestConfiguration_configuration_ColumnStatisticsConfiguration = cmdletContext.Configuration_ColumnStatisticsConfiguration;
            }
            if (requestConfiguration_configuration_ColumnStatisticsConfiguration != null)
            {
                request.Configuration.ColumnStatisticsConfigurations = requestConfiguration_configuration_ColumnStatisticsConfiguration;
                requestConfigurationIsNull = false;
            }
            List<Amazon.GlueDataBrew.Model.ColumnSelector> requestConfiguration_configuration_ProfileColumn = null;
            if (cmdletContext.Configuration_ProfileColumn != null)
            {
                requestConfiguration_configuration_ProfileColumn = cmdletContext.Configuration_ProfileColumn;
            }
            if (requestConfiguration_configuration_ProfileColumn != null)
            {
                request.Configuration.ProfileColumns = requestConfiguration_configuration_ProfileColumn;
                requestConfigurationIsNull = false;
            }
            Amazon.GlueDataBrew.Model.StatisticsConfiguration requestConfiguration_configuration_DatasetStatisticsConfiguration = null;
            
             // populate DatasetStatisticsConfiguration
            var requestConfiguration_configuration_DatasetStatisticsConfigurationIsNull = true;
            requestConfiguration_configuration_DatasetStatisticsConfiguration = new Amazon.GlueDataBrew.Model.StatisticsConfiguration();
            List<System.String> requestConfiguration_configuration_DatasetStatisticsConfiguration_datasetStatisticsConfiguration_IncludedStatistic = null;
            if (cmdletContext.DatasetStatisticsConfiguration_IncludedStatistic != null)
            {
                requestConfiguration_configuration_DatasetStatisticsConfiguration_datasetStatisticsConfiguration_IncludedStatistic = cmdletContext.DatasetStatisticsConfiguration_IncludedStatistic;
            }
            if (requestConfiguration_configuration_DatasetStatisticsConfiguration_datasetStatisticsConfiguration_IncludedStatistic != null)
            {
                requestConfiguration_configuration_DatasetStatisticsConfiguration.IncludedStatistics = requestConfiguration_configuration_DatasetStatisticsConfiguration_datasetStatisticsConfiguration_IncludedStatistic;
                requestConfiguration_configuration_DatasetStatisticsConfigurationIsNull = false;
            }
            List<Amazon.GlueDataBrew.Model.StatisticOverride> requestConfiguration_configuration_DatasetStatisticsConfiguration_datasetStatisticsConfiguration_Override = null;
            if (cmdletContext.DatasetStatisticsConfiguration_Override != null)
            {
                requestConfiguration_configuration_DatasetStatisticsConfiguration_datasetStatisticsConfiguration_Override = cmdletContext.DatasetStatisticsConfiguration_Override;
            }
            if (requestConfiguration_configuration_DatasetStatisticsConfiguration_datasetStatisticsConfiguration_Override != null)
            {
                requestConfiguration_configuration_DatasetStatisticsConfiguration.Overrides = requestConfiguration_configuration_DatasetStatisticsConfiguration_datasetStatisticsConfiguration_Override;
                requestConfiguration_configuration_DatasetStatisticsConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_DatasetStatisticsConfiguration should be set to null
            if (requestConfiguration_configuration_DatasetStatisticsConfigurationIsNull)
            {
                requestConfiguration_configuration_DatasetStatisticsConfiguration = null;
            }
            if (requestConfiguration_configuration_DatasetStatisticsConfiguration != null)
            {
                request.Configuration.DatasetStatisticsConfiguration = requestConfiguration_configuration_DatasetStatisticsConfiguration;
                requestConfigurationIsNull = false;
            }
            Amazon.GlueDataBrew.Model.EntityDetectorConfiguration requestConfiguration_configuration_EntityDetectorConfiguration = null;
            
             // populate EntityDetectorConfiguration
            var requestConfiguration_configuration_EntityDetectorConfigurationIsNull = true;
            requestConfiguration_configuration_EntityDetectorConfiguration = new Amazon.GlueDataBrew.Model.EntityDetectorConfiguration();
            List<Amazon.GlueDataBrew.Model.AllowedStatistics> requestConfiguration_configuration_EntityDetectorConfiguration_entityDetectorConfiguration_AllowedStatistic = null;
            if (cmdletContext.EntityDetectorConfiguration_AllowedStatistic != null)
            {
                requestConfiguration_configuration_EntityDetectorConfiguration_entityDetectorConfiguration_AllowedStatistic = cmdletContext.EntityDetectorConfiguration_AllowedStatistic;
            }
            if (requestConfiguration_configuration_EntityDetectorConfiguration_entityDetectorConfiguration_AllowedStatistic != null)
            {
                requestConfiguration_configuration_EntityDetectorConfiguration.AllowedStatistics = requestConfiguration_configuration_EntityDetectorConfiguration_entityDetectorConfiguration_AllowedStatistic;
                requestConfiguration_configuration_EntityDetectorConfigurationIsNull = false;
            }
            List<System.String> requestConfiguration_configuration_EntityDetectorConfiguration_entityDetectorConfiguration_EntityType = null;
            if (cmdletContext.EntityDetectorConfiguration_EntityType != null)
            {
                requestConfiguration_configuration_EntityDetectorConfiguration_entityDetectorConfiguration_EntityType = cmdletContext.EntityDetectorConfiguration_EntityType;
            }
            if (requestConfiguration_configuration_EntityDetectorConfiguration_entityDetectorConfiguration_EntityType != null)
            {
                requestConfiguration_configuration_EntityDetectorConfiguration.EntityTypes = requestConfiguration_configuration_EntityDetectorConfiguration_entityDetectorConfiguration_EntityType;
                requestConfiguration_configuration_EntityDetectorConfigurationIsNull = false;
            }
             // determine if requestConfiguration_configuration_EntityDetectorConfiguration should be set to null
            if (requestConfiguration_configuration_EntityDetectorConfigurationIsNull)
            {
                requestConfiguration_configuration_EntityDetectorConfiguration = null;
            }
            if (requestConfiguration_configuration_EntityDetectorConfiguration != null)
            {
                request.Configuration.EntityDetectorConfiguration = requestConfiguration_configuration_EntityDetectorConfiguration;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.EncryptionKeyArn != null)
            {
                request.EncryptionKeyArn = cmdletContext.EncryptionKeyArn;
            }
            if (cmdletContext.EncryptionMode != null)
            {
                request.EncryptionMode = cmdletContext.EncryptionMode;
            }
            
             // populate JobSample
            var requestJobSampleIsNull = true;
            request.JobSample = new Amazon.GlueDataBrew.Model.JobSample();
            Amazon.GlueDataBrew.SampleMode requestJobSample_jobSample_Mode = null;
            if (cmdletContext.JobSample_Mode != null)
            {
                requestJobSample_jobSample_Mode = cmdletContext.JobSample_Mode;
            }
            if (requestJobSample_jobSample_Mode != null)
            {
                request.JobSample.Mode = requestJobSample_jobSample_Mode;
                requestJobSampleIsNull = false;
            }
            System.Int64? requestJobSample_jobSample_Size = null;
            if (cmdletContext.JobSample_Size != null)
            {
                requestJobSample_jobSample_Size = cmdletContext.JobSample_Size.Value;
            }
            if (requestJobSample_jobSample_Size != null)
            {
                request.JobSample.Size = requestJobSample_jobSample_Size.Value;
                requestJobSampleIsNull = false;
            }
             // determine if request.JobSample should be set to null
            if (requestJobSampleIsNull)
            {
                request.JobSample = null;
            }
            if (cmdletContext.LogSubscription != null)
            {
                request.LogSubscription = cmdletContext.LogSubscription;
            }
            if (cmdletContext.MaxCapacity != null)
            {
                request.MaxCapacity = cmdletContext.MaxCapacity.Value;
            }
            if (cmdletContext.MaxRetry != null)
            {
                request.MaxRetries = cmdletContext.MaxRetry.Value;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate OutputLocation
            var requestOutputLocationIsNull = true;
            request.OutputLocation = new Amazon.GlueDataBrew.Model.S3Location();
            System.String requestOutputLocation_outputLocation_Bucket = null;
            if (cmdletContext.OutputLocation_Bucket != null)
            {
                requestOutputLocation_outputLocation_Bucket = cmdletContext.OutputLocation_Bucket;
            }
            if (requestOutputLocation_outputLocation_Bucket != null)
            {
                request.OutputLocation.Bucket = requestOutputLocation_outputLocation_Bucket;
                requestOutputLocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_BucketOwner = null;
            if (cmdletContext.OutputLocation_BucketOwner != null)
            {
                requestOutputLocation_outputLocation_BucketOwner = cmdletContext.OutputLocation_BucketOwner;
            }
            if (requestOutputLocation_outputLocation_BucketOwner != null)
            {
                request.OutputLocation.BucketOwner = requestOutputLocation_outputLocation_BucketOwner;
                requestOutputLocationIsNull = false;
            }
            System.String requestOutputLocation_outputLocation_Key = null;
            if (cmdletContext.OutputLocation_Key != null)
            {
                requestOutputLocation_outputLocation_Key = cmdletContext.OutputLocation_Key;
            }
            if (requestOutputLocation_outputLocation_Key != null)
            {
                request.OutputLocation.Key = requestOutputLocation_outputLocation_Key;
                requestOutputLocationIsNull = false;
            }
             // determine if request.OutputLocation should be set to null
            if (requestOutputLocationIsNull)
            {
                request.OutputLocation = null;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.Timeout != null)
            {
                request.Timeout = cmdletContext.Timeout.Value;
            }
            if (cmdletContext.ValidationConfiguration != null)
            {
                request.ValidationConfigurations = cmdletContext.ValidationConfiguration;
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
        
        private Amazon.GlueDataBrew.Model.UpdateProfileJobResponse CallAWSServiceOperation(IAmazonGlueDataBrew client, Amazon.GlueDataBrew.Model.UpdateProfileJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Glue DataBrew", "UpdateProfileJob");
            try
            {
                #if DESKTOP
                return client.UpdateProfileJob(request);
                #elif CORECLR
                return client.UpdateProfileJobAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.GlueDataBrew.Model.ColumnStatisticsConfiguration> Configuration_ColumnStatisticsConfiguration { get; set; }
            public List<System.String> DatasetStatisticsConfiguration_IncludedStatistic { get; set; }
            public List<Amazon.GlueDataBrew.Model.StatisticOverride> DatasetStatisticsConfiguration_Override { get; set; }
            public List<Amazon.GlueDataBrew.Model.AllowedStatistics> EntityDetectorConfiguration_AllowedStatistic { get; set; }
            public List<System.String> EntityDetectorConfiguration_EntityType { get; set; }
            public List<Amazon.GlueDataBrew.Model.ColumnSelector> Configuration_ProfileColumn { get; set; }
            public System.String EncryptionKeyArn { get; set; }
            public Amazon.GlueDataBrew.EncryptionMode EncryptionMode { get; set; }
            public Amazon.GlueDataBrew.SampleMode JobSample_Mode { get; set; }
            public System.Int64? JobSample_Size { get; set; }
            public Amazon.GlueDataBrew.LogSubscription LogSubscription { get; set; }
            public System.Int32? MaxCapacity { get; set; }
            public System.Int32? MaxRetry { get; set; }
            public System.String Name { get; set; }
            public System.String OutputLocation_Bucket { get; set; }
            public System.String OutputLocation_BucketOwner { get; set; }
            public System.String OutputLocation_Key { get; set; }
            public System.String RoleArn { get; set; }
            public System.Int32? Timeout { get; set; }
            public List<Amazon.GlueDataBrew.Model.ValidationConfiguration> ValidationConfiguration { get; set; }
            public System.Func<Amazon.GlueDataBrew.Model.UpdateProfileJobResponse, UpdateGDBProfileJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Name;
        }
        
    }
}
