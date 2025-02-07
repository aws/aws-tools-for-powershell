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
    /// This retrieves the invoice unit definition.
    /// </summary>
    [Cmdlet("Get", "INVInvoiceUnit")]
    [OutputType("Amazon.Invoicing.Model.GetInvoiceUnitResponse")]
    [AWSCmdlet("Calls the AWS Invoicing GetInvoiceUnit API operation.", Operation = new[] {"GetInvoiceUnit"}, SelectReturnType = typeof(Amazon.Invoicing.Model.GetInvoiceUnitResponse))]
    [AWSCmdletOutput("Amazon.Invoicing.Model.GetInvoiceUnitResponse",
        "This cmdlet returns an Amazon.Invoicing.Model.GetInvoiceUnitResponse object containing multiple properties."
    )]
    public partial class GetINVInvoiceUnitCmdlet : AmazonInvoicingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AsOf
        /// <summary>
        /// <para>
        /// <para> The state of an invoice unit at a specified time. You can see legacy invoice units
        /// that are currently deleted if the <c>AsOf</c> time is set to before it was deleted.
        /// If an <c>AsOf</c> is not provided, the default value is the current time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.DateTime? AsOf { get; set; }
        #endregion
        
        #region Parameter InvoiceUnitArn
        /// <summary>
        /// <para>
        /// <para> The ARN to identify an invoice unit. This information can't be modified or deleted.
        /// </para>
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
        public System.String InvoiceUnitArn { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Invoicing.Model.GetInvoiceUnitResponse).
        /// Specifying the name of a property of type Amazon.Invoicing.Model.GetInvoiceUnitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the InvoiceUnitArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^InvoiceUnitArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^InvoiceUnitArn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.Invoicing.Model.GetInvoiceUnitResponse, GetINVInvoiceUnitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.InvoiceUnitArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AsOf = this.AsOf;
            context.InvoiceUnitArn = this.InvoiceUnitArn;
            #if MODULAR
            if (this.InvoiceUnitArn == null && ParameterWasBound(nameof(this.InvoiceUnitArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InvoiceUnitArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.Invoicing.Model.GetInvoiceUnitRequest();
            
            if (cmdletContext.AsOf != null)
            {
                request.AsOf = cmdletContext.AsOf.Value;
            }
            if (cmdletContext.InvoiceUnitArn != null)
            {
                request.InvoiceUnitArn = cmdletContext.InvoiceUnitArn;
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
        
        private Amazon.Invoicing.Model.GetInvoiceUnitResponse CallAWSServiceOperation(IAmazonInvoicing client, Amazon.Invoicing.Model.GetInvoiceUnitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Invoicing", "GetInvoiceUnit");
            try
            {
                #if DESKTOP
                return client.GetInvoiceUnit(request);
                #elif CORECLR
                return client.GetInvoiceUnitAsync(request).GetAwaiter().GetResult();
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
            public System.DateTime? AsOf { get; set; }
            public System.String InvoiceUnitArn { get; set; }
            public System.Func<Amazon.Invoicing.Model.GetInvoiceUnitResponse, GetINVInvoiceUnitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
