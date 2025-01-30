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
using Amazon.Tnb;
using Amazon.Tnb.Model;

namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Validates function package content. This can be used as a dry run before uploading
    /// function package content with <a href="https://docs.aws.amazon.com/tnb/latest/APIReference/API_PutSolFunctionPackageContent.html">PutSolFunctionPackageContent</a>.
    /// 
    ///  
    /// <para>
    /// A function package is a .zip file in CSAR (Cloud Service Archive) format that contains
    /// a network function (an ETSI standard telecommunication application) and function package
    /// descriptor that uses the TOSCA standard to describe how the network functions should
    /// run on your network.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "TNBSolFunctionPackageContent")]
    [OutputType("Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse")]
    [AWSCmdlet("Calls the AWS Telco Network Builder ValidateSolFunctionPackageContent API operation.", Operation = new[] {"ValidateSolFunctionPackageContent"}, SelectReturnType = typeof(Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse))]
    [AWSCmdletOutput("Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse",
        "This cmdlet returns an Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse object containing multiple properties."
    )]
    public partial class TestTNBSolFunctionPackageContentCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsSensitiveRequest { get; set; } = true;
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>Function package content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Tnb.PackageContentType")]
        public Amazon.Tnb.PackageContentType ContentType { get; set; }
        #endregion
        
        #region Parameter File
        /// <summary>
        /// <para>
        /// <para>Function package file.</para>
        /// </para>
        /// <para>The cmdlet will automatically convert the supplied parameter of type string, string[], System.IO.FileInfo or System.IO.Stream to byte[] before supplying it to the service.</para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Amazon.PowerShell.Common.MemoryStreamParameterConverter]
        public byte[] File { get; set; }
        #endregion
        
        #region Parameter VnfPkgId
        /// <summary>
        /// <para>
        /// <para>Function package ID.</para>
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
        public System.String VnfPkgId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse).
        /// Specifying the name of a property of type Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the File parameter.
        /// The -PassThru parameter is deprecated, use -Select '^File' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^File' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse, TestTNBSolFunctionPackageContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.File;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContentType = this.ContentType;
            context.File = this.File;
            #if MODULAR
            if (this.File == null && ParameterWasBound(nameof(this.File)))
            {
                WriteWarning("You are passing $null as a value for parameter File which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.VnfPkgId = this.VnfPkgId;
            #if MODULAR
            if (this.VnfPkgId == null && ParameterWasBound(nameof(this.VnfPkgId)))
            {
                WriteWarning("You are passing $null as a value for parameter VnfPkgId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            System.IO.MemoryStream _FileStream = null;
            
            try
            {
                var cmdletContext = context as CmdletContext;
                // create request
                var request = new Amazon.Tnb.Model.ValidateSolFunctionPackageContentRequest();
                
                if (cmdletContext.ContentType != null)
                {
                    request.ContentType = cmdletContext.ContentType;
                }
                if (cmdletContext.File != null)
                {
                    _FileStream = new System.IO.MemoryStream(cmdletContext.File);
                    request.File = _FileStream;
                }
                if (cmdletContext.VnfPkgId != null)
                {
                    request.VnfPkgId = cmdletContext.VnfPkgId;
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
                if( _FileStream != null)
                {
                    _FileStream.Dispose();
                }
            }
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.ValidateSolFunctionPackageContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "ValidateSolFunctionPackageContent");
            try
            {
                #if DESKTOP
                return client.ValidateSolFunctionPackageContent(request);
                #elif CORECLR
                return client.ValidateSolFunctionPackageContentAsync(request).GetAwaiter().GetResult();
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
            public Amazon.Tnb.PackageContentType ContentType { get; set; }
            public byte[] File { get; set; }
            public System.String VnfPkgId { get; set; }
            public System.Func<Amazon.Tnb.Model.ValidateSolFunctionPackageContentResponse, TestTNBSolFunctionPackageContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
