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
using Amazon.Inspector2;
using Amazon.Inspector2.Model;

namespace Amazon.PowerShell.Cmdlets.INS2
{
    /// <summary>
    /// Disassociates multiple code repositories from an Amazon Inspector code security scan
    /// configuration.
    /// </summary>
    [Cmdlet("Unregister", "INS2CodeSecurityScanConfigurationBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse")]
    [AWSCmdlet("Calls the Inspector2 BatchDisassociateCodeSecurityScanConfiguration API operation.", Operation = new[] {"BatchDisassociateCodeSecurityScanConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse object containing multiple properties."
    )]
    public partial class UnregisterINS2CodeSecurityScanConfigurationBatchCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter DisassociateConfigurationRequest
        /// <summary>
        /// <para>
        /// <para>A list of code repositories to disassociate from the specified scan configuration.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [Alias("DisassociateConfigurationRequests")]
        public Amazon.Inspector2.Model.DisassociateConfigurationRequest[] DisassociateConfigurationRequest { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.DisassociateConfigurationRequest), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Unregister-INS2CodeSecurityScanConfigurationBatch (BatchDisassociateCodeSecurityScanConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse, UnregisterINS2CodeSecurityScanConfigurationBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.DisassociateConfigurationRequest != null)
            {
                context.DisassociateConfigurationRequest = new List<Amazon.Inspector2.Model.DisassociateConfigurationRequest>(this.DisassociateConfigurationRequest);
            }
            #if MODULAR
            if (this.DisassociateConfigurationRequest == null && ParameterWasBound(nameof(this.DisassociateConfigurationRequest)))
            {
                WriteWarning("You are passing $null as a value for parameter DisassociateConfigurationRequest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationRequest();
            
            if (cmdletContext.DisassociateConfigurationRequest != null)
            {
                request.DisassociateConfigurationRequests = cmdletContext.DisassociateConfigurationRequest;
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
        
        private Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "BatchDisassociateCodeSecurityScanConfiguration");
            try
            {
                #if DESKTOP
                return client.BatchDisassociateCodeSecurityScanConfiguration(request);
                #elif CORECLR
                return client.BatchDisassociateCodeSecurityScanConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.DisassociateConfigurationRequest> DisassociateConfigurationRequest { get; set; }
            public System.Func<Amazon.Inspector2.Model.BatchDisassociateCodeSecurityScanConfigurationResponse, UnregisterINS2CodeSecurityScanConfigurationBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
