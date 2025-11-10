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
using Amazon.Invoicing;
using Amazon.Invoicing.Model;

namespace Amazon.PowerShell.Cmdlets.INV
{
    /// <summary>
    /// Returns a URL to download the invoice document and supplemental documents associated
    /// with an invoice. The URLs are pre-signed and have expiration time. For special cases
    /// like Brazil, where Amazon Web Services generated invoice identifiers and government
    /// provided identifiers do not match, use the Amazon Web Services generated invoice identifier
    /// when making API requests. To grant IAM permission to use this operation, the caller
    /// needs the <c>invoicing:GetInvoicePDF</c> policy action.
    /// </summary>
    [Cmdlet("Get", "INVInvoicePDF")]
    [OutputType("Amazon.Invoicing.Model.InvoicePDF")]
    [AWSCmdlet("Calls the AWS Invoicing GetInvoicePDF API operation.", Operation = new[] {"GetInvoicePDF"}, SelectReturnType = typeof(Amazon.Invoicing.Model.GetInvoicePDFResponse))]
    [AWSCmdletOutput("Amazon.Invoicing.Model.InvoicePDF or Amazon.Invoicing.Model.GetInvoicePDFResponse",
        "This cmdlet returns an Amazon.Invoicing.Model.InvoicePDF object.",
        "The service call response (type Amazon.Invoicing.Model.GetInvoicePDFResponse) can be returned by specifying '-Select *'."
    )]
    public partial class GetINVInvoicePDFCmdlet : AmazonInvoicingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter InvoiceId
        /// <summary>
        /// <para>
        /// <para> Your unique invoice ID. </para>
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
        public System.String InvoiceId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvoicePDF'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Invoicing.Model.GetInvoicePDFResponse).
        /// Specifying the name of a property of type Amazon.Invoicing.Model.GetInvoicePDFResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvoicePDF";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InvoiceId parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InvoiceId' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InvoiceId' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Invoicing.Model.GetInvoicePDFResponse, GetINVInvoicePDFCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InvoiceId;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.InvoiceId = this.InvoiceId;
            #if MODULAR
            if (this.InvoiceId == null && ParameterWasBound(nameof(this.InvoiceId)))
            {
                WriteWarning("You are passing $null as a value for parameter InvoiceId which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Invoicing.Model.GetInvoicePDFRequest();
            
            if (cmdletContext.InvoiceId != null)
            {
                request.InvoiceId = cmdletContext.InvoiceId;
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
        
        private Amazon.Invoicing.Model.GetInvoicePDFResponse CallAWSServiceOperation(IAmazonInvoicing client, Amazon.Invoicing.Model.GetInvoicePDFRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Invoicing", "GetInvoicePDF");
            try
            {
                #if DESKTOP
                return client.GetInvoicePDF(request);
                #elif CORECLR
                return client.GetInvoicePDFAsync(request).GetAwaiter().GetResult();
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
            public System.String InvoiceId { get; set; }
            public System.Func<Amazon.Invoicing.Model.GetInvoicePDFResponse, GetINVInvoicePDFCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvoicePDF;
        }
        
    }
}
