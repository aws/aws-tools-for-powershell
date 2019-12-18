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
    /// Creates a build project.
    /// </summary>
    [Cmdlet("New", "CBProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.Project")]
    [AWSCmdlet("Calls the AWS CodeBuild CreateProject API operation.", Operation = new[] {"CreateProject"}, SelectReturnType = typeof(Amazon.CodeBuild.Model.CreateProjectResponse))]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Project or Amazon.CodeBuild.Model.CreateProjectResponse",
        "This cmdlet returns an Amazon.CodeBuild.Model.Project object.",
        "The service call response (type Amazon.CodeBuild.Model.CreateProjectResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewCBProjectCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        #region Parameter Artifacts_ArtifactIdentifier
        /// <summary>
        /// <para>
        /// <para> An identifier for this artifact definition. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Artifacts_ArtifactIdentifier { get; set; }
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
        
        #region Parameter Source_Buildspec
        /// <summary>
        /// <para>
        /// <para>The build spec declaration to use for the builds in this build project.</para><para>If this value is not specified, a build spec must be included along with the source
        /// code to be built.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_Buildspec { get; set; }
        #endregion
        
        #region Parameter Environment_Certificate
        /// <summary>
        /// <para>
        /// <para>The certificate to use with this build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Environment_Certificate { get; set; }
        #endregion
        
        #region Parameter Environment_ComputeType
        /// <summary>
        /// <para>
        /// <para>Information about the compute resources the build project uses. Available values include:</para><ul><li><para><code>BUILD_GENERAL1_SMALL</code>: Use up to 3 GB memory and 2 vCPUs for builds.</para></li><li><para><code>BUILD_GENERAL1_MEDIUM</code>: Use up to 7 GB memory and 4 vCPUs for builds.</para></li><li><para><code>BUILD_GENERAL1_LARGE</code>: Use up to 16 GB memory and 8 vCPUs for builds,
        /// depending on your environment type.</para></li><li><para><code>BUILD_GENERAL1_2XLARGE</code>: Use up to 145 GB memory, 72 vCPUs, and 824 GB
        /// of SSD storage for builds. This compute type supports Docker images up to 100 GB uncompressed.</para></li></ul><para> If you use <code>BUILD_GENERAL1_LARGE</code>: </para><ul><li><para> For environment type <code>LINUX_CONTAINER</code>, you can use up to 15 GB memory
        /// and 8 vCPUs for builds. </para></li><li><para> For environment type <code>LINUX_GPU_CONTAINER</code>, you can use up to 255 GB memory,
        /// 32 vCPUs, and 4 NVIDIA Tesla V100 GPUs for builds.</para></li><li><para> For environment type <code>ARM_CONTAINER</code>, you can use up to 16 GB memory and
        /// 8 vCPUs on ARM-based processors for builds.</para></li></ul><para> For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/build-env-ref-compute-types.html">Build
        /// Environment Compute Types</a> in the <i>AWS CodeBuild User Guide.</i></para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ComputeType")]
        public Amazon.CodeBuild.ComputeType Environment_ComputeType { get; set; }
        #endregion
        
        #region Parameter RegistryCredential_Credential
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) or name of credentials created using AWS Secrets Manager.
        /// </para><note><para> The <code>credential</code> can use the name of the credentials only if they exist
        /// in your current region. </para></note>
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
        /// valid value, SECRETS_MANAGER, is for AWS Secrets Manager. </para>
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
        /// <para>A description that makes the build project easy to identify.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Artifacts_EncryptionDisabled
        /// <summary>
        /// <para>
        /// <para> Set to true if you do not want your output artifacts encrypted. This option is valid
        /// only if your artifacts type is Amazon Simple Storage Service (Amazon S3). If this
        /// is set with another artifacts type, an invalidInputException is thrown. </para>
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
        /// <para>The AWS Key Management Service (AWS KMS) customer master key (CMK) to be used for
        /// encrypting the build output artifacts.</para><note><para> You can use a cross-account KMS key to encrypt the build output artifacts if your
        /// service role has permission to that key. </para></note><para>You can specify either the Amazon Resource Name (ARN) of the CMK or, if available,
        /// the CMK's alias (using the format <code>alias/<i>alias-name</i></code>).</para>
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
        /// <para> Set to true to fetch Git submodules for your AWS CodeBuild build project. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Source_GitSubmodulesConfig_FetchSubmodules")]
        public System.Boolean? GitSubmodulesConfig_FetchSubmodule { get; set; }
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
        /// <para> The group name of the logs in Amazon CloudWatch Logs. For more information, see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/Working-with-log-groups-and-streams.html">Working
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
        /// project. Use the following formats:</para><ul><li><para>For an image tag: <code>registry/repository:tag</code>. For example, to specify an
        /// image with the tag "latest," use <code>registry/repository:latest</code>.</para></li><li><para>For an image digest: <code>registry/repository@digest</code>. For example, to specify
        /// an image with the digest "sha256:cbbf2f9a99b47fc460d422812b6a5adff7dfee951d8fa2e4a98caa0382cfbdbf,"
        /// use <code>registry/repository@sha256:cbbf2f9a99b47fc460d422812b6a5adff7dfee951d8fa2e4a98caa0382cfbdbf</code>.</para></li></ul>
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
        public System.String Environment_Image { get; set; }
        #endregion
        
        #region Parameter Environment_ImagePullCredentialsType
        /// <summary>
        /// <para>
        /// <para> The type of credentials AWS CodeBuild uses to pull images in your build. There are
        /// two valid values: </para><ul><li><para><code>CODEBUILD</code> specifies that AWS CodeBuild uses its own credentials. This
        /// requires that you modify your ECR repository policy to trust AWS CodeBuild's service
        /// principal. </para></li><li><para><code>SERVICE_ROLE</code> specifies that AWS CodeBuild uses your build project's
        /// service role. </para></li></ul><para> When you use a cross-account or private registry image, you must use SERVICE_ROLE
        /// credentials. When you use an AWS CodeBuild curated image, you must use CODEBUILD credentials.
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
        
        #region Parameter Artifacts_Location
        /// <summary>
        /// <para>
        /// <para>Information about the build output artifact location:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, AWS CodePipeline ignores
        /// this value if specified. This is because AWS CodePipeline manages its build output
        /// locations instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, this value is ignored if
        /// specified, because no build output is produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, this is the name of the output bucket.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Artifacts_Location { get; set; }
        #endregion
        
        #region Parameter Cache_Location
        /// <summary>
        /// <para>
        /// <para>Information about the cache location: </para><ul><li><para><code>NO_CACHE</code> or <code>LOCAL</code>: This value is ignored.</para></li><li><para><code>S3</code>: This is the S3 bucket name/prefix.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Cache_Location { get; set; }
        #endregion
        
        #region Parameter S3Logs_Location
        /// <summary>
        /// <para>
        /// <para> The ARN of an S3 bucket and the path prefix for S3 logs. If your Amazon S3 bucket
        /// name is <code>my-bucket</code>, and your path prefix is <code>build-log</code>, then
        /// acceptable formats are <code>my-bucket/build-log</code> or <code>arn:aws:s3:::my-bucket/build-log</code>.
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
        /// AWS CodePipeline, <code>location</code> should not be specified. If it is specified,
        /// AWS CodePipeline ignores it. This is because AWS CodePipeline uses the settings in
        /// a pipeline's source action instead of this value.</para></li><li><para>For source code in an AWS CodeCommit repository, the HTTPS clone URL to the repository
        /// that contains the source code and the build spec (for example, <code>https://git-codecommit.<i>region-ID</i>.amazonaws.com/v1/repos/<i>repo-name</i></code>).</para></li><li><para>For source code in an Amazon Simple Storage Service (Amazon S3) input bucket, one
        /// of the following. </para><ul><li><para> The path to the ZIP file that contains the source code (for example, <code><i>bucket-name</i>/<i>path</i>/<i>to</i>/<i>object-name</i>.zip</code>).
        /// </para></li><li><para> The path to the folder that contains the source code (for example, <code><i>bucket-name</i>/<i>path</i>/<i>to</i>/<i>source-code</i>/<i>folder</i>/</code>).
        /// </para></li></ul></li><li><para>For source code in a GitHub repository, the HTTPS clone URL to the repository that
        /// contains the source and the build spec. You must connect your AWS account to your
        /// GitHub account. Use the AWS CodeBuild console to start creating a build project. When
        /// you use the console to connect (or reconnect) with GitHub, on the GitHub <b>Authorize
        /// application</b> page, for <b>Organization access</b>, choose <b>Request access</b>
        /// next to each repository you want to allow AWS CodeBuild to have access to, and then
        /// choose <b>Authorize application</b>. (After you have connected to your GitHub account,
        /// you do not need to finish creating the build project. You can leave the AWS CodeBuild
        /// console.) To instruct AWS CodeBuild to use this connection, in the <code>source</code>
        /// object, set the <code>auth</code> object's <code>type</code> value to <code>OAUTH</code>.</para></li><li><para>For source code in a Bitbucket repository, the HTTPS clone URL to the repository that
        /// contains the source and the build spec. You must connect your AWS account to your
        /// Bitbucket account. Use the AWS CodeBuild console to start creating a build project.
        /// When you use the console to connect (or reconnect) with Bitbucket, on the Bitbucket
        /// <b>Confirm access to your account</b> page, choose <b>Grant access</b>. (After you
        /// have connected to your Bitbucket account, you do not need to finish creating the build
        /// project. You can leave the AWS CodeBuild console.) To instruct AWS CodeBuild to use
        /// this connection, in the <code>source</code> object, set the <code>auth</code> object's
        /// <code>type</code> value to <code>OAUTH</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_Location { get; set; }
        #endregion
        
        #region Parameter Cache_Mode
        /// <summary>
        /// <para>
        /// <para> If you use a <code>LOCAL</code> cache, the local cache mode. You can use one or more
        /// local cache modes at the same time. </para><ul><li><para><code>LOCAL_SOURCE_CACHE</code> mode caches Git metadata for primary and secondary
        /// sources. After the cache is created, subsequent builds pull only the change between
        /// commits. This mode is a good choice for projects with a clean working directory and
        /// a source that is a large Git repository. If you choose this option and your project
        /// does not use a Git repository (GitHub, GitHub Enterprise, or Bitbucket), the option
        /// is ignored. </para></li><li><para><code>LOCAL_DOCKER_LAYER_CACHE</code> mode caches existing Docker layers. This mode
        /// is a good choice for projects that build or pull large Docker images. It can prevent
        /// the performance issues caused by pulling large Docker images down from the network.
        /// </para><note><ul><li><para> You can use a Docker layer cache in the Linux environment only. </para></li><li><para> The <code>privileged</code> flag must be set so that your project has the required
        /// Docker permissions. </para></li><li><para> You should consider the security implications before you use a Docker layer cache.
        /// </para></li></ul></note></li></ul><ul><li><para><code>LOCAL_CUSTOM_CACHE</code> mode caches directories you specify in the buildspec
        /// file. This mode is a good choice if your build scenario is not suited to one of the
        /// other three local cache modes. If you use a custom cache: </para><ul><li><para> Only directories can be specified for caching. You cannot specify individual files.
        /// </para></li><li><para> Symlinks are used to reference cached directories. </para></li><li><para> Cached directories are linked to your build before it downloads its project sources.
        /// Cached items are overridden if a source item has the same name. Directories are specified
        /// using cache paths in the buildspec file. </para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Cache_Modes")]
        public System.String[] Cache_Mode { get; set; }
        #endregion
        
        #region Parameter Artifacts_Name
        /// <summary>
        /// <para>
        /// <para>Along with <code>path</code> and <code>namespaceType</code>, the pattern that AWS
        /// CodeBuild uses to name and store the output artifact:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, AWS CodePipeline ignores
        /// this value if specified. This is because AWS CodePipeline manages its build output
        /// names instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, this value is ignored if
        /// specified, because no build output is produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, this is the name of the output artifact
        /// object. If you set the name to be a forward slash ("/"), the artifact is stored in
        /// the root of the output bucket.</para></li></ul><para>For example:</para><ul><li><para> If <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>BUILD_ID</code>, and <code>name</code> is set to <code>MyArtifact.zip</code>,
        /// then the output artifact is stored in <code>MyArtifacts/<i>build-ID</i>/MyArtifact.zip</code>.
        /// </para></li><li><para> If <code>path</code> is empty, <code>namespaceType</code> is set to <code>NONE</code>,
        /// and <code>name</code> is set to "<code>/</code>", the output artifact is stored in
        /// the root of the output bucket. </para></li><li><para> If <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>BUILD_ID</code>, and <code>name</code> is set to "<code>/</code>",
        /// the output artifact is stored in <code>MyArtifacts/<i>build-ID</i></code>. </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Artifacts_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the build project.</para>
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
        /// <para>Along with <code>path</code> and <code>name</code>, the pattern that AWS CodeBuild
        /// uses to determine the name and location to store the output artifact:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, AWS CodePipeline ignores
        /// this value if specified. This is because AWS CodePipeline manages its build output
        /// names instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, this value is ignored if
        /// specified, because no build output is produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, valid values include:</para><ul><li><para><code>BUILD_ID</code>: Include the build ID in the location of the build output artifact.</para></li><li><para><code>NONE</code>: Do not include the build ID. This is the default if <code>namespaceType</code>
        /// is not specified.</para></li></ul></li></ul><para>For example, if <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>BUILD_ID</code>, and <code>name</code> is set to <code>MyArtifact.zip</code>,
        /// the output artifact is stored in <code>MyArtifacts/<i>build-ID</i>/MyArtifact.zip</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactNamespace")]
        public Amazon.CodeBuild.ArtifactNamespace Artifacts_NamespaceType { get; set; }
        #endregion
        
        #region Parameter Artifacts_OverrideArtifactName
        /// <summary>
        /// <para>
        /// <para> If this flag is set, a name specified in the build spec file overrides the artifact
        /// name. The name specified in a build spec file is calculated at build time and uses
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
        /// <para>The type of build output artifact to create:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, AWS CodePipeline ignores
        /// this value if specified. This is because AWS CodePipeline manages its build output
        /// artifacts instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, this value is ignored if
        /// specified, because no build output is produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, valid values include:</para><ul><li><para><code>NONE</code>: AWS CodeBuild creates in the output bucket a folder that contains
        /// the build output. This is the default if <code>packaging</code> is not specified.</para></li><li><para><code>ZIP</code>: AWS CodeBuild creates in the output bucket a ZIP file that contains
        /// the build output.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactPackaging")]
        public Amazon.CodeBuild.ArtifactPackaging Artifacts_Packaging { get; set; }
        #endregion
        
        #region Parameter Artifacts_Path
        /// <summary>
        /// <para>
        /// <para>Along with <code>namespaceType</code> and <code>name</code>, the pattern that AWS
        /// CodeBuild uses to name and store the output artifact:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, AWS CodePipeline ignores
        /// this value if specified. This is because AWS CodePipeline manages its build output
        /// names instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, this value is ignored if
        /// specified, because no build output is produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, this is the path to the output artifact.
        /// If <code>path</code> is not specified, <code>path</code> is not used.</para></li></ul><para>For example, if <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>NONE</code>, and <code>name</code> is set to <code>MyArtifact.zip</code>,
        /// the output artifact is stored in the output bucket at <code>MyArtifacts/MyArtifact.zip</code>.</para>
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
        /// interact with the Docker daemon fails. The default setting is <code>false</code>.</para><para>You can initialize the Docker daemon during the install phase of your build by adding
        /// one of the following sets of commands to the install phase of your buildspec file:</para><para>If the operating system's base image is Ubuntu Linux:</para><para><code>- nohup /usr/local/bin/dockerd --host=unix:///var/run/docker.sock --host=tcp://0.0.0.0:2375
        /// --storage-driver=overlay&amp;</code></para><para><code>- timeout 15 sh -c "until docker info; do echo .; sleep 1; done"</code></para><para>If the operating system's base image is Alpine Linux and the previous command does
        /// not work, add the <code>-t</code> argument to <code>timeout</code>:</para><para><code>- nohup /usr/local/bin/dockerd --host=unix:///var/run/docker.sock --host=tcp://0.0.0.0:2375
        /// --storage-driver=overlay&amp;</code></para><para><code>- timeout -t 15 sh -c "until docker info; do echo .; sleep 1; done"</code></para>
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
        /// or Bitbucket. If this is set and you use a different source provider, an invalidInputException
        /// is thrown. </para><note><para> The status of a build triggered by a webhook is always reported to your source provider.
        /// </para></note>
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
        /// <para> An array of <code>ProjectArtifacts</code> objects. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecondaryArtifacts")]
        public Amazon.CodeBuild.Model.ProjectArtifacts[] SecondaryArtifact { get; set; }
        #endregion
        
        #region Parameter SecondarySource
        /// <summary>
        /// <para>
        /// <para> An array of <code>ProjectSource</code> objects. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecondarySources")]
        public Amazon.CodeBuild.Model.ProjectSource[] SecondarySource { get; set; }
        #endregion
        
        #region Parameter SecondarySourceVersion
        /// <summary>
        /// <para>
        /// <para> An array of <code>ProjectSourceVersion</code> objects. If <code>secondarySourceVersions</code>
        /// is specified at the build level, then they take precedence over these <code>secondarySourceVersions</code>
        /// (at the project level). </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("SecondarySourceVersions")]
        public Amazon.CodeBuild.Model.ProjectSourceVersion[] SecondarySourceVersion { get; set; }
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
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The ARN of the AWS Identity and Access Management (IAM) role that enables AWS CodeBuild
        /// to interact with dependent AWS services on behalf of the AWS account.</para>
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
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter Source_SourceIdentifier
        /// <summary>
        /// <para>
        /// <para> An identifier for this project source. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Source_SourceIdentifier { get; set; }
        #endregion
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para> A version of the build input to be built for this project. If not specified, the
        /// latest version is used. If specified, it must be one of: </para><ul><li><para>For AWS CodeCommit: the commit ID, branch, or Git tag to use.</para></li><li><para>For GitHub: the commit ID, pull request ID, branch name, or tag name that corresponds
        /// to the version of the source code you want to build. If a pull request ID is specified,
        /// it must use the format <code>pr/pull-request-ID</code> (for example <code>pr/25</code>).
        /// If a branch name is specified, the branch's HEAD commit ID is used. If not specified,
        /// the default branch's HEAD commit ID is used.</para></li><li><para>For Bitbucket: the commit ID, branch name, or tag name that corresponds to the version
        /// of the source code you want to build. If a branch name is specified, the branch's
        /// HEAD commit ID is used. If not specified, the default branch's HEAD commit ID is used.</para></li><li><para>For Amazon Simple Storage Service (Amazon S3): the version ID of the object that represents
        /// the build input ZIP file to use.</para></li></ul><para> If <code>sourceVersion</code> is specified at the build level, then that version
        /// takes precedence over this <code>sourceVersion</code> (at the project level). </para><para> For more information, see <a href="https://docs.aws.amazon.com/codebuild/latest/userguide/sample-source-version.html">Source
        /// Version Sample with CodeBuild</a> in the <i>AWS CodeBuild User Guide</i>. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String SourceVersion { get; set; }
        #endregion
        
        #region Parameter CloudWatchLogs_Status
        /// <summary>
        /// <para>
        /// <para>The current status of the logs in Amazon CloudWatch Logs for a build project. Valid
        /// values are:</para><ul><li><para><code>ENABLED</code>: Amazon CloudWatch Logs are enabled for this build project.</para></li><li><para><code>DISABLED</code>: Amazon CloudWatch Logs are not enabled for this build project.</para></li></ul>
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
        /// <para>The current status of the S3 build logs. Valid values are:</para><ul><li><para><code>ENABLED</code>: S3 build logs are enabled for this build project.</para></li><li><para><code>DISABLED</code>: S3 build logs are not enabled for this build project.</para></li></ul>
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
        /// <para> The prefix of the stream name of the Amazon CloudWatch Logs. For more information,
        /// see <a href="https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/Working-with-log-groups-and-streams.html">Working
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
        /// <para>A set of tags for this build project.</para><para>These tags are available for use by AWS services that support AWS CodeBuild build
        /// project tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.CodeBuild.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>How long, in minutes, from 5 to 480 (8 hours), for AWS CodeBuild to wait before it
        /// times out any build that has not been marked as completed. The default is 60 minutes.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TimeoutInMinutes")]
        public System.Int32? TimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter Artifacts_Type
        /// <summary>
        /// <para>
        /// <para>The type of build output artifact. Valid values include:</para><ul><li><para><code>CODEPIPELINE</code>: The build project has build output generated through AWS
        /// CodePipeline. </para><note><para>The <code>CODEPIPELINE</code> type is not supported for <code>secondaryArtifacts</code>.</para></note></li><li><para><code>NO_ARTIFACTS</code>: The build project does not produce any build output.</para></li><li><para><code>S3</code>: The build project stores build output in Amazon Simple Storage Service
        /// (Amazon S3).</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactsType")]
        public Amazon.CodeBuild.ArtifactsType Artifacts_Type { get; set; }
        #endregion
        
        #region Parameter Cache_Type
        /// <summary>
        /// <para>
        /// <para>The type of cache used by the build project. Valid values include:</para><ul><li><para><code>NO_CACHE</code>: The build project does not use any cache.</para></li><li><para><code>S3</code>: The build project reads and writes from and to S3.</para></li><li><para><code>LOCAL</code>: The build project stores a cache locally on a build host that
        /// is only available to that build host.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CodeBuild.CacheType")]
        public Amazon.CodeBuild.CacheType Cache_Type { get; set; }
        #endregion
        
        #region Parameter Environment_Type
        /// <summary>
        /// <para>
        /// <para>The type of build environment to use for related builds.</para><ul><li><para>The environment type <code>ARM_CONTAINER</code> is available only in regions US East
        /// (N. Virginia), US East (Ohio), US West (Oregon), EU (Ireland), Asia Pacific (Mumbai),
        /// Asia Pacific (Tokyo), Asia Pacific (Sydney), and EU (Frankfurt).</para></li><li><para>The environment type <code>LINUX_CONTAINER</code> with compute type <code>build.general1.2xlarge</code>
        /// is available only in regions US East (N. Virginia), US East (N. Virginia), US West
        /// (Oregon), Canada (Central), EU (Ireland), EU (London), EU (Frankfurt), Asia Pacific
        /// (Tokyo), Asia Pacific (Seoul), Asia Pacific (Singapore), Asia Pacific (Sydney), China
        /// (Beijing), and China (Ningxia).</para></li><li><para>The environment type <code>LINUX_GPU_CONTAINER</code> is available only in regions
        /// US East (N. Virginia), US East (N. Virginia), US West (Oregon), Canada (Central),
        /// EU (Ireland), EU (London), EU (Frankfurt), Asia Pacific (Tokyo), Asia Pacific (Seoul),
        /// Asia Pacific (Singapore), Asia Pacific (Sydney) , China (Beijing), and China (Ningxia).</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.EnvironmentType")]
        public Amazon.CodeBuild.EnvironmentType Environment_Type { get; set; }
        #endregion
        
        #region Parameter Auth_Type
        /// <summary>
        /// <para>
        /// <note><para> This data type is deprecated and is no longer accurate or used. </para></note><para>The authorization type to use. The only valid value is <code>OAUTH</code>, which represents
        /// the OAuth authorization type.</para>
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
        /// <para>The type of repository that contains the source code to be built. Valid values include:</para><ul><li><para><code>BITBUCKET</code>: The source code is in a Bitbucket repository.</para></li><li><para><code>CODECOMMIT</code>: The source code is in an AWS CodeCommit repository.</para></li><li><para><code>CODEPIPELINE</code>: The source code settings are specified in the source action
        /// of a pipeline in AWS CodePipeline.</para></li><li><para><code>GITHUB</code>: The source code is in a GitHub repository.</para></li><li><para><code>GITHUB_ENTERPRISE</code>: The source code is in a GitHub Enterprise repository.</para></li><li><para><code>NO_SOURCE</code>: The project does not have input source code.</para></li><li><para><code>S3</code>: The source code is in an Amazon Simple Storage Service (Amazon S3)
        /// input bucket.</para></li></ul>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceType")]
        public Amazon.CodeBuild.SourceType Source_Type { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CodeBuild.Model.CreateProjectResponse).
        /// Specifying the name of a property of type Amazon.CodeBuild.Model.CreateProjectResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Project";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-CBProject (CreateProject)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CodeBuild.Model.CreateProjectResponse, NewCBProjectCmdlet>(Select) ??
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
            context.Artifacts_ArtifactIdentifier = this.Artifacts_ArtifactIdentifier;
            context.Artifacts_EncryptionDisabled = this.Artifacts_EncryptionDisabled;
            context.Artifacts_Location = this.Artifacts_Location;
            context.Artifacts_Name = this.Artifacts_Name;
            context.Artifacts_NamespaceType = this.Artifacts_NamespaceType;
            context.Artifacts_OverrideArtifactName = this.Artifacts_OverrideArtifactName;
            context.Artifacts_Packaging = this.Artifacts_Packaging;
            context.Artifacts_Path = this.Artifacts_Path;
            context.Artifacts_Type = this.Artifacts_Type;
            #if MODULAR
            if (this.Artifacts_Type == null && ParameterWasBound(nameof(this.Artifacts_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Artifacts_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BadgeEnabled = this.BadgeEnabled;
            context.Cache_Location = this.Cache_Location;
            if (this.Cache_Mode != null)
            {
                context.Cache_Mode = new List<System.String>(this.Cache_Mode);
            }
            context.Cache_Type = this.Cache_Type;
            context.Description = this.Description;
            context.EncryptionKey = this.EncryptionKey;
            context.Environment_Certificate = this.Environment_Certificate;
            context.Environment_ComputeType = this.Environment_ComputeType;
            #if MODULAR
            if (this.Environment_ComputeType == null && ParameterWasBound(nameof(this.Environment_ComputeType)))
            {
                WriteWarning("You are passing $null as a value for parameter Environment_ComputeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Environment_EnvironmentVariable != null)
            {
                context.Environment_EnvironmentVariable = new List<Amazon.CodeBuild.Model.EnvironmentVariable>(this.Environment_EnvironmentVariable);
            }
            context.Environment_Image = this.Environment_Image;
            #if MODULAR
            if (this.Environment_Image == null && ParameterWasBound(nameof(this.Environment_Image)))
            {
                WriteWarning("You are passing $null as a value for parameter Environment_Image which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Environment_ImagePullCredentialsType = this.Environment_ImagePullCredentialsType;
            context.Environment_PrivilegedMode = this.Environment_PrivilegedMode;
            context.RegistryCredential_Credential = this.RegistryCredential_Credential;
            context.RegistryCredential_CredentialProvider = this.RegistryCredential_CredentialProvider;
            context.Environment_Type = this.Environment_Type;
            #if MODULAR
            if (this.Environment_Type == null && ParameterWasBound(nameof(this.Environment_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Environment_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.CloudWatchLogs_GroupName = this.CloudWatchLogs_GroupName;
            context.CloudWatchLogs_Status = this.CloudWatchLogs_Status;
            context.CloudWatchLogs_StreamName = this.CloudWatchLogs_StreamName;
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
            #if MODULAR
            if (this.ServiceRole == null && ParameterWasBound(nameof(this.ServiceRole)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceRole which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Auth_Resource = this.Auth_Resource;
            context.Auth_Type = this.Auth_Type;
            context.Source_Buildspec = this.Source_Buildspec;
            context.Source_GitCloneDepth = this.Source_GitCloneDepth;
            context.GitSubmodulesConfig_FetchSubmodule = this.GitSubmodulesConfig_FetchSubmodule;
            context.Source_InsecureSsl = this.Source_InsecureSsl;
            context.Source_Location = this.Source_Location;
            context.Source_ReportBuildStatus = this.Source_ReportBuildStatus;
            context.Source_SourceIdentifier = this.Source_SourceIdentifier;
            context.Source_Type = this.Source_Type;
            #if MODULAR
            if (this.Source_Type == null && ParameterWasBound(nameof(this.Source_Type)))
            {
                WriteWarning("You are passing $null as a value for parameter Source_Type which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
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
            var request = new Amazon.CodeBuild.Model.CreateProjectRequest();
            
            
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
            if (cmdletContext.BadgeEnabled != null)
            {
                request.BadgeEnabled = cmdletContext.BadgeEnabled.Value;
            }
            
             // populate Cache
            var requestCacheIsNull = true;
            request.Cache = new Amazon.CodeBuild.Model.ProjectCache();
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
             // determine if request.Environment should be set to null
            if (requestEnvironmentIsNull)
            {
                request.Environment = null;
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
        
        private Amazon.CodeBuild.Model.CreateProjectResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.CreateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "CreateProject");
            try
            {
                #if DESKTOP
                return client.CreateProject(request);
                #elif CORECLR
                return client.CreateProjectAsync(request).GetAwaiter().GetResult();
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
            public System.String Artifacts_ArtifactIdentifier { get; set; }
            public System.Boolean? Artifacts_EncryptionDisabled { get; set; }
            public System.String Artifacts_Location { get; set; }
            public System.String Artifacts_Name { get; set; }
            public Amazon.CodeBuild.ArtifactNamespace Artifacts_NamespaceType { get; set; }
            public System.Boolean? Artifacts_OverrideArtifactName { get; set; }
            public Amazon.CodeBuild.ArtifactPackaging Artifacts_Packaging { get; set; }
            public System.String Artifacts_Path { get; set; }
            public Amazon.CodeBuild.ArtifactsType Artifacts_Type { get; set; }
            public System.Boolean? BadgeEnabled { get; set; }
            public System.String Cache_Location { get; set; }
            public List<System.String> Cache_Mode { get; set; }
            public Amazon.CodeBuild.CacheType Cache_Type { get; set; }
            public System.String Description { get; set; }
            public System.String EncryptionKey { get; set; }
            public System.String Environment_Certificate { get; set; }
            public Amazon.CodeBuild.ComputeType Environment_ComputeType { get; set; }
            public List<Amazon.CodeBuild.Model.EnvironmentVariable> Environment_EnvironmentVariable { get; set; }
            public System.String Environment_Image { get; set; }
            public Amazon.CodeBuild.ImagePullCredentialsType Environment_ImagePullCredentialsType { get; set; }
            public System.Boolean? Environment_PrivilegedMode { get; set; }
            public System.String RegistryCredential_Credential { get; set; }
            public Amazon.CodeBuild.CredentialProviderType RegistryCredential_CredentialProvider { get; set; }
            public Amazon.CodeBuild.EnvironmentType Environment_Type { get; set; }
            public System.String CloudWatchLogs_GroupName { get; set; }
            public Amazon.CodeBuild.LogsConfigStatusType CloudWatchLogs_Status { get; set; }
            public System.String CloudWatchLogs_StreamName { get; set; }
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
            public System.Func<Amazon.CodeBuild.Model.CreateProjectResponse, NewCBProjectCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Project;
        }
        
    }
}
