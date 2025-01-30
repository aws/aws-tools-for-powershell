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
using Amazon.Synthetics;
using Amazon.Synthetics.Model;

namespace Amazon.PowerShell.Cmdlets.CWSYN
{
    /// <summary>
    /// Updates the configuration of a canary that has already been created.
    /// 
    ///  
    /// <para>
    /// You can't use this operation to update the tags of an existing canary. To change the
    /// tags of an existing canary, use <a href="https://docs.aws.amazon.com/AmazonSynthetics/latest/APIReference/API_TagResource.html">TagResource</a>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "CWSYNCanary", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("None")]
    [AWSCmdlet("Calls the Amazon CloudWatch Synthetics UpdateCanary API operation.", Operation = new[] {"UpdateCanary"}, SelectReturnType = typeof(Amazon.Synthetics.Model.UpdateCanaryResponse))]
    [AWSCmdletOutput("None or Amazon.Synthetics.Model.UpdateCanaryResponse",
        "This cmdlet does not generate any output." +
        "The service response (type Amazon.Synthetics.Model.UpdateCanaryResponse) be returned by specifying '-Select *'."
    )]
    public partial class UpdateCWSYNCanaryCmdlet : AmazonSyntheticsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RunConfig_ActiveTracing
        /// <summary>
        /// <para>
        /// <para>Specifies whether this canary is to use active X-Ray tracing when it runs. Active
        /// tracing enables this canary run to be displayed in the ServiceLens and X-Ray service
        /// maps even if the canary does not hit an endpoint that has X-Ray tracing enabled. Using
        /// X-Ray tracing incurs charges. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch_Synthetics_Canaries_tracing.html">
        /// Canaries and X-Ray tracing</a>.</para><para>You can enable active tracing only for canaries that use version <c>syn-nodejs-2.0</c>
        /// or later for their canary runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? RunConfig_ActiveTracing { get; set; }
        #endregion
        
        #region Parameter ArtifactS3Location
        /// <summary>
        /// <para>
        /// <para>The location in Amazon S3 where Synthetics stores artifacts from the test runs of
        /// this canary. Artifacts include the log file, screenshots, and HAR files. The name
        /// of the S3 bucket can't include a period (.).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArtifactS3Location { get; set; }
        #endregion
        
        #region Parameter VisualReference_BaseCanaryRunId
        /// <summary>
        /// <para>
        /// <para>Specifies which canary run to use the screenshots from as the baseline for future
        /// visual monitoring with this canary. Valid values are <c>nextrun</c> to use the screenshots
        /// from the next run after this update is made, <c>lastrun</c> to use the screenshots
        /// from the most recent run before this update was made, or the value of <c>Id</c> in
        /// the <a href="https://docs.aws.amazon.com/AmazonSynthetics/latest/APIReference/API_CanaryRun.html">
        /// CanaryRun</a> from a run of this a canary in the past 31 days. If you specify the
        /// <c>Id</c> of a canary run older than 31 days, the operation returns a 400 validation
        /// exception error..</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VisualReference_BaseCanaryRunId { get; set; }
        #endregion
        
        #region Parameter VisualReference_BaseScreenshot
        /// <summary>
        /// <para>
        /// <para>An array of screenshots that will be used as the baseline for visual monitoring in
        /// future runs of this canary. If there is a screenshot that you don't want to be used
        /// for visual monitoring, remove it from this array.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VisualReference_BaseScreenshots")]
        public Amazon.Synthetics.Model.BaseScreenshot[] VisualReference_BaseScreenshot { get; set; }
        #endregion
        
        #region Parameter Schedule_DurationInSecond
        /// <summary>
        /// <para>
        /// <para>How long, in seconds, for the canary to continue making regular runs according to
        /// the schedule in the <c>Expression</c> value. If you specify 0, the canary continues
        /// making runs until you stop it. If you omit this field, the default of 0 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_DurationInSeconds")]
        public System.Int64? Schedule_DurationInSecond { get; set; }
        #endregion
        
        #region Parameter S3Encryption_EncryptionMode
        /// <summary>
        /// <para>
        /// <para> The encryption method to use for artifacts created by this canary. Specify <c>SSE_S3</c>
        /// to use server-side encryption (SSE) with an Amazon S3-managed key. Specify <c>SSE-KMS</c>
        /// to use server-side encryption with a customer-managed KMS key.</para><para>If you omit this parameter, an Amazon Web Services-managed KMS key is used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ArtifactConfig_S3Encryption_EncryptionMode")]
        [AWSConstantClassSource("Amazon.Synthetics.EncryptionMode")]
        public Amazon.Synthetics.EncryptionMode S3Encryption_EncryptionMode { get; set; }
        #endregion
        
        #region Parameter RunConfig_EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>Specifies the keys and values to use for any environment variables used in the canary
        /// script. Use the following format:</para><para>{ "key1" : "value1", "key2" : "value2", ...}</para><para>Keys must start with a letter and be at least two characters. The total size of your
        /// environment variables cannot exceed 4 KB. You can't specify any Lambda reserved environment
        /// variables as the keys for your environment variables. For more information about reserved
        /// keys, see <a href="https://docs.aws.amazon.com/lambda/latest/dg/configuration-envvars.html#configuration-envvars-runtime">
        /// Runtime environment variables</a>.</para><important><para>The environment variables keys and values are not encrypted. Do not store sensitive
        /// information in this field.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RunConfig_EnvironmentVariables")]
        public System.Collections.Hashtable RunConfig_EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role to be used to run the canary. This role must already exist,
        /// and must include <c>lambda.amazonaws.com</c> as a principal in the trust policy. The
        /// role must also have the following permissions:</para><ul><li><para><c>s3:PutObject</c></para></li><li><para><c>s3:GetBucketLocation</c></para></li><li><para><c>s3:ListAllMyBuckets</c></para></li><li><para><c>cloudwatch:PutMetricData</c></para></li><li><para><c>logs:CreateLogGroup</c></para></li><li><para><c>logs:CreateLogStream</c></para></li><li><para><c>logs:CreateLogStream</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Schedule_Expression
        /// <summary>
        /// <para>
        /// <para>A <c>rate</c> expression or a <c>cron</c> expression that defines how often the canary
        /// is to run.</para><para>For a rate expression, The syntax is <c>rate(<i>number unit</i>)</c>. <i>unit</i>
        /// can be <c>minute</c>, <c>minutes</c>, or <c>hour</c>. </para><para>For example, <c>rate(1 minute)</c> runs the canary once a minute, <c>rate(10 minutes)</c>
        /// runs it once every 10 minutes, and <c>rate(1 hour)</c> runs it once every hour. You
        /// can specify a frequency between <c>rate(1 minute)</c> and <c>rate(1 hour)</c>.</para><para>Specifying <c>rate(0 minute)</c> or <c>rate(0 hour)</c> is a special value that causes
        /// the canary to run only once when it is started.</para><para>Use <c>cron(<i>expression</i>)</c> to specify a cron expression. You can't schedule
        /// a canary to wait for more than a year before running. For information about the syntax
        /// for cron expressions, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch_Synthetics_Canaries_cron.html">
        /// Scheduling canary runs using cron</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Expression { get; set; }
        #endregion
        
        #region Parameter FailureRetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The number of days to retain data about failed runs of this canary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FailureRetentionPeriodInDays")]
        public System.Int32? FailureRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter Code_Handler
        /// <summary>
        /// <para>
        /// <para>The entry point to use for the source code when running the canary. For canaries that
        /// use the <c>syn-python-selenium-1.0</c> runtime or a <c>syn-nodejs.puppeteer</c> runtime
        /// earlier than <c>syn-nodejs.puppeteer-3.4</c>, the handler must be specified as <c><i>fileName</i>.handler</c>. For <c>syn-python-selenium-1.1</c>, <c>syn-nodejs.puppeteer-3.4</c>,
        /// and later runtimes, the handler can be specified as <c><i>fileName</i>.<i>functionName</i></c>, or you can specify a folder where canary scripts reside as <c><i>folder</i>/<i>fileName</i>.<i>functionName</i></c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_Handler { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Ipv6AllowedForDualStack
        /// <summary>
        /// <para>
        /// <para>Set this to <c>true</c> to allow outbound IPv6 traffic on VPC canaries that are connected
        /// to dual-stack subnets. The default is <c>false</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? VpcConfig_Ipv6AllowedForDualStack { get; set; }
        #endregion
        
        #region Parameter S3Encryption_KmsKeyArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the customer-managed KMS key to use, if you specify <c>SSE-KMS</c> for
        /// <c>EncryptionMode</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ArtifactConfig_S3Encryption_KmsKeyArn")]
        public System.String S3Encryption_KmsKeyArn { get; set; }
        #endregion
        
        #region Parameter RunConfig_MemoryInMB
        /// <summary>
        /// <para>
        /// <para>The maximum amount of memory available to the canary while it is running, in MB. This
        /// value must be a multiple of 64.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? RunConfig_MemoryInMB { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the canary that you want to update. To find the names of your canaries,
        /// use <a href="https://docs.aws.amazon.com/AmazonSynthetics/latest/APIReference/API_DescribeCanaries.html">DescribeCanaries</a>.</para><para>You cannot change the name of a canary that has already been created.</para>
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
        
        #region Parameter ProvisionedResourceCleanup
        /// <summary>
        /// <para>
        /// <para>Specifies whether to also delete the Lambda functions and layers used by this canary
        /// when the canary is deleted.</para><para>If the value of this parameter is <c>OFF</c>, then the value of the <c>DeleteLambda</c>
        /// parameter of the <a href="https://docs.aws.amazon.com/AmazonSynthetics/latest/APIReference/API_DeleteCanary.html">DeleteCanary</a>
        /// operation determines whether the Lambda functions and layers will be deleted.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Synthetics.ProvisionedResourceCleanupSetting")]
        public Amazon.Synthetics.ProvisionedResourceCleanupSetting ProvisionedResourceCleanup { get; set; }
        #endregion
        
        #region Parameter RuntimeVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the runtime version to use for the canary. For a list of valid runtime versions
        /// and for more information about runtime versions, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch_Synthetics_Canaries_Library.html">
        /// Canary Runtime Versions</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RuntimeVersion { get; set; }
        #endregion
        
        #region Parameter Code_S3Bucket
        /// <summary>
        /// <para>
        /// <para>If your canary script is located in S3, specify the bucket name here. Do not include
        /// <c>s3://</c> as the start of the bucket name.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3Bucket { get; set; }
        #endregion
        
        #region Parameter Code_S3Key
        /// <summary>
        /// <para>
        /// <para>The S3 key of your script. For more information, see <a href="https://docs.aws.amazon.com/AmazonS3/latest/dev/UsingObjects.html">Working
        /// with Amazon S3 Objects</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3Key { get; set; }
        #endregion
        
        #region Parameter Code_S3Version
        /// <summary>
        /// <para>
        /// <para>The S3 version ID of your script.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Code_S3Version { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups for this canary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SubnetId
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets where this canary is to run.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SubnetIds")]
        public System.String[] VpcConfig_SubnetId { get; set; }
        #endregion
        
        #region Parameter SuccessRetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The number of days to retain data about successful runs of this canary.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuccessRetentionPeriodInDays")]
        public System.Int32? SuccessRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter RunConfig_TimeoutInSecond
        /// <summary>
        /// <para>
        /// <para>How long the canary is allowed to run before it must stop. You can't set this time
        /// to be longer than the frequency of the runs of this canary.</para><para>If you omit this field, the frequency of the canary is used as this value, up to a
        /// maximum of 14 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RunConfig_TimeoutInSeconds")]
        public System.Int32? RunConfig_TimeoutInSecond { get; set; }
        #endregion
        
        #region Parameter Code_ZipFile
        /// <summary>
        /// <para>
        /// <para>If you input your canary script directly into the canary instead of referring to an
        /// S3 location, the value of this parameter is the base64-encoded contents of the .zip
        /// file that contains the script. It must be smaller than 225 Kb.</para><para>For large canary scripts, we recommend that you use an S3 location instead of inputting
        /// it directly with this parameter.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Code_ZipFile { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The cmdlet doesn't have a return value by default.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Synthetics.Model.UpdateCanaryResponse).
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CWSYNCanary (UpdateCanary)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Synthetics.Model.UpdateCanaryResponse, UpdateCWSYNCanaryCmdlet>(Select) ??
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
            context.S3Encryption_EncryptionMode = this.S3Encryption_EncryptionMode;
            context.S3Encryption_KmsKeyArn = this.S3Encryption_KmsKeyArn;
            context.ArtifactS3Location = this.ArtifactS3Location;
            context.Code_Handler = this.Code_Handler;
            context.Code_S3Bucket = this.Code_S3Bucket;
            context.Code_S3Key = this.Code_S3Key;
            context.Code_S3Version = this.Code_S3Version;
            context.Code_ZipFile = this.Code_ZipFile;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            context.FailureRetentionPeriodInDay = this.FailureRetentionPeriodInDay;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ProvisionedResourceCleanup = this.ProvisionedResourceCleanup;
            context.RunConfig_ActiveTracing = this.RunConfig_ActiveTracing;
            if (this.RunConfig_EnvironmentVariable != null)
            {
                context.RunConfig_EnvironmentVariable = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.RunConfig_EnvironmentVariable.Keys)
                {
                    context.RunConfig_EnvironmentVariable.Add((String)hashKey, (System.String)(this.RunConfig_EnvironmentVariable[hashKey]));
                }
            }
            context.RunConfig_MemoryInMB = this.RunConfig_MemoryInMB;
            context.RunConfig_TimeoutInSecond = this.RunConfig_TimeoutInSecond;
            context.RuntimeVersion = this.RuntimeVersion;
            context.Schedule_DurationInSecond = this.Schedule_DurationInSecond;
            context.Schedule_Expression = this.Schedule_Expression;
            context.SuccessRetentionPeriodInDay = this.SuccessRetentionPeriodInDay;
            context.VisualReference_BaseCanaryRunId = this.VisualReference_BaseCanaryRunId;
            if (this.VisualReference_BaseScreenshot != null)
            {
                context.VisualReference_BaseScreenshot = new List<Amazon.Synthetics.Model.BaseScreenshot>(this.VisualReference_BaseScreenshot);
            }
            context.VpcConfig_Ipv6AllowedForDualStack = this.VpcConfig_Ipv6AllowedForDualStack;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_SubnetId != null)
            {
                context.VpcConfig_SubnetId = new List<System.String>(this.VpcConfig_SubnetId);
            }
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            System.IO.MemoryStream _Code_ZipFileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Synthetics.Model.UpdateCanaryRequest();
                
                
                 // populate ArtifactConfig
                var requestArtifactConfigIsNull = true;
                request.ArtifactConfig = new Amazon.Synthetics.Model.ArtifactConfigInput();
                Amazon.Synthetics.Model.S3EncryptionConfig requestArtifactConfig_artifactConfig_S3Encryption = null;
                
                 // populate S3Encryption
                var requestArtifactConfig_artifactConfig_S3EncryptionIsNull = true;
                requestArtifactConfig_artifactConfig_S3Encryption = new Amazon.Synthetics.Model.S3EncryptionConfig();
                Amazon.Synthetics.EncryptionMode requestArtifactConfig_artifactConfig_S3Encryption_s3Encryption_EncryptionMode = null;
                if (cmdletContext.S3Encryption_EncryptionMode != null)
                {
                    requestArtifactConfig_artifactConfig_S3Encryption_s3Encryption_EncryptionMode = cmdletContext.S3Encryption_EncryptionMode;
                }
                if (requestArtifactConfig_artifactConfig_S3Encryption_s3Encryption_EncryptionMode != null)
                {
                    requestArtifactConfig_artifactConfig_S3Encryption.EncryptionMode = requestArtifactConfig_artifactConfig_S3Encryption_s3Encryption_EncryptionMode;
                    requestArtifactConfig_artifactConfig_S3EncryptionIsNull = false;
                }
                System.String requestArtifactConfig_artifactConfig_S3Encryption_s3Encryption_KmsKeyArn = null;
                if (cmdletContext.S3Encryption_KmsKeyArn != null)
                {
                    requestArtifactConfig_artifactConfig_S3Encryption_s3Encryption_KmsKeyArn = cmdletContext.S3Encryption_KmsKeyArn;
                }
                if (requestArtifactConfig_artifactConfig_S3Encryption_s3Encryption_KmsKeyArn != null)
                {
                    requestArtifactConfig_artifactConfig_S3Encryption.KmsKeyArn = requestArtifactConfig_artifactConfig_S3Encryption_s3Encryption_KmsKeyArn;
                    requestArtifactConfig_artifactConfig_S3EncryptionIsNull = false;
                }
                 // determine if requestArtifactConfig_artifactConfig_S3Encryption should be set to null
                if (requestArtifactConfig_artifactConfig_S3EncryptionIsNull)
                {
                    requestArtifactConfig_artifactConfig_S3Encryption = null;
                }
                if (requestArtifactConfig_artifactConfig_S3Encryption != null)
                {
                    request.ArtifactConfig.S3Encryption = requestArtifactConfig_artifactConfig_S3Encryption;
                    requestArtifactConfigIsNull = false;
                }
                 // determine if request.ArtifactConfig should be set to null
                if (requestArtifactConfigIsNull)
                {
                    request.ArtifactConfig = null;
                }
                if (cmdletContext.ArtifactS3Location != null)
                {
                    request.ArtifactS3Location = cmdletContext.ArtifactS3Location;
                }
                
                 // populate Code
                var requestCodeIsNull = true;
                request.Code = new Amazon.Synthetics.Model.CanaryCodeInput();
                System.String requestCode_code_Handler = null;
                if (cmdletContext.Code_Handler != null)
                {
                    requestCode_code_Handler = cmdletContext.Code_Handler;
                }
                if (requestCode_code_Handler != null)
                {
                    request.Code.Handler = requestCode_code_Handler;
                    requestCodeIsNull = false;
                }
                System.String requestCode_code_S3Bucket = null;
                if (cmdletContext.Code_S3Bucket != null)
                {
                    requestCode_code_S3Bucket = cmdletContext.Code_S3Bucket;
                }
                if (requestCode_code_S3Bucket != null)
                {
                    request.Code.S3Bucket = requestCode_code_S3Bucket;
                    requestCodeIsNull = false;
                }
                System.String requestCode_code_S3Key = null;
                if (cmdletContext.Code_S3Key != null)
                {
                    requestCode_code_S3Key = cmdletContext.Code_S3Key;
                }
                if (requestCode_code_S3Key != null)
                {
                    request.Code.S3Key = requestCode_code_S3Key;
                    requestCodeIsNull = false;
                }
                System.String requestCode_code_S3Version = null;
                if (cmdletContext.Code_S3Version != null)
                {
                    requestCode_code_S3Version = cmdletContext.Code_S3Version;
                }
                if (requestCode_code_S3Version != null)
                {
                    request.Code.S3Version = requestCode_code_S3Version;
                    requestCodeIsNull = false;
                }
                System.IO.MemoryStream requestCode_code_ZipFile = null;
                if (cmdletContext.Code_ZipFile != null)
                {
                    _Code_ZipFileStream = new System.IO.MemoryStream(cmdletContext.Code_ZipFile);
                    requestCode_code_ZipFile = _Code_ZipFileStream;
                }
                if (requestCode_code_ZipFile != null)
                {
                    request.Code.ZipFile = requestCode_code_ZipFile;
                    requestCodeIsNull = false;
                }
                 // determine if request.Code should be set to null
                if (requestCodeIsNull)
                {
                    request.Code = null;
                }
                if (cmdletContext.ExecutionRoleArn != null)
                {
                    request.ExecutionRoleArn = cmdletContext.ExecutionRoleArn;
                }
                if (cmdletContext.FailureRetentionPeriodInDay != null)
                {
                    request.FailureRetentionPeriodInDays = cmdletContext.FailureRetentionPeriodInDay.Value;
                }
                if (cmdletContext.Name != null)
                {
                    request.Name = cmdletContext.Name;
                }
                if (cmdletContext.ProvisionedResourceCleanup != null)
                {
                    request.ProvisionedResourceCleanup = cmdletContext.ProvisionedResourceCleanup;
                }
                
                 // populate RunConfig
                var requestRunConfigIsNull = true;
                request.RunConfig = new Amazon.Synthetics.Model.CanaryRunConfigInput();
                System.Boolean? requestRunConfig_runConfig_ActiveTracing = null;
                if (cmdletContext.RunConfig_ActiveTracing != null)
                {
                    requestRunConfig_runConfig_ActiveTracing = cmdletContext.RunConfig_ActiveTracing.Value;
                }
                if (requestRunConfig_runConfig_ActiveTracing != null)
                {
                    request.RunConfig.ActiveTracing = requestRunConfig_runConfig_ActiveTracing.Value;
                    requestRunConfigIsNull = false;
                }
                Dictionary<System.String, System.String> requestRunConfig_runConfig_EnvironmentVariable = null;
                if (cmdletContext.RunConfig_EnvironmentVariable != null)
                {
                    requestRunConfig_runConfig_EnvironmentVariable = cmdletContext.RunConfig_EnvironmentVariable;
                }
                if (requestRunConfig_runConfig_EnvironmentVariable != null)
                {
                    request.RunConfig.EnvironmentVariables = requestRunConfig_runConfig_EnvironmentVariable;
                    requestRunConfigIsNull = false;
                }
                System.Int32? requestRunConfig_runConfig_MemoryInMB = null;
                if (cmdletContext.RunConfig_MemoryInMB != null)
                {
                    requestRunConfig_runConfig_MemoryInMB = cmdletContext.RunConfig_MemoryInMB.Value;
                }
                if (requestRunConfig_runConfig_MemoryInMB != null)
                {
                    request.RunConfig.MemoryInMB = requestRunConfig_runConfig_MemoryInMB.Value;
                    requestRunConfigIsNull = false;
                }
                System.Int32? requestRunConfig_runConfig_TimeoutInSecond = null;
                if (cmdletContext.RunConfig_TimeoutInSecond != null)
                {
                    requestRunConfig_runConfig_TimeoutInSecond = cmdletContext.RunConfig_TimeoutInSecond.Value;
                }
                if (requestRunConfig_runConfig_TimeoutInSecond != null)
                {
                    request.RunConfig.TimeoutInSeconds = requestRunConfig_runConfig_TimeoutInSecond.Value;
                    requestRunConfigIsNull = false;
                }
                 // determine if request.RunConfig should be set to null
                if (requestRunConfigIsNull)
                {
                    request.RunConfig = null;
                }
                if (cmdletContext.RuntimeVersion != null)
                {
                    request.RuntimeVersion = cmdletContext.RuntimeVersion;
                }
                
                 // populate Schedule
                var requestScheduleIsNull = true;
                request.Schedule = new Amazon.Synthetics.Model.CanaryScheduleInput();
                System.Int64? requestSchedule_schedule_DurationInSecond = null;
                if (cmdletContext.Schedule_DurationInSecond != null)
                {
                    requestSchedule_schedule_DurationInSecond = cmdletContext.Schedule_DurationInSecond.Value;
                }
                if (requestSchedule_schedule_DurationInSecond != null)
                {
                    request.Schedule.DurationInSeconds = requestSchedule_schedule_DurationInSecond.Value;
                    requestScheduleIsNull = false;
                }
                System.String requestSchedule_schedule_Expression = null;
                if (cmdletContext.Schedule_Expression != null)
                {
                    requestSchedule_schedule_Expression = cmdletContext.Schedule_Expression;
                }
                if (requestSchedule_schedule_Expression != null)
                {
                    request.Schedule.Expression = requestSchedule_schedule_Expression;
                    requestScheduleIsNull = false;
                }
                 // determine if request.Schedule should be set to null
                if (requestScheduleIsNull)
                {
                    request.Schedule = null;
                }
                if (cmdletContext.SuccessRetentionPeriodInDay != null)
                {
                    request.SuccessRetentionPeriodInDays = cmdletContext.SuccessRetentionPeriodInDay.Value;
                }
                
                 // populate VisualReference
                var requestVisualReferenceIsNull = true;
                request.VisualReference = new Amazon.Synthetics.Model.VisualReferenceInput();
                System.String requestVisualReference_visualReference_BaseCanaryRunId = null;
                if (cmdletContext.VisualReference_BaseCanaryRunId != null)
                {
                    requestVisualReference_visualReference_BaseCanaryRunId = cmdletContext.VisualReference_BaseCanaryRunId;
                }
                if (requestVisualReference_visualReference_BaseCanaryRunId != null)
                {
                    request.VisualReference.BaseCanaryRunId = requestVisualReference_visualReference_BaseCanaryRunId;
                    requestVisualReferenceIsNull = false;
                }
                List<Amazon.Synthetics.Model.BaseScreenshot> requestVisualReference_visualReference_BaseScreenshot = null;
                if (cmdletContext.VisualReference_BaseScreenshot != null)
                {
                    requestVisualReference_visualReference_BaseScreenshot = cmdletContext.VisualReference_BaseScreenshot;
                }
                if (requestVisualReference_visualReference_BaseScreenshot != null)
                {
                    request.VisualReference.BaseScreenshots = requestVisualReference_visualReference_BaseScreenshot;
                    requestVisualReferenceIsNull = false;
                }
                 // determine if request.VisualReference should be set to null
                if (requestVisualReferenceIsNull)
                {
                    request.VisualReference = null;
                }
                
                 // populate VpcConfig
                var requestVpcConfigIsNull = true;
                request.VpcConfig = new Amazon.Synthetics.Model.VpcConfigInput();
                System.Boolean? requestVpcConfig_vpcConfig_Ipv6AllowedForDualStack = null;
                if (cmdletContext.VpcConfig_Ipv6AllowedForDualStack != null)
                {
                    requestVpcConfig_vpcConfig_Ipv6AllowedForDualStack = cmdletContext.VpcConfig_Ipv6AllowedForDualStack.Value;
                }
                if (requestVpcConfig_vpcConfig_Ipv6AllowedForDualStack != null)
                {
                    request.VpcConfig.Ipv6AllowedForDualStack = requestVpcConfig_vpcConfig_Ipv6AllowedForDualStack.Value;
                    requestVpcConfigIsNull = false;
                }
                List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
                if (cmdletContext.VpcConfig_SecurityGroupId != null)
                {
                    requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupId;
                }
                if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
                {
                    request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                    requestVpcConfigIsNull = false;
                }
                List<System.String> requestVpcConfig_vpcConfig_SubnetId = null;
                if (cmdletContext.VpcConfig_SubnetId != null)
                {
                    requestVpcConfig_vpcConfig_SubnetId = cmdletContext.VpcConfig_SubnetId;
                }
                if (requestVpcConfig_vpcConfig_SubnetId != null)
                {
                    request.VpcConfig.SubnetIds = requestVpcConfig_vpcConfig_SubnetId;
                    requestVpcConfigIsNull = false;
                }
                 // determine if request.VpcConfig should be set to null
                if (requestVpcConfigIsNull)
                {
                    request.VpcConfig = null;
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
            finally
            {
                if( _Code_ZipFileStream != null)
                {
                    _Code_ZipFileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Synthetics.Model.UpdateCanaryResponse CallAWSServiceOperation(IAmazonSynthetics client, Amazon.Synthetics.Model.UpdateCanaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Synthetics", "UpdateCanary");
            try
            {
                #if DESKTOP
                return client.UpdateCanary(request);
                #elif CORECLR
                return client.UpdateCanaryAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Synthetics.EncryptionMode S3Encryption_EncryptionMode { get; set; }
            public System.String S3Encryption_KmsKeyArn { get; set; }
            public System.String ArtifactS3Location { get; set; }
            public System.String Code_Handler { get; set; }
            public System.String Code_S3Bucket { get; set; }
            public System.String Code_S3Key { get; set; }
            public System.String Code_S3Version { get; set; }
            public byte[] Code_ZipFile { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Int32? FailureRetentionPeriodInDay { get; set; }
            public System.String Name { get; set; }
            public Amazon.Synthetics.ProvisionedResourceCleanupSetting ProvisionedResourceCleanup { get; set; }
            public System.Boolean? RunConfig_ActiveTracing { get; set; }
            public Dictionary<System.String, System.String> RunConfig_EnvironmentVariable { get; set; }
            public System.Int32? RunConfig_MemoryInMB { get; set; }
            public System.Int32? RunConfig_TimeoutInSecond { get; set; }
            public System.String RuntimeVersion { get; set; }
            public System.Int64? Schedule_DurationInSecond { get; set; }
            public System.String Schedule_Expression { get; set; }
            public System.Int32? SuccessRetentionPeriodInDay { get; set; }
            public System.String VisualReference_BaseCanaryRunId { get; set; }
            public List<Amazon.Synthetics.Model.BaseScreenshot> VisualReference_BaseScreenshot { get; set; }
            public System.Boolean? VpcConfig_Ipv6AllowedForDualStack { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.Synthetics.Model.UpdateCanaryResponse, UpdateCWSYNCanaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => null;
        }
        
    }
}
