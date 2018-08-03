/*******************************************************************************
 *  Copyright 2012-2018 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
    /// AWS generates your recommendations by identifying your On-Demand usage during a specific
    /// time period and collecting your usage into categories that are eligible for a reservation.
    /// After AWS has these categories, it simulates every combination of reservations in
    /// each category of usage to identify the best number of each type of RI to purchase
    /// to maximize your estimated savings. 
    /// </para><para>
    /// For example, AWS automatically aggregates your EC2 Linux, shared tenancy, and c4 family
    /// usage in the US West (Oregon) Region and recommends that you buy size-flexible regional
    /// reservations to apply to the c4 family usage. AWS recommends the smallest size instance
    /// in an instance family. This makes it easier to purchase a size-flexible RI. AWS also
    /// shows the equal number of normalized units so that you can purchase any instance size
    /// that you want. For this example, your RI recommendation would be for <code>c4.large</code>,
    /// because that is the smallest size instance in the c4 instance family.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "CEReservationPurchaseRecommendation")]
    [OutputType("Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse")]
    [AWSCmdlet("Calls the AWS Cost Explorer GetReservationPurchaseRecommendation API operation.", Operation = new[] {"GetReservationPurchaseRecommendation"})]
    [AWSCmdletOutput("Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse",
        "This cmdlet returns a Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetCEReservationPurchaseRecommendationCmdlet : AmazonCostExplorerClientCmdlet, IExecutor
    {
        
        #region Parameter AccountId
        /// <summary>
        /// <para>
        /// <para>The account ID that is associated with the recommendation. </para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String AccountId { get; set; }
        #endregion
        
        #region Parameter AccountScope
        /// <summary>
        /// <para>
        /// <para>The account scope that you want recommendations for. <code>PAYER</code> means that
        /// AWS includes the master account and any member accounts when it calculates its recommendations.
        /// <code>LINKED</code> means that AWS includes only member accounts when it calculates
        /// its recommendations.</para><para>Valid values are <code>PAYER</code> and <code>LINKED</code>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostExplorer.AccountScope")]
        public Amazon.CostExplorer.AccountScope AccountScope { get; set; }
        #endregion
        
        #region Parameter LookbackPeriodInDay
        /// <summary>
        /// <para>
        /// <para>The number of previous days that you want AWS to consider when it calculates your
        /// recommendations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("LookbackPeriodInDays")]
        [AWSConstantClassSource("Amazon.CostExplorer.LookbackPeriodInDays")]
        public Amazon.CostExplorer.LookbackPeriodInDays LookbackPeriodInDay { get; set; }
        #endregion
        
        #region Parameter EC2Specification_OfferingClass
        /// <summary>
        /// <para>
        /// <para>Whether you want a recommendation for standard or convertible reservations.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("ServiceSpecification_EC2Specification_OfferingClass")]
        [AWSConstantClassSource("Amazon.CostExplorer.OfferingClass")]
        public Amazon.CostExplorer.OfferingClass EC2Specification_OfferingClass { get; set; }
        #endregion
        
        #region Parameter PageSize
        /// <summary>
        /// <para>
        /// <para>The number of recommendations that you want returned in a single response object.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.Int32 PageSize { get; set; }
        #endregion
        
        #region Parameter PaymentOption
        /// <summary>
        /// <para>
        /// <para>The reservation purchase option that you want recommendations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [AWSConstantClassSource("Amazon.CostExplorer.PaymentOption")]
        public Amazon.CostExplorer.PaymentOption PaymentOption { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The specific service that you want recommendations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipeline = true)]
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter TermInYear
        /// <summary>
        /// <para>
        /// <para>The reservation term that you want recommendations for.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        [Alias("TermInYears")]
        [AWSConstantClassSource("Amazon.CostExplorer.TermInYears")]
        public Amazon.CostExplorer.TermInYears TermInYear { get; set; }
        #endregion
        
        #region Parameter NextPageToken
        /// <summary>
        /// <para>
        /// <para>The pagination token that indicates the next set of results that you want to retrieve.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter]
        public System.String NextPageToken { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var context = new CmdletContext
            {
                Region = this.Region,
                Credentials = this.CurrentCredentials
            };
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            context.AccountId = this.AccountId;
            context.AccountScope = this.AccountScope;
            context.LookbackPeriodInDays = this.LookbackPeriodInDay;
            context.NextPageToken = this.NextPageToken;
            if (ParameterWasBound("PageSize"))
                context.PageSize = this.PageSize;
            context.PaymentOption = this.PaymentOption;
            context.Service = this.Service;
            context.ServiceSpecification_EC2Specification_OfferingClass = this.EC2Specification_OfferingClass;
            context.TermInYears = this.TermInYear;
            
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
            var request = new Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationRequest();
            
            if (cmdletContext.AccountId != null)
            {
                request.AccountId = cmdletContext.AccountId;
            }
            if (cmdletContext.AccountScope != null)
            {
                request.AccountScope = cmdletContext.AccountScope;
            }
            if (cmdletContext.LookbackPeriodInDays != null)
            {
                request.LookbackPeriodInDays = cmdletContext.LookbackPeriodInDays;
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
            bool requestServiceSpecificationIsNull = true;
            request.ServiceSpecification = new Amazon.CostExplorer.Model.ServiceSpecification();
            Amazon.CostExplorer.Model.EC2Specification requestServiceSpecification_serviceSpecification_EC2Specification = null;
            
             // populate EC2Specification
            bool requestServiceSpecification_serviceSpecification_EC2SpecificationIsNull = true;
            requestServiceSpecification_serviceSpecification_EC2Specification = new Amazon.CostExplorer.Model.EC2Specification();
            Amazon.CostExplorer.OfferingClass requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass = null;
            if (cmdletContext.ServiceSpecification_EC2Specification_OfferingClass != null)
            {
                requestServiceSpecification_serviceSpecification_EC2Specification_eC2Specification_OfferingClass = cmdletContext.ServiceSpecification_EC2Specification_OfferingClass;
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
            if (cmdletContext.TermInYears != null)
            {
                request.TermInYears = cmdletContext.TermInYears;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(context.Credentials, context.Region);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                Dictionary<string, object> notes = null;
                object pipelineOutput = response;
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response,
                    Notes = notes
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
        
        private Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationResponse CallAWSServiceOperation(IAmazonCostExplorer client, Amazon.CostExplorer.Model.GetReservationPurchaseRecommendationRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Cost Explorer", "GetReservationPurchaseRecommendation");
            try
            {
                #if DESKTOP
                return client.GetReservationPurchaseRecommendation(request);
                #elif CORECLR
                // todo: handle AggregateException and extract true service exception for rethrow
                var task = client.GetReservationPurchaseRecommendationAsync(request);
                return task.Result;
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
            public Amazon.CostExplorer.LookbackPeriodInDays LookbackPeriodInDays { get; set; }
            public System.String NextPageToken { get; set; }
            public System.Int32? PageSize { get; set; }
            public Amazon.CostExplorer.PaymentOption PaymentOption { get; set; }
            public System.String Service { get; set; }
            public Amazon.CostExplorer.OfferingClass ServiceSpecification_EC2Specification_OfferingClass { get; set; }
            public Amazon.CostExplorer.TermInYears TermInYears { get; set; }
        }
        
    }
}
