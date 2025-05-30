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
using System.Threading;
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Changes the settings of a build project.
    /// </summary>
    [Cmdlet("Update", "CBProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.Project")]
    [AWSCmdlet("Calls the AWS CodeBuild UpdateProject API operation.", Operation = new[] {"UpdateProject"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.UpdateProjectResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Project or Amazon.CodeBuild.Model.UpdateProjectResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.Project object.",
        "The service call response (type Amazon.CodeBuild.Model.UpdateProjectResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateCBProjectCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Artifacts_ArtifactIdentifier
        /// <summary>
        /// <para>
        /// <para> An identifier for this artifact definition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Artifacts_ArtifactIdentifier { get; set; }
        #endregion
        
        #region Parameter AutoRetryLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of additional automatic retries after a failed build. For example,
        /// if the auto-retry limit is set to 2, CodeBuild will call the <c>RetryBuild</c> API
        /// to automatically retry your build for up to 2 additional times.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? AutoRetryLimit { get; set; }
        #endregion
        
        #region Parameter BadgeEnabled
        /// <summary>
        /// <para>
        /// <para>Set this to true to generate a publicly accessible URL for your project's build badge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? BadgeEnabled { get; set; }
        #endregion
        
        #region Parameter BuildBatchConfig_BatchReportMode
        /// <summary>
        /// <para>
        /// <para>Specifies how build status reports are sent to the source provider for the batch build.
        /// This property is only used when the source provider for your project is Bitbucket,
        /// GitHub, or GitHub Enterprise, and your project is configured to report build statuses
        /// to the source provider.</para><dl><dt>REPORT_AGGREGATED_BATCH</dt><dd><para>(Default) Aggregate all of the build statuses into a single status report.</para></dd><dt>REPORT_INDIVIDUAL_BUILDS</dt><dd><para>Send a separate status report for each individual build.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.BatchReportModeType")]
        public Amazon.CodeBuild.BatchReportModeType BuildBatchConfig_BatchReportMode { get; set; }
        #endregion
        
        #region Parameter Artifacts_BucketOwnerAccess
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.BucketOwnerAccess")]
        public Amazon.CodeBuild.BucketOwnerAccess Artifacts_BucketOwnerAccess { get; set; }
        #endregion
        
        #region Parameter S3Logs_BucketOwnerAccess
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfig_S3Logs_BucketOwnerAccess")]
        [AWSConstantClassSource("Amazon.CodeBuild.BucketOwnerAccess")]
        public Amazon.CodeBuild.BucketOwnerAccess S3Logs_BucketOwnerAccess { get; set; }
        #endregion
        
        #region Parameter Source_Buildspec
        /// <summary>
        /// <para>
        /// <para>The buildspec file declaration to use for the builds in this build project.</para><para> If this value is set, it can be either an inline buildspec definition, the path to
        /// an alternate buildspec file relative to the value of the built-in <c>CODEBUILD_SRC_DIR</c>
        /// environment variable, or the path to an S3 bucket. The bucket must be in the same
        /// Amazon Web Services Region as the build project. Specify the buildspec file using
        /// its ARN (for example, <c>arn:aws:s3:::my-codebuild-sample2/buildspec.yml</c>). If
        /// this value is not provided or is set to an empty string, the source code must contain
        /// a buildspec file in its root directory. For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-spec-ref.html#build-spec-ref-name-storage">Buildspec
        /// File Name and Storage Location</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_Buildspec { get; set; }
        #endregion
        
        #region Parameter Cache_CacheNamespace
        /// <summary>
        /// <para>
        /// <para>Defines the scope of the cache. You can use this namespace to share a cache across
        /// multiple projects. For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/caching-s3.html#caching-s3-sharing">Cache
        /// sharing between projects</a> in the <i>CodeBuild User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cache_CacheNamespace { get; set; }
        #endregion
        
        #region Parameter Environment_Certificate
        /// <summary>
        /// <para>
        /// <para>The ARN of the Amazon S3 bucket, path prefix, and object key that contains the PEM-encoded
        /// certificate for the build project. For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/create-project-cli.html#cli.environment.certificate">certificate</a>
        /// in the <i>CodeBuild User Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Environment_Certificate { get; set; }
        #endregion
        
        #region Parameter BuildBatchConfig_CombineArtifact
        /// <summary>
        /// <para>
        /// <para>Specifies if the build artifacts for the batch build should be combined into a single
        /// artifact location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildBatchConfig_CombineArtifacts")]
        public System.Boolean? BuildBatchConfig_CombineArtifact { get; set; }
        #endregion
        
        #region Parameter Environment_ComputeType
        /// <summary>
        /// <para>
        /// <para>Information about the compute resources the build project uses. Available values include:</para><ul><li><para><c>ATTRIBUTE_BASED_COMPUTE</c>: Specify the amount of vCPUs, memory, disk space,
        /// and the type of machine.</para><note><para> If you use <c>ATTRIBUTE_BASED_COMPUTE</c>, you must define your attributes by using
        /// <c>computeConfiguration</c>. CodeBuild will select the cheapest instance that satisfies
        /// your specified attributes. For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-env-ref-compute-types.html#environment-reserved-capacity.types">Reserved
        /// capacity environment types</a> in the <i>CodeBuild User Guide</i>.</para></note></li><li><para><c>BUILD_GENERAL1_SMALL</c>: Use up to 4 GiB memory and 2 vCPUs for builds.</para></li><li><para><c>BUILD_GENERAL1_MEDIUM</c>: Use up to 8 GiB memory and 4 vCPUs for builds.</para></li><li><para><c>BUILD_GENERAL1_LARGE</c>: Use up to 16 GiB memory and 8 vCPUs for builds, depending
        /// on your environment type.</para></li><li><para><c>BUILD_GENERAL1_XLARGE</c>: Use up to 72 GiB memory and 36 vCPUs for builds, depending
        /// on your environment type.</para></li><li><para><c>BUILD_GENERAL1_2XLARGE</c>: Use up to 144 GiB memory, 72 vCPUs, and 824 GB of
        /// SSD storage for builds. This compute type supports Docker images up to 100 GB uncompressed.</para></li><li><para><c>BUILD_LAMBDA_1GB</c>: Use up to 1 GiB memory for builds. Only available for environment
        /// type <c>LINUX_LAMBDA_CONTAINER</c> and <c>ARM_LAMBDA_CONTAINER</c>.</para></li><li><para><c>BUILD_LAMBDA_2GB</c>: Use up to 2 GiB memory for builds. Only available for environment
        /// type <c>LINUX_LAMBDA_CONTAINER</c> and <c>ARM_LAMBDA_CONTAINER</c>.</para></li><li><para><c>BUILD_LAMBDA_4GB</c>: Use up to 4 GiB memory for builds. Only available for environment
        /// type <c>LINUX_LAMBDA_CONTAINER</c> and <c>ARM_LAMBDA_CONTAINER</c>.</para></li><li><para><c>BUILD_LAMBDA_8GB</c>: Use up to 8 GiB memory for builds. Only available for environment
        /// type <c>LINUX_LAMBDA_CONTAINER</c> and <c>ARM_LAMBDA_CONTAINER</c>.</para></li><li><para><c>BUILD_LAMBDA_10GB</c>: Use up to 10 GiB memory for builds. Only available for
        /// environment type <c>LINUX_LAMBDA_CONTAINER</c> and <c>ARM_LAMBDA_CONTAINER</c>.</para></li></ul><para> If you use <c>BUILD_GENERAL1_SMALL</c>: </para><ul><li><para> For environment type <c>LINUX_CONTAINER</c>, you can use up to 4 GiB memory and 2
        /// vCPUs for builds. </para></li><li><para> For environment type <c>LINUX_GPU_CONTAINER</c>, you can use up to 16 GiB memory,
        /// 4 vCPUs, and 1 NVIDIA A10G Tensor Core GPU for builds.</para></li><li><para> For environment type <c>ARM_CONTAINER</c>, you can use up to 4 GiB memory and 2 vCPUs
        /// on ARM-based processors for builds.</para></li></ul><para> If you use <c>BUILD_GENERAL1_LARGE</c>: </para><ul><li><para> For environment type <c>LINUX_CONTAINER</c>, you can use up to 16 GiB memory and
        /// 8 vCPUs for builds. </para></li><li><para> For environment type <c>LINUX_GPU_CONTAINER</c>, you can use up to 255 GiB memory,
        /// 32 vCPUs, and 4 NVIDIA Tesla V100 GPUs for builds.</para></li><li><para> For environment type <c>ARM_CONTAINER</c>, you can use up to 16 GiB memory and 8
        /// vCPUs on ARM-based processors for builds.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-env-ref-compute-types.html#environment.types">On-demand
        /// environment types</a> in the <i>CodeBuild User Guide.</i></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ComputeType")]
        public Amazon.CodeBuild.ComputeType Environment_ComputeType { get; set; }
        #endregion
        
        #region Parameter DockerServer_ComputeType
        /// <summary>
        /// <para>
        /// <para>Information about the compute resources the docker server uses. Available values include:</para><ul><li><para><c>BUILD_GENERAL1_SMALL</c>: Use up to 4 GiB memory and 2 vCPUs for your docker server.</para></li><li><para><c>BUILD_GENERAL1_MEDIUM</c>: Use up to 8 GiB memory and 4 vCPUs for your docker
        /// server.</para></li><li><para><c>BUILD_GENERAL1_LARGE</c>: Use up to 16 GiB memory and 8 vCPUs for your docker
        /// server.</para></li><li><para><c>BUILD_GENERAL1_XLARGE</c>: Use up to 64 GiB memory and 32 vCPUs for your docker
        /// server.</para></li><li><para><c>BUILD_GENERAL1_2XLARGE</c>: Use up to 128 GiB memory and 64 vCPUs for your docker
        /// server.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_DockerServer_ComputeType")]
        [AWSConstantClassSource("Amazon.CodeBuild.ComputeType")]
        public Amazon.CodeBuild.ComputeType DockerServer_ComputeType { get; set; }
        #endregion
        
        #region Parameter Restrictions_ComputeTypesAllowed
        /// <summary>
        /// <para>
        /// <para>An array of strings that specify the compute types that are allowed for the batch
        /// build. See <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-env-ref-compute-types.html">Build
        /// environment compute types</a> in the <i>CodeBuild User Guide</i> for these values.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildBatchConfig_Restrictions_ComputeTypesAllowed")]
        public System.String[] Restrictions_ComputeTypesAllowed { get; set; }
        #endregion
        
        #region Parameter ConcurrentBuildLimit
        /// <summary>
        /// <para>
        /// <para>The maximum number of concurrent builds that are allowed for this project.</para><para>New builds are only started if the current number of builds is less than or equal
        /// to this limit. If the current build count meets this limit, new builds are throttled
        /// and are not run.</para><para>To remove this limit, set this value to -1.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? ConcurrentBuildLimit { get; set; }
        #endregion
        
        #region Parameter BuildStatusConfig_Context
        /// <summary>
        /// <para>
        /// <para>Specifies the context of the build status CodeBuild sends to the source provider.
        /// The usage of this parameter depends on the source provider.</para><dl><dt>Bitbucket</dt><dd><para>This parameter is used for the <c>name</c> parameter in the Bitbucket commit status.
        /// For more information, see <a href="https://developer.atlassian.com/bitbucket/api/2/reference/resource/repositories/%7Bworkspace%7D/%7Brepo_slug%7D/commit/%7Bnode%7D/statuses/build">build</a>
        /// in the Bitbucket API documentation.</para></dd><dt>GitHub/GitHub Enterprise Server</dt><dd><para>This parameter is used for the <c>context</c> parameter in the GitHub commit status.
        /// For more information, see <a href="https://developer.github.com/v3/repos/statuses/#create-a-commit-status">Create
        /// a commit status</a> in the GitHub developer guide.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_BuildStatusConfig_Context")]
        public System.String BuildStatusConfig_Context { get; set; }
        #endregion
        
        #region Parameter RegistryCredential_Credential
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) or name of credentials created using Secrets Manager.
        /// </para><note><para> The <c>credential</c> can use the name of the credentials only if they exist in your
        /// current Amazon Web Services Region. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_RegistryCredential_Credential")]
        public System.String RegistryCredential_Credential { get; set; }
        #endregion
        
        #region Parameter RegistryCredential_CredentialProvider
        /// <summary>
        /// <para>
        /// <para> The service that created the credentials to access a private Docker registry. The
        /// valid value, SECRETS_MANAGER, is for Secrets Manager. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_RegistryCredential_CredentialProvider")]
        [AWSConstantClassSource("Amazon.CodeBuild.CredentialProviderType")]
        public Amazon.CodeBuild.CredentialProviderType RegistryCredential_CredentialProvider { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new or replacement description of the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Disk
        /// <summary>
        /// <para>
        /// <para>The amount of disk space of the instance type included in your fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_ComputeConfiguration_Disk")]
        public System.Int64? ComputeConfiguration_Disk { get; set; }
        #endregion
        
        #region Parameter Artifacts_EncryptionDisabled
        /// <summary>
        /// <para>
        /// <para> Set to true if you do not want your output artifacts encrypted. This option is valid
        /// only if your artifacts type is Amazon S3. If this is set with another artifacts type,
        /// an invalidInputException is thrown. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Artifacts_EncryptionDisabled { get; set; }
        #endregion
        
        #region Parameter S3Logs_EncryptionDisabled
        /// <summary>
        /// <para>
        /// <para> Set to true if you do not want your S3 build log output encrypted. By default S3
        /// build logs are encrypted. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfig_S3Logs_EncryptionDisabled")]
        public System.Boolean? S3Logs_EncryptionDisabled { get; set; }
        #endregion
        
        #region Parameter EncryptionKey
        /// <summary>
        /// <para>
        /// <para>The Key Management Service customer master key (CMK) to be used for encrypting the
        /// build output artifacts.</para><note><para> You can use a cross-account KMS key to encrypt the build output artifacts if your
        /// service role has permission to that key. </para></note><para>You can specify either the Amazon Resource Name (ARN) of the CMK or, if available,
        /// the CMK's alias (using the format <c>alias/&lt;alias-name&gt;</c>). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKey { get; set; }
        #endregion
        
        #region Parameter Environment_EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>A set of environment variables to make available to builds for this build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_EnvironmentVariables")]
        public Amazon.CodeBuild.Model.EnvironmentVariable[] Environment_EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter GitSubmodulesConfig_FetchSubmodule
        /// <summary>
        /// <para>
        /// <para> Set to true to fetch Git submodules for your CodeBuild build project. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_GitSubmodulesConfig_FetchSubmodules")]
        public System.Boolean? GitSubmodulesConfig_FetchSubmodule { get; set; }
        #endregion
        
        #region Parameter FileSystemLocation
        /// <summary>
        /// <para>
        /// <para> An array of <c>ProjectFileSystemLocation</c> objects for a CodeBuild build project.
        /// A <c>ProjectFileSystemLocation</c> object specifies the <c>identifier</c>, <c>location</c>,
        /// <c>mountOptions</c>, <c>mountPoint</c>, and <c>type</c> of a file system created using
        /// Amazon Elastic File System. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("FileSystemLocations")]
        public Amazon.CodeBuild.Model.ProjectFileSystemLocation[] FileSystemLocation { get; set; }
        #endregion
        
        #region Parameter Fleet_FleetArn
        /// <summary>
        /// <para>
        /// <para>Specifies the compute fleet ARN for the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_Fleet_FleetArn")]
        public System.String Fleet_FleetArn { get; set; }
        #endregion
        
        #region Parameter Restrictions_FleetsAllowed
        /// <summary>
        /// <para>
        /// <para>An array of strings that specify the fleets that are allowed for the batch build.
        /// See <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/fleets.html">Run
        /// builds on reserved capacity fleets</a> in the <i>CodeBuild User Guide</i> for more
        /// information. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildBatchConfig_Restrictions_FleetsAllowed")]
        public System.String[] Restrictions_FleetsAllowed { get; set; }
        #endregion
        
        #region Parameter Source_GitCloneDepth
        /// <summary>
        /// <para>
        /// <para>Information about the Git clone depth for the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Source_GitCloneDepth { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_GroupName
        /// <summary>
        /// <para>
        /// <para> The group name of the logs in CloudWatch Logs. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/Working-with-log-groups-and-streams.html">Working
        /// with Log Groups and Log Streams</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfig_CloudWatchLogs_GroupName")]
        public System.String CloudWatchLogs_GroupName { get; set; }
        #endregion
        
        #region Parameter Environment_Image
        /// <summary>
        /// <para>
        /// <para>The image tag or image digest that identifies the Docker image to use for this build
        /// project. Use the following formats:</para><ul><li><para>For an image tag: <c>&lt;registry&gt;/&lt;repository&gt;:&lt;tag&gt;</c>. For example,
        /// in the Docker repository that CodeBuild uses to manage its Docker images, this would
        /// be <c>aws/codebuild/standard:4.0</c>. </para></li><li><para>For an image digest: <c>&lt;registry&gt;/&lt;repository&gt;@&lt;digest&gt;</c>. For
        /// example, to specify an image with the digest "sha256:cbbf2f9a99b47fc460d422812b6a5adff7dfee951d8fa2e4a98caa0382cfbdbf,"
        /// use <c>&lt;registry&gt;/&lt;repository&gt;@sha256:cbbf2f9a99b47fc460d422812b6a5adff7dfee951d8fa2e4a98caa0382cfbdbf</c>.</para></li></ul><para>For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-env-ref-available.html">Docker
        /// images provided by CodeBuild</a> in the <i>CodeBuild user guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Environment_Image { get; set; }
        #endregion
        
        #region Parameter Environment_ImagePullCredentialsType
        /// <summary>
        /// <para>
        /// <para> The type of credentials CodeBuild uses to pull images in your build. There are two
        /// valid values: </para><ul><li><para><c>CODEBUILD</c> specifies that CodeBuild uses its own credentials. This requires
        /// that you modify your ECR repository policy to trust CodeBuild service principal. </para></li><li><para><c>SERVICE_ROLE</c> specifies that CodeBuild uses your build project's service role.
        /// </para></li></ul><para> When you use a cross-account or private registry image, you must use SERVICE_ROLE
        /// credentials. When you use an CodeBuild curated image, you must use CODEBUILD credentials.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ImagePullCredentialsType")]
        public Amazon.CodeBuild.ImagePullCredentialsType Environment_ImagePullCredentialsType { get; set; }
        #endregion
        
        #region Parameter Source_InsecureSsl
        /// <summary>
        /// <para>
        /// <para>Enable this flag to ignore SSL warnings while connecting to the project source code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Source_InsecureSsl { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_InstanceType
        /// <summary>
        /// <para>
        /// <para>The EC2 instance type to be launched in your fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_ComputeConfiguration_InstanceType")]
        public System.String ComputeConfiguration_InstanceType { get; set; }
        #endregion
        
        #region Parameter Artifacts_Location
        /// <summary>
        /// <para>
        /// <para>Information about the build output artifact location:</para><ul><li><para>If <c>type</c> is set to <c>CODEPIPELINE</c>, CodePipeline ignores this value if specified.
        /// This is because CodePipeline manages its build output locations instead of CodeBuild.</para></li><li><para>If <c>type</c> is set to <c>NO_ARTIFACTS</c>, this value is ignored if specified,
        /// because no build output is produced.</para></li><li><para>If <c>type</c> is set to <c>S3</c>, this is the name of the output bucket.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Artifacts_Location { get; set; }
        #endregion
        
        #region Parameter Cache_Location
        /// <summary>
        /// <para>
        /// <para>Information about the cache location: </para><ul><li><para><c>NO_CACHE</c> or <c>LOCAL</c>: This value is ignored.</para></li><li><para><c>S3</c>: This is the S3 bucket name/prefix.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cache_Location { get; set; }
        #endregion
        
        #region Parameter S3Logs_Location
        /// <summary>
        /// <para>
        /// <para> The ARN of an S3 bucket and the path prefix for S3 logs. If your Amazon S3 bucket
        /// name is <c>my-bucket</c>, and your path prefix is <c>build-log</c>, then acceptable
        /// formats are <c>my-bucket/build-log</c> or <c>arn:aws:s3:::my-bucket/build-log</c>.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfig_S3Logs_Location")]
        public System.String S3Logs_Location { get; set; }
        #endregion
        
        #region Parameter Source_Location
        /// <summary>
        /// <para>
        /// <para>Information about the location of the source code to be built. Valid values include:</para><ul><li><para>For source code settings that are specified in the source action of a pipeline in
        /// CodePipeline, <c>location</c> should not be specified. If it is specified, CodePipeline
        /// ignores it. This is because CodePipeline uses the settings in a pipeline's source
        /// action instead of this value.</para></li><li><para>For source code in an CodeCommit repository, the HTTPS clone URL to the repository
        /// that contains the source code and the buildspec file (for example, <c>https://git-codecommit.&lt;region-ID&gt;.amazonaws.com/v1/repos/&lt;repo-name&gt;</c>).</para></li><li><para>For source code in an Amazon S3 input bucket, one of the following. </para><ul><li><para>The path to the ZIP file that contains the source code (for example, <c>&lt;bucket-name&gt;/&lt;path&gt;/&lt;object-name&gt;.zip</c>).
        /// </para></li><li><para>The path to the folder that contains the source code (for example, <c>&lt;bucket-name&gt;/&lt;path-to-source-code&gt;/&lt;folder&gt;/</c>).
        /// </para></li></ul></li><li><para>For source code in a GitHub repository, the HTTPS clone URL to the repository that
        /// contains the source and the buildspec file. You must connect your Amazon Web Services
        /// account to your GitHub account. Use the CodeBuild console to start creating a build
        /// project. When you use the console to connect (or reconnect) with GitHub, on the GitHub
        /// <b>Authorize application</b> page, for <b>Organization access</b>, choose <b>Request
        /// access</b> next to each repository you want to allow CodeBuild to have access to,
        /// and then choose <b>Authorize application</b>. (After you have connected to your GitHub
        /// account, you do not need to finish creating the build project. You can leave the CodeBuild
        /// console.) To instruct CodeBuild to use this connection, in the <c>source</c> object,
        /// set the <c>auth</c> object's <c>type</c> value to <c>OAUTH</c>.</para></li><li><para>For source code in an GitLab or self-managed GitLab repository, the HTTPS clone URL
        /// to the repository that contains the source and the buildspec file. You must connect
        /// your Amazon Web Services account to your GitLab account. Use the CodeBuild console
        /// to start creating a build project. When you use the console to connect (or reconnect)
        /// with GitLab, on the Connections <b>Authorize application</b> page, choose <b>Authorize</b>.
        /// Then on the CodeConnections <b>Create GitLab connection</b> page, choose <b>Connect
        /// to GitLab</b>. (After you have connected to your GitLab account, you do not need to
        /// finish creating the build project. You can leave the CodeBuild console.) To instruct
        /// CodeBuild to override the default connection and use this connection instead, set
        /// the <c>auth</c> object's <c>type</c> value to <c>CODECONNECTIONS</c> in the <c>source</c>
        /// object.</para></li><li><para>For source code in a Bitbucket repository, the HTTPS clone URL to the repository that
        /// contains the source and the buildspec file. You must connect your Amazon Web Services
        /// account to your Bitbucket account. Use the CodeBuild console to start creating a build
        /// project. When you use the console to connect (or reconnect) with Bitbucket, on the
        /// Bitbucket <b>Confirm access to your account</b> page, choose <b>Grant access</b>.
        /// (After you have connected to your Bitbucket account, you do not need to finish creating
        /// the build project. You can leave the CodeBuild console.) To instruct CodeBuild to
        /// use this connection, in the <c>source</c> object, set the <c>auth</c> object's <c>type</c>
        /// value to <c>OAUTH</c>.</para></li></ul><para> If you specify <c>CODEPIPELINE</c> for the <c>Type</c> property, don't specify this
        /// property. For all of the other types, you must specify <c>Location</c>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_Location { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_MachineType
        /// <summary>
        /// <para>
        /// <para>The machine type of the instance type included in your fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_ComputeConfiguration_MachineType")]
        [AWSConstantClassSource("Amazon.CodeBuild.MachineType")]
        public Amazon.CodeBuild.MachineType ComputeConfiguration_MachineType { get; set; }
        #endregion
        
        #region Parameter Restrictions_MaximumBuildsAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of builds allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildBatchConfig_Restrictions_MaximumBuildsAllowed")]
        public System.Int32? Restrictions_MaximumBuildsAllowed { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_Memory
        /// <summary>
        /// <para>
        /// <para>The amount of memory of the instance type included in your fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_ComputeConfiguration_Memory")]
        public System.Int64? ComputeConfiguration_Memory { get; set; }
        #endregion
        
        #region Parameter Status_Message
        /// <summary>
        /// <para>
        /// <para>A message associated with the status of a docker server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_DockerServer_Status_Message")]
        public System.String Status_Message { get; set; }
        #endregion
        
        #region Parameter Cache_Mode
        /// <summary>
        /// <para>
        /// <para>An array of strings that specify the local cache modes. You can use one or more local
        /// cache modes at the same time. This is only used for <c>LOCAL</c> cache types.</para><para>Possible values are:</para><dl><dt>LOCAL_SOURCE_CACHE</dt><dd><para>Caches Git metadata for primary and secondary sources. After the cache is created,
        /// subsequent builds pull only the change between commits. This mode is a good choice
        /// for projects with a clean working directory and a source that is a large Git repository.
        /// If you choose this option and your project does not use a Git repository (GitHub,
        /// GitHub Enterprise, or Bitbucket), the option is ignored. </para></dd><dt>LOCAL_DOCKER_LAYER_CACHE</dt><dd><para>Caches existing Docker layers. This mode is a good choice for projects that build
        /// or pull large Docker images. It can prevent the performance issues caused by pulling
        /// large Docker images down from the network. </para><note><ul><li><para>You can use a Docker layer cache in the Linux environment only. </para></li><li><para>The <c>privileged</c> flag must be set so that your project has the required Docker
        /// permissions. </para></li><li><para>You should consider the security implications before you use a Docker layer cache.
        /// </para></li></ul></note></dd><dt>LOCAL_CUSTOM_CACHE</dt><dd><para>Caches directories you specify in the buildspec file. This mode is a good choice if
        /// your build scenario is not suited to one of the other three local cache modes. If
        /// you use a custom cache: </para><ul><li><para>Only directories can be specified for caching. You cannot specify individual files.
        /// </para></li><li><para>Symlinks are used to reference cached directories. </para></li><li><para>Cached directories are linked to your build before it downloads its project sources.
        /// Cached items are overridden if a source item has the same name. Directories are specified
        /// using cache paths in the buildspec file. </para></li></ul></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Cache_Modes")]
        public System.String[] Cache_Mode { get; set; }
        #endregion
        
        #region Parameter Artifacts_Name
        /// <summary>
        /// <para>
        /// <para>Along with <c>path</c> and <c>namespaceType</c>, the pattern that CodeBuild uses to
        /// name and store the output artifact:</para><ul><li><para>If <c>type</c> is set to <c>CODEPIPELINE</c>, CodePipeline ignores this value if specified.
        /// This is because CodePipeline manages its build output names instead of CodeBuild.</para></li><li><para>If <c>type</c> is set to <c>NO_ARTIFACTS</c>, this value is ignored if specified,
        /// because no build output is produced.</para></li><li><para>If <c>type</c> is set to <c>S3</c>, this is the name of the output artifact object.
        /// If you set the name to be a forward slash ("/"), the artifact is stored in the root
        /// of the output bucket.</para></li></ul><para>For example:</para><ul><li><para> If <c>path</c> is set to <c>MyArtifacts</c>, <c>namespaceType</c> is set to <c>BUILD_ID</c>,
        /// and <c>name</c> is set to <c>MyArtifact.zip</c>, then the output artifact is stored
        /// in <c>MyArtifacts/&lt;build-ID&gt;/MyArtifact.zip</c>. </para></li><li><para> If <c>path</c> is empty, <c>namespaceType</c> is set to <c>NONE</c>, and <c>name</c>
        /// is set to "<c>/</c>", the output artifact is stored in the root of the output bucket.
        /// </para></li><li><para> If <c>path</c> is set to <c>MyArtifacts</c>, <c>namespaceType</c> is set to <c>BUILD_ID</c>,
        /// and <c>name</c> is set to "<c>/</c>", the output artifact is stored in <c>MyArtifacts/&lt;build-ID&gt;</c>.
        /// </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Artifacts_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the build project.</para><note><para>You cannot change a build project's name.</para></note>
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
        
        #region Parameter Artifacts_NamespaceType
        /// <summary>
        /// <para>
        /// <para>Along with <c>path</c> and <c>name</c>, the pattern that CodeBuild uses to determine
        /// the name and location to store the output artifact:</para><ul><li><para>If <c>type</c> is set to <c>CODEPIPELINE</c>, CodePipeline ignores this value if specified.
        /// This is because CodePipeline manages its build output names instead of CodeBuild.</para></li><li><para>If <c>type</c> is set to <c>NO_ARTIFACTS</c>, this value is ignored if specified,
        /// because no build output is produced.</para></li><li><para>If <c>type</c> is set to <c>S3</c>, valid values include:</para><ul><li><para><c>BUILD_ID</c>: Include the build ID in the location of the build output artifact.</para></li><li><para><c>NONE</c>: Do not include the build ID. This is the default if <c>namespaceType</c>
        /// is not specified.</para></li></ul></li></ul><para>For example, if <c>path</c> is set to <c>MyArtifacts</c>, <c>namespaceType</c> is
        /// set to <c>BUILD_ID</c>, and <c>name</c> is set to <c>MyArtifact.zip</c>, the output
        /// artifact is stored in <c>MyArtifacts/&lt;build-ID&gt;/MyArtifact.zip</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactNamespace")]
        public Amazon.CodeBuild.ArtifactNamespace Artifacts_NamespaceType { get; set; }
        #endregion
        
        #region Parameter Artifacts_OverrideArtifactName
        /// <summary>
        /// <para>
        /// <para> If this flag is set, a name specified in the buildspec file overrides the artifact
        /// name. The name specified in a buildspec file is calculated at build time and uses
        /// the Shell Command Language. For example, you can append a date and time to your artifact
        /// name so that it is always unique. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Artifacts_OverrideArtifactName { get; set; }
        #endregion
        
        #region Parameter Artifacts_Packaging
        /// <summary>
        /// <para>
        /// <para>The type of build output artifact to create:</para><ul><li><para>If <c>type</c> is set to <c>CODEPIPELINE</c>, CodePipeline ignores this value if specified.
        /// This is because CodePipeline manages its build output artifacts instead of CodeBuild.</para></li><li><para>If <c>type</c> is set to <c>NO_ARTIFACTS</c>, this value is ignored if specified,
        /// because no build output is produced.</para></li><li><para>If <c>type</c> is set to <c>S3</c>, valid values include:</para><ul><li><para><c>NONE</c>: CodeBuild creates in the output bucket a folder that contains the build
        /// output. This is the default if <c>packaging</c> is not specified.</para></li><li><para><c>ZIP</c>: CodeBuild creates in the output bucket a ZIP file that contains the build
        /// output.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactPackaging")]
        public Amazon.CodeBuild.ArtifactPackaging Artifacts_Packaging { get; set; }
        #endregion
        
        #region Parameter Artifacts_Path
        /// <summary>
        /// <para>
        /// <para>Along with <c>namespaceType</c> and <c>name</c>, the pattern that CodeBuild uses to
        /// name and store the output artifact:</para><ul><li><para>If <c>type</c> is set to <c>CODEPIPELINE</c>, CodePipeline ignores this value if specified.
        /// This is because CodePipeline manages its build output names instead of CodeBuild.</para></li><li><para>If <c>type</c> is set to <c>NO_ARTIFACTS</c>, this value is ignored if specified,
        /// because no build output is produced.</para></li><li><para>If <c>type</c> is set to <c>S3</c>, this is the path to the output artifact. If <c>path</c>
        /// is not specified, <c>path</c> is not used.</para></li></ul><para>For example, if <c>path</c> is set to <c>MyArtifacts</c>, <c>namespaceType</c> is
        /// set to <c>NONE</c>, and <c>name</c> is set to <c>MyArtifact.zip</c>, the output artifact
        /// is stored in the output bucket at <c>MyArtifacts/MyArtifact.zip</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Artifacts_Path { get; set; }
        #endregion
        
        #region Parameter Environment_PrivilegedMode
        /// <summary>
        /// <para>
        /// <para>Enables running the Docker daemon inside a Docker container. Set to true only if the
        /// build project is used to build Docker images. Otherwise, a build that attempts to
        /// interact with the Docker daemon fails. The default setting is <c>false</c>.</para><para>You can initialize the Docker daemon during the install phase of your build by adding
        /// one of the following sets of commands to the install phase of your buildspec file:</para><para>If the operating system's base image is Ubuntu Linux:</para><para><c>- nohup /usr/local/bin/dockerd --host=unix:///var/run/docker.sock --host=tcp://0.0.0.0:2375
        /// --storage-driver=overlay&amp;</c></para><para><c>- timeout 15 sh -c "until docker info; do echo .; sleep 1; done"</c></para><para>If the operating system's base image is Alpine Linux and the previous command does
        /// not work, add the <c>-t</c> argument to <c>timeout</c>:</para><para><c>- nohup /usr/local/bin/dockerd --host=unix:///var/run/docker.sock --host=tcp://0.0.0.0:2375
        /// --storage-driver=overlay&amp;</c></para><para><c>- timeout -t 15 sh -c "until docker info; do echo .; sleep 1; done"</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Environment_PrivilegedMode { get; set; }
        #endregion
        
        #region Parameter QueuedTimeoutInMinute
        /// <summary>
        /// <para>
        /// <para> The number of minutes a build is allowed to be queued before it times out. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("QueuedTimeoutInMinutes")]
        public System.Int32? QueuedTimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter Source_ReportBuildStatus
        /// <summary>
        /// <para>
        /// <para> Set to true to report the status of a build's start and finish to your source provider.
        /// This option is valid only when your source provider is GitHub, GitHub Enterprise,
        /// GitLab, GitLab Self Managed, GitLab, GitLab Self Managed, or Bitbucket. If this is
        /// set and you use a different source provider, an <c>invalidInputException</c> is thrown.
        /// </para><para>To be able to report the build status to the source provider, the user associated
        /// with the source provider must have write access to the repo. If the user does not
        /// have write access, the build status cannot be updated. For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/access-tokens.html">Source
        /// provider access</a> in the <i>CodeBuild User Guide</i>.</para><para>The status of a build triggered by a webhook is always reported to your source provider.
        /// </para><para>If your project's builds are triggered by a webhook, you must push a new commit to
        /// the repo for a change to this property to take effect.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? Source_ReportBuildStatus { get; set; }
        #endregion
        
        #region Parameter Auth_Resource
        /// <summary>
        /// <para>
        /// <para>The resource value that applies to the specified authorization type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_Auth_Resource")]
        public System.String Auth_Resource { get; set; }
        #endregion
        
        #region Parameter SecondaryArtifact
        /// <summary>
        /// <para>
        /// <para> An array of <c>ProjectArtifact</c> objects. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecondaryArtifacts")]
        public Amazon.CodeBuild.Model.ProjectArtifacts[] SecondaryArtifact { get; set; }
        #endregion
        
        #region Parameter SecondarySource
        /// <summary>
        /// <para>
        /// <para> An array of <c>ProjectSource</c> objects. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecondarySources")]
        public Amazon.CodeBuild.Model.ProjectSource[] SecondarySource { get; set; }
        #endregion
        
        #region Parameter SecondarySourceVersion
        /// <summary>
        /// <para>
        /// <para> An array of <c>ProjectSourceVersion</c> objects. If <c>secondarySourceVersions</c>
        /// is specified at the build level, then they take over these <c>secondarySourceVersions</c>
        /// (at the project level). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecondarySourceVersions")]
        public Amazon.CodeBuild.Model.ProjectSourceVersion[] SecondarySourceVersion { get; set; }
        #endregion
        
        #region Parameter DockerServer_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of one or more security groups IDs.</para><note><para>Security groups configured for Docker servers should allow ingress network traffic
        /// from the VPC configured in the project. They should allow ingress on port 9876.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_DockerServer_SecurityGroupIds")]
        public System.String[] DockerServer_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of one or more security groups IDs in your Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter BuildBatchConfig_ServiceRole
        /// <summary>
        /// <para>
        /// <para>Specifies the service role ARN for the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildBatchConfig_ServiceRole { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The replacement ARN of the IAM role that enables CodeBuild to interact with dependent
        /// Amazon Web Services services on behalf of the Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter Source_SourceIdentifier
        /// <summary>
        /// <para>
        /// <para>An identifier for this project source. The identifier can only contain alphanumeric
        /// characters and underscores, and must be less than 128 characters in length. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_SourceIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para> A version of the build input to be built for this project. If not specified, the
        /// latest version is used. If specified, it must be one of: </para><ul><li><para>For CodeCommit: the commit ID, branch, or Git tag to use.</para></li><li><para>For GitHub: the commit ID, pull request ID, branch name, or tag name that corresponds
        /// to the version of the source code you want to build. If a pull request ID is specified,
        /// it must use the format <c>pr/pull-request-ID</c> (for example <c>pr/25</c>). If a
        /// branch name is specified, the branch's HEAD commit ID is used. If not specified, the
        /// default branch's HEAD commit ID is used.</para></li><li><para>For GitLab: the commit ID, branch, or Git tag to use.</para></li><li><para>For Bitbucket: the commit ID, branch name, or tag name that corresponds to the version
        /// of the source code you want to build. If a branch name is specified, the branch's
        /// HEAD commit ID is used. If not specified, the default branch's HEAD commit ID is used.</para></li><li><para>For Amazon S3: the version ID of the object that represents the build input ZIP file
        /// to use.</para></li></ul><para> If <c>sourceVersion</c> is specified at the build level, then that version takes
        /// precedence over this <c>sourceVersion</c> (at the project level). </para><para> For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/sample-source-version.html">Source
        /// Version Sample with CodeBuild</a> in the <i>CodeBuild User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceVersion { get; set; }
        #endregion
        
        #region Parameter Status_Status
        /// <summary>
        /// <para>
        /// <para>The status of the docker server.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_DockerServer_Status_Status")]
        public System.String Status_Status { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_Status
        /// <summary>
        /// <para>
        /// <para>The current status of the logs in CloudWatch Logs for a build project. Valid values
        /// are:</para><ul><li><para><c>ENABLED</c>: CloudWatch Logs are enabled for this build project.</para></li><li><para><c>DISABLED</c>: CloudWatch Logs are not enabled for this build project.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfig_CloudWatchLogs_Status")]
        [AWSConstantClassSource("Amazon.CodeBuild.LogsConfigStatusType")]
        public Amazon.CodeBuild.LogsConfigStatusType CloudWatchLogs_Status { get; set; }
        #endregion
        
        #region Parameter S3Logs_Status
        /// <summary>
        /// <para>
        /// <para>The current status of the S3 build logs. Valid values are:</para><ul><li><para><c>ENABLED</c>: S3 build logs are enabled for this build project.</para></li><li><para><c>DISABLED</c>: S3 build logs are not enabled for this build project.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfig_S3Logs_Status")]
        [AWSConstantClassSource("Amazon.CodeBuild.LogsConfigStatusType")]
        public Amazon.CodeBuild.LogsConfigStatusType S3Logs_Status { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_StreamName
        /// <summary>
        /// <para>
        /// <para> The prefix of the stream name of the CloudWatch Logs. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/Working-with-log-groups-and-streams.html">Working
        /// with Log Groups and Log Streams</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfig_CloudWatchLogs_StreamName")]
        public System.String CloudWatchLogs_StreamName { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>A list of one or more subnet IDs in your Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>An updated list of tag key and value pairs associated with this build project.</para><para>These tags are available for use by Amazon Web Services services that support CodeBuild
        /// build project tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CodeBuild.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter BuildStatusConfig_TargetUrl
        /// <summary>
        /// <para>
        /// <para>Specifies the target url of the build status CodeBuild sends to the source provider.
        /// The usage of this parameter depends on the source provider.</para><dl><dt>Bitbucket</dt><dd><para>This parameter is used for the <c>url</c> parameter in the Bitbucket commit status.
        /// For more information, see <a href="https://developer.atlassian.com/bitbucket/api/2/reference/resource/repositories/%7Bworkspace%7D/%7Brepo_slug%7D/commit/%7Bnode%7D/statuses/build">build</a>
        /// in the Bitbucket API documentation.</para></dd><dt>GitHub/GitHub Enterprise Server</dt><dd><para>This parameter is used for the <c>target_url</c> parameter in the GitHub commit status.
        /// For more information, see <a href="https://developer.github.com/v3/repos/statuses/#create-a-commit-status">Create
        /// a commit status</a> in the GitHub developer guide.</para></dd></dl>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_BuildStatusConfig_TargetUrl")]
        public System.String BuildStatusConfig_TargetUrl { get; set; }
        #endregion
        
        #region Parameter BuildBatchConfig_TimeoutInMin
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum amount of time, in minutes, that the batch build must be completed
        /// in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildBatchConfig_TimeoutInMins")]
        public System.Int32? BuildBatchConfig_TimeoutInMin { get; set; }
        #endregion
        
        #region Parameter TimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The replacement value in minutes, from 5 to 2160 (36 hours), for CodeBuild to wait
        /// before timing out any related build that did not get marked as completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutInMinutes")]
        public System.Int32? TimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter Artifacts_Type
        /// <summary>
        /// <para>
        /// <para>The type of build output artifact. Valid values include:</para><ul><li><para><c>CODEPIPELINE</c>: The build project has build output generated through CodePipeline.
        /// </para><note><para>The <c>CODEPIPELINE</c> type is not supported for <c>secondaryArtifacts</c>.</para></note></li><li><para><c>NO_ARTIFACTS</c>: The build project does not produce any build output.</para></li><li><para><c>S3</c>: The build project stores build output in Amazon S3.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactsType")]
        public Amazon.CodeBuild.ArtifactsType Artifacts_Type { get; set; }
        #endregion
        
        #region Parameter Cache_Type
        /// <summary>
        /// <para>
        /// <para>The type of cache used by the build project. Valid values include:</para><ul><li><para><c>NO_CACHE</c>: The build project does not use any cache.</para></li><li><para><c>S3</c>: The build project reads and writes from and to S3.</para></li><li><para><c>LOCAL</c>: The build project stores a cache locally on a build host that is only
        /// available to that build host.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.CacheType")]
        public Amazon.CodeBuild.CacheType Cache_Type { get; set; }
        #endregion
        
        #region Parameter Environment_Type
        /// <summary>
        /// <para>
        /// <para>The type of build environment to use for related builds.</para><note><para>If you're using compute fleets during project creation, <c>type</c> will be ignored.</para></note><para>For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-env-ref-compute-types.html">Build
        /// environment compute types</a> in the <i>CodeBuild user guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.EnvironmentType")]
        public Amazon.CodeBuild.EnvironmentType Environment_Type { get; set; }
        #endregion
        
        #region Parameter Auth_Type
        /// <summary>
        /// <para>
        /// <para>The authorization type to use. Valid options are OAUTH, CODECONNECTIONS, or SECRETS_MANAGER.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_Auth_Type")]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceAuthType")]
        public Amazon.CodeBuild.SourceAuthType Auth_Type { get; set; }
        #endregion
        
        #region Parameter Source_Type
        /// <summary>
        /// <para>
        /// <para>The type of repository that contains the source code to be built. Valid values include:</para><ul><li><para><c>BITBUCKET</c>: The source code is in a Bitbucket repository.</para></li><li><para><c>CODECOMMIT</c>: The source code is in an CodeCommit repository.</para></li><li><para><c>CODEPIPELINE</c>: The source code settings are specified in the source action
        /// of a pipeline in CodePipeline.</para></li><li><para><c>GITHUB</c>: The source code is in a GitHub repository.</para></li><li><para><c>GITHUB_ENTERPRISE</c>: The source code is in a GitHub Enterprise Server repository.</para></li><li><para><c>GITLAB</c>: The source code is in a GitLab repository.</para></li><li><para><c>GITLAB_SELF_MANAGED</c>: The source code is in a self-managed GitLab repository.</para></li><li><para><c>NO_SOURCE</c>: The project does not have input source code.</para></li><li><para><c>S3</c>: The source code is in an Amazon S3 bucket.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceType")]
        public Amazon.CodeBuild.SourceType Source_Type { get; set; }
        #endregion
        
        #region Parameter ComputeConfiguration_VCpu
        /// <summary>
        /// <para>
        /// <para>The number of vCPUs of the instance type included in your fleet.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Environment_ComputeConfiguration_VCpu")]
        public System.Int64? ComputeConfiguration_VCpu { get; set; }
        #endregion
        
        #region Parameter VpcConfig_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String VpcConfig_VpcId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Project'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.UpdateProjectResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.UpdateProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Project";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CBProject (UpdateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.UpdateProjectResponse, UpdateCBProjectCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Artifacts_ArtifactIdentifier = this.Artifacts_ArtifactIdentifier;
            context.Artifacts_BucketOwnerAccess = this.Artifacts_BucketOwnerAccess;
            context.Artifacts_EncryptionDisabled = this.Artifacts_EncryptionDisabled;
            context.Artifacts_Location = this.Artifacts_Location;
            context.Artifacts_Name = this.Artifacts_Name;
            context.Artifacts_NamespaceType = this.Artifacts_NamespaceType;
            context.Artifacts_OverrideArtifactName = this.Artifacts_OverrideArtifactName;
            context.Artifacts_Packaging = this.Artifacts_Packaging;
            context.Artifacts_Path = this.Artifacts_Path;
            context.Artifacts_Type = this.Artifacts_Type;
            context.AutoRetryLimit = this.AutoRetryLimit;
            context.BadgeEnabled = this.BadgeEnabled;
            context.BuildBatchConfig_BatchReportMode = this.BuildBatchConfig_BatchReportMode;
            context.BuildBatchConfig_CombineArtifact = this.BuildBatchConfig_CombineArtifact;
            if (this.Restrictions_ComputeTypesAllowed != null)
            {
                context.Restrictions_ComputeTypesAllowed = new List<System.String>(this.Restrictions_ComputeTypesAllowed);
            }
            if (this.Restrictions_FleetsAllowed != null)
            {
                context.Restrictions_FleetsAllowed = new List<System.String>(this.Restrictions_FleetsAllowed);
            }
            context.Restrictions_MaximumBuildsAllowed = this.Restrictions_MaximumBuildsAllowed;
            context.BuildBatchConfig_ServiceRole = this.BuildBatchConfig_ServiceRole;
            context.BuildBatchConfig_TimeoutInMin = this.BuildBatchConfig_TimeoutInMin;
            context.Cache_CacheNamespace = this.Cache_CacheNamespace;
            context.Cache_Location = this.Cache_Location;
            if (this.Cache_Mode != null)
            {
                context.Cache_Mode = new List<System.String>(this.Cache_Mode);
            }
            context.Cache_Type = this.Cache_Type;
            context.ConcurrentBuildLimit = this.ConcurrentBuildLimit;
            context.Description = this.Description;
            context.EncryptionKey = this.EncryptionKey;
            context.Environment_Certificate = this.Environment_Certificate;
            context.ComputeConfiguration_Disk = this.ComputeConfiguration_Disk;
            context.ComputeConfiguration_InstanceType = this.ComputeConfiguration_InstanceType;
            context.ComputeConfiguration_MachineType = this.ComputeConfiguration_MachineType;
            context.ComputeConfiguration_Memory = this.ComputeConfiguration_Memory;
            context.ComputeConfiguration_VCpu = this.ComputeConfiguration_VCpu;
            context.Environment_ComputeType = this.Environment_ComputeType;
            context.DockerServer_ComputeType = this.DockerServer_ComputeType;
            if (this.DockerServer_SecurityGroupId != null)
            {
                context.DockerServer_SecurityGroupId = new List<System.String>(this.DockerServer_SecurityGroupId);
            }
            context.Status_Message = this.Status_Message;
            context.Status_Status = this.Status_Status;
            if (this.Environment_EnvironmentVariable != null)
            {
                context.Environment_EnvironmentVariable = new List<Amazon.CodeBuild.Model.EnvironmentVariable>(this.Environment_EnvironmentVariable);
            }
            context.Fleet_FleetArn = this.Fleet_FleetArn;
            context.Environment_Image = this.Environment_Image;
            context.Environment_ImagePullCredentialsType = this.Environment_ImagePullCredentialsType;
            context.Environment_PrivilegedMode = this.Environment_PrivilegedMode;
            context.RegistryCredential_Credential = this.RegistryCredential_Credential;
            context.RegistryCredential_CredentialProvider = this.RegistryCredential_CredentialProvider;
            context.Environment_Type = this.Environment_Type;
            if (this.FileSystemLocation != null)
            {
                context.FileSystemLocation = new List<Amazon.CodeBuild.Model.ProjectFileSystemLocation>(this.FileSystemLocation);
            }
            context.CloudWatchLogs_GroupName = this.CloudWatchLogs_GroupName;
            context.CloudWatchLogs_Status = this.CloudWatchLogs_Status;
            context.CloudWatchLogs_StreamName = this.CloudWatchLogs_StreamName;
            context.S3Logs_BucketOwnerAccess = this.S3Logs_BucketOwnerAccess;
            context.S3Logs_EncryptionDisabled = this.S3Logs_EncryptionDisabled;
            context.S3Logs_Location = this.S3Logs_Location;
            context.S3Logs_Status = this.S3Logs_Status;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueuedTimeoutInMinute = this.QueuedTimeoutInMinute;
            if (this.SecondaryArtifact != null)
            {
                context.SecondaryArtifact = new List<Amazon.CodeBuild.Model.ProjectArtifacts>(this.SecondaryArtifact);
            }
            if (this.SecondarySource != null)
            {
                context.SecondarySource = new List<Amazon.CodeBuild.Model.ProjectSource>(this.SecondarySource);
            }
            if (this.SecondarySourceVersion != null)
            {
                context.SecondarySourceVersion = new List<Amazon.CodeBuild.Model.ProjectSourceVersion>(this.SecondarySourceVersion);
            }
            context.ServiceRole = this.ServiceRole;
            context.Auth_Resource = this.Auth_Resource;
            context.Auth_Type = this.Auth_Type;
            context.Source_Buildspec = this.Source_Buildspec;
            context.BuildStatusConfig_Context = this.BuildStatusConfig_Context;
            context.BuildStatusConfig_TargetUrl = this.BuildStatusConfig_TargetUrl;
            context.Source_GitCloneDepth = this.Source_GitCloneDepth;
            context.GitSubmodulesConfig_FetchSubmodule = this.GitSubmodulesConfig_FetchSubmodule;
            context.Source_InsecureSsl = this.Source_InsecureSsl;
            context.Source_Location = this.Source_Location;
            context.Source_ReportBuildStatus = this.Source_ReportBuildStatus;
            context.Source_SourceIdentifier = this.Source_SourceIdentifier;
            context.Source_Type = this.Source_Type;
            context.SourceVersion = this.SourceVersion;
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.CodeBuild.Model.Tag>(this.Tag);
            }
            context.TimeoutInMinute = this.TimeoutInMinute;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupId = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnet = new List<System.String>(this.VpcConfig_Subnet);
            }
            context.VpcConfig_VpcId = this.VpcConfig_VpcId;
            
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
            var request = new Amazon.CodeBuild.Model.UpdateProjectRequest();
            
            
             // populate Artifacts
            var requestArtifactsIsNull = true;
            request.Artifacts = new Amazon.CodeBuild.Model.ProjectArtifacts();
            System.String requestArtifacts_artifacts_ArtifactIdentifier = null;
            if (cmdletContext.Artifacts_ArtifactIdentifier != null)
            {
                requestArtifacts_artifacts_ArtifactIdentifier = cmdletContext.Artifacts_ArtifactIdentifier;
            }
            if (requestArtifacts_artifacts_ArtifactIdentifier != null)
            {
                request.Artifacts.ArtifactIdentifier = requestArtifacts_artifacts_ArtifactIdentifier;
                requestArtifactsIsNull = false;
            }
            Amazon.CodeBuild.BucketOwnerAccess requestArtifacts_artifacts_BucketOwnerAccess = null;
            if (cmdletContext.Artifacts_BucketOwnerAccess != null)
            {
                requestArtifacts_artifacts_BucketOwnerAccess = cmdletContext.Artifacts_BucketOwnerAccess;
            }
            if (requestArtifacts_artifacts_BucketOwnerAccess != null)
            {
                request.Artifacts.BucketOwnerAccess = requestArtifacts_artifacts_BucketOwnerAccess;
                requestArtifactsIsNull = false;
            }
            System.Boolean? requestArtifacts_artifacts_EncryptionDisabled = null;
            if (cmdletContext.Artifacts_EncryptionDisabled != null)
            {
                requestArtifacts_artifacts_EncryptionDisabled = cmdletContext.Artifacts_EncryptionDisabled.Value;
            }
            if (requestArtifacts_artifacts_EncryptionDisabled != null)
            {
                request.Artifacts.EncryptionDisabled = requestArtifacts_artifacts_EncryptionDisabled.Value;
                requestArtifactsIsNull = false;
            }
            System.String requestArtifacts_artifacts_Location = null;
            if (cmdletContext.Artifacts_Location != null)
            {
                requestArtifacts_artifacts_Location = cmdletContext.Artifacts_Location;
            }
            if (requestArtifacts_artifacts_Location != null)
            {
                request.Artifacts.Location = requestArtifacts_artifacts_Location;
                requestArtifactsIsNull = false;
            }
            System.String requestArtifacts_artifacts_Name = null;
            if (cmdletContext.Artifacts_Name != null)
            {
                requestArtifacts_artifacts_Name = cmdletContext.Artifacts_Name;
            }
            if (requestArtifacts_artifacts_Name != null)
            {
                request.Artifacts.Name = requestArtifacts_artifacts_Name;
                requestArtifactsIsNull = false;
            }
            Amazon.CodeBuild.ArtifactNamespace requestArtifacts_artifacts_NamespaceType = null;
            if (cmdletContext.Artifacts_NamespaceType != null)
            {
                requestArtifacts_artifacts_NamespaceType = cmdletContext.Artifacts_NamespaceType;
            }
            if (requestArtifacts_artifacts_NamespaceType != null)
            {
                request.Artifacts.NamespaceType = requestArtifacts_artifacts_NamespaceType;
                requestArtifactsIsNull = false;
            }
            System.Boolean? requestArtifacts_artifacts_OverrideArtifactName = null;
            if (cmdletContext.Artifacts_OverrideArtifactName != null)
            {
                requestArtifacts_artifacts_OverrideArtifactName = cmdletContext.Artifacts_OverrideArtifactName.Value;
            }
            if (requestArtifacts_artifacts_OverrideArtifactName != null)
            {
                request.Artifacts.OverrideArtifactName = requestArtifacts_artifacts_OverrideArtifactName.Value;
                requestArtifactsIsNull = false;
            }
            Amazon.CodeBuild.ArtifactPackaging requestArtifacts_artifacts_Packaging = null;
            if (cmdletContext.Artifacts_Packaging != null)
            {
                requestArtifacts_artifacts_Packaging = cmdletContext.Artifacts_Packaging;
            }
            if (requestArtifacts_artifacts_Packaging != null)
            {
                request.Artifacts.Packaging = requestArtifacts_artifacts_Packaging;
                requestArtifactsIsNull = false;
            }
            System.String requestArtifacts_artifacts_Path = null;
            if (cmdletContext.Artifacts_Path != null)
            {
                requestArtifacts_artifacts_Path = cmdletContext.Artifacts_Path;
            }
            if (requestArtifacts_artifacts_Path != null)
            {
                request.Artifacts.Path = requestArtifacts_artifacts_Path;
                requestArtifactsIsNull = false;
            }
            Amazon.CodeBuild.ArtifactsType requestArtifacts_artifacts_Type = null;
            if (cmdletContext.Artifacts_Type != null)
            {
                requestArtifacts_artifacts_Type = cmdletContext.Artifacts_Type;
            }
            if (requestArtifacts_artifacts_Type != null)
            {
                request.Artifacts.Type = requestArtifacts_artifacts_Type;
                requestArtifactsIsNull = false;
            }
             // determine if request.Artifacts should be set to null
            if (requestArtifactsIsNull)
            {
                request.Artifacts = null;
            }
            if (cmdletContext.AutoRetryLimit != null)
            {
                request.AutoRetryLimit = cmdletContext.AutoRetryLimit.Value;
            }
            if (cmdletContext.BadgeEnabled != null)
            {
                request.BadgeEnabled = cmdletContext.BadgeEnabled.Value;
            }
            
             // populate BuildBatchConfig
            var requestBuildBatchConfigIsNull = true;
            request.BuildBatchConfig = new Amazon.CodeBuild.Model.ProjectBuildBatchConfig();
            Amazon.CodeBuild.BatchReportModeType requestBuildBatchConfig_buildBatchConfig_BatchReportMode = null;
            if (cmdletContext.BuildBatchConfig_BatchReportMode != null)
            {
                requestBuildBatchConfig_buildBatchConfig_BatchReportMode = cmdletContext.BuildBatchConfig_BatchReportMode;
            }
            if (requestBuildBatchConfig_buildBatchConfig_BatchReportMode != null)
            {
                request.BuildBatchConfig.BatchReportMode = requestBuildBatchConfig_buildBatchConfig_BatchReportMode;
                requestBuildBatchConfigIsNull = false;
            }
            System.Boolean? requestBuildBatchConfig_buildBatchConfig_CombineArtifact = null;
            if (cmdletContext.BuildBatchConfig_CombineArtifact != null)
            {
                requestBuildBatchConfig_buildBatchConfig_CombineArtifact = cmdletContext.BuildBatchConfig_CombineArtifact.Value;
            }
            if (requestBuildBatchConfig_buildBatchConfig_CombineArtifact != null)
            {
                request.BuildBatchConfig.CombineArtifacts = requestBuildBatchConfig_buildBatchConfig_CombineArtifact.Value;
                requestBuildBatchConfigIsNull = false;
            }
            System.String requestBuildBatchConfig_buildBatchConfig_ServiceRole = null;
            if (cmdletContext.BuildBatchConfig_ServiceRole != null)
            {
                requestBuildBatchConfig_buildBatchConfig_ServiceRole = cmdletContext.BuildBatchConfig_ServiceRole;
            }
            if (requestBuildBatchConfig_buildBatchConfig_ServiceRole != null)
            {
                request.BuildBatchConfig.ServiceRole = requestBuildBatchConfig_buildBatchConfig_ServiceRole;
                requestBuildBatchConfigIsNull = false;
            }
            System.Int32? requestBuildBatchConfig_buildBatchConfig_TimeoutInMin = null;
            if (cmdletContext.BuildBatchConfig_TimeoutInMin != null)
            {
                requestBuildBatchConfig_buildBatchConfig_TimeoutInMin = cmdletContext.BuildBatchConfig_TimeoutInMin.Value;
            }
            if (requestBuildBatchConfig_buildBatchConfig_TimeoutInMin != null)
            {
                request.BuildBatchConfig.TimeoutInMins = requestBuildBatchConfig_buildBatchConfig_TimeoutInMin.Value;
                requestBuildBatchConfigIsNull = false;
            }
            Amazon.CodeBuild.Model.BatchRestrictions requestBuildBatchConfig_buildBatchConfig_Restrictions = null;
            
             // populate Restrictions
            var requestBuildBatchConfig_buildBatchConfig_RestrictionsIsNull = true;
            requestBuildBatchConfig_buildBatchConfig_Restrictions = new Amazon.CodeBuild.Model.BatchRestrictions();
            List<System.String> requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_ComputeTypesAllowed = null;
            if (cmdletContext.Restrictions_ComputeTypesAllowed != null)
            {
                requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_ComputeTypesAllowed = cmdletContext.Restrictions_ComputeTypesAllowed;
            }
            if (requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_ComputeTypesAllowed != null)
            {
                requestBuildBatchConfig_buildBatchConfig_Restrictions.ComputeTypesAllowed = requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_ComputeTypesAllowed;
                requestBuildBatchConfig_buildBatchConfig_RestrictionsIsNull = false;
            }
            List<System.String> requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_FleetsAllowed = null;
            if (cmdletContext.Restrictions_FleetsAllowed != null)
            {
                requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_FleetsAllowed = cmdletContext.Restrictions_FleetsAllowed;
            }
            if (requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_FleetsAllowed != null)
            {
                requestBuildBatchConfig_buildBatchConfig_Restrictions.FleetsAllowed = requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_FleetsAllowed;
                requestBuildBatchConfig_buildBatchConfig_RestrictionsIsNull = false;
            }
            System.Int32? requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_MaximumBuildsAllowed = null;
            if (cmdletContext.Restrictions_MaximumBuildsAllowed != null)
            {
                requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_MaximumBuildsAllowed = cmdletContext.Restrictions_MaximumBuildsAllowed.Value;
            }
            if (requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_MaximumBuildsAllowed != null)
            {
                requestBuildBatchConfig_buildBatchConfig_Restrictions.MaximumBuildsAllowed = requestBuildBatchConfig_buildBatchConfig_Restrictions_restrictions_MaximumBuildsAllowed.Value;
                requestBuildBatchConfig_buildBatchConfig_RestrictionsIsNull = false;
            }
             // determine if requestBuildBatchConfig_buildBatchConfig_Restrictions should be set to null
            if (requestBuildBatchConfig_buildBatchConfig_RestrictionsIsNull)
            {
                requestBuildBatchConfig_buildBatchConfig_Restrictions = null;
            }
            if (requestBuildBatchConfig_buildBatchConfig_Restrictions != null)
            {
                request.BuildBatchConfig.Restrictions = requestBuildBatchConfig_buildBatchConfig_Restrictions;
                requestBuildBatchConfigIsNull = false;
            }
             // determine if request.BuildBatchConfig should be set to null
            if (requestBuildBatchConfigIsNull)
            {
                request.BuildBatchConfig = null;
            }
            
             // populate Cache
            var requestCacheIsNull = true;
            request.Cache = new Amazon.CodeBuild.Model.ProjectCache();
            System.String requestCache_cache_CacheNamespace = null;
            if (cmdletContext.Cache_CacheNamespace != null)
            {
                requestCache_cache_CacheNamespace = cmdletContext.Cache_CacheNamespace;
            }
            if (requestCache_cache_CacheNamespace != null)
            {
                request.Cache.CacheNamespace = requestCache_cache_CacheNamespace;
                requestCacheIsNull = false;
            }
            System.String requestCache_cache_Location = null;
            if (cmdletContext.Cache_Location != null)
            {
                requestCache_cache_Location = cmdletContext.Cache_Location;
            }
            if (requestCache_cache_Location != null)
            {
                request.Cache.Location = requestCache_cache_Location;
                requestCacheIsNull = false;
            }
            List<System.String> requestCache_cache_Mode = null;
            if (cmdletContext.Cache_Mode != null)
            {
                requestCache_cache_Mode = cmdletContext.Cache_Mode;
            }
            if (requestCache_cache_Mode != null)
            {
                request.Cache.Modes = requestCache_cache_Mode;
                requestCacheIsNull = false;
            }
            Amazon.CodeBuild.CacheType requestCache_cache_Type = null;
            if (cmdletContext.Cache_Type != null)
            {
                requestCache_cache_Type = cmdletContext.Cache_Type;
            }
            if (requestCache_cache_Type != null)
            {
                request.Cache.Type = requestCache_cache_Type;
                requestCacheIsNull = false;
            }
             // determine if request.Cache should be set to null
            if (requestCacheIsNull)
            {
                request.Cache = null;
            }
            if (cmdletContext.ConcurrentBuildLimit != null)
            {
                request.ConcurrentBuildLimit = cmdletContext.ConcurrentBuildLimit.Value;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.EncryptionKey != null)
            {
                request.EncryptionKey = cmdletContext.EncryptionKey;
            }
            
             // populate Environment
            var requestEnvironmentIsNull = true;
            request.Environment = new Amazon.CodeBuild.Model.ProjectEnvironment();
            System.String requestEnvironment_environment_Certificate = null;
            if (cmdletContext.Environment_Certificate != null)
            {
                requestEnvironment_environment_Certificate = cmdletContext.Environment_Certificate;
            }
            if (requestEnvironment_environment_Certificate != null)
            {
                request.Environment.Certificate = requestEnvironment_environment_Certificate;
                requestEnvironmentIsNull = false;
            }
            Amazon.CodeBuild.ComputeType requestEnvironment_environment_ComputeType = null;
            if (cmdletContext.Environment_ComputeType != null)
            {
                requestEnvironment_environment_ComputeType = cmdletContext.Environment_ComputeType;
            }
            if (requestEnvironment_environment_ComputeType != null)
            {
                request.Environment.ComputeType = requestEnvironment_environment_ComputeType;
                requestEnvironmentIsNull = false;
            }
            List<Amazon.CodeBuild.Model.EnvironmentVariable> requestEnvironment_environment_EnvironmentVariable = null;
            if (cmdletContext.Environment_EnvironmentVariable != null)
            {
                requestEnvironment_environment_EnvironmentVariable = cmdletContext.Environment_EnvironmentVariable;
            }
            if (requestEnvironment_environment_EnvironmentVariable != null)
            {
                request.Environment.EnvironmentVariables = requestEnvironment_environment_EnvironmentVariable;
                requestEnvironmentIsNull = false;
            }
            System.String requestEnvironment_environment_Image = null;
            if (cmdletContext.Environment_Image != null)
            {
                requestEnvironment_environment_Image = cmdletContext.Environment_Image;
            }
            if (requestEnvironment_environment_Image != null)
            {
                request.Environment.Image = requestEnvironment_environment_Image;
                requestEnvironmentIsNull = false;
            }
            Amazon.CodeBuild.ImagePullCredentialsType requestEnvironment_environment_ImagePullCredentialsType = null;
            if (cmdletContext.Environment_ImagePullCredentialsType != null)
            {
                requestEnvironment_environment_ImagePullCredentialsType = cmdletContext.Environment_ImagePullCredentialsType;
            }
            if (requestEnvironment_environment_ImagePullCredentialsType != null)
            {
                request.Environment.ImagePullCredentialsType = requestEnvironment_environment_ImagePullCredentialsType;
                requestEnvironmentIsNull = false;
            }
            System.Boolean? requestEnvironment_environment_PrivilegedMode = null;
            if (cmdletContext.Environment_PrivilegedMode != null)
            {
                requestEnvironment_environment_PrivilegedMode = cmdletContext.Environment_PrivilegedMode.Value;
            }
            if (requestEnvironment_environment_PrivilegedMode != null)
            {
                request.Environment.PrivilegedMode = requestEnvironment_environment_PrivilegedMode.Value;
                requestEnvironmentIsNull = false;
            }
            Amazon.CodeBuild.EnvironmentType requestEnvironment_environment_Type = null;
            if (cmdletContext.Environment_Type != null)
            {
                requestEnvironment_environment_Type = cmdletContext.Environment_Type;
            }
            if (requestEnvironment_environment_Type != null)
            {
                request.Environment.Type = requestEnvironment_environment_Type;
                requestEnvironmentIsNull = false;
            }
            Amazon.CodeBuild.Model.ProjectFleet requestEnvironment_environment_Fleet = null;
            
             // populate Fleet
            var requestEnvironment_environment_FleetIsNull = true;
            requestEnvironment_environment_Fleet = new Amazon.CodeBuild.Model.ProjectFleet();
            System.String requestEnvironment_environment_Fleet_fleet_FleetArn = null;
            if (cmdletContext.Fleet_FleetArn != null)
            {
                requestEnvironment_environment_Fleet_fleet_FleetArn = cmdletContext.Fleet_FleetArn;
            }
            if (requestEnvironment_environment_Fleet_fleet_FleetArn != null)
            {
                requestEnvironment_environment_Fleet.FleetArn = requestEnvironment_environment_Fleet_fleet_FleetArn;
                requestEnvironment_environment_FleetIsNull = false;
            }
             // determine if requestEnvironment_environment_Fleet should be set to null
            if (requestEnvironment_environment_FleetIsNull)
            {
                requestEnvironment_environment_Fleet = null;
            }
            if (requestEnvironment_environment_Fleet != null)
            {
                request.Environment.Fleet = requestEnvironment_environment_Fleet;
                requestEnvironmentIsNull = false;
            }
            Amazon.CodeBuild.Model.RegistryCredential requestEnvironment_environment_RegistryCredential = null;
            
             // populate RegistryCredential
            var requestEnvironment_environment_RegistryCredentialIsNull = true;
            requestEnvironment_environment_RegistryCredential = new Amazon.CodeBuild.Model.RegistryCredential();
            System.String requestEnvironment_environment_RegistryCredential_registryCredential_Credential = null;
            if (cmdletContext.RegistryCredential_Credential != null)
            {
                requestEnvironment_environment_RegistryCredential_registryCredential_Credential = cmdletContext.RegistryCredential_Credential;
            }
            if (requestEnvironment_environment_RegistryCredential_registryCredential_Credential != null)
            {
                requestEnvironment_environment_RegistryCredential.Credential = requestEnvironment_environment_RegistryCredential_registryCredential_Credential;
                requestEnvironment_environment_RegistryCredentialIsNull = false;
            }
            Amazon.CodeBuild.CredentialProviderType requestEnvironment_environment_RegistryCredential_registryCredential_CredentialProvider = null;
            if (cmdletContext.RegistryCredential_CredentialProvider != null)
            {
                requestEnvironment_environment_RegistryCredential_registryCredential_CredentialProvider = cmdletContext.RegistryCredential_CredentialProvider;
            }
            if (requestEnvironment_environment_RegistryCredential_registryCredential_CredentialProvider != null)
            {
                requestEnvironment_environment_RegistryCredential.CredentialProvider = requestEnvironment_environment_RegistryCredential_registryCredential_CredentialProvider;
                requestEnvironment_environment_RegistryCredentialIsNull = false;
            }
             // determine if requestEnvironment_environment_RegistryCredential should be set to null
            if (requestEnvironment_environment_RegistryCredentialIsNull)
            {
                requestEnvironment_environment_RegistryCredential = null;
            }
            if (requestEnvironment_environment_RegistryCredential != null)
            {
                request.Environment.RegistryCredential = requestEnvironment_environment_RegistryCredential;
                requestEnvironmentIsNull = false;
            }
            Amazon.CodeBuild.Model.DockerServer requestEnvironment_environment_DockerServer = null;
            
             // populate DockerServer
            var requestEnvironment_environment_DockerServerIsNull = true;
            requestEnvironment_environment_DockerServer = new Amazon.CodeBuild.Model.DockerServer();
            Amazon.CodeBuild.ComputeType requestEnvironment_environment_DockerServer_dockerServer_ComputeType = null;
            if (cmdletContext.DockerServer_ComputeType != null)
            {
                requestEnvironment_environment_DockerServer_dockerServer_ComputeType = cmdletContext.DockerServer_ComputeType;
            }
            if (requestEnvironment_environment_DockerServer_dockerServer_ComputeType != null)
            {
                requestEnvironment_environment_DockerServer.ComputeType = requestEnvironment_environment_DockerServer_dockerServer_ComputeType;
                requestEnvironment_environment_DockerServerIsNull = false;
            }
            List<System.String> requestEnvironment_environment_DockerServer_dockerServer_SecurityGroupId = null;
            if (cmdletContext.DockerServer_SecurityGroupId != null)
            {
                requestEnvironment_environment_DockerServer_dockerServer_SecurityGroupId = cmdletContext.DockerServer_SecurityGroupId;
            }
            if (requestEnvironment_environment_DockerServer_dockerServer_SecurityGroupId != null)
            {
                requestEnvironment_environment_DockerServer.SecurityGroupIds = requestEnvironment_environment_DockerServer_dockerServer_SecurityGroupId;
                requestEnvironment_environment_DockerServerIsNull = false;
            }
            Amazon.CodeBuild.Model.DockerServerStatus requestEnvironment_environment_DockerServer_environment_DockerServer_Status = null;
            
             // populate Status
            var requestEnvironment_environment_DockerServer_environment_DockerServer_StatusIsNull = true;
            requestEnvironment_environment_DockerServer_environment_DockerServer_Status = new Amazon.CodeBuild.Model.DockerServerStatus();
            System.String requestEnvironment_environment_DockerServer_environment_DockerServer_Status_status_Message = null;
            if (cmdletContext.Status_Message != null)
            {
                requestEnvironment_environment_DockerServer_environment_DockerServer_Status_status_Message = cmdletContext.Status_Message;
            }
            if (requestEnvironment_environment_DockerServer_environment_DockerServer_Status_status_Message != null)
            {
                requestEnvironment_environment_DockerServer_environment_DockerServer_Status.Message = requestEnvironment_environment_DockerServer_environment_DockerServer_Status_status_Message;
                requestEnvironment_environment_DockerServer_environment_DockerServer_StatusIsNull = false;
            }
            System.String requestEnvironment_environment_DockerServer_environment_DockerServer_Status_status_Status = null;
            if (cmdletContext.Status_Status != null)
            {
                requestEnvironment_environment_DockerServer_environment_DockerServer_Status_status_Status = cmdletContext.Status_Status;
            }
            if (requestEnvironment_environment_DockerServer_environment_DockerServer_Status_status_Status != null)
            {
                requestEnvironment_environment_DockerServer_environment_DockerServer_Status.Status = requestEnvironment_environment_DockerServer_environment_DockerServer_Status_status_Status;
                requestEnvironment_environment_DockerServer_environment_DockerServer_StatusIsNull = false;
            }
             // determine if requestEnvironment_environment_DockerServer_environment_DockerServer_Status should be set to null
            if (requestEnvironment_environment_DockerServer_environment_DockerServer_StatusIsNull)
            {
                requestEnvironment_environment_DockerServer_environment_DockerServer_Status = null;
            }
            if (requestEnvironment_environment_DockerServer_environment_DockerServer_Status != null)
            {
                requestEnvironment_environment_DockerServer.Status = requestEnvironment_environment_DockerServer_environment_DockerServer_Status;
                requestEnvironment_environment_DockerServerIsNull = false;
            }
             // determine if requestEnvironment_environment_DockerServer should be set to null
            if (requestEnvironment_environment_DockerServerIsNull)
            {
                requestEnvironment_environment_DockerServer = null;
            }
            if (requestEnvironment_environment_DockerServer != null)
            {
                request.Environment.DockerServer = requestEnvironment_environment_DockerServer;
                requestEnvironmentIsNull = false;
            }
            Amazon.CodeBuild.Model.ComputeConfiguration requestEnvironment_environment_ComputeConfiguration = null;
            
             // populate ComputeConfiguration
            var requestEnvironment_environment_ComputeConfigurationIsNull = true;
            requestEnvironment_environment_ComputeConfiguration = new Amazon.CodeBuild.Model.ComputeConfiguration();
            System.Int64? requestEnvironment_environment_ComputeConfiguration_computeConfiguration_Disk = null;
            if (cmdletContext.ComputeConfiguration_Disk != null)
            {
                requestEnvironment_environment_ComputeConfiguration_computeConfiguration_Disk = cmdletContext.ComputeConfiguration_Disk.Value;
            }
            if (requestEnvironment_environment_ComputeConfiguration_computeConfiguration_Disk != null)
            {
                requestEnvironment_environment_ComputeConfiguration.Disk = requestEnvironment_environment_ComputeConfiguration_computeConfiguration_Disk.Value;
                requestEnvironment_environment_ComputeConfigurationIsNull = false;
            }
            System.String requestEnvironment_environment_ComputeConfiguration_computeConfiguration_InstanceType = null;
            if (cmdletContext.ComputeConfiguration_InstanceType != null)
            {
                requestEnvironment_environment_ComputeConfiguration_computeConfiguration_InstanceType = cmdletContext.ComputeConfiguration_InstanceType;
            }
            if (requestEnvironment_environment_ComputeConfiguration_computeConfiguration_InstanceType != null)
            {
                requestEnvironment_environment_ComputeConfiguration.InstanceType = requestEnvironment_environment_ComputeConfiguration_computeConfiguration_InstanceType;
                requestEnvironment_environment_ComputeConfigurationIsNull = false;
            }
            Amazon.CodeBuild.MachineType requestEnvironment_environment_ComputeConfiguration_computeConfiguration_MachineType = null;
            if (cmdletContext.ComputeConfiguration_MachineType != null)
            {
                requestEnvironment_environment_ComputeConfiguration_computeConfiguration_MachineType = cmdletContext.ComputeConfiguration_MachineType;
            }
            if (requestEnvironment_environment_ComputeConfiguration_computeConfiguration_MachineType != null)
            {
                requestEnvironment_environment_ComputeConfiguration.MachineType = requestEnvironment_environment_ComputeConfiguration_computeConfiguration_MachineType;
                requestEnvironment_environment_ComputeConfigurationIsNull = false;
            }
            System.Int64? requestEnvironment_environment_ComputeConfiguration_computeConfiguration_Memory = null;
            if (cmdletContext.ComputeConfiguration_Memory != null)
            {
                requestEnvironment_environment_ComputeConfiguration_computeConfiguration_Memory = cmdletContext.ComputeConfiguration_Memory.Value;
            }
            if (requestEnvironment_environment_ComputeConfiguration_computeConfiguration_Memory != null)
            {
                requestEnvironment_environment_ComputeConfiguration.Memory = requestEnvironment_environment_ComputeConfiguration_computeConfiguration_Memory.Value;
                requestEnvironment_environment_ComputeConfigurationIsNull = false;
            }
            System.Int64? requestEnvironment_environment_ComputeConfiguration_computeConfiguration_VCpu = null;
            if (cmdletContext.ComputeConfiguration_VCpu != null)
            {
                requestEnvironment_environment_ComputeConfiguration_computeConfiguration_VCpu = cmdletContext.ComputeConfiguration_VCpu.Value;
            }
            if (requestEnvironment_environment_ComputeConfiguration_computeConfiguration_VCpu != null)
            {
                requestEnvironment_environment_ComputeConfiguration.VCpu = requestEnvironment_environment_ComputeConfiguration_computeConfiguration_VCpu.Value;
                requestEnvironment_environment_ComputeConfigurationIsNull = false;
            }
             // determine if requestEnvironment_environment_ComputeConfiguration should be set to null
            if (requestEnvironment_environment_ComputeConfigurationIsNull)
            {
                requestEnvironment_environment_ComputeConfiguration = null;
            }
            if (requestEnvironment_environment_ComputeConfiguration != null)
            {
                request.Environment.ComputeConfiguration = requestEnvironment_environment_ComputeConfiguration;
                requestEnvironmentIsNull = false;
            }
             // determine if request.Environment should be set to null
            if (requestEnvironmentIsNull)
            {
                request.Environment = null;
            }
            if (cmdletContext.FileSystemLocation != null)
            {
                request.FileSystemLocations = cmdletContext.FileSystemLocation;
            }
            
             // populate LogsConfig
            var requestLogsConfigIsNull = true;
            request.LogsConfig = new Amazon.CodeBuild.Model.LogsConfig();
            Amazon.CodeBuild.Model.CloudWatchLogsConfig requestLogsConfig_logsConfig_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLogsConfig_logsConfig_CloudWatchLogsIsNull = true;
            requestLogsConfig_logsConfig_CloudWatchLogs = new Amazon.CodeBuild.Model.CloudWatchLogsConfig();
            System.String requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_GroupName = null;
            if (cmdletContext.CloudWatchLogs_GroupName != null)
            {
                requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_GroupName = cmdletContext.CloudWatchLogs_GroupName;
            }
            if (requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_GroupName != null)
            {
                requestLogsConfig_logsConfig_CloudWatchLogs.GroupName = requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_GroupName;
                requestLogsConfig_logsConfig_CloudWatchLogsIsNull = false;
            }
            Amazon.CodeBuild.LogsConfigStatusType requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_Status = null;
            if (cmdletContext.CloudWatchLogs_Status != null)
            {
                requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_Status = cmdletContext.CloudWatchLogs_Status;
            }
            if (requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_Status != null)
            {
                requestLogsConfig_logsConfig_CloudWatchLogs.Status = requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_Status;
                requestLogsConfig_logsConfig_CloudWatchLogsIsNull = false;
            }
            System.String requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_StreamName = null;
            if (cmdletContext.CloudWatchLogs_StreamName != null)
            {
                requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_StreamName = cmdletContext.CloudWatchLogs_StreamName;
            }
            if (requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_StreamName != null)
            {
                requestLogsConfig_logsConfig_CloudWatchLogs.StreamName = requestLogsConfig_logsConfig_CloudWatchLogs_cloudWatchLogs_StreamName;
                requestLogsConfig_logsConfig_CloudWatchLogsIsNull = false;
            }
             // determine if requestLogsConfig_logsConfig_CloudWatchLogs should be set to null
            if (requestLogsConfig_logsConfig_CloudWatchLogsIsNull)
            {
                requestLogsConfig_logsConfig_CloudWatchLogs = null;
            }
            if (requestLogsConfig_logsConfig_CloudWatchLogs != null)
            {
                request.LogsConfig.CloudWatchLogs = requestLogsConfig_logsConfig_CloudWatchLogs;
                requestLogsConfigIsNull = false;
            }
            Amazon.CodeBuild.Model.S3LogsConfig requestLogsConfig_logsConfig_S3Logs = null;
            
             // populate S3Logs
            var requestLogsConfig_logsConfig_S3LogsIsNull = true;
            requestLogsConfig_logsConfig_S3Logs = new Amazon.CodeBuild.Model.S3LogsConfig();
            Amazon.CodeBuild.BucketOwnerAccess requestLogsConfig_logsConfig_S3Logs_s3Logs_BucketOwnerAccess = null;
            if (cmdletContext.S3Logs_BucketOwnerAccess != null)
            {
                requestLogsConfig_logsConfig_S3Logs_s3Logs_BucketOwnerAccess = cmdletContext.S3Logs_BucketOwnerAccess;
            }
            if (requestLogsConfig_logsConfig_S3Logs_s3Logs_BucketOwnerAccess != null)
            {
                requestLogsConfig_logsConfig_S3Logs.BucketOwnerAccess = requestLogsConfig_logsConfig_S3Logs_s3Logs_BucketOwnerAccess;
                requestLogsConfig_logsConfig_S3LogsIsNull = false;
            }
            System.Boolean? requestLogsConfig_logsConfig_S3Logs_s3Logs_EncryptionDisabled = null;
            if (cmdletContext.S3Logs_EncryptionDisabled != null)
            {
                requestLogsConfig_logsConfig_S3Logs_s3Logs_EncryptionDisabled = cmdletContext.S3Logs_EncryptionDisabled.Value;
            }
            if (requestLogsConfig_logsConfig_S3Logs_s3Logs_EncryptionDisabled != null)
            {
                requestLogsConfig_logsConfig_S3Logs.EncryptionDisabled = requestLogsConfig_logsConfig_S3Logs_s3Logs_EncryptionDisabled.Value;
                requestLogsConfig_logsConfig_S3LogsIsNull = false;
            }
            System.String requestLogsConfig_logsConfig_S3Logs_s3Logs_Location = null;
            if (cmdletContext.S3Logs_Location != null)
            {
                requestLogsConfig_logsConfig_S3Logs_s3Logs_Location = cmdletContext.S3Logs_Location;
            }
            if (requestLogsConfig_logsConfig_S3Logs_s3Logs_Location != null)
            {
                requestLogsConfig_logsConfig_S3Logs.Location = requestLogsConfig_logsConfig_S3Logs_s3Logs_Location;
                requestLogsConfig_logsConfig_S3LogsIsNull = false;
            }
            Amazon.CodeBuild.LogsConfigStatusType requestLogsConfig_logsConfig_S3Logs_s3Logs_Status = null;
            if (cmdletContext.S3Logs_Status != null)
            {
                requestLogsConfig_logsConfig_S3Logs_s3Logs_Status = cmdletContext.S3Logs_Status;
            }
            if (requestLogsConfig_logsConfig_S3Logs_s3Logs_Status != null)
            {
                requestLogsConfig_logsConfig_S3Logs.Status = requestLogsConfig_logsConfig_S3Logs_s3Logs_Status;
                requestLogsConfig_logsConfig_S3LogsIsNull = false;
            }
             // determine if requestLogsConfig_logsConfig_S3Logs should be set to null
            if (requestLogsConfig_logsConfig_S3LogsIsNull)
            {
                requestLogsConfig_logsConfig_S3Logs = null;
            }
            if (requestLogsConfig_logsConfig_S3Logs != null)
            {
                request.LogsConfig.S3Logs = requestLogsConfig_logsConfig_S3Logs;
                requestLogsConfigIsNull = false;
            }
             // determine if request.LogsConfig should be set to null
            if (requestLogsConfigIsNull)
            {
                request.LogsConfig = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.QueuedTimeoutInMinute != null)
            {
                request.QueuedTimeoutInMinutes = cmdletContext.QueuedTimeoutInMinute.Value;
            }
            if (cmdletContext.SecondaryArtifact != null)
            {
                request.SecondaryArtifacts = cmdletContext.SecondaryArtifact;
            }
            if (cmdletContext.SecondarySource != null)
            {
                request.SecondarySources = cmdletContext.SecondarySource;
            }
            if (cmdletContext.SecondarySourceVersion != null)
            {
                request.SecondarySourceVersions = cmdletContext.SecondarySourceVersion;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            
             // populate Source
            var requestSourceIsNull = true;
            request.Source = new Amazon.CodeBuild.Model.ProjectSource();
            System.String requestSource_source_Buildspec = null;
            if (cmdletContext.Source_Buildspec != null)
            {
                requestSource_source_Buildspec = cmdletContext.Source_Buildspec;
            }
            if (requestSource_source_Buildspec != null)
            {
                request.Source.Buildspec = requestSource_source_Buildspec;
                requestSourceIsNull = false;
            }
            System.Int32? requestSource_source_GitCloneDepth = null;
            if (cmdletContext.Source_GitCloneDepth != null)
            {
                requestSource_source_GitCloneDepth = cmdletContext.Source_GitCloneDepth.Value;
            }
            if (requestSource_source_GitCloneDepth != null)
            {
                request.Source.GitCloneDepth = requestSource_source_GitCloneDepth.Value;
                requestSourceIsNull = false;
            }
            System.Boolean? requestSource_source_InsecureSsl = null;
            if (cmdletContext.Source_InsecureSsl != null)
            {
                requestSource_source_InsecureSsl = cmdletContext.Source_InsecureSsl.Value;
            }
            if (requestSource_source_InsecureSsl != null)
            {
                request.Source.InsecureSsl = requestSource_source_InsecureSsl.Value;
                requestSourceIsNull = false;
            }
            System.String requestSource_source_Location = null;
            if (cmdletContext.Source_Location != null)
            {
                requestSource_source_Location = cmdletContext.Source_Location;
            }
            if (requestSource_source_Location != null)
            {
                request.Source.Location = requestSource_source_Location;
                requestSourceIsNull = false;
            }
            System.Boolean? requestSource_source_ReportBuildStatus = null;
            if (cmdletContext.Source_ReportBuildStatus != null)
            {
                requestSource_source_ReportBuildStatus = cmdletContext.Source_ReportBuildStatus.Value;
            }
            if (requestSource_source_ReportBuildStatus != null)
            {
                request.Source.ReportBuildStatus = requestSource_source_ReportBuildStatus.Value;
                requestSourceIsNull = false;
            }
            System.String requestSource_source_SourceIdentifier = null;
            if (cmdletContext.Source_SourceIdentifier != null)
            {
                requestSource_source_SourceIdentifier = cmdletContext.Source_SourceIdentifier;
            }
            if (requestSource_source_SourceIdentifier != null)
            {
                request.Source.SourceIdentifier = requestSource_source_SourceIdentifier;
                requestSourceIsNull = false;
            }
            Amazon.CodeBuild.SourceType requestSource_source_Type = null;
            if (cmdletContext.Source_Type != null)
            {
                requestSource_source_Type = cmdletContext.Source_Type;
            }
            if (requestSource_source_Type != null)
            {
                request.Source.Type = requestSource_source_Type;
                requestSourceIsNull = false;
            }
            Amazon.CodeBuild.Model.GitSubmodulesConfig requestSource_source_GitSubmodulesConfig = null;
            
             // populate GitSubmodulesConfig
            var requestSource_source_GitSubmodulesConfigIsNull = true;
            requestSource_source_GitSubmodulesConfig = new Amazon.CodeBuild.Model.GitSubmodulesConfig();
            System.Boolean? requestSource_source_GitSubmodulesConfig_gitSubmodulesConfig_FetchSubmodule = null;
            if (cmdletContext.GitSubmodulesConfig_FetchSubmodule != null)
            {
                requestSource_source_GitSubmodulesConfig_gitSubmodulesConfig_FetchSubmodule = cmdletContext.GitSubmodulesConfig_FetchSubmodule.Value;
            }
            if (requestSource_source_GitSubmodulesConfig_gitSubmodulesConfig_FetchSubmodule != null)
            {
                requestSource_source_GitSubmodulesConfig.FetchSubmodules = requestSource_source_GitSubmodulesConfig_gitSubmodulesConfig_FetchSubmodule.Value;
                requestSource_source_GitSubmodulesConfigIsNull = false;
            }
             // determine if requestSource_source_GitSubmodulesConfig should be set to null
            if (requestSource_source_GitSubmodulesConfigIsNull)
            {
                requestSource_source_GitSubmodulesConfig = null;
            }
            if (requestSource_source_GitSubmodulesConfig != null)
            {
                request.Source.GitSubmodulesConfig = requestSource_source_GitSubmodulesConfig;
                requestSourceIsNull = false;
            }
            Amazon.CodeBuild.Model.SourceAuth requestSource_source_Auth = null;
            
             // populate Auth
            var requestSource_source_AuthIsNull = true;
            requestSource_source_Auth = new Amazon.CodeBuild.Model.SourceAuth();
            System.String requestSource_source_Auth_auth_Resource = null;
            if (cmdletContext.Auth_Resource != null)
            {
                requestSource_source_Auth_auth_Resource = cmdletContext.Auth_Resource;
            }
            if (requestSource_source_Auth_auth_Resource != null)
            {
                requestSource_source_Auth.Resource = requestSource_source_Auth_auth_Resource;
                requestSource_source_AuthIsNull = false;
            }
            Amazon.CodeBuild.SourceAuthType requestSource_source_Auth_auth_Type = null;
            if (cmdletContext.Auth_Type != null)
            {
                requestSource_source_Auth_auth_Type = cmdletContext.Auth_Type;
            }
            if (requestSource_source_Auth_auth_Type != null)
            {
                requestSource_source_Auth.Type = requestSource_source_Auth_auth_Type;
                requestSource_source_AuthIsNull = false;
            }
             // determine if requestSource_source_Auth should be set to null
            if (requestSource_source_AuthIsNull)
            {
                requestSource_source_Auth = null;
            }
            if (requestSource_source_Auth != null)
            {
                request.Source.Auth = requestSource_source_Auth;
                requestSourceIsNull = false;
            }
            Amazon.CodeBuild.Model.BuildStatusConfig requestSource_source_BuildStatusConfig = null;
            
             // populate BuildStatusConfig
            var requestSource_source_BuildStatusConfigIsNull = true;
            requestSource_source_BuildStatusConfig = new Amazon.CodeBuild.Model.BuildStatusConfig();
            System.String requestSource_source_BuildStatusConfig_buildStatusConfig_Context = null;
            if (cmdletContext.BuildStatusConfig_Context != null)
            {
                requestSource_source_BuildStatusConfig_buildStatusConfig_Context = cmdletContext.BuildStatusConfig_Context;
            }
            if (requestSource_source_BuildStatusConfig_buildStatusConfig_Context != null)
            {
                requestSource_source_BuildStatusConfig.Context = requestSource_source_BuildStatusConfig_buildStatusConfig_Context;
                requestSource_source_BuildStatusConfigIsNull = false;
            }
            System.String requestSource_source_BuildStatusConfig_buildStatusConfig_TargetUrl = null;
            if (cmdletContext.BuildStatusConfig_TargetUrl != null)
            {
                requestSource_source_BuildStatusConfig_buildStatusConfig_TargetUrl = cmdletContext.BuildStatusConfig_TargetUrl;
            }
            if (requestSource_source_BuildStatusConfig_buildStatusConfig_TargetUrl != null)
            {
                requestSource_source_BuildStatusConfig.TargetUrl = requestSource_source_BuildStatusConfig_buildStatusConfig_TargetUrl;
                requestSource_source_BuildStatusConfigIsNull = false;
            }
             // determine if requestSource_source_BuildStatusConfig should be set to null
            if (requestSource_source_BuildStatusConfigIsNull)
            {
                requestSource_source_BuildStatusConfig = null;
            }
            if (requestSource_source_BuildStatusConfig != null)
            {
                request.Source.BuildStatusConfig = requestSource_source_BuildStatusConfig;
                requestSourceIsNull = false;
            }
             // determine if request.Source should be set to null
            if (requestSourceIsNull)
            {
                request.Source = null;
            }
            if (cmdletContext.SourceVersion != null)
            {
                request.SourceVersion = cmdletContext.SourceVersion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            if (cmdletContext.TimeoutInMinute != null)
            {
                request.TimeoutInMinutes = cmdletContext.TimeoutInMinute.Value;
            }
            
             // populate VpcConfig
            var requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.CodeBuild.Model.VpcConfig();
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
            List<System.String> requestVpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnet != null)
            {
                requestVpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnet;
            }
            if (requestVpcConfig_vpcConfig_Subnet != null)
            {
                request.VpcConfig.Subnets = requestVpcConfig_vpcConfig_Subnet;
                requestVpcConfigIsNull = false;
            }
            System.String requestVpcConfig_vpcConfig_VpcId = null;
            if (cmdletContext.VpcConfig_VpcId != null)
            {
                requestVpcConfig_vpcConfig_VpcId = cmdletContext.VpcConfig_VpcId;
            }
            if (requestVpcConfig_vpcConfig_VpcId != null)
            {
                request.VpcConfig.VpcId = requestVpcConfig_vpcConfig_VpcId;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CodeBuild.Model.UpdateProjectResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.UpdateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "UpdateProject");
            try
            {
                return client.UpdateProjectAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Artifacts_ArtifactIdentifier { get; set; }
            public Amazon.CodeBuild.BucketOwnerAccess Artifacts_BucketOwnerAccess { get; set; }
            public System.Boolean? Artifacts_EncryptionDisabled { get; set; }
            public System.String Artifacts_Location { get; set; }
            public System.String Artifacts_Name { get; set; }
            public Amazon.CodeBuild.ArtifactNamespace Artifacts_NamespaceType { get; set; }
            public System.Boolean? Artifacts_OverrideArtifactName { get; set; }
            public Amazon.CodeBuild.ArtifactPackaging Artifacts_Packaging { get; set; }
            public System.String Artifacts_Path { get; set; }
            public Amazon.CodeBuild.ArtifactsType Artifacts_Type { get; set; }
            public System.Int32? AutoRetryLimit { get; set; }
            public System.Boolean? BadgeEnabled { get; set; }
            public Amazon.CodeBuild.BatchReportModeType BuildBatchConfig_BatchReportMode { get; set; }
            public System.Boolean? BuildBatchConfig_CombineArtifact { get; set; }
            public List<System.String> Restrictions_ComputeTypesAllowed { get; set; }
            public List<System.String> Restrictions_FleetsAllowed { get; set; }
            public System.Int32? Restrictions_MaximumBuildsAllowed { get; set; }
            public System.String BuildBatchConfig_ServiceRole { get; set; }
            public System.Int32? BuildBatchConfig_TimeoutInMin { get; set; }
            public System.String Cache_CacheNamespace { get; set; }
            public System.String Cache_Location { get; set; }
            public List<System.String> Cache_Mode { get; set; }
            public Amazon.CodeBuild.CacheType Cache_Type { get; set; }
            public System.Int32? ConcurrentBuildLimit { get; set; }
            public System.String Description { get; set; }
            public System.String EncryptionKey { get; set; }
            public System.String Environment_Certificate { get; set; }
            public System.Int64? ComputeConfiguration_Disk { get; set; }
            public System.String ComputeConfiguration_InstanceType { get; set; }
            public Amazon.CodeBuild.MachineType ComputeConfiguration_MachineType { get; set; }
            public System.Int64? ComputeConfiguration_Memory { get; set; }
            public System.Int64? ComputeConfiguration_VCpu { get; set; }
            public Amazon.CodeBuild.ComputeType Environment_ComputeType { get; set; }
            public Amazon.CodeBuild.ComputeType DockerServer_ComputeType { get; set; }
            public List<System.String> DockerServer_SecurityGroupId { get; set; }
            public System.String Status_Message { get; set; }
            public System.String Status_Status { get; set; }
            public List<Amazon.CodeBuild.Model.EnvironmentVariable> Environment_EnvironmentVariable { get; set; }
            public System.String Fleet_FleetArn { get; set; }
            public System.String Environment_Image { get; set; }
            public Amazon.CodeBuild.ImagePullCredentialsType Environment_ImagePullCredentialsType { get; set; }
            public System.Boolean? Environment_PrivilegedMode { get; set; }
            public System.String RegistryCredential_Credential { get; set; }
            public Amazon.CodeBuild.CredentialProviderType RegistryCredential_CredentialProvider { get; set; }
            public Amazon.CodeBuild.EnvironmentType Environment_Type { get; set; }
            public List<Amazon.CodeBuild.Model.ProjectFileSystemLocation> FileSystemLocation { get; set; }
            public System.String CloudWatchLogs_GroupName { get; set; }
            public Amazon.CodeBuild.LogsConfigStatusType CloudWatchLogs_Status { get; set; }
            public System.String CloudWatchLogs_StreamName { get; set; }
            public Amazon.CodeBuild.BucketOwnerAccess S3Logs_BucketOwnerAccess { get; set; }
            public System.Boolean? S3Logs_EncryptionDisabled { get; set; }
            public System.String S3Logs_Location { get; set; }
            public Amazon.CodeBuild.LogsConfigStatusType S3Logs_Status { get; set; }
            public System.String Name { get; set; }
            public System.Int32? QueuedTimeoutInMinute { get; set; }
            public List<Amazon.CodeBuild.Model.ProjectArtifacts> SecondaryArtifact { get; set; }
            public List<Amazon.CodeBuild.Model.ProjectSource> SecondarySource { get; set; }
            public List<Amazon.CodeBuild.Model.ProjectSourceVersion> SecondarySourceVersion { get; set; }
            public System.String ServiceRole { get; set; }
            public System.String Auth_Resource { get; set; }
            public Amazon.CodeBuild.SourceAuthType Auth_Type { get; set; }
            public System.String Source_Buildspec { get; set; }
            public System.String BuildStatusConfig_Context { get; set; }
            public System.String BuildStatusConfig_TargetUrl { get; set; }
            public System.Int32? Source_GitCloneDepth { get; set; }
            public System.Boolean? GitSubmodulesConfig_FetchSubmodule { get; set; }
            public System.Boolean? Source_InsecureSsl { get; set; }
            public System.String Source_Location { get; set; }
            public System.Boolean? Source_ReportBuildStatus { get; set; }
            public System.String Source_SourceIdentifier { get; set; }
            public Amazon.CodeBuild.SourceType Source_Type { get; set; }
            public System.String SourceVersion { get; set; }
            public List<Amazon.CodeBuild.Model.Tag> Tag { get; set; }
            public System.Int32? TimeoutInMinute { get; set; }
            public List<System.String> VpcConfig_SecurityGroupId { get; set; }
            public List<System.String> VpcConfig_Subnet { get; set; }
            public System.String VpcConfig_VpcId { get; set; }
            public System.Func<Amazon.CodeBuild.Model.UpdateProjectResponse, UpdateCBProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Project;
        }
        
    }
}
