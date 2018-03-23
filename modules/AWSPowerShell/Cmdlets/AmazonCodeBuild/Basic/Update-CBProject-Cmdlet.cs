/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// Changes the settings of a build project.
    /// </summary>
    [Cmdlet("Update", "CBProject", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.Project")]
    [AWSCmdlet("Calls the AWS CodeBuild UpdateProject API operation.", Operation = new[] {"UpdateProject"})]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Project",
        "This cmdlet returns a Project object.",
        "The service call response (type Amazon.CodeBuild.Model.UpdateProjectResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateCBProjectCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        #region Parameter BadgeEnabled
        /// <summary>
        /// <para>
        /// <para>Set this to true to generate a publicly-accessible URL for your project's build badge.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean BadgeEnabled { get; set; }
        #endregion
        
        #region Parameter Source_Buildspec
        /// <summary>
        /// <para>
        /// <para>The build spec declaration to use for the builds in this build project.</para><para>If this value is not specified, a build spec must be included along with the source
        /// code to be built.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Source_Buildspec { get; set; }
        #endregion
        
        #region Parameter Environment_Certificate
        /// <summary>
        /// <para>
        /// <para>The certificate to use with this build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Environment_Certificate { get; set; }
        #endregion
        
        #region Parameter Environment_ComputeType
        /// <summary>
        /// <para>
        /// <para>Information about the compute resources the build project will use. Available values
        /// include:</para><ul><li><para><code>BUILD_GENERAL1_SMALL</code>: Use up to 3 GB memory and 2 vCPUs for builds.</para></li><li><para><code>BUILD_GENERAL1_MEDIUM</code>: Use up to 7 GB memory and 4 vCPUs for builds.</para></li><li><para><code>BUILD_GENERAL1_LARGE</code>: Use up to 15 GB memory and 8 vCPUs for builds.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ComputeType")]
        public Amazon.CodeBuild.ComputeType Environment_ComputeType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A new or replacement description of the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter EncryptionKey
        /// <summary>
        /// <para>
        /// <para>The replacement AWS Key Management Service (AWS KMS) customer master key (CMK) to
        /// be used for encrypting the build output artifacts.</para><para>You can specify either the CMK's Amazon Resource Name (ARN) or, if available, the
        /// CMK's alias (using the format <code>alias/<i>alias-name</i></code>).</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String EncryptionKey { get; set; }
        #endregion
        
        #region Parameter Environment_EnvironmentVariable
        /// <summary>
        /// <para>
        /// <para>A set of environment variables to make available to builds for this build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Environment_EnvironmentVariables")]
        public Amazon.CodeBuild.Model.EnvironmentVariable[] Environment_EnvironmentVariable { get; set; }
        #endregion
        
        #region Parameter Source_GitCloneDepth
        /// <summary>
        /// <para>
        /// <para>Information about the git clone depth for the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 Source_GitCloneDepth { get; set; }
        #endregion
        
        #region Parameter Environment_Image
        /// <summary>
        /// <para>
        /// <para>The ID of the Docker image to use for this build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Environment_Image { get; set; }
        #endregion
        
        #region Parameter Source_InsecureSsl
        /// <summary>
        /// <para>
        /// <para>Enable this flag to ignore SSL warnings while connecting to the project source code.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Source_InsecureSsl { get; set; }
        #endregion
        
        #region Parameter Artifacts_Location
        /// <summary>
        /// <para>
        /// <para>Information about the build output artifact location, as follows:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, then AWS CodePipeline will
        /// ignore this value if specified. This is because AWS CodePipeline manages its build
        /// output locations instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, then this value will be
        /// ignored if specified, because no build output will be produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, this is the name of the output bucket.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Artifacts_Location { get; set; }
        #endregion
        
        #region Parameter Cache_Location
        /// <summary>
        /// <para>
        /// <para>Information about the cache location, as follows: </para><ul><li><para><code>NO_CACHE</code>: This value will be ignored.</para></li><li><para><code>S3</code>: This is the S3 bucket name/prefix.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Cache_Location { get; set; }
        #endregion
        
        #region Parameter Source_Location
        /// <summary>
        /// <para>
        /// <para>Information about the location of the source code to be built. Valid values include:</para><ul><li><para>For source code settings that are specified in the source action of a pipeline in
        /// AWS CodePipeline, <code>location</code> should not be specified. If it is specified,
        /// AWS CodePipeline will ignore it. This is because AWS CodePipeline uses the settings
        /// in a pipeline's source action instead of this value.</para></li><li><para>For source code in an AWS CodeCommit repository, the HTTPS clone URL to the repository
        /// that contains the source code and the build spec (for example, <code>https://git-codecommit.<i>region-ID</i>.amazonaws.com/v1/repos/<i>repo-name</i></code>).</para></li><li><para>For source code in an Amazon Simple Storage Service (Amazon S3) input bucket, the
        /// path to the ZIP file that contains the source code (for example, <code><i>bucket-name</i>/<i>path</i>/<i>to</i>/<i>object-name</i>.zip</code>)</para></li><li><para>For source code in a GitHub repository, the HTTPS clone URL to the repository that
        /// contains the source and the build spec. Also, you must connect your AWS account to
        /// your GitHub account. To do this, use the AWS CodeBuild console to begin creating a
        /// build project. When you use the console to connect (or reconnect) with GitHub, on
        /// the GitHub <b>Authorize application</b> page that displays, for <b>Organization access</b>,
        /// choose <b>Request access</b> next to each repository you want to allow AWS CodeBuild
        /// to have access to. Then choose <b>Authorize application</b>. (After you have connected
        /// to your GitHub account, you do not need to finish creating the build project, and
        /// you may then leave the AWS CodeBuild console.) To instruct AWS CodeBuild to then use
        /// this connection, in the <code>source</code> object, set the <code>auth</code> object's
        /// <code>type</code> value to <code>OAUTH</code>.</para></li><li><para>For source code in a Bitbucket repository, the HTTPS clone URL to the repository that
        /// contains the source and the build spec. Also, you must connect your AWS account to
        /// your Bitbucket account. To do this, use the AWS CodeBuild console to begin creating
        /// a build project. When you use the console to connect (or reconnect) with Bitbucket,
        /// on the Bitbucket <b>Confirm access to your account</b> page that displays, choose
        /// <b>Grant access</b>. (After you have connected to your Bitbucket account, you do not
        /// need to finish creating the build project, and you may then leave the AWS CodeBuild
        /// console.) To instruct AWS CodeBuild to then use this connection, in the <code>source</code>
        /// object, set the <code>auth</code> object's <code>type</code> value to <code>OAUTH</code>.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Source_Location { get; set; }
        #endregion
        
        #region Parameter Artifacts_Name
        /// <summary>
        /// <para>
        /// <para>Along with <code>path</code> and <code>namespaceType</code>, the pattern that AWS
        /// CodeBuild will use to name and store the output artifact, as follows:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, then AWS CodePipeline will
        /// ignore this value if specified. This is because AWS CodePipeline manages its build
        /// output names instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, then this value will be
        /// ignored if specified, because no build output will be produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, this is the name of the output artifact
        /// object.</para></li></ul><para>For example, if <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>BUILD_ID</code>, and <code>name</code> is set to <code>MyArtifact.zip</code>,
        /// then the output artifact would be stored in <code>MyArtifacts/<i>build-ID</i>/MyArtifact.zip</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Artifacts_Name { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the build project.</para><note><para>You cannot change a build project's name.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter Artifacts_NamespaceType
        /// <summary>
        /// <para>
        /// <para>Along with <code>path</code> and <code>name</code>, the pattern that AWS CodeBuild
        /// will use to determine the name and location to store the output artifact, as follows:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, then AWS CodePipeline will
        /// ignore this value if specified. This is because AWS CodePipeline manages its build
        /// output names instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, then this value will be
        /// ignored if specified, because no build output will be produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, then valid values include:</para><ul><li><para><code>BUILD_ID</code>: Include the build ID in the location of the build output artifact.</para></li><li><para><code>NONE</code>: Do not include the build ID. This is the default if <code>namespaceType</code>
        /// is not specified.</para></li></ul></li></ul><para>For example, if <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>BUILD_ID</code>, and <code>name</code> is set to <code>MyArtifact.zip</code>,
        /// then the output artifact would be stored in <code>MyArtifacts/<i>build-ID</i>/MyArtifact.zip</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactNamespace")]
        public Amazon.CodeBuild.ArtifactNamespace Artifacts_NamespaceType { get; set; }
        #endregion
        
        #region Parameter Artifacts_Packaging
        /// <summary>
        /// <para>
        /// <para>The type of build output artifact to create, as follows:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, then AWS CodePipeline will
        /// ignore this value if specified. This is because AWS CodePipeline manages its build
        /// output artifacts instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, then this value will be
        /// ignored if specified, because no build output will be produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, valid values include:</para><ul><li><para><code>NONE</code>: AWS CodeBuild will create in the output bucket a folder containing
        /// the build output. This is the default if <code>packaging</code> is not specified.</para></li><li><para><code>ZIP</code>: AWS CodeBuild will create in the output bucket a ZIP file containing
        /// the build output.</para></li></ul></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactPackaging")]
        public Amazon.CodeBuild.ArtifactPackaging Artifacts_Packaging { get; set; }
        #endregion
        
        #region Parameter Artifacts_Path
        /// <summary>
        /// <para>
        /// <para>Along with <code>namespaceType</code> and <code>name</code>, the pattern that AWS
        /// CodeBuild will use to name and store the output artifact, as follows:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, then AWS CodePipeline will
        /// ignore this value if specified. This is because AWS CodePipeline manages its build
        /// output names instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, then this value will be
        /// ignored if specified, because no build output will be produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, this is the path to the output artifact.
        /// If <code>path</code> is not specified, then <code>path</code> will not be used.</para></li></ul><para>For example, if <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>NONE</code>, and <code>name</code> is set to <code>MyArtifact.zip</code>,
        /// then the output artifact would be stored in the output bucket at <code>MyArtifacts/MyArtifact.zip</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String Artifacts_Path { get; set; }
        #endregion
        
        #region Parameter Environment_PrivilegedMode
        /// <summary>
        /// <para>
        /// <para>Enables running the Docker daemon inside a Docker container. Set to true only if the
        /// build project is be used to build Docker images, and the specified build environment
        /// image is not provided by AWS CodeBuild with Docker support. Otherwise, all associated
        /// builds that attempt to interact with the Docker daemon will fail. Note that you must
        /// also start the Docker daemon so that builds can interact with it. One way to do this
        /// is to initialize the Docker daemon during the install phase of your build spec by
        /// running the following build commands. (Do not run the following build commands if
        /// the specified build environment image is provided by AWS CodeBuild with Docker support.)</para><para><code>- nohup /usr/local/bin/dockerd --host=unix:///var/run/docker.sock --host=tcp://0.0.0.0:2375
        /// --storage-driver=overlay&amp; - timeout -t 15 sh -c "until docker info; do echo .;
        /// sleep 1; done"</code></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean Environment_PrivilegedMode { get; set; }
        #endregion
        
        #region Parameter Auth_Resource
        /// <summary>
        /// <para>
        /// <para>The resource value that applies to the specified authorization type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Source_Auth_Resource")]
        public System.String Auth_Resource { get; set; }
        #endregion
        
        #region Parameter VpcConfig_SecurityGroupId
        /// <summary>
        /// <para>
        /// <para>A list of one or more security groups IDs in your Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcConfig_SecurityGroupIds")]
        public System.String[] VpcConfig_SecurityGroupId { get; set; }
        #endregion
        
        #region Parameter ServiceRole
        /// <summary>
        /// <para>
        /// <para>The replacement ARN of the AWS Identity and Access Management (IAM) role that enables
        /// AWS CodeBuild to interact with dependent AWS services on behalf of the AWS account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRole { get; set; }
        #endregion
        
        #region Parameter VpcConfig_Subnet
        /// <summary>
        /// <para>
        /// <para>A list of one or more subnet IDs in your Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("VpcConfig_Subnets")]
        public System.String[] VpcConfig_Subnet { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The replacement set of tags for this build project.</para><para>These tags are available for use by AWS services that support AWS CodeBuild build
        /// project tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Tags")]
        public Amazon.CodeBuild.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter TimeoutInMinute
        /// <summary>
        /// <para>
        /// <para>The replacement value in minutes, from 5 to 480 (8 hours), for AWS CodeBuild to wait
        /// before timing out any related build that did not get marked as completed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TimeoutInMinutes")]
        public System.Int32 TimeoutInMinute { get; set; }
        #endregion
        
        #region Parameter Artifacts_Type
        /// <summary>
        /// <para>
        /// <para>The type of build output artifact. Valid values include:</para><ul><li><para><code>CODEPIPELINE</code>: The build project will have build output generated through
        /// AWS CodePipeline.</para></li><li><para><code>NO_ARTIFACTS</code>: The build project will not produce any build output.</para></li><li><para><code>S3</code>: The build project will store build output in Amazon Simple Storage
        /// Service (Amazon S3).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactsType")]
        public Amazon.CodeBuild.ArtifactsType Artifacts_Type { get; set; }
        #endregion
        
        #region Parameter Cache_Type
        /// <summary>
        /// <para>
        /// <para>The type of cache used by the build project. Valid values include:</para><ul><li><para><code>NO_CACHE</code>: The build project will not use any cache.</para></li><li><para><code>S3</code>: The build project will read and write from/to S3.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.CacheType")]
        public Amazon.CodeBuild.CacheType Cache_Type { get; set; }
        #endregion
        
        #region Parameter Environment_Type
        /// <summary>
        /// <para>
        /// <para>The type of build environment to use for related builds.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.EnvironmentType")]
        public Amazon.CodeBuild.EnvironmentType Environment_Type { get; set; }
        #endregion
        
        #region Parameter Auth_Type
        /// <summary>
        /// <para>
        /// <para>The authorization type to use. The only valid value is <code>OAUTH</code>, which represents
        /// the OAuth authorization type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("Source_Auth_Type")]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceAuthType")]
        public Amazon.CodeBuild.SourceAuthType Auth_Type { get; set; }
        #endregion
        
        #region Parameter Source_Type
        /// <summary>
        /// <para>
        /// <para>The type of repository that contains the source code to be built. Valid values include:</para><ul><li><para><code>BITBUCKET</code>: The source code is in a Bitbucket repository.</para></li><li><para><code>CODECOMMIT</code>: The source code is in an AWS CodeCommit repository.</para></li><li><para><code>CODEPIPELINE</code>: The source code settings are specified in the source action
        /// of a pipeline in AWS CodePipeline.</para></li><li><para><code>GITHUB</code>: The source code is in a GitHub repository.</para></li><li><para><code>S3</code>: The source code is in an Amazon Simple Storage Service (Amazon S3)
        /// input bucket.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceType")]
        public Amazon.CodeBuild.SourceType Source_Type { get; set; }
        #endregion
        
        #region Parameter VpcConfig_VpcId
        /// <summary>
        /// <para>
        /// <para>The ID of the Amazon VPC.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String VpcConfig_VpcId { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("Name", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-CBProject (UpdateProject)"))
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
            
            context.Artifacts_Location = this.Artifacts_Location;
            context.Artifacts_Name = this.Artifacts_Name;
            context.Artifacts_NamespaceType = this.Artifacts_NamespaceType;
            context.Artifacts_Packaging = this.Artifacts_Packaging;
            context.Artifacts_Path = this.Artifacts_Path;
            context.Artifacts_Type = this.Artifacts_Type;
            if (ParameterWasBound("BadgeEnabled"))
                context.BadgeEnabled = this.BadgeEnabled;
            context.Cache_Location = this.Cache_Location;
            context.Cache_Type = this.Cache_Type;
            context.Description = this.Description;
            context.EncryptionKey = this.EncryptionKey;
            context.Environment_Certificate = this.Environment_Certificate;
            context.Environment_ComputeType = this.Environment_ComputeType;
            if (this.Environment_EnvironmentVariable != null)
            {
                context.Environment_EnvironmentVariables = new List<Amazon.CodeBuild.Model.EnvironmentVariable>(this.Environment_EnvironmentVariable);
            }
            context.Environment_Image = this.Environment_Image;
            if (ParameterWasBound("Environment_PrivilegedMode"))
                context.Environment_PrivilegedMode = this.Environment_PrivilegedMode;
            context.Environment_Type = this.Environment_Type;
            context.Name = this.Name;
            context.ServiceRole = this.ServiceRole;
            context.Source_Auth_Resource = this.Auth_Resource;
            context.Source_Auth_Type = this.Auth_Type;
            context.Source_Buildspec = this.Source_Buildspec;
            if (ParameterWasBound("Source_GitCloneDepth"))
                context.Source_GitCloneDepth = this.Source_GitCloneDepth;
            if (ParameterWasBound("Source_InsecureSsl"))
                context.Source_InsecureSsl = this.Source_InsecureSsl;
            context.Source_Location = this.Source_Location;
            context.Source_Type = this.Source_Type;
            if (this.Tag != null)
            {
                context.Tags = new List<Amazon.CodeBuild.Model.Tag>(this.Tag);
            }
            if (ParameterWasBound("TimeoutInMinute"))
                context.TimeoutInMinutes = this.TimeoutInMinute;
            if (this.VpcConfig_SecurityGroupId != null)
            {
                context.VpcConfig_SecurityGroupIds = new List<System.String>(this.VpcConfig_SecurityGroupId);
            }
            if (this.VpcConfig_Subnet != null)
            {
                context.VpcConfig_Subnets = new List<System.String>(this.VpcConfig_Subnet);
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
            bool requestArtifactsIsNull = true;
            request.Artifacts = new Amazon.CodeBuild.Model.ProjectArtifacts();
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
            bool requestCacheIsNull = true;
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
            bool requestEnvironmentIsNull = true;
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
            if (cmdletContext.Environment_EnvironmentVariables != null)
            {
                requestEnvironment_environment_EnvironmentVariable = cmdletContext.Environment_EnvironmentVariables;
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
             // determine if request.Environment should be set to null
            if (requestEnvironmentIsNull)
            {
                request.Environment = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ServiceRole != null)
            {
                request.ServiceRole = cmdletContext.ServiceRole;
            }
            
             // populate Source
            bool requestSourceIsNull = true;
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
            Amazon.CodeBuild.Model.SourceAuth requestSource_source_Auth = null;
            
             // populate Auth
            bool requestSource_source_AuthIsNull = true;
            requestSource_source_Auth = new Amazon.CodeBuild.Model.SourceAuth();
            System.String requestSource_source_Auth_auth_Resource = null;
            if (cmdletContext.Source_Auth_Resource != null)
            {
                requestSource_source_Auth_auth_Resource = cmdletContext.Source_Auth_Resource;
            }
            if (requestSource_source_Auth_auth_Resource != null)
            {
                requestSource_source_Auth.Resource = requestSource_source_Auth_auth_Resource;
                requestSource_source_AuthIsNull = false;
            }
            Amazon.CodeBuild.SourceAuthType requestSource_source_Auth_auth_Type = null;
            if (cmdletContext.Source_Auth_Type != null)
            {
                requestSource_source_Auth_auth_Type = cmdletContext.Source_Auth_Type;
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
            if (cmdletContext.Tags != null)
            {
                request.Tags = cmdletContext.Tags;
            }
            if (cmdletContext.TimeoutInMinutes != null)
            {
                request.TimeoutInMinutes = cmdletContext.TimeoutInMinutes.Value;
            }
            
             // populate VpcConfig
            bool requestVpcConfigIsNull = true;
            request.VpcConfig = new Amazon.CodeBuild.Model.VpcConfig();
            List<System.String> requestVpcConfig_vpcConfig_SecurityGroupId = null;
            if (cmdletContext.VpcConfig_SecurityGroupIds != null)
            {
                requestVpcConfig_vpcConfig_SecurityGroupId = cmdletContext.VpcConfig_SecurityGroupIds;
            }
            if (requestVpcConfig_vpcConfig_SecurityGroupId != null)
            {
                request.VpcConfig.SecurityGroupIds = requestVpcConfig_vpcConfig_SecurityGroupId;
                requestVpcConfigIsNull = false;
            }
            List<System.String> requestVpcConfig_vpcConfig_Subnet = null;
            if (cmdletContext.VpcConfig_Subnets != null)
            {
                requestVpcConfig_vpcConfig_Subnet = cmdletContext.VpcConfig_Subnets;
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
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Project;
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
        
        private Amazon.CodeBuild.Model.UpdateProjectResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.UpdateProjectRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "UpdateProject");
            try
            {
                #if DESKTOP
                return client.UpdateProject(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.UpdateProjectAsync(request);
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
            public System.String Artifacts_Location { get; set; }
            public System.String Artifacts_Name { get; set; }
            public Amazon.CodeBuild.ArtifactNamespace Artifacts_NamespaceType { get; set; }
            public Amazon.CodeBuild.ArtifactPackaging Artifacts_Packaging { get; set; }
            public System.String Artifacts_Path { get; set; }
            public Amazon.CodeBuild.ArtifactsType Artifacts_Type { get; set; }
            public System.Boolean? BadgeEnabled { get; set; }
            public System.String Cache_Location { get; set; }
            public Amazon.CodeBuild.CacheType Cache_Type { get; set; }
            public System.String Description { get; set; }
            public System.String EncryptionKey { get; set; }
            public System.String Environment_Certificate { get; set; }
            public Amazon.CodeBuild.ComputeType Environment_ComputeType { get; set; }
            public List<Amazon.CodeBuild.Model.EnvironmentVariable> Environment_EnvironmentVariables { get; set; }
            public System.String Environment_Image { get; set; }
            public System.Boolean? Environment_PrivilegedMode { get; set; }
            public Amazon.CodeBuild.EnvironmentType Environment_Type { get; set; }
            public System.String Name { get; set; }
            public System.String ServiceRole { get; set; }
            public System.String Source_Auth_Resource { get; set; }
            public Amazon.CodeBuild.SourceAuthType Source_Auth_Type { get; set; }
            public System.String Source_Buildspec { get; set; }
            public System.Int32? Source_GitCloneDepth { get; set; }
            public System.Boolean? Source_InsecureSsl { get; set; }
            public System.String Source_Location { get; set; }
            public Amazon.CodeBuild.SourceType Source_Type { get; set; }
            public List<Amazon.CodeBuild.Model.Tag> Tags { get; set; }
            public System.Int32? TimeoutInMinutes { get; set; }
            public List<System.String> VpcConfig_SecurityGroupIds { get; set; }
            public List<System.String> VpcConfig_Subnets { get; set; }
            public System.String VpcConfig_VpcId { get; set; }
        }
        
    }
}
