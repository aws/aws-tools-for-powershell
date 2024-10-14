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
using Amazon.Imagebuilder;
using Amazon.Imagebuilder.Model;

namespace Amazon.PowerShell.Cmdlets.EC2IB
{
    /// <summary>
    /// Creates a new image recipe. Image recipes define how images are configured, tested,
    /// and assessed.
    /// </summary>
    [Cmdlet("New", "EC2IBImageRecipe", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder CreateImageRecipe API operation.", Operation = new[] {"CreateImageRecipe"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.CreateImageRecipeResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.CreateImageRecipeResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.CreateImageRecipeResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewEC2IBImageRecipeCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter BlockDeviceMapping
        /// <summary>
        /// <para>
        /// <para>The block device mappings of the image recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("BlockDeviceMappings")]
        public Amazon.Imagebuilder.Model.InstanceBlockDeviceMapping[] BlockDeviceMapping { get; set; }
        #endregion
        
        #region Parameter Component
        /// <summary>
        /// <para>
        /// <para>The components included in the image recipe.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("Components")]
        public Amazon.Imagebuilder.Model.ComponentConfiguration[] Component { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The description of the image recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the image recipe.</para>
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
        
        #region Parameter ParentImage
        /// <summary>
        /// <para>
        /// <para>The base image of the image recipe. The value of the string can be the ARN of the
        /// base image or an AMI ID. The format for the ARN follows this example: <c>arn:aws:imagebuilder:us-west-2:aws:image/windows-server-2016-english-full-base-x86/x.x.x</c>.
        /// You can provide the specific version that you want to use, or you can use a wildcard
        /// in all of the fields. If you enter an AMI ID for the string value, you must have access
        /// to the AMI, and the AMI must be in the same Region in which you are using Image Builder.</para>
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
        
        #region Parameter SemanticVersion
        /// <summary>
        /// <para>
        /// <para>The semantic version of the image recipe. This version follows the semantic version
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags of the image recipe.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter SystemsManagerAgent_UninstallAfterBuild
        /// <summary>
        /// <para>
        /// <para>Controls whether the Systems Manager agent is removed from your final build image,
        /// prior to creating the new AMI. If this is set to true, then the agent is removed from
        /// the final image. If it's set to false, then the agent is left in, so that it is included
        /// in the new AMI. The default value is false.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("AdditionalInstanceConfiguration_SystemsManagerAgent_UninstallAfterBuild")]
        public System.Boolean? SystemsManagerAgent_UninstallAfterBuild { get; set; }
        #endregion
        
        #region Parameter AdditionalInstanceConfiguration_UserDataOverride
        /// <summary>
        /// <para>
        /// <para>Use this property to provide commands or a command script to run when you launch your
        /// build instance.</para><para>The userDataOverride property replaces any commands that Image Builder might have
        /// added to ensure that Systems Manager is installed on your Linux build instance. If
        /// you override the user data, make sure that you add commands to install Systems Manager,
        /// if it is not pre-installed on your base image.</para><note><para>The user data is always base 64 encoded. For example, the following commands are encoded
        /// as <c>IyEvYmluL2Jhc2gKbWtkaXIgLXAgL3Zhci9iYi8KdG91Y2ggL3Zhci$</c>:</para><para><i>#!/bin/bash</i></para><para>mkdir -p /var/bb/</para><para>touch /var</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AdditionalInstanceConfiguration_UserDataOverride { get; set; }
        #endregion
        
        #region Parameter WorkingDirectory
        /// <summary>
        /// <para>
        /// <para>The working directory used during build and test workflows.</para>
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
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageRecipeArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.CreateImageRecipeResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.CreateImageRecipeResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageRecipeArn";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IBImageRecipe (CreateImageRecipe)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.CreateImageRecipeResponse, NewEC2IBImageRecipeCmdlet>(Select) ??
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
            context.SystemsManagerAgent_UninstallAfterBuild = this.SystemsManagerAgent_UninstallAfterBuild;
            context.AdditionalInstanceConfiguration_UserDataOverride = this.AdditionalInstanceConfiguration_UserDataOverride;
            if (this.BlockDeviceMapping != null)
            {
                context.BlockDeviceMapping = new List<Amazon.Imagebuilder.Model.InstanceBlockDeviceMapping>(this.BlockDeviceMapping);
            }
            context.ClientToken = this.ClientToken;
            if (this.Component != null)
            {
                context.Component = new List<Amazon.Imagebuilder.Model.ComponentConfiguration>(this.Component);
            }
            #if MODULAR
            if (this.Component == null && ParameterWasBound(nameof(this.Component)))
            {
                WriteWarning("You are passing $null as a value for parameter Component which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Description = this.Description;
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
            var request = new Amazon.Imagebuilder.Model.CreateImageRecipeRequest();
            
            
             // populate AdditionalInstanceConfiguration
            var requestAdditionalInstanceConfigurationIsNull = true;
            request.AdditionalInstanceConfiguration = new Amazon.Imagebuilder.Model.AdditionalInstanceConfiguration();
            System.String requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_UserDataOverride = null;
            if (cmdletContext.AdditionalInstanceConfiguration_UserDataOverride != null)
            {
                requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_UserDataOverride = cmdletContext.AdditionalInstanceConfiguration_UserDataOverride;
            }
            if (requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_UserDataOverride != null)
            {
                request.AdditionalInstanceConfiguration.UserDataOverride = requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_UserDataOverride;
                requestAdditionalInstanceConfigurationIsNull = false;
            }
            Amazon.Imagebuilder.Model.SystemsManagerAgent requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent = null;
            
             // populate SystemsManagerAgent
            var requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgentIsNull = true;
            requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent = new Amazon.Imagebuilder.Model.SystemsManagerAgent();
            System.Boolean? requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent_systemsManagerAgent_UninstallAfterBuild = null;
            if (cmdletContext.SystemsManagerAgent_UninstallAfterBuild != null)
            {
                requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent_systemsManagerAgent_UninstallAfterBuild = cmdletContext.SystemsManagerAgent_UninstallAfterBuild.Value;
            }
            if (requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent_systemsManagerAgent_UninstallAfterBuild != null)
            {
                requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent.UninstallAfterBuild = requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent_systemsManagerAgent_UninstallAfterBuild.Value;
                requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgentIsNull = false;
            }
             // determine if requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent should be set to null
            if (requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgentIsNull)
            {
                requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent = null;
            }
            if (requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent != null)
            {
                request.AdditionalInstanceConfiguration.SystemsManagerAgent = requestAdditionalInstanceConfiguration_additionalInstanceConfiguration_SystemsManagerAgent;
                requestAdditionalInstanceConfigurationIsNull = false;
            }
             // determine if request.AdditionalInstanceConfiguration should be set to null
            if (requestAdditionalInstanceConfigurationIsNull)
            {
                request.AdditionalInstanceConfiguration = null;
            }
            if (cmdletContext.BlockDeviceMapping != null)
            {
                request.BlockDeviceMappings = cmdletContext.BlockDeviceMapping;
            }
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.Component != null)
            {
                request.Components = cmdletContext.Component;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ParentImage != null)
            {
                request.ParentImage = cmdletContext.ParentImage;
            }
            if (cmdletContext.SemanticVersion != null)
            {
                request.SemanticVersion = cmdletContext.SemanticVersion;
            }
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Imagebuilder.Model.CreateImageRecipeResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.CreateImageRecipeRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "CreateImageRecipe");
            try
            {
                #if DESKTOP
                return client.CreateImageRecipe(request);
                #elif CORECLR
                return client.CreateImageRecipeAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? SystemsManagerAgent_UninstallAfterBuild { get; set; }
            public System.String AdditionalInstanceConfiguration_UserDataOverride { get; set; }
            public List<Amazon.Imagebuilder.Model.InstanceBlockDeviceMapping> BlockDeviceMapping { get; set; }
            public System.String ClientToken { get; set; }
            public List<Amazon.Imagebuilder.Model.ComponentConfiguration> Component { get; set; }
            public System.String Description { get; set; }
            public System.String Name { get; set; }
            public System.String ParentImage { get; set; }
            public System.String SemanticVersion { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.String WorkingDirectory { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.CreateImageRecipeResponse, NewEC2IBImageRecipeCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageRecipeArn;
        }
        
    }
}
