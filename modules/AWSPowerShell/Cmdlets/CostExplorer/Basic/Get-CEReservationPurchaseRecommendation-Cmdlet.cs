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
using Amazon.CostExplorer;
using Amazon.CostExplorer.Model;

namespace Amazon.PowerShell.Cmdlets.CE
{
    /// <summary>
    /// Gets recommendations for which reservations to purchase. These recommendations could
    /// help you reduce your costs. Reservations provide a discounted hourly rate (up to 75%)
    /// compared to On-Demand pricing.
    /// 
    ///  
    /// <para>
    /// Amazon Web Services generates your recommendations by identifying your On-Demand usage
    /// during a specific time period and collecting your usage into categories that are eligible
    /// for a reservation. After Amazon Web Services has these categories, it simulates every
    /// combination of reservations in each category of usage to identify the best number
    /// of each type of RI to purchase to maximize your estimated savings. 
    /// </para><para>
    /// For example, Amazon Web Services automatically aggregates your Amazon EC2 Linux, shared
    /// tenancy, and c4 family usage in the US West (Oregon) Region and recommends that you
    /// buy size-flexible regional reservations to apply to the c4 family usage. Amazon Web
    /// Services recommends the smallest size instance in an instance family. This makes it
    /// easier to purchase a size-flexible RI. Amazon Web Services also shows the equal number
    /// of normalized units so that you can purchase any instance size that you want. For
    /// this example, your RI recommendation would be for <code>c4.large</code> because that
    /// is the smallest size instance in the c4 instance family.
    /// </para><br/><br/>In the AWS.Tools.CostExplorer module, this cmdlet automatically pages all available results to the pipeline - parameters related to iteration are only needed if you want to manually control the paginated output. To disable autopagination, use -NoAutoIteration.
    /// </summary>
    [Cmdlet("Get", "CEReservationPurchaseRecommendation")]
    [OutputType("Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetReservationPurchaseRecommendation API operation.", Operation = new[] {"GetReservationPurchaseRecommendation"}, SelectReturnType = typeof(Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse))]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse",
        "This cmdlet returns an Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCEReservationPurchaseRecommendationCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID that is associated with the recommendation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AccountScope
        /// <summary>
        /// <para>
        /// <para>The account scope that you want your recommendations for. Amazon Web Services calculates
        /// recommendations including the management account and member accounts if the value
        /// is set to <code>PAYER</code>. If the value is <code>LINKED</code>, recommendations
        /// are calculated for individual member accounts only.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.AccountScope")]
        public Amazon.CostExplorer.AccountScope AccountScope { get; set; }
        #endregion
        
        #region Parameter Filter
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.CostExplorer.Model.Expression Filter { get; set; }
        #endregion
        
        #region Parameter LookbackPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The number of previous days that you want Amazon Web Services to consider when it
        /// calculates your recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LookbackPeriodInDays")]
        [AWSConstantClassSource("Amazon.CostExplorer.LookbackPeriodInDays")]
        public Amazon.CostExplorer.LookbackPeriodInDays LookbackPeriodInDay { get; set; }
        #endregion
        
        #region Parameter EC2Specification_OfferingClass
        /// <summary>
        /// <para>
        /// <para>Indicates whether you want a recommendation for standard or convertible reservations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceSpecification_EC2Specification_OfferingClass")]
        [AWSConstantClassSource("Amazon.CostExplorer.OfferingClass")]
        public Amazon.CostExplorer.OfferingClass EC2Specification_OfferingClass { get; set; }
        #endregion
        
        #region Parameter PaymentOption
        /// <summary>
        /// <para>
        /// <para>The reservation purchase option that you want recommendations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.CostExplorer.PaymentOption")]
        public Amazon.CostExplorer.PaymentOption PaymentOption { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The specific service that you want recommendations for.</para>
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
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter TermInYear
        /// <summary>
        /// <para>
        /// <para>The reservation term that you want recommendations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("TermInYears")]
        [AWSConstantClassSource("Amazon.CostExplorer.TermInYears")]
        public Amazon.CostExplorer.TermInYears TermInYear { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results that you want to retrieve.</para>
        /// </para>
        /// <para>
        /// <br/><b>Note:</b> In the AWS.Tools.CostExplorer module, this parameter is only used if you are manually controlling output pagination of the service API call.
        /// <br/>In order to manually control output pagination, use '-NextPageToken $null' for the first call and '-NextPageToken $AWSHistory.LastServiceResponse.NextPageToken' for subsequent calls.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NextToken")]
        public System.String NextPageToken { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The number of recommendations that you want returned in a single response object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? PageSize { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse).
        /// Specifying the name of a property of type Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Service parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Service' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Service' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter NoAutoIteration
        #if MODULAR
        /// <summary>
        /// By default the cmdlet will auto-iterate and retrieve all results to the pipeline by performing multiple
        /// service calls. If set, the cmdlet will retrieve only the next 'page' of results using the value of NextPageToken
        /// as the start point.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter NoAutoIteration { get; set; }
        #endif
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse, GetCEReservationPurchaseRecommendationCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Service;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccountId = this.AccountId;
            context.AccountScope = this.AccountScope;
            context.Filter = this.Filter;
            context.LookbackPeriodInDay = this.LookbackPeriodInDay;
            context.NextPageToken = this.NextPageToken;
            context.PageSize = this.PageSize;
            context.PaymentOption = this.PaymentOption;
            context.Service = this.Service;
            #if MODULAR
            if (this.Service == null && ParameterWasBound(nameof(this.Service)))
            {
                WriteWarning("You are passing $null as a value for parameter Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.EC2Specification_OfferingClass = this.EC2Specification_OfferingClass;
            context.TermInYear = this.TermInYear;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        #if MODULAR
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            var useParameterSelect = this.Select.StartsWith("^") || this.PassThru.IsPresent;
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            
            // create request and set iteration invariants
            var request = new Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.AccountScope != null)
            {
                request.AccountScope = cmdletContext.AccountScope;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.LookbackPeriodInDay != null)
            {
                request.LookbackPeriodInDays = cmdletContext.LookbackPeriodInDay;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.PaymentOption != null)
            {
                request.PaymentOption = cmdletContext.PaymentOption;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            
             // populate ServiceSpecification
            var requestServiceSpecificationIsNull = true;
            request.ServiceSpecification = new Amazon.CostExplorer.Model.ServiceSpecification();
            Amazon.CostExplorer.Model.EC2Specification requestServiceSpecification_serviceSpecification_EC2Specification = null;
            
             // populate EC2Specification
            var requestServiceSpecification_serviceSpecification_EC2SpecificationIsNull = true;
            requestServiceSpecification_serviceSpecification_EC2Specification = new Amazon.CostExplorer.Model.EC2Specification();
            Amazon.CostExplorer.OfferingClass requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass = null;
            if (cmdletContext.EC2Specification_OfferingClass != null)
            {
                requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass = cmdletContext.EC2Specification_OfferingClass;
            }
            if (requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass != null)
            {
                requestServiceSpecification_serviceSpecification_EC2Specification.OfferingClass = requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass;
                requestServiceSpecification_serviceSpecification_EC2SpecificationIsNull = false;
            }
             // determine if requestServiceSpecification_serviceSpecification_EC2Specification should be set to null
            if (requestServiceSpecification_serviceSpecification_EC2SpecificationIsNull)
            {
                requestServiceSpecification_serviceSpecification_EC2Specification = null;
            }
            if (requestServiceSpecification_serviceSpecification_EC2Specification != null)
            {
                request.ServiceSpecification.EC2Specification = requestServiceSpecification_serviceSpecification_EC2Specification;
                requestServiceSpecificationIsNull = false;
            }
             // determine if request.ServiceSpecification should be set to null
            if (requestServiceSpecificationIsNull)
            {
                request.ServiceSpecification = null;
            }
            if (cmdletContext.TermInYear != null)
            {
                request.TermInYears = cmdletContext.TermInYear;
            }
            
            // Initialize loop variant and commence piping
            var _nextToken = cmdletContext.NextPageToken;
            var _userControllingPaging = this.NoAutoIteration.IsPresent || ParameterWasBound(nameof(this.NextPageToken));
            
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            do
            {
                request.NextPageToken = _nextToken;
                
                CmdletOutput output;
                
                try
                {
                    
                    var response = CallAWSServiceOperation(client, request);
                    
                    object pipelineOutput = null;
                    if (!useParameterSelect)
                    {
                        pipelineOutput = cmdletContext.Select(response, this);
                    }
                    output = new CmdletOutput
                    {
                        PipelineOutput = pipelineOutput,
                        ServiceResponse = response
                    };
                    
                    _nextToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    output = new CmdletOutput { ErrorResponse = e };
                }
                
                ProcessOutput(output);
                
            } while (!_userControllingPaging && AutoIterationHelpers.HasValue(_nextToken));
            
            if (useParameterSelect)
            {
                WriteObject(cmdletContext.Select(null, this));
            }
            
            
            return null;
        }
        #else
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.AccountScope != null)
            {
                request.AccountScope = cmdletContext.AccountScope;
            }
            if (cmdletContext.Filter != null)
            {
                request.Filter = cmdletContext.Filter;
            }
            if (cmdletContext.LookbackPeriodInDay != null)
            {
                request.LookbackPeriodInDays = cmdletContext.LookbackPeriodInDay;
            }
            if (cmdletContext.NextPageToken != null)
            {
                request.NextPageToken = cmdletContext.NextPageToken;
            }
            if (cmdletContext.PageSize != null)
            {
                request.PageSize = cmdletContext.PageSize.Value;
            }
            if (cmdletContext.PaymentOption != null)
            {
                request.PaymentOption = cmdletContext.PaymentOption;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            
             // populate ServiceSpecification
            var requestServiceSpecificationIsNull = true;
            request.ServiceSpecification = new Amazon.CostExplorer.Model.ServiceSpecification();
            Amazon.CostExplorer.Model.EC2Specification requestServiceSpecification_serviceSpecification_EC2Specification = null;
            
             // populate EC2Specification
            var requestServiceSpecification_serviceSpecification_EC2SpecificationIsNull = true;
            requestServiceSpecification_serviceSpecification_EC2Specification = new Amazon.CostExplorer.Model.EC2Specification();
            Amazon.CostExplorer.OfferingClass requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass = null;
            if (cmdletContext.EC2Specification_OfferingClass != null)
            {
                requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass = cmdletContext.EC2Specification_OfferingClass;
            }
            if (requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass != null)
            {
                requestServiceSpecification_serviceSpecification_EC2Specification.OfferingClass = requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass;
                requestServiceSpecification_serviceSpecification_EC2SpecificationIsNull = false;
            }
             // determine if requestServiceSpecification_serviceSpecification_EC2Specification should be set to null
            if (requestServiceSpecification_serviceSpecification_EC2SpecificationIsNull)
            {
                requestServiceSpecification_serviceSpecification_EC2Specification = null;
            }
            if (requestServiceSpecification_serviceSpecification_EC2Specification != null)
            {
                request.ServiceSpecification.EC2Specification = requestServiceSpecification_serviceSpecification_EC2Specification;
                requestServiceSpecificationIsNull = false;
            }
             // determine if request.ServiceSpecification should be set to null
            if (requestServiceSpecificationIsNull)
            {
                request.ServiceSpecification = null;
            }
            if (cmdletContext.TermInYear != null)
            {
                request.TermInYears = cmdletContext.TermInYear;
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
        #endif
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetReservationPurchaseRecommendation");
            try
            {
                #if DESKTOP
                return client.GetReservationPurchaseRecommendation(request);
                #elif CORECLR
                return client.GetReservationPurchaseRecommendationAsync(request).GetAwaiter().GetResult();
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
            public System.String AccountId { get; set; }
            public Amazon.CostExplorer.AccountScope AccountScope { get; set; }
            public Amazon.CostExplorer.Model.Expression Filter { get; set; }
            public Amazon.CostExplorer.LookbackPeriodInDays LookbackPeriodInDay { get; set; }
            public System.String NextPageToken { get; set; }
            public System.Int32? PageSize { get; set; }
            public Amazon.CostExplorer.PaymentOption PaymentOption { get; set; }
            public System.String Service { get; set; }
            public Amazon.CostExplorer.OfferingClass EC2Specification_OfferingClass { get; set; }
            public Amazon.CostExplorer.TermInYears TermInYear { get; set; }
            public System.Func<Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse, GetCEReservationPurchaseRecommendationCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
