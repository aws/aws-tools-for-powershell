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
using Amazon.BillingConductor;
using Amazon.BillingConductor.Model;

namespace Amazon.PowerShell.Cmdlets.ABC
{
    /// <summary>
    /// A paginated call to get a list of all custom line item versions.
    /// </summary>
    [Cmdlet("Get", "ABCCustomLineItemVersionList")]
    [OutputType("Amazon.BillingConductor.Model.CustomLineItemVersionListElement")]
    [AWSCmdlet("Calls the AWSBillingConductor ListCustomLineItemVersions API operation.", Operation = new[] {"ListCustomLineItemVersions"}, SelectReturnType = typeof(Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse))]
    [AWSCmdletOutput("Amazon.BillingConductor.Model.CustomLineItemVersionListElement or Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse",
        "This cmdlet returns a collection of Amazon.BillingConductor.Model.CustomLineItemVersionListElement objects.",
        "The service call response (type Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetABCCustomLineItemVersionListCmdlet : AmazonBillingConductorClientCmdlet, IExecutor
    {
        
        #region Parameter Arn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) for the custom line item.</para>
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
        public System.String Arn { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_EndBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The exclusive end billing period that defines a billing period range where a custom
        /// line item version is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_BillingPeriodRange_EndBillingPeriod")]
        public System.String BillingPeriodRange_EndBillingPeriod { get; set; }
        #endregion
        
        #region Parameter BillingPeriodRange_StartBillingPeriod
        /// <summary>
        /// <para>
        /// <para>The inclusive start billing period that defines a billing period range where a custom
        /// line item version is applied.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("Filters_BillingPeriodRange_StartBillingPeriod")]
        public System.String BillingPeriodRange_StartBillingPeriod { get; set; }
        #endregion
        
        #region Parameter MaxResult
        /// <summary>
        /// <para>
        /// <para>The maximum number of custom line item versions to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("MaxResults")]
        public System.Int32? MaxResult { get; set; }
        #endregion
        
        #region Parameter NextToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that's used on subsequent calls to retrieve custom line item
        /// versions.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String NextToken { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'CustomLineItemVersions'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse).
        /// Specifying the name of a property of type Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "CustomLineItemVersions";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Arn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Arn' instead. This parameter will be removed in a future version.")]
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
                context.Select = CreateSelectDelegate<Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse, GetABCCustomLineItemVersionListCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Arn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Arn = this.Arn;
            #if MODULAR
            if (this.Arn == null && ParameterWasBound(nameof(this.Arn)))
            {
                WriteWarning("You are passing $null as a value for parameter Arn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.BillingPeriodRange_EndBillingPeriod = this.BillingPeriodRange_EndBillingPeriod;
            context.BillingPeriodRange_StartBillingPeriod = this.BillingPeriodRange_StartBillingPeriod;
            context.MaxResult = this.MaxResult;
            context.NextToken = this.NextToken;
            
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
            var request = new Amazon.BillingConductor.Model.ListCustomLineItemVersionsRequest();
            
            if (cmdletContext.Arn != null)
            {
                request.Arn = cmdletContext.Arn;
            }
            
             // populate Filters
            var requestFiltersIsNull = true;
            request.Filters = new Amazon.BillingConductor.Model.ListCustomLineItemVersionsFilter();
            Amazon.BillingConductor.Model.ListCustomLineItemVersionsBillingPeriodRangeFilter requestFilters_filters_BillingPeriodRange = null;
            
             // populate BillingPeriodRange
            var requestFilters_filters_BillingPeriodRangeIsNull = true;
            requestFilters_filters_BillingPeriodRange = new Amazon.BillingConductor.Model.ListCustomLineItemVersionsBillingPeriodRangeFilter();
            System.String requestFilters_filters_BillingPeriodRange_billingPeriodRange_EndBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_EndBillingPeriod != null)
            {
                requestFilters_filters_BillingPeriodRange_billingPeriodRange_EndBillingPeriod = cmdletContext.BillingPeriodRange_EndBillingPeriod;
            }
            if (requestFilters_filters_BillingPeriodRange_billingPeriodRange_EndBillingPeriod != null)
            {
                requestFilters_filters_BillingPeriodRange.EndBillingPeriod = requestFilters_filters_BillingPeriodRange_billingPeriodRange_EndBillingPeriod;
                requestFilters_filters_BillingPeriodRangeIsNull = false;
            }
            System.String requestFilters_filters_BillingPeriodRange_billingPeriodRange_StartBillingPeriod = null;
            if (cmdletContext.BillingPeriodRange_StartBillingPeriod != null)
            {
                requestFilters_filters_BillingPeriodRange_billingPeriodRange_StartBillingPeriod = cmdletContext.BillingPeriodRange_StartBillingPeriod;
            }
            if (requestFilters_filters_BillingPeriodRange_billingPeriodRange_StartBillingPeriod != null)
            {
                requestFilters_filters_BillingPeriodRange.StartBillingPeriod = requestFilters_filters_BillingPeriodRange_billingPeriodRange_StartBillingPeriod;
                requestFilters_filters_BillingPeriodRangeIsNull = false;
            }
             // determine if requestFilters_filters_BillingPeriodRange should be set to null
            if (requestFilters_filters_BillingPeriodRangeIsNull)
            {
                requestFilters_filters_BillingPeriodRange = null;
            }
            if (requestFilters_filters_BillingPeriodRange != null)
            {
                request.Filters.BillingPeriodRange = requestFilters_filters_BillingPeriodRange;
                requestFiltersIsNull = false;
            }
             // determine if request.Filters should be set to null
            if (requestFiltersIsNull)
            {
                request.Filters = null;
            }
            if (cmdletContext.MaxResult != null)
            {
                request.MaxResults = cmdletContext.MaxResult.Value;
            }
            if (cmdletContext.NextToken != null)
            {
                request.NextToken = cmdletContext.NextToken;
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
        
        private Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse CallAWSServiceOperation(IAmazonBillingConductor client, Amazon.BillingConductor.Model.ListCustomLineItemVersionsRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWSBillingConductor", "ListCustomLineItemVersions");
            try
            {
                #if DESKTOP
                return client.ListCustomLineItemVersions(request);
                #elif CORECLR
                return client.ListCustomLineItemVersionsAsync(request).GetAwaiter().GetResult();
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
            public System.String Arn { get; set; }
            public System.String BillingPeriodRange_EndBillingPeriod { get; set; }
            public System.String BillingPeriodRange_StartBillingPeriod { get; set; }
            public System.Int32? MaxResult { get; set; }
            public System.String NextToken { get; set; }
            public System.Func<Amazon.BillingConductor.Model.ListCustomLineItemVersionsResponse, GetABCCustomLineItemVersionListCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.CustomLineItemVersions;
        }
        
    }
}
