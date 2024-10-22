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
using Amazon.ElasticBeanstalk;
using Amazon.ElasticBeanstalk.Model;

namespace Amazon.PowerShell.Cmdlets.EB
{
    /// <summary>
    /// Creates an application version for the specified application. You can create an application
    /// version from a source bundle in Amazon S3, a commit in AWS CodeCommit, or the output
    /// of an AWS CodeBuild build as follows:
    /// 
    ///  
    /// <para>
    /// Specify a commit in an AWS CodeCommit repository with <c>SourceBuildInformation</c>.
    /// </para><para>
    /// Specify a build in an AWS CodeBuild with <c>SourceBuildInformation</c> and <c>BuildConfiguration</c>.
    /// </para><para>
    /// Specify a source bundle in S3 with <c>SourceBundle</c></para><para>
    /// Omit both <c>SourceBuildInformation</c> and <c>SourceBundle</c> to use the default
    /// sample application.
    /// </para><note><para>
    /// After you create an application version with a specified Amazon S3 bucket and key
    /// location, you can't change that Amazon S3 location. If you change the Amazon S3 location,
    /// you receive an exception when you attempt to launch an environment from the application
    /// version.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "EBApplicationVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.ApplicationVersionDescription")]
    [AWSCmdlet("Calls the AWS Elastic Beanstalk CreateApplicationVersion API operation.", Operation = new[] {"CreateApplicationVersion"}, SelectReturnType = typeof(Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse))]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.ApplicationVersionDescription or Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse",
        "This cmdlet returns an Amazon.ElasticBeanstalk.Model.ApplicationVersionDescription object.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEBApplicationVersionCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para> The name of the application. If no application is found with this name, and <c>AutoCreateApplication</c>
        /// is <c>false</c>, returns an <c>InvalidParameterValue</c> error. </para>
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
        public System.String ApplicationName { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_ArtifactName
        /// <summary>
        /// <para>
        /// <para>The name of the artifact of the CodeBuild build. If provided, Elastic Beanstalk stores
        /// the build artifact in the S3 location <i>S3-bucket</i>/resources/<i>application-name</i>/codebuild/codebuild-<i>version-label</i>-<i>artifact-name</i>.zip.
        /// If not provided, Elastic Beanstalk stores the build artifact in the S3 location <i>S3-bucket</i>/resources/<i>application-name</i>/codebuild/codebuild-<i>version-label</i>.zip.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildConfiguration_ArtifactName { get; set; }
        #endregion
        
        #region Parameter AutoCreateApplication
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to create an application with the specified name if it doesn't
        /// already exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? AutoCreateApplication { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_CodeBuildServiceRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that enables AWS CodeBuild to interact with dependent AWS services on behalf of the
        /// AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildConfiguration_CodeBuildServiceRole { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_ComputeType
        /// <summary>
        /// <para>
        /// <para>Information about the compute resources the build project will use.</para><ul><li><para><c>BUILD_GENERAL1_SMALL: Use up to 3 GB memory and 2 vCPUs for builds</c></para></li><li><para><c>BUILD_GENERAL1_MEDIUM: Use up to 7 GB memory and 4 vCPUs for builds</c></para></li><li><para><c>BUILD_GENERAL1_LARGE: Use up to 15 GB memory and 8 vCPUs for builds</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticBeanstalk.ComputeType")]
        public Amazon.ElasticBeanstalk.ComputeType BuildConfiguration_ComputeType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of this application version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2, ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_Image
        /// <summary>
        /// <para>
        /// <para>The ID of the Docker image to use for this build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildConfiguration_Image { get; set; }
        #endregion
        
        #region Parameter Process
        /// <summary>
        /// <para>
        /// <para>Pre-processes and validates the environment manifest (<c>env.yaml</c>) and configuration
        /// files (<c>*.config</c> files in the <c>.ebextensions</c> folder) in the source bundle.
        /// Validating configuration files can identify issues prior to deploying the application
        /// version to an environment.</para><para>You must turn processing on for application versions that you create using AWS CodeBuild
        /// or AWS CodeCommit. For application versions built from a source bundle in Amazon S3,
        /// processing is optional.</para><note><para>The <c>Process</c> option validates Elastic Beanstalk configuration files. It doesn't
        /// validate your application's configuration files, like proxy server or Docker configuration.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Process { get; set; }
        #endregion
        
        #region Parameter SourceBundle_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket where the data is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceBundle_S3Bucket { get; set; }
        #endregion
        
        #region Parameter SourceBundle_S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key where the data is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceBundle_S3Key { get; set; }
        #endregion
        
        #region Parameter SourceBuildInformation_SourceLocation
        /// <summary>
        /// <para>
        /// <para>The location of the source code, as a formatted string, depending on the value of
        /// <c>SourceRepository</c></para><ul><li><para>For <c>CodeCommit</c>, the format is the repository name and commit ID, separated
        /// by a forward slash. For example, <c>my-git-repo/265cfa0cf6af46153527f55d6503ec030551f57a</c>.</para></li><li><para>For <c>S3</c>, the format is the S3 bucket name and object key, separated by a forward
        /// slash. For example, <c>my-s3-bucket/Folders/my-source-file</c>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceBuildInformation_SourceLocation { get; set; }
        #endregion
        
        #region Parameter SourceBuildInformation_SourceRepository
        /// <summary>
        /// <para>
        /// <para>Location where the repository is stored.</para><ul><li><para><c>CodeCommit</c></para></li><li><para><c>S3</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticBeanstalk.SourceRepository")]
        public Amazon.ElasticBeanstalk.SourceRepository SourceBuildInformation_SourceRepository { get; set; }
        #endregion
        
        #region Parameter SourceBuildInformation_SourceType
        /// <summary>
        /// <para>
        /// <para>The type of repository.</para><ul><li><para><c>Git</c></para></li><li><para><c>Zip</c></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.ElasticBeanstalk.SourceType")]
        public Amazon.ElasticBeanstalk.SourceType SourceBuildInformation_SourceType { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Specifies the tags applied to the application version.</para><para>Elastic Beanstalk applies these tags only to the application version. Environments
        /// that use the application version don't inherit the tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.ElasticBeanstalk.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_TimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>How long in minutes, from 5 to 480 (8 hours), for AWS CodeBuild to wait until timing
        /// out any related build that does not get marked as completed. The default is 60 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildConfiguration_TimeoutInMinutes")]
        public System.Int32? BuildConfiguration_TimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter VersionLabel
        /// <summary>
        /// <para>
        /// <para>A label identifying this version.</para><para>Constraint: Must be unique per application. If an application version already exists
        /// with this label for the specified application, AWS Elastic Beanstalk returns an <c>InvalidParameterValue</c>
        /// error. </para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String VersionLabel { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ApplicationVersion'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse).
        /// Specifying the name of a property of type Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ApplicationVersion";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ApplicationName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBApplicationVersion (CreateApplicationVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse, NewEBApplicationVersionCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApplicationName = this.ApplicationName;
            #if MODULAR
            if (this.ApplicationName == null && ParameterWasBound(nameof(this.ApplicationName)))
            {
                WriteWarning("You are passing $null as a value for parameter ApplicationName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.AutoCreateApplication = this.AutoCreateApplication;
            context.BuildConfiguration_ArtifactName = this.BuildConfiguration_ArtifactName;
            context.BuildConfiguration_CodeBuildServiceRole = this.BuildConfiguration_CodeBuildServiceRole;
            context.BuildConfiguration_ComputeType = this.BuildConfiguration_ComputeType;
            context.BuildConfiguration_Image = this.BuildConfiguration_Image;
            context.BuildConfiguration_TimeoutInMinute = this.BuildConfiguration_TimeoutInMinute;
            context.Description = this.Description;
            context.Process = this.Process;
            context.SourceBuildInformation_SourceLocation = this.SourceBuildInformation_SourceLocation;
            context.SourceBuildInformation_SourceRepository = this.SourceBuildInformation_SourceRepository;
            context.SourceBuildInformation_SourceType = this.SourceBuildInformation_SourceType;
            context.SourceBundle_S3Bucket = this.SourceBundle_S3Bucket;
            context.SourceBundle_S3Key = this.SourceBundle_S3Key;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.ElasticBeanstalk.Model.Tag>(this.Tag);
            }
            context.VersionLabel = this.VersionLabel;
            #if MODULAR
            if (this.VersionLabel == null && ParameterWasBound(nameof(this.VersionLabel)))
            {
                WriteWarning("You are passing $null as a value for parameter VersionLabel which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.ElasticBeanstalk.Model.CreateApplicationVersionRequest();
            
            if (cmdletContext.ApplicationName != null)
            {
                request.ApplicationName = cmdletContext.ApplicationName;
            }
            if (cmdletContext.AutoCreateApplication != null)
            {
                request.AutoCreateApplication = cmdletContext.AutoCreateApplication.Value;
            }
            
             // populate BuildConfiguration
            var requestBuildConfigurationIsNull = true;
            request.BuildConfiguration = new Amazon.ElasticBeanstalk.Model.BuildConfiguration();
            System.String requestBuildConfiguration_buildConfiguration_ArtifactName = null;
            if (cmdletContext.BuildConfiguration_ArtifactName != null)
            {
                requestBuildConfiguration_buildConfiguration_ArtifactName = cmdletContext.BuildConfiguration_ArtifactName;
            }
            if (requestBuildConfiguration_buildConfiguration_ArtifactName != null)
            {
                request.BuildConfiguration.ArtifactName = requestBuildConfiguration_buildConfiguration_ArtifactName;
                requestBuildConfigurationIsNull = false;
            }
            System.String requestBuildConfiguration_buildConfiguration_CodeBuildServiceRole = null;
            if (cmdletContext.BuildConfiguration_CodeBuildServiceRole != null)
            {
                requestBuildConfiguration_buildConfiguration_CodeBuildServiceRole = cmdletContext.BuildConfiguration_CodeBuildServiceRole;
            }
            if (requestBuildConfiguration_buildConfiguration_CodeBuildServiceRole != null)
            {
                request.BuildConfiguration.CodeBuildServiceRole = requestBuildConfiguration_buildConfiguration_CodeBuildServiceRole;
                requestBuildConfigurationIsNull = false;
            }
            Amazon.ElasticBeanstalk.ComputeType requestBuildConfiguration_buildConfiguration_ComputeType = null;
            if (cmdletContext.BuildConfiguration_ComputeType != null)
            {
                requestBuildConfiguration_buildConfiguration_ComputeType = cmdletContext.BuildConfiguration_ComputeType;
            }
            if (requestBuildConfiguration_buildConfiguration_ComputeType != null)
            {
                request.BuildConfiguration.ComputeType = requestBuildConfiguration_buildConfiguration_ComputeType;
                requestBuildConfigurationIsNull = false;
            }
            System.String requestBuildConfiguration_buildConfiguration_Image = null;
            if (cmdletContext.BuildConfiguration_Image != null)
            {
                requestBuildConfiguration_buildConfiguration_Image = cmdletContext.BuildConfiguration_Image;
            }
            if (requestBuildConfiguration_buildConfiguration_Image != null)
            {
                request.BuildConfiguration.Image = requestBuildConfiguration_buildConfiguration_Image;
                requestBuildConfigurationIsNull = false;
            }
            System.Int32? requestBuildConfiguration_buildConfiguration_TimeoutInMinute = null;
            if (cmdletContext.BuildConfiguration_TimeoutInMinute != null)
            {
                requestBuildConfiguration_buildConfiguration_TimeoutInMinute = cmdletContext.BuildConfiguration_TimeoutInMinute.Value;
            }
            if (requestBuildConfiguration_buildConfiguration_TimeoutInMinute != null)
            {
                request.BuildConfiguration.TimeoutInMinutes = requestBuildConfiguration_buildConfiguration_TimeoutInMinute.Value;
                requestBuildConfigurationIsNull = false;
            }
             // determine if request.BuildConfiguration should be set to null
            if (requestBuildConfigurationIsNull)
            {
                request.BuildConfiguration = null;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Process != null)
            {
                request.Process = cmdletContext.Process.Value;
            }
            
             // populate SourceBuildInformation
            var requestSourceBuildInformationIsNull = true;
            request.SourceBuildInformation = new Amazon.ElasticBeanstalk.Model.SourceBuildInformation();
            System.String requestSourceBuildInformation_sourceBuildInformation_SourceLocation = null;
            if (cmdletContext.SourceBuildInformation_SourceLocation != null)
            {
                requestSourceBuildInformation_sourceBuildInformation_SourceLocation = cmdletContext.SourceBuildInformation_SourceLocation;
            }
            if (requestSourceBuildInformation_sourceBuildInformation_SourceLocation != null)
            {
                request.SourceBuildInformation.SourceLocation = requestSourceBuildInformation_sourceBuildInformation_SourceLocation;
                requestSourceBuildInformationIsNull = false;
            }
            Amazon.ElasticBeanstalk.SourceRepository requestSourceBuildInformation_sourceBuildInformation_SourceRepository = null;
            if (cmdletContext.SourceBuildInformation_SourceRepository != null)
            {
                requestSourceBuildInformation_sourceBuildInformation_SourceRepository = cmdletContext.SourceBuildInformation_SourceRepository;
            }
            if (requestSourceBuildInformation_sourceBuildInformation_SourceRepository != null)
            {
                request.SourceBuildInformation.SourceRepository = requestSourceBuildInformation_sourceBuildInformation_SourceRepository;
                requestSourceBuildInformationIsNull = false;
            }
            Amazon.ElasticBeanstalk.SourceType requestSourceBuildInformation_sourceBuildInformation_SourceType = null;
            if (cmdletContext.SourceBuildInformation_SourceType != null)
            {
                requestSourceBuildInformation_sourceBuildInformation_SourceType = cmdletContext.SourceBuildInformation_SourceType;
            }
            if (requestSourceBuildInformation_sourceBuildInformation_SourceType != null)
            {
                request.SourceBuildInformation.SourceType = requestSourceBuildInformation_sourceBuildInformation_SourceType;
                requestSourceBuildInformationIsNull = false;
            }
             // determine if request.SourceBuildInformation should be set to null
            if (requestSourceBuildInformationIsNull)
            {
                request.SourceBuildInformation = null;
            }
            
             // populate SourceBundle
            var requestSourceBundleIsNull = true;
            request.SourceBundle = new Amazon.ElasticBeanstalk.Model.S3Location();
            System.String requestSourceBundle_sourceBundle_S3Bucket = null;
            if (cmdletContext.SourceBundle_S3Bucket != null)
            {
                requestSourceBundle_sourceBundle_S3Bucket = cmdletContext.SourceBundle_S3Bucket;
            }
            if (requestSourceBundle_sourceBundle_S3Bucket != null)
            {
                request.SourceBundle.S3Bucket = requestSourceBundle_sourceBundle_S3Bucket;
                requestSourceBundleIsNull = false;
            }
            System.String requestSourceBundle_sourceBundle_S3Key = null;
            if (cmdletContext.SourceBundle_S3Key != null)
            {
                requestSourceBundle_sourceBundle_S3Key = cmdletContext.SourceBundle_S3Key;
            }
            if (requestSourceBundle_sourceBundle_S3Key != null)
            {
                request.SourceBundle.S3Key = requestSourceBundle_sourceBundle_S3Key;
                requestSourceBundleIsNull = false;
            }
             // determine if request.SourceBundle should be set to null
            if (requestSourceBundleIsNull)
            {
                request.SourceBundle = null;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
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
        
        private Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse CallAWSServiceOperation(IAmazonElasticBeanstalk client, Amazon.ElasticBeanstalk.Model.CreateApplicationVersionRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elastic Beanstalk", "CreateApplicationVersion");
            try
            {
                #if DESKTOP
                return client.CreateApplicationVersion(request);
                #elif CORECLR
                return client.CreateApplicationVersionAsync(request).GetAwaiter().GetResult();
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
            public System.String ApplicationName { get; set; }
            public System.Boolean? AutoCreateApplication { get; set; }
            public System.String BuildConfiguration_ArtifactName { get; set; }
            public System.String BuildConfiguration_CodeBuildServiceRole { get; set; }
            public Amazon.ElasticBeanstalk.ComputeType BuildConfiguration_ComputeType { get; set; }
            public System.String BuildConfiguration_Image { get; set; }
            public System.Int32? BuildConfiguration_TimeoutInMinute { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? Process { get; set; }
            public System.String SourceBuildInformation_SourceLocation { get; set; }
            public Amazon.ElasticBeanstalk.SourceRepository SourceBuildInformation_SourceRepository { get; set; }
            public Amazon.ElasticBeanstalk.SourceType SourceBuildInformation_SourceType { get; set; }
            public System.String SourceBundle_S3Bucket { get; set; }
            public System.String SourceBundle_S3Key { get; set; }
            public List<Amazon.ElasticBeanstalk.Model.Tag> Tag { get; set; }
            public System.String VersionLabel { get; set; }
            public System.Func<Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse, NewEBApplicationVersionCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ApplicationVersion;
        }
        
    }
}
