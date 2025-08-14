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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Imports the specified Windows 10 or 11 Bring Your Own License (BYOL) image into Amazon
    /// WorkSpaces using EC2 Image Builder. The image must be an already licensed image that
    /// is in your Amazon Web Services account, and you must own the image. For more information
    /// about creating BYOL images, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/byol-windows-images.html">
    /// Bring Your Own Windows Desktop Licenses</a>.
    /// </summary>
    [Cmdlet("Import", "WKSCustomWorkspaceImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ImportCustomWorkspaceImage API operation.", Operation = new[] {"ImportCustomWorkspaceImage"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse))]
    [AWSCmdletOutput("Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse",
        "This cmdlet returns an Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse object containing multiple properties."
    )]
    public partial class ImportWKSCustomWorkspaceImageCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ComputeType
        /// <summary>
        /// <para>
        /// <para>The supported compute type for the WorkSpace image.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpaces.ImageComputeType")]
        public Amazon.WorkSpaces.ImageComputeType ComputeType { get; set; }
        #endregion
        
        #region Parameter ImageSource_Ec2ImageId
        /// <summary>
        /// <para>
        /// <para>The identifier of the EC2 image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageSource_Ec2ImageId { get; set; }
        #endregion
        
        #region Parameter ImageSource_Ec2ImportTaskId
        /// <summary>
        /// <para>
        /// <para>The EC2 import task ID to import the image from the Amazon EC2 VM import process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageSource_Ec2ImportTaskId { get; set; }
        #endregion
        
        #region Parameter ImageSource_ImageBuildVersionArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the EC2 Image Builder image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageSource_ImageBuildVersionArn { get; set; }
        #endregion
        
        #region Parameter ImageDescription
        /// <summary>
        /// <para>
        /// <para>The description of the WorkSpace image.</para>
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
        public System.String ImageDescription { get; set; }
        #endregion
        
        #region Parameter ImageName
        /// <summary>
        /// <para>
        /// <para>The name of the WorkSpace image.</para>
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
        public System.String ImageName { get; set; }
        #endregion
        
        #region Parameter InfrastructureConfigurationArn
        /// <summary>
        /// <para>
        /// <para>The infrastructure configuration ARN that specifies how the WorkSpace image is built.</para>
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
        
        #region Parameter OsVersion
        /// <summary>
        /// <para>
        /// <para>The OS version for the WorkSpace image source.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpaces.OSVersion")]
        public Amazon.WorkSpaces.OSVersion OsVersion { get; set; }
        #endregion
        
        #region Parameter Platform
        /// <summary>
        /// <para>
        /// <para>The platform for the WorkSpace image source.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpaces.Platform")]
        public Amazon.WorkSpaces.Platform Platform { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// <para>The supported protocol for the WorkSpace image. Windows 11 does not support PCOIP
        /// protocol.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpaces.CustomImageProtocol")]
        public Amazon.WorkSpaces.CustomImageProtocol Protocol { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The resource tags. Each WorkSpaces resource can have a maximum of 50 tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WorkSpaces.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the ImageName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^ImageName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^ImageName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ImageName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-WKSCustomWorkspaceImage (ImportCustomWorkspaceImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse, ImportWKSCustomWorkspaceImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.ImageName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ComputeType = this.ComputeType;
            #if MODULAR
            if (this.ComputeType == null && ParameterWasBound(nameof(this.ComputeType)))
            {
                WriteWarning("You are passing $null as a value for parameter ComputeType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageDescription = this.ImageDescription;
            #if MODULAR
            if (this.ImageDescription == null && ParameterWasBound(nameof(this.ImageDescription)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageDescription which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageName = this.ImageName;
            #if MODULAR
            if (this.ImageName == null && ParameterWasBound(nameof(this.ImageName)))
            {
                WriteWarning("You are passing $null as a value for parameter ImageName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ImageSource_Ec2ImageId = this.ImageSource_Ec2ImageId;
            context.ImageSource_Ec2ImportTaskId = this.ImageSource_Ec2ImportTaskId;
            context.ImageSource_ImageBuildVersionArn = this.ImageSource_ImageBuildVersionArn;
            context.InfrastructureConfigurationArn = this.InfrastructureConfigurationArn;
            #if MODULAR
            if (this.InfrastructureConfigurationArn == null && ParameterWasBound(nameof(this.InfrastructureConfigurationArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InfrastructureConfigurationArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OsVersion = this.OsVersion;
            #if MODULAR
            if (this.OsVersion == null && ParameterWasBound(nameof(this.OsVersion)))
            {
                WriteWarning("You are passing $null as a value for parameter OsVersion which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Platform = this.Platform;
            #if MODULAR
            if (this.Platform == null && ParameterWasBound(nameof(this.Platform)))
            {
                WriteWarning("You are passing $null as a value for parameter Platform which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Protocol = this.Protocol;
            #if MODULAR
            if (this.Protocol == null && ParameterWasBound(nameof(this.Protocol)))
            {
                WriteWarning("You are passing $null as a value for parameter Protocol which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Tag != null)
            {
                context.Tag = new List<Amazon.WorkSpaces.Model.Tag>(this.Tag);
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
            var request = new Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageRequest();
            
            if (cmdletContext.ComputeType != null)
            {
                request.ComputeType = cmdletContext.ComputeType;
            }
            if (cmdletContext.ImageDescription != null)
            {
                request.ImageDescription = cmdletContext.ImageDescription;
            }
            if (cmdletContext.ImageName != null)
            {
                request.ImageName = cmdletContext.ImageName;
            }
            
             // populate ImageSource
            var requestImageSourceIsNull = true;
            request.ImageSource = new Amazon.WorkSpaces.Model.ImageSourceIdentifier();
            System.String requestImageSource_imageSource_Ec2ImageId = null;
            if (cmdletContext.ImageSource_Ec2ImageId != null)
            {
                requestImageSource_imageSource_Ec2ImageId = cmdletContext.ImageSource_Ec2ImageId;
            }
            if (requestImageSource_imageSource_Ec2ImageId != null)
            {
                request.ImageSource.Ec2ImageId = requestImageSource_imageSource_Ec2ImageId;
                requestImageSourceIsNull = false;
            }
            System.String requestImageSource_imageSource_Ec2ImportTaskId = null;
            if (cmdletContext.ImageSource_Ec2ImportTaskId != null)
            {
                requestImageSource_imageSource_Ec2ImportTaskId = cmdletContext.ImageSource_Ec2ImportTaskId;
            }
            if (requestImageSource_imageSource_Ec2ImportTaskId != null)
            {
                request.ImageSource.Ec2ImportTaskId = requestImageSource_imageSource_Ec2ImportTaskId;
                requestImageSourceIsNull = false;
            }
            System.String requestImageSource_imageSource_ImageBuildVersionArn = null;
            if (cmdletContext.ImageSource_ImageBuildVersionArn != null)
            {
                requestImageSource_imageSource_ImageBuildVersionArn = cmdletContext.ImageSource_ImageBuildVersionArn;
            }
            if (requestImageSource_imageSource_ImageBuildVersionArn != null)
            {
                request.ImageSource.ImageBuildVersionArn = requestImageSource_imageSource_ImageBuildVersionArn;
                requestImageSourceIsNull = false;
            }
             // determine if request.ImageSource should be set to null
            if (requestImageSourceIsNull)
            {
                request.ImageSource = null;
            }
            if (cmdletContext.InfrastructureConfigurationArn != null)
            {
                request.InfrastructureConfigurationArn = cmdletContext.InfrastructureConfigurationArn;
            }
            if (cmdletContext.OsVersion != null)
            {
                request.OsVersion = cmdletContext.OsVersion;
            }
            if (cmdletContext.Platform != null)
            {
                request.Platform = cmdletContext.Platform;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
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
        
        private Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ImportCustomWorkspaceImage");
            try
            {
                #if DESKTOP
                return client.ImportCustomWorkspaceImage(request);
                #elif CORECLR
                return client.ImportCustomWorkspaceImageAsync(request).GetAwaiter().GetResult();
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
            public Amazon.WorkSpaces.ImageComputeType ComputeType { get; set; }
            public System.String ImageDescription { get; set; }
            public System.String ImageName { get; set; }
            public System.String ImageSource_Ec2ImageId { get; set; }
            public System.String ImageSource_Ec2ImportTaskId { get; set; }
            public System.String ImageSource_ImageBuildVersionArn { get; set; }
            public System.String InfrastructureConfigurationArn { get; set; }
            public Amazon.WorkSpaces.OSVersion OsVersion { get; set; }
            public Amazon.WorkSpaces.Platform Platform { get; set; }
            public Amazon.WorkSpaces.CustomImageProtocol Protocol { get; set; }
            public List<Amazon.WorkSpaces.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ImportCustomWorkspaceImageResponse, ImportWKSCustomWorkspaceImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
