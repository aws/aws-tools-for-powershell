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
using Amazon.CodeBuild;
using Amazon.CodeBuild.Model;

namespace Amazon.PowerShell.Cmdlets.CB
{
    /// <summary>
    /// Starts a batch build for a project.
    /// </summary>
    [Cmdlet("Start", "CBBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.BuildBatch")]
    [AWSCmdlet("Calls the AWS CodeBuild StartBuildBatch API operation.", Operation = new[] {"StartBuildBatch"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.StartBuildBatchResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.BuildBatch or Amazon.CodeBuild.Model.StartBuildBatchResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.BuildBatch object.",
        "The service call response (type Amazon.CodeBuild.Model.StartBuildBatchResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCBBatchCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ArtifactsOverride_ArtifactIdentifier
        /// <summary>
        /// <para>
        /// <para> An identifier for this artifact definition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArtifactsOverride_ArtifactIdentifier { get; set; }
        #endregion
        
        #region Parameter BuildBatchConfigOverride_BatchReportMode
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
        public Amazon.CodeBuild.BatchReportModeType BuildBatchConfigOverride_BatchReportMode { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_BucketOwnerAccess
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.BucketOwnerAccess")]
        public Amazon.CodeBuild.BucketOwnerAccess ArtifactsOverride_BucketOwnerAccess { get; set; }
        #endregion
        
        #region Parameter S3Logs_BucketOwnerAccess
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfigOverride_S3Logs_BucketOwnerAccess")]
        [AWSConstantClassSource("Amazon.CodeBuild.BucketOwnerAccess")]
        public Amazon.CodeBuild.BucketOwnerAccess S3Logs_BucketOwnerAccess { get; set; }
        #endregion
        
        #region Parameter BuildspecOverride
        /// <summary>
        /// <para>
        /// <para>A buildspec file declaration that overrides, for this build only, the latest one already
        /// defined in the build project.</para><para>If this value is set, it can be either an inline buildspec definition, the path to
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
        public System.String BuildspecOverride { get; set; }
        #endregion
        
        #region Parameter BuildTimeoutInMinutesOverride
        /// <summary>
        /// <para>
        /// <para>Overrides the build timeout specified in the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? BuildTimeoutInMinutesOverride { get; set; }
        #endregion
        
        #region Parameter CertificateOverride
        /// <summary>
        /// <para>
        /// <para>The name of a certificate for this batch build that overrides the one specified in
        /// the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CertificateOverride { get; set; }
        #endregion
        
        #region Parameter BuildBatchConfigOverride_CombineArtifact
        /// <summary>
        /// <para>
        /// <para>Specifies if the build artifacts for the batch build should be combined into a single
        /// artifact location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildBatchConfigOverride_CombineArtifacts")]
        public System.Boolean? BuildBatchConfigOverride_CombineArtifact { get; set; }
        #endregion
        
        #region Parameter ComputeTypeOverride
        /// <summary>
        /// <para>
        /// <para>The name of a compute type for this batch build that overrides the one specified in
        /// the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ComputeType")]
        public Amazon.CodeBuild.ComputeType ComputeTypeOverride { get; set; }
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
        [Alias("BuildBatchConfigOverride_Restrictions_ComputeTypesAllowed")]
        public System.String[] Restrictions_ComputeTypesAllowed { get; set; }
        #endregion
        
        #region Parameter RegistryCredentialOverride_Credential
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) or name of credentials created using Secrets Manager.
        /// </para><note><para> The <c>credential</c> can use the name of the credentials only if they exist in your
        /// current Amazon Web Services Region. </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryCredentialOverride_Credential { get; set; }
        #endregion
        
        #region Parameter RegistryCredentialOverride_CredentialProvider
        /// <summary>
        /// <para>
        /// <para> The service that created the credentials to access a private Docker registry. The
        /// valid value, SECRETS_MANAGER, is for Secrets Manager. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.CredentialProviderType")]
        public Amazon.CodeBuild.CredentialProviderType RegistryCredentialOverride_CredentialProvider { get; set; }
        #endregion
        
        #region Parameter DebugSessionEnabled
        /// <summary>
        /// <para>
        /// <para>Specifies if session debugging is enabled for this batch build. For more information,
        /// see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/session-manager.html">Viewing
        /// a running build in Session Manager</a>. Batch session debugging is not supported for
        /// matrix batch builds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? DebugSessionEnabled { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_EncryptionDisabled
        /// <summary>
        /// <para>
        /// <para> Set to true if you do not want your output artifacts encrypted. This option is valid
        /// only if your artifacts type is Amazon S3. If this is set with another artifacts type,
        /// an invalidInputException is thrown. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ArtifactsOverride_EncryptionDisabled { get; set; }
        #endregion
        
        #region Parameter S3Logs_EncryptionDisabled
        /// <summary>
        /// <para>
        /// <para> Set to true if you do not want your S3 build log output encrypted. By default S3
        /// build logs are encrypted. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfigOverride_S3Logs_EncryptionDisabled")]
        public System.Boolean? S3Logs_EncryptionDisabled { get; set; }
        #endregion
        
        #region Parameter EncryptionKeyOverride
        /// <summary>
        /// <para>
        /// <para>The Key Management Service customer master key (CMK) that overrides the one specified
        /// in the batch build project. The CMK key encrypts the build output artifacts.</para><note><para>You can use a cross-account KMS key to encrypt the build output artifacts if your
        /// service role has permission to that key. </para></note><para>You can specify either the Amazon Resource Name (ARN) of the CMK or, if available,
        /// the CMK's alias (using the format <c>alias/&lt;alias-name&gt;</c>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String EncryptionKeyOverride { get; set; }
        #endregion
        
        #region Parameter EnvironmentTypeOverride
        /// <summary>
        /// <para>
        /// <para>A container type for this batch build that overrides the one specified in the batch
        /// build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.EnvironmentType")]
        public Amazon.CodeBuild.EnvironmentType EnvironmentTypeOverride { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariablesOverride
        /// <summary>
        /// <para>
        /// <para>An array of <c>EnvironmentVariable</c> objects that override, or add to, the environment
        /// variables defined in the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeBuild.Model.EnvironmentVariable[] EnvironmentVariablesOverride { get; set; }
        #endregion
        
        #region Parameter GitSubmodulesConfigOverride_FetchSubmodule
        /// <summary>
        /// <para>
        /// <para> Set to true to fetch Git submodules for your CodeBuild build project. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("GitSubmodulesConfigOverride_FetchSubmodules")]
        public System.Boolean? GitSubmodulesConfigOverride_FetchSubmodule { get; set; }
        #endregion
        
        #region Parameter GitCloneDepthOverride
        /// <summary>
        /// <para>
        /// <para>The user-defined depth of history, with a minimum value of 0, that overrides, for
        /// this batch build only, any previous depth of history defined in the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? GitCloneDepthOverride { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_GroupName
        /// <summary>
        /// <para>
        /// <para> The group name of the logs in CloudWatch Logs. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/Working-with-log-groups-and-streams.html">Working
        /// with Log Groups and Log Streams</a>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfigOverride_CloudWatchLogs_GroupName")]
        public System.String CloudWatchLogs_GroupName { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case sensitive identifier you provide to ensure the idempotency of the <c>StartBuildBatch</c>
        /// request. The token is included in the <c>StartBuildBatch</c> request and is valid
        /// for five minutes. If you repeat the <c>StartBuildBatch</c> request with the same token,
        /// but change a parameter, CodeBuild returns a parameter mismatch error.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter ImageOverride
        /// <summary>
        /// <para>
        /// <para>The name of an image for this batch build that overrides the one specified in the
        /// batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageOverride { get; set; }
        #endregion
        
        #region Parameter ImagePullCredentialsTypeOverride
        /// <summary>
        /// <para>
        /// <para>The type of credentials CodeBuild uses to pull images in your batch build. There are
        /// two valid values: </para><dl><dt>CODEBUILD</dt><dd><para>Specifies that CodeBuild uses its own credentials. This requires that you modify your
        /// ECR repository policy to trust CodeBuild's service principal.</para></dd><dt>SERVICE_ROLE</dt><dd><para>Specifies that CodeBuild uses your build project's service role. </para></dd></dl><para>When using a cross-account or private registry image, you must use <c>SERVICE_ROLE</c>
        /// credentials. When using an CodeBuild curated image, you must use <c>CODEBUILD</c>
        /// credentials. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ImagePullCredentialsType")]
        public Amazon.CodeBuild.ImagePullCredentialsType ImagePullCredentialsTypeOverride { get; set; }
        #endregion
        
        #region Parameter InsecureSslOverride
        /// <summary>
        /// <para>
        /// <para>Enable this flag to override the insecure SSL setting that is specified in the batch
        /// build project. The insecure SSL setting determines whether to ignore SSL warnings
        /// while connecting to the project source code. This override applies only if the build's
        /// source is GitHub Enterprise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? InsecureSslOverride { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Location
        /// <summary>
        /// <para>
        /// <para>Information about the build output artifact location:</para><ul><li><para>If <c>type</c> is set to <c>CODEPIPELINE</c>, CodePipeline ignores this value if specified.
        /// This is because CodePipeline manages its build output locations instead of CodeBuild.</para></li><li><para>If <c>type</c> is set to <c>NO_ARTIFACTS</c>, this value is ignored if specified,
        /// because no build output is produced.</para></li><li><para>If <c>type</c> is set to <c>S3</c>, this is the name of the output bucket.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ArtifactsOverride_Location { get; set; }
        #endregion
        
        #region Parameter CacheOverride_Location
        /// <summary>
        /// <para>
        /// <para>Information about the cache location: </para><ul><li><para><c>NO_CACHE</c> or <c>LOCAL</c>: This value is ignored.</para></li><li><para><c>S3</c>: This is the S3 bucket name/prefix.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CacheOverride_Location { get; set; }
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
        [Alias("LogsConfigOverride_S3Logs_Location")]
        public System.String S3Logs_Location { get; set; }
        #endregion
        
        #region Parameter Restrictions_MaximumBuildsAllowed
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum number of builds allowed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildBatchConfigOverride_Restrictions_MaximumBuildsAllowed")]
        public System.Int32? Restrictions_MaximumBuildsAllowed { get; set; }
        #endregion
        
        #region Parameter CacheOverride_Mode
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
        [Alias("CacheOverride_Modes")]
        public System.String[] CacheOverride_Mode { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Name
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
        public System.String ArtifactsOverride_Name { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_NamespaceType
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
        public Amazon.CodeBuild.ArtifactNamespace ArtifactsOverride_NamespaceType { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_OverrideArtifactName
        /// <summary>
        /// <para>
        /// <para> If this flag is set, a name specified in the buildspec file overrides the artifact
        /// name. The name specified in a buildspec file is calculated at build time and uses
        /// the Shell Command Language. For example, you can append a date and time to your artifact
        /// name so that it is always unique. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ArtifactsOverride_OverrideArtifactName { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Packaging
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
        public Amazon.CodeBuild.ArtifactPackaging ArtifactsOverride_Packaging { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Path
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
        public System.String ArtifactsOverride_Path { get; set; }
        #endregion
        
        #region Parameter PrivilegedModeOverride
        /// <summary>
        /// <para>
        /// <para>Enable this flag to override privileged mode in the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? PrivilegedModeOverride { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the project.</para>
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
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter QueuedTimeoutInMinutesOverride
        /// <summary>
        /// <para>
        /// <para>The number of minutes a batch build is allowed to be queued before it times out.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? QueuedTimeoutInMinutesOverride { get; set; }
        #endregion
        
        #region Parameter ReportBuildBatchStatusOverride
        /// <summary>
        /// <para>
        /// <para>Set to <c>true</c> to report to your source provider the status of a batch build's
        /// start and completion. If you use this option with a source provider other than GitHub,
        /// GitHub Enterprise, or Bitbucket, an <c>invalidInputException</c> is thrown. </para><note><para>The status of a build triggered by a webhook is always reported to your source provider.
        /// </para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ReportBuildBatchStatusOverride { get; set; }
        #endregion
        
        #region Parameter SourceAuthOverride_Resource
        /// <summary>
        /// <para>
        /// <para>The resource value that applies to the specified authorization type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceAuthOverride_Resource { get; set; }
        #endregion
        
        #region Parameter SecondaryArtifactsOverride
        /// <summary>
        /// <para>
        /// <para>An array of <c>ProjectArtifacts</c> objects that override the secondary artifacts
        /// defined in the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeBuild.Model.ProjectArtifacts[] SecondaryArtifactsOverride { get; set; }
        #endregion
        
        #region Parameter SecondarySourcesOverride
        /// <summary>
        /// <para>
        /// <para>An array of <c>ProjectSource</c> objects that override the secondary sources defined
        /// in the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeBuild.Model.ProjectSource[] SecondarySourcesOverride { get; set; }
        #endregion
        
        #region Parameter SecondarySourcesVersionOverride
        /// <summary>
        /// <para>
        /// <para>An array of <c>ProjectSourceVersion</c> objects that override the secondary source
        /// versions in the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CodeBuild.Model.ProjectSourceVersion[] SecondarySourcesVersionOverride { get; set; }
        #endregion
        
        #region Parameter BuildBatchConfigOverride_ServiceRole
        /// <summary>
        /// <para>
        /// <para>Specifies the service role ARN for the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String BuildBatchConfigOverride_ServiceRole { get; set; }
        #endregion
        
        #region Parameter ServiceRoleOverride
        /// <summary>
        /// <para>
        /// <para>The name of a service role for this batch build that overrides the one specified in
        /// the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceRoleOverride { get; set; }
        #endregion
        
        #region Parameter SourceLocationOverride
        /// <summary>
        /// <para>
        /// <para>A location that overrides, for this batch build, the source location defined in the
        /// batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceLocationOverride { get; set; }
        #endregion
        
        #region Parameter SourceTypeOverride
        /// <summary>
        /// <para>
        /// <para>The source input type that overrides the source input defined in the batch build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceType")]
        public Amazon.CodeBuild.SourceType SourceTypeOverride { get; set; }
        #endregion
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para>The version of the batch build input to be built, for this build only. If not specified,
        /// the latest version is used. If specified, the contents depends on the source provider:</para><dl><dt>CodeCommit</dt><dd><para>The commit ID, branch, or Git tag to use.</para></dd><dt>GitHub</dt><dd><para>The commit ID, pull request ID, branch name, or tag name that corresponds to the version
        /// of the source code you want to build. If a pull request ID is specified, it must use
        /// the format <c>pr/pull-request-ID</c> (for example <c>pr/25</c>). If a branch name
        /// is specified, the branch's HEAD commit ID is used. If not specified, the default branch's
        /// HEAD commit ID is used.</para></dd><dt>Bitbucket</dt><dd><para>The commit ID, branch name, or tag name that corresponds to the version of the source
        /// code you want to build. If a branch name is specified, the branch's HEAD commit ID
        /// is used. If not specified, the default branch's HEAD commit ID is used.</para></dd><dt>Amazon S3</dt><dd><para>The version ID of the object that represents the build input ZIP file to use.</para></dd></dl><para>If <c>sourceVersion</c> is specified at the project level, then this <c>sourceVersion</c>
        /// (at the build level) takes precedence. </para><para>For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/sample-source-version.html">Source
        /// Version Sample with CodeBuild</a> in the <i>CodeBuild User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceVersion { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_Status
        /// <summary>
        /// <para>
        /// <para>The current status of the logs in CloudWatch Logs for a build project. Valid values
        /// are:</para><ul><li><para><c>ENABLED</c>: CloudWatch Logs are enabled for this build project.</para></li><li><para><c>DISABLED</c>: CloudWatch Logs are not enabled for this build project.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LogsConfigOverride_CloudWatchLogs_Status")]
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
        [Alias("LogsConfigOverride_S3Logs_Status")]
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
        [Alias("LogsConfigOverride_CloudWatchLogs_StreamName")]
        public System.String CloudWatchLogs_StreamName { get; set; }
        #endregion
        
        #region Parameter BuildBatchConfigOverride_TimeoutInMin
        /// <summary>
        /// <para>
        /// <para>Specifies the maximum amount of time, in minutes, that the batch build must be completed
        /// in.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BuildBatchConfigOverride_TimeoutInMins")]
        public System.Int32? BuildBatchConfigOverride_TimeoutInMin { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Type
        /// <summary>
        /// <para>
        /// <para>The type of build output artifact. Valid values include:</para><ul><li><para><c>CODEPIPELINE</c>: The build project has build output generated through CodePipeline.
        /// </para><note><para>The <c>CODEPIPELINE</c> type is not supported for <c>secondaryArtifacts</c>.</para></note></li><li><para><c>NO_ARTIFACTS</c>: The build project does not produce any build output.</para></li><li><para><c>S3</c>: The build project stores build output in Amazon S3.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactsType")]
        public Amazon.CodeBuild.ArtifactsType ArtifactsOverride_Type { get; set; }
        #endregion
        
        #region Parameter CacheOverride_Type
        /// <summary>
        /// <para>
        /// <para>The type of cache used by the build project. Valid values include:</para><ul><li><para><c>NO_CACHE</c>: The build project does not use any cache.</para></li><li><para><c>S3</c>: The build project reads and writes from and to S3.</para></li><li><para><c>LOCAL</c>: The build project stores a cache locally on a build host that is only
        /// available to that build host.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.CacheType")]
        public Amazon.CodeBuild.CacheType CacheOverride_Type { get; set; }
        #endregion
        
        #region Parameter SourceAuthOverride_Type
        /// <summary>
        /// <para>
        /// <para>The authorization type to use. Valid options are OAUTH or CODECONNECTIONS.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceAuthType")]
        public Amazon.CodeBuild.SourceAuthType SourceAuthOverride_Type { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'BuildBatch'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.StartBuildBatchResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.StartBuildBatchResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "BuildBatch";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ProjectName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ProjectName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ProjectName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CBBatch (StartBuildBatch)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.StartBuildBatchResponse, StartCBBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ProjectName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ArtifactsOverride_ArtifactIdentifier = this.ArtifactsOverride_ArtifactIdentifier;
            context.ArtifactsOverride_BucketOwnerAccess = this.ArtifactsOverride_BucketOwnerAccess;
            context.ArtifactsOverride_EncryptionDisabled = this.ArtifactsOverride_EncryptionDisabled;
            context.ArtifactsOverride_Location = this.ArtifactsOverride_Location;
            context.ArtifactsOverride_Name = this.ArtifactsOverride_Name;
            context.ArtifactsOverride_NamespaceType = this.ArtifactsOverride_NamespaceType;
            context.ArtifactsOverride_OverrideArtifactName = this.ArtifactsOverride_OverrideArtifactName;
            context.ArtifactsOverride_Packaging = this.ArtifactsOverride_Packaging;
            context.ArtifactsOverride_Path = this.ArtifactsOverride_Path;
            context.ArtifactsOverride_Type = this.ArtifactsOverride_Type;
            context.BuildBatchConfigOverride_BatchReportMode = this.BuildBatchConfigOverride_BatchReportMode;
            context.BuildBatchConfigOverride_CombineArtifact = this.BuildBatchConfigOverride_CombineArtifact;
            if (this.Restrictions_ComputeTypesAllowed != null)
            {
                context.Restrictions_ComputeTypesAllowed = new List<System.String>(this.Restrictions_ComputeTypesAllowed);
            }
            context.Restrictions_MaximumBuildsAllowed = this.Restrictions_MaximumBuildsAllowed;
            context.BuildBatchConfigOverride_ServiceRole = this.BuildBatchConfigOverride_ServiceRole;
            context.BuildBatchConfigOverride_TimeoutInMin = this.BuildBatchConfigOverride_TimeoutInMin;
            context.BuildspecOverride = this.BuildspecOverride;
            context.BuildTimeoutInMinutesOverride = this.BuildTimeoutInMinutesOverride;
            context.CacheOverride_Location = this.CacheOverride_Location;
            if (this.CacheOverride_Mode != null)
            {
                context.CacheOverride_Mode = new List<System.String>(this.CacheOverride_Mode);
            }
            context.CacheOverride_Type = this.CacheOverride_Type;
            context.CertificateOverride = this.CertificateOverride;
            context.ComputeTypeOverride = this.ComputeTypeOverride;
            context.DebugSessionEnabled = this.DebugSessionEnabled;
            context.EncryptionKeyOverride = this.EncryptionKeyOverride;
            context.EnvironmentTypeOverride = this.EnvironmentTypeOverride;
            if (this.EnvironmentVariablesOverride != null)
            {
                context.EnvironmentVariablesOverride = new List<Amazon.CodeBuild.Model.EnvironmentVariable>(this.EnvironmentVariablesOverride);
            }
            context.GitCloneDepthOverride = this.GitCloneDepthOverride;
            context.GitSubmodulesConfigOverride_FetchSubmodule = this.GitSubmodulesConfigOverride_FetchSubmodule;
            context.IdempotencyToken = this.IdempotencyToken;
            context.ImageOverride = this.ImageOverride;
            context.ImagePullCredentialsTypeOverride = this.ImagePullCredentialsTypeOverride;
            context.InsecureSslOverride = this.InsecureSslOverride;
            context.CloudWatchLogs_GroupName = this.CloudWatchLogs_GroupName;
            context.CloudWatchLogs_Status = this.CloudWatchLogs_Status;
            context.CloudWatchLogs_StreamName = this.CloudWatchLogs_StreamName;
            context.S3Logs_BucketOwnerAccess = this.S3Logs_BucketOwnerAccess;
            context.S3Logs_EncryptionDisabled = this.S3Logs_EncryptionDisabled;
            context.S3Logs_Location = this.S3Logs_Location;
            context.S3Logs_Status = this.S3Logs_Status;
            context.PrivilegedModeOverride = this.PrivilegedModeOverride;
            context.ProjectName = this.ProjectName;
            #if MODULAR
            if (this.ProjectName == null && ParameterWasBound(nameof(this.ProjectName)))
            {
                WriteWarning("You are passing $null as a value for parameter ProjectName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QueuedTimeoutInMinutesOverride = this.QueuedTimeoutInMinutesOverride;
            context.RegistryCredentialOverride_Credential = this.RegistryCredentialOverride_Credential;
            context.RegistryCredentialOverride_CredentialProvider = this.RegistryCredentialOverride_CredentialProvider;
            context.ReportBuildBatchStatusOverride = this.ReportBuildBatchStatusOverride;
            if (this.SecondaryArtifactsOverride != null)
            {
                context.SecondaryArtifactsOverride = new List<Amazon.CodeBuild.Model.ProjectArtifacts>(this.SecondaryArtifactsOverride);
            }
            if (this.SecondarySourcesOverride != null)
            {
                context.SecondarySourcesOverride = new List<Amazon.CodeBuild.Model.ProjectSource>(this.SecondarySourcesOverride);
            }
            if (this.SecondarySourcesVersionOverride != null)
            {
                context.SecondarySourcesVersionOverride = new List<Amazon.CodeBuild.Model.ProjectSourceVersion>(this.SecondarySourcesVersionOverride);
            }
            context.ServiceRoleOverride = this.ServiceRoleOverride;
            context.SourceAuthOverride_Resource = this.SourceAuthOverride_Resource;
            context.SourceAuthOverride_Type = this.SourceAuthOverride_Type;
            context.SourceLocationOverride = this.SourceLocationOverride;
            context.SourceTypeOverride = this.SourceTypeOverride;
            context.SourceVersion = this.SourceVersion;
            
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
            var request = new Amazon.CodeBuild.Model.StartBuildBatchRequest();
            
            
             // populate ArtifactsOverride
            var requestArtifactsOverrideIsNull = true;
            request.ArtifactsOverride = new Amazon.CodeBuild.Model.ProjectArtifacts();
            System.String requestArtifactsOverride_artifactsOverride_ArtifactIdentifier = null;
            if (cmdletContext.ArtifactsOverride_ArtifactIdentifier != null)
            {
                requestArtifactsOverride_artifactsOverride_ArtifactIdentifier = cmdletContext.ArtifactsOverride_ArtifactIdentifier;
            }
            if (requestArtifactsOverride_artifactsOverride_ArtifactIdentifier != null)
            {
                request.ArtifactsOverride.ArtifactIdentifier = requestArtifactsOverride_artifactsOverride_ArtifactIdentifier;
                requestArtifactsOverrideIsNull = false;
            }
            Amazon.CodeBuild.BucketOwnerAccess requestArtifactsOverride_artifactsOverride_BucketOwnerAccess = null;
            if (cmdletContext.ArtifactsOverride_BucketOwnerAccess != null)
            {
                requestArtifactsOverride_artifactsOverride_BucketOwnerAccess = cmdletContext.ArtifactsOverride_BucketOwnerAccess;
            }
            if (requestArtifactsOverride_artifactsOverride_BucketOwnerAccess != null)
            {
                request.ArtifactsOverride.BucketOwnerAccess = requestArtifactsOverride_artifactsOverride_BucketOwnerAccess;
                requestArtifactsOverrideIsNull = false;
            }
            System.Boolean? requestArtifactsOverride_artifactsOverride_EncryptionDisabled = null;
            if (cmdletContext.ArtifactsOverride_EncryptionDisabled != null)
            {
                requestArtifactsOverride_artifactsOverride_EncryptionDisabled = cmdletContext.ArtifactsOverride_EncryptionDisabled.Value;
            }
            if (requestArtifactsOverride_artifactsOverride_EncryptionDisabled != null)
            {
                request.ArtifactsOverride.EncryptionDisabled = requestArtifactsOverride_artifactsOverride_EncryptionDisabled.Value;
                requestArtifactsOverrideIsNull = false;
            }
            System.String requestArtifactsOverride_artifactsOverride_Location = null;
            if (cmdletContext.ArtifactsOverride_Location != null)
            {
                requestArtifactsOverride_artifactsOverride_Location = cmdletContext.ArtifactsOverride_Location;
            }
            if (requestArtifactsOverride_artifactsOverride_Location != null)
            {
                request.ArtifactsOverride.Location = requestArtifactsOverride_artifactsOverride_Location;
                requestArtifactsOverrideIsNull = false;
            }
            System.String requestArtifactsOverride_artifactsOverride_Name = null;
            if (cmdletContext.ArtifactsOverride_Name != null)
            {
                requestArtifactsOverride_artifactsOverride_Name = cmdletContext.ArtifactsOverride_Name;
            }
            if (requestArtifactsOverride_artifactsOverride_Name != null)
            {
                request.ArtifactsOverride.Name = requestArtifactsOverride_artifactsOverride_Name;
                requestArtifactsOverrideIsNull = false;
            }
            Amazon.CodeBuild.ArtifactNamespace requestArtifactsOverride_artifactsOverride_NamespaceType = null;
            if (cmdletContext.ArtifactsOverride_NamespaceType != null)
            {
                requestArtifactsOverride_artifactsOverride_NamespaceType = cmdletContext.ArtifactsOverride_NamespaceType;
            }
            if (requestArtifactsOverride_artifactsOverride_NamespaceType != null)
            {
                request.ArtifactsOverride.NamespaceType = requestArtifactsOverride_artifactsOverride_NamespaceType;
                requestArtifactsOverrideIsNull = false;
            }
            System.Boolean? requestArtifactsOverride_artifactsOverride_OverrideArtifactName = null;
            if (cmdletContext.ArtifactsOverride_OverrideArtifactName != null)
            {
                requestArtifactsOverride_artifactsOverride_OverrideArtifactName = cmdletContext.ArtifactsOverride_OverrideArtifactName.Value;
            }
            if (requestArtifactsOverride_artifactsOverride_OverrideArtifactName != null)
            {
                request.ArtifactsOverride.OverrideArtifactName = requestArtifactsOverride_artifactsOverride_OverrideArtifactName.Value;
                requestArtifactsOverrideIsNull = false;
            }
            Amazon.CodeBuild.ArtifactPackaging requestArtifactsOverride_artifactsOverride_Packaging = null;
            if (cmdletContext.ArtifactsOverride_Packaging != null)
            {
                requestArtifactsOverride_artifactsOverride_Packaging = cmdletContext.ArtifactsOverride_Packaging;
            }
            if (requestArtifactsOverride_artifactsOverride_Packaging != null)
            {
                request.ArtifactsOverride.Packaging = requestArtifactsOverride_artifactsOverride_Packaging;
                requestArtifactsOverrideIsNull = false;
            }
            System.String requestArtifactsOverride_artifactsOverride_Path = null;
            if (cmdletContext.ArtifactsOverride_Path != null)
            {
                requestArtifactsOverride_artifactsOverride_Path = cmdletContext.ArtifactsOverride_Path;
            }
            if (requestArtifactsOverride_artifactsOverride_Path != null)
            {
                request.ArtifactsOverride.Path = requestArtifactsOverride_artifactsOverride_Path;
                requestArtifactsOverrideIsNull = false;
            }
            Amazon.CodeBuild.ArtifactsType requestArtifactsOverride_artifactsOverride_Type = null;
            if (cmdletContext.ArtifactsOverride_Type != null)
            {
                requestArtifactsOverride_artifactsOverride_Type = cmdletContext.ArtifactsOverride_Type;
            }
            if (requestArtifactsOverride_artifactsOverride_Type != null)
            {
                request.ArtifactsOverride.Type = requestArtifactsOverride_artifactsOverride_Type;
                requestArtifactsOverrideIsNull = false;
            }
             // determine if request.ArtifactsOverride should be set to null
            if (requestArtifactsOverrideIsNull)
            {
                request.ArtifactsOverride = null;
            }
            
             // populate BuildBatchConfigOverride
            var requestBuildBatchConfigOverrideIsNull = true;
            request.BuildBatchConfigOverride = new Amazon.CodeBuild.Model.ProjectBuildBatchConfig();
            Amazon.CodeBuild.BatchReportModeType requestBuildBatchConfigOverride_buildBatchConfigOverride_BatchReportMode = null;
            if (cmdletContext.BuildBatchConfigOverride_BatchReportMode != null)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_BatchReportMode = cmdletContext.BuildBatchConfigOverride_BatchReportMode;
            }
            if (requestBuildBatchConfigOverride_buildBatchConfigOverride_BatchReportMode != null)
            {
                request.BuildBatchConfigOverride.BatchReportMode = requestBuildBatchConfigOverride_buildBatchConfigOverride_BatchReportMode;
                requestBuildBatchConfigOverrideIsNull = false;
            }
            System.Boolean? requestBuildBatchConfigOverride_buildBatchConfigOverride_CombineArtifact = null;
            if (cmdletContext.BuildBatchConfigOverride_CombineArtifact != null)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_CombineArtifact = cmdletContext.BuildBatchConfigOverride_CombineArtifact.Value;
            }
            if (requestBuildBatchConfigOverride_buildBatchConfigOverride_CombineArtifact != null)
            {
                request.BuildBatchConfigOverride.CombineArtifacts = requestBuildBatchConfigOverride_buildBatchConfigOverride_CombineArtifact.Value;
                requestBuildBatchConfigOverrideIsNull = false;
            }
            System.String requestBuildBatchConfigOverride_buildBatchConfigOverride_ServiceRole = null;
            if (cmdletContext.BuildBatchConfigOverride_ServiceRole != null)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_ServiceRole = cmdletContext.BuildBatchConfigOverride_ServiceRole;
            }
            if (requestBuildBatchConfigOverride_buildBatchConfigOverride_ServiceRole != null)
            {
                request.BuildBatchConfigOverride.ServiceRole = requestBuildBatchConfigOverride_buildBatchConfigOverride_ServiceRole;
                requestBuildBatchConfigOverrideIsNull = false;
            }
            System.Int32? requestBuildBatchConfigOverride_buildBatchConfigOverride_TimeoutInMin = null;
            if (cmdletContext.BuildBatchConfigOverride_TimeoutInMin != null)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_TimeoutInMin = cmdletContext.BuildBatchConfigOverride_TimeoutInMin.Value;
            }
            if (requestBuildBatchConfigOverride_buildBatchConfigOverride_TimeoutInMin != null)
            {
                request.BuildBatchConfigOverride.TimeoutInMins = requestBuildBatchConfigOverride_buildBatchConfigOverride_TimeoutInMin.Value;
                requestBuildBatchConfigOverrideIsNull = false;
            }
            Amazon.CodeBuild.Model.BatchRestrictions requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions = null;
            
             // populate Restrictions
            var requestBuildBatchConfigOverride_buildBatchConfigOverride_RestrictionsIsNull = true;
            requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions = new Amazon.CodeBuild.Model.BatchRestrictions();
            List<System.String> requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions_restrictions_ComputeTypesAllowed = null;
            if (cmdletContext.Restrictions_ComputeTypesAllowed != null)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions_restrictions_ComputeTypesAllowed = cmdletContext.Restrictions_ComputeTypesAllowed;
            }
            if (requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions_restrictions_ComputeTypesAllowed != null)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions.ComputeTypesAllowed = requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions_restrictions_ComputeTypesAllowed;
                requestBuildBatchConfigOverride_buildBatchConfigOverride_RestrictionsIsNull = false;
            }
            System.Int32? requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions_restrictions_MaximumBuildsAllowed = null;
            if (cmdletContext.Restrictions_MaximumBuildsAllowed != null)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions_restrictions_MaximumBuildsAllowed = cmdletContext.Restrictions_MaximumBuildsAllowed.Value;
            }
            if (requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions_restrictions_MaximumBuildsAllowed != null)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions.MaximumBuildsAllowed = requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions_restrictions_MaximumBuildsAllowed.Value;
                requestBuildBatchConfigOverride_buildBatchConfigOverride_RestrictionsIsNull = false;
            }
             // determine if requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions should be set to null
            if (requestBuildBatchConfigOverride_buildBatchConfigOverride_RestrictionsIsNull)
            {
                requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions = null;
            }
            if (requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions != null)
            {
                request.BuildBatchConfigOverride.Restrictions = requestBuildBatchConfigOverride_buildBatchConfigOverride_Restrictions;
                requestBuildBatchConfigOverrideIsNull = false;
            }
             // determine if request.BuildBatchConfigOverride should be set to null
            if (requestBuildBatchConfigOverrideIsNull)
            {
                request.BuildBatchConfigOverride = null;
            }
            if (cmdletContext.BuildspecOverride != null)
            {
                request.BuildspecOverride = cmdletContext.BuildspecOverride;
            }
            if (cmdletContext.BuildTimeoutInMinutesOverride != null)
            {
                request.BuildTimeoutInMinutesOverride = cmdletContext.BuildTimeoutInMinutesOverride.Value;
            }
            
             // populate CacheOverride
            var requestCacheOverrideIsNull = true;
            request.CacheOverride = new Amazon.CodeBuild.Model.ProjectCache();
            System.String requestCacheOverride_cacheOverride_Location = null;
            if (cmdletContext.CacheOverride_Location != null)
            {
                requestCacheOverride_cacheOverride_Location = cmdletContext.CacheOverride_Location;
            }
            if (requestCacheOverride_cacheOverride_Location != null)
            {
                request.CacheOverride.Location = requestCacheOverride_cacheOverride_Location;
                requestCacheOverrideIsNull = false;
            }
            List<System.String> requestCacheOverride_cacheOverride_Mode = null;
            if (cmdletContext.CacheOverride_Mode != null)
            {
                requestCacheOverride_cacheOverride_Mode = cmdletContext.CacheOverride_Mode;
            }
            if (requestCacheOverride_cacheOverride_Mode != null)
            {
                request.CacheOverride.Modes = requestCacheOverride_cacheOverride_Mode;
                requestCacheOverrideIsNull = false;
            }
            Amazon.CodeBuild.CacheType requestCacheOverride_cacheOverride_Type = null;
            if (cmdletContext.CacheOverride_Type != null)
            {
                requestCacheOverride_cacheOverride_Type = cmdletContext.CacheOverride_Type;
            }
            if (requestCacheOverride_cacheOverride_Type != null)
            {
                request.CacheOverride.Type = requestCacheOverride_cacheOverride_Type;
                requestCacheOverrideIsNull = false;
            }
             // determine if request.CacheOverride should be set to null
            if (requestCacheOverrideIsNull)
            {
                request.CacheOverride = null;
            }
            if (cmdletContext.CertificateOverride != null)
            {
                request.CertificateOverride = cmdletContext.CertificateOverride;
            }
            if (cmdletContext.ComputeTypeOverride != null)
            {
                request.ComputeTypeOverride = cmdletContext.ComputeTypeOverride;
            }
            if (cmdletContext.DebugSessionEnabled != null)
            {
                request.DebugSessionEnabled = cmdletContext.DebugSessionEnabled.Value;
            }
            if (cmdletContext.EncryptionKeyOverride != null)
            {
                request.EncryptionKeyOverride = cmdletContext.EncryptionKeyOverride;
            }
            if (cmdletContext.EnvironmentTypeOverride != null)
            {
                request.EnvironmentTypeOverride = cmdletContext.EnvironmentTypeOverride;
            }
            if (cmdletContext.EnvironmentVariablesOverride != null)
            {
                request.EnvironmentVariablesOverride = cmdletContext.EnvironmentVariablesOverride;
            }
            if (cmdletContext.GitCloneDepthOverride != null)
            {
                request.GitCloneDepthOverride = cmdletContext.GitCloneDepthOverride.Value;
            }
            
             // populate GitSubmodulesConfigOverride
            var requestGitSubmodulesConfigOverrideIsNull = true;
            request.GitSubmodulesConfigOverride = new Amazon.CodeBuild.Model.GitSubmodulesConfig();
            System.Boolean? requestGitSubmodulesConfigOverride_gitSubmodulesConfigOverride_FetchSubmodule = null;
            if (cmdletContext.GitSubmodulesConfigOverride_FetchSubmodule != null)
            {
                requestGitSubmodulesConfigOverride_gitSubmodulesConfigOverride_FetchSubmodule = cmdletContext.GitSubmodulesConfigOverride_FetchSubmodule.Value;
            }
            if (requestGitSubmodulesConfigOverride_gitSubmodulesConfigOverride_FetchSubmodule != null)
            {
                request.GitSubmodulesConfigOverride.FetchSubmodules = requestGitSubmodulesConfigOverride_gitSubmodulesConfigOverride_FetchSubmodule.Value;
                requestGitSubmodulesConfigOverrideIsNull = false;
            }
             // determine if request.GitSubmodulesConfigOverride should be set to null
            if (requestGitSubmodulesConfigOverrideIsNull)
            {
                request.GitSubmodulesConfigOverride = null;
            }
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.ImageOverride != null)
            {
                request.ImageOverride = cmdletContext.ImageOverride;
            }
            if (cmdletContext.ImagePullCredentialsTypeOverride != null)
            {
                request.ImagePullCredentialsTypeOverride = cmdletContext.ImagePullCredentialsTypeOverride;
            }
            if (cmdletContext.InsecureSslOverride != null)
            {
                request.InsecureSslOverride = cmdletContext.InsecureSslOverride.Value;
            }
            
             // populate LogsConfigOverride
            var requestLogsConfigOverrideIsNull = true;
            request.LogsConfigOverride = new Amazon.CodeBuild.Model.LogsConfig();
            Amazon.CodeBuild.Model.CloudWatchLogsConfig requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs = null;
            
             // populate CloudWatchLogs
            var requestLogsConfigOverride_logsConfigOverride_CloudWatchLogsIsNull = true;
            requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs = new Amazon.CodeBuild.Model.CloudWatchLogsConfig();
            System.String requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_GroupName = null;
            if (cmdletContext.CloudWatchLogs_GroupName != null)
            {
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_GroupName = cmdletContext.CloudWatchLogs_GroupName;
            }
            if (requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_GroupName != null)
            {
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs.GroupName = requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_GroupName;
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogsIsNull = false;
            }
            Amazon.CodeBuild.LogsConfigStatusType requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_Status = null;
            if (cmdletContext.CloudWatchLogs_Status != null)
            {
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_Status = cmdletContext.CloudWatchLogs_Status;
            }
            if (requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_Status != null)
            {
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs.Status = requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_Status;
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogsIsNull = false;
            }
            System.String requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_StreamName = null;
            if (cmdletContext.CloudWatchLogs_StreamName != null)
            {
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_StreamName = cmdletContext.CloudWatchLogs_StreamName;
            }
            if (requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_StreamName != null)
            {
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs.StreamName = requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs_cloudWatchLogs_StreamName;
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogsIsNull = false;
            }
             // determine if requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs should be set to null
            if (requestLogsConfigOverride_logsConfigOverride_CloudWatchLogsIsNull)
            {
                requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs = null;
            }
            if (requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs != null)
            {
                request.LogsConfigOverride.CloudWatchLogs = requestLogsConfigOverride_logsConfigOverride_CloudWatchLogs;
                requestLogsConfigOverrideIsNull = false;
            }
            Amazon.CodeBuild.Model.S3LogsConfig requestLogsConfigOverride_logsConfigOverride_S3Logs = null;
            
             // populate S3Logs
            var requestLogsConfigOverride_logsConfigOverride_S3LogsIsNull = true;
            requestLogsConfigOverride_logsConfigOverride_S3Logs = new Amazon.CodeBuild.Model.S3LogsConfig();
            Amazon.CodeBuild.BucketOwnerAccess requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_BucketOwnerAccess = null;
            if (cmdletContext.S3Logs_BucketOwnerAccess != null)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_BucketOwnerAccess = cmdletContext.S3Logs_BucketOwnerAccess;
            }
            if (requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_BucketOwnerAccess != null)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs.BucketOwnerAccess = requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_BucketOwnerAccess;
                requestLogsConfigOverride_logsConfigOverride_S3LogsIsNull = false;
            }
            System.Boolean? requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_EncryptionDisabled = null;
            if (cmdletContext.S3Logs_EncryptionDisabled != null)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_EncryptionDisabled = cmdletContext.S3Logs_EncryptionDisabled.Value;
            }
            if (requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_EncryptionDisabled != null)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs.EncryptionDisabled = requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_EncryptionDisabled.Value;
                requestLogsConfigOverride_logsConfigOverride_S3LogsIsNull = false;
            }
            System.String requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_Location = null;
            if (cmdletContext.S3Logs_Location != null)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_Location = cmdletContext.S3Logs_Location;
            }
            if (requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_Location != null)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs.Location = requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_Location;
                requestLogsConfigOverride_logsConfigOverride_S3LogsIsNull = false;
            }
            Amazon.CodeBuild.LogsConfigStatusType requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_Status = null;
            if (cmdletContext.S3Logs_Status != null)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_Status = cmdletContext.S3Logs_Status;
            }
            if (requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_Status != null)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs.Status = requestLogsConfigOverride_logsConfigOverride_S3Logs_s3Logs_Status;
                requestLogsConfigOverride_logsConfigOverride_S3LogsIsNull = false;
            }
             // determine if requestLogsConfigOverride_logsConfigOverride_S3Logs should be set to null
            if (requestLogsConfigOverride_logsConfigOverride_S3LogsIsNull)
            {
                requestLogsConfigOverride_logsConfigOverride_S3Logs = null;
            }
            if (requestLogsConfigOverride_logsConfigOverride_S3Logs != null)
            {
                request.LogsConfigOverride.S3Logs = requestLogsConfigOverride_logsConfigOverride_S3Logs;
                requestLogsConfigOverrideIsNull = false;
            }
             // determine if request.LogsConfigOverride should be set to null
            if (requestLogsConfigOverrideIsNull)
            {
                request.LogsConfigOverride = null;
            }
            if (cmdletContext.PrivilegedModeOverride != null)
            {
                request.PrivilegedModeOverride = cmdletContext.PrivilegedModeOverride.Value;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            if (cmdletContext.QueuedTimeoutInMinutesOverride != null)
            {
                request.QueuedTimeoutInMinutesOverride = cmdletContext.QueuedTimeoutInMinutesOverride.Value;
            }
            
             // populate RegistryCredentialOverride
            var requestRegistryCredentialOverrideIsNull = true;
            request.RegistryCredentialOverride = new Amazon.CodeBuild.Model.RegistryCredential();
            System.String requestRegistryCredentialOverride_registryCredentialOverride_Credential = null;
            if (cmdletContext.RegistryCredentialOverride_Credential != null)
            {
                requestRegistryCredentialOverride_registryCredentialOverride_Credential = cmdletContext.RegistryCredentialOverride_Credential;
            }
            if (requestRegistryCredentialOverride_registryCredentialOverride_Credential != null)
            {
                request.RegistryCredentialOverride.Credential = requestRegistryCredentialOverride_registryCredentialOverride_Credential;
                requestRegistryCredentialOverrideIsNull = false;
            }
            Amazon.CodeBuild.CredentialProviderType requestRegistryCredentialOverride_registryCredentialOverride_CredentialProvider = null;
            if (cmdletContext.RegistryCredentialOverride_CredentialProvider != null)
            {
                requestRegistryCredentialOverride_registryCredentialOverride_CredentialProvider = cmdletContext.RegistryCredentialOverride_CredentialProvider;
            }
            if (requestRegistryCredentialOverride_registryCredentialOverride_CredentialProvider != null)
            {
                request.RegistryCredentialOverride.CredentialProvider = requestRegistryCredentialOverride_registryCredentialOverride_CredentialProvider;
                requestRegistryCredentialOverrideIsNull = false;
            }
             // determine if request.RegistryCredentialOverride should be set to null
            if (requestRegistryCredentialOverrideIsNull)
            {
                request.RegistryCredentialOverride = null;
            }
            if (cmdletContext.ReportBuildBatchStatusOverride != null)
            {
                request.ReportBuildBatchStatusOverride = cmdletContext.ReportBuildBatchStatusOverride.Value;
            }
            if (cmdletContext.SecondaryArtifactsOverride != null)
            {
                request.SecondaryArtifactsOverride = cmdletContext.SecondaryArtifactsOverride;
            }
            if (cmdletContext.SecondarySourcesOverride != null)
            {
                request.SecondarySourcesOverride = cmdletContext.SecondarySourcesOverride;
            }
            if (cmdletContext.SecondarySourcesVersionOverride != null)
            {
                request.SecondarySourcesVersionOverride = cmdletContext.SecondarySourcesVersionOverride;
            }
            if (cmdletContext.ServiceRoleOverride != null)
            {
                request.ServiceRoleOverride = cmdletContext.ServiceRoleOverride;
            }
            
             // populate SourceAuthOverride
            var requestSourceAuthOverrideIsNull = true;
            request.SourceAuthOverride = new Amazon.CodeBuild.Model.SourceAuth();
            System.String requestSourceAuthOverride_sourceAuthOverride_Resource = null;
            if (cmdletContext.SourceAuthOverride_Resource != null)
            {
                requestSourceAuthOverride_sourceAuthOverride_Resource = cmdletContext.SourceAuthOverride_Resource;
            }
            if (requestSourceAuthOverride_sourceAuthOverride_Resource != null)
            {
                request.SourceAuthOverride.Resource = requestSourceAuthOverride_sourceAuthOverride_Resource;
                requestSourceAuthOverrideIsNull = false;
            }
            Amazon.CodeBuild.SourceAuthType requestSourceAuthOverride_sourceAuthOverride_Type = null;
            if (cmdletContext.SourceAuthOverride_Type != null)
            {
                requestSourceAuthOverride_sourceAuthOverride_Type = cmdletContext.SourceAuthOverride_Type;
            }
            if (requestSourceAuthOverride_sourceAuthOverride_Type != null)
            {
                request.SourceAuthOverride.Type = requestSourceAuthOverride_sourceAuthOverride_Type;
                requestSourceAuthOverrideIsNull = false;
            }
             // determine if request.SourceAuthOverride should be set to null
            if (requestSourceAuthOverrideIsNull)
            {
                request.SourceAuthOverride = null;
            }
            if (cmdletContext.SourceLocationOverride != null)
            {
                request.SourceLocationOverride = cmdletContext.SourceLocationOverride;
            }
            if (cmdletContext.SourceTypeOverride != null)
            {
                request.SourceTypeOverride = cmdletContext.SourceTypeOverride;
            }
            if (cmdletContext.SourceVersion != null)
            {
                request.SourceVersion = cmdletContext.SourceVersion;
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
        
        private Amazon.CodeBuild.Model.StartBuildBatchResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.StartBuildBatchRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "StartBuildBatch");
            try
            {
                #if DESKTOP
                return client.StartBuildBatch(request);
                #elif CORECLR
                return client.StartBuildBatchAsync(request).GetAwaiter().GetResult();
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
            public System.String ArtifactsOverride_ArtifactIdentifier { get; set; }
            public Amazon.CodeBuild.BucketOwnerAccess ArtifactsOverride_BucketOwnerAccess { get; set; }
            public System.Boolean? ArtifactsOverride_EncryptionDisabled { get; set; }
            public System.String ArtifactsOverride_Location { get; set; }
            public System.String ArtifactsOverride_Name { get; set; }
            public Amazon.CodeBuild.ArtifactNamespace ArtifactsOverride_NamespaceType { get; set; }
            public System.Boolean? ArtifactsOverride_OverrideArtifactName { get; set; }
            public Amazon.CodeBuild.ArtifactPackaging ArtifactsOverride_Packaging { get; set; }
            public System.String ArtifactsOverride_Path { get; set; }
            public Amazon.CodeBuild.ArtifactsType ArtifactsOverride_Type { get; set; }
            public Amazon.CodeBuild.BatchReportModeType BuildBatchConfigOverride_BatchReportMode { get; set; }
            public System.Boolean? BuildBatchConfigOverride_CombineArtifact { get; set; }
            public List<System.String> Restrictions_ComputeTypesAllowed { get; set; }
            public System.Int32? Restrictions_MaximumBuildsAllowed { get; set; }
            public System.String BuildBatchConfigOverride_ServiceRole { get; set; }
            public System.Int32? BuildBatchConfigOverride_TimeoutInMin { get; set; }
            public System.String BuildspecOverride { get; set; }
            public System.Int32? BuildTimeoutInMinutesOverride { get; set; }
            public System.String CacheOverride_Location { get; set; }
            public List<System.String> CacheOverride_Mode { get; set; }
            public Amazon.CodeBuild.CacheType CacheOverride_Type { get; set; }
            public System.String CertificateOverride { get; set; }
            public Amazon.CodeBuild.ComputeType ComputeTypeOverride { get; set; }
            public System.Boolean? DebugSessionEnabled { get; set; }
            public System.String EncryptionKeyOverride { get; set; }
            public Amazon.CodeBuild.EnvironmentType EnvironmentTypeOverride { get; set; }
            public List<Amazon.CodeBuild.Model.EnvironmentVariable> EnvironmentVariablesOverride { get; set; }
            public System.Int32? GitCloneDepthOverride { get; set; }
            public System.Boolean? GitSubmodulesConfigOverride_FetchSubmodule { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String ImageOverride { get; set; }
            public Amazon.CodeBuild.ImagePullCredentialsType ImagePullCredentialsTypeOverride { get; set; }
            public System.Boolean? InsecureSslOverride { get; set; }
            public System.String CloudWatchLogs_GroupName { get; set; }
            public Amazon.CodeBuild.LogsConfigStatusType CloudWatchLogs_Status { get; set; }
            public System.String CloudWatchLogs_StreamName { get; set; }
            public Amazon.CodeBuild.BucketOwnerAccess S3Logs_BucketOwnerAccess { get; set; }
            public System.Boolean? S3Logs_EncryptionDisabled { get; set; }
            public System.String S3Logs_Location { get; set; }
            public Amazon.CodeBuild.LogsConfigStatusType S3Logs_Status { get; set; }
            public System.Boolean? PrivilegedModeOverride { get; set; }
            public System.String ProjectName { get; set; }
            public System.Int32? QueuedTimeoutInMinutesOverride { get; set; }
            public System.String RegistryCredentialOverride_Credential { get; set; }
            public Amazon.CodeBuild.CredentialProviderType RegistryCredentialOverride_CredentialProvider { get; set; }
            public System.Boolean? ReportBuildBatchStatusOverride { get; set; }
            public List<Amazon.CodeBuild.Model.ProjectArtifacts> SecondaryArtifactsOverride { get; set; }
            public List<Amazon.CodeBuild.Model.ProjectSource> SecondarySourcesOverride { get; set; }
            public List<Amazon.CodeBuild.Model.ProjectSourceVersion> SecondarySourcesVersionOverride { get; set; }
            public System.String ServiceRoleOverride { get; set; }
            public System.String SourceAuthOverride_Resource { get; set; }
            public Amazon.CodeBuild.SourceAuthType SourceAuthOverride_Type { get; set; }
            public System.String SourceLocationOverride { get; set; }
            public Amazon.CodeBuild.SourceType SourceTypeOverride { get; set; }
            public System.String SourceVersion { get; set; }
            public System.Func<Amazon.CodeBuild.Model.StartBuildBatchResponse, StartCBBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.BuildBatch;
        }
        
    }
}
