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
    /// This creates a new invoice unit with the provided definition.
    /// </summary>
    [Cmdlet("New", "INVInvoiceUnit", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("System.String")]
    [AWSCmdlet("Calls the AWS Invoicing CreateInvoiceUnit API operation.", Operation = new[] {"CreateInvoiceUnit"}, SelectReturnType = typeof(Amazon.Invoicing.Model.CreateInvoiceUnitResponse))]
    [AWSCmdletOutput("System.String or Amazon.Invoicing.Model.CreateInvoiceUnitResponse",
        "This cmdlet returns a System.String object.",
        "The service call response (type Amazon.Invoicing.Model.CreateInvoiceUnitResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewINVInvoiceUnitCmdlet : AmazonInvoicingClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para> The invoice unit's description. This can be changed at a later time. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter InvoiceReceiver
        /// <summary>
        /// <para>
        /// <para> The Amazon Web Services account ID chosen to be the receiver of an invoice unit.
        /// All invoices generated for that invoice unit will be sent to this account ID. </para>
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
        public System.String InvoiceReceiver { get; set; }
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
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para> The unique name of the invoice unit that is shown on the generated invoice. This
        /// can't be changed once it is set. To change this name, you must delete the invoice
        /// unit recreate. </para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ResourceTag
        /// <summary>
        /// <para>
        /// <para> The tag structure that contains a tag key and value. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ResourceTags")]
        public Amazon.Invoicing.Model.ResourceTag[] ResourceTag { get; set; }
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
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Invoicing.Model.CreateInvoiceUnitResponse).
        /// Specifying the name of a property of type Amazon.Invoicing.Model.CreateInvoiceUnitResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "InvoiceUnitArn";
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-INVInvoiceUnit (CreateInvoiceUnit)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Invoicing.Model.CreateInvoiceUnitResponse, NewINVInvoiceUnitCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.Description = this.Description;
            context.InvoiceReceiver = this.InvoiceReceiver;
            #if MODULAR
            if (this.InvoiceReceiver == null && ParameterWasBound(nameof(this.InvoiceReceiver)))
            {
                WriteWarning("You are passing $null as a value for parameter InvoiceReceiver which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.ResourceTag != null)
            {
                context.ResourceTag = new List<Amazon.Invoicing.Model.ResourceTag>(this.ResourceTag);
            }
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
            var request = new Amazon.Invoicing.Model.CreateInvoiceUnitRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.InvoiceReceiver != null)
            {
                request.InvoiceReceiver = cmdletContext.InvoiceReceiver;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ResourceTag != null)
            {
                request.ResourceTags = cmdletContext.ResourceTag;
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
        
        private Amazon.Invoicing.Model.CreateInvoiceUnitResponse CallAWSServiceOperation(IAmazonInvoicing client, Amazon.Invoicing.Model.CreateInvoiceUnitRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Invoicing", "CreateInvoiceUnit");
            try
            {
                #if DESKTOP
                return client.CreateInvoiceUnit(request);
                #elif CORECLR
                return client.CreateInvoiceUnitAsync(request).GetAwaiter().GetResult();
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
            public System.String InvoiceReceiver { get; set; }
            public System.String Name { get; set; }
            public List<Amazon.Invoicing.Model.ResourceTag> ResourceTag { get; set; }
            public List<System.String> Rule_LinkedAccount { get; set; }
            public System.Boolean? TaxInheritanceDisabled { get; set; }
            public System.Func<Amazon.Invoicing.Model.CreateInvoiceUnitResponse, NewINVInvoiceUnitCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.InvoiceUnitArn;
        }
        
    }
}
