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
using Amazon.Invoicing;
using Amazon.Invoicing.Model;

namespace Amazon.PowerShell.Cmdlets.INV
{
    /// <summary>
    /// You can update the invoice unit configuration at any time, and Amazon Web Services
    /// will use the latest configuration at the end of the month.
    /// </summary>
    [Cmdlet("Update", "INVInvoiceUnit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Invoicing UpdateInvoiceUnit API operation.", Operation = new[] {"UpdateInvoiceUnit"}, SelectReturnType = typeof(Amazon.Invoicing.Model.UpdateInvoiceUnitResponse))]
    [AWSCmdletOutput("System.String or Amazon.Invoicing.Model.UpdateInvoiceUnitResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Invoicing.Model.UpdateInvoiceUnitResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateINVInvoiceUnitCmdlet : AmazonInvoicingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>The assigned description for an invoice unit. This information can't be modified or
        /// deleted. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InvoiceUnitArn
        /// <summary>
        /// <para>
        /// <para>The ARN to identify an invoice unit. This information can't be modified or deleted.
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
        
        #region Parameter Rule_LinkedAccount
        /// <summary>
        /// <para>
        /// <para>The list of <c>LINKED_ACCOUNT</c> IDs where charges are included within the invoice
        /// unit. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Rule_LinkedAccounts")]
        public System.String[] Rule_LinkedAccount { get; set; }
        #endregion
        
        #region Parameter TaxInheritanceDisabled
        /// <summary>
        /// <para>
        /// <para>Whether the invoice unit based tax inheritance is/ should be enabled or disabled.
        /// </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? TaxInheritanceDisabled { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'InvoiceUnitArn'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Invoicing.Model.UpdateInvoiceUnitResponse).
        /// Specifying the name of a property of type Amazon.Invoicing.Model.UpdateInvoiceUnitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvoiceUnitArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.InvoiceUnitArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-INVInvoiceUnit (UpdateInvoiceUnit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Invoicing.Model.UpdateInvoiceUnitResponse, UpdateINVInvoiceUnitCmdlet>(Select) ??
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
            context.Description = this.Description;
            context.InvoiceUnitArn = this.InvoiceUnitArn;
            #if MODULAR
            if (this.InvoiceUnitArn == null && ParameterWasBound(nameof(this.InvoiceUnitArn)))
            {
                WriteWarning("You are passing $null as a value for parameter InvoiceUnitArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.Rule_LinkedAccount != null)
            {
                context.Rule_LinkedAccount = new List<System.String>(this.Rule_LinkedAccount);
            }
            context.TaxInheritanceDisabled = this.TaxInheritanceDisabled;
            
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
            var request = new Amazon.Invoicing.Model.UpdateInvoiceUnitRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InvoiceUnitArn != null)
            {
                request.InvoiceUnitArn = cmdletContext.InvoiceUnitArn;
            }
            
             // populate Rule
            var requestRuleIsNull = true;
            request.Rule = new Amazon.Invoicing.Model.InvoiceUnitRule();
            List<System.String> requestRule_rule_LinkedAccount = null;
            if (cmdletContext.Rule_LinkedAccount != null)
            {
                requestRule_rule_LinkedAccount = cmdletContext.Rule_LinkedAccount;
            }
            if (requestRule_rule_LinkedAccount != null)
            {
                request.Rule.LinkedAccounts = requestRule_rule_LinkedAccount;
                requestRuleIsNull = false;
            }
             // determine if request.Rule should be set to null
            if (requestRuleIsNull)
            {
                request.Rule = null;
            }
            if (cmdletContext.TaxInheritanceDisabled != null)
            {
                request.TaxInheritanceDisabled = cmdletContext.TaxInheritanceDisabled.Value;
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
        
        private Amazon.Invoicing.Model.UpdateInvoiceUnitResponse CallAWSServiceOperation(IAmazonInvoicing client, Amazon.Invoicing.Model.UpdateInvoiceUnitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Invoicing", "UpdateInvoiceUnit");
            try
            {
                #if DESKTOP
                return client.UpdateInvoiceUnit(request);
                #elif CORECLR
                return client.UpdateInvoiceUnitAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public System.String InvoiceUnitArn { get; set; }
            public List<System.String> Rule_LinkedAccount { get; set; }
            public System.Boolean? TaxInheritanceDisabled { get; set; }
            public System.Func<Amazon.Invoicing.Model.UpdateInvoiceUnitResponse, UpdateINVInvoiceUnitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvoiceUnitArn;
        }
        
    }
}
