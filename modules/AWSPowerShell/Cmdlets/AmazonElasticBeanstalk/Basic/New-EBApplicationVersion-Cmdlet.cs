/*******************************************************************************
 *  Copyright 2012-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Specify a commit in an AWS CodeCommit repository with <code>SourceBuildInformation</code>.
    /// </para><para>
    /// Specify a build in an AWS CodeBuild with <code>SourceBuildInformation</code> and <code>BuildConfiguration</code>.
    /// </para><para>
    /// Specify a source bundle in S3 with <code>SourceBundle</code></para><para>
    /// Omit both <code>SourceBuildInformation</code> and <code>SourceBundle</code> to use
    /// the default sample application.
    /// </para><note><para>
    /// Once you create an application version with a specified Amazon S3 bucket and key location,
    /// you cannot change that Amazon S3 location. If you change the Amazon S3 location, you
    /// receive an exception when you attempt to launch an environment from the application
    /// version.
    /// </para></note>
    /// </summary>
    [Cmdlet("New", "EBApplicationVersion", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ElasticBeanstalk.Model.ApplicationVersionDescription")]
    [AWSCmdlet("Invokes the CreateApplicationVersion operation against AWS Elastic Beanstalk.", Operation = new[] {"CreateApplicationVersion"})]
    [AWSCmdletOutput("Amazon.ElasticBeanstalk.Model.ApplicationVersionDescription",
        "This cmdlet returns a ApplicationVersionDescription object.",
        "The service call response (type Amazon.ElasticBeanstalk.Model.CreateApplicationVersionResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEBApplicationVersionCmdlet : AmazonElasticBeanstalkClientCmdlet, IExecutor
    {
        
        #region Parameter ApplicationName
        /// <summary>
        /// <para>
        /// <para> The name of the application. If no application is found with this name, and <code>AutoCreateApplication</code>
        /// is <code>false</code>, returns an <code>InvalidParameterValue</code> error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
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
        [System.Management.Automation.Parameter]
        public System.String BuildConfiguration_ArtifactName { get; set; }
        #endregion
        
        #region Parameter AutoCreateApplication
        /// <summary>
        /// <para>
        /// <para>Set to <code>true</code> to create an application with the specified name if it doesn't
        /// already exist.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean AutoCreateApplication { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_CodeBuildServiceRole
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the AWS Identity and Access Management (IAM) role
        /// that enables AWS CodeBuild to interact with dependent AWS services on behalf of the
        /// AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BuildConfiguration_CodeBuildServiceRole { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_ComputeType
        /// <summary>
        /// <para>
        /// <para>Information about the compute resources the build project will use.</para><ul><li><para><code>BUILD_GENERAL1_SMALL: Use up to 3 GB memory and 2 vCPUs for builds</code></para></li><li><para><code>BUILD_GENERAL1_MEDIUM: Use up to 7 GB memory and 4 vCPUs for builds</code></para></li><li><para><code>BUILD_GENERAL1_LARGE: Use up to 15 GB memory and 8 vCPUs for builds</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticBeanstalk.ComputeType")]
        public Amazon.ElasticBeanstalk.ComputeType BuildConfiguration_ComputeType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>Describes this version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 2)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_Image
        /// <summary>
        /// <para>
        /// <para>The ID of the Docker image to use for this build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BuildConfiguration_Image { get; set; }
        #endregion
        
        #region Parameter Process
        /// <summary>
        /// <para>
        /// <para>Preprocesses and validates the environment manifest and configuration files in the
        /// source bundle. Validating configuration files can identify issues prior to deploying
        /// the application version to an environment.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Process { get; set; }
        #endregion
        
        #region Parameter SourceBundle_S3Bucket
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 bucket where the data is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceBundle_S3Bucket { get; set; }
        #endregion
        
        #region Parameter SourceBundle_S3Key
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 key where the data is located.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceBundle_S3Key { get; set; }
        #endregion
        
        #region Parameter SourceBuildInformation_SourceLocation
        /// <summary>
        /// <para>
        /// <para>The location of the source code, as a formatted string, depending on the value of
        /// <code>SourceRepository</code></para><ul><li><para>For <code>CodeCommit</code>, the format is the repository name and commit ID, separated
        /// by a forward slash. For example, <code>my-git-repo/265cfa0cf6af46153527f55d6503ec030551f57a</code>.</para></li><li><para>For <code>S3</code>, the format is the S3 bucket name and object key, separated by
        /// a forward slash. For example, <code>my-s3-bucket/Folders/my-source-file</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceBuildInformation_SourceLocation { get; set; }
        #endregion
        
        #region Parameter SourceBuildInformation_SourceRepository
        /// <summary>
        /// <para>
        /// <para>Location where the repository is stored.</para><ul><li><para><code>CodeCommit</code></para></li><li><para><code>S3</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticBeanstalk.SourceRepository")]
        public Amazon.ElasticBeanstalk.SourceRepository SourceBuildInformation_SourceRepository { get; set; }
        #endregion
        
        #region Parameter SourceBuildInformation_SourceType
        /// <summary>
        /// <para>
        /// <para>The type of repository.</para><ul><li><para><code>Git</code></para></li><li><para><code>Zip</code></para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.ElasticBeanstalk.SourceType")]
        public Amazon.ElasticBeanstalk.SourceType SourceBuildInformation_SourceType { get; set; }
        #endregion
        
        #region Parameter BuildConfiguration_TimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>How long in minutes, from 5 to 480 (8 hours), for AWS CodeBuild to wait until timing
        /// out any related build that does not get marked as completed. The default is 60 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("BuildConfiguration_TimeoutInMinutes")]
        public System.Int32 BuildConfiguration_TimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter VersionLabel
        /// <summary>
        /// <para>
        /// <para>A label identifying this version.</para><para>Constraint: Must be unique per application. If an application version already exists
        /// with this label for the specified application, AWS Elastic Beanstalk returns an <code>InvalidParameterValue</code>
        /// error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 1, ValueFromPipelineByPropertyName = true)]
        public System.String VersionLabel { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ApplicationName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EBApplicationVersion (CreateApplicationVersion)"))
            {
                return;
            }
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.ApplicationName = this.ApplicationName;
            if (ParameterWasBound("AutoCreateApplication"))
                context.AutoCreateApplication = this.AutoCreateApplication;
            context.BuildConfiguration_ArtifactName = this.BuildConfiguration_ArtifactName;
            context.BuildConfiguration_CodeBuildServiceRole = this.BuildConfiguration_CodeBuildServiceRole;
            context.BuildConfiguration_ComputeType = this.BuildConfiguration_ComputeType;
            context.BuildConfiguration_Image = this.BuildConfiguration_Image;
            if (ParameterWasBound("BuildConfiguration_TimeoutInMinute"))
                context.BuildConfiguration_TimeoutInMinutes = this.BuildConfiguration_TimeoutInMinute;
            context.Description = this.Description;
            if (ParameterWasBound("Process"))
                context.Process = this.Process;
            context.SourceBuildInformation_SourceLocation = this.SourceBuildInformation_SourceLocation;
            context.SourceBuildInformation_SourceRepository = this.SourceBuildInformation_SourceRepository;
            context.SourceBuildInformation_SourceType = this.SourceBuildInformation_SourceType;
            context.SourceBundle_S3Bucket = this.SourceBundle_S3Bucket;
            context.SourceBundle_S3Key = this.SourceBundle_S3Key;
            context.VersionLabel = this.VersionLabel;
            
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
            bool requestBuildConfigurationIsNull = true;
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
            if (cmdletContext.BuildConfiguration_TimeoutInMinutes != null)
            {
                requestBuildConfiguration_buildConfiguration_TimeoutInMinute = cmdletContext.BuildConfiguration_TimeoutInMinutes.Value;
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
            bool requestSourceBuildInformationIsNull = true;
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
            bool requestSourceBundleIsNull = true;
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
            if (cmdletContext.VersionLabel != null)
            {
                request.VersionLabel = cmdletContext.VersionLabel;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.ApplicationVersion;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.CreateApplicationVersionAsync(request);
                return task.Result;
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
            public System.Int32? BuildConfiguration_TimeoutInMinutes { get; set; }
            public System.String Description { get; set; }
            public System.Boolean? Process { get; set; }
            public System.String SourceBuildInformation_SourceLocation { get; set; }
            public Amazon.ElasticBeanstalk.SourceRepository SourceBuildInformation_SourceRepository { get; set; }
            public Amazon.ElasticBeanstalk.SourceType SourceBuildInformation_SourceType { get; set; }
            public System.String SourceBundle_S3Bucket { get; set; }
            public System.String SourceBundle_S3Key { get; set; }
            public System.String VersionLabel { get; set; }
        }
        
    }
}
