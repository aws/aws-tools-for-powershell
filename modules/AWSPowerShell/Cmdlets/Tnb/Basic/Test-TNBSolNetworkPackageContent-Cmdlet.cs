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
using Amazon.Tnb;
using Amazon.Tnb.Model;

namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Validates network package content. This can be used as a dry run before uploading
    /// network package content with <a href="https://docs.aws.amazon.com/tnb/latest/APIReference/API_PutSolNetworkPackageContent.html">PutSolNetworkPackageContent</a>.
    /// 
    ///  
    /// <para>
    /// A network package is a .zip file in CSAR (Cloud Service Archive) format defines the
    /// function packages you want to deploy and the Amazon Web Services infrastructure you
    /// want to deploy them on.
    /// </para>
    /// </summary>
    [Cmdlet("Test", "TNBSolNetworkPackageContent")]
    [OutputType("Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse")]
    [AWSCmdlet("Calls the AWS Telco Network Builder ValidateSolNetworkPackageContent API operation.", Operation = new[] {"ValidateSolNetworkPackageContent"}, SelectReturnType = typeof(Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse))]
    [AWSCmdletOutput("Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse",
        "This cmdlet returns an Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class TestTNBSolNetworkPackageContentCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContentType
        /// <summary>
        /// <para>
        /// <para>Network package content type.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Tnb.PackageContentType")]
        public Amazon.Tnb.PackageContentType ContentType { get; set; }
        #endregion
        
        #region Parameter File
        /// <summary>
        /// <para>
        /// <para>Network package file.</para>
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
        
        #region Parameter NsdInfoId
        /// <summary>
        /// <para>
        /// <para>Network service descriptor file.</para>
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
        public System.String NsdInfoId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse).
        /// Specifying the name of a property of type Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse, TestTNBSolNetworkPackageContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ContentType = this.ContentType;
            context.File = this.File;
            #if MODULAR
            if (this.File == null && ParameterWasBound(nameof(this.File)))
            {
                WriteWarning("You are passing $null as a value for parameter File which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.NsdInfoId = this.NsdInfoId;
            #if MODULAR
            if (this.NsdInfoId == null && ParameterWasBound(nameof(this.NsdInfoId)))
            {
                WriteWarning("You are passing $null as a value for parameter NsdInfoId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
                var request = new Amazon.Tnb.Model.ValidateSolNetworkPackageContentRequest();
                
                if (cmdletContext.ContentType != null)
                {
                    request.ContentType = cmdletContext.ContentType;
                }
                if (cmdletContext.File != null)
                {
                    _FileStream = new System.IO.MemoryStream(cmdletContext.File);
                    request.File = _FileStream;
                }
                if (cmdletContext.NsdInfoId != null)
                {
                    request.NsdInfoId = cmdletContext.NsdInfoId;
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
        
        private Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.ValidateSolNetworkPackageContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "ValidateSolNetworkPackageContent");
            try
            {
                #if DESKTOP
                return client.ValidateSolNetworkPackageContent(request);
                #elif CORECLR
                return client.ValidateSolNetworkPackageContentAsync(request).GetAwaiter().GetResult();
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
            public System.String NsdInfoId { get; set; }
            public System.Func<Amazon.Tnb.Model.ValidateSolNetworkPackageContentResponse, TestTNBSolNetworkPackageContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
