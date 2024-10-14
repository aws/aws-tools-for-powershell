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
using Amazon.ECR;
using Amazon.ECR.Model;

namespace Amazon.PowerShell.Cmdlets.ECR
{
    /// <summary>
    /// <important><para>
    /// The <c>PutImageScanningConfiguration</c> API is being deprecated, in favor of specifying
    /// the image scanning configuration at the registry level. For more information, see
    /// <a>PutRegistryScanningConfiguration</a>.
    /// </para></important><para>
    /// Updates the image scanning configuration for the specified repository.
    /// </para>
    /// </summary>
    [Cmdlet("Write", "ECRImageScanningConfiguration", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECR.Model.PutImageScanningConfigurationResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry PutImageScanningConfiguration API operation.", Operation = new[] {"PutImageScanningConfiguration"}, SelectReturnType = typeof(Amazon.ECR.Model.PutImageScanningConfigurationResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.PutImageScanningConfigurationResponse",
        "This cmdlet returns an Amazon.ECR.Model.PutImageScanningConfigurationResponse object containing multiple properties."
    )]
    public partial class WriteECRImageScanningConfigurationCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the registry that contains the
        /// repository in which to update the image scanning configuration setting. If you do
        /// not specify a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository in which to update the image scanning configuration setting.</para>
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
        
        #region Parameter ImageScanningConfiguration_ScanOnPush
        /// <summary>
        /// <para>
        /// <para>The setting that determines whether images are scanned after being pushed to a repository.
        /// If set to <c>true</c>, images will be scanned after being pushed. If this parameter
        /// is not specified, it will default to <c>false</c> and images will not be scanned unless
        /// a scan is manually started with the <a href="https://docs.aws.amazon.com/AmazonECR/latest/APIReference/API_StartImageScan.html">API_StartImageScan</a>
        /// API.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ImageScanningConfiguration_ScanOnPush { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.PutImageScanningConfigurationResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.PutImageScanningConfigurationResponse will result in that property being returned.
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Write-ECRImageScanningConfiguration (PutImageScanningConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.PutImageScanningConfigurationResponse, WriteECRImageScanningConfigurationCmdlet>(Select) ??
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
            context.ImageScanningConfiguration_ScanOnPush = this.ImageScanningConfiguration_ScanOnPush;
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
            var request = new Amazon.ECR.Model.PutImageScanningConfigurationRequest();
            
            
             // populate ImageScanningConfiguration
            var requestImageScanningConfigurationIsNull = true;
            request.ImageScanningConfiguration = new Amazon.ECR.Model.ImageScanningConfiguration();
            System.Boolean? requestImageScanningConfiguration_imageScanningConfiguration_ScanOnPush = null;
            if (cmdletContext.ImageScanningConfiguration_ScanOnPush != null)
            {
                requestImageScanningConfiguration_imageScanningConfiguration_ScanOnPush = cmdletContext.ImageScanningConfiguration_ScanOnPush.Value;
            }
            if (requestImageScanningConfiguration_imageScanningConfiguration_ScanOnPush != null)
            {
                request.ImageScanningConfiguration.ScanOnPush = requestImageScanningConfiguration_imageScanningConfiguration_ScanOnPush.Value;
                requestImageScanningConfigurationIsNull = false;
            }
             // determine if request.ImageScanningConfiguration should be set to null
            if (requestImageScanningConfigurationIsNull)
            {
                request.ImageScanningConfiguration = null;
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
        
        private Amazon.ECR.Model.PutImageScanningConfigurationResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.PutImageScanningConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "PutImageScanningConfiguration");
            try
            {
                #if DESKTOP
                return client.PutImageScanningConfiguration(request);
                #elif CORECLR
                return client.PutImageScanningConfigurationAsync(request).GetAwaiter().GetResult();
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
            public System.Boolean? ImageScanningConfiguration_ScanOnPush { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.Func<Amazon.ECR.Model.PutImageScanningConfigurationResponse, WriteECRImageScanningConfigurationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
