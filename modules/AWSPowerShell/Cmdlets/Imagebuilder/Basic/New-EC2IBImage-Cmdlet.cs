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
    /// Creates a new image. This request will create a new image along with all of the configured
    /// output resources defined in the distribution configuration. You must specify exactly
    /// one recipe for your image, using either a ContainerRecipeArn or an ImageRecipeArn.
    /// </summary>
    [Cmdlet("New", "EC2IBImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the EC2 Image Builder CreateImage API operation.", Operation = new[] {"CreateImage"}, SelectReturnType = typeof(Amazon.Imagebuilder.Model.CreateImageResponse))]
    [AWSCmdletOutput("System.String or Amazon.Imagebuilder.Model.CreateImageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Imagebuilder.Model.CreateImageResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class NewEC2IBImageCmdlet : AmazonImagebuilderClientCmdlet, IExecutor
    {
        
        #region Parameter ContainerRecipeArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the container recipe that defines how images are
        /// configured and tested.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContainerRecipeArn { get; set; }
        #endregion
        
        #region Parameter DistributionConfigurationArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the distribution configuration that defines and
        /// configures the outputs of your pipeline.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String DistributionConfigurationArn { get; set; }
        #endregion
        
        #region Parameter EnhancedImageMetadataEnabled
        /// <summary>
        /// <para>
        /// <para> Collects additional information about the image being created, including the operating
        /// system (OS) version and package list. This information is used to enhance the overall
        /// experience of using EC2 Image Builder. Enabled by default.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnhancedImageMetadataEnabled { get; set; }
        #endregion
        
        #region Parameter ImageRecipeArn
        /// <summary>
        /// <para>
        /// <para> The Amazon Resource Name (ARN) of the image recipe that defines how images are configured,
        /// tested, and assessed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String ImageRecipeArn { get; set; }
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
        /// <para> The Amazon Resource Name (ARN) of the infrastructure configuration that defines the
        /// environment in which your image will be built and tested.</para>
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
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para> The tags of the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public System.Collections.Hashtable Tag { get; set; }
        #endregion
        
        #region Parameter ImageTestsConfiguration_TimeoutMinute
        /// <summary>
        /// <para>
        /// <para>The maximum time in minutes that tests are permitted to run.</para><note><para>The timeoutMinutes attribute is not currently active. This value is ignored.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ImageTestsConfiguration_TimeoutMinutes")]
        public System.Int32? ImageTestsConfiguration_TimeoutMinute { get; set; }
        #endregion
        
        #region Parameter ClientToken
        /// <summary>
        /// <para>
        /// <para> The idempotency token used to make this request idempotent.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageBuildVersionArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Imagebuilder.Model.CreateImageResponse).
        /// Specifying the name of a property of type Amazon.Imagebuilder.Model.CreateImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageBuildVersionArn";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImageRecipeArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImageRecipeArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImageRecipeArn' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageRecipeArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-EC2IBImage (CreateImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Imagebuilder.Model.CreateImageResponse, NewEC2IBImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImageRecipeArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ClientToken = this.ClientToken;
            context.ContainerRecipeArn = this.ContainerRecipeArn;
            context.DistributionConfigurationArn = this.DistributionConfigurationArn;
            context.EnhancedImageMetadataEnabled = this.EnhancedImageMetadataEnabled;
            context.ImageRecipeArn = this.ImageRecipeArn;
            context.ImageTestsConfiguration_ImageTestsEnabled = this.ImageTestsConfiguration_ImageTestsEnabled;
            context.ImageTestsConfiguration_TimeoutMinute = this.ImageTestsConfiguration_TimeoutMinute;
            context.InfrastructureConfigurationArn = this.InfrastructureConfigurationArn;
            #if MODULAR
            if (this.InfrastructureConfigurationArn == null && ParameterWasBound(nameof(this.InfrastructureConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InfrastructureConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.Tag.Keys)
                {
                    context.Tag.Add((String)hashKey, (String)(this.Tag[hashKey]));
                }
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
            var request = new Amazon.Imagebuilder.Model.CreateImageRequest();
            
            if (cmdletContext.ClientToken != null)
            {
                request.ClientToken = cmdletContext.ClientToken;
            }
            if (cmdletContext.ContainerRecipeArn != null)
            {
                request.ContainerRecipeArn = cmdletContext.ContainerRecipeArn;
            }
            if (cmdletContext.DistributionConfigurationArn != null)
            {
                request.DistributionConfigurationArn = cmdletContext.DistributionConfigurationArn;
            }
            if (cmdletContext.EnhancedImageMetadataEnabled != null)
            {
                request.EnhancedImageMetadataEnabled = cmdletContext.EnhancedImageMetadataEnabled.Value;
            }
            if (cmdletContext.ImageRecipeArn != null)
            {
                request.ImageRecipeArn = cmdletContext.ImageRecipeArn;
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
            if (cmdletContext.Tag != null)
            {
                request.Tags = cmdletContext.Tag;
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
        
        private Amazon.Imagebuilder.Model.CreateImageResponse CallAWSServiceOperation(IAmazonImagebuilder client, Amazon.Imagebuilder.Model.CreateImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "EC2 Image Builder", "CreateImage");
            try
            {
                #if DESKTOP
                return client.CreateImage(request);
                #elif CORECLR
                return client.CreateImageAsync(request).GetAwaiter().GetResult();
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
            public System.String DistributionConfigurationArn { get; set; }
            public System.Boolean? EnhancedImageMetadataEnabled { get; set; }
            public System.String ImageRecipeArn { get; set; }
            public System.Boolean? ImageTestsConfiguration_ImageTestsEnabled { get; set; }
            public System.Int32? ImageTestsConfiguration_TimeoutMinute { get; set; }
            public System.String InfrastructureConfigurationArn { get; set; }
            public Dictionary<System.String, System.String> Tag { get; set; }
            public System.Func<Amazon.Imagebuilder.Model.CreateImageResponse, NewEC2IBImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageBuildVersionArn;
        }
        
    }
}
