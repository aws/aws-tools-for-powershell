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
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.PowerShell.Cmdlets.EC2
{
    /// <summary>
    /// Uploads a client certificate revocation list to the specified Client VPN endpoint.
    /// Uploading a client certificate revocation list overwrites the existing client certificate
    /// revocation list.
    /// 
    ///  
    /// <para>
    /// Uploading a client certificate revocation list resets existing client connections.
    /// </para>
    /// </summary>
    [Cmdlet("Import", "EC2ClientVpnClientCertificateRevocationList", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.Boolean")]
    [AWSCmdlet("Calls the Amazon Elastic Compute Cloud (EC2) ImportClientVpnClientCertificateRevocationList API operation.", Operation = new[] {"ImportClientVpnClientCertificateRevocationList"}, SelectReturnType = typeof(Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListResponse))]
    [AWSCmdletOutput("System.Boolean or Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListResponse",
        "This cmdlet returns a collection of System.Boolean objects.",
        "The service call response (type Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListResponse) can be returned by specifying '-Select *'."
    )]
    public partial class ImportEC2ClientVpnClientCertificateRevocationListCmdlet : AmazonEC2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CertificateRevocationList
        /// <summary>
        /// <para>
        /// <para>The client certificate revocation list file. For more information, see <a href="https://docs.aws.amazon.com/vpn/latest/clientvpn-admin/cvpn-working-certificates.html#cvpn-working-certificates-generate">Generate
        /// a Client Certificate Revocation List</a> in the <i>Client VPN Administrator Guide</i>.</para>
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
        public System.String CertificateRevocationList { get; set; }
        #endregion
        
        #region Parameter ClientVpnEndpointId
        /// <summary>
        /// <para>
        /// <para>The ID of the Client VPN endpoint to which the client certificate revocation list
        /// applies.</para>
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
        public System.String ClientVpnEndpointId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Return'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListResponse).
        /// Specifying the name of a property of type Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Return";
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
        
        protected override void StopProcessing()
        {
            base.StopProcessing();
            _cancellationTokenSource.Cancel();
        }
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.ClientVpnEndpointId), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Import-EC2ClientVpnClientCertificateRevocationList (ImportClientVpnClientCertificateRevocationList)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListResponse, ImportEC2ClientVpnClientCertificateRevocationListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CertificateRevocationList = this.CertificateRevocationList;
            #if MODULAR
            if (this.CertificateRevocationList == null && ParameterWasBound(nameof(this.CertificateRevocationList)))
            {
                WriteWarning("You are passing $null as a value for parameter CertificateRevocationList which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ClientVpnEndpointId = this.ClientVpnEndpointId;
            #if MODULAR
            if (this.ClientVpnEndpointId == null && ParameterWasBound(nameof(this.ClientVpnEndpointId)))
            {
                WriteWarning("You are passing $null as a value for parameter ClientVpnEndpointId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListRequest();
            
            if (cmdletContext.CertificateRevocationList != null)
            {
                request.CertificateRevocationList = cmdletContext.CertificateRevocationList;
            }
            if (cmdletContext.ClientVpnEndpointId != null)
            {
                request.ClientVpnEndpointId = cmdletContext.ClientVpnEndpointId;
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
        
        private Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListResponse CallAWSServiceOperation(IAmazonEC2 client, Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Compute Cloud (EC2)", "ImportClientVpnClientCertificateRevocationList");
            try
            {
                return client.ImportClientVpnClientCertificateRevocationListAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CertificateRevocationList { get; set; }
            public System.String ClientVpnEndpointId { get; set; }
            public System.Func<Amazon.EC2.Model.ImportClientVpnClientCertificateRevocationListResponse, ImportEC2ClientVpnClientCertificateRevocationListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Return;
        }
        
    }
}
