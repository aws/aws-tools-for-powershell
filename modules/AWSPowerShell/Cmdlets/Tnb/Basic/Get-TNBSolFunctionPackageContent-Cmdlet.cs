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
using System.Threading;
using Amazon.Tnb;
using Amazon.Tnb.Model;

namespace Amazon.PowerShell.Cmdlets.TNB
{
    /// <summary>
    /// Gets the contents of a function package.
    /// 
    ///  
    /// <para>
    /// A function package is a .zip file in CSAR (Cloud Service Archive) format that contains
    /// a network function (an ETSI standard telecommunication application) and function package
    /// descriptor that uses the TOSCA standard to describe how the network functions should
    /// run on your network.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TNBSolFunctionPackageContent")]
    [OutputType("Amazon.Tnb.Model.GetSolFunctionPackageContentResponse")]
    [AWSCmdlet("Calls the AWS Telco Network Builder GetSolFunctionPackageContent API operation.", Operation = new[] {"GetSolFunctionPackageContent"}, SelectReturnType = typeof(Amazon.Tnb.Model.GetSolFunctionPackageContentResponse))]
    [AWSCmdletOutput("Amazon.Tnb.Model.GetSolFunctionPackageContentResponse",
        "This cmdlet returns an Amazon.Tnb.Model.GetSolFunctionPackageContentResponse object containing multiple properties."
    )]
    public partial class GetTNBSolFunctionPackageContentCmdlet : AmazonTnbClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Accept
        /// <summary>
        /// <para>
        /// <para>The format of the package that you want to download from the function packages.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Tnb.PackageContentType")]
        public Amazon.Tnb.PackageContentType Accept { get; set; }
        #endregion
        
        #region Parameter VnfPkgId
        /// <summary>
        /// <para>
        /// <para>ID of the function package.</para>
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
        public System.String VnfPkgId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Tnb.Model.GetSolFunctionPackageContentResponse).
        /// Specifying the name of a property of type Amazon.Tnb.Model.GetSolFunctionPackageContentResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Tnb.Model.GetSolFunctionPackageContentResponse, GetTNBSolFunctionPackageContentCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Accept = this.Accept;
            #if MODULAR
            if (this.Accept == null && ParameterWasBound(nameof(this.Accept)))
            {
                WriteWarning("You are passing $null as a value for parameter Accept which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.Tnb.Model.GetSolFunctionPackageContentRequest();
            
            if (cmdletContext.Accept != null)
            {
                request.Accept = cmdletContext.Accept;
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
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.Tnb.Model.GetSolFunctionPackageContentResponse CallAWSServiceOperation(IAmazonTnb client, Amazon.Tnb.Model.GetSolFunctionPackageContentRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Telco Network Builder", "GetSolFunctionPackageContent");
            try
            {
                return client.GetSolFunctionPackageContentAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public Amazon.Tnb.PackageContentType Accept { get; set; }
            public System.String VnfPkgId { get; set; }
            public System.Func<Amazon.Tnb.Model.GetSolFunctionPackageContentResponse, GetTNBSolFunctionPackageContentCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
