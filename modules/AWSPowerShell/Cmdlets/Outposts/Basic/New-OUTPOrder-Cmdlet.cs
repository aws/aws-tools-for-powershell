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
using Amazon.Outposts;
using Amazon.Outposts.Model;

namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Creates an order for an Outpost.
    /// </summary>
    [Cmdlet("New", "OUTPOrder", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.Order")]
    [AWSCmdlet("Calls the AWS Outposts CreateOrder API operation.", Operation = new[] {"CreateOrder"}, SelectReturnType = typeof(Amazon.Outposts.Model.CreateOrderResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.Order or Amazon.Outposts.Model.CreateOrderResponse",
        "This cmdlet returns an Amazon.Outposts.Model.Order object.",
        "The service call response (type Amazon.Outposts.Model.CreateOrderResponse) can be returned by specifying '-Select *'."
    )]
    public partial class NewOUTPOrderCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter LineItem
        /// <summary>
        /// <para>
        /// <para>The line items that make up the order.</para>
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
        [Alias("LineItems")]
        public Amazon.Outposts.Model.LineItemRequest[] LineItem { get; set; }
        #endregion
        
        #region Parameter OutpostIdentifier
        /// <summary>
        /// <para>
        /// <para> The ID or the Amazon Resource Name (ARN) of the Outpost. </para>
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
        public System.String OutpostIdentifier { get; set; }
        #endregion
        
        #region Parameter PaymentOption
        /// <summary>
        /// <para>
        /// <para>The payment option.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.Outposts.PaymentOption")]
        public Amazon.Outposts.PaymentOption PaymentOption { get; set; }
        #endregion
        
        #region Parameter PaymentTerm
        /// <summary>
        /// <para>
        /// <para>The payment terms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.Outposts.PaymentTerm")]
        public Amazon.Outposts.PaymentTerm PaymentTerm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Order'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.CreateOrderResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.CreateOrderResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Order";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OutpostIdentifier parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OutpostIdentifier' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OutpostIdentifier' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutpostIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "New-OUTPOrder (CreateOrder)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.CreateOrderResponse, NewOUTPOrderCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OutpostIdentifier;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.LineItem != null)
            {
                context.LineItem = new List<Amazon.Outposts.Model.LineItemRequest>(this.LineItem);
            }
            #if MODULAR
            if (this.LineItem == null && ParameterWasBound(nameof(this.LineItem)))
            {
                WriteWarning("You are passing $null as a value for parameter LineItem which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.OutpostIdentifier = this.OutpostIdentifier;
            #if MODULAR
            if (this.OutpostIdentifier == null && ParameterWasBound(nameof(this.OutpostIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter OutpostIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentOption = this.PaymentOption;
            #if MODULAR
            if (this.PaymentOption == null && ParameterWasBound(nameof(this.PaymentOption)))
            {
                WriteWarning("You are passing $null as a value for parameter PaymentOption which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.PaymentTerm = this.PaymentTerm;
            
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
            var request = new Amazon.Outposts.Model.CreateOrderRequest();
            
            if (cmdletContext.LineItem != null)
            {
                request.LineItems = cmdletContext.LineItem;
            }
            if (cmdletContext.OutpostIdentifier != null)
            {
                request.OutpostIdentifier = cmdletContext.OutpostIdentifier;
            }
            if (cmdletContext.PaymentOption != null)
            {
                request.PaymentOption = cmdletContext.PaymentOption;
            }
            if (cmdletContext.PaymentTerm != null)
            {
                request.PaymentTerm = cmdletContext.PaymentTerm;
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
        
        private Amazon.Outposts.Model.CreateOrderResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.CreateOrderRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "CreateOrder");
            try
            {
                #if DESKTOP
                return client.CreateOrder(request);
                #elif CORECLR
                return client.CreateOrderAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.Outposts.Model.LineItemRequest> LineItem { get; set; }
            public System.String OutpostIdentifier { get; set; }
            public Amazon.Outposts.PaymentOption PaymentOption { get; set; }
            public Amazon.Outposts.PaymentTerm PaymentTerm { get; set; }
            public System.Func<Amazon.Outposts.Model.CreateOrderResponse, NewOUTPOrderCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Order;
        }
        
    }
}
