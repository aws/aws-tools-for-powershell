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
using Amazon.Synthetics;
using Amazon.Synthetics.Model;

namespace Amazon.PowerShell.Cmdlets.CWSYN
{
    /// <summary>
    /// Creates a canary. Canaries are scripts that monitor your endpoints and APIs from the
    /// outside-in. Canaries help you check the availability and latency of your web services
    /// and troubleshoot anomalies by investigating load time data, screenshots of the UI,
    /// logs, and metrics. You can set up a canary to run continuously or just once. 
    /// 
    ///  
    /// <para>
    /// Do not use <code>CreateCanary</code> to modify an existing canary. Use <a href="https://docs.aws.amazon.com/AmazonSynthetics/latest/APIReference/API_UpdateCanary.html">UpdateCanary</a>
    /// instead.
    /// </para><para>
    /// To create canaries, you must have the <code>CloudWatchSyntheticsFullAccess</code>
    /// policy. If you are creating a new IAM role for the canary, you also need the the <code>iam:CreateRole</code>,
    /// <code>iam:CreatePolicy</code> and <code>iam:AttachRolePolicy</code> permissions. For
    /// more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch_Synthetics_Canaries_Roles">Necessary
    /// Roles and Permissions</a>.
    /// </para><para>
    /// Do not include secrets or proprietary information in your canary names. The canary
    /// name makes up part of the Amazon Resource Name (ARN) for the canary, and the ARN is
    /// included in outbound calls over the internet. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/servicelens_canaries_security.html">Security
    /// Considerations for Synthetics Canaries</a>.
    /// </para>
    /// </summary>
    [Cmdlet("New", "CWSYNCanary", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Synthetics.Model.Canary")]
    [AWSCmdlet("Calls the Amazon CloudWatch Synthetics CreateCanary API operation.", Operation = new[] {"CreateCanary"}, SelectReturnType = typeof(Amazon.Synthetics.Model.CreateCanaryResponse))]
    [AWSCmdletOutput("Amazon.Synthetics.Model.Canary or Amazon.Synthetics.Model.CreateCanaryResponse",
        "This cmdlet returns an Amazon.Synthetics.Model.Canary object.",
        "The service call response (type Amazon.Synthetics.Model.CreateCanaryResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCWSYNCanaryCmdlet : AmazonSyntheticsClientCmdlet, IExecutor
    {
        
        #region Parameter RunConfig_ActiveTracing
        /// <summary>
        /// <para>
        /// <para>Specifies whether this canary is to use active AWS X-Ray tracing when it runs. Active
        /// tracing enables this canary run to be displayed in the ServiceLens and X-Ray service
        /// maps even if the canary does not hit an endpoint that has X-ray tracing enabled. Using
        /// X-Ray tracing incurs charges. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch_Synthetics_Canaries_tracing.html">
        /// Canaries and X-Ray tracing</a>.</para><para>You can enable active tracing only for canaries that use version <code>syn-nodejs-2.0</code>
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
        /// this canary. Artifacts include the log file, screenshots, and HAR files.</para>
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
        public System.String ArtifactS3Location { get; set; }
        #endregion
        
        #region Parameter Schedule_DurationInSecond
        /// <summary>
        /// <para>
        /// <para>How long, in seconds, for the canary to continue making regular runs according to
        /// the schedule in the <code>Expression</code> value. If you specify 0, the canary continues
        /// making runs until you stop it. If you omit this field, the default of 0 is used.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_DurationInSeconds")]
        public System.Int64? Schedule_DurationInSecond { get; set; }
        #endregion
        
        #region Parameter ExecutionRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM role to be used to run the canary. This role must already exist,
        /// and must include <code>lambda.amazonaws.com</code> as a principal in the trust policy.
        /// The role must also have the following permissions:</para><ul><li><para><code>s3:PutObject</code></para></li><li><para><code>s3:GetBucketLocation</code></para></li><li><para><code>s3:ListAllMyBuckets</code></para></li><li><para><code>cloudwatch:PutMetricData</code></para></li><li><para><code>logs:CreateLogGroup</code></para></li><li><para><code>logs:CreateLogStream</code></para></li><li><para><code>logs:PutLogEvents</code></para></li></ul>
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
        public System.String ExecutionRoleArn { get; set; }
        #endregion
        
        #region Parameter Schedule_Expression
        /// <summary>
        /// <para>
        /// <para>A rate expression that defines how often the canary is to run. The syntax is <code>rate(<i>number
        /// unit</i>)</code>. <i>unit</i> can be <code>minute</code>, <code>minutes</code>, or
        /// <code>hour</code>. </para><para>For example, <code>rate(1 minute)</code> runs the canary once a minute, <code>rate(10
        /// minutes)</code> runs it once every 10 minutes, and <code>rate(1 hour)</code> runs
        /// it once every hour. You can specify a frequency between <code>rate(1 minute)</code>
        /// and <code>rate(1 hour)</code>.</para><para>Specifying <code>rate(0 minute)</code> or <code>rate(0 hour)</code> is a special value
        /// that causes the canary to run only once when it is started.</para>
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
        public System.String Schedule_Expression { get; set; }
        #endregion
        
        #region Parameter FailureRetentionPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The number of days to retain data about failed runs of this canary. If you omit this
        /// field, the default of 31 days is used. The valid range is 1 to 455 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FailureRetentionPeriodInDays")]
        public System.Int32? FailureRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter Code_Handler
        /// <summary>
        /// <para>
        /// <para>The entry point to use for the source code when running the canary. This value must
        /// end with the string <code>.handler</code>.</para>
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
        public System.String Code_Handler { get; set; }
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
        /// <para>The name for this canary. Be sure to give it a descriptive name that distinguishes
        /// it from other canaries in your account.</para><para>Do not include secrets or proprietary information in your canary names. The canary
        /// name makes up part of the canary ARN, and the ARN is included in outbound calls over
        /// the internet. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/servicelens_canaries_security.html">Security
        /// Considerations for Synthetics Canaries</a>.</para>
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
        
        #region Parameter RuntimeVersion
        /// <summary>
        /// <para>
        /// <para>Specifies the runtime version to use for the canary. Currently, the only valid values
        /// are <code>syn-nodejs-2.0</code>, <code>syn-nodejs-2.0-beta</code>, and <code>syn-1.0</code>.
        /// For more information about runtime versions, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/monitoring/CloudWatch_Synthetics_Canaries_Library.html">
        /// Canary Runtime Versions</a>.</para>
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
        public System.String RuntimeVersion { get; set; }
        #endregion
        
        #region Parameter Code_S3Bucket
        /// <summary>
        /// <para>
        /// <para>If your canary script is located in S3, specify the full bucket name here. The bucket
        /// must already exist. Specify the full bucket name, including <code>s3://</code> as
        /// the start of the bucket name.</para>
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
        /// <para>The number of days to retain data about successful runs of this canary. If you omit
        /// this field, the default of 31 days is used. The valid range is 1 to 455 days.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SuccessRetentionPeriodInDays")]
        public System.Int32? SuccessRetentionPeriodInDay { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>A list of key-value pairs to associate with the canary. You can associate as many
        /// as 50 tags with a canary.</para><para>Tags can help you organize and categorize your resources. You can also use them to
        /// scope user permissions, by granting a user permission to access or change only the
        /// resources that have certain tag values.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
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
        /// S3 location, the value of this parameter is the .zip file that contains the script.
        /// It can be up to 5 MB.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] Code_ZipFile { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Canary'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Synthetics.Model.CreateCanaryResponse).
        /// Specifying the name of a property of type Amazon.Synthetics.Model.CreateCanaryResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Canary";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CWSYNCanary (CreateCanary)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Synthetics.Model.CreateCanaryResponse, NewCWSYNCanaryCmdlet>(Select) ??
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
            context.ArtifactS3Location = this.ArtifactS3Location;
            #if MODULAR
            if (this.ArtifactS3Location == null && ParameterWasBound(nameof(this.ArtifactS3Location)))
            {
                WriteWarning("You are passing $null as a value for parameter ArtifactS3Location which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Code_Handler = this.Code_Handler;
            #if MODULAR
            if (this.Code_Handler == null && ParameterWasBound(nameof(this.Code_Handler)))
            {
                WriteWarning("You are passing $null as a value for parameter Code_Handler which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Code_S3Bucket = this.Code_S3Bucket;
            context.Code_S3Key = this.Code_S3Key;
            context.Code_S3Version = this.Code_S3Version;
            context.Code_ZipFile = this.Code_ZipFile;
            context.ExecutionRoleArn = this.ExecutionRoleArn;
            #if MODULAR
            if (this.ExecutionRoleArn == null && ParameterWasBound(nameof(this.ExecutionRoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ExecutionRoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.FailureRetentionPeriodInDay = this.FailureRetentionPeriodInDay;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RunConfig_ActiveTracing = this.RunConfig_ActiveTracing;
            context.RunConfig_MemoryInMB = this.RunConfig_MemoryInMB;
            context.RunConfig_TimeoutInSecond = this.RunConfig_TimeoutInSecond;
            context.RuntimeVersion = this.RuntimeVersion;
            #if MODULAR
            if (this.RuntimeVersion == null && ParameterWasBound(nameof(this.RuntimeVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter RuntimeVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Schedule_DurationInSecond = this.Schedule_DurationInSecond;
            context.Schedule_Expression = this.Schedule_Expression;
            #if MODULAR
            if (this.Schedule_Expression == null && ParameterWasBound(nameof(this.Schedule_Expression)))
            {
                WriteWarning("You are passing $null as a value for parameter Schedule_Expression which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.SuccessRetentionPeriodInDay = this.SuccessRetentionPeriodInDay;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
            }
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
                var request = new Amazon.Synthetics.Model.CreateCanaryRequest();
                
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
                if (cmdletContext.Tag != null)
                {
                    request.Tags = cmdletContext.Tag;
                }
                
                 // populate VpcConfig
                var requestVpcConfigIsNull = true;
                request.VpcConfig = new Amazon.Synthetics.Model.VpcConfigInput();
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
        
        private Amazon.Synthetics.Model.CreateCanaryResponse CallAWSServiceOperation(IAmazonSynthetics client, Amazon.Synthetics.Model.CreateCanaryRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon CloudWatch Synthetics", "CreateCanary");
            try
            {
                #if DESKTOP
                return client.CreateCanary(request);
                #elif CORECLR
                return client.CreateCanaryAsync(request).GetAwaiter().GetResult();
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
            public System.String ArtifactS3Location { get; set; }
            public System.String Code_Handler { get; set; }
            public System.String Code_S3Bucket { get; set; }
            public System.String Code_S3Key { get; set; }
            public System.String Code_S3Version { get; set; }
            public byte[] Code_ZipFile { get; set; }
            public System.String ExecutionRoleArn { get; set; }
            public System.Int32? FailureRetentionPeriodInDay { get; set; }
            public System.String Name { get; set; }
            public System.Boolean? RunConfig_ActiveTracing { get; set; }
            public System.Int32? RunConfig_MemoryInMB { get; set; }
            public System.Int32? RunConfig_TimeoutInSecond { get; set; }
            public System.String RuntimeVersion { get; set; }
            public System.Int64? Schedule_DurationInSecond { get; set; }
            public System.String Schedule_Expression { get; set; }
            public System.Int32? SuccessRetentionPeriodInDay { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_SubnetId { get; set; }
            public System.Func<Amazon.Synthetics.Model.CreateCanaryResponse, NewCWSYNCanaryCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Canary;
        }
        
    }
}
