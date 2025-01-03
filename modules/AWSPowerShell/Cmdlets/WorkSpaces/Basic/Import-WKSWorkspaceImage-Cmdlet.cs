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
using Amazon.WorkSpaces;
using Amazon.WorkSpaces.Model;

namespace Amazon.PowerShell.Cmdlets.WKS
{
    /// <summary>
    /// Imports the specified Windows 10 or 11 Bring Your Own License (BYOL) image into Amazon
    /// WorkSpaces. The image must be an already licensed Amazon EC2 image that is in your
    /// Amazon Web Services account, and you must own the image. For more information about
    /// creating BYOL images, see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/byol-windows-images.html">
    /// Bring Your Own Windows Desktop Licenses</a>.
    /// </summary>
    [Cmdlet("Import", "WKSWorkspaceImage", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the Amazon WorkSpaces ImportWorkspaceImage API operation.", Operation = new[] {"ImportWorkspaceImage"}, SelectReturnType = typeof(Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse))]
    [AWSCmdletOutput("System.String or Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportWKSWorkspaceImageCmdlet : AmazonWorkSpacesClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Application
        /// <summary>
        /// <para>
        /// <para>If specified, the version of Microsoft Office to subscribe to. Valid only for Windows
        /// 10 and 11 BYOL images. For more information about subscribing to Office for BYOL images,
        /// see <a href="https://docs.aws.amazon.com/workspaces/latest/adminguide/byol-windows-images.html">
        /// Bring Your Own Windows Desktop Licenses</a>.</para><note><ul><li><para>Although this parameter is an array, only one item is allowed at this time.</para></li><li><para>During the image import process, non-GPU DCV (formerly WSP) WorkSpaces with Windows
        /// 11 support only <c>Microsoft_Office_2019</c>. GPU DCV (formerly WSP) WorkSpaces with
        /// Windows 11 do not support Office installation.</para></li></ul></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Applications")]
        public System.String[] Application { get; set; }
        #endregion
        
        #region Parameter Ec2ImageId
        /// <summary>
        /// <para>
        /// <para>The identifier of the EC2 image.</para>
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
        public System.String Ec2ImageId { get; set; }
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
        
        #region Parameter IngestionProcess
        /// <summary>
        /// <para>
        /// <para>The ingestion process to be used when importing the image, depending on which protocol
        /// you want to use for your BYOL Workspace image, either PCoIP, WSP, or bring your own
        /// protocol (BYOP). To use DCV, specify a value that ends in <c>_WSP</c>. To use PCoIP,
        /// specify a value that does not end in <c>_WSP</c>. To use BYOP, specify a value that
        /// ends in <c>_BYOP</c>.</para><para>For non-GPU-enabled bundles (bundles other than Graphics or GraphicsPro), specify
        /// <c>BYOL_REGULAR</c>, <c>BYOL_REGULAR_WSP</c>, or <c>BYOL_REGULAR_BYOP</c>, depending
        /// on the protocol.</para><note><para>The <c>BYOL_REGULAR_BYOP</c> and <c>BYOL_GRAPHICS_G4DN_BYOP</c> values are only supported
        /// by Amazon WorkSpaces Core. Contact your account team to be allow-listed to use these
        /// values. For more information, see <a href="http://aws.amazon.com/workspaces/core/">Amazon
        /// WorkSpaces Core</a>.</para></note>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.WorkSpaces.WorkspaceImageIngestionProcess")]
        public Amazon.WorkSpaces.WorkspaceImageIngestionProcess IngestionProcess { get; set; }
        #endregion
        
        #region Parameter Tag
        /// <summary>
        /// <para>
        /// <para>The tags. Each WorkSpaces resource can have a maximum of 50 tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Tags")]
        public Amazon.WorkSpaces.Model.Tag[] Tag { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'ImageId'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse).
        /// Specifying the name of a property of type Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "ImageId";
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-WKSWorkspaceImage (ImportWorkspaceImage)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse, ImportWKSWorkspaceImageCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.Application != null)
            {
                context.Application = new List<System.String>(this.Application);
            }
            context.Ec2ImageId = this.Ec2ImageId;
            #if MODULAR
            if (this.Ec2ImageId == null && ParameterWasBound(nameof(this.Ec2ImageId)))
            {
                WriteWarning("You are passing $null as a value for parameter Ec2ImageId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            context.IngestionProcess = this.IngestionProcess;
            #if MODULAR
            if (this.IngestionProcess == null && ParameterWasBound(nameof(this.IngestionProcess)))
            {
                WriteWarning("You are passing $null as a value for parameter IngestionProcess which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.WorkSpaces.Model.ImportWorkspaceImageRequest();
            
            if (cmdletContext.Application != null)
            {
                request.Applications = cmdletContext.Application;
            }
            if (cmdletContext.Ec2ImageId != null)
            {
                request.Ec2ImageId = cmdletContext.Ec2ImageId;
            }
            if (cmdletContext.ImageDescription != null)
            {
                request.ImageDescription = cmdletContext.ImageDescription;
            }
            if (cmdletContext.ImageName != null)
            {
                request.ImageName = cmdletContext.ImageName;
            }
            if (cmdletContext.IngestionProcess != null)
            {
                request.IngestionProcess = cmdletContext.IngestionProcess;
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
        
        private Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse CallAWSServiceOperation(IAmazonWorkSpaces client, Amazon.WorkSpaces.Model.ImportWorkspaceImageRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon WorkSpaces", "ImportWorkspaceImage");
            try
            {
                #if DESKTOP
                return client.ImportWorkspaceImage(request);
                #elif CORECLR
                return client.ImportWorkspaceImageAsync(request).GetAwaiter().GetResult();
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
            public List<System.String> Application { get; set; }
            public System.String Ec2ImageId { get; set; }
            public System.String ImageDescription { get; set; }
            public System.String ImageName { get; set; }
            public Amazon.WorkSpaces.WorkspaceImageIngestionProcess IngestionProcess { get; set; }
            public List<Amazon.WorkSpaces.Model.Tag> Tag { get; set; }
            public System.Func<Amazon.WorkSpaces.Model.ImportWorkspaceImageResponse, ImportWKSWorkspaceImageCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.ImageId;
        }
        
    }
}
