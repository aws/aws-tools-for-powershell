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
    /// Uploads an image layer part to Amazon ECR.
    /// 
    ///  
    /// <para>
    /// When an image is pushed, each new image layer is uploaded in parts. The maximum size
    /// of each image layer part can be 20971520 bytes (or about 20MB). The UploadLayerPart
    /// API is called once per each new image layer part.
    /// </para><note><para>
    /// This operation is used by the Amazon ECR proxy and is not generally used by customers
    /// for pulling and pushing images. In most cases, you should use the <code>docker</code>
    /// CLI to pull, tag, and push images.
    /// </para></note>
    /// </summary>
    [Cmdlet("Send", "ECRLayerPart", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium, DefaultParameterSetName="FromBytes")]
    [OutputType("Amazon.ECR.Model.UploadLayerPartResponse")]
    [AWSCmdlet("Calls the Amazon EC2 Container Registry UploadLayerPart API operation.", Operation = new[] {"UploadLayerPart"}, SelectReturnType = typeof(Amazon.ECR.Model.UploadLayerPartResponse))]
    [AWSCmdletOutput("Amazon.ECR.Model.UploadLayerPartResponse",
        "This cmdlet returns an Amazon.ECR.Model.UploadLayerPartResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class SendECRLayerPartCmdlet : AmazonECRClientCmdlet, IExecutor
    {
        
        #region Parameter LayerPartBlob
        /// <summary>
        /// <para>
        /// <para>The base64-encoded layer part payload.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter to Base64 before supplying to the service.</para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true, ParameterSetName = "FromBytes")]
        [Alias("LayerPartBytes")]
        [Amazon.PowerShell.Common.Base64StreamParameterConverter]
        public byte[] LayerPartBlob { get; set; }
        #endregion
        
        #region Parameter PartFirstByte
        /// <summary>
        /// <para>
        /// <para>The position of the first byte of the layer part witin the overall image layer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? PartFirstByte { get; set; }
        #endregion
        
        #region Parameter PartLastByte
        /// <summary>
        /// <para>
        /// <para>The position of the last byte of the layer part within the overall image layer.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Int64? PartLastByte { get; set; }
        #endregion
        
        #region Parameter RegistryId
        /// <summary>
        /// <para>
        /// <para>The Amazon Web Services account ID associated with the registry to which you are uploading
        /// layer parts. If you do not specify a registry, the default registry is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RegistryId { get; set; }
        #endregion
        
        #region Parameter RepositoryName
        /// <summary>
        /// <para>
        /// <para>The name of the repository to which you are uploading layer parts.</para>
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
        public System.String RepositoryName { get; set; }
        #endregion
        
        #region Parameter UploadId
        /// <summary>
        /// <para>
        /// <para>The upload ID from a previous <a>InitiateLayerUpload</a> operation to associate with
        /// the layer part upload.</para>
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
        public System.String UploadId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECR.Model.UploadLayerPartResponse).
        /// Specifying the name of a property of type Amazon.ECR.Model.UploadLayerPartResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the LayerPartBlob parameter.
        /// The -PassThru parameter is deprecated, use -Select '^LayerPartBlob' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^LayerPartBlob' instead. This parameter will be removed in a future version.")]
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
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Send-ECRLayerPart (UploadLayerPart)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECR.Model.UploadLayerPartResponse, SendECRLayerPartCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.LayerPartBlob;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.LayerPartBlob = this.LayerPartBlob;
            #if MODULAR
            if (this.LayerPartBlob == null && ParameterWasBound(nameof(this.LayerPartBlob)))
            {
                WriteWarning("You are passing $null as a value for parameter LayerPartBlob which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartFirstByte = this.PartFirstByte;
            #if MODULAR
            if (this.PartFirstByte == null && ParameterWasBound(nameof(this.PartFirstByte)))
            {
                WriteWarning("You are passing $null as a value for parameter PartFirstByte which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PartLastByte = this.PartLastByte;
            #if MODULAR
            if (this.PartLastByte == null && ParameterWasBound(nameof(this.PartLastByte)))
            {
                WriteWarning("You are passing $null as a value for parameter PartLastByte which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RegistryId = this.RegistryId;
            context.RepositoryName = this.RepositoryName;
            #if MODULAR
            if (this.RepositoryName == null && ParameterWasBound(nameof(this.RepositoryName)))
            {
                WriteWarning("You are passing $null as a value for parameter RepositoryName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.UploadId = this.UploadId;
            #if MODULAR
            if (this.UploadId == null && ParameterWasBound(nameof(this.UploadId)))
            {
                WriteWarning("You are passing $null as a value for parameter UploadId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _LayerPartBlobStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.ECR.Model.UploadLayerPartRequest();
                
                if (cmdletContext.LayerPartBlob != null)
                {
                    _LayerPartBlobStream = new System.IO.MemoryStream(cmdletContext.LayerPartBlob);
                    request.LayerPartBlob = _LayerPartBlobStream;
                }
                if (cmdletContext.PartFirstByte != null)
                {
                    request.PartFirstByte = cmdletContext.PartFirstByte.Value;
                }
                if (cmdletContext.PartLastByte != null)
                {
                    request.PartLastByte = cmdletContext.PartLastByte.Value;
                }
                if (cmdletContext.RegistryId != null)
                {
                    request.RegistryId = cmdletContext.RegistryId;
                }
                if (cmdletContext.RepositoryName != null)
                {
                    request.RepositoryName = cmdletContext.RepositoryName;
                }
                if (cmdletContext.UploadId != null)
                {
                    request.UploadId = cmdletContext.UploadId;
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
            finally
            {
                if( _LayerPartBlobStream != null)
                {
                    _LayerPartBlobStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.ECR.Model.UploadLayerPartResponse CallAWSServiceOperation(IAmazonECR client, Amazon.ECR.Model.UploadLayerPartRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Registry", "UploadLayerPart");
            try
            {
                #if DESKTOP
                return client.UploadLayerPart(request);
                #elif CORECLR
                return client.UploadLayerPartAsync(request).GetAwaiter().GetResult();
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
            public byte[] LayerPartBlob { get; set; }
            public System.Int64? PartFirstByte { get; set; }
            public System.Int64? PartLastByte { get; set; }
            public System.String RegistryId { get; set; }
            public System.String RepositoryName { get; set; }
            public System.String UploadId { get; set; }
            public System.Func<Amazon.ECR.Model.UploadLayerPartResponse, SendECRLayerPartCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
