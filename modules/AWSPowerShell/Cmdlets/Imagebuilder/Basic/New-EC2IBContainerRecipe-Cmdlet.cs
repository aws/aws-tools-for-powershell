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
    /// Creates a new container recipe. Container recipes define how images are configured,
    /// tested, and assessed.
    /// </summary>
    [Cmdlet("New", "EC2IBContainerRecipe", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder CreateContainerRecipe API operation.", Operation = new[] {"CreateContainerRecipe"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.CreateContainerRecipeResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.CreateContainerRecipeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.CreateContainerRecipeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IBContainerRecipeCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InstanceConfiguration_BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>Defines the block devices to attach for building an instance from this Image Builder
        /// AMI.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("InstanceConfiguration_BlockDeviceMappings")]
        public Amazon.Imagebuilder.Model.InstanceBlockDeviceMapping[] InstanceConfiguration_BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter Component
        /// <summary>
        /// <para>
        /// <para>The components included in the container recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Components")]
        public Amazon.Imagebuilder.Model.ComponentConfiguration[] Component { get; set; }
        #endregion
        
        #region Parameter ContainerType
        /// <summary>
        /// <para>
        /// <para>The type of container to create.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Imagebuilder.ContainerType")]
        public Amazon.Imagebuilder.ContainerType ContainerType { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the container recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter DockerfileTemplateData
        /// <summary>
        /// <para>
        /// <para>The Dockerfile template used to build your image as an inline data blob.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DockerfileTemplateData { get; set; }
        #endregion
        
        #region Parameter DockerfileTemplateUri
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 URI for the Dockerfile that will be used to build your container image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DockerfileTemplateUri { get; set; }
        #endregion
        
        #region Parameter InstanceConfiguration_Image
        /// <summary>
        /// <para>
        /// <para>The base image for a container build and test instance. This can contain an AMI ID
        /// or it can specify an Amazon Web Services Systems Manager (SSM) Parameter Store Parameter,
        /// prefixed by <c>ssm:</c>, followed by the parameter name or ARN.</para><para>If not specified, Image Builder uses the appropriate ECS-optimized AMI as a base image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String InstanceConfiguration_Image { get; set; }
        #endregion
        
        #region Parameter ImageOsVersionOverride
        /// <summary>
        /// <para>
        /// <para>Specifies the operating system version for the base image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageOsVersionOverride { get; set; }
        #endregion
        
        #region Parameter KmsKeyId
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) that uniquely identifies which KMS key is used to encrypt
        /// the Dockerfile template. This can be either the Key ARN or the Alias ARN. For more
        /// information, see <a href="https://docs.aws.amazon.com/kms/latest/developerguide/concepts.html#key-id-key-ARN">Key
        /// identifiers (KeyId)</a> in the <i>Key Management Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KmsKeyId { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the container recipe.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ParentImage
        /// <summary>
        /// <para>
        /// <para>The base image for the container recipe.</para>
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
        public System.String ParentImage { get; set; }
        #endregion
        
        #region Parameter PlatformOverride
        /// <summary>
        /// <para>
        /// <para>Specifies the operating system platform when you use a custom base image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Imagebuilder.Platform")]
        public Amazon.Imagebuilder.Platform PlatformOverride { get; set; }
        #endregion
        
        #region Parameter TargetRepository_RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the container repository where the output container image is stored. This
        /// name is prefixed by the repository location. For example, <c>&lt;repository location
        /// url&gt;/repository_name</c>.</para>
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
        public System.String TargetRepository_RepositoryName { get; set; }
        #endregion
        
        #region Parameter SemanticVersion
        /// <summary>
        /// <para>
        /// <para>The semantic version of the container recipe. This version follows the semantic version
        /// syntax.</para><note><para>The semantic version has four nodes: &lt;major&gt;.&lt;minor&gt;.&lt;patch&gt;/&lt;build&gt;.
        /// You can assign values for the first three, and can filter on all of them.</para><para><b>Assignment:</b> For the first three nodes you can assign any positive integer
        /// value, including zero, with an upper limit of 2^30-1, or 1073741823 for each node.
        /// Image Builder automatically assigns the build number to the fourth node.</para><para><b>Patterns:</b> You can use any numeric pattern that adheres to the assignment requirements
        /// for the nodes that you can assign. For example, you might choose a software version
        /// pattern, such as 1.0.0, or a date, such as 2021.01.01.</para></note>
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
        public System.String SemanticVersion { get; set; }
        #endregion
        
        #region Parameter TargetRepository_Service
        /// <summary>
        /// <para>
        /// <para>Specifies the service in which this image was registered.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Imagebuilder.ContainerRepositoryService")]
        public Amazon.Imagebuilder.ContainerRepositoryService TargetRepository_Service { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>Tags that are attached to the container recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter WorkingDirectory
        /// <summary>
        /// <para>
        /// <para>The working directory for use during build and test workflows.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String WorkingDirectory { get; set; }
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ContainerRecipeArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.CreateContainerRecipeResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.CreateContainerRecipeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ContainerRecipeArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IBContainerRecipe (CreateContainerRecipe)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.CreateContainerRecipeResponse, NewEC2IBContainerRecipeCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ClientToken = this.ClientToken;
            if (this.Component != null)
            {
                context.Component = new List<Amazon.Imagebuilder.Model.ComponentConfiguration>(this.Component);
            }
            context.ContainerType = this.ContainerType;
            #if MODULAR
            if (this.ContainerType == null && ParameterWasBound(nameof(this.ContainerType)))
            {
                WriteWarning("You are passing $null as a value for parameter ContainerType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
            context.DockerfileTemplateData = this.DockerfileTemplateData;
            context.DockerfileTemplateUri = this.DockerfileTemplateUri;
            context.ImageOsVersionOverride = this.ImageOsVersionOverride;
            if (this.InstanceConfiguration_BlockDeviceMapping != null)
            {
                context.InstanceConfiguration_BlockDeviceMapping = new List<Amazon.Imagebuilder.Model.InstanceBlockDeviceMapping>(this.InstanceConfiguration_BlockDeviceMapping);
            }
            context.InstanceConfiguration_Image = this.InstanceConfiguration_Image;
            context.KmsKeyId = this.KmsKeyId;
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ParentImage = this.ParentImage;
            #if MODULAR
            if (this.ParentImage == null && ParameterWasBound(nameof(this.ParentImage)))
            {
                WriteWarning("You are passing $null as a value for parameter ParentImage which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PlatformOverride = this.PlatformOverride;
            context.SemanticVersion = this.SemanticVersion;
            #if MODULAR
            if (this.SemanticVersion == null && ParameterWasBound(nameof(this.SemanticVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter SemanticVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (System.String)(this.Tag[hashKey]));
                }
            }
            context.TargetRepository_RepositoryName = this.TargetRepository_RepositoryName;
            #if MODULAR
            if (this.TargetRepository_RepositoryName == null && ParameterWasBound(nameof(this.TargetRepository_RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetRepository_RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetRepository_Service = this.TargetRepository_Service;
            #if MODULAR
            if (this.TargetRepository_Service == null && ParameterWasBound(nameof(this.TargetRepository_Service)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetRepository_Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkingDirectory = this.WorkingDirectory;
            
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
            var request = new Amazon.Imagebuilder.Model.CreateContainerRecipeRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Component != null)
            {
                request.Components = cmdletContext.Component;
            }
            if (cmdletContext.ContainerType != null)
            {
                request.ContainerType = cmdletContext.ContainerType;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.DockerfileTemplateData != null)
            {
                request.DockerfileTemplateData = cmdletContext.DockerfileTemplateData;
            }
            if (cmdletContext.DockerfileTemplateUri != null)
            {
                request.DockerfileTemplateUri = cmdletContext.DockerfileTemplateUri;
            }
            if (cmdletContext.ImageOsVersionOverride != null)
            {
                request.ImageOsVersionOverride = cmdletContext.ImageOsVersionOverride;
            }
            
             // populate InstanceConfiguration
            var requestInstanceConfigurationIsNull = true;
            request.InstanceConfiguration = new Amazon.Imagebuilder.Model.InstanceConfiguration();
            List<Amazon.Imagebuilder.Model.InstanceBlockDeviceMapping> requestInstanceConfiguration_instanceConfiguration_BlockDeviceMapping = null;
            if (cmdletContext.InstanceConfiguration_BlockDeviceMapping != null)
            {
                requestInstanceConfiguration_instanceConfiguration_BlockDeviceMapping = cmdletContext.InstanceConfiguration_BlockDeviceMapping;
            }
            if (requestInstanceConfiguration_instanceConfiguration_BlockDeviceMapping != null)
            {
                request.InstanceConfiguration.BlockDeviceMappings = requestInstanceConfiguration_instanceConfiguration_BlockDeviceMapping;
                requestInstanceConfigurationIsNull = false;
            }
            System.String requestInstanceConfiguration_instanceConfiguration_Image = null;
            if (cmdletContext.InstanceConfiguration_Image != null)
            {
                requestInstanceConfiguration_instanceConfiguration_Image = cmdletContext.InstanceConfiguration_Image;
            }
            if (requestInstanceConfiguration_instanceConfiguration_Image != null)
            {
                request.InstanceConfiguration.Image = requestInstanceConfiguration_instanceConfiguration_Image;
                requestInstanceConfigurationIsNull = false;
            }
             // determine if request.InstanceConfiguration should be set to null
            if (requestInstanceConfigurationIsNull)
            {
                request.InstanceConfiguration = null;
            }
            if (cmdletContext.KmsKeyId != null)
            {
                request.KmsKeyId = cmdletContext.KmsKeyId;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ParentImage != null)
            {
                request.ParentImage = cmdletContext.ParentImage;
            }
            if (cmdletContext.PlatformOverride != null)
            {
                request.PlatformOverride = cmdletContext.PlatformOverride;
            }
            if (cmdletContext.SemanticVersion != null)
            {
                request.SemanticVersion = cmdletContext.SemanticVersion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
            }
            
             // populate TargetRepository
            var requestTargetRepositoryIsNull = true;
            request.TargetRepository = new Amazon.Imagebuilder.Model.TargetContainerRepository();
            System.String requestTargetRepository_targetRepository_RepositoryName = null;
            if (cmdletContext.TargetRepository_RepositoryName != null)
            {
                requestTargetRepository_targetRepository_RepositoryName = cmdletContext.TargetRepository_RepositoryName;
            }
            if (requestTargetRepository_targetRepository_RepositoryName != null)
            {
                request.TargetRepository.RepositoryName = requestTargetRepository_targetRepository_RepositoryName;
                requestTargetRepositoryIsNull = false;
            }
            Amazon.Imagebuilder.ContainerRepositoryService requestTargetRepository_targetRepository_Service = null;
            if (cmdletContext.TargetRepository_Service != null)
            {
                requestTargetRepository_targetRepository_Service = cmdletContext.TargetRepository_Service;
            }
            if (requestTargetRepository_targetRepository_Service != null)
            {
                request.TargetRepository.Service = requestTargetRepository_targetRepository_Service;
                requestTargetRepositoryIsNull = false;
            }
             // determine if request.TargetRepository should be set to null
            if (requestTargetRepositoryIsNull)
            {
                request.TargetRepository = null;
            }
            if (cmdletContext.WorkingDirectory != null)
            {
                request.WorkingDirectory = cmdletContext.WorkingDirectory;
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
        
        private Amazon.Imagebuilder.Model.CreateContainerRecipeResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.CreateContainerRecipeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "CreateContainerRecipe");
            try
            {
                #if DESKTOP
                return client.CreateContainerRecipe(request);
                #elif CORECLR
                return client.CreateContainerRecipeAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Imagebuilder.Model.ComponentConfiguration> Component { get; set; }
            public Amazon.Imagebuilder.ContainerType ContainerType { get; set; }
            public System.String Description { get; set; }
            public System.String DockerfileTemplateData { get; set; }
            public System.String DockerfileTemplateUri { get; set; }
            public System.String ImageOsVersionOverride { get; set; }
            public List<Amazon.Imagebuilder.Model.InstanceBlockDeviceMapping> InstanceConfiguration_BlockDeviceMapping { get; set; }
            public System.String InstanceConfiguration_Image { get; set; }
            public System.String KmsKeyId { get; set; }
            public System.String Name { get; set; }
            public System.String ParentImage { get; set; }
            public Amazon.Imagebuilder.Platform PlatformOverride { get; set; }
            public System.String SemanticVersion { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String TargetRepository_RepositoryName { get; set; }
            public Amazon.Imagebuilder.ContainerRepositoryService TargetRepository_Service { get; set; }
            public System.String WorkingDirectory { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.CreateContainerRecipeResponse, NewEC2IBContainerRecipeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ContainerRecipeArn;
        }
        
    }
}
