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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Retrieves information about a specific code security scan.
    /// </summary>
    [Cmdlet("Get", "INS2CodeSecurityScan")]
    [OutputType("Amazon.Inspector2.Model.GetCodeSecurityScanResponse")]
    [AWSCmdlet("Calls the Inspector2 GetCodeSecurityScan API operation.", Operation = new[] {"GetCodeSecurityScan"}, SelectReturnType = typeof(Amazon.Inspector2.Model.GetCodeSecurityScanResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.GetCodeSecurityScanResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.GetCodeSecurityScanResponse object containing multiple properties."
    )]
    public partial class GetINS2CodeSecurityScanCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter Resource_ProjectId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the project in the code repository.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Resource_ProjectId { get; set; }
        #endregion
        
        #region Parameter ScanId
        /// <summary>
        /// <para>
        /// <para>The unique identifier of the scan to retrieve.</para>
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
        public System.String ScanId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.GetCodeSecurityScanResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.GetCodeSecurityScanResponse will result in that property being returned.
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
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.GetCodeSecurityScanResponse, GetINS2CodeSecurityScanCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Resource_ProjectId = this.Resource_ProjectId;
            context.ScanId = this.ScanId;
            #if MODULAR
            if (this.ScanId == null && ParameterWasBound(nameof(this.ScanId)))
            {
                WriteWarning("You are passing $null as a value for parameter ScanId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.GetCodeSecurityScanRequest();
            
            
             // populate Resource
            request.Resource = new Amazon.Inspector2.Model.CodeSecurityResource();
            System.String requestResource_resource_ProjectId = null;
            if (cmdletContext.Resource_ProjectId != null)
            {
                requestResource_resource_ProjectId = cmdletContext.Resource_ProjectId;
            }
            if (requestResource_resource_ProjectId != null)
            {
                request.Resource.ProjectId = requestResource_resource_ProjectId;
            }
            if (cmdletContext.ScanId != null)
            {
                request.ScanId = cmdletContext.ScanId;
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
        
        private Amazon.Inspector2.Model.GetCodeSecurityScanResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.GetCodeSecurityScanRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "GetCodeSecurityScan");
            try
            {
                return client.GetCodeSecurityScanAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String Resource_ProjectId { get; set; }
            public System.String ScanId { get; set; }
            public System.Func<Amazon.Inspector2.Model.GetCodeSecurityScanResponse, GetINS2CodeSecurityScanCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
