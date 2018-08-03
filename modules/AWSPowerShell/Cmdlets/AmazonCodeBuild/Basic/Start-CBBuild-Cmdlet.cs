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
    /// Starts running a build.
    /// </summary>
    [Cmdlet("Start", "CBBuild", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.CodeBuild.Model.Build")]
    [AWSCmdlet("Calls the AWS CodeBuild StartBuild API operation.", Operation = new[] {"StartBuild"})]
    [AWSCmdletOutput("Amazon.CodeBuild.Model.Build",
        "This cmdlet returns a Build object.",
        "The service call response (type Amazon.CodeBuild.Model.StartBuildResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class StartCBBuildCmdlet : AmazonCodeBuildClientCmdlet, IExecutor
    {
        
        #region Parameter BuildspecOverride
        /// <summary>
        /// <para>
        /// <para>A build spec declaration that overrides, for this build only, the latest one already
        /// defined in the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String BuildspecOverride { get; set; }
        #endregion
        
        #region Parameter CertificateOverride
        /// <summary>
        /// <para>
        /// <para>The name of a certificate for this build that overrides the one specified in the build
        /// project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CertificateOverride { get; set; }
        #endregion
        
        #region Parameter ComputeTypeOverride
        /// <summary>
        /// <para>
        /// <para>The name of a compute type for this build that overrides the one specified in the
        /// build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ComputeType")]
        public Amazon.CodeBuild.ComputeType ComputeTypeOverride { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_EncryptionDisabled
        /// <summary>
        /// <para>
        /// <para> Set to true if you do not want your output artifacts encrypted. This option is only
        /// valid if your artifacts type is Amazon S3. If this is set with another artifacts type,
        /// an invalidInputException will be thrown. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ArtifactsOverride_EncryptionDisabled { get; set; }
        #endregion
        
        #region Parameter EnvironmentTypeOverride
        /// <summary>
        /// <para>
        /// <para>A container type for this build that overrides the one specified in the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.EnvironmentType")]
        public Amazon.CodeBuild.EnvironmentType EnvironmentTypeOverride { get; set; }
        #endregion
        
        #region Parameter EnvironmentVariablesOverride
        /// <summary>
        /// <para>
        /// <para>A set of environment variables that overrides, for this build only, the latest ones
        /// already defined in the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public Amazon.CodeBuild.Model.EnvironmentVariable[] EnvironmentVariablesOverride { get; set; }
        #endregion
        
        #region Parameter GitCloneDepthOverride
        /// <summary>
        /// <para>
        /// <para>The user-defined depth of history, with a minimum value of 0, that overrides, for
        /// this build only, any previous depth of history defined in the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 GitCloneDepthOverride { get; set; }
        #endregion
        
        #region Parameter IdempotencyToken
        /// <summary>
        /// <para>
        /// <para>A unique, case sensitive identifier you provide to ensure the idempotency of the StartBuild
        /// request. The token is included in the StartBuild request and is valid for 12 hours.
        /// If you repeat the StartBuild request with the same token, but change a parameter,
        /// AWS CodeBuild returns a parameter mismatch error. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String IdempotencyToken { get; set; }
        #endregion
        
        #region Parameter ImageOverride
        /// <summary>
        /// <para>
        /// <para>The name of an image for this build that overrides the one specified in the build
        /// project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ImageOverride { get; set; }
        #endregion
        
        #region Parameter InsecureSslOverride
        /// <summary>
        /// <para>
        /// <para>Enable this flag to override the insecure SSL setting that is specified in the build
        /// project. The insecure SSL setting determines whether to ignore SSL warnings while
        /// connecting to the project source code. This override applies only if the build's source
        /// is GitHub Enterprise.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean InsecureSslOverride { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Location
        /// <summary>
        /// <para>
        /// <para>Information about the build output artifact location, as follows:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, then AWS CodePipeline will
        /// ignore this value if specified. This is because AWS CodePipeline manages its build
        /// output locations instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, then this value will be
        /// ignored if specified, because no build output will be produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, this is the name of the output bucket.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ArtifactsOverride_Location { get; set; }
        #endregion
        
        #region Parameter CacheOverride_Location
        /// <summary>
        /// <para>
        /// <para>Information about the cache location, as follows: </para><ul><li><para><code>NO_CACHE</code>: This value will be ignored.</para></li><li><para><code>S3</code>: This is the S3 bucket name/prefix.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String CacheOverride_Location { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Name
        /// <summary>
        /// <para>
        /// <para>Along with <code>path</code> and <code>namespaceType</code>, the pattern that AWS
        /// CodeBuild will use to name and store the output artifact, as follows:</para><ul><li><para>If <code>type</code> is set to <code>CODEPIPELINE</code>, then AWS CodePipeline will
        /// ignore this value if specified. This is because AWS CodePipeline manages its build
        /// output names instead of AWS CodeBuild.</para></li><li><para>If <code>type</code> is set to <code>NO_ARTIFACTS</code>, then this value will be
        /// ignored if specified, because no build output will be produced.</para></li><li><para>If <code>type</code> is set to <code>S3</code>, this is the name of the output artifact
        /// object. If you set the name to be a forward slash ("/"), then the artifact is stored
        /// in the root of the output bucket.</para></li></ul><para>For example:</para><ul><li><para> If <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>BUILD_ID</code>, and <code>name</code> is set to <code>MyArtifact.zip</code>,
        /// then the output artifact would be stored in <code>MyArtifacts/<i>build-ID</i>/MyArtifact.zip</code>.
        /// </para></li><li><para> If <code>path</code> is empty, <code>namespaceType</code> is set to <code>NONE</code>,
        /// and <code>name</code> is set to "<code>/</code>", then the output artifact would be
        /// stored in the root of the output bucket. </para></li><li><para> If <code>path</code> is set to <code>MyArtifacts</code>, <code>namespaceType</code>
        /// is set to <code>BUILD_ID</code>, and <code>name</code> is set to "<code>/</code>",
        /// then the output artifact would be stored in <code>MyArtifacts/<i>build-ID</i></code>.
        /// </para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ArtifactsOverride_Name { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_NamespaceType
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
        public Amazon.CodeBuild.ArtifactNamespace ArtifactsOverride_NamespaceType { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Packaging
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
        public Amazon.CodeBuild.ArtifactPackaging ArtifactsOverride_Packaging { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Path
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
        public System.String ArtifactsOverride_Path { get; set; }
        #endregion
        
        #region Parameter PrivilegedModeOverride
        /// <summary>
        /// <para>
        /// <para>Enable this flag to override privileged mode in the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean PrivilegedModeOverride { get; set; }
        #endregion
        
        #region Parameter ProjectName
        /// <summary>
        /// <para>
        /// <para>The name of the AWS CodeBuild build project to start running a build.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String ProjectName { get; set; }
        #endregion
        
        #region Parameter ReportBuildStatusOverride
        /// <summary>
        /// <para>
        /// <para> Set to true to report to your source provider the status of a build's start and completion.
        /// If you use this option with a source provider other than GitHub, an invalidInputException
        /// is thrown. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Boolean ReportBuildStatusOverride { get; set; }
        #endregion
        
        #region Parameter SourceAuthOverride_Resource
        /// <summary>
        /// <para>
        /// <para>The resource value that applies to the specified authorization type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceAuthOverride_Resource { get; set; }
        #endregion
        
        #region Parameter ServiceRoleOverride
        /// <summary>
        /// <para>
        /// <para>The name of a service role for this build that overrides the one specified in the
        /// build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String ServiceRoleOverride { get; set; }
        #endregion
        
        #region Parameter SourceLocationOverride
        /// <summary>
        /// <para>
        /// <para>A location that overrides for this build the source location for the one defined in
        /// the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceLocationOverride { get; set; }
        #endregion
        
        #region Parameter SourceTypeOverride
        /// <summary>
        /// <para>
        /// <para>A source input type for this build that overrides the source input defined in the
        /// build project</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceType")]
        public Amazon.CodeBuild.SourceType SourceTypeOverride { get; set; }
        #endregion
        
        #region Parameter SourceVersion
        /// <summary>
        /// <para>
        /// <para>A version of the build input to be built, for this build only. If not specified, the
        /// latest version will be used. If specified, must be one of:</para><ul><li><para>For AWS CodeCommit: the commit ID to use.</para></li><li><para>For GitHub: the commit ID, pull request ID, branch name, or tag name that corresponds
        /// to the version of the source code you want to build. If a pull request ID is specified,
        /// it must use the format <code>pr/pull-request-ID</code> (for example <code>pr/25</code>).
        /// If a branch name is specified, the branch's HEAD commit ID will be used. If not specified,
        /// the default branch's HEAD commit ID will be used.</para></li><li><para>For Bitbucket: the commit ID, branch name, or tag name that corresponds to the version
        /// of the source code you want to build. If a branch name is specified, the branch's
        /// HEAD commit ID will be used. If not specified, the default branch's HEAD commit ID
        /// will be used.</para></li><li><para>For Amazon Simple Storage Service (Amazon S3): the version ID of the object representing
        /// the build input ZIP file to use.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String SourceVersion { get; set; }
        #endregion
        
        #region Parameter TimeoutInMinutesOverride
        /// <summary>
        /// <para>
        /// <para>The number of build timeout minutes, from 5 to 480 (8 hours), that overrides, for
        /// this build only, the latest setting already defined in the build project.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 TimeoutInMinutesOverride { get; set; }
        #endregion
        
        #region Parameter ArtifactsOverride_Type
        /// <summary>
        /// <para>
        /// <para>The type of build output artifact. Valid values include:</para><ul><li><para><code>CODEPIPELINE</code>: The build project will have build output generated through
        /// AWS CodePipeline.</para></li><li><para><code>NO_ARTIFACTS</code>: The build project will not produce any build output.</para></li><li><para><code>S3</code>: The build project will store build output in Amazon Simple Storage
        /// Service (Amazon S3).</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.ArtifactsType")]
        public Amazon.CodeBuild.ArtifactsType ArtifactsOverride_Type { get; set; }
        #endregion
        
        #region Parameter CacheOverride_Type
        /// <summary>
        /// <para>
        /// <para>The type of cache used by the build project. Valid values include:</para><ul><li><para><code>NO_CACHE</code>: The build project will not use any cache.</para></li><li><para><code>S3</code>: The build project will read and write from/to S3.</para></li></ul>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.CacheType")]
        public Amazon.CodeBuild.CacheType CacheOverride_Type { get; set; }
        #endregion
        
        #region Parameter SourceAuthOverride_Type
        /// <summary>
        /// <para>
        /// <para>The authorization type to use. The only valid value is <code>OAUTH</code>, which represents
        /// the OAuth authorization type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CodeBuild.SourceAuthType")]
        public Amazon.CodeBuild.SourceAuthType SourceAuthOverride_Type { get; set; }
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg("ProjectName", MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-CBBuild (StartBuild)"))
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
            
            if (ParameterWasBound("ArtifactsOverride_EncryptionDisabled"))
                context.ArtifactsOverride_EncryptionDisabled = this.ArtifactsOverride_EncryptionDisabled;
            context.ArtifactsOverride_Location = this.ArtifactsOverride_Location;
            context.ArtifactsOverride_Name = this.ArtifactsOverride_Name;
            context.ArtifactsOverride_NamespaceType = this.ArtifactsOverride_NamespaceType;
            context.ArtifactsOverride_Packaging = this.ArtifactsOverride_Packaging;
            context.ArtifactsOverride_Path = this.ArtifactsOverride_Path;
            context.ArtifactsOverride_Type = this.ArtifactsOverride_Type;
            context.BuildspecOverride = this.BuildspecOverride;
            context.CacheOverride_Location = this.CacheOverride_Location;
            context.CacheOverride_Type = this.CacheOverride_Type;
            context.CertificateOverride = this.CertificateOverride;
            context.ComputeTypeOverride = this.ComputeTypeOverride;
            context.EnvironmentTypeOverride = this.EnvironmentTypeOverride;
            if (this.EnvironmentVariablesOverride != null)
            {
                context.EnvironmentVariablesOverride = new List<Amazon.CodeBuild.Model.EnvironmentVariable>(this.EnvironmentVariablesOverride);
            }
            if (ParameterWasBound("GitCloneDepthOverride"))
                context.GitCloneDepthOverride = this.GitCloneDepthOverride;
            context.IdempotencyToken = this.IdempotencyToken;
            context.ImageOverride = this.ImageOverride;
            if (ParameterWasBound("InsecureSslOverride"))
                context.InsecureSslOverride = this.InsecureSslOverride;
            if (ParameterWasBound("PrivilegedModeOverride"))
                context.PrivilegedModeOverride = this.PrivilegedModeOverride;
            context.ProjectName = this.ProjectName;
            if (ParameterWasBound("ReportBuildStatusOverride"))
                context.ReportBuildStatusOverride = this.ReportBuildStatusOverride;
            context.ServiceRoleOverride = this.ServiceRoleOverride;
            context.SourceAuthOverride_Resource = this.SourceAuthOverride_Resource;
            context.SourceAuthOverride_Type = this.SourceAuthOverride_Type;
            context.SourceLocationOverride = this.SourceLocationOverride;
            context.SourceTypeOverride = this.SourceTypeOverride;
            context.SourceVersion = this.SourceVersion;
            if (ParameterWasBound("TimeoutInMinutesOverride"))
                context.TimeoutInMinutesOverride = this.TimeoutInMinutesOverride;
            
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
            var request = new Amazon.CodeBuild.Model.StartBuildRequest();
            
            
             // populate ArtifactsOverride
            bool requestArtifactsOverrideIsNull = true;
            request.ArtifactsOverride = new Amazon.CodeBuild.Model.ProjectArtifacts();
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
            if (cmdletContext.BuildspecOverride != null)
            {
                request.BuildspecOverride = cmdletContext.BuildspecOverride;
            }
            
             // populate CacheOverride
            bool requestCacheOverrideIsNull = true;
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
            if (cmdletContext.IdempotencyToken != null)
            {
                request.IdempotencyToken = cmdletContext.IdempotencyToken;
            }
            if (cmdletContext.ImageOverride != null)
            {
                request.ImageOverride = cmdletContext.ImageOverride;
            }
            if (cmdletContext.InsecureSslOverride != null)
            {
                request.InsecureSslOverride = cmdletContext.InsecureSslOverride.Value;
            }
            if (cmdletContext.PrivilegedModeOverride != null)
            {
                request.PrivilegedModeOverride = cmdletContext.PrivilegedModeOverride.Value;
            }
            if (cmdletContext.ProjectName != null)
            {
                request.ProjectName = cmdletContext.ProjectName;
            }
            if (cmdletContext.ReportBuildStatusOverride != null)
            {
                request.ReportBuildStatusOverride = cmdletContext.ReportBuildStatusOverride.Value;
            }
            if (cmdletContext.ServiceRoleOverride != null)
            {
                request.ServiceRoleOverride = cmdletContext.ServiceRoleOverride;
            }
            
             // populate SourceAuthOverride
            bool requestSourceAuthOverrideIsNull = true;
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
            if (cmdletContext.TimeoutInMinutesOverride != null)
            {
                request.TimeoutInMinutesOverride = cmdletContext.TimeoutInMinutesOverride.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response.Build;
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
        
        private Amazon.CodeBuild.Model.StartBuildResponse CallAWSServiceOperation(IAmazonCodeBuild client, Amazon.CodeBuild.Model.StartBuildRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS CodeBuild", "StartBuild");
            try
            {
                #if DESKTOP
                return client.StartBuild(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.StartBuildAsync(request);
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
            public System.Boolean? ArtifactsOverride_EncryptionDisabled { get; set; }
            public System.String ArtifactsOverride_Location { get; set; }
            public System.String ArtifactsOverride_Name { get; set; }
            public Amazon.CodeBuild.ArtifactNamespace ArtifactsOverride_NamespaceType { get; set; }
            public Amazon.CodeBuild.ArtifactPackaging ArtifactsOverride_Packaging { get; set; }
            public System.String ArtifactsOverride_Path { get; set; }
            public Amazon.CodeBuild.ArtifactsType ArtifactsOverride_Type { get; set; }
            public System.String BuildspecOverride { get; set; }
            public System.String CacheOverride_Location { get; set; }
            public Amazon.CodeBuild.CacheType CacheOverride_Type { get; set; }
            public System.String CertificateOverride { get; set; }
            public Amazon.CodeBuild.ComputeType ComputeTypeOverride { get; set; }
            public Amazon.CodeBuild.EnvironmentType EnvironmentTypeOverride { get; set; }
            public List<Amazon.CodeBuild.Model.EnvironmentVariable> EnvironmentVariablesOverride { get; set; }
            public System.Int32? GitCloneDepthOverride { get; set; }
            public System.String IdempotencyToken { get; set; }
            public System.String ImageOverride { get; set; }
            public System.Boolean? InsecureSslOverride { get; set; }
            public System.Boolean? PrivilegedModeOverride { get; set; }
            public System.String ProjectName { get; set; }
            public System.Boolean? ReportBuildStatusOverride { get; set; }
            public System.String ServiceRoleOverride { get; set; }
            public System.String SourceAuthOverride_Resource { get; set; }
            public Amazon.CodeBuild.SourceAuthType SourceAuthOverride_Type { get; set; }
            public System.String SourceLocationOverride { get; set; }
            public Amazon.CodeBuild.SourceType SourceTypeOverride { get; set; }
            public System.String SourceVersion { get; set; }
            public System.Int32? TimeoutInMinutesOverride { get; set; }
        }
        
    }
}
