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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Creates a new image pipeline. Image pipelines enable you to automate the creation
    /// and distribution of images.
    /// </summary>
    [Cmdlet("New", "EC2IBImagePipeline", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder CreateImagePipeline API operation.", Operation = new[] {"CreateImagePipeline"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.CreateImagePipelineResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.CreateImagePipelineResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.CreateImagePipelineResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IBImagePipelineCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContainerRecipeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the container recipe that is used to configure images
        /// created by this container pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerRecipeArn { get; set; }
        #endregion
        
        #region Parameter EcrConfiguration_ContainerTag
        /// <summary>
        /// <para>
        /// <para>Tags for Image Builder to apply to the output container image that Amazon Inspector
        /// scans. Tags can help you identify and manage your scanned images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageScanningConfiguration_EcrConfiguration_ContainerTags")]
        public System.String[] EcrConfiguration_ContainerTag { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the image pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DistributionConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the distribution configuration that will be used
        /// to configure and distribute images created by this image pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DistributionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter EnhancedImageMetadataEnabled
        /// <summary>
        /// <para>
        /// <para>Collects additional information about the image being created, including the operating
        /// system (OS) version and package list. This information is used to enhance the overall
        /// experience of using EC2 Image Builder. Enabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnhancedImageMetadataEnabled { get; set; }
        #endregion
        
        #region Parameter ExecutionRole
        /// <summary>
        /// <para>
        /// <para>The name or Amazon Resource Name (ARN) for the IAM role you create that grants Image
        /// Builder access to perform workflow actions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ExecutionRole { get; set; }
        #endregion
        
        #region Parameter AutoDisablePolicy_FailureCount
        /// <summary>
        /// <para>
        /// <para>The number of consecutive scheduled image pipeline executions that must fail before
        /// Image Builder automatically disables the pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Schedule_AutoDisablePolicy_FailureCount")]
        public System.Int32? AutoDisablePolicy_FailureCount { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_ImageLogGroupName
        /// <summary>
        /// <para>
        /// <para>The log group name that Image Builder uses for image creation. If not specified, the
        /// log group name defaults to <c>/aws/imagebuilder/image-name</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_ImageLogGroupName { get; set; }
        #endregion
        
        #region Parameter ImageRecipeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the image recipe that will be used to configure
        /// images created by this image pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageRecipeArn { get; set; }
        #endregion
        
        #region Parameter ImageScanningConfiguration_ImageScanningEnabled
        /// <summary>
        /// <para>
        /// <para>A setting that indicates whether Image Builder keeps a snapshot of the vulnerability
        /// scans that Amazon Inspector runs against the build instance when you create a new
        /// image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ImageScanningConfiguration_ImageScanningEnabled { get; set; }
        #endregion
        
        #region Parameter ImageTestsConfiguration_ImageTestsEnabled
        /// <summary>
        /// <para>
        /// <para>Determines if tests should run after building the image. Image Builder defaults to
        /// enable tests to run following the image build, before image distribution.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ImageTestsConfiguration_ImageTestsEnabled { get; set; }
        #endregion
        
        #region Parameter InfrastructureConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the infrastructure configuration that will be used
        /// to build images created by this image pipeline.</para>
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
        public System.String InfrastructureConfigurationArn { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the image pipeline.</para>
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
        
        #region Parameter Schedule_PipelineExecutionStartCondition
        /// <summary>
        /// <para>
        /// <para>The start condition configures when the pipeline should trigger a new image build,
        /// as follows. If no value is set Image Builder defaults to <c>EXPRESSION_MATCH_AND_DEPENDENCY_UPDATES_AVAILABLE</c>.</para><ul><li><para><c>EXPRESSION_MATCH_AND_DEPENDENCY_UPDATES_AVAILABLE</c> (default) – When you use
        /// semantic version filters on the base image or components in your image recipe, EC2
        /// Image Builder builds a new image only when there are new versions of the base image
        /// or components in your recipe that match the filter.</para><note><para>For semantic version syntax, see <a href="https://docs.aws.amazon.com/imagebuilder/latest/APIReference/API_CreateComponent.html">CreateComponent</a>.</para></note></li><li><para><c>EXPRESSION_MATCH_ONLY</c> – This condition builds a new image every time the CRON
        /// expression matches the current time.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.PipelineExecutionStartCondition")]
        public Amazon.Imagebuilder.PipelineExecutionStartCondition Schedule_PipelineExecutionStartCondition { get; set; }
        #endregion
        
        #region Parameter LoggingConfiguration_PipelineLogGroupName
        /// <summary>
        /// <para>
        /// <para>The log group name that Image Builder uses for the log output during creation of a
        /// new pipeline. If not specified, the pipeline log group name defaults to <c>/aws/imagebuilder/pipeline/pipeline-name</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String LoggingConfiguration_PipelineLogGroupName { get; set; }
        #endregion
        
        #region Parameter EcrConfiguration_RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the container repository that Amazon Inspector scans to identify findings
        /// for your container images. The name includes the path for the repository location.
        /// If you don’t provide this information, Image Builder creates a repository in your
        /// account named <c>image-builder-image-scanning-repository</c> for vulnerability scans
        /// of your output container images.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageScanningConfiguration_EcrConfiguration_RepositoryName")]
        public System.String EcrConfiguration_RepositoryName { get; set; }
        #endregion
        
        #region Parameter Schedule_ScheduleExpression
        /// <summary>
        /// <para>
        /// <para>The cron expression determines how often EC2 Image Builder evaluates your <c>pipelineExecutionStartCondition</c>.</para><para>For information on how to format a cron expression in Image Builder, see <a href="https://docs.aws.amazon.com/imagebuilder/latest/userguide/image-builder-cron.html">Use
        /// cron expressions in EC2 Image Builder</a>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_ScheduleExpression { get; set; }
        #endregion
        
        #region Parameter Status
        /// <summary>
        /// <para>
        /// <para>The status of the image pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.PipelineStatus")]
        public Amazon.Imagebuilder.PipelineStatus Status { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags of the image pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ImageTestsConfiguration_TimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The maximum time in minutes that tests are permitted to run.</para><note><para>The timeout property is not currently active. This value is ignored.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageTestsConfiguration_TimeoutMinutes")]
        public System.Int32? ImageTestsConfiguration_TimeoutMinute { get; set; }
        #endregion
        
        #region Parameter Schedule_Timezone
        /// <summary>
        /// <para>
        /// <para>The timezone that applies to the scheduling expression. For example, "Etc/UTC", "America/Los_Angeles"
        /// in the <a href="https://www.joda.org/joda-time/timezones.html">IANA timezone format</a>.
        /// If not specified this defaults to UTC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Schedule_Timezone { get; set; }
        #endregion
        
        #region Parameter Workflow
        /// <summary>
        /// <para>
        /// <para>Contains an array of workflow configuration objects.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Workflows")]
        public Amazon.Imagebuilder.Model.WorkflowConfiguration[] Workflow { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para>Unique, case-sensitive identifier you provide to ensure idempotency of the request.
        /// For more information, see <a href="https://docs.aws.amazon.com/AWSEC2/latest/APIReference/Run_Instance_Idempotency.html">Ensuring
        /// idempotency</a> in the <i>Amazon EC2 API Reference</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImagePipelineArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.CreateImagePipelineResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.CreateImagePipelineResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImagePipelineArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IBImagePipeline (CreateImagePipeline)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.CreateImagePipelineResponse, NewEC2IBImagePipelineCmdlet>(Select) ??
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
            context.ClientToken = this.ClientToken;
            context.ContainerRecipeArn = this.ContainerRecipeArn;
            context.Description = this.Description;
            context.DistributionConfigurationArn = this.DistributionConfigurationArn;
            context.EnhancedImageMetadataEnabled = this.EnhancedImageMetadataEnabled;
            context.ExecutionRole = this.ExecutionRole;
            context.ImageRecipeArn = this.ImageRecipeArn;
            if (this.EcrConfiguration_ContainerTag != null)
            {
                context.EcrConfiguration_ContainerTag = new List<System.String>(this.EcrConfiguration_ContainerTag);
            }
            context.EcrConfiguration_RepositoryName = this.EcrConfiguration_RepositoryName;
            context.ImageScanningConfiguration_ImageScanningEnabled = this.ImageScanningConfiguration_ImageScanningEnabled;
            context.ImageTestsConfiguration_ImageTestsEnabled = this.ImageTestsConfiguration_ImageTestsEnabled;
            context.ImageTestsConfiguration_TimeoutMinute = this.ImageTestsConfiguration_TimeoutMinute;
            context.InfrastructureConfigurationArn = this.InfrastructureConfigurationArn;
            #if MODULAR
            if (this.InfrastructureConfigurationArn == null && ParameterWasBound(nameof(this.InfrastructureConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InfrastructureConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.LoggingConfiguration_ImageLogGroupName = this.LoggingConfiguration_ImageLogGroupName;
            context.LoggingConfiguration_PipelineLogGroupName = this.LoggingConfiguration_PipelineLogGroupName;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoDisablePolicy_FailureCount = this.AutoDisablePolicy_FailureCount;
            context.Schedule_PipelineExecutionStartCondition = this.Schedule_PipelineExecutionStartCondition;
            context.Schedule_ScheduleExpression = this.Schedule_ScheduleExpression;
            context.Schedule_Timezone = this.Schedule_Timezone;
            context.Status = this.Status;
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            if (this.Workflow != null)
            {
                context.Workflow = new List<Amazon.Imagebuilder.Model.WorkflowConfiguration>(this.Workflow);
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
            var request = new Amazon.Imagebuilder.Model.CreateImagePipelineRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContainerRecipeArn != null)
            {
                request.ContainerRecipeArn = cmdletContext.ContainerRecipeArn;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DistributionConfigurationArn != null)
            {
                request.DistributionConfigurationArn = cmdletContext.DistributionConfigurationArn;
            }
            if (cmdletContext.EnhancedImageMetadataEnabled != null)
            {
                request.EnhancedImageMetadataEnabled = cmdletContext.EnhancedImageMetadataEnabled.Value;
            }
            if (cmdletContext.ExecutionRole != null)
            {
                request.ExecutionRole = cmdletContext.ExecutionRole;
            }
            if (cmdletContext.ImageRecipeArn != null)
            {
                request.ImageRecipeArn = cmdletContext.ImageRecipeArn;
            }
            
             // populate ImageScanningConfiguration
            var requestImageScanningConfigurationIsNull = true;
            request.ImageScanningConfiguration = new Amazon.Imagebuilder.Model.ImageScanningConfiguration();
            System.Boolean? requestImageScanningConfiguration_imageScanningConfiguration_ImageScanningEnabled = null;
            if (cmdletContext.ImageScanningConfiguration_ImageScanningEnabled != null)
            {
                requestImageScanningConfiguration_imageScanningConfiguration_ImageScanningEnabled = cmdletContext.ImageScanningConfiguration_ImageScanningEnabled.Value;
            }
            if (requestImageScanningConfiguration_imageScanningConfiguration_ImageScanningEnabled != null)
            {
                request.ImageScanningConfiguration.ImageScanningEnabled = requestImageScanningConfiguration_imageScanningConfiguration_ImageScanningEnabled.Value;
                requestImageScanningConfigurationIsNull = false;
            }
            Amazon.Imagebuilder.Model.EcrConfiguration requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration = null;
            
             // populate EcrConfiguration
            var requestImageScanningConfiguration_imageScanningConfiguration_EcrConfigurationIsNull = true;
            requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration = new Amazon.Imagebuilder.Model.EcrConfiguration();
            List<System.String> requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration_ecrConfiguration_ContainerTag = null;
            if (cmdletContext.EcrConfiguration_ContainerTag != null)
            {
                requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration_ecrConfiguration_ContainerTag = cmdletContext.EcrConfiguration_ContainerTag;
            }
            if (requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration_ecrConfiguration_ContainerTag != null)
            {
                requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration.ContainerTags = requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration_ecrConfiguration_ContainerTag;
                requestImageScanningConfiguration_imageScanningConfiguration_EcrConfigurationIsNull = false;
            }
            System.String requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration_ecrConfiguration_RepositoryName = null;
            if (cmdletContext.EcrConfiguration_RepositoryName != null)
            {
                requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration_ecrConfiguration_RepositoryName = cmdletContext.EcrConfiguration_RepositoryName;
            }
            if (requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration_ecrConfiguration_RepositoryName != null)
            {
                requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration.RepositoryName = requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration_ecrConfiguration_RepositoryName;
                requestImageScanningConfiguration_imageScanningConfiguration_EcrConfigurationIsNull = false;
            }
             // determine if requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration should be set to null
            if (requestImageScanningConfiguration_imageScanningConfiguration_EcrConfigurationIsNull)
            {
                requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration = null;
            }
            if (requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration != null)
            {
                request.ImageScanningConfiguration.EcrConfiguration = requestImageScanningConfiguration_imageScanningConfiguration_EcrConfiguration;
                requestImageScanningConfigurationIsNull = false;
            }
             // determine if request.ImageScanningConfiguration should be set to null
            if (requestImageScanningConfigurationIsNull)
            {
                request.ImageScanningConfiguration = null;
            }
            
             // populate ImageTestsConfiguration
            var requestImageTestsConfigurationIsNull = true;
            request.ImageTestsConfiguration = new Amazon.Imagebuilder.Model.ImageTestsConfiguration();
            System.Boolean? requestImageTestsConfiguration_imageTestsConfiguration_ImageTestsEnabled = null;
            if (cmdletContext.ImageTestsConfiguration_ImageTestsEnabled != null)
            {
                requestImageTestsConfiguration_imageTestsConfiguration_ImageTestsEnabled = cmdletContext.ImageTestsConfiguration_ImageTestsEnabled.Value;
            }
            if (requestImageTestsConfiguration_imageTestsConfiguration_ImageTestsEnabled != null)
            {
                request.ImageTestsConfiguration.ImageTestsEnabled = requestImageTestsConfiguration_imageTestsConfiguration_ImageTestsEnabled.Value;
                requestImageTestsConfigurationIsNull = false;
            }
            System.Int32? requestImageTestsConfiguration_imageTestsConfiguration_TimeoutMinute = null;
            if (cmdletContext.ImageTestsConfiguration_TimeoutMinute != null)
            {
                requestImageTestsConfiguration_imageTestsConfiguration_TimeoutMinute = cmdletContext.ImageTestsConfiguration_TimeoutMinute.Value;
            }
            if (requestImageTestsConfiguration_imageTestsConfiguration_TimeoutMinute != null)
            {
                request.ImageTestsConfiguration.TimeoutMinutes = requestImageTestsConfiguration_imageTestsConfiguration_TimeoutMinute.Value;
                requestImageTestsConfigurationIsNull = false;
            }
             // determine if request.ImageTestsConfiguration should be set to null
            if (requestImageTestsConfigurationIsNull)
            {
                request.ImageTestsConfiguration = null;
            }
            if (cmdletContext.InfrastructureConfigurationArn != null)
            {
                request.InfrastructureConfigurationArn = cmdletContext.InfrastructureConfigurationArn;
            }
            
             // populate LoggingConfiguration
            var requestLoggingConfigurationIsNull = true;
            request.LoggingConfiguration = new Amazon.Imagebuilder.Model.PipelineLoggingConfiguration();
            System.String requestLoggingConfiguration_loggingConfiguration_ImageLogGroupName = null;
            if (cmdletContext.LoggingConfiguration_ImageLogGroupName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_ImageLogGroupName = cmdletContext.LoggingConfiguration_ImageLogGroupName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_ImageLogGroupName != null)
            {
                request.LoggingConfiguration.ImageLogGroupName = requestLoggingConfiguration_loggingConfiguration_ImageLogGroupName;
                requestLoggingConfigurationIsNull = false;
            }
            System.String requestLoggingConfiguration_loggingConfiguration_PipelineLogGroupName = null;
            if (cmdletContext.LoggingConfiguration_PipelineLogGroupName != null)
            {
                requestLoggingConfiguration_loggingConfiguration_PipelineLogGroupName = cmdletContext.LoggingConfiguration_PipelineLogGroupName;
            }
            if (requestLoggingConfiguration_loggingConfiguration_PipelineLogGroupName != null)
            {
                request.LoggingConfiguration.PipelineLogGroupName = requestLoggingConfiguration_loggingConfiguration_PipelineLogGroupName;
                requestLoggingConfigurationIsNull = false;
            }
             // determine if request.LoggingConfiguration should be set to null
            if (requestLoggingConfigurationIsNull)
            {
                request.LoggingConfiguration = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            
             // populate Schedule
            var requestScheduleIsNull = true;
            request.Schedule = new Amazon.Imagebuilder.Model.Schedule();
            Amazon.Imagebuilder.PipelineExecutionStartCondition requestSchedule_schedule_PipelineExecutionStartCondition = null;
            if (cmdletContext.Schedule_PipelineExecutionStartCondition != null)
            {
                requestSchedule_schedule_PipelineExecutionStartCondition = cmdletContext.Schedule_PipelineExecutionStartCondition;
            }
            if (requestSchedule_schedule_PipelineExecutionStartCondition != null)
            {
                request.Schedule.PipelineExecutionStartCondition = requestSchedule_schedule_PipelineExecutionStartCondition;
                requestScheduleIsNull = false;
            }
            System.String requestSchedule_schedule_ScheduleExpression = null;
            if (cmdletContext.Schedule_ScheduleExpression != null)
            {
                requestSchedule_schedule_ScheduleExpression = cmdletContext.Schedule_ScheduleExpression;
            }
            if (requestSchedule_schedule_ScheduleExpression != null)
            {
                request.Schedule.ScheduleExpression = requestSchedule_schedule_ScheduleExpression;
                requestScheduleIsNull = false;
            }
            System.String requestSchedule_schedule_Timezone = null;
            if (cmdletContext.Schedule_Timezone != null)
            {
                requestSchedule_schedule_Timezone = cmdletContext.Schedule_Timezone;
            }
            if (requestSchedule_schedule_Timezone != null)
            {
                request.Schedule.Timezone = requestSchedule_schedule_Timezone;
                requestScheduleIsNull = false;
            }
            Amazon.Imagebuilder.Model.AutoDisablePolicy requestSchedule_schedule_AutoDisablePolicy = null;
            
             // populate AutoDisablePolicy
            var requestSchedule_schedule_AutoDisablePolicyIsNull = true;
            requestSchedule_schedule_AutoDisablePolicy = new Amazon.Imagebuilder.Model.AutoDisablePolicy();
            System.Int32? requestSchedule_schedule_AutoDisablePolicy_autoDisablePolicy_FailureCount = null;
            if (cmdletContext.AutoDisablePolicy_FailureCount != null)
            {
                requestSchedule_schedule_AutoDisablePolicy_autoDisablePolicy_FailureCount = cmdletContext.AutoDisablePolicy_FailureCount.Value;
            }
            if (requestSchedule_schedule_AutoDisablePolicy_autoDisablePolicy_FailureCount != null)
            {
                requestSchedule_schedule_AutoDisablePolicy.FailureCount = requestSchedule_schedule_AutoDisablePolicy_autoDisablePolicy_FailureCount.Value;
                requestSchedule_schedule_AutoDisablePolicyIsNull = false;
            }
             // determine if requestSchedule_schedule_AutoDisablePolicy should be set to null
            if (requestSchedule_schedule_AutoDisablePolicyIsNull)
            {
                requestSchedule_schedule_AutoDisablePolicy = null;
            }
            if (requestSchedule_schedule_AutoDisablePolicy != null)
            {
                request.Schedule.AutoDisablePolicy = requestSchedule_schedule_AutoDisablePolicy;
                requestScheduleIsNull = false;
            }
             // determine if request.Schedule should be set to null
            if (requestScheduleIsNull)
            {
                request.Schedule = null;
            }
            if (cmdletContext.Status != null)
            {
                request.Status = cmdletContext.Status;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.Workflow != null)
            {
                request.Workflows = cmdletContext.Workflow;
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
        
        private Amazon.Imagebuilder.Model.CreateImagePipelineResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.CreateImagePipelineRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "CreateImagePipeline");
            try
            {
                #if DESKTOP
                return client.CreateImagePipeline(request);
                #elif CORECLR
                return client.CreateImagePipelineAsync(request).GetAwaiter().GetResult();
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
            public System.String ContainerRecipeArn { get; set; }
            public System.String Description { get; set; }
            public System.String DistributionConfigurationArn { get; set; }
            public System.Boolean? EnhancedImageMetadataEnabled { get; set; }
            public System.String ExecutionRole { get; set; }
            public System.String ImageRecipeArn { get; set; }
            public List<System.String> EcrConfiguration_ContainerTag { get; set; }
            public System.String EcrConfiguration_RepositoryName { get; set; }
            public System.Boolean? ImageScanningConfiguration_ImageScanningEnabled { get; set; }
            public System.Boolean? ImageTestsConfiguration_ImageTestsEnabled { get; set; }
            public System.Int32? ImageTestsConfiguration_TimeoutMinute { get; set; }
            public System.String InfrastructureConfigurationArn { get; set; }
            public System.String LoggingConfiguration_ImageLogGroupName { get; set; }
            public System.String LoggingConfiguration_PipelineLogGroupName { get; set; }
            public System.String Name { get; set; }
            public System.Int32? AutoDisablePolicy_FailureCount { get; set; }
            public Amazon.Imagebuilder.PipelineExecutionStartCondition Schedule_PipelineExecutionStartCondition { get; set; }
            public System.String Schedule_ScheduleExpression { get; set; }
            public System.String Schedule_Timezone { get; set; }
            public Amazon.Imagebuilder.PipelineStatus Status { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public List<Amazon.Imagebuilder.Model.WorkflowConfiguration> Workflow { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.CreateImagePipelineResponse, NewEC2IBImagePipelineCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImagePipelineArn;
        }
        
    }
}
