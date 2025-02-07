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
using Amazon.LookoutforVision;
using Amazon.LookoutforVision.Model;

namespace Amazon.PowerShell.Cmdlets.LFV
{
    /// <summary>
    /// Starts an Amazon Lookout for Vision model packaging job. A model packaging job creates
    /// an AWS IoT Greengrass component for a Lookout for Vision model. You can use the component
    /// to deploy your model to an edge device managed by Greengrass. 
    /// 
    ///  
    /// <para>
    /// Use the <a>DescribeModelPackagingJob</a> API to determine the current status of the
    /// job. The model packaging job is complete if the value of <c>Status</c> is <c>SUCCEEDED</c>.
    /// </para><para>
    /// To deploy the component to the target device, use the component name and component
    /// version with the AWS IoT Greengrass <a href="https://docs.aws.amazon.com/greengrass/v2/APIReference/API_CreateDeployment.html">CreateDeployment</a>
    /// API.
    /// </para><para>
    /// This operation requires the following permissions:
    /// </para><ul><li><para><c>lookoutvision:StartModelPackagingJob</c></para></li><li><para><c>s3:PutObject</c></para></li><li><para><c>s3:GetBucketLocation</c></para></li><li><para><c>kms:GenerateDataKey</c></para></li><li><para><c>greengrass:CreateComponentVersion</c></para></li><li><para><c>greengrass:DescribeComponent</c></para></li><li><para>
    /// (Optional) <c>greengrass:TagResource</c>. Only required if you want to tag the component.
    /// </para></li></ul><para>
    /// For more information, see <i>Using your Amazon Lookout for Vision model on an edge
    /// device</i> in the Amazon Lookout for Vision Developer Guide. 
    /// </para>
    /// </summary>
    [Cmdlet("Start", "LFVModelPackagingJob", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon Lookout for Vision StartModelPackagingJob API operation.", Operation = new[] {"StartModelPackagingJob"}, SelectReturnType = typeof(Amazon.LookoutforVision.Model.StartModelPackagingJobResponse))]
    [AWSCmdletOutput("System.String or Amazon.LookoutforVision.Model.StartModelPackagingJobResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.LookoutforVision.Model.StartModelPackagingJobResponse) can be returned by specifying '-Select *'."
    )]
    public partial class StartLFVModelPackagingJobCmdlet : AmazonLookoutforVisionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter TargetPlatform_Accelerator
        /// <summary>
        /// <para>
        /// <para>The target accelerator for the model. Currently, Amazon Lookout for Vision only supports
        /// NVIDIA (Nvidia graphics processing unit) and CPU accelerators. If you specify NVIDIA
        /// as an accelerator, you must also specify the <c>gpu-code</c>, <c>trt-ver</c>, and
        /// <c>cuda-ver</c> compiler options. If you don't specify an accelerator, Lookout for
        /// Vision uses the CPU for compilation and we highly recommend that you use the <a>GreengrassConfiguration$CompilerOptions</a>
        /// field. For example, you can use the following compiler options for CPU: </para><ul><li><para><c>mcpu</c>: CPU micro-architecture. For example, <c>{'mcpu': 'skylake-avx512'}</c></para></li><li><para><c>mattr</c>: CPU flags. For example, <c>{'mattr': ['+neon', '+vfpv4']}</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_TargetPlatform_Accelerator")]
        [AWSConstantClassSource("Amazon.LookoutforVision.TargetPlatformAccelerator")]
        public Amazon.LookoutforVision.TargetPlatformAccelerator TargetPlatform_Accelerator { get; set; }
        #endregion
        
        #region Parameter TargetPlatform_Arch
        /// <summary>
        /// <para>
        /// <para>The target architecture for the model. The currently supported architectures are X86_64
        /// (64-bit version of the x86 instruction set) and ARM_64 (ARMv8 64-bit CPU). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_TargetPlatform_Arch")]
        [AWSConstantClassSource("Amazon.LookoutforVision.TargetPlatformArch")]
        public Amazon.LookoutforVision.TargetPlatformArch TargetPlatform_Arch { get; set; }
        #endregion
        
        #region Parameter S3OutputLocation_Bucket
        /// <summary>
        /// <para>
        /// <para>The S3 bucket that contains the training or model packaging job output. If you are
        /// training a model, the bucket must in your AWS account. If you use an S3 bucket for
        /// a model packaging job, the S3 bucket must be in the same AWS Region and AWS account
        /// in which you use AWS IoT Greengrass.</para>
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
        [Alias("Configuration_Greengrass_S3OutputLocation_Bucket")]
        public System.String S3OutputLocation_Bucket { get; set; }
        #endregion
        
        #region Parameter Greengrass_CompilerOption
        /// <summary>
        /// <para>
        /// <para>Additional compiler options for the Greengrass component. Currently, only NVIDIA Graphics
        /// Processing Units (GPU) and CPU accelerators are supported. If you specify <c>TargetDevice</c>,
        /// don't specify <c>CompilerOptions</c>.</para><para>For more information, see <i>Compiler options</i> in the Amazon Lookout for Vision
        /// Developer Guide. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_CompilerOptions")]
        public System.String Greengrass_CompilerOption { get; set; }
        #endregion
        
        #region Parameter Greengrass_ComponentDescription
        /// <summary>
        /// <para>
        /// <para> A description for the AWS IoT Greengrass component. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_ComponentDescription")]
        public System.String Greengrass_ComponentDescription { get; set; }
        #endregion
        
        #region Parameter Greengrass_ComponentName
        /// <summary>
        /// <para>
        /// <para> A name for the AWS IoT Greengrass component. </para>
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
        [Alias("Configuration_Greengrass_ComponentName")]
        public System.String Greengrass_ComponentName { get; set; }
        #endregion
        
        #region Parameter Greengrass_ComponentVersion
        /// <summary>
        /// <para>
        /// <para>A Version for the AWS IoT Greengrass component. If you don't provide a value, a default
        /// value of <c><i>Model Version</i>.0.0</c> is used. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_ComponentVersion")]
        public System.String Greengrass_ComponentVersion { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the model packaging job. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter JobName
        /// <summary>
        /// <para>
        /// <para>A name for the model packaging job. If you don't supply a value, the service creates
        /// a job name for you. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String JobName { get; set; }
        #endregion
        
        #region Parameter ModelVersion
        /// <summary>
        /// <para>
        /// <para> The version of the model within the project that you want to package. </para>
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
        public System.String ModelVersion { get; set; }
        #endregion
        
        #region Parameter TargetPlatform_Os
        /// <summary>
        /// <para>
        /// <para>The target operating system for the model. Linux is the only operating system that
        /// is currently supported. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_TargetPlatform_Os")]
        [AWSConstantClassSource("Amazon.LookoutforVision.TargetPlatformOs")]
        public Amazon.LookoutforVision.TargetPlatformOs TargetPlatform_Os { get; set; }
        #endregion
        
        #region Parameter S3OutputLocation_Prefix
        /// <summary>
        /// <para>
        /// <para>The path of the folder, within the S3 bucket, that contains the output.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_S3OutputLocation_Prefix")]
        public System.String S3OutputLocation_Prefix { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para> The name of the project which contains the version of the model that you want to
        /// package. </para>
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
        
        #region Parameter Greengrass_Tag
        /// <summary>
        /// <para>
        /// <para> A set of tags (key-value pairs) that you want to attach to the AWS IoT Greengrass
        /// component. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_Tags")]
        public Amazon.LookoutforVision.Model.Tag[] Greengrass_Tag { get; set; }
        #endregion
        
        #region Parameter Greengrass_TargetDevice
        /// <summary>
        /// <para>
        /// <para>The target device for the model. Currently the only supported value is <c>jetson_xavier</c>.
        /// If you specify <c>TargetDevice</c>, you can't specify <c>TargetPlatform</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Configuration_Greengrass_TargetDevice")]
        [AWSConstantClassSource("Amazon.LookoutforVision.TargetDevice")]
        public Amazon.LookoutforVision.TargetDevice Greengrass_TargetDevice { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>ClientToken is an idempotency token that ensures a call to <c>StartModelPackagingJob</c>
        /// completes only once. You choose the value to pass. For example, An issue might prevent
        /// you from getting a response from <c>StartModelPackagingJob</c>. In this case, safely
        /// retry your call to <c>StartModelPackagingJob</c> by using the same <c>ClientToken</c>
        /// parameter value.</para><para>If you don't supply a value for <c>ClientToken</c>, the AWS SDK you are using inserts
        /// a value for you. This prevents retries after a network error from making multiple
        /// dataset creation requests. You'll need to provide your own value for other use cases.
        /// </para><para>An error occurs if the other input parameters are not the same as in the first request.
        /// Using a different value for <c>ClientToken</c> is considered a new call to <c>StartModelPackagingJob</c>.
        /// An idempotency token is active for 8 hours. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'JobName'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LookoutforVision.Model.StartModelPackagingJobResponse).
        /// Specifying the name of a property of type Amazon.LookoutforVision.Model.StartModelPackagingJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "JobName";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-LFVModelPackagingJob (StartModelPackagingJob)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.LookoutforVision.Model.StartModelPackagingJobResponse, StartLFVModelPackagingJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            context.Greengrass_CompilerOption = this.Greengrass_CompilerOption;
            context.Greengrass_ComponentDescription = this.Greengrass_ComponentDescription;
            context.Greengrass_ComponentName = this.Greengrass_ComponentName;
            #if MODULAR
            if (this.Greengrass_ComponentName == null && ParameterWasBound(nameof(this.Greengrass_ComponentName)))
            {
                WriteWarning("You are passing $null as a value for parameter Greengrass_ComponentName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Greengrass_ComponentVersion = this.Greengrass_ComponentVersion;
            context.S3OutputLocation_Bucket = this.S3OutputLocation_Bucket;
            #if MODULAR
            if (this.S3OutputLocation_Bucket == null && ParameterWasBound(nameof(this.S3OutputLocation_Bucket)))
            {
                WriteWarning("You are passing $null as a value for parameter S3OutputLocation_Bucket which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.S3OutputLocation_Prefix = this.S3OutputLocation_Prefix;
            if (this.Greengrass_Tag != null)
            {
                context.Greengrass_Tag = new List<Amazon.LookoutforVision.Model.Tag>(this.Greengrass_Tag);
            }
            context.Greengrass_TargetDevice = this.Greengrass_TargetDevice;
            context.TargetPlatform_Accelerator = this.TargetPlatform_Accelerator;
            context.TargetPlatform_Arch = this.TargetPlatform_Arch;
            context.TargetPlatform_Os = this.TargetPlatform_Os;
            context.Description = this.Description;
            context.JobName = this.JobName;
            context.ModelVersion = this.ModelVersion;
            #if MODULAR
            if (this.ModelVersion == null && ParameterWasBound(nameof(this.ModelVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter ModelVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.LookoutforVision.Model.StartModelPackagingJobRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            
             // populate Configuration
            var requestConfigurationIsNull = true;
            request.Configuration = new Amazon.LookoutforVision.Model.ModelPackagingConfiguration();
            Amazon.LookoutforVision.Model.GreengrassConfiguration requestConfiguration_configuration_Greengrass = null;
            
             // populate Greengrass
            var requestConfiguration_configuration_GreengrassIsNull = true;
            requestConfiguration_configuration_Greengrass = new Amazon.LookoutforVision.Model.GreengrassConfiguration();
            System.String requestConfiguration_configuration_Greengrass_greengrass_CompilerOption = null;
            if (cmdletContext.Greengrass_CompilerOption != null)
            {
                requestConfiguration_configuration_Greengrass_greengrass_CompilerOption = cmdletContext.Greengrass_CompilerOption;
            }
            if (requestConfiguration_configuration_Greengrass_greengrass_CompilerOption != null)
            {
                requestConfiguration_configuration_Greengrass.CompilerOptions = requestConfiguration_configuration_Greengrass_greengrass_CompilerOption;
                requestConfiguration_configuration_GreengrassIsNull = false;
            }
            System.String requestConfiguration_configuration_Greengrass_greengrass_ComponentDescription = null;
            if (cmdletContext.Greengrass_ComponentDescription != null)
            {
                requestConfiguration_configuration_Greengrass_greengrass_ComponentDescription = cmdletContext.Greengrass_ComponentDescription;
            }
            if (requestConfiguration_configuration_Greengrass_greengrass_ComponentDescription != null)
            {
                requestConfiguration_configuration_Greengrass.ComponentDescription = requestConfiguration_configuration_Greengrass_greengrass_ComponentDescription;
                requestConfiguration_configuration_GreengrassIsNull = false;
            }
            System.String requestConfiguration_configuration_Greengrass_greengrass_ComponentName = null;
            if (cmdletContext.Greengrass_ComponentName != null)
            {
                requestConfiguration_configuration_Greengrass_greengrass_ComponentName = cmdletContext.Greengrass_ComponentName;
            }
            if (requestConfiguration_configuration_Greengrass_greengrass_ComponentName != null)
            {
                requestConfiguration_configuration_Greengrass.ComponentName = requestConfiguration_configuration_Greengrass_greengrass_ComponentName;
                requestConfiguration_configuration_GreengrassIsNull = false;
            }
            System.String requestConfiguration_configuration_Greengrass_greengrass_ComponentVersion = null;
            if (cmdletContext.Greengrass_ComponentVersion != null)
            {
                requestConfiguration_configuration_Greengrass_greengrass_ComponentVersion = cmdletContext.Greengrass_ComponentVersion;
            }
            if (requestConfiguration_configuration_Greengrass_greengrass_ComponentVersion != null)
            {
                requestConfiguration_configuration_Greengrass.ComponentVersion = requestConfiguration_configuration_Greengrass_greengrass_ComponentVersion;
                requestConfiguration_configuration_GreengrassIsNull = false;
            }
            List<Amazon.LookoutforVision.Model.Tag> requestConfiguration_configuration_Greengrass_greengrass_Tag = null;
            if (cmdletContext.Greengrass_Tag != null)
            {
                requestConfiguration_configuration_Greengrass_greengrass_Tag = cmdletContext.Greengrass_Tag;
            }
            if (requestConfiguration_configuration_Greengrass_greengrass_Tag != null)
            {
                requestConfiguration_configuration_Greengrass.Tags = requestConfiguration_configuration_Greengrass_greengrass_Tag;
                requestConfiguration_configuration_GreengrassIsNull = false;
            }
            Amazon.LookoutforVision.TargetDevice requestConfiguration_configuration_Greengrass_greengrass_TargetDevice = null;
            if (cmdletContext.Greengrass_TargetDevice != null)
            {
                requestConfiguration_configuration_Greengrass_greengrass_TargetDevice = cmdletContext.Greengrass_TargetDevice;
            }
            if (requestConfiguration_configuration_Greengrass_greengrass_TargetDevice != null)
            {
                requestConfiguration_configuration_Greengrass.TargetDevice = requestConfiguration_configuration_Greengrass_greengrass_TargetDevice;
                requestConfiguration_configuration_GreengrassIsNull = false;
            }
            Amazon.LookoutforVision.Model.S3Location requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation = null;
            
             // populate S3OutputLocation
            var requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocationIsNull = true;
            requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation = new Amazon.LookoutforVision.Model.S3Location();
            System.String requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation_s3OutputLocation_Bucket = null;
            if (cmdletContext.S3OutputLocation_Bucket != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation_s3OutputLocation_Bucket = cmdletContext.S3OutputLocation_Bucket;
            }
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation_s3OutputLocation_Bucket != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation.Bucket = requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation_s3OutputLocation_Bucket;
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocationIsNull = false;
            }
            System.String requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation_s3OutputLocation_Prefix = null;
            if (cmdletContext.S3OutputLocation_Prefix != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation_s3OutputLocation_Prefix = cmdletContext.S3OutputLocation_Prefix;
            }
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation_s3OutputLocation_Prefix != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation.Prefix = requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation_s3OutputLocation_Prefix;
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocationIsNull = false;
            }
             // determine if requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation should be set to null
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocationIsNull)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation = null;
            }
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation != null)
            {
                requestConfiguration_configuration_Greengrass.S3OutputLocation = requestConfiguration_configuration_Greengrass_configuration_Greengrass_S3OutputLocation;
                requestConfiguration_configuration_GreengrassIsNull = false;
            }
            Amazon.LookoutforVision.Model.TargetPlatform requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform = null;
            
             // populate TargetPlatform
            var requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatformIsNull = true;
            requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform = new Amazon.LookoutforVision.Model.TargetPlatform();
            Amazon.LookoutforVision.TargetPlatformAccelerator requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Accelerator = null;
            if (cmdletContext.TargetPlatform_Accelerator != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Accelerator = cmdletContext.TargetPlatform_Accelerator;
            }
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Accelerator != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform.Accelerator = requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Accelerator;
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatformIsNull = false;
            }
            Amazon.LookoutforVision.TargetPlatformArch requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Arch = null;
            if (cmdletContext.TargetPlatform_Arch != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Arch = cmdletContext.TargetPlatform_Arch;
            }
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Arch != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform.Arch = requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Arch;
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatformIsNull = false;
            }
            Amazon.LookoutforVision.TargetPlatformOs requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Os = null;
            if (cmdletContext.TargetPlatform_Os != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Os = cmdletContext.TargetPlatform_Os;
            }
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Os != null)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform.Os = requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform_targetPlatform_Os;
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatformIsNull = false;
            }
             // determine if requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform should be set to null
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatformIsNull)
            {
                requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform = null;
            }
            if (requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform != null)
            {
                requestConfiguration_configuration_Greengrass.TargetPlatform = requestConfiguration_configuration_Greengrass_configuration_Greengrass_TargetPlatform;
                requestConfiguration_configuration_GreengrassIsNull = false;
            }
             // determine if requestConfiguration_configuration_Greengrass should be set to null
            if (requestConfiguration_configuration_GreengrassIsNull)
            {
                requestConfiguration_configuration_Greengrass = null;
            }
            if (requestConfiguration_configuration_Greengrass != null)
            {
                request.Configuration.Greengrass = requestConfiguration_configuration_Greengrass;
                requestConfigurationIsNull = false;
            }
             // determine if request.Configuration should be set to null
            if (requestConfigurationIsNull)
            {
                request.Configuration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.JobName != null)
            {
                request.JobName = cmdletContext.JobName;
            }
            if (cmdletContext.ModelVersion != null)
            {
                request.ModelVersion = cmdletContext.ModelVersion;
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
        
        private Amazon.LookoutforVision.Model.StartModelPackagingJobResponse CallAWSServiceOperation(IAmazonLookoutforVision client, Amazon.LookoutforVision.Model.StartModelPackagingJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Lookout for Vision", "StartModelPackagingJob");
            try
            {
                #if DESKTOP
                return client.StartModelPackagingJob(request);
                #elif CORECLR
                return client.StartModelPackagingJobAsync(request).GetAwaiter().GetResult();
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
            public System.String Greengrass_CompilerOption { get; set; }
            public System.String Greengrass_ComponentDescription { get; set; }
            public System.String Greengrass_ComponentName { get; set; }
            public System.String Greengrass_ComponentVersion { get; set; }
            public System.String S3OutputLocation_Bucket { get; set; }
            public System.String S3OutputLocation_Prefix { get; set; }
            public List<Amazon.LookoutforVision.Model.Tag> Greengrass_Tag { get; set; }
            public Amazon.LookoutforVision.TargetDevice Greengrass_TargetDevice { get; set; }
            public Amazon.LookoutforVision.TargetPlatformAccelerator TargetPlatform_Accelerator { get; set; }
            public Amazon.LookoutforVision.TargetPlatformArch TargetPlatform_Arch { get; set; }
            public Amazon.LookoutforVision.TargetPlatformOs TargetPlatform_Os { get; set; }
            public System.String Description { get; set; }
            public System.String JobName { get; set; }
            public System.String ModelVersion { get; set; }
            public System.String ProjectName { get; set; }
            public System.Func<Amazon.LookoutforVision.Model.StartModelPackagingJobResponse, StartLFVModelPackagingJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.JobName;
        }
        
    }
}
