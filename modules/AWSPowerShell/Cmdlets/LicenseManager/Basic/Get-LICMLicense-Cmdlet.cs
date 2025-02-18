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
using Amazon.LicenseManager;
using Amazon.LicenseManager.Model;

namespace Amazon.PowerShell.Cmdlets.LICM
{
    /// <summary>
    /// Gets detailed information about the specified license.
    /// </summary>
    [Cmdlet("Get", "LICMLicense")]
    [OutputType("Amazon.LicenseManager.Model.License")]
    [AWSCmdlet("Calls the AWS License Manager GetLicense API operation.", Operation = new[] {"GetLicense"}, SelectReturnType = typeof(Amazon.LicenseManager.Model.GetLicenseResponse))]
    [AWSCmdletOutput("Amazon.LicenseManager.Model.License or Amazon.LicenseManager.Model.GetLicenseResponse",
        "This cmdlet returns an Amazon.LicenseManager.Model.License object.",
        "The service call response (type Amazon.LicenseManager.Model.GetLicenseResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetLICMLicenseCmdlet : AmazonLicenseManagerClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter LicenseArn
        /// <summary>
        /// <para>
        /// <para>Amazon Resource Name (ARN) of the license.</para>
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
        public System.String LicenseArn { get; set; }
        #endregion
        
        #region Parameter Version
        /// <summary>
        /// <para>
        /// <para>License version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Version { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'License'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.LicenseManager.Model.GetLicenseResponse).
        /// Specifying the name of a property of type Amazon.LicenseManager.Model.GetLicenseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "License";
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
                context.Select = CreateSelectDelegate<Amazon.LicenseManager.Model.GetLicenseResponse, GetLICMLicenseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.LicenseArn = this.LicenseArn;
            #if MODULAR
            if (this.LicenseArn == null && ParameterWasBound(nameof(this.LicenseArn)))
            {
                WriteWarning("You are passing $null as a value for parameter LicenseArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Version = this.Version;
            
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
            var request = new Amazon.LicenseManager.Model.GetLicenseRequest();
            
            if (cmdletContext.LicenseArn != null)
            {
                request.LicenseArn = cmdletContext.LicenseArn;
            }
            if (cmdletContext.Version != null)
            {
                request.Version = cmdletContext.Version;
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
        
        private Amazon.LicenseManager.Model.GetLicenseResponse CallAWSServiceOperation(IAmazonLicenseManager client, Amazon.LicenseManager.Model.GetLicenseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS License Manager", "GetLicense");
            try
            {
                return client.GetLicenseAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String LicenseArn { get; set; }
            public System.String Version { get; set; }
            public System.Func<Amazon.LicenseManager.Model.GetLicenseResponse, GetLICMLicenseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.License;
        }
        
    }
}
