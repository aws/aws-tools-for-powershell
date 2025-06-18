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
    /// Associates multiple code repositories with an Amazon Inspector code security scan
    /// configuration.
    /// </summary>
    [Cmdlet("Register", "INS2CodeSecurityScanConfigurationBatch", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse")]
    [AWSCmdlet("Calls the Inspector2 BatchAssociateCodeSecurityScanConfiguration API operation.", Operation = new[] {"BatchAssociateCodeSecurityScanConfiguration"}, SelectReturnType = typeof(Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse))]
    [AWSCmdletOutput("Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse",
        "This cmdlet returns an Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse object containing multiple properties."
    )]
    public partial class RegisterINS2CodeSecurityScanConfigurationBatchCmdlet : AmazonInspector2ClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AssociateConfigurationRequest
        /// <summary>
        /// <para>
        /// <para>A list of code repositories to associate with the specified scan configuration.</para>
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
        [Alias("AssociateConfigurationRequests")]
        public Amazon.Inspector2.Model.AssociateConfigurationRequest[] AssociateConfigurationRequest { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse).
        /// Specifying the name of a property of type Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse will result in that property being returned.
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.AssociateConfigurationRequest), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Register-INS2CodeSecurityScanConfigurationBatch (BatchAssociateCodeSecurityScanConfiguration)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse, RegisterINS2CodeSecurityScanConfigurationBatchCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            if (this.AssociateConfigurationRequest != null)
            {
                context.AssociateConfigurationRequest = new List<Amazon.Inspector2.Model.AssociateConfigurationRequest>(this.AssociateConfigurationRequest);
            }
            #if MODULAR
            if (this.AssociateConfigurationRequest == null && ParameterWasBound(nameof(this.AssociateConfigurationRequest)))
            {
                WriteWarning("You are passing $null as a value for parameter AssociateConfigurationRequest which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationRequest();
            
            if (cmdletContext.AssociateConfigurationRequest != null)
            {
                request.AssociateConfigurationRequests = cmdletContext.AssociateConfigurationRequest;
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
        
        private Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse CallAWSServiceOperation(IAmazonInspector2 client, Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Inspector2", "BatchAssociateCodeSecurityScanConfiguration");
            try
            {
                #if DESKTOP
                return client.BatchAssociateCodeSecurityScanConfiguration(request);
                #elif CORECLR
                return client.BatchAssociateCodeSecurityScanConfigurationAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Inspector2.Model.AssociateConfigurationRequest> AssociateConfigurationRequest { get; set; }
            public System.Func<Amazon.Inspector2.Model.BatchAssociateCodeSecurityScanConfigurationResponse, RegisterINS2CodeSecurityScanConfigurationBatchCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
