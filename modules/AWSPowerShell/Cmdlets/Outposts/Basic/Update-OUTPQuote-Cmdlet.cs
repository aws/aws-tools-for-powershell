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
using Amazon.Outposts;
using Amazon.Outposts.Model;

#pragma warning disable CS0618, CS0612
namespace Amazon.PowerShell.Cmdlets.OUTP
{
    /// <summary>
    /// Updates the specified quote. You can modify the requested capacities, constraints,
    /// payment options, payment terms, or Outpost association.
    /// </summary>
    [Cmdlet("Update", "OUTPQuote", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.Outposts.Model.Quote")]
    [AWSCmdlet("Calls the AWS Outposts UpdateQuote API operation.", Operation = new[] {"UpdateQuote"}, SelectReturnType = typeof(Amazon.Outposts.Model.UpdateQuoteResponse))]
    [AWSCmdletOutput("Amazon.Outposts.Model.Quote or Amazon.Outposts.Model.UpdateQuoteResponse",
        "This cmdlet returns an Amazon.Outposts.Model.Quote object.",
        "The service call response (type Amazon.Outposts.Model.UpdateQuoteResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateOUTPQuoteCmdlet : AmazonOutpostsClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        
        #region Parameter CountryCode
        /// <summary>
        /// <para>
        /// <para>The country code for the Outpost site location.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String CountryCode { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description for the quote.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter OutpostIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the Outpost to associate with the quote. Specify an empty string
        /// to remove the Outpost association.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String OutpostIdentifier { get; set; }
        #endregion
        
        #region Parameter QuoteIdentifier
        /// <summary>
        /// <para>
        /// <para>The ID or ARN of the quote.</para>
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
        public System.String QuoteIdentifier { get; set; }
        #endregion
        
        #region Parameter RequestedCapacity
        /// <summary>
        /// <para>
        /// <para>The updated capacity requirements for the quote.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedCapacities")]
        public Amazon.Outposts.Model.QuoteCapacity[] RequestedCapacity { get; set; }
        #endregion
        
        #region Parameter RequestedConstraint
        /// <summary>
        /// <para>
        /// <para>The updated physical constraints for the quote.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedConstraints")]
        public Amazon.Outposts.Model.QuoteConstraint[] RequestedConstraint { get; set; }
        #endregion
        
        #region Parameter RequestedPaymentOption
        /// <summary>
        /// <para>
        /// <para>The updated payment options to include in the quote pricing.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedPaymentOptions")]
        public System.String[] RequestedPaymentOption { get; set; }
        #endregion
        
        #region Parameter RequestedPaymentTerm
        /// <summary>
        /// <para>
        /// <para>The updated payment terms to include in the quote pricing.</para><para />
        /// Starting with version 4 of the SDK this property will default to null. If no data for this property is returned
        /// from the service the property will also be null. This was changed to improve performance and allow the SDK and caller
        /// to distinguish between a property not set or a property being empty to clear out a value. To retain the previous
        /// SDK behavior set the AWSConfigs.InitializeCollections static property to true.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("RequestedPaymentTerms")]
        public System.String[] RequestedPaymentTerm { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Quote'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.Outposts.Model.UpdateQuoteResponse).
        /// Specifying the name of a property of type Amazon.Outposts.Model.UpdateQuoteResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Quote";
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
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QuoteIdentifier), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-OUTPQuote (UpdateQuote)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.Outposts.Model.UpdateQuoteResponse, UpdateOUTPQuoteCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.CountryCode = this.CountryCode;
            context.Description = this.Description;
            context.OutpostIdentifier = this.OutpostIdentifier;
            context.QuoteIdentifier = this.QuoteIdentifier;
            #if MODULAR
            if (this.QuoteIdentifier == null && ParameterWasBound(nameof(this.QuoteIdentifier)))
            {
                WriteWarning("You are passing $null as a value for parameter QuoteIdentifier which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.RequestedCapacity != null)
            {
                context.RequestedCapacity = new List<Amazon.Outposts.Model.QuoteCapacity>(this.RequestedCapacity);
            }
            if (this.RequestedConstraint != null)
            {
                context.RequestedConstraint = new List<Amazon.Outposts.Model.QuoteConstraint>(this.RequestedConstraint);
            }
            if (this.RequestedPaymentOption != null)
            {
                context.RequestedPaymentOption = new List<System.String>(this.RequestedPaymentOption);
            }
            if (this.RequestedPaymentTerm != null)
            {
                context.RequestedPaymentTerm = new List<System.String>(this.RequestedPaymentTerm);
            }
            
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
            var request = new Amazon.Outposts.Model.UpdateQuoteRequest();
            
            if (cmdletContext.CountryCode != null)
            {
                request.CountryCode = cmdletContext.CountryCode;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.OutpostIdentifier != null)
            {
                request.OutpostIdentifier = cmdletContext.OutpostIdentifier;
            }
            if (cmdletContext.QuoteIdentifier != null)
            {
                request.QuoteIdentifier = cmdletContext.QuoteIdentifier;
            }
            if (cmdletContext.RequestedCapacity != null)
            {
                request.RequestedCapacities = cmdletContext.RequestedCapacity;
            }
            if (cmdletContext.RequestedConstraint != null)
            {
                request.RequestedConstraints = cmdletContext.RequestedConstraint;
            }
            if (cmdletContext.RequestedPaymentOption != null)
            {
                request.RequestedPaymentOptions = cmdletContext.RequestedPaymentOption;
            }
            if (cmdletContext.RequestedPaymentTerm != null)
            {
                request.RequestedPaymentTerms = cmdletContext.RequestedPaymentTerm;
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
        
        private Amazon.Outposts.Model.UpdateQuoteResponse CallAWSServiceOperation(IAmazonOutposts client, Amazon.Outposts.Model.UpdateQuoteRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Outposts", "UpdateQuote");
            try
            {
                return client.UpdateQuoteAsync(request, _cancellationTokenSource.Token).GetAwaiter().GetResult();
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
            public System.String CountryCode { get; set; }
            public System.String Description { get; set; }
            public System.String OutpostIdentifier { get; set; }
            public System.String QuoteIdentifier { get; set; }
            public List<Amazon.Outposts.Model.QuoteCapacity> RequestedCapacity { get; set; }
            public List<Amazon.Outposts.Model.QuoteConstraint> RequestedConstraint { get; set; }
            public List<System.String> RequestedPaymentOption { get; set; }
            public List<System.String> RequestedPaymentTerm { get; set; }
            public System.Func<Amazon.Outposts.Model.UpdateQuoteResponse, UpdateOUTPQuoteCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Quote;
        }
        
    }
}
