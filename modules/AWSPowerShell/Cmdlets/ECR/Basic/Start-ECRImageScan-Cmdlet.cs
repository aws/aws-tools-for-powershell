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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// Starts an image vulnerability scan. An image scan can only be started once per 24
    /// hours on an individual image. This limit includes if an image was scanned on initial
    /// push. For more information, see <a href="https://docs.aws.amazon.com/AmazonECR/latest/userguide/image-scanning.html">Image
    /// scanning</a> in the <i>Amazon Elastic Container Registry User Guide</i>.
    /// </summary>
    [Cmdlet("Start", "ECRImageScan", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.StartImageScanResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry StartImageScan API operation.", Operation = new[] {"StartImageScan"}, SelectReturnType = typeof(Amazon.ECR.Model.StartImageScanResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.StartImageScanResponse",
        "This cmdlet returns an Amazon.ECR.Model.StartImageScanResponse object containing multiple properties."
    )]
    public partial class StartECRImageScanCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ImageId_ImageDigest
        /// <summary>
        /// <para>
        /// <para>The <c>sha256</c> digest of the image manifest.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageId_ImageDigest { get; set; }
        #endregion
        
        #region Parameter ImageId_ImageTag
        /// <summary>
        /// <para>
        /// <para>The tag used for the image.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ImageId_ImageTag { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the registry that contains the
        /// repository in which to start an image scan request. If you do not specify a registry,
        /// the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository that contains the images to scan.</para>
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
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.StartImageScanResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.StartImageScanResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the RepositoryName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^RepositoryName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.RepositoryName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Start-ECRImageScan (StartImageScan)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.StartImageScanResponse, StartECRImageScanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.RepositoryName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ImageId_ImageDigest = this.ImageId_ImageDigest;
            context.ImageId_ImageTag = this.ImageId_ImageTag;
            context.RegistryId = this.RegistryId;
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ECR.Model.StartImageScanRequest();
            
            
             // populate ImageId
            var requestImageIdIsNull = true;
            request.ImageId = new Amazon.ECR.Model.ImageIdentifier();
            System.String requestImageId_imageId_ImageDigest = null;
            if (cmdletContext.ImageId_ImageDigest != null)
            {
                requestImageId_imageId_ImageDigest = cmdletContext.ImageId_ImageDigest;
            }
            if (requestImageId_imageId_ImageDigest != null)
            {
                request.ImageId.ImageDigest = requestImageId_imageId_ImageDigest;
                requestImageIdIsNull = false;
            }
            System.String requestImageId_imageId_ImageTag = null;
            if (cmdletContext.ImageId_ImageTag != null)
            {
                requestImageId_imageId_ImageTag = cmdletContext.ImageId_ImageTag;
            }
            if (requestImageId_imageId_ImageTag != null)
            {
                request.ImageId.ImageTag = requestImageId_imageId_ImageTag;
                requestImageIdIsNull = false;
            }
             // determine if request.ImageId should be set to null
            if (requestImageIdIsNull)
            {
                request.ImageId = null;
            }
            if (cmdletContext.RegistryId != null)
            {
                request.RegistryId = cmdletContext.RegistryId;
            }
            if (cmdletContext.RepositoryName != null)
            {
                request.RepositoryName = cmdletContext.RepositoryName;
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
        
        private Amazon.ECR.Model.StartImageScanResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.StartImageScanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "StartImageScan");
            try
            {
                #if DESKTOP
                return client.StartImageScan(request);
                #elif CORECLR
                return client.StartImageScanAsync(request).GetAwaiter().GetResult();
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
            public System.String ImageId_ImageDigest { get; set; }
            public System.String ImageId_ImageTag { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.Func<Amazon.ECR.Model.StartImageScanResponse, StartECRImageScanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
